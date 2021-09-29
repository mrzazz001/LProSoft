using System;
using System.IO;
using System.Text;
using Microsoft.Win32;
using System.Diagnostics;
using System.Windows.Forms;

namespace SqlExp
{
    public class SqlExpInstall
    {
        public static void InstallSqlEngine(string sqlpath,string name,string password)
        {
            SqlExpInstall EI = new SqlExpInstall();
            EI.instanceName = name;
            EI.saPassword = password;
            EI.sqlExpressSetupFileLocation = sqlpath;// Path.Combine(sqlpath, );  //Provide location for the Express setup file              
           int pid = EI.InstallExpress();
            // System.Diagnostics.Process processObj = System.Diagnostics.Process.Start(sqlpath,  @"/q /Action=Install  /IAcceptSQLServerLicenseTerms=True /Features=SQL,Tools /InstanceName=SQLExpress /SQLSYSADMINACCOUNTS=""Builtin\Administrators"" /SQLSVCACCOUNT="+EI.sqlAccount+" /SQLSVCPASSWORD="+password);
          //  now let's wait till the setup is complete  
            Process installp = Process.GetProcessById(pid);
            if (installp != null)
                installp.WaitForExit();
            int cc = installp.ExitCode;
        }
        #region Internal variables  

        //Variables for setup.exe command line  
        private string instanceAction = "Install";                                                          // Required  
        private string instanceFeature = "FEATURES=SQL";                                                       // Required  
        public string instanceName = "SQLEXPRESS";                                                          // Required  
        public string installSqlDir = "C:\\Program Files\\";                                                // Optional  
        public string installSqlSharedDir = "C:\\Program Files\\";                                          // Optional  
        public string installSqlDataDir = "C:\\Program Files\\Microsoft SQL Server\\";                      // Optional  
        public bool sqlAutoStart = true;                                                                    // Optional  
        public bool sqlBrowserAutoStart = false;                                                            // Optional  
        public string sqlBrowserAccount = "NT AUTHORITY\\SYSTEM";                                           // Optional  
        public string sqlBrowserPassword = "";                                                              // Optional  
        public string sqlAccount = "NT AUTHORITY\\SYSTEM";                                                  // Required  
        public string sqlPassword = "testdemo";                                                             // Required  
        public bool sqlSecurityMode = true;                                                                 // Optional  
        public string saPassword = "tetdemo123";                                                           // Required when SECURITYMODE=SQL  
        public string sqlCollation = "SQL_Latin1_General_Cp1_CS_AS";                                        // Optional  
        public bool disableNetworkProtocols = true;                                                         // Optional  
        public bool errorReporting = true;                                                                  // Optional  
        public string sqlExpressSetupFileLocation = Path.Combine(@"C:\Downloads", "sqlexpr.exe");   // Required  
        public bool enableRANU = false;                                                                     // Optional  
        public string sysAdminAccount = "Builtin\\Administrators";                                          // Required  
        public string agtSqlAccount = "NT AUTHORITY\\Network Service";                                      // Required  
        public bool sqlServiceLicence = true;                                                               // Required  

        #endregion

        private string BuildCommandLine()
        {
            StringBuilder strCommandLine = new StringBuilder();

            if (!IsNullOrEmpty(instanceAction))
            {
                strCommandLine.Append(" ACTION=\"").Append(instanceAction).Append("\"");
            }

            if (!IsNullOrEmpty(instanceFeature))
            {
                strCommandLine.Append(" FEATURES=\"").Append(instanceFeature).Append("\"");
            }

            if (!IsNullOrEmpty(installSqlDir))
            {
                strCommandLine.Append(" INSTANCENAME=\"").Append(instanceName).Append("\"");
            }

            if (!IsNullOrEmpty(sqlAccount))
            {
                strCommandLine.Append(" SQLSVCACCOUNT=\"").Append(sqlAccount).Append("\"");
            }

            if (!IsNullOrEmpty(sqlPassword))
            {
                strCommandLine.Append(" SQLSVCPASSWORD=\"").Append(sqlPassword).Append("\"");
            }

            if (!IsNullOrEmpty(sysAdminAccount))
            {
                strCommandLine.Append(" SQLSYSADMINACCOUNTS=\"").Append(sysAdminAccount).Append("\"");
            }

            if (!IsNullOrEmpty(agtSqlAccount))
            {
                strCommandLine.Append(" AGTSVCACCOUNT=\"").Append(agtSqlAccount).Append("\"");
            }

            if (sqlSecurityMode == true)
            {
                strCommandLine.Append(" SECURITYMODE=SQL");
            }

            if (!IsNullOrEmpty(saPassword))
            {
                strCommandLine.Append(" SAPWD=\"").Append(saPassword).Append("\"");
            }

            if (!IsNullOrEmpty(sqlCollation))
            {
                strCommandLine.Append(" SQLCOLLATION=\"").Append(sqlCollation).Append("\"");
            }

            if (errorReporting == true)
            {
                strCommandLine.Append(" ERRORREPORTING=1");
            }
            else
            {
                strCommandLine.Append(" ERRORREPORTING=0");
            }

            if (enableRANU == true)
            {
                strCommandLine.Append(" ENABLERANU=1");
            }
            else
            {
                strCommandLine.Append(" ENABLERANU=0");
            }

            if (sqlServiceLicence == true)
            {
                strCommandLine.Append(" IACCEPTSQLSERVERLICENSETERMS=1");
            }
            else
            {
                strCommandLine.Append(" IACCEPTSQLSERVERLICENSETERMS=0");
            }

            return strCommandLine.ToString();
        }

        public int InstallExpress()
        {
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = sqlExpressSetupFileLocation;
            myProcess.StartInfo.Arguments = "/q " + BuildCommandLine();
            /*  /q -- Specifies that setup run with no user interface. */
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.Start();
            return myProcess.Id;
        }

        private static bool IsNullOrEmpty(string str)
        {
            return (str == null) || (str == string.Empty);
        }
    }

}