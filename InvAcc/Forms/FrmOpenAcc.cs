using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.Editors;
using Framework.Data;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Microsoft.Win32;
using SSSDateTime.Date;
using SSSLanguage;
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
    public partial  class FrmOpenAcc : Form
    { void avs(int arln)

{ 
}
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
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private List<T_INVSETTING> listInvSetting = new List<T_INVSETTING>();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private List<T_SYSSETTING> listSysSetting = new List<T_SYSSETTING>();
        private T_SYSSETTING _SysSetting = new T_SYSSETTING();
        private List<T_Company> listCompany = new List<T_Company>();
        private T_Company _Company = new T_Company();
        private List<T_GdAuto> listGdAuto = new List<T_GdAuto>();
        private T_GdAuto _GdAuto = new T_GdAuto();
        private List<T_InfoTb> listInfotb = new List<T_InfoTb>();
        private T_InfoTb _Infotb = new T_InfoTb();
        private int LangArEn = 0;
        private Stock_DataDataContext dbInstance;
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private T_GDHEAD data_this_GH;
        private T_GDDET data_this_GD;
        private ScriptNumber ScriptNumber1 = new ScriptNumber();
        public bool CanEdit = true;
        protected bool CanInsert = true;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
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
        private SuperTabControl superTabControl1;
        private ButtonItem ButWithSave;
        private ButtonItem ButWithoutSave;
        private SuperTabControlPanel superTabControlPanel5;
        private SuperTabItem superTabItem_General;
        private SuperGridControl DVG_ACC;
        private DoubleInput txtSumDebit;
        private DoubleInput txtSumCredit;
        private ComboBoxEx CmbPosting;
        private Label label3;
        private ComboBoxEx CmbCurr;
        private ButtonItem buttonItemDelete;
        private LabelItem labelItem1;
        private LabelItem labelItem2;
        internal Label label4;
        private MaskedTextBox txtGDate;
        private MaskedTextBox txtHDate;
        internal Label label1;
        internal Label label2;
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
        public T_GDHEAD DataThis_GH
        {
            get
            {
                return data_this_GH;
            }
            set
            {
                data_this_GH = value;
            }
        }
        public T_GDDET DataThis_GD
        {
            get
            {
                return data_this_GD;
            }
            set
            {
                data_this_GD = value;
            }
        }
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
        protected bool CanUpdate
        {
            get
            {
                return canUpdate;
            }
            set
            {
                canUpdate = value;
            }
        }
        public bool SetReadOnly
        {
            set
            {
                if (value)
                {
                    State = FormState.Saved;
                }
                ButWithSave.Enabled = !value;
            }
        }
        public FrmOpenAcc()
        {
            InitializeComponent();this.Load += langloads;
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
            {
                txtSumDebit.DisplayFormat = VarGeneral.DicemalMask;
                txtSumCredit.DisplayFormat = VarGeneral.DicemalMask;
            }
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
            if (e.KeyCode == Keys.F2)
            {
                ButWithSave_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmOpenAcc));
                if (base.Parent.RightToLeft == RightToLeft.Yes)
                {
                    Language.ChangeLanguage("ar-SA", this, resources);
                    LangArEn = 0;
                }
                else
                {
                    Language.ChangeLanguage("en", this, resources);
                    LangArEn = 1;
                }
            }
            FillCombo();
            BindData();
        }
        private void BindData()
        {
        }
        private bool ValidData()
        {
            DVG_ACC_EndEdit(null, null);
            if (txtSumCredit.Value != txtSumDebit.Value)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام العملية .. تاكد من ان إجمالي الدائن يساوي اجمالي المدين" : "You can not complete the process .. make sure that the total equals the total creditor debtor", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (txtSumCredit.Value == 0.0 || txtSumDebit.Value == 0.0 || txtSumCredit.Value == 0.0 || txtSumDebit.Value == 0.0 || txtSumCredit.Value == 0.0 || txtSumDebit.Value == 0.0)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ والصافي يساوي صفر" : "Can not save, and the total is equal to zero", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (false)
            {
#pragma warning disable CS0162 // Unreachable code detected
                Environment.Exit(0);
#pragma warning restore CS0162 // Unreachable code detected
                return false;
            }
            for (int i = 0; i < DVG_ACC.PrimaryGrid.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(DVG_ACC.PrimaryGrid.GetCell(i, 4).Value.ToString()))
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من تعبئة جميع البيانات المطلوبة" : "We must not be empty value .. Please make sure there are items in the bill.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
            }
            return true;
        }
        private bool CheckRemotDate()
        {
            try
            {
                if (VarGeneral.gUserName != "runsetting")
                {
                    bool User_Remotly = CheckUserIFRemote();
                    RegistryKey hKeyNew = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", writable: true);
                    RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
                    long regval = 0L;
                    long regvalNew = 0L;
                    if (hKey != null)
                    {
                        try
                        {
                            object q = hKey.GetValue("vRemotly");
                            if (string.IsNullOrEmpty(q.ToString()))
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
                            object t = hKeyNew.GetValue("vRemotly_New");
                            if (string.IsNullOrEmpty(t.ToString()))
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
                    if (User_Remotly || regval == 1 || regvalNew == 1)
                    {
                        try
                        {
                            if (VarGeneral.vDemo)
                            {
                                return false;
                            }
                            string dtAction = txtHDate.Text;
                            if (Convert.ToDateTime(n.GregToHijri(hKeyNew.GetValue("vBackup_New").ToString(), "yyyy/MM/dd")) < Convert.ToDateTime(n.FormatHijri(dtAction, "yyyy/MM/dd")))
                            {
                                MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. لقد تخطيت السنة المالية المحدد للنظام \n يرجى التواصل مع الإدارة لللإشتراك في خدمات النسخة " : "We can not complete the operation .. have you skip the fiscal year specified for the system", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return false;
                            }
                        }
                        catch
                        {
                            MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. لقد تخطيت السنة المالية المحدد للنظام \n يرجى التواصل مع الإدارة لللإشتراك في خدمات النسخة " : "We can not complete the operation .. have you skip the fiscal year specified for the system", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return false;
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        private bool CheckUserIFRemote()
        {
            try
            {
#pragma warning disable CS0162 // Unreachable code detected
                return false; if (SystemInformation.TerminalServerSession)
#pragma warning restore CS0162 // Unreachable code detected
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return true;
            }
        }
        private T_GDHEAD GetData()
        {
            data_this_GH.gdHDate = txtHDate.Text;
            data_this_GH.gdGDate = txtGDate.Text;
            data_this_GH.BName = data_this_GH.BName;
            data_this_GH.ChekNo = data_this_GH.ChekNo;
            data_this_GH.CurTyp = int.Parse(CmbCurr.SelectedValue.ToString());
            data_this_GH.ArbTaf = ScriptNumber1.ScriptNum(decimal.Parse(VarGeneral.TString.TEmpty(string.Concat(txtSumCredit.Value))));
            data_this_GH.EngTaf = ScriptNumber1.TafEng(decimal.Parse(VarGeneral.TString.TEmpty(string.Concat(txtSumCredit.Value))));
            data_this_GH.gdCstNo = 1;
            data_this_GH.gdID = 0;
            data_this_GH.gdLok = false;
            data_this_GH.AdminLock = false;
            data_this_GH.gdMem = ((LangArEn == 0) ? "الرصيد الإفتتاحي" : "Start Balance");
            data_this_GH.gdMnd = null;
            data_this_GH.gdRcptID = 0.0;
            data_this_GH.gdTot = txtSumCredit.Value;
            data_this_GH.gdTp = 0;
            data_this_GH.gdTyp = 11;
            data_this_GH.gdUser = VarGeneral.UserNumber;
            data_this_GH.gdUserNam = VarGeneral.UserNameA;
            data_this_GH.RefNo = string.Empty;
            data_this_GH.salMonth = "OpenGD";
            data_this_GH.CommMnd_Gaid = 0.0;
            data_this_GH.CompanyID = 1;
            return data_this_GH;
        }
        private bool SaveData()
        {
            try
            {
                if (!ValidData())
                {
                    return false;
                }
                IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
                data_this_GH = new T_GDHEAD();
                List<T_GDHEAD> data_this = (from er in db.T_GDHEADs
                                            where er.salMonth == "OpenGD"
                                            where er.gdLok == false
                                            where er.gdTyp == (int?)11
                                            orderby er.gdNo
                                            select er).ToList();
                if (data_this.Count > 0)
                {
                    data_this_GH = data_this.FirstOrDefault();
                    GetData();
                    db.Log = VarGeneral.DebugLog;
                    db.SubmitChanges(ConflictMode.ContinueOnConflict);
                    for (int i = 0; i < data_this_GH.T_GDDETs.Count; i++)
                    {
                        db_.StartTransaction();
                        db_.ClearParameters();
                        db_.AddParameter("GDDET_ID", DbType.Int32, data_this_GH.T_GDDETs[i].GDDET_ID);
                        db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_DELETE");
                        db_.EndTransaction();
                    }
                }
                else
                {
                    data_this_GH.gdNo = db.MaxGDHEADsNo.ToString();
                    GetData();
                    db.T_GDHEADs.InsertOnSubmit(data_this_GH);
                    db.SubmitChanges();
                }
                int vAutoNo = 0;
                for (int i = 0; i < DVG_ACC.PrimaryGrid.Rows.Count; i++)
                {
                    if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(DVG_ACC.PrimaryGrid.GetCell(i, 0).Value))) > 0.0)
                    {
                        vAutoNo++;
                        data_this_GD = new T_GDDET();
                        data_this_GD.gdID = data_this_GH.gdhead_ID;
                        data_this_GD.gdNo = data_this_GH.gdNo;
                        data_this_GD.gdDes = "الرصيد الإفتتاحي";
                        data_this_GD.gdDesE = "Start Balance";
                        data_this_GD.recptTyp = "11";
                        data_this_GD.AccNo = DVG_ACC.PrimaryGrid.GetCell(i, 4).Value.ToString();
                        data_this_GD.AccName = DVG_ACC.PrimaryGrid.GetCell(i, 3).Value.ToString();
                        data_this_GD.gdValue = 0.0 - double.Parse(VarGeneral.TString.TEmpty(string.Concat(DVG_ACC.PrimaryGrid.GetCell(i, 0).Value)));
                        data_this_GD.recptNo = "1";
                        data_this_GD.Lin = vAutoNo;
                        db.T_GDDETs.InsertOnSubmit(data_this_GD);
                        db.SubmitChanges();
                    }
                }
                for (int i = 0; i < DVG_ACC.PrimaryGrid.Rows.Count; i++)
                {
                    if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(DVG_ACC.PrimaryGrid.GetCell(i, 1).Value))) > 0.0)
                    {
                        vAutoNo++;
                        data_this_GD = new T_GDDET();
                        data_this_GD.gdID = data_this_GH.gdhead_ID;
                        data_this_GD.gdNo = data_this_GH.gdNo;
                        data_this_GD.gdDes = "الرصيد الإفتتاحي";
                        data_this_GD.gdDesE = "Start Balance";
                        data_this_GD.recptTyp = "11";
                        data_this_GD.AccNo = DVG_ACC.PrimaryGrid.GetCell(i, 4).Value.ToString();
                        data_this_GD.AccName = DVG_ACC.PrimaryGrid.GetCell(i, 3).Value.ToString();
                        data_this_GD.gdValue = double.Parse(VarGeneral.TString.TEmpty(string.Concat(DVG_ACC.PrimaryGrid.GetCell(i, 1).Value)));
                        data_this_GD.recptNo = "1";
                        data_this_GD.Lin = vAutoNo;
                        db.T_GDDETs.InsertOnSubmit(data_this_GD);
                        db.SubmitChanges();
                    }
                }
                MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                VarGeneral.DebLog.writeLog("SaveData:", ex, enable: true);
                return false;
            }
            return true;
        }
        private void FillCombo()
        {
            CmbPosting.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                CmbPosting.Items.Add("الكــل");
                CmbPosting.Items.Add("متاجرة");
                CmbPosting.Items.Add("أرباح وخسائر");
                CmbPosting.Items.Add("الميزانية العمومية");
            }
            else
            {
                CmbPosting.Items.Add("ALL");
                CmbPosting.Items.Add("Trading");
                CmbPosting.Items.Add("Profits and Losses");
                CmbPosting.Items.Add("General Budget");
            }
            CmbPosting.SelectedIndex = 0;
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                List<T_Curency> listAccCat = new List<T_Curency>(db.T_Curencies.Select((T_Curency item) => item).ToList());
                CmbCurr.DataSource = listAccCat;
                CmbCurr.DisplayMember = "Arb_Des";
                CmbCurr.ValueMember = "Curency_ID";
            }
            else
            {
                List<T_Curency> listCurr = new List<T_Curency>(db.T_Curencies.Select((T_Curency item) => item).ToList());
                CmbCurr.DataSource = listCurr;
                CmbCurr.DisplayMember = "Eng_Des";
                CmbCurr.ValueMember = "Curency_ID";
            }
            try
            {
                CmbCurr.SelectedValue = int.Parse(VarGeneral.Settings_Sys.ImportIp.ToString());
            }
            catch
            {
            }
            try
            {
                List<T_GDHEAD> qkeys = (from item in db.T_GDHEADs
                                        where item.gdTyp == (int?)11
                                        where item.gdLok == false
                                        where item.salMonth == "OpenGD"
                                        select item).ToList();
                if (qkeys.Count > 0)
                {
                    if (qkeys.FirstOrDefault().CurTyp.HasValue)
                    {
                        CmbCurr.SelectedValue = qkeys.FirstOrDefault().CurTyp.Value;
                    }
                    try
                    {
                        if (VarGeneral.CheckDate(qkeys.FirstOrDefault().gdGDate))
                        {
                            txtGDate.Text = Convert.ToDateTime(qkeys.FirstOrDefault().gdGDate).ToString("yyyy/MM/dd");
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        if (VarGeneral.CheckDate(qkeys.FirstOrDefault().gdHDate))
                        {
                            txtHDate.Text = Convert.ToDateTime(qkeys.FirstOrDefault().gdHDate).ToString("yyyy/MM/dd");
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
                try
                {
                    CmbCurr.SelectedValue = int.Parse(VarGeneral.Settings_Sys.ImportIp.ToString());
                }
                catch
                {
                }
            }
            RibunButtons();
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                ButWithSave.Text = "حفظ";
                ButWithSave.Tooltip = "F2";
                ButWithoutSave.Text = "خروج";
                ButWithoutSave.Tooltip = "Esc";
                superTabItem_General.Text = "الحسابات المالية";
                Text = "الأرصدة الإفتتاحية";
            }
            else
            {
                ButWithSave.Text = "Save";
                ButWithoutSave.Text = "Exit";
                ButWithSave.Tooltip = "F2";
                ButWithoutSave.Tooltip = "Esc";
                superTabItem_General.Text = "Accounting";
                buttonItemDelete.Text = "DELETE";
                Text = "Open Balances";
            }
        }
        private void SettingGridLate()
        {
            DVG_ACC.PrimaryGrid.Columns[0].HeaderText = ((LangArEn == 0) ? "الــدائن" : "Credit");
            DVG_ACC.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "المــدين" : "Debit");
            DVG_ACC.PrimaryGrid.Columns[2].HeaderText = ((LangArEn == 0) ? "المستوى" : "Level");
            DVG_ACC.PrimaryGrid.Columns[3].HeaderText = ((LangArEn == 0) ? "إسم الحساب" : "Account Name");
            DVG_ACC.PrimaryGrid.Columns[4].HeaderText = ((LangArEn == 0) ? "رقم الحساب" : "Account No");
        }
        private void FrmOpenAcc_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmOpenAcc));
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
                txtGDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                txtHDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                FillCombo();
                SettingGridLate();
                CmbPosting_SelectedIndexChanged(sender, e);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            label1.Left = txtSumDebit.Left;
            label2.Left = txtSumCredit.Left;
        }
        private void ButWithSave_Click(object sender, EventArgs e)
        {
            GridPanel panel = DVG_ACC.PrimaryGrid;
            foreach (GridColumn column in panel.Columns)
            {
                column.FilterExpr = null;
            }
            if (SaveData())
            {
                Close();
            }
        }
        private void ButWithoutSave_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void textbox_Arb_Des_Enter(object sender, EventArgs e)
        {
            Language.Switch("AR");
        }
        private void textbox_Eng_Des_Enter(object sender, EventArgs e)
        {
            Language.Switch("EN");
        }
        private void txtHeadingR3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b')) && e.KeyChar != '-' && e.KeyChar != '\\')
            {
                e.Handled = true;
            }
        }
        private void Button_Edit_Click(object sender, EventArgs e)
        {
            if (CanEdit && State != FormState.Edit && State != FormState.New)
            {
                if (State != FormState.New)
                {
                    State = FormState.Edit;
                }
                SetReadOnly = false;
            }
        }
        private void CmbPosting_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<T_AccDef> list = db.FillAccDef_2(string.Empty).ToList();
            list = list.Where((T_AccDef q) => (CmbPosting.SelectedIndex <= 0 || q.Trn == CmbPosting.SelectedIndex) && q.Lev == 4).ToList();
            try
            {
                DVG_ACC.PrimaryGrid.Rows.Clear();
            }
            catch
            {
            }
            if (list.Count > 14)
            {
                base.Width = 674;
            }
            else
            {
                base.Width = 656;
            }
            for (int i = 0; i < list.Count; i++)
            {
                GridRow row = new GridRow();
                row.Cells.Add(new GridCell(string.Empty));
                row.Cells.Add(new GridCell(string.Empty));
                row.Cells.Add(new GridCell(string.Empty));
                row.Cells.Add(new GridCell(string.Empty));
                row.Cells.Add(new GridCell(string.Empty));
                row.Cells.Add(new GridCell(string.Empty));
                row.Cells[4].Value = list[i].AccDef_No;
                row.Cells[3].Value = ((LangArEn == 0) ? list[i].Arb_Des : list[i].Eng_Des);
                row.Cells[2].Value = list[i].Lev.Value;
                row.Cells[1].Value = db.OpenAccDebit(list[i].AccDef_No);
                row.Cells[0].Value = Math.Abs(db.OpenAccCredit(list[i].AccDef_No));
                DVG_ACC.PrimaryGrid.Rows.Add(row);
            }
            txtSumCredit.Value = CellSum(0);
            txtSumDebit.Value = CellSum(1);
        }
        private double CellSum(int col)
        {
            double sum = 0.0;
            for (int i = 0; i < DVG_ACC.PrimaryGrid.Rows.Count; i++)
            {
                double d = 0.0;
                d = double.Parse(DVG_ACC.PrimaryGrid.GetCell(i, col).Value.ToString());
                sum += d;
            }
            return Math.Round(sum, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
        }
        private void DVG_ACC_EndEdit(object sender, GridEditEventArgs e)
        {
            txtSumCredit.Value = CellSum(0);
            txtSumDebit.Value = CellSum(1);
        }
        private void buttonItemDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل أنت متاكد من حذف السجل ؟ \n Are you sure that you want to delete the record?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            List<T_GDHEAD> q = (from t in db.T_GDHEADs
                                where t.salMonth == "OpenGD"
                                where t.gdTyp == (int?)11
                                where t.gdLok == false
                                orderby t.gdNo
                                select t).ToList();
            if (q.Count > 0 && q != null && !(q.FirstOrDefault().gdNo == 0.ToString()))
            {
                for (int i = 0; i < q.FirstOrDefault().T_GDDETs.Count; i++)
                {
                    db.ExecuteCommand("DELETE FROM [dbo].[T_GDDET] WHERE gdID = " + q.FirstOrDefault().gdhead_ID);
                }
                try
                {
                    db.T_GDHEADs.DeleteOnSubmit(q.FirstOrDefault());
                    db.SubmitChanges();
                }
                catch (SqlException)
                {
                    return;
                }
                Close();
            }
        }
        private void txtGDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtGDate.Text))
                {
                    txtGDate.Text = Convert.ToDateTime(txtGDate.Text).ToString("yyyy/MM/dd");
                    txtGDate.Text = n.FormatGreg(txtGDate.Text, "yyyy/MM/dd");
                    txtHDate.Text = n.GregToHijri(txtGDate.Text, "yyyy/MM/dd");
                }
                else
                {
                    txtGDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                }
            }
            catch
            {
                txtGDate.Text = string.Empty;
            }
        }
        private void txtGDate_Click(object sender, EventArgs e)
        {
            txtGDate.SelectAll();
        }
        private void txtHDate_Click(object sender, EventArgs e)
        {
            txtHDate.SelectAll();
        }
        private void txtHDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtHDate.Text))
                {
                    txtHDate.Text = Convert.ToDateTime(txtHDate.Text).ToString("yyyy/MM/dd");
                    txtHDate.Text = n.FormatHijri(txtHDate.Text, "yyyy/MM/dd");
                    txtGDate.Text = n.HijriToGreg(txtHDate.Text, "yyyy/MM/dd");
                }
                else
                {
                    txtHDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                }
            }
            catch
            {
                txtHDate.Text = string.Empty;
            }
        }
    }
}
