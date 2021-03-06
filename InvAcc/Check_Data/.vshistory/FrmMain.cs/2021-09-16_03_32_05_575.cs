// Decompiled with JetBrains decompiler
// Type: Check_Data.Forms.FrmMain
// Assembly: Check_Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 36F786BA-8BF1-463D-BDEC-46FF9F01EBC1
// Assembly location: C:\Program Files (x86)\PROSOFT\InvAccc\Check_Data.dll
using Check_Data.Forms;
using InvAcc.DBUdate;
using InvAcc.GeneralM;
//using InvAcc.Stock_Data;
using InvAcc.Stock_Data;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
//using System.ServiceProcess;
using System.ServiceProcess;
using System.Text.RegularExpressions;
using System.Windows.Forms;
public class FrmMain : Form
{
    private Stock_DataDataContext dbInstance;
    private Rate_DataDataContext dbInstanceRate;
    private Stock_DataDataContext vConn = new Stock_DataDataContext();
    private Rate_DataDataContext vConnDB = new Rate_DataDataContext();
    private string vBrNoNew = "";
    private IContainer components = (IContainer)null;
    private Button button1;
    private Label label1;
    private Stock_DataDataContext db
    {
        get
        {
            if (this.dbInstance == null)
                this.dbInstance = new Stock_DataDataContext(VarGeneral.BranchCS);
            return this.dbInstance;
        }
    }
    private Rate_DataDataContext dbRate
    {
        get
        {

            if (this.dbInstanceRate == null)
                this.dbInstanceRate = new Rate_DataDataContext(VarGeneral.BranchRt);
            return this.dbInstanceRate;
        }
    }

    public FrmMain(
  Stock_DataDataContext conn,
  Rate_DataDataContext connDB,
  string BrNoNew,
  int _onlyCheckCol)
    {
        this.InitializeComponent();//
        if (_onlyCheckCol == 1)
        {
            try
            {
               
                FrmMain.CheckUpdate_Col(this.db);
            }
            catch
            {
            }
        }
        else
        {
            this.vConn = conn;
            this.vConnDB = connDB;
            this.vBrNoNew = BrNoNew;
            VarGeneral.ReadConnectionSettings();
            this.CheckDB();
            VarGeneral.ProdectNam = "?????????????? ?????????????????? - PROSOFT";

            if (conn == null && connDB == null)
                this.CheckData_item();
            else if (conn != null)
                this.CreateNewBranch(conn, BrNoNew);
            else
                this.CreateNewDataBase(connDB, BrNoNew);
            this.dbInstance = (Stock_DataDataContext)null;
            FrmMain.CheckUpdate_ADMINCol(this.dbRate);
            FrmMain.CheckUpdate_Col(this.db);
            try
            {
                if (VarGeneral.vEndYears)
                    this.db.ExecuteCommand("ALTER DATABASE [" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber + "] SET READ_ONLY ");
            }
            catch
            {
            }
        }



    }
    public void CheckDB()
    {
        try
        {
            int startIndex;
            for (startIndex = 0; startIndex < VarGeneral.gServerName.Length; ++startIndex)
            {
                if (VarGeneral.gServerName.Substring(startIndex, 1) == "\\")
                    break;
            }
            string str;
            try
            {
                str = VarGeneral.gServerName.Substring(startIndex + 1);
            }
            catch
            {
                str = "";
            }
            ServiceController serviceController = new ServiceController("MSSQL$" + str);
            try
            {
                serviceController.Status.ToString();
            }
            catch
            {
                return;
            }
            if (!(serviceController.Status.Equals((object)ServiceControllerStatus.Stopped) | serviceController.Status.Equals((object)ServiceControllerStatus.StopPending)))
                return;
            try
            {
                serviceController.Start();
                serviceController.WaitForStatus(ServiceControllerStatus.Running);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in starting the service: " + ex.Message);
            }
        }
        catch
        {
        }


    }
    public void exe(string s, SqlConnection Connection)
    {
        string script = s;

        // split script on GO command
        IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);

        Connection.Open();
        foreach (string commandString in commandStrings)
        {
            if (!string.IsNullOrWhiteSpace(commandString.Trim()))
            {
                using (var command = new SqlCommand(commandString, Connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        Connection.Close();
    }
    private void CheckData_item()
    {
        try
        {

            if (VarGeneral.vEndYears)
                return;
            this.dbInstanceRate = (Rate_DataDataContext)null;
            Exception exception;
            if (string.IsNullOrEmpty(VarGeneral.DBNo))
            {
                VarGeneral.DBNo = "";
                List<string> stringList = new List<string>();
                using (Rate_DataDataContext rateDataDataContext = new Rate_DataDataContext("Server=" + VarGeneral.gServerName + ";Database=;UID=" + VarGeneral.UsrName + ";PWD=" + VarGeneral.Qut2 + VarGeneral.UsrPass + VarGeneral.Qut2))
                {
                    List<string> list = rateDataDataContext.ExecuteQuery<string>("select name From master..sysdatabases Where name like 'DBPROSOFT_%' and name not like '%_Endsyr_%' order by name ").ToList<string>();
                    if (list.Count > 0)
                    {
                        if (list.Count == 1)
                        {
                            VarGeneral.DBNo = list.First<string>();
                            this.dbInstanceRate = (Rate_DataDataContext)null;
                            this.CheckData_item();
                        }
                        else
                        {
                            VarGeneral.brNm = "";
                            int num = (int)new FrmBranch(list).ShowDialog();
                            VarGeneral.DBNo = VarGeneral.brNm;
                            this.dbInstanceRate = (Rate_DataDataContext)null;
                            this.CheckData_item();
                        }
                    }
                    else
                    {
                        VarGeneral.DBNo = "DBPROSOFT_default";
                        try
                        {
                            rateDataDataContext.ExecuteCommand("CREATE DATABASE " + VarGeneral.DBNo);
                            try
                            {
                                rateDataDataContext.ExecuteCommand(" USE master\r\n                                                          ALTER DATABASE " + VarGeneral.DBNo + " SET SINGLE_USER;\r\n                                                          ALTER DATABASE " + VarGeneral.DBNo + " COLLATE Arabic_CI_AS;\r\n                                                          ALTER DATABASE " + VarGeneral.DBNo + " SET MULTI_USER;");
                            }
                            catch
                            {
                            }
                        }
                        catch (Exception ex)
                        {
                            int num = (int)MessageBox.Show("?????? ?????????? ?????????? ?????????? ????????????????! .", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            try
                            {
                                rateDataDataContext.ExecuteCommand("ALTER DATABASE " + VarGeneral.DBNo + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE;\r\n                                                        DROP DATABASE [" + VarGeneral.DBNo + "]");
                            }
                            catch
                            {
                            }
                            VarGeneral.DebLog.writeLog("CheckData_item Rate:", ex, true);
                            Environment.Exit(0);
                            return;
                        }
                        try
                        {
                            rateDataDataContext.ExecuteCommand(InvAcc.Properties.Resources.ScriptTbRates.Replace("DBPROSOFT", VarGeneral.DBNo).Replace("GO", "").Replace("PathRate1", Application.StartupPath + "\\DBPROSOFT.mdf").Replace("PathRate2", Application.StartupPath + "\\DBPROSOFT_log.ldf"));
                          
                        }
                        catch (Exception ex)
                        {
                            exception = ex;
                            //int num = (int)MessageBox.Show("?????? ?????????? ???????????????????? ?????????? ????????????????! .", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            try
                            {
                                rateDataDataContext.ExecuteCommand("ALTER DATABASE " + VarGeneral.DBNo + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE;\r\n                                                       DROP DATABASE [" + VarGeneral.DBNo + "]");
                            }
                            catch
                            {
                            }
                            Environment.Exit(0);
                            return;
                        }
                    }
                }
            }
            if (!this.db.DatabaseExists())
            {
                List<string> source = new List<string>();
                using (Stock_DataDataContext stockDataDataContext = new Stock_DataDataContext("Server=" + VarGeneral.gServerName + ";Database=;UID=" + VarGeneral.UsrName + ";PWD=" + VarGeneral.Qut + VarGeneral.UsrPass + VarGeneral.Qut))
                    source = stockDataDataContext.ExecuteQuery<string>("select name From master..sysdatabases Where name like '" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_%' order by name ").ToList<string>();
                if (source.Count > 0)
                {
                    VarGeneral.BranchNumber = source.First<string>().Trim().Substring(VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT").Length + 1);
                    this.dbInstance = (Stock_DataDataContext)null;
                    this.CheckData_item();
                }
                else
                {
                    VarGeneral.BranchNumber = "1";
                    using (Stock_DataDataContext stockDataDataContext = new Stock_DataDataContext("Server=" + VarGeneral.gServerName + ";Database=;UID=" + VarGeneral.UsrName + ";PWD=" + VarGeneral.Qut + VarGeneral.UsrPass + VarGeneral.Qut))
                    {
                        try
                        {
                            string str = stockDataDataContext.ExecuteQuery<string>("SELECT SUBSTRING(physical_name, 1, CHARINDEX(N'master.mdf', LOWER(physical_name)) - 1) FROM master.sys.master_files WHERE database_id = 1 AND file_id = 1").ToList<string>().First<string>().ToString();
                            if (!string.IsNullOrEmpty(str))
                            {
                                File.Delete(str + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber + ".mdf");
                                File.Delete(str + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber + "_log.ldf");
                            }
                        }
                        catch
                        {
                        }
                        try
                        {
                            stockDataDataContext.ExecuteCommand("CREATE DATABASE " + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber);
                            try
                            {
                                stockDataDataContext.ExecuteCommand(" USE master\r\n                                                          ALTER DATABASE " + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber + " SET SINGLE_USER;\r\n                                                          ALTER DATABASE " + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber + " COLLATE Arabic_CI_AS;\r\n                                                          ALTER DATABASE " + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber + " SET MULTI_USER;");
                            }
                            catch
                            {
                            }
                        }
                        catch (Exception ex)
                        {
                            int num = (int)MessageBox.Show("?????? ?????????? ?????????? ?????????? ?????????????? - ??????????????????! .", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            try
                            {
                                stockDataDataContext.ExecuteCommand("ALTER DATABASE " + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE;\r\n                                                        DROP DATABASE [" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber + "]");
                            }
                            catch
                            {
                            }
                            VarGeneral.DebLog.writeLog("CheckData_item:", ex, true);
                            Environment.Exit(0);
                            return;
                        }
                        try
                        {


                            string script2 = (InvAcc.Properties.Resources.DbScript.Replace("PROSOFT", VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber).Replace("Path1", Application.StartupPath + "\\PROSOFT.mdf").Replace("Path2", Application.StartupPath + "\\PROSOFT_log.ldf"));
                            string sqlConnectionString = "Server=" + VarGeneral.gServerName + ";Database=;UID=" + VarGeneral.UsrName + ";PWD=" + VarGeneral.Qut + VarGeneral.UsrPass + VarGeneral.Qut;


                            using (SqlConnection connection = new SqlConnection((sqlConnectionString)))
                            {
                                Server server = new Server(new ServerConnection(connection));
                                server.ConnectionContext.ExecuteNonQuery(script2);
                            }

                        }
                        catch (Exception ex)
                        {
                            exception = ex;
                            int num = (int)MessageBox.Show("?????? ?????????? ?????????? ???????????? ?????????? ?????????????? - ?????????????????? ! .", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            try
                            {
                                stockDataDataContext.ExecuteCommand("ALTER DATABASE " + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE;\r\n                                                       DROP DATABASE [" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber + "]");
                            }
                            catch
                            {
                            }
                            Environment.Exit(0);

                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            VarGeneral.DebLog.writeLog("CheckData_item:", ex, true);
            int num = (int)new FrmPathSetting().ShowDialog();
            FrmMain frmMain = new FrmMain(this.vConn, this.vConnDB, this.vBrNoNew, 0);
        }
    }
    public static int restoredefaultValues(Stock_DataDataContext dbs)
    {
        try
        {
            string script2 = (InvAcc.Properties.Resources.DbScript.Replace("PROSOFT", VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber).Replace("Path1", Application.StartupPath + "\\PROSOFT.mdf").Replace("Path2", Application.StartupPath + "\\PROSOFT_log.ldf"));
            string sqlConnectionString = "Server=" + VarGeneral.gServerName + ";Database=;UID=" + VarGeneral.UsrName + ";PWD=" + VarGeneral.Qut + VarGeneral.UsrPass + VarGeneral.Qut;

            string s1 = @"
EXEC sp_msforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT all'
EXEC sp_msforeachtable 'DELETE ?'";
            using (SqlConnection connection = new SqlConnection((sqlConnectionString)))
            {
                Server server = new Server(new ServerConnection(connection));
                server.ConnectionContext.ExecuteNonQuery(s1);
                server.ConnectionContext.ExecuteNonQuery(script2);
            }
            CheckUpdate_Col(dbs);
            FrmMain.ing(dbs);
            checkdkd(dbs);

            VarGeneral.complete = true;
            return 1;

        }
        catch (Exception ex)
        {
            VarGeneral.DebLog.writeLog("Restore Default DB  Data And Setting:", ex, true);

        }
        return 0;


    }
    private void CreateNewBranch(Stock_DataDataContext dbc, string vBr)
    {
        dbc.ExecuteCommand("CREATE DATABASE " + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + vBr);
        try
        {
            dbc.ExecuteCommand(" USE master\r\n                                      ALTER DATABASE " + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + vBr + " SET SINGLE_USER;\r\n                                      ALTER DATABASE " + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + vBr + " COLLATE Arabic_CI_AS;\r\n                                      ALTER DATABASE " + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + vBr + " SET MULTI_USER;");
        }
        catch
        {
        }
        string script2 = (InvAcc.Properties.Resources.ScriptTb.Replace("PROSOFT", VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + vBr).Replace("Path1", Application.StartupPath + "\\PROSOFT.mdf").Replace("Path2", Application.StartupPath + "\\PROSOFT_log.ldf"));
        string sqlConnectionString = "Server=" + VarGeneral.gServerName + ";Database=;UID=" + VarGeneral.UsrName + ";PWD=" + VarGeneral.Qut + VarGeneral.UsrPass + VarGeneral.Qut;


        using (SqlConnection connection = new SqlConnection((sqlConnectionString)))
        {
            Server server = new Server(new ServerConnection(connection));
            server.ConnectionContext.ExecuteNonQuery(script2);
        }

        using (Stock_DataDataContext db = new Stock_DataDataContext("Server=" + VarGeneral.gServerName + ";Database=" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + vBr + ";UID=" + VarGeneral.UsrName + ";PWD=" + VarGeneral.Qut + VarGeneral.UsrPass + VarGeneral.Qut))
         
        FrmMain.CheckUpdate_Col(db);
    }
    private void CreateNewDataBase(Rate_DataDataContext dbc, string vBr)
    {
        dbc.ExecuteCommand("CREATE DATABASE DBPROSOFT_" + vBr);
        try
        {
            dbc.ExecuteCommand(" USE master\r\n                                      ALTER DATABASE DBPROSOFT_" + vBr + " SET SINGLE_USER;\r\n                                      ALTER DATABASE DBPROSOFT_" + vBr + " COLLATE Arabic_CI_AS;\r\n                                      ALTER DATABASE DBPROSOFT_" + vBr + " SET MULTI_USER;");
        }
        catch
        {
        }
        dbc.ExecuteCommand(InvAcc.Properties.Resources.ScriptTbRates.Replace("DBPROSOFT", "DBPROSOFT_" + vBr).Replace("GO", "").Replace("PathRate1", Application.StartupPath + "\\DBPROSOFT.mdf").Replace("PathRate2", Application.StartupPath + "\\DBPROSOFT_log.ldf"));
        using (Stock_DataDataContext stockDataDataContext = new Stock_DataDataContext("Server=" + VarGeneral.gServerName + ";Database=;UID=" + VarGeneral.UsrName + ";PWD=" + VarGeneral.Qut + VarGeneral.UsrPass + VarGeneral.Qut))
        {
            try
            {
                stockDataDataContext.ExecuteCommand("CREATE DATABASE PROSOFT_" + vBr + "_1");
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("?????? ?????????? ?????????? ?????????? ?????????????? - ??????????????????! .", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                try
                {
                    stockDataDataContext.ExecuteCommand("ALTER DATABASE PROSOFT_" + vBr + "_1 SET SINGLE_USER WITH ROLLBACK IMMEDIATE;\r\n                                                        DROP DATABASE [ PROSOFT_" + vBr + "_1]");
                }
                catch
                {
                }
                VarGeneral.DebLog.writeLog("CheckData_item:", ex, true);
                Environment.Exit(0);
                return;
            }
            try
            {
                dbc.ExecuteCommand(" USE master\r\n                                      ALTER DATABASE PROSOFT_" + vBr + "_1 SET SINGLE_USER;\r\n                                      ALTER DATABASE PROSOFT_" + vBr + "_1 COLLATE Arabic_CI_AS;\r\n                                      ALTER DATABASE PROSOFT_" + vBr + "_1 SET MULTI_USER;");
            }
            catch
            {
            }
            try
            {
                stockDataDataContext.ExecuteCommand(InvAcc.Properties.Resources.ScriptTb.Replace("PROSOFT", "PROSOFT_" + vBr + "_1").Replace("GO", "").Replace("Path1", Application.StartupPath + "\\PROSOFT.mdf").Replace("Path2", Application.StartupPath + "\\PROSOFT_log.ldf"));
                File.WriteAllText(Application.StartupPath + "\\newdb.tx", "dfs");


            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                int num = (int)MessageBox.Show("?????? ?????????? ?????????? ???????????? ?????????? ?????????????? - ?????????????????? ! .", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                try
                {
                    try
                    {
                        stockDataDataContext.ExecuteCommand("ALTER DATABASE PROSOFT_" + vBr + "_1 SET SINGLE_USER WITH ROLLBACK IMMEDIATE;\r\n                                                        DROP DATABASE [ PROSOFT_" + vBr + "_1]");
                    }
                    catch
                    {
                    }
                }
                catch
                {
                }
                Environment.Exit(0);
            }
        }
    }
    public static void CheckUpdate_ADMINCol(Rate_DataDataContext dbc)
    {
        try
        {
            dbc.ExecuteCommand("select Eqar_FilStr from [T_Users] ");
        }
        catch
        {
            try
            {
                dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [Emp_FilStr] [varchar](100) NULL");
                dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [Emp_MovStr] [varchar](100) NULL");
                dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [Emp_SalStr] [varchar](100) NULL");
                dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [Emp_RepStr] [varchar](100) NULL");
                dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [Emp_GenStr] [varchar](100) NULL");
            }
            catch
            {
            }
            try
            {
                dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [CreateGaid] [int] NULL");
                dbc.ExecuteCommand("Update [dbo].[T_Users] Set [CreateGaid] = 0 ");
            }
            catch
            {
            }
            try
            {
                dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [UserPointTyp] [int] NULL");
                dbc.ExecuteCommand("Update [dbo].[T_Users] Set [UserPointTyp] = 0 ");
            }
            catch
            {
            }
            try
            {
                dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [CashAccNo_D] varchar(30) NULL");
                dbc.ExecuteCommand("Update [dbo].[T_Users] Set [CashAccNo_D] = '' ");
            }
            catch
            {
            }
            try
            {
                dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [CashAccNo_C] varchar(30) NULL");
                dbc.ExecuteCommand("Update [dbo].[T_Users] Set [CashAccNo_C] = '' ");
            }
            catch
            {
            }
            try
            {
                dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [NetworkAccNo_D] varchar(30) NULL");
                dbc.ExecuteCommand("Update [dbo].[T_Users] Set [NetworkAccNo_D] = '' ");
            }
            catch
            {
            }
            try
            {
                dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [NetworkAccNo_C] varchar(30) NULL");
                dbc.ExecuteCommand("Update [dbo].[T_Users] Set [NetworkAccNo_C] = '' ");
            }
            catch
            {
            }
            try
            {
                dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [CreaditAccNo_D] varchar(30) NULL");
                dbc.ExecuteCommand("Update [dbo].[T_Users] Set [CreaditAccNo_D] = '' ");
            }
            catch
            {
            }
            try
            {
                dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [CreaditAccNo_C] varchar(30) NULL");
                dbc.ExecuteCommand("Update [dbo].[T_Users] Set [CreaditAccNo_C] = '' ");
            }
            catch
            {
            }
            try
            {
                dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [CashAccNo_D_R] varchar(30) NULL");
                dbc.ExecuteCommand("Update [dbo].[T_Users] Set [CashAccNo_D_R] = '' ");
            }
            catch
            {
            }
            try
            {
                dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [CashAccNo_C_R] varchar(30) NULL");
                dbc.ExecuteCommand("Update [dbo].[T_Users] Set [CashAccNo_C_R] = '' ");
            }
            catch
            {
            }
            try
            {
                dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [NetworkAccNo_D_R] varchar(30) NULL");
                dbc.ExecuteCommand("Update [dbo].[T_Users] Set [NetworkAccNo_D_R] = '' ");
            }
            catch
            {
            }
            try
            {
                dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [NetworkAccNo_C_R] varchar(30) NULL");
                dbc.ExecuteCommand("Update [dbo].[T_Users] Set [NetworkAccNo_C_R] = '' ");
            }
            catch
            {
            }
            try
            {
                dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [CreaditAccNo_D_R] varchar(30) NULL");
                dbc.ExecuteCommand("Update [dbo].[T_Users] Set [CreaditAccNo_D_R] = '' ");
            }
            catch
            {
            }
            try
            {
                dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [CreaditAccNo_C_R] varchar(30) NULL");
                dbc.ExecuteCommand("Update [dbo].[T_Users] Set [CreaditAccNo_C_R] = '' ");
            }
            catch
            {
            }
            try
            {
                dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [Comm_Inv] [float] NULL");
                dbc.ExecuteCommand("Update [dbo].[T_Users] Set [Comm_Inv] = 0 where Comm_Inv = '' or Comm_Inv is null ");
            }
            catch
            {
            }
            try
            {
                dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [Comm_Gaid] [float] NULL");
                dbc.ExecuteCommand("Update [dbo].[T_Users] Set [Comm_Gaid] = 0 where Comm_Gaid = '' or Comm_Gaid is null ");
            }
            catch
            {
            }
            try
            {
                dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [PeaperTyp] [varchar](150) NULL");
                dbc.ExecuteCommand("Update [dbo].[T_Users] Set [PeaperTyp] = '0000000000000' ");
            }
            catch
            {
            }
            try
            {
                dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [StorePrmission] [varchar](250) NULL");
                dbc.ExecuteCommand("Update [dbo].[T_Users] Set [StorePrmission] = '' ");
            }
            catch
            {
            }
            try
            {
                dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [DefStores] [int] NULL");
                dbc.ExecuteCommand("Update [dbo].[T_Users] Set [DefStores] = 0 ");
                try
                {
                    File.Delete(Application.StartupPath + "\\InvCreateInsert.sql");
                    File.Delete(Application.StartupPath + "\\InvCreateUpdate.sql");
                }
                catch
                {
                }
            }
            catch
            {
            }
            try
            {
                dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [StopBanner] [varchar](50) NULL");
                dbc.ExecuteCommand("Update [dbo].[T_Users] Set [StopBanner] = '00' ");
                dbc.ExecuteCommand("Update [dbo].[T_Users] Set [InvStr] = InvStr + '1111111111111'");
            }
            catch
            {
            }
            try
            {
                dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [UsrImg] [varbinary](max) NULL");
            }
            catch
            {
            }
            try
            {
                dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [MaxDiscountSals] [float] NULL");
                dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [MaxDiscountPurchaes] [float] NULL");
                dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [vColumnStr1] [varchar](250) NULL");
                dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [vColumnStr2] [varchar](250) NULL");
                dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [vColumnStr3] [varchar](250) NULL");
                dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [vColumnStr4] [varchar](250) NULL");
                dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [vColumnNum1] [float] NULL");
                dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [vColumnNum2] [int] NULL");
                dbc.ExecuteCommand("Update [dbo].[T_Users] Set [MaxDiscountSals] = 0 ");
                dbc.ExecuteCommand("Update [dbo].[T_Users] Set [MaxDiscountPurchaes] = 0 ");
                dbc.ExecuteCommand("Update [dbo].[T_Users] Set [vColumnStr1] = '' ");
                dbc.ExecuteCommand("Update [dbo].[T_Users] Set [vColumnStr2] = '' ");
                dbc.ExecuteCommand("Update [dbo].[T_Users] Set [vColumnStr3] = '' ");
                dbc.ExecuteCommand("Update [dbo].[T_Users] Set [vColumnStr4] = '' ");
                dbc.ExecuteCommand("Update [dbo].[T_Users] Set [vColumnNum1] = 0 ");
                dbc.ExecuteCommand("Update [dbo].[T_Users] Set [vColumnNum2] = 0 ");
            }
            catch
            {
            }
        }
        try
        {
            dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [Eqar_FilStr] [varchar](100) NULL");
            dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [Eqar_TenantStr] [varchar](100) NULL");
            dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [Eqar_RepStr] [varchar](100) NULL");
            dbc.ExecuteCommand("ALTER TABLE T_Users ADD  [Eqar_GenStr] [varchar](100) NULL");
        }
        catch
        {
        }
        try
        {
            dbc.ExecuteCommand("Update [dbo].[T_Users] Set [FilStr] = '11111111111111111111111111111111111111111111111111111111',[InvStr] = '1111111111111111111111111111111111111111111111111111111111111111111111',[SndStr] = '1111111111111111111111111111111111111111', [StkRep] = '111111111111111111111111111111', [AccRep] = '11111111111111',[SetStr] = '1111111111111111111111111111111111111111111110110111', [Emp_GenStr] = '1111111111111',[Emp_FilStr] = '1111111111111111111111111111111111111111111111111111',[Emp_MovStr] = '111111111111111111111111111111111111111111111111', [Emp_RepStr] = '11111111111111111111111', [Emp_SalStr] = '1111111111', [Eqar_FilStr] = '1111111111111111111111111111',[Eqar_TenantStr] = '1111111111111111', [Eqar_RepStr] = '111111', [Eqar_GenStr] = '1',[RepInv1] = '1', [RepAcc1] = '1111111111111111', [RepAcc2] = '1111111111111111111111111111', [RepAcc3] = '111111111111', [RepAcc4] = '111111111111111', [RepAcc5] = (case when [RepAcc5] = '' then '0' else [RepAcc5] end), [RepAcc6] = (case when  [RepAcc6] = '' then '0' else  [RepAcc6] end) Where Usr_ID = '2' OR UsrNo = 2");
        }
        catch
        {
        }
        try
        {
            dbc.ExecuteCommand("Update [dbo].[T_Users] Set[FilStr] = '11111111111111111111111111111111111111111111111111111111',[InvStr] = '1111111111111111111111111111111111111111111111111111111111111111111111',[SndStr] = '1111111111111111111111111111111111111111', [StkRep] = '111111111111111111111111111111', [AccRep] = '11111111111111',[SetStr] = '1111111111111111111111111111111111111111111110110111',[PassQty] = '1111111110001', [Emp_GenStr] = '1111111111111',[Emp_FilStr] = '1111111111111111111111111111111111111111111111111111',[Emp_MovStr] = '111111111111111111111111111111111111111111111111', [Emp_RepStr] = '11111111111111111111111', [Emp_SalStr] = '1111111111', [Eqar_FilStr] = '1111111111111111111111111111',[Eqar_TenantStr] = '1111111111111111', [Eqar_RepStr] = '111111', [Eqar_GenStr] = '1',[Pass] = 'flm8ZAF33tWSzGqBtqx+7z3fzGlwHHymse1vRjXS93smXO4DliC+wNFW5VWj9v7o',[RepInv1] = '1', [RepAcc1] = '1111111111111111', [RepAcc2] = '1111111111111111111111111111', [RepAcc3] = '111111111111', [RepAcc4] = '111111111111111', [RepAcc5] = (case when [RepAcc5] = '' then '0' else [RepAcc5] end), [RepAcc6] = (case when  [RepAcc6] = '' then '0' else  [RepAcc6] end) Where Usr_ID = '1' OR UsrNo = 1");
        }
        catch
        {
        }
        try
        {
            dbc.ExecuteCommand("Update [dbo].[T_Users] Set [RepInv1] = '0' where (RepInv1 = '' or RepInv1 is null) and (Usr_ID <> '2' OR UsrNo <> 2 OR Usr_ID <> '2' OR UsrNo <> 2) ");
        }
        catch
        {
        }
        try
        {
            dbc.ExecuteCommand("Update [dbo].[T_Users] Set [RepInv2] = '0' where (RepInv2 = '' or RepInv2 is null) ");
        }
        catch
        {
        }
        try
        {
            dbc.ExecuteCommand("Update [dbo].[T_Users] Set [RepInv3] = '0' where (RepInv3 = '' or RepInv3 is null) ");
        }
        catch
        {
        }
        try
        {
            dbc.ExecuteCommand("Update [dbo].[T_Users] Set [RepInv4] = '0' where (RepInv4 = '' or RepInv4 is null) ");
        }
        catch
        {
        }
        try
        {
            dbc.ExecuteCommand("Update [dbo].[T_Users] Set [RepInv6] = '0' where (RepInv6 = '' or RepInv6 is null) ");
        }
        catch
        {
        }
        try
        {
            dbc.ExecuteCommand("Update [dbo].[T_Users] Set [RepAcc5] = '0' where (RepAcc5 = '' or RepAcc5 is null) ");
        }
        catch
        {
        }
        try
        {
            dbc.ExecuteCommand("Update [dbo].[T_Users] Set [RepAcc6] = '0' where (RepAcc6 = '' or RepAcc6 is null) ");
        }
        catch
        {
        }
        try
        {
            int num;
            switch (VarGeneral.SSSTyp)
            {
                case 0:
                    dbc.ExecuteCommand("Update [dbo].[T_Users] Set CashAccNo_C = '3021001'  Where Usr_ID <> 1 and Usr_ID <> 2 ");
                    dbc.ExecuteCommand("Update [dbo].[T_Users] Set CashAccNo_D = '1020001'  Where Usr_ID <> 1 and Usr_ID <> 2 ");
                    dbc.ExecuteCommand("Update [dbo].[T_Users] Set NetworkAccNo_C = '3021005'  Where Usr_ID <> 1 and Usr_ID <> 2 ");
                    dbc.ExecuteCommand("Update [dbo].[T_Users] Set NetworkAccNo_D = '***'  Where Usr_ID <> 1 and Usr_ID <> 2 ");
                    dbc.ExecuteCommand("Update [dbo].[T_Users] Set CreaditAccNo_C = '3021005'  Where Usr_ID <> 1 and Usr_ID <> 2 ");
                    dbc.ExecuteCommand("Update [dbo].[T_Users] Set CreaditAccNo_D = '***'  Where Usr_ID <> 1 and Usr_ID <> 2 ");
                    if (!(VarGeneral.SSSLev == "M"))
                        return;
                    dbc.ExecuteCommand("Update [dbo].[T_Users] Set CreateGaid = 0,UserPointTyp = 0 ,CashAccNo_C = '',CashAccNo_D = '' ,NetworkAccNo_C = '',NetworkAccNo_D = '',CreaditAccNo_C = '',CreaditAccNo_D = ''");
                    return;
                case 1:
                    num = 0;
                    break;
                default:
                    num = !(VarGeneral.SSSLev == "E") ? 1 : 0;
                    break;
            }
            if (num != 0)
                return;
            dbc.ExecuteCommand("Update [dbo].[T_Users] Set CreateGaid = 0,UserPointTyp = 0 ,CashAccNo_C = '',CashAccNo_D = '' ,NetworkAccNo_C = '',NetworkAccNo_D = '',CreaditAccNo_C = '',CreaditAccNo_D = ''");
        }
        catch
        {
        }
    }
    public static void checkdkd(Stock_DataDataContext db)
    {
        SqlConnection con = new SqlConnection(db.Connection.ConnectionString + InvAcc.Properties.Settings.Default.pscomp);
        ServerConnection c = new ServerConnection(con);
        Server ser = new Server(c);
        foreach (string s in DbUpdates.scripts)
        {
            try
            {
                if (s.Contains("T_Colors"))
                { }
                db.ExecuteCommand(s);
            }

            catch
            {
                try
                {
                    ser.ConnectionContext.ExecuteNonQuery(s);
                }
                catch
                { }
            }
        }
        try
        {
            db.ExecuteCommand("update T_Items set T_Items.OpenQty = 0 where T_Items.Itm_No not in (select itmNo from T_STKSQTY) and T_Items.OpenQty > 0");
        }
        catch
        {
        }
        try
        {
            db.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
        }
        catch { }
        try
        {
            db.ExecuteCommand(DbUpdates.addscolor);
        }
        catch { }
        try
        {
            if (db.T_INVSETTINGs.Where(i => i.InvNamE == "SaveOverBill").Count() == 0)
            { db.ExecuteCommand(DbUpdates.draftbillup); }
        }
        catch { }
        try
        {
            DbUpdates.updateusersettings();

            { db.ExecuteCommand(DbUpdates.alterusersettings.Replace("GO", "")); }

        }
        catch
        {

        }
        try
        {
            try
            {
                db.ExecuteCommand(DbUpdates.CreatePrinterSettingsTable);
                db.ExecuteCommand("ALTER TABLE dbo.T_Printers ADD    InvTypA4 varchar(50) NULL");
                Rate_DataDataContext dra = new Rate_DataDataContext(VarGeneral.BranchRt);
                foreach (T_User d in dra.T_Users)
                {
                    VarGeneral.UserID = d.Usr_ID;
                    DbUpdates.copysetting();

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
    public static void CheckUpdate_Col(Stock_DataDataContext db)
    {
        tb_version tfv = db.stockdbversion();
        if (tfv.dbv == null)
        {
            try
            {
                db.ExecuteCommand(@"CREATE TABLE [dbo].[tb_version](
    [id][int] IDENTITY(1, 1) NOT NULL,

    [dbv][varchar](max) NULL,

    [lastupdate][datetime] NULL
) ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]
");
                db.ExecuteCommand("insert into tb_version (dbv) values ('0') ;");
            }
            catch
            { }
            tfv = db.stockdbversion();
        }
        try
        {
            tfv.dbv = tfv.dbv.Replace("Versiong0000", "0").Replace("Versiong0001", "1").Replace("Versiong0002", "2").Replace("Versiong0003", "3").Replace("Versiong0004", "4");
            int K = int.Parse(tfv.dbv);
        }
        catch { tfv.dbv = "0"; }
        int ver = int.Parse(tfv.dbv.ToString());
        if (ver < 5)
        {

            DbUpdates.executes("ALTER LOGIN sa ENABLE ;ALTER LOGIN sa WITH PASSWORD = 'Prosoft@prosoft&ma89';", VarGeneral.BranchCS);

            try
            {
                db.ExecuteCommand("update tb_version set dbv='5'");
            }
            catch
            {
                try
                {
                    db.ExecuteCommand(@"CREATE TABLE [dbo].[tb_version](
    [id][int] IDENTITY(1, 1) NOT NULL,

    [dbv][varchar](max) NULL,

    [lastupdate][datetime] NULL
) ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]
");
                    db.ExecuteCommand("insert into tb_version (dbv) values ('0') ;");
                }
                catch
                { }
            }

            try
            {
                int i;
                T_AccDef q;
#pragma warning disable CS0168 // The variable 'c' is declared but never used
                T_AccDef c;
#pragma warning restore CS0168 // The variable 'c' is declared but never used
#pragma warning disable CS0168 // The variable 'num' is declared but never used
                int num;
#pragma warning restore CS0168 // The variable 'num' is declared but never used
#pragma warning disable CS0168 // The variable 'Value' is declared but never used
                int Value;
#pragma warning restore CS0168 // The variable 'Value' is declared but never used
#pragma warning disable CS0168 // The variable '_AccDefBind' is declared but never used
                T_AccDef _AccDefBind;
#pragma warning restore CS0168 // The variable '_AccDefBind' is declared but never used
#pragma warning disable CS0168 // The variable 'qa' is declared but never used
                List<T_AccDef> qa;
#pragma warning restore CS0168 // The variable 'qa' is declared but never used
#pragma warning disable CS0168 // The variable 'AccBox' is declared but never used
                string AccBox;
#pragma warning restore CS0168 // The variable 'AccBox' is declared but never used
#pragma warning disable CS0168 // The variable 'x' is declared but never used
                T_AccDef x;
#pragma warning restore CS0168 // The variable 'x' is declared but never used
#pragma warning disable CS0168 // The variable 't' is declared but never used
                T_AccDef t;
#pragma warning restore CS0168 // The variable 't' is declared but never used
#pragma warning disable CS0168 // The variable 'qc' is declared but never used
                List<T_CATEGORY> qc;
#pragma warning restore CS0168 // The variable 'qc' is declared but never used
#pragma warning disable CS0168 // The variable 'max' is declared but never used
                int max;
#pragma warning restore CS0168 // The variable 'max' is declared but never used
                string[] serialKey;
                object[] gdheadID;
#pragma warning disable CS0168 // The variable 'flag' is declared but never used
                bool flag;
#pragma warning restore CS0168 // The variable 'flag' is declared but never used
                try
                {
                    if (!VarGeneral.vEndYears)
                    {
                        List<string> newDb = db.ExecuteQuery<string>("  SELECT DB_NAME(database_id) AS DatabaseName\r\n                                                                        FROM sys.master_files AS mf\r\n                                                                        Where DB_NAME(database_id) like '%_Endsyr_%'", new object[0]).ToList<string>();
                        for (i = 0; i < newDb.Count; i++)
                        {
                            try
                            {
                                db.ExecuteCommand(string.Concat("DROP DATABASE [", newDb[i], "]"), new object[0]);
                            }
                            catch
                            {
                            }
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccCredit0 = '***'  Where AccCredit0 = '' or AccCredit0 is null", new object[0]);
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccDebit0 = '***'  Where AccDebit0 = '' or AccDebit0 is null", new object[0]);
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccCredit1 = '***'  Where AccCredit1 = '' or AccCredit1 is null", new object[0]);
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccDebit1 = '***'  Where AccDebit1 = '' or AccDebit1 is null", new object[0]);
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccCredit2 = '***'  Where AccCredit2 = '' or AccCredit2 is null", new object[0]);
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccDebit2 = '***'  Where AccDebit2 = '' or AccDebit2 is null", new object[0]);
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccCredit3 = '3021001'  Where InvID = 1 ", new object[0]);
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccDebit3 = '1020001'  Where InvID = 1 ", new object[0]);
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccCredit4 = '3021005'  Where InvID = 1 ", new object[0]);
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccDebit4 = '***'  Where InvID = 1 ", new object[0]);
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccCredit3 = '1020001'  Where InvID = 2 ", new object[0]);
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccDebit3 = '3041001'  Where InvID = 2 ", new object[0]);
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccCredit4 = '***'  Where InvID = 2 ", new object[0]);
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccDebit4 = '3041005'  Where InvID = 2 ", new object[0]);
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccCredit3 = '1020001'  Where InvID = 3 ", new object[0]);
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccDebit3 = '3021002'  Where InvID = 3 ", new object[0]);
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccCredit4 = '***'  Where InvID = 3 ", new object[0]);
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccDebit4 = '3021006'  Where InvID = 3 ", new object[0]);
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccCredit3 = '3041002'  Where InvID = 4 ", new object[0]);
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccDebit3 = '1020001'  Where InvID = 4 ", new object[0]);
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccCredit4 = '3041006'  Where InvID = 4", new object[0]);
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccDebit4 = '***'  Where InvID = 4 ", new object[0]);
                }
                catch
                {
                }
                if (VarGeneral.SSSTyp == 0)
                {
                    try
                    {
                        q = db.StockAccDef("1020001");
                        if ((q == null ? true : string.IsNullOrEmpty(q.AccDef_No)))
                        {
                            try
                            {
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'102', N'?????????????????? ?????????????????? ??????????????', N'Current Assets', N'1', 2, N'', 1, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)", new object[0]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'1020', N'?????????????? ??????????????', N'Box', N'102', 3, N'', 2, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)", new object[0]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'1020001', N'?????????????? ???????????? ??????????????', N'Box', N'1020', 4, N'', 2, 0, 0, 0, 0, 0, 3, N'', N'', N'', N'', N'', N'', 0, N'', 0, N'', N'', 0, NULL, NULL, NULL, NULL, 1)", new object[0]);
                            }
                            catch
                            {
                            }
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        T_AccDef q2 = db.StockAccDef("3021001");
                        if ((q2 == null ? true : string.IsNullOrEmpty(q2.AccDef_No)))
                        {
                            try
                            {
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'302', N'???????? ????????????????', N'Net sales', N'3', 2, N'', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)", new object[0]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'3021', N'???????? ???????????????? ??????????????', N'Net cash sales', N'302', 3, N'', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)", new object[0]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'3021001', N'???????????????? ?????????????? ??????????????', N'Cash sales', N'3021', 4, N'4', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)", new object[0]);
                            }
                            catch
                            {
                            }
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        T_AccDef q3 = db.StockAccDef("3021005");
                        if ((q3 == null ? true : string.IsNullOrEmpty(q3.AccDef_No)))
                        {
                            try
                            {
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'302', N'???????? ????????????????', N'Net sales', N'3', 2, N'', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)", new object[0]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'3021', N'???????? ???????????????? ??????????????', N'Net cash sales', N'302', 3, N'', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)", new object[0]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'3021005', N'???????????????? ???????????? ??????????????', N'Sales futures', N'3021', 4, N'4', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)", new object[0]);
                            }
                            catch
                            {
                            }
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        T_AccDef q4 = db.StockAccDef("3041001");
                        if ((q4 == null ? true : string.IsNullOrEmpty(q4.AccDef_No)))
                        {
                            try
                            {
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'304', N'???????? ??????????????????', N'Net purchases', N'3', 2, N'', 7, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)", new object[0]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'3041', N'???????? ?????????????????? ??????????', N'Net cash purchases', N'304', 3, N'', 7, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)", new object[0]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'3041001', N'?????????????????? ?????????????? ??????????????', N'Cash purchases', N'3041', 4, N'4', 7, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)", new object[0]);
                            }
                            catch
                            {
                            }
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        T_AccDef q5 = db.StockAccDef("3041005");
                        if ((q5 == null ? true : string.IsNullOrEmpty(q5.AccDef_No)))
                        {
                            try
                            {
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'304', N'???????? ??????????????????', N'Net purchases', N'3', 2, N'', 7, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)", new object[0]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'3041', N'???????? ?????????????????? ??????????', N'Net cash purchases', N'304', 3, N'', 7, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)", new object[0]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'3041005', N'?????????????????? ???????????? ??????????????', N'Purchases futures', N'3041', 4, N'4', 7, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)", new object[0]);
                            }
                            catch
                            {
                            }
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        T_AccDef q6 = db.StockAccDef("3021002");
                        if ((q6 == null ? true : string.IsNullOrEmpty(q6.AccDef_No)))
                        {
                            try
                            {
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'302', N'???????? ????????????????', N'Net sales', N'3', 2, N'', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)", new object[0]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'3021', N'???????? ???????????????? ??????????????', N'Net cash sales', N'302', 3, N'', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)", new object[0]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'3021002', N'?????????????? ???????????? ?????????? ??????????????', N'Returns cash sales', N'3021', 4, N'4', 7, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)", new object[0]);
                            }
                            catch
                            {
                            }
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        T_AccDef q7 = db.StockAccDef("3021006");
                        if ((q7 == null ? true : string.IsNullOrEmpty(q7.AccDef_No)))
                        {
                            try
                            {
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'302', N'???????? ????????????????', N'Net sales', N'3', 2, N'', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)", new object[0]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'3021', N'???????? ???????????????? ??????????????', N'Net cash sales', N'302', 3, N'', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)", new object[0]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'3021006', N'?????????????? ???????????? ???????????? ??????????????', N'Returns futures sales', N'3021', 4, N'4', 7, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)", new object[0]);
                            }
                            catch
                            {
                            }
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        T_AccDef q8 = db.StockAccDef("3041002");
                        if ((q8 == null ? true : string.IsNullOrEmpty(q8.AccDef_No)))
                        {
                            try
                            {
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'304', N'???????? ??????????????????', N'Net purchases', N'3', 2, N'', 7, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)", new object[0]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'3041', N'???????? ?????????????????? ??????????', N'Net cash purchases', N'304', 3, N'', 7, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)", new object[0]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'3041002', N'?????????????? ?????????????? ?????????? ??????????????', N'Purchases cash returns', N'3041', 4, N'4', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)", new object[0]);
                            }
                            catch
                            {
                            }
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        T_AccDef q9 = db.StockAccDef("3041006");
                        if ((q9 == null ? true : string.IsNullOrEmpty(q9.AccDef_No)))
                        {
                            try
                            {
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'304', N'???????? ??????????????????', N'Net purchases', N'3', 2, N'', 7, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)", new object[0]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'3041', N'???????? ?????????????????? ??????????', N'Net cash purchases', N'304', 3, N'', 7, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)", new object[0]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'3041006', N'?????????????? ?????????????? ???????????? ??????????????', N'Returns purchases futures', N'3041', 4, N'4', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)", new object[0]);
                            }
                            catch
                            {
                            }
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        q = db.StockAccDef("4011001");
                        if ((q == null ? false : !string.IsNullOrEmpty(q.AccDef_No)))
                        {
                            try
                            {
                                db.ExecuteCommand("Update [dbo].[T_AccDef] Set [Arb_Des] = '???????? ???????????????? ??????????????',[Eng_Des] ='Expenses' where AccDef_No = '4011001'", new object[0]);
                            }
                            catch
                            {
                            }
                        }
                        else
                        {
                            try
                            {
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'401', N'?????????????? ???????????? ??????????????', N'General expenses', N'4', 2, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)", new object[0]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'4011', N'???????????????????? ???????????? ??????????????', N'Expenses', N'401', 3, N'', 8, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)", new object[0]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'4011001', N'???????? ???????????????? ??????????????', N'Expenses', N'4011', 4, N'', 8, 0, 0, 0, 0, 0, 3, N'', N'', N'', N'', N'', N'', 0, N'', 0, N'', N'', 0, NULL, NULL, NULL, NULL, 1)", new object[0]);
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
                try
                {
                    string HostName = Environment.MachineName;
                    string UsrName = Environment.UserName;
                    serialKey = new string[] { "ALTER LOGIN [", HostName, "\\", UsrName, "] Disable" };
                    db.ExecuteCommand(string.Concat(serialKey), new object[0]);
                }
                catch
                {
                }
                try
                {
                    List<T_GDHEAD> q1 = (
                        from t3 in db.T_GDHEADs
                        where t3.gdTyp == (int?)13
                        where t3.gdTot.Value <= 0
                        where !t3.gdLok
                        select t3).ToList<T_GDHEAD>();
                    for (i = 0; i < q1.Count; i++)
                    {
                        try
                        {
                            gdheadID = new object[] { "update T_GDHEAD set gdTot = (select abs(MAX(T_GDDET.gdValue)) from  T_GDDET INNER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID where T_GDDET.gdValue < 0  and T_GDHEAD.gdTyp = 13 and T_GDHEAD.gdTot <= 0 and T_GDHEAD.gdhead_ID = ", q1[i].gdhead_ID, ") where T_GDHEAD.gdTyp = 13 and T_GDHEAD.gdTot <= 0 and T_GDHEAD.gdhead_ID = ", q1[i].gdhead_ID };
                            db.ExecuteCommand(string.Concat(gdheadID), new object[0]);
                        }
                        catch
                        {

                        }

                    }
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("update T_Items set Itm_No = RTRIM(LTRIM(Itm_No)) WHERE Itm_No LIKE '% %'", new object[0]);
                }
                catch
                {
                }
            
            }
            catch { }
            try { ing(db); }
            catch { }

            try
            {



                checkdkd(db);
            }
            catch
            {



            }
        }


    }
    public static void ing(Stock_DataDataContext db)
    {
        try
        {
            db.ExecuteCommand("Create function [dbo].[get_date]()\r\n                                    returns VARCHAR(10)\r\n                                    as\r\n                                    begin\r\n                                    DECLARE @GETDATE AS DATETIME = GETDATE()\r\n                                    return  CONVERT(VARCHAR(4),DATEPART(YEAR, @GETDATE)) \r\n                                    + '/'+ CONVERT(VARCHAR(2),DATEPART(MONTH, @GETDATE)) \r\n                                    + '/' + CONVERT(VARCHAR(2),DATEPART(DAY, @GETDATE)) end");
        }
        catch
        {
        }
        try
        {
            db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccCredit0 = '***'  Where AccCredit0 = '' or AccCredit0 is null");
        }
        catch
        {
        }
        try
        {
            db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccCredit0 = '***'  Where AccCredit0 = '' or AccCredit0 is null");
        }
        catch
        {
        }
        try
        {
            db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccCredit0 = '***'  Where AccCredit0 = '' or AccCredit0 is null");
        }
        catch
        {
        }
        try
        {
            db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccDebit0 = '***'  Where AccDebit0 = '' or AccDebit0 is null");
        }
        catch
        {
        }
        try
        {
            db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccCredit1 = '***'  Where AccCredit1 = '' or AccCredit1 is null");
        }
        catch
        {
        }
        try
        {
            db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccDebit1 = '***'  Where AccDebit1 = '' or AccDebit1 is null");
        }
        catch
        {
        }
        try
        {
            db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccCredit2 = '***'  Where AccCredit2 = '' or AccCredit2 is null");
        }
        catch
        {
        }
        try
        {
            db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccDebit2 = '***'  Where AccDebit2 = '' or AccDebit2 is null");
        }
        catch
        {
        }
        try
        {
            db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccCredit3 = '3021001'  Where InvID = 1 ");
            db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccDebit3 = '1020001'  Where InvID = 1 ");
            db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccCredit4 = '3021005'  Where InvID = 1 ");
            db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccDebit4 = '***'  Where InvID = 1 ");
            db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccCredit3 = '1020001'  Where InvID = 2 ");
            db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccDebit3 = '3041001'  Where InvID = 2 ");
            db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccCredit4 = '***'  Where InvID = 2 ");
            db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccDebit4 = '3041005'  Where InvID = 2 ");
            db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccCredit3 = '1020001'  Where InvID = 3 ");
            db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccDebit3 = '3021002'  Where InvID = 3 ");
            db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccCredit4 = '***'  Where InvID = 3 ");
            db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccDebit4 = '3021006'  Where InvID = 3 ");
            db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccCredit3 = '3041002'  Where InvID = 4 ");
            db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccDebit3 = '1020001'  Where InvID = 4 ");
            db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccCredit4 = '3041006'  Where InvID = 4");
            db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set AccDebit4 = '***'  Where InvID = 4 ");
        }
        catch
        {
        }
        //tree
        if (VarGeneral.SSSTyp == 2)
        {
            try
            {
                T_AccDef tAccDef = db.StockAccDef("1020001");
                if (tAccDef == null || string.IsNullOrEmpty(tAccDef.AccDef_No))
                {
                    try
                    {
                        db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'102', N'?????????????????? ?????????????????? ??????????????', N'Current Assets', N'1', 2, N'', 1, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'1020', N'?????????????? ??????????????', N'Box', N'102', 3, N'', 2, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'1020001', N'?????????????? ???????????? ??????????????', N'Box', N'1020', 4, N'', 2, 0, 0, 0, 0, 0, 3, N'', N'', N'', N'', N'', N'', 0, N'', 0, N'', N'', 0, NULL, NULL, NULL, NULL, 1)");
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
            try
            {
                T_AccDef tAccDef = db.StockAccDef("3021001");
                if (tAccDef == null || string.IsNullOrEmpty(tAccDef.AccDef_No))
                {
                    try
                    {
                        db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'302', N'???????? ????????????????', N'Net sales', N'3', 2, N'', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'3021', N'???????? ???????????????? ??????????????', N'Net cash sales', N'302', 3, N'', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'3021001', N'???????????????? ?????????????? ??????????????', N'Cash sales', N'3021', 4, N'4', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)");
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
            try
            {
                T_AccDef tAccDef = db.StockAccDef("3021005");
                if (tAccDef == null || string.IsNullOrEmpty(tAccDef.AccDef_No))
                {
                    try
                    {
                        db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'302', N'???????? ????????????????', N'Net sales', N'3', 2, N'', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'3021', N'???????? ???????????????? ??????????????', N'Net cash sales', N'302', 3, N'', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'3021005', N'???????????????? ???????????? ??????????????', N'Sales futures', N'3021', 4, N'4', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)");
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
            try
            {
                T_AccDef tAccDef = db.StockAccDef("3041001");
                if (tAccDef == null || string.IsNullOrEmpty(tAccDef.AccDef_No))
                {
                    try
                    {
                        db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'304', N'???????? ??????????????????', N'Net purchases', N'3', 2, N'', 7, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'3041', N'???????? ?????????????????? ??????????', N'Net cash purchases', N'304', 3, N'', 7, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'3041001', N'?????????????????? ?????????????? ??????????????', N'Cash purchases', N'3041', 4, N'4', 7, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)");
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
            try
            {
                T_AccDef tAccDef = db.StockAccDef("3041005");
                if (tAccDef == null || string.IsNullOrEmpty(tAccDef.AccDef_No))
                {
                    try
                    {
                        db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'304', N'???????? ??????????????????', N'Net purchases', N'3', 2, N'', 7, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'3041', N'???????? ?????????????????? ??????????', N'Net cash purchases', N'304', 3, N'', 7, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'3041005', N'?????????????????? ???????????? ??????????????', N'Purchases futures', N'3041', 4, N'4', 7, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)");
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
            try
            {
                T_AccDef tAccDef = db.StockAccDef("3021002");
                if (tAccDef == null || string.IsNullOrEmpty(tAccDef.AccDef_No))
                {
                    try
                    {
                        db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'302', N'???????? ????????????????', N'Net sales', N'3', 2, N'', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'3021', N'???????? ???????????????? ??????????????', N'Net cash sales', N'302', 3, N'', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'3021002', N'?????????????? ???????????? ?????????? ??????????????', N'Returns cash sales', N'3021', 4, N'4', 7, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)");
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
            try
            {
                T_AccDef tAccDef = db.StockAccDef("3021006");
                if (tAccDef == null || string.IsNullOrEmpty(tAccDef.AccDef_No))
                {
                    try
                    {
                        db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'302', N'???????? ????????????????', N'Net sales', N'3', 2, N'', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'3021', N'???????? ???????????????? ??????????????', N'Net cash sales', N'302', 3, N'', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'3021006', N'?????????????? ???????????? ???????????? ??????????????', N'Returns futures sales', N'3021', 4, N'4', 7, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)");
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
            try
            {
                T_AccDef tAccDef = db.StockAccDef("3041002");
                if (tAccDef == null || string.IsNullOrEmpty(tAccDef.AccDef_No))
                {
                    try
                    {
                        db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'304', N'???????? ??????????????????', N'Net purchases', N'3', 2, N'', 7, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'3041', N'???????? ?????????????????? ??????????', N'Net cash purchases', N'304', 3, N'', 7, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'3041002', N'?????????????? ?????????????? ?????????? ??????????????', N'Purchases cash returns', N'3041', 4, N'4', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)");
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
            try
            {
                T_AccDef tAccDef = db.StockAccDef("3041006");
                if (tAccDef == null || string.IsNullOrEmpty(tAccDef.AccDef_No))
                {
                    try
                    {
                        db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'304', N'???????? ??????????????????', N'Net purchases', N'3', 2, N'', 7, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'3041', N'???????? ?????????????????? ??????????', N'Net cash purchases', N'304', 3, N'', 7, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'3041006', N'?????????????? ?????????????? ???????????? ??????????????', N'Returns purchases futures', N'3041', 4, N'4', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)");
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
            try
            {
                T_AccDef tAccDef = db.StockAccDef("4011001");
                if (tAccDef == null || string.IsNullOrEmpty(tAccDef.AccDef_No))
                {
                    try
                    {
                        db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'401', N'?????????????? ???????????? ??????????????', N'General expenses', N'4', 2, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'4011', N'???????????????????? ???????????? ??????????????', N'Expenses', N'401', 3, N'', 8, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'4011001', N'???????? ???????????????? ??????????????', N'Expenses', N'4011', 4, N'', 8, 0, 0, 0, 0, 0, 3, N'', N'', N'', N'', N'', N'', 0, N'', 0, N'', N'', 0, NULL, NULL, NULL, NULL, 1)");
                    }
                    catch
                    {
                    }
                }
                else
                {
                    try
                    {
                        db.ExecuteCommand("Update [dbo].[T_AccDef] Set [Arb_Des] = '???????? ???????????????? ??????????????',[Eng_Des] ='Expenses' where AccDef_No = '4011001'");
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }

            {
                try
                {
                    db.ExecuteCommand("sp_rename T_CATERY, T_CATEGORY");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("    SET ANSI_NULLS ON\r\n                                        SET QUOTED_IDENTIFIER ON\r\n                                        SET ANSI_PADDING ON\r\n                                        CREATE TABLE [dbo].[TmpTbl](\r\n\t                                        [ID] [int] IDENTITY(1,1) NOT NULL,\r\n\t                                        [AccNo] [varchar](50) NULL,\r\n\t                                        [AccNm] [varchar](100) NULL,\r\n\t                                        [Num1] [float] NULL,\r\n\t                                        [Num2] [float] NULL,\r\n\t                                        [Num3] [float] NULL,\r\n\t                                        [Num4] [float] NULL,\r\n\t                                        [Num5] [float] NULL,\r\n\t                                        [Num6] [float] NULL,\r\n\t                                        [Num7] [float] NULL,\r\n\t                                        [Num8] [float] NULL,\r\n\t                                        [Num9] [float] NULL,\r\n\t                                        [Num10] [float] NULL,\r\n\t                                        [Num11] [float] NULL,\r\n\t                                        [Num12] [float] NULL,\r\n\t                                        [Num13] [float] NULL,\r\n\t                                        [Num14] [float] NULL,\r\n\t                                        [Str1] [varchar](50) NULL,\r\n\t                                        [Str2] [varchar](50) NULL,\r\n\t                                        [str3] [varchar](100) NULL,\r\n\t                                        [str4] [varchar](50) NULL,\r\n\t                                        [str5] [varchar](50) NULL,\r\n\t                                        [str6] [varchar](100) NULL,\r\n                                         CONSTRAINT [PK_TmpTbl] PRIMARY KEY CLUSTERED \r\n                                        (\r\n\t                                        [ID] ASC\r\n                                        )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                        ) ON [PRIMARY]\r\n\r\n                                        SET ANSI_PADDING OFF");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("SET ANSI_NULLS ON\r\n                                        SET QUOTED_IDENTIFIER ON\r\n                                        SET ANSI_PADDING ON\r\n                                        CREATE TABLE [dbo].[T_EditItemPrice](\r\n\t                                        [ID] [int] IDENTITY(1,1) NOT NULL,\r\n\t                                        [ItmNo] [varchar](50) NOT NULL,\r\n\t                                        [SelPriceNow1] [float] NULL,\r\n\t                                        [SelPriceNew1] [float] NULL,\r\n\t                                        [SelCostNow] [float] NULL,\r\n\t                                        [SelCostNew] [float] NULL,\r\n\t                                        [Legates] [float] NULL,\r\n\t                                        [LegatesNew] [float] NULL,\r\n\t                                        [Distributors] [float] NULL,\r\n\t                                        [DistributorsNew] [float] NULL,\r\n\t                                        [Sentence] [float] NULL,\r\n\t                                        [SentenceNew] [float] NULL,\r\n\t                                        [Sectorial] [float] NULL,\r\n\t                                        [SectorialNew] [float] NULL,\r\n\t                                        [VIP] [float] NULL,\r\n\t                                        [VIPNew] [float] NULL,\r\n\t                                        [SelPriceNow2] [float] NULL,\r\n\t                                        [SelPriceNew2] [float] NULL,\r\n\t                                        [SelPriceNow3] [float] NULL,\r\n\t                                        [SelPriceNew3] [float] NULL,\r\n\t                                        [SelPriceNow4] [float] NULL,\r\n\t                                        [SelPriceNew4] [float] NULL,\r\n\t                                        [SelPriceNow5] [float] NULL,\r\n\t                                        [SelPriceNew5] [float] NULL,\r\n\t                                        [LTim] [varchar](10) NULL,\r\n\t                                        [HDate] [varchar](10) NULL,\r\n\t                                        [GDate] [varchar](10) NULL,\r\n\t                                        [UsrNm] [varchar](50) NULL,\r\n                                         CONSTRAINT [PK_T_EditItemPrice] PRIMARY KEY CLUSTERED \r\n                                        (\r\n\t                                        [ID] ASC\r\n                                        )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                        ) ON [PRIMARY]\r\n                                        SET ANSI_PADDING OFF\r\n                                        ALTER TABLE [dbo].[T_EditItemPrice]  WITH CHECK ADD  CONSTRAINT [FK_T_EditItemPrice_T_Items] FOREIGN KEY([ItmNo])\r\n                                        REFERENCES [dbo].[T_Items] ([Itm_No])\r\n                                        ALTER TABLE [dbo].[T_EditItemPrice] CHECK CONSTRAINT [FK_T_EditItemPrice_T_Items]");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("SET ANSI_NULLS ON\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    SET ANSI_PADDING ON\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_SINVDET]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_SINVDET](\r\n\t                                [SInvDet_ID] [int] IDENTITY(1,1) NOT NULL,\r\n\t                                [SInvNo] [varchar](10) NULL,\r\n\t                                [SInvId] [int] NULL,\r\n\t                                [SInvSer] [int] NULL,\r\n\t                                [SItmNo] [varchar](50) NULL,\r\n\t                                [SCost] [float] NULL,\r\n\t                                [SQty] [float] NULL,\r\n\t                                [SItmDes] [varchar](100) NULL,\r\n\t                                [SItmUnt] [varchar](15) NULL,\r\n\t                                [SItmDesE] [varchar](100) NULL,\r\n\t                                [SItmUntE] [varchar](15) NULL,\r\n\t                                [SItmUntPak] [float] NULL,\r\n\t                                [SStoreNo] [int] NULL,\r\n\t                                [SPrice] [float] NULL,\r\n\t                                [SAmount] [float] NULL,\r\n\t                                [SRealQty] [float] NULL,\r\n\t                                [SitmInvDsc] [float] NULL,\r\n\t                                [SDatExper] [varchar](11) NULL,\r\n\t                                [SItmDis] [float] NULL,\r\n\t                                [SItmTyp] [int] NULL,\r\n\t                                [SItmIndex] [int] NULL,\r\n\t                                [SItmWight] [float] NULL,\r\n\t                                [SItmWight_T] [float] NULL,\r\n                                    [SQtyDef] [float] NULL,\r\n                                    [SPriceDef] [float] NULL,\r\n                                    [SInvIdHEAD] [int] NULL,\r\n                                     CONSTRAINT [PK_T_SINVDET] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [SInvDet_ID] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    END\r\n                                    SET ANSI_PADDING OFF ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_SINVDET_T_INVDET]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_SINVDET]'))\r\n                                    ALTER TABLE [dbo].[T_SINVDET]  WITH CHECK ADD  CONSTRAINT [FK_T_SINVDET_T_INVDET] FOREIGN KEY([SInvId])\r\n                                    REFERENCES [dbo].[T_INVDET] ([InvDet_ID])\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_SINVDET_T_INVDET]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_SINVDET]'))\r\n                                    ALTER TABLE [dbo].[T_SINVDET] CHECK CONSTRAINT [FK_T_SINVDET_T_INVDET]\r\n                                    /****** Object:  ForeignKey [FK_T_SINVDET_T_INVHED]    Script Date: 10/03/2015 03:35:08 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_SINVDET_T_INVHED]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_SINVDET]'))\r\n                                    ALTER TABLE [dbo].[T_SINVDET]  WITH CHECK ADD  CONSTRAINT [FK_T_SINVDET_T_INVHED] FOREIGN KEY([SInvIdHEAD])\r\n                                    REFERENCES [dbo].[T_INVHED] ([InvHed_ID])\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_SINVDET_T_INVHED]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_SINVDET]'))\r\n                                    ALTER TABLE [dbo].[T_SINVDET] CHECK CONSTRAINT [FK_T_SINVDET_T_INVHED]\r\n                                    /****** Object:  ForeignKey [FK_T_SINVDET_T_Items]    Script Date: 10/03/2015 03:35:08 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_SINVDET_T_Items]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_SINVDET]'))\r\n                                    ALTER TABLE [dbo].[T_SINVDET]  WITH CHECK ADD  CONSTRAINT [FK_T_SINVDET_T_Items] FOREIGN KEY([SItmNo])\r\n                                    REFERENCES [dbo].[T_Items] ([Itm_No])\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_SINVDET_T_Items]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_SINVDET]'))\r\n                                    ALTER TABLE [dbo].[T_SINVDET] CHECK CONSTRAINT [FK_T_SINVDET_T_Items]");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("\r\n                                    SET ANSI_NULLS ON\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    SET ANSI_PADDING ON\r\n                                    CREATE TABLE [dbo].[T_BankPeaper](\r\n\t                                    [ID] [int] IDENTITY(1,1) NOT NULL,\r\n\t                                    [PageNo] [varchar](20) NULL,\r\n\t                                    [CustAcc] [varchar](30) NULL,\r\n\t                                    [BankAcc] [varchar](30) NULL,\r\n\t                                    [BranchAcc] [varchar](30) NULL,\r\n\t                                    [PageDate] [varchar](50) NULL,\r\n\t                                    [PageDatePay] [varchar](50) NULL,\r\n\t                                    [Amount] [float] NULL,\r\n\t                                    [PageType] [bit] NULL,\r\n\t                                    [vTyp] [bit] NULL,\r\n\t                                    [PayState] [int] NULL,\r\n\t                                    [gdID] [int] NULL,\r\n\t                                    [IfDel] [int] NULL,\r\n\t                                    [gdTyp] [int] NULL,\r\n\t                                    [gdUser] [varchar](3) NULL,\r\n\t                                    [CompanyID] [int] NULL,\r\n                                     CONSTRAINT [PK_T_BankPeaper] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [ID] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    SET ANSI_PADDING OFF\r\n                                    ALTER TABLE [dbo].[T_BankPeaper]  WITH CHECK ADD  CONSTRAINT [FK_T_BankPeaper_T_AccDef] FOREIGN KEY([CustAcc])\r\n                                    REFERENCES [dbo].[T_AccDef] ([AccDef_No])\r\n                                    ALTER TABLE [dbo].[T_BankPeaper] CHECK CONSTRAINT [FK_T_BankPeaper_T_AccDef]\r\n                                    ALTER TABLE [dbo].[T_BankPeaper]  WITH CHECK ADD  CONSTRAINT [FK_T_BankPeaper_T_AccDef1] FOREIGN KEY([BankAcc])\r\n                                    REFERENCES [dbo].[T_AccDef] ([AccDef_No])\r\n                                    ALTER TABLE [dbo].[T_BankPeaper] CHECK CONSTRAINT [FK_T_BankPeaper_T_AccDef1]\r\n                                    ALTER TABLE [dbo].[T_BankPeaper]  WITH CHECK ADD  CONSTRAINT [FK_T_BankPeaper_T_AccDef2] FOREIGN KEY([BranchAcc])\r\n                                    REFERENCES [dbo].[T_AccDef] ([AccDef_No])\r\n                                    ALTER TABLE [dbo].[T_BankPeaper] CHECK CONSTRAINT [FK_T_BankPeaper_T_AccDef2]\r\n                                    ALTER TABLE [dbo].[T_BankPeaper]  WITH CHECK ADD  CONSTRAINT [FK_T_BankPeaper_T_GDHEAD] FOREIGN KEY([gdID])\r\n                                    REFERENCES [dbo].[T_GDHEAD] ([gdhead_ID])\r\n                                    ALTER TABLE [dbo].[T_BankPeaper] CHECK CONSTRAINT [FK_T_BankPeaper_T_GDHEAD]\r\n                                    ALTER TABLE [dbo].[T_BankPeaper]  WITH CHECK ADD  CONSTRAINT [FK_T_BankPeaper_T_INVSETTING] FOREIGN KEY([gdTyp])\r\n                                    REFERENCES [dbo].[T_INVSETTING] ([InvID])\r\n                                    ALTER TABLE [dbo].[T_BankPeaper] CHECK CONSTRAINT [FK_T_BankPeaper_T_INVSETTING]\r\n                                    ALTER TABLE [dbo].[T_BankPeaper]  WITH CHECK ADD  CONSTRAINT [FK_T_BankPeaper_T_SYSSETTING] FOREIGN KEY([CompanyID])\r\n                                    REFERENCES [dbo].[T_SYSSETTING] ([SYSSETTING_ID])\r\n                                    ALTER TABLE [dbo].[T_BankPeaper] CHECK CONSTRAINT [FK_T_BankPeaper_T_SYSSETTING]");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_Items ADD  [FirstCost] [float] NULL");
                    db.ExecuteCommand("ALTER TABLE [dbo].[T_Items] ADD  CONSTRAINT [DF_T_Items_FirstCost]  DEFAULT ((0)) FOR [FirstCost]");
                    db.ExecuteCommand("Update [dbo].[T_Items] Set [FirstCost] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_GDHEAD] Set [salMonth] = '' Where [salMonth] is null ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [IsBackground] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [IsBackground] = 1 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [IsNotBackground] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [IsNotBackground] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [BackgroundPic] [varbinary] (max) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [defSizePaper_Setting] [varchar](100) NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [defSizePaper_Setting] = '' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [Orientation_Setting] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [Orientation_Setting] = 1 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVSETTING ADD  [defSizePaper] [varchar](100) NULL");
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [defSizePaper] = '' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVSETTING ADD [Orientation] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [Orientation] = 1 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [IsBackground] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [IsBackground] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [IsNotBackground] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [IsNotBackground] = 1 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [BackgroundPic] [varbinary] (max) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [Sponer] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [Sponer] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [IsAlarmVisaGoBack] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [IsAlarmVisaGoBack] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [IsAlarmVisaIntro] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [IsAlarmVisaIntro] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [AlarmVisaGoBack] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [AlarmVisaGoBack] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [AlarmVisaIntro] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [AlarmVisaIntro] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [IsAlarmDepts] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [IsAlarmDepts] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [AlarmDeptsBefore] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [AlarmDeptsBefore] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [AutoChangSalStatus] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [AutoChangSalStatus] = 1 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [AccUsrNo] [int] NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [BackPath] [varchar](max) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [DocumentPath] [varchar](max) NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [DocumentPath] = '' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [ImportFilePath] [varchar](max) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [ImportIp] [varchar](20) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [ImportEmpNo] [varchar](5) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [ImportDate] [varchar](5) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [ImportTime1] [varchar](5) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [ImportTimeLeave1] [varchar](5) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [ImportStart] [varchar](5) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [ImportEnd] [varchar](5) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [AccPath] [varchar](max) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [ServerNm] [varchar](50) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [DataBaseNm] [varchar](50) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [Sa_Pass] [varchar](30) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [Path_Kind] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [Path_Kind] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [AlarmDoc] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [AlarmDoc] = 1 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [AlarmDocBefore] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [AlarmDocBefore] = 1 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [AutoLeave] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [AutoLeave] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [EmpLeaveAfter] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [EmpLeaveAfter] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [AttendanceManually] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [AttendanceManually] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [VacationManually] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [VacationManually] = 1 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [CalculateNo] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [CalculateNo] = 2 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [CalculatliquidNo] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [CalculatliquidNo] = 2 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [Allowances] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [Allowances] = 12 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [AllowancesTime] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [AllowancesTime] = 1 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [ShowBanner] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [ShowBanner] = 1 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [ShowPageNo] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [ShowPageNo] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [ShowDateH] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [ShowDateH] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [ShowDateG] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [ShowDateG] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [SalDate] [varchar](10) NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [SalDate] = '' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [DisVacationType] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [DisVacationType] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [IsAlarmEmpDoc] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [IsAlarmEmpDoc] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [IsAlarmEmpContract] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [IsAlarmEmpContract] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [IsAlarmFamilyPassport] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [IsAlarmFamilyPassport] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [IsAlarmGuarantorDoc] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [IsAlarmGuarantorDoc] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [IsAlarmEndVaction] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [IsAlarmEndVaction] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [IsAlarmBranchDoc] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [IsAlarmBranchDoc] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [IsAlarmCarDoc] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [IsAlarmCarDoc] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [IsAlarmSecretariatsDoc] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [IsAlarmSecretariatsDoc] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [AlarmEmpDocBefore] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [AlarmEmpDocBefore] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [AlarmEmpContractBefore] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [AlarmEmpContractBefore] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [AlarmFamilyPassportBefore] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [AlarmFamilyPassportBefore] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [AlarmGuarantorDocBefore] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [AlarmGuarantorDocBefore] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [AlarmEndVactionBefore] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [AlarmEndVactionBefore] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [AlarmBranchDocBefore] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [AlarmBranchDocBefore] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [AlarmCarDocBefore] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [AlarmCarDocBefore] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [AlarmSecretariatsBefore] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [AlarmSecretariatsBefore] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [IsAutoBackup] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [IsAutoBackup] = 1 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [AutoBackup] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [AutoBackup] = 2 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [AutoBackupDate] [varchar](15) NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [AutoBackupDate] = '' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [Hdat] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [Hdat] = 1 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Create function [dbo].[get_date]()\r\n                                    returns VARCHAR(10)\r\n                                    as\r\n                                    begin\r\n                                    DECLARE @GETDATE AS DATETIME = GETDATE()\r\n                                    return  CONVERT(VARCHAR(4),DATEPART(YEAR, @GETDATE)) \r\n                                    + '/'+ CONVERT(VARCHAR(2),DATEPART(MONTH, @GETDATE)) \r\n                                    + '/' + CONVERT(VARCHAR(2),DATEPART(DAY, @GETDATE)) end");
                }
                catch
                {
                }
                try
                {
                    db.T_Emps.Select<T_Emp, T_Emp>((Expression<Func<T_Emp, T_Emp>>)(t => t)).ToList<T_Emp>();
                }
                catch
                {
                    try
                    {
                        db.ExecuteCommand("/****** Object:  Table [dbo].[T_Dept]    Script Date: 08/15/2014 07:50:28 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Dept]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_Dept](\r\n\t                                    [Dept_ID] [varchar](40) NOT NULL,\r\n\t                                    [Dept_No] [int] NOT NULL,\r\n\t                                    [NameA] [varchar](50) NULL,\r\n\t                                    [NameE] [varchar](50) NULL,\r\n\t                                    [Note] [varchar](250) NULL,\r\n                                     CONSTRAINT [PK_T_Dept] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [Dept_No] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    /****** Object:  Table [dbo].[T_DaysOfMonth]    Script Date: 08/15/2014 07:50:28 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_DaysOfMonth]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_DaysOfMonth](\r\n\t                                    [ID] [varchar](40) NOT NULL,\r\n\t                                    [DaysOfMonth] [int] NULL,\r\n\t                                    [Year] [int] NULL,\r\n\t                                    [Month] [int] NULL,\r\n                                     CONSTRAINT [PK_T_DaysOfMonth] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [ID] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    /****** Object:  Table [dbo].[T_DayOfWeek]    Script Date: 08/15/2014 07:50:28 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_DayOfWeek]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_DayOfWeek](\r\n\t                                    [Day_No] [int] NOT NULL,\r\n\t                                    [NameA] [varchar](10) NULL,\r\n\t                                    [NameE] [varchar](10) NULL,\r\n                                     CONSTRAINT [PK_T_DayOfWeek] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [Day_No] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    INSERT [dbo].[T_DayOfWeek] ([Day_No], [NameA], [NameE]) VALUES (1, N'??????????     ', N'Sat       ')\r\n                                    INSERT [dbo].[T_DayOfWeek] ([Day_No], [NameA], [NameE]) VALUES (2, N'??????????     ', N'Sun       ')\r\n                                    INSERT [dbo].[T_DayOfWeek] ([Day_No], [NameA], [NameE]) VALUES (3, N'??????????????   ', N'Mon       ')\r\n                                    INSERT [dbo].[T_DayOfWeek] ([Day_No], [NameA], [NameE]) VALUES (4, N'????????????????  ', N'Tues      ')\r\n                                    INSERT [dbo].[T_DayOfWeek] ([Day_No], [NameA], [NameE]) VALUES (5, N'????????????????  ', N'Wednes    ')\r\n                                    INSERT [dbo].[T_DayOfWeek] ([Day_No], [NameA], [NameE]) VALUES (6, N'????????????    ', N'Thurs     ')\r\n                                    INSERT [dbo].[T_DayOfWeek] ([Day_No], [NameA], [NameE]) VALUES (7, N'????????????    ', N'Fri       ')\r\n                                    /****** Object:  Table [dbo].[T_Contract]    Script Date: 08/15/2014 07:50:28 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Contract]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_Contract](\r\n\t                                    [Contract_ID] [varchar](40) NOT NULL,\r\n\t                                    [Contract_No] [int] NOT NULL,\r\n\t                                    [NameA] [varchar](30) NULL,\r\n\t                                    [NameE] [varchar](30) NULL,\r\n\t                                    [Note] [varchar](250) NULL,\r\n                                     CONSTRAINT [PK_T_Contract] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [Contract_No] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    INSERT [dbo].[T_Contract] ([Contract_ID], [Contract_No], [NameA], [NameE], [Note]) VALUES (N'd75681e4-ecb5-416e-b2ce-64be0417911b', 1, N'??????????', N'Main', N'----------')\r\n                                    INSERT [dbo].[T_Contract] ([Contract_ID], [Contract_No], [NameA], [NameE], [Note]) VALUES (N'192c7bf7-4976-4a06-80d5-44a8a39132e1', 2, N'????????', N'Temporary', N'-----------')\r\n                                    /****** Object:  Table [dbo].[T_City]    Script Date: 08/15/2014 07:50:28 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_City]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_City](\r\n\t                                    [City_ID] [varchar](40) NOT NULL,\r\n\t                                    [City_No] [int] NOT NULL,\r\n\t                                    [NameA] [varchar](30) NULL,\r\n\t                                    [NameE] [varchar](30) NULL,\r\n\t                                    [Note] [varchar](250) NULL,\r\n                                     CONSTRAINT [PK_T_City] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [City_No] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    INSERT [dbo].[T_City] ([City_ID], [City_No], [NameA], [NameE], [Note]) VALUES (N'7781ea2d-d8b2-4c72-8ddd-b67985e94fe2', 1, N'??????', N'Jeddah', N'')\r\n                                    INSERT [dbo].[T_City] ([City_ID], [City_No], [NameA], [NameE], [Note]) VALUES (N'823914d8-3203-4fec-a6ac-abda3efc7607', 2, N'????????????', N'Riyadh', N'')\r\n                                    INSERT [dbo].[T_City] ([City_ID], [City_No], [NameA], [NameE], [Note]) VALUES (N'ff3af6cd-0e00-4cd2-ac88-f0d4c939a577', 3, N'??????????????', N'Cairo', N'')\r\n                                    INSERT [dbo].[T_City] ([City_ID], [City_No], [NameA], [NameE], [Note]) VALUES (N'14b9aef8-7704-4a1e-9a44-7592fa9f4f82', 4, N'??????????', N'San''a', N'')\r\n                                    INSERT [dbo].[T_City] ([City_ID], [City_No], [NameA], [NameE], [Note]) VALUES (N'cb2a73a6-c68b-42b4-ad14-8e12f64930fc', 5, N'????????', N'Abhaa', N'')\r\n                                    INSERT [dbo].[T_City] ([City_ID], [City_No], [NameA], [NameE], [Note]) VALUES (N'1166d7ba-34de-4871-b9d6-8544164adf1e', 6, N'??????????', N'Birute', N'')\r\n                                    INSERT [dbo].[T_City] ([City_ID], [City_No], [NameA], [NameE], [Note]) VALUES (N'9e94d17b-0f4b-4c46-aa69-091a302db846', 7, N'????????', N'Tunisia', N'')\r\n                                    INSERT [dbo].[T_City] ([City_ID], [City_No], [NameA], [NameE], [Note]) VALUES (N'768c4d11-a4ff-49c6-bc32-12667b53adad', 8, N'??????????????', N'Manaama', N'')\r\n                                    INSERT [dbo].[T_City] ([City_ID], [City_No], [NameA], [NameE], [Note]) VALUES (N'9b58b074-4be0-4fc0-9cdc-7e9b19d0745e', 9, N'????????????????????', N'Iskendriaa', N'')\r\n                                    INSERT [dbo].[T_City] ([City_ID], [City_No], [NameA], [NameE], [Note]) VALUES (N'15ab5c93-3023-4a91-a128-abf48a4a09ed', 10, N'????????', N'Bishaa', N'')\r\n                                    INSERT [dbo].[T_City] ([City_ID], [City_No], [NameA], [NameE], [Note]) VALUES (N'6c719c20-51d6-42b7-94bc-d02272102d32', 11, N'????????', N'Demasq', N'')\r\n                                    INSERT [dbo].[T_City] ([City_ID], [City_No], [NameA], [NameE], [Note]) VALUES (N'41bf61a2-d6ae-497d-a59f-460df25972a9', 12, N'????????????', N'Blgoraashi', N'')\r\n                                    INSERT [dbo].[T_City] ([City_ID], [City_No], [NameA], [NameE], [Note]) VALUES (N'bce7c960-e279-4ef9-8d59-e8858ca8e666', 13, N'????????', N'Aarish', N'')\r\n                                    INSERT [dbo].[T_City] ([City_ID], [City_No], [NameA], [NameE], [Note]) VALUES (N'31ee5d45-94de-47f3-840a-30c1eb6b41cf', 14, N'????????????', N'Dammam', N'')\r\n                                    INSERT [dbo].[T_City] ([City_ID], [City_No], [NameA], [NameE], [Note]) VALUES (N'42ef8d1e-162d-4868-b45c-208791d6391f', 15, N'??????????????', N'Khartoom', N'')\r\n                                    /****** Object:  Table [dbo].[T_BloodTyp]    Script Date: 08/15/2014 07:50:28 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_BloodTyp]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_BloodTyp](\r\n\t                                    [BloodTyp_No] [int] NOT NULL,\r\n\t                                    [NameA] [varchar](10) NULL,\r\n\t                                    [NameE] [varchar](10) NULL,\r\n                                     CONSTRAINT [PK_T_BloodTyp] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [BloodTyp_No] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    INSERT [dbo].[T_BloodTyp] ([BloodTyp_No], [NameA], [NameE]) VALUES (1, N'A+   ', N'A+   ')\r\n                                    INSERT [dbo].[T_BloodTyp] ([BloodTyp_No], [NameA], [NameE]) VALUES (2, N'A-   ', N'A-   ')\r\n                                    INSERT [dbo].[T_BloodTyp] ([BloodTyp_No], [NameA], [NameE]) VALUES (3, N'B+   ', N'B+   ')\r\n                                    INSERT [dbo].[T_BloodTyp] ([BloodTyp_No], [NameA], [NameE]) VALUES (4, N'B-   ', N'B-   ')\r\n                                    INSERT [dbo].[T_BloodTyp] ([BloodTyp_No], [NameA], [NameE]) VALUES (5, N'O    ', N'O    ')\r\n                                    /****** Object:  Table [dbo].[T_BirthPlace]    Script Date: 08/15/2014 07:50:28 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_BirthPlace]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_BirthPlace](\r\n\t                                    [BirthPlaceNo] [int] NOT NULL,\r\n\t                                    [NameA] [varchar](20) NULL,\r\n\t                                    [NameE] [varchar](20) NULL,\r\n                                     CONSTRAINT [PK_T_BirthPlace] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [BirthPlaceNo] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (1, N'????????', N'Abha')\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (2, N'?????? ????????', N'Abo Aresh')\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (3, N'????????????', N'Baha')\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (4, N'??????????', N'Bridaa')\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (5, N'????????????????', N'alBakeria')\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (6, N'????????????', N'BoLjorashi')\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (7, N'????????', N'Bisha')\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (8, N'????????', N'Tabook')\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (9, N'??????????', N'Tnomaa')\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (10, N'??????', N'Jeddah')\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (11, N'??????????', N'Jezaan')\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (12, N'????????????', N'Riyadh')\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (13, N'????????????', N'Damaam')\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (14, N'????????', N'Haiel')\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (15, N'???????? ????????', N'Khmiss Meshiat')\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (16, N'?????? ????????????          ', N'Haafr Albaten')\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (17, N'????????                ', N'Aar Aar ')\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (18, N'????????????              ', N'Gatif')\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (20, N'????????????              ', N'Qussim')\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (21, N'??????????????             ', N'Cairo')\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (22, N'????????????????????          ', N'Iskendrya')\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (23, N'??????????               ', NULL)\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (24, N'??????                 ', NULL)\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (25, N'????????                ', NULL)\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (26, N'??????                 ', NULL)\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (27, N'????????                ', NULL)\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (28, N'????????????              ', NULL)\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (29, N'??????????????             ', NULL)\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (30, N'??????                 ', NULL)\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (31, N'????????????              ', NULL)\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (32, N'??????????????             ', NULL)\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (33, N'?????? ??????????           ', NULL)\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (34, N'????????????              ', NULL)\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (35, N'??????????????????           ', NULL)\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (36, N'????????????              ', NULL)\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (37, N'??????????               ', NULL)\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (38, N'????????????              ', NULL)\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (39, N'????????                ', NULL)\r\n                                    INSERT [dbo].[T_BirthPlace] ([BirthPlaceNo], [NameA], [NameE]) VALUES (40, N'??????????               ', NULL)\r\n                                    /****** Object:  Table [dbo].[T_Bank]    Script Date: 08/15/2014 07:50:28 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Bank]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_Bank](\r\n\t                                    [Bank_ID] [varchar](40) NOT NULL,\r\n\t                                    [Bank_No] [int] NOT NULL,\r\n\t                                    [Cod] [varchar](50) NULL,\r\n\t                                    [NameA] [varchar](50) NULL,\r\n\t                                    [NameE] [varchar](50) NULL,\r\n\t                                    [Note] [varchar](250) NULL,\r\n                                     CONSTRAINT [PK_T_Bank] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [Bank_No] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    INSERT [dbo].[T_Bank] ([Bank_ID], [Bank_No], [Cod], [NameA], [NameE], [Note]) VALUES (N'2fc43218-2c8e-4ce0-8139-411ac61bbeb5', 1, N'', N'?????????? ????????????', N'', N'')\r\n                                    INSERT [dbo].[T_Bank] ([Bank_ID], [Bank_No], [Cod], [NameA], [NameE], [Note]) VALUES (N'1c6add1c-ba68-4251-a46f-b8983185ebd3', 2, N'', N'??????????????', N'', N'----------')\r\n                                    INSERT [dbo].[T_Bank] ([Bank_ID], [Bank_No], [Cod], [NameA], [NameE], [Note]) VALUES (N'7ea6b450-0d15-49d3-becb-4c7b55978a6e', 3, N'', N'?????????????? ????????????????', N'', N'----------')\r\n                                    INSERT [dbo].[T_Bank] ([Bank_ID], [Bank_No], [Cod], [NameA], [NameE], [Note]) VALUES (N'c30b857d-a2cd-4fc3-9526-bd12d68deeef', 4, N'', N'??????????????', N'', N'----------')\r\n                                    INSERT [dbo].[T_Bank] ([Bank_ID], [Bank_No], [Cod], [NameA], [NameE], [Note]) VALUES (N'e04fd042-28ee-4342-be95-c8d1ab60aefb', 5, N'', N'????????????', N'', N'----------')\r\n                                    /****** Object:  UserDefinedFunction [dbo].[get_date]    Script Date: 08/15/2014 07:50:29 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[get_date]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))\r\n                                    BEGIN\r\n                                    execute dbo.sp_executesql @statement = N'\r\n                                    create function [dbo].[get_date]()\r\n                                    returns DateTime\r\n                                    as\r\n                                    begin\r\n                                          return(Select Convert(DateTime,Getdate()))\r\n                                    end\r\n\r\n                                    ' \r\n                                    END\r\n                                    GO\r\n                                    /****** Object:  UserDefinedFunction [dbo].[fnCalAgeVaction]    Script Date: 08/15/2014 07:50:29 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fnCalAgeVaction]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))\r\n                                    BEGIN\r\n                                    execute dbo.sp_executesql @statement = N'\r\n                                    CREATE FUNCTION [dbo].[fnCalAgeVaction] (\r\n                                        @DOB nvarchar(10),\r\n                                        @vacCount int\r\n                                        ) \r\n                                    RETURNS INT\r\n                                    BEGIN\r\n                                    DECLARE @now date = getdate()\r\n                                        DECLARE @years int, @months int;\r\n                                        IF @DOB &gt; @now RETURN 0;\r\n                                        SET @years = DATEDIFF(year, @DOB, @now);\r\n                                        IF MONTH(@DOB) * 100 + DAY(@DOB) &gt; MONTH(@now) * 100 + DAY(@now)\r\n                                            SET @years = @years - 1;\r\n                                        SET @months = DATEDIFF(month, DATEADD(year, @years, @DOB), @now);\r\n                                        IF DAY(@DOB) &gt; DAY(@now)\r\n                                            SET @months = @months - 1;\r\n                                        RETURN CASE\r\n                                            WHEN @years = 0 THEN  @months \r\n                                            ELSE  @years * @vacCount\r\n                                        END;\r\n                                    END\r\n                                    ' \r\n                                    END\r\n                                    GO\r\n                                    /****** Object:  UserDefinedFunction [dbo].[fnCalAge]    Script Date: 08/15/2014 07:50:29 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fnCalAge]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))\r\n                                    BEGIN\r\n                                    execute dbo.sp_executesql @statement = N'\r\n                                    CREATE FUNCTION [dbo].[fnCalAge] (@DOB nvarchar(10),@TicketCount int) \r\n                                    RETURNS INT\r\n                                    BEGIN\r\n                                    DECLARE @now date = getdate()\r\n                                        DECLARE @years int, @months int;\r\n                                        IF @DOB &gt; @now RETURN 0;\r\n                                        SET @years = DATEDIFF(year, @DOB, @now);\r\n                                        IF MONTH(@DOB) * 100 + DAY(@DOB) &gt; MONTH(@now) * 100 + DAY(@now)\r\n                                            SET @years = @years - 1;\r\n                                        SET @months = DATEDIFF(month, DATEADD(year, @years, @DOB), @now);\r\n                                        IF DAY(@DOB) &gt; DAY(@now)\r\n                                            SET @months = @months - 1;\r\n                                        RETURN CASE\r\n                                            WHEN @years = 0 THEN  @months \r\n                                            ELSE  @years * @TicketCount\r\n                                        END;\r\n                                    END\r\n                                    ' \r\n                                    END\r\n                                    GO\r\n                                    /****** Object:  StoredProcedure [dbo].[S_T_Report]    Script Date: 08/15/2014 07:50:30 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[S_T_Report]') AND type in (N'P', N'PC'))\r\n                                    BEGIN\r\n                                    EXEC dbo.sp_executesql @statement = N'\r\n\r\n\r\n                                    create PROCEDURE [dbo].[S_T_Report](\r\n                                                        \r\n                                                       @Tables VARCHAR(Max),\r\n                                                       @Fields VARCHAR(Max)=''*'',\r\n\t\t\t\t                                       @Rule VARCHAR(Max)= NULL     \r\n                                          )\r\n                                          AS\r\n                                          BEGIN\r\n                                          DECLARE @sql AS NVARCHAR(MAX);\r\n\r\n                                          SET @sql = N''SELECT '' + @Fields\r\n                                          \r\n                                          + N'' FROM '' +@Tables + '' ''\r\n\r\n\t                                      + CASE WHEN @Rule IS NOT NULL THEN\r\n                                          + @Rule + '';'' ELSE N'''' END\r\n                                          \r\n                                          EXEC sp_executesql\r\n                                          @sql,\r\n                                          N''\r\n                                          @P_Tables VARCHAR(Max),\r\n                                          @P_Fields VARCHAR(Max),\r\n\t                                      @P_Rule VARCHAR(Max)''\r\n                                          \r\n                                          ,@P_Tables = @Tables\r\n                                          ,@P_Fields = @Fields\r\n\t                                      ,@P_Rule = @Rule;\r\n                                          \r\n                                          RETURN\r\n                                          END\r\n\r\n\r\n\r\n                                    ' \r\n                                    END\r\n                                    GO\r\n                                    /****** Object:  Table [dbo].[T_Guarantor]    Script Date: 08/15/2014 07:50:30 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Guarantor]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_Guarantor](\r\n\t                                    [Guarantor_ID] [varchar](40) NOT NULL,\r\n\t                                    [Guarantor_No] [int] NOT NULL,\r\n\t                                    [CodPc] [varchar](15) NULL,\r\n\t                                    [NameA] [varchar](30) NULL,\r\n\t                                    [NameE] [varchar](30) NULL,\r\n\t                                    [Address] [varchar](30) NULL,\r\n\t                                    [Tel] [varchar](15) NULL,\r\n\t                                    [Fax] [varchar](15) NULL,\r\n\t                                    [Mobil] [varchar](15) NULL,\r\n                                     CONSTRAINT [PK_T_Guarantor] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [Guarantor_No] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    /****** Object:  Table [dbo].[T_Religion]    Script Date: 08/15/2014 07:50:30 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Religion]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_Religion](\r\n\t                                    [Religion_ID] [varchar](40) NOT NULL,\r\n\t                                    [Religion_No] [int] NOT NULL,\r\n\t                                    [NameA] [varchar](30) NULL,\r\n\t                                    [NameE] [varchar](30) NULL,\r\n\t                                    [Note] [varchar](30) NULL,\r\n                                     CONSTRAINT [PK_T_Religion] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [Religion_No] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    INSERT [dbo].[T_Religion] ([Religion_ID], [Religion_No], [NameA], [NameE], [Note]) VALUES (N'2ab2a6f3-e237-4e94-a10f-04fe1d4a73b4', 1, N'????????', N'Muslim', N'----------')\r\n                                    INSERT [dbo].[T_Religion] ([Religion_ID], [Religion_No], [NameA], [NameE], [Note]) VALUES (N'8ee8b3d4-0fed-4ceb-92ef-acb97699a319', 2, N'??????????', N'Christian', N'-------------')\r\n                                    /****** Object:  Table [dbo].[T_AddTyp]    Script Date: 08/15/2014 07:50:30 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_AddTyp]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_AddTyp](\r\n\t                                    [AddTyp_No] [int] NOT NULL,\r\n\t                                    [NameA] [varchar](20) NULL,\r\n\t                                    [NameE] [varchar](20) NULL,\r\n                                     CONSTRAINT [PK_T_AddTyp] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [AddTyp_No] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    INSERT [dbo].[T_AddTyp] ([AddTyp_No], [NameA], [NameE]) VALUES (1, N'?????????? ??????           ', N'For Day???s        ')\r\n                                    INSERT [dbo].[T_AddTyp] ([AddTyp_No], [NameA], [NameE]) VALUES (2, N'?????????? ????????          ', N'For Hour???s         ')\r\n                                    INSERT [dbo].[T_AddTyp] ([AddTyp_No], [NameA], [NameE]) VALUES (3, N'???????????? ??????              ', N'Delegate            ')\r\n                                    /****** Object:  Table [dbo].[T_TicetTyp]    Script Date: 08/15/2014 07:50:30 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_TicetTyp]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_TicetTyp](\r\n\t                                    [TicetT_No] [int] NOT NULL,\r\n\t                                    [NameA] [varchar](20) NULL,\r\n\t                                    [NameE] [varchar](20) NULL,\r\n                                     CONSTRAINT [PK_T_TicetTyp] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [TicetT_No] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    INSERT [dbo].[T_TicetTyp] ([TicetT_No], [NameA], [NameE]) VALUES (1, N'??????????         ', N'Busniss       ')\r\n                                    INSERT [dbo].[T_TicetTyp] ([TicetT_No], [NameA], [NameE]) VALUES (2, N'????????           ', N'First         ')\r\n                                    INSERT [dbo].[T_TicetTyp] ([TicetT_No], [NameA], [NameE]) VALUES (3, N'??????????          ', N'Touring       ')\r\n                                    INSERT [dbo].[T_TicetTyp] ([TicetT_No], [NameA], [NameE]) VALUES (4, N'??????????????        ', N'Hospitality ')\r\n                                    INSERT [dbo].[T_TicetTyp] ([TicetT_No], [NameA], [NameE]) VALUES (5, N'??????                ', N'Other               ')\r\n                                    /****** Object:  Table [dbo].[T_SubTyp]    Script Date: 08/15/2014 07:50:30 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_SubTyp]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_SubTyp](\r\n\t                                    [SubNo] [int] NOT NULL,\r\n\t                                    [NameA] [varchar](20) NULL,\r\n\t                                    [NameE] [varchar](20) NULL,\r\n                                     CONSTRAINT [PK_T_SubTyp] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [SubNo] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    INSERT [dbo].[T_SubTyp] ([SubNo], [NameA], [NameE]) VALUES (1, N'???????? ??????', N'Day???s Absent        ')\r\n                                    INSERT [dbo].[T_SubTyp] ([SubNo], [NameA], [NameE]) VALUES (2, N'?????????? ????????', N'Hour???s late         ')\r\n                                    INSERT [dbo].[T_SubTyp] ([SubNo], [NameA], [NameE]) VALUES (3, N'?????? ????????', N'Penalty Deduction   ')\r\n                                    INSERT [dbo].[T_SubTyp] ([SubNo], [NameA], [NameE]) VALUES (4, N'???????????? ????????', N'Other Deduction     ')\r\n                                    /****** Object:  Table [dbo].[T_Sex]    Script Date: 08/15/2014 07:50:30 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Sex]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_Sex](\r\n\t                                    [SexNo] [int] NOT NULL,\r\n\t                                    [NameA] [varchar](20) NULL,\r\n\t                                    [NameE] [varchar](20) NULL,\r\n                                     CONSTRAINT [PK_T_Sex] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [SexNo] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    INSERT [dbo].[T_Sex] ([SexNo], [NameA], [NameE]) VALUES (1, N'??????', N'Male')\r\n                                    INSERT [dbo].[T_Sex] ([SexNo], [NameA], [NameE]) VALUES (2, N'????????', N'Female')\r\n                                    /****** Object:  Table [dbo].[T_Section]    Script Date: 08/15/2014 07:50:30 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Section]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_Section](\r\n\t                                    [Section_ID] [varchar](40) NOT NULL,\r\n\t                                    [Section_No] [int] NOT NULL,\r\n\t                                    [NameA] [varchar](30) NULL,\r\n\t                                    [NameE] [varchar](30) NULL,\r\n\t                                    [Note] [varchar](250) NULL,\r\n                                     CONSTRAINT [PK_T_Section] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [Section_No] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    /****** Object:  Table [dbo].[T_SalStatus]    Script Date: 08/15/2014 07:50:30 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_SalStatus]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_SalStatus](\r\n\t                                    [SalStatusNo] [int] NOT NULL,\r\n\t                                    [NameA] [varchar](20) NULL,\r\n\t                                    [NameE] [varchar](20) NULL,\r\n                                     CONSTRAINT [PK_T_SalStatus] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [SalStatusNo] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    INSERT [dbo].[T_SalStatus] ([SalStatusNo], [NameA], [NameE]) VALUES (1, N'????????', N'Valid')\r\n                                    INSERT [dbo].[T_SalStatus] ([SalStatusNo], [NameA], [NameE]) VALUES (2, N'??????????', N'Stopped')\r\n                                    /****** Object:  Table [dbo].[T_OpMethod]    Script Date: 08/15/2014 07:50:30 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_OpMethod]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_OpMethod](\r\n\t                                    [Method_No] [int] NOT NULL,\r\n\t                                    [Name] [varchar](50) NULL,\r\n\t                                    [NameE] [varchar](50) NULL,\r\n                                     CONSTRAINT [PK_T_OpMethod] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [Method_No] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    INSERT [dbo].[T_OpMethod] ([Method_No], [Name], [NameE]) VALUES (1, N'?????????????? ???????????? ???? ???????? ???????????? ????????????', N'As specified in employee data')\r\n                                    INSERT [dbo].[T_OpMethod] ([Method_No], [Name], [NameE]) VALUES (2, N'???????????? ??????????????', N'Main Salary')\r\n                                    INSERT [dbo].[T_OpMethod] ([Method_No], [Name], [NameE]) VALUES (3, N'???????????? ?????????????? + ?????????? ???????????? ???? ?????? ??????????', N'Main salary+Monthly installment of housing')\r\n                                    INSERT [dbo].[T_OpMethod] ([Method_No], [Name], [NameE]) VALUES (4, N'???????????? ?????????????? + ???????? ??????????????', N'Main Salary+All Allowance')\r\n                                    INSERT [dbo].[T_OpMethod] ([Method_No], [Name], [NameE]) VALUES (5, N'???????????? ?????????????? + ?????? ?????????????????? + ?????? ??????????', N'Main salary+Installment of housing+Transport')\r\n                                    INSERT [dbo].[T_OpMethod] ([Method_No], [Name], [NameE]) VALUES (6, N'???????????? ?????????????? + ?????? ??????????????', N'Main salary+Food allowance')\r\n                                    INSERT [dbo].[T_OpMethod] ([Method_No], [Name], [NameE]) VALUES (7, N'???????????? ?????????????? + ?????? ??????????????????', N'Main salary+Transport')\r\n                                    INSERT [dbo].[T_OpMethod] ([Method_No], [Name], [NameE]) VALUES (8, N'???????? ??????????', N'Fixed Sum')\r\n                                    INSERT [dbo].[T_OpMethod] ([Method_No], [Name], [NameE]) VALUES (9, N'?????? ?????????? ????????????', N'Anuall housing')\r\n                                    INSERT [dbo].[T_OpMethod] ([Method_No], [Name], [NameE]) VALUES (10, N'?????? ??????????????????', N'Transportation')\r\n                                    INSERT [dbo].[T_OpMethod] ([Method_No], [Name], [NameE]) VALUES (11, N'?????? ??????????????', N'Food allowance')\r\n                                    INSERT [dbo].[T_OpMethod] ([Method_No], [Name], [NameE]) VALUES (12, N'?????? ?????????? ??????', N'Job allowance')\r\n                                    INSERT [dbo].[T_OpMethod] ([Method_No], [Name], [NameE]) VALUES (13, N'?????????? ????????', N'Other allowance')\r\n                                    /****** Object:  Table [dbo].[T_Nationalities]    Script Date: 08/15/2014 07:50:30 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Nationalities]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_Nationalities](\r\n\t                                    [Nation_ID] [varchar](40) NOT NULL,\r\n\t                                    [Nation_No] [int] NOT NULL,\r\n\t                                    [NameA] [varchar](30) NULL,\r\n\t                                    [NameE] [varchar](30) NULL,\r\n\t                                    [Note] [varchar](50) NULL,\r\n\t                                    [SalSubtract] [float] NULL,\r\n\t                                    [CompPaying] [float] NULL,\r\n                                     CONSTRAINT [PK_T_Nationalities] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [Nation_No] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    INSERT [dbo].[T_Nationalities] ([Nation_ID], [Nation_No], [NameA], [NameE], [Note], [SalSubtract], [CompPaying]) VALUES (N'0ddda9a3-32fc-46aa-a28b-1b93503e9037', 1, N'??????????', N'Saudi', N'----------', 0, 0)\r\n                                    INSERT [dbo].[T_Nationalities] ([Nation_ID], [Nation_No], [NameA], [NameE], [Note], [SalSubtract], [CompPaying]) VALUES (N'6750a26a-e616-4f1a-9b61-5c1b28dbaac5', 2, N'????????', N'yemeni', N'--------', 0, 0)\r\n                                    INSERT [dbo].[T_Nationalities] ([Nation_ID], [Nation_No], [NameA], [NameE], [Note], [SalSubtract], [CompPaying]) VALUES (N'e4ec98ab-5865-4e44-9707-8fc2a0eec675', 3, N'????????', N'Egypt', N'--------', 0, 0)\r\n                                    INSERT [dbo].[T_Nationalities] ([Nation_ID], [Nation_No], [NameA], [NameE], [Note], [SalSubtract], [CompPaying]) VALUES (N'7f1207b9-7a7f-48ba-9aa7-917a1d7f62a3', 4, N'????????', N'syria', N'--------', 0, 0)\r\n                                    INSERT [dbo].[T_Nationalities] ([Nation_ID], [Nation_No], [NameA], [NameE], [Note], [SalSubtract], [CompPaying]) VALUES (N'43d390f1-e6d5-456a-a97b-396b90140e85', 5, N'????????????', N'lebanon', N'', 0, 0)\r\n                                    INSERT [dbo].[T_Nationalities] ([Nation_ID], [Nation_No], [NameA], [NameE], [Note], [SalSubtract], [CompPaying]) VALUES (N'75f01556-2850-4c11-86ef-6d0fffbbe8e8', 6, N'????????', N'india', N'--------', 0, 0)\r\n                                    INSERT [dbo].[T_Nationalities] ([Nation_ID], [Nation_No], [NameA], [NameE], [Note], [SalSubtract], [CompPaying]) VALUES (N'18203d93-9ffc-4314-a104-60f90740fd59', 7, N'????????????????', N'indonisia', N'--------', 0, 0)\r\n                                    INSERT [dbo].[T_Nationalities] ([Nation_ID], [Nation_No], [NameA], [NameE], [Note], [SalSubtract], [CompPaying]) VALUES (N'92ee3102-3a9e-43a3-b6c2-17d3610c9ade', 8, N'??????????', N'iraq', N'--------', 0, 0)\r\n                                    INSERT [dbo].[T_Nationalities] ([Nation_ID], [Nation_No], [NameA], [NameE], [Note], [SalSubtract], [CompPaying]) VALUES (N'66799e62-0b56-4974-8122-d2bd04deccd5', 9, N'??????????', N'kuwait', N'--------', 0, 0)\r\n                                    INSERT [dbo].[T_Nationalities] ([Nation_ID], [Nation_No], [NameA], [NameE], [Note], [SalSubtract], [CompPaying]) VALUES (N'aec0e758-75fa-4d62-9fc1-c63e6029f782', 10, N'????????????', N'USA', N'--------', 0, 0)\r\n                                    INSERT [dbo].[T_Nationalities] ([Nation_ID], [Nation_No], [NameA], [NameE], [Note], [SalSubtract], [CompPaying]) VALUES (N'918a3f7a-e57a-4587-90fa-2da3d452c87e', 11, N'????????????', N'Sudan', N'--------', 0, 0)\r\n                                    INSERT [dbo].[T_Nationalities] ([Nation_ID], [Nation_No], [NameA], [NameE], [Note], [SalSubtract], [CompPaying]) VALUES (N'63c13cc3-597e-4aba-bebb-7b6538478927', 12, N'????????', N'canada', N'--------', 0, 0)\r\n                                    /****** Object:  Table [dbo].[T_MStatus]    Script Date: 08/15/2014 07:50:30 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_MStatus]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_MStatus](\r\n\t                                    [MStatusNo] [int] NOT NULL,\r\n\t                                    [NameA] [varchar](20) NULL,\r\n\t                                    [NameE] [varchar](20) NULL,\r\n                                     CONSTRAINT [PK_T_MStatus] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [MStatusNo] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    INSERT [dbo].[T_MStatus] ([MStatusNo], [NameA], [NameE]) VALUES (1, N'????????', N'Single')\r\n                                    INSERT [dbo].[T_MStatus] ([MStatusNo], [NameA], [NameE]) VALUES (2, N'??????????', N'Married')\r\n                                    INSERT [dbo].[T_MStatus] ([MStatusNo], [NameA], [NameE]) VALUES (3, N'????????', N'Separate')\r\n                                    INSERT [dbo].[T_MStatus] ([MStatusNo], [NameA], [NameE]) VALUES (4, N'????????', N'Widower')\r\n                                    /****** Object:  Table [dbo].[T_LiquidationTyp]    Script Date: 08/15/2014 07:50:30 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_LiquidationTyp]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_LiquidationTyp](\r\n\t                                    [LiquidationT_ID] [varchar](40) NULL,\r\n\t                                    [LiquidationT_No] [int] NOT NULL,\r\n\t                                    [NameA] [varchar](20) NULL,\r\n\t                                    [NameE] [varchar](20) NULL,\r\n                                     CONSTRAINT [PK_T_LiquidationT] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [LiquidationT_No] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    INSERT [dbo].[T_LiquidationTyp] ([LiquidationT_ID], [LiquidationT_No], [NameA], [NameE]) VALUES (N'71a645e1-6d96-49ac-99ff-19b97ac2a912', 1, N'??????????', N'Settlement')\r\n                                    INSERT [dbo].[T_LiquidationTyp] ([LiquidationT_ID], [LiquidationT_No], [NameA], [NameE]) VALUES (N'a5191621-1a86-482f-8007-a2ffe27f5b81', 2, N'??????????????', N'Resign')\r\n                                    INSERT [dbo].[T_LiquidationTyp] ([LiquidationT_ID], [LiquidationT_No], [NameA], [NameE]) VALUES (N'898392e4-3512-440e-aa02-7a386874f210', 3, N'??????????????', N'Layoff')\r\n                                    INSERT [dbo].[T_LiquidationTyp] ([LiquidationT_ID], [LiquidationT_No], [NameA], [NameE]) VALUES (N'ae625aef-55a9-49ae-ba14-907736cbdec5', 4, N'??????', N'Dismiss')\r\n                                    /****** Object:  Table [dbo].[T_Job]    Script Date: 08/15/2014 07:50:30 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Job]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_Job](\r\n\t                                    [Job_ID] [varchar](40) NOT NULL,\r\n\t                                    [Job_No] [int] NOT NULL,\r\n\t                                    [NameA] [varchar](30) NULL,\r\n\t                                    [NameE] [varchar](30) NULL,\r\n\t                                    [Note] [varchar](250) NULL,\r\n                                     CONSTRAINT [PK_T_Job] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [Job_No] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    INSERT [dbo].[T_Job] ([Job_ID], [Job_No], [NameA], [NameE], [Note]) VALUES (N'608d3d80-b898-450f-bb06-bcb5d1512a84', 1, N'????????', N'Doctor', N'-------')\r\n                                    INSERT [dbo].[T_Job] ([Job_ID], [Job_No], [NameA], [NameE], [Note]) VALUES (N'5358dff2-2054-45a6-a833-75e6cdc04b34', 2, N'??????????', N'Eng', N'-------')\r\n                                    INSERT [dbo].[T_Job] ([Job_ID], [Job_No], [NameA], [NameE], [Note]) VALUES (N'3bbe6c85-a1d5-449a-a984-5a0698976d5b', 3, N'????????', N'salesman', N'---------')\r\n                                    INSERT [dbo].[T_Job] ([Job_ID], [Job_No], [NameA], [NameE], [Note]) VALUES (N'75ae2b9e-991e-41c6-8c4f-1708c043cb51', 4, N'??????????', N'Programming', N'--------')\r\n                                    INSERT [dbo].[T_Job] ([Job_ID], [Job_No], [NameA], [NameE], [Note]) VALUES (N'b5a8ead1-dc09-4a38-bf27-22647a40268e', 5, N'????????', N'Driver', N'----------')\r\n                                    /****** Object:  Table [dbo].[T_VacTyp]    Script Date: 08/15/2014 07:50:30 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_VacTyp]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_VacTyp](\r\n\t                                    [VacT_ID] [varchar](40) NOT NULL,\r\n\t                                    [VacT_No] [int] NOT NULL,\r\n\t                                    [NameA] [varchar](30) NULL,\r\n\t                                    [NameE] [varchar](30) NULL,\r\n\t                                    [Dis_VacT] [bit] NULL,\r\n\t                                    [Dis_Sal] [bit] NULL,\r\n                                     CONSTRAINT [PK_T_HolidayTyp] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [VacT_No] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    INSERT [dbo].[T_VacTyp] ([VacT_ID], [VacT_No], [NameA], [NameE], [Dis_VacT], [Dis_Sal]) VALUES (N'23b1e997-be89-422b-8db3-0bab0cd9c789', 1, N'??????????????', N'Eid', 0, 0)\r\n                                    INSERT [dbo].[T_VacTyp] ([VacT_ID], [VacT_No], [NameA], [NameE], [Dis_VacT], [Dis_Sal]) VALUES (N'a848fcdd-1f12-429b-a24e-b2037cd20e12', 2, N'??????', N'disease', 0, 0)\r\n                                    INSERT [dbo].[T_VacTyp] ([VacT_ID], [VacT_No], [NameA], [NameE], [Dis_VacT], [Dis_Sal]) VALUES (N'd0c15470-637d-404f-a45c-557702794691', 3, N'??????????????', N'Normal', 0, 0)\r\n                                    INSERT [dbo].[T_VacTyp] ([VacT_ID], [VacT_No], [NameA], [NameE], [Dis_VacT], [Dis_Sal]) VALUES (N'b76e8627-cd73-4744-b560-b5ec8c4e310b', 4, N'??????????', N'Baby', 0, 0)\r\n                                    /****** Object:  Table [dbo].[T_Info]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Info]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_Info](\r\n\t                                    [Company_ID] [int] IDENTITY(1,1) NOT NULL,\r\n\t                                    [CompName] [varchar](50) NOT NULL,\r\n\t                                    [Address] [varchar](30) NULL,\r\n\t                                    [Tel1] [varchar](15) NULL,\r\n\t                                    [Mobile] [varchar](15) NULL,\r\n\t                                    [Fax] [varchar](15) NULL,\r\n\t                                    [PBox] [varchar](15) NULL,\r\n\t                                    [MailCode] [varchar](15) NULL,\r\n\t                                    [NaturalJob] [varchar](20) NULL,\r\n\t                                    [Note] [varchar](250) NULL,\r\n\t                                    [BannarCompNameA] [varchar](100) NULL,\r\n\t                                    [BannarCompAddressA] [varchar](50) NULL,\r\n\t                                    [BannarTelA] [varchar](15) NULL,\r\n\t                                    [BannarFaxA] [varchar](15) NULL,\r\n\t                                    [CurrA1] [varchar](10) NULL,\r\n\t                                    [CurrA2] [varchar](10) NULL,\r\n\t                                    [CurrE1] [varchar](10) NULL,\r\n\t                                    [CurrE2] [varchar](10) NULL,\r\n\t                                    [AlarmDoc] [bit] NULL,\r\n\t                                    [AlarmDocBefore] [int] NULL,\r\n\t                                    [AutoLeave] [bit] NULL,\r\n\t                                    [EmpLeaveAfter] [int] NULL,\r\n\t                                    [AttendanceManually] [bit] NULL,\r\n\t                                    [VacationManually] [bit] NULL,\r\n\t                                    [CalculateNo] [int] NULL,\r\n\t                                    [CalculatliquidNo] [int] NULL,\r\n\t                                    [Allowances] [int] NULL,\r\n\t                                    [AllowancesTime] [int] NULL,\r\n\t                                    [CleanderType] [int] NULL,\r\n\t                                    [ShowBanner] [bit] NULL,\r\n\t                                    [ShowPageNo] [bit] NULL,\r\n\t                                    [ShowDateH] [bit] NULL,\r\n\t                                    [ShowDateG] [bit] NULL,\r\n\t                                    [LogoPic] [varbinary](max) NULL,\r\n\t                                    [SalDate] [varchar](10) NULL,\r\n\t                                    [BackPath] [varchar](max) NULL,\r\n                                     CONSTRAINT [PK_T_Info] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [Company_ID] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    SET IDENTITY_INSERT [dbo].[T_Info] ON\r\n                                    INSERT [dbo].[T_Info] ([Company_ID], [CompName], [Address], [Tel1], [Mobile], [Fax], [PBox], [MailCode], [NaturalJob], [Note], [BannarCompNameA], [BannarCompAddressA], [BannarTelA], [BannarFaxA], [CurrA1], [CurrA2], [CurrE1], [CurrE2], [AlarmDoc], [AlarmDocBefore], [AutoLeave], [EmpLeaveAfter], [AttendanceManually], [VacationManually], [CalculateNo], [CalculatliquidNo], [Allowances], [AllowancesTime], [CleanderType], [ShowBanner], [ShowPageNo], [ShowDateH], [ShowDateG], [LogoPic], [SalDate], [BackPath]) VALUES (1, N'???????????????????? ???????????? ??????????????', N'??????', N'012-6578843', N'0530805881', N'012-6530771', N'2724', N'11461', N'?????????? ????????????', N'----------------------', N'???????????????????? ???????????? ??????????????', N'?????????????? ?????????????? ???????????????? ', N'012-6578843', N'012-6530771', N'????????', N'????????', N'Riyal     ', N'Halal     ', 1, 1, 1, 0, 0, 1, 2, 2, 12, 1, 0, 1, 0, 0, 0, 0xFFD8FFE000104A46494600010101006000600000FFDB004300080606070605080707070909080A0C140D0C0B0B0C1912130F141D1A1F1E1D1A1C1C20242E2720222C231C1C2837292C30313434341F27393D38323C2E333432FFDB0043010909090C0B0C180D0D1832211C213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232FFC00011080064006403012200021101031101FFC4001F0000010501010101010100000000000000000102030405060708090A0BFFC400B5100002010303020403050504040000017D01020300041105122131410613516107227114328191A1082342B1C11552D1F02433627282090A161718191A25262728292A3435363738393A434445464748494A535455565758595A636465666768696A737475767778797A838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE1E2E3E4E5E6E7E8E9EAF1F2F3F4F5F6F7F8F9FAFFC4001F0100030101010101010101010000000000000102030405060708090A0BFFC400B51100020102040403040705040400010277000102031104052131061241510761711322328108144291A1B1C109233352F0156272D10A162434E125F11718191A262728292A35363738393A434445464748494A535455565758595A636465666768696A737475767778797A82838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE2E3E4E5E6E7E8E9EAF2F3F4F5F6F7F8F9FAFFDA000C03010002110311003F00F7FA28A2800A28A2800A28A2800A28AA97B3384F2A2566761CED19C0A00B11CA928251B383834FAC8B6335AC9B9A37119FBD9535AC082010720D002D14514005145140051457317FE39D334FD53EC72A4A515FCB79C01B54F7F72077AD29D29D47682B9956AF4E8A4EA3B5CE9E8ACED5B5BB2D16C56F2E9D8C4EC1104637162413C7E009FC2A5B2D52D6FB4A4D4A2665B6642FBA452A401D720FD0D65757E5EA74384943DA35EEF72E515CD69BE36D3B51D5869E2396177FF54D260073E9EC6AE6B3E28D3742B986DEF1A5324ABB808E32DB4671938F7CFE46B4AB0951FE22B1961A6B15FC0F7BD0D59A658222EDDBA0F53592B233ADC484FCC40E7F1156B52476449013B07518E954E1664C91820F04100FF3A8282166225C927E43DEADE9D73FF2C5CFFBA7FA54324BB86D440808C1F957FA566DEDF47A6DABDD4AD811F231D49EC055462E4ECB726538C22E527648EA68AC7F0E6BB1EBDA689C0093A1DB3463F84FAFD0D6C539C254E4E32DD134AAC2AC15483BA614514541A05795DC585B5C78575ABD9630F71118CC6E7AA92C33F9E6BD52BCD1BFE447D7FEB17FE842BBF02DABDBBC7F33CACCE29A57FE59FE4477624D574BF0BD9331F9AD8027DD8AA03F8053F9D771AE4496FE18B98625091A4423551D97818FCAB8EB4C5B5BF852E9FEE3448A4FA6D7FF00ECEBB4F117FC802EFF00DD1FCC571417FB64BFC47AD5E4DE5B4974E47F7F53CEB58B382CB4BF0FEA104616EA4B962F203C9C371F962B7C5A0D57E23CCF28DD1DB30600FA22AE3FF1F626B1FC47FF0022CF873FEBE1FF00F42AE974FC5B78FEFE36FF0096A84A9F5C846FF1FCAB7CCBDE853BF77F99CD91BE49E2397F963F92B9D6328752AC320F04572BAE6A36BA0E04FBA591FF00D54287E66F73E82BABAF2BD5246D57C47A84AD72200AEF1A4A413B1231CE00E79E3A7A9ABC1508D59BE7D91CB99E2E787A6BD9FC527646BDA789E19AE52DEF6CA5B0690E23776CA93EF9031F5AE73C51AABDEEA0D6AB9586DD8AE0F1961C127F9535F487B14786E2F21DCEE57C8E72CBBCA071EE181E3AE01ED9A63627BAB4BA768C34B6ACCED22EE5DCA1972460E7EE83D3A9AF628E1A853A9ED208F9BC4637155A8FB0AAFAAED7B79DB4DEDD8D0D0D9FC3F782E62BB496658C3DD598520F96402707A1650738ED83EF5EA304F15CDBC73C2E1E291432B0EE0D792B5F46B742F5A7B6B854B84DC22876314218302768CE4715D57846E2E34A6934FBC75FB13C98B2998F12139385F50473EC78EA6B971F41CE3ED1FC5F9FFC31E86538A54A5EC57C2FF0EDD5EFF75FD4ED28A28AF14FA62ADF6A16DA744B25CB3AA31DA0AC6CFCFF00C041AF34B8D4AD20F0AEAD672CBB6E2E3CB312153F360827B607E35E9F756B15E40D0CA0953E87915E5979A55BDDF86F54D425DFE7DA94F2F078E480723F1AF4B01C9D6FBAFCF4FF008278D9A7B5FB36DA5F75B5FC3635AFADCBFC31D2EE17868150923B0391FCCAFE55B3A8EBB6D77E16883B3FDA2EAD9240044C464E33F30181C83DEB1EFEED6DFE1558439FDE5C2471A0FA36E3FA29AD08EC153E1F594922912C56EAEBFF000220F3F9D70C797EBCEFFD3BE87B35149E4F06B7FD3975395D7751B4B8D2343B28A5DD716F3B1953691B72DC738C1FC2BA7F154A74BF1568FA90E15D846E47A0383FA3FE95CA6B7A4DB5B69DA2EA3197F3EE67224C9E386E302BA1F8852FDAB53D2B4D8B9949DCC076DCCAABF9E1BF2ADF36E55460E3DDFDF739786D4E58BA91A9D52BFA72BB7E9F33BFAF27BE967D1B5ED4FCBDEB34724AC854E0859070DF871F9D7ABBBAC68CEEC155464B13800578EEAFE2CD2F5FD7A73E67D84C4765ADE60959147F7F1C8E724103A1C1A30789A7467CB55E92271F966271B479F0D16E50D74FD3CFAFC86C7A845756E9F6881E4BA8464DC34990137972718FBC492339EF4C941416701FBE964ECC3D376F61FF008E95A86E6F6C2CA3F32EF51B6BB0A7725A597491BB6E200007BF27D2B36DB5696FA76BC7602E3765801C7E5E98E31F857B34B1787A95BD95395DEAFC8F9AC46518FA184FADD7A6D4534B5567EAD7C92BB2CA7FC78CC7FE9A27F26AE9BC11A01D4EF85F5C29FB25B36541E8EFD40FA0EA7F0AC6B0B59F5DBF86C2DA18E2566DCDB01C01DD8E493C0FFEB75AF61B0B1834DB18AD2DD76C512E07A9F527DCD4E618AF650E48FC52FC11393E01622A2AB2F863F8BFF8059A28A2BE74FB30ACD3A06986CAE6CFECDFB8B9C79A9BDB9C74EFC7E15A55C32E9FE3D6B696017FA50FF4616A25769B76403FBD1FED1CF5F6AA8CA51D99328465F12B9B5368FA25C49169135A314B1B70F1E6460155C918CE739F93BD5837B6375A8C9E1F681CE202E7A04DA36700839FE31F957311F86BC59E5CFF006C9F44D47ED512C53C7782574DABD001F5249CF734DB1F0C788348B492E8B5B4D7505A982086C9D94950D110A0BE00F96361C9EE2A7ED73752DB6E0A9BF8574E8747A8691A3BAE99A75CDA33C7E737D9C0761B182B3924E738E0FAF6A76A1A769A9AE69F7925A07BBB8B8F2C49B8F0563770719C7F07EB5CCE9DA2F8E0B45A8DC5DD8FDA1645922B5BB9247110F2DD18315C8DDF329E0E339ABDA4E81E285D760BDD6753B49ADE1B89275861690E37A32E06EEC3771ED9A726E6AD2D454D2A4DBA7A37A3B68667C55F10DC58D8C3A3DBABA7DAD4B4B2E300A038DA0FBF7F6C7AD792DBA47B5E6946E8E3C7CB9C6E63D07D3827F0AFA0FC59E1C87C4DA24968DB56E13E7B790FF0BFF81E87FF00AD5E39E1CF0F45A95FEA1A4EA53BD9CF0A960BB724BA86183F89EDD7A0EB5C35E12733EB728C4D18E11A5A38EFFE6259F87A4D5FC3D7DA8C50470C96986089B812B8EE0939CF6FA1C9E95CFDACEF6F70ACA09CF05477AEB75CF14CDA96A71456A67B78A252B72BE602182B162A0AF05179C568FC31F09FDBEF06B7791E6DADDB102B0E1E41DFE8BFCFE9534DB8D48BA4F55D4E8C44A3F54A9F5C578C97C3EBA5AFFD58EFFC1DE1F1A36982699317970034991CA0ECBFE3EFF4AE928A2BD3AB525566E72DD9F0B4284285354E9AB24145145666A14514500145145001451450015E73F11FC3B346CBE26D2C14B9800172107DE5ECFF008743EDF4AF46A6BA2C88C8EA191861948C823D2A67052563A30B89961EAAA91F9AEEBB1F3D787B4BB8F136AD1E99690476D13FCD7124618E101E492C4FB60742715F405959C1A75943676B188E08502228EC0566787BC31A7F8692E56C50E6E252ECCDD40FE151EC2B6AB3A34F916BB9D799E3FEB534A1F0AFEAE1451456C79814514500145145001451450014514500145145001451450014514500145145007FFFD9, N'', NULL)\r\n                                    SET IDENTITY_INSERT [dbo].[T_Info] OFF\r\n                                    /****** Object:  Table [dbo].[T_Emp]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Emp]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_Emp](\r\n\t                                    [Emp_ID] [varchar](40) NOT NULL,\r\n\t                                    [Emp_No] [varchar](6) NOT NULL,\r\n\t                                    [Pass] [varchar](50) NULL,\r\n\t                                    [NameA] [varchar](30) NULL,\r\n\t                                    [NameE] [varchar](30) NULL,\r\n\t                                    [DateAppointment] [varchar](10) NOT NULL,\r\n\t                                    [StartContr] [varchar](10) NULL,\r\n\t                                    [EndContr] [varchar](10) NULL,\r\n\t                                    [LastFilter] [varchar](10) NULL,\r\n\t                                    [ID_Date] [varchar](10) NULL,\r\n\t                                    [ID_DateEnd] [varchar](10) NULL,\r\n\t                                    [Passport_Date] [varchar](10) NULL,\r\n\t                                    [Passport_DateEnd] [varchar](10) NULL,\r\n\t                                    [License_Date] [varchar](10) NULL,\r\n\t                                    [License_DateEnd] [varchar](10) NULL,\r\n\t                                    [Form_Date] [varchar](10) NULL,\r\n\t                                    [Form_DateEnd] [varchar](10) NULL,\r\n\t                                    [Insurance_Date] [varchar](10) NULL,\r\n\t                                    [Insurance_DateEnd] [varchar](10) NULL,\r\n\t                                    [BirthDate] [varchar](10) NULL,\r\n\t                                    [AutoReturnContr] [bit] NULL,\r\n\t                                    [WorkHours] [float] NULL,\r\n\t                                    [DayOfMonth] [int] NULL,\r\n\t                                    [VacationCount] [int] NULL,\r\n\t                                    [VacationBalance] [float] NULL,\r\n\t                                    [TicketsCount] [float] NULL,\r\n\t                                    [TicketsPrice] [float] NULL,\r\n\t                                    [TicketsBalance] [float] NULL,\r\n\t                                    [IsDesSocialInsurance] [bit] NULL,\r\n\t                                    [SocialInsuranceNo] [varchar](15) NULL,\r\n\t                                    [MainSal] [float] NULL,\r\n\t                                    [HousingAllowance] [float] NULL,\r\n\t                                    [TransferAllowance] [float] NULL,\r\n\t                                    [SubsistenceAllowance] [float] NULL,\r\n\t                                    [NaturalWorkAllowance] [float] NULL,\r\n\t                                    [OtherAllowance] [float] NULL,\r\n\t                                    [DisOneDay] [float] NULL,\r\n\t                                    [LateHours] [float] NULL,\r\n\t                                    [SocialInsuranceComp] [float] NULL,\r\n\t                                    [SocialInsurance] [float] NULL,\r\n\t                                    [InsuranceMedicalCom] [float] NULL,\r\n\t                                    [InsuranceMedical] [float] NULL,\r\n\t                                    [AddDay] [float] NULL,\r\n\t                                    [AddHours] [float] NULL,\r\n\t                                    [MandateDay] [float] NULL,\r\n\t                                    [BankBR] [varchar](30) NULL,\r\n\t                                    [AccountID] [varchar](30) NULL,\r\n\t                                    [ID_No] [varchar](15) NULL,\r\n\t                                    [Passport_No] [varchar](15) NULL,\r\n\t                                    [License_No] [varchar](15) NULL,\r\n\t                                    [Form_No] [varchar](15) NULL,\r\n\t                                    [Insurance_No] [varchar](15) NULL,\r\n\t                                    [AddressA] [varchar](30) NULL,\r\n\t                                    [AddressE] [varchar](30) NULL,\r\n\t                                    [PO_Box] [varchar](10) NULL,\r\n\t                                    [ZipCode] [varchar](15) NULL,\r\n\t                                    [Tel] [varchar](30) NULL,\r\n\t                                    [Email] [varchar](30) NULL,\r\n\t                                    [QualificationA] [varchar](30) NULL,\r\n\t                                    [QualificatioE] [varchar](30) NULL,\r\n\t                                    [ExperiencesA] [varchar](100) NULL,\r\n\t                                    [ExperiencesE] [varchar](100) NULL,\r\n\t                                    [Note] [varchar](30) NULL,\r\n\t                                    [EmpState] [bit] NULL,\r\n\t                                    [EmpPic] [varbinary](max) NULL,\r\n\t                                    [Job] [int] NULL,\r\n\t                                    [Dept] [int] NULL,\r\n\t                                    [Section] [int] NULL,\r\n\t                                    [Guarantor] [int] NULL,\r\n\t                                    [ContrTyp] [int] NULL,\r\n\t                                    [DirBoss] [int] NULL,\r\n\t                                    [StatusSal] [int] NULL,\r\n\t                                    [Bank] [int] NULL,\r\n\t                                    [ID_From] [int] NULL,\r\n\t                                    [Passport_From] [int] NULL,\r\n\t                                    [License_From] [int] NULL,\r\n\t                                    [Form_From] [int] NULL,\r\n\t                                    [Insurance_From] [int] NULL,\r\n\t                                    [Religion] [int] NULL,\r\n\t                                    [Sex] [int] NULL,\r\n\t                                    [Nationalty] [int] NULL,\r\n\t                                    [BloodTyp] [int] NULL,\r\n\t                                    [MaritalStatus] [int] NULL,\r\n\t                                    [BirthPlace] [int] NULL,\r\n\t                                    [CityNo] [int] NULL,\r\n\t                                    [CalculateNo] [int] NULL,\r\n\t                                    [FatherA] [varchar](30) NULL,\r\n\t                                    [GrandFA] [varchar](30) NULL,\r\n\t                                    [FamilyA] [varchar](30) NULL,\r\n\t                                    [FatherE] [varchar](30) NULL,\r\n\t                                    [GrandFE] [varchar](30) NULL,\r\n\t                                    [FamilyE] [varchar](30) NULL,\r\n\t                                    [FirstNameA] [varchar](30) NULL,\r\n\t                                    [FirstNameE] [varchar](30) NULL,\r\n\t                                    [CompanyID] [int] NULL,\r\n                                     CONSTRAINT [PK_T_Emp] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [Emp_ID] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    /****** Object:  Table [dbo].[T_Vacation]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Vacation]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_Vacation](\r\n\t                                    [vacation_ID] [varchar](40) NOT NULL,\r\n\t                                    [warnNo] [int] NOT NULL,\r\n\t                                    [warnDate] [varchar](10) NULL,\r\n\t                                    [EmpID] [varchar](40) NULL,\r\n\t                                    [VacCountDay] [int] NULL,\r\n\t                                    [VacTyp] [int] NULL,\r\n\t                                    [StartDate] [varchar](10) NOT NULL,\r\n\t                                    [EndDate] [varchar](10) NOT NULL,\r\n\t                                    [StopSalFrom] [varchar](10) NULL,\r\n\t                                    [VacAllowance] [bit] NULL,\r\n\t                                    [CalculateNo] [int] NULL,\r\n\t                                    [WithDateSal] [varchar](10) NULL,\r\n\t                                    [Amount] [float] NULL,\r\n\t                                    [Note] [varchar](250) NULL,\r\n\t                                    [IFState] [bit] NULL,\r\n                                     CONSTRAINT [PK_T_Vacation_1] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [warnNo] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    /****** Object:  Table [dbo].[T_Authorization]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Authorization]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_Authorization](\r\n\t                                    [Authorization_ID] [varchar](40) NOT NULL,\r\n\t                                    [Authorization_No] [int] NOT NULL,\r\n\t                                    [Date] [varchar](10) NULL,\r\n\t                                    [EmpID] [varchar](40) NULL,\r\n\t                                    [ExitTime] [varchar](20) NULL,\r\n\t                                    [BackTime] [varchar](20) NULL,\r\n\t                                    [reason] [varchar](250) NULL,\r\n\t                                    [Note] [varchar](250) NULL,\r\n\t                                    [RTime] [varchar](10) NULL,\r\n\t                                    [IFState] [bit] NULL,\r\n                                     CONSTRAINT [PK_T_Authorization] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [Authorization_No] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    /****** Object:  Table [dbo].[T_AttendOperat]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_AttendOperat]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_AttendOperat](\r\n\t                                    [AttendOperat_ID] [varchar](40) NOT NULL,\r\n\t                                    [EmpID] [varchar](40) NULL,\r\n\t                                    [Day] [int] NULL,\r\n\t                                    [Date] [varchar](10) NULL,\r\n\t                                    [ComeTime] [varchar](20) NULL,\r\n\t                                    [LateTime] [float] NULL,\r\n\t                                    [Time1] [varchar](20) NULL,\r\n\t                                    [Time2] [varchar](20) NULL,\r\n\t                                    [LeaveTime] [varchar](20) NULL,\r\n\t                                    [LeaveTime2] [varchar](20) NULL,\r\n\t                                    [Note] [varchar](50) NULL,\r\n\t                                    [Operation] [varchar](10) NULL,\r\n                                     CONSTRAINT [PK_T_AttendOperat] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [AttendOperat_ID] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    /****** Object:  Table [dbo].[T_Attend]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Attend]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_Attend](\r\n\t                                    [Attend_ID] [varchar](40) NOT NULL,\r\n\t                                    [EmpID] [varchar](40) NULL,\r\n\t                                    [Day_No] [int] NULL,\r\n\t                                    [Periods] [int] NULL,\r\n\t                                    [Time1] [varchar](10) NULL,\r\n\t                                    [TimeAllow1] [varchar](10) NULL,\r\n\t                                    [LeaveTime1] [varchar](10) NULL,\r\n\t                                    [Time2] [varchar](10) NULL,\r\n\t                                    [TimeAlow2] [varchar](10) NULL,\r\n\t                                    [LeaveTime2] [varchar](10) NULL,\r\n                                     CONSTRAINT [PK_T_Attend] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [Attend_ID] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    /****** Object:  Table [dbo].[T_Advances]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Advances]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_Advances](\r\n\t                                    [Advances_ID] [varchar](40) NOT NULL,\r\n\t                                    [Advances_No] [int] NOT NULL,\r\n\t                                    [ResolutionNo] [varchar](10) NULL,\r\n\t                                    [ResolutionDate] [varchar](10) NULL,\r\n\t                                    [EmpID] [varchar](40) NULL,\r\n\t                                    [Salary] [float] NULL,\r\n\t                                    [SalDate] [varchar](10) NULL,\r\n\t                                    [ValueAdvances] [float] NULL,\r\n\t                                    [Remaining] [float] NULL,\r\n\t                                    [TotalPremiums] [int] NULL,\r\n\t                                    [ValuePremium] [float] NULL,\r\n\t                                    [ValuePremiumEdit] [float] NULL,\r\n\t                                    [Note] [varchar](250) NULL,\r\n                                     CONSTRAINT [PK_T_Advances_1] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [Advances_No] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    /****** Object:  Table [dbo].[T_Family]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Family]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_Family](\r\n\t                                    [Family_ID] [varchar](40) NOT NULL,\r\n\t                                    [Person_No] [int] NOT NULL,\r\n\t                                    [EmpID] [varchar](40) NOT NULL,\r\n\t                                    [Name] [varchar](20) NULL,\r\n\t                                    [BirthDay] [varchar](10) NULL,\r\n\t                                    [Link] [varchar](20) NULL,\r\n\t                                    [PassNo] [varchar](15) NULL,\r\n\t                                    [PassEnd] [varchar](10) NULL,\r\n                                     CONSTRAINT [PK_T_Family] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [Person_No] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    /****** Object:  Table [dbo].[T_EndService]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_EndService]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_EndService](\r\n\t                                    [EndService_ID] [varchar](40) NOT NULL,\r\n\t                                    [warnNo] [int] NOT NULL,\r\n\t                                    [EmpID] [varchar](40) NOT NULL,\r\n\t                                    [warnDate] [varchar](10) NULL,\r\n\t                                    [CauseLiquidation] [int] NULL,\r\n\t                                    [DateAppointment] [varchar](10) NULL,\r\n\t                                    [LastFilter] [varchar](10) NULL,\r\n\t                                    [Salary] [float] NULL,\r\n\t                                    [DateFilter] [varchar](10) NULL,\r\n\t                                    [Years] [int] NULL,\r\n\t                                    [Months] [int] NULL,\r\n\t                                    [Days] [int] NULL,\r\n\t                                    [ServLess] [int] NULL,\r\n\t                                    [LessWorth] [int] NULL,\r\n\t                                    [ServMore] [int] NULL,\r\n\t                                    [AndLess] [int] NULL,\r\n\t                                    [LessMoreWorth] [int] NULL,\r\n\t                                    [ServMoreOnly] [int] NULL,\r\n\t                                    [MoreWorth] [int] NULL,\r\n\t                                    [IFState] [bit] NULL,\r\n\t                                    [GenTotal] [float] NULL,\r\n\t                                    [ISCalculatTicketVal] [bit] NULL,\r\n\t                                    [ValueAdvances] [float] NULL,\r\n\t                                    [Paid] [float] NULL,\r\n\t                                    [Remaining] [float] NULL,\r\n\t                                    [WagesDetails] [varchar](max) NULL,\r\n\t                                    [Note] [varchar](50) NULL,\r\n\t                                    [EAdvancesRemainning] [float] NULL,\r\n\t                                    [EWagesValue] [float] NULL,\r\n\t                                    [eEndServisValue] [float] NULL,\r\n\t                                    [TicketCount] [float] NULL,\r\n\t                                    [Tickets] [float] NULL,\r\n\t                                    [TicketUsed] [float] NULL,\r\n\t                                    [TicketBalance] [float] NULL,\r\n\t                                    [TicketValue] [float] NULL,\r\n\t                                    [TicketTotal] [float] NULL,\r\n\t                                    [VacDayCount] [int] NULL,\r\n\t                                    [VacUsed] [float] NULL,\r\n\t                                    [VacAcout] [float] NULL,\r\n\t                                    [VacBalance] [float] NULL,\r\n\t                                    [VacTotal] [float] NULL,\r\n                                     CONSTRAINT [PK_T_EndService_1] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [warnNo] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    /****** Object:  Table [dbo].[T_SalDiscount]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_SalDiscount]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_SalDiscount](\r\n\t                                    [Discont_ID] [varchar](40) NOT NULL,\r\n\t                                    [warnNo] [int] NOT NULL,\r\n\t                                    [warnDate] [varchar](10) NULL,\r\n\t                                    [SubTyp] [int] NULL,\r\n\t                                    [SalDate] [varchar](10) NULL,\r\n\t                                    [CalculateNo] [int] NULL,\r\n\t                                    [DayOfMonth] [int] NULL,\r\n\t                                    [EmpID] [varchar](40) NULL,\r\n\t                                    [ACount] [float] NULL,\r\n\t                                    [SubValue] [float] NULL,\r\n\t                                    [SubTotaly] [float] NULL,\r\n\t                                    [Note] [varchar](250) NULL,\r\n\t                                    [IFState] [bit] NULL,\r\n                                     CONSTRAINT [PK_T_SalDiscount_1] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [warnNo] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    /****** Object:  Table [dbo].[T_Salary]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Salary]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_Salary](\r\n\t                                    [SalaryID] [varchar](40) NOT NULL,\r\n\t                                    [EmpID] [varchar](40) NOT NULL,\r\n\t                                    [SalMonth] [int] NULL,\r\n\t                                    [SalYear] [int] NULL,\r\n\t                                    [DirBoss] [int] NULL,\r\n\t                                    [DeptNo] [int] NULL,\r\n\t                                    [Job] [int] NULL,\r\n\t                                    [Salary] [float] NULL,\r\n\t                                    [HousingAllowance] [float] NULL,\r\n\t                                    [TransferAllowance] [float] NULL,\r\n\t                                    [OtherAllowance] [float] NULL,\r\n\t                                    [SubDay] [float] NULL,\r\n\t                                    [LateHours] [float] NULL,\r\n\t                                    [SubJaza] [float] NULL,\r\n\t                                    [SubOther] [float] NULL,\r\n\t                                    [MandateDay] [float] NULL,\r\n\t                                    [SocialInsuranceComp] [float] NULL,\r\n\t                                    [SocialInsurance] [float] NULL,\r\n\t                                    [InsuranceMedicalCom] [float] NULL,\r\n\t                                    [InsuranceMedical] [float] NULL,\r\n\t                                    [Advance] [float] NULL,\r\n\t                                    [Rewards] [float] NULL,\r\n\t                                    [Bank] [int] NULL,\r\n\t                                    [AccountNo] [varchar](30) NULL,\r\n\t                                    [SalaryStatus] [bit] NULL,\r\n\t                                    [IsPrint] [bit] NULL,\r\n\t                                    [SalSpell] [varchar](max) NULL,\r\n\t                                    [AddDay] [float] NULL,\r\n\t                                    [AddHour] [float] NULL,\r\n\t                                    [SectionNo] [int] NULL,\r\n                                     CONSTRAINT [PK_T_Salary] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [SalaryID] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    /****** Object:  Table [dbo].[T_Rewards]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Rewards]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_Rewards](\r\n\t                                    [Reward_ID] [varchar](40) NOT NULL,\r\n\t                                    [Reward_No] [int] NOT NULL,\r\n\t                                    [RewardDate] [varchar](10) NULL,\r\n\t                                    [EmpID] [varchar](40) NULL,\r\n\t                                    [SalDate] [varchar](10) NULL,\r\n\t                                    [RewardValue] [float] NULL,\r\n\t                                    [Note] [varchar](250) NULL,\r\n\t                                    [IFState] [bit] NULL,\r\n                                     CONSTRAINT [PK_T_Rewards] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [Reward_No] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    /****** Object:  Table [dbo].[T_Tickets]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Tickets]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_Tickets](\r\n\t                                    [Ticket_ID] [varchar](40) NOT NULL,\r\n\t                                    [warnNo] [int] NOT NULL,\r\n\t                                    [warnDate] [varchar](10) NULL,\r\n\t                                    [EmpID] [varchar](40) NULL,\r\n\t                                    [GoLine] [varchar](50) NULL,\r\n\t                                    [TickTyp] [int] NULL,\r\n\t                                    [TicketValue] [float] NULL,\r\n\t                                    [TicketCount] [float] NULL,\r\n\t                                    [AllTicketValue] [float] NULL,\r\n\t                                    [Note] [varchar](250) NULL,\r\n\t                                    [IFState] [bit] NULL,\r\n                                     CONSTRAINT [PK_T_Tickets_1] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [warnNo] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    /****** Object:  Table [dbo].[T_Add]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Add]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_Add](\r\n\t                                    [Add_ID] [varchar](40) NOT NULL,\r\n\t                                    [warnNo] [int] NOT NULL,\r\n\t                                    [EmpID] [varchar](40) NULL,\r\n\t                                    [warnDate] [varchar](10) NULL,\r\n\t                                    [SalDate] [varchar](10) NULL,\r\n\t                                    [CalculateNo] [int] NULL,\r\n\t                                    [AddTyp] [int] NULL,\r\n\t                                    [DayOfMonth] [int] NULL,\r\n\t                                    [CountDay] [float] NULL,\r\n\t                                    [AddValue] [float] NULL,\r\n\t                                    [AddTotaly] [float] NULL,\r\n\t                                    [Note] [varchar](250) NULL,\r\n\t                                    [IFState] [bit] NULL,\r\n                                     CONSTRAINT [PK_T_Add_1] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [warnNo] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    /****** Object:  Table [dbo].[T_Premiums]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    SET ANSI_PADDING ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Premiums]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_Premiums](\r\n\t                                    [Premiums_ID] [varchar](40) NOT NULL,\r\n\t                                    [Premiums_No] [int] NOT NULL,\r\n\t                                    [Advances_No] [int] NULL,\r\n\t                                    [PremiumsDate] [varchar](10) NULL,\r\n\t                                    [ValuePremiums] [float] NULL,\r\n\t                                    [Paying] [float] NULL,\r\n\t                                    [IFState] [bit] NULL,\r\n                                     CONSTRAINT [PK_T_Premiums] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [Premiums_ID] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    END\r\n                                    GO\r\n                                    SET ANSI_PADDING OFF\r\n                                    GO\r\n                                    /****** Object:  UserDefinedFunction [dbo].[GetVacUsed]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetVacUsed]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))\r\n                                    BEGIN\r\n                                    execute dbo.sp_executesql @statement = N'\r\n                                    CREATE FUNCTION [dbo].[GetVacUsed](@EmpID varchar(40))\r\n                                    RETURNS INT\r\n                                    WITH EXECUTE AS CALLER\r\n                                    AS\r\n                                    begin\r\n\t                                    DECLARE @valueIn int;\r\n\t                                    DECLARE @value int;\r\n\t\t                                    set @valueIn = ISNull((SELECT sum(VacCountDay) from T_Vacation join T_VacTyp on T_Vacation.VacTyp = T_VacTyp.VacT_No Where T_Vacation.EmpID=@EmpID AND T_VacTyp.Dis_VacT = 1),''0'')\r\n\r\n\t                                    set @value = @valueIn ;\r\n\t                                    return (@value);\r\n                                    end\r\n\r\n                                    ' \r\n                                    END\r\n                                    GO\r\n                                    /****** Object:  UserDefinedFunction [dbo].[GetTickeUsed]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    GO\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    GO\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetTickeUsed]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))\r\n                                    BEGIN\r\n                                    execute dbo.sp_executesql @statement = N'\r\n                                    CREATE FUNCTION [dbo].[GetTickeUsed] (@EmpID varchar(40))\r\n                                    RETURNS Float\r\n                                    WITH EXECUTE AS CALLER\r\n                                    AS\r\n                                    begin\r\n\t                                    DECLARE @valueIn int;\r\n\t                                    DECLARE @value int;\r\n\t\t                                    set @valueIn = ISNull((SELECT sum(TicketCount) from T_Tickets Where EmpID=@EmpID),''0'')\r\n\r\n\t                                    set @value = @valueIn ;\r\n\t                                    return (@value);\r\n                                    end\r\n\r\n                                    ' \r\n                                    END\r\n                                    GO\r\n                                    /****** Object:  Default [DF_T_Salary_SalaryStatus]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_T_Salary_SalaryStatus]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Salary]'))\r\n                                    Begin\r\n                                    IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_Salary_SalaryStatus]') AND type = 'D')\r\n                                    BEGIN\r\n                                    ALTER TABLE [dbo].[T_Salary] ADD  CONSTRAINT [DF_T_Salary_SalaryStatus]  DEFAULT ((0)) FOR [SalaryStatus]\r\n                                    END\r\n\r\n\r\n                                    End\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Info_T_OpMethod]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Info_T_OpMethod]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Info]'))\r\n                                    ALTER TABLE [dbo].[T_Info]  WITH CHECK ADD  CONSTRAINT [FK_T_Info_T_OpMethod] FOREIGN KEY([CalculateNo])\r\n                                    REFERENCES [dbo].[T_OpMethod] ([Method_No])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Info_T_OpMethod]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Info]'))\r\n                                    ALTER TABLE [dbo].[T_Info] CHECK CONSTRAINT [FK_T_Info_T_OpMethod]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Info_T_OpMethod1]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Info_T_OpMethod1]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Info]'))\r\n                                    ALTER TABLE [dbo].[T_Info]  WITH CHECK ADD  CONSTRAINT [FK_T_Info_T_OpMethod1] FOREIGN KEY([CalculatliquidNo])\r\n                                    REFERENCES [dbo].[T_OpMethod] ([Method_No])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Info_T_OpMethod1]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Info]'))\r\n                                    ALTER TABLE [dbo].[T_Info] CHECK CONSTRAINT [FK_T_Info_T_OpMethod1]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Emp_T_Bank]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_Bank]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_Bank] FOREIGN KEY([Bank])\r\n                                    REFERENCES [dbo].[T_Bank] ([Bank_No])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_Bank]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_Bank]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Emp_T_BloodTyp]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_BloodTyp]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_BloodTyp] FOREIGN KEY([BloodTyp])\r\n                                    REFERENCES [dbo].[T_BloodTyp] ([BloodTyp_No])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_BloodTyp]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_BloodTyp]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Emp_T_City]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_City]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_City] FOREIGN KEY([CityNo])\r\n                                    REFERENCES [dbo].[T_City] ([City_No])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_City]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_City]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Emp_T_City1]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_City1]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_City1] FOREIGN KEY([ID_From])\r\n                                    REFERENCES [dbo].[T_City] ([City_No])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_City1]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_City1]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Emp_T_City2]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_City2]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_City2] FOREIGN KEY([Passport_From])\r\n                                    REFERENCES [dbo].[T_City] ([City_No])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_City2]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_City2]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Emp_T_City3]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_City3]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_City3] FOREIGN KEY([License_From])\r\n                                    REFERENCES [dbo].[T_City] ([City_No])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_City3]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_City3]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Emp_T_City4]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_City4]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_City4] FOREIGN KEY([Form_From])\r\n                                    REFERENCES [dbo].[T_City] ([City_No])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_City4]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_City4]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Emp_T_City5]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_City5]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_City5] FOREIGN KEY([Insurance_From])\r\n                                    REFERENCES [dbo].[T_City] ([City_No])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_City5]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_City5]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Emp_T_City6]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_City6]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_City6] FOREIGN KEY([BirthPlace])\r\n                                    REFERENCES [dbo].[T_City] ([City_No])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_City6]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_City6]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Emp_T_Contract]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_Contract]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_Contract] FOREIGN KEY([ContrTyp])\r\n                                    REFERENCES [dbo].[T_Contract] ([Contract_No])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_Contract]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_Contract]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Emp_T_Dept]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_Dept]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_Dept] FOREIGN KEY([Dept])\r\n                                    REFERENCES [dbo].[T_Dept] ([Dept_No])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_Dept]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_Dept]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Emp_T_Guarantor]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_Guarantor]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_Guarantor] FOREIGN KEY([Guarantor])\r\n                                    REFERENCES [dbo].[T_Guarantor] ([Guarantor_No])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_Guarantor]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_Guarantor]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Emp_T_Info]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_Info]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_Info] FOREIGN KEY([CompanyID])\r\n                                    REFERENCES [dbo].[T_Info] ([Company_ID])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_Info]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_Info]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Emp_T_Job]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_Job]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_Job] FOREIGN KEY([Job])\r\n                                    REFERENCES [dbo].[T_Job] ([Job_No])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_Job]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_Job]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Emp_T_MStatus]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_MStatus]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_MStatus] FOREIGN KEY([MaritalStatus])\r\n                                    REFERENCES [dbo].[T_MStatus] ([MStatusNo])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_MStatus]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_MStatus]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Emp_T_Nationalities]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_Nationalities]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_Nationalities] FOREIGN KEY([Nationalty])\r\n                                    REFERENCES [dbo].[T_Nationalities] ([Nation_No])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_Nationalities]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_Nationalities]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Emp_T_OpMethod]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_OpMethod]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_OpMethod] FOREIGN KEY([CalculateNo])\r\n                                    REFERENCES [dbo].[T_OpMethod] ([Method_No])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_OpMethod]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_OpMethod]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Emp_T_Religion]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_Religion]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_Religion] FOREIGN KEY([Religion])\r\n                                    REFERENCES [dbo].[T_Religion] ([Religion_No])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_Religion]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_Religion]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Emp_T_SalStatus]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_SalStatus]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_SalStatus] FOREIGN KEY([StatusSal])\r\n                                    REFERENCES [dbo].[T_SalStatus] ([SalStatusNo])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_SalStatus]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_SalStatus]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Emp_T_Section]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_Section]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_Section] FOREIGN KEY([Section])\r\n                                    REFERENCES [dbo].[T_Section] ([Section_No])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_Section]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_Section]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Emp_T_Sex]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_Sex]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_Sex] FOREIGN KEY([Sex])\r\n                                    REFERENCES [dbo].[T_Sex] ([SexNo])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Emp_T_Sex]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Emp]'))\r\n                                    ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_Sex]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Vacation_T_Emp]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Vacation_T_Emp]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Vacation]'))\r\n                                    ALTER TABLE [dbo].[T_Vacation]  WITH CHECK ADD  CONSTRAINT [FK_T_Vacation_T_Emp] FOREIGN KEY([EmpID])\r\n                                    REFERENCES [dbo].[T_Emp] ([Emp_ID])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Vacation_T_Emp]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Vacation]'))\r\n                                    ALTER TABLE [dbo].[T_Vacation] CHECK CONSTRAINT [FK_T_Vacation_T_Emp]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Vacation_T_OpMethod]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Vacation_T_OpMethod]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Vacation]'))\r\n                                    ALTER TABLE [dbo].[T_Vacation]  WITH CHECK ADD  CONSTRAINT [FK_T_Vacation_T_OpMethod] FOREIGN KEY([CalculateNo])\r\n                                    REFERENCES [dbo].[T_OpMethod] ([Method_No])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Vacation_T_OpMethod]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Vacation]'))\r\n                                    ALTER TABLE [dbo].[T_Vacation] CHECK CONSTRAINT [FK_T_Vacation_T_OpMethod]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Vacation_T_VacTyp]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Vacation_T_VacTyp]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Vacation]'))\r\n                                    ALTER TABLE [dbo].[T_Vacation]  WITH CHECK ADD  CONSTRAINT [FK_T_Vacation_T_VacTyp] FOREIGN KEY([VacTyp])\r\n                                    REFERENCES [dbo].[T_VacTyp] ([VacT_No])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Vacation_T_VacTyp]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Vacation]'))\r\n                                    ALTER TABLE [dbo].[T_Vacation] CHECK CONSTRAINT [FK_T_Vacation_T_VacTyp]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Authorization_T_Emp]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Authorization_T_Emp]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Authorization]'))\r\n                                    ALTER TABLE [dbo].[T_Authorization]  WITH CHECK ADD  CONSTRAINT [FK_T_Authorization_T_Emp] FOREIGN KEY([EmpID])\r\n                                    REFERENCES [dbo].[T_Emp] ([Emp_ID])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Authorization_T_Emp]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Authorization]'))\r\n                                    ALTER TABLE [dbo].[T_Authorization] CHECK CONSTRAINT [FK_T_Authorization_T_Emp]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_AttendOperat_T_DayOfWeek]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_AttendOperat_T_DayOfWeek]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_AttendOperat]'))\r\n                                    ALTER TABLE [dbo].[T_AttendOperat]  WITH CHECK ADD  CONSTRAINT [FK_T_AttendOperat_T_DayOfWeek] FOREIGN KEY([Day])\r\n                                    REFERENCES [dbo].[T_DayOfWeek] ([Day_No])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_AttendOperat_T_DayOfWeek]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_AttendOperat]'))\r\n                                    ALTER TABLE [dbo].[T_AttendOperat] CHECK CONSTRAINT [FK_T_AttendOperat_T_DayOfWeek]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_AttendOperat_T_Emp]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_AttendOperat_T_Emp]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_AttendOperat]'))\r\n                                    ALTER TABLE [dbo].[T_AttendOperat]  WITH CHECK ADD  CONSTRAINT [FK_T_AttendOperat_T_Emp] FOREIGN KEY([EmpID])\r\n                                    REFERENCES [dbo].[T_Emp] ([Emp_ID])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_AttendOperat_T_Emp]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_AttendOperat]'))\r\n                                    ALTER TABLE [dbo].[T_AttendOperat] CHECK CONSTRAINT [FK_T_AttendOperat_T_Emp]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Attend_T_DayOfWeek]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Attend_T_DayOfWeek]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Attend]'))\r\n                                    ALTER TABLE [dbo].[T_Attend]  WITH CHECK ADD  CONSTRAINT [FK_T_Attend_T_DayOfWeek] FOREIGN KEY([Day_No])\r\n                                    REFERENCES [dbo].[T_DayOfWeek] ([Day_No])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Attend_T_DayOfWeek]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Attend]'))\r\n                                    ALTER TABLE [dbo].[T_Attend] CHECK CONSTRAINT [FK_T_Attend_T_DayOfWeek]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Attend_T_Emp]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Attend_T_Emp]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Attend]'))\r\n                                    ALTER TABLE [dbo].[T_Attend]  WITH CHECK ADD  CONSTRAINT [FK_T_Attend_T_Emp] FOREIGN KEY([EmpID])\r\n                                    REFERENCES [dbo].[T_Emp] ([Emp_ID])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Attend_T_Emp]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Attend]'))\r\n                                    ALTER TABLE [dbo].[T_Attend] CHECK CONSTRAINT [FK_T_Attend_T_Emp]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Advances_T_Emp]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Advances_T_Emp]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Advances]'))\r\n                                    ALTER TABLE [dbo].[T_Advances]  WITH CHECK ADD  CONSTRAINT [FK_T_Advances_T_Emp] FOREIGN KEY([EmpID])\r\n                                    REFERENCES [dbo].[T_Emp] ([Emp_ID])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Advances_T_Emp]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Advances]'))\r\n                                    ALTER TABLE [dbo].[T_Advances] CHECK CONSTRAINT [FK_T_Advances_T_Emp]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Family_T_Emp1]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Family_T_Emp1]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Family]'))\r\n                                    ALTER TABLE [dbo].[T_Family]  WITH CHECK ADD  CONSTRAINT [FK_T_Family_T_Emp1] FOREIGN KEY([EmpID])\r\n                                    REFERENCES [dbo].[T_Emp] ([Emp_ID])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Family_T_Emp1]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Family]'))\r\n                                    ALTER TABLE [dbo].[T_Family] CHECK CONSTRAINT [FK_T_Family_T_Emp1]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_EndService_T_Emp]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_EndService_T_Emp]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_EndService]'))\r\n                                    ALTER TABLE [dbo].[T_EndService]  WITH CHECK ADD  CONSTRAINT [FK_T_EndService_T_Emp] FOREIGN KEY([EmpID])\r\n                                    REFERENCES [dbo].[T_Emp] ([Emp_ID])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_EndService_T_Emp]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_EndService]'))\r\n                                    ALTER TABLE [dbo].[T_EndService] CHECK CONSTRAINT [FK_T_EndService_T_Emp]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_EndService_T_LiquidationTyp]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_EndService_T_LiquidationTyp]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_EndService]'))\r\n                                    ALTER TABLE [dbo].[T_EndService]  WITH CHECK ADD  CONSTRAINT [FK_T_EndService_T_LiquidationTyp] FOREIGN KEY([CauseLiquidation])\r\n                                    REFERENCES [dbo].[T_LiquidationTyp] ([LiquidationT_No])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_EndService_T_LiquidationTyp]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_EndService]'))\r\n                                    ALTER TABLE [dbo].[T_EndService] CHECK CONSTRAINT [FK_T_EndService_T_LiquidationTyp]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_SalDiscount_T_Emp]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_SalDiscount_T_Emp]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_SalDiscount]'))\r\n                                    ALTER TABLE [dbo].[T_SalDiscount]  WITH CHECK ADD  CONSTRAINT [FK_T_SalDiscount_T_Emp] FOREIGN KEY([EmpID])\r\n                                    REFERENCES [dbo].[T_Emp] ([Emp_ID])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_SalDiscount_T_Emp]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_SalDiscount]'))\r\n                                    ALTER TABLE [dbo].[T_SalDiscount] CHECK CONSTRAINT [FK_T_SalDiscount_T_Emp]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_SalDiscount_T_OpMethod]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_SalDiscount_T_OpMethod]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_SalDiscount]'))\r\n                                    ALTER TABLE [dbo].[T_SalDiscount]  WITH CHECK ADD  CONSTRAINT [FK_T_SalDiscount_T_OpMethod] FOREIGN KEY([CalculateNo])\r\n                                    REFERENCES [dbo].[T_OpMethod] ([Method_No])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_SalDiscount_T_OpMethod]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_SalDiscount]'))\r\n                                    ALTER TABLE [dbo].[T_SalDiscount] CHECK CONSTRAINT [FK_T_SalDiscount_T_OpMethod]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_SalDiscount_T_SubTyp]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_SalDiscount_T_SubTyp]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_SalDiscount]'))\r\n                                    ALTER TABLE [dbo].[T_SalDiscount]  WITH CHECK ADD  CONSTRAINT [FK_T_SalDiscount_T_SubTyp] FOREIGN KEY([SubTyp])\r\n                                    REFERENCES [dbo].[T_SubTyp] ([SubNo])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_SalDiscount_T_SubTyp]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_SalDiscount]'))\r\n                                    ALTER TABLE [dbo].[T_SalDiscount] CHECK CONSTRAINT [FK_T_SalDiscount_T_SubTyp]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Salary_T_Bank]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Salary_T_Bank]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Salary]'))\r\n                                    ALTER TABLE [dbo].[T_Salary]  WITH CHECK ADD  CONSTRAINT [FK_T_Salary_T_Bank] FOREIGN KEY([Bank])\r\n                                    REFERENCES [dbo].[T_Bank] ([Bank_No])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Salary_T_Bank]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Salary]'))\r\n                                    ALTER TABLE [dbo].[T_Salary] CHECK CONSTRAINT [FK_T_Salary_T_Bank]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Salary_T_Dept]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Salary_T_Dept]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Salary]'))\r\n                                    ALTER TABLE [dbo].[T_Salary]  WITH CHECK ADD  CONSTRAINT [FK_T_Salary_T_Dept] FOREIGN KEY([DeptNo])\r\n                                    REFERENCES [dbo].[T_Dept] ([Dept_No])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Salary_T_Dept]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Salary]'))\r\n                                    ALTER TABLE [dbo].[T_Salary] CHECK CONSTRAINT [FK_T_Salary_T_Dept]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Salary_T_Emp]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Salary_T_Emp]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Salary]'))\r\n                                    ALTER TABLE [dbo].[T_Salary]  WITH CHECK ADD  CONSTRAINT [FK_T_Salary_T_Emp] FOREIGN KEY([EmpID])\r\n                                    REFERENCES [dbo].[T_Emp] ([Emp_ID])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Salary_T_Emp]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Salary]'))\r\n                                    ALTER TABLE [dbo].[T_Salary] CHECK CONSTRAINT [FK_T_Salary_T_Emp]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Salary_T_Guarantor]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Salary_T_Guarantor]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Salary]'))\r\n                                    ALTER TABLE [dbo].[T_Salary]  WITH CHECK ADD  CONSTRAINT [FK_T_Salary_T_Guarantor] FOREIGN KEY([DirBoss])\r\n                                    REFERENCES [dbo].[T_Guarantor] ([Guarantor_No])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Salary_T_Guarantor]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Salary]'))\r\n                                    ALTER TABLE [dbo].[T_Salary] CHECK CONSTRAINT [FK_T_Salary_T_Guarantor]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Salary_T_Job]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Salary_T_Job]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Salary]'))\r\n                                    ALTER TABLE [dbo].[T_Salary]  WITH CHECK ADD  CONSTRAINT [FK_T_Salary_T_Job] FOREIGN KEY([Job])\r\n                                    REFERENCES [dbo].[T_Job] ([Job_No])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Salary_T_Job]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Salary]'))\r\n                                    ALTER TABLE [dbo].[T_Salary] CHECK CONSTRAINT [FK_T_Salary_T_Job]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Salary_T_Section]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Salary_T_Section]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Salary]'))\r\n                                    ALTER TABLE [dbo].[T_Salary]  WITH CHECK ADD  CONSTRAINT [FK_T_Salary_T_Section] FOREIGN KEY([SectionNo])\r\n                                    REFERENCES [dbo].[T_Section] ([Section_No])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Salary_T_Section]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Salary]'))\r\n                                    ALTER TABLE [dbo].[T_Salary] CHECK CONSTRAINT [FK_T_Salary_T_Section]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Rewards_T_Emp]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Rewards_T_Emp]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Rewards]'))\r\n                                    ALTER TABLE [dbo].[T_Rewards]  WITH CHECK ADD  CONSTRAINT [FK_T_Rewards_T_Emp] FOREIGN KEY([EmpID])\r\n                                    REFERENCES [dbo].[T_Emp] ([Emp_ID])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Rewards_T_Emp]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Rewards]'))\r\n                                    ALTER TABLE [dbo].[T_Rewards] CHECK CONSTRAINT [FK_T_Rewards_T_Emp]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Rewards_T_Emp1]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Rewards_T_Emp1]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Rewards]'))\r\n                                    ALTER TABLE [dbo].[T_Rewards]  WITH CHECK ADD  CONSTRAINT [FK_T_Rewards_T_Emp1] FOREIGN KEY([EmpID])\r\n                                    REFERENCES [dbo].[T_Emp] ([Emp_ID])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Rewards_T_Emp1]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Rewards]'))\r\n                                    ALTER TABLE [dbo].[T_Rewards] CHECK CONSTRAINT [FK_T_Rewards_T_Emp1]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Tickets_T_Emp]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Tickets_T_Emp]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Tickets]'))\r\n                                    ALTER TABLE [dbo].[T_Tickets]  WITH CHECK ADD  CONSTRAINT [FK_T_Tickets_T_Emp] FOREIGN KEY([EmpID])\r\n                                    REFERENCES [dbo].[T_Emp] ([Emp_ID])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Tickets_T_Emp]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Tickets]'))\r\n                                    ALTER TABLE [dbo].[T_Tickets] CHECK CONSTRAINT [FK_T_Tickets_T_Emp]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Tickets_T_TicetTyp]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Tickets_T_TicetTyp]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Tickets]'))\r\n                                    ALTER TABLE [dbo].[T_Tickets]  WITH CHECK ADD  CONSTRAINT [FK_T_Tickets_T_TicetTyp] FOREIGN KEY([TickTyp])\r\n                                    REFERENCES [dbo].[T_TicetTyp] ([TicetT_No])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Tickets_T_TicetTyp]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Tickets]'))\r\n                                    ALTER TABLE [dbo].[T_Tickets] CHECK CONSTRAINT [FK_T_Tickets_T_TicetTyp]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Add_T_Emp]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Add_T_Emp]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Add]'))\r\n                                    ALTER TABLE [dbo].[T_Add]  WITH CHECK ADD  CONSTRAINT [FK_T_Add_T_Emp] FOREIGN KEY([EmpID])\r\n                                    REFERENCES [dbo].[T_Emp] ([Emp_ID])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Add_T_Emp]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Add]'))\r\n                                    ALTER TABLE [dbo].[T_Add] CHECK CONSTRAINT [FK_T_Add_T_Emp]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Add_T_OpMethod]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Add_T_OpMethod]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Add]'))\r\n                                    ALTER TABLE [dbo].[T_Add]  WITH CHECK ADD  CONSTRAINT [FK_T_Add_T_OpMethod] FOREIGN KEY([CalculateNo])\r\n                                    REFERENCES [dbo].[T_OpMethod] ([Method_No])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Add_T_OpMethod]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Add]'))\r\n                                    ALTER TABLE [dbo].[T_Add] CHECK CONSTRAINT [FK_T_Add_T_OpMethod]\r\n                                    GO\r\n                                    /****** Object:  ForeignKey [FK_T_Premiums_T_Advances]    Script Date: 08/15/2014 07:50:31 ******/\r\n                                    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Premiums_T_Advances]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Premiums]'))\r\n                                    ALTER TABLE [dbo].[T_Premiums]  WITH CHECK ADD  CONSTRAINT [FK_T_Premiums_T_Advances] FOREIGN KEY([Advances_No])\r\n                                    REFERENCES [dbo].[T_Advances] ([Advances_No])\r\n                                    GO\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Premiums_T_Advances]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Premiums]'))\r\n                                    ALTER TABLE [dbo].[T_Premiums] CHECK CONSTRAINT [FK_T_Premiums_T_Advances]\r\n                                    GO".Replace("GO", ""));
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE [dbo].[T_Emp] drop constraint [FK_T_Emp_T_City6]");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_BirthPlace] FOREIGN KEY([BirthPlace])\r\n                                        REFERENCES [dbo].[T_BirthPlace] ([BirthPlaceNo])\r\n                                        ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_BirthPlace]");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Info ADD  [ShowEmpNo] [bit] NULL");
                        db.ExecuteCommand("Update [dbo].[T_Info] Set [ShowEmpNo] = 0 ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Info ADD  [ShowSigne] [bit] NULL");
                        db.ExecuteCommand("Update [dbo].[T_Info] Set [ShowSigne] = 1 ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Info ADD  [CalculateAddDis] [int] NULL");
                        db.ExecuteCommand("Update [dbo].[T_Info] Set [CalculateAddDis] = 0 ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Add ADD  [MinuteTyp] [bit] NULL");
                        db.ExecuteCommand("Update [dbo].[T_Add] Set [MinuteTyp] = 0 ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_SalDiscount ADD  [MinuteTyp] [bit] NULL");
                        db.ExecuteCommand("Update [dbo].[T_SalDiscount] Set [MinuteTyp] = 0 ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Salary ADD  [GadeId2] [float] NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Emp ADD  [SalAcc] [varchar](30) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Emp ADD  [LoanAcc] [varchar](30) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Emp ADD  [HouseAcc] [varchar](30) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Salary ADD  [SalAcc] [varchar](30) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Salary ADD  [SubCallPhone] [float] NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Salary ADD  [SubCommentary] [float] NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Salary ADD  [LoanAcc] [varchar](30) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Salary ADD  [HouseAcc] [varchar](30) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Salary ADD  [fGUID] [varchar](40) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Emp ADD  [Allowances] [int] NULL");
                        db.ExecuteCommand("Update [dbo].[T_Emp] Set [Allowances] = 1 ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Emp ADD  [AllowancesTime] [int] NULL");
                        db.ExecuteCommand("Update [dbo].[T_Emp] Set [AllowancesTime] = 0 ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Advances ADD  [LoanAcc] [varchar](30) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Advances ADD  [fGUID] [varchar](40) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Salary ADD  [Total] [float] NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Dept ADD  [BossName] [varchar](30) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Dept ADD  [Phone] [varchar](15) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Dept ADD  [Fax] [varchar](15) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Section ADD  [BossName] [varchar](30) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Section ADD  [Phone] [varchar](15) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Section ADD  [Fax] [varchar](15) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Guarantor ADD  [MdniNo] [varchar](20) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Guarantor ADD  [MdniBeginDate] [varchar](20) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Guarantor ADD  [MdniEndDate] [varchar](20) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Guarantor ADD  [BusnisNo] [varchar](20) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Guarantor ADD [BusnisBeginDate] [varchar](20) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Guarantor ADD [BusnisEndDate] [varchar](20) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Guarantor ADD [MdniNo] [varchar](20) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Guarantor ADD [BusnisNo] [varchar](20) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Guarantor ADD [BusnisFrom] [varchar](20) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Guarantor ADD [MdniFrom] [varchar](20) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("/****** Object:  Table [dbo].[T_CarTyp]    Script Date: 08/16/2014 03:49:23 ******/\r\n                                SET ANSI_NULLS ON\r\n                                SET QUOTED_IDENTIFIER ON\r\n                                SET ANSI_PADDING ON\r\n                                CREATE TABLE [dbo].[T_CarTyp](\r\n\t                                [CarTyp_ID] [varchar](40) NOT NULL,\r\n\t                                [CarTyp_No] [int] NOT NULL,\r\n\t                                [NameA] [varchar](50) NULL,\r\n\t                                [NameE] [varchar](50) NULL,\r\n\t                                [Note] [varchar](250) NULL,\r\n                                 CONSTRAINT [PK_T_CarTyp] PRIMARY KEY CLUSTERED \r\n                                (\r\n\t                                [CarTyp_No] ASC\r\n                                )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                ) ON [PRIMARY]\r\n                                SET ANSI_PADDING OFF\r\n                                ");
                        db.ExecuteCommand("INSERT [dbo].[T_CarTyp] ([CarTyp_ID], [CarTyp_No], [NameA],[NameE], [Note]) VALUES (N'916e164e-3f77-4690-a7cb-707764ba8d7c',1,N'????????????',N'Ch',N'-----------')");
                        db.ExecuteCommand("INSERT [dbo].[T_CarTyp] ([CarTyp_ID], [CarTyp_No], [NameA],[NameE], [Note]) VALUES (N'64a1b30d-230e-4940-a971-3006662537a3',2,N'??????',N'GMC',N'-----------')");
                        db.ExecuteCommand("INSERT [dbo].[T_CarTyp] ([CarTyp_ID], [CarTyp_No], [NameA],[NameE], [Note]) VALUES (N'7e7ee1f8-3a55-4ba7-bb34-bcbecd1b3ec0',3,N'????????????',N'Hyundai',N'-----------')");
                        db.ExecuteCommand("INSERT [dbo].[T_CarTyp] ([CarTyp_ID], [CarTyp_No], [NameA],[NameE], [Note]) VALUES (N'4a0543b5-56f2-4e32-8dad-f79d8ffe8896',4,N'????????????',N'Toyota',N'-----------')");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("/****** Object:  Table [dbo].[T_Cars]    Script Date: 08/16/2014 07:59:09 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    SET ANSI_PADDING ON\r\n                                    CREATE TABLE [dbo].[T_Cars](\r\n\t                                    [Car_ID] [varchar](40) NOT NULL,\r\n\t                                    [Car_No] [int] NOT NULL,\r\n\t                                    [NameA] [varchar](50) NULL,\r\n\t                                    [NameE] [varchar](50) NULL,\r\n\t                                    [Model] [varchar](20) NULL,\r\n\t                                    [PlateNo] [varchar](20) NULL,\r\n\t                                    [Color] [varchar](30) NULL,\r\n\t                                    [Note] [varchar](250) NULL,\r\n\t                                    [CarType] [int] NULL,\r\n\t                                    [FormNo] [varchar](20) NULL,\r\n\t                                    [FormBeginDate] [varchar](20) NULL,\r\n\t                                    [FormEndDate] [varchar](20) NULL,\r\n\t                                    [AllownceNo] [varchar](20) NULL,\r\n\t                                    [AllownceBeginDate] [varchar](20) NULL,\r\n\t                                    [AllownceEndDate] [varchar](20) NULL,\r\n\t                                    [AllownceName] [varchar](40) NULL,\r\n\t                                    [PlayCardNo] [varchar](20) NULL,\r\n\t                                    [PlayCardBeginDate] [varchar](20) NULL,\r\n\t                                    [PlayCardEndDate] [varchar](20) NULL,\r\n                                     CONSTRAINT [PK_T_Cars] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [Car_No] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n\r\n                                    SET ANSI_PADDING OFF ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Cars_T_CarTyp]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Cars]'))\r\n                                    ALTER TABLE [dbo].[T_Cars]  WITH CHECK ADD  CONSTRAINT [FK_T_Cars_T_CarTyp] FOREIGN KEY([CarType])\r\n                                    REFERENCES [dbo].[T_CarTyp] ([CarTyp_No])\r\n                                    IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Cars_T_CarTyp]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Cars]'))\r\n                                    ALTER TABLE [dbo].[T_Cars] CHECK CONSTRAINT [FK_T_Cars_T_CarTyp]\r\n                                     ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER function [dbo].[get_date]()\r\n                                    returns VARCHAR(10)\r\n                                    as\r\n                                    begin\r\n                                    DECLARE @GETDATE AS DATETIME = GETDATE()\r\n                                    return  CONVERT(VARCHAR(4),DATEPART(YEAR, @GETDATE)) \r\n                                    + '/'+ CONVERT(VARCHAR(2),DATEPART(MONTH, @GETDATE)) \r\n                                    + '/' + CONVERT(VARCHAR(2),DATEPART(DAY, @GETDATE)) end");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("/****** Object:  Table [dbo].[T_SecretariatsTyp]    Script Date: 08/16/2014 03:49:23 ******/\r\n                                SET ANSI_NULLS ON\r\n                                SET QUOTED_IDENTIFIER ON\r\n                                SET ANSI_PADDING ON\r\n                                CREATE TABLE [dbo].[T_SecretariatsTyp](\r\n\t                                               [SecretariatTyp_ID] [varchar](40) NOT NULL,\r\n\t                                               [SecretariatTyp_No] [int] NOT NULL,\r\n\t                                               [NameA] [varchar](50) NULL,\r\n\t                                               [NameE] [varchar](50) NULL,\r\n\t                                               [Note] [varchar](250) NULL,\r\n                                                 CONSTRAINT [PK_T_SecretariatsTyp] PRIMARY KEY CLUSTERED \r\n                                                (\r\n\t                                                [SecretariatTyp_No] ASC\r\n                                                )   WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                                )   ON [PRIMARY]\r\n                                SET ANSI_PADDING OFF\r\n                                ");
                        db.ExecuteCommand("INSERT [dbo].[T_SecretariatsTyp] ([SecretariatTyp_ID], [SecretariatTyp_No], [NameA],[NameE], [Note]) VALUES (N'4ffa2a1e-2c92-4602-96e8-33913bc94aad',1,N'?????????? ????????????????',N'Electrical Equipment',N'?????????? + ?????????? + ???????????? + ???????? ???????? ???????????? ??????????????????')");
                        db.ExecuteCommand("INSERT [dbo].[T_SecretariatsTyp] ([SecretariatTyp_ID], [SecretariatTyp_No], [NameA],[NameE], [Note]) VALUES (N'd5de0711-a330-4c76-8a66-56ee2bc547ac',2,N'???????? ??????????',N'Mobile',N'???????? ?????????? 5 + ?????????? ????????????')");
                        db.ExecuteCommand("INSERT [dbo].[T_SecretariatsTyp] ([SecretariatTyp_ID], [SecretariatTyp_No], [NameA],[NameE], [Note]) VALUES (N'48c1f772-101b-4492-88dd-dd57b4c49ccd',3,N'?????????? ??????????',N'Job Box',N'?????????? ?????????? + ?????? ?????????????? + ?????????? ??????????????')");
                        db.ExecuteCommand("INSERT [dbo].[T_SecretariatsTyp] ([SecretariatTyp_ID], [SecretariatTyp_No], [NameA],[NameE], [Note]) VALUES (N'ea779b85-aceb-4a18-afe9-44660661e657',4,N'?????????? ??????????',N'Finishing Tools',N'???????? ?????????????? ( ????????) + ???????? + ?????????? + ??????')");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("/****** Object:  Table [dbo].[T_Secretariats]    Script Date: 08/16/2014 07:59:09 ******/\r\n                                     SET ANSI_NULLS ON\r\n                                     SET QUOTED_IDENTIFIER ON\r\n                                     SET ANSI_PADDING ON\r\n                                     CREATE TABLE [dbo].[T_Secretariats](\r\n\t                                                    [Secretariats_ID] [varchar](40) NOT NULL,\r\n\t                                                    [warnNo] [int] NOT NULL,\r\n\t                                                    [EmpID] [varchar](40) NULL,\r\n\t                                                    [warnDate] [varchar](10) NULL,\r\n\t                                                    [StartDate] [varchar](10) NULL,\r\n\t                                                    [EndDate] [varchar](10) NULL,\r\n\t                                                    [SecretariatsTyp] [int] NULL,\r\n\t                                                    [Note] [varchar](250) NULL,\r\n\t                                                    [IFState] [bit] NULL,\r\n                                                    CONSTRAINT [PK_T_Secretariats] PRIMARY KEY CLUSTERED \r\n                                                    (\r\n\t                                                [warnNo] ASC\r\n                                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                                    ) ON [PRIMARY]\r\n                                                    SET ANSI_PADDING OFF\r\n                                                    ALTER TABLE [dbo].[T_Secretariats]  WITH CHECK ADD  CONSTRAINT [FK_T_Secretariats_T_Emp] FOREIGN KEY([EmpID])\r\n                                                    REFERENCES [dbo].[T_Emp] ([Emp_ID])\r\n                                                    ALTER TABLE [dbo].[T_Secretariats] CHECK CONSTRAINT [FK_T_Secretariats_T_Emp]\r\n                                                    ALTER TABLE [dbo].[T_Secretariats]  WITH CHECK ADD  CONSTRAINT [FK_T_Secretariats_T_SecretariatsTyp] FOREIGN KEY([SecretariatsTyp])\r\n                                                    REFERENCES [dbo].[T_SecretariatsTyp] ([SecretariatTyp_No])\r\n                                                    ALTER TABLE [dbo].[T_Secretariats] CHECK CONSTRAINT [FK_T_Secretariats_T_SecretariatsTyp]");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Emp ADD  [WorkNo] [varchar](30) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Emp ADD  [VisaNo] [varchar](30) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Emp ADD  [VisaEnterNo] [varchar](30) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Emp ADD  [VisaDate] [varchar](30) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Emp ADD  [VisaCountry] [varchar](30) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Emp ADD  [CostCenterEmp] [int] NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Salary ADD  [CostCenterEmp] [int] NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Salary ADD  [BankBR] [varchar](30) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("\r\n                                    SET ANSI_NULLS ON\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    SET ANSI_PADDING ON\r\n                                    CREATE TABLE [dbo].[T_VisaGoBack](\r\n\t                                    [Visa_ID] [varchar](40) NOT NULL,\r\n\t                                    [warnNo] [int] NOT NULL,\r\n\t                                    [EmpID] [varchar](40) NULL,\r\n\t                                    [warnDate] [varchar](10) NULL,\r\n\t                                    [VisaNo] [varchar](40) NULL,\r\n\t                                    [VisaPlace] [varchar](40) NULL,\r\n\t                                    [VisaBeginDate] [varchar](20) NULL,\r\n\t                                    [VisaEndDate] [varchar](20) NULL,\r\n\t                                    [DateGo] [varchar](20) NULL,\r\n\t                                    [DateBack] [varchar](20) NULL,\r\n\t                                    [Note] [varchar](250) NULL,\r\n                                     CONSTRAINT [PK_VisaGoBack] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [warnNo] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    SET ANSI_PADDING OFF\r\n                                    ALTER TABLE [dbo].[T_VisaGoBack]  WITH CHECK ADD  CONSTRAINT [FK_T_VisaGoBack_T_Emp] FOREIGN KEY([EmpID])\r\n                                    REFERENCES [dbo].[T_Emp] ([Emp_ID])\r\n                                    ALTER TABLE [dbo].[T_VisaGoBack] CHECK CONSTRAINT [FK_T_VisaGoBack_T_Emp]\r\n                                ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("\r\n                                    SET ANSI_NULLS ON\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    SET ANSI_PADDING ON\r\n                                    CREATE TABLE [dbo].[T_VisaIntroduction](\r\n\t                                    [Visa_ID] [varchar](40) NOT NULL,\r\n\t                                    [warnNo] [int] NOT NULL,\r\n\t                                    [EmpID] [varchar](40) NULL,\r\n\t                                    [warnDate] [varchar](10) NULL,\r\n\t                                    [VisaNo] [varchar](40) NULL,\r\n\t                                    [VisaPlace] [varchar](40) NULL,\r\n\t                                    [VisaBeginDate] [varchar](20) NULL,\r\n\t                                    [VisaEndDate] [varchar](20) NULL,\r\n\t                                    [DateGo] [varchar](20) NULL,\r\n\t                                    [DateBack] [varchar](20) NULL,\r\n\t                                    [Note] [varchar](250) NULL,\r\n                                     CONSTRAINT [PK_T_VisaIntroduction] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [warnNo] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    SET ANSI_PADDING OFF\r\n                                    ALTER TABLE [dbo].[T_VisaIntroduction]  WITH CHECK ADD  CONSTRAINT [FK_T_VisaIntroduction_T_Emp] FOREIGN KEY([EmpID])\r\n                                    REFERENCES [dbo].[T_Emp] ([Emp_ID])\r\n                                    ALTER TABLE [dbo].[T_VisaIntroduction] CHECK CONSTRAINT [FK_T_VisaIntroduction_T_Emp]\r\n                                ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Cars ADD  [CompanyID] [int] NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("Update [dbo].[T_Cars] Set [CompanyID] = 1");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Dept ADD  [AllownceNo] [varchar](20) NULL");
                        db.ExecuteCommand("Update [dbo].[T_Dept] Set [AllownceNo] = '' ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Dept ADD  [AllownceBeginDate] [varchar](20) NULL");
                        db.ExecuteCommand("Update [dbo].[T_Dept] Set [AllownceBeginDate] = '' ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Dept ADD  [AllownceEndDate] [varchar](20) NULL");
                        db.ExecuteCommand("Update [dbo].[T_Dept] Set [AllownceEndDate] = '' ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Dept ADD  [ZakaaNo] [varchar](20) NULL");
                        db.ExecuteCommand("Update [dbo].[T_Dept] Set [ZakaaNo] = '' ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Dept ADD  [ZakaaBeginDate] [varchar](20) NULL");
                        db.ExecuteCommand("Update [dbo].[T_Dept] Set [ZakaaBeginDate] = '' ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Dept ADD [ZakaaEndDate1] [varchar](20) NULL");
                        db.ExecuteCommand("Update [dbo].[T_Dept] Set [ZakaaEndDate1] = '' ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_AttendOperat ADD  [Usr_No] [int] NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_AttendOperat ADD  [DateEdit] [varchar](10) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Cars ADD  [EmpID] [varchar](40) NULL");
                        db.ExecuteCommand("ALTER TABLE [dbo].[T_Cars]  WITH CHECK ADD  CONSTRAINT [FK_T_Cars_T_Emp] FOREIGN KEY([EmpID])\r\n                                    REFERENCES [dbo].[T_Emp] ([Emp_ID])\r\n                                    ALTER TABLE [dbo].[T_Cars] CHECK CONSTRAINT [FK_T_Cars_T_Emp]");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("/****** Object: Table [dbo].[T_Project]    Script Date: 02/13/2016 11:17:26 ******/\r\n                                                    SET ANSI_NULLS ON\r\n                                                    SET QUOTED_IDENTIFIER ON\r\n                                                    SET ANSI_PADDING ON\r\n                                                    CREATE TABLE [dbo].[T_Project](\r\n\t                                                    [Project_ID] [varchar](40) NOT NULL,\r\n\t                                                    [Project_No] [int] NOT NULL,\r\n\t                                                    [NameA] [varchar](30) NULL,\r\n\t                                                    [NameE] [varchar](30) NULL,\r\n\t                                                    [Note] [varchar](250) NULL,\r\n\t                                                    [BossName] [varchar](30) NULL,\r\n\t                                                    [Phone] [varchar](15) NULL,\r\n\t                                                    [Fax] [varchar](15) NULL,\r\n                                                     CONSTRAINT [PK_T_Project] PRIMARY KEY CLUSTERED \r\n                                                    (\r\n\t                                                    [Project_No] ASC\r\n                                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                                    ) ON [PRIMARY]\r\n                                                    SET ANSI_PADDING OFF");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Emp ADD  [ProjectNo] [int] NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_AttendOperat ADD  [ProjectNo] [int] NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_Project] FOREIGN KEY([ProjectNo])\r\n                                    REFERENCES [dbo].[T_Project] ([Project_No])\r\n                                    ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_Project]");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE [dbo].[T_AttendOperat]  WITH CHECK ADD  CONSTRAINT [FK_T_AttendOperat_T_Project] FOREIGN KEY([ProjectNo])\r\n                                    REFERENCES [dbo].[T_Project] ([Project_No])\r\n                                    ALTER TABLE [dbo].[T_AttendOperat] CHECK CONSTRAINT [FK_T_AttendOperat_T_Project]");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("/****** Object:  Table [dbo].[T_TransEmployee]    Script Date: 02/27/2016 12:35:44 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    SET ANSI_PADDING ON\r\n                                    CREATE TABLE [dbo].[T_TransEmployee](\r\n\t                                    [Trans_ID] [varchar](40) NOT NULL,\r\n\t                                    [warnNo] [int] NOT NULL,\r\n\t                                    [EmpID] [varchar](40) NULL,\r\n\t                                    [warnDate] [varchar](10) NULL,\r\n\t                                    [DateFrom] [varchar](10) NULL,\r\n\t                                    [DateTo] [varchar](10) NULL,\r\n\t                                    [BranchFrom] [int] NULL,\r\n\t                                    [BranchTo] [int] NULL,\r\n\t                                    [Usr_No] [int] NULL,\r\n\t                                    [Usr_NoEdite] [int] NULL,\r\n\t                                    [DateEdit] [varchar](10) NULL,\r\n\t                                    [Note] [varchar](250) NULL,\r\n\t                                    [TransTyp] [bit] NULL,\r\n                                     CONSTRAINT [PK_T_TransEmployee] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [warnNo] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    SET ANSI_PADDING OFF\r\n                                    ALTER TABLE [dbo].[T_TransEmployee]  WITH CHECK ADD  CONSTRAINT [FK_T_TransEmployee_T_Emp] FOREIGN KEY([EmpID])\r\n                                    REFERENCES [dbo].[T_Emp] ([Emp_ID])\r\n                                    ALTER TABLE [dbo].[T_TransEmployee] CHECK CONSTRAINT [FK_T_TransEmployee_T_Emp]");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Emp ADD  [Insurance_Name] [varchar](100) NULL");
                        db.ExecuteCommand("Update [dbo].[T_Emp] Set [Insurance_Name] = '' ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Emp ADD  [InsuranceNo] [int] NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("/****** Object:  Table [dbo].[T_Insurance]    Script Date: 03/15/2016 11:08:53 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    SET ANSI_PADDING ON\r\n                                    CREATE TABLE [dbo].[T_Insurance](\r\n\t                                    [Insurance_ID] [varchar](40) NOT NULL,\r\n\t                                    [Insurance_No] [int] NOT NULL,\r\n\t                                    [NameA] [varchar](30) NULL,\r\n\t                                    [NameE] [varchar](30) NULL,\r\n\t                                    [Note] [varchar](250) NULL,\r\n                                     CONSTRAINT [PK_T_Insurance] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [Insurance_No] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    SET ANSI_PADDING OFF");
                        db.ExecuteCommand("INSERT INTO [T_Insurance]\r\n                                       ([Insurance_ID]\r\n                                       ,[Insurance_No]\r\n                                       ,[NameA]\r\n                                       ,[NameE]\r\n                                       ,[Note])\r\n                                 VALUES\r\n                                       ('5ccc3b97-79e1-406c-8604-89e612e544aa'\r\n                                       ,1\r\n                                       ,'????????'\r\n                                       ,'bupa'\r\n                                   ,'------')");
                        db.ExecuteCommand("INSERT INTO [T_Insurance]\r\n                                       ([Insurance_ID]\r\n                                       ,[Insurance_No]\r\n                                       ,[NameA]\r\n                                       ,[NameE]\r\n                                       ,[Note])\r\n                                 VALUES\r\n                                       ('0475b5ea-92ff-4604-88d4-965c16840017'\r\n                                       ,2\r\n                                       ,'??????????????????'\r\n                                       ,'AL-Tawniya'\r\n                                   ,'------')");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Emp ADD  [SocialInsuranceDate] [varchar](10) NULL");
                        db.ExecuteCommand("Update [dbo].[T_Emp] Set [SocialInsuranceDate] = '' ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Emp ADD  [ExclusionDate] [varchar](10) NULL");
                        db.ExecuteCommand("Update [dbo].[T_Emp] Set [ExclusionDate] = '' ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_EndService ADD  [ExclusionDt] [varchar](10) NULL");
                        db.ExecuteCommand("Update [dbo].[T_EndService] Set [ExclusionDt] = '' ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_VacTyp ADD  [Dis_Sal_Sts] [int] NULL");
                        db.ExecuteCommand("ALTER TABLE [dbo].[T_VacTyp] ADD  CONSTRAINT [DF_T_VacTyp_Dis_Sal_Sts]  DEFAULT ((0)) FOR [Dis_Sal_Sts]");
                        db.ExecuteCommand("Update [dbo].[T_VacTyp] Set [Dis_Sal_Sts] = 0 ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Emp ADD  [Boss] [int] NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("/****** Object:  Table [dbo].[T_Boss]    Script Date: 03/18/2016 04:18:48 ******/\r\n                                SET ANSI_NULLS ON\r\n                                SET QUOTED_IDENTIFIER ON\r\n                                SET ANSI_PADDING ON\r\n                                CREATE TABLE [dbo].[T_Boss](\r\n\t                                [Boss_ID] [varchar](40) NOT NULL,\r\n\t                                [Boss_No] [int] NOT NULL,\r\n\t                                [NameA] [varchar](30) NULL,\r\n\t                                [NameE] [varchar](30) NULL,\r\n\t                                [Note] [varchar](250) NULL,\r\n                                 CONSTRAINT [PK_T_Boss] PRIMARY KEY CLUSTERED \r\n                                (\r\n\t                                [Boss_No] ASC\r\n                                )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                ) ON [PRIMARY]\r\n                                SET ANSI_PADDING OFF");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_AccDef_AccountID] FOREIGN KEY([AccountID])\r\n                                    REFERENCES [dbo].[T_AccDef] ([AccDef_No])\r\n                                    ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_AccDef_AccountID]\r\n                                    ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_AccDef_BankBR] FOREIGN KEY([BankBR])\r\n                                    REFERENCES [dbo].[T_AccDef] ([AccDef_No])\r\n                                    ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_AccDef_BankBR]\r\n                                    ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_AccDef_HousAcc] FOREIGN KEY([HouseAcc])\r\n                                    REFERENCES [dbo].[T_AccDef] ([AccDef_No])\r\n                                    ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_AccDef_HousAcc]\r\n                                    ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_AccDef_LoanAcc] FOREIGN KEY([LoanAcc])\r\n                                    REFERENCES [dbo].[T_AccDef] ([AccDef_No])\r\n                                    ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_AccDef_LoanAcc]\r\n                                    ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_AccDef_SalAcc] FOREIGN KEY([SalAcc])\r\n                                    REFERENCES [dbo].[T_AccDef] ([AccDef_No])\r\n                                    ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_AccDef_SalAcc]\r\n                                    ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_Contract]\r\n                                    ALTER TABLE [dbo].[T_Emp]  WITH CHECK ADD  CONSTRAINT [FK_T_Emp_T_CstTbl] FOREIGN KEY([CostCenterEmp])\r\n                                    REFERENCES [dbo].[T_CstTbl] ([Cst_ID])\r\n                                    ALTER TABLE [dbo].[T_Emp] CHECK CONSTRAINT [FK_T_Emp_T_CstTbl]");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE [dbo].[T_Salary]  WITH CHECK ADD  CONSTRAINT [FK_T_Salary_T_AccDef_AccountNo] FOREIGN KEY([AccountNo])\r\n                                    REFERENCES [dbo].[T_AccDef] ([AccDef_No])\r\n                                    ALTER TABLE [dbo].[T_Salary] CHECK CONSTRAINT [FK_T_Salary_T_AccDef_AccountNo]\r\n                                    ALTER TABLE [dbo].[T_Salary]  WITH CHECK ADD  CONSTRAINT [FK_T_Salary_T_AccDef_BankBr] FOREIGN KEY([BankBR])\r\n                                    REFERENCES [dbo].[T_AccDef] ([AccDef_No])\r\n                                    ALTER TABLE [dbo].[T_Salary] CHECK CONSTRAINT [FK_T_Salary_T_AccDef_BankBr]\r\n                                    ALTER TABLE [dbo].[T_Salary]  WITH CHECK ADD  CONSTRAINT [FK_T_Salary_T_AccDef_HousAcc] FOREIGN KEY([HouseAcc])\r\n                                    REFERENCES [dbo].[T_AccDef] ([AccDef_No])\r\n                                    ALTER TABLE [dbo].[T_Salary] CHECK CONSTRAINT [FK_T_Salary_T_AccDef_HousAcc]\r\n                                    ALTER TABLE [dbo].[T_Salary]  WITH CHECK ADD  CONSTRAINT [FK_T_Salary_T_AccDef_LoanAcc] FOREIGN KEY([LoanAcc])\r\n                                    REFERENCES [dbo].[T_AccDef] ([AccDef_No])\r\n                                    ALTER TABLE [dbo].[T_Salary] CHECK CONSTRAINT [FK_T_Salary_T_AccDef_LoanAcc]\r\n                                    ALTER TABLE [dbo].[T_Salary]  WITH CHECK ADD  CONSTRAINT [FK_T_Salary_T_AccDef_SalAcc] FOREIGN KEY([SalAcc])\r\n                                    REFERENCES [dbo].[T_AccDef] ([AccDef_No])\r\n                                    ALTER TABLE [dbo].[T_Salary] CHECK CONSTRAINT [FK_T_Salary_T_AccDef_SalAcc]\r\n                                    ALTER TABLE [dbo].[T_Salary]  WITH CHECK ADD  CONSTRAINT [FK_T_Salary_T_CstTbl] FOREIGN KEY([CostCenterEmp])\r\n                                    REFERENCES [dbo].[T_CstTbl] ([Cst_ID])\r\n                                    ALTER TABLE [dbo].[T_Salary] CHECK CONSTRAINT [FK_T_Salary_T_CstTbl]");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Advances ADD  [AccountID] [varchar](30) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Advances ADD  [BankBR] [varchar](30) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Advances ADD  [CostCenterEmp] [int] NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE [dbo].[T_Advances]  WITH CHECK ADD  CONSTRAINT [FK_T_Advances_T_AccDef_AccountID] FOREIGN KEY([AccountID])\r\n                                    REFERENCES [dbo].[T_AccDef] ([AccDef_No])\r\n                                    ALTER TABLE [dbo].[T_Advances] CHECK CONSTRAINT [FK_T_Advances_T_AccDef_AccountID]\r\n                                    ALTER TABLE [dbo].[T_Advances]  WITH CHECK ADD  CONSTRAINT [FK_T_Advances_T_AccDef_BankBR] FOREIGN KEY([BankBR])\r\n                                    REFERENCES [dbo].[T_AccDef] ([AccDef_No])\r\n                                    ALTER TABLE [dbo].[T_Advances] CHECK CONSTRAINT [FK_T_Advances_T_AccDef_BankBR]\r\n                                    ALTER TABLE [dbo].[T_Advances]  WITH CHECK ADD  CONSTRAINT [FK_T_Advances_T_AccDef_LoanAcc] FOREIGN KEY([LoanAcc])\r\n                                    REFERENCES [dbo].[T_AccDef] ([AccDef_No])\r\n                                    ALTER TABLE [dbo].[T_Advances] CHECK CONSTRAINT [FK_T_Advances_T_AccDef_LoanAcc]\r\n                                    ALTER TABLE [dbo].[T_Advances]  WITH CHECK ADD  CONSTRAINT [FK_T_Advances_T_CstTbl] FOREIGN KEY([CostCenterEmp])\r\n                                    REFERENCES [dbo].[T_CstTbl] ([Cst_ID])\r\n                                    ALTER TABLE [dbo].[T_Advances] CHECK CONSTRAINT [FK_T_Advances_T_CstTbl]");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("/****** Object:  Table [dbo].[T_CallPhone]    Script Date: 03/27/2016 15:14:35 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    SET ANSI_PADDING ON\r\n                                    CREATE TABLE [dbo].[T_CallPhone](\r\n\t                                    [Phone_ID] [varchar](40) NOT NULL,\r\n\t                                    [Phone_No] [int] NOT NULL,\r\n\t                                    [PhoneDate] [varchar](10) NULL,\r\n\t                                    [EmpID] [varchar](40) NULL,\r\n\t                                    [SalDate] [varchar](10) NULL,\r\n\t                                    [PhoneValue] [float] NULL,\r\n\t                                    [Note] [varchar](250) NULL,\r\n\t                                    [IFState] [bit] NULL,\r\n                                     CONSTRAINT [PK_T_CallPhone] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [Phone_No] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    SET ANSI_PADDING OFF\r\n                                    ALTER TABLE [dbo].[T_CallPhone]  WITH CHECK ADD  CONSTRAINT [FK_T_CallPhone_T_Emp] FOREIGN KEY([EmpID])\r\n                                    REFERENCES [dbo].[T_Emp] ([Emp_ID])\r\n                                    ALTER TABLE [dbo].[T_CallPhone] CHECK CONSTRAINT [FK_T_CallPhone_T_Emp]");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_VisaGoBack ADD  [CountDay] [int] NULL");
                        db.ExecuteCommand("ALTER TABLE [dbo].[T_VisaGoBack] ADD  CONSTRAINT [DF_T_VisaGoBack_CountDay]  DEFAULT ((0)) FOR [CountDay]");
                        db.ExecuteCommand("Update [dbo].[T_VisaGoBack] Set [CountDay] = 0 ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_VisaGoBack ADD  [PlaceGo] [varchar](150) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_VisaGoBack ADD  [PlaceBack] [varchar](150) NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Advances ADD  [AutoDisFromSalary] [bit] NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Advances ADD  [AccID]  [bit] NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Advances ADD  [GadeId] [float] NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Salary ADD  [AccID]  [bit] NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Salary ADD  [GadeId] [float] NULL");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("/****** Object:  Table [dbo].[T_SalaryOp]    Script Date: 04/14/2016 12:25:58 ******/\r\n                                            SET ANSI_NULLS ON\r\n                                            SET QUOTED_IDENTIFIER ON\r\n                                            SET ANSI_PADDING ON\r\n                                            CREATE TABLE [dbo].[T_SalaryOp](\r\n\t                                            [SalaryOp_ID] [varchar](40) NOT NULL,\r\n\t                                            [warnNo] [int] NOT NULL,\r\n\t                                            [EmpID] [varchar](40) NULL,\r\n\t                                            [warnDate] [varchar](10) NULL,\r\n\t                                            [opTyp] [int] NULL,\r\n\t                                            [opMethod] [int] NULL,\r\n\t                                            [AddTo] [int] NULL,\r\n\t                                            [opCalc] [int] NULL,\r\n\t                                            [AddValue] [float] NULL,\r\n\t                                            [Usr_No] [int] NULL,\r\n\t                                            [Usr_NoEdite] [int] NULL,\r\n\t                                            [DateEdit] [varchar](10) NULL,\r\n\t                                            [Note] [varchar](250) NULL,\r\n\t                                            [ValueBefor] [float] NULL,\r\n\t                                            [ValueAfter] [float] NULL,\r\n                                             CONSTRAINT [PK_T_SalaryOp] PRIMARY KEY CLUSTERED \r\n                                            (\r\n\t                                            [warnNo] ASC\r\n                                            )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                            ) ON [PRIMARY]\r\n                                            SET ANSI_PADDING OFF\r\n                                            ALTER TABLE [dbo].[T_SalaryOp]  WITH CHECK ADD  CONSTRAINT [FK_T_SalaryOp_T_Emp] FOREIGN KEY([EmpID])\r\n                                            REFERENCES [dbo].[T_Emp] ([Emp_ID])\r\n                                            ALTER TABLE [dbo].[T_SalaryOp] CHECK CONSTRAINT [FK_T_SalaryOp_T_Emp]\r\n                                            ALTER TABLE [dbo].[T_SalaryOp]  WITH CHECK ADD  CONSTRAINT [FK_T_SalaryOp_T_OpMethod] FOREIGN KEY([opCalc])\r\n                                            REFERENCES [dbo].[T_OpMethod] ([Method_No])\r\n                                            ALTER TABLE [dbo].[T_SalaryOp] CHECK CONSTRAINT [FK_T_SalaryOp_T_OpMethod]\r\n                                            ALTER TABLE [dbo].[T_SalaryOp]  WITH CHECK ADD  CONSTRAINT [FK_T_SalaryOp_T_OpMethod1] FOREIGN KEY([AddTo])\r\n                                            REFERENCES [dbo].[T_OpMethod] ([Method_No])\r\n                                            ALTER TABLE [dbo].[T_SalaryOp] CHECK CONSTRAINT [FK_T_SalaryOp_T_OpMethod1]");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("/****** Object: Table [dbo].[T_UpdateDoc]    Script Date: 04/14/2016 08:12:40 ******/\r\n                                                    SET ANSI_NULLS ON\r\n                                                    SET QUOTED_IDENTIFIER ON\r\n                                                    SET ANSI_PADDING ON\r\n                                                    CREATE TABLE [dbo].[T_UpdateDoc](\r\n\t                                                    [UpdateDoc_ID] [varchar](40) NOT NULL,\r\n\t                                                    [warnNo] [int] NOT NULL,\r\n\t                                                    [EmpID] [varchar](40) NULL,\r\n\t                                                    [warnDate] [varchar](10) NULL,\r\n\t                                                    [Usr_No] [int] NULL,\r\n\t                                                    [Usr_NoEdite] [int] NULL,\r\n\t                                                    [DateEdit] [varchar](10) NULL,\r\n\t                                                    [Note] [varchar](250) NULL,\r\n\t                                                    [BeginDateBefor] [varchar](10) NULL,\r\n\t                                                    [BeginDateAfter] [varchar](10) NULL,\r\n\t                                                    [EndDateBefor] [varchar](10) NULL,\r\n\t                                                    [EndDateAfter] [varchar](10) NULL,\r\n\t                                                    [DocNo] [varchar](15) NULL,\r\n\t                                                    [DocFrom] [int] NULL,\r\n\t                                                    [Insurance_NameBefor] [varchar](100) NULL,\r\n\t                                                    [InsuranceNoBefor] [int] NULL,\r\n\t                                                    [Insurance_NameAfter] [varchar](100) NULL,\r\n\t                                                    [InsuranceNoAfter] [int] NULL,\r\n\t                                                    [DocTyp] [int] NULL,\r\n\t                                                    [DocNoAfter] [varchar](15) NULL,\r\n\t                                                    [DocFromAfter] [int] NULL,\r\n                                                     CONSTRAINT [PK_T_UpdateDoc] PRIMARY KEY CLUSTERED \r\n                                                    (\r\n\t                                                    [warnNo] ASC\r\n                                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                                    ) ON [PRIMARY]\r\n                                                    SET ANSI_PADDING OFF\r\n                                                    ALTER TABLE [dbo].[T_UpdateDoc]  WITH CHECK ADD  CONSTRAINT [FK_T_UpdateDoc_T_City] FOREIGN KEY([DocFrom])\r\n                                                    REFERENCES [dbo].[T_City] ([City_No])\r\n                                                    ALTER TABLE [dbo].[T_UpdateDoc] CHECK CONSTRAINT [FK_T_UpdateDoc_T_City]\r\n                                                    ALTER TABLE [dbo].[T_UpdateDoc]  WITH CHECK ADD  CONSTRAINT [FK_T_UpdateDoc_T_City_After] FOREIGN KEY([DocFromAfter])\r\n                                                    REFERENCES [dbo].[T_City] ([City_No])\r\n                                                    ALTER TABLE [dbo].[T_UpdateDoc] CHECK CONSTRAINT [FK_T_UpdateDoc_T_City_After]\r\n                                                    ALTER TABLE [dbo].[T_UpdateDoc]  WITH CHECK ADD  CONSTRAINT [FK_T_UpdateDoc_T_Emp] FOREIGN KEY([EmpID])\r\n                                                    REFERENCES [dbo].[T_Emp] ([Emp_ID])\r\n                                                    ALTER TABLE [dbo].[T_UpdateDoc] CHECK CONSTRAINT [FK_T_UpdateDoc_T_Emp]\r\n                                                    ALTER TABLE [dbo].[T_UpdateDoc]  WITH CHECK ADD  CONSTRAINT [FK_T_UpdateDoc_T_Insurance_After] FOREIGN KEY([InsuranceNoAfter])\r\n                                                    REFERENCES [dbo].[T_Insurance] ([Insurance_No])\r\n                                                    ALTER TABLE [dbo].[T_UpdateDoc] CHECK CONSTRAINT [FK_T_UpdateDoc_T_Insurance_After]\r\n                                                    ALTER TABLE [dbo].[T_UpdateDoc]  WITH CHECK ADD  CONSTRAINT [FK_T_UpdateDoc_T_Insurance_Befor] FOREIGN KEY([InsuranceNoBefor])\r\n                                                    REFERENCES [dbo].[T_Insurance] ([Insurance_No])\r\n                                                    ALTER TABLE [dbo].[T_UpdateDoc] CHECK CONSTRAINT [FK_T_UpdateDoc_T_Insurance_Befor]");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("/****** Object:  Table [dbo].[T_treatment]    Script Date: 04/24/2016 06:17:48 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    SET ANSI_PADDING ON\r\n                                    CREATE TABLE [dbo].[T_treatment](\r\n\t                                    [treatment_ID] [varchar](40) NOT NULL,\r\n\t                                    [treatment_No] [int] NOT NULL,\r\n\t                                    [NameA] [varchar](100) NULL,\r\n\t                                    [NameE] [varchar](100) NULL,\r\n\t                                    [Note] [varchar](250) NULL,\r\n                                     CONSTRAINT [PK_T_treatment] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [treatment_No] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    SET ANSI_PADDING OFF");
                        db.ExecuteCommand("INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'e762c504-f115-4e05-9191-6b82a6f7c569', 1, N'?????? ?????????? ????????????', N'Ensure the transfer of institu', N'')");
                        db.ExecuteCommand("INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'aa2badfa-99ce-448b-9fd3-9a83d0d63446', 2, N'?????? ?????????? ??????????', N'Ensure the transfer of personn', N'')");
                        db.ExecuteCommand("INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'ebdf0a93-703f-4779-8952-be4f6215a796', 3, N'?????? ?????????? ???????????? (????????????????)', N'Transport workers'' services (g', N'')");
                        db.ExecuteCommand("INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'd9e8126b-6529-4bd8-87ce-54c20c60d96e', 4, N'?????????????? (?????????? ?????? ???????????? ???????????? ??????????????)', N'Information (No. prove the new passport to the computer)', N'')");
                        db.ExecuteCommand("INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'a7f2ff6e-69ce-4a50-82cd-8a67830516f0', 5, N'?????? ?????? ?????????????? ?????? ???????? ??????????', N'Opening of the facility ', N'')");
                        db.ExecuteCommand("INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'c9870ff2-c99d-4843-b3fc-22cb7e5de148', 6, N'?????? ?????????? ?????????? ???????????? ???????? ???????????? (?????????? ????????????)', N'Open the file new automated computer system (uniform number)', N'')");
                        db.ExecuteCommand("INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'8250c48b-8821-4228-a704-a0746e2c8b00', 7, N'?????? ?????????????? ??????????????', N'Request visas', N'')");
                        db.ExecuteCommand("INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'ec1c1162-88cc-4fe2-812e-2691fe74bb6e', 8, N'???????? ????????', N'change occupation', N'')");
                        db.ExecuteCommand("INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'137104e5-2d3c-4232-b148-ad8d921e1c21', 9, N'?????????????? ???? ?????????? ?????????????? ?????????????? - ?????????????? ?????????????????? ', N'Instructions for the deceased person for - for individuals and institutions.', N'')");
                        db.ExecuteCommand("INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'bc84a1a8-a5de-4c08-8c83-743bf3199162', 10, N'?????????? ????????', N'Amendment profession', N'')");
                        db.ExecuteCommand("INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'36f428e0-392f-41c1-909c-0e01af275df0', 11, N'?????????? ???????? ??????????????', N'Book accommodation renewal', N'')");
                        db.ExecuteCommand("INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'28d2f42b-6eaa-43a4-b9d4-3937b486b943', 12, N'???????????? ???????? ??????????', N'Exit and return visa', N'')");
                        db.ExecuteCommand("INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'0a4c35dc-711c-4357-a5a3-8754cd483d26', 13, N'?????????? ????????', N'Cancellation author', N'')");
                        db.ExecuteCommand("INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'29abadc3-e647-4481-9833-b307ced49b66', 14, N'???????????? ?????? ???????? ?????????? ??????????????', N'Get the Saudi passport', N'')");
                        db.ExecuteCommand("INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'547dabf2-f2f7-40c4-912c-494313ba4a39', 15, N'?????????????? ???? ???????????? ??????????????(???????????????? ???????????????? )', N'Report internal flight (for institutions and companies)', N'')");
                        db.ExecuteCommand("INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'94ba1ed1-c845-4846-8c1e-9196c91396f8', 16, N'?????????????? ???? ???????????? ?????????????? (??????????????)', N'Report internal flight (for individuals)', N'')");
                        db.ExecuteCommand("INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'51670f93-6f48-4e9b-b93e-2832b05f0601', 17, N'?????????????? ???? ???????????? ?????????????? ???????????????? - ???????? ??????????', N'Report external Escape institutions - out and back', N'')");
                        db.ExecuteCommand("INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'86018217-8135-43bb-9e7d-b3c15c382a90', 18, N'?????????????? ???? ???????????? ?????????????? (?????????????? (???????? ?????????? ))', N'Report external escape (for individuals (out and back))', N'')");
                        db.ExecuteCommand("INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'79d3b7c8-69a5-4b4e-9b81-c7f316f2d6e2', 19, N'?????????????? ?????????????? ???????????????? (???????????? -????????????-????????????)', N'Circulation domestic workers (server -alsaiq-Sentinel)', N'')");
                        db.ExecuteCommand("INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'e0705ad8-a640-44fb-963b-ba2fda9c7d28', 20, N'?????????????? ????????', N'Recruitment wife', N'')");
                        db.ExecuteCommand("INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'2296ada4-b351-4a7f-a18b-e2e1110bb718', 21, N'??????????????', N'Recruitment', N'')");
                        db.ExecuteCommand("INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'ae05fc69-22f6-438c-af1e-afa1c9b3ccd3', 22, N'?????????????? ???????? ??????', N'Extraction work permit', N'')");
                        db.ExecuteCommand("INSERT [dbo].[T_treatment] ([treatment_ID], [treatment_No], [NameA], [NameE], [Note]) VALUES (N'f64b18a8-484b-464a-86d9-a71595a15e87', 23, N'?????????????? ???????? ?????????? ????????', N'The extraction of a new residence Book', N'')");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("/****** Object:  Table [dbo].[T_Commentary]    Script Date: 04/24/2016 06:19:21 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    SET ANSI_PADDING ON\r\n                                    CREATE TABLE [dbo].[T_Commentary](\r\n\t                                    [Commentary_ID] [varchar](40) NOT NULL,\r\n\t                                    [warnNo] [int] NOT NULL,\r\n\t                                    [EmpID] [varchar](40) NULL,\r\n\t                                    [warnDate] [varchar](10) NULL,\r\n\t                                    [SalDate] [varchar](10) NULL,\r\n\t                                    [Value] [float] NULL,\r\n\t                                    [Note] [varchar](250) NULL,\r\n\t                                    [IFState] [bit] NULL,\r\n\t                                    [treatmentNo] [int] NULL,\r\n                                        [CommentaryName] [varchar](40) NULL,\r\n                                     CONSTRAINT [PK_T_Commentary] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [warnNo] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    SET ANSI_PADDING OFF\r\n                                    ALTER TABLE [dbo].[T_Commentary]  WITH CHECK ADD  CONSTRAINT [FK_T_Commentary_T_Emp] FOREIGN KEY([EmpID])\r\n                                    REFERENCES [dbo].[T_Emp] ([Emp_ID])\r\n                                    ALTER TABLE [dbo].[T_Commentary] CHECK CONSTRAINT [FK_T_Commentary_T_Emp]\r\n                                    ALTER TABLE [dbo].[T_Commentary]  WITH CHECK ADD  CONSTRAINT [FK_T_Commentary_T_treatment] FOREIGN KEY([treatmentNo])\r\n                                    REFERENCES [dbo].[T_treatment] ([treatment_No])\r\n                                    ALTER TABLE [dbo].[T_Commentary] CHECK CONSTRAINT [FK_T_Commentary_T_treatment]");
                    }
                    catch
                    {
                    }
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [InvAddCost] [float] NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [InvAddCost] = 0 where InvAddCost is null");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [InvAddCostLoc] [float] NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [InvAddCostLoc] = 0 where InvAddCostLoc is null");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [InvAddCostExtrnal] [float] NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [InvAddCostExtrnal] = 0 where InvAddCostExtrnal is null");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [InvAddCostExtrnalLoc] [float] NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [InvAddCostExtrnalLoc] = 0 where InvAddCostExtrnalLoc is null");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [IsExtrnalGaid] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [IsExtrnalGaid] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [IsExtrnalGaid] = 0 where IsExtrnalGaid is null");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [ExtrnalCostGaidID] [float] NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [ExtrnalCostGaidID] = 0 where ExtrnalCostGaidID is null");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVDET ADD  [ItmAddCost] [float] NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_INVDET] Set [ItmAddCost] = 0 where ItmAddCost is null");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD [Puyaid] [float] NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [Puyaid] = 0 where Puyaid is null");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD [Remming] [float] NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [Remming] = 0 where Remming is null");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [smsUserName] [varchar](500) NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [smsUserName] = '' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [smsPass] [varchar](500) NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [smsPass] = '' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [smsSenderName] [varchar](15) NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [smsSenderName] = '' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [smsMessage1] [varchar](500) NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [smsMessage1] = '???????? ?????????? ?????? ?????????????? ??????????????' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [smsMessage2] [varchar](500) NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [smsMessage2] = '???????? ????????????????' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [smsMessage3] [varchar](500) NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [smsMessage3] = '?????????? ?????? ?????????? ??????????' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [smsMessage4] [varchar](500) NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [smsMessage4] = '???? ?????? ?????????? ????????' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_AccDef] Set [Mobile] = '' Where Mobile is null ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("DELETE FROM [dbo].[T_AccDef] WHERE AccDef_ID=23 and AccDef_No='1020002'");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_Items ADD  [SerialKey] [varchar](100) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_Items] Set [SerialKey] = '' where SerialKey = '' or SerialKey is null");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_QTYEXP ADD  [RunCod] [varchar](100) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_QTYEXP] Set [RunCod] = '' where RunCod = '' or RunCod is null");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVDET ADD  [RunCod] [varchar](100) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_INVDET] Set [RunCod] = '' where RunCod = '' or RunCod is null");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("alter table T_SYSSETTING alter column Seting nchar(100)");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("DELETE FROM T_Info");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set IfPrint = 1  Where IfPrint is null");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set IfTrans = 0  Where IfTrans is null");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [AccCusDes] = '' WHERE [AccCusDes] is null ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [AccSupDes] = '' WHERE [AccSupDes] is null ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("alter table T_AccDef alter column Mnd [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_AccDef] Set [Mnd] = null WHERE [Mnd] = ''");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("alter table T_INVHED alter column Remark [varchar](max) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("alter table T_GDHEAD alter column gdMem [varchar](max) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("alter table T_GDDET alter column gdDes [varchar](max) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_AccDef ADD  [StopInvTyp] [int] NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_AccDef ADD [DateAppointment] varchar(10) NULL");
                    db.ExecuteCommand("Update [dbo].[T_AccDef] Set [DateAppointment] = '' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_AccDef ADD [ID_Date] varchar(10) NULL");
                    db.ExecuteCommand("Update [dbo].[T_AccDef] Set [ID_Date] = '' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_AccDef ADD [ID_DateEnd] varchar(10) NULL");
                    db.ExecuteCommand("Update [dbo].[T_AccDef] Set [ID_DateEnd] = '' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_AccDef ADD [Passport_Date] varchar(10) NULL");
                    db.ExecuteCommand("Update [dbo].[T_AccDef] Set [Passport_DateEnd] = '' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_AccDef ADD [Insurance_Date] varchar(10) NULL");
                    db.ExecuteCommand("Update [dbo].[T_AccDef] Set [Insurance_DateEnd] = '' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_AccDef ADD [Passport_DateEnd] varchar(10) NULL");
                    db.ExecuteCommand("Update [dbo].[T_AccDef] Set [Passport_DateEnd] = '' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_AccDef ADD [Insurance_DateEnd] varchar(10) NULL");
                    db.ExecuteCommand("Update [dbo].[T_AccDef] Set [Insurance_DateEnd] = '' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_AccDef ADD [ID_No] varchar(15) NULL");
                    db.ExecuteCommand("Update [dbo].[T_AccDef] Set [ID_No] = '' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_AccDef ADD [Passport_No] varchar(15) NULL");
                    db.ExecuteCommand("Update [dbo].[T_AccDef] Set [Passport_No] = '' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_AccDef ADD [Insurance_No] varchar(15) NULL");
                    db.ExecuteCommand("Update [dbo].[T_AccDef] Set [Insurance_No] = '' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_AccDef ADD [ID_From] varchar(50) NULL");
                    db.ExecuteCommand("Update [dbo].[T_AccDef] Set [ID_From] = '' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_AccDef ADD [Passport_From] varchar(50) NULL");
                    db.ExecuteCommand("Update [dbo].[T_AccDef] Set [Passport_From] = '' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_AccDef ADD [Insurance_From] varchar(50) NULL");
                    db.ExecuteCommand("Update [dbo].[T_AccDef] Set [Insurance_From] = ''");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_AccDef ADD [MainSal] [float] NULL");
                    db.ExecuteCommand("Update [dbo].[T_AccDef] Set [MainSal] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_AccDef ADD  [BankComm] [float] NULL");
                    db.ExecuteCommand("Update [dbo].[T_AccDef] Set [BankComm] = 0");
                    db.ExecuteCommand("Update [dbo].[T_AccDef] Set [BankComm] = 0.008 where lev=4 and AccCat = 3");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_AccDef ADD  [TaxNo] [varchar](50) NULL");
                    db.ExecuteCommand("Update [dbo].[T_AccDef] Set [TaxNo] = ''");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_AccDef ADD  [TotPoints] [float] NULL");
                    db.ExecuteCommand("Update [dbo].[T_AccDef] Set [TotPoints] = 0");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_AccDef ADD  [MaxDisCust] [float] NULL");
                    db.ExecuteCommand("ALTER TABLE T_AccDef ADD  [vColNum1] [float] NULL");
                    db.ExecuteCommand("ALTER TABLE T_AccDef ADD  [vColNum2] [float] NULL");
                    db.ExecuteCommand("ALTER TABLE T_AccDef ADD  [vColStr1] [varchar](250) NULL");
                    db.ExecuteCommand("ALTER TABLE T_AccDef ADD  [vColStr2] [varchar](250) NULL");
                    db.ExecuteCommand("ALTER TABLE T_AccDef ADD  [vColStr3] [varchar](250) NULL");
                    db.ExecuteCommand("Update [dbo].[T_AccDef] Set [MaxDisCust] = 0");
                    db.ExecuteCommand("Update [dbo].[T_AccDef] Set [vColNum1] = 0 ");
                    db.ExecuteCommand("Update [dbo].[T_AccDef] Set [vColNum2] = 0 ");
                    db.ExecuteCommand("Update [dbo].[T_AccDef] Set [vColStr1] = '' ");
                    db.ExecuteCommand("Update [dbo].[T_AccDef] Set [vColStr2] = '' ");
                    db.ExecuteCommand("Update [dbo].[T_AccDef] Set [vColStr3] = '' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE [dbo].[T_AccDef]  WITH CHECK ADD  CONSTRAINT [FK_T_AccDef_T_Mndob] FOREIGN KEY([Mnd])\r\n                                    REFERENCES [dbo].[T_Mndob] ([Mnd_ID])\r\n                                    ALTER TABLE [dbo].[T_AccDef] CHECK CONSTRAINT [FK_T_AccDef_T_Mndob]");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("SET ANSI_NULLS ON\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    SET ANSI_PADDING ON\r\n                                    CREATE TABLE [dbo].[T_Sal](\r\n\t                                    [SalaryID] [varchar](40) NOT NULL,\r\n\t                                    [EmpID] [varchar](30) NOT NULL,\r\n\t                                    [SalMonth] [int] NULL,\r\n\t                                    [SalYear] [int] NULL,\r\n\t                                    [DirBoss] [int] NULL,\r\n\t                                    [DeptNo] [int] NULL,\r\n\t                                    [Job] [int] NULL,\r\n\t                                    [Salary] [float] NULL,\r\n\t                                    [HousingAllowance] [float] NULL,\r\n\t                                    [TransferAllowance] [float] NULL,\r\n\t                                    [OtherAllowance] [float] NULL,\r\n\t                                    [SubDay] [float] NULL,\r\n\t                                    [LateHours] [float] NULL,\r\n\t                                    [SubJaza] [float] NULL,\r\n\t                                    [SubOther] [float] NULL,\r\n\t                                    [MandateDay] [float] NULL,\r\n\t                                    [SocialInsuranceComp] [float] NULL,\r\n\t                                    [SocialInsurance] [float] NULL,\r\n\t                                    [InsuranceMedicalCom] [float] NULL,\r\n\t                                    [InsuranceMedical] [float] NULL,\r\n\t                                    [Advance] [float] NULL,\r\n\t                                    [Rewards] [float] NULL,\r\n\t                                    [Bank] [int] NULL,\r\n\t                                    [AccountNo] [varchar](30) NULL,\r\n\t                                    [SalaryStatus] [bit] NULL,\r\n\t                                    [IsPrint] [bit] NULL,\r\n\t                                    [SalSpell] [varchar](max) NULL,\r\n\t                                    [AddDay] [float] NULL,\r\n\t                                    [AddHour] [float] NULL,\r\n\t                                    [SectionNo] [int] NULL,\r\n\t                                    [SalAcc] [varchar](30) NULL,\r\n\t                                    [SubCallPhone] [float] NULL,\r\n\t                                    [SubCommentary] [float] NULL,\r\n\t                                    [LoanAcc] [varchar](30) NULL,\r\n\t                                    [HouseAcc] [varchar](30) NULL,\r\n\t                                    [fGUID] [varchar](40) NULL,\r\n\t                                    [Total] [float] NULL,\r\n\t                                    [CostCenterEmp] [int] NULL,\r\n\t                                    [BankBR] [varchar](30) NULL,\r\n\t                                    [AccID] [bit] NULL,\r\n\t                                    [GadeId] [float] NULL,\r\n\t                                    [GadeId2] [float] NULL,\r\n                                     CONSTRAINT [PK_T_Sal] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [SalaryID] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]\r\n                                    SET ANSI_PADDING OFF\r\n                                    ALTER TABLE [dbo].[T_Sal]  WITH CHECK ADD  CONSTRAINT [FK_T_Sal_T_AccDef] FOREIGN KEY([EmpID])\r\n                                    REFERENCES [dbo].[T_AccDef] ([AccDef_No])\r\n                                    ALTER TABLE [dbo].[T_Sal] CHECK CONSTRAINT [FK_T_Sal_T_AccDef]\r\n                                    ALTER TABLE [dbo].[T_Sal] ADD  CONSTRAINT [DF_T_Sal_SalaryStatus]  DEFAULT ((0)) FOR [SalaryStatus]");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [AlarmEmployee] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [AlarmEmployee] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVDET ADD [LineDetails] varchar(250) NULL");
                    db.ExecuteCommand("Update [dbo].[T_INVDET] Set [LineDetails] = '' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_INVDET] Set [LineDetails] = '' WHERE [LineDetails] is null ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [LineDetailSts] varchar(100) NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [LineDetailSts] = '0000000000000000000000000000' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [LineDetailNameA] varchar(30) NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [LineDetailNameA] = '???????????? ????????' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [LineDetailNameE] varchar(30) NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [LineDetailNameE] = 'Other Details' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [LineGiftSts] varchar(100) NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [LineGiftSts] = '0000000000000000000000000000' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [LineGiftlNameA] varchar(30) NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [LineGiftlNameA] = '????????????' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [LineGiftlNameE] varchar(30) NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [LineGiftlNameE] = 'Gift' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("SET ANSI_NULLS ON\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    SET ANSI_PADDING ON\r\n                                    CREATE TABLE [dbo].[T_Chauffeur](\r\n\t                                    [chauffeur_ID] [int] IDENTITY(1,1) NOT NULL,\r\n\t                                    [chauffeur_No] [varchar](30) NULL,\r\n\t                                    [Arb_Des] [varchar](100) NULL,\r\n\t                                    [Eng_Des] [varchar](100) NULL,\r\n\t                                    [chauffeurSts] [int] NULL,\r\n\t                                    [CompanyID] [int] NULL,\r\n                                     CONSTRAINT [PK_T_Driv] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [chauffeur_ID] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    SET ANSI_PADDING OFF");
                    db.ExecuteCommand("/****** Object:  Table [dbo].[T_Rooms]    Script Date: 10/03/2016 14:15:43 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    CREATE TABLE [dbo].[T_Rooms](\r\n\t                                [ID] [int] IDENTITY(1,1) NOT NULL,\r\n\t                                [RomeNo] [int] NOT NULL,\r\n\t                                [RomeStatus] [bit] NULL,\r\n\t                                [Type] [int] NULL,\r\n                                 CONSTRAINT [PK_T_Rooms] PRIMARY KEY CLUSTERED \r\n                                (\r\n\t                                [ID] ASC\r\n                                )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                ) ON [PRIMARY]");
                    db.ExecuteCommand("INSERT [dbo].[T_Rooms] ( [RomeNo], [RomeStatus],[Type]) VALUES ( N'0', '0',0)");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [RoomNo] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [RoomNo] = 1 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [OrderTyp] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [OrderTyp] = 1 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [RoomSts] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [RoomSts] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [chauffeurNo] [int] NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [RoomPerson] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [RoomPerson] = 1 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [ServiceValue] [float] NULL");
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [ServiceValue] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [Sts] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [Sts] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE [dbo].[T_INVHED]  WITH CHECK ADD  CONSTRAINT [FK_T_INVHED_T_Chauffeur] FOREIGN KEY([chauffeurNo])\r\n                                        REFERENCES [dbo].[T_Chauffeur] ([chauffeur_ID])\r\n                                        ALTER TABLE [dbo].[T_INVHED] CHECK CONSTRAINT [FK_T_INVHED_T_Chauffeur]");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE [dbo].[T_INVHED]  WITH CHECK ADD  CONSTRAINT [FK_T_INVHED_T_Rooms] FOREIGN KEY([RoomNo])\r\n                                    REFERENCES [dbo].[T_Rooms] ([ID])\r\n                                    ALTER TABLE [dbo].[T_INVHED] CHECK CONSTRAINT [FK_T_INVHED_T_Rooms]");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [TableFamily] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [TableFamily] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [TableBoys] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [TableBoys] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [TableExtrnal] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [TableExtrnal] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [TableOther] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [TableOther] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_Rooms ADD  [Stop] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_Rooms] Set [Stop] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_Rooms ADD  [reserved] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_Rooms] Set [reserved] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_Rooms ADD  [chair] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_Rooms] Set [chair] = 1 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_Rooms ADD  [Note] varchar(150) NULL");
                    db.ExecuteCommand("Update [dbo].[T_Rooms] Set [Note] = '' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_Rooms ADD  [waiterNo] [int] NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("/****** Object:  Table [dbo].[T_Waiter]    Script Date: 10/30/2016 20:35:39 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    SET ANSI_PADDING ON\r\n                                    CREATE TABLE [dbo].[T_Waiter](\r\n\t                                    [waiter_ID] [int] IDENTITY(1,1) NOT NULL,\r\n\t                                    [waiter_No] [varchar](30) NULL,\r\n\t                                    [Arb_Des] [varchar](100) NULL,\r\n\t                                    [Eng_Des] [varchar](100) NULL,\r\n\t                                    [CompanyID] [int] NULL,\r\n                                     CONSTRAINT [PK_T_Waiter] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [waiter_ID] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n\r\n                                    SET ANSI_PADDING OFF");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE [dbo].[T_Rooms]  WITH CHECK ADD  CONSTRAINT [FK_T_Rooms_T_Waiter] FOREIGN KEY([waiterNo])\r\n                                    REFERENCES [dbo].[T_Waiter] ([waiter_ID])\r\n                                    ALTER TABLE [dbo].[T_Rooms] CHECK CONSTRAINT [FK_T_Rooms_T_Waiter]");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set InvTypA4 = '0'  Where InvID = 22 and ( InvTypA4 = '' or InvTypA4 is null)");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [PaymentOrderTyp] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [PaymentOrderTyp] = 0");
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [CusVenNo] = '',[CusVenNm] = '',[CusVenAdd] = '',[CusVenTel] = '' Where InvTyp = 17 or InvTyp = 20");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE dbo.T_StoreMnd ADD  [CusVenNo] varchar(30) NULL");
                    db.ExecuteCommand("ALTER TABLE [dbo].[T_StoreMnd]  WITH CHECK ADD  CONSTRAINT [FK_T_StoreMnd_T_AccDef] FOREIGN KEY([CusVenNo])\r\n                                    REFERENCES [dbo].[T_AccDef] ([AccDef_No])\r\n                                    ALTER TABLE [dbo].[T_StoreMnd] CHECK CONSTRAINT [FK_T_StoreMnd_T_AccDef]");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [AdminLock] [bit] NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_GDHEAD ADD  [AdminLock] [bit] NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [AdminLock] = 0 where AdminLock = '' or AdminLock is null");
                    db.ExecuteCommand("Update [dbo].[T_GDHEAD] Set [AdminLock] = 0 where AdminLock = '' or AdminLock is null");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [EstDat] = '' where EstDat = '' or EstDat is null");
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [InvCashPayNm] = '' where InvCashPayNm = '' or InvCashPayNm is null");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [nTyp_Setting] = '" + db.SystemSettingStock().nTyp_Setting.Trim() + "0' where nTyp_Setting = '0' or nTyp_Setting ='1' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [InvNamA] = '?????? ??????                                           ' where InvID = 12 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [InvNamA] = '?????? ??????                                           ' where InvID = 13 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [DeleteDate] varchar(10) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [DeleteDate] = ''  where DeleteDate is null");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [DeleteTime] varchar(10) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [DeleteTime] = '' where DeleteTime is null");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [UserNew] varchar(3) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [UserNew] = SalsManNo where UserNew is null");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_AccDef ADD  [DepreciationPercent] [float] NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_AccDef] Set [DepreciationPercent] = 0 where DepreciationPercent is null");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_AccDef ADD  [ProofAcc] varchar(30) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_AccDef] Set [ProofAcc] = ''  where ProofAcc is null");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_AccDef ADD  [RelayAcc] varchar(30) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_AccDef] Set [RelayAcc] = '' where RelayAcc is null");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_GDDET ADD  [gdDesE] [varchar](max) NULL");
                    db.ExecuteCommand("Update [dbo].[T_GDDET] Set [gdDesE] = '' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_GDDET] Set [gdDesE] = '' where gdDesE is null");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_AccDef] Set [StopedState] = 0 where [StopedState] is null");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_GDDET ADD  [AccNoDestruction] [varchar](30) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVSETTING ADD [CatID] [int] NULL");
                    db.ExecuteCommand("ALTER TABLE T_INVSETTING ADD [PrintCat] [bit] NULL");
                    db.ExecuteCommand("ALTER TABLE [dbo].[T_INVSETTING] ADD  CONSTRAINT [DF_T_INVSETTING_PrintCat]  DEFAULT ((0)) FOR [PrintCat]");
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [PrintCat] = 0 WHERE [PrintCat] is null ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE [dbo].[T_INVSETTING]  WITH CHECK ADD  CONSTRAINT [FK_T_INVSETTING_T_CATEGORY] FOREIGN KEY([CatID])\r\n                                    REFERENCES [dbo].[T_CATEGORY] ([CAT_ID])\r\n                                    ALTER TABLE [dbo].[T_INVSETTING] CHECK CONSTRAINT [FK_T_INVSETTING_T_CATEGORY]");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [AutoEmp] = 0 where AutoEmp is null");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("/****** Object:  Table [dbo].[T_InvDetNote]    Script Date: 06/04/2016 01:51:40 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    SET ANSI_PADDING ON\r\n                                    CREATE TABLE [dbo].[T_InvDetNote](\r\n\t                                    [InvDetNote_ID] [int] IDENTITY(1,1) NOT NULL,\r\n\t                                    [InvDetNote_No] [varchar](30) NULL,\r\n\t                                    [Arb_Des] [varchar](200) NULL,\r\n\t                                    [Eng_Des] [varchar](200) NULL,\r\n\t                                    [Price] [float] NULL,\r\n\t                                    [BrNo] [int] NULL,\r\n                                     CONSTRAINT [PK_T_InvDetNote_1] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [InvDetNote_ID] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    SET ANSI_PADDING OFF");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [ServerNm] = '' where ServerNm is null");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [Sa_Pass] = '' where Sa_Pass is null");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [DataBaseNm] = '0' where DataBaseNm is null");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("alter table T_Company alter column Tel2 [varchar](50) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_mInvPrint ADD  [BarcodeTyp] [int] NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_mInvPrint] Set [BarcodeTyp] = 0 where BarcodeTyp is null");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE dbo.T_GDDET DROP CONSTRAINT FK_T_GDDET_T_AccDef_Destruction");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_Mndob ADD  [PriceDoctor] [float] NULL");
                    db.ExecuteCommand("Update [dbo].[T_Mndob] Set [PriceDoctor] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_Mndob ADD  [DoctorJob] varchar(100) NULL");
                    db.ExecuteCommand("Update [dbo].[T_Mndob] Set [DoctorJob] = '' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("SET ANSI_NULLS ON\r\n                                        SET QUOTED_IDENTIFIER ON\r\n                                        SET ANSI_PADDING ON\r\n                                        CREATE TABLE [dbo].[T_PatientCout](\r\n\t                                        [ID] [int] IDENTITY(1,1) NOT NULL,\r\n\t                                        [ItmNo] [varchar](50) NOT NULL,\r\n\t                                        [Mnth] [float] NULL,\r\n\t                                        [Total] [float] NULL,\r\n\t                                        [Filed1] [float] NULL,\r\n\t                                        [Field2] [float] NULL,\r\n\t                                        [Field3] [varchar](50) NULL,\r\n\t                                        [Field4] [varchar](50) NULL,\r\n                                         CONSTRAINT [PK_T_PatientCout] PRIMARY KEY CLUSTERED \r\n                                        (\r\n\t                                        [ID] ASC\r\n                                        )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                        ) ON [PRIMARY]\r\n                                        SET ANSI_PADDING OFF\r\n                                        ALTER TABLE [dbo].[T_PatientCout]  WITH CHECK ADD  CONSTRAINT [FK_T_PatientCout_T_Items] FOREIGN KEY([ItmNo])\r\n                                        REFERENCES [dbo].[T_Items] ([Itm_No])\r\n                                        ALTER TABLE [dbo].[T_PatientCout] CHECK CONSTRAINT [FK_T_PatientCout_T_Items]");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("/****** Object:  Table [dbo].[T_INVDET_Repair]    Script Date: 02/25/2017 00:32:51 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    SET ANSI_PADDING ON\r\n                                    CREATE TABLE [dbo].[T_INVDET_Repair](\r\n\t                                    [InvDet_ID_Repair] [int] IDENTITY(1,1) NOT NULL,\r\n\t                                    [InvNo_Repair] [varchar](10) NULL,\r\n\t                                    [InvId_Repair] [int] NULL,\r\n\t                                    [InvSer_Repair] [int] NULL,\r\n\t                                    [ItmNo_Repair] [varchar](50) NULL,\r\n\t                                    [Cost_Repair] [float] NULL,\r\n\t                                    [Qty_Repair] [float] NULL,\r\n\t                                    [ItmDes_Repair] [varchar](100) NULL,\r\n\t                                    [ItmUnt_Repair] [varchar](15) NULL,\r\n\t                                    [ItmDesE_Repair] [varchar](100) NULL,\r\n\t                                    [ItmUntE_Repair] [varchar](15) NULL,\r\n\t                                    [ItmUntPak_Repair] [float] NULL,\r\n\t                                    [StoreNo_Repair] [int] NULL,\r\n\t                                    [Price_Repair] [float] NULL,\r\n\t                                    [Amount_Repair] [float] NULL,\r\n\t                                    [RealQty_Repair] [float] NULL,\r\n\t                                    [itmInvDsc_Repair] [float] NULL,\r\n\t                                    [DatExper_Repair] [varchar](11) NULL,\r\n\t                                    [ItmDis_Repair] [float] NULL,\r\n\t                                    [ItmTyp_Repair] [int] NULL,\r\n\t                                    [ItmIndex_Repair] [int] NULL,\r\n\t                                    [ItmWight_Repair] [float] NULL,\r\n\t                                    [ItmWight_T_Repair] [float] NULL,\r\n\t                                    [ItmAddCost_Repair] [float] NULL,\r\n\t                                    [RunCod_Repair] [varchar](100) NULL,\r\n\t                                    [LineDetails_Repair] [varchar](250) NULL,\r\n\t                                    [InvDet_ID] [int] NOT NULL,\r\n\t                                    [TypeRepair] [int] NULL,\r\n                                     CONSTRAINT [PK_T_INVDET_Repair] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [InvDet_ID_Repair] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    SET ANSI_PADDING OFF");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("alter table T_SYSSETTING alter column Sa_Pass [varchar](100) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [ImportIp] = '1' where ImportIp is null");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVDET ADD [Serial_Key] varchar(100) NULL");
                    db.ExecuteCommand("Update [dbo].[T_INVDET] Set [Serial_Key] = '' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVDET_Repair ADD [Serial_Key_Repair] varchar(100) NULL");
                    db.ExecuteCommand("Update [dbo].[T_INVDET_Repair] Set [Serial_Key_Repair] = '' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("/****** Object:  Table [dbo].[T_ItemSerial]    Script Date: 03/24/2017 10:36:42 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    SET ANSI_PADDING ON\r\n                                    CREATE TABLE [dbo].[T_ItemSerial](\r\n\t                                    [id] [int] IDENTITY(1,1) NOT NULL,\r\n\t                                    [SerialKey] [varchar](100) NOT NULL,\r\n\t                                    [ItmNo] [varchar](50) NULL,\r\n\t                                    [SerialStatus] [bit] NULL,\r\n                                     CONSTRAINT [PK_T_ItemSerial] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [SerialKey] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    SET ANSI_PADDING OFF\r\n                                    ALTER TABLE [dbo].[T_ItemSerial]  WITH CHECK ADD  CONSTRAINT [FK_T_ItemSerial_T_Items] FOREIGN KEY([ItmNo])\r\n                                    REFERENCES [dbo].[T_Items] ([Itm_No])\r\n                                    ALTER TABLE [dbo].[T_ItemSerial] CHECK CONSTRAINT [FK_T_ItemSerial_T_Items]");
                    List<T_Item> list = db.ExecuteQuery<T_Item>("select * from T_Items where SerialKey <> ''").ToList<T_Item>();
                    for (int index = 0; index < list.Count; ++index)
                        db.ExecuteCommand("INSERT INTO [dbo].[T_ItemSerial]\r\n                                           ([SerialKey]\r\n                                           ,[ItmNo]\r\n                                           ,[SerialStatus])\r\n                                     VALUES ('" + list[index].SerialKey + "','" + list[index].Itm_No + "',0)");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("alter table T_GDDET alter column AccName [varchar](100) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_Waiter ADD [Pass] varchar(250) NULL");
                    db.ExecuteCommand("Update [dbo].[T_Waiter] Set [Pass] = '1' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [InvNamA] = '?????????????? ??????????????',[InvNamE] = 'Local Orders' where InvID = 21 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [MainDirPath] [varchar](max) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [MainDirPath] = '" + Application.StartupPath + "'");
                }
                catch
                {
                }
                try
                {
                    db.T_Roms.Select<T_Rom, T_Rom>((Expression<Func<T_Rom, T_Rom>>)(t => t)).ToList<T_Rom>();
                }
                catch
                {
                    try
                    {
                        db.ExecuteCommand("SET ANSI_NULLS ON\r\n                                        SET QUOTED_IDENTIFIER ON\r\n                                        SET ANSI_PADDING ON\r\n                                        CREATE TABLE [dbo].[T_IDType](\r\n\t                                        [IDType_ID] [int] NOT NULL,\r\n\t                                        [Arb_Des] [varchar](100) NULL,\r\n\t                                        [Eng_Des] [varchar](100) NULL,\r\n\t                                        [Usr] [varchar](3) NULL,\r\n\t                                        [UsrNam] [varchar](50) NULL,\r\n\t                                        [CompanyID] [int] NULL,\r\n                                         CONSTRAINT [PK_T_IDType] PRIMARY KEY CLUSTERED \r\n                                        (\r\n\t                                        [IDType_ID] ASC\r\n                                        )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                        ) ON [PRIMARY]\r\n                                        SET ANSI_PADDING OFF\r\n                                        INSERT [dbo].[T_IDType] ([IDType_ID], [Arb_Des], [Eng_Des], [Usr], [UsrNam], [CompanyID]) VALUES (1, N'?????????? ??????????', N'Status Card', NULL, NULL, 1)\r\n                                        INSERT [dbo].[T_IDType] ([IDType_ID], [Arb_Des], [Eng_Des], [Usr], [UsrNam], [CompanyID]) VALUES (2, N'???????? ?????? ????????', N'Normal Passport', NULL, NULL, 1)\r\n                                        INSERT [dbo].[T_IDType] ([IDType_ID], [Arb_Des], [Eng_Des], [Usr], [UsrNam], [CompanyID]) VALUES (3, N'???????? ?????? ????????????????', N'Diplomatic passport', NULL, NULL, 1)\r\n                                        INSERT [dbo].[T_IDType] ([IDType_ID], [Arb_Des], [Eng_Des], [Usr], [UsrNam], [CompanyID]) VALUES (4, N'??????????', N'ID', NULL, NULL, 1)\r\n                                        INSERT [dbo].[T_IDType] ([IDType_ID], [Arb_Des], [Eng_Des], [Usr], [UsrNam], [CompanyID]) VALUES (5, N'?????? ??????????', N'Family Card', NULL, NULL, 1)\r\n                                        INSERT [dbo].[T_IDType] ([IDType_ID], [Arb_Des], [Eng_Des], [Usr], [UsrNam], [CompanyID]) VALUES (6, N'?????? ????????', N'Marriage contract', NULL, NULL, 1)");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("SET ANSI_NULLS ON\r\n                                        SET QUOTED_IDENTIFIER ON\r\n                                        SET ANSI_PADDING ON\r\n                                        CREATE TABLE [dbo].[T_StsReas](\r\n\t                                        [ID] [int] NOT NULL,\r\n\t                                        [NameSts] [varchar](250) NULL,\r\n\t                                        [NameStsE] [varchar](250) NULL,\r\n                                         CONSTRAINT [PK_T_StsReas] PRIMARY KEY CLUSTERED \r\n                                        (\r\n\t                                        [ID] ASC\r\n                                        )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                        ) ON [PRIMARY]\r\n                                        SET ANSI_PADDING OFF\r\n                                        INSERT [dbo].[T_StsReas] ([ID], [NameSts], [NameStsE]) VALUES (1, N'?????????? ????????', N'Reservations are valid')\r\n                                        INSERT [dbo].[T_StsReas] ([ID], [NameSts], [NameStsE]) VALUES (2, N'???? ??????????????', N'It was settled')\r\n                                        INSERT [dbo].[T_StsReas] ([ID], [NameSts], [NameStsE]) VALUES (3, N'???????? ??????????', N'Reservation canceled')");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [BColor0] [varchar](50) NULL");
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [BColor0] = '255,255,255' ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [BColor1] [varchar](50) NULL");
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [BColor1] = '224,224,224' ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [BColor2] [varchar](50) NULL");
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [BColor2] = '255,0,0' ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [BColor3] [varchar](50) NULL");
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [BColor3] = '128,64,0' ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [BColor4] [varchar](50) NULL");
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [BColor4] = '255,128,0' ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [BColor5] [varchar](50) NULL");
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [BColor5] = '64,64,64' ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [BColor6] [varchar](50) NULL");
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [BColor6] = '255,128,128' ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [BColor7] [varchar](50) NULL");
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [BColor7] = '0,128,0' ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [FColor0] [varchar](50) NULL");
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [FColor0] = '0,64,0' ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [FColor1] [varchar](50) NULL");
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [FColor1] = '0,64,0'  ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [FColor2] [varchar](50) NULL");
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [FColor2] = '255,255,255' ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [FColor3] [varchar](50) NULL");
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [FColor3] = '255,255,255' ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [FColor4] [varchar](50) NULL");
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [FColor4] = '0,0,0' ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [FColor5] [varchar](50) NULL");
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [FColor5] = '255,255,255' ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [FColor6] [varchar](50) NULL");
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [FColor6] = '0,0,0' ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [FColor7] [varchar](50) NULL");
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [FColor7] = '255,255,255' ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [Fld_w] [int] NULL");
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [Fld_w] = 125 ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [Fld_H] [int] NULL");
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [Fld_H] = 100 ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [DayOfM] [int] NULL");
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [DayOfM] = 30 ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [ch] [bit] NULL");
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [ch] = 0 ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [flore] [int] NULL");
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [flore] = 4 ");
                        db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [rom] [int] NULL");
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [rom] = 6 ");
                        db.ExecuteCommand("SET ANSI_NULLS ON\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    SET ANSI_PADDING ON\r\n                                    CREATE TABLE [dbo].[T_Rom](\r\n\t                                    [romno] [int] NOT NULL,\r\n\t                                    [flore] [int] NULL,\r\n\t                                    [ch] [int] NULL,\r\n\t                                    [state] [int] NULL,\r\n\t                                    [row] [int] NULL,\r\n\t                                    [col] [int] NULL,\r\n\t                                    [wcno] [int] NULL,\r\n\t                                    [wc] [int] NULL,\r\n\t                                    [perno] [int] NULL,\r\n\t                                    [bedno] [int] NULL,\r\n\t                                    [bed] [int] NULL,\r\n\t                                    [tv] [int] NULL,\r\n\t                                    [bl] [int] NULL,\r\n\t                                    [aline] [int] NULL,\r\n\t                                    [typ] [int] NULL,\r\n\t                                    [gropno] [int] NULL,\r\n\t                                    [price] [float] NULL,\r\n\t                                    [hed] [int] NULL,\r\n\t                                    [tax] [int] NULL,\r\n\t                                    [ser] [int] NULL,\r\n\t                                    [dt] [varchar](10) NULL,\r\n\t                                    [tm] [varchar](11) NULL,\r\n\t                                    [pri0] [float] NULL,\r\n\t                                    [pri1] [float] NULL,\r\n\t                                    [pri2] [float] NULL,\r\n\t                                    [pri3] [float] NULL,\r\n\t                                    [priM0] [float] NULL,\r\n\t                                    [priM1] [float] NULL,\r\n\t                                    [ShortDsc] [varchar](50) NULL,\r\n\t                                    [Numcounter] [varchar](50) NULL,\r\n\t                                    [CompanyID] [int] NULL,\r\n\t                                    [perno_Old] [int] NULL,\r\n                                     CONSTRAINT [PK_T_Rom] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [romno] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    SET ANSI_PADDING OFF\r\n                                    ALTER TABLE [dbo].[T_Rom] ADD  CONSTRAINT [DF_T_Rom_ch]  DEFAULT ((0)) FOR [ch]\r\n                                    ALTER TABLE [dbo].[T_Rom] ADD  CONSTRAINT [DF_T_Rom_state]  DEFAULT ((0)) FOR [state]");
                        db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                    INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID]) VALUES (101, 1, 0, 1, 1, 1, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1)\r\n                                    INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID]) VALUES (102, 1, 0, 1, 1, 3, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1)\r\n                                    INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID]) VALUES (103, 1, 0, 1, 1, 5, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1)\r\n                                    INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID]) VALUES (104, 1, 0, 1, 1, 7, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1)\r\n                                    INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID]) VALUES (105, 1, 0, 1, 1, 9, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1)\r\n                                    INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID]) VALUES (106, 1, 0, 1, 1, 11, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1)\r\n                                    INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID]) VALUES (201, 2, 0, 1, 3, 1, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1)\r\n                                    INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID]) VALUES (202, 2, 0, 1, 3, 3, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1)\r\n                                    INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID]) VALUES (203, 2, 0, 1, 3, 5, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1)\r\n                                    INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID]) VALUES (204, 2, 0, 1, 3, 7, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1)\r\n                                    INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID]) VALUES (205, 2, 0, 1, 3, 9, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1)\r\n                                    INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID]) VALUES (206, 2, 0, 1, 3, 11, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1)\r\n                                    INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID]) VALUES (301, 3, 0, 1, 5, 1, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1)\r\n                                    INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID]) VALUES (302, 3, 0, 1, 5, 3, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1)\r\n                                    INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID]) VALUES (303, 3, 0, 1, 5, 5, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1)\r\n                                    INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID]) VALUES (304, 3, 0, 1, 5, 7, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1)\r\n                                    INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID]) VALUES (305, 3, 0, 1, 5, 9, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1)\r\n                                    INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID]) VALUES (306, 3, 0, 1, 5, 11, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1)\r\n                                    INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID]) VALUES (401, 4, 0, 1, 7, 1, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1)\r\n                                    INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID]) VALUES (402, 4, 0, 1, 7, 3, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1)\r\n                                    INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID]) VALUES (403, 4, 0, 1, 7, 5, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1)\r\n                                    INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID]) VALUES (404, 4, 0, 1, 7, 7, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1)\r\n                                    INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID]) VALUES (405, 4, 0, 1, 7, 9, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1)\r\n                                    INSERT [dbo].[T_Rom] ([romno], [flore], [ch], [state], [row], [col], [wcno], [wc], [perno], [bedno], [bed], [tv], [bl], [aline], [typ], [gropno], [price], [hed], [tax], [ser], [dt], [tm], [pri0], [pri1], [pri2], [pri3], [priM0], [priM1], [ShortDsc], [Numcounter], [CompanyID]) VALUES (406, 4, 0, 1, 7, 11, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N' ', N' ', 0, 0, 0, 0, 0, 0, N' ', N' ', 1)");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [vStart] [varchar](10) NULL");
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [vStart] = '05:00:00' ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [vEnd] [varchar](10) NULL");
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [vEnd] = '06:00:00' ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [vStartTyp] [varchar](5) NULL");
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [vStartTyp] = 'AM' ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [vEndTyp] [varchar](5) NULL");
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [vEndTyp] = 'PM' ");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("SET ANSI_NULLS ON\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    SET ANSI_PADDING ON\r\n                                    CREATE TABLE [dbo].[T_per](\r\n\t                                    [perno] [int] NOT NULL,\r\n\t                                    [romno] [int] NULL,\r\n\t                                    [nm] [varchar](100) NULL,\r\n\t                                    [nath] [int] NULL,\r\n\t                                    [day] [varchar](12) NULL,\r\n\t                                    [dt1] [int] NULL,\r\n\t                                    [price] [float] NULL,\r\n\t                                    [pasno] [varchar](15) NULL,\r\n\t                                    [dt2] [varchar](10) NULL,\r\n\t                                    [dt3] [varchar](10) NULL,\r\n\t                                    [ch] [int] NULL,\r\n\t                                    [dis] [float] NULL,\r\n\t                                    [actyp] [int] NULL,\r\n\t                                    [ps1] [varchar](30) NULL,\r\n\t                                    [ps2] [varchar](30) NULL,\r\n\t                                    [cc] [int] NULL,\r\n\t                                    [pastyp] [int] NULL,\r\n\t                                    [tm1] [varchar](11) NULL,\r\n\t                                    [tm2] [varchar](11) NULL,\r\n\t                                    [tax] [float] NULL,\r\n\t                                    [ser] [float] NULL,\r\n\t                                    [DOL] [float] NULL,\r\n\t                                    [vip] [int] NULL,\r\n\t                                    [job] [int] NULL,\r\n\t                                    [curr] [int] NULL,\r\n\t                                    [distyp] [int] NULL,\r\n\t                                    [cust] [int] NULL,\r\n\t                                    [disknd] [int] NULL,\r\n\t                                    [jobpls] [varchar](30) NULL,\r\n\t                                    [bdt] [varchar](10) NULL,\r\n\t                                    [bpls] [varchar](30) NULL,\r\n\t                                    [paspls] [varchar](30) NULL,\r\n\t                                    [passt] [varchar](10) NULL,\r\n\t                                    [pasend] [varchar](10) NULL,\r\n\t                                    [enddt] [varchar](10) NULL,\r\n\t                                    [pict] [varbinary](max) NULL,\r\n\t                                    [fat] [float] NULL,\r\n\t                                    [gropno] [int] NULL,\r\n\t                                    [Cust_no] [varchar](30) NULL,\r\n\t                                    [Totel] [int] NULL,\r\n\t                                    [DayEdit] [int] NULL,\r\n\t                                    [DayImport] [int] NULL,\r\n\t                                    [dt4] [varchar](255) NULL,\r\n\t                                    [KindPer] [int] NULL,\r\n\t                                    [DayOfM] [int] NULL,\r\n                                     CONSTRAINT [PK_T_per] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [perno] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    SET ANSI_PADDING OFF\r\n                                    ALTER TABLE [dbo].[T_per]  WITH CHECK ADD  CONSTRAINT [FK_T_per_T_AccDef] FOREIGN KEY([Cust_no])\r\n                                    REFERENCES [dbo].[T_AccDef] ([AccDef_No])\r\n                                    ALTER TABLE [dbo].[T_per] CHECK CONSTRAINT [FK_T_per_T_AccDef]\r\n                                    ALTER TABLE [dbo].[T_per]  WITH CHECK ADD  CONSTRAINT [FK_T_per_T_Curency] FOREIGN KEY([curr])\r\n                                    REFERENCES [dbo].[T_Curency] ([Curency_ID])\r\n                                    ALTER TABLE [dbo].[T_per] CHECK CONSTRAINT [FK_T_per_T_Curency]\r\n                                    ALTER TABLE [dbo].[T_per]  WITH CHECK ADD  CONSTRAINT [FK_T_per_T_IDType] FOREIGN KEY([pastyp])\r\n                                    REFERENCES [dbo].[T_IDType] ([IDType_ID])\r\n                                    ALTER TABLE [dbo].[T_per] CHECK CONSTRAINT [FK_T_per_T_IDType]\r\n                                    ALTER TABLE [dbo].[T_per]  WITH CHECK ADD  CONSTRAINT [FK_T_per_T_Nationalities] FOREIGN KEY([nath])\r\n                                    REFERENCES [dbo].[T_Nationalities] ([Nation_No])\r\n                                    ALTER TABLE [dbo].[T_per] CHECK CONSTRAINT [FK_T_per_T_Nationalities]\r\n                                    ALTER TABLE [dbo].[T_per]  WITH CHECK ADD  CONSTRAINT [FK_T_per_T_Job] FOREIGN KEY([job])\r\n                                    REFERENCES [dbo].[T_Job] ([Job_No])\r\n                                    ALTER TABLE [dbo].[T_per] CHECK CONSTRAINT [FK_T_per_T_Job]\r\n                                    ALTER TABLE [dbo].[T_per]  WITH CHECK ADD  CONSTRAINT [FK_T_per_T_Rom] FOREIGN KEY([romno])\r\n                                    REFERENCES [dbo].[T_Rom] ([romno])\r\n                                    ALTER TABLE [dbo].[T_per] CHECK CONSTRAINT [FK_T_per_T_Rom]\r\n                                    ALTER TABLE [dbo].[T_per] ADD  CONSTRAINT [DF_T_per_ch]  DEFAULT ((0)) FOR [ch]");
                        db.ExecuteCommand("ALTER TABLE [dbo].[T_Rom]  WITH CHECK ADD  CONSTRAINT [FK_T_Rom_T_per] FOREIGN KEY([perno])\r\n                                    REFERENCES [dbo].[T_per] ([perno])\r\n                                    ALTER TABLE [dbo].[T_Rom] CHECK CONSTRAINT [FK_T_Rom_T_per]");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("SET ANSI_NULLS ON\r\n                                        SET QUOTED_IDENTIFIER ON\r\n                                        SET ANSI_PADDING ON\r\n                                        CREATE TABLE [dbo].[T_RomChart](\r\n\t                                        [ID] [int] IDENTITY(1,1) NOT NULL,\r\n\t                                        [FName] [varchar](100) NULL,\r\n\t                                        [FNameE] [varchar](100) NULL,\r\n\t                                        [col1] [int] NULL,\r\n\t                                        [col2] [int] NULL,\r\n\t                                        [col3] [int] NULL,\r\n\t                                        [col4] [int] NULL,\r\n\t                                        [col5] [int] NULL,\r\n\t                                        [col6] [int] NULL,\r\n\t                                        [col7] [int] NULL,\r\n\t                                        [col8] [int] NULL,\r\n\t                                        [col9] [int] NULL,\r\n\t                                        [col10] [int] NULL,\r\n\t                                        [col11] [int] NULL,\r\n\t                                        [col12] [int] NULL,\r\n\t                                        [col13] [int] NULL,\r\n\t                                        [col14] [int] NULL,\r\n\t                                        [col15] [int] NULL,\r\n\t                                        [col16] [int] NULL,\r\n\t                                        [col17] [int] NULL,\r\n\t                                        [col18] [int] NULL,\r\n\t                                        [col19] [int] NULL,\r\n\t                                        [col20] [int] NULL,\r\n\t                                        [col21] [int] NULL,\r\n\t                                        [col22] [int] NULL,\r\n\t                                        [col23] [int] NULL,\r\n\t                                        [col24] [int] NULL,\r\n\t                                        [col25] [int] NULL,\r\n\t                                        [col26] [int] NULL,\r\n\t                                        [col27] [int] NULL,\r\n\t                                        [col28] [int] NULL,\r\n\t                                        [col29] [int] NULL,\r\n\t                                        [col30] [int] NULL,\r\n\t                                        [col31] [int] NULL,\r\n\t                                        [col32] [int] NULL,\r\n\t                                        [col33] [int] NULL,\r\n\t                                        [col34] [int] NULL,\r\n\t                                        [col35] [int] NULL,\r\n\t                                        [col36] [int] NULL,\r\n\t                                        [col37] [int] NULL,\r\n\t                                        [col38] [int] NULL,\r\n\t                                        [col39] [int] NULL,\r\n\t                                        [col40] [int] NULL,\r\n\t                                        [col41] [int] NULL,\r\n\t                                        [col42] [int] NULL,\r\n\t                                        [col43] [int] NULL,\r\n\t                                        [col44] [int] NULL,\r\n\t                                        [col45] [int] NULL,\r\n\t                                        [col46] [int] NULL,\r\n\t                                        [col47] [int] NULL,\r\n\t                                        [col48] [int] NULL,\r\n\t                                        [col49] [int] NULL,\r\n\t                                        [col50] [int] NULL,\r\n\t                                        [col51] [int] NULL,\r\n\t                                        [col52] [int] NULL,\r\n\t                                        [col53] [int] NULL,\r\n\t                                        [col54] [int] NULL,\r\n\t                                        [col55] [int] NULL,\r\n\t                                        [col56] [int] NULL,\r\n\t                                        [col57] [int] NULL,\r\n\t                                        [col58] [int] NULL,\r\n\t                                        [col59] [int] NULL,\r\n\t                                        [col60] [int] NULL,\r\n\t                                        [col61] [int] NULL,\r\n\t                                        [col62] [int] NULL,\r\n\t                                        [col63] [int] NULL,\r\n\t                                        [col64] [int] NULL,\r\n\t                                        [col65] [int] NULL,\r\n\t                                        [col66] [int] NULL,\r\n\t                                        [col67] [int] NULL,\r\n\t                                        [col68] [int] NULL,\r\n\t                                        [col69] [int] NULL,\r\n\t                                        [col70] [int] NULL,\r\n\t                                        [col71] [int] NULL,\r\n\t                                        [col72] [int] NULL,\r\n\t                                        [col73] [int] NULL,\r\n\t                                        [col74] [int] NULL,\r\n\t                                        [col75] [int] NULL,\r\n\t                                        [col76] [int] NULL,\r\n\t                                        [col77] [int] NULL,\r\n\t                                        [col78] [int] NULL,\r\n\t                                        [col79] [int] NULL,\r\n\t                                        [col80] [int] NULL,\r\n\t                                        [col81] [int] NULL,\r\n\t                                        [col82] [int] NULL,\r\n\t                                        [col83] [int] NULL,\r\n\t                                        [col84] [int] NULL,\r\n\t                                        [col85] [int] NULL,\r\n\t                                        [col86] [int] NULL,\r\n\t                                        [col87] [int] NULL,\r\n\t                                        [col88] [int] NULL,\r\n\t                                        [col89] [int] NULL,\r\n\t                                        [col90] [int] NULL,\r\n\t                                        [col91] [int] NULL,\r\n\t                                        [col92] [int] NULL,\r\n\t                                        [col93] [int] NULL,\r\n\t                                        [col94] [int] NULL,\r\n\t                                        [col95] [int] NULL,\r\n\t                                        [col96] [int] NULL,\r\n\t                                        [col97] [int] NULL,\r\n\t                                        [col98] [int] NULL,\r\n\t                                        [col99] [int] NULL,\r\n\t                                        [col100] [int] NULL,\r\n                                         CONSTRAINT [PK_T_RomChart] PRIMARY KEY CLUSTERED \r\n                                        (\r\n\t                                        [ID] ASC\r\n                                        )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                        ) ON [PRIMARY]\r\n                                        SET ANSI_PADDING OFF\r\n                                        SET IDENTITY_INSERT [dbo].[T_RomChart] ON\r\n                                        INSERT [dbo].[T_RomChart] ([ID], [FName], [FNameE], [col1], [col2], [col3], [col4], [col5], [col6], [col7], [col8], [col9], [col10], [col11], [col12], [col13], [col14], [col15], [col16], [col17], [col18], [col19], [col20], [col21], [col22], [col23], [col24], [col25], [col26], [col27], [col28], [col29], [col30], [col31], [col32], [col33], [col34], [col35], [col36], [col37], [col38], [col39], [col40], [col41], [col42], [col43], [col44], [col45], [col46], [col47], [col48], [col49], [col50], [col51], [col52], [col53], [col54], [col55], [col56], [col57], [col58], [col59], [col60], [col61], [col62], [col63], [col64], [col65], [col66], [col67], [col68], [col69], [col70], [col71], [col72], [col73], [col74], [col75], [col76], [col77], [col78], [col79], [col80], [col81], [col82], [col83], [col84], [col85], [col86], [col87], [col88], [col89], [col90], [col91], [col92], [col93], [col94], [col95], [col96], [col97], [col98], [col99], [col100]) VALUES (1, N'???????????? 1', N'floor 1', 101, 102, 103, 104, 105, 106, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)\r\n                                        INSERT [dbo].[T_RomChart] ([ID], [FName], [FNameE], [col1], [col2], [col3], [col4], [col5], [col6], [col7], [col8], [col9], [col10], [col11], [col12], [col13], [col14], [col15], [col16], [col17], [col18], [col19], [col20], [col21], [col22], [col23], [col24], [col25], [col26], [col27], [col28], [col29], [col30], [col31], [col32], [col33], [col34], [col35], [col36], [col37], [col38], [col39], [col40], [col41], [col42], [col43], [col44], [col45], [col46], [col47], [col48], [col49], [col50], [col51], [col52], [col53], [col54], [col55], [col56], [col57], [col58], [col59], [col60], [col61], [col62], [col63], [col64], [col65], [col66], [col67], [col68], [col69], [col70], [col71], [col72], [col73], [col74], [col75], [col76], [col77], [col78], [col79], [col80], [col81], [col82], [col83], [col84], [col85], [col86], [col87], [col88], [col89], [col90], [col91], [col92], [col93], [col94], [col95], [col96], [col97], [col98], [col99], [col100]) VALUES (2, N'???????????? 2', N'floor 2', 201, 202, 203, 204, 205, 206, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)\r\n                                        INSERT [dbo].[T_RomChart] ([ID], [FName], [FNameE], [col1], [col2], [col3], [col4], [col5], [col6], [col7], [col8], [col9], [col10], [col11], [col12], [col13], [col14], [col15], [col16], [col17], [col18], [col19], [col20], [col21], [col22], [col23], [col24], [col25], [col26], [col27], [col28], [col29], [col30], [col31], [col32], [col33], [col34], [col35], [col36], [col37], [col38], [col39], [col40], [col41], [col42], [col43], [col44], [col45], [col46], [col47], [col48], [col49], [col50], [col51], [col52], [col53], [col54], [col55], [col56], [col57], [col58], [col59], [col60], [col61], [col62], [col63], [col64], [col65], [col66], [col67], [col68], [col69], [col70], [col71], [col72], [col73], [col74], [col75], [col76], [col77], [col78], [col79], [col80], [col81], [col82], [col83], [col84], [col85], [col86], [col87], [col88], [col89], [col90], [col91], [col92], [col93], [col94], [col95], [col96], [col97], [col98], [col99], [col100]) VALUES (3, N'???????????? 3', N'floor 3', 301, 302, 303, 304, 305, 306, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)\r\n                                        INSERT [dbo].[T_RomChart] ([ID], [FName], [FNameE], [col1], [col2], [col3], [col4], [col5], [col6], [col7], [col8], [col9], [col10], [col11], [col12], [col13], [col14], [col15], [col16], [col17], [col18], [col19], [col20], [col21], [col22], [col23], [col24], [col25], [col26], [col27], [col28], [col29], [col30], [col31], [col32], [col33], [col34], [col35], [col36], [col37], [col38], [col39], [col40], [col41], [col42], [col43], [col44], [col45], [col46], [col47], [col48], [col49], [col50], [col51], [col52], [col53], [col54], [col55], [col56], [col57], [col58], [col59], [col60], [col61], [col62], [col63], [col64], [col65], [col66], [col67], [col68], [col69], [col70], [col71], [col72], [col73], [col74], [col75], [col76], [col77], [col78], [col79], [col80], [col81], [col82], [col83], [col84], [col85], [col86], [col87], [col88], [col89], [col90], [col91], [col92], [col93], [col94], [col95], [col96], [col97], [col98], [col99], [col100]) VALUES (4, N'???????????? 4', N'floor 4', 401, 402, 403, 404, 405, 406, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)\r\n                                        SET IDENTITY_INSERT [dbo].[T_RomChart] OFF");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("SET ANSI_NULLS ON\r\n                                        SET QUOTED_IDENTIFIER ON\r\n                                        SET ANSI_PADDING ON\r\n                                        CREATE TABLE [dbo].[T_BlackList](\r\n\t                                        [ID] [int] IDENTITY(1,1) NOT NULL,\r\n\t                                        [CustNum] [varchar](50) NOT NULL,\r\n\t                                        [CustNam] [varchar](250) NULL,\r\n\t                                        [IdNo] [varchar](100) NULL,\r\n\t                                        [LecnId] [varchar](100) NULL,\r\n\t                                        [Dis] [varchar](100) NULL,\r\n                                         CONSTRAINT [PK_T_BlackList] PRIMARY KEY CLUSTERED \r\n                                        (\r\n\t                                        [CustNum] ASC\r\n                                        )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                        ) ON [PRIMARY]\r\n                                        SET ANSI_PADDING OFF");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("SET ANSI_NULLS ON\r\n                                        SET QUOTED_IDENTIFIER ON\r\n                                        SET ANSI_PADDING ON\r\n                                        CREATE TABLE [dbo].[T_per1](\r\n\t                                        [ID] [int] IDENTITY(1,1) NOT NULL,\r\n\t                                        [perno] [int] NULL,\r\n\t                                        [nm] [varchar](100) NULL,\r\n\t                                        [natNm] [varchar](100) NULL,\r\n\t                                        [nat] [int] NULL,\r\n\t                                        [bdt] [varchar](10) NULL,\r\n\t                                        [bpls] [varchar](50) NULL,\r\n\t                                        [pastyp] [int] NULL,\r\n\t                                        [pasno] [varchar](25) NULL,\r\n\t                                        [paspls] [varchar](30) NULL,\r\n\t                                        [passt] [varchar](10) NULL,\r\n\t                                        [pasend] [varchar](10) NULL,\r\n\t                                        [entdt] [varchar](10) NULL,\r\n\t                                        [job] [int] NULL,\r\n\t                                        [jobNm] [varchar](100) NULL,\r\n\t                                        [jobpls] [varchar](50) NULL,\r\n\t                                        [romno] [int] NULL,\r\n\t                                        [fNo] [int] NULL,\r\n                                         CONSTRAINT [PK_T_per1] PRIMARY KEY CLUSTERED \r\n                                        (\r\n\t                                        [ID] ASC\r\n                                        )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                        ) ON [PRIMARY]\r\n                                        SET ANSI_PADDING OFF\r\n                                        ALTER TABLE [dbo].[T_per1]  WITH CHECK ADD  CONSTRAINT [FK_T_per1_T_IDType] FOREIGN KEY([pastyp])\r\n                                        REFERENCES [dbo].[T_IDType] ([IDType_ID])\r\n                                        ALTER TABLE [dbo].[T_per1] CHECK CONSTRAINT [FK_T_per1_T_IDType]\r\n                                        ALTER TABLE [dbo].[T_per1]  WITH CHECK ADD  CONSTRAINT [FK_T_per1_T_Job] FOREIGN KEY([job])\r\n                                        REFERENCES [dbo].[T_Job] ([Job_No])\r\n                                        ALTER TABLE [dbo].[T_per1] CHECK CONSTRAINT [FK_T_per1_T_Job]\r\n                                        ALTER TABLE [dbo].[T_per1]  WITH CHECK ADD  CONSTRAINT [FK_T_per1_T_Nationalities] FOREIGN KEY([nat])\r\n                                        REFERENCES [dbo].[T_Nationalities] ([Nation_No])\r\n                                        ALTER TABLE [dbo].[T_per1] CHECK CONSTRAINT [FK_T_per1_T_Nationalities]\r\n                                        ALTER TABLE [dbo].[T_per1]  WITH CHECK ADD  CONSTRAINT [FK_T_per1_T_per] FOREIGN KEY([perno])\r\n                                        REFERENCES [dbo].[T_per] ([perno])\r\n                                        ALTER TABLE [dbo].[T_per1] CHECK CONSTRAINT [FK_T_per1_T_per]\r\n                                        ALTER TABLE [dbo].[T_per1]  WITH CHECK ADD  CONSTRAINT [FK_T_per1_T_Rom] FOREIGN KEY([romno])\r\n                                        REFERENCES [dbo].[T_Rom] ([romno])\r\n                                        ALTER TABLE [dbo].[T_per1] CHECK CONSTRAINT [FK_T_per1_T_Rom]");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("SET ANSI_NULLS ON\r\n                                        SET QUOTED_IDENTIFIER ON\r\n                                        SET ANSI_PADDING ON\r\n                                        CREATE TABLE [dbo].[T_romtrn](\r\n\t                                        [ID] [int] NOT NULL,\r\n\t                                        [romno1] [int] NULL,\r\n\t                                        [romno2] [int] NULL,\r\n\t                                        [perno] [int] NULL,\r\n\t                                        [dt] [varchar](10) NULL,\r\n\t                                        [tm] [varchar](11) NULL,\r\n\t                                        [Usr] [varchar](3) NULL,\r\n\t                                        [UsrNam] [varchar](50) NULL,\r\n\t                                        [typ] [int] NULL,\r\n                                         CONSTRAINT [PK_T_romtrn] PRIMARY KEY CLUSTERED \r\n                                        (\r\n\t                                        [ID] ASC\r\n                                        )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                        ) ON [PRIMARY]\r\n                                        SET ANSI_PADDING OFF\r\n                                        ALTER TABLE [dbo].[T_romtrn]  WITH CHECK ADD  CONSTRAINT [FK_T_romtrn_T_Rom] FOREIGN KEY([romno1])\r\n                                        REFERENCES [dbo].[T_Rom] ([romno])\r\n                                        ALTER TABLE [dbo].[T_romtrn] CHECK CONSTRAINT [FK_T_romtrn_T_Rom]\r\n                                        ALTER TABLE [dbo].[T_romtrn]  WITH CHECK ADD  CONSTRAINT [FK_T_romtrn_T_Rom1] FOREIGN KEY([romno2])\r\n                                        REFERENCES [dbo].[T_Rom] ([romno])\r\n                                        ALTER TABLE [dbo].[T_romtrn] CHECK CONSTRAINT [FK_T_romtrn_T_Rom1]");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("SET ANSI_NULLS ON\r\n                                        SET QUOTED_IDENTIFIER ON\r\n                                        CREATE TABLE [dbo].[T_telmn](\r\n\t                                        [pl] [int] IDENTITY(1,1) NOT NULL,\r\n\t                                        [price] [float] NULL,\r\n\t                                        [d] [int] NULL,\r\n                                         CONSTRAINT [PK_T_telmn] PRIMARY KEY CLUSTERED \r\n                                        (\r\n\t                                        [pl] ASC\r\n                                        )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                        ) ON [PRIMARY]\r\n                                        SET IDENTITY_INSERT [dbo].[T_telmn] ON\r\n                                        INSERT [dbo].[T_telmn] ([pl], [price], [d]) VALUES (1, 1, 0)\r\n                                        INSERT [dbo].[T_telmn] ([pl], [price], [d]) VALUES (2, 2.5, 0)\r\n                                        INSERT [dbo].[T_telmn] ([pl], [price], [d]) VALUES (3, 6, 0)\r\n                                        INSERT [dbo].[T_telmn] ([pl], [price], [d]) VALUES (4, 10, 0)\r\n                                        INSERT [dbo].[T_telmn] ([pl], [price], [d]) VALUES (5, 30, 0)\r\n                                        SET IDENTITY_INSERT [dbo].[T_telmn] OFF");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("SET ANSI_NULLS ON\r\n                                        SET QUOTED_IDENTIFIER ON\r\n                                        SET ANSI_PADDING ON\r\n                                        CREATE TABLE [dbo].[T_tel](\r\n\t                                        [ID] [int] NOT NULL,\r\n\t                                        [perno] [int] NULL,\r\n\t                                        [ino] [int] NULL,\r\n\t                                        [romno] [int] NULL,\r\n\t                                        [tel] [varchar](25) NULL,\r\n\t                                        [s] [float] NULL,\r\n\t                                        [m] [int] NULL,\r\n\t                                        [op] [int] NULL,\r\n\t                                        [price] [float] NULL,\r\n\t                                        [dt] [varchar](10) NULL,\r\n\t                                        [tm] [varchar](10) NULL,\r\n\t                                        [h] [int] NULL,\r\n\t                                        [Usr] [varchar](3) NULL,\r\n\t                                        [UsrNam] [varchar](50) NULL,\r\n                                         CONSTRAINT [PK_T_tel] PRIMARY KEY CLUSTERED \r\n                                        (\r\n\t                                        [ID] ASC\r\n                                        )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                        ) ON [PRIMARY]\r\n                                        SET ANSI_PADDING OFF\r\n                                        ALTER TABLE [dbo].[T_tel]  WITH CHECK ADD  CONSTRAINT [FK_T_tel_T_per] FOREIGN KEY([perno])\r\n                                        REFERENCES [dbo].[T_per] ([perno])\r\n                                        ALTER TABLE [dbo].[T_tel] CHECK CONSTRAINT [FK_T_tel_T_per]\r\n                                        ALTER TABLE [dbo].[T_tel]  WITH CHECK ADD  CONSTRAINT [FK_T_tel_T_Rom] FOREIGN KEY([romno])\r\n                                        REFERENCES [dbo].[T_Rom] ([romno])\r\n                                        ALTER TABLE [dbo].[T_tel] CHECK CONSTRAINT [FK_T_tel_T_Rom]");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("SET ANSI_NULLS ON\r\n                                        SET QUOTED_IDENTIFIER ON\r\n                                        SET ANSI_PADDING ON\r\n                                        CREATE TABLE [dbo].[T_tran](\r\n\t                                        [ID] [int] IDENTITY(1,1) NOT NULL,\r\n\t                                        [dt] [varchar](10) NULL,\r\n\t                                        [romno] [int] NULL,\r\n\t                                        [price] [float] NULL,\r\n\t                                        [fat] [int] NULL,\r\n\t                                        [detal] [varchar](100) NULL,\r\n\t                                        [Usr] [varchar](3) NULL,\r\n\t                                        [UsrNam] [varchar](50) NULL,\r\n\t                                        [tm] [varchar](11) NULL,\r\n\t                                        [perno] [int] NULL,\r\n\t                                        [typ] [int] NULL,\r\n                                         CONSTRAINT [PK_T_tran] PRIMARY KEY CLUSTERED \r\n                                        (\r\n\t                                        [ID] ASC\r\n                                        )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                        ) ON [PRIMARY]\r\n                                        SET ANSI_PADDING OFF\r\n                                        ALTER TABLE [dbo].[T_tran]  WITH CHECK ADD  CONSTRAINT [FK_T_tran_T_per] FOREIGN KEY([perno])\r\n                                        REFERENCES [dbo].[T_per] ([perno])\r\n                                        ALTER TABLE [dbo].[T_tran] CHECK CONSTRAINT [FK_T_tran_T_per]\r\n                                        ALTER TABLE [dbo].[T_tran]  WITH CHECK ADD  CONSTRAINT [FK_T_tran_T_Rom] FOREIGN KEY([romno])\r\n                                        REFERENCES [dbo].[T_Rom] ([romno])\r\n                                        ALTER TABLE [dbo].[T_tran] CHECK CONSTRAINT [FK_T_tran_T_Rom]");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("SET IDENTITY_INSERT [dbo].[T_AccCat] ON\r\n                                    INSERT [dbo].[T_AccCat] ([AccCat_ID], [AccCat_No], [Arb_Des], [Eng_Des], [CompanyID]) VALUES (11, N'11', N'??????????????', N'Guests', 1)\r\n                                    SET IDENTITY_INSERT [dbo].[T_AccCat] OFF");
                    }
                    catch
                    {
                    }
                }
                int num1;
                try
                {
                    db.ExecuteCommand("SET ANSI_NULLS ON\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    SET ANSI_PADDING ON\r\n                                    CREATE TABLE [dbo].[T_sertyp](\r\n\t                                    [Serv_ID] [int] IDENTITY(1,1) NOT NULL,\r\n\t                                    [Serv_No] [varchar](30) NULL,\r\n\t                                    [Arb_Des] [varchar](100) NULL,\r\n\t                                    [Eng_Des] [varchar](100) NULL,\r\n\t                                    [accno] [varchar](30) NULL,\r\n\t                                    [acched] [varchar](30) NULL,\r\n\t                                    [Usr] [varchar](3) NULL,\r\n\t                                    [UsrNam] [varchar](50) NULL,\r\n\t                                    [CompanyID] [int] NULL,\r\n                                     CONSTRAINT [PK_T_sertyp] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [Serv_ID] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    SET ANSI_PADDING OFF\r\n                                    ALTER TABLE [dbo].[T_sertyp]  WITH CHECK ADD  CONSTRAINT [FK_T_sertyp_T_AccDef] FOREIGN KEY([accno])\r\n                                    REFERENCES [dbo].[T_AccDef] ([AccDef_No])\r\n                                    ALTER TABLE [dbo].[T_sertyp] CHECK CONSTRAINT [FK_T_sertyp_T_AccDef]");
                    db.ExecuteCommand("SET ANSI_PADDING OFF\r\n                                    SET IDENTITY_INSERT [dbo].[T_sertyp] ON\r\n\r\n                                    INSERT [dbo].[T_sertyp] ([Serv_ID], [Serv_No], [Arb_Des], [Eng_Des], [accno], [acched], [Usr], [UsrNam], [CompanyID]) VALUES (1, N'1', N'?????????????? ??????????', N'Previous receivables', NULL, NULL, NULL, NULL, 1)\r\n                                    INSERT [dbo].[T_sertyp] ([Serv_ID], [Serv_No], [Arb_Des], [Eng_Des], [accno], [acched], [Usr], [UsrNam], [CompanyID]) VALUES (2, N'2', N'??????????????', N'Damage', NULL, NULL, NULL, NULL, 1)\r\n                                    INSERT [dbo].[T_sertyp] ([Serv_ID], [Serv_No], [Arb_Des], [Eng_Des], [accno], [acched], [Usr], [UsrNam], [CompanyID]) VALUES (3, N'3', N'?????? ????????????', N'furniture', NULL, NULL, NULL, NULL, 1)\r\n                                    INSERT [dbo].[T_sertyp] ([Serv_ID], [Serv_No], [Arb_Des], [Eng_Des], [accno], [acched], [Usr], [UsrNam], [CompanyID]) VALUES (4, N'4', N'??????????', N'Phone', NULL, NULL, NULL, NULL, 1)\r\n                                    SET IDENTITY_INSERT [dbo].[T_sertyp] OFF");
                    db.ExecuteCommand("ALTER TABLE [dbo].[T_tran]  WITH CHECK ADD  CONSTRAINT [FK_T_tran_T_sertyp] FOREIGN KEY([typ])\r\n                                    REFERENCES [dbo].[T_sertyp] ([Serv_ID])\r\n                                    ALTER TABLE [dbo].[T_tran] CHECK CONSTRAINT [FK_T_tran_T_sertyp]");
                    db.ExecuteCommand("ALTER TABLE T_tran ADD GadeNo [float] NULL");
                    db.ExecuteCommand("ALTER TABLE T_tran ADD GadeId [float] NULL");
                    db.ExecuteCommand("ALTER TABLE T_tran ADD IsGaid [bit] NULL");
                    db.ExecuteCommand("alter table T_per alter column dt1 [varchar](10) NULL");
                    db.ExecuteCommand("ALTER TABLE T_telmn ADD accno [varchar](30) NULL");
                    db.ExecuteCommand("ALTER TABLE [dbo].[T_telmn]  WITH CHECK ADD  CONSTRAINT [FK_T_telmn_T_AccDef] FOREIGN KEY([accno])\r\n                                    REFERENCES [dbo].[T_AccDef] ([AccDef_No])\r\n                                    ALTER TABLE [dbo].[T_telmn] CHECK CONSTRAINT [FK_T_telmn_T_AccDef]");
                    db.ExecuteCommand("ALTER TABLE T_per ADD vAmPm [varchar](5) NULL");
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [GuestAcc] [varchar](30) NULL");
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [GuestBoxAcc] [varchar](30) NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [GuestAcc] = '' ");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [GuestBoxAcc] = '' ");
                    try
                    {
                        T_AccDef tAccDef1 = db.StockAccDef("1026");
                        if (tAccDef1 == null || string.IsNullOrEmpty(tAccDef1.AccDef_No))
                        {
                            num1 = 1;
                            try
                            {
                                num1 = db.T_AccDefs.Max<T_AccDef, int>((Expression<Func<T_AccDef, int>>)(lgl => Convert.ToInt32(lgl.AccDef_ID))) + 1;
                            }
                            catch
                            {
                            }
                            db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [DepreciationPercent], [ProofAcc], [RelayAcc]) VALUES ( N'1026', N'??????????????', N'Guests', N'102', 3, NULL, 11, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL)");
                            T_AccDef tAccDef2 = db.StockAccDef("1026");
                            if (tAccDef2 != null && !string.IsNullOrEmpty(tAccDef2.AccDef_No))
                                db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [GuestAcc] = '1026' ");
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        T_AccDef tAccDef = db.StockAccDef("1020001");
                        if (tAccDef != null && !string.IsNullOrEmpty(tAccDef.AccDef_No))
                            db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [GuestBoxAcc] = '1020001' ");
                    }
                    catch
                    {
                    }
                    db.ExecuteCommand("/****** Object:  Table [dbo].[T_Reserv]    Script Date: 07/30/2017 07:38:23 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    SET ANSI_PADDING ON\r\n                                    CREATE TABLE [dbo].[T_Reserv](\r\n\t                                    [ID] [int] IDENTITY(1,1) NOT NULL,\r\n\t                                    [ResrvNo] [int] NOT NULL,\r\n\t                                    [Dat] [varchar](10) NULL,\r\n\t                                    [Rom] [int] NULL,\r\n\t                                    [PerNm] [varchar](150) NULL,\r\n\t                                    [Dt] [varchar](10) NULL,\r\n\t                                    [Tm] [varchar](11) NULL,\r\n\t                                    [vAmPm] [varchar](5) NULL,\r\n\t                                    [IdNo] [varchar](25) NULL,\r\n\t                                    [Nat] [int] NULL,\r\n\t                                    [Remark] [varchar](300) NULL,\r\n\t                                    [Sts] [int] NULL,\r\n\t                                    [Usr] [varchar](3) NULL,\r\n\t                                    [DayImport] [int] NULL,\r\n\t                                    [Dat2] [varchar](10) NULL,\r\n\t                                    [CompanyID] [int] NULL,\r\n                                     CONSTRAINT [PK_T_Reserv] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [ResrvNo] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n\r\n                                    SET ANSI_PADDING OFF\r\n                                    ALTER TABLE [dbo].[T_Reserv]  WITH CHECK ADD  CONSTRAINT [FK_T_Reserv_T_Nationalities] FOREIGN KEY([Nat])\r\n                                    REFERENCES [dbo].[T_Nationalities] ([Nation_No])\r\n                                    ALTER TABLE [dbo].[T_Reserv] CHECK CONSTRAINT [FK_T_Reserv_T_Nationalities]\r\n                                    ALTER TABLE [dbo].[T_Reserv]  WITH CHECK ADD  CONSTRAINT [FK_T_Reserv_T_Rom] FOREIGN KEY([Rom])\r\n                                    REFERENCES [dbo].[T_Rom] ([romno])\r\n                                    ALTER TABLE [dbo].[T_Reserv] CHECK CONSTRAINT [FK_T_Reserv_T_Rom]");
                    db.ExecuteCommand("/****** Object:  Table [dbo].[cod]    Script Date: 08/03/2017 15:42:49 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    CREATE TABLE [dbo].[cod](\r\n\t                                    [cod] [int] NOT NULL,\r\n                                     CONSTRAINT [PK_cod] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [cod] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    INSERT [dbo].[cod] ([cod]) VALUES (201)\r\n                                    INSERT [dbo].[cod] ([cod]) VALUES (202)\r\n                                    INSERT [dbo].[cod] ([cod]) VALUES (212)\r\n                                    INSERT [dbo].[cod] ([cod]) VALUES (213)\r\n                                    INSERT [dbo].[cod] ([cod]) VALUES (216)\r\n                                    INSERT [dbo].[cod] ([cod]) VALUES (218)\r\n                                    INSERT [dbo].[cod] ([cod]) VALUES (222)\r\n                                    INSERT [dbo].[cod] ([cod]) VALUES (249)\r\n                                    INSERT [dbo].[cod] ([cod]) VALUES (252)\r\n                                    INSERT [dbo].[cod] ([cod]) VALUES (253)\r\n                                    INSERT [dbo].[cod] ([cod]) VALUES (291)\r\n                                    INSERT [dbo].[cod] ([cod]) VALUES (962)\r\n                                    INSERT [dbo].[cod] ([cod]) VALUES (963)\r\n                                    INSERT [dbo].[cod] ([cod]) VALUES (964)\r\n                                    INSERT [dbo].[cod] ([cod]) VALUES (965)\r\n                                    INSERT [dbo].[cod] ([cod]) VALUES (966)\r\n                                    INSERT [dbo].[cod] ([cod]) VALUES (967)\r\n                                    INSERT [dbo].[cod] ([cod]) VALUES (968)\r\n                                    INSERT [dbo].[cod] ([cod]) VALUES (970)\r\n                                    INSERT [dbo].[cod] ([cod]) VALUES (971)\r\n                                    INSERT [dbo].[cod] ([cod]) VALUES (973)\r\n                                    INSERT [dbo].[cod] ([cod]) VALUES (974)");
                    db.ExecuteCommand("IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_telmn_T_AccDef]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_telmn]'))\r\n                                    ALTER TABLE [dbo].[T_telmn] DROP CONSTRAINT [FK_T_telmn_T_AccDef]\r\n                                    /****** Object:  Table [dbo].[T_telmn]    Script Date: 08/03/2017 16:21:54 ******/\r\n                                    IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_telmn]') AND type in (N'U'))\r\n                                    DROP TABLE [dbo].[T_telmn]");
                    db.ExecuteCommand("/****** Object:  Table [dbo].[T_telmn]    Script Date: 08/03/2017 16:26:14 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    SET ANSI_PADDING ON\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_telmn]') AND type in (N'U'))\r\n                                    BEGIN\r\n                                    CREATE TABLE [dbo].[T_telmn](\r\n\t                                    [pl] [int] NOT NULL,\r\n\t                                    [price] [float] NULL,\r\n\t                                    [d] [int] NULL,\r\n\t                                    [accno] [varchar](30) COLLATE Arabic_CI_AS NULL,\r\n                                     CONSTRAINT [PK_T_telmn] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [pl] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    END\r\n                                    SET ANSI_PADDING OFF\r\n                                    INSERT [dbo].[T_telmn] ([pl], [price], [d], [accno]) VALUES (0, 2, 0, NULL)\r\n                                    INSERT [dbo].[T_telmn] ([pl], [price], [d], [accno]) VALUES (1, 3, 0, NULL)\r\n                                    INSERT [dbo].[T_telmn] ([pl], [price], [d], [accno]) VALUES (2, 7, 0, NULL)\r\n                                    INSERT [dbo].[T_telmn] ([pl], [price], [d], [accno]) VALUES (3, 12, 0, NULL)\r\n                                    INSERT [dbo].[T_telmn] ([pl], [price], [d], [accno]) VALUES (4, 50, 0, NULL)");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_per ADD [romnoNew] [int] NULL");
                    db.ExecuteCommand("ALTER TABLE T_Reserv ADD [romnoNew] [int] NULL");
                    db.ExecuteCommand("ALTER TABLE T_per1 ADD [romnoNew] [int] NULL");
                    db.ExecuteCommand("ALTER TABLE T_tel ADD [romnoNew] [int] NULL");
                    db.ExecuteCommand("ALTER TABLE T_tran ADD [romnoNew] [int] NULL");
                    db.ExecuteCommand("ALTER TABLE T_romtrn ADD [romnoNew] [int] NULL");
                    db.ExecuteCommand("ALTER TABLE T_romtrn ADD [romnoNew1] [int] NULL");
                    db.ExecuteCommand("ALTER TABLE T_romtrn ADD [romnoNew2] [int] NULL");
                    db.ExecuteCommand("ALTER TABLE dbo.T_per DROP CONSTRAINT [FK_T_per_T_Rom]");
                    db.ExecuteCommand("ALTER TABLE dbo.T_romtrn DROP CONSTRAINT [FK_T_romtrn_T_Rom]");
                    db.ExecuteCommand("ALTER TABLE dbo.T_romtrn DROP CONSTRAINT [FK_T_romtrn_T_Rom1]");
                    db.ExecuteCommand("ALTER TABLE dbo.T_per1 DROP CONSTRAINT [FK_T_per1_T_Rom]");
                    db.ExecuteCommand("ALTER TABLE dbo.T_Reserv DROP CONSTRAINT [FK_T_Reserv_T_Rom]");
                    db.ExecuteCommand("ALTER TABLE dbo.T_tel DROP CONSTRAINT [FK_T_tel_T_Rom]");
                    db.ExecuteCommand("ALTER TABLE dbo.T_tran DROP CONSTRAINT [FK_T_tran_T_Rom]");
                    db.ExecuteCommand("/****** Object:  Table [dbo].[T_Snd]    Script Date: 09/03/2017 00:59:10 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    SET ANSI_PADDING ON\r\n                                    CREATE TABLE [dbo].[T_Snd](\r\n\t                                    [gd_ID] [int] IDENTITY(1,1) NOT NULL,\r\n\t                                    [fNo] [int] NOT NULL,\r\n\t                                    [SndName] [varchar](100) NULL,\r\n\t                                    [romno] [int] NULL,\r\n\t                                    [price] [float] NULL,\r\n\t                                    [det] [varchar](250) NULL,\r\n\t                                    [typ] [int] NULL,\r\n\t                                    [Usr] [varchar](30) NULL,\r\n\t                                    [gdUser] [varchar](3) NULL,\r\n\t                                    [gdUserNam] [varchar](50) NULL,\r\n\t                                    [perno] [int] NULL,\r\n\t                                    [dt] [varchar](10) NULL,\r\n\t                                    [curr] [int] NULL,\r\n\t                                    [tm] [varchar](11) NULL,\r\n\t                                    [ch] [int] NULL,\r\n\t                                    [curcost] [float] NULL,\r\n\t                                    [sala] [int] NULL,\r\n\t                                    [typN] [int] NULL,\r\n\t                                    [ShekNo] [varchar](50) NULL,\r\n\t                                    [ShekDate] [varchar](20) NULL,\r\n\t                                    [ShekBank] [varchar](50) NULL,\r\n\t                                    [IfTrans] [int] NULL,\r\n\t                                    [RStat] [int] NULL,\r\n\t                                    [GadeNo] [float] NULL,\r\n\t                                    [GadeId] [float] NULL,\r\n                                     CONSTRAINT [PK_T_Snd] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [gd_ID] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    SET ANSI_PADDING OFF\r\n                                    ALTER TABLE [dbo].[T_Snd]  WITH CHECK ADD  CONSTRAINT [FK_T_Snd_T_Curency] FOREIGN KEY([curr])\r\n                                    REFERENCES [dbo].[T_Curency] ([Curency_ID])\r\n                                    ALTER TABLE [dbo].[T_Snd] CHECK CONSTRAINT [FK_T_Snd_T_Curency]\r\n                                    ALTER TABLE [dbo].[T_Snd]  WITH CHECK ADD  CONSTRAINT [FK_T_Snd_T_per] FOREIGN KEY([perno])\r\n                                    REFERENCES [dbo].[T_per] ([perno])\r\n                                    ALTER TABLE [dbo].[T_Snd] CHECK CONSTRAINT [FK_T_Snd_T_per]");
                    db.ExecuteCommand("        SET IDENTITY_INSERT [dbo].[T_INVSETTING] ON\r\n                                            INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines],[defSizePaper],[Orientation],[CatID],[PrintCat]) VALUES (27, 27, N'?????? ?????? ????????', N'Catch Receipt Guest', N'1', N'1         ', N'?????????????? ???? ????????????             ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 16706518, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 10, N'', N'111 ', NULL, 1, 1,1,N'',1,NULL,0)\r\n                                            INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines],[defSizePaper],[Orientation],[CatID],[PrintCat]) VALUES (28, 28, N'?????? ?????? ????????', N'receipt Guest', N'1', N'1         ', N'???????????? ???? ????????????              ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 16706518, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 10, N'', N'111 ', NULL, 1, 1,1,N'',1,NULL,0)\r\n                                            SET IDENTITY_INSERT [dbo].[T_INVSETTING] OFF");
                    try
                    {
                        T_AccDef tAccDef1 = db.StockAccDef("3011");
                        if (tAccDef1 != null && !string.IsNullOrEmpty(tAccDef1.AccDef_No))
                        {
                            T_AccDef tAccDef2 = db.StockAccDef("3011002");
                            if (tAccDef2 == null || string.IsNullOrEmpty(tAccDef2.AccDef_No))
                            {
                                try
                                {
                                    db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'3011002', N'?????????????? ????????????', N'Hotel Income', N'3011', 4, N'1', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)");
                                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [GuestBoxAcc] = '3011002' ");
                                }
                                catch
                                {
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                    db.ExecuteCommand("alter table T_Reserv alter column Usr [varchar](100) NULL");
                    db.ExecuteCommand("alter table T_per alter column jobpls [varchar](150) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("/****** Object:  Table [dbo].[T_Loc]    Script Date: 09/14/2017 14:43:05 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    SET ANSI_PADDING ON\r\n                                    CREATE TABLE [dbo].[T_Loc](\r\n\t                                    [Loc_ID] [int] IDENTITY(1,1) NOT NULL,\r\n\t                                    [Loc_No] [varchar](30) NULL,\r\n\t                                    [Arb_Des] [varchar](100) NULL,\r\n\t                                    [Eng_Des] [varchar](100) NULL,\r\n\t                                    [CompanyID] [int] NULL,\r\n                                     CONSTRAINT [PK_T_Loc] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [Loc_ID] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    SET ANSI_PADDING OFF");
                    db.ExecuteCommand("UPDATE [dbo].[T_Rom]  SET [aline] = 1");
                    db.ExecuteCommand("SET IDENTITY_INSERT [dbo].[T_Loc] ON\r\n                                    INSERT [dbo].[T_Loc] ([Loc_ID], [Loc_No], [Arb_Des], [Eng_Des], [CompanyID]) VALUES (1, N'1', N'??????????', N'South', 1)\r\n                                    INSERT [dbo].[T_Loc] ([Loc_ID], [Loc_No], [Arb_Des], [Eng_Des], [CompanyID]) VALUES (2, N'2', N'??????????', N'North', 1)\r\n                                    INSERT [dbo].[T_Loc] ([Loc_ID], [Loc_No], [Arb_Des], [Eng_Des], [CompanyID]) VALUES (3, N'3', N'????????', N'East', 1)\r\n                                    INSERT [dbo].[T_Loc] ([Loc_ID], [Loc_No], [Arb_Des], [Eng_Des], [CompanyID]) VALUES (4, N'4', N'????????', N'West', 1)\r\n                                    SET IDENTITY_INSERT [dbo].[T_Loc] OFF");
                    db.ExecuteCommand("ALTER TABLE [dbo].[T_Rom]  WITH CHECK ADD  CONSTRAINT [FK_T_Rom_T_Loc] FOREIGN KEY([aline])\r\n                                    REFERENCES [dbo].[T_Loc] ([Loc_ID])\r\n                                    ALTER TABLE [dbo].[T_Rom] CHECK CONSTRAINT [FK_T_Rom_T_Loc]");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("SET ANSI_NULLS ON\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[S_T_SINVDET_DELETE]') AND type in (N'P', N'PC'))\r\n                                    BEGIN\r\n                                    EXEC dbo.sp_executesql @statement = N'\r\n                                    CREATE PROCEDURE [dbo].[S_T_SINVDET_DELETE](\r\n                                                      @SInvDet_ID INT \r\n                                          )\r\n                                          AS\r\n                                          BEGIN\r\n\r\n                                            declare @SInvTyp int \r\n                                            declare @SInvId int\r\n                                            declare @SMndID int\r\n                                            declare @SItemCountMnd int \r\n                                            declare @SMndKind int \r\n                                            declare @SRelation int\r\n                                                   \r\n                                            select @SInvId = SInvId from T_SINVDET where SInvDet_ID = @SInvDet_ID;\r\n\r\n                                            select @SRelation = InvId from T_INVDET where InvDet_ID = @SInvId;\r\n\r\n                                            select @SInvTyp = InvTyp from T_INVHED where InvHed_ID = @SRelation;\r\n\r\n                                            select @SMndID = MndNo from T_INVHED where InvHed_ID = @SRelation;\r\n                                            \r\n                                            select @SMndKind = Mnd_Typ from T_Mndob where Mnd_ID = @SMndID;\r\n                                            \r\n                                            if(@SInvTyp != 7 and @SInvTyp != 8 and @SInvTyp != 9 and @SInvTyp != 21)\r\n                                            begin\r\n                                              if(@SMndKind != 1 or @SMndKind is null)\r\n\t\t                                          begin\r\n\t\t\t                                          UPDATE T_Items SET T_Items.OpenQty = T_Items.OpenQty - T_SINVDET.SRealQty \r\n\t\t\t                                          From T_SINVDET Left Join T_Items ON (T_SINVDET.SItmNo = T_Items.Itm_No) \r\n\t\t\t                                          where (SInvDet_ID = @SInvDet_ID) and (T_SINVDET.SItmTyp <> 3) and (T_SINVDET.SItmTyp <> 2);\r\n\r\n\t\t\t                                          UPDATE T_STKSQTY SET T_STKSQTY.stkQty = T_STKSQTY.stkQty - T_SINVDET.SRealQty \r\n\t\t\t                                          From T_SINVDET Left Join T_STKSQTY ON (T_SINVDET.SItmNo = T_STKSQTY.itmNo) AND (T_SINVDET.SStoreNo = T_STKSQTY.storeNo)  \r\n\t\t\t                                          where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 and (T_SINVDET.SItmTyp <> 2);\r\n                                        \t\t\t  \r\n\t\t\t                                          UPDATE T_QTYEXP SET T_QTYEXP.stkQty = T_QTYEXP.stkQty - T_SINVDET.SRealQty \r\n\t\t\t                                          From  T_SINVDET Left Join T_QTYEXP ON (T_SINVDET.SItmNo = T_QTYEXP.itmNo) AND (T_SINVDET.SStoreNo = T_QTYEXP.storeNo) AND (T_SINVDET.SDatExper = T_QTYEXP.DatExper)\r\n\t\t\t                                          where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 and (T_SINVDET.SItmTyp <> 2);\r\n\t\t                                          end\r\n                                              if(@SInvTyp = 14)\r\n\t\t                                          begin\r\n\t\t\t                                          UPDATE T_STKSQTY SET T_STKSQTY.stkInt = T_STKSQTY.stkInt - T_SINVDET.SRealQty \r\n\t\t\t                                          From T_SINVDET Left Join T_STKSQTY ON (T_SINVDET.SItmNo = T_STKSQTY.itmNo) AND (T_SINVDET.SStoreNo = T_STKSQTY.storeNo)  \r\n\t\t\t                                          where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 and (T_SINVDET.SItmTyp <> 2);\r\n\t\t                                          end\r\n                                             if(@SInvTyp = 17)\r\n\t                                         begin\r\n\t \t\t                                          UPDATE T_Items SET T_Items.OpenQty = T_Items.OpenQty - T_SINVDET.SRealQty \r\n\t\t\t                                          From T_SINVDET Left Join T_Items ON (T_SINVDET.SItmNo = T_Items.Itm_No) \r\n\t\t\t                                          where (SInvDet_ID = @SInvDet_ID) and (T_SINVDET.SItmTyp <> 3) and (T_SINVDET.SItmTyp <> 2);\r\n\r\n\t\t\t                                          UPDATE T_STKSQTY SET T_STKSQTY.stkQty = T_STKSQTY.stkQty - T_SINVDET.SRealQty \r\n\t\t\t                                          From T_SINVDET Left Join T_STKSQTY ON (T_SINVDET.SItmNo = T_STKSQTY.itmNo) AND (T_SINVDET.SStoreNo = T_STKSQTY.storeNo)  \r\n\t\t\t                                          where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 and (T_SINVDET.SItmTyp <> 2);\r\n                                        \t\t\t  \r\n\t\t\t                                          UPDATE T_QTYEXP SET T_QTYEXP.stkQty = T_QTYEXP.stkQty - T_SINVDET.SRealQty \r\n\t\t\t                                          From  T_SINVDET Left Join T_QTYEXP ON (T_SINVDET.SItmNo = T_QTYEXP.itmNo) AND (T_SINVDET.SStoreNo = T_QTYEXP.storeNo) AND (T_SINVDET.SDatExper = T_QTYEXP.DatExper)\r\n\t\t\t                                          where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 ;\r\n                                        \t\t\t  \r\n\t                                             -- select @SMndID = MndNo from T_INVHED where InvHed_ID = @SRelation;\r\n\t\t                                         -- UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty - abs(T_SINVDET.SRealQty)\r\n\t\t                                         -- From T_SINVDET Left Join T_StoreMnd ON (T_SINVDET.SItmNo = T_StoreMnd.itmNo) AND (T_SINVDET.SStoreNo = T_StoreMnd.storeNo)  \r\n\t\t                                         -- where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 and (T_SINVDET.SItmTyp <> 2) and T_StoreMnd.MndNo = @SMndID ;\r\n                                             end\r\n                                             \r\n                                             if(@SInvTyp = 20)\r\n\t                                         begin\r\n\t       \t                                          UPDATE T_Items SET T_Items.OpenQty = T_Items.OpenQty - T_SINVDET.SRealQty \r\n\t\t\t                                          From T_SINVDET Left Join T_Items ON (T_SINVDET.SItmNo = T_Items.Itm_No) \r\n\t\t\t                                          where (SInvDet_ID = @SInvDet_ID) and (T_SINVDET.SItmTyp <> 3) and (T_SINVDET.SItmTyp <> 2);\r\n\r\n\t\t\t                                          UPDATE T_STKSQTY SET T_STKSQTY.stkQty = T_STKSQTY.stkQty - T_SINVDET.SRealQty \r\n\t\t\t                                          From T_SINVDET Left Join T_STKSQTY ON (T_SINVDET.SItmNo = T_STKSQTY.itmNo) AND (T_SINVDET.SStoreNo = T_STKSQTY.storeNo)  \r\n\t\t\t                                          where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 and (T_SINVDET.SItmTyp <> 2);\r\n                                        \t\t\t  \r\n\t\t\t                                          UPDATE T_QTYEXP SET T_QTYEXP.stkQty = T_QTYEXP.stkQty - T_SINVDET.SRealQty \r\n\t\t\t                                          From  T_SINVDET Left Join T_QTYEXP ON (T_SINVDET.SItmNo = T_QTYEXP.itmNo) AND (T_SINVDET.SStoreNo = T_QTYEXP.storeNo) AND (T_SINVDET.SDatExper = T_QTYEXP.DatExper)\r\n\t\t\t                                          where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 and (T_SINVDET.SItmTyp <> 2);\r\n                                        \t\t\t  \r\n\t                                            --  select @SMndID = MndNo from T_INVHED where InvHed_ID = @SRelation;\r\n\t\t                                        --  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty + T_SINVDET.SRealQty \r\n\t\t                                        --  From T_SINVDET Left Join T_StoreMnd ON (T_SINVDET.SItmNo = T_StoreMnd.itmNo) AND (T_SINVDET.SStoreNo = T_StoreMnd.storeNo)  \r\n\t\t                                        --  where @SInvDet_ID = SInvDet_ID and T_SINVDET.SItmTyp <> 3 and (T_SINVDET.SItmTyp <> 2) and T_StoreMnd.MndNo = @SMndID ;\r\n                                             end\r\n                                            end\r\n\r\n                                        \r\n\r\n                                          DELETE FROM T_SINVDET\r\n                                          WHERE      @SInvDet_ID = SInvDet_ID   \r\n\r\n                                          RETURN\r\n                                          END\r\n                                    ' \r\n                                    END");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("SET ANSI_NULLS ON\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[S_T_SINVDET_INSERT]') AND type in (N'P', N'PC'))\r\n                                    BEGIN\r\n                                    EXEC dbo.sp_executesql @statement = N'\r\n\r\n                                    CREATE PROCEDURE [dbo].[S_T_SINVDET_INSERT](   \r\n                                                 @SInvDet_ID INT OUTPUT,\r\n                                                 @SInvNo VARCHAR (10)=NULL,\r\n                                                 @SInvId INT =NULL,\r\n                                                 @SInvSer INT =NULL,\r\n                                                 @SItmNo VARCHAR (50)=NULL,\r\n                                                 @SCost FLOAT =NULL,\r\n                                                 @SQty FLOAT =NULL,\r\n                                                 @SItmDes VARCHAR (50)=NULL,\r\n                                                 @SItmUnt VARCHAR (100)=NULL,\r\n                                                 @SItmDesE VARCHAR (50)=NULL,\r\n                                                 @SItmUntE VARCHAR (100)=NULL,\r\n                                                 @SItmUntPak FLOAT =NULL,\r\n                                                 @SStoreNo INT=NULL,\r\n                                                 @SPrice FLOAT =NULL,\r\n                                                 @SAmount FLOAT =NULL,\r\n                                                 @SRealQty FLOAT =NULL,\r\n                                                 @SitmInvDsc FLOAT =NULL,\r\n                                                 @SDatExper VARCHAR (11)=NULL,\r\n                                                 @SItmDis FLOAT =NULL,\r\n                                                 @SItmTyp INT =NULL,\r\n                                                 @SItmIndex INT =NULL,\r\n                                                 @SItmWight FLOAT =NULL,\r\n                                                 @SItmWight_T FLOAT =NULL,\r\n                                                 @SQtyDef FLOAT =NULL,\r\n                                                 @SPriceDef FLOAT =NULL,\r\n                                                 @SInvIdHEAD INT =NULL\r\n                                                 \r\n                                          )\r\n                                          AS\r\n                                          BEGIN\r\n\r\n                                          INSERT INTO T_SINVDET(\r\n                                                 SInvNo,\r\n                                                 SInvId,\r\n                                                 SInvSer,\r\n                                                 SItmNo,\r\n                                                 SCost,\r\n                                                 SQty,\r\n                                                 SItmDes,\r\n                                                 SItmUnt,\r\n                                                 SItmDesE,\r\n                                                 SItmUntE,\r\n                                                 SItmUntPak,\r\n                                                 SStoreNo,\r\n                                                 SPrice,\r\n                                                 SAmount,\r\n                                                 SRealQty,\r\n                                                 SitmInvDsc,\r\n                                                 SDatExper,\r\n                                                 SItmDis,\r\n                                                 SItmTyp,\r\n                                                 SItmIndex,\r\n                                                 SItmWight,\r\n                                                 SItmWight_T,\r\n                                                 SQtyDef,\r\n                                                 SPriceDef,\r\n                                                 SInvIdHEAD\r\n                                          )\r\n                                          VALUES\r\n                                          (\r\n                                                @SInvNo,\r\n                                                @SInvId,\r\n                                                @SInvSer,\r\n                                                @SItmNo,\r\n                                                @SCost,\r\n                                                @SQty,\r\n                                                @SItmDes,\r\n                                                @SItmUnt,\r\n                                                @SItmDesE,\r\n                                                @SItmUntE,\r\n                                                @SItmUntPak,\r\n                                                @SStoreNo,\r\n                                                @SPrice,\r\n                                                @SAmount,\r\n                                                @SRealQty,\r\n                                                @SitmInvDsc,\r\n                                                @SDatExper,\r\n                                                @SItmDis,\r\n                                                @SItmTyp,\r\n                                                @SItmIndex,\r\n                                                @SItmWight,\r\n                                                @SItmWight_T,\r\n                                                @SQtyDef,\r\n                                                @SPriceDef,\r\n                                                @SInvIdHEAD\r\n                                          )\r\n                                          SELECT @SInvDet_ID = SCOPE_IDENTITY()\r\n\r\n                                                declare @SItemCount int  \r\n                                                declare @SInvTyp int\r\n                                                declare @SMndID int\r\n                                                declare @SItemCountMnd int \r\n                                                declare @SRelation int\r\n                                                   \r\n                                                select @SRelation = InvId from T_INVDET where InvDet_ID = @SInvId;\r\n                                                select @SItemCount = Count(*) from T_STKSQTY where itmNo = @SItmNo and storeNo =@SStoreNo;\r\n                                                select @SInvTyp = InvTyp from T_INVHED where InvHed_ID = @SRelation;\r\n                                                if((@SInvTyp != 7 and @SInvTyp != 8 and @SInvTyp != 9 and @SInvTyp != 21) and @SItmTyp <> 3 and @SItmTyp <> 2)\r\n                                                begin\r\n\r\n                                                    Update T_Items SET OpenQty = OpenQty+@SRealQty WHERE Itm_No = @SItmNo;\r\n                                                    if(@SItemCount > 0)\r\n                                                    begin\r\n                                                    Update T_STKSQTY SET stkQty = stkQty+@SRealQty WHERE itmNo = @SItmNo and storeNo = @SStoreNo;\r\n                                                    end\r\n\r\n                                                    if(@SItemCount = 0)\r\n                                                    begin \r\n                                                    INSERT INTO T_STKSQTY(itmNo,storeNo,stkQty,stkInt) VALUES(@SItmNo,@SStoreNo,@SRealQty,0);\r\n                                                    END\r\n\r\n                                                    if(@SInvTyp = 14)\r\n                                                    begin\r\n                                                        Update T_STKSQTY SET stkInt = stkInt+@SRealQty WHERE itmNo = @SItmNo and storeNo = @SStoreNo;\r\n                                                    end\r\n\r\n                                                    select @SItemCount = Count(*) from T_QTYEXP where itmNo = @SItmNo and storeNo =@SStoreNo and DatExper = @SDatExper;\r\n\r\n                                                    if(@SItemCount > 0 and @SDatExper <> '')\r\n                                                    begin\r\n                                                    Update T_QTYEXP SET stkQty = stkQty+@SRealQty WHERE itmNo = @SItmNo and storeNo = @StoreNo and DatExper = @SDatExper;\r\n                                                    end\r\n\r\n                                                    if(@SItemCount = 0 and @SDatExper <> '')\r\n                                                    begin \r\n                                                    INSERT INTO T_QTYEXP(itmNo,storeNo,DatExper,stkQty) VALUES(@SItmNo,@SStoreNo,@SDatExper,@SRealQty);\r\n                                                    END\r\n--                                                    if(@SInvTyp = 17)\r\n--                                                        begin\r\n--                                                         select @SMndID = MndNo from T_INVHED where InvHed_ID = @SRelation;\r\n--                                                            select @SItemCountMnd = Count(*) from T_StoreMnd where itmNo = @SItmNo and storeNo =@SStoreNo and MndNo = @SMndID;\r\n--                                                                    if(@SItemCountMnd > 0)\r\n--                                                                    begin\r\n--                                                                         Update T_StoreMnd SET stkQty = stkQty + abs(@SRealQty) WHERE itmNo = @SItmNo and storeNo = @SStoreNo and MndNo = @SMndID;\r\n--                                                                    end\r\n--\r\n--                                                                    if(@SItemCountMnd = 0)\r\n--                                                                    begin \r\n--                                                                         INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,MndNo) VALUES(@SItmNo,@SStoreNo,abs(@SRealQty),0,@SMndID);\r\n--                                                                    END\r\n--                                                        end\t\r\n--                                                    if(@SInvTyp = 20)\r\n--                                                        begin\r\n--                                                         select @SMndID = MndNo from T_INVHED where InvHed_ID = @SRelation;\r\n--                                                            select @SItemCountMnd = Count(*) from T_StoreMnd where itmNo = @SItmNo and storeNo =@SStoreNo and MndNo = @SMndID;\r\n--                                                                    if(@SItemCountMnd > 0)\r\n--                                                                    begin\r\n--                                                                         Update T_StoreMnd SET stkQty = stkQty + (-@SRealQty) WHERE itmNo = @SItmNo and storeNo = @SStoreNo and MndNo = @SMndID;\r\n--                                                                    end\r\n--\r\n--                                                                    if(@SItemCountMnd = 0)\r\n--                                                                    begin \r\n--                                                                         INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,MndNo) VALUES(@SItmNo,@SStoreNo,-@SRealQty,0,@SMndID);\r\n--                                                                    END\r\n--                                                        end\r\n                                                end\r\n\r\n\r\n                                              RETURN\r\n                                              END\r\n                                    ' \r\n                                    END");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("     ALTER PROCEDURE [dbo].[S_T_INVDET_INSERT](   \r\n                                             @InvDet_ID INT OUTPUT,\r\n                                             @InvNo VARCHAR (10)=NULL,\r\n                                             @InvId INT =NULL,\r\n                                             @InvSer INT =NULL,\r\n                                             @ItmNo VARCHAR (50)=NULL,\r\n                                             @Cost FLOAT =NULL,\r\n                                             @Qty FLOAT =NULL,\r\n                                             @ItmDes VARCHAR (50)=NULL,\r\n                                             @ItmUnt VARCHAR (100)=NULL,\r\n                                             @ItmDesE VARCHAR (50)=NULL,\r\n                                             @ItmUntE VARCHAR (100)=NULL,\r\n                                             @ItmUntPak FLOAT =NULL,\r\n                                             @StoreNo INT=NULL,\r\n                                             @Price FLOAT =NULL,\r\n                                             @Amount FLOAT =NULL,\r\n                                             @RealQty FLOAT =NULL,\r\n                                             @itmInvDsc FLOAT =NULL,\r\n                                             @DatExper VARCHAR (11)=NULL,\r\n                                             @ItmDis FLOAT =NULL,\r\n                                             @ItmTyp INT =NULL,\r\n                                             @ItmIndex INT =NULL,\r\n                                             @ItmWight FLOAT =NULL,\r\n                                             @ItmWight_T FLOAT =NULL,\r\n                                             @ItmAddCost FLOAT =NULL,\r\n                                             @RunCod VARCHAR (100)=NULL,\r\n                                             @LineDetails VARCHAR (250)=NULL,\r\n                                             @Serial_Key VARCHAR (100)=NULL,\r\n                                             @ItmTax FLOAT =NULL,\r\n                                             @OfferTyp INT =NULL                                                \r\n                                      )\r\n                                      AS\r\n                                      BEGIN\r\n                                      INSERT INTO T_INVDET(\r\n                                             InvNo,\r\n                                             InvId,\r\n                                             InvSer,\r\n                                             ItmNo,\r\n                                             Cost,\r\n                                             Qty,\r\n                                             ItmDes,\r\n                                             ItmUnt,\r\n                                             ItmDesE,\r\n                                             ItmUntE,\r\n                                             ItmUntPak,\r\n                                             StoreNo,\r\n                                             Price,\r\n                                             Amount,\r\n                                             RealQty,\r\n                                             itmInvDsc,\r\n                                             DatExper,\r\n                                             ItmDis,\r\n                                             ItmTyp,\r\n                                             ItmIndex,\r\n                                             ItmWight,\r\n                                             ItmWight_T,\r\n                                             ItmAddCost,\r\n                                             RunCod,\r\n                                             LineDetails,\r\n                                             Serial_Key,\r\n                                             ItmTax,\r\n                                             OfferTyp\r\n                                      )\r\n                                      VALUES\r\n                                      (\r\n                                             \r\n                                            @InvNo,\r\n                                            @InvId,\r\n                                            @InvSer,\r\n                                            @ItmNo,\r\n                                            @Cost,\r\n                                            @Qty,\r\n                                            @ItmDes,\r\n                                            @ItmUnt,\r\n                                            @ItmDesE,\r\n                                            @ItmUntE,\r\n                                            @ItmUntPak,\r\n                                            @StoreNo,\r\n                                            @Price,\r\n                                            @Amount,\r\n                                            @RealQty,\r\n                                            @itmInvDsc,\r\n                                            @DatExper,\r\n                                            @ItmDis,\r\n                                            @ItmTyp,\r\n                                            @ItmIndex,\r\n                                            @ItmWight,\r\n                                            @ItmWight_T,\r\n                                            @ItmAddCost,\r\n                                            @RunCod,\r\n                                            @LineDetails,\r\n                                            @Serial_Key,\r\n                                            @ItmTax,\r\n                                            @OfferTyp\r\n                                      )\r\n                                      SELECT @InvDet_ID = SCOPE_IDENTITY()\r\n                                        declare @ItemCount int  \r\n                                        declare @InvTyp int\r\n                                        declare @MndID int\r\n                                        declare @CusVenNo varchar(30)\r\n                                        declare @ItemCountMnd int \r\n                                        declare @ItemCountCust int \r\n\t\t                                select @ItemCount = Count(*) from T_STKSQTY where itmNo = @ItmNo and storeNo =@StoreNo;\r\n                                        select @InvTyp = InvTyp from T_INVHED where InvHed_ID = @InvId;\r\n                                        if((@InvTyp != 7 and @InvTyp != 8 and @InvTyp != 9 and @InvTyp != 21) and @ItmTyp <> 3)\r\n                                        begin\r\n\t\t\t                                      if(@ItmTyp <> 2)\r\n\t\t\t                                      begin\r\n\t\t                                                Update T_Items SET OpenQty = OpenQty+@RealQty WHERE Itm_No = @ItmNo;\r\n\t\t\t                                            if(@ItemCount > 0)\r\n\t\t\t                                            begin\r\n\t\t\t                                            Update T_STKSQTY SET stkQty = stkQty+@RealQty WHERE itmNo = @ItmNo and storeNo = @StoreNo;\r\n\t\t\t                                            end\r\n\r\n\t\t\t                                            if(@ItemCount = 0)\r\n\t\t\t                                            begin \r\n\t\t\t                                            INSERT INTO T_STKSQTY(itmNo,storeNo,stkQty,stkInt) VALUES(@ItmNo,@StoreNo,@RealQty,0);\r\n\t\t\t                                            END\r\n                                                        if(@InvTyp = 14)\r\n                                                        begin\r\n\t\t\t\t                                            Update T_STKSQTY SET stkInt = stkInt+@RealQty WHERE itmNo = @ItmNo and storeNo = @StoreNo;\r\n                                                        end\r\n\r\n\t\t\t                                            select @ItemCount = Count(*) from T_QTYEXP where itmNo = @ItmNo and storeNo =@StoreNo and (DatExper = @DatExper and RunCod = @RunCod);\r\n\r\n\t\t\t                                            if(@ItemCount > 0 and (@DatExper <> '' or @RunCod <> ''))\r\n\t\t\t                                            begin\r\n\t\t\t                                            Update T_QTYEXP SET stkQty = stkQty+@RealQty WHERE itmNo = @ItmNo and storeNo = @StoreNo and (DatExper = @DatExper and RunCod = @RunCod);\r\n\t\t\t                                            end\r\n\r\n\t\t\t                                            if(@ItemCount = 0 and (@DatExper <> '' or @RunCod <> ''))\r\n\t\t\t                                            begin \r\n\t\t\t                                            INSERT INTO T_QTYEXP(itmNo,storeNo,DatExper,stkQty,RunCod) VALUES(@ItmNo,@StoreNo,@DatExper,@RealQty,@RunCod);\r\n\t\t\t                                            END\r\n                                            END\r\n\t\t\t                                      if(@InvTyp = 17)\r\n\t\t\t\t                                      begin\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t   select @MndID = MndNo from T_INVHED where InvHed_ID = @InvId;\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t   select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvId;\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t   if(@MndID > 0 )\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tbegin\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t          select @ItemCountMnd = Count(*) from T_StoreMnd where itmNo = @ItmNo and storeNo =@StoreNo and MndNo = @MndID;\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  if(@ItemCountMnd > 0)\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  begin\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t   Update T_StoreMnd SET stkQty = stkQty + abs(@RealQty) WHERE itmNo = @ItmNo and storeNo = @StoreNo and MndNo = @MndID;\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  end\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  if(@ItemCountMnd = 0)\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  begin \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t   INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,MndNo) VALUES(@ItmNo,@StoreNo,abs(@RealQty),0,@MndID);\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  END\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tEND\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t  else\r\n\t\t\t\t\t\t\t\t\t                        begin\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t         select @ItemCountCust = Count(*) from T_StoreMnd where itmNo = @ItmNo and storeNo =@StoreNo and CusVenNo = @CusVenNo;\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  if(@ItemCountCust > 0)\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  begin\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t   Update T_StoreMnd SET stkQty = stkQty + abs(@RealQty) WHERE itmNo = @ItmNo and storeNo = @StoreNo and CusVenNo = @CusVenNo;\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  end\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  if(@ItemCountCust = 0)\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  begin \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t   INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,CusVenNo) VALUES(@ItmNo,@StoreNo,abs(@RealQty),0,@CusVenNo);\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  END\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tEND\r\n\t\t\t\t                                      END\t\r\n\t\t\t                                      if(@InvTyp = 20)\r\n\t\t\t\t                                      begin\r\n\t\t\t\t                                          select @MndID = MndNo from T_INVHED where InvHed_ID = @InvId;\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t  select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvId;\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t    if(@MndID > 0 )\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tbegin\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t select @ItemCountMnd = Count(*) from T_StoreMnd where itmNo = @ItmNo and storeNo =@StoreNo and MndNo = @MndID;\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  if(@ItemCountMnd > 0)\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  begin\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t   Update T_StoreMnd SET stkQty = stkQty + (-@RealQty) WHERE itmNo = @ItmNo and storeNo = @StoreNo and MndNo = @MndID;\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  end\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  if(@ItemCountMnd = 0)\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  begin \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t   INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,MndNo) VALUES(@ItmNo,@StoreNo,-@RealQty,0,@MndID);\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  END\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t END\r\n\t\t\t\t\t\t\t                                 else\r\n\t\t\t\t\t\t\t                                     begin\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t select @ItemCountCust = Count(*) from T_StoreMnd where itmNo = @ItmNo and storeNo =@StoreNo and CusVenNo = @CusVenNo;\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  if(@ItemCountCust > 0)\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  begin\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t   Update T_StoreMnd SET stkQty = stkQty + (-@RealQty) WHERE itmNo = @ItmNo and storeNo = @StoreNo and CusVenNo = @CusVenNo;\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  end\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  if(@ItemCountCust = 0)\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  begin \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t   INSERT INTO T_StoreMnd(itmNo,storeNo,stkQty,stkInt,CusVenNo) VALUES(@ItmNo,@StoreNo,-@RealQty,0,@CusVenNo);\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  END\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t END\r\n\t\t\t\t                                      end\r\n                                        end\r\n                                      RETURN @InvDet_ID\r\n                                      END");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("      ALTER PROCEDURE [dbo].[S_T_INVDET_DELETE](\r\n                                                      @InvDet_ID INT \r\n                                          )\r\n                                          AS\r\n                                          BEGIN\r\n                                        declare @InvTyp int \r\n                                        declare @InvId int\r\n                                        declare @MndID int\r\n                                        declare @CusVenNo varchar(30)\r\n                                        declare @PaymentOrderTyp int\r\n                                        declare @ItemCountMnd int \r\n                                        declare @MndKind int \r\n                                         \r\n                                        select @InvId = InvId from T_INVDET where InvDet_ID = @InvDet_ID;\r\n\r\n                                        select @InvTyp = InvTyp from T_INVHED where InvHed_ID = @InvId;\r\n\r\n                                        select @MndID = MndNo from T_INVHED where InvHed_ID = @InvId;\r\n                                        \r\n                                        select @PaymentOrderTyp = PaymentOrderTyp from T_INVHED where InvHed_ID = @InvId;\r\n\r\n                                        select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvId;\r\n                                        \r\n                                        select @MndKind = Mnd_Typ from T_Mndob where Mnd_ID = @MndID;\r\n                                        \r\n                                        if(@InvTyp != 7 and @InvTyp != 8 and @InvTyp != 9 and @InvTyp != 21)\r\n                                        begin\r\n                                             if((@PaymentOrderTyp <= 0 or @PaymentOrderTyp is null) or ((@PaymentOrderTyp = 1 or @PaymentOrderTyp = 2) and (@InvTyp = 17 or @InvTyp = 20) ))\r\n\t\t                                      begin\r\n\t\t\t                                      UPDATE T_Items SET T_Items.OpenQty = T_Items.OpenQty - T_INVDET.RealQty \r\n\t\t\t                                      From T_INVDET Left Join T_Items ON (T_INVDET.ItmNo = T_Items.Itm_No) \r\n\t\t\t                                      where (InvDet_ID = @InvDet_ID) and (T_INVDET.ItmTyp <> 3) and (T_INVDET.ItmTyp <> 2);\r\n\r\n\t\t\t                                      UPDATE T_STKSQTY SET T_STKSQTY.stkQty = T_STKSQTY.stkQty - T_INVDET.RealQty \r\n\t\t\t                                      From T_INVDET Left Join T_STKSQTY ON (T_INVDET.ItmNo = T_STKSQTY.itmNo) AND (T_INVDET.StoreNo = T_STKSQTY.storeNo)  \r\n\t\t\t                                      where @InvDet_ID = InvDet_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);\r\n                                    \t\t\t  \r\n\t\t\t                                      UPDATE T_QTYEXP SET T_QTYEXP.stkQty = T_QTYEXP.stkQty - T_INVDET.RealQty \r\n\t\t\t                                      From  T_INVDET Left Join T_QTYEXP ON (T_INVDET.ItmNo = T_QTYEXP.itmNo) AND (T_INVDET.StoreNo = T_QTYEXP.storeNo) AND (T_INVDET.DatExper = T_QTYEXP.DatExper and T_INVDET.RunCod = T_QTYEXP.RunCod )\r\n\t\t\t                                      where @InvDet_ID = InvDet_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);\r\n                                             end\r\n                                             if(@InvTyp = 14)\r\n\t\t                                      begin\r\n\t\t\t                                      UPDATE T_STKSQTY SET T_STKSQTY.stkInt = T_STKSQTY.stkInt - T_INVDET.RealQty \r\n\t\t\t                                      From T_INVDET Left Join T_STKSQTY ON (T_INVDET.ItmNo = T_STKSQTY.itmNo) AND (T_INVDET.StoreNo = T_STKSQTY.storeNo)  \r\n\t\t\t                                      where @InvDet_ID = InvDet_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);\r\n\t\t                                      end\r\n                                         if(@InvTyp = 17)\r\n\t                                     begin\r\n\r\n                                    \t\t\t\t  \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t  select @MndID = MndNo from T_INVHED where InvHed_ID = @InvId;\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty - abs(T_INVDET.RealQty)\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo)  \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t  where @InvDet_ID = InvDet_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.MndNo = @MndID ;\r\n\t\t\t\t                                      \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t  select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvId;\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty - abs(T_INVDET.RealQty)\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo)  \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t  where @InvDet_ID = InvDet_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.CusVenNo = @CusVenNo ;\r\n                                         end\r\n                                         \r\n                                         if(@InvTyp = 20)\r\n\t                                     begin\r\n                                    \t\t\t\t   \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t  select @MndID = MndNo from T_INVHED where InvHed_ID = @InvId;\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty + T_INVDET.RealQty \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo)  \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t  where @InvDet_ID = InvDet_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.MndNo = @MndID ;\r\n\t\t\t\t\t                                      \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t  select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvId;\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty + T_INVDET.RealQty \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo)  \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t  where @InvDet_ID = InvDet_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.CusVenNo = @CusVenNo ;\r\n                                         end\r\n                                        end\r\n                                         \r\n                                          DELETE FROM T_INVDET\r\n                                          WHERE      @InvDet_ID = InvDet_ID    \r\n\r\n                                          RETURN\r\n                                          END");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER PROCEDURE [dbo].[S_T_INVHED_DELETE](\r\n                                              @InvHed_ID INT \r\n                                  )\r\n                                  AS\r\n                                  BEGIN\r\n                                  declare @InvTyp int\r\n                                  declare @MndID int\r\n                                  declare @CusVenNo varchar(30)\r\n                                  declare @PaymentOrderTyp int\r\n                                  declare @MndKind int \r\n                                       \r\n                                  select @InvTyp = InvTyp from T_INVHED where InvHed_ID = @InvHed_ID;\r\n\r\n                                select @MndID = MndNo from T_INVHED where InvHed_ID = @InvHed_ID;\r\n                                \r\n                                select @PaymentOrderTyp = PaymentOrderTyp from T_INVHED where InvHed_ID = @InvHed_ID;\r\n\r\n                                select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvHed_ID;\r\n\r\n                                select @MndKind = Mnd_Typ from T_Mndob where Mnd_ID = @MndID;\r\n                                \r\n                                  if(@InvTyp != 7 and @InvTyp != 8 and @InvTyp != 9 and @InvTyp != 21)\r\n                                begin\r\n                                  if(@PaymentOrderTyp <= 0 or @PaymentOrderTyp is null)\r\n\t                              begin\r\n\t\t                              UPDATE T_Items SET T_Items.OpenQty = T_Items.OpenQty - T_INVDET.RealQty \r\n\t\t                              From T_INVDET Left Join T_Items ON (T_INVDET.ItmNo = T_Items.Itm_No) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID) \r\n\t\t                              where (InvHed_ID = @InvHed_ID) and (T_INVDET.ItmTyp <> 3) and (T_INVDET.ItmTyp <> 2);\r\n\r\n\t\t                              UPDATE T_STKSQTY SET T_STKSQTY.stkQty = T_STKSQTY.stkQty - T_INVDET.RealQty \r\n\t\t                              From T_INVDET Left Join T_STKSQTY ON (T_INVDET.ItmNo = T_STKSQTY.itmNo) AND (T_INVDET.StoreNo = T_STKSQTY.storeNo) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)  \r\n\t\t                              where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);\r\n                            \t\t  \r\n\t\t                              UPDATE T_QTYEXP SET T_QTYEXP.stkQty = T_QTYEXP.stkQty - T_INVDET.RealQty \r\n\t\t                              From  T_INVDET Left Join T_QTYEXP ON (T_INVDET.ItmNo = T_QTYEXP.itmNo) AND (T_INVDET.StoreNo = T_QTYEXP.storeNo) AND (T_INVDET.DatExper = T_QTYEXP.DatExper and T_INVDET.RunCod = T_QTYEXP.RunCod ) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)\r\n\t\t                              where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);\r\n                                  end\r\n                                 if(@InvTyp = 17)\r\n\t                             begin\r\n                                         if(@PaymentOrderTyp > 0)\r\n\t                                      begin\r\n \t\t\t\t\t\t\t\t\t\t      UPDATE T_Items SET T_Items.OpenQty = T_Items.OpenQty - T_INVDET.RealQty \r\n\t\t\t\t\t\t\t\t\t\t      From T_INVDET Left Join T_Items ON (T_INVDET.ItmNo = T_Items.Itm_No) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID) \r\n\t\t\t\t\t\t\t\t\t\t      where (InvHed_ID = @InvHed_ID) and (T_INVDET.ItmTyp <> 3) and (T_INVDET.ItmTyp <> 2);\r\n\r\n\t\t\t\t\t\t\t\t\t\t      UPDATE T_STKSQTY SET T_STKSQTY.stkQty = T_STKSQTY.stkQty - T_INVDET.RealQty \r\n\t\t\t\t\t\t\t\t\t\t      From T_INVDET Left Join T_STKSQTY ON (T_INVDET.ItmNo = T_STKSQTY.itmNo) AND (T_INVDET.StoreNo = T_STKSQTY.storeNo) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)  \r\n\t\t\t\t\t\t\t\t\t\t      where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);\r\n                                \t\t\t  \r\n\t\t\t\t\t\t\t\t\t\t      UPDATE T_QTYEXP SET T_QTYEXP.stkQty = T_QTYEXP.stkQty - T_INVDET.RealQty \r\n\t\t\t\t\t\t\t\t\t\t      From  T_INVDET Left Join T_QTYEXP ON (T_INVDET.ItmNo = T_QTYEXP.itmNo) AND (T_INVDET.StoreNo = T_QTYEXP.storeNo) AND (T_INVDET.DatExper = T_QTYEXP.DatExper and T_INVDET.RunCod = T_QTYEXP.RunCod ) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)\r\n\t\t\t\t\t\t\t\t\t\t      where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);\r\n                                          end\r\n\r\n\t\t\t\t\t\t\t\t\t\t  select @MndID = MndNo from T_INVHED where InvHed_ID = @InvHed_ID;  \t  \r\n\t\t\t\t\t\t\t\t\t\t  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty - abs(T_INVDET.RealQty)\r\n\t\t\t\t\t\t\t\t\t\t  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)  \r\n\t\t\t\t\t\t\t\t\t\t  where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.MndNo = @MndID ;\r\n\t\t\t\t\t\t\t\t\t\t  \r\n\t\t\t\t\t\t\t\t\t\t  select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvHed_ID;  \t  \r\n\t\t\t\t\t\t\t\t\t\t  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty - abs(T_INVDET.RealQty)\r\n\t\t\t\t\t\t\t\t\t\t  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)  \r\n\t\t\t\t\t\t\t\t\t\t  where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.CusVenNo = @CusVenNo ;\r\n                                 end\r\n                                 \r\n                                 if(@InvTyp = 20)\r\n\t                             begin\r\n                                         if(@PaymentOrderTyp > 0)\r\n\t                                      begin\r\n \t\t\t\t\t\t\t\t\t\t      UPDATE T_Items SET T_Items.OpenQty = T_Items.OpenQty - T_INVDET.RealQty \r\n\t\t\t\t\t\t\t\t\t\t      From T_INVDET Left Join T_Items ON (T_INVDET.ItmNo = T_Items.Itm_No) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID) \r\n\t\t\t\t\t\t\t\t\t\t      where (InvHed_ID = @InvHed_ID) and (T_INVDET.ItmTyp <> 3) and (T_INVDET.ItmTyp <> 2);\r\n\r\n\t\t\t\t\t\t\t\t\t\t      UPDATE T_STKSQTY SET T_STKSQTY.stkQty = T_STKSQTY.stkQty - T_INVDET.RealQty \r\n\t\t\t\t\t\t\t\t\t\t      From T_INVDET Left Join T_STKSQTY ON (T_INVDET.ItmNo = T_STKSQTY.itmNo) AND (T_INVDET.StoreNo = T_STKSQTY.storeNo) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)  \r\n\t\t\t\t\t\t\t\t\t\t      where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);\r\n                                \t\t\t  \r\n\t\t\t\t\t\t\t\t\t\t      UPDATE T_QTYEXP SET T_QTYEXP.stkQty = T_QTYEXP.stkQty - T_INVDET.RealQty \r\n\t\t\t\t\t\t\t\t\t\t      From  T_INVDET Left Join T_QTYEXP ON (T_INVDET.ItmNo = T_QTYEXP.itmNo) AND (T_INVDET.StoreNo = T_QTYEXP.storeNo) AND (T_INVDET.DatExper = T_QTYEXP.DatExper and T_INVDET.RunCod = T_QTYEXP.RunCod ) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)\r\n\t\t\t\t\t\t\t\t\t\t      where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);\r\n                                          end\r\n\t\t\t\t\t\t\t\t\t\t\t  select @MndID = MndNo from T_INVHED where InvHed_ID = @InvHed_ID;  \t  \r\n\t\t\t\t\t\t\t\t\t\t\t  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty + T_INVDET.RealQty \r\n\t\t\t\t\t\t\t\t\t\t\t  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)  \r\n\t\t\t\t\t\t\t\t\t\t\t  where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.MndNo = @MndID ;\r\n\t\t\t\t\t\t\t\t\t\t\t  \r\n\t\t\t\t\t\t\t\t\t\t\t  select @CusVenNo = CusVenNo from T_INVHED where InvHed_ID = @InvHed_ID;  \t  \r\n\t\t\t\t\t\t\t\t\t\t\t  UPDATE T_StoreMnd SET T_StoreMnd.stkQty = T_StoreMnd.stkQty + T_INVDET.RealQty \r\n\t\t\t\t\t\t\t\t\t\t\t  From T_INVDET Left Join T_StoreMnd ON (T_INVDET.ItmNo = T_StoreMnd.itmNo) AND (T_INVDET.StoreNo = T_StoreMnd.storeNo) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)  \r\n\t\t\t\t\t\t\t\t\t\t\t  where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and T_StoreMnd.CusVenNo = @CusVenNo ;\r\n                                 end\r\n                             \r\n                                  if(@InvTyp = 14)\r\n                                  begin\r\n\t\t                              UPDATE T_STKSQTY SET T_STKSQTY.stkInt = T_STKSQTY.stkInt - T_INVDET.RealQty \r\n\t\t                              From T_INVDET Left Join T_STKSQTY ON (T_INVDET.ItmNo = T_STKSQTY.itmNo) AND (T_INVDET.StoreNo = T_STKSQTY.storeNo) Left Join T_INVHED ON (T_INVDET.InvId = T_INVHED.InvHed_ID)  \r\n\t\t                              where InvHed_ID = @InvHed_ID and T_INVDET.ItmTyp <> 3 and (T_INVDET.ItmTyp <> 2);\r\n                                  end       \r\n                                  \r\n                                end\r\n                                  UPDATE T_INVHED SET T_INVHED.IfDel = 1 \r\n                                  FROM  T_INVHED\r\n                                  WHERE  @InvHed_ID = InvHed_ID\r\n\r\n                                  RETURN\r\n                                  END");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER PROCEDURE [dbo].[S_T_INVHED_INSERT](   \r\n                                                                     @InvHed_ID INT OUTPUT,\r\n                                                                     @InvId FLOAT =NULL,\r\n                                                                     @InvNo VARCHAR (10),\r\n                                                                     @InvTyp INT =NULL,\r\n                                                                     @InvCashPay INT =NULL,\r\n                                                                     @CusVenNo VARCHAR (20)=NULL,\r\n                                                                     @CusVenNm VARCHAR (50)=NULL,\r\n                                                                     @CusVenAdd VARCHAR (100)=NULL,\r\n                                                                     @CusVenTel VARCHAR (30)=NULL,\r\n                                                                     @Remark VARCHAR (MAX)=NULL,\r\n                                                                     @HDat VARCHAR (10)=NULL,\r\n                                                                     @GDat VARCHAR (10)=NULL,\r\n                                                                     @MndNo INT =NULL,\r\n                                                                     @SalsManNo VARCHAR (3)=NULL,\r\n                                                                     @SalsManNam VARCHAR (50)=NULL,\r\n                                                                     @InvTot FLOAT =NULL,\r\n                                                                     @InvTotLocCur FLOAT =NULL,\r\n                                                                     @InvDisPrs FLOAT =NULL,\r\n                                                                     @InvDisVal FLOAT =NULL,\r\n                                                                     @InvDisValLocCur FLOAT =NULL,\r\n                                                                     @InvNet FLOAT =NULL,\r\n                                                                     @InvNetLocCur FLOAT =NULL,\r\n                                                                     @CashPay FLOAT =NULL,\r\n                                                                     @CashPayLocCur FLOAT =NULL,\r\n                                                                     @IfRet INT =NULL,\r\n                                                                     @GadeNo FLOAT =NULL,\r\n                                                                     @GadeId FLOAT =NULL,\r\n                                                                     @IfDel INT =NULL,\r\n                                                                     @RetNo VARCHAR (10)=NULL,\r\n                                                                     @RetId FLOAT =NULL,\r\n                                                                     @InvCstNo INT =NULL,\r\n                                                                     @InvCashPayNm VARCHAR (100)=NULL,\r\n                                                                     @RefNo VARCHAR (20)=NULL,\r\n                                                                     @InvCost FLOAT =NULL,\r\n                                                                     @EstDat VARCHAR (10)=NULL,\r\n                                                                     @CustPri INT =NULL,\r\n                                                                     @ArbTaf VARCHAR (150)=NULL,\r\n                                                                     @CurTyp INT =NULL,\r\n                                                                     @InvCash VARCHAR (20)=NULL,\r\n                                                                     @ToStore VARCHAR (3)=NULL,\r\n                                                                     @ToStoreNm VARCHAR (50)=NULL,\r\n                                                                     @InvQty FLOAT =NULL,\r\n                                                                     @EngTaf VARCHAR (150)=NULL,\r\n                                                                     @IfTrans INT =NULL,\r\n                                                                     @CustRep FLOAT =NULL,\r\n                                                                     @CustNet FLOAT =NULL,\r\n                                                                     @InvWight_T FLOAT =NULL,\r\n                                                                     @IfPrint INT =NULL,\r\n                                                                     @LTim VARCHAR (10)=NULL,\r\n                                                                     @CREATED_BY VARCHAR(100) =NULL,\r\n                                                                     @DATE_CREATED datetime =NULL,\r\n                                                                     @MODIFIED_BY VARCHAR (100)=NULL,\r\n                                                                     @DATE_MODIFIED datetime=NULL,\r\n                                                                     @CreditPay float=NULL,\r\n                                                                     @CreditPayLocCur float=NULL,\r\n                                                                     @NetworkPay float=NULL,\r\n                                                                     @NetworkPayLocCur float=NULL,\r\n                                                                     @CommMnd_Inv float=NULL,\r\n                                                                     @MndExtrnal bit=NULL,\r\n                                                                     @CompanyID int=NULL,\r\n                                                                     @InvAddCost float=NULL,\r\n                                                                     @InvAddCostLoc float=NULL,\r\n                                                                     @InvAddCostExtrnal float=NULL,\r\n                                                                     @InvAddCostExtrnalLoc float=NULL,\r\n                                                                     @IsExtrnalGaid bit=NULL,\r\n                                                                     @ExtrnalCostGaidID float=NULL,\r\n                                                                     @Puyaid float=NULL,\r\n                                                                     @Remming float=NULL,\r\n                                                                     @RoomNo int=NULL,\r\n                                                                     @OrderTyp int=NULL,\r\n                                                                     @RoomSts bit=NULL,\r\n                                                                     @chauffeurNo int=NULL,\r\n                                                                     @RoomPerson int=NULL,\r\n                                                                     @ServiceValue float=NULL,\r\n                                                                     @Sts bit=NULL,\r\n                                                                     @PaymentOrderTyp int=NULL,\r\n                                                                     @AdminLock bit=NULL,\r\n                                                                     @DeleteDate VARCHAR (10)=NULL,\r\n                                                                     @DeleteTime VARCHAR (10)=NULL,\r\n                                                                     @UserNew VARCHAR (3)=NULL,\r\n                                                                     @IfEnter int=NULL,\r\n                                                                     @InvAddTax float=NULL,\r\n                                                                     @InvAddTaxlLoc float=NULL,\r\n                                                                     @IsTaxGaid bit=NULL,\r\n                                                                     @TaxGaidID float=NULL,\r\n                                                                     @IsTaxUse bit=NULL,\r\n                                                                     @InvValGaidDis float=NULL,\r\n                                                                     @InvValGaidDislLoc float=NULL,\r\n                                                                     @IsDisGaid bit=NULL,\r\n                                                                     @DisGaidID1 float=NULL,\r\n                                                                     @IsDisUse1 bit=NULL,\r\n                                                                     @InvComm float=NULL,\r\n                                                                     @InvCommLoc float=NULL,\r\n                                                                     @IsCommGaid bit=NULL,\r\n                                                                     @CommGaidID float=NULL,\r\n                                                                     @IsCommUse bit=NULL,\r\n                                                                     @IsTaxLines bit=NULL,\r\n                                                                     @IsTaxByTotal bit=NULL,\r\n                                                                     @IsTaxByNet bit=NULL,\r\n                                                                     @TaxByNetValue float=NULL,\r\n                                                                     @DesPointsValue float=NULL,\r\n                                                                     @DesPointsValueLocCur float=NULL,\r\n                                                                     @PointsCount float=NULL,\r\n                                                                     @IsPoints bit=NULL,\r\n                                                                     @tailor1 VARCHAR (100)=NULL,\r\n                                                                     @tailor2 VARCHAR (100)=NULL,\r\n                                                                     @tailor3 VARCHAR (100)=NULL,\r\n                                                                     @tailor4 VARCHAR (100)=NULL,\r\n                                                                     @tailor5 VARCHAR (100)=NULL,\r\n                                                                     @tailor6 VARCHAR (100)=NULL,\r\n                                                                     @tailor7 VARCHAR (100)=NULL,\r\n                                                                     @tailor8 VARCHAR (100)=NULL,\r\n                                                                     @tailor9 VARCHAR (100)=NULL,\r\n                                                                     @tailor10 VARCHAR (100)=NULL,\r\n                                                                     @tailor11 VARCHAR (100)=NULL,\r\n                                                                     @tailor12 VARCHAR (100)=NULL,\r\n                                                                     @tailor13 VARCHAR (100)=NULL,\r\n                                                                     @tailor14 VARCHAR (100)=NULL,\r\n                                                                     @tailor15 VARCHAR (100)=NULL,\r\n                                                                     @tailor16 VARCHAR (100)=NULL,\r\n                                                                     @tailor17 VARCHAR (100)=NULL,\r\n                                                                     @tailor18 VARCHAR (100)=NULL,\r\n                                                                     @tailor19 VARCHAR (100)=NULL,\r\n                                                                     @tailor20 VARCHAR (100)=NULL,\r\n                                                                     @InvImg [varbinary](max) =NULL\r\n                                                              )\r\n                                                              AS\r\n                                                              BEGIN\r\n\r\n                                                              INSERT INTO T_INVHED(\r\n                                                                     InvId,\r\n                                                                     InvNo,\r\n                                                                     InvTyp,\r\n                                                                     InvCashPay,\r\n                                                                     CusVenNo,\r\n                                                                     CusVenNm,\r\n                                                                     HDat,\r\n                                                                     CusVenAdd,\r\n                                                                     CusVenTel,\r\n                                                                     Remark,\r\n                                                                     GDat,\r\n                                                                     MndNo,\r\n                                                                     SalsManNo,\r\n                                                                     SalsManNam,\r\n                                                                     InvTot,\r\n                                                                     InvTotLocCur,\r\n                                                                     InvDisPrs,\r\n                                                                     InvDisVal,\r\n                                                                     InvDisValLocCur,\r\n                                                                     InvNet,\r\n                                                                     InvNetLocCur,\r\n                                                                     CashPay,\r\n                                                                     CashPayLocCur,\r\n                                                                     IfRet,\r\n                                                                     GadeNo,\r\n                                                                     GadeId,\r\n                                                                     IfDel,\r\n                                                                     RetNo,\r\n                                                                     RetId,\r\n                                                                     InvCstNo,\r\n                                                                     InvCashPayNm,\r\n                                                                     RefNo,\r\n                                                                     InvCost,\r\n                                                                     EstDat,\r\n                                                                     CustPri,\r\n                                                                     ArbTaf,\r\n                                                                     CurTyp,\r\n                                                                     InvCash,\r\n                                                                     ToStore,\r\n                                                                     ToStoreNm,\r\n                                                                     InvQty,\r\n                                                                     EngTaf,\r\n                                                                     IfTrans,\r\n                                                                     CustRep,\r\n                                                                     CustNet,\r\n                                                                     InvWight_T,\r\n                                                                     IfPrint,\r\n                                                                     LTim,\r\n                                                                     CREATED_BY,\r\n                                                                     DATE_CREATED,\r\n                                                                     MODIFIED_BY ,\r\n                                                                     DATE_MODIFIED ,\r\n                                                                     CreditPay ,\r\n                                                                     CreditPayLocCur ,\r\n                                                                     NetworkPay ,\r\n                                                                     NetworkPayLocCur ,\r\n                                                                     CommMnd_Inv ,\r\n                                                                     MndExtrnal ,\r\n                                                                     CompanyID ,\r\n                                                                     InvAddCost ,\r\n                                                                     InvAddCostLoc ,\r\n                                                                     InvAddCostExtrnal ,\r\n                                                                     InvAddCostExtrnalLoc ,\r\n                                                                     IsExtrnalGaid ,\r\n                                                                     ExtrnalCostGaidID ,\r\n                                                                     Puyaid ,\r\n                                                                     Remming ,\r\n                                                                     RoomNo ,\r\n                                                                     OrderTyp ,\r\n                                                                     RoomSts ,\r\n                                                                     chauffeurNo ,\r\n                                                                     RoomPerson ,\r\n                                                                     ServiceValue ,\r\n                                                                     Sts ,\r\n                                                                     PaymentOrderTyp ,\r\n                                                                     AdminLock ,\r\n                                                                     DeleteDate ,\r\n                                                                     DeleteTime ,\r\n                                                                     UserNew ,\r\n                                                                     IfEnter ,\r\n                                                                     InvAddTax ,\r\n                                                                     InvAddTaxlLoc ,\r\n                                                                     IsTaxGaid ,\r\n                                                                     TaxGaidID ,\r\n                                                                     IsTaxUse ,\r\n                                                                     InvValGaidDis ,\r\n                                                                     InvValGaidDislLoc ,\r\n                                                                     IsDisGaid ,\r\n                                                                     DisGaidID1 ,\r\n                                                                     IsDisUse1 ,\r\n                                                                     InvComm ,\r\n                                                                     InvCommLoc ,\r\n                                                                     IsCommGaid ,\r\n                                                                     CommGaidID ,\r\n                                                                     IsCommUse ,\r\n                                                                     IsTaxLines ,\r\n                                                                     IsTaxByTotal ,\r\n                                                                     IsTaxByNet ,\r\n                                                                     TaxByNetValue ,\r\n                                                                     DesPointsValue ,\r\n                                                                     DesPointsValueLocCur ,\r\n                                                                     PointsCount,\r\n                                                                     IsPoints,\r\n                                                                     tailor1 ,\r\n                                                                     tailor2 ,\r\n                                                                     tailor3 ,\r\n                                                                     tailor4 ,\r\n                                                                     tailor5 ,\r\n                                                                     tailor6 ,\r\n                                                                     tailor7 ,\r\n                                                                     tailor8 ,\r\n                                                                     tailor9 ,\r\n                                                                     tailor10 ,\r\n                                                                     tailor11 ,\r\n                                                                     tailor12 ,\r\n                                                                     tailor13 ,\r\n                                                                     tailor14 ,\r\n                                                                     tailor15 ,\r\n                                                                     tailor16 ,\r\n                                                                     tailor17 ,\r\n                                                                     tailor18 ,\r\n                                                                     tailor19 ,\r\n                                                                     tailor20,\r\n                                                                     InvImg\r\n                                                              )\r\n                                                              VALUES\r\n                                                              (\r\n                                                                     \r\n                                                                    @InvId,\r\n                                                                    @InvNo,\r\n                                                                    @InvTyp,\r\n                                                                    @InvCashPay,\r\n                                                                    @CusVenNo,\r\n                                                                    @CusVenNm,\r\n                                                                    @HDat,\r\n                                                                    @CusVenAdd,\r\n                                                                    @CusVenTel,\r\n                                                                    @Remark,\r\n                                                                    @GDat,\r\n                                                                    @MndNo,\r\n                                                                    @SalsManNo,\r\n                                                                    @SalsManNam,\r\n                                                                    @InvTot,\r\n                                                                    @InvTotLocCur,\r\n                                                                    @InvDisPrs,\r\n                                                                    @InvDisVal,\r\n                                                                    @InvDisValLocCur,\r\n                                                                    @InvNet,\r\n                                                                    @InvNetLocCur,\r\n                                                                    @CashPay,\r\n                                                                    @CashPayLocCur,\r\n                                                                    @IfRet,\r\n                                                                    @GadeNo,\r\n                                                                    @GadeId,\r\n                                                                    @IfDel,\r\n                                                                    @RetNo,\r\n                                                                    @RetId,\r\n                                                                    @InvCstNo,\r\n                                                                    @InvCashPayNm,\r\n                                                                    @RefNo,\r\n                                                                    @InvCost,\r\n                                                                    @EstDat,\r\n                                                                    @CustPri,\r\n                                                                    @ArbTaf,\r\n                                                                    @CurTyp,\r\n                                                                    @InvCash,\r\n                                                                    @ToStore,\r\n                                                                    @ToStoreNm,\r\n                                                                    @InvQty,\r\n                                                                    @EngTaf,\r\n                                                                    @IfTrans,\r\n                                                                    @CustRep,\r\n                                                                    @CustNet,\r\n                                                                    @InvWight_T,\r\n                                                                    @IfPrint,\r\n                                                                    @LTim,\r\n                                                                    @CREATED_BY,\r\n                                                                    @DATE_CREATED,\r\n                                                                    @MODIFIED_BY ,\r\n                                                                    @DATE_MODIFIED ,\r\n                                                                    @CreditPay ,\r\n                                                                    @CreditPayLocCur ,\r\n                                                                    @NetworkPay ,\r\n                                                                    @NetworkPayLocCur ,\r\n                                                                    @CommMnd_Inv ,\r\n                                                                    @MndExtrnal ,\r\n                                                                    @CompanyID ,\r\n                                                                    @InvAddCost ,\r\n                                                                    @InvAddCostLoc ,\r\n                                                                    @InvAddCostExtrnal ,\r\n                                                                    @InvAddCostExtrnalLoc ,\r\n                                                                    @IsExtrnalGaid ,\r\n                                                                    @ExtrnalCostGaidID ,\r\n                                                                    @Puyaid ,\r\n                                                                    @Remming ,\r\n                                                                    @RoomNo ,\r\n                                                                    @OrderTyp ,\r\n                                                                    @RoomSts ,\r\n                                                                    @chauffeurNo ,\r\n                                                                    @RoomPerson ,\r\n                                                                    @ServiceValue ,\r\n                                                                    @Sts ,\r\n                                                                    @PaymentOrderTyp ,\r\n                                                                    @AdminLock ,\r\n                                                                    @DeleteDate ,\r\n                                                                    @DeleteTime ,\r\n                                                                    @UserNew ,\r\n                                                                    @IfEnter ,\r\n                                                                    @InvAddTax ,\r\n                                                                    @InvAddTaxlLoc ,\r\n                                                                    @IsTaxGaid ,\r\n                                                                    @TaxGaidID ,\r\n                                                                    @IsTaxUse ,\r\n                                                                    @InvValGaidDis ,\r\n                                                                    @InvValGaidDislLoc ,\r\n                                                                    @IsDisGaid ,\r\n                                                                    @DisGaidID1 ,\r\n                                                                    @IsDisUse1 ,\r\n                                                                    @InvComm ,\r\n                                                                    @InvCommLoc ,\r\n                                                                    @IsCommGaid ,\r\n                                                                    @CommGaidID ,\r\n                                                                    @IsCommUse ,\r\n                                                                    @IsTaxLines ,\r\n                                                                    @IsTaxByTotal ,\r\n                                                                    @IsTaxByNet ,\r\n                                                                    @TaxByNetValue ,\r\n                                                                    @DesPointsValue ,\r\n                                                                    @DesPointsValueLocCur ,\r\n                                                                    @PointsCount,\r\n                                                                    @IsPoints,\r\n                                                                    @tailor1 ,\r\n                                                                    @tailor2 ,\r\n                                                                    @tailor3 ,\r\n                                                                    @tailor4 ,\r\n                                                                    @tailor5 ,\r\n                                                                    @tailor6 ,\r\n                                                                    @tailor7 ,\r\n                                                                    @tailor8 ,\r\n                                                                    @tailor9 ,\r\n                                                                    @tailor10 ,\r\n                                                                    @tailor11 ,\r\n                                                                    @tailor12 ,\r\n                                                                    @tailor13 ,\r\n                                                                    @tailor14 ,\r\n                                                                    @tailor15 ,\r\n                                                                    @tailor16 ,\r\n                                                                    @tailor17 ,\r\n                                                                    @tailor18 ,\r\n                                                                    @tailor19 ,\r\n                                                                    @tailor20,\r\n                                                                    @InvImg\r\n                                                              )\r\n\r\n\r\n                                                              SELECT @InvHed_ID = SCOPE_IDENTITY()\r\n                                                                      \r\n\r\n                                                              RETURN\r\n                                                              END");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER PROCEDURE [dbo].[S_T_INVHED_UPDATE](\r\n                                                                                 @InvHed_ID INT ,\r\n                                                                                 @InvId FLOAT =NULL,\r\n                                                                                 @InvNo VARCHAR (10),\r\n                                                                                 @InvTyp INT =NULL,\r\n                                                                                 @InvCashPay INT =NULL,\r\n                                                                                 @CusVenNo VARCHAR (20)=NULL,\r\n                                                                                 @CusVenNm VARCHAR (50)=NULL,\r\n                                                                                 @CusVenAdd VARCHAR (100)=NULL,\r\n                                                                                 @CusVenTel VARCHAR (30)=NULL,\r\n                                                                                 @Remark VARCHAR (MAX)=NULL,\r\n                                                                                 @HDat VARCHAR (10)=NULL,\r\n                                                                                 @GDat VARCHAR (10)=NULL,\r\n                                                                                 @MndNo INT =NULL,\r\n                                                                                 @SalsManNo VARCHAR (3)=NULL,\r\n                                                                                 @SalsManNam VARCHAR (50)=NULL,\r\n                                                                                 @InvTot FLOAT =NULL,\r\n                                                                                 @InvTotLocCur FLOAT =NULL,\r\n                                                                                 @InvDisPrs FLOAT =NULL,\r\n                                                                                 @InvDisVal FLOAT =NULL,\r\n                                                                                 @InvDisValLocCur FLOAT =NULL,\r\n                                                                                 @InvNet FLOAT =NULL,\r\n                                                                                 @InvNetLocCur FLOAT =NULL,\r\n                                                                                 @CashPay FLOAT =NULL,\r\n                                                                                 @CashPayLocCur FLOAT =NULL,\r\n                                                                                 @IfRet INT =NULL,\r\n                                                                                 @GadeNo FLOAT =NULL,\r\n                                                                                 @GadeId FLOAT =NULL,\r\n                                                                                 @IfDel INT =NULL,\r\n                                                                                 @RetNo VARCHAR (10)=NULL,\r\n                                                                                 @RetId FLOAT =NULL,\r\n                                                                                 @InvCstNo INT =NULL,\r\n                                                                                 @InvCashPayNm VARCHAR (100)=NULL,\r\n                                                                                 @RefNo VARCHAR (20)=NULL,\r\n                                                                                 @InvCost FLOAT =NULL,\r\n                                                                                 @EstDat VARCHAR (10)=NULL,\r\n                                                                                 @CustPri INT =NULL,\r\n                                                                                 @ArbTaf VARCHAR (150)=NULL,\r\n                                                                                 @CurTyp INT =NULL,\r\n                                                                                 @InvCash VARCHAR (20)=NULL,\r\n                                                                                 @ToStore VARCHAR (3)=NULL,\r\n                                                                                 @ToStoreNm VARCHAR (50)=NULL,\r\n                                                                                 @InvQty FLOAT =NULL,\r\n                                                                                 @EngTaf VARCHAR (150)=NULL,\r\n                                                                                 @IfTrans INT =NULL,\r\n                                                                                 @CustRep FLOAT =NULL,\r\n                                                                                 @CustNet FLOAT =NULL,\r\n                                                                                 @InvWight_T FLOAT =NULL,\r\n                                                                                 @IfPrint INT =NULL,\r\n                                                                                 @LTim VARCHAR (10)=NULL,\r\n                                                                                 @CREATED_BY VARCHAR(100) =NULL,\r\n                                                                                 @DATE_CREATED datetime =NULL,\r\n                                                                                 @MODIFIED_BY VARCHAR (100)=NULL,\r\n                                                                                 @DATE_MODIFIED datetime=NULL,\r\n                                                                                 @CreditPay float=NULL,\r\n                                                                                 @CreditPayLocCur float=NULL,\r\n                                                                                 @NetworkPay float=NULL,\r\n                                                                                 @NetworkPayLocCur float=NULL,\r\n                                                                                 @CommMnd_Inv float=NULL,\r\n                                                                                 @MndExtrnal bit=NULL,\r\n                                                                                 @CompanyID int=NULL,\r\n                                                                                 @InvAddCost float=NULL,\r\n                                                                                 @InvAddCostLoc float=NULL,\r\n                                                                                 @InvAddCostExtrnal float=NULL,\r\n                                                                                 @InvAddCostExtrnalLoc float=NULL,\r\n                                                                                 @IsExtrnalGaid bit=NULL,\r\n                                                                                 @ExtrnalCostGaidID float=NULL,\r\n                                                                                 @Puyaid float=NULL,\r\n                                                                                 @Remming float=NULL,\r\n                                                                                 @RoomNo int=NULL,\r\n                                                                                 @OrderTyp int=NULL,\r\n                                                                                 @RoomSts bit=NULL,\r\n                                                                                 @chauffeurNo int=NULL,\r\n                                                                                 @RoomPerson int=NULL,\r\n                                                                                 @ServiceValue float=NULL,\r\n                                                                                 @Sts bit=NULL,\r\n                                                                                 @PaymentOrderTyp int=NULL,\r\n                                                                                 @AdminLock bit=NULL,\r\n                                                                                 @DeleteDate VARCHAR (10)=NULL,\r\n                                                                                 @DeleteTime VARCHAR (10)=NULL,\r\n                                                                                 @UserNew VARCHAR (3)=NULL,\r\n                                                                                 @IfEnter int=NULL,\r\n                                                                                 @InvAddTax float=NULL,\r\n                                                                                 @InvAddTaxlLoc float=NULL,\r\n                                                                                 @IsTaxGaid bit=NULL,\r\n                                                                                 @TaxGaidID float=NULL,\r\n                                                                                 @IsTaxUse bit=NULL,\r\n                                                                                 @InvValGaidDis float=NULL,\r\n                                                                                 @InvValGaidDislLoc float=NULL,\r\n                                                                                 @IsDisGaid bit=NULL,\r\n                                                                                 @DisGaidID1 float=NULL,\r\n                                                                                 @IsDisUse1 bit=NULL,\r\n                                                                                 @InvComm float=NULL,\r\n                                                                                 @InvCommLoc float=NULL,\r\n                                                                                 @IsCommGaid bit=NULL,\r\n                                                                                 @CommGaidID float=NULL,\r\n                                                                                 @IsCommUse bit=NULL,\r\n                                                                                 @IsTaxLines bit=NULL,\r\n                                                                                 @IsTaxByTotal bit=NULL,\r\n                                                                                 @IsTaxByNet bit=NULL,\r\n                                                                                 @TaxByNetValue float=NULL,\r\n                                                                                 @DesPointsValue float=NULL,\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t     @DesPointsValueLocCur float=NULL,\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t     @PointsCount float=NULL,\r\n                                                                                 @IsPoints bit=NULL,\r\n                                                                                 @tailor1 VARCHAR (100)=NULL,\r\n                                                                                 @tailor2 VARCHAR (100)=NULL,\r\n                                                                                 @tailor3 VARCHAR (100)=NULL,\r\n                                                                                 @tailor4 VARCHAR (100)=NULL,\r\n                                                                                 @tailor5 VARCHAR (100)=NULL,\r\n                                                                                 @tailor6 VARCHAR (100)=NULL,\r\n                                                                                 @tailor7 VARCHAR (100)=NULL,\r\n                                                                                 @tailor8 VARCHAR (100)=NULL,\r\n                                                                                 @tailor9 VARCHAR (100)=NULL,\r\n                                                                                 @tailor10 VARCHAR (100)=NULL,\r\n                                                                                 @tailor11 VARCHAR (100)=NULL,\r\n                                                                                 @tailor12 VARCHAR (100)=NULL,\r\n                                                                                 @tailor13 VARCHAR (100)=NULL,\r\n                                                                                 @tailor14 VARCHAR (100)=NULL,\r\n                                                                                 @tailor15 VARCHAR (100)=NULL,\r\n                                                                                 @tailor16 VARCHAR (100)=NULL,\r\n                                                                                 @tailor17 VARCHAR (100)=NULL,\r\n                                                                                 @tailor18 VARCHAR (100)=NULL,\r\n                                                                                 @tailor19 VARCHAR (100)=NULL,\r\n                                                                                 @tailor20 VARCHAR (100)=NULL,\r\n                                                                                 @InvImg VARBINARY(max) =NULL\r\n                                  )\r\n                                  AS\r\n                                  BEGIN\r\n\r\n                                  UPDATE T_INVHED\r\n                                  SET    InvId = @InvId,\r\n                                         InvNo = @InvNo,\r\n                                         InvTyp = @InvTyp,\r\n                                         InvCashPay = @InvCashPay,\r\n                                         CusVenNo = @CusVenNo,\r\n                                         CusVenNm = @CusVenNm,\r\n                                         CusVenAdd = @CusVenAdd,\r\n                                         CusVenTel = @CusVenTel,\r\n                                         Remark = @Remark,\r\n                                         HDat = @HDat,\r\n                                         GDat = @GDat,\r\n                                         MndNo = @MndNo,\r\n                                         SalsManNo = @SalsManNo,\r\n                                         SalsManNam = @SalsManNam,\r\n                                         InvTot = @InvTot,\r\n                                         InvTotLocCur = @InvTotLocCur,\r\n                                         InvDisPrs = @InvDisPrs,\r\n                                         InvDisVal = @InvDisVal,\r\n                                         InvDisValLocCur = @InvDisValLocCur,\r\n                                         InvNet = @InvNet,\r\n                                         InvNetLocCur = @InvNetLocCur,\r\n                                         CashPay = @CashPay,\r\n                                         CashPayLocCur = @CashPayLocCur,\r\n                                         IfRet = @IfRet,\r\n                                         GadeNo = @GadeNo,\r\n                                         GadeId = @GadeId,\r\n                                         IfDel = @IfDel,\r\n                                         RetNo = @RetNo,\r\n                                         RetId = @RetId,\r\n                                         InvCstNo = @InvCstNo,\r\n                                         InvCashPayNm = @InvCashPayNm,\r\n                                         RefNo = @RefNo,\r\n                                         InvCost = @InvCost,\r\n                                         EstDat = @EstDat,\r\n                                         CustPri = @CustPri,\r\n                                         ArbTaf = @ArbTaf,\r\n                                         CurTyp = @CurTyp,\r\n                                         InvCash = @InvCash,\r\n                                         ToStore = @ToStore,\r\n                                         ToStoreNm = @ToStoreNm,\r\n                                         InvQty = @InvQty,\r\n                                         EngTaf = @EngTaf,\r\n                                         IfTrans = @IfTrans,\r\n                                         CustRep = @CustRep,\r\n                                         CustNet = @CustNet,\r\n                                         InvWight_T = @InvWight_T,\r\n                                         IfPrint = @IfPrint,\r\n                                         LTim = @LTim,\r\n                                         MODIFIED_BY = @MODIFIED_BY,\r\n                                         DATE_MODIFIED = @DATE_MODIFIED,\r\n                                                                                 CreditPay = @CreditPay,\r\n                                                                                 CreditPayLocCur = @CreditPayLocCur,\r\n                                                                                 NetworkPay = @NetworkPay,\r\n                                                                                 NetworkPayLocCur = @NetworkPayLocCur,\r\n                                                                                 CommMnd_Inv = @CommMnd_Inv,\r\n                                                                                 MndExtrnal = @MndExtrnal,\r\n                                                                                 CompanyID = @CompanyID,\r\n                                                                                 InvAddCost = @InvAddCost,\r\n                                                                                 InvAddCostLoc = @InvAddCostLoc,\r\n                                                                                 InvAddCostExtrnal = @InvAddCostExtrnal,\r\n                                                                                 InvAddCostExtrnalLoc = @InvAddCostExtrnalLoc,\r\n                                                                                 IsExtrnalGaid = @IsExtrnalGaid,\r\n                                                                                 ExtrnalCostGaidID = @ExtrnalCostGaidID,\r\n                                                                                 Puyaid = @Puyaid,\r\n                                                                                 Remming = @Remming,\r\n                                                                                 RoomNo = @RoomNo,\r\n                                                                                 OrderTyp = @OrderTyp,\r\n                                                                                 RoomSts = @RoomSts,\r\n                                                                                 chauffeurNo = @chauffeurNo,\r\n                                                                                 RoomPerson = @RoomPerson,\r\n                                                                                 ServiceValue = @ServiceValue,\r\n                                                                                 Sts = @Sts,\r\n                                                                                 PaymentOrderTyp = @PaymentOrderTyp,\r\n                                                                                 AdminLock = @AdminLock,\r\n                                                                                 DeleteDate = @DeleteDate,\r\n                                                                                 DeleteTime = @DeleteTime,\r\n                                                                                 UserNew = @UserNew,\r\n                                                                                 IfEnter = @IfEnter,\r\n                                                                                 InvAddTax = @InvAddTax,\r\n                                                                                 InvAddTaxlLoc = @InvAddTaxlLoc,\r\n                                                                                 IsTaxGaid = @IsTaxGaid,\r\n                                                                                 TaxGaidID = @TaxGaidID,\r\n                                                                                 IsTaxUse = @IsTaxUse,\r\n                                                                                 InvValGaidDis = @InvValGaidDis,\r\n                                                                                 InvValGaidDislLoc = @InvValGaidDislLoc,\r\n                                                                                 IsDisGaid = @IsDisGaid,\r\n                                                                                 DisGaidID1 = @DisGaidID1,\r\n                                                                                 IsDisUse1 = @IsDisUse1,\r\n                                                                                 InvComm = @InvComm,\r\n                                                                                 InvCommLoc = @InvCommLoc,\r\n                                                                                 IsCommGaid = @IsCommGaid,\r\n                                                                                 CommGaidID = @CommGaidID,\r\n                                                                                 IsCommUse = @IsCommUse,\r\n                                                                                 IsTaxLines = @IsTaxLines,\r\n                                                                                 IsTaxByTotal = @IsTaxByTotal,\r\n                                                                                 IsTaxByNet = @IsTaxByNet,\r\n                                                                                 TaxByNetValue = @TaxByNetValue,\r\n                                                                                 DesPointsValue = @DesPointsValue ,\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t DesPointsValueLocCur = @DesPointsValueLocCur ,\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t PointsCount = @PointsCount,\r\n                                                                                 IsPoints = @IsPoints,\r\n                                                                                 tailor1 = @tailor1 ,\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t tailor2 = @tailor2,\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t tailor3 = @tailor3,\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t tailor4 = @tailor4,\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t tailor5 = @tailor5,\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t tailor6 = @tailor6,\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t tailor7 = @tailor7,\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t tailor8 = @tailor8,\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t tailor9 = @tailor9,\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t tailor10 = @tailor10,\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t tailor11 = @tailor11,\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t tailor12 = @tailor12,\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t tailor13 = @tailor13,\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t tailor14 = @tailor14,\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t tailor15 = @tailor15,\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t tailor16 = @tailor16,\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t tailor17 = @tailor17,\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t tailor18 = @tailor18,\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t tailor19 = @tailor19,\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t tailor20 = @tailor20,\r\n                                                                                 InvImg   = @InvImg \r\n                                  WHERE  @InvHed_ID = InvHed_ID\r\n                                  RETURN\r\n                                  END");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("/****** Object:  StoredProcedure [dbo].[S_T_GDDET_INSERT]    Script Date: 12/23/2016 17:51:49 ******/\r\n                                    ALTER PROCEDURE [dbo].[S_T_GDDET_INSERT](   \r\n                                                 @GDDET_ID INT OUTPUT,\r\n                                                 @gdID INT =NULL,\r\n                                                 @gdNo VARCHAR (10)=NULL,\r\n                                                 @gdDes VARCHAR (100)=NULL,\r\n                                                 @gdDesE VARCHAR (100)=NULL,\r\n                                                 @recptTyp VARCHAR (20)=NULL,\r\n                                                 @AccNo VARCHAR (30)=NULL,\r\n                                                 @AccName VARCHAR (50)=NULL,\r\n                                                 @gdValue FLOAT =NULL,\r\n                                                 @recptNo VARCHAR (20)=NULL,\r\n                                                 @Lin INT =NULL,\r\n                                                 @AccNoDestruction VARCHAR (30)=NULL\r\n                                                 \r\n                                          )\r\n                                          AS\r\n                                          BEGIN\r\n\r\n                                          INSERT INTO T_GDDET(\r\n                                                 gdID,\r\n                                                 gdNo,\r\n                                                 gdDes,\r\n                                                 gdDesE,\r\n                                                 recptTyp,\r\n                                                 AccNo,\r\n                                                 AccName,\r\n                                                 gdValue,\r\n                                                 recptNo,\r\n                                                 Lin,\r\n                                                 AccNoDestruction\r\n                                          )\r\n                                          VALUES\r\n                                          (\r\n                                                 \r\n                                                @gdID,\r\n                                                @gdNo,\r\n                                                @gdDes,\r\n                                                @gdDesE,\r\n                                                @recptTyp,\r\n                                                @AccNo,\r\n                                                @AccName,\r\n                                                @gdValue,\r\n                                                @recptNo,\r\n                                                @Lin,\r\n                                                @AccNoDestruction\r\n                                          )\r\n                                          SELECT @GDDET_ID = SCOPE_IDENTITY()\r\n                                          UPDATE T_AccDef SET T_AccDef.Debit = T_AccDef.Debit + ROUND( T_GDDET.gdValue, case when Substring((select MAX(T_SYSSETTING.Seting) from T_SYSSETTING),49,1) = 0 then 2 else 3 end)\r\n                                          From T_AccDef Left Join T_GDDET ON (T_AccDef.AccDef_No = T_GDDET.AccNo) \r\n                                          where @GDDET_ID = GDDET_ID and  T_GDDET.gdValue > 0 ;\r\n                                          UPDATE T_AccDef SET T_AccDef.Credit = T_AccDef.Credit + ABS(ROUND( T_GDDET.gdValue, case when Substring((select MAX(T_SYSSETTING.Seting) from T_SYSSETTING),49,1) = 0 then 2 else 3 end))\r\n                                          From T_AccDef Left Join T_GDDET ON (T_AccDef.AccDef_No = T_GDDET.AccNo) \r\n                                          where @GDDET_ID = GDDET_ID and  T_GDDET.gdValue < 0 ;\r\n                                          UPDATE T_AccDef SET T_AccDef.Balance = T_AccDef.Debit - T_AccDef.Credit\r\n                                          From T_AccDef Left Join T_GDDET ON (T_AccDef.AccDef_No = T_GDDET.AccNo) \r\n                                          where @GDDET_ID = GDDET_ID ;\r\n                                          RETURN\r\n                                          END");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("update T_Items set T_Items.OpenQty = 0 where T_Items.Itm_No not in (select itmNo from T_STKSQTY) and T_Items.OpenQty > 0");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_Items ADD  [ItemComm] [float] NULL");
                    db.ExecuteCommand("Update [dbo].[T_Items] Set [ItemComm] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [IfEnter] [int] NULL");
                    db.ExecuteCommand("UPDATE [dbo].[T_INVHED] Set [IfEnter] = [IfRet] Where [InvTyp] = 6 ");
                    db.ExecuteCommand("UPDATE [dbo].[T_INVHED] Set [IfRet] = 0 Where [InvTyp] = 6 ");
                }
                catch
                {
                }
                try
                {
                    T_AccDef tAccDef1 = db.StockAccDef("3051002");
                    if (tAccDef1 == null || string.IsNullOrEmpty(tAccDef1.AccDef_No))
                    {
                        db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES ( N'3051002', N'?????????? ???????????? ??????????', N'Cost of raw materials', N'3051', 4, N'', 7, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)");
                        db.ExecuteCommand("Update [dbo].[T_INVHED] Set [IfEnter] = 0 where IfEnter is null");
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [AccSup] = '' where AccSup is null");
                        db.ExecuteCommand("alter table T_SYSSETTING alter column AccSup varchar(10)");
                        T_AccDef tAccDef2 = db.StockAccDef("3051001");
                        if (tAccDef2 != null && !string.IsNullOrEmpty(tAccDef2.AccDef_No))
                            db.ExecuteCommand("Update [dbo].[T_AccDef] Set [Arb_Des] = '?????????? ?????????? - ??????????' ,Eng_Des = 'Production of varieties' where AccDef_No= '3051001'");
                    }
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_Items ADD  [TaxSales] [float] NULL");
                    db.ExecuteCommand("Update [dbo].[T_Items] Set [TaxSales] = 0 ");
                    db.ExecuteCommand("ALTER TABLE T_Items ADD  [TaxPurchas] [float] NULL");
                    db.ExecuteCommand("Update [dbo].[T_Items] Set [TaxPurchas] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_Items ADD [InvEnterStoped] [bit] NULL");
                    db.ExecuteCommand("ALTER TABLE T_Items ADD [InvOutStoped] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_Items] Set [InvEnterStoped] = 0 ");
                    db.ExecuteCommand("Update [dbo].[T_Items] Set [InvOutStoped] = 0 ");
                }
                catch
                {
                }
#pragma warning disable CS0219 // The variable 'str1' is assigned but its value is never used
                string str1;
#pragma warning restore CS0219 // The variable 'str1' is assigned but its value is never used
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [InvAddTax] [float] NULL");
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [InvAddTax] = 0 where InvAddTax is null");
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [InvAddTaxlLoc] [float] NULL");
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [InvAddTaxlLoc] = 0 where InvAddTaxlLoc is null");
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [IsTaxGaid] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [IsTaxGaid] = 0 ");
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [TaxGaidID] [float] NULL");
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [IsTaxUse] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [IsTaxUse] = 1 ");
                    db.ExecuteCommand("ALTER TABLE T_INVDET ADD  [ItmTax] [float] NULL");
                    db.ExecuteCommand("Update [dbo].[T_INVDET] Set [ItmTax] = 0 where ItmTax is null");
                    db.ExecuteCommand("ALTER TABLE T_INVDET_Repair ADD  [ItmTax_Repair] [float] NULL");
                    db.ExecuteCommand("Update [dbo].[T_INVDET_Repair] Set [ItmTax_Repair] = 0 where ItmTax_Repair is null");
                    db.ExecuteCommand("ALTER TABLE T_SINVDET ADD  [SItmTax] [float] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SINVDET] Set [SItmTax] = 0 where SItmTax is null");
                    string str2 = "***";
                    string str3 = "***";
#pragma warning disable CS0219 // The variable 'num2' is assigned but its value is never used
                    int num2;
#pragma warning restore CS0219 // The variable 'num2' is assigned but its value is never used
                    T_AccDef tAccDef1;
                    try
                    {
                        T_AccDef tAccDef2 = db.StockAccDef("4011");
                        if (tAccDef2 != null && !string.IsNullOrEmpty(tAccDef2.AccDef_No))
                        {
                            try
                            {
                                num2 = 0;
                                string txtMainAccNo = "4011";
                                tAccDef1 = new T_AccDef();
                                List<T_AccDef> list = db.T_AccDefs.Where<T_AccDef>((Expression<Func<T_AccDef, bool>>)(t => t.ParAcc == txtMainAccNo)).OrderBy<T_AccDef, string>((Expression<Func<T_AccDef, string>>)(t => t.AccDef_No)).ToList<T_AccDef>();
                                str2 = list.Count != 0 ? string.Concat((object)(int.Parse(list[list.Count - 1].AccDef_No) + 1)) : txtMainAccNo + "001";
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID],MainSal,DepreciationPercent) VALUES (N'" + str2 + "', N'???????????? ?????????????? - ?????????? ????????????????', N'Sales Tax', N'4011', 4, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1,0,0)");
                            }
                            catch
                            {
                                str2 = "***";
                            }
                        }
                    }
                    catch
                    {
                        str2 = "***";
                    }
                    try
                    {
                        T_AccDef tAccDef2 = db.StockAccDef("4011");
                        if (tAccDef2 != null && !string.IsNullOrEmpty(tAccDef2.AccDef_No))
                        {
                            try
                            {
                                num2 = 0;
                                string txtMainAccNo = "4011";
                                tAccDef1 = new T_AccDef();
                                List<T_AccDef> list = db.T_AccDefs.Where<T_AccDef>((Expression<Func<T_AccDef, bool>>)(t => t.ParAcc == txtMainAccNo)).OrderBy<T_AccDef, string>((Expression<Func<T_AccDef, string>>)(t => t.AccDef_No)).ToList<T_AccDef>();
                                str3 = list.Count != 0 ? string.Concat((object)(int.Parse(list[list.Count - 1].AccDef_No) + 1)) : txtMainAccNo + "001";
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID],MainSal,DepreciationPercent) VALUES (N'" + str3 + "', N'???????????? ?????????????? - ?????????? ??????????????????', N'Purchaes Tax', N'4011', 4, N'', 8, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1,0,0)");
                            }
                            catch
                            {
                                str3 = "***";
                            }
                        }
                    }
                    catch
                    {
                        str3 = "***";
                    }
                    str1 = "***";
                    string str4;
                    try
                    {
                        T_AccDef tAccDef2 = db.StockAccDef("1020001");
                        str4 = tAccDef2 == null || string.IsNullOrEmpty(tAccDef2.AccDef_No) ? "***" : "1020001";
                    }
                    catch
                    {
                        str4 = "***";
                    }
                    if (string.IsNullOrEmpty(str2))
                        str2 = "***";
                    if (string.IsNullOrEmpty(str3))
                        str3 = "***";
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_INVSETTING ADD  [TaxOptions] [varchar](100) NULL");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxOptions] = '110110' where InvID = 1");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxOptions] = '111010'  where InvID = 2");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxOptions] = '110110'  where InvID = 3");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxOptions] = '111010'  where InvID = 4");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxOptions] = '111010'  where InvID = 5");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxOptions] = '111010'  where InvID = 6");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxOptions] = '110110'  where InvID = 7");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxOptions] = '110110'  where InvID = 8");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxOptions] = '111010'  where InvID = 9");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxOptions] = '111010'  where InvID = 10");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxOptions] = '111010'  where InvID = 14");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxOptions] = '111010'  where InvID = 16");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxOptions] = '110110'  where InvID = 17");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxOptions] = '110110'  where InvID = 20");
                        db.ExecuteCommand("ALTER TABLE T_INVSETTING ADD  [autoTaxGaid] [bit] NULL");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [autoTaxGaid] = 0");
                        db.ExecuteCommand("ALTER TABLE T_INVSETTING ADD  [TaxDebit] [varchar](15) NULL");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxDebit] = '***'");
                        db.ExecuteCommand("ALTER TABLE T_INVSETTING ADD  [TaxCredit] [varchar](15) NULL");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxCredit] = '***'");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxDebit] = '" + str3 + "' where InvID = 2");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxCredit] = '" + str4 + "' where InvID = 2");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxDebit] = '" + str4 + "' where InvID = 4");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxCredit] = '" + str3 + "' where InvID = 4");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxDebit] = '" + str4 + "' where InvID = 1");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxCredit] = '" + str2 + "' where InvID = 1");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxDebit] = '" + str2 + "' where InvID = 3");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxCredit] = '" + str4 + "' where InvID = 3");
                        db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [DefSalesTax] [float] NULL");
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [DefSalesTax] = 0");
                        db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [DefPurchaesTax] [float] NULL");
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [DefPurchaesTax] = 0");
                    }
                    catch { }
                }
                catch
                {
                }
                try
                {
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_INVSETTING ADD  [autoDisGaid] [bit] NULL");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [autoDisGaid] = 0");
                        db.ExecuteCommand("ALTER TABLE T_INVSETTING ADD  [DisDebit] [varchar](15) NULL");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [DisDebit] = '***'");
                        db.ExecuteCommand("ALTER TABLE T_INVSETTING ADD  [DisCredit] [varchar](15) NULL");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [DisCredit] = '***'");
                        db.ExecuteCommand("ALTER TABLE T_Items ADD  [ItemDis] [float] NULL");
                        db.ExecuteCommand("Update [dbo].[T_Items] Set [ItemDis] = 0 ");
                        db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [InvValGaidDis] [float] NULL");
                        db.ExecuteCommand("Update [dbo].[T_INVHED] Set [InvValGaidDis] = 0 where InvValGaidDis is null");
                        db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [InvValGaidDislLoc] [float] NULL");
                        db.ExecuteCommand("Update [dbo].[T_INVHED] Set [InvValGaidDislLoc] = 0 where InvValGaidDislLoc is null");
                        db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [IsDisGaid] [bit] NULL");
                        db.ExecuteCommand("Update [dbo].[T_INVHED] Set [IsDisGaid] = 0 ");
                        db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [DisGaidID1] [float] NULL");
                        db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [IsDisUse1] [bit] NULL");
                        db.ExecuteCommand("Update [dbo].[T_INVHED] Set [IsDisUse1] = 0 ");
                    }
                    catch { }

                    string str2;
                    try
                    {
                        T_AccDef tAccDef = db.StockAccDef("3021003");
                        str2 = tAccDef == null || string.IsNullOrEmpty(tAccDef.AccDef_No) ? "***" : "3021003";
                    }
                    catch
                    {
                        str2 = "***";
                    }
                    string str3;
                    try
                    {
                        T_AccDef tAccDef = db.StockAccDef("3021001");
                        str3 = tAccDef == null || string.IsNullOrEmpty(tAccDef.AccDef_No) ? "***" : "3021001";
                    }
                    catch
                    {
                        str3 = "***";
                    }
                    string str4;
                    try
                    {
                        T_AccDef tAccDef = db.StockAccDef("3021002");
                        str4 = tAccDef == null || string.IsNullOrEmpty(tAccDef.AccDef_No) ? "***" : "3021002";
                    }
                    catch
                    {
                        str4 = "***";
                    }
                    string str5;
                    try
                    {
                        T_AccDef tAccDef = db.StockAccDef("3021004");
                        str5 = tAccDef == null || string.IsNullOrEmpty(tAccDef.AccDef_No) ? "***" : "3021004";
                    }
                    catch
                    {
                        str5 = "***";
                    }
                    string str6;
                    try
                    {
                        T_AccDef tAccDef = db.StockAccDef("3041001");
                        str6 = tAccDef == null || string.IsNullOrEmpty(tAccDef.AccDef_No) ? "***" : "3041001";
                    }
                    catch
                    {
                        str6 = "***";
                    }
                    string str7;
                    try
                    {
                        T_AccDef tAccDef = db.StockAccDef("3041003");
                        str7 = tAccDef == null || string.IsNullOrEmpty(tAccDef.AccDef_No) ? "***" : "3041003";
                    }
                    catch
                    {
                        str7 = "***";
                    }
                    string str8;
                    try
                    {
                        T_AccDef tAccDef = db.StockAccDef("3041004");
                        str8 = tAccDef == null || string.IsNullOrEmpty(tAccDef.AccDef_No) ? "***" : "3041004";
                    }
                    catch
                    {
                        str8 = "***";
                    }
                    string str9;
                    try
                    {
                        T_AccDef tAccDef = db.StockAccDef("3041002");
                        str9 = tAccDef == null || string.IsNullOrEmpty(tAccDef.AccDef_No) ? "***" : "3041002";
                    }
                    catch
                    {
                        str9 = "***";
                    }
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [DisDebit] = '" + str2 + "',[DisCredit] = '" + str3 + "' where InvID = 1");
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [DisDebit] = '" + str6 + "',[DisCredit] = '" + str7 + "' where InvID = 2");
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [DisDebit] = '" + str4 + "',[DisCredit] = '" + str5 + "' where InvID = 3");
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [DisDebit] = '" + str8 + "',[DisCredit] = '" + str9 + "' where InvID = 4");
                    try
                    {
                        if (File.Exists(Application.StartupPath + "\\\\Script\\\\SecriptInvitationCards.dll"))
                        {
                            db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [InvNamA] = '?????????? ??????????????' ,[InvNamE] = 'Issue invitations' where InvID = 8 ");
                            db.ExecuteCommand("Update [dbo].[T_INVHED] Set [ArbTaf] = '' where InvTyp = 8");
                            db.ExecuteCommand("Update [dbo].[T_INVHED] Set [EngTaf] = '' where InvTyp = 8");
                            db.ExecuteCommand("Update [dbo].[T_AccDef] Set [RessonStoped] = '' where Lev = 4 and AccCat = 4");
                        }
                    }
                    catch
                    {
                    }
                }
                catch
                {
                }
                try
                {
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [InvComm] [float] NULL");
                        db.ExecuteCommand("Update [dbo].[T_INVHED] Set [InvComm] = 0 where InvComm is null");
                        db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [InvCommLoc] [float] NULL");
                        db.ExecuteCommand("Update [dbo].[T_INVHED] Set [InvCommLoc] = 0 where InvCommLoc is null");
                        db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [IsCommGaid] [bit] NULL");
                        db.ExecuteCommand("Update [dbo].[T_INVHED] Set [IsCommGaid] = 0 ");
                        db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [CommGaidID] [float] NULL");
                        db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [IsCommUse] [bit] NULL");
                        db.ExecuteCommand("Update [dbo].[T_INVHED] Set [IsCommUse] = 0 ");
                    }
                    catch { }
                    str1 = "***";
                    string str2;
                    try
                    {
                        T_AccDef tAccDef = db.StockAccDef("4011012");
                        str2 = tAccDef == null || string.IsNullOrEmpty(tAccDef.AccDef_No) ? "***" : "4011012";
                    }
                    catch
                    {
                        str2 = "***";
                    }
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_INVSETTING ADD  [CommOptions] [varchar](100) NULL");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [CommOptions] = '10' where InvID = 1");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [CommOptions] = '10'  where InvID = 2");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [CommOptions] = '10'  where InvID = 3");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [CommOptions] = '10'  where InvID = 4");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [CommOptions] = '10'  where InvID = 5");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [CommOptions] = '10'  where InvID = 6");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [CommOptions] = '10'  where InvID = 7");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [CommOptions] = '10'  where InvID = 8");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [CommOptions] = '10'  where InvID = 9");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [CommOptions] = '10'  where InvID = 10");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [CommOptions] = '10'  where InvID = 14");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [CommOptions] = '10'  where InvID = 16");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [CommOptions] = '10'  where InvID = 17");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [CommOptions] = '10'  where InvID = 20");
                        db.ExecuteCommand("ALTER TABLE T_INVSETTING ADD  [autoCommGaid] [bit] NULL");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [autoCommGaid] = 0");
                        db.ExecuteCommand("ALTER TABLE T_INVSETTING ADD  [CommDebit] [varchar](15) NULL");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [CommDebit] = '***'");
                        db.ExecuteCommand("ALTER TABLE T_INVSETTING ADD  [CommCredit] [varchar](15) NULL");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [CommCredit] = '***'");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [CommDebit] = '***' where InvID = 1");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [CommCredit] = '" + str2 + "' where InvID = 1");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [CommDebit] = '" + str2 + "' where InvID = 2");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [CommCredit] = '***' where InvID = 2");

                    }
                    catch { }
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [TaxAcc] [varchar](30) NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [TaxAcc] = '' ");
                }
                catch
                {
                }
                try
                {
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [TaxNoteInv] [varchar](150) NULL");
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [TaxNoteInv] = 'Tax is 5%    |   ?????????????? 5 %' ");
                        db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [IsTaxLines] [bit] NULL");
                        db.ExecuteCommand("Update [dbo].[T_INVHED] Set [IsTaxLines] = 1 ");
                        db.ExecuteCommand("Update [dbo].[T_Items] Set [ItemComm] = 0 Where [ItemComm] is null");
                        db.ExecuteCommand("Update [dbo].[T_Items] Set [TaxSales] = 0 Where [TaxSales] is null");
                        db.ExecuteCommand("Update [dbo].[T_Items] Set [TaxPurchas] = 0 Where [TaxPurchas] is null");
                        db.ExecuteCommand("Update [dbo].[T_Items] Set [InvEnterStoped] = 0 Where [InvEnterStoped] is null");
                        db.ExecuteCommand("Update [dbo].[T_Items] Set [InvOutStoped] = 0 Where [InvOutStoped] is null");
                        db.ExecuteCommand("Update [dbo].[T_Items] Set [ItemDis] = 0 Where [ItemDis] is null");
                    }
                    catch { }

                    str1 = "";
                    string str2;
                    try
                    {
                        T_AccDef tAccDef = db.StockAccDef("4011026");
                        str2 = tAccDef == null || string.IsNullOrEmpty(tAccDef.AccDef_No) ? "" : "4011026";
                    }
                    catch
                    {
                        str2 = "";
                    }
                    if (!string.IsNullOrEmpty(str2))
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [TaxAcc] = '4011026' where [TaxAcc] is null or [TaxAcc] = ''");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [InvComm] = 0 where InvComm is null");
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [InvCommLoc] = 0 where InvCommLoc is null");
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [IsCommGaid] = 0 where IsCommGaid is null");
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [IsCommUse] = 0 where IsCommUse is null");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [IsCustomerDisplay] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [IsCustomerDisplay] = 0 ");
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [Port] [varchar](15) NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [Port] = 'COM4' ");
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [Fast] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [Fast] = 9600 ");
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [BitStop] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [BitStop] = 1 ");
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [BitData] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [BitData] = 8 ");
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [Parity] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [Parity] = 3 ");
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [CustomerHello] [varchar](100) NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [CustomerHello] = 'Pro.Soft-Solution' ");
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [DisplayTypeShow] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [DisplayTypeShow] = 0 ");
                }
                catch
                {
                }
                try
                {
                    if (File.Exists(Application.StartupPath + "\\\\Script\\\\SecriptSchool.dll"))
                    {
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [InvNamA] = '?????? ?????? ??????????????' ,[InvNamE] = 'Students Qutation' where InvID = 7 ");
                        db.ExecuteCommand("Update [dbo].[T_AccCat] Set [Arb_Des] = '????????????' ,[Eng_Des]= 'Students' where AccCat_ID = 4");
                    }
                }
                catch
                {
                }
                try
                {
                    if (File.Exists(Application.StartupPath + "\\\\Script\\\\SecriptTegnicalCollage.dll"))
                    {
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [InvNamA] = '?????????? ??????????' ,[InvNamE] = 'Issuance of Custody' where InvID = 17 ");
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [InvNamA] = '?????????? ??????????' ,[InvNamE] = 'Return Custody' where InvID = 20 ");
                        db.ExecuteCommand("Update [dbo].[T_AccCat] Set [Arb_Des] = '????????????' ,[Eng_Des]= 'Students' where AccCat_ID = 4");
                        try
                        {
                            db.ExecuteCommand("UPDATE [T_Mndob]SET [Mnd_Typ] = 1");
                        }
                        catch
                        {
                        }
                        try
                        {
                            db.ExecuteCommand("Update [dbo].[T_AccDef] Set [Arb_Des] = '????????????????' ,[Eng_Des] = 'Students' where AccDef_ID = 28 and AccCat = 4 and ParAcc = '102' and Lev = 3 ");
                        }
                        catch
                        {
                        }
                        try
                        {
                            db.ExecuteCommand("Update [dbo].[T_AccDef] Set [Arb_Des] = '????????' ,[Eng_Des] = 'Student' where AccDef_ID = 29 and AccCat = 4 and ParAcc = '1022' and Lev = 4 and  Arb_Des = '????????'");
                        }
                        catch
                        {
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    if (File.Exists(Application.StartupPath + "\\\\Script\\\\SecriptWaterPackages.dll"))
                    {
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [InvNamA] = '?????? ?????? ????????????????' ,[InvNamE] = 'Drivers Qutation' where InvID = 7 ");
                        db.ExecuteCommand("Update [dbo].[T_AccCat] Set [Arb_Des] = '????????????????' ,[Eng_Des]= 'Drivers' where AccCat_ID = 4");
                        try
                        {
                            db.ExecuteCommand("Update [dbo].[T_AccDef] Set [Arb_Des] = '????????????????' ,[Eng_Des] = 'Drivers' where AccDef_ID = 28 and AccCat = 4 and ParAcc = '102' and Lev = 3 ");
                        }
                        catch
                        {
                        }
                        try
                        {
                            db.ExecuteCommand("Update [dbo].[T_AccDef] Set [Arb_Des] = '????????' ,[Eng_Des] = 'Driver' where AccDef_ID = 29 and AccCat = 4 and ParAcc = '1022' and Lev = 4 and  Arb_Des = '????????'");
                        }
                        catch
                        {
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    if (File.Exists(Application.StartupPath + "\\\\Script\\\\SecriptStons.dll"))
                    {
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [InvNamA] = '?????? ??????????' ,[InvNamE] = 'Students Qutation' where InvID = 8 ");
                        db.ExecuteCommand("Update [dbo].[T_AccCat] Set [Arb_Des] = '?????? ??????????' ,[Eng_Des]= 'Students' where AccCat_ID = 5");
                    }
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_Items ADD  [SecriptCeramicCombo] [varchar](100) NULL");
                    db.ExecuteCommand("Update [dbo].[T_Items] Set [SecriptCeramicCombo] = '0' ");
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_Items ADD  [SecriptCeramic] [varchar](100) NULL");
                        db.ExecuteCommand("Update [dbo].[T_Items] Set [SecriptCeramic] = '' ");
                    }
                    catch
                    {
                    }
                    db.ExecuteCommand("Update [dbo].[T_Items] Set [SecriptCeramic] = '' where SecriptCeramic='0' or SecriptCeramic='1' or SecriptCeramic='2' or SecriptCeramic='3' or SecriptCeramic='4'");
                }
                catch
                {
                }
                try
                {
                    db.StockInvSetting(1, 1).TaxOptions.Substring(4, 1);
                }
                catch
                {
                    try
                    {
                        db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxOptions] = [TaxOptions] + '11'");
                    }
                    catch
                    {
                    }
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [IsTaxByTotal] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [IsTaxByTotal] = 0 ");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [AccCus] = '30' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [IsTaxByNet] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [IsTaxByNet] = 0 ");
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [TaxByNetValue] [float] NULL");
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [TaxByNetValue] = 0 ");
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [IsTaxLines] = 1 where IsTaxLines is null");
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [IsTaxByTotal] = 0 where IsTaxByTotal is null");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_Rom ADD  [Furnished] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_Rom] Set [Furnished] = 0 ");
                    db.ExecuteCommand("ALTER TABLE T_Rom ADD  [AreaDetail] [varchar](250) NULL");
                    db.ExecuteCommand("Update [dbo].[T_Rom] Set [AreaDetail] = '' ");
                    db.ExecuteCommand("ALTER TABLE T_Rom ADD  [RoomCount] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_Rom] Set [RoomCount] = 1 ");
                    db.ExecuteCommand("ALTER TABLE T_Rom ADD  [loungesCount] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_Rom] Set [loungesCount] = 0 ");
                    db.ExecuteCommand("ALTER TABLE T_Rom ADD  [kitchensCount] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_Rom] Set [kitchensCount] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [LineOfInvoices] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [LineOfInvoices] = 100 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("alter table T_Items alter column BarCod1 [varchar](250) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("alter table T_Items alter column BarCod2 [varchar](250) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("alter table T_Items alter column BarCod3 [varchar](250) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("alter table T_Items alter column BarCod4 [varchar](250) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("alter table T_Items alter column BarCod5 [varchar](250) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [IsActiveBalance] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [IsActiveBalance] = 0 ");
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [BalanceType] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [BalanceType] = 0 ");
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [BarcodFrom] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [BarcodFrom] = 1 ");
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [BarcodTo] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [BarcodTo] = 1 ");
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [WightFrom] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [WightFrom] = 1 ");
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [WightTo] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [WightTo] = 1 ");
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [PriceFrom] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [PriceFrom] = 1 ");
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [PriceTo] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [PriceTo] = 1 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [WightQ] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [WightQ] = 0 ");
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [PriceQ] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [PriceQ] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_Items ADD [IsBalance] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_Items] Set [IsBalance] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_Waiter ADD [Brn] [varchar](50) ");
                    db.ExecuteCommand("Update [dbo].[T_Waiter] Set [Brn] = 1 ");
                    db.ExecuteCommand("ALTER TABLE T_Waiter ADD [ProLng] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_Waiter] Set [ProLng] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("alter table T_INVDET alter column ItmUnt [varchar](100) NULL");
                    db.ExecuteCommand("alter table T_INVDET alter column ItmUntE [varchar](100) NULL");
                    db.ExecuteCommand("alter table T_SINVDET alter column SItmUnt [varchar](100) NULL");
                    db.ExecuteCommand("alter table T_SINVDET alter column SItmUntE [varchar](100) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVSETTING ADD  [TaxDebitCredit] [varchar](15) NULL");
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxDebitCredit] = '***'");
                    db.ExecuteCommand("ALTER TABLE T_INVSETTING ADD  [TaxCreditCredit] [varchar](15) NULL");
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxCreditCredit] = '***'");
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxDebitCredit] = '***' where InvID = 1");
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxDebitCredit] = [TaxDebit] where InvID = 2");
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxDebitCredit] = [TaxDebit] where InvID = 3");
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxDebitCredit] = '***' where InvID = 4");
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxCreditCredit] = [TaxCredit] where InvID = 1");
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxCreditCredit] = '***' where InvID = 2");
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxCreditCredit] = '***' where InvID = 3");
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxCreditCredit] = [TaxCredit] where InvID = 4");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("/****** Object:  Table [dbo].[T_Offer]    Script Date: 05/19/2018 04:32:57 ******/\r\n                                        SET ANSI_NULLS ON\r\n                                        SET QUOTED_IDENTIFIER ON\r\n                                        SET ANSI_PADDING ON\r\n                                        CREATE TABLE [dbo].[T_Offer](\r\n\t                                        [OfferHeadID] [int] IDENTITY(1,1) NOT NULL,\r\n\t                                        [OfferHeadNo] [varchar](10) NULL,\r\n\t                                        [OfferHeadName] [varchar](250) NULL,\r\n\t                                        [OfferHeadTyp] [int] NULL,\r\n\t                                        [StartDat] [varchar](10) NULL,\r\n\t                                        [EndDat] [varchar](10) NULL,\r\n\t                                        [OfferHeadCashCredit] [int] NULL,\r\n\t                                        [CustPri] [int] NULL,\r\n\t                                        [CusVenNo] [varchar](20) NULL,\r\n\t                                        [OfferSalsManNo] [varchar](3) NULL,\r\n\t                                        [OfferRemark] [varchar](max) NULL,\r\n                                         CONSTRAINT [PK_T_Offer] PRIMARY KEY CLUSTERED \r\n                                        (\r\n\t                                        [OfferHeadID] ASC\r\n                                        )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                        ) ON [PRIMARY]\r\n                                        SET ANSI_PADDING OFF");
                    db.ExecuteCommand("/****** Object:  Table [dbo].[T_OfferDet]    Script Date: 05/19/2018 04:37:20 ******/\r\n                                        SET ANSI_NULLS ON\r\n                                        SET QUOTED_IDENTIFIER ON\r\n                                        SET ANSI_PADDING ON\r\n                                        CREATE TABLE [dbo].[T_OfferDet](\r\n\t                                        [OfferDet_ID] [int] IDENTITY(1,1) NOT NULL,\r\n\t                                        [OfferDetNo] [varchar](10) NULL,\r\n\t                                        [OfferID] [int] NULL,\r\n\t                                        [OfferDetSer] [int] NULL,\r\n\t                                        [ItmNo] [varchar](50) NULL,\r\n\t                                        [ItmUnt] [int] NULL,\r\n\t                                        [Price] [float] NULL,\r\n\t                                        [DisVal] [float] NULL,\r\n\t                                        [UnitPriVal] [float] NULL,\r\n                                            [Qty] [float] NULL,\r\n                                         CONSTRAINT [PK_T_OfferDet] PRIMARY KEY CLUSTERED \r\n                                        (\r\n\t                                        [OfferDet_ID] ASC\r\n                                        )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                        ) ON [PRIMARY]\r\n\r\n                                        SET ANSI_PADDING OFF\r\n                                        ALTER TABLE [dbo].[T_OfferDet]  WITH CHECK ADD  CONSTRAINT [FK_T_OfferDet_T_Items] FOREIGN KEY([ItmNo])\r\n                                        REFERENCES [dbo].[T_Items] ([Itm_No])\r\n                                        ALTER TABLE [dbo].[T_OfferDet] CHECK CONSTRAINT [FK_T_OfferDet_T_Items]\r\n                                        ALTER TABLE [dbo].[T_OfferDet]  WITH CHECK ADD  CONSTRAINT [FK_T_OfferDet_T_Offer] FOREIGN KEY([OfferID])\r\n                                        REFERENCES [dbo].[T_Offer] ([OfferHeadID])\r\n                                        ALTER TABLE [dbo].[T_OfferDet] CHECK CONSTRAINT [FK_T_OfferDet_T_Offer]\r\n                                        ALTER TABLE [dbo].[T_OfferDet]  WITH CHECK ADD  CONSTRAINT [FK_T_OfferDet_T_Unit] FOREIGN KEY([ItmUnt])\r\n                                        REFERENCES [dbo].[T_Unit] ([Unit_ID])\r\n                                        ALTER TABLE [dbo].[T_OfferDet] CHECK CONSTRAINT [FK_T_OfferDet_T_Unit]");
                    db.ExecuteCommand("/****** Object:  Table [dbo].[T_OfferQFree]    Script Date: 05/23/2018 08:22:46 ******/\r\n                                        SET ANSI_NULLS ON\r\n                                        SET QUOTED_IDENTIFIER ON\r\n                                        SET ANSI_PADDING ON\r\n                                        CREATE TABLE [dbo].[T_OfferQFree](\r\n\t                                        [OfferQFree_ID] [int] IDENTITY(1,1) NOT NULL,\r\n\t                                        [OfferQFreeNo] [varchar](10) NULL,\r\n\t                                        [OfferQFreeID] [int] NULL,\r\n\t                                        [OfferQFreeSer] [int] NULL,\r\n\t                                        [OfferQFreeItmNo] [varchar](50) NULL,\r\n\t                                        [OfferQFreeItmUnt] [int] NULL,\r\n\t                                        [OfferQFreePrice] [float] NULL,\r\n\t                                        [OfferQFreeDisVal] [float] NULL,\r\n\t                                        [OfferQFreeUnitPriVal] [float] NULL,\r\n\t                                        [OfferIDQ] [int] NULL,\r\n                                            [OfferQFreeQty] [float] NULL,\r\n\t                                        [OfferQFreeStoreNo] [int] NULL,\r\n\t                                        [OfferQFreeItmTax] [float] NULL,\r\n\t                                        [OfferQFreeRunCod] [varchar](100) NULL,\r\n\t                                        [OfferQFreeDatExper] [varchar](11) NULL,\r\n                                         CONSTRAINT [PK_T_OfferQFree] PRIMARY KEY CLUSTERED \r\n                                        (\r\n\t                                        [OfferQFree_ID] ASC\r\n                                        )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                        ) ON [PRIMARY]\r\n\r\n                                        SET ANSI_PADDING OFF\r\n                                        ALTER TABLE [dbo].[T_OfferQFree]  WITH CHECK ADD  CONSTRAINT [FK_T_OfferQFree_T_Items] FOREIGN KEY([OfferQFreeItmNo])\r\n                                        REFERENCES [dbo].[T_Items] ([Itm_No])\r\n                                        ALTER TABLE [dbo].[T_OfferQFree] CHECK CONSTRAINT [FK_T_OfferQFree_T_Items]\r\n                                        ALTER TABLE [dbo].[T_OfferQFree]  WITH CHECK ADD  CONSTRAINT [FK_T_OfferQFree_T_Offer] FOREIGN KEY([OfferIDQ])\r\n                                        REFERENCES [dbo].[T_Offer] ([OfferHeadID])\r\n                                        ALTER TABLE [dbo].[T_OfferQFree] CHECK CONSTRAINT [FK_T_OfferQFree_T_Offer]\r\n                                        ALTER TABLE [dbo].[T_OfferQFree]  WITH CHECK ADD  CONSTRAINT [FK_T_OfferQFree_T_OfferDet] FOREIGN KEY([OfferQFreeID])\r\n                                        REFERENCES [dbo].[T_OfferDet] ([OfferDet_ID])\r\n                                        ALTER TABLE [dbo].[T_OfferQFree] CHECK CONSTRAINT [FK_T_OfferQFree_T_OfferDet]\r\n                                        ALTER TABLE [dbo].[T_OfferQFree]  WITH CHECK ADD  CONSTRAINT [FK_T_OfferQFree_T_Unit] FOREIGN KEY([OfferQFreeItmUnt])\r\n                                        REFERENCES [dbo].[T_Unit] ([Unit_ID])\r\n                                        ALTER TABLE [dbo].[T_OfferQFree] CHECK CONSTRAINT [FK_T_OfferQFree_T_Unit]");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVDET ADD  [OfferTyp] [int] NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [PointOfRyal] [float] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [PointOfRyal] = 0.01 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [ItemTyp1] [varchar](100)");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [ItemTyp1] = '????????' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [ItemTyp2] [varchar](100)");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [ItemTyp2] = '???????? ????????' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [ItemTyp3] [varchar](100)");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [ItemTyp3] = '????????' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [ItemTyp1E] [varchar](100)");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [ItemTyp1E] = 'Commodity' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [ItemTyp2E] [varchar](100)");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [ItemTyp2E] = 'Raw materials' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [ItemTyp3E] [varchar](100)");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [ItemTyp3E] = 'Service' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_CATEGORY ADD [TotalPurchaes] [float] NULL");
                    db.ExecuteCommand("Update [dbo].[T_CATEGORY] Set [TotalPurchaes] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_CATEGORY ADD [TotalPoint] [float] NULL");
                    db.ExecuteCommand("Update [dbo].[T_CATEGORY] Set [TotalPoint] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_Items ADD [IsPoints] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_Items] Set [IsPoints] = 1 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [DesPointsValue] [float] NULL");
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [DesPointsValue] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [DesPointsValueLocCur] [float] NULL");
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [DesPointsValueLocCur] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD  [PointsCount] [float] NULL");
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [PointsCount] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD [IsPoints] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [IsPoints] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_tel ADD  [GadeNo] [float] NULL");
                    db.ExecuteCommand("ALTER TABLE T_tel ADD  [GadeId] [float] NULL");
                    db.ExecuteCommand("ALTER TABLE T_tel ADD [IsGaid] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_tel] Set [IsGaid] = 0 ");
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [InvNamA] = '?????????? ??????????????' ,[InvNamE] = 'Guests Services' where InvID = 15 ");
                    db.ExecuteCommand("Update [dbo].[T_AccDef] Set [Mobile] = '' ,[DateAppointment] = '',[ID_Date] = '',[ID_DateEnd] = '',[Passport_Date] = '',[Insurance_Date] = '',[Passport_DateEnd] = '',[Insurance_DateEnd] = '',[ID_No] = '',[Passport_No] = '',[Insurance_No] = '',[ID_From] = '',[Passport_From] = '',[Insurance_From] = '',[MainSal] = 0,[BankComm] = 0,[TaxNo] = '',[TotPoints] = 0,[DepreciationPercent] = 0,[ProofAcc] = '',[RelayAcc] = '' where [Mobile]  is null and [DateAppointment]  is null and [ID_Date]  is null and [ID_DateEnd]  is null and [Passport_Date]  is null and [Insurance_Date]  is null and [Passport_DateEnd]  is null and [Insurance_DateEnd]  is null and [ID_No]  is null and [Passport_No]  is null and [Insurance_No]  is null and [ID_From]  is null and [Passport_From]  is null and [Insurance_From]  is null and [BankComm]  is null and [TaxNo]  is null and [TotPoints]  is null and [ProofAcc]  is null and [RelayAcc] is null ");
                    db.ExecuteCommand("Update [dbo].[T_sertyp] Set [accno] = '3011002' where accno is null ");
                    db.ExecuteCommand("Update [dbo].[T_telmn] Set [accno] = '3011002' where accno is null ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [AlarmDueoBefore] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [AlarmDueoBefore] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [EmpSeting] [varchar](100) NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [EmpSeting] = '0' ");
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [InvNamA] = '???????? ????????????????' ,[InvNamE] = 'HR',[InvSetting] = '1' where InvID = 16 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [SyncPath] [varchar](max) NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [SyncPath] = '' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("alter table T_InvDetNote alter column Arb_Des [varchar](max) NULL");
                    db.ExecuteCommand("alter table T_InvDetNote alter column Eng_Des [varchar](max) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_Mndob ADD  [MndFlied1] varchar(250) NULL");
                    db.ExecuteCommand("Update [dbo].[T_Mndob] Set [MndFlied1] = '' ");
                    db.ExecuteCommand("ALTER TABLE T_Mndob ADD  [MndFlied2] varchar(250) NULL");
                    db.ExecuteCommand("Update [dbo].[T_Mndob] Set [MndFlied2] = '' ");
                    db.ExecuteCommand("ALTER TABLE T_Mndob ADD  [MndFlied3] varchar(250) NULL");
                    db.ExecuteCommand("Update [dbo].[T_Mndob] Set [MndFlied3] = '' ");
                    db.ExecuteCommand("ALTER TABLE T_Mndob ADD  [MndFlied4] varchar(250) NULL");
                    db.ExecuteCommand("Update [dbo].[T_Mndob] Set [MndFlied4] = '' ");
                    db.ExecuteCommand("ALTER TABLE T_CstTbl ADD  [CstFlied1] varchar(250) NULL");
                    db.ExecuteCommand("Update [dbo].[T_CstTbl] Set [CstFlied1] = '' ");
                    db.ExecuteCommand("ALTER TABLE T_CstTbl ADD  [CstFlied2] varchar(250) NULL");
                    db.ExecuteCommand("Update [dbo].[T_CstTbl] Set [CstFlied2] = '' ");
                    db.ExecuteCommand("ALTER TABLE T_CstTbl ADD  [CstFlied3] varchar(250) NULL");
                    db.ExecuteCommand("Update [dbo].[T_CstTbl] Set [CstFlied3] = '' ");
                    db.ExecuteCommand("ALTER TABLE T_CstTbl ADD  [CstFlied4] varchar(250) NULL");
                    db.ExecuteCommand("Update [dbo].[T_CstTbl] Set [CstFlied4] = '' ");
                    db.ExecuteCommand("ALTER TABLE T_CstTbl ADD  [CstFlied5] varchar(250) NULL");
                    db.ExecuteCommand("Update [dbo].[T_CstTbl] Set [CstFlied5] = '' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_CATEGORY ADD [CAT_Symbol] [varchar](100) NULL");
                    db.ExecuteCommand("Update [dbo].[T_CATEGORY] Set [CAT_Symbol] = '' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("alter table T_INVSETTING alter column invGdADesc [varchar](max) NULL");
                    db.ExecuteCommand("alter table T_INVSETTING alter column invGdEDesc [varchar](max) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("alter table T_Items alter column ItmLoc [varchar](40) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD [tailor1] [varchar](100) NULL");
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD [tailor2] [varchar](100) NULL");
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD [tailor3] [varchar](100) NULL");
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD [tailor4] [varchar](100) NULL");
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD [tailor5] [varchar](100) NULL");
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD [tailor6] [varchar](100) NULL");
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD [tailor7] [varchar](100) NULL");
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD [tailor8] [varchar](100) NULL");
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD [tailor9] [varchar](100) NULL");
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD [tailor10] [varchar](100) NULL");
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD [tailor11] [varchar](100) NULL");
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD [tailor12] [varchar](100) NULL");
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD [tailor13] [varchar](100) NULL");
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD [tailor14] [varchar](100) NULL");
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD [tailor15] [varchar](100) NULL");
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD [tailor16] [varchar](100) NULL");
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD [tailor17] [varchar](100) NULL");
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD [tailor18] [varchar](100) NULL");
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD [tailor19] [varchar](100) NULL");
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD [tailor20] [varchar](100) NULL");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_INVHED ADD [InvImg] [varbinary](max) NULL");
                }
                catch
                {
                }
                try
                {
                    if (db.T_INVSETTINGs.Select<T_INVSETTING, T_INVSETTING>((Expression<Func<T_INVSETTING, T_INVSETTING>>)(t => t)).ToList<T_INVSETTING>().Count <= 28)
                    {
                        List<T_CATEGORY> list = db.FillCat_2("").ToList<T_CATEGORY>();
                        for (int index = 0; index < list.Count; ++index)
                            db.ExecuteCommand("SET IDENTITY_INSERT [dbo].[T_INVSETTING] ON \r\n                                            INSERT [dbo].[T_INVSETTING] ([InvSet_ID],[InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines],[CatID],[PrintCat]) VALUES (" + (object)(100 + index) + "," + (object)(100 + index) + ", N'" + list[index].Arb_Des + "', N'" + list[index].Eng_Des + "', N'212', N'1         ', N'????????                          ', N'??????       ', NULL, NULL, NULL, N'Cash      ', N'Credit    ', NULL, NULL, NULL, -2147483633, 12640511, 0, N'????????????              ', NULL, NULL, NULL, NULL, N'Customer            ', NULL, NULL, NULL, NULL, N'3021001        ', N'1020001        ', NULL, NULL, NULL, NULL, NULL, N'3021005        ', N'***', N'3021005', N'1022001', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, N'Microsoft XPS Document Writer', N'110 ', N'1011 ', 1, 1,1," + (object)list[index].CAT_ID + ",0)\r\n                                            SET IDENTITY_INSERT [dbo].[T_INVSETTING] OFF");
                    }
                }
                catch
                {
                }
                try
                {
                    List<T_CATEGORY> list = db.ExecuteQuery<T_CATEGORY>("SELECT T_CATEGORY.*\r\n                                                                   FROM T_CATEGORY\r\n                                                                   WHERE CAT_ID NOT IN (SELECT T_INVSETTING.CatID from T_INVSETTING where CatID != '' )").ToList<T_CATEGORY>();
                    for (int index = 0; index < list.Count; ++index)
                    {
                        int maxInvsetting = db.MaxINVSETTING;
                        db.ExecuteCommand("INSERT [dbo].[T_INVSETTING] ([InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines],[CatID],[PrintCat]) VALUES (" + (object)maxInvsetting + ", N'" + list[index].Arb_Des + "', N'" + list[index].Eng_Des + "', N'212', N'1         ', N'????????                          ', N'??????       ', NULL, NULL, NULL, N'Cash      ', N'Credit    ', NULL, NULL, NULL, -2147483633, 12640511, 0, N'????????????              ', NULL, NULL, NULL, NULL, N'Customer            ', NULL, NULL, NULL, NULL, N'3021001        ', N'1020001        ', NULL, NULL, NULL, NULL, NULL, N'3021005        ', N'***', N'3021005', N'1022001', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, N'Microsoft XPS Document Writer', N'110 ', N'1011 ', 1, 1,1," + (object)list[index].CAT_ID + ",0)");
                    }
                }
                catch
                {
                }
                try
                {
                    try
                    {
                        db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [vFiledA] [varchar](100)");
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [vFiledA] = '' ");
                        db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [vFiledB] [varchar](100)");
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [vFiledB] = '' ");
                        db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [vFiledC] [varchar](100)");
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [vFiledC] = '' ");
                        db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [vFiledInt] [int] NULL");
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [vFiledInt] = 0 ");
                        db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [vFiledBool] [bit] NULL");
                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [vFiledBool] = 0 ");

                    }
                    catch { }
                    try
                    {
                        T_AccDef tAccDef1 = db.StockAccDef("4011026");
                        if (tAccDef1 != null && !string.IsNullOrEmpty(tAccDef1.AccDef_No))
                        {
                            db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxDebit] = (select AccDebit0 from T_INVSETTING where InvID = 1),[TaxCredit]= '4011026',[TaxDebitCredit] = '***',[TaxCreditCredit]='4011026' where InvID = 1");
                            db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxDebit] = '4011026',[TaxCredit]=(select AccCredit0 from T_INVSETTING where InvID = 3),[TaxDebitCredit] = '4011026',[TaxCreditCredit]='***' where InvID = 3");
                        }
                        T_AccDef tAccDef2 = db.StockAccDef("4011027");
                        if (tAccDef2 != null && !string.IsNullOrEmpty(tAccDef2.AccDef_No))
                        {
                            db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxDebit] = '4011027',[TaxCredit]=(select AccCredit0 from T_INVSETTING where InvID = 2),[TaxDebitCredit] = '4011027',[TaxCreditCredit]='***' where InvID = 2");
                            db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [TaxDebit] = (select AccDebit0 from T_INVSETTING where InvID = 4),[TaxCredit]='4011027',[TaxDebitCredit] = '***',[TaxCreditCredit]= '4011027' where InvID = 4");
                        }
                    }
                    catch
                    {
                    }
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_Items ADD  [vSize1] [varchar](100) NULL");
                    db.ExecuteCommand("Update [dbo].[T_Items] Set [vSize1] = '' where vSize1 = '' or vSize1 is null");
                    db.ExecuteCommand("ALTER TABLE T_Items ADD  [vSize2] [varchar](100) NULL");
                    db.ExecuteCommand("Update [dbo].[T_Items] Set [vSize2] = '' where vSize2 = '' or vSize2 is null");
                    db.ExecuteCommand("ALTER TABLE T_Items ADD  [vSize3] [varchar](100) NULL");
                    db.ExecuteCommand("Update [dbo].[T_Items] Set [vSize3] = '' where vSize3 = '' or vSize3 is null");
                    db.ExecuteCommand("ALTER TABLE T_Items ADD  [vSize4] [varchar](100) NULL");
                    db.ExecuteCommand("Update [dbo].[T_Items] Set [vSize4] = '' where vSize4 = '' or vSize4 is null");
                    db.ExecuteCommand("ALTER TABLE T_Items ADD  [vSize5] [varchar](100) NULL");
                    db.ExecuteCommand("Update [dbo].[T_Items] Set [vSize5] = '' where vSize5 = '' or vSize5 is null");
                    db.ExecuteCommand("ALTER TABLE T_Items ADD  [vSize6] [varchar](100) NULL");
                    db.ExecuteCommand("Update [dbo].[T_Items] Set [vSize6] = '' where vSize6 = '' or vSize6 is null");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_Vacation ADD [EmpCover] [varchar](40)");
                    db.ExecuteCommand("ALTER TABLE [dbo].[T_Vacation]  WITH CHECK ADD  CONSTRAINT [FK_T_Vacation_T_Emp1] FOREIGN KEY([EmpCover])\r\n                                        REFERENCES [dbo].[T_Emp] ([Emp_ID])\r\n                                        ALTER TABLE [dbo].[T_Vacation] CHECK CONSTRAINT [FK_T_Vacation_T_Emp1]");
                }
                catch
                {
                }
                try
                {
                    List<T_INVSETTING> list1 = db.T_INVSETTINGs.OrderBy<T_INVSETTING, int>((Expression<Func<T_INVSETTING, int>>)(t => t.InvID)).Where<T_INVSETTING>((Expression<Func<T_INVSETTING, bool>>)(t => t.CatID.HasValue)).ToList<T_INVSETTING>();
                    if (list1.Count > 0)
                    {
                        if (list1.FirstOrDefault<T_INVSETTING>().InvID < 100)
                        {
                            db.ExecuteCommand("Delete from T_INVSETTING where CatID > 0 and CatID != ''");
                            if (db.T_INVSETTINGs.OrderBy<T_INVSETTING, int>((Expression<Func<T_INVSETTING, int>>)(t => t.InvID)).Where<T_INVSETTING>((Expression<Func<T_INVSETTING, bool>>)(t => t.InvID == 27 && !t.CatID.HasValue)).ToList<T_INVSETTING>().Count <= 0)
                            {
                                try
                                {
                                    try
                                    {
                                        try
                                        {
                                            db.ExecuteCommand("ALTER TABLE T_per ADD [romnoNew] [int] NULL");
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            db.ExecuteCommand("ALTER TABLE T_Reserv ADD [romnoNew] [int] NULL");
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            db.ExecuteCommand("ALTER TABLE T_per1 ADD [romnoNew] [int] NULL");
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            db.ExecuteCommand("ALTER TABLE T_tel ADD [romnoNew] [int] NULL");
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            db.ExecuteCommand("ALTER TABLE T_tran ADD [romnoNew] [int] NULL");
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            db.ExecuteCommand("ALTER TABLE T_romtrn ADD [romnoNew] [int] NULL");
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            db.ExecuteCommand("ALTER TABLE T_romtrn ADD [romnoNew1] [int] NULL");
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            db.ExecuteCommand("ALTER TABLE T_romtrn ADD [romnoNew2] [int] NULL");
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            db.ExecuteCommand("ALTER TABLE dbo.T_per DROP CONSTRAINT [FK_T_per_T_Rom]");
                                            db.ExecuteCommand("ALTER TABLE dbo.T_romtrn DROP CONSTRAINT [FK_T_romtrn_T_Rom]");
                                            db.ExecuteCommand("ALTER TABLE dbo.T_romtrn DROP CONSTRAINT [FK_T_romtrn_T_Rom1]");
                                            db.ExecuteCommand("ALTER TABLE dbo.T_per1 DROP CONSTRAINT [FK_T_per1_T_Rom]");
                                            db.ExecuteCommand("ALTER TABLE dbo.T_Reserv DROP CONSTRAINT [FK_T_Reserv_T_Rom]");
                                            db.ExecuteCommand("ALTER TABLE dbo.T_tel DROP CONSTRAINT [FK_T_tel_T_Rom]");
                                            db.ExecuteCommand("ALTER TABLE dbo.T_tran DROP CONSTRAINT [FK_T_tran_T_Rom]");
                                        }
                                        catch
                                        {
                                        }
                                        db.ExecuteCommand("/****** Object:  Table [dbo].[T_Snd]    Script Date: 09/03/2017 00:59:10 ******/\r\n                                    SET ANSI_NULLS ON\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    SET ANSI_PADDING ON\r\n                                    CREATE TABLE [dbo].[T_Snd](\r\n\t                                    [gd_ID] [int] IDENTITY(1,1) NOT NULL,\r\n\t                                    [fNo] [int] NOT NULL,\r\n\t                                    [SndName] [varchar](100) NULL,\r\n\t                                    [romno] [int] NULL,\r\n\t                                    [price] [float] NULL,\r\n\t                                    [det] [varchar](250) NULL,\r\n\t                                    [typ] [int] NULL,\r\n\t                                    [Usr] [varchar](30) NULL,\r\n\t                                    [gdUser] [varchar](3) NULL,\r\n\t                                    [gdUserNam] [varchar](50) NULL,\r\n\t                                    [perno] [int] NULL,\r\n\t                                    [dt] [varchar](10) NULL,\r\n\t                                    [curr] [int] NULL,\r\n\t                                    [tm] [varchar](11) NULL,\r\n\t                                    [ch] [int] NULL,\r\n\t                                    [curcost] [float] NULL,\r\n\t                                    [sala] [int] NULL,\r\n\t                                    [typN] [int] NULL,\r\n\t                                    [ShekNo] [varchar](50) NULL,\r\n\t                                    [ShekDate] [varchar](20) NULL,\r\n\t                                    [ShekBank] [varchar](50) NULL,\r\n\t                                    [IfTrans] [int] NULL,\r\n\t                                    [RStat] [int] NULL,\r\n\t                                    [GadeNo] [float] NULL,\r\n\t                                    [GadeId] [float] NULL,\r\n                                     CONSTRAINT [PK_T_Snd] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [gd_ID] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    SET ANSI_PADDING OFF\r\n                                    ALTER TABLE [dbo].[T_Snd]  WITH CHECK ADD  CONSTRAINT [FK_T_Snd_T_Curency] FOREIGN KEY([curr])\r\n                                    REFERENCES [dbo].[T_Curency] ([Curency_ID])\r\n                                    ALTER TABLE [dbo].[T_Snd] CHECK CONSTRAINT [FK_T_Snd_T_Curency]\r\n                                    ALTER TABLE [dbo].[T_Snd]  WITH CHECK ADD  CONSTRAINT [FK_T_Snd_T_per] FOREIGN KEY([perno])\r\n                                    REFERENCES [dbo].[T_per] ([perno])\r\n                                    ALTER TABLE [dbo].[T_Snd] CHECK CONSTRAINT [FK_T_Snd_T_per]");
                                        db.ExecuteCommand("        SET IDENTITY_INSERT [dbo].[T_INVSETTING] ON\r\n                                            INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines],[defSizePaper],[Orientation],[CatID],[PrintCat]) VALUES (27, 27, N'?????? ?????? ????????', N'Catch Receipt Guest', N'1', N'1         ', N'?????????????? ???? ????????????             ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 16706518, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 10, N'', N'111 ', NULL, 1, 1,1,N'',1,NULL,0)\r\n                                            INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines],[defSizePaper],[Orientation],[CatID],[PrintCat]) VALUES (28, 28, N'?????? ?????? ????????', N'receipt Guest', N'1', N'1         ', N'???????????? ???? ????????????              ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 16706518, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 10, N'', N'111 ', NULL, 1, 1,1,N'',1,NULL,0)\r\n                                            SET IDENTITY_INSERT [dbo].[T_INVSETTING] OFF");
                                        try
                                        {
                                            T_AccDef tAccDef1 = db.StockAccDef("3011");
                                            if (tAccDef1 != null && !string.IsNullOrEmpty(tAccDef1.AccDef_No))
                                            {
                                                T_AccDef tAccDef2 = db.StockAccDef("3011002");
                                                if (tAccDef2 == null || string.IsNullOrEmpty(tAccDef2.AccDef_No))
                                                {
                                                    try
                                                    {
                                                        db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID]) VALUES (N'3011002', N'?????????????? ????????????', N'Hotel Income', N'3011', 4, N'1', 7, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)");
                                                        try
                                                        {
                                                            db.ExecuteCommand("Update [dbo].[T_AccDef] Set [DateAppointment] = '' where  AccDef_No = '3011002' ");
                                                            db.ExecuteCommand("Update [dbo].[T_AccDef] Set [ID_Date] = '' where  AccDef_No = '3011002'");
                                                            db.ExecuteCommand("Update [dbo].[T_AccDef] Set [ID_DateEnd] = '' where  AccDef_No = '3011002'");
                                                            db.ExecuteCommand("Update [dbo].[T_AccDef] Set [Passport_DateEnd] = '' where  AccDef_No = '3011002'");
                                                            db.ExecuteCommand("Update [dbo].[T_AccDef] Set [Insurance_DateEnd] = '' where  AccDef_No = '3011002'");
                                                            db.ExecuteCommand("Update [dbo].[T_AccDef] Set [Passport_DateEnd] = '' where  AccDef_No = '3011002'");
                                                            db.ExecuteCommand("Update [dbo].[T_AccDef] Set [Insurance_DateEnd] = '' where  AccDef_No = '3011002'");
                                                            db.ExecuteCommand("Update [dbo].[T_AccDef] Set [ID_No] = '' where  AccDef_No = '3011002'");
                                                            db.ExecuteCommand("Update [dbo].[T_AccDef] Set [Passport_No] = '' where  AccDef_No = '3011002'");
                                                            db.ExecuteCommand("Update [dbo].[T_AccDef] Set [Insurance_No] = '' where  AccDef_No = '3011002'");
                                                            db.ExecuteCommand("Update [dbo].[T_AccDef] Set [ID_From] = '' where  AccDef_No = '3011002'");
                                                            db.ExecuteCommand("Update [dbo].[T_AccDef] Set [Passport_From] = '' where  AccDef_No = '3011002'");
                                                            db.ExecuteCommand("Update [dbo].[T_AccDef] Set [Insurance_From] = '' where  AccDef_No = '3011002'");
                                                            db.ExecuteCommand("Update [dbo].[T_AccDef] Set [MainSal] = 0 ");
                                                            db.ExecuteCommand("Update [dbo].[T_AccDef] Set [BankComm] = 0.008 where  AccDef_No = '3011002' ");
                                                            db.ExecuteCommand("Update [dbo].[T_AccDef] Set [TaxNo] = '' where  AccDef_No = '3011002'");
                                                            db.ExecuteCommand("Update [dbo].[T_AccDef] Set [TotPoints] = 0 where  AccDef_No = '3011002'");
                                                            db.ExecuteCommand("Update [dbo].[T_AccDef] Set [DepreciationPercent] = 0 where DepreciationPercent is null");
                                                            db.ExecuteCommand("Update [dbo].[T_AccDef] Set [ProofAcc] = ''  where ProofAcc is null");
                                                            db.ExecuteCommand("Update [dbo].[T_AccDef] Set [RelayAcc] = '' where RelayAcc is null");
                                                            db.ExecuteCommand("Update [dbo].[T_AccDef] Set [StopedState] = 0 where [StopedState] is null");
                                                        }
                                                        catch
                                                        {
                                                        }
                                                        db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [GuestBoxAcc] = '3011002' ");
                                                    }
                                                    catch
                                                    {
                                                    }
                                                }
                                            }
                                        }
                                        catch
                                        {
                                        }
                                        db.ExecuteCommand("alter table T_Reserv alter column Usr [varchar](100) NULL");
                                        db.ExecuteCommand("alter table T_per alter column jobpls [varchar](150) NULL");
                                    }
                                    catch
                                    {
                                    }
                                    try
                                    {
                                        db.ExecuteCommand("UPDATE [dbo].[T_Rom]  SET [aline] = 1");
                                        db.ExecuteCommand("SET IDENTITY_INSERT [dbo].[T_Loc] ON\r\n                                    INSERT [dbo].[T_Loc] ([Loc_ID], [Loc_No], [Arb_Des], [Eng_Des], [CompanyID]) VALUES (1, N'1', N'??????????', N'South', 1)\r\n                                    INSERT [dbo].[T_Loc] ([Loc_ID], [Loc_No], [Arb_Des], [Eng_Des], [CompanyID]) VALUES (2, N'2', N'??????????', N'North', 1)\r\n                                    INSERT [dbo].[T_Loc] ([Loc_ID], [Loc_No], [Arb_Des], [Eng_Des], [CompanyID]) VALUES (3, N'3', N'????????', N'East', 1)\r\n                                    INSERT [dbo].[T_Loc] ([Loc_ID], [Loc_No], [Arb_Des], [Eng_Des], [CompanyID]) VALUES (4, N'4', N'????????', N'West', 1)\r\n                                    SET IDENTITY_INSERT [dbo].[T_Loc] OFF");
                                        db.ExecuteCommand("ALTER TABLE [dbo].[T_Rom]  WITH CHECK ADD  CONSTRAINT [FK_T_Rom_T_Loc] FOREIGN KEY([aline])\r\n                                    REFERENCES [dbo].[T_Loc] ([Loc_ID])\r\n                                    ALTER TABLE [dbo].[T_Rom] CHECK CONSTRAINT [FK_T_Rom_T_Loc]");
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
                        List<T_CATEGORY> list2 = db.FillCat_2("").ToList<T_CATEGORY>();
                        for (int index = 0; index < list2.Count; ++index)
                            db.ExecuteCommand("SET IDENTITY_INSERT [dbo].[T_INVSETTING] ON \r\n                                            INSERT [dbo].[T_INVSETTING] ([InvSet_ID],[InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines],[CatID],[PrintCat]) VALUES (" + (object)(100 + index) + "," + (object)(100 + index) + ", N'" + list2[index].Arb_Des + "', N'" + list2[index].Eng_Des + "', N'212', N'1         ', N'????????                          ', N'??????       ', NULL, NULL, NULL, N'Cash      ', N'Credit    ', NULL, NULL, NULL, -2147483633, 12640511, 0, N'????????????              ', NULL, NULL, NULL, NULL, N'Customer            ', NULL, NULL, NULL, NULL, N'3021001        ', N'1020001        ', NULL, NULL, NULL, NULL, NULL, N'3021005        ', N'***', N'3021005', N'1022001', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, N'Microsoft XPS Document Writer', N'110 ', N'1011 ', 1, 1,1," + (object)list2[index].CAT_ID + ",0)\r\n                                            SET IDENTITY_INSERT [dbo].[T_INVSETTING] OFF");
                    }
                    List<T_CATEGORY> list3 = db.ExecuteQuery<T_CATEGORY>("SELECT T_CATEGORY.*\r\n                                                                   FROM T_CATEGORY\r\n                                                                   WHERE CAT_ID NOT IN (SELECT T_INVSETTING.CatID from T_INVSETTING where CatID != '' )").ToList<T_CATEGORY>();
                    for (int index = 0; index < list3.Count; ++index)
                    {
                        int maxInvsetting = db.MaxINVSETTING;
                        db.ExecuteCommand("INSERT [dbo].[T_INVSETTING] ([InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines],[CatID],[PrintCat]) VALUES (" + (object)maxInvsetting + ", N'" + list3[index].Arb_Des + "', N'" + list3[index].Eng_Des + "', N'212', N'1         ', N'????????                          ', N'??????       ', NULL, NULL, NULL, N'Cash      ', N'Credit    ', NULL, NULL, NULL, -2147483633, 12640511, 0, N'????????????              ', NULL, NULL, NULL, NULL, N'Customer            ', NULL, NULL, NULL, NULL, N'3021001        ', N'1020001        ', NULL, NULL, NULL, NULL, NULL, N'3021005        ', N'***', N'3021005', N'1022001', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, N'Microsoft XPS Document Writer', N'110 ', N'1011 ', 1, 1,1," + (object)list3[index].CAT_ID + ",0)");
                    }
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_Vacation ADD  [AdminLock] [bit] NULL");
                    db.ExecuteCommand("Update [dbo].[T_Vacation] Set [AdminLock] = 1 where AdminLock is null");
                    db.ExecuteCommand("    ALTER FUNCTION [dbo].[GetVacUsed](@EmpID varchar(40))\r\n                                            RETURNS INT\r\n                                            WITH EXECUTE AS CALLER\r\n                                            AS\r\n                                            begin\r\n\t                                            DECLARE @valueIn int;\r\n\t                                            DECLARE @value int;\r\n\t\t                                            set @valueIn = ISNull((SELECT sum(VacCountDay) from T_Vacation join T_VacTyp on T_Vacation.VacTyp = T_VacTyp.VacT_No Where T_Vacation.EmpID=@EmpID AND T_VacTyp.Dis_VacT = 1 AND T_Vacation.AdminLock = 1),'0')\r\n\r\n\t                                            set @value = @valueIn ;\r\n\t                                            return (@value);\r\n                                            end");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_INVHED] Set [tailor20] = '0' where tailor20 is null or tailor20 = '' ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_OfferDet ADD [QtyTo] [float] NULL ");
                    db.ExecuteCommand("Update [dbo].[T_OfferDet] Set [QtyTo] = 0 ");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("\r\n                                    SET ANSI_NULLS ON\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    SET ANSI_PADDING ON\r\n                                    CREATE TABLE [dbo].[T_EqarTyp](\r\n\t                                    [EqarTyp_ID] [varchar](40) NOT NULL,\r\n\t                                    [EqarTyp_No] [int] NOT NULL,\r\n\t                                    [NameA] [varchar](30) NULL,\r\n\t                                    [NameE] [varchar](30) NULL,\r\n\t                                    [Note] [varchar](50) NULL,\r\n                                     CONSTRAINT [PK_T_EqarTyp] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [EqarTyp_No] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    SET ANSI_PADDING OFF\r\n                                    INSERT [dbo].[T_EqarTyp] ([EqarTyp_ID], [EqarTyp_No], [NameA], [NameE], [Note]) VALUES (N'404d5799-d96c-4461-bd43-4d88ddea630e', 1, N'????????', N'residential', N'----------')\r\n                                    INSERT [dbo].[T_EqarTyp] ([EqarTyp_ID], [EqarTyp_No], [NameA], [NameE], [Note]) VALUES (N'326ec889-2aee-4d38-b22e-f152a5796c6a', 2, N'??????????', N'commercial', N'--------')\r\n                                    INSERT [dbo].[T_EqarTyp] ([EqarTyp_ID], [EqarTyp_No], [NameA], [NameE], [Note]) VALUES (N'8a56f18d-cadd-4541-9e5a-63d1d06b3a93', 3, N'???????? ??????????', N'residential commercial', N'--------')");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("\r\n                                                SET ANSI_NULLS ON\r\n                                                SET QUOTED_IDENTIFIER ON\r\n                                                SET ANSI_PADDING ON\r\n                                                CREATE TABLE [dbo].[T_EqarNatural](\r\n\t                                                [EqarNatural_ID] [varchar](40) NOT NULL,\r\n\t                                                [EqarNatural_No] [int] NOT NULL,\r\n\t                                                [NameA] [varchar](30) NULL,\r\n\t                                                [NameE] [varchar](30) NULL,\r\n\t                                                [Note] [varchar](50) NULL,\r\n                                                 CONSTRAINT [PK_T_EqarNatural] PRIMARY KEY CLUSTERED \r\n                                                (\r\n\t                                                [EqarNatural_No] ASC\r\n                                                )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                                ) ON [PRIMARY]\r\n                                                SET ANSI_PADDING OFF   \r\n                                                INSERT [dbo].[T_EqarNatural] ([EqarNatural_ID], [EqarNatural_No], [NameA], [NameE], [Note]) VALUES (N'a0724d8d-4764-4d44-90a4-138bec9a0dec', 1, N'??????????????', N'to Rent', N'----------')\r\n                                                INSERT [dbo].[T_EqarNatural] ([EqarNatural_ID], [EqarNatural_No], [NameA], [NameE], [Note]) VALUES (N'4bcb64e1-1897-40a7-b705-955a70f641a4', 2, N'??????????', N'To Sales', N'--------')");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("\r\n                                    SET ANSI_NULLS ON\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    SET ANSI_PADDING ON\r\n                                    CREATE TABLE [dbo].[T_AinTyp](\r\n\t                                    [AinTyp_ID] [varchar](40) NOT NULL,\r\n\t                                    [AinTyp_No] [int] NOT NULL,\r\n\t                                    [NameA] [varchar](30) NULL,\r\n\t                                    [NameE] [varchar](30) NULL,\r\n\t                                    [Note] [varchar](50) NULL,\r\n                                     CONSTRAINT [PK_T_AinTyp] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [AinTyp_No] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n                                    SET ANSI_PADDING OFF\r\n                                    INSERT [dbo].[T_AinTyp] ([AinTyp_ID], [AinTyp_No], [NameA], [NameE], [Note]) VALUES (N'8f9260d3-3c6c-4e00-a989-89ed520c8230', 1, N'??????', N'Flat', N'----------')\r\n                                    INSERT [dbo].[T_AinTyp] ([AinTyp_ID], [AinTyp_No], [NameA], [NameE], [Note]) VALUES (N'f1fbd4c5-7fe3-4830-ae5f-b92b0f4b64f3', 2, N'????????????', N'Store', N'--------')\r\n                                    INSERT [dbo].[T_AinTyp] ([AinTyp_ID], [AinTyp_No], [NameA], [NameE], [Note]) VALUES (N'e32f19df-d0e5-45c6-b26c-49aa9d4e0a1e', 3, N'??????', N'Shop commercial', N'--------')\r\n                                    INSERT [dbo].[T_AinTyp] ([AinTyp_ID], [AinTyp_No], [NameA], [NameE], [Note]) VALUES (N'35d46f05-6b84-47ea-bfa3-315429288c63', 4, N'????????', N'Exhibition', N'--------')\r\n                                    INSERT [dbo].[T_AinTyp] ([AinTyp_ID], [AinTyp_No], [NameA], [NameE], [Note]) VALUES (N'40f0228b-27c4-4569-bb41-6966aca524cb', 5, N'????????', N'Hall', N'--------')");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("\r\n                                                SET ANSI_NULLS ON\r\n                                                SET QUOTED_IDENTIFIER ON\r\n                                                SET ANSI_PADDING ON\r\n                                                CREATE TABLE [dbo].[T_AinNatural](\r\n\t                                                [AinNatural_ID] [varchar](40) NOT NULL,\r\n\t                                                [AinNatural_No] [int] NOT NULL,\r\n\t                                                [NameA] [varchar](30) NULL,\r\n\t                                                [NameE] [varchar](30) NULL,\r\n\t                                                [Note] [varchar](50) NULL,\r\n                                                 CONSTRAINT [PK_T_AinNatural] PRIMARY KEY CLUSTERED \r\n                                                (\r\n\t                                                [AinNatural_No] ASC\r\n                                                )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                                ) ON [PRIMARY]\r\n                                                SET ANSI_PADDING OFF   \r\n                                                INSERT [dbo].[T_AinNatural] ([AinNatural_ID], [AinNatural_No], [NameA], [NameE], [Note]) VALUES (N'08696a45-14e0-4ee3-bd98-858dc4861c8e', 1, N'??????????????', N'to Rent', N'----------')\r\n                                                INSERT [dbo].[T_AinNatural] ([AinNatural_ID], [AinNatural_No], [NameA], [NameE], [Note]) VALUES (N'ffb6c5ee-e85a-4e8e-a0f5-d453d4ff463d', 2, N'??????????', N'To Sales', N'--------')");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("\r\n                                        SET ANSI_NULLS ON\r\n                                        SET QUOTED_IDENTIFIER ON\r\n                                        SET ANSI_PADDING ON\r\n                                        CREATE TABLE [dbo].[T_Owner](\r\n\t                                        [Owner_ID] [int] IDENTITY(1,1) NOT NULL,\r\n\t                                        [Owner_No] [int] NOT NULL,\r\n\t                                        [NameA] [varchar](50) NULL,\r\n\t                                        [NameE] [varchar](50) NULL,\r\n\t                                        [OwnerIdent] [varchar](50) NULL,\r\n\t                                        [OwnerIdentDate] [varchar](10) NULL,\r\n\t                                        [OwnerIdentSource] [varchar](100) NULL,\r\n\t                                        [Nationalty] [int] NULL,\r\n\t                                        [Address] [varchar](30) NULL,\r\n\t                                        [Tel] [varchar](30) NULL,\r\n\t                                        [Mobile] [varchar](30) NULL,\r\n                                         CONSTRAINT [PK_T_Owner] PRIMARY KEY CLUSTERED \r\n                                        (\r\n\t                                        [Owner_No] ASC\r\n                                        )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                        ) ON [PRIMARY]\r\n\r\n                                        SET ANSI_PADDING OFF\r\n                                        ALTER TABLE [dbo].[T_Owner]  WITH CHECK ADD  CONSTRAINT [FK_T_Owner_T_Nationalities] FOREIGN KEY([Nationalty])\r\n                                        REFERENCES [dbo].[T_Nationalities] ([Nation_No])\r\n                                        ALTER TABLE [dbo].[T_Owner] CHECK CONSTRAINT [FK_T_Owner_T_Nationalities]");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("    SET ANSI_NULLS ON\r\n                                        SET QUOTED_IDENTIFIER ON\r\n                                        SET ANSI_PADDING ON\r\n                                        CREATE TABLE [dbo].[T_EqarsData](\r\n\t                                        [EqarID] [int] IDENTITY(1,1) NOT NULL,\r\n\t                                        [EqarNo] [int] NOT NULL,\r\n\t                                        [NameA] [varchar](100) NULL,\r\n\t                                        [NameE] [varchar](100) NULL,\r\n\t                                        [EqarStatus] [int] NULL,\r\n\t                                        [AccNo] [varchar](30) NULL,\r\n\t                                        [Nationalty] [int] NULL,\r\n\t                                        [CityNo] [int] NULL,\r\n\t                                        [EqarTypNo] [int] NULL,\r\n\t                                        [EqarNatureNo] [int] NULL,\r\n\t                                        [OwnerNo] [int] NULL,\r\n\t                                        [ContractValue] [float] NULL,\r\n\t                                        [ContractRentValue] [float] NULL,\r\n\t                                        [SQNo] [varchar](100) NULL,\r\n\t                                        [SQDate] [varchar](10) NULL,\r\n\t                                        [Neighborhood] [varchar](100) NULL,\r\n\t                                        [Street] [varchar](100) NULL,\r\n\t                                        [FloorsCount] [int] NULL,\r\n\t                                        [EyesCount] [int] NULL,\r\n\t                                        [Space] [varchar](100) NULL,\r\n\t                                        [Note] [varchar](500) NULL,\r\n                                         CONSTRAINT [PK_T_EqarsData] PRIMARY KEY CLUSTERED \r\n                                        (\r\n\t                                        [EqarID] ASC\r\n                                        )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                        ) ON [PRIMARY]\r\n\r\n                                        SET ANSI_PADDING OFF\r\n                                        ALTER TABLE [dbo].[T_EqarsData]  WITH CHECK ADD  CONSTRAINT [FK_T_EqarsData_T_AccDef] FOREIGN KEY([AccNo])\r\n                                        REFERENCES [dbo].[T_AccDef] ([AccDef_No])\r\n                                        ALTER TABLE [dbo].[T_EqarsData] CHECK CONSTRAINT [FK_T_EqarsData_T_AccDef]\r\n                                        ALTER TABLE [dbo].[T_EqarsData]  WITH CHECK ADD  CONSTRAINT [FK_T_EqarsData_T_City] FOREIGN KEY([CityNo])\r\n                                        REFERENCES [dbo].[T_City] ([City_No])\r\n                                        ALTER TABLE [dbo].[T_EqarsData] CHECK CONSTRAINT [FK_T_EqarsData_T_City]\r\n                                        ALTER TABLE [dbo].[T_EqarsData]  WITH CHECK ADD  CONSTRAINT [FK_T_EqarsData_T_EqarNatural] FOREIGN KEY([EqarNatureNo])\r\n                                        REFERENCES [dbo].[T_EqarNatural] ([EqarNatural_No])\r\n                                        ALTER TABLE [dbo].[T_EqarsData] CHECK CONSTRAINT [FK_T_EqarsData_T_EqarNatural]\r\n                                        ALTER TABLE [dbo].[T_EqarsData]  WITH CHECK ADD  CONSTRAINT [FK_T_EqarsData_T_EqarTyp] FOREIGN KEY([EqarTypNo])\r\n                                        REFERENCES [dbo].[T_EqarTyp] ([EqarTyp_No])\r\n                                        ALTER TABLE [dbo].[T_EqarsData] CHECK CONSTRAINT [FK_T_EqarsData_T_EqarTyp]\r\n                                        ALTER TABLE [dbo].[T_EqarsData]  WITH CHECK ADD  CONSTRAINT [FK_T_EqarsData_T_Nationalities] FOREIGN KEY([Nationalty])\r\n                                        REFERENCES [dbo].[T_Nationalities] ([Nation_No])\r\n                                        ALTER TABLE [dbo].[T_EqarsData] CHECK CONSTRAINT [FK_T_EqarsData_T_Nationalities]\r\n                                        ALTER TABLE [dbo].[T_EqarsData]  WITH CHECK ADD  CONSTRAINT [FK_T_EqarsData_T_Owner] FOREIGN KEY([OwnerNo])\r\n                                        REFERENCES [dbo].[T_Owner] ([Owner_No])\r\n                                        ALTER TABLE [dbo].[T_EqarsData] CHECK CONSTRAINT [FK_T_EqarsData_T_Owner]");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("SET ANSI_NULLS ON\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    SET ANSI_PADDING ON\r\n                                    CREATE TABLE [dbo].[T_AinsData](\r\n\t                                    [AinID] [int] IDENTITY(1,1) NOT NULL,\r\n\t                                    [AinNo] [varchar](100) NOT NULL,\r\n\t                                    [EqarID] [int] NOT NULL,\r\n\t                                    [AinTyp] [int] NOT NULL,\r\n\t                                    [AinNature] [int] NOT NULL,\r\n\t                                    [AinStatus] [int] NULL,\r\n\t                                    [RentOfYear] [float] NULL,\r\n\t                                    [EyeValue] [float] NULL,\r\n\t                                    [EyeDetail] [varchar](750) NULL,\r\n                                     CONSTRAINT [PK_T_Ain] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [AinID] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n\r\n                                    SET ANSI_PADDING OFF\r\n                                    ALTER TABLE [dbo].[T_AinsData]  WITH CHECK ADD  CONSTRAINT [FK_T_AinsData_T_AinNatural] FOREIGN KEY([AinNature])\r\n                                    REFERENCES [dbo].[T_AinNatural] ([AinNatural_No])\r\n                                    ALTER TABLE [dbo].[T_AinsData] CHECK CONSTRAINT [FK_T_AinsData_T_AinNatural]\r\n                                    ALTER TABLE [dbo].[T_AinsData]  WITH CHECK ADD  CONSTRAINT [FK_T_AinsData_T_AinTyp] FOREIGN KEY([AinTyp])\r\n                                    REFERENCES [dbo].[T_AinTyp] ([AinTyp_No])\r\n                                    ALTER TABLE [dbo].[T_AinsData] CHECK CONSTRAINT [FK_T_AinsData_T_AinTyp]\r\n                                    ALTER TABLE [dbo].[T_AinsData]  WITH CHECK ADD  CONSTRAINT [FK_T_AinsData_T_EqarsData] FOREIGN KEY([EqarID])\r\n                                    REFERENCES [dbo].[T_EqarsData] ([EqarID])\r\n                                    ALTER TABLE [dbo].[T_AinsData] CHECK CONSTRAINT [FK_T_AinsData_T_EqarsData]");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("SET ANSI_NULLS ON\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    SET ANSI_PADDING ON\r\n                                    CREATE TABLE [dbo].[T_EqarContract](\r\n\t                                    [ContractID] [int] IDENTITY(1,1) NOT NULL,\r\n\t                                    [ContractNo] [varchar](100) NOT NULL,\r\n\t                                    [EqarID] [int] NOT NULL,\r\n\t                                    [AinID] [int] NOT NULL,\r\n\t                                    [StartDate] [varchar](10) NOT NULL,\r\n\t                                    [EndDate] [varchar](10) NOT NULL,\r\n\t                                    [RentOfYear] [float] NOT NULL,\r\n\t                                    [tenant] [int] NOT NULL,\r\n\t                                    [Note] [varchar](500) NULL,\r\n                                     CONSTRAINT [PK_T_EqarContract] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [ContractID] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n\r\n                                    SET ANSI_PADDING OFF\r\n                                    ALTER TABLE [dbo].[T_EqarContract]  WITH CHECK ADD  CONSTRAINT [FK_T_EqarContract_T_AinsData] FOREIGN KEY([AinID])\r\n                                    REFERENCES [dbo].[T_AinsData] ([AinID])\r\n                                    ALTER TABLE [dbo].[T_EqarContract] CHECK CONSTRAINT [FK_T_EqarContract_T_AinsData]\r\n                                    ALTER TABLE [dbo].[T_EqarContract]  WITH CHECK ADD  CONSTRAINT [FK_T_EqarContract_T_EqarsData] FOREIGN KEY([EqarID])\r\n                                    REFERENCES [dbo].[T_EqarsData] ([EqarID])\r\n                                    ALTER TABLE [dbo].[T_EqarContract] CHECK CONSTRAINT [FK_T_EqarContract_T_EqarsData]");
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("SET ANSI_NULLS ON\r\n                                    SET QUOTED_IDENTIFIER ON\r\n                                    SET ANSI_PADDING ON\r\n                                    CREATE TABLE [dbo].[T_EqarSale](\r\n\t                                    [EqarSaleID] [int] IDENTITY(1,1) NOT NULL,\r\n\t                                    [EqarSaleNo] [varchar](100) NOT NULL,\r\n\t                                    [EqarID] [int] NOT NULL,\r\n\t                                    [AinID] [int] NULL,\r\n\t                                    [GDate] [varchar](10) NOT NULL,\r\n\t                                    [HDate] [varchar](10) NOT NULL,\r\n\t                                    [SaleValue] [float] NULL,\r\n\t                                    [Note] [varchar](500) NULL,\r\n                                     CONSTRAINT [PK_T_EqarSale] PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [EqarSaleID] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]\r\n\r\n                                    SET ANSI_PADDING OFF\r\n                                    ALTER TABLE [dbo].[T_EqarSale]  WITH CHECK ADD  CONSTRAINT [FK_T_EqarSale_T_AinsData] FOREIGN KEY([AinID])\r\n                                    REFERENCES [dbo].[T_AinsData] ([AinID])\r\n                                    ALTER TABLE [dbo].[T_EqarSale] CHECK CONSTRAINT [FK_T_EqarSale_T_AinsData]\r\n                                    ALTER TABLE [dbo].[T_EqarSale]  WITH CHECK ADD  CONSTRAINT [FK_T_EqarSale_T_EqarsData] FOREIGN KEY([EqarID])\r\n                                    REFERENCES [dbo].[T_EqarsData] ([EqarID])\r\n                                    ALTER TABLE [dbo].[T_EqarSale] CHECK CONSTRAINT [FK_T_EqarSale_T_EqarsData]");
                }
                catch
                {
                }
                try
                {
                    try
                    {
                        db.ExecuteCommand("SET IDENTITY_INSERT [dbo].[T_AccCat] ON\r\n                                    INSERT [dbo].[T_AccCat] ([AccCat_ID], [AccCat_No], [Arb_Des], [Eng_Des], [CompanyID]) VALUES (12, N'12', N'????????????????????', N'Tenant', 1)\r\n                                    SET IDENTITY_INSERT [dbo].[T_AccCat] OFF");
                    }
                    catch
                    {
                    }
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [EqarAlarmContractEnd] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [EqarAlarmContractEnd] = 30 ");
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD  [EqarAlarmDayPay] [int] NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [EqarAlarmDayPay] = 5 ");
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [EqarAcc] [varchar](30) NULL");
                    db.ExecuteCommand("ALTER TABLE T_SYSSETTING ADD [tenantAcc] [varchar](30) NULL");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [EqarAcc] = '' ");
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [tenantAcc] = '' ");
                    try
                    {
                        T_AccDef tAccDef1 = db.StockAccDef("10110");
                        if (tAccDef1 == null || string.IsNullOrEmpty(tAccDef1.AccDef_No))
                        {
                            num1 = 1;
                            try
                            {
                                num1 = db.T_AccDefs.Max<T_AccDef, int>((Expression<Func<T_AccDef, int>>)(lgl => Convert.ToInt32(lgl.AccDef_ID))) + 1;
                            }
                            catch
                            {
                            }
                            db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [DepreciationPercent], [ProofAcc], [RelayAcc],[MaxDisCust],[vColNum1],[vColNum2],[vColStr1],[vColStr2],[vColStr3]) VALUES ( N'10110', N'????????????????', N'Real Est', N'101', 3, NULL, 1, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, '', '',0,0,0,'','','')");
                            T_AccDef tAccDef2 = db.StockAccDef("10110");
                            if (tAccDef2 != null && !string.IsNullOrEmpty(tAccDef2.AccDef_No))
                                db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [EqarAcc] = '10110' ");
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        T_AccDef tAccDef1 = db.StockAccDef("1027");
                        if (tAccDef1 == null || string.IsNullOrEmpty(tAccDef1.AccDef_No))
                        {
                            num1 = 1;
                            try
                            {
                                num1 = db.T_AccDefs.Max<T_AccDef, int>((Expression<Func<T_AccDef, int>>)(lgl => Convert.ToInt32(lgl.AccDef_ID))) + 1;
                            }
                            catch
                            {
                            }
                            db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [DepreciationPercent], [ProofAcc], [RelayAcc],[MaxDisCust],[vColNum1],[vColNum2],[vColStr1],[vColStr2],[vColStr3]) VALUES ( N'1027', N'????????????????????', N'Tenant', N'102', 3, NULL, 12, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, '', '',0,0,0,'','','')");
                            T_AccDef tAccDef2 = db.StockAccDef("1027");
                            if (tAccDef2 != null && !string.IsNullOrEmpty(tAccDef2.AccDef_No))
                                db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [tenantAcc] = '1027' ");
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("SET ANSI_NULLS ON\r\n                                        SET QUOTED_IDENTIFIER ON\r\n                                        SET ANSI_PADDING ON\r\n                                        CREATE TABLE [dbo].[T_Tenant](\r\n\t                                        [tenantID] [int] IDENTITY(1,1) NOT NULL,\r\n\t                                        [tenantNo] [int] NOT NULL,\r\n\t                                        [NameA] [varchar](100) NULL,\r\n\t                                        [NameE] [varchar](100) NULL,\r\n\t                                        [AccNo] [varchar](30) NULL,\r\n\t                                        [Nationalty] [int] NULL,\r\n\t                                        [IDNo] [varchar](100) NULL,\r\n\t                                        [IDDate] [varchar](10) NULL,\r\n\t                                        [IDSource] [varchar](200) NULL,\r\n\t                                        [Tel] [varchar](100) NULL,\r\n\t                                        [Mobile] [varchar](100) NULL,\r\n\t                                        [workAdd] [varchar](200) NULL,\r\n\t                                        [workPhone] [varchar](100) NULL,\r\n\t                                        [BossName] [varchar](100) NULL,\r\n\t                                        [BossID] [varchar](100) NULL,\r\n\t                                        [BossIDDate] [varchar](10) NULL,\r\n\t                                        [BossIDSource] [varchar](200) NULL,\r\n\t                                        [BossAdd] [varchar](200) NULL,\r\n\t                                        [BossPhone] [varchar](100) NULL,\r\n\t                                        [BossMobile] [varchar](100) NULL,\r\n                                         CONSTRAINT [PK_T_Tenant] PRIMARY KEY CLUSTERED \r\n                                        (\r\n\t                                        [tenantID] ASC\r\n                                        )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                        ) ON [PRIMARY]\r\n\r\n                                        SET ANSI_PADDING OFF\r\n                                        ALTER TABLE [dbo].[T_Tenant]  WITH CHECK ADD  CONSTRAINT [FK_T_Tenant_T_AccDef] FOREIGN KEY([AccNo])\r\n                                        REFERENCES [dbo].[T_AccDef] ([AccDef_No])\r\n                                        ALTER TABLE [dbo].[T_Tenant] CHECK CONSTRAINT [FK_T_Tenant_T_AccDef]\r\n                                        ALTER TABLE [dbo].[T_Tenant]  WITH CHECK ADD  CONSTRAINT [FK_T_Tenant_T_Nationalities] FOREIGN KEY([Nationalty])\r\n                                        REFERENCES [dbo].[T_Nationalities] ([Nation_No])\r\n                                        ALTER TABLE [dbo].[T_Tenant] CHECK CONSTRAINT [FK_T_Tenant_T_Nationalities]");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("SET ANSI_NULLS ON\r\n                                        SET QUOTED_IDENTIFIER ON\r\n                                        SET ANSI_PADDING ON\r\n                                        CREATE TABLE [dbo].[T_TenantContract](\r\n\t                                        [ContractID] [int] IDENTITY(1,1) NOT NULL,\r\n\t                                        [ContractNo] [int] NOT NULL,\r\n\t                                        [tenant_ID] [int] NOT NULL,\r\n\t                                        [Eqar_ID] [int] NOT NULL,\r\n\t                                        [Ain_ID] [int] NULL,\r\n\t                                        [RentOfYear] [float] NULL,\r\n\t                                        [ContractStart] [varchar](10) NOT NULL,\r\n\t                                        [ContractEnd] [varchar](10) NOT NULL,\r\n\t                                        [RentOfYearPayment] [float] NULL,\r\n\t                                        [PayMethod] [int] NULL,\r\n                                         CONSTRAINT [PK_T_TenantContract] PRIMARY KEY CLUSTERED \r\n                                        (\r\n\t                                        [ContractID] ASC\r\n                                        )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                        ) ON [PRIMARY]\r\n\r\n                                        SET ANSI_PADDING OFF\r\n                                        ALTER TABLE [dbo].[T_TenantContract]  WITH CHECK ADD  CONSTRAINT [FK_T_TenantContract_T_AinsData] FOREIGN KEY([Ain_ID])\r\n                                        REFERENCES [dbo].[T_AinsData] ([AinID])\r\n                                        ALTER TABLE [dbo].[T_TenantContract] CHECK CONSTRAINT [FK_T_TenantContract_T_AinsData]\r\n                                        ALTER TABLE [dbo].[T_TenantContract]  WITH CHECK ADD  CONSTRAINT [FK_T_TenantContract_T_EqarsData] FOREIGN KEY([Eqar_ID])\r\n                                        REFERENCES [dbo].[T_EqarsData] ([EqarID])\r\n                                        ALTER TABLE [dbo].[T_TenantContract] CHECK CONSTRAINT [FK_T_TenantContract_T_EqarsData]\r\n                                        ALTER TABLE [dbo].[T_TenantContract]  WITH CHECK ADD  CONSTRAINT [FK_T_TenantContract_T_Tenant] FOREIGN KEY([tenant_ID])\r\n                                        REFERENCES [dbo].[T_Tenant] ([tenantID])\r\n                                        ALTER TABLE [dbo].[T_TenantContract] CHECK CONSTRAINT [FK_T_TenantContract_T_Tenant]");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("SET ANSI_NULLS ON\r\n                                        SET QUOTED_IDENTIFIER ON\r\n                                        SET ANSI_PADDING ON\r\n                                        CREATE TABLE [dbo].[T_AlarmTenant](\r\n\t                                        [AlarmTenantID] [int] IDENTITY(1,1) NOT NULL,\r\n\t                                        [AlarmTenantNo] [int] NOT NULL,\r\n\t                                        [AlarmDateG] [varchar](10) NOT NULL,\r\n\t                                        [AlarmDateH] [varchar](10) NOT NULL,\r\n\t                                        [tenant_ID] [int] NOT NULL,\r\n\t                                        [AlarmSubject] [varchar](100) NOT NULL,\r\n\t                                        [AlarmDetail] [varchar](1500) NULL,\r\n\t                                        [AlarmAdmin] [varchar](100) NULL,\r\n                                         CONSTRAINT [PK_T_AlarmTenant] PRIMARY KEY CLUSTERED \r\n                                        (\r\n\t                                        [AlarmTenantNo] ASC\r\n                                        )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                        ) ON [PRIMARY]\r\n\r\n                                        SET ANSI_PADDING OFF\r\n                                        ALTER TABLE [dbo].[T_AlarmTenant]  WITH CHECK ADD  CONSTRAINT [FK_T_AlarmTenant_T_Tenant] FOREIGN KEY([tenant_ID])\r\n                                        REFERENCES [dbo].[T_Tenant] ([tenantID])\r\n                                        ALTER TABLE [dbo].[T_AlarmTenant] CHECK CONSTRAINT [FK_T_AlarmTenant_T_Tenant]");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("SET ANSI_NULLS ON\r\n                                        SET QUOTED_IDENTIFIER ON\r\n                                        SET ANSI_PADDING ON\r\n                                        CREATE TABLE [dbo].[T_TenantPayment](\r\n\t                                        [PaymentID] [int] IDENTITY(1,1) NOT NULL,\r\n\t                                        [PaymentNo] [int] NOT NULL,\r\n\t                                        [tenantContract_ID] [int] NOT NULL,\r\n\t                                        [Value] [float] NULL,\r\n\t                                        [PayMonth] [varchar](10) NULL,\r\n\t                                        [Statue] [bit] NULL,\r\n\t                                        [Remining] [float] NULL,\r\n\t                                        [SndNo] [int] NULL,\r\n                                         CONSTRAINT [PK_T_TenantPayment] PRIMARY KEY CLUSTERED \r\n                                        (\r\n\t                                        [PaymentID] ASC\r\n                                        )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                        ) ON [PRIMARY]\r\n\r\n                                        SET ANSI_PADDING OFF\r\n                                        ALTER TABLE [dbo].[T_TenantPayment]  WITH CHECK ADD  CONSTRAINT [FK_T_TenantPayment_T_GDHEAD] FOREIGN KEY([SndNo])\r\n                                        REFERENCES [dbo].[T_GDHEAD] ([gdhead_ID])\r\n                                        ALTER TABLE [dbo].[T_TenantPayment] CHECK CONSTRAINT [FK_T_TenantPayment_T_GDHEAD]\r\n                                        ALTER TABLE [dbo].[T_TenantPayment]  WITH CHECK ADD  CONSTRAINT [FK_T_TenantPayment_T_TenantContract] FOREIGN KEY([tenantContract_ID])\r\n                                        REFERENCES [dbo].[T_TenantContract] ([ContractID])\r\n                                        ALTER TABLE [dbo].[T_TenantPayment] CHECK CONSTRAINT [FK_T_TenantPayment_T_TenantContract]");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("        SET IDENTITY_INSERT [dbo].[T_INVSETTING] ON\r\n                                            INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines],[defSizePaper],[Orientation],[CatID],[PrintCat]) VALUES (29, 29, N'?????? ?????? ????????????', N'Catch Receipt Tenant', N'1', N'1         ', N'?????????????? ???? ????????????             ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 16706518, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 10, N'', N'111 ', NULL, 1, 1,1,N'',1,NULL,0)\r\n                                            INSERT [dbo].[T_INVSETTING] ([InvSet_ID], [InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines],[defSizePaper],[Orientation],[CatID],[PrintCat]) VALUES (30, 30, N'?????? ?????? ????????????', N'receipt Tenant', N'1', N'1         ', N'???????????? ???? ????????????              ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, -2147483633, 16706518, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 10, N'', N'111 ', NULL, 1, 1,1,N'',1,NULL,0)\r\n                                            SET IDENTITY_INSERT [dbo].[T_INVSETTING] OFF");
                    }
                    catch
                    {
                    }
                    try
                    {
                        db.ExecuteCommand("  ALTER PROCEDURE [dbo].[S_T_GDHEAD_DELETE](\r\n                                          @gdhead_ID INT \r\n                                          )\r\n                                          AS\r\n                                          BEGIN\r\n                                          \r\n                                          UPDATE T_GDHEAD SET T_GDHEAD.gdLok = 'True',T_GDHEAD.gdTp = null,T_GDHEAD.gdRcptID = null \r\n                                          From T_GDHEAD\r\n                                          where @gdhead_ID = gdhead_ID\r\n                                          \r\n                                          RETURN\r\n                                          END");
                    }
                    catch
                    {
                    }
                }
                catch
                {
                }
                try
                {

                    if (!File.Exists(Application.StartupPath + "\\\\Script\\\\Secriptjustlight.dll") && (!(VarGeneral.gUserName == "runsetting") || !File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", "").Trim() + "\\Secriptjustlight.dll")))
                        return;
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [InvNamA] = '?????? ????????????' ,[InvNamE] = 'Renting and Booking' where InvID = 1 ");
                    db.ExecuteCommand("Update [dbo].[T_INVSETTING] Set [InvNamA] = '?????????? ?????? ????????????' ,[InvNamE] = 'Renting and Booking Cancel' where InvID = 3 ");
                }
                catch
                {
                }
            }
        }

    }

    private void button1_Click(object sender, EventArgs e) => Environment.Exit(0);
    protected override void Dispose(bool disposing)
    {
        if (disposing && this.components != null)
            this.components.Dispose();
        base.Dispose(disposing);
    }
    private void InitializeComponent()
    {
        this.button1 = new System.Windows.Forms.Button();
        this.label1 = new System.Windows.Forms.Label();
        this.SuspendLayout();
        // 
        // button1
        // 
        this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
        this.button1.ForeColor = System.Drawing.Color.Black;
        this.button1.Location = new System.Drawing.Point(34, 128);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(438, 34);
        this.button1.TabIndex = 3;
        this.button1.Text = "????????????????";
        this.button1.UseVisualStyleBackColor = true;

        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
        this.label1.ForeColor = System.Drawing.Color.Black;
        this.label1.Location = new System.Drawing.Point(120, 68);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(268, 16);
        this.label1.TabIndex = 2;
        this.label1.Text = "???????? .. ???? ?????????? ???????????? ?????????????? ????????????????";
        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.label1.Click += new System.EventHandler(this.label1_Click);
        // 
        // FrmMain
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.Yellow;
        this.ClientSize = new System.Drawing.Size(493, 180);
        this.ControlBox = false;
        this.Controls.Add(this.button1);
        this.Controls.Add(this.label1);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; this.Name = "FrmMain";
        this.ShowIcon = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Load += new System.EventHandler(this.FrmMain_Load);
        this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
        this.ResumeLayout(false);
        this.PerformLayout();

    }
    private void FrmMain_Load(object sender, EventArgs e)
    {
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }
}
