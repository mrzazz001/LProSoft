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
#pragma warning disable CS0067 // The event 'POS_ItemsPanel.OpenCasher_Click' is never used
        public event customMessageHandler OpenCasher_Click;
#pragma warning restore CS0067 // The event 'POS_ItemsPanel.OpenCasher_Click' is never used
        public delegate void customMessageHandler(System.Object sender,
                                        ItemEventArg e);
#pragma warning disable CS0649 // Field 'POS_ItemsPanel.poS_ItemsGride1' is never assigned to, and will always have its default value null
#pragma warning disable CS0169 // The field 'POS_ItemsPanel.poS_CategoryGride' is never used
        POS_ItemsGride poS_ItemsGride1,poS_CategoryGride;
#pragma warning restore CS0169 // The field 'POS_ItemsPanel.poS_CategoryGride' is never used
#pragma warning restore CS0649 // Field 'POS_ItemsPanel.poS_ItemsGride1' is never assigned to, and will always have its default value null
        public POS_ItemsPanel()
        {
            InitializeComponent();

            try {
                if (VarGeneral.currentintlanguage == 1) 
                    TexBoxFilter.WaterMarkText = "Type Something To Search...";
                else
                    TexBoxFilter.WaterMarkText = "اكتب شيأ للبحث...";
            }
            catch
            {

            }
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
                    //CategoryGride.mode = 1;
                    //CategoryGride.itemClick += ItmClick;
                    //ItemsGride.mode = 0;
                    //ItemsGride.itemClick += ProductClick;
                    //ItemsGride.CAT_ID = 1;
                    //CategoryGride.fill(0, false);
                    //ItemsGride.fill(1, false);


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
            poS_ItemsGride1.mode = 1;
            poS_ItemsGride1.fill(1, false);
       
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

        private void TexBoxFilter_TextChanged(object sender, EventArgs e)
        {
            ItemsGride.sedfilter( TexBoxFilter.Text);
         //   poS_ItemsGride1.TextBoxFilter_TextChanged(sender, e);
        }

        private void ItemsGride_Load(object sender, EventArgs e)
        { 
         
        }

        private void ItemsGride_Click(object sender, EventArgs e)
        {

            ItemsGride.fill(1, false);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void orientedButton2_Click_1(object sender, EventArgs e)
        {

            poS_ItemsGride1.mode = 0;
            poS_ItemsGride1.fill(1, false);
        }
    }
}
