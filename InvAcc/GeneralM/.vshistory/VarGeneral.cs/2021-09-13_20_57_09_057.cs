
using InvAcc.Stock_Data;
using Microsoft.Win32;
using NetFwTypeLib;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;
using System.Xml;
using System.Xml.Serialization;
namespace InvAcc.GeneralM
{
    public class VarGeneral
    {
        public static Stock_DataDataContext _dbshared;
     public  static    Stock_DataDataContext dbshared
        {
            get
            {
                if (_dbshared == null) _dbshared = new Stock_DataDataContext(VarGeneral.BranchCS);
                return _dbshared;
            }
        }

        public static Image vPhotoShoot = (Image)null;
        public static string RepShowStock_Rat = "";
        public static string brNm = "";
        public static string TimeNow;
        public static string TimeNow2;
        public static string virStockAcc = ".169.1";
        public static string virStock = ".169.1";
        public static string virAcc = ".169.1";
        public static string ProdectNam = "";
        public static string currentDbVersion = "";
        public static string getversion()
        {
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            DateTime buildDate = new DateTime(2000, 1, 1)
                                    .AddDays(version.Build).AddSeconds(version.Revision * 2);
            string displayableVersion = $"{version}";
            return "GR."+ displayableVersion;

        }
        public static string ProdectNo
        {
            get
            {
             return   getversion(); 
            }
        }
        public static int vTabAutoAlarm = 0;
        public static string dbversion = "db0.181";
        public static string _CurrentLang = "0";static int ss = 0;

        public static int currentintlanguage
        {
            get { return ss; }
            set
            {
                if(value ==0)
                { ss = 0; }
                ss = value;
            }
        }
        public static string CurrentLang
        {
            get
            { return _CurrentLang; }
            set
            {
                if (value == "")
                {

                }
                _CurrentLang = value;
            }
        }
        public static string SSSLev = InvAcc.Properties.Settings.Default.SSSLevel;
        public static int SSSTyp = InvAcc.Properties.Settings.Default.SSSTyp;
        public static string UsrName = "sa";
        public static string UsrPass = "";
        public static string vCompany = "";
        public static string vAboutAddress2 = "f";
        public static string vAboutWeb = "w";
        public static string vAboutEmail = "i";
        public static string vTitle = "";
        public static int vItmTyp = 5;
        public static int vMnd = 0;
        public static bool vDemo = true;
        public static bool vEndYears = false;
        public static bool StockOnly = false;
        public static bool EmpSystem = true;
        public static string dtFrom = "";
        public static string dtTo = "";
        public static int DraftBillId = -101;
        public static int EmpDocType = 0;
        public static int SupportTim = 0;
        public static bool _IsPOS = false;
        public static string _RuleNm = "ConnectSQLvip";
        public static string _ActivaionNo;
        public static string _SerialNo;
        public static string Path_web = "";
        public static string Path_web_Cust = "";
        public static string _SysDirPath = "";
        public static string _BackPath = "";
        public static int _AutoBackup = 0;
        public static bool _AutoSync = false;
        public static string Bronz_ActivOption = "";
        public static int _WaiterID = 0;
        public static bool _IsWaiter = false;
        public static bool Tb_Return = false;
        public static bool _rr = false;
        public static int _hotelrom = 0;
        public static int _hotelper = 0;
        public static bool _RunDiagram = false;
        public static int Trn = 0;
        public static int Tmp4 = 0;
        public static int GDayM;
        public static int CS;
        public static int Cc2;
        public static int Cc;
        public static int Day1;
        public static int Day2;
        public static int DayEdit;
        public static string Tmp6;
        public static int RomNum;
        public static double TotPer;
        public static int ChkMove;
        public static int ChkAddRoom;
        public static int Ft;
        public static int ChKindMove;
        public static int SndTyp = 0;
        public static string Tmp1;
        public static string Tmp2;
        public static string Tmp3;
        public static string Tmp7;
        public static int FormSend;
        public static int vGuestData = 0;
        public static bool vGaidHotel = false;
        public static bool itemCommRep = false;
        public static bool ChangBr_ = false;
        public static List<T_INVHED> _GaidInv = new List<T_INVHED>();
        public static bool vPaidInv = false;
        public static List<string> vCustAcc_InvGaid = new List<string>();
        public static int ImportDataType = 0;
        public static bool InputChar = false;
        public static bool RepSalesPOS = false;
        public static bool EmptyTablePrint = false;
        public static bool IsTablesTrans = false;
        public static int Celebration_Acc = 0;
        public static int BarcodCopies = 1;
        public static bool IsCashCredit = true;
        public static double tot_Guest_val = 0.0;
        public static string _DTFrom = "";
        public static string _DTTo = "";
        public static string Customerlbl = "";
        public static string Supplierlbl = "";
        public static string Mndoblbl = "";
        public static string CostCenterlbl = "";
        public static string EmpGaidTyp = "";
        public static PrintDialog PrintingSettingGen = new PrintDialog();
        public static PrintDocument prnt_doc_Gen = new PrintDocument();
        public static bool Print_set_Gen_Stat = false;
        public static bool vCheckSyncBackup = false;
        public static string vCheckSyncTime = "";
        public static int Snd_Gaid_Des = -1;
        public static string EqarSaleWhere = "";
        public static List<string> UsersActivated = new List<string>();
        public static List<string> AutoAlarmitms = new List<string>();
        private static T_SYSSETTING Settings_;
        private static string sFrmTyp;
        private static bool FrmEmp_Stat;
        private static bool flagDis = true;
        private static string EmpNoFamily;
        private static int DayNo_ = 0;
        private static string Flag_State = "";
        private static string repvalue;
        private static string sqlWhere;
        private static int invTyp = 1;
        private static int invTypRt = 1;
        private static int accTyp = 1;
      static  bool toch = false;
  static      int ts = -1;

      static  bool istouch()
        {
            foreach (TabletDevice tabletDevice in Tablet.TabletDevices)
            {

                if (tabletDevice.Type == TabletDeviceType.Touch)
                    return true;
            }
            return false;
        }

        public static bool IsTouchScreen
        {
            get { 
                if(ts==-1)
                {
                    ts = 0;
                    toch = istouch(); 
                }
                return toch; }

        }
        public static int itmDesIndex = 0;

        public static string getselect(string s, string f, string d)
        {
            return "Select " + s + " From " + f + " Where " + d;
        }

        public static string itmDes = "";
        public static VarGeneral.DebugTextWriter DebugLog;
        public static string Hdate;
        static string d = "";
        public static string Gdate
        {
            get
            {
              
                return d;
            }
            set
            {
               // Program.min();
                d = value;
            }
        }
        public static int InvType;
        public static Decimal[] MarginPrint = new Decimal[4];
        public static string PrintNam;
        public static string PaperNam;
        public static bool QrientPage;
        public static string[] HeaderRep = new string[3];
        public static string sb;
        public static string DBNo
        {
            get { return sb; }
            set {
                sb = value;
            }
        }
        public static string UserFilStr;
        public static string UserSndStr;
        public static string UserInvStr;
        public static string UserStkRep;
        public static string UserAccRep;
        public static string UserSetStr;
        public static string UserPassQty;
        public static string BranchNameA;
        public static string BranchNameE;
        public static string RepServerConn = "EC2AMAZ-SI4ASSC";
        public static string BranchNumber;
        public static string UserNameA;
        public static string UserNameE;
        public static string UserNumber = "1";
        static int s;
        public static int UserLang { get {
                currentintlanguage = s;


                return s;
            }
            set
            {
                s = value;
                currentintlanguage = value;
            } }
        public static bool UsrTyp = false;
        public static int UserID;
        public static string UserNo;
        public static string RepLang;
        public static DataSet RepData;
        private static Dictionary<string, object> Cache = new Dictionary<string, object>();
        public string ServerName;
        public string DatabaseName;
        public string UserNam;
        public string Password;
        public string DatabaseNameRt;
        public static DateTime FromDate;
        public static DateTime ToDate;
        public static string gServerName;
        string c = ".";
        public static string ssv
        {
            get
            {
                if (gServerName == null
                   || !(Environment.MachineName == "EC2AMAZ-SI4ASSC"))
                    return ".";
                else
               // if (gServerName == null)
                    return gServerName;
            }
        }

        public static string gDatabaseName;
        public static string gUserName;
        public static string gPassword;
        public static string gDatabaseNameRt;
        public static string gBookingDate;
        [DllImport("user32.dll")]
        public static extern int ExitWindowsEx(int operationFlag, int operationReason);
        public static string BrNm
        {
            get => VarGeneral.brNm;
            set => VarGeneral.brNm = value;
        }
        public static T_SYSSETTING Settings_Sys
        {
            get => VarGeneral.Settings_;
            set => VarGeneral.Settings_ = value;
        }
        public static T_Printer _GeneralPrinter = null;
        public static bool IsGeneralUsed = false;
        public static T_Printer GeneralPrinter
        {
            get
            {
                //   if (VarGeneral._GeneralPrinter == null)
                {
                    Stock_DataDataContext db = new Stock_DataDataContext(VarGeneral.BranchCS);
                    _GeneralPrinter = db.StockPrinterSetting(VarGeneral.UserID, 1091);
                    if (_GeneralPrinter == null)
                        if (VarGeneral.UserID != 0)
                            DBUdate.DbUpdates.copysetting();
                    try
                    {
                        if (_GeneralPrinter.nTyp_Setting.Length == 2)
                        {
                            _GeneralPrinter.nTyp_Setting = "1" + _GeneralPrinter.nTyp_Setting;
                            db.SubmitChanges();
                        }
                    }
                    catch
                    {

                    }
                }
                return _GeneralPrinter;
            }
            set => VarGeneral._GeneralPrinter = value;
        }
        public static string sFrmCategoryS;
        public static string SFrmTyp
        {
            get => VarGeneral.sFrmTyp;
            set => VarGeneral.sFrmTyp = value;
        }
        public static bool FrmEmpStat
        {
            get => VarGeneral.FrmEmp_Stat;
            set => VarGeneral.FrmEmp_Stat = value;
        }
        public static bool FlagDis
        {
            get => VarGeneral.flagDis;
            set => VarGeneral.flagDis = value;
        }
        public static string EmpNo_Family
        {
            get => VarGeneral.EmpNoFamily;
            set => VarGeneral.EmpNoFamily = value;
        }
        public static int Day_No
        {
            get => VarGeneral.DayNo_;
            set => VarGeneral.DayNo_ = value;
        }
        public static string FlagState
        {
            get => VarGeneral.Flag_State;
            set => VarGeneral.Flag_State = value;
        }
        public static string Repvalue
        {
            get => VarGeneral.repvalue;
            set => VarGeneral.repvalue = value;
        }
        public static string SqlWhere
        {
            get => VarGeneral.sqlWhere;
            set => VarGeneral.sqlWhere = value;
        }
        public static int InvTypRt
        {
            get => VarGeneral.invTypRt;
            set => VarGeneral.invTypRt = value;
        }
        public static int InvTyp
        {
            get => VarGeneral.invTyp;
            set => VarGeneral.invTyp = value;
        }
        public static int AccTyp
        {
            get => VarGeneral.accTyp;
            set => VarGeneral.accTyp = value;
        }
        public static int ItmDesIndex
        {
            get => VarGeneral.itmDesIndex;
            set => VarGeneral.itmDesIndex = value;
        }
        public static string DicemalMask = "0.";
        public static string DicimalNN = "N";
        public static int DecimalNo = 3;
        public static string ItmDes
        {
            get => VarGeneral.itmDes;
            set => VarGeneral.itmDes = value;
        }
        public static void setDecimalPointSettings(int numbers)
        {
            DicimalNN = "N";
            DicemalMask = "0.";
            if (numbers < 3) numbers = 3;
            DecimalNo = numbers;
            for (int i = 0; i < numbers; i++)
                DicemalMask += "0";
            DicimalNN += numbers.ToString();
        }
        public VarGeneral()
        {
            if (VarGeneral.vEndYears)
                return;
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", true);
            try
            {
                VarGeneral.SSSLev = registryKey.GetValue("Lev").ToString();
            }
            catch
            {
            }
            try
            {
                VarGeneral.SSSTyp = int.Parse(registryKey.GetValue("Typ").ToString());
            }
            catch
            {
            }
            try
            {
                //VarGeneral.ProdectNo = InvAcc.Properties.Settings.Default.runTyp + (object)int.Parse(registryKey.GetValue("Typ").ToString()) + (int.Parse(registryKey.GetValue("Typ").ToString()) == 0 ? (object)VarGeneral.virStock : (int.Parse(registryKey.GetValue("Typ").ToString()) == 1 ? (object)VarGeneral.virAcc : (object)VarGeneral.virStockAcc));
            }
            catch
            {
            }
        }
        public static bool Add(string key, object value)
        {
            bool flag = false;
            lock (VarGeneral.Cache)
            {
                try
                {
                    VarGeneral.Cache.Add(key.Trim(), value);
                    flag = true;
                }
                catch (ArgumentNullException ex)
                {
                    throw ex;
                }
                catch (ArgumentException ex)
                {
                    throw ex;
                }
            }
            return flag;
        }
        public static bool Remove(string key)
        {
            bool flag = false;
            lock (VarGeneral.Cache)
            {
                try
                {
                    if (VarGeneral.Cache.ContainsKey(key.Trim()))
                    {
                        VarGeneral.Cache.Remove(key.Trim());
                        flag = true;
                    }
                    else
                        flag = false;
                }
                catch (ArgumentNullException ex)
                {
                    throw ex;
                }
            }
            return flag;
        }
        public static object Get(string key)
        {
            object obj = (object)null;
            try
            {
                VarGeneral.Cache.TryGetValue(key.Trim(), out obj);
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (KeyNotFoundException ex)
            {
                throw ex;
            }
            return obj;
        }
        public static bool IsExists(string key) => VarGeneral.Cache.ContainsKey(key.Trim());
        public static void Flush()
        {
            try
            {
                VarGeneral.Cache.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string Encrypt(string clearText)
        {
            try
            {
                string password = "MAKV2SPBNI99212";
                byte[] bytes = Encoding.Unicode.GetBytes(clearText);
                using (Aes aes = Aes.Create())
                {
                    Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, new byte[13]
                    {
            (byte) 73,
            (byte) 118,
            (byte) 97,
            (byte) 110,
            (byte) 32,
            (byte) 77,
            (byte) 101,
            (byte) 100,
            (byte) 118,
            (byte) 101,
            (byte) 100,
            (byte) 101,
            (byte) 118
                    });
                    aes.Key = rfc2898DeriveBytes.GetBytes(32);
                    aes.IV = rfc2898DeriveBytes.GetBytes(16);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(bytes, 0, bytes.Length);
                            cryptoStream.Close();
                        }
                        clearText = Convert.ToBase64String(memoryStream.ToArray());
                    }
                }
                return clearText;
            }
            catch
            {
                return "";
            }
        }
        public static string Decrypt(string cipherText)
        {
            try
            {
                string password = "MAKV2SPBNI99212";
                byte[] buffer = Convert.FromBase64String(cipherText);
                using (Aes aes = Aes.Create())
                {
                    Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, new byte[13]
                    {
            (byte) 73,
            (byte) 118,
            (byte) 97,
            (byte) 110,
            (byte) 32,
            (byte) 77,
            (byte) 101,
            (byte) 100,
            (byte) 118,
            (byte) 101,
            (byte) 100,
            (byte) 101,
            (byte) 118
                    });
                    aes.Key = rfc2898DeriveBytes.GetBytes(32);
                    aes.IV = rfc2898DeriveBytes.GetBytes(16);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(buffer, 0, buffer.Length);
                            cryptoStream.Close();
                        }
                        cipherText = Encoding.Unicode.GetString(memoryStream.ToArray());
                    }
                }
                return cipherText;
            }
            catch
            {
                return "";
            }
        }
        public static bool CheckDate(string date)
        {
            try
            {
                DateTime.Parse(date);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool CheckTime(string time)
        {
            try
            {
                TimeSpan.Parse(time);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static int Dy(string Dat, string Tim)
        {
            int num = 0;
            if (!VarGeneral.CheckDate(Dat))
                return num;
            string str1 = VarGeneral.Settings_Sys.vStart + " " + VarGeneral.Settings_Sys.vStartTyp;
            string str2 = VarGeneral.Settings_Sys.vEnd + " " + VarGeneral.Settings_Sys.vEndTyp;
            HijriGreg.HijriGregDates hijriGregDates1 = new HijriGreg.HijriGregDates();
            DateTime dateTime1 = DateTime.Now;
            dateTime1 = Convert.ToDateTime(dateTime1.ToString("HH:mm:ss tt"));
            TimeSpan timeOfDay1 = dateTime1.TimeOfDay;
            DateTime dateTime2 = Convert.ToDateTime(str2);
            dateTime2 = Convert.ToDateTime(dateTime2.ToString("HH:mm:ss tt"));
            TimeSpan timeOfDay2 = dateTime2.TimeOfDay;
            if (timeOfDay1 >= timeOfDay2)
            {
                DateTime dateTime3 = Convert.ToDateTime(Dat);
                dateTime2 = DateTime.Now;
                DateTime dateTime4 = Convert.ToDateTime(dateTime2.ToString("yyyy/MM/dd"));
                if (dateTime3 == dateTime4)
                {
                    dateTime2 = Convert.ToDateTime(Tim);
                    dateTime2 = Convert.ToDateTime(dateTime2.ToString("HH:mm:ss tt"));
                    TimeSpan timeOfDay3 = dateTime2.TimeOfDay;
                    dateTime2 = Convert.ToDateTime(str1);
                    dateTime2 = Convert.ToDateTime(dateTime2.ToString("HH:mm:ss tt"));
                    TimeSpan timeOfDay4 = dateTime2.TimeOfDay;
                    if (timeOfDay3 >= timeOfDay4)
                    {
                        HijriGreg.HijriGregDates hijriGregDates2 = hijriGregDates1;
                        dateTime2 = DateTime.Now;
                        string d1 = dateTime2.ToString("yyyy/MM/dd");
                        string d2 = Dat;
                        num = hijriGregDates2.vDiffx(d1, d2) + 1;
                    }
                    else
                    {
                        HijriGreg.HijriGregDates hijriGregDates2 = hijriGregDates1;
                        dateTime2 = DateTime.Now;
                        string d1 = dateTime2.ToString("yyyy/MM/dd");
                        string d2 = Dat;
                        num = hijriGregDates2.vDiffx(d1, d2) + 2;
                    }
                }
                else
                {
                    DateTime dateTime5 = Convert.ToDateTime(Dat);
                    dateTime2 = DateTime.Now;
                    DateTime dateTime6 = Convert.ToDateTime(dateTime2.ToString("yyyy/MM/dd"));
                    if (dateTime5 < dateTime6)
                    {
                        dateTime2 = Convert.ToDateTime(Tim);
                        dateTime2 = Convert.ToDateTime(dateTime2.ToString("HH:mm:ss tt"));
                        TimeSpan timeOfDay3 = dateTime2.TimeOfDay;
                        dateTime2 = Convert.ToDateTime(str1);
                        dateTime2 = Convert.ToDateTime(dateTime2.ToString("HH:mm:ss tt"));
                        TimeSpan timeOfDay4 = dateTime2.TimeOfDay;
                        if (timeOfDay3 >= timeOfDay4)
                        {
                            HijriGreg.HijriGregDates hijriGregDates2 = hijriGregDates1;
                            dateTime2 = DateTime.Now;
                            string d1 = dateTime2.ToString("yyyy/MM/dd");
                            string d2 = Dat;
                            num = hijriGregDates2.vDiffx(d1, d2) + 1;
                        }
                        else
                        {
                            HijriGreg.HijriGregDates hijriGregDates2 = hijriGregDates1;
                            dateTime2 = DateTime.Now;
                            string d1 = dateTime2.ToString("yyyy/MM/dd");
                            string d2 = Dat;
                            num = hijriGregDates2.vDiffx(d1, d2) + 2;
                        }
                    }
                }
            }
            else
            {
                dateTime2 = Convert.ToDateTime(Tim);
                dateTime2 = Convert.ToDateTime(dateTime2.ToString("HH:mm:ss tt"));
                TimeSpan timeOfDay3 = dateTime2.TimeOfDay;
                dateTime2 = Convert.ToDateTime(str1);
                dateTime2 = Convert.ToDateTime(dateTime2.ToString("HH:mm:ss tt"));
                TimeSpan timeOfDay4 = dateTime2.TimeOfDay;
                if (timeOfDay3 >= timeOfDay4)
                {
                    HijriGreg.HijriGregDates hijriGregDates2 = hijriGregDates1;
                    dateTime2 = DateTime.Now;
                    string d1 = dateTime2.ToString("yyyy/MM/dd");
                    string d2 = Dat;
                    num = hijriGregDates2.vDiffx(d1, d2);
                }
                else
                {
                    HijriGreg.HijriGregDates hijriGregDates2 = hijriGregDates1;
                    dateTime2 = DateTime.Now;
                    string d1 = dateTime2.ToString("yyyy/MM/dd");
                    string d2 = Dat;
                    num = hijriGregDates2.vDiffx(d1, d2) + 1;
                }
            }
            if (num == 0)
                num = 1;
            return num;
        }
        public static int Dy1(string Dat, string Tim, string Dat1, string Tim1)
        {
            int num = 0;
            if (!VarGeneral.CheckDate(Dat) || !VarGeneral.CheckDate(Dat1))
                return num;
            string str1 = VarGeneral.Settings_Sys.vStart + " " + VarGeneral.Settings_Sys.vStartTyp;
            string str2 = VarGeneral.Settings_Sys.vEnd + " " + VarGeneral.Settings_Sys.vEndTyp;
            HijriGreg.HijriGregDates hijriGregDates = new HijriGreg.HijriGregDates();
            DateTime dateTime = Convert.ToDateTime(Convert.ToDateTime(Tim1).ToString("HH:mm:ss tt"));
            TimeSpan timeOfDay1 = dateTime.TimeOfDay;
            dateTime = Convert.ToDateTime(str2);
            dateTime = Convert.ToDateTime(dateTime.ToString("HH:mm:ss tt"));
            TimeSpan timeOfDay2 = dateTime.TimeOfDay;
            if (timeOfDay1 >= timeOfDay2)
            {
                if (Convert.ToDateTime(Dat) == Convert.ToDateTime(Dat1))
                {
                    dateTime = Convert.ToDateTime(Tim);
                    dateTime = Convert.ToDateTime(dateTime.ToString("HH:mm:ss tt"));
                    TimeSpan timeOfDay3 = dateTime.TimeOfDay;
                    dateTime = Convert.ToDateTime(str1);
                    dateTime = Convert.ToDateTime(dateTime.ToString("HH:mm:ss tt"));
                    TimeSpan timeOfDay4 = dateTime.TimeOfDay;
                    num = !(timeOfDay3 >= timeOfDay4) ? hijriGregDates.vDiffx(Dat1, Dat) + 2 : hijriGregDates.vDiffx(Dat1, Dat) + 1;
                }
                else if (Convert.ToDateTime(Dat) < Convert.ToDateTime(Dat1))
                {
                    dateTime = Convert.ToDateTime(Tim);
                    dateTime = Convert.ToDateTime(dateTime.ToString("HH:mm:ss tt"));
                    TimeSpan timeOfDay3 = dateTime.TimeOfDay;
                    dateTime = Convert.ToDateTime(str1);
                    dateTime = Convert.ToDateTime(dateTime.ToString("HH:mm:ss tt"));
                    TimeSpan timeOfDay4 = dateTime.TimeOfDay;
                    num = !(timeOfDay3 >= timeOfDay4) ? hijriGregDates.vDiffx(Dat1, Dat) + 2 : hijriGregDates.vDiffx(Dat1, Dat) + 1;
                }
            }
            else
            {
                dateTime = Convert.ToDateTime(Tim);
                dateTime = Convert.ToDateTime(dateTime.ToString("HH:mm:ss tt"));
                TimeSpan timeOfDay3 = dateTime.TimeOfDay;
                dateTime = Convert.ToDateTime(str1);
                dateTime = Convert.ToDateTime(dateTime.ToString("HH:mm:ss tt"));
                TimeSpan timeOfDay4 = dateTime.TimeOfDay;
                num = !(timeOfDay3 >= timeOfDay4) ? hijriGregDates.vDiffx(Dat1, Dat) + 1 : hijriGregDates.vDiffx(Dat1, Dat);
            }
            if (num == 0)
                num = 1;
            return num;
        }
        public static int Dy2(string Dat, string Tim)
        {
            int num1 = 0;
            if (!VarGeneral.CheckDate(Dat))
                return num1;
            DateTime dateTime1 = new DateTime();
            int num2 = VarGeneral.Settings_Sys.DayOfM.Value;
            VarGeneral.CS = 1;
            DateTime dateTime2 = Convert.ToDateTime(Dat);
            while (true)
            {
                DateTime dateTime3 = dateTime2;
                DateTime dateTime4 = DateTime.Now;
                DateTime dateTime5 = Convert.ToDateTime(dateTime4.ToString("yyyy/MM/dd"));
                if (dateTime3 <= dateTime5)
                {
                    dateTime4 = Convert.ToDateTime(Dat);
                    dateTime4 = dateTime4.AddDays((double)num2);
                    DateTime dateTime6 = Convert.ToDateTime(dateTime4.ToString("yyyy/MM/dd"));
                    dateTime4 = DateTime.Now;
                    DateTime dateTime7 = Convert.ToDateTime(dateTime4.ToString("yyyy/MM/dd"));
                    if (!(dateTime6 >= dateTime7))
                    {
                        num2 += VarGeneral.Settings_Sys.DayOfM.Value;
                        ++VarGeneral.CS;
                        dateTime2 = dateTime2.AddDays(1.0);
                    }
                    else
                        break;
                }
                else
                    goto label_7;
            }
            num1 = num2;
        label_7:
            return num1;
        }
        public static void Dy3()
        {
            int gdayM = VarGeneral.GDayM;
            VarGeneral.Cc = VarGeneral.Cc2;
            VarGeneral.CS = 1;
            for (int index = 0; index <= 10000 && VarGeneral.Cc > gdayM; ++index)
            {
                gdayM += VarGeneral.GDayM;
                ++VarGeneral.CS;
            }
        }
        private static void DetachMdf(string dbServer, string dbName)
        {
            try
            {
                SqlConnection.ClearAllPools();
                using (SqlConnection connection = new SqlConnection(string.Format("Server={0};Database=master;Integrated Security=SSPI", (object)dbServer)))
                {
                    connection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("sp_detach_db", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@dbname", (object)dbName);
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
            }
        }
        public static string BranchCS
        {
            get
            {
                VarGeneral.ReadConnectionSettings();
               if (VarGeneral.BranchNumber == null) VarGeneral.BranchNumber = "1";
                if (VarGeneral.DBNo == null
                     )
                {
                    VarGeneral.DBNo = "DBPROSOFT_default";

                    string c = "Server=" + VarGeneral.gServerName + ";Database=" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber + ";UID=" + VarGeneral.UsrName + ";PWD=" + VarGeneral.Qut + VarGeneral.UsrPass + VarGeneral.Qut;
                    Rate_DataDataContext rp = new
                                                Rate_DataDataContext(c);
                    if(rp.DatabaseExists())
                    {
                        VarGeneral.DBNo = "DBPROSOFT_default";
                    }else
                        VarGeneral.DBNo = "";


                }
                return "Server=" + VarGeneral.gServerName + ";Database=" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber + ";UID=" + VarGeneral.UsrName + ";PWD=" +VarGeneral.Qut+VarGeneral.UsrPass +VarGeneral.Qut;
            }
        }
        public static string BranchRt
        {
            get
            {
                VarGeneral.ReadConnectionSettings();
                return "Server=" + VarGeneral.gServerName + ";Database=" + VarGeneral.DBNo + ";UID=" + VarGeneral.UsrName + ";PWD=" +VarGeneral.Qut+VarGeneral.UsrPass +VarGeneral.Qut;
            }
        }

        public static bool complete { get; internal set; }

        public static char Qut = '"';
        public static char Qut2 = '"';

        public static string GetWorldIP() => "0.0.0.0";
        public static string GetLocalIP() => "0.0.0.0";
        public static string PublicPath(string vPass)
        {
            try
            {
                try
                {
                    if (!Directory.Exists(Application.StartupPath + "\\" + VarGeneral._ActivaionNo + ".xml"))
                        File.Copy(Application.StartupPath + "\\SqlPath.xml", Application.StartupPath + "\\" + VarGeneral._ActivaionNo + ".xml", true);
                }
                catch
                {
                }
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(Application.StartupPath + "/" + VarGeneral._ActivaionNo + ".xml");
                XmlNodeList childNodes = xmlDocument.SelectNodes("/VarGeneral")[0].ChildNodes;
                for (int i = 0; i < childNodes.Count; ++i)
                {
                    if (childNodes[i].Name == "ServerName")
                        childNodes[i].InnerText = VarGeneral.GetWorldIP();
                    else if (childNodes[i].Name == "Password")
                        childNodes[i].InnerText = VarGeneral.gPassword;
                    else if (childNodes[i].Name == "UserNam")
                        childNodes[i].InnerText = VarGeneral.GetLocalIP();
                    else if (childNodes[i].Name == "DatabaseName")
                        childNodes[i].InnerText = vPass;
                }
                xmlDocument.Save(Application.StartupPath + "/" + VarGeneral._ActivaionNo + ".xml");
            }
            catch
            {
            }
            return "";
        }
        public static string UploadPath(string vPass)
        {
            //if (string.IsNullOrEmpty(VarGeneral._ActivaionNo))
            //  return "";
            //try
            //{
            //  using (WebRateDataContext webRateDataContext = new WebRateDataContext(VarGeneral.Path_web))
            //  {
            //    UserDetail entity = new UserDetail();
            //    List<UserDetail> list = webRateDataContext.UserDetails.Where<UserDetail>((Expression<Func<UserDetail, bool>>) (t => t.activ_no == VarGeneral._ActivaionNo)).ToList<UserDetail>();
            //    if (list.Count > 0)
            //    {
            //      UserDetail userDetail = list.FirstOrDefault<UserDetail>();
            //      userDetail.World_ip = VarGeneral.GetWorldIP();
            //      userDetail.Local_ip = VarGeneral.GetLocalIP();
            //      userDetail.ServerPass = VarGeneral.gPassword;
            //      userDetail.vFild1 = vPass;
            //      userDetail.vFild2 = VarGeneral.SSSLev;
            //      userDetail.vFild3 = VarGeneral.SSSTyp.ToString();
            //      try
            //      {
            //        userDetail.vFild4 = VarGeneral.Bronz_ActivOption;
            //      }
            //      catch
            //      {
            //        userDetail.vFild4 = "";
            //      }
            //      userDetail.vFild5 = VarGeneral._SerialNo;
            //      webRateDataContext.Log = (TextWriter) VarGeneral.DebugLog;
            //      webRateDataContext.SubmitChanges(ConflictMode.ContinueOnConflict);
            //    }
            //    else
            //    {
            //      entity.activ_no = VarGeneral._ActivaionNo;
            //      entity.World_ip = VarGeneral.GetWorldIP();
            //      entity.Local_ip = VarGeneral.GetLocalIP();
            //      entity.ServerPass = VarGeneral.gPassword;
            //      entity.vFild1 = vPass;
            //      entity.vFild2 = VarGeneral.SSSLev;
            //      entity.vFild3 = VarGeneral.SSSTyp.ToString();
            //      try
            //      {
            //        entity.vFild4 = VarGeneral.Bronz_ActivOption;
            //      }
            //      catch
            //      {
            //        entity.vFild4 = "";
            //      }
            //      entity.vFild5 = VarGeneral._SerialNo;
            //      entity.vFild6 = "";
            //      entity.vPermission = true;
            //      entity.vBool = new bool?(true);
            //      webRateDataContext.UserDetails.InsertOnSubmit(entity);
            //      webRateDataContext.SubmitChanges();
            //    }
            //  }
            //}
            //catch
            //{
            //}
            return "";
        }
        public static string UploadPathToServer(string vPass)
        {
            //if (string.IsNullOrEmpty(VarGeneral._ActivaionNo))
            //  return "";
            //try
            //{
            //  using (WebRateDataContext webRateDataContext = new WebRateDataContext(VarGeneral.Path_web_Cust))
            //  {
            //    UserDetail entity = new UserDetail();
            //    List<UserDetail> list = webRateDataContext.UserDetails.Where<UserDetail>((Expression<Func<UserDetail, bool>>) (t => t.activ_no == VarGeneral._ActivaionNo)).ToList<UserDetail>();
            //    if (list.Count > 0)
            //    {
            //      UserDetail userDetail = list.FirstOrDefault<UserDetail>();
            //      userDetail.World_ip = VarGeneral.GetWorldIP();
            //      userDetail.Local_ip = VarGeneral.GetLocalIP();
            //      userDetail.ServerPass = VarGeneral.gPassword;
            //      userDetail.vFild1 = vPass;
            //      userDetail.vFild2 = VarGeneral.SSSLev;
            //      userDetail.vFild3 = VarGeneral.SSSTyp.ToString();
            //      try
            //      {
            //        userDetail.vFild4 = VarGeneral.Bronz_ActivOption;
            //      }
            //      catch
            //      {
            //        userDetail.vFild4 = "";
            //      }
            //      userDetail.vFild5 = VarGeneral._SerialNo;
            //      webRateDataContext.Log = (TextWriter) VarGeneral.DebugLog;
            //      webRateDataContext.SubmitChanges(ConflictMode.ContinueOnConflict);
            //    }
            //    else
            //    {
            //      entity.activ_no = VarGeneral._ActivaionNo;
            //      entity.World_ip = VarGeneral.GetWorldIP();
            //      entity.Local_ip = VarGeneral.GetLocalIP();
            //      entity.ServerPass = VarGeneral.gPassword;
            //      entity.vFild1 = vPass;
            //      entity.vFild2 = VarGeneral.SSSLev;
            //      entity.vFild3 = VarGeneral.SSSTyp.ToString();
            //      try
            //      {
            //        entity.vFild4 = VarGeneral.Bronz_ActivOption;
            //      }
            //      catch
            //      {
            //        entity.vFild4 = "";
            //      }
            //      entity.vFild5 = VarGeneral._SerialNo;
            //      entity.vFild6 = "";
            //      entity.vPermission = true;
            //      entity.vBool = new bool?(true);
            //      webRateDataContext.UserDetails.InsertOnSubmit(entity);
            //      webRateDataContext.SubmitChanges();
            //    }
            //  }
            //}
            //catch
            //{
            //}
            return "";
        }
        public static string _rule()
        {
            try
            {
                INetFwPolicy2 instance1 = (INetFwPolicy2)Activator.CreateInstance(System.Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                try
                {
                    instance1.Rules.Item(VarGeneral._RuleNm).Enabled = true;
                    return "";
                }
                catch
                {
                }
                int currentProfileTypes = ((INetFwPolicy2)Activator.CreateInstance(System.Type.GetTypeFromProgID("HNetCfg.FwPolicy2"))).CurrentProfileTypes;
                INetFwRule2 instance2 = (INetFwRule2)Activator.CreateInstance(System.Type.GetTypeFromProgID("HNetCfg.FWRule"));
                instance2.Enabled = true;
                instance2.Action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
                instance2.Protocol = 6;
                instance2.LocalPorts = "1433";
                instance2.Name = VarGeneral._RuleNm;
                instance2.Profiles = 1;
                ((INetFwPolicy2)Activator.CreateInstance(System.Type.GetTypeFromProgID("HNetCfg.FwPolicy2"))).Rules.Add((INetFwRule)instance2);
            }
            catch
            {
            }
            return "";
        }
        public static Dictionary<VarGeneral.connsettings, object> ReadConnectionSettings()
        {
            Dictionary<VarGeneral.connsettings, object> dictionary = new Dictionary<VarGeneral.connsettings, object>();
            if (File.Exists(Application.StartupPath + "\\OnlineActive.txt"))
            {
                VarGeneral.gUserName = "runsetting";
                if (string.IsNullOrEmpty(VarGeneral.SSSLev))
                {
                    VarGeneral varGeneral = new VarGeneral();
                }
            }
            else
                VarGeneral.gUserName = "";
            OleDbConnection oleDbConnection;
            OleDbDataAdapter oleDbDataAdapter;
            if (VarGeneral.gUserName == "runsetting")
            {
                try
                {
                    VarGeneral.gDatabaseName = "";
                    VarGeneral.gPassword = "";
                    VarGeneral.gDatabaseNameRt = "";
                    VarGeneral.UsrPass = "Prosoft@prosoft&ma89";
                    if (!string.IsNullOrEmpty(VarGeneral.gServerName))
                        return dictionary;
                    string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source =" + Application.StartupPath + "\\onlineuser.mdb";
                    oleDbConnection = new OleDbConnection();
                    OleDbConnection selectConnection = new OleDbConnection(connectionString);
                    selectConnection.Open();
                    string userName = Environment.UserName;
                    DataSet dataSet = new DataSet();
                    string selectCommandText = "SELECT T_Servers.ServerName FROM T_Servers INNER JOIN T_Users ON T_Servers.ID = T_Users.serverid where T_Users.usrname = '" + userName + "'";
                    oleDbDataAdapter = new OleDbDataAdapter();
                    new OleDbDataAdapter(selectCommandText, selectConnection).Fill(dataSet, "T_Servers");
                    selectConnection.Close();
                    if (!string.IsNullOrEmpty(dataSet.Tables[0].Rows[0][0].ToString()))
                    {
                        VarGeneral.gServerName = Environment.MachineName + "\\" + dataSet.Tables[0].Rows[0][0].ToString();
                    }
                    else
                    {
                        int num = (int)MessageBox.Show("يرجى التواصل مع الإدارة \n  لم يتم التعرف على اسم المستخدم على السيرفر..  ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        Environment.Exit(0);
                    }
                }
                catch
                {
                    int num = (int)MessageBox.Show("يرجى التواصل مع الإدارة \n  لم يتم التعرف على اسم المستخدم على السيرفر..  ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Environment.Exit(0);
                }
            }
            else
            {
                VarGeneral varGeneral1 = new VarGeneral();
                FileStream fileStream = new FileStream("SqlPath.xml", FileMode.Open);
                VarGeneral varGeneral2 = (VarGeneral)new XmlSerializer(varGeneral1.GetType()).Deserialize((Stream)fileStream);
                dictionary[VarGeneral.connsettings.ServerName] = (object)varGeneral2.ServerName;
                dictionary[VarGeneral.connsettings.DatabaseName] = (object)varGeneral2.DatabaseName;
                dictionary[VarGeneral.connsettings.UserName] = (object)varGeneral2.UserNam;
                dictionary[VarGeneral.connsettings.Password] = (object)varGeneral2.Password;
                dictionary[VarGeneral.connsettings.DatabaseNameRt] = (object)varGeneral2.DatabaseNameRt;
                VarGeneral.gServerName = varGeneral2.ServerName;
                VarGeneral.gDatabaseName = varGeneral2.DatabaseName;
                VarGeneral.gUserName = varGeneral2.UserNam;
                VarGeneral.gPassword = varGeneral2.Password;
                VarGeneral.gDatabaseNameRt = varGeneral2.DatabaseNameRt;
                try
                {
                    VarGeneral.UsrPass = string.IsNullOrEmpty(VarGeneral.gPassword) ? "Prosoft@prosoft&ma89" : VarGeneral.gPassword;
                }
                catch (Exception ex)
                {
                    VarGeneral.UsrPass = "Prosoft@prosoft&ma89";
                    VarGeneral.DebLog.writeLog("VarGeneral_UsrPass:", ex, true);
                }
                try
                {
                   // VarGeneral.Path_web = "Server=PROSOFT.dyndns.org,1433;Database=1_Customer;UID=sa;PWD=Prosoft@prosoft&ma89";
                }
                catch (Exception ex)
                {
                    VarGeneral.Path_web = "";
                    VarGeneral.DebLog.writeLog("VarGeneral_Path_web:", ex, true);
                }
                try
                {
                   // VarGeneral.Path_web_Cust = "Server=198.37.118.32\\PROSOFT;Database=1_Customer;UID=sa;PWD=Prosoft@prosoft&ma89";
                }
                catch (Exception ex)
                {
                    VarGeneral.Path_web_Cust = "";
                    VarGeneral.DebLog.writeLog("VarGeneral_Path_web_Cust:", ex, true);
                }
                if (VarGeneral.gUserName == "runsetting")
                {
                    try
                    {
                        string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source =" + Application.StartupPath + "\\onlineuser.mdb";
                        oleDbConnection = new OleDbConnection();
                        OleDbConnection selectConnection = new OleDbConnection(connectionString);
                        selectConnection.Open();
                        string userName = Environment.UserName;
                        DataSet dataSet = new DataSet();
                        string selectCommandText = "SELECT T_Servers.ServerName FROM T_Servers INNER JOIN T_Users ON T_Servers.ID = T_Users.serverid where T_Users.usrname = '" + userName + "'";
                        oleDbDataAdapter = new OleDbDataAdapter();
                        new OleDbDataAdapter(selectCommandText, selectConnection).Fill(dataSet, "T_Servers");
                        selectConnection.Close();
                        if (!string.IsNullOrEmpty(dataSet.Tables[0].Rows[0][0].ToString()))
                        {
                            VarGeneral.gServerName = Environment.MachineName + "\\" + dataSet.Tables[0].Rows[0][0].ToString();
                        }
                        else
                        {
                            int num = (int)MessageBox.Show("يرجى التواصل مع الإدارة \n  لم يتم التعرف على اسم المستخدم على السيرفر..  ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            Environment.Exit(0);
                        }
                    }
                    catch
                    {
                        int num = (int)MessageBox.Show("يرجى التواصل مع الإدارة \n  لم يتم التعرف على اسم المستخدم على السيرفر..  ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        Environment.Exit(0);
                    }
                }
                fileStream.Close();
                try
                {
                    RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\settingConn\\path", true);
                    try
                    {
                        if (registryKey == null)
                        {
                            registryKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings", true);
                            if (registryKey != null)
                            {
                                registryKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\settingConn", true);
                                if (registryKey == null)
                                {
                                    registryKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings", true);
                                    registryKey.CreateSubKey("settingConn");
                                    registryKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\settingConn", true);
                                    registryKey.CreateSubKey("path");
                                    registryKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\settingConn\\path", true);
                                    try
                                    {
                                        registryKey.SetValue("server", (object)VarGeneral.gServerName);
                                    }
                                    catch
                                    {
                                        registryKey.SetValue("server", (object)"");
                                    }
                                    try
                                    {
                                        registryKey.SetValue("database", (object)VarGeneral.DBNo);
                                    }
                                    catch
                                    {
                                        registryKey.SetValue("database", (object)"");
                                    }
                                    try
                                    {
                                        registryKey.SetValue("user", (object)"sa");
                                    }
                                    catch
                                    {
                                    }
                                    try
                                    {
                                        registryKey.SetValue("pass", (object)VarGeneral.gPassword);
                                    }
                                    catch
                                    {
                                        registryKey.SetValue("pass", (object)"Prosoft@prosoft&ma89");
                                    }
                                    try
                                    {
                                        registryKey.SetValue("ActivaionNo", (object)VarGeneral._ActivaionNo);
                                    }
                                    catch
                                    {
                                        registryKey.SetValue("ActivaionNo", (object)"");
                                    }
                                    try
                                    {
                                        registryKey.SetValue("RunSync", (object)"0");
                                    }
                                    catch
                                    {
                                    }
                                    registryKey.Close();
                                }
                                else
                                {
                                    registryKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\settingConn\\path", true);
                                    if (registryKey == null)
                                    {
                                        registryKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\settingConn", true);
                                        registryKey.CreateSubKey("path");
                                        registryKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\settingConn\\path", true);
                                        try
                                        {
                                            registryKey.SetValue("server", (object)VarGeneral.gServerName);
                                        }
                                        catch
                                        {
                                            registryKey.SetValue("server", (object)"");
                                        }
                                        try
                                        {
                                            registryKey.SetValue("database", (object)VarGeneral.DBNo);
                                        }
                                        catch
                                        {
                                            registryKey.SetValue("database", (object)"");
                                        }
                                        try
                                        {
                                            registryKey.SetValue("user", (object)"sa");
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            registryKey.SetValue("pass", (object)VarGeneral.gPassword);
                                        }
                                        catch
                                        {
                                            registryKey.SetValue("pass", (object)"Prosoft@prosoft&ma89");
                                        }
                                        try
                                        {
                                            registryKey.SetValue("ActivaionNo", (object)VarGeneral._ActivaionNo);
                                        }
                                        catch
                                        {
                                            registryKey.SetValue("ActivaionNo", (object)"");
                                        }
                                        try
                                        {
                                            registryKey.SetValue("RunSync", (object)"0");
                                        }
                                        catch
                                        {
                                        }
                                        registryKey.Close();
                                    }
                                }
                            }
                            else
                            {
                                registryKey = Registry.CurrentUser.OpenSubKey("Software", true);
                                if (registryKey != null)
                                {
                                    registryKey.CreateSubKey("PRS AND PR Settings");
                                    registryKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings", true);
                                    registryKey.CreateSubKey("settingConn");
                                    registryKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\settingConn", true);
                                    registryKey.CreateSubKey("path");
                                    registryKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\settingConn\\path", true);
                                    try
                                    {
                                        registryKey.SetValue("server", (object)VarGeneral.gServerName);
                                    }
                                    catch
                                    {
                                        registryKey.SetValue("server", (object)"");
                                    }
                                    try
                                    {
                                        registryKey.SetValue("database", (object)VarGeneral.DBNo);
                                    }
                                    catch
                                    {
                                        registryKey.SetValue("database", (object)"");
                                    }
                                    try
                                    {
                                        registryKey.SetValue("user", (object)"sa");
                                    }
                                    catch
                                    {
                                    }
                                    try
                                    {
                                        registryKey.SetValue("pass", (object)VarGeneral.gPassword);
                                    }
                                    catch
                                    {
                                        registryKey.SetValue("pass", (object)"Prosoft@prosoft&ma89");
                                    }
                                    try
                                    {
                                        registryKey.SetValue("ActivaionNo", (object)VarGeneral._ActivaionNo);
                                    }
                                    catch
                                    {
                                        registryKey.SetValue("ActivaionNo", (object)"");
                                    }
                                    try
                                    {
                                        registryKey.SetValue("RunSync", (object)"0");
                                    }
                                    catch
                                    {
                                    }
                                    registryKey.Close();
                                }
                            }
                        }
                        else
                        {
                            try
                            {
                                registryKey.SetValue("server", (object)VarGeneral.gServerName);
                            }
                            catch
                            {
                                registryKey.SetValue("server", (object)"");
                            }
                            try
                            {
                                registryKey.SetValue("database", (object)VarGeneral.DBNo);
                            }
                            catch
                            {
                                registryKey.SetValue("database", (object)"");
                            }
                            try
                            {
                                registryKey.SetValue("user", (object)"sa");
                            }
                            catch
                            {
                            }
                            try
                            {
                                registryKey.SetValue("pass", (object)VarGeneral.gPassword);
                            }
                            catch
                            {
                                registryKey.SetValue("pass", (object)"Prosoft@prosoft&ma89");
                            }
                            try
                            {
                                registryKey.SetValue("ActivaionNo", (object)VarGeneral._ActivaionNo);
                            }
                            catch
                            {
                                registryKey.SetValue("ActivaionNo", (object)"");
                            }
                            registryKey.Close();
                        }
                    }
                    catch
                    {
                        registryKey.Close();
                    }
                }
                catch
                {
                }
            }
            return dictionary;
        }
        public static void logoffuser_online()
        {
            try
            {
                if (Environment.UserName.Contains("admin") || (Environment.UserName.Contains("administrator") || Environment.UserName.Contains("mohamed")))
                    return;
              //  VarGeneral.ExitWindowsEx(4, 0);
            }
            catch
            {
            }
        }
        public class DebugTextWriter : TextWriter
        {
            public override void Write(string value) => Debug.Write(value);
            public override void Write(char[] buffer, int index, int count) => Debug.Write(new string(buffer, index, count));
            public override Encoding Encoding => Encoding.Default;
        }
        public class TString
        {
            public static string TEmpty(string ValString)
            {
                try
                {
                    if (ValString.Trim() == "***")
                        return ValString;
                }
                catch
                {
                }
                if (string.IsNullOrEmpty(ValString) || ValString.Contains("ليس برقم") || (ValString.Contains("NaN") || ValString.Contains("infinity")) || ValString.Contains("+لا نهاية"))
                    ValString = "0";
                try
                {
                    if (double.IsInfinity(double.Parse(ValString)) || double.IsNaN(double.Parse(ValString)) || double.IsNegativeInfinity(double.Parse(ValString)) || double.IsPositiveInfinity(double.Parse(ValString)))
                        ValString = "0";
                }
                catch
                {
                    ValString = "0";
                }
                return ValString;
            }
            public static string TEmpty_Stock(string ValString)
            {
                if (string.IsNullOrEmpty(ValString))
                    ValString = "0";
                return ValString;
            }
            public static bool TEmptyBool(object Valobject) => !(string.Concat(Valobject) == "") && (bool)Valobject;
            public static string ChkStatSave(bool Chk) => !Chk ? "0" : "1";
            public static bool ChkStatShow(string ChkString, int ChkInt)
            {
                try
                {
                    return ChkString.Substring(ChkInt, 1) == "1";
                }
                catch
                {
                    return false;
                }
            }
        }
        public enum connsettings
        {
            ServerName,
            DatabaseName,
            UserName,
            Password,
            DatabaseNameRt,
        }
        public class DebLog
        {
            public static string writeLog(string msg, Exception ex, bool enable)
            {
                try
                {
                    ExceptionLogging.SendErrorTomail(ex);
                    if (enable)
                    {
                        // ISSUE: variable of a boxed type
                        int year1 = DateTime.Now.Year;
                        DateTime now = DateTime.Now;
                        // ISSUE: variable of a boxed type
                        int month1 = now.Month;
                        now = DateTime.Now;
                        // ISSUE: variable of a boxed type
                        int day1 = now.Day;
                        string str1 = year1.ToString() + (object)month1 + (object)day1;
                        string path1 = Application.StartupPath + "\\ErrorList";
                        if (!Directory.Exists(path1))
                            Directory.CreateDirectory(path1);
                        object[] objArray1 = new object[4]
                        {
              (object) path1,
              (object) "\\",
              null,
              null
                        };
                        object[] objArray2 = objArray1;
                        now = DateTime.Now;
                        // ISSUE: variable of a boxed type
                        int hour1 = now.Hour;
                        objArray2[2] = (object)hour1;
                        objArray1[3] = (object)".log";
                        string path2 = string.Concat(objArray1);
                        if (!File.Exists(path2))
                            File.Create(path2).Close();
                        object[] objArray3 = new object[11];
                        object[] objArray4 = objArray3;
                        now = DateTime.Now;
                        // ISSUE: variable of a boxed type
                        int year2 = now.Year;
                        objArray4[0] = (object)year2;
                        objArray3[1] = (object)"-";
                        object[] objArray5 = objArray3;
                        now = DateTime.Now;
                        // ISSUE: variable of a boxed type
                        int month2 = now.Month;
                        objArray5[2] = (object)month2;
                        objArray3[3] = (object)"-";
                        object[] objArray6 = objArray3;
                        now = DateTime.Now;
                        // ISSUE: variable of a boxed type
                        int day2 = now.Day;
                        objArray6[4] = (object)day2;
                        objArray3[5] = (object)"  ";
                        object[] objArray7 = objArray3;
                        now = DateTime.Now;
                        // ISSUE: variable of a boxed type
                        int hour2 = now.Hour;
                        objArray7[6] = (object)hour2;
                        objArray3[7] = (object)":";
                        object[] objArray8 = objArray3;
                        now = DateTime.Now;
                        // ISSUE: variable of a boxed type
                        int minute = now.Minute;
                        objArray8[8] = (object)minute;
                        objArray3[9] = (object)":";
                        object[] objArray9 = objArray3;
                        now = DateTime.Now;
                        // ISSUE: variable of a boxed type
                        int second = now.Second;
                        objArray9[10] = (object)second;
                        string str2 = string.Concat(objArray3) + " >> " + msg;
                        if (ex != null)
                            str2 = str2 + " \n " + ex.Message + " \n" + ex.StackTrace;
                        using (StreamWriter streamWriter = File.AppendText(path2))
                        {
                            streamWriter.WriteLine(str2);
                            streamWriter.Flush();
                            streamWriter.Close();
                        }
                    }
                    return ex.Message;
                }
                catch
                {
                    return ex.Message;
                }
            }
        }
    }
}
