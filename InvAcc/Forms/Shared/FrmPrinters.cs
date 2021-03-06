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
            CmbPrinter_Reports.Click += Button_Edit_Click;
            CmbPaperSizeRep_Reports.Click += Button_Edit_Click;
            RButLandscapeRep_Reports.Click += Button_Edit_Click;
            RButPortraitRep_Reports.Click += Button_Edit_Click;
            RadRepA4_Reports.Click += Button_Edit_Click;
            RadRepCashier_Reports.Click += Button_Edit_Click;
            txtpageCountRep_Reports.Click += Button_Edit_Click;
            txtLinePageRep_Reports.Click += Button_Edit_Click;
            txtRightRep_Reports.Click += Button_Edit_Click;
            txtLeftMRep_Reports.Click += Button_Edit_Click;
            txtTopM_Reports.Click += Button_Edit_Click;
            txtBottMRep_Reports.Click += Button_Edit_Click;
            listInvSetting1 = db1.StockInvSettingList(VarGeneral.UserID);
            txtBottM_Sandatat.Click += Button_Edit_Click;
            txtDistance.Click += Button_Edit_Click;
            DirectOption_Reports.Click += Button_Edit_Click;
            txtLeftM_Sandatat.Click += Button_Edit_Click;
            txtLinePage_Sandatat.Click += Button_Edit_Click;
            txtpageCount3.Click += Button_Edit_Click;
            txtRight_Sandatat.Click += Button_Edit_Click;
            txtTopM_Sandatat.Click += Button_Edit_Click;
            txtDistance.Click += Button_Edit_Click;
            DirectPrinter_Sandatat.Click += Button_Edit_Click;
            RButLandscape_Sandatat.Click += Button_Edit_Click;
            RButPortrait3.Click += Button_Edit_Click;
            CmBType_Sandatat.Click += Button_Edit_Click;
            CmbPaperSize_Sandatat.Click += Button_Edit_Click;
            CmpPrinter__Sandatat.Click += Button_Edit_Click;
            listInvSetting3 = db1.StockInvSettingList(VarGeneral.UserID);
            _SettingType2 = 0;
            txtBottM.Click += Button_Edit_Click;
            txtDistance.Click += Button_Edit_Click;
            txtLeftM_Barcode.Click += Button_Edit_Click;
            txtLinePage.Click += Button_Edit_Click;
            txtpageCount_Barcode.Click += Button_Edit_Click;
            txtRight.Click += Button_Edit_Click;
            txtTopM_Barcode.Click += Button_Edit_Click;
            chk_Stoped.Click += Button_Edit_Click;
            checkBox_WaiterAll.Click += Button_Edit_Click;
            txtDistance.Click += Button_Edit_Click;
            textBox_CachierTxtA.Click += Button_Edit_Click;
            textBox_CachierTxtE.Click += Button_Edit_Click;
            DirectOption_Barcode.Click += Button_Edit_Click;
            RButLandscape.Click += Button_Edit_Click;
            RButPortrait.Click += Button_Edit_Click;
            CmbInvType.Click += Button_Edit_Click;
            CmbPaperSize.Click += Button_Edit_Click;
            cmPrinter_Barcode.Click += Button_Edit_Click;
            listInvSetting2 = db1.StockInvSettingList(VarGeneral.UserID).Where(i=>i.InvID!=1091).ToList();
            if (Program.isScriptOf("SecriptInvitationCards.dll"))
            {
                listInvSetting2 = db1.T_INVSETTINGs.Where((T_INVSETTING t) => t.InvID == 1 || t.InvID == 8).ToList();
            }
            if (Program.isScriptOf("SecriptSchool.dll"))
            {
                listInvSetting2 = db1.T_INVSETTINGs.Where((T_INVSETTING t) => t.InvID == 1 || t.InvID == 2 || t.InvID == 3 || t.InvID == 4 || t.InvID == 7 || t.InvID == 8 || t.InvID == 9 || t.InvID == 10 || t.InvID == 14).ToList();
            }
            if (Program.isScriptOf("SecriptMaintenanceCars.dll"))
            {
                listInvSetting2 = db1.T_INVSETTINGs.Where((T_INVSETTING t) => t.InvID == 1 || t.InvID == 2 || t.InvID == 3 || t.InvID == 4 || t.InvID == 7).ToList();
            }
            if (Program.isScriptOf("SecriptTegnicalCollage.dll"))
            {
                listInvSetting2 = db1.T_INVSETTINGs.Where((T_INVSETTING t) => t.InvID == 2 || t.InvID == 4 || t.InvID == 9 || t.InvID == 10 || t.InvID == 14 || t.InvID == 17 || t.InvID == 20).ToList();
            }
            if (Program.isScriptOf("SecriptWaterPackages.dll"))
            {
                listInvSetting2 = db1.T_INVSETTINGs.Where((T_INVSETTING t) => t.InvID == 1 || t.InvID == 2 || t.InvID == 3 || t.InvID == 4 || t.InvID == 5 || t.InvID == 6 || t.InvID == 7 || t.InvID == 8 || t.InvID == 9 || t.InvID == 10 || t.InvID == 14).ToList();
            }
        }
        void filldatarep()
        {
            cmbType_Reports.Items.Clear();
            cmbType_Reports.Items.Add("???????????? ???????????????? ??????");
            cmbType_Reports.Items.Add("?????????????? ?????????????????? ??????");
            cmbType_Reports.Items.Add("????????????????");
            CmbPrinter_Reports.Items.Clear();
            PrinterSettings PrintS = new PrinterSettings();
            if (PrinterSettings.InstalledPrinters.Count != 0)
            {
                for (int iiCnt = 0; iiCnt < PrinterSettings.InstalledPrinters.Count; iiCnt++)
                {
                    CmbPrinter_Reports.Items.Add(PrinterSettings.InstalledPrinters[iiCnt]);
                }
                CmbPrinter_Reports.SelectedIndex = 0;
                if (!string.IsNullOrEmpty(VarGeneral.PrintNam))
                {
                    CmbPrinter_Reports.Text = VarGeneral.PrintNam;
                }
                else
                {
                    CmbPrinter_Reports.Text = PrintS.DefaultPageSettings.PrinterSettings.PrinterName;
                }
            }
        }
        void binddatarep()
        {
            repsystemsetings = db1.StockPrinterSetting(VarGeneral.UserID, 1091);
            if (repsystemsetings.Repl_ntyp_Setting.Length == 2)
                repsystemsetings.Repl_ntyp_Setting = "1" + repsystemsetings.Repl_ntyp_Setting;
            string ntyp = repsystemsetings.Repl_ntyp_Setting;
            CmbPrinter_Reports.Text = repsystemsetings.defPrn_Setting;
           
            {
                RadRepA4_Reports.Checked = repsystemsetings.ISA4PaperType;
                RadRepCashier_Reports.Checked = repsystemsetings.ISCashierType;
                RadRepPointer_Reports.Checked = repsystemsetings.ISPOINTERType;
            }
         
           
            {
                DirectOption_Reports.Checked = repsystemsetings.ISdirectPrinting;
            }
            txtBottMRep_Reports.Value = repsystemsetings.hAs_Setting.Value;
            txtLeftMRep_Reports.Value = repsystemsetings.hYs_Setting.Value;
            txtLinePageRep_Reports.Value = (int)repsystemsetings.lnPg_Setting.Value;
            if (txtLinePageRep_Reports.Value <= 0)
            {
                txtLinePageRep_Reports.LockUpdateChecked = false;
            }
            else
            {
                txtLinePageRep_Reports.LockUpdateChecked = true;
            }
            txtRightRep_Reports.Value = repsystemsetings.hYm_Setting.Value;
            txtTopM_Reports.Value = repsystemsetings.hAl_Setting.Value;
            txtpageCountRep_Reports.Value = repsystemsetings.DefLines_Setting.Value;
            txtDistance.Value = repsystemsetings.lnSpc_Setting.Value;
            if (!string.IsNullOrEmpty(repsystemsetings.defSizePaper_Setting))
            {
                CmbPaperSizeRep_Reports.Items.Clear();
                CmbPaperSizeRep_Reports.Items.Add(repsystemsetings.defSizePaper_Setting);
                CmbPaperSizeRep_Reports.SelectedIndex = 0;
            }
            if (repsystemsetings.Orientation_Setting.Value == 1)
            {
                RButPortraitRep_Reports.Checked = true;
            }
            else
            {
                RButLandscapeRep_Reports.Checked = true;
            }
            ChkPTable.Visible = false;
            ChkPTable3_Sandatat.Visible = false;
        }
        private bool savingBarcodeSetting()
        {
            try
            {
                dbInstance1 = null;
             T_Printer      _InvSetting1 = db1.StockPrinterSetting(VarGeneral.UserID, 22);
                string ntyp = "10";
                ntyp = (DirectOption_Barcode.Checked ? (ntyp + "1") : (ntyp + "0"));
                _InvSetting1.ISdirectPrinting = DirectOption_Barcode.Checked;
                _InvSetting1.hAs = txtWidth_Barcode.Value;
                _InvSetting1.hYs = txtLeftM_Barcode.Value;
                _InvSetting1.lnPg = txtNumRows_Barcode.Value;
                _InvSetting1.hYm = txtHeight_Barcode.Value;
                _InvSetting1.hAl = txtTopM_Barcode.Value;
                _InvSetting1.lnSpc = txtNumCols_Barcode.Value;
                _InvSetting1.InvInfo.InvNum = txtBarHeigth_Barcode.Value;
                _InvSetting1.InvInfo.InvNum1 = txtBarWidth_Barcode.Value;
                _InvSetting1.defPrn = cmPrinter_Barcode.Text ?? "";
                _InvSetting1.DefLines = txtpageCount_Barcode.Value;
                _InvSetting1.InvTypA4 = (ColleteOptionBarcode.Checked ? "1" : "0");
                db1.Log = VarGeneral.DebugLog;
                db1.SubmitChanges(ConflictMode.ContinueOnConflict);
                //   MessageBox.Show((LangArEn == 0) ? "?????? ???? ?????????? ?????????????? ?????????? .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

                    if (_InvSetting1.ISdirectPrinting)
                    {
                        DirectOption_Barcode.Checked = true;
                    }
                    else
                    {
                        DirectOption_Barcode.Checked = false;
                    }
                    cmPrinter_Barcode.Text = _InvSetting1.defPrn;
                    txtWidth_Barcode.Text = _InvSetting1.hAs.ToString();
                    txtLeftM_Barcode.Text = _InvSetting1.hYs.ToString();
                    txtNumRows_Barcode.Text = _InvSetting1.lnPg.ToString();
                    txtHeight_Barcode.Text = _InvSetting1.hYm.ToString();
                    txtTopM_Barcode.Text = _InvSetting1.hAl.ToString();
                    txtNumCols_Barcode.Text = _InvSetting1.lnSpc.ToString();
                    txtBarHeigth_Barcode.Text = _InvSetting1.InvInfo.InvNum.ToString();
                    txtBarWidth_Barcode.Text = _InvSetting1.InvInfo.InvNum1.ToString();
                    txtpageCount_Barcode.Value = _InvSetting1.DefLines.Value;
                    try
                    {
                        if (!string.IsNullOrEmpty(_InvSetting1.InvTypA4))
                        {
                            if (_InvSetting1.InvTypA4 == "0")
                            {
                                ColleteOptionBarcode.Checked = false;
                            }
                            else
                            {
                                ColleteOptionBarcode.Checked = true;
                            }
                        }
                        else
                        {
                            ColleteOptionBarcode.Checked = false;
                        }
                    }
                    catch
                    {
                        ColleteOptionBarcode.Checked = false;
                    }


                }
                catch (Exception error)
                {
                    VarGeneral.DebLog.writeLog("BindData:", error, enable: true);
                }
            }
            ChkPTable.Visible = false;
            ChkPTable3_Sandatat.Visible = false;
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
                    cmPrinter_Barcode.Items.Clear();
                    PrinterSettings PrintS = new PrinterSettings();
                    if (PrinterSettings.InstalledPrinters.Count != 0)
                    {
                        for (int iiCnt = 0; iiCnt < PrinterSettings.InstalledPrinters.Count; iiCnt++)
                        {
                            cmPrinter_Barcode.Items.Add(PrinterSettings.InstalledPrinters[iiCnt]);
                        }
                        if (!string.IsNullOrEmpty(VarGeneral.PrintNam))
                        {
                            cmPrinter_Barcode.Text = VarGeneral.PrintNam;
                        }
                        else
                        {
                            cmPrinter_Barcode.Text = PrintS.DefaultPageSettings.PrinterSettings.PrinterName;
                        }
                    }
                    CmbDir.Items.Clear();
                    CmbDir.Items.Add("????????");
                    CmbDir.Items.Add("????????");
                    CmbDir.Items.Add("??????");
                    CmbPrintP.Items.Clear();
                    CmbPrintP.Items.Add("?????? ??????????????");
                    CmbPrintP.Items.Add("???????? ??????????????");
                    InstalledFontCollection _font = new InstalledFontCollection();
                    string fontString = "";
                    for (int i = 0; i < _font.Families.Length; i++)
                    {
                        fontString += _font.Families[i].Name;
                        fontString += "|";
                    }
                    CmbPrintP2.Items.Clear();
                    CmbPrintP2.Items.Add("???? ????????");
                    CmbPrintP2.Items.Add("???????????? ????????????");
                    CmbPrintP2.Items.Add("???????????? ??????????????");
                }
                else
                {
                    cmPrinter_Barcode.Items.Clear();
                    PrinterSettings PrintS = new PrinterSettings();
                    if (PrinterSettings.InstalledPrinters.Count != 0)
                    {
                        for (int iiCnt = 0; iiCnt < PrinterSettings.InstalledPrinters.Count; iiCnt++)
                        {
                            cmPrinter_Barcode.Items.Add(PrinterSettings.InstalledPrinters[iiCnt]);
                        }
                        if (!string.IsNullOrEmpty(VarGeneral.PrintNam))
                        {
                            cmPrinter_Barcode.Text = VarGeneral.PrintNam;
                        }
                        else
                        {
                            cmPrinter_Barcode.Text = PrintS.DefaultPageSettings.PrinterSettings.PrinterName;
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
                ButWithSave.Text = "?????????????? F2";
                ButWithoutSave.Text = "???????????????? Esc";
                label1.Text = "???????????? ?????????????? :";
                label2.Text = "???????? ???????? :";
                label10.Text = "???????? ???????? :";
                label4.Text = "???????????????? :";
                label5.Text = "?????????????????????? :";
                label6.Text = "?????????? ???????????? ?????? ???????? ???????????????? :";
                label7.Text = "???????????????? ?????? ???????? ???????????????? :";
                label8.Text = "?????? ???????????? ?????????? :";
                label9.Text = "?????? ???????????? ?????????? :";
                labelX1.Text = "?????????????? ?????????? ????????????????";
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
        Stock_DataDataContext db = new Stock_DataDataContext(VarGeneral.BranchCS);
        void savedatarep()
        { 
            string ntyp = "1";
            //     Stock_DataDataContext db = new Stock_DataDataContext(VarGeneral.BranchCS);

            {
                T_Printer ReportsSettings = new T_Printer();
                int xd = 0;
                xd= db.T_Printers.Single(x => x.User_ID == VarGeneral.UserID && x.InvID == 1091).P_ID;
                ReportsSettings = db.T_Printers.Single(xc =>(int) xc.P_ID==xd);

                ReportsSettings.ISA4PaperType = RadRepA4_Reports.Checked;
                ReportsSettings.ISCashierType = RadRepCashier_Reports.Checked;
                ReportsSettings.ISPOINTERType = RadRepPointer_Reports.Checked;
                ReportsSettings.ISdirectPrinting = DirectOption_Reports.Checked;

                ReportsSettings.DefLines_Setting = txtpageCountRep_Reports.Value;
                ReportsSettings.hAs_Setting = txtBottMRep_Reports.Value;
                ReportsSettings.hYs_Setting = txtLeftMRep_Reports.Value;
                ReportsSettings.lnPg_Setting = txtLinePageRep_Reports.Value;
                ReportsSettings.hYm_Setting = txtRightRep_Reports.Value;
                ReportsSettings.hAl_Setting = txtTopM_Reports.Value;
                ReportsSettings.lnSpc_Setting = txtDistance.Value;
                ReportsSettings.defPrn_Setting = CmbPrinter_Reports.Text ?? "";
                ReportsSettings.DefLines_Setting = txtpageCountRep_Reports.Value;
                if (RButPortraitRep_Reports.Checked)
                {
                    ReportsSettings.Orientation_Setting = 1;
                }
                else
                {
                    ReportsSettings.Orientation_Setting = 2;
                }
                if (CmbPaperSizeRep_Reports.Items.Count > 0)
                {
                    if (!string.IsNullOrEmpty(CmbPrinter_Reports.Text))
                    {
                        if (CmbPaperSizeRep_Reports.SelectedIndex > 0)
                        {
                            ReportsSettings.defSizePaper_Setting = CmbPaperSizeRep_Reports.Text;
                        }
                        else
                        {
                            ReportsSettings.defSizePaper_Setting = "";
                        }
                    }
                    else
                    {
                        ReportsSettings.defSizePaper_Setting = "";
                    }
                }
                else
                {
                    ReportsSettings.defSizePaper_Setting = "";
                }
                db.SubmitChanges();
            }

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
                if (savingBarcodeSetting())
                {
                }
                savedatarep();
                bool SaveStat = SavingInvoiceSettings();
        
                db1.SubmitChanges(ConflictMode.ContinueOnConflict);
                db1.SubmitChanges(ConflictMode.ContinueOnConflict);
                db1.SubmitChanges(ConflictMode.ContinueOnConflict);
                db1.SubmitChanges();
     if(orUser!=1)           Close();

            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("ButWithSave_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }

        }
        private void CmbPaperSize_Click(object sender, EventArgs e)
        {
            try
            {
                CmbPaperSize.Items.Clear();
                CmbPaperSize.Items.Add((LangArEn == 0) ? "??????????????????" : "Default");
                PrintDocument pd = new PrintDocument();
                pd.PrinterSettings.PrinterName = comboBoxEx1.Text;
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
        private void checkBox_previewPrint_CheckedChanged(object sender, EventArgs e)
        {
            if (!DirectOption_Barcode.Checked)
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
                    ChkPTable3_Sandatat.Visible = false;


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
                    ChkPTable3_Sandatat.Visible = false;

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
                ButWithSave.Text = "?????????????? F2";
                ButWithoutSave.Text = "???????????????? Esc";
                labelX1.Text = ((_SettingType2 == 0) ? "?????????????? ?????????? ????????????????" : "?????????????? ?????????? ??????????????????????");
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
                    if (_InvSetting2.Repl_ntyp.Substring(0, 1) == "0")
                    {
                        ChkPTable.Checked = false;
                    }
                    else
                    {
                        ChkPTable.Checked = true;
                    }

                    {
                        RadInvA4.Checked = _InvSetting2.ISA4PaperType;
                        RadINVCashier.Checked = _InvSetting2.ISCashierType;
                        RadInvPointer.Checked = _InvSetting2.ISPOINTERType;
                    }
                   

                  
                    {
                        ChkInvDirect.Checked = _InvSetting2.ISdirectPrinting;
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
                label8.Text = ((LangArEn == 0) ? "?????????????????? :" : "Categories :");
                chk_Stoped.OnText = ((LangArEn == 0) ? "?????????? ??????????????" : "Printing Stoped");
                chk_Stoped.OffText = ((LangArEn == 0) ? "?????????? ??????????????" : "Printing Stoped");
                ChkInvDirect.Visible = false;
                chk_Stoped.Visible = true;
                if (db1.StockPrinterSetting(VarGeneral.UserID, 1).ISdirectPrinting)
                {
                    groupBox_PrintType.Visible = false;
                    picture_SSS.Visible = true;
                }
            }
            ChkPTable.Visible = false;
            ChkPTable3_Sandatat.Visible = false;
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
        private bool SavingInvoiceSettings()
        {
            try
            {
                dbInstance1 = null;
                Stock_DataDataContext db = new Stock_DataDataContext(VarGeneral.BranchCS);

                T_Printer InoviceSetting = db.StockPrinterSetting(VarGeneral.UserID, ((Item)CmbInvType.SelectedItem).Value) ;
                InoviceSetting.ISdirectPrinting = ChkInvDirect.Checked;
                InoviceSetting.ISCashierType = RadINVCashier.Checked;
                InoviceSetting.ISA4PaperType = RadInvA4.Checked;
                InoviceSetting.ISPOINTERType = RadInvPointer.Checked;

                InoviceSetting.hAs = double.Parse(VarGeneral.TString.TEmpty(txtBottM.Text ?? ""));
                InoviceSetting.hYs = double.Parse(VarGeneral.TString.TEmpty(doubleInput2.Text ?? ""));
                InoviceSetting.lnPg = double.Parse(VarGeneral.TString.TEmpty(txtLinePage.Text ?? ""));
                InoviceSetting.hYm = double.Parse(VarGeneral.TString.TEmpty(txtRight.Text ?? ""));
                InoviceSetting.hAl = double.Parse(VarGeneral.TString.TEmpty(doubleInput1.Text ?? ""));
                InoviceSetting.lnSpc = double.Parse(VarGeneral.TString.TEmpty(txtDistance.Text ?? ""));
                InoviceSetting.invGdADesc = textBox_CachierTxtA.Text;
                InoviceSetting.invGdEDesc = textBox_CachierTxtE.Text;
                InoviceSetting.defPrn = comboBoxEx1.Text ?? "";
                InoviceSetting.DefLines = integerInput1.Value;
                InoviceSetting.InvInfo.PrintCat = chk_Stoped.Value;
                if (RButPortrait.Checked)
                {
                    InoviceSetting.Orientation = 1;
                }
                else
                {
                    InoviceSetting.Orientation = 2;
                }
                try
                {
                    if (checkBox_WaiterAll.Visible && InoviceSetting.InvID == 21)
                    {
                        InoviceSetting.InvInfo.autoCommGaid = checkBox_WaiterAll.Checked;
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
                            InoviceSetting.defSizePaper = CmbPaperSize.Text;
                        }
                        else
                        {
                            InoviceSetting.defSizePaper = "";
                        }
                    }
                    else
                    {
                        InoviceSetting.defSizePaper = "";
                    }
                }
                else
                {
                    InoviceSetting.defSizePaper = "";
                }
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                MessageBox.Show((LangArEn == 0) ? "?????? ???? ?????????? ?????????????? ?????????? .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
            _item3 = (Item)CmBType_Sandatat.SelectedItem;
            for (int iiCnt = 0; iiCnt < listInvSetting3.Count; iiCnt++)
            {
                _InvSetting3 = db1.StockPrinterSetting(VarGeneral.UserID, listInvSetting3[iiCnt].InvID);
                if (_item3.Value == _InvSetting3.InvID)
                {
                    if (_InvSetting3.Repl_ntyp.Substring(0, 1) == "0")
                    {
                        ChkPTable3_Sandatat.Checked = false;
                    }
                    else
                    {
                        ChkPTable3_Sandatat.Checked = true;
                    }

                    if (_InvSetting3.ISdirectPrinting)
                    {
                        DirectPrinter_Sandatat.Checked = true;
                    }
                    else
                    {
                        DirectPrinter_Sandatat.Checked = false;
                    }
                    txtBottM_Sandatat.Text = _InvSetting3.hAs.ToString();
                    txtLeftM_Sandatat.Text = _InvSetting3.hYs.ToString();
                    txtLinePage_Sandatat.Value = (int)_InvSetting3.lnPg.Value;
                    if (txtLinePage_Sandatat.Value <= 0)
                    {
                        txtLinePage_Sandatat.LockUpdateChecked = false;
                    }
                    else
                    {
                        txtLinePage_Sandatat.LockUpdateChecked = true;
                    }
                    txtRight_Sandatat.Text = _InvSetting3.hYm.ToString();
                    txtTopM_Sandatat.Text = _InvSetting3.hAl.ToString();
                    txtDistance.Text = _InvSetting3.lnSpc.ToString();
                    CmpPrinter__Sandatat.Text = _InvSetting3.defPrn;
                    txtpageCount3.Value = _InvSetting3.DefLines.Value;
                    if (_InvSetting3.InvID == 27 || _InvSetting3.InvID == 28)
                    {
                        ChkPTable3_Sandatat.Visible = false;
                    }
                    else
                    {
                        ChkPTable3_Sandatat.Visible = true;
                    }
                    if (!string.IsNullOrEmpty(_InvSetting3.defSizePaper))
                    {
                        CmbPaperSize_Sandatat.Items.Clear();
                        CmbPaperSize_Sandatat.Items.Add(_InvSetting3.defSizePaper);
                        CmbPaperSize_Sandatat.SelectedIndex = 0;
                    }
                    else
                    {
                        CmbPaperSize_Sandatat.Items.Clear();
                    }
                    if (_InvSetting3.Orientation.Value == 1)
                    {
                        RButPortrait3.Checked = true;
                    }
                    else
                    {
                        RButLandscape_Sandatat.Checked = true;
                    }
                    break;
                }
            }
            ChkPTable.Visible = false;
            ChkPTable3_Sandatat.Visible = false;
        }
        private void FillCombo3()
        {
#pragma warning disable CS0219 // The variable '_CmbIndex' is assigned but its value is never used
            int _CmbIndex = 0;
#pragma warning restore CS0219 // The variable '_CmbIndex' is assigned but its value is never used
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                CmpPrinter__Sandatat.Items.Clear();
                CmpPrinter__Sandatat.Items.Add(" ");
                PrinterSettings PrintS = new PrinterSettings();
                if (PrinterSettings.InstalledPrinters.Count != 0)
                {
                    for (int iiCnt = 0; iiCnt < PrinterSettings.InstalledPrinters.Count; iiCnt++)
                    {
                        CmpPrinter__Sandatat.Items.Add(PrinterSettings.InstalledPrinters[iiCnt]);
                    }
                    if (!string.IsNullOrEmpty(VarGeneral.PrintNam))
                    {
                        CmpPrinter__Sandatat.Text = VarGeneral.PrintNam;
                    }
                    else
                    {
                        CmpPrinter__Sandatat.Text = PrintS.DefaultPageSettings.PrinterSettings.PrinterName;
                    }
                }
                CmBType_Sandatat.Items.Clear();
                for (int iiCnt = 0; iiCnt < listInvSetting3.Count; iiCnt++)
                {
                    _InvSetting3 = db1.StockPrinterSettingwithoutGeneralPrinter(VarGeneral.UserID, listInvSetting3[iiCnt].InvID);
                    if (_InvSetting3.InvInfo.InvSetting == "1" && _InvSetting3.InvID != 18 && _InvSetting3.InvID != 19 && (!(VarGeneral.SSSLev != "H") || !(VarGeneral.SSSLev != "X") || (_InvSetting3.InvID != 27 && _InvSetting3.InvID != 28)) && (!(VarGeneral.SSSLev != "E") || !(VarGeneral.SSSLev != "D") || _InvSetting3.InvID != 16))
                    {
                        if (VarGeneral.SSSTyp != 0)
                        {
                            CmBType_Sandatat.Items.Add(new Item(_InvSetting3.InvInfo.InvNamA.Trim(), int.Parse(_InvSetting3.InvID.ToString())));
                        }
                        else if (_InvSetting3.InvID != 11 && _InvSetting3.InvID != 23 && _InvSetting3.InvID != 24 && _InvSetting3.InvID != 25 && _InvSetting3.InvID != 26)
                        {
                            CmBType_Sandatat.Items.Add(new Item(_InvSetting3.InvInfo.InvNamA.Trim(), int.Parse(_InvSetting3.InvID.ToString())));
                        }
                    }
                }
                CmBType_Sandatat.SelectedIndex = 0;
            }
            else
            {
                CmpPrinter__Sandatat.Items.Clear();
                CmpPrinter__Sandatat.Items.Add(" ");
                PrinterSettings PrintS = new PrinterSettings();
                if (PrinterSettings.InstalledPrinters.Count != 0)
                {
                    for (int iiCnt = 0; iiCnt < PrinterSettings.InstalledPrinters.Count; iiCnt++)
                    {
                        CmpPrinter__Sandatat.Items.Add(PrinterSettings.InstalledPrinters[iiCnt]);
                    }
                    if (!string.IsNullOrEmpty(VarGeneral.PrintNam))
                    {
                        CmpPrinter__Sandatat.Text = VarGeneral.PrintNam;
                    }
                    else
                    {
                        CmpPrinter__Sandatat.Text = PrintS.DefaultPageSettings.PrinterSettings.PrinterName;
                    }
                }
                CmBType_Sandatat.Items.Clear();
                for (int iiCnt = 0; iiCnt < listInvSetting3.Count; iiCnt++)
                {
                    _InvSetting3 = db1.StockPrinterSetting(VarGeneral.UserID, listInvSetting3[iiCnt].InvID);
                    if (_InvSetting3.InvInfo.InvSetting == "1")
                    {
                        CmBType_Sandatat.Items.Add(new Item(_InvSetting3.InvInfo.InvNamE.Trim(), int.Parse(_InvSetting3.InvID.ToString())));
                    }
                }
                CmBType_Sandatat.SelectedIndex = 0;
            }
            RibunButtons3();
        }
        private void RibunButtons3()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ButWithSave.Text = "?????????????? F2";
                ButWithoutSave.Text = "???????????????? Esc";
                labelX1.Text = "?????????????? ?????????? ?????????? ??????";
            }
            else
            {
                ButWithSave.Text = "Save F2";
                ButWithoutSave.Text = "Exit Esc";
                labelX1.Text = "Barcode Printer Setting";
            }
        }
        private bool SavingSandatatSettiongs()
        {
            try
            {
                dbInstance1 = null;
                Stock_DataDataContext db = new Stock_DataDataContext(VarGeneral.BranchCS);

          T_Printer       sendatSetting = db.StockPrinterSetting(VarGeneral.UserID, ((Item)cmPrinter_Barcode.SelectedItem).Value);
                string ntyp = "";
                ntyp = (ChkPTable3_Sandatat.Checked ? "1" : "0");

                string c = "0";
               
                    c = "2";
                ntyp += c;
                ntyp = (DirectPrinter_Sandatat.Checked ? (ntyp + "1") : (ntyp + "0"));
         
                
                sendatSetting.Repl_ntyp = ntyp;
                sendatSetting.hAs = double.Parse(VarGeneral.TString.TEmpty(txtBottM_Sandatat.Text ?? ""));
                sendatSetting.hYs = double.Parse(VarGeneral.TString.TEmpty(txtLeftM_Sandatat.Text ?? ""));
                sendatSetting.lnPg = double.Parse(VarGeneral.TString.TEmpty(txtLinePage_Sandatat.Text ?? ""));
                sendatSetting.hYm = double.Parse(VarGeneral.TString.TEmpty(txtRight_Sandatat.Text ?? ""));
                sendatSetting.hAl = double.Parse(VarGeneral.TString.TEmpty(txtTopM_Sandatat.Text ?? ""));
                sendatSetting.lnSpc = double.Parse(VarGeneral.TString.TEmpty(txtDistance.Text ?? ""));
                sendatSetting.defPrn = CmpPrinter__Sandatat.Text ?? "";
                sendatSetting.DefLines = txtpageCount3.Value;
                if (RButPortrait3.Checked)
                {
                    sendatSetting.Orientation = 1;
                }
                else
                {
                    sendatSetting.Orientation = 2;
                }
                if (CmbPaperSize_Sandatat.Items.Count > 0)
                {
                    if (!string.IsNullOrEmpty(CmpPrinter__Sandatat.Text))
                    {
                        if (CmbPaperSize_Sandatat.SelectedIndex > 0)
                        {
                            sendatSetting.defSizePaper = CmbPaperSize_Sandatat.Text;
                        }
                        else
                        {
                            sendatSetting.defSizePaper = "";
                        }
                    }
                    else
                    {
                        sendatSetting.defSizePaper = "";
                    }
                }
                else
                {
                    sendatSetting.defSizePaper = "";
                }
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                db.SubmitChanges(ConflictMode.ContinueOnConflict);

                // MessageBox.Show((LangArEn == 0) ? "?????? ???? ?????????? ?????????????? ?????????? .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
            ChkPTable3_Sandatat.Visible = false;


        }
        private void ChkPTable3_CheckedChanged(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            if (VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F" || VarGeneral.SSSLev == "C")
            {
                ChkPTable3_Sandatat.Checked = true;
            }
            else if (!ChkPTable3_Sandatat.Checked)
            {
                CmbPaperSize_Sandatat.Items.Clear();
                CmbPaperSize_Sandatat.Enabled = false;
            }
            else
            {
                CmbPaperSize_Sandatat.Items.Clear();
                CmbPaperSize_Sandatat.Enabled = true;
            }
        }
        private void checkBox_previewPrint3_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void CmbPrinter3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                CmbPaperSize_Sandatat.Items.Clear();
            }
        }
        private void txtLinePage3_ValueChanged(object sender, EventArgs e)
        {
            if (txtLinePage_Sandatat.Value == 0)
            {
                txtLinePage_Sandatat.LockUpdateChecked = false;
            }
        }
        private void txtLinePage3_LockUpdateChanged(object sender, EventArgs e)
        {
            if (1 != 0)
            {
                if (txtLinePage_Sandatat.LockUpdateChecked)
                {
                    txtLinePage_Sandatat.Value = 1;
                }
                else
                {
                    txtLinePage_Sandatat.Value = 0;
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
                CmbPaperSizeRep_Reports.Items.Clear();
            }
        }
        private void CmbPaperSizeRep_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                CmbPaperSizeRep_Reports.Items.Clear();
                CmbPaperSizeRep_Reports.Items.Add((LangArEn == 0) ? "??????????????????" : "Default");
                PrintDocument pd = new PrintDocument();
                pd.PrinterSettings.PrinterName = CmbPrinter_Reports.Text;
                foreach (PaperSize item in pd.PrinterSettings.PaperSizes)
                {
                    CmbPaperSizeRep_Reports.Items.Add(item.PaperName);
                }
            }
            catch
            {
                CmbPaperSizeRep_Reports.Items.Clear();
            }
        }
        private void txtLinePageRep_LockUpdateChanged(object sender, EventArgs e)
        {
            if (1 != 0)
            {
                if (txtLinePageRep_Reports.LockUpdateChecked)
                {
                    txtLinePageRep_Reports.Value = 1;
                }
                else
                {
                    txtLinePageRep_Reports.Value = 0;
                }
            }
        }
        private void txtLinePageRep_ValueChanged(object sender, EventArgs e)
        {
            if (txtLinePageRep_Reports.Value == 0)
            {
                txtLinePageRep_Reports.LockUpdateChecked = false;
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
            if (RadRepPointer_Reports.Checked)
            {
                DirectOption_Reports.Checked = true;
                // ChkInvDirect.Checked = true;
            }
            else
                DirectOption_Reports.Checked = false;


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

        private void groupPanel1Rep_Click(object sender, EventArgs e)
        {

        }

        private void txtNumRows_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtNumCols_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox13_Enter(object sender, EventArgs e)
        {

        }

        private void DirectOption_Reports_CheckedChanged(object sender, DevComponents.DotNetBar.CheckBoxChangeEventArgs e)
        {

        }
    }
}
