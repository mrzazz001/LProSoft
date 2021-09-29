using DevComponents.DotNetBar;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmTransDate : Form
    { void avs(int arln)

{ 
}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
        }
   
#pragma warning disable CS0414 // The field 'FrmTransDate.LangArEn' is assigned but its value is never used
        private int LangArEn = 0;
#pragma warning restore CS0414 // The field 'FrmTransDate.LangArEn' is assigned but its value is never used
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private List<T_SYSSETTING> listSysSetting = new List<T_SYSSETTING>();
        private T_SYSSETTING _SysSetting = new T_SYSSETTING();
        private Stock_DataDataContext dbInstance;
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
        public FrmTransDate()
        {
            InitializeComponent();this.Load += langloads;
            dateTimeInput_DateG.Text = VarGeneral.Gdate;
            dateTimeInput_DateH.Text = n.FormatHijri(n.GDateAdd2(n.GregToHijri(dateTimeInput_DateG.Text, "yyyy/MM/dd"), VarGeneral.Settings_Sys.HDat.Value), "yyyy/MM/dd");
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                buttonX_Close.Text = "إغلاق";
                label1.Text = "التاريخ الميـلادي :";
                label2.Text = "التاريخ الهجـــري :";
                label3.Text = "التحويل بين التواريخ";
            }
            else
            {
                buttonX_Close.Text = "Close";
                label1.Text = "Date / Gregorian :";
                label2.Text = "Date / Hijri :";
                label3.Text = "Conversion between dates";
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmTransDate));
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmTransDate));
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
                }
            }
            catch
            {
            }
        }
        private void dateTimeInput_DateG_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(dateTimeInput_DateG.Text))
                {
                    dateTimeInput_DateH.Text = n.GregToHijri(n.GDateAdd2(dateTimeInput_DateG.Text, VarGeneral.Settings_Sys.HDat.Value), "yyyy/MM/dd");
                }
            }
            catch
            {
            }
        }
        private void buttonX_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ribbonBar1_ItemClick(object sender, EventArgs e)
        {
        }
    }
}
