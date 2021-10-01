using DevComponents.DotNetBar;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmTransDateSync : Form
    { void avs(int arln)

{ 
}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
       // private IContainer components = null;
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
        private Panel panel1;
        private MaskedTextBox dateTimeInput_DateG;
        private MaskedTextBox dateTimeInput_DateH;
        private Label label1;
        private Label label2;
        private ButtonX buttonX_Close;
        private LabelX label3;
        public ButtonX ButOk;
#pragma warning disable CS0414 // The field 'FrmTransDateSync.LangArEn' is assigned but its value is never used
        private int LangArEn = 0;
#pragma warning restore CS0414 // The field 'FrmTransDateSync.LangArEn' is assigned but its value is never used
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private List<T_SYSSETTING> listSysSetting = new List<T_SYSSETTING>();
        private T_SYSSETTING _SysSetting = new T_SYSSETTING();
        private Stock_DataDataContext dbInstance;
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
        public FrmTransDateSync()
        {
            InitializeComponent();//this.Load += langloads;
            dateTimeInput_DateG.Text = VarGeneral.Gdate;
            dateTimeInput_DateH.Text = VarGeneral.Hdate;
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                buttonX_Close.Text = "إغلاق";
                ButOk.Text = "حفــظ";
                label1.Text = "التاريخ الميـلادي :";
                label2.Text = "التاريخ الهجـــري :";
                label3.Text = "تاريخ جلسة العمل";
            }
            else
            {
                buttonX_Close.Text = "Close";
                ButOk.Text = "Save";
                label1.Text = "Date / Gregorian :";
                label2.Text = "Date / Hijri :";
                label3.Text = "Session Date";
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmTransDateSync));
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
            RibunButtons();
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmTransDateSync));
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
            RibunButtons();
        }
        private void dateTimeInput_DateH_Click(object sender, EventArgs e)
        {
            dateTimeInput_DateH.SelectAll();
        }
        private void dateTimeInput_DateG_Click(object sender, EventArgs e)
        {
            dateTimeInput_DateG.SelectAll();
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
                Close();
            }
        }
        private void dateTimeInput_DateH_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(dateTimeInput_DateH.Text))
                {
                    dateTimeInput_DateG.Text = n.HijriToGreg(n.GDateAdd3(dateTimeInput_DateH.Text, VarGeneral.Settings_Sys.HDat.Value), "yyyy/MM/dd");
                    return;
                }
                dateTimeInput_DateG.Text = VarGeneral.Gdate;
                dateTimeInput_DateH.Text = VarGeneral.Hdate;
            }
            catch
            {
                dateTimeInput_DateG.Text = VarGeneral.Gdate;
                dateTimeInput_DateH.Text = VarGeneral.Hdate;
            }
        }
        private void dateTimeInput_DateG_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(dateTimeInput_DateG.Text))
                {
                    dateTimeInput_DateH.Text = n.GregToHijri(n.GDateAdd2(dateTimeInput_DateG.Text, VarGeneral.Settings_Sys.HDat.Value), "yyyy/MM/dd");
                    return;
                }
                dateTimeInput_DateG.Text = VarGeneral.Gdate;
                dateTimeInput_DateH.Text = VarGeneral.Hdate;
            }
            catch
            {
                dateTimeInput_DateG.Text = VarGeneral.Gdate;
                dateTimeInput_DateH.Text = VarGeneral.Hdate;
            }
        }
        private void buttonX_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ribbonBar1_ItemClick(object sender, EventArgs e)
        {
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            try
            {
                int GdateY = int.Parse(dateTimeInput_DateG.Text.Substring(0, 4));
                int GdateM = int.Parse(dateTimeInput_DateG.Text.Substring(5, 2));
                int GdateD = int.Parse(dateTimeInput_DateG.Text.Substring(8, 2));
                int GdateY_h = int.Parse(dateTimeInput_DateH.Text.Substring(0, 4));
                int GdateM_h = int.Parse(dateTimeInput_DateH.Text.Substring(5, 2));
                int GdateD_h = int.Parse(dateTimeInput_DateH.Text.Substring(8, 2));
                try
                {
                    DateTime TmpdateTime = new DateTime(GdateY, GdateM, GdateD);
                    VarGeneral.Gdate = n.FormatGreg(TmpdateTime.Year + "/" + TmpdateTime.Month + "/" + TmpdateTime.Day, "yyyy/MM/dd");
                }
                catch
                {
#pragma warning disable CS0219 // The variable 'TmpdateTime' is assigned but its value is never used
                    DateTime TmpdateTime = default(DateTime);
#pragma warning restore CS0219 // The variable 'TmpdateTime' is assigned but its value is never used
                    DateTime TmpdateTime_h = new DateTime(GdateY_h, GdateM_h, GdateD_h);
                    VarGeneral.Hdate = n.FormatHijri(TmpdateTime_h.Year + "/" + TmpdateTime_h.Month + "/" + TmpdateTime_h.Day, "yyyy/MM/dd");
                    VarGeneral.Gdate = n.HijriToGreg(VarGeneral.Hdate, "yyyy/MM/dd");
                }
                try
                {
                    DateTime TmpdateTime_h = new DateTime(GdateY_h, GdateM_h, GdateD_h);
                    VarGeneral.Hdate = n.FormatHijri(TmpdateTime_h.Year + "/" + TmpdateTime_h.Month + "/" + TmpdateTime_h.Day, "yyyy/MM/dd");
                }
                catch
                {
#pragma warning disable CS0219 // The variable 'TmpdateTime_h' is assigned but its value is never used
                    DateTime TmpdateTime_h = default(DateTime);
#pragma warning restore CS0219 // The variable 'TmpdateTime_h' is assigned but its value is never used
                    VarGeneral.Hdate = n.GregToHijri(VarGeneral.Gdate, "yyyy/MM/dd");
                }
                Close();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("ButOk_Click:", error, enable: true);
                MessageBox.Show(error.Message);
                db.getdate = "";
                Close();
            }
        }
    }
}
