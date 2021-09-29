using InvAcc.GeneralM;
using System.Data;
using System.Data.SqlClient;

namespace InvAcc.DBUdate
{
    public class DBMonitoring
    {
        System.Data.SqlClient.SqlDependency sqlDependency;
        public static string getdatabasename()
        {
            return InvAcc.Properties.Settings.Default.DefaultDDatabaseName + "_" + VarGeneral.BranchNumber;
        }
        public DBMonitoring()
        {
            sampleSqlConnection = new SqlConnection(VarGeneral.BranchCS);
            string dbname = getdatabasename();
            string cms = @"ALTER DATABASE [DBNAME] SET ENABLE_BROKER WITH ROLLBACK IMMEDIATE";
            cms = cms.Replace("DBNAME", dbname);
            SqlCommand cm = new SqlCommand(cms, sampleSqlConnection);
            sampleSqlConnection.Open();
            cm.ExecuteNonQuery();
            sampleSqlConnection.Close();
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
            sampleSqlConnection = new SqlConnection(VarGeneral.BranchCS);
            if (sampleSqlConnection.State == ConnectionState.Open)
                sampleSqlConnection.Close();

            this.sampleSqlCommand = new SqlCommand();

            this.sampleSqlCommand.Connection = this.sampleSqlConnection;
            this.sampleSqlCommand.Connection.Open();
            this.sampleSqlCommand.CommandType = CommandType.Text;
            this.sampleSqlCommand.CommandText = c;// "SELECT [SampleId],[SampleName], [SampleCategory], [SampleDateTime], [IsSampleProcessed] FROM [dbo].[SampleTable01];";
            this.sampleSqlCommand.Notification = null;
            this.sampleSqlDependency = new SqlDependency(this.sampleSqlCommand);
            this.sampleSqlDependency.OnChange += this.SqlDependencyOnChange;
            SqlDependency.Start(VarGeneral.BranchCS);

            this.sampleSqlCommand.ExecuteReader();

        }
        public void termination()
        {
            SqlDependency.Stop(VarGeneral.BranchCS);
        }
        public delegate void customMessageHandler(System.Object sender,
                                   SqlNotificationEventArgs e);

        public event customMessageHandler OrderStatuschanged;
        private void SqlDependencyOnChange(object sender, SqlNotificationEventArgs e)
        {
            if (OrderStatuschanged != null)
                OrderStatuschanged(null, e);
        }

        SqlCommand sampleSqlCommand;
        SqlDependency sampleSqlDependency;
        SqlConnection sampleSqlConnection;
    }
}
