using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.Editors;
using DevComponents.Editors.DateTimeAdv;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
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
    public partial class FrmSpin : Form
    {
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
        private IContainer components = null;
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
            InitializeComponent();
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
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmSpin));
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background2 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background3 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background4 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn10 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn11 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn12 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background5 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background6 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background7 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background8 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            panel1 = new System.Windows.Forms.Panel();
            expandablePanel_Girds = new DevComponents.DotNetBar.ExpandablePanel();
            expandablePanel_Emp = new DevComponents.DotNetBar.ExpandablePanel();
            itemPanel4 = new DevComponents.DotNetBar.ItemPanel();
            dataGridViewX_Emp = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            expandablePanel_Job = new DevComponents.DotNetBar.ExpandablePanel();
            itemPanel3 = new DevComponents.DotNetBar.ItemPanel();
            dataGridViewX_Job = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            expandablePanel_Section = new DevComponents.DotNetBar.ExpandablePanel();
            itemPanel2 = new DevComponents.DotNetBar.ItemPanel();
            dataGridViewX_Section = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            expandablePanel_Dept = new DevComponents.DotNetBar.ExpandablePanel();
            itemPanel1 = new DevComponents.DotNetBar.ItemPanel();
            dataGridViewX_Dept = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            ButExit = new DevComponents.DotNetBar.ButtonX();
            Button_Ok = new DevComponents.DotNetBar.ButtonX();
            groupBox_Date = new System.Windows.Forms.GroupBox();
            label18 = new System.Windows.Forms.Label();
            dateTimeInput_warnDate = new System.Windows.Forms.MaskedTextBox();
            label54 = new System.Windows.Forms.Label();
            comboBox_CalculatliquidNo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            label2 = new System.Windows.Forms.Label();
            comboBox_CalculateTyp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            groupBox1 = new System.Windows.Forms.GroupBox();
            comboBox_CalculateNo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            label1 = new System.Windows.Forms.Label();
            textBox_Value = new DevComponents.Editors.DoubleInput();
            label70 = new System.Windows.Forms.Label();
            comboBox_Allowances = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            label19 = new System.Windows.Forms.Label();
            ribbonBar1.SuspendLayout();
            panel1.SuspendLayout();
            expandablePanel_Girds.SuspendLayout();
            expandablePanel_Emp.SuspendLayout();
            itemPanel4.SuspendLayout();
            expandablePanel_Job.SuspendLayout();
            itemPanel3.SuspendLayout();
            expandablePanel_Section.SuspendLayout();
            itemPanel2.SuspendLayout();
            expandablePanel_Dept.SuspendLayout();
            itemPanel1.SuspendLayout();
            groupBox_Date.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)textBox_Value).BeginInit();
            SuspendLayout();
            ribbonBar1.AutoOverflowEnabled = true;
            ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.ContainerControlProcessDialogKey = true;
            ribbonBar1.Controls.Add(panel1);
            resources.ApplyResources(ribbonBar1, "ribbonBar1");
            ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            ribbonBar1.Name = "ribbonBar1";
            ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.FromArgb(227, 239, 255);
            ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(101, 147, 207);
            ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            panel1.BackColor = System.Drawing.Color.Transparent;
            panel1.Controls.Add(expandablePanel_Girds);
            panel1.Controls.Add(ButExit);
            panel1.Controls.Add(Button_Ok);
            panel1.Controls.Add(groupBox_Date);
            panel1.Controls.Add(groupBox1);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            expandablePanel_Girds.CanvasColor = System.Drawing.SystemColors.Control;
            expandablePanel_Girds.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft;
            expandablePanel_Girds.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            expandablePanel_Girds.Controls.Add(expandablePanel_Emp);
            expandablePanel_Girds.Controls.Add(expandablePanel_Job);
            expandablePanel_Girds.Controls.Add(expandablePanel_Section);
            expandablePanel_Girds.Controls.Add(expandablePanel_Dept);
            resources.ApplyResources(expandablePanel_Girds, "expandablePanel_Girds");
            expandablePanel_Girds.Expanded = false;
            expandablePanel_Girds.ExpandedBounds = new System.Drawing.Rectangle(0, 0, 314, 283);
            expandablePanel_Girds.Name = "expandablePanel_Girds";
            expandablePanel_Girds.Style.Alignment = System.Drawing.StringAlignment.Center;
            expandablePanel_Girds.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            expandablePanel_Girds.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            expandablePanel_Girds.Style.GradientAngle = 90;
            expandablePanel_Girds.TitleStyle.Alignment = System.Drawing.StringAlignment.Far;
            expandablePanel_Girds.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            expandablePanel_Girds.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            expandablePanel_Girds.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            expandablePanel_Girds.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            expandablePanel_Girds.TitleStyle.GradientAngle = 90;
            expandablePanel_Girds.TitleStyle.MarginLeft = 6;
            expandablePanel_Girds.ExpandedChanged += new DevComponents.DotNetBar.ExpandChangeEventHandler(expandablePanel_Girds_ExpandedChanged);
            expandablePanel_Girds.ExpandedChanging += new DevComponents.DotNetBar.ExpandChangeEventHandler(expandablePanel_Girds_ExpandedChanging);
            expandablePanel_Emp.CanvasColor = System.Drawing.SystemColors.Control;
            expandablePanel_Emp.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            expandablePanel_Emp.Controls.Add(itemPanel4);
            resources.ApplyResources(expandablePanel_Emp, "expandablePanel_Emp");
            expandablePanel_Emp.Expanded = false;
            expandablePanel_Emp.ExpandedBounds = new System.Drawing.Rectangle(0, 104, 314, 179);
            expandablePanel_Emp.ExpandOnTitleClick = true;
            expandablePanel_Emp.Name = "expandablePanel_Emp";
            expandablePanel_Emp.Style.Alignment = System.Drawing.StringAlignment.Center;
            expandablePanel_Emp.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            expandablePanel_Emp.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            expandablePanel_Emp.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            expandablePanel_Emp.Style.GradientAngle = 90;
            expandablePanel_Emp.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            expandablePanel_Emp.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            expandablePanel_Emp.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            expandablePanel_Emp.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            expandablePanel_Emp.TitleStyle.GradientAngle = 90;
            expandablePanel_Emp.TitleStyle.MarginLeft = 12;
            itemPanel4.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            itemPanel4.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemPanel4.BackgroundStyle.BorderBottomWidth = 1;
            itemPanel4.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(127, 157, 185);
            itemPanel4.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemPanel4.BackgroundStyle.BorderLeftWidth = 1;
            itemPanel4.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemPanel4.BackgroundStyle.BorderRightWidth = 1;
            itemPanel4.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemPanel4.BackgroundStyle.BorderTopWidth = 1;
            itemPanel4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            itemPanel4.BackgroundStyle.PaddingBottom = 1;
            itemPanel4.BackgroundStyle.PaddingLeft = 1;
            itemPanel4.BackgroundStyle.PaddingRight = 1;
            itemPanel4.BackgroundStyle.PaddingTop = 1;
            itemPanel4.ContainerControlProcessDialogKey = true;
            itemPanel4.Controls.Add(dataGridViewX_Emp);
            resources.ApplyResources(itemPanel4, "itemPanel4");
            itemPanel4.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            itemPanel4.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            itemPanel4.Name = "itemPanel4";
            dataGridViewX_Emp.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(dataGridViewX_Emp, "dataGridViewX_Emp");
            dataGridViewX_Emp.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            dataGridViewX_Emp.ForeColor = System.Drawing.Color.Black;
            dataGridViewX_Emp.HScrollBarVisible = false;
            dataGridViewX_Emp.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            dataGridViewX_Emp.Name = "dataGridViewX_Emp";
            dataGridViewX_Emp.PrimaryGrid.AllowRowHeaderResize = true;
            dataGridViewX_Emp.PrimaryGrid.AllowRowResize = true;
            dataGridViewX_Emp.PrimaryGrid.ColumnHeader.RowHeight = 30;
            dataGridViewX_Emp.PrimaryGrid.ColumnHeader.SortImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_Emp.PrimaryGrid.ColumnHeader.Visible = false;
            gridColumn1.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn1.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.None;
            gridColumn1.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn1.Name = "*";
            gridColumn1.Width = 50;
            gridColumn5.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn5.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn5.FilterAutoScan = true;
            gridColumn5.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn5.InfoImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn5.Name = "رقم / إسم الإدارة";
            gridColumn5.ReadOnly = true;
            gridColumn5.Width = 263;
            gridColumn6.ReadOnly = true;
            gridColumn6.Visible = false;
            dataGridViewX_Emp.PrimaryGrid.Columns.Add(gridColumn1);
            dataGridViewX_Emp.PrimaryGrid.Columns.Add(gridColumn5);
            dataGridViewX_Emp.PrimaryGrid.Columns.Add(gridColumn6);
            dataGridViewX_Emp.PrimaryGrid.DefaultRowHeight = 24;
            background1.Color1 = System.Drawing.Color.White;
            background1.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            dataGridViewX_Emp.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = background1;
            background2.Color1 = System.Drawing.Color.White;
            background2.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            dataGridViewX_Emp.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background2;
            dataGridViewX_Emp.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_Emp.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_Emp.PrimaryGrid.EnableColumnFiltering = true;
            dataGridViewX_Emp.PrimaryGrid.EnableFiltering = true;
            dataGridViewX_Emp.PrimaryGrid.EnableRowFiltering = true;
            dataGridViewX_Emp.PrimaryGrid.Filter.Visible = true;
            dataGridViewX_Emp.PrimaryGrid.FilterLevel = DevComponents.DotNetBar.SuperGrid.FilterLevel.All;
            dataGridViewX_Emp.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            dataGridViewX_Emp.PrimaryGrid.MultiSelect = false;
            dataGridViewX_Emp.PrimaryGrid.NullString = "-----";
            dataGridViewX_Emp.PrimaryGrid.RowHeaderWidth = 45;
            dataGridViewX_Emp.PrimaryGrid.ShowColumnHeader = false;
            dataGridViewX_Emp.PrimaryGrid.ShowRowGridIndex = true;
            dataGridViewX_Emp.PrimaryGrid.ShowRowHeaders = false;
            dataGridViewX_Emp.PrimaryGrid.UseAlternateRowStyle = true;
            expandablePanel_Job.CanvasColor = System.Drawing.SystemColors.Control;
            expandablePanel_Job.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            expandablePanel_Job.Controls.Add(itemPanel3);
            resources.ApplyResources(expandablePanel_Job, "expandablePanel_Job");
            expandablePanel_Job.Expanded = false;
            expandablePanel_Job.ExpandedBounds = new System.Drawing.Rectangle(0, 78, 314, 179);
            expandablePanel_Job.ExpandOnTitleClick = true;
            expandablePanel_Job.Name = "expandablePanel_Job";
            expandablePanel_Job.Style.Alignment = System.Drawing.StringAlignment.Center;
            expandablePanel_Job.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            expandablePanel_Job.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            expandablePanel_Job.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            expandablePanel_Job.Style.GradientAngle = 90;
            expandablePanel_Job.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            expandablePanel_Job.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            expandablePanel_Job.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            expandablePanel_Job.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            expandablePanel_Job.TitleStyle.GradientAngle = 90;
            expandablePanel_Job.TitleStyle.MarginLeft = 12;
            itemPanel3.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            itemPanel3.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemPanel3.BackgroundStyle.BorderBottomWidth = 1;
            itemPanel3.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(127, 157, 185);
            itemPanel3.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemPanel3.BackgroundStyle.BorderLeftWidth = 1;
            itemPanel3.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemPanel3.BackgroundStyle.BorderRightWidth = 1;
            itemPanel3.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemPanel3.BackgroundStyle.BorderTopWidth = 1;
            itemPanel3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            itemPanel3.BackgroundStyle.PaddingBottom = 1;
            itemPanel3.BackgroundStyle.PaddingLeft = 1;
            itemPanel3.BackgroundStyle.PaddingRight = 1;
            itemPanel3.BackgroundStyle.PaddingTop = 1;
            itemPanel3.ContainerControlProcessDialogKey = true;
            itemPanel3.Controls.Add(dataGridViewX_Job);
            resources.ApplyResources(itemPanel3, "itemPanel3");
            itemPanel3.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            itemPanel3.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            itemPanel3.Name = "itemPanel3";
            dataGridViewX_Job.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(dataGridViewX_Job, "dataGridViewX_Job");
            dataGridViewX_Job.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            dataGridViewX_Job.ForeColor = System.Drawing.Color.Black;
            dataGridViewX_Job.HScrollBarVisible = false;
            dataGridViewX_Job.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            dataGridViewX_Job.Name = "dataGridViewX_Job";
            dataGridViewX_Job.PrimaryGrid.AllowRowHeaderResize = true;
            dataGridViewX_Job.PrimaryGrid.AllowRowResize = true;
            dataGridViewX_Job.PrimaryGrid.ColumnHeader.RowHeight = 30;
            dataGridViewX_Job.PrimaryGrid.ColumnHeader.SortImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_Job.PrimaryGrid.ColumnHeader.Visible = false;
            gridColumn7.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn7.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn7.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.None;
            gridColumn7.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn7.Name = "*";
            gridColumn7.Width = 50;
            gridColumn8.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn8.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn8.FilterAutoScan = true;
            gridColumn8.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn8.InfoImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn8.Name = "رقم / إسم الإدارة";
            gridColumn8.ReadOnly = true;
            gridColumn8.Width = 263;
            gridColumn9.ReadOnly = true;
            gridColumn9.Visible = false;
            dataGridViewX_Job.PrimaryGrid.Columns.Add(gridColumn7);
            dataGridViewX_Job.PrimaryGrid.Columns.Add(gridColumn8);
            dataGridViewX_Job.PrimaryGrid.Columns.Add(gridColumn9);
            dataGridViewX_Job.PrimaryGrid.DefaultRowHeight = 24;
            background3.Color1 = System.Drawing.Color.White;
            background3.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            dataGridViewX_Job.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = background3;
            background4.Color1 = System.Drawing.Color.White;
            background4.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            dataGridViewX_Job.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background4;
            dataGridViewX_Job.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_Job.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_Job.PrimaryGrid.EnableColumnFiltering = true;
            dataGridViewX_Job.PrimaryGrid.EnableFiltering = true;
            dataGridViewX_Job.PrimaryGrid.EnableRowFiltering = true;
            dataGridViewX_Job.PrimaryGrid.Filter.Visible = true;
            dataGridViewX_Job.PrimaryGrid.FilterLevel = DevComponents.DotNetBar.SuperGrid.FilterLevel.All;
            dataGridViewX_Job.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            dataGridViewX_Job.PrimaryGrid.MultiSelect = false;
            dataGridViewX_Job.PrimaryGrid.NullString = "-----";
            dataGridViewX_Job.PrimaryGrid.RowHeaderWidth = 45;
            dataGridViewX_Job.PrimaryGrid.ShowColumnHeader = false;
            dataGridViewX_Job.PrimaryGrid.ShowRowGridIndex = true;
            dataGridViewX_Job.PrimaryGrid.ShowRowHeaders = false;
            dataGridViewX_Job.PrimaryGrid.UseAlternateRowStyle = true;
            expandablePanel_Section.CanvasColor = System.Drawing.SystemColors.Control;
            expandablePanel_Section.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            expandablePanel_Section.Controls.Add(itemPanel2);
            resources.ApplyResources(expandablePanel_Section, "expandablePanel_Section");
            expandablePanel_Section.Expanded = false;
            expandablePanel_Section.ExpandedBounds = new System.Drawing.Rectangle(0, 52, 314, 179);
            expandablePanel_Section.ExpandOnTitleClick = true;
            expandablePanel_Section.Name = "expandablePanel_Section";
            expandablePanel_Section.Style.Alignment = System.Drawing.StringAlignment.Center;
            expandablePanel_Section.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            expandablePanel_Section.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            expandablePanel_Section.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            expandablePanel_Section.Style.GradientAngle = 90;
            expandablePanel_Section.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            expandablePanel_Section.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            expandablePanel_Section.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            expandablePanel_Section.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            expandablePanel_Section.TitleStyle.GradientAngle = 90;
            expandablePanel_Section.TitleStyle.MarginLeft = 12;
            itemPanel2.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            itemPanel2.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemPanel2.BackgroundStyle.BorderBottomWidth = 1;
            itemPanel2.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(127, 157, 185);
            itemPanel2.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemPanel2.BackgroundStyle.BorderLeftWidth = 1;
            itemPanel2.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemPanel2.BackgroundStyle.BorderRightWidth = 1;
            itemPanel2.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemPanel2.BackgroundStyle.BorderTopWidth = 1;
            itemPanel2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            itemPanel2.BackgroundStyle.PaddingBottom = 1;
            itemPanel2.BackgroundStyle.PaddingLeft = 1;
            itemPanel2.BackgroundStyle.PaddingRight = 1;
            itemPanel2.BackgroundStyle.PaddingTop = 1;
            itemPanel2.ContainerControlProcessDialogKey = true;
            itemPanel2.Controls.Add(dataGridViewX_Section);
            resources.ApplyResources(itemPanel2, "itemPanel2");
            itemPanel2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            itemPanel2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            itemPanel2.Name = "itemPanel2";
            dataGridViewX_Section.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(dataGridViewX_Section, "dataGridViewX_Section");
            dataGridViewX_Section.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            dataGridViewX_Section.ForeColor = System.Drawing.Color.Black;
            dataGridViewX_Section.HScrollBarVisible = false;
            dataGridViewX_Section.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            dataGridViewX_Section.Name = "dataGridViewX_Section";
            dataGridViewX_Section.PrimaryGrid.AllowRowHeaderResize = true;
            dataGridViewX_Section.PrimaryGrid.AllowRowResize = true;
            dataGridViewX_Section.PrimaryGrid.ColumnHeader.RowHeight = 30;
            dataGridViewX_Section.PrimaryGrid.ColumnHeader.SortImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_Section.PrimaryGrid.ColumnHeader.Visible = false;
            gridColumn10.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn10.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn10.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.None;
            gridColumn10.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn10.Name = "*";
            gridColumn10.Width = 50;
            gridColumn11.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn11.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn11.FilterAutoScan = true;
            gridColumn11.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn11.InfoImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn11.Name = "رقم / إسم الإدارة";
            gridColumn11.ReadOnly = true;
            gridColumn11.Width = 263;
            gridColumn12.ReadOnly = true;
            gridColumn12.Visible = false;
            dataGridViewX_Section.PrimaryGrid.Columns.Add(gridColumn10);
            dataGridViewX_Section.PrimaryGrid.Columns.Add(gridColumn11);
            dataGridViewX_Section.PrimaryGrid.Columns.Add(gridColumn12);
            dataGridViewX_Section.PrimaryGrid.DefaultRowHeight = 24;
            background5.Color1 = System.Drawing.Color.White;
            background5.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            dataGridViewX_Section.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = background5;
            background6.Color1 = System.Drawing.Color.White;
            background6.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            dataGridViewX_Section.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background6;
            dataGridViewX_Section.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_Section.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_Section.PrimaryGrid.EnableColumnFiltering = true;
            dataGridViewX_Section.PrimaryGrid.EnableFiltering = true;
            dataGridViewX_Section.PrimaryGrid.EnableRowFiltering = true;
            dataGridViewX_Section.PrimaryGrid.Filter.Visible = true;
            dataGridViewX_Section.PrimaryGrid.FilterLevel = DevComponents.DotNetBar.SuperGrid.FilterLevel.All;
            dataGridViewX_Section.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            dataGridViewX_Section.PrimaryGrid.MultiSelect = false;
            dataGridViewX_Section.PrimaryGrid.NullString = "-----";
            dataGridViewX_Section.PrimaryGrid.RowHeaderWidth = 45;
            dataGridViewX_Section.PrimaryGrid.ShowColumnHeader = false;
            dataGridViewX_Section.PrimaryGrid.ShowRowGridIndex = true;
            dataGridViewX_Section.PrimaryGrid.ShowRowHeaders = false;
            dataGridViewX_Section.PrimaryGrid.UseAlternateRowStyle = true;
            expandablePanel_Dept.CanvasColor = System.Drawing.SystemColors.Control;
            expandablePanel_Dept.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            expandablePanel_Dept.Controls.Add(itemPanel1);
            resources.ApplyResources(expandablePanel_Dept, "expandablePanel_Dept");
            expandablePanel_Dept.Expanded = false;
            expandablePanel_Dept.ExpandedBounds = new System.Drawing.Rectangle(0, 26, 314, 179);
            expandablePanel_Dept.ExpandOnTitleClick = true;
            expandablePanel_Dept.Name = "expandablePanel_Dept";
            expandablePanel_Dept.Style.Alignment = System.Drawing.StringAlignment.Center;
            expandablePanel_Dept.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            expandablePanel_Dept.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            expandablePanel_Dept.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            expandablePanel_Dept.Style.GradientAngle = 90;
            expandablePanel_Dept.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            expandablePanel_Dept.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            expandablePanel_Dept.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            expandablePanel_Dept.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            expandablePanel_Dept.TitleStyle.GradientAngle = 90;
            expandablePanel_Dept.TitleStyle.MarginLeft = 12;
            itemPanel1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            itemPanel1.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemPanel1.BackgroundStyle.BorderBottomWidth = 1;
            itemPanel1.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(127, 157, 185);
            itemPanel1.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemPanel1.BackgroundStyle.BorderLeftWidth = 1;
            itemPanel1.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemPanel1.BackgroundStyle.BorderRightWidth = 1;
            itemPanel1.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemPanel1.BackgroundStyle.BorderTopWidth = 1;
            itemPanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            itemPanel1.BackgroundStyle.PaddingBottom = 1;
            itemPanel1.BackgroundStyle.PaddingLeft = 1;
            itemPanel1.BackgroundStyle.PaddingRight = 1;
            itemPanel1.BackgroundStyle.PaddingTop = 1;
            itemPanel1.ContainerControlProcessDialogKey = true;
            itemPanel1.Controls.Add(dataGridViewX_Dept);
            resources.ApplyResources(itemPanel1, "itemPanel1");
            itemPanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            itemPanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            itemPanel1.Name = "itemPanel1";
            dataGridViewX_Dept.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(dataGridViewX_Dept, "dataGridViewX_Dept");
            dataGridViewX_Dept.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            dataGridViewX_Dept.ForeColor = System.Drawing.Color.Black;
            dataGridViewX_Dept.HScrollBarVisible = false;
            dataGridViewX_Dept.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            dataGridViewX_Dept.Name = "dataGridViewX_Dept";
            dataGridViewX_Dept.PrimaryGrid.AllowRowHeaderResize = true;
            dataGridViewX_Dept.PrimaryGrid.AllowRowResize = true;
            dataGridViewX_Dept.PrimaryGrid.ColumnHeader.RowHeight = 30;
            dataGridViewX_Dept.PrimaryGrid.ColumnHeader.SortImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_Dept.PrimaryGrid.ColumnHeader.Visible = false;
            gridColumn2.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn2.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn2.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.None;
            gridColumn2.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn2.Name = "*";
            gridColumn2.Width = 50;
            gridColumn3.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn3.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn3.FilterAutoScan = true;
            gridColumn3.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn3.InfoImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn3.Name = "رقم / إسم الإدارة";
            gridColumn3.ReadOnly = true;
            gridColumn3.Width = 263;
            gridColumn4.ReadOnly = true;
            gridColumn4.Visible = false;
            dataGridViewX_Dept.PrimaryGrid.Columns.Add(gridColumn2);
            dataGridViewX_Dept.PrimaryGrid.Columns.Add(gridColumn3);
            dataGridViewX_Dept.PrimaryGrid.Columns.Add(gridColumn4);
            dataGridViewX_Dept.PrimaryGrid.DefaultRowHeight = 24;
            background7.Color1 = System.Drawing.Color.White;
            background7.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            dataGridViewX_Dept.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = background7;
            background8.Color1 = System.Drawing.Color.White;
            background8.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            dataGridViewX_Dept.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background8;
            dataGridViewX_Dept.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_Dept.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_Dept.PrimaryGrid.EnableColumnFiltering = true;
            dataGridViewX_Dept.PrimaryGrid.EnableFiltering = true;
            dataGridViewX_Dept.PrimaryGrid.EnableRowFiltering = true;
            dataGridViewX_Dept.PrimaryGrid.Filter.Visible = true;
            dataGridViewX_Dept.PrimaryGrid.FilterLevel = DevComponents.DotNetBar.SuperGrid.FilterLevel.All;
            dataGridViewX_Dept.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            dataGridViewX_Dept.PrimaryGrid.MultiSelect = false;
            dataGridViewX_Dept.PrimaryGrid.NullString = "-----";
            dataGridViewX_Dept.PrimaryGrid.RowHeaderWidth = 45;
            dataGridViewX_Dept.PrimaryGrid.ShowColumnHeader = false;
            dataGridViewX_Dept.PrimaryGrid.ShowRowGridIndex = true;
            dataGridViewX_Dept.PrimaryGrid.ShowRowHeaders = false;
            dataGridViewX_Dept.PrimaryGrid.UseAlternateRowStyle = true;
            ButExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            ButExit.Checked = true;
            ButExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(ButExit, "ButExit");
            ButExit.Name = "ButExit";
            ButExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButExit.Symbol = "\uf011";
            ButExit.SymbolSize = 16f;
            ButExit.TextColor = System.Drawing.Color.Black;
            ButExit.Click += new System.EventHandler(Button_Cancel_Click);
            Button_Ok.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            Button_Ok.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            resources.ApplyResources(Button_Ok, "Button_Ok");
            Button_Ok.Name = "Button_Ok";
            Button_Ok.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            Button_Ok.Symbol = "\uf0c5";
            Button_Ok.SymbolSize = 16f;
            Button_Ok.TextColor = System.Drawing.Color.White;
            Button_Ok.Click += new System.EventHandler(Button_Ok_Click);
            groupBox_Date.BackColor = System.Drawing.Color.Transparent;
            groupBox_Date.Controls.Add(label18);
            groupBox_Date.Controls.Add(dateTimeInput_warnDate);
            groupBox_Date.Controls.Add(label54);
            groupBox_Date.Controls.Add(comboBox_CalculatliquidNo);
            groupBox_Date.Controls.Add(label2);
            groupBox_Date.Controls.Add(comboBox_CalculateTyp);
            resources.ApplyResources(groupBox_Date, "groupBox_Date");
            groupBox_Date.Name = "groupBox_Date";
            groupBox_Date.TabStop = false;
            resources.ApplyResources(label18, "label18");
            label18.Name = "label18";
            resources.ApplyResources(dateTimeInput_warnDate, "dateTimeInput_warnDate");
            dateTimeInput_warnDate.Name = "dateTimeInput_warnDate";
            dateTimeInput_warnDate.Leave += new System.EventHandler(dateTimeInput_warnDate_Leave);
            dateTimeInput_warnDate.Click += new System.EventHandler(dateTimeInput_warnDate_Click);
            resources.ApplyResources(label54, "label54");
            label54.BackColor = System.Drawing.Color.Transparent;
            label54.Name = "label54";
            comboBox_CalculatliquidNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            comboBox_CalculatliquidNo.DisplayMember = "Text";
            comboBox_CalculatliquidNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboBox_CalculatliquidNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_CalculatliquidNo.FormattingEnabled = true;
            resources.ApplyResources(comboBox_CalculatliquidNo, "comboBox_CalculatliquidNo");
            comboBox_CalculatliquidNo.Name = "comboBox_CalculatliquidNo";
            comboBox_CalculatliquidNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            comboBox_CalculateTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            comboBox_CalculateTyp.DisplayMember = "Text";
            comboBox_CalculateTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboBox_CalculateTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_CalculateTyp.FormattingEnabled = true;
            resources.ApplyResources(comboBox_CalculateTyp, "comboBox_CalculateTyp");
            comboBox_CalculateTyp.Name = "comboBox_CalculateTyp";
            comboBox_CalculateTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            comboBox_CalculateTyp.SelectedIndexChanged += new System.EventHandler(comboBox_CalculateTyp_SelectedIndexChanged);
            groupBox1.BackColor = System.Drawing.Color.Transparent;
            groupBox1.Controls.Add(comboBox_CalculateNo);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox_Value);
            groupBox1.Controls.Add(label70);
            groupBox1.Controls.Add(comboBox_Allowances);
            groupBox1.Controls.Add(label19);
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            comboBox_CalculateNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            comboBox_CalculateNo.DisplayMember = "Text";
            comboBox_CalculateNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboBox_CalculateNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_CalculateNo.FormattingEnabled = true;
            resources.ApplyResources(comboBox_CalculateNo, "comboBox_CalculateNo");
            comboBox_CalculateNo.Name = "comboBox_CalculateNo";
            comboBox_CalculateNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            textBox_Value.AllowEmptyState = false;
            textBox_Value.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 198);
            textBox_Value.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_Value.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_Value.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(textBox_Value, "textBox_Value");
            textBox_Value.Increment = 1.0;
            textBox_Value.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_Value.Name = "textBox_Value";
            resources.ApplyResources(label70, "label70");
            label70.BackColor = System.Drawing.Color.Transparent;
            label70.Name = "label70";
            comboBox_Allowances.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            comboBox_Allowances.DisplayMember = "Text";
            comboBox_Allowances.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboBox_Allowances.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_Allowances.FormattingEnabled = true;
            resources.ApplyResources(comboBox_Allowances, "comboBox_Allowances");
            comboBox_Allowances.Name = "comboBox_Allowances";
            comboBox_Allowances.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            resources.ApplyResources(label19, "label19");
            label19.Name = "label19";
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(ribbonBar1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.Name = "FrmSpin";
            base.Load += new System.EventHandler(FrmSpin_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(FrmSpin_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmSpin_KeyDown);
            ribbonBar1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            expandablePanel_Girds.ResumeLayout(false);
            expandablePanel_Emp.ResumeLayout(false);
            itemPanel4.ResumeLayout(false);
            expandablePanel_Job.ResumeLayout(false);
            itemPanel3.ResumeLayout(false);
            expandablePanel_Section.ResumeLayout(false);
            itemPanel2.ResumeLayout(false);
            expandablePanel_Dept.ResumeLayout(false);
            itemPanel1.ResumeLayout(false);
            groupBox_Date.ResumeLayout(false);
            groupBox_Date.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)textBox_Value).EndInit();
            ResumeLayout(false);
        }
    }
}
