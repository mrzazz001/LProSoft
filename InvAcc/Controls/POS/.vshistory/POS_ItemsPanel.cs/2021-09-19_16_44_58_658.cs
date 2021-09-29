using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace InvAcc.Controls.POS
{
    public partial class POS_ItemsPanel : UserControl
    {
        public event customMessageHandler Product_Click;
        public delegate void customMessageHandler(System.Object sender,
                                        ItemEventArg e);
        public POS_ItemsPanel()
        {
            try
            {
                InitializeComponent();
            }
            catch { }
          
        }
      
        private void arrowButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void simpleButton1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void orientedButton1_Click(object sender, EventArgs e)
        {

        }

        private  void POS_ItemsPanel_Load(object sender, EventArgs e)

        {
            try
            {
              
                if (LicenseUsageMode.Designtime != LicenseManager.UsageMode)
                {
                    CategoryGride.mode = 1;
                    CategoryGride.itemClick += ItmClick;
                    CategoryGride.fill(0, false);
                   
                    ItemsGride.mode = 0;
                    ItemsGride.itemClick += ProductClick;
                    ItemsGride.CAT_ID = 1;

                    ItemsGride.fill(1, false);


                }
            }
            catch { }
        }

        private void ProductClick(object sender, ItemEventArg e)
        {if (Product_Click != null)
                Product_Click(sender, e);
            
        }

        private void ItmClick(object sender, ItemEventArg e)
        {
            ItemsGride.CAT_ID = int.Parse(e.item_No);
            ItemsGride.fillcat(ItemsGride.CAT_ID);
        }

        private void orientedButton2_Click(object sender, EventArgs e)
        {
            
       
        }

        private void HeaderPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void poS_ItemsGride2_Load(object sender, EventArgs e)
        {

        }

        private void poS_ItemsGride2_Load_1(object sender, EventArgs e)
        {

        }
        public void filter(string s)
        {
            ItemsGride.sedfilter(s);

        }
        private void TexBoxFilter_TextChanged(object sender, EventArgs e)
        {
          //  ItemsGride.sedfilter( testc.Text);
         //   poS_ItemsGride1.TextBoxFilter_TextChanged(sender, e);
        }

        private void ItemsGride_Load(object sender, EventArgs e)
        { 
         
        }

        private void ItemsGride_Click(object sender, EventArgs e)
        {

        //    ItemsGride.fill(1, false);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void orientedButton2_Click_1(object sender, EventArgs e)
        {

        
        }
    }
}
