using InvAcc.Forms;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.QrCode.Internal;

namespace InvAcc
{
    public class RegInfo
    {

        public string PcName
        {
            get
            {
                return Environment.MachineName.ToString();
            }
        }
        public static List<T_InfoTb> CompanyInfo = null;
        public string CompanyName
        {
            get
            {
                try
                {
                    if (CompanyInfo == null)
                        CompanyInfo = db.StockInfoList();
                    return (from i in CompanyInfo where i.InfoTb_ID == 9 select i.fldValue).ToList<string>().FirstOrDefault();
                }
                catch
                {
                    return "";
                }
            }
        }
        public RegInfo()
        {
            try
            {
                int i = 0;
                if (BIOSID == "")
                    i = 1;
            }
            catch { }

        }
        public string Comp_Address
        {
            get
            {
                try
                {
                    if (CompanyInfo == null)
                        CompanyInfo = db.StockInfoList();
                    return (from i in CompanyInfo where i.InfoTb_ID == 10 select i.fldValue).ToList<string>().FirstOrDefault();
                }
                catch
                {
                    return "";
                }
            }
        }
        public string Comp_Mobile
        {
            get
            {
                try
                {
                    if (CompanyInfo == null)
                        CompanyInfo = db.StockInfoList();
                    return (from i in CompanyInfo where i.InfoTb_ID == 12 select i.fldValue).ToList<string>().FirstOrDefault();
                }
                catch
                {
                    return "";
                }
            }

        }
        public string PosAddress
        {
            get
            {
                try
                {
                    if (CompanyInfo == null)
                        CompanyInfo = db.StockInfoList();
                    return (from i in CompanyInfo where i.InfoTb_ID == 11 select i.fldValue).ToList<string>().FirstOrDefault();
                }
                catch
                {
                    return "";
                }
            }
        }
        string _installedCopyName = "";
        public string installedCopyName
        {
            get
            {
                if (_installedCopyName == "")
                {
                    string ss = "";
                    try
                    {
                        ss = Serial.Substring(3, 3);
                        ss = CopyesNames.Find(x => x.Key == ss).Value;
                    }
                    catch
                    {
                        ss = "";
                    }
                    _installedCopyName = ss;
                }
                return _installedCopyName;
            }
        }
        public string LastIp;
        public string Status;
        List<KeyValuePair<string, string>> _CopyesNames = null;
        public List<KeyValuePair<string, string>> CopyesNames
        {
            get
            {

                if (_CopyesNames == null)
                {
                    _CopyesNames = new List<KeyValuePair<string, string>>();
                    _CopyesNames.Add(new KeyValuePair<string, string>("02G", "«· ÿ»Ìﬁ «·–Â»Ì ·«œ«—… «·„Œ“Ê‰ Ê«·„Õ«”»Â"));
                    _CopyesNames.Add(new KeyValuePair<string, string>("02S", "«· ÿ»Ìﬁ «·›÷Ì ·«œ«—… «·„Œ“Ê‰ Ê«·„Õ«”»Â"));
                    _CopyesNames.Add(new KeyValuePair<string, string>("02B", "«· ÿ»Ìﬁ «·»Ê—Ê‰“Ì ·«œ«—… «·„Œ“Ê‰ Ê«·„Õ«”»Â"));
                    _CopyesNames.Add(new KeyValuePair<string, string>("00W", "«·„Œ“Ê‰ «·–Â»Ì ·«œ«—… «·„Œ«“‰ Ê«·⁄„·«¡ Ê«·„Ê—œÌ‰  "));
                    _CopyesNames.Add(new KeyValuePair<string, string>("00K", "«·„Œ“Ê‰ «·»Ê—Ê‰“Ì ·«œ«—… «·„Œ«“‰ Ê«·⁄„·«¡ Ê«·„Ê—œÌ‰"));
                    _CopyesNames.Add(new KeyValuePair<string, string>("00M", " ÿ»Ìﬁ «·„” Êœ⁄«  ·«œ«—… »÷«∆⁄ Ê”·⁄ «·„” Êœ⁄  "));
                    _CopyesNames.Add(new KeyValuePair<string, string>("01I", " ÿ»Ìﬁ «·„Õ«”»Â «·–Â»Ì ·«œ«—… «·‘ƒÊ‰ «·„«·ÌÂ "));
                    _CopyesNames.Add(new KeyValuePair<string, string>("01Z", " ÿ»Ìﬁ «·„Õ«”»Â «·»Ê—Ê‰“Ì ·«œ«—… «·‘ƒÊ‰ «·„«·ÌÂ "));
                    _CopyesNames.Add(new KeyValuePair<string, string>("02R", " ÿ»Ìﬁ «·„ÿ⁄„ «·–Â»Ì ·«œ«—… «·„ÿ«⁄„ Ê«·ﬂ«›ÌÂ« "));
                    _CopyesNames.Add(new KeyValuePair<string, string>("02C", " ÿ»Ìﬁ «·„ÿ⁄„ «·»Ê—Ê‰“Ì ·«œ«—… «·„ÿ«⁄„ Ê«·ﬂ«›ÌÂ« "));
                    _CopyesNames.Add(new KeyValuePair<string, string>("02H", " ÿ»Ìﬁ «·›‰«œﬁ «·–Â»Ì ·«œ«—… «·›‰«œﬁ "));
                    _CopyesNames.Add(new KeyValuePair<string, string>("01X", " ÿ»Ìﬁ «·›‰«œﬁ «·»Ê—Ê‰“Ì ·«œ«—… «·›‰«œﬁ"));
                    _CopyesNames.Add(new KeyValuePair<string, string>("01Q", " ÿ»Ìﬁ «·⁄ﬁ«—Ì «·–Â»Ì ·«œ«—… «·⁄ﬁ«—«  Ê«·Õ”«»«  "));


                }
                return _CopyesNames;

            }
        }
        static string _BIOSID = "";
        public static string BIOSID
        {
            get
            {
                if (_BIOSID == "")
                {
                    ReadInfo();
                }
                return _BIOSID;



            }
            set
            {
                _BIOSID = value;


            }
        }
        public static string CpuID = "";
        public static string HardiskInfo = "";
        public static string OsType = "";
        public static void ReadInfo()
        {
            try
            {
                // txtProName.Text = Application.ProductName + "  " + Application.ProductVersion;
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS");
                try
                {
                    ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = searcher.Get().GetEnumerator();
                    if (managementObjectEnumerator.MoveNext())
                    {
                        ManagementObject wmi_HD = (ManagementObject)managementObjectEnumerator.Current;
                        if (string.Concat(wmi_HD["SerialNumber"]).Trim() != "")
                        {
                            BIOSID = wmi_HD["SerialNumber"].ToString();
                        }
                        else if (wmi_HD["Version"] == null)
                        {
                            BIOSID = "None";
                        }
                        else
                        {
                            BIOSID = wmi_HD["Version"].ToString().Trim();
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
                        CpuID = wmi_HD["ProcessorId"].ToString();
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
                        OsType = wmi_HD["Caption"].ToString();
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
                            HardiskInfo = wmi_HD["Caption"].ToString().Trim();
                        }
                        else if (wmi_HD["Model"] == null)
                        {
                            HardiskInfo = "None";
                        }
                        else
                        {
                            HardiskInfo = wmi_HD["Model"].ToString().Trim();
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

            }

        }
        public static Stock_DataDataContext db = new Stock_DataDataContext(VarGeneral.BranchCS);
        public static T_SYSSETTING _SysSetting;
        string _Serial = "";
        public string Serial
        {
            get
            {
                if (_Serial == "")
                {
                    RegistryKey hKey = RegisterK;

                    string s;
                    try
                    {
                        s = hKey.GetValue("vSr").ToString();
                    }
                    catch
                    {
                        s = "";
                    }
                    _Serial = s;
                }
                return _Serial;
            }
            set
            {
                Serial = value
                    ;
                RegistryKey hKey = RegisterK;

                string s;
                try
                {
                    hKey.SetValue("vSr", value);
                }
                catch
                {
                    s = "";
                }


            }
        }
        string _ActivationNo = "";
        public string ActivationNo
        {
            get
            {
                if (_ActivationNo == "")
                {
                    RegistryKey hKey = RegisterK;

                    string s;
                    try
                    {
                        s = hKey.GetValue("SSSActivationNo").ToString();
                    }
                    catch
                    {
                        s = "";
                    }
                    _ActivationNo = s;
                }
                return _ActivationNo;
            }
            set
            {
                _ActivationNo = value
                    ;
                RegistryKey hKey = RegisterK;
                registeronline();
                string s;
                try
                {
                    hKey.SetValue("SSSActivationNo", value);
                }
                catch
                {
                    try
                    {
                        hKey.CreateSubKey("SSSActivationNo");
                        hKey.SetValue("SSSActivationNo", value);
                    }
                    catch
                    {

                    }
                }


            }
        }
        public static string onlineuser = @"Data Source=SQL5075.site4now.net;Initial Catalog=DB_A720C2_Customers;User Id=DB_A720C2_Customers_admin;Password=ebrahim2007;";
        public static void registeronline()
        {
            //    onlineuser = VarGeneral.BranchCS.Replace("PROSOFT_default_1", "MRDClientsDB");
            string k = RegInfo.BIOSID;
            if (RegisterdID != "")
            {
                if (CheckForInternetConnection())
                {
                    SqlConnection con = new SqlConnection(onlineuser);
                    SqlCommand cmd = new SqlCommand(getSqlStatement(), con);
                    con.Open();
                    int dd = cmd.ExecuteNonQuery();
                    con.Close();
                    if (dd != -1)
                        RegisterdID = dd.ToString();

                }
            }

            string ss = RegisterdID;
            if (RegisterdID == "")
            {
                DataTable ta = DBUdate.DbUpdates.execute("select Client_ID From T_Clients Where BIOSID=N'" + BIOSID + "' AND CpuID=N'" + CpuID + "' AND HardiskInfo=N'" + HardiskInfo + "'", onlineuser);
                if (ta.Rows.Count > 0)
                    RegisterdID = ta.Rows[0][0].ToString();
            }


        }
        static SqlCommand sampleSqlCommand;
        static SqlDependency sampleSqlDependency;
        static SqlConnection sampleSqlConnection;

        private static void updategride()
        {

            try
            {
                DataTable ta = DBUdate.DbUpdates.execute("select * From T_Clients Where Client_ID=" + RegisterdID, onlineuser);
                if (ta.Rows.Count > 0)
                {
                    string Prog_MessageToShow = ta.Rows[0]["Prog_MessageToShow"].ToString();
                    string Prog_StartCommandToExecute = ta.Rows[0]["Prog_StartCommandToExecute"].ToString();
                    string Prog_AutoCommandToExecute = ta.Rows[0]["Prog_AutoCommandToExecute"].ToString();
                    if (Prog_MessageToShow != Properties.Settings.Default.Prog_MessageToShow)
                    {
                        Properties.Settings.Default.Prog_MessageToShow = Prog_MessageToShow;
                        showmessage(Prog_MessageToShow);
                    }
                    if (Prog_StartCommandToExecute != Properties.Settings.Default.Prog_StartCommandToExecute)
                    {
                        Properties.Settings.Default.Prog_StartCommandToExecute = Prog_StartCommandToExecute;
                        StartCommandToExecute(Prog_StartCommandToExecute);
                    }
                    if (Prog_AutoCommandToExecute != Properties.Settings.Default.Prog_AutoCommandToExecute)
                    {
                        Properties.Settings.Default.Prog_AutoCommandToExecute = Prog_AutoCommandToExecute;
                        AutoCommandToExecute(Prog_AutoCommandToExecute);
                    }
                    Properties.Settings.Default.Save();
                }
            }
            catch { }

        }

        private static void AutoCommandToExecute(string prog_MessageToShow)
        {
            if (prog_MessageToShow.StartsWith("NetworkConnectivityEnabled"))
            {
                string s = prog_MessageToShow.Split('-')[1];
                NetworkConnectivityEnabled = s;
            }
            if (prog_MessageToShow.StartsWith("BankPaperEnabled"))
            {
                string s = prog_MessageToShow.Split('-')[1];
                BankPaperEnabled = s;
            }
            if (prog_MessageToShow.StartsWith("ActivationEnabled"))
            {
                string s = prog_MessageToShow.Split('-')[1];
                ActivationEnabled = s;
            }


            if (prog_MessageToShow.StartsWith("POSForBoronzVersions"))
            {
                string s = prog_MessageToShow.Split('-')[1];
                POSForBoronzVersions = s;
            }
            if (prog_MessageToShow == "DeActivate")
            {
                ExpirationDate = DateTime.Today.ToShortDateString();
            }
            if (prog_MessageToShow.StartsWith("Activate"))
            {
                try
                {
                    string sd = prog_MessageToShow.Split('-')[1];
                    ExpirationDate = sd;
                }
                catch { }
            }
            if (prog_MessageToShow.StartsWith("SetSettings"))
            {
                try
                {
                    string sd = prog_MessageToShow.Split('-')[1];
                    T_SYSSETTING t = db.SystemSettingStock();
                    t.Seting = sd;
                    db.T_SYSSETTINGs.DeleteOnSubmit(db.SystemSettingStock());

                    db.T_SYSSETTINGs.InsertOnSubmit(t);

                }
                catch { }
                db.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
            }
            if (prog_MessageToShow.StartsWith("RemotlySet"))
            {
                string ss = prog_MessageToShow.Split('-')[1];
                RemotlyDeskTopEnabled = ss;
            }
            if (prog_MessageToShow.StartsWith("CostCenterEnable"))
            {
                string ss = prog_MessageToShow.Split('-')[1];
                CostCenterEnabled = ss;
            }

            if (prog_MessageToShow.StartsWith("BranchesEnabled"))
            {
                string ss = prog_MessageToShow.Split('-')[1];
                BranchesEnabled = ss;
            }
            if (prog_MessageToShow.StartsWith("MultipleDBEnabled"))
            {
                string ss = prog_MessageToShow.Split('-')[1];
                MultipleDBEnabled = ss;
            }
            if (prog_MessageToShow.StartsWith("POSOnlyEnable"))
            {
                string ss = prog_MessageToShow.Split('-')[1];
                POSOnlyEnable = ss;
            }

        }

        private static void StartCommandToExecute(string prog_MessageToShow)
        {
            if (prog_MessageToShow.StartsWith("NetworkConnectivityEnabled"))
            {
                string s = prog_MessageToShow.Split('-')[1];
                NetworkConnectivityEnabled = s;
            }
            if (prog_MessageToShow.StartsWith("BankPaperEnabled"))
            {
                string s = prog_MessageToShow.Split('-')[1];
                BankPaperEnabled = s;
            }
            if (prog_MessageToShow.StartsWith("ActivationEnabled"))
            {
                string s = prog_MessageToShow.Split('-')[1];
                ActivationEnabled = s;
            }


            if (prog_MessageToShow.StartsWith("POSForBoronzVersions"))
            {
                string s = prog_MessageToShow.Split('-')[1];
                POSForBoronzVersions = s;
            }
            if (prog_MessageToShow == "DeActivate")
            {
                ExpirationDate = DateTime.Today.ToShortDateString();
            }
            if (prog_MessageToShow.StartsWith("Activate"))
            {
                try
                {
                    string sd = prog_MessageToShow.Split('-')[1];
                    ExpirationDate = sd;
                }
                catch { }
            }
            if (prog_MessageToShow.StartsWith("SetSettings"))
            {
                try
                {
                    string sd = prog_MessageToShow.Split('-')[1];
                    T_SYSSETTING t = db.SystemSettingStock();
                    t.Seting = sd;
                    db.T_SYSSETTINGs.DeleteOnSubmit(db.SystemSettingStock());

                    db.T_SYSSETTINGs.InsertOnSubmit(t);

                }
                catch { }
                db.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
            }
            if (prog_MessageToShow.StartsWith("RemotlySet"))
            {
                string ss = prog_MessageToShow.Split('-')[1];
                RemotlyDeskTopEnabled = ss;
            }
            if (prog_MessageToShow.StartsWith("CostCenterEnable"))
            {
                string ss = prog_MessageToShow.Split('-')[1];
                CostCenterEnabled = ss;
            }

            if (prog_MessageToShow.StartsWith("BranchesEnabled"))
            {
                string ss = prog_MessageToShow.Split('-')[1];
                BranchesEnabled = ss;
            }
            if (prog_MessageToShow.StartsWith("MultipleDBEnabled"))
            {
                string ss = prog_MessageToShow.Split('-')[1];
                MultipleDBEnabled = ss;
            }
            if (prog_MessageToShow.StartsWith("POSOnlyEnable"))
            {
                string ss = prog_MessageToShow.Split('-')[1];
                POSOnlyEnable = ss;
            }
        }

        private static void showmessage(string prog_MessageToShow)
        {
            MessageBox.Show(prog_MessageToShow);
        }
        public static string ServConString = @"Data Source=SQL5075.site4now.net;Initial Catalog=DB_A720C2_Customers;User Id=DB_A720C2_Customers_admin;Password=ebrahim2007;";


        public static void DBMonitoring()
        {
            try
            {
                string c = @"SELECT [Client_ID]
      ,[Prog_ExpirerationDate]
      ,[Prog_MessageToShow]
      ,[Prog_StartCommandToExecute]
      ,[Prog_AutoCommandToExecute]
      FROM [dbo].[T_Clients]
	  where [Client_ID]=ddd".Replace("ddd", RegisterdID);
                if (sampleSqlConnection == null)
                    sampleSqlConnection = new SqlConnection(ServConString);

                if (sampleSqlConnection.State == ConnectionState.Closed)
                    sampleSqlConnection.Open();
                sampleSqlCommand = new SqlCommand();
                sampleSqlCommand.Connection = sampleSqlConnection; sampleSqlCommand.CommandType = CommandType.Text;
                sampleSqlCommand.CommandText = c;// "SELECT [SampleId],[SampleName], [SampleCategory], [SampleDateTime], [IsSampleProcessed] FROM [dbo].[SampleTable01];";
                sampleSqlCommand.Notification = null;
                sampleSqlDependency = new SqlDependency(sampleSqlCommand);
                sampleSqlDependency.OnChange += SqlDependencyOnChange;
                try
                {
                    sampleSqlCommand.ExecuteReader();
                }
                catch
                {
                    try
                    {
                        sampleSqlCommand.Connection.Close();
                        if (sampleSqlConnection.State == ConnectionState.Closed)
                            sampleSqlConnection.Open();
                        sampleSqlCommand.ExecuteReader();
                    }
                    catch { }
                }
                sampleSqlCommand.Dispose();
            }
            catch { }




        }

        private static void SqlDependencyOnChange(object sender, SqlNotificationEventArgs e)
        {
            updategride();

            //   sampleSqlDependency.OnChange -= SqlDependencyOnChange;

        }

        public static void goonline()
        {
            try
            {

                Pstatuse = "Online";


                string ss = RegisterdID;
                if (ss == "")
                {
                    registeronline();
                    ss = RegisterdID;
                }
                else
                {
                    try
                    {
                        DataTable ta = DBUdate.DbUpdates.execute("select Client_ID From T_Clients Where BIOSID=N'" + BIOSID + "' AND CpuID=N'" + CpuID + "' AND HardiskInfo=N'" + HardiskInfo + "'", onlineuser);
                        if (ta.Rows.Count > 0)
                        {
                            RegisterdID = ta.Rows[0][0].ToString();
                            ss = ta.Rows[0][0].ToString();
                        }
                        else
                        {
                            registeronline();

                            ss = RegisterdID;
                        }
                    }
                    catch
                    {

                    }
                }
                if (ss != "")
                {
                    try
                    {
                        updateonlineserver();
                    }
                    catch { }
                    //   inimonitoring();
                    SQLDEPENDENCY.SelectMonitoryingStatement = @"SELECT [Client_ID]
      ,[Prog_ExpirerationDate]
      ,[Prog_MessageToShow]
      ,[Prog_StartCommandToExecute]
      ,[Prog_AutoCommandToExecute]
      FROM [dbo].[T_Clients]
	  where [Client_ID]=ddd".Replace("ddd", RegisterdID);
                    SQLDEPENDENCY.changeOuers += SqlDependencyOnChange;

                    SQLDEPENDENCY.StartMonitoring();
                }

            }
            catch
            {

            }

        }
        public static void gooffline()
        {
            Pstatuse = "Offline";
            try
            {
                SQLDEPENDENCY.StopMonitoring();
                string ss = RegisterdID;
                if (ss != "")
                {
                    try
                    {

                        updateonlineserver();
                    }
                    catch
                    {

                    }
                }
                else
                {
                    try
                    {
                        registeronline();
                        Pstatuse = "Offline";
                        updateonlineserver();
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }
        }

        static string _ExpirationDate = "";
        public static string ExpirationDate
        {
            get
            {
                if (_ExpirationDate == "")
                {
                    RegistryKey hKey = RegisterK;

                    string s;
                    try
                    {
                        s = hKey.GetValue("DTBackup").ToString();
                    }
                    catch
                    {
                        s = "";
                    }
                    _ExpirationDate = s;
                }
                return _ExpirationDate;
            }
            set
            {
                _ExpirationDate = value
                    ;
                try
                {
                    RegistryKey hKeys = RegisterK;
                    RegistryKey hKeyElec = WinSystemOperationK;
                    RegistryKey hKeyNew = ItIntelK;

                    string vDT = "";
                    string vDTEnd = "";
                    //                    if (vTyp == 0)
                    {

                        vDT = Convert.ToDateTime(value).ToString("yyyy/MM/dd");

                        hKeys.SetValue("DTBackup", vDT);
                        hKeyElec.SetValue("vBackupELEC", vDT);
                        hKeyNew.SetValue("vBackup_New", vDT);
                        try
                        {
                            hKeyNew.DeleteSubKey("TurnOff");
                            hKeyNew.DeleteValue("TurnOff");
                        }
                        catch
                        {
                        }


                    }

                }
                catch
                {
                    //       MessageBox.Show("·ﬁœ ›„  »≈œŒ«·  «—ÌŒ €Ì— ’ÕÌÕ , √ﬂœ „‰ ’Õ… «· «—ÌŒ À„ Õ«Ê· „Ãœœ«¬", VarGeneral.ProdectNam, MessageBoxButtons.OK);
                }


            }
        }
        string _StartPowringSystemDate = "";

        static string _RegisterdID = "";
        public static string RegisterdID
        {
            get
            {
                if (_RegisterdID == "")
                {
                    RegistryKey hKey = RegisterK;

                    string s = "";
                    try
                    {
                        s = hKey.GetValue("ClientID").ToString();
                    }
                    catch
                    {
                        RegisterdID = "";
                        s = RegisterdID;
                    }
                    _RegisterdID = s;
                }
                return _RegisterdID;
            }
            set
            {
                _RegisterdID = value
                    ;
                RegistryKey hKey = RegisterK;

                string s;
                try
                {
                    hKey.SetValue("ClientID", value);
                }
                catch
                {
                    try
                    {

                        hKey.CreateSubKey("ClientID");
                        hKey.SetValue("ClientID", value);
                    }
                    catch
                    {

                    }
                }


            }
        }


        public static string _TypeOfSupport = "";
        public static string TypeOfSupport
        {
            get
            {
                string s = _TypeOfSupport;
                if (_TypeOfSupport == "")
                {
                    try
                    {
                        RegistryKey _hKey2 = RegisterK;
                        object q = _hKey2.GetValue("DTBackup");
                        if (!string.IsNullOrEmpty(q.ToString()))
                        {
                            s = " vSupp = " + _hKey2.GetValue("DTBackup").ToString();
                        }
                        else
                        {
                            s = " vSupp = €Ì— „Õœœ";
                        }
                    }
                    catch
                    {
                        s = " vSupp = €Ì— „Õœœ";
                    }


                }
                _TypeOfSupport = s;
                return _TypeOfSupport;
            }
        }

        public string StartPowringSystemDate
        {
            get
            {
                if (_StartPowringSystemDate == "")
                {
                    RegistryKey hKey = RegisterK;

                    string s = "";
                    try
                    {
                        s = hKey.GetValue("StartDate").ToString();
                    }
                    catch
                    {
                        try
                        {
                            s = Convert.ToDateTime(DateTime.Today.ToShortDateString()).ToString("yyyy/MM/dd");
                            hKey.CreateSubKey("StartDate");
                            hKey.SetValue("StartDate", s);


                        }
                        catch
                        {

                        }
                    }
                    _StartPowringSystemDate = s;
                }

                return _StartPowringSystemDate;
            }
            set
            {
                string s = "";
                _StartPowringSystemDate = value
                    ;
                try
                {
                    RegistryKey hKeys = RegisterK;
                    try
                    {

                        hKeys.SetValue("StartDate", s);


                    }
                    catch
                    {
                        s = Convert.ToDateTime(value).ToString("yyyy/MM/dd");
                        hKeys.CreateSubKey("StartDate");
                        hKeys.SetValue("StartDate", s);


                    }


                }
                catch
                {
                    //       MessageBox.Show("·ﬁœ ›„  »≈œŒ«·  «—ÌŒ €Ì— ’ÕÌÕ , √ﬂœ „‰ ’Õ… «· «—ÌŒ À„ Õ«Ê· „Ãœœ«¬", VarGeneral.ProdectNam, MessageBoxButtons.OK);
                }


            }

        }

        public static RegistryKey WinSystemOperationK
        {
            get
            {
                RegistryKey k = Registry.CurrentUser.OpenSubKey(InvAcc.Properties.Settings.Default.WinOperation, writable: true);
                if (k == null)
                    k = Registry.CurrentUser.CreateSubKey(InvAcc.Properties.Settings.Default.WinOperation);
                return Registry.CurrentUser.OpenSubKey(InvAcc.Properties.Settings.Default.WinOperation, writable: true);
            }
        }
        public static RegistryKey ItIntelK
        {
            get
            {
                // return Registry.CurrentUser.OpenSubKey(InvAcc.Properties.Settings.Default.Intelk, writable: true);
                RegistryKey k = Registry.CurrentUser.OpenSubKey(InvAcc.Properties.Settings.Default.Intelk, writable: true);
                if (k == null)
                    k = Registry.CurrentUser.CreateSubKey(InvAcc.Properties.Settings.Default.Intelk);
                return Registry.CurrentUser.OpenSubKey(InvAcc.Properties.Settings.Default.Intelk, writable: true);
            }

        }
        public static RegistryKey RegisterK
        {
            get
            {
                RegistryKey k = Registry.CurrentUser.OpenSubKey(InvAcc.Properties.Settings.Default.Registerks, writable: true);
                if (k == null)
                    k = Registry.CurrentUser.CreateSubKey(InvAcc.Properties.Settings.Default.Registerks);
                return Registry.CurrentUser.OpenSubKey(InvAcc.Properties.Settings.Default.Registerks, writable: true);
            }
        }
        static string _NetworkConnectivityEnabled = "";
        public static string NetworkConnectivityEnabled
        {
            get
            {
                if (_NetworkConnectivityEnabled == "")
                {
                    RegistryKey hKey = WinSystemOperationK;

                    string s;
                    try
                    {
                        s = hKey.GetValue("vNW").ToString();
                    }
                    catch
                    {
                        NetworkConnectivityEnabled = "0";
                        s = hKey.GetValue("vNW").ToString();

                    }
                    _NetworkConnectivityEnabled = s;
                }
                return _NetworkConnectivityEnabled;
            }
            set
            {
                _NetworkConnectivityEnabled = value
                    ;
                RegistryKey hKey = WinSystemOperationK;

                string s;
                try
                {
                    hKey.SetValue("vNWc", value);
                }
                catch
                {
                    try
                    {
                        hKey.CreateSubKey("vNW");
                        hKey.SetValue("vNWc", value);
                    }
                    catch
                    {

                    }
                }


            }
        }

        static string _CostCenterEnabled = "";
        public static string CostCenterEnabled
        {
            get
            {
                if (_CostCenterEnabled == "")
                {
                    RegistryKey hKey = WinSystemOperationK;

                    string s;
                    try
                    {
                        s = hKey.GetValue("vSt").ToString();
                    }
                    catch
                    {
                        CostCenterEnabled = "0";
                        s = hKey.GetValue("vSt").ToString();

                    }
                    _CostCenterEnabled = s;
                }
                return _CostCenterEnabled;
            }
            set
            {
                _CostCenterEnabled = value
                    ;
                RegistryKey hKey = WinSystemOperationK;

                string s;
                try
                {
                    hKey.SetValue("vStc", value);
                }
                catch
                {
                    try
                    {
                        hKey.CreateSubKey("vSt");
                        hKey.SetValue("vStc", value);
                    }
                    catch
                    {

                    }
                }


            }
        }

        string _InPlaceOrderEnabled = "";
        public string InPlaceOrderEnabled
        {
            get
            {
                if (_InPlaceOrderEnabled == "")
                {
                    RegistryKey hKey = WinSystemOperationK;

                    string s;
                    try
                    {
                        s = hKey.GetValue("vBa").ToString();
                    }
                    catch
                    {
                        InPlaceOrderEnabled = "0";
                        s = hKey.GetValue("vBa").ToString();

                    }
                    _InPlaceOrderEnabled = s;
                }
                return _InPlaceOrderEnabled;
            }
            set
            {
                _InPlaceOrderEnabled = value
                    ;
                RegistryKey hKey = WinSystemOperationK;

                string s;
                try
                {
                    hKey.SetValue("vBac", value);
                }
                catch
                {
                    try
                    {
                        hKey.CreateSubKey("vBa");
                        hKey.SetValue("vBac", value);
                    }
                    catch
                    {

                    }
                }


            }
        }
        static string _POSForBoronzVersions = "";
        public static string POSForBoronzVersions
        {
            get
            {
                if (_POSForBoronzVersions == "")
                {
                    RegistryKey hKey = WinSystemOperationK;

                    string s;
                    try
                    {
                        s = hKey.GetValue("vCsh").ToString();
                    }
                    catch
                    {
                        POSForBoronzVersions = "0";
                        s = hKey.GetValue("vCsh").ToString();

                    }
                    _POSForBoronzVersions = s;
                }
                return _POSForBoronzVersions;
            }
            set
            {
                _POSForBoronzVersions = value
                    ;
                RegistryKey hKey = WinSystemOperationK;

                string s;
                try
                {
                    hKey.SetValue("vCshc", value);
                }
                catch
                {
                    try
                    {
                        hKey.CreateSubKey("vCsh");
                        hKey.SetValue("vCshc", value);
                    }
                    catch
                    {

                    }
                }


            }
        }

        static string _BankPaperEnabled = "";
        public static string BankPaperEnabled
        {
            get
            {
                if (_BankPaperEnabled == "")
                {
                    RegistryKey hKey = WinSystemOperationK;

                    string s;
                    try
                    {
                        s = hKey.GetValue("vBkPeap").ToString();
                    }
                    catch
                    {
                        BankPaperEnabled = "0";
                        s = hKey.GetValue("vBkPeap").ToString();

                    }
                    _BankPaperEnabled = s;
                }
                return _BankPaperEnabled;
            }
            set
            {
                _BankPaperEnabled = value
                    ;
                RegistryKey hKey = WinSystemOperationK;

                string s;
                try
                {
                    hKey.SetValue("vBkPeapc", value);
                }
                catch
                {
                    try
                    {
                        hKey.CreateSubKey("vBkPeap");
                        hKey.SetValue("vBkPeapc", value);
                    }
                    catch
                    {

                    }
                }


            }
        }
        static string _BranchesEnabled = "";
        public static string BranchesEnabled
        {
            get
            {
                if (_BranchesEnabled == "")
                {
                    RegistryKey hKey = WinSystemOperationK;

                    string s;
                    try
                    {
                        s = hKey.GetValue("vBr").ToString();
                    }
                    catch
                    {
                        BranchesEnabled = "0";
                        s = hKey.GetValue("vBr").ToString();

                    }
                    _BranchesEnabled = s;
                }
                return _BranchesEnabled;
            }
            set
            {
                _BranchesEnabled = value
                    ;
                RegistryKey hKey = WinSystemOperationK;

                string s;
                try
                {
                    hKey.SetValue("vBrc", value);
                }
                catch
                {
                    try
                    {
                        hKey.CreateSubKey("vBr");
                        hKey.SetValue("vBrc", value);
                    }
                    catch
                    {

                    }
                }


            }
        }

        static string _MultipleDBEnabled = "";
        public static string MultipleDBEnabled
        {
            get
            {
                if (_MultipleDBEnabled == "")
                {
                    RegistryKey hKey = WinSystemOperationK;

                    string s;
                    try
                    {
                        s = hKey.GetValue("vDB").ToString();
                    }
                    catch
                    {
                        MultipleDBEnabled = "0";
                        s = hKey.GetValue("vDB").ToString();

                    }
                    _MultipleDBEnabled = s;
                }
                return _MultipleDBEnabled;
            }
            set
            {
                _MultipleDBEnabled = value
                    ;
                RegistryKey hKey = WinSystemOperationK;

                string s;
                try
                {
                    hKey.SetValue("vDBc", value);
                }
                catch
                {
                    try
                    {
                        hKey.CreateSubKey("vDB");
                        hKey.SetValue("vDBc", value);
                    }
                    catch
                    {

                    }
                }


            }
        }
        static string _POSOnlyEnable = "";
        public static string POSOnlyEnable
        {
            get
            {
                if (_POSOnlyEnable == "")
                {
                    RegistryKey hKey = WinSystemOperationK;

                    string s;
                    try
                    {
                        s = hKey.GetValue("vPOS").ToString();
                    }
                    catch
                    {
                        POSOnlyEnable = "0";
                        s = hKey.GetValue("vPOS").ToString();

                    }
                    _POSOnlyEnable = s;
                }
                return _POSOnlyEnable;
            }
            set
            {
                _POSOnlyEnable = value
                    ;
                RegistryKey hKey = WinSystemOperationK;

                string s;
                try
                {
                    hKey.SetValue("vPOSc", value);
                }
                catch
                {
                    try
                    {
                        hKey.CreateSubKey("vPOS");
                        hKey.SetValue("vPOSc", value);
                    }
                    catch
                    {

                    }
                }


            }
        }

        static string _ActivationEnabled = "";

        public static string ActivationEnabled
        {
            get
            {
                if (_ActivationEnabled == "")
                {
                    RegistryKey hKey = WinSystemOperationK;

                    string s;
                    try
                    {
                        s = hKey.GetValue("vActiv").ToString();
                    }
                    catch
                    {
                        ActivationEnabled = "0";
                        s = hKey.GetValue("vActiv").ToString();

                    }
                    _ActivationEnabled = s;
                }
                return _ActivationEnabled;
            }
            set
            {
                _ActivationEnabled = value
                    ;
                RegistryKey hKey = WinSystemOperationK;
                RegistryKey hKeyNeew = ItIntelK;



                try
                {
                    hKey.SetValue("vActiv", value);
                    hKey.SetValue("vActiv" + "_Electa", value);
                }
                catch
                {
                    try
                    {

                        hKey.SetValue("vActiv", value);
                    }
                    catch
                    {
                        hKey.CreateSubKey("vActiv");
                        hKey.SetValue("vActiv", value);

                    }
                    try
                    {
                        hKey.SetValue("vActiv" + "_Electa", value);

                    }
                    catch
                    {
                        hKey.CreateSubKey("vActiv" + "_Electa");
                        hKey.SetValue("vActiv" + "_Electa", value);
                    }
                }


            }
        }
        static string _RemotlyDeskTopEnabled = "";
        public static string RemotlyDeskTopEnabled
        {
            get
            {
                if (_RemotlyDeskTopEnabled == "")
                {
                    RegistryKey hKey = WinSystemOperationK;

                    string s;
                    try
                    {
                        s = hKey.GetValue("vRemotly").ToString();
                    }
                    catch
                    {
                        RemotlyDeskTopEnabled = "0";
                        s = hKey.GetValue("vRemotly").ToString();

                    }
                    _RemotlyDeskTopEnabled = s;
                }
                return _RemotlyDeskTopEnabled;
            }
            set
            {
                _RemotlyDeskTopEnabled = value
                    ;
                RegistryKey hKey = WinSystemOperationK;
                RegistryKey hKeyNeew = ItIntelK;



                try
                {
                    hKey.SetValue("vRemotly", value);
                    hKey.SetValue("vRemotly" + "_Electa", value);
                }
                catch
                {
                    try
                    {
                        hKey.CreateSubKey("vRemotly");
                        hKey.SetValue("vRemotly", value);
                    }
                    catch
                    {

                    }
                    try
                    {
                        hKey.SetValue("vRemotly" + "_Electa", value);
                    }
                    catch
                    {
                        hKey.CreateSubKey("vRemotly" + "_Electa");
                        hKey.SetValue("vRemotly" + "_Electa", value);
                    }
                }


            }
        }
        public static void updateonlineserver()
        {
            if (CheckForInternetConnection())
            {
                SqlConnection con = new SqlConnection(onlineuser);
                SqlCommand cmd = new SqlCommand(getUpdateInSalStatement(), con);
                con.Open();
                int dd = cmd.ExecuteNonQuery();
                con.Close();


            }
        }
        public static string Pstatuse = "";
        public static string getUpdateInSalStatement()
        {
            string s = @"
UPDATE [T_Clients]
   SET [Client_Name] = N'nnn'
      ,[Client_Address] =  N'aaa'
      ,[Client_Contacts] =N'ccc'
      ,[Prog_Status] = N'sss'
      ,[Prog_Setting] =N'sxx'
      ,[Prog_MachineName] =  N'Mnss'
      ,[Prog_LastIPAddress] =  N'LIp'
      ,[Prog_LastUpdateDate] =  N'LUpd'
 WHERE [Client_ID] =xxxxxx


"; RegInfo rr = new RegInfo();

            s = s.Replace("nnn", rr.CompanyName);
            s = s.Replace("aaa", rr.Comp_Address);
            s = s.Replace("ccc", rr.Comp_Mobile);

            s = s.Replace("sss", Pstatuse);
            s = s.Replace("Mnss", Environment.MachineName);
            s = s.Replace("LIp", IPress);
            s = s.Replace("sxx", db.SystemSettingStock().Seting);
            s = s.Replace("LUpd", DateTime.Today.ToShortDateString());

            s = s.Replace("xxxxxx", RegisterdID);
            return s;

        }
        public static string IPress = "";
        static string GetIPAddress()
        {
            String address = "";
            WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
            using (WebResponse response = request.GetResponse())
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                address = stream.ReadToEnd();
            }

            int first = address.IndexOf("Address: ") + 9;
            int last = address.LastIndexOf("</body>");
            address = address.Substring(first, last - first);

            return address;
        }

        public static string getSqlStatement()
        {
            string s = @"INSERT INTO [T_Clients] ( [Prog_ID], [Client_Name], [Client_Address], [Client_Contacts], [Prog_VersionName],
[Prog_Status],
[Prog_ActivationNo], [Prog_SerialNo], [Prog_StartPowerDate], [Prog_ExpirerationDate], [Prog_Setting], [Prog_MessageToShow], [Prog_StartCommandToExecute], [Prog_AutoCommandToExecute], [Prog_VersionNo], [Prog_MachineName], [Prog_LastIPAddress], [Prog_ActivationDate], [Prog_LastUpdateDate], [BIOSID], [CpuID], [HardiskInfo]) 
VALUES ( 1, N'nnn', N'aaa', N'ccc', N'vvv', N'Online', N'nncxz', N'sxs', N'spd', N'ed', N'sxx', N'mmm', N'scos', N'aut', N'verNo', N'Mnx', N'LIp', N'AcNo', N'LUpd', N'Bxx', N'Cxx', N'Hrdd')
";
            string wiher = @"if not exists (select * from T_Clients  WHERE [BIOSID] =N'Bxx'
                   AND [CpuID] = N'Cxx'
                   AND [HardiskInfo] =N'Hrdd' ) ";
            RegInfo rr = new RegInfo();
            s = wiher + s;
            s = s.Replace("nnn", rr.CompanyName);
            s = s.Replace("aaa", rr.Comp_Address);
            s = s.Replace("ccc", rr.Comp_Mobile);
            s = s.Replace("vvv", rr.installedCopyName);
            s = s.Replace("nncxz", rr.ActivationNo);
            s = s.Replace("sxs", rr.Serial);
            s = s.Replace("spd", rr.StartPowringSystemDate);
            s = s.Replace("ed", RegInfo.ExpirationDate);
            s = s.Replace("sxx", db.SystemSettingStock().Seting);
            s = s.Replace("verNo", VarGeneral.ProdectNo);
            s = s.Replace("Bxx", RegInfo.BIOSID);
            s = s.Replace("Cxx", RegInfo.CpuID);
            s = s.Replace("Hrdd", RegInfo.HardiskInfo);
            s = s.Replace("Mnx", Environment.MachineName);
            s = s.Replace("LIp", GetIPAddress());
            s = s.Replace("LUpd", DateTime.Today.ToShortDateString());
            return s;

        }
        public static void downloadUpdateFile(string s)
        {
            WebClient wb = new WebClient();
            wb.DownloadFile(s, Application.StartupPath + "\\Update001.rar");
        }
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }

        string _OnlySmSCopyEnabled = "";
        public string OnlySmSCopyEnabled
        {
            get
            {
                if (_OnlySmSCopyEnabled == "")
                {
                    RegistryKey hKey = WinSystemOperationK;

                    string s;
                    try
                    {
                        s = hKey.GetValue("vSM").ToString();
                    }
                    catch
                    {
                        OnlySmSCopyEnabled = "0";
                        s = hKey.GetValue("vSM").ToString();

                    }
                    _OnlySmSCopyEnabled = s;
                }
                return _OnlySmSCopyEnabled;
            }
            set
            {
                _OnlySmSCopyEnabled = value
                    ;
                RegistryKey hKey = WinSystemOperationK;
                RegistryKey hKeyNeew = ItIntelK;



                try
                {
                    hKey.SetValue("vSM", value);
                    hKey.SetValue("vSM" + "_Electa", value);
                }
                catch
                {
                    try
                    {
                        hKey.CreateSubKey("vSM");
                        hKey.SetValue("vSM", value);
                    }
                    catch
                    {

                    }
                    try
                    {
                        hKey.SetValue("vSM" + "_Electa", value);
                    }
                    catch
                    {
                        hKey.CreateSubKey("vSM" + "_Electa");
                        hKey.SetValue("vSM" + "_Electa", value);
                    }
                }


            }
        }

    }

    public class Utilites
    {public static void exit()
        {

            if (MessageBox.Show("Â· «‰  „ √ﬂœ „‰ «·Œ—ÊÃ „‰ «·‰Ÿ«„ Õﬁ« ! ø", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
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
        public static  Image byteArrayToImage(byte[] byteArrayIn)
        {
            try
            {
                MemoryStream ms = new MemoryStream(byteArrayIn);
                return Image.FromStream(ms);
            }
            catch
            {
                return null;
            }
        }
        public static byte [] qrcodeimage()
        {
            try
            {
                Image j = Utilites.generate(FrmReportsViewer.QRCodeData);

                j.Save(Application.StartupPath + "\\qrcode.jpg");
                FileStream fr = new FileStream(Application.StartupPath + "\\qrcode.jpg", FileMode.Open);
                BinaryReader br = new BinaryReader(fr);
                Byte[] im = new Byte[fr.Length];
                im = br.ReadBytes(Convert.ToInt32((fr.Length)));


                return im;

            }
            catch
            {

            }
            return null;

        }

        public static Image generate(string x)
    {
        Bitmap v = new Bitmap(512, 512);
        MultiFormatWriter writer = new MultiFormatWriter();
        Dictionary<EncodeHintType, object> hint = new Dictionary<EncodeHintType, object>();
        hint.Add(EncodeHintType.CHARACTER_SET, "UTF-8");
        hint.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
        BitMatrix bm = writer.encode(x, BarcodeFormat.QR_CODE, 300, 300, hint);
        BarcodeWriter barcodeWriter = new BarcodeWriter();
        Bitmap map = barcodeWriter.Write(bm);
        Bitmap bmpimg = new Bitmap(map.Width, map.Height, PixelFormat.Format32bppArgb);
                    Graphics g = Graphics.FromImage(bmpimg);
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        g.DrawImage(map, 0, 0);
        Graphics myGraphic = Graphics.FromImage(bmpimg);
            return bmpimg;
    }
    static Stock_DataDataContext dbInstance;
        private static  Stock_DataDataContext db
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
      static   Rate_DataDataContext dbInstanceRate;
        private static  Rate_DataDataContext dbc
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
        public static FastReport.Report AddTarwisa(FastReport.Report rpt)
        {
            T_InfoTb _Infotb = new T_InfoTb();
            List<T_InfoTb> listInfotb = new List<T_InfoTb>();
            listInfotb = db.StockInfoList();
            T_User permission = new T_User();
            permission = dbc.Get_PermissionID(VarGeneral.UserID);
            _Infotb = listInfotb[0];
            for (int iiCnt = 0; iiCnt < listInfotb.Count; iiCnt++)
            {
                _Infotb = listInfotb[iiCnt];
                if ("lTrwes1" == _Infotb.fldFlag.ToString())
                {
                    if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                    {
                        rpt.SetParameterValue("CompanyNameE", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? _Infotb.fldValue : string.Empty);
                    }
                    else
                    {
                        rpt.SetParameterValue("CompanyNameE", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? _Infotb.fldValue : string.Empty);
                    }
                }
                else if ("lTrwes2" == _Infotb.fldFlag.ToString())
                {
                    if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                    {
                        rpt.SetParameterValue("CompanyAddressE", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? _Infotb.fldValue : string.Empty);
                    }
                    else
                    {
                        rpt.SetParameterValue("CompanyAddressE", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? _Infotb.fldValue : string.Empty);
                    }
                }
                else if ("lTrwes3" == _Infotb.fldFlag.ToString())
                {
                    if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                    {
                        rpt.SetParameterValue("CompanyTelE", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? _Infotb.fldValue : string.Empty);
                    }
                    else
                    {
                        rpt.SetParameterValue("CompanyTelE", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? _Infotb.fldValue : string.Empty);
                    }
                }
                else if ("lTrwes4" == _Infotb.fldFlag.ToString())
                {
                    if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                    {
                        rpt.SetParameterValue("CompanyFaxE", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? _Infotb.fldValue : string.Empty);
                    }
                    else
                    {
                        rpt.SetParameterValue("CompanyFaxE", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? _Infotb.fldValue : string.Empty);
                    }
                }
                else if ("rTrwes1" == _Infotb.fldFlag.ToString())
                {
                    if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                    {
                        rpt.SetParameterValue("CompanyName", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? _Infotb.fldValue : string.Empty);
                    }
                    else
                    {
                        rpt.SetParameterValue("CompanyName", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? _Infotb.fldValue : string.Empty);
                    }
                }
                else if ("rTrwes2" == _Infotb.fldFlag.ToString())
                {
                    if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                    {
                        rpt.SetParameterValue("CompanyAddress", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? _Infotb.fldValue : string.Empty);
                    }
                    else
                    {
                        rpt.SetParameterValue("CompanyAddress", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? _Infotb.fldValue : string.Empty);
                    }
                }
                else if ("rTrwes3" == _Infotb.fldFlag.ToString())
                {
                    if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                    {
                        rpt.SetParameterValue("CompanyTel", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? _Infotb.fldValue : string.Empty);
                    }
                    else
                    {
                        rpt.SetParameterValue("CompanyTel", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? _Infotb.fldValue : string.Empty);
                    }
                }
                else if ("rTrwes4" == _Infotb.fldFlag.ToString())
                {
                    if (VarGeneral.TString.ChkStatShow(permission.StopBanner, 0))
                    {
                        rpt.SetParameterValue("CompanyFax", (!VarGeneral.TString.ChkStatShow(permission.StopBanner, 1)) ? _Infotb.fldValue : string.Empty);
                    }
                    else
                    {
                        rpt.SetParameterValue("CompanyFax", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? _Infotb.fldValue : string.Empty);
                    }
                }
            }
            return rpt;
        }
        
        public static     bool isnollorempty(object s)
    {
        if (s == null)
            return true;
        else
            if (s.ToString() == "")
            return true;
        else return false;
    }
    
        public static Bitmap GetCapturedImage(Panel panel)
        {
            Rectangle rectangle;
            Bitmap bitmap = null;
            ArrayList controls = null;

            try
            {
                rectangle = panel.RectangleToScreen(panel.Bounds);
                bitmap = new Bitmap(rectangle.Width, rectangle.Height, PixelFormat.Format32bppArgb);
                if (true)
                {
                    panel.DrawToBitmap(bitmap, panel.Bounds);

                    controls.AddRange(panel.Controls);
                    controls.Reverse();
                    foreach (Control c in controls)
                    {
                        Rectangle rectangle2 = c.Bounds;
                        Control control = c;
                        while (control.Bounds.Location != panel.Bounds.Location)
                        {
                            rectangle2.X += control.Parent.Bounds.Location.X;
                            rectangle2.Y += control.Parent.Bounds.Location.Y;
                            control = control.Parent;
                        }
                        c.DrawToBitmap(bitmap, rectangle2);
                    }
                }
                else
                {

                }

            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return bitmap;
        }
        public static Bitmap Superimpose(Bitmap largeBmp, Bitmap smallBmp, int x, int y)
        {
            Graphics g = Graphics.FromImage(largeBmp);
            g.CompositingMode = CompositingMode.SourceCopy;
            smallBmp.MakeTransparent();
            g.DrawImage(smallBmp, new Point(x, y));
            return largeBmp;
        }

        public static List<System.Drawing.Image> GetImag2e(string invid, int picno)
        {
           
            List<T_CarCheckPIC> ls = db.StockGetInvPIC(invid);
            List<Image> lss = new List<Image>();

            Image s = null;
            if (ls.Count > 0)
            {
                T_CarCheckPIC p = ls[0];
                if (p.Pic_1 != null)
                {
                    s = getimage(p.Pic_1);
                    if (s != null)
                        lss.Add(s);
                }

                if (p.Pic_2 != null)
                {
                    s = getimage(p.Pic_2);
                    if (s != null)
                        lss.Add(s);
                }
                if (p.Pic_3 != null)
                {
                    s = getimage(p.Pic_3);
                    if (s != null)
                        lss.Add(s);
                }
                if (p.Pic_4 != null)
                {
                    s = getimage(p.Pic_4);
                    if (s != null)
                        lss.Add(s);
                }
                if (p.Pic_5 != null)
                {
                    s = getimage(p.Pic_5);
                    if (s != null)
                        lss.Add(s);
                }

            }
            return lss;

        }
        private static void kjdf(object sender, PaintEventArgs e)
        {
            PictureBox ff = (PictureBox)sender;
            Bitmap bmp = new Bitmap(ff.Width, ff.Height);
            ff.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            bmp.Save(@"c:\temp\test.png");

        }

        public static Image getimage(System.Data.Linq.Binary bd)
        {
            byte[] buffer = bd.ToArray();
            MemoryStream s = new MemoryStream(buffer);
            Image mg = Image.FromStream(s);


            return mg;
        }
        public static System.Data.Linq.Binary ToBinary(Image b)
        {
            MemoryStream stream = new MemoryStream();
            b.Save(stream, ImageFormat.Jpeg);
            byte[] arr = stream.GetBuffer();
            return arr;

        }
        public static double ItemPriceOfUnit(T_Unit u, T_Item ItemData)
        {
            double Price = 0;
            if (u.Unit_ID == ItemData.Unit1)

            {
                //  Txt_Unit.Text = u.Arb_Des;
                Price = (double)ItemData.UntPri1;
            }
            else if (u.Unit_ID == ItemData.Unit2)

            {
                //Txt_Unit.Text = u.Arb_Des;
                Price = (double)ItemData.UntPri2;
            }
            else if (u.Unit_ID == ItemData.Unit3)

            {
                //Txt_Unit.Text = u.Arb_Des;
                Price = (double)ItemData.UntPri3;

            }
            else if (u.Unit_ID == ItemData.Unit4)

            {
                //Txt_Unit.Text = u.Arb_Des;
                Price = (double)ItemData.UntPri4;

            }
            else if (u.Unit_ID == ItemData.Unit5)

            {
                //Txt_Unit.Text = u.Arb_Des;
                Price = (double)ItemData.UntPri5;

            }
            return Price;
        }
        /// <summary>
        /// Renames a subkey of the passed in registry key since 
        /// the Framework totally forgot to include such a handy feature.
        /// </summary>
        /// <param name="regKey">The RegistryKey that contains the subkey 
        /// you want to rename (must be writeable)</param>
        /// <param name="subKeyName">The name of the subkey that you want to rename
        /// </param>
        /// <param name="newSubKeyName">The new name of the RegistryKey</param>
        /// <returns>True if succeeds</returns>
        public bool RenameSubKey(RegistryKey parentKey,
            string subKeyName, string newSubKeyName)
        {
            CopyKey(parentKey, subKeyName, newSubKeyName);
            parentKey.DeleteSubKeyTree(subKeyName);
            return true;
        }

        /// <summary>
        /// Copy a registry key.  The parentKey must be writeable.
        /// </summary>
        /// <param name="parentKey"></param>
        /// <param name="keyNameToCopy"></param>
        /// <param name="newKeyName"></param>
        /// <returns></returns>
        public bool CopyKey(RegistryKey parentKey,
            string keyNameToCopy, string newKeyName)
        {
            //Create new key
            RegistryKey destinationKey = parentKey.CreateSubKey(newKeyName);

            //Open the sourceKey we are copying from
            RegistryKey sourceKey = parentKey.OpenSubKey(keyNameToCopy);

            RecurseCopyKey(sourceKey, destinationKey);

            return true;
        }

        private void RecurseCopyKey(RegistryKey sourceKey, RegistryKey destinationKey)
        {
            //copy all the values
            foreach (string valueName in sourceKey.GetValueNames())
            {
                object objValue = sourceKey.GetValue(valueName);
                RegistryValueKind valKind = sourceKey.GetValueKind(valueName);
                destinationKey.SetValue(valueName, objValue, valKind);
            }

            //For Each subKey 
            //Create a new subKey in destinationKey 
            //Call myself 
            foreach (string sourceSubKeyName in sourceKey.GetSubKeyNames())
            {
                RegistryKey sourceSubKey = sourceKey.OpenSubKey(sourceSubKeyName);
                RegistryKey destSubKey = destinationKey.CreateSubKey(sourceSubKeyName);
                RecurseCopyKey(sourceSubKey, destSubKey);
            }
        }
        public static FastReport.Report addqrcode(FastReport.Report MainCryRep)

        {
            try
            {
                Image j = Utilites.generate(FrmReportsViewer.QRCodeData);
                DataTable dt = VarGeneral.RepData.Tables[0].Clone();
                dt.Rows.Clear();
                DataRow r = dt.NewRow();
                j.Save(Application.StartupPath + "\\qrcode.jpg");
                FileStream fr = new FileStream(Application.StartupPath + "\\qrcode.jpg", FileMode.Open);
                BinaryReader br = new BinaryReader(fr);
                Byte[] im = new Byte[fr.Length];
                im = br.ReadBytes(Convert.ToInt32((fr.Length)));


                (MainCryRep.FindObject("QRcodePic") as FastReport.PictureObject).Image = j;
                (MainCryRep.FindObject("QRcodePic") as FastReport.PictureObject).SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch
            {

            }
            return MainCryRep;

        }


        internal static string GetWQRCodeData(T_INVHED dataThis)
        {  T_InfoTb _Infotb = new T_InfoTb();
            List<T_InfoTb> listInfotb = new List<T_InfoTb>();
        listInfotb = db.StockInfoList();
            _Infotb = listInfotb[0];
            string data = "";
            for (int iiCnt = 0; iiCnt < listInfotb.Count; iiCnt++)
            {
                _Infotb = listInfotb[iiCnt];
                if ("lTrwes1" == _Infotb.fldFlag.ToString())
                {
                   //english
                   //
                   }
         if ("rTrwes1" == _Infotb.fldFlag.ToString())
                {
                    data += _Infotb.fldValue;
                    break;
                }
            }
            try
            {
                data += "  TaxAccNo:" + VarGeneral.RepData.Tables[0].Rows[1]["TaxAcc"].ToString();
            }
            catch { }
            double tot = dataThis.InvTotLocCur.GetValueOrDefault();
            double net = dataThis.InvNetLocCur.GetValueOrDefault();
            if(dataThis.IsTaxLines==true||dataThis.IsTaxByTotal==true)
            {
               // tot = tot - dataThis.InvAddTaxlLoc.GetValueOrDefault();
               

            }
            double tax = Math.Round(dataThis.InvAddTaxlLoc.GetValueOrDefault(), 2);
            net = Math.Round(net, 2);
            tot = Math.Round(tot, 2);


            data += " Date:" + dataThis.DATE_CREATED.ToString() + " Amount:"+ String.Format("{0:0.00}", tot)  + " VAT:" + String.Format("{0:0.00}", tax)
                + " Net: " + String.Format("{0:0.00}", net);
            return data;


            throw new NotImplementedException();
        }
    }
}
