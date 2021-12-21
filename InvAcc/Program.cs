using InvAcc.Forms;
 
using InvAcc.Forms.Shared;
using ProShared.GeneralM;using ProShared;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using System;
using System.Data;
using System.Deployment.Application;
using System.Diagnostics;
using System.IO;
using System.Runtime;
using System.Threading;
using System.Windows.Forms;
using InvAcc.Forms.Eqr_Version.New;
using ProShared.DBUdate;
using InvAcc.Forms.Cards;
using ProShared.Stock_Data;

namespace InvAcc
{
    static class Program
    {//88888
#pragma warning disable CS0414 // The field 'Program.workerThread' is assigned but its value is never used
        static Thread workerThread = null;
#pragma warning restore CS0414 // The field 'Program.workerThread' is assigned but its value is never used
        public static int runtimeex1 = 0;
        public static int runtimeex2 = 0;
        static int ks = 0;
        public static bool isdevelopermachine()
        {

            if (Environment.MachineName.ToLower() == "instance-3" || Environment.MachineName == "DESKTOP-320H5U2")
            {
                VarGeneral.SSSLev = "Q";
                if (ks == 0)
                {
                    try
                    {
                        ks = 1;

                        new FrmMain(null, null, "1", 0);
                        Rate_DataDataContext db = new Rate_DataDataContext();
                        T_User permission = db.Get_PermissionID(int.Parse("1"));
                        new Stock_DataDataContext().getdate = "";
                        VarGeneral.UserID = permission.Usr_ID;
                        VarGeneral.UserNo = permission.UsrNo;
                        VarGeneral.InvTyp = 2;
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
                        VarGeneral.Settings_Sys = new Stock_DataDataContext().SystemSettingStock();

                    }
                    catch { }
                }
                return true;
            }
            else return false;
        }
        private static void applicatdin_thread_expcion(object sender, UnhandledExceptionEventArgs e)
        {
            closing(null, null);
            VarGeneral.DebLog.writeLog("UnHandeledException",
               (Exception)e.ExceptionObject, enable: true);
        }
        private static void applicatin_thread_expcion(object sender, ThreadExceptionEventArgs e)
        {
            closing(null, null);
            VarGeneral.DebLog.writeLog("UnHandeledException",
              e.Exception, enable: true);
        }
        private static void closing(object sender, EventArgs e)
        {


        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += applicatin_thread_expcion;
            Application.ThreadException += new ThreadExceptionEventHandler(applicatin_thread_expcion);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(applicatdin_thread_expcion);
            Application.ApplicationExit += closing;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            VarGeneral.ProdectNo = getversion();
            try { isdevelopermachine(); } catch { }
            try
            {
            
                if ((ApplicationDeployment.IsNetworkDeployed && ApplicationDeployment.CurrentDeployment.IsFirstRun) || File.Exists(Application.StartupPath + "\\install.txt"))

                {
                    string appPath = Application.StartupPath;
                    string winPath = Environment.GetEnvironmentVariable("WINDIR");

                    Process proc = new Process();
                    System.IO.Directory.SetCurrentDirectory(appPath);

                    proc.EnableRaisingEvents = false;
                    proc.StartInfo.CreateNoWindow = false;
                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                    proc.StartInfo.FileName = winPath + @"\Microsoft.NET\Framework\v2.0.50727\ngen.exe";
                    proc.StartInfo.Arguments = "uninstall " + Application.ProductName + " /nologo /silent";

                    proc.Start();
                    proc.WaitForExit();
                    if (!isdevelopermachine())
                    File.Delete(Application.StartupPath + "\\install.txt");

                    proc.StartInfo.FileName = winPath + @"\Microsoft.NET\Framework\v2.0.50727\ngen.exe";
                    proc.StartInfo.Arguments = "install " + Application.ProductName + " /nologo /silent";

                    proc.Start();
                    proc.WaitForExit();

                }
                ProfileOptimization.SetProfileRoot(Application.StartupPath);
                ProfileOptimization.StartProfile("Startup.Profile");
            }
            catch
            { }

            if (iscarversion())
            {
                setnewviersion("CarVersion.CR.400.22" +
                    "");  
                setdbver("CarVersion.CR.400.22");
            }
            else
            {
                setnewviersion(".CR.400.22");
                setdbver(".CR.400.22");

            }
            FrmReportsViewer.TypeOfReporting = isfastversion();

            DbUpdates f = new DbUpdates();

            //InvAcc.Properties.Settings.Default.B4 = k

           
            // 
            setserve();
            //  Application.Run(new Forms.formstest("13"));
            //Application.Run(new FrmCarChecking("4"));
            try
            {
                File.Delete(Application.StartupPath +"\\flxgridD.txt");
            }
            catch
            {}
            Application.Run(new FrmLog());
            closing(null, null);
        }
        public static string getversion()
        {
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            DateTime buildDate = new DateTime(2000, 1, 1)
                                    .AddDays(version.Build).AddSeconds(version.Revision * 2);
            string displayableVersion = $"{version}";
            return "GR." + displayableVersion;

        }
        static  void setserve()
        {
            {
if(!(Environment.MachineName== "EC2AMAZ-SI4ASSC"))
                { VarGeneral.Qut = ' ';
                    InvAcc.Properties.Settings.Default.SPassword = InvAcc.Properties.Settings.Default.SPassword.Replace('"',' ');
                }
                else VarGeneral.Qut = '"';
            }
        }

        public static
        void createdb_BARACODE(DataTable B_TABLE, string XmlFile)
        {
            DataSet invo = new DataSet();


            //  System.Windows.Forms.MessageBox.Show(B_TABLE.DataSet.ToString());
            invo.Tables.Add(B_TABLE.Copy());
            invo.Tables[0].TableName = "item";
            //string outpath = System.Windows.Forms.Application.StartupPath + "\\" + "baracode_product.xml";
            string outpath = System.Windows.Forms.Application.StartupPath + "\\" + XmlFile + ".xml";

            if (File.Exists(outpath))
            {
                System.IO.File.Delete(outpath);
            }
            using (TextWriter tw = File.CreateText(outpath))
            {

                invo.WriteXml(tw);
                tw.Close();
            }
            invo.Tables.Clear();
            invo.Dispose();

            //     System.Windows.Forms.MessageBox.Show("dispos");
        }
        public static string getbno()
        {
            RegistryKey hKeyNeew1 = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\dlouyt", writable: true);
            string bno = "";
            try
            {
                object q = hKeyNeew1.GetValue("dlouyt");
                bno = q.ToString();
            }
            catch
            {
                bno = "1";
            }
            return bno;
        }
        public static bool iscarversion()
        {
            if (File.Exists(Application.StartupPath + "\\Script\\carsdll.dll"))
            {
                return true;
            }
            return false;
        }
        public static int isfastversion()
        {
            if (File.Exists(Application.StartupPath + "\\Script\\fastdll.dll"))
            {
                return 1;
            }
            return 0;
        }
        public static bool isScriptOf(string s)
        {
            if (!s.Contains(".dll"))
                s += ".dll";
            if (File.Exists(Application.StartupPath + "\\Script\\" + s))
            {
                return true;
            }
            else return false;
        }
        public static void min()
        {
            foreach (Form i in Application.OpenForms)
            {
                if (isdevelopermachine())
                    i.TopMost = false;
            }

        }
        public static void min3()
        {
            foreach (Form i in Application.OpenForms)
            {
               
                    i.TopMost = false;
            }
        }

        public static void min2()
        {
            foreach (Form i in Application.OpenForms)
            {
                i.WindowState = FormWindowState.Minimized;
            }
        }
        public static void restartprogram()
        {
            closing(null, null);

            string arguments = string.Empty;
            string[] args = Environment.GetCommandLineArgs();
            for (int i = 1; i < args.Length; i++)
            {
                arguments = arguments + args[i] + " ";
            }
            Application.ExitThread();
            Process.Start(Application.ExecutablePath, arguments);
        }

        public static void setdbver(string s)
        {
            VarGeneral.dbversion = "db.0" + s;
        //   ProShared. DBUdate.DbUpdates.dbvers =ProShared. DBUdate.DbUpdates.dbvers.Replace("Versiong0001", VarGeneral.dbversion);
        }

        public static void setnewviersion(string s)
        {
            s = "." + s;
            ProShared.GeneralM.VarGeneral.virStockAcc = s;
            ProShared.GeneralM.VarGeneral.virAcc = s;
            ProShared.GeneralM.VarGeneral.virStock = s;


        }

        public static bool sIsNumeric(string s)
        {

            return Information.IsNumeric(s);
        }

    }
}
