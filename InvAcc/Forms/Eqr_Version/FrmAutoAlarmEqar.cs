using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using Library.RepShow;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmAutoAlarmEqar : Form
    { void avs(int arln)

{ 
 tabControl2.Text=   (arln == 0 ? "  tabControl2  " : "  tabControl2") ; tabItem_Contracts.Text=   (arln == 0 ? "  تنبيه بالعقود  " : "  Contract alert") ; tabItem_Rents.Text=   (arln == 0 ? "  تنبيه بالإيجار  " : "  Rent Alert") ; tabItem_EqarDoc.Text=   (arln == 0 ? "    " : "    ") ; Text = "تنبيهات الــــوثائق";this.Text=   (arln == 0 ? "  تنبيهات الــــوثائق  " : "  Document alerts") ;}
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
        private SuperGridControl superGridControl_Contracts;
        private TabItem tabItem_Contracts;
        private TabControlPanel tabControlPanel10;
        private SuperGridControl superGridControl_Rent;
        private TabItem tabItem_Rents;
        private TabItem tabItem_EqarDoc;
        private TabControlPanel tabControlPanel16;
        private TabControlPanel tabControlPanel32;
        private TabControlPanel tabControlPanel18;
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
        public FrmAutoAlarmEqar()
        {
            InitializeComponent();this.Load += langloads;
            try
            {
                tabItem_EqarDoc.Parent.Visible = false;
                SettingGrid();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FrmAutoAlarmEqar:", error, enable: true);
            }
        }
        private void FrmAutoAlarmEqar_Load(object sender, EventArgs e)
        {
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmAutoAlarmEqar));
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
                if (superGridControl_Contracts.PrimaryGrid.Rows.Count <= 0 && superGridControl_Rent.PrimaryGrid.Rows.Count <= 0)
                {
                    Close();
                }
                try
                {
                    tabControl2.SelectedTabIndex = VarGeneral.vTabAutoAlarm;
                    if (superGridControl_Contracts.PrimaryGrid.Rows.Count <= 0)
                    {
                        tabControl2.SelectedTabIndex = 1;
                    }
                }
                catch
                {
                    tabControl2.SelectedTabIndex = 0;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
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
        private void FillEqarDoc()
        {
            RepShow _RepShow = new RepShow();
            _RepShow.Tables = "  T_TenantPayment left JOIN\r\n                                  T_GDHEAD ON T_TenantPayment.SndNo = T_GDHEAD.gdhead_ID INNER JOIN\r\n                                  T_TenantContract ON T_TenantPayment.tenantContract_ID = T_TenantContract.ContractID INNER JOIN\r\n                                  T_Tenant ON T_TenantContract.tenant_ID = T_Tenant.tenantID INNER JOIN\r\n                                  T_EqarsData ON T_TenantContract.Eqar_ID = T_EqarsData.EqarID INNER JOIN\r\n                                  T_AinsData ON T_TenantContract.Ain_ID = T_AinsData.AinID AND T_EqarsData.EqarID = T_AinsData.EqarID ";
            string Fields = "  T_TenantPayment.PaymentID,T_Tenant.NameA,T_Tenant.NameE,T_Tenant.tenantNo ,T_TenantPayment.PayMonth,T_TenantPayment.Value ,T_AinsData.AinNo ,T_EqarsData.EqarNo ,T_GDHEAD.gdRcptID  ";
            _RepShow.Rule = " where T_TenantPayment.SndNo is null AND DATEADD(DAY, -" + VarGeneral.Settings_Sys.EqarAlarmDayPay.Value + ", CONVERT(DATE,  PayMonth + '/01')) <= CASE WHEN substring( PayMonth + '/01',1,4) < 1800 THEN CONVERT(DATE, '" + VarGeneral.Hdate + "') ELSE '" + VarGeneral.Gdate + "' END ";
            _RepShow.Fields = Fields;
            try
            {
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
            }
            catch (Exception)
            {
                VarGeneral.RepData = new DataSet();
            }
            for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
            {
                row = new GridRow();
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                superGridControl_Rent.PrimaryGrid.Rows.Add(row);
                superGridControl_Rent.PrimaryGrid.GetCell(i, 0).Value = VarGeneral.RepData.Tables[0].Rows[i]["PayMonth"];
                superGridControl_Rent.PrimaryGrid.GetCell(i, 1).Value = VarGeneral.RepData.Tables[0].Rows[i]["Value"];
                superGridControl_Rent.PrimaryGrid.GetCell(i, 2).Value = VarGeneral.RepData.Tables[0].Rows[i]["AinNo"];
                superGridControl_Rent.PrimaryGrid.GetCell(i, 3).Value = VarGeneral.RepData.Tables[0].Rows[i]["EqarNo"];
                superGridControl_Rent.PrimaryGrid.GetCell(i, 4).Value = ((LangArEn == 0) ? VarGeneral.RepData.Tables[0].Rows[i]["NameA"] : VarGeneral.RepData.Tables[0].Rows[i]["NameE"]);
                superGridControl_Rent.PrimaryGrid.GetCell(i, 5).Value = VarGeneral.RepData.Tables[0].Rows[i]["tenantNo"];
            }
            _RepShow = new RepShow();
            _RepShow.Tables = "  T_TenantContract INNER JOIN\r\n                                  T_Tenant ON T_TenantContract.tenant_ID = T_Tenant.tenantID INNER JOIN\r\n                                  T_EqarsData ON T_TenantContract.Eqar_ID = T_EqarsData.EqarID INNER JOIN\r\n                                  T_AinsData ON T_TenantContract.Ain_ID = T_AinsData.AinID AND T_EqarsData.EqarID = T_AinsData.EqarID ";
            Fields = " T_TenantContract.ContractNo, T_Tenant.tenantNo, T_Tenant.NameA, T_Tenant.NameE, T_TenantContract.ContractStart, T_TenantContract.ContractEnd, T_AinsData.AinNo, T_EqarsData.EqarNo ";
            _RepShow.Rule = " where DATEADD(DAY, -" + VarGeneral.Settings_Sys.EqarAlarmContractEnd.Value + ", CONVERT(DATE, ContractEnd)) <= CASE WHEN substring( ContractEnd,1,4) < 1800 THEN CONVERT(DATE, '" + VarGeneral.Hdate + "') ELSE '" + VarGeneral.Gdate + "' END ";
            _RepShow.Fields = Fields;
            try
            {
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
            }
            catch (Exception)
            {
                VarGeneral.RepData = new DataSet();
            }
            for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
            {
                row = new GridRow();
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                superGridControl_Contracts.PrimaryGrid.Rows.Add(row);
                superGridControl_Contracts.PrimaryGrid.GetCell(i, 0).Value = VarGeneral.RepData.Tables[0].Rows[i]["ContractEnd"];
                superGridControl_Contracts.PrimaryGrid.GetCell(i, 1).Value = VarGeneral.RepData.Tables[0].Rows[i]["ContractStart"];
                superGridControl_Contracts.PrimaryGrid.GetCell(i, 2).Value = ((LangArEn == 0) ? VarGeneral.RepData.Tables[0].Rows[i]["NameA"] : VarGeneral.RepData.Tables[0].Rows[i]["NameE"]);
                superGridControl_Contracts.PrimaryGrid.GetCell(i, 3).Value = VarGeneral.RepData.Tables[0].Rows[i]["tenantNo"];
                superGridControl_Contracts.PrimaryGrid.GetCell(i, 4).Value = VarGeneral.RepData.Tables[0].Rows[i]["ContractNo"];
            }
        }
        private void SettingGrid()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                tabItem_EqarDoc.Text = "التنبيهــــات";
                tabItem_Contracts.Text = "التنبيه التلقائي عن تحصيل العقود المنتهي قبل اقل من " + VarGeneral.Settings_Sys.EqarAlarmContractEnd.Value;
                tabItem_Rents.Text = "التنبيه التلقائي عن تحصيل الأيجار المنتهي قبل اقل من " + VarGeneral.Settings_Sys.EqarAlarmDayPay.Value;
                Text = "تنبيهات الــــوثائق";
            }
            else
            {
                tabItem_EqarDoc.Text = "Alarms";
                tabItem_Contracts.Text = "ID";
                tabItem_Rents.Text = "Passport";
                Text = "Documents Alarms";
            }
            superGridControl_Contracts.PrimaryGrid.Columns[0].HeaderText = ((LangArEn == 0) ? "تاريخ نهاية العقد" : "Days");
            superGridControl_Contracts.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "تاريخ بداية العقد" : "Expir Date");
            superGridControl_Contracts.PrimaryGrid.Columns[2].HeaderText = ((LangArEn == 0) ? "إسم المستأجر" : "Release Date");
            superGridControl_Contracts.PrimaryGrid.Columns[3].HeaderText = ((LangArEn == 0) ? "رقم المستأجر" : "Place of Issue");
            superGridControl_Contracts.PrimaryGrid.Columns[4].HeaderText = ((LangArEn == 0) ? "رقم العقد" : "ID No");
            superGridControl_Rent.PrimaryGrid.Columns[0].HeaderText = ((LangArEn == 0) ? "تاريخه" : "Days");
            superGridControl_Rent.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "المبلغ المستحق" : "Expir Date");
            superGridControl_Rent.PrimaryGrid.Columns[2].HeaderText = ((LangArEn == 0) ? "رقم العين" : "Release Date");
            superGridControl_Rent.PrimaryGrid.Columns[3].HeaderText = ((LangArEn == 0) ? "رقم العقار" : "Place of Issue");
            superGridControl_Rent.PrimaryGrid.Columns[4].HeaderText = ((LangArEn == 0) ? "إسم المستأجر" : "Passport No");
            superGridControl_Rent.PrimaryGrid.Columns[5].HeaderText = ((LangArEn == 0) ? "رقم المستأجر" : "Name");
            superGridControl_Contracts.PrimaryGrid.ReadOnly = true;
            superGridControl_Rent.PrimaryGrid.ReadOnly = true;
            FillEqarDoc();
        }
        private void FrmAutoAlarmEqar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void FrmAutoAlarmEqar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void superGridControl_Contracts_Click(object sender, EventArgs e)
        {

        }
    }
}
