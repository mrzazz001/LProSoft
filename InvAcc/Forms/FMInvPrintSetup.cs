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
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FMInvPrintSetup : Form
    { void avs(int arln)

{ 
 checkBox_WaiterAll.Text=   (arln == 0 ? "  الكل  " : "  All") ; groupBox_PrintType.Text=   (arln == 0 ? "  طريقة الطباعة  " : "  printing method") ; RedButCasher.Text=   (arln == 0 ? "  طباعة على ورق الكاشير  " : "  Print on cashier paper") ; RedButPaperA4.Text=   (arln == 0 ? "  طباعة على ورق A4  " : "  Print on A4 paper") ; checkBox_previewPrint.Text=   (arln == 0 ? "  تعيين إعدادات الطابعة الإفتراضية   " : "  Set the default printer settings") ; groupBox4.Text=   (arln == 0 ? "  الإتجـــــاه  " : "  direction") ; RButLandscape.Text=   (arln == 0 ? "  عرضي                     " : "  accidental") ; RButPortrait.Text=   (arln == 0 ? "  طولي                      " : "  linear") ; label9.Text=   (arln == 0 ? "  حجم الورقة :  " : "  paper size:") ; label33.Text=   (arln == 0 ? "  عدد النسخ :  " : "  Number of copies :") ; label6.Text=   (arln == 0 ? "  المسافة بين السطور :  " : "  Line spacing:") ; label4.Text=   (arln == 0 ? "  الهامش الأيسر :  " : "  left margin:") ; label3.Text=   (arln == 0 ? "  الهامش الأسفل :  " : "  bottom margin:") ; label2.Text=   (arln == 0 ? "  الهامش الأيمن :  " : "  Right margin:") ; label1.Text=   (arln == 0 ? "  الهامش الأعلى :  " : "  top margin:") ; label5.Text=   (arln == 0 ? "  السطور في الصفحة :  " : "  The lines on the page:") ; label7.Text=   (arln == 0 ? "  الطابعة الإفتراضية :  " : "  default printer:") ; labelX1.Text=   (arln == 0 ? "  اعدادات طباعة الفواتير  " : "  Invoice printing settings") ; label8.Text=   (arln == 0 ? "   نوع الفاتورة:  " : "   Invoice type:") ; ChkPTable.Text=   (arln == 0 ? "  طباعة الفاتورة بالشكل الإفتراضي  " : "  Print invoice as default بالشكل") ; ButWithoutSave.Text=   (arln == 0 ? "  خــــروج  " : "  exit") ; ButWithSave.Text=   (arln == 0 ? "  حفــــظ  " : "  save") ;}
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
        private CheckBox ChkPTable;
        private Label label8;
        private RibbonBar ribbonBar1;
        private Panel panel1;
        private LabelX labelX1;
        private GroupBox groupBox_PrintType;
        private RadioButton RedButCasher;
        private RadioButton RedButPaperA4;
        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBoxEx CmbInvType;
        private Label label7;
        private DoubleInput txtTopM;
        private DoubleInput txtBottM;
        private DoubleInput txtRight;
        private DoubleInput txtLeftM;
        private ComboBoxEx CmbPrinter;
        private GroupBox groupBox3;
        private ButtonX ButWithoutSave;
        private ButtonX ButWithSave;
        private CheckBox checkBox_previewPrint;
        private DoubleInput txtDistance;
        private IntegerInput txtLinePage;
        private Label label6;
        private Label label5;
        private IntegerInput txtpageCount;
        private Label label33;
        private GroupBox groupBox4;
        private RadioButton RButLandscape;
        private RadioButton RButPortrait;
        private ComboBoxEx CmbPaperSize;
        private Label label9;
        private TextBoxX textBox_CachierTxtE;
        private TextBoxX textBox_CachierTxtA;
        private PictureBox picture_SSS;
        private SwitchButton chk_Stoped;
        private CheckBoxX checkBox_WaiterAll;
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private List<T_INVSETTING> listInvSetting = new List<T_INVSETTING>();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private Item _item = new Item("", 0);
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
        public FMInvPrintSetup(int _typ)
        {
            InitializeComponent();this.Load += langloads;
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
            Rate_DataDataContext dbc = new Rate_DataDataContext(VarGeneral.BranchRt);

     List< T_User>      Users = (from i in dbc.T_Users
                     select i).ToList<T_User>();
            comboBox1.DataSource = Users;
            comboBox1.DisplayMember = "UsrNamA";
            comboBox1.ValueMember = "Usr_ID";

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
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FMInvPrintSetup));
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
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FMInvPrintSetup));
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
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
              //  for (int iiCnt = 0; iiCnt < listInvSetting.Count; iiCnt++)
                {
                    T_Printer p = db.StockPrinterSetting(VarGeneral.UserID, _item.Value);

                    _InvSetting = p.InvInfo;
                    chk_Stoped.Value = false;
                    checkBox_WaiterAll.Checked = false;
                    if (p.nTyp.Substring(0, 1) == "0")
                    {
                        ChkPTable.Checked = false;
                    }
                    else
                    {
                        ChkPTable.Checked = true;
                    }
                    if (p.nTyp.Substring(1, 1) == "0")
                    {
                        RedButPaperA4.Checked = false;
                        RedButCasher.Checked = true;
                    }
                    else
                    {
                        RedButPaperA4.Checked = true;
                        RedButCasher.Checked = false;
                    }
                    if (p.nTyp.Substring(2, 1) == "1")
                    {
                        checkBox_previewPrint.Checked = true;
                    }
                    else
                    {
                        checkBox_previewPrint.Checked = false;
                    }
                    txtBottM.Text = p.hAs.ToString();
                    txtLeftM.Text = p.hYs.ToString();
                    txtLinePage.Value = (int)p.lnPg.Value;
                    if (txtLinePage.Value <= 0)
                    {
                        txtLinePage.LockUpdateChecked = false;
                    }
                    else
                    {
                        txtLinePage.LockUpdateChecked = true;
                    }
                    txtRight.Text = p.hYm.ToString();
                    txtTopM.Text = p.hAl.ToString();
                    txtDistance.Text = p.lnSpc.ToString();
                    textBox_CachierTxtA.Text = _InvSetting.invGdADesc;
                    textBox_CachierTxtE.Text = _InvSetting.invGdEDesc;
                    CmbPrinter.Text = p.defPrn;
                    txtpageCount.Value = p.DefLines.Value;
                    try
                    { 
                        chk_Stoped.Value = _InvSetting.PrintCat.Value;
                    }
                    catch
                    {
                        chk_Stoped.Value = true;
                    }
                    if (!string.IsNullOrEmpty(p.defSizePaper))
                    {
                        CmbPaperSize.Items.Clear();
                        CmbPaperSize.Items.Add(p.defSizePaper);
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
                checkBox_previewPrint.Visible = true;
                chk_Stoped.Visible = true;
                if (db.StockInvSetting( 1).nTyp.Substring(2, 1) == "1")
                {
                    groupBox_PrintType.Visible = true;
                  //  picture_SSS.Visible = true;
                }
            }
        }
        private void FillCombo()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
                    if (_InvSetting.InvID != VarGeneral.DraftBillId)
                    {
                        try
                        {
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
                        catch { }
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
                    if (_InvSetting.InvID != VarGeneral.DraftBillId)
                    {
                        if (_InvSetting.InvSetting != "1" && int.Parse(_InvSetting.InvSetting.ToString()) < 400 && _InvSetting.InvID != 22 && ((_SettingType == 0) ? (!_InvSetting.CatID.HasValue) : _InvSetting.CatID.HasValue))
                        {
                            CmbInvType.Items.Add(new Item(_InvSetting.InvNamE.Trim(), int.Parse(_InvSetting.InvID.ToString())));
                        }
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
                string ntyp = "";
                ntyp = (ChkPTable.Checked ? "1" : "0");
                ntyp = (RedButPaperA4.Checked ? (ntyp + "1") : (ntyp + "0"));
                ntyp = (checkBox_previewPrint.Checked ? (ntyp + "1") : (ntyp + "0"));
                T_Printer p = new T_Printer();
                p = db.StockPrinterSetting(VarGeneral.UserID,_InvSetting.InvID);
                if(p==null)
                {
                    p = new T_Printer();
                }
                p.nTyp = ntyp;
                p.hAs = double.Parse(VarGeneral.TString.TEmpty(txtBottM.Text ?? ""));
                p.hYs = double.Parse(VarGeneral.TString.TEmpty(txtLeftM.Text ?? ""));
                p.lnPg = double.Parse(VarGeneral.TString.TEmpty(txtLinePage.Text ?? ""));
                p.hYm = double.Parse(VarGeneral.TString.TEmpty(txtRight.Text ?? ""));
                p.hAl = double.Parse(VarGeneral.TString.TEmpty(txtTopM.Text ?? ""));
                p.lnSpc = double.Parse(VarGeneral.TString.TEmpty(txtDistance.Text ?? ""));
                p.invGdADesc = textBox_CachierTxtA.Text;
                p.invGdEDesc = textBox_CachierTxtE.Text;
                p.defPrn = CmbPrinter.Text ?? "";
                p.DefLines = txtpageCount.Value;
                _InvSetting.PrintCat = chk_Stoped.Value;
                if (RButPortrait.Checked)
                {
                    p.Orientation = 1;
                }
                else
                {
                    p.Orientation = 2;
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
                            p.defSizePaper = CmbPaperSize.Text;
                        }
                        else
                        {
                            p.defSizePaper = "";
                        }
                    }
                    else
                    {
                        p.defSizePaper = "";
                    }
                }
                else
                {
                    p.defSizePaper = "";
                }
                int r = 0;
               if(_InvSetting.InvpRINTERInfo==null)
                {
                    r = 1;
                    p.Branch_ID =(VarGeneral.BranchNumber);
                    p.User_ID = VarGeneral.UserID;

                    p.InvID = _InvSetting.InvID;
                    db.T_Printers.InsertOnSubmit(p);
           
                }
               else
                {
                    db.SubmitChanges();
                }
                _InvSetting.nTyp = ntyp;
                _InvSetting.hAs = double.Parse(VarGeneral.TString.TEmpty(txtBottM.Text ?? ""));
                _InvSetting.hYs = double.Parse(VarGeneral.TString.TEmpty(txtLeftM.Text ?? ""));
                _InvSetting.lnPg = double.Parse(VarGeneral.TString.TEmpty(txtLinePage.Text ?? ""));
                _InvSetting.hYm = double.Parse(VarGeneral.TString.TEmpty(txtRight.Text ?? ""));
                _InvSetting.hAl = double.Parse(VarGeneral.TString.TEmpty(txtTopM.Text ?? ""));
                _InvSetting.lnSpc = double.Parse(VarGeneral.TString.TEmpty(txtDistance.Text ?? ""));
                _InvSetting.invGdADesc = textBox_CachierTxtA.Text;
                _InvSetting.invGdEDesc = textBox_CachierTxtE.Text;
                _InvSetting.defPrn = CmbPrinter.Text ?? "";
                _InvSetting.DefLines = txtpageCount.Value;
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
                            _InvSetting.defSizePaper = "";
                        }
                    }
                    else
                    {
                        _InvSetting.defSizePaper = "";
                    }
                }
                else
                {
                    _InvSetting.defSizePaper = "";
                }
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
         if(r==1)
                {
                    dbInstance = null;
                    listInvSetting = db.StockInvSettingList(VarGeneral.UserID);
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SaveData:", error, enable: true);
                MessageBox.Show(error.Message);
                return false;
            }
            return true;
        }
        private void FlxFiles_AfterEdit(object sender, RowColEventArgs e)
        {
        }
        private void CmbInvType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }
        private void FMInvPrintSetup_Load(object sender, EventArgs e)
        {
        }
        private void Frm_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && ButWithSave.Enabled && ButWithSave.Visible && State != 0)
            {
                ButWithSave_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void ButWithSave_Click(object sender, EventArgs e)
        {
            bool SaveStat = SaveData();
        }
        private void ButWithoutSave_Click(object sender, EventArgs e)
        {
            Close();
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
        private void CmbPaperSize_MouseClick(object sender, MouseEventArgs e)
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
        private void CmbPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                CmbPaperSize.Items.Clear();
            }
        }
        private void ChkPTable_CheckedChanged(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            if (!ChkPTable.Checked)
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
        private void textBox_CachierTxtA_ButtonCustomClick(object sender, EventArgs e)
        {
            textBox_CachierTxtA.Text = "";
        }
        private void textBox_CachierTxtE_ButtonCustomClick(object sender, EventArgs e)
        {
            textBox_CachierTxtE.Text = "";
        }
        private void RedButPaperA4_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
        }
        private void RedButCasher_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
        }
        private void txtLinePage_LockUpdateChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                if (txtLinePage.LockUpdateChecked)
                {
                    txtLinePage.Value = 1;
                }
                else
                {
                    txtLinePage.Value = 0;
                }
            }
        }
        private void txtLinePage_ValueChanged(object sender, EventArgs e)
        {
            if (txtLinePage.Value == 0)
            {
                txtLinePage.LockUpdateChecked = false;
            }
        }
        private void RedButPaperA4_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void RedButCasher_CheckedChanged(object sender, EventArgs e)
        {
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

        private void button3_Click(object sender, EventArgs e)
        {
            VarGeneral.UserID = ((T_User)comboBox1.SelectedItem).Usr_ID;
            listInvSetting = db.StockInvSettingList(VarGeneral.UserID);
            FMInvPrintSetup_Load(null, null);
            OnLoad(null);
            Refresh();
        }
    }
}
