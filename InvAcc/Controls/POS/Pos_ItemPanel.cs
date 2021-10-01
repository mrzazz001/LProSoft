using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProShared.Stock_Data;
using ProShared.GeneralM;using ProShared;

namespace InvAcc.Controls.POS
{
    public partial class Pos_ItemPanel : UserControl
    {
        public int ItemWidth = 203;
        public int ItemHieght = 193;
        private int TotalPage = 0;
#pragma warning disable CS0414 // The field 'Pos_ItemPanel.TotalPageDet' is assigned but its value is never used
        private int TotalPageDet = 0;
#pragma warning restore CS0414 // The field 'Pos_ItemPanel.TotalPageDet' is assigned but its value is never used
        public int CAT_ID = 0;
        //   FlowLayoutPanel Flayout2 = new FlowLayoutPanel();
        public int Cpanel_ID;
        public int PosFlag = 0;
        private int PageSize = 10;
#pragma warning disable CS0414 // The field 'Pos_ItemPanel.PageSizeDet' is assigned but its value is never used
        private int PageSizeDet = 10;
#pragma warning restore CS0414 // The field 'Pos_ItemPanel.PageSizeDet' is assigned but its value is never used
        int posflag = 0;
#pragma warning disable CS0414 // The field 'Pos_ItemPanel.rearrange' is assigned but its value is never used
        int rearrange = 0;
#pragma warning restore CS0414 // The field 'Pos_ItemPanel.rearrange' is assigned but its value is never used
        private int row = 0;
#pragma warning disable CS0414 // The field 'Pos_ItemPanel.rowH' is assigned but its value is never used
        private int rowH = 0;
#pragma warning restore CS0414 // The field 'Pos_ItemPanel.rowH' is assigned but its value is never used
        public int ItemCategory = 0;
        public  void FillItmesMain(int Cat_Id, bool vBestSaller)
        {
#pragma warning disable CS1717 // Assignment made to same variable; did you mean to assign something else?
            CAT_ID = CAT_ID;
#pragma warning restore CS1717 // Assignment made to same variable; did you mean to assign something else?
            ItemsGride.Controls.Clear();
            col = ItemsGride.ColumnCount;
            row = ItemsGride.RowCount;
            PageSize = Math.Abs(col * row);
            List<T_Item> vItemsMain = new List<T_Item>();
            Stock_DataDataContext dbc = new Stock_DataDataContext();
            vItemsMain = (from t in dbc.T_Items
                          where t.ItmTyp != (int?)1 && !t.InvSaleStoped.Value && t.ItmCat == CAT_ID
                          orderby t.Itm_ID

                          select t).ToList();
#pragma warning disable CS0472 // The result of the expression is always 'true' since a value of type 'int' is never equal to 'null' of type 'int?'
            if (Cat_Id != null)
#pragma warning restore CS0472 // The result of the expression is always 'true' since a value of type 'int' is never equal to 'null' of type 'int?'
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
#pragma warning disable CS0414 // The field 'Pos_ItemPanel.r' is assigned but its value is never used
#pragma warning disable CS0414 // The field 'Pos_ItemPanel.c' is assigned but its value is never used
        int r = 0, c = 0;
#pragma warning restore CS0414 // The field 'Pos_ItemPanel.c' is assigned but its value is never used
#pragma warning restore CS0414 // The field 'Pos_ItemPanel.r' is assigned but its value is never used
        private void GetCurrentRecords(int page, bool vBestSaller)
        {
            try
            {
                
                int romhit = 0;
        string        ItmMainParameter = CAT_ID.ToString();
                if (CAT_ID == 2)
                {

#pragma warning disable CS0219 // The variable 'k' is assigned but its value is never used
                    int k = 0;
#pragma warning restore CS0219 // The variable 'k' is assigned but its value is never used

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
#pragma warning disable CS0219 // The variable 'irowTeplate' is assigned but its value is never used
                int irowTeplate = 5;
#pragma warning restore CS0219 // The variable 'irowTeplate' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'irow' is assigned but its value is never used
                int irow = 0;
#pragma warning restore CS0219 // The variable 'irow' is assigned but its value is never used


                for (int j = 0; j <ItemsGride.RowCount; j++)
                {




                    {
                        for (int i = 0; i < ItemsGride.ColumnCount; i++)
                        {
                            if (iicnt < dt.Count)
                            { POSItem p = new POSItem();
                        p.Item_name.Text = dt[iicnt].Arb_Des;
                        if (dt[iicnt].ItmImg != null)
                            p.Item_Image.Image = Utilites.byteArrayToImage(dt[iicnt].ItmImg.ToArray());
                        ItemsGride.Controls.Add(p, i, j);
                        p.Tag = dt[iicnt].Itm_No;
                        p.Item_Click += clickitem;
                        iicnt++;
                  
                            }   else
                            {
                                try
                                {
                                    POSItem c = ItemsGride.GetControlFromPosition(i, j) as POSItem;
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
#pragma warning disable CS0067 // The event 'Pos_ItemPanel.PriceChanged' is never used
        public event customMessageHandler PriceChanged;
#pragma warning restore CS0067 // The event 'Pos_ItemPanel.PriceChanged' is never used
#pragma warning disable CS0067 // The event 'Pos_ItemPanel.Unit_Changed' is never used
        public event customMessageHandler Unit_Changed;
#pragma warning restore CS0067 // The event 'Pos_ItemPanel.Unit_Changed' is never used
#pragma warning disable CS0067 // The event 'Pos_ItemPanel.FStatechanged' is never used
        public event customMessageHandler FStatechanged;
#pragma warning restore CS0067 // The event 'Pos_ItemPanel.FStatechanged' is never used
#pragma warning disable CS0067 // The event 'Pos_ItemPanel.Edit' is never used
        public event customMessageHandler Edit;
#pragma warning restore CS0067 // The event 'Pos_ItemPanel.Edit' is never used
#pragma warning disable CS0067 // The event 'Pos_ItemPanel.TOTCal_ReadY' is never used
#pragma warning disable CS0067 // The event 'Pos_ItemPanel.ItemCheckedChanged' is never used
        public event customMessageHandler ItemCheckedChanged, TOTCal_ReadY;
#pragma warning restore CS0067 // The event 'Pos_ItemPanel.ItemCheckedChanged' is never used
#pragma warning restore CS0067 // The event 'Pos_ItemPanel.TOTCal_ReadY' is never used
        private void clickitem(object sender, ItemEventArg e)
        {
            if(itemClick!=null)
                    itemClick(this, e);
        }

        int col = 0;
        private int CurrentPageIndex = 1;
#pragma warning disable CS0414 // The field 'Pos_ItemPanel.CurrentPageIndexItmDet' is assigned but its value is never used
        private int CurrentPageIndexItmDet = 1;
#pragma warning restore CS0414 // The field 'Pos_ItemPanel.CurrentPageIndexItmDet' is assigned but its value is never used
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

  
        private void Pos_ItemPanel_Load(object sender, EventArgs e)
        {
            if (DesignMode == false)
            {
                this.BackColor = Color.White;
                ItemsGride.ColumnCount = (Width / ItemWidth);
                ItemsGride.RowCount = (Height/ItemHieght);
                foreach (RowStyle i in ItemsGride.RowStyles)
                {
                    i.SizeType = SizeType.Absolute;
                    i.Height = ItemHieght;
                }
                foreach (ColumnStyle i in ItemsGride.ColumnStyles)
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
                ItemsGride.ColumnCount = (Width / ItemWidth);
                ItemsGride.RowCount = (Height / ItemHieght);
                if (ItemsGride.RowCount == 0) (ItemsGride.RowCount) = 1;
                foreach (RowStyle i in ItemsGride.RowStyles)
                {
                    i.SizeType = SizeType.Absolute;
                    i.Height = ItemHieght;
                }
                foreach (ColumnStyle i in ItemsGride.ColumnStyles)
                {
                    i.SizeType = SizeType.Absolute;
                    i.Width = ItemWidth;

                }
            }
            FillItmesMain(CAT_ID, false);
        }
      
        private void ItemsGride_Paint(object sender, PaintEventArgs e)
        {
         
        }
    }
}
