using InvAcc.DBUdate;
using InvAcc.Forms;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Microsoft.Win32;
using SSSDateTime.Date;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
#pragma warning disable CS0219 // The variable 'i' is assigned but its value is never used
                int i = 0;
#pragma warning restore CS0219 // The variable 'i' is assigned but its value is never used
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
                    _CopyesNames.Add(new KeyValuePair<string, string>("02G", "??????? ?????? ?????? ??????? ?????????"));
                    _CopyesNames.Add(new KeyValuePair<string, string>("02S", "??????? ????? ?????? ??????? ?????????"));
                    _CopyesNames.Add(new KeyValuePair<string, string>("02B", "??????? ????????? ?????? ??????? ?????????"));
                    _CopyesNames.Add(new KeyValuePair<string, string>("00W", "??????? ?????? ?????? ??????? ???????? ?????????  "));
                    _CopyesNames.Add(new KeyValuePair<string, string>("00K", "??????? ????????? ?????? ??????? ???????? ?????????"));
                    _CopyesNames.Add(new KeyValuePair<string, string>("00M", "????? ?????????? ?????? ????? ???? ????????  "));
                    _CopyesNames.Add(new KeyValuePair<string, string>("01I", "????? ???????? ?????? ?????? ?????? ??????? "));
                    _CopyesNames.Add(new KeyValuePair<string, string>("01Z", "????? ???????? ????????? ?????? ?????? ??????? "));
                    _CopyesNames.Add(new KeyValuePair<string, string>("02R", "????? ?????? ?????? ?????? ??????? ??????????"));
                    _CopyesNames.Add(new KeyValuePair<string, string>("02C", "????? ?????? ????????? ?????? ??????? ??????????"));
                    _CopyesNames.Add(new KeyValuePair<string, string>("02H", "????? ??????? ?????? ?????? ??????? "));
                    _CopyesNames.Add(new KeyValuePair<string, string>("01X", "????? ??????? ????????? ?????? ???????"));
                    _CopyesNames.Add(new KeyValuePair<string, string>("01Q", "????? ??????? ?????? ?????? ???????? ????????? "));


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

#pragma warning disable CS0219 // The variable 's' is assigned but its value is never used
                string s;
#pragma warning restore CS0219 // The variable 's' is assigned but its value is never used
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
#pragma warning disable CS0168 // The variable 's' is declared but never used
                string s;
#pragma warning restore CS0168 // The variable 's' is declared but never used
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
#pragma warning disable CS0219 // The variable 'vDTEnd' is assigned but its value is never used
                    string vDTEnd = "";
#pragma warning restore CS0219 // The variable 'vDTEnd' is assigned but its value is never used
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
                    //       MessageBox.Show("??? ??? ?????? ????? ??? ???? ,???? ?? ??? ??????? ?? ???? ??????", VarGeneral.ProdectNam, MessageBoxButtons.OK);
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

#pragma warning disable CS0168 // The variable 's' is declared but never used
                string s;
#pragma warning restore CS0168 // The variable 's' is declared but never used
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
                            s = " vSupp = ??? ????";
                        }
                    }
                    catch
                    {
                        s = " vSupp = ??? ????";
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
                    //       MessageBox.Show("??? ??? ?????? ????? ??? ???? ,???? ?? ??? ??????? ?? ???? ??????", VarGeneral.ProdectNam, MessageBoxButtons.OK);
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

#pragma warning disable CS0168 // The variable 's' is declared but never used
                string s;
#pragma warning restore CS0168 // The variable 's' is declared but never used
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

#pragma warning disable CS0168 // The variable 's' is declared but never used
                string s;
#pragma warning restore CS0168 // The variable 's' is declared but never used
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

#pragma warning disable CS0168 // The variable 's' is declared but never used
                string s;
#pragma warning restore CS0168 // The variable 's' is declared but never used
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

#pragma warning disable CS0168 // The variable 's' is declared but never used
                string s;
#pragma warning restore CS0168 // The variable 's' is declared but never used
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

#pragma warning disable CS0168 // The variable 's' is declared but never used
                string s;
#pragma warning restore CS0168 // The variable 's' is declared but never used
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

#pragma warning disable CS0168 // The variable 's' is declared but never used
                string s;
#pragma warning restore CS0168 // The variable 's' is declared but never used
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

#pragma warning disable CS0168 // The variable 's' is declared but never used
                string s;
#pragma warning restore CS0168 // The variable 's' is declared but never used
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

#pragma warning disable CS0168 // The variable 's' is declared but never used
                string s;
#pragma warning restore CS0168 // The variable 's' is declared but never used
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
    {
        public static void setinitaliaiztion()
        {
            if (Environment.MachineName != "EC2AMAZ-SI4ASSC")
                VarGeneral.RepServerConn = ".";
            else VarGeneral.RepServerConn = "EC2AMAZ-SI4ASSC";

            Stock_DataDataContext db = new Stock_DataDataContext(VarGeneral.BranchCS);
            try
            {
                T_SYSSETTING ts = db.SystemSettingStock();
                VarGeneral.Settings_Sys = ts;
                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
                {
                    int ihjj = (ts.AfterDotNum == null ? 3 : (int)ts.AfterDotNum);
                    VarGeneral.setDecimalPointSettings(ihjj);
                }
                else
                    VarGeneral.setDecimalPointSettings(2);
            }
            catch
            {
                SqlConnection cons = new SqlConnection(VarGeneral.BranchCS);
                SqlCommand cmd = new SqlCommand(DbUpdates.Uptate3, cons);
                cons.Open();
                cmd.ExecuteNonQuery();
                cons.Close();
                T_SYSSETTING ts = db.SystemSettingStock();
                VarGeneral.Settings_Sys = ts;
                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
                {
                    int ihjj = (ts.AfterDotNum == null ? 3 : (int)ts.AfterDotNum);
                    VarGeneral.setDecimalPointSettings(ihjj);
                }
                else

                    VarGeneral.setDecimalPointSettings(2);
            }
            try
            {
                RegistryKey _hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\MrdSoft\\Register", writable: true);
                if (_hKey != null)
                {
                    VarGeneral._ActivaionNo = _hKey.GetValue("SSSActivationNo").ToString();
                    VarGeneral._SerialNo = _hKey.GetValue("vSr").ToString();
                }
            }
            catch
            {
                VarGeneral._ActivaionNo = "";
                VarGeneral._SerialNo = "";
            }
            VarGeneral.Settings_Sys = db.SystemSettingStock();
            VarGeneral._SysDirPath = VarGeneral.Settings_Sys.SysDir;
            VarGeneral._BackPath = VarGeneral.Settings_Sys.BackPath;
        }
        private static  HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        public static int LangArEn = 0;
        public static  void CheckReg_New()
        {
            try
            {
                RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software", writable: true);
                hKey.CreateSubKey("MrdHrdw");
                hKey = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw", writable: true);
                hKey.CreateSubKey("ItIntel");
                hKey = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", writable: true);
                RegistryKey hKeyOrginal = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
                try
                {
                    object q = hKeyOrginal.GetValue("vBr");
                    if (!string.IsNullOrEmpty(q.ToString()))
                    {
                        long regval2 = long.Parse(hKeyOrginal.GetValue("vBr").ToString());
                        try
                        {
                            object c = hKey.GetValue("vBr_New");
                            if (string.IsNullOrEmpty(c.ToString()))
                            {
                                hKey.CreateSubKey("vBr_New");
                                hKey.SetValue("vBr_New", regval2.ToString());
                            }
                        }
                        catch
                        {
                            hKey.CreateSubKey("vBr_New");
                            hKey.SetValue("vBr_New", regval2.ToString());
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    object q = hKeyOrginal.GetValue("vCsh");
                    if (!string.IsNullOrEmpty(q.ToString()))
                    {
                        long regval2 = long.Parse(hKeyOrginal.GetValue("vCsh").ToString());
                        try
                        {
                            object c = hKey.GetValue("vCsh_New");
                            if (string.IsNullOrEmpty(c.ToString()))
                            {
                                hKey.CreateSubKey("vCsh_New");
                                hKey.SetValue("vCsh_New", regval2.ToString());
                            }
                        }
                        catch
                        {
                            hKey.CreateSubKey("vCsh_New");
                            hKey.SetValue("vCsh_New", regval2.ToString());
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    object q = hKeyOrginal.GetValue("vNW");
                    if (!string.IsNullOrEmpty(q.ToString()))
                    {
                        long regval2 = long.Parse(hKeyOrginal.GetValue("vNW").ToString());
                        try
                        {
                            object c = hKey.GetValue("vNW_New");
                            if (string.IsNullOrEmpty(c.ToString()))
                            {
                                hKey.CreateSubKey("vNW_New");
                                hKey.SetValue("vNW_New", regval2.ToString());
                            }
                        }
                        catch
                        {
                            hKey.CreateSubKey("vNW_New");
                            hKey.SetValue("vNW_New", regval2.ToString());
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    object q = hKeyOrginal.GetValue("vBackupELEC");
                    if (string.IsNullOrEmpty(q.ToString()))
                    {
                        return;
                    }
                    string regval = hKeyOrginal.GetValue("vBackupELEC").ToString();
                    try
                    {
                        object c = hKey.GetValue("vBackup_New");
                        if (string.IsNullOrEmpty(c.ToString()))
                        {
                            hKey.CreateSubKey("vBackup_New");
                            hKey.SetValue("vBackup_New", regval.ToString());
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vBackup_New");
                        hKey.SetValue("vBackup_New", regval.ToString());
                    }
                }
                catch
                {
                }
            }
            catch
            {
            }
        }

        public static  void CheckReg_Elect()
        {
            try
            {
                RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
                if (hKey == null)
                {
                    return;
                }
                try
                {
                    object q = hKey.GetValue("vSt");
                    if (!string.IsNullOrEmpty(q.ToString()))
                    {
                        long regval = long.Parse(hKey.GetValue("vSt").ToString());
                        try
                        {
                            object c = hKey.GetValue("vSt_Electa");
                            if (string.IsNullOrEmpty(c.ToString()))
                            {
                                hKey.CreateSubKey("vSt_Electa");
                                hKey.SetValue("vSt_Electa", regval.ToString());
                            }
                        }
                        catch
                        {
                            hKey.CreateSubKey("vSt_Electa");
                            hKey.SetValue("vSt_Electa", regval.ToString());
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    object q = hKey.GetValue("vCoCe");
                    if (!string.IsNullOrEmpty(q.ToString()))
                    {
                        long regval = long.Parse(hKey.GetValue("vCoCe").ToString());
                        try
                        {
                            object c = hKey.GetValue("vCoCe_Electa");
                            if (string.IsNullOrEmpty(c.ToString()))
                            {
                                hKey.CreateSubKey("vCoCe_Electa");
                                hKey.SetValue("vCoCe_Electa", regval.ToString());
                            }
                        }
                        catch
                        {
                            hKey.CreateSubKey("vCoCe_Electa");
                            hKey.SetValue("vCoCe_Electa", regval.ToString());
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    object q = hKey.GetValue("vBr");
                    if (!string.IsNullOrEmpty(q.ToString()))
                    {
                        long regval = long.Parse(hKey.GetValue("vBr").ToString());
                        try
                        {
                            object c = hKey.GetValue("vBr_Electa");
                            if (string.IsNullOrEmpty(c.ToString()))
                            {
                                hKey.CreateSubKey("vBr_Electa");
                                hKey.SetValue("vBr_Electa", regval.ToString());
                            }
                        }
                        catch
                        {
                            hKey.CreateSubKey("vBr_Electa");
                            hKey.SetValue("vBr_Electa", regval.ToString());
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    object q = hKey.GetValue("vDB");
                    if (!string.IsNullOrEmpty(q.ToString()))
                    {
                        long regval = long.Parse(hKey.GetValue("vDB").ToString());
                        try
                        {
                            object c = hKey.GetValue("vDB_Electa");
                            if (string.IsNullOrEmpty(c.ToString()))
                            {
                                hKey.CreateSubKey("vDB_Electa");
                                hKey.SetValue("vDB_Electa", regval.ToString());
                            }
                        }
                        catch
                        {
                            hKey.CreateSubKey("vDB_Electa");
                            hKey.SetValue("vDB_Electa", regval.ToString());
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    object q = hKey.GetValue("vCsh");
                    if (!string.IsNullOrEmpty(q.ToString()))
                    {
                        long regval = long.Parse(hKey.GetValue("vCsh").ToString());
                        try
                        {
                            object c = hKey.GetValue("vCsh_Electa");
                            if (string.IsNullOrEmpty(c.ToString()))
                            {
                                hKey.CreateSubKey("vCsh_Electa");
                                hKey.SetValue("vCsh_Electa", regval.ToString());
                            }
                        }
                        catch
                        {
                            hKey.CreateSubKey("vCsh_Electa");
                            hKey.SetValue("vCsh_Electa", regval.ToString());
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    object q = hKey.GetValue("vNW");
                    if (!string.IsNullOrEmpty(q.ToString()))
                    {
                        long regval = long.Parse(hKey.GetValue("vNW").ToString());
                        try
                        {
                            object c = hKey.GetValue("vNW_Electa");
                            if (string.IsNullOrEmpty(c.ToString()))
                            {
                                hKey.CreateSubKey("vNW_Electa");
                                hKey.SetValue("vNW_Electa", regval.ToString());
                            }
                        }
                        catch
                        {
                            hKey.CreateSubKey("vNW_Electa");
                            hKey.SetValue("vNW_Electa", regval.ToString());
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    RegistryKey hKey_ElecDB = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\MrdSoft\\Register", writable: true);
                    if (hKey_ElecDB == null)
                    {
                        return;
                    }
                    object q = hKey_ElecDB.GetValue("DTBackup");
                    if (string.IsNullOrEmpty(q.ToString()))
                    {
                        return;
                    }
                    try
                    {
                        object c = hKey.GetValue("vBackupELEC");
                        if (string.IsNullOrEmpty(c.ToString()))
                        {
                            hKey.CreateSubKey("vBackupELEC");
                            hKey.SetValue("vBackupELEC", q.ToString());
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vBackupELEC");
                        hKey.SetValue("vBackupELEC", q.ToString());
                    }
                }
                catch
                {
                }
            }
            catch
            {
            }
        }

        public static void  systemLoading()
        {
            new FrmMain(null, null, VarGeneral.BranchNumber, 0);
            setinitaliaiztion();
            VarGeneral.vDemo = true;
            try
            {
                try
                {
                    RegistryKey u = Registry.CurrentUser.OpenSubKey("Software\\FilesSys", writable: true);
                    if (u != null)
                    {
                        MessageBox.Show((LangArEn == 0) ? "??? ?????? ??? ??????? ???? ??????? ?? ??????? \n  ??? ?? ????? ????? ?????? ??? ??? ?????? ??????..  " : "If the problem persists with you, please communicate with the administration \n is not sure of the status activated version ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                        Environment.Exit(0);
                    }
                }
                catch
                {
                }
                RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\MrdSoft\\Register", writable: true);
                if (hKey == null)
                {
                    hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings", writable: true);
                    if (hKey != null)
                    {
                        hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\MrdSoft", writable: true);
                        if (hKey == null)
                        {
                            hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings", writable: true);
                            hKey.CreateSubKey("MrdSoft");
                            hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\MrdSoft", writable: true);
                            hKey.CreateSubKey("Register");
                            hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\MrdSoft\\Register", writable: true);
                            hKey.SetValue("DT", n.GDateNow("yyyy/MM/dd"));
                            hKey.SetValue("DTBackup", "");
                            hKey.SetValue("SSSActivationNo", "1");
                            hKey.SetValue("vSr", "");
                            hKey.Close();
                        }
                        else
                        {
                            hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\MrdSoft\\Register", writable: true);
                            if (hKey == null)
                            {
                                hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\MrdSoft", writable: true);
                                hKey.CreateSubKey("Register");
                                hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\MrdSoft\\Register", writable: true);
                                hKey.SetValue("DT", n.GDateNow("yyyy/MM/dd"));
                                hKey.SetValue("DTBackup", "");
                                hKey.SetValue("SSSActivationNo", "1");
                                hKey.SetValue("vSr", "");
                                hKey.Close();
                            }
                        }
                    }
                    else
                    {
                        hKey = Registry.CurrentUser.OpenSubKey("Software", writable: true);
                        if (hKey != null)
                        {
                            hKey.CreateSubKey("PRS AND PR Settings");
                            hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings", writable: true);
                            hKey.CreateSubKey("MrdSoft");
                            hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\MrdSoft", writable: true);
                            hKey.CreateSubKey("Register");
                            hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\MrdSoft\\Register", writable: true);
                            hKey.SetValue("DT", n.GDateNow("yyyy/MM/dd"));
                            hKey.SetValue("DTBackup", "");
                            hKey.SetValue("SSSActivationNo", "1");
                            hKey.SetValue("vSr", "");
                            hKey.Close();
                        }
                    }
                    FrmReg form2 = new FrmReg(); form2.TopMost = true;
                    if (VarGeneral.UserID != 1) form2.disableactivation();
                    form2.ShowDialog();
                    if (VarGeneral.vDemo)
                    {
                         VarGeneral.labelItem_RegVisible = true;
                    }
                }
                else
                {
                    long regval = long.Parse(hKey.GetValue("SSSActivationNo").ToString());
                    string SerHrd = "";
                    try
                    {
                        ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_LogicalDisk");
                        foreach (ManagementObject wmi_HD in searcher.Get())
                        {
                            if (string.Concat(wmi_HD["Caption"]) == "C:")
                            {
                                SerHrd = Math.Abs(Convert.ToInt32(wmi_HD["VolumeSerialNumber"].ToString().Trim(), 16)).ToString();
                                break;
                            }
                        }
                    }
                    catch
                    {
                    }
                    if (regval.ToString() != long.Parse(RetScrt1(SerHrd)).ToString())
                    {
                        hKey.SetValue("SSSActivationNo", regval + 1);
                        FrmReg form2 = new FrmReg(); form2.TopMost = true;
                        form2.ShowDialog();
                         VarGeneral.labelItem_RegVisible = true;
                        VarGeneral.labelItem_RegVisible = true;
                        VarGeneral.vDemo = true;
                    }
                    else
                    {
                        try
                        {
                            string vSerial = hKey.GetValue("vSr").ToString();
                            if (string.IsNullOrEmpty(vSerial))
                            {
                                MessageBox.Show("??? ??? .. ???????? ???? ???? ?????? ????? ,???? ?????? ???????", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                                Environment.Exit(0);
                                return;
                            }
                            if (VarGeneral.SSSLev == "G")
                            {
                                if (VarGeneral.SSSTyp == 0)
                                {
                                    if (vSerial.Substring(3, 3) != "00W")
                                    {
                                        MessageBox.Show("??? ?? ????? ??? ??????? ??? ????? ??? ??? ?? ??? ?????? ?????? ??? ?????? ??? ???????.. ?????? ????? ???? ?????? ?? ???????", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                                        Environment.Exit(0);
                                        return;
                                    }
                                }
                                else if (VarGeneral.SSSTyp == 1)
                                {
                                    if (vSerial.Substring(3, 3) != "01I")
                                    {
                                        MessageBox.Show("??? ?? ????? ??? ??????? ??? ????? ??? ??? ?? ??? ?????? ?????? ??? ?????? ??? ???????.. ?????? ????? ???? ?????? ?? ???????", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                                        Environment.Exit(0);
                                        return;
                                    }
                                }
                                else if (vSerial.Substring(3, 3) != "02G")
                                {
                                    MessageBox.Show("??? ?? ????? ??? ??????? ??? ????? ??? ??? ?? ??? ?????? ?????? ??? ?????? ??? ???????.. ?????? ????? ???? ?????? ?? ???????", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                                    Environment.Exit(0);
                                    return;
                                }
                            }
                            else if (VarGeneral.SSSLev == "M")
                            {
                                if (vSerial.Substring(3, 3) != "00M")
                                {
                                    MessageBox.Show("??? ?? ????? ??? ??????? ??? ????? ??? ??? ?? ??? ?????? ?????? ??? ?????? ??? ???????.. ?????? ????? ???? ?????? ?? ???????", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                                    Environment.Exit(0);
                                    return;
                                }
                            }
                            else if (VarGeneral.SSSLev == "S")
                            {
                                if (vSerial.Substring(3, 3) != "02S")
                                {
                                    MessageBox.Show("??? ?? ????? ??? ??????? ??? ????? ??? ??? ?? ??? ?????? ?????? ??? ?????? ??? ???????.. ?????? ????? ???? ?????? ?? ???????", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                                    Environment.Exit(0);
                                    return;
                                }
                            }
                            else if (VarGeneral.SSSLev == "B")
                            {
                                if (vSerial.Substring(3, 3) != "02B")
                                {
                                    MessageBox.Show("??? ?? ????? ??? ??????? ??? ????? ??? ??? ?? ??? ?????? ?????? ??? ?????? ??? ???????.. ?????? ????? ???? ?????? ?? ???????", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                                    Environment.Exit(0);
                                    return;
                                }
                            }
                            else if (VarGeneral.SSSLev == "F")
                            {
                                if (vSerial.Substring(3, 3) != "02F")
                                {
                                    MessageBox.Show("??? ?? ????? ??? ??????? ??? ????? ??? ??? ?? ??? ?????? ?????? ??? ?????? ??? ???????.. ?????? ????? ???? ?????? ?? ???????", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                                    Environment.Exit(0);
                                    return;
                                }
                            }
                            else if (VarGeneral.SSSLev == "C")
                            {
                                if (vSerial.Substring(3, 3) != "02C")
                                {
                                    MessageBox.Show("??? ?? ????? ??? ??????? ??? ????? ??? ??? ?? ??? ?????? ?????? ??? ?????? ??? ???????.. ?????? ????? ???? ?????? ?? ???????", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                                    Environment.Exit(0);
                                    return;
                                }
                            }
                            else if (VarGeneral.SSSLev == "D")
                            {
                                if (vSerial.Substring(3, 3) != "02D")
                                {
                                    MessageBox.Show("??? ?? ????? ??? ??????? ??? ????? ??? ??? ?? ??? ?????? ?????? ??? ?????? ??? ???????.. ?????? ????? ???? ?????? ?? ???????", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                                    Environment.Exit(0);
                                    return;
                                }
                            }
                            else if (VarGeneral.SSSLev == "E")
                            {
                                if (vSerial.Substring(3, 3) != "01E")
                                {
                                    MessageBox.Show("??? ?? ????? ??? ??????? ??? ????? ??? ??? ?? ??? ?????? ?????? ??? ?????? ??? ???????.. ?????? ????? ???? ?????? ?? ???????", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                                    Environment.Exit(0);
                                    return;
                                }
                            }
                            else if (VarGeneral.SSSLev == "R")
                            {
                                if (vSerial.Substring(3, 3) != "02R")
                                {
                                    MessageBox.Show("??? ?? ????? ??? ??????? ??? ????? ??? ??? ?? ??? ?????? ?????? ??? ?????? ??? ???????.. ?????? ????? ???? ?????? ?? ???????", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                                    Environment.Exit(0);
                                    return;
                                }
                            }
                            else if (VarGeneral.SSSLev == "H")
                            {
                                if (vSerial.Substring(3, 3) != "02H")
                                {
                                    MessageBox.Show("??? ?? ????? ??? ??????? ??? ????? ??? ??? ?? ??? ?????? ?????? ??? ?????? ??? ???????.. ?????? ????? ???? ?????? ?? ???????", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                                    Environment.Exit(0);
                                    return;
                                }
                            }
                            else if (VarGeneral.SSSLev == "X")
                            {
                                if (vSerial.Substring(3, 3) != "01X")
                                {
                                    MessageBox.Show("??? ?? ????? ??? ??????? ??? ????? ??? ??? ?? ??? ?????? ?????? ??? ?????? ??? ???????.. ?????? ????? ???? ?????? ?? ???????", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                                    Environment.Exit(0);
                                    return;
                                }
                            }
                            else if (VarGeneral.SSSLev == "K")
                            {
                                if (vSerial.Substring(3, 3) != "00K")
                                {
                                    MessageBox.Show("??? ?? ????? ??? ??????? ??? ????? ??? ??? ?? ??? ?????? ?????? ??? ?????? ??? ???????.. ?????? ????? ???? ?????? ?? ???????", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                                    Environment.Exit(0);
                                    return;
                                }
                            }
                            else if (VarGeneral.SSSLev == "Z")
                            {
                                if (vSerial.Substring(3, 3) != "01Z")
                                {
                                    MessageBox.Show("??? ?? ????? ??? ??????? ??? ????? ??? ??? ?? ??? ?????? ?????? ??? ?????? ??? ???????.. ?????? ????? ???? ?????? ?? ???????", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                                    Environment.Exit(0);
                                    return;
                                }
                            }
                            else if (VarGeneral.SSSLev == "Q" && vSerial.Substring(3, 3) != "01Q")
                            {
                                MessageBox.Show("??? ?? ????? ??? ??????? ??? ????? ??? ??? ?? ??? ?????? ?????? ??? ?????? ??? ???????.. ?????? ????? ???? ?????? ?? ???????", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                                Environment.Exit(0);
                                return;
                            }
                        }
                        catch (Exception error2)
                        {
                            VarGeneral.DebLog.writeLog("FrmMain_Load:", error2, enable: true);
                            MessageBox.Show(error2.Message, VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                            MessageBox.Show("??? ??? .. ???????? ???? ???? ?????? ????? ,???? ?????? ???????", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                            Environment.Exit(0);
                            return;
                        }
                         VarGeneral.labelItem_RegVisible = false;
                        VarGeneral.vDemo = false;
                    }
                }
            }
            catch (Exception error2)
            {
                VarGeneral.DebLog.writeLog("FrmMain:", error2, enable: true);
                MessageBox.Show((LangArEn == 0) ? "??? ?????? ??? ??????? ???? ??????? ?? ??????? \n  ?? ??? ?????? ?? ???? ????? ??????..  " : "If the problem persists with you, please communicate with the administration \n is not sure of the status activated version ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                MessageBox.Show(error2.Message, VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                Environment.Exit(0);
            }
            LangArEn = VarGeneral.UserLang;
            VarGeneral.n = n;
            
            CheckReg_New();
            CheckReg_Elect();
        }
        public static  string RetScrt1(string pNo)
        {
            string RetScrt = "";
            try
            {
                if (pNo == "" || !Microsoft.VisualBasic.Information.IsNumeric(pNo))
                {
                    return RetScrt;
                }
                int ii = 0;
                int jj = 0;
                int lnNo = 0;
                string retNo = "";
                string TretNo = "";
                lnNo = pNo.Length + 1; List<int> ff = new List<int>();
                for (ii = 1; ii <= lnNo; ii++)
                {
                    TretNo = "";
                    jj = 0;
                    while (TretNo.Length <= lnNo)
                    {
                        jj++;
                        if (Microsoft.VisualBasic.Information.IsNumeric(pNo.Substring(jj, 1)))
                        {
                            TretNo += (double)(int.Parse(pNo.Substring(jj, 1)) * ii) * 0.1651;
                        }
                    }
                    ff.Add(TretNo.Length);
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

        internal static void exit()
        {
            Environment.Exit(0);
        }
    }
}
