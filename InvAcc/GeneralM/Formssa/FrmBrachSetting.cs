using Microsoft.Win32;
using System;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmBrachSetting : Form
    {
        public FrmBrachSetting()
        {
            InitializeComponent();
        }
        private void c1Label2_Click(object sender, EventArgs e)
        {
        }
        public static void setdropactivation(string no)
        {
            RegistryKey hKeyNeew1 = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", writable: true);
            try
            {
                object q = hKeyNeew1.GetValue("vDropBoxActivation");
                if (string.IsNullOrEmpty(q.ToString()))
                {
                    hKeyNeew1.CreateSubKey("vDropBoxActivation");
                    hKeyNeew1.SetValue("vDropBoxActivation", no);
                }
                else
                {
                    hKeyNeew1.SetValue("vDropBoxActivation", no);
                }
            }
            catch
            {
                hKeyNeew1.CreateSubKey("vDropBoxActivation");
                hKeyNeew1.SetValue("vDropBoxActivation", no);
            }
        }
        public static string getdropnoactivation()
        {
            RegistryKey hKeyNeew1 = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", writable: true);
            string bno = "";
            try
            {
                object q = hKeyNeew1.GetValue("vDropBoxActivation");
                bno = q.ToString();
            }
            catch
            {
                return "NA";
            }
            return bno;
        }
        private void FrmBrachSetting_Load(object sender, EventArgs e)
        {
            string s = getbno();
            if (s == null)
                setbranchno("");
            else
                textBox1.Text = s;
            string ss = getdropnoactivation();
            if (ss == "1")
                checkBox1.Checked = true;
        }
        private void c1Label4_Click(object sender, EventArgs e)
        {
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
                if (!char.IsControl(e.KeyChar)) e.Handled = true;
        }
        static void setbranchno(string no)
        {
            RegistryKey hKeyNeew1 = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", writable: true);
            try
            {
                object q = hKeyNeew1.GetValue("vBranchNo");
                if (string.IsNullOrEmpty(q.ToString()))
                {
                    hKeyNeew1.CreateSubKey("vBranchNo");
                    hKeyNeew1.SetValue("vBranchNo", no);
                }
                else
                {
                    hKeyNeew1.SetValue("vBranchNo", no);
                }
            }
            catch
            {
                hKeyNeew1.CreateSubKey("vBranchNo");
                hKeyNeew1.SetValue("vBranchNo", no);
            }
        }
        static string getbno()
        {
            RegistryKey hKeyNeew1 = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", writable: true);
            string bno = "";
            try
            {
                object q = hKeyNeew1.GetValue("vBranchNo");
                bno = q.ToString();
            }
            catch
            {
                hKeyNeew1.CreateSubKey("vBranchNo");
                hKeyNeew1.SetValue("vBranchNo", -1);
                return null;
            }
            return bno;
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }
        private void ButWithSave_Click(object sender, EventArgs e)
        {

        }
        private void ButWithSave_Clickd(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            setbranchno(textBox1.Text);
            this.Close();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                setdropactivation("1");
            else
                setdropactivation("0");
        }
    }
}
