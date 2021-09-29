using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc
{
    public class ReportOnline
    {
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private int LangArEn = 0;
        private string _Path = string.Empty;
        private string _PathServer = string.Empty;
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private Stock_DataDataContext dbInstance_Web;
        private Rate_DataDataContext dbInstanceRate_Web;
        private List<string> _DBNo = new List<string>();
        private string _oldDBNo = VarGeneral.DBNo;
        private Stock_DataDataContext db
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
        private Rate_DataDataContext dbc
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
        private Stock_DataDataContext db_Web
        {
            get
            {
                if (dbInstance_Web == null)
                {
                    dbInstance_Web = new Stock_DataDataContext("Server=PROSOFT.dyndns.org,1433;Database=" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber + "_" + VarGeneral._ActivaionNo + ";UID=sa;PWD=Prosoft@prosoft&ma89");
                }
                return dbInstance_Web;
            }
        }
        private Rate_DataDataContext dbc_Web
        {
            get
            {
                if (dbInstanceRate_Web == null)
                {
                    dbInstanceRate_Web = new Rate_DataDataContext("Server=PROSOFT.dyndns.org,1433;Database=" + VarGeneral.DBNo + "_" + VarGeneral._ActivaionNo + ";UID=sa;PWD=Prosoft@prosoft&ma89");
                }
                return dbInstanceRate_Web;
            }
        }
        private void CheckDataBaseName()
        {
            Rate_DataDataContext _DBWeb = new Rate_DataDataContext("Server=PROSOFT.dyndns.org,1433;Database=;UID=sa;PWD=Prosoft@prosoft&ma89");
            try
            {
                try
                {
                    _DBWeb.ExecuteCommand("ALTER DATABASE " + VarGeneral.DBNo + "_" + VarGeneral._ActivaionNo + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE;\r\n                                                DROP DATABASE [" + VarGeneral.DBNo + "_" + VarGeneral._ActivaionNo + "]");
                }
                catch
                {
                }
                _DBWeb.ExecuteCommand("CREATE DATABASE " + VarGeneral.DBNo + "_" + VarGeneral._ActivaionNo);
                try
                {
                    _DBWeb.ExecuteCommand(" USE master\r\n                                                          ALTER DATABASE " + VarGeneral.DBNo + "_" + VarGeneral._ActivaionNo + " SET SINGLE_USER;\r\n                                                          ALTER DATABASE " + VarGeneral.DBNo + "_" + VarGeneral._ActivaionNo + " COLLATE Arabic_CI_AS;\r\n                                                          ALTER DATABASE " + VarGeneral.DBNo + "_" + VarGeneral._ActivaionNo + " SET MULTI_USER;");
                }
                catch
                {
                }
            }
            catch
            {
            }
            List<T_Branch> vBranchCount = dbc.FillBranch_2(string.Empty).ToList();
            for (int i = 0; i < vBranchCount.Count; i++)
            {
                try
                {
                    try
                    {
                        _DBWeb.ExecuteCommand("ALTER DATABASE " + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + vBranchCount[i].Branch_no + "_" + VarGeneral._ActivaionNo + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE;\r\n                                                       DROP DATABASE [" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + vBranchCount[i].Branch_no + "_" + VarGeneral._ActivaionNo + "]");
                    }
                    catch
                    {
                    }
                    _DBWeb.ExecuteCommand("CREATE DATABASE " + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + vBranchCount[i].Branch_no + "_" + VarGeneral._ActivaionNo);
                    try
                    {
                        _DBWeb.ExecuteCommand(" USE master\r\n                                                          ALTER DATABASE " + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + vBranchCount[i].Branch_no + "_" + VarGeneral._ActivaionNo + " SET SINGLE_USER;\r\n                                                          ALTER DATABASE " + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + vBranchCount[i].Branch_no + "_" + VarGeneral._ActivaionNo + " COLLATE Arabic_CI_AS;\r\n                                                          ALTER DATABASE " + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + vBranchCount[i].Branch_no + "_" + VarGeneral._ActivaionNo + " SET MULTI_USER;");
                    }
                    catch
                    {
                    }
                }
                catch
                {
                }
            }
        }
        public void DBBackup(bool vMsg)
        {
            try
            {
                if (VarGeneral.vEndYears)
                {
                    return;
                }
                using (NetworkShareAccesser.Access("PROSOFT.dyndns.org", "PROSOFT-PC", "PROSOFT", "Prosoft@prosoft&ma89"))
                {
                    _Path = Application.StartupPath + "\\ReportOnline_" + VarGeneral._ActivaionNo;
                    _PathServer = "\\PROSOFT.dyndns.org\\backuponline_Customer\\ReportOnline_" + VarGeneral._ActivaionNo;
                    string BackupPath = string.Empty;
                    try
                    {
                        if (Directory.Exists(_PathServer + "_Done"))
                        {
                            try
                            {
                                Directory.Delete(_PathServer + "_Done", recursive: true);
                            }
                            catch
                            {
                                MessageBox.Show("يتم الان عملية مزامنة سابقة .. يرجى الانتظار قليلا ثم المحاولة مرة اخرى");
                                return;
                            }
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        if (!Directory.Exists(_Path))
                        {
                            Directory.CreateDirectory(_Path);
                        }
                        else
                        {
                            Directory.Delete(_Path, recursive: true);
                            Directory.CreateDirectory(_Path);
                        }
                    }
                    catch (Exception error3)
                    {
                        VarGeneral.DebLog.writeLog("Local Create Path: ", error3, enable: true);
                    }
                    try
                    {
                        if (!Directory.Exists(_PathServer))
                        {
                            Directory.CreateDirectory(_PathServer);
                        }
                        else
                        {
                            Directory.Delete(_PathServer, recursive: true);
                            Directory.CreateDirectory(_PathServer);
                        }
                    }
                    catch (Exception error3)
                    {
                        VarGeneral.DebLog.writeLog("Server Create Path: ", error3, enable: true);
                    }
                    using (Rate_DataDataContext _db = new Rate_DataDataContext("Server=" + VarGeneral.gServerName + ";Database=;UID=" + VarGeneral.UsrName + ";PWD=" + VarGeneral.UsrPass))
                    {
                        _DBNo = _db.ExecuteQuery<string>("select name From master..sysdatabases Where name like 'DBPROSOFT_%' and name not like '%_Endsyr_%' order by name ", new object[0]).ToList();
                    }
                    _oldDBNo = VarGeneral.DBNo;
                    for (int i = 0; i < _DBNo.Count; i++)
                    {
                        try
                        {
                            VarGeneral.DBNo = _DBNo[i];
                            BackupPath = _Path;
                            string text = BackupPath;
                            BackupPath = text + "\\" + VarGeneral.DBNo + "_" + VarGeneral._ActivaionNo + ".bak";
                            string CmdText = " BACKUP DATABASE " + VarGeneral.DBNo + " TO DISK='{0}' WITH NOFORMAT, NOINIT, NAME = N'MyDB-FullBackup, SKIP, NOREWIND, NOUNLOAD, STATS = 10'";
                            CmdText = string.Format(CmdText, BackupPath);
                            db.ExecuteCommand(CmdText);
                            SSSBackup(BackupPath);
                            File.Copy(BackupPath, _PathServer + "\\" + VarGeneral.DBNo + "_" + VarGeneral._ActivaionNo + ".bak");
                        }
                        catch (Exception error3)
                        {
                            VarGeneral.DebLog.writeLog("db.ExecuteCommand(CmdText) " + i + " : ", error3, enable: true);
                        }
                    }
                }
            }
            catch (Exception error3)
            {
                VarGeneral.DebLog.writeLog("ButBackUp_Click:", error3, enable: true);
            }
            VarGeneral.DBNo = _oldDBNo;
            Directory.Delete(_Path, recursive: true);
            try
            {
                Directory.Move(_PathServer, _PathServer + "_Done");
            }
            catch
            {
                Directory.Delete(_PathServer, recursive: true);
            }
        }
        private void SSSBackup(string vPaths)
        {
            try
            {
                List<T_Branch> vBranchCount = dbc.FillBranch_2(string.Empty).ToList();
                for (int i = 0; i < vBranchCount.Count; i++)
                {
                    try
                    {
                        string CmdText = " BACKUP DATABASE " + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + vBranchCount[i].Branch_no + " TO DISK='{0}' WITH NOFORMAT, NOINIT, NAME = N'MyDB-FullBackup, SKIP, NOREWIND, NOUNLOAD, STATS = 10'";
                        CmdText = string.Format(CmdText, vPaths);
                        db.ExecuteCommand(CmdText);
                    }
                    catch (Exception error2)
                    {
                        VarGeneral.DebLog.writeLog("SSSBackup " + i + " : ", error2, enable: true);
                    }
                }
            }
            catch (Exception error2)
            {
                VarGeneral.DebLog.writeLog("SSSBackup:", error2, enable: true);
            }
        }
        private void RestoreProcess()
        {
            int vID = 0;
            string vMDF_File = string.Empty;
            string vLDB_File = string.Empty;
            string vLogicalName = string.Empty;
            string vLogicalNameLog = string.Empty;
            string filename = string.Empty;
            DirectoryInfo d = new DirectoryInfo(_Path);
            FileInfo[] files = d.GetFiles("*.bak");
            foreach (FileInfo file in files)
            {
                if (!file.Name.StartsWith(VarGeneral.DBNo))
                {
                    continue;
                }
                filename = _PathServer.Replace("\\PROSOFT.dyndns.org\\", "D:\\") + "\\" + file.Name;
                if (string.IsNullOrEmpty(filename))
                {
                    break;
                }
                try
                {
                    List<int> vRec1 = db_Web.ExecuteQuery<int>("SELECT database_id FROM sys.databases WHERE name='" + VarGeneral.DBNo + "_" + VarGeneral._ActivaionNo + "'", new object[0]).ToList();
                    if (vRec1.Count <= 0)
                    {
                        return;
                    }
                    vID = vRec1.First();
                    if (vID > 0)
                    {
                        List<string> vRecPath = db_Web.ExecuteQuery<string>("SELECT physical_name FROM sys.master_files WHERE type = 0 and database_id=" + vID, new object[0]).ToList();
                        if (vRecPath.Count > 0)
                        {
                            vMDF_File = vRecPath.First().ToString();
                        }
                        vRecPath = db_Web.ExecuteQuery<string>("SELECT physical_name FROM sys.master_files WHERE type = 1 and database_id=" + vID, new object[0]).ToList();
                        if (vRecPath.Count > 0)
                        {
                            vLDB_File = vRecPath.First().ToString();
                        }
                    }
                    string vFile1 = filename;
                    List<string> vRecPath2 = db_Web.ExecuteQuery<string>("RESTORE FILELISTONLY FROM DISK = '" + vFile1 + "'", new object[0]).ToList();
                    if (vRecPath2.Count > 0)
                    {
                        vLogicalName = vRecPath2[0];
                        vLogicalNameLog = vRecPath2[1];
                    }
                    string vWITH = string.Empty;
                    vWITH = " Move '" + vLogicalName + "' TO '" + vMDF_File + "',Move '" + vLogicalNameLog + "' TO '" + vLDB_File + "'";
                    vWITH += ",REPLACE";
                    db_Web.ExecuteCommand("USE [master] ALTER DATABASE [" + VarGeneral.DBNo + "_" + VarGeneral._ActivaionNo + "] SET SINGLE_USER WITH Rollback IMMEDIATE RESTORE DATABASE [" + VarGeneral.DBNo + "_" + VarGeneral._ActivaionNo + "] FROM DISK = '" + vFile1 + "' WITH FILE = 1 , " + vWITH + " ALTER DATABASE [" + VarGeneral.DBNo + "_" + VarGeneral._ActivaionNo + "] SET MULTI_USER");
                    int _Loop = 0;
                    List<T_Branch> vBranchCount = new List<T_Branch>();
                    while (true)
                    {
                        try
                        {
                            if (_Loop <= 1)
                            {
                                vBranchCount = dbc_Web.FillBranch_2(string.Empty).ToList();
                            }
                        }
                        catch
                        {
                            _Loop++;
                            continue;
                        }
                        break;
                    }
                    for (int i = 0; i < vBranchCount.Count; i++)
                    {
                        try
                        {
                            List<int> vRec2 = db_Web.ExecuteQuery<int>("SELECT database_id FROM sys.databases WHERE name='" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + vBranchCount[i].Branch_no + "_" + VarGeneral._ActivaionNo + "'", new object[0]).ToList();
                            if (vRec2.Count <= 0)
                            {
                                return;
                            }
                            vID = vRec2.First();
                            if (vID > 0)
                            {
                                List<string> vRecPath = db_Web.ExecuteQuery<string>("SELECT physical_name FROM sys.master_files WHERE type = 0 and database_id=" + vID, new object[0]).ToList();
                                if (vRecPath.Count > 0)
                                {
                                    vMDF_File = vRecPath.First().ToString();
                                }
                                vRecPath = db_Web.ExecuteQuery<string>("SELECT physical_name FROM sys.master_files WHERE type = 1 and database_id=" + vID, new object[0]).ToList();
                                if (vRecPath.Count > 0)
                                {
                                    vLDB_File = vRecPath.First().ToString();
                                }
                            }
                            vFile1 = filename;
                            vRecPath2 = db_Web.ExecuteQuery<string>("RESTORE FILELISTONLY FROM DISK = '" + vFile1 + "'", new object[0]).ToList();
                            if (vRecPath2.Count > 0)
                            {
                                vLogicalName = vRecPath2[0].Replace("DBPROSOFT", "PROSOFT") + "_" + vBranchCount[i].Branch_no;
                                vLogicalNameLog = vRecPath2[1].Replace("_log", string.Empty).Replace("DBPROSOFT", "PROSOFT") + "_" + vBranchCount[i].Branch_no + "_log";
                            }
                            vWITH = string.Empty;
                            vWITH = " Move '" + vLogicalName + "' TO '" + vMDF_File + "',Move '" + vLogicalNameLog + "' TO '" + vLDB_File + "'";
                            vWITH += ",REPLACE";
                            db_Web.ExecuteCommand("USE [master] ALTER DATABASE [" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + vBranchCount[i].Branch_no + "_" + VarGeneral._ActivaionNo + "] SET SINGLE_USER WITH Rollback IMMEDIATE RESTORE DATABASE [" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + vBranchCount[i].Branch_no + "_" + VarGeneral._ActivaionNo + "] FROM DISK = '" + vFile1 + "' WITH FILE = " + (i + 2) + "," + vWITH + " ALTER DATABASE [" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + vBranchCount[i].Branch_no + "_" + VarGeneral._ActivaionNo + "] SET MULTI_USER");
                            continue;
                        }
                        catch
                        {
                        }
                    }
                    continue;
                }
                catch (Exception error)
                {
                    VarGeneral.DebLog.writeLog("buttonItem_Restore_Click:", error, enable: true);
                    return;
                }
            }
        }
    }
}
