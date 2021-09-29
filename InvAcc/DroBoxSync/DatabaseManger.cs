using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
//using System.Threading.Tasks;
namespace ShamelSynch
{
    public class DatabaseManager
    {
        public bool IsConnected { get; private set; }
        private ServerConnection _connection;
        public void Connect(string userName, string password, string serverName, bool useInteratedLogin)
        {
            if (useInteratedLogin)
            {
                var sqlCon = new SqlConnection(string.Format("Data Source={0}; Integrated Security=True; Connection Timeout=5", serverName));
                _connection = new ServerConnection(sqlCon);
                _connection.Connect();
                IsConnected = true;
            }
            else
            {
                _connection = new ServerConnection(serverName, userName, password);
                _connection.ConnectTimeout = 5000;
                _connection.Connect();
                IsConnected = true;
            }
        }
        public ServerConnection Createcon(string userName, string password, string serverName, bool useInteratedLogin)
        {
            ServerConnection connection;
            if (useInteratedLogin)
            {
                var sqlCon = new SqlConnection(string.Format("Data Source={0}; Integrated Security=True; Connection Timeout=5", serverName));
                connection = new ServerConnection(sqlCon);


            }
            else
            {
                connection = new ServerConnection(serverName, userName, password);
                connection.ConnectTimeout = 5000;


            }
            return connection;
        }
        public void Connect2(string con)
        {
            {
                _connection = new ServerConnection(con);
                _connection.ConnectTimeout = 5000;
                _connection.Connect();
                IsConnected = true;
            }
        }
        public void BackupDatabase(string databaseName, string destinationPath)
        {
            var sqlServer = new Server(_connection);
            databaseName = databaseName.Replace("[", string.Empty).Replace("]", string.Empty);
            var sqlBackup = new Backup
            {
                Action = BackupActionType.Database,
                BackupSetDescription = "ArchiveDataBase:" + DateTime.Now.ToShortDateString(),
                BackupSetName = "Archive",
                Database = databaseName
            };
            var deviceItem = new BackupDeviceItem(destinationPath, DeviceType.File);

            sqlBackup.Initialize = true;
            sqlBackup.Checksum = false;
            sqlBackup.ContinueAfterError = true;

            sqlBackup.Devices.Add(deviceItem);
            sqlBackup.Incremental = false;
            sqlBackup.ExpirationDate = DateTime.Now.AddDays(3);

            sqlBackup.LogTruncation = BackupTruncateLogType.Truncate;
            sqlBackup.PercentCompleteNotification = 10;
            //sqlBackup.PercentComplete += (sender, e) => OnSqlBackupPercentComplete(e.Percent, e.Message);
            //sqlBackup.Complete += (sender, e) => OnSqlBackupComplete(e.Error);
            sqlBackup.FormatMedia = false;
            sqlBackup.SqlBackup(sqlServer);
        }
        public DatabaseCollection GetDatabasesList()
        {
            if (IsConnected)
            {
                var sqlServer = new Server(_connection);
                return sqlServer.Databases;
            }
            return null;
        }
        public void RestoreDatabase(string serverName, string databaseName, string filePath, string con2)
        {
            string rcom = @"-- use this command to get the logical names for the restore 
-- so you can specify a new location using MOVE
RESTORE FILELISTONLY FROM DISK='" + filePath + @"'
RESTORE DATABASE " + databaseName + @" FROM DISK= '" + filePath + @"' WITH 
MOVE 'AdventureWorks_Data'  to 'C:\AdventureWorks_Data.mdf',
MOVE 'AdventureWorks_Log'   to 'C:\AdventureWorks_Log.ldf' , 
NORECOVERY
".Replace("AdventureWorks", databaseName);
            SqlConnection con = new SqlConnection(con2);
            SqlCommand cmd = new SqlCommand(rcom, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static Server Getdatabases(string serverName)
        {
            ServerConnection conn = new ServerConnection();
            conn.ServerInstance = serverName;
            Server srv = new Server(conn);
            conn.Disconnect();
            return srv;
        }

        public void restore(string con, string dbna, string path)
        {

            Server server = new Server(_connection);
            Restore destination = new Restore();
            destination.Action = RestoreActionType.Database;
            destination.Database = dbna;
            BackupDeviceItem source = new BackupDeviceItem(path, DeviceType.File);
            destination.Devices.Add(source);
            destination.ReplaceDatabase = true;
            destination.SqlRestore(server);
        }
        public void Rename(string oldname, string newname)
        {
            Server srv = new Server(_connection);
            Database db = srv.Databases[oldname];
            srv.KillAllProcesses(db.Name);
            srv.Databases[0].Rename(newname);
            db.SetOnline();
            srv.Refresh();
            db.DatabaseOptions.UserAccess = DatabaseUserAccess.Multiple;


        }
        public void RestoreDatabase(string databaseName, string filePath)
        {
            var sqlServer = new Server(_connection);
            databaseName = databaseName.Replace("[", string.Empty).Replace("]", string.Empty);
            var sqlRestore = new Restore();
            sqlRestore.PercentCompleteNotification = 10;
            //sqlRestore.PercentComplete += (sender, e) => OnSqlRestorePercentComplete(e.Percent, e.Message);
            //sqlRestore.Complete += (sender, e) => OnSqlRestoreComplete(e.Error);
            var deviceItem = new BackupDeviceItem(filePath, DeviceType.File);
            sqlRestore.Devices.Add(deviceItem);
            sqlRestore.Database = databaseName;

            DataTable dtFileList = sqlRestore.ReadFileList(sqlServer);
            int lastIndexOf = dtFileList.Rows[1][1].ToString().LastIndexOf(@"\");
            string physicalName = dtFileList.Rows[1][1].ToString().Substring(0, lastIndexOf + 1);
            string dbLogicalName = dtFileList.Rows[0][0].ToString();
            string dbPhysicalName = physicalName + databaseName + ".mdf";
            string logLogicalName = dtFileList.Rows[1][0].ToString();
            string logPhysicalName = physicalName + databaseName + "_log.ldf";
            sqlRestore.RelocateFiles.Add(new RelocateFile(dbLogicalName, dbPhysicalName));
            sqlRestore.RelocateFiles.Add(new RelocateFile(logLogicalName, logPhysicalName));
            sqlServer.KillAllProcesses(sqlRestore.Database);
            Database db = sqlServer.Databases[databaseName];
            if (db != null)
            {
                db.DatabaseOptions.UserAccess = DatabaseUserAccess.Single;
                db.Alter(TerminationClause.RollbackTransactionsImmediately);
                sqlServer.DetachDatabase(sqlRestore.Database, false);
            }
            try
            {
                sqlRestore.Action = RestoreActionType.Database;
                sqlRestore.NoRecovery = false;
                sqlRestore.ReplaceDatabase = true;

                sqlRestore.SqlRestore(sqlServer);
                //     Database db = sqlServer.Databases[databaseName];
                db = sqlServer.Databases[databaseName];
                db.SetOnline();
                sqlServer.Refresh();
                db.DatabaseOptions.UserAccess = DatabaseUserAccess.Multiple;
            }
            catch (SqlException ex) { MessageBox.Show(ex.Message); }
        }
        public void Disconnect()
        {
            if (IsConnected)
                _connection.Disconnect();
            IsConnected = false;
        }
        List<string> dblist;
        public void testwithcreate(string ddb, string cont)
        {
            string script = @"USE[master]
 CREATE DATABASE[DB_temp] ON PRIMARY
 (NAME = N'DB_temp', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.PROSOFT\MSSQL\DATA\DB_temp.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON
(NAME = N'DB_temp_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.PROSOFT\MSSQL\DATA\DB_temp_log.LDF' , SIZE = 768KB , MAXSIZE = 2048GB , FILEGROWTH = 10 %)
;
IF(1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
 begin
 EXEC[DB_temp].[dbo].[sp_fulltext_database] @action = 'enable'
end
;
ALTER DATABASE[DB_temp] SET ANSI_NULL_DEFAULT OFF
;
ALTER DATABASE[DB_temp] SET ANSI_NULLS OFF
;
ALTER DATABASE[DB_temp] SET ANSI_PADDING OFF
;
ALTER DATABASE[DB_temp] SET ANSI_WARNINGS OFF
;
ALTER DATABASE[DB_temp] SET ARITHABORT OFF
;
ALTER DATABASE[DB_temp] SET AUTO_CLOSE ON
;
ALTER DATABASE[DB_temp] SET AUTO_SHRINK OFF
;
ALTER DATABASE[DB_temp] SET AUTO_UPDATE_STATISTICS ON
;
ALTER DATABASE[DB_temp] SET CURSOR_CLOSE_ON_COMMIT OFF
;
ALTER DATABASE[DB_temp] SET CURSOR_DEFAULT  GLOBAL
;
ALTER DATABASE[DB_temp] SET CONCAT_NULL_YIELDS_NULL OFF
;
ALTER DATABASE[DB_temp] SET NUMERIC_ROUNDABORT OFF
;
ALTER DATABASE[DB_temp] SET QUOTED_IDENTIFIER OFF
;
ALTER DATABASE[DB_temp] SET RECURSIVE_TRIGGERS OFF
;
ALTER DATABASE[DB_temp] SET DISABLE_BROKER
;
ALTER DATABASE[DB_temp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
;
ALTER DATABASE[DB_temp] SET DATE_CORRELATION_OPTIMIZATION OFF
;
ALTER DATABASE[DB_temp] SET TRUSTWORTHY OFF
;
ALTER DATABASE[DB_temp] SET ALLOW_SNAPSHOT_ISOLATION OFF
;
ALTER DATABASE[DB_temp] SET PARAMETERIZATION SIMPLE
;
ALTER DATABASE[DB_temp] SET READ_COMMITTED_SNAPSHOT OFF
;
ALTER DATABASE[DB_temp] SET HONOR_BROKER_PRIORITY OFF
;
ALTER DATABASE[DB_temp] SET RECOVERY SIMPLE
;
ALTER DATABASE[DB_temp] SET  MULTI_USER
;
ALTER DATABASE[DB_temp] SET PAGE_VERIFY CHECKSUM
;
ALTER DATABASE[DB_temp] SET DB_CHAINING OFF
;
ALTER DATABASE[DB_temp] SET READ_WRITE
;";
            try
            {
                Server srv = new Server(_connection);
                if (dblist == null || dblist.Count == 0)
                {
                    dblist = new List<string>();
                    foreach (Database s in srv.Databases)
                    {
                        dblist.Add(s.Name);
                    }
                }
                if (!dblist.Contains(ddb))
                {
                    SqlConnection con = new SqlConnection(cont.Replace(ddb, "master"));
                    script = script.Replace("DB_temp", ddb);
                    con.Open();
                    SqlCommand cm = new SqlCommand(script, con);
                    cm.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch { MessageBox.Show("يجب اولا فتح الفرع في البرو سوفت "); }
        }
    }
}
