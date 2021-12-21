using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProShared.Stock_Data;
using ProShared.GeneralM;
using ProShared;
using InvAcc.Forms;

namespace InvAcc.Controls.POS
{
    public partial class POS_ItemsGride : UserControl
    {
        public int ItemWidth = 115;
        public int ItemHieght = 148;
        private int TotalPage = 0;
#pragma warning disable CS0414 // The field 'POS_ItemsGride.TotalPageDet' is assigned but its value is never used
        private int TotalPageDet = 0;
#pragma warning restore CS0414 // The field 'POS_ItemsGride.TotalPageDet' is assigned but its value is never used
        int xx = 0;
        public int CAT_ID
        {
            get { return xx; }
            set
            {
                xx = value;

            }
        }
        //   FlowLayoutPanel Flayout2 = new FlowLayoutPanel();
        public int Cpanel_ID;
        public int PosFlag = 0;
        private int PageSize = 10;
#pragma warning disable CS0414 // The field 'POS_ItemsGride.PageSizeDet' is assigned but its value is never used
        private int PageSizeDet = 10;
#pragma warning restore CS0414 // The field 'POS_ItemsGride.PageSizeDet' is assigned but its value is never used
        int posflag = 0;
#pragma warning disable CS0414 // The field 'POS_ItemsGride.rearrange' is assigned but its value is never used
        int rearrange = 0;
#pragma warning restore CS0414 // The field 'POS_ItemsGride.rearrange' is assigned but its value is never used
        private int row = 0;
#pragma warning disable CS0414 // The field 'POS_ItemsGride.rowH' is assigned but its value is never used
        private int rowH = 0;
#pragma warning restore CS0414 // The field 'POS_ItemsGride.rowH' is assigned but its value is never used
        public int ItemCategory = 0;
        public int mode = 0;
        // The placeholder text:
#pragma warning disable CS0414 // The field 'POS_ItemsGride.watermark' is assigned but its value is never used
        string watermark = "Type here...to Filter";
#pragma warning restore CS0414 // The field 'POS_ItemsGride.watermark' is assigned but its value is never used
        public void FillItmesMain(int Cat_Id, bool vBestSaller)
        {

            //    if(vItemsMain.Count>1)
            GetCurrentRecords(1, vBestSaller);
            //   else
            //  { superGridControl1.PrimaryGrid.Columns.Clear();
            //    superGridControl1.PrimaryGrid.Rows.Clear();
            //}
        }
        public void FillCatsMain(int Cat_Id, bool vBestSaller)
        {
            CAT_ID = CAT_ID;

            List<T_CATEGORY> vItemsMain = new List<T_CATEGORY>();
            Stock_DataDataContext db = new Stock_DataDataContext();
            try
            {
                vItemsMain = (from t in db.T_CATEGORies


                              select t).ToList();
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            }
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            { }
            CurrentPageIndex = 1;
            CurrentPageIndexItmDet = 1;
            CalculateTotalPages(vItemsMain);
            //    if(vItemsMain.Count>1)
            GetCurrentRecordscats(CurrentPageIndex, vBestSaller);
            //   else
            //  { superGridControl1.PrimaryGrid.Columns.Clear();
            //    superGridControl1.PrimaryGrid.Rows.Clear();
            //}
        }
        string like = "";
        public void fillcat(int cat_it0)

        {
            CAT_ID = cat_it0;
            CurrentPageIndex = 1;
            maxcount = db.ExecuteQuery<T_Item>("Select * From T_Items where  ItmCat ='" + cat_it0.ToString() + "'").Count();

            currentcolumn = 0;
            curentrow = 0;

            setinitial();
            fill(CAT_ID, false);

        }
        public string filtertext = "";
        public void sedfilter(string txt)
        {
            CurrentPageIndex = 1;
            filtertext = txt;
            currentcolumn = 0;
            curentrow = 0;
            ItemsGride.Controls.Clear();
            setinitial();

            if (string.IsNullOrEmpty(filtertext))
            {
                sql = _sql;
                maxcount = db.ExecuteQuery<T_Item>("Select * From T_Items where ItmCat='" + CAT_ID.ToString() + "'").Count();
                like = "";
            }
            else
            {
                T_Item t = new T_Item();

                like = filtertext;
                sql = _sql.Replace("Test", "Test  WHERE Arb_Des LIKE '%xxxxxxxx%' Or  Eng_Des LIKE '%xxxxxxxx%' OR  BarCod1 LIKE '%xxxxxxxx%' OR  BarCod2 LIKE '%xxxxxxxx%' OR  BarCod3 LIKE '%xxxxxxxx%' OR  BarCod3 LIKE '%xxxxxxxx%' OR  BarCod4 LIKE '%xxxxxxxx%' OR  BarCod5 LIKE '%xxxxxxxx%'".Replace("xxxxxxxx", like));
                maxcount = db.ExecuteQuery<T_Item>("Select * From T_Items where ItmCat='" + CAT_ID.ToString() + "' and" + " Arb_Des LIKE '%xxxx%'  Or  Eng_Des LIKE '%xxxxxxxx%' OR  BarCod1 LIKE '%xxxxxxxx%' OR  BarCod2 LIKE '%xxxxxxxx%' OR  BarCod3 LIKE '%xxxxxxxx%' OR  BarCod3 LIKE '%xxxxxxxx%' OR  BarCod4 LIKE '%xxxxxxxx%' OR  BarCod5 LIKE '%xxxxxxxx%'".Replace("xxxx", like)).Count();
                setinitial();



            }

            fill(CAT_ID, false);

        }
        public void TextBoxFilter_TextChanged(object sender, EventArgs e)
        {
            CurrentPageIndex = 1;

            currentcolumn = 0;
            curentrow = 0;

            setinitial();
            if (string.IsNullOrEmpty(filtertext))
            {
                sql = _sql;
                maxcount = db.MaxCatNo;
                like = "";
            }
            else
            {

                like = filtertext;
                sql = _sql.Replace("Test", "Test  WHERE Arb_Des LIKE '%xxxxxxxx%'".Replace("xxxxxxxx", like)); maxcount = db.ExecuteQuery<T_Item>("Select * From T_Items where  Arb_Des LIKE '%xxxx%'".Replace("xxxx", like)).Count();
                maxcount = db.ExecuteQuery<T_Item>("Select * From T_Items where  Arb_Des LIKE '%xxxx%'".Replace("xxxx", like)).Count();
                setinitial();



            }
            //TexBoxFilter.Invalidate();
            fill(0, false);


        }


        public POS_ItemsGride()
        {
            InitializeComponent();
            try
            {


                maxcount = db.MaxItemNo;
                _sql = sql;

                POSItem f = new POSItem();
                ItemHieght = f.Height;
                ItemWidth = f.Width;

                gridwidth = this.Width;
                gridheight = this.Height;
                if (ItemWidth != 0)
                    ItemsGride.ColumnCount = (gridwidth / ItemWidth);
                if (ItemHieght != 0)
                    ItemsGride.RowCount = (gridheight / ItemHieght);
                if (ItemWidth != 0)

                    col = (gridwidth / ItemWidth);
                if (ItemHieght != 0)

                    row = (gridheight / ItemHieght);
                setinitial();

                f.Dispose();
                {


                    this.BackColor = Color.White;

                }
                this.SizeChanged += SizeChadnged;
                if (DesignMode == false)
                {
                    t_CATEGORYes = new List<T_CATEGORY>();
                }
            }
            catch { }

        }
        List<T_CATEGORY> t_CATEGORYes;
        public Stock_DataDataContext _db;
        Stock_DataDataContext db
        {
            get
            {
                return VarGeneral.dbshared;
            }
        }




#pragma warning disable CS0414 // The field 'POS_ItemsGride.r' is assigned but its value is never used
#pragma warning disable CS0414 // The field 'POS_ItemsGride.c' is assigned but its value is never used
        int r = 0, c = 0;
#pragma warning restore CS0414 // The field 'POS_ItemsGride.c' is assigned but its value is never used
#pragma warning restore CS0414 // The field 'POS_ItemsGride.r' is assigned but its value is never used
        string _sql = "";
        string sql = @"DECLARE @recsPerPage int
DECLARE @page int
SET @recsPerPage = PageSize
SET @page = PageNumber

SELECT*
FROM(
   SELECT ROW_NUMBER() OVER (ORDER BY Itm_ID) As RowNum, * 
   FROM Test) As a
WHERE RowNum BETWEEN 1+(@recsPerPage)* (@page-1) AND @recsPerPage*(@page)";
        int curentrow = 0, currentcolumn = 0;
        private void GetCurrentRecords(int page, bool vBestSaller)
        {
            try
            {


                int romhit = 0;
                string ItmMainParameter = CAT_ID.ToString();
                if (CAT_ID == 2)
                {

#pragma warning disable CS0219 // The variable 'k' is assigned but its value is never used
                    int k = 0;
#pragma warning restore CS0219 // The variable 'k' is assigned but its value is never used

                }
                List<T_Item> dt = new List<T_Item>();
                int pd = PageSize;
                if (FrmInvSalePoint.ShowBackButtons) PageSize--;
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
                string sqll = "";
                if (like == "")
                    sqll = sql.Replace("PageSize", PageSize.ToString()).Replace("PageNumber", CurrentPageIndex.ToString()).Replace("Test", "T_Items where ItmCat='" + CAT_ID.ToString() + "'");
                else
                {
                    sqll = sql.Replace("PageSize", PageSize.ToString()).Replace("PageNumber", CurrentPageIndex.ToString()).Replace("Test", "T_Items");
                    sqll = sqll.Replace("WHERE", "where ItmCat='" + CAT_ID.ToString() + "' and ");


                }
                dt = db.ExecuteQuery<T_Item>(sqll, new object[0]).ToList();
                if (like != "")
                {
                    maxcount = db.ExecuteQuery<T_Item>("Select * From T_Items where " + "ItmCat='" + CAT_ID.ToString() + "'" + " and  Arb_Des LIKE '%xxxx%'  Or  Eng_Des LIKE '%xxxxxxxx%' OR  BarCod1 LIKE '%xxxxxxxx%' OR  BarCod2 LIKE '%xxxxxxxx%' OR  BarCod3 LIKE '%xxxxxxxx%' OR  BarCod3 LIKE '%xxxxxxxx%' OR  BarCod4 LIKE '%xxxxxxxx%' OR  BarCod5 LIKE '%xxxxxxxx%'".Replace("xxxx", like)).Count();
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


                List<T_Item> g = null;

                //   if (like == "")
                g = (from isa in dt
                     where isa.ItmCat == CAT_ID
                     select isa).ToList<T_Item>();
                //else
                //    g = (from isa in dt
                //         where isa.ItmCat == CAT_ID && (VarGeneral.currentintlanguage == 0 ? isa.Arb_Des.Contains(like) : isa.Eng_Des.Contains(like))
                //         select isa).ToList<T_Item>();
                dt = g;
#pragma warning disable CS0219 // The variable 'irowTeplate' is assigned but its value is never used
                int irowTeplate = 5;
#pragma warning restore CS0219 // The variable 'irowTeplate' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'irow' is assigned but its value is never used
                int irow = 0;

#pragma warning restore CS0219 // The variable 'irow' is assigned but its value is never used

                {




                    {
                        for (int i = 0; i < dt.Count; i++)
                        {

                            {


                                POSItem p = new POSItem();
                                p.Item_name.Text = (VarGeneral.currentintlanguage == 0 ? dt[iicnt].Arb_Des : dt[iicnt].Eng_Des);
                                if (dt[i].ItmImg != null)
                                    p.Item_Image.Image = Utilites.byteArrayToImage(dt[iicnt].ItmImg.ToArray());
                                p.Item_Price.Text = dt[i].UntPri1.ToString() + (VarGeneral.currentintlanguage == 0 ? "SR" :
                                "ر.س");
                                p.Tag = dt[i].Itm_No;
                                p.Dock = DockStyle.Fill;
                                ItemsGride.Controls.Add(p, currentcolumn, curentrow);
                                increment();
                                p.Refresh();

                                p.Item_Click += clickitem;
                                iicnt++;

                            }
                        }
                    }

                    romhit += ItemHieght;
                    //  else
                    //rowCell.Visible = false;
                }
                PageSize = pd;
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
            }


        }

        private void increment()
        {
            if (currentcolumn < ItemsGride.ColumnCount)
                currentcolumn++;
            else
            {
                currentcolumn = 0; curentrow++;
                if (curentrow >= ItemsGride.RowCount)
                {
                    ItemsGride.RowCount++;
                    RowStyle c = new RowStyle();
                    c.SizeType = SizeType.Absolute;
                    c.Height = ItemHieght;
                    ItemsGride.RowStyles.Add(c);

                }
            }
        }

        int maxcount = 0;

        private void GetCurrentRecordscats(int page, bool vBestSaller)
        {
            try
            {
                CAT_ID = CAT_ID;

                int romhit = 0;
                string ItmMainParameter = CAT_ID.ToString();
                if (CAT_ID == 2)
                {

#pragma warning disable CS0219 // The variable 'k' is assigned but its value is never used
                    int k = 0;
#pragma warning restore CS0219 // The variable 'k' is assigned but its value is never used

                }
                List<T_CATEGORY> dt = new List<T_CATEGORY>();
                int iicnt = 0;
                maxcount = db.MaxCatNo;
                string sqll = "";
                if (PageSize == 0) PageSize = 1;
                sqll = sql.Replace("PageSize", PageSize.ToString()).Replace("PageNumber", CurrentPageIndex.ToString()).Replace("Itm_ID", "CAT_ID").Replace("Test", "T_CATEGORY");


                dt = db.ExecuteQuery<T_CATEGORY>(sqll, new object[0]).ToList();
                if (like != "")
                {
                    maxcount = db.ExecuteQuery<T_Item>("Select * From T_CATEGORY WHERE  Arb_Des LIKE '%xxxx%'".Replace("xxxx", like)).Count();
                }



                Size newSize = default(Size);
                try
                {
                    //          newSize = new Size(colW, rowH / 2 + rowH * 25 / 100);
                }
                catch
                {
                    newSize = new Size(130, 110);
                }


#pragma warning disable CS0219 // The variable 'g' is assigned but its value is never used
                List<T_CATEGORY> g = null;
#pragma warning restore CS0219 // The variable 'g' is assigned but its value is never used

#pragma warning disable CS0219 // The variable 'irowTeplate' is assigned but its value is never used
                int irowTeplate = 5;
#pragma warning restore CS0219 // The variable 'irowTeplate' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'irow' is assigned but its value is never used
                int irow = 0;
#pragma warning restore CS0219 // The variable 'irow' is assigned but its value is never used
                {



                    if (dt.Count > 4)
                    { }
                    {
                        for (int i = 0; i < dt.Count; i++)
                        {

                            {


                                POSItem p = new POSItem();
                                p.Item_name.Text = (VarGeneral.currentintlanguage == 0 ? dt[iicnt].Arb_Des : dt[iicnt].Eng_Des);
                                if (dt[i].CatImage != null)
                                    p.Item_Image.Image = Utilites.byteArrayToImage(dt[iicnt].CatImage.ToArray());
                                p.Item_Price.Visible = false;

                                p.Tag = dt[i].CAT_ID;
                                p.Dock = DockStyle.Fill;
                                ItemsGride.Controls.Add(p, currentcolumn, curentrow);
                                increment();
                                p.Refresh();

                                p.Item_Click += clickitem;
                                iicnt++;

                            }
                        }
                    }

                    romhit += ItemHieght;
                    //  else
                    //rowCell.Visible = false;
                }

            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
            }


        }
        string _selectStatement = "";
        string _SelectS = "";
        public string SelectS
        {
            get
            {
                if (PagesEnable)
                {
                    string s = selectStatement;
                    s = s.Replace("Select ", "Select Top " + PageSize);
                    return s;
                }
                else
                    return selectStatement;
            }
        }
        public string selectStatement
        {
            get { return _selectStatement; }
            set
            {
                _selectStatement = value;
                _SelectS = value;
            }
        }
        public bool HorizantalBarVisable
        {
            get
            {
                return ItemsGride.HorizontalScroll.Visible;
            }
            set
            {
                HorizontalScroll.Visible = value;
                ItemsGride.HorizontalScroll.Enabled = false;
                ItemsGride.HorizontalScroll.Visible = false;
            }
        }
        bool enablepages = false;
        public bool PagesEnable
        {
            get { return enablepages; }
            set
            {
                enablepages = value;

                {
                }

            }
        }
        bool _EnableFilterSearch = true;
        public bool EnableFilterSearch
        {
            get { return _EnableFilterSearch; }
            set
            {
                _EnableFilterSearch = value;
                //TexBoxFilter.Visible = value;
            }
        }
        public event customMessageHandler itemClick;
        public event customMessageHandler itemAddedToGried;
        public event customMessageHandler BackToCategories;
        public delegate void customMessageHandler(System.Object sender,
                                        ItemEventArg e);
#pragma warning disable CS0067 // The event 'POS_ItemsGride.PriceChanged' is never used
        public event customMessageHandler PriceChanged;
#pragma warning restore CS0067 // The event 'POS_ItemsGride.PriceChanged' is never used
#pragma warning disable CS0067 // The event 'POS_ItemsGride.Unit_Changed' is never used
        public event customMessageHandler Unit_Changed;
#pragma warning restore CS0067 // The event 'POS_ItemsGride.Unit_Changed' is never used
#pragma warning disable CS0067 // The event 'POS_ItemsGride.FStatechanged' is never used
        public event customMessageHandler FStatechanged;
#pragma warning restore CS0067 // The event 'POS_ItemsGride.FStatechanged' is never used
#pragma warning disable CS0067 // The event 'POS_ItemsGride.Edit' is never used
        public event customMessageHandler Edit;
#pragma warning restore CS0067 // The event 'POS_ItemsGride.Edit' is never used
#pragma warning disable CS0067 // The event 'POS_ItemsGride.TOTCal_ReadY' is never used
#pragma warning disable CS0067 // The event 'POS_ItemsGride.ItemCheckedChanged' is never used
        public event customMessageHandler ItemCheckedChanged, TOTCal_ReadY;
#pragma warning restore CS0067 // The event 'POS_ItemsGride.ItemCheckedChanged' is never used
#pragma warning restore CS0067 // The event 'POS_ItemsGride.TOTCal_ReadY' is never used
        bool isPageBackOn = false;
        private void clickitem(object sender, ItemEventArg e)
        {
            Program.min();

            if (mode == 0 || !FrmInvSalePoint.ShowBackButtons)
            {
                if (itemClick != null)
                    itemClick(this, e);
            }
            else
            {
                mode = 0;
                CAT_ID = int.Parse(e.item_No.ToString());
                fill(CAT_ID, false);
            }
        }

        int col = 0;
        private int CurrentPageIndex = 1;
#pragma warning disable CS0414 // The field 'POS_ItemsGride.CurrentPageIndexItmDet' is assigned but its value is never used
        private int CurrentPageIndexItmDet = 1;
#pragma warning restore CS0414 // The field 'POS_ItemsGride.CurrentPageIndexItmDet' is assigned but its value is never used
        private void CalculateTotalPages(int cc)
        {
            try
            {
                int rowCount = cc;
                TotalPage = calc(rowCount, PageSize);
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
        private void CalculateTotalPages(List<T_CATEGORY> vItemsMain)
        {
            try
            {
                int rowCount = vItemsMain.ToList().Count;
                if (PageSize != 0) TotalPage = calc(rowCount, PageSize);
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

            col = ItemsGride.ColumnCount;
            row = ItemsGride.RowCount;
            //  PageSize = Math.Abs(col * row);

            int rowCount = ItemsGride.RowCount;
            if (PageSize != 0)
                TotalPage = calc(rowCount, PageSize);
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
                if (t.ItmImg != null)
                    p.Item_Image.Image = Utilites.byteArrayToImage(t.ItmImg.ToArray());


            }
            //   Tot_Label.Text = (VarGeneral.UserLang == 0 ? "إجمالي" : "Total") + " " + (VarGeneral.UserLang == 0 ? ts.Arb_Des : ts.Eng_Des);


        }

        private void Pos_ItemPanel_Load(object sender, EventArgs e)
        {

        }

        private void arrowButton2_Click(object sender, EventArgs e)
        {

        }

        private void arrowButton1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void turnButton1_Click(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.ItemsGride = new System.Windows.Forms.TableLayoutPanel();
            this.But_Back = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ItemsGride.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ItemsGride
            // 
            this.ItemsGride.AutoSize = true;
            this.ItemsGride.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ItemsGride.BackColor = System.Drawing.Color.White;
            this.ItemsGride.ColumnCount = 1;
            this.ItemsGride.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ItemsGride.Controls.Add(this.But_Back, 0, 0);
            this.ItemsGride.Dock = System.Windows.Forms.DockStyle.Top;
            this.ItemsGride.Location = new System.Drawing.Point(0, 0);
            this.ItemsGride.Margin = new System.Windows.Forms.Padding(0);
            this.ItemsGride.Name = "ItemsGride";
            this.ItemsGride.RowCount = 1;
            this.ItemsGride.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ItemsGride.Size = new System.Drawing.Size(148, 115);
            this.ItemsGride.TabIndex = 0;
            this.ItemsGride.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ItemsGride_Scroll);
            this.ItemsGride.SizeChanged += new System.EventHandler(this.ItemsGride_SizeChanged);
            this.ItemsGride.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.ItemsGride_ControlRemoved);
            this.ItemsGride.Paint += new System.Windows.Forms.PaintEventHandler(this.ItemsGride_Paint);
            // 
            // But_Back
            // 
            this.But_Back.BackColor = System.Drawing.Color.MediumTurquoise;
            this.But_Back.Dock = System.Windows.Forms.DockStyle.Fill;
            this.But_Back.Location = new System.Drawing.Point(3, 3);
            this.But_Back.Name = "But_Back";
            this.But_Back.Size = new System.Drawing.Size(142, 109);
            this.But_Back.TabIndex = 1;
            this.But_Back.Text = "Back";
            this.But_Back.UseVisualStyleBackColor = false;
            this.But_Back.Click += new System.EventHandler(this.But_Back_Click);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.ItemsGride);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(148, 115);
            this.panel2.TabIndex = 2;
            this.panel2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ItemsGride_Scroll);
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // POS_ItemsGride
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "POS_ItemsGride";
            this.Size = new System.Drawing.Size(148, 115);
            this.Load += new System.EventHandler(this.Pos_ItemPanel_Load);
            this.SizeChanged += new System.EventHandler(this.POS_ItemsGride_SizeChanged);
            this.ItemsGride.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        private void buttonRotate1_Load(object sender, EventArgs e)
        {

        }
        int gridwidth = 0, gridheight = 0;
        private void SizeChadnged(object sender, EventArgs e)
        {


        }
        void calcolsm()
        {
            int col = ((this.Width / ItemWidth));

        }

        void setinitial()
        {


            try
            {
                if (mode == 0)
                    maxcount = db.ExecuteQuery<T_Item>("Select * From T_Items where  ItmCat ='" + CAT_ID.ToString() + "'").Count();
                else
                    maxcount = db.ExecuteQuery<T_CATEGORY>("Select * From T_CATEGORY ").Count();

                CalculateTotalPages(maxcount);
                curentrow = 0;
                currentcolumn = 0;
                CurrentPageIndex = 1;
                gridwidth = this.Width;

                gridheight = this.Height - getPanelSize();
                {
                    if (ItemWidth == 0) return;
                    if (ItemHieght == 0) return;


                    col = ((gridwidth) / ItemWidth);
                    ItemsGride.ColumnCount = col;
                    row = (gridheight / ItemHieght);
                    ItemsGride.ColumnCount = (gridwidth / ItemWidth);
                    ItemsGride.RowCount = (gridheight / ItemHieght);
                    ItemsGride.Controls.Clear();

                    col = (gridwidth / ItemWidth);
                    row = (gridheight / ItemHieght);
                    row = (row == 0 ? 1 : row);
                    ItemsGride.RowStyles.Clear();
                    for (int i = 0; i < row; i++)
                    {
                        RowStyle c = new RowStyle();
                        c.SizeType = SizeType.Absolute;
                        c.Height = ItemHieght;
                        ItemsGride.RowStyles.Add(c);
                    }
                    if (col == 0) return;

                    float cc = (float)100 / col;
                    ItemsGride.ColumnStyles.Clear();
                    for (int i = 0; i < col; i++)
                    {
                        ColumnStyle c = new ColumnStyle();
                        c.SizeType = SizeType.Percent;
                        c.Width = cc;
                        ItemsGride.ColumnStyles.Add(c);
                    }
                    PageSize = Math.Abs(col * row);
                    setbackButton();

                    if (PageSize != 0)

                    {
                        numberofpages = calc(maxcount, PageSize);


                    }

                }
            }
            catch { }
        }
        int calc(int m, int p)
        {
            int d = m / p;
            float v = (float)m / p;
            int kk = (int)v;
            if (v - kk > 0) d++;
            return d;

        }
        private int getPanelSize()
        {
            return 0;
        }

        private void setbackButton()
        {

            if (FrmInvSalePoint.ShowBackButtons)
            {
                if (mode == 0)
                {
                    ItemsGride.Controls.Add(But_Back, 0, 0);
                    increment();
                }
            }
        }

        private void But_NextPage_Click(object sender, EventArgs e)
        {
            if (PageSize == 0) return;

            numberofpages = calc(maxcount, PageSize);
            if (CurrentPageIndex < numberofpages)
            {

                CurrentPageIndex++;
                if (mode == 0) GetCurrentRecords(CurrentPageIndex, vBestSaller: false);
                else

                    GetCurrentRecordscats(CurrentPageIndex, vBestSaller: false);
            }
        }

        private void But_PrivPage_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndex > 1)
            {


                CurrentPageIndex--;
                GetCurrentRecords(CurrentPageIndex, vBestSaller: false);
            }
        }

        private void POS_ItemsGride_SizeChanged(object sender, EventArgs e)
        {

            try
            {

                try { setinitial(); } catch { }
                try
                {
                    CurrentPageIndex = 1;

                    currentcolumn = 0;
                    curentrow = 0;



                    fill(CAT_ID, false);

                    setscrol();
                }
                catch { }
            }
            catch { }
            //TexBoxFilter.Size = new Size(200, TexBoxFilter.Size.Height);
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        VScrollProperties vScrollBar1;
        void setscrol()

        {
            vScrollBar1 = ItemsGride.VerticalScroll;
            if (this.vScrollBar1.Visible)
            {
                this.vScrollBar1.Minimum = 0;
                this.vScrollBar1.SmallChange = this.panel2.Height / 20;
                this.vScrollBar1.LargeChange = this.panel2.Height / 10;

                this.vScrollBar1.Maximum = this.ItemsGride.Size.Height - ItemsGride.ClientSize.Height; //step 1



                this.vScrollBar1.Maximum += this.vScrollBar1.LargeChange; //step 3
            }
        }

        private void ItemsGride_SizeChanged(object sender, EventArgs e)
        {

        }

        private void ItemsGride_ControlRemoved(object sender, ControlEventArgs e)
        {

        }

        private void But_Back_Click(object sender, EventArgs e)
        {
            if (mode == 0)
            { mode = 1; }
            else
            { mode = 0; }
            fill(0, false);

        }

        int numberofpages = 1;
        private void ItemsGride_Scroll(object sender, ScrollEventArgs e)
        {
            VScrollProperties vs = panel2.VerticalScroll;
            if (e.NewValue == vs.Maximum - vs.LargeChange + 1)
            {
                But_NextPage_Click(null, null);
            }



        }

#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        public async void fill(int cAT_ID, bool v)
        {
            ItemsGride.RowStyles.Clear();
            setinitial();
            CAT_ID = cAT_ID;


            for (int i = 0; i < ItemsGride.RowCount; i++)
            {
                RowStyle c = new RowStyle();
                c.SizeType = SizeType.Absolute;
                c.Height = ItemHieght;
                ItemsGride.RowStyles.Add(c);
            }
            float ff = (float)100 / col;
            ItemsGride.ColumnStyles.Clear();
            for (int i = 0; i < ItemsGride.ColumnCount; i++)
            {
                ColumnStyle c = new ColumnStyle();
                c.SizeType = SizeType.Percent;
                c.Width = ff;
                ItemsGride.ColumnStyles.Add(c);
            }
            try
            {
                if (DesignMode == false)
                {
                    CAT_ID = CAT_ID;


                    if (mode == 0)
                        GetCurrentRecords(CurrentPageIndex, false);
                    else
                        GetCurrentRecordscats(CurrentPageIndex, false);
                    if (PageSize != 0)
                        numberofpages = calc(maxcount, PageSize);
                    if (CurrentPageIndex < numberofpages)
                    {
                        //CurrentPageIndex++;

                        //if (mode == 0)
                        //    GetCurrentRecords(CurrentPageIndex, false);
                        //else
                        //    GetCurrentRecordscats(CurrentPageIndex, false);

                    }
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            }
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            { }

        }
        private void ssss(int page, bool vBestSaller)
        {
            try
            {

                int romhit = 0;
                string ItmMainParameter = CAT_ID.ToString();
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


                for (int j = 0; j < ItemsGride.RowCount; j++)
                {


                    int i = 0;
                    if (FrmInvSalePoint.ShowBackButtons && j == 0) i = 1;
                    {
                        for (; i < ItemsGride.ColumnCount; i++)
                        {
                            if (iicnt < dt.Count)
                            {
                                POSItem p = new POSItem();
                                p.Item_name.Text = dt[iicnt].Arb_Des;
                                if (dt[iicnt].ItmImg != null)
                                    p.Item_Image.Image = Utilites.byteArrayToImage(dt[iicnt].ItmImg.ToArray());
                                ItemsGride.Controls.Add(p, i, j);
                                p.Tag = dt[iicnt].Itm_No;
                                p.Item_Click += clickitem;
                                iicnt++;

                            }
                            else
                            {
                                try
                                {
                                    POSItem c = ItemsGride.GetControlFromPosition(i, j) as POSItem;
                                    if (c != null)
                                    {
                                        c.Dispose();

                                    }

                                }
                                catch
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
        int pageindex = 1;
        public void NextPage()
        {

            if (pageindex < TotalPage)
            {
                currentcolumn = 0;
                curentrow = 0;
                ItemsGride.Controls.Clear();
                setbackButton();
                pageindex++;
                CurrentPageIndex = pageindex;
                if (mode == 0)
                    ssss(pageindex, vBestSaller: false);
                else
                    GetCurrentRecordscats(CurrentPageIndex, false);
            }
        }

        public void PreivousPage()
        {

            if (pageindex > 1)
            {
                currentcolumn = 0;
                curentrow = 0;
                ItemsGride.Controls.Clear();
                setbackButton();
                pageindex--;

                CurrentPageIndex = pageindex;
                if (mode == 0)
                    ssss(pageindex, vBestSaller: false);
                else
                    GetCurrentRecordscats(CurrentPageIndex, false);
              
            }
        }
        private void ItemsGride_Paint(object sender, PaintEventArgs e)
        {


        }
    }
}
