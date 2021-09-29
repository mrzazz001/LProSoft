using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InvAcc.Stock_Data;
using InvAcc.GeneralM;

namespace InvAcc.Controls.POS
{
    public partial class Pos_ItemPanel : UserControl
    {
        public int ItemWidth = 203;
        public int ItemHieght = 193;
        private int TotalPage = 0;
        private int TotalPageDet = 0;
        public int CAT_ID = 0;
        //   FlowLayoutPanel Flayout2 = new FlowLayoutPanel();
        public int Cpanel_ID;
        public int PosFlag = 0;
        private int PageSize = 10;
        private int PageSizeDet = 10;
        int posflag = 0;
        int rearrange = 0;
        private int row = 0;
        private int rowH = 0;
        public int ItemCategory = 0;
        public  void FillItmesMain(int Cat_Id, bool vBestSaller)
        {
            CAT_ID = CAT_ID;
            ItemGried.Controls.Clear();
            col = ItemGried.ColumnCount;
            row = ItemGried.RowCount;
            PageSize = Math.Abs(col * row);
            List<T_Item> vItemsMain = new List<T_Item>();
            Stock_DataDataContext dbc = new Stock_DataDataContext();
            vItemsMain = (from t in dbc.T_Items
                          where t.ItmTyp != (int?)1 && !t.InvSaleStoped.Value && t.ItmCat == CAT_ID
                          orderby t.Itm_ID

                          select t).ToList();
            if (Cat_Id != null)
            {
                
                if (Cat_Id != 0)
                {
                    vItemsMain = (from t in dbc.T_Items
                                  where t.ItmCat == Cat_Id
                                  where t.ItmTyp != (int?)1 && !t.InvSaleStoped.Value && t.ItmCat == CAT_ID
                                  orderby t.Itm_ID
                                  select t).ToList();
                }
            }
            if (vBestSaller)
            {
                vItemsMain = db.ExecuteQuery<T_Item>("SELECT        T_Items.Itm_ID, T_Items.Itm_No, T_Items.ItmCat, T_Items.Arb_Des, T_Items.Eng_Des, T_Items.StartCost, T_Items.AvrageCost, T_Items.LastCost, T_Items.Price1, \r\n                                                                                  T_Items.Price3, T_Items.Price2, T_Items.Price5, T_Items.Price4, T_Items.Price6, T_Items.Unit1, T_Items.Pack1, T_Items.Unit2, T_Items.UntPri2, T_Items.UntPri1, \r\n                                                                                  T_Items.Pack2, T_Items.Unit3, T_Items.Pack3, T_Items.Unit4, T_Items.UntPri3, T_Items.UntPri4, T_Items.Pack4, T_Items.Unit5, T_Items.UntPri5, T_Items.Pack5, \r\n                                                                                  T_Items.DefultUnit, T_Items.DefultVendor, T_Items.OpenQty, T_Items.QtyLvl, T_Items.ItmLoc, T_Items.BarCod1, T_Items.BarCod2, T_Items.BarCod3, \r\n                                                                                  T_Items.BarCod4, T_Items.BarCod5, T_Items.Lot, T_Items.LrnExp, T_Items.DMY, T_Items.ItmTyp, T_Items.DefPack, T_Items.ItmImg, \r\n                                                                                  T_Items.InvSaleStoped, T_Items.InvPaymentStoped, T_Items.InvPaymentReturnStoped, T_Items.FirstCost, T_Items.CompanyID, T_Items.InvSaleReturnStoped, \r\n                                                                                  T_Items.SerialKey,sum(RealQty) as QtyMax\r\n                                                            FROM         T_Items INNER JOIN\r\n                                                                                  T_INVDET ON T_Items.Itm_No = T_INVDET.ItmNo INNER JOIN\r\n                                                                                  T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID  \r\n                                                            WHERE T_INVHED.InvTyp = 1 and T_Items.ItmTyp != 1 and T_Items.InvSaleStoped = 0\r\n                                                            Group By T_Items.Itm_ID, T_Items.Itm_No, T_Items.ItmCat, T_Items.Arb_Des, T_Items.Eng_Des, T_Items.StartCost, T_Items.AvrageCost, T_Items.LastCost, T_Items.Price1, \r\n                                                                                  T_Items.Price3, T_Items.Price2, T_Items.Price5, T_Items.Price4, T_Items.Price6, T_Items.Unit1, T_Items.Pack1, T_Items.Unit2, T_Items.UntPri2, T_Items.UntPri1, \r\n                                                                                  T_Items.Pack2, T_Items.Unit3, T_Items.Pack3, T_Items.Unit4, T_Items.UntPri3, T_Items.UntPri4, T_Items.Pack4, T_Items.Unit5, T_Items.UntPri5, T_Items.Pack5, \r\n                                                                                  T_Items.DefultUnit, T_Items.DefultVendor, T_Items.OpenQty, T_Items.QtyLvl, T_Items.ItmLoc, T_Items.BarCod1, T_Items.BarCod2, T_Items.BarCod3, \r\n                                                                                  T_Items.BarCod4, T_Items.BarCod5, T_Items.Lot, T_Items.QtyMax, T_Items.LrnExp, T_Items.DMY, T_Items.ItmTyp, T_Items.DefPack, T_Items.ItmImg, \r\n                                                                                  T_Items.InvSaleStoped, T_Items.InvPaymentStoped, T_Items.InvPaymentReturnStoped, T_Items.FirstCost, T_Items.CompanyID, T_Items.InvSaleReturnStoped, \r\n                                                                                  T_Items.SerialKey\r\n                                                                                  order by QtyMax desc", new object[0]).ToList();
            }
            if (vItemsMain.Count <= 0)
            {
                
                return;
            }
            CurrentPageIndex = 1;
            CurrentPageIndexItmDet = 1;
            CalculateTotalPages(vItemsMain);
            //    if(vItemsMain.Count>1)
            GetCurrentRecords(1, vBestSaller);
            //   else
            //  { superGridControl1.PrimaryGrid.Columns.Clear();
            //    superGridControl1.PrimaryGrid.Rows.Clear();
            //}
        }

        public Pos_ItemPanel()
        {
            InitializeComponent();
            POSItem f = new POSItem();
            ItemHieght = f.Height;
            ItemWidth = f.Width;
            
        }
        List<T_CATEGORY> t_CATEGORYes = new List<T_CATEGORY>();
        Stock_DataDataContext _db;
        Stock_DataDataContext db
        {
            get
            {
                if (_db == null)
                    _db = new Stock_DataDataContext(VarGeneral.BranchCS);
                return _db;
            }
        }
        int r = 0, c = 0;
        private void GetCurrentRecords(int page, bool vBestSaller)
        {
            try
            {
                
                int romhit = 0;
        string        ItmMainParameter = CAT_ID.ToString();
                if (CAT_ID == 2)
                {

                    int k = 0;

                }
                List<T_Item> dt = new List<T_Item>();
                if (!vBestSaller)
                {
                    if (page == 1)
                    {
                        dt = db.ExecuteQuery<T_Item>("Select TOP " + PageSize + " * from T_Items " + ((!string.IsNullOrEmpty(ItmMainParameter) && ItmMainParameter != "0") ? (" where ItmCat = " + ItmMainParameter + " and ") : " where ") + "  T_Items.InvSaleStoped = 0 ORDER BY Itm_ID", new object[0]).ToList();
                    }
                    else
                    {
                        int PreviouspageLimit = (page - 1) * PageSize;
                        dt = db.ExecuteQuery<T_Item>("Select TOP " + PageSize + " * from T_Items WHERE " + ((!string.IsNullOrEmpty(ItmMainParameter) && ItmMainParameter != "0") ? (" ItmCat = " + ItmMainParameter + " AND ") : " ") + " Itm_ID NOT IN (Select TOP " + PreviouspageLimit + " Itm_ID from T_Items WHERE " + ((!string.IsNullOrEmpty(ItmMainParameter) && ItmMainParameter != "0") ? (" ItmCat = " + ItmMainParameter) : " 1 = 1 ") + "ORDER BY Itm_ID)  and T_Items.InvSaleStoped = 0 ORDER BY Itm_ID", new object[0]).ToList();
                    }
                }
                else if (page == 1)
                {
                    dt = db.ExecuteQuery<T_Item>("SELECT   TOP " + PageSize + "  T_Items.Itm_ID, T_Items.Itm_No, T_Items.ItmCat, T_Items.Arb_Des, T_Items.Eng_Des, T_Items.StartCost, T_Items.AvrageCost, T_Items.LastCost, T_Items.Price1, \r\n                                                                                  T_Items.Price3, T_Items.Price2, T_Items.Price5, T_Items.Price4, T_Items.Price6, T_Items.Unit1, T_Items.Pack1, T_Items.Unit2, T_Items.UntPri2, T_Items.UntPri1, \r\n                                                                                  T_Items.Pack2, T_Items.Unit3, T_Items.Pack3, T_Items.Unit4, T_Items.UntPri3, T_Items.UntPri4, T_Items.Pack4, T_Items.Unit5, T_Items.UntPri5, T_Items.Pack5, \r\n                                                                                  T_Items.DefultUnit, T_Items.DefultVendor, T_Items.OpenQty, T_Items.QtyLvl, T_Items.ItmLoc, T_Items.BarCod1, T_Items.BarCod2, T_Items.BarCod3, \r\n                                                                                  T_Items.BarCod4, T_Items.BarCod5, T_Items.Lot, T_Items.LrnExp, T_Items.DMY, T_Items.ItmTyp, T_Items.DefPack, T_Items.ItmImg, \r\n                                                                                  T_Items.InvSaleStoped, T_Items.InvPaymentStoped, T_Items.InvPaymentReturnStoped, T_Items.FirstCost, T_Items.CompanyID, T_Items.InvSaleReturnStoped, \r\n                                                                                  T_Items.SerialKey,sum(RealQty) as QtyMax\r\n                                                            FROM         T_Items INNER JOIN\r\n                                                                                  T_INVDET ON T_Items.Itm_No = T_INVDET.ItmNo INNER JOIN\r\n                                                                                  T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID\r\n                                                            WHERE T_INVHED.InvTyp = 1 and T_Items.ItmTyp != 1 and T_Items.InvSaleStoped = 0\r\n                                                            Group By T_Items.Itm_ID, T_Items.Itm_No, T_Items.ItmCat, T_Items.Arb_Des, T_Items.Eng_Des, T_Items.StartCost, T_Items.AvrageCost, T_Items.LastCost, T_Items.Price1, \r\n                                                                                  T_Items.Price3, T_Items.Price2, T_Items.Price5, T_Items.Price4, T_Items.Price6, T_Items.Unit1, T_Items.Pack1, T_Items.Unit2, T_Items.UntPri2, T_Items.UntPri1, \r\n                                                                                  T_Items.Pack2, T_Items.Unit3, T_Items.Pack3, T_Items.Unit4, T_Items.UntPri3, T_Items.UntPri4, T_Items.Pack4, T_Items.Unit5, T_Items.UntPri5, T_Items.Pack5, \r\n                                                                                  T_Items.DefultUnit, T_Items.DefultVendor, T_Items.OpenQty, T_Items.QtyLvl, T_Items.ItmLoc, T_Items.BarCod1, T_Items.BarCod2, T_Items.BarCod3, \r\n                                                                                  T_Items.BarCod4, T_Items.BarCod5, T_Items.Lot, T_Items.QtyMax, T_Items.LrnExp, T_Items.DMY, T_Items.ItmTyp, T_Items.DefPack, T_Items.ItmImg, \r\n                                                                                  T_Items.InvSaleStoped, T_Items.InvPaymentStoped, T_Items.InvPaymentReturnStoped, T_Items.FirstCost, T_Items.CompanyID, T_Items.InvSaleReturnStoped, \r\n                                                                                  T_Items.SerialKey\r\n                                                                                  order by QtyMax desc", new object[0]).ToList();
                }
                else
                {
                    int PreviouspageLimit = (page - 1) * PageSize;
                    dt = db.ExecuteQuery<T_Item>("SELECT   TOP " + PageSize + "  T_Items.Itm_ID, T_Items.Itm_No, T_Items.ItmCat, T_Items.Arb_Des, T_Items.Eng_Des, T_Items.StartCost, T_Items.AvrageCost, T_Items.LastCost, T_Items.Price1, \r\n                                                                                  T_Items.Price3, T_Items.Price2, T_Items.Price5, T_Items.Price4, T_Items.Price6, T_Items.Unit1, T_Items.Pack1, T_Items.Unit2, T_Items.UntPri2, T_Items.UntPri1, \r\n                                                                                  T_Items.Pack2, T_Items.Unit3, T_Items.Pack3, T_Items.Unit4, T_Items.UntPri3, T_Items.UntPri4, T_Items.Pack4, T_Items.Unit5, T_Items.UntPri5, T_Items.Pack5, \r\n                                                                                  T_Items.DefultUnit, T_Items.DefultVendor, T_Items.OpenQty, T_Items.QtyLvl, T_Items.ItmLoc, T_Items.BarCod1, T_Items.BarCod2, T_Items.BarCod3, \r\n                                                                                  T_Items.BarCod4, T_Items.BarCod5, T_Items.Lot, T_Items.LrnExp, T_Items.DMY, T_Items.ItmTyp, T_Items.DefPack, T_Items.ItmImg, \r\n                                                                                  T_Items.InvSaleStoped, T_Items.InvPaymentStoped, T_Items.InvPaymentReturnStoped, T_Items.FirstCost, T_Items.CompanyID, T_Items.InvSaleReturnStoped, \r\n                                                                                  T_Items.SerialKey,sum(RealQty) as QtyMax\r\n                                                            FROM         T_Items INNER JOIN\r\n                                                                                  T_INVDET ON T_Items.Itm_No = T_INVDET.ItmNo INNER JOIN\r\n                                                                                  T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID\r\n                                                            WHERE T_INVHED.InvTyp = 1 and T_Items.ItmTyp != 1 and T_Items.InvSaleStoped = 0 AND  Itm_No NOT IN (Select TOP " + PreviouspageLimit + " Itm_ID from T_Items ORDER BY Itm_ID)\r\n                                                            Group By T_Items.Itm_ID, T_Items.Itm_No, T_Items.ItmCat, T_Items.Arb_Des, T_Items.Eng_Des, T_Items.StartCost, T_Items.AvrageCost, T_Items.LastCost, T_Items.Price1, \r\n                                                                                  T_Items.Price3, T_Items.Price2, T_Items.Price5, T_Items.Price4, T_Items.Price6, T_Items.Unit1, T_Items.Pack1, T_Items.Unit2, T_Items.UntPri2, T_Items.UntPri1, \r\n                                                                                  T_Items.Pack2, T_Items.Unit3, T_Items.Pack3, T_Items.Unit4, T_Items.UntPri3, T_Items.UntPri4, T_Items.Pack4, T_Items.Unit5, T_Items.UntPri5, T_Items.Pack5, \r\n                                                                                  T_Items.DefultUnit, T_Items.DefultVendor, T_Items.OpenQty, T_Items.QtyLvl, T_Items.ItmLoc, T_Items.BarCod1, T_Items.BarCod2, T_Items.BarCod3, \r\n                                                                                  T_Items.BarCod4, T_Items.BarCod5, T_Items.Lot, T_Items.QtyMax, T_Items.LrnExp, T_Items.DMY, T_Items.ItmTyp, T_Items.DefPack, T_Items.ItmImg, \r\n                                                                                  T_Items.InvSaleStoped, T_Items.InvPaymentStoped, T_Items.InvPaymentReturnStoped, T_Items.FirstCost, T_Items.CompanyID, T_Items.InvSaleReturnStoped, \r\n                                                                                  T_Items.SerialKey\r\n                                                                                  order by QtyMax desc", new object[0]).ToList();
                }
                int iicnt = 0;
                Size newSize = default(Size);
                try
                {
          //          newSize = new Size(colW, rowH / 2 + rowH * 25 / 100);
                }
                catch
                {
                    newSize = new Size(130, 110);
                }

              
                List<T_Item> g = (from isa in dt
                                  where isa.ItmCat == CAT_ID
                                  select isa).ToList<T_Item>();
                dt = g;
                int irowTeplate = 5;
                int irow = 0;


                for (int j = 0; j <ItemGried.RowCount; j++)
                {




                    {
                        for (int i = 0; i < ItemGried.ColumnCount; i++)
                        {
                            if (iicnt < dt.Count)
                            { POSItem p = new POSItem();
                        p.Item_name.Text = dt[iicnt].Arb_Des;
                        if (dt[iicnt].ItmImg != null)
                            p.Item_Image.Image = Utilites.byteArrayToImage(dt[iicnt].ItmImg.ToArray());
                        ItemGried.Controls.Add(p, i, j);
                        p.Tag = dt[iicnt].Itm_No;
                        p.Item_Click += clickitem;
                        iicnt++;
                  
                            }   else
                            {
                                try
                                {
                                    POSItem c = ItemGried.GetControlFromPosition(i, j) as POSItem;
                                    if (c != null)
                                    {
                                        c.Dispose();
                                      
                                    }
                                          
                                }catch
                                {

                                }


                            }
                        }
                    }
                  
                    romhit += ItemHieght;
                    //  else
                    //rowCell.Visible = false;
                }
                
            }
            catch
            {
            }
          

        }
        public event customMessageHandler itemClick;
        public delegate void customMessageHandler(System.Object sender,
                                        ItemEventArg e);
        public event customMessageHandler PriceChanged;
        public event customMessageHandler Unit_Changed;
        public event customMessageHandler FStatechanged;
        public event customMessageHandler Edit;
        public event customMessageHandler ItemCheckedChanged, TOTCal_ReadY;
        private void clickitem(object sender, ItemEventArg e)
        {
            if(itemClick!=null)
                    itemClick(this, e);
        }

        int col = 0;
        private int CurrentPageIndex = 1;
        private int CurrentPageIndexItmDet = 1;
        private void CalculateTotalPages(List<T_Item> vItemsMain)
        {
            try
            {
                int rowCount = vItemsMain.ToList().Count;
                TotalPage = rowCount / PageSize;
                if (rowCount % PageSize > 0)
                {
                    TotalPage++;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("CalculateTotalPages:", error, enable: true);
                if (TotalPage <= 0)
                {
                    TotalPage = 1;
                }
            }
        }

        public void loadItemsOfCategory(int cat_id, int ID, int pos)
        {
            Cpanel_ID = ID;

            posflag = pos;
            CAT_ID = cat_id;

            col = ItemGried.ColumnCount;
            row = ItemGried.RowCount;
            PageSize = Math.Abs(col * row);
            int rowCount = ItemGried.RowCount;
            TotalPage = rowCount / PageSize;
            if (rowCount % PageSize > 0)
            {
                TotalPage++;
            }

            List<T_Item> items = new List<T_Item>();
            T_CATEGORY ts = db.StockCat(cat_id.ToString());
          
            items = db.StockItemListBycat(cat_id);
            foreach (T_Item t in items)
            {
                POSItem p = new POSItem();
                p.Item_name.Text = (VarGeneral.UserLang == 0 ? t.Arb_Des : t.Eng_Des);
               if(t.ItmImg!=null)
                p.Item_Image.Image = Utilites.byteArrayToImage(t.ItmImg.ToArray());


            }
         //   Tot_Label.Text = (VarGeneral.UserLang == 0 ? "إجمالي" : "Total") + " " + (VarGeneral.UserLang == 0 ? ts.Arb_Des : ts.Eng_Des);
          

        }

        private void Pos_ItemPanel_Load(object sender, EventArgs e)
        {
            if (DesignMode == false)
            {
                this.BackColor = Color.White;
                ItemGried.ColumnCount = (Width / ItemWidth);
                ItemGried.RowCount = (Height/ItemHieght);
                foreach (RowStyle i in ItemGried.RowStyles)
                {
                    i.SizeType = SizeType.Absolute;
                    i.Height = ItemHieght;
                }
                foreach (ColumnStyle i in ItemGried.ColumnStyles)
                {
                    i.SizeType = SizeType.Absolute;
                    i.Width = ItemWidth;

                }
            }
            this.SizeChanged += SizeChadnged;
           

        }

        private void arrowButton2_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndex < TotalPage)
            {

                CurrentPageIndex++;
                GetCurrentRecords(CurrentPageIndex, vBestSaller: false);
            }
        }

        private void arrowButton1_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndex >TotalPage)
            {
                 
                CurrentPageIndex--;
                GetCurrentRecords(CurrentPageIndex, vBestSaller: false);
            }
        }

        private void SizeChadnged(object sender, EventArgs e)
        {
            if (DesignMode == false)
            {
                ItemGried.ColumnCount = (Width / ItemWidth);
                ItemGried.RowCount = (Height / ItemHieght);
                if (ItemGried.RowCount == 0) (ItemGried.RowCount) = 1;
                foreach (RowStyle i in ItemGried.RowStyles)
                {
                    i.SizeType = SizeType.Absolute;
                    i.Height = ItemHieght;
                }
                foreach (ColumnStyle i in ItemGried.ColumnStyles)
                {
                    i.SizeType = SizeType.Absolute;
                    i.Width = ItemWidth;

                }
            }
            FillItmesMain(CAT_ID, false);
        }

        private void ItemGried_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
