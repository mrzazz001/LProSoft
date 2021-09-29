using Framework.UI;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Drawing.Printing;
using System.Windows.Forms;
namespace InvAcc.Controls
{
    public partial class SndPrintSetupControl : UserControl
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
        private int ItemIndex = 0;
        private int LangArEn = 0;
        private Stock_DataDataContext dbInstance;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
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
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(SndPrintSetupControl));
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
                if (VarGeneral.vDemo && VarGeneral.UserID != 1)
                {
                    checkBox_previewPrint.Visible = false;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(SndPrintSetupControl));
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
        private void BindData()
        {
            State = FormState.Saved;
            ButWithSave.Enabled = false;
            _item = (Item)CmbInvType.SelectedItem;
            for (int iiCnt = 0; iiCnt < listInvSetting.Count; iiCnt++)
            {
                _InvSetting = listInvSetting[iiCnt];
                if (_item.Value == _InvSetting.InvID)
                {
                    if (_InvSetting.InvpRINTERInfo.nTyp.Substring(0, 1) == "0")
                    {
                        ChkPTable.Checked = false;
                    }
                    else
                    {
                        ChkPTable.Checked = true;
                    }
                    if (_InvSetting.InvpRINTERInfo.nTyp.Substring(1, 1) == "0")
                    {
                        RedButPaperA4.Checked = false;
                        RedButCasher.Checked = true;
                    }
                    else
                    {
                        RedButPaperA4.Checked = true;
                        RedButCasher.Checked = false;
                    }
                    if (_InvSetting.InvpRINTERInfo.nTyp.Substring(2, 1) == "1")
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
                    CmbPrinter.Text = _InvSetting.defPrn;
                    txtpageCount.Value = _InvSetting.InvpRINTERInfo.DefLines.Value;
                    if (_InvSetting.InvID == 27 || _InvSetting.InvID == 28)
                    {
                        ChkPTable.Visible = false;
                    }
                    else
                    {
                        ChkPTable.Visible = true;
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
                    break;
                }
            }
        }
        private void FillCombo()
        {
            int _CmbIndex = 0;
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
                    if (_InvSetting.InvSetting == "1" && _InvSetting.InvID != 18 && _InvSetting.InvID != 19 && (!(VarGeneral.SSSLev != "H") || !(VarGeneral.SSSLev != "X") || (_InvSetting.InvID != 27 && _InvSetting.InvID != 28)) && (!(VarGeneral.SSSLev != "E") || !(VarGeneral.SSSLev != "D") || _InvSetting.InvID != 16))
                    {
                        if (VarGeneral.SSSTyp != 0)
                        {
                            CmbInvType.Items.Add(new Item(_InvSetting.InvNamA.Trim(), int.Parse(_InvSetting.InvID.ToString())));
                        }
                        else if (_InvSetting.InvID != 11 && _InvSetting.InvID != 23 && _InvSetting.InvID != 24 && _InvSetting.InvID != 25 && _InvSetting.InvID != 26)
                        {
                            CmbInvType.Items.Add(new Item(_InvSetting.InvNamA.Trim(), int.Parse(_InvSetting.InvID.ToString())));
                        }
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
                    if (_InvSetting.InvSetting == "1")
                    {
                        CmbInvType.Items.Add(new Item(_InvSetting.InvNamE.Trim(), int.Parse(_InvSetting.InvID.ToString())));
                    }
                }
                CmbInvType.SelectedIndex = 0;
            }
            RibunButtons();
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                ButWithSave.Text = "حفــــظ F2";
                ButWithoutSave.Text = "خــــروج Esc";
                labelX1.Text = "إعدادات طباعة السندات";
            }
            else
            {
                ButWithSave.Text = "Save F2";
                ButWithoutSave.Text = "Exit Esc";
                labelX1.Text = "Gaid Printer Setting";
            }
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
                _InvSetting.defPrn = CmbPrinter.Text ?? string.Empty;
                _InvSetting.InvpRINTERInfo.DefLines = txtpageCount.Value;
                if (RButPortrait.Checked)
                {
                    _InvSetting.Orientation = 1;
                }
                else
                {
                    _InvSetting.Orientation = 2;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
        public SndPrintSetupControl()
        {
            InitializeComponent();//
            txtBottM.Click += Button_Edit_Click;
            txtDistance.Click += Button_Edit_Click;
            txtLeftM.Click += Button_Edit_Click;
            txtLinePage.Click += Button_Edit_Click;
            txtpageCount.Click += Button_Edit_Click;
            txtRight.Click += Button_Edit_Click;
            txtTopM.Click += Button_Edit_Click;
            txtDistance.Click += Button_Edit_Click;
            checkBox_previewPrint.Click += Button_Edit_Click;
            RButLandscape.Click += Button_Edit_Click;
            RButPortrait.Click += Button_Edit_Click;
            CmbInvType.Click += Button_Edit_Click;
            CmbPaperSize.Click += Button_Edit_Click;
            CmbPrinter.Click += Button_Edit_Click;
            listInvSetting = db.StockInvSettingList(VarGeneral.UserID);
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void ChkPTable_CheckedChanged(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            if (VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F" || VarGeneral.SSSLev == "C")
            {
                ChkPTable.Checked = true;
            }
            else if (!ChkPTable.Checked)
            {
                CmbPaperSize.Items.Clear();
                CmbPaperSize.Enabled = false;
            }
            else
            {
                CmbPaperSize.Items.Clear();
                CmbPaperSize.Enabled = true;
            }
        }
        private void checkBox_previewPrint_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_previewPrint.Checked)
            {
                groupBox1.Enabled = false;
            }
            else
            {
                groupBox1.Enabled = true;
            }
        }
        private void CmbPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                CmbPaperSize.Items.Clear();
            }
        }
        private void CmbPaperSize_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (State == FormState.Saved || string.IsNullOrEmpty(CmbPrinter.Text))
                {
                    return;
                }
                CmbPaperSize.Items.Clear();
                CmbPaperSize.Items.Add((LangArEn == 0) ? "الإفتراضي" : "Default");
                PrintDocument pd = new PrintDocument();
                pd.PrinterSettings.PrinterName = CmbPrinter.Text;
                foreach (PaperSize item in pd.PrinterSettings.PaperSizes)
                {
                    CmbPaperSize.Items.Add(item.PaperName);
                }
            }
            catch
            {
                CmbPaperSize.Items.Clear();
            }
        }
        private void CmbInvType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }
        private void SndPrintSetupControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void SndPrintSetupControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && ButWithSave.Enabled && ButWithSave.Visible)
            {
                ButWithSave_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                //Close();
            }
        }
        private void ButWithSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool SaveStat = SaveData();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SaveWith:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
    }
}
