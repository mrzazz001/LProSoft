using CrystalDecisions.CrystalReports.Engine;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using Framework.Data;
using Framework.Date;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
//using InvAcc.Reports;
//using InvAcc.ReportsCasheir;
//using InvAcc.ReportsCasheirE;
//using InvAcc.ReportsE;
using Library.RepShow;
using Microsoft.Win32;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmRelayBoxes : Form
    { void avs(int arln)

{ 
}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
        }
   
       // private IContainer components = null;
        private GroupPanel groupPanel2;
        private ComboBoxEx CmbToBox;
        private ComboBoxEx CmbFromBox;
        internal Label label2;
        private Label label1;
        private ComboBoxEx CmbUser;
        private Label label3;
        private GroupPanel groupPanel_Balance;
        private DoubleInput txtAmount;
        internal Label label8;
        private ButtonX ButOk;
        private Label label_Balance;
        private ButtonX buttonX_Close;
        private GroupPanel groupPanel_SendOption;
        private CheckBoxX chk2;
        private CheckBoxX chk1;
        private MaskedTextBox txtTime;
        internal Label label4;
        private MaskedTextBox txtGDate;
        private MaskedTextBox txtHDate;
        private ButtonX button_RepAccFrom;
        private ButtonX button_RepAccTo;
        private GroupBox groupBox2;
        public RadioButton RButShort;
        public RadioButton RButDet;
        private CheckBoxX checBox_Acc2;
        private CheckBoxX checBox_Acc1;
        private ComboBoxEx CmbCurr;
        public Dictionary<string, FrmRelayBoxes.ColumnDictinary> columns_Names_visible = new Dictionary<string, FrmRelayBoxes.ColumnDictinary>();
        public Dictionary<string, FrmRelayBoxes.ColumnDictinary> columns_Names_visible2 = new Dictionary<string, FrmRelayBoxes.ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private T_AccDef _AccDefBind = new T_AccDef();
        private int LangArEn = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
#pragma warning disable CS0414 // The field 'FrmRelayBoxes.FlagUpdate' is assigned but its value is never used
        private string FlagUpdate = "";
#pragma warning restore CS0414 // The field 'FrmRelayBoxes.FlagUpdate' is assigned but its value is never used
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        private T_SYSSETTING _SysSetting = new T_SYSSETTING();
        private List<T_SYSSETTING> listSysSetting = new List<T_SYSSETTING>();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private List<T_INVSETTING> listInvSetting = new List<T_INVSETTING>();
        private T_GDHEAD _GdHead = new T_GDHEAD();
        private List<T_GDHEAD> listGdHead = new List<T_GDHEAD>();
        private T_GDDET _GdDet = new T_GDDET();
        private List<T_GDDET> listGdDet = new List<T_GDDET>();
        private List<T_GdAuto> listGdAuto = new List<T_GdAuto>();
        private T_GdAuto _GdAuto = new T_GdAuto();
        private List<T_Company> listCompany = new List<T_Company>();
        private T_Company _Company = new T_Company();
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private T_User Permmission = new T_User();
        private ScriptNumber ScriptNumber1 = new ScriptNumber();
        protected bool CanUpdate
        {
            get
            {
                return this.canUpdate;
            }
            set
            {
                this.canUpdate = value;
            }
        }
        private Stock_DataDataContext db
        {
            get
            {
                if (this.dbInstance == null)
                {
                    this.dbInstance = new Stock_DataDataContext(VarGeneral.BranchCS);
                }
                return this.dbInstance;
            }
        }
        private Rate_DataDataContext dbc
        {
            get
            {
                if (this.dbInstanceRate == null)
                {
                    this.dbInstanceRate = new Rate_DataDataContext(VarGeneral.BranchRt);
                }
                return this.dbInstanceRate;
            }
        }
        public FormState State
        {
            get
            {
                return this.statex;
            }
            set
            {
                this.statex = value;
            }
        }
        public FrmRelayBoxes()
        {
            this.InitializeComponent();this.Load += langloads;
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
            {
                this.txtAmount.DisplayFormat = VarGeneral.DicemalMask;
            }
        }
        private void _Procces(int _acc)
        {
            try
            {
                RepShow _RepShow = new RepShow()
                {
                    Tables = " T_GDDET LEFT OUTER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID  LEFT OUTER JOIN T_INVSETTING On T_GDHEAD.gdTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_SYSSETTING ON T_GDHEAD.CompanyID = T_SYSSETTING.SYSSETTING_ID"
                };
                string Fields = string.Concat(this.BuildFieldList(), " ,0 as DebitPervious,0 as CreditPervious,0 as BalancePervious");
                _RepShow.Rule = string.Concat(this.BuildRuleList(_acc), " order by T_GDHEAD.gdGDate");
                _RepShow.Fields = Fields;
                try
                {
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
                if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                {
                    try
                    {
                        FrmReportsViewer frm = new FrmReportsViewer()
                        {
                            Tag = this.LangArEn,
                            Repvalue = "Account"
                        };
                        if (!this.RButDet.Checked)
                        {
                            VarGeneral.itmDesIndex = 1;
                        }
                        else
                        {
                            VarGeneral.itmDesIndex = 0;
                        }
                        VarGeneral.vTitle = (this.LangArEn == 0 ? "كشف حساب" : "Account statement");
                        VarGeneral.itmDes = "";
                        VarGeneral._DTFrom = "";
                        VarGeneral._DTTo = "";
                        frm.TopMost = true;
                        frm.ShowDialog();
                    }
                    catch (Exception exception1)
                    {
                        Exception error = exception1;
                        VarGeneral.DebLog.writeLog("button_ShowRep_Click:", error, true);
                        MessageBox.Show(error.Message);
                    }
                }
                else
                {
                    MessageBox.Show((this.LangArEn == 0 ? "عفوا .. لا يوجد بيانات لعرضها في التقرير " : "Sorry .. there is no data to display in the report "), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception exception2)
            {
                MessageBox.Show(exception2.Message);
            }
            try
            {
                VarGeneral.itmDesIndex = 0;
            }
            catch
            {
            }
        }
     ReportDocument getdoc(string name)
        {
            string n = "";
            for (int i = 7; i < name.Length; i++)
                if (name[i] == '.')
                    n += "\\";
                else
                    n += name[i];
            n += ".rpt";
            ReportDocument MainCryRep = new ReportDocument();
            string spath = Path.GetFullPath(Application.StartupPath + "\\Rep\\" + n);
            MainCryRep.Load(spath);
            return MainCryRep;
        }
        private bool AttachFile(int _acc)
        {
            bool flag;
            try
            {
                RepShow _RepShow = new RepShow()
                {
                    Tables = " T_GDDET LEFT OUTER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID  LEFT OUTER JOIN T_INVSETTING On T_GDHEAD.gdTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_SYSSETTING ON T_GDHEAD.CompanyID = T_SYSSETTING.SYSSETTING_ID"
                };
                string Fields = this.BuildFieldList();
                _RepShow.Rule = string.Concat(this.BuildRuleList(_acc), " order by T_GDHEAD.gdGDate");
                _RepShow.Fields = Fields;
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                if (VarGeneral.RepData.Tables[0].Rows.Count > 0)
                {
                    VarGeneral.vTitle = (this.LangArEn == 0 ? "كشف حساب" : "Account statement");
                    ReportDocument MainCryRep = new ReportDocument();
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        if (VarGeneral.GeneralPrinter.nTyp_Setting.Substring(1, 1) == "0")
                        {
                            if (!this.RButDet.Checked)
                            {
                                MainCryRep = getdoc("InvAcc.Reports. RepAccountShort");
                            }
                            else
                            {
                                MainCryRep = getdoc("InvAcc.Reports.RepAccount");
                            }
                        }
                        else if (!this.RButDet.Checked)
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepAccountShort");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepAccount");
                        }
                    }
                    else if (VarGeneral.GeneralPrinter.nTyp_Setting.Substring(1, 1) == "0")
                    {
                        if (!this.RButDet.Checked)
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepAccountShort");
                        }
                        else
                        {
                            MainCryRep = getdoc("InvAcc.Reports.RepAccount");
                        }
                    }
                    else if (!this.RButDet.Checked)
                    {
                        MainCryRep = getdoc("InvAcc.Reports.RepAccountShort");
                    }
                    else
                    {
                        MainCryRep = getdoc("InvAcc.Reports.RepAccount");
                    }
                    ReportDocument rpt = MainCryRep;
                    rpt.SetDataSource(VarGeneral.RepData); ;
                    List<T_InfoTb> listInfotb = this.db.StockInfoList();
                    T_InfoTb _Infotb = listInfotb[0];
                    for (int iiCnt = 0; iiCnt < listInfotb.Count; iiCnt++)
                    {
                        _Infotb = listInfotb[iiCnt];
                        if ("lTrwes1" == _Infotb.fldFlag.ToString())
                        {
                            rpt.SetParameterValue("CompanyNameE", (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? _Infotb.fldValue : ""));
                        }
                        else if ("lTrwes2" == _Infotb.fldFlag.ToString())
                        {
                            rpt.SetParameterValue("CompanyAddressE", (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? _Infotb.fldValue : ""));
                        }
                        else if ("lTrwes3" == _Infotb.fldFlag.ToString())
                        {
                            rpt.SetParameterValue("CompanyTelE", (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? _Infotb.fldValue : ""));
                        }
                        else if ("lTrwes4" == _Infotb.fldFlag.ToString())
                        {
                            rpt.SetParameterValue("CompanyFaxE", (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? _Infotb.fldValue : ""));
                        }
                        else if ("rTrwes1" == _Infotb.fldFlag.ToString())
                        {
                            rpt.SetParameterValue("CompanyName", (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? _Infotb.fldValue : ""));
                        }
                        else if ("rTrwes2" == _Infotb.fldFlag.ToString())
                        {
                            rpt.SetParameterValue("CompanyAddress", (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? _Infotb.fldValue : ""));
                        }
                        else if ("rTrwes3" == _Infotb.fldFlag.ToString())
                        {
                            rpt.SetParameterValue("CompanyTel", (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? _Infotb.fldValue : ""));
                        }
                        else if ("rTrwes4" == _Infotb.fldFlag.ToString())
                        {
                            rpt.SetParameterValue("CompanyFax", (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? _Infotb.fldValue : ""));
                        }
                    }
                    rpt.SetParameterValue("CompanyPic", (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 9) ? "Show" : "Hide"));
                    rpt.SetParameterValue("vPage", (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 12) ? "Show" : "Hide"));
                    rpt.SetParameterValue("vTitle", VarGeneral.vTitle);
                    try
                    {
                        rpt.SetParameterValue("DTFrom", VarGeneral._DTFrom);
                    }
                    catch
                    {
                    }
                    try
                    {
                        rpt.SetParameterValue("DTTo", VarGeneral._DTTo);
                    }
                    catch
                    {
                    }
                    rpt.SetParameterValue("HDate", (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 11) ? VarGeneral.Hdate : ""));
                    rpt.SetParameterValue("GDate", (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 10) ? VarGeneral.Gdate : ""));
                    rpt.SetParameterValue("vSts", false);
                    rpt.SetParameterValue("vLines", 1);
                    try
                    {
                        rpt.SetParameterValue("OldBalance", VarGeneral.itmDes);
                    }
                    catch
                    {
                    }
                    //  rpt.Export(FastReport.Export.BIFF8.Excel2003Document,)//exporExportToDisk(ExportFormatType.Excel, string.Concat("_PROSOFTReportAcc_", _acc, ".xls"));
                }
                flag = true;
            }
            catch (Exception exception)
            {
                Exception ex = exception;
                VarGeneral.DebLog.writeLog("button_ShowRep_Click:", ex, true);
                MessageBox.Show(ex.Message);
                flag = false;
            }
            return flag;
        }
        private string BuildFieldList()
        {
            string str;
            str = (this.LangArEn != 0 ? string.Concat(" T_GDDET.AccNo as AccDef_No,(select Eng_Des from T_AccDef where T_AccDef.AccDef_No = T_GDDET.AccNo) as AccDefNm, T_GDHEAD.gdNo,T_INVSETTING.InvNamE as InvNm,T_GDHEAD.gdHDate,T_GDHEAD.gdGDate,T_GDDET.gdDesE as gdDes,CASE WHEN T_GDDET.gdValue > 0 THEN T_GDDET.gdValue ELSE 0 END as Debit,CASE WHEN T_GDDET.gdValue < 0 THEN Abs(T_GDDET.gdValue) ELSE 0 END as Credit,(Round(T_GDDET.gdValue,", (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2), ")) as Balance,T_SYSSETTING.LogImg ,T_SYSSETTING.Calendr, 0 as BalanceIsMove ") : string.Concat(" T_GDDET.AccNo as AccDef_No,(select Arb_Des from T_AccDef where T_AccDef.AccDef_No = T_GDDET.AccNo) as AccDefNm, T_GDHEAD.gdNo,T_INVSETTING.InvNamA as InvNm,T_GDHEAD.gdHDate,T_GDHEAD.gdGDate,T_GDDET.gdDes,CASE WHEN T_GDDET.gdValue > 0 THEN T_GDDET.gdValue ELSE 0 END as Debit,CASE WHEN T_GDDET.gdValue < 0 THEN Abs(T_GDDET.gdValue) ELSE 0 END as Credit,(Round(T_GDDET.gdValue,", (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2), ")) as Balance,T_SYSSETTING.LogImg ,T_SYSSETTING.Calendr, 0 as BalanceIsMove "));
            return str;
        }
        private string BuildRuleList(int _acc)
        {
            object obj;
            object[] tag;
            HijriGregDates dateFormatter = new HijriGregDates();
            string Rule = "Where 1 = 1 and T_GDHEAD.gdLok = 0 ";
            if (_acc == 1)
            {
                if (!string.IsNullOrEmpty(this.CmbFromBox.SelectedValue.ToString()))
                {
                    obj = Rule;
                    tag = new object[] { obj, " and ", this.CmbFromBox.Tag, " = '", this.CmbFromBox.SelectedValue.ToString().Trim(), "'" };
                    Rule = string.Concat(tag);
                }
            }
            else if (!string.IsNullOrEmpty(this.CmbToBox.SelectedValue.ToString()))
            {
                obj = Rule;
                tag = new object[] { obj, " and ", this.CmbToBox.Tag, " = '", this.CmbToBox.SelectedValue.ToString().Trim(), "'" };
                Rule = string.Concat(tag);
            }
            if ((!VarGeneral.CheckDate(this.txtGDate.Text) || this.txtGDate.Text.Length != 10 || !VarGeneral.CheckDate(this.txtHDate.Text) ? false : this.txtHDate.Text.Length == 10))
            {
                Rule = (VarGeneral.Settings_Sys.Calendr.Value != 1 ? string.Concat(Rule, " and  T_GDHEAD.gdGDate  >= '", dateFormatter.FormatGreg(this.txtGDate.Text, "yyyy/MM/dd"), "'") : string.Concat(Rule, " and  T_GDHEAD.gdHDate  >= '", dateFormatter.FormatHijri(this.txtHDate.Text, "yyyy/MM/dd"), "'"));
            }
            if ((!VarGeneral.CheckDate(this.txtGDate.Text) || this.txtGDate.Text.Length != 10 || !VarGeneral.CheckDate(this.txtHDate.Text) ? false : this.txtHDate.Text.Length == 10))
            {
                Rule = (VarGeneral.Settings_Sys.Calendr.Value != 1 ? string.Concat(Rule, " and  T_GDHEAD.gdGDate  <= '", dateFormatter.FormatGreg(this.txtGDate.Text, "yyyy/MM/dd"), "'") : string.Concat(Rule, " and  T_GDHEAD.gdHDate  <= '", dateFormatter.FormatHijri(this.txtHDate.Text, "yyyy/MM/dd"), "'"));
            }
            return Rule;
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            Exception ex;
            int value;
            try
            {
                if (!string.IsNullOrEmpty(this.label_Balance.Text))
                {
                    if (this.CmbUser.SelectedIndex <= 0)
                    {
                        MessageBox.Show((this.LangArEn == 0 ? "تأكد من اسم المستخدم ثم حاول مرة اخرى" : "Check User Name"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.CmbUser.Focus();
                    }
                    else if (this.CmbFromBox.SelectedIndex <= 0)
                    {
                        MessageBox.Show((this.LangArEn == 0 ? "تأكد من اسم الصندوق الاول ثم حاول مرة اخرى" : "Check First Box Name"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.CmbFromBox.Focus();
                    }
                    else if (this.CmbToBox.SelectedIndex > 0)
                    {
                        if ((double.Parse(this.label_Balance.Text) <= 0 ? true : double.Parse(this.label_Balance.Text) < this.txtAmount.Value))
                        {
                            if (!VarGeneral.TString.ChkStatShow(this.Permmission.SetStr, 24))
                            {
                                MessageBox.Show((this.LangArEn == 0 ? "لايمكن اتمام العملية .. تأكد من رصيد الصندوق" : "Can not complete the process .. make sure the fund balance"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                this.CmbFromBox.Focus();
                                return;
                            }
                        }
                        if (this.txtAmount.Value <= 0)
                        {
                            MessageBox.Show((this.LangArEn == 0 ? "تأكد من المبلغ ثم حاول مرة اخرى" : "Check Value"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            this.txtAmount.Focus();
                        }
                        else if (this.CmbFromBox.SelectedValue.ToString() == this.CmbToBox.SelectedValue.ToString())
                        {
                            MessageBox.Show((this.LangArEn == 0 ? "تأكد من صحة حسابات الصناديق ثم حاول مرة اخرى" : "Check Box Acc"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            this.txtAmount.Focus();
                        }
                        else if (this.CheckRemotDate())
                        {
                            this.dbInstance = null;
                            T_GDHEAD data_this = new T_GDHEAD();
                            Stock_DataDataContext _DB = new Stock_DataDataContext(VarGeneral.BranchCS);
                            try
                            {
                                string max = _DB.MaxGDHEADsNo.ToString();
                                T_GDHEAD newData = _DB.StockGDHEAD(11, max);
                                if ((newData == null ? true : string.IsNullOrEmpty(newData.gdNo)))
                                {
                                    data_this.gdHDate = this.txtHDate.Text;
                                    data_this.gdGDate = this.txtGDate.Text;
                                    data_this.gdNo = max;
                                    data_this.BName = data_this.BName;
                                    data_this.ChekNo = data_this.ChekNo;
                                    data_this.CurTyp = new int?(int.Parse(this.CmbCurr.SelectedValue.ToString()));
                                    data_this.ArbTaf = this.ScriptNumber1.ScriptNum(decimal.Parse(VarGeneral.TString.TEmpty(string.Concat(this.txtAmount.Value))));
                                    data_this.EngTaf = this.ScriptNumber1.TafEng(decimal.Parse(VarGeneral.TString.TEmpty(string.Concat(this.txtAmount.Value))));
                                    data_this.gdCstNo = new int?(1);
                                    data_this.gdID = new int?(0);
                                    data_this.gdLok = false;
                                    data_this.AdminLock = new bool?(false);
                                    data_this.gdMem = string.Concat("ترحيل الصندوق - من حساب  ", this.CmbFromBox.Text, " إلى حساب ", this.CmbToBox.Text);
                                    int? nullable = null;
                                    data_this.gdMnd = nullable;
                                    data_this.gdRcptID = new double?((data_this.gdRcptID.HasValue ? data_this.gdRcptID.Value : 0));
                                    data_this.gdTot = new double?(this.txtAmount.Value);
                                    T_GDHEAD tGDHEAD = data_this;
                                    nullable = data_this.gdTp;
                                    if (nullable.HasValue)
                                    {
                                        nullable = data_this.gdTp;
                                        value = nullable.Value;
                                    }
                                    else
                                    {
                                        value = 0;
                                    }
                                    tGDHEAD.gdTp = new int?(value);
                                    data_this.gdTyp = new int?(11);
                                    data_this.gdUser = this.CmbUser.SelectedValue.ToString();
                                    data_this.gdUserNam = this.CmbUser.Text;
                                    data_this.RefNo = "";
                                    data_this.salMonth = "";
                                    data_this.CompanyID = new int?(1);
                                    data_this.DATE_CREATED = new DateTime?(DateTime.Now);
                                    try
                                    {
                                        _DB.T_GDHEADs.InsertOnSubmit(data_this);
                                        _DB.SubmitChanges();
                                    }
                                    catch (SqlException sqlException)
                                    {
                                        SqlException eex = sqlException;
                                        max = _DB.MaxGDHEADsNo.ToString();
                                        if (eex.Number == 2627)
                                        {
                                            MessageBox.Show(string.Concat("الرمز مستخدم من قبل.\n سيتم الحفظ برقم جديد [", max, "]"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                            data_this.gdNo = max ?? "";
                                            this.ButOk_Click(sender, e);
                                        }
                                    }
                                    catch (Exception exception)
                                    {
                                        ex = exception;
                                        return;
                                    }
                                    IDatabase db_ = Framework.Data.Database.GetDatabase(VarGeneral.BranchCS);
                                    db_.StartTransaction();
                                    db_.ClearParameters();
                                    db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                                    db_.AddParameter("gdID", DbType.Int32, data_this.gdhead_ID);
                                    db_.AddParameter("gdNo", DbType.String, max);
                                    db_.AddParameter("gdDes", DbType.String, string.Concat("ترحيل الصندوق - من حساب  ", this.CmbFromBox.Text, " إلى حساب ", this.CmbToBox.Text));
                                    db_.AddParameter("gdDesE", DbType.String, "Relay Box");
                                    db_.AddParameter("recptTyp", DbType.String, "11");
                                    db_.AddParameter("AccNo", DbType.String, this.CmbFromBox.SelectedValue.ToString());
                                    db_.AddParameter("AccName", DbType.String, this.CmbFromBox.Text);
                                    db_.AddParameter("gdValue", DbType.Double, -this.txtAmount.Value);
                                    db_.AddParameter("recptNo", DbType.String, max);
                                    db_.AddParameter("Lin", DbType.Int32, 1);
                                    db_.AddParameter("AccNoDestruction", DbType.String, null);
                                    db_.ExecuteNonQueryWithoutCommit(true, "S_T_GDDET_INSERT");
                                    db_.EndTransaction();
                                    db_.StartTransaction();
                                    db_.ClearParameters();
                                    db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                                    db_.AddParameter("gdID", DbType.Int32, data_this.gdhead_ID);
                                    db_.AddParameter("gdNo", DbType.String, max);
                                    db_.AddParameter("gdDes", DbType.String, string.Concat("ترحيل الصندوق - من حساب  ", this.CmbFromBox.Text, " إلى حساب ", this.CmbToBox.Text));
                                    db_.AddParameter("gdDesE", DbType.String, "Relay Box");
                                    db_.AddParameter("recptTyp", DbType.String, "11");
                                    db_.AddParameter("AccNo", DbType.String, this.CmbToBox.SelectedValue.ToString());
                                    db_.AddParameter("AccName", DbType.String, this.CmbToBox.Text);
                                    db_.AddParameter("gdValue", DbType.Double, this.txtAmount.Value);
                                    db_.AddParameter("recptNo", DbType.String, max);
                                    db_.AddParameter("Lin", DbType.Int32, 2);
                                    db_.AddParameter("AccNoDestruction", DbType.String, null);
                                    db_.ExecuteNonQueryWithoutCommit(true, "S_T_GDDET_INSERT");
                                    db_.EndTransaction();
                                    try
                                    {
                                        if (this.chk1.Checked)
                                        {
                                            if ((!this.EmailVerify(this._Company.Tel2.Trim()) || !this.EmailVerify(VarGeneral.Settings_Sys.ServerNm.Trim()) ? true : string.IsNullOrEmpty(VarGeneral.Settings_Sys.Sa_Pass)))
                                            {
                                                MessageBox.Show((this.LangArEn == 0 ? "لم يتم ارسال الايميل الى المدير .. يرجى التأكد من صحة بيانات الاعدادات" : "The Email was not sent to the Boss .. Please make sure the settings information is correct."), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                                return;
                                            }
                                            else if (!this.SendEmail(max))
                                            {
                                                MessageBox.Show((this.LangArEn == 0 ? "لم يتم ارسال الايميل الى المدير .. يرجى التأكد من صحة بيانات الاعدادات" : "The Email was not sent to the Boss .. Please make sure the settings information is correct."), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                                return;
                                            }
                                        }
                                    }
                                    catch (Exception exception1)
                                    {
                                        ex = exception1;
                                        MessageBox.Show((this.LangArEn == 0 ? "لم يتم ارسال الايميل الى المدير .. يرجى التأكد من صحة بيانات الاعدادات" : "The Email was not sent to the Boss .. Please make sure the settings information is correct."), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                        return;
                                    }
                                    try
                                    {
                                        if (this.chk2.Checked)
                                        {
                                            if ((string.IsNullOrEmpty(this._Company.Mobl) || string.IsNullOrEmpty(VarGeneral.Settings_Sys.smsUserName) || string.IsNullOrEmpty(VarGeneral.Settings_Sys.smsPass) ? true : string.IsNullOrEmpty(VarGeneral.Settings_Sys.smsSenderName.Trim())))
                                            {
                                                MessageBox.Show((this.LangArEn == 0 ? "لم يتم ارسال رسالة نصية الى جوال المدير .. يرجى التأكد من صحة بيانات إعدادات الرسائل النصية" : "SMS Message was not sent to the Boss .. Please make sure the settings information is correct."), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                                return;
                                            }
                                            else if (!this.SendMobileMessage(max))
                                            {
                                                MessageBox.Show((this.LangArEn == 0 ? "لم يتم ارسال رسالة نصية الى جوال المدير .. يرجى التأكد من صحة بيانات إعدادات الرسائل النصية" : "SMS Message was not sent to the Boss .. Please make sure the settings information is correct."), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                                return;
                                            }
                                        }
                                    }
                                    catch (Exception exception2)
                                    {
                                        ex = exception2;
                                        MessageBox.Show((this.LangArEn == 0 ? "لم يتم ارسال رسالة نصية الى جوال المدير .. يرجى التأكد من صحة بيانات إعدادات الرسائل النصية" : "SMS Message was not sent to the Boss .. Please make sure the settings information is correct."), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                        return;
                                    }
                                    MessageBox.Show((this.LangArEn == 0 ? "تمت عملية الترحيل بنجاح .." : "Relay Is Done"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 35))
                                    {
                                        if (MessageBox.Show((this.LangArEn == 0 ? string.Concat("سيتم اعادة الترقيم التسلسلي لصندوق المستخدم ", this.CmbUser.Text, " .. هل تريد المتابعة ؟") : "Will be re-serial numbering of bills Fund .. Do you want to continue?"), VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                        {
                                            this.RelayInv();
                                        }
                                    }
                                    if (MessageBox.Show((this.LangArEn == 0 ? "سيتم طباعة كشف حساب .. هل تريد المتابعة ؟" : "Will print the Report .. Do you want to continue? "), VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                    {
                                        this.button_RepAccFrom_Click(sender, e);
                                    }
                                    base.Close();
                                }
                                else
                                {
                                    return;
                                }
                            }
                            finally
                            {
                                if (_DB != null)
                                {
                                    ((IDisposable)_DB).Dispose();
                                }
                            }
                            return;
                        }
                        else
                        {
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        MessageBox.Show((this.LangArEn == 0 ? "تأكد من اسم الصندوق الثاني ثم حاول مرة اخرى" : "Check Second Box Name"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.CmbToBox.Focus();
                    }
                }
            }
            catch (Exception exception3)
            {
                Exception error = exception3;
                VarGeneral.DebLog.writeLog("FrmRelayBoxes_Load:", error, true);
                MessageBox.Show(error.Message);
                return;
            }
        }
        private void button_RepAccFrom_Click(object sender, EventArgs e)
        {
            if (!(this.CmbFromBox.Text == ""))
            {
                this._Procces(1);
            }
        }
        private void button_RepAccTo_Click(object sender, EventArgs e)
        {
            if (!(this.CmbToBox.Text == ""))
            {
                this._Procces(2);
            }
        }
        private void buttonX_Close_Click(object sender, EventArgs e)
        {
            base.Close();
        }
        private bool CheckRemotDate()
        {
            bool flag;
            try
            {
                if (VarGeneral.gUserName != "runsetting")
                {
                    bool User_Remotly = this.CheckUserIFRemote();
                    RegistryKey hKeyNew = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", true);
                    RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", true);
                    long regval = (long)0;
                    long regvalNew = (long)0;
                    if (hKey != null)
                    {
                        try
                        {
                            if (string.IsNullOrEmpty(hKey.GetValue("vRemotly").ToString()))
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
                            if (string.IsNullOrEmpty(hKeyNew.GetValue("vRemotly_New").ToString()))
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
                    if ((User_Remotly || regval == (long)1 ? true : regvalNew == (long)1))
                    {
                        try
                        {
                            if (!VarGeneral.vDemo)
                            {
                                string dtAction = this.txtHDate.Text;
                                try
                                {
                                    if (Convert.ToDateTime(this.n.GregToHijri(hKeyNew.GetValue("vBackup_New").ToString(), "yyyy/MM/dd")) < Convert.ToDateTime(this.n.FormatHijri(dtAction, "yyyy/MM/dd")))
                                    {
                                        MessageBox.Show((this.LangArEn == 0 ? "لا يمكن إتمام العملية .. لقد تخطيت السنة المالية المحدد للنظام \n يرجى التواصل مع الإدارة لللإشتراك في خدمات النسخة " : "We can not complete the operation .. have you skip the fiscal year specified for the system"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                        flag = false;
                                        return flag;
                                    }
                                }
                                catch
                                {
                                    dtAction = this.txtGDate.Text;
                                    if (Convert.ToDateTime(this.n.FormatGreg(hKeyNew.GetValue("vBackup_New").ToString(), "yyyy/MM/dd")) < Convert.ToDateTime(this.n.FormatGreg(dtAction, "yyyy/MM/dd")))
                                    {
                                        MessageBox.Show((this.LangArEn == 0 ? "لا يمكن إتمام العملية .. لقد تخطيت السنة المالية المحدد للنظام \n يرجى التواصل مع الإدارة لللإشتراك في خدمات النسخة " : "We can not complete the operation .. have you skip the fiscal year specified for the system"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                        flag = false;
                                        return flag;
                                    }
                                }
                            }
                            else
                            {
                                flag = false;
                                return flag;
                            }
                        }
                        catch
                        {
                            MessageBox.Show((this.LangArEn == 0 ? "لا يمكن إتمام العملية .. لقد تخطيت السنة المالية المحدد للنظام \n يرجى التواصل مع الإدارة لللإشتراك في خدمات النسخة " : "We can not complete the operation .. have you skip the fiscal year specified for the system"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            flag = false;
                            return flag;
                        }
                    }
                }
                flag = true;
                return flag;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }
        private bool CheckUserIFRemote()
        {
            bool flag;
            try
            {
                flag = (!SystemInformation.TerminalServerSession ? false : true);
            }
            catch
            {
                flag = true;
            }
            return flag;
        }
        private void chk1_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.chk1.Checked)
            {
                this.checBox_Acc1.Checked = false;
                this.checBox_Acc2.Checked = false;
                this.checBox_Acc1.Enabled = false;
                this.checBox_Acc2.Enabled = false;
            }
            else
            {
                this.checBox_Acc1.Checked = true;
                this.checBox_Acc2.Checked = true;
                this.checBox_Acc1.Enabled = true;
                this.checBox_Acc2.Enabled = true;
            }
        }
        private void CmbFromBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.label_Balance.Text = "";
            if (this.CmbFromBox.SelectedIndex > 0)
            {
                Label labelBalance = this.label_Balance;
                double? balance = this.db.StockAccDef(this.CmbFromBox.SelectedValue.ToString()).Balance;
                double num = Math.Round(balance.Value, (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2));
                labelBalance.Text = num.ToString();
            }
        }
        private string convertToUnicode(char ch)
        {
            byte[] msg = (new UnicodeEncoding()).GetBytes(Convert.ToString(ch));
            string str = this.fourDigits(string.Concat(msg[1], msg[0].ToString("X")));
            return str;
        }
        private string ConvertToUnicode(string val)
        {
            string msg2 = string.Empty;
            for (int i = 0; i < val.Length; i++)
            {
                msg2 = string.Concat(msg2, this.convertToUnicode(Convert.ToChar(val.Substring(i, 1))));
            }
            return msg2;
        }
        private bool EmailVerify(string email)
        {
            bool flag;
            try
            {
                MailAddress mail = new MailAddress(email);
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }
        private void FillCombo()
        {
            List<T_User> LUsr;
            List<T_AccDef> LAccDef;
            if (this.LangArEn != 0)
            {
                LUsr = (
                    from t in this.dbc.T_Users
                    where t.Usr_ID != 1
                    orderby t.UsrNo
                    select t).ToList<T_User>();
                LUsr.Insert(0, new T_User());
                this.CmbUser.DataSource = LUsr;
                this.CmbUser.DisplayMember = "UsrNamE";
                this.CmbUser.ValueMember = "UsrNo";
                LAccDef = (
                    from t in this.db.T_AccDefs
                    where t.Lev == (int?)4 && t.Sts == (int?)0 && t.AccCat == (int?)2
                    orderby t.AccDef_No
                    select t).ToList<T_AccDef>();
                LAccDef.Insert(0, new T_AccDef());
                this.CmbFromBox.DataSource = LAccDef;
                this.CmbFromBox.DisplayMember = "Eng_Des";
                this.CmbFromBox.ValueMember = "AccDef_No";
                LAccDef = (
                    from t in this.db.T_AccDefs
                    where t.Lev == (int?)4 && t.Sts == (int?)0 && t.AccCat == (int?)2
                    orderby t.AccDef_No
                    select t).ToList<T_AccDef>();
                LAccDef.Insert(0, new T_AccDef());
                this.CmbToBox.DataSource = LAccDef;
                this.CmbToBox.DisplayMember = "Eng_Des";
                this.CmbToBox.ValueMember = "AccDef_No";
            }
            else
            {
                LUsr = (
                    from t in this.dbc.T_Users
                    where t.Usr_ID != 1
                    orderby t.UsrNo
                    select t).ToList<T_User>();
                LUsr.Insert(0, new T_User());
                this.CmbUser.DataSource = LUsr;
                this.CmbUser.DisplayMember = "UsrNamA";
                this.CmbUser.ValueMember = "UsrNo";
                LAccDef = (
                    from t in this.db.T_AccDefs
                    where t.Lev == (int?)4 && t.Sts == (int?)0 && t.AccCat == (int?)2
                    orderby t.AccDef_No
                    select t).ToList<T_AccDef>();
                LAccDef.Insert(0, new T_AccDef());
                this.CmbFromBox.DataSource = LAccDef;
                this.CmbFromBox.DisplayMember = "Arb_Des";
                this.CmbFromBox.ValueMember = "AccDef_No";
                LAccDef = (
                    from t in this.db.T_AccDefs
                    where t.Lev == (int?)4 && t.Sts == (int?)0 && t.AccCat == (int?)2
                    orderby t.AccDef_No
                    select t).ToList<T_AccDef>();
                LAccDef.Insert(0, new T_AccDef());
                this.CmbToBox.DataSource = LAccDef;
                this.CmbToBox.DisplayMember = "Arb_Des";
                this.CmbToBox.ValueMember = "AccDef_No";
            }
            this.CmbUser.SelectedIndex = 0;
            this.CmbFromBox.SelectedIndex = 0;
            this.CmbToBox.SelectedIndex = 0;
            if (this.LangArEn != 0)
            {
                List<T_Curency> listCurr = new List<T_Curency>((
                    from item in this.db.T_Curencies
                    select item).ToList<T_Curency>());
                this.CmbCurr.DataSource = listCurr;
                this.CmbCurr.DisplayMember = "Eng_Des";
                this.CmbCurr.ValueMember = "Curency_ID";
            }
            else
            {
                List<T_Curency> listAccCat = new List<T_Curency>((
                    from item in this.db.T_Curencies
                    select item).ToList<T_Curency>());
                this.CmbCurr.DataSource = listAccCat;
                this.CmbCurr.DisplayMember = "Arb_Des";
                this.CmbCurr.ValueMember = "Curency_ID";
            }
            try
            {
                this.CmbCurr.SelectedValue = int.Parse(VarGeneral.Settings_Sys.ImportIp.ToString());
            }
            catch
            {
            }
        }
        private string fourDigits(string val)
        {
            string result = string.Empty;
            switch (val.Length)
            {
                case 1:
                    {
                        result = string.Concat("000", val);
                        break;
                    }
                case 2:
                    {
                        result = string.Concat("00", val);
                        break;
                    }
                case 3:
                    {
                        result = string.Concat("0", val);
                        break;
                    }
                case 4:
                    {
                        result = val;
                        break;
                    }
            }
            return result;
        }
        private void FrmRelayBoxes_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (File.Exists(string.Concat(Application.StartupPath, "\\_PROSOFTReportAcc_1.xls")))
            {
                File.Delete(string.Concat(Application.StartupPath, "\\_PROSOFTReportAcc_1.xls"));
            }
            if (File.Exists(string.Concat(Application.StartupPath, "\\_PROSOFTReportAcc_2.xls")))
            {
                File.Delete(string.Concat(Application.StartupPath, "\\_PROSOFTReportAcc_2.xls"));
            }
        }
        private void FrmRelayBoxes_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.KeyCode != Keys.F2 || !this.ButOk.Enabled ? true : !this.ButOk.Visible))
            {
                this.ButOk_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                base.Close();
            }
        }
        private void FrmRelayBoxes_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmRelayBoxes));
                if (!(VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == ""))
                {
                    Language.ChangeLanguage("en", this, resources);
                    this.LangArEn = 1;
                    this.ButOk.Text = "Relay Value F2";
                    this.buttonX_Close.Text = "Close Esc";
                    this.groupPanel_SendOption.Text = "Send Options";
                    this.Text = "Relay fund accounts - Treasury";
                    this.button_RepAccFrom.Text = "Report";
                    this.button_RepAccTo.Text = "Report";
                }
                else
                {
                    Language.ChangeLanguage("ar-SA", this, resources);
                    this.LangArEn = 0;
                    this.ButOk.Text = "ترحيل المبلغ F2";
                    this.buttonX_Close.Text = "إغلاق Esc";
                    this.groupPanel_SendOption.Text = "خيارات الإرسال";
                    this.Text = "ترحيل حسابات الصناديق - الخزينة";
                }
                VarGeneral.InvTyp = 11;
                this.Permmission = this.dbc.Get_PermissionID(VarGeneral.UserID);
                this.GetInvSetting();
                try
                {
                    if (int.Parse(this.Permmission.RepInv3.Trim()) > 0)
                    {
                        this.chk1.Enabled = false;
                        this.chk2.Enabled = false;
                        if (int.Parse(this.Permmission.RepInv3.Trim()) == 1)
                        {
                            this.chk1.Checked = true;
                            this.chk2.Checked = false;
                        }
                        else if (int.Parse(this.Permmission.RepInv3.Trim()) != 2)
                        {
                            this.chk1.Checked = true;
                            this.chk2.Checked = true;
                        }
                        else
                        {
                            this.chk1.Checked = false;
                            this.chk2.Checked = true;
                        }
                    }
                }
                catch
                {
                    this.chk1.Enabled = true;
                    this.chk2.Enabled = true;
                }
                this.listCompany = this.db.StockCompanyList();
                this._Company = this.listCompany[0];
                this.FillCombo();
                this.CmbUser.SelectedValue = VarGeneral.UserNo;
                this.chk1_CheckedChanged(sender, e);
            }
            catch (Exception exception)
            {
                Exception error = exception;
                VarGeneral.DebLog.writeLog("Load:", error, true);
                MessageBox.Show(error.Message);
            }
            this.txtGDate.Text = this.n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
            this.txtHDate.Text = this.n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
            this.txtTime.Text = DateTime.Now.ToString("HH:mm");
        }
        private void GetInvSetting()
        {
            this._InvSetting = new T_INVSETTING();
            this._SysSetting = new T_SYSSETTING();
            this._InvSetting = this.db.StockInvSetting(VarGeneral.UserID, VarGeneral.InvTyp);
            this._SysSetting = this.db.SystemSettingStock();
        }
        private void RelayInv()
        {
            try
            {
                if (this.CmbUser.SelectedIndex > 0)
                {
                    this.db.ExecuteCommand(string.Concat("UPDATE T_INVHED SET T_INVHED.InvId = 0  WHERE SalsManNo = '", this.CmbUser.SelectedValue.ToString(), "' and T_INVHED.InvId > 0"), new object[0]);
                }
                else
                {
                    MessageBox.Show((this.LangArEn == 0 ? "تأكد من اسم المستخدم ثم حاول مرة اخرى" : "Check User Name"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.CmbUser.Focus();
                    return;
                }
            }
            catch (Exception exception)
            {
                Exception error = exception;
                VarGeneral.DebLog.writeLog("RelayInv:", error, true);
                MessageBox.Show(error.Message);
            }
        }
        private bool SendEmail(string max)
        {
            Attachment at;
#pragma warning disable CS0219 // The variable 'a' is assigned but its value is never used
            Attachment a = null;
#pragma warning restore CS0219 // The variable 'a' is assigned but its value is never used
            bool flag;
            string[] str;
            double value;
            string str1;
            try
            {
                MailMessage msg = new MailMessage();
                SmtpClient client = new SmtpClient();
                if (VarGeneral.Settings_Sys.DataBaseNm == "0")
                {
                    client.Host = "smtp.live.com";
                }
                else if (!(VarGeneral.Settings_Sys.DataBaseNm == "1"))
                {
                    client.Host = "smtp.mail.yahoo.com";
                }
                else
                {
                    client.Host = "smtp.gmail.com";
                }
                client.Port = 587;
                msg.From = new MailAddress(this._Company.Tel2.Trim());
                msg.To.Add(VarGeneral.Settings_Sys.ServerNm.Trim());
                msg.Subject = (this.LangArEn == 0 ? "Pro.Soft-Mail :  عملية ترحيل الصندوق " : "Pro.Soft-Mail :  Relay Box ");
                MailMessage mailMessage = msg;
                if (this.LangArEn == 0)
                {
                    str = new string[20];
                    str[0] = "عملية إقفال اليوم وترحيل المبلغ  ";
                    value = this.txtAmount.Value;
                    str[1] = value.ToString();
                    str[2] = " \n من الصندوق ";
                    str[3] = this.CmbFromBox.SelectedValue.ToString();
                    str[4] = " | ";
                    str[5] = this.CmbFromBox.Text;
                    str[6] = "  \n  إلى الصندوق ";
                    str[7] = this.CmbToBox.SelectedValue.ToString();
                    str[8] = " | ";
                    str[9] = this.CmbToBox.Text;
                    str[10] = "  \n وذلك بتاريخ  ";
                    str[11] = this.txtHDate.Text;
                    str[12] = "  الموافق  ";
                    str[13] = this.txtGDate.Text;
                    str[14] = " تمام الساعة ";
                    str[15] = this.txtTime.Text;
                    str[16] = "  \n حيث تمت العملية بواسطة المستخدم  ";
                    str[17] = this.CmbUser.Text;
                    str[18] = " \n رقم القيد المحاسبي ";
                    str[19] = max;
                    str1 = string.Concat(str);
                }
                else
                {
                    str = new string[20];
                    str[0] = "Relay amount ";
                    value = this.txtAmount.Value;
                    str[1] = value.ToString();
                    str[2] = " \n Box From ";
                    str[3] = this.CmbFromBox.SelectedValue.ToString();
                    str[4] = " | ";
                    str[5] = this.CmbFromBox.Text;
                    str[6] = "  \n  Box To ";
                    str[7] = this.CmbToBox.SelectedValue.ToString();
                    str[8] = " | ";
                    str[9] = this.CmbToBox.Text;
                    str[10] = "  \n Date  ";
                    str[11] = this.txtHDate.Text;
                    str[12] = "  Agrees on  ";
                    str[13] = this.txtGDate.Text;
                    str[14] = " Time is ";
                    str[15] = this.txtTime.Text;
                    str[16] = "  \n By User  ";
                    str[17] = this.CmbUser.Text;
                    str[18] = " \n Gaid No ";
                    str[19] = max;
                    str1 = string.Concat(str);
                }
                mailMessage.Body = str1;
                if (this.checBox_Acc1.Checked)
                {
                    if (this.AttachFile(1))
                    {
                        if (File.Exists(string.Concat(Application.StartupPath, "\\_PROSOFTReportAcc_1.xls")))
                        {
                            at = new Attachment(string.Concat(Application.StartupPath, "\\_PROSOFTReportAcc_1.xls"));
                            msg.Attachments.Add(at);
                        }
                    }
                }
                if (this.checBox_Acc2.Checked)
                {
                    if (this.AttachFile(2))
                    {
                        if (File.Exists(string.Concat(Application.StartupPath, "\\_PROSOFTReportAcc_2.xls")))
                        {
                            at = new Attachment(string.Concat(Application.StartupPath, "\\_PROSOFTReportAcc_2.xls"));
                            msg.Attachments.Add(at);
                        }
                    }
                }
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(this._Company.Tel2.Trim(), VarGeneral.Settings_Sys.Sa_Pass);
                try
                {
                    client.Send(msg);
                    foreach (Attachment aa in msg.Attachments)
                    {
                        aa.Dispose();
                    }
                    msg.Dispose();
                    flag = true;
                }
                catch (SmtpFailedRecipientsException smtpFailedRecipientsException)
                {
                    SmtpFailedRecipientsException ex = smtpFailedRecipientsException;
                    int i = 0;
                    while (i < (int)ex.InnerExceptions.Length)
                    {
                        SmtpStatusCode status = ex.InnerExceptions[i].StatusCode;
                        if ((status == SmtpStatusCode.MailboxBusy ? false : status != SmtpStatusCode.MailboxUnavailable))
                        {
                            i++;
                        }
                        else
                        {
                            Thread.Sleep(5000);
                            client.Send(msg);
                            foreach (Attachment attachment in msg.Attachments)
                            {
                                attachment.Dispose();
                            }
                            msg.Dispose();
                            flag = true;
                            return flag;
                        }
                    }
                    foreach (Attachment attachment1 in msg.Attachments)
                    {
                        attachment1.Dispose();
                    }
                    msg.Dispose();
                    MessageBox.Show(ex.Message);
                    flag = false;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                MessageBox.Show((this.LangArEn == 0 ? "لم يتم ارسال الايميل الى المدير .. يرجى التأكد من صحة بيانات الاعدادات" : "The Email was not sent to the Boss .. Please make sure the settings information is correct."), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                flag = false;
            }
            return flag;
        }
        public string SendMessage(string username, string password, string msg, string sender, string numbers)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://www.mobily.ws/api/msgSend.php");
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            string SenderList = "";
            string[] strArrays = new string[] { "mobile=", username, "&password=", password, "&numbers=", null, null, null, null, null, null };
            strArrays[5] = (string.IsNullOrEmpty(SenderList) ? numbers : string.Concat(SenderList, ",", numbers));
            strArrays[6] = "&sender=";
            strArrays[7] = sender;
            strArrays[8] = "&msg=";
            strArrays[9] = msg;
            strArrays[10] = "&applicationType=61";
            string postData = string.Concat(strArrays);
            req.ContentLength = (long)postData.Length;
            StreamWriter stOut = new StreamWriter(req.GetRequestStream(), Encoding.ASCII);
            stOut.Write(postData);
            stOut.Close();
            StreamReader stIn = new StreamReader(req.GetResponse().GetResponseStream());
            string strResponse = stIn.ReadToEnd();
            stIn.Close();
            return strResponse;
        }
        private bool SendMobileMessage(string max)
        {
            bool flag;
            string[] str;
            double value;
            string str1;
            try
            {
                if (this.LangArEn == 0)
                {
                    str = new string[20];
                    str[0] = "عملية إقفال اليوم وترحيل المبلغ  ";
                    value = this.txtAmount.Value;
                    str[1] = value.ToString();
                    str[2] = " \n من الصندوق ";
                    str[3] = this.CmbFromBox.SelectedValue.ToString();
                    str[4] = " | ";
                    str[5] = this.CmbFromBox.Text;
                    str[6] = "  \n  إلى الصندوق ";
                    str[7] = this.CmbToBox.SelectedValue.ToString();
                    str[8] = " | ";
                    str[9] = this.CmbToBox.Text;
                    str[10] = "  \n وذلك بتاريخ  ";
                    str[11] = this.txtHDate.Text;
                    str[12] = "  الموافق  ";
                    str[13] = this.txtGDate.Text;
                    str[14] = " تمام الساعة ";
                    str[15] = this.txtTime.Text;
                    str[16] = "  \n حيث تمت العملية بواسطة المستخدم  ";
                    str[17] = this.CmbUser.Text;
                    str[18] = " \n رقم القيد المحاسبي ";
                    str[19] = max;
                    str1 = string.Concat(str);
                }
                else
                {
                    str = new string[20];
                    str[0] = "Relay amount ";
                    value = this.txtAmount.Value;
                    str[1] = value.ToString();
                    str[2] = " \n Box From ";
                    str[3] = this.CmbFromBox.SelectedValue.ToString();
                    str[4] = " | ";
                    str[5] = this.CmbFromBox.Text;
                    str[6] = "  \n  Box To ";
                    str[7] = this.CmbToBox.SelectedValue.ToString();
                    str[8] = " | ";
                    str[9] = this.CmbToBox.Text;
                    str[10] = "  \n Date  ";
                    str[11] = this.txtHDate.Text;
                    str[12] = "  Agrees on  ";
                    str[13] = this.txtGDate.Text;
                    str[14] = " Time is ";
                    str[15] = this.txtTime.Text;
                    str[16] = "  \n By User  ";
                    str[17] = this.CmbUser.Text;
                    str[18] = " \n Gaid No ";
                    str[19] = max;
                    str1 = string.Concat(str);
                }
                string msgTxt = str1;
                if (!(new Regex("^\\d{10}$")).Match(this._Company.Mobl).Success)
                {
                    this._Company.Mobl = "";
                    MessageBox.Show((this.LangArEn == 0 ? "لم يتم ارسال رسالة نصية الى جوال المدير .. يرجى التأكد من صحة بيانات إعدادات الرسائل النصية" : "SMS Message was not sent to the Boss .. Please make sure the settings information is correct."), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    flag = false;
                }
                else if (this._Company.Mobl.StartsWith("05"))
                {
                    string M_Value = string.Concat("966", this._Company.Mobl.Substring(1));
                    string t = this.SendMessage(VarGeneral.Settings_Sys.smsUserName, VarGeneral.Settings_Sys.smsPass, this.ConvertToUnicode(msgTxt), VarGeneral.Settings_Sys.smsSenderName.Trim(), M_Value);
                    this.ShowResult(t);
                    flag = (!(t != "1") ? true : false);
                }
                else
                {
                    this._Company.Mobl = "";
                    MessageBox.Show((this.LangArEn == 0 ? "لم يتم ارسال رسالة نصية الى جوال المدير .. يرجى التأكد من صحة بيانات إعدادات الرسائل النصية" : "SMS Message was not sent to the Boss .. Please make sure the settings information is correct."), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    flag = false;
                }
            }
#pragma warning disable CS0168 // The variable 'exception' is declared but never used
            catch (Exception exception)
#pragma warning restore CS0168 // The variable 'exception' is declared but never used
            {
                MessageBox.Show((this.LangArEn == 0 ? "لم يتم ارسال رسالة نصية الى جوال المدير .. يرجى التأكد من صحة بيانات إعدادات الرسائل النصية" : "SMS Message was not sent to the Boss .. Please make sure the settings information is correct."), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                flag = false;
            }
            return flag;
        }
        private void ShowResult(string res)
        {
            DialogResult dialogResult;
            string str = res;
            if (str != null)
            {
                switch (str)
                {
                    case "1":
                        {
                            break;
                        }
                    case "2":
                        {
                            MessageBox.Show("إن رصيدك لدى برو سوفت قد إنتهى ولم يعد به أي رسائل. (لحل المشكلة قم بشحن رصيدك من الرسائل لدى برو سوفت. لشحن رصيدك إتبع تعليمات شحن الرصيد)");
                            break;
                        }
                    case "3":
                        {
                            MessageBox.Show("إن رصيدك الحالي لا يكفي لإتمام عملية الإرسال. (لحل المشكلة قم بشحن رصيدك من الرسائل لدى برو سوفت. لشحن رصيدك إتبع تعليمات شحن الرصيد");
                            break;
                        }
                    case "4":
                        {
                            MessageBox.Show("إن إسم المستخدم الذي إستخدمته للدخول إلى حساب الرسائل غير صحيح (تأكد من أن إسم المستخدم الذي إستخدمته هو نفسه الذي تستخدمه عند دخولك إلى موقع برو سوفت).");
                            break;
                        }
                    case "5":
                        {
                            MessageBox.Show("هناك خطأ في كلمة المرور (تأكد من أن كلمة المرور التي تم إستخدامها هي نفسها التي تستخدمها عند دخولك موقع برو سوفت,إذا نسيت كلمة المرور إضغط على رابط نسيت كلمة المرور لتصلك رسالة على جوالك برقم المرور الخاص بك)");
                            break;
                        }
                    case "6":
                        {
                            MessageBox.Show("إن صفحة الإرسال لاتجيب في الوقت الحالي (قد يكون هناك طلب كبير على الصفحة أو توقف مؤقت للصفحة فقط حاول مرة أخرى أو تواصل مع الدعم الفني إذا إستمر الخطأ)");
                            break;
                        }
                    case "12":
                        {
                            MessageBox.Show("إن حسابك بحاجة إلى تحديث يرجى مراجعة الدعم الفني");
                            break;
                        }
                    case "13":
                        {
                            MessageBox.Show("إن إسم المرسل الذي إستخدمته في هذه الرسالة لم يتم قبوله. (يرجى إرسال الرسالة بإسم مرسل آخر أو تعريف إسم المرسل لدى برو سوفت)");
                            break;
                        }
                    case "14":
                        {
                            MessageBox.Show("إن إسم المرسل الذي إستخدمته غير معرف لدى برو سوفت. (يمكنك تعريف إسم المرسل من خلال صفحة إضافة إسم مرسل)");
                            break;
                        }
                    case "15":
                        {
                            MessageBox.Show("يوجد رقم جوال خاطئ في الأرقام التي قمت بالإرسال لها. (تأكد من صحة الأرقام التي تريد الإرسال لها وأنها بالصيغة الدولية)");
                            break;
                        }
                    case "16":
                        {
                            MessageBox.Show("الرسالة التي قمت بإرسالها لا تحتوي على إسم مرسل. (أدخل إسم مرسل عند إرسالك الرسالة)");
                            break;
                        }
                    case "17":
                        {
                            MessageBox.Show("لم يتم ارسال نص الرسالة. الرجاء التأكد من ارسال نص الرسالة والتأكد من تحويل الرسالة الى يوني كود (الرجاء التأكد من استخدام الدالة()");
                            break;
                        }
                    case "18":
                        {
                            MessageBox.Show("الارسال متوقف حاليا");
                            break;
                        }
                    case "19":
                        {
                            MessageBox.Show("applicationType غير موجودة في الرابط");
                            break;
                        }
                    case "-1":
                        {
                            MessageBox.Show("لم يتم التواصل مع خادم (Server) الإرسال برو سوفت بنجاح. (قد يكون هناك محاولات إرسال كثيرة تمت معا , أو قد يكون هناك عطل مؤقت طرأ على الخادم إذا إستمرت المشكلة يرجى التواصل مع الدعم الفني)");
                            break;
                        }
                    case "-2":
                        {
                            MessageBox.Show("لم يتم الربط مع قاعدة البيانات (Database) التي تحتوي على حسابك وبياناتك لدى برو سوفت. (قد يكون هناك محاولات إرسال كثيرة تمت معا , أو قد يكون هناك عطل مؤقت طرأ على الخادم إذا إستمرت المشكلة يرجى التواصل مع الدعم الفني)");
                            break;
                        }
                    default:
                        {
                            dialogResult = MessageBox.Show(res.ToString());
                            return;
                        }
                }
            }
            else
            {
                dialogResult = MessageBox.Show(res.ToString());
                return;
            }
        }
        private void txtGDate_Click(object sender, EventArgs e)
        {
            this.txtGDate.SelectAll();
        }
        private void txtGDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!VarGeneral.CheckDate(this.txtGDate.Text))
                {
                    this.txtGDate.Text = this.n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                }
                else
                {
                    MaskedTextBox str = this.txtGDate;
                    DateTime dateTime = Convert.ToDateTime(this.txtGDate.Text);
                    str.Text = dateTime.ToString("yyyy/MM/dd");
                    this.txtGDate.Text = this.n.FormatGreg(this.txtGDate.Text, "yyyy/MM/dd");
                    this.txtHDate.Text = this.n.GregToHijri(this.txtGDate.Text, "yyyy/MM/dd");
                }
            }
            catch
            {
                this.txtGDate.Text = "";
            }
        }
        private void txtHDate_Click(object sender, EventArgs e)
        {
            this.txtHDate.SelectAll();
        }
        private void txtHDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!VarGeneral.CheckDate(this.txtHDate.Text))
                {
                    this.txtHDate.Text = this.n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                }
                else
                {
                    MaskedTextBox str = this.txtHDate;
                    DateTime dateTime = Convert.ToDateTime(this.txtHDate.Text);
                    str.Text = dateTime.ToString("yyyy/MM/dd");
                    this.txtHDate.Text = this.n.FormatHijri(this.txtHDate.Text, "yyyy/MM/dd");
                    this.txtGDate.Text = this.n.HijriToGreg(this.txtHDate.Text, "yyyy/MM/dd");
                }
            }
            catch
            {
                this.txtHDate.Text = "";
            }
        }
        private void txtTime_Click(object sender, EventArgs e)
        {
            this.txtTime.SelectAll();
        }
        private void txtTime_Leave(object sender, EventArgs e)
        {
            DateTime now;
            try
            {
                if (!VarGeneral.CheckTime(this.txtTime.Text))
                {
                    MaskedTextBox str = this.txtTime;
                    now = DateTime.Now;
                    str.Text = now.ToString("HH:mm");
                }
                else
                {
                    MaskedTextBox maskedTextBox = this.txtTime;
                    TimeSpan timeSpan = TimeSpan.Parse(this.txtTime.Text);
                    maskedTextBox.Text = timeSpan.ToString();
                }
            }
            catch
            {
                MaskedTextBox str1 = this.txtTime;
                now = DateTime.Now;
                str1.Text = now.ToString("HH:mm");
            }
        }
        public class ColumnDictinary
        {
            public string AText = "";
            public string EText = "";
            public bool IfDefault = false;
            public string Format = "";
            public ColumnDictinary(string aText, string eText, bool ifDefault, string format)
            {
                this.AText = aText;
                this.EText = eText;
                this.IfDefault = ifDefault;
                this.Format = format;
            }
        }
    }
}
