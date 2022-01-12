using C1.Win.C1BarCode;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using InputKey;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using Library.RepShow;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmCustomer : Form
    { void avs(int arln)

{ 
 checkBoxX_Stoped.Text=   (arln == 0 ? "  حظر العميل  " : "  block client") ; label25.Text=   (arln == 0 ? "  العمـــر :  " : "  Age:") ; label24.Text=   (arln == 0 ? "  %  " : "  %") ; label23.Text=   (arln == 0 ? "  نسبة الخصم :  " : "  discount percentage :") ; label22.Text=   (arln == 0 ? "  الــرقم الضريبـــي :  " : "  Tax number:") ; label20.Text=   (arln == 0 ? "  الرمز البريدي :  " : "  Postal code :") ; label6.Text=   (arln == 0 ? "  العنوان :  " : "  Address :") ; label7.Text=   (arln == 0 ? "  الإيميل :  " : "  Email:") ; label8.Text=   (arln == 0 ? "  البلد :  " : "  Country :") ; label12.Text=   (arln == 0 ? "  الفاكس :  " : "  Fax:") ; label13.Text=   (arln == 0 ? "  الجوال :  " : "  cell phone :") ; label9.Text=   (arln == 0 ? "  الهاتف :  " : "  the phone :") ; label11.Text=   (arln == 0 ? "  ص . ب :  " : "  s . B :") ; label18.Text=   (arln == 0 ? "  السعر الإفتراضي :  " : "  Default price:") ; label10.Text=   (arln == 0 ? "  عمر الدين :  " : "  Omar Eddin:") ; label16.Text=   (arln == 0 ? "  حد المديونية :  " : "  Debt Limit:") ; label15.Text=   (arln == 0 ? "  الرصيد الحالي :  " : "  current balance :") ; label14.Text=   (arln == 0 ? "  دائن :  " : "  Creditor :") ; label17.Text=   (arln == 0 ? "  مدين :  " : "  Debit :") ; label19.Text=   (arln == 0 ? "  إسم المسؤول :  " : "  Name of the manager :") ; label3.Text=   (arln == 0 ? "  حساب الأب :  " : "  Father's account:") ; label4.Text=   (arln == 0 ? "  رقم العميل :  " : "  Customer Number :") ; label2.Text=   (arln == 0 ? "  الإسم الإنجليزي :  " : "  English name:") ; label1.Text=   (arln == 0 ? "  الإسم العربي :  " : "  Arabic name:") ; buttonX_CustomerStoped.Text=   (arln == 0 ? "  العملاء الموقوفين  " : "  suspended clients") ; label5.Text=   (arln == 0 ? "  سبب الحظـــر :  " : "  Lucky reason:") ; label21.Text=   (arln == 0 ? "  المنــــــــــــــدوب :  " : "  The delegate:") ; c1BarCode1.Text=   (arln == 0 ? "  1225  " : "  1225") ; line1.Text=   (arln == 0 ? "  line1  " : "  line1") ; superTabControl_Main1.Text=   (arln == 0 ? "  superTabControl3  " : "  superTabControl3") ; Button_Close.Text=   (arln == 0 ? "  إغلاق  " : "  Close") ; Button_Search.Text=   (arln == 0 ? "  بحث  " : "  Search") ; Button_Delete.Text=   (arln == 0 ? "  حذف  " : "  delete") ; Button_Save.Text=   (arln == 0 ? "  حفظ  " : "  save") ; Button_Add.Text=   (arln == 0 ? "  إضافة  " : "  addition") ; superTabControl_Main2.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; Button_First.Text=   (arln == 0 ? "  الأول  " : "  the first") ; Button_Prev.Text=   (arln == 0 ? "  السابق  " : "  the previous") ; lable_Records.Text=   (arln == 0 ? "  ---  " : "  ---") ; Button_Next.Text=   (arln == 0 ? "  التالي  " : "  next one") ; Button_Last.Text=   (arln == 0 ? "  الأخير  " : "  the last one") ; ToolStripMenuItem_Rep.Text=   (arln == 0 ? "  إظهار التقرير  " : "  Show report") ; ToolStripMenuItem_Det.Text=   (arln == 0 ? "  إظهار التفاصيل  " : "  Show details") ; panelEx3.Text=   (arln == 0 ? "  Fill Panel  " : "  Fill Panel") ; DGV_Main.Text=   (arln == 0 ? "    " : "    ") ; DGV_Main.Text=   (arln == 0 ? "  جميــع السجــــلات  " : "  All records") ; DGV_Main.Text=   (arln == 0 ? "    " : "    ") ; superTabControl_DGV.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; textBox_search.Text=   (arln == 0 ? "  ...  " : "  ...") ; Button_ExportTable2.Text=   (arln == 0 ? "  تصدير  " : "  Export") ; /*Button_PrintTable.Text=   (arln == 0 ? "  طباعة  " : "  Print") ; */panelEx2.Text=   (arln == 0 ? "  Click to collapse  " : "  Click to collapse") ; Text = "العملاء";this.Text=   (arln == 0 ? "  العملاء  " : "  customers") ;}
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
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData.ToString().Contains("Control") && !keyData.ToString().ToLower().Contains("delete") && keyData.ToString().Contains("Alt"))
            {
                try
                {
                    VarGeneral.Print_set_Gen_Stat = true;
                    FrmReportsViewer.IsSettingOnly = true;
                    VarGeneral.IsGeneralUsed = true;
                    {
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "RepGeneral";
                        frm.Repvalue = "RepGeneral";
                        //ADDADD
                        frm.Tag = LangArEn;
                        frm.ShowDialog();
                        VarGeneral.IsGeneralUsed = false;
                    }
                    FrmReportsViewer.IsSettingOnly = false;
                }
                catch
                {
                    VarGeneral.Print_set_Gen_Stat = false;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void netResize1_AfterControlResize(object sender, Softgroup.NetResize.AfterControlResizeEventArgs e)
        {
            if (e.Control.Name.Contains("ribbonBar_Tasks"))
            {
                ribbonBar_Tasks.Font = new Font("Tahoma", 8F);
                ribbonBar1.BackgroundStyle.BackColor = Color.Gainsboro;
                ribbonBar1.BackgroundStyle.BackColor2 = Color.Gainsboro;
            }
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
        private Panel PanelSpecialContainer;
        private void superTabControl_Main1_RightToLeftChanged(object sender, EventArgs e)
        {
            superTabControl_Main1.RightToLeftChanged -= superTabControl_Main1_RightToLeftChanged;
            superTabControl_Main1.RightToLeft = RightToLeft.No;
            superTabControl_Main1.RightToLeftChanged -= superTabControl_Main1_RightToLeftChanged;
        }
        private void FrmInvSale_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                superTabControl_Main2.Width = 500;
            }
            else
            {
                superTabControl_Main2.Width = 443;
            }
            netResize1.Refresh();
        }
        private Softgroup.NetResize.NetResize netResize1;
        protected ToolStripMenuItem ToolStripMenuItem_Rep;
        private RibbonBar ribbonBar1;
        private DockSite barTopDockSite;
        private DockSite barBottomDockSite;
        private DockSite barLeftDockSite;
        private DockSite barRightDockSite;
        private DockSite dockSite1;
        private DockSite dockSite2;
        private ImageList imageList1;
        private DockSite dockSite4;
        private DockSite dockSite3;
        protected ContextMenuStrip contextMenuStrip1;
        protected ContextMenuStrip contextMenuStrip2;
        protected ToolStripMenuItem ToolStripMenuItem_Det;
        private System.Windows.Forms.OpenFileDialog  openFileDialog1;
        private Timer timerInfoBallon;
        private System.Windows.Forms. SaveFileDialog saveFileDialog1;
        private PanelEx panelEx3;
        private Timer timer1;
        private PanelEx panelEx2;
        private ExpandableSplitter expandableSplitter1;
        private Panel panel1;
        private Label label5;
        private CheckBoxX checkBoxX_Stoped;
        private ButtonX buttonX_CustomerStoped;
        private RibbonBar ribbonBar_Tasks;
        private SuperTabControl superTabControl_Main1;
        private SuperTabControl superTabControl_Main2;
        protected SuperGridControl DGV_Main;
        private RibbonBar ribbonBar_DGV;
        private SuperTabControl superTabControl_DGV;
        private TextBox txtZipCod;
        private Label label20;
        private Label label6;
        private TextBox txtEMail;
        private Label label7;
        private TextBox txtCity;
        private Label label8;
        private TextBox txtFax;
        private Label label12;
        private TextBox txtMobile;
        private Label label13;
        private TextBox txtTele1;
        private Label label9;
        private TextBox txtTele2;
        private Label label11;
        private Label label18;
        private ComboBox CmbPrice;
        private IntegerInput txtAgeLimit;
        private Label label10;
        private Label label16;
        private DoubleInput txtBalance;
        private Label label15;
        private DoubleInput txtCredit;
        private Label label14;
        private DoubleInput txtDeb;
        private Label label17;
        private TextBox txtPersonalName;
        private Label label19;
        private ButtonX buttonX_SerchAccNo;
        private Label label3;
        private TextBox textBox_ID;
        private Label label4;
        private TextBox txtEngDes;
        private Label label2;
        private TextBox txtArbDes;
        private Label label1;
        private TextBox txtMainAccNo;
        private DoubleInput txtCreditLimit;
        private TextBox txtAddress;
        private TextBox txtRessonsStoped;
        private LabelItem lable_Records;
        private Label label21;
        private ComboBox CmbLegate;
        private ComboBox CmbInvTyp;
        private ButtonX button_Barcode;
        private PrintDialog printDialog1;
        internal PrintDocument prnt_doc;
        internal PrintPreviewDialog prnt_prev;
        private C1BarCode c1BarCode1;
        private ButtonX button_SrchPlaceNo;
        private TextBox txtPlaceName;
        private TextBox txtTaxNo;
        private Label label22;
        private Line line1;
        private DoubleInput txtMaxDis;
        private Label label23;
        private Label label24;
        private SwitchButton switchButton_DisTyp;
        private TextBox txtAge;
        private Label label25;
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private T_AccDef _AccDefBind = new T_AccDef();
        private int LangArEn = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
#pragma warning disable CS0414 // The field 'FrmCustomer.FlagUpdate' is assigned but its value is never used
        private string FlagUpdate = "";
#pragma warning restore CS0414 // The field 'FrmCustomer.FlagUpdate' is assigned but its value is never used
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private T_Company _Company = new T_Company();
        private bool canUpdate = true;
        private T_AccDef data_this;
        private Stock_DataDataContext dbInstance;
        private List<string> pkeys = new List<string>();
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
        private string IdProof = "";
        private int CountPage = 0;
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
        public bool IfAdd
        {
            set
            {
                Button_Add.Visible = value;
            }
        }
        public bool IfDelete
        {
            set
            {
                Button_Delete.Visible = value;
                superTabControl_Main1.Refresh();
            }
        }
        public bool IfSave
        {
            set
            {
                Button_Save.Visible = value;
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
        public T_AccDef DataThis
        {
            get
            {
                return data_this;
            }
            set
            {
                data_this = value;
                SetData(data_this);
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
        public bool SetReadOnly
        {
            set
            {
                if (value)
                {
                    State = FormState.Saved;
                }
                Button_Save.Enabled = !value;
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
        public T_User Permmission
        {
            get
            {
                return permission;
            }
            set
            {
                if (value != null && value.UsrNo != "")
                {
                    permission = value;
                    if (!VarGeneral.TString.ChkStatShow(value.FilStr, 33))
                    {
                        IfAdd = false;
                    }
                    else
                    {
                        IfAdd = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.FilStr, 34))
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.FilStr, 35))
                    {
                        IfDelete = false;
                    }
                    else
                    {
                        IfDelete = true;
                    }
                }
            }
        }
        private void ksdjfa(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;
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
            if (e.KeyCode == Keys.F1 && Button_Add.Enabled && Button_Add.Visible)
            {
                Button_Add_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F2 && Button_Save.Enabled && Button_Save.Visible && State != 0)
            {
                Button_Save_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F3 && Button_Delete.Enabled && Button_Delete.Visible && State == FormState.Saved)
            {
                Button_Delete_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F4 && Button_Search.Enabled && Button_Search.Visible)
            {
                Button_Search_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F5 && Button_PrintTable.Enabled && Button_PrintTable.Visible && !expandableSplitter1.Expanded)
            {
                Button_Print_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F10 && Button_ExportTable2.Enabled && Button_ExportTable2.Visible && !expandableSplitter1.Expanded)
            {
                Button_ExportTable2_Click(sender, e);
            }
            else
            {
                if (e.KeyCode != Keys.Escape)
                {
                    return;
                }
                if (State == FormState.Saved)
                {
                    Close();
                    return;
                }
                if (State != FormState.New)
                {
                    textBox_ID_TextChanged(sender, e);
                    return;
                }
                try
                {
                    if (int.Parse(Label_Count.Text) > 0)
                    {
                        Button_Last_Click(sender, e);
                    }
                    else
                    {
                        Close();
                    }
                }
                catch
                {
                    Close();
                }
            }
        }
        public void RefreshPKeys()
        {
            PKeys.Clear();
            var qkeys = from item in db.T_AccDefs
                        where item.Lev == (int?)4 && item.AccCat == (int?)4
                        orderby item.AccDef_No
                        select new
                        {
                            Code = item.AccDef_No + ""
                        };
            int count = 0;
            foreach (var item2 in qkeys)
            {
                count++;
                PKeys.Add(item2.Code);
            }
            Label_Count.Text = string.Concat(count);
            UpdateVcr();
        }
        private void LockedFrm(bool Stat)
        {
            if (State == FormState.New)
            {
                textBox_ID.ReadOnly = true;
                txtMainAccNo.ReadOnly = true;
                buttonX_SerchAccNo.Enabled = true;
            }
            else
            {
                textBox_ID.ReadOnly = true;
                txtMainAccNo.ReadOnly = true;
                buttonX_SerchAccNo.Enabled = false;
            }
        }
        protected bool ContinueIfEditOrNew()
        {
            if (State == FormState.Edit || State == FormState.New)
            {
                if (MessageBox.Show((LangArEn == 0) ? "تم تعديل السجل الحالي دون حفظ التغييرات .. هل تريد المتابعة؟" : "Not saved the changes, do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    return false;
                }
                return true;
            }
            return true;
        }
        public FrmCustomer()
        {
            InitializeComponent();this.Load += langloads;
            txtAddress.Click += Button_Edit_Click;
            txtAgeLimit.Click += Button_Edit_Click;
            txtArbDes.Click += Button_Edit_Click;
            txtMaxDis.Click += Button_Edit_Click;
            switchButton_DisTyp.Click += Button_Edit_Click;
            txtPersonalName.Click += Button_Edit_Click;
            txtZipCod.Click += Button_Edit_Click;
            txtRessonsStoped.Click += Button_Edit_Click;
            checkBoxX_Stoped.Click += Button_Edit_Click;
            txtTaxNo.Click += Button_Edit_Click;
            txtBalance.Click += Button_Edit_Click;
            txtCity.Click += Button_Edit_Click;
            txtCredit.Click += Button_Edit_Click;
            txtCreditLimit.Click += Button_Edit_Click;
            txtEngDes.Click += Button_Edit_Click;
            txtDeb.Click += Button_Edit_Click;
            txtEMail.Click += Button_Edit_Click;
            txtFax.Click += Button_Edit_Click;
            txtMobile.Click += Button_Edit_Click;
            txtTele1.Click += Button_Edit_Click;
            txtTele2.Click += Button_Edit_Click;
            txtAge.Click += Button_Edit_Click;
            buttonX_SerchAccNo.TextChanged += Button_Edit_Click;
            CmbPrice.Click += Button_Edit_Click;
            CmbLegate.Click += Button_Edit_Click;
            CmbInvTyp.Click += Button_Edit_Click;
            DGV_Main.PrimaryGrid.CheckBoxes = false;
            DGV_Main.PrimaryGrid.ShowCheckBox = false;
            DGV_Main.PrimaryGrid.ShowTreeButton = false;
            DGV_Main.PrimaryGrid.ShowTreeButtons = false;
            DGV_Main.PrimaryGrid.ShowTreeLines = false;
            DGV_Main.PrimaryGrid.RowHeaderWidth = 25;
            DGV_Main.PrimaryGrid.VirtualMode = true;
            DGV_Main.MouseDown += DGV_Main_MouseDown;
            expandableSplitter1.Click += expandableSplitter1_Click;
            DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
            DGV_Main.CellClick += DGV_Main_CellClick;
            ToolStripMenuItem_Det.Click += ToolStripMenuItem_Det_Click;
            Button_ExportTable2.Click += Button_ExportTable2_Click;
            DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
            textBox_search.InputTextChanged += TextBox_Search_InputTextChanged;
            textBox_search.ButtonCustomClick += TextBox_Search_ButtonCustomClick;
            TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
            DGV_Main.DataBindingComplete += DGV_Main_DataBindingComplete;
            Button_Close.Click += Button_Close_Click;
            Button_First.Click += Button_First_Click;
            Button_Prev.Click += Button_Prev_Click;
            Button_Next.Click += Button_Next_Click;
            Button_Last.Click += Button_Last_Click;
            Button_Add.Click += Button_Add_Click;
            Button_Search.Click += Button_Search_Click;
            Button_Delete.Click += Button_Delete_Click;
            Button_Save.Click += Button_Save_Click;
            TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
            buttonX_SerchAccNo.TextChanged += buttonX_SerchAccNo_Click;
            Button_PrintTable.Click += Button_Print_Click;
            GetInvSetting();
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
            {
                txtCreditLimit.DisplayFormat = VarGeneral.DicemalMask;
                txtDeb.DisplayFormat = VarGeneral.DicemalMask;
                txtCredit.DisplayFormat = VarGeneral.DicemalMask;
                txtBalance.DisplayFormat = VarGeneral.DicemalMask;
            }
        }
        private void expandableSplitter1_Click(object sender, EventArgs e)
        {
            if (expandableSplitter1.Expanded)
            {
                ViewTable_Click(sender, e);
            }
            else
            {
                ViewDetails_Click(sender, e);
            }
        }
        public void Button_Search_Click(object sender, EventArgs e)
        {
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_AccDef_Suppliers";
            VarGeneral.AccTyp = 4;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                textBox_ID.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
            }
        }
        public void Button_First_Click(object sender, EventArgs e)
        {
            if (ContinueIfEditOrNew())
            {
                TextBox_Index.TextBox.Text = string.Concat(1);
                UpdateVcr();
                textBox_ID.Focus();
            }
        }
        public void Button_Prev_Click(object sender, EventArgs e)
        {
            if (ContinueIfEditOrNew())
            {
                int index = 0;
                try
                {
                    index = Convert.ToInt32(TextBox_Index.TextBox.Text);
                }
                catch
                {
                }
                if (index > 1)
                {
                    TextBox_Index.TextBox.Text = string.Concat(index - 1);
                }
                UpdateVcr();
                textBox_ID.Focus();
            }
        }
        public void Button_Next_Click(object sender, EventArgs e)
        {
            if (ContinueIfEditOrNew())
            {
                int index = 0;
                int count = 0;
                try
                {
                    index = Convert.ToInt32(TextBox_Index.TextBox.Text);
                }
                catch
                {
                }
                try
                {
                    count = Convert.ToInt32(Label_Count.Text);
                }
                catch
                {
                }
                if (index < count)
                {
                    TextBox_Index.TextBox.Text = string.Concat(index + 1);
                }
                UpdateVcr();
                textBox_ID.Focus();
            }
        }
        public void Button_Last_Click(object sender, EventArgs e)
        {
            if (ContinueIfEditOrNew())
            {
                TextBox_Index.TextBox.Text = Label_Count.Text;
                UpdateVcr();
            }
        }
        private void UpdateVcr()
        {
            int vCount = 0;
            int vPosition = 0;
            try
            {
                vCount = int.Parse(Label_Count.Text);
            }
            catch
            {
                vCount = 0;
            }
            try
            {
                vPosition = int.Parse(TextBox_Index.Text);
            }
            catch
            {
                vPosition = 0;
            }
            if (vCount <= 1)
            {
                Button_First.Enabled = false;
                Button_Prev.Enabled = false;
                Button_Next.Enabled = false;
                Button_Last.Enabled = false;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    lable_Records.Text = ((vCount == 0) ? "لايوجد سجلات" : "سجل واحد فقط");
                }
                else
                {
                    lable_Records.Text = ((vCount == 0) ? "No records" : "Only Record");
                }
                return;
            }
            if (vPosition == 1)
            {
                ButtonItem button_First = Button_First;
                bool enabled = (Button_Prev.Enabled = false);
                button_First.Enabled = enabled;
                ButtonItem button_Last = Button_Last;
                enabled = (Button_Next.Enabled = vCount > 1);
                button_Last.Enabled = enabled;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    lable_Records.Text = "الأول من " + vCount + " سجلات";
                }
                else
                {
                    lable_Records.Text = "First of " + vCount + " records";
                }
                return;
            }
            if (vPosition == vCount)
            {
                Button_Last.Enabled = false;
                Button_Next.Enabled = false;
                ButtonItem button_First2 = Button_First;
                bool enabled = (Button_Prev.Enabled = vCount > 1);
                button_First2.Enabled = enabled;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    lable_Records.Text = "الأخير من " + vCount + " سجلات";
                }
                else
                {
                    lable_Records.Text = "Last of " + vCount + " records";
                }
                return;
            }
            Button_First.Enabled = true;
            Button_Prev.Enabled = true;
            Button_Next.Enabled = true;
            Button_Last.Enabled = true;
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                lable_Records.Text = "السجل " + vPosition + " من " + vCount;
            }
            else
            {
                lable_Records.Text = "Record " + vPosition + " of " + vCount;
            }
        }
        private void TextBox_Search_InputTextChanged(object sender)
        {
            Fill_DGV_Main();
        }
        private void TextBox_Search_ButtonCustomClick(object sender, EventArgs e)
        {
            textBox_search.Text = "";
        }
        private void ToolStripMenuItem_Det_Click(object sender, EventArgs e)
        {
            int rowIndex = Convert.ToInt32(DGV_Main.PrimaryGrid.Tag);
            TextBox_Index.TextBox.Text = string.Concat(rowIndex + 1);
            expandableSplitter1.Expanded = true;
            ViewDetails_Click(sender, e);
        }
        public void ViewDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(Label_Count.Text ?? "") <= 0 || (Label_Count.Text ?? "") == "")
                {
                    expandableSplitter1.Expandable = false;
                    return;
                }
                expandableSplitter1.Expandable = true;
                DGV_Main.PrimaryGrid.DataSource = null;
                DGV_Main.PrimaryGrid.VirtualMode = false;
                ViewState = ViewState.Deiles;
            }
            catch
            {
            }
        }
        public void ViewTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(Label_Count.Text ?? "") <= 0 || (Label_Count.Text ?? "") == "")
                {
                    expandableSplitter1.Expandable = false;
                    return;
                }
                expandableSplitter1.Expandable = true;
                ViewState = ViewState.Table;
            }
            catch
            {
            }
            Fill_DGV_Main();
            int index = -1;
            try
            {
                index = Convert.ToInt32(TextBox_Index.TextBox.Text);
            }
            catch
            {
                index = -1;
            }
            index--;
            if (index < DGV_Main.PrimaryGrid.Rows.Count && index >= 0)
            {
                DGV_Main.PrimaryGrid.Rows[index].EnsureVisible();
            }
        }
        private void DGV_Main_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                GridElement item = DGV_Main.GetElementAt(e.Location);
                if (item is GridColumnHeader)
                {
                    GridColumnHeader gch = (GridColumnHeader)item;
                    GridColumn column = null;
                    HeaderArea area = gch.GetHitArea(e.Location, ref column);
                    contextMenuStrip1.Show(Control.MousePosition);
                }
                else
                {
                    contextMenuStrip2.Show(Control.MousePosition);
                }
            }
        }
        public void Fill_DGV_Main()
        {
            DGV_Main.PrimaryGrid.VirtualMode = false;
            List<T_AccDef> list = db.FillAccDef_2(textBox_search.TextBox.Text, 4, 4).ToList();
            if (list.Count() > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].Debit = list[i].T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.gdValue > 0.0).Sum((T_GDDET g) => g.gdValue.Value);
                    list[i].Credit = Math.Abs(list[i].T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.gdValue < 0.0).Sum((T_GDDET g) => g.gdValue.Value));
                    list[i].Balance = list[i].T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok).Sum((T_GDDET g) => g.gdValue.Value);
                }
            }
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                }
            }
            FillHDGV(list);
        }
        public void FillHDGV(IEnumerable<T_AccDef> new_data_enum)
        {
            bool contextMenuSet = false;
            if (contextMenuStrip1.Items.Count > 0)
            {
                contextMenuSet = true;
            }
            for (int i = 0; i < DGV_Main.PrimaryGrid.Columns.Count; i++)
            {
                if (columns_Names_visible.ContainsKey(DGV_Main.PrimaryGrid.Columns[i].Name))
                {
                    DGV_Main.PrimaryGrid.Columns[i].AutoSizeMode = ColumnAutoSizeMode.None;
                    DGV_Main.PrimaryGrid.Columns[i].MinimumWidth = 50;
                    DGV_Main.PrimaryGrid.Columns[i].Visible = columns_Names_visible[DGV_Main.PrimaryGrid.Columns[i].Name].IfDefault;
                    DGV_Main.PrimaryGrid.Columns[i].HeaderText = ((LangArEn == 0) ? columns_Names_visible[DGV_Main.PrimaryGrid.Columns[i].Name].AText : columns_Names_visible[DGV_Main.PrimaryGrid.Columns[i].Name].EText);
                    if (!contextMenuSet)
                    {
                        ToolStripMenuItem item = new ToolStripMenuItem();
                        item.Checked = columns_Names_visible[DGV_Main.PrimaryGrid.Columns[i].Name].IfDefault;
                        item.CheckOnClick = true;
                        item.Name = DGV_Main.PrimaryGrid.Columns[i].Name;
                        item.Text = DGV_Main.PrimaryGrid.Columns[i].HeaderText;
                        item.CheckedChanged += item_Click;
                        contextMenuStrip1.Items.Add(item);
                    }
                    else
                    {
                        DGV_Main.PrimaryGrid.Columns[i].Visible = (contextMenuStrip1.Items[DGV_Main.PrimaryGrid.Columns[i].Name] as ToolStripMenuItem).Checked;
                    }
                }
                else
                {
                    DGV_Main.PrimaryGrid.Columns[i].Visible = false;
                }
            }
            DGV_Main.PrimaryGrid.DataSource = new_data_enum.ToList();
            DGV_Main.PrimaryGrid.DataMember = "T_AccDef";
            DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background.Color2 = Color.LightBlue;
        }
        private void item_Click(object sender, EventArgs e)
        {
            string name = (sender as ToolStripMenuItem).Name;
            try
            {
                string NameExsist = DGV_Main.PrimaryGrid.Columns[name].Name;
            }
            catch
            {
                DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(name));
                DGV_Main.PrimaryGrid.Columns[name].AutoSizeMode = ColumnAutoSizeMode.None;
                DGV_Main.PrimaryGrid.Columns[name].MinimumWidth = 90;
                DGV_Main.PrimaryGrid.Columns[name].HeaderText = columns_Names_visible[name].AText;
            }
            DGV_Main.PrimaryGrid.Columns[name].Visible = (sender as ToolStripMenuItem).Checked;
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {   ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmCustomer));
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
            try
            {
                if (data_this != null)
                {
                    SetData(data_this);
                }
            }
            catch
            {
            }
        }
        private void RibunButtons()
        {
            label1.Text = (LangArEn == 0 ? "الإسم العربي :" : "Arabic Name:");
            label10.Text = (LangArEn == 0 ? "عمر الدين :" : "indebtedness Dates:");
            label11.Text = (LangArEn == 0 ? "ص . ب :" : " P.oF");
            label12.Text = (LangArEn == 0 ? "الفاكس :" : "Fax:");
            label13.Text = (LangArEn == 0 ? "الجوال :" : "Mobile");
            label14.Text = (LangArEn == 0 ? "دائن :" : "creditor:");
            label15.Text = (LangArEn == 0 ? "الرصيد الحالي :" : "Current Balance:");
            label16.Text = (LangArEn == 0 ? "حد المديونية :" : "Debit:");
            label17.Text = (LangArEn == 0 ? "مدين :" : "Debit:");
            label18.Text = (LangArEn == 0 ? "السعر الإفتراضي :" : "Default price:");
            label19.Text = (LangArEn == 0 ? "إسم المسؤول :" : "Admin Name:");
            label2.Text = (LangArEn == 0 ? "الإسم الإنجليزي :" : "English name:");
            label20.Text = (LangArEn == 0 ? "الرمز البريدي :" : "Zip Code:");
            label21.Text = (LangArEn == 0 ? "المنــــــــــــــدوب :" : "Delegate:");
            label22.Text = (LangArEn == 0 ? "الــرقم الضريبـــي :" : "Tax No");
            label23.Text = (LangArEn == 0 ? "نسبة الخصم :" : "Discount Percentage:");
            label24.Text = (LangArEn == 0 ? "%" : "%");
            label25.Text = (LangArEn == 0 ? "العمـــر :" : "Age :");
            label3.Text = (LangArEn == 0 ? "حساب الأب :" : "Father Acc:");
            label4.Text = (LangArEn == 0 ? "رقم العميل :" : "Custumer No:");
            label5.Text = (LangArEn == 0 ? "سبب الحظـــر :" : "Reasone Of Block:");
            label6.Text = (LangArEn == 0 ? "العنوان :" : "Address :");
            label7.Text = (LangArEn == 0 ? "الإيميل :" : "Email:");
            label8.Text = (LangArEn == 0 ? "البلد :" : "Counter:");
            label9.Text = (LangArEn == 0 ? "الهاتف :" : "Telphone");
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                Button_First.Text = "الأول";
                Button_Last.Text = "الأخير";
                Button_Next.Text = "التالي";
                Button_Prev.Text = "السابق";
                Button_Add.Text = "جديد";
                Button_Close.Text = "اغلاق";
                Button_Delete.Text = "حذف";
                Button_Save.Text = "حفظ";
                Button_Search.Text = "بحث";
                Button_First.Tooltip = "السجل الاول";
                Button_Last.Tooltip = "السجل الاخير";
                Button_Next.Tooltip = "السجل التالي";
                Button_Prev.Tooltip = "السجل السابق";
                Button_Add.Tooltip = "F1";
                Button_Close.Tooltip = "Esc";
                Button_Delete.Tooltip = "F3";
                Button_Save.Tooltip = "F2";
                Button_Search.Tooltip = "F4";
                Button_PrintTable.Text = ((VarGeneral.GeneralPrinter.ISdirectPrinting) ? "طباعة" : "عــرض");
                Button_PrintTable.Tooltip = "F5";
                Button_ExportTable2.Text = "تصدير";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "جميع السجلات";
                label4.Text = "رقم العميل :";
                label3.Text = "حساب الأب :";
                label1.Text = "الإسم - عربي :";
                label2.Text = "الإسم - إنجليزي :";
                label19.Text = "إسم المسؤول :";
                label16.Text = "حد المديونية :";
                label10.Text = "عمر الدين :";
                label18.Text = "السعر الإفتراضي :";
                label17.Text = "مدين :";
                label14.Text = "دائن :";
                label15.Text = "الرصيد الحالي :";
                label6.Text = "العنوان :";
                label8.Text = "البلد :";
                label9.Text = "الهاتف :";
                label12.Text = "الفاكس :";
                label13.Text = "الجوال :";
                label11.Text = "ص . ب :";
                label20.Text = "الرمز البريدي :";
                label7.Text = "الإيميل :";
                label25.Text = "العمـــر :";
                Text = "كرت العمــــلاء";
                checkBoxX_Stoped.Text = "حظر العميل";
                buttonX_CustomerStoped.Text = "العملاء الموقوفين";
                label5.Text = "سبب الحظر :";
                switchButton_DisTyp.OffText = "خصم سطور";
                switchButton_DisTyp.OnText = "خصم إجمالي";
            }
            else
            {
                Button_First.Text = "First";
                Button_Last.Text = "Last";
                Button_Next.Text = "Next";
                Button_Prev.Text = "Previous";
                Button_Add.Text = "New";
                Button_Close.Text = "Close";
                Button_Delete.Text = "Delete";
                Button_Save.Text = "Save";
                Button_Search.Text = "Search";
                Button_First.Tooltip = "First Record";
                Button_Last.Tooltip = "Last Record";
                Button_Next.Tooltip = "Next Record";
                Button_Prev.Tooltip = "Previous Record";
                Button_Add.Tooltip = "F1";
                Button_Close.Tooltip = "Esc";
                Button_Delete.Tooltip = "F3";
                Button_Save.Tooltip = "F2";
                Button_Search.Tooltip = "F4";
                Button_PrintTable.Text = ((VarGeneral.GeneralPrinter.ISdirectPrinting) ? "Print" : "Show");
                Button_PrintTable.Tooltip = "F5";
                Button_ExportTable2.Text = "Export";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "All Records";
                label4.Text = "Customer No :";
                label3.Text = "Account No :";
                label1.Text = "Name - Arabic :";
                label2.Text = "Name - English :";
                label19.Text = "The official name :";
                label16.Text = "Debt limit :";
                label10.Text = "Life of the loan :";
                label18.Text = "Price Default :";
                label17.Text = "Debtor :";
                label14.Text = "Creditor :";
                label15.Text = "Balance :";
                label6.Text = "Address :";
                label8.Text = "Country :";
                label9.Text = "Tel :";
                label12.Text = "Fax :";
                label13.Text = "Mobile :";
                label11.Text = "PO Box :";
                label20.Text = "Postal Code :";
                label7.Text = "Email :";
                label25.Text = "Age :";
                Text = "Customers Card";
                checkBoxX_Stoped.Text = "Customer ban";
                buttonX_CustomerStoped.Text = "Customers arrested";
                label5.Text = "The reason for the ban :";
                switchButton_DisTyp.OffText = "Discount lines";
                switchButton_DisTyp.OnText = "Discount Total";
            }
        }
        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmCustomer));
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
                if (VarGeneral.SSSTyp == 1)
                {
                    CmbInvTyp.Visible = false;
                    label18.Visible = false;
                    CmbPrice.Visible = false;
                }
                ADD_Controls();
                LockedFrm(Stat: true);
                Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
                if (columns_Names_visible.Count == 0)
                {
                    columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
                    columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
                    columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
                    columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
                    columns_Names_visible.Add("Adders", new ColumnDictinary("العنوان", "Address", ifDefault: true, ""));
                    columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, ""));
                }
                else
                {
                    Clear();
                    textBox_ID.Text = "";
                    TextBox_Index.TextBox.Text = "";
                }
                RefreshPKeys();
                FillCombo();
                RibunButtons();
                textBox_ID.Text = PKeys.FirstOrDefault();
                ViewDetails_Click(sender, e);
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptCustBarcode.dll"))
                {
                    button_Barcode.Visible = true;
                }
                else
                {
                    button_Barcode.Visible = false;
                }
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptInvitationCards.dll"))
                {
                    Script_InvitationCards();
                }
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptSchool.dll"))
                {
                    Script_School();
                }
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptMaintenanceCars.dll"))
                {
                    MaintenanceCars();
                }
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptBus.dll"))
                {
                    label21.Text = ((LangArEn == 0) ? "الســـائق :" : "Driver :");
                }
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptTegnicalCollage.dll"))
                {
                    TegnicalCollage();
                }
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptWaterPackages.dll"))
                {
                    WaterPackages();
                }
                if (File.Exists(Application.StartupPath + "\\Script\\Secriptjustlight.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", "").Trim() + "\\Secriptjustlight.dll")))
                {
                    justlight();
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void WaterPackages()
        {
            Text = ((LangArEn == 0) ? "كرت السائقــين" : "Drivers Card");
            label4.Text = ((LangArEn == 0) ? "رقم السائق :" : "Driver No :");
            label19.Text = ((LangArEn == 0) ? "رقــم الإقـامــة :" : "ID No :");
            label12.Visible = false;
            txtFax.Visible = false;
            label11.Text = ((LangArEn == 0) ? "المساعد :" : "Partner :");
            txtTele2.Width = txtPersonalName.Width;
            txtTele2.Location = new Point(txtPersonalName.Location.X, txtTele2.Location.Y);
            label20.Visible = false;
            txtZipCod.Visible = false;
            label7.Text = ((LangArEn == 0) ? "رقم إقامتة :" : "Partner ID :");
            txtPersonalName.KeyPress += txtTele1_KeyPress;
            txtEMail.KeyPress += txtTele1_KeyPress;
            txtEMail.TextAlign = HorizontalAlignment.Center;
            txtPersonalName.TextAlign = HorizontalAlignment.Center;
            label22.Visible = false;
            txtTaxNo.Visible = false;
            label21.Visible = false;
            CmbLegate.Visible = false;
            label18.Visible = false;
            CmbPrice.Visible = false;
            label17.Visible = false;
            txtDeb.Visible = false;
            label14.Visible = false;
            txtCredit.Visible = false;
            label15.Visible = false;
            txtBalance.Visible = false;
            checkBoxX_Stoped.Visible = false;
            label5.Visible = false;
            txtRessonsStoped.Visible = false;
            buttonX_CustomerStoped.Visible = false;
            CmbInvTyp.Visible = false;
            txtCreditLimit.Visible = false;
            label16.Visible = false;
            line1.Visible = true;
            line1.Thickness = 2;
            line1.Location = new Point(-90, 122);
        }
        private void TegnicalCollage()
        {
            Text = ((LangArEn == 0) ? "الطـــلاب" : "Students");
            label4.Text = ((LangArEn == 0) ? "رقم الطالب :" : "Student No :");
            label22.Visible = false;
            txtTaxNo.Visible = false;
            label21.Visible = false;
            CmbLegate.Visible = false;
            label18.Visible = false;
            CmbPrice.Visible = false;
            label17.Visible = false;
            txtDeb.Visible = false;
            label14.Visible = false;
            txtCredit.Visible = false;
            label15.Visible = false;
            txtBalance.Visible = false;
            checkBoxX_Stoped.Visible = false;
            label5.Visible = false;
            txtRessonsStoped.Visible = false;
            buttonX_CustomerStoped.Visible = false;
            CmbInvTyp.Visible = false;
            txtCreditLimit.Visible = false;
            label16.Visible = false;
            line1.Visible = true;
            line1.Thickness = 2;
            line1.Location = new Point(-90, 122);
        }
        private void Script_InvitationCards()
        {
            button_SrchPlaceNo.Visible = true;
            txtRessonsStoped.Multiline = false;
            txtRessonsStoped.ReadOnly = true;
            txtRessonsStoped.TextAlign = HorizontalAlignment.Center;
            txtPlaceName.Visible = true;
            label5.Text = ((LangArEn == 0) ? "حساب المكان :" : "Place Acc :");
        }
        private void Script_School()
        {
            button_SrchPlaceNo.Visible = true;
            txtRessonsStoped.Multiline = false;
            txtRessonsStoped.ReadOnly = true;
            txtRessonsStoped.TextAlign = HorizontalAlignment.Center;
            txtPlaceName.Visible = true;
            Text = ((LangArEn == 0) ? "الطـــلاب" : "Students");
            label19.Text = ((LangArEn == 0) ? "ولي الأمر :" : "Guardian :");
            label4.Text = ((LangArEn == 0) ? "رقم الطالب :" : "Student No :");
            label22.Visible = false;
            txtTaxNo.Visible = false;
            CmbInvTyp.Visible = false;
        }
        private void justlight()
        {
            label8.Text = ((LangArEn == 0) ? "الجنسيـــة :" : "Nationality :");
            label7.Text = ((LangArEn == 0) ? "رقم الهوية :" : "ID No :");
            label19.Text = ((LangArEn == 0) ? "رقم الهوية_سند :" : "ID No :");
            label22.Text = ((LangArEn == 0) ? "المصــــــدر :" : "Source :");
        }
        private void MaintenanceCars()
        {
            button_SrchPlaceNo.Visible = true;
            txtRessonsStoped.Multiline = false;
            txtRessonsStoped.ReadOnly = true;
            txtRessonsStoped.TextAlign = HorizontalAlignment.Center;
            txtPlaceName.Visible = true;
            Text = ((LangArEn == 0) ? "السيــارات" : "Cars");
            label6.Text = ((LangArEn == 0) ? "رقم الشاص :" : "Chase No :");
            label4.Text = ((LangArEn == 0) ? "رقم السيارة :" : "Car No :");
            label21.Text = ((LangArEn == 0) ? "نوع السيارة :" : "Car Type :");
            label19.Text = ((LangArEn == 0) ? "لون السيارة :" : "Car Color :");
            label8.Text = ((LangArEn == 0) ? "رقم اللوحة :" : "Plate Number :");
            label9.Text = ((LangArEn == 0) ? "سنة الصنع :" : "Year :");
            label12.Visible = false;
            txtFax.Visible = false;
            label13.Visible = false;
            txtMobile.Visible = false;
            label11.Visible = false;
            txtTele2.Visible = false;
            label20.Visible = false;
            txtZipCod.Visible = false;
            label7.Visible = false;
            txtEMail.Visible = false;
            label22.Visible = false;
            txtTaxNo.Visible = false;
            CmbInvTyp.Visible = false;
            CmbPrice.Visible = false;
            label18.Visible = false;
            label16.Visible = false;
            txtCreditLimit.Visible = false;
            checkBoxX_Stoped.Visible = false;
            label5.Visible = false;
            txtRessonsStoped.Visible = false;
            button_SrchPlaceNo.Visible = false;
            buttonX_CustomerStoped.Visible = false;
            txtPlaceName.Visible = false;
            txtEngDes.Width = txtArbDes.Width;
            txtEngDes.Location = new Point(txtArbDes.Location.X, txtEngDes.Location.Y);
            line1.Visible = true;
            line1.Location = new Point(-90, 116);
        }
        private void FillCombo()
        {
            int _CmbIndex = CmbPrice.SelectedIndex;
            CmbPrice.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                CmbPrice.Items.Add("الافتراضي");
                CmbPrice.Items.Add("سعر الجملة");
                CmbPrice.Items.Add("سعر الموزع");
                CmbPrice.Items.Add("سعر المندوب");
                CmbPrice.Items.Add("سعر التجزئة");
                CmbPrice.Items.Add("سعر آخر");
            }
            else
            {
                CmbPrice.Items.Add("Defualt");
                CmbPrice.Items.Add("Wholesale price");
                CmbPrice.Items.Add("Distributor price");
                CmbPrice.Items.Add("Legates Price");
                CmbPrice.Items.Add("Retail price");
                CmbPrice.Items.Add("another Price");
            }
            CmbPrice.SelectedIndex = _CmbIndex;
            CmbInvTyp.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                CmbInvTyp.Items.Add("خيـــارات البيـــع");
                CmbInvTyp.Items.Add("إيقاف البيع النقدي");
                CmbInvTyp.Items.Add("إيقاف البيع الآجل");
            }
            else
            {
                CmbInvTyp.Items.Add("Sales Options");
                CmbInvTyp.Items.Add("Stop cash sales");
                CmbInvTyp.Items.Add("Stop Future sales");
            }
            CmbInvTyp.SelectedIndex = 0;
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                List<T_Mndob> listMnd = new List<T_Mndob>(db.T_Mndobs.Select((T_Mndob item) => item).ToList());
                listMnd.Insert(0, new T_Mndob());
                CmbLegate.DataSource = listMnd;
                CmbLegate.DisplayMember = "Arb_Des";
                CmbLegate.ValueMember = "Mnd_ID";
            }
            else
            {
                List<T_Mndob> listMnd = new List<T_Mndob>(db.T_Mndobs.Select((T_Mndob item) => item).ToList());
                listMnd.Insert(0, new T_Mndob());
                CmbLegate.DataSource = listMnd;
                CmbLegate.DisplayMember = "Eng_Des";
                CmbLegate.ValueMember = "Mnd_ID";
            }
            CmbLegate.SelectedIndex = 0;
        }
        private void GetInvSetting()
        {
            _InvSetting = db.StockInvSetting( 22);
            _Company = db.StockCompanyList().FirstOrDefault();
        }
        private void textBox_ID_TextChanged(object sender, EventArgs e)
        {
            long no = 0L;
            try
            {
                no = long.Parse(textBox_ID.Text);
            }
            catch
            {
            }
            try
            {
                T_AccDef newData = db.StockAccDef(no.ToString());
                if (newData == null || string.IsNullOrEmpty(newData.AccDef_No))
                {
                    if (!Button_Add.Visible || !Button_Add.Enabled)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textBox_ID.TextChanged -= textBox_ID_TextChanged;
                        try
                        {
                            textBox_ID.Text = data_this.AccDef_No;
                        }
                        catch
                        {
                        }
                        textBox_ID.TextChanged += textBox_ID_TextChanged;
                        return;
                    }
                    Clear();
                    TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                    TextBox_Index.TextBox.Text = string.Concat(PKeys.Count + 1);
                    TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                }
                else
                {
                    DataThis = newData;
                    int indexA = PKeys.IndexOf(newData.AccDef_No ?? "");
                    indexA++;
                    TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                    TextBox_Index.TextBox.Text = string.Concat(indexA);
                    TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            UpdateVcr();
        }
        public void Clear()
        {
            if (State == FormState.New)
            {
                return;
            }
            State = FormState.New;
            data_this = new T_AccDef();
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
                else if (!(controls[i].Name == codeControl.Name))
                {
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
                        (controls[i] as ComboBox).SelectedIndex = -1;
                    }
                }
            }
            switchButton_DisTyp.Value = false;
            textBox_ID.Focus();
            SetReadOnly = false;
        }
        public void SetData(T_AccDef value)
        {
            try
            {
                try
                {
                    TxtGroupVatNumb.Text = data_this.Group_VAT_Number;

                }
                catch { }
              
                try
                {
                    comboBox1.SelectedIndex = int.Parse(data_this.Buyer_Other_ID.ToString());
                }
                catch
                {
                    comboBox1.SelectedIndex = 0;

                }

                    try
                    {
                        Byer_IDTExt.Text = data_this.Buyer_City;
                    }catch
                    {
                        Byer_IDTExt.Text = "";
                    }
                    try
                    {
                        streetline1.Text = data_this.Street_Line1;
                    }
                    catch
                    { streetline1.Text = ""; }
                    try
                    {
                        streetline2.Text = data_this.Street_Line2;
                    } catch
                    { streetline2.Text = "";
                    }
                    try
                    {
                        ProviesionState.Text = data_this.City_Provision_District;
                    } catch
                    {
                        ProviesionState.Text = "";


                    } try
                    {
                        CountryCode.Text = data_this.Country_Code;
                    }
                    catch
                    {
                        CountryCode.Text = "";


                    } try
                    {
                        BuildingNumber.Text = data_this.Building_Number;
                    }
                    catch { BuildingNumber.Text = ""; }      try
                    {
                        AddationalNumber.Text = data_this.Addational_Address_Number;
                    }
                    catch
                    {
                        AddationalNumber.Text = "";

                    }
             
                                                State = FormState.Saved;
                Button_Save.Enabled = false;
                textBox_ID.Tag = value.AccDef_ID.ToString();
                txtEngDes.Text = value.Eng_Des;
                txtArbDes.Text = value.Arb_Des;
                txtMaxDis.Value = value.MaxDisCust.Value;
                if (value.vColNum1.Value == 1.0)
                {
                    switchButton_DisTyp.Value = true;
                }
                else
                {
                    switchButton_DisTyp.Value = false;
                }
                txtRessonsStoped.Text = value.RessonStoped;
                txtPersonalName.Text = value.PersonalNm;
                txtTaxNo.Text = value.TaxNo;
                txtZipCod.Text = value.zipCod;
                try
                {
                    checkBoxX_Stoped.Checked = value.StopedState.Value;
                }
                catch
                {
                    checkBoxX_Stoped.Checked = false;
                }
                txtMainAccNo.Text = value.ParAcc;
                txtBalance.Value = (value.Balance.HasValue ? value.Balance.Value : 0.0);
                txtCredit.Value = (value.Credit.HasValue ? value.Credit.Value : 0.0);
                txtDeb.Value = (value.Debit.HasValue ? value.Debit.Value : 0.0);
                if (value.Price.HasValue)
                {
                    CmbPrice.SelectedIndex = value.Price.Value;
                }
                else
                {
                    CmbPrice.SelectedIndex = 0;
                }
                if (value.Mnd.HasValue)
                {
                    CmbLegate.SelectedValue = value.Mnd;
                }
                else
                {
                    CmbLegate.SelectedIndex = 0;
                }
                if (value.StopInvTyp.HasValue)
                {
                    CmbInvTyp.SelectedIndex = value.StopInvTyp.Value;
                }
                else
                {
                    CmbInvTyp.SelectedIndex = 0;
                }
                txtCreditLimit.Text = value.MaxLemt.ToString();
                txtCity.Text = value.City ?? "";
                txtEMail.Text = value.Email ?? "";
                txtTele1.Text = value.Telphone1 ?? "";
                txtTele2.Text = value.Telphone2 ?? "";
                txtFax.Text = value.Fax ?? "";
                txtMobile.Text = value.Mobile ?? "";
                txtAgeLimit.Text = value.StrAm.ToString();
                txtAddress.Text = value.Adders ?? "";
                txtAge.Text = value.vColStr1 ?? "";
                checkBoxX_Stoped_CheckedChanged(null, null);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SetData:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void TextBox_Index_InputTextChanged(object sender)
        {
            int index = 0;
            try
            {
                index = Convert.ToInt32(TextBox_Index.TextBox.Text);
            }
            catch
            {
            }
            if (index <= PKeys.Count && index > 0)
            {
                textBox_ID.Text = PKeys[index - 1];
            }
        }
        private T_AccDef GetData()
        {
            textBox_ID.Focus();
            data_this.Arb_Des = txtArbDes.Text;
            data_this.MaxDisCust = txtMaxDis.Value;
            if (switchButton_DisTyp.Value)
            {
                data_this.vColNum1 = 1.0;
            }
            else
            {
                data_this.vColNum1 = 0.0;
            }
            data_this.PersonalNm = txtPersonalName.Text;
            data_this.zipCod = txtZipCod.Text;
            data_this.TaxNo = txtTaxNo.Text;
            try
            {
                if (State == FormState.New)
                {
                    if (data_this.DepreciationPercent.HasValue)
                    {
                        data_this.DepreciationPercent = data_this.DepreciationPercent.Value;
                    }
                    else
                    {
                        data_this.DepreciationPercent = 0.0;
                    }
                    if (data_this.vColNum2.HasValue)
                    {
                        data_this.vColNum2 = data_this.vColNum2.Value;
                    }
                    else
                    {
                        data_this.vColNum2 = 0.0;
                    }
                    if (!string.IsNullOrEmpty(data_this.vColStr2))
                    {
                        data_this.vColStr2 = data_this.vColStr2;
                    }
                    else
                    {
                        data_this.vColStr2 = "";
                    }
                    if (!string.IsNullOrEmpty(data_this.vColStr3))
                    {
                        data_this.vColStr3 = data_this.vColStr3;
                    }
                    else
                    {
                        data_this.vColStr3 = "";
                    }
                }
            }
            catch
            {
            }
            data_this.RessonStoped = txtRessonsStoped.Text;
            data_this.StopedState = checkBoxX_Stoped.Checked;
            data_this.Eng_Des = txtEngDes.Text;
            data_this.AccDef_No = textBox_ID.Text;
            data_this.Lev = 4;
            data_this.ParAcc = txtMainAccNo.Text;
            data_this.AccCat = 4;
            if (State == FormState.New)
            {
                data_this.DC = 0;
                data_this.Trn = 3;
            }
            data_this.Sts = 0;
            if (double.TryParse(txtCreditLimit.Text, out var value))
            {
                data_this.MaxLemt = value;
            }
            else
            {
                data_this.MaxLemt = 0.0;
            }
            data_this.Typ = "";
            data_this.City = txtCity.Text ?? "";
            data_this.Email = txtEMail.Text ?? "";
            data_this.Telphone1 = txtTele1.Text ?? "";
            data_this.Telphone2 = txtTele2.Text ?? "";
            data_this.vColStr1 = txtAge.Text ?? "";
            data_this.Fax = txtFax.Text ?? "";
            data_this.Mobile = txtMobile.Text ?? "";
            data_this.DesPers = "";
            data_this.StrAm = int.Parse(txtAgeLimit.Text);
            data_this.Adders = txtAddress.Text ?? "";
            data_this.Price = CmbPrice.SelectedIndex;
            if (CmbLegate.SelectedIndex > 0)
            {
                data_this.Mnd = int.Parse(CmbLegate.SelectedValue.ToString());
            }
            else
            {
                data_this.Mnd = null;
            }
            data_this.StopInvTyp = CmbInvTyp.SelectedIndex;
            data_this.BankComm = 0.0;
            if (State == FormState.New)
            {
                data_this.TotPoints = 0.0;
            }
            data_this.CompanyID = 1;
            data_this.Group_VAT_Number = TxtGroupVatNumb.Text;
            data_this.Buyer_Other_ID = comboBox1.SelectedIndex.ToString();
            data_this.Buyer_City = Byer_IDTExt.Text;
            data_this.Buyer_City = Byer_IDTExt.Text;
            data_this.Street_Line1 = streetline1.Text;
            data_this.Street_Line2 = streetline2.Text;
            data_this.City_Provision_District = ProviesionState.Text;
            data_this.Country_Code = CountryCode.Text;
            data_this.Building_Number = BuildingNumber.Text;
            data_this.Addational_Address_Number = AddationalNumber.Text;
            return data_this;
        }
        private void Button_Edit_Click(object sender, EventArgs e)
        {
            if (CanEdit && State != FormState.Edit && State != FormState.New && !string.IsNullOrEmpty(textBox_ID.Text))
            {
                if (State != FormState.New)
                {
                    State = FormState.Edit;
                }
                LockedFrm(Stat: false);
                SetReadOnly = false;
            }
        }
        private void Button_Add_Click(object sender, EventArgs e)
        {
            if (!Button_Add.Visible || !Button_Add.Enabled)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                if (State == FormState.Edit && MessageBox.Show((LangArEn == 0) ? "تم تعديل السجل الحالي دون حفظ التغييرات .. هل تريد المتابعة؟" : "Not saved the changes, do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    return;
                }
                Clear();
                int id = db.MaxAccDefNo;
                textBox_ID.Tag = id.ToString();
                State = FormState.New;
                LockedFrm(Stat: false);
                try
                {
                    T_AccDef q = db.StockAccDefWithOutBalance("1022");
                    if (q != null && !string.IsNullOrEmpty(q.AccDef_No))
                    {
                        txtMainAccNo.Text = "1022";
                    }
                }
                catch
                {
                }
            }
        }
        private void Button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Button_Save.Enabled)
                {
                    return;
                }
                if (State == FormState.Edit && !CanEdit)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (State == FormState.New && !Button_Add.Enabled)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                textBox_ID.Focus();
                if (textBox_ID.Text == "" || txtArbDes.Text == "" || txtEngDes.Text == "")
                {
                    MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الرمز او الإسم فارغا\u0651" : "Can not be a number or name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                try
                {
                    if (VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 14) && State == FormState.New)
                    {
                        IdProof = "";
                        if (string.IsNullOrEmpty(txtMobile.Text) || string.IsNullOrEmpty(VarGeneral.Settings_Sys.smsUserName) || string.IsNullOrEmpty(VarGeneral.Settings_Sys.smsPass) || string.IsNullOrEmpty(VarGeneral.Settings_Sys.smsSenderName.Trim()))
                        {
                            MessageBox.Show((LangArEn == 0) ? "لم يتم ارسال رسالة نصية الى جوال العميل .. يرجى التأكد من صحة بيانات إعدادات الرسائل النصية" : "SMS Message was not sent to the Boss .. Please make sure the settings information is correct.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;
                        }
                        if (!SendMobileMessage())
                        {
                            return;
                        }
                        string vNewNo = InputDialog.mostrar((LangArEn == 0) ? "أدخل الرمز التأكيدي المرسل للعميل : " : "Enter the confirmation code sent to the customer : ", "Confirm Customer Identity");
                        if (vNewNo != IdProof)
                        {
                            MessageBox.Show((LangArEn == 0) ? ".. يرجى التأكد من صحة الرمز" : "Please make sure the code", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show((LangArEn == 0) ? "لم يتم ارسال رسالة نصية الى جوال العميل .. يرجى التأكد من صحة بيانات إعدادات الرسائل النصية" : "SMS Message was not sent to the Boss .. Please make sure the settings information is correct.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (State != FormState.New || string.IsNullOrEmpty(txtMobile.Text))
                {
                    goto IL_047c;
                }
                List<T_AccDef> q = (from item in db.T_AccDefs
                                    where item.Lev == (int?)4 && item.AccCat == (int?)4
                                    where item.Mobile == txtMobile.Text
                                    orderby item.AccDef_No
                                    select item).ToList();
                if (!VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 18) || q.Count <= 0)
                {
                    goto IL_047c;
                }
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                goto end_IL_0001;
            IL_047c:
                GetData();
                if (State == FormState.New)
                {
                    try
                    {
                        data_this.MainSal = 0.0;
                        data_this.Credit = 0.0;
                        data_this.Debit = 0.0;
                        data_this.Balance = 0.0;
                        db.T_AccDefs.InsertOnSubmit(data_this);
                        db.SubmitChanges();
                    }
                    catch (SqlException ex5)
                    {
                        if (ex5.Number != 2627)
                        {
                            return;
                        }
                        MessageBox.Show("الرقم مستخدم من قبل.\n سيتم الحفظ برقم جديد ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        int id = db.MaxAccDefNo;
                        textBox_ID.Tag = id.ToString();
                        Button_Save_Click(sender, e);
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
                else if (State == FormState.Edit)
                {
                    try
                    {
                        db.Log = VarGeneral.DebugLog;
                        db.SubmitChanges(ConflictMode.ContinueOnConflict);
                    }
                    catch (SqlException)
                    {
                        return;
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
                State = FormState.Saved;
                RefreshPKeys();
                TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(data_this.AccDef_No ?? "") + 1);
                SetReadOnly = true;
                LockedFrm(Stat: true);
            end_IL_0001:;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Save:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        private bool SendMobileMessage()
        {
            try
            {
                IdProof = RandomNumber(1000, 9999).ToString();
                string msgTxt = ((LangArEn == 0) ? ("رمز تأكيد الهوية هو :  " + IdProof) : ("The confirmation code is : " + IdProof));
                Regex regex = new Regex("^\\d{10}$");
                Match match = regex.Match(txtMobile.Text);
                if (!match.Success)
                {
                    MessageBox.Show((LangArEn == 0) ? "لم يتم ارسال رسالة نصية الى جوال العميل .. يرجى التأكد من صحة رقم الجوال" : "SMS Message was not sent to the Boss .. Please make sure the Mobile Number.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
                if (!txtMobile.Text.StartsWith("05"))
                {
                    MessageBox.Show((LangArEn == 0) ? "لم يتم ارسال رسالة نصية الى جوال العميل .. يرجى التأكد من صحة رقم الجوال" : "SMS Message was not sent to the Boss .. Please make sure the Mobile Number.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
                string M_Value = "966" + txtMobile.Text.Substring(1);
                string t = SendMessage(VarGeneral.Settings_Sys.smsUserName, VarGeneral.Settings_Sys.smsPass, ConvertToUnicode(msgTxt), VarGeneral.Settings_Sys.smsSenderName.Trim(), M_Value);
                ShowResult(t);
                if (t != "1")
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show((LangArEn == 0) ? "لم يتم ارسال رسالة نصية الى جوال العميل .. يرجى التأكد من صحة رقم الجوال" : "SMS Message was not sent to the Boss .. Please make sure the Mobile Number.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
        }
        public string SendMessage(string username, string password, string msg, string sender, string numbers)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://www.mobily.ws/api/msgSend.php");
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            string SenderList = "";
            string postData = "mobile=" + username + "&password=" + password + "&numbers=" + (string.IsNullOrEmpty(SenderList) ? numbers : (SenderList + "," + numbers)) + "&sender=" + sender + "&msg=" + msg + "&applicationType=61";
            req.ContentLength = postData.Length;
            StreamWriter stOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
            stOut.Write(postData);
            stOut.Close();
            StreamReader stIn = new StreamReader(req.GetResponse().GetResponseStream());
            string strResponse = stIn.ReadToEnd();
            stIn.Close();
            return strResponse;
        }
        private void ShowResult(string res)
        {
            switch (res)
            {
                case "1":
                    break;
                case "2":
                    MessageBox.Show("إن رصيدك لدى برو سوفت قد إنتهى ولم يعد به أي رسائل. (لحل المشكلة قم بشحن رصيدك من الرسائل لدى برو سوفت. لشحن رصيدك إتبع تعليمات شحن الرصيد)");
                    break;
                case "3":
                    MessageBox.Show("إن رصيدك الحالي لا يكفي لإتمام عملية الإرسال. (لحل المشكلة قم بشحن رصيدك من الرسائل لدى برو سوفت. لشحن رصيدك إتبع تعليمات شحن الرصيد");
                    break;
                case "4":
                    MessageBox.Show("إن إسم المستخدم الذي إستخدمته للدخول إلى حساب الرسائل غير صحيح (تأكد من أن إسم المستخدم الذي إستخدمته هو نفسه الذي تستخدمه عند دخولك إلى موقع برو سوفت).");
                    break;
                case "5":
                    MessageBox.Show("هناك خطأ في كلمة المرور (تأكد من أن كلمة المرور التي تم إستخدامها هي نفسها التي تستخدمها عند دخولك موقع برو سوفت,إذا نسيت كلمة المرور إضغط على رابط نسيت كلمة المرور لتصلك رسالة على جوالك برقم المرور الخاص بك)");
                    break;
                case "6":
                    MessageBox.Show("إن صفحة الإرسال لاتجيب في الوقت الحالي (قد يكون هناك طلب كبير على الصفحة أو توقف مؤقت للصفحة فقط حاول مرة أخرى أو تواصل مع الدعم الفني إذا إستمر الخطأ)");
                    break;
                case "12":
                    MessageBox.Show("إن حسابك بحاجة إلى تحديث يرجى مراجعة الدعم الفني");
                    break;
                case "13":
                    MessageBox.Show("إن إسم المرسل الذي إستخدمته في هذه الرسالة لم يتم قبوله. (يرجى إرسال الرسالة بإسم مرسل آخر أو تعريف إسم المرسل لدى برو سوفت)");
                    break;
                case "14":
                    MessageBox.Show("إن إسم المرسل الذي إستخدمته غير معرف لدى برو سوفت. (يمكنك تعريف إسم المرسل من خلال صفحة إضافة إسم مرسل)");
                    break;
                case "15":
                    MessageBox.Show("يوجد رقم جوال خاطئ في الأرقام التي قمت بالإرسال لها. (تأكد من صحة الأرقام التي تريد الإرسال لها وأنها بالصيغة الدولية)");
                    break;
                case "16":
                    MessageBox.Show("الرسالة التي قمت بإرسالها لا تحتوي على إسم مرسل. (أدخل إسم مرسل عند إرسالك الرسالة)");
                    break;
                case "17":
                    MessageBox.Show("لم يتم ارسال نص الرسالة. الرجاء التأكد من ارسال نص الرسالة والتأكد من تحويل الرسالة الى يوني كود (الرجاء التأكد من استخدام الدالة()");
                    break;
                case "18":
                    MessageBox.Show("الارسال متوقف حاليا");
                    break;
                case "19":
                    MessageBox.Show("applicationType غير موجودة في الرابط");
                    break;
                case "-1":
                    MessageBox.Show("لم يتم التواصل مع خادم (Server) الإرسال برو سوفت بنجاح. (قد يكون هناك محاولات إرسال كثيرة تمت معا , أو قد يكون هناك عطل مؤقت طرأ على الخادم إذا إستمرت المشكلة يرجى التواصل مع الدعم الفني)");
                    break;
                case "-2":
                    MessageBox.Show("لم يتم الربط مع قاعدة البيانات (Database) التي تحتوي على حسابك وبياناتك لدى برو سوفت. (قد يكون هناك محاولات إرسال كثيرة تمت معا , أو قد يكون هناك عطل مؤقت طرأ على الخادم إذا إستمرت المشكلة يرجى التواصل مع الدعم الفني)");
                    break;
                default:
                    MessageBox.Show(res.ToString());
                    break;
            }
        }
        private string ConvertToUnicode(string val)
        {
            string msg2 = string.Empty;
            for (int i = 0; i < val.Length; i++)
            {
                msg2 += convertToUnicode(Convert.ToChar(val.Substring(i, 1)));
            }
            return msg2;
        }
        private string convertToUnicode(char ch)
        {
            UnicodeEncoding class1 = new UnicodeEncoding();
            byte[] msg = class1.GetBytes(Convert.ToString(ch));
            return fourDigits(msg[1] + msg[0].ToString("X"));
        }
        private string fourDigits(string val)
        {
            string result = string.Empty;
            switch (val.Length)
            {
                case 1:
                    result = "000" + val;
                    break;
                case 2:
                    result = "00" + val;
                    break;
                case 3:
                    result = "0" + val;
                    break;
                case 4:
                    result = val;
                    break;
            }
            return result;
        }
        private void Button_Delete_Click(object sender, EventArgs e)
        {
            if (!Button_Delete.Enabled || !Button_Delete.Visible || State != 0)
            {
                ifOkDelete = false;
                return;
            }
            string Code = "";
            Code = textBox_ID.Text;
            if (Code == "")
            {
                ifOkDelete = false;
                return;
            }
            if (MessageBox.Show("هل أنت متاكد من حذف السجل [" + Code + "]؟ \n Are you sure that you want to delete the record [" + Code + "]?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ifOkDelete = true;
            }
            else
            {
                ifOkDelete = false;
            }
            if (data_this == null || string.IsNullOrEmpty(data_this.AccDef_No) || !ifOkDelete)
            {
                return;
            }
            T_GDDET returned = db.SelectAccDefNoByReturnNo(DataThis.AccDef_No);
            if ((returned != null && returned.GDDET_ID != 0) || textBox_ID.Text == "1")
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن حذف العميل .. لانه مرتبط باحد القيود" : "You can not delete Category .. because it is tied to a Gaid", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            data_this = db.StockAccDefWithOutBalance(DataThis.AccDef_No);
            try
            {
                db.T_AccDefs.DeleteOnSubmit(DataThis);
                db.SubmitChanges();
            }
            catch (SqlException)
            {
                data_this = db.StockAccDefWithOutBalance(DataThis.AccDef_No);
                return;
            }
            catch (Exception)
            {
                data_this = db.StockAccDefWithOutBalance(DataThis.AccDef_No);
                return;
            }
            Clear();
            RefreshPKeys();
            textBox_ID.Text = PKeys.LastOrDefault();
        }
        private void DGV_Main_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            string dataMember = panel.DataMember;
            if (dataMember != null && dataMember == "T_AccDef")
            {
                PropBranchPanel(panel);
            }
        }
        private void PropBranchPanel(GridPanel panel)
        {
            DGV_Main.PrimaryGrid.UseAlternateRowStyle = true;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background.Color1 = Color.SkyBlue;
            panel.FrozenColumnCount = 1;
            panel.Columns[0].GroupBoxEffects = GroupBoxEffects.None;
            foreach (GridColumn column in panel.Columns)
            {
                column.ColumnSortMode = ColumnSortMode.Multiple;
            }
            panel.ColumnHeader.RowHeight = 30;
            for (int i = 0; i < panel.Columns.Count; i++)
            {
                DGV_Main.PrimaryGrid.Columns[i].CellStyles.Default.Alignment = Alignment.MiddleCenter;
                DGV_Main.PrimaryGrid.Columns[i].Visible = false;
            }
            panel.Columns["AccDef_No"].Width = 120;
            panel.Columns["AccDef_No"].Visible = columns_Names_visible["AccDef_No"].IfDefault;
            panel.Columns["Arb_Des"].Width = 180;
            panel.Columns["Arb_Des"].Visible = columns_Names_visible["Arb_Des"].IfDefault;
            panel.Columns["Eng_Des"].Width = 180;
            panel.Columns["Eng_Des"].Visible = columns_Names_visible["Eng_Des"].IfDefault;
            panel.Columns["Adders"].Width = 120;
            panel.Columns["Adders"].Visible = columns_Names_visible["Adders"].IfDefault;
            panel.Columns["Mobile"].Width = 120;
            panel.Columns["Mobile"].Visible = columns_Names_visible["Mobile"].IfDefault;
        }
        private void DGV_Main_CellClick(object sender, GridCellClickEventArgs e)
        {
            DGV_Main.PrimaryGrid.Tag = e.GridCell.RowIndex;
        }
        private void DGV_Main_CellDoubleClick(object sender, GridCellDoubleClickEventArgs e)
        {
            ToolStripMenuItem_Det_Click(sender, e);
        }
        private void Button_ExportTable2_Click(object sender, EventArgs e)
        {
            try
            {
                ExportExcel.ExportToExcel(DGV_Main, "تقرير العملاء");
            }
            catch
            {
            }
        }
        private void Button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ADD_Controls()
        {
            try
            {
                controls = new List<Control>();
                controls.Add(textBox_ID);
                controls.Add(txtAddress);
                controls.Add(txtAgeLimit);
                controls.Add(txtArbDes);
                controls.Add(txtRessonsStoped);
                controls.Add(txtPersonalName);
                controls.Add(txtZipCod);
                controls.Add(txtTaxNo);
                controls.Add(checkBoxX_Stoped);
                controls.Add(txtBalance);
                controls.Add(txtCity);
                controls.Add(txtCredit);
                controls.Add(txtCreditLimit);
                controls.Add(txtDeb);
                controls.Add(txtEMail);
                controls.Add(txtEngDes);
                controls.Add(txtFax);
                controls.Add(txtMainAccNo);
                controls.Add(txtMobile);
                controls.Add(txtTele1);
                controls.Add(txtTele2);
                controls.Add(txtAge);
                controls.Add(buttonX_SerchAccNo);
                controls.Add(CmbPrice);
                controls.Add(CmbLegate);
                controls.Add(CmbInvTyp);
                controls.Add(txtMaxDis);
                controls.Add(switchButton_DisTyp);
            }
            catch (SqlException)
            {
            }
        }
        private void textBox_ID_Leave(object sender, EventArgs e)
        {
            if (textBox_ID.Text != "" && State == FormState.New)
            {
                List<T_AccDef> q = (from t in db.T_AccDefs
                                    where t.AccDef_No == textBox_ID.Text
                                    orderby t.AccDef_No descending
                                    select t).ToList();
                if (q.Count != 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "الرقم الذي قمت بإدخاله موجود من قبل - مكرر .. يرجى المحاولة مرة اخرى" : "The number you have entered already exists - bis .. Please try again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_ID.Text = "";
                    textBox_ID.Focus();
                }
            }
        }
        private void txtArbDes_Enter(object sender, EventArgs e)
        {
            Framework.Keyboard.Language.Switch("Arabic");
        }
        private void txtEngDes_Enter(object sender, EventArgs e)
        {
            Framework.Keyboard.Language.Switch("English");
        }
        private void buttonX_SerchAccNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "AccDefID_Customer";
            VarGeneral.AccTyp = 4;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtMainAccNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
            }
            else
            {
                txtMainAccNo.Text = "";
            }
        }
        private void txtMainAccNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox_ID.TextChanged -= textBox_ID_TextChanged;
                if (State == FormState.New && !string.IsNullOrEmpty(txtMainAccNo.Text))
                {
                    int Value = 0;
                    List<T_AccDef> q = (from t in db.T_AccDefs
                                        where t.ParAcc == txtMainAccNo.Text
                                        orderby t.AccDef_ID
                                        select t).ToList();
                    if (q.Count == 0)
                    {
                        textBox_ID.Text = txtMainAccNo.Text + "001";
                        txtArbDes.Focus();
                    }
                    else
                    {
                        _AccDefBind = q[q.Count - 1];
                        string _Zero = "";
                        for (int iiCnt = 0; iiCnt < _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Length && _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Substring(iiCnt, 1) == "0"; iiCnt++)
                        {
                            _Zero += _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Substring(iiCnt, 1);
                        }
                        Value = int.Parse(_AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length)) + 1;
                        if (!string.IsNullOrEmpty(_Zero))
                        {
                            textBox_ID.Text = _AccDefBind.ParAcc + _Zero + Value;
                        }
                        else
                        {
                            textBox_ID.Text = _AccDefBind.ParAcc + Value;
                        }
                        txtArbDes.Focus();
                    }
                }
                textBox_ID.TextChanged += textBox_ID_TextChanged;
            }
            catch
            {
                txtMainAccNo.Text = "";
                textBox_ID.TextChanged += textBox_ID_TextChanged;
            }
        }
        private void checkBoxX_Stoped_CheckedChanged(object sender, EventArgs e)
        {
            if (!File.Exists(Application.StartupPath + "\\Script\\SecriptInvitationCards.dll"))
            {
                if (checkBoxX_Stoped.Checked)
                {
                    txtRessonsStoped.Enabled = true;
                    return;
                }
                txtRessonsStoped.Enabled = false;
                txtRessonsStoped.Text = "";
            }
        }
        private void buttonX_CustomerStoped_Click(object sender, EventArgs e)
        {
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_AccDef_CustomerStoped";
            VarGeneral.AccTyp = 4;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                textBox_ID.Text = frm.SerachNo.ToString();
            }
        }
        private void txtTele1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b')) && e.KeyChar != '-' && e.KeyChar != '\\')
            {
                e.Handled = true;
            }
        }
        private void textBox_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        public void Button_Print_Click(object sender, EventArgs e)
        {
            if (ViewState != 0)
            {
                return;
            }
            try
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_AccDef left join T_SYSSETTING on T_SYSSETTING.SYSSETTING_ID = T_AccDef.CompanyID ";
                string Fields = "";
                Fields = " T_AccDef.AccDef_ID , T_AccDef.AccDef_No as No , T_AccDef.Arb_Des as NmA, T_AccDef.Eng_Des as NmE,T_SYSSETTING.LogImg ";
                _RepShow.Rule = " Where 1 = 1 and T_AccDef.AccCat = '4' and T_AccDef.Lev = 4 ";
                if (!string.IsNullOrEmpty(Fields))
                {
                    _RepShow.Fields = Fields;
                    try
                    {
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show(ex2.Message);
                    }
                    if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "عفوا .. لا يوجد بيانات لعرضها في التقرير " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    try
                    {
                        VarGeneral.IsGeneralUsed = true;
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "RepGeneral";
                        frm.Tag = LangArEn;
                        frm.Repvalue = "RepGeneral";
                        VarGeneral.vTitle = Text;
                        frm.TopMost = true;
                        frm.ShowDialog();
                        VarGeneral.IsGeneralUsed = false;
                    }
                    catch (Exception error)
                    {
                        VarGeneral.DebLog.writeLog("button_ShowRep_Click:", error, enable: true);
                        MessageBox.Show(error.Message);
                    }
                }
                else
                {
                    MessageBox.Show((LangArEn == 0) ? " يجب تحديد حقل واحد على الأقل للطباعة" : "You must select one field or more", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }
        private void txtTele1_Click(object sender, EventArgs e)
        {
            txtTele1.SelectAll();
        }
        private void txtFax_Click(object sender, EventArgs e)
        {
            txtFax.SelectAll();
        }
        private void txtMobile_Click(object sender, EventArgs e)
        {
            txtMobile.SelectAll();
        }
        private void textBox_ID_Click(object sender, EventArgs e)
        {
            textBox_ID.SelectAll();
        }
        private void prnt_doc_BeginPrint(object sender, PrintEventArgs e)
        {
            CountPage = 0;
        }
        private void prnt_doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                e.PageSettings.Margins.Bottom = 0;
                e.PageSettings.Margins.Top = Convert.ToInt32(_InvSetting.InvpRINTERInfo.hAl);
                e.PageSettings.Margins.Left = Convert.ToInt32(_InvSetting.InvpRINTERInfo.hYs);
                e.PageSettings.Margins.Right = 0;
                e.PageSettings.PrinterSettings.Copies = short.Parse(_InvSetting.InvpRINTERInfo.DefLines.Value.ToString());
                List<T_mInvPrint> listmInvPrint = new List<T_mInvPrint>();
                T_mInvPrint _mInvPrint = new T_mInvPrint();
                listmInvPrint = (from item in db.T_mInvPrints
                                 where item.repTyp == (int?)22
                                 where item.repNum == (int?)4
                                 where item.IsPrint == (int?)1
                                 where item.BarcodeTyp == (int?)1
                                 select item).ToList();
                if (listmInvPrint.Count == 0)
                {
                    return;
                }
                double _isRows = 0.0;
                double _isCols = 0.0;
                float _Row = 0f;
                float _Col = 0f;
                double _PageLine = _InvSetting.InvpRINTERInfo.lnPg.Value;
                double _LineSp = _InvSetting.InvpRINTERInfo.lnSpc.Value;
                StringFormat strformat = new StringFormat((StringFormatFlags)0, 1);
                for (int iiRnt = 0; (double)iiRnt < _PageLine; iiRnt++)
                {
                    _isCols = 0.0;
                    for (int iiCol = 0; (double)iiCol < _LineSp; iiCol++)
                    {
                        for (int iiCnt = 0; iiCnt < listmInvPrint.Count; iiCnt++)
                        {
                            _mInvPrint = listmInvPrint[iiCnt];
                            if (!(_mInvPrint.vFont != "0") || _mInvPrint.vSize.Value == 0)
                            {
                                continue;
                            }
                            strformat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                            if (_mInvPrint.vEt.Value == 0)
                            {
                                strformat.Alignment = StringAlignment.Near;
                            }
                            else if (_mInvPrint.vEt.Value == 1)
                            {
                                strformat.Alignment = StringAlignment.Far;
                            }
                            else if (_mInvPrint.vEt.Value == 2)
                            {
                                strformat.Alignment = StringAlignment.Center;
                            }
                            if (_mInvPrint.uChr == "mm")
                            {
                                e.Graphics.PageUnit = GraphicsUnit.Millimeter;
                            }
                            else if (_mInvPrint.uChr == "doc")
                            {
                                e.Graphics.PageUnit = GraphicsUnit.Document;
                            }
                            else if (_mInvPrint.uChr == "in")
                            {
                                e.Graphics.PageUnit = GraphicsUnit.Inch;
                            }
                            else if (_mInvPrint.uChr == "point")
                            {
                                e.Graphics.PageUnit = GraphicsUnit.Point;
                            }
                            else if (_mInvPrint.uChr == "pixel")
                            {
                                e.Graphics.PageUnit = GraphicsUnit.Pixel;
                            }
                            Font _font = new Font(_mInvPrint.vFont, float.Parse(_mInvPrint.vSize.Value.ToString()), e.Graphics.PageUnit);
                            if (_mInvPrint.vBold.Value == 1)
                            {
                                _font = new Font(_mInvPrint.vFont, float.Parse(_mInvPrint.vSize.Value.ToString()), FontStyle.Bold, e.Graphics.PageUnit);
                            }
                            _Row = (float)_mInvPrint.vRow.Value + (float)_isRows;
                            _Col = (float)_mInvPrint.vCol.Value + (float)_isCols;
                            if (_mInvPrint.pField == "CustNo")
                            {
                                e.Graphics.DrawImage(c1BarCode1.Image, _Col, _Row, float.Parse(_mInvPrint.MaxW.Value.ToString()), float.Parse(_mInvPrint.vSize.Value.ToString()));
                            }
                            else if (_mInvPrint.pField == "CustNm")
                            {
                                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                                {
                                    e.Graphics.DrawString(txtArbDes.Text, _font, Brushes.Black, _Col, _Row, strformat);
                                }
                                else
                                {
                                    e.Graphics.DrawString(txtEngDes.Text, _font, Brushes.Black, _Col, _Row, strformat);
                                }
                            }
                            else if (_mInvPrint.pField == "CompanyNm")
                            {
                                e.Graphics.DrawString(_Company.CopNam, _font, Brushes.Black, _Col, _Row, strformat);
                            }
                        }
                        _isCols = _isCols + (double)_InvSetting.InvNum1.Value + _InvSetting.InvpRINTERInfo.hYm.Value;
                    }
                    _isRows = _isRows + (double)_InvSetting.InvNum.Value + _InvSetting.InvpRINTERInfo.hAs.Value;
                }
                CountPage++;
                if (CountPage == e.PageSettings.PrinterSettings.Copies)
                {
                    e.HasMorePages = false;
                }
                else
                {
                    e.HasMorePages = true;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
                MessageBox.Show("عفوا\u064b ... لا توجد حقول للطباعة راجع إعدادات الطباعة  \n Sorry , Not Found Fields for Printing", Application.ProductName);
            }
        }
        private void PrintSet()
        {
            string _PrinterName = prnt_doc.PrinterSettings.PrinterName;
            prnt_doc.PrinterSettings.PrinterName = _InvSetting.InvpRINTERInfo.defPrn;
            if (!prnt_doc.PrinterSettings.IsValid)
            {
                prnt_doc.PrinterSettings.PrinterName = _PrinterName;
            }
        }
        private void PrintForm_Click(object sender, EventArgs e)
        {
            PrintDialog PrintDialog1 = new PrintDialog();
            printDialog1.Document = prnt_doc;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                prnt_doc.Print();
            }
        }
        private void button_Barcode_Click(object sender, EventArgs e)
        {
            if (!(textBox_ID.Text != ""))
            {
                return;
            }
            c1BarCode1.Text = textBox_ID.Text;
            PrintSet();
            prnt_prev = new PrintPreviewDialog();
            ToolStrip toollstr = (ToolStrip)prnt_prev.Controls["toolStrip1"];
            toollstr.Items.RemoveAt(0);
            toollstr.Items.Add("Print", null, PrintForm_Click);
            prnt_prev.Controls.Add(toollstr);
            prnt_prev.Document = prnt_doc;
            prnt_prev.ShowIcon = false;
            prnt_prev.AllowTransparency = true;
            prnt_prev.MdiParent = base.MdiParent;
            PrintDialog PrintDialog1 = new PrintDialog();
            printDialog1.Document = prnt_doc;
            T_INVSETTING _InvSetting = new T_INVSETTING();
            _InvSetting = db.StockInvSetting( 22);
            try
            {
                if (_InvSetting.InvpRINTERInfo.DefLines.Value > 0)
                {
                    if (_InvSetting.InvTypA4 == "1")
                    {
                        prnt_doc.PrinterSettings.Collate = true;
                    }
                    else
                    {
                        prnt_doc.PrinterSettings.Collate = false;
                    }
                }
                else
                {
                    prnt_doc.PrinterSettings.Collate = false;
                }
            }
            catch
            {
                prnt_doc.PrinterSettings.Collate = false;
            }
            try
            {
                if (_InvSetting.ISdirectPrinting)
                {
                    prnt_doc.Print();
                    return;
                }
                prnt_prev.TopMost = true;
                prnt_prev.ShowDialog();
            }
            catch
            {
            }
        }
        private void button_SrchPlaceNo_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            if (State == FormState.Saved)
            {
                return;
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
            VarGeneral.SFrmTyp = "T_AccDef";
            VarGeneral.AccTyp = 5;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtRessonsStoped.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtPlaceName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
                else
                {
                    txtPlaceName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
            }
            else
            {
                txtRessonsStoped.Text = "";
                txtPlaceName.Text = "";
            }
        }
        private void txtRessonsStoped_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(Application.StartupPath + "\\Script\\SecriptInvitationCards.dll"))
                {
                    return;
                }
                if (txtRessonsStoped.Text != "")
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtPlaceName.Text = db.StockAccDefWithOutBalance(txtRessonsStoped.Text).Arb_Des;
                    }
                    else
                    {
                        txtPlaceName.Text = db.StockAccDefWithOutBalance(txtRessonsStoped.Text).Eng_Des;
                    }
                }
                else
                {
                    txtPlaceName.Text = "";
                }
            }
            catch
            {
            }
        }
        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void Button_Add_Click_1(object sender, EventArgs e)
        {
        }
        private void FrmCustomer_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;
        }
        private void superTabControl_Main2_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        {
        }
        private void label23_TextChanged(object sender, EventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button_Save_Click_1(object sender, EventArgs e)
        {

        }

        private void CountryCode_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(null, null);
        }
    }
}
