using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using InvAcc.Forms;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace InvAcc.Controls
{
    public partial class catPanel : UserControl
    {
        public string itemno = string.Empty;
        public string ssss = string.Empty;
#pragma warning disable CS0414 // The field 'catPanel.c1' is assigned but its value is never used
#pragma warning disable CS0414 // The field 'catPanel.p2' is assigned but its value is never used
#pragma warning disable CS0414 // The field 'catPanel.c2' is assigned but its value is never used
#pragma warning disable CS0414 // The field 'catPanel.p1' is assigned but its value is never used
        int c1 = 0, c2 = 0, p1 = 0, p2 = 0;
#pragma warning restore CS0414 // The field 'catPanel.p1' is assigned but its value is never used
#pragma warning restore CS0414 // The field 'catPanel.c2' is assigned but its value is never used
#pragma warning restore CS0414 // The field 'catPanel.p2' is assigned but its value is never used
#pragma warning restore CS0414 // The field 'catPanel.c1' is assigned but its value is never used
        int cmergin = 0, cpadding = 0, panmergin = 0, panpadding = 0;
        private int col = 0;
        private int colW = 0;
#pragma warning disable CS0414 // The field 'catPanel.count' is assigned but its value is never used
        int count = 0;
#pragma warning restore CS0414 // The field 'catPanel.count' is assigned but its value is never used
        int countc = 0;
        private int CurrentPageIndex = 1;
#pragma warning disable CS0414 // The field 'catPanel.CurrentPageIndexItmDet' is assigned but its value is never used
        private int CurrentPageIndexItmDet = 1;
#pragma warning restore CS0414 // The field 'catPanel.CurrentPageIndexItmDet' is assigned but its value is never used
        GridDoubleIntInputEditControl da = new GridDoubleIntInputEditControl();
        TableLayoutPanel DataGrideTable = new TableLayoutPanel();
        Stock_DataDataContext db;
        Control First = null;

#pragma warning disable CS0414 // The field 'catPanel.ie' is assigned but its value is never used
        int ie = 0;
#pragma warning restore CS0414 // The field 'catPanel.ie' is assigned but its value is never used
        List<KeyValuePair<int, int>> ItemKey = new List<KeyValuePair<int, int>>();
        List<itemControl> ItemList = new List<itemControl>();
        List<spatialItems> ItemLists = new List<spatialItems>();
        List<POSItemControl> ItemsPosList = new List<POSItemControl>();
        string ItmMainParameter;
        int LangArEn = VarGeneral.UserLang;
        private int PageSize = 10;
#pragma warning disable CS0414 // The field 'catPanel.PageSizeDet' is assigned but its value is never used
        private int PageSizeDet = 10;
#pragma warning restore CS0414 // The field 'catPanel.PageSizeDet' is assigned but its value is never used
        int posflag = 0;
#pragma warning disable CS0414 // The field 'catPanel.rearrange' is assigned but its value is never used
        int rearrange = 0;
#pragma warning restore CS0414 // The field 'catPanel.rearrange' is assigned but its value is never used
        private int row = 0;
        private int rowH = 0;
        TableLayoutPanel Tlayout = new TableLayoutPanel();
        private int TotalPage = 0;
#pragma warning disable CS0414 // The field 'catPanel.TotalPageDet' is assigned but its value is never used
        private int TotalPageDet = 0;
#pragma warning restore CS0414 // The field 'catPanel.TotalPageDet' is assigned but its value is never used
        public int CAT_ID = 0;
        //   FlowLayoutPanel Flayout2 = new FlowLayoutPanel();
        public int Cpanel_ID;
        public int PosFlag = 0;
        public catPanel()
        {

            InitializeComponent();
            //    this.RightToLeft = RightToLeft.Inherit;
            PItems.RightToLeft = RightToLeft.Yes;
            PItems.HorizontalScroll.Enabled = false;
            PItems.HorizontalScroll.Visible = false;
            Tot_Text.DisplayFormat = VarGeneral.DicemalMask;
            Letel_Text.DisplayFormat = VarGeneral.DicemalMask;
            Safi_Text.DisplayFormat = VarGeneral.DicemalMask;
            PItems.ControlRemoved += Countrol_removed;
            PItems.VerticalScroll.Enabled = true;
            PItems.AutoScroll = true;
            bs = VarGeneral.BranchCS;
            db = new Stock_DataDataContext(bs);
            checkBox1.Text = (VarGeneral.UserLang == 0 ? "الكل" : "All");

        }
        public static string bs;
        public delegate void customMessageHandler(System.Object sender,
                                    CatINvDetealilsArg e);

        public event customMessageHandler Edit;
        public event customMessageHandler Item_Added;

        public event customMessageHandler Item_Price_Changed;
#pragma warning disable CS0067 // The event 'catPanel.Item_Price_Entered' is never used
        public event customMessageHandler Item_Price_Entered;
#pragma warning restore CS0067 // The event 'catPanel.Item_Price_Entered' is never used
        public event customMessageHandler Item_Removed;
        public event customMessageHandler Item_UnitSeted;

        private void button1_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndex > 1)
            {
                CurrentPageIndex--;
                GetCurrentRecords(CurrentPageIndex, vBestSaller: false);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Calc_Total(object sender, ItemEventArg e)
        {
            calcluateTotals();
        }
        void calcluateTotals
            (
            )
        {
            double sum = 0;
            if (isPosversion == 0)
            {
                foreach (itemControl t in ItemList)
                {
                    if (t.State == CheckState.Checked) sum += t.price;

                }
                foreach (spatialItems t in ItemLists)
                {
                    if (t.State == CheckState.Checked) sum += t.price;

                }
            }
            else
                foreach (GridRow r in superGridControl1.PrimaryGrid.Rows)
                {
                    string ff = string.Empty;

                    if (r.Tag != null)
                        ff = r.Tag.ToString();
                    if (ff == "chk")

                        foreach (GridCell c in r.Cells)
                        {
                            if (c.EditorType == typeof(CHkvalue))
                            {

                                sum += ((CHkvalue)c.EditControl).getpriceControls();

                            }

                        }
                }
            try
            {
                Tot_Text.Text = Math.Round((sum), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString();
            }catch
            {
                Tot_Text.Text = Math.Round((sum), 2).ToString();
            }
        }

        internal void Refress()
        {

            superGridControl1.Refresh();
        }

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

        private void Changetoedit(object sender, ItemEventArg e)
        {
            if (Edit != null)
                Edit(null, null);
        }
#pragma warning disable CS0169 // The field 'catPanel.thread' is never used
        Thread thread;
#pragma warning restore CS0169 // The field 'catPanel.thread' is never used
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (spatialItems s in ItemLists)
                {

                    s.setcheck(checkBox1.CheckState);
                }
            }
            catch { }
            try
            {
                foreach (itemControl s in ItemList)
                    s.setcheck(checkBox1.CheckState);

            }
            catch
            {

            }
            try
            {

                if (checkBox1.CheckState == CheckState.Checked)
                    selectall();
                else
                    unselectall();

            }
            catch
            {

            }

        }

        private void ClearItemsMain()
        {
            foreach (GridRow rowCell in superGridControl1.PrimaryGrid.Rows)
            {
                foreach (GridCell cell in rowCell.Cells)
                {
                    try
                    {
                        cell.Value = string.Empty;
                        //  cell.Tag = "";
                        cell.CellStyles.Default.Background.Color1 = Color.White;
                        cell.CellStyles.Default.Background.Color2 = Color.White;
                        cell.CellStyles.Default.Background.BackFillType = BackFillType.Center;// = Color.White;


                        // cell.Visible = false;
                        if (cell.EditorType == typeof(CHkvalue))
                        {
                            CHkvalue vh = (CHkvalue)cell.EditControl;
                            vh.clear();

                        }
                        //if(cell.EditControl==typeof(PriceGridElement))
                        //{

                        //    PriceGridElement p = ((PriceGridElement)cell.EditControl);
                        //    p.clear();

                        //    cell.EditorType = typeof(PriceGridElement);


                        //    cell.EditorParams = new object[] { 0, cell };



                        //}
                        //if(cell.EditControl==typeof(TypeGridButton))
                        //{
                        //    TypeGridButton t = ((TypeGridButton)cell.EditControl);
                        //    t.clear();
                        //    T_Item ts = t.ItemData;
                        //    cell.EditorType = typeof(TypeGridButton);

                        //    // cell.EditorParams = new object[] {smal,larg };

                        //    cell.EditorParams = new object[] { ts.Itm_No, cell };


                        //    cell.Tag = ts.Itm_No;
                        //}
                    }
                    catch { }
                }
            }
        }

        private void Countrol_removed(object sender, ControlEventArgs e)
        {
            if (e.Control.Name == "spatialItems") countc--;
        }

        private void FillItmesMain(MetroTileItem vSender, bool vBestSaller)
        {
            List<T_Item> vItemsMain = new List<T_Item>();
            Stock_DataDataContext dbc = new Stock_DataDataContext();
            vItemsMain = (from t in dbc.T_Items
                          where t.ItmTyp != (int?)1 && !t.InvSaleStoped.Value && t.ItmCat == CAT_ID
                          orderby t.Itm_ID

                          select t).ToList();
            if (vSender != null)
            {
                vSender.Checked = true;
                if (int.Parse(vSender.Tag.ToString()) != 0)
                {
                    vItemsMain = (from t in dbc.T_Items
                                  where t.ItmCat == (int?)int.Parse(vSender.Tag.ToString())
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
                ClearItemsMain();
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
        public List<KeyValuePair<int, KeyValuePair<int, int>>> GridIndexes = new List<KeyValuePair<int, KeyValuePair<int, int>>>();
        private void GetCurrentRecords2(int page, bool vBestSaller)
        {
            try
            {
                ItmMainParameter = CAT_ID.ToString();
                List<T_Item> dt = new List<T_Item>();
                if (!vBestSaller)
                {
                    if (page == 1)
                    {
                        dt = db.ExecuteQuery<T_Item>("Select TOP " + PageSize + " * from T_Items " + ((!string.IsNullOrEmpty(ItmMainParameter) && ItmMainParameter != "0") ? (" where ItmCat = " + ItmMainParameter + " and ") : " where ") + " T_Items.ItmTyp != 1 and T_Items.InvSaleStoped = 0 ORDER BY Itm_ID", new object[0]).ToList();
                    }
                    else
                    {
                        int PreviouspageLimit = (page - 1) * PageSize;
                        dt = db.ExecuteQuery<T_Item>("Select TOP " + PageSize + " * from T_Items WHERE " + ((!string.IsNullOrEmpty(ItmMainParameter) && ItmMainParameter != "0") ? (" ItmCat = " + ItmMainParameter + " AND ") : " ") + " Itm_ID NOT IN (Select TOP " + PreviouspageLimit + " Itm_ID from T_Items WHERE " + ((!string.IsNullOrEmpty(ItmMainParameter) && ItmMainParameter != "0") ? (" ItmCat = " + ItmMainParameter) : " 1 = 1 ") + "ORDER BY Itm_ID) and T_Items.ItmTyp != 1 and T_Items.InvSaleStoped = 0 ORDER BY Itm_ID", new object[0]).ToList();
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
                    newSize = new Size(colW, rowH / 2 + rowH * 25 / 100);
                }
                catch
                {
                    newSize = new Size(130, 110);
                }
                foreach (GridRow rowCell in superGridControl1.PrimaryGrid.Rows)
                {
                    string ff = string.Empty;
                    if (rowCell.Tag != null)
                    {
                        ff = rowCell.Tag.ToString();
                    }
                    foreach (GridCell cell in rowCell.Cells)
                    {
                        try

                        {
                            cell.CellStyles.Default.Image = null;
                        }
                        catch
                        {
                        }
                        if (iicnt < dt.Count)
                        {
                            try
                            {
                                try
                                {
                                    if ((ff == "Name"))
                                    {
                                        cell.CellStyles.Default.AllowWrap = Tbool.True;
                                        cell.Value = ((VarGeneral.UserLang == 0) ? dt[iicnt].Arb_Des : dt[iicnt].Eng_Des);
                                        cell.CellStyles.Default.Background.Color1 = Color.White;
                                        cell.Tag = dt[iicnt].Itm_No;
                                        iicnt++;
                                    }
                                    if (ff == "chk")
                                    {
                                        rowCell.RowHeight = 0;
                                        rowCell.CellStyles.Default.AllowWrap = Tbool.True;
                                        cell.EditorType = typeof(CHkvalue);

                                        cell.CellStyles.Default.Background.Color1 = Color.White;
                                        cell.EditorParams = new object[] { dt[iicnt], cell };
                                        cell.Tag = dt[iicnt].Itm_No;
                                        iicnt++;
                                        cell.Value = false;
                                    }
                                    if ((ff == "KIND"))
                                    {
                                        cell.CellStyles.Default.Background.Color1 = Color.White;
                                        List<T_Unit
                                            > t = new List<T_Unit>();
                                        if (dt[iicnt].T_Unit != null)
                                            t.Add(dt[iicnt].T_Unit);
                                        if (dt[iicnt].T_Unit1 != null)
                                            t.Add(dt[iicnt].T_Unit1);
                                        if (dt[iicnt].T_Unit2 != null)
                                            t.Add(dt[iicnt].T_Unit2);
                                        if (dt[iicnt].T_Unit3 != null)
                                            t.Add(dt[iicnt].T_Unit3);
                                        if (dt[iicnt].T_Unit4 != null)
                                            t.Add(dt[iicnt].T_Unit4);
                                        int lang = VarGeneral.UserLang;
                                        List<Image> Ls = new List<Image>();
                                        ImageList smal = new ImageList();
                                        ImageList larg = new ImageList();
                                        foreach (T_Unit fs in t)
                                        {
                                            larg.Images.Add(Convert_Text_to_Image((VarGeneral.UserLang == 0 ? fs.Arb_Des : fs.Eng_Des), DefaultFont.Name, 15));
                                            smal.Images.Add(Convert_Text_to_Image((VarGeneral.UserLang == 0 ? fs.Arb_Des : fs.Eng_Des), "Bookman Old Style", 12));
                                        }
                                        cell.EditorType = typeof(TypeGridButton);
                                        // cell.EditorParams = new object[] {smal,larg };

                                        cell.EditorParams = new object[] { dt[iicnt].Itm_No, cell };


                                        cell.Tag = dt[iicnt].Itm_No;
                                        iicnt++;

                                    }

                                    if ((ff == "PriceInput"))
                                    {

                                        List<T_Unit
                                            > t = new List<T_Unit>();
                                        if (dt[iicnt].T_Unit != null)
                                            t.Add(dt[iicnt].T_Unit);
                                        if (dt[iicnt].T_Unit1 != null)
                                            t.Add(dt[iicnt].T_Unit1);
                                        if (dt[iicnt].T_Unit2 != null)
                                            t.Add(dt[iicnt].T_Unit2);
                                        if (dt[iicnt].T_Unit3 != null)
                                            t.Add(dt[iicnt].T_Unit3);
                                        if (dt[iicnt].T_Unit4 != null)
                                            t.Add(dt[iicnt].T_Unit4);

                                        cell.EditorType = typeof(PriceGridElement);


                                        cell.EditorParams = new object[] { dt[iicnt].UntPri1, cell };


                                        cell.Tag = dt[iicnt].Itm_No;
                                        iicnt++;

                                    }
                                    cell.CellStyles.Default.Background.Color1 = Color.White;

                                }
                                catch
                                {
                                    cell.Visible = false;
                                    iicnt++;
                                }


                            }
                            catch
                            {
                                iicnt++;
                            }
                        }
                        else
                        {
                            cell.Value = string.Empty;
                        }
                    }
                    superGridControl1.Refresh();
                }
                if (VarGeneral.Settings_Sys.Path_Kind < 2)
                {
                    iicnt = 0;
                    foreach (GridRow rowCell in superGridControl1.PrimaryGrid.Rows)
                    {
                        foreach (GridCell cell in rowCell.Cells)
                        {
                            if (iicnt >= dt.Count)
                            {
                                continue;
                            }
                            try
                            {
                                if (rowCell.RowHeight <= rowH / 4)
                                {
                                    continue;
                                }
                                cell.Tag = dt[iicnt].Itm_No;
                                if (VarGeneral.Settings_Sys.Path_Kind == 1)
                                {
                                    if (dt[iicnt].ItmImg != null)
                                    {
                                        byte[] arr = dt[iicnt].ItmImg.ToArray();
                                        MemoryStream stream = new MemoryStream(arr);
                                        cell.CellStyles.Default.Image = new Bitmap(Image.FromStream(stream), newSize);
                                    }
                                    else
                                    {
                                        cell.CellStyles.Default.Image = null;
                                    }
                                    try
                                    {
                                        cell.Tag = dt[iicnt].Itm_No;
                                        cell.Value = ".";
                                    }
                                    catch
                                    {
                                    }
                                }
                                else
                                {
                                    string[] filters = new string[7]
                                    {
                                        "jpg",
                                        "jpeg",
                                        "png",
                                        "gif",
                                        "tiff",
                                        "bmp",
                                        "gif"
                                    };
                                    string[] filePaths = GetFilesFrom(Application.StartupPath + "\\POS_IMG", filters, isRecursive: false);
                                    if (filePaths.Count() > 0)
                                    {
                                        Random rnd = new Random();
                                        string mypic_path = filePaths[rnd.Next(0, filePaths.Count() - 1)];
                                        if (File.Exists(mypic_path))
                                        {
                                            Image original = Image.FromFile(mypic_path);
                                            Image resized = ResizeImage(original, new Size(80, 80), preserveAspectRatio: false);
                                            cell.CellStyles.Default.Image = resized;
                                        }
                                    }
                                    try
                                    {
                                        cell.Tag = dt[iicnt].Itm_No;
                                        cell.Value = ".";
                                    }
                                    catch
                                    {
                                    }
                                }
                                cell.CellStyles.Default.ImageAlignment = Alignment.MiddleCenter;
                                iicnt++;
                            }
                            catch
                            {
                                iicnt++;
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            superGridControl1.Refresh();
            Refresh();
        }


        private void GetCurrentRecords(int page, bool vBestSaller)
        {
            try
            {
                superGridControl1.GetCellStyle += sdf;
                int romhit = 0;
                ItmMainParameter = CAT_ID.ToString();
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
                    newSize = new Size(colW, rowH / 2 + rowH * 25 / 100);
                }
                catch
                {
                    newSize = new Size(130, 110);
                }

                superGridControl1.PrimaryGrid.ShowColumnHeader = false;
                superGridControl1.PrimaryGrid.ShowRowHeaders = false;
                superGridControl1.PrimaryGrid.ShowRowGridIndex = false;
                List<T_Item> g = (from isa in dt
                                  where isa.ItmCat == CAT_ID
                                  select isa).ToList<T_Item>();
                dt = g;
                int irowTeplate = 5;
                int irow = 0;


                for (int j = 0; j < superGridControl1.PrimaryGrid.Rows.Count; j++)
                {


                    GridRow rowCell = (GridRow)superGridControl1.PrimaryGrid.Rows[j];
                    if ((j + 1) % irowTeplate == 0)
                    {

                        irow++;
                        iicnt = (irowTeplate * irow);

                    }
                    else
                    { iicnt = irowTeplate * irow; }
                    if (iicnt < dt.Count)

                    {
                        for (int i = 0; i < rowCell.Cells.Count; i++)
                        {

                            GridCell cell = rowCell.Cells[i];
                            try
                            {
                                cell.CellStyles.Default.Image = null;
                            }
                            catch
                            {
                            }
                            string ff = string.Empty;
                            if (i == 5)
                            { }
                            if (rowCell.Tag != null)
                                ff = rowCell.Tag.ToString();
                            if (ff.Contains("ضاف"))
                            { }
                            if (iicnt < dt.Count)
                            {

                                try
                                {
                                    if (ff == "Image")
                                    {
                                        if (dt[iicnt].ItmImg != null)
                                        {
                                            byte[] arr = dt[iicnt].ItmImg.ToArray();
                                            MemoryStream stream = new MemoryStream(arr);
                                            cell.CellStyles.Default.Image = new Bitmap(Image.FromStream(stream), newSize);
                                        }
                                        else
                                        {
                                            cell.CellStyles.Default.Image = null;
                                        }
                                        iicnt++;


                                    }
                                    if ((ff == "Name"))
                                    {
                                        cell.CellStyles.Default.AllowWrap = Tbool.True;
                                        cell.Value = ((VarGeneral.UserLang == 0) ? dt[iicnt].Arb_Des : dt[iicnt].Eng_Des);
                                        //   cell.CellStyles.Default.Background.Color1 = Color.Orange;
                                        cell.Tag = dt[iicnt].Itm_No;
                                        iicnt++;
                                    }
                                    if (ff == "chk")
                                    {
                                        cell.CellStyles.Default.AllowWrap = Tbool.True;
                                        cell.EditorType = typeof(CHkvalue);


                                        cell.EditorParams = new object[] { dt[iicnt], cell };

                                        cell.Tag = dt[iicnt].Itm_No;
                                        int kd = int.Parse(dt[iicnt].Itm_No);
                                        iicnt++;
                                        cell.Value = false;
                                        //    (cell.EditControl as CHkvalue).set(0,-101, dt[iicnt]);
                                    }
                                    if ((ff == "KIND"))
                                    {

                                        List<T_Unit
                                            > t = new List<T_Unit>();
                                        if (dt[iicnt].T_Unit != null)
                                            t.Add(dt[iicnt].T_Unit);
                                        if (dt[iicnt].T_Unit1 != null)
                                            t.Add(dt[iicnt].T_Unit1);
                                        if (dt[iicnt].T_Unit2 != null)
                                            t.Add(dt[iicnt].T_Unit2);
                                        if (dt[iicnt].T_Unit3 != null)
                                            t.Add(dt[iicnt].T_Unit3);
                                        if (dt[iicnt].T_Unit4 != null)
                                            t.Add(dt[iicnt].T_Unit4);
                                        int lang = VarGeneral.UserLang;
                                        List<Image> Ls = new List<Image>();
                                        ImageList smal = new ImageList();
                                        ImageList larg = new ImageList();
                                        foreach (T_Unit fs in t)
                                        {

                                            larg.Images.Add(Convert_Text_to_Image((lang == 0 ? fs.Arb_Des : fs.Eng_Des), DefaultFont.Name, 15));
                                            smal.Images.Add(Convert_Text_to_Image((lang == 0 ? fs.Arb_Des : fs.Eng_Des), "Bookman Old Style", 12));

                                        }
                                        cell.EditorType = typeof(TypeGridButton);

                                        // cell.EditorParams = new object[] {smal,larg };

                                        cell.EditorParams = new object[] { dt[iicnt].Itm_No, cell };


                                        cell.Tag = dt[iicnt].Itm_No;
                                        iicnt++;

                                    }

                                    if ((ff == "PriceInput"))
                                    {

                                        List<T_Unit
                                            > t = new List<T_Unit>();
                                        if (dt[iicnt].T_Unit != null)
                                            t.Add(dt[iicnt].T_Unit);
                                        if (dt[iicnt].T_Unit1 != null)
                                            t.Add(dt[iicnt].T_Unit1);
                                        if (dt[iicnt].T_Unit2 != null)
                                            t.Add(dt[iicnt].T_Unit2);
                                        if (dt[iicnt].T_Unit3 != null)
                                            t.Add(dt[iicnt].T_Unit3);
                                        if (dt[iicnt].T_Unit4 != null)
                                            t.Add(dt[iicnt].T_Unit4);

                                        cell.EditorType = typeof(PriceGridElement);


                                        cell.EditorParams = new object[] { dt[iicnt].UntPri1, cell };


                                        cell.Tag = dt[iicnt].Itm_No;
                                        iicnt++;

                                    }
                                    BorderColor ccc = new BorderColor();
                                    ccc.All = Color.Blue;
                                    cell.CellStyles.Default.Background.Color1 = Color.AliceBlue;
                                    cell.Visible = true;

                                    BorderPattern c = new BorderPattern();
                                    c.All = LinePattern.Solid;
                                    cell.CellStyles.Default.BorderThickness.All = 1;
                                    cell.CellStyles.Default.BorderPattern = c;
                                }
                                catch
                                {
                                    superGridControl1.PrimaryGrid.GetCell(cell.RowIndex, cell.ColumnIndex).Value = string.Empty;
                                    superGridControl1.PrimaryGrid.GetCell(cell.RowIndex, cell.ColumnIndex).ReadOnly = false;

                                    superGridControl1.PrimaryGrid.GetCell(cell.RowIndex, cell.ColumnIndex).AllowEdit = false;

                                    superGridControl1.PrimaryGrid.GetCell(cell.RowIndex, cell.ColumnIndex).AllowSelection = false;
                                    superGridControl1.PrimaryGrid.GetCell(cell.RowIndex, cell.ColumnIndex).Visible = false;



                                    iicnt++;
                                }


                            }

                            else
                            {
                                superGridControl1.PrimaryGrid.GetCell(cell.RowIndex, cell.ColumnIndex).Value = string.Empty;
                                superGridControl1.PrimaryGrid.GetCell(cell.RowIndex, cell.ColumnIndex).ReadOnly = false;

                                superGridControl1.PrimaryGrid.GetCell(cell.RowIndex, cell.ColumnIndex).AllowEdit = false;

                                superGridControl1.PrimaryGrid.GetCell(cell.RowIndex, cell.ColumnIndex).AllowSelection = false;
                                superGridControl1.PrimaryGrid.GetCell(cell.RowIndex, cell.ColumnIndex).Visible = false;


                            }
                        }
                    }
                    else
                    { superGridControl1.PrimaryGrid.Rows[j].Visible = false; }
                    romhit += rowCell.RowHeight;
                    //  else
                    //rowCell.Visible = false;
                }
                if (VarGeneral.Settings_Sys.Path_Kind < 2)
                {
                    iicnt = 0;
                    foreach (GridRow rowCell in superGridControl1.PrimaryGrid.Rows)
                    {
                        foreach (GridCell cell in rowCell.Cells)
                        {
                            if (iicnt >= dt.Count)
                            {
                                continue;
                            }
                            try
                            {
                                if (rowCell.RowHeight <= rowH / 4)
                                {
                                    continue;
                                }
                                cell.Tag = dt[iicnt].Itm_No;
                                if (VarGeneral.Settings_Sys.Path_Kind == 1)
                                {
                                    if (dt[iicnt].ItmImg != null)
                                    {
                                        byte[] arr = dt[iicnt].ItmImg.ToArray();
                                        MemoryStream stream = new MemoryStream(arr);
                                        cell.CellStyles.Default.Image = new Bitmap(Image.FromStream(stream), newSize);
                                    }
                                    else
                                    {
                                        cell.CellStyles.Default.Image = null;
                                    }
                                    try
                                    {
                                        cell.Tag = dt[iicnt].Itm_No;
                                        cell.Value = ".";
                                    }
                                    catch
                                    {
                                    }
                                }
                                else
                                {
                                    string[] filters = new string[7]
                                    {
                                        "jpg",
                                        "jpeg",
                                        "png",
                                        "gif",
                                        "tiff",
                                        "bmp",
                                        "gif"
                                    };
                                    string[] filePaths = GetFilesFrom(Application.StartupPath + "\\POS_IMG", filters, isRecursive: false);
                                    if (filePaths.Count() > 0)
                                    {
                                        Random rnd = new Random();
                                        string mypic_path = filePaths[rnd.Next(0, filePaths.Count() - 1)];
                                        if (File.Exists(mypic_path))
                                        {
                                            Image original = Image.FromFile(mypic_path);
                                            Image resized = ResizeImage(original, new Size(80, 80), preserveAspectRatio: false);
                                            cell.CellStyles.Default.Image = resized;
                                        }
                                    }
                                    try
                                    {
                                        cell.Tag = dt[iicnt].Itm_No;
                                        cell.Value = ".";
                                    }
                                    catch
                                    {
                                    }
                                }
                                cell.CellStyles.Default.ImageAlignment = Alignment.MiddleCenter;
                                iicnt++;
                            }
                            catch
                            {
                                iicnt++;
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            superGridControl1.Refresh();
            Refresh();

        }

        private void sdf(object sender, GridGetCellStyleEventArgs e)
        {
        }

        private void parentchanged(object sender, EventArgs e)
        {
        }

        private void propritychanged(object sender, PropertyChangedEventArgs e)
        {

        }

        private void Item_PriceChanged(object sender, ItemEventArg e)
        {
            CatINvDetealilsArg arg = new CatINvDetealilsArg();
            arg.Action = ActionInv.SetPrice;
            arg.cPanel_ID = Cpanel_ID;
            arg.Row_ID = e.Row_ID;
            arg.ItemData = e.ItemData;
            arg.Type = e.Type;
            arg.Price = e.Price;
            arg.Item_state = e.state;


            if (Item_Price_Changed != null)
            {
                Item_Price_Changed(this, arg);

                e.Price = arg.Price;

            }



        }

        private void Item_StateChanged(object sender, ItemEventArg e)
        {

            CatINvDetealilsArg par = new CatINvDetealilsArg();
            par.ItemData = e.ItemData;
            par.cPanel_ID = Cpanel_ID;

            par.Action = e.Action;
            par.Row_ID = e.Row_ID;
            par.Price = e.Price;

            if (par.Action == ActionInv.Add)
            {
                if (Item_Added != null)
                {
                    Item_Added(this, par);
                    e.Row_ID = par.Row_ID;
                    e.Type = par.Type;
                    e.Price = par.Price;
                }
            }
            else
            {
                if (Item_Removed != null)
                {
                    Item_Removed(this, par);
                    e.Row_ID = -100;
                    //e.Column_ID = -100;
                    e.Price = 0;

                }
            }

        }

        private void Item_TypeChanged(object sender, ItemEventArg e)
        {
            CatINvDetealilsArg arg = new CatINvDetealilsArg();
            arg.ItemData = e.ItemData;
            arg.Row_ID = e.Row_ID;
            arg.cPanel_ID = Cpanel_ID;
            arg.Price = e.Price;
            arg.Type = e.Type;

            arg.Action = ActionInv.setUnit;
            if (Item_UnitSeted != null)
            {
                Item_UnitSeted(this, arg);
                e.Price = arg.Price;

            }
        }
#pragma warning disable CS0169 // The field 'catPanel.suercopy' is never used
        Object suercopy;
#pragma warning restore CS0169 // The field 'catPanel.suercopy' is never used
        public void CLEARGRID()
        {
            superGridControl1.PrimaryGrid.Columns.Clear();
            superGridControl1.PrimaryGrid.Rows.Clear();

            ItemsMainSetting();
        }
        public static int swidt = -1;

        public static int shight = -1;

        private void ItemsMainSetting()
        {
            try
            {
                if (shight == -1)
                    shight = superGridControl1.Height;
                if (swidt == -1)
                    swidt = superGridControl1.Width;

                superGridControl1.Tag = this;
                superGridControl1.PrimaryGrid.AllowEdit = true;

                //  this.superGridControl1.PrimaryGrid.ColumnHeader.Visible = false;
                this.superGridControl1.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.TopLeft;
                this.superGridControl1.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.superGridControl1.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.TextColor = System.Drawing.Color.White;
                superGridControl1.PrimaryGrid.ShowWhitespaceRowLines = false;

                col = (swidt) / 130;
                colW = (swidt) / col;
                row = (shight
                    ) / 130;
                rowH = (shight) / row;

                PageSize = Math.Abs(col * row);
                int d = rowH / 10;
                int dd = (d * 5) / 3;
                dd += 10;

                for (int i = 0; i < col; i++)
                {

                    GridColumn q = new GridColumn();
                    q.Width = colW;

                    superGridControl1.PrimaryGrid.Columns.Add(q);
                }
                int Rowh = rowH / 2 + rowH * 25 / 100; ;
                for (int i = 0; i < row; i++)
                {
                    try
                    {
                        GridRow c = new GridRow();
                        c.RowHeight = (d * 5) - 10;
                        c.RowStyles.Default.Background.Color1 = Color.White;


                        for (int j = 0; j < col; j++)
                        {
                            c.Cells.Add(new GridCell(string.Empty));
                            c.Cells.LastOrDefault().Visible = false;
                            c.Tag = "Image";
                        }
                        GridRow fec = new GridRow();
                        fec.RowHeight = dd;

                        // ..//  fec.RowStyles.Default.Background.Color1 = Color.AliceBlue;
                        for (int k = 0; k < col; k++)
                        {


                            fec.Cells.Add(new GridCell("kdksk"));
                            //     fec.Cells.LastOrDefault().EditorType = typeof(CHkvalue);
                            fec.CellStyles.Default.Font = new Font("Tahoma", 9f, FontStyle.Bold);
                            fec.CellStyles.Default.TextColor = Color.Black;// = new Font("Tahoma", 6f, FontStyle.Bold);


                            fec.Cells.LastOrDefault().Visible = false;
                            fec.Cells.LastOrDefault().CellStyles.Default.Background.Color1 = Color.White;

                            fec.Tag = "chk";
                            //  fec.Cells.LastOrDefault().PropertyChanged += changespropreityvalue;


                        }
                        superGridControl1.PrimaryGrid.Rows.Add(fec);


                        //GridRow fgs = new GridRow();
                        //fgs.RowHeight = 0;
                        //fgs.RowStyles.Default.Background.Color1 = Color.AliceBlue;

                        //for (int j = 0; j < col; j++)
                        //{
                        //    fgs.Cells.Add(new GridCell(""));
                        //    fgs.Cells.LastOrDefault().EditorType = typeof(GridLabelEditControl);



                        //    fgs.CellStyles.Default.Font = new Font("Tahoma", 10f, FontStyle.Bold);

                        //    fgs.CellStyles.Default.TextColor = Color.Black;// = new Font("Tahoma", 6f, FontStyle.Bold);
                        //    fgs.Tag = "Name";

                        //}

                        //superGridControl1.PrimaryGrid.Rows.Add(fgs);
                        superGridControl1.PrimaryGrid.Rows.Add(c);
                        GridRow fc = new GridRow();
                        fc.RowHeight = dd;

                        for (int k = 0; k < col; k++)
                        {
                            GridCell ccc = new GridCell();

                            fc.Cells.Add(new GridCell());


                            fc.CellStyles.Default.Font = new Font("Tahoma", 12f, FontStyle.Bold);
                            fc.CellStyles.Default.TextColor = Color.Black;// = new Font("Tahoma", 6f, FontStyle.Bold);
                            fc.CellStyles.Default.Background.Color1 = Color.White;

                            fc.Cells.LastOrDefault().CellStyles.Default.Background.Color1 = Color.White;
                            fc.Cells.LastOrDefault().Visible = false;
                            fc.Tag = "PriceInput";

                        }

                        //    fc.RowHeaderText = "ألسعر";
                        superGridControl1.PrimaryGrid.Rows.Add(fc);

                        GridRow cc = new GridRow();
                        cc.RowHeight = dd;

                        cc.RowStyles.Default.Background.Color1 = Color.White;
                        for (int j = 0; j < col; j++)
                        {
#pragma warning disable CS0168 // The variable 'k' is declared but never used
                            GridComboBoxExEditControl k;
#pragma warning restore CS0168 // The variable 'k' is declared but never used

                            cc.Cells.Add(new GridCell((VarGeneral.UserLang == 0 ? "النوع" : "Kind")));


                            //    cc.Cells.LastOrDefault().Value = "dskfkl\nkdjsfalkj\n";
                            //  if (base.WindowState == FormWindowState.Normal)
                            {
                                cc.CellStyles.Default.Font = new Font("Tahoma", 12f, FontStyle.Bold);
                                cc.CellStyles.Default.TextColor = Color.Black;
                                cc.Cells.LastOrDefault().CellStyles.Default.Background.Color1 = Color.White;
                            }
                            cc.Cells.LastOrDefault().Visible = false;
                            cc.Tag = "KIND";
                            //cc .Cells.LastOrDefault().PropertyChanged += changespropreityvalue;
                        }
                        superGridControl1.PrimaryGrid.Rows.Add(cc);

                    }
                    catch { }

                }
            }
            catch
            {
            }
            ItmMainParameter = string.Empty;
            FillItmesMain(null, vBestSaller: false);

        }

        private void changespropreityvalue(object sender, PropertyChangedEventArgs e)
        {
            calcluateTotals();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void PItems_ControlAdded(object sender, ControlEventArgs e)
        {
            if (posflag != 1)
            {
                if (First == null)
                {
                    First = e.Control;
                    Control c = e.Control;
                    if (c.Name == "spatialItems")
                    {

                        spatialItems sit = new spatialItems();
                        sit.setHeader("الخدمة", "النوع", "الملاحظات", "السعر");
                        PItems.ControlAdded -= PItems_ControlAdded;
                        PItems.Controls.Remove(e.Control);
                        PItems.Controls.Add(sit);
                        countc++;
                        PItems.Controls.Add(e.Control);
                        PItems.ControlAdded += PItems_ControlAdded;


                    }


                }
                else
                {


                    if (First.Location.X != e.Control.Location.X)
                    {
                        Control c = e.Control;
                        if (c.Name == "spatialItems")
                        {
                            countc++;

                            First = null;
                            PItems_ControlAdded(null, e);
                        }

                    }
                }
            }

        }

        private void PItems_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PItems_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void PItems_Paint_2(object sender, PaintEventArgs e)
        {

        }
        private void PItems_Paint_3(object sender, PaintEventArgs e)
        {

        }

        private void PItems_Resize(object sender, EventArgs e)
        {

        }
        private void PItems_SizeChanged(object sender, EventArgs e)
        {

            //if (posflag != 1)
            //{
            //    PItems.Controls.Clear();
            //    First = null;
            //    foreach (spatialItems k in ItemLists)
            //    {



            //        PItems.Controls.Add(k);


            //    }

            //    foreach (itemControl k in ItemList)
            //    {

            //        PItems.Controls.Add(k);

            //    }
            //    PItems.Refresh();
            //  }



        }

        private void PsItems_Paint(object sender, PaintEventArgs e)
        {

        }
        private void setlayout(int count)
        {

        }
        List<T_Unit> setunit2(T_Item ItemData)
        {
#pragma warning disable CS0168 // The variable 'price' is declared but never used
            double price;
#pragma warning restore CS0168 // The variable 'price' is declared but never used
#pragma warning disable CS0219 // The variable 'pack' is assigned but its value is never used
            double pack = 1;
#pragma warning restore CS0219 // The variable 'pack' is assigned but its value is never used
            List<T_Unit> types = new List<T_Unit>();
            if (ItemData.Unit1 != null)

            {
                //  types.Add(VarGeneral.UserLang == 0 ? db.StockUnit(ItemData.Unit1.ToString()).Arb_Des.ToString() : db.StockUnit(ItemData.Unit1.ToString()).Eng_Des.ToString());
                types.Add(db.StockUnit(ItemData.Unit1.ToString()));
            }
            if (null != ItemData.Unit2)

            {
                types.Add(db.StockUnit(ItemData.Unit2.ToString()));
                //types.Add(VarGeneral.UserLang == 0 ? db.StockUnit(ItemData.Unit2.ToString()).Arb_Des.ToString() : db.StockUnit(ItemData.Unit2.ToString()).Eng_Des.ToString());

            }
            if (null != ItemData.Unit3)

            {

                types.Add(db.StockUnit(ItemData.Unit3.ToString()));
                //
                //types.Add(VarGeneral.UserLang == 0 ? db.StockUnit(ItemData.Unit3.ToString()).Arb_Des.ToString() : db.StockUnit(ItemData.Unit3.ToString()).Eng_Des.ToString());

            }
            if (null != ItemData.Unit4)

            {
                types.Add(db.StockUnit(ItemData.Unit4.ToString()));
                //types.Add(VarGeneral.UserLang == 0 ? db.StockUnit(ItemData.Unit4.ToString()).Arb_Des.ToString() : db.StockUnit(ItemData.Unit4.ToString()).Eng_Des.ToString());

            }
            if (null != ItemData.Unit5)

            {
                types.Add(db.StockUnit(ItemData.Unit5.ToString()));
                // types.Add(VarGeneral.UserLang == 0 ? db.StockUnit(ItemData.Unit5.ToString()).Arb_Des.ToString() : db.StockUnit(ItemData.Unit5.ToString()).Eng_Des.ToString());

            }

            return types;
        }

        private void splitContainer1_SizeChanged(object sender, EventArgs e)
        {
            splitContainer1.SizeChanged -= splitContainer1_SizeChanged;
            try
            {

                splitContainer1.SplitterDistance = splitContainer1.Size.Height - 34;
            }
            catch
            {

            }
            splitContainer1.SizeChanged += splitContainer1_SizeChanged;

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
        private void superGridControl1_Click(object sender, EventArgs e)
        {

        }

        private void superGridControl1_Click_1(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        internal void setprice(int r, double price)
        {

            foreach (itemControl t in ItemList)
            {
                t.setprice(r, price);
            }
            foreach (spatialItems tt in ItemLists)
                tt.setprice(r, price);
        }
        public int isPosversion = 0;
        public void clear()
        {
            if (isPosversion == 0)
            {
                ssas = 0;
                foreach (itemControl i in ItemList)
                {
                    i.SetitemControlDataClear(i.ItemData);
                }
                foreach (spatialItems i in ItemLists)
                {
                    i.SetitemControlDataClear(i.ItemData);
                }

                foreach (POSItemControl i in ItemsPosList)
                    i.SetitemControlDataClear(i.ItemData);
            }
            else
            {
                CLEARGRID();
                Refresh();
            }

            Tot_Text.Value = 0;
            // txtTotTax.Value = 0;
            Letel_Text.Value = 0;

        }

        public static string[] GetFilesFrom(string searchFolder, string[] filters, bool isRecursive)
        {
            List<string> filesFound = new List<string>();
            SearchOption searchOption = (isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
            foreach (string filter in filters)
            {
                filesFound.AddRange(Directory.GetFiles(searchFolder, $"*.{filter}", searchOption));
            }
            return filesFound.ToArray();
        }
#pragma warning disable CS0414 // The field 'catPanel.itemContainer2' is assigned but its value is never used
        DevComponents.DotNetBar.ItemContainer itemContainer2 = null;
#pragma warning restore CS0414 // The field 'catPanel.itemContainer2' is assigned but its value is never used
        DevComponents.DotNetBar.ControlContainerItem addrow(Control c)
        {


            DevComponents.DotNetBar.ControlContainerItem ccontainwer = new ControlContainerItem();
            ccontainwer.Control = c;
            return ccontainwer;
        }
        public List<KeyValuePair<int, int>> loadItemsOfCategory(int cat_id, int ID)
        {
            Cpanel_ID = ID;
            CAT_ID = cat_id;
            //Pitem2.Margin = new System.Windows.Forms.Padding(panpadding);
            //PItems.Margin = new System.Windows.Forms.Padding(panpadding);
            //PItems.Padding = new System.Windows.Forms.Padding(panmergin);
            //Pitem2.Padding = new System.Windows.Forms.Padding(panmergin);
            superGridControl1.Visible = false;
            buttonX1.Visible = false;
            buttonX2.Visible = false;
            buttonX3.Visible = false;
            List<T_Item> items = new List<T_Item>();
            T_CATEGORY ts = db.StockCat(cat_id.ToString());
            items = db.StockItemListBycat(cat_id);
            setlayout(items.Count);
            var q = from i in items
                    where i.Unit2 != null
                    select i;
            var q1 = from i in items
                     where i.Unit2 == null
                     select i;
            List<T_Item> Lwithoutunits = q1.ToList<T_Item>();
            List<T_Item> WithUnits = q.ToList<T_Item>();
            int id = CarInvData.ControlsCount;
            //  PItems.Dock = DockStyle.Fill;
            int flag = 0;
            //  PItems.RightToLeft = RightToLeft.Yes;
            if (q.Count<T_Item>() != 0)
            {


                itemControl fa = new itemControl();




                rearrange = 1;
                if (WithUnits.Count > 0)
                {
                    spatialItems sit = new spatialItems();
                    if (VarGeneral.UserLang == 0)
                        sit.setHeader("الخدمة", "النوع", "الملاحظات", "السعر");
                    else
                        sit.setHeader("Serveice", "Type", "Notes", "Price");
                    SpecialContainer.SubItems.Add(addrow(sit));
                }
                foreach (T_Item t in WithUnits)
                {
                    flag++;
                    KeyValuePair<int, int> key = new KeyValuePair<int, int>(t.Itm_ID, Cpanel_ID);
                    ItemKey.Add(key);

                    spatialItems it = new spatialItems();
                    it.ControlID = id;
                    id++;

                    it.setItemData(t);
                    it.cPanel_ID = ID;
                    it.PriceChanged += Item_PriceChanged;
                    it.Edit += Changetoedit;
                    it.ItemCheckedChanged += Item_StateChanged;
                    it.ItemTypeChanged += Item_TypeChanged;
                    it.TOTCal_ReadY += Calc_Total;


                    it.Margin = new System.Windows.Forms.Padding(cmergin);
                    it.Padding = new System.Windows.Forms.Padding(panmergin);
                    //      it.Dock = DockStyle.Top;
                    it.Tag = it;


                    it.Click += klj;
                    SpecialContainer.SubItems.Add(addrow(it));
                    //    PItems.Controls.Add(it);
                    //  PItems.AutoScroll = true;

                    //   ItemList.Add(it);

                    ItemLists.Add(it);

                }


            }
            foreach (T_Item t in Lwithoutunits)
            {
                itemControl it = new itemControl();
                KeyValuePair<int, int> key = new KeyValuePair<int, int>(t.Itm_ID, Cpanel_ID);
                ItemKey.Add(key);



                it.ControlID = id;
                id++;


                it.SetitemControlData(t);
                //      it.Dock = DockStyle.Top;
                it.cPanel_ID = ID;
                it.PriceChanged += Item_PriceChanged;
                it.ItemCheckedChanged += Item_StateChanged;
                it.TOTCal_ReadY += Calc_Total;
                it.Edit += Changetoedit;
                it.Click += klj;
                it.Tag = it;
                ITemCOntrolCOntainer.SubItems.Add(addrow(it));
                //PItems.Controls.Add(it);
                //PItems.Controls.SetChildIndex(it, flag); flag++;
                flag++;

                ItemList.Add(it);



            }
            CarInvData.ControlsCount = id;
            Tot_Label.Text = (VarGeneral.UserLang == 0 ? "إجمالي" : "Total") + " " + (VarGeneral.UserLang == 0 ? ts.Arb_Des : ts.Eng_Des);
            Safi_Label.Text = (VarGeneral.UserLang == 0 ? "الصافي " : "Net") + " " + (VarGeneral.UserLang == 0 ? ts.Arb_Des : ts.Eng_Des);
            letel_Label.Text = (VarGeneral.UserLang == 0 ? "مبلغ اقل" : "Few:");

            return ItemKey;

        }


        private void klj(object sender, EventArgs e)
        {

        }

        public List<KeyValuePair<int, int>> loadItemsOfCategory(int cat_id, int ID, int pos)
        {
            Cpanel_ID = ID;

            posflag = pos;
            CAT_ID = cat_id;

            isPosversion = 1;
            ItmMainParameter = 2.ToString();
            PItems.Visible = false;
            List<T_Item> items = new List<T_Item>();
            T_CATEGORY ts = db.StockCat(cat_id.ToString());
            ItemsMainSetting();
            items = db.StockItemListBycat(cat_id);
            foreach (T_Item t in items)
            {
                KeyValuePair<int, int> key = new KeyValuePair<int, int>(t.Itm_ID, Cpanel_ID);
                ItemKey.Add(key);
            }
            Tot_Label.Text = (VarGeneral.UserLang == 0 ? "إجمالي" : "Total") + " " + (VarGeneral.UserLang == 0 ? ts.Arb_Des : ts.Eng_Des);
            Safi_Label.Text = (VarGeneral.UserLang == 0 ? "الصافي " : "Net") + " " + (VarGeneral.UserLang == 0 ? ts.Arb_Des : ts.Eng_Des);
            letel_Label.Text = (VarGeneral.UserLang == 0 ? "مبلغ اقل" : "Few:");

            return ItemKey;
            //superGridControl1.Visible = false;
            //PItems.Visible = true;

#pragma warning disable CS0162 // Unreachable code detected
            PItems.Dock = DockStyle.Fill;
#pragma warning restore CS0162 // Unreachable code detected

            PItems.BackColor = Color.White;

            setlayout(items.Count); int id = CarInvData.ControlsCount;
            PItems.ControlAdded -= PItems_ControlAdded;
            foreach (T_Item t in items)
            {
                KeyValuePair<int, int> key = new KeyValuePair<int, int>(t.Itm_ID, Cpanel_ID);
                ItemKey.Add(key);

                POSItemControl it = new POSItemControl();
                it.ControlID = id;
                id++;

                it.SetitemControlData(t);
                it.DeActivate();
                it.cPanel_ID = ID;
                it.PriceChanged += Item_PriceChanged;
                it.Edit += Changetoedit;
                it.ItemCheckedChanged += Item_StateChanged;
                it.ItemTypeChanged += Item_TypeChanged;
                it.TOTCal_ReadY += Calc_Total;
                //      it.Dock = DockStyle.Top;

                PItems.Controls.Add(it);
                //  PItems.AutoScroll = true;
                ItemsPosList.Add(it);
                //   ItemList.Add(it);

            }
            CarInvData.ControlsCount = id;
            Tot_Label.Text = "إجمالي" + " " + ts.Arb_Des;
            Safi_Label.Text = "صافي " + " " + ts.Arb_Des;
            letel_Label.Text = "مبلغ اقل ";
            PItems.Visible = false;
            return ItemKey;

        }
        public static Image ResizeImage(Image image, Size size, bool preserveAspectRatio)
        {
            int newWidth;
            int newHeight;
            if (preserveAspectRatio)
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                float percentWidth = (float)size.Width / (float)originalWidth;
                float percentHeight = (float)size.Height / (float)originalHeight;
                float percent = ((percentHeight < percentWidth) ? percentHeight : percentWidth);
                newWidth = (int)((float)originalWidth * percent);
                newHeight = (int)((float)originalHeight * percent);
            }
            else
            {
                newWidth = size.Width;
                newHeight = size.Height;
            }
            Image newImage = new Bitmap(newWidth, newHeight);
            using (Graphics graphicsHandle = Graphics.FromImage(newImage))
            {
                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }
        public static int ssa = 0;

        public static int ssas = 0;
        public void selectall()
        {

            {
                for (int i = 0; i < superGridControl1.PrimaryGrid.Rows.Count; i++)
                {
                    GridRow rowcell = (GridRow)superGridControl1.PrimaryGrid.Rows[i];
                    string ff = string.Empty;

                    if (rowcell.Tag != null)
                        ff = rowcell.Tag.ToString();
                    int kf = 0;
                    for (int j = 0; j < rowcell.Cells.Count; j++)
                    {
                        GridCell c = rowcell[j];
                        if (c.Tag != null)
                        {
                            try
                            {
                                int idno = int.Parse(c.Tag.ToString())
                                    ;
                                //   if (idno == (int.Parse(itm.Itm_No)))
                                {

                                    if (ff == "chk")
                                    {
                                        CHkvalue cc = (c.EditControl as CHkvalue);
                                        //  cc.Checked = true;

                                        cc.EditorCell = c;
                                        //  cc.CheckValueChecked = CheckState.Checked;
                                        cc.CheckState = CheckState.Checked;
                                        superGridControl1_EditorValueChanged(this, new GridEditEventArgs(null, c, cc));
                                        kf = 1;
                                        break;







                                    }
                                }
                            }
                            catch
                            { }
                        }

                    }

                    if (kf == 1) break;
                }
            }
            calcluateTotals();
        }
        public void unselectall()
        {

            {
                for (int i = 0; i < superGridControl1.PrimaryGrid.Rows.Count; i++)
                {
                    GridRow rowcell = (GridRow)superGridControl1.PrimaryGrid.Rows[i];
                    string ff = string.Empty;

                    if (rowcell.Tag != null)
                        ff = rowcell.Tag.ToString();
                    int kf = 0;
                    for (int j = 0; j < rowcell.Cells.Count; j++)
                    {
                        GridCell c = rowcell[j];
                        if (c.Tag != null)
                        {
                            try
                            {
                                int idno = int.Parse(c.Tag.ToString())
                                    ;
                                //      if (idno == (int.Parse(itm.Itm_No)))
                                {

                                    if (ff == "chk")
                                    {
                                        CHkvalue cc = (c.EditControl as CHkvalue);
                                        //  cc.Checked = true;

                                        cc.EditorCell = c;
                                        //  cc.CheckValueChecked = CheckState.Checked;
                                        cc.CheckState = CheckState.Unchecked;
                                        superGridControl1_EditorValueChanged(this, new GridEditEventArgs(null, c, cc));
                                        kf = 1;
                                        break;







                                    }
                                }
                            }
                            catch
                            { }
                        }

                    }

                    if (kf == 1) break;
                }
            }
            calcluateTotals();
        }
        public int setItemData(double price, T_Item itm, int Rowid, T_Unit u, int k)
        {
            ssas = 1;

            int ik = Rowid;
            if (isPosversion == 1)
            {
                ssas = 1;

                for (int i = 0; i < superGridControl1.PrimaryGrid.Rows.Count; i++)
                {
                    GridRow rowcell = (GridRow)superGridControl1.PrimaryGrid.Rows[i];
                    string ff = string.Empty;

                    if (rowcell.Tag != null)
                        ff = rowcell.Tag.ToString();

                    for (int j = 0; j < rowcell.Cells.Count; j++)
                    {
                        GridCell c = rowcell[j];
                        if (c.Tag != null)
                        {
                            try
                            {
                                int idno = int.Parse(c.Tag.ToString())
                                    ;
                                if (idno == (int.Parse(itm.Itm_No)))
                                {

                                    if (ff == "chk")
                                    {

                                        (c.EditControl as CHkvalue).set(1, Rowid, itm);









                                    }
                                    if ((ff == "KIND"))
                                    {

                                        TypeGridButton da = (TypeGridButton)c.EditControl;
                                        da.Row_ID = Rowid;
                                        da.ItemData = itm; c.Value = (VarGeneral.UserLang == 0 ? u.Arb_Des : u.Eng_Des);


                                    }
                                    if ((ff == "PriceInput"))
                                    {

                                        PriceGridElement da = (PriceGridElement)c.EditControl;
                                        da.Row_ID = Rowid;
                                        c.Value = price.ToString();
                                        //   superGridControl1_EditorValueChanged(null, new GridEditEventArgs(null, c, c.EditControl));
                                    }
                                    //superGridControl1_EditorValueChanged(null, new GridEditEventArgs(null, c, c.EditControl));
                                }
                            }
                            catch
                            { }
                        }

                    }

                }
                calcluateTotals();
                ssa = 0;
                ssas = 0;
            }
            else
            if (k == 0)
            {
                foreach (itemControl i in ItemList)
                {
                    if (i.ItemData.Itm_ID == itm.Itm_ID)
                    {
                        i.setData(price, u, ik, itm); ik++;
                        ssas = 0;
                        return ik;
                    }
                }
                foreach (spatialItems i in ItemLists)
                {
                    if (i.ItemData.Itm_ID == itm.Itm_ID)
                    {
                        i.setData(price, u, ik, itm); ik++;
                        ssas = 0; return ik;
                    }
                }
            }
            else
            {
                foreach (POSItemControl i in ItemsPosList)
                {
                    if (i.ItemData.Itm_ID == itm.Itm_ID)
                    {
                        i.setData(price, u, ik, itm); ik++;
                        ssas = 0;
                        return ik;
                    }
                }

            }
            superGridControl1.Refresh();

            ssas = 0;
            return ik;
        }

        private void setcheck(CHkvalue cHkvalue)
        {
            if (cHkvalue != null)
            {
                cHkvalue.CheckState = CheckState.Checked;
            }
        }

        public void setmergin
        (int cm, int cp, int pm, int pp)
        {
            cmergin = cm;
            cpadding = cp;
            panmergin = pm;
            panpadding = pp;


            PItems.Controls.Clear();
            //Pitem2.Margin = new Padding(panpadding);
            PItems.Margin = new System.Windows.Forms.Padding(0);
            PItems.Padding = new System.Windows.Forms.Padding(0);
            foreach (Control c in ItemLists)
            {
                foreach (Control cc in c.Controls)
                { cc.Margin = new System.Windows.Forms.Padding(0); cc.Padding = new System.Windows.Forms.Padding(0); }
                { c.Padding = new System.Windows.Forms.Padding(0); c.Margin = new System.Windows.Forms.Padding(0); }
                PItems.Controls.Add(c);
            }
            // Pitem2.Padding = new Padding(panmergin);

        }

        public class GridComb : GridComboBoxExEditControl
        {
            GridComb(List<string> tyeps)
            {
                this.Items.AddRange(tyeps.ToArray());
                this.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
        public static int setbillflagforcar = 0;
        public class CHkvalue : GridCheckBoxEditControl
        {
            public static string name = string.Empty;
            public CheckState State;
            public T_Item ItemData;
            public int Row_ID;
            public GridCell _Cell;




            public void clear()
            {
                if (setbillflagforcar == 0)
                {
                    CheckValueChecked = CheckState.Unchecked;

                    State = CheckState.Unchecked;
                    _Cell.CellStyles.Default.Background.Color1 = Color.White;

                    CheckState = CheckState.Unchecked;
                    _Cell.Value = string.Empty;
                    _Cell.CellStyles.Default.Background.Color1 = Color.White;
                }
                //   _Cell.EditorValueChanged(this);
            }


            public CHkvalue(object itm, object cc)
            {
                _Cell = (GridCell)cc;
                CheckValueChecked = CheckState.Unchecked;
                ItemData = (T_Item)itm;
                this.Text = (VarGeneral.UserLang == 0 ? ItemData.Arb_Des.ToString() : ItemData.Eng_Des.ToString());
                CheckedChanged += fsdfa;
                _Cell.PropertyChanged += CHANGE;
            }
            public void set(int c, int r, T_Item t)
            {
                if (c == 1)
                {
                    Row_ID = r;
                    ItemData = t;

                    State = CheckState.Checked;

                    CheckValueChecked = CheckState.Checked;
                    _Cell.Value = CheckState.Checked;
                    _Cell.Value = true;

                }
                else
                {
                    this.CheckState = CheckState.Unchecked; State = CheckState.Unchecked;

                    CheckValueChecked = CheckState.Unchecked;
                    _Cell.Value = CheckState.Unchecked;
                    _Cell.Value = false;
                }
                _Cell.InvalidateRender();
                _Cell.SuperGrid.Refresh();
            }

            private void CHANGE(object sender, PropertyChangedEventArgs e)
            {

                if (e.PropertyName == "Value")
                {
                    Type c = _Cell.Value.GetType();
                    if (c == typeof(CheckState))
                    {
                        try
                        {
                            if ((CheckState)_Cell.Value == CheckState.Checked)
                            {
                                CheckValueChecked = CheckState.Checked;
                            }
                            else if ((CheckState)_Cell.Value == CheckState.Unchecked)
                            {
                                CheckValueChecked = CheckState.Unchecked;
                            }
                            _Cell.InvalidateRender();
                        }
                        catch { clear(); }

                    }
                    else
                    {
                        try
                        {
                            if ((bool)_Cell.Value == true)
                            {
                                CheckValueChecked = CheckState.Checked;
                            }
                            else if ((bool)_Cell.Value == false)
                            {
                                CheckValueChecked = CheckState.Unchecked;
                            }
                            _Cell.InvalidateRender();
                        }
                        catch { clear(); }

                    }
                }


            }

            private void fsdfa(object sender, EventArgs e)
            {
                _Cell.SuperGrid.Refresh();


            }

#pragma warning disable CS0108 // 'catPanel.CHkvalue.GetType()' hides inherited member 'object.GetType()'. Use the new keyword if hiding was intended.
            public T_Unit GetType()
#pragma warning restore CS0108 // 'catPanel.CHkvalue.GetType()' hides inherited member 'object.GetType()'. Use the new keyword if hiding was intended.
            {
                int rowid = _Cell.RowIndex;
                int colid = _Cell.ColumnIndex;
                GridRow c = (GridRow)_Cell.SuperGrid.PrimaryGrid.Rows[rowid + 3];
                TypeGridButton ss = (TypeGridButton)c.Cells[colid].EditControl;
                return ss.gettype();
            }
            public TypeGridButton GetTypeControl()
            {
                int rowid = _Cell.RowIndex;
                int colid = _Cell.ColumnIndex;
                GridRow c = (GridRow)_Cell.SuperGrid.PrimaryGrid.Rows[rowid + 3];
                TypeGridButton ss = (TypeGridButton)c.Cells[colid].EditControl;
                return ss;
            }
            public PriceGridElement getpriceControl()
            {
                int rowid = _Cell.RowIndex;
                int colid = _Cell.ColumnIndex;
                GridRow c = (GridRow)_Cell.SuperGrid.PrimaryGrid.Rows[rowid + 2];
                PriceGridElement ss = (PriceGridElement)c.Cells[colid].EditControl;

                return ss;
            }
            public double getpriceControls()
            {
                if (State == CheckState.Checked)
                {
                    int rowid = _Cell.RowIndex;
                    int colid = _Cell.ColumnIndex;
                    GridRow c = (GridRow)_Cell.SuperGrid.PrimaryGrid.Rows[rowid + 2];
                    PriceGridElement ss = (PriceGridElement)c.Cells[colid].EditControl;

                    return ss.price;
                }
                return 0;
            }
            public void setprice(double d)
            {
                int rowid = _Cell.RowIndex;
                int colid = _Cell.ColumnIndex;
                GridRow c = (GridRow)_Cell.SuperGrid.PrimaryGrid.Rows[rowid + 2];
                PriceGridElement ss = (PriceGridElement)c.Cells[colid].EditControl;

                ss.setprice(d);
            }
            public void getChanges()
            {
                try
                {
                    int rowid = _Cell.RowIndex;
                    int colid = _Cell.ColumnIndex;
                    GridRow c = (GridRow)_Cell.SuperGrid.PrimaryGrid.Rows[rowid + 2];
                    GridCell ss = c.Cells[colid];
                    c = (GridRow)_Cell.SuperGrid.PrimaryGrid.Rows[rowid + 3];
                    GridCell ss1 = c.Cells[colid];
                    State = CheckState;

                    _Cell.SuperGrid.Refresh();
                }
                catch
                {

                }
            }
            private void cmm(object sender, EventArgs e)
            {

            }

            private void csd(object sender, EventArgs e)
            {
                //                throw new NotImplementedException
            }
        }
        List<ItemEventArg> PresentItems = new List<ItemEventArg>();
        public static int sflag = 0;
        private void superGridControl1_EditorValueChanged(object sender, GridEditEventArgs e)
        {
            if (ssas == 1)
                return;
            if (e.EditControl.EditorCell.EditorType == typeof(CHkvalue))
            {
                CHkvalue c; PriceGridElement p; TypeGridButton t;
                c = (CHkvalue)e.EditControl;
                p = (PriceGridElement)((GridRow)e.GridCell.SuperGrid.PrimaryGrid.Rows[e.GridCell.RowIndex + 2]).Cells[e.GridCell.ColumnIndex].EditControl;
                t = (TypeGridButton)((GridRow)e.GridCell.SuperGrid.PrimaryGrid.Rows[e.GridCell.RowIndex + 3]).Cells[e.GridCell.ColumnIndex].EditControl;
                sflag = 1;
                c.getChanges();
                CheckState cf = c.State;

                ItemEventArg v = new ItemEventArg();
                v.ItemData = c.ItemData;
                v.Price = p.getprice();
                v.state = c.State;
                v.Row_ID = c.Row_ID;
                v.CPanel_ID = Cpanel_ID;
                if (v.state == CheckState.Checked) v.Action = ActionInv.Add;
                else
                    v.Action = ActionInv.Remove;
                v.Type = t.gettype();
                Item_StateChanged(null, v);
                c = (CHkvalue)e.EditControl;
                c.Row_ID = v.Row_ID;
                p.Row_ID = v.Row_ID;
                t.Row_ID = v.Row_ID;
                p.setprice(v.Price);

                t.settype(v.Type);

                e.GridCell.SuperGrid.Refresh();


            }
            else if (e.EditControl.EditorCell.EditorType == typeof(TypeGridButton))
            {
                CHkvalue c; PriceGridElement p; TypeGridButton t;
                t = (TypeGridButton)e.EditControl;
                c = (CHkvalue)((GridRow)e.GridCell.SuperGrid.PrimaryGrid.Rows[e.GridCell.RowIndex - 3]).Cells[e.GridCell.ColumnIndex].EditControl;
                p = (PriceGridElement)((GridRow)e.GridCell.SuperGrid.PrimaryGrid.Rows[e.GridCell.RowIndex - 1]).Cells[e.GridCell.ColumnIndex].EditControl;
                c.getChanges();
                CheckState cf = c.State;

                ItemEventArg v = new ItemEventArg();
                v.ItemData = c.ItemData;

                v.Price = Utilites.ItemPriceOfUnit(t._Unit, c.ItemData);

                v.state = c.State;
                v.CPanel_ID = Cpanel_ID;
                v.Row_ID = c.Row_ID;
                v.Action = ActionInv.setUnit;
                v.Type = t._Unit;
                Item_TypeChanged(null, v);

                c.Row_ID = v.Row_ID;
                p.Row_ID = v.Row_ID;
                t.Row_ID = v.Row_ID;
                p.setprice(v.Price);
                e.GridCell.SuperGrid.Refresh();



            }
            else if (e.EditControl.EditorCell.EditorType == typeof(PriceGridElement))
            {
                CHkvalue c; PriceGridElement p; TypeGridButton t;
                p = (PriceGridElement)e.EditControl;
                c = (CHkvalue)((GridRow)e.GridCell.SuperGrid.PrimaryGrid.Rows[e.GridCell.RowIndex - 2]).Cells[e.GridCell.ColumnIndex].EditControl;
                t = (TypeGridButton)((GridRow)e.GridCell.SuperGrid.PrimaryGrid.Rows[e.GridCell.RowIndex + 1]).Cells[e.GridCell.ColumnIndex].EditControl;
                c.getChanges();
                CheckState cf = c.State;

                ItemEventArg v = new ItemEventArg();
                v.ItemData = c.ItemData;

                v.Price = p.price;
                v.state = c.State;
                v.CPanel_ID = Cpanel_ID;
                v.Row_ID = c.Row_ID;
                v.Action = ActionInv.SetPrice;
                v.Type = t._Unit;
                Item_PriceChanged(null, v);

                c.Row_ID = v.Row_ID;
                p.Row_ID = v.Row_ID;
                t.Row_ID = v.Row_ID;
                p.setprice(v.Price);

                e.GridCell.SuperGrid.Refresh();



            }
            calcluateTotals();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndex < TotalPage)
            {
                ClearItemsMain();
                CurrentPageIndex++;
                GetCurrentRecords(CurrentPageIndex, vBestSaller: false);
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            try
            {

                {
                    ItmMainParameter = string.Empty;
                    FillItmesMain(null, vBestSaller: true);
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("metroTilePanel_Cat_ItemClick:", error, enable: true);
                Refresh();
            }
        }

        private void superGridControl1_CellActivating(object sender, GridCellActivatingEventArgs e)
        {

        }

        private void superGridControl1_CellMouseDown(object sender, GridCellMouseEventArgs e)
        {

        }

        private void superGridControl1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void superGridControl1_CellClick(object sender, GridCellClickEventArgs e)
        {

        }

        private void superGridControl1_Enter(object sender, EventArgs e)
        {

        }

        private void superGridControl1_RowDeleting(object sender, GridRowDeletingEventArgs e)
        {


        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Contains("PIT"))
                propertyGrid1.SelectedObject = PItems;
            else if (comboBox1.Text.Contains("ite"))
                propertyGrid1.SelectedObject = ItemList[0];
            else if (comboBox1.Text.Contains("panel"))
                propertyGrid1.SelectedObject = itemPanel1;
        }

        private void itemPanel1_ItemClick(object sender, EventArgs e)
        {

        }

        private void itemPanel1_VisibleChanged(object sender, EventArgs e)
        {
            itemPanel1.VisibleChanged -= itemPanel1_VisibleChanged;
            itemPanel1.Visible = true;
            itemPanel1.VisibleChanged += itemPanel1_VisibleChanged;

        }

        private void propertyGrid1_Click(object sender, EventArgs e)
        {

        }

        private void Tot_Label_Click(object sender, EventArgs e)
        {

        }
        public static Bitmap Convert_Text_to_Image(string txt, string fontname, int fontsize)
        {
            //creating bitmap image
            Bitmap bmp = new Bitmap(1, 1);

            //FromImage method creates a new Graphics from the specified Image.
            Graphics graphics = Graphics.FromImage(bmp);
            // Create the Font object for the image text drawing.
            Font font = new Font(fontname, fontsize);
            // Instantiating object of Bitmap image again with the correct size for the text and font.
            SizeF stringSize = graphics.MeasureString(txt, font);
            bmp = new Bitmap(bmp, (int)stringSize.Width, (int)stringSize.Height);
            graphics = Graphics.FromImage(bmp);

            /* It can also be a way
           bmp = new Bitmap(bmp, new Size((int)graphics.MeasureString(txt, font).Width, (int)graphics.MeasureString(txt, font).Height));*/

            //Draw Specified text with specified format 
            graphics.DrawString(txt, font, Brushes.Red, 0, 0);
            font.Dispose();
            graphics.Flush();
            graphics.Dispose();
            return bmp;     //return Bitmap Image 
        }

        private void btnconvert_Click(object sender, EventArgs e)
        {
        }
        public class TypeGridButton : GridButtonXEditControl
        {
            public double price = 0;
            public GridCell _Cell;
            Stock_DataDataContext db = new Stock_DataDataContext(catPanel.bs);
            public string item_no = string.Empty;
            public T_Item ItemData;
            public string Txt_Unit = string.Empty;
            public T_Unit current_Unit
                ;
            public void clear()
            {
                Txt_Unit = string.Empty;
                _Unit = null;


            }
            public void settype(T_Unit t)
            {
                Txt_Unit = (VarGeneral.UserLang == 0 ? t.Arb_Des : t.Eng_Des); ;
                changes(null, null);
                _Unit = t;

            }
            public TypeGridButton(object itm, object c)
            {

                item_no = itm.ToString();
                ItemData = db.StockItem(item_no);

                price = double.Parse(itm.ToString());
                Click += type_search;
                this.Symbol = "";
                this.SymbolSize = 18F;

                Text = string.Empty;
                _Cell = (GridCell)c;



                _Cell.PropertyChanged += CHANGE;
            }

            private void CHANGE(object sender, PropertyChangedEventArgs e)
            {
                if (catPanel.ssa == 1) if (e.PropertyName == "Value")
                    {
                        string pp = string.Empty;
                        try
                        {
                            pp = (_Cell.Value.ToString());
                            _Unit = db.StockUnitbyname(pp);
                            settype(_Unit);
                        }
                        catch
                        {

                        }
                    };


            }

            public void activate(
              )
            {
                int rowid = _Cell.RowIndex;
                int colid = _Cell.ColumnIndex;
                GridRow cc = (GridRow)_Cell.SuperGrid.PrimaryGrid.Rows[rowid];
                GridCell ss = cc.Cells[colid];
                ss.ReadOnly = false;
            }

            public void Deactivate(
                )
            {
                int rowid = _Cell.RowIndex;
                int colid = _Cell.ColumnIndex;
                GridRow cc = (GridRow)_Cell.SuperGrid.PrimaryGrid.Rows[rowid];
                GridCell ss = cc.Cells[colid];
                ss.ReadOnly = true;
            }
            private void changes(object sender, EventArgs e)
            {
                string d = (VarGeneral.UserLang == 0 ? "النوع :" : "Type :");

                Text = Txt_Unit;
                _Cell.Value = Text;

                //   OnTextChanged(null);

            }

            public delegate void customMessageHandler(System.Object sender,
                                             ItemEventArg e);
#pragma warning disable CS0067 // The event 'catPanel.TypeGridButton.PriceChanged' is never used
            public event customMessageHandler PriceChanged;
#pragma warning restore CS0067 // The event 'catPanel.TypeGridButton.PriceChanged' is never used
            public int Row_ID;
            public CheckState State;
            public T_Unit _Unit;
#pragma warning disable CS0067 // The event 'catPanel.TypeGridButton.ItemCheckedChanged' is never used
            public event customMessageHandler ItemCheckedChanged;
#pragma warning restore CS0067 // The event 'catPanel.TypeGridButton.ItemCheckedChanged' is never used
#pragma warning disable CS0067 // The event 'catPanel.TypeGridButton.ItemTypeChanged' is never used
            public event customMessageHandler ItemTypeChanged;
#pragma warning restore CS0067 // The event 'catPanel.TypeGridButton.ItemTypeChanged' is never used
#pragma warning disable CS0067 // The event 'catPanel.TypeGridButton.TOTCal_ReadY' is never used
            public event customMessageHandler TOTCal_ReadY;
#pragma warning restore CS0067 // The event 'catPanel.TypeGridButton.TOTCal_ReadY' is never used
            public T_Unit gettype()
            {
                return _Unit;
            }

            private void type_search(object sender, EventArgs e)
            {
                GridRow r = (GridRow)_Cell.SuperGrid.PrimaryGrid.Rows[_Cell.RowIndex - 3];
                GridCell cc = r[_Cell.ColumnIndex];
                CHkvalue f = (CHkvalue)cc.EditControl;
                if (f.State == CheckState.Unchecked) return;

                if (db == null) db = new Stock_DataDataContext(bs);
                List<T_Unit> listUnit = db.T_Units.ToList<T_Unit>();
                _Unit = null;
                FrmItemSize frm = new FrmItemSize(item_no);
                frm.Tag = VarGeneral.CurrentLang;
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.vSts_Op)
                {
                    if (frm.vSize_ == 0)
                    {
                        for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                        {
                            _Unit = listUnit[iiCnt];
                            if (ItemData.Unit1 == _Unit.Unit_ID)
                            {
                                //  ItemData.Pack1.Value;
                                Txt_Unit = (VarGeneral.UserLang == 0 ? _Unit.Arb_Des : _Unit.Eng_Des); ;

                                //  DefUnitE = _Unit.Eng_Des;
                                //   FlxInv.SetData(FlxInv.Row, 8, ItemData.UntPri1.Value);
                                //   FlxInv.SetData(FlxInv.Row, 11, ItemData.Pack1.Value);
                                break;
                            }
                        }
                    }
                    else if (frm.vSize_ == 1)
                    {
                        for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                        {
                            _Unit = listUnit[iiCnt];
                            if (ItemData.Unit2 == _Unit.Unit_ID)
                            {
                                //  ItemData.Pack2.Value;
                                Txt_Unit = (VarGeneral.UserLang == 0 ? _Unit.Arb_Des : _Unit.Eng_Des); ;
                                //  DefUnitE = _Unit.Eng_Des;
                                //   FlxInv.SetData(FlxInv.Row, 8, ItemData.UntPri2.Value);
                                //   FlxInv.SetData(FlxInv.Row, 11, ItemData.Pack2.Value);
                                break;
                            }
                        }
                    }
                    else if (frm.vSize_ == 2)
                    {
                        for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                        {
                            _Unit = listUnit[iiCnt];
                            if (ItemData.Unit3 == _Unit.Unit_ID)
                            {
                                //  ItemData.Pack3.Value;
                                Txt_Unit = (VarGeneral.UserLang == 0 ? _Unit.Arb_Des : _Unit.Eng_Des); ;
                                //  DefUnitE = _Unit.Eng_Des;
                                //   FlxInv.SetData(FlxInv.Row, 8, ItemData.UntPri3.Value);
                                //   FlxInv.SetData(FlxInv.Row, 11, ItemData.Pack3.Value);
                                break;
                            }
                        }
                    }
                    else if (frm.vSize_ == 3)
                    {
                        for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                        {
                            _Unit = listUnit[iiCnt];
                            if (ItemData.Unit4 == _Unit.Unit_ID)
                            {
                                //  ItemData.Pack4.Value;
                                Txt_Unit = (VarGeneral.UserLang == 0 ? _Unit.Arb_Des : _Unit.Eng_Des); ;
                                //  DefUnitE = _Unit.Eng_Des;
                                //   FlxInv.SetData(FlxInv.Row, 8, ItemData.UntPri4.Value);
                                //   FlxInv.SetData(FlxInv.Row, 11, ItemData.Pack4.Value);
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                        {
                            _Unit = listUnit[iiCnt];
                            if (ItemData.Unit5 == _Unit.Unit_ID)
                            {

                                Txt_Unit = (VarGeneral.UserLang == 0 ? _Unit.Arb_Des : _Unit.Eng_Des); ;
                                //  DefUnitE = _Unit.Eng_Des;
                                //   FlxInv.SetData(FlxInv.Row, 8, ItemData.UntPri5.Value);
                                //   FlxInv.SetData(FlxInv.Row, 11, ItemData.Pack5.Value);
                                break;
                            }
                        }
                    }
                    changes(null, null);
                    _Cell.EditorValueChanged(this);

                }



            }
        }
        public class PriceGridElement : GridButtonXEditControl
        {
            public double price = 0;
            GridCell _Cell;
            public PriceGridElement(object p, Object c)
            {
                price = double.Parse(p.ToString());
                Click += Open_Price;
                this.Symbol = "";
                this.SymbolSize = 18F;

                Text = "0.0";
                _Cell = (GridCell)c;



                _Cell.PropertyChanged += CHANGE;
            }

            private void CHANGE(object sender, PropertyChangedEventArgs e)
            {
                if (catPanel.ssa == 1) if (e.PropertyName == "Value")
                    {
                        double pp = 0;
                        try
                        {
                            pp = double.Parse(_Cell.Value.ToString());
                            price = pp;
                            Text = price.ToString();
                            _Cell.EditControl.EditorValue = Text;
                            _Cell.Value = Text;
                            _Cell.EditControl.EditorValueChanged = true;
                            _Cell.EditorValueChanged(this);

                        }
                        catch
                        {

                        }
                    };


            }

            public void clear()
            {
                setprice(0);

            }
            public void activate(
              )
            {
                int rowid = _Cell.RowIndex;
                int colid = _Cell.ColumnIndex;
                GridRow cc = (GridRow)_Cell.SuperGrid.PrimaryGrid.Rows[rowid];
                GridCell ss = cc.Cells[colid];
                ss.ReadOnly = false;
            }

            public void Deactivate(
                )
            {
                int rowid = _Cell.RowIndex;
                int colid = _Cell.ColumnIndex;
                GridRow cc = (GridRow)_Cell.SuperGrid.PrimaryGrid.Rows[rowid];
                GridCell ss = cc.Cells[colid];
                ss.ReadOnly = true;

            }
            public double getprice()
            {
                return price;
            }
            public int Row_ID;
            private void Open_Price(object sender, EventArgs e)
            {
                GridRow r = (GridRow)_Cell.SuperGrid.PrimaryGrid.Rows[_Cell.RowIndex - 2];
                GridCell cc = r[_Cell.ColumnIndex];
                CHkvalue f = (CHkvalue)cc.EditControl;
                if (f.State == CheckState.Unchecked) return;
                FrmPOSPriceForm2 fr = new FrmPOSPriceForm2()
                    ;
                fr.price = price;
                fr.StartPosition = FormStartPosition.CenterScreen;
                fr.TopMost = true;
                fr.ShowDialog();
                price = fr.price;
                Text = price.ToString();
                _Cell.EditControl.EditorValue = Text;
                _Cell.Value = Text;
                _Cell.EditControl.EditorValueChanged = true;
                _Cell.EditorValueChanged(this);
            }
            public void setprice(double it)
            {
                price = it;

                Text = price.ToString();
                _Cell.BeginEdit(false);
                _Cell.Value = Text;

                _Cell.EndEdit();

                //    EditorCell.Value = Text;
                //EditorCell.InvalidateRender();

            }
        }
        public class ThisGridComboBoxControl : GridTextBoxXEditControl
        {
            Stock_DataDataContext db = new Stock_DataDataContext(bs);
            public string item_no = string.Empty;
            public T_Item ItemData;
            public string Txt_Unit = string.Empty;
            public ThisGridComboBoxControl(object itm)
            {

                item_no = itm.ToString();
                ItemData = db.StockItem(item_no);
                ButtonCustom.Visible = true;
                ButtonCustomClick += dfasf;
                //   Click += type_search;

            }

            private void dfasf(object sender, EventArgs e)
            {
                type_search(null, null);
            }

            private void changes(object sender, EventArgs e)
            {
                string d = (VarGeneral.UserLang == 0 ? "النوع :" : "Type :");

                Text = d + "[" + Txt_Unit + "]";
                EditorValue = Text;
                EditorCell.InvalidateRender();
                //   OnTextChanged(null);

            }

            public delegate void customMessageHandler(System.Object sender,
                                             ItemEventArg e);
#pragma warning disable CS0067 // The event 'catPanel.ThisGridComboBoxControl.PriceChanged' is never used
            public event customMessageHandler PriceChanged;
#pragma warning restore CS0067 // The event 'catPanel.ThisGridComboBoxControl.PriceChanged' is never used
            public int Row_ID;
            public CheckState State;

#pragma warning disable CS0067 // The event 'catPanel.ThisGridComboBoxControl.ItemCheckedChanged' is never used
            public event customMessageHandler ItemCheckedChanged;
#pragma warning restore CS0067 // The event 'catPanel.ThisGridComboBoxControl.ItemCheckedChanged' is never used
#pragma warning disable CS0067 // The event 'catPanel.ThisGridComboBoxControl.ItemTypeChanged' is never used
            public event customMessageHandler ItemTypeChanged;
#pragma warning restore CS0067 // The event 'catPanel.ThisGridComboBoxControl.ItemTypeChanged' is never used
#pragma warning disable CS0067 // The event 'catPanel.ThisGridComboBoxControl.TOTCal_ReadY' is never used
            public event customMessageHandler TOTCal_ReadY;
#pragma warning restore CS0067 // The event 'catPanel.ThisGridComboBoxControl.TOTCal_ReadY' is never used

            private void type_search(object sender, EventArgs e)
            {

                if (db == null) db = new Stock_DataDataContext(bs);
                List<T_Unit> listUnit = db.T_Units.ToList<T_Unit>();
                T_Unit _Unit = null;
                FrmItemSize frm = new FrmItemSize(item_no);
                frm.Tag = VarGeneral.CurrentLang;
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.vSts_Op)
                {
                    if (frm.vSize_ == 0)
                    {
                        for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                        {
                            _Unit = listUnit[iiCnt];
                            if (ItemData.Unit1 == _Unit.Unit_ID)
                            {
                                //  ItemData.Pack1.Value;
                                Txt_Unit = (VarGeneral.UserLang == 0 ? _Unit.Arb_Des : _Unit.Eng_Des);

                                //  DefUnitE = _Unit.Eng_Des;
                                //   FlxInv.SetData(FlxInv.Row, 8, ItemData.UntPri1.Value);
                                //   FlxInv.SetData(FlxInv.Row, 11, ItemData.Pack1.Value);
                                break;
                            }
                        }
                    }
                    else if (frm.vSize_ == 1)
                    {
                        for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                        {
                            _Unit = listUnit[iiCnt];
                            if (ItemData.Unit2 == _Unit.Unit_ID)
                            {
                                //  ItemData.Pack2.Value;
                                Txt_Unit = (VarGeneral.UserLang == 0 ? _Unit.Arb_Des : _Unit.Eng_Des); ;
                                //  DefUnitE = _Unit.Eng_Des;
                                //   FlxInv.SetData(FlxInv.Row, 8, ItemData.UntPri2.Value);
                                //   FlxInv.SetData(FlxInv.Row, 11, ItemData.Pack2.Value);
                                break;
                            }
                        }
                    }
                    else if (frm.vSize_ == 2)
                    {
                        for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                        {
                            _Unit = listUnit[iiCnt];
                            if (ItemData.Unit3 == _Unit.Unit_ID)
                            {
                                //  ItemData.Pack3.Value;
                                Txt_Unit = (VarGeneral.UserLang == 0 ? _Unit.Arb_Des : _Unit.Eng_Des); ;
                                //  DefUnitE = _Unit.Eng_Des;
                                //   FlxInv.SetData(FlxInv.Row, 8, ItemData.UntPri3.Value);
                                //   FlxInv.SetData(FlxInv.Row, 11, ItemData.Pack3.Value);
                                break;
                            }
                        }
                    }
                    else if (frm.vSize_ == 3)
                    {
                        for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                        {
                            _Unit = listUnit[iiCnt];
                            if (ItemData.Unit4 == _Unit.Unit_ID)
                            {
                                //  ItemData.Pack4.Value;
                                Txt_Unit = (VarGeneral.UserLang == 0 ? _Unit.Arb_Des : _Unit.Eng_Des); ;
                                //  DefUnitE = _Unit.Eng_Des;
                                //   FlxInv.SetData(FlxInv.Row, 8, ItemData.UntPri4.Value);
                                //   FlxInv.SetData(FlxInv.Row, 11, ItemData.Pack4.Value);
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                        {
                            _Unit = listUnit[iiCnt];
                            if (ItemData.Unit5 == _Unit.Unit_ID)
                            {

                                Txt_Unit = (VarGeneral.UserLang == 0 ? _Unit.Arb_Des : _Unit.Eng_Des); ;
                                //  DefUnitE = _Unit.Eng_Des;
                                //   FlxInv.SetData(FlxInv.Row, 8, ItemData.UntPri5.Value);
                                //   FlxInv.SetData(FlxInv.Row, 11, ItemData.Pack5.Value);
                                break;
                            }
                        }
                    }
                    changes(null, null);

                }



            }
        }


    }
    public enum ActionInv
    {
        Notset = 0, Add = 1, Remove = 2, SetPrice = 3, SetQuantity = 4, setUnit = 5, opennewbill = 6

    }

    public partial class CatINvDetealilsArg : System.EventArgs
    {
        private double price;
        public ActionInv Action;
        public int Col_ID;
        public int cPanel_ID;
        public CheckState Item_state;
        public T_Item ItemData;
        public int Row_ID;
        public T_Unit Type;

        public List<T_INVDET> LDataThis
        {
            get
            {
                return LDataThis;
            }
            set
            {
                LDataThis = value;
            }
        }


        public double Price

        {
            get
            {

                return price;
            }
            set
            {
                price = value;
            }
        }
    }

}
