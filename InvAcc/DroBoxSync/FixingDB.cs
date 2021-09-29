using Microsoft.Win32;
using System;
using System.Data;
using System.Data.SqlClient;
namespace InvAcc.DroBoxSync
{
    class FixingDB
    {
        String user, pas, server;
#pragma warning disable CS0169 // The field 'FixingDB.con' is never used
        SqlConnection con;
#pragma warning restore CS0169 // The field 'FixingDB.con' is never used
        FixingDB(string ser, string username, string pass)
        {
            user = username;
            server = ser;
            pas = pass;
        }
        SqlConnection getcon(string db)
        {
            SqlConnection con = new SqlConnection(@"server=" + server +
                         ";Database=" + db + ";Integrated Security=false;" +
                         "User ID=" + user + "; Password=" + pas + "");
            return con;
        }
        void updateuserids(SqlConnection con, string newid, string oldid)
        {
            string ctxt = "update T_INVHED " +
                "set SalsManNo=@new where SalsManNo=@old;";
            string ctxt1 = "update T_INVHED " +
                "set UserNew=@new where UserNew=@old;";
            string ctxt2 = "update T_BankPeaper " +
                "set gdID=@new where gdID=@old;";
            string ctxt3 = "update T_EditItemPrice " +
                "set UsrNm=@new where UsrNm=@old;";
            string ctxt4 = "update T_GDHEAD " +
               "set gdUser=@new where gdUser=@old;";
            //string ctxt5 = "update T_IDType " +
            //   "set usr=@new where usr=@old;";
            // Res();
            SqlConnection sq = new SqlConnection("server=.\\PROSOFT;Database=PROSOFT_default_2;Integrated Security=false;User ID=sa; Password=Prosoft@prosoft&ma89;MultipleActiveResultSets=True");
            //con = sq;
            SqlCommand cmd1 = new SqlCommand(ctxt1 + ctxt1 + ctxt2 + ctxt3 + ctxt4 + ctxt, con);
            //   SqlCommand cmd5 = new SqlCommand(ctxt5, con);
            cmd1.Parameters.Add(new SqlParameter("@new", SqlDbType.Int)).Value = int.Parse(newid);
            cmd1.Parameters.Add(new SqlParameter("@old", SqlDbType.Int)).Value = int.Parse(oldid);
            //   for (decimal i = 0; i < 99999999999; i++) ;
            //for (decimal i = 0; i < 99999999999; i++) ;
            //for (decimal i = 0; i < 99999999999; i++) ;
            //for (decimal i = 0; i < 99999999999; i++) ;
            //for (decimal i = 0; i < 99999999999; i++) ;
            //for (decimal i = 0; i < 99999999999; i++) ;
            //for (decimal i = 0; i < 99999999999; i++) ;
            //for (decimal i = 0; i < 99999999999; i++) ;
            //for (decimal i = 0; i < 99999999999; i++) ;
            //for (decimal i = 0; i < 99999999999; i++) ;
            //for (decimal i = 0; i < 99999999999; i++) ;
            //for (decimal i = 0; i < 99999999999; i++) ;
            //for (decimal i = 0; i < 99999999999; i++) ;
            //cmd5.Parameters.Add(new SqlParameter("@new", SqlDbType.Int)).Value = int.Parse(newid);
            //cmd5.Parameters.Add(new SqlParameter("@oldid", SqlDbType.Int)).Value = int.Parse(oldid);
            try
            {
                con.Open();
                //cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                //cmd2.ExecuteNonQuery();
                //cmd3.ExecuteNonQuery();
                //cmd4.ExecuteNonQuery();
                // cmd5.ExecuteNonQuery();.
                con.Close();
            }
            catch
            {
                updateuserids(con, newid, oldid);
            }
        }
        public static string bnotest()
        {
            RegistryKey hKeyNeew1 = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", writable: true);
            string bno = "";
            try
            {
                object q = hKeyNeew1.GetValue("vBranchNo");
                bno = q.ToString();
            }
            catch
            {
                return "NA";
            }
            return bno;
        }
        public void updateMain(string BrancNo, string datadatabase)
        {
            string Database = "DBPROSOFT_default";
            SqlConnection con = getcon(Database);
            int brn = int.Parse(bnotest());
#pragma warning disable CS0219 // The variable 'cm' is assigned but its value is never used
            string cm = "select * from T_Users where Brn=@b;"
                ;
#pragma warning restore CS0219 // The variable 'cm' is assigned but its value is never used
            string upcmd = "update T_Users set Brn=1 where Brn=@b";
            SqlCommand cmd = new SqlCommand(upcmd, con);
            cmd.Parameters.Add(new SqlParameter("@b", System.Data.SqlDbType.Int)).Value = brn;
            DataTable t = new DataTable();
#pragma warning disable CS0219 // The variable 'sx' is assigned but its value is never used
            string sx = "Delete From T_Users where Brn!=1;";
#pragma warning restore CS0219 // The variable 'sx' is assigned but its value is never used
            SqlCommand cmd2 = new SqlCommand(upcmd, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            con.Close();
        }
    }
}
