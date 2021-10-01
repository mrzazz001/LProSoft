using C1.Win.C1FlexGrid;
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
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FMBarCodeUserInv : Form
    { void avs(int arln)

{ 
 button1.Text=   (arln == 0 ? "  شكل توضيح  " : "  illustration shape") ; label7.Text=   (arln == 0 ? "  الإرتفاع بين كروت الباركود :  " : "  Height between barcode cards:") ; label10.Text=   (arln == 0 ? "  هامش يسار :  " : "  left margin:") ; label5.Text=   (arln == 0 ? "  الإرتفـــاع :  " : "  Height:") ; label4.Text=   (arln == 0 ? "  العـــرض :  " : "  Presentation:") ; label6.Text=   (arln == 0 ? "  البعد العرضي بين كروت الباركود :  " : "  The transverse dimension between the barcode cards:") ; label1.Text=   (arln == 0 ? "  اختيار الطابعة :  " : "  Printer selection:") ; label2.Text=   (arln == 0 ? "  هامش اعلى :  " : "  higher margin:") ; label33.Text=   (arln == 0 ? "  عدد النسخ :  " : "  Number of copies :") ; label9.Text=   (arln == 0 ? "  عدد الكروت عرضيا :  " : "  Number of cross cards:") ; label8.Text=   (arln == 0 ? "  عدد الكروت طوليا :  " : "  Number of cards longitudinally:") ; ButWithoutSave.Text=   (arln == 0 ? "  خــــروج Esc  " : "  Esc . Exit") ; ButWithSave.Text=   (arln == 0 ? "  حفــــظ F2  " : "  Save F2") ; labelX1.Text=   (arln == 0 ? "  إعدادات طباعة الباركود  " : "  Barcode printing settings") ;}
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
        private List<T_mInvPrint> listmInvPrint = new List<T_mInvPrint>();
        private T_mInvPrint _mInvPrint = new T_mInvPrint();
        private Item _item = new Item("", 0);
#pragma warning disable CS0414 // The field 'FMBarCodeUserInv.ItemIndex' is assigned but its value is never used
        private int ItemIndex = 0;
#pragma warning restore CS0414 // The field 'FMBarCodeUserInv.ItemIndex' is assigned but its value is never used
        private int LangArEn = 0;
        private Stock_DataDataContext dbInstance;
       // private IContainer components = null;
        private ComboBox CmbPrintP2;
        private Button button1;
        private ComboBox CmbPrintP;
        private ComboBox CmbDir;
        private RibbonBar ribbonBar1;
        private C1FlexGrid FlxFiles;
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
        private ComboBox CmbUnit;
        private ComboBox CmbInvType;
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
        public FMBarCodeUserInv()
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FMBarCodeUserInv));
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
            CmbInvType.SelectedIndex = 0;
            FillCombo();
            BindData();
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FMBarCodeUserInv));
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
        private void BindData()
        {
            try
            {
                for (int iiCnt = 0; iiCnt < listInvSetting.Count; iiCnt++)
                {
                    _InvSetting = listInvSetting[iiCnt];
                    if (_InvSetting.InvID == 22)
                    {
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
                        break;
                    }
                }
                listmInvPrint = (from item in db.T_mInvPrints
                                 where item.repTyp == (int?)22
                                 where item.repNum == (int?)4
                                 where item.BarcodeTyp == (int?)(CmbInvType.SelectedIndex + 2)
                                 select item).ToList();
                if (listmInvPrint.Count != 0)
                {
                    try
                    {
                        for (int i = 0; i < CmbUnit.Items.Count; i++)
                        {
                            CmbUnit.SelectedIndex = i;
                            if (CmbUnit.Text.ToString().ToUpper().Trim() == listmInvPrint[0].uChr.ToString().ToUpper().Trim())
                            {
                                break;
                            }
                        }
                    }
                    catch
                    {
                        CmbUnit.SelectedIndex = 0;
                    }
                    for (int iiCnt = 1; iiCnt <= listmInvPrint.Count; iiCnt++)
                    {
                        _mInvPrint = listmInvPrint[iiCnt - 1];
                        if ((_mInvPrint.pField ?? "").ToString() == string.Concat(FlxFiles.GetData(iiCnt, 12)))
                        {
                            FlxFiles.SetData(iiCnt, 2, VarGeneral.TString.ChkStatShow(VarGeneral.TString.TEmpty(string.Concat(_mInvPrint.IsPrint)), 0));
                            FlxFiles.SetData(iiCnt, 3, _mInvPrint.vRow);
                            FlxFiles.SetData(iiCnt, 4, _mInvPrint.vCol);
                            FlxFiles.SetData(iiCnt, 13, _mInvPrint.vEt);
                            CmbDir.SelectedIndex = int.Parse(VarGeneral.TString.TEmpty(string.Concat(_mInvPrint.vEt)));
                            FlxFiles.SetData(iiCnt, 5, CmbDir.Text);
                            FlxFiles.SetData(iiCnt, 14, _mInvPrint.IsPrntHd);
                            CmbPrintP.SelectedIndex = int.Parse(VarGeneral.TString.TEmpty(string.Concat(_mInvPrint.IsPrntHd)));
                            FlxFiles.SetData(iiCnt, 6, CmbPrintP.Text);
                            FlxFiles.SetData(iiCnt, 7, _mInvPrint.MaxW);
                            FlxFiles.SetData(iiCnt, 15, _mInvPrint.nTyp);
                            CmbPrintP2.SelectedIndex = int.Parse(VarGeneral.TString.TEmpty(string.Concat(_mInvPrint.nTyp)));
                            FlxFiles.SetData(iiCnt, 11, CmbPrintP2.Text);
                            FlxFiles.SetData(iiCnt, 8, _mInvPrint.vFont);
                            FlxFiles.SetData(iiCnt, 9, _mInvPrint.vSize);
                            FlxFiles.SetData(iiCnt, 10, VarGeneral.TString.ChkStatShow(VarGeneral.TString.TEmpty(string.Concat(_mInvPrint.vBold)), 0));
                        }
                    }
                }
                else
                {
                    CmbUnit.SelectedIndex = 0;
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
                FlxFiles.Rows.Count = 43;
                FlxFiles.Cols[0].Visible = false;
                FlxFiles.Cols[1].Visible = true;
                FlxFiles.SetData(0, 0, "Filed");
                FlxFiles.SetData(0, 1, "العنوان");
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
                FlxFiles.SetData(0, 7, "أقصى عرض");
                FlxFiles.SetData(0, 8, "الخط");
                InstalledFontCollection _font = new InstalledFontCollection();
                string fontString = "";
                for (int i = 0; i < _font.Families.Length; i++)
                {
                    fontString += _font.Families[i].Name;
                    fontString += "|";
                }
                FlxFiles.Cols[8].ComboList = fontString;
                FlxFiles.SetData(0, 9, "الحجم");
                FlxFiles.SetData(0, 10, "عريض");
                FlxFiles.SetData(0, 11, "موقع الطباعة 2");
                CmbPrintP2.Items.Clear();
                CmbPrintP2.Items.Add("كل صفحة");
                CmbPrintP2.Items.Add("الصفحة الأولى");
                CmbPrintP2.Items.Add("الصفحة الأخيرة");
                FlxFiles.Cols[11].Editor = CmbPrintP2;
                FlxFiles.SetData(1, 1, "أسم المنشأة");
                FlxFiles.SetData(1, 12, "CompanyName");
                FlxFiles.SetData(2, 1, "كود الصنف");
                FlxFiles.SetData(2, 12, "ItmNo");
                FlxFiles.SetData(3, 1, "إسم الصنف عربي");
                FlxFiles.SetData(3, 12, "ItmDes");
                FlxFiles.SetData(4, 1, "إسم الصنف انجليزي");
                FlxFiles.SetData(4, 12, "ItmDesE");
                FlxFiles.SetData(5, 1, "الكمية");
                FlxFiles.SetData(5, 12, "Qty");
                FlxFiles.SetData(6, 1, "الوحدة عربي");
                FlxFiles.SetData(6, 12, "ItmUnt");
                FlxFiles.SetData(7, 1, "الوحدة انجليزي");
                FlxFiles.SetData(7, 12, "ItmUntE");
                FlxFiles.SetData(8, 1, "السعر");
                FlxFiles.SetData(8, 12, "Price");
                FlxFiles.SetData(9, 1, "تفاصيل اخرى");
                FlxFiles.SetData(9, 12, "LineDetails");
                FlxFiles.SetData(10, 1, "باركود رقم الصنف");
                FlxFiles.SetData(10, 12, "ItmBarC");
                FlxFiles.SetData(11, 1, "باركود رقم الفاتورة");
                FlxFiles.SetData(11, 12, "InvNo");
                FlxFiles.SetData(12, 1, "رقم العميل");
                FlxFiles.SetData(12, 12, "CusVenNo");
                FlxFiles.SetData(13, 1, "إسم العميل");
                FlxFiles.SetData(13, 12, "CusVenNm");
                FlxFiles.SetData(14, 1, "تاريخ الفاتورة هجري");
                FlxFiles.SetData(14, 12, "HDat");
                FlxFiles.SetData(15, 1, "تاريخ الفاتورة ميلادي");
                FlxFiles.SetData(15, 12, "GDat");
                FlxFiles.SetData(16, 1, "سعر بيع الصنف");
                FlxFiles.SetData(16, 12, "ItmPrice");
                FlxFiles.SetData(17, 1, "الملاحظات");
                FlxFiles.SetData(17, 12, "Remark");
                FlxFiles.SetData(18, 1, "المدفوع");
                FlxFiles.SetData(18, 12, "Puyaid");
                FlxFiles.SetData(19, 1, "المتبقي");
                FlxFiles.SetData(19, 12, "Remming");
                FlxFiles.SetData(20, 1, "تاريخ الإستحقاق");
                FlxFiles.SetData(20, 12, "EstDat");
                FlxFiles.SetData(21, 1, "رقم التصنيع");
                FlxFiles.SetData(21, 12, "RunCod");
                FlxFiles.SetData(22, 1, "رقم المرجع");
                FlxFiles.SetData(22, 12, "RefNo");
                FlxFiles.SetData(23, 1, "الترويسة 1 - عربي");
                FlxFiles.SetData(23, 12, "rTrwes1");
                FlxFiles.SetData(24, 1, "الترويسة 2 - عربي");
                FlxFiles.SetData(24, 12, "rTrwes2");
                FlxFiles.SetData(25, 1, "الترويسة 3 - عربي");
                FlxFiles.SetData(25, 12, "rTrwes3");
                FlxFiles.SetData(26, 1, "الترويسة 4 - عربي");
                FlxFiles.SetData(26, 12, "rTrwes4");
                FlxFiles.SetData(27, 1, "الترويسة 1 - إنجليزي");
                FlxFiles.SetData(27, 12, "lTrwes1");
                FlxFiles.SetData(28, 1, "الترويسة 2 - إنجليزي");
                FlxFiles.SetData(28, 12, "lTrwes2");
                FlxFiles.SetData(29, 1, "الترويسة 3 - إنجليزي");
                FlxFiles.SetData(29, 12, "lTrwes3");
                FlxFiles.SetData(30, 1, "الترويسة 4 - إنجليزي");
                FlxFiles.SetData(30, 12, "lTrwes4");
                FlxFiles.SetData(31, 1, "عنوان العميل");
                FlxFiles.SetData(31, 12, "CusVenAdd");
                FlxFiles.SetData(32, 1, "إسم المستخدم");
                FlxFiles.SetData(32, 12, "SalsManNam");
                FlxFiles.SetData(33, 1, "تاريخ الصلاحية");
                FlxFiles.SetData(33, 12, "DatExper");
                FlxFiles.SetData(34, 1, "الملاحظة بالضريبة");
                FlxFiles.SetData(34, 12, "TaxNoteInv");
                FlxFiles.SetData(35, 1, "العمر");
                FlxFiles.SetData(35, 12, "vColStr1");
                FlxFiles.SetData(36, 1, "إسم المريض - كتابة");
                FlxFiles.SetData(36, 12, "pationName_W");
                FlxFiles.SetData(37, 1, "إسم الدواء - كتابة");
                FlxFiles.SetData(37, 12, "medicinName_W");
                FlxFiles.SetData(38, 1, "تاريخ الصلاحية - كتابة");
                FlxFiles.SetData(38, 12, "ExpirDate_W");
                FlxFiles.SetData(39, 1, "طريقة الإستخدام - كتابة");
                FlxFiles.SetData(39, 12, "UseMethod_W");
                FlxFiles.SetData(40, 1, "العمر - كتابة");
                FlxFiles.SetData(40, 12, "Age_W");
                FlxFiles.SetData(41, 1, "تاريخ الانتاج: ");
                FlxFiles.SetData(41, 12, "ProductionDate");
                FlxFiles.SetData(42, 1, "تاريخ الانتهاء ");
                FlxFiles.SetData(42, 12, "ExpirationDate");
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
                FlxFiles.Rows.Count =
                    43;
                FlxFiles.Cols[0].Visible = true;
                FlxFiles.Cols[1].Visible = false;
                FlxFiles.SetData(0, 0, "Filed");
                FlxFiles.SetData(0, 1, "العنوان");
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
                FlxFiles.SetData(0, 7, "With");
                FlxFiles.SetData(0, 8, "Font");
                InstalledFontCollection _font = new InstalledFontCollection();
                string fontString = "";
                for (int i = 0; i < _font.Families.Length; i++)
                {
                    fontString += _font.Families[i].Name;
                    fontString += "|";
                }
                FlxFiles.Cols[8].ComboList = fontString;
                FlxFiles.SetData(0, 9, "Size");
                FlxFiles.SetData(0, 10, "Bold");
                FlxFiles.SetData(0, 11, "Print Place 2");
                CmbPrintP2.Items.Clear();
                CmbPrintP2.Items.Add("All Page");
                CmbPrintP2.Items.Add("Frist Page");
                CmbPrintP2.Items.Add("Last Page");
                FlxFiles.Cols[11].Editor = CmbPrintP2;
                FlxFiles.SetData(1, 1, "أسم المنشأة");
                FlxFiles.SetData(1, 12, "CompanyName");
                FlxFiles.SetData(2, 1, "كود الصنف");
                FlxFiles.SetData(2, 12, "ItmNo");
                FlxFiles.SetData(3, 1, "إسم الصنف عربي");
                FlxFiles.SetData(3, 12, "ItmDes");
                FlxFiles.SetData(4, 1, "إسم الصنف انجليزي");
                FlxFiles.SetData(4, 12, "ItmDesE");
                FlxFiles.SetData(5, 1, "الكمية");
                FlxFiles.SetData(5, 12, "Qty");
                FlxFiles.SetData(6, 1, "الوحدة عربي");
                FlxFiles.SetData(6, 12, "ItmUnt");
                FlxFiles.SetData(7, 1, "الوحدة انجليزي");
                FlxFiles.SetData(7, 12, "ItmUntE");
                FlxFiles.SetData(8, 1, "السعر");
                FlxFiles.SetData(8, 12, "Price");
                FlxFiles.SetData(9, 1, "تفاصيل اخرى");
                FlxFiles.SetData(9, 12, "LineDetails");
                FlxFiles.SetData(10, 1, "باركود رقم الصنف");
                FlxFiles.SetData(10, 12, "ItmBarC");
                FlxFiles.SetData(11, 1, "باركود رقم الفاتورة");
                FlxFiles.SetData(11, 12, "InvNo");
                FlxFiles.SetData(12, 1, "رقم العميل");
                FlxFiles.SetData(12, 12, "CusVenNo");
                FlxFiles.SetData(13, 1, "إسم العميل");
                FlxFiles.SetData(13, 12, "CusVenNm");
                FlxFiles.SetData(14, 1, "تاريخ الفاتورة هجري");
                FlxFiles.SetData(14, 12, "HDat");
                FlxFiles.SetData(15, 1, "تاريخ الفاتورة ميلادي");
                FlxFiles.SetData(15, 12, "GDat");
                FlxFiles.SetData(16, 1, "سعر بيع الصنف");
                FlxFiles.SetData(16, 12, "ItmPrice");
                FlxFiles.SetData(17, 1, "الملاحظات");
                FlxFiles.SetData(17, 12, "Remark");
                FlxFiles.SetData(18, 1, "المدفوع");
                FlxFiles.SetData(18, 12, "Puyaid");
                FlxFiles.SetData(19, 1, "المتبقي");
                FlxFiles.SetData(19, 12, "Remming");
                FlxFiles.SetData(20, 1, "تاريخ الإستحقاق");
                FlxFiles.SetData(20, 12, "EstDat");
                FlxFiles.SetData(21, 1, "رقم التصنيع");
                FlxFiles.SetData(21, 12, "RunCod");
                FlxFiles.SetData(22, 1, "رقم المرجع");
                FlxFiles.SetData(22, 12, "RefNo");
                FlxFiles.SetData(23, 1, "الترويسة 1 - عربي");
                FlxFiles.SetData(23, 12, "rTrwes1");
                FlxFiles.SetData(24, 1, "الترويسة 2 - عربي");
                FlxFiles.SetData(24, 12, "rTrwes2");
                FlxFiles.SetData(25, 1, "الترويسة 3 - عربي");
                FlxFiles.SetData(25, 12, "rTrwes3");
                FlxFiles.SetData(26, 1, "الترويسة 4 - عربي");
                FlxFiles.SetData(26, 12, "rTrwes4");
                FlxFiles.SetData(27, 1, "الترويسة 1 - إنجليزي");
                FlxFiles.SetData(27, 12, "lTrwes1");
                FlxFiles.SetData(28, 1, "الترويسة 2 - إنجليزي");
                FlxFiles.SetData(28, 12, "lTrwes2");
                FlxFiles.SetData(29, 1, "الترويسة 3 - إنجليزي");
                FlxFiles.SetData(29, 12, "lTrwes3");
                FlxFiles.SetData(30, 1, "الترويسة 4 - إنجليزي");
                FlxFiles.SetData(30, 12, "lTrwes4");
                FlxFiles.SetData(31, 1, "عنوان العميل");
                FlxFiles.SetData(31, 12, "CusVenAdd");
                FlxFiles.SetData(32, 1, "إسم المستخدم");
                FlxFiles.SetData(32, 12, "SalsManNam");
                FlxFiles.SetData(33, 1, "تاريخ الصلاحية");
                FlxFiles.SetData(33, 12, "DatExper");
                FlxFiles.SetData(34, 1, "الملاحظة بالضريبة");
                FlxFiles.SetData(34, 12, "TaxNoteInv");
                FlxFiles.SetData(35, 1, "العمر");
                FlxFiles.SetData(35, 12, "vColStr1");
                FlxFiles.SetData(36, 1, "إسم المريض - كتابة");
                FlxFiles.SetData(36, 12, "pationName_W");
                FlxFiles.SetData(37, 1, "إسم الدواء - كتابة");
                FlxFiles.SetData(37, 12, "medicinName_W");
                FlxFiles.SetData(38, 1, "تاريخ الصلاحية - كتابة");
                FlxFiles.SetData(38, 12, "ExpirDate_W");
                FlxFiles.SetData(39, 1, "طريقة الإستخدام - كتابة");
                FlxFiles.SetData(39, 12, "UseMethod_W");
                FlxFiles.SetData(40, 1, "العمر - كتابة");
                FlxFiles.SetData(40, 12, "Age_W");
                FlxFiles.SetData(41, 1, "تاريخ الانتاج: ");
                FlxFiles.SetData(41, 12, "ProductionDate");
                FlxFiles.SetData(42, 1, "تاريخ الانتهاء ");
                FlxFiles.SetData(42, 12, "ExpirationDate");
            }
            RibunButtons();
        }
        private bool SaveData()
        {
            try
            {
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
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
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
                    _mInvPrint.vEt = int.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxFiles.GetData(iiCnt, 13))));
                    _mInvPrint.IsPrntHd = int.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxFiles.GetData(iiCnt, 14))));
                    _mInvPrint.nTyp = int.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxFiles.GetData(iiCnt, 15))));
                    _mInvPrint.MaxW = int.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxFiles.GetData(iiCnt, 7))));
                    _mInvPrint.vFont = string.Concat(FlxFiles.GetData(iiCnt, 8));
                    _mInvPrint.vSize = int.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxFiles.GetData(iiCnt, 9))));
                    _mInvPrint.vBold = int.Parse(VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(FlxFiles.GetData(iiCnt, 10))));
                    _mInvPrint.pField = string.Concat(FlxFiles.GetData(iiCnt, 12));
                    _mInvPrint.uChr = CmbUnit.Text;
                    _mInvPrint.repTyp = 22;
                    _mInvPrint.repNum = 4;
                    _mInvPrint.BarcodeTyp = CmbInvType.SelectedIndex + 2;
                    db.T_mInvPrints.InsertOnSubmit(_mInvPrint);
                    db.SubmitChanges();
                }
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
        private void FlxFiles_AfterEdit(object sender, RowColEventArgs e)
        {
            if (e.Col == 5)
            {
                FlxFiles.SetData(e.Row, 13, CmbDir.SelectedIndex);
            }
            if (e.Col == 6)
            {
                FlxFiles.SetData(e.Row, 14, CmbPrintP.SelectedIndex);
            }
            if (e.Col == 11)
            {
                FlxFiles.SetData(e.Row, 15, CmbPrintP2.SelectedIndex);
            }
        }
        private void CmbInvType_SelectedIndexChanged(object sender, EventArgs e)
        {
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
        private void FMBarCodeUserInv_Load(object sender, EventArgs e)
        {
        }
        private void CmbInvType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
