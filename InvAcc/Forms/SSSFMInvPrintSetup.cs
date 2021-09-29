using C1.Win.C1FlexGrid;
using Framework.UI;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
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
    public partial  class SSSFMInvPrintSetup : Form
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
        private Label label3;
        private TextBox txtRight;
        private C1FlexGrid FlxFiles;
        private Label label2;
        private TextBox txtTopM;
        private TextBox txtBottM;
        private RadioButton RedButPaperA4;
        private ComboBox CmbInvType;
        private CheckBox ChkPTable;
        private Label label5;
        private Label label1;
        private RadioButton RedButCasher;
        private ComboBox CmbPrintP;
        private ComboBox CmbDir;
        private ComboBox CmbUnit;
        private Label label4;
        private Label label7;
        private Button ButWithoutSave;
        private ComboBox CmbPrinter;
        private ComboBox CmbPrintP2;
        private TextBox txtDistance;
        private Label label8;
        private Label label6;
        private GroupBox groupBox1;
        private TextBox txtLinePage;
        private TextBox txtLeftM;
        private Button ButWithSave;
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private List<T_INVSETTING> listInvSetting = new List<T_INVSETTING>();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private List<T_mInvPrint> listmInvPrint = new List<T_mInvPrint>();
        private T_mInvPrint _mInvPrint = new T_mInvPrint();
        private Item _item = new Item("", 0);
#pragma warning disable CS0414 // The field 'SSSFMInvPrintSetup.ItemIndex' is assigned but its value is never used
        private int ItemIndex = 0;
#pragma warning restore CS0414 // The field 'SSSFMInvPrintSetup.ItemIndex' is assigned but its value is never used
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
        public SSSFMInvPrintSetup()
        {
            InitializeComponent();this.Load += langloads;
            listInvSetting = db.StockInvSettingList(VarGeneral.UserID);
        }
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(SSSFMInvPrintSetup));
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
                VarGeneral.DebLog.writeLog("OnLoad:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(SSSFMInvPrintSetup));
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
        private void BindData()
        {
            try
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
                                 where item.repNum == (int?)3
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
                        if ((_mInvPrint.pField ?? "").ToString() == string.Concat(FlxFiles.GetData(ii, 11)))
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
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("BindData:", error, enable: true);
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
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
                FlxFiles.Rows.Count = 95;
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
                fontString = "";
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
                FlxFiles.SetData(1, 1, "نوع الفاتورة");
                FlxFiles.SetData(1, 11, "InvTyp");
                FlxFiles.SetData(2, 1, "رقم الفاتورة");
                FlxFiles.SetData(2, 11, "InvNo");
                FlxFiles.SetData(3, 1, "طريقة الدفع");
                FlxFiles.SetData(3, 11, "InvCash");
                FlxFiles.SetData(4, 1, "التاريخ");
                FlxFiles.SetData(4, 11, "HDat");
                FlxFiles.SetData(5, 1, "الموافق");
                FlxFiles.SetData(5, 11, "GDat");
                FlxFiles.SetData(6, 1, "رقم العميل / المورد");
                FlxFiles.SetData(6, 11, "CusVenNo");
                FlxFiles.SetData(7, 1, "اسم العميل / المورد");
                FlxFiles.SetData(7, 11, "CusVenNm");
                FlxFiles.SetData(8, 1, "التلفون");
                FlxFiles.SetData(8, 11, "CusVenTel");
                FlxFiles.SetData(9, 1, "العنوان");
                FlxFiles.SetData(9, 11, "CusVenAdd");
                FlxFiles.SetData(10, 1, "المندوب عربي");
                FlxFiles.SetData(10, 11, "Mndob_Arb_Des");
                FlxFiles.SetData(11, 1, "المندوب أنجليزي");
                FlxFiles.SetData(11, 11, "Mndob_Eng_Des");
                FlxFiles.SetData(12, 1, "مركز التكلفة عربي");
                FlxFiles.SetData(12, 11, "CstTbl_Arb_Des");
                FlxFiles.SetData(13, 1, "مركز التكلفة انجليزي");
                FlxFiles.SetData(13, 11, "CstTbl_Eng_Des");
                FlxFiles.SetData(14, 1, "ملاحظات");
                FlxFiles.SetData(14, 11, "Remark");
                FlxFiles.SetData(15, 1, "المرجع");
                FlxFiles.SetData(15, 11, "RefNo");
                FlxFiles.SetData(16, 1, "أجمالي الفاتورة - ذيل");
                FlxFiles.SetData(16, 11, "InvTotLocCur");
                FlxFiles.SetData(17, 1, "المدفوع - ذيل");
                FlxFiles.SetData(17, 11, "Puyaid");
                FlxFiles.SetData(18, 1, "الخصم قيمة - ذيل");
                FlxFiles.SetData(18, 11, "InvDisVal");
                FlxFiles.SetData(19, 1, "الخصم نسبة - ذيل");
                FlxFiles.SetData(19, 11, "InvDisPrs");
                FlxFiles.SetData(20, 1, "توتال - صافي الفاتورة - ذيل");
                FlxFiles.SetData(20, 11, "InvNetLocCur");
                FlxFiles.SetData(21, 1, "الأجمالي بالحروف أنجليزي");
                FlxFiles.SetData(21, 11, "EngTaf");
                FlxFiles.SetData(22, 1, "الأجمالي بالحروف عربي");
                FlxFiles.SetData(22, 11, "ArbTaf");
                FlxFiles.SetData(23, 1, "تكلفة الفاتورة");
                FlxFiles.SetData(23, 11, "InvCost");
                FlxFiles.SetData(24, 1, "رقم الصنف");
                FlxFiles.SetData(24, 11, "ItmNo");
                FlxFiles.SetData(25, 1, "وصف الصنف عربي");
                FlxFiles.SetData(25, 11, "ItmDes");
                FlxFiles.SetData(26, 1, "وصف الصنف أنجليزي");
                FlxFiles.SetData(26, 11, "ItmDesE");
                FlxFiles.SetData(27, 1, "المستودع");
                FlxFiles.SetData(27, 11, "StoreNo");
                FlxFiles.SetData(28, 1, "الوحدة عربي");
                FlxFiles.SetData(28, 11, "ItmUnt");
                FlxFiles.SetData(29, 1, "الوحدة أنجليزي");
                FlxFiles.SetData(29, 11, "ItmUntE");
                FlxFiles.SetData(30, 1, "العبوة");
                FlxFiles.SetData(30, 11, "ItmUntPak");
                FlxFiles.SetData(31, 1, "الكمية");
                FlxFiles.SetData(31, 11, "QtyAbs");
                FlxFiles.SetData(32, 1, "السعر");
                FlxFiles.SetData(32, 11, "Price");
                FlxFiles.SetData(33, 1, "الأجمالي - سطور");
                FlxFiles.SetData(33, 11, "Amount");
                FlxFiles.SetData(34, 1, "تكلفة الصنف");
                FlxFiles.SetData(34, 11, "Cost");
                FlxFiles.SetData(35, 1, "أسم الفاتورة عربي");
                FlxFiles.SetData(35, 11, "InvNamA");
                FlxFiles.SetData(36, 1, "أسم الفاتورة أنجليزي");
                FlxFiles.SetData(36, 11, "InvNamE");
                FlxFiles.SetData(37, 1, "رقم الصفحة");
                FlxFiles.SetData(37, 11, "PageNo");
                FlxFiles.SetData(38, 1, "الرقم التسلسلي");
                FlxFiles.SetData(38, 11, "InvSer");
                FlxFiles.SetData(39, 1, "أجمالي الكمية");
                FlxFiles.SetData(39, 11, "InvQty");
                FlxFiles.SetData(40, 1, "خصم الصنف - نسبة");
                FlxFiles.SetData(40, 11, "ItmDis");
                FlxFiles.SetData(41, 1, "الوزن");
                FlxFiles.SetData(41, 11, "InvWight_T");
                FlxFiles.SetData(42, 1, "اسم المستودع انجليزي");
                FlxFiles.SetData(42, 11, "PageTotelE");
                FlxFiles.SetData(43, 1, "الوقت");
                FlxFiles.SetData(43, 11, "LTim");
                FlxFiles.SetData(44, 1, "إسم المستودع عربي");
                FlxFiles.SetData(44, 11, "PageTotel");
                FlxFiles.SetData(45, 1, "أسم المستخدم");
                FlxFiles.SetData(45, 11, "SalsManNam");
                FlxFiles.SetData(46, 1, "المدفوع نقدا\u0651");
                FlxFiles.SetData(46, 11, "CashPayLocCur");
                FlxFiles.SetData(47, 1, "المدفوع آجل");
                FlxFiles.SetData(47, 11, "CreditPayLocCur");
                FlxFiles.SetData(48, 1, "المدفوع شبكة");
                FlxFiles.SetData(48, 11, "NetworkPayLocCur");
                FlxFiles.SetData(49, 1, "سيريال الصنف");
                FlxFiles.SetData(49, 11, "Serial_Key");
                FlxFiles.SetData(50, 1, "تفاصيل اخرى");
                FlxFiles.SetData(50, 11, "LineDetails");
                FlxFiles.SetData(51, 1, "تاريخ الصلاحية");
                FlxFiles.SetData(51, 11, "DatExper");
                FlxFiles.SetData(52, 1, "رقم التصنيع");
                FlxFiles.SetData(52, 11, "RunCod");
                FlxFiles.SetData(53, 1, "المتبقي");
                FlxFiles.SetData(53, 11, "Remming");
                FlxFiles.SetData(54, 1, "تاريخ الإستحقاق");
                FlxFiles.SetData(54, 11, "EstDat");
                FlxFiles.SetData(55, 1, "نسبة الضريبة - سطور");
                FlxFiles.SetData(55, 11, "ItmTax");
                FlxFiles.SetData(56, 1, "إجمالي الضريبة");
                FlxFiles.SetData(56, 11, "InvAddTax");
                FlxFiles.SetData(57, 1, "الرقم الضريبي");
                FlxFiles.SetData(57, 11, "TaxAcc");
                FlxFiles.SetData(58, 1, "مبلغ الضريبة - سطور");
                FlxFiles.SetData(58, 11, "TaxValue");
                FlxFiles.SetData(59, 1, "الرقم الضريبي - عميل مورد");
                FlxFiles.SetData(59, 11, "TaxCustNo");
                FlxFiles.SetData(60, 1, "الملاحظة بالضريبة");
                FlxFiles.SetData(60, 11, "TaxNoteInv");
                FlxFiles.SetData(61, 1, "اجمالي الفاتورة بدون الضريبة - ذيل");
                FlxFiles.SetData(61, 11, "TotWithTaxPoint");
                FlxFiles.SetData(62, 1, "جوال العميل");
                FlxFiles.SetData(62, 11, "Mobile");
                FlxFiles.SetData(63, 1, "الشخص المسؤول");
                FlxFiles.SetData(63, 11, "PersonalNm");
                FlxFiles.SetData(64, 1, "المدينة");
                FlxFiles.SetData(64, 11, "City");
                FlxFiles.SetData(65, 1, "الإيميل");
                FlxFiles.SetData(65, 11, "Email");
                FlxFiles.SetData(66, 1, "حقل1");
                FlxFiles.SetData(66, 11, "tailor1");
                FlxFiles.SetData(67, 1, "حقل2");
                FlxFiles.SetData(67, 11, "tailor2");
                FlxFiles.SetData(68, 1, "حقل3");
                FlxFiles.SetData(68, 11, "tailor3");
                FlxFiles.SetData(69, 1, "حقل4");
                FlxFiles.SetData(69, 11, "tailor4");
                FlxFiles.SetData(70, 1, "حقل5");
                FlxFiles.SetData(70, 11, "tailor5");
                FlxFiles.SetData(71, 1, "حقل6");
                FlxFiles.SetData(71, 11, "tailor6");
                FlxFiles.SetData(72, 1, "حقل7");
                FlxFiles.SetData(72, 11, "tailor7");
                FlxFiles.SetData(73, 1, "حقل8");
                FlxFiles.SetData(73, 11, "tailor8");
                FlxFiles.SetData(74, 1, "حقل9");
                FlxFiles.SetData(74, 11, "tailor9");
                FlxFiles.SetData(75, 1, "حقل10");
                FlxFiles.SetData(75, 11, "tailor10");
                FlxFiles.SetData(76, 1, "حقل11");
                FlxFiles.SetData(76, 11, "tailor11");
                FlxFiles.SetData(77, 1, "حقل12");
                FlxFiles.SetData(77, 11, "tailor12");
                FlxFiles.SetData(78, 1, "حقل13");
                FlxFiles.SetData(78, 11, "tailor13");
                FlxFiles.SetData(79, 1, "حقل14");
                FlxFiles.SetData(79, 11, "tailor14");
                FlxFiles.SetData(80, 1, "حقل15");
                FlxFiles.SetData(80, 11, "tailor15");
                FlxFiles.SetData(81, 1, "حقل16");
                FlxFiles.SetData(81, 11, "tailor16");
                FlxFiles.SetData(82, 1, "حقل17");
                FlxFiles.SetData(82, 11, "tailor17");
                FlxFiles.SetData(83, 1, "حقل18");
                FlxFiles.SetData(83, 11, "tailor18");
                FlxFiles.SetData(84, 1, "حقل19");
                FlxFiles.SetData(84, 11, "tailor19");
                FlxFiles.SetData(85, 1, "حقل20");
                FlxFiles.SetData(85, 11, "tailor20");
                FlxFiles.SetData(86, 1, "صورة");
                FlxFiles.SetData(86, 11, "InvImg");
                FlxFiles.SetData(87, 1, "إجمالي السطر بدون ضريبة");
                FlxFiles.SetData(87, 11, "TotBeforeTax");
                FlxFiles.SetData(88, 1, "رقم الحاوية");
                FlxFiles.SetData(88, 11, "MODIFIED_BY");
                FlxFiles.SetData(89, 1, "عدد الايام المتبقي");
                FlxFiles.SetData(89, 11, "EstDatNote");
                FlxFiles.SetData(90, 1, "اسم عميل/مورد انجليزي");
                FlxFiles.SetData(90, 11, "CusVenNmE");
                FlxFiles.SetData(91, 1, "خصم الصنف - قيمة");
                FlxFiles.SetData(91, 11, "ItmDisVal");
                FlxFiles.SetData(92, 1, "إجمالي الفاتورة بعد الخصم قيمة");
                FlxFiles.SetData(92, 11, "TotBeforeDisVal");
                FlxFiles.SetData(93, 1, "صافي الفاتورة بدون الضريبة - ذيل");
                FlxFiles.SetData(93, 11, "NetWithoutTax");
                FlxFiles.SetData(94, 1, "QR CODE ");
                FlxFiles.SetData(94, 11, "Table.LogImg");

                try
                {
                    if (File.Exists(Application.StartupPath + "\\Script\\Secriptjustlight.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", "").Trim() + "\\Secriptjustlight.dll")))
                    {
                        FlxFiles.SetData(64, 1, "الجنسية");
                        FlxFiles.SetData(65, 1, "رقم الهوية");
                        FlxFiles.SetData(86, 1, "البصمة");
                        FlxFiles.SetData(88, 1, "مبلغ السند");
                        FlxFiles.SetData(59, 1, "المصدر");
                    }
                }
                catch
                {
                }
                CmbInvType.Items.Clear();
                for (int iiCnt = 0; iiCnt < listInvSetting.Count; iiCnt++)
                {
                    _InvSetting = listInvSetting[iiCnt];
                    if (_InvSetting.InvID != -101)
                    {
                        if (_InvSetting.InvSetting != "1" && int.Parse(_InvSetting.InvSetting.ToString()) < 400 && !_InvSetting.CatID.HasValue)
                        {
                            CmbInvType.Items.Add(new Item(_InvSetting.InvNamA.Trim(), int.Parse(_InvSetting.InvID.ToString())));
                        }
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
            FlxFiles.Rows.Count = 95;
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
            fontString = "";
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
            FlxFiles.SetData(1, 0, "Invoice Type");
            FlxFiles.SetData(1, 11, "InvTyp");
            FlxFiles.SetData(2, 0, "Invoice No");
            FlxFiles.SetData(2, 11, "InvNo");
            FlxFiles.SetData(3, 0, "Pay Mode");
            FlxFiles.SetData(3, 11, "InvCash");
            FlxFiles.SetData(4, 0, "H Date");
            FlxFiles.SetData(4, 11, "HDat");
            FlxFiles.SetData(5, 0, "G Date");
            FlxFiles.SetData(5, 11, "GDat");
            FlxFiles.SetData(6, 0, "Customer / Supp No");
            FlxFiles.SetData(6, 11, "CusVenNo");
            FlxFiles.SetData(7, 0, "Customer / Supp Name");
            FlxFiles.SetData(7, 11, "CusVenNm");
            FlxFiles.SetData(8, 0, "Telephone");
            FlxFiles.SetData(8, 11, "CusVenTel");
            FlxFiles.SetData(9, 0, "Address");
            FlxFiles.SetData(9, 11, "CusVenAdd");
            FlxFiles.SetData(10, 0, "Legate Arabic");
            FlxFiles.SetData(10, 11, "Mndob_Arb_Des");
            FlxFiles.SetData(11, 0, "Legate English");
            FlxFiles.SetData(11, 11, "Mndob_Eng_Des");
            FlxFiles.SetData(12, 0, "Cost Center Arabic");
            FlxFiles.SetData(12, 11, "CstTbl_Arb_Des");
            FlxFiles.SetData(13, 0, "Cost Center English");
            FlxFiles.SetData(13, 11, "CstTbl_Eng_Des");
            FlxFiles.SetData(14, 0, "Note");
            FlxFiles.SetData(14, 11, "Remark");
            FlxFiles.SetData(15, 0, "Reference");
            FlxFiles.SetData(15, 11, "RefNo");
            FlxFiles.SetData(16, 0, "Total Amount");
            FlxFiles.SetData(16, 11, "InvTotLocCur");
            FlxFiles.SetData(17, 0, "Payment");
            FlxFiles.SetData(17, 11, "Puyaid");
            FlxFiles.SetData(18, 0, "Discount");
            FlxFiles.SetData(18, 11, "InvDisVal");
            FlxFiles.SetData(19, 0, "Discount %");
            FlxFiles.SetData(19, 11, "InvDisPrs");
            FlxFiles.SetData(20, 0, "Due Amount");
            FlxFiles.SetData(20, 11, "InvNetLocCur");
            FlxFiles.SetData(21, 0, "Script Number English");
            FlxFiles.SetData(21, 11, "EngTaf");
            FlxFiles.SetData(22, 0, "Script Number Arabic");
            FlxFiles.SetData(22, 11, "ArbTaf");
            FlxFiles.SetData(23, 0, "Invoice Cost");
            FlxFiles.SetData(23, 11, "InvCost");
            FlxFiles.SetData(24, 0, "Item No");
            FlxFiles.SetData(24, 11, "ItmNo");
            FlxFiles.SetData(25, 0, "Item Desc Arabic");
            FlxFiles.SetData(25, 11, "ItmDes");
            FlxFiles.SetData(26, 0, "Item Desc English");
            FlxFiles.SetData(26, 11, "ItmDesE");
            FlxFiles.SetData(27, 0, "Store");
            FlxFiles.SetData(27, 11, "StoreNo");
            FlxFiles.SetData(28, 0, "Unit Arabic");
            FlxFiles.SetData(28, 11, "ItmUnt");
            FlxFiles.SetData(29, 0, "Unit English");
            FlxFiles.SetData(29, 11, "ItmUntE");
            FlxFiles.SetData(30, 0, "Pack");
            FlxFiles.SetData(30, 11, "ItmUntPak");
            FlxFiles.SetData(31, 0, "Quantity");
            FlxFiles.SetData(31, 11, "QtyAbs");
            FlxFiles.SetData(32, 0, "Price");
            FlxFiles.SetData(32, 11, "Price");
            FlxFiles.SetData(33, 0, "Total");
            FlxFiles.SetData(33, 11, "Amount");
            FlxFiles.SetData(34, 0, "Item Cost");
            FlxFiles.SetData(34, 11, "Cost");
            FlxFiles.SetData(35, 0, "Invoice Name Arabic");
            FlxFiles.SetData(35, 11, "InvNamA");
            FlxFiles.SetData(36, 0, "Invoice Name English");
            FlxFiles.SetData(36, 11, "InvNamE");
            FlxFiles.SetData(37, 0, "Page No");
            FlxFiles.SetData(37, 11, "PageNo");
            FlxFiles.SetData(38, 0, "Serial No");
            FlxFiles.SetData(38, 11, "InvSer");
            FlxFiles.SetData(39, 0, "Total Quantity");
            FlxFiles.SetData(39, 11, "InvQty");
            FlxFiles.SetData(40, 0, "Item Discount");
            FlxFiles.SetData(40, 11, "ItmDis");
            FlxFiles.SetData(41, 0, "Wight");
            FlxFiles.SetData(41, 11, "InvWight_T");
            FlxFiles.SetData(42, 0, "Store Name English");
            FlxFiles.SetData(42, 11, "PageTotelE");
            FlxFiles.SetData(43, 0, "Time");
            FlxFiles.SetData(43, 11, "LTim");
            FlxFiles.SetData(44, 0, "Store Name Arabic");
            FlxFiles.SetData(44, 11, "PageTotel");
            FlxFiles.SetData(45, 0, "User Name");
            FlxFiles.SetData(45, 11, "SalsManNam");
            FlxFiles.SetData(46, 0, "Puaid Cash");
            FlxFiles.SetData(46, 11, "CashPayLocCur");
            FlxFiles.SetData(47, 0, "Puaid Credit");
            FlxFiles.SetData(47, 11, "CreditPayLocCur");
            FlxFiles.SetData(48, 0, "Puaid NetWork");
            FlxFiles.SetData(48, 11, "NetworkPayLocCur");
            FlxFiles.SetData(49, 0, "Serial");
            FlxFiles.SetData(49, 11, "Serial_Key");
            FlxFiles.SetData(50, 0, "Details Other");
            FlxFiles.SetData(50, 11, "LineDetails");
            FlxFiles.SetData(51, 0, "Expir Date");
            FlxFiles.SetData(51, 11, "DatExper");
            FlxFiles.SetData(52, 0, "Run No");
            FlxFiles.SetData(52, 11, "RunCod");
            FlxFiles.SetData(53, 1, "المتبقي");
            FlxFiles.SetData(53, 11, "Remming");
            FlxFiles.SetData(54, 1, "تاريخ الإستحقاق");
            FlxFiles.SetData(54, 11, "EstDat");
            FlxFiles.SetData(55, 1, "قيمة الضريبة");
            FlxFiles.SetData(55, 11, "ItmTax");
            FlxFiles.SetData(56, 1, "إجمالي الضريبة");
            FlxFiles.SetData(56, 11, "InvAddTax");
            FlxFiles.SetData(57, 1, "الرقم الضريبي");
            FlxFiles.SetData(57, 11, "TaxAcc");
            FlxFiles.SetData(58, 1, "مبلغ الضريبة - سطور");
            FlxFiles.SetData(58, 11, "TaxValue");
            FlxFiles.SetData(59, 1, "الرقم الضريبي - عميل مورد");
            FlxFiles.SetData(59, 11, "TaxCustNo");
            FlxFiles.SetData(60, 1, "الملاحظة بالضريبة");
            FlxFiles.SetData(60, 11, "TaxNoteInv");
            FlxFiles.SetData(61, 1, "اجمالي الفاتورة بدون الضريبة - ذيل");
            FlxFiles.SetData(61, 11, "TotWithTaxPoint");
            FlxFiles.SetData(62, 1, "جوال العميل");
            FlxFiles.SetData(62, 11, "Mobile");
            FlxFiles.SetData(63, 1, "الشخص المسؤول");
            FlxFiles.SetData(63, 11, "PersonalNm");
            FlxFiles.SetData(64, 1, "المدينة");
            FlxFiles.SetData(64, 11, "City");
            FlxFiles.SetData(65, 1, "الإيميل");
            FlxFiles.SetData(65, 11, "Email");
            FlxFiles.SetData(66, 1, "حقل1");
            FlxFiles.SetData(66, 11, "tailor1");
            FlxFiles.SetData(67, 1, "حقل2");
            FlxFiles.SetData(67, 11, "tailor2");
            FlxFiles.SetData(68, 1, "حقل3");
            FlxFiles.SetData(68, 11, "tailor3");
            FlxFiles.SetData(69, 1, "حقل4");
            FlxFiles.SetData(69, 11, "tailor4");
            FlxFiles.SetData(70, 1, "حقل5");
            FlxFiles.SetData(70, 11, "tailor5");
            FlxFiles.SetData(71, 1, "حقل6");
            FlxFiles.SetData(71, 11, "tailor6");
            FlxFiles.SetData(72, 1, "حقل7");
            FlxFiles.SetData(72, 11, "tailor7");
            FlxFiles.SetData(73, 1, "حقل8");
            FlxFiles.SetData(73, 11, "tailor8");
            FlxFiles.SetData(74, 1, "حقل9");
            FlxFiles.SetData(74, 11, "tailor9");
            FlxFiles.SetData(75, 1, "حقل10");
            FlxFiles.SetData(75, 11, "tailor10");
            FlxFiles.SetData(76, 1, "حقل11");
            FlxFiles.SetData(76, 11, "tailor11");
            FlxFiles.SetData(77, 1, "حقل12");
            FlxFiles.SetData(77, 11, "tailor12");
            FlxFiles.SetData(78, 1, "حقل13");
            FlxFiles.SetData(78, 11, "tailor13");
            FlxFiles.SetData(79, 1, "حقل14");
            FlxFiles.SetData(79, 11, "tailor14");
            FlxFiles.SetData(80, 1, "حقل15");
            FlxFiles.SetData(80, 11, "tailor15");
            FlxFiles.SetData(81, 1, "حقل16");
            FlxFiles.SetData(81, 11, "tailor16");
            FlxFiles.SetData(82, 1, "حقل17");
            FlxFiles.SetData(82, 11, "tailor17");
            FlxFiles.SetData(83, 1, "حقل18");
            FlxFiles.SetData(83, 11, "tailor18");
            FlxFiles.SetData(84, 1, "حقل19");
            FlxFiles.SetData(84, 11, "tailor19");
            FlxFiles.SetData(85, 1, "حقل20");
            FlxFiles.SetData(85, 11, "tailor20");
            FlxFiles.SetData(86, 1, "صورة");
            FlxFiles.SetData(86, 11, "InvImg");
            FlxFiles.SetData(87, 1, "إجمالي السطر بدون ضريبة");
            FlxFiles.SetData(87, 11, "TotBeforeTax");
            FlxFiles.SetData(88, 1, "رقم الحاوية");
            FlxFiles.SetData(88, 11, "MODIFIED_BY");
            FlxFiles.SetData(89, 1, "عدد الايام المتبقي");
            FlxFiles.SetData(89, 11, "EstDatNote");
            FlxFiles.SetData(90, 1, "اسم عميل/مورد انجليزي");
            FlxFiles.SetData(90, 11, "CusVenNmE");
            FlxFiles.SetData(91, 1, "خصم الصنف - قيمة");
            FlxFiles.SetData(91, 11, "ItmDisVal");
            FlxFiles.SetData(92, 1, "إجمالي الفاتورة بعد الخصم قيمة");
            FlxFiles.SetData(92, 11, "TotBeforeDisVal");
            FlxFiles.SetData(93, 1, "صافي الفاتورة بدون الضريبة - ذيل");
            FlxFiles.SetData(93, 11, "NetWithoutTax");
            try
            {
                if (File.Exists(Application.StartupPath + "\\Script\\Secriptjustlight.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", "").Trim() + "\\Secriptjustlight.dll")))
                {
                    FlxFiles.SetData(64, 1, "الجنسية");
                    FlxFiles.SetData(65, 1, "رقم الهوية");
                    FlxFiles.SetData(86, 1, "البصمة");
                    FlxFiles.SetData(88, 1, "مبلغ السند");
                    FlxFiles.SetData(59, 1, "المصدر");
                }
            }
            catch
            {
            }
            CmbInvType.Items.Clear();
            for (int iiCnt = 0; iiCnt < listInvSetting.Count; iiCnt++)
            {
                _InvSetting = listInvSetting[iiCnt];
                if (_InvSetting.InvSetting != "1" && int.Parse(_InvSetting.InvSetting.ToString()) < 400)
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
                string ntyp = "";
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
                _InvSetting.InvpRINTERInfo.hAs = double.Parse(VarGeneral.TString.TEmpty(txtBottM.Text ?? ""));
                _InvSetting.InvpRINTERInfo.hYs = double.Parse(VarGeneral.TString.TEmpty(txtLeftM.Text ?? ""));
                _InvSetting.InvpRINTERInfo.lnPg = double.Parse(VarGeneral.TString.TEmpty(txtLinePage.Text ?? ""));
                _InvSetting.InvpRINTERInfo.hYm = double.Parse(VarGeneral.TString.TEmpty(txtRight.Text ?? ""));
                _InvSetting.InvpRINTERInfo.hAl = double.Parse(VarGeneral.TString.TEmpty(txtTopM.Text ?? ""));
                _InvSetting.InvpRINTERInfo.lnSpc = double.Parse(VarGeneral.TString.TEmpty(txtDistance.Text ?? ""));
                _InvSetting.defPrn = CmbPrinter.Text ?? "";
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
                    _mInvPrint.repNum = 3;
                    listmInvPrintSave.Add(_mInvPrint);
                }
                for (int q = 0; q < listmInvPrintSave.Count; q++)
                {
                    db.T_mInvPrints.InsertOnSubmit(listmInvPrintSave[q]);
                    db.SubmitChanges();
                }
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
        private void SSSFMInvPrintSetup_Load(object sender, EventArgs e)
        {
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
    }
}
