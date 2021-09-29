using InvAcc.Forms;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
namespace ShamelSynch
{
    public class backdata
    {
        public string branchA;
        public string branchE;
        public int BrancheNo;
        public string dataPath;
        public string UsersPath;
        public DateTime time;
        public static string droppath = "";
        public backdata(string a, string e, int b)
        {
            branchA = a;
            branchE = e;
            BrancheNo = b;
            if (droppath == "")
                getpath();
            if (droppath != "-")
            {
                dataPath = droppath + "\\" + b.ToString() + "\\1.bak";
                FileInfo i = new FileInfo(dataPath);
                if (i.Exists == false)
                { dataPath = "-"; time = DateTime.MinValue; }
                else
                    time = i.CreationTime;
                UsersPath = droppath + "\\" + b.ToString() + "\\2.bak"; ;
            }

        }
        void getpath()
        {
            // string BackPath;
            try
            {
                string appDataPath = Environment.GetFolderPath(
                                 Environment.SpecialFolder.ApplicationData);
                appDataPath = appDataPath.Replace("Roaming", "Local");
                string dbPath = System.IO.Path.Combine(appDataPath, "Dropbox\\host.db");
                string[] lines = System.IO.File.ReadAllLines(dbPath);
                byte[] dbBase64Text = Convert.FromBase64String(lines[1]);
                droppath = System.Text.ASCIIEncoding.ASCII.GetString(dbBase64Text);
                //  return BackPath;
            }
            catch
            {// MessageBox.Show(" الرجاء التاكد من تثبيت برنامج الدروب بوكس "); Application.ExitThread(); 
            }
            //    return "-";
        }
    }
    public class dropback
    {
        int barchcount = 0;
        List<backdata> Info;
        public dropback()
        {
            Info = new List<backdata>();
            foreach (DataRow r in DropBoxSyncronization.Brtbl.Rows)
            {
                int brn = int.Parse(r["Branch_no"].ToString());
                string A = r["Branch_Name"].ToString();
                string E = r["Branch_NameE"].ToString();
                backdata b = new backdata(A, E, brn);
                if (brn != 1) addinfo(b);

            }
            gettable();
        }
        void addinfo(backdata b)
        {
            //  Info.RemoveAt(brno - 1);
            foreach (backdata r in Info)
            {
                if (r.BrancheNo == b.BrancheNo) { return; }
            }
            Info.Add(b);
        }
        public bool iscorrect(string p)
        {
            foreach (backdata r in Info)
            {
                if (r.dataPath == p)
                    return true;
                if (r.UsersPath == p)
                    return true;
            }
            return false;
        }
        public void deletebackfile(string s)
        {
            foreach (backdata r in Info)
            {
                if (r.dataPath == s)
                {
                    r.time = DateTime.MinValue; r.dataPath = "-";
                }
                if (r.UsersPath == s)
                { r.time = DateTime.MinValue; r.UsersPath = "-"; }
            }
        }
        public void updatepaths(string br)
        {
            if (br.Contains("1.bak") || br.Contains("2.bak"))
            {
                br = br.Replace(backdata.droppath + "\\", "");
                char[] c = { '\\' };
                string[] s = br.Split(c);
                int ins = int.Parse(s[0]);
                int i = getindex(ins);
                //    Info[i].time = t;
                if (br.Contains("1.bak")) Info[i].dataPath = backdata.droppath + "\\" + ins.ToString() + "\\1.bak";
                if (br.Contains("2.bak")) Info[i].UsersPath = backdata.droppath + "\\" + ins.ToString() + "\\2.bak";
                FileInfo fs = new FileInfo(Info[i].dataPath);
                Info[i].time = fs.CreationTimeUtc;
            }
        }
        public void updatetime(DateTime t, string br)
        {
            if (iscorrect(br))
            {
                br = br.Replace(backdata.droppath + "\\", "");
                char[] c = { '\\' };
                string[] s = br.Split(c);
                int ins = int.Parse(s[0]);
                int i = getindex(ins);
                Info[i].time = t;
                Info[i].dataPath = backdata.droppath + "\\" + ins.ToString() + "\\1.bak";
                Info[i].UsersPath = backdata.droppath + "\\" + ins.ToString() + "\\2.bak";
                FileInfo fs = new FileInfo(Info[i].dataPath);
                Info[i].time = fs.CreationTimeUtc;
            }
        }
        public DataTable table = new DataTable();
        public DataTable gettable()
        {
            DataTable t = new DataTable();
            t.Columns.Add("BrA", typeof(string));
            //  t.Columns.Add("BrE",typeof(string));
            t.Columns.Add("Time", typeof(DateTime));
            foreach (backdata i in Info)
            {
                DataRow r = t.NewRow();
                r["BrA"] = i.branchA;
                //    r["BrE"] = i.branchE;
                r["Time"] = i.time;
                t.Rows.Add(r);
            }
            table = t;
            return t;
        }
        public int getindex(int brno)
        {
            backdata b;
            for (int i = 0; i < Info.Count; i++)
            {
                if (Info[i].BrancheNo == brno)
                {
                    return i;
                }
            }
            return -1;
        }
        public backdata get(int brno)
        {
            backdata b;
            foreach (backdata f in Info)
            {
                if (f.BrancheNo == brno)
                {
                    return f;
                }
            }
            return null;
        }
        public backdata get(string brno)
        {
            backdata b;
            foreach (backdata f in Info)
            {
                if (f.branchA == brno)
                {
                    return f;
                }
            }
            return null;
        }
    }
    public class DropBoxSyncronization
    {
        public dropback dropsyninfo;
        public SqlConnection SQLiteC = new SqlConnection();
        DataTable dt = new DataTable();
        //string PATHH = Properties.Settings.Default.DBPATH;
        public static DataTable Brtbl = new DataTable();
        DataTable Usertbl = new DataTable();
        string BackPath = "";
        string txt_path, s;
        string dbpath = @"C:\Program Files\Microsoft SQL Server";//MSSQL12.ShamelSoft" + @"\MSSQL\DATA";
        public string MainDataBase, ServerName;
        public string Password;
        public string Username;
        public string moode;
        string appDataPath;
        string dbPath;
        string[] lines;
        byte[] dbBase64Text;
        void createtempdb()
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
            DataAccessLayer("master", ServerName);
            SqlCommand cmd = new SqlCommand(script, SQLiteC);
            SQLiteC.Open();
            cmd.ExecuteNonQuery();
            SQLiteC.Close();
        }
        public void prepare()
        {
            DataAccessLayer(MainDataBase, ServerName);
            SqlCommand cmd = new SqlCommand("Select * from T_Branch ;", SQLiteC);
            SqlDataAdapter t = new SqlDataAdapter(cmd);
            SqlCommand cmd2 = new SqlCommand("select * from T_USERS;", SQLiteC);
            SqlDataAdapter t2 = new SqlDataAdapter(cmd2);
            try
            {
                SQLiteC.Open();
                t.Fill(Brtbl);
                t2.Fill(Usertbl);
                SQLiteC.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            dropsyninfo = new dropback();
            Filewatcher.Path = backdata.droppath;
            Filewatcher.Filter = "*.*";
            Filewatcher.IncludeSubdirectories = true;
            Filewatcher.Changed += FileSystemWatcher_Renamed;
            Filewatcher.Created += FileSystemWatcher_Created;
            Filewatcher.Deleted += FileSystemWatcher_Deleted;
            Filewatcher.EnableRaisingEvents = true;
        }
        public DropBoxSyncronization(string db, string sn, string us, string pass, string mod, string sqlfolder)
        {
            
            pa = new string[66] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "aa", "bb", "cc", "dd", "ee", "ff", "gg", "hh", "ii", "jj", "kk", "ll", "mm", "nn", "oo", "pp", "qq", "rr", "ss", "tt", "uu", "vv", "ww", "xx", "yy", "zz", "aaa", "bbb", "ccc", "ddd", "eee", "fff", "ggg", "hhh", "iii", "jjj", "kkk", "lll", "mmm", "nnn" };
            dbpath += sqlfolder + @"\MSSQL\DATA";
            MainDataBase = db;
            ServerName = sn;
            moode = mod;
            Username = us;
            Password = pass;
            DataAccessLayer(db, sn);
            SqlCommand cmd = new SqlCommand("Select * from T_Branch ;", SQLiteC);
            SqlDataAdapter t = new SqlDataAdapter(cmd);
            SqlCommand cmd2 = new SqlCommand("select * from T_USERS;", SQLiteC);
            SqlDataAdapter t2 = new SqlDataAdapter(cmd2);
            try
            {
                SQLiteC.Open();
                t.Fill(Brtbl);
                t2.Fill(Usertbl);
                SQLiteC.Close();
            }
            catch (SqlException ex)
            {
                return;
                //       MessageBox.Show(ex.Message);
            }
            try
            {
                try
                {
                    createtempdb();
                }
                catch { }
                DataAccessLayer("DB_temp", sn);
                SqlCommand cdmd2 = new SqlCommand("Select * from T_Branch ;", SQLiteC);
                SqlDataAdapter t222 = new SqlDataAdapter(cdmd2);
                DataTable ts = new DataTable();
                SQLiteC.Open();
                t.Fill(ts);
                t2.Fill(ts);
                SQLiteC.Close();
                dropsyninfo = new dropback();
                Filewatcher.Path = backdata.droppath;
                Filewatcher.Filter = "*.*";
                Filewatcher.IncludeSubdirectories = true;
                Filewatcher.Changed += FileSystemWatcher_Renamed;
                Filewatcher.Created += FileSystemWatcher_Created;
                Filewatcher.Deleted += FileSystemWatcher_Deleted;
                Filewatcher.EnableRaisingEvents = true;
            }
            catch
            {

            }
            setbackpaths();
        }
        private void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            dropsyninfo.updatepaths(e.FullPath);// (DateTime.Now,e.FullPath);
            if (caller != null)
                caller.syninfo();
            string sa = bnohtest();
            if (sa == "1")
            {
                string sas = FrmSystemSetting.getbno();
                if (sas == "1")
                { syncAll(); }
            }
            else
            {
            }
        }
        public string bnohtest()
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
        private void FileSystemWatcher_Renamed(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                dropsyninfo.updatetime(DateTime.Now, e.FullPath);
                if (caller != null)
                    caller.syninfo();
            }
        }
        private void FileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            dropsyninfo.deletebackfile(e.FullPath);

        }
        public FileSystemWatcher Filewatcher = new FileSystemWatcher();
        public DropBoxSyncronization(string sn, string us, string pass, string mod, string sqlfolder)
        {
            pa = new string[66] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "aa", "bb", "cc", "dd", "ee", "ff", "gg", "hh", "ii", "jj", "kk", "ll", "mm", "nn", "oo", "pp", "qq", "rr", "ss", "tt", "uu", "vv", "ww", "xx", "yy", "zz", "aaa", "bbb", "ccc", "ddd", "eee", "fff", "ggg", "hhh", "iii", "jjj", "kkk", "lll", "mmm", "nnn" };
            dbpath += sqlfolder + @"\MSSQL\DATA";
            //           MainDataBase = db;
            ServerName = sn;
            moode = mod;
            Username = us;
            Password = pass;
            //         DataAccessLayer(db, sn);
            //SqlCommand cmd = new SqlCommand("Select * from T_Branch ;", SQLiteC);
            //SqlDataAdapter t = new SqlDataAdapter(cmd);
            //SqlCommand cmd2 = new SqlCommand("select * from T_USERS;", SQLiteC);
            //SqlDataAdapter t2 = new SqlDataAdapter(cmd2);
            //try
            //{
            //    SQLiteC.Open();
            //    t.Fill(Brtbl);
            //    t2.Fill(Usertbl);
            //    SQLiteC.Close();
            //}
            //catch (SqlException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //try
            //{
            //    DataAccessLayer("DB_temp", sn);
            //    SqlCommand cdmd2 = new SqlCommand("Select * from T_Branch ;", SQLiteC);
            //    SqlDataAdapter t222 = new SqlDataAdapter(cdmd2);
            //    SQLiteC.Open();
            //    t.Fill(Brtbl);
            //    t2.Fill(Usertbl);
            //    SQLiteC.Close();
            //}
            //catch
            //{
            //    try
            //    {
            //        createtempdb();
            //    }
            //    catch { }
            //}
            setbackpaths();
        }
        void DataAccessLayer(string database, string server)
        {
            try
            {
                if (moode == "SQL")
                {
                    SQLiteC = new SqlConnection(@"server=" + server +
                        ";Database=" + database + ";Integrated Security=false;" +
                        "User ID=" + Username + "; Password=" + Password + "");
                }
                else
                {
                    SQLiteC = new SqlConnection(@"server=" + server +
                        ";Database=" + database + ";Integrated Security=true;");
                }
            }
            catch (SqlException sqlex)
            {
                System.Windows.Forms.MessageBox.Show("غير قادر على الإتصال بالسيرفر " + sqlex.Message, "خطا غير متوقع");
                return;
            }
        }
        SqlConnection DataAccessLayer2(string database, string server)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                if (moode == "SQL")
                {
                    con = new SqlConnection(@"server=" + server +
                        ";Database=" + database + ";Integrated Security=false;" +
                        "User ID=" + Username + "; Password=" + InvAcc.Properties.Settings.Default.SPassword + "");
                }
                else
                {
                    con = new SqlConnection(@"server=" + server +
                        ";Database=" + database + ";Integrated Security=true;");
                }
            }
            catch (SqlException sqlex)
            {
                System.Windows.Forms.MessageBox.Show("غير قادر على الإتصال بالسيرفر " + sqlex.Message, "خطا غير متوقع");
                return null;
            }
            return con;
        }
        List<SqlParameter> getPar(DataRow r)
        {
            List<SqlParameter> p = new List<SqlParameter>();
            for (int i = 1; i < r.ItemArray.Length; i++)
            {
                SqlParameter s;
                switch (i - 1)
                {
                    case 5:
                    case 6:
                    case 7:
                    case 33:
                    case 34:
                    case 49:
                    case 61:
                        s = new SqlParameter("@" + pa[i - 1], SqlDbType.Int);
                        try
                        {
                            if (i == 7)
                            {
                                s.Value = 0;
                            }
                            else
                                s.Value = int.Parse(r[i].ToString());
                        }
                        catch
                        {
                            s.Value = null;
                        }
                        p.Add(s);
                        break;
                    case 47:
                    case 48:
                    case 54:
                    case 55:
                    case 60:

                        s = new SqlParameter("@" + pa[i - 1], SqlDbType.Float);
                        try
                        {
                            s.Value = float.Parse(r[i].ToString());
                        }
                        catch
                        {
                            s.Value = null;
                        }
                        p.Add(s);
                        break;
                    case 53:
                        s = new SqlParameter("@" + pa[i - 1], SqlDbType.VarBinary);
                        try
                        {
                            s.Value = ImageToByteArray((Image)r["UsrImg"]);
                        }
                        catch
                        {
                            byte[] sa = new byte[1];
                            sa[0] = 1;
                            s.Value = sa;
                        }
                        p.Add(s);
                        break;
                    default:
                        s = new SqlParameter("@" + pa[i - 1], SqlDbType.VarChar);
                        try
                        {
                            s.Value = r[i].ToString();
                        }
                        catch
                        {
                            s.Value = null;
                        }
                        p.Add(s);
                        break;
                }

            }
            return p;
        }
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
        string[] pa;
        void updateusers(DataRow r, SqlConnection con)
        {
            string script = @"UPDATE [dbo].[T_Users]
   SET
      
      [UsrNamE] =  @c
      ,[Pass] = @d
    ,[UsrNamA] = @b
      ,[Sts] = @f
      ,[Typ] = @g
      ,[ProLng] =@h
      ,[FilStr] =@i
      ,[InvStr] = @j
      ,[SndStr] = @k
      ,[StkRep] =@l
      ,[AccRep] = @m
      ,[SetStr] = @n
      ,[EditCost] = @o
      ,[PassQty] = @p
      ,[RepInv1] = @q
      ,[RepInv2] = @r
      ,[RepInv3] = @s
      ,[RepInv4] = @t
      ,[RepInv5] = @u
      ,[RepInv6] = @v
      ,[RepAcc1] = @w
      ,[RepAcc2] = @x
      ,[RepAcc3] = @y
      ,[RepAcc4] = @z
      ,[RepAcc5] = @aa
      ,[RepAcc6] = @bb
      ,[Emp_FilStr] = @cc
      ,[Emp_MovStr] = @dd
      ,[Emp_SalStr] = @ee
      ,[Emp_RepStr] = @ff
      ,[Emp_GenStr] = @gg
      ,[CreateGaid] = @hh
      ,[UserPointTyp] = @ii
      ,[CashAccNo_D] = @jj
      ,[CashAccNo_C] = @kk
      ,[NetworkAccNo_D] = @ll
      ,[NetworkAccNo_C] = @mm
      ,[CreaditAccNo_D] = @nn
      ,[CreaditAccNo_C] = @oo
      ,[CashAccNo_D_R] = @pp
      ,[CashAccNo_C_R] = @qq
      ,[NetworkAccNo_D_R] = @rr
      ,[NetworkAccNo_C_R] = @ss
      ,[CreaditAccNo_D_R] = @tt
      ,[CreaditAccNo_C_R] = @uu
      ,[Comm_Inv] = @vv
      ,[Comm_Gaid] = @ww
      ,[PeaperTyp] = @xx
      ,[StorePrmission] = @yy
      ,[DefStores] = @zz
      ,[StopBanner] = @aaa
      ,[UsrImg] = @bbb
      ,[MaxDiscountSals] = @ccc
      ,[MaxDiscountPurchaes] = @ddd
      ,[vColumnStr1] = @eee
      ,[vColumnStr2] = @fff
      ,[vColumnStr3] = @ggg
      ,[vColumnStr4] = @hhh
      ,[vColumnNum1] = @iii
      ,[vColumnNum2] = @jjj
      ,[Eqar_FilStr] = @kkk
      ,[Eqar_TenantStr] = @lll
      ,[Eqar_RepStr] = @mmm
      ,[Eqar_GenStr] = @nnn
WHERE [UsrNo] = @a AND [Brn] = @e";
            SqlCommand cmd = new SqlCommand(script, con);
            List<SqlParameter> ps = getPar(r);
            foreach (SqlParameter i in ps) cmd.Parameters.Add(i);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        void insertUser(DataRow r, SqlConnection con)
        {
            string script = @"
INSERT INTO [T_Users]
           ([UsrNo]
           ,[UsrNamA]
           ,[UsrNamE]
           ,[Pass]
           ,[Brn]
           ,[Sts]
           ,[Typ]
           ,[ProLng]
           ,[FilStr]
           ,[InvStr]
           ,[SndStr]
           ,[StkRep]
           ,[AccRep]
           ,[SetStr]
           ,[EditCost]
           ,[PassQty]
           ,[RepInv1]
           ,[RepInv2]
           ,[RepInv3]
           ,[RepInv4]
           ,[RepInv5]
           ,[RepInv6]
           ,[RepAcc1]
           ,[RepAcc2]
           ,[RepAcc3]
           ,[RepAcc4]
           ,[RepAcc5]
           ,[RepAcc6]
           ,[Emp_FilStr]
           ,[Emp_MovStr]
           ,[Emp_SalStr]
           ,[Emp_RepStr]
           ,[Emp_GenStr]
           ,[CreateGaid]
           ,[UserPointTyp]
           ,[CashAccNo_D]
           ,[CashAccNo_C]
           ,[NetworkAccNo_D]
           ,[NetworkAccNo_C]
           ,[CreaditAccNo_D]
           ,[CreaditAccNo_C]
           ,[CashAccNo_D_R]
           ,[CashAccNo_C_R]
           ,[NetworkAccNo_D_R]
           ,[NetworkAccNo_C_R]
           ,[CreaditAccNo_D_R]
           ,[CreaditAccNo_C_R]
           ,[Comm_Inv]
           ,[Comm_Gaid]
           ,[PeaperTyp]
           ,[StorePrmission]
           ,[DefStores]
           ,[StopBanner]
          ,[UsrImg]
           ,[MaxDiscountSals]
           ,[MaxDiscountPurchaes]
           ,[vColumnStr1]
           ,[vColumnStr2]
           ,[vColumnStr3]
           ,[vColumnStr4]
           ,[vColumnNum1]
           ,[vColumnNum2]
           ,[Eqar_FilStr]
           ,[Eqar_TenantStr]
           ,[Eqar_RepStr]
           ,[Eqar_GenStr])
     VALUES
(@a,@b,@c,@d,@e,@f,@g,@h,@i,@j,@k,@l,@m,@n,@o,@p,@q,@r,@s,@t,@u,@v,@w,@x,@y,@z,@aa,@bb,@cc,@dd,@ee,@ff,@gg,@hh,@ii,@jj,@kk,@ll,@mm,@nn,@oo,@pp,@qq,@rr,@ss,@tt,@uu,@vv,@ww,@xx,@yy,@zz,@aaa,@bbb,@ccc,@ddd,@eee,@fff,@jjj,@hhh,@iii,@jjj,@kkk,@lll,@mmm,@nnn)";
            int no = GenerateID(con);
            r["UsrNo"] = no.ToString();
            List<SqlParameter> par = getPar(r);
            SqlCommand cmd = new SqlCommand(script, con);
            foreach (SqlParameter p in par)
                cmd.Parameters.Add(p);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public int GenerateID(SqlConnection con)
        {
            int X = 0;
            //     DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            string SCRIPT = @"SELECT ISNULL(MAX([UsrNo])+1,1)
                       FROM [T_Users]";
            DataTable Dt = new DataTable();
            SqlCommand cmd = new SqlCommand(SCRIPT, con);
            //  SqlCommand cmd = new SqlCommand(SCRIPT, con);
            con.Open();
            Dt.Load(cmd.ExecuteReader());
            //Dt = DAL.selectScript(SCRIPT, null);
            con.Close();
            if (Dt.Rows.Count <= 0)
            {
                X = 0;
                return X;
            }
            X = Convert.ToInt32(Dt.Rows[0][0]);
            if (X == 0)
            {
                X = 1;
            }
            return X;
        }
        void Res()
        {
            Process p = new Process();
            ProcessStartInfo psi = new ProcessStartInfo("netsh", "interface ip set address \"Local Area Connection\" static 192.168.0.10 255.255.255.0 192.168.0.1 1");
            p.StartInfo = psi;
            p.Start();
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
            SqlConnection sq = new SqlConnection("server=" + InvAcc.GeneralM.VarGeneral.gServerName + ";Database=PROSOFT_default_2;Integrated Security=false;User ID=sa; Password=Prosoft@prosoft&ma89;MultipleActiveResultSets=True");
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
                // cmd5.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                updateuserids(con, newid, oldid);
            }
        }
        void FixUSersIDs(DataTable t, String Branchno)
        {
            foreach (DataRow r in t.Rows)
            {
            }
        }
        int getnewid(DataRow r, SqlConnection con)
        {
            //string dbu = InvAcc.Properties.Settings.Default.DefaultUDatabaseName.ToString();
            //string sr = InvAcc.Properties.Settings.Default.ServerName.ToString();
            //string dbd = InvAcc.Properties.Settings.Default.DefaultDDatabaseName.ToString();
            //string pas = InvAcc.Properties.Settings.Default.SPassword.ToString();
            int brn = int.Parse(r["Brn"].ToString());
            //   dbd += "_" + brn.ToString();
            //  SqlConnection con = DataAccessLayer2(dbd, sr);
            string script = "Select *from T_USERS ; ";
            SqlCommand cmd = new SqlCommand(script, con);
            cmd.Parameters.Add(new SqlParameter("@b", SqlDbType.Int)).Value = int.Parse(r["Brn"].ToString());
            cmd.Parameters.Add(new SqlParameter("@a", SqlDbType.VarChar)).Value = "N'" + (r["UsrNamA"].ToString());
            //cmd.Parameters.Add(new SqlParameter("@e", SqlDbType.VarChar)).Value = (r["Pass"].ToString());
            //cmd.Parameters.Add(new SqlParameter("@p", SqlDbType.VarChar)).Value = (r["UsrNamE"].ToString());
            DataTable t = new DataTable();
            con.Open();
            t.Load(cmd.ExecuteReader());
            con.Close(); int id = 0;
            foreach (DataRow rr in t.Rows)
            {
                if (rr["Brn"].ToString() == r["Brn"].ToString())
                    if (rr["UsrNamA"].ToString() == r["UsrNamA"].ToString())
                        id = int.Parse(rr["UsrNo"].ToString());
            }
            return id;
        }
        public void updateMain(string BrancNo, string datadatabase)
        {

            SqlConnection con = DataAccessLayer2(InvAcc.Properties.Settings.Default.DefaultUDatabaseName, ServerName); ;
            string Database = InvAcc.Properties.Settings.Default.DefaultUDatabaseName;
            string tmDatatabase = "DB_temp";
            SqlConnection tmcon = DataAccessLayer2(tmDatatabase, ServerName);
            SqlCommand cmdMain = new SqlCommand("select *from T_Users;", con);
            SqlCommand cmdBran = new SqlCommand("select *from T_Users;", con);
            DataTable MainUsers = new DataTable();
            DataTable BranchUsers = new DataTable();
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                MainUsers.Load(cmdMain.ExecuteReader());
                con.ChangeDatabase(tmDatatabase);
                BranchUsers.Load(cmdBran.ExecuteReader());
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
            if (BranchUsers.Rows.Count > 0)
            {
                foreach (DataRow B in BranchUsers.Rows)
                {
                    if (B["UsrNo"].ToString() != "1")
                    {
                        string n = B["UsrNo"].ToString();
                        int brn = int.Parse(B["Brn"].ToString());
                        B["Brn"] = BrancNo;
                        if (B["UsrNamA"].ToString() == "الرئيسي")
                            B["UsrNamA"] = "الرئيسي" + " - " + BrancNo.ToString();
                        string sn = B["UsrNamA"].ToString();
                        string brns = BrancNo.ToString();
                        if (isexists(sn, brns, MainUsers))
                            updateusers(B, con);
                        else
                            insertUser(B, con);
                        int newID = getnewid(B, con);
                        int old = int.Parse(B["UsrNo"].ToString());
                        //   Merge(InvAcc.Properties.Settings.Default.DefaultDDatabaseName + "_" + BrancNo);
                        updateuserids(DataAccessLayer2(InvAcc.Properties.Settings.Default.DefaultDDatabaseName + BrancNo, InvAcc.Properties.Settings.Default.ServerName), newID.ToString(), old.ToString());
                    }
                }
                //FixUSersIDs(BranchUsers,BrancNo);
            }
        }
        void Merge(string da)
        {
            string text = File.ReadAllText(Application.StartupPath + "\\sqlMerge.txt");
            text = text.Replace("GO", "");
            text = text.Replace("TPL", da);
            text = text.Replace("pascal", InvAcc.Properties.Settings.Default.SUser);
            text = text.Replace("test", InvAcc.Properties.Settings.Default.SPassword);
            SqlConnection c = DataAccessLayer2("master", "PROSOFT");
            SqlCommand cmd = new SqlCommand(text, c);
            c.Open();
            cmd.ExecuteNonQuery();
            c.Close();
        }
        bool isexists(string name, string branchno, DataTable t)
        {
            foreach (DataRow r in t.Rows)
            {
                if (r["UsrNamA"].ToString() == name && branchno == r["Brn"].ToString())
                    return true;
            }
            return false;
        }
        void reso(string backupfilePath, string databaseName, string NameOfBranch)
        {
            string sa = backupfilePath;
            string ddb = databaseName;
            string ss = NameOfBranch;
            //      DataAccessLayer(ddb, ServerName);
            DatabaseManager mg = new DatabaseManager();
            mg.Connect(InvAcc.Properties.Settings.Default.SUser.ToString(), InvAcc.Properties.Settings.Default.SPassword.ToString(), ServerName, false);
            mg.RestoreDatabase(ddb, sa);
        }
        public void inserttest()
        {
            SqlConnection con = DataAccessLayer2(InvAcc.Properties.Settings.Default.DefaultUDatabaseName, ServerName); ;
            string Database = InvAcc.Properties.Settings.Default.DefaultUDatabaseName;
            string tmDatatabase = "DB_temp";
            SqlConnection tmcon = DataAccessLayer2(tmDatatabase, ServerName);
            SqlCommand cmdMain = new SqlCommand("select *from T_Users;", con);
            SqlCommand cmdBran = new SqlCommand("select *from T_Users;", tmcon);
            DataTable MainUsers = new DataTable();
            DataTable BranchUsers = new DataTable();
            con.Open();
            MainUsers.Load(cmdMain.ExecuteReader());
            con.Close();
            MainUsers.Rows[1]["UsrNamA"] = "Ebrahim";
            MainUsers.Rows[1]["UsrNo"] = 54;
            MainUsers.Rows[1]["Brn"] = 3;
            insertUser(MainUsers.Rows[1], con);
        }
        public void sync()
        {
            foreach (DataRow r in Brtbl.Rows)
            {
                if (r["Branch_no"].ToString() != "1")
                {
                    string ds = InvAcc.Properties.Settings.Default.DefaultDDatabaseName + r["Branch_no"].ToString();
                    string dss = "DB_temp";
                    string en = r["Branch_no"].ToString();
                    string ar = r["Branch_Name"].ToString();
                    string bp = BackPath + "\\" + en + "\\1.bak";
                    string bpp = BackPath + "\\" + en + "\\2.bak";
                    if (File.Exists(bp))
                        reso(bp, ds, ar);
                    if (File.Exists(bpp))
                    {
                        reso(bpp, dss, ar);
                        updateMain(en, ds);
                    }
                }
            }
        }
        public void backup()
        {

            DatabaseManager m = new DatabaseManager();
            m.Connect(InvAcc.Properties.Settings.Default.SUser, InvAcc.Properties.Settings.Default.SPassword, InvAcc.Properties.Settings.Default.ServerName, false);
            string s = DropBoxSyncronization.getbno();
            if (s != "-1")
            {
                if (!Directory.Exists(BackPath + "\\" + s))
                {
                    Directory.CreateDirectory(BackPath + "\\" + s);
                }
                string[] files = Directory.GetFiles(BackPath + "\\" + s);
                foreach (string sa in files)
                    File.Delete(sa);
                m.BackupDatabase(InvAcc.Properties.Settings.Default.DefaultUDatabaseName, BackPath + "\\" + s + "\\2.bak");
                m.BackupDatabase(InvAcc.Properties.Settings.Default.DefaultDDatabaseName + "1", BackPath + "\\" + s + "\\1.bak");
            }
            else
            {

                //MessageBox.Show("لا يمكن اتمام عملية المزامنة الرجاء ضبط رقم الفرع او الاتصال بالدعم الفني");
                //Application.ExitThread();
            }
        }
        public static string getdropbox()
        {
            try
            {
                string appDataPath = Environment.GetFolderPath(
                                  Environment.SpecialFolder.ApplicationData);
                appDataPath = appDataPath.Replace("Roaming", "Local");
                string dbPath = System.IO.Path.Combine(appDataPath, "Dropbox\\host.db");
                string[] lines = System.IO.File.ReadAllLines(dbPath);
                byte[] dbBase64Text = Convert.FromBase64String(lines[1]);
                return System.Text.ASCIIEncoding.ASCII.GetString(dbBase64Text);
            }
            catch
            { return "NA"; }
        }
        void setbackpaths()
        {
            try
            {
                appDataPath = Environment.GetFolderPath(
                                Environment.SpecialFolder.ApplicationData);
                appDataPath = appDataPath.Replace("Roaming", "Local");
                dbPath = System.IO.Path.Combine(appDataPath, "Dropbox\\host.db");
                lines = System.IO.File.ReadAllLines(dbPath);
                dbBase64Text = Convert.FromBase64String(lines[1]);
                BackPath = System.Text.ASCIIEncoding.ASCII.GetString(dbBase64Text);
            }
            catch
            { //MessageBox.Show(" الرجاء التاكد من تثبيت برنامج الدروب بوكس ");Application.ExitThread(); 
            }
        }
        public static void setdropactivation(string no)
        {
            RegistryKey hKeyNeew1 = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", writable: true);
            try
            {
                object q = hKeyNeew1.GetValue("vDropBoxActivation");
                if (string.IsNullOrEmpty(q.ToString()))
                {
                    hKeyNeew1.CreateSubKey("vDropBoxActivation");
                    hKeyNeew1.SetValue("vDropBoxActivation", no);
                }
                else
                {
                    hKeyNeew1.SetValue("vDropBoxActivation", no);
                }
            }
            catch
            {
                hKeyNeew1.CreateSubKey("vDropBoxActivation");
                hKeyNeew1.SetValue("vDropBoxActivation", no);
            }
        }
        public static string getdropnoactivation()
        {
            RegistryKey hKeyNeew1 = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", writable: true);
            string bno = "";
            try
            {
                object q = hKeyNeew1.GetValue("vDropBoxActivation");
                bno = q.ToString();
            }
            catch
            {
                return "NA";
            }
            return bno;
        }
        public static void setbranchno(string no)
        {
            RegistryKey hKeyNeew1 = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", writable: true);
            try
            {
                object q = hKeyNeew1.GetValue("vBranchNo");
                if (string.IsNullOrEmpty(q.ToString()))
                {
                    hKeyNeew1.CreateSubKey("vBranchNo");
                    hKeyNeew1.SetValue("vBranchNo", no);
                }
                else
                {
                    hKeyNeew1.SetValue("vBranchNo", no);
                }
            }
            catch
            {
                hKeyNeew1.CreateSubKey("vBranchNo");
                hKeyNeew1.SetValue("vBranchNo", no);
            }
        }
        public static string getbno()
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
                hKeyNeew1.CreateSubKey("vBranchNo");
                hKeyNeew1.SetValue("vBranchNo", -1);
                return (-1).ToString();
            }
            return bno;
        }
        public void setcaller(Frm_Main f)
        { caller = f; }
        public static string bnotest()
        {
            return "NA";
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
        public static void CompressFile(string path)
        {
            FileStream sourceFile = File.OpenRead(path);
            FileStream destinationFile = File.Create(path + ".gz");
            byte[] buffer = new byte[sourceFile.Length];
            sourceFile.Read(buffer, 0, buffer.Length);
            using (GZipStream output = new GZipStream(destinationFile,
                CompressionMode.Compress))
            {
                Console.WriteLine("Compressing {0} to {1}.", sourceFile.Name,
                    destinationFile.Name, false);
                output.Write(buffer, 0, buffer.Length);
            }
            // Close the files.
            sourceFile.Close();
            destinationFile.Close();
        }
        public void syncAll()
        {
            for (int i = 1; i <= dropsyninfo.table.Rows.Count; i++)
            {
                syncBranch(i);
                for (int j = 0; j < 1444; j++) ;
            }
        }
        public int getnumberofbranches()
        {
            return dropsyninfo.table.Rows.Count;
        }
        public void syncBranch(int rowSel)
        {
            if (rowSel - 1 >= 0 && rowSel - 1 < dropsyninfo.table.Rows.Count)
            {
                backdata f = dropsyninfo.get(dropsyninfo.table.Rows[rowSel - 1]["BrA"].ToString());
                // dropsyninfo.table.Rows[rowSel]["BrE"].ToString();
                string ds = InvAcc.Properties.Settings.Default.DefaultDDatabaseName + f.BrancheNo.ToString();
                string dss = "DB_temp";
                string en = f.BrancheNo.ToString();
                string ar = f.branchA;
                string bp = f.dataPath;
                string bpp = f.UsersPath;
                if (File.Exists(bp))
                { reso(bp, ds, ar); Alert fd = new Alert("تم مزامنة فرع : " + f.branchA + "  بنجاح"); fd.TopMost = true; ; fd.Show(); }
                if (File.Exists(bpp))
                {
                    reso(bpp, dss, ar);
                    updateMain(en, ds);
                }

            }
        }
        Frm_Main caller;
    }
}
