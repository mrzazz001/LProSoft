
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
    public partial class FrmRelayBoxes : Form
    {
        private IContainer components = null;
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
        private string FlagUpdate = "";
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
            this.InitializeComponent();
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
        protected override void Dispose(bool disposing)
        {
            if ((!disposing ? false : this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
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
        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmRelayBoxes));
            this.groupPanel2 = new GroupPanel();
            this.CmbCurr = new ComboBoxEx();
            this.checBox_Acc2 = new CheckBoxX();
            this.checBox_Acc1 = new CheckBoxX();
            this.groupBox2 = new GroupBox();
            this.RButDet = new RadioButton();
            this.RButShort = new RadioButton();
            this.button_RepAccTo = new ButtonX();
            this.button_RepAccFrom = new ButtonX();
            this.txtTime = new MaskedTextBox();
            this.label4 = new Label();
            this.txtGDate = new MaskedTextBox();
            this.txtHDate = new MaskedTextBox();
            this.buttonX_Close = new ButtonX();
            this.ButOk = new ButtonX();
            this.txtAmount = new DoubleInput();
            this.label8 = new Label();
            this.label2 = new Label();
            this.label1 = new Label();
            this.CmbUser = new ComboBoxEx();
            this.label3 = new Label();
            this.CmbFromBox = new ComboBoxEx();
            this.CmbToBox = new ComboBoxEx();
            this.groupPanel_Balance = new GroupPanel();
            this.label_Balance = new Label();
            this.groupPanel_SendOption = new GroupPanel();
            this.chk2 = new CheckBoxX();
            this.chk1 = new CheckBoxX();
            this.groupPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((ISupportInitialize)this.txtAmount).BeginInit();
            this.groupPanel_Balance.SuspendLayout();
            this.groupPanel_SendOption.SuspendLayout();
            base.SuspendLayout();
            this.groupPanel2.AccessibleDescription = null;
            this.groupPanel2.AccessibleName = null;
            resources.ApplyResources(this.groupPanel2, "groupPanel2");
            this.groupPanel2.BackColor = Color.Transparent;
            this.groupPanel2.CanvasColor = SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.CmbCurr);
            this.groupPanel2.Controls.Add(this.checBox_Acc2);
            this.groupPanel2.Controls.Add(this.checBox_Acc1);
            this.groupPanel2.Controls.Add(this.groupBox2);
            this.groupPanel2.Controls.Add(this.button_RepAccTo);
            this.groupPanel2.Controls.Add(this.button_RepAccFrom);
            this.groupPanel2.Controls.Add(this.txtTime);
            this.groupPanel2.Controls.Add(this.label4);
            this.groupPanel2.Controls.Add(this.txtGDate);
            this.groupPanel2.Controls.Add(this.txtHDate);
            this.groupPanel2.Controls.Add(this.buttonX_Close);
            this.groupPanel2.Controls.Add(this.ButOk);
            this.groupPanel2.Controls.Add(this.txtAmount);
            this.groupPanel2.Controls.Add(this.label8);
            this.groupPanel2.Controls.Add(this.label2);
            this.groupPanel2.Controls.Add(this.label1);
            this.groupPanel2.Controls.Add(this.CmbUser);
            this.groupPanel2.Controls.Add(this.label3);
            this.groupPanel2.Controls.Add(this.CmbFromBox);
            this.groupPanel2.Controls.Add(this.CmbToBox);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Style.BackColor2 = SystemColors.GradientInactiveCaption;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = eColorSchemePart.PanelText;
            this.groupPanel2.StyleMouseDown.CornerType = eCornerType.Square;
            this.groupPanel2.StyleMouseOver.CornerType = eCornerType.Square;
            this.groupPanel2.TitleImagePosition = eTitleImagePosition.Center;
            this.CmbCurr.AccessibleDescription = null;
            this.CmbCurr.AccessibleName = null;
            resources.ApplyResources(this.CmbCurr, "CmbCurr");
            this.CmbCurr.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.CmbCurr.BackgroundImage = null;
            this.CmbCurr.CommandParameter = null;
            this.CmbCurr.DisplayMember = "Text";
            this.CmbCurr.DrawMode = DrawMode.OwnerDrawFixed;
            this.CmbCurr.DropDownStyle = ComboBoxStyle.DropDownList;
            this.CmbCurr.Font = null;
            this.CmbCurr.FormattingEnabled = true;
            this.CmbCurr.Name = "CmbCurr";
            this.CmbCurr.Style = eDotNetBarStyle.StyleManagerControlled;
            this.checBox_Acc2.AccessibleDescription = null;
            this.checBox_Acc2.AccessibleName = null;
            resources.ApplyResources(this.checBox_Acc2, "checBox_Acc2");
            this.checBox_Acc2.BackColor = Color.Transparent;
            this.checBox_Acc2.BackgroundImage = null;
            this.checBox_Acc2.BackgroundStyle.CornerType = eCornerType.Square;
            this.checBox_Acc2.CommandParameter = null;
            this.checBox_Acc2.Name = "checBox_Acc2";
            this.checBox_Acc2.Style = eDotNetBarStyle.StyleManagerControlled;
            this.checBox_Acc2.TextColor = Color.Maroon;
            this.checBox_Acc1.AccessibleDescription = null;
            this.checBox_Acc1.AccessibleName = null;
            resources.ApplyResources(this.checBox_Acc1, "checBox_Acc1");
            this.checBox_Acc1.BackColor = Color.Transparent;
            this.checBox_Acc1.BackgroundImage = null;
            this.checBox_Acc1.BackgroundStyle.CornerType = eCornerType.Square;
            this.checBox_Acc1.CommandParameter = null;
            this.checBox_Acc1.Name = "checBox_Acc1";
            this.checBox_Acc1.Style = eDotNetBarStyle.StyleManagerControlled;
            this.checBox_Acc1.TextColor = Color.Maroon;
            this.groupBox2.AccessibleDescription = null;
            this.groupBox2.AccessibleName = null;
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.BackColor = Color.Transparent;
            this.groupBox2.BackgroundImage = null;
            this.groupBox2.Controls.Add(this.RButDet);
            this.groupBox2.Controls.Add(this.RButShort);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            this.RButDet.AccessibleDescription = null;
            this.RButDet.AccessibleName = null;
            resources.ApplyResources(this.RButDet, "RButDet");
            this.RButDet.BackgroundImage = null;
            this.RButDet.ForeColor = Color.SteelBlue;
            this.RButDet.Name = "RButDet";
            this.RButDet.UseVisualStyleBackColor = true;
            this.RButShort.AccessibleDescription = null;
            this.RButShort.AccessibleName = null;
            resources.ApplyResources(this.RButShort, "RButShort");
            this.RButShort.BackgroundImage = null;
            this.RButShort.Checked = true;
            this.RButShort.ForeColor = Color.SteelBlue;
            this.RButShort.Name = "RButShort";
            this.RButShort.TabStop = true;
            this.RButShort.UseVisualStyleBackColor = true;
            this.button_RepAccTo.AccessibleDescription = null;
            this.button_RepAccTo.AccessibleName = null;
            this.button_RepAccTo.AccessibleRole = AccessibleRole.PushButton;
            resources.ApplyResources(this.button_RepAccTo, "button_RepAccTo");
            this.button_RepAccTo.BackgroundImage = null;
            this.button_RepAccTo.Checked = true;
            this.button_RepAccTo.ColorTable = eButtonColor.Flat;
            this.button_RepAccTo.CommandParameter = null;
            this.button_RepAccTo.Name = "button_RepAccTo";
            this.button_RepAccTo.Style = eDotNetBarStyle.StyleManagerControlled;
            this.button_RepAccTo.Symbol = "";
            this.button_RepAccTo.SymbolSize = 12f;
            this.button_RepAccTo.TextColor = Color.Black;
            this.button_RepAccTo.Click += new EventHandler(this.button_RepAccTo_Click);
            this.button_RepAccFrom.AccessibleDescription = null;
            this.button_RepAccFrom.AccessibleName = null;
            this.button_RepAccFrom.AccessibleRole = AccessibleRole.PushButton;
            resources.ApplyResources(this.button_RepAccFrom, "button_RepAccFrom");
            this.button_RepAccFrom.BackgroundImage = null;
            this.button_RepAccFrom.Checked = true;
            this.button_RepAccFrom.ColorTable = eButtonColor.Flat;
            this.button_RepAccFrom.CommandParameter = null;
            this.button_RepAccFrom.Name = "button_RepAccFrom";
            this.button_RepAccFrom.Style = eDotNetBarStyle.StyleManagerControlled;
            this.button_RepAccFrom.Symbol = "";
            this.button_RepAccFrom.SymbolSize = 12f;
            this.button_RepAccFrom.TextColor = Color.Black;
            this.button_RepAccFrom.Click += new EventHandler(this.button_RepAccFrom_Click);
            this.txtTime.AccessibleDescription = null;
            this.txtTime.AccessibleName = null;
            resources.ApplyResources(this.txtTime, "txtTime");
            this.txtTime.BackColor = Color.White;
            this.txtTime.BackgroundImage = null;
            this.txtTime.Name = "txtTime";
            this.txtTime.Click += new EventHandler(this.txtTime_Click);
            this.label4.AccessibleDescription = null;
            this.label4.AccessibleName = null;
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = Color.Transparent;
            this.label4.FlatStyle = FlatStyle.Flat;
            this.label4.Name = "label4";
            this.txtGDate.AccessibleDescription = null;
            this.txtGDate.AccessibleName = null;
            resources.ApplyResources(this.txtGDate, "txtGDate");
            this.txtGDate.BackColor = Color.WhiteSmoke;
            this.txtGDate.BackgroundImage = null;
            this.txtGDate.Name = "txtGDate";
            this.txtGDate.Leave += new EventHandler(this.txtGDate_Leave);
            this.txtGDate.Click += new EventHandler(this.txtGDate_Click);
            this.txtHDate.AccessibleDescription = null;
            this.txtHDate.AccessibleName = null;
            resources.ApplyResources(this.txtHDate, "txtHDate");
            this.txtHDate.BackColor = Color.WhiteSmoke;
            this.txtHDate.BackgroundImage = null;
            this.txtHDate.Name = "txtHDate";
            this.txtHDate.Leave += new EventHandler(this.txtHDate_Leave);
            this.txtHDate.Click += new EventHandler(this.txtHDate_Click);
            this.buttonX_Close.AccessibleDescription = null;
            this.buttonX_Close.AccessibleName = null;
            this.buttonX_Close.AccessibleRole = AccessibleRole.PushButton;
            resources.ApplyResources(this.buttonX_Close, "buttonX_Close");
            this.buttonX_Close.BackgroundImage = null;
            this.buttonX_Close.Checked = true;
            this.buttonX_Close.ColorTable = eButtonColor.OrangeWithBackground;
            this.buttonX_Close.CommandParameter = null;
            this.buttonX_Close.Name = "buttonX_Close";
            this.buttonX_Close.Style = eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_Close.Symbol = "";
            this.buttonX_Close.TextColor = Color.SteelBlue;
            this.buttonX_Close.Click += new EventHandler(this.buttonX_Close_Click);
            this.ButOk.AccessibleDescription = null;
            this.ButOk.AccessibleName = null;
            this.ButOk.AccessibleRole = AccessibleRole.PushButton;
            resources.ApplyResources(this.ButOk, "ButOk");
            this.ButOk.BackgroundImage = null;
            this.ButOk.ColorTable = eButtonColor.BlueOrb;
            this.ButOk.CommandParameter = null;
            this.ButOk.Name = "ButOk";
            this.ButOk.Style = eDotNetBarStyle.StyleManagerControlled;
            this.ButOk.Symbol = "";
            this.ButOk.SymbolSize = 16f;
            this.ButOk.TextColor = Color.White;
            this.ButOk.Click += new EventHandler(this.ButOk_Click);
            this.txtAmount.AccessibleDescription = null;
            this.txtAmount.AccessibleName = null;
            this.txtAmount.AllowEmptyState = false;
            resources.ApplyResources(this.txtAmount, "txtAmount");
            this.txtAmount.BackgroundImage = null;
            this.txtAmount.BackgroundStyle.BackColor = Color.FromArgb(255, 255, 0);
            this.txtAmount.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtAmount.BackgroundStyle.CornerType = eCornerType.Square;
            this.txtAmount.ButtonCalculator.DisplayPosition = (int)resources.GetObject("txtAmount.ButtonCalculator.DisplayPosition");
            this.txtAmount.ButtonCalculator.Image = null;
            this.txtAmount.ButtonCalculator.Text = resources.GetString("txtAmount.ButtonCalculator.Text");
            this.txtAmount.ButtonClear.DisplayPosition = (int)resources.GetObject("txtAmount.ButtonClear.DisplayPosition");
            this.txtAmount.ButtonClear.Image = null;
            this.txtAmount.ButtonClear.Text = resources.GetString("txtAmount.ButtonClear.Text");
            this.txtAmount.ButtonCustom.DisplayPosition = (int)resources.GetObject("txtAmount.ButtonCustom.DisplayPosition");
            this.txtAmount.ButtonCustom.Image = null;
            this.txtAmount.ButtonCustom.Text = resources.GetString("txtAmount.ButtonCustom.Text");
            this.txtAmount.ButtonCustom2.DisplayPosition = (int)resources.GetObject("txtAmount.ButtonCustom2.DisplayPosition");
            this.txtAmount.ButtonCustom2.Image = null;
            this.txtAmount.ButtonCustom2.Text = resources.GetString("txtAmount.ButtonCustom2.Text");
            this.txtAmount.ButtonDropDown.DisplayPosition = (int)resources.GetObject("txtAmount.ButtonDropDown.DisplayPosition");
            this.txtAmount.ButtonDropDown.Image = null;
            this.txtAmount.ButtonDropDown.Text = resources.GetString("txtAmount.ButtonDropDown.Text");
            this.txtAmount.ButtonFreeText.DisplayPosition = (int)resources.GetObject("txtAmount.ButtonFreeText.DisplayPosition");
            this.txtAmount.ButtonFreeText.Image = null;
            this.txtAmount.ButtonFreeText.Shortcut = eShortcut.F2;
            this.txtAmount.ButtonFreeText.Text = resources.GetString("txtAmount.ButtonFreeText.Text");
            this.txtAmount.CommandParameter = null;
            this.txtAmount.DisplayFormat = "0.00";
            this.txtAmount.Increment = 1;
            this.txtAmount.InputHorizontalAlignment = eHorizontalAlignment.Center;
            this.txtAmount.MinValue = 0;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ShowUpDown = true;
            this.label8.AccessibleDescription = null;
            this.label8.AccessibleName = null;
            resources.ApplyResources(this.label8, "label8");
            this.label8.BackColor = Color.SteelBlue;
            this.label8.BorderStyle = BorderStyle.FixedSingle;
            this.label8.ForeColor = Color.White;
            this.label8.Name = "label8";
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = Color.Transparent;
            this.label2.FlatStyle = FlatStyle.Flat;
            this.label2.Name = "label2";
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            this.CmbUser.AccessibleDescription = null;
            this.CmbUser.AccessibleName = null;
            resources.ApplyResources(this.CmbUser, "CmbUser");
            this.CmbUser.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.CmbUser.BackgroundImage = null;
            this.CmbUser.CommandParameter = null;
            this.CmbUser.DisplayMember = "Text";
            this.CmbUser.DrawMode = DrawMode.OwnerDrawFixed;
            this.CmbUser.DropDownStyle = ComboBoxStyle.DropDownList;
            this.CmbUser.Font = null;
            this.CmbUser.FormattingEnabled = true;
            this.CmbUser.Name = "CmbUser";
            this.CmbUser.Style = eDotNetBarStyle.StyleManagerControlled;
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Font = null;
            this.label3.Name = "label3";
            this.CmbFromBox.AccessibleDescription = null;
            this.CmbFromBox.AccessibleName = null;
            resources.ApplyResources(this.CmbFromBox, "CmbFromBox");
            this.CmbFromBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.CmbFromBox.BackgroundImage = null;
            this.CmbFromBox.CommandParameter = null;
            this.CmbFromBox.DisplayMember = "Text";
            this.CmbFromBox.DrawMode = DrawMode.OwnerDrawFixed;
            this.CmbFromBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.CmbFromBox.Font = null;
            this.CmbFromBox.FormattingEnabled = true;
            this.CmbFromBox.Name = "CmbFromBox";
            this.CmbFromBox.Style = eDotNetBarStyle.StyleManagerControlled;
            this.CmbFromBox.Tag = "T_GDDET.AccNo ";
            this.CmbFromBox.SelectedIndexChanged += new EventHandler(this.CmbFromBox_SelectedIndexChanged);
            this.CmbToBox.AccessibleDescription = null;
            this.CmbToBox.AccessibleName = null;
            resources.ApplyResources(this.CmbToBox, "CmbToBox");
            this.CmbToBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.CmbToBox.BackgroundImage = null;
            this.CmbToBox.CommandParameter = null;
            this.CmbToBox.DisplayMember = "Text";
            this.CmbToBox.DrawMode = DrawMode.OwnerDrawFixed;
            this.CmbToBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.CmbToBox.Font = null;
            this.CmbToBox.FormattingEnabled = true;
            this.CmbToBox.Name = "CmbToBox";
            this.CmbToBox.Style = eDotNetBarStyle.StyleManagerControlled;
            this.CmbToBox.Tag = "T_GDDET.AccNo ";
            this.groupPanel_Balance.AccessibleDescription = null;
            this.groupPanel_Balance.AccessibleName = null;
            resources.ApplyResources(this.groupPanel_Balance, "groupPanel_Balance");
            this.groupPanel_Balance.BackColor = Color.Transparent;
            this.groupPanel_Balance.CanvasColor = SystemColors.Control;
            this.groupPanel_Balance.ColorSchemeStyle = eDotNetBarStyle.Office2007;
            this.groupPanel_Balance.Controls.Add(this.label_Balance);
            this.groupPanel_Balance.Name = "groupPanel_Balance";
            this.groupPanel_Balance.Style.BackColor2 = SystemColors.GradientInactiveCaption;
            this.groupPanel_Balance.Style.BackColorGradientAngle = 90;
            this.groupPanel_Balance.Style.BackColorSchemePart = eColorSchemePart.PanelBackground;
            this.groupPanel_Balance.Style.BorderBottom = eStyleBorderType.Solid;
            this.groupPanel_Balance.Style.BorderBottomWidth = 1;
            this.groupPanel_Balance.Style.BorderColorSchemePart = eColorSchemePart.PanelBorder;
            this.groupPanel_Balance.Style.BorderLeft = eStyleBorderType.Solid;
            this.groupPanel_Balance.Style.BorderLeftWidth = 1;
            this.groupPanel_Balance.Style.BorderRight = eStyleBorderType.Solid;
            this.groupPanel_Balance.Style.BorderRightWidth = 1;
            this.groupPanel_Balance.Style.BorderTop = eStyleBorderType.Solid;
            this.groupPanel_Balance.Style.BorderTopWidth = 1;
            this.groupPanel_Balance.Style.CornerDiameter = 4;
            this.groupPanel_Balance.Style.CornerType = eCornerType.Rounded;
            this.groupPanel_Balance.Style.TextAlignment = eStyleTextAlignment.Center;
            this.groupPanel_Balance.Style.TextColorSchemePart = eColorSchemePart.PanelText;
            this.groupPanel_Balance.StyleMouseDown.CornerType = eCornerType.Square;
            this.groupPanel_Balance.StyleMouseOver.CornerType = eCornerType.Square;
            this.groupPanel_Balance.TitleImagePosition = eTitleImagePosition.Right;
            this.label_Balance.AccessibleDescription = null;
            this.label_Balance.AccessibleName = null;
            resources.ApplyResources(this.label_Balance, "label_Balance");
            this.label_Balance.BackColor = Color.WhiteSmoke;
            this.label_Balance.ForeColor = Color.Red;
            this.label_Balance.Name = "label_Balance";
            this.groupPanel_SendOption.AccessibleDescription = null;
            this.groupPanel_SendOption.AccessibleName = null;
            resources.ApplyResources(this.groupPanel_SendOption, "groupPanel_SendOption");
            this.groupPanel_SendOption.BackColor = Color.Transparent;
            this.groupPanel_SendOption.CanvasColor = SystemColors.Control;
            this.groupPanel_SendOption.ColorSchemeStyle = eDotNetBarStyle.Office2007;
            this.groupPanel_SendOption.Controls.Add(this.chk2);
            this.groupPanel_SendOption.Controls.Add(this.chk1);
            this.groupPanel_SendOption.Name = "groupPanel_SendOption";
            this.groupPanel_SendOption.Style.BackColor2 = SystemColors.GradientInactiveCaption;
            this.groupPanel_SendOption.Style.BackColorGradientAngle = 90;
            this.groupPanel_SendOption.Style.BackColorSchemePart = eColorSchemePart.PanelBackground;
            this.groupPanel_SendOption.Style.BorderBottom = eStyleBorderType.Solid;
            this.groupPanel_SendOption.Style.BorderBottomWidth = 1;
            this.groupPanel_SendOption.Style.BorderColorSchemePart = eColorSchemePart.PanelBorder;
            this.groupPanel_SendOption.Style.BorderLeft = eStyleBorderType.Solid;
            this.groupPanel_SendOption.Style.BorderLeftWidth = 1;
            this.groupPanel_SendOption.Style.BorderRight = eStyleBorderType.Solid;
            this.groupPanel_SendOption.Style.BorderRightWidth = 1;
            this.groupPanel_SendOption.Style.BorderTop = eStyleBorderType.Solid;
            this.groupPanel_SendOption.Style.BorderTopWidth = 1;
            this.groupPanel_SendOption.Style.CornerDiameter = 4;
            this.groupPanel_SendOption.Style.CornerType = eCornerType.Rounded;
            this.groupPanel_SendOption.Style.TextAlignment = eStyleTextAlignment.Center;
            this.groupPanel_SendOption.Style.TextColorSchemePart = eColorSchemePart.PanelText;
            this.groupPanel_SendOption.StyleMouseDown.CornerType = eCornerType.Square;
            this.groupPanel_SendOption.StyleMouseOver.CornerType = eCornerType.Square;
            this.groupPanel_SendOption.TitleImagePosition = eTitleImagePosition.Right;
            this.chk2.AccessibleDescription = null;
            this.chk2.AccessibleName = null;
            resources.ApplyResources(this.chk2, "chk2");
            this.chk2.BackColor = Color.Transparent;
            this.chk2.BackgroundImage = null;
            this.chk2.BackgroundStyle.CornerType = eCornerType.Square;
            this.chk2.CommandParameter = null;
            this.chk2.Name = "chk2";
            this.chk2.Style = eDotNetBarStyle.StyleManagerControlled;
            this.chk1.AccessibleDescription = null;
            this.chk1.AccessibleName = null;
            resources.ApplyResources(this.chk1, "chk1");
            this.chk1.BackColor = Color.Transparent;
            this.chk1.BackgroundImage = null;
            this.chk1.BackgroundStyle.CornerType = eCornerType.Square;
            this.chk1.CommandParameter = null;
            this.chk1.Name = "chk1";
            this.chk1.Style = eDotNetBarStyle.StyleManagerControlled;
            this.chk1.CheckedChanged += new EventHandler(this.chk1_CheckedChanged);
            base.AccessibleDescription = null;
            base.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.SteelBlue;
            this.BackgroundImage = null;
            base.Controls.Add(this.groupPanel_SendOption);
            base.Controls.Add(this.groupPanel_Balance);
            base.Controls.Add(this.groupPanel2);
            this.Font = null;
            base.FormBorderStyle = FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.Name = "FrmRelayBoxes";
            base.Load += new EventHandler(this.FrmRelayBoxes_Load);
            base.FormClosed += new FormClosedEventHandler(this.FrmRelayBoxes_FormClosed);
            base.KeyDown += new KeyEventHandler(this.FrmRelayBoxes_KeyDown);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((ISupportInitialize)this.txtAmount).EndInit();
            this.groupPanel_Balance.ResumeLayout(false);
            this.groupPanel_SendOption.ResumeLayout(false);
            this.groupPanel_SendOption.PerformLayout();
            base.ResumeLayout(false);
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
            Attachment a = null;
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
            catch (Exception exception)
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
