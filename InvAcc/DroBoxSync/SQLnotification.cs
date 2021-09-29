using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace InvAcc
{
    class SQLDEPENDENCY
    {



        static void exe(string cms)
        {
            sampleSqlConnection = new SqlConnection(ConectionSetring);
            SqlCommand cm = new SqlCommand(cms, sampleSqlConnection);
            sampleSqlConnection.Open();
            cm.ExecuteNonQuery();
            sampleSqlConnection.Close();


        }
        static SqlCommand sampleSqlCommand;
        static SqlDependency sampleSqlDependency;
        static SqlConnection sampleSqlConnection;
        static void executes(string s, string con)
        {
            SqlConnection connection = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand(s, connection);
            try
            {
                connection.Open();
            }
            catch { }
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch { }
            connection.Close();

        }
        static DataTable execute(string s, string con)
        {
            DataTable ta = new DataTable();
            SqlConnection connection = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand(s, connection);

            //  cmd.Parameters.Add("@id", SqlDbType.Int).Value = i;
            try
            {
                connection.Open();
            }
            catch { }
            try
            {
                ta.Load(cmd.ExecuteReader());
            }
            catch { return null; }
            connection.Close();

            return ta;
        }
        public static string ConectionSetring =RegInfo.onlineuser;
        public static string DATABASENAME = "DB_A720C2_Customers";
        static void init()
        {
            string dbname = DATABASENAME;
            string ss = ConectionSetring;

            sampleSqlConnection = new SqlConnection(ss);


            DataTable tb = execute("SELECT is_broker_enabled FROM sys.databases WHERE name = 'Database_name';".Replace("Database_name", dbname), ss);
            if (tb.Rows.Count > 0)
            {
                if (((bool)tb.Rows[0][0]) == false)
                {
                    try
                    {
                        exe("USE [master] ALTER DATABASE [" + dbname + "] SET SINGLE_USER WITH Rollback IMMEDIATE ");
                        Thread.Sleep(5000);
                        //             dbx.ExecuteCommand("USE [master] RESTORE DATABASE [" +  + "] FROM DISK = '" + vFile1 + "' WITH FILE = 1 , " + vWITH);

                        string cms = @"ALTER DATABASE [DBNAME] SET ENABLE_BROKER WITH NO_WAIT";
                        cms = cms.Replace("DBNAME", dbname);
                        exe(cms);
                        Thread.Sleep(5000);
                        exe("USE [master] ALTER DATABASE [" + dbname + "] SET MULTI_USER");
                        string arguments = string.Empty;
                        string[] args = Environment.GetCommandLineArgs();
                        for (int i = 1; i < args.Length; i++)
                        {
                            arguments = arguments + args[i] + " ";
                        }

                    }
                    catch
                    {
                    }


                }


            }




        }
        public static string SelectMonitoryingStatement = "";
        public static void StopMonitoring()
        {
            SqlDependency.Stop(ConectionSetring);
        }
        public static void StartMonitoring()
        {
            try
            {
                SqlDependency.Start(ConectionSetring);


                DBMonitoring();

            }
            catch
            {

            }

        }

        static void DBMonitoring()
        {

            string c = SelectMonitoryingStatement;
            if (sampleSqlConnection == null)
                sampleSqlConnection = new SqlConnection(ConectionSetring);

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
                sampleSqlCommand.Connection.Close();
                if (sampleSqlConnection.State == ConnectionState.Closed)
                    sampleSqlConnection.Open();
                sampleSqlCommand.ExecuteReader();
            }

            sampleSqlCommand.Dispose();

        }
        public delegate void customMessageHandler(System.Object sender,
                                  SqlNotificationEventArgs e);
        public static event customMessageHandler changeOuers;
        private static void SqlDependencyOnChange(object sender, SqlNotificationEventArgs e)
        {

            if (changeOuers != null)
                changeOuers(sender, e);
            sampleSqlDependency.OnChange -= SqlDependencyOnChange;
            DBMonitoring();
        }




    }
}
