using DevComponents.DotNetBar;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Drawing;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmSetYearAcc : Form
    { void avs(int arln)

{ 
 label54.Text=   (arln == 0 ? "  مــــن :  " : "  from:") ; label55.Text=   (arln == 0 ? "  إلـــى :  " : "  to:") ; label1.Text=   (arln == 0 ? "  سيتم تعيين السنة المالية للنظام ,يرجى كتابة تاريخ البداية لإتمام العملية  " : "  The system's fiscal year will be set, please write the start date to complete the process") ; label_HEADER.Text=   (arln == 0 ? "  تعيين السنة المالية  " : "  Set the fiscal year") ; buttonX_Close.Text=   (arln == 0 ? "  إغلاق  " : "  Close") ; buttonX_Ok.Text=   (arln == 0 ? "  موافــــق  " : "  ok") ;}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
        }
   
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private int LangArEn = 0;
        private Stock_DataDataContext dbInstance;
        private List<T_SYSSETTING> listSysSetting = new List<T_SYSSETTING>();
        private T_SYSSETTING _SysSetting = new T_SYSSETTING();
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
        private Label label1;
        private LabelX label_HEADER;
        private ButtonX buttonX_Close;
        private ButtonX buttonX_Ok;
        private MaskedTextBox dateTimeInput_DT;
        private MaskedTextBox dateTimeInput_DTEnd;
        private Label label54;
        private Label label55;
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
        public FrmSetYearAcc()
        {
            InitializeComponent();this.Load += langloads;
        }
        private void FrmSetYearAcc_Load(object sender, EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmSetYearAcc));
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                Language.ChangeLanguage("ar-SA", this, resources);
                RightToLeft = RightToLeft.Yes;
                LangArEn = 0;
            }
            else
            {
                Language.ChangeLanguage("en", this, resources);
                RightToLeft = RightToLeft.Yes;
                LangArEn = 1;
                buttonX_Close.Text = "Close ";
                buttonX_Ok.Text = "OK";
            }
            _SysSetting = db.SystemSettingStock();
            if (VarGeneral.CheckDate(_SysSetting.AccSupDes.Trim()))
            {
                dateTimeInput_DT.Text = Convert.ToDateTime(_SysSetting.AccSupDes.Trim()).ToString("yyyy/MM/dd");
            }
            if (VarGeneral.CheckDate(_SysSetting.AccCusDes.Trim()))
            {
                dateTimeInput_DTEnd.Text = Convert.ToDateTime(_SysSetting.AccCusDes.Trim()).ToString("yyyy/MM/dd");
            }
        }
        private void buttonX_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void buttonX_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                string vDT = "";
                string vDTEnd = "";
                if (VarGeneral.CheckDate(dateTimeInput_DT.Text))
                {
                    vDT = Convert.ToDateTime(dateTimeInput_DT.Text).ToString("yyyy/MM/dd");
                }
                if (VarGeneral.CheckDate(dateTimeInput_DTEnd.Text))
                {
                    vDTEnd = Convert.ToDateTime(dateTimeInput_DTEnd.Text).ToString("yyyy/MM/dd");
                }
                if (!VarGeneral.CheckDate(vDTEnd))
                {
                    vDT = "";
                }
                if (!VarGeneral.CheckDate(vDT))
                {
                    vDTEnd = "";
                }
                if (VarGeneral.CheckDate(vDT) && !VarGeneral.CheckDate(vDTEnd))
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من صحة تاريخ النهاية " : "End Date is Uncorrecte", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    dateTimeInput_DTEnd.Focus();
                    return;
                }
                if (!VarGeneral.CheckDate(vDT) && VarGeneral.CheckDate(vDTEnd))
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من صحة تاريخ البداية " : "Start Date is Uncorrecte", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    dateTimeInput_DT.Focus();
                    return;
                }
                if (VarGeneral.CheckDate(vDT) && VarGeneral.CheckDate(vDTEnd) && Convert.ToDateTime(vDTEnd) < Convert.ToDateTime(vDT))
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من صحة تاريخ البدايةوالنهاية " : "Start Date and End Date is Uncorrecte", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    vDTEnd = "";
                    dateTimeInput_DT.Focus();
                    return;
                }
                _SysSetting.AccCusDes = vDTEnd;
                _SysSetting.AccSupDes = vDT;
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                MessageBox.Show(".. لقد تم تعيين السنة المالية بنجاح", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                try
                {
                    Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
                    VarGeneral.Settings_Sys = new T_SYSSETTING();
                    VarGeneral.Settings_Sys = dbc.SystemSettingStock();
                }
                catch
                {
                    Application.Exit();
                }
                Close();
            }
            catch
            {
                MessageBox.Show("لقد فمت بإدخال تاريخ غير صحيح ,تأكد من صحة التاريخ ثم حاول مجدداآ", VarGeneral.ProdectNam, MessageBoxButtons.OK);
            }
        }
        private void FrmSetYearAcc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && buttonX_Ok.Enabled && buttonX_Ok.Visible)
            {
                buttonX_Ok_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void dateTimeInput_DT_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_DT.Text = Convert.ToDateTime(dateTimeInput_DT.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_DT.Text = "";
            }
        }
        private void dateTimeInput_DTEnd_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_DTEnd.Text = Convert.ToDateTime(dateTimeInput_DTEnd.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_DTEnd.Text = "";
            }
        }
        private void dateTimeInput_DT_Click(object sender, EventArgs e)
        {
            dateTimeInput_DT.SelectAll();
        }
        private void dateTimeInput_DTEnd_Click(object sender, EventArgs e)
        {
            dateTimeInput_DTEnd.SelectAll();
        }
    }
}
