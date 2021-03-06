using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using Framework.Data;
using Framework.UI;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
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
    public partial class FrmOpenRelaySalaries : Form
    {
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
        private IContainer components = null;
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
            InitializeComponent();
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                Button_OK.Text = "?????????? ??????????????";
                button_Close.Text = "??????????????";
                comboBox_Month.WatermarkText = "???? ???????? ?????????? ????\u0651??????";
                Text = "???????????????? ?????????????? ?????????????? ??????????";
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
                        MessageBox.Show((LangArEn == 0) ? " ?????????? ?????? ?????????? ?????? ??????????" : "Salaries this Month not Carryover", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        Button_OK.Enabled = true;
                        button_Close.Enabled = true;
                        return;
                    }
                    if (MessageBox.Show((LangArEn == 0) ? ("???? ???????? ?????? ???????? ?????? : [" + Convert.ToDateTime(vDate).ToString("yyyy/MM") + "]") : ("Do you want to delete Messier month : [" + Convert.ToDateTime(vDate).ToString("yyyy/MM") + "]"), VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        goto IL_0626;
                    }
                    if (newdata2.FirstOrDefault().GadeId.HasValue && MessageBox.Show((LangArEn == 0) ? " ?????? ???? ?????????? ?????? ???????????? ??????????\u064c ???????????? ?????? ??????????  \n ?????????? ?????? ?????? ?????????? ???? ???????? ???????????????? ??" : "Will filter all advances and holidays between the dates specified \n Are you sure you want to Carryover the data?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
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
                                    MessageBox.Show((LangArEn == 0) ? "?????? ?????? ?????????? ???????????? ?????????? ?????????? ?????????? ?????????? .. " : "An error occurred while trying to decipher the deportation ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    Button_OK.Enabled = true;
                                    button_Close.Enabled = true;
                                    return;
                                }
                            }
                        }
                        catch
                        {
                            MessageBox.Show((LangArEn == 0) ? "?????? ?????? ?????????? ???????????? ?????????? ?????????? ?????????? ?????????? .. " : "An error occurred while trying to decipher the deportation ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                    MessageBox.Show((LangArEn == 0) ? ("?????? ?????????? ?????????? ?????????? ?????????? ?????????? ?????????? : [" + Convert.ToDateTime(vDate).ToString("yyyy/MM") + "]") : ("Will be Undo Carryover of month : [" + Convert.ToDateTime(vDate).ToString("yyyy/MM") + "]"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                    MessageBox.Show((LangArEn == 0) ? " ?????????? ?????? ?????????? ?????? ??????????" : "Salaries this Month not Carryover", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Button_OK.Enabled = true;
                    button_Close.Enabled = true;
                    return;
                }
                if (MessageBox.Show((LangArEn == 0) ? ("???? ???????? ?????? ???????? ?????? : " + Convert.ToDateTime(vDate).ToString("yyyy/MM")) : ("Do you want to delete Messier month : " + Convert.ToDateTime(vDate).ToString("yyyy/MM")), VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    goto IL_0beb;
                }
                if (newdata.FirstOrDefault().GadeId.HasValue && MessageBox.Show((LangArEn == 0) ? " ?????? ???? ?????????? ?????? ???????????? ??????????\u064c ???????????? ?????? ??????????  \n ?????????? ?????? ?????? ?????????? ???? ???????? ???????????????? ??" : "Will filter all advances and holidays between the dates specified \n Are you sure you want to Carryover the data?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
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
                                MessageBox.Show((LangArEn == 0) ? "?????? ?????? ?????????? ???????????? ?????????? ?????????? ?????????? ?????????? .. " : "An error occurred while trying to decipher the deportation ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                Button_OK.Enabled = true;
                                button_Close.Enabled = true;
                                return;
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show((LangArEn == 0) ? "?????? ?????? ?????????? ???????????? ?????????? ?????????? ?????????? ?????????? .. " : "An error occurred while trying to decipher the deportation ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                MessageBox.Show((LangArEn == 0) ? "?????? ?????????? ?????????? ?????????? ?????????????? ????????" : "The process has been successfully", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                columns_Names_visible2.Add("Date", new ColumnDictinary("?????????????? ", " Date", ifDefault: true, ""));
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOpenRelaySalaries));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button_SrchMonth = new DevComponents.DotNetBar.ButtonX();
            this.comboBox_Month = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.button_Close = new DevComponents.DotNetBar.ButtonX();
            this.Button_OK = new DevComponents.DotNetBar.ButtonX();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_DayOfMonth = new DevComponents.Editors.IntegerInput();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.panel1.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_DayOfMonth)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelSpecialContainer
            // 
            this.PanelSpecialContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelSpecialContainer.Name = "PanelSpecialContainer";
            this.PanelSpecialContainer.Size = new System.Drawing.Size(200, 100);
            this.PanelSpecialContainer.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(263, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 70;
            this.label1.Text = "???????????????????? :";
            // 
            // button_SrchMonth
            // 
            this.button_SrchMonth.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchMonth.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchMonth.Location = new System.Drawing.Point(56, 42);
            this.button_SrchMonth.Name = "button_SrchMonth";
            this.button_SrchMonth.Size = new System.Drawing.Size(26, 20);
            this.button_SrchMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchMonth.Symbol = "???";
            this.button_SrchMonth.SymbolSize = 12F;
            this.button_SrchMonth.TabIndex = 1587;
            this.button_SrchMonth.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchMonth.Click += new System.EventHandler(this.button_SrchMonth_Click);
            // 
            // comboBox_Month
            // 
            this.comboBox_Month.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Month.DisplayMember = "Text";
            this.comboBox_Month.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_Month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Month.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.comboBox_Month.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboBox_Month.FormattingEnabled = true;
            this.comboBox_Month.ItemHeight = 14;
            this.comboBox_Month.Location = new System.Drawing.Point(84, 42);
            this.comboBox_Month.Name = "comboBox_Month";
            this.comboBox_Month.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBox_Month.Size = new System.Drawing.Size(173, 20);
            this.comboBox_Month.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_Month.TabIndex = 1584;
            this.comboBox_Month.WatermarkText = "???? ???????? ?????????? ????????????";
            // 
            // button_Close
            // 
            this.button_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_Close.Checked = true;
            this.button_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_Close.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button_Close.Location = new System.Drawing.Point(11, 106);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(208, 37);
            this.button_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_Close.Symbol = "???";
            this.button_Close.SymbolSize = 16F;
            this.button_Close.TabIndex = 19;
            this.button_Close.Text = "??????????????";
            this.button_Close.TextColor = System.Drawing.Color.Black;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // Button_OK
            // 
            this.Button_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Button_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.Button_OK.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Button_OK.Location = new System.Drawing.Point(223, 106);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(208, 37);
            this.Button_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Button_OK.Symbol = "???";
            this.Button_OK.SymbolSize = 16F;
            this.Button_OK.TabIndex = 18;
            this.Button_OK.Text = "?????????? ??????????????";
            this.Button_OK.TextColor = System.Drawing.Color.White;
            this.Button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // netResize1
            // 
            this.netResize1.ParentControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.button_Close);
            this.panel1.Controls.Add(this.Button_OK);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(442, 154);
            this.panel1.TabIndex = 1104;
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.panel1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(442, 171);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 1103;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(114, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 69;
            this.label3.Text = "?????? ???????????? :";
            // 
            // textBox_DayOfMonth
            // 
            this.textBox_DayOfMonth.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_DayOfMonth.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_DayOfMonth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_DayOfMonth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_DayOfMonth.Enabled = false;
            this.textBox_DayOfMonth.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_DayOfMonth.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_DayOfMonth.Location = new System.Drawing.Point(13, 169);
            this.textBox_DayOfMonth.MaxValue = 31;
            this.textBox_DayOfMonth.MinValue = 1;
            this.textBox_DayOfMonth.Name = "textBox_DayOfMonth";
            this.textBox_DayOfMonth.Size = new System.Drawing.Size(95, 20);
            this.textBox_DayOfMonth.TabIndex = 5;
            this.textBox_DayOfMonth.Value = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_SrchMonth);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_DayOfMonth);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox_Month);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(11, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 88);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // FrmOpenRelaySalaries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 171);
            this.Controls.Add(this.ribbonBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmOpenRelaySalaries";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "?????????? ?????????? ?????????? ??????";
            this.Load += new System.EventHandler(this.FrmOpenRelaySalaries_Load);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmOpenRelaySalaries_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmOpenRelaySalaries_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textBox_DayOfMonth)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
