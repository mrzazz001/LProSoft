using DevComponents.DotNetBar;
using InvAcc.GeneralM;
using InvAcc.Properties;
using InvAcc.Stock_Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace InvAcc.Controls
{
    public partial class POSItem : UserControl
    {
        public POSItem()
        {
            InitializeComponent();//
            Item_Price.price = 1;
        }

        
        public delegate void customMessageHandler(System.Object sender,
                                           ItemEventArg e);
        public event customMessageHandler PriceChanged;
        public event customMessageHandler Unit_Changed;
        public event customMessageHandler FStatechanged;
        public event customMessageHandler Edit;
        public event customMessageHandler ItemCheckedChanged, TOTCal_ReadY;
        public int Row_ID = -10;
        public int cPanel_ID;

        private void ItemPic_Click(object sender, EventArgs e)
        { ItemEventArg es = new ItemEventArg();
            es.item_No = Tag.ToString();
            if (Item_Click != null)
                Item_Click(null, es);

        }
        public Image img
        {
            set { Item_Image.Image = value; }
            get { return Item_Image.Image; }
        }
        public string name
        {
            set {  Item_name.Text=value; }
            get {return Item_name.Text; }
        }
        public bool pvisable
        {
            set { Item_Price.Visible = value; }
            get { return Item_Price.Visible; }
        }
        private void Item_Image_Click(object sender, EventArgs e)
        {
            ItemEventArg es = new ItemEventArg();
            es.item_No = Tag.ToString();
            if (Item_Click != null)
                Item_Click(null, es);
        }

        private void Item_name_Click(object sender, EventArgs e)
        {
            ItemEventArg es = new ItemEventArg();
            es.item_No = Tag.ToString();
            if (Item_Click != null)
                Item_Click(null, es);
        }

        //   public event customMessageHandler ItemCheckedChanged;
        public event customMessageHandler Item_Click;

        private void windowsUIButtonPanel1_Click(object sender, EventArgs e)
        {

        }

        private void Item_name_Click_1(object sender, EventArgs e)
        {

        }

        private void Item_name_Click_2(object sender, EventArgs e)
        {

        }
        public bool price
        {
            set { Item_Price.Visible = value; }
            get { return Item_Price.Visible; }
        }
        private void Item_Price_Click(object sender, EventArgs e)
        {

        }

        internal void clear()
        {
            Item_Image.Image = null;
            Item_name.Text = "";
        }
    }
   
}
