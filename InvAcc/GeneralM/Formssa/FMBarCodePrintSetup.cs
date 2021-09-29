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
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FMBarCodePrintSetup : Form
    {

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
        private IContainer components = null;
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
            InitializeComponent();
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
                        if (_InvSetting.InvpRINTERInfo.nTyp.Substring(2, 1) == "0")
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
            int _CmbIndex = 0;
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
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMBarCodePrintSetup));
            this.CmbPrintP2 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.CmbPrintP = new System.Windows.Forms.ComboBox();
            this.CmbDir = new System.Windows.Forms.ComboBox();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.checkBox_previewPrint = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_Collate = new System.Windows.Forms.CheckBox();
            this.txtLeftM = new DevComponents.Editors.DoubleInput();
            this.txtTopM = new DevComponents.Editors.DoubleInput();
            this.CmbPrinter = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtWidth = new DevComponents.Editors.DoubleInput();
            this.txtHeight = new DevComponents.Editors.DoubleInput();
            this.txtBarWidth = new DevComponents.Editors.IntegerInput();
            this.txtBarHeigth = new DevComponents.Editors.IntegerInput();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtpageCount = new DevComponents.Editors.IntegerInput();
            this.label33 = new System.Windows.Forms.Label();
            this.txtNumRows = new DevComponents.Editors.DoubleInput();
            this.txtNumCols = new DevComponents.Editors.DoubleInput();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ButWithoutSave = new DevComponents.DotNetBar.ButtonX();
            this.ButWithSave = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.ribbonBar1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeftM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTopM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarHeigth)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtpageCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumCols)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CmbPrintP2
            // 
            this.CmbPrintP2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPrintP2.FormattingEnabled = true;
            this.CmbPrintP2.Location = new System.Drawing.Point(132, 486);
            this.CmbPrintP2.Name = "CmbPrintP2";
            this.CmbPrintP2.Size = new System.Drawing.Size(140, 21);
            this.CmbPrintP2.TabIndex = 33;
            // 
            // button1
            // 
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(610, 384);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 25);
            this.button1.TabIndex = 34;
            this.button1.Text = "شكل توضيح";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CmbPrintP
            // 
            this.CmbPrintP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPrintP.FormattingEnabled = true;
            this.CmbPrintP.Location = new System.Drawing.Point(297, 484);
            this.CmbPrintP.Name = "CmbPrintP";
            this.CmbPrintP.Size = new System.Drawing.Size(140, 21);
            this.CmbPrintP.TabIndex = 32;
            // 
            // CmbDir
            // 
            this.CmbDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDir.FormattingEnabled = true;
            this.CmbDir.Location = new System.Drawing.Point(448, 486);
            this.CmbDir.Name = "CmbDir";
            this.CmbDir.Size = new System.Drawing.Size(140, 21);
            this.CmbDir.TabIndex = 31;
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            this.ribbonBar1.BackColor = System.Drawing.Color.Silver;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.checkBox_previewPrint);
            this.ribbonBar1.Controls.Add(this.groupBox1);
            this.ribbonBar1.Controls.Add(this.groupBox3);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(594, 209);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 980;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.Black;
            this.ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // checkBox_previewPrint
            // 
            this.checkBox_previewPrint.AutoSize = true;
            this.checkBox_previewPrint.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_previewPrint.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkBox_previewPrint.ForeColor = System.Drawing.Color.Blue;
            this.checkBox_previewPrint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox_previewPrint.Location = new System.Drawing.Point(402, 36);
            this.checkBox_previewPrint.Name = "checkBox_previewPrint";
            this.checkBox_previewPrint.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_previewPrint.Size = new System.Drawing.Size(177, 17);
            this.checkBox_previewPrint.TabIndex = 1021;
            this.checkBox_previewPrint.Text = "تعيين إعدادات الطابعة الإفتراضية ";
            this.checkBox_previewPrint.UseVisualStyleBackColor = false;
            this.checkBox_previewPrint.CheckedChanged += new System.EventHandler(this.checkBox_previewPrint_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.Controls.Add(this.checkBox_Collate);
            this.groupBox1.Controls.Add(this.txtLeftM);
            this.groupBox1.Controls.Add(this.txtTopM);
            this.groupBox1.Controls.Add(this.CmbPrinter);
            this.groupBox1.Controls.Add(this.txtWidth);
            this.groupBox1.Controls.Add(this.txtHeight);
            this.groupBox1.Controls.Add(this.txtBarWidth);
            this.groupBox1.Controls.Add(this.txtBarHeigth);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(585, 110);
            this.groupBox1.TabIndex = 983;
            this.groupBox1.TabStop = false;
            // 
            // checkBox_Collate
            // 
            this.checkBox_Collate.AutoSize = true;
            this.checkBox_Collate.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_Collate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.checkBox_Collate.ForeColor = System.Drawing.Color.Maroon;
            this.checkBox_Collate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox_Collate.Location = new System.Drawing.Point(66, 53);
            this.checkBox_Collate.Name = "checkBox_Collate";
            this.checkBox_Collate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_Collate.Size = new System.Drawing.Size(71, 17);
            this.checkBox_Collate.TabIndex = 1022;
            this.checkBox_Collate.Text = "تجـميــــع";
            this.checkBox_Collate.UseVisualStyleBackColor = false;
            // 
            // txtLeftM
            // 
            this.txtLeftM.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtLeftM.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtLeftM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLeftM.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtLeftM.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtLeftM.Increment = 1D;
            this.txtLeftM.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtLeftM.Location = new System.Drawing.Point(20, 21);
            this.txtLeftM.MinValue = 0D;
            this.txtLeftM.Name = "txtLeftM";
            this.txtLeftM.Size = new System.Drawing.Size(47, 20);
            this.txtLeftM.TabIndex = 3;
            // 
            // txtTopM
            // 
            this.txtTopM.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtTopM.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTopM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTopM.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTopM.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtTopM.Increment = 1D;
            this.txtTopM.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTopM.Location = new System.Drawing.Point(153, 21);
            this.txtTopM.MinValue = 0D;
            this.txtTopM.Name = "txtTopM";
            this.txtTopM.Size = new System.Drawing.Size(47, 20);
            this.txtTopM.TabIndex = 2;
            // 
            // CmbPrinter
            // 
            this.CmbPrinter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbPrinter.DisplayMember = "Text";
            this.CmbPrinter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPrinter.FormattingEnabled = true;
            this.CmbPrinter.ItemHeight = 14;
            this.CmbPrinter.Location = new System.Drawing.Point(296, 21);
            this.CmbPrinter.Name = "CmbPrinter";
            this.CmbPrinter.Size = new System.Drawing.Size(202, 20);
            this.CmbPrinter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbPrinter.TabIndex = 1;
            // 
            // txtWidth
            // 
            this.txtWidth.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtWidth.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtWidth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtWidth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtWidth.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtWidth.Increment = 1D;
            this.txtWidth.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtWidth.Location = new System.Drawing.Point(310, 84);
            this.txtWidth.MinValue = 0D;
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.ShowUpDown = true;
            this.txtWidth.Size = new System.Drawing.Size(85, 20);
            this.txtWidth.TabIndex = 6;
            // 
            // txtHeight
            // 
            this.txtHeight.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtHeight.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtHeight.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtHeight.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtHeight.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtHeight.Increment = 1D;
            this.txtHeight.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtHeight.Location = new System.Drawing.Point(52, 81);
            this.txtHeight.MinValue = 0D;
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.ShowUpDown = true;
            this.txtHeight.Size = new System.Drawing.Size(85, 20);
            this.txtHeight.TabIndex = 7;
            this.txtHeight.Value = 2D;
            // 
            // txtBarWidth
            // 
            this.txtBarWidth.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtBarWidth.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.txtBarWidth.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtBarWidth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBarWidth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtBarWidth.DisplayFormat = "0";
            this.txtBarWidth.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtBarWidth.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtBarWidth.Location = new System.Drawing.Point(430, 51);
            this.txtBarWidth.MinValue = 0;
            this.txtBarWidth.Name = "txtBarWidth";
            this.txtBarWidth.ShowUpDown = true;
            this.txtBarWidth.Size = new System.Drawing.Size(68, 21);
            this.txtBarWidth.TabIndex = 4;
            this.txtBarWidth.Value = 1;
            // 
            // txtBarHeigth
            // 
            this.txtBarHeigth.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtBarHeigth.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.txtBarHeigth.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtBarHeigth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBarHeigth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtBarHeigth.DisplayFormat = "0";
            this.txtBarHeigth.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtBarHeigth.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtBarHeigth.Location = new System.Drawing.Point(291, 51);
            this.txtBarHeigth.MinValue = 0;
            this.txtBarHeigth.Name = "txtBarHeigth";
            this.txtBarHeigth.ShowUpDown = true;
            this.txtBarHeigth.Size = new System.Drawing.Size(68, 21);
            this.txtBarHeigth.TabIndex = 5;
            this.txtBarHeigth.Value = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(143, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "الإرتفاع بين كروت الباركود :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(68, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "هامش يسار :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(367, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "الإرتفـــاع :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(498, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "العـــرض :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(401, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "البعد العرضي بين كروت الباركود :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(498, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "اختيار الطابعة :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(201, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "هامش اعلى :";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox3.Controls.Add(this.txtpageCount);
            this.groupBox3.Controls.Add(this.label33);
            this.groupBox3.Controls.Add(this.txtNumRows);
            this.groupBox3.Controls.Add(this.txtNumCols);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(7, 144);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(581, 45);
            this.groupBox3.TabIndex = 990;
            this.groupBox3.TabStop = false;
            // 
            // txtpageCount
            // 
            this.txtpageCount.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtpageCount.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtpageCount.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtpageCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtpageCount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtpageCount.DisplayFormat = "0";
            this.txtpageCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtpageCount.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtpageCount.Location = new System.Drawing.Point(20, 17);
            this.txtpageCount.MinValue = 1;
            this.txtpageCount.Name = "txtpageCount";
            this.txtpageCount.ShowUpDown = true;
            this.txtpageCount.Size = new System.Drawing.Size(62, 21);
            this.txtpageCount.TabIndex = 1001;
            this.txtpageCount.Value = 1;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label33.ForeColor = System.Drawing.Color.Blue;
            this.label33.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label33.Location = new System.Drawing.Point(83, 21);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(69, 13);
            this.label33.TabIndex = 1000;
            this.label33.Text = "عدد النسخ :";
            // 
            // txtNumRows
            // 
            this.txtNumRows.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtNumRows.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtNumRows.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtNumRows.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNumRows.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtNumRows.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtNumRows.Increment = 1D;
            this.txtNumRows.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtNumRows.Location = new System.Drawing.Point(416, 17);
            this.txtNumRows.MinValue = 0D;
            this.txtNumRows.Name = "txtNumRows";
            this.txtNumRows.ShowUpDown = true;
            this.txtNumRows.Size = new System.Drawing.Size(62, 20);
            this.txtNumRows.TabIndex = 8;
            this.txtNumRows.Value = 1D;
            // 
            // txtNumCols
            // 
            this.txtNumCols.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtNumCols.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtNumCols.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtNumCols.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNumCols.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtNumCols.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtNumCols.Increment = 1D;
            this.txtNumCols.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtNumCols.Location = new System.Drawing.Point(204, 17);
            this.txtNumCols.MinValue = 0D;
            this.txtNumCols.Name = "txtNumCols";
            this.txtNumCols.ShowUpDown = true;
            this.txtNumCols.Size = new System.Drawing.Size(62, 20);
            this.txtNumCols.TabIndex = 9;
            this.txtNumCols.Value = 1D;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(265, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 13);
            this.label9.TabIndex = 990;
            this.label9.Text = "عدد الكروت عرضيا :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(478, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 989;
            this.label8.Text = "عدد الكروت طوليا :";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox2.Controls.Add(this.ButWithoutSave);
            this.groupBox2.Controls.Add(this.ButWithSave);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 209);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(594, 54);
            this.groupBox2.TabIndex = 983;
            this.groupBox2.TabStop = false;
            // 
            // ButWithoutSave
            // 
            this.ButWithoutSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButWithoutSave.Checked = true;
            this.ButWithoutSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ButWithoutSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButWithoutSave.Location = new System.Drawing.Point(15, 14);
            this.ButWithoutSave.Name = "ButWithoutSave";
            this.ButWithoutSave.Size = new System.Drawing.Size(280, 35);
            this.ButWithoutSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButWithoutSave.Symbol = "";
            this.ButWithoutSave.SymbolSize = 12F;
            this.ButWithoutSave.TabIndex = 13;
            this.ButWithoutSave.Text = "خــــروج";
            this.ButWithoutSave.TextColor = System.Drawing.Color.Black;
            this.ButWithoutSave.Click += new System.EventHandler(this.ButWithoutSave_Click);
            // 
            // ButWithSave
            // 
            this.ButWithSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButWithSave.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.ButWithSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButWithSave.Location = new System.Drawing.Point(303, 14);
            this.ButWithSave.Name = "ButWithSave";
            this.ButWithSave.Size = new System.Drawing.Size(280, 35);
            this.ButWithSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButWithSave.Symbol = "";
            this.ButWithSave.SymbolSize = 12F;
            this.ButWithSave.TabIndex = 12;
            this.ButWithSave.Text = "حفــــظ";
            this.ButWithSave.TextColor = System.Drawing.Color.White;
            this.ButWithSave.Click += new System.EventHandler(this.ButWithSave_Click);
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.DimGray;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX1.Font = new System.Drawing.Font("Tahoma", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labelX1.ForeColor = System.Drawing.Color.White;
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(594, 30);
            this.labelX1.TabIndex = 984;
            this.labelX1.Text = "إعدادات طباعة الباركود";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelX1.Click += new System.EventHandler(this.labelX1_Click);
            // 
            // FMBarCodePrintSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(594, 263);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.ribbonBar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.CmbPrintP2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CmbPrintP);
            this.Controls.Add(this.CmbDir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FMBarCodePrintSetup";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FMBarCodePrintSetup_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.ribbonBar1.ResumeLayout(false);
            this.ribbonBar1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeftM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTopM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarHeigth)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtpageCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumCols)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.ResumeLayout(false);

        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }
    }
}
