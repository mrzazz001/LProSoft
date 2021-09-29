using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
namespace InvAcc.DroBoxSync
{
    public partial class Frm_PrinterShow : Form
    {
        int invtype;
        public Frm_PrinterShow(int type)
        {
            InitializeComponent();//this.Load += langloads;invtype =type;
        }
        T_Printer setting = new T_Printer();
        Stock_DataDataContext db = new Stock_DataDataContext();
        char[] tp;
        string stp = "";
        private void Frm_PrinterShow_Load(object sender, EventArgs e)
        {
          
            setting= db.StockPrinterSetting(VarGeneral.UserID,invtype);
          stp = setting.nTyp; 
             tp = stp.ToCharArray();
            if (tp[1] == '1')
                A4.Checked = true;
            else
                casher.Checked = true;
            groupPanel15.Text +=" في  " + setting.InvInfo.InvNamA;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
        public static  string PLSetting;
        private void button1_Click(object sender, EventArgs e)
        {
          
        }
        private void button2_Click(object sender, EventArgs e)
        {
            char m = ' ';
            if (A4.Checked == true)
            {
                m = '1';
            }
            else
             if (casher.Checked == true) m = '0';
            else m = setting.nTyp[1];
            char c1 = '1', c2 = '1';
            string nt = "";
            if (pintes.Checked == true)
            {
                c1 = '0';
                c2 = '0';
                nt += c1;
                nt += '1';
                nt += c2;
            }
            else
            {
                nt += setting.nTyp[0];
                nt += m;
                nt += setting.nTyp[2];
            }
                setting.nTyp =  nt;
            PLSetting = nt;
            db.SubmitChanges(ConflictMode.ContinueOnConflict);
            Close();
        }
        void fill
             ()
        {

            comboBoxEx1.Items.Clear();
            comboBoxEx1.Items.Add(" ");
            PrinterSettings PrintS = new PrinterSettings();
            if (PrinterSettings.InstalledPrinters.Count != 0)
            {
                for (int iiCnt = 0; iiCnt < PrinterSettings.InstalledPrinters.Count; iiCnt++)
                {
                    comboBoxEx1.Items.Add(PrinterSettings.InstalledPrinters[iiCnt]);
                }
                if (!string.IsNullOrEmpty(VarGeneral.PrintNam))
                {
                    comboBoxEx1.Text = VarGeneral.PrintNam;
                }
                else
                {
                    comboBoxEx1.Text = PrintS.DefaultPageSettings.PrinterSettings.PrinterName;
                }
            }

        }
        private void groupPanel15_Click(object sender, EventArgs e)
        {
        }
    }
}
