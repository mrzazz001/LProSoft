using InvAcc.Forms;
using ProShared.Stock_Data;
using Microsoft.Win32;
using ShamelSynch;
using SqlDbCloner.Core.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ProShared.Forms;

namespace InvAcc
{
    public partial  class megration : Form
    {
        public megration()
        {
            InitializeComponent();
        }
        List<string> gettables(SqlConnection con)
        {
            List<string> v = new List<string>();
            con.Open();
            DataTable t = con.GetSchema("Tables");
            foreach (DataRow r in t.Rows)
            {
                v.Add(r[2].ToString());
            }
            con.Close();
            return v;
        }
#pragma warning disable CS0414 // The field 'megration.dbname' is assigned but its value is never used
        string dbname = "[PROSOFT_default_1]";
#pragma warning restore CS0414 // The field 'megration.dbname' is assigned but its value is never used
        string servername = ".\\APPSOFT";
#pragma warning restore CS0414 // The field 'megration.servername' is assigned but its value is never used
        string dbname2 = "[APPSOFT_default_1]";
        void transfer(string tname, SqlConnection con1, SqlConnection con2)
        {
            DataTable t = new DataTable();
            SqlBulkCopy bulkCopy = new SqlBulkCopy(con2);
            //try
            //{
            string txt = "select * From " + tname + ";";
            if (con1.State == ConnectionState.Closed) con1.Open()
                    ;
            SqlCommand c = new SqlCommand(txt, con1);
            t.Load(c.ExecuteReader());
            con1.Close();
            string txt1 = "  SET IDENTITY_INSERT " + tname + " ON";
            SqlCommand cc = new SqlCommand(txt1, con2);

            if (con2.State == ConnectionState.Closed) con2.Open();
            try
            {
                cc.ExecuteNonQuery();
            }
            catch
            { }
            con2.Close();
            //   if (con2.State == ConnectionState.Closed) con2.Open();
            if (tname.ToLower().Contains("invhed"))
            {
                string cmd = @"IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_INVHED]') AND type in (N'U'))
DROP TABLE [dbo].[T_INVHED]";
                con2.Open();
                SqlCommand cc1 = new SqlCommand(cmd, con2);
                cc1.ExecuteNonQuery();
                string cmc = @"CREATE TABLE [dbo].[T_INVHED](
	[InvHed_ID] [int]  NOT NULL,
	[InvId] [float] NULL,
	[InvNo] [varchar](10) NULL,
	[InvTyp] [int] NULL,
	[InvCashPay] [int] NULL,
	[CusVenNo] [varchar](20) NULL,
	[CusVenNm] [varchar](50) NULL,
	[CusVenAdd] [varchar](100) NULL,
	[CusVenTel] [varchar](30) NULL,
	[Remark] [varchar](max) NULL,
	[HDat] [varchar](10) NULL,
	[GDat] [varchar](10) NULL,
	[MndNo] [int] NULL,
	[SalsManNo] [varchar](3) NULL,
	[SalsManNam] [varchar](50) NULL,
	[InvTot] [float] NULL,
	[InvTotLocCur] [float] NULL,
	[InvDisPrs] [float] NULL,
	[InvDisVal] [float] NULL,
	[InvDisValLocCur] [float] NULL,
	[InvNet] [float] NULL,
	[InvNetLocCur] [float] NULL,
	[CashPay] [float] NULL,
	[CashPayLocCur] [float] NULL,
	[IfRet] [int] NULL,
	[GadeNo] [float] NULL,
	[GadeId] [float] NULL,
	[IfDel] [int] NULL,
	[RetNo] [varchar](10) NULL,
	[RetId] [float] NULL,
	[InvCstNo] [int] NULL,
	[InvCashPayNm] [varchar](100) NULL,
	[RefNo] [varchar](20) NULL,
	[InvCost] [float] NULL,
	[EstDat] [varchar](10) NULL,
	[CustPri] [int] NULL,
	[ArbTaf] [varchar](150) NULL,
	[CurTyp] [int] NULL,
	[InvCash] [varchar](20) NULL,
	[ToStore] [varchar](3) NULL,
	[ToStoreNm] [varchar](50) NULL,
	[InvQty] [float] NULL,
	[EngTaf] [varchar](150) NULL,
	[IfTrans] [int] NULL,
	[CustRep] [float] NULL,
	[CustNet] [float] NULL,
	[InvWight_T] [float] NULL,
	[IfPrint] [int] NULL,
	[LTim] [varchar](10) NULL,
	[CREATED_BY] [varchar](100) NULL,
	[DATE_CREATED] [datetime] NULL,
	[MODIFIED_BY] [varchar](100) NULL,
	[DATE_MODIFIED] [datetime] NULL,
	[CreditPay] [float] NULL,
	[CreditPayLocCur] [float] NULL,
	[NetworkPay] [float] NULL,
	[NetworkPayLocCur] [float] NULL,
	[CommMnd_Inv] [float] NULL,
	[MndExtrnal] [bit] NULL,
	[CompanyID] [int] NULL,
	[InvAddCost] [float] NULL,
	[InvAddCostLoc] [float] NULL,
	[InvAddCostExtrnal] [float] NULL,
	[InvAddCostExtrnalLoc] [float] NULL,
	[IsExtrnalGaid] [bit] NULL,
	[ExtrnalCostGaidID] [float] NULL,
	[Puyaid] [float] NULL,
	[Remming] [float] NULL,
	[RoomNo] [int] NULL,
	[OrderTyp] [int] NULL,
	[RoomSts] [bit] NULL,
	[chauffeurNo] [int] NULL,
	[RoomPerson] [int] NULL,
	[ServiceValue] [float] NULL,
	[Sts] [bit] NULL,
	[PaymentOrderTyp] [int] NULL,
	[AdminLock] [bit] NULL,
	[DeleteDate] [varchar](10) NULL,
	[DeleteTime] [varchar](10) NULL,
	[UserNew] [varchar](3) NULL,
	[IfEnter] [int] NULL,
	[InvAddTax] [float] NULL,
	[InvAddTaxlLoc] [float] NULL,
	[IsTaxGaid] [bit] NULL,
	[TaxGaidID] [float] NULL,
	[IsTaxUse] [bit] NULL,
	[InvValGaidDis] [float] NULL,
	[InvValGaidDislLoc] [float] NULL,
	[IsDisGaid] [bit] NULL,
	[DisGaidID1] [float] NULL,
	[IsDisUse1] [bit] NULL,
	[InvComm] [float] NULL,
	[InvCommLoc] [float] NULL,
	[IsCommGaid] [bit] NULL,
	[CommGaidID] [float] NULL,
	[IsCommUse] [bit] NULL,
	[IsTaxLines] [bit] NULL,
	[IsTaxByTotal] [bit] NULL,
	[IsTaxByNet] [bit] NULL,
	[TaxByNetValue] [float] NULL,
	[DesPointsValue] [float] NULL,
	[DesPointsValueLocCur] [float] NULL,
	[PointsCount] [float] NULL,
	[IsPoints] [bit] NULL,
	[tailor1] [varchar](100) NULL,
	[tailor2] [varchar](100) NULL,
	[tailor3] [varchar](100) NULL,
	[tailor4] [varchar](100) NULL,
	[tailor5] [varchar](100) NULL,
	[tailor6] [varchar](100) NULL,
	[tailor7] [varchar](100) NULL,
	[tailor8] [varchar](100) NULL,
	[tailor9] [varchar](100) NULL,
	[tailor10] [varchar](100) NULL,
	[tailor11] [varchar](100) NULL,
	[tailor12] [varchar](100) NULL,
	[tailor13] [varchar](100) NULL,
	[tailor14] [varchar](100) NULL,
	[tailor15] [varchar](100) NULL,
	[tailor16] [varchar](100) NULL,
	[tailor17] [varchar](100) NULL,
	[tailor18] [varchar](100) NULL,
	[tailor19] [varchar](100) NULL,
	[tailor20] [varchar](100) NULL,
	[InvImg] [varbinary](max) NULL
);
";
                cc1 = new SqlCommand(cmc, con2);
                cc1.ExecuteNonQuery();
                bulkCopy.DestinationTableName = tname;
                foreach (DataColumn fs in t.Columns)
                {
                    bulkCopy.ColumnMappings.Add(fs.ColumnName, fs.ColumnName);
                }

                bulkCopy.WriteToServer(t);
                con2.Close();
            }
            coln = new List<string>();



        }
        string insertpar(DataRow r, string ts)
        {
            string s = " Insert INTO " + ts + "  ( ";
            string id = string.Empty; int i = 0;
            string values = "VALUES ( ";
            foreach (string c in coln)
            {
                if (r[c].ToString() != string.Empty)
                {
                    if (i == 0)
                    {
                        s += c;
                        values += "'" + r[c].ToString() + "' ";
                        i = 2;
                    }
                    else
                    {
                        s += " , " + c;
                        r[c] = r[c].ToString().Replace("'", "''");
                        values += ", '" + r[c].ToString() + "' ";
                        i = 2;
                    }
                }

            }
            return s + ") " + values + ") ;";
        }
        string getpar(DataRow r, string ts)
        {
            string s = " SET ";
            string id = string.Empty; int i = 0;
            foreach (string c in coln)
            {
                if (c.ToLower().Contains(ts.ToLower()) && c.Contains("ID"))
                {
                    id = c;
                }
                else
                {
                    if (r[c].ToString() != string.Empty)
                    {
                        if (i == 0)
                            s += " " + c + " ='" + r[c].ToString() + "' ";
                        else
                            s += " , " + c + " ='" + r[c].ToString() + "' ";
                        i = 2;
                    }
                }
            }
            if (ts == "INVDERepair") id = "InvDet_ID_Repair";
            s += " where " + id + " ='" + r[id] + "' ;";
            return s;
        }
        List<string> coln;
        void del(string cmd, SqlConnection con)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            SqlCommand c = new SqlCommand(cmd, con);
            c.ExecuteNonQuery();
            con.Close();
        }
#pragma warning disable CS0169 // The field 'megration.Transfer' is never used
        DataTransfer Transfer;
#pragma warning disable CS0414 // The field 'megration.servername' is assigned but its value is never used
#pragma warning restore CS0169 // The field 'megration.Transfer' is never used
        void copydatabase(string appcon, string procon)
        {
            SqlConnection con1 = new SqlConnection(appcon);
            SqlConnection con2 = new SqlConnection(procon);
            //if (!appcon.Contains("DBAPPSOFT_default"))
            //{
            //  //  del("EXEC sp_MSForEachTable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL' ", con2);
            //    //try
            //    //{
            //    //    del("Delete From T_unit;", con2);
            //    //}
            //    //catch { con2.Close(); del("Delete From T_Items;", con2); del("Delete From T_unit;", con2); }
            //    //del("Delete From T_Rom;", con2);
            //    //del("Delete From T_CstTbl;", con2);
            //    //del("Delete From T_INVSETTING;", con2);
            //    //del("Delete From T_Items;", con2);
            //    //del("Delete From T_CATEGORY;", con2);
            //    //del("Delete From T_Curency;", con2);
            //    //del("Delete From T_Mndob;", con2); del("Delete From T_sertyp;", con2);
            //    //del("Delete From T_AccDef;", con2); del("Delete From T_AccCat;", con2);
            //    //del("Delete From T_Store;", con2);
            //}
            //else {  del("Delete From T_Branch;", con2); del("Delete From T_Users;", con2); }
            del("EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL' ", con2);
            del("EXEC sp_MSForEachTable 'DELETE FROM ?' ", con2);
            try { del("EXEC sp_MSForEachTable 'DBCC CHECKIDENT(''?'', RESEED, 0)'", con2); }
            catch { };
            del("EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL' ", con2);
            //  Transfer = new DataTransfer(appcon, procon);
            //  del("  EXEC sp_addlinkedsrvlogin '.\\APPSOFT', 'false', null, 'sa', 'appsoftvip'", con2);
            List<string> tables = gettables(con1);
            foreach (string s in tables)
            {
                string cm = "select * from " + s;// + " WITH(NOLOCK)";
                transfer(s, con1, con2);
            }
        }
        string appcons = @"data source=.\appsoft;Integrated Security=false;user id=sa;password=appsoftvip;";
        string procons = Properties.Settings.Default.PROSOFT_default_1ConnectionStringh;
        DataTable ts = new DataTable();
        private void megration_Load(object sender, EventArgs e)
        {
            DatabaseManager DB = new DatabaseManager();
            DB.Connect("sa", "appsoftvip", @".\appsoft", false);
            //  DB.BackupDatabase("DBAPPSOFT_default", Application.StartupPath+@"\user2.bak");
            //       del()

            string tsw = "Select name from master.dbo.sysdatabases where dbid > 4;";
            SqlConnection c = new SqlConnection(appcons + "database=APPSOFT_default_1;");
            c.Open();
            ts.Load(new SqlCommand(tsw, c).ExecuteReader());
            c.Close();
            for (int i = 0; i < ts.Rows.Count; i++)
            {
                if (ts.Rows[i]["name"].ToString() == "DB_temp")
                { ts.Rows.RemoveAt(i); break; }
            }
            comboBox1.DataSource = ts;
            comboBox1.DisplayMember = "name";

        }
        int copiedcount = 0;
        void copydatabase2(string con1, string con2, string sdb, string ddb)
        {
            DatabaseManager dbs = new DatabaseManager();
            dbs.Connect("sa", "appsoftvip", ".\\APPSOFT", false);
            //db.Rename(sdb,ddb);
            dbs.Connect("sa", "Prosoft@prosoft&ma89", ".\\PROSOFT", false);
            dbs.testwithcreate(ddb, con2);
            dbs.Disconnect();
            dbs.Connect("sa", "appsoftvip", ".\\APPSOFT", false);
            string path =
              Application.StartupPath + "\\db1.bak";
            if (File.Exists(path))
                File.Delete(path);
            dbs.BackupDatabase(sdb, path);
            //db.Disconnect();
            //db.Connect("sa", "Prosoft@prosoft&ma89", ".\\PROSOFT", false);
            //db.RestoreDatabase(ddb, path);
            //db.Disconnect();
            con2 = con2.Replace(dbname2, "master");
            Stock_DataDataContext db = new Stock_DataDataContext(con2);
            try
            {
                List<int> vRec1 = new List<int>();
                int _LoopMain = 0;
                while (true)
                {
                    try
                    {
                        if (_LoopMain <= 5)
                        {
                            vRec1 = db.ExecuteQuery<int>("SELECT database_id FROM sys.databases WHERE name='" + ddb + "'", new object[0]).ToList();
                        }
                    }
                    catch
                    {
                        _LoopMain++;
                        continue;
                    }
                    break;
                }
                int vID = 0; string vMDF_File = string.Empty, vLDB_File = string.Empty;
                if (vRec1.Count > 0)
                {
                    vID = vRec1.First();
                    if (vID > 0)
                    {
                        List<string> vRecPath = db.ExecuteQuery<string>("SELECT physical_name FROM sys.master_files WHERE type = 0 and database_id=" + vID, new object[0]).ToList();
                        if (vRecPath.Count > 0)
                        {
                            vMDF_File = vRecPath.First().ToString();
                        }
                        vRecPath = db.ExecuteQuery<string>("SELECT physical_name FROM sys.master_files WHERE type = 1 and database_id=" + vID, new object[0]).ToList();
                        if (vRecPath.Count > 0)
                        {
                            vLDB_File = vRecPath.First().ToString();
                        }
                    }
                    string vFile1 = path, vLogicalName = string.Empty, vLogicalNameLog = string.Empty;
                    List<string> vRecPath2 = db.ExecuteQuery<string>("RESTORE FILELISTONLY FROM DISK = '" + vFile1 + "'", new object[0]).ToList();
                    if (vRecPath2.Count > 0)
                    {
                        vLogicalName = vRecPath2[0];
                        vLogicalNameLog = vRecPath2[1];
                    }
                    string vWITH = string.Empty;
                    vWITH = " Move '" + vLogicalName + "' TO '" + vMDF_File + "',Move '" + vLogicalNameLog + "' TO '" + vLDB_File + "'";
                    vWITH += ",REPLACE";
                    using (Stock_DataDataContext dbx = new Stock_DataDataContext(con2 + ";Connect Timeout=120"))
                    {
                        //  dbx.ExecuteCommand("USE [master] ALTER DATABASE [" + ddb + "] SET SET MULTI_USER WITH Rollback IMMEDIATE ");
                        int _LoopDBc = 0;
                        while (true)
                        {
                            try
                            {
                                if (_LoopDBc <= 5)
                                {
                                    dbx.CommandTimeout = (int)t1.Value;
                                    dbx.ExecuteCommand("USE [master] ALTER DATABASE [" + ddb + "] SET SINGLE_USER WITH Rollback IMMEDIATE ");
                                    Thread.Sleep((int)t2.Value);
                                    dbx.ExecuteCommand("USE [master] RESTORE DATABASE [" + ddb + "] FROM DISK = '" + vFile1 + "' WITH FILE = 1, " + vWITH);
                                    Thread.Sleep((int)t3.Value);
                                    dbx.ExecuteCommand("USE [master] ALTER DATABASE [" + ddb + "] SET MULTI_USER");
                                    MessageBox.Show("تم نسخ البيانات " + ddb + "الى البروسوفت بنجاح ");
                                }
                            }
                            catch (SqlException ex)
                            {
                                dbx.ExecuteCommand("USE [master] ALTER DATABASE [" + ddb + "] SET MULTI_USER");
                                //  dbx.ExecuteCommand("USE [master] ALTER DATABASE [" + ddb + "] SET SINGLE_USER WITH Rollback IMMEDIATE ");
                                MessageBox.Show(ex.Message);
                                _LoopDBc++;
                                continue;
                            }
                            break;
                        }
                    }
                }
            }
            catch (SqlException ex) { MessageBox.Show(ex.Message); }
            if (File.Exists(path))
                File.Delete(path);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                if (comboBox1.Items.Count > 0)
                {
                    string db = comboBox1.Text + ";";
                    string db2 = db.Replace("APPSOFT", "PROSOFT");
                    string db23 = procons.Replace("PROSOFT_default_1", db2);
                    db = "database=" + db;
                    SqlConnection cs = new SqlConnection(db23)
    ;
                    try
                    {
                        cs.Open();
                    }
                    catch
                    {
                        //          MessageBox.Show("قاعدة البيانات المطلوب نسخها غير متوفره في البروسوفت سيرفر" + "  " + db2);
                        //            return;
                    }
                    copydatabase2(appcons + db, db23, comboBox1.Text, comboBox1.Text.Replace("APPSOFT", "PROSOFT"));
                    int i = comboBox1.SelectedIndex; comboBox1.DataSource = null;
                    ts.Rows.RemoveAt(i);
                    copiedcount++;
                    label_Balance.Text = copiedcount.ToString();
                    comboBox1.DataSource = ts;
                    comboBox1.DisplayMember = "name";
                }
                else
                { MessageBox.Show("لا يوجد قواعد بيانات اخرى في الاب سوفت سرفر لنسخها"); }
            }
            else
            {
                int j = comboBox1.Items.Count - 1;
                if (j > 0)
                {
                    while (comboBox1.Items.Count != 0)
                    {
                        comboBox1.SelectedIndex = j;
                        j--;
                        comboBox1_SelectedIndexChanged(null, null);
                        string db = comboBox1.Text + ";";
                        string db2 = db.Replace("APPSOFT", "PROSOFT");
                        string db23 = procons.Replace("PROSOFT_default_1", db2);
                        db = "database=" + db;
                        SqlConnection cs = new SqlConnection(db23)
        ;
                        try
                        {
                            cs.Open();
                        }
                        catch
                        {
                            MessageBox.Show("قاعدة البيانات المطلوب نسخها غير متوفره في البروسوفت سيرفر" + "  " + db2);
                            return;
                        }
                        copydatabase(appcons + db, db23);
                        int i = comboBox1.SelectedIndex; comboBox1.DataSource = null;
                        ts.Rows.RemoveAt(i);
                        copiedcount++;
                        label_Balance.Text = copiedcount.ToString();
                        comboBox1.DataSource = ts;
                        comboBox1.DisplayMember = "name";
                    }
                }
                else
                { MessageBox.Show("لا يوجد قواعد بيانات اخرى في الاب سوفت سرفر لنسخها"); }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) comboBox1.Enabled = false;
            else
                comboBox1.Enabled = true;
        }
        private void buttonX_Close_Click(object sender, EventArgs e)
        {
            string arguments = string.Empty;
            string[] args = Environment.GetCommandLineArgs();
            for (int i = 1; i < args.Length; i++)
            {
                arguments = arguments + args[i] + " ";
            }
            Application.ExitThread();
            Process.Start(Application.ExecutablePath, arguments);
        }
        private void groupPanel2_Click(object sender, EventArgs e)
        {
        }

        private void reg_copy(object sender, EventArgs e)
        {
            RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\VB and VBA Program Settings\\SmartSoft\\Register", writable: true);
            string regnu = string.Empty, serial = string.Empty;
            try
            {
                regnu = hKey.GetValue("SSSActivationNo").ToString();
                serial = hKey.GetValue("vSr").ToString();
            }
            catch
            {

            }
            if (regnu != string.Empty && serial != string.Empty)
            {
                FrmReg f = new FrmReg();
                f.copyreg(regnu, serial);
            }
        }

        private void megration_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ProShared. DBUdate.DbUpdates.periodicupdate();
        }
    }
}
