using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using Framework.Data;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using Microsoft.Win32;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FMReceiptVoucherCustSupp : Form
    { void avs(int arln)

{ 
 //label16.Text=   (arln == 0 ? "  البيان / إنجليزي :  " : "  Statement / English:") ; label9.Text=   (arln == 0 ? "  البيان / إنجليزي :  " : "  Statement / English:") ; label14.Text=   (arln == 0 ? "  المبلـــغ :  " : "  Amount:") ; Label2.Text=   (arln == 0 ? "  التاريخ :  " : "  Date :") ; groupPanel1.Text=   (arln == 0 ? "  إجمالي مديونية العميل  " : "  Total client indebtedness") ; Label1.Text=   (arln == 0 ? "  رقم السند :  " : "  Bond No :") ; label13.Text=   (arln == 0 ? "  البيان / عـــربي :  " : "  Statement / Arabic:") ; label12.Text=   (arln == 0 ? "  البيان / عـــربي :  " : "  Statement / Arabic:") ; label19.Text=   (arln == 0 ? "  العملــــــــة :  " : "  work:") ; label18.Text=   (arln == 0 ? "  المنـــــدوب :  " : "  The delegate:") ; label15.Text=   (arln == 0 ? "  مركز التكلفــة :  " : "  cost center:") ; label11.Text=   (arln == 0 ? "  حساب العميل :  " : "  Customer account:") ; label4.Text=   (arln == 0 ? "  الحساب المدين :  " : "  debit account:") ; label7.Text=   (arln == 0 ? "  رقم المرجع :  " : "  reference number :") ; label8.Text=   (arln == 0 ? "  إستلمنا من :  " : "  we received from :") ; label17.Text=   (arln == 0 ? "  الرصيد  " : "  Balance") ; Label21.Text=   (arln == 0 ? "  قيمة الدائن  " : "  creditor value") ; label5.Text=   (arln == 0 ? "  رقم الشيك  " : "  check number") ; label3.Text=   (arln == 0 ? "  قيمة المدين  " : "  Debit value") ; label6.Text=   (arln == 0 ? "  الحســــاب :  " : "  Account:") ; superTabControl_Main1.Text=   (arln == 0 ? "  superTabControl3  " : "  superTabControl3") ; Button_Close.Text=   (arln == 0 ? "  إغلاق  " : "  Close") ; Button_Save.Text=   (arln == 0 ? "  حفظ  " : "  save") ; ToolStripMenuItem_Rep.Text=   (arln == 0 ? "  إظهار التقرير  " : "  Show report") ; panelEx2.Text=   (arln == 0 ? "  Click to collapse  " : "  Click to collapse") ; ToolStripMenuItem_Det.Text=   (arln == 0 ? "  إظهار التفاصيل  " : "  Show details") ; Text = "قيد يومي";this.Text=   (arln == 0 ? "  قيد يومي  " : "  daily entry") ;
        
        }
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
       // private IContainer components = null;
        private void netResize1_AfterControlResize(object sender, Softgroup.NetResize.AfterControlResizeEventArgs e)
        {
            if (e.Control.Name.Contains("ribbonBar_Tasks"))
            {
                ribbonBar_Tasks.Font = new Font("Tahoma", 8F);
                ribbonBar1.BackgroundStyle.BackColor = Color.Gainsboro;
                ribbonBar1.BackgroundStyle.BackColor2 = Color.Gainsboro;
            }
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
        private void superTabControl_Main1_RightToLeftChanged(object sender, EventArgs e)
        {
            superTabControl_Main1.RightToLeftChanged -= superTabControl_Main1_RightToLeftChanged;
            superTabControl_Main1.RightToLeft = RightToLeft.No;
            superTabControl_Main1.RightToLeftChanged -= superTabControl_Main1_RightToLeftChanged;
        }
        public Softgroup.NetResize.NetResize netResize1;
        protected ToolStripMenuItem ToolStripMenuItem_Rep;
        private ExpandableSplitter expandableSplitter1;
        private PanelEx panelEx2;
        private RibbonBar ribbonBar1;
        private TextBox txtChequeNo;
        private Label label5;
        internal Label label3;
        private Label label6;
        internal PrintPreviewDialog prnt_prev;
        private PrintDocument prnt_doc;
        protected ContextMenuStrip contextMenuStrip2;
        protected ToolStripMenuItem ToolStripMenuItem_Det;
        private DockSite dockSite1;
        private System.Windows.Forms. SaveFileDialog saveFileDialog1;
        protected ContextMenuStrip contextMenuStrip1;
        private Panel panel1;
        private DockSite dockSite4;
        private DockSite dockSite3;
        private DockSite barTopDockSite;
        private DockSite barBottomDockSite;
        private DockSite barLeftDockSite;
        private DockSite barRightDockSite;
        private DockSite dockSite2;
        private System.Windows.Forms.OpenFileDialog  openFileDialog1;
        private Timer timerInfoBallon;
        private Timer timer1;
        private ImageList imageList1;
        public DotNetBarManager dotNetBarManager1;
        private RibbonBar ribbonBar_Tasks;
        private SuperTabControl superTabControl_Main1;
        protected ButtonItem Button_Close;
        protected ButtonItem Button_Save;
        protected LabelItem labelItem2;
        internal Label label10;
        internal Label label17;
        internal Label Label21;
        internal Label label7;
        private Label label8;
        private TextBox txtReceivedForm;
        private Panel panel2;
        private Label label13;
        private Label label12;
        internal Label label19;
        internal Label label18;
        internal Label label15;
        private TextBox txtRemark;
        private ButtonX button_CustSrchAccNo;
        private TextBox txtCustAccNo;
        internal Label label11;
        private ButtonX button_SrchAccNo;
        private TextBox txtAccNo;
        internal Label label4;
        private ComboBoxEx CmbCostC;
        private ComboBoxEx CmbCurr;
        private ComboBoxEx CmbLegate;
        private TextBox txtCustAccName;
        private TextBox txtCustDescription;
        private TextBox txtAccNameR;
        internal TextBox textBox_ID;
        internal Label Label1;
        private GroupPanel groupPanel1;
        internal Label Label2;
        private DoubleInput txtAmount;
        internal Label label14;
        private DoubleInput label_Balance;
        private MaskedTextBox txtGDate;
        private MaskedTextBox txtHDate;
        private Label label16;
        private TextBox txtRemarkE;
        private Label label9;
        private TextBox txtCustDescriptionE;
        public static int LangArEn = 0;
        private ScriptNumber ScriptNumber1 = new ScriptNumber();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        public Dictionary<string, string> columns_Nams_Sums = new Dictionary<string, string>();
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
        public bool ifCheckData = false;
        public long TimeFinish = 0L;
        public long TimeStart = 0L;
        public TextBox textBox_Type = new TextBox();
        public List<string> pkeys = new List<string>();
        public bool canUpdate = true;
        protected bool CanInsert = true;
        public FormState statex;
        public ViewState ViewState = ViewState.Deiles;
        public string tableName = "";
        protected bool ifModify = true;
        public List<Control> controls;
        public Control codeControl = new Control();
        public bool CanEdit = true;
        protected bool ifOkDelete;
        private T_SYSSETTING _SysSetting = new T_SYSSETTING();
        private List<T_SYSSETTING> listSysSetting = new List<T_SYSSETTING>();
        private T_AccDef _AccDef = new T_AccDef();
        private List<T_AccDef> listAccDef = new List<T_AccDef>();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private List<T_INVSETTING> listInvSetting = new List<T_INVSETTING>();
        private T_GDHEAD data_this;
        private T_STKSQTY data_this_stkQ;
        private List<T_GDDET> LData_This;
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        public List<string> PKeys
        {
            get
            {
                return pkeys;
            }
            set
            {
                pkeys = value;
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
        public string TableName
        {
            get
            {
                return tableName;
            }
            set
            {
                tableName = value;
            }
        }
        public bool IfSave
        {
            set
            {
                Button_Save.Visible = value;
            }
        }
        public bool IfClose
        {
            set
            {
                Button_Close.Visible = value;
            }
        }
        public T_GDHEAD DataThis
        {
            get
            {
                return data_this;
            }
            set
            {
                data_this = value;
            }
        }
        public T_STKSQTY DataThis_stkQ
        {
            get
            {
                return data_this_stkQ;
            }
            set
            {
                data_this_stkQ = value;
            }
        }
        public List<T_GDDET> LDataThis
        {
            get
            {
                return LData_This;
            }
            set
            {
                LData_This = value;
            }
        }
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
        private Rate_DataDataContext dbc
        {
            get
            {
                if (dbInstanceRate == null)
                {
                    dbInstanceRate = new Rate_DataDataContext(VarGeneral.BranchRt);
                }
                return dbInstanceRate;
            }
        }
        protected bool Check()
        {
            if (!ifCheckData)
            {
                return true;
            }
            return true;
        }
        public FMReceiptVoucherCustSupp()
        {
            InitializeComponent();this.Load += langloads;
            ADD_Controls();
            Button_Close.Click += Button_Close_Click;
            Button_Save.Click += Button_Save_Click;
            textBox_ID.Click += textBox_ID_Click;
            txtHDate.Click += txtHDate_Click;
            txtHDate.Leave += txtHDate_Leave;
            txtGDate.Click += txtGDate_Click;
            txtGDate.Leave += txtGDate_Leave;
            button_SrchAccNo.Click += button_SrchAccNo_Click;
            if (VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F" || VarGeneral.SSSLev == "S" || VarGeneral.SSSLev == "C")
            {
                CmbCostC.Visible = false;
                label15.Visible = false;
            }
            else
            {
                CmbCostC.Visible = true;
                label15.Visible = true;
            }
            try
            {
                if (VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F")
                {
                    RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
                    try
                    {
                        object q = hKey.GetValue("vCoCe");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vCoCe");
                            hKey.SetValue("vCoCe", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vCoCe");
                        hKey.SetValue("vCoCe", "0");
                    }
                    long regval = long.Parse(hKey.GetValue("vCoCe").ToString());
                    if (regval == 1)
                    {
                        CmbCostC.Visible = true;
                        label15.Visible = true;
                    }
                    else
                    {
                        CmbCostC.Visible = false;
                        label15.Visible = false;
                    }
                }
            }
            catch
            {
            }
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
            {
                label_Balance.DisplayFormat = VarGeneral.DicemalMask;
                txtAmount.DisplayFormat = VarGeneral.DicemalMask;
            }
        }
        private void textBox_ID_Click(object sender, EventArgs e)
        {
            textBox_ID.SelectAll();
        }
        private void Button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                textBox_ID.Focus();
                if (SaveData())
                {
                    State = FormState.Saved;
                    dbInstance = null;
                    Button_Add_Click(sender, e);
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Button_Save_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void Button_Add_Click(object sender, EventArgs e)
        {
            Clear();
            txtGDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
            txtHDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
            GetInvSetting();
            textBox_ID.Text = db.MaxGDHEADsNo.ToString();
            textBox_ID.Focus();
            label_Balance_ValueChanged(sender, e);
        }
        public void Clear()
        {
            if (State == FormState.New)
            {
                return;
            }
            State = FormState.New;
            data_this = new T_GDHEAD();
            State = FormState.New;
            for (int i = 0; i < controls.Count; i++)
            {
                if (controls[i].GetType() == typeof(DateTimePicker))
                {
                    int? calendr = VarGeneral.Settings_Sys.Calendr;
                    if (calendr.Value == 0 && calendr.HasValue)
                    {
                        (controls[i] as DateTimePicker).Value = Convert.ToDateTime(n.GDateNow());
                    }
                    else
                    {
                        (controls[i] as DateTimePicker).Text = n.HDateNow();
                    }
                }
                else if (controls[i].GetType() == typeof(CheckBox))
                {
                    (controls[i] as CheckBox).Checked = false;
                }
                else if (controls[i].GetType() == typeof(PictureBox))
                {
                    (controls[i] as PictureBox).Image = null;
                }
                else
                {
                    if (controls[i].Name == codeControl.Name)
                    {
                        continue;
                    }
                    if (controls[i].GetType() == typeof(DoubleInput))
                    {
                        (controls[i] as DoubleInput).Value = 0.0;
                    }
                    else if (controls[i].GetType() == typeof(IntegerInput))
                    {
                        (controls[i] as IntegerInput).Value = 0;
                    }
                    else if (controls[i].GetType() == typeof(TextBox) || controls[i].GetType() == typeof(TextBoxX) || controls[i].GetType() == typeof(MaskedTextBox))
                    {
                        controls[i].Text = "";
                    }
                    else if (controls[i].GetType() == typeof(CheckBox))
                    {
                        (controls[i] as CheckBox).Checked = false;
                    }
                    else if (controls[i].GetType() == typeof(RadioButton))
                    {
                        (controls[i] as RadioButton).Checked = false;
                    }
                    else if (controls[i].GetType() == typeof(ComboBox))
                    {
                        (controls[i] as ComboBox).SelectedIndex = 0;
                    }
                    else if (controls[i].GetType() == typeof(ComboBoxEx))
                    {
                        try
                        {
                            (controls[i] as ComboBoxEx).SelectedIndex = 0;
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }
        private bool ValidData()
        {
            if (textBox_ID.Text == "0" || textBox_ID.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ بدون رقم الفاتورة - السند" : "Can not save without the invoice number", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (txtAmount.Value == 0.0 || txtAmount.Value == 0.0)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ والصافي يساوي صفر" : "Can not save, and the total is equal to zero", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (txtCustAccNo.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام العملية .. يجب تحديد حساب العميل اولا\u064c" : "You can not complete the process .. must specify the Customer account number first", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            if (txtCustDescription.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام العملية .. يجب تحديد وصف لحساب العميل اولا\u064c" : "You can not complete the process .. must specify the Customer account Decription", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (txtAccNo.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام العملية .. يجب تحديد حساب المدين اولا\u064c" : "You can not complete the process .. must specify the debit account number first", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (txtRemark.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام العملية .. يجب تحديد وصف لحساب المدين اولا\u064c" : "You can not complete the process .. must specify the debit account Decription", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            try
            {
                if (VarGeneral.CheckDate(VarGeneral.Settings_Sys.AccCusDes.Trim()) && VarGeneral.CheckDate(VarGeneral.Settings_Sys.AccSupDes.Trim()))
                {
                    if (Convert.ToDateTime(n.FormatGreg(txtGDate.Text, "yyyy/MM/dd")) <= Convert.ToDateTime(VarGeneral.Settings_Sys.AccCusDes) && Convert.ToDateTime(n.FormatGreg(txtGDate.Text, "yyyy/MM/dd")) >= Convert.ToDateTime(VarGeneral.Settings_Sys.AccSupDes))
                    {
                        return true;
                    }
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. لقد تخطيت السنة المالية المحدد للنظام \n يرجى التواصل مع الإدارة لإتمام عملية الإقفال السنوية " : "We can not complete the operation .. have you skip the fiscal year specified for the system", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. لقد تخطيت السنة المالية المحدد للنظام \n يرجى التواصل مع الإدارة لإتمام عملية الإقفال السنوية " : "We can not complete the operation .. have you skip the fiscal year specified for the system", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            return true;
        }
        private T_GDHEAD GetData()
        {
            data_this.gdHDate = txtHDate.Text;
            data_this.gdGDate = txtGDate.Text;
            data_this.gdNo = textBox_ID.Text;
            data_this.BName = data_this.BName;
            data_this.ChekNo = txtChequeNo.Text;
            data_this.CurTyp = int.Parse(CmbCurr.SelectedValue.ToString());
            data_this.ArbTaf = ScriptNumber1.ScriptNum(decimal.Parse(VarGeneral.TString.TEmpty(string.Concat(txtAmount.Value))));
            data_this.EngTaf = ScriptNumber1.TafEng(decimal.Parse(VarGeneral.TString.TEmpty(string.Concat(txtAmount.Value))));
            data_this.gdCstNo = int.Parse(CmbCostC.SelectedValue.ToString());
            data_this.gdID = 0;
            data_this.gdLok = false;
            data_this.gdMem = txtReceivedForm.Text;
            if (CmbLegate.SelectedIndex > 0)
            {
                data_this.gdMnd = int.Parse(CmbLegate.SelectedValue.ToString());
            }
            else
            {
                data_this.gdMnd = null;
            }
            data_this.gdRcptID = (data_this.gdRcptID.HasValue ? data_this.gdRcptID.Value : 0.0);
            data_this.gdTot = txtAmount.Value;
            data_this.gdTp = (data_this.gdTp!=0? data_this.gdTp : 0);
            data_this.gdTyp = 11;
            data_this.AdminLock = false;
            data_this.gdUser = VarGeneral.UserNumber;
            data_this.gdUserNam = VarGeneral.UserNameA;
            data_this.RefNo = "";
            data_this.salMonth = "";
            try
            {
                if (CmbLegate.SelectedIndex != -1)
                {
                    T_Mndob q = db.StockMndobID(int.Parse(CmbLegate.SelectedValue.ToString()));
                    if (q.Comm_Inv.Value > 0.0 && txtAmount.Value > 0.0)
                    {
                        data_this.CommMnd_Gaid = txtAmount.Value * (q.Comm_Gaid.Value / 100.0);
                    }
                    else
                    {
                        data_this.CommMnd_Gaid = 0.0;
                    }
                }
                else
                {
                    data_this.CommMnd_Gaid = 0.0;
                }
            }
            catch
            {
                data_this.CommMnd_Gaid = 0.0;
            }
            data_this.CompanyID = 1;
            return data_this;
        }
        private void GetInvSetting()
        {
            _InvSetting = new T_INVSETTING();
            _SysSetting = new T_SYSSETTING();
            listAccDef = new List<T_AccDef>();
            _InvSetting = db.StockInvSetting( VarGeneral.InvTyp);
            _SysSetting = db.SystemSettingStock();
            listAccDef = db.StockAccDefList();
        }
        private void FillCombo()
        {
            int _CmbIndex = CmbCurr.SelectedIndex;
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                List<T_Curency> listAccCat = new List<T_Curency>(db.T_Curencies.Select((T_Curency item) => item).ToList());
                CmbCurr.DataSource = listAccCat;
                CmbCurr.DisplayMember = "Arb_Des";
                CmbCurr.ValueMember = "Curency_ID";
            }
            else
            {
                List<T_Curency> listCurr = new List<T_Curency>(db.T_Curencies.Select((T_Curency item) => item).ToList());
                CmbCurr.DataSource = listCurr;
                CmbCurr.DisplayMember = "Eng_Des";
                CmbCurr.ValueMember = "Curency_ID";
            }
            CmbCurr.SelectedIndex = _CmbIndex;
            _CmbIndex = CmbLegate.SelectedIndex;
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                List<T_Mndob> listMnd = new List<T_Mndob>(db.T_Mndobs.Where((T_Mndob item) => item.Mnd_Typ.Value == 0).ToList());
                listMnd.Insert(0, new T_Mndob());
                CmbLegate.DataSource = listMnd;
                CmbLegate.DisplayMember = "Arb_Des";
                CmbLegate.ValueMember = "Mnd_ID";
            }
            else
            {
                List<T_Mndob> listMnd = new List<T_Mndob>(db.T_Mndobs.Where((T_Mndob item) => item.Mnd_Typ.Value == 0).ToList());
                listMnd.Insert(0, new T_Mndob());
                CmbLegate.DataSource = listMnd;
                CmbLegate.DisplayMember = "Eng_Des";
                CmbLegate.ValueMember = "Mnd_ID";
            }
            CmbLegate.SelectedIndex = _CmbIndex;
            _CmbIndex = CmbCostC.SelectedIndex;
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                List<T_CstTbl> listCs = new List<T_CstTbl>(db.T_CstTbls.Select((T_CstTbl item) => item).ToList());
                CmbCostC.DataSource = listCs;
                CmbCostC.DisplayMember = "Arb_Des";
                CmbCostC.ValueMember = "Cst_ID";
            }
            else
            {
                List<T_CstTbl> listCs = new List<T_CstTbl>(db.T_CstTbls.Select((T_CstTbl item) => item).ToList());
                CmbCostC.DataSource = listCs;
                CmbCostC.DisplayMember = "Eng_Des";
                CmbCostC.ValueMember = "Cst_ID";
            }
            CmbCostC.SelectedIndex = _CmbIndex;
        }
        private void ADD_Controls()
        {
            try
            {
                controls = new List<Control>();
                controls.Add(textBox_ID);
                codeControl = textBox_ID;
                controls.Add(textBox_Type);
                controls.Add(txtGDate);
                controls.Add(txtHDate);
                controls.Add(txtRemark);
                controls.Add(txtRemarkE);
                controls.Add(CmbCostC);
                controls.Add(CmbCurr);
                controls.Add(CmbLegate);
                controls.Add(txtAccNo);
                controls.Add(txtReceivedForm);
                controls.Add(txtAccNameR);
                controls.Add(txtCustDescription);
                controls.Add(txtCustDescriptionE);
                controls.Add(txtCustAccNo);
                controls.Add(txtCustAccName);
                controls.Add(txtAmount);
                controls.Add(label_Balance);
            }
            catch (SqlException)
            {
            }
        }
        private void txtHDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtHDate.Text))
                {
                    txtHDate.Text = Convert.ToDateTime(txtHDate.Text).ToString("yyyy/MM/dd");
                    txtHDate.Text = n.FormatHijri(txtHDate.Text, "yyyy/MM/dd");
                    txtGDate.Text = n.HijriToGreg(txtHDate.Text, "yyyy/MM/dd");
                }
                else
                {
                    txtHDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                }
            }
            catch
            {
                txtHDate.Text = "";
            }
        }
        private void txtGDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtGDate.Text))
                {
                    txtGDate.Text = Convert.ToDateTime(txtGDate.Text).ToString("yyyy/MM/dd");
                    txtGDate.Text = n.FormatGreg(txtGDate.Text, "yyyy/MM/dd");
                    txtHDate.Text = n.GregToHijri(txtGDate.Text, "yyyy/MM/dd");
                }
                else
                {
                    txtGDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                }
            }
            catch
            {
                txtGDate.Text = "";
            }
        }
        private void txtGDate_Click(object sender, EventArgs e)
        {
            txtGDate.SelectAll();
        }
        private bool SaveData()
        {
            if (!ValidData())
            {
                return false;
            }
            try
            {
                GetData();
                IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
                if (State == FormState.New)
                {
                    try
                    {
                        GetInvSetting();
                        data_this.DATE_CREATED = DateTime.Now;
                        db.T_GDHEADs.InsertOnSubmit(data_this);
                        db.SubmitChanges();
                    }
                    catch (SqlException ex2)
                    {
                        string max = "";
                        max = db.MaxGDHEADsNo.ToString();
                        if (ex2.Number == 2627)
                        {
                            MessageBox.Show("الرمز مستخدم من قبل.\n سيتم الحفظ برقم جديد [" + max + "]", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            textBox_ID.Text = max ?? "";
                            data_this.gdNo = max ?? "";
                            Button_Save_Click(null, null);
                        }
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
                else
                {
                    db.Log = VarGeneral.DebugLog;
                    db.SubmitChanges(ConflictMode.ContinueOnConflict);
                    for (int i = 0; i < data_this.T_GDDETs.Count; i++)
                    {
                        db_.StartTransaction();
                        db_.ClearParameters();
                        db_.AddParameter("GDDET_ID", DbType.Int32, data_this.T_GDDETs[i].GDDET_ID);
                        db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_DELETE");
                        db_.EndTransaction();
                    }
                }
                double txtAmountValue = txtAmount.Value;
                if (VarGeneral.AccTyp != 4)
                {
                    txtAmountValue = txtAmountValue * -1;
                }
                    db_.StartTransaction();
                db_.ClearParameters();
                db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                db_.AddParameter("gdID", DbType.Int32, data_this.gdhead_ID);
                db_.AddParameter("gdNo", DbType.String, textBox_ID.Text);
                db_.AddParameter("gdDes", DbType.String, txtRemark.Text);
                db_.AddParameter("gdDesE", DbType.String, txtRemarkE.Text);
                db_.AddParameter("recptTyp", DbType.String, "11");
                db_.AddParameter("AccNo", DbType.String, txtAccNo.Text);
                db_.AddParameter("AccName", DbType.String, txtAccNameR.Text);
                db_.AddParameter("gdValue", DbType.Double, txtAmountValue);
                db_.AddParameter("recptNo", DbType.String, textBox_ID.Text);
                db_.AddParameter("Lin", DbType.Int32, 1);
                db_.AddParameter("AccNoDestruction", DbType.String, null);
                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                db_.EndTransaction();
                db_.StartTransaction();
                db_.ClearParameters();
                db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                db_.AddParameter("gdID", DbType.Int32, data_this.gdhead_ID);
                db_.AddParameter("gdNo", DbType.String, textBox_ID.Text);
                db_.AddParameter("gdDes", DbType.String, txtCustDescription.Text);
                db_.AddParameter("gdDesE", DbType.String, txtCustDescriptionE.Text);
                db_.AddParameter("recptTyp", DbType.String, "11");
                db_.AddParameter("AccNo", DbType.String, txtCustAccNo.Text);
                db_.AddParameter("AccName", DbType.String, txtCustAccName.Text);
                db_.AddParameter("gdValue", DbType.Double, 0.0 - txtAmountValue);
                db_.AddParameter("recptNo", DbType.String, textBox_ID.Text);
                db_.AddParameter("Lin", DbType.Int32, 2);
                db_.AddParameter("AccNoDestruction", DbType.String, null);
                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                db_.EndTransaction();
                dbInstance = null;
                MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex3)
            {
                MessageBox.Show(ex3.Message);
                return false;
            }
            return true;
        }
        private void txtHDate_Click(object sender, EventArgs e)
        {
            txtHDate.SelectAll();
        }
        private void txtGDate_Enter(object sender, EventArgs e)
        {
            Framework.Keyboard.Language.Switch("English");
        }
        private void txtHDate_Enter(object sender, EventArgs e)
        {
            Framework.Keyboard.Language.Switch("Arabic");
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
            if (e.KeyCode == Keys.F2 && Button_Save.Enabled && Button_Save.Visible && State != 0)
            {
                Button_Save_Click(sender, e);
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
                Button_Close.Text = "اغلاق";
                Button_Save.Text = "حفظ";
                Button_Close.Tooltip = "Esc";
                Button_Save.Tooltip = "F2";
                Label1.Text = "رقم السند :";
                Label2.Text = "التاريخ :";
                label7.Text = "رقم المرجع :";
                label19.Text = "العملــــــــة :";
                label18.Text = "المنـــــدوب :";
                label15.Text = "مركز التكلفـــــة :";
                label6.Text = "الحســــاب :";
                label3.Text = "قيمة المدين";
                Label21.Text = "قيمة الدائن";
                label17.Text = "الرصيد";
                label8.Text = "إستلمنا من :";
                label4.Text = "حساب المدين :";
                if (VarGeneral.AccTyp == 4)
                {
                    groupPanel1.Text = "إجمالي مديونية العميل";
                    label11.Text = "حساب العميل :";
                }
                else
                {
                    groupPanel1.Text = "إجمالي مديونية المورد";
                    label11.Text = "حساب المورد :";
                }
                Text = "قيــد يـومــي";
            }
            else
            {
                Button_Close.Text = "Close";
                Button_Save.Text = "Save";
                Button_Close.Tooltip = "Esc";
                Button_Save.Tooltip = "F2";
                Label1.Text = "Number :";
                Label2.Text = "Date :";
                label7.Text = "Reference No :";
                label19.Text = "Currncy :";
                label18.Text = "Delegate :";
                label15.Text = "Cost Center :";
                label6.Text = "Account :";
                label3.Text = "Debtor";
                Label21.Text = "Creditor";
                label17.Text = "Balance";
                label8.Text = "Received from :";
                label4.Text = "Debtor account :";
                if (VarGeneral.AccTyp == 4)
                {
                    label11.Text = "Debtor Account :";
                }
                else
                {
                    label11.Text = "Supplier Acc :";
                }
                groupPanel1.Text = "Total Debit Value";
                Text = "Under daily";
            }
        }
        private void FMReceiptVoucherCustSupp_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FMReceiptVoucherCustSupp));
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    SSSLanguage.Language.ChangeLanguage("ar-SA", this, resources);
                    LangArEn = 0;
                }
                else
                {
                    SSSLanguage.Language.ChangeLanguage("en", this, resources);
                    LangArEn = 1;
                }
                RibunButtons();
                FillCombo();
                GetInvSetting();
                Button_Add_Click(sender, e);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptMaintenanceCars.dll"))
            {
                label18.Visible = false;
                CmbLegate.Visible = false;
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptBus.dll"))
            {
                label15.Text = ((LangArEn == 0) ? "الباص : " : "Bus :");
                label18.Text = ((LangArEn == 0) ? "السائق :" : "Driver :");
            }
        }
        private void button_SrchAccNo_Click(object sender, EventArgs e)
        {
            if (State == FormState.Saved)
            {
                return;
            }
            if (VarGeneral.SSSTyp == 0)
            {
                VarGeneral.StockOnly = true;
            }
            if (label11.Text == "حساب العميل :")
            {
                VarGeneral.AccTyp = 4;
            }
            else
            {
                VarGeneral.AccTyp = 5;
            }
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
            columns_Names_visible2.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            if (VarGeneral.SSSTyp == 0)
            {
                VarGeneral.SFrmTyp = "T_AccDef";
            }
            else
            {
                VarGeneral.SFrmTyp = "AccDefID_Setting";
            }
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                txtAccNo.Text = _AccDef.AccDef_No.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtAccNameR.Text = _AccDef.Arb_Des.ToString();
                }
                else
                {
                    txtAccNameR.Text = _AccDef.Eng_Des.ToString();
                }
                if (VarGeneral.AccTyp == 4)
                {
                    txtRemark.Text = "سند لتخفيض مديونية العميل";
                    txtRemarkE.Text = "Indebtedness of the customer.";
                }
                else
                {
                    txtRemark.Text = "سند لتخفيض مديونية المورد";
                    txtRemarkE.Text = "Indebtedness of the Supplier.";
                }
            }
        }
        private void label_Balance_ValueChanged(object sender, EventArgs e)
        {
            txtAmount.Value = 0.0;
            txtAmount.MaxValue = label_Balance.Value;
        }
        private void button_CustSrchAccNo_Click(object sender, EventArgs e)
        {
            if (State == FormState.Saved)
            {
                return;
            }
            if (VarGeneral.SSSTyp == 0)
            {
                VarGeneral.StockOnly = true;
            }
            if (label11.Text == "حساب العميل :")
            {
                VarGeneral.AccTyp = 4;
            }
            else
            {
                VarGeneral.AccTyp = 5;
            }
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
            columns_Names_visible2.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_AccDef_Suppliers";
            frm.TopMost = true;
            frm.ShowDialog();
            if (!(frm.SerachNo != ""))
            {
                return;
            }
            _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
            _AccDef.Debit = _AccDef.T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.gdValue > 0.0).Sum((T_GDDET g) => g.gdValue.Value);
            _AccDef.Credit = Math.Abs(_AccDef.T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.gdValue < 0.0).Sum((T_GDDET g) => g.gdValue.Value));
            _AccDef.Balance = _AccDef.T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok).Sum((T_GDDET g) => g.gdValue.Value);
            txtCustAccNo.Text = _AccDef.AccDef_No.ToString();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                txtCustAccName.Text = _AccDef.Arb_Des.ToString();
            }
            else
            {
                txtCustAccName.Text = _AccDef.Eng_Des.ToString();
            }
            if (VarGeneral.AccTyp == 4)
            {
                txtCustDescription.Text = "سند لتخفيض مديونية العميل";
                txtCustDescriptionE.Text = "Indebtedness of the Cust.";
                try
                {
                    if (_AccDef.Balance.Value >0.0)
                    {
                        label_Balance.Value = _AccDef.Balance.Value;
                    }
                    else
                    {
                        label_Balance.Value = 0.0;
                    }
                }
                catch
                {
                    label_Balance.Value = 0.0;
                }

            }
            else
            {
                txtCustDescription.Text = "سند لتخفيض مديونية مورد";
                txtCustDescriptionE.Text = "Indebtedness of theSupplier.";
                try
                {
                    if (_AccDef.Balance.Value < 0.0)
                    {
                        label_Balance.Value =(-1)* _AccDef.Balance.Value;
                    }
                    else
                    {
                        label_Balance.Value = 0.0;
                    }
                }
                catch
                {
                    label_Balance.Value = 0.0;
                }

            }
        }
        private void txtCustDescription_Click(object sender, EventArgs e)
        {
            txtCustDescription.SelectAll();
        }
        private void txtCustDescriptionE_Click(object sender, EventArgs e)
        {
            txtCustDescriptionE.SelectAll();
        }
        private void txtRemark_Click(object sender, EventArgs e)
        {
            txtRemark.SelectAll();
        }
        private void txtRemarkE_Click(object sender, EventArgs e)
        {
            txtRemarkE.SelectAll();
        }
    }
}
