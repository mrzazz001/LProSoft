using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmAutoAlarm : Form
    { void avs(int arln)

{ 
 tabControl1.Text=   (arln == 0 ? "  tabControl1  " : "  tabControl1") ; tabControl2.Text=   (arln == 0 ? "  tabControl2  " : "  tabControl2") ; tabItem_ID.Text=   (arln == 0 ? "  الهويات  " : "  identities") ; tabItem_Passport.Text=   (arln == 0 ? "  حوازات السفر  " : "  travel passports") ; tabItem_EmpAllownce.Text=   (arln == 0 ? "  التأمينات الصحية  " : "  health insurance") ; tabItem_EmpForms.Text=   (arln == 0 ? "  إستمارات السيارات  " : "  car forms") ; tabItem_License.Text=   (arln == 0 ? "  رخص القيادة  " : "  Driving licenses") ; tabItem_EmployeeDoc.Text=   (arln == 0 ? "  وثائق الموظفين  " : "  Personnel Documents") ; tabItem_DeptAllownce.Text=   (arln == 0 ? "  التأمينات الإجتماعية  " : "  Social Security") ; tabItem_DeptZakaa.Text=   (arln == 0 ? "  مصلحة الزكاة  " : "  Department of Zakat") ; tabItem_DeptDoc.Text=   (arln == 0 ? "  وثائق الإدارات  " : "  Departmental documents") ; tabItem_Visa.Text=   (arln == 0 ? "  التأشيرات  " : "  visas") ; tabItem_VacDoc.Text=   (arln == 0 ? "  الإجازات المنتهية  " : "  Expired vacations") ; tabItem_Secretariats.Text=   (arln == 0 ? "  وثائق الأمانات  " : "  Trust Documents") ; tabControl5.Text=   (arln == 0 ? "  كروت التشغيل  " : "  operating cards") ; tabItem_CarForms.Text=   (arln == 0 ? "  الإستمارات  " : "  forms") ; tabItem_CarAllownce.Text=   (arln == 0 ? "  التأمينات  " : "  insurances") ; tabItem_CarsDoc.Text=   (arln == 0 ? "  وثائق السيارات  " : "  Auto Documents") ; tabItem_FamilyDoc.Text=   (arln == 0 ? "  جوازات المرافقين  " : "  Accompanying passports") ; tabItem_EmployeeContract.Text=   (arln == 0 ? "  العقود المنتهية  " : "  Expired contracts") ; tabItem_BossDoc.Text=   (arln == 0 ? "  السجل المدني للكفلاء  " : "  The civil registry of the sponsors") ; toolStrip1.Text=   (arln == 0 ? "  toolStrip1  " : "  toolStrip1") ; toolStripSplitButton_Print.Text=   (arln == 0 ? "  طبـــــاعة  " : "  printing") ; ToolStripMenuItem_DocEmp.Text=   (arln == 0 ? "  وثائق الموظفين  " : "  Personnel Documents") ; ToolStripMenuItem_PrintEmpID.Text=   (arln == 0 ? "  طباعة الهويات  " : "  ID printing") ; ToolStripMenuItem_PrintEmpPassport.Text=   (arln == 0 ? "  طباعة جوازات السفر  " : "  Passport printing") ; ToolStripMenuItem_PrintEmpLicense.Text=   (arln == 0 ? "  طباعة رخص القيادة  " : "  Driving licenses printing") ; ToolStripMenuItem_PrintEmpForms.Text=   (arln == 0 ? "  طباعة إستمارات السيارات  " : "  Printing car forms") ; ToolStripMenuItem_PrintEmpAllownce.Text=   (arln == 0 ? "  طباعة التأمينات الصحية  " : "  Health insurance printing") ; ToolStripMenuItem_PrintContract.Text=   (arln == 0 ? "  طباعة العقود المنتهية  " : "  Print expired contracts") ; ToolStripMenuItem_PrintVac.Text=   (arln == 0 ? "  طباعة الاجازات المنتهية  " : "  Expired leave printing") ; ToolStripMenuItem_PrintFamilyPassport.Text=   (arln == 0 ? "  طباعة جوازات المرافقين المنتهية  " : "  Printing expired passports of companions") ; ToolStripMenuItem_BossRecord.Text=   (arln == 0 ? "  السجل المدني للكفلاء  " : "  The civil registry of the sponsors") ; ToolStripMenuItem_DeptDoc.Text=   (arln == 0 ? "  وثائق الإدارات  " : "  Departmental documents") ; ToolStripMenuItem_DeptAllownce.Text=   (arln == 0 ? "  التأمينات الإجتماعية للإدارات  " : "  Departmental Social Security") ; ToolStripMenuItem_DeptZakaa.Text=   (arln == 0 ? "  مصلحة الزكاة  " : "  Department of Zakat") ; ToolStripMenuItem_CarDoc.Text=   (arln == 0 ? "  وثائق السيارات  " : "  Auto Documents") ; ToolStripMenuItem_CarsForms.Text=   (arln == 0 ? "  طباعة الإستمارات  " : "  print forms") ; ToolStripMenuItem_CarsAllownce.Text=   (arln == 0 ? "  طباعة التأمينات  " : "  Insurance printing") ; ToolStripMenuItem_SecretariatsDoc.Text=   (arln == 0 ? "  وثائق الأمانات  " : "  Trust Documents") ; ToolStripMenuItem_VisaGoBack.Text=   (arln == 0 ? "  تأشيرات الخروج والعودة  " : "  Exit and return visas") ; toolStripButton_Close.Text=   (arln == 0 ? "  خــــــــروج  " : "  exit") ; Text = "تنبيهــات وثائــق شؤون الموظفـــين";this.Text=   (arln == 0 ? "  تنبيهــات وثائــق شؤون الموظفـــين  " : "  Personnel Documents Alerts") ;}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
        public class ColumnDictinary
        {
            public string EmpNo;
            public ColumnDictinary(string empNo)
            {
                EmpNo = empNo;
            }
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
        private DevComponents.DotNetBar.TabControl tabControl1;
        private TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabControl tabControl2;
        private TabControlPanel tabControlPanel6;
        private SuperGridControl superGridControl_Id;
        private TabItem tabItem_ID;
        private TabControlPanel tabControlPanel8;
        private SuperGridControl superGridControl_Forms;
        private TabItem tabItem_EmpForms;
        private TabControlPanel tabControlPanel9;
        private SuperGridControl superGridControl_Lisnese;
        private TabItem tabItem_License;
        private TabControlPanel tabControlPanel10;
        private SuperGridControl superGridControl_Passport;
        private TabItem tabItem_Passport;
        private TabControlPanel tabControlPanel7;
        private SuperGridControl superGridControl_Allownc;
        private TabItem tabItem_EmpAllownce;
        private TabItem tabItem_EmployeeDoc;
        private TabControlPanel tabControlPanel3;
        private SuperGridControl superGridControl_Contract;
        private TabItem tabItem_EmployeeContract;
        private TabControlPanel tabControlPanel16;
        private SuperGridControl superGridControl_RecordBranch;
        private TabControlPanel tabControlPanel1;
        private TabItem tabItem_BossDoc;
        private TabControlPanel tabControlPanel28;
        private DevComponents.DotNetBar.TabControl tabControl6;
        private TabControlPanel tabControlPanel29;
        private SuperGridControl superGridControl_AllownceDept;
        private TabItem tabItem_DeptAllownce;
        private TabControlPanel tabControlPanel32;
        private SuperGridControl superGridControl_ZakaaDept;
        private TabItem tabItem_DeptZakaa;
        private TabItem tabItem_DeptDoc;
        private TabControlPanel tabControlPanel13;
        private DevComponents.DotNetBar.TabControl tabControl5;
        private TabControlPanel tabControlPanel17;
        private SuperGridControl superGridControl_CarForms;
        private TabItem tabItem_CarForms;
        private TabControlPanel tabControlPanel18;
        private SuperGridControl superGridControl_CarAllownces;
        private TabItem tabItem_CarAllownce;
        private TabItem tabItem_CarsDoc;
        private TabControlPanel tabControlPanel23;
        private TabItem tabItem_Visa;
        private TabControlPanel tabControlPanel22;
        private SuperGridControl superGridControl_Secretariats;
        private TabItem tabItem_Secretariats;
        private TabControlPanel tabControlPanel5;
        private SuperGridControl superGridControl_EmployeeVac;
        private TabItem tabItem_VacDoc;
        private TabControlPanel tabControlPanel4;
        private SuperGridControl superGridControl_FamilyPassport;
        private TabItem tabItem_FamilyDoc;
        private ToolStrip toolStrip1;
        private ToolStripSplitButton toolStripSplitButton_Print;
        private ToolStripMenuItem ToolStripMenuItem_DocEmp;
        private ToolStripMenuItem ToolStripMenuItem_PrintEmpID;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem ToolStripMenuItem_PrintEmpPassport;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem ToolStripMenuItem_PrintEmpLicense;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem ToolStripMenuItem_PrintEmpForms;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem ToolStripMenuItem_PrintEmpAllownce;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem ToolStripMenuItem_PrintContract;
        private ToolStripMenuItem ToolStripMenuItem_PrintVac;
        private ToolStripMenuItem ToolStripMenuItem_PrintFamilyPassport;
        private ToolStripSeparator toolStripSeparator18;
        private ToolStripMenuItem ToolStripMenuItem_DeptDoc;
        private ToolStripMenuItem ToolStripMenuItem_DeptAllownce;
        private ToolStripSeparator toolStripSeparator16;
        private ToolStripMenuItem ToolStripMenuItem_DeptZakaa;
        private ToolStripSeparator toolStripSeparator17;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem ToolStripMenuItem_CarDoc;
        private ToolStripMenuItem ToolStripMenuItem_CarsForms;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripMenuItem ToolStripMenuItem_CarsAllownce;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripSeparator toolStripSeparator13;
        private ToolStripMenuItem ToolStripMenuItem_SecretariatsDoc;
        private ToolStripSeparator toolStripSeparator19;
        private ToolStripButton toolStripButton_Close;
        private SuperGridControl superGridControl_VisaGoBack;
        private ToolStripMenuItem ToolStripMenuItem_VisaGoBack;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem ToolStripMenuItem_BossRecord;
        private SuperGridControl superGridControl_BossRecord;
        private int LangArEn = 0;
        private GridRow row;
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private Dictionary<string, ColumnDictinary> FlagLte = new Dictionary<string, ColumnDictinary>();
        private Dictionary<string, ColumnDictinary> FlagSlp = new Dictionary<string, ColumnDictinary>();
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        public FormState State
        {
            get
            {
                return statex;
            }
            set
            {
                statex = value;
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
        public FrmAutoAlarm()
        {
            InitializeComponent();this.Load += langloads;
        }
        private void FrmAutoAlarm_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmAutoAlarm));
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
                    SettingGrid();
                    try
                    {
                        tabControl1.SelectedTabIndex = VarGeneral.vTabAutoAlarm;
                    }
                    catch
                    {
                        tabControl1.SelectedTabIndex = 0;
                    }
                }
                catch (Exception error2)
                {
                    VarGeneral.DebLog.writeLog("FrmAttendLate_Load:", error2, enable: true);
                    MessageBox.Show(error2.Message);
                }
            }
            catch (Exception error2)
            {
                VarGeneral.DebLog.writeLog("Load:", error2, enable: true);
                MessageBox.Show(error2.Message);
            }
        }
        private int getTotalDays(string dt1, string dt2)
        {
            try
            {
                DateTime d1 = Convert.ToDateTime(dt1);
                DateTime d2 = Convert.ToDateTime(dt2);
                return d1.Subtract(d2).Days;
            }
            catch
            {
                return 0;
            }
        }
        private void FillEmpDoc()
        {
            List<T_Emp> vEmp = db.ExecuteQuery<T_Emp>("Select * From T_Emp Where T_Emp.EmpState = 1 AND DATEADD(DAY, -" + VarGeneral.Settings_Sys.AlarmEmpDocBefore.Value + ", CONVERT(DATE, ID_DateEnd)) <= CASE WHEN substring(ID_DateEnd,1,4) < 1800 THEN CONVERT(DATE, '" + VarGeneral.Hdate + "') ELSE '" + VarGeneral.Gdate + "' END", new object[0]).ToList();
            for (int i = 0; i < vEmp.Count(); i++)
            {
                if (VarGeneral.CheckDate(vEmp[i].ID_DateEnd))
                {
                    row = new GridRow();
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    superGridControl_Id.PrimaryGrid.Rows.Add(row);
                    superGridControl_Id.PrimaryGrid.GetCell(i, 0).Value = getTotalDays(vEmp[i].ID_DateEnd, n.IsGreg(vEmp[i].ID_DateEnd) ? VarGeneral.Gdate : VarGeneral.Hdate);
                    superGridControl_Id.PrimaryGrid.GetCell(i, 1).Value = vEmp[i].ID_DateEnd;
                    superGridControl_Id.PrimaryGrid.GetCell(i, 2).Value = vEmp[i].ID_Date;
                    if (vEmp[i].ID_From.HasValue)
                    {
                        superGridControl_Id.PrimaryGrid.GetCell(i, 3).Value = ((LangArEn == 0) ? db.CityEmp(vEmp[i].ID_From.Value).NameA : db.CityEmp(vEmp[i].ID_From.Value).NameE);
                    }
                    else
                    {
                        superGridControl_Id.PrimaryGrid.GetCell(i, 3).Value = "";
                    }
                    superGridControl_Id.PrimaryGrid.GetCell(i, 4).Value = vEmp[i].ID_No;
                    superGridControl_Id.PrimaryGrid.GetCell(i, 5).Value = ((LangArEn == 0) ? vEmp[i].NameA : vEmp[i].NameE);
                    superGridControl_Id.PrimaryGrid.GetCell(i, 6).Value = vEmp[i].Emp_No;
                }
            }
            List<T_Car> vCr = db.ExecuteQuery<T_Car>("Select * From T_Cars Where EmpID is not null and DATEADD(DAY, -" + VarGeneral.Settings_Sys.AlarmEmpDocBefore.Value + ", CONVERT(DATE, FormEndDate)) <= CASE WHEN substring(FormEndDate,1,4) < 1800 THEN CONVERT(DATE, '" + VarGeneral.Hdate + "') ELSE '" + VarGeneral.Gdate + "' END", new object[0]).ToList();
            for (int i = 0; i < vCr.Count(); i++)
            {
                if (VarGeneral.CheckDate(vCr[i].FormEndDate) && vCr[i].T_Emp.EmpState.Value)
                {
                    row = new GridRow();
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    superGridControl_Forms.PrimaryGrid.Rows.Add(row);
                    superGridControl_Forms.PrimaryGrid.GetCell(i, 0).Value = getTotalDays(vCr[i].FormEndDate, n.IsGreg(vCr[i].FormEndDate) ? VarGeneral.Gdate : VarGeneral.Hdate);
                    superGridControl_Forms.PrimaryGrid.GetCell(i, 1).Value = vCr[i].FormEndDate;
                    superGridControl_Forms.PrimaryGrid.GetCell(i, 2).Value = vCr[i].FormBeginDate;
                    superGridControl_Forms.PrimaryGrid.GetCell(i, 3).Value = ((LangArEn == 0) ? vCr[i].NameA : vCr[i].NameE);
                    superGridControl_Forms.PrimaryGrid.GetCell(i, 4).Value = vCr[i].FormNo;
                    superGridControl_Forms.PrimaryGrid.GetCell(i, 5).Value = ((LangArEn == 0) ? vCr[i].T_Emp.NameA : vCr[i].T_Emp.NameE);
                    superGridControl_Forms.PrimaryGrid.GetCell(i, 6).Value = vCr[i].T_Emp.Emp_No;
                }
            }
            vEmp = db.ExecuteQuery<T_Emp>("Select * From T_Emp Where T_Emp.EmpState = 1 AND DATEADD(DAY, -" + VarGeneral.Settings_Sys.AlarmEmpDocBefore.Value + ", CONVERT(DATE, Passport_DateEnd)) <= CASE WHEN substring(Passport_DateEnd,1,4) < 1800 THEN CONVERT(DATE, '" + VarGeneral.Hdate + "') ELSE '" + VarGeneral.Gdate + "' END", new object[0]).ToList();
            for (int i = 0; i < vEmp.Count(); i++)
            {
                if (VarGeneral.CheckDate(vEmp[i].Passport_DateEnd))
                {
                    row = new GridRow();
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    superGridControl_Passport.PrimaryGrid.Rows.Add(row);
                    superGridControl_Passport.PrimaryGrid.GetCell(i, 0).Value = getTotalDays(vEmp[i].Passport_DateEnd, n.IsGreg(vEmp[i].Passport_DateEnd) ? VarGeneral.Gdate : VarGeneral.Hdate);
                    superGridControl_Passport.PrimaryGrid.GetCell(i, 1).Value = vEmp[i].Passport_DateEnd;
                    superGridControl_Passport.PrimaryGrid.GetCell(i, 2).Value = vEmp[i].Passport_Date;
                    if (vEmp[i].Passport_From.HasValue)
                    {
                        superGridControl_Passport.PrimaryGrid.GetCell(i, 3).Value = ((LangArEn == 0) ? db.CityEmp(vEmp[i].Passport_From.Value).NameA : db.CityEmp(vEmp[i].Passport_From.Value).NameE);
                    }
                    else
                    {
                        superGridControl_Passport.PrimaryGrid.GetCell(i, 3).Value = "";
                    }
                    superGridControl_Passport.PrimaryGrid.GetCell(i, 4).Value = vEmp[i].Passport_No;
                    superGridControl_Passport.PrimaryGrid.GetCell(i, 5).Value = ((LangArEn == 0) ? vEmp[i].NameA : vEmp[i].NameE);
                    superGridControl_Passport.PrimaryGrid.GetCell(i, 6).Value = vEmp[i].Emp_No;
                }
            }
            vEmp = db.ExecuteQuery<T_Emp>("Select * From T_Emp Where T_Emp.EmpState = 1 AND DATEADD(DAY, -" + VarGeneral.Settings_Sys.AlarmEmpDocBefore.Value + ", CONVERT(DATE, License_DateEnd)) <= CASE WHEN substring(License_DateEnd,1,4) < 1800 THEN CONVERT(DATE, '" + VarGeneral.Hdate + "') ELSE '" + VarGeneral.Gdate + "' END", new object[0]).ToList();
            for (int i = 0; i < vEmp.Count(); i++)
            {
                if (VarGeneral.CheckDate(vEmp[i].License_DateEnd))
                {
                    row = new GridRow();
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    superGridControl_Lisnese.PrimaryGrid.Rows.Add(row);
                    superGridControl_Lisnese.PrimaryGrid.GetCell(i, 0).Value = getTotalDays(vEmp[i].License_DateEnd, n.IsGreg(vEmp[i].License_DateEnd) ? VarGeneral.Gdate : VarGeneral.Hdate);
                    superGridControl_Lisnese.PrimaryGrid.GetCell(i, 1).Value = vEmp[i].License_DateEnd;
                    superGridControl_Lisnese.PrimaryGrid.GetCell(i, 2).Value = vEmp[i].License_Date;
                    if (vEmp[i].License_From.HasValue)
                    {
                        superGridControl_Lisnese.PrimaryGrid.GetCell(i, 3).Value = ((LangArEn == 0) ? db.CityEmp(vEmp[i].License_From.Value).NameA : db.CityEmp(vEmp[i].License_From.Value).NameE);
                    }
                    else
                    {
                        superGridControl_Lisnese.PrimaryGrid.GetCell(i, 3).Value = "";
                    }
                    superGridControl_Lisnese.PrimaryGrid.GetCell(i, 4).Value = vEmp[i].License_No;
                    superGridControl_Lisnese.PrimaryGrid.GetCell(i, 5).Value = ((LangArEn == 0) ? vEmp[i].NameA : vEmp[i].NameE);
                    superGridControl_Lisnese.PrimaryGrid.GetCell(i, 6).Value = vEmp[i].Emp_No;
                }
            }
            vEmp = db.ExecuteQuery<T_Emp>("Select * From T_Emp Where T_Emp.EmpState = 1 AND DATEADD(DAY, -" + VarGeneral.Settings_Sys.AlarmEmpDocBefore.Value + ", CONVERT(DATE, Insurance_DateEnd)) <= CASE WHEN substring(Insurance_DateEnd,1,4) < 1800 THEN CONVERT(DATE, '" + VarGeneral.Hdate + "') ELSE '" + VarGeneral.Gdate + "' END", new object[0]).ToList();
            for (int i = 0; i < vEmp.Count(); i++)
            {
                if (VarGeneral.CheckDate(vEmp[i].Insurance_DateEnd))
                {
                    row = new GridRow();
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    superGridControl_Allownc.PrimaryGrid.Rows.Add(row);
                    superGridControl_Allownc.PrimaryGrid.GetCell(i, 0).Value = getTotalDays(vEmp[i].Insurance_DateEnd, n.IsGreg(vEmp[i].Insurance_DateEnd) ? VarGeneral.Gdate : VarGeneral.Hdate);
                    superGridControl_Allownc.PrimaryGrid.GetCell(i, 1).Value = vEmp[i].Insurance_DateEnd;
                    superGridControl_Allownc.PrimaryGrid.GetCell(i, 2).Value = vEmp[i].Insurance_Date;
                    if (vEmp[i].Insurance_From.HasValue)
                    {
                        superGridControl_Allownc.PrimaryGrid.GetCell(i, 3).Value = ((LangArEn == 0) ? db.CityEmp(vEmp[i].Insurance_From.Value).NameA : db.CityEmp(vEmp[i].Insurance_From.Value).NameE);
                    }
                    else
                    {
                        superGridControl_Allownc.PrimaryGrid.GetCell(i, 3).Value = "";
                    }
                    superGridControl_Allownc.PrimaryGrid.GetCell(i, 4).Value = vEmp[i].Insurance_No;
                    superGridControl_Allownc.PrimaryGrid.GetCell(i, 5).Value = ((LangArEn == 0) ? vEmp[i].NameA : vEmp[i].NameE);
                    superGridControl_Allownc.PrimaryGrid.GetCell(i, 6).Value = vEmp[i].Emp_No;
                }
            }
        }
        private void FillEmpContract()
        {
            List<T_Emp> vEmp = db.ExecuteQuery<T_Emp>("Select * From T_Emp Where DATEADD(DAY, -" + VarGeneral.Settings_Sys.AlarmEmpContractBefore.Value + ", CONVERT(DATE, EndContr)) <= CASE WHEN substring(EndContr,1,4) < 1800 THEN CONVERT(DATE, '" + VarGeneral.Hdate + "') ELSE '" + VarGeneral.Gdate + "' END", new object[0]).ToList();
            for (int i = 0; i < vEmp.Count(); i++)
            {
                if (VarGeneral.CheckDate(vEmp[i].EndContr))
                {
                    row = new GridRow();
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    superGridControl_Contract.PrimaryGrid.Rows.Add(row);
                    superGridControl_Contract.PrimaryGrid.GetCell(i, 0).Value = getTotalDays(vEmp[i].EndContr, n.IsGreg(vEmp[i].EndContr) ? VarGeneral.Gdate : VarGeneral.Hdate);
                    superGridControl_Contract.PrimaryGrid.GetCell(i, 1).Value = vEmp[i].EndContr;
                    superGridControl_Contract.PrimaryGrid.GetCell(i, 2).Value = vEmp[i].StartContr;
                    superGridControl_Contract.PrimaryGrid.GetCell(i, 3).Value = ((LangArEn == 0) ? vEmp[i].T_Dept.NameA : vEmp[i].T_Dept.NameE);
                    superGridControl_Contract.PrimaryGrid.GetCell(i, 4).Value = ((LangArEn == 0) ? VarGeneral.BranchNameA : VarGeneral.BranchNameE);
                    superGridControl_Contract.PrimaryGrid.GetCell(i, 5).Value = ((LangArEn == 0) ? vEmp[i].NameA : vEmp[i].NameE);
                    superGridControl_Contract.PrimaryGrid.GetCell(i, 6).Value = vEmp[i].Emp_No;
                }
            }
        }
        private void FillEmpFamily()
        {
            List<T_Family> vFamily = db.ExecuteQuery<T_Family>("Select * From T_Family Where DATEADD(DAY, -" + VarGeneral.Settings_Sys.AlarmFamilyPassportBefore.Value + ", CONVERT(DATE, PassEnd)) <= CASE WHEN substring(PassEnd,1,4) < 1800 THEN CONVERT(DATE, '" + VarGeneral.Hdate + "') ELSE '" + VarGeneral.Gdate + "' END", new object[0]).ToList();
            for (int i = 0; i < vFamily.Count; i++)
            {
                if (VarGeneral.CheckDate(vFamily[i].PassEnd))
                {
                    row = new GridRow();
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    superGridControl_FamilyPassport.PrimaryGrid.Rows.Add(row);
                    superGridControl_FamilyPassport.PrimaryGrid.GetCell(i, 0).Value = getTotalDays(vFamily[i].PassEnd, n.IsGreg(vFamily[i].PassEnd) ? VarGeneral.Gdate : VarGeneral.Hdate);
                    superGridControl_FamilyPassport.PrimaryGrid.GetCell(i, 1).Value = vFamily[i].PassEnd;
                    superGridControl_FamilyPassport.PrimaryGrid.GetCell(i, 2).Value = vFamily[i].PassNo;
                    superGridControl_FamilyPassport.PrimaryGrid.GetCell(i, 3).Value = vFamily[i].Name;
                    superGridControl_FamilyPassport.PrimaryGrid.GetCell(i, 4).Value = ((LangArEn == 0) ? vFamily[i].T_Emp.T_Dept.NameA : vFamily[i].T_Emp.T_Dept.NameE);
                    superGridControl_FamilyPassport.PrimaryGrid.GetCell(i, 5).Value = ((LangArEn == 0) ? VarGeneral.BranchNameA : VarGeneral.BranchNameE);
                    superGridControl_FamilyPassport.PrimaryGrid.GetCell(i, 6).Value = vFamily[i].T_Emp.Emp_No;
                }
            }
        }
        private void FillEmpVac()
        {
            List<T_Vacation> vEmpVac = db.ExecuteQuery<T_Vacation>("Select * From T_Vacation Where IFState = 0 AND  DATEADD(DAY, -" + VarGeneral.Settings_Sys.AlarmEndVactionBefore.Value + ", CONVERT(DATE, EndDate)) <= CASE WHEN substring(EndDate,1,4) < 1800 THEN CONVERT(DATE, '" + VarGeneral.Hdate + "') ELSE '" + VarGeneral.Gdate + "' END", new object[0]).ToList();
            for (int i = 0; i < vEmpVac.Count(); i++)
            {
                if (VarGeneral.CheckDate(vEmpVac[i].EndDate))
                {
                    row = new GridRow();
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    superGridControl_EmployeeVac.PrimaryGrid.Rows.Add(row);
                    superGridControl_EmployeeVac.PrimaryGrid.GetCell(i, 0).Value = getTotalDays(vEmpVac[i].EndDate, n.IsGreg(vEmpVac[i].EndDate) ? VarGeneral.Gdate : VarGeneral.Hdate);
                    superGridControl_EmployeeVac.PrimaryGrid.GetCell(i, 1).Value = vEmpVac[i].EndDate;
                    superGridControl_EmployeeVac.PrimaryGrid.GetCell(i, 2).Value = vEmpVac[i].StartDate;
                    superGridControl_EmployeeVac.PrimaryGrid.GetCell(i, 3).Value = ((LangArEn == 0) ? vEmpVac[i].T_Emp.T_Dept.NameA : vEmpVac[i].T_Emp.T_Dept.NameE);
                    superGridControl_EmployeeVac.PrimaryGrid.GetCell(i, 4).Value = ((LangArEn == 0) ? VarGeneral.BranchNameA : VarGeneral.BranchNameE);
                    superGridControl_EmployeeVac.PrimaryGrid.GetCell(i, 5).Value = ((LangArEn == 0) ? vEmpVac[i].T_Emp.NameA : vEmpVac[i].T_Emp.NameE);
                    superGridControl_EmployeeVac.PrimaryGrid.GetCell(i, 6).Value = vEmpVac[i].T_Emp.Emp_No;
                }
            }
        }
        private void FillSecretariats()
        {
            string vDate = Convert.ToDateTime(VarGeneral.Gdate).AddDays(-VarGeneral.Settings_Sys.AlarmSecretariatsBefore.Value).ToString("yyyy/MM/dd");
            string vDateH = Convert.ToDateTime(VarGeneral.Hdate).AddDays(-VarGeneral.Settings_Sys.AlarmSecretariatsBefore.Value).ToString("yyyy/MM/dd");
            List<T_Secretariat> vSecretariats = db.ExecuteQuery<T_Secretariat>("Select * From T_Secretariats Where T_Secretariats.IFState = 0 and DATEADD(DAY, -" + VarGeneral.Settings_Sys.AlarmSecretariatsBefore.Value + ", CONVERT(DATE, T_Secretariats.EndDate)) <= CASE WHEN substring(T_Secretariats.EndDate,1,4) < 1800 THEN CONVERT(DATE, '" + VarGeneral.Hdate + "') ELSE '" + VarGeneral.Gdate + "' END", new object[0]).ToList();
            for (int i = 0; i < vSecretariats.Count(); i++)
            {
                if (VarGeneral.CheckDate(vSecretariats[i].EndDate))
                {
                    row = new GridRow();
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    superGridControl_Secretariats.PrimaryGrid.Rows.Add(row);
                    superGridControl_Secretariats.PrimaryGrid.GetCell(i, 0).Value = getTotalDays(vSecretariats[i].EndDate, n.IsGreg(vSecretariats[i].EndDate) ? VarGeneral.Gdate : VarGeneral.Hdate);
                    superGridControl_Secretariats.PrimaryGrid.GetCell(i, 1).Value = vSecretariats[i].Note;
                    superGridControl_Secretariats.PrimaryGrid.GetCell(i, 2).Value = vSecretariats[i].EndDate;
                    superGridControl_Secretariats.PrimaryGrid.GetCell(i, 3).Value = vSecretariats[i].StartDate;
                    superGridControl_Secretariats.PrimaryGrid.GetCell(i, 4).Value = ((LangArEn == 0) ? vSecretariats[i].T_SecretariatsTyp.NameA : vSecretariats[i].T_SecretariatsTyp.NameE);
                    superGridControl_Secretariats.PrimaryGrid.GetCell(i, 5).Value = ((LangArEn == 0) ? vSecretariats[i].T_Emp.NameA : vSecretariats[i].T_Emp.NameE);
                    superGridControl_Secretariats.PrimaryGrid.GetCell(i, 6).Value = vSecretariats[i].T_Emp.Emp_No;
                }
            }
        }
        private void FillVisaGoBack()
        {
            string vDate = Convert.ToDateTime(VarGeneral.Gdate).AddDays(-VarGeneral.Settings_Sys.AlarmVisaGoBack.Value).ToString("yyyy/MM/dd");
            string vDateH = Convert.ToDateTime(VarGeneral.Hdate).AddDays(-VarGeneral.Settings_Sys.AlarmVisaGoBack.Value).ToString("yyyy/MM/dd");
            List<T_VisaGoBack> vVisaGoBack = db.ExecuteQuery<T_VisaGoBack>("Select * From T_VisaGoBack Where DATEADD(DAY, -" + VarGeneral.Settings_Sys.AlarmVisaGoBack.Value + ", CONVERT(DATE, T_VisaGoBack.VisaEndDate)) <= CASE WHEN substring(T_VisaGoBack.VisaEndDate,1,4) < 1800 THEN CONVERT(DATE, '" + VarGeneral.Hdate + "') ELSE '" + VarGeneral.Gdate + "' END", new object[0]).ToList();
            for (int i = 0; i < vVisaGoBack.Count(); i++)
            {
                if (VarGeneral.CheckDate(vVisaGoBack[i].VisaEndDate))
                {
                    row = new GridRow();
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    superGridControl_VisaGoBack.PrimaryGrid.Rows.Add(row);
                    superGridControl_VisaGoBack.PrimaryGrid.GetCell(i, 0).Value = getTotalDays(vVisaGoBack[i].VisaEndDate, n.IsGreg(vVisaGoBack[i].VisaEndDate) ? VarGeneral.Gdate : VarGeneral.Hdate);
                    superGridControl_VisaGoBack.PrimaryGrid.GetCell(i, 1).Value = vVisaGoBack[i].VisaEndDate;
                    superGridControl_VisaGoBack.PrimaryGrid.GetCell(i, 2).Value = vVisaGoBack[i].VisaBeginDate;
                    superGridControl_VisaGoBack.PrimaryGrid.GetCell(i, 3).Value = vVisaGoBack[i].VisaPlace;
                    superGridControl_VisaGoBack.PrimaryGrid.GetCell(i, 4).Value = vVisaGoBack[i].VisaNo;
                    superGridControl_VisaGoBack.PrimaryGrid.GetCell(i, 5).Value = ((LangArEn == 0) ? vVisaGoBack[i].T_Emp.NameA : vVisaGoBack[i].T_Emp.NameE);
                    superGridControl_VisaGoBack.PrimaryGrid.GetCell(i, 6).Value = vVisaGoBack[i].T_Emp.Emp_No;
                }
            }
        }
        private void FillBoss()
        {
            List<T_Guarantor> vBoss = db.ExecuteQuery<T_Guarantor>("Select * From T_Guarantor Where DATEADD(DAY, -" + VarGeneral.Settings_Sys.AlarmGuarantorDocBefore.Value + ", CONVERT(DATE, MdniEndDate)) <= CASE WHEN substring(MdniEndDate,1,4) < 1800 THEN CONVERT(DATE, '" + VarGeneral.Hdate + "') ELSE '" + VarGeneral.Gdate + "' END", new object[0]).ToList();
            for (int i = 0; i < vBoss.Count(); i++)
            {
                if (VarGeneral.CheckDate(vBoss[i].MdniEndDate))
                {
                    row = new GridRow();
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    superGridControl_BossRecord.PrimaryGrid.Rows.Add(row);
                    superGridControl_BossRecord.PrimaryGrid.GetCell(i, 0).Value = getTotalDays(vBoss[i].MdniEndDate, n.IsGreg(vBoss[i].MdniEndDate) ? VarGeneral.Gdate : VarGeneral.Hdate);
                    superGridControl_BossRecord.PrimaryGrid.GetCell(i, 1).Value = vBoss[i].MdniEndDate;
                    superGridControl_BossRecord.PrimaryGrid.GetCell(i, 2).Value = vBoss[i].MdniBeginDate;
                    superGridControl_BossRecord.PrimaryGrid.GetCell(i, 3).Value = vBoss[i].MdniFrom;
                    superGridControl_BossRecord.PrimaryGrid.GetCell(i, 4).Value = vBoss[i].MdniNo;
                    superGridControl_BossRecord.PrimaryGrid.GetCell(i, 5).Value = ((LangArEn == 0) ? vBoss[i].NameA : vBoss[i].NameE);
                    superGridControl_BossRecord.PrimaryGrid.GetCell(i, 6).Value = vBoss[i].Guarantor_No;
                }
            }
        }
        private void FillDept()
        {
            List<T_Dept> vDepts = db.ExecuteQuery<T_Dept>("Select * From T_Dept Where DATEADD(DAY, -" + VarGeneral.Settings_Sys.AlarmDeptsBefore.Value + ", CONVERT(DATE, AllownceEndDate)) <= CASE WHEN substring(AllownceEndDate,1,4) < 1800 THEN CONVERT(DATE, '" + VarGeneral.Hdate + "') ELSE '" + VarGeneral.Gdate + "' END", new object[0]).ToList();
            for (int i = 0; i < vDepts.Count(); i++)
            {
                if (VarGeneral.CheckDate(vDepts[i].AllownceEndDate))
                {
                    row = new GridRow();
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    superGridControl_AllownceDept.PrimaryGrid.Rows.Add(row);
                    superGridControl_AllownceDept.PrimaryGrid.GetCell(i, 0).Value = getTotalDays(vDepts[i].AllownceEndDate, n.IsGreg(vDepts[i].AllownceEndDate) ? VarGeneral.Gdate : VarGeneral.Hdate);
                    superGridControl_AllownceDept.PrimaryGrid.GetCell(i, 1).Value = vDepts[i].AllownceEndDate;
                    superGridControl_AllownceDept.PrimaryGrid.GetCell(i, 2).Value = vDepts[i].AllownceBeginDate;
                    superGridControl_AllownceDept.PrimaryGrid.GetCell(i, 3).Value = vDepts[i].AllownceNo;
                    superGridControl_AllownceDept.PrimaryGrid.GetCell(i, 4).Value = vDepts[i].Phone;
                    superGridControl_AllownceDept.PrimaryGrid.GetCell(i, 5).Value = ((LangArEn == 0) ? vDepts[i].NameA : vDepts[i].NameE);
                    superGridControl_AllownceDept.PrimaryGrid.GetCell(i, 6).Value = vDepts[i].Dept_No;
                }
            }
            vDepts = db.ExecuteQuery<T_Dept>("Select * From T_Dept Where DATEADD(DAY, -" + VarGeneral.Settings_Sys.AlarmDeptsBefore.Value + ", CONVERT(DATE, ZakaaEndDate1)) <= CASE WHEN substring(ZakaaEndDate1,1,4) < 1800 THEN CONVERT(DATE, '" + VarGeneral.Hdate + "') ELSE '" + VarGeneral.Gdate + "' END", new object[0]).ToList();
            for (int i = 0; i < vDepts.Count(); i++)
            {
                if (VarGeneral.CheckDate(vDepts[i].ZakaaEndDate1))
                {
                    row = new GridRow();
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    superGridControl_ZakaaDept.PrimaryGrid.Rows.Add(row);
                    superGridControl_ZakaaDept.PrimaryGrid.GetCell(i, 0).Value = getTotalDays(vDepts[i].ZakaaEndDate1, n.IsGreg(vDepts[i].ZakaaEndDate1) ? VarGeneral.Gdate : VarGeneral.Hdate);
                    superGridControl_ZakaaDept.PrimaryGrid.GetCell(i, 1).Value = vDepts[i].ZakaaEndDate1;
                    superGridControl_ZakaaDept.PrimaryGrid.GetCell(i, 2).Value = vDepts[i].ZakaaBeginDate;
                    superGridControl_ZakaaDept.PrimaryGrid.GetCell(i, 3).Value = vDepts[i].ZakaaNo;
                    superGridControl_ZakaaDept.PrimaryGrid.GetCell(i, 4).Value = vDepts[i].Phone;
                    superGridControl_ZakaaDept.PrimaryGrid.GetCell(i, 5).Value = ((LangArEn == 0) ? vDepts[i].NameA : vDepts[i].NameE);
                    superGridControl_ZakaaDept.PrimaryGrid.GetCell(i, 6).Value = vDepts[i].Dept_No;
                }
            }
        }
        private void FillCars()
        {
            List<T_Car> vCars = db.ExecuteQuery<T_Car>("Select * From T_Cars Where DATEADD(DAY, -" + VarGeneral.Settings_Sys.AlarmCarDocBefore.Value + ", CONVERT(DATE, FormEndDate)) <= CASE WHEN substring(FormEndDate,1,4) < 1800 THEN CONVERT(DATE, '" + VarGeneral.Hdate + "') ELSE '" + VarGeneral.Gdate + "' END", new object[0]).ToList();
            for (int i = 0; i < vCars.Count(); i++)
            {
                if (VarGeneral.CheckDate(vCars[i].FormEndDate))
                {
                    row = new GridRow();
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    superGridControl_CarForms.PrimaryGrid.Rows.Add(row);
                    superGridControl_CarForms.PrimaryGrid.GetCell(i, 0).Value = getTotalDays(vCars[i].FormEndDate, n.IsGreg(vCars[i].FormEndDate) ? VarGeneral.Gdate : VarGeneral.Hdate);
                    superGridControl_CarForms.PrimaryGrid.GetCell(i, 1).Value = vCars[i].FormEndDate;
                    superGridControl_CarForms.PrimaryGrid.GetCell(i, 2).Value = vCars[i].FormBeginDate;
                    superGridControl_CarForms.PrimaryGrid.GetCell(i, 3).Value = vCars[i].FormNo;
                    superGridControl_CarForms.PrimaryGrid.GetCell(i, 4).Value = ((LangArEn == 0) ? vCars[i].T_CarTyp.NameA : vCars[i].T_CarTyp.NameE);
                    superGridControl_CarForms.PrimaryGrid.GetCell(i, 5).Value = ((LangArEn == 0) ? vCars[i].NameA : vCars[i].NameE);
                    superGridControl_CarForms.PrimaryGrid.GetCell(i, 6).Value = vCars[i].Car_No;
                }
            }
            vCars = db.ExecuteQuery<T_Car>("Select * From T_Cars Where DATEADD(DAY, -" + VarGeneral.Settings_Sys.AlarmCarDocBefore.Value + ", CONVERT(DATE, AllownceEndDate)) <= CASE WHEN substring(AllownceEndDate,1,4) < 1800 THEN CONVERT(DATE, '" + VarGeneral.Hdate + "') ELSE '" + VarGeneral.Gdate + "' END", new object[0]).ToList();
            for (int i = 0; i < vCars.Count(); i++)
            {
                if (VarGeneral.CheckDate(vCars[i].AllownceEndDate))
                {
                    row = new GridRow();
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    row.Cells.Add(new GridCell(""));
                    superGridControl_CarAllownces.PrimaryGrid.Rows.Add(row);
                    superGridControl_CarAllownces.PrimaryGrid.GetCell(i, 0).Value = getTotalDays(vCars[i].AllownceEndDate, n.IsGreg(vCars[i].AllownceEndDate) ? VarGeneral.Gdate : VarGeneral.Hdate);
                    superGridControl_CarAllownces.PrimaryGrid.GetCell(i, 1).Value = vCars[i].AllownceEndDate;
                    superGridControl_CarAllownces.PrimaryGrid.GetCell(i, 2).Value = vCars[i].AllownceBeginDate;
                    superGridControl_CarAllownces.PrimaryGrid.GetCell(i, 3).Value = vCars[i].AllownceNo;
                    superGridControl_CarAllownces.PrimaryGrid.GetCell(i, 4).Value = ((LangArEn == 0) ? vCars[i].T_CarTyp.NameA : vCars[i].T_CarTyp.NameE);
                    superGridControl_CarAllownces.PrimaryGrid.GetCell(i, 5).Value = ((LangArEn == 0) ? vCars[i].NameA : vCars[i].NameE);
                    superGridControl_CarAllownces.PrimaryGrid.GetCell(i, 6).Value = vCars[i].Car_No;
                }
            }
        }
        private void SettingGrid()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                tabItem_EmployeeDoc.Text = "وثائق الموظفين";
                tabItem_EmployeeContract.Text = "العقود المنتهية";
                tabItem_BossDoc.Text = "السجل المدني للكفلاء";
                tabItem_DeptDoc.Text = "وثائق الإدارات";
                tabItem_CarsDoc.Text = "وثائق السيارات";
                tabItem_EmployeeDoc.Text = "وثائق الموظفين";
                tabItem_ID.Text = "الهويات";
                tabItem_EmployeeContract.Text = "العقود المنتهية";
                tabItem_Passport.Text = "جوازات السفر";
                tabItem_License.Text = "رخص القيادة";
                tabItem_EmpForms.Text = "إستمارة السيارات";
                tabItem_EmpAllownce.Text = "التامينات الصحية";
                tabItem_DeptAllownce.Text = "التأمينات الإجتماعية";
                tabItem_DeptZakaa.Text = "مصلحة الزكاة";
                tabItem_CarForms.Text = "الإستمارات";
                tabItem_CarAllownce.Text = "التأمينات";
                tabItem_FamilyDoc.Text = "جوازات المرافقين";
                tabItem_VacDoc.Text = "الإجازات المنتهية";
                tabItem_Secretariats.Text = "وثائق الأمانات";
                tabItem_Visa.Text = "التأشيرات";
                ToolStripMenuItem_BossRecord.Text = "السجل المدني للكفلاء";
                ToolStripMenuItem_DeptDoc.Text = "وثائق الإدارات";
                ToolStripMenuItem_DeptAllownce.Text = "التأمينات الإجتماعية";
                ToolStripMenuItem_DeptZakaa.Text = "وثائق مصلحة الزكاة";
                ToolStripMenuItem_VisaGoBack.Text = "تأشيرات الخروج والعودة";
                ToolStripMenuItem_CarDoc.Text = "وثائق السيارات";
                ToolStripMenuItem_CarsAllownce.Text = "تأمين السيارات";
                ToolStripMenuItem_CarsForms.Text = "استمارات السيارات";
                ToolStripMenuItem_DocEmp.Text = "وثائق الموظفين";
                ToolStripMenuItem_PrintContract.Text = "العقود المنتهية";
                ToolStripMenuItem_PrintEmpAllownce.Text = "التأمينات الصحية";
                ToolStripMenuItem_PrintEmpForms.Text = "طباعةاستمارة السيارات";
                ToolStripMenuItem_PrintEmpID.Text = "هويات الموظفين";
                ToolStripMenuItem_PrintEmpLicense.Text = "رخص القيادة";
                ToolStripMenuItem_PrintEmpPassport.Text = "جوازات الموظفين";
                ToolStripMenuItem_PrintFamilyPassport.Text = "جوازات المرافقين المنتهثية";
                ToolStripMenuItem_PrintVac.Text = "الاجازات المنتهية";
                ToolStripMenuItem_SecretariatsDoc.Text = "الأمانات";
                toolStripSplitButton_Print.Text = "طبـــــاعة";
                toolStripButton_Close.Text = "خروج";
                Text = "تنبيهــات وثائــق شؤون الموظفـــين";
            }
            else
            {
                tabItem_EmployeeDoc.Text = "Employee Documents";
                tabItem_EmployeeContract.Text = "Employee Documents";
                tabItem_BossDoc.Text = "civil registry For Sponsors";
                tabItem_DeptDoc.Text = "Department Documents";
                tabItem_CarsDoc.Text = "Cars Documents";
                tabItem_EmployeeDoc.Text = "Employee Documents";
                tabItem_ID.Text = "Identities";
                tabItem_EmployeeContract.Text = "Employee Documents";
                tabItem_Passport.Text = "Passport";
                tabItem_License.Text = "License";
                tabItem_EmpForms.Text = "Cars Forms";
                tabItem_EmpAllownce.Text = "Health Insurance";
                tabItem_DeptAllownce.Text = "Social Insurance";
                tabItem_DeptZakaa.Text = "Department of Zakat";
                tabItem_CarForms.Text = "Forms";
                tabItem_CarAllownce.Text = "Insurance";
                tabItem_FamilyDoc.Text = "Passports escorts";
                tabItem_VacDoc.Text = "Vacation ended";
                tabItem_Secretariats.Text = "Secretariats Documents";
                tabItem_Visa.Text = "Visa";
                ToolStripMenuItem_VisaGoBack.Text = "Exit visa and return";
                ToolStripMenuItem_BossRecord.Text = "civil registry For Sponsors";
                ToolStripMenuItem_DeptDoc.Text = "Department Documents";
                ToolStripMenuItem_DeptAllownce.Text = "Print Social insurance";
                ToolStripMenuItem_DeptZakaa.Text = "Print Zakat Documents";
                ToolStripMenuItem_CarDoc.Text = "Cars Documents";
                ToolStripMenuItem_CarsAllownce.Text = "Insurance car";
                ToolStripMenuItem_CarsForms.Text = "Cars Forms";
                ToolStripMenuItem_DocEmp.Text = "Employee Documents";
                ToolStripMenuItem_PrintContract.Text = "Print contracts ended";
                ToolStripMenuItem_PrintEmpAllownce.Text = "Print health insurance";
                ToolStripMenuItem_PrintEmpForms.Text = "Print Form cars";
                ToolStripMenuItem_PrintEmpID.Text = "Print identities of Employee";
                ToolStripMenuItem_PrintEmpLicense.Text = "Print driving licenses";
                ToolStripMenuItem_PrintEmpPassport.Text = "Print Employee passports";
                ToolStripMenuItem_PrintFamilyPassport.Text = "Print passports accompanying ended";
                ToolStripMenuItem_PrintVac.Text = "Print vacations ended";
                ToolStripMenuItem_SecretariatsDoc.Text = "Secretariats Print";
                toolStripSplitButton_Print.Text = "Print";
                toolStripButton_Close.Text = "Close";
                Text = "Documents Alarms of Employee";
            }
            superGridControl_Id.PrimaryGrid.Columns[0].HeaderText = ((LangArEn == 0) ? "الأيام" : "Days");
            superGridControl_Id.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "تاريخ الإنتهاء" : "Expir Date");
            superGridControl_Id.PrimaryGrid.Columns[2].HeaderText = ((LangArEn == 0) ? "تاريخ الإصدار" : "Release Date");
            superGridControl_Id.PrimaryGrid.Columns[3].HeaderText = ((LangArEn == 0) ? "مكان الإصدار" : "Place of Issue");
            superGridControl_Id.PrimaryGrid.Columns[4].HeaderText = ((LangArEn == 0) ? "رقم البطاقة" : "Card No");
            superGridControl_Id.PrimaryGrid.Columns[5].HeaderText = ((LangArEn == 0) ? "اسم الموظف" : "Employee Name");
            superGridControl_Id.PrimaryGrid.Columns[6].HeaderText = ((LangArEn == 0) ? "رقم الموظف" : "Emp No");
            superGridControl_Forms.PrimaryGrid.Columns[0].HeaderText = ((LangArEn == 0) ? "الأيام" : "Days");
            superGridControl_Forms.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "تاريخ الإنتهاء" : "Expir Date");
            superGridControl_Forms.PrimaryGrid.Columns[2].HeaderText = ((LangArEn == 0) ? "تاريخ الإصدار" : "Release Date");
            superGridControl_Forms.PrimaryGrid.Columns[3].HeaderText = ((LangArEn == 0) ? "إسم السيارة" : "Car Name");
            superGridControl_Forms.PrimaryGrid.Columns[4].HeaderText = ((LangArEn == 0) ? "رقم الاستمارة" : "Form No");
            superGridControl_Forms.PrimaryGrid.Columns[5].HeaderText = ((LangArEn == 0) ? "اسم الموظف" : "Employee Name");
            superGridControl_Forms.PrimaryGrid.Columns[6].HeaderText = ((LangArEn == 0) ? "رقم الموظف" : "Emp No");
            superGridControl_Passport.PrimaryGrid.Columns[0].HeaderText = ((LangArEn == 0) ? "الأيام" : "Days");
            superGridControl_Passport.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "تاريخ الإنتهاء" : "Expir Date");
            superGridControl_Passport.PrimaryGrid.Columns[2].HeaderText = ((LangArEn == 0) ? "تاريخ الإصدار" : "Release Date");
            superGridControl_Passport.PrimaryGrid.Columns[3].HeaderText = ((LangArEn == 0) ? "مكان الإصدار" : "Place of Issue");
            superGridControl_Passport.PrimaryGrid.Columns[4].HeaderText = ((LangArEn == 0) ? "رقم الجواز" : "Passport No");
            superGridControl_Passport.PrimaryGrid.Columns[5].HeaderText = ((LangArEn == 0) ? "اسم الموظف" : "Employee Name");
            superGridControl_Passport.PrimaryGrid.Columns[6].HeaderText = ((LangArEn == 0) ? "رقم الموظف" : "Emp No");
            superGridControl_Lisnese.PrimaryGrid.Columns[0].HeaderText = ((LangArEn == 0) ? "الأيام" : "Days");
            superGridControl_Lisnese.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "تاريخ الإنتهاء" : "Expir Date");
            superGridControl_Lisnese.PrimaryGrid.Columns[2].HeaderText = ((LangArEn == 0) ? "تاريخ الإصدار" : "Release Date");
            superGridControl_Lisnese.PrimaryGrid.Columns[3].HeaderText = ((LangArEn == 0) ? "مكان الإصدار" : "Place of Issue");
            superGridControl_Lisnese.PrimaryGrid.Columns[4].HeaderText = ((LangArEn == 0) ? "رقم الرخصة" : "License No");
            superGridControl_Lisnese.PrimaryGrid.Columns[5].HeaderText = ((LangArEn == 0) ? "اسم الموظف" : "Employee Name");
            superGridControl_Lisnese.PrimaryGrid.Columns[6].HeaderText = ((LangArEn == 0) ? "رقم الموظف" : "Emp No");
            superGridControl_Allownc.PrimaryGrid.Columns[0].HeaderText = ((LangArEn == 0) ? "الأيام" : "Days");
            superGridControl_Allownc.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "تاريخ الإنتهاء" : "Expir Date");
            superGridControl_Allownc.PrimaryGrid.Columns[2].HeaderText = ((LangArEn == 0) ? "تاريخ الإصدار" : "Release Date");
            superGridControl_Allownc.PrimaryGrid.Columns[3].HeaderText = ((LangArEn == 0) ? "مكان الإصدار" : "Place of Issue");
            superGridControl_Allownc.PrimaryGrid.Columns[4].HeaderText = ((LangArEn == 0) ? "رقم التأمين" : "Allownce No");
            superGridControl_Allownc.PrimaryGrid.Columns[5].HeaderText = ((LangArEn == 0) ? "اسم الموظف" : "Employee Name");
            superGridControl_Allownc.PrimaryGrid.Columns[6].HeaderText = ((LangArEn == 0) ? "رقم الموظف" : "Emp No");
            superGridControl_Contract.PrimaryGrid.Columns[0].HeaderText = ((LangArEn == 0) ? "الأيام" : "Days");
            superGridControl_Contract.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "نهاية العقد" : "End Contract Date");
            superGridControl_Contract.PrimaryGrid.Columns[2].HeaderText = ((LangArEn == 0) ? "بداية العقد" : "Bigen Contract Date");
            superGridControl_Contract.PrimaryGrid.Columns[3].HeaderText = ((LangArEn == 0) ? "الإدارة" : "Departemente");
            superGridControl_Contract.PrimaryGrid.Columns[4].HeaderText = ((LangArEn == 0) ? "الفرع" : "Branch No");
            superGridControl_Contract.PrimaryGrid.Columns[5].HeaderText = ((LangArEn == 0) ? "اسم الموظف" : "Employee Name");
            superGridControl_Contract.PrimaryGrid.Columns[6].HeaderText = ((LangArEn == 0) ? "رقم الموظف" : "Emp No");
            superGridControl_FamilyPassport.PrimaryGrid.Columns[0].HeaderText = ((LangArEn == 0) ? "الأيام" : "Days");
            superGridControl_FamilyPassport.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "تاريخ انتهائه" : "End Date");
            superGridControl_FamilyPassport.PrimaryGrid.Columns[2].HeaderText = ((LangArEn == 0) ? "رقم الجواز" : "Passport No");
            superGridControl_FamilyPassport.PrimaryGrid.Columns[3].HeaderText = ((LangArEn == 0) ? "إسم المرافق" : "Name");
            superGridControl_FamilyPassport.PrimaryGrid.Columns[4].HeaderText = ((LangArEn == 0) ? "الإدارة" : "Departement");
            superGridControl_FamilyPassport.PrimaryGrid.Columns[5].HeaderText = ((LangArEn == 0) ? "الفرع" : "Branch No");
            superGridControl_FamilyPassport.PrimaryGrid.Columns[6].HeaderText = ((LangArEn == 0) ? "رقم الموظف" : "Emp No");
            superGridControl_EmployeeVac.PrimaryGrid.Columns[0].HeaderText = ((LangArEn == 0) ? "الأيام" : "Days");
            superGridControl_EmployeeVac.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "تاريخ انتهائه" : "End Date");
            superGridControl_EmployeeVac.PrimaryGrid.Columns[2].HeaderText = ((LangArEn == 0) ? "رقم الجواز" : "Passport No");
            superGridControl_EmployeeVac.PrimaryGrid.Columns[3].HeaderText = ((LangArEn == 0) ? "إسم المرافق" : "Name");
            superGridControl_EmployeeVac.PrimaryGrid.Columns[4].HeaderText = ((LangArEn == 0) ? "الإدارة" : "Departement");
            superGridControl_EmployeeVac.PrimaryGrid.Columns[5].HeaderText = ((LangArEn == 0) ? "الفرع" : "Branch");
            superGridControl_EmployeeVac.PrimaryGrid.Columns[6].HeaderText = ((LangArEn == 0) ? "رقم الموظف" : "Emp No");
            superGridControl_BossRecord.PrimaryGrid.Columns[0].HeaderText = ((LangArEn == 0) ? "الأيام" : "Days");
            superGridControl_BossRecord.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "تاريخ الإنتهاء" : "Expir Date");
            superGridControl_BossRecord.PrimaryGrid.Columns[2].HeaderText = ((LangArEn == 0) ? "تاريخ الإصدار" : "Release Date");
            superGridControl_BossRecord.PrimaryGrid.Columns[3].HeaderText = ((LangArEn == 0) ? "مكان الإصدار" : "Place of Issue");
            superGridControl_BossRecord.PrimaryGrid.Columns[4].HeaderText = ((LangArEn == 0) ? "رقم السجل" : "Record No");
            superGridControl_BossRecord.PrimaryGrid.Columns[5].HeaderText = ((LangArEn == 0) ? "اسم الكفيل" : "Boss Name");
            superGridControl_BossRecord.PrimaryGrid.Columns[6].HeaderText = ((LangArEn == 0) ? "رقم الكفيل" : "Boss No");
            superGridControl_RecordBranch.PrimaryGrid.Columns[0].HeaderText = ((LangArEn == 0) ? "الأيام" : "Days");
            superGridControl_RecordBranch.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "تاريخ الإنتهاء" : "Expir Date");
            superGridControl_RecordBranch.PrimaryGrid.Columns[2].HeaderText = ((LangArEn == 0) ? "تاريخ الإصدار" : "Release Date");
            superGridControl_RecordBranch.PrimaryGrid.Columns[3].HeaderText = ((LangArEn == 0) ? "رقم السجل" : "Record No");
            superGridControl_RecordBranch.PrimaryGrid.Columns[4].HeaderText = ((LangArEn == 0) ? "الهاتف" : "Phone");
            superGridControl_RecordBranch.PrimaryGrid.Columns[5].HeaderText = ((LangArEn == 0) ? "اسم الفرع" : "Branch Name");
            superGridControl_RecordBranch.PrimaryGrid.Columns[6].HeaderText = ((LangArEn == 0) ? "رقم الفرع" : "Branch No");
            superGridControl_AllownceDept.PrimaryGrid.Columns[0].HeaderText = ((LangArEn == 0) ? "الأيام" : "Days");
            superGridControl_AllownceDept.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "تاريخ الإنتهاء" : "Expir Date");
            superGridControl_AllownceDept.PrimaryGrid.Columns[2].HeaderText = ((LangArEn == 0) ? "تاريخ الإصدار" : "Release Date");
            superGridControl_AllownceDept.PrimaryGrid.Columns[3].HeaderText = ((LangArEn == 0) ? "رقم التأمين الإجتماعي" : "Social Insurance No");
            superGridControl_AllownceDept.PrimaryGrid.Columns[4].HeaderText = ((LangArEn == 0) ? "الهاتف" : "Phone");
            superGridControl_AllownceDept.PrimaryGrid.Columns[5].HeaderText = ((LangArEn == 0) ? "اسم الإدارة" : " Department Name");
            superGridControl_AllownceDept.PrimaryGrid.Columns[6].HeaderText = ((LangArEn == 0) ? "رقم الإدارة" : " Department No");
            superGridControl_ZakaaDept.PrimaryGrid.Columns[0].HeaderText = ((LangArEn == 0) ? "الأيام" : "Days");
            superGridControl_ZakaaDept.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "تاريخ النهاية" : "End Date");
            superGridControl_ZakaaDept.PrimaryGrid.Columns[2].HeaderText = ((LangArEn == 0) ? "تاريخ البداية" : "Start Date");
            superGridControl_ZakaaDept.PrimaryGrid.Columns[3].HeaderText = ((LangArEn == 0) ? "الرقـــم" : "No");
            superGridControl_ZakaaDept.PrimaryGrid.Columns[4].HeaderText = ((LangArEn == 0) ? "الهاتف" : "Phone");
            superGridControl_ZakaaDept.PrimaryGrid.Columns[5].HeaderText = ((LangArEn == 0) ? "اسم الإدارة" : " Department Name");
            superGridControl_ZakaaDept.PrimaryGrid.Columns[6].HeaderText = ((LangArEn == 0) ? "رقم الإدارة" : " Department No");
            superGridControl_CarForms.PrimaryGrid.Columns[0].HeaderText = ((LangArEn == 0) ? "الأيام" : "Days");
            superGridControl_CarForms.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "تاريخ الإنتهاء" : "Expir Date");
            superGridControl_CarForms.PrimaryGrid.Columns[2].HeaderText = ((LangArEn == 0) ? "تاريخ الإصدار" : "Release Date");
            superGridControl_CarForms.PrimaryGrid.Columns[3].HeaderText = ((LangArEn == 0) ? "رقم الاستمارة" : "Form No");
            superGridControl_CarForms.PrimaryGrid.Columns[4].HeaderText = ((LangArEn == 0) ? "ماركة السيارة" : "Car Type");
            superGridControl_CarForms.PrimaryGrid.Columns[5].HeaderText = ((LangArEn == 0) ? "اسم السيارة" : "Car Name");
            superGridControl_CarForms.PrimaryGrid.Columns[6].HeaderText = ((LangArEn == 0) ? "رقم السيارة" : "Car No");
            superGridControl_CarAllownces.PrimaryGrid.Columns[0].HeaderText = ((LangArEn == 0) ? "الأيام" : "Days");
            superGridControl_CarAllownces.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "تاريخ الإنتهاء" : "Expir Date");
            superGridControl_CarAllownces.PrimaryGrid.Columns[2].HeaderText = ((LangArEn == 0) ? "تاريخ الإصدار" : "Release Date");
            superGridControl_CarAllownces.PrimaryGrid.Columns[3].HeaderText = ((LangArEn == 0) ? "رقم التأمين" : "Allownce No");
            superGridControl_CarAllownces.PrimaryGrid.Columns[4].HeaderText = ((LangArEn == 0) ? "ماركة السيارة" : "Car Type");
            superGridControl_CarAllownces.PrimaryGrid.Columns[5].HeaderText = ((LangArEn == 0) ? "اسم السيارة" : "Car Name");
            superGridControl_CarAllownces.PrimaryGrid.Columns[6].HeaderText = ((LangArEn == 0) ? "رقم السيارة" : "Car No");
            superGridControl_Secretariats.PrimaryGrid.Columns[0].HeaderText = ((LangArEn == 0) ? "الأيام" : "Days");
            superGridControl_Secretariats.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "الملاحظات" : "Note");
            superGridControl_Secretariats.PrimaryGrid.Columns[2].HeaderText = ((LangArEn == 0) ? "تاريخ التسليم" : "Delivery Date");
            superGridControl_Secretariats.PrimaryGrid.Columns[3].HeaderText = ((LangArEn == 0) ? "تاريخ الإستلام" : "Receipt Date");
            superGridControl_Secretariats.PrimaryGrid.Columns[4].HeaderText = ((LangArEn == 0) ? "نوع الأمانة" : "Secretariats Type");
            superGridControl_Secretariats.PrimaryGrid.Columns[5].HeaderText = ((LangArEn == 0) ? "اسم الموظف" : "Employee Name");
            superGridControl_Secretariats.PrimaryGrid.Columns[6].HeaderText = ((LangArEn == 0) ? "رقم الموظف" : "Emp No");
            superGridControl_VisaGoBack.PrimaryGrid.Columns[0].HeaderText = ((LangArEn == 0) ? "الأيام" : "Days");
            superGridControl_VisaGoBack.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "تاريخ الإنتهاء" : "Expir Date");
            superGridControl_VisaGoBack.PrimaryGrid.Columns[2].HeaderText = ((LangArEn == 0) ? "تاريخ الإصدار" : "Release Date");
            superGridControl_VisaGoBack.PrimaryGrid.Columns[3].HeaderText = ((LangArEn == 0) ? "مصدرها" : "Source");
            superGridControl_VisaGoBack.PrimaryGrid.Columns[4].HeaderText = ((LangArEn == 0) ? "رقم التأشيرة" : "Visa No");
            superGridControl_VisaGoBack.PrimaryGrid.Columns[5].HeaderText = ((LangArEn == 0) ? "اسم الموظف" : "Employee Name");
            superGridControl_VisaGoBack.PrimaryGrid.Columns[6].HeaderText = ((LangArEn == 0) ? "رقم الموظف" : "Emp No");
            superGridControl_Id.PrimaryGrid.Columns[0].Width = 60;
            superGridControl_Id.PrimaryGrid.Columns[1].Width = 90;
            superGridControl_Id.PrimaryGrid.Columns[2].Width = 90;
            superGridControl_Id.PrimaryGrid.Columns[3].Width = 120;
            superGridControl_Id.PrimaryGrid.Columns[4].Width = 120;
            superGridControl_Id.PrimaryGrid.Columns[5].Width = 260;
            superGridControl_Id.PrimaryGrid.Columns[6].Width = 100;
            superGridControl_Forms.PrimaryGrid.Columns[0].Width = 60;
            superGridControl_Forms.PrimaryGrid.Columns[1].Width = 90;
            superGridControl_Forms.PrimaryGrid.Columns[2].Width = 90;
            superGridControl_Forms.PrimaryGrid.Columns[3].Width = 120;
            superGridControl_Forms.PrimaryGrid.Columns[4].Width = 120;
            superGridControl_Forms.PrimaryGrid.Columns[5].Width = 260;
            superGridControl_Forms.PrimaryGrid.Columns[6].Width = 100;
            superGridControl_Passport.PrimaryGrid.Columns[0].Width = 60;
            superGridControl_Passport.PrimaryGrid.Columns[1].Width = 90;
            superGridControl_Passport.PrimaryGrid.Columns[2].Width = 90;
            superGridControl_Passport.PrimaryGrid.Columns[3].Width = 120;
            superGridControl_Passport.PrimaryGrid.Columns[4].Width = 120;
            superGridControl_Passport.PrimaryGrid.Columns[5].Width = 260;
            superGridControl_Passport.PrimaryGrid.Columns[6].Width = 100;
            superGridControl_Lisnese.PrimaryGrid.Columns[0].Width = 60;
            superGridControl_Lisnese.PrimaryGrid.Columns[1].Width = 90;
            superGridControl_Lisnese.PrimaryGrid.Columns[2].Width = 90;
            superGridControl_Lisnese.PrimaryGrid.Columns[3].Width = 120;
            superGridControl_Lisnese.PrimaryGrid.Columns[4].Width = 120;
            superGridControl_Lisnese.PrimaryGrid.Columns[5].Width = 260;
            superGridControl_Lisnese.PrimaryGrid.Columns[6].Width = 100;
            superGridControl_Allownc.PrimaryGrid.Columns[0].Width = 60;
            superGridControl_Allownc.PrimaryGrid.Columns[1].Width = 90;
            superGridControl_Allownc.PrimaryGrid.Columns[2].Width = 90;
            superGridControl_Allownc.PrimaryGrid.Columns[3].Width = 120;
            superGridControl_Allownc.PrimaryGrid.Columns[4].Width = 120;
            superGridControl_Allownc.PrimaryGrid.Columns[5].Width = 260;
            superGridControl_Allownc.PrimaryGrid.Columns[6].Width = 100;
            superGridControl_Contract.PrimaryGrid.Columns[0].Width = 60;
            superGridControl_Contract.PrimaryGrid.Columns[1].Width = 90;
            superGridControl_Contract.PrimaryGrid.Columns[2].Width = 90;
            superGridControl_Contract.PrimaryGrid.Columns[3].Width = 120;
            superGridControl_Contract.PrimaryGrid.Columns[4].Width = 120;
            superGridControl_Contract.PrimaryGrid.Columns[5].Width = 260;
            superGridControl_Contract.PrimaryGrid.Columns[6].Width = 100;
            superGridControl_FamilyPassport.PrimaryGrid.Columns[0].Width = 60;
            superGridControl_FamilyPassport.PrimaryGrid.Columns[1].Width = 90;
            superGridControl_FamilyPassport.PrimaryGrid.Columns[2].Width = 90;
            superGridControl_FamilyPassport.PrimaryGrid.Columns[3].Width = 120;
            superGridControl_FamilyPassport.PrimaryGrid.Columns[4].Width = 120;
            superGridControl_FamilyPassport.PrimaryGrid.Columns[5].Width = 260;
            superGridControl_FamilyPassport.PrimaryGrid.Columns[6].Width = 100;
            superGridControl_EmployeeVac.PrimaryGrid.Columns[0].Width = 60;
            superGridControl_EmployeeVac.PrimaryGrid.Columns[1].Width = 90;
            superGridControl_EmployeeVac.PrimaryGrid.Columns[2].Width = 90;
            superGridControl_EmployeeVac.PrimaryGrid.Columns[3].Width = 120;
            superGridControl_EmployeeVac.PrimaryGrid.Columns[4].Width = 120;
            superGridControl_EmployeeVac.PrimaryGrid.Columns[5].Width = 260;
            superGridControl_EmployeeVac.PrimaryGrid.Columns[6].Width = 100;
            superGridControl_BossRecord.PrimaryGrid.Columns[0].Width = 60;
            superGridControl_BossRecord.PrimaryGrid.Columns[1].Width = 90;
            superGridControl_BossRecord.PrimaryGrid.Columns[2].Width = 90;
            superGridControl_BossRecord.PrimaryGrid.Columns[3].Width = 120;
            superGridControl_BossRecord.PrimaryGrid.Columns[4].Width = 120;
            superGridControl_BossRecord.PrimaryGrid.Columns[5].Width = 260;
            superGridControl_BossRecord.PrimaryGrid.Columns[6].Width = 100;
            superGridControl_RecordBranch.PrimaryGrid.Columns[0].Width = 60;
            superGridControl_RecordBranch.PrimaryGrid.Columns[1].Width = 90;
            superGridControl_RecordBranch.PrimaryGrid.Columns[2].Width = 90;
            superGridControl_RecordBranch.PrimaryGrid.Columns[3].Width = 120;
            superGridControl_RecordBranch.PrimaryGrid.Columns[4].Width = 120;
            superGridControl_RecordBranch.PrimaryGrid.Columns[5].Width = 260;
            superGridControl_RecordBranch.PrimaryGrid.Columns[6].Width = 100;
            superGridControl_AllownceDept.PrimaryGrid.Columns[0].Width = 60;
            superGridControl_AllownceDept.PrimaryGrid.Columns[1].Width = 90;
            superGridControl_AllownceDept.PrimaryGrid.Columns[2].Width = 90;
            superGridControl_AllownceDept.PrimaryGrid.Columns[3].Width = 120;
            superGridControl_AllownceDept.PrimaryGrid.Columns[4].Width = 120;
            superGridControl_AllownceDept.PrimaryGrid.Columns[5].Width = 260;
            superGridControl_AllownceDept.PrimaryGrid.Columns[6].Width = 100;
            superGridControl_ZakaaDept.PrimaryGrid.Columns[0].Width = 60;
            superGridControl_ZakaaDept.PrimaryGrid.Columns[1].Width = 90;
            superGridControl_ZakaaDept.PrimaryGrid.Columns[2].Width = 90;
            superGridControl_ZakaaDept.PrimaryGrid.Columns[3].Width = 120;
            superGridControl_ZakaaDept.PrimaryGrid.Columns[4].Width = 120;
            superGridControl_ZakaaDept.PrimaryGrid.Columns[5].Width = 260;
            superGridControl_ZakaaDept.PrimaryGrid.Columns[6].Width = 100;
            superGridControl_CarForms.PrimaryGrid.Columns[0].Width = 60;
            superGridControl_CarForms.PrimaryGrid.Columns[1].Width = 90;
            superGridControl_CarForms.PrimaryGrid.Columns[2].Width = 90;
            superGridControl_CarForms.PrimaryGrid.Columns[3].Width = 120;
            superGridControl_CarForms.PrimaryGrid.Columns[4].Width = 120;
            superGridControl_CarForms.PrimaryGrid.Columns[5].Width = 260;
            superGridControl_CarForms.PrimaryGrid.Columns[6].Width = 100;
            superGridControl_CarAllownces.PrimaryGrid.Columns[0].Width = 60;
            superGridControl_CarAllownces.PrimaryGrid.Columns[1].Width = 90;
            superGridControl_CarAllownces.PrimaryGrid.Columns[2].Width = 90;
            superGridControl_CarAllownces.PrimaryGrid.Columns[3].Width = 120;
            superGridControl_CarAllownces.PrimaryGrid.Columns[4].Width = 120;
            superGridControl_CarAllownces.PrimaryGrid.Columns[5].Width = 260;
            superGridControl_CarAllownces.PrimaryGrid.Columns[6].Width = 100;
            superGridControl_Secretariats.PrimaryGrid.Columns[0].Width = 60;
            superGridControl_Secretariats.PrimaryGrid.Columns[1].Width = 140;
            superGridControl_Secretariats.PrimaryGrid.Columns[2].Width = 80;
            superGridControl_Secretariats.PrimaryGrid.Columns[3].Width = 80;
            superGridControl_Secretariats.PrimaryGrid.Columns[4].Width = 120;
            superGridControl_Secretariats.PrimaryGrid.Columns[5].Width = 260;
            superGridControl_Secretariats.PrimaryGrid.Columns[6].Width = 100;
            superGridControl_VisaGoBack.PrimaryGrid.Columns[0].Width = 60;
            superGridControl_VisaGoBack.PrimaryGrid.Columns[1].Width = 140;
            superGridControl_VisaGoBack.PrimaryGrid.Columns[2].Width = 80;
            superGridControl_VisaGoBack.PrimaryGrid.Columns[3].Width = 80;
            superGridControl_VisaGoBack.PrimaryGrid.Columns[4].Width = 120;
            superGridControl_VisaGoBack.PrimaryGrid.Columns[5].Width = 260;
            superGridControl_VisaGoBack.PrimaryGrid.Columns[6].Width = 100;
            superGridControl_BossRecord.PrimaryGrid.ReadOnly = true;
            superGridControl_AllownceDept.PrimaryGrid.ReadOnly = true;
            superGridControl_ZakaaDept.PrimaryGrid.ReadOnly = true;
            superGridControl_CarAllownces.PrimaryGrid.ReadOnly = true;
            superGridControl_CarForms.PrimaryGrid.ReadOnly = true;
            superGridControl_Contract.PrimaryGrid.ReadOnly = true;
            superGridControl_EmployeeVac.PrimaryGrid.ReadOnly = true;
            superGridControl_FamilyPassport.PrimaryGrid.ReadOnly = true;
            superGridControl_Forms.PrimaryGrid.ReadOnly = true;
            superGridControl_Id.PrimaryGrid.ReadOnly = true;
            superGridControl_Lisnese.PrimaryGrid.ReadOnly = true;
            superGridControl_Passport.PrimaryGrid.ReadOnly = true;
            superGridControl_Allownc.PrimaryGrid.ReadOnly = true;
            superGridControl_RecordBranch.PrimaryGrid.ReadOnly = true;
            superGridControl_Secretariats.PrimaryGrid.ReadOnly = true;
            superGridControl_VisaGoBack.PrimaryGrid.ReadOnly = true;
            if (VarGeneral.Settings_Sys.IsAlarmEmpDoc.Value)
            {
                FillEmpDoc();
            }
            if (VarGeneral.Settings_Sys.IsAlarmEmpContract.Value)
            {
                FillEmpContract();
            }
            if (VarGeneral.Settings_Sys.IsAlarmFamilyPassport.Value)
            {
                FillEmpFamily();
            }
            if (VarGeneral.Settings_Sys.IsAlarmEndVaction.Value)
            {
                FillEmpVac();
            }
            if (VarGeneral.Settings_Sys.IsAlarmGuarantorDoc.Value)
            {
                FillBoss();
            }
            if (VarGeneral.Settings_Sys.IsAlarmCarDoc.Value)
            {
                FillCars();
            }
            if (VarGeneral.Settings_Sys.IsAlarmSecretariatsDoc.Value)
            {
                FillSecretariats();
            }
            if (VarGeneral.Settings_Sys.IsAlarmVisaGoBack.Value)
            {
                FillVisaGoBack();
            }
            if (VarGeneral.Settings_Sys.IsAlarmDepts.Value)
            {
                FillDept();
            }
        }
        private void FrmAutoAlarm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void FrmAutoAlarm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void RepActive(SuperGridControl vGridData, string vRepName)
        {
            try
            {
                FrmReportsViewer frm = new FrmReportsViewer();
                frm.Tag = LangArEn;
                frm.Repvalue = "PrintAutoAlarm";
                VarGeneral.vTitle = Text;
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dt.Columns.Add("Col_1", typeof(string));
                dt.Columns.Add("Col_2", typeof(string));
                dt.Columns.Add("Col_3", typeof(string));
                dt.Columns.Add("Col_4", typeof(string));
                dt.Columns.Add("Col_5", typeof(string));
                dt.Columns.Add("Col_6", typeof(string));
                foreach (GridRow dgv in vGridData.PrimaryGrid.Rows)
                {
                    dt.Rows.Add(dgv.Cells[1].Value, dgv.Cells[2].Value, dgv.Cells[3].Value, dgv.Cells[4].Value, dgv.Cells[5].Value, dgv.Cells[6].Value);
                }
                ds.Tables.Add(dt);
                VarGeneral.RepData = ds;
                try
                {
                    VarGeneral.AutoAlarmitms = new List<string>();
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms[1] = vGridData.PrimaryGrid.Columns[1].HeaderText;
                    VarGeneral.AutoAlarmitms[2] = vGridData.PrimaryGrid.Columns[2].HeaderText;
                    VarGeneral.AutoAlarmitms[3] = vGridData.PrimaryGrid.Columns[3].HeaderText;
                    VarGeneral.AutoAlarmitms[4] = vGridData.PrimaryGrid.Columns[4].HeaderText;
                    VarGeneral.AutoAlarmitms[5] = vGridData.PrimaryGrid.Columns[5].HeaderText;
                    VarGeneral.AutoAlarmitms[6] = vGridData.PrimaryGrid.Columns[6].HeaderText;
                    VarGeneral.AutoAlarmitms[7] = vRepName ?? "";
                }
                catch
                {
                }
                frm.TopMost = true;
                frm.ShowDialog();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("RepActive:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ToolStripMenuItem_PrintEmpID_Click(object sender, EventArgs e)
        {
            if (superGridControl_Id.PrimaryGrid.Rows.Count > 0)
            {
                RepActive(superGridControl_Id, tabItem_ID.Text);
            }
            else
            {
                MessageBox.Show((LangArEn == 0) ? "لا توجد بيانات مدخلة للطباعة" : "No Find Data For Print", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void ToolStripMenuItem_PrintEmpPassport_Click(object sender, EventArgs e)
        {
            if (superGridControl_Passport.PrimaryGrid.Rows.Count > 0)
            {
                RepActive(superGridControl_Passport, tabItem_Passport.Text);
            }
            else
            {
                MessageBox.Show((LangArEn == 0) ? "لا توجد بيانات مدخلة للطباعة" : "No Find Data For Print", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void ToolStripMenuItem_PrintEmpLicense_Click(object sender, EventArgs e)
        {
            if (superGridControl_Lisnese.PrimaryGrid.Rows.Count > 0)
            {
                RepActive(superGridControl_Lisnese, tabItem_License.Text);
            }
            else
            {
                MessageBox.Show((LangArEn == 0) ? "لا توجد بيانات مدخلة للطباعة" : "No Find Data For Print", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void ToolStripMenuItem_PrintEmpForms_Click(object sender, EventArgs e)
        {
            if (superGridControl_Forms.PrimaryGrid.Rows.Count > 0)
            {
                RepActive(superGridControl_Forms, tabItem_EmpForms.Text);
            }
            else
            {
                MessageBox.Show((LangArEn == 0) ? "لا توجد بيانات مدخلة للطباعة" : "No Find Data For Print", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void ToolStripMenuItem_PrintEmpAllownce_Click(object sender, EventArgs e)
        {
            if (superGridControl_Allownc.PrimaryGrid.Rows.Count > 0)
            {
                RepActive(superGridControl_Allownc, tabItem_EmpAllownce.Text);
            }
            else
            {
                MessageBox.Show((LangArEn == 0) ? "لا توجد بيانات مدخلة للطباعة" : "No Find Data For Print", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void ToolStripMenuItem_PrintContract_Click(object sender, EventArgs e)
        {
            if (superGridControl_Contract.PrimaryGrid.Rows.Count > 0)
            {
                RepActive(superGridControl_Contract, tabItem_EmployeeContract.Text);
            }
            else
            {
                MessageBox.Show((LangArEn == 0) ? "لا توجد بيانات مدخلة للطباعة" : "No Find Data For Print", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void ToolStripMenuItem_PrintVac_Click(object sender, EventArgs e)
        {
            if (superGridControl_EmployeeVac.PrimaryGrid.Rows.Count > 0)
            {
                RepActive(superGridControl_EmployeeVac, tabItem_VacDoc.Text);
            }
            else
            {
                MessageBox.Show((LangArEn == 0) ? "لا توجد بيانات مدخلة للطباعة" : "No Find Data For Print", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void ToolStripMenuItem_PrintFamilyPassport_Click(object sender, EventArgs e)
        {
            if (superGridControl_FamilyPassport.PrimaryGrid.Rows.Count > 0)
            {
                RepActive(superGridControl_FamilyPassport, tabItem_FamilyDoc.Text);
            }
            else
            {
                MessageBox.Show((LangArEn == 0) ? "لا توجد بيانات مدخلة للطباعة" : "No Find Data For Print", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void ToolStripMenuItem_BossRecord_Click(object sender, EventArgs e)
        {
            if (superGridControl_BossRecord.PrimaryGrid.Rows.Count > 0)
            {
                RepActive(superGridControl_BossRecord, tabItem_BossDoc.Text);
            }
            else
            {
                MessageBox.Show((LangArEn == 0) ? "لا توجد بيانات مدخلة للطباعة" : "No Find Data For Print", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void ToolStripMenuItem_DeptAllownce_Click(object sender, EventArgs e)
        {
            if (superGridControl_AllownceDept.PrimaryGrid.Rows.Count > 0)
            {
                RepActive(superGridControl_AllownceDept, tabItem_DeptAllownce.Text);
            }
            else
            {
                MessageBox.Show((LangArEn == 0) ? "لا توجد بيانات مدخلة للطباعة" : "No Find Data For Print", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void ToolStripMenuItem_DeptZakaa_Click(object sender, EventArgs e)
        {
            if (superGridControl_ZakaaDept.PrimaryGrid.Rows.Count > 0)
            {
                RepActive(superGridControl_ZakaaDept, tabItem_DeptZakaa.Text);
            }
            else
            {
                MessageBox.Show((LangArEn == 0) ? "لا توجد بيانات مدخلة للطباعة" : "No Find Data For Print", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void ToolStripMenuItem_CarsForms_Click(object sender, EventArgs e)
        {
            if (superGridControl_CarForms.PrimaryGrid.Rows.Count > 0)
            {
                RepActive(superGridControl_CarForms, tabItem_CarForms.Text);
            }
            else
            {
                MessageBox.Show((LangArEn == 0) ? "لا توجد بيانات مدخلة للطباعة" : "No Find Data For Print", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void ToolStripMenuItem_CarsAllownce_Click(object sender, EventArgs e)
        {
            if (superGridControl_CarAllownces.PrimaryGrid.Rows.Count > 0)
            {
                RepActive(superGridControl_CarAllownces, tabItem_CarAllownce.Text);
            }
            else
            {
                MessageBox.Show((LangArEn == 0) ? "لا توجد بيانات مدخلة للطباعة" : "No Find Data For Print", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void ToolStripMenuItem_SecretariatsDoc_Click(object sender, EventArgs e)
        {
            if (superGridControl_Secretariats.PrimaryGrid.Rows.Count > 0)
            {
                RepActive(superGridControl_Secretariats, tabItem_Secretariats.Text);
            }
            else
            {
                MessageBox.Show((LangArEn == 0) ? "لا توجد بيانات مدخلة للطباعة" : "No Find Data For Print", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void ToolStripMenuItem_VisaGoBack_Click(object sender, EventArgs e)
        {
            if (superGridControl_VisaGoBack.PrimaryGrid.Rows.Count > 0)
            {
                RepActive(superGridControl_VisaGoBack, ToolStripMenuItem_VisaGoBack.Text);
            }
            else
            {
                MessageBox.Show((LangArEn == 0) ? "لا توجد بيانات مدخلة للطباعة" : "No Find Data For Print", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
