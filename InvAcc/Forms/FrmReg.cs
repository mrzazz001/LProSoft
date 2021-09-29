using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using InputKey;
using InvAcc.GeneralM;
using Microsoft.Win32;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Management;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmReg : Form

    {
        private void bubbleButton_Cancel_Click(object sender, EventArgs e)
        {

            RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\MrdSoft\\Register", writable: true);
            long regval = long.Parse(VarGeneral.TString.TEmpty(string.Concat(hKey.GetValue("SSSActivationNo"))));
            try
            {
                string SerHrd = txtDiskSerNo.Text;
                if (txtRunNo.Text == long.Parse(RetScrt1(SerHrd)).ToString())
                {
                    goto IL_038e;
                }
            }
            catch
            {
            }
            try
            {
                string dt = hKey.GetValue("DT").ToString();
                try
                {
                    if (!Program.sIsNumeric(dt.Substring(2, 1)))
                    {
                        dt = dt.Substring(6, 4) + "/" + dt.Substring(3, 2) + "/" + dt.Substring(0, 2);
                    }
                    if (dt.Substring(8, 2) == "31")
                    {
                        dt = ((!(dt.Substring(5, 2) != "12")) ? (int.Parse(dt.Substring(0, 4)) + 1 + "/01/01") : (dt.Substring(0, 4) + "/" + $"{int.Parse(dt.Substring(5, 2)) + 1:00}" + "/01"));
                    }
                    if (int.Parse(Convert.ToDateTime(DateTime.Now).ToString("yyyy/MM/dd").Substring(0, 4)) < 1900)
                    {
                        if (n.IsGreg(dt))
                        {
                            dt = n.GregToHijri(dt, "yyyy/MM/dd");
                        }
                    }
                    else if (n.IsHijri(dt))
                    {
                        dt = n.HijriToGreg(dt, "yyyy/MM/dd");
                    }
                }
                catch
                {
                    dt = hKey.GetValue("DT").ToString();
                }
                if (dt != "DONE" && Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd")) > Convert.ToDateTime(Convert.ToDateTime(dt).AddMonths(1).ToString("yyyy/MM/dd")))
                {
                    MessageBox.Show("نأسف .. لقد انتهت الفترة التجريبية للمنتج .. يرجى التواصل مع الادارة لشراء النسخة \n " + VarGeneral.vCompany + "\n" + VarGeneral.vAboutAddress2 + "\n" + VarGeneral.vAboutWeb + "\n" + VarGeneral.vAboutEmail, VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Application.Exit();
                    return;
                }
            }
            catch
            {
            }
            if (regval <= 60)
            {
                hKey.SetValue("SSSActivationNo", regval + 1);
                Close();
                return;
            }
            MessageBox.Show("نأسف .. لقد انتهت الفترة التجريبية للمنتج .. يرجى التواصل مع الادارة لشراء النسخة \n " + VarGeneral.vCompany + "\n" + VarGeneral.vAboutAddress2 + "\n" + VarGeneral.vAboutWeb + "\n" + VarGeneral.vAboutEmail, VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            Application.Exit();
            return;
            IL_038e:
            Close();
       }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
          
                Close();
           
        }
        private void bubbleButton_Print_Click(object sender, EventArgs e)
        {
            try
            {

                string[] txtReg = new string[25];
                if (!checkBox1.Checked)
                {
                    MessageBox.Show("يجب الموافقة على جميع شروط المنتج", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    checkBox1.Focus();
                    return;
                }
                if (txtCsutName.Text == "")
                {
                    MessageBox.Show("هناك خطأ.. يجب عليك كتابة اسم المنشأة قبل الطباعة", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    //tabItem1.AttachedControl.Select();
                    txtCsutName.Focus();
                    return;
                }
                if (txtCsutName.Text == "")
                {
                    MessageBox.Show("هناك خطأ., يجب عليك تحديد اسم العميل المسؤول قبل الطباعة", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    //tabItem1.AttachedControl.Select();
                    txtCsutName.Focus();
                    return;
                }
                if (txtMobile.Text == "")
                {
                    MessageBox.Show("هناك خطأ., يجب عليك كتابة رقم موبايل العميل قبل الطباعة", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    //tabItem1.AttachedControl.Select();
                    txtMobile.Focus();
                    return;
                }
                if (txtDiskSerNo.Text == "")
                {
                    MessageBox.Show("خانة رقم المنتج فارغة .. يرجى مراجعة الادارة بالمشكلة", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    //tabItem3.AttachedControl.Select();
                    txtDiskSerNo.Focus();
                    return;
                }
                if (txtRunNo.Text == "")
                {
                    MessageBox.Show("يرجى التأكد من ان لا يكون خانة كود الفعيل فارغا\u064c", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    //tabItem3.AttachedControl.Select();
                    txtRunNo.Focus();
                    return;
                }
                if (txtSerNo.Text == "")
                {
                    MessageBox.Show("هناك خطأ ... يجب عليك كتابة كود التسلسل قبل الطباعة", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    //tabItem3.AttachedControl.Select();
                    txtSerNo.Focus();
                    return;
                }
                RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\MrdSoft\\Register", writable: true);
                long regval = long.Parse(hKey.GetValue("SSSActivationNo").ToString());
                string SerHrd = txtDiskSerNo.Text;
                if (txtRunNo.Text != long.Parse(RetScrt1(SerHrd)).ToString())
                {
                    MessageBox.Show("هناك خطأ ...يجب عليك تفعيل المنتج ثم طباعة استمارة التسجيل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtRunNo.Focus();
                    return;
                }
                FrmReportsViewer frm = new FrmReportsViewer();
                frm.Tag = 0;
                frm.Repvalue = "RegRep";
                try
                {
                    VarGeneral.AutoAlarmitms = new List<string>();
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms[1] = txtCsutName.Text;
                    VarGeneral.AutoAlarmitms[2] = "";
                    VarGeneral.AutoAlarmitms[3] = txtPrsName.Text;
                    VarGeneral.AutoAlarmitms[4] = textBox_ActivatedCompany.Text;
                    VarGeneral.AutoAlarmitms[5] = txtTel.Text;
                    VarGeneral.AutoAlarmitms[6] = txtFax.Text;
                    VarGeneral.AutoAlarmitms[7] = txtMobile.Text;
                    VarGeneral.AutoAlarmitms[8] = textBox_Email.Text;
                    VarGeneral.AutoAlarmitms[9] = textBox_City.Text;
                    VarGeneral.AutoAlarmitms[11] = txtPOBOX.Text;
                    VarGeneral.AutoAlarmitms[12] = txtPost.Text;
                    VarGeneral.AutoAlarmitms[13] = "";
                    VarGeneral.AutoAlarmitms[14] = "";
                    VarGeneral.AutoAlarmitms[15] = "";
                    VarGeneral.AutoAlarmitms[16] = "";
                    VarGeneral.AutoAlarmitms[17] = VarGeneral.ProdectNam;
                    VarGeneral.AutoAlarmitms[18] = VarGeneral.ProdectNo;
                    VarGeneral.AutoAlarmitms[19] = txtDiskSerNo.Text;
                    VarGeneral.AutoAlarmitms[20] = txtSerNo.Text;
                    VarGeneral.AutoAlarmitms[21] = txtRunNo.Text;
                    VarGeneral.AutoAlarmitms[22] = txtWindowsName.Text;
                    VarGeneral.AutoAlarmitms[23] = txtProcessorId.Text;
                    VarGeneral.AutoAlarmitms[24] = txtDiskInfo.Text;
                    VarGeneral.AutoAlarmitms[25] = txtBIOSId.Text;
                }
                catch
                {
                }
                this.TopMost = false;
                frm.TopMost = true;
                frm.ShowDialog();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("bubbleButton_Print_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }


        }

        void avs(int arln)

{ 
 label9.Text=   (arln == 0 ? "  مفتاح التشغيل  " : "  Power key") ; label8.Text=   (arln == 0 ? "  الرقم التسلسلي  " : "  Serial Number") ; label7.Text=   (arln == 0 ? "  رقم المنتج  " : "  Product number") ; label6.Text=   (arln == 0 ? "  رقم القرص الصلب  " : "  hard disk number") ; label5.Text=   (arln == 0 ? "  رقم المعالج  " : "  Processor number") ; label4.Text=   (arln == 0 ? "  رقم اللوحة الأم  " : "  motherboard number") ; label3.Text=   (arln == 0 ? "  نظام التشغيل  " : "  OS") ; label2.Text=   (arln == 0 ? "  أسم المنتج  " : "  product name") ; bubbleBar_Cancel.Text=   (arln == 0 ? "  bubbleBar5  " : "  bubbleBar5") ; bubbleBarTab4.Text=   (arln == 0 ? "  bubbleBarTab1  " : "  bubbleBarTab1") ; bubbleBar_Ok.Text=   (arln == 0 ? "  bubbleBar2  " : "  bubbleBar2") ; bubbleBarTab1.Text=   (arln == 0 ? "  bubbleBarTab1  " : "  bubbleBarTab1") ; bubbleBar_Leave.Text=   (arln == 0 ? "  bubbleBar5  " : "  bubbleBar5") ; bubbleBarTab2.Text=   (arln == 0 ? "  bubbleBarTab1  " : "  bubbleBarTab1") ; 
            label21.Text=   (arln == 0 ? "  تفعيل النسخة  " : "  Activate version") ; label1.Text=   (arln == 0 ? "  Activation No  " : "  Activation No") ; label12.Text=   (arln == 0 ? "  Hard Desc  " : "  Hard Desc") ; label13.Text=   (arln == 0 ? "  Process  " : "  Process") ; label14.Text=   (arln == 0 ? "  Bord  " : "  Bord") ; label15.Text=   (arln == 0 ? "  Win  " : "  Win") ; label10.Text=   (arln == 0 ? "  Serial  " : "  Serial") ; label11.Text=   (arln == 0 ? "  Prouduct Code   " : "  Product Code") ; label16.Text=   (arln == 0 ? "  إسم المنتج :  " : "  product name :") ; checkBox1.Text=   (arln == 0 ? "  نعم , أوافق على جميع شروط المنتج  " : "  Yes, I agree to all product terms") ; label20.Text=   (arln == 0 ? "  بيانات الشراء  " : "  Purchase data") ; label28.Text=   (arln == 0 ? "  تاريخ الفاتورة :  " : "  Invoice date:") ; label31.Text=   (arln == 0 ? "  رقم الفاتورة :  " : "  invoice number :") ; label32.Text=   (arln == 0 ? "  فاكس :  " : "  Fax:") ; label33.Text=   (arln == 0 ? "  تلفـــون :  " : "  Telephone:") ; label34.Text=   (arln == 0 ? "  المدينة :  " : "  City :") ; label35.Text=   (arln == 0 ? "  محل الشراء :  " : "  Where to buy:") ; label40.Text=   (arln == 0 ? "  بريد إلكتروني :  " : "  e-mail :") ; label41.Text=   (arln == 0 ? "  اسم المسؤول :  " : "  Name of the manager :") ; label43.Text=   (arln == 0 ? "  البلد :  " : "  Country :") ; label44.Text=   (arln == 0 ? "  الرمز البريدي :  " : "  Postal code :") ; label45.Text=   (arln == 0 ? "  صندوق البريدي :  " : "  postal box:") ; label46.Text=   (arln == 0 ? "  موبايــــل :  " : "  Mobile:") ; label47.Text=   (arln == 0 ? "  فاكس :  " : "  Fax:") ; label48.Text=   (arln == 0 ? "  تلفـــون :  " : "  Telephone:") ; label49.Text=   (arln == 0 ? "  نشاط المنشأة :  " : "  Enterprise activity:") ; label50.Text=   (arln == 0 ? "  إسم المنشأة :  " : "  Facility Name :") ; label29.Text=   (arln == 0 ? "  بيانات العميل  " : "  Customer data") ; tabItem1.Text=   (arln == 0 ? "  بيانات عامــــة  " : "  general data") ; c1Button1.Text=   (arln == 0 ? "  اغلاق  " : "  Close") ; Text = "تفعيل النسخة";this.Text=   (arln == 0 ? "  تفعيل النسخة  " : "  Activate version") ;}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
            TopMost = true;
        }
   
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
       // private IContainer components = null;
        private void netResize1_AfterControlResize(object sender, Softgroup.NetResize.AfterControlResizeEventArgs e)
        {
            if (e.Control.GetType() == typeof(Label))
            {
                Label c = (e.Control as Label); if ((c.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))))) && (c.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))))) && (c.BackColor != System.Drawing.Color.SteelBlue))
                    c.BackColor = Color.Transparent; 
                //  e.Control.Font= new System.Drawing.Font("Tahoma",(float) (c-0.5));
            }
        }
        private void FrmInvSale_Shown(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Minimized;
            //this.WindowState = FormWindowState.Maximized;
        }
        private void FrmInvSale_SizeChanged(object sender, EventArgs e)
        {
            netResize1.Refresh();
        }
        public Softgroup.NetResize.NetResize netResize1;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
#pragma warning disable CS0169 // The field 'FrmReg.panel1' is never used
        private Panel panel1;
#pragma warning restore CS0169 // The field 'FrmReg.panel1' is never used
        protected BubbleBar bubbleBar_Cancel;
        protected BubbleBarTab bubbleBarTab4;
     
        protected BubbleBarTab bubbleBarTab1;
        protected BubbleButton bubbleButton_Ok;
        protected BubbleBar bubbleBar_Leave;
        protected BubbleBarTab bubbleBarTab2;
      //  protected BubbleButton bubbleButton_Print;
#pragma warning disable CS0169 // The field 'FrmReg.tabControl1' is never used
        private DevComponents.DotNetBar.TabControl tabControl1;
#pragma warning restore CS0169 // The field 'FrmReg.tabControl1' is never used
#pragma warning disable CS0169 // The field 'FrmReg.tabControlPanel1' is never used
      private TabControlPanel tabControlPanel1;
#pragma warning restore CS0169 // The field 'FrmReg.tabControlPanel1' is never used
      //  private Label label29;
#pragma warning disable CS0649 // Field 'FrmReg.tabItem1' is never assigned to, and will always have its default value null
        private TabItem tabItem1;
#pragma warning restore CS0649 // Field 'FrmReg.tabItem1' is never assigned to, and will always have its default value null
#pragma warning disable CS0169 // The field 'FrmReg.tabControlPanel3' is never used
        private TabControlPanel tabControlPanel3;
#pragma warning restore CS0169 // The field 'FrmReg.tabControlPanel3' is never used
#pragma warning disable CS0169 // The field 'FrmReg.panel3' is never used
        private Panel panel3;
#pragma warning restore CS0169 // The field 'FrmReg.panel3' is never used
#pragma warning disable CS0649 // Field 'FrmReg.label28' is never assigned to, and will always have its default value null
        private Label label28;
#pragma warning restore CS0649 // Field 'FrmReg.label28' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'FrmReg.txt_PaidInvDate' is never assigned to, and will always have its default value null
        private TextBox txt_PaidInvDate;
#pragma warning restore CS0649 // Field 'FrmReg.txt_PaidInvDate' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'FrmReg.label31' is never assigned to, and will always have its default value null
        private Label label31;
#pragma warning restore CS0649 // Field 'FrmReg.label31' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'FrmReg.txt_PaidInv' is never assigned to, and will always have its default value null
        private TextBox txt_PaidInv;
#pragma warning restore CS0649 // Field 'FrmReg.txt_PaidInv' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'FrmReg.label32' is never assigned to, and will always have its default value null
        private Label label32;
#pragma warning restore CS0649 // Field 'FrmReg.label32' is never assigned to, and will always have its default value null
#pragma warning disable CS0169 // The field 'FrmReg.txt_PaidFax' is never used
        private TextBox txt_PaidFax;
#pragma warning restore CS0169 // The field 'FrmReg.txt_PaidFax' is never used
#pragma warning disable CS0649 // Field 'FrmReg.label33' is never assigned to, and will always have its default value null
        private Label label33;
#pragma warning restore CS0649 // Field 'FrmReg.label33' is never assigned to, and will always have its default value null
#pragma warning disable CS0169 // The field 'FrmReg.txt_PaidTel' is never used
        private TextBox txt_PaidTel;
#pragma warning restore CS0169 // The field 'FrmReg.txt_PaidTel' is never used
#pragma warning disable CS0649 // Field 'FrmReg.label34' is never assigned to, and will always have its default value null
        private Label label34;
#pragma warning restore CS0649 // Field 'FrmReg.label34' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'FrmReg.txt_PaidCity' is never assigned to, and will always have its default value null
        private TextBox txt_PaidCity;
#pragma warning restore CS0649 // Field 'FrmReg.txt_PaidCity' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'FrmReg.label35' is never assigned to, and will always have its default value null
        private Label label35;
#pragma warning restore CS0649 // Field 'FrmReg.label35' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'FrmReg.txt_PaidPlace' is never assigned to, and will always have its default value null
        private TextBox txt_PaidPlace;
#pragma warning restore CS0649 // Field 'FrmReg.txt_PaidPlace' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'FrmReg.label20' is never assigned to, and will always have its default value null
        private Label label20;
#pragma warning restore CS0649 // Field 'FrmReg.label20' is never assigned to, and will always have its default value null
      //  private Label label21;
#pragma warning disable CS0649 // Field 'FrmReg.Picture_SSS' is never assigned to, and will always have its default value null
        private PictureBox Picture_SSS;
#pragma warning restore CS0649 // Field 'FrmReg.Picture_SSS' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'FrmReg.c1Button1' is never assigned to, and will always have its default value null
        private C1.Win.C1Input.C1Button c1Button1;
#pragma warning restore CS0649 // Field 'FrmReg.c1Button1' is never assigned to, and will always have its default value null
        private void bubbleButton_Ok_Click(object sender, EventArgs e)
        {

            try
            {

                if (!checkBox1.Checked)
                {
                    MessageBox.Show("يجب الموافقة على جميع شروط المنتج", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    checkBox1.Focus();
                }
                else if (txtDiskSerNo.Text == "")
                {
                    MessageBox.Show("خانة رقم المنتج فارغة .. يرجى مراجعة الادارة بالمشكلة", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    //tabItem3.AttachedControl.Select();
                    txtDiskSerNo.Focus();
                }
                else if (txtRunNo.Text == "")
                {
                    MessageBox.Show("يرجى التأكد من ان لا يكون خانة كود التفعيل فارغا\u064c", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    ////tabItem3.AttachedControl.Select();
                    txtRunNo.Focus();
                }
                else if (txtSerNo.Text == "")
                {
                    MessageBox.Show("يرجى التأكد من ان لا يكون خانة كود التسلسل فارغا\u064c", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    //tabItem3.AttachedControl.Select();
                    txtSerNo.Focus();
                }
                else if (txtSerNo.Text.Length != 10)
                {
                    MessageBox.Show("يرجى التأكد من ان لا يكون خانة كود التسلسل فارغا\u064c", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    //tabItem3.AttachedControl.Select();
                    txtSerNo.Focus();
                }
                else if (VarGeneral.SSSLev == "G")
                {
                    if (VarGeneral.SSSTyp == 0)
                    {
                        if (!(txtSerNo.Text.Substring(3, 3) != "00W"))
                        {
                            goto IL_081e;
                        }
                        MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        //tabItem3.AttachedControl.Select();
                        txtSerNo.Focus();
                    }
                    else if (VarGeneral.SSSTyp == 1)
                    {
                        if (!(txtSerNo.Text.Substring(3, 3) != "01I"))
                        {
                            goto IL_081e;
                        }
                        MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        //tabItem3.AttachedControl.Select();
                        txtSerNo.Focus();
                    }
                    else
                    {
                        if (!(txtSerNo.Text.Substring(3, 3) != "02G"))
                        {
                            goto IL_081e;
                        }
                        MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        //tabItem3.AttachedControl.Select();
                        txtSerNo.Focus();
                    }
                }
                else if (VarGeneral.SSSLev == "S")
                {
                    if (!(txtSerNo.Text.Substring(3, 3) != "02S"))
                    {
                        goto IL_081e;
                    }
                    MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    //tabItem3.AttachedControl.Select();
                    txtSerNo.Focus();
                }
                else if (VarGeneral.SSSLev == "B")
                {
                    if (!(txtSerNo.Text.Substring(3, 3) != "02B"))
                    {
                        goto IL_081e;
                    }
                    MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    //tabItem3.AttachedControl.Select();
                    txtSerNo.Focus();
                }
                else if (VarGeneral.SSSLev == "F")
                {
                    if (!(txtSerNo.Text.Substring(3, 3) != "02F"))
                    {
                        goto IL_081e;
                    }
                    MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    //tabItem3.AttachedControl.Select();
                    txtSerNo.Focus();
                }
                else if (VarGeneral.SSSLev == "C")
                {
                    if (!(txtSerNo.Text.Substring(3, 3) != "02C"))
                    {
                        goto IL_081e;
                    }
                    MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    //tabItem3.AttachedControl.Select();
                    txtSerNo.Focus();
                }
                else if (VarGeneral.SSSLev == "D")
                {
                    if (!(txtSerNo.Text.Substring(3, 3) != "02D"))
                    {
                        goto IL_081e;
                    }
                    MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    //tabItem3.AttachedControl.Select();
                    txtSerNo.Focus();
                }
                else if (VarGeneral.SSSLev == "E")
                {
                    if (!(txtSerNo.Text.Substring(3, 3) != "01E"))
                    {
                        goto IL_081e;
                    }
                    MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    //tabItem3.AttachedControl.Select();
                    txtSerNo.Focus();
                }
                else if (VarGeneral.SSSLev == "R")
                {
                    if (!(txtSerNo.Text.Substring(3, 3) != "02R"))
                    {
                        goto IL_081e;
                    }
                    MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    //tabItem3.AttachedControl.Select();
                    txtSerNo.Focus();
                }
                else if (VarGeneral.SSSLev == "H")
                {
                    if (!(txtSerNo.Text.Substring(3, 3) != "02H"))
                    {
                        goto IL_081e;
                    }
                    MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    //tabItem3.AttachedControl.Select();
                    txtSerNo.Focus();
                }
                else if (VarGeneral.SSSLev == "X")
                {
                    if (!(txtSerNo.Text.Substring(3, 3) != "01X"))
                    {
                        goto IL_081e;
                    }
                    MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    //tabItem3.AttachedControl.Select();
                    txtSerNo.Focus();
                }
                else if (VarGeneral.SSSLev == "K")
                {
                    if (!(txtSerNo.Text.Substring(3, 3) != "00K"))
                    {
                        goto IL_081e;
                    }
                    MessageBox.Show("لقد تم تفعيل أحد برامجنا على جهازك هذا ومن ثم قمت بتغيير النسخة دون الرجوع الى الإدارة.. لترقية نظامك يرجى التحدث مع الإدارة", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Environment.Exit(0);
                }
                else
                {
                    if (!(VarGeneral.SSSLev == "Z") || !(txtSerNo.Text.Substring(3, 3) != "01Z"))
                    {
                        goto IL_081e;
                    }
                    MessageBox.Show("لقد تم تفعيل أحد برامجنا على جهازك هذا ومن ثم قمت بتغيير النسخة دون الرجوع الى الإدارة.. لترقية نظامك يرجى التحدث مع الإدارة", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Environment.Exit(0);
                }
                goto end_IL_0001;
                IL_081e:

             

                RegistryKey hKeyNew = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", writable: true);
                RegistryKey hKeyElc = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
                RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\MrdSoft\\Register", writable: true);
                long regval = long.Parse(hKey.GetValue("SSSActivationNo").ToString());
                string SerHrd = txtDiskSerNo.Text;
                if (txtRunNo.Text == long.Parse(RetScrt1(SerHrd)).ToString())
                {
                    hKey.SetValue("SSSActivationNo", long.Parse(txtRunNo.Text));
                    hKey.SetValue("DT", "DONE");
                    hKey.SetValue("vSr", txtSerNo.Text.Trim().ToUpper());
                    try
                    {
                        if (VarGeneral.vDemo)
                        {
                            hKeyElc.SetValue("vMixWaiters", "0");
                            hKeyElc.SetValue("vMixWaiters_Electa", "0");
                            hKeyNew.SetValue("vMixWaiters_New", "0");
                        }
                    }
                    catch
                    {
                    }
                    FrmBackupElectDate fa = new FrmBackupElectDate(0);
                    TopMost = false;
                    fa.TopMost = true;
                    fa.ShowDialog();
                    TopMost = true;
                    MessageBox.Show("مبروووك .. لقد تم تفعيل نسختك الخاصة بنجاح .. \n لا تنسى .. طباعة استمارة التسجيل قبل إغلاق النافذة", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    VarGeneral.vDemo = false;
                    string arguments = string.Empty;
                    string[] args = Environment.GetCommandLineArgs();
                    for (int i = 1; i < args.Length; i++)
                    {
                        arguments = arguments + args[i] + " ";
                    }
                    Application.ExitThread();
                    Process.Start(Application.ExecutablePath, arguments);
                }
                else
                {
                    MessageBox.Show("هناك خطأ ... كود التفعيل الذي ادخلته غير صحيح .. حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtRunNo.Focus();
                }
                end_IL_0001:;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("bubbleButton_Ok_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }


        }

        public FrmReg()
        {
            InitializeComponent();this.Load += langloads;
            try
            {
                txtProName.Text = Application.ProductName + "  " + Application.ProductVersion;
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS");
                try
                {
                    ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = searcher.Get().GetEnumerator();
                    if (managementObjectEnumerator.MoveNext())
                    {
                        ManagementObject wmi_HD = (ManagementObject)managementObjectEnumerator.Current;
                        if (string.Concat(wmi_HD["SerialNumber"]).Trim() != "")
                        {
                            txtBIOSId.Text = wmi_HD["SerialNumber"].ToString();
                        }
                        else if (wmi_HD["Version"] == null)
                        {
                            txtBIOSId.Text = "None";
                        }
                        else
                        {
                            txtBIOSId.Text = wmi_HD["Version"].ToString().Trim();
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
                    ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = searcher.Get().GetEnumerator();
                    if (managementObjectEnumerator.MoveNext())
                    {
                        ManagementObject wmi_HD = (ManagementObject)managementObjectEnumerator.Current;
                        txtProcessorId.Text = wmi_HD["ProcessorId"].ToString();
                    }
                }
                catch
                {
                }
                try
                {
                    searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
                    ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = searcher.Get().GetEnumerator();
                    if (managementObjectEnumerator.MoveNext())
                    {
                        ManagementObject wmi_HD = (ManagementObject)managementObjectEnumerator.Current;
                        txtWindowsName.Text = wmi_HD["Caption"].ToString();
                    }
                }
                catch
                {
                }
                try
                {
                    searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
                    ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = searcher.Get().GetEnumerator();
                    if (managementObjectEnumerator.MoveNext())
                    {
                        ManagementObject wmi_HD = (ManagementObject)managementObjectEnumerator.Current;
                        if (wmi_HD["Caption"] != null)
                        {
                            txtDiskInfo.Text = wmi_HD["Caption"].ToString().Trim();
                        }
                        else if (wmi_HD["Model"] == null)
                        {
                            txtDiskInfo.Text = "None";
                        }
                        else
                        {
                            txtDiskInfo.Text = wmi_HD["Model"].ToString().Trim();
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    searcher = new ManagementObjectSearcher("SELECT * FROM Win32_LogicalDisk");
                    foreach (ManagementObject wmi_HD in searcher.Get())
                    {
                        if (string.Concat(wmi_HD["Caption"]) == "C:")
                        {
                            txtDiskSerNo.Text = Math.Abs(Convert.ToInt32(wmi_HD["VolumeSerialNumber"].ToString().Trim(), 16)).ToString();
                            break;
                        }
                    }
                }
                catch
                {
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("LoadReg:", error, enable: true);
                MessageBox.Show(error.Message);
            }
          
        }
#pragma warning disable CS0414 // The field 'FrmReg.fsA' is assigned but its value is never used
        int fsA = 0;
#pragma warning restore CS0414 // The field 'FrmReg.fsA' is assigned but its value is never used
        public void disableactivation()
        {
            fsA = 1;
 
            txtSerNo.ReadOnly = true;
            txtRunNo.ReadOnly = true;
            bubbleBar_Ok.Enabled = false;
        }
        public void copyreg(string run, string ser)
        {
            RegistryKey hKeyNew = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", writable: true);
            RegistryKey hKeyElc = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
            RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\MrdSoft\\Register", writable: true);
            long regval = long.Parse(hKey.GetValue("SSSActivationNo").ToString());
            string SerHrd = txtDiskSerNo.Text;
            if (run == long.Parse(RetScrt1(SerHrd)).ToString())
            {
                hKey.SetValue("SSSActivationNo", long.Parse(run));
                hKey.SetValue("DT", "DONE");
                hKey.SetValue("vSr", ser.Trim().ToUpper());
                try
                {
                    if (VarGeneral.vDemo)
                    {
                        hKeyElc.SetValue("vMixWaiters", "0");
                        hKeyElc.SetValue("vMixWaiters_Electa", "0");
                        hKeyNew.SetValue("vMixWaiters_New", "0");
                    }
                }
                catch
                {
                }
                this.TopMost = false;
                FrmBackupElectDate fa = new FrmBackupElectDate(0);
                fa.TopMost = true;
                fa.ShowDialog(); this.TopMost = true;
            }
            else
            {
                MessageBox.Show("المفتاح غير صالح");
            }
        }
        private void bubbleButton_Ok_Click(object sender, ClickEventArgs e)
        {
            try
            {
                if (Picture_SSS.Visible)
                {
                    MessageBox.Show("لايمكنك تفعيل النسخة .. تحتاج الى ملف التفعيل الخاص بالمنتج لإتمام العملية.. \n يرجى الإتصال بالإدارة للحصول على ملف التفعيل", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (!checkBox1.Checked)
                {
                    MessageBox.Show("يجب الموافقة على جميع شروط المنتج", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    checkBox1.Focus();
                }
                else if (txtDiskSerNo.Text == "")
                {
                    MessageBox.Show("خانة رقم المنتج فارغة .. يرجى مراجعة الادارة بالمشكلة", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                  //Control.Select();
                    txtDiskSerNo.Focus();
                }
                else if (txtRunNo.Text == "")
                {
                    MessageBox.Show("يرجى التأكد من ان لا يكون خانة كود التفعيل فارغا\u064c", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                  //Control.Select();
                    txtRunNo.Focus();
                }
                else if (txtSerNo.Text == "")
                {
                    MessageBox.Show("يرجى التأكد من ان لا يكون خانة كود التسلسل فارغا\u064c", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                  //Control.Select();
                    txtSerNo.Focus();
                }
                else if (txtSerNo.Text.Length != 10)
                {
                    MessageBox.Show("يرجى التأكد من ان لا يكون خانة كود التسلسل فارغا\u064c", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                  //Control.Select();
                    txtSerNo.Focus();
                }
                else if (VarGeneral.SSSLev == "G")
                {
                    if (VarGeneral.SSSTyp == 0)
                    {
                        if (!(txtSerNo.Text.Substring(3, 3) != "00W"))
                        {
                            goto IL_081e;
                        }
                        MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                      //Control.Select();
                        txtSerNo.Focus();
                    }
                    else if (VarGeneral.SSSTyp == 1)
                    {
                        if (!(txtSerNo.Text.Substring(3, 3) != "01I"))
                        {
                            goto IL_081e;
                        }
                        MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                      //Control.Select();
                        txtSerNo.Focus();
                    }
                    else
                    {
                        if (!(txtSerNo.Text.Substring(3, 3) != "02G"))
                        {
                            goto IL_081e;
                        }
                        MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                      //Control.Select();
                        txtSerNo.Focus();
                    }
                }
                else if (VarGeneral.SSSLev == "S")
                {
                    if (!(txtSerNo.Text.Substring(3, 3) != "02S"))
                    {
                        goto IL_081e;
                    }
                    MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                  //Control.Select();
                    txtSerNo.Focus();
                }
                else if (VarGeneral.SSSLev == "B")
                {
                    if (!(txtSerNo.Text.Substring(3, 3) != "02B"))
                    {
                        goto IL_081e;
                    }
                    MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                  //Control.Select();
                    txtSerNo.Focus();
                }
                else if (VarGeneral.SSSLev == "F")
                {
                    if (!(txtSerNo.Text.Substring(3, 3) != "02F"))
                    {
                        goto IL_081e;
                    }
                    MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                  //Control.Select();
                    txtSerNo.Focus();
                }
                else if (VarGeneral.SSSLev == "C")
                {
                    if (!(txtSerNo.Text.Substring(3, 3) != "02C"))
                    {
                        goto IL_081e;
                    }
                    MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                  //Control.Select();
                    txtSerNo.Focus();
                }
                else if (VarGeneral.SSSLev == "D")
                {
                    if (!(txtSerNo.Text.Substring(3, 3) != "02D"))
                    {
                        goto IL_081e;
                    }
                    MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                  //Control.Select();
                    txtSerNo.Focus();
                }
                else if (VarGeneral.SSSLev == "E")
                {
                    if (!(txtSerNo.Text.Substring(3, 3) != "01E"))
                    {
                        goto IL_081e;
                    }
                    MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                  //Control.Select();
                    txtSerNo.Focus();
                }
                else if (VarGeneral.SSSLev == "R")
                {
                    if (!(txtSerNo.Text.Substring(3, 3) != "02R"))
                    {
                        goto IL_081e;
                    }
                    MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                  //Control.Select();
                    txtSerNo.Focus();
                }
                else if (VarGeneral.SSSLev == "H")
                {
                    if (!(txtSerNo.Text.Substring(3, 3) != "02H"))
                    {
                        goto IL_081e;
                    }
                    MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                  //Control.Select();
                    txtSerNo.Focus();
                }
                else if (VarGeneral.SSSLev == "X")
                {
                    if (!(txtSerNo.Text.Substring(3, 3) != "01X"))
                    {
                        goto IL_081e;
                    }
                    MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                  //Control.Select();
                    txtSerNo.Focus();
                }
                else if (VarGeneral.SSSLev == "K")
                {
                    if (!(txtSerNo.Text.Substring(3, 3) != "00K"))
                    {
                        goto IL_081e;
                    }
                    MessageBox.Show("لقد تم تفعيل أحد برامجنا على جهازك هذا ومن ثم قمت بتغيير النسخة دون الرجوع الى الإدارة.. لترقية نظامك يرجى التحدث مع الإدارة", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Environment.Exit(0);
                }
                else
                {
                    if (!(VarGeneral.SSSLev == "Z") || !(txtSerNo.Text.Substring(3, 3) != "01Z"))
                    {
                        goto IL_081e;
                    }
                    MessageBox.Show("لقد تم تفعيل أحد برامجنا على جهازك هذا ومن ثم قمت بتغيير النسخة دون الرجوع الى الإدارة.. لترقية نظامك يرجى التحدث مع الإدارة", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Environment.Exit(0);
                }
                goto end_IL_0001;
            IL_081e:
                RegistryKey hKeyNew = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", writable: true);
                RegistryKey hKeyElc = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
                RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\MrdSoft\\Register", writable: true);
                long regval = long.Parse(hKey.GetValue("SSSActivationNo").ToString());
                string SerHrd = txtDiskSerNo.Text;
                if (txtRunNo.Text == long.Parse(RetScrt1(SerHrd)).ToString())
                {
                    hKey.SetValue("SSSActivationNo", long.Parse(txtRunNo.Text));
                    hKey.SetValue("DT", "DONE");
                    hKey.SetValue("vSr", txtSerNo.Text.Trim().ToUpper());
                    try
                    {
                        if (VarGeneral.vDemo)
                        {
                            hKeyElc.SetValue("vMixWaiters", "0");
                            hKeyElc.SetValue("vMixWaiters_Electa", "0");
                            hKeyNew.SetValue("vMixWaiters_New", "0");
                        }
                    }
                    catch
                    {
                    }
                    FrmBackupElectDate fa = new FrmBackupElectDate(0);
                    TopMost = false;
                    fa.TopMost = true;
                    fa.ShowDialog();
                   TopMost = true;
                    MessageBox.Show("مبروووك .. لقد تم تفعيل نسختك الخاصة بنجاح .. \n لا تنسى .. طباعة استمارة التسجيل قبل إغلاق النافذة", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    VarGeneral.vDemo = false;
                    string arguments = string.Empty;
                    string[] args = Environment.GetCommandLineArgs();
                    for (int i = 1; i < args.Length; i++)
                    {
                        arguments = arguments + args[i] + " ";
                    }
                    Application.ExitThread();
                    Process.Start(Application.ExecutablePath, arguments);
                }
                else
                {
                    MessageBox.Show("هناك خطأ ... كود التفعيل الذي ادخلته غير صحيح .. حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtRunNo.Focus();
                }
            end_IL_0001:;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("bubbleButton_Ok_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private string RetScrt1(string pNo)
        {
            string RetScrt = "";
            try
            {
                if (pNo == "" || !Program.sIsNumeric(pNo))
                {
                    return RetScrt;
                }
                int ii = 0;
                int jj = 0;
                int lnNo = 0;
                string retNo = "";
                string TretNo = "";
                lnNo = pNo.Length + 1;
                for (ii = 1; ii <= lnNo; ii++)
                {
                    TretNo = "";
                    jj = 0;
                    while (TretNo.Length <= lnNo)
                    {
                        jj++;
                        if (Program.sIsNumeric(pNo.Substring(jj, 1)))
                        {
                            TretNo += (double)(int.Parse(pNo.Substring(jj, 1)) * ii) * 0.1651;
                        }
                    }
                    retNo = ((!(TretNo.Substring(ii, 1) == ".")) ? (retNo + TretNo.Substring(ii, 1)) : (retNo + (ii * 45).ToString().Substring(2)));
                }
                RetScrt = retNo.Substring(0, lnNo - 1).ToString();
                return RetScrt;
            }
            catch
            {
                return RetScrt;
            }
        }
        private void bubbleButton_Cancel_Click(object sender, ClickEventArgs e)
        {
            RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\MrdSoft\\Register", writable: true);
            long regval = long.Parse(VarGeneral.TString.TEmpty(string.Concat(hKey.GetValue("SSSActivationNo"))));
            try
            {
                string SerHrd = txtDiskSerNo.Text;
                if (txtRunNo.Text == long.Parse(RetScrt1(SerHrd)).ToString())
                {
                    goto IL_038e;
                }
            }
            catch
            {
            }
            try
            {
                string dt = hKey.GetValue("DT").ToString();
                try
                {
                    if (!Program.sIsNumeric(dt.Substring(2, 1)))
                    {
                        dt = dt.Substring(6, 4) + "/" + dt.Substring(3, 2) + "/" + dt.Substring(0, 2);
                    }
                    if (dt.Substring(8, 2) == "31")
                    {
                        dt = ((!(dt.Substring(5, 2) != "12")) ? (int.Parse(dt.Substring(0, 4)) + 1 + "/01/01") : (dt.Substring(0, 4) + "/" + $"{int.Parse(dt.Substring(5, 2)) + 1:00}" + "/01"));
                    }
                    if (int.Parse(Convert.ToDateTime(DateTime.Now).ToString("yyyy/MM/dd").Substring(0, 4)) < 1900)
                    {
                        if (n.IsGreg(dt))
                        {
                            dt = n.GregToHijri(dt, "yyyy/MM/dd");
                        }
                    }
                    else if (n.IsHijri(dt))
                    {
                        dt = n.HijriToGreg(dt, "yyyy/MM/dd");
                    }
                }
                catch
                {
                    dt = hKey.GetValue("DT").ToString();
                }
                if (dt != "DONE" && Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd")) > Convert.ToDateTime(Convert.ToDateTime(dt).AddMonths(1).ToString("yyyy/MM/dd")))
                {
                    MessageBox.Show("نأسف .. لقد انتهت الفترة التجريبية للمنتج .. يرجى التواصل مع الادارة لشراء النسخة \n " + VarGeneral.vCompany + "\n" + VarGeneral.vAboutAddress2 + "\n" + VarGeneral.vAboutWeb + "\n" + VarGeneral.vAboutEmail, VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Application.Exit();
                    return;
                }
            }
            catch
            {
            }
            if (regval <= 60)
            {
                hKey.SetValue("SSSActivationNo", regval + 1);
                Close();
                return;
            }
            MessageBox.Show("نأسف .. لقد انتهت الفترة التجريبية للمنتج .. يرجى التواصل مع الادارة لشراء النسخة \n " + VarGeneral.vCompany + "\n" + VarGeneral.vAboutAddress2 + "\n" + VarGeneral.vAboutWeb + "\n" + VarGeneral.vAboutEmail, VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            Application.Exit();
            return;
        IL_038e:
            Close();
        }
        private void bubbleButton_Print_Click(object sender, ClickEventArgs e)
        {
            try
            {
                if (Picture_SSS.Visible)
                {
                    MessageBox.Show("لايمكنك طباعة الإستمارة .. تحتاج الى ملف التفعيل الخاص بالمنتج لإتمام العملية.. \n يرجى الإتصال بالإدارة للحصول على ملف التفعيل", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                string[] txtReg = new string[25];
                if (!checkBox1.Checked)
                {
                    MessageBox.Show("يجب الموافقة على جميع شروط المنتج", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    checkBox1.Focus();
                    return;
                }
                if (txtCsutName.Text == "")
                {
                    MessageBox.Show("هناك خطأ.. يجب عليك كتابة اسم المنشأة قبل الطباعة", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    tabItem1.AttachedControl.Select();
                    txtCsutName.Focus();
                    return;
                }
                if (txtCsutName.Text == "")
                {
                    MessageBox.Show("هناك خطأ., يجب عليك تحديد اسم العميل المسؤول قبل الطباعة", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    tabItem1.AttachedControl.Select();
                    txtCsutName.Focus();
                    return;
                }
                if (txtMobile.Text == "")
                {
                    MessageBox.Show("هناك خطأ., يجب عليك كتابة رقم موبايل العميل قبل الطباعة", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    tabItem1.AttachedControl.Select();
                    txtMobile.Focus();
                    return;
                }
                if (txtDiskSerNo.Text == "")
                {
                    MessageBox.Show("خانة رقم المنتج فارغة .. يرجى مراجعة الادارة بالمشكلة", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                  //Control.Select();
                    txtDiskSerNo.Focus();
                    return;
                }
                if (txtRunNo.Text == "")
                {
                    MessageBox.Show("يرجى التأكد من ان لا يكون خانة كود الفعيل فارغا\u064c", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                  //Control.Select();
                    txtRunNo.Focus();
                    return;
                }
                if (txtSerNo.Text == "")
                {
                    MessageBox.Show("هناك خطأ ... يجب عليك كتابة كود التسلسل قبل الطباعة", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                  //Control.Select();
                    txtSerNo.Focus();
                    return;
                }
                RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\MrdSoft\\Register", writable: true);
                long regval = long.Parse(hKey.GetValue("SSSActivationNo").ToString());
                string SerHrd = txtDiskSerNo.Text;
                if (txtRunNo.Text != long.Parse(RetScrt1(SerHrd)).ToString())
                {
                    MessageBox.Show("هناك خطأ ...يجب عليك تفعيل المنتج ثم طباعة استمارة التسجيل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtRunNo.Focus();
                    return;
                }
                FrmReportsViewer frm = new FrmReportsViewer();
                frm.Tag = 0;
                frm.Repvalue = "RegRep";
                try
                {
                    VarGeneral.AutoAlarmitms = new List<string>();
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms[1] = txtCsutName.Text;
                    VarGeneral.AutoAlarmitms[2] = "";
                    VarGeneral.AutoAlarmitms[3] = txtPrsName.Text;
                    VarGeneral.AutoAlarmitms[4] = textBox_ActivatedCompany.Text;
                    VarGeneral.AutoAlarmitms[5] = txtTel.Text;
                    VarGeneral.AutoAlarmitms[6] = txtFax.Text;
                    VarGeneral.AutoAlarmitms[7] = txtMobile.Text;
                    VarGeneral.AutoAlarmitms[8] = textBox_Email.Text;
                    VarGeneral.AutoAlarmitms[9] = textBox_City.Text;
                    VarGeneral.AutoAlarmitms[11] = txtPOBOX.Text;
                    VarGeneral.AutoAlarmitms[12] = txtPost.Text;
                    VarGeneral.AutoAlarmitms[13] = txt_PaidPlace.Text;
                    VarGeneral.AutoAlarmitms[14] = txt_PaidCity.Text;
                    VarGeneral.AutoAlarmitms[15] = txt_PaidInv.Text;
                    VarGeneral.AutoAlarmitms[16] = txt_PaidInvDate.Text;
                    VarGeneral.AutoAlarmitms[17] = VarGeneral.ProdectNam;
                    VarGeneral.AutoAlarmitms[18] = VarGeneral.ProdectNo;
                    VarGeneral.AutoAlarmitms[19] = txtDiskSerNo.Text;
                    VarGeneral.AutoAlarmitms[20] = txtSerNo.Text;
                    VarGeneral.AutoAlarmitms[21] = txtRunNo.Text;
                    VarGeneral.AutoAlarmitms[22] = txtWindowsName.Text;
                    VarGeneral.AutoAlarmitms[23] = txtProcessorId.Text;
                    VarGeneral.AutoAlarmitms[24] = txtDiskInfo.Text;
                    VarGeneral.AutoAlarmitms[25] = txtBIOSId.Text;
                }
                catch
                {
                }
                this.TopMost = false;
                frm.TopMost = true;
                frm.ShowDialog(); this.TopMost = true;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("bubbleButton_Print_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void txtRunNo_Click(object sender, EventArgs e)
        {
            txtRunNo.SelectAll();
        }
        private void txtDiskSerNo_Click(object sender, EventArgs e)
        {
            txtDiskSerNo.SelectAll();
        }
        private void Frm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                bubbleButton_Cancel_Click(null, null);
            }
        }
        private void FrmReg_Load(object sender, EventArgs e)
        {
            if (VarGeneral.UserID != 1) disableactivation();
            try
            {
                RegistryKey SSS = Registry.CurrentUser.OpenSubKey("Software\\SystemSupportedFile\\Files\\ActivFile", writable: true);
                if (SSS == null)
                {
                    SSS = Registry.CurrentUser.OpenSubKey("Software\\SystemSupportedFile", writable: true);
                    if (SSS != null)
                    {
                        SSS = Registry.CurrentUser.OpenSubKey("Software\\SystemSupportedFile\\Files", writable: true);
                        if (SSS == null)
                        {
                            SSS = Registry.CurrentUser.OpenSubKey("Software\\SystemSupportedFile", writable: true);
                            SSS.CreateSubKey("Files");
                            SSS = Registry.CurrentUser.OpenSubKey("Software\\SystemSupportedFile\\Files", writable: true);
                            SSS.CreateSubKey("ActivFile");
                            SSS = Registry.CurrentUser.OpenSubKey("Software\\SystemSupportedFile\\Files\\ActivFile", writable: true);
                            SSS.SetValue("sFile", "0");
                            SSS.Close();
                        }
                        else
                        {
                            SSS = Registry.CurrentUser.OpenSubKey("Software\\SystemSupportedFile\\Files\\ActivFile", writable: true);
                            if (SSS == null)
                            {
                                SSS = Registry.CurrentUser.OpenSubKey("Software\\SystemSupportedFile\\Files", writable: true);
                                SSS.CreateSubKey("ActivFile");
                                SSS = Registry.CurrentUser.OpenSubKey("Software\\SystemSupportedFile\\Files\\ActivFile", writable: true);
                                SSS.SetValue("sFile", "0");
                                SSS.Close();
                            }
                        }
                    }
                    else
                    {
                        SSS = Registry.CurrentUser.OpenSubKey("Software", writable: true);
                        if (SSS != null)
                        {
                            SSS.CreateSubKey("SystemSupportedFile");
                            SSS = Registry.CurrentUser.OpenSubKey("Software\\SystemSupportedFile", writable: true);
                            SSS.CreateSubKey("Files");
                            SSS = Registry.CurrentUser.OpenSubKey("Software\\SystemSupportedFile\\Files", writable: true);
                            SSS.CreateSubKey("ActivFile");
                            SSS = Registry.CurrentUser.OpenSubKey("Software\\SystemSupportedFile\\Files\\ActivFile", writable: true);
                            SSS.SetValue("sFile", "0");
                            SSS.Close();
                        }
                    }
                }
            }
            catch
            {
            }
            try
            {
                RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
                if (hKey != null)
                {
                    try
                    {
                        object q = hKey.GetValue("vActiv");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vActiv");
                            hKey.SetValue("vActiv", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vActiv");
                        hKey.SetValue("vActiv", "0");
                    }
                    
                }
                else
                {
                   // Picture_SSS.Visible = true;
                }
            }
            catch
            {
              //  Picture_SSS.Visible = true;
            }
            try
            {
                RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\MrdSoft\\Register", writable: true);
                long regval = long.Parse(hKey.GetValue("SSSActivationNo").ToString());
                string SerHrd = txtDiskSerNo.Text;
                txtRunNo.Text = regval.ToString();
                if (txtRunNo.Text == long.Parse(RetScrt1(SerHrd)).ToString())
                {
                    txtSerNo.Text = hKey.GetValue("vSr").ToString();
                    bubbleButton_Cancel.Visible = false;
                    checkBox1.Checked = true;
                }
                else
                {
                    txtSerNo.Text = "";
                    txtRunNo.Text = "";
                    checkBox1.Checked = false;
                }
            }
            catch
            {
                txtSerNo.Text = "";
                txtRunNo.Text = "";
            }
        }
        private void txtSerNo_Click(object sender, EventArgs e)
        {
            txtSerNo.SelectAll();
        }
        private void txtSerNo_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        private void txtRunNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void txtSerNo_TextChanged(object sender, EventArgs e)
        {
        }
        private void groupPanel1_Click(object sender, EventArgs e)
        {
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }
        private void c1Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tabControlPanel1_Click(object sender, EventArgs e)
        {

        }

        private void expandableSplitter1_ExpandedChanged(object sender, ExpandedChangeEventArgs e)
        {

        }

        private void expandablePanel1_ExpandedChanged(object sender, ExpandedChangeEventArgs e)
        {

        }

        private void expandablePanel1_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void txtSerNo_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
