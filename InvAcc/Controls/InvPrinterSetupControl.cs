using Framework.UI;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Controls
{
    public partial class InvPrinterSetupControl : UserControl
    {
        public InvPrinterSetupControl(int _typ)
        {
            InitializeComponent();
            _SettingType = _typ;
            txtBottM.Click += Button_Edit_Click;
            txtDistance.Click += Button_Edit_Click;
            txtLeftM.Click += Button_Edit_Click;
            txtLinePage.Click += Button_Edit_Click;
            txtpageCount.Click += Button_Edit_Click;
            txtRight.Click += Button_Edit_Click;
            txtTopM.Click += Button_Edit_Click;
            chk_Stoped.Click += Button_Edit_Click;
            checkBox_WaiterAll.Click += Button_Edit_Click;
            txtDistance.Click += Button_Edit_Click;
            textBox_CachierTxtA.Click += Button_Edit_Click;
            textBox_CachierTxtE.Click += Button_Edit_Click;
            checkBox_previewPrint.Click += Button_Edit_Click;
            RButLandscape.Click += Button_Edit_Click;
            RButPortrait.Click += Button_Edit_Click;
            CmbInvType.Click += Button_Edit_Click;
            CmbPaperSize.Click += Button_Edit_Click;
            CmbPrinter.Click += Button_Edit_Click;
            listInvSetting = db.StockInvSettingList(VarGeneral.UserID);
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptInvitationCards.dll"))
            {
                listInvSetting = db.T_INVSETTINGs.Where((T_INVSETTING t) => t.InvID == 1 || t.InvID == 8).ToList();
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptSchool.dll"))
            {
                listInvSetting = db.T_INVSETTINGs.Where((T_INVSETTING t) => t.InvID == 1 || t.InvID == 2 || t.InvID == 3 || t.InvID == 4 || t.InvID == 7 || t.InvID == 8 || t.InvID == 9 || t.InvID == 10 || t.InvID == 14).ToList();
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptMaintenanceCars.dll"))
            {
                listInvSetting = db.T_INVSETTINGs.Where((T_INVSETTING t) => t.InvID == 1 || t.InvID == 2 || t.InvID == 3 || t.InvID == 4 || t.InvID == 7).ToList();
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptTegnicalCollage.dll"))
            {
                listInvSetting = db.T_INVSETTINGs.Where((T_INVSETTING t) => t.InvID == 2 || t.InvID == 4 || t.InvID == 9 || t.InvID == 10 || t.InvID == 14 || t.InvID == 17 || t.InvID == 20).ToList();
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptWaterPackages.dll"))
            {
                listInvSetting = db.T_INVSETTINGs.Where((T_INVSETTING t) => t.InvID == 1 || t.InvID == 2 || t.InvID == 3 || t.InvID == 4 || t.InvID == 5 || t.InvID == 6 || t.InvID == 7 || t.InvID == 8 || t.InvID == 9 || t.InvID == 10 || t.InvID == 14).ToList();
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(InvPrinterSetupControl));
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
                chk_Stoped.OnText = ((LangArEn == 0) ? "طابعات التصنيفات فقط" : "Catogaries Printers Only");
                chk_Stoped.OffText = ((LangArEn == 0) ? "طابعة الكاشيير فقط" : "Cashier Printer Only");
                FillCombo();
                BindData();
                if (VarGeneral.vDemo && VarGeneral.UserID != 1)
                {
                    checkBox_previewPrint.Visible = false;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("OnLoad:", error, enable: true);
                MessageBox.Show(error.Message);
            }
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
        private class Item
        {
            public string Name;
            public int Value;
            public Item(string name, int value)
            {
                Name = name;
                Value = value;
            }
            public override string ToString()
            {
                return Name;
            }
        }
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private List<T_INVSETTING> listInvSetting = new List<T_INVSETTING>();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private Item _item = new Item(string.Empty, 0);
        private int LangArEn = 0;
        private Stock_DataDataContext dbInstance;
        private int _SettingType = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
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
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                ButWithSave.Text = "حفــــظ F2";
                ButWithoutSave.Text = "خــــروج Esc";
                labelX1.Text = ((_SettingType == 0) ? "إعدادات طباعة الفواتير" : "إعدادات طباعة التصنيفــات");
            }
            else
            {
                ButWithSave.Text = "Save F2";
                ButWithoutSave.Text = "Exit Esc";
                labelX1.Text = ((_SettingType == 0) ? "Invoice Printer Setting" : "Categories Printer Setting");
            }
        }
        private void BindData()
        {
            try
            {
                State = FormState.Saved;
                ButWithSave.Enabled = false;
                _item = (Item)CmbInvType.SelectedItem;
                for (int iiCnt = 0; iiCnt < listInvSetting.Count; iiCnt++)
                {
                    _InvSetting = listInvSetting[iiCnt];
                    if (_item.Value != _InvSetting.InvID)
                    {
                        continue;
                    }
                    chk_Stoped.Value = false;
                    checkBox_WaiterAll.Checked = false;
                    if (_InvSetting.InvpRINTERInfo.nTyp.Substring(0, 1) == "0")
                    {
                        ChkPTable.Checked = false;
                    }
                    else
                    {
                        ChkPTable.Checked = true;
                    }
                    if (_InvSetting.InvpRINTERInfo.ISCashierType)
                    {
                        RedButPaperA4.Checked = false;
                        RedButCasher.Checked = true;
                    }
                    else
                    {
                        RedButPaperA4.Checked = true;
                        RedButCasher.Checked = false;
                    }
                    if (_InvSetting.ISdirectPrinting)
                    {
                        checkBox_previewPrint.Checked = false;
                    }
                    else
                    {
                        checkBox_previewPrint.Checked = true;
                    }
                    txtBottM.Text = _InvSetting.InvpRINTERInfo.hAs.ToString();
                    txtLeftM.Text = _InvSetting.InvpRINTERInfo.hYs.ToString();
                    txtLinePage.Value = (int)_InvSetting.InvpRINTERInfo.lnPg.Value;
                    if (txtLinePage.Value <= 0)
                    {
                        txtLinePage.LockUpdateChecked = false;
                    }
                    else
                    {
                        txtLinePage.LockUpdateChecked = true;
                    }
                    txtRight.Text = _InvSetting.InvpRINTERInfo.hYm.ToString();
                    txtTopM.Text = _InvSetting.InvpRINTERInfo.hAl.ToString();
                    txtDistance.Text = _InvSetting.InvpRINTERInfo.lnSpc.ToString();
                    textBox_CachierTxtA.Text = _InvSetting.invGdADesc;
                    textBox_CachierTxtE.Text = _InvSetting.invGdEDesc;
                    CmbPrinter.Text = _InvSetting.defPrn;
                    txtpageCount.Value = _InvSetting.InvpRINTERInfo.DefLines.Value;
                    try
                    {
                        chk_Stoped.Value = _InvSetting.PrintCat.Value;
                    }
                    catch
                    {
                        chk_Stoped.Value = true;
                    }
                    if (!string.IsNullOrEmpty(_InvSetting.defSizePaper))
                    {
                        CmbPaperSize.Items.Clear();
                        CmbPaperSize.Items.Add(_InvSetting.defSizePaper);
                        CmbPaperSize.SelectedIndex = 0;
                    }
                    else
                    {
                        CmbPaperSize.Items.Clear();
                    }
                    if (_InvSetting.Orientation.Value == 1)
                    {
                        RButPortrait.Checked = true;
                    }
                    else
                    {
                        RButLandscape.Checked = true;
                    }
                    if (_InvSetting.InvID == 21)
                    {
                        ChkPTable.Visible = false;
                        chk_Stoped.Visible = true;
                        checkBox_WaiterAll.Visible = true;
                        try
                        {
                            if (checkBox_WaiterAll.Visible)
                            {
                                checkBox_WaiterAll.Checked = _InvSetting.autoCommGaid.Value;
                            }
                            else
                            {
                                checkBox_WaiterAll.Checked = false;
                            }
                        }
                        catch
                        {
                            checkBox_WaiterAll.Checked = false;
                        }
                    }
                    else
                    {
                        ChkPTable.Visible = true;
                        chk_Stoped.Visible = false;
                        checkBox_WaiterAll.Visible = false;
                    }
                    break;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("BindData:", error, enable: true);
            }
            if (_SettingType == 1)
            {
                ChkPTable.Visible = false;
                label8.Text = ((LangArEn == 0) ? "التصنيفات :" : "Categories :");
                chk_Stoped.OnText = ((LangArEn == 0) ? "إيقاف الطباعة" : "Printing Stoped");
                chk_Stoped.OffText = ((LangArEn == 0) ? "إيقاف الطباعة" : "Printing Stoped");
                checkBox_previewPrint.Visible = false;
                chk_Stoped.Visible = true;
                if (db.StockInvSetting( 1).ISdirectPrinting)
                {
                    groupBox_PrintType.Visible = false;
                    picture_SSS.Visible = true;
                }
            }
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(InvPrinterSetupControl));
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
            FillCombo();
            BindData();
        }
        private void FillCombo()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                CmbPrinter.Items.Clear();
                CmbPrinter.Items.Add(" ");
                PrinterSettings PrintS = new PrinterSettings();
                if (PrinterSettings.InstalledPrinters.Count != 0)
                {
                    for (int iiCnt = 0; iiCnt < PrinterSettings.InstalledPrinters.Count; iiCnt++)
                    {
                        CmbPrinter.Items.Add(PrinterSettings.InstalledPrinters[iiCnt]);
                    }
                    if (!string.IsNullOrEmpty(VarGeneral.PrintNam))
                    {
                        CmbPrinter.Text = VarGeneral.PrintNam;
                    }
                    else
                    {
                        CmbPrinter.Text = PrintS.DefaultPageSettings.PrinterSettings.PrinterName;
                    }
                }
                CmbInvType.Items.Clear();
                for (int iiCnt = 0; iiCnt < listInvSetting.Count; iiCnt++)
                {
                    _InvSetting = listInvSetting[iiCnt];
                    if (VarGeneral.SSSLev == "R" || VarGeneral.SSSLev == "C" || VarGeneral.SSSLev == "H")
                    {
                        if (_InvSetting.InvSetting != "1" && (int.Parse(_InvSetting.InvSetting.ToString()) < 400 || int.Parse(_InvSetting.InvSetting.ToString()) == 910) && _InvSetting.InvID != 22 && ((_SettingType == 0) ? (!_InvSetting.CatID.HasValue) : _InvSetting.CatID.HasValue))
                        {
                            CmbInvType.Items.Add(new Item(_InvSetting.InvNamA.Trim(), int.Parse(_InvSetting.InvID.ToString())));
                        }
                    }
                    else if (_InvSetting.InvSetting != "1" && int.Parse(_InvSetting.InvSetting.ToString()) < 400 && _InvSetting.InvID != 22 && ((_SettingType == 0) ? (!_InvSetting.CatID.HasValue) : _InvSetting.CatID.HasValue))
                    {
                        CmbInvType.Items.Add(new Item(_InvSetting.InvNamA.Trim(), int.Parse(_InvSetting.InvID.ToString())));
                    }
                }
                CmbInvType.SelectedIndex = 0;
            }
            else
            {
                CmbPrinter.Items.Clear();
                CmbPrinter.Items.Add(" ");
                PrinterSettings PrintS = new PrinterSettings();
                if (PrinterSettings.InstalledPrinters.Count != 0)
                {
                    for (int iiCnt = 0; iiCnt < PrinterSettings.InstalledPrinters.Count; iiCnt++)
                    {
                        CmbPrinter.Items.Add(PrinterSettings.InstalledPrinters[iiCnt]);
                    }
                    if (!string.IsNullOrEmpty(VarGeneral.PrintNam))
                    {
                        CmbPrinter.Text = VarGeneral.PrintNam;
                    }
                    else
                    {
                        CmbPrinter.Text = PrintS.DefaultPageSettings.PrinterSettings.PrinterName;
                    }
                }
                CmbInvType.Items.Clear();
                for (int iiCnt = 0; iiCnt < listInvSetting.Count; iiCnt++)
                {
                    _InvSetting = listInvSetting[iiCnt];
                    if (_InvSetting.InvSetting != "1" && int.Parse(_InvSetting.InvSetting.ToString()) < 400 && _InvSetting.InvID != 22 && ((_SettingType == 0) ? (!_InvSetting.CatID.HasValue) : _InvSetting.CatID.HasValue))
                    {
                        CmbInvType.Items.Add(new Item(_InvSetting.InvNamE.Trim(), int.Parse(_InvSetting.InvID.ToString())));
                    }
                }
                CmbInvType.SelectedIndex = 0;
            }
            RibunButtons();
        }
        private bool SaveData()
        {
            try
            {
                string ntyp = string.Empty;
                ntyp = (ChkPTable.Checked ? "1" : "0");
                ntyp = (RedButPaperA4.Checked ? (ntyp + "1") : (ntyp + "0"));
                ntyp = (checkBox_previewPrint.Checked ? (ntyp + "1") : (ntyp + "0"));
                _InvSetting.InvpRINTERInfo.nTyp = ntyp;
                _InvSetting.InvpRINTERInfo.hAs = double.Parse(VarGeneral.TString.TEmpty(txtBottM.Text ?? string.Empty));
                _InvSetting.InvpRINTERInfo.hYs = double.Parse(VarGeneral.TString.TEmpty(txtLeftM.Text ?? string.Empty));
                _InvSetting.InvpRINTERInfo.lnPg = double.Parse(VarGeneral.TString.TEmpty(txtLinePage.Text ?? string.Empty));
                _InvSetting.InvpRINTERInfo.hYm = double.Parse(VarGeneral.TString.TEmpty(txtRight.Text ?? string.Empty));
                _InvSetting.InvpRINTERInfo.hAl = double.Parse(VarGeneral.TString.TEmpty(txtTopM.Text ?? string.Empty));
                _InvSetting.InvpRINTERInfo.lnSpc = double.Parse(VarGeneral.TString.TEmpty(txtDistance.Text ?? string.Empty));
                _InvSetting.invGdADesc = textBox_CachierTxtA.Text;
                _InvSetting.invGdEDesc = textBox_CachierTxtE.Text;
                _InvSetting.defPrn = CmbPrinter.Text ?? string.Empty;
                _InvSetting.InvpRINTERInfo.DefLines = txtpageCount.Value;
                _InvSetting.PrintCat = chk_Stoped.Value;
                if (RButPortrait.Checked)
                {
                    _InvSetting.Orientation = 1;
                }
                else
                {
                    _InvSetting.Orientation = 2;
                }
                try
                {
                    if (checkBox_WaiterAll.Visible && _InvSetting.InvID == 21)
                    {
                        _InvSetting.autoCommGaid = checkBox_WaiterAll.Checked;
                    }
                }
                catch
                {
                }
                if (CmbPaperSize.Items.Count > 0)
                {
                    if (!string.IsNullOrEmpty(CmbPrinter.Text))
                    {
                        if (CmbPaperSize.SelectedIndex > 0)
                        {
                            _InvSetting.defSizePaper = CmbPaperSize.Text;
                        }
                        else
                        {
                            _InvSetting.defSizePaper = string.Empty;
                        }
                    }
                    else
                    {
                        _InvSetting.defSizePaper = string.Empty;
                    }
                }
                else
                {
                    _InvSetting.defSizePaper = string.Empty;
                }
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SaveData:", error, enable: true);
                MessageBox.Show(error.Message);
                return false;
            }
            return true;
        }
        private void ButWithSave_Click(object sender, EventArgs e)
        {
            bool SaveStat = SaveData();
        }
        private void CmbInvType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }
        private void checkBox_WaiterAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_WaiterAll.Checked)
            {
                chk_Stoped.Enabled = false;
            }
            else
            {
                chk_Stoped.Enabled = true;
            }
        }
        private void ButWithSave_Click_1(object sender, EventArgs e)
        {
            bool SaveStat = SaveData();
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
        private void RedButPaperA4_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
        }
        private void RedButCasher_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
        }
        private void InvPrinterSetupControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && ButWithSave.Enabled && ButWithSave.Visible && State != 0)
            {
                ButWithSave_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                //    Close();
            }
        }
        private void CmbPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                CmbPaperSize.Items.Clear();
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }
    }
}
