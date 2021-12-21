using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using Framework.UI;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FMBarCodePrintSetup : Form
    { void avs(int arln)

{ 
 button1.Text=   (arln == 0 ? "  شكل توضيح  " : "  illustration shape") ; checkBox_previewPrint.Text=   (arln == 0 ? "  تعيين إعدادات الطابعة الإفتراضية   " : "  Set the default printer settings") ; checkBox_Collate.Text=   (arln == 0 ? "  تجـميــــع  " : "  collection") ; label7.Text=   (arln == 0 ? "  الإرتفاع بين كروت الباركود :  " : "  Height between barcode cards:") ; label10.Text=   (arln == 0 ? "  هامش يسار :  " : "  left margin:") ; label5.Text=   (arln == 0 ? "  الإرتفـــاع :  " : "  Height:") ; label4.Text=   (arln == 0 ? "  العـــرض :  " : "  Presentation:") ; label6.Text=   (arln == 0 ? "  البعد العرضي بين كروت الباركود :  " : "  The transverse dimension between the barcode cards:") ; label1.Text=   (arln == 0 ? "  اختيار الطابعة :  " : "  Printer selection:") ; label2.Text=   (arln == 0 ? "  هامش اعلى :  " : "  higher margin:") ; label33.Text=   (arln == 0 ? "  عدد النسخ :  " : "  Number of copies :") ; label9.Text=   (arln == 0 ? "  عدد الكروت عرضيا :  " : "  Number of cross cards:") ; label8.Text=   (arln == 0 ? "  عدد الكروت طوليا :  " : "  Number of cards longitudinally:") ; ButWithoutSave.Text=   (arln == 0 ? "  خــــروج  " : "  exit") ; ButWithSave.Text=   (arln == 0 ? "  حفــــظ  " : "  save") ; labelX1.Text=   (arln == 0 ? "  إعدادات طباعة الباركود  " : "  Barcode printing settings") ;}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
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
        private Item _item = new Item("", 0);
        private int LangArEn = 0;
        private Stock_DataDataContext dbInstance;
       // private IContainer components = null;
        private ComboBox CmbPrintP2;
        private Button button1;
        private ComboBox CmbPrintP;
        private ComboBox CmbDir;
        private RibbonBar ribbonBar1;
        private GroupBox groupBox1;
        private IntegerInput txtBarWidth;
        private IntegerInput txtBarHeigth;
        private Label label7;
        private Label label5;
        private Label label1;
        private Label label4;
        private Label label6;
        private Label label2;
        private GroupBox groupBox2;
        private ButtonX ButWithoutSave;
        private ButtonX ButWithSave;
        private DoubleInput txtWidth;
        private DoubleInput txtHeight;
        private DoubleInput txtLeftM;
        private DoubleInput txtTopM;
        private GroupBox groupBox3;
        private DoubleInput txtNumRows;
        private DoubleInput txtNumCols;
        private Label label9;
        private Label label8;
        private ComboBoxEx CmbPrinter;
        private LabelX labelX1;
        private Label label10;
        private IntegerInput txtpageCount;
        private Label label33;
        private CheckBox checkBox_previewPrint;
        private CheckBox checkBox_Collate;
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
        public FMBarCodePrintSetup()
        {
            InitializeComponent();this.Load += langloads;
            listInvSetting = db.StockInvSettingList(VarGeneral.UserID);
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
        protected override void OnLoad(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FMBarCodePrintSetup));
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
            FillCombo();
            BindData();
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FMBarCodePrintSetup));
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
                FillCombo();
                BindData();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("OnParentRightToLeftChanged:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        int sa = 0;
        private void BindData()
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
                    if (sa == 0)
                    {
                        if (_InvSetting.InvpRINTERInfo.nTyp.Substring(2, 1) == "1")
                        {
                            checkBox_previewPrint.Checked = false;
                        }
                        else
                        {
                            checkBox_previewPrint.Checked = true;
                        }
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
        private void FillCombo()
        {
#pragma warning disable CS0219 // The variable '_CmbIndex' is assigned but its value is never used
            int _CmbIndex = 0;
#pragma warning restore CS0219 // The variable '_CmbIndex' is assigned but its value is never used
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
                string fontString = "";
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
                string fontString = "";
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
                _InvSetting.defPrn = CmbPrinter.Text ?? "";
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
        private void ButWithoutSave_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ButWithSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Close();
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("ButWithSave_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void CmbInvType_SelectedIndexChanged(object sender, EventArgs e)
        {
            sa = 1;
            BindData(); sa = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FMExplanation fromExp = new FMExplanation(LangArEn);
            fromExp.ShowDialog();
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
            if (e.KeyCode == Keys.F2 && ButWithSave.Enabled && ButWithSave.Visible)
            {
                ButWithSave_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void FMBarCodePrintSetup_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
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
        private void labelX1_Click(object sender, EventArgs e)
        {
        }
    }
}
