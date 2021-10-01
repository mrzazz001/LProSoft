using DevComponents.DotNetBar;
using ProShared.GeneralM;using ProShared;
using ProShared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ProShared.Stock_Data;

namespace InvAcc.Controls
{
    public partial class CarInvData : UserControl
    {
        public CarInvData(int y, int pos = 0)
        {
            InvType = y;
            InitializeComponent();
            this.RightToLeft = RightToLeft.Inherit;
            loaditems(pos);
        }
        ProShared.Stock_Data.Stock_DataDataContext db = new ProShared.Stock_Data.Stock_DataDataContext(ProShared.GeneralM.VarGeneral.BranchCS);
#pragma warning disable CS0169 // The field 'CarInvData.t_items' is never used
        List<T_Item> t_items;
#pragma warning restore CS0169 // The field 'CarInvData.t_items' is never used
        List<T_CATEGORY> t_CATEGORYes;
        List<BaseItem> TabsInv;
        List<KeyValuePair<int, int>> itemmap = new List<KeyValuePair<int, int>>();
        public static int ControlsCount = 0;
        List<catPanel> CpList = new List<catPanel>();
        void loaditems(int pos = 0)
        {
            TabsInv = new List<BaseItem>();

            int i = 0;
            t_CATEGORYes = db.StoctCatList();
            DevComponents.DotNetBar.SuperTabItem p = new DevComponents.DotNetBar.SuperTabItem();
#pragma warning disable CS0168 // The variable 'cc' is declared but never used
            BaseItem cc;
#pragma warning restore CS0168 // The variable 'cc' is declared but never used
            List<DevComponents.DotNetBar.SuperTabControlPanel> ppl = new List<DevComponents.DotNetBar.SuperTabControlPanel>();
            DevComponents.DotNetBar.SuperTabControlPanel pp;
#pragma warning disable CS0168 // The variable 'ps' is declared but never used
            DevComponents.DotNetBar.ItemPanel ps;
#pragma warning restore CS0168 // The variable 'ps' is declared but never used
            new List<BaseItem>();
            int id = 0;
            itemmap.Clear();
            foreach (T_CATEGORY c in t_CATEGORYes)
            {
                p = new DevComponents.DotNetBar.SuperTabItem();
                pp = new SuperTabControlPanel();
                p.Name = (VarGeneral.UserLang == 0 ? c.Arb_Des : c.Eng_Des); ;
                p.Text = (VarGeneral.UserLang == 0 ? c.Arb_Des : c.Eng_Des); ;


                catPanel csa = new catPanel();
                p.Tag = csa;
                p.ExpandChange += refreshss;
                if (pos == 1)
                    itemmap.AddRange(csa.loadItemsOfCategory(c.CAT_ID, id, pos));
                else
                    itemmap.AddRange(csa.loadItemsOfCategory(c.CAT_ID, id));
                id++;
                csa.Item_Price_Changed += cPanel_PriceChanged;
                csa.Item_Added += cPanel_Item_Added;
                csa.Edit += changetoedit;
                csa.BackColor = Color.White;
                csa.Item_Removed += cPanel_Item_Removed;
                csa.Item_UnitSeted += catPanel_Item_UnitSeted;

                csa.Dock = DockStyle.Fill;
                DevComponents.DotNetBar.ItemPanel pl = new DevComponents.DotNetBar.ItemPanel();
                pl.Dock = DockStyle.Fill;
                pl.BackColor = Color.White;
                pl.TouchEnabled = true;
                pl.Controls.Add(csa);
                pp.Controls.Add(pl);
                pp.TabItem = p;
                p.AttachedControl = pp;
                ppl.Add(pp);
                TabsInv.Add(p);
                CpList.Add(csa);
                i++;

            }
            InvDetails.Controls.AddRange(ppl.ToArray());
            InvDetails.Tabs.AddRange(TabsInv.ToArray());

            this.OrderStatusSwitch = new DevComponents.DotNetBar.SwitchButtonItem();
            //  if (InvType == 0)
            {
                this.OrderStatusSwitch.ButtonWidth = 100;
                this.OrderStatusSwitch.Name = "OrderStatusSwitch";


                this.OrderStatusSwitch.OffText = (VarGeneral.UserLang == 0 ? "تحت التنفيذ:" : "Under Execution: ");
                this.OrderStatusSwitch.OnText = (VarGeneral.UserLang == 0 ? "تم التنفيذ:" : "Don :");


                this.OrderStatusSwitch.SwitchWidth = 20;
                this.InvDetails.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.OrderStatusSwitch});

                OrderStatusSwitch.Value = false;
                OrderStatusSwitch.MouseDown += dfa;
            }
            InvDetails.Refresh();


        }

        private void refreshss(object sender, EventArgs e)
        {
            catPanel c = (catPanel)sender;
            c.Refress();
        }

        public int InvType = 0;
        private void dfa(object sender, MouseEventArgs e)
        {
            changetoedit(null, null);
        }

        public void setprice(int r, double price)
        {
            foreach (catPanel c in CpList)
            {
                c.setprice(r, price);
            }


        }
        public int getorderstatus()
        {
            if (InvType == 1)
                return 1;

            if (OrderStatusSwitch.Value)
                return 1;
            else
                return 0;
        }
        private void changetoedit(object sender, CatINvDetealilsArg e)
        {
            if (ChangeTOEditMode != null)
            {
                CatINvDetealilsArg ew = new CatINvDetealilsArg();
                ew.Action = ActionInv.opennewbill;

                ChangeTOEditMode(null, ew);

                if (ew.Action == ActionInv.setUnit)
                { }
            }

        }

        private void catPanel_Item_UnitSeted(object sender, CatINvDetealilsArg e)
        {
            CatINvDetealilsArg arg = new CatINvDetealilsArg();
            arg = e;
            if (SetUnit_Item != null)
            {
                SetUnit_Item(this, arg);
                e = arg;
            }

        }

        private void cPanel_Item_Removed(object sender, CatINvDetealilsArg e)
        {
            CatINvDetealilsArg arg = new CatINvDetealilsArg();
            arg = e;
            if (Remove_Item != null)
            {
                Remove_Item(this, arg);
                e.Row_ID = -100;
            }
        }

        private void cPanel_Item_Added(object sender, CatINvDetealilsArg e)
        {
            CatINvDetealilsArg arg = new CatINvDetealilsArg();
            arg = e;
            if (Add_Item != null)
            {

                Add_Item(this, arg);
                e = arg;
            }

        }
#pragma warning disable CS0067 // The event 'CarInvData.FstateChanged' is never used
        public event customMessageHandler FstateChanged;
#pragma warning restore CS0067 // The event 'CarInvData.FstateChanged' is never used
        private void cPanel_PriceChanged(object sender, CatINvDetealilsArg e)
        {
            CatINvDetealilsArg arg = new CatINvDetealilsArg();
            arg = e;
            if (Item_PriceChanged != null)
            {
                Item_PriceChanged(null, arg)
                    ;
                e = arg;
            }


        }

        private void CarInvData_Load(object sender, EventArgs e)
        {


        }

        private void superTabControl_CostSts_SelectedTabChanged(object sender, DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs e)
        {

        }

        private void superTabControlPanel6_Click(object sender, EventArgs e)
        {

        }

        private void tab1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
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
        public static OrderStatus Ostatus;
        public void setBillData(List<T_INVDET> ldate, OrderStatus k)
        {
            int iff = 1;
            Ostatus = k;
            clear();
            if (k == OrderStatus.Done)
            {
                OrderStatusSwitch.Value = true;
            }
            else
          if (k == OrderStatus.UnderExecution) OrderStatusSwitch.Value = false;
            else if (k == OrderStatus.finshied)
            {
                OrderStatusSwitch.Value = true;

                OrderStatusSwitch.Enabled = false;
                this.Enabled = false;
            }

            //   try
            {
                foreach (T_INVDET j in ldate)
                {
                    T_Item it = db.StockItem(j.ItmNo);
                    T_Unit u = db.StockUnitbyname(j.ItmUnt);
                    KeyValuePair<int, int> key = itemmap.Find(i => i.Key == it.Itm_ID);
                    iff = CpList[key.Value].setItemData((double)j.Price, it, iff, u, 0);
                }
            }

            //     catch(Exception ex)
            { }
        }
        public void setBillData(List<T_INVDET> ldate, OrderStatus k, int ksa)
        {
            int iff = 1;
            Ostatus = k;
            clear();
            if (k == OrderStatus.Done)
            {
                OrderStatusSwitch.Value = true;
            }
            else
          if (k == OrderStatus.UnderExecution) OrderStatusSwitch.Value = false;
            else if (k == OrderStatus.finshied)
            {
                OrderStatusSwitch.Value = true;

                OrderStatusSwitch.Enabled = false;
                this.Enabled = false;
            }

            //   try
            {
                foreach (T_INVDET j in ldate)
                {
                    T_Item it = db.StockItem(j.ItmNo);
                    T_Unit u = db.StockUnitbyname(j.ItmUnt);
                    KeyValuePair<int, int> key = itemmap.Find(i => i.Key == it.Itm_ID);
                    iff = CpList[key.Value].setItemData((double)j.Price, it, iff, u, ksa);
                }
            }

            //     catch(Exception ex)
            { }
        }

        public void clear()
        {
            foreach (catPanel i in CpList)
                i.clear();
            OrderStatusSwitch.Value = false;
            this.Enabled = true;
            OrderStatusSwitch.Enabled = true;
        }
        private DevComponents.DotNetBar.CheckBoxItem OrderUnderExectuion;
        private DevComponents.DotNetBar.CheckBoxItem OrderExectuionDone;
        public int orderStatus
            ()
        {
            int i = 0;
            if (OrderStatusSwitch.Value == true)
            {
                i = 1;
            }
            else

            {
                i = 0;
            }
            return i;
        }
        private void InvDetails_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        {

        }
        public delegate void customMessageHandler(System.Object sender,
                                        CatINvDetealilsArg e);
        public event customMessageHandler Item_PriceChanged;
        public event customMessageHandler Add_Item;
        public event customMessageHandler Remove_Item;
        public event customMessageHandler SetUnit_Item;
#pragma warning disable CS0067 // The event 'CarInvData.Item_Price_Entered' is never used
        public event customMessageHandler Item_Price_Entered;
#pragma warning restore CS0067 // The event 'CarInvData.Item_Price_Entered' is never used
        public event customMessageHandler ChangeTOEditMode;

    }
    public enum OrderStatus
    {
        UnderExecution = 0, Done = 1, finshied = 3
    }
}
