using DevComponents.DotNetBar;
using System;
using System.Windows.Forms;

namespace InvAcc.Controls
{
    public partial class POSCatBar : UserControl
    {
        public POSCatBar()
        {
            InitializeComponent();//
        }
        public ItemContainer itemContainer_Cat
        {
            set
            {
                itemContainer_Cat = value;
                DisplayedITemSet = value;
                metroTilePanel_Cat.Refresh();

            }
            get
            {
                return itemContainer_Cat;
            }
        }
        private void Button_Next_Click(object sender, EventArgs e)
        {

        }
    }
}
