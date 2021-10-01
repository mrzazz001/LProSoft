using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
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
                if (VarGeneral.ISPOSPagesVisable == true)
                {

                    panel1.Visible = true;
                }
                panel2.BackColor = Color.White;
                this.BackColor= Color.White;
                ItemsGride.BackColor= Color.White;
                HeaderPanel.BackColor = Color.White;
                HeaderPanel.Dock = DockStyle.Top;
               

            }
            catch { }
          
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
                
                //if (LicenseUsageMode.Designtime != LicenseManager.UsageMode)
                {if (ppp == -1) ppp = (VarGeneral.IsBackPOSButtonOn ? 1 : 0);
                    if (ppp == 0)
                    {
                        CategoryGride.Visible = true;
                        panel2.Visible = true;
                        CategoryGride.mode = 1;
                        CategoryGride.itemClick += ItmClick;
                        CategoryGride.fill(0, false);
                    }else
                    {
                        CategoryGride.Visible = false;
                        HeaderPanel.Visible = false;
                        panel2.Visible = false;
                       
                    }
                    ItemsGride.mode = 0;
                    ItemsGride.itemClick += ProductClick;
                    ItemsGride.CAT_ID = 1;

                    ItemsGride.fill(1, false);


                }
            }
            catch { }
        }
        int ppp = -1;
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
  
        private int TotalPage = 0;
        private int CurrentPageIndex = 1;
#pragma warning disable CS0414 // The field 'Pos_ItemPanel.CurrentPageIndexItmDet' is assigned but its value is never used
        private int CurrentPageIndexItmDet = 1;
        private void arrowButton3_Click(object sender, EventArgs e)
        {
            ItemsGride.PreivousPage();
        }

        private void arrowButton4_Click(object sender, EventArgs e)
        {

            ItemsGride.NextPage();
       

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            arrowButton3_Click(null, null);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            arrowButton4_Click(null, null);
        }

        private void POS_ItemsPanel_SizeChanged(object sender, EventArgs e)
        {
            HeaderPanel.Height = 115;
        }
    }
}
