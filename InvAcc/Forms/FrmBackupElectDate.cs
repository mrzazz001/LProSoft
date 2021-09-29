using DevComponents.DotNetBar;
using DevComponents.Editors.DateTimeAdv;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Microsoft.Win32;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmBackupElectDate : Form
    { void avs(int arln)

        {
            //dateTimeInput_DTEnd.Text=   (arln == 0 ? "  تاريخ النهاية  " : "  Expiry date") ; label1.Text=   (arln == 0 ? "  سيتم تفعيل خدمات الدعم الفني و النسخ الإحتياطي الإلكتروني ,   " : "  Technical support and electronic backup services will be activated.") ; labelX1.Text=   (arln == 0 ? "  خدمات الدعم الفني و النسخ الإحتياطي الإلكتروني  " : "  Technical support and electronic backup services") ; buttonX_Close.Text=   (arln == 0 ? "  إغلاق  " : "  Close") ; buttonX_Ok.Text=   (arln == 0 ? "  موافــــق  " : "  ok") ;}
        }
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
        }
   
       // private IContainer components = null;
        private RibbonBar ribbonBar1;
        private Panel panel1;
        private Label label1;
        private DateTimeInput dateTimeInput_DT;
        private LabelX labelX1;
        private ButtonX buttonX_Close;
        private ButtonX buttonX_Ok;
        private DateTimeInput dateTimeInput_DTEnd;
        private int vTyp = 0;
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private Stock_DataDataContext dbInstance;
        private List<T_SYSSETTING> listSysSetting = new List<T_SYSSETTING>();
        private T_SYSSETTING _SysSetting = new T_SYSSETTING();
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
        public FrmBackupElectDate(int typ)
        {
            InitializeComponent();this.Load += langloads;
            vTyp = typ;
        }
        private void FrmBackupElectDate_Load(object sender, EventArgs e)
        {
            CultureInfo sa = new CultureInfo("en-US", useUserOverride: false);
            sa.DateTimeFormat.Calendar = new GregorianCalendar();
            Thread.CurrentThread.CurrentCulture = sa;
            Thread.CurrentThread.CurrentUICulture = sa;
            if (vTyp == 1)
            {
                labelX1.Text = "تعيين السنة المالية";
                label1.Text = "سيتم تعيين السنة المالية للنظام ,يرجى كتابة تاريخ البداية لإتمام العملية";
                dateTimeInput_DT.WatermarkText = "لتعيين تاريخ بداية السنة المالية - إضغط هنا";
                dateTimeInput_DTEnd.WatermarkText = "لتعيين تاريخ نهاية السنة المالية - إضغط هنا";
                dateTimeInput_DTEnd.Visible = true;
                _SysSetting = db.SystemSettingStock();
                if (VarGeneral.CheckDate(_SysSetting.AccSupDes.Trim()))
                {
                    dateTimeInput_DT.Text = Convert.ToDateTime(_SysSetting.AccSupDes.Trim()).ToString("yyyy/MM/dd");
                }
                if (VarGeneral.CheckDate(_SysSetting.AccCusDes.Trim()))
                {
                    dateTimeInput_DTEnd.Text = Convert.ToDateTime(_SysSetting.AccCusDes.Trim()).ToString("yyyy/MM/dd");
                }
                return;
            }
            RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\MrdSoft\\Register", writable: true);
            string regval = string.Empty;
            string DT_H = string.Empty;
            try
            {
                regval = n.FormatGreg(hKey.GetValue("DTBackup").ToString(), "yyyy/MM/dd");
                DT_H = n.GregToHijri(regval);
            }
            catch
            {
                regval = string.Empty;
                DT_H = string.Empty;
            }
            if (VarGeneral.CheckDate(regval))
            {
                dateTimeInput_DTEnd.Text = regval;
                dateTimeInput_DT.Text = Convert.ToDateTime(dateTimeInput_DTEnd.Text).AddYears(-1).ToString("yyyy/MM/dd");
            }
            else
            {
                dateTimeInput_DTEnd.Text = string.Empty;
                dateTimeInput_DT.Text = string.Empty;
            }
            RegistryKey hKeyElec = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
            try
            {
                object q = hKeyElec.GetValue("vBackupELEC");
                if (string.IsNullOrEmpty(q.ToString()))
                {
                    hKeyElec.CreateSubKey("vBackupELEC");
                    hKeyElec.SetValue("vBackupELEC", "0");
                }
            }
            catch
            {
                hKeyElec.CreateSubKey("vBackupELEC");
                hKeyElec.SetValue("vBackupELEC", "0");
            }
            RegistryKey hKeyNew = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", writable: true);
            try
            {
                object q = hKeyNew.GetValue("vBackup_New");
                if (string.IsNullOrEmpty(q.ToString()))
                {
                    hKeyNew.CreateSubKey("vBackup_New");
                    hKeyNew.SetValue("vBackup_New", "0");
                }
            }
            catch
            {
                hKeyNew.CreateSubKey("vBackup_New");
                hKeyNew.SetValue("vBackup_New", "0");
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
                string vDT = string.Empty;
                string vDTEnd = string.Empty;
                if (vTyp == 0)
                {
                    if (VarGeneral.CheckDate(dateTimeInput_DTEnd.Text))
                    {
                        vDT = Convert.ToDateTime(dateTimeInput_DTEnd.Text).ToString("yyyy/MM/dd");
                    }
                    RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\MrdSoft\\Register", writable: true);
                    hKey.SetValue("DTBackup", vDT);
                    RegistryKey hKeyElec = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
                    hKeyElec.SetValue("vBackupELEC", vDT);
                    RegistryKey hKeyNew = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", writable: true);
                    hKeyNew.SetValue("vBackup_New", vDT);
                    try
                    {
                        hKeyNew.DeleteSubKey("TurnOff");
                        hKeyNew.DeleteValue("TurnOff");
                    }
                    catch
                    {
                    }
                    try
                    {
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        File.Delete(Application.StartupPath + "\\flxgridD.txt");
                    }
                    catch
                    {
                    }
                    MessageBox.Show("مبروووك .. لقد تم تفعيل الخـدمــات بنجاح .. \n يمكنك الآن تحديد المسار الخاص بك من شاشة تهيئة النظام", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Close();
                }
                else
                {
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
                        vDT = string.Empty;
                    }
                    if (!VarGeneral.CheckDate(vDT))
                    {
                        vDTEnd = string.Empty;
                    }
                    _SysSetting.AccCusDes = vDTEnd;
                    _SysSetting.AccSupDes = vDT;
                    db.Log = VarGeneral.DebugLog;
                    db.SubmitChanges(ConflictMode.ContinueOnConflict);
                    MessageBox.Show(".. لقد تم تعيين السنة المالية بنجاح", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Close();
                }
            }
            catch
            {
                MessageBox.Show("لقد فمت بإدخال تاريخ غير صحيح ,تأكد من صحة التاريخ ثم حاول مجدداآ", VarGeneral.ProdectNam, MessageBoxButtons.OK);
            }
        }
        private void FrmBackupElectDate_KeyDown(object sender, KeyEventArgs e)
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
        private void labelX1_Click(object sender, EventArgs e)
        {
        }
        private void dateTimeInput_DT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string vDT = string.Empty;
                if (VarGeneral.CheckDate(dateTimeInput_DT.Text))
                {
                    if (VarGeneral.CheckDate(dateTimeInput_DT.Text))
                    {
                        vDT = Convert.ToDateTime(dateTimeInput_DT.Text).ToString("yyyy/MM/dd");
                        dateTimeInput_DTEnd.Text = Convert.ToDateTime(vDT).AddYears(1).ToString("yyyy/MM/dd");
                    }
                }
                else
                {
                    dateTimeInput_DTEnd.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_DTEnd.Text = string.Empty;
            }
        }
        private void dateTimeInput_DTEnd_Click(object sender, EventArgs e)
        {
        }
    }
}
