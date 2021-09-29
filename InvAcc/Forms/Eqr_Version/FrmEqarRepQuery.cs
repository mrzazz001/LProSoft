using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Framework.UI;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Library.RepShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmEqarRepQuery : Form
    { void avs(int arln)

{ 
}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
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
       // private IContainer components = null;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData.ToString().Contains("Control") && !keyData.ToString().ToLower().Contains("delete") && keyData.ToString().Contains("Alt"))
            {
                try
                {
                    VarGeneral.Print_set_Gen_Stat = true;
                    FrmReportsViewer.IsSettingOnly = true;
                    VarGeneral.IsGeneralUsed = true;
                    {
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "ItemsData";
                        frm.Repvalue = "ItemsData";
                        //ADDADD
                        frm.Tag = LangArEn;
                        frm.ShowDialog();
                        VarGeneral.IsGeneralUsed = false;
                    }
                    FrmReportsViewer.IsSettingOnly = false;
                }
                catch
                {
                    VarGeneral.Print_set_Gen_Stat = false;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private RibbonBar ribbonBar1;
        private Panel panel1;
        private Label label10;
        private ComboBoxEx CmbEqarStat;
        private Label label5;
        private TextBox txtOwnerName;
        private TextBox txtEqarName;
        private TextBox txtEqarNo;
        private TextBox txtOwnerNo;
        private Label label6;
        private ButtonX button_SrchOwner;
        private ButtonX button_SrchEqarNo;
        private C1FlexGrid FlexHead;
        private Label label1;
        private ComboBoxEx CmbEqarTyp;
        private Label label3;
        private ComboBoxEx CmbCity;
        private Label label2;
        private ComboBoxEx CmbEqarNature;
        private Label label4;
        private ComboBoxEx CmbEyeNature;
        private ComboBoxEx CmbEyeTyp;
        private Label label7;
        private ComboBoxEx CmbEyeStatus;
        private Label label8;
        private ButtonX ButQuery;
        private ButtonX ButExit;
        private ButtonX ButOk;
        private C1FlexGrid FlexFooter;
        private int LangArEn = 0;
        private T_User _User = new T_User();
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private bool EqarEye = false;
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
        public FrmEqarRepQuery()
        {
            InitializeComponent();this.Load += langloads;
            _User = dbc.StockUser(VarGeneral.UserNumber);
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ButExit.Text = "خــــروج Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "طبـــاعة F5" : "عــــرض F5");
                ButQuery.Text = "إستعلام";
                Text = "بيانات الأصناف";
                FlexHead.Cols[0].Caption = "رقم العقار";
                FlexHead.Cols[1].Caption = "إسم العقار";
                FlexHead.Cols[2].Caption = "المالك";
                FlexHead.Cols[3].Caption = "المدينة";
                FlexHead.Cols[4].Caption = "نوع العقار";
                FlexHead.Cols[5].Caption = "طبيعة العقار";
                FlexHead.Cols[6].Caption = "حالة العقار";
                FlexHead.Cols[7].Caption = "قيمة العقار";
                FlexHead.Cols[8].Caption = "قيمة إيجار العقار";
                FlexFooter.Cols[0].Caption = "رقم العقار";
                FlexFooter.Cols[1].Caption = "إسم العين";
                FlexFooter.Cols[2].Caption = "نوع العين";
                FlexFooter.Cols[3].Caption = "حالة العين";
                FlexFooter.Cols[4].Caption = "طبيعة العين";
                FlexFooter.Cols[5].Caption = "رقم المستأجر";
                FlexFooter.Cols[6].Caption = "إسم المستأجر";
                FlexFooter.Cols[7].Caption = "رقم العقد";
                FlexFooter.Cols[8].Caption = "تاريخ بداية العقد";
                FlexFooter.Cols[9].Caption = "تاريخ نهاية العقد";
            }
            else
            {
                ButExit.Text = "Exit Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "Print F5" : "Show F5");
                ButQuery.Text = "Enquiry";
                Text = "بيانات الأصناف";
                FlexHead.Cols[0].Caption = "Property No";
                FlexHead.Cols[1].Caption = "Property Name";
                FlexHead.Cols[2].Caption = "Owner";
                FlexHead.Cols[3].Caption = "City";
                FlexHead.Cols[4].Caption = "Property Type";
                FlexHead.Cols[5].Caption = "Property Nature";
                FlexHead.Cols[6].Caption = "Property Status";
                FlexHead.Cols[7].Caption = "value property";
                FlexHead.Cols[8].Caption = "Rent the property";
                FlexFooter.Cols[0].Caption = "Property No";
                FlexFooter.Cols[1].Caption = "Eye No";
                FlexFooter.Cols[2].Caption = "Eye Type";
                FlexFooter.Cols[3].Caption = "Eye Status";
                FlexFooter.Cols[4].Caption = "Eye Nature";
                FlexFooter.Cols[5].Caption = "Tenant No";
                FlexFooter.Cols[6].Caption = "Tenant Name";
                FlexFooter.Cols[7].Caption = "Contract No";
                FlexFooter.Cols[8].Caption = "Contract Starting Date";
                FlexFooter.Cols[9].Caption = "End date of the contract";
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmEqarRepQuery));
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
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmEqarRepQuery));
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
        private string BuildRuleList()
        {
            string Rule = "Where 1 = 1 ";
            if (!string.IsNullOrEmpty(txtEqarNo.Text) && !string.IsNullOrEmpty(txtEqarNo.Tag.ToString()))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtEqarNo.Tag, " = '", txtEqarNo.Tag.ToString().Trim(), "'");
            }
            if (!string.IsNullOrEmpty(txtOwnerNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtOwnerNo.Tag, " = '", txtOwnerNo.Text.Trim(), "'");
            }
            if (CmbEqarTyp.SelectedIndex > 0)
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", CmbEqarTyp.Tag, " = ", CmbEqarTyp.SelectedValue);
            }
            if (CmbEqarNature.SelectedIndex > 0)
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", CmbEqarNature.Tag, " = ", CmbEqarNature.SelectedValue);
            }
            if (CmbEqarStat.SelectedIndex > 0)
            {
                int x = CmbEqarStat.SelectedIndex - 1;
                object obj = Rule;
                Rule = string.Concat(obj, " and ", CmbEqarStat.Tag, " = ", CmbEqarStat.SelectedIndex - 1);
            }
            if (CmbCity.SelectedIndex > 0)
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", CmbCity.Tag, " = ", CmbCity.SelectedValue);
            }
            if (EqarEye)
            {
                if (CmbEyeTyp.SelectedIndex > 0)
                {
                    object obj = Rule;
                    Rule = string.Concat(obj, " and ", CmbEyeTyp.Tag, " = ", CmbEyeTyp.SelectedValue);
                }
                if (CmbEyeNature.SelectedIndex > 0)
                {
                    object obj = Rule;
                    Rule = string.Concat(obj, " and ", CmbEyeNature.Tag, " = ", CmbEyeNature.SelectedValue);
                }
                if (CmbEyeStatus.SelectedIndex > 0)
                {
                    object obj = Rule;
                    Rule = string.Concat(obj, " and ", CmbEyeStatus.Tag, " = ", CmbEyeStatus.SelectedIndex - 1);
                }
            }
            return Rule;
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            ProcessQuery(1);
        }
        private void ButExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Frm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 && ButOk.Enabled && ButOk.Visible)
            {
                ButOk_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void FrmEqarRepQuery_Load(object sender, EventArgs e)
        {
        }
        private void FillCombo()
        {
            List<T_City> listCity = new List<T_City>(db.T_Cities.Select((T_City item) => item).ToList());
            listCity.Insert(0, new T_City());
            listCity[0].NameA = "     ";
            listCity[0].NameE = "     ";
            CmbCity.DataSource = listCity;
            CmbCity.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            CmbCity.ValueMember = "City_No";
            CmbCity.SelectedIndex = 0;
            List<T_EqarTyp> listEqarTyp = new List<T_EqarTyp>(db.T_EqarTyps.Select((T_EqarTyp item) => item).ToList());
            listEqarTyp.Insert(0, new T_EqarTyp());
            listEqarTyp[0].NameA = "     ";
            listEqarTyp[0].NameE = "     ";
            CmbEqarTyp.DataSource = listEqarTyp;
            CmbEqarTyp.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            CmbEqarTyp.ValueMember = "EqarTyp_No";
            CmbEqarTyp.SelectedIndex = 0;
            List<T_EqarNatural> listEqarNature = new List<T_EqarNatural>(db.T_EqarNaturals.Select((T_EqarNatural item) => item).ToList());
            listEqarNature.Insert(0, new T_EqarNatural());
            listEqarNature[0].NameA = "     ";
            listEqarNature[0].NameE = "     ";
            CmbEqarNature.DataSource = listEqarNature;
            CmbEqarNature.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            CmbEqarNature.ValueMember = "EqarNatural_No";
            CmbEqarNature.SelectedIndex = 0;
            CmbEqarStat.Items.Add("     ");
            CmbEqarStat.Items.Add((LangArEn == 0) ? "فارغة" : "Empty");
            CmbEqarStat.Items.Add((LangArEn == 0) ? "مؤجرة" : "Leased");
            CmbEqarStat.Items.Add((LangArEn == 0) ? "مباعة" : "Sold");
            CmbEqarStat.SelectedIndex = 0;
            List<T_AinTyp> listEyeTyp = new List<T_AinTyp>(db.T_AinTyps.Select((T_AinTyp item) => item).ToList());
            listEyeTyp.Insert(0, new T_AinTyp());
            listEyeTyp[0].NameA = "     ";
            listEyeTyp[0].NameE = "     ";
            CmbEyeTyp.DataSource = listEyeTyp;
            CmbEyeTyp.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            CmbEyeTyp.ValueMember = "AinTyp_No";
            CmbEyeTyp.SelectedIndex = 0;
            List<T_AinNatural> listEyeNature = new List<T_AinNatural>(db.T_AinNaturals.Select((T_AinNatural item) => item).ToList());
            listEyeNature.Insert(0, new T_AinNatural());
            listEyeNature[0].NameA = "     ";
            listEyeNature[0].NameE = "     ";
            CmbEyeNature.DataSource = listEyeNature;
            CmbEyeNature.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            CmbEyeNature.ValueMember = "AinNatural_No";
            CmbEyeNature.SelectedIndex = 0;
            CmbEyeStatus.Items.Add("     ");
            CmbEyeStatus.Items.Add((LangArEn == 0) ? "فارغة" : "Empty");
            CmbEyeStatus.Items.Add((LangArEn == 0) ? "مؤجرة" : "Leased");
            CmbEyeStatus.Items.Add((LangArEn == 0) ? "مباعة" : "Sold");
            CmbEyeStatus.SelectedIndex = 0;
        }
        private void button_SrchEqarNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("EqarNo", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
            columns_Names_visible.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            columns_Names_visible.Add("ContractValue", new ColumnDictinary("قيمة العقار", "Property value", ifDefault: true, ""));
            columns_Names_visible.Add("ContractRentValue", new ColumnDictinary("إيجار العقار", "Rent the property", ifDefault: false, ""));
            columns_Names_visible.Add("FloorsCount", new ColumnDictinary("عدد الطوابق", "Floors Count", ifDefault: false, ""));
            columns_Names_visible.Add("EyesCount", new ColumnDictinary("عدد العيون", "Eyes Count", ifDefault: false, ""));
            columns_Names_visible.Add("Space", new ColumnDictinary("مساحة العقار", "Space", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_EqarsData";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != "")
                {
                    T_EqarsData _Eqar = db.EqarsDataEmp(int.Parse(frm.Serach_No));
                    txtEqarNo.Text = frm.Serach_No;
                    txtEqarNo.Tag = _Eqar.EqarID;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtEqarName.Text = _Eqar.NameA;
                    }
                    else
                    {
                        txtEqarName.Text = _Eqar.NameE;
                    }
                }
                else
                {
                    txtEqarNo.Text = "";
                    txtEqarName.Text = "";
                    txtEqarNo.Tag = "";
                }
            }
            catch
            {
                txtEqarNo.Text = "";
                txtEqarName.Text = "";
                txtEqarNo.Tag = "";
            }
        }
        private void button_SrchOwner_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("Owner_No", new ColumnDictinary("الرقـــــم", "No", ifDefault: true, ""));
            columns_Names_visible.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_Owner";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != "")
                {
                    T_Owner _Owner = db.OwnerEmp(int.Parse(frm.Serach_No));
                    txtOwnerNo.Text = _Owner.Owner_No.ToString();
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtOwnerName.Text = _Owner.NameA;
                    }
                    else
                    {
                        txtOwnerName.Text = _Owner.NameE;
                    }
                }
                else
                {
                    txtOwnerNo.Text = "";
                    txtOwnerName.Text = "";
                }
            }
            catch
            {
                txtOwnerNo.Text = "";
                txtOwnerName.Text = "";
            }
        }
        private void ButQuery_Click(object sender, EventArgs e)
        {
            FlexHead.Rows.Count = 1;
            FlexFooter.Rows.Count = 1;
            ProcessQuery(0);
        }
        private void ProcessQuery(int _typ)
        {
            try
            {
                VarGeneral.itmDes = "";
                EqarEye = false;
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = "  T_EqarsData INNER JOIN\r\n                                      T_EqarTyp ON T_EqarsData.EqarTypNo = T_EqarTyp.EqarTyp_No INNER JOIN\r\n                                      T_EqarNatural ON T_EqarsData.EqarNatureNo = T_EqarNatural.EqarNatural_No INNER JOIN\r\n                                      T_Owner ON T_EqarsData.OwnerNo = T_Owner.Owner_No INNER JOIN\r\n                                      T_City ON T_EqarsData.CityNo = T_City.City_No ";
                _RepShow.Rule = BuildRuleList() + " order by T_EqarsData.EqarNo ";
                _RepShow.Fields = " T_EqarsData.EqarID,T_EqarsData.EqarNo , T_EqarsData.NameA as EqarNameA, T_EqarsData.NameE as EqarNameE, T_EqarTyp.NameA AS EqarTypNameA, T_EqarTyp.NameE AS EqarTypNameE,T_EqarNatural.NameA as EqarNatureNameA,T_EqarNatural.NameE as EqarNatureNameE, T_Owner.NameA AS OwnerNameA, \r\n                                   T_Owner.NameE AS OwnerNameE, T_City.NameA AS CityNameA, T_City.NameE AS CityNameE,T_EqarsData.EqarStatus,T_EqarsData.ContractRentValue,T_EqarsData.ContractValue ";
                try
                {
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.Message);
                }
                if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "عفوا .. لا يوجد بيانات لعرضها في التقرير " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                try
                {
                    FlexHead.Rows.Count = VarGeneral.RepData.Tables[0].Rows.Count + 1;
                    if (_typ == 0)
                    {
                        for (int iiCnt = 1; iiCnt <= VarGeneral.RepData.Tables[0].Rows.Count; iiCnt++)
                        {
                            FlexHead.SetData(iiCnt, 0, VarGeneral.RepData.Tables[0].Rows[iiCnt - 1]["EqarNo"]);
                            FlexHead.SetData(iiCnt, 1, (LangArEn == 0) ? VarGeneral.RepData.Tables[0].Rows[iiCnt - 1]["EqarNameA"] : VarGeneral.RepData.Tables[0].Rows[iiCnt - 1]["EqarNameE"]);
                            FlexHead.SetData(iiCnt, 2, (LangArEn == 0) ? VarGeneral.RepData.Tables[0].Rows[iiCnt - 1]["OwnerNameA"] : VarGeneral.RepData.Tables[0].Rows[iiCnt - 1]["OwnerNameE"]);
                            FlexHead.SetData(iiCnt, 3, (LangArEn == 0) ? VarGeneral.RepData.Tables[0].Rows[iiCnt - 1]["CityNameA"] : VarGeneral.RepData.Tables[0].Rows[iiCnt - 1]["CityNameE"]);
                            FlexHead.SetData(iiCnt, 4, (LangArEn == 0) ? VarGeneral.RepData.Tables[0].Rows[iiCnt - 1]["EqarTypNameA"] : VarGeneral.RepData.Tables[0].Rows[iiCnt - 1]["EqarTypNameE"]);
                            FlexHead.SetData(iiCnt, 5, (LangArEn == 0) ? VarGeneral.RepData.Tables[0].Rows[iiCnt - 1]["EqarNatureNameA"] : VarGeneral.RepData.Tables[0].Rows[iiCnt - 1]["EqarNatureNameE"]);
                            FlexHead.SetData(iiCnt, 6, (int.Parse(VarGeneral.RepData.Tables[0].Rows[iiCnt - 1]["EqarStatus"].ToString()) == 0) ? ((LangArEn == 0) ? "فارغة" : "Empty") : ((int.Parse(VarGeneral.RepData.Tables[0].Rows[iiCnt - 1]["EqarStatus"].ToString()) == 1) ? ((LangArEn == 0) ? "مؤجرة" : "Leased") : ((LangArEn == 0) ? "مباعة" : "sold")));
                            FlexHead.SetData(iiCnt, 7, VarGeneral.RepData.Tables[0].Rows[iiCnt - 1]["ContractValue"]);
                            FlexHead.SetData(iiCnt, 8, VarGeneral.RepData.Tables[0].Rows[iiCnt - 1]["ContractRentValue"]);
                        }
                        EqarEye = true;
                        _RepShow = new RepShow();
                        _RepShow.Tables = "  T_EqarsData left JOIN\r\n                                                  T_EqarTyp ON T_EqarsData.EqarTypNo = T_EqarTyp.EqarTyp_No left JOIN\r\n                                                  T_EqarNatural ON T_EqarsData.EqarNatureNo = T_EqarNatural.EqarNatural_No left JOIN\r\n                                                  T_AinsData ON T_EqarsData.EqarID = T_AinsData.EqarID left JOIN\r\n                                                  T_AinTyp ON T_AinsData.AinTyp = T_AinTyp.AinTyp_No left JOIN\r\n                                                  T_AinNatural ON T_AinsData.AinNature = T_AinNatural.AinNatural_No left JOIN\r\n                                                  T_TenantContract ON T_EqarsData.EqarID = T_TenantContract.Eqar_ID AND T_AinsData.AinID = T_TenantContract.Ain_ID left JOIN\r\n                                                  T_Tenant ON T_TenantContract.tenant_ID = T_Tenant.tenantID left JOIN\r\n                                                  T_Owner ON T_EqarsData.OwnerNo = T_Owner.Owner_No left JOIN\r\n                                                  T_City ON T_EqarsData.CityNo = T_City.City_No ";
                        _RepShow.Rule = BuildRuleList() + " order by T_EqarsData.EqarNo,T_AinsData.AinNo";
                        _RepShow.Fields = " T_EqarsData.EqarID,T_EqarsData.EqarNo , T_EqarsData.NameA as EqarNameA, T_EqarsData.NameE as EqarNameE, T_EqarTyp.NameA AS EqarTypNameA, T_EqarTyp.NameE AS EqarTypNameE,T_EqarNatural.NameA as EqarNatureNameA,T_EqarNatural.NameE as EqarNatureNameE, T_Owner.NameA AS OwnerNameA, \r\n                                                 T_Owner.NameE AS OwnerNameE, T_City.NameA AS CityNameA, T_City.NameE AS CityNameE, T_AinsData.AinNo, T_AinTyp.NameA AS EyeTypeNameA, T_AinTyp.NameE AS EyeTypeNameE, \r\n                                                 T_AinNatural.NameA AS EyeNatureNameA, T_AinNatural.NameE AS EyeNatureNameE, T_AinsData.RentOfYear, T_EqarsData.EqarStatus, T_AinsData.AinStatus, \r\n                                                 T_EqarsData.ContractRentValue,T_EqarsData.ContractValue ,T_Tenant.tenantNo,T_Tenant.NameA as TenantNameA,T_Tenant.NameE as TenantNameE,T_TenantContract.ContractNo,T_TenantContract.ContractStart,T_TenantContract.ContractEnd ";
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        FlexFooter.Rows.Count = VarGeneral.RepData.Tables[0].Rows.Count + 1;
                        for (int iiCnt = 1; iiCnt <= VarGeneral.RepData.Tables[0].Rows.Count; iiCnt++)
                        {
                            FlexFooter.SetData(iiCnt, 0, VarGeneral.RepData.Tables[0].Rows[iiCnt - 1]["EqarNo"]);
                            FlexFooter.SetData(iiCnt, 1, VarGeneral.RepData.Tables[0].Rows[iiCnt - 1]["AinNo"]);
                            FlexFooter.SetData(iiCnt, 2, (LangArEn == 0) ? VarGeneral.RepData.Tables[0].Rows[iiCnt - 1]["EyeTypeNameA"] : VarGeneral.RepData.Tables[0].Rows[iiCnt - 1]["EyeTypeNameA"]);
                            FlexFooter.SetData(iiCnt, 3, (int.Parse(VarGeneral.RepData.Tables[0].Rows[iiCnt - 1]["AinStatus"].ToString()) == 0) ? ((LangArEn == 0) ? "فارغة" : "Empty") : ((int.Parse(VarGeneral.RepData.Tables[0].Rows[iiCnt - 1]["AinStatus"].ToString()) == 1) ? ((LangArEn == 0) ? "مؤجرة" : "Leased") : ((LangArEn == 0) ? "مباعة" : "sold")));
                            FlexFooter.SetData(iiCnt, 4, (LangArEn == 0) ? VarGeneral.RepData.Tables[0].Rows[iiCnt - 1]["EyeNatureNameA"] : VarGeneral.RepData.Tables[0].Rows[iiCnt - 1]["EyeNatureNameE"]);
                            FlexFooter.SetData(iiCnt, 5, VarGeneral.RepData.Tables[0].Rows[iiCnt - 1]["tenantNo"]);
                            FlexFooter.SetData(iiCnt, 6, (LangArEn == 0) ? VarGeneral.RepData.Tables[0].Rows[iiCnt - 1]["TenantNameA"] : VarGeneral.RepData.Tables[0].Rows[iiCnt - 1]["TenantNameE"]);
                            FlexFooter.SetData(iiCnt, 7, VarGeneral.RepData.Tables[0].Rows[iiCnt - 1]["ContractNo"]);
                            FlexFooter.SetData(iiCnt, 8, VarGeneral.RepData.Tables[0].Rows[iiCnt - 1]["ContractStart"]);
                            FlexFooter.SetData(iiCnt, 9, VarGeneral.RepData.Tables[0].Rows[iiCnt - 1]["ContractEnd"]);
                        }
                    }
                    else
                    {
                        VarGeneral.IsGeneralUsed = true;
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "ItemsData";
                        frm.Tag = LangArEn;
                        frm.Repvalue = "ItemsData";
                        VarGeneral.vTitle = Text;
                        frm.TopMost = true;
                        frm.ShowDialog();
                        VarGeneral.IsGeneralUsed = false;
                    }
                }
                catch (Exception error)
                {
                    VarGeneral.DebLog.writeLog("button_ShowRep_Click:", error, enable: true);
                    MessageBox.Show(error.Message);
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }
    }
}
