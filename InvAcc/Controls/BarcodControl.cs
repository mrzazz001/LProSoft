using Framework.UI;
using InvAcc.Forms;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Windows.Forms;
namespace InvAcc.Controls
{
    public partial class BarcodControl : UserControl
    {
        public BarcodControl()
        {
            InitializeComponent();
            if (this.DesignMode == false)
                listInvSetting = db.StockInvSettingList(VarGeneral.UserID);
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
        private Stock_DataDataContext db
        {
            get
            {
                if (dbInstance == null)
                {
                    if (DesignMode == false) dbInstance = new Stock_DataDataContext(VarGeneral.BranchCS);
                }
                return dbInstance;
            }
        }
        public Dictionary<string, ColumnDictinary> columns_Names_visible;//ew Dictionary<string, ColumnDictinary>();
        private List<T_INVSETTING> listInvSetting;
        private T_INVSETTING _InvSetting; //new T_INVSETTING();
        private Item _item;// new Item("", 0);
        private int LangArEn = 0;
        private Stock_DataDataContext dbInstance;
        private void BarcodControl_Load(object sender, EventArgs e)
        {
            if (this.DesignMode == false)
            {
                _InvSetting = new T_INVSETTING();
                _item = new Item(string.Empty, 0);
                listInvSetting = new List<T_INVSETTING>();
                columns_Names_visible = new Dictionary<string, ColumnDictinary>();
            }
        }
        private void BindData()
        {
            if (this.DesignMode == false)
            {
                try
                {
                    for (int iiCnt = 0; iiCnt < listInvSetting.Count; iiCnt++)
                    {
                        _InvSetting = listInvSetting[iiCnt];
                        if (_InvSetting.InvID != 22)
                        {
                            continue;
                        }
                        if (_InvSetting.ISdirectPrinting)
                        {
                            checkBox_previewPrint.Checked = false;
                        }
                        else
                        {
                            checkBox_previewPrint.Checked = true;
                        }
                        txtWidth.Text = _InvSetting.InvpRINTERInfo.hAs.ToString();
                        txtLeftM.Text = _InvSetting.InvpRINTERInfo.hYs.ToString();
                        txtNumRows.Text = _InvSetting.InvpRINTERInfo.lnPg.ToString();
                        txtHeight.Text = _InvSetting.InvpRINTERInfo.hYm.ToString();
                        txtTopM.Text = _InvSetting.InvpRINTERInfo.hAl.ToString();
                        txtNumCols.Text = _InvSetting.InvpRINTERInfo.lnSpc.ToString();
                        txtBarHeigth.Text = _InvSetting.InvNum.ToString();
                        txtBarWidth.Text = _InvSetting.InvNum1.ToString();
                        CmbPrinter.Text = _InvSetting.defPrn;
                        txtpageCount.Value = _InvSetting.InvpRINTERInfo.DefLines.Value;
                        try
                        {
                            if (!string.IsNullOrEmpty(_InvSetting.InvTypA4))
                            {
                                if (_InvSetting.InvTypA4 == "0")
                                {
                                    checkBox_Collate.Checked = false;
                                }
                                else
                                {
                                    checkBox_Collate.Checked = true;
                                }
                            }
                            else
                            {
                                checkBox_Collate.Checked = false;
                            }
                        }
                        catch
                        {
                            checkBox_Collate.Checked = false;
                        }
                        break;
                    }
                }
                catch (Exception error)
                {
                    VarGeneral.DebLog.writeLog("BindData:", error, enable: true);
                }
            }
        }
        private void FillCombo()
        {
            if (this.DesignMode == false)
            {
#pragma warning disable CS0219 // The variable '_CmbIndex' is assigned but its value is never used
                int _CmbIndex = 0;
#pragma warning restore CS0219 // The variable '_CmbIndex' is assigned but its value is never used
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    CmbPrinter.Items.Clear();
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
                    CmbDir.Items.Clear();
                    CmbDir.Items.Add("يمين");
                    CmbDir.Items.Add("يسار");
                    CmbDir.Items.Add("وسط");
                    CmbPrintP.Items.Clear();
                    CmbPrintP.Items.Add("رأس المستند");
                    CmbPrintP.Items.Add("سطور المستند");
                    InstalledFontCollection _font = new InstalledFontCollection();
                    string fontString = string.Empty;
                    for (int i = 0; i < _font.Families.Length; i++)
                    {
                        fontString += _font.Families[i].Name;
                        fontString += "|";
                    }
                    CmbPrintP2.Items.Clear();
                    CmbPrintP2.Items.Add("كل صفحة");
                    CmbPrintP2.Items.Add("الصفحة الأولى");
                    CmbPrintP2.Items.Add("الصفحة الأخيرة");
                }
                else
                {
                    CmbPrinter.Items.Clear();
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
                    CmbDir.Items.Clear();
                    CmbDir.Items.Add("Right");
                    CmbDir.Items.Add("Left");
                    CmbDir.Items.Add("Center");
                    CmbPrintP.Items.Clear();
                    CmbPrintP.Items.Add("Document Top");
                    CmbPrintP.Items.Add("Document Line");
                    InstalledFontCollection _font = new InstalledFontCollection();
                    string fontString = string.Empty;
                    for (int i = 0; i < _font.Families.Length; i++)
                    {
                        fontString += _font.Families[i].Name;
                        fontString += "|";
                    }
                    CmbPrintP2.Items.Clear();
                    CmbPrintP2.Items.Add("All Page");
                    CmbPrintP2.Items.Add("Frist Page");
                    CmbPrintP2.Items.Add("Last Page");
                }
                RibunButtons();
            }
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                ButWithSave.Text = "حفــــظ F2";
                ButWithoutSave.Text = "خــــروج Esc";
                label1.Text = "اختيار الطابعة :";
                label2.Text = "هامش اعلى :";
                label10.Text = "هامش يسار :";
                label4.Text = "العـــرض :";
                label5.Text = "الإرتفـــاع :";
                label6.Text = "البعد العرضي بين كروت الباركود :";
                label7.Text = "الإرتفاع بين كروت الباركود :";
                label8.Text = "عدد الكروت طوليا :";
                label9.Text = "عدد الكروت عرضيا :";
                labelX1.Text = "إعدادات طباعة الباركود";
            }
            else
            {
                ButWithSave.Text = "Save F2";
                ButWithoutSave.Text = "Exit Esc";
                label1.Text = "Select Printer :";
                label2.Text = "Top margin :";
                label10.Text = "Left margin :";
                label4.Text = "width :";
                label5.Text = "Height :";
                label6.Text = "Width dimension between the barcode :";
                label7.Text = "Height between the barcode :";
                label8.Text = "Number of full-length cards :";
                label9.Text = "Number of cards Width :";
                labelX1.Text = "Barcode Setting";
            }
        }
        private bool SaveData()
        {
            try
            {
                string ntyp = "10";
                ntyp = (checkBox_previewPrint.Checked ? (ntyp + "1") : (ntyp + "0"));
                _InvSetting.InvpRINTERInfo.nTyp = ntyp;
                _InvSetting.InvpRINTERInfo.hAs = txtWidth.Value;
                _InvSetting.InvpRINTERInfo.hYs = txtLeftM.Value;
                _InvSetting.InvpRINTERInfo.lnPg = txtNumRows.Value;
                _InvSetting.InvpRINTERInfo.hYm = txtHeight.Value;
                _InvSetting.InvpRINTERInfo.hAl = txtTopM.Value;
                _InvSetting.InvpRINTERInfo.lnSpc = txtNumCols.Value;
                _InvSetting.InvNum = txtBarHeigth.Value;
                _InvSetting.InvNum1 = txtBarWidth.Value;
                _InvSetting.defPrn = CmbPrinter.Text ?? string.Empty;
                _InvSetting.InvpRINTERInfo.DefLines = txtpageCount.Value;
                _InvSetting.InvTypA4 = (checkBox_Collate.Checked ? "1" : "0");
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void ButWithSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {

                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("ButWithSave_Click:", error, enable: true);
                MessageBox.Show(error.Message);
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
        private void BarcodControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && ButWithSave.Enabled && ButWithSave.Visible)
            {
                ButWithSave_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                // Close();
            }
        }
        private void BarcodControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void CmbInvType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FMExplanation fromExp = new FMExplanation(LangArEn);
            fromExp.ShowDialog();
        }
        protected override void OnLoad(EventArgs e)
        {
            if (this.DesignMode == false)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(BarcodControl));
                if (this.DesignMode == false)
                {
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
            }
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            if (this.DesignMode == false)
            {
                try
                {
                    ComponentResourceManager resources = new ComponentResourceManager(typeof(FMBarCodePrintSetup));
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
                catch (Exception error)
                {
                    VarGeneral.DebLog.writeLog("OnParentRightToLeftChanged:", error, enable: true);
                    MessageBox.Show(error.Message);
                }
            }
        }
        private void ribbonBar1_ItemClick(object sender, EventArgs e)
        {
        }
        private void labelX1_Click(object sender, EventArgs e)
        {
        }
    }
}
