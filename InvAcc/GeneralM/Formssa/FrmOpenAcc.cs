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
    public partial class FrmOpenAcc : Form
    {
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
            InitializeComponent();
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
                Environment.Exit(0);
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
                return false; if (SystemInformation.TerminalServerSession)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmOpenAcc));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();

            components = new System.ComponentModel.Container();

            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background2 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            superTabControlPanel5 = new DevComponents.DotNetBar.SuperTabControlPanel();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            txtGDate = new System.Windows.Forms.MaskedTextBox();
            txtHDate = new System.Windows.Forms.MaskedTextBox();
            CmbCurr = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            label3 = new System.Windows.Forms.Label();
            txtSumCredit = new DevComponents.Editors.DoubleInput();
            txtSumDebit = new DevComponents.Editors.DoubleInput();
            DVG_ACC = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            CmbPosting = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            superTabItem_General = new DevComponents.DotNetBar.SuperTabItem();
            ButWithSave = new DevComponents.DotNetBar.ButtonItem();
            labelItem2 = new DevComponents.DotNetBar.LabelItem();
            ButWithoutSave = new DevComponents.DotNetBar.ButtonItem();
            labelItem1 = new DevComponents.DotNetBar.LabelItem();
            buttonItemDelete = new DevComponents.DotNetBar.ButtonItem();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();

            ribbonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)superTabControl1).BeginInit();
            superTabControl1.SuspendLayout();
            superTabControlPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtSumCredit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtSumDebit).BeginInit();
            SuspendLayout();
            ribbonBar1.AccessibleDescription = null;
            ribbonBar1.AccessibleName = null;
            resources.ApplyResources(ribbonBar1, "ribbonBar1");
            ribbonBar1.AutoOverflowEnabled = true;
            ribbonBar1.BackgroundImage = null;
            ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.ContainerControlProcessDialogKey = true;
            ribbonBar1.Controls.Add(superTabControl1);
            ribbonBar1.Font = null;
            ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            ribbonBar1.Name = "ribbonBar1";
            ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            superTabControl1.AccessibleDescription = null;
            superTabControl1.AccessibleName = null;
            resources.ApplyResources(superTabControl1, "superTabControl1");
            superTabControl1.BackColor = System.Drawing.Color.White;
            superTabControl1.BackgroundImage = null;
            superTabControl1.ControlBox.Category = null;
            superTabControl1.ControlBox.CloseBox.Category = null;
            superTabControl1.ControlBox.CloseBox.CommandParameter = null;
            superTabControl1.ControlBox.CloseBox.Description = null;
            superTabControl1.ControlBox.CloseBox.Name = string.Empty;
            superTabControl1.ControlBox.CloseBox.Tag = null;
            superTabControl1.ControlBox.CloseBox.Text = resources.GetString("superTabControl1.ControlBox.CloseBox.Text");
            superTabControl1.ControlBox.CloseBox.Tooltip = resources.GetString("superTabControl1.ControlBox.CloseBox.Tooltip");
            superTabControl1.ControlBox.CommandParameter = null;
            superTabControl1.ControlBox.Description = null;
            superTabControl1.ControlBox.MenuBox.Category = null;
            superTabControl1.ControlBox.MenuBox.CommandParameter = null;
            superTabControl1.ControlBox.MenuBox.Description = null;
            superTabControl1.ControlBox.MenuBox.Name = string.Empty;
            superTabControl1.ControlBox.MenuBox.Tag = null;
            superTabControl1.ControlBox.MenuBox.Text = resources.GetString("superTabControl1.ControlBox.MenuBox.Text");
            superTabControl1.ControlBox.MenuBox.Tooltip = resources.GetString("superTabControl1.ControlBox.MenuBox.Tooltip");
            superTabControl1.ControlBox.Name = string.Empty;
            superTabControl1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[2]
            {
                superTabControl1.ControlBox.MenuBox,
                superTabControl1.ControlBox.CloseBox
            });
            superTabControl1.ControlBox.Tag = null;
            superTabControl1.ControlBox.Text = resources.GetString("superTabControl1.ControlBox.Text");
            superTabControl1.ControlBox.Tooltip = resources.GetString("superTabControl1.ControlBox.Tooltip");
            superTabControl1.ControlBox.Visible = false;
            superTabControl1.Controls.Add(superTabControlPanel5);
            superTabControl1.Font = null;
            superTabControl1.ForeColor = System.Drawing.Color.Black;
            superTabControl1.Name = "superTabControl1";
            superTabControl1.ReorderTabsEnabled = true;
            superTabControl1.SelectedTabIndex = 0;
            superTabControl1.TabHorizontalSpacing = 40;
            superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[6]
            {
                superTabItem_General,
                ButWithSave,
                labelItem2,
                ButWithoutSave,
                labelItem1,
                buttonItemDelete
            });
            superTabControl1.TabVerticalSpacing = 8;
            superTabControl1.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            superTabControlPanel5.AccessibleDescription = null;
            superTabControlPanel5.AccessibleName = null;
            resources.ApplyResources(superTabControlPanel5, "superTabControlPanel5");
            superTabControlPanel5.BackgroundImage = null;
            superTabControlPanel5.Controls.Add(label2);
            superTabControlPanel5.Controls.Add(label1);
            superTabControlPanel5.Controls.Add(label4);
            superTabControlPanel5.Controls.Add(txtGDate);
            superTabControlPanel5.Controls.Add(txtHDate);
            superTabControlPanel5.Controls.Add(CmbCurr);
            superTabControlPanel5.Controls.Add(label3);
            superTabControlPanel5.Controls.Add(txtSumCredit);
            superTabControlPanel5.Controls.Add(txtSumDebit);
            superTabControlPanel5.Controls.Add(DVG_ACC);
            superTabControlPanel5.Controls.Add(CmbPosting);
            superTabControlPanel5.Font = null;
            superTabControlPanel5.Name = "superTabControlPanel5";
            superTabControlPanel5.TabItem = superTabItem_General;
            label2.AccessibleDescription = null;
            label2.AccessibleName = null;
            resources.ApplyResources(label2, "label2");
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label2.Name = "label2";
            label1.AccessibleDescription = null;
            label1.AccessibleName = null;
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label1.Name = "label1";
            label4.AccessibleDescription = null;
            label4.AccessibleName = null;
            resources.ApplyResources(label4, "label4");
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label4.Name = "label4";
            txtGDate.AccessibleDescription = null;
            txtGDate.AccessibleName = null;
            resources.ApplyResources(txtGDate, "txtGDate");
            txtGDate.BackColor = System.Drawing.Color.WhiteSmoke;
            txtGDate.BackgroundImage = null;
            txtGDate.Name = "txtGDate";
            txtGDate.Leave += new System.EventHandler(txtGDate_Leave);
            txtGDate.Click += new System.EventHandler(txtGDate_Click);
            txtHDate.AccessibleDescription = null;
            txtHDate.AccessibleName = null;
            resources.ApplyResources(txtHDate, "txtHDate");
            txtHDate.BackColor = System.Drawing.Color.WhiteSmoke;
            txtHDate.BackgroundImage = null;
            txtHDate.Name = "txtHDate";
            txtHDate.Leave += new System.EventHandler(txtHDate_Leave);
            txtHDate.Click += new System.EventHandler(txtHDate_Click);
            CmbCurr.AccessibleDescription = null;
            CmbCurr.AccessibleName = null;
            resources.ApplyResources(CmbCurr, "CmbCurr");
            CmbCurr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            CmbCurr.BackgroundImage = null;
            CmbCurr.CommandParameter = null;
            CmbCurr.DisplayMember = "Text";
            CmbCurr.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            CmbCurr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CmbCurr.Font = null;
            CmbCurr.FormattingEnabled = true;
            CmbCurr.Name = "CmbCurr";
            CmbCurr.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            label3.AccessibleDescription = null;
            label3.AccessibleName = null;
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            txtSumCredit.AccessibleDescription = null;
            txtSumCredit.AccessibleName = null;
            resources.ApplyResources(txtSumCredit, "txtSumCredit");
            txtSumCredit.BackgroundImage = null;
            txtSumCredit.BackgroundStyle.Class = "DateTimeInputBackground";
            txtSumCredit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            txtSumCredit.ButtonCalculator.DisplayPosition = (int)resources.GetObject("txtSumCredit.ButtonCalculator.DisplayPosition");
            txtSumCredit.ButtonCalculator.Image = null;
            txtSumCredit.ButtonCalculator.Text = resources.GetString("txtSumCredit.ButtonCalculator.Text");
            txtSumCredit.ButtonClear.DisplayPosition = (int)resources.GetObject("txtSumCredit.ButtonClear.DisplayPosition");
            txtSumCredit.ButtonClear.Image = null;
            txtSumCredit.ButtonClear.Text = resources.GetString("txtSumCredit.ButtonClear.Text");
            txtSumCredit.ButtonCustom.DisplayPosition = (int)resources.GetObject("txtSumCredit.ButtonCustom.DisplayPosition");
            txtSumCredit.ButtonCustom.Image = null;
            txtSumCredit.ButtonCustom.Text = resources.GetString("txtSumCredit.ButtonCustom.Text");
            txtSumCredit.ButtonCustom2.DisplayPosition = (int)resources.GetObject("txtSumCredit.ButtonCustom2.DisplayPosition");
            txtSumCredit.ButtonCustom2.Image = null;
            txtSumCredit.ButtonCustom2.Text = resources.GetString("txtSumCredit.ButtonCustom2.Text");
            txtSumCredit.ButtonDropDown.DisplayPosition = (int)resources.GetObject("txtSumCredit.ButtonDropDown.DisplayPosition");
            txtSumCredit.ButtonDropDown.Image = null;
            txtSumCredit.ButtonDropDown.Text = resources.GetString("txtSumCredit.ButtonDropDown.Text");
            txtSumCredit.ButtonFreeText.DisplayPosition = (int)resources.GetObject("txtSumCredit.ButtonFreeText.DisplayPosition");
            txtSumCredit.ButtonFreeText.Image = null;
            txtSumCredit.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            txtSumCredit.ButtonFreeText.Text = resources.GetString("txtSumCredit.ButtonFreeText.Text");
            txtSumCredit.CommandParameter = null;
            txtSumCredit.DisplayFormat = "0.00";
            txtSumCredit.ForeColor = System.Drawing.Color.Maroon;
            txtSumCredit.Increment = 1.0;
            txtSumCredit.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            txtSumCredit.IsInputReadOnly = true;
            txtSumCredit.Name = "txtSumCredit";
            txtSumDebit.AccessibleDescription = null;
            txtSumDebit.AccessibleName = null;
            resources.ApplyResources(txtSumDebit, "txtSumDebit");
            txtSumDebit.BackgroundImage = null;
            txtSumDebit.BackgroundStyle.Class = "DateTimeInputBackground";
            txtSumDebit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            txtSumDebit.ButtonCalculator.DisplayPosition = (int)resources.GetObject("txtSumDebit.ButtonCalculator.DisplayPosition");
            txtSumDebit.ButtonCalculator.Image = null;
            txtSumDebit.ButtonCalculator.Text = resources.GetString("txtSumDebit.ButtonCalculator.Text");
            txtSumDebit.ButtonClear.DisplayPosition = (int)resources.GetObject("txtSumDebit.ButtonClear.DisplayPosition");
            txtSumDebit.ButtonClear.Image = null;
            txtSumDebit.ButtonClear.Text = resources.GetString("txtSumDebit.ButtonClear.Text");
            txtSumDebit.ButtonCustom.DisplayPosition = (int)resources.GetObject("txtSumDebit.ButtonCustom.DisplayPosition");
            txtSumDebit.ButtonCustom.Image = null;
            txtSumDebit.ButtonCustom.Text = resources.GetString("txtSumDebit.ButtonCustom.Text");
            txtSumDebit.ButtonCustom2.DisplayPosition = (int)resources.GetObject("txtSumDebit.ButtonCustom2.DisplayPosition");
            txtSumDebit.ButtonCustom2.Image = null;
            txtSumDebit.ButtonCustom2.Text = resources.GetString("txtSumDebit.ButtonCustom2.Text");
            txtSumDebit.ButtonDropDown.DisplayPosition = (int)resources.GetObject("txtSumDebit.ButtonDropDown.DisplayPosition");
            txtSumDebit.ButtonDropDown.Image = null;
            txtSumDebit.ButtonDropDown.Text = resources.GetString("txtSumDebit.ButtonDropDown.Text");
            txtSumDebit.ButtonFreeText.DisplayPosition = (int)resources.GetObject("txtSumDebit.ButtonFreeText.DisplayPosition");
            txtSumDebit.ButtonFreeText.Image = null;
            txtSumDebit.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            txtSumDebit.ButtonFreeText.Text = resources.GetString("txtSumDebit.ButtonFreeText.Text");
            txtSumDebit.CommandParameter = null;
            txtSumDebit.DisplayFormat = "0.00";
            txtSumDebit.ForeColor = System.Drawing.Color.Maroon;
            txtSumDebit.Increment = 1.0;
            txtSumDebit.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            txtSumDebit.IsInputReadOnly = true;
            txtSumDebit.Name = "txtSumDebit";
            txtSumDebit.UseWaitCursor = true;
            DVG_ACC.AccessibleDescription = null;
            DVG_ACC.AccessibleName = null;
            resources.ApplyResources(DVG_ACC, "DVG_ACC");
            DVG_ACC.BackgroundImage = null;
            DVG_ACC.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            DVG_ACC.Font = null;
            DVG_ACC.HScrollBarVisible = false;
            DVG_ACC.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            DVG_ACC.Name = "DVG_ACC";
            gridColumn1.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.None;
            gridColumn1.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl);
            gridColumn1.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            gridColumn1.FilterAutoScan = true;
            gridColumn1.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.Wildcards;
            gridColumn1.HeaderText = null;
            gridColumn1.Name = string.Empty;
            gridColumn1.Width = 110;
            gridColumn2.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.None;
            gridColumn2.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn2.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl);
            gridColumn2.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            gridColumn2.FilterAutoScan = true;
            gridColumn2.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.Wildcards;
            gridColumn2.HeaderText = null;
            gridColumn2.Name = string.Empty;
            gridColumn2.Width = 110;
            gridColumn3.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.None;
            gridColumn3.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn3.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            gridColumn3.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            gridColumn3.FilterAutoScan = true;
            gridColumn3.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.Wildcards;
            gridColumn3.HeaderText = null;
            gridColumn3.Name = string.Empty;
            gridColumn3.ReadOnly = true;
            gridColumn3.Visible = false;
            gridColumn3.Width = 60;
            gridColumn4.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.None;
            gridColumn4.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn4.CellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            gridColumn4.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            gridColumn4.FilterAutoScan = true;
            gridColumn4.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            gridColumn4.HeaderText = null;
            gridColumn4.Name = string.Empty;
            gridColumn4.ReadOnly = true;
            gridColumn4.Width = 280;
            gridColumn5.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.None;
            gridColumn5.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn5.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            gridColumn5.FilterAutoScan = true;
            gridColumn5.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.Wildcards;
            gridColumn5.HeaderText = null;
            gridColumn5.Name = string.Empty;
            gridColumn5.ReadOnly = true;
            gridColumn5.Width = 110;
            DVG_ACC.PrimaryGrid.Columns.Add(gridColumn1);
            DVG_ACC.PrimaryGrid.Columns.Add(gridColumn2);
            DVG_ACC.PrimaryGrid.Columns.Add(gridColumn3);
            DVG_ACC.PrimaryGrid.Columns.Add(gridColumn4);
            DVG_ACC.PrimaryGrid.Columns.Add(gridColumn5);
            DVG_ACC.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            DVG_ACC.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            background1.Color1 = System.Drawing.SystemColors.ActiveCaption;
            background1.Color2 = System.Drawing.SystemColors.GradientInactiveCaption;
            DVG_ACC.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.Background = background1;
            background2.Color1 = System.Drawing.SystemColors.ActiveCaption;
            DVG_ACC.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Background = background2;
            DVG_ACC.PrimaryGrid.EnableColumnFiltering = true;
            DVG_ACC.PrimaryGrid.EnableFiltering = true;
            DVG_ACC.PrimaryGrid.EnableRowFiltering = true;
            DVG_ACC.PrimaryGrid.Filter.Visible = true;
            DVG_ACC.PrimaryGrid.ShowRowGridIndex = true;
            DVG_ACC.PrimaryGrid.UseAlternateColumnStyle = true;
            DVG_ACC.SizingStyle = DevComponents.DotNetBar.SuperGrid.Style.StyleType.NotSelectable;
            DVG_ACC.EndEdit += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridEditEventArgs>(DVG_ACC_EndEdit);
            CmbPosting.AccessibleDescription = null;
            CmbPosting.AccessibleName = null;
            resources.ApplyResources(CmbPosting, "CmbPosting");
            CmbPosting.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            CmbPosting.BackgroundImage = null;
            CmbPosting.CommandParameter = null;
            CmbPosting.DisplayMember = "Text";
            CmbPosting.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            CmbPosting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CmbPosting.Font = null;
            CmbPosting.FormattingEnabled = true;
            CmbPosting.Name = "CmbPosting";
            CmbPosting.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            CmbPosting.SelectedIndexChanged += new System.EventHandler(CmbPosting_SelectedIndexChanged);
            superTabItem_General.AttachedControl = superTabControlPanel5;
            resources.ApplyResources(superTabItem_General, "superTabItem_General");
            superTabItem_General.CommandParameter = null;
            superTabItem_General.GlobalItem = false;
            superTabItem_General.Name = "superTabItem_General";
            resources.ApplyResources(ButWithSave, "ButWithSave");
            ButWithSave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            ButWithSave.Checked = true;
            ButWithSave.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            ButWithSave.CommandParameter = null;
            ButWithSave.FontBold = true;
            ButWithSave.Name = "ButWithSave";
            ButWithSave.Stretch = true;
            ButWithSave.Symbol = "\uf00c";
            ButWithSave.SymbolSize = 8f;
            ButWithSave.Click += new System.EventHandler(ButWithSave_Click);
            resources.ApplyResources(labelItem2, "labelItem2");
            labelItem2.CommandParameter = null;
            labelItem2.Name = "labelItem2";
            resources.ApplyResources(ButWithoutSave, "ButWithoutSave");
            ButWithoutSave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            ButWithoutSave.Checked = true;
            ButWithoutSave.CommandParameter = null;
            ButWithoutSave.FontBold = true;
            ButWithoutSave.Name = "ButWithoutSave";
            ButWithoutSave.Stretch = true;
            ButWithoutSave.Symbol = "\uf00d";
            ButWithoutSave.SymbolSize = 8f;
            ButWithoutSave.Click += new System.EventHandler(ButWithoutSave_Click);
            resources.ApplyResources(labelItem1, "labelItem1");
            labelItem1.CommandParameter = null;
            labelItem1.Name = "labelItem1";
            resources.ApplyResources(buttonItemDelete, "buttonItemDelete");
            buttonItemDelete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            buttonItemDelete.Checked = true;
            buttonItemDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            buttonItemDelete.CommandParameter = null;
            buttonItemDelete.FontBold = true;
            buttonItemDelete.Name = "buttonItemDelete";
            buttonItemDelete.Stretch = true;
            buttonItemDelete.Symbol = "\uf014";
            buttonItemDelete.SymbolSize = 12f;
            buttonItemDelete.Visible = false;
            buttonItemDelete.Click += new System.EventHandler(buttonItemDelete_Click);
            base.AccessibleDescription = null;
            base.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImage = null;
            base.Controls.Add(ribbonBar1);
            Font = null;
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.Name = "FrmOpenAcc";
            base.Load += new System.EventHandler(FrmOpenAcc_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Frm_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(Frm_KeyDown);
            ribbonBar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)superTabControl1).EndInit();
            superTabControl1.ResumeLayout(false);
            superTabControlPanel5.ResumeLayout(false);
            superTabControlPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtSumCredit).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtSumDebit).EndInit();
            ResumeLayout(false);
        }
    }
}
