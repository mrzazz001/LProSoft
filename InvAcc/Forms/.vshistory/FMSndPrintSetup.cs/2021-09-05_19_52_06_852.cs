using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using Framework.UI;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FMSndPrintSetup : Form
    { void avs(int arln)

{ 
 checkBox_previewPrint3.Text=   (arln == 0 ? "  تعيين إعدادات الطابعة الإفتراضية   " : "  Set the default printer settings") ; groupBox4.Text=   (arln == 0 ? "  الإتجـــــاه  " : "  direction") ; RButLandscape3.Text=   (arln == 0 ? "  عرضي                    " : "  accidental") ; RButPortrait3.Text=   (arln == 0 ? "  طولي                     " : "  linear") ; label9.Text=   (arln == 0 ? "  حجم الورقة :  " : "  paper size:") ; label33.Text=   (arln == 0 ? "  عدد النسخ :  " : "  Number of copies :") ; label6.Text=   (arln == 0 ? "  المسافة بين السطور :  " : "  Line spacing:") ; label4.Text=   (arln == 0 ? "  الهامش الأيسر :  " : "  left margin:") ; label3.Text=   (arln == 0 ? "  الهامش الأسفل :  " : "  bottom margin:") ; label2.Text=   (arln == 0 ? "  الهامش الأيمن :  " : "  Right margin:") ; label1.Text=   (arln == 0 ? "  الهامش الأعلى :  " : "  top margin:") ; label5.Text=   (arln == 0 ? "  السطور في الصفحة :  " : "  The lines on the page:") ; label7.Text=   (arln == 0 ? "  تحديد طابعة افتراضية للفاتورة :  " : "  Specify a default printer for the invoice:") ; labelX1.Text=   (arln == 0 ? "  اعدادات طباعة السندات  " : "  bond printing settings") ; label8.Text=   (arln == 0 ? "   نوع الفاتورة:  " : "   Invoice type:") ; ChkPTable3.Text=   (arln == 0 ? "  طباعة السند بالشكل الإفتراضي  " : "  Print the bond as default") ; groupBox2.Text=   (arln == 0 ? "  طريقة الطباعة  " : "  printing method") ; RedButCasher.Text=   (arln == 0 ? "  طباعة على ورق الكاشير  " : "  Print on cashier paper") ; RedButPaperA4.Text=   (arln == 0 ? "  طباعة على ورق A4  " : "  Print on A4 paper") ; ButWithoutSave.Text=   (arln == 0 ? "  خــــروج  " : "  exit") ; ButWithSave.Text=   (arln == 0 ? "  حفــــظ  " : "  save") ;}
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
        public Dictionary<string, ColumnDictinary> columns_Names_visible3 = new Dictionary<string, ColumnDictinary>();
        private List<T_INVSETTING> listInvSetting3 = new List<T_INVSETTING>();
        private T_INVSETTING _InvSetting3 = new T_INVSETTING();
        private Item _item3 = new Item("", 0);
        private int ItemIndex3 = 0;
        private int LangArEn = 0;
        private Stock_DataDataContext dbInstance3;
        protected bool ifOkDelete3;
        public bool CanEdit3 = true;
        protected bool CanInsert3 = true;
        private FormState statex3;
        public List<Control> controls3;
        public Control codeControl3 = new Control();
        private bool canUpdate3 = true;
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
        private Panel panel1;
        private ComboBoxEx CmbInvType3;
        private GroupBox groupBox13;
        private DoubleInput txtDistance;
        private IntegerInput txtLinePage3;
        private ComboBoxEx CmbPrinter3;
        private DoubleInput txtTopM3;
        private DoubleInput txtBottM3;
        private DoubleInput txtRight3;
        private DoubleInput txtLeftM3;
        private Label label6;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label5;
        private Label label7;
        private LabelX labelX1;
        private Label label8;
        private CheckBox ChkPTable3;
        private GroupBox groupBox3;
        private ButtonX ButWithoutSave;
        private ButtonX ButWithSave;
        private GroupBox groupBox2;
        private RadioButton RedButCasher;
        private RadioButton RedButPaperA4;
        private CheckBox checkBox_previewPrint3;
        private IntegerInput txtpageCount3;
        private Label label33;
        private GroupBox groupBox4;
        private RadioButton RButLandscape3;
        private RadioButton RButPortrait3;
        private ComboBoxEx CmbPaperSize3;
        private Label label9;
        private Stock_DataDataContext db3
        {
            get
            {
                if (dbInstance3 == null)
                {
                    dbInstance3 = new Stock_DataDataContext(VarGeneral.BranchCS);
                }
                return dbInstance3;
            }
        }
        public FormState State3
        {
            get
            {
                return statex3;
            }
            set
            {
                statex3 = value;
            }
        }
        protected bool CanUpdate3
        {
            get
            {
                return canUpdate3;
            }
            set
            {
                canUpdate3 = value;
            }
        }
        public bool SetReadOnly3
        {
            set
            {
                if (value)
                {
                    State3 = FormState.Saved;
                }
                ButWithSave.Enabled = !value;
            }
        }
        public FMSndPrintSetup()
        {
            InitializeComponent();this.Load += langloads;
            txtBottM3.Click += Button_Edit_Click;
            txtDistance.Click += Button_Edit_Click;
            txtLeftM3.Click += Button_Edit_Click;
            txtLinePage3.Click += Button_Edit_Click;
            txtpageCount3.Click += Button_Edit_Click;
            txtRight3.Click += Button_Edit_Click;
            txtTopM3.Click += Button_Edit_Click;
            txtDistance.Click += Button_Edit_Click;
            checkBox_previewPrint3.Click += Button_Edit_Click;
            RButLandscape3.Click += Button_Edit_Click;
            RButPortrait3.Click += Button_Edit_Click;
            CmbInvType3.Click += Button_Edit_Click;
            CmbPaperSize3.Click += Button_Edit_Click;
            CmbPrinter3.Click += Button_Edit_Click;
            listInvSetting3 = db3.StockInvSettingList(VarGeneral.UserID);
        }
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FMSndPrintSetup));
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
                FillCombo3();
                BindData3();
                if (VarGeneral.vDemo && VarGeneral.UserID != 1)
                {
                    checkBox_previewPrint3.Visible = false;
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FMSndPrintSetup));
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
            FillCombo3();
            BindData3();
        }
        private void BindData3()
        {
            State3 = FormState.Saved;
            ButWithSave.Enabled = false;
            _item3 = (Item)CmbInvType3.SelectedItem;
            for (int iiCnt = 0; iiCnt < listInvSetting3.Count; iiCnt++)
            {
                _InvSetting3 = listInvSetting3[iiCnt];
                if (_item3.Value == _InvSetting3.InvID)
                {
                    if (_InvSetting3.nTyp.Substring(0, 1) == "0")
                    {
                        ChkPTable3.Checked = false;
                    }
                    else
                    {
                        ChkPTable3.Checked = true;
                    }
                    if (_InvSetting3.nTyp.Substring(1, 1) == "0")
                    {
                        RedButPaperA4.Checked = false;
                        RedButCasher.Checked = true;
                    }
                    else
                    {
                        RedButPaperA4.Checked = true;
                        RedButCasher.Checked = false;
                    }
                    if (_InvSetting3.nTyp.Substring(2, 1) == "1")
                    {
                        checkBox_previewPrint3.Checked = false;
                    }
                    else
                    {
                        checkBox_previewPrint3.Checked = true;
                    }
                    txtBottM3.Text = _InvSetting3.hAs.ToString();
                    txtLeftM3.Text = _InvSetting3.hYs.ToString();
                    txtLinePage3.Value = (int)_InvSetting3.lnPg.Value;
                    if (txtLinePage3.Value <= 0)
                    {
                        txtLinePage3.LockUpdateChecked = false;
                    }
                    else
                    {
                        txtLinePage3.LockUpdateChecked = true;
                    }
                    txtRight3.Text = _InvSetting3.hYm.ToString();
                    txtTopM3.Text = _InvSetting3.hAl.ToString();
                    txtDistance.Text = _InvSetting3.lnSpc.ToString();
                    CmbPrinter3.Text = _InvSetting3.defPrn;
                    txtpageCount3.Value = _InvSetting3.DefLines.Value;
                    if (_InvSetting3.InvID == 27 || _InvSetting3.InvID == 28)
                    {
                        ChkPTable3.Visible = false;
                    }
                    else
                    {
                        ChkPTable3.Visible = true;
                    }
                    if (!string.IsNullOrEmpty(_InvSetting3.defSizePaper))
                    {
                        CmbPaperSize3.Items.Clear();
                        CmbPaperSize3.Items.Add(_InvSetting3.defSizePaper);
                        CmbPaperSize3.SelectedIndex = 0;
                    }
                    else
                    {
                        CmbPaperSize3.Items.Clear();
                    }
                    if (_InvSetting3.Orientation.Value == 1)
                    {
                        RButPortrait3.Checked = true;
                    }
                    else
                    {
                        RButLandscape3.Checked = true;
                    }
                    break;
                }
            }
        }
        private void FillCombo3()
        {
            int _CmbIndex = 0;
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                CmbPrinter3.Items.Clear();
                CmbPrinter3.Items.Add(" ");
                PrinterSettings PrintS = new PrinterSettings();
                if (PrinterSettings.InstalledPrinters.Count != 0)
                {
                    for (int iiCnt = 0; iiCnt < PrinterSettings.InstalledPrinters.Count; iiCnt++)
                    {
                        CmbPrinter3.Items.Add(PrinterSettings.InstalledPrinters[iiCnt]);
                    }
                    if (!string.IsNullOrEmpty(VarGeneral.PrintNam))
                    {
                        CmbPrinter3.Text = VarGeneral.PrintNam;
                    }
                    else
                    {
                        CmbPrinter3.Text = PrintS.DefaultPageSettings.PrinterSettings.PrinterName;
                    }
                }
                CmbInvType3.Items.Clear();
                for (int iiCnt = 0; iiCnt < listInvSetting3.Count; iiCnt++)
                {
                    _InvSetting3 = listInvSetting3[iiCnt];
                    if (_InvSetting3.InvSetting == "1" && _InvSetting3.InvID != 18 && _InvSetting3.InvID != 19 && (!(VarGeneral.SSSLev != "H") || !(VarGeneral.SSSLev != "X") || (_InvSetting3.InvID != 27 && _InvSetting3.InvID != 28)) && (!(VarGeneral.SSSLev != "E") || !(VarGeneral.SSSLev != "D") || _InvSetting3.InvID != 16))
                    {
                        if (VarGeneral.SSSTyp != 0)
                        {
                            CmbInvType3.Items.Add(new Item(_InvSetting3.InvNamA.Trim(), int.Parse(_InvSetting3.InvID.ToString())));
                        }
                        else if (_InvSetting3.InvID != 11 && _InvSetting3.InvID != 23 && _InvSetting3.InvID != 24 && _InvSetting3.InvID != 25 && _InvSetting3.InvID != 26)
                        {
                            CmbInvType3.Items.Add(new Item(_InvSetting3.InvNamA.Trim(), int.Parse(_InvSetting3.InvID.ToString())));
                        }
                    }
                }
                CmbInvType3.SelectedIndex = 0;
            }
            else
            {
                CmbPrinter3.Items.Clear();
                CmbPrinter3.Items.Add(" ");
                PrinterSettings PrintS = new PrinterSettings();
                if (PrinterSettings.InstalledPrinters.Count != 0)
                {
                    for (int iiCnt = 0; iiCnt < PrinterSettings.InstalledPrinters.Count; iiCnt++)
                    {
                        CmbPrinter3.Items.Add(PrinterSettings.InstalledPrinters[iiCnt]);
                    }
                    if (!string.IsNullOrEmpty(VarGeneral.PrintNam))
                    {
                        CmbPrinter3.Text = VarGeneral.PrintNam;
                    }
                    else
                    {
                        CmbPrinter3.Text = PrintS.DefaultPageSettings.PrinterSettings.PrinterName;
                    }
                }
                CmbInvType3.Items.Clear();
                for (int iiCnt = 0; iiCnt < listInvSetting3.Count; iiCnt++)
                {
                    _InvSetting3 = listInvSetting3[iiCnt];
                    if (_InvSetting3.InvSetting == "1")
                    {
                        CmbInvType3.Items.Add(new Item(_InvSetting3.InvNamE.Trim(), int.Parse(_InvSetting3.InvID.ToString())));
                    }
                }
                CmbInvType3.SelectedIndex = 0;
            }
            RibunButtons();
        }
        private bool SaveData3()
        {
            try
            {
                string ntyp = "";
                ntyp = (ChkPTable3.Checked ? "1" : "0");
                ntyp = (RedButPaperA4.Checked ? (ntyp + "1") : (ntyp + "0"));
                ntyp = (checkBox_previewPrint3.Checked ? (ntyp + "1") : (ntyp + "0"));
                _InvSetting3.nTyp = ntyp;
                _InvSetting3.hAs = double.Parse(VarGeneral.TString.TEmpty(txtBottM3.Text ?? ""));
                _InvSetting3.hYs = double.Parse(VarGeneral.TString.TEmpty(txtLeftM3.Text ?? ""));
                _InvSetting3.lnPg = double.Parse(VarGeneral.TString.TEmpty(txtLinePage3.Text ?? ""));
                _InvSetting3.hYm = double.Parse(VarGeneral.TString.TEmpty(txtRight3.Text ?? ""));
                _InvSetting3.hAl = double.Parse(VarGeneral.TString.TEmpty(txtTopM3.Text ?? ""));
                _InvSetting3.lnSpc = double.Parse(VarGeneral.TString.TEmpty(txtDistance.Text ?? ""));
                _InvSetting3.defPrn = CmbPrinter3.Text ?? "";
                _InvSetting3.DefLines = txtpageCount3.Value;
                if (RButPortrait3.Checked)
                {
                    _InvSetting3.Orientation = 1;
                }
                else
                {
                    _InvSetting3.Orientation = 2;
                }
                if (CmbPaperSize3.Items.Count > 0)
                {
                    if (!string.IsNullOrEmpty(CmbPrinter3.Text))
                    {
                        if (CmbPaperSize3.SelectedIndex > 0)
                        {
                            _InvSetting3.defSizePaper = CmbPaperSize3.Text;
                        }
                        else
                        {
                            _InvSetting3.defSizePaper = "";
                        }
                    }
                    else
                    {
                        _InvSetting3.defSizePaper = "";
                    }
                }
                else
                {
                    _InvSetting3.defSizePaper = "";
                }
                db3.Log = VarGeneral.DebugLog;
                db3.SubmitChanges(ConflictMode.ContinueOnConflict);
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
                bool SaveStat = SaveData3();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SaveWith:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void CmbInvType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData3();
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
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
        private void FMSndPrintSetup_Load(object sender, EventArgs e)
        {
        }
        private void ChkPTable_CheckedChanged(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            if (VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F" || VarGeneral.SSSLev == "C")
            {
                ChkPTable3.Checked = true;
            }
            else if (!ChkPTable3.Checked)
            {
                CmbPaperSize3.Items.Clear();
                CmbPaperSize3.Enabled = false;
            }
            else
            {
                CmbPaperSize3.Items.Clear();
                CmbPaperSize3.Enabled = true;
            }
        }
        private void checkBox_previewPrint_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_previewPrint3.Checked)
            {
                groupBox13.Enabled = false;
            }
            else
            {
                groupBox13.Enabled = true;
            }
        }
        private void Button_Edit_Click(object sender, EventArgs e)
        {
            if (CanEdit3 && State3 != FormState.Edit && State3 != FormState.New)
            {
                if (State3 != FormState.New)
                {
                    State3 = FormState.Edit;
                }
                SetReadOnly3 = false;
            }
        }
        private void CmbPaperSize_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (State3 == FormState.Saved || string.IsNullOrEmpty(CmbPrinter3.Text))
                {
                    return;
                }
                CmbPaperSize3.Items.Clear();
                CmbPaperSize3.Items.Add((LangArEn == 0) ? "الإفتراضي" : "Default");
                PrintDocument pd = new PrintDocument();
                pd.PrinterSettings.PrinterName = CmbPrinter3.Text;
                foreach (PaperSize item in pd.PrinterSettings.PaperSizes)
                {
                    CmbPaperSize3.Items.Add(item.PaperName);
                }
            }
            catch
            {
                CmbPaperSize3.Items.Clear();
            }
        }
        private void CmbPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (State3 != 0)
            {
                CmbPaperSize3.Items.Clear();
            }
        }
        private void txtLinePage_LockUpdateChanged(object sender, EventArgs e)
        {
            if (State3 != 0)
            {
                if (txtLinePage3.LockUpdateChecked)
                {
                    txtLinePage3.Value = 1;
                }
                else
                {
                    txtLinePage3.Value = 0;
                }
            }
        }
        private void txtLinePage_ValueChanged(object sender, EventArgs e)
        {
            if (txtLinePage3.Value == 0)
            {
                txtLinePage3.LockUpdateChecked = false;
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void ribbonBar1_ItemClick(object sender, EventArgs e)
        {
        }
        private void groupBox4_Enter(object sender, EventArgs e)
        {
        }
        private void RButLandscape3_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void RButPortrait3_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void CmbPaperSize3_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void label9_Click(object sender, EventArgs e)
        {
        }
        private void txtpageCount3_ValueChanged(object sender, EventArgs e)
        {
        }
        private void label33_Click(object sender, EventArgs e)
        {
        }
        private void txtDistance_ValueChanged(object sender, EventArgs e)
        {
        }
        private void txtTopM3_ValueChanged(object sender, EventArgs e)
        {
        }
        private void txtBottM3_ValueChanged(object sender, EventArgs e)
        {
        }
        private void txtRight3_ValueChanged(object sender, EventArgs e)
        {
        }
        private void txtLeftM3_ValueChanged(object sender, EventArgs e)
        {
        }
        private void label6_Click(object sender, EventArgs e)
        {
        }
        private void label4_Click(object sender, EventArgs e)
        {
        }
        private void label3_Click(object sender, EventArgs e)
        {
        }
        private void label2_Click(object sender, EventArgs e)
        {
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void label5_Click(object sender, EventArgs e)
        {
        }
        private void label7_Click(object sender, EventArgs e)
        {
        }
        private void labelX1_Click(object sender, EventArgs e)
        {
        }
        private void label8_Click(object sender, EventArgs e)
        {
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }
        private void RedButCasher_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void RedButPaperA4_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
