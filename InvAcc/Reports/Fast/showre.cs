using InvAcc.Forms;
using InvAcc.GeneralM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InvAcc.Reports
{
    public partial class showre : Form
    {
        public showre()
        {
            InitializeComponent();//FSANCX.Text = this.Text;
            StartPosition = FormStartPosition.CenterScreen;
        }
      
        private void showre_Load(object sender, EventArgs e)
        {
            rpt.GetDataSource("item").Enabled = true;

           

           
            rpt.SetParameterValue("MaxLines", 10);
            try
            {
                try
                {
                    (rpt.FindObject("Section3") as FastReport.DataBand).DataSource = rpt.GetDataSource("item");
                }catch
                {
                    
                    
                    foreach (var item in rpt.Report.AllObjects)
                    {
                        if (item.GetType() == typeof(FastReport.DataBand))
                        {
                            FastReport.DataBand x = (item as FastReport.DataBand);
                            x.DataSource = rpt.GetDataSource("item");
                            x.DataSource.Enabled = true;

                        }



                    }
                }
            }
            catch (Exception ex)
            {
                if (VarGeneral.UserID == 1)
                {
                    button3_Click(null, null);
                }
                MessageBox.Show(ex.Message);


            }


        }
        public FastReport.Report rpt;
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
              }
  public       FrmReportsViewer fr;

        private void button2_Click(object sender, EventArgs e)
        {
         
            
        }
    }
}
