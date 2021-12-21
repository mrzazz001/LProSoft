using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using Framework.Data;
using ProShared.GeneralM;using ProShared;
using CellRange = C1.Win.C1FlexGrid.CellRange;
using ProShared.Stock_Data;
using Library.RepShow;

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
using Microsoft.Win32;

namespace InvAcc.Forms
{
    public partial  class FMJournalVoucherEmpRelaySal : Form
    { void avs(int arln)

{ 
 ToolStripMenuItem_Rep.Text=   (arln == 0 ? "  إظهار التقرير  " : "  Show report") ; panelEx3.Text=   (arln == 0 ? "  Fill Panel  " : "  Fill Panel") ; DGV_Main.Text=   (arln == 0 ? "    " : "    ") ; DGV_Main.Text=   (arln == 0 ? "  جميــع السجــــلات  " : "  All records") ; DGV_Main.Text=   (arln == 0 ? "    " : "    ") ; superTabControl_DGV.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; textBox_search.Text=   (arln == 0 ? "  ...  " : "  ...") ; Button_ExportTable2.Text=   (arln == 0 ? "  تصدير  " : "  Export") ; /*Button_PrintTable.Text=   (arln == 0 ? "  طباعة  " : "  Print") ; */panelEx2.Text=   (arln == 0 ? "  Click to collapse  " : "  Click to collapse") ; label3.Text=   (arln == 0 ? "  قيمة المدين  " : "  Debit value") ; label19.Text=   (arln == 0 ? "  العملــــــــة :  " : "  work:") ; label18.Text=   (arln == 0 ? "  المنـــــدوب :  " : "  The delegate:") ; label17.Text=   (arln == 0 ? "  الرصيد  " : "  Balance") ; Label21.Text=   (arln == 0 ? "  قيمة الدائن  " : "  creditor value") ; label15.Text=   (arln == 0 ? "  مركز التكلفـــــة :  " : "  cost center:") ; Label9.Text=   (arln == 0 ? "  ملاحظـــات :  " : "  Notes:") ; label7.Text=   (arln == 0 ? "  رقم المرجع :  " : "  reference number :") ; Label2.Text=   (arln == 0 ? "  التاريــــــــخ :  " : "  date:") ; Label1.Text=   (arln == 0 ? "  رقم السند :  " : "  Bond No :") ; label6.Text=   (arln == 0 ? "  الحســــاب :  " : "  Account:") ; superTabControl_Main1.Text=   (arln == 0 ? "  superTabControl3  " : "  superTabControl3") ; Button_Close.Text=   (arln == 0 ? "  إغلاق  " : "  Close") ; /*buttonItem_Print.Text=   (arln == 0 ? "  طباعة  " : "  Print") ;*/ Button_Search.Text=   (arln == 0 ? "  بحث  " : "  Search") ; Button_Delete.Text=   (arln == 0 ? "  حذف  " : "  delete") ; Button_Save.Text=   (arln == 0 ? "  حفظ  " : "  save") ; Button_Add.Text=   (arln == 0 ? "  إضافة  " : "  addition") ; superTabControl_Main2.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; Button_First.Text=   (arln == 0 ? "  الأول  " : "  the first") ; Button_Prev.Text=   (arln == 0 ? "  السابق  " : "  the previous") ; lable_Records.Text=   (arln == 0 ? "  ---  " : "  ---") ; Button_Next.Text=   (arln == 0 ? "  التالي  " : "  next one") ; Button_Last.Text=   (arln == 0 ? "  الأخير  " : "  the last one") ; ToolStripMenuItem_Det.Text=   (arln == 0 ? "  إظهار التفاصيل  " : "  Show details") ; Text = "القيود المرحلة للرواتب";this.Text=   (arln == 0 ? "  القيود المرحلة للرواتب  " : "  Stage restrictions for salaries") ;}
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
                    if (textBox_ID.Text != "" && State == FormState.Saved)
                    {
                        buttonItem_Print_Click(null, null);
                        VarGeneral.Print_set_Gen_Stat = false;
                    }
                    else
                    {
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "RepGaid";
                        frm.Repvalue = "RepGaid";
                        //ADDADD
                        frm.Tag = LangArEn;
                        frm.ShowDialog();
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
        protected ToolStripMenuItem ToolStripMenuItem_Rep;
        private DockSite barTopDockSite;
        private DockSite barBottomDockSite;
        private Panel panel1;
        private PanelEx panelEx3;
        private ExpandableSplitter expandableSplitter1;
        private PanelEx panelEx2;
        private RibbonBar ribbonBar1;
        internal Label label19;
        internal Label label18;
        internal Label label17;
        internal Label Label21;
        private ComboBoxEx CmbCostC;
        private ComboBoxEx CmbCurr;
        private ComboBoxEx CmbLegate;
        internal Label label15;
        internal TextBox txtRemark;
        internal TextBox txtRef;
        internal TextBox textBox_ID;
        internal Label Label9;
        internal Label label7;
        internal Label Label2;
        internal Label Label1;
        private DockSite barLeftDockSite;
        private DockSite barRightDockSite;
        internal PrintPreviewDialog prnt_prev;
        private PrintDocument prnt_doc;
        private Timer timer1;
        private DockSite dockSite4;
        private ImageList imageList1;
        public DotNetBarManager dotNetBarManager1;
        private DockSite dockSite1;
        private DockSite dockSite2;
        private DockSite dockSite3;
        protected ContextMenuStrip contextMenuStrip1;
        protected ContextMenuStrip contextMenuStrip2;
        protected ToolStripMenuItem ToolStripMenuItem_Det;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Timer timerInfoBallon;
        private System.Windows.Forms.OpenFileDialog  openFileDialog1;
        private C1FlexGrid c1FlexGrid1;
        private TextBox txtAccName;
        private Label label6;
        internal Label label3;
        private RibbonBar ribbonBar_Tasks;
        private SuperTabControl superTabControl_Main1;
        protected ButtonItem Button_Close;
        protected ButtonItem Button_Search;
        protected ButtonItem Button_Delete;
        protected ButtonItem Button_Save;
        protected ButtonItem Button_Add;
        protected LabelItem labelItem2;
        private SuperTabControl superTabControl_Main2;
        protected LabelItem labelItem1;
        protected ButtonItem Button_First;
        protected ButtonItem Button_Prev;
        protected TextBoxItem TextBox_Index;
        protected LabelItem Label_Count;
        protected ButtonItem Button_Next;
        protected ButtonItem Button_Last;
        protected ButtonItem buttonItem_Print;
        protected SuperGridControl DGV_Main;
        private RibbonBar ribbonBar_DGV;
        private SuperTabControl superTabControl_DGV;
        protected TextBoxItem textBox_search;
        protected ButtonItem Button_ExportTable2;
        protected LabelItem labelItem3;
        private DoubleInput txtBalance;
        private DoubleInput txtTotalCredit;
        private DoubleInput txtTotalDebit;
        private LabelItem lable_Records;
        private MaskedTextBox txtGDate;
        private MaskedTextBox txtHDate;
        protected ButtonItem Button_PrintTable;
        private SwitchButton switchButton_Lock;
        internal Label label_LockeName;
        private TextBox txtFatherAccName;
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
        private long T1;
        private long T2;
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
        private T_AccDef _AccFather = new T_AccDef();
        private int iiRntP = 0;
        private int _page = 1;
        private bool RepetitionSts = false;
        private bool ReverseSts = false;
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
                SetData(data_this);
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
                    try
                    {
                        IfAdd = false;
                        CanEdit = false;
                        IfDelete = false;
                    }
                    catch
                    {
                    }
                }
                if (!VarGeneral.TString.ChkStatShow(Permmission.RepInv1, 0))
                {
                    switchButton_Lock.IsReadOnly = true;
                }
                else
                {
                    try
                    {
                        if (data_this == null || string.IsNullOrEmpty(data_this.gdNo))
                        {
                            switchButton_Lock.IsReadOnly = false;
                        }
                        else if (!string.IsNullOrEmpty(data_this.MODIFIED_BY))
                        {
                            if (VarGeneral.UserNumber.Trim() != data_this.MODIFIED_BY.Trim() && switchButton_Lock.Value && State != FormState.Edit)
                            {
                                switchButton_Lock.IsReadOnly = true;
                            }
                            else
                            {
                                switchButton_Lock.IsReadOnly = false;
                            }
                        }
                        else
                        {
                            switchButton_Lock.IsReadOnly = false;
                        }
                    }
                    catch
                    {
                        switchButton_Lock.IsReadOnly = false;
                    }
                }
                if (VarGeneral.vDemo)
                {
                    IfDelete = false;
                }
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
        public void RefreshPKeys()
        {
            PKeys.Clear();
            try
            {
                PKeys = db.ExecuteQuery<string>("select gdNo from T_GDHEAD where gdTyp =" + VarGeneral.InvTyp + " and gdLok = 0 and ChekNo ='" + VarGeneral.EmpGaidTyp + "'", new object[0]).ToList();
            }
            catch
            {
                PKeys.Clear();
            }
            int count = 0;
            count = PKeys.Count;
            Label_Count.Text = string.Concat(count);
            UpdateVcr();
        }
        public void Fill_DGV_Main()
        {
            T1 = DateTime.Now.Ticks;
            DGV_Main.PrimaryGrid.VirtualMode = true;
            Stock_DataDataContext db = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_GDHEAD> list = db.FillGDHEADEmpRelay_3(VarGeneral.InvTyp, textBox_search.TextBox.Text).ToList();
            DGV_Main.PrimaryGrid.VirtualRowCount = list.Count;
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                }
            }
            FillHDGV(list);
        }
        public FMJournalVoucherEmpRelaySal()
        {
            InitializeComponent();this.Load += langloads;
            ADD_Controls();
            textBox_ID.Click += Button_Edit_Click;
            txtAccName.Click += Button_Edit_Click;
            txtBalance.Click += Button_Edit_Click;
            textBox_Type.Click += Button_Edit_Click;
            txtGDate.Click += Button_Edit_Click;
            txtHDate.Click += Button_Edit_Click;
            txtRef.Click += Button_Edit_Click;
            txtRemark.Click += Button_Edit_Click;
            txtTotalCredit.Click += Button_Edit_Click;
            txtTotalDebit.Click += Button_Edit_Click;
            CmbCostC.Click += Button_Edit_Click;
            CmbCurr.Click += Button_Edit_Click;
            CmbLegate.Click += Button_Edit_Click;
            expandableSplitter1.Click += expandableSplitter1_Click;
            ToolStripMenuItem_Det.Click += ToolStripMenuItem_Det_Click;
            Button_ExportTable2.Click += Button_ExportTable2_Click;
            textBox_search.InputTextChanged += TextBox_Search_InputTextChanged;
            textBox_search.ButtonCustomClick += TextBox_Search_ButtonCustomClick;
            TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
            Button_Close.Click += Button_Close_Click;
            Button_First.Click += Button_First_Click;
            Button_Prev.Click += Button_Prevouse_Click;
            Button_Next.Click += Button_Next_Click;
            Button_Last.Click += Button_Last_Click;
            Button_Add.Click += Button_Add_Click;
            Button_Search.Click += Button_Search_Click;
            Button_Delete.Click += Button_Delete_Click;
            Button_Save.Click += Button_Save_Click;
            TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
            expandableSplitter1.Click += expandableSplitter1_Click;
            DGV_Main.PrimaryGrid.CheckBoxes = false;
            DGV_Main.PrimaryGrid.ShowCheckBox = false;
            DGV_Main.PrimaryGrid.ShowTreeButton = true;
            DGV_Main.PrimaryGrid.ShowTreeButtons = true;
            DGV_Main.PrimaryGrid.ShowTreeLines = true;
            DGV_Main.PrimaryGrid.ShowRowGridIndex = true;
            DGV_Main.PrimaryGrid.RowHeaderWidth = 25;
            DGV_Main.DataBindingComplete += DGV_Main_DataBindingComplete;
            DGV_Main.CellClick += DGV_Main_CellClick;
            DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
            DGV_Main.GetCellStyle += DGV_MainGetCellStyle;
            DGV_Main.MouseDown += DGV_Main_MouseDown;
            textBox_ID.TextChanged += textBox_ID_TextChanged;
            textBox_ID.Click += textBox_ID_Click;
            txtHDate.Click += txtHDate_Click;
            txtHDate.Leave += txtHDate_Leave;
            txtGDate.Click += txtGDate_Click;
            txtGDate.Leave += txtGDate_Leave;
            c1FlexGrid1.Click += c1FlexGrid1_Click;
            c1FlexGrid1.AfterEdit += c1FlexGrid1_AfterEdit;
            c1FlexGrid1.AfterRowColChange += c1FlexGrid1_AfterRowColChange;
            c1FlexGrid1.KeyDown += c1FlexGrid1_KeyDown;
            c1FlexGrid1.MouseDown += c1FlexGrid1_MouseDown;
            c1FlexGrid1.RowColChange += c1FlexGrid1_RowColChange;
            buttonItem_Print.Click += buttonItem_Print_Click;
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
                        object u = hKey.GetValue("vCoCe");
                        if (string.IsNullOrEmpty(u.ToString()))
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
                txtTotalDebit.DisplayFormat = VarGeneral.DicemalMask;
                txtTotalCredit.DisplayFormat = VarGeneral.DicemalMask;
                txtBalance.DisplayFormat = VarGeneral.DicemalMask;
            }
        }
        public void buttonItem_Print_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(textBox_ID.Text != "") || State != 0)
                {
                    return;
                }
                if (_InvSetting.InvpRINTERInfo.nTyp.Substring(0, 1) == "1")
                {
                    RepShow _RepShow = new RepShow();
                    _RepShow.Tables = "T_GDDET LEFT OUTER JOIN T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID LEFT OUTER JOIN T_INVSETTING ON T_GDHEAD.gdTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_GDHEAD.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_GDHEAD.gdCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_GDHEAD.gdMnd = T_Mndob.Mnd_ID LEFT OUTER JOIN T_AccDef ON T_GDDET.AccNo = T_AccDef.AccDef_No LEFT OUTER JOIN T_SYSSETTING ON T_GDHEAD.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                    string Fields = " CASE WHEN T_GDDET.gdValue > 0 THEN T_GDDET.gdValue ELSE 0 END as DebitBala , CASE WHEN T_GDDET.gdValue < 0 THEN Abs(T_GDDET.gdValue) ELSE 0 END as CreditBala , T_Curency.Arb_Des as Arb_Cur , T_Curency.Eng_Des as Eng_Cur, T_Curency.Rate , " + ((LangArEn == 0) ? " T_CstTbl.Arb_Des as CostCenteNm " : "T_CstTbl.Eng_Des as CostCenteNm") + " , T_Mndob.Arb_Des as MndNm , T_GDHEAD.* , T_GDDET.AccNo as AccDef_No," + ((LangArEn == 0) ? "T_AccDef.Arb_Des as AccDefNm" : "T_AccDef.Eng_Des as AccDefNm") + "," + ((LangArEn == 0) ? " T_GDDET.gdDes as gdDesDet " : " T_GDDET.gdDesE as gdDesDet ") + ",T_SYSSETTING.LogImg";
                    VarGeneral.HeaderRep[0] = Text;
                    VarGeneral.HeaderRep[1] = "";
                    VarGeneral.HeaderRep[2] = "";
                    _RepShow.Rule = " where T_GDHEAD.gdhead_ID = " + data_this.gdhead_ID + " Order by T_GDDET.Lin ";
                    _RepShow.Fields = Fields;
                    try
                    {
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                    {
                        try
                        {
                            FrmReportsViewer frm = new FrmReportsViewer();
                            frm.Repvalue = "RepGaid";
                            frm.Tag = LangArEn;
                            frm.Repvalue = "RepGaid";
                            VarGeneral.vTitle = Text;
                            VarGeneral.CostCenterlbl = label15.Text.Replace(" :", "");
                            VarGeneral.Mndoblbl = label18.Text.Replace(" :", "");
                            frm.TopMost = true;
                            frm.ShowDialog();
                        }
                        catch (Exception error2)
                        {
                            VarGeneral.DebLog.writeLog("buttonItem_Print_Click:", error2, enable: true);
                            MessageBox.Show(error2.Message);
                        }
                    }
                }
                else
                {
                    PrintSet();
                    prnt_doc.Print();
                }
            }
            catch (Exception error2)
            {
                MessageBox.Show((LangArEn == 0) ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                VarGeneral.DebLog.writeLog("buttonItem_Print_Click:", error2, enable: true);
                MessageBox.Show(error2.Message);
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
            if (_InvSetting.Orientation == 1)
            {
                prnt_doc.PrinterSettings.DefaultPageSettings.Landscape = false;
            }
            else
            {
                prnt_doc.PrinterSettings.DefaultPageSettings.Landscape = true;
            }
        }
        private void DGV_MainGetCellStyle(object sender, GridGetCellStyleEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            if (panel.DataMember.Equals("HISale") && e.GridCell.GridColumn.Name.Equals("Date"))
            {
                DateTime dt = default(DateTime);
                dt = Convert.ToDateTime(e.GridCell.Value);
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
        public void FillHDGV(IEnumerable<T_GDHEAD> new_data_enum)
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
                    DGV_Main.PrimaryGrid.Columns[i].MinimumWidth = 90;
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
            DGV_Main.PrimaryGrid.DataMember = "T_GDHEAD";
        }
        public void FillHDGVQ(IQueryable new_data_enum)
        {
            SetReadOnly = true;
            DGV_Main.PrimaryGrid.DataSource = new_data_enum;
            DGV_Main.PrimaryGrid.DataMember = "T_GDHEAD";
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
                DGV_Main.PrimaryGrid.Columns[name].MinimumWidth = 100;
                DGV_Main.PrimaryGrid.Columns[name].HeaderText = ((LangArEn == 0) ? columns_Names_visible[name].AText : columns_Names_visible[name].EText);
            }
            DGV_Main.PrimaryGrid.Columns[name].Visible = (sender as ToolStripMenuItem).Checked;
            for (int i = 0; i < DGV_Main.PrimaryGrid.Rows.Count; i++)
            {
                DGV_Main.PrimaryGrid.Rows[i].GridPanel.CheckBoxes = true;
            }
            try
            {
                DGV_Main.PrimaryGrid.SetSelectedCells(1, 0, 1, 1, selected: true);
            }
            catch
            {
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
        public void Button_First_Click(object sender, EventArgs e)
        {
            if (ContinueIfEditOrNew())
            {
                TextBox_Index.TextBox.Text = string.Concat(1);
                UpdateVcr();
            }
        }
        public void Button_Prevouse_Click(object sender, EventArgs e)
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
        public bool CheckNotificationMassage()
        {
            return false;
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
        public void expandableSplitter1_Click(object sender, EventArgs e)
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
        private void Button_ExportTable2_Click(object sender, EventArgs e)
        {
            try
            {
                ExportExcel.ExportToExcel(DGV_Main, "تقرير سندات القيد اليومية");
            }
            catch
            {
            }
        }
        private void TextBox_Search_ButtonCustomClick(object sender, EventArgs e)
        {
            textBox_search.Text = "";
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
            VarGeneral.SFrmTyp = "T_Gaid3";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                textBox_ID.Text = frm.SerachNo.ToString();
            }
        }
        private void DGV_Main_AfterCheck(object sender, GridAfterCheckEventArgs e)
        {
            DGV_Main.PrimaryGrid.VirtualMode = false;
            GridRow crow = e.Item as GridRow;
            if (crow != null && crow.Checked)
            {
                GridPanel panel = new GridPanel();
                var q = db.StockGDHEAD(VarGeneral.InvTyp, crow.Cells["gdNo"].Value.ToString()).T_GDDETs.Select((T_GDDET item) => new
                {
                    item.gdNo,
                    item.gdDes,
                    item.gdDesE,
                    item.AccNo,
                    item.AccName,
                    item.gdValue
                });
                panel.DataSource = q.ToList();
                panel.DataMember = "Line";
                crow.Rows.Add(panel);
                crow.SuperGrid.DataBindingComplete += DGV_Main_DataBindingComplete;
                panel.EnsureVisible(center: true);
            }
            else
            {
                crow?.Rows.Clear();
            }
        }
        private void DGV_Main_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            switch (panel.DataMember)
            {
                case "T_GDHEAD":
                    PropHIOfferPanel(panel);
                    break;
                case "Line":
                    PropLOfferPanel(panel);
                    break;
            }
            T2 = DateTime.Now.Ticks;
        }
        private void PropHIOfferPanel(GridPanel panel)
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
            panel.Columns["gdUser"].Width = 220;
            panel.Columns["gdUser"].Visible = columns_Names_visible["gdUser"].IfDefault;
            panel.Columns["gdUserNam"].Width = 220;
            panel.Columns["gdUserNam"].Visible = columns_Names_visible["gdUserNam"].IfDefault;
            panel.Columns["gdNo"].Width = 150;
            panel.Columns["gdNo"].Visible = columns_Names_visible["gdNo"].IfDefault;
            panel.Columns["gdCstNo"].Width = 100;
            panel.Columns["gdCstNo"].Visible = columns_Names_visible["gdCstNo"].IfDefault;
            panel.Columns["gdHDate"].Width = 120;
            panel.Columns["gdHDate"].Visible = columns_Names_visible["gdHDate"].IfDefault;
            panel.Columns["gdGDate"].Width = 120;
            panel.Columns["gdGDate"].Visible = columns_Names_visible["gdGDate"].IfDefault;
            panel.Columns["gdMem"].Width = 250;
            panel.Columns["gdMem"].Visible = columns_Names_visible["gdMem"].IfDefault;
            panel.Columns["gdTot"].Width = 100;
            panel.Columns["gdTot"].Visible = columns_Names_visible["gdTot"].IfDefault;
            panel.Columns["RefNo"].Width = 120;
            panel.Columns["RefNo"].Visible = columns_Names_visible["RefNo"].IfDefault;
            panel.ReadOnly = true;
        }
        private void PropLOfferPanel(GridPanel panel)
        {
            panel.ColumnAutoSizeMode = ColumnAutoSizeMode.DisplayedCells;
            panel.Columns["gdNo"].HeaderText = ((LangArEn == 0) ? "رقم القيد" : "Gaid No");
            panel.Columns["gdDes"].HeaderText = ((LangArEn == 0) ? "الوصف عربي " : "Description Ar");
            panel.Columns["gdDesE"].HeaderText = ((LangArEn == 0) ? "الوصف إنجليزي " : "Description En");
            panel.Columns["AccNo"].HeaderText = ((LangArEn == 0) ? "رقم الحساب" : "Acc No");
            panel.Columns["AccName"].HeaderText = ((LangArEn == 0) ? "اسم الحساب" : "Acc Name");
            panel.Columns["gdValue"].HeaderText = ((LangArEn == 0) ? "القيمة" : "Value");
            panel.Footer.Text = ((LangArEn == 0) ? "عدد الاسطر: " : "Lines Count: ") + panel.Rows.Count;
            panel.ReadOnly = true;
            panel.ShowRowDirtyMarker = true;
            panel.ColumnHeader.RowHeight = 30;
            for (int i = 0; i < panel.Columns.Count; i++)
            {
                panel.Columns[i].AutoSizeMode = ColumnAutoSizeMode.AllCells;
            }
            panel.Columns[1].Width = 160;
            panel.Columns[2].Width = 300;
            panel.DefaultVisualStyles.CaptionStyles.Default.Alignment = Alignment.MiddleCenter;
            panel.DefaultVisualStyles.CellStyles.Default.Alignment = Alignment.MiddleCenter;
            panel.GroupByRow.Visible = false;
            panel.AllowEdit = false;
            panel.CheckBoxes = false;
            panel.ShowCheckBox = false;
            panel.ShowRowGridIndex = true;
        }
        private void DateTimePicker_Search_From_ValueChanged(object sender, EventArgs e)
        {
            Fill_DGV_Main();
        }
        private void TextBox_Search_InputTextChanged(object sender)
        {
            Fill_DGV_Main();
        }
        private void Button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                textBox_ID.Focus();
                if (SaveData())
                {
                    State = FormState.Saved;
                    RefreshPKeys();
                    TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(data_this.gdNo ?? "") + 1);
                    dbInstance = null;
                    textBox_ID_TextChanged(sender, e);
                    SetReadOnly = true;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Button_Save_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void Button_Delete_Click(object sender, EventArgs e)
        {
            if (!Button_Delete.Enabled || !Button_Delete.Visible || State != 0)
            {
                ifOkDelete = false;
                return;
            }
            string Code = "???";
            if (codeControl != null)
            {
                Code = codeControl.Text;
            }
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
            if (data_this != null && !(data_this.gdNo == 0.ToString()) && ifOkDelete)
            {
                data_this = db.StockGDHEAD(VarGeneral.InvTyp, data_this.gdNo);
                IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
                try
                {
                    db_ = Database.GetDatabase(VarGeneral.BranchCS);
                    db_.StartTransaction();
                    db_.ClearParameters();
                    db_.AddParameter("gdhead_ID", DbType.Int32, data_this.gdhead_ID);
                    db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDHEAD_DELETE");
                    db_.EndTransaction();
                }
                catch (SqlException)
                {
                    data_this = db.StockGDHEAD(VarGeneral.InvTyp, data_this.gdNo);
                    return;
                }
                catch (Exception)
                {
                    data_this = db.StockGDHEAD(VarGeneral.InvTyp, data_this.gdNo);
                    return;
                }
                Clear();
                RefreshPKeys();
                textBox_ID.Text = PKeys.LastOrDefault();
            }
        }
        private void Button_Add_Click(object sender, EventArgs e)
        {
            if (!Button_Add.Visible || !Button_Add.Enabled)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (State != FormState.Edit || MessageBox.Show((LangArEn == 0) ? "تم تعديل السجل الحالي دون حفظ التغييرات .. هل تريد المتابعة؟" : "Not saved the changes, do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Clear();
                txtGDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                txtHDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                GetInvSetting();
                textBox_ID.Text = db.MaxGDHEADsNo.ToString();
                c1FlexGrid1.Rows.Count = c1FlexGrid1.Rows.Count + 100;
                textBox_ID.Focus();
                State = FormState.New;
                try
                {
                    base.ActiveControl = c1FlexGrid1;
                    c1FlexGrid1.Row = 1;
                    c1FlexGrid1.Col = 1;
                }
                catch
                {
                }
            }
        }
        private void Button_Edit_Click(object sender, EventArgs e)
        {
            if (CanEdit && State != FormState.Edit && State != FormState.New && !string.IsNullOrEmpty(textBox_ID.Text))
            {
                if (State != FormState.New)
                {
                    State = FormState.Edit;
                }
                c1FlexGrid1.Rows.Count = c1FlexGrid1.Rows.Count + 100;
                SetReadOnly = false;
            }
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
            if (c1FlexGrid1.Rows.Count <= 1)
            {
                c1FlexGrid1.Rows.Count = 100;
            }
            else
            {
                c1FlexGrid1.Clear(ClearFlags.Content, 1, 1, c1FlexGrid1.Rows.Count - 1, 7);
            }
            switchButton_Lock.Value = false;
            label_LockeName.Text = ((LangArEn == 0) ? "غير مقف\u0651ــلة" : "Unlocked");
            SetReadOnly = false;
        }
        private bool ValidData()
        {
            if (textBox_ID.Text == "0" || textBox_ID.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ بدون رقم الفاتورة - السند" : "Can not save without the invoice number", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            try
            {
                c1FlexGrid1_AfterRowColChange(null, new RangeEventArgs(default(CellRange), default(CellRange)));
            }
            catch
            {
            }
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
            {
                if (Math.Round(txtTotalCredit.Value, 3) != Math.Round(txtTotalDebit.Value, 3))
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام العملية .. تاكد من ان إجمالي الدائن يساوي اجمالي المدين" : "You can not complete the process .. make sure that the total equals the total creditor debtor", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
            }
            else if (Math.Round(txtTotalCredit.Value, 2) != Math.Round(txtTotalDebit.Value, 2))
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام العملية .. تاكد من ان إجمالي الدائن يساوي اجمالي المدين" : "You can not complete the process .. make sure that the total equals the total creditor debtor", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (txtTotalCredit.Value == 0.0 || txtTotalDebit.Value == 0.0 || txtTotalCredit.Value == 0.0 || txtTotalDebit.Value == 0.0 || txtTotalCredit.Value == 0.0 || txtTotalDebit.Value == 0.0)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ والصافي يساوي صفر" : "Can not save, and the total is equal to zero", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            for (int iiCnt = 1; iiCnt < c1FlexGrid1.Rows.Count; iiCnt++)
            {
                if (!(string.Concat(c1FlexGrid1.GetData(iiCnt, 1)) != ""))
                {
                    continue;
                }
                for (int i = 1; i < c1FlexGrid1.Cols.Count; i++)
                {
                    if (string.Concat(c1FlexGrid1.GetData(iiCnt, i)) == "")
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من تعبئة جميع البيانات المطلوبة" : "We must not be empty value .. Please make sure there are items in the bill.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        c1FlexGrid1.Row = iiCnt;
                        c1FlexGrid1.Col = i;
                        c1FlexGrid1.Focus();
                        return false;
                    }
                    try
                    {
                        if (double.Parse(VarGeneral.TString.TEmpty(c1FlexGrid1.GetData(iiCnt, 6).ToString())) <= 0.0 && double.Parse(VarGeneral.TString.TEmpty(c1FlexGrid1.GetData(iiCnt, 7).ToString())) <= 0.0)
                        {
                            MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من تعبئة جميع البيانات المطلوبة" : "We must not be empty value .. Please make sure there are items in the bill.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            c1FlexGrid1.Row = iiCnt;
                            c1FlexGrid1.Col = i;
                            c1FlexGrid1.Focus();
                            return false;
                        }
                    }
                    catch
                    {
                    }
                }
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
        private bool CheckRemotDate()
        {
            try
            {
                if (VarGeneral.gUserName != "runsetting")
                {
                    bool User_Remotly = CheckUserIFRemote();
                    RegistryKey hKeyNew = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", writable: true);
                    RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
                    long regval = 0L;
                    long regvalNew = 0L;
                    if (hKey != null)
                    {
                        try
                        {
                            object q = hKey.GetValue("vRemotly");
                            if (string.IsNullOrEmpty(q.ToString()))
                            {
                                hKey.CreateSubKey("vRemotly");
                                hKey.SetValue("vRemotly", "0");
                            }
                        }
                        catch
                        {
                            hKey.CreateSubKey("vRemotly");
                            hKey.SetValue("vRemotly", "0");
                        }
                        try
                        {
                            object t = hKeyNew.GetValue("vRemotly_New");
                            if (string.IsNullOrEmpty(t.ToString()))
                            {
                                hKeyNew.CreateSubKey("vRemotly_New");
                                hKeyNew.SetValue("vRemotly_New", "0");
                            }
                        }
                        catch
                        {
                            hKeyNew.CreateSubKey("vRemotly_New");
                            hKeyNew.SetValue("vRemotly_New", "0");
                        }
                        regval = long.Parse(hKey.GetValue("vRemotly").ToString());
                        regvalNew = long.Parse(hKeyNew.GetValue("vRemotly_New").ToString());
                    }
                    if (User_Remotly || regval == 1 || regvalNew == 1)
                    {
                        try
                        {
                            if (VarGeneral.vDemo)
                            {
                                return false;
                            }
                            try
                            {
                                if (Convert.ToDateTime(n.GregToHijri(hKeyNew.GetValue("vBackup_New").ToString(), "yyyy/MM/dd")) < Convert.ToDateTime(n.FormatHijri(txtHDate.Text, "yyyy/MM/dd")))
                                {
                                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. لقد تخطيت السنة المالية المحدد للنظام \n يرجى التواصل مع الإدارة لللإشتراك في خدمات النسخة " : "We can not complete the operation .. have you skip the fiscal year specified for the system", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    return false;
                                }
                            }
                            catch
                            {
                                if (Convert.ToDateTime(n.FormatGreg(hKeyNew.GetValue("vBackup_New").ToString(), "yyyy/MM/dd")) < Convert.ToDateTime(n.FormatGreg(txtGDate.Text, "yyyy/MM/dd")))
                                {
                                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. لقد تخطيت السنة المالية المحدد للنظام \n يرجى التواصل مع الإدارة لللإشتراك في خدمات النسخة " : "We can not complete the operation .. have you skip the fiscal year specified for the system", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    return false;
                                }
                            }
                        }
                        catch
                        {
                            MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. لقد تخطيت السنة المالية المحدد للنظام \n يرجى التواصل مع الإدارة لللإشتراك في خدمات النسخة " : "We can not complete the operation .. have you skip the fiscal year specified for the system", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return false;
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        private bool CheckUserIFRemote()
        {
            try
            {
#pragma warning disable CS0162 // Unreachable code detected
               return false; if (SystemInformation.TerminalServerSession)
#pragma warning restore CS0162 // Unreachable code detected
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return true;
            }
        }
        private T_GDHEAD GetData()
        {
            data_this.gdHDate = txtHDate.Text;
            data_this.gdGDate = txtGDate.Text;
            data_this.gdNo = textBox_ID.Text;
            data_this.BName = data_this.BName;
            data_this.ChekNo = data_this.ChekNo;
            data_this.CurTyp = int.Parse(CmbCurr.SelectedValue.ToString());
            data_this.ArbTaf = ScriptNumber1.ScriptNum(decimal.Parse(VarGeneral.TString.TEmpty(string.Concat(txtTotalCredit.Value))));
            data_this.EngTaf = ScriptNumber1.TafEng(decimal.Parse(VarGeneral.TString.TEmpty(string.Concat(txtTotalCredit.Value))));
            data_this.gdCstNo = int.Parse(CmbCostC.SelectedValue.ToString());
            data_this.gdID = 0;
            data_this.gdLok = false;
            data_this.gdMem = txtRemark.Text;
            if (State == FormState.New && VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 10))
            {
                data_this.AdminLock = true;
            }
            else
            {
                data_this.AdminLock = switchButton_Lock.Value;
            }
            if (CmbLegate.SelectedIndex > 0)
            {
                data_this.gdMnd = int.Parse(CmbLegate.SelectedValue.ToString());
            }
            else
            {
                data_this.gdMnd = null;
            }
            data_this.gdRcptID = (data_this.gdRcptID.HasValue ? data_this.gdRcptID.Value : 0.0);
            data_this.gdTot = txtTotalCredit.Value;
            data_this.gdTp = (data_this.gdTp.HasValue ? data_this.gdTp.Value : 0);
            data_this.gdTyp = 16;
            data_this.RefNo = txtRef.Text;
            data_this.salMonth = "";
            try
            {
                if (CmbLegate.SelectedIndex != -1)
                {
                    T_Mndob q = db.StockMndobID(int.Parse(CmbLegate.SelectedValue.ToString()));
                    if (q.Comm_Gaid.Value > 0.0 && txtTotalCredit.Value > 0.0)
                    {
                        data_this.CommMnd_Gaid = txtTotalCredit.Value * (q.Comm_Gaid.Value / 100.0);
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
        public void SetData(T_GDHEAD value)
        {
            switchButton_Lock.ValueChanged -= switchButton_Lock_ValueChanged;
            try
            {
                if (!RepetitionSts && !ReverseSts)
                {
                    State = FormState.Saved;
                    Button_Save.Enabled = false;
                    textBox_ID.Tag = value.gdhead_ID;
                    if (VarGeneral.CheckDate(value.gdGDate))
                    {
                        txtGDate.Text = Convert.ToDateTime(value.gdGDate).ToString("yyyy/MM/dd");
                    }
                    if (VarGeneral.CheckDate(value.gdHDate))
                    {
                        txtHDate.Text = Convert.ToDateTime(value.gdHDate).ToString("yyyy/MM/dd");
                    }
                    textBox_ID.Text = value.gdNo.Trim();
                }
                txtRef.Text = value.RefNo.Trim();
                txtRemark.Text = value.gdMem;
                txtTotalCredit.Value = value.gdTot.Value;
                txtTotalDebit.Value = value.gdTot.Value;
                if (!RepetitionSts && !ReverseSts)
                {
                    switchButton_Lock.Value = value.AdminLock.Value;
                    try
                    {
                        if (data_this.AdminLock.HasValue)
                        {
                            if (!data_this.AdminLock.Value)
                            {
                                label_LockeName.Text = ((LangArEn == 0) ? "غير مقف\u0651ــلة" : "Unlocked");
                            }
                            else
                            {
                                label_LockeName.Text = ((LangArEn == 0) ? ("أقفلها المسؤول : \n" + dbc.RateUsr(data_this.MODIFIED_BY).UsrNamA) : ("Closed By :\n" + dbc.RateUsr(data_this.MODIFIED_BY).UsrNamE));
                            }
                        }
                        else
                        {
                            label_LockeName.Text = ((LangArEn == 0) ? "غير مقف\u0651ــلة" : "Unlocked");
                        }
                    }
                    catch
                    {
                        label_LockeName.Text = ((LangArEn == 0) ? "غير مقف\u0651ــلة" : "Unlocked");
                    }
                }
                for (int iiCnt = 0; iiCnt < CmbCostC.Items.Count; iiCnt++)
                {
                    CmbCostC.SelectedIndex = iiCnt;
                    if (CmbCostC.SelectedValue != null && CmbCostC.SelectedValue.ToString() == value.gdCstNo.ToString().Trim())
                    {
                        break;
                    }
                }
                for (int iiCnt = 0; iiCnt < CmbCurr.Items.Count; iiCnt++)
                {
                    CmbCurr.SelectedIndex = iiCnt;
                    if (CmbCurr.SelectedValue != null && CmbCurr.SelectedValue.ToString() == value.CurTyp.Value.ToString())
                    {
                        break;
                    }
                }
                if (value.gdMnd.HasValue)
                {
                    CmbLegate.SelectedValue = value.gdMnd;
                }
                else
                {
                    CmbLegate.SelectedIndex = 0;
                }
                LDataThis = new BindingList<T_GDDET>(value.T_GDDETs).OrderBy((T_GDDET g) => g.Lin.Value).ToList();
                SetLines(LDataThis);
                Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
                if (!RepetitionSts && !ReverseSts)
                {
                    try
                    {
                        List<T_Sal> returned3 = db.SelectSalsReturnNo(DataThis.gdhead_ID).ToList();
                        if (returned3.Count > 0)
                        {
                            CanEdit = false;
                            IfDelete = false;
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        List<T_Advance> returned2 = db.SelectAdvanceReturnNo(DataThis.gdhead_ID).ToList();
                        if (returned2.Count > 0)
                        {
                            CanEdit = false;
                            IfDelete = false;
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        List<T_Salary> returned = db.SelectSalaryReturnNo(DataThis.gdhead_ID).ToList();
                        if (returned.Count > 0)
                        {
                            CanEdit = false;
                            IfDelete = false;
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SetData:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            switchButton_Lock.ValueChanged += switchButton_Lock_ValueChanged;
        }
        public void SetLines(List<T_GDDET> listDet)
        {
            try
            {
                T_GDDET _GdDet = new T_GDDET();
                if (!RepetitionSts && !ReverseSts)
                {
                    c1FlexGrid1.Rows.Count = listDet.Count + 1;
                }
                if (listDet.Count == 0)
                {
                    return;
                }
                for (int iiCnt = 0; iiCnt < listDet.Count; iiCnt++)
                {
                    _GdDet = listDet[iiCnt];
                    int Lin = _GdDet.Lin.Value;
                    c1FlexGrid1.SetData(Lin, 0, Lin.ToString());
                    c1FlexGrid1.SetData(Lin, 1, _GdDet.AccNo.ToString());
                    c1FlexGrid1.SetData(Lin, 2, _GdDet.T_AccDef.Arb_Des.ToString());
                    c1FlexGrid1.SetData(Lin, 3, _GdDet.T_AccDef.Eng_Des.ToString());
                    c1FlexGrid1.SetData(Lin, 4, _GdDet.gdDes.ToString());
                    c1FlexGrid1.SetData(Lin, 5, _GdDet.gdDesE.ToString());
                    if (!ReverseSts)
                    {
                        if (_GdDet.gdValue.Value > 0.0)
                        {
                            c1FlexGrid1.SetData(Lin, 6, _GdDet.gdValue.ToString());
                            c1FlexGrid1.SetData(Lin, 7, 0);
                        }
                        else
                        {
                            c1FlexGrid1.SetData(Lin, 7, Math.Abs(double.Parse(VarGeneral.TString.TEmpty(string.Concat(_GdDet.gdValue.Value)))));
                            c1FlexGrid1.SetData(Lin, 6, 0);
                        }
                    }
                    else if (_GdDet.gdValue.Value < 0.0)
                    {
                        c1FlexGrid1.SetData(Lin, 6, Math.Abs(double.Parse(VarGeneral.TString.TEmpty(string.Concat(_GdDet.gdValue.Value)))));
                        c1FlexGrid1.SetData(Lin, 7, 0);
                    }
                    else
                    {
                        c1FlexGrid1.SetData(Lin, 7, _GdDet.gdValue.Value);
                        c1FlexGrid1.SetData(Lin, 6, 0);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show((LangArEn == 0) ? "حدث خطأ أثناء تعبئة الأسطر .." : "An error occurred while filling lines ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                VarGeneral.DebLog.writeLog("SetLines:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        public void TextBox_Index_InputTextChanged(object sender)
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
        private void ArbEng()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                c1FlexGrid1.Cols[1].Caption = "رقم الحساب";
                c1FlexGrid1.Cols[2].Visible = true;
                c1FlexGrid1.Cols[3].Visible = false;
                c1FlexGrid1.Cols[4].Caption = "البيـــان - عربي";
                c1FlexGrid1.Cols[5].Caption = "البيــان - إنجليزي";
                c1FlexGrid1.Cols[6].Caption = "مــدين";
                c1FlexGrid1.Cols[7].Caption = "دائــن";
            }
            else
            {
                c1FlexGrid1.Cols[1].Caption = "Acc Name";
                c1FlexGrid1.Cols[2].Visible = false;
                c1FlexGrid1.Cols[3].Visible = true;
                c1FlexGrid1.Cols[4].Caption = "Description - Ar";
                c1FlexGrid1.Cols[5].Caption = "Description - En";
                c1FlexGrid1.Cols[6].Caption = "Debit";
                c1FlexGrid1.Cols[7].Caption = "Credit";
            }
            RibunButtons();
        }
        private void textBox_ID_TextChanged(object sender, EventArgs e)
        {
            string no = "";
            try
            {
                no = textBox_ID.Text;
            }
            catch
            {
            }
            try
            {
                T_GDHEAD newData = db.StockGDHEAD(VarGeneral.InvTyp, no);
                if (newData == null || string.IsNullOrEmpty(newData.gdNo))
                {
                    if (!Button_Add.Visible || !Button_Add.Enabled)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textBox_ID.TextChanged -= textBox_ID_TextChanged;
                        try
                        {
                            textBox_ID.Text = data_this.gdNo;
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
                    int indexA = PKeys.IndexOf(newData.gdNo ?? "");
                    indexA++;
                    TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                    TextBox_Index.TextBox.Text = string.Concat(indexA);
                    TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                }
                Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
            }
            catch
            {
            }
            UpdateVcr();
        }
        private void Button_Filter_Click(object sender, EventArgs e)
        {
            Fill_DGV_Main();
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
        private void ToolStripMenuItem_Det_Click(object sender, EventArgs e)
        {
            int rowIndex = Convert.ToInt32(DGV_Main.PrimaryGrid.Tag);
            TextBox_Index.TextBox.Text = string.Concat(rowIndex + 1);
            expandableSplitter1.Expanded = true;
            ViewDetails_Click(sender, e);
        }
        private void DGV_Main_CellMouseDown(object sender, GridCellMouseEventArgs e)
        {
            DGV_Main.PrimaryGrid.Tag = e.GridCell.RowIndex;
        }
        private void DGV_Main_CellDoubleClick(object sender, GridCellDoubleClickEventArgs e)
        {
            ToolStripMenuItem_Det_Click(sender, e);
        }
        private void DGV_Main_CellClick(object sender, GridCellClickEventArgs e)
        {
            DGV_Main.PrimaryGrid.Tag = e.GridCell.RowIndex;
        }
        private void ADD_Controls()
        {
            try
            {
                controls = new List<Control>();
                controls.Add(textBox_ID);
                codeControl = textBox_ID;
                controls.Add(textBox_Type);
                controls.Add(txtBalance);
                controls.Add(txtTotalCredit);
                controls.Add(txtTotalDebit);
                controls.Add(txtGDate);
                controls.Add(txtHDate);
                controls.Add(txtRef);
                controls.Add(txtRemark);
                controls.Add(CmbCostC);
                controls.Add(CmbCurr);
                controls.Add(CmbLegate);
                controls.Add(txtFatherAccName);
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
                        textBox_ID.TextChanged -= textBox_ID_TextChanged;
                        string max = "";
                        max = db.MaxGDHEADsNo.ToString();
                        textBox_ID.Text = max ?? "";
                        data_this.gdNo = max ?? "";
                        textBox_ID.TextChanged += textBox_ID_TextChanged;
                        data_this.DATE_CREATED = DateTime.Now;
                        data_this.gdUser = VarGeneral.UserNumber;
                        data_this.gdUserNam = VarGeneral.UserNameA;
                        data_this.MODIFIED_BY = "";
                        db.T_GDHEADs.InsertOnSubmit(data_this);
                        db.SubmitChanges();
                    }
                    catch (SqlException ex)
                    {
                        string max = "";
                        max = db.MaxGDHEADsNo.ToString();
                        if (ex.Number == 2627)
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
                    data_this.MODIFIED_BY = VarGeneral.UserNumber;
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
                int iiCnt = 0;
                db_ = Database.GetDatabase(VarGeneral.BranchCS);
                for (iiCnt = 1; iiCnt < c1FlexGrid1.Rows.Count; iiCnt++)
                {
                    try
                    {
                        if (c1FlexGrid1.GetData(iiCnt, 1) != null)
                        {
                            db_.StartTransaction();
                            db_.ClearParameters();
                            db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                            db_.AddParameter("gdID", DbType.Int32, data_this.gdhead_ID);
                            db_.AddParameter("gdNo", DbType.String, textBox_ID.Text);
                            db_.AddParameter("gdDes", DbType.String, c1FlexGrid1.GetData(iiCnt, 4).ToString());
                            try
                            {
                                db_.AddParameter("gdDesE", DbType.String, c1FlexGrid1.GetData(iiCnt, 5).ToString());
                            }
                            catch
                            {
                                db_.AddParameter("gdDesE", DbType.String, " ");
                            }
                            db_.AddParameter("recptTyp", DbType.String, "16");
                            db_.AddParameter("AccNo", DbType.String, c1FlexGrid1.GetData(iiCnt, 1).ToString());
                            db_.AddParameter("AccName", DbType.String, c1FlexGrid1.GetData(iiCnt, 2).ToString());
                            if (double.Parse(c1FlexGrid1.GetData(iiCnt, 6).ToString()) > 0.0)
                            {
                                db_.AddParameter("gdValue", DbType.Double, double.Parse(c1FlexGrid1.GetData(iiCnt, 6).ToString()));
                            }
                            else if (double.Parse(c1FlexGrid1.GetData(iiCnt, 7).ToString()) > 0.0)
                            {
                                db_.AddParameter("gdValue", DbType.Double, 0.0 - double.Parse(c1FlexGrid1.GetData(iiCnt, 7).ToString()));
                            }
                            db_.AddParameter("recptNo", DbType.String, textBox_ID.Text);
                            db_.AddParameter("Lin", DbType.Int32, iiCnt);
                            db_.AddParameter("AccNoDestruction", DbType.String, null);
                            db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                            db_.EndTransaction();
                        }
                    }
                    catch
                    {
                    }
                }
                dbInstance = null;
                textBox_ID_TextChanged(null, null);
                MessageBox.Show((LangArEn == 0) ? "تمت عملية حفظ البيانات بنجاح .." : "Save Data Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                try
                {
                    Stock_DataDataContext stock_DataDataContext = new Stock_DataDataContext(VarGeneral.BranchCS);
                    List<T_GDDET> q = (from t in stock_DataDataContext.T_GDDETs
                                       where t.gdNo == data_this.gdNo
                                       where t.T_GDHEAD.gdTyp == (int?)VarGeneral.InvTyp
                                       select t).ToList();
                    if (q.Count <= 0)
                    {
                        stock_DataDataContext.ExecuteCommand("DELETE FROM [T_GDHEAD] WHERE gdNo = '" + data_this.gdNo + "' and gdTyp =" + VarGeneral.InvTyp);
                        textBox_ID_TextChanged(null, null);
                    }
                }
                catch
                {
                }
            }
            catch (Exception ex3)
            {
                try
                {
                    Stock_DataDataContext stock_DataDataContext = new Stock_DataDataContext(VarGeneral.BranchCS);
                    List<T_GDDET> q = (from t in stock_DataDataContext.T_GDDETs
                                       where t.gdNo == data_this.gdNo
                                       where t.T_GDHEAD.gdTyp == (int?)VarGeneral.InvTyp
                                       select t).ToList();
                    if (q.Count <= 0)
                    {
                        stock_DataDataContext.ExecuteCommand("DELETE FROM [T_GDHEAD] WHERE gdNo = '" + data_this.gdNo + "' and gdTyp =" + VarGeneral.InvTyp);
                        textBox_ID_TextChanged(null, null);
                    }
                }
                catch
                {
                }
                MessageBox.Show(ex3.Message);
                VarGeneral.DebLog.writeLog("SaveData:", ex3, enable: true);
                return false;
            }
            return true;
        }
        private void txtHDate_Click(object sender, EventArgs e)
        {
            txtHDate.SelectAll();
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FMJournalVoucherEmpRelaySal));
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
            ArbEng();
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
                buttonItem_Print.Text = ((_InvSetting.InvpRINTERInfo.nTyp.Substring(2, 1) == "1") ? "طباعة" : "عــرض");
                buttonItem_Print.Tooltip = "F5";
                Button_ExportTable2.Text = "تصدير";
                Button_ExportTable2.Tooltip = "F10";
                Button_PrintTable.Text = "عــرض";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "جميع السجلات";
                Label1.Text = "رقم السند :";
                Label2.Text = "التاريــــــــخ :";
                label7.Text = "رقم المرجع :";
                Label9.Text = "ملاحظـــات :";
                label19.Text = "العملــــــــة :";
                label18.Text = "المنـــــدوب :";
                label15.Text = "مركز التكلفـــــة :";
                label6.Text = "الحســــاب :";
                label3.Text = "قيمة المدين";
                Label21.Text = "قيمة الدائن";
                label17.Text = "الرصيد";
                switchButton_Lock.OffText = "لم يتم الموافقة";
                switchButton_Lock.OnText = "تمت الموافقة";
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
                buttonItem_Print.Text = ((_InvSetting.InvpRINTERInfo.nTyp.Substring(2, 1) == "1") ? "Print" : "Show");
                buttonItem_Print.Tooltip = "F5";
                Button_ExportTable2.Text = "Export";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "All Records";
                Button_PrintTable.Text = "Show";
                Label1.Text = "Number :";
                Label2.Text = "Date :";
                label7.Text = "Reference No :";
                Label9.Text = "Note :";
                label19.Text = "Currncy :";
                label18.Text = "Delegate :";
                label15.Text = "Cost Center :";
                label6.Text = "Account :";
                label3.Text = "Debtor";
                Label21.Text = "Creditor";
                label17.Text = "Balance";
                switchButton_Lock.OffText = "not approved";
                switchButton_Lock.OnText = "Been approved";
            }
        }
        private void FMJournalVoucherEmpRelaySal_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FMJournalVoucherEmpRelaySal));
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
                mainProcess();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FMJournalVoucherEmpRelaySal_Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            c1FlexGrid1.DrawMode = DrawModeEnum.OwnerDraw;
            c1FlexGrid1.OwnerDrawCell += _ownerDraw;
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
        private void _ownerDraw(object sender, OwnerDrawCellEventArgs e)
        {
            if (e.Col == 0 && e.Row > 0)
            {
                e.Text = e.Row.ToString();
            }
        }
        private void mainProcess()
        {
            if (columns_Names_visible.Count == 0)
            {
                columns_Names_visible.Add("gdNo", new ColumnDictinary("رقم القيد", "Gaid No", ifDefault: true, ""));
                columns_Names_visible.Add("gdHDate", new ColumnDictinary("التاريخ الهجري", "Date Hijri", ifDefault: true, ""));
                columns_Names_visible.Add("gdGDate", new ColumnDictinary("التاريخ الميلادي", "Date Gregorian", ifDefault: false, ""));
                columns_Names_visible.Add("gdCstNo", new ColumnDictinary("مركز التكلفة", "Cost Center", ifDefault: true, ""));
                columns_Names_visible.Add("gdUser", new ColumnDictinary("رقم المستخدم", "User No", ifDefault: false, ""));
                columns_Names_visible.Add("gdUserNam", new ColumnDictinary("إسم المستخدم", "User Name", ifDefault: true, ""));
                columns_Names_visible.Add("gdTot", new ColumnDictinary("القيمة", "Value", ifDefault: false, ""));
                columns_Names_visible.Add("gdMem", new ColumnDictinary("ملاحظات", "Note", ifDefault: true, ""));
                columns_Names_visible.Add("RefNo", new ColumnDictinary("رقم المرجع", "Ref No", ifDefault: false, ""));
            }
            else
            {
                Clear();
                textBox_ID.Text = "";
                TextBox_Index.TextBox.Text = "";
            }
            Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
            FillCombo();
            GetInvSetting();
            ArbEng();
            RefreshPKeys();
            textBox_ID.Text = PKeys.FirstOrDefault();
            UpdateVcr();
        }
        private void txtGDate_Enter(object sender, EventArgs e)
        {
            Framework.Keyboard.Language.Switch("English");
        }
        private void txtHDate_Enter(object sender, EventArgs e)
        {
            Framework.Keyboard.Language.Switch("Arabic");
        }
        private void c1FlexGrid1_AfterEdit(object sender, RowColEventArgs e)
        {
            if (e.Col == 1 || e.Col == 2 || e.Col == 3)
            {
                List<T_AccDef> listAccDefSer = new List<T_AccDef>();
                listAccDefSer = db.T_AccDefs.Where((T_AccDef t) => t.AccDef_ID == 0).ToList();
                if (e.Col == 1 && c1FlexGrid1.GetData(e.Row, e.Col).ToString() != "")
                {
                    listAccDefSer = (from t in db.T_AccDefs
                                     where t.AccDef_No == c1FlexGrid1.GetData(e.Row, e.Col).ToString()
                                     where t.Sts == (int?)0
                                     where t.Lev == (int?)4
                                     select t).ToList();
                }
                else if (e.Col == 2 && c1FlexGrid1.GetData(e.Row, e.Col).ToString() != "")
                {
                    listAccDefSer = (from t in db.T_AccDefs
                                     where t.Arb_Des == c1FlexGrid1.GetData(e.Row, e.Col).ToString()
                                     where t.Sts == (int?)0
                                     where t.Lev == (int?)4
                                     select t).ToList();
                }
                else if (e.Col == 3 && c1FlexGrid1.GetData(e.Row, e.Col).ToString() != "")
                {
                    listAccDefSer = (from t in db.T_AccDefs
                                     where t.Eng_Des == c1FlexGrid1.GetData(e.Row, e.Col).ToString()
                                     where t.Sts == (int?)0
                                     where t.Lev == (int?)4
                                     select t).ToList();
                }
                if (listAccDefSer.Count == 0)
                {
                    if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 31))
                    {
                        string _SearchNo = "";
                        RepShow _RepShow = new RepShow();
                        _RepShow.Tables = " T_AccDef ";
                        string Fields = "";
                        Fields = ((LangArEn != 0) ? " T_AccDef.AccDef_ID as [ID_Number], T_AccDef.AccDef_No as [No] , T_AccDef.Arb_Des as [Arabic Name], T_AccDef.Eng_Des as [English Name] " : " T_AccDef.AccDef_ID as [رقم_التعريف], T_AccDef.AccDef_No as [الرقم] , T_AccDef.Arb_Des as [الاسم عربي], T_AccDef.Eng_Des as [الاسم إنجليزي] ");
                        _RepShow.Rule = " Where 1 = 1 and T_AccDef.Lev = 4 and T_AccDef.Sts = 0 and T_AccDef.StopedState = 0";
                        if (!string.IsNullOrEmpty(Fields))
                        {
                            _RepShow.Fields = Fields;
                            _RepShow = _RepShow.Save();
                            VarGeneral.RepData = _RepShow.RepData;
                            if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                            {
                                FMFind FmQuikSerch = new FMFind((string)c1FlexGrid1.GetData(e.Row, e.Col), e.Col);
                                FmQuikSerch.Tag = LangArEn;
                                FmQuikSerch.TopMost = true;
                                FmQuikSerch.ShowDialog();
                                _SearchNo = FmQuikSerch.SerachNo;
                            }
                        }
                        if (_SearchNo != "")
                        {
                            _AccDef = db.StockAccDefs_OnlyGaid(int.Parse(_SearchNo));
                            c1FlexGrid1.SetData(e.Row, 1, _AccDef.AccDef_No.ToString());
                            c1FlexGrid1.SetData(e.Row, 2, _AccDef.Arb_Des.ToString());
                            c1FlexGrid1.SetData(e.Row, 3, _AccDef.Eng_Des.ToString());
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                            {
                                txtAccName.Text = _AccDef.Arb_Des.ToString();
                            }
                            else
                            {
                                txtAccName.Text = _AccDef.Eng_Des.ToString();
                            }
                            txtBalance.Value = _AccDef.Balance.Value;
                        }
                    }
                    else
                    {
                        columns_Names_visible2.Clear();
                        columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
                        columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
                        columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
                        columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
                        columns_Names_visible2.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, ""));
                        columns_Names_visible2.Add("TaxNo", new ColumnDictinary("الرقم الضريبي", "Tax No", ifDefault: false, ""));
                        FrmSearch frm = new FrmSearch();
                        frm.Tag = LangArEn;
                        ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
                        foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                        {
                            frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                        }
                        VarGeneral.SFrmTyp = "AccDefID_Setting";
                        VarGeneral.itmDes = (string)c1FlexGrid1.GetData(e.Row, e.Col);
                        VarGeneral.itmDesIndex = e.Col;
                        frm.TopMost = true;
                        frm.ShowDialog();
                        if (frm.SerachNo != "")
                        {
                            _AccDef = db.StockAccDefs_OnlyGaid(int.Parse(frm.Serach_No));
                            c1FlexGrid1.SetData(e.Row, 1, _AccDef.AccDef_No.ToString());
                            c1FlexGrid1.SetData(e.Row, 2, _AccDef.Arb_Des.ToString());
                            c1FlexGrid1.SetData(e.Row, 3, _AccDef.Eng_Des.ToString());
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                            {
                                txtAccName.Text = _AccDef.Arb_Des.ToString();
                            }
                            else
                            {
                                txtAccName.Text = _AccDef.Eng_Des.ToString();
                            }
                            txtBalance.Value = _AccDef.Balance.Value;
                        }
                    }
                }
                else
                {
                    _AccDef = listAccDefSer[0];
                    c1FlexGrid1.SetData(e.Row, 1, _AccDef.AccDef_No.ToString());
                    c1FlexGrid1.SetData(e.Row, 2, _AccDef.Arb_Des.ToString());
                    c1FlexGrid1.SetData(e.Row, 3, _AccDef.Eng_Des.ToString());
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtAccName.Text = _AccDef.Arb_Des.ToString();
                    }
                    else
                    {
                        txtAccName.Text = _AccDef.Eng_Des.ToString();
                    }
                    txtBalance.Value = _AccDef.Balance.Value;
                }
                VarGeneral.Flush();
            }
            else if (e.Col == 6)
            {
                try
                {
                    if (double.Parse(VarGeneral.TString.TEmpty(c1FlexGrid1.GetData(e.Row, 6).ToString())) > 0.0)
                    {
                        c1FlexGrid1.SetData(e.Row, 7, 0);
                    }
                }
                catch
                {
                }
            }
            else
            {
                if (e.Col != 7)
                {
                    return;
                }
                try
                {
                    if (double.Parse(VarGeneral.TString.TEmpty(c1FlexGrid1.GetData(e.Row, 7).ToString())) > 0.0)
                    {
                        c1FlexGrid1.SetData(e.Row, 6, 0);
                    }
                }
                catch
                {
                }
            }
        }
        private void c1FlexGrid1_AfterRowColChange(object sender, RangeEventArgs e)
        {
            try
            {
                if (State == FormState.Saved || !(VarGeneral.TString.TEmpty(string.Concat(c1FlexGrid1.GetData(e.OldRange.r1, 1))) != ""))
                {
                    return;
                }
                double RowVal = 0.0;
                txtTotalCredit.Value = 0.0;
                txtTotalDebit.Value = 0.0;
                for (int iiCnt = 1; iiCnt < c1FlexGrid1.Rows.Count && (string)c1FlexGrid1.GetData(iiCnt, 1) != null; iiCnt++)
                {
                    RowVal = double.Parse("0" + c1FlexGrid1.GetData(iiCnt, 6));
                    txtTotalDebit.Value += RowVal;
                    RowVal = double.Parse("0" + c1FlexGrid1.GetData(iiCnt, 7));
                    txtTotalCredit.Value += RowVal;
                }
                if ((string)c1FlexGrid1.GetData(c1FlexGrid1.Row, 1) != "" && c1FlexGrid1.GetData(c1FlexGrid1.Row, 1) != null)
                {
                    List<T_AccDef> listAccDefSer = new List<T_AccDef>();
                    listAccDefSer = (from t in db.T_AccDefs
                                     where t.AccDef_No == c1FlexGrid1.GetData(c1FlexGrid1.Row, 1).ToString().Trim()
                                     where t.Sts == (int?)0
                                     where t.Lev == (int?)4
                                     select t).ToList();
                    if (listAccDefSer.Count == 0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "رقم الحساب يدل على انه موقوف او انه ليس حساب حركة .." : "Account number indicates that he was not arrested or movement account ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        c1FlexGrid1.SetData(c1FlexGrid1.Row, 1, "");
                        c1FlexGrid1.SetData(c1FlexGrid1.Row, 2, "");
                        c1FlexGrid1.SetData(c1FlexGrid1.Row, 3, "");
                        c1FlexGrid1.Row = e.OldRange.r1;
                        c1FlexGrid1.Col = 1;
                    }
                }
                if (double.Parse("0" + c1FlexGrid1.GetData(c1FlexGrid1.Row, 6)) > 0.0)
                {
                    c1FlexGrid1.SetData(c1FlexGrid1.Row, 7, 0);
                }
                else if (double.Parse("0" + c1FlexGrid1.GetData(e.OldRange.r1, 7)) > 0.0)
                {
                    c1FlexGrid1.SetData(e.OldRange.r1, 6, 0);
                }
            }
            catch
            {
            }
        }
        private void c1FlexGrid1_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            if (!((string)c1FlexGrid1.GetData(c1FlexGrid1.Row, 1) != "") || c1FlexGrid1.GetData(c1FlexGrid1.Row, 1) == null)
            {
                return;
            }
            List<T_AccDef> listAccDefSer = new List<T_AccDef>();
            listAccDefSer = (from t in db.T_AccDefs
                             where t.AccDef_No == c1FlexGrid1.GetData(c1FlexGrid1.Row, 1).ToString().Trim()
                             where t.Sts == (int?)0
                             where t.Lev == (int?)4
                             select t).ToList();
            if (listAccDefSer.Count() > 0)
            {
                try
                {
                    listAccDefSer.First().Debit = db.ExecuteQuery<double>(" select sum(Round(T_GDDET.gdValue," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) from T_GDDET INNER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID where T_GDHEAD.gdLok = 0 and T_GDDET.gdValue > 0 and T_GDDET.AccNo ='" + listAccDefSer.First().AccDef_No + "'", new object[0]).FirstOrDefault();
                }
                catch
                {
                    listAccDefSer.First().Debit = 0.0;
                }
                try
                {
                    listAccDefSer.First().Credit = Math.Abs(db.ExecuteQuery<double>(" select sum(Round(T_GDDET.gdValue," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) from T_GDDET INNER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID where T_GDHEAD.gdLok = 0 and T_GDDET.gdValue < 0 and T_GDDET.AccNo ='" + listAccDefSer.First().AccDef_No + "'", new object[0]).FirstOrDefault());
                }
                catch
                {
                    listAccDefSer.First().Credit = 0.0;
                }
                try
                {
                    listAccDefSer.First().Balance = db.ExecuteQuery<double>(" select sum(Round(T_GDDET.gdValue," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) from T_GDDET INNER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID where T_GDHEAD.gdLok = 0 and T_GDDET.AccNo ='" + listAccDefSer.First().AccDef_No + "'", new object[0]).FirstOrDefault();
                }
                catch
                {
                    listAccDefSer.First().Balance = 0.0;
                }
                _AccDef = listAccDefSer[0];
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtAccName.Text = _AccDef.Arb_Des.ToString();
                }
                else
                {
                    txtAccName.Text = _AccDef.Eng_Des.ToString();
                }
                txtBalance.Value = _AccDef.Balance.Value;
            }
        }
        private void c1FlexGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                c1FlexGrid1.RemoveItem(c1FlexGrid1.Row);
                double RowVal = 0.0;
                txtTotalCredit.Value = 0.0;
                txtTotalDebit.Value = 0.0;
                for (int iiCnt = 1; iiCnt < c1FlexGrid1.Rows.Count && (string)c1FlexGrid1.GetData(iiCnt, 1) != null; iiCnt++)
                {
                    RowVal = double.Parse("0" + c1FlexGrid1.GetData(iiCnt, 6));
                    txtTotalDebit.Value += RowVal;
                    RowVal = double.Parse("0" + c1FlexGrid1.GetData(iiCnt, 7));
                    txtTotalCredit.Value += RowVal;
                }
            }
            else if (e.KeyCode == Keys.Insert && c1FlexGrid1.Col == 4 && c1FlexGrid1.Row >= 2)
            {
                c1FlexGrid1.SetData(c1FlexGrid1.Row, c1FlexGrid1.Col, c1FlexGrid1.GetData(c1FlexGrid1.Row - 1, c1FlexGrid1.Col));
            }
            else if (e.KeyCode == Keys.Insert && c1FlexGrid1.Col == 5 && c1FlexGrid1.Row >= 2)
            {
                c1FlexGrid1.SetData(c1FlexGrid1.Row, c1FlexGrid1.Col, c1FlexGrid1.GetData(c1FlexGrid1.Row - 1, c1FlexGrid1.Col));
            }
        }
        private void c1FlexGrid1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (string.Concat(c1FlexGrid1.GetData(c1FlexGrid1.RowSel, 1)) != "")
                {
                    _AccFather = new T_AccDef();
                    T_AccDef newData = db.StockAccDef(string.Concat(c1FlexGrid1.GetData(c1FlexGrid1.RowSel, 1)));
                    if (newData == null || string.IsNullOrEmpty(newData.AccDef_No))
                    {
                        txtFatherAccName.Text = "";
                        return;
                    }
                    _AccFather = db.StockAccDef(newData.ParAcc);
                    txtFatherAccName.Text = ((LangArEn == 0) ? ("  حســاب الأب   |   " + _AccFather.Arb_Des) : ("  Father Account  |  " + _AccFather.Eng_Des));
                }
            }
            catch
            {
                _AccFather = new T_AccDef();
                txtFatherAccName.Text = "";
            }
        }
        private void c1FlexGrid1_RowColChange(object sender, EventArgs e)
        {
            if (c1FlexGrid1.Col == 1)
            {
                Framework.Keyboard.Language.Switch("English");
            }
            if (c1FlexGrid1.Col == 2)
            {
                Framework.Keyboard.Language.Switch("Arabic");
            }
            if (c1FlexGrid1.Col == 3)
            {
                Framework.Keyboard.Language.Switch("English");
            }
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
            else if (e.KeyCode == Keys.F5 && buttonItem_Print.Enabled && buttonItem_Print.Visible && State == FormState.Saved && expandableSplitter1.Expanded)
            {
                buttonItem_Print_Click(sender, e);
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
        private void prnt_doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
            {
                return;
            }
            List<T_mInvPrint> listmInvPrint = new List<T_mInvPrint>();
            T_mInvPrint _mInvPrint = new T_mInvPrint();
            listmInvPrint = (from item in db.T_mInvPrints
                             where item.repTyp == (int?)16
                             where item.repNum == (int?)2
                             where item.IsPrint == (int?)1
                             select item).ToList();
            if (listmInvPrint.Count == 0)
            {
                return;
            }
            e.PageSettings.Margins.Bottom = Convert.ToInt32(_InvSetting.InvpRINTERInfo.hAs);
            e.PageSettings.Margins.Top = Convert.ToInt32(_InvSetting.InvpRINTERInfo.hAl);
            e.PageSettings.Margins.Left = Convert.ToInt32(_InvSetting.InvpRINTERInfo.hYs);
            e.PageSettings.Margins.Right = Convert.ToInt32(_InvSetting.InvpRINTERInfo.hYm);
            e.PageSettings.PrinterSettings.Copies = short.Parse(_InvSetting.InvpRINTERInfo.DefLines.Value.ToString());
            double _isRows = 0.0;
            float _Row = 0f;
            double _PageLine = _InvSetting.InvpRINTERInfo.lnPg.Value;
            double _LineSp = _InvSetting.InvpRINTERInfo.lnSpc.Value;
            int _PageCount = Convert.ToInt32((double)VarGeneral.RepData.Tables[0].Rows.Count / _PageLine);
            double _VPage = (double)VarGeneral.RepData.Tables[0].Rows.Count / _PageLine;
            StringFormat strformat = new StringFormat((StringFormatFlags)0, 1);
            if (_VPage - (double)_PageCount != 0.0)
            {
                _PageCount++;
            }
            for (int iiRnt = iiRntP; iiRnt < VarGeneral.RepData.Tables[0].Rows.Count; iiRnt++)
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
                    Font _font = new Font(_mInvPrint.vFont, _mInvPrint.vSize.Value, e.Graphics.PageUnit);
                    if (_mInvPrint.vBold.Value == 1)
                    {
                        _font = new Font(_mInvPrint.vFont, _mInvPrint.vSize.Value, FontStyle.Bold, e.Graphics.PageUnit);
                    }
                    _Row = ((_mInvPrint.IsPrntHd.Value != 1) ? ((float)_mInvPrint.vRow.Value) : ((float)_mInvPrint.vRow.Value + (float)_isRows));
                    string strfiled = "";
                    if (_mInvPrint.pField == "PageNo")
                    {
                        strfiled = _page + " / " + _PageCount;
                    }
                    else
                    {
                        try
                        {
                            strfiled = VarGeneral.TString.TEmpty_Stock(string.Concat(VarGeneral.RepData.Tables[0].Rows[iiRnt][_mInvPrint.pField]));
                        }
                        catch
                        {
                            MessageBox.Show(_mInvPrint.pField);
                        }
                    }
                    if (_mInvPrint.IsPrntHd == 1)
                    {
                        e.Graphics.DrawString(strfiled, _font, Brushes.Black, _mInvPrint.vCol.Value, _Row, strformat);
                        continue;
                    }
                    int? nTyp = _mInvPrint.nTyp;
                    if (nTyp.Value == 0 && nTyp.HasValue && _isRows == 0.0)
                    {
                        e.Graphics.DrawString(strfiled, _font, Brushes.Black, _mInvPrint.vCol.Value, _Row, strformat);
                    }
                    else if (_mInvPrint.nTyp == 1 && _page == 1)
                    {
                        e.Graphics.DrawString(strfiled, _font, Brushes.Black, _mInvPrint.vCol.Value, _Row, strformat);
                    }
                    else if (_mInvPrint.nTyp == 2 && _page == _PageCount)
                    {
                        e.Graphics.DrawString(strfiled, _font, Brushes.Black, _mInvPrint.vCol.Value, _Row, strformat);
                    }
                }
                _isRows += _InvSetting.InvpRINTERInfo.lnSpc.Value;
                if ((double)(iiRnt + 1) >= (double)_page * _PageLine)
                {
                    _page++;
                    _isRows = 0.0;
                    iiRntP = iiRnt + 1;
                    if (_page <= _PageCount)
                    {
                        e.HasMorePages = true;
                        return;
                    }
                }
            }
            e.HasMorePages = false;
        }
        private void prnt_doc_BeginPrint(object sender, PrintEventArgs e)
        {
            if (!(textBox_ID.Text != ""))
            {
                return;
            }
            RepShow _RepShow = new RepShow();
            _RepShow.Tables = "T_GDDET LEFT OUTER JOIN T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID LEFT OUTER JOIN T_INVSETTING ON T_GDHEAD.gdTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_GDHEAD.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_GDHEAD.gdCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_GDHEAD.gdMnd = T_Mndob.Mnd_ID LEFT OUTER JOIN T_AccDef ON T_GDDET.AccNo = T_AccDef.AccDef_No LEFT OUTER JOIN T_SYSSETTING ON T_GDHEAD.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
            string Fields = " CASE WHEN T_GDDET.gdValue > 0 THEN T_GDDET.gdValue ELSE 0 END as DebitBala , CASE WHEN T_GDDET.gdValue < 0 THEN Abs(T_GDDET.gdValue) ELSE 0 END as CreditBala , T_Curency.Arb_Des as Arb_Cur , T_Curency.Eng_Des as Eng_Cur, T_Curency.Rate , T_CstTbl.Arb_Des as Arb_Cst, T_CstTbl.Eng_Des as Eng_Cst , T_Mndob.Arb_Des as Arb_Mnd, T_Mndob.Eng_Des as Eng_Mnd , T_GDHEAD.* , T_GDDET.AccNo as AccDef_No,T_AccDef.Arb_Des ,T_AccDef.Eng_Des ,T_GDDET.gdDes,T_GDDET.gdDesE,T_SYSSETTING.LogImg,(select InvNamA from T_INVSETTING where T_GDHEAD.gdTyp = T_INVSETTING.InvID ) as InvNamA,(select InvNamE from T_INVSETTING where T_GDHEAD.gdTyp = T_INVSETTING.InvID ) as InvNamE,(select InvTypA0 from T_INVSETTING where T_GDHEAD.gdTyp = T_INVSETTING.InvID ) as InvTypA0 ";
            VarGeneral.HeaderRep[0] = Text;
            VarGeneral.HeaderRep[1] = "";
            VarGeneral.HeaderRep[2] = "";
            _RepShow.Rule = " where T_GDHEAD.gdhead_ID = " + data_this.gdhead_ID + " Order by T_GDDET.Lin ";
            if (!string.IsNullOrEmpty(Fields))
            {
                _RepShow.Fields = Fields;
                try
                {
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                    iiRntP = 0;
                    _page = 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void Button_PrintTable_Click(object sender, EventArgs e)
        {
            VarGeneral.InvType = 1;
            FRAccountReport from1 = new FRAccountReport(1);
            from1.Tag = LangArEn;
            from1.TopMost = true;
            from1.ShowDialog();
        }
        private void switchButton_Lock_ValueChanged(object sender, EventArgs e)
        {
            Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
        }
        private void switchButton_Lock_Click(object sender, EventArgs e)
        {
            if (!switchButton_Lock.IsReadOnly)
            {
                if (data_this.AdminLock.Value && switchButton_Lock.Value && !CanEdit)
                {
                    CanEdit = true;
                }
                Button_Edit_Click(sender, e);
            }
        }
        private void txtTotalDebit_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (State != 0)
                {
                    if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
                    {
                        txtTotalDebit.Value = Math.Round(txtTotalDebit.Value, 3);
                    }
                    else
                    {
                        txtTotalDebit.Value = Math.Round(txtTotalDebit.Value, 2);
                    }
                }
            }
            catch
            {
            }
        }
        private void txtTotalCredit_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (State != 0)
                {
                    if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
                    {
                        txtTotalCredit.Value = Math.Round(txtTotalCredit.Value, 3);
                    }
                    else
                    {
                        txtTotalCredit.Value = Math.Round(txtTotalCredit.Value, 2);
                    }
                }
            }
            catch
            {
            }
        }
        private void txtFatherAccName_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
