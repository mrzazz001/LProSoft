using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmPrinters : Form
    {
        public FrmPrinters()
        {
            InitializeComponent();//this.Load += langloads;

            orUser = VarGeneral.UserID;
            if (orUser == 1)
            {
                Rate_DataDataContext dbc = new Rate_DataDataContext(VarGeneral.BranchRt);

                Users = (from i in dbc.T_Users
                         select i).ToList<T_User>();
                comboBox1.DataSource = Users;
                comboBox1.DisplayMember = "UsrNamA";
                comboBox1.ValueMember = "Usr_ID";


            }
            else
            {
                tabControl1.TabPages.Remove(tabPage5);
            }
            CmbPrinterRep.Click += Button_Edit_Click;
            CmbPaperSizeRep.Click += Button_Edit_Click;
            RButLandscapeRep.Click += Button_Edit_Click;
            RButPortraitRep.Click += Button_Edit_Click;
            RadRepA4.Click += Button_Edit_Click;
            RadRepCashier.Click += Button_Edit_Click;
            txtpageCountRep.Click += Button_Edit_Click;
            txtLinePageRep.Click += Button_Edit_Click;
            txtRightRep.Click += Button_Edit_Click;
            txtLeftMRep.Click += Button_Edit_Click;
            txtTopMRep.Click += Button_Edit_Click;
            txtBottMRep.Click += Button_Edit_Click;
            listInvSetting1 = db1.StockInvSettingList(VarGeneral.UserID);
            txtBottM3.Click += Button_Edit_Click;
            txtDistance.Click += Button_Edit_Click;
            checkBox_previewPrintRep.Click += Button_Edit_Click;
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
            _SettingType2 = 0;
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
            listInvSetting2 = db2.StockInvSettingList(VarGeneral.UserID);
            if (Program.isScriptOf("SecriptInvitationCards.dll"))
            {
                listInvSetting2 = db2.T_INVSETTINGs.Where((T_INVSETTING t) => t.InvID == 1 || t.InvID == 8).ToList();
            }
            if (Program.isScriptOf("SecriptSchool.dll"))
            {
                listInvSetting2 = db2.T_INVSETTINGs.Where((T_INVSETTING t) => t.InvID == 1 || t.InvID == 2 || t.InvID == 3 || t.InvID == 4 || t.InvID == 7 || t.InvID == 8 || t.InvID == 9 || t.InvID == 10 || t.InvID == 14).ToList();
            }
            if (Program.isScriptOf("SecriptMaintenanceCars.dll"))
            {
                listInvSetting2 = db2.T_INVSETTINGs.Where((T_INVSETTING t) => t.InvID == 1 || t.InvID == 2 || t.InvID == 3 || t.InvID == 4 || t.InvID == 7).ToList();
            }
            if (Program.isScriptOf("SecriptTegnicalCollage.dll"))
            {
                listInvSetting2 = db2.T_INVSETTINGs.Where((T_INVSETTING t) => t.InvID == 2 || t.InvID == 4 || t.InvID == 9 || t.InvID == 10 || t.InvID == 14 || t.InvID == 17 || t.InvID == 20).ToList();
            }
            if (Program.isScriptOf("SecriptWaterPackages.dll"))
            {
                listInvSetting2 = db2.T_INVSETTINGs.Where((T_INVSETTING t) => t.InvID == 1 || t.InvID == 2 || t.InvID == 3 || t.InvID == 4 || t.InvID == 5 || t.InvID == 6 || t.InvID == 7 || t.InvID == 8 || t.InvID == 9 || t.InvID == 10 || t.InvID == 14).ToList();
            }
        }
        void filldatarep()
        {
            CmbPrintTyp.Items.Clear();
            CmbPrintTyp.Items.Add("فاتورة المبيعات فقط");
            CmbPrintTyp.Items.Add("اعدادات التصنيفات فقط");
            CmbPrintTyp.Items.Add("الكــــل");
            CmbPrinterRep.Items.Clear();
            PrinterSettings PrintS = new PrinterSettings();
            if (PrinterSettings.InstalledPrinters.Count != 0)
            {
                for (int iiCnt = 0; iiCnt < PrinterSettings.InstalledPrinters.Count; iiCnt++)
                {
                    CmbPrinterRep.Items.Add(PrinterSettings.InstalledPrinters[iiCnt]);
                }
                CmbPrinterRep.SelectedIndex = 0;
                if (!string.IsNullOrEmpty(VarGeneral.PrintNam))
                {
                    CmbPrinterRep.Text = VarGeneral.PrintNam;
                }
                else
                {
                    CmbPrinterRep.Text = PrintS.DefaultPageSettings.PrinterSettings.PrinterName;
                }
            }
        }
        void binddatarep()
        {
            repsystemsetings = dprep.StockPrinterSetting(VarGeneral.UserID, 1091);
            if (repsystemsetings.nTyp_Setting.Length == 2)
                repsystemsetings.nTyp_Setting = "1" + repsystemsetings.nTyp_Setting;
            string ntyp = repsystemsetings.nTyp_Setting;
            CmbPrinterRep.Text = repsystemsetings.defPrn_Setting;
            if (ntyp.Substring(1, 1) == "0")
            {
                RadRepA4.Checked = true;
                RadRepCashier.Checked = false;
                RadRepPointer.Checked = false;
            }
            else if (ntyp.Substring(1, 1) == "1")
            {
                RadRepA4.Checked = false;
                RadRepCashier.Checked = true;
                RadRepPointer.Checked = false;

            }
            else if (ntyp.Substring(1, 1) == "2")
            {
                RadRepA4.Checked = false;
                RadRepCashier.Checked = false;
                RadRepPointer.Checked = true;

            }
            if (repsystemsetings.nTyp_Setting.Substring(2, 1) == "0")
            {
                checkBox_previewPrintRep.Checked = true;
            }
            else
            {
                checkBox_previewPrintRep.Checked = false;
            }
            txtBottMRep.Value = repsystemsetings.hAs_Setting.Value;
            txtLeftMRep.Value = repsystemsetings.hYs_Setting.Value;
            txtLinePageRep.Value = (int)repsystemsetings.lnPg_Setting.Value;
            if (txtLinePageRep.Value <= 0)
            {
                txtLinePageRep.LockUpdateChecked = false;
            }
            else
            {
                txtLinePageRep.LockUpdateChecked = true;
            }
            txtRightRep.Value = repsystemsetings.hYm_Setting.Value;
            txtTopMRep.Value = repsystemsetings.hAl_Setting.Value;
            txtpageCountRep.Value = repsystemsetings.DefLines_Setting.Value;
            txtDistance.Value = repsystemsetings.lnSpc_Setting.Value;
            if (!string.IsNullOrEmpty(repsystemsetings.defSizePaper_Setting))
            {
                CmbPaperSizeRep.Items.Clear();
                CmbPaperSizeRep.Items.Add(repsystemsetings.defSizePaper_Setting);
                CmbPaperSizeRep.SelectedIndex = 0;
            }
            if (repsystemsetings.Orientation_Setting.Value == 1)
            {
                RButPortraitRep.Checked = true;
            }
            else
            {
                RButLandscapeRep.Checked = true;
            }
            ChkPTable.Visible = false;
            ChkPTable3.Visible = false;
        }
        private bool SaveData1()
        {
            try
            {

                string ntyp = "10";
                ntyp = (checkBox_previewPrint.Checked ? (ntyp + "1") : (ntyp + "0"));
                _InvSetting1.nTyp = ntyp;
                _InvSetting1.hAs = txtWidth.Value;
                _InvSetting1.hYs = txtLeftM.Value;
                _InvSetting1.lnPg = txtNumRows.Value;
                _InvSetting1.hYm = txtHeight.Value;
                _InvSetting1.hAl = txtTopM.Value;
                _InvSetting1.lnSpc = txtNumCols.Value;
                _InvSetting1.InvInfo.InvNum = txtBarHeigth.Value;
                _InvSetting1.InvInfo.InvNum1 = txtBarWidth.Value;
                _InvSetting1.defPrn = CmbPrinter.Text ?? "";
                _InvSetting1.DefLines = txtpageCount.Value;
                _InvSetting1.InvTypA4 = (checkBox_Collate.Checked ? "1" : "0");
                db1.Log = VarGeneral.DebugLog;
                db1.SubmitChanges(ConflictMode.ContinueOnConflict);
                //   MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch
            {
                return false;
            }
            return true;
        }
        private void BindData1()
        {
            if (this.DesignMode == false)
            {
                try
                {

                    _InvSetting1 = db1.StockPrinterSetting(VarGeneral.UserID, 22);

                    if (_InvSetting1.nTyp.Substring(2, 1) == "1")
                    {
                        checkBox_previewPrint.Checked = true;
                    }
                    else
                    {
                        checkBox_previewPrint.Checked = false;
                    }
                    CmbPrinter.Text = _InvSetting1.defPrn;
                    txtWidth.Text = _InvSetting1.hAs.ToString();
                    txtLeftM.Text = _InvSetting1.hYs.ToString();
                    txtNumRows.Text = _InvSetting1.lnPg.ToString();
                    txtHeight.Text = _InvSetting1.hYm.ToString();
                    txtTopM.Text = _InvSetting1.hAl.ToString();
                    txtNumCols.Text = _InvSetting1.lnSpc.ToString();
                    txtBarHeigth.Text = _InvSetting1.InvInfo.InvNum.ToString();
                    txtBarWidth.Text = _InvSetting1.InvInfo.InvNum1.ToString();
                    txtpageCount.Value = _InvSetting1.DefLines.Value;
                    try
                    {
                        if (!string.IsNullOrEmpty(_InvSetting1.InvTypA4))
                        {
                            if (_InvSetting1.InvTypA4 == "0")
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


                }
                catch (Exception error)
                {
                    VarGeneral.DebLog.writeLog("BindData:", error, enable: true);
                }
            }
            ChkPTable.Visible = false;
            ChkPTable3.Visible = false;
        }
        private void FillCombo1()
        {
            if (this.DesignMode == false)
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
                RibunButtons1();
            }
        }
        private void RibunButtons1()
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
        private Stock_DataDataContext db1
        {
            get
            {
                if (dbInstance1 == null)
                {
                    if (DesignMode == false) dbInstance1 = new Stock_DataDataContext(VarGeneral.BranchCS);
                }
                return dbInstance1;
            }
        }
        public Dictionary<string, ColumnDictinary> columns_Names_visible;//ew Dictionary<string, ColumnDictinary>();
        private List<T_INVSETTING> listInvSetting1;
        private T_Printer _InvSetting1; //new T_InvSetting();
        private Item _item1;// new Item("", 0);
        private int LangArEn = 0;
        private Stock_DataDataContext dbInstance1;
        T_Printer repsystemsetings;
        void savedatarep()
        {
            string ntyp = "1";
            string c = "";
            if (RadRepA4.Checked)
                c = "0";
            else if (RadRepCashier.Checked)
                c = "1";
            else
                c = "2";
            ntyp += c;
            ntyp = (checkBox_previewPrintRep.Checked ? (ntyp + "0") : (ntyp + "1"));

            repsystemsetings.nTyp_Setting = ntyp;
            repsystemsetings.DefLines_Setting = txtpageCountRep.Value;
            repsystemsetings.hAs_Setting = txtBottMRep.Value;
            repsystemsetings.hYs_Setting = txtLeftMRep.Value;
            repsystemsetings.lnPg_Setting = txtLinePageRep.Value;
            repsystemsetings.hYm_Setting = txtRightRep.Value;
            repsystemsetings.hAl_Setting = txtTopMRep.Value;
            repsystemsetings.lnSpc_Setting = txtDistance.Value;
            repsystemsetings.defPrn_Setting = CmbPrinterRep.Text ?? "";
            repsystemsetings.DefLines_Setting = txtpageCountRep.Value;
            if (RButPortraitRep.Checked)
            {
                repsystemsetings.Orientation_Setting = 1;
            }
            else
            {
                repsystemsetings.Orientation_Setting = 2;
            }
            if (CmbPaperSizeRep.Items.Count > 0)
            {
                if (!string.IsNullOrEmpty(CmbPrinterRep.Text))
                {
                    if (CmbPaperSizeRep.SelectedIndex > 0)
                    {
                        repsystemsetings.defSizePaper_Setting = CmbPaperSizeRep.Text;
                    }
                    else
                    {
                        repsystemsetings.defSizePaper_Setting = "";
                    }
                }
                else
                {
                    repsystemsetings.defSizePaper_Setting = "";
                }
            }
            else
            {
                repsystemsetings.defSizePaper_Setting = "";
            }
            dprep.SubmitChanges(ConflictMode.ContinueOnConflict);
            VarGeneral._GeneralPrinter = null;
        }
        public void getallcontrols(Control root)
        {
            foreach (Control control in root.Controls)
            {
                if ((control.GetType() == typeof(TextBox))
                    || (control.GetType() == typeof(SwitchButton)) ||
                    (control.GetType() == typeof(ComboBoxEx)) ||
                    (control.GetType() == typeof(CheckBox)) ||
                    (control.GetType() == typeof(CheckBoxX)) || (control.GetType() == typeof(RadioButton)) ||
                    (control.GetType() == typeof(DoubleInput)) || (control.GetType() == typeof(TextBoxX)))
                    control.Click += Button_Edit_jClick;
                if (control.Controls != null)
                {
                    if (control.Name == "checkBox1")
                    {
                    }
                    getallcontrols(control);
                }
            }
        }
        List<T_User> Users;
        private void Button_Edit_jClick(object sender, EventArgs e)
        {
            State = FormState.Edit;
            SetReadOnly = false;
        }int orUser = 0;
        private void FrmPrinters_Load(object sender, EventArgs e)
        {
            _InvSetting1 = new T_Printer();
            _item1 = new Item("", 0);
            listInvSetting1 = new List<T_INVSETTING>();
            columns_Names_visible = new Dictionary<string, ColumnDictinary>();
            getallcontrols(tabControl1);


            BindData2();
        }
        private void ButWithSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData1())
                {
                }
                savedatarep();
                bool SaveStat = SaveData2();
                bool SaveStat3 = SaveData3();
                db3.SubmitChanges(ConflictMode.ContinueOnConflict);
                db1.SubmitChanges(ConflictMode.ContinueOnConflict);
                db2.SubmitChanges(ConflictMode.ContinueOnConflict);
                dprep.SubmitChanges();
     if(orUser!=1)           Close();

            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("ButWithSave_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }

        }
        private void checkBox_previewPrint_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox_previewPrint.Checked)
            {
                groupBox1.Enabled = true;
            }
            else
            {
                groupBox1.Enabled = false;
            }
        }
        private void FrmPrinters_KeyDown(object sender, KeyEventArgs e)
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

        private void FrmPrinters_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        Stock_DataDataContext dprep = new Stock_DataDataContext(VarGeneral.BranchCS);
        protected override void OnLoad(EventArgs e)
        {
            filldatarep();
            binddatarep();
          
            if (this.DesignMode == false)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmPrinters));
                if (this.DesignMode == false)
                {
                    //if (VarGeneral.CurrentLang.ToString() == "0"||VarGeneral.CurrentLang.ToString() == "")
                    //{
                    //    Language.ChangeLanguage("ar-SA", this, resources);
                    //    LangArEn = 0;
                    //}
                    //else
                    //{
                    //    Language.ChangeLanguage("en", this, resources);
                    //    LangArEn = 1;
                    //}
                    FillCombo1();
                    BindData1();
                    FillCombo2();
                    FillCombo3();
                    BindData2();
                    BindData3();
                    getallcontrols(this);
                    ChkPTable.Visible = false;
                    ChkPTable3.Visible = false;


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
                    //if (VarGeneral.CurrentLang.ToString() == "0"||VarGeneral.CurrentLang.ToString() == "")
                    //{
                    //    Language.ChangeLanguage("ar-SA", this, resources);
                    //    LangArEn = 0;
                    //}
                    //else
                    //{
                    //    Language.ChangeLanguage("en", this, resources);
                    //    LangArEn = 1;
                    //}
                    FillCombo1();
                    BindData1();
                    FillCombo2();
                    FillCombo3();
                    BindData2();
                    BindData3();
                    ChkPTable.Visible = false;
                    ChkPTable3.Visible = false;

                }
                catch (Exception error)
                {
                    VarGeneral.DebLog.writeLog("OnParentRightToLeftChanged:", error, enable: true);
                    MessageBox.Show(error.Message);
                }
            }
        }
#pragma warning disable CS0414 // The field 'FrmPrinters.FS' is assigned but its value is never used
        int FS = 0;
#pragma warning restore CS0414 // The field 'FrmPrinters.FS' is assigned but its value is never used
        private void CmbPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        public Dictionary<string, ColumnDictinary> columns_Names_visible1 = new Dictionary<string, ColumnDictinary>();
        private List<T_INVSETTING> listInvSetting2 = new List<T_INVSETTING>();
        private T_Printer _InvSetting2 = new T_Printer();
        private Item _item2 = new Item("", 0);
        //private int LangArEn = 0;
        private Stock_DataDataContext dbInstance2;
        private int _SettingType2 = 0;
        protected bool ifOkDelete2;
        public bool CanEdit2 = true;
        protected bool CanInsert2 = true;
#pragma warning disable CS0649 // Field 'FrmPrinters.statex2' is never assigned to, and will always have its default value
        private FormState statex2;
#pragma warning restore CS0649 // Field 'FrmPrinters.statex2' is never assigned to, and will always have its default value
        public List<Control> controls;
        public Control codeControl2 = new Control();
        private bool canUpdate2 = true;
        private Stock_DataDataContext db2
        {
            get
            {
                if (dbInstance2 == null)
                {
                    dbInstance2 = new Stock_DataDataContext(VarGeneral.BranchCS);
                }
                return dbInstance2;
            }
        }
        protected bool CanUpdate2
        {
            get
            {
                return canUpdate2;
            }
            set
            {
                canUpdate2 = value;
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
        private void RibunButtons2()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ButWithSave.Text = "حفــــظ F2";
                ButWithoutSave.Text = "خــــروج Esc";
                labelX1.Text = ((_SettingType2 == 0) ? "إعدادات طباعة الفواتير" : "إعدادات طباعة التصنيفــات");
            }
            else
            {
                ButWithSave.Text = "Save F2";
                ButWithoutSave.Text = "Exit Esc";
                labelX1.Text = ((_SettingType2 == 0) ? "Invoice Printer Setting" : "Categories Printer Setting");
            }
        }
        private void BindData2()
        {
            try
            {
                State = FormState.Saved;
                ButWithSave.Enabled = false;
                _item2 = (Item)CmbInvType.SelectedItem;
                //    for (int iiCnt = 0; iiCnt < listInvSetting2.Count; iiCnt++)
                {
                    _InvSetting2 = db1.StockPrinterSetting(VarGeneral.UserID, _item2.Value);
                    if (_item2.Value != _InvSetting2.InvID)
                    {
                        //    continue;
                    }
                    chk_Stoped.Value = false;
                    checkBox_WaiterAll.Checked = false;
                    if (_InvSetting2.nTyp.Substring(0, 1) == "0")
                    {
                        ChkPTable.Checked = false;
                    }
                    else
                    {
                        ChkPTable.Checked = true;
                    }

                    if (_InvSetting2.nTyp.Substring(1, 1) == "1")
                    {
                        RadInvA4.Checked = true;
                        RadINVCashier.Checked = false;
                        RadInvPointer.Checked = false;
                    }
                    else if (_InvSetting2.nTyp.Substring(1, 1) == "2")
                    {
                        RadInvPointer.Checked = true;
                        RadInvA4.Checked = false;
                        RadINVCashier.Checked = false;
                    }
                    else if (_InvSetting2.nTyp.Substring(1, 1) == "0")
                    {
                        RadInvPointer.Checked = false;
                        RadInvA4.Checked = false;
                        RadINVCashier.Checked = true;

                    }

                    if (_InvSetting2.nTyp.Substring(2, 1) == "1")
                    {
                        ChkInvDirect.Checked = true;
                    }
                    else
                    {
                        ChkInvDirect.Checked = false;
                    }
                    txtBottM.Text = _InvSetting2.hAs.ToString();
                    doubleInput2.Text = _InvSetting2.hYs.ToString();
                    txtLinePage.Value = (int)_InvSetting2.lnPg.Value;
                    if (txtLinePage.Value <= 0)
                    {
                        txtLinePage.LockUpdateChecked = false;
                    }
                    else
                    {
                        txtLinePage.LockUpdateChecked = true;
                    }
                    txtRight.Text = _InvSetting2.hYm.ToString();
                    doubleInput1.Text = _InvSetting2.hAl.ToString();
                    txtDistance.Text = _InvSetting2.lnSpc.ToString();
                    textBox_CachierTxtA.Text = _InvSetting2.invGdADesc;
                    textBox_CachierTxtE.Text = _InvSetting2.invGdEDesc;
                    comboBoxEx1.Text = _InvSetting2.defPrn;
                    integerInput1.Value = _InvSetting2.DefLines.Value;
                    try
                    {
                        chk_Stoped.Value = _InvSetting2.InvInfo.PrintCat.Value;
                    }
                    catch
                    {
                        chk_Stoped.Value = true;
                    }
                    if (!string.IsNullOrEmpty(_InvSetting2.defSizePaper))
                    {
                        CmbPaperSize.Items.Clear();
                        CmbPaperSize.Items.Add(_InvSetting2.defSizePaper);
                        CmbPaperSize.SelectedIndex = 0;
                    }
                    else
                    {
                        CmbPaperSize.Items.Clear();
                    }
                    if (_InvSetting2.Orientation.Value == 1)
                    {
                        RButPortrait.Checked = true;
                    }
                    else
                    {
                        RButLandscape.Checked = true;
                    }
                    if (_InvSetting2.InvID == 21)
                    {
                        ChkPTable.Visible = false;
                        chk_Stoped.Visible = true;
                        checkBox_WaiterAll.Visible = true;
                        try
                        {
                            if (checkBox_WaiterAll.Visible)
                            {
                                checkBox_WaiterAll.Checked = _InvSetting2.InvInfo.autoCommGaid.Value;
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
                    //break;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("BindData:", error, enable: true);
            }
            if (_SettingType2 == 1)
            {
                ChkPTable.Visible = false;
                label8.Text = ((LangArEn == 0) ? "التصنيفات :" : "Categories :");
                chk_Stoped.OnText = ((LangArEn == 0) ? "إيقاف الطباعة" : "Printing Stoped");
                chk_Stoped.OffText = ((LangArEn == 0) ? "إيقاف الطباعة" : "Printing Stoped");
                ChkInvDirect.Visible = false;
                chk_Stoped.Visible = true;
                if (db2.StockPrinterSetting(VarGeneral.UserID, 1).nTyp.Substring(2, 1) == "1")
                {
                    groupBox_PrintType.Visible = false;
                    picture_SSS.Visible = true;
                }
            }
            ChkPTable.Visible = false;
            ChkPTable3.Visible = false;
        }

        private void FillCombo2()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                comboBoxEx1.Items.Clear();
                comboBoxEx1.Items.Add(" ");
                PrinterSettings PrintS = new PrinterSettings();
                if (PrinterSettings.InstalledPrinters.Count != 0)
                {
                    for (int iiCnt = 0; iiCnt < PrinterSettings.InstalledPrinters.Count; iiCnt++)
                    {
                        comboBoxEx1.Items.Add(PrinterSettings.InstalledPrinters[iiCnt]);
                    }
                    if (!string.IsNullOrEmpty(VarGeneral.PrintNam))
                    {
                        comboBoxEx1.Text = VarGeneral.PrintNam;
                    }
                    else
                    {
                        comboBoxEx1.Text = PrintS.DefaultPageSettings.PrinterSettings.PrinterName;
                    }
                }
                CmbInvType.Items.Clear();
                for (int iiCnt = 0; iiCnt < listInvSetting2.Count; iiCnt++)
                {
                    try
                    {
                        if (listInvSetting2[iiCnt].InvID == -101)
                            continue;
                        _InvSetting2 = listInvSetting2[iiCnt].InvpRINTERInfo;
                        if (VarGeneral.SSSLev == "R" || VarGeneral.SSSLev == "C" || VarGeneral.SSSLev == "H")
                        {
                            if (_InvSetting2.InvInfo.InvSetting != "1" && (int.Parse(_InvSetting2.InvInfo.InvSetting.ToString()) < 400 || int.Parse(_InvSetting2.InvInfo.InvSetting.ToString()) == 910) && _InvSetting2.InvID != 22 && ((_SettingType2 == 0) ? (!_InvSetting2.InvInfo.CatID.HasValue) : _InvSetting2.InvInfo.CatID.HasValue))
                            {
                                CmbInvType.Items.Add(new Item(_InvSetting2.InvInfo.InvNamA.Trim(), int.Parse(_InvSetting2.InvID.ToString())));
                            }
                        }
                        else if (_InvSetting2.InvInfo.InvSetting != "1" && int.Parse(_InvSetting2.InvInfo.InvSetting.ToString()) < 400 && _InvSetting2.InvID != 22 && ((_SettingType2 == 0) ? (!_InvSetting2.InvInfo.CatID.HasValue) : _InvSetting2.InvInfo.CatID.HasValue))
                        {
                            CmbInvType.Items.Add(new Item(_InvSetting2.InvInfo.InvNamA.Trim(), int.Parse(_InvSetting2.InvID.ToString())));
                        }
                    }
                    catch { }
                }
                CmbInvType.SelectedIndex = 0;
                CmbInvType_SelectedIndexChanged(null, null);
            }
            else
            {
                comboBoxEx1.Items.Clear();
                comboBoxEx1.Items.Add(" ");
                PrinterSettings PrintS = new PrinterSettings();
                if (PrinterSettings.InstalledPrinters.Count != 0)
                {
                    for (int iiCnt = 0; iiCnt < PrinterSettings.InstalledPrinters.Count; iiCnt++)
                    {
                        comboBoxEx1.Items.Add(PrinterSettings.InstalledPrinters[iiCnt]);
                    }
                    if (!string.IsNullOrEmpty(VarGeneral.PrintNam))
                    {
                        comboBoxEx1.Text = VarGeneral.PrintNam;
                    }
                    else
                    {
                        comboBoxEx1.Text = PrintS.DefaultPageSettings.PrinterSettings.PrinterName;
                    }
                }
                CmbInvType.Items.Clear();
                for (int iiCnt = 0; iiCnt < listInvSetting2.Count; iiCnt++)
                {
                    _InvSetting2 = db1.StockPrinterSetting(VarGeneral.UserID, listInvSetting2[iiCnt].InvID);
                    if (_InvSetting2.InvInfo.InvSetting != "1" && int.Parse(_InvSetting2.InvInfo.InvSetting.ToString()) < 400 && _InvSetting2.InvID != 22 && ((_SettingType2 == 0) ? (!_InvSetting2.InvInfo.CatID.HasValue) : _InvSetting2.InvInfo.CatID.HasValue))
                    {
                        CmbInvType.Items.Add(new Item(_InvSetting2.InvInfo.InvNamE.Trim(), int.Parse(_InvSetting2.InvID.ToString())));
                    }
                }
                CmbInvType.SelectedIndex = 0;
            }
            RibunButtons2();
        }
        private bool SaveData2()
        {
            try
            {
                string ntyp = "";
                ntyp = (ChkPTable.Checked ? "1" : "0");
                string c = "";
                if (RadInvA4.Checked)
                    c = "1";
                else if (RadINVCashier.Checked)
                    c = "0";
                else
                    c = "2";
                ntyp += c;

                ntyp = (ChkInvDirect.Checked ? (ntyp + "1") : (ntyp + "0"));
                _InvSetting2.nTyp = ntyp;
                _InvSetting2.hAs = double.Parse(VarGeneral.TString.TEmpty(txtBottM.Text ?? ""));
                _InvSetting2.hYs = double.Parse(VarGeneral.TString.TEmpty(doubleInput2.Text ?? ""));
                _InvSetting2.lnPg = double.Parse(VarGeneral.TString.TEmpty(txtLinePage.Text ?? ""));
                _InvSetting2.hYm = double.Parse(VarGeneral.TString.TEmpty(txtRight.Text ?? ""));
                _InvSetting2.hAl = double.Parse(VarGeneral.TString.TEmpty(doubleInput1.Text ?? ""));
                _InvSetting2.lnSpc = double.Parse(VarGeneral.TString.TEmpty(txtDistance.Text ?? ""));
                _InvSetting2.invGdADesc = textBox_CachierTxtA.Text;
                _InvSetting2.invGdEDesc = textBox_CachierTxtE.Text;
                _InvSetting2.defPrn = comboBoxEx1.Text ?? "";
                _InvSetting2.DefLines = integerInput1.Value;
                _InvSetting2.InvInfo.PrintCat = chk_Stoped.Value;
                if (RButPortrait.Checked)
                {
                    _InvSetting2.Orientation = 1;
                }
                else
                {
                    _InvSetting2.Orientation = 2;
                }
                try
                {
                    if (checkBox_WaiterAll.Visible && _InvSetting2.InvID == 21)
                    {
                        _InvSetting2.InvInfo.autoCommGaid = checkBox_WaiterAll.Checked;
                    }
                }
                catch
                {
                }
                if (CmbPaperSize.Items.Count > 0)
                {
                    if (!string.IsNullOrEmpty(comboBoxEx1.Text))
                    {
                        if (CmbPaperSize.SelectedIndex > 0)
                        {
                            _InvSetting2.defSizePaper = CmbPaperSize.Text;
                        }
                        else
                        {
                            _InvSetting2.defSizePaper = "";
                        }
                    }
                    else
                    {
                        _InvSetting2.defSizePaper = "";
                    }
                }
                else
                {
                    _InvSetting2.defSizePaper = "";
                }
                db2.Log = VarGeneral.DebugLog;
                db2.SubmitChanges(ConflictMode.ContinueOnConflict);
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
        private void CmbInvType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData2();
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
        private void Button_Edit_Click(object sender, EventArgs e)
        {
            State = FormState.Edit;
            SetReadOnly = false;
        }
        private void chk_Stoped_ValueChanged(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
        }
        private void RedButCasher_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
        }
        private void RedButPaperA4_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
        }
        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                CmbPaperSize.Items.Clear();
            }
        }
        public Dictionary<string, ColumnDictinary> columns_Names_visible3 = new Dictionary<string, ColumnDictinary>();
        private List<T_INVSETTING> listInvSetting3 = new List<T_INVSETTING>();
        private T_Printer _InvSetting3 = new T_Printer();
        private Item _item3 = new Item("", 0);
#pragma warning disable CS0414 // The field 'FrmPrinters.ItemIndex3' is assigned but its value is never used
        private int ItemIndex3 = 0;
#pragma warning restore CS0414 // The field 'FrmPrinters.ItemIndex3' is assigned but its value is never used
        //private int LangArEn = 0
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
        FormState _state;
        public FormState State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
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
        private Stock_DataDataContext dbInstance3;
        protected bool ifOkDelete3;
        public bool CanEdit3 = true;
        protected bool CanInsert3 = true;
#pragma warning disable CS0169 // The field 'FrmPrinters.statex3' is never used
        private FormState statex3;
#pragma warning restore CS0169 // The field 'FrmPrinters.statex3' is never used
        public List<Control> controls3;
        public Control codeControl3 = new Control();
        private bool canUpdate3 = true;
        private void
            BindData3()
        {
            State = FormState.Saved;
            ButWithSave.Enabled = false;
            _item3 = (Item)CmbInvType3.SelectedItem;
            for (int iiCnt = 0; iiCnt < listInvSetting3.Count; iiCnt++)
            {
                _InvSetting3 = db1.StockPrinterSetting(VarGeneral.UserID, listInvSetting3[iiCnt].InvID);
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

                    if (_InvSetting3.nTyp.Substring(2, 1) == "1")
                    {
                        checkBox_previewPrint3.Checked = true;
                    }
                    else
                    {
                        checkBox_previewPrint3.Checked = false;
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
            ChkPTable.Visible = false;
            ChkPTable3.Visible = false;
        }
        private void FillCombo3()
        {
#pragma warning disable CS0219 // The variable '_CmbIndex' is assigned but its value is never used
            int _CmbIndex = 0;
#pragma warning restore CS0219 // The variable '_CmbIndex' is assigned but its value is never used
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
                    _InvSetting3 = db1.StockPrinterSetting(VarGeneral.UserID, listInvSetting3[iiCnt].InvID);
                    if (_InvSetting3.InvInfo.InvSetting == "1" && _InvSetting3.InvID != 18 && _InvSetting3.InvID != 19 && (!(VarGeneral.SSSLev != "H") || !(VarGeneral.SSSLev != "X") || (_InvSetting3.InvID != 27 && _InvSetting3.InvID != 28)) && (!(VarGeneral.SSSLev != "E") || !(VarGeneral.SSSLev != "D") || _InvSetting3.InvID != 16))
                    {
                        if (VarGeneral.SSSTyp != 0)
                        {
                            CmbInvType3.Items.Add(new Item(_InvSetting3.InvInfo.InvNamA.Trim(), int.Parse(_InvSetting3.InvID.ToString())));
                        }
                        else if (_InvSetting3.InvID != 11 && _InvSetting3.InvID != 23 && _InvSetting3.InvID != 24 && _InvSetting3.InvID != 25 && _InvSetting3.InvID != 26)
                        {
                            CmbInvType3.Items.Add(new Item(_InvSetting3.InvInfo.InvNamA.Trim(), int.Parse(_InvSetting3.InvID.ToString())));
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
                    _InvSetting3 = db1.StockPrinterSetting(VarGeneral.UserID, listInvSetting3[iiCnt].InvID);
                    if (_InvSetting3.InvInfo.InvSetting == "1")
                    {
                        CmbInvType3.Items.Add(new Item(_InvSetting3.InvInfo.InvNamE.Trim(), int.Parse(_InvSetting3.InvID.ToString())));
                    }
                }
                CmbInvType3.SelectedIndex = 0;
            }
            RibunButtons3();
        }
        private void RibunButtons3()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ButWithSave.Text = "حفــــظ F2";
                ButWithoutSave.Text = "خــــروج Esc";
                labelX1.Text = "إعدادات طباعة البار كود";
            }
            else
            {
                ButWithSave.Text = "Save F2";
                ButWithoutSave.Text = "Exit Esc";
                labelX1.Text = "Barcode Printer Setting";
            }
        }
        private bool SaveData3()
        {
            try
            {
                string ntyp = "";
                ntyp = (ChkPTable3.Checked ? "1" : "0");

                string c = "";
                if (RadInvA4.Checked)
                    c = "0";
                else if (RadINVCashier.Checked)
                    c = "1";
                else
                    c = "2";
                ntyp += c;
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
                db1.SubmitChanges(ConflictMode.ContinueOnConflict);
                db2.SubmitChanges(ConflictMode.ContinueOnConflict);

                // MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
        private void CmbInvType3_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData3();
            ChkPTable.Visible = false;
            ChkPTable3.Visible = false;


        }
        private void ChkPTable3_CheckedChanged(object sender, EventArgs e)
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
        private void checkBox_previewPrint3_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void CmbPrinter3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                CmbPaperSize3.Items.Clear();
            }
        }
        private void txtLinePage3_ValueChanged(object sender, EventArgs e)
        {
            if (txtLinePage3.Value == 0)
            {
                txtLinePage3.LockUpdateChecked = false;
            }
        }
        private void txtLinePage3_LockUpdateChanged(object sender, EventArgs e)
        {
            if (1 != 0)
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
        private void ButWithoutSave_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox1.Checked)
            //{
            //    groupBox4.Enabled = false;
            //}
            //else
            //{
            //    groupBox4.Enabled = true;
            //}
        }
        private void ribbonBar1_ItemClick(object sender, EventArgs e)
        {
        }
        private void checkBox_previewPrintRep_Click(object sender, EventArgs e)
        {
        }
        private void CmbPrinterRep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (statex2 != 0)
            {
                CmbPaperSizeRep.Items.Clear();
            }
        }
        private void CmbPaperSizeRep_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                CmbPaperSizeRep.Items.Clear();
                CmbPaperSizeRep.Items.Add((LangArEn == 0) ? "الإفتراضي" : "Default");
                PrintDocument pd = new PrintDocument();
                pd.PrinterSettings.PrinterName = CmbPrinterRep.Text;
                foreach (PaperSize item in pd.PrinterSettings.PaperSizes)
                {
                    CmbPaperSizeRep.Items.Add(item.PaperName);
                }
            }
            catch
            {
                CmbPaperSizeRep.Items.Clear();
            }
        }
        private void txtLinePageRep_LockUpdateChanged(object sender, EventArgs e)
        {
            if (1 != 0)
            {
                if (txtLinePageRep.LockUpdateChecked)
                {
                    txtLinePageRep.Value = 1;
                }
                else
                {
                    txtLinePageRep.Value = 0;
                }
            }
        }
        private void txtLinePageRep_ValueChanged(object sender, EventArgs e)
        {
            if (txtLinePageRep.Value == 0)
            {
                txtLinePageRep.LockUpdateChecked = false;
            }
        }
        private void checkBox_previewPrintRep_Click(object sender, DevComponents.DotNetBar.CheckBoxChangeEventArgs e)
        {
            //if (checkBox_previewPrintRep.Checked)
            //{
            //    groupPanel1Rep.Enabled = true;
            //}
            //else
            //{
            //    groupPanel1Rep.Enabled = false;
            //}
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FMBarCodePrintSetup f = new FMBarCodePrintSetup();
            f.Show();
        }
        private void checkBox1_Click(object sender, EventArgs e)
        {
            State = FormState.Edit;
            State = FormState.Edit;
        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }

        private void txtLinePage_ValueChanged(object sender, EventArgs e)
        {
            if (txtLinePage.Value == 0)
            {
                txtLinePage.LockUpdateChecked = false;
            }
        }

        private void txtLinePage_LockUpdateChanged(object sender, EventArgs e)
        {
            if (1 != 0)
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

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void ChkPTable_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void PointerPrinterRD_CheckedChanged(object sender, EventArgs e)
        {
            if (RadInvPointer.Checked)
            {
                ChkPTable.Checked = true;
                ChkInvDirect.Checked = true;
            }else
            {
                ChkPTable.Checked = false;
                ChkInvDirect.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void RadRepPointer_CheckedChanged(object sender, EventArgs e)
        {
            if (RadRepPointer.Checked)
            {
                checkBox_previewPrintRep.Checked = true;
                // ChkInvDirect.Checked = true;
            }
            else
                checkBox_previewPrintRep.Checked = false;


        }

        private void button3_Click(object sender, EventArgs e)
        {
     
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            VarGeneral.UserID = ((T_User)comboBox1.SelectedItem).Usr_ID;
            FrmPrinters_Load(null, null);
            OnLoad(null);
            Refresh();

        }
    }
}
