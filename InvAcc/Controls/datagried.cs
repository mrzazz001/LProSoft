using ProShared.Stock_Data;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace InvAcc.Controls
{
    public partial class datagried : UserControl
    {
        public datagried()
        {
            InitializeComponent();
        }
        T_INVHED data;
        public void setdata(T_INVHED t)
        {
            data = t;
            label1.Text = t.InvNo;
            label2.Text = t.CusVenNm;
            label3.Text = t.CusVenMob;
            label4.Text = t.Car_TypeNameA;
            label5.Text = t.Car_NameA;
            label6.Text = t.PlateNo;
            label7.Text = t.Delevery_Date.ToString();
            label8.Text = ((int)t.OrderStatus == 1 ? "تم التنفيذ" : "تحت التنفيذ");
            if (t.OrderStatus == 1)
                tableLayoutPanel1.BackColor = Color.Green;

        }
        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
