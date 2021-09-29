using InvAcc.Stock_Data;
using System;
using System.Windows.Forms;

namespace InvAcc.Forms
{
    public partial class FrmPOSPriceForm : Form
    {
        public FrmPOSPriceForm()
        {
            InitializeComponent();
        }
        public double price = 0.0;
        public T_Item ITemData;
        public T_Unit ItemUnit;
        public string Item_no;
        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void FrmPOSPriceForm_Load(object sender, EventArgs e)
        {
            Tot_Text.Value = price;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button_Unit1_Click(object sender, EventArgs e)
        {
            Tot_Text.Value = Tot_Text.Value - 1;


        }

        private void button_Unit2_Click(object sender, EventArgs e)
        {
            Tot_Text.Value = Tot_Text.Value + 1;



        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            price = Tot_Text.Value;
            Close();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
