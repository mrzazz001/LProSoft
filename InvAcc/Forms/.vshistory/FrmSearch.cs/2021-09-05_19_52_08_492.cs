using C1.Win.C1TrueDBGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Library.RepShow;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmSearch : Form
    { void avs(int arln)

{ 
 buttonX_Close.Text=   (arln == 0 ? "  إغـــلاق  " : "  close") ; buttonX_Clear.Text=   (arln == 0 ? "  مســـح  " : "  clear") ; button1.Text=   (arln == 0 ? "  حذف  " : "  delete") ; radioButton1.Text=   (arln == 0 ? "  بحث محتوى  " : "  content search") ; radioButton2.Text=   (arln == 0 ? "  بحث مطابق  " : "  matching search") ; groupBox2.Text=   (arln == 0 ? "  الترتيب حسب  " : "  Sort by") ; buttonX_Ok.Text=   (arln == 0 ? "  موافق  " : "  OK") ; GridCheck.Text=   (arln == 0 ? "  (Caption)<div align" : "  (Caption)<div align") ; GridCheck.Text=   (arln == 0 ? "  (Footer)<div align" : "  (Footer)<div align") ; GridCheck.Text=   (arln == 0 ? "  (Header) <div align" : "  (Header) <div align") ; GridCheck.Text=   (arln == 0 ? "  (Title)<div align" : "  (Title)<div align") ; buttonX_Additem.Text=   (arln == 0 ? "  إضافة الصنف  " : "  add item") ; c1TrueDBGrid1.Text=   (arln == 0 ? "  c1TrueDBGrid1  " : "  c1TrueDBGrid1") ; Text = "البحث - Search";this.Text=   (arln == 0 ? "  البحث - Search  " : "  Search - Search") ;}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
        }
   
        public class SColumnDictinary
        {
            public string AText = string.Empty;
            public string EText = string.Empty;
            public bool IfDefault = false;
            public string Format = string.Empty;
            public SColumnDictinary(string aText, string eText, bool ifDefault, string format)
            {
                AText = aText;
                EText = eText;
                IfDefault = ifDefault;
                Format = format;
            }
        }
        private T_SYSSETTING _SysSetting = new T_SYSSETTING();
        private List<T_SYSSETTING> listSysSetting = new List<T_SYSSETTING>();
        private int LangArEn = 0;
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRt;
        private string MainCol = string.Empty;
        public Dictionary<string, SColumnDictinary> columns_Names_visible = new Dictionary<string, SColumnDictinary>();
        public string Serach_No = string.Empty;
        private bool ifAutoOrderColumn = true;
        private T_User permission = new T_User();
        private int Row = 0;
        private int Col = 0;
        private int flag = 0;
       // private IContainer components = null;
        private ButtonX buttonX_Close;
        private ButtonX buttonX_Clear;
        private GroupBox groupBox1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private GroupBox groupBox2;
        protected ContextMenuStrip contextMenuStrip1;
        private ButtonX buttonX_Ok;
        private SuperGridControl GridCheck;
        private ButtonX buttonX_Additem;
        private C1TrueDBGrid c1TrueDBGrid1;
        private Button button1;
        private DataSet dataSet1;
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
                if (dbInstanceRt == null)
                {
                    dbInstanceRt = new Rate_DataDataContext(VarGeneral.BranchRt);
                }
                return dbInstanceRt;
            }
        }
        public int ordersflag = 0;
        public int orderstatus = 0;
        public int smsf = 0;
        public string SerachNo
        {
            get
            {
                return Serach_No;
            }
            set
            {
                Serach_No = value;
            }
        }
        public T_User Permmission
        {
            get
            {
                return permission;
            }
            set
            {
                if (value != null && value.UsrNo != string.Empty)
                {
                    permission = value;
                    if (!VarGeneral.TString.ChkStatShow(value.FilStr, 4))
                    {
                        buttonX_Additem.Enabled = false;
                    }
                    else
                    {
                        buttonX_Additem.Enabled = true;
                    }
                }
            }
        }
        public FrmSearch()
        {
            
                InitializeComponent();
                this.Load += langloads;
           
            try
            {
                Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
            }
            catch
            {
            }
            c1TrueDBGrid1.FilterBar = true;
            c1TrueDBGrid1.AllowFilter = false;
            c1TrueDBGrid1.FocusedSplit.AllowFocus = true;
            c1TrueDBGrid1.FocusedSplit.FilterActive = false;
            c1TrueDBGrid1.Focus();
            c1TrueDBGrid1.Col = 0;
            try
            {
                SendKeys.Send("{UP}");
            }
            catch
            {
            }
        }
        private void GetInvSetting()
        {
            _SysSetting = new T_SYSSETTING();
            _SysSetting = db.SystemSettingStock();
        }
        private void Frm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void SeachTyp(int tp)
        {
            if (VarGeneral.SFrmTyp == "T_SearchNumber")
            {
                GetInvSetting();
                List<T_AccDef> LAccDef = new List<T_AccDef>();
                LAccDef = (from t in db.T_AccDefs
                           orderby t.AccDef_No
                           where t.Lev == (int?)4 && t.AccCat == (int?)VarGeneral.AccTyp
                           where !t.StopedState.Value
                           where t.Mobile != string.Empty
                           where (string.IsNullOrEmpty(VarGeneral.Settings_Sys.AccSup.Trim()) || VarGeneral.Settings_Sys.AccSup.Trim() == "966") ? (t.Mobile.Length >= 10) : (t.Mobile.Length >= 7)
                           select t).ToList();
                if (LAccDef.Count() > 0)
                {
                    for (int i = 0; i < LAccDef.Count; i++)
                    {
                        if (string.IsNullOrEmpty(VarGeneral.Settings_Sys.AccSup.Trim()) || VarGeneral.Settings_Sys.AccSup.Trim() == "966")
                        {
                            if (LAccDef[i].Mobile.StartsWith("05"))
                            {
                                LAccDef[i].Mobile = "966" + LAccDef[i].Mobile.Substring(1);
                            }
                            else if (LAccDef[i].Mobile.StartsWith("009665"))
                            {
                                LAccDef[i].Mobile = LAccDef[i].Mobile.Substring(2);
                            }
                            else if (LAccDef[i].Mobile.StartsWith("0096605"))
                            {
                                LAccDef[i].Mobile = LAccDef[i].Mobile.Substring(2, 3) + LAccDef[i].Mobile.Substring(6);
                            }
                            else if (LAccDef[i].Mobile.StartsWith("96605"))
                            {
                                LAccDef[i].Mobile = LAccDef[i].Mobile.Substring(0, 3) + LAccDef[i].Mobile.Substring(4);
                            }
                            else if (!LAccDef[i].Mobile.StartsWith("96"))
                            {
                                LAccDef.RemoveAt(i);
                                i = 0;
                                continue;
                            }
                            string phoneNum = LAccDef[i].Mobile;
                            Regex regex = new Regex("^\\d{12}$");
                            Match match = regex.Match(phoneNum);
                            if (!match.Success)
                            {
                                LAccDef.RemoveAt(i);
                                i = 0;
                            }
                        }
                        else
                        {
                            LAccDef[i].Mobile = VarGeneral.Settings_Sys.AccSup.Trim() + LAccDef[i].Mobile;
                        }
                    }
                }
                VarGeneral.RepData = new DataSet();
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T_AccDef));
                DataTable table = new DataTable();
                foreach (PropertyDescriptor prop in properties)
                {
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
                foreach (T_AccDef item2 in LAccDef)
                {
                    DataRow row2 = table.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                    {
                        row2[prop.Name] = prop.GetValue(item2) ?? DBNull.Value;
                    }
                    table.Rows.Add(row2);
                }
                VarGeneral.RepData = new DataSet();
                VarGeneral.RepData.Tables.Add(table);
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_SearchNumberEmp")
            {
                if (VarGeneral.SSSLev == "D" || VarGeneral.SSSLev == "E")
                {
                    List<T_Emp> LAccDef2 = new List<T_Emp>();
                    LAccDef2 = (from t in db.T_Emps
                                orderby t.Emp_No
                                where t.EmpState.Value
                                where t.Tel != string.Empty
                                where (string.IsNullOrEmpty(VarGeneral.Settings_Sys.AccSup.Trim()) || VarGeneral.Settings_Sys.AccSup.Trim() == "966") ? (t.Tel.Length >= 10) : (t.Tel.Length >= 7)
                                select t).ToList();
                    if (LAccDef2.Count() > 0)
                    {
                        for (int i = 0; i < LAccDef2.Count; i++)
                        {
                            if (string.IsNullOrEmpty(VarGeneral.Settings_Sys.AccSup.Trim()) || VarGeneral.Settings_Sys.AccSup.Trim() == "966")
                            {
                                if (LAccDef2[i].Tel.StartsWith("05"))
                                {
                                    LAccDef2[i].Tel = "966" + LAccDef2[i].Tel.Substring(1);
                                }
                                else if (LAccDef2[i].Tel.StartsWith("009665"))
                                {
                                    LAccDef2[i].Tel = LAccDef2[i].Tel.Substring(2);
                                }
                                else if (LAccDef2[i].Tel.StartsWith("0096605"))
                                {
                                    LAccDef2[i].Tel = LAccDef2[i].Tel.Substring(2, 3) + LAccDef2[i].Tel.Substring(6);
                                }
                                else if (LAccDef2[i].Tel.StartsWith("96605"))
                                {
                                    LAccDef2[i].Tel = LAccDef2[i].Tel.Substring(0, 3) + LAccDef2[i].Tel.Substring(4);
                                }
                                else if (!LAccDef2[i].Tel.StartsWith("96"))
                                {
                                    LAccDef2.RemoveAt(i);
                                    i = 0;
                                    continue;
                                }
                                string phoneNum = LAccDef2[i].Tel;
                                Regex regex = new Regex("^\\d{12}$");
                                Match match = regex.Match(phoneNum);
                                if (!match.Success)
                                {
                                    LAccDef2.RemoveAt(i);
                                    i = 0;
                                }
                            }
                            else
                            {
                                LAccDef2[i].Tel = VarGeneral.Settings_Sys.AccSup.Trim() + LAccDef2[i].Tel;
                            }
                        }
                    }
                    VarGeneral.RepData = new DataSet();
                    PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T_Emp));
                    DataTable table = new DataTable();
                    foreach (PropertyDescriptor prop in properties)
                    {
                        table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                    }
                    foreach (T_Emp item3 in LAccDef2)
                    {
                        DataRow row2 = table.NewRow();
                        foreach (PropertyDescriptor prop in properties)
                        {
                            row2[prop.Name] = prop.GetValue(item3) ?? DBNull.Value;
                        }
                        table.Rows.Add(row2);
                    }
                    VarGeneral.RepData = new DataSet();
                    VarGeneral.RepData.Tables.Add(table);
                    DataSetFill();
                    c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
                }
                else
                {
                    List<T_AccDef> LAccDef = (from t in db.T_AccDefs
                                              where t.Lev == (int?)4 && t.AccCat == (int?)6
                                              where t.Mobile != string.Empty
                                              where (string.IsNullOrEmpty(VarGeneral.Settings_Sys.AccSup.Trim()) || VarGeneral.Settings_Sys.AccSup.Trim() == "966") ? (t.Mobile.Length >= 10) : (t.Mobile.Length >= 7)
                                              where !t.StopedState.Value
                                              orderby t.AccDef_No
                                              select t).ToList();
                    if (LAccDef.Count() > 0)
                    {
                        for (int i = 0; i < LAccDef.Count; i++)
                        {
                            if (string.IsNullOrEmpty(VarGeneral.Settings_Sys.AccSup.Trim()) || VarGeneral.Settings_Sys.AccSup.Trim() == "966")
                            {
                                if (LAccDef[i].Mobile.StartsWith("05"))
                                {
                                    LAccDef[i].Mobile = "966" + LAccDef[i].Mobile.Substring(1);
                                }
                                else if (LAccDef[i].Mobile.StartsWith("009665"))
                                {
                                    LAccDef[i].Mobile = LAccDef[i].Mobile.Substring(2);
                                }
                                else if (LAccDef[i].Mobile.StartsWith("0096605"))
                                {
                                    LAccDef[i].Mobile = LAccDef[i].Mobile.Substring(2, 3) + LAccDef[i].Mobile.Substring(6);
                                }
                                else if (LAccDef[i].Mobile.StartsWith("96605"))
                                {
                                    LAccDef[i].Mobile = LAccDef[i].Mobile.Substring(0, 3) + LAccDef[i].Mobile.Substring(4);
                                }
                                else if (!LAccDef[i].Mobile.StartsWith("96"))
                                {
                                    LAccDef.RemoveAt(i);
                                    i = 0;
                                    continue;
                                }
                                string phoneNum = LAccDef[i].Mobile;
                                Regex regex = new Regex("^\\d{12}$");
                                Match match = regex.Match(phoneNum);
                                if (!match.Success)
                                {
                                    LAccDef.RemoveAt(i);
                                    i = 0;
                                }
                            }
                            else
                            {
                                LAccDef[i].Mobile = VarGeneral.Settings_Sys.AccSup.Trim() + LAccDef[i].Mobile;
                            }
                        }
                    }
                    VarGeneral.RepData = new DataSet();
                    PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T_AccDef));
                    DataTable table = new DataTable();
                    foreach (PropertyDescriptor prop in properties)
                    {
                        table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                    }
                    foreach (T_AccDef item2 in LAccDef)
                    {
                        DataRow row2 = table.NewRow();
                        foreach (PropertyDescriptor prop in properties)
                        {
                            row2[prop.Name] = prop.GetValue(item2) ?? DBNull.Value;
                        }
                        table.Rows.Add(row2);
                    }
                    VarGeneral.RepData = new DataSet();
                    VarGeneral.RepData.Tables.Add(table);
                    DataSetFill();
                    c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
                }
            }
            if (VarGeneral.SFrmTyp == "Themes")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_SYSSETTING ";
                _RepShow.Fields = " T_SYSSETTING.smsMessage1, T_SYSSETTING.smsMessage2, T_SYSSETTING.smsMessage3, T_SYSSETTING.smsMessage4 ";
                _RepShow.Rule = " ";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "BirthPlaceNo")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_BirthPlace ";
                _RepShow.Fields = " T_BirthPlace.BirthPlaceNo, T_BirthPlace.NameA, T_BirthPlace.NameE  ";
                _RepShow.Rule = " ";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_per")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = "  T_per left JOIN  T_AccDef ON T_per.Cust_no = T_AccDef.AccDef_No ";
                _RepShow.Fields = " T_per.perno, T_per.nm,  T_AccDef.Arb_Des as nmA, T_AccDef.Eng_Des as nmE, T_per.price, T_per.day, T_per.pasno  ";
                _RepShow.Rule = " where T_per.ch = 2 ";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_per2")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = "  T_per left JOIN  T_AccDef ON T_per.Cust_no = T_AccDef.AccDef_No ";
                _RepShow.Fields = " T_per.perno, T_per.nm,  T_AccDef.Arb_Des as nmA, T_AccDef.Eng_Des as nmE, T_per.price, T_per.day, T_per.pasno  ";
                _RepShow.Rule = " where T_per.ch = 3 ";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_per3")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = "  T_per left JOIN  T_AccDef ON T_per.Cust_no = T_AccDef.AccDef_No ";
                _RepShow.Fields = " T_per.perno, T_per.nm,  T_AccDef.Arb_Des as nmA, T_AccDef.Eng_Des as nmE, T_per.price, T_per.day, T_per.pasno  ";
                _RepShow.Rule = " ";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_MTemplate")
            {
                string ctxt = @"select T_MTemplates.ID,T_MTemplates.Tamplate_Name,T_MTemplates.Message From T_MTemplates;";
                SqlConnection con = new SqlConnection(VarGeneral.BranchCS);
                SqlCommand cmd = new SqlCommand(ctxt, con);
                DataTable t = new DataTable();
                con.Open();
                t.Load(cmd.ExecuteReader());
                con.Close();
                dataSet1.Tables.Add(t);
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            //if (VarGeneral.SFrmTyp == "T_MTemplate")
            //{
            //    RepShow _RepShow = new RepShow();
            //    _RepShow.Tables = " T_MTemplates ";
            //    _RepShow.Fields = " T_MTemplates.ID, T_MTemplates.Tamplate_Name, T_MTemplates.Message ";
            //    _RepShow.Rule = " ";
            //    _RepShow = _RepShow.Save();
            //    VarGeneral.RepData = _RepShow.RepData;
            //    DataSetFill();
            //    c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            //}
            if (VarGeneral.SFrmTyp == "T_Loc")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Loc ";
                _RepShow.Fields = " T_Loc.Loc_No, T_Loc.Arb_Des, T_Loc.Eng_Des ";
                _RepShow.Rule = " ";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_BlackList")
            {
                var q = db.T_BlackLists.Select((T_BlackList t) => new
                {
                    t.CustNum,
                    t.CustNam,
                    t.IdNo
                });
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_BlackList ";
                _RepShow.Fields = " T_BlackList.CustNum, T_BlackList.CustNam, T_BlackList.IdNo ";
                _RepShow.Rule = " ";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Items")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = "  T_Items INNER JOIN  T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID ";
                _RepShow.Fields = "  T_Items.Itm_ID, T_Items.Itm_No, T_Items.Arb_Des, T_Items.Eng_Des, T_Items.StartCost, T_Items.LastCost, T_Items.UntPri1, T_Items.AvrageCost, T_CATEGORY.Arb_Des as Arb_Des_Cat, T_CATEGORY.Eng_Des as Eng_Des_Cat, T_Items.BarCod1, T_Items.BarCod2, T_Items.BarCod3, T_Items.BarCod4, T_Items.BarCod5 ";
                _RepShow.Rule = " ";
                try
                {
                    db.ExecuteCommand("select " + _RepShow.Fields + " From " + _RepShow.Tables + " order by  CONVERT(INT, LEFT(T_Items.Itm_No, PATINDEX('%[^0-9]%', T_Items.Itm_No + 'z')-1)) ");
                    _RepShow.Rule = " order by  CONVERT(INT, LEFT(T_Items.Itm_No, PATINDEX('%[^0-9]%', T_Items.Itm_No + 'z')-1)) ";
                }
                catch
                {
                    _RepShow.Rule = " order by T_Items.Itm_No ";
                }
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_ItemSerial")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_ItemSerial ";
                _RepShow.Fields = "  T_ItemSerial.ItmNo, T_ItemSerial.SerialStatus, T_ItemSerial.SerialKey, T_ItemSerial.id  ";
                _RepShow.Rule = " order by SerialKey";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_CATEGORY")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_CATEGORY ";
                _RepShow.Fields = " T_CATEGORY.CAT_No, T_CATEGORY.Arb_Des, T_CATEGORY.Eng_Des ";
                _RepShow.Rule = " order by CAT_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Snd")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = "   T_Snd left JOIN  T_per ON T_Snd.perno = T_per.perno left JOIN  T_AccDef ON T_per.Cust_no = T_AccDef.AccDef_No ";
                _RepShow.Fields = "  T_Snd.fNo, T_AccDef.Arb_Des as SndName, T_AccDef.Eng_Des as SndNameE, T_Snd.romno, T_Snd.perno, T_Snd.price, T_Snd.dt, T_Snd.tm  ";
                _RepShow.Rule = " order by fNo";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Reserv")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Reserv ";
                _RepShow.Fields = " T_Reserv.ResrvNo, T_Reserv.PerNm, T_Reserv.Dat ";
                _RepShow.Rule = " order by ResrvNo";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Unit")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Unit ";
                _RepShow.Fields = " T_Unit.Unit_No, T_Unit.Arb_Des, T_Unit.Eng_Des ";
                _RepShow.Rule = " order by Unit_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Units")
            {
                string ru = " Where ", rid = " T_Unit.Unit_No ", rm = string.Empty, or = " or ";
                T_Item itm = db.StockItem(VarGeneral.sFrmCategoryS);
                if (itm.Unit1 != null)
                {
                    if (rm == string.Empty)
                    { rm = ru; rm += rid + " = " + itm.Unit1; }
                    else
                        rm += or + rid + " = " + itm.Unit1;
                }
                if (itm.Unit2 != null)
                {
                    if (rm == string.Empty)
                    { rm = ru; rm += rid + " = " + itm.Unit2; }
                    else
                        rm += or + rid + " = " + itm.Unit2;
                }
                if (itm.Unit3 != null)
                {
                    if (rm == string.Empty)
                    { rm = ru; rm += rid + " = " + itm.Unit3; }
                    else
                        rm += or + rid + " = " + itm.Unit3;
                }
                if (itm.Unit4 != null)
                {
                    if (rm == string.Empty)
                    { rm = ru; rm += rid + " = " + itm.Unit4; }
                    else
                        rm += or + rid + " = " + itm.Unit4;
                }
                if (itm.Unit5 != null)
                {
                    if (rm == string.Empty)
                    { rm = ru; rm += rid + " = " + itm.Unit5; }
                    else
                        rm += or + rid + " = " + itm.Unit5;
                }
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Unit ";
                _RepShow.Fields = " T_Unit.Unit_No, T_Unit.Arb_Des, T_Unit.Eng_Des ";
                _RepShow.Rule = rm + " order by Unit_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_sertyp")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_sertyp ";
                _RepShow.Fields = " T_sertyp.Serv_No, T_sertyp.Arb_Des, T_sertyp.Eng_Des  ";
                _RepShow.Rule = " order by Serv_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_IDType")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_IDType ";
                _RepShow.Fields = " T_IDType.IDType_ID, T_IDType.Arb_Des, T_IDType.Eng_Des ";
                _RepShow.Rule = " order by IDType_ID";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_InvDetNote")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_InvDetNote ";
                _RepShow.Fields = " T_InvDetNote.InvDetNote_No, T_InvDetNote.Arb_Des, T_InvDetNote.Eng_Des  ";
                _RepShow.Rule = " order by InvDetNote_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_BankPeaper")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_BankPeaper ";
                _RepShow.Fields = " T_BankPeaper.PageNo, T_BankPeaper.PageDate, T_BankPeaper.PageDatePay, T_BankPeaper.BankAcc, T_BankPeaper.BranchAcc, T_BankPeaper.ID, T_BankPeaper.Amount ,T_BankPeaper.gdID ";
                _RepShow.Rule = " where T_BankPeaper.IfDel = 0 order by ID";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_AccCat")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_AccCat ";
                _RepShow.Fields = " T_AccCat.AccCat_No, T_AccCat.Arb_Des, T_AccCat.Eng_Des ";
                _RepShow.Rule = " order by AccCat_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Curency")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Curency ";
                _RepShow.Fields = " T_Curency.Curency_No, T_Curency.Arb_Des, T_Curency.Eng_Des, T_Curency.Rate, T_Curency.Symbol  ";
                _RepShow.Rule = " order by Curency_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_CstTbl")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_CstTbl ";
                _RepShow.Fields = " T_CstTbl.Cst_No, T_CstTbl.Arb_Des, T_CstTbl.Eng_Des ";
                _RepShow.Rule = " order by Cst_No ";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Branch")
            {
                try
                {
                    RepShow _RepShow = new RepShow();
                    _RepShow.Tables = " T_Branch ";
                    _RepShow.Fields = " *  ";
                    _RepShow.Rule = " order by Branch_no";
                    VarGeneral.RepShowStock_Rat = "Rate";
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepShowStock_Rat = string.Empty;
                    VarGeneral.RepData = _RepShow.RepData;
                    DataSetFill();
                    c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
                }
                catch
                {
                    VarGeneral.RepShowStock_Rat = string.Empty;
                }
            }
            if (VarGeneral.SFrmTyp == "T_Mndob")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Mndob ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " order by Mnd_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_tran")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_tran left JOIN  T_per ON T_tran.perno = T_per.perno left JOIN  T_AccDef ON T_per.Cust_no = T_AccDef.AccDef_No ";
                _RepShow.Fields = " T_tran.fat," + ((LangArEn == 0) ? " T_AccDef.Arb_Des " : " T_AccDef.Eng_Des") + " as nm , T_tran.romno, T_tran.price  ";
                _RepShow.Rule = " where T_per.ch = 2 order by ID";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_tranToLeave")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_tran left JOIN  T_per ON T_tran.perno = T_per.perno left JOIN  T_AccDef ON T_per.Cust_no = T_AccDef.AccDef_No ";
                _RepShow.Fields = " T_tran.fat," + ((LangArEn == 0) ? " T_AccDef.Arb_Des " : " T_AccDef.Eng_Des") + " as nm , T_tran.romno, T_tran.price  ";
                _RepShow.Rule = " where T_per.ch = 3 order by ID";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Mndob_Extrnal")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Mndob ";
                _RepShow.Fields = " T_Mndob.Mnd_No, T_Mndob.Arb_Des, T_Mndob.Eng_Des   ";
                _RepShow.Rule = " where T_Mndob.Mnd_Typ = 1 order by Mnd_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Store")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Store ";
                _RepShow.Fields = "  T_Store.Stor_ID, T_Store.Arb_Des, T_Store.Eng_Des, T_Store.Tel, T_Store.City, T_Store.Address   ";
                _RepShow.Rule = " order by Stor_ID";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_tel")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_tel left JOIN T_per ON T_tel.perno = T_per.perno ";
                _RepShow.Fields = " T_tel.ID, T_tel.perno, T_tel.romno, T_tel.price  ";
                _RepShow.Rule = " where T_per.ch = 2 order by T_tel.ID";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_telToLeave")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_tel left JOIN T_per ON T_tel.perno = T_per.perno ";
                _RepShow.Fields = " T_tel.ID, T_tel.perno, T_tel.romno, T_tel.price  ";
                _RepShow.Rule = " where T_per.ch = 3 order by T_tel.ID";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Driv")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Chauffeur ";
                _RepShow.Fields = " T_Chauffeur.chauffeur_No, T_Chauffeur.Arb_Des, T_Chauffeur.Eng_Des ";
                _RepShow.Rule = " order by chauffeur_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Waiter")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Waiter ";
                _RepShow.Fields = " T_Waiter.waiter_No, T_Waiter.Arb_Des, T_Waiter.Eng_Des  ";
                _RepShow.Rule = " order by waiter_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_AccDef")
            {
                GetInvSetting();
                List<T_AccDef> LAccDef = new List<T_AccDef>();
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_AccDef ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " where (T_AccDef.Lev = 4 and T_AccDef.AccCat = " + VarGeneral.AccTyp + " and T_AccDef.Sts = 0) and T_AccDef.StopedState = 0 order by AccDef_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                if ((VarGeneral.TString.ChkStatShow(_SysSetting.Seting, VarGeneral.AccTyp) && VarGeneral.AccTyp != 8) || VarGeneral.StockOnly)
                {
                    _RepShow = new RepShow();
                    _RepShow.Tables = " T_AccDef ";
                    _RepShow.Fields = " *  ";
                    _RepShow.Rule = " where (T_AccDef.Lev = 4 and T_AccDef.Sts = 0 ) and ( T_AccDef.AccCat = 4 or T_AccDef.AccCat = 5 ) or (" + (VarGeneral.StockOnly ? " T_AccDef.AccDef_No = '4011001' " : "1 = 2") + ") and T_AccDef.StopedState = 0 ";
                    if (VarGeneral.SSSTyp == 0 && VarGeneral.InvTyp == 555)
                    {
                        _RepShow.Rule += " or ( AccDef_No = '1020001')";
                    }
                    _RepShow.Rule += " order by AccDef_No ";
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                }
                else if (VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 6))
                {
                    _RepShow = new RepShow();
                    _RepShow.Tables = " T_AccDef ";
                    _RepShow.Fields = " *  ";
                    _RepShow.Rule = " where (T_AccDef.Lev = 4 and T_AccDef.Sts = 0 ) and T_AccDef.StopedState = 0 order by AccDef_No";
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                }
                if ((VarGeneral.SSSLev == "H" || VarGeneral.SSSLev == "X") && VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 47) && !VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 6))
                {
                    _RepShow = new RepShow();
                    _RepShow.Tables = " T_AccDef ";
                    _RepShow.Fields = " *  ";
                    _RepShow.Rule = " where (T_AccDef.Lev = 4 and (T_AccDef.AccCat = " + VarGeneral.AccTyp + " or T_AccDef.AccCat = 11) and T_AccDef.Sts = 0 ) and T_AccDef.StopedState = 0 order by AccDef_No";
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                    if (VarGeneral.TString.ChkStatShow(_SysSetting.Seting, VarGeneral.AccTyp) && VarGeneral.AccTyp != 8)
                    {
                        _RepShow = new RepShow();
                        _RepShow.Tables = " T_AccDef ";
                        _RepShow.Fields = " *  ";
                        _RepShow.Rule = " where (T_AccDef.Lev = 4 and T_AccDef.Sts = 0) and (T_AccDef.AccCat = 4 or T_AccDef.AccCat = 5 or T_AccDef.AccCat = 11) and T_AccDef.StopedState = 0 order by AccDef_No";
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                    }
                }
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_AccDef2")
            {
                GetInvSetting();
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_AccDef ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " where (T_AccDef.Lev = 4 and T_AccDef.AccCat = " + VarGeneral.AccTyp + " and T_AccDef.Sts = 0) and T_AccDef.StopedState = 0 order by AccDef_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_AccDef3")
            {
                GetInvSetting();
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_AccDef ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " where (T_AccDef.Lev = 4 and ( " + ((VarGeneral.SSSTyp == 0) ? " T_AccDef.AccDef_No = '1020001' " : " (T_AccDef.AccCat = 2 or T_AccDef.AccCat = 3) ") + ") and T_AccDef.Sts = 0) and T_AccDef.StopedState = 0 order by AccDef_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_AccDef4")
            {
                GetInvSetting();
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_AccDef ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " order by AccDef_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_AccDef5")
            {
                GetInvSetting();
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_AccDef ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " where (T_AccDef.Lev != 4) and T_AccDef.StopedState = 0 order by AccDef_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "AccDefID_Setting")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_AccDef ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " where (T_AccDef.Lev = 4 and T_AccDef.Sts = 0 ) and T_AccDef.StopedState = 0 order by AccDef_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "AccDefID_Customer")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_AccDef ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " where (T_AccDef.AccCat = " + VarGeneral.AccTyp + " and T_AccDef.Lev = 3 and (" + ((VarGeneral.AccTyp == 3) ? " 1=1 " : ((VarGeneral.AccTyp == 4) ? " AccDef_No Like '1%' " : " AccDef_No Like '2%'  ")) + ")) and T_AccDef.StopedState = 0  order by AccDef_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "Acc_BankBr")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_AccDef ";
                _RepShow.Fields = " * ";
                _RepShow.Rule = " where ( T_AccDef.AccCat = 3 and T_AccDef.Lev = 4 and  T_AccDef.ParAcc = " + VarGeneral.AccTyp + " ) and T_AccDef.StopedState = 0  order by AccDef_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "AccDefID_Banks")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_AccDef ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " where ( T_AccDef.Lev = 2 and  T_AccDef.AccDef_No Like '1%' ) and T_AccDef.StopedState = 0  order by AccDef_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "AccDefID_Boxes")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_AccDef ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " where ( T_AccDef.Lev = 3 and T_AccDef.AccDef_No Like '1%' and T_AccDef.AccCat = 2 ) and T_AccDef.StopedState = 0  order by AccDef_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_AccDef_Suppliers")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_AccDef ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " where ( T_AccDef.Lev = 4 and  T_AccDef.AccCat = " + VarGeneral.AccTyp + ") and T_AccDef.StopedState = 0  order by AccDef_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_AccDef_CustomerStoped")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_AccDef ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " where ( T_AccDef.Lev = 4 and  T_AccDef.AccCat = " + VarGeneral.AccTyp + ") and T_AccDef.StopedState = 1  order by AccDef_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_AccDef_Banks")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_AccDef ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " where ( T_AccDef.Lev = 3 and  T_AccDef.AccCat = " + VarGeneral.AccTyp + ") and T_AccDef.StopedState = 0  order by AccDef_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_User")
            {
                try
                {
                    RepShow _RepShow = new RepShow();
                    _RepShow.Tables = " T_Users ";
                    _RepShow.Fields = " T_Users.UsrNo, T_Users.UsrNamA, T_Users.UsrNamE  ";
                    _RepShow.Rule = " where T_Users.Usr_ID != 1 order by UsrNo";
                    VarGeneral.RepShowStock_Rat = "Rate";
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepShowStock_Rat = string.Empty;
                    VarGeneral.RepData = _RepShow.RepData;
                    DataSetFill();
                    c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
                }
                catch
                {
                    VarGeneral.RepShowStock_Rat = string.Empty;
                }
            }
            if (VarGeneral.SFrmTyp == "T_User_Log_POS")
            {
                try
                {
                    RepShow _RepShow = new RepShow();
                    _RepShow.Tables = " T_Users ";
                    _RepShow.Fields = "  T_Users.UsrNo, T_Users.UsrNamA, T_Users.UsrNamE ";
                    _RepShow.Rule = " where T_Users.UserPointTyp = 1 or T_Users.Usr_ID = 1 order by Usr_ID";
                    VarGeneral.RepShowStock_Rat = "Rate";
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepShowStock_Rat = string.Empty;
                    VarGeneral.RepData = _RepShow.RepData;
                    DataSetFill();
                    c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
                }
                catch
                {
                    VarGeneral.RepShowStock_Rat = string.Empty;
                }
            }
            if (VarGeneral.SFrmTyp == "T_Offer")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Offer ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " where T_Offer.OfferHeadTyp = " + VarGeneral.InvTyp + " order by T_Offer.OfferHeadNo";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (Program.iscarversion())
            {
                if (VarGeneral.SFrmTyp == "T_Inv")
                {
                    int vSts = dbc.StockUser(VarGeneral.UserNo).UserPointTyp.Value;
                    RepShow _RepShow = new RepShow();
                    _RepShow.Tables = " T_INVHED ";
                    _RepShow.Fields = " T_INVHED.ArbTaf,T_INVHED.CusVenMob, T_INVHED.CashPay, T_INVHED.CashPayLocCur,T_INVHED.PlateNo,T_INVHED.ModelNo,T_INVHED.chauffeurNo, T_INVHED.CommMnd_Inv, T_INVHED.CompanyID, T_INVHED.CREATED_BY, T_INVHED.CreditPay, T_INVHED.CreditPayLocCur, T_INVHED.CurTyp, T_INVHED.CustNet, T_INVHED.CustPri, T_INVHED.CustRep,T_INVHED.CusVenMob, T_INVHED.CusVenAdd, T_INVHED.CusVenNo, T_INVHED.CusVenTel, T_INVHED.DATE_CREATED, T_INVHED.DATE_MODIFIED, T_INVHED.EstDat, T_INVHED.ExtrnalCostGaidID, T_INVHED.GadeId, T_INVHED.GadeNo, T_INVHED.GDat, T_INVHED.HDat, T_INVHED.IfDel, T_INVHED.IfPrint, T_INVHED.IfRet, T_INVHED.IfTrans, T_INVHED.InvAddCost, T_INVHED.InvAddCostExtrnal, T_INVHED.InvAddCostExtrnalLoc, T_INVHED.InvAddCostLoc, T_INVHED.InvCash, T_INVHED.InvCashPay, T_INVHED.InvCashPayNm, T_INVHED.InvCost, T_INVHED.InvCstNo, T_INVHED.InvDisPrs, ((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints, T_INVHED.InvDisValLocCur, T_INVHED.InvHed_ID, T_INVHED.InvId, T_INVHED.InvNet, T_INVHED.InvNetLocCur, T_INVHED.InvNo, T_INVHED.InvQty, T_INVHED.InvTot, T_INVHED.InvTotLocCur, T_INVHED.InvTyp, T_INVHED.InvWight_T, T_INVHED.IsExtrnalGaid, T_INVHED.LTim, T_INVHED.MndExtrnal, T_INVHED.MndNo, T_INVHED.MODIFIED_BY, T_INVHED.NetworkPay, T_INVHED.NetworkPayLocCur, T_INVHED.OrderTyp, T_INVHED.Puyaid, T_INVHED.RefNo, T_INVHED.Remark, T_INVHED.Remming, T_INVHED.RetId, T_INVHED.RetNo, T_INVHED.RoomNo, T_INVHED.RoomPerson, T_INVHED.RoomSts, T_INVHED.SalsManNam, T_INVHED.SalsManNo, T_INVHED.ServiceValue, T_INVHED.Sts, T_INVHED.ToStore, T_INVHED.ToStoreNm,case when T_INVHED.CusVenNo <> '' then (select " + ((LangArEn == 0) ? " T_AccDef.Arb_Des " : " T_AccDef.Eng_Des") + " from T_AccDef where T_AccDef.AccDef_No = T_INVHED.CusVenNo) else T_INVHED.CusVenNm end as CusVenNm,case when T_INVHED.CusVenNo <> '' then (select T_AccDef.Mobile from T_AccDef where T_AccDef.AccDef_No = T_INVHED.CusVenNo) else '' end as CusVenAdd  ";
                    _RepShow.Rule = " where InvTyp = " + VarGeneral.InvTyp + " and IfDel <> 1 " + ((vSts == 1) ? (" and SalsManNo = '" + VarGeneral.UserNo + "'") : "  order by InvHed_ID");
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                    DataSetFill();
                    c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
                }
            }
            else
            if (VarGeneral.SFrmTyp == "T_Inv")
            {
                int vSts = dbc.StockUser(VarGeneral.UserNo).UserPointTyp.Value;
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_INVHED ";
                _RepShow.Fields = " T_INVHED.ArbTaf, T_INVHED.CusVenMob,T_INVHED.CashPay, T_INVHED.CashPayLocCur, T_INVHED.chauffeurNo, T_INVHED.CommMnd_Inv, T_INVHED.CompanyID, T_INVHED.CREATED_BY, T_INVHED.CreditPay, T_INVHED.CreditPayLocCur, T_INVHED.CurTyp, T_INVHED.CustNet, T_INVHED.CustPri, T_INVHED.CustRep, T_INVHED.CusVenAdd, T_INVHED.CusVenNo, T_INVHED.CusVenTel, T_INVHED.DATE_CREATED, T_INVHED.DATE_MODIFIED, T_INVHED.EstDat, T_INVHED.ExtrnalCostGaidID, T_INVHED.GadeId, T_INVHED.GadeNo, T_INVHED.GDat, T_INVHED.HDat, T_INVHED.IfDel, T_INVHED.IfPrint, T_INVHED.IfRet, T_INVHED.IfTrans, T_INVHED.InvAddCost, T_INVHED.InvAddCostExtrnal, T_INVHED.InvAddCostExtrnalLoc, T_INVHED.InvAddCostLoc, T_INVHED.InvCash, T_INVHED.InvCashPay, T_INVHED.InvCashPayNm, T_INVHED.InvCost, T_INVHED.InvCstNo, T_INVHED.InvDisPrs, ((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints, T_INVHED.InvDisValLocCur, T_INVHED.InvHed_ID, T_INVHED.InvId, T_INVHED.InvNet, T_INVHED.InvNetLocCur, T_INVHED.InvNo, T_INVHED.InvQty, T_INVHED.InvTot, T_INVHED.InvTotLocCur, T_INVHED.InvTyp, T_INVHED.InvWight_T, T_INVHED.IsExtrnalGaid, T_INVHED.LTim, T_INVHED.MndExtrnal, T_INVHED.MndNo, T_INVHED.MODIFIED_BY, T_INVHED.NetworkPay, T_INVHED.NetworkPayLocCur, T_INVHED.OrderTyp, T_INVHED.Puyaid, T_INVHED.RefNo, T_INVHED.Remark, T_INVHED.Remming, T_INVHED.RetId, T_INVHED.RetNo, T_INVHED.RoomNo, T_INVHED.RoomPerson, T_INVHED.RoomSts, T_INVHED.SalsManNam, T_INVHED.SalsManNo, T_INVHED.ServiceValue, T_INVHED.Sts, T_INVHED.ToStore, T_INVHED.ToStoreNm,case when T_INVHED.CusVenNo <> '' then (select " + ((LangArEn == 0) ? " T_AccDef.Arb_Des " : " T_AccDef.Eng_Des") + " from T_AccDef where T_AccDef.AccDef_No = T_INVHED.CusVenNo) else T_INVHED.CusVenNm end as CusVenNm,case when T_INVHED.CusVenNo <> '' then (select T_AccDef.Mobile from T_AccDef where T_AccDef.AccDef_No = T_INVHED.CusVenNo) else '' end as CusVenAdd  ";
                _RepShow.Rule = " where InvTyp = " + VarGeneral.InvTyp + " and IfDel <> 1 " + ((vSts == 1) ? (" and SalsManNo = '" + VarGeneral.UserNo + "'") : "  order by InvHed_ID");
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_InvDeleted")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_INVHED ";
                _RepShow.Fields = " T_INVHED.ArbTaf, T_INVHED.CashPay, T_INVHED.CashPayLocCur, T_INVHED.chauffeurNo, T_INVHED.CommMnd_Inv, T_INVHED.CompanyID, T_INVHED.CREATED_BY, T_INVHED.CreditPay, T_INVHED.CreditPayLocCur, T_INVHED.CurTyp, T_INVHED.CustNet, T_INVHED.CustPri, T_INVHED.CustRep, T_INVHED.CusVenAdd, T_INVHED.CusVenNo, T_INVHED.CusVenTel, T_INVHED.DATE_CREATED, T_INVHED.DATE_MODIFIED, T_INVHED.EstDat, T_INVHED.ExtrnalCostGaidID, T_INVHED.GadeId, T_INVHED.GadeNo, T_INVHED.GDat, T_INVHED.HDat, T_INVHED.IfDel, T_INVHED.IfPrint, T_INVHED.IfRet, T_INVHED.IfTrans, T_INVHED.InvAddCost, T_INVHED.InvAddCostExtrnal, T_INVHED.InvAddCostExtrnalLoc, T_INVHED.InvAddCostLoc, T_INVHED.InvCash, T_INVHED.InvCashPay, T_INVHED.InvCashPayNm, T_INVHED.InvCost, T_INVHED.InvCstNo, T_INVHED.InvDisPrs, ((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints, T_INVHED.InvDisValLocCur, T_INVHED.InvHed_ID, T_INVHED.InvId, T_INVHED.InvNet, T_INVHED.InvNetLocCur, T_INVHED.InvNo, T_INVHED.InvQty, T_INVHED.InvTot, T_INVHED.InvTotLocCur, T_INVHED.InvTyp, T_INVHED.InvWight_T, T_INVHED.IsExtrnalGaid, T_INVHED.LTim, T_INVHED.MndExtrnal, T_INVHED.MndNo, T_INVHED.MODIFIED_BY, T_INVHED.NetworkPay, T_INVHED.NetworkPayLocCur, T_INVHED.OrderTyp, T_INVHED.Puyaid, T_INVHED.RefNo, T_INVHED.Remark, T_INVHED.Remming, T_INVHED.RetId, T_INVHED.RetNo, T_INVHED.RoomNo, T_INVHED.RoomPerson, T_INVHED.RoomSts, T_INVHED.SalsManNam, T_INVHED.SalsManNo, T_INVHED.ServiceValue, T_INVHED.Sts, T_INVHED.ToStore, T_INVHED.ToStoreNm,case when T_INVHED.CusVenNo <> '' then (select " + ((LangArEn == 0) ? " T_AccDef.Arb_Des " : " T_AccDef.Eng_Des") + " from T_AccDef where T_AccDef.AccDef_No = T_INVHED.CusVenNo) else T_INVHED.CusVenNm end as CusVenNm  ";
                _RepShow.Rule = " where InvTyp = " + VarGeneral.InvTyp + " and IfDel = 1  order by InvHed_ID";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_InvSalReturn")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_INVHED ";
                _RepShow.Fields = " T_INVHED.ArbTaf, T_INVHED.CashPay, T_INVHED.CashPayLocCur, T_INVHED.chauffeurNo, T_INVHED.CommMnd_Inv, T_INVHED.CompanyID, T_INVHED.CREATED_BY, T_INVHED.CreditPay, T_INVHED.CreditPayLocCur, T_INVHED.CurTyp, T_INVHED.CustNet, T_INVHED.CustPri, T_INVHED.CustRep, T_INVHED.CusVenAdd, T_INVHED.CusVenNo, T_INVHED.CusVenTel, T_INVHED.DATE_CREATED, T_INVHED.DATE_MODIFIED, T_INVHED.EstDat, T_INVHED.ExtrnalCostGaidID, T_INVHED.GadeId, T_INVHED.GadeNo, T_INVHED.GDat, T_INVHED.HDat, T_INVHED.IfDel, T_INVHED.IfPrint, T_INVHED.IfRet, T_INVHED.IfTrans, T_INVHED.InvAddCost, T_INVHED.InvAddCostExtrnal, T_INVHED.InvAddCostExtrnalLoc, T_INVHED.InvAddCostLoc, T_INVHED.InvCash, T_INVHED.InvCashPay, T_INVHED.InvCashPayNm, T_INVHED.InvCost, T_INVHED.InvCstNo, T_INVHED.InvDisPrs, ((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints, T_INVHED.InvDisValLocCur, T_INVHED.InvHed_ID, T_INVHED.InvId, T_INVHED.InvNet, T_INVHED.InvNetLocCur, T_INVHED.InvNo, T_INVHED.InvQty, T_INVHED.InvTot, T_INVHED.InvTotLocCur, T_INVHED.InvTyp, T_INVHED.InvWight_T, T_INVHED.IsExtrnalGaid, T_INVHED.LTim, T_INVHED.MndExtrnal, T_INVHED.MndNo, T_INVHED.MODIFIED_BY, T_INVHED.NetworkPay, T_INVHED.NetworkPayLocCur, T_INVHED.OrderTyp, T_INVHED.Puyaid, T_INVHED.RefNo, T_INVHED.Remark, T_INVHED.Remming, T_INVHED.RetId, T_INVHED.RetNo, T_INVHED.RoomNo, T_INVHED.RoomPerson, T_INVHED.RoomSts, T_INVHED.SalsManNam, T_INVHED.SalsManNo, T_INVHED.ServiceValue, T_INVHED.Sts, T_INVHED.ToStore, T_INVHED.ToStoreNm,case when T_INVHED.CusVenNo <> '' then (select " + ((LangArEn == 0) ? " T_AccDef.Arb_Des " : " T_AccDef.Eng_Des") + " from T_AccDef where T_AccDef.AccDef_No = T_INVHED.CusVenNo) else T_INVHED.CusVenNm end as CusVenNm  ";
                if (ordersflag == 1)
                    _RepShow.Rule = " where InvTyp = " + VarGeneral.InvTypRt.ToString() + " and IfDel = 0  and OrderStatus=" + (orderstatus.ToString()) + " and IfRet = 0 order by InvHed_ID";
                else
                    _RepShow.Rule = " where InvTyp = " + ((VarGeneral.InvTypRt == 1001) ? 1 : VarGeneral.InvTypRt) + ((VarGeneral.InvTypRt == 17 || VarGeneral.InvTypRt == 1001) ? VarGeneral.itmDes : string.Empty) + " and IfDel = 0 and IfRet = 0 order by InvHed_ID";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Draft")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_INVHED ";
                _RepShow.Fields = " T_INVHED.ArbTaf, T_INVHED.CashPay, T_INVHED.CashPayLocCur, T_INVHED.chauffeurNo, T_INVHED.CommMnd_Inv, T_INVHED.CompanyID, T_INVHED.CREATED_BY, T_INVHED.CreditPay, T_INVHED.CreditPayLocCur, T_INVHED.CurTyp, T_INVHED.CustNet, T_INVHED.CustPri, T_INVHED.CustRep, T_INVHED.CusVenAdd, T_INVHED.CusVenNo, T_INVHED.CusVenTel, T_INVHED.DATE_CREATED, T_INVHED.DATE_MODIFIED, T_INVHED.EstDat, T_INVHED.ExtrnalCostGaidID, T_INVHED.GadeId, T_INVHED.GadeNo, T_INVHED.GDat, T_INVHED.HDat, T_INVHED.IfDel, T_INVHED.IfPrint, T_INVHED.IfRet, T_INVHED.IfTrans, T_INVHED.InvAddCost, T_INVHED.InvAddCostExtrnal, T_INVHED.InvAddCostExtrnalLoc, T_INVHED.InvAddCostLoc, T_INVHED.InvCash, T_INVHED.InvCashPay, T_INVHED.InvCashPayNm, T_INVHED.InvCost, T_INVHED.InvCstNo, T_INVHED.InvDisPrs, ((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints, T_INVHED.InvDisValLocCur, T_INVHED.InvHed_ID, T_INVHED.InvId, T_INVHED.InvNet, T_INVHED.InvNetLocCur, T_INVHED.InvNo, T_INVHED.InvQty, T_INVHED.InvTot, T_INVHED.InvTotLocCur, T_INVHED.InvTyp, T_INVHED.InvWight_T, T_INVHED.IsExtrnalGaid, T_INVHED.LTim, T_INVHED.MndExtrnal, T_INVHED.MndNo, T_INVHED.MODIFIED_BY, T_INVHED.NetworkPay, T_INVHED.NetworkPayLocCur, T_INVHED.OrderTyp, T_INVHED.Puyaid, T_INVHED.RefNo, T_INVHED.Remark, T_INVHED.Remming, T_INVHED.RetId, T_INVHED.RetNo, T_INVHED.RoomNo, T_INVHED.RoomPerson, T_INVHED.RoomSts, T_INVHED.SalsManNam, T_INVHED.SalsManNo, T_INVHED.ServiceValue, T_INVHED.Sts, T_INVHED.ToStore, T_INVHED.ToStoreNm,case when T_INVHED.CusVenNo <> '' then (select " + ((LangArEn == 0) ? " T_AccDef.Arb_Des " : " T_AccDef.Eng_Des") + " from T_AccDef where T_AccDef.AccDef_No = T_INVHED.CusVenNo) else T_INVHED.CusVenNm end as CusVenNm  ";
                _RepShow.Rule = " where InvTyp = " + VarGeneral.DraftBillId.ToString() + " AND CINVType=" + VarGeneral.InvTyp.ToString() + " and SalsManNo = '" + VarGeneral.UserNo + "'" + "  order by InvHed_ID";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_InvSalReturnExchag")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_INVHED ";
                _RepShow.Fields = " T_INVHED.ArbTaf, T_INVHED.CashPay, T_INVHED.CashPayLocCur, T_INVHED.chauffeurNo, T_INVHED.CommMnd_Inv, T_INVHED.CompanyID, T_INVHED.CREATED_BY, T_INVHED.CreditPay, T_INVHED.CreditPayLocCur, T_INVHED.CurTyp, T_INVHED.CustNet, T_INVHED.CustPri, T_INVHED.CustRep, T_INVHED.CusVenAdd, T_INVHED.CusVenNo, T_INVHED.CusVenTel, T_INVHED.DATE_CREATED, T_INVHED.DATE_MODIFIED, T_INVHED.EstDat, T_INVHED.ExtrnalCostGaidID, T_INVHED.GadeId, T_INVHED.GadeNo, T_INVHED.GDat, T_INVHED.HDat, T_INVHED.IfDel, T_INVHED.IfPrint, T_INVHED.IfRet, T_INVHED.IfTrans, T_INVHED.InvAddCost, T_INVHED.InvAddCostExtrnal, T_INVHED.InvAddCostExtrnalLoc, T_INVHED.InvAddCostLoc, T_INVHED.InvCash, T_INVHED.InvCashPay, T_INVHED.InvCashPayNm, T_INVHED.InvCost, T_INVHED.InvCstNo, T_INVHED.InvDisPrs, ((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints, T_INVHED.InvDisValLocCur, T_INVHED.InvHed_ID, T_INVHED.InvId, T_INVHED.InvNet, T_INVHED.InvNetLocCur, T_INVHED.InvNo, T_INVHED.InvQty, T_INVHED.InvTot, T_INVHED.InvTotLocCur, T_INVHED.InvTyp, T_INVHED.InvWight_T, T_INVHED.IsExtrnalGaid, T_INVHED.LTim, T_INVHED.MndExtrnal, T_INVHED.MndNo, T_INVHED.MODIFIED_BY, T_INVHED.NetworkPay, T_INVHED.NetworkPayLocCur, T_INVHED.OrderTyp, T_INVHED.Puyaid, T_INVHED.RefNo, T_INVHED.Remark, T_INVHED.Remming, T_INVHED.RetId, T_INVHED.RetNo, T_INVHED.RoomNo, T_INVHED.RoomPerson, T_INVHED.RoomSts, T_INVHED.SalsManNam, T_INVHED.SalsManNo, T_INVHED.ServiceValue, T_INVHED.Sts, T_INVHED.ToStore, T_INVHED.ToStoreNm,case when T_INVHED.CusVenNo <> '' then (select " + ((LangArEn == 0) ? " T_AccDef.Arb_Des " : " T_AccDef.Eng_Des") + " from T_AccDef where T_AccDef.AccDef_No = T_INVHED.CusVenNo) else T_INVHED.CusVenNm end as CusVenNm  ";
                _RepShow.Rule = " where InvTyp = " + VarGeneral.InvTypRt + VarGeneral.itmDes + " and IfDel = 0 and IfRet = 0 order by InvHed_ID";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_InvSalEnter")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_INVHED ";
                _RepShow.Fields = " T_INVHED.ArbTaf, T_INVHED.CashPay, T_INVHED.CashPayLocCur, T_INVHED.chauffeurNo, T_INVHED.CommMnd_Inv, T_INVHED.CompanyID, T_INVHED.CREATED_BY, T_INVHED.CreditPay, T_INVHED.CreditPayLocCur, T_INVHED.CurTyp, T_INVHED.CustNet, T_INVHED.CustPri, T_INVHED.CustRep, T_INVHED.CusVenAdd, T_INVHED.CusVenNo, T_INVHED.CusVenTel, T_INVHED.DATE_CREATED, T_INVHED.DATE_MODIFIED, T_INVHED.EstDat, T_INVHED.ExtrnalCostGaidID, T_INVHED.GadeId, T_INVHED.GadeNo, T_INVHED.GDat, T_INVHED.HDat, T_INVHED.IfDel, T_INVHED.IfPrint, T_INVHED.IfRet, T_INVHED.IfTrans, T_INVHED.InvAddCost, T_INVHED.InvAddCostExtrnal, T_INVHED.InvAddCostExtrnalLoc, T_INVHED.InvAddCostLoc, T_INVHED.InvCash, T_INVHED.InvCashPay, T_INVHED.InvCashPayNm, T_INVHED.InvCost, T_INVHED.InvCstNo, T_INVHED.InvDisPrs, ((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints, T_INVHED.InvDisValLocCur, T_INVHED.InvHed_ID, T_INVHED.InvId, T_INVHED.InvNet, T_INVHED.InvNetLocCur, T_INVHED.InvNo, T_INVHED.InvQty, T_INVHED.InvTot, T_INVHED.InvTotLocCur, T_INVHED.InvTyp, T_INVHED.InvWight_T, T_INVHED.IsExtrnalGaid, T_INVHED.LTim, T_INVHED.MndExtrnal, T_INVHED.MndNo, T_INVHED.MODIFIED_BY, T_INVHED.NetworkPay, T_INVHED.NetworkPayLocCur, T_INVHED.OrderTyp, T_INVHED.Puyaid, T_INVHED.RefNo, T_INVHED.Remark, T_INVHED.Remming, T_INVHED.RetId, T_INVHED.RetNo, T_INVHED.RoomNo, T_INVHED.RoomPerson, T_INVHED.RoomSts, T_INVHED.SalsManNam, T_INVHED.SalsManNo, T_INVHED.ServiceValue, T_INVHED.Sts, T_INVHED.ToStore, T_INVHED.ToStoreNm,case when T_INVHED.CusVenNo <> '' then (select " + ((LangArEn == 0) ? " T_AccDef.Arb_Des " : " T_AccDef.Eng_Des") + " from T_AccDef where T_AccDef.AccDef_No = T_INVHED.CusVenNo) else T_INVHED.CusVenNm end as CusVenNm  ";
                _RepShow.Rule = " where T_INVHED.tailor20 = 0 and  InvTyp = " + ((VarGeneral.InvTypRt == 1001) ? 1 : VarGeneral.InvTypRt) + ((VarGeneral.InvTypRt == 17 || VarGeneral.InvTypRt == 1001) ? VarGeneral.itmDes : string.Empty) + " and IfDel = 0 and IfEnter = 0 order by InvHed_ID";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_InvSalEnter_Branch")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_INVHED ";
                _RepShow.Fields = " T_INVHED.ArbTaf, T_INVHED.CashPay, T_INVHED.CashPayLocCur, T_INVHED.chauffeurNo, T_INVHED.CommMnd_Inv, T_INVHED.CompanyID, T_INVHED.CREATED_BY, T_INVHED.CreditPay, T_INVHED.CreditPayLocCur, T_INVHED.CurTyp, T_INVHED.CustNet, T_INVHED.CustPri, T_INVHED.CustRep, T_INVHED.CusVenAdd, T_INVHED.CusVenNo, T_INVHED.CusVenTel, T_INVHED.DATE_CREATED, T_INVHED.DATE_MODIFIED, T_INVHED.EstDat, T_INVHED.ExtrnalCostGaidID, T_INVHED.GadeId, T_INVHED.GadeNo, T_INVHED.GDat, T_INVHED.HDat, T_INVHED.IfDel, T_INVHED.IfPrint, T_INVHED.IfRet, T_INVHED.IfTrans, T_INVHED.InvAddCost, T_INVHED.InvAddCostExtrnal, T_INVHED.InvAddCostExtrnalLoc, T_INVHED.InvAddCostLoc, T_INVHED.InvCash, T_INVHED.InvCashPay, T_INVHED.InvCashPayNm, T_INVHED.InvCost, T_INVHED.InvCstNo, T_INVHED.InvDisPrs, ((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints, T_INVHED.InvDisValLocCur, T_INVHED.InvHed_ID, T_INVHED.InvId, T_INVHED.InvNet, T_INVHED.InvNetLocCur, T_INVHED.InvNo, T_INVHED.InvQty, T_INVHED.InvTot, T_INVHED.InvTotLocCur, T_INVHED.InvTyp, T_INVHED.InvWight_T, T_INVHED.IsExtrnalGaid, T_INVHED.LTim, T_INVHED.MndExtrnal, T_INVHED.MndNo, T_INVHED.MODIFIED_BY, T_INVHED.NetworkPay, T_INVHED.NetworkPayLocCur, T_INVHED.OrderTyp, T_INVHED.Puyaid, T_INVHED.RefNo, T_INVHED.Remark, T_INVHED.Remming, T_INVHED.RetId, T_INVHED.RetNo, T_INVHED.RoomNo, T_INVHED.RoomPerson, T_INVHED.RoomSts, T_INVHED.SalsManNam, T_INVHED.SalsManNo, T_INVHED.ServiceValue, T_INVHED.Sts, T_INVHED.ToStore, T_INVHED.ToStoreNm,case when T_INVHED.CusVenNo <> '' then (select " + ((LangArEn == 0) ? " T_AccDef.Arb_Des " : " T_AccDef.Eng_Des") + " from T_AccDef where T_AccDef.AccDef_No = T_INVHED.CusVenNo) else T_INVHED.CusVenNm end as CusVenNm  ";
                _RepShow.Rule = " where T_INVHED.tailor20 <> 0 and T_INVHED.tailor20 <> '' and  InvTyp = " + ((VarGeneral.InvTypRt == 1001) ? 1 : VarGeneral.InvTypRt) + ((VarGeneral.InvTypRt == 17 || VarGeneral.InvTypRt == 1001) ? VarGeneral.itmDes : string.Empty) + " and IfDel = 0 and IfEnter = 0 order by InvHed_ID";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_InvSalReturnMain")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_INVHED ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " where (T_INVHED.InvTyp = " + VarGeneral.InvTypRt + ") and T_INVHED.IfDel = 0 and T_INVHED.IfRet = 0 and T_INVHED.PaymentOrderTyp = 0  order by T_INVHED.InvHed_ID";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_InvGaid")
            {
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Gaid")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_GDHEAD ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = "  where (T_GDHEAD.gdTyp = " + VarGeneral.InvTyp + ") and T_GDHEAD.gdLok = 0 order by T_GDHEAD.gdNo";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_GaidToLeave")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_GDHEAD ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = "  where (T_GDHEAD.gdTyp = " + VarGeneral.InvTyp + ") and T_GDHEAD.gdLok = 0 and T_GDHEAD.ChekNo = 'GuestLeave' order by T_GDHEAD.gdNo";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Gaid2")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_GDHEAD ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = "  where (T_GDHEAD.gdTyp = " + VarGeneral.InvTyp + ") and T_GDHEAD.gdLok = 0 and T_GDHEAD.salMonth != 'OpenGD' order by T_GDHEAD.gdNo";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Gaid3")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_GDHEAD ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = "  where (T_GDHEAD.gdTyp = " + VarGeneral.InvTyp + ") and T_GDHEAD.gdLok = 0 and T_GDHEAD.ChekNo = '" + VarGeneral.EmpGaidTyp + "' order by T_GDHEAD.gdNo";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_InvGrid")
            {
                try
                {
                    RepShow _RepShow = new RepShow();
                    _RepShow.Tables = " T_Items INNER JOIN  T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID  ";
                    _RepShow.Fields = " T_Items.Itm_No, T_Items.Arb_Des, T_Items.Eng_Des, T_Items.StartCost, T_Items.LastCost, T_Items.AvrageCost, T_CATEGORY.Arb_Des as Arb_Des_Cat , T_CATEGORY.Eng_Des as Eng_Des_Cat ";
                    _RepShow.Rule = " where (T_Items.ItmTyp != 1 and " + ((VarGeneral.InvTyp == 1) ? " T_Items.InvSaleStoped = 0 " : " 1 = 1 ") + " and " + ((VarGeneral.InvTyp == 2) ? " T_Items.InvPaymentStoped = 0 " : " 1 = 1 ") + " and " + ((VarGeneral.InvTyp == 3) ? " T_Items.InvSaleReturnStoped = 0 " : " 1 = 1 ") + " and " + ((VarGeneral.InvTyp == 4) ? " T_Items.InvPaymentReturnStoped = 0 " : " 1 = 1 ") + " and " + ((VarGeneral.InvTyp == 5) ? " T_Items.InvEnterStoped = 0 " : " 1 = 1 ") + " and " + ((VarGeneral.InvTyp == 6) ? " T_Items.InvOutStoped = 0 " : " 1 = 1 ") + " ) and T_Items.ItmTyp != " + VarGeneral.vItmTyp + " and (" + ((VarGeneral.InvTyp == 2) ? " T_Items.ItmTyp != 2 " : " 1 = 1 ") + ") and (" + ((VarGeneral.InvTyp == 4) ? " T_Items.ItmTyp != 2 " : " 1 = 1 ") + ") and (" + ((VarGeneral.InvTyp == 2) ? " T_Items.ItmTyp != 9 " : " 1 = 1 ") + ") and (" + ((VarGeneral.InvTyp == 14) ? " T_Items.ItmTyp != 2 " : " 1 = 1 ") + ") order by Itm_No";
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                    DataSetFill();
                    c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
                }
                catch
                {
                }
            }
            if (VarGeneral.SFrmTyp == "T_InvGrid_CardCelebration")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Items INNER JOIN  T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID  ";
                _RepShow.Fields = " T_Items.Itm_No, T_Items.Arb_Des, T_Items.Eng_Des, T_Items.StartCost, T_Items.LastCost, T_Items.AvrageCost, T_CATEGORY.Arb_Des as Arb_Des_Cat , T_CATEGORY.Eng_Des as Eng_Des_Cat ";
                _RepShow.Rule = " where (T_Items.ItmTyp != 1 and " + ((VarGeneral.InvTyp == 1) ? " T_Items.InvSaleStoped = 0 " : " 1 = 1 ") + " and " + ((VarGeneral.InvTyp == 2) ? " T_Items.InvPaymentStoped = 0 " : " 1 = 1 ") + " and " + ((VarGeneral.InvTyp == 3) ? " T_Items.InvSaleReturnStoped = 0 " : " 1 = 1 ") + " and " + ((VarGeneral.InvTyp == 4) ? " T_Items.InvPaymentReturnStoped = 0 " : " 1 = 1 ") + " and " + ((VarGeneral.InvTyp == 5) ? " T_Items.InvEnterStoped = 0 " : " 1 = 1 ") + " and " + ((VarGeneral.InvTyp == 6) ? " T_Items.InvOutStoped = 0 " : " 1 = 1 ") + " ) and T_Items.ItmTyp != " + VarGeneral.vItmTyp + " and (" + ((VarGeneral.InvTyp == 2) ? " T_Items.ItmTyp != 2 " : " 1 = 1 ") + ") and (" + ((VarGeneral.InvTyp == 4) ? " T_Items.ItmTyp != 2 " : " 1 = 1 ") + ") and (" + ((VarGeneral.InvTyp == 2) ? " T_Items.ItmTyp != 9 " : " 1 = 1 ") + ") and (" + ((VarGeneral.InvTyp == 14) ? " T_Items.ItmTyp != 2 " : " 1 = 1 ") + ") and T_Items.DefultVendor = " + VarGeneral.Celebration_Acc + " order by Itm_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Items_Sum")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = "  T_Items INNER JOIN  T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID ";
                _RepShow.Fields = " T_Items.*  , T_CATEGORY.Arb_Des as Arb_Des_Cat, T_CATEGORY.Eng_Des as Eng_Des_Cat";
                _RepShow.Rule = " where " + ((!string.IsNullOrEmpty(VarGeneral.itmDes)) ? (" (T_Items.Itm_No != '" + VarGeneral.itmDes + "'") : " (1 = 1 ") + " and T_Items.InvSaleStoped = 0) order by Itm_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_InvGridExtrnalReturn")
            {
                string vRul = string.Empty;
                if (VarGeneral.vItmTyp == 1)
                {
                    vRul = " and T_Items.InvSaleStoped = 0 ";
                }
                else if (VarGeneral.vItmTyp == 2)
                {
                    vRul = " and T_Items.InvPaymentStoped = 0 ";
                }
                else if (VarGeneral.vItmTyp == 3)
                {
                    vRul = " and T_Items.InvSaleReturnStoped = 0 ";
                }
                else if (VarGeneral.vItmTyp == 4)
                {
                    vRul = " and T_Items.InvPaymentReturnStoped = 0 ";
                }
                else if (VarGeneral.vItmTyp == 5)
                {
                    vRul = " and T_Items.InvEnterStoped = 0 ";
                }
                else if (VarGeneral.vItmTyp == 6)
                {
                    vRul = " and T_Items.InvOutStoped = 0 ";
                }
                T_Mndob c = db.StockMndobID(VarGeneral.vMnd);
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Items INNER JOIN\r\n                                     T_StoreMnd ON T_Items.Itm_No = T_StoreMnd.itmNo INNER JOIN\r\n                                     T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID ";
                _RepShow.Fields = " DISTINCT(T_Items.Itm_No),T_Items.Arb_Des, T_Items.Eng_Des, T_Items.StartCost, T_Items.AvrageCost, T_Items.LastCost,T_CATEGORY.Arb_Des as Arb_Des_Cat , T_CATEGORY.Eng_Des as Eng_Des_Cat  ";
                _RepShow.Rule = " WHERE  T_Items.ItmTyp <> " + VarGeneral.vItmTyp + " and T_StoreMnd.stkQty > 0 and " + ((c == null || c.Mnd_ID == 0) ? (" T_StoreMnd.CusVenNo = '" + VarGeneral.vMnd + "'") : (" T_StoreMnd.MndNo = " + VarGeneral.vMnd)) + vRul + " order by T_Items.Itm_No ";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_InvGridExtrnalReturnSal")
            {
                string vRul = string.Empty;
                if (VarGeneral.vItmTyp == 1)
                {
                    vRul = " and T_Items.InvSaleStoped = 0 ";
                }
                else if (VarGeneral.vItmTyp == 2)
                {
                    vRul = " and T_Items.InvPaymentStoped = 0 ";
                }
                else if (VarGeneral.vItmTyp == 3)
                {
                    vRul = " and T_Items.InvSaleReturnStoped = 0 ";
                }
                else if (VarGeneral.vItmTyp == 4)
                {
                    vRul = " and T_Items.InvPaymentReturnStoped = 0 ";
                }
                else if (VarGeneral.vItmTyp == 5)
                {
                    vRul = " and T_Items.InvEnterStoped = 0 ";
                }
                else if (VarGeneral.vItmTyp == 6)
                {
                    vRul = " and T_Items.InvOutStoped = 0 ";
                }
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = "  T_Items INNER JOIN\r\n                                      T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID INNER JOIN\r\n                                      T_StoreMnd ON T_Items.Itm_No = T_StoreMnd.itmNo INNER JOIN\r\n                                      T_INVDET ON T_Items.Itm_No = T_INVDET.ItmNo INNER JOIN\r\n                                      T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID ";
                _RepShow.Fields = "  DISTINCT(T_Items.Itm_No),T_Items.Arb_Des, T_Items.Eng_Des, T_Items.StartCost, T_Items.AvrageCost, T_Items.LastCost,T_CATEGORY.Arb_Des as Arb_Des_Cat , T_CATEGORY.Eng_Des as Eng_Des_Cat  ";
                _RepShow.Rule = " WHERE  T_Items.ItmTyp <> " + VarGeneral.vItmTyp + " and  T_INVHED.InvTyp = 1 and T_INVHED.IfDel = 0 and T_INVHED.PaymentOrderTyp > 0 and T_StoreMnd.MndNo = " + VarGeneral.vMnd + vRul + " order by T_Items.Itm_No ";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "InvSalPriceShow")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_INVHED ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " where (T_INVHED.InvTyp = 7) and T_INVHED.IfDel = 0 and T_INVHED.IfRet = 0 order by InvHed_ID";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "InvPriceShow")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_INVHED ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " where (T_INVHED.InvTyp = " + VarGeneral.AccTyp + ") and T_INVHED.IfDel = 0 and T_INVHED.IfRet = 0 order by InvHed_ID";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Dept")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Dept ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " order by T_Dept.Dept_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Section")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Section ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " order by T_Section.Section_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Project")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Project ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " order by T_Project.Project_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Contract")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Contract ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " order by T_Contract.Contract_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Job")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Job ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " order by T_Job.Job_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_treatment")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_treatment ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " order by T_treatment.treatment_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Insurance")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Insurance ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " order by T_Insurance.Insurance_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Religion")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Religion ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " order by T_Religion.Religion_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_City")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_City ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " order by T_City.City_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Bank")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Bank ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " order by T_Bank.Bank_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_VacTyp")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_VacTyp ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " order by T_VacTyp.VacT_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Nationality")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Nationalities ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " order by T_Nationalities.Nation_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Guarantor")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Guarantor ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " order by T_Guarantor.Guarantor_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Colors")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Colors ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " ";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_CarTyp")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_CarTyp ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " order by T_CarTyp.CarTyp_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_SecretariatsTyp")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_SecretariatsTyp ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " order by T_SecretariatsTyp.SecretariatTyp_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Car")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Cars ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " order by T_Cars.Car_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Boss")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = "T_Boss";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " order by T_Boss.Boss_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Emp" && VarGeneral.FrmEmpStat)
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Emp ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " where T_Emp.EmpState = 1 order by T_Emp.Emp_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_LiquidationTyp")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_LiquidationTyp ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " order by T_LiquidationTyp.LiquidationT_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Emp" && !VarGeneral.FrmEmpStat)
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Emp ";
                _RepShow.Fields = " T_Emp.Emp_No, T_Emp.NameA, T_Emp.NameE, T_Emp.DateAppointment, T_Emp.StartContr, T_Emp.EndContr, T_Emp.MainSal, T_Emp.ID_No, T_Emp.Passport_No, T_Emp.AddressA, T_Emp.Tel, T_Emp.Note ";
                _RepShow.Rule = " where T_Emp.EmpState = 0 order by Emp_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_SalDiscount")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_SalDiscount left JOIN  T_Emp ON T_SalDiscount.EmpID = T_Emp.Emp_ID ";
                _RepShow.Fields = ((LangArEn == 0) ? " T_Emp.NameA " : " T_Emp.NameE ") + " as EmpNm , T_Emp.Emp_No, T_SalDiscount.ACount, T_SalDiscount.Note, T_SalDiscount.warnNo, T_SalDiscount.warnDate  ,T_SalDiscount.SalDate,T_SalDiscount.SubValue ";
                _RepShow.Rule = " order by T_SalDiscount.warnNo";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Add")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Add left JOIN  T_Emp ON T_Add.EmpID = T_Emp.Emp_ID ";
                _RepShow.Fields = " T_Emp.Emp_No, " + ((LangArEn == 0) ? " T_Emp.NameA " : " T_Emp.NameE ") + " as EmpNm , T_Add.CountDay, T_Add.Note, T_Add.warnNo, T_Add.warnDate ,T_Add.SalDate,T_Add.AddValue ";
                _RepShow.Rule = " order by warnNo";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Commentary")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Commentary left JOIN  T_Emp ON T_Commentary.EmpID = T_Emp.Emp_ID ";
                _RepShow.Fields = " T_Emp.Emp_No, " + ((LangArEn == 0) ? " T_Emp.NameA " : " T_Emp.NameE ") + " as EmpNm , T_Commentary.Value, T_Commentary.Note, T_Commentary.warnNo, T_Commentary.warnDate ,T_Commentary.SalDate ";
                _RepShow.Rule = " order by warnNo";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_VisaGoBack")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_VisaGoBack left JOIN  T_Emp ON T_VisaGoBack.EmpID = T_Emp.Emp_ID ";
                _RepShow.Fields = ((LangArEn == 0) ? " T_Emp.NameA " : " T_Emp.NameE ") + " as EmpNm , T_Emp.Emp_No, T_VisaGoBack.VisaNo, T_VisaGoBack.Note, T_VisaGoBack.warnNo, T_VisaGoBack.warnDate ";
                _RepShow.Rule = " order by T_VisaGoBack.warnNo";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_VisaIntroduction")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_VisaIntroduction left JOIN  T_Emp ON T_VisaIntroduction.EmpID = T_Emp.Emp_ID ";
                _RepShow.Fields = ((LangArEn == 0) ? " T_Emp.NameA " : " T_Emp.NameE ") + " as EmpNm, T_Emp.Emp_No, T_VisaIntroduction.VisaNo, T_VisaIntroduction.Note, T_VisaIntroduction.warnNo, T_VisaIntroduction.warnDate  ";
                _RepShow.Rule = " order by T_VisaIntroduction.warnNo";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Secretariat")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Secretariats left JOIN  T_Emp ON T_Secretariats.EmpID = T_Emp.Emp_ID ";
                _RepShow.Fields = ((LangArEn == 0) ? " T_Emp.NameA " : " T_Emp.NameE ") + " as EmpNm, T_Emp.Emp_No, T_Secretariats.warnDate, T_Secretariats.Note, T_Secretariats.warnNo, T_Secretariats.StartDate, T_Secretariats.EndDate ";
                _RepShow.Rule = " order by T_Secretariats.warnNo";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Reward")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Rewards left JOIN  T_Emp ON T_Rewards.EmpID = T_Emp.Emp_ID ";
                _RepShow.Fields = " T_Rewards.Reward_No, " + ((LangArEn == 0) ? " T_Emp.NameA " : " T_Emp.NameE ") + " as EmpNm, T_Emp.Emp_No, T_Rewards.RewardValue, T_Rewards.Note, T_Rewards.RewardDate,T_Rewards.SalDate   ";
                _RepShow.Rule = " order by T_Rewards.Reward_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_CallPhone")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_CallPhone left JOIN  T_Emp ON T_CallPhone.EmpID = T_Emp.Emp_ID ";
                _RepShow.Fields = "  T_CallPhone.Phone_No, " + ((LangArEn == 0) ? " T_Emp.NameA " : " T_Emp.NameE ") + " as EmpNm , T_Emp.Emp_No, T_CallPhone.PhoneValue, T_CallPhone.Note, T_CallPhone.PhoneDate,T_CallPhone.SalDate  ";
                _RepShow.Rule = " order by T_CallPhone.Phone_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Authorization")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Authorization left JOIN  T_Emp ON T_Authorization.EmpID = T_Emp.Emp_ID ";
                _RepShow.Fields = " T_Authorization.Authorization_No, " + ((LangArEn == 0) ? " T_Emp.NameA " : " T_Emp.NameE ") + " as EmpNm, T_Emp.Emp_No, T_Authorization.Date, T_Authorization.Note,T_Authorization.ExitTime,T_Authorization.BackTime,T_Authorization.reason ";
                _RepShow.Rule = " order by T_Authorization.Authorization_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Vacation")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Vacation left JOIN  T_Emp ON T_Vacation.EmpID = T_Emp.Emp_ID ";
                _RepShow.Fields = " T_Vacation.warnNo, T_Vacation.warnDate, " + ((LangArEn == 0) ? " T_Emp.NameA " : " T_Emp.NameE ") + " as EmpNm, T_Emp.Emp_No, T_Vacation.Note ,T_Vacation.VacCountDay,T_Vacation.StartDate,T_Vacation.EndDate";
                _RepShow.Rule = " order by T_Vacation.warnNo";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Ticket")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Tickets left JOIN  T_Emp ON T_Tickets.EmpID = T_Emp.Emp_ID ";
                _RepShow.Fields = " T_Tickets.warnNo, T_Tickets.warnDate, " + ((LangArEn == 0) ? " T_Emp.NameA " : " T_Emp.NameE ") + " as EmpNm, T_Emp.Emp_No, T_Tickets.Note,T_Tickets.TicketValue,T_Tickets.TicketCount,T_Tickets.AllTicketValue,T_Tickets.GoLine ";
                _RepShow.Rule = " order by T_Tickets.warnNo";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Advance")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Advances left JOIN  T_Emp ON T_Advances.EmpID = T_Emp.Emp_ID ";
                _RepShow.Fields = " T_Advances.Advances_No," + ((LangArEn == 0) ? " T_Emp.NameA " : " T_Emp.NameE ") + " as EmpNm, T_Emp.Emp_No, T_Advances.ResolutionNo, T_Advances.ResolutionDate, T_Advances.Note ,T_Advances.ValueAdvances,T_Advances.TotalPremiums,T_Advances.SalDate";
                _RepShow.Rule = " order by T_Advances.Advances_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_EndService")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_EndService left JOIN  T_Emp ON T_EndService.EmpID = T_Emp.Emp_ID ";
                _RepShow.Fields = ((LangArEn == 0) ? " T_Emp.NameA " : " T_Emp.NameE ") + " as EmpNm, T_Emp.Emp_No, T_Emp.DateAppointment, T_Emp.StartContr, T_Emp.EndContr, T_EndService.DateFilter, T_EndService.Years, T_EndService.Months, T_EndService.Days, T_Emp.MainSal, T_EndService.Note, T_EndService.warnNo, T_EndService.warnDate  ";
                _RepShow.Rule = " order by T_EndService.warnNo";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "Months")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Salary ";
                _RepShow.Fields = " (Convert(varchar,T_Salary.SalYear) + '/' + Convert(varchar,T_Salary.SalMonth))  as Date ";
                _RepShow.Rule = " where T_Salary.SalaryStatus = 0 order by T_Salary.SalMonth, T_Salary.SalYear";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "Months2")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Sal ";
                _RepShow.Fields = " (Convert(varchar,T_Sal.SalYear) + '/' + Convert(varchar,T_Sal.SalMonth))  as Date ";
                _RepShow.Rule = " where T_Sal.SalaryStatus = 1 order by T_Sal.SalMonth, T_Sal.SalYear";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Rom")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Rom left JOIN  T_per ON T_Rom.perno = T_per.perno left JOIN  T_AccDef ON T_per.Cust_no = T_AccDef.AccDef_No ";
                _RepShow.Fields = " T_Rom.romno,T_AccDef.Arb_Des as nmA,T_AccDef.Eng_Des as nmE, case when T_Rom.state = 0 then '" + ((LangArEn == 0) ? "صيانة" : "Repair") + "' else case when T_Rom.state = 1 then '" + ((LangArEn == 0) ? "فارغة" : "Empty") + "' else case when T_Rom.state = 2 then '" + ((LangArEn == 0) ? "نظافة" : "Cleaning") + "' else '" + ((LangArEn == 0) ? "مشغولة" : "Bussy") + "' end end end  as state, T_Rom.flore, T_Rom.wcno, T_Rom.pri0, T_Rom.pri1, T_Rom.priM0, T_Rom.priM1, T_Rom.bedno, T_Rom.ShortDsc  ";
                _RepShow.Rule = " order by T_Rom.flore, T_Rom.romno";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_EqarTyp")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_EqarTyp ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " order by T_EqarTyp.EqarTyp_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_EqarNatural")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_EqarNatural ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " order by T_EqarNatural.EqarNatural_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_AinTyp")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_AinTyp ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " order by T_AinTyp.AinTyp_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_AinNatural")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_AinNatural ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " order by T_AinNatural.AinNatural_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Owner")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Owner ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " order by T_Owner.Owner_No";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_EqarsData")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_EqarsData ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " order by T_EqarsData.EqarNo";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_EqarsDataSale")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_EqarsData ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " where EqarStatus = 0 " + VarGeneral.EqarSaleWhere + " order by T_EqarsData.EqarNo";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_AinsData")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_AinsData INNER JOIN T_EqarsData ON T_AinsData.EqarID = T_EqarsData.EqarID ";
                _RepShow.Fields = " T_AinsData.AinNo, T_EqarsData.EqarNo, T_EqarsData.NameA, T_EqarsData.NameE  ";
                _RepShow.Rule = " order by T_AinsData.AinNo";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_AinsDataSale")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_AinsData INNER JOIN T_EqarsData ON T_AinsData.EqarID = T_EqarsData.EqarID ";
                _RepShow.Fields = " T_AinsData.AinNo, T_EqarsData.EqarNo, T_EqarsData.NameA, T_EqarsData.NameE  ";
                _RepShow.Rule = " where (T_AinsData.AinStatus = 0 " + VarGeneral.EqarSaleWhere + " order by T_AinsData.AinNo";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_EqarSale")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_AinsData INNER JOIN T_EqarsData ON T_AinsData.EqarID = T_EqarsData.EqarID INNER JOIN T_EqarSale ON T_AinsData.AinID = T_EqarSale.AinID AND T_EqarsData.EqarID = T_EqarSale.EqarID ";
                _RepShow.Fields = " T_EqarSale.EqarSaleNo, T_EqarsData.EqarNo, T_AinsData.AinNo, T_EqarsData.NameA, T_EqarsData.NameE  ";
                _RepShow.Rule = " order by T_EqarSale.EqarSaleNo";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_Tenant")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Tenant ";
                _RepShow.Fields = " *  ";
                _RepShow.Rule = " order by T_Tenant.tenantNo";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_AlarmTenant")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_AlarmTenant INNER JOIN T_Tenant ON T_AlarmTenant.tenant_ID = T_Tenant.tenantID  ";
                _RepShow.Fields = " T_AlarmTenant.AlarmTenantID , T_AlarmTenant.AlarmTenantNo  , T_AlarmTenant.AlarmSubject  , T_AlarmTenant.AlarmAdmin  , T_Tenant.NameA , T_Tenant.NameE   ";
                _RepShow.Rule = " order by T_Tenant.tenantNo";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (VarGeneral.SFrmTyp == "T_TenantContract")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_TenantContract left JOIN  T_Tenant ON T_TenantContract.tenant_ID = T_Tenant.tenantID  ";
                _RepShow.Fields = " T_TenantContract.ContractNo , T_TenantContract.ContractID  , T_Tenant.NameA  , T_Tenant.NameE ";
                _RepShow.Rule = " order by T_TenantContract.ContractID";
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                DataSetFill();
                c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            }
            if (tp != 0)
            {
                return;
            }
            GridRow row = new GridRow();
            for (int ii = 0; ii < c1TrueDBGrid1.Columns.Count; ii++)
            {
                bool contextMenuSet = false;
                if (contextMenuStrip1.Items.Count > 0)
                {
                    contextMenuSet = true;
                }
                row = new GridRow();
                row.Cells.Add(new GridCell(string.Empty));
                row.Cells.Add(new GridCell(string.Empty));
                row.Cells.Add(new GridCell(string.Empty));
                GridCheck.PrimaryGrid.Rows.Add(row);
                object value = (GridCheck.PrimaryGrid.GetCell(ii, 0).Value = false);
                Convert.ToBoolean(value);
                GridCheck.PrimaryGrid.GetCell(ii, 1).Value = ((LangArEn == 0) ? columns_Names_visible[c1TrueDBGrid1.Columns[ii].DataField].AText : columns_Names_visible[c1TrueDBGrid1.Columns[ii].DataField].EText);
                if (ii != 0)
                {
                    GridCheck.PrimaryGrid.GetCell(ii, 2).Value = c1TrueDBGrid1.Columns[ii].DataField;
                }
                else
                {
                    GridCheck.PrimaryGrid.GetCell(ii, 2).Value = string.Empty;
                    GridCheck.PrimaryGrid.Rows[ii].Visible = false;
                }
                for (int i = 0; i < c1TrueDBGrid1.Columns.Count; i++)
                {
                    if (columns_Names_visible.ContainsKey(c1TrueDBGrid1.Columns[i].DataField))
                    {
                        c1TrueDBGrid1.Splits[0].DisplayColumns[i].Width = 50;
                        c1TrueDBGrid1.Splits[0].DisplayColumns[i].Visible = columns_Names_visible[c1TrueDBGrid1.Columns[i].DataField].IfDefault;
                        c1TrueDBGrid1.Columns[i].Caption = ((LangArEn == 0) ? columns_Names_visible[c1TrueDBGrid1.Columns[i].DataField].AText : columns_Names_visible[c1TrueDBGrid1.Columns[i].DataField].EText);
                        if (!contextMenuSet)
                        {
                            ToolStripMenuItem item = new ToolStripMenuItem();
                            if (i == 0 || i == 1)
                            {
                                item.Checked = true;
                            }
                            else
                            {
                                item.Checked = false;
                            }
                            item.CheckOnClick = true;
                            item.Name = c1TrueDBGrid1.Columns[i].DataField;
                            item.Text = c1TrueDBGrid1.Columns[i].Caption;
                            item.CheckedChanged += item_Click;
                            contextMenuStrip1.Items.Add(item);
                        }
                        else
                        {
                            c1TrueDBGrid1.Splits[0].DisplayColumns[i].Visible = (contextMenuStrip1.Items[c1TrueDBGrid1.Columns[i].DataField] as ToolStripMenuItem).Checked;
                        }
                    }
                    else
                    {
                        c1TrueDBGrid1.Splits[0].DisplayColumns[i].Visible = false;
                    }
                }
            }
            for (int i = 0; i < c1TrueDBGrid1.Columns.Count; i++)
            {
                if (i == 0)
                {
                    c1TrueDBGrid1.Splits[0].DisplayColumns[i].Width = 90;
                }
                else
                {
                    c1TrueDBGrid1.Splits[0].DisplayColumns[i].Width = 250;
                }
                c1TrueDBGrid1.Splits[0].DisplayColumns[i].AllowSizing = false;
            }
            try
            {
                object value = (GridCheck.PrimaryGrid.GetCell(1, 0).Value = true);
                Convert.ToBoolean(value);
            }
            catch
            {
            }
        }
        private void c1TrueDBGrid1_RowColChange(object sender, RowColChangeEventArgs e)
        {
        }
        private void ShowGrid_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            ReorderColumns();
        }
        private void ReorderColumns()
        {
            if (!ifAutoOrderColumn)
            {
                return;
            }
            int i = 0;
            foreach (string item in columns_Names_visible.Keys)
            {
                try
                {
                }
                catch
                {
                }
                i++;
            }
        }
        private void item_Click(object sender, EventArgs e)
        {
            if (MainCol == c1TrueDBGrid1.Columns[0].DataField || MainCol == "AccDef_ID" || MainCol == "AccDefID_Setting" || MainCol == "T_AccDef2" || MainCol == "T_AccDef_Suppliers" || MainCol == "T_AccDef3" || MainCol == "AccDefID_Customer" || MainCol == "T_AccDef_CustomerStoped" || MainCol == "AccDefID_Banks" || MainCol == "T_AccDef_Banks" || MainCol == "Acc_BankBr" || MainCol == "AccDefID_Boxes")
            {
                return;
            }
            string name = (sender as ToolStripMenuItem).Name;
            try
            {
                string NameExsist = c1TrueDBGrid1.Columns[name].DataField;
            }
            catch
            {
                C1DataColumn t = new C1DataColumn();
                t.DataField = name;
                c1TrueDBGrid1.Columns.Add(t);
                c1TrueDBGrid1.Splits[0].DisplayColumns[name].Width = 90;
                c1TrueDBGrid1.Columns[name].Caption = ((LangArEn == 0) ? columns_Names_visible[name].AText : columns_Names_visible[name].EText);
            }
            for (int ii = 1; ii < contextMenuStrip1.Items.Count; ii++)
            {
                if (contextMenuStrip1.Items[ii].Name == MainCol)
                {
                    (contextMenuStrip1.Items[ii] as ToolStripMenuItem).Checked = true;
                }
                else
                {
                    (contextMenuStrip1.Items[ii] as ToolStripMenuItem).Checked = false;
                }
            }
            for (int i = 0; i < c1TrueDBGrid1.Columns.Count; i++)
            {
                c1TrueDBGrid1.Splits[0].DisplayColumns[i].Visible = false;
            }
            c1TrueDBGrid1.Splits[0].DisplayColumns[0].Visible = true;
            c1TrueDBGrid1.Splits[0].DisplayColumns[name].Visible = true;
            c1TrueDBGrid1.Splits[0].DisplayColumns[name].Visible = (sender as ToolStripMenuItem).Checked;
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                groupBox1.Text = string.Empty;
                groupBox2.Text = "رتب البيانات حسب :";
                radioButton1.Text = "بحث محتوى";
                radioButton2.Text = "بحث مطابق";
                buttonX_Ok.Text = "موافق";
                buttonX_Clear.Text = "مســـح";
                buttonX_Close.Text = "إغـــلاق";
                buttonX_Additem.Text = "إضافة الصنف";
                Text = "شاشة البحث";
            }
            else
            {
                groupBox1.Text = string.Empty;
                groupBox2.Text = "Sort Data By :";
                radioButton1.Text = "Contains";
                radioButton2.Text = "Identical";
                buttonX_Ok.Text = "OK";
                buttonX_Clear.Text = "Clear";
                buttonX_Close.Text = "Close";
                buttonX_Additem.Text = "Add Item";
                Text = "Search Form";
            }
        }
        int getindex(DataTable t, int uid)
        {
            int id = -1;
            for (int i = 0; i < t.Rows.Count; i++)
            {
            }
            return id;
        }
        private void DataSetFill()
        {
            try
            {
                dataSet1 = VarGeneral.RepData;
                DataTable ts = dataSet1.Tables[0].Clone();
                if (VarGeneral.SFrmTyp == "T_Units")
                {
                }
                int columnIndex = 0;
                foreach (string columnName in columns_Names_visible.Keys)
                {
                    dataSet1.Tables[0].Columns[columnName].SetOrdinal(columnIndex);
                    columnIndex++;
                }
                while (dataSet1.Tables[0].Columns.Count > columns_Names_visible.Keys.Count)
                {
                    dataSet1.Tables[0].Columns.RemoveAt(columns_Names_visible.Keys.Count);
                }
            }
            catch
            {
                dataSet1 = new DataSet();
            }
        }
        private void FrmSearch_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmSearch));
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
                SeachTyp(0);
                try
                {
                    if (VarGeneral.SFrmTyp == "T_InvGrid")
                    {
                        buttonX_Additem.Visible = true;
                    }
                    else
                    {
                        buttonX_Additem.Visible = false;
                    }
                }
                catch
                {
                    buttonX_Additem.Visible = false;
                }
                try
                {
                    if (VarGeneral.SFrmTyp == "T_SearchNumber" || VarGeneral.SFrmTyp == "T_SearchNumberEmp")
                    {
                        c1TrueDBGrid1.Splits[0].DisplayColumns[0].Width = c1TrueDBGrid1.Splits[0].DisplayColumns[0].Width + 25;
                    }
                }
                catch
                {
                }
                if (VarGeneral.gUserName == "runsetting")
                {
                    SendKeys.Send("%{TAB}");
                }
                if (VarGeneral.SFrmTyp == "T_Draft")
                {
                    button1.Visible = true;
                    GridCheck_CellClick(null, new GridCellClickEventArgs(null, GridCheck.GetCell(11, 0), null));
                }
                else
                    button1.Visible = false;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        int cell = 12;
        private void buttonX2_Click(object sender, EventArgs e)
        {
            foreach (GridColumn column in c1TrueDBGrid1.Columns)
            {
                column.FilterExpr = null;
            }
        }
        private void buttonX3_Click(object sender, EventArgs e)
        {
            SerachNo = string.Empty;
            Close();
        }
        private void FrmSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                SerachNo = string.Empty;
                Close();
            }
        }
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                MainCol = e.ClickedItem.Name;
                if (!(MainCol == c1TrueDBGrid1.Columns[0].DataField) && !(MainCol == "AccDef_ID") && !(MainCol == "AccDefID_Setting") && !(MainCol == "T_AccDef2") && !(MainCol == "T_AccDef_Suppliers") && !(MainCol == "T_AccDef3") && !(MainCol == "AccDefID_Customer") && !(MainCol == "T_AccDef_CustomerStoped") && !(MainCol == "AccDefID_Banks") && !(MainCol == "T_AccDef_Banks") && !(MainCol == "Acc_BankBr") && !(MainCol == "AccDefID_Boxes"))
                {
                }
            }
            catch
            {
            }
        }
        private void buttonX_Ok_Click(object sender, EventArgs e)
        {
            c1TrueDBGrid1_DoubleClick(sender, e);
        }
        private void GridCheck_CellClick(object sender, GridCellClickEventArgs e)
        {
            try
            {
                int row = 0;//= e.GridCell.RowIndex;
                int col = 0;
                row = e.GridCell.RowIndex;
                col = e.GridCell.ColumnIndex;
                if (col != 0)
                {
                    return;
                }
                object value;
                for (int i = 0; i < GridCheck.PrimaryGrid.Rows.Count; i++)
                {
                    value = (GridCheck.PrimaryGrid.GetCell(i, 0).Value = false);
                    Convert.ToBoolean(value);
                    if (i != 0)
                    {
                        c1TrueDBGrid1.Splits[0].DisplayColumns[i].Visible = false;
                    }
                }
                value = (GridCheck.PrimaryGrid.GetCell(row, col).Value = true);
                Convert.ToBoolean(value);
                c1TrueDBGrid1.Splits[0].DisplayColumns[GridCheck.PrimaryGrid.GetCell(row, 2).Value.ToString()].Visible = true;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("GridCheck_CellClick:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void FrmSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            VarGeneral.ItmDes = string.Empty;
            VarGeneral.ItmDesIndex = 0;
        }
        private void buttonX_Additem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmItems frm = new FrmItems();
                frm.buttonItem_Serials.Visible = false;
                frm.Tag = LangArEn;
                GridCheck.PrimaryGrid.Rows.Clear();
                frm.TopMost = true;
                frm.ShowDialog();
                SeachTyp(0);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("buttonX_Additem_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void c1TrueDBGrid1_FilterChange(object sender, EventArgs e)
        {
            try
            {
                int int_col = 0;
                string str = null;
                StringBuilder sb = new StringBuilder();
                int multi = 0;
                foreach (C1DataColumn dc in c1TrueDBGrid1.Columns)
                {
                    if (dc.FilterText.Length <= 0)
                    {
                        continue;
                    }
                    if (sb.Length > 0)
                    {
                        sb.Append(" AND ");
                    }
                    string[] words;
                    string[] array;
                    if (flag == 1)
                    {
                        if (dc.FilterText.Contains(dc.FilterSeparator))
                        {
                            words = dc.FilterText.ToString().Split(dc.FilterSeparator);
                            array = words;
                            foreach (string word in array)
                            {
                                sb.Append(dc.DataField + " = '" + word + "'");
                                sb.Append(" OR ");
                            }
                            multi = 1;
                        }
                        else
                        {
                            sb.Append(dc.DataField + " = '" + dc.FilterText + "'");
                        }
                        continue;
                    }
                    if (dc.DataType.Name.ToUpper() == "STRING".ToUpper())
                    {
                        if (dc.FilterText.Contains(dc.FilterSeparator))
                        {
                            words = dc.FilterText.ToString().Split(dc.FilterSeparator);
                            array = words;
                            foreach (string word in array)
                            {
                                sb.Append(dc.DataField + " = '" + word + "'");
                                sb.Append(" OR ");
                            }
                            multi = 1;
                        }
                        else if (radioButton1.Checked)
                        {
                            sb.Append(dc.DataField + " like '*" + dc.FilterText + "*'");
                        }
                        else
                        {
                            sb.Append(dc.DataField + " like '" + dc.FilterText + "*'");
                        }
                        continue;
                    }
                    int_col = 1;
                    words = dc.FilterText.ToString().Split(dc.FilterSeparator);
                    sb.Append(dc.DataField + " IN (");
                    array = words;
                    foreach (string word in array)
                    {
                        if (word != null)
                        {
                            sb.Append(word + ",");
                        }
                    }
                    str = sb.ToString().Remove(sb.ToString().Length - 1);
                    str += ")";
                }
                try
                {
                    sb.Replace("[", "[[]").Replace("%", "[%]");
                }
                catch (Exception error2)
                {
                    VarGeneral.DebLog.writeLog("[ :", error2, enable: true);
                }
                if (multi == 1)
                {
                    dataSet1.Tables[0].DefaultView.RowFilter = sb.ToString().Remove(sb.Length - 3).ToString();
                }
                else if (int_col == 1)
                {
                    dataSet1.Tables[0].DefaultView.RowFilter = str;
                }
                else
                {
                    dataSet1.Tables[0].DefaultView.RowFilter = sb.ToString();
                }
                flag = 0;
            }
            catch (Exception error2)
            {
                VarGeneral.DebLog.writeLog("c1TrueDBGrid1_FilterChange:", error2, enable: true);
            }
        }
        private void c1TrueDBGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode != Keys.Return)
                {
                    return;
                }
                int Index;
                try
                {
                    Index = Row;
                    if (VarGeneral.SFrmTyp == "T_AccDef" || VarGeneral.SFrmTyp == "AccDefID_Setting" || VarGeneral.SFrmTyp == "T_AccDef2" || VarGeneral.SFrmTyp == "T_AccDef_Suppliers" || VarGeneral.SFrmTyp == "T_AccDef3" || VarGeneral.SFrmTyp == "AccDefID_Customer" || VarGeneral.SFrmTyp == "T_AccDef_CustomerStoped" || VarGeneral.SFrmTyp == "AccDefID_Banks" || VarGeneral.SFrmTyp == "T_AccDef_Banks" || VarGeneral.SFrmTyp == "Acc_BankBr" || VarGeneral.SFrmTyp == "AccDefID_Boxes" || VarGeneral.SFrmTyp == "T_TenantContract")
                    {
                        SerachNo = c1TrueDBGrid1.Columns[3].CellValue(c1TrueDBGrid1.Row).ToString();
                    }
                    else if (VarGeneral.SFrmTyp == "T_InvGaid")
                    {
                        SerachNo = c1TrueDBGrid1.Columns[5].CellValue(c1TrueDBGrid1.Row).ToString();
                    }
                    else if (smsf == 1)
                    {
                        SerachNo = c1TrueDBGrid1.Columns[2].CellValue(c1TrueDBGrid1.Row).ToString();
                    }
                    else
                    {
                        SerachNo = c1TrueDBGrid1.Columns[0].CellValue(c1TrueDBGrid1.Row).ToString();
                    }
                }
                catch
                {
                }
                if (!string.IsNullOrEmpty(SerachNo))
                {
                    Close();
                    return;
                }
                Index = Row;
                if (VarGeneral.SFrmTyp == "T_AccDef" || VarGeneral.SFrmTyp == "AccDefID_Setting" || VarGeneral.SFrmTyp == "T_AccDef2" || VarGeneral.SFrmTyp == "T_AccDef_Suppliers" || VarGeneral.SFrmTyp == "T_AccDef3" || VarGeneral.SFrmTyp == "AccDefID_Customer" || VarGeneral.SFrmTyp == "T_AccDef_CustomerStoped" || VarGeneral.SFrmTyp == "AccDefID_Banks" || VarGeneral.SFrmTyp == "T_AccDef_Banks" || VarGeneral.SFrmTyp == "Acc_BankBr" || VarGeneral.SFrmTyp == "AccDefID_Boxes" || VarGeneral.SFrmTyp == "T_TenantContract")
                {
                    SerachNo = c1TrueDBGrid1.Columns[3].CellValue(c1TrueDBGrid1.Row).ToString();
                }
                else if (VarGeneral.SFrmTyp == "T_InvGaid")
                {
                    SerachNo = c1TrueDBGrid1.Columns[5].CellValue(c1TrueDBGrid1.Row).ToString();
                }
                else
                {
                    SerachNo = c1TrueDBGrid1.Columns[0].CellValue(c1TrueDBGrid1.Row).ToString();
                }
                Close();
            }
            catch
            {
                SerachNo = string.Empty;
            }
        }
        int closeform = 0;
        private void c1TrueDBGrid1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                base.ActiveControl = c1TrueDBGrid1;
                if (Row < 0)
                {
                    Row = 0;
                }
                if (VarGeneral.SFrmTyp == "T_AccDef" || VarGeneral.SFrmTyp == "AccDefID_Setting" || VarGeneral.SFrmTyp == "T_AccDef2" || VarGeneral.SFrmTyp == "T_AccDef_Suppliers" || VarGeneral.SFrmTyp == "T_AccDef3" || VarGeneral.SFrmTyp == "AccDefID_Customer" || VarGeneral.SFrmTyp == "T_AccDef_CustomerStoped" || VarGeneral.SFrmTyp == "AccDefID_Banks" || VarGeneral.SFrmTyp == "T_AccDef_Banks" || VarGeneral.SFrmTyp == "Acc_BankBr" || VarGeneral.SFrmTyp == "AccDefID_Boxes" || VarGeneral.SFrmTyp == "T_TenantContract")
                {
                    SerachNo = c1TrueDBGrid1.Columns[3].CellValue(c1TrueDBGrid1.Row).ToString();
                }
                else if (VarGeneral.SFrmTyp == "T_InvGaid")
                {
                    SerachNo = c1TrueDBGrid1.Columns[5].CellValue(c1TrueDBGrid1.Row).ToString();
                }
                else if (VarGeneral.SFrmTyp == "T_Draft")
                {
                    SerachNo = c1TrueDBGrid1.Columns[10].CellValue(c1TrueDBGrid1.Row).ToString();
                }
                else
                    SerachNo = c1TrueDBGrid1.Columns[0].CellValue(c1TrueDBGrid1.Row).ToString();
                if (closeform == 0) Close();
            }
            catch
            {
                SerachNo = string.Empty;
                if (closeform == 0) Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (VarGeneral.SFrmTyp == "T_Draft")
            {
                if (c1TrueDBGrid1.RowCount != 0)
                {
                    closeform = 1;
                    c1TrueDBGrid1_DoubleClick(null, null);
                    closeform = 0;
                    string dl = "DELETE FROM T_INVDET WHERE InvId=" + SerachNo + " AND CInvType=" + VarGeneral.DraftBillId.ToString();
                    DBUdate.DbUpdates.executes(dl, VarGeneral.BranchCS);
                    dl = "Delete From T_INVHED where InvTyp=" + VarGeneral.DraftBillId.ToString() + " AND InvHed_ID=" + SerachNo + " and SalsManNo = " + VarGeneral.UserNo;
                    DBUdate.DbUpdates.executes(dl, VarGeneral.BranchCS);
                    SerachNo = string.Empty;
                    GridCheck.PrimaryGrid.Rows.Clear();
                    FrmSearch_Load(null, null);
                }
            }
        }
        private void c1TrueDBGrid1_Click(object sender, EventArgs e)
        {
        }

        private void GridCheck_Click(object sender, EventArgs e)
        {

        }
    }
}
