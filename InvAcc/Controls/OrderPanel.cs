using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;
using InvAcc.GeneralM;
using InvAcc.Properties;
using InvAcc.Stock_Data;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace InvAcc.Controls
{
    public partial class OrderPanel : UserControl
    {
        public OrderPanel()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;


        }
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
        public static string getdatabasename()
        {
            return InvAcc.Properties.Settings.Default.DefaultDDatabaseName + "_" + VarGeneral.BranchNumber;
        }
        public void init()
        {
            vTy_ = 7;
            superTabItem_Customer.Text = "الطلبات";
            labelItem_Mobile.Visible = true;
            txtSearchMobile.Visible = true;
            sampleSqlConnection = new SqlConnection(VarGeneral.BranchCS);
            string dbname = getdatabasename();
            string cms = @"ALTER DATABASE [DBNAME] SET ENABLE_BROKER WITH ROLLBACK IMMEDIATE";
            cms = cms.Replace("DBNAME", dbname);
            SqlCommand cm = new SqlCommand(cms, sampleSqlConnection);
            sampleSqlConnection.Open();
            cm.ExecuteNonQuery();
            sampleSqlConnection.Close();

            SqlDependency.Start(VarGeneral.BranchCS);
            DBMonitoring();
            FillItems();
            TableInfo(string.Empty);
            VisibleSts = true;

        }
        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void ToolStripMenuItem_Det_Click(object sender, EventArgs e)
        {

        }
        SqlCommand sampleSqlCommand;
        SqlDependency sampleSqlDependency;
        SqlConnection sampleSqlConnection;
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

            this.sampleSqlCommand.ExecuteReader();

        }
        private void SqlDependencyOnChange(object sender, SqlNotificationEventArgs e)
        {

            this.sampleSqlDependency.OnChange -= this.SqlDependencyOnChange;
            DBMonitoring();

            FillItems();
            TableInfo(string.Empty);
            VisibleSts = true;

        }

        private void ToolStripMenuItem_Rep_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void superTabControl_Tables_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        {

        }

        private void superTabControlPanel1_Click(object sender, EventArgs e)
        {

        }

        private void labelItem2_Click(object sender, EventArgs e)
        {

        }

        private void labelItem_Mobile_Click(object sender, EventArgs e)
        {

        }

        private void checkBox_ByMobile_Click(object sender, EventArgs e)
        {

        }

        private void checkBox_ByName_Click(object sender, EventArgs e)
        {

        }

        private void expandablePanel_Table_Click(object sender, EventArgs e)
        {

        }

        private void itemPanel1_ItemClick(object sender, EventArgs e)
        {

        }

        private void labelItem_Tables_Click(object sender, EventArgs e)
        {

        }

        private void labelItem_Note_Click(object sender, EventArgs e)
        {

        }

        private void labelItem_Time_Click(object sender, EventArgs e)
        {

        }

        private void labelItem_Nadel_Click(object sender, EventArgs e)
        {

        }

        private void labelItem_Type_Click(object sender, EventArgs e)
        {

        }

        private void itemPanel2_ItemClick(object sender, EventArgs e)
        {

        }

        private void labelItem_SumTable_Click(object sender, EventArgs e)
        {

        }

        private void panel_ButSave_Paint(object sender, PaintEventArgs e)
        {

        }

        public int vTy_ = 0;
        public string Serach_No = string.Empty;
        public string sts_ = string.Empty;
        private string vNo = string.Empty;
#pragma warning disable CS0414 // The field 'OrderPanel.vTyp' is assigned but its value is never used
        private int vTyp = 0;
#pragma warning restore CS0414 // The field 'OrderPanel.vTyp' is assigned but its value is never used
        private bool frmSts_ = false;
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private int LangArEn = 0;
        private Stock_DataDataContext dbInstance;
#pragma warning disable CS0169 // The field 'OrderPanel.dbInstanceRt' is never used
        private Rate_DataDataContext dbInstanceRt;
#pragma warning restore CS0169 // The field 'OrderPanel.dbInstanceRt' is never used
        private MetroTileItem vItemSelect = new MetroTileItem();
        public bool VisibleSts
        {
            set
            {
                if (!frmSts_)
                {
                    panel_ButSave.Visible = !value;
                }
                else
                {
                    panel_ButSave.Visible = false;
                }
            }
        }
        private void metroTilePanel_Customer_ItemClick(object sender, EventArgs e)
        {
            try
            {
                MetroTileItem q = (vItemSelect = sender as MetroTileItem);
                if (q != null)
                {
                    TableInfo(q.Tag.ToString());
                    VisibleSts = false;
                }
                else
                {
                    TableInfo(string.Empty);
                    VisibleSts = true;
                }
            }
            catch
            {
                vItemSelect = null;
                VisibleSts = true;
            }
        }
        private void txtSearchMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b')) && checkBox_ByMobile.Checked)
            {
                e.Handled = true;
            }
        }
        private void txtSearchMobile_ButtonCustomClick(object sender, EventArgs e)
        {
            FillItems();
            TableInfo(string.Empty);
            VisibleSts = true;
        }
        private void txtSearchMobile_ButtonCustom2Click(object sender, EventArgs e)
        {
            txtSearchMobile.Text = string.Empty;
            FillItems();
            TableInfo(string.Empty);
            VisibleSts = true;
        }
        private void txtSearchMobile_VisibleChanged(object sender, EventArgs e)
        {
            if (vTy_ == 0)
            {
                checkBox_ByMobile.Visible = txtSearchMobile.Visible;
                checkBox_ByName.Visible = txtSearchMobile.Visible;
            }
            else
            {
                checkBox_ByMobile.Visible = false;
                checkBox_ByName.Visible = false;
            }
        }
        private void checkBox_ByMobile_CheckedChanged(object sender, CheckBoxChangeEventArgs e)
        {
            labelItem_Mobile.Text = checkBox_ByMobile.Text + " :";
        }
        private void checkBox_ByName_CheckedChanged(object sender, CheckBoxChangeEventArgs e)
        {
            labelItem_Mobile.Text = checkBox_ByName.Text + " :";
        }

        private void FillItems()
        {
            try
            {
                itemContainer_Customer.SubItems.Clear();

                {
                    List<T_INVHED> LAccDef = new List<T_INVHED>();
                    if (true)
                    {
                        LAccDef = (from item in db.T_INVHEDs
                                   where item.InvTyp == (int?)7
                                   where item.IfDel == (int?)0
                                   where item.OrderStatus == 1
                                   select item).ToList();
                    }
                    else
                    {
                    }
                    for (int i = 0; i < LAccDef.Count; i++)
                    {
                        MetroTileItem vTable = new MetroTileItem();
                        vTable.Image = Resources.Customer;
                        vTable.ImageTextAlignment = ContentAlignment.MiddleCenter;
                        vTable.SymbolColor = Color.Empty;
                        vTable.TileColor = eMetroTileColor.Azure;
                        vTable.TileSize = new Size(160, 140);
                        vTable.TileStyle.CornerType = eCornerType.Diagonal;
                        vTable.TitleText = LAccDef[i].InvNo.ToString();
                        vTable.Tag = LAccDef[i].InvNo.ToString();
                        vTable.TitleTextAlignment = ContentAlignment.BottomCenter;
                        vTable.TitleTextFont = new Font("Tahoma", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
                        itemContainer_Customer.SubItems.AddRange(new BaseItem[1]
                        {
                            vTable
                        });
                    }

                }

                Refresh();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FillItems:", error, enable: true);
                itemContainer_Customer.SubItems.Clear();
                Refresh();
            }
        }
        private void TableInfo(string vTableNo)
        {
            if (!string.IsNullOrEmpty(vTableNo))
            {
                //if (vTy_ == 0)
                //{
                //    List<T_AccDef> q2 = db.T_AccDefs.Where((T_AccDef t) => t.AccDef_No == vTableNo).ToList();
                //    labelItem_Tables.Text = ((LangArEn == 0) ? "رقم العميل : " : "Customer No : ") + q2.FirstOrDefault().AccDef_No;
                //    labelItem_Note.Text = ((LangArEn == 0) ? "إسم العميل - عـربــي : " : "Customer Name A : ") + q2.FirstOrDefault().Arb_Des;
                //    labelItem_Time.Text = ((LangArEn == 0) ? "إسم العميل - إنجليزي : " : "Customer Name E : ") + q2.FirstOrDefault().Eng_Des;
                //    labelItem_Nadel.Text = ((LangArEn == 0) ? "إجمالي المدين : " : "Debit Total : ") + q2.FirstOrDefault().Debit.Value + "    |    " + ((LangArEn == 0) ? " إجمالي الدائن : " : "Credit Total : ") + q2.FirstOrDefault().Credit.Value;
                //    labelItem_Type.Text = ((LangArEn == 0) ? " رصيد العميل : " : "Balance : ") + q2.FirstOrDefault().Balance.Value;
                //}
                //if (vTy_ == 7)
                {
                    List<T_INVHED> q = (from t in db.T_INVHEDs
                                        where t.InvNo == vTableNo
                                        where t.InvTyp == 7
                                        where t.IfDel == 0
                                        where t.OrderStatus == 1
                                        select t).ToList();
                    labelItem_Tables.Text = ((LangArEn == 0) ? "رقم الفاتورة : " : "Customer No : ") + q.FirstOrDefault().InvNo;
                    labelItem_Note.Text = ((LangArEn == 0) ? "تاريخ الفاتورة هجري : " : "Date Hij : ") + q.FirstOrDefault().HDat + "    |    " + ((LangArEn == 0) ? " تاريخ الفاتورة ميلادي : " : "Date Ger : ") + q.FirstOrDefault().GDat;
                    labelItem_Time.Text = ((LangArEn == 0) ? "إجمالي الفاتورة : " : "Invoice Total : ") + q.FirstOrDefault().InvTotLocCur.Value + "    |    " + ((LangArEn == 0) ? " صافي الفاتورة : " : "Invoice Net : ") + q.FirstOrDefault().InvNetLocCur.Value;
                    labelItem_Nadel.Text = ((LangArEn == 0) ? "إسم العميل : " : "Customer Name : ") + q.FirstOrDefault().CusVenNm + "    |    " + ((LangArEn == 0) ? " رقم العميل : " : "Customer No : ") + q.FirstOrDefault().CusVenNo;
                    labelItem_Type.Text = ((LangArEn == 0) ? " الملاحظـــات : " : "Notes : ") + q.FirstOrDefault().Remark;
                }
            }
            else
            {
                //  if (vTy_ == 7)
                {
                    labelItem_Tables.Text = "رقم الفاتورة : لا يوجد ";
                    labelItem_Note.Text = "صافي الفاتورة : لا يوجد ";
                    labelItem_Time.Text = "صافي الفاتورة : لا يوجد ";
                    labelItem_Nadel.Text = "إسم العميل  : لا يوجد ";
                    labelItem_Type.Text = "لم يتم تحديد فاتورة ";
                }
            }
            //if (vTy_ == 0)
            {
                labelItem_SumTable.Text = ((LangArEn == 0) ? "إجمالي عدد الطلبات : " : "Orders Total : ") + itemContainer_Customer.SubItems.Count + ((LangArEn == 0) ? " عميل " : "Customer");
            }

        }

        private void ButOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (vItemSelect == null)
                {
                    Serach_No = string.Empty;

                }
                else if (!string.IsNullOrEmpty(vItemSelect.TitleText) && !string.IsNullOrEmpty(vItemSelect.Tag.ToString()))
                {
                    Serach_No = vItemSelect.Tag.ToString();

                }
                else
                {
                    Serach_No = string.Empty;

                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("ButOk_Click:", error, enable: true);
                MessageBox.Show((LangArEn == 0) ? "حدث خطأ ما .. يرجى تحديد العميل ثم المحاولة مرة آخرى" : "Error .. Please identify the Customer and then try again", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Serach_No = string.Empty;

            }
        }
    }
}
