using DevComponents.DotNetBar;
using DevComponents.Editors;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSDateTime.Date;
using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmDaysOfMonth : Form
    { void avs(int arln)

{ 
 button_Save.Text=   (arln == 0 ? "  حفــــظ  " : "  save") ; button_Close.Text=   (arln == 0 ? "  رجــوع  " : "  back") ; label_M12.Text=   (arln == 0 ? "  ذو الحجة  " : "  Dhul-Hijjah") ; label_M11.Text=   (arln == 0 ? "  ذو القعدة  " : "  Zul Qi'dah") ; label_M10.Text=   (arln == 0 ? "  شوال  " : "  Shawwal") ; label_M9.Text=   (arln == 0 ? "  رمضان  " : "  Ramadan") ; label_M8.Text=   (arln == 0 ? "  شعبان  " : "  Shaban") ; label_M7.Text=   (arln == 0 ? "  رجب  " : "  Regep") ; label_M6.Text=   (arln == 0 ? "  جمادى الثاني  " : "  Jumada II") ; label_M5.Text=   (arln == 0 ? "  جمادى الأول  " : "  Jumada I") ; label_M4.Text=   (arln == 0 ? "  ربيع الثاني  " : "  second spring") ; label_M3.Text=   (arln == 0 ? "  ربيع الأول  " : "  Rabi' al-Awal") ; label_M2.Text=   (arln == 0 ? "  صفر  " : "  zero") ; label_M1.Text=   (arln == 0 ? "  محرم  " : "  Muharram") ; button_Defalte.Text=   (arln == 0 ? "  استرجاع التقويم السنوي  " : "  Retrieve the annual calendar") ;}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
        }
   
       // private IContainer components = null;
        protected PanelEx Main_Panel;
        private IntegerInput textbox_Year;
        private IntegerInput textBox_M12;
        private IntegerInput textBox_M11;
        private IntegerInput textBox_M10;
        private IntegerInput textBox_M9;
        private IntegerInput textBox_M8;
        private IntegerInput textBox_M7;
        private IntegerInput textBox_M6;
        private IntegerInput textBox_M5;
        private IntegerInput textBox_M4;
        private IntegerInput textBox_M3;
        private IntegerInput textBox_M2;
        private IntegerInput textBox_M1;
        private Label label_M12;
        private Label label_M11;
        private Label label_M10;
        private Label label_M9;
        private Label label_M8;
        private Label label_M7;
        private Label label_M6;
        private Label label_M5;
        private Label label_M4;
        private Label label_M3;
        private Label label_M2;
        private Label label_M1;
        private ButtonX button_Defalte;
        private ButtonX button_Save;
        private ButtonX button_Close;
        private Panel panel1;
        private PictureBox picture_SSS;
        private int LangArEn = 0;
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private T_DaysOfMonth data_this;
        private Stock_DataDataContext dbInstance;
        public T_DaysOfMonth DataThis
        {
            get
            {
                return data_this;
            }
            set
            {
                data_this = value;
            }
        }
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
        public FrmDaysOfMonth()
        {
            InitializeComponent();this.Load += langloads;
        }
        private void Main_Panel_Click(object sender, EventArgs e)
        {
        }
        private void FrmDaysOfMonth_Load(object sender, EventArgs e)
        {
            try
            {
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                if (calendr.Value == 0 && calendr.HasValue)
                {
                    textbox_Year.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy");
                }
                else
                {
                    textbox_Year.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy");
                }
                for (int i = 1; i <= 12; i++)
                {
                    if (i == 1)
                    {
                        textBox_M1.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: false);
                        label_M1.Text = (n.IsHijri(textbox_Year.Text + "/01/01") ? "محرم" : "Jan");
                    }
                    if (i == 2)
                    {
                        textBox_M2.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: false);
                        label_M2.Text = (n.IsHijri(textbox_Year.Text + "/01/01") ? "صفر" : "Feb");
                    }
                    if (i == 3)
                    {
                        textBox_M3.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: false);
                        label_M3.Text = (n.IsHijri(textbox_Year.Text + "/01/01") ? "ربيع الاول" : "March");
                    }
                    if (i == 4)
                    {
                        textBox_M4.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: false);
                        label_M4.Text = (n.IsHijri(textbox_Year.Text + "/01/01") ? "ربيع الثاني" : "April");
                    }
                    if (i == 5)
                    {
                        textBox_M5.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: false);
                        label_M5.Text = (n.IsHijri(textbox_Year.Text + "/01/01") ? "جمادى الاول" : "May");
                    }
                    if (i == 6)
                    {
                        textBox_M6.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: false);
                        label_M6.Text = (n.IsHijri(textbox_Year.Text + "/01/01") ? "جمادى الثاني" : "Jun");
                    }
                    if (i == 7)
                    {
                        textBox_M7.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: false);
                        label_M7.Text = (n.IsHijri(textbox_Year.Text + "/01/01") ? "رجب" : "Jul");
                    }
                    if (i == 8)
                    {
                        textBox_M8.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: false);
                        label_M8.Text = (n.IsHijri(textbox_Year.Text + "/01/01") ? "شعبان" : "Aug");
                    }
                    if (i == 9)
                    {
                        textBox_M9.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: false);
                        label_M9.Text = (n.IsHijri(textbox_Year.Text + "/01/01") ? "رمضان" : "Sep");
                    }
                    if (i == 10)
                    {
                        textBox_M10.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: false);
                        label_M10.Text = (n.IsHijri(textbox_Year.Text + "/01/01") ? "شوال" : "Oct");
                    }
                    if (i == 11)
                    {
                        textBox_M11.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: false);
                        label_M11.Text = (n.IsHijri(textbox_Year.Text + "/01/01") ? "ذو القعدة" : "Nov");
                    }
                    if (i == 12)
                    {
                        textBox_M12.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: false);
                        label_M12.Text = (n.IsHijri(textbox_Year.Text + "/01/01") ? "ذو الحجة" : "Dec");
                    }
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FrmDaysOfMonth_Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void button_Defalte_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 1; i <= 12; i++)
                {
                    if (i == 1)
                    {
                        textBox_M1.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: true);
                    }
                    if (i == 2)
                    {
                        textBox_M2.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: true);
                    }
                    if (i == 3)
                    {
                        textBox_M3.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: true);
                    }
                    if (i == 4)
                    {
                        textBox_M4.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: true);
                    }
                    if (i == 5)
                    {
                        textBox_M5.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: true);
                    }
                    if (i == 6)
                    {
                        textBox_M6.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: true);
                    }
                    if (i == 7)
                    {
                        textBox_M7.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: true);
                    }
                    if (i == 8)
                    {
                        textBox_M8.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: true);
                    }
                    if (i == 9)
                    {
                        textBox_M9.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: true);
                    }
                    if (i == 10)
                    {
                        textBox_M10.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: true);
                    }
                    if (i == 11)
                    {
                        textBox_M11.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: true);
                    }
                    if (i == 12)
                    {
                        textBox_M12.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: true);
                    }
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_Defalte_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 1; i <= 12; i++)
                {
                    data_this = new T_DaysOfMonth();
                    T_DaysOfMonth newdata = db.EmpFirstDayofMonth(textbox_Year.Text + "/" + i);
                    if (string.IsNullOrEmpty(newdata.ID) || newdata == null)
                    {
                        GetData(i);
                        Guid id = Guid.NewGuid();
                        data_this.ID = id.ToString();
                        db.T_DaysOfMonths.InsertOnSubmit(data_this);
                        db.SubmitChanges();
                    }
                    else
                    {
                        DataThis = newdata;
                        GetData(i);
                        db.Log = VarGeneral.DebugLog;
                        db.SubmitChanges(ConflictMode.ContinueOnConflict);
                    }
                }
                button_Close_Click(sender, e);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_Save_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private T_DaysOfMonth GetData(int iFlag)
        {
            data_this.Year = textbox_Year.Value;
            data_this.Month = iFlag;
            switch (iFlag)
            {
                case 1:
                    data_this.DaysOfMonth = textBox_M1.Value;
                    break;
                case 2:
                    data_this.DaysOfMonth = textBox_M2.Value;
                    break;
            }
            if (iFlag == 3)
            {
                data_this.DaysOfMonth = textBox_M3.Value;
            }
            if (iFlag == 4)
            {
                data_this.DaysOfMonth = textBox_M4.Value;
            }
            if (iFlag == 5)
            {
                data_this.DaysOfMonth = textBox_M5.Value;
            }
            if (iFlag == 6)
            {
                data_this.DaysOfMonth = textBox_M6.Value;
            }
            if (iFlag == 7)
            {
                data_this.DaysOfMonth = textBox_M7.Value;
            }
            if (iFlag == 8)
            {
                data_this.DaysOfMonth = textBox_M8.Value;
            }
            if (iFlag == 9)
            {
                data_this.DaysOfMonth = textBox_M9.Value;
            }
            if (iFlag == 10)
            {
                data_this.DaysOfMonth = textBox_M10.Value;
            }
            if (iFlag == 11)
            {
                data_this.DaysOfMonth = textBox_M11.Value;
            }
            if (iFlag == 12)
            {
                data_this.DaysOfMonth = textBox_M12.Value;
            }
            return data_this;
        }
        private void FrmDaysOfMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void FrmDaysOfMonth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && button_Save.Enabled && button_Save.Visible)
            {
                button_Save_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
