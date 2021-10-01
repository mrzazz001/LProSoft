using DevComponents.DotNetBar.Controls;
using ProShared.DBUdate;
using InvAcc.Forms;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace InvAcc.Controls
{
    public partial class EXPanel : UserControl
    {
        public EXPanel()
        {
            InitializeComponent();

            addcolumns();


            DonView.CellContentClick += ClickDonview;
            DonView.RowEnter += DonView_RowEnter;
            UndeExeCView.CellContentClick += ClickUnderExecution;
            UndeExeCView.RowEnter += DonView_RowEnter;
            if (VarGeneral.UserLang == 1)
            {
                label1.Text = "Orders that not done yet";
                label2.Text = "Orders that  done ";

                notdoneorders = notdoneorders.Replace("'اسم العميل'", "'Name Of Customer'").Replace("'هاتف العميل'", "'Customer Phone'")
                    .Replace("'جوال العميل'", "'Customer Mobile'").Replace("'ماركة السيارة'", "'Car Brand'").Replace("'اسم السيارة '", "'Car Name'")
                    .Replace("'رقم لوحة السيارة'", "'Car Plate No'").Replace("' لون السيارة'", "'Car Color'" +
string.Empty).Replace("' موديل السيارة'", "'Car Model'").Replace("' تاريخ التسليم'", "'Date of Delevery'")
  ;
                donorders = donorders.Replace("'اسم العميل'", "'Name Of Customer'").Replace("'هاتف العميل'", "'Customer Phone'")
                    .Replace("'جوال العميل'", "'Customer Mobile'").Replace("'ماركة السيارة'", "'Car Brand'").Replace("'اسم السيارة '", "'Car Name'")
                    .Replace("'رقم لوحة السيارة'", "'Car Plate No'").Replace("' لون السيارة'", "'Car Color'" +
string.Empty).Replace("' موديل السيارة'", "'Car Model'").Replace("' تاريخ التسليم'", "'Date of Delevery'")
  ;
            }
            CheckForIllegalCrossThreadCalls = false;


        }
        void 
            addcolumns()
        {


            DataGridViewButtonColumn bs = new DataGridViewButtonColumn();
            bs.Name = "op2"; bs.Text = (VarGeneral.UserLang == 0 ? "فتح الطلب" : "Open Order: ");
            DataGridViewButtonColumn bss = new DataGridViewButtonColumn();
            bss.Name = "ch1"; bs.UseColumnTextForButtonValue = true;
            bss.UseColumnTextForButtonValue = true;
            bss.Text = (VarGeneral.UserLang == 0 ? "تحويل الى تحت التنفيذ" : "Change  Order  TO Under Execution : "); ; ;
            bss.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            bs.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            bs.HeaderText = (VarGeneral.UserLang == 0 ? "فتح الطلب" : "Open Order: ");
            bss.HeaderText = (VarGeneral.UserLang == 0 ? "تغيير حالة الطلب" : "Change  Order  Status : "); ;
            UndeExeCView.Columns.Add(bs);
            DataGridViewButtonColumn bsass = new DataGridViewButtonColumn();
            bsass.Name = "ch2";
            bsass.Text = (VarGeneral.UserLang == 0 ? "تحويل الى تم التنفيذ" : "Change  Order  TO Done : "); ; ;
            bsass.UseColumnTextForButtonValue = true;
            bsass.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            bsass.HeaderText = (VarGeneral.UserLang == 0 ? "تغيير حالة الطلب" : "Change  Order  Status : "); ;
            UndeExeCView.Columns.Add(bsass);
            DataGridViewButtonColumn bsas = new DataGridViewButtonColumn();
            bsas.Name = "op1";
            bsas.Text = (VarGeneral.UserLang == 0 ? "فتح الطلب" : "Open Order: ");
            bsas.HeaderText = bsas.Text;
            bsas.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            bsas.UseColumnTextForButtonValue = true;
            DonView.Columns.Add(bsas);
            DonView.Columns.Add(bss);
            DonView.Columns.Add(getbuton("Print", VarGeneral.UserLang == 0 ? "طباعة" : "Print"));
            UndeExeCView.Columns.Add(getbuton("Print1", VarGeneral.UserLang == 0 ? "طباعة" : "Print"));

        }

        DataGridViewButtonColumn getbuton(string name, string header)
        {
            DataGridViewButtonColumn bsas = new DataGridViewButtonColumn();
            bsas.Name = name;
            bsas.Text = header;
            bsas.UseColumnTextForButtonValue = true;
            bsas.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            return bsas;
        }
        string donorders = @"SELECT  [INVHED_ID] as id,
[InvNo]       
      ,[CusVenNm] as 'اسم العميل'
  --    ,[CusVenTel] as 'هاتف العميل'
      ,[CusVenMob] as 'جوال العميل'
      ,[Car_TypeNameA] as 'ماركة السيارة'
      ,[Car_NameA] as 'اسم السيارة '
  
      ,[PlateNo] as 'رقم لوحة السيارة'
      ,[Color] as ' لون السيارة'
    --  ,[ModelNo] as ' موديل السيارة'
      ,[Delevery_Date] as ' تاريخ التسليم'
      ,[OrderStatus]
  FROM [T_INVHED]
  where InvTyp=7 AND [OrderStatus]=1;";

        string notdoneorders = @"SELECT [INVHED_ID] as id, 
[InvNo]     
      ,[CusVenNm] as 'اسم العميل'
  --    ,[CusVenTel] as 'هاتف العميل'
      ,[CusVenMob] as 'جوال العميل'
      ,[Car_TypeNameA] as 'ماركة السيارة'
      ,[Car_NameA] as 'اسم السيارة '
  
      ,[PlateNo] as 'رقم لوحة السيارة'
      ,[Color] as ' لون السيارة'
    --  ,[ModelNo] as ' موديل السيارة'
      ,[Delevery_Date] as ' تاريخ التسليم'
      ,[OrderStatus]
  FROM [T_INVHED]
  where InvTyp=7 AND [OrderStatus]=0";

        DataTable tnotdoneorders = new DataTable();
        Stock_DataDataContext db;
        public void updategrid()
        {
            updategride();
            if (VarGeneral.UserLang == 1)
            {

            }
            //List<T_INVHED> orders = db.StockInvHeadlist(7);
            //foreach(T_INVHED i in orders)
            //{
            //    datagried c = new datagried();
            //    c.setdata(i);
            //    c.Dock = DockStyle.Top;
            //    this.Controls.Add(c);
            //}
        }
        DataTable tdoneorders;
        public void shopanel(string id ,int s)
        {
        }
        string getcategories(string id, int i)
        {
            if (db == null) db = new Stock_DataDataContext(VarGeneral.BranchCS);
           // shopanel(id,i);
           
            string s = string.Empty;
            try
            {
                T_INVHED f = db.StockInvHeadbyid(7, id, i);
                List<T_INVDET> det = f.T_INVDETs.ToList<T_INVDET>();
                List<string> ss = new List<string>();
                foreach (T_INVDET t in det)
                {

                    string s1 = t.T_Item.T_CATEGORY.Arb_Des.ToString();
                    if (!ss.Contains(s1)) ss.Add(s1);
                }
                foreach (string sf in ss)
                {
                    if (s == string.Empty) s = sf;
                    else
                        s += " - " + sf;
                }
            }
#pragma warning disable CS0168 // The variable 'e' is declared but never used
            catch (Exception e)
#pragma warning restore CS0168 // The variable 'e' is declared but never used
            { }
            return
                s;

        }
        private void updategride()
        {

            SqlConnection con = new SqlConnection(VarGeneral.BranchCS);
            tnotdoneorders = new DataTable();
            tdoneorders = new DataTable();

            SqlCommand cmd = new SqlCommand(notdoneorders, con);

            SqlCommand cmd2 = new SqlCommand(donorders, con);

            con.Open();
            tnotdoneorders.Load(cmd.ExecuteReader());
            tdoneorders.Load(cmd2.ExecuteReader());

            con.Close();
            if (tnotdoneorders.Rows.Count > 0)
            {

                DataColumn c = new DataColumn("status");
                c.Caption = (VarGeneral.UserLang == 0 ? "حالة الطلب" : "Order Status : "); ; ;
                tnotdoneorders.Columns.Add(c);
                c = new DataColumn("Departments");
                c.Caption = (VarGeneral.UserLang == 0 ? "الاقسام" : "Department : "); ; ;
                tnotdoneorders.Columns.Add(c);
            }
            tnotdoneorders.Columns["InvNo"].Caption = (VarGeneral.UserLang == 0 ? "رقم الطلب" : "Order No : "); ; ;
            foreach (DataRow r in tnotdoneorders.Rows)
            {
                if (r["OrderStatus"].ToString() == "1")
                    r["status"] = (VarGeneral.UserLang == 0 ? "تم التنفيذ" : "Done : ");
                else
                    r["status"] = (VarGeneral.UserLang == 0 ? "تحت التنفيذ" : "Under Execution : "); ; ;


                r["Departments"] = getcategories(r["id"].ToString(), 0);


            }
            if (tdoneorders.Rows.Count > 0)
            {

                DataColumn c = new DataColumn("status");
                c.Caption = (VarGeneral.UserLang == 0 ? "حالة الطلب" : "Status Order : "); ; ;
                tdoneorders.Columns.Add(c);
                c = new DataColumn("Departments");
                c.Caption = (VarGeneral.UserLang == 0 ? "الاقسام" : "Department : "); ; ;
                tdoneorders.Columns.Add(c);
            }
            foreach (DataRow r in tdoneorders.Rows)
            {
                if (r["OrderStatus"].ToString() == "1")
                    r["status"] = (VarGeneral.UserLang == 0 ? "تم التنفيذ" : "Done : ");
                else
                    r["status"] = (VarGeneral.UserLang == 0 ? "تحت التنفيذ" : "Under Execution : "); ; ;
                r["Departments"] = getcategories(r["id"].ToString(), 1);

            }
            try
            {



                tdoneorders.Columns["InvNo"].Caption = (VarGeneral.UserLang == 0 ? "رقم الطلب :" : "Under Execution : "); ; ;

            }
            catch { }

            //dataGridView1.DataSource = Table;
            try
            {
                DonView.DataSource = tdoneorders;

                DonView.Columns["OrderStatus"].Visible = false;
                DonView.Columns["status"].HeaderText = (VarGeneral.UserLang == 0 ? " حالة الطلب" : "  Order  Status : "); ;

                DonView.Columns["id"].Visible = false;
                ;
                int j = DonView.Columns.Count;
                DonView.Columns["op1"].DisplayIndex = j - 2;

                DonView.Columns["ch1"].DisplayIndex = j - 2;
                DonView.Columns["Print"].DisplayIndex = j - 2;

                DonView.Refresh();
            }
            catch { }
            try
            {
                UndeExeCView.DataSource = tnotdoneorders;

                UndeExeCView.Columns["OrderStatus"].Visible = false;
                UndeExeCView.Columns["status"].HeaderText = (VarGeneral.UserLang == 0 ? " حالة الطلب" : "  Order  Status : "); ;
                UndeExeCView.Columns["id"].Visible = false;
                int j = UndeExeCView.Columns.Count;

                UndeExeCView.Columns["op2"].DisplayIndex = j - 2;
                UndeExeCView.Columns["ch2"].DisplayIndex = j - 2;
                UndeExeCView.Columns["Print1"].DisplayIndex = j - 2;
                UndeExeCView.Refresh();
            }
            catch { }

            Refresh();
            //dataGridView1. Refresh();
        }
        private void ClickDonview(object sender, DataGridViewCellEventArgs e)
        {
             
            DataGridView grid = (DataGridView)sender;
            if (db == null)
                db = new Stock_DataDataContext(VarGeneral.BranchCS);
            if (e.RowIndex < 0)
            {
                //They clicked the header column, do nothing
                return;
            }

            if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            {
                if (grid.Columns[e.ColumnIndex].Name == "ch1")
                {

                    string i = grid.Rows[e.RowIndex].Cells["id"].Value.ToString();

                    T_INVHED v = db.StockInvHeadID(7, int.Parse(i));

                    if (v != null)
                    {
                        db.ExecuteCommand("Update T_INVHED SET OrderStatus=0 where InvHed_ID=" + v.InvHed_ID.ToString());
                        db.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);

                    }
                }
                else
                    if (grid.Columns[e.ColumnIndex].Name == "op1")
                {
                    try
                    {
                        string i = grid.Rows[e.RowIndex].Cells["InvNo"].Value.ToString();
                        FrmCarFixingOrder f = new FrmCarFixingOrder();
                        f.GOTONO = i.ToString();


                        f.TopMost = true;
                        f.BringToFront();
                        f.WindowState = FormWindowState.Maximized;
                        f.ShowDialog();

                    }
                    catch
                    {

                    }

                }
                if (grid.Columns[e.ColumnIndex].Name == "Print")
                {
                    try
                    {
                        VarGeneral.InvTyp = 7;
                        string i = grid.Rows[e.RowIndex].Cells["InvNo"].Value.ToString();
                        FrmCarFixingOrder f = new FrmCarFixingOrder();
                        f.GOTONO = i.ToString();
                        ParentForm.TopMost = false;
                        f.directprint();
                        ParentForm.TopMost = true;

                    }
                    catch
                    {

                    }
                }


            }

        }


        private void ClickUnderExecution(object sender, DataGridViewCellEventArgs e)
        {
           
            DataGridView grid = (DataGridView)sender;
            if (db == null)
                db = new Stock_DataDataContext(VarGeneral.BranchCS);
            if (e.RowIndex < 0)
            {
                //They clicked the header column, do nothing
                return;
            }

            if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            {
                if (grid.Columns[e.ColumnIndex].Name == "ch2")
                {

                    string i = grid.Rows[e.RowIndex].Cells["id"].Value.ToString();

                    T_INVHED v = db.StockInvHeadID(7, int.Parse(i));

                    if (v != null)
                    {
                        db.ExecuteCommand("Update T_INVHED SET OrderStatus=1 where InvHed_ID=" + v.InvHed_ID.ToString());
                        db.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);

                    }
                }

                if (grid.Columns[e.ColumnIndex].Name == "op2")
                {
                    try
                    {
                        string i = grid.Rows[e.RowIndex].Cells["InvNo"].Value.ToString();
                        FrmCarFixingOrder f = new FrmCarFixingOrder();
                        f.GOTONO = i.ToString();

                        f.BringToFront();
                        f.TopMost = true;
                        f.WindowState = FormWindowState.Maximized;
                        f.Show();

                    }
                    catch
                    {

                    }

                }
                if (grid.Columns[e.ColumnIndex].Name == "Print1")
                {
                    try
                    {
                        VarGeneral.InvTyp = 7;
                        string i = grid.Rows[e.RowIndex].Cells["InvNo"].Value.ToString();
                        FrmCarFixingOrder f = new FrmCarFixingOrder();
                        f.GOTONO = i.ToString();
                        ParentForm.TopMost = false;
                        f.directprint();
                        ParentForm.TopMost = true;

                    }
                    catch
                    {

                    }
                }
            }
        }

        public DBMonitoring dbmonitor;
        void exe(string cms)
        {
            sampleSqlConnection = new SqlConnection(VarGeneral.BranchCS);
            SqlCommand cm = new SqlCommand(cms, sampleSqlConnection);
            sampleSqlConnection.Open();
            cm.ExecuteNonQuery();
            sampleSqlConnection.Close();


        }
        public void init()
        {
            string dbname = getdatabasename();


            sampleSqlConnection = new SqlConnection(VarGeneral.BranchCS);

            DataTable tb = ProShared.DBUdate.DbUpdates.execute("SELECT is_broker_enabled FROM sys.databases WHERE name = 'Database_name';".Replace("Database_name", dbname), VarGeneral.BranchCS);
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
                        Application.ExitThread();
                        Process.Start(Application.ExecutablePath, arguments);
                    }
                    catch
                    {
                        MessageBox.Show("please Contatct IT SUPPORT");
                    }


                }


            }


            SqlDependency.Start(VarGeneral.BranchCS);

            DBMonitoring();
            updategride();

        }


        public static string getdatabasename()
        {
            string db = VarGeneral.BranchCS;
            string name = string.Empty;
            int i = db.ToLower().IndexOf("database");
            int f = 0;
            for (int j = i; j < db.Length; j++)
            {
                if (db[j] == '=')
                {
                    f = 1; continue;
                }
                else if (db[j] == ';') break;
                if (f == 1)
                {
                    name += db[j];
                }
            }
            return name;
        }
        public void DBMonitoring()
        {

            string c = @"SELECT [InvHed_ID]
      ,[InvId]
      ,[InvNo]
      ,[InvTyp]
      ,[InvCashPay]
      ,[CusVenNo]
      ,[CusVenNm]
      ,[CusVenAdd]
      ,[CusVenTel]
      ,[Remark]
      ,[HDat]
      ,[GDat]
      ,[MndNo]
      ,[SalsManNo]
      ,[SalsManNam]
      ,[InvTot]
      ,[InvTotLocCur]
      ,[InvDisPrs]
      ,[InvDisVal]
      ,[InvDisValLocCur]
      ,[InvNet]
      ,[InvNetLocCur]
      ,[CashPay]
      ,[CashPayLocCur]
      ,[IfRet]
      ,[GadeNo]
      ,[GadeId]
      ,[IfDel]
      ,[RetNo]
      ,[RetId]
      ,[InvCstNo]
      ,[InvCashPayNm]
      ,[RefNo]
      ,[InvCost]
      ,[EstDat]
      ,[CustPri]
      ,[ArbTaf]
      ,[CurTyp]
      ,[InvCash]
      ,[ToStore]
      ,[ToStoreNm]
      ,[InvQty]
      ,[EngTaf]
      ,[IfTrans]
      ,[CustRep]
      ,[CustNet]
      ,[InvWight_T]
      ,[IfPrint]
      ,[LTim]
      ,[CREATED_BY]
      ,[DATE_CREATED]
      ,[MODIFIED_BY]
      ,[DATE_MODIFIED]
      ,[CreditPay]
      ,[CreditPayLocCur]
      ,[NetworkPay]
      ,[NetworkPayLocCur]
      ,[CommMnd_Inv]
      ,[MndExtrnal]
      ,[CompanyID]
      ,[InvAddCost]
      ,[InvAddCostLoc]
      ,[InvAddCostExtrnal]
      ,[InvAddCostExtrnalLoc]
      ,[IsExtrnalGaid]
      ,[ExtrnalCostGaidID]
      ,[Puyaid]
      ,[Remming]
      ,[RoomNo]
      ,[OrderTyp]
      ,[RoomSts]
      ,[chauffeurNo]
      ,[RoomPerson]
      ,[ServiceValue]
      ,[Sts]
      ,[PaymentOrderTyp]
      ,[AdminLock]
      ,[DeleteDate]
      ,[DeleteTime]
      ,[UserNew]
      ,[IfEnter]
      ,[InvAddTax]
      ,[InvAddTaxlLoc]
      ,[IsTaxGaid]
      ,[TaxGaidID]
      ,[IsTaxUse]
      ,[InvValGaidDis]
      ,[InvValGaidDislLoc]
      ,[IsDisGaid]
      ,[DisGaidID1]
      ,[IsDisUse1]
      ,[InvComm]
      ,[InvCommLoc]
      ,[IsCommGaid]
      ,[CommGaidID]
      ,[IsCommUse]
      ,[IsTaxLines]
      ,[IsTaxByTotal]
      ,[IsTaxByNet]
      ,[TaxByNetValue]
      ,[DesPointsValue]
      ,[DesPointsValueLocCur]
      ,[PointsCount]
      ,[IsPoints]
      ,[tailor1]
      ,[tailor2]
      ,[tailor3]
      ,[tailor4]
      ,[tailor5]
      ,[tailor6]
      ,[tailor7]
      ,[tailor8]
      ,[tailor9]
      ,[tailor10]
      ,[tailor11]
      ,[tailor12]
      ,[tailor13]
      ,[tailor14]
      ,[tailor15]
      ,[tailor16]
      ,[tailor17]
      ,[tailor18]
      ,[tailor19]
      ,[tailor20]
      ,[InvImg]
      ,[PriceIncludTax]
      ,[CusVenMob]
      ,[CInvType]
      ,[VehiclechassisNumber]
      ,[Car_ID]
      ,[Car_TypeNameA]
      ,[Car_TypeNameE]
      ,[Car_NameA]
      ,[Car_NameE]
      ,[PlateNo]
      ,[Color]
      ,[ModelNo]
      ,[Delevery_Date]
      ,[OrderStatus]
  FROM [dbo].[T_INVHED];";
            if (sampleSqlConnection.State == ConnectionState.Closed)
                sampleSqlConnection.Open();
            this.sampleSqlCommand = new SqlCommand();
            this.sampleSqlCommand.Connection = this.sampleSqlConnection; this.sampleSqlCommand.CommandType = CommandType.Text;
            this.sampleSqlCommand.CommandText = c;// "SELECT [SampleId],[SampleName], [SampleCategory], [SampleDateTime], [IsSampleProcessed] FROM [dbo].[SampleTable01];";
            this.sampleSqlCommand.Notification = null;
            this.sampleSqlDependency = new SqlDependency(this.sampleSqlCommand);
            this.sampleSqlDependency.OnChange += this.SqlDependencyOnChange;

            try
            {
                this.sampleSqlCommand.ExecuteReader();
            }
            catch
            {
                this.sampleSqlCommand.Connection.Close();
                if (sampleSqlConnection.State == ConnectionState.Closed)
                    sampleSqlConnection.Open();
                this.sampleSqlCommand.ExecuteReader();
            }



        }
        public void termination()
        {

        }
        public delegate void customMessageHandler(System.Object sender,
                                   SqlNotificationEventArgs e);

#pragma warning disable CS0067 // The event 'EXPanel.OrderStatuschanged' is never used
        public event customMessageHandler OrderStatuschanged;
#pragma warning restore CS0067 // The event 'EXPanel.OrderStatuschanged' is never used
        private void SqlDependencyOnChange(object sender, SqlNotificationEventArgs e)
        {
            updategride();
            this.sampleSqlDependency.OnChange -= this.SqlDependencyOnChange;
            DonView.DataSource = tdoneorders;
            UndeExeCView.DataSource = tnotdoneorders;
            DonView.Refresh();
            UndeExeCView.Refresh();
            DBMonitoring();

        }

        SqlCommand sampleSqlCommand;
        SqlDependency sampleSqlDependency;
        SqlConnection sampleSqlConnection;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void EXPanel_Load(object sender, EventArgs e)
        {
            VarGeneral.InvTyp = 7;
        }

        private void UndeExeCView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string i = UndeExeCView.SelectedRows[0].Cells["InvNo"].Value.ToString();
                FrmCarFixingOrder f = new FrmCarFixingOrder();
                f.GOTONO = i.ToString();

                Parent.SendToBack();
                f.TopMost = true;
                f.WindowState = FormWindowState.Maximized;
                f.Show();
                Parent.BringToFront();
            }
            catch
            {

            }

        }

        private void DonView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DonView_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                string i = DonView.SelectedRows[0].Cells["InvNo"].Value.ToString();
                FrmCarFixingOrder f = new FrmCarFixingOrder();
                f.GOTONO = i.ToString();
                Parent.SendToBack();
                f.TopMost = true;
                f.WindowState = FormWindowState.Maximized;
                f.Show();
                Parent.BringToFront();
            }
            catch
            {

            }
        }

        private void UndeExeCView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UndeExeCView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void changeToUnDone(object sender, EventArgs e)
        {

            try
            {
                string i = ((Button)sender).Tag.ToString();

                T_INVHED v = db.StockInvHeadID(7, int.Parse(i));

                if (v != null)
                {
                    db.ExecuteCommand("Update T_INVHED SET OrderStatus=0 where InvHed_ID=" + v.InvHed_ID.ToString());
                    db.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
                }

            }
            catch
            {

            }
        }

        private void openOrder_click(object sender, EventArgs e)
        {
        }

        private void DonView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void ChangeStutusTOdon_click(object sender, EventArgs e)
        {
            try
            {
                string i = ((Button)sender).Tag.ToString();

                T_INVHED v = db.StockInvHeadID(7, int.Parse(i));

                if (v != null)
                {
                    db.ExecuteCommand("Update T_INVHED SET OrderStatus=1 where InvHed_ID=" + v.InvHed_ID.ToString());
                    db.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);

                }

            }
            catch
            {

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void EXPanel_SizeChanged(object sender, EventArgs e)
        {
            splitContainer2.SplitterDistance = 25;
            splitContainer3.SplitterDistance = 25;
            splitContainer1.SplitterDistance = (this.Height / 2);
            label1.MinimumSize = new Size(this.Width, 0);
            label2.MinimumSize = new Size(this.Width, 0);
        }

        private void UndeExeCView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            UndeExeCView.Refresh();
        }

        private void DonView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DonView.Refresh();
        }

        private void UndeExeCView_CellErrorTextChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DonView_CellErrorTextChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UndeExeCView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DonView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            DataGridView grid = (DataGridView)sender;
            if (e.RowIndex < 0)
            {
                //They clicked the header column, do nothing
                return;
            }

            if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            {
             
                    string i = grid.Rows[e.RowIndex].Cells["id"].Value.ToString();

                    T_INVHED v = db.StockInvHeadID(7, int.Parse(i));

                    if (v != null)
                    {
                    shopanel(i, 0);
                    }
              
            }
              
           
        
        }

        private void DonView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        

        }

        private void DonView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            UnExStatus.Visible = false;
            DataGridView grid = (DataGridView)sender;
            if (e.RowIndex < 0)
            {
                //They clicked the header column, do nothing
                return;
            }

            if (grid.Columns[e.ColumnIndex].Name == "Departments")
            {

                string i = grid.Rows[e.RowIndex].Cells["id"].Value.ToString();

                T_INVHED v = db.StockInvHeadID(7, int.Parse(i));

                if (v != null)
                {
                    dri = e.RowIndex;
                    shopanel(i, 1, DonExstatus);
                   for (int k =1;k<DonExstatus.Columns.Count;k++)
                    {
                        {
                            string s = DonExstatus.Columns[k].HeaderText ;
                            if (!(s == ("ItmDes")))
                            {
                                DonExstatus.Columns[k].Visible = false;
                            }
                        }


                    }
                    for (int k = 0; k < DonExstatus.Rows.Count; k++)
                    {

                        DonExstatus_CellEndEdit(sender, new DataGridViewCellEventArgs(DonExstatus.Columns["CaExState"].Index, k));


                    }
                    DonExstatus.AutoSize = true;
                }

            }
            else
                DonExstatus.Visible = false;

        }
        int uri = 0;
        int dri = 0;
        private void UndeExeCView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                DonExstatus.Visible = false; DataGridView grid = (DataGridView)sender;
                if (e.RowIndex < 0)
                {
                    //They clicked the header column, do nothing
                    return;
                }

                if (grid.Columns[e.ColumnIndex].Name == "Departments")
                {

                    string i = grid.Rows[e.RowIndex].Cells["id"].Value.ToString();

                    T_INVHED v = db.StockInvHeadID(7, int.Parse(i));

                    if (v != null)
                    {
                        uri = e.RowIndex;
                        shopanel(i, 0, UnExStatus);
                      
                        for (int k = 1; k < UnExStatus.Columns.Count; k++)
                        {
                            {
                                string s = UnExStatus.Columns[k].HeaderText;
                                if (!(s == ("ItmDes")))
                                {
                                    UnExStatus.Columns[k].Visible = false;
                                }
                            }


                        }
                        for(int k=0;k< UnExStatus.Rows.Count;k++)
                        {

                            UnExStatus_CellEndEdit(sender, new DataGridViewCellEventArgs(UnExStatus.Columns["CaExState"].Index, k));


                        }
                        UnExStatus.AutoSize = true;
                    }

                }

                else
                    UnExStatus.Visible = false;
            }
            catch { }
        }
      
        private void shopanel(string i, int v, DataGridView undeExseCView)
        {
            
            if (db == null) db = new Stock_DataDataContext(VarGeneral.BranchCS);
            T_INVHED f = db.StockInvHeadbyid(7, i,v );
            List<T_INVDET> det= f.T_INVDETs.ToList<T_INVDET>();
            BindingSource b = new BindingSource();
            b.DataSource = det;
            undeExseCView.Visible = true;
            undeExseCView.BringToFront();
          
          //  undeExseCView.AutoResizeRows(DataGridViewAutoSizeRowsMode.)

            undeExseCView.DataSource = b;
               undeExseCView.Refresh();
            //undeExseCView.Show();
        }

        private void DonExstatus_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {  }

        private void DonExstatus_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DonExstatus.CellEndEdit -= DonExstatus_CellEndEdit;
            if (e.ColumnIndex == 0)
            {
            
                {

                    DataGridViewCheckBoxCell c = (DonExstatus.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell);
                    if (((bool)c.Value) == true)
                    {
                        (DonExstatus.Rows[e.RowIndex].Cells["CaExState"]).Value = 1;
                        (DonExstatus.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell).Value = true;
                        int c3 = int.Parse((DonExstatus.Rows[e.RowIndex].Cells["InvDet_ID"]).Value.ToString());
                        T_INVDET T = db.StockInvDet(7, c3);
                        T.CaExState = 1;
                        db.SubmitChanges();

                            }
                    else

                    {
                       (DonExstatus.Rows[e.RowIndex].Cells["CaExState"]).Value = 0;

                        (DonExstatus.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell).Value = false;
                        int c3 = int.Parse((DonExstatus.Rows[e.RowIndex].Cells["InvDet_ID"]).Value.ToString());
                        T_INVDET T = db.StockInvDet(7, c3);
                        T.CaExState = 0;
                        db.SubmitChanges();
                      //  updategride();
                    }
                    if (check(DonExstatus))
                    { ClickDonview(DonView, new DataGridViewCellEventArgs(DonView.Columns["ch1"].Index, dri)); DonExstatus.Visible = false; }//updategride();


                }
            }
            else
            if (DonExstatus.Columns[e.ColumnIndex].Name == "CaExState")
            {
               // if (e.RowIndex > 0)
                {
                    object c = (DonExstatus.Rows[e.RowIndex].Cells["CaExState"]).Value;
                
                if (c == null)
                        c = 0;

                    if (c.ToString() == "1")
                    {
                        // (DonExstatus.Rows[e.RowIndex].Cells["CaExState"]).Value = 1;
                        (DonExstatus.Rows[e.RowIndex].Cells[0] as DataGridViewCheckBoxCell).Value = true;

                    }
                    else

                    {
                        /// (DonExstatus.Rows[e.RowIndex].Cells["CaExState"]).Value = 0;

                        (DonExstatus.Rows[e.RowIndex].Cells[0] as DataGridViewCheckBoxCell).Value = false;;
                    }
                }
            }
            DonExstatus.CellEndEdit += DonExstatus_CellEndEdit;
            DonExstatus.Refresh();
        }

        private void UnExStatus_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            UnExStatus.CellEndEdit -= UnExStatus_CellEndEdit;
            if (e.ColumnIndex == 0)
            {
           
                {
              
                       DataGridViewCheckBoxCell c = (UnExStatus.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell);
                    if (((bool)c.Value) == true)
                    {
                        (UnExStatus.Rows[e.RowIndex].Cells["CaExState"]).Value = 1;
                        (UnExStatus.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell).Value = true;
                        int c3 = int.Parse((UnExStatus.Rows[e.RowIndex].Cells["InvDet_ID"]).Value.ToString());
                        T_INVDET T = db.StockInvDet(7, c3);
                        T.CaExState = 1;
                        db.SubmitChanges();
                        
                    }
                    else

                    {
                        (UnExStatus.Rows[e.RowIndex].Cells["CaExState"]).Value = 0;

                        (UnExStatus.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell).Value = false;
                        int c3 = int.Parse((UnExStatus.Rows[e.RowIndex].Cells["InvDet_ID"]).Value.ToString());
                        T_INVDET T = db.StockInvDet(7, c3);
                        T.CaExState = 1;
                        db.SubmitChanges();
                       
                    }
                    if (check(UnExStatus))
                    { ClickUnderExecution(UndeExeCView, new DataGridViewCellEventArgs(UndeExeCView.Columns["ch2"].Index, uri)); UnExStatus.Visible = false; }


                }
            }
          else
            if (UnExStatus.Columns[ e.ColumnIndex ].Name== "CaExState")
            {
               // if (e.RowIndex > 0)
                {
                object c=    (UnExStatus.Rows[e.RowIndex].Cells["CaExState"]).Value;
                    if (c == null)
                        c = 0;

  if(c.ToString()=="1")
                    {
                        // (UnExStatus.Rows[e.RowIndex].Cells["CaExState"]).Value = 1;
                        (UnExStatus.Rows[e.RowIndex].Cells[0] as DataGridViewCheckBoxCell).Value = true;

                    }
                    else

                    {
                       /// (UnExStatus.Rows[e.RowIndex].Cells["CaExState"]).Value = 0;

                        (UnExStatus.Rows[e.RowIndex].Cells[0] as DataGridViewCheckBoxCell).Value = false;;
                    }
                    db.SubmitChanges();
                }
            }
            UnExStatus.CellEndEdit += UnExStatus_CellEndEdit;
            Refresh();
        }

        private bool check(DataGridView e)
        { int a = 0;
            for (int k = 0; k < e.Rows.Count; k++)
            {
                {
                    bool s =(bool) e.Rows[k].Cells[0].Value;
                    if (s) a++;
                }


            }
            if (a == e.Rows.Count) return true;
            else return false;

        }

        private void DonExstatus_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           // DonExstatus_CellEndEdit(sender, new DataGridViewCellEventArgs(DonExstatus.Columns["CaExState"].Index, e.RowIndex));
        }

        private void UnExStatus_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
        
        }

        private void UnExStatus_Leave(object sender, EventArgs e)
        {
            UnExStatus.Visible = false;
        }

        private void DonExstatus_Leave(object sender, EventArgs e)
        {
            DonExstatus.Visible=false;
        }

        private void DonView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
         
        }
    }
}
