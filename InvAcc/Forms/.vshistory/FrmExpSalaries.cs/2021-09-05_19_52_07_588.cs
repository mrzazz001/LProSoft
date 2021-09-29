using DevComponents.DotNetBar;
using DevComponents.Editors;
using Framework.UI;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Microsoft.Win32;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmExpSalaries : Form
    { void avs(int arln)

{ 
}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
        }
   
       // private IContainer components = null;
        private RibbonBar ribbonBar1;
        private Panel panel1;
        protected GroupBox groupBox1;
        protected Label label1;
        private IntegerInput textBox_DayOfMonth;
        private MaskedTextBox textBox_Date;
        protected Label label3;
        private ButtonX button_Close;
        private ButtonX Button_OK;
        private int LangArEn = 0;
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private ScriptNumber ScriptNumber1 = new ScriptNumber();
        private string vDate = "";
        private T_DaysOfMonth data_this_Dayofmonth;
        private T_Salary data_this_salary;
        private T_Vacation data_this_Vac;
        private T_Info data_this_info;
        private Stock_DataDataContext dbInstance;
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
        public FrmExpSalaries()
        {
            InitializeComponent();this.Load += langloads;
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                Button_OK.Text = "إصــدار";
                button_Close.Text = "خـــروج";
                Text = "إصــــدار الرواتـــب";
            }
            else
            {
                Button_OK.Text = "Calculating";
                button_Close.Text = "Close";
                Text = "Calculating salaries";
            }
        }
        private void FrmExpSalaries_Load(object sender, EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmExpSalaries));
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
                RibunButtons();
                dbInstance = null;
                Button_OK.Enabled = true;
                button_Close.Enabled = true;
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                if (calendr.Value == 0 && calendr.HasValue)
                {
                    vDate = VarGeneral.Gdate;
                }
                else
                {
                    vDate = VarGeneral.Hdate;
                }
                textBox_Date.Text = Convert.ToDateTime(vDate).ToString("yyyy/MM");
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FrmExpSalaries_Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void textBox_Date_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(textBox_Date.Text))
                {
                    textBox_Date.Text = Convert.ToDateTime(textBox_Date.Text).ToString("yyyy/MM");
                    return;
                }
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                if (calendr.Value == 0 && calendr.HasValue)
                {
                    textBox_Date.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM");
                }
                else
                {
                    textBox_Date.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM");
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("textBox_Date_Leave:", error, enable: true);
            }
        }
        private void textBox_Date_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox_Date.Text.Length == 7 && VarGeneral.CheckDate(textBox_Date.Text))
                {
                    T_DaysOfMonth newdata = db.EmpFirstDayofMonth(Convert.ToDateTime(textBox_Date.Text + "/01").ToString("yyyy/MM/dd"));
                    if (!string.IsNullOrEmpty(newdata.ID) && newdata != null)
                    {
                        textBox_DayOfMonth.Value = newdata.DaysOfMonth.Value;
                    }
                    else
                    {
                        textBox_DayOfMonth.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textBox_Date.Text + "/01").ToString("yyyy/MM/dd"), GetDefault: true);
                    }
                }
            }
            catch
            {
                textBox_DayOfMonth.Value = 1;
            }
        }
        private T_DaysOfMonth GetData()
        {
            data_this_Dayofmonth.Year = int.Parse(Convert.ToDateTime(vDate).ToString("yyyy/MM/dd").Substring(0, 4));
            data_this_Dayofmonth.Month = int.Parse(Convert.ToDateTime(vDate).ToString("yyyy/MM/dd").Substring(5, 2));
            data_this_Dayofmonth.DaysOfMonth = textBox_DayOfMonth.Value;
            return data_this_Dayofmonth;
        }
        private T_Salary GetData_Sal(T_Emp vEmp)
        {
            int Month1 = 0;
            int Month2 = 0;
            double Total = 0.0;
            double FullSalary = 0.0;
            Guid id = Guid.NewGuid();
            data_this_salary.SalaryID = id.ToString();
            data_this_salary.SalMonth = int.Parse(Convert.ToDateTime(vDate).ToString("yyyy/MM/dd").Substring(5, 2));
            data_this_salary.SalYear = int.Parse(Convert.ToDateTime(vDate).ToString("yyyy/MM/dd").Substring(0, 4));
            data_this_salary.EmpID = vEmp.Emp_ID;
            try
            {
                if (vEmp.Guarantor.HasValue)
                {
                    data_this_salary.DirBoss = vEmp.Guarantor.Value;
                }
                else
                {
                    data_this_salary.DirBoss = null;
                }
            }
            catch
            {
            }
            data_this_salary.DeptNo = vEmp.Dept.Value;
            data_this_salary.SectionNo = vEmp.Section.Value;
            data_this_salary.Job = vEmp.Job.Value;
            data_this_salary.Salary = vEmp.MainSal.Value;
            data_this_salary.SalaryStatus = false;
            data_this_salary.IsPrint = false;
            data_this_salary.SalAcc = vEmp.SalAcc;
            data_this_salary.LoanAcc = vEmp.LoanAcc;
            data_this_salary.HouseAcc = vEmp.HouseAcc;
            try
            {
                if (vEmp.CostCenterEmp.HasValue)
                {
                    data_this_salary.CostCenterEmp = vEmp.CostCenterEmp.Value;
                }
                else
                {
                    data_this_salary.CostCenterEmp = null;
                }
            }
            catch
            {
                data_this_salary.CostCenterEmp = null;
            }
            if (VarGeneral.Settings_Sys.SYSSETTING_ID != 0 && VarGeneral.Settings_Sys != null)
            {
                Total = 0.0;
                Month1 = int.Parse(Convert.ToDateTime(vEmp.DateAppointment).ToString("yyyy/MM/dd").Substring(5, 2));
                Month2 = int.Parse(Convert.ToDateTime(vDate).ToString("yyyy/MM/dd").Substring(5, 2));
                if (vEmp.AllowancesTime.Value == 0)
                {
                    int? num = (Month2 - Month1) % vEmp.Allowances;
                    if (num.Value == 0 && num.HasValue)
                    {
                        Total = vEmp.HousingAllowance.Value * (double)vEmp.Allowances.Value / 12.0;
                    }
                }
                else
                {
                    int? num = (Month2 - Month1 + 1) % vEmp.Allowances;
                    if (num.Value == 0 && num.HasValue)
                    {
                        Total = vEmp.HousingAllowance.Value * (double)vEmp.Allowances.Value / 12.0;
                    }
                }
                if (Total < 0.0)
                {
                    Total = 0.0;
                }
                data_this_salary.HousingAllowance = Total;
            }
            data_this_salary.TransferAllowance = vEmp.TransferAllowance.Value;
            data_this_salary.OtherAllowance = vEmp.OtherAllowance.Value + vEmp.SubsistenceAllowance.Value + vEmp.NaturalWorkAllowance.Value;
            Total = data_this_salary.OtherAllowance.Value;
            if (VarGeneral.Settings_Sys.CalculateNo == 2)
            {
                FullSalary = vEmp.MainSal.Value;
            }
            else if (VarGeneral.Settings_Sys.CalculateNo == 3)
            {
                FullSalary = vEmp.MainSal.Value + vEmp.HousingAllowance.Value / 12.0;
            }
            else if (VarGeneral.Settings_Sys.CalculateNo == 4)
            {
                FullSalary = vEmp.MainSal.Value + vEmp.HousingAllowance.Value / 12.0 + vEmp.TransferAllowance.Value + vEmp.SubsistenceAllowance.Value + vEmp.NaturalWorkAllowance.Value + vEmp.OtherAllowance.Value;
            }
            data_this_salary.SocialInsuranceComp = FullSalary * (vEmp.SocialInsuranceComp.Value / 100.0);
            data_this_salary.SocialInsurance = FullSalary * (vEmp.SocialInsurance.Value / 100.0);
            if (VarGeneral.Settings_Sys.CalculateNo == 8)
            {
                data_this_salary.SocialInsuranceComp = vEmp.SocialInsurance.Value;
                data_this_salary.SocialInsurance = vEmp.SocialInsuranceComp.Value;
            }
            data_this_salary.InsuranceMedical = vEmp.InsuranceMedical.Value;
            data_this_salary.InsuranceMedicalCom = vEmp.InsuranceMedicalCom.Value;
            if (vEmp.MainSal.Value > 0.0 && textBox_DayOfMonth.Value > 0 && Convert.ToDateTime(vEmp.DateAppointment).ToString("yyyy/MM") == Convert.ToDateTime(vDate).ToString("yyyy/MM") && int.Parse(Convert.ToDateTime(vEmp.DateAppointment).ToString("yyyy/MM/dd").Substring(8, 2)) > 1)
            {
                data_this_salary.Salary = Math.Round(vEmp.MainSal.Value - (double)(int.Parse(Convert.ToDateTime(vEmp.DateAppointment).ToString("yyyy/MM/dd").Substring(8, 2)) - 1) * (vEmp.MainSal.Value / (double)textBox_DayOfMonth.Value), 2);
                data_this_salary.TransferAllowance = Math.Round(vEmp.TransferAllowance.Value - (double)(int.Parse(Convert.ToDateTime(vEmp.DateAppointment).ToString("yyyy/MM/dd").Substring(8, 2)) - 1) * (vEmp.TransferAllowance.Value / (double)textBox_DayOfMonth.Value), 2);
                Total = Math.Round(Total - (double)(int.Parse(Convert.ToDateTime(vEmp.DateAppointment).ToString("yyyy/MM/dd").Substring(8, 2)) - 1) * (Total / (double)textBox_DayOfMonth.Value), 2);
                data_this_salary.OtherAllowance = Total;
                data_this_salary.InsuranceMedical = Math.Round(vEmp.InsuranceMedical.Value - (double)(int.Parse(Convert.ToDateTime(vEmp.DateAppointment).ToString("yyyy/MM/dd").Substring(8, 2)) - 1) * (vEmp.InsuranceMedical.Value / (double)textBox_DayOfMonth.Value), 2);
                data_this_salary.InsuranceMedicalCom = Math.Round(vEmp.InsuranceMedicalCom.Value - (double)(int.Parse(Convert.ToDateTime(vEmp.DateAppointment).ToString("yyyy/MM/dd").Substring(8, 2)) - 1) * (vEmp.InsuranceMedicalCom.Value / (double)textBox_DayOfMonth.Value), 2);
                if (VarGeneral.Settings_Sys.CalculateNo == 2)
                {
                    FullSalary = vEmp.MainSal.Value;
                }
                else if (VarGeneral.Settings_Sys.CalculateNo == 3)
                {
                    FullSalary = vEmp.MainSal.Value + vEmp.HousingAllowance.Value / 12.0;
                }
                else if (VarGeneral.Settings_Sys.CalculateNo == 4)
                {
                    FullSalary = vEmp.MainSal.Value + vEmp.HousingAllowance.Value / 12.0 + vEmp.TransferAllowance.Value + vEmp.SubsistenceAllowance.Value + vEmp.NaturalWorkAllowance.Value + vEmp.OtherAllowance.Value;
                }
                data_this_salary.SocialInsuranceComp = FullSalary * (vEmp.SocialInsuranceComp.Value / 100.0);
                data_this_salary.SocialInsurance = FullSalary * (vEmp.SocialInsurance.Value / 100.0);
                data_this_salary.SocialInsuranceComp = Math.Round(FullSalary - (double)(int.Parse(Convert.ToDateTime(vEmp.DateAppointment).ToString("yyyy/MM/dd").Substring(8, 2)) - 1) * (FullSalary / (double)textBox_DayOfMonth.Value), 2) * (vEmp.SocialInsuranceComp.Value / 100.0);
                data_this_salary.SocialInsurance = Math.Round(FullSalary - (double)(int.Parse(Convert.ToDateTime(vEmp.DateAppointment).ToString("yyyy/MM/dd").Substring(8, 2)) - 1) * (FullSalary / (double)textBox_DayOfMonth.Value), 2) * (vEmp.SocialInsurance.Value / 100.0);
                if (VarGeneral.Settings_Sys.CalculateNo == 8)
                {
                    data_this_salary.SocialInsuranceComp = Math.Round(vEmp.SocialInsuranceComp.Value - (double)(int.Parse(Convert.ToDateTime(vEmp.DateAppointment).ToString("yyyy/MM/dd").Substring(8, 2)) - 1) * (vEmp.SocialInsuranceComp.Value / (double)textBox_DayOfMonth.Value), 2);
                    data_this_salary.SocialInsurance = Math.Round(vEmp.SocialInsurance.Value - (double)(int.Parse(Convert.ToDateTime(vEmp.DateAppointment).ToString("yyyy/MM/dd").Substring(8, 2)) - 1) * (vEmp.SocialInsurance.Value / (double)textBox_DayOfMonth.Value), 2);
                }
                if (data_this_salary.HousingAllowance.Value > 0.0)
                {
                    data_this_salary.HousingAllowance = Math.Round(data_this_salary.HousingAllowance.Value - (vEmp.HousingAllowance.Value / 12.0 - (double)(textBox_DayOfMonth.Value - (int.Parse(Convert.ToDateTime(vEmp.DateAppointment).ToString("yyyy/MM/dd").Substring(8, 2)) - 1)) * (vEmp.HousingAllowance.Value / 12.0) / (double)textBox_DayOfMonth.Value), 2);
                }
            }
            RemoveVacFromSalary(data_this_salary, vEmp, VarGeneral.Settings_Sys, vDate, Total);
            Total = data_this_salary.OtherAllowance.Value;
            DateTime Dt2 = Convert.ToDateTime(Convert.ToDateTime(vDate).ToString("yyyy/MM"));
            Data_this_Vac = new T_Vacation();
            List<T_Vacation> data = db.ExecuteQuery<T_Vacation>("Select * From T_Vacation Where EmpID='" + vEmp.Emp_ID + "' AND T_Vacation.AdminLock = 1 And WithDateSal='" + Convert.ToDateTime(vDate).ToString("yyyy/MM") + "'", new object[0]).ToList();
            if (data.Count > 0)
            {
                double q = data.Sum((T_Vacation t) => t.Amount.Value);
                if (!string.IsNullOrEmpty(q.ToString()) && q > 0.0)
                {
                    Total += q;
                }
            }
            data_this_salary.OtherAllowance = Total;
            double RSum = 0.0;
            List<T_SalDiscount> QSum = db.ExecuteQuery<T_SalDiscount>("Select * from [T_SalDiscount] where [EmpID]='" + vEmp.Emp_ID + "' And [SalDate] like '" + Convert.ToDateTime(vDate).ToString("yyyy/MM") + "' And [SubTyp] = 1", new object[0]).ToList();
            if (QSum.Count() > 0)
            {
                RSum = QSum.Sum((T_SalDiscount g) => g.SubTotaly.Value);
            }
            if (RSum != 0.0)
            {
                if (!string.IsNullOrEmpty(RSum.ToString()))
                {
                    data_this_salary.SubDay = RSum;
                }
                RSum = 0.0;
            }
            else
            {
                data_this_salary.SubDay = 0.0;
            }
            QSum = db.ExecuteQuery<T_SalDiscount>("Select * from [T_SalDiscount] where [EmpID]='" + vEmp.Emp_ID + "' And [SalDate] like '" + Convert.ToDateTime(vDate).ToString("yyyy/MM") + "' And [SubTyp] = 2", new object[0]).ToList();
            if (QSum.Count() > 0)
            {
                RSum = QSum.Sum((T_SalDiscount g) => g.SubTotaly.Value);
            }
            if (RSum != 0.0)
            {
                if (!string.IsNullOrEmpty(RSum.ToString()))
                {
                    data_this_salary.LateHours = RSum;
                }
                RSum = 0.0;
            }
            else
            {
                data_this_salary.LateHours = 0.0;
            }
            QSum = db.ExecuteQuery<T_SalDiscount>("Select * from [T_SalDiscount] where [EmpID]='" + vEmp.Emp_ID + "' And [SalDate] like '" + Convert.ToDateTime(vDate).ToString("yyyy/MM") + "' And [SubTyp] = 3", new object[0]).ToList();
            if (QSum.Count() > 0)
            {
                RSum = QSum.Sum((T_SalDiscount g) => g.SubTotaly.Value);
            }
            if (RSum != 0.0)
            {
                if (!string.IsNullOrEmpty(RSum.ToString()))
                {
                    data_this_salary.SubJaza = RSum;
                }
                RSum = 0.0;
            }
            else
            {
                data_this_salary.SubJaza = 0.0;
            }
            QSum = db.ExecuteQuery<T_SalDiscount>("Select * from [T_SalDiscount] where [EmpID]='" + vEmp.Emp_ID + "' And [SalDate] like '" + Convert.ToDateTime(vDate).ToString("yyyy/MM") + "' And [SubTyp] = 4", new object[0]).ToList();
            if (QSum.Count() > 0)
            {
                RSum = QSum.Sum((T_SalDiscount g) => g.SubTotaly.Value);
            }
            if (RSum != 0.0)
            {
                if (!string.IsNullOrEmpty(RSum.ToString()))
                {
                    data_this_salary.SubOther = RSum;
                }
                RSum = 0.0;
            }
            else
            {
                data_this_salary.SubOther = 0.0;
            }
            List<T_CallPhone> QSumCallPhone = db.ExecuteQuery<T_CallPhone>("Select * from [T_CallPhone] where [EmpID]='" + vEmp.Emp_ID + "' And [SalDate] like '" + Convert.ToDateTime(vDate).ToString("yyyy/MM") + "'", new object[0]).ToList();
            if (QSumCallPhone.Count() > 0)
            {
                RSum = QSumCallPhone.Sum((T_CallPhone g) => g.PhoneValue.Value);
            }
            if (RSum != 0.0)
            {
                if (!string.IsNullOrEmpty(RSum.ToString()))
                {
                    data_this_salary.SubCallPhone = RSum;
                }
                RSum = 0.0;
            }
            else
            {
                data_this_salary.SubCallPhone = 0.0;
            }
            List<T_Commentary> QSumCommentary = db.ExecuteQuery<T_Commentary>("Select * from [T_Commentary] where [EmpID]='" + vEmp.Emp_ID + "' And [SalDate] like '" + Convert.ToDateTime(vDate).ToString("yyyy/MM") + "'", new object[0]).ToList();
            if (QSumCommentary.Count() > 0)
            {
                RSum = QSumCommentary.Sum((T_Commentary g) => g.Value.Value);
            }
            if (RSum != 0.0)
            {
                if (!string.IsNullOrEmpty(RSum.ToString()))
                {
                    data_this_salary.SubCommentary = RSum;
                }
                RSum = 0.0;
            }
            else
            {
                data_this_salary.SubCommentary = 0.0;
            }
            List<T_Add> QSumAdd = db.ExecuteQuery<T_Add>("Select * from [T_Add] where [EmpID]='" + vEmp.Emp_ID + "' And [SalDate] like '" + Convert.ToDateTime(vDate).ToString("yyyy/MM") + "' And [AddTyp] = 1", new object[0]).ToList();
            if (QSumAdd.Count() > 0)
            {
                RSum = QSumAdd.Sum((T_Add g) => g.AddTotaly.Value);
            }
            if (RSum != 0.0)
            {
                if (!string.IsNullOrEmpty(RSum.ToString()))
                {
                    data_this_salary.AddDay = RSum;
                }
                RSum = 0.0;
            }
            else
            {
                data_this_salary.AddDay = 0.0;
            }
            QSumAdd = db.ExecuteQuery<T_Add>("Select * from [T_Add] where [EmpID]='" + vEmp.Emp_ID + "' And [SalDate] like '" + Convert.ToDateTime(vDate).ToString("yyyy/MM") + "' And [AddTyp] = 2", new object[0]).ToList();
            if (QSumAdd.Count() > 0)
            {
                RSum = QSumAdd.Sum((T_Add g) => g.AddTotaly.Value);
            }
            if (RSum != 0.0)
            {
                if (!string.IsNullOrEmpty(RSum.ToString()))
                {
                    data_this_salary.AddHour = RSum;
                }
                RSum = 0.0;
            }
            else
            {
                data_this_salary.AddHour = 0.0;
            }
            QSumAdd = db.ExecuteQuery<T_Add>("Select * from [T_Add] where [EmpID]='" + vEmp.Emp_ID + "' And [SalDate] like '" + Convert.ToDateTime(vDate).ToString("yyyy/MM") + "' And [AddTyp] = 3", new object[0]).ToList();
            if (QSumAdd.Count() > 0)
            {
                RSum = QSumAdd.Sum((T_Add g) => g.AddTotaly.Value);
            }
            if (RSum != 0.0)
            {
                if (!string.IsNullOrEmpty(RSum.ToString()))
                {
                    data_this_salary.MandateDay = RSum;
                }
                RSum = 0.0;
            }
            else
            {
                data_this_salary.MandateDay = 0.0;
            }
            Total = 0.0;
            List<T_Advance> QAdvanc = db.T_Advances.Where((T_Advance t) => t.EmpID == vEmp.Emp_ID && t.Remaining.Value != 0.0).ToList();
            for (int i = 0; i < QAdvanc.Count; i++)
            {
                List<T_Premium> QPremimum = db.ExecuteQuery<T_Premium>("Select * from [T_Premiums] where [Advances_No]= " + QAdvanc[i].Advances_No + " And [PremiumsDate] like '" + Convert.ToDateTime(vDate).ToString("yyyy/MM") + "'", new object[0]).ToList();
                for (int ii = 0; ii < QPremimum.Count; ii++)
                {
                    Total += QPremimum[ii].ValuePremiums.Value;
                }
            }
            data_this_salary.Advance = Total;
            List<T_Reward> QReward = db.ExecuteQuery<T_Reward>("Select * from [T_Rewards] where [EmpID]='" + vEmp.Emp_ID + "' And [SalDate] like '" + Convert.ToDateTime(vDate).ToString("yyyy/MM") + "'", new object[0]).ToList();
            Total = 0.0;
            for (int i = 0; i < QReward.Count; i++)
            {
                Total += QReward[i].RewardValue.Value;
            }
            data_this_salary.Rewards = Total;
            data_this_salary.Bank = vEmp.Bank;
            if (!string.IsNullOrEmpty(vEmp.AccountID))
            {
                data_this_salary.AccountNo = vEmp.AccountID;
            }
            data_this_salary.IsPrint = false;
            data_this_salary.Total = double.Parse(VarGeneral.TString.TEmpty(string.Concat(data_this_salary.Salary.Value + data_this_salary.HousingAllowance.Value + data_this_salary.TransferAllowance.Value + data_this_salary.OtherAllowance.Value - data_this_salary.SubDay.Value - data_this_salary.LateHours.Value - data_this_salary.SubJaza.Value - data_this_salary.SubOther.Value - data_this_salary.SubCallPhone.Value - data_this_salary.SubCommentary.Value + data_this_salary.AddDay.Value + data_this_salary.AddHour.Value + data_this_salary.MandateDay.Value - data_this_salary.SocialInsurance.Value - data_this_salary.Advance.Value + data_this_salary.Rewards.Value - data_this_salary.InsuranceMedical.Value)));
            data_this_salary.SalSpell = ScriptNumber1.ScriptNum(decimal.Parse(VarGeneral.TString.TEmpty(string.Concat(data_this_salary.Total))));
            return data_this_salary;
        }
        private void RemoveVacFromSalary(T_Salary vSalary, T_Emp vEmp, T_SYSSETTING vInfo, string VSalDate, double TotOthers)
        {
            int Days = 0;
            int Days2 = 0;
            double FullSalary = 0.0;
            if (!(vEmp.MainSal.Value > 0.0) || textBox_DayOfMonth.Value <= 0)
            {
                return;
            }
            Days = db.GetVacDays1(vEmp.Emp_ID, VSalDate);
            Days2 = db.GetVacDays2(vEmp.Emp_ID, VSalDate);
            if (Days == 0 && Days2 == 0)
            {
                data_this_salary.OtherAllowance = TotOthers;
                return;
            }
            if (Days >= textBox_DayOfMonth.Value && Days2 >= textBox_DayOfMonth.Value)
            {
                vSalary.Salary = 0.0;
                vSalary.TransferAllowance = 0.0;
                vSalary.OtherAllowance = 0.0;
                vSalary.InsuranceMedicalCom = 0.0;
                vSalary.InsuranceMedical = 0.0;
                vSalary.SocialInsuranceComp = 0.0;
                vSalary.SocialInsurance = 0.0;
                vSalary.HousingAllowance = 0.0;
                return;
            }
            if (Days < textBox_DayOfMonth.Value && Days != 0)
            {
                vSalary.Salary = vSalary.Salary.Value - (data_this_salary.Salary.Value - Math.Round(vEmp.MainSal.Value - (double)Days * vEmp.MainSal.Value / (double)textBox_DayOfMonth.Value, 2));
                if (VarGeneral.Settings_Sys.DisVacationType.Value == 1 || VarGeneral.Settings_Sys.DisVacationType.Value == 2)
                {
                    data_this_salary.TransferAllowance = data_this_salary.TransferAllowance.Value - (vSalary.TransferAllowance.Value - Math.Round(vEmp.TransferAllowance.Value - (double)Days * vEmp.TransferAllowance.Value / (double)textBox_DayOfMonth.Value, 2));
                }
                if (VarGeneral.Settings_Sys.DisVacationType.Value == 1)
                {
                    TotOthers = Math.Round(TotOthers - (double)Days * (TotOthers / (double)textBox_DayOfMonth.Value), 2);
                    vSalary.OtherAllowance = TotOthers;
                }
                if ((VarGeneral.Settings_Sys.DisVacationType.Value == 1 || VarGeneral.Settings_Sys.DisVacationType.Value == 0) && vSalary.HousingAllowance.Value > 0.0)
                {
                    vSalary.HousingAllowance = vSalary.HousingAllowance.Value - (vSalary.HousingAllowance.Value - (vSalary.HousingAllowance.Value - Math.Round(vEmp.HousingAllowance.Value / 12.0 - (double)(textBox_DayOfMonth.Value - Days) * (vEmp.HousingAllowance.Value / 12.0) / (double)textBox_DayOfMonth.Value, 2)));
                }
                if (vInfo.CalculateNo == 1)
                {
                    FullSalary = vSalary.Salary.Value;
                }
                else if (VarGeneral.Settings_Sys.CalculateNo == 3)
                {
                    FullSalary = vSalary.Salary.Value + vSalary.HousingAllowance.Value;
                }
                else if (VarGeneral.Settings_Sys.CalculateNo == 4)
                {
                    FullSalary = vSalary.Salary.Value + vSalary.HousingAllowance.Value + vSalary.TransferAllowance.Value + TotOthers;
                }
            }
            if (Days2 < textBox_DayOfMonth.Value && Days2 != 0)
            {
                vSalary.Salary = vSalary.Salary.Value - (data_this_salary.Salary.Value - Math.Round(vEmp.MainSal.Value - (double)Days2 * vEmp.MainSal.Value / (double)textBox_DayOfMonth.Value, 2));
                if (vInfo.CalculateNo == 1)
                {
                    FullSalary = vSalary.Salary.Value;
                }
                else if (VarGeneral.Settings_Sys.CalculateNo == 3)
                {
                    FullSalary = vSalary.Salary.Value + vSalary.HousingAllowance.Value;
                }
                else if (VarGeneral.Settings_Sys.CalculateNo == 4)
                {
                    FullSalary = vSalary.Salary.Value + vSalary.HousingAllowance.Value + vSalary.TransferAllowance.Value + TotOthers;
                }
            }
        }
        private void Button_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_DayOfMonth.Value < 28 || textBox_Date.Text.Length != 7 || !VarGeneral.CheckDate(textBox_Date.Text))
                {
                    return;
                }
                if (false)
                {
                    Environment.Exit(0);
                    return;
                }
                vDate = Convert.ToDateTime(textBox_Date.Text).ToString("yyyy/MM/dd");
                string BDate = vDate;
                Button_OK.Enabled = false;
                button_Close.Enabled = false;
                T_DaysOfMonth q = db.EmpFirstDayofMonth(vDate);
                if (q == null || string.IsNullOrEmpty(q.ID))
                {
                    data_this_Dayofmonth = new T_DaysOfMonth();
                    GetData();
                    Guid id = Guid.NewGuid();
                    data_this_Dayofmonth.ID = id.ToString();
                    db.T_DaysOfMonths.InsertOnSubmit(data_this_Dayofmonth);
                    db.SubmitChanges();
                }
                else
                {
                    data_this_Dayofmonth = q;
                    GetData();
                    db.Log = VarGeneral.DebugLog;
                    db.SubmitChanges(ConflictMode.ContinueOnConflict);
                }
                List<T_Salary> newdata = db.GetEmpSalary(textBox_Date.Text);
                if (newdata.Count > 0)
                {
                    for (int i = 0; i < newdata.Count; i++)
                    {
                        if (newdata[i].SalaryStatus == true)
                        {
                            MessageBox.Show((LangArEn == 0) ? "لقد تم احتساب راتب هذا الشهر وترحيلها سابقا" : "Salaries this month is Carryover", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            Button_OK.Enabled = true;
                            button_Close.Enabled = true;
                            return;
                        }
                    }
                }
                db.ExecuteCommand("UPDATE [T_Emp] SET T_Emp.StatusSal = 2 FROM [T_Emp] INNER JOIN dbo.T_Vacation ON T_Emp.Emp_ID = T_Vacation.[EmpID] WHERE T_Vacation.IFState = 0 and '" + Convert.ToDateTime(vDate).ToString("yyyy/MM/dd") + "' >= T_Vacation.StopSalFrom  AND T_Vacation.StopSalFrom <> '' ");
                db.ExecuteCommand("delete T_Salary WHERE SalaryStatus = 0 AND SalYear = " + int.Parse(Convert.ToDateTime(vDate).ToString("yyyy/MM/dd").Substring(0, 4)) + " AND SalMonth = " + int.Parse(Convert.ToDateTime(vDate).ToString("yyyy/MM/dd").Substring(5, 2)));
                List<T_Emp> QuaryEmp = db.EmpsEmpClc();
                if (QuaryEmp.Count() > 0)
                {
                    for (int i = 0; i < QuaryEmp.Count; i++)
                    {
                        try
                        {
                            T_Salary vQ2 = db.GetEmpSalaryWithRqst2(vDate, QuaryEmp[i].Emp_ID);
                            if (vQ2 != null && !string.IsNullOrEmpty(vQ2.SalaryID))
                            {
                                continue;
                            }
                        }
                        catch
                        {
                        }
                        if (Convert.ToDateTime(Convert.ToDateTime(vDate).ToString("yyyy/MM")) >= Convert.ToDateTime(Convert.ToDateTime(QuaryEmp[i].DateAppointment).ToString("yyyy/MM")))
                        {
                            T_Salary vQ = db.GetEmpSalaryWithRqst(vDate, QuaryEmp[i].Emp_ID);
                            if (vQ == null || string.IsNullOrEmpty(vQ.SalaryID))
                            {
                                Datathis_salary = new T_Salary();
                                GetData_Sal(QuaryEmp[i]);
                                db.T_Salaries.InsertOnSubmit(data_this_salary);
                                db.SubmitChanges();
                            }
                        }
                    }
                }
                MessageBox.Show((LangArEn == 0) ? ("تمت عملية احتساب رواتب شهر : [" + Convert.ToDateTime(vDate).ToString("yyyy/MM") + "]") : ("Will be Calcalate Salary of month : [" + Convert.ToDateTime(vDate).ToString("yyyy/MM") + "]"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Close();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("bubbleButton_Ok_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private bool CheckRemotDate()
        {
            try
            {
                if (VarGeneral.gUserName != "runsetting")
                {
                    bool User_Remotly = CheckUserIFRemote();
                    RegistryKey hKeyNew = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", writable: true);
                    RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
                    long regval = 0L;
                    long regvalNew = 0L;
                    if (hKey != null)
                    {
                        try
                        {
                            object q = hKey.GetValue("vRemotly");
                            if (string.IsNullOrEmpty(q.ToString()))
                            {
                                hKey.CreateSubKey("vRemotly");
                                hKey.SetValue("vRemotly", "0");
                            }
                        }
                        catch
                        {
                            hKey.CreateSubKey("vRemotly");
                            hKey.SetValue("vRemotly", "0");
                        }
                        try
                        {
                            object t = hKeyNew.GetValue("vRemotly_New");
                            if (string.IsNullOrEmpty(t.ToString()))
                            {
                                hKeyNew.CreateSubKey("vRemotly_New");
                                hKeyNew.SetValue("vRemotly_New", "0");
                            }
                        }
                        catch
                        {
                            hKeyNew.CreateSubKey("vRemotly_New");
                            hKeyNew.SetValue("vRemotly_New", "0");
                        }
                        regval = long.Parse(hKey.GetValue("vRemotly").ToString());
                        regvalNew = long.Parse(hKeyNew.GetValue("vRemotly_New").ToString());
                    }
                    if (User_Remotly || regval == 1 || regvalNew == 1)
                    {
                        try
                        {
                            if (VarGeneral.vDemo)
                            {
                                return false;
                            }
                            string dtAction = (n.IsHijri(textBox_Date.Text + "/01") ? (textBox_Date.Text + "/01") : n.GregToHijri(textBox_Date.Text + "/01", "yyyy/MM/dd"));
                            if (Convert.ToDateTime(n.GregToHijri(hKeyNew.GetValue("vBackup_New").ToString(), "yyyy/MM/dd")) < Convert.ToDateTime(n.FormatHijri(dtAction, "yyyy/MM/dd")))
                            {
                                MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. لقد تخطيت السنة المالية المحدد للنظام \n يرجى التواصل مع الإدارة لللإشتراك في خدمات النسخة " : "We can not complete the operation .. have you skip the fiscal year specified for the system", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return false;
                            }
                        }
                        catch
                        {
                            MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. لقد تخطيت السنة المالية المحدد للنظام \n يرجى التواصل مع الإدارة لللإشتراك في خدمات النسخة " : "We can not complete the operation .. have you skip the fiscal year specified for the system", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return false;
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        private bool CheckUserIFRemote()
        {
            try
            {
               return false; if (SystemInformation.TerminalServerSession)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return true;
            }
        }
        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void FrmExpSalaries_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void FrmExpSalaries_KeyDown(object sender, KeyEventArgs e)
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
        private void textBox_Date_Click(object sender, EventArgs e)
        {
            textBox_Date.SelectAll();
        }
    }
}
