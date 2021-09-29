using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
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
    public partial  class FrmUserPointReturn : Form
    { void avs(int arln)

{ 
 label3.Text=   (arln == 0 ? "  تعيين مستخدمين نقاط البيع  " : "  Assigning point of sale users") ; buttonX_Close.Text=   (arln == 0 ? "  إغلاق  " : "  Close") ; label13.Text=   (arln == 0 ? "  حسابات فاتورة المبيعات  " : "  Sales invoice accounts") ; groupPanel4.Text=   (arln == 0 ? "  حسابات القيد الآجــل  " : "  deferred entry accounts") ; label7.Text=   (arln == 0 ? "  الحساب المديـن :  " : "  Debit account:") ; label8.Text=   (arln == 0 ? "  الحساب الدائـــن :  " : "  Debit account:") ; groupPanel5.Text=   (arln == 0 ? "  حسابات القيد النقــدي  " : "  cash entry accounts") ; label9.Text=   (arln == 0 ? "  الحساب المديـن :  " : "  Debit account:") ; label10.Text=   (arln == 0 ? "  الحسـاب الدائـن :  " : "  Credit account:") ; groupPanel6.Text=   (arln == 0 ? "  حسابات قيد الشــبكة  " : "  Network accounts") ; label11.Text=   (arln == 0 ? "  الحساب المديـن :  " : "  Debit account:") ; label12.Text=   (arln == 0 ? "  الحساب الدائـــن :  " : "  Debit account:") ; groupPanel3.Text=   (arln == 0 ? "  حسابات القيد الآجــل  " : "  deferred entry accounts") ; label5.Text=   (arln == 0 ? "  الحساب المديـن :  " : "  Debit account:") ; label6.Text=   (arln == 0 ? "  الحساب الدائـــن :  " : "  Debit account:") ; groupPanel1.Text=   (arln == 0 ? "  حسابات القيد النقــدي  " : "  cash entry accounts") ; labelD1.Text=   (arln == 0 ? "  الحساب المديـن :  " : "  Debit account:") ; labelC1.Text=   (arln == 0 ? "  الحسـاب الدائـن :  " : "  Credit account:") ; groupPanel2.Text=   (arln == 0 ? "  حسابات قيد الشــبكة  " : "  Network accounts") ; label2.Text=   (arln == 0 ? "  الحساب المديـن :  " : "  Debit account:") ; label4.Text=   (arln == 0 ? "  الحساب الدائـــن :  " : "  Debit account:") ; label14.Text=   (arln == 0 ? "  حسابات فاتورة مرتجع المبيعات  " : "  Sales return invoice accounts") ; buttonX_Delete.Text=   (arln == 0 ? "  حــــذف  " : "  delete") ; ChkGaid.Text=   (arln == 0 ? "  انشاء قيد تلقائي  " : "  Automatic entry creation") ; label1.Text=   (arln == 0 ? "  إسم المستخدم :  " : "  user name :") ; buttonX_OK.Text=   (arln == 0 ? "  حفــظ  " : "  save") ;}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
        }
   
        public class ColumnDictinary
        {
            public string AText = string.Empty;
            public string EText = string.Empty;
            public bool IfDefault = false;
            public string Format = string.Empty;
            public ColumnDictinary(string aText, string eText, bool ifDefault, string format)
            {
                AText = aText;
                EText = eText;
                IfDefault = ifDefault;
                Format = format;
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
        private LabelX label3;
        private ButtonX buttonX_Close;
        private RibbonBar ribbonBar1;
        private Panel panel1;
        private Label label1;
        private ButtonX buttonX_OK;
        private ComboBoxEx CmbUsers;
        private CheckBox ChkGaid;
        private ButtonX buttonX_Delete;
        private Label label13;
        private GroupPanel groupPanel4;
        private TextBoxX txtDebit3_R;
        private TextBoxX txtCredit3_R;
        internal Label label7;
        internal Label label8;
        private GroupPanel groupPanel5;
        private TextBoxX txtDebit1_R;
        private TextBoxX txtCredit1_R;
        internal Label label9;
        internal Label label10;
        private GroupPanel groupPanel6;
        private TextBoxX txtDebit2_R;
        private TextBoxX txtCredit2_R;
        internal Label label11;
        internal Label label12;
        private GroupPanel groupPanel3;
        private TextBoxX txtDebit3;
        private TextBoxX txtCredit3;
        internal Label label5;
        internal Label label6;
        private GroupPanel groupPanel1;
        private TextBoxX txtDebit1;
        private TextBoxX txtCredit1;
        internal Label labelD1;
        internal Label labelC1;
        private GroupPanel groupPanel2;
        private TextBoxX txtDebit2;
        private TextBoxX txtCredit2;
        internal Label label2;
        internal Label label4;
        private Label label14;
        private int LangArEn = 0;
        private Rate_DataDataContext dbInstance;
        private Stock_DataDataContext dbStock;
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private Rate_DataDataContext dbc
        {
            get
            {
                if (dbInstance == null)
                {
                    dbInstance = new Rate_DataDataContext(VarGeneral.BranchRt);
                }
                return dbInstance;
            }
        }
        private Stock_DataDataContext db
        {
            get
            {
                if (dbStock == null)
                {
                    dbStock = new Stock_DataDataContext(VarGeneral.BranchCS);
                }
                return dbStock;
            }
        }
        public FrmUserPointReturn()
        {
            InitializeComponent();this.Load += langloads;
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                buttonX_Close.Text = "إغلاق";
                buttonX_OK.Text = "حفــظ";
                buttonX_Delete.Text = "حــــذف";
                label1.Text = "إسم المستخدم :";
                label3.Text = "إزالة مستخدمين نقاط البيع";
                groupPanel1.Text = "حسابات القيد النقــدي";
                groupPanel2.Text = "حسابات قيد الشــبكة";
                groupPanel3.Text = "حسابات القيد الآجــل";
            }
            else
            {
                buttonX_Close.Text = "Close";
                buttonX_OK.Text = "Save";
                buttonX_Delete.Text = "Delete";
                label1.Text = "User Name :";
                label3.Text = "Delete Users POS";
                groupPanel1.Text = "Cash Accounts";
                groupPanel2.Text = "Network Accounts";
                groupPanel3.Text = "Credit Accounts";
            }
        }
        private void FrmUserPointReturn_Load(object sender, EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmUserPointReturn));
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
            FillCombo();
            if (VarGeneral.SSSTyp == 0)
            {
                txtDebit1.Enabled = false;
                txtDebit2.Enabled = false;
                txtDebit3.Enabled = false;
                txtCredit1.Enabled = false;
                txtCredit2.Enabled = false;
                txtCredit3.Enabled = false;
                txtDebit1_R.Enabled = false;
                txtDebit2_R.Enabled = false;
                txtDebit3_R.Enabled = false;
                txtCredit1_R.Enabled = false;
                txtCredit2_R.Enabled = false;
                txtCredit3_R.Enabled = false;
            }
        }
        private void FillCombo()
        {
            CmbUsers.DataSource = null;
            List<T_User> listUsers = new List<T_User>(dbc.T_Users.Where((T_User item) => item.Usr_ID != 1 && item.Usr_ID != 2 && item.UserPointTyp.Value == 1).ToList());
            listUsers.Insert(0, new T_User());
            CmbUsers.DataSource = listUsers;
            CmbUsers.DisplayMember = ((LangArEn == 0) ? "UsrNamA" : "UsrNamE");
            CmbUsers.ValueMember = "UsrNo";
            CmbUsers.SelectedIndex = 0;
        }
        private void FrmUserPointReturn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void buttonX_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbUsers.SelectedIndex <= 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "الرجاء تحديد اسم المستخدم" : "Please Select User Name", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (ChkGaid.Checked && (string.IsNullOrEmpty(txtCredit1.Text) || string.IsNullOrEmpty(txtCredit2.Text) || string.IsNullOrEmpty(txtCredit3.Text) || string.IsNullOrEmpty(txtDebit1.Text) || string.IsNullOrEmpty(txtDebit2.Text) || string.IsNullOrEmpty(txtDebit3.Text) || string.IsNullOrEmpty(txtCredit1_R.Text) || string.IsNullOrEmpty(txtCredit2_R.Text) || string.IsNullOrEmpty(txtCredit3_R.Text) || string.IsNullOrEmpty(txtDebit1_R.Text) || string.IsNullOrEmpty(txtDebit2_R.Text) || string.IsNullOrEmpty(txtDebit3_R.Text)))
                {
                    MessageBox.Show((LangArEn == 0) ? "الرجاء التأكد من تعبئة حسابات القيود النقدية الشبكة والآجلة" : "Please be sure to fill in the accounts cash and network.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                T_User DataThis = dbc.StockUser(CmbUsers.SelectedValue.ToString());
                if (DataThis == null || DataThis.Usr_ID == 0)
                {
                    ChkGaid.Checked = false;
                    ChkGaid_CheckedChanged(sender, e);
                    return;
                }
                T_User newData = new T_User();
                newData = DataThis;
                newData.UserPointTyp = 1;
                if (ChkGaid.Checked)
                {
                    newData.CreateGaid = 1;
                    newData.CashAccNo_D = txtDebit1.Tag.ToString();
                    newData.CashAccNo_C = txtCredit1.Tag.ToString();
                    newData.NetworkAccNo_D = txtDebit2.Tag.ToString();
                    newData.NetworkAccNo_C = txtCredit2.Tag.ToString();
                    newData.CreaditAccNo_D = txtDebit3.Tag.ToString();
                    newData.CreaditAccNo_C = txtCredit3.Tag.ToString();
                    newData.CashAccNo_D_R = txtDebit1_R.Tag.ToString();
                    newData.CashAccNo_C_R = txtCredit1_R.Tag.ToString();
                    newData.NetworkAccNo_D_R = txtDebit2_R.Tag.ToString();
                    newData.NetworkAccNo_C_R = txtCredit2_R.Tag.ToString();
                    newData.CreaditAccNo_D_R = txtDebit3_R.Tag.ToString();
                    newData.CreaditAccNo_C_R = txtCredit3_R.Tag.ToString();
                }
                else
                {
                    newData.CreateGaid = 0;
                    newData.CashAccNo_D = string.Empty;
                    newData.CashAccNo_C = string.Empty;
                    newData.NetworkAccNo_D = string.Empty;
                    newData.NetworkAccNo_C = string.Empty;
                    newData.CreaditAccNo_D = string.Empty;
                    newData.CreaditAccNo_C = string.Empty;
                    newData.CashAccNo_D_R = string.Empty;
                    newData.CashAccNo_C_R = string.Empty;
                    newData.NetworkAccNo_D_R = string.Empty;
                    newData.NetworkAccNo_C_R = string.Empty;
                    newData.CreaditAccNo_D_R = string.Empty;
                    newData.CreaditAccNo_C_R = string.Empty;
                }
                try
                {
                    dbc.Log = VarGeneral.DebugLog;
                    dbc.SubmitChanges(ConflictMode.ContinueOnConflict);
                }
                catch (SqlException)
                {
                    return;
                }
                catch (Exception)
                {
                    return;
                }
                MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                dbInstance = null;
                FillCombo();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("buttonX_OK_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void buttonX_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void textBox_DataBaseNm_Enter(object sender, EventArgs e)
        {
            Language.Switch("EN");
        }
        private void textBox_DataBaseNm_KeyPress(object sender, KeyPressEventArgs e)
        {
            Language.Switch("EN");
        }
        private void CmbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbUsers.SelectedIndex > 0)
            {
                T_User DataThis = dbc.StockUser(CmbUsers.SelectedValue.ToString());
                if (DataThis == null || DataThis.Usr_ID == 0)
                {
                    ChkGaid.Checked = false;
                    ChkGaid_CheckedChanged(sender, e);
                }
                else if (DataThis.CreateGaid.HasValue)
                {
                    if (DataThis.CreateGaid.Value == 1)
                    {
                        ChkGaid.Checked = true;
                        txtCredit1.Tag = DataThis.CashAccNo_C;
                        txtDebit1.Tag = DataThis.CashAccNo_D;
                        txtCredit2.Tag = DataThis.NetworkAccNo_C;
                        txtDebit2.Tag = DataThis.NetworkAccNo_D;
                        txtCredit3.Tag = DataThis.CreaditAccNo_C;
                        txtDebit3.Tag = DataThis.CreaditAccNo_D;
                        if (DataThis.CashAccNo_C == "***")
                        {
                            txtCredit1.Text = "***";
                        }
                        else
                        {
                            txtCredit1.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.CashAccNo_C).Arb_Des : db.StockAccDefWithOutBalance(DataThis.CashAccNo_C).Eng_Des);
                        }
                        if (DataThis.CashAccNo_D == "***")
                        {
                            txtDebit1.Text = "***";
                        }
                        else
                        {
                            txtDebit1.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.CashAccNo_D).Arb_Des : db.StockAccDefWithOutBalance(DataThis.CashAccNo_D).Eng_Des);
                        }
                        if (DataThis.NetworkAccNo_C == "***")
                        {
                            txtCredit2.Text = "***";
                        }
                        else
                        {
                            txtCredit2.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.NetworkAccNo_C).Arb_Des : db.StockAccDefWithOutBalance(DataThis.NetworkAccNo_C).Eng_Des);
                        }
                        if (DataThis.NetworkAccNo_D == "***")
                        {
                            txtDebit2.Text = "***";
                        }
                        else
                        {
                            txtDebit2.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.NetworkAccNo_D).Arb_Des : db.StockAccDefWithOutBalance(DataThis.NetworkAccNo_D).Eng_Des);
                        }
                        if (DataThis.CreaditAccNo_C == "***")
                        {
                            txtCredit3.Text = "***";
                        }
                        else
                        {
                            txtCredit3.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.CreaditAccNo_C).Arb_Des : db.StockAccDefWithOutBalance(DataThis.CreaditAccNo_C).Eng_Des);
                        }
                        if (DataThis.CreaditAccNo_D == "***")
                        {
                            txtDebit3.Text = "***";
                        }
                        else
                        {
                            txtDebit3.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.CreaditAccNo_D).Arb_Des : db.StockAccDefWithOutBalance(DataThis.CreaditAccNo_D).Eng_Des);
                        }
                        txtCredit1_R.Tag = DataThis.CashAccNo_C_R;
                        txtDebit1_R.Tag = DataThis.CashAccNo_D_R;
                        txtCredit2_R.Tag = DataThis.NetworkAccNo_C_R;
                        txtDebit2_R.Tag = DataThis.NetworkAccNo_D_R;
                        txtCredit3_R.Tag = DataThis.CreaditAccNo_C_R;
                        txtDebit3_R.Tag = DataThis.CreaditAccNo_D_R;
                        if (DataThis.CashAccNo_C_R == "***")
                        {
                            txtCredit1_R.Text = "***";
                        }
                        else
                        {
                            txtCredit1_R.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.CashAccNo_C_R).Arb_Des : db.StockAccDefWithOutBalance(DataThis.CashAccNo_C_R).Eng_Des);
                        }
                        if (DataThis.CashAccNo_D_R == "***")
                        {
                            txtDebit1_R.Text = "***";
                        }
                        else
                        {
                            txtDebit1_R.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.CashAccNo_D_R).Arb_Des : db.StockAccDefWithOutBalance(DataThis.CashAccNo_D_R).Eng_Des);
                        }
                        if (DataThis.NetworkAccNo_C_R == "***")
                        {
                            txtCredit2_R.Text = "***";
                        }
                        else
                        {
                            txtCredit2_R.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.NetworkAccNo_C_R).Arb_Des : db.StockAccDefWithOutBalance(DataThis.NetworkAccNo_C_R).Eng_Des);
                        }
                        if (DataThis.NetworkAccNo_D_R == "***")
                        {
                            txtDebit2_R.Text = "***";
                        }
                        else
                        {
                            txtDebit2_R.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.NetworkAccNo_D_R).Arb_Des : db.StockAccDefWithOutBalance(DataThis.NetworkAccNo_D_R).Eng_Des);
                        }
                        if (DataThis.CreaditAccNo_C_R == "***")
                        {
                            txtCredit3_R.Text = "***";
                        }
                        else
                        {
                            txtCredit3_R.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.CreaditAccNo_C_R).Arb_Des : db.StockAccDefWithOutBalance(DataThis.CreaditAccNo_C_R).Eng_Des);
                        }
                        if (DataThis.CreaditAccNo_D_R == "***")
                        {
                            txtDebit3_R.Text = "***";
                        }
                        else
                        {
                            txtDebit3_R.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.CreaditAccNo_D_R).Arb_Des : db.StockAccDefWithOutBalance(DataThis.CreaditAccNo_D_R).Eng_Des);
                        }
                    }
                    else
                    {
                        ChkGaid.Checked = false;
                        ChkGaid_CheckedChanged(sender, e);
                    }
                }
                else
                {
                    ChkGaid.Checked = false;
                    ChkGaid_CheckedChanged(sender, e);
                }
            }
            else
            {
                ChkGaid.Checked = false;
                ChkGaid_CheckedChanged(sender, e);
            }
        }
        private void txtDebit1_ButtonCustomClick(object sender, EventArgs e)
        {
            if (CmbUsers.SelectedIndex <= 0 || !ChkGaid.Checked)
            {
                return;
            }
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtDebit1.Tag = _AccDef.AccDef_No.ToString();
                    txtDebit1.Text = ((LangArEn == 0) ? _AccDef.Arb_Des : _AccDef.Eng_Des);
                }
                else
                {
                    txtDebit1.Text = "***";
                    txtDebit1.Tag = "***";
                }
            }
            catch
            {
                txtDebit1.Text = "***";
                txtDebit1.Tag = "***";
            }
        }
        private void txtCredit1_ButtonCustomClick(object sender, EventArgs e)
        {
            if (CmbUsers.SelectedIndex <= 0 || !ChkGaid.Checked)
            {
                return;
            }
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtCredit1.Tag = _AccDef.AccDef_No.ToString();
                    txtCredit1.Text = ((LangArEn == 0) ? _AccDef.Arb_Des : _AccDef.Eng_Des);
                }
                else
                {
                    txtCredit1.Text = "***";
                    txtCredit1.Tag = "***";
                }
            }
            catch
            {
                txtCredit1.Text = "***";
                txtCredit1.Tag = "***";
            }
        }
        private void txtDebit2_ButtonCustomClick(object sender, EventArgs e)
        {
            if (CmbUsers.SelectedIndex <= 0 || !ChkGaid.Checked || CmbUsers.SelectedIndex <= 0 || !ChkGaid.Checked)
            {
                return;
            }
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtDebit2.Tag = _AccDef.AccDef_No.ToString();
                    txtDebit2.Text = ((LangArEn == 0) ? _AccDef.Arb_Des : _AccDef.Eng_Des);
                }
                else
                {
                    txtDebit2.Text = "***";
                    txtDebit2.Tag = "***";
                }
            }
            catch
            {
                txtDebit2.Text = "***";
                txtDebit2.Tag = "***";
            }
        }
        private void txtCredit2_ButtonCustomClick(object sender, EventArgs e)
        {
            if (CmbUsers.SelectedIndex <= 0 || !ChkGaid.Checked)
            {
                return;
            }
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtCredit2.Tag = _AccDef.AccDef_No.ToString();
                    txtCredit2.Text = ((LangArEn == 0) ? _AccDef.Arb_Des : _AccDef.Eng_Des);
                }
                else
                {
                    txtCredit2.Text = "***";
                    txtCredit2.Tag = "***";
                }
            }
            catch
            {
                txtCredit2.Text = "***";
                txtCredit2.Tag = "***";
            }
        }
        private void ChkGaid_CheckedChanged(object sender, EventArgs e)
        {
            if (!ChkGaid.Checked)
            {
                txtDebit3.Text = string.Empty;
                txtDebit2.Text = string.Empty;
                txtDebit1.Text = string.Empty;
                txtCredit3.Text = string.Empty;
                txtCredit2.Text = string.Empty;
                txtCredit1.Text = string.Empty;
                txtDebit3.Tag = string.Empty;
                txtDebit2.Tag = string.Empty;
                txtDebit1.Tag = string.Empty;
                txtCredit3.Tag = string.Empty;
                txtCredit2.Tag = string.Empty;
                txtCredit1.Tag = string.Empty;
                txtDebit3_R.Text = string.Empty;
                txtDebit2_R.Text = string.Empty;
                txtDebit1_R.Text = string.Empty;
                txtCredit3_R.Text = string.Empty;
                txtCredit2_R.Text = string.Empty;
                txtCredit1_R.Text = string.Empty;
                txtDebit3_R.Tag = string.Empty;
                txtDebit2_R.Tag = string.Empty;
                txtDebit1_R.Tag = string.Empty;
                txtCredit3_R.Tag = string.Empty;
                txtCredit2_R.Tag = string.Empty;
                txtCredit1_R.Tag = string.Empty;
            }
            else if (CmbUsers.SelectedIndex > 0)
            {
                T_User DataThis = dbc.StockUser(CmbUsers.SelectedValue.ToString());
                if (DataThis == null || DataThis.Usr_ID == 0)
                {
                    txtDebit3.Text = string.Empty;
                    txtDebit2.Text = string.Empty;
                    txtDebit1.Text = string.Empty;
                    txtCredit3.Text = string.Empty;
                    txtCredit2.Text = string.Empty;
                    txtCredit1.Text = string.Empty;
                    txtDebit3.Tag = string.Empty;
                    txtDebit2.Tag = string.Empty;
                    txtDebit1.Tag = string.Empty;
                    txtCredit3.Tag = string.Empty;
                    txtCredit2.Tag = string.Empty;
                    txtCredit1.Tag = string.Empty;
                    txtDebit3_R.Text = string.Empty;
                    txtDebit2_R.Text = string.Empty;
                    txtDebit1_R.Text = string.Empty;
                    txtCredit3_R.Text = string.Empty;
                    txtCredit2_R.Text = string.Empty;
                    txtCredit1_R.Text = string.Empty;
                    txtDebit3_R.Tag = string.Empty;
                    txtDebit2_R.Tag = string.Empty;
                    txtDebit1_R.Tag = string.Empty;
                    txtCredit3_R.Tag = string.Empty;
                    txtCredit2_R.Tag = string.Empty;
                    txtCredit1_R.Tag = string.Empty;
                }
                else if (DataThis.CreateGaid.HasValue)
                {
                    if (DataThis.CreateGaid.Value == 1)
                    {
                        ChkGaid.Checked = true;
                        txtCredit1.Tag = DataThis.CashAccNo_C;
                        txtDebit1.Tag = DataThis.CashAccNo_D;
                        txtCredit2.Tag = DataThis.NetworkAccNo_C;
                        txtDebit2.Tag = DataThis.NetworkAccNo_D;
                        if (DataThis.CashAccNo_C == "***")
                        {
                            txtCredit1.Text = "***";
                        }
                        else
                        {
                            txtCredit1.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.CashAccNo_C).Arb_Des : db.StockAccDefWithOutBalance(DataThis.CashAccNo_C).Eng_Des);
                        }
                        if (DataThis.CashAccNo_D == "***")
                        {
                            txtDebit1.Text = "***";
                        }
                        else
                        {
                            txtDebit1.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.CashAccNo_D).Arb_Des : db.StockAccDefWithOutBalance(DataThis.CashAccNo_D).Eng_Des);
                        }
                        if (DataThis.NetworkAccNo_C == "***")
                        {
                            txtCredit2.Text = "***";
                        }
                        else
                        {
                            txtCredit2.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.NetworkAccNo_C).Arb_Des : db.StockAccDefWithOutBalance(DataThis.NetworkAccNo_C).Eng_Des);
                        }
                        if (DataThis.NetworkAccNo_D == "***")
                        {
                            txtDebit2.Text = "***";
                        }
                        else
                        {
                            txtDebit2.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.NetworkAccNo_D).Arb_Des : db.StockAccDefWithOutBalance(DataThis.NetworkAccNo_D).Eng_Des);
                        }
                        if (DataThis.CreaditAccNo_C == "***")
                        {
                            txtCredit3.Text = "***";
                        }
                        else
                        {
                            txtCredit3.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.CreaditAccNo_C).Arb_Des : db.StockAccDefWithOutBalance(DataThis.CreaditAccNo_C).Eng_Des);
                        }
                        if (DataThis.CreaditAccNo_D == "***")
                        {
                            txtDebit3.Text = "***";
                        }
                        else
                        {
                            txtDebit3.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.CreaditAccNo_D).Arb_Des : db.StockAccDefWithOutBalance(DataThis.CreaditAccNo_D).Eng_Des);
                        }
                        txtCredit1_R.Tag = DataThis.CashAccNo_C_R;
                        txtDebit1_R.Tag = DataThis.CashAccNo_D_R;
                        txtCredit2_R.Tag = DataThis.NetworkAccNo_C_R;
                        txtDebit2_R.Tag = DataThis.NetworkAccNo_D_R;
                        if (DataThis.CashAccNo_C_R == "***")
                        {
                            txtCredit1_R.Text = "***";
                        }
                        else
                        {
                            txtCredit1_R.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.CashAccNo_C_R).Arb_Des : db.StockAccDefWithOutBalance(DataThis.CashAccNo_C_R).Eng_Des);
                        }
                        if (DataThis.CashAccNo_D_R == "***")
                        {
                            txtDebit1_R.Text = "***";
                        }
                        else
                        {
                            txtDebit1_R.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.CashAccNo_D_R).Arb_Des : db.StockAccDefWithOutBalance(DataThis.CashAccNo_D_R).Eng_Des);
                        }
                        if (DataThis.NetworkAccNo_C_R == "***")
                        {
                            txtCredit2_R.Text = "***";
                        }
                        else
                        {
                            txtCredit2_R.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.NetworkAccNo_C_R).Arb_Des : db.StockAccDefWithOutBalance(DataThis.NetworkAccNo_C_R).Eng_Des);
                        }
                        if (DataThis.NetworkAccNo_D_R == "***")
                        {
                            txtDebit2_R.Text = "***";
                        }
                        else
                        {
                            txtDebit2_R.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.NetworkAccNo_D_R).Arb_Des : db.StockAccDefWithOutBalance(DataThis.NetworkAccNo_D_R).Eng_Des);
                        }
                        if (DataThis.CreaditAccNo_C_R == "***")
                        {
                            txtCredit3_R.Text = "***";
                        }
                        else
                        {
                            txtCredit3_R.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.CreaditAccNo_C_R).Arb_Des : db.StockAccDefWithOutBalance(DataThis.CreaditAccNo_C_R).Eng_Des);
                        }
                        if (DataThis.CreaditAccNo_D_R == "***")
                        {
                            txtDebit3_R.Text = "***";
                        }
                        else
                        {
                            txtDebit3_R.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.CreaditAccNo_D_R).Arb_Des : db.StockAccDefWithOutBalance(DataThis.CreaditAccNo_D_R).Eng_Des);
                        }
                    }
                    else
                    {
                        txtDebit3.Text = string.Empty;
                        txtDebit2.Text = string.Empty;
                        txtDebit1.Text = string.Empty;
                        txtCredit3.Text = string.Empty;
                        txtCredit2.Text = string.Empty;
                        txtCredit1.Text = string.Empty;
                        txtDebit3.Tag = string.Empty;
                        txtDebit2.Tag = string.Empty;
                        txtDebit1.Tag = string.Empty;
                        txtCredit3.Tag = string.Empty;
                        txtCredit2.Tag = string.Empty;
                        txtCredit1.Tag = string.Empty;
                        txtDebit3_R.Text = string.Empty;
                        txtDebit2_R.Text = string.Empty;
                        txtDebit1_R.Text = string.Empty;
                        txtCredit3_R.Text = string.Empty;
                        txtCredit2_R.Text = string.Empty;
                        txtCredit1_R.Text = string.Empty;
                        txtDebit3_R.Tag = string.Empty;
                        txtDebit2_R.Tag = string.Empty;
                        txtDebit1_R.Tag = string.Empty;
                        txtCredit3_R.Tag = string.Empty;
                        txtCredit2_R.Tag = string.Empty;
                        txtCredit1_R.Tag = string.Empty;
                    }
                }
                else
                {
                    txtDebit3.Text = string.Empty;
                    txtDebit2.Text = string.Empty;
                    txtDebit1.Text = string.Empty;
                    txtCredit3.Text = string.Empty;
                    txtCredit2.Text = string.Empty;
                    txtCredit1.Text = string.Empty;
                    txtDebit3.Tag = string.Empty;
                    txtDebit2.Tag = string.Empty;
                    txtDebit1.Tag = string.Empty;
                    txtCredit3.Tag = string.Empty;
                    txtCredit2.Tag = string.Empty;
                    txtCredit1.Tag = string.Empty;
                    txtDebit3_R.Text = string.Empty;
                    txtDebit2_R.Text = string.Empty;
                    txtDebit1_R.Text = string.Empty;
                    txtCredit3_R.Text = string.Empty;
                    txtCredit2_R.Text = string.Empty;
                    txtCredit1_R.Text = string.Empty;
                    txtDebit3_R.Tag = string.Empty;
                    txtDebit2_R.Tag = string.Empty;
                    txtDebit1_R.Tag = string.Empty;
                    txtCredit3_R.Tag = string.Empty;
                    txtCredit2_R.Tag = string.Empty;
                    txtCredit1_R.Tag = string.Empty;
                }
            }
            else
            {
                txtDebit3.Text = string.Empty;
                txtDebit2.Text = string.Empty;
                txtDebit1.Text = string.Empty;
                txtCredit3.Text = string.Empty;
                txtCredit2.Text = string.Empty;
                txtCredit1.Text = string.Empty;
                txtDebit3.Tag = string.Empty;
                txtDebit2.Tag = string.Empty;
                txtDebit1.Tag = string.Empty;
                txtCredit3.Tag = string.Empty;
                txtCredit2.Tag = string.Empty;
                txtCredit1.Tag = string.Empty;
                txtDebit3_R.Text = string.Empty;
                txtDebit2_R.Text = string.Empty;
                txtDebit1_R.Text = string.Empty;
                txtCredit3_R.Text = string.Empty;
                txtCredit2_R.Text = string.Empty;
                txtCredit1_R.Text = string.Empty;
                txtDebit3_R.Tag = string.Empty;
                txtDebit2_R.Tag = string.Empty;
                txtDebit1_R.Tag = string.Empty;
                txtCredit3_R.Tag = string.Empty;
                txtCredit2_R.Tag = string.Empty;
                txtCredit1_R.Tag = string.Empty;
            }
        }
        private void buttonX_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbUsers.SelectedIndex <= 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "الرجاء تحديد اسم المستخدم" : "Please Select User Name", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    if (MessageBox.Show("هل أنت متاكد من ازالة نقطة البيع للمستخدم  [" + CmbUsers.Text + "]؟ \n Are you sure that you want to delete the POS  [" + CmbUsers.Text + "]?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        return;
                    }
                    T_User DataThis = dbc.StockUser(CmbUsers.SelectedValue.ToString());
                    if (DataThis == null || DataThis.Usr_ID == 0)
                    {
                        ChkGaid.Checked = false;
                        ChkGaid_CheckedChanged(sender, e);
                        return;
                    }
                    T_User newData = new T_User();
                    newData = DataThis;
                    newData.UserPointTyp = 0;
                    newData.CreateGaid = 0;
                    newData.CashAccNo_D = string.Empty;
                    newData.CashAccNo_C = string.Empty;
                    newData.NetworkAccNo_D = string.Empty;
                    newData.NetworkAccNo_C = string.Empty;
                    newData.CreaditAccNo_D = string.Empty;
                    newData.CreaditAccNo_C = string.Empty;
                    newData.CashAccNo_D_R = string.Empty;
                    newData.CashAccNo_C_R = string.Empty;
                    newData.NetworkAccNo_D_R = string.Empty;
                    newData.NetworkAccNo_C_R = string.Empty;
                    newData.CreaditAccNo_D_R = string.Empty;
                    newData.CreaditAccNo_C_R = string.Empty;
                    try
                    {
                        dbc.Log = VarGeneral.DebugLog;
                        dbc.SubmitChanges(ConflictMode.ContinueOnConflict);
                    }
                    catch (SqlException)
                    {
                        return;
                    }
                    catch (Exception)
                    {
                        return;
                    }
                    MessageBox.Show((LangArEn == 0) ? "تمت العملية بنجاح .." : "Delete OPS Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    dbInstance = null;
                    FillCombo();
                    return;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("buttonX_Delete_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void txtDebit3_ButtonCustomClick(object sender, EventArgs e)
        {
            if (CmbUsers.SelectedIndex <= 0 || !ChkGaid.Checked || CmbUsers.SelectedIndex <= 0 || !ChkGaid.Checked)
            {
                return;
            }
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtDebit3.Tag = _AccDef.AccDef_No.ToString();
                    txtDebit3.Text = ((LangArEn == 0) ? _AccDef.Arb_Des : _AccDef.Eng_Des);
                }
                else
                {
                    txtDebit3.Text = "***";
                    txtDebit3.Tag = "***";
                }
            }
            catch
            {
                txtDebit3.Text = "***";
                txtDebit3.Tag = "***";
            }
        }
        private void txtCredit3_ButtonCustomClick(object sender, EventArgs e)
        {
            if (CmbUsers.SelectedIndex <= 0 || !ChkGaid.Checked)
            {
                return;
            }
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtCredit3.Tag = _AccDef.AccDef_No.ToString();
                    txtCredit3.Text = ((LangArEn == 0) ? _AccDef.Arb_Des : _AccDef.Eng_Des);
                }
                else
                {
                    txtCredit3.Text = "***";
                    txtCredit3.Tag = "***";
                }
            }
            catch
            {
                txtCredit3.Text = "***";
                txtCredit3.Tag = "***";
            }
        }
        private void txtDebit1_R_ButtonCustomClick(object sender, EventArgs e)
        {
            if (CmbUsers.SelectedIndex <= 0 || !ChkGaid.Checked)
            {
                return;
            }
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtDebit1_R.Tag = _AccDef.AccDef_No.ToString();
                    txtDebit1_R.Text = ((LangArEn == 0) ? _AccDef.Arb_Des : _AccDef.Eng_Des);
                }
                else
                {
                    txtDebit1_R.Text = "***";
                    txtDebit1_R.Tag = "***";
                }
            }
            catch
            {
                txtDebit1_R.Text = "***";
                txtDebit1_R.Tag = "***";
            }
        }
        private void txtDebit2_R_ButtonCustomClick(object sender, EventArgs e)
        {
            if (CmbUsers.SelectedIndex <= 0 || !ChkGaid.Checked)
            {
                return;
            }
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtDebit2_R.Tag = _AccDef.AccDef_No.ToString();
                    txtDebit2_R.Text = ((LangArEn == 0) ? _AccDef.Arb_Des : _AccDef.Eng_Des);
                }
                else
                {
                    txtDebit2_R.Text = "***";
                    txtDebit2_R.Tag = "***";
                }
            }
            catch
            {
                txtDebit2_R.Text = "***";
                txtDebit2_R.Tag = "***";
            }
        }
        private void txtDebit3_R_ButtonCustomClick(object sender, EventArgs e)
        {
            if (CmbUsers.SelectedIndex <= 0 || !ChkGaid.Checked)
            {
                return;
            }
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtDebit3_R.Tag = _AccDef.AccDef_No.ToString();
                    txtDebit3_R.Text = ((LangArEn == 0) ? _AccDef.Arb_Des : _AccDef.Eng_Des);
                }
                else
                {
                    txtDebit3_R.Text = "***";
                    txtDebit3_R.Tag = "***";
                }
            }
            catch
            {
                txtDebit3_R.Text = "***";
                txtDebit3_R.Tag = "***";
            }
        }
        private void txtCredit1_R_ButtonCustomClick(object sender, EventArgs e)
        {
            if (CmbUsers.SelectedIndex <= 0 || !ChkGaid.Checked)
            {
                return;
            }
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtCredit1_R.Tag = _AccDef.AccDef_No.ToString();
                    txtCredit1_R.Text = ((LangArEn == 0) ? _AccDef.Arb_Des : _AccDef.Eng_Des);
                }
                else
                {
                    txtCredit1_R.Text = "***";
                    txtCredit1_R.Tag = "***";
                }
            }
            catch
            {
                txtCredit1_R.Text = "***";
                txtCredit1_R.Tag = "***";
            }
        }
        private void txtCredit2_R_ButtonCustomClick(object sender, EventArgs e)
        {
            if (CmbUsers.SelectedIndex <= 0 || !ChkGaid.Checked)
            {
                return;
            }
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtCredit2_R.Tag = _AccDef.AccDef_No.ToString();
                    txtCredit2_R.Text = ((LangArEn == 0) ? _AccDef.Arb_Des : _AccDef.Eng_Des);
                }
                else
                {
                    txtCredit2_R.Text = "***";
                    txtCredit2_R.Tag = "***";
                }
            }
            catch
            {
                txtCredit2_R.Text = "***";
                txtCredit2_R.Tag = "***";
            }
        }
        private void txtCredit3_R_ButtonCustomClick(object sender, EventArgs e)
        {
            if (CmbUsers.SelectedIndex <= 0 || !ChkGaid.Checked)
            {
                return;
            }
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtCredit3_R.Tag = _AccDef.AccDef_No.ToString();
                    txtCredit3_R.Text = ((LangArEn == 0) ? _AccDef.Arb_Des : _AccDef.Eng_Des);
                }
                else
                {
                    txtCredit3_R.Text = "***";
                    txtCredit3_R.Tag = "***";
                }
            }
            catch
            {
                txtCredit3_R.Text = "***";
                txtCredit3_R.Tag = "***";
            }
        }
    }
}
