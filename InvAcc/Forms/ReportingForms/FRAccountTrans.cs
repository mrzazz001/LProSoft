using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using Framework.Date;
using Framework.UI;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using Library.RepShow;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FRAccountTrans : Form
    { void avs(int arln)

{ 
  label10.Text=   (arln == 0 ? "  المستوى :  " : "  the level :") ; groupBox4.Text=   (arln == 0 ? "  حسب التاريخ  " : "  by date") ; label1.Text=   (arln == 0 ? "  مـــــن :  " : "  from:") ; label2.Text=   (arln == 0 ? "  إلـــــى :  " : "  to:") ; groupBox3.Text=   (arln == 0 ? "  الرصيــــد  " : "  balance") ; label3.Text=   (arln == 0 ? "  مـــــن :  " : "  from:") ; label4.Text=   (arln == 0 ? "  أصغر من " : "  Younger than") ; label9.Text=   (arln == 0 ? "  المستخدم :  " : "  the user :") ; label7.Text=   (arln == 0 ? "  المنـــــدوب :  " : "  The delegate:") ; label6.Text=   (arln == 0 ? "  الى حساب :  " : "  to account :") ; label5.Text=   (arln == 0 ? "  من حساب :  " : "  from account :") ; label8.Text=   (arln == 0 ? "  مركز التكلفة :  " : "  cost center:") ;}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
        public class ColumnDictinary
        {
            public string AText = "";
            public string EText = "";
            public bool IfDefault = false;
            public string Format = "";
            public ColumnDictinary(string aText, string eText, bool ifDefault, string format)
            {
                AText = aText;
                EText = eText;
                IfDefault = ifDefault;
                Format = format;
            }
        }
       // private IContainer components = null;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData.ToString().Contains("Control") && !keyData.ToString().ToLower().Contains("delete") && keyData.ToString().Contains("Alt"))
            {
                try
                {
                    VarGeneral.Print_set_Gen_Stat = true;
                    FrmReportsViewer.IsSettingOnly = true;
                    VarGeneral.IsGeneralUsed = true;
                    {
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "AccountTrans";
                        frm.Repvalue = "AccountTrans";
                        //ADDADD
                        frm.Tag = LangArEn;
                        frm.ShowDialog();
                        VarGeneral.IsGeneralUsed = false;
                    }
                    FrmReportsViewer.IsSettingOnly = false;
                }
                catch
                {
                    VarGeneral.Print_set_Gen_Stat = false;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void netResize1_AfterControlResize(object sender, Softgroup.NetResize.AfterControlResizeEventArgs e)
        {
            if (e.Control.GetType() == typeof(Label))
            {
                Label c = (e.Control as Label); if ((c.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))))) && (c.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))))) && (c.BackColor != System.Drawing.Color.SteelBlue))
                    c.BackColor = Color.Transparent; Size cc = c.PreferredSize;
                c.AutoSize = false;
                c.Size = cc;
                //  e.Control.Font= new System.Drawing.Font("Tahoma",(float) (c-0.5));
            }
        }
        private void FRInvoice_VisibleChanged(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;
        }
        private void FrmInvSale_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;
        }
        private void FrmInvSale_SizeChanged(object sender, EventArgs e)
        {
            netResize1.Refresh();
        }
        private Panel PanelSpecialContainer;
        public Softgroup.NetResize.NetResize netResize1;
        private RibbonBar ribbonBar1;
        private C1FlexGrid FlexField;
        private NumericUpDown numUpDownLevel;
        private GroupBox groupBox2;
        private TextBox txtIntoAccName;
        private TextBox txtLegateName;
        private TextBox txtFromAccName;
        private TextBox txtUserName;
        private TextBox txtCostCName;
        private TextBox txtFromAccNo;
        private TextBox txtIntoAccNo;
        private TextBox txtLegateNo;
        private TextBox txtUserNo;
        private TextBox txtCostCNo;
        private ButtonX button_SrchUsrNo;
        private ButtonX button_SrchCostNo;
        private ButtonX button_SrchLegNo;
        private ButtonX button_SrchAccTo;
        private ButtonX button_SrchAccFrom;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label8;
        private GroupBox groupBox4;
        private MaskedTextBox txtMToDate;
        private MaskedTextBox txtMFromDate;
        private Label label2;
        private GroupBox groupBox3;
        private Label label1;
        private Label label9;
        private Label label10;
        private PictureBox pictureBox1;
        private DoubleInput txtMBalanceB;
        private DoubleInput txtMBalanceS;
        private Label label3;
        private Label label4;
        private SwitchButton switchButton_OpenValue;
        private int LangArEn = 0;
        private T_User _User = new T_User();
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private Stock_DataDataContext dbInstance;
        private C1.Win.C1Input.C1Button ButOk;
        private C1.Win.C1Input.C1Button ButExit;
        private Rate_DataDataContext dbInstanceRate;
        private Stock_DataDataContext db
        {
            get
            {
                if (dbInstance == null)
                {
                    dbInstance = new Stock_DataDataContext(VarGeneral.BranchCS);
                }
                return dbInstance;
            }
        }
        private Rate_DataDataContext dbc
        {
            get
            {
                if (dbInstanceRate == null)
                {
                    dbInstanceRate = new Rate_DataDataContext(VarGeneral.BranchRt);
                }
                return dbInstanceRate;
            }
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
            if (e.KeyCode == Keys.F5 && ButOk.Enabled && ButOk.Visible)
            {
                ButOk_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        public FRAccountTrans()
        {
            InitializeComponent();this.Load += langloads;
            _User = dbc.StockUser(VarGeneral.UserNumber);
            HijriGregDates dateFormatter = new HijriGregDates();
            if (VarGeneral.Settings_Sys.Calendr.Value == 0)
            {
                txtMFromDate.Text = VarGeneral.Gdate.Substring(0, 4) + "/01/01";
                txtMToDate.Text = dateFormatter.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
            }
            else
            {
                txtMFromDate.Text = VarGeneral.Hdate.Substring(0, 4) + "/01/01";
                txtMToDate.Text = dateFormatter.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
            }
            if (VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F" || VarGeneral.SSSLev == "S" || VarGeneral.SSSLev == "C")
            {
                label8.Visible = false;
                txtCostCNo.Visible = false;
                button_SrchCostNo.Visible = false;
                txtCostCName.Visible = false;
            }
            else
            {
                label8.Visible = true;
                txtCostCNo.Visible = true;
                button_SrchCostNo.Visible = true;
                txtCostCName.Visible = true;
            }
            try
            {
                if (VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F")
                {
                    RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
                    try
                    {
                        object q = hKey.GetValue("vCoCe");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vCoCe");
                            hKey.SetValue("vCoCe", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vCoCe");
                        hKey.SetValue("vCoCe", "0");
                    }
                    long regval = long.Parse(hKey.GetValue("vCoCe").ToString());
                    if (regval == 1)
                    {
                        label8.Visible = true;
                        txtCostCNo.Visible = true;
                        button_SrchCostNo.Visible = true;
                        txtCostCName.Visible = true;
                    }
                    else
                    {
                        label8.Visible = false;
                        txtCostCNo.Visible = false;
                        button_SrchCostNo.Visible = false;
                        txtCostCName.Visible = false;
                    }
                }
            }
            catch
            {
            }
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
            {
                txtMBalanceB.DisplayFormat = VarGeneral.DicemalMask;
                txtMBalanceS.DisplayFormat = VarGeneral.DicemalMask;
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRAccountTrans));
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                Language.ChangeLanguage("ar-SA", this, resources);
                LangArEn = 0;
            }
            else
            {
                Language.ChangeLanguage("en", this, resources);
                LangArEn = 1;
            }
            try
            {
                VarGeneral.itmDesIndex = 0;
                VarGeneral.itmDes = "";
                VarGeneral._DTFrom = "";
                VarGeneral._DTTo = "";
            }
            catch
            {
            }
            FillFlex();
            RepDef();
            if (VarGeneral.SSSTyp == 0)
            {
                numUpDownLevel.Visible = false;
                label10.Visible = false;
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptMaintenanceCars.dll"))
            {
                label7.Text = ((LangArEn == 0) ? "نوع السيارة :" : "Car Type :");
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptBus.dll"))
            {
                label8.Text = ((LangArEn == 0) ? "الباص :" : "Bus :");
                label7.Text = ((LangArEn == 0) ? "السائق :" : "Driver :");
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptWaterPackages.dll"))
            {
                label7.Text = ((LangArEn == 0) ? "العميــــــــل :" : "Customer :");
                label8.Text = ((LangArEn == 0) ? "السيــارة :" : "Car :");
            }
             avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRAccountTrans));
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                Language.ChangeLanguage("ar-SA", this, resources);
                LangArEn = 0;
            }
            else
            {
                Language.ChangeLanguage("en", this, resources);
                LangArEn = 1;
            }
            FillFlex();
            RepDef();
        }
        private void RepDef()
        {
            for (int iiCnt = 1; iiCnt < FlexField.Rows.Count; iiCnt++)
            {
                FlexField.SetData(iiCnt, 0, 1);
            }
        }
        private void FillFlex()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                if (VarGeneral.InvType == 1)
                {
                    Text = "ميزان مراجعة بالحركة";
                    FlexField.Rows.Count = 5;
                    FlexField.SetData(0, 0, "أظهار");
                    FlexField.SetData(0, 1, "أسم الحقل");
                    FlexField.SetData(1, 1, "[رقم الحساب]");
                    FlexField.SetData(1, 2, " T_AccDef.AccDef_No ");
                    FlexField.SetData(2, 1, "[أسم الحساب]");
                    FlexField.SetData(2, 2, " T_AccDef.Arb_Des as AccDefNm ");
                    FlexField.SetData(3, 1, "[حركة مدينة]");
                    FlexField.SetData(3, 2, " Sum(CASE WHEN T_GDDET.gdValue > 0 THEN T_GDDET.gdValue ELSE 0 END) as Debit");
                    FlexField.SetData(4, 1, "[حركة دائنة]");
                    FlexField.SetData(4, 2, " Sum(CASE WHEN T_GDDET.gdValue < 0 THEN Abs(T_GDDET.gdValue) ELSE 0 END) as Credit");
                    FlexField.Tag = " Group by T_AccDef.AccDef_No,T_AccDef.Arb_Des,T_SYSSETTING.LogImg  ";
                }
                else if (VarGeneral.InvType == 2)
                {
                    Text = "ميزان مراجعة بالأرصدة";
                    FlexField.Rows.Count = 5;
                    FlexField.SetData(0, 0, "أظهار");
                    FlexField.SetData(0, 1, "أسم الحقل");
                    FlexField.SetData(1, 1, "[رقم الحساب]");
                    FlexField.SetData(1, 2, " T_AccDef.AccDef_No ");
                    FlexField.SetData(2, 1, "[أسم الحساب]");
                    FlexField.SetData(2, 2, " T_AccDef.Arb_Des as AccDefNm ");
                    FlexField.SetData(3, 1, "[الرصيد مدين]");
                    FlexField.SetData(3, 2, " CASE WHEN Sum(T_GDDET.gdValue) > 0 THEN Sum(T_GDDET.gdValue) ELSE 0 END as Debit");
                    FlexField.SetData(4, 1, "[الرصيد دائن]");
                    FlexField.SetData(4, 2, " CASE WHEN Sum(T_GDDET.gdValue) < 0 THEN Abs(Sum(T_GDDET.gdValue)) ELSE 0 END as Credit");
                    FlexField.Tag = " Group by T_AccDef.AccDef_No,T_AccDef.Arb_Des,T_SYSSETTING.LogImg  ";
                }
                else if (VarGeneral.InvType == 3)
                {
                    Text = "ميزان مراجعة بالمجاميع";
                    FlexField.Rows.Count = 5;
                    FlexField.SetData(0, 0, "أظهار");
                    FlexField.SetData(0, 1, "أسم الحقل");
                    FlexField.SetData(1, 1, "[رقم الحساب]");
                    FlexField.SetData(1, 2, " T_AccDef.AccDef_No ");
                    FlexField.SetData(2, 1, "[أسم الحساب]");
                    FlexField.SetData(2, 2, " T_AccDef.Arb_Des as AccDefNm ");
                    FlexField.SetData(3, 1, "[مجموع مدين]");
                    FlexField.SetData(3, 2, " Sum(CASE WHEN T_GDDET.gdValue > 0 THEN T_GDDET.gdValue ELSE 0 END) as Debit");
                    FlexField.SetData(4, 1, "[مجموع دائن]");
                    FlexField.SetData(4, 2, " Sum(CASE WHEN T_GDDET.gdValue < 0 THEN Abs(T_GDDET.gdValue) ELSE 0 END) as Credit");
                    FlexField.Tag = " Group by T_AccDef.AccDef_No,T_AccDef.Arb_Des,T_SYSSETTING.LogImg  ";
                }
                else if (VarGeneral.InvType == 4)
                {
                    Text = "ميزان مراجعة بالأرصدة و المجاميع";
                    FlexField.Rows.Count = 7;
                    FlexField.SetData(0, 0, "أظهار");
                    FlexField.SetData(0, 1, "أسم الحقل");
                    FlexField.SetData(1, 1, "[رقم الحساب]");
                    FlexField.SetData(1, 2, " T_AccDef.AccDef_No ");
                    FlexField.SetData(2, 1, "[أسم الحساب]");
                    FlexField.SetData(2, 2, " T_AccDef.Arb_Des as AccDefNm ");
                    FlexField.SetData(3, 1, "[مجموع مدين]");
                    FlexField.SetData(3, 2, " Sum(CASE WHEN T_GDDET.gdValue > 0 THEN T_GDDET.gdValue ELSE 0 END) as Debit");
                    FlexField.SetData(4, 1, "[مجموع دائن]");
                    FlexField.SetData(4, 2, " Sum(CASE WHEN T_GDDET.gdValue < 0 THEN Abs(T_GDDET.gdValue) ELSE 0 END) as Credit");
                    FlexField.SetData(5, 1, "[الرصيد مدين]");
                    FlexField.SetData(5, 2, " CASE WHEN Sum(T_GDDET.gdValue) > 0 THEN Sum(T_GDDET.gdValue) ELSE 0 END as TotDebit");
                    FlexField.SetData(6, 1, "[الرصيد دائن]");
                    FlexField.SetData(6, 2, " CASE WHEN Sum(T_GDDET.gdValue) < 0 THEN Abs(Sum(T_GDDET.gdValue)) ELSE 0 END TotCreit");
                    FlexField.Tag = " Group by T_AccDef.AccDef_No,T_AccDef.Arb_Des,T_SYSSETTING.LogImg  ";
                    switchButton_OpenValue.Visible = true;
                }
                else if (VarGeneral.InvType == 5)
                {
                    Text = "حساب المتاجرة";
                    FlexField.Rows.Count = 6;
                    FlexField.SetData(0, 0, "أظهار");
                    FlexField.SetData(0, 1, "أسم الحقل");
                    FlexField.SetData(1, 1, "[رقم الحساب]");
                    FlexField.SetData(1, 2, " T_AccDef.AccDef_No ");
                    FlexField.SetData(2, 1, "[أسم الحساب]");
                    FlexField.SetData(2, 2, " T_AccDef.Arb_Des as AccDefNm ");
                    FlexField.SetData(3, 1, "[الرصيد مدين]");
                    FlexField.SetData(3, 2, " CASE WHEN Sum(T_GDDET.gdValue) > 0 THEN Sum(T_GDDET.gdValue) ELSE 0 END as Debit");
                    FlexField.SetData(4, 1, "[الرصيد دائن]");
                    FlexField.SetData(4, 2, " CASE WHEN Sum(T_GDDET.gdValue) < 0 THEN Abs(Sum(T_GDDET.gdValue)) ELSE 0 END as Credit");
                    FlexField.SetData(5, 1, "[الرصيد]");
                    FlexField.SetData(5, 2, " Sum(T_GDDET.gdValue) as Balance ");
                    FlexField.Tag = " and T_AccDef.Trn = 1 Group by T_AccDef.AccDef_No,T_AccDef.Arb_Des,T_SYSSETTING.LogImg  ";
                    groupBox2.Visible = false;
                }
                else if (VarGeneral.InvType == 6)
                {
                    Text = "حساب الأرباح والخسائر";
                    FlexField.Rows.Count = 6;
                    FlexField.SetData(0, 0, "أظهار");
                    FlexField.SetData(0, 1, "أسم الحقل");
                    FlexField.SetData(1, 1, "[رقم الحساب]");
                    FlexField.SetData(1, 2, " T_AccDef.AccDef_No ");
                    FlexField.SetData(2, 1, "[أسم الحساب]");
                    FlexField.SetData(2, 2, " T_AccDef.Arb_Des as AccDefNm ");
                    FlexField.SetData(3, 1, "[الرصيد مدين]");
                    FlexField.SetData(3, 2, " CASE WHEN Sum(T_GDDET.gdValue) > 0 THEN Sum(T_GDDET.gdValue) ELSE 0 END as Debit");
                    FlexField.SetData(4, 1, "[الرصيد دائن]");
                    FlexField.SetData(4, 2, " CASE WHEN Sum(T_GDDET.gdValue) < 0 THEN Abs(Sum(T_GDDET.gdValue)) ELSE 0 END as Credit");
                    FlexField.SetData(5, 1, "[الرصيد]");
                    FlexField.SetData(5, 2, " Sum(T_GDDET.gdValue) as Balance");
                    FlexField.Tag = " and T_AccDef.Trn = 2 Group by T_AccDef.AccDef_No,T_AccDef.Arb_Des,T_SYSSETTING.LogImg  ";
                    groupBox2.Visible = false;
                }
                else if (VarGeneral.InvType == 7)
                {
                    Text = "الميزانية العمومية";
                    FlexField.Rows.Count = 5;
                    FlexField.SetData(0, 0, "أظهار");
                    FlexField.SetData(0, 1, "أسم الحقل");
                    FlexField.SetData(1, 1, "[رقم الحساب]");
                    FlexField.SetData(1, 2, " T_AccDef.AccDef_No ");
                    FlexField.SetData(2, 1, "[أسم الحساب]");
                    FlexField.SetData(2, 2, " T_AccDef.Arb_Des as AccDefNm ");
                    FlexField.SetData(3, 1, "[الرصيد مدين]");
                    FlexField.SetData(3, 2, " CASE WHEN Sum(T_GDDET.gdValue) > 0 THEN Sum(T_GDDET.gdValue) ELSE 0 END as Debit");
                    FlexField.SetData(4, 1, "[الرصيد دائن]");
                    FlexField.SetData(4, 2, " CASE WHEN Sum(T_GDDET.gdValue) < 0 THEN Abs(Sum(T_GDDET.gdValue)) ELSE 0 END as Credit");
                    FlexField.Tag = " and T_AccDef.Trn = 3 Group by T_AccDef.AccDef_No,T_AccDef.Arb_Des,T_SYSSETTING.LogImg  ";
                    groupBox2.Visible = false;
                }
            }
            else if (VarGeneral.InvType == 1)
            {
                Text = "Movements Entrails Balance";
                FlexField.Rows.Count = 5;
                FlexField.SetData(0, 0, "Showing");
                FlexField.SetData(0, 1, "Filed Name");
                FlexField.SetData(1, 1, "[Account No]");
                FlexField.SetData(1, 2, " T_AccDef.AccDef_No ");
                FlexField.SetData(2, 1, "[Account Name]");
                FlexField.SetData(2, 2, " T_AccDef.Eng_Des as AccDefNm ");
                FlexField.SetData(3, 1, "[Debit Trans]");
                FlexField.SetData(3, 2, " Sum(CASE WHEN T_GDDET.gdValue > 0 THEN T_GDDET.gdValue ELSE 0 END) as Debit");
                FlexField.SetData(4, 1, "[Credit Trans]");
                FlexField.SetData(4, 2, " Sum(CASE WHEN T_GDDET.gdValue < 0 THEN Abs(T_GDDET.gdValue) ELSE 0 END) as Credit");
                FlexField.Tag = " Group by T_AccDef.AccDef_No,T_AccDef.Eng_Des,T_SYSSETTING.LogImg  ";
            }
            else if (VarGeneral.InvType == 2)
            {
                Text = "Trial balance of balances";
                FlexField.Rows.Count = 5;
                FlexField.SetData(0, 0, "Showing");
                FlexField.SetData(0, 1, "Filed Name");
                FlexField.SetData(1, 1, "[Account No]");
                FlexField.SetData(1, 2, " T_AccDef.AccDef_No ");
                FlexField.SetData(2, 1, "[Account Name]");
                FlexField.SetData(2, 2, " T_AccDef.Eng_Des as AccDefNm ");
                FlexField.SetData(3, 1, "[Debit Balance]");
                FlexField.SetData(3, 2, " CASE WHEN Sum(T_GDDET.gdValue) > 0 THEN Sum(T_GDDET.gdValue) ELSE 0 END as Debit");
                FlexField.SetData(4, 1, "[Credit Balance]");
                FlexField.SetData(4, 2, " CASE WHEN Sum(T_GDDET.gdValue) < 0 THEN Abs(Sum(T_GDDET.gdValue)) ELSE 0 END as Credit");
                FlexField.Tag = " Group by T_AccDef.AccDef_No,T_AccDef.Eng_Des,T_SYSSETTING.LogImg  ";
            }
            else if (VarGeneral.InvType == 3)
            {
                Text = "Totals Trial Balance";
                FlexField.Rows.Count = 5;
                FlexField.SetData(0, 0, "Showing");
                FlexField.SetData(0, 1, "Filed Name");
                FlexField.SetData(1, 1, "[Account No]");
                FlexField.SetData(1, 2, " T_AccDef.AccDef_No ");
                FlexField.SetData(2, 1, "[Account Name]");
                FlexField.SetData(2, 2, " T_AccDef.Eng_Des as AccDefNm ");
                FlexField.SetData(3, 1, "[Total Debit]");
                FlexField.SetData(3, 2, " Sum(CASE WHEN T_GDDET.gdValue > 0 THEN T_GDDET.gdValue ELSE 0 END) as Debit");
                FlexField.SetData(4, 1, "[Total Credit]");
                FlexField.SetData(4, 2, " Sum(CASE WHEN T_GDDET.gdValue < 0 THEN Abs(T_GDDET.gdValue) ELSE 0 END) as Credit");
                FlexField.Tag = " Group by T_AccDef.AccDef_No,T_AccDef.Eng_Des,T_SYSSETTING.LogImg  ";
            }
            else if (VarGeneral.InvType == 4)
            {
                Text = "Balance and Totally Trial Balance";
                FlexField.Rows.Count = 7;
                FlexField.SetData(0, 0, "Showing");
                FlexField.SetData(0, 1, "Filed Name");
                FlexField.SetData(1, 1, "[Account No]");
                FlexField.SetData(1, 2, " T_AccDef.AccDef_No ");
                FlexField.SetData(2, 1, "[Account Name]");
                FlexField.SetData(2, 2, " T_AccDef.Eng_Des as AccDefNm ");
                FlexField.SetData(3, 1, "[Total Debit]");
                FlexField.SetData(3, 2, " Sum(CASE WHEN T_GDDET.gdValue > 0 THEN T_GDDET.gdValue ELSE 0 END) as Debit");
                FlexField.SetData(4, 1, "[Total Credit]");
                FlexField.SetData(4, 2, " Sum(CASE WHEN T_GDDET.gdValue < 0 THEN Abs(T_GDDET.gdValue) ELSE 0 END) as Credit");
                FlexField.SetData(5, 1, "[Debit Balance]");
                FlexField.SetData(5, 2, " CASE WHEN Sum(T_GDDET.gdValue) > 0 THEN Sum(T_GDDET.gdValue) ELSE 0 END as TotDebit");
                FlexField.SetData(6, 1, "[Credit Balance]");
                FlexField.SetData(6, 2, " CASE WHEN Sum(T_GDDET.gdValue) < 0 THEN Abs(Sum(T_GDDET.gdValue)) ELSE 0 END TotCreit");
                switchButton_OpenValue.Visible = true;
                FlexField.Tag = " Group by T_AccDef.AccDef_No,T_AccDef.Eng_Des,T_SYSSETTING.LogImg  ";
            }
            else if (VarGeneral.InvType == 5)
            {
                Text = "Trading Account";
                FlexField.Rows.Count = 6;
                FlexField.SetData(0, 0, "Showing");
                FlexField.SetData(0, 1, "Filed Name");
                FlexField.SetData(1, 1, "[Account No]");
                FlexField.SetData(1, 2, " T_AccDef.AccDef_No ");
                FlexField.SetData(2, 1, "[Account Name]");
                FlexField.SetData(2, 2, " T_AccDef.Eng_Des as AccDefNm ");
                FlexField.SetData(3, 1, "[Debit Balance]");
                FlexField.SetData(3, 2, " CASE WHEN Sum(T_GDDET.gdValue) > 0 THEN Sum(T_GDDET.gdValue) ELSE 0 END as Debit");
                FlexField.SetData(4, 1, "[Credit Balance]");
                FlexField.SetData(4, 2, " CASE WHEN Sum(T_GDDET.gdValue) < 0 THEN Abs(Sum(T_GDDET.gdValue)) ELSE 0 END as Credit");
                FlexField.SetData(5, 1, "[Balance]");
                FlexField.SetData(5, 2, " Sum(T_GDDET.gdValue) as Balance");
                FlexField.Tag = " and T_AccDef.Trn = 1 Group by T_AccDef.AccDef_No,T_AccDef.Eng_Des,T_SYSSETTING.LogImg  ";
                groupBox2.Visible = false;
            }
            else if (VarGeneral.InvType == 6)
            {
                Text = "Profits and Losses";
                FlexField.Rows.Count = 6;
                FlexField.SetData(0, 0, "Showing");
                FlexField.SetData(0, 1, "Filed Name");
                FlexField.SetData(1, 1, "[Account No]");
                FlexField.SetData(1, 2, " T_AccDef.AccDef_No ");
                FlexField.SetData(2, 1, "[Account Name]");
                FlexField.SetData(2, 2, " T_AccDef.Eng_Des as AccDefNm ");
                FlexField.SetData(3, 1, "[Debit Balance]");
                FlexField.SetData(3, 2, " CASE WHEN Sum(T_GDDET.gdValue) > 0 THEN Sum(T_GDDET.gdValue) ELSE 0 END as Debit");
                FlexField.SetData(4, 1, "[Credit Balance]");
                FlexField.SetData(4, 2, " CASE WHEN Sum(T_GDDET.gdValue) < 0 THEN Abs(Sum(T_GDDET.gdValue)) ELSE 0 END as Credit");
                FlexField.SetData(5, 1, "[Balance]");
                FlexField.SetData(5, 2, " Sum(T_GDDET.gdValue) as Balance");
                FlexField.Tag = " and T_AccDef.Trn = 2 Group by T_AccDef.AccDef_No,T_AccDef.Eng_Des,T_SYSSETTING.LogImg  ";
                groupBox2.Visible = false;
            }
            else if (VarGeneral.InvType == 7)
            {
                Text = "General Budget";
                FlexField.Rows.Count = 5;
                FlexField.SetData(0, 0, "Showing");
                FlexField.SetData(0, 1, "Filed Name");
                FlexField.SetData(1, 1, "[Account No]");
                FlexField.SetData(1, 2, " T_AccDef.AccDef_No ");
                FlexField.SetData(2, 1, "[Account Name]");
                FlexField.SetData(2, 2, " T_AccDef.Eng_Des as AccDefNm ");
                FlexField.SetData(3, 1, "[Debit Balance]");
                FlexField.SetData(3, 2, " Round(CASE WHEN Sum(T_GDDET.gdValue) > 0 THEN Sum(T_GDDET.gdValue) ELSE 0 END," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as Debit");
                FlexField.SetData(4, 1, "[Credit Balance]");
                FlexField.SetData(4, 2, " Round(CASE WHEN Sum(T_GDDET.gdValue) < 0 THEN Abs(Sum(T_GDDET.gdValue)) ELSE 0 END," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as Credit");
                FlexField.Tag = " and T_AccDef.Trn = 3 Group by T_AccDef.AccDef_No,T_AccDef.Eng_Des , T_AccDef.AccCat , T_AccDef.ParAcc,T_SYSSETTING.LogImg  ";
                groupBox2.Visible = false;
            }
            RibunButtons();
        }
        private string BuildFieldList()
        {
            string Fields = "";
            for (int iiCnt = 1; iiCnt < FlexField.Rows.Count; iiCnt++)
            {
                if (VarGeneral.TString.TEmptyBool(FlexField.GetData(iiCnt, 0)) && FlexField.Rows[iiCnt].Visible)
                {
                    if (!string.IsNullOrEmpty(Fields))
                    {
                        Fields += ",";
                    }
                    Fields += FlexField.GetData(iiCnt, 2).ToString();
                }
            }
            return Fields + " ,T_SYSSETTING.LogImg " + (switchButton_OpenValue.Value ? ",case when (select sum(gdValue) from T_GDDET x LEFT OUTER JOIN T_GDHEAD ON x.gdID = T_GDHEAD.gdhead_ID where x.AccNo = T_AccDef.AccDef_No and T_GDHEAD.salMonth = 'OpenGD' and x.gdValue > 0) > 0 then (select sum(gdValue) from T_GDDET x LEFT OUTER JOIN T_GDHEAD ON x.gdID = T_GDHEAD.gdhead_ID where x.AccNo = T_AccDef.AccDef_No and T_GDHEAD.salMonth = 'OpenGD' and x.gdValue > 0) else 0 end as DebitPervious,case when (select abs(sum(gdValue)) from T_GDDET x LEFT OUTER JOIN T_GDHEAD ON x.gdID = T_GDHEAD.gdhead_ID where x.AccNo = T_AccDef.AccDef_No and T_GDHEAD.salMonth = 'OpenGD' and x.gdValue < 0) > 0 then (select abs(sum(gdValue)) from T_GDDET x LEFT OUTER JOIN T_GDHEAD ON x.gdID = T_GDHEAD.gdhead_ID where x.AccNo = T_AccDef.AccDef_No and T_GDHEAD.salMonth = 'OpenGD' and x.gdValue < 0) else 0 end as CreditPervious" : " ");
        }
        private string BuildRuleList()
        {
            HijriGregDates dateFormatter = new HijriGregDates();
            string Rule = "Where 1 = 1 and T_GDHEAD.gdLok = 0 ";
            if (txtMBalanceB.LockUpdateChecked)
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtMBalanceB.Tag, " >= ", txtMBalanceB.Value);
            }
            if (txtMBalanceS.LockUpdateChecked)
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtMBalanceS.Tag, " <= ", txtMBalanceS.Value);
            }
            if (!string.IsNullOrEmpty(txtFromAccNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtFromAccNo.Tag, " >= '", txtFromAccNo.Text.Trim(), "'");
            }
            if (!string.IsNullOrEmpty(txtIntoAccNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtIntoAccNo.Tag, " <= '", txtIntoAccNo.Text.Trim(), "'");
            }
            if (!string.IsNullOrEmpty(txtCostCNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtCostCNo.Tag, " = '", txtCostCNo.Text.Trim(), "'");
            }
            if (!string.IsNullOrEmpty(txtUserNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtUserNo.Tag, " = '", txtUserNo.Text.Trim(), "'");
            }
            if (!string.IsNullOrEmpty(txtLegateNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtLegateNo.Tag, " = '", txtLegateNo.Text.Trim(), "'");
            }
            if (VarGeneral.InvType == 7 && numUpDownLevel.Value == 4m)
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", numUpDownLevel.Tag, " =  CASE WHEN T_AccDef.AccCat = '4' OR T_AccDef.AccCat = '5' OR T_AccDef.AccCat = '6' THEN 3 ELSE 4 END ");
            }
            else
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", numUpDownLevel.Tag, " = ", numUpDownLevel.Value);
            }
            if (VarGeneral.CheckDate(txtMFromDate.Text) && txtMFromDate.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMFromDate.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_GDHEAD.gdGDate  >= '" + dateFormatter.FormatGreg(txtMFromDate.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_GDHEAD.gdHDate  >= '" + dateFormatter.FormatHijri(txtMFromDate.Text, "yyyy/MM/dd") + "'"));
            }
            if (VarGeneral.CheckDate(txtMToDate.Text) && txtMToDate.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMToDate.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_GDHEAD.gdGDate  <= '" + dateFormatter.FormatGreg(txtMToDate.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_GDHEAD.gdHDate  <= '" + dateFormatter.FormatHijri(txtMToDate.Text, "yyyy/MM/dd") + "'"));
            }
            return Rule + FlexField.Tag;
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (Text == "ميزان مراجعة بالحركة" || Text == "Movements Entrails Balance")
                {
                    VarGeneral.InvType = 1;
                }
                else if (Text == "ميزان مراجعة بالأرصدة" || Text == "Trial balance of balances")
                {
                    VarGeneral.InvType = 2;
                }
                else if (Text == "ميزان مراجعة بالمجاميع" || Text == "Totals Trial Balance")
                {
                    VarGeneral.InvType = 3;
                }
                else if (Text == "ميزان مراجعة بالأرصدة و المجاميع" || Text == "Balance and Totally Trial Balance")
                {
                    VarGeneral.InvType = 4;
                }
                else if (Text == "حساب المتاجرة" || Text == "Trading Account")
                {
                    VarGeneral.InvType = 5;
                }
                else if (Text == "حساب الأرباح والخسائر" || Text == "Profits and Losses")
                {
                    VarGeneral.InvType = 6;
                }
                else if (Text == "الميزانية العمومية" || Text == "General Budget")
                {
                    VarGeneral.InvType = 7;
                }
                RepShow _RepShow = new RepShow();
                string Tables = " T_GDDET LEFT OUTER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID  LEFT OUTER JOIN T_INVSETTING On T_GDHEAD.gdTyp = T_INVSETTING.InvID  " + ((VarGeneral.InvType == 7 && numUpDownLevel.Value == 4m) ? " LEFT OUTER JOIN T_AccDef on (T_GDDET.AccNo = T_AccDef.AccDef_No or (T_GDDET.AccNo LIKE T_AccDef.AccDef_No + '%' and (T_AccDef.AccCat = '4' OR T_AccDef.AccCat = '5' OR T_AccDef.AccCat = '6'))) LEFT OUTER JOIN " : " LEFT OUTER JOIN T_AccDef on T_GDDET.AccNo = T_AccDef.AccDef_No LEFT OUTER JOIN ") + "T_SYSSETTING ON T_GDHEAD.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                string Fields = BuildFieldList();
                _RepShow.Rule = BuildRuleList() + " order by AccDef_No ";
                if (string.IsNullOrEmpty(Fields))
                {
                    return;
                }
                _RepShow.Fields = Fields;
                _RepShow.Tables = Tables;
                try
                {
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                    if (VarGeneral.InvType == 5)
                    {
                        _RepShow = new RepShow();
                        _RepShow.Rule = "";
                        _RepShow.Tables = " T_Items INNER JOIN T_stksQty ON T_Items.Itm_No = T_stksQty.itmNo Left Join  T_SYSSETTING ON T_Items.CompanyID = T_SYSSETTING.SYSSETTING_ID Group by T_SYSSETTING.LogImg ";
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                        {
                            _RepShow.Fields = " '----'  As [AccDef_No], 'بضاعة اخر المدة '  As [AccDefNm], Round(Sum(T_Items.AvrageCost * T_stksQty.stkQty) * 0," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")  As [Debit], Round(Sum(T_Items.AvrageCost * T_stksQty.stkQty)," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")  As [Credit] ,  -Round(Sum(T_Items.AvrageCost * T_stksQty.stkQty)," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")  As [Balance],T_SYSSETTING.LogImg ";
                        }
                        else
                        {
                            _RepShow.Fields = " '----'  As [AccDef_No], 'Net Stock Value'  As [AccDefNm], Round(Sum(T_Items.AvrageCost * T_stksQty.stkQty) * 0," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")  As [Debit], Round(Sum(T_Items.AvrageCost * T_stksQty.stkQty)," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") As [Credit] , -Round(Sum(T_Items.AvrageCost * T_stksQty.stkQty)," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")  As [Balance] ,T_SYSSETTING.LogImg ";
                        }
                        _RepShow = _RepShow.Save();
                        _RepShow.RepData.Tables[0].Merge(VarGeneral.RepData.Tables[0]);
                        VarGeneral.RepData = _RepShow.RepData;
                    }
                    else if (VarGeneral.InvType == 6)
                    {
                        double NetStock = 0.0;
                        _RepShow = new RepShow();
                        _RepShow.Rule = "";
                        _RepShow.Tables = " T_Items INNER JOIN T_stksQty ON T_Items.Itm_No = T_stksQty.itmNo ";
                        _RepShow.Fields = " Round(Sum(T_Items.AvrageCost * T_stksQty.stkQty)," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")  As [MTA] ";
                        _RepShow = _RepShow.Save();
                        if (_RepShow.RepData.Tables[0].Rows.Count != 0)
                        {
                            NetStock = double.Parse(VarGeneral.TString.TEmpty(string.Concat(_RepShow.RepData.Tables[0].Rows[0][0])));
                        }
                        _RepShow = new RepShow();
                        _RepShow.Rule = " Where 1 = 1 and T_GDHEAD.gdLok = 0  and T_AccDef.Trn = 1 and T_AccDef.Lev = 4 Group by T_SYSSETTING.LogImg ";
                        _RepShow.Tables = Tables;
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                        {
                            _RepShow.Fields = " '----'  As [AccDef_No], 'قيمة الأرباح والخسائر'  As [AccDefNm], Round(CASE WHEN (Sum(T_GDDET.gdValue) -  " + NetStock + ") > 0 THEN (Sum(T_GDDET.gdValue) -  " + NetStock + ") ELSE 0 END," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")  As [Debit], Round(CASE WHEN (Sum(T_GDDET.gdValue) -  " + NetStock + ") < 0 THEN Abs(Sum(T_GDDET.gdValue) -  " + NetStock + ") ELSE 0 END," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")  As [Credit] , Round(Sum(T_GDDET.gdValue) -  " + NetStock + "," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as [Balance] ,T_SYSSETTING.LogImg ";
                        }
                        else
                        {
                            _RepShow.Fields = " '----'  As [AccDef_No], 'Net profits and losses'  As [AccDefNm], Round(CASE WHEN (Sum(T_GDDET.gdValue)  -  " + NetStock + ") > 0 THEN (Sum(T_GDDET.gdValue)  -  " + NetStock + ") ELSE 0 END," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")  As [Debit], Round(CASE WHEN (Sum(T_GDDET.gdValue)  -  " + NetStock + ") < 0 THEN Abs(Sum(T_GDDET.gdValue) -  " + NetStock + ") ELSE 0 END," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")  As [Credit] , Round(Sum(T_GDDET.gdValue) -  " + NetStock + "," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as [Balance] ,T_SYSSETTING.LogImg ";
                        }
                        _RepShow = _RepShow.Save();
                        _RepShow.RepData.Tables[0].Merge(VarGeneral.RepData.Tables[0]);
                        VarGeneral.RepData = _RepShow.RepData;
                    }
                    else if (VarGeneral.InvType == 7)
                    {
                        double NetStock = 0.0;
                        _RepShow = new RepShow();
                        _RepShow.Rule = "";
                        _RepShow.Tables = " T_Items INNER JOIN T_stksQty ON T_Items.Itm_No = T_stksQty.itmNo ";
                        _RepShow.Fields = " Round(Sum(T_Items.AvrageCost * T_stksQty.stkQty)," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")  As [MTA] ";
                        _RepShow = _RepShow.Save();
                        if (_RepShow.RepData.Tables[0].Rows.Count != 0)
                        {
                            NetStock = double.Parse(VarGeneral.TString.TEmpty(string.Concat(_RepShow.RepData.Tables[0].Rows[0][0])));
                        }
                        _RepShow = new RepShow();
                        _RepShow.Rule = " Where 1 = 1 and T_GDHEAD.gdLok = 0  and (T_AccDef.Trn = 1 or T_AccDef.Trn = 2) and T_AccDef.Lev = 4 Group by T_SYSSETTING.LogImg";
                        _RepShow.Tables = Tables;
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                        {
                            _RepShow.Fields = " '----'  As [AccDef_No], 'قيمة الأرباح والخسائر'  As [AccDefNm], Round(CASE WHEN (Sum(T_GDDET.gdValue) -  " + NetStock + ") > 0 THEN (Sum(T_GDDET.gdValue) -  " + NetStock + ") ELSE 0 END," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")  As [Debit], Round(CASE WHEN (Sum(T_GDDET.gdValue) -  " + NetStock + ") < 0 THEN Abs(Sum(T_GDDET.gdValue) -  " + NetStock + ") ELSE 0 END," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")  As [Credit] ,T_SYSSETTING.LogImg ";
                        }
                        else
                        {
                            _RepShow.Fields = " '----'  As [AccDef_No], 'Net profits and losses'  As [AccDefNm], Round(CASE WHEN (Sum(T_GDDET.gdValue) -  " + NetStock + ") > 0 THEN (Sum(T_GDDET.gdValue) - " + NetStock + ") ELSE 0 END," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")  As [Debit], Round(CASE WHEN (Sum(T_GDDET.gdValue) - " + NetStock + ") < 0 THEN Abs(Sum(T_GDDET.gdValue) - " + NetStock + ") ELSE 0 END ," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") As [Credit] ,T_SYSSETTING.LogImg ";
                        }
                        _RepShow = _RepShow.Save();
                        _RepShow.RepData.Tables[0].Merge(VarGeneral.RepData.Tables[0]);
                        VarGeneral.RepData = _RepShow.RepData;
                        _RepShow = new RepShow();
                        _RepShow.Rule = "";
                        _RepShow.Tables = " T_Items INNER JOIN T_stksQty ON T_Items.Itm_No = T_stksQty.itmNo Left Join  T_SYSSETTING ON T_Items.CompanyID = T_SYSSETTING.SYSSETTING_ID Group by T_SYSSETTING.LogImg ";
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                        {
                            _RepShow.Fields = " '----'  As [AccDef_No], 'بضاعة اخر المدة'  As [AccDefNm], Round(Sum(T_Items.AvrageCost * T_stksQty.stkQty)," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")  As [Debit], Round(Sum(T_Items.AvrageCost * T_stksQty.stkQty) * 0," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")  As [Credit],T_SYSSETTING.LogImg ";
                        }
                        else
                        {
                            _RepShow.Fields = " '----'  As [AccDef_No], 'Net Stock Value'  As [AccDefNm], Round(Sum(T_Items.AvrageCost * T_stksQty.stkQty)," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")  As [Debit], Round(Sum(T_Items.AvrageCost * T_stksQty.stkQty)* 0," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") As [Credit],T_SYSSETTING.LogImg ";
                        }
                        _RepShow = _RepShow.Save();
                        _RepShow.RepData.Tables[0].Merge(VarGeneral.RepData.Tables[0]);
                        VarGeneral.RepData = _RepShow.RepData;
                    }
                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.Message);
                }
                if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "عفوا .. لا يوجد بيانات لعرضها في التقرير " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                try
                {
                    VarGeneral.IsGeneralUsed = true;
                    FrmReportsViewer frm = new FrmReportsViewer();
                    frm.Repvalue = "AccountTrans";
                    frm.Tag = LangArEn;
                    frm.Repvalue = "AccountTrans";
                    if (switchButton_OpenValue.Value && switchButton_OpenValue.Visible)
                    {
                        VarGeneral.itmDesIndex = 1;
                    }
                    else
                    {
                        VarGeneral.itmDesIndex = 0;
                    }
                    VarGeneral.vTitle = Text;
                    if (VarGeneral.CheckDate(txtMFromDate.Text))
                    {
                        VarGeneral._DTFrom = txtMFromDate.Text;
                    }
                    else
                    {
                        VarGeneral._DTFrom = "";
                    }
                    if (VarGeneral.CheckDate(txtMToDate.Text))
                    {
                        VarGeneral._DTTo = txtMToDate.Text;
                    }
                    else
                    {
                        VarGeneral._DTTo = "";
                    }
                    frm.TopMost = true;
                    frm.ShowDialog();
                    VarGeneral.IsGeneralUsed = false;
                }
                catch (Exception error)
                {
                    VarGeneral.DebLog.writeLog("button_ShowRep_Click:", error, enable: true);
                    MessageBox.Show(error.Message);
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }
        private void ButExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ButExit.Text = "خــــروج Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "طبـــاعة F5" : "عــــرض F5");
                groupBox3.Text = "الرصيــــد";
                groupBox4.Text = "التاريــــخ";
                label1.Text = "مـــــن :";
                label2.Text = "إلـــــى :";
                label5.Text = "من حساب :";
                label6.Text = "الى حساب :";
                label7.Text = "المنـــــدوب :";
                label8.Text = "مركز التكلفة :";
                label9.Text = "المستخـــدم :";
                label10.Text = "المستوى :";
                switchButton_OpenValue.OffText = "إظهار الرصيد الإفتتاحي";
                switchButton_OpenValue.OnText = "إظهار الرصيد الإفتتاحي";
            }
            else
            {
                ButExit.Text = "Exit Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "Print F5" : "Show F5");
                groupBox3.Text = "Balance";
                groupBox4.Text = "Date";
                label1.Text = "From :";
                label2.Text = "To :";
                label5.Text = "Account From :";
                label6.Text = "Account To :";
                label7.Text = "Delegate :";
                label8.Text = "Cost Center :";
                label9.Text = "User:";
                label10.Text = "Level :";
                switchButton_OpenValue.OffText = "Show opening balance";
                switchButton_OpenValue.OnText = "Show opening balance";
            }
        }
        private void FRAccountTrans_Load(object sender, EventArgs e)
        {
        }
        private void txtMFromDate_Click(object sender, EventArgs e)
        {
            txtMFromDate.SelectAll();
        }
        private void txtMToDate_Click(object sender, EventArgs e)
        {
            txtMToDate.SelectAll();
        }
        private void txtMFromDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtMFromDate.Text))
                {
                    txtMFromDate.Text = Convert.ToDateTime(txtMFromDate.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    txtMFromDate.Text = "";
                }
            }
            catch
            {
                txtMFromDate.Text = "";
            }
        }
        private void txtMToDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtMToDate.Text))
                {
                    txtMToDate.Text = Convert.ToDateTime(txtMToDate.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    txtMToDate.Text = "";
                }
            }
            catch
            {
                txtMToDate.Text = "";
            }
        }
        private void button_SrchAccFrom_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, ""));
            columns_Names_visible.Add("TaxNo", new ColumnDictinary("الرقم الضريبي", "Tax No", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtFromAccNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtFromAccName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
                else
                {
                    txtFromAccName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
            }
            else
            {
                txtFromAccNo.Text = "";
                txtFromAccName.Text = "";
            }
        }
        private void button_SrchAccTo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, ""));
            columns_Names_visible.Add("TaxNo", new ColumnDictinary("الرقم الضريبي", "Tax No", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtIntoAccNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtIntoAccName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
                else
                {
                    txtIntoAccName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
            }
            else
            {
                txtIntoAccNo.Text = "";
                txtIntoAccName.Text = "";
            }
        }
        private void button_SrchLegNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("Mnd_No", new ColumnDictinary("رقم المندوب", "Commissary No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_Mndob";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtLegateNo.Text = db.StockMndob(frm.Serach_No).Mnd_ID.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtLegateName.Text = db.StockMndob(frm.Serach_No).Arb_Des.ToString();
                }
                else
                {
                    txtLegateName.Text = db.StockMndob(frm.Serach_No).Eng_Des.ToString();
                }
            }
            else
            {
                txtLegateNo.Text = "";
                txtLegateName.Text = "";
            }
        }
        private void button_SrchCostNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("Cst_No", new ColumnDictinary("الرقم", "No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_CstTbl";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtCostCNo.Text = db.StockCst(frm.Serach_No).Cst_ID.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtCostCName.Text = db.StockCst(frm.Serach_No).Arb_Des.ToString();
                }
                else
                {
                    txtCostCName.Text = db.StockCst(frm.Serach_No).Eng_Des.ToString();
                }
            }
            else
            {
                txtCostCNo.Text = "";
                txtCostCName.Text = "";
            }
        }
        private void button_SrchUsrNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("UsrNo", new ColumnDictinary("رقم المستخدم", "User No", ifDefault: true, ""));
            columns_Names_visible.Add("UsrNamA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("UsrNamE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_User";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtUserNo.Text = dbc.StockUser(frm.Serach_No).UsrNo;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtUserName.Text = dbc.StockUser(frm.Serach_No).UsrNamA.ToString();
                }
                else
                {
                    txtUserName.Text = dbc.StockUser(frm.Serach_No).UsrNamE.ToString();
                }
            }
            else
            {
                txtUserNo.Text = "";
                txtUserName.Text = "";
            }
        }
    }
}
