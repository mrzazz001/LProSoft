using C1.Win.C1FlexGrid;
using Framework.UI;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class SSSFMSndPrintSetup : Form
    { void avs(int arln)

{ 
}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
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
       // private IContainer components = null;
        private C1FlexGrid FlxFiles;
        private RadioButton RedButPaperA4;
        private ComboBox CmbInvType;
        private CheckBox ChkPTable;
        private ComboBox CmbPrinter;
        private RadioButton RedButCasher;
        private ComboBox CmbPrintP;
        private TextBox txtDistance;
        private Label label6;
        private ComboBox CmbDir;
        private TextBox txtLinePage;
        private ComboBox CmbUnit;
        private Button ButWithoutSave;
        private TextBox txtLeftM;
        private Label label3;
        private Button ButWithSave;
        private Label label8;
        private GroupBox groupBox1;
        private Label label7;
        private Label label4;
        private TextBox txtBottM;
        private TextBox txtRight;
        private Label label2;
        private TextBox txtTopM;
        private Label label1;
        private Label label5;
        private ComboBox CmbPrintP2;
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private List<T_INVSETTING> listInvSetting = new List<T_INVSETTING>();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private List<T_mInvPrint> listmInvPrint = new List<T_mInvPrint>();
        private T_mInvPrint _mInvPrint = new T_mInvPrint();
        private Item _item = new Item(string.Empty, 0);
#pragma warning disable CS0414 // The field 'SSSFMSndPrintSetup.ItemIndex' is assigned but its value is never used
        private int ItemIndex = 0;
#pragma warning restore CS0414 // The field 'SSSFMSndPrintSetup.ItemIndex' is assigned but its value is never used
        private int LangArEn = 0;
        private Stock_DataDataContext dbInstance;
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
        public SSSFMSndPrintSetup()
        {
            InitializeComponent();this.Load += langloads;
            listInvSetting = db.StockInvSettingList(VarGeneral.UserID);
        }
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(SSSFMSndPrintSetup));
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
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(SSSFMSndPrintSetup));
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
                    txtBottM.Text = _InvSetting.InvpRINTERInfo.hAs.ToString();
                    txtLeftM.Text = _InvSetting.InvpRINTERInfo.hYs.ToString();
                    txtLinePage.Text = _InvSetting.InvpRINTERInfo.lnPg.ToString();
                    txtRight.Text = _InvSetting.InvpRINTERInfo.hYm.ToString();
                    txtTopM.Text = _InvSetting.InvpRINTERInfo.hAl.ToString();
                    txtDistance.Text = _InvSetting.InvpRINTERInfo.lnSpc.ToString();
                    CmbPrinter.Text = _InvSetting.defPrn;
                    break;
                }
            }
            listmInvPrint = (from item in db.T_mInvPrints
                             where item.repTyp == (int?)_item.Value
                             where item.repNum == (int?)2
                             select item).ToList();
            if (listmInvPrint.Count == 0)
            {
                return;
            }
            for (int iiCnt = 0; iiCnt < listmInvPrint.Count; iiCnt++)
            {
                _mInvPrint = listmInvPrint[iiCnt];
                for (int ii = 1; ii < FlxFiles.Rows.Count; ii++)
                {
                    if ((_mInvPrint.pField ?? string.Empty).ToString() == string.Concat(FlxFiles.GetData(ii, 11)))
                    {
                        FlxFiles.SetData(ii, 2, VarGeneral.TString.ChkStatShow(VarGeneral.TString.TEmpty(string.Concat(_mInvPrint.IsPrint)), 0));
                        FlxFiles.SetData(ii, 3, _mInvPrint.vRow);
                        FlxFiles.SetData(ii, 4, _mInvPrint.vCol);
                        FlxFiles.SetData(ii, 12, _mInvPrint.vEt);
                        CmbDir.SelectedIndex = int.Parse(VarGeneral.TString.TEmpty(string.Concat(_mInvPrint.vEt)));
                        FlxFiles.SetData(ii, 5, CmbDir.Text);
                        FlxFiles.SetData(ii, 13, _mInvPrint.IsPrntHd);
                        CmbPrintP.SelectedIndex = int.Parse(VarGeneral.TString.TEmpty(string.Concat(_mInvPrint.IsPrntHd)));
                        FlxFiles.SetData(ii, 6, CmbPrintP.Text);
                        FlxFiles.SetData(ii, 14, _mInvPrint.nTyp);
                        CmbPrintP2.SelectedIndex = int.Parse(VarGeneral.TString.TEmpty(string.Concat(_mInvPrint.nTyp)));
                        FlxFiles.SetData(ii, 10, CmbPrintP2.Text);
                        FlxFiles.SetData(ii, 7, _mInvPrint.vFont);
                        FlxFiles.SetData(ii, 8, _mInvPrint.vSize);
                        FlxFiles.SetData(ii, 9, VarGeneral.TString.ChkStatShow(VarGeneral.TString.TEmpty(string.Concat(_mInvPrint.vBold)), 0));
                    }
                }
            }
        }
        private void FillCombo()
        {
            CmbUnit.SelectedIndex = 0;
#pragma warning disable CS0219 // The variable '_CmbIndex' is assigned but its value is never used
            int _CmbIndex = 0;
#pragma warning restore CS0219 // The variable '_CmbIndex' is assigned but its value is never used
            PrinterSettings PrintS;
            InstalledFontCollection _font;
            string fontString;
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                PrintS = new PrinterSettings();
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
                FlxFiles.Rows.Count = 34;
                FlxFiles.Cols[0].Visible = false;
                FlxFiles.Cols[1].Visible = true;
                FlxFiles.SetData(0, 0, "Filed");
                FlxFiles.SetData(0, 1, "الحقل");
                FlxFiles.SetData(0, 2, "طباعة");
                FlxFiles.SetData(0, 3, "السطر");
                FlxFiles.SetData(0, 4, "العمود");
                FlxFiles.SetData(0, 5, "الأتجاه");
                CmbDir.Items.Clear();
                CmbDir.Items.Add("يمين");
                CmbDir.Items.Add("يسار");
                CmbDir.Items.Add("وسط");
                FlxFiles.Cols[5].Editor = CmbDir;
                FlxFiles.SetData(0, 6, "مكان الطباعة");
                CmbPrintP.Items.Clear();
                CmbPrintP.Items.Add("رأس المستند");
                CmbPrintP.Items.Add("سطور المستند");
                FlxFiles.Cols[6].Editor = CmbPrintP;
                FlxFiles.SetData(0, 7, "الخط");
                _font = new InstalledFontCollection();
                fontString = string.Empty;
                for (int i = 0; i < _font.Families.Length; i++)
                {
                    fontString += _font.Families[i].Name;
                    fontString += "|";
                }
                FlxFiles.Cols[7].ComboList = fontString;
                FlxFiles.SetData(0, 8, "الحجم");
                FlxFiles.SetData(0, 9, "عريض");
                FlxFiles.SetData(0, 10, "مكان الطباعة 2");
                CmbPrintP2.Items.Clear();
                CmbPrintP2.Items.Add("كل صفحة");
                CmbPrintP2.Items.Add("الصفحة الأولى");
                CmbPrintP2.Items.Add("الصفحة الأخيرة");
                FlxFiles.Cols[10].Editor = CmbPrintP2;
                FlxFiles.SetData(1, 1, "رقم القيد");
                FlxFiles.SetData(1, 11, "gdID");
                FlxFiles.SetData(2, 1, "رقم السند");
                FlxFiles.SetData(2, 11, "gdNo");
                FlxFiles.SetData(3, 1, "التاريخ الهجري");
                FlxFiles.SetData(3, 11, "gdHDate");
                FlxFiles.SetData(4, 1, "التاريخ الميلادي");
                FlxFiles.SetData(4, 11, "gdGDate");
                FlxFiles.SetData(5, 1, "مركز التكلفة عربي");
                FlxFiles.SetData(5, 11, "Arb_Cst");
                FlxFiles.SetData(6, 1, "مركز التكلفة أنجليزي");
                FlxFiles.SetData(6, 11, "Eng_Cst");
                FlxFiles.SetData(7, 1, "المندوب عربي");
                FlxFiles.SetData(7, 11, "Arb_Mnd");
                FlxFiles.SetData(8, 1, "المندوب أنجليزي");
                FlxFiles.SetData(8, 11, "Eng_Mnd");
                FlxFiles.SetData(9, 1, "المستخدم");
                FlxFiles.SetData(9, 11, "gdUserNam");
                FlxFiles.SetData(10, 1, "العملة عربي");
                FlxFiles.SetData(10, 11, "Arb_Cur");
                FlxFiles.SetData(11, 1, "العملة أنجليزي");
                FlxFiles.SetData(11, 11, "Eng_Cur");
                FlxFiles.SetData(12, 1, "وصف القيد");
                FlxFiles.SetData(12, 11, "gdDes");
                FlxFiles.SetData(13, 1, "رقم الحساب");
                FlxFiles.SetData(13, 11, "AccDef_No");
                FlxFiles.SetData(14, 1, "أسم الحساب عربي");
                FlxFiles.SetData(14, 11, "Arb_Des");
                FlxFiles.SetData(15, 1, "أسم الحساب أنجليزي");
                FlxFiles.SetData(15, 11, "Eng_Des");
                FlxFiles.SetData(16, 1, "الأجمالي");
                FlxFiles.SetData(16, 11, "gdTot");
                FlxFiles.SetData(17, 1, "حركة مدينة");
                FlxFiles.SetData(17, 11, "DebitBala");
                FlxFiles.SetData(18, 1, "حركة دائنة");
                FlxFiles.SetData(18, 11, "CreditBala");
                FlxFiles.SetData(19, 1, "الأجمالي كتابة عربي");
                FlxFiles.SetData(19, 11, "ArbTaf");
                FlxFiles.SetData(20, 1, "الأجمالي كتابة أنجليزي");
                FlxFiles.SetData(20, 11, "EngTaf");
                FlxFiles.SetData(21, 1, "ملاحظات");
                FlxFiles.SetData(21, 11, "gdMem");
                FlxFiles.SetData(22, 1, "أسم السند عربي");
                FlxFiles.SetData(22, 11, "InvNamA");
                FlxFiles.SetData(23, 1, "أسم السند أنجليزي");
                FlxFiles.SetData(23, 11, "InvNamE");
                FlxFiles.SetData(24, 1, "رقم الصفحة");
                FlxFiles.SetData(24, 11, "PageNo");
                FlxFiles.SetData(25, 1, "المرجع");
                FlxFiles.SetData(25, 11, "RefNo");
                FlxFiles.SetData(26, 1, "شيك رقم");
                FlxFiles.SetData(26, 11, "ChekNo");
                FlxFiles.SetData(27, 1, "أستلمنا من / أصرفوا لي");
                FlxFiles.SetData(27, 11, "InvTypA0");
                FlxFiles.SetData(28, 1, "اسم العميل / المورد)-السطر الاول");
                FlxFiles.SetData(28, 11, "CusVenNm");
                FlxFiles.SetData(29, 1, "اسم العميل / المورد-انجليزي -السطر الاول");
                FlxFiles.SetData(29, 11, "CusVenNmE");
                FlxFiles.SetData(30, 1, "جوال العميل-السطر الاول");
                FlxFiles.SetData(30, 11, "Mobile");
                FlxFiles.SetData(31, 1, "الشخص المسؤول-السطر الاول");
                FlxFiles.SetData(31, 11, "PersonalNm");
                FlxFiles.SetData(32, 1, "المدينة-السطر الاول");
                FlxFiles.SetData(32, 11, "City");
                FlxFiles.SetData(33, 1, "الإيميل-السطر الاول");
                FlxFiles.SetData(33, 11, "Email");
                try
                {
                    if (File.Exists(Application.StartupPath + "\\Script\\Secriptjustlight.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\Secriptjustlight.dll")))
                    {
                        FlxFiles.SetData(32, 11, "الجنسية");
                        FlxFiles.SetData(33, 1, "رقم الهوية");
                    }
                }
                catch
                {
                }
                CmbInvType.Items.Clear();
                for (int iiCnt = 0; iiCnt < listInvSetting.Count; iiCnt++)
                {
                    _InvSetting = listInvSetting[iiCnt];
                    if (_InvSetting.InvSetting == "1")
                    {
                        CmbInvType.Items.Add(new Item(_InvSetting.InvNamA.Trim(), int.Parse(_InvSetting.InvID.ToString())));
                    }
                }
                CmbInvType.SelectedIndex = 0;
                return;
            }
            PrintS = new PrinterSettings();
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
            FlxFiles.Rows.Count = 34;
            FlxFiles.Cols[0].Visible = true;
            FlxFiles.Cols[1].Visible = false;
            FlxFiles.SetData(0, 0, "Filed");
            FlxFiles.SetData(0, 1, "الحقل");
            FlxFiles.SetData(0, 2, "Print");
            FlxFiles.SetData(0, 3, "Line");
            FlxFiles.SetData(0, 4, "Column");
            FlxFiles.SetData(0, 5, "Direction");
            CmbDir.Items.Clear();
            CmbDir.Items.Add("Right");
            CmbDir.Items.Add("Left");
            CmbDir.Items.Add("Center");
            FlxFiles.Cols[5].Editor = CmbDir;
            FlxFiles.SetData(0, 6, "Print Place");
            CmbPrintP.Items.Clear();
            CmbPrintP.Items.Add("Document Top");
            CmbPrintP.Items.Add("Document Line");
            FlxFiles.Cols[6].Editor = CmbPrintP;
            FlxFiles.SetData(0, 7, "Font");
            _font = new InstalledFontCollection();
            fontString = string.Empty;
            for (int i = 0; i < _font.Families.Length; i++)
            {
                fontString += _font.Families[i].Name;
                fontString += "|";
            }
            FlxFiles.Cols[7].ComboList = fontString;
            FlxFiles.SetData(0, 8, "Size");
            FlxFiles.SetData(0, 9, "Bold");
            FlxFiles.SetData(0, 10, "Print Place 2");
            CmbPrintP2.Items.Clear();
            CmbPrintP2.Items.Add("All Page");
            CmbPrintP2.Items.Add("Frist Page");
            CmbPrintP2.Items.Add("Last Page");
            FlxFiles.Cols[10].Editor = CmbPrintP2;
            FlxFiles.SetData(1, 0, "Journal No");
            FlxFiles.SetData(1, 11, "gdID");
            FlxFiles.SetData(2, 0, "Document No");
            FlxFiles.SetData(2, 11, "gdNo");
            FlxFiles.SetData(3, 0, "Hijri Date");
            FlxFiles.SetData(3, 11, "gdHDate");
            FlxFiles.SetData(4, 0, "Greg Date");
            FlxFiles.SetData(4, 11, "gdGDate");
            FlxFiles.SetData(5, 0, "Cost Center Arabic");
            FlxFiles.SetData(5, 11, "Arb_Cst");
            FlxFiles.SetData(6, 0, "Cost Center English");
            FlxFiles.SetData(6, 11, "Eng_Cst");
            FlxFiles.SetData(7, 0, "Lagate Arabic");
            FlxFiles.SetData(7, 11, "Arb_Mnd");
            FlxFiles.SetData(8, 0, "Lagate English");
            FlxFiles.SetData(8, 11, "Eng_Mnd");
            FlxFiles.SetData(9, 0, "User");
            FlxFiles.SetData(9, 11, "gdUserNam");
            FlxFiles.SetData(10, 0, "Currency Arabic");
            FlxFiles.SetData(10, 11, "Arb_Cur");
            FlxFiles.SetData(11, 0, "Currency English");
            FlxFiles.SetData(11, 11, "Eng_Cur");
            FlxFiles.SetData(12, 0, "Jurnal Desc");
            FlxFiles.SetData(12, 11, "gdDes");
            FlxFiles.SetData(13, 0, "Account No");
            FlxFiles.SetData(13, 11, "AccDef_No");
            FlxFiles.SetData(14, 0, "Account Name Arabic");
            FlxFiles.SetData(14, 11, "Arb_Des");
            FlxFiles.SetData(15, 0, "Account Name English");
            FlxFiles.SetData(15, 11, "Eng_Des");
            FlxFiles.SetData(16, 0, "Total");
            FlxFiles.SetData(16, 11, "gdTot");
            FlxFiles.SetData(17, 0, "Debit Trans");
            FlxFiles.SetData(17, 11, "DebitBala");
            FlxFiles.SetData(18, 0, "Credit Trans");
            FlxFiles.SetData(18, 11, "CreditBala");
            FlxFiles.SetData(19, 0, "Total Script Arabic");
            FlxFiles.SetData(19, 11, "ArbTaf");
            FlxFiles.SetData(20, 0, "Total Script English");
            FlxFiles.SetData(20, 11, "EngTaf");
            FlxFiles.SetData(21, 0, "Remark");
            FlxFiles.SetData(21, 11, "gdMem");
            FlxFiles.SetData(22, 0, "Docment Name Arabic");
            FlxFiles.SetData(22, 11, "InvNamA");
            FlxFiles.SetData(23, 0, "Docment Name English");
            FlxFiles.SetData(23, 11, "InvNamE");
            FlxFiles.SetData(24, 0, "Page No");
            FlxFiles.SetData(24, 11, "PageNo");
            FlxFiles.SetData(25, 0, "Reference");
            FlxFiles.SetData(25, 11, "RefNo");
            FlxFiles.SetData(26, 0, "Cheque No");
            FlxFiles.SetData(26, 11, "ChekNo");
            FlxFiles.SetData(27, 0, "Docment Desc");
            FlxFiles.SetData(27, 11, "InvTypA0");
            FlxFiles.SetData(28, 1, "اسم العميل / المورد)-السطر الاول");
            FlxFiles.SetData(28, 11, "CusVenNm");
            FlxFiles.SetData(29, 1, "اسم العميل / المورد-انجليزي -السطر الاول");
            FlxFiles.SetData(29, 11, "CusVenNmE");
            FlxFiles.SetData(30, 1, "جوال العميل-السطر الاول");
            FlxFiles.SetData(30, 11, "Mobile");
            FlxFiles.SetData(31, 1, "الشخص المسؤول-السطر الاول");
            FlxFiles.SetData(31, 11, "PersonalNm");
            FlxFiles.SetData(32, 1, "المدينة-السطر الاول");
            FlxFiles.SetData(32, 11, "City");
            FlxFiles.SetData(33, 1, "الإيميل-السطر الاول");
            FlxFiles.SetData(33, 11, "Email");
            try
            {
                if (File.Exists(Application.StartupPath + "\\Script\\Secriptjustlight.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", string.Empty).Trim() + "\\Secriptjustlight.dll")))
                {
                    FlxFiles.SetData(32, 11, "الجنسية");
                    FlxFiles.SetData(33, 1, "رقم الهوية");
                }
            }
            catch
            {
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
        private bool SaveData()
        {
            try
            {
                string ntyp = string.Empty;
                ntyp = (ChkPTable.Checked ? "1" : "0");
                ntyp = (RedButPaperA4.Checked ? (ntyp + "1") : (ntyp + "0"));
                try
                {
                    ntyp += _InvSetting.InvpRINTERInfo.nTyp.Substring(2, 1);
                }
                catch
                {
                    ntyp += "1";
                }
                _InvSetting.InvpRINTERInfo.nTyp = ntyp;
                _InvSetting.InvpRINTERInfo.hAs = double.Parse(VarGeneral.TString.TEmpty(txtBottM.Text ?? string.Empty));
                _InvSetting.InvpRINTERInfo.hYs = double.Parse(VarGeneral.TString.TEmpty(txtLeftM.Text ?? string.Empty));
                _InvSetting.InvpRINTERInfo.lnPg = double.Parse(VarGeneral.TString.TEmpty(txtLinePage.Text ?? string.Empty));
                _InvSetting.InvpRINTERInfo.hYm = double.Parse(VarGeneral.TString.TEmpty(txtRight.Text ?? string.Empty));
                _InvSetting.InvpRINTERInfo.hAl = double.Parse(VarGeneral.TString.TEmpty(txtTopM.Text ?? string.Empty));
                _InvSetting.InvpRINTERInfo.lnSpc = double.Parse(VarGeneral.TString.TEmpty(txtDistance.Text ?? string.Empty));
                _InvSetting.defPrn = CmbPrinter.Text ?? string.Empty;
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                List<T_mInvPrint> listmInvPrintSave = new List<T_mInvPrint>();
                int iiCnt = 0;
                if (listmInvPrint.Count != 0)
                {
                    for (iiCnt = 0; iiCnt < listmInvPrint.Count; iiCnt++)
                    {
                        db.T_mInvPrints.DeleteOnSubmit(listmInvPrint[iiCnt]);
                        db.SubmitChanges();
                    }
                }
                for (iiCnt = 1; iiCnt < FlxFiles.Rows.Count; iiCnt++)
                {
                    _mInvPrint = new T_mInvPrint();
                    _mInvPrint.IsPrint = int.Parse(VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(FlxFiles.GetData(iiCnt, 2))));
                    _mInvPrint.vRow = int.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxFiles.GetData(iiCnt, 3))));
                    _mInvPrint.vCol = int.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxFiles.GetData(iiCnt, 4))));
                    _mInvPrint.vEt = int.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxFiles.GetData(iiCnt, 12))));
                    _mInvPrint.IsPrntHd = int.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxFiles.GetData(iiCnt, 13))));
                    _mInvPrint.nTyp = int.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxFiles.GetData(iiCnt, 14))));
                    _mInvPrint.vFont = string.Concat(FlxFiles.GetData(iiCnt, 7));
                    _mInvPrint.vSize = int.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxFiles.GetData(iiCnt, 8))));
                    _mInvPrint.vBold = int.Parse(VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(FlxFiles.GetData(iiCnt, 9))));
                    _mInvPrint.pField = string.Concat(FlxFiles.GetData(iiCnt, 11));
                    _mInvPrint.uChr = CmbUnit.Text;
                    _mInvPrint.repTyp = _item.Value;
                    _mInvPrint.repNum = 2;
                    listmInvPrintSave.Add(_mInvPrint);
                }
                for (int q = 0; q < listmInvPrintSave.Count; q++)
                {
                    db.T_mInvPrints.InsertOnSubmit(listmInvPrintSave[q]);
                    db.SubmitChanges();
                }
                MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
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
                VarGeneral.DebLog.writeLog("SaveWith:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void FlxFiles_AfterEdit(object sender, RowColEventArgs e)
        {
            if (e.Col == 5)
            {
                FlxFiles.SetData(e.Row, 12, CmbDir.SelectedIndex);
            }
            if (e.Col == 6)
            {
                FlxFiles.SetData(e.Row, 13, CmbPrintP.SelectedIndex);
            }
            if (e.Col == 10)
            {
                FlxFiles.SetData(e.Row, 14, CmbPrintP2.SelectedIndex);
            }
        }
        private void CmbInvType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
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
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void SSSFMSndPrintSetup_Load(object sender, EventArgs e)
        {
        }
    }
}
