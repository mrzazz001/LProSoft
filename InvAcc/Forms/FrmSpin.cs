using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.Editors;
using DevComponents.Editors.DateTimeAdv;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmSpin : Form
    { void avs(int arln)

{ 
}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
        private int LangArEn = 0;
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        public List<Control> controls;
        public Control codeControl = new Control();
        private T_Emp data_this;
        private T_SalaryOp data_this_SalaryOp;
        private T_Attend Data_this_Attend;
        private BindingList<T_Attend> Update_Attend;
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
       // private IContainer components = null;
        private RibbonBar ribbonBar1;
        private Panel panel1;
        private ButtonX ButExit;
        private ButtonX Button_Ok;
        private GroupBox groupBox_Date;
        private ExpandablePanel expandablePanel_Girds;
        private ExpandablePanel expandablePanel_Emp;
        private ItemPanel itemPanel4;
        private SuperGridControl dataGridViewX_Emp;
        private ExpandablePanel expandablePanel_Job;
        private ItemPanel itemPanel3;
        private SuperGridControl dataGridViewX_Job;
        private ExpandablePanel expandablePanel_Section;
        private ItemPanel itemPanel2;
        private SuperGridControl dataGridViewX_Section;
        private ExpandablePanel expandablePanel_Dept;
        private ItemPanel itemPanel1;
        private SuperGridControl dataGridViewX_Dept;
        private GroupBox groupBox1;
        private ComboBoxEx comboBox_CalculatliquidNo;
        private Label label2;
        private ComboBoxEx comboBox_CalculateTyp;
        private ComboBoxEx comboBox_Allowances;
        private Label label19;
        private DoubleInput textBox_Value;
        private Label label70;
        private ComboBoxEx comboBox_CalculateNo;
        private Label label1;
        private MaskedTextBox dateTimeInput_warnDate;
        private Label label54;
        private Label label18;
        public T_Emp DataThis
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
        public T_SalaryOp DataThis_SalaryOp
        {
            get
            {
                return data_this_SalaryOp;
            }
            set
            {
                data_this_SalaryOp = value;
            }
        }
        public T_Attend Datathis_Attend
        {
            get
            {
                return Data_this_Attend;
            }
            set
            {
                Data_this_Attend = value;
            }
        }
        public BindingList<T_Attend> UpdateAttend
        {
            get
            {
                return Update_Attend;
            }
            set
            {
                Update_Attend = value;
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
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ButExit.Text = "خــــروج Esc";
                Button_Ok.Text = "نفــــذ\u0651 F2";
                expandablePanel_Dept.Text = "الإدارة";
                expandablePanel_Section.Text = "القسم";
                expandablePanel_Job.Text = "الوظيفة";
                expandablePanel_Emp.Text = "الموظف";
                expandablePanel_Girds.TitleText = "على حسب";
                Text = "العملــــيات على الـــرواتب";
            }
            else
            {
                ButExit.Text = "Exit Esc";
                Button_Ok.Text = "OK F2";
                expandablePanel_Dept.Text = "Department";
                expandablePanel_Section.Text = "Section";
                expandablePanel_Job.Text = "Job";
                expandablePanel_Emp.Text = "Employee";
                expandablePanel_Girds.TitleText = "depend on";
                Text = "Salaries Opration";
            }
        }
        public FrmSpin()
        {
            InitializeComponent();this.Load += langloads;
            expandablePanel_Dept.ExpandedChanging += expandablePanel_Dept_ExpandedChanging;
            expandablePanel_Emp.ExpandedChanging += expandablePanel_Emp_ExpandedChanging;
            expandablePanel_Section.ExpandedChanging += expandablePanel_Section_ExpandedChanging;
            expandablePanel_Job.ExpandedChanging += expandablePanel_Job_ExpandedChanging;
        }
        private void FrmSpin_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmSpin));
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
                SuperGridColumns();
                ADD_Controls();
                RibunButtons();
                Clear();
                FillGrid();
                FillCombo();
                comboBox_CalculateTyp.Focus();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void SuperGridColumns()
        {
            dataGridViewX_Emp.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "الموظف" : "Employee");
            dataGridViewX_Dept.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "الادارة" : "Management");
            dataGridViewX_Job.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "الوظيفة" : "Job");
            dataGridViewX_Section.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "القسم" : "Section");
            dataGridViewX_Emp.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Background.Color1 = SystemColors.ActiveCaption;
            dataGridViewX_Dept.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Background.Color1 = SystemColors.ActiveCaption;
            dataGridViewX_Job.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Background.Color1 = SystemColors.ActiveCaption;
            dataGridViewX_Section.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Background.Color1 = SystemColors.ActiveCaption;
            dataGridViewX_Emp.PrimaryGrid.UseAlternateColumnStyle = false;
            dataGridViewX_Dept.PrimaryGrid.UseAlternateColumnStyle = false;
            dataGridViewX_Job.PrimaryGrid.UseAlternateColumnStyle = false;
            dataGridViewX_Section.PrimaryGrid.UseAlternateColumnStyle = false;
        }
        private void FillGrid()
        {
            dataGridViewX_Dept.PrimaryGrid.Rows.Clear();
            dataGridViewX_Emp.PrimaryGrid.Rows.Clear();
            dataGridViewX_Job.PrimaryGrid.Rows.Clear();
            dataGridViewX_Section.PrimaryGrid.Rows.Clear();
            GridRow row = new GridRow();
            List<T_Emp> listEmp = db.FillEmps_2("").ToList();
            for (int i = 0; i < listEmp.Count; i++)
            {
                row = new GridRow();
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                dataGridViewX_Emp.PrimaryGrid.Rows.Add(row);
                dataGridViewX_Emp.PrimaryGrid.GetCell(i, 1).Value = ((LangArEn == 0) ? listEmp[i].NameA.ToString() : listEmp[i].NameE.ToString());
                dataGridViewX_Emp.PrimaryGrid.GetCell(i, 2).Value = listEmp[i].Emp_ID.ToString();
            }
            List<T_Dept> listDept = db.FillDept_2("").ToList();
            for (int i = 0; i < listDept.Count; i++)
            {
                row = new GridRow();
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                dataGridViewX_Dept.PrimaryGrid.Rows.Add(row);
                dataGridViewX_Dept.PrimaryGrid.GetCell(i, 1).Value = ((LangArEn == 0) ? listDept[i].NameA.ToString() : listDept[i].NameE.ToString());
                dataGridViewX_Dept.PrimaryGrid.GetCell(i, 2).Value = listDept[i].Dept_No.ToString();
            }
            List<T_Section> listSection = db.FillSection_2("").ToList();
            for (int i = 0; i < listSection.Count; i++)
            {
                row = new GridRow();
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                dataGridViewX_Section.PrimaryGrid.Rows.Add(row);
                dataGridViewX_Section.PrimaryGrid.GetCell(i, 1).Value = ((LangArEn == 0) ? listSection[i].NameA.ToString() : listSection[i].NameE.ToString());
                dataGridViewX_Section.PrimaryGrid.GetCell(i, 2).Value = listSection[i].Section_No.ToString();
            }
            List<T_Job> listJob = db.FillJob_2("").ToList();
            for (int i = 0; i < listJob.Count; i++)
            {
                row = new GridRow();
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                dataGridViewX_Job.PrimaryGrid.Rows.Add(row);
                dataGridViewX_Job.PrimaryGrid.GetCell(i, 1).Value = ((LangArEn == 0) ? listJob[i].NameA.ToString() : listJob[i].NameE.ToString());
                dataGridViewX_Job.PrimaryGrid.GetCell(i, 2).Value = listJob[i].Job_No.ToString();
            }
        }
        private string[] getDeptNo()
        {
            string[] listSalse = new string[dataGridViewX_Dept.PrimaryGrid.Rows.Count];
            for (int i = 0; i < dataGridViewX_Dept.PrimaryGrid.Rows.Count; i++)
            {
                if (dataGridViewX_Dept.PrimaryGrid.GetCell(i, 0).Value.ToString() == "True")
                {
                    listSalse[i] = dataGridViewX_Dept.PrimaryGrid.GetCell(i, 2).Value.ToString();
                }
            }
            return listSalse;
        }
        private string[] getEmpNo()
        {
            string[] listSalse = new string[dataGridViewX_Emp.PrimaryGrid.Rows.Count];
            for (int i = 0; i < dataGridViewX_Emp.PrimaryGrid.Rows.Count; i++)
            {
                if (dataGridViewX_Emp.PrimaryGrid.GetCell(i, 0).Value.ToString() == "True")
                {
                    listSalse[i] = dataGridViewX_Emp.PrimaryGrid.GetCell(i, 2).Value.ToString();
                }
            }
            return listSalse;
        }
        private string[] getJobNo()
        {
            string[] listSalse = new string[dataGridViewX_Job.PrimaryGrid.Rows.Count];
            for (int i = 0; i < dataGridViewX_Job.PrimaryGrid.Rows.Count; i++)
            {
                if (dataGridViewX_Job.PrimaryGrid.GetCell(i, 0).Value.ToString() == "True")
                {
                    listSalse[i] = dataGridViewX_Job.PrimaryGrid.GetCell(i, 2).Value.ToString();
                }
            }
            return listSalse;
        }
        private string[] getSectionNo()
        {
            string[] listSalse = new string[dataGridViewX_Section.PrimaryGrid.Rows.Count];
            for (int i = 0; i < dataGridViewX_Section.PrimaryGrid.Rows.Count; i++)
            {
                if (dataGridViewX_Section.PrimaryGrid.GetCell(i, 0).Value.ToString() == "True")
                {
                    listSalse[i] = dataGridViewX_Section.PrimaryGrid.GetCell(i, 2).Value.ToString();
                }
            }
            return listSalse;
        }
        private void expandablePanel_Girds_ExpandedChanging(object sender, ExpandedChangeEventArgs e)
        {
            if (!expandablePanel_Girds.ExpandButtonVisible)
            {
                e.Cancel = true;
                return;
            }
            expandablePanel_Emp.Expanded = false;
            expandablePanel_Dept.Expanded = false;
            expandablePanel_Job.Expanded = false;
            expandablePanel_Section.Expanded = false;
        }
        private void expandablePanel_Girds_ExpandedChanged(object sender, ExpandedChangeEventArgs e)
        {
            expandablePanel_Dept.Expanded = false;
            expandablePanel_Emp.Expanded = false;
            expandablePanel_Job.Expanded = false;
            expandablePanel_Section.Expanded = false;
        }
        private void expandablePanel_Dept_ExpandedChanging(object sender, ExpandedChangeEventArgs e)
        {
            if (!expandablePanel_Girds.Expanded)
            {
                e.Cancel = true;
            }
        }
        private void expandablePanel_Emp_ExpandedChanging(object sender, ExpandedChangeEventArgs e)
        {
            if (!expandablePanel_Girds.Expanded)
            {
                e.Cancel = true;
            }
        }
        private void expandablePanel_Job_ExpandedChanging(object sender, ExpandedChangeEventArgs e)
        {
            if (!expandablePanel_Girds.Expanded)
            {
                e.Cancel = true;
            }
        }
        private void expandablePanel_Section_ExpandedChanging(object sender, ExpandedChangeEventArgs e)
        {
            if (!expandablePanel_Girds.Expanded)
            {
                e.Cancel = true;
            }
        }
        public void FillCombo()
        {
            comboBox_CalculateTyp.Items.Clear();
            comboBox_CalculateTyp.Items.Add((LangArEn == 0) ? "زيادة" : "Increase");
            comboBox_CalculateTyp.Items.Add((LangArEn == 0) ? "نقص" : "Decrease");
            comboBox_CalculateTyp.SelectedIndex = 0;
            comboBox_CalculatliquidNo.Items.Clear();
            comboBox_CalculatliquidNo.Items.Add((LangArEn == 0) ? "في المائة" : "Percent");
            comboBox_CalculatliquidNo.Items.Add((LangArEn == 0) ? "مبلغ مقطوع" : "Fixed Sum");
            comboBox_CalculatliquidNo.SelectedIndex = 0;
            List<T_OpMethod> listOpMethod = new List<T_OpMethod>((from item in db.T_OpMethods
                                                                  orderby item.Method_No
                                                                  where item.Method_No != 1 && item.Method_No != 3 && item.Method_No != 4 && item.Method_No != 5 && item.Method_No != 6 && item.Method_No != 7 && item.Method_No != 8
                                                                  select item).ToList());
            comboBox_Allowances.DataSource = listOpMethod;
            comboBox_Allowances.DisplayMember = ((LangArEn == 0) ? "Name" : "NameE");
            comboBox_Allowances.ValueMember = "Method_No";
            comboBox_Allowances.SelectedIndex = 0;
            List<T_OpMethod> listOpMethodN0 = new List<T_OpMethod>((from item in db.T_OpMethods
                                                                    orderby item.Method_No
                                                                    where item.Method_No != 1 && item.Method_No != 7 && item.Method_No != 8 && item.Method_No != 9 && item.Method_No != 10 && item.Method_No != 10 && item.Method_No != 11 && item.Method_No != 12 && item.Method_No != 13
                                                                    select item).ToList());
            comboBox_CalculateNo.DataSource = listOpMethodN0;
            comboBox_CalculateNo.DisplayMember = ((LangArEn == 0) ? "Name" : "NameE");
            comboBox_CalculateNo.ValueMember = "Method_No";
            comboBox_CalculateNo.SelectedIndex = 0;
        }
        private void ADD_Controls()
        {
            try
            {
                controls = new List<Control>();
                controls.Add(textBox_Value);
                controls.Add(comboBox_Allowances);
                controls.Add(comboBox_CalculateTyp);
                controls.Add(comboBox_CalculatliquidNo);
                controls.Add(comboBox_CalculateNo);
                controls.Add(dateTimeInput_warnDate);
                controls.Add(dataGridViewX_Dept);
                controls.Add(dataGridViewX_Job);
                controls.Add(dataGridViewX_Section);
            }
            catch (SqlException)
            {
            }
        }
        public void Clear()
        {
            data_this = new T_Emp();
            Data_this_Attend = new T_Attend();
            Update_Attend = new BindingList<T_Attend>();
            int? calendr;
            for (int i = 0; i < controls.Count; i++)
            {
                if (controls[i].GetType() == typeof(DateTimePicker))
                {
                    calendr = VarGeneral.Settings_Sys.Calendr;
                    if (calendr.Value == 0 && calendr.HasValue)
                    {
                        (controls[i] as DateTimePicker).Text = VarGeneral.Gdate;
                    }
                    else
                    {
                        (controls[i] as DateTimePicker).Text = VarGeneral.Hdate;
                    }
                }
                else if (controls[i].GetType() == typeof(DateTimeInput))
                {
                    (controls[i] as DateTimeInput).Value = DateTime.Now;
                }
                else if (controls[i].GetType() == typeof(ComboBox) && (controls[i] as ComboBox).Items.Count > 0)
                {
                    try
                    {
                        (controls[i] as ComboBox).SelectedIndex = 0;
                    }
                    catch
                    {
                        (controls[i] as ComboBox).SelectedIndex = -1;
                    }
                }
                else if (controls[i].GetType() == typeof(CheckBox))
                {
                    (controls[i] as CheckBox).Checked = false;
                }
                else if (controls[i].GetType() == typeof(PictureBox))
                {
                    (controls[i] as PictureBox).Image = null;
                }
                else if (!(controls[i].Name == codeControl.Name))
                {
                    if (controls[i].GetType() == typeof(DoubleInput))
                    {
                        (controls[i] as DoubleInput).Value = 0.0;
                    }
                    else if (controls[i].GetType() == typeof(IntegerInput))
                    {
                        (controls[i] as IntegerInput).Value = 0;
                    }
                    else if (controls[i].GetType() == typeof(TextBox) || controls[i].GetType() == typeof(TextBoxX) || controls[i].GetType() == typeof(MaskedTextBox))
                    {
                        controls[i].Text = "";
                    }
                    else if (controls[i].GetType() == typeof(CheckBox))
                    {
                        (controls[i] as CheckBox).Checked = false;
                    }
                    else if (controls[i].GetType() == typeof(RadioButton))
                    {
                        (controls[i] as RadioButton).Checked = false;
                    }
                }
            }
            calendr = VarGeneral.Settings_Sys.Calendr;
            if (calendr.Value == 0 && calendr.HasValue)
            {
                dateTimeInput_warnDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
            }
            else
            {
                dateTimeInput_warnDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
            }
        }
        private T_Emp GetData(double vValue)
        {
            switch (comboBox_Allowances.SelectedIndex)
            {
                case 0:
                    data_this.MainSal = vValue;
                    break;
                case 1:
                    data_this.HousingAllowance = vValue;
                    break;
                case 2:
                    data_this.TransferAllowance = vValue;
                    break;
                case 3:
                    data_this.SubsistenceAllowance = vValue;
                    break;
                case 4:
                    data_this.NaturalWorkAllowance = vValue;
                    break;
                case 5:
                    data_this.OtherAllowance = vValue;
                    break;
            }
            return data_this;
        }
        private void CalcAddSub()
        {
            try
            {
                double vHour = 0.0;
                double vDay = 0.0;
                if (data_this.DayOfMonth.Value <= 0 || !(data_this.MainSal.Value > 0.0))
                {
                    return;
                }
                switch (comboBox_CalculateNo.SelectedIndex)
                {
                    case 0:
                        vDay = Math.Round(data_this.MainSal.Value / (double)data_this.DayOfMonth.Value, 2);
                        vHour = Math.Round(vDay / data_this.WorkHours.Value, 2);
                        break;
                    case 1:
                        if (data_this.HousingAllowance.Value > 0.0)
                        {
                            vDay = Math.Round((data_this.HousingAllowance.Value / 12.0 + data_this.MainSal.Value) / (double)data_this.DayOfMonth.Value, 2);
                            vHour = Math.Round(vDay / data_this.WorkHours.Value, 2);
                        }
                        else
                        {
                            vDay = Math.Round(data_this.MainSal.Value / (double)data_this.DayOfMonth.Value, 2);
                            vHour = Math.Round(vDay / data_this.WorkHours.Value, 2);
                        }
                        break;
                    case 2:
                        if (data_this.HousingAllowance.Value > 0.0)
                        {
                            vDay = data_this.HousingAllowance.Value / 12.0;
                        }
                        vDay += data_this.MainSal.Value;
                        vDay = vDay + data_this.TransferAllowance.Value + data_this.SubsistenceAllowance.Value + data_this.NaturalWorkAllowance.Value + data_this.OtherAllowance.Value;
                        vDay = Math.Round(vDay / (double)data_this.DayOfMonth.Value, 2);
                        vHour = Math.Round(vDay / data_this.WorkHours.Value, 2);
                        break;
                    case 3:
                        if (data_this.HousingAllowance.Value > 0.0)
                        {
                            vDay = data_this.HousingAllowance.Value / 12.0;
                        }
                        vDay += data_this.MainSal.Value;
                        vDay += data_this.TransferAllowance.Value;
                        vDay = Math.Round(vDay / (double)data_this.DayOfMonth.Value, 2);
                        vHour = Math.Round(vDay / data_this.WorkHours.Value, 2);
                        break;
                    case 4:
                        vDay = data_this.MainSal.Value;
                        vDay += data_this.SubsistenceAllowance.Value;
                        vDay = Math.Round(vDay / (double)data_this.DayOfMonth.Value, 2);
                        vHour = Math.Round(vDay / data_this.WorkHours.Value, 2);
                        break;
                    case 5:
                        vDay = data_this.MainSal.Value;
                        vDay += data_this.TransferAllowance.Value;
                        vDay = Math.Round(vDay / (double)data_this.DayOfMonth.Value, 2);
                        vHour = Math.Round(vDay / data_this.WorkHours.Value, 2);
                        break;
                }
                data_this.AddHours = Math.Round(vHour, 2);
                data_this.LateHours = Math.Round(vHour, 2);
                data_this.AddDay = Math.Round(vDay, 2);
                data_this.DisOneDay = Math.Round(vDay, 2);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("CalcAddSub:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void comboBox_CalculateTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_CalculateTyp.SelectedIndex == 0)
            {
                label18.Text = ((LangArEn == 0) ? "مقدار الزيادة" : "Increase Value :");
                label19.Text = ((LangArEn == 0) ? "الزيادة على :" : "Increase To :");
            }
            else
            {
                label18.Text = ((LangArEn == 0) ? "مقدار النقص :" : "Decrease Value :");
                label19.Text = ((LangArEn == 0) ? "الإنقاص من :" : "Decrease To :");
            }
        }
        private void Button_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                double vValue = 0.0;
                if (textBox_Value.Value == 0.0)
                {
                    MessageBox.Show((LangArEn == 0) ? "قيمة غير منطقية " : "The value of non-logical", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    textBox_Value.Focus();
                    return;
                }
                if (dateTimeInput_warnDate.Text.Length != 10)
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب تحديد تاريخ العملية " : "You must specify the date", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    dateTimeInput_warnDate.Focus();
                    return;
                }
                string tmpStr = "";
                string QStr = "";
                string[] GetSql = getDeptNo();
                for (int num2 = 0; num2 < GetSql.Length; num2++)
                {
                    if (!string.IsNullOrEmpty(GetSql[num2]))
                    {
                        tmpStr = ((!string.IsNullOrEmpty(tmpStr)) ? (tmpStr + " OR ") : (tmpStr + " AND ( "));
                        tmpStr = tmpStr + " ( Dept = " + GetSql[num2].Trim() + " ) ";
                    }
                }
                QStr += ((tmpStr != "") ? (tmpStr + " )") : "");
                tmpStr = "";
                GetSql = getEmpNo();
                for (int num2 = 0; num2 < GetSql.Length; num2++)
                {
                    if (!string.IsNullOrEmpty(GetSql[num2]))
                    {
                        tmpStr = ((!string.IsNullOrEmpty(tmpStr)) ? (tmpStr + " OR ") : (tmpStr + " AND ( "));
                        tmpStr = tmpStr + " ( Emp_ID = '" + GetSql[num2].Trim() + "' ) ";
                    }
                }
                QStr += ((tmpStr != "") ? (tmpStr + " )") : "");
                tmpStr = "";
                GetSql = getJobNo();
                for (int num2 = 0; num2 < GetSql.Length; num2++)
                {
                    if (!string.IsNullOrEmpty(GetSql[num2]))
                    {
                        tmpStr = ((!string.IsNullOrEmpty(tmpStr)) ? (tmpStr + " OR ") : (tmpStr + " AND ( "));
                        tmpStr = tmpStr + " ( Job = " + GetSql[num2].Trim() + " ) ";
                    }
                }
                QStr += ((tmpStr != "") ? (tmpStr + " )") : "");
                tmpStr = "";
                GetSql = getSectionNo();
                for (int num2 = 0; num2 < GetSql.Length; num2++)
                {
                    if (!string.IsNullOrEmpty(GetSql[num2]))
                    {
                        tmpStr = ((!string.IsNullOrEmpty(tmpStr)) ? (tmpStr + " OR ") : (tmpStr + " AND ( "));
                        tmpStr = tmpStr + " ( Section = " + GetSql[num2].Trim() + " ) ";
                    }
                }
                QStr += ((tmpStr != "") ? (tmpStr + " )") : "");
                tmpStr = "";
                string query = "SELECT * FROM [dbo].[T_Emp] as [t0] WHERE EmpState = " + 1 + QStr + " ORDER BY [Emp_No]";
                List<T_Emp> newData = db.ExecuteQuery<T_Emp>(query, new object[0]).ToList();
                if (newData.Count == 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    if (MessageBox.Show(comboBox_CalculateTyp.Text + " " + comboBox_Allowances.Text.ToUpper() + " \n " + label18.Text + "  ( " + textBox_Value.Text + " " + comboBox_CalculatliquidNo.Text + " )   لعدد : " + newData.Count + " موظف\nهل تريد الاستمرار", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    for (int i = 0; i < newData.Count; i++)
                    {
                        switch (comboBox_Allowances.SelectedIndex)
                        {
                            case 0:
                                vValue = newData[i].MainSal.Value;
                                break;
                            case 1:
                                vValue = newData[i].HousingAllowance.Value;
                                break;
                            case 2:
                                vValue = newData[i].TransferAllowance.Value;
                                break;
                            case 3:
                                vValue = newData[i].SubsistenceAllowance.Value;
                                break;
                            case 4:
                                vValue = newData[i].NaturalWorkAllowance.Value;
                                break;
                            case 5:
                                vValue = newData[i].OtherAllowance.Value;
                                break;
                        }
                        GetDataOpSalary(vValue, newData[i]);
                        if (comboBox_CalculatliquidNo.SelectedIndex == 0)
                        {
                            if (comboBox_CalculateTyp.SelectedIndex == 0)
                            {
                                vValue += vValue / 100.0 * textBox_Value.Value;
                            }
                            else if (vValue > 0.0)
                            {
                                vValue -= vValue / 100.0 * textBox_Value.Value;
                            }
                        }
                        else if (comboBox_CalculateTyp.SelectedIndex == 0)
                        {
                            vValue += textBox_Value.Value;
                        }
                        else if (vValue > 0.0)
                        {
                            vValue -= textBox_Value.Value;
                        }
                        data_this = new T_Emp();
                        data_this = newData[i];
                        GetData(vValue);
                        CalcAddSub();
                        db.Log = VarGeneral.DebugLog;
                        db.SubmitChanges(ConflictMode.ContinueOnConflict);
                        try
                        {
                            data_this_SalaryOp.ValueAfter = vValue;
                            db.T_SalaryOps.InsertOnSubmit(data_this_SalaryOp);
                            db.SubmitChanges();
                        }
                        catch (SqlException error2)
                        {
                            if (error2.Number == 2627)
                            {
                                data_this_SalaryOp.warnNo = db.MaxOpSalaryEmpNo;
                                db.T_SalaryOps.InsertOnSubmit(data_this_SalaryOp);
                                db.SubmitChanges();
                            }
                            else
                            {
                                VarGeneral.DebLog.writeLog("Button_Ok_Click:", error2, enable: true);
                                MessageBox.Show(error2.Message);
                            }
                            return;
                        }
                    }
                    MessageBox.Show((LangArEn == 0) ? "تم اتمام العملية بنجاح " : "The completion of the process has been successfully", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    dbInstance = null;
                    Clear();
                    return;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FrmSpin_Button_Ok_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void GetDataOpSalary(double vValue, T_Emp newData)
        {
            data_this_SalaryOp = new T_SalaryOp();
            data_this_SalaryOp.ValueBefor = vValue;
            data_this_SalaryOp.warnNo = db.MaxOpSalaryEmpNo;
            data_this_SalaryOp.Note = "";
            data_this_SalaryOp.opMethod = comboBox_CalculatliquidNo.SelectedIndex;
            data_this_SalaryOp.opTyp = comboBox_CalculateTyp.SelectedIndex;
            data_this_SalaryOp.opCalc = int.Parse(comboBox_CalculateNo.SelectedValue.ToString());
            data_this_SalaryOp.AddTo = int.Parse(comboBox_Allowances.SelectedValue.ToString());
            data_this_SalaryOp.AddValue = textBox_Value.Value;
            data_this_SalaryOp.EmpID = newData.Emp_ID;
            try
            {
                data_this_SalaryOp.warnDate = Convert.ToDateTime(dateTimeInput_warnDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_warnDate.Text = "";
                data_this_SalaryOp.warnDate = "";
            }
            Guid id = Guid.NewGuid();
            data_this_SalaryOp.SalaryOp_ID = id.ToString();
            data_this_SalaryOp.Usr_No = VarGeneral.UserID;
            data_this_SalaryOp.Usr_NoEdite = null;
            data_this_SalaryOp.DateEdit = "";
        }
        private void dateTimeInput_warnDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(dateTimeInput_warnDate.Text))
                {
                    dateTimeInput_warnDate.Text = Convert.ToDateTime(dateTimeInput_warnDate.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_warnDate.Text = "";
                }
            }
            catch
            {
                dateTimeInput_warnDate.Text = "";
            }
        }
        private void dateTimeInput_warnDate_Click(object sender, EventArgs e)
        {
            dateTimeInput_warnDate.SelectAll();
        }
        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void FrmSpin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void FrmSpin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && Button_Ok.Enabled && Button_Ok.Visible)
            {
                Button_Ok_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
