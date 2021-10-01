using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using Framework.Data;
using Framework.UI;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmOpenRelaySalaries : Form
    { void avs(int arln)

{ 
 label1.Text=   (arln == 0 ? "  الشهـــــر :  " : "  month:") ; button_Close.Text=   (arln == 0 ? "  خـــروج  " : "  Close") ; Button_OK.Text=   (arln == 0 ? "  إلغاء الترحيل  " : "  cancel deportation") ; label3.Text=   (arln == 0 ? "  عدد الأيام :  " : "  The number of days :") ; Text = "إلغاء ترحيل رواتب شهر";this.Text=   (arln == 0 ? "  إلغاء ترحيل رواتب شهر  " : "  Cancellation of posting monthly salaries") ;}
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
        private int LangArEn = 0;
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private ScriptNumber ScriptNumber1 = new ScriptNumber();
        private string vDate = "";
        private T_DaysOfMonth data_this_Dayofmonth;
        private T_Salary data_this_salary;
        private T_Sal data_this_sal;
        private T_Vacation data_this_Vac;
        private T_Info data_this_info;
        private Stock_DataDataContext dbInstance;
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
        private RibbonBar ribbonBar1;
        private Panel panel1;
        protected GroupBox groupBox1;
        private IntegerInput textBox_DayOfMonth;
        protected Label label3;
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
        protected Label label1;
        private ButtonX button_Close;
        private ButtonX Button_OK;
        private ComboBoxEx comboBox_Month;
        private ButtonX button_SrchMonth;
        public T_DaysOfMonth DataThis_Dayofmonth
        {
            get
            {
                return data_this_Dayofmonth;
            }
            set
            {
                data_this_Dayofmonth = value;
            }
        }
        public T_Salary Datathis_salary
        {
            get
            {
                return data_this_salary;
            }
            set
            {
                data_this_salary = value;
            }
        }
        public T_Sal Datathis_sal
        {
            get
            {
                return data_this_sal;
            }
            set
            {
                data_this_sal = value;
            }
        }
        public T_Vacation Data_this_Vac
        {
            get
            {
                return data_this_Vac;
            }
            set
            {
                data_this_Vac = value;
            }
        }
        public T_Info Data_this_info
        {
            get
            {
                return data_this_info;
            }
            set
            {
                data_this_info = value;
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
        public FrmOpenRelaySalaries()
        {
            InitializeComponent();this.Load += langloads;
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                Button_OK.Text = "إلغاء الترحيل";
                button_Close.Text = "خـــروج";
                comboBox_Month.WatermarkText = "لا يوجد رواتب مر\u0651حلة";
                Text = "إلغـــاء ترحيــل رواتــب شهــر";
            }
            else
            {
                Button_OK.Text = "Calculating";
                button_Close.Text = "Close";
                comboBox_Month.WatermarkText = "No Records";
                Text = "Cancel the salaries Relay";
            }
        }
        private void FrmOpenRelaySalaries_Load(object sender, EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmOpenRelaySalaries));
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
            FillCombo();
        }
        private void FillCombo()
        {
            if (VarGeneral.SSSLev == "D" || VarGeneral.SSSLev == "E")
            {
                try
                {
                    List<string> listMonth = (from t in db.T_Salaries
                                              orderby t.SalMonth, t.SalYear
                                              where t.SalaryStatus == (bool?)true
                                              select string.Concat(t.SalYear + "/", t.SalMonth)).ToList();
                    if (listMonth.Count > 0)
                    {
                        comboBox_Month.DataSource = listMonth.Distinct().ToList();
                        comboBox_Month.DisplayMember = "SalYear/SalMonth";
                        comboBox_Month.SelectedIndex = 0;
                    }
                }
                catch (Exception error2)
                {
                    VarGeneral.DebLog.writeLog("comboBox_Branch_SelectedIndexChanged:", error2, enable: true);
                    comboBox_Month.DataSource = null;
                }
                return;
            }
            try
            {
                List<string> listMonth = (from t in db.T_Sals
                                          orderby t.SalMonth, t.SalYear
                                          where t.SalaryStatus == (bool?)true
                                          select string.Concat(t.SalYear + "/", t.SalMonth)).ToList();
                if (listMonth.Count > 0)
                {
                    comboBox_Month.DataSource = listMonth.Distinct().ToList();
                    comboBox_Month.DisplayMember = "SalYear/SalMonth";
                    comboBox_Month.SelectedIndex = 0;
                }
            }
            catch (Exception error2)
            {
                VarGeneral.DebLog.writeLog("comboBox_Branch_SelectedIndexChanged:", error2, enable: true);
                comboBox_Month.DataSource = null;
            }
        }
        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void FrmOpenRelaySalaries_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void FrmOpenRelaySalaries_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && Button_OK.Enabled && Button_OK.Visible)
            {
                Button_OK_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void Button_OK_Click(object sender, EventArgs e)
        {
            if (VarGeneral.SSSLev == "D" || VarGeneral.SSSLev == "E")
            {
                try
                {
                    try
                    {
                        if (comboBox_Month.SelectedIndex == -1 || !VarGeneral.CheckDate(comboBox_Month.Text))
                        {
                            return;
                        }
                    }
                    catch
                    {
                        return;
                    }
                    string txtMonth = Convert.ToDateTime(comboBox_Month.Text).ToString("yyyy/MM");
                    vDate = Convert.ToDateTime(txtMonth).ToString("yyyy/MM/dd");
                    string BDate = vDate;
                    Button_OK.Enabled = false;
                    button_Close.Enabled = false;
                    List<T_Salary> newdata2 = db.GetEmpSalary2(txtMonth);
                    if (newdata2.Count == 0)
                    {
                        MessageBox.Show((LangArEn == 0) ? " رواتب هذا الشهر غير مرحله" : "Salaries this Month not Carryover", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        Button_OK.Enabled = true;
                        button_Close.Enabled = true;
                        return;
                    }
                    if (MessageBox.Show((LangArEn == 0) ? ("هل تريد حذف مسير شهر : [" + Convert.ToDateTime(vDate).ToString("yyyy/MM") + "]") : ("Do you want to delete Messier month : [" + Convert.ToDateTime(vDate).ToString("yyyy/MM") + "]"), VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        goto IL_0626;
                    }
                    if (newdata2.FirstOrDefault().GadeId.HasValue && MessageBox.Show((LangArEn == 0) ? " لقد تم انشاء قيد محاسبي مسبقا\u064c لرواتب هذا الشهر  \n وسيتم حذف هذا القيد هل تريد المتابعة ؟" : "Will filter all advances and holidays between the dates specified \n Are you sure you want to Carryover the data?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    {
                        Button_OK.Enabled = true;
                        button_Close.Enabled = true;
                        return;
                    }
                    int j;
                    for (j = 0; j < newdata2.Count; j++)
                    {
                        if (!newdata2[j].GadeId.HasValue)
                        {
                            continue;
                        }
                        try
                        {
                            List<T_GDHEAD> gdData = db.T_GDHEADs.Where((T_GDHEAD t) => t.gdhead_ID == int.Parse(newdata2[j].GadeId.Value.ToString()) && t.gdTyp == (int?)16).ToList();
                            if (gdData.Count > 0)
                            {
                                IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
                                try
                                {
                                    T_GDHEAD data_this = gdData.FirstOrDefault();
                                    db_ = Database.GetDatabase(VarGeneral.BranchCS);
                                    db_.StartTransaction();
                                    db_.ClearParameters();
                                    db_.AddParameter("gdhead_ID", DbType.Int32, data_this.gdhead_ID);
                                    db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDHEAD_DELETE");
                                    db_.EndTransaction();
                                }
                                catch (SqlException)
                                {
                                    MessageBox.Show((LangArEn == 0) ? "حدث خطأ اثناء محاولة إلغاء ترحيل رواتب الشهر .. " : "An error occurred while trying to decipher the deportation ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    Button_OK.Enabled = true;
                                    button_Close.Enabled = true;
                                    return;
                                }
                            }
                        }
                        catch
                        {
                            MessageBox.Show((LangArEn == 0) ? "حدث خطأ اثناء محاولة إلغاء ترحيل رواتب الشهر .. " : "An error occurred while trying to decipher the deportation ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            Button_OK.Enabled = true;
                            button_Close.Enabled = true;
                            return;
                        }
                    }
                    for (int k = 0; k < newdata2.Count; k++)
                    {
                        Datathis_salary = new T_Salary();
                        data_this_salary = newdata2[k];
                        data_this_salary.GadeId = null;
                        data_this_salary.SalaryStatus = false;
                        db.Log = VarGeneral.DebugLog;
                        db.SubmitChanges(ConflictMode.ContinueOnConflict);
                    }
                    db.OpTestWithBr(Convert.ToDateTime(vDate).ToString("yyyy/MM"), vValue: false);
                    MessageBox.Show((LangArEn == 0) ? ("تمت بنجاح عملية إلغاء ترحيل رواتب شهــر : [" + Convert.ToDateTime(vDate).ToString("yyyy/MM") + "]") : ("Will be Undo Carryover of month : [" + Convert.ToDateTime(vDate).ToString("yyyy/MM") + "]"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Close();
                    goto IL_0626;
                IL_0626:
                    Button_OK.Enabled = true;
                    button_Close.Enabled = true;
                }
                catch (Exception error2)
                {
                    VarGeneral.DebLog.writeLog("bubbleButton_Ok_Click:", error2, enable: true);
                    MessageBox.Show(error2.Message);
                }
                return;
            }
            try
            {
                try
                {
                    if (comboBox_Month.SelectedIndex == -1 || !VarGeneral.CheckDate(comboBox_Month.Text))
                    {
                        return;
                    }
                }
                catch
                {
                    return;
                }
                string txtMonth = Convert.ToDateTime(comboBox_Month.Text).ToString("yyyy/MM");
                vDate = Convert.ToDateTime(txtMonth).ToString("yyyy/MM/dd");
                string BDate = vDate;
                Button_OK.Enabled = false;
                button_Close.Enabled = false;
                List<T_Sal> newdata = db.GetEmpSal2(txtMonth);
                if (newdata.Count == 0)
                {
                    MessageBox.Show((LangArEn == 0) ? " رواتب هذا الشهر غير مرحله" : "Salaries this Month not Carryover", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Button_OK.Enabled = true;
                    button_Close.Enabled = true;
                    return;
                }
                if (MessageBox.Show((LangArEn == 0) ? ("هل تريد حذف مسير شهر : " + Convert.ToDateTime(vDate).ToString("yyyy/MM")) : ("Do you want to delete Messier month : " + Convert.ToDateTime(vDate).ToString("yyyy/MM")), VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    goto IL_0beb;
                }
                if (newdata.FirstOrDefault().GadeId.HasValue && MessageBox.Show((LangArEn == 0) ? " لقد تم انشاء قيد محاسبي مسبقا\u064c لرواتب هذا الشهر  \n وسيتم حذف هذا القيد هل تريد المتابعة ؟" : "Will filter all advances and holidays between the dates specified \n Are you sure you want to Carryover the data?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                {
                    Button_OK.Enabled = true;
                    button_Close.Enabled = true;
                    return;
                }
                int i;
                for (i = 0; i < newdata.Count; i++)
                {
                    try
                    {
                        if (!newdata[i].GadeId.HasValue)
                        {
                            continue;
                        }
                        List<T_GDHEAD> gdData = db.T_GDHEADs.Where((T_GDHEAD t) => t.gdhead_ID == int.Parse(newdata[i].GadeId.Value.ToString()) && t.gdTyp == (int?)13).ToList();
                        if (gdData.Count > 0)
                        {
                            IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
                            try
                            {
                                T_GDHEAD data_this = gdData.FirstOrDefault();
                                db_ = Database.GetDatabase(VarGeneral.BranchCS);
                                db_.StartTransaction();
                                db_.ClearParameters();
                                db_.AddParameter("gdhead_ID", DbType.Int32, data_this.gdhead_ID);
                                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDHEAD_DELETE");
                                db_.EndTransaction();
                            }
                            catch (SqlException)
                            {
                                MessageBox.Show((LangArEn == 0) ? "حدث خطأ اثناء محاولة إلغاء ترحيل رواتب الشهر .. " : "An error occurred while trying to decipher the deportation ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                Button_OK.Enabled = true;
                                button_Close.Enabled = true;
                                return;
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show((LangArEn == 0) ? "حدث خطأ اثناء محاولة إلغاء ترحيل رواتب الشهر .. " : "An error occurred while trying to decipher the deportation ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Button_OK.Enabled = true;
                        button_Close.Enabled = true;
                        return;
                    }
                }
                for (int k = 0; k < newdata.Count; k++)
                {
                    Datathis_sal = new T_Sal();
                    data_this_sal = newdata[k];
                    data_this_sal.GadeId = null;
                    data_this_sal.SalaryStatus = false;
                    db.Log = VarGeneral.DebugLog;
                    db.SubmitChanges(ConflictMode.ContinueOnConflict);
                }
                MessageBox.Show((LangArEn == 0) ? "تمت عملية إلغاء ترحيل الرواتب نجاح" : "The process has been successfully", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Close();
                goto IL_0beb;
            IL_0beb:
                Button_OK.Enabled = true;
                button_Close.Enabled = true;
            }
            catch (Exception error2)
            {
                VarGeneral.DebLog.writeLog("bubbleButton_Ok_Click:", error2, enable: true);
                MessageBox.Show(error2.Message);
            }
        }
        private void button_SrchMonth_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_Month.Items.Count <= 0)
                {
                    return;
                }
                columns_Names_visible2.Clear();
                columns_Names_visible2.Add("Date", new ColumnDictinary("التاريخ ", " Date", ifDefault: true, ""));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                }
                VarGeneral.SFrmTyp = "Months2";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    comboBox_Month.Text = frm.SerachNo;
                }
            }
            catch
            {
            }
        }
    }
}
