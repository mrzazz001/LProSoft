using C1.Win.C1BarCode;
using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using Framework.Data;
using InputKey;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Library.RepShow;
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
    public partial class FMOpenQuantities : Form
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
        private ScriptNumber ScriptNumber1 = new ScriptNumber();
        public Dictionary<string, string> columns_Nams_Sums = new Dictionary<string, string>();
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private int RowSel = 0;
        private string oldUnit = "";
        private double RateValue = 0.0;
        private string UnitAOld = "";
        private string UnitEOld = "";
        private double PriceOld = 0.0;
        private int DefPack = 0;
        private double Pack = 0.0;
        private double PriceLoc = 0.0;
        public static int LangArEn = 0;
        public string DocType = "";
        private T_SYSSETTING _SysSetting = new T_SYSSETTING();
        private List<T_SYSSETTING> listSysSetting = new List<T_SYSSETTING>();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private List<T_INVSETTING> listInvSetting = new List<T_INVSETTING>();
        private T_STKSQTY _StksQty = new T_STKSQTY();
        private List<T_STKSQTY> listStkQty = new List<T_STKSQTY>();
        private T_GDHEAD _GdHeadCostTax = new T_GDHEAD();
        private List<T_GDHEAD> listGdHeadCostTax = new List<T_GDHEAD>();
        private List<T_GDDET> listGdDetCostTax = new List<T_GDDET>();
        private T_GDHEAD _GdHead = new T_GDHEAD();
        private List<T_GDHEAD> listGdHead = new List<T_GDHEAD>();
        private T_GDDET _GdDet = new T_GDDET();
        private List<T_GDDET> listGdDet = new List<T_GDDET>();
        private List<T_QTYEXP> listQtyExp = new List<T_QTYEXP>();
        private T_QTYEXP _QtyExp = new T_QTYEXP();
        private T_Unit _Unit = new T_Unit();
        private List<T_Unit> listUnit = new List<T_Unit>();
        private T_Item _Items = new T_Item();
        private List<T_Item> listItems = new List<T_Item>();
        private T_Store _Store = new T_Store();
        private List<T_Store> listStore = new List<T_Store>();
        private List<T_Curency> listCurency = new List<T_Curency>();
        private T_Curency _Curency = new T_Curency();
        private List<T_GdAuto> listGdAuto = new List<T_GdAuto>();
        private T_GdAuto _GdAuto = new T_GdAuto();
        private T_INVDET _InvDetRet = new T_INVDET();
        private T_INVDET _InvDet = new T_INVDET();
        private T_GDHEAD _GdHeadCostDis = new T_GDHEAD();
        private List<T_GDHEAD> listGdHeadCostDis = new List<T_GDHEAD>();
        private List<T_GDDET> listGdDetCostDis = new List<T_GDDET>();
        private T_INVHED data_this;
        private T_STKSQTY data_this_stkQ;
        private List<T_INVDET> LData_This;
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
        private bool ifAutoOrderColumn = true;
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
        private List<string> _StorePr = new List<string>();
        private T_INVDET_Repair vDataRapir = new T_INVDET_Repair();
        private int iiRntP = 0;
        private int _page = 1;
        private bool RepetitionSts = false;
        private bool ReverseSts = false;
        private bool _StopMove = true;
        private int vRowBarcode = 0;
        private int CountPage = 0;
        private T_Company _Company = new T_Company();
        private T_INVSETTING _InvSettingBarCod = new T_INVSETTING();
        private bool ifMultiPrint = false;
        private IContainer components = null;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!keyData.ToString().Contains("Control") && !keyData.ToString().ToLower().Contains("delete") && keyData.ToString().Contains("Alt"))
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
                        frm.Repvalue = "OpenQty";
                        frm.RepCashier = "InvoiceCachier";

                        frm.Repvalue = "OpenQty";
                        frm.RepCashier = "InvoiceCachier";
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
        private DoubleInput txtCustNet;
        private DoubleInput txtCustRep;
        private DoubleInput textBox2;
        private DoubleInput textBox1;
        private ImageList imageList1;
        protected ContextMenuStrip contextMenuStrip1;
        private Timer timerInfoBallon;
        protected ContextMenuStrip contextMenuStrip2;
        protected ToolStripMenuItem ToolStripMenuItem_Det;
        private SaveFileDialog saveFileDialog1;
        private Timer timer1;
        private PrintDocument prnt_doc;
        internal PrintPreviewDialog prnt_prev;
        private DoubleInput txtInvCost;
        private RibbonBar ribbonBar1;
        private C1FlexGrid FlxInv;
        private Panel panel1;
        private PanelEx panelEx3;
        private ExpandableSplitter expandableSplitter1;
        private PanelEx panelEx2;
        private OpenFileDialog openFileDialog1;
        internal GroupBox groupBox5;
        private CheckBoxX checkBox_Chash;
        private PictureBox pictureBox_Cash;
        private Bar barTaskList;
        private PanelDockContainer panelDockContainer1;
        private DockContainerItem Panel_Navigate;
        protected SuperGridControl DGV_Main;
        private RibbonBar ribbonBar_DGV;
        private SuperTabControl superTabControl_DGV;
        protected TextBoxItem textBox_search;
        protected ButtonItem Button_ExportTable2;
        protected ButtonItem Button_PrintTable;
        protected LabelItem labelItem3;
        private RibbonBar ribbonBar_Tasks;
        private SuperTabControl superTabControl_Main1;
        protected ButtonItem Button_Close;
        protected ButtonItem buttonItem_Print;
        protected ButtonItem Button_Search;
        protected ButtonItem Button_Delete;
        protected ButtonItem Button_Save;
        protected ButtonItem Button_Add;
        private SuperTabControl superTabControl_Main2;
        protected LabelItem labelItem1;
        protected ButtonItem Button_First;
        protected ButtonItem Button_Prev;
        protected TextBoxItem TextBox_Index;
        protected LabelItem Label_Count;
        protected ButtonItem Button_Next;
        protected ButtonItem Button_Last;
        private TextBox txtItemName;
        private DoubleInput doubleInput_Rate;
        private ComboBoxEx CmbCostC;
        private ComboBoxEx CmbCurr;
        private ComboBoxEx CmbLegate;
        internal TextBox txtRef;
        internal Label label5;
        internal Label label15;
        internal Label label19;
        internal Label label18;
        internal Label label7;
        internal Label Label2;
        internal Label Label1;
        private ComboBoxEx CmbInvPrice;
        private SuperTabControl superTabControl_Info;
        private SuperTabControlPanel superTabControlPanel3;
        private TextBox txtUnit;
        private TextBox txtLPrice;
        internal Label label25;
        internal Label label22;
        internal Label label23;
        internal Label label24;
        private TextBox txtLCost;
        private TextBox txtVCost;
        private SuperTabItem superTabItem_items;
        private SuperTabControlPanel superTabControlPanel1;
        private TextBoxX txtCredit1;
        private TextBoxX txtDebit1;
        internal Label labelC1;
        internal Label labelD1;
        private SuperTabItem superTabItem_Pay;
        private SuperTabControlPanel superTabControlPanel2;
        internal Label label27;
        private DoubleInput txtTotalQ;
        internal Label label30;
        private TextBox textBox_Usr;
        private SuperTabItem superTabItem_Detiles;
        private SuperTabControlPanel superTabControlPanel4;
        private TextBoxX txtRemark;
        private SuperTabItem superTabItem_Note;
        private LabelItem lable_Records;
        private GroupBox groupBox1;
        internal Label label8;
        internal Label Label26;
        private DoubleInput txtDueAmount;
        private DoubleInput txtTotalAm;
        private DoubleInput txtDiscountVal;
        private DoubleInput txtDiscountP;
        internal Label label3;
        private DoubleInput txtDiscountValLoc;
        private DoubleInput txtTotalAmLoc;
        private DoubleInput txtDueAmountLoc;
        internal Label label9;
        internal Label label17;
        private C1FlexGrid FlxDat;
        private MaskedTextBox txtTime;
        private MaskedTextBox txtHDate;
        private MaskedTextBox txtGDate;
        private C1FlexGrid FlxStkQty;
        private GroupPanel groupPanel_Items;
        private ButtonX button_AllItems;
        private ButtonX button_SomeItems;
        private SwitchButton switchButton_Lock;
        internal Label label_LockeName;
        protected ButtonItem button_Repetition;
        private TextBoxX textBox_ID;
        protected ButtonItem Button_BarcodPrint;
        private C1BarCode c1BarCode1;
        private PrintDialog printDialog1;
        internal PrintDocument prnt_doc2;
        private SuperTabControlPanel superTabControlPanel5;
        private SuperTabControl superTabControl_CostSts;
        private SuperTabControlPanel superTabControlPanel6;
        private SwitchButton switchButton_Tax;
        internal Label label33;
        internal Label label34;
        internal Label label35;
        private TextBoxX txtCredit5;
        private TextBoxX txtDebit5;
        private CheckBoxX checkBox_CostGaidTax;
        internal Label label36;
        private DoubleInput txtTotTax;
        private DoubleInput txtTotTaxLoc;
        private SuperTabItem superTabItem_Tax;
        private SuperTabControlPanel superTabControlPanel7;
        private SuperTabItem superTabItem_Dis;
        private SuperTabItem superTabItem_Gaids;
        internal Label label31;
        internal Label label37;
        internal Label label38;
        private TextBoxX txtCredit6;
        private TextBoxX txtDebit6;
        internal Label label39;
        private DoubleInput txtTotDis;
        private DoubleInput txtTotDisLoc;
        private CheckBoxX checkBox_GaidDis;
        private SwitchButton switchButton_Dis;
        private SwitchButtonItem switchButton_TaxLines;
        private SwitchButtonItem switchButton_TaxByTotal;
        private SwitchButtonItem switchButton_TaxByNet;
        private TextBoxItem textBoxItem_TaxByNetValue;
        private LabelItem labelItem_TaxByNetPer;
        protected ButtonItem Button_Export;
        private ButtonItem printingsettings;
        protected ButtonItem Button_PrintTableMulti;
        public T_INVHED DataThis
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
        public List<T_INVDET> LDataThis
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
                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 24))
                {
                    if (statex == FormState.New)
                    {
                        FlxInv.Size = new Size(1181, 167);
                        FlxInv.Location = new Point(64, 108);
                    }
                    else
                    {
                        FlxInv.Size = new Size(1245, 167);
                        FlxInv.Location = new Point(0, 108);
                    }
                }
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
                button_Repetition.Visible = value;
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
        public bool SetReadOnly
        {
            set
            {
                if (value)
                {
                    State = FormState.Saved;
                }
                Button_Save.Enabled = !value;
                if (State == FormState.New)
                {
                    switchButton_Lock.Visible = false;
                    Button_Export.Visible = true;
                }
                else
                {
                    switchButton_Lock.Visible = true;
                    Button_Export.Visible = false;
                }
                if (State == FormState.Saved)
                {
                    button_Repetition.Enabled = true;
                    textBox_ID.ButtonCustom.Visible = true;
                    Button_BarcodPrint.Enabled = true;
                    Button_PrintTableMulti.Enabled = true;
                }
                else
                {
                    button_Repetition.Enabled = false;
                    textBox_ID.ButtonCustom.Visible = false;
                    Button_BarcodPrint.Enabled = false;
                    Button_PrintTableMulti.Enabled = false;
                }
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
        public T_User Permmission
        {
            get
            {
                return permission;
            }
            set
            {
                if (value == null || !(value.UsrNo != ""))
                {
                    return;
                }
                permission = value;
                if (!VarGeneral.TString.ChkStatShow(value.InvStr, 29))
                {
                    IfAdd = false;
                }
                else
                {
                    IfAdd = true;
                }
                if (!VarGeneral.TString.ChkStatShow(value.InvStr, 30) || switchButton_Lock.Value)
                {
                    CanEdit = false;
                }
                else
                {
                    CanEdit = true;
                }
                if (!VarGeneral.TString.ChkStatShow(value.InvStr, 31) || switchButton_Lock.Value)
                {
                    IfDelete = false;
                }
                else
                {
                    IfDelete = true;
                }
                if (!VarGeneral.TString.ChkStatShow(value.InvStr, 63) || switchButton_Lock.Value)
                {
                    button_Repetition.Visible = false;
                }
                else
                {
                    button_Repetition.Visible = true;
                }
                if (!VarGeneral.TString.ChkStatShow(Permmission.RepInv1, 0))
                {
                    switchButton_Lock.IsReadOnly = true;
                }
                else
                {
                    try
                    {
                        if (data_this == null || string.IsNullOrEmpty(data_this.InvNo))
                        {
                            switchButton_Lock.IsReadOnly = false;
                        }
                        else if (!string.IsNullOrEmpty(data_this.SalsManNam))
                        {
                            if (VarGeneral.UserNumber.Trim() != data_this.SalsManNam.Trim() && switchButton_Lock.Value && State != FormState.Edit)
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
                if (State != FormState.New)
                {
                    switchButton_Lock.Visible = true;
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
        public void FillHDGV(IEnumerable<T_INVHED> new_data_enum)
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
            DGV_Main.PrimaryGrid.DataMember = "T_INVHED";
        }
        public void FillHDGVQ(IQueryable new_data_enum)
        {
            SetReadOnly = true;
            DGV_Main.PrimaryGrid.DataSource = new_data_enum;
            DGV_Main.PrimaryGrid.DataMember = "T_INVHED";
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
        private void Button_Edit_Click(object sender, EventArgs e)
        {
            if (CanEdit && State != FormState.Edit && State != FormState.New && !string.IsNullOrEmpty(textBox_ID.Text))
            {
                if (State != FormState.New)
                {
                    State = FormState.Edit;
                }
                FlxInv.Rows.Count = FlxInv.Rows.Count + VarGeneral.Settings_Sys.LineOfInvoices.Value;
                SetReadOnly = false;
            }
        }
        public void Button_Print_Click(object sender, EventArgs e)
        {
            if (ViewState == ViewState.Table)
            {
                VarGeneral.InvType = 14;
                FRInvoice form1 = new FRInvoice(VarGeneral.InvTyp, LangArEn);
                form1.Tag = LangArEn.ToString();
                form1.StartPosition = FormStartPosition.CenterScreen;
                form1.TopMost = true;
                form1.ShowDialog();
            }
        }
        private void Button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void textBox_ID_Click(object sender, EventArgs e)
        {
            textBox_ID.SelectAll();
        }
        private void txtTime_Click(object sender, EventArgs e)
        {
            txtTime.SelectAll();
        }
        private void textBox_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void FrmInvices_CheckFouce(object sender, EventArgs e)
        {
            VarGeneral.InvTyp = 14;
        }
        public FMOpenQuantities()
        {
            InitializeComponent();
            base.Activated += FrmInvices_CheckFouce;
            textBox_ID.KeyPress += textBox_ID_KeyPress;
            textBox1.Click += Button_Edit_Click;
            textBox2.Click += Button_Edit_Click;
            textBox_Type.Click += Button_Edit_Click;
            txtCustNet.Click += Button_Edit_Click;
            txtCustRep.Click += Button_Edit_Click;
            txtDiscountP.Click += Button_Edit_Click;
            txtDiscountVal.Click += Button_Edit_Click;
            txtDiscountValLoc.Click += Button_Edit_Click;
            txtDueAmount.Click += Button_Edit_Click;
            txtDueAmountLoc.Click += Button_Edit_Click;
            txtGDate.Click += Button_Edit_Click;
            txtHDate.Click += Button_Edit_Click;
            txtInvCost.Click += Button_Edit_Click;
            txtItemName.Click += Button_Edit_Click;
            switchButton_Tax.Click += Button_Edit_Click;
            checkBox_CostGaidTax.Click += Button_Edit_Click;
            switchButton_TaxLines.Click += Button_Edit_Click;
            switchButton_TaxLines.ValueChanged += switchButton_TaxLines_ValueChanged;
            switchButton_TaxByTotal.Click += Button_Edit_Click;
            switchButton_TaxByTotal.ValueChanged += switchButton_TaxLines_ValueChanged;
            switchButton_TaxByNet.Click += Button_Edit_Click;
            switchButton_TaxByNet.ValueChanged += switchButton_TaxLines_ValueChanged;
            switchButton_TaxByNet.ValueChanged += switchButton_TaxByNet_ValueChanged;
            textBoxItem_TaxByNetValue.KeyPress += textBoxItem_TaxByNetValue_KeyPress;
            textBoxItem_TaxByNetValue.LostFocus += textBoxItem_TaxByNetValue_LostFocus;
            textBoxItem_TaxByNetValue.GotFocus += Button_Edit_Click;
            switchButton_Dis.Click += Button_Edit_Click;
            checkBox_GaidDis.Click += Button_Edit_Click;
            txtDebit6.ButtonCustomClick += txtDebit6_ButtonCustomClick;
            txtCredit6.ButtonCustomClick += txtCredit6_ButtonCustomClick;
            checkBox_GaidDis.CheckedChanged += checkBox_GaidDis_CheckedChanged;
            switchButton_Dis.ValueChanged += switchButton_Dis_ValueChanged;
            txtRef.Click += Button_Edit_Click;
            txtRemark.Click += Button_Edit_Click;
            txtTime.Click += Button_Edit_Click;
            txtTotalAm.Click += Button_Edit_Click;
            txtTotalAmLoc.Click += Button_Edit_Click;
            txtTotalQ.Click += Button_Edit_Click;
            CmbCostC.Click += Button_Edit_Click;
            CmbCurr.Click += Button_Edit_Click;
            checkBox_Chash.Click += Button_Edit_Click;
            CmbInvPrice.Click += Button_Edit_Click;
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
            DGV_Main.PrimaryGrid.CheckBoxes = true;
            DGV_Main.PrimaryGrid.ShowCheckBox = true;
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
            DGV_Main.AfterCheck += DGV_Main_AfterCheck;
            textBox_ID.TextChanged += textBox_ID_TextChanged;
            textBox_ID.Click += textBox_ID_Click;
            txtHDate.Click += txtHDate_Click;
            txtHDate.Leave += txtHDate_Leave;
            txtGDate.Click += txtGDate_Click;
            txtGDate.Leave += txtGDate_Leave;
            txtTime.Click += txtTime_Click;
            txtTime.Leave += txtTime_Leave;
            CmbCurr.SelectedIndexChanged += CmbCurr_SelectedIndexChanged;
            checkBox_Chash.CheckedChanged += checkBox_Chash_CheckedChanged;
            FlxInv.Click += FlxInv_Click;
            FlxInv.AfterEdit += FlxInv_AfterEdit;
            FlxInv.BeforeEdit += FlxInv_BeforeEdit;
            FlxInv.KeyDown += FlxInv_KeyDown;
            FlxInv.MouseDown += FlxInv_MouseDown;
            FlxInv.RowColChange += FlxInv_RowColChange;
            FlxInv.SelChange += FlxInv_SelChange;
            FlxDat.DoubleClick += FlxDat_DoubleClick;
            FlxDat.KeyDown += FlxDat_KeyDown;
            FlxDat.Leave += FlxDat_Leave;
            txtDiscountP.Leave += txtDiscountP_Leave;
            txtDiscountVal.Leave += txtDiscountVal_Leave;
            buttonItem_Print.Click += buttonItem_Print_Click;
            Button_PrintTable.Click += Button_Print_Click;
            txtRemark.ButtonCustomClick += txtRemark_ButtonCustomClick;
            txtRemark.ButtonCustomClick += txtRemark_ButtonCustomClick;
            txtDebit1.ButtonCustomClick += txtDebit1_ButtonCustomClick;
            txtCredit1.ButtonCustomClick += txtCredit1_ButtonCustomClick;
            txtCredit5.ButtonCustomClick += txtCredit5_ButtonCustomClick;
            txtDebit5.ButtonCustomClick += txtDebit5_ButtonCustomClick;
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
                doubleInput_Rate.DisplayFormat = VarGeneral.DicemalMask;
                txtDiscountVal.DisplayFormat = VarGeneral.DicemalMask;
                txtDiscountP.DisplayFormat = VarGeneral.DicemalMask;
                txtTotalAmLoc.DisplayFormat = VarGeneral.DicemalMask;
                txtDueAmountLoc.DisplayFormat = VarGeneral.DicemalMask;
                txtDiscountValLoc.DisplayFormat = VarGeneral.DicemalMask;
                txtTotalAm.DisplayFormat = VarGeneral.DicemalMask;
                txtDueAmount.DisplayFormat = VarGeneral.DicemalMask;
                txtTotalQ.DisplayFormat = VarGeneral.DicemalMask;
                txtTotTax.DisplayFormat = VarGeneral.DicemalMask;
                txtTotTaxLoc.DisplayFormat = VarGeneral.DicemalMask;
                txtTotDis.DisplayFormat = VarGeneral.DicemalMask;
                txtTotDisLoc.DisplayFormat = VarGeneral.DicemalMask;
                try
                {
                    FlxInv.Cols[8].Format = VarGeneral.DicimalNN;
                    FlxInv.Cols[9].Format = VarGeneral.DicimalNN;
                    FlxInv.Cols[10].Format = VarGeneral.DicimalNN;
                    FlxInv.Cols[11].Format = VarGeneral.DicimalNN;
                    FlxInv.Cols[12].Format = VarGeneral.DicimalNN;
                    FlxInv.Cols[38].Format = VarGeneral.DicimalNN;
                    FlxInv.Cols[31].Format = VarGeneral.DicimalNN;
                }
                catch
                {
                }
            }
        }
        private void txtDebit6_ButtonCustomClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            Button_Edit_Click(sender, e);
            columns_Names_visible2.Clear();
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
                VarGeneral.AccTyp = 5;
            }
            else
            {
                VarGeneral.SFrmTyp = "AccDefID_Setting";
            }
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != "")
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtDebit6.Tag = _AccDef.AccDef_No;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtDebit6.Text = _AccDef.Arb_Des;
                    }
                    else
                    {
                        txtDebit6.Text = _AccDef.Eng_Des;
                    }
                }
                else
                {
                    txtDebit6.Text = "";
                    txtDebit6.Tag = "";
                }
            }
            catch
            {
                txtDebit6.Text = "";
                txtDebit6.Tag = "";
            }
        }
        private void txtCredit6_ButtonCustomClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            Button_Edit_Click(sender, e);
            columns_Names_visible2.Clear();
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
                VarGeneral.AccTyp = 5;
            }
            else
            {
                VarGeneral.SFrmTyp = "AccDefID_Setting";
            }
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != "")
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtCredit6.Tag = _AccDef.AccDef_No;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtCredit6.Text = _AccDef.Arb_Des;
                    }
                    else
                    {
                        txtCredit6.Text = _AccDef.Eng_Des;
                    }
                }
                else
                {
                    txtCredit6.Text = "";
                    txtCredit6.Tag = "";
                }
            }
            catch
            {
                txtCredit6.Text = "";
                txtCredit6.Tag = "";
            }
        }
        private void txtDebit5_ButtonCustomClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            Button_Edit_Click(sender, e);
            columns_Names_visible2.Clear();
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
                VarGeneral.AccTyp = 5;
            }
            else
            {
                VarGeneral.SFrmTyp = "AccDefID_Setting";
            }
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != "")
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtDebit5.Tag = _AccDef.AccDef_No;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtDebit5.Text = _AccDef.Arb_Des;
                    }
                    else
                    {
                        txtDebit5.Text = _AccDef.Eng_Des;
                    }
                }
                else
                {
                    txtDebit5.Text = "";
                    txtDebit5.Tag = "";
                }
            }
            catch
            {
                txtDebit5.Text = "";
                txtDebit5.Tag = "";
            }
        }
        private void txtCredit5_ButtonCustomClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            Button_Edit_Click(sender, e);
            columns_Names_visible2.Clear();
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
                VarGeneral.AccTyp = 5;
            }
            else
            {
                VarGeneral.SFrmTyp = "AccDefID_Setting";
            }
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != "")
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtCredit5.Tag = _AccDef.AccDef_No;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtCredit5.Text = _AccDef.Arb_Des;
                    }
                    else
                    {
                        txtCredit5.Text = _AccDef.Eng_Des;
                    }
                }
                else
                {
                    txtCredit5.Text = "";
                    txtCredit5.Tag = "";
                }
            }
            catch
            {
                txtCredit5.Text = "";
                txtCredit5.Tag = "";
            }
        }
        private int vStr(int vTy)
        {
            if (VarGeneral.InvTyp == 1)
            {
                if (VarGeneral._IsPOS)
                {
                    return 27;
                }
                return 1;
            }
            if (VarGeneral.InvTyp == 1)
            {
                return 1;
            }
            if (VarGeneral.InvTyp == 2)
            {
                return 5;
            }
            if (VarGeneral.InvTyp == 3)
            {
                return 3;
            }
            if (VarGeneral.InvTyp == 4)
            {
                return 7;
            }
            if (VarGeneral.InvTyp == 7)
            {
                return 9;
            }
            if (VarGeneral.InvTyp == 8)
            {
                return 11;
            }
            if (VarGeneral.InvTyp == 9)
            {
                return 13;
            }
            if (VarGeneral.InvTyp == 14)
            {
                return 15;
            }
            if (VarGeneral.InvTyp == 5)
            {
                return 17;
            }
            if (VarGeneral.InvTyp == 6)
            {
                return 19;
            }
            if (VarGeneral.InvTyp == 17)
            {
                return 21;
            }
            if (VarGeneral.InvTyp == 20)
            {
                return 23;
            }
            return 25;
        }
        public void buttonItem_Print_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(textBox_ID.Text != "") || State != 0)
                {
                    return;
                }
                if ((_InvSetting.InvpRINTERInfo.nTyp.Substring(0, 1) == "1" && !VarGeneral.TString.ChkStatShow(permission.StopBanner, 2)) || (_InvSetting.InvpRINTERInfo.nTyp.Substring(0, 1) == "0" && VarGeneral.TString.ChkStatShow(permission.StopBanner, 2)))
                {
                    RepShow _RepShow = new RepShow();
                    _RepShow.Tables = "T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                    string vInvH = " T_INVHED.InvHed_ID, T_INVHED.InvId as vID, T_INVHED.InvNo, T_INVHED.InvTyp, T_INVHED.InvCashPay, T_INVHED.CusVenNo,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Arb_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNm,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Eng_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNmE, T_INVHED.CusVenAdd, T_INVHED.CusVenTel, T_INVHED.Remark, T_INVHED.HDat, T_INVHED.GDat, T_INVHED.MndNo, T_INVHED.SalsManNo, T_INVHED.SalsManNam, T_INVHED.InvTot, T_INVHED.InvDisPrs, ((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints, T_INVHED.InvNet, T_INVHED.InvNetLocCur, T_INVHED.CashPayLocCur, T_INVHED.IfRet, T_INVHED.CashPay, T_INVHED.InvTotLocCur, T_INVHED.InvDisValLocCur, T_INVHED.GadeNo, T_INVHED.GadeId, T_INVHED.RetNo, T_INVHED.RetId, T_INVHED.InvCashPayNm, T_INVHED.InvCost, T_INVHED.CustPri, T_INVHED.ArbTaf, T_INVHED.ToStore, T_INVHED.InvCash, T_INVHED.CurTyp, T_INVHED.EstDat,case when DATEDIFF(day, GETDATE(), EstDat) > 0 Then DATEDIFF(day, GETDATE(), EstDat) WHEN DATEDIFF(day, GETDATE(), InvCashPayNm) > 0 THEN DATEDIFF(day, GETDATE(), InvCashPayNm) Else '0' END as EstDatNote, T_INVHED.InvCstNo, T_INVHED.IfDel, T_INVHED.RefNo, T_INVHED.ToStoreNm, T_INVHED.EngTaf, T_INVHED.IfTrans, T_INVHED.InvQty, T_INVHED.CustNet, T_INVHED.CustRep, T_INVHED.InvWight_T, T_INVHED.IfPrint, T_INVHED.LTim, T_INVHED.DATE_CREATED, T_INVHED.MODIFIED_BY, T_INVHED.CreditPay, T_INVHED.DATE_MODIFIED, T_INVHED.CREATED_BY, T_INVHED.CreditPayLocCur, T_INVHED.NetworkPay, T_INVHED.NetworkPayLocCur, T_INVHED.MndExtrnal, T_INVHED.CompanyID, T_INVHED.InvAddCost, T_INVHED.InvAddCostExtrnal, T_INVHED.InvAddCostExtrnalLoc, T_INVHED.IsExtrnalGaid, T_INVHED.ExtrnalCostGaidID, T_INVHED.InvAddCostLoc, T_INVHED.CommMnd_Inv, T_INVHED.Puyaid, T_INVHED.Remming,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.PersonalNm from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as PersonalNm,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.City from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as City,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Email from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Email,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Mobile from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Mobile,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Telphone1 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Telphone1,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select vColStr1 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CustAge,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Telphone2 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Telphone2,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Fax from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Fax,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.zipCod from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as zipCod,T_SYSSETTING.LineGiftlNameA,T_SYSSETTING.LineGiftlNameE,T_Curency.Arb_Des as CurrnceyNm,T_Curency.Eng_Des as CurrnceyNmE,(select max(gdDes)from T_GDDET where gdID = T_INVHED.GadeId )as gdDes, (T_INVDET.Amount - (case when T_INVHED.IsTaxLines = 1 then (case when T_INVHED.IsTaxByTotal = 1 then (case when (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) > 0 then ((Abs(T_INVDET.Qty) *  T_INVDET.Price) - case when (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) > 0 then (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) else 0 end )* T_INVDET.ItmTax / 100   else 0 end) else (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) end) else 0 end )) as TotBeforeTax,(select invGdADesc from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as invGdADesc,(select invGdEDesc from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as invGdEDesc,(select T_CATEGORY.CAT_No from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CAT_No,(select T_CATEGORY.Arb_Des from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CatNmA,(select T_CATEGORY.Eng_Des from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CatNmE,(case when (select t.BarCod1 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit1 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod1 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit1 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt ))  when (select t.BarCod2 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit2 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod2 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit2 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod3 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit3 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod3 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit3 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod4 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit4 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod4 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit4 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod5 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit5 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod5 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit5 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) else T_Items.Itm_No  end) as ItmBarcod";
                    string Fields = " Abs(T_INVDET.Qty) as QtyAbs , T_INVDET.InvDet_ID,T_INVHED.tailor1,T_INVHED.tailor2,T_INVHED.tailor3,T_INVHED.tailor4,T_INVHED.tailor5,T_INVHED.tailor6,T_INVHED.tailor7,T_INVHED.tailor8,T_INVHED.tailor9,T_INVHED.tailor10,T_INVHED.tailor11,T_INVHED.tailor12,T_INVHED.tailor13,T_INVHED.tailor14,T_INVHED.tailor15,T_INVHED.tailor16,T_INVHED.tailor17,T_INVHED.tailor18,T_INVHED.tailor19,T_INVHED.tailor20,T_INVHED.InvImg, T_INVDET.InvNo, T_INVDET.InvId, T_INVDET.InvSer, T_INVDET.ItmNo, T_INVDET.Cost, T_INVDET.Qty, T_INVDET.ItmUnt, T_INVDET.ItmDes,T_INVDET.ItmDesE , T_INVDET.ItmUntE, T_INVDET.ItmUntPak, T_INVDET.StoreNo, T_INVDET.Price, T_INVDET.Amount, T_INVDET.RealQty, T_INVDET.ItmTyp,T_INVDET.ItmDis, (Abs(T_INVDET.Qty) *  T_INVDET.Price) * (T_INVDET.ItmDis / 100) as ItmDisVal, T_INVDET.DatExper, T_INVDET.itmInvDsc,ItmIndex," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.LineGiftSts, vStr(VarGeneral.InvTyp)) ? " T_INVDET.ItmWight " : " 0 as ItmWight") + ", T_INVDET.ItmWight_T, T_INVDET.ItmAddCost, T_INVDET.RunCod, T_INVDET.LineDetails ,T_INVDET.Serial_Key, " + vInvH + ", T_Items.* , T_CstTbl.Arb_Des as CstTbl_Arb_Des , T_CstTbl.Eng_Des as CstTbl_Eng_Des , T_Mndob.Arb_Des as Mndob_Arb_Des , T_Mndob.Eng_Des as Mndob_Eng_Des,T_SYSSETTING.LogImg,(select max(T_AccDef.TaxNo) from T_AccDef where T_AccDef.AccDef_No = T_SYSSETTING.TaxAcc) as TaxAcc,T_SYSSETTING.TaxNoteInv,case when T_INVHED.IsTaxLines = 1 then (case when T_INVHED.IsTaxByTotal = 1 then (case when (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) > 0 then ((Abs(T_INVDET.Qty) *  T_INVDET.Price) - case when (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) > 0 then (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) else 0 end )* T_INVDET.ItmTax / 100   else 0 end) else (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) end) else 0 end as TaxValue ,(select InvNamA from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as InvNamA,(select InvNamE from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as InvNamE,(select T_Store.Arb_Des from T_Store where T_Store.Stor_ID = T_INVDET.StoreNo) as StoreNmA,(select T_Store.Eng_Des from T_Store where T_Store.Stor_ID = T_INVDET.StoreNo) as StoreNmE,(select defPrn from T_INVSETTING where CatID = (select ItmCat from T_Items where Itm_No = T_INVDET.ItmNo) ) as defPrn,case when T_INVHED.CusVenNo = '' THEN '0' ELSE (SELECT Sum(T_GDDET.gdValue) FROM T_GDHEAD INNER JOIN  T_GDDET ON T_GDHEAD.gdhead_ID = T_GDDET.gdID where T_GDDET.AccNo = T_INVHED.CusVenNo and T_GDHEAD.gdLok = 0 and (select T_AccDef.AccCat from T_AccDef where T_AccDef.AccDef_No = T_INVHED.CusVenNo) = '4') END as Balanc,T_INVDET.ItmTax,T_INVHED.InvAddTax,T_INVHED.InvAddTaxlLoc,T_INVHED.TaxGaidID,T_INVHED.IsTaxUse,T_INVHED.IsTaxLines,IsTaxByTotal,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.TaxNo from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as TaxCustNo,T_INVHED.OrderTyp," + ((data_this.IsTaxLines.Value && !VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65)) ? " T_INVHED.InvTotLocCur - T_INVHED.InvAddTax as TotWithTaxPoint " : " T_INVHED.InvTotLocCur as TotWithTaxPoint") + " ,T_INVHED.InvTotLocCur - T_INVHED.InvDisVal as TotBeforeDisVal,T_INVHED.IsTaxByNet,T_INVHED.TaxByNetValue," + (data_this.IsTaxUse.Value ? " T_INVHED.InvNetLocCur - T_INVHED.InvAddTax as NetWithoutTax " : " T_INVHED.InvNetLocCur as NetWithoutTax");
                    VarGeneral.HeaderRep[0] = Text;
                    VarGeneral.HeaderRep[1] = "";
                    VarGeneral.HeaderRep[2] = "";
                    _RepShow.Rule = " where T_INVHED.InvHed_ID = " + data_this.InvHed_ID;
                    if (string.IsNullOrEmpty(Fields))
                    {
                        return;
                    }
                    _RepShow.Fields = Fields;
                    try
                    {
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        _RepShow = new RepShow();
                        _RepShow.Rule = " WHERE T_Users.UsrNo = '" + data_this.SalsManNo + "'";
                        _RepShow.Tables = " T_Branch INNER JOIN T_Users ON T_Branch.Branch_no = T_Users.Brn ";
                        _RepShow.Fields = " T_Users.UsrNamA ,T_Branch.Branch_Name ,T_Users.UsrNamE ,T_Branch.Branch_NameE ,T_Users.UsrImg ";
                        try
                        {
                            VarGeneral.RepShowStock_Rat = "Rate";
                            _RepShow = _RepShow.Save();
                            VarGeneral.RepShowStock_Rat = "";
                        }
                        catch (Exception ex2)
                        {
                            VarGeneral.RepShowStock_Rat = "";
                            MessageBox.Show(ex2.Message);
                        }
                        _RepShow.RepData.Tables[0].Merge(VarGeneral.RepData.Tables[0]);
                        VarGeneral.RepData = _RepShow.RepData;
                        try
                        {
                            for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
                            {
                                if (string.IsNullOrEmpty(VarGeneral.RepData.Tables[0].Rows[i]["LogImg"].ToString()))
                                {
                                    VarGeneral.RepData.Tables[0].Rows[i]["LogImg"] = VarGeneral.RepData.Tables[0].Rows[VarGeneral.RepData.Tables[0].Rows.Count - 1]["LogImg"];
                                    VarGeneral.RepData.Tables[0].Rows[i]["LTim"] = VarGeneral.RepData.Tables[0].Rows[VarGeneral.RepData.Tables[0].Rows.Count - 1]["LTim"];
                                }
                            }
                        }
                        catch
                        {
                        }
                        try
                        {
                            for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
                            {
                                if (string.IsNullOrEmpty(VarGeneral.RepData.Tables[0].Rows[i]["UsrImg"].ToString()))
                                {
                                    try
                                    {
                                        VarGeneral.RepData.Tables[0].Rows[i]["UsrImg"] = VarGeneral.RepData.Tables[0].Rows[0]["UsrImg"];
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                        }
                        catch
                        {
                        }
                        try
                        {
                            if (VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 15))
                            {
                                _RepShow = new RepShow();
                                _RepShow.Rule = "";
                                _RepShow.Tables = "T_SINVDET LEFT OUTER JOIN T_INVHED ON T_SINVDET.SInvIdHEAD = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_SINVDET.SItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                                _RepShow.Fields = " Abs(T_SINVDET.SQty) as QtyAbs , SInvDet_ID as InvId, SInvNo as InvNo, SInvId as InvDet_ID, SInvSer as InvSer,SItmNo as ItmNo, SCost as Cost, SQty as Qty, SItmDes as ItmDes, SItmUnt as ItmUnt, SItmDesE as ItmDesE, SItmUntE as ItmUntE, SItmUntPak as ItmUntPak, SStoreNo as StoreNo, (SPrice * 0) as Price, (SAmount * 0) as Amount, SRealQty as RealQty, SitmInvDsc as itmInvDsc, SDatExper as DatExper, SItmDis as ItmDis, SItmTyp as ItmTyp,SItmIndex as ItmIndex, SItmWight_T as ItmWight_T, SItmWight as ItmWight , T_INVHED.* , T_Items.* , T_CstTbl.Arb_Des as CstTbl_Arb_Des , T_CstTbl.Eng_Des as CstTbl_Eng_Des , T_Mndob.Arb_Des as Mndob_Arb_Des , T_Mndob.Eng_Des as Mndob_Eng_Des,T_SYSSETTING.LogImg";
                                _RepShow.Rule = " where T_INVHED.InvHed_ID = " + data_this.InvHed_ID;
                                _RepShow = _RepShow.Save();
                                VarGeneral.RepData.Tables[0].Merge(_RepShow.RepData.Tables[0]);
                            }
                        }
                        catch
                        {
                        }
                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show(ex2.Message);
                    }
                    if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                    {
                        return;
                    }
                    try
                    {
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "OpenQty";
                        frm.RepCashier = "InvoiceCachier";

                        frm.Tag = LangArEn;
                        if (ifMultiPrint)
                        {
                            frm.BarcodSts = true;
                        }
                        else
                        {
                            frm.BarcodSts = false;
                        }
                        if (_InvSetting.InvpRINTERInfo.nTyp.Substring(1, 1) == "1")
                        {
                            frm.Repvalue = "OpenQty";
                        }
                        else
                        {
                            frm.RepCashier = "InvoiceCachier";
                        }
                        if (VarGeneral.TString.ChkStatShow(Permmission.PeaperTyp, 7))
                        {
                            if (frm.Repvalue == "OpenQty")
                            {
                                frm.RepCashier = "InvoiceCachier";
                            }
                            else
                            {
                                frm.Repvalue = "OpenQty";
                            }
                        }
                        VarGeneral.vTitle = Text;
                        VarGeneral.CostCenterlbl = label15.Text.Replace(" :", "");
                        VarGeneral.Mndoblbl = label18.Text.Replace(" :", "");
                        if (_InvSetting.InvpRINTERInfo.nTyp.Substring(2, 1) == "0" || ifMultiPrint)
                        {
                            frm._Proceess();
                            return;
                        }
                        frm.TopMost = true;
                        frm.ShowDialog();
                    }
                    catch (Exception error)
                    {
                        VarGeneral.DebLog.writeLog("buttonItem_Print_Click:", error, enable: true);
                        MessageBox.Show(error.Message);
                    }
                    return;
                }
                PrintSet();
                prnt_doc.Print();
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void PrintSet()
        {
            string _PrinterName = prnt_doc.PrinterSettings.PrinterName;
            prnt_doc.PrinterSettings.PrinterName = _InvSetting.defPrn;
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
        public void Button_Search_Click(object sender, EventArgs e)
        {
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_Inv";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                textBox_ID.Text = frm.SerachNo.ToString();
            }
        }
        public void ReorderColumns()
        {
            if (!ifAutoOrderColumn)
            {
                return;
            }
            int i = 0;
            foreach (string item in columns_Names_visible.Keys)
            {
                try
                {
                    DGV_Main.PrimaryGrid.Columns[item].DisplayIndex = i;
                }
                catch
                {
                }
                i++;
            }
        }
        public void DGV_Main_ColumnResized(object sender, GridColumnEventArgs e)
        {
            if (ViewState == ViewState.Deiles)
            {
                return;
            }
            foreach (KeyValuePair<string, string> item in columns_Nams_Sums)
            {
                TextBox textBox = new TextBox();
                textBox.Visible = DGV_Main.PrimaryGrid.Columns[item.Key].IsOnScreen;
                textBox.Text = item.Value;
                textBox.Location = new Point(DGV_Main.PrimaryGrid.Columns[item.Key].Bounds.X, 3);
                textBox.Size = new Size(DGV_Main.PrimaryGrid.Columns[item.Key].Width, 20);
            }
        }
        private void DGV_Main_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            ReorderColumns();
            DGV_Main_ColumnResized(new object(), new GridColumnEventArgs(new GridPanel(), new GridColumn()));
            GridPanel panel = e.GridPanel;
            switch (panel.DataMember)
            {
                case "T_INVHED":
                    PropHIOfferPanel(panel);
                    break;
                case "Line":
                    PropLOfferPanel(panel);
                    break;
            }
        }
        public void Clear()
        {
            if (State == FormState.New)
            {
                return;
            }
            State = FormState.New;
            data_this = new T_INVHED();
            _GdHead = new T_GDHEAD();
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
            if (FlxInv.Rows.Count <= 1)
            {
                FlxInv.Rows.Count = VarGeneral.Settings_Sys.LineOfInvoices.Value;
            }
            else
            {
                FlxInv.Clear(ClearFlags.Content, 1, 1, FlxInv.Rows.Count - 1, 38);
            }
            FlxStkQty.Clear(ClearFlags.Content, 1, 1, 1, 1);
            superTabControl_Info.SelectedTabIndex = 0;
            try
            {
                CmbCurr.SelectedValue = int.Parse(VarGeneral.Settings_Sys.ImportIp.ToString());
            }
            catch
            {
            }
            CmbCurr_SelectedIndexChanged(null, null);
            textBox_Usr.Text = ((LangArEn == 0) ? VarGeneral.UserNameA : VarGeneral.UserNameE);
            checkBox_Chash.Checked = true;
            try
            {
                CmbInvPrice.SelectedIndex = int.Parse(_SysSetting.Seting.Substring(13)) + 1;
            }
            catch
            {
                CmbInvPrice.SelectedIndex = 0;
            }
            switchButton_Lock.Value = false;
            label_LockeName.Text = ((LangArEn == 0) ? "غير مقف\u0651ــلة" : "Unlocked");
            textBox_ID.ButtonCustom.Visible = false;
            _GdHeadCostTax = new T_GDHEAD();
            try
            {
                switchButton_Tax.Value = VarGeneral.TString.ChkStatShow(_InvSetting.TaxOptions, 4);
            }
            catch
            {
                switchButton_Tax.Value = true;
            }
            try
            {
                switchButton_TaxLines.Value = VarGeneral.TString.ChkStatShow(_InvSetting.TaxOptions, 5);
            }
            catch
            {
                switchButton_TaxLines.Value = true;
            }
            try
            {
                switchButton_TaxByTotal.Value = VarGeneral.TString.ChkStatShow(_InvSetting.TaxOptions, 6);
            }
            catch
            {
                switchButton_TaxByTotal.Value = false;
            }
            try
            {
                switchButton_TaxByNet.Value = VarGeneral.TString.ChkStatShow(_InvSetting.TaxOptions, 7);
            }
            catch
            {
                switchButton_TaxByNet.Value = false;
            }
            try
            {
                textBoxItem_TaxByNetValue.Text = (VarGeneral.TString.ChkStatShow(_InvSetting.TaxOptions, 2) ? VarGeneral.Settings_Sys.DefPurchaesTax.Value : VarGeneral.Settings_Sys.DefSalesTax.Value).ToString();
            }
            catch
            {
                textBoxItem_TaxByNetValue.Text = "0";
            }
            checkBox_CostGaidTax.Checked = false;
            txtDebit5.Tag = "";
            txtCredit5.Tag = "";
            _GdHeadCostDis = new T_GDHEAD();
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 57))
            {
                switchButton_Dis.Value = true;
            }
            else
            {
                switchButton_Dis.Value = false;
            }
            checkBox_GaidDis.Checked = false;
            txtDebit6.Tag = "";
            txtCredit6.Tag = "";
            SetReadOnly = false;
        }
        private void InvModeChanged()
        {
            pictureBox_Cash.Visible = true;
        }
        private void checkBox_Chash_CheckedChanged(object sender, EventArgs e)
        {
            InvModeChanged();
        }
        private void checkBox_Credit_CheckedChanged(object sender, EventArgs e)
        {
            InvModeChanged();
        }
        private void checkBox_NetWork_CheckedChanged(object sender, EventArgs e)
        {
            InvModeChanged();
        }
        private void ArbEng()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                LangArEn = 0;
                FlxInv.Cols[1].Caption = "رمز الصنف";
                FlxInv.Cols[2].Visible = true;
                FlxInv.Cols[3].Visible = true;
                FlxInv.Cols[4].Visible = false;
                FlxInv.Cols[5].Visible = false;
                FlxInv.Cols[6].Caption = "مستودع";
                FlxInv.Cols[7].Caption = "الكمية";
                FlxInv.Cols[8].Caption = "السعر";
                FlxInv.Cols[9].Caption = "خصم نسبة";
                FlxInv.Cols[9].Visible = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 8);
                FlxInv.Cols[27].Caption = "تاريخ الصلاحية";
                FlxInv.Cols[38].Caption = "الأجمالي";
                FlxInv.Cols[35].Caption = "رقم التصنيع";
                FlxInv.Cols[36].Caption = VarGeneral.Settings_Sys.LineDetailNameA;
                FlxInv.Cols[36].Visible = VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 14);
                FlxInv.Cols[31].Caption = "ضريبة %";
                FlxInv.Cols[33].Caption = VarGeneral.Settings_Sys.LineGiftlNameA;
                FlxInv.Cols[33].Visible = VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 14);
                FlxStkQty.Cols[0].Caption = "المستودع";
                FlxStkQty.Cols[1].Caption = "الكمية المتاحة";
                FlxStkQty.Cols[2].Caption = "المستودع";
                FlxDat.Cols[0].Caption = "تاريخ الصلاحية";
                FlxDat.Cols[1].Caption = "الكمية";
                FlxDat.Cols[2].Caption = "رقم التصنيع";
            }
            else
            {
                LangArEn = 1;
                FlxInv.Cols[1].Caption = "Item Code";
                FlxInv.Cols[2].Visible = false;
                FlxInv.Cols[3].Visible = false;
                FlxInv.Cols[4].Visible = true;
                FlxInv.Cols[5].Visible = true;
                FlxInv.Cols[6].Caption = "Store";
                FlxInv.Cols[7].Caption = "Quantity";
                FlxInv.Cols[8].Caption = "Price";
                FlxInv.Cols[9].Caption = "Dis %";
                FlxInv.Cols[9].Visible = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 8);
                FlxInv.Cols[27].Caption = "Validity Date";
                FlxInv.Cols[38].Caption = "Totel";
                FlxInv.Cols[35].Caption = "Make No";
                FlxInv.Cols[36].Caption = VarGeneral.Settings_Sys.LineDetailNameE;
                FlxInv.Cols[36].Visible = VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 14);
                FlxInv.Cols[31].Caption = "Tax %";
                FlxInv.Cols[33].Caption = VarGeneral.Settings_Sys.LineGiftlNameE;
                FlxInv.Cols[33].Visible = VarGeneral.TString.ChkStatShow(_SysSetting.LineGiftSts, 14);
                FlxStkQty.Cols[0].Caption = "Store";
                FlxStkQty.Cols[1].Caption = "Quantity";
                FlxStkQty.Cols[2].Caption = "Store";
                FlxDat.Cols[0].Caption = "Expir Date";
                FlxDat.Cols[1].Caption = "Quantity";
                FlxDat.Cols[2].Caption = "Make No";
            }
            try
            {
                if (FlxInv.Cols[9].Visible)
                {
                    FlxInv.Cols[9].Visible = !VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 15);
                }
            }
            catch
            {
            }
            try
            {
                txtDiscountVal.IsInputReadOnly = VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 16);
                txtDiscountP.IsInputReadOnly = VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 16);
            }
            catch
            {
            }
            if (!VarGeneral.TString.ChkStatShow(_InvSetting.TaxOptions, 0))
            {
                FlxInv.Cols[31].Visible = false;
            }
            RibunButtons();
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
        private void ADD_Controls()
        {
            try
            {
                controls = new List<Control>();
                controls.Add(textBox_ID);
                codeControl = textBox_ID;
                controls.Add(textBox_Type);
                controls.Add(textBox1);
                controls.Add(textBox2);
                controls.Add(txtCustNet);
                controls.Add(txtCustRep);
                controls.Add(txtDiscountP);
                controls.Add(txtDiscountVal);
                controls.Add(txtDiscountValLoc);
                controls.Add(txtDueAmount);
                controls.Add(txtDueAmountLoc);
                controls.Add(txtGDate);
                controls.Add(txtHDate);
                controls.Add(txtInvCost);
                controls.Add(txtItemName);
                controls.Add(txtLCost);
                controls.Add(txtLPrice);
                controls.Add(txtRef);
                controls.Add(txtRemark);
                controls.Add(txtTime);
                controls.Add(txtTotalAm);
                controls.Add(txtTotalAmLoc);
                controls.Add(txtTotalQ);
                controls.Add(txtUnit);
                controls.Add(txtVCost);
                controls.Add(txtUnit);
                controls.Add(txtLPrice);
                controls.Add(CmbCostC);
                controls.Add(CmbCurr);
                controls.Add(checkBox_Chash);
                controls.Add(CmbInvPrice);
                controls.Add(CmbLegate);
                controls.Add(textBox_Usr);
                controls.Add(doubleInput_Rate);
                controls.Add(txtDebit1);
                controls.Add(txtCredit1);
                controls.Add(txtDebit1);
                controls.Add(txtCredit1);
                controls.Add(txtTotTax);
                controls.Add(txtTotTaxLoc);
                controls.Add(txtDebit5);
                controls.Add(txtCredit5);
                controls.Add(switchButton_Tax);
                controls.Add(checkBox_CostGaidTax);
                controls.Add(txtTotDis);
                controls.Add(txtTotDisLoc);
                controls.Add(txtDebit6);
                controls.Add(txtCredit6);
                controls.Add(switchButton_Dis);
                controls.Add(checkBox_GaidDis);
            }
            catch (SqlException)
            {
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
            if (data_this == null || data_this.InvNo == 0.ToString() || !ifOkDelete)
            {
                return;
            }
            if (data_this.IfRet == 1)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن حذف الفاتورة .. لانه مرتجع" : "You can not delete your invoice .. because it discards", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ifOkDelete = false;
                return;
            }
            data_this = db.StockInvHead(VarGeneral.InvTyp, DataThis.InvNo);
            IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
            try
            {
                db_ = Database.GetDatabase(VarGeneral.BranchCS);
                try
                {
                    db.ExecuteCommand("update T_INVHED set DeleteDate = '" + n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") + "',DeleteTime = '" + DateTime.Now.ToString("HH:mm") + "' where InvHed_ID=" + data_this.InvHed_ID);
                }
                catch
                {
                }
                db_.ClearParameters();
                db_.AddParameter("InvHed_ID", DbType.Int32, data_this.InvHed_ID);
                db_.ExecuteNonQuery(storedProcedure: true, "S_T_INVHED_DELETE");
                db_.StartTransaction();
                db_.ClearParameters();
                db_.AddParameter("gdhead_ID", DbType.Int32, _GdHead.gdhead_ID);
                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDHEAD_DELETE");
                db_.EndTransaction();
                db_.StartTransaction();
                db_.ClearParameters();
                db_.AddParameter("gdhead_ID", DbType.Int32, _GdHeadCostTax.gdhead_ID);
                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDHEAD_DELETE");
                db_.EndTransaction();
                db_.StartTransaction();
                db_.ClearParameters();
                db_.AddParameter("gdhead_ID", DbType.Int32, _GdHeadCostDis.gdhead_ID);
                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDHEAD_DELETE");
                db_.EndTransaction();
            }
            catch (SqlException)
            {
                data_this = db.StockInvHead(VarGeneral.InvTyp, DataThis.InvNo);
                return;
            }
            catch (Exception)
            {
                data_this = db.StockInvHead(VarGeneral.InvTyp, DataThis.InvNo);
                return;
            }
            Clear();
            RefreshPKeys();
            textBox_ID.Text = PKeys.LastOrDefault();
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
                GetInvSetting();
                textBox_ID.Text = db.MaxInvheadNo.ToString();
                FlxInv.Rows.Count = VarGeneral.Settings_Sys.LineOfInvoices.Value;
                State = FormState.New;
                if (_InvSetting.InvSetting.Substring(1, 1) == "1" && VarGeneral.SSSTyp != 0)
                {
                    txtCredit1.Tag = ((_InvSetting.AccCredit0.Trim() != "***") ? _InvSetting.AccCredit0.Trim() : "");
                    if (!string.IsNullOrEmpty(txtCredit1.Tag.ToString()))
                    {
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                        {
                            txtCredit1.Text = db.SelectAccRootByCode(txtCredit1.Tag.ToString()).Arb_Des;
                        }
                        else
                        {
                            txtCredit1.Text = db.SelectAccRootByCode(txtCredit1.Tag.ToString()).Eng_Des;
                        }
                    }
                    else
                    {
                        txtCredit1.Text = "";
                    }
                    txtDebit1.Tag = ((_InvSetting.AccDebit0.Trim() != "***") ? _InvSetting.AccDebit0.Trim() : "");
                    if (!string.IsNullOrEmpty(txtDebit1.Tag.ToString()))
                    {
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                        {
                            txtDebit1.Text = db.SelectAccRootByCode(txtDebit1.Tag.ToString()).Arb_Des;
                        }
                        else
                        {
                            txtDebit1.Text = db.SelectAccRootByCode(txtDebit1.Tag.ToString()).Eng_Des;
                        }
                    }
                    else
                    {
                        txtDebit1.Text = "";
                    }
                }
                try
                {
                    base.ActiveControl = FlxInv;
                    FlxInv.Row = 1;
                    FlxInv.Col = 1;
                }
                catch
                {
                }
                txtGDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                txtHDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                txtTime.Text = DateTime.Now.ToString("HH:mm");
                if (VarGeneral.SSSTyp != 0)
                {
                    if (_InvSetting.autoTaxGaid.Value)
                    {
                        checkBox_CostGaidTax.Checked = true;
                    }
                    if (_InvSetting.autoDisGaid.Value)
                    {
                        checkBox_GaidDis.Checked = true;
                    }
                }
            }
        }
        public void RefreshPKeys()
        {
            PKeys.Clear();
            try
            {
                PKeys = db.ExecuteQuery<string>("select InvNo from T_INVHED where InvTyp =" + VarGeneral.InvTyp + " and IfDel = 0 ", new object[0]).ToList();
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
            DGV_Main.PrimaryGrid.VirtualMode = true;
            Stock_DataDataContext db = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_INVHED> list = db.FillInvHead_2(VarGeneral.InvTyp, textBox_search.TextBox.Text).ToList();
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
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FMOpenQuantities));
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
                Button_PrintTable.Text = "عــرض";
                Button_PrintTable.Tooltip = "F5";
                Button_PrintTableMulti.Text = "طباعة الفواتير المحددة";
                buttonItem_Print.Text = ((_InvSetting.InvpRINTERInfo.nTyp.Substring(2, 1) == "0") ? "طباعة" : "عــرض");
                buttonItem_Print.Tooltip = "F5";
                Button_ExportTable2.Text = "تصدير";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "جميع السجلات";
                Label1.Text = "رقم الفاتورة :";
                Label2.Text = "التاريــــــــخ :";
                label7.Text = "رقم المرجع :";
                label19.Text = "العملــــــــة :";
                label18.Text = "المنـــــدوب :";
                label15.Text = "مركز التكلفـــــة :";
                label5.Text = "السعر المعتمــد :";
                label24.Text = "متوسط التكلفة";
                label23.Text = "آخر تكلفة";
                label25.Text = "الوحدة";
                label8.Text = "نسبة الخصم";
                Label26.Text = "قيمة الخصم";
                label17.Text = "قيمة الفاتـــورة :";
                label9.Text = "صافي الفاتورة :";
                label3.Text = "بالريــال";
                superTabItem_items.Text = "م.الصنف";
                superTabItem_Pay.Text = "السند المحاسبي";
                superTabItem_Note.Text = "ملاحظات";
                superTabItem_Detiles.Text = "تفاصيل";
                txtRemark.WatermarkText = "ملاحظات الفاتورة";
                label30.Text = "إجمالي الكمية :";
                label27.Text = "المستخدم :";
                checkBox_Chash.Text = "سند";
                labelD1.Text = "المـــدين :";
                labelC1.Text = "الدائـــن :";
                switchButton_Lock.OffText = "لم يتم الموافقة";
                switchButton_Lock.OnText = "تمت الموافقة";
                button_Repetition.Text = "تكرار";
                Button_BarcodPrint.Tooltip = "طباعة باركود";
                switchButton_Tax.OffText = "غير معتمد";
                switchButton_Tax.OnText = "معتمد";
                superTabItem_Tax.Text = "ضرائب";
                superTabItem_Dis.Text = "الخصـــــم";
                superTabItem_Gaids.Text = "سندات";
                switchButton_Dis.OffText = "+ السطــور";
                switchButton_Dis.OnText = "+ السطــور";
                switchButton_TaxLines.OnText = "سطور الضريبة";
                switchButton_TaxLines.OffText = "سطور الضريبة";
                switchButton_TaxByTotal.OnText = "إجمالي السطر";
                switchButton_TaxByTotal.OffText = "إجمالي السطر";
                switchButton_TaxByNet.OffText = "الصـافي";
                switchButton_TaxByNet.OffText = "الصـافي";
            }
            else
            {
                Button_First.Text = "First";
                Button_Last.Text = "Last";
                Button_Next.Text = "Next";
                Button_Prev.Text = "Previous";
                Button_Add.Text = "New";
                Button_Close.Text = "Close";
                Button_Delete.Text = "Del";
                Button_Save.Text = "Save";
                Button_Search.Text = "Srch";
                Button_First.Tooltip = "First Record";
                Button_Last.Tooltip = "Last Record";
                Button_Next.Tooltip = "Next Record";
                Button_Prev.Tooltip = "Previous Record";
                Button_Add.Tooltip = "F1";
                Button_Close.Tooltip = "Esc";
                Button_Delete.Tooltip = "F3";
                Button_Save.Tooltip = "F2";
                Button_Search.Tooltip = "F4";
                Button_PrintTable.Text = "Show";
                Button_PrintTable.Tooltip = "F5";
                Button_PrintTableMulti.Text = "Print of the invoices selected";
                buttonItem_Print.Text = ((_InvSetting.InvpRINTERInfo.nTyp.Substring(2, 1) == "0") ? "Print" : "Show");
                buttonItem_Print.Tooltip = "F5";
                Button_ExportTable2.Text = "Export";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "All Records";
                Label1.Text = "Invoice No :";
                Label2.Text = "Date :";
                label7.Text = "Reference No :";
                label19.Text = "Currncy :";
                label18.Text = "Delegate :";
                label15.Text = "Cost Center :";
                label5.Text = "Price Now : ";
                label24.Text = "Average Cost";
                label23.Text = "Last Cost :";
                label25.Text = "Unit";
                label8.Text = "Discount %";
                Label26.Text = "Dis value";
                label17.Text = "Invoice value :";
                label9.Text = "Invoice Net :";
                label3.Text = "Riyal";
                superTabItem_items.Text = "Item Info";
                superTabItem_Pay.Text = "Accounting";
                superTabItem_Note.Text = "Notes";
                superTabItem_Detiles.Text = "Details";
                txtRemark.WatermarkText = "Notes";
                label30.Text = "Total Quantity :";
                label27.Text = "User :";
                checkBox_Chash.Text = "Invoice";
                labelD1.Text = "Debtor :";
                labelC1.Text = "Creditor :";
                button_AllItems.Text = "ALL Items";
                button_SomeItems.Text = "By Category";
                groupPanel_Items.Text = "ADD";
                switchButton_Lock.OffText = "not approved";
                switchButton_Lock.OnText = "Been approved";
                Button_Export.Text = "Import";
                button_Repetition.Text = "Repetition";
                Button_BarcodPrint.Tooltip = "Barcode Print";
                switchButton_Tax.OffText = "certified";
                switchButton_Tax.OnText = "un certified";
                switchButton_Dis.OffText = "+ Lines";
                switchButton_Dis.OnText = "+ Lines";
                superTabItem_Tax.Text = "Taxes";
                superTabItem_Dis.Text = "Discount";
                superTabItem_Gaids.Text = "Bonds";
                switchButton_TaxLines.OnText = "Tax Lines";
                switchButton_TaxLines.OffText = "Tax Lines";
                switchButton_TaxByTotal.OnText = "Total Line";
                switchButton_TaxByTotal.OffText = "Total Line";
                switchButton_TaxByNet.OffText = "Inv Net";
                switchButton_TaxByNet.OffText = "Inv Net";
            }
        }
        private void FMOpenQuantities_Load(object sender, EventArgs e)
        {
            Location = Frm_Main.loc;
            if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 59))
            {
                switchButton_Lock.Visible = false;
            }
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FMOpenQuantities));
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
            ADD_Controls();
            Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
            _StorePr = permission.StorePrmission.Split(',').ToList();
            if (columns_Names_visible.Count == 0)
            {
                columns_Names_visible.Add("InvNo", new ColumnDictinary("رقم الفاتورة", "Invoice No", ifDefault: true, ""));
                columns_Names_visible.Add("SalsManNo", new ColumnDictinary("رقم البائع", "SalsMan No", ifDefault: false, ""));
                columns_Names_visible.Add("HDat", new ColumnDictinary("التاريخ الهجري", "Date Hijri", ifDefault: true, ""));
                columns_Names_visible.Add("GDat", new ColumnDictinary("التاريخ الميلادي", "Date Gregorian", ifDefault: true, ""));
                columns_Names_visible.Add("InvTotLocCur", new ColumnDictinary("إجمالي الفاتورة", "Invoice Total", ifDefault: false, ""));
                columns_Names_visible.Add("InvNetLocCur", new ColumnDictinary("صافي الفاتورة", "Invoice Net", ifDefault: true, ""));
                columns_Names_visible.Add("InvQty", new ColumnDictinary("إجمالي الكمية", "Quantity Total", ifDefault: true, ""));
                columns_Names_visible.Add("InvDisPrs", new ColumnDictinary("الخصم نسبة", "Discount Percentage", ifDefault: false, ""));
                columns_Names_visible.Add("InvDisValLocCur", new ColumnDictinary("الخصم قيمة", "Discount value", ifDefault: true, ""));
                columns_Names_visible.Add("GadeNo", new ColumnDictinary("رقم القيد المحاسبي", "Gaid No", ifDefault: false, ""));
                columns_Names_visible.Add("Remark", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, ""));
            }
            else
            {
                Clear();
                textBox_ID.Text = "";
                TextBox_Index.TextBox.Text = "";
            }
            FillCombo();
            GetInvSetting();
            ArbEng();
            RefreshPKeys();
            textBox_ID.Text = PKeys.FirstOrDefault();
            listUnit = new List<T_Unit>();
            listStore = new List<T_Store>();
            listUnit = db.FillUnit_2("").ToList();
            listStore = db.FillStore_2("").ToList();
            FlxStkQty.Rows.Count = listStore.Count + 1;
            string Co = "";
            for (int iiCnt = 0; iiCnt < listStore.Count; iiCnt++)
            {
                _Store = listStore[iiCnt];
                FlxStkQty.SetData(iiCnt + 1, 0, _Store.Stor_ID.ToString());
                FlxStkQty.SetData(iiCnt + 1, 2, ((LangArEn == 0) ? _Store.Arb_Des : _Store.Eng_Des).ToString());
                FlxStkQty.SetData(iiCnt + 1, 2, ((LangArEn == 0) ? _Store.Arb_Des : _Store.Eng_Des).ToString());
                Co = ((!(Co != "")) ? _Store.Stor_ID.ToString() : (Co + "|" + _Store.Stor_ID));
            }
            FlxInv.Cols[6].ComboList = Co;
            int? calendr = _SysSetting.Calendr;
            if (calendr.Value == 0 && calendr.HasValue)
            {
                txtGDate.BringToFront();
            }
            else
            {
                txtHDate.BringToFront();
            }
            if (VarGeneral.vDemo)
            {
                IfDelete = false;
            }
            if (_InvSetting.InvSetting.Substring(1, 1) == "0")
            {
                txtDebit1.ButtonCustom.Enabled = false;
                txtCredit1.ButtonCustom.Enabled = false;
            }
            if (VarGeneral.SSSTyp == 0)
            {
                txtDebit1.Visible = false;
                txtCredit1.Visible = false;
                labelD1.Visible = false;
                labelC1.Visible = false;
                superTabItem_Pay.Visible = false;
                txtDebit5.Visible = false;
                txtCredit5.Visible = false;
                checkBox_CostGaidTax.Visible = false;
                label35.Visible = false;
                label34.Visible = false;
                txtDebit6.Visible = false;
                label31.Visible = false;
                txtCredit6.Visible = false;
                label37.Visible = false;
                checkBox_GaidDis.Visible = false;
                label35.Visible = false;
                label34.Visible = false;
            }
            label24.Visible = false;
            label23.Visible = false;
            label22.Visible = false;
            label25.Visible = false;
            txtVCost.Visible = false;
            txtUnit.Visible = false;
            txtLCost.Visible = false;
            txtLPrice.Visible = false;
            try
            {
                textBox_ID.ReadOnly = true;
                if (!VarGeneral.TString.ChkStatShow(permission.SetStr, 43))
                {
                    textBox_ID.Enabled = false;
                }
            }
            catch
            {
            }
            UpdateVcr();
            FlxInv.DrawMode = DrawModeEnum.OwnerDraw;
            FlxInv.OwnerDrawCell += _ownerDraw;
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptBus.dll"))
            {
                label15.Text = ((LangArEn == 0) ? "الباص : " : "Bus :");
                label18.Text = ((LangArEn == 0) ? "السائق :" : "Driver :");
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptTegnicalCollage.dll"))
            {
                TegnicalCollage();
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptWaterPackages.dll"))
            {
                label15.Text = ((LangArEn == 0) ? "السيارة : " : "Car :");
                label18.Text = ((LangArEn == 0) ? "العميــــل :" : "Customer :");
            }
        }
        private void TegnicalCollage()
        {
            label18.Visible = false;
            CmbLegate.Visible = false;
        }
        private void _ownerDraw(object sender, OwnerDrawCellEventArgs e)
        {
            if (e.Col == 0 && e.Row > 0)
            {
                e.Text = e.Row.ToString();
            }
        }
        private void Button_ExportTable2_Click(object sender, EventArgs e)
        {
            try
            {
                ExportExcel.ExportToExcel(DGV_Main, "تقرير فواتير بضاعة أول المدة");
            }
            catch
            {
            }
        }
        private void TextBox_Search_ButtonCustomClick(object sender, EventArgs e)
        {
            textBox_search.Text = "";
        }
        private void DGV_Main_AfterCheck(object sender, GridAfterCheckEventArgs e)
        {
            DGV_Main.PrimaryGrid.VirtualMode = false;
            GridRow crow = e.Item as GridRow;
            if (crow != null && crow.Checked)
            {
                GridPanel panel = new GridPanel();
                var q = db.StockInvHead(VarGeneral.InvTyp, crow.Cells["InvNo"].Value.ToString()).T_INVDETs.Select((T_INVDET item) => new
                {
                    item.ItmNo,
                    item.ItmDes,
                    item.ItmDesE,
                    item.ItmUnt,
                    item.ItmUntE,
                    item.StoreNo,
                    item.Cost,
                    item.Qty,
                    item.Price,
                    item.ItmDis,
                    item.Amount
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
            panel.Columns["InvNo"].Width = 150;
            panel.Columns["InvNo"].Visible = columns_Names_visible["InvNo"].IfDefault;
            panel.Columns["SalsManNo"].Width = 100;
            panel.Columns["SalsManNo"].Visible = columns_Names_visible["SalsManNo"].IfDefault;
            panel.Columns["HDat"].Width = 100;
            panel.Columns["HDat"].Visible = columns_Names_visible["HDat"].IfDefault;
            panel.Columns["GDat"].Width = 100;
            panel.Columns["GDat"].Visible = columns_Names_visible["GDat"].IfDefault;
            panel.Columns["InvTotLocCur"].Width = 150;
            panel.Columns["InvTotLocCur"].Visible = columns_Names_visible["InvTotLocCur"].IfDefault;
            panel.Columns["InvNetLocCur"].Width = 150;
            panel.Columns["InvNetLocCur"].Visible = columns_Names_visible["InvNetLocCur"].IfDefault;
            panel.Columns["InvQty"].Width = 150;
            panel.Columns["InvQty"].Visible = columns_Names_visible["InvQty"].IfDefault;
            panel.Columns["InvDisPrs"].Width = 100;
            panel.Columns["InvDisPrs"].Visible = columns_Names_visible["InvDisPrs"].IfDefault;
            panel.Columns["InvDisValLocCur"].Width = 100;
            panel.Columns["InvDisValLocCur"].Visible = columns_Names_visible["InvDisValLocCur"].IfDefault;
            panel.Columns["GadeNo"].Width = 130;
            panel.Columns["GadeNo"].Visible = columns_Names_visible["GadeNo"].IfDefault;
            panel.Columns["Remark"].Width = 400;
            panel.Columns["Remark"].Visible = columns_Names_visible["Remark"].IfDefault;
        }
        private void PropLOfferPanel(GridPanel panel)
        {
            panel.ColumnAutoSizeMode = ColumnAutoSizeMode.DisplayedCells;
            panel.Columns["ItmNo"].HeaderText = ((LangArEn == 0) ? "رقم الصنف" : "Item No");
            panel.Columns["ItmDes"].HeaderText = ((LangArEn == 0) ? "الوصف " : "Description");
            panel.Columns["ItmDesE"].HeaderText = ((LangArEn == 0) ? "الوصف" : "Description");
            panel.Columns["ItmUnt"].HeaderText = ((LangArEn == 0) ? "الوحدة" : "Unit");
            panel.Columns["ItmUntE"].HeaderText = ((LangArEn == 0) ? "الوحدة" : "Unit");
            panel.Columns["StoreNo"].HeaderText = ((LangArEn == 0) ? "المستودع" : "Store");
            panel.Columns["Qty"].HeaderText = ((LangArEn == 0) ? "الكمية" : "Qrt.");
            panel.Columns["Cost"].HeaderText = ((LangArEn == 0) ? "التكلفة" : "Cost");
            panel.Columns["Price"].HeaderText = ((LangArEn == 0) ? "السعر" : "Price");
            panel.Columns["ItmDis"].HeaderText = ((LangArEn == 0) ? "الخصم" : "Discount");
            panel.Columns["Amount"].HeaderText = ((LangArEn == 0) ? "الاجمالي" : "Total");
            panel.Footer.Text = ((LangArEn == 0) ? "عدد الأسطر: " : "Lines Count: ") + panel.Rows.Count;
            panel.ReadOnly = true;
            panel.ShowRowDirtyMarker = true;
            panel.ColumnHeader.RowHeight = 30;
            for (int i = 0; i < panel.Columns.Count; i++)
            {
                panel.Columns[i].AutoSizeMode = ColumnAutoSizeMode.AllCells;
            }
            panel.Columns[1].Width = 160;
            panel.Columns[2].Width = 300;
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                panel.Columns["ItmDesE"].Visible = false;
                panel.Columns["ItmUntE"].Visible = false;
                panel.Columns["ItmDes"].Visible = true;
                panel.Columns["ItmUnt"].Visible = true;
            }
            else
            {
                panel.Columns["ItmDes"].Visible = false;
                panel.Columns["ItmUnt"].Visible = false;
                panel.Columns["ItmDesE"].Visible = true;
                panel.Columns["ItmUntE"].Visible = true;
            }
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
                    TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(data_this.InvNo ?? "") + 1);
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
            _GdAuto = new T_GdAuto();
            _InvSetting = db.StockInvSetting(VarGeneral.UserID, VarGeneral.InvTyp);
            _SysSetting = db.SystemSettingStock();
            _GdAuto = db.GdAutoStock();
            _Company = db.StockCompanyList().FirstOrDefault();
            _InvSettingBarCod = db.StockInvSetting(VarGeneral.UserID, 22);
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
                if (!_StopMove)
                {
                    return;
                }
                T_INVHED newData = db.StockInvHead(VarGeneral.InvTyp, no);
                if (newData == null || string.IsNullOrEmpty(newData.InvNo))
                {
                    if (!Button_Add.Visible || !Button_Add.Enabled)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textBox_ID.TextChanged -= textBox_ID_TextChanged;
                        try
                        {
                            textBox_ID.Text = data_this.InvNo;
                        }
                        catch
                        {
                        }
                        textBox_ID.TextChanged += textBox_ID_TextChanged;
                        return;
                    }
                    Clear();
                    txtGDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                    txtHDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                    txtTime.Text = DateTime.Now.ToString("HH:mm");
                    GetInvSetting();
                    FlxInv.Rows.Count = VarGeneral.Settings_Sys.LineOfInvoices.Value;
                    State = FormState.New;
                    if (_InvSetting.InvSetting.Substring(1, 1) == "1" && VarGeneral.SSSTyp != 0)
                    {
                        txtCredit1.Tag = ((_InvSetting.AccCredit0.Trim() != "***") ? _InvSetting.AccCredit0.Trim() : "");
                        if (!string.IsNullOrEmpty(txtCredit1.Tag.ToString()))
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                            {
                                txtCredit1.Text = db.SelectAccRootByCode(txtCredit1.Tag.ToString()).Arb_Des;
                            }
                            else
                            {
                                txtCredit1.Text = db.SelectAccRootByCode(txtCredit1.Tag.ToString()).Eng_Des;
                            }
                        }
                        else
                        {
                            txtCredit1.Text = "";
                        }
                        txtDebit1.Tag = ((_InvSetting.AccDebit0.Trim() != "***") ? _InvSetting.AccDebit0.Trim() : "");
                        if (!string.IsNullOrEmpty(txtDebit1.Tag.ToString()))
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                            {
                                txtDebit1.Text = db.SelectAccRootByCode(txtDebit1.Tag.ToString()).Arb_Des;
                            }
                            else
                            {
                                txtDebit1.Text = db.SelectAccRootByCode(txtDebit1.Tag.ToString()).Eng_Des;
                            }
                        }
                        else
                        {
                            txtDebit1.Text = "";
                        }
                    }
                    TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                    TextBox_Index.TextBox.Text = string.Concat(PKeys.Count + 1);
                    TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                }
                else
                {
                    DataThis = newData;
                    int indexA = PKeys.IndexOf(newData.InvNo ?? "");
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
            FlxDat.Visible = false;
            UpdateVcr();
            if (State == FormState.Saved)
            {
                button_Repetition.Enabled = true;
                Button_BarcodPrint.Enabled = true;
                Button_PrintTableMulti.Enabled = true;
            }
            else
            {
                button_Repetition.Enabled = false;
                Button_BarcodPrint.Enabled = false;
                Button_PrintTableMulti.Enabled = false;
            }
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
        private void txtHDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtHDate.Text))
                {
                    txtHDate.Text = Convert.ToDateTime(txtHDate.Text).ToString("yyyy/MM/dd");
                    txtHDate.Text = n.FormatHijri(txtHDate.Text, "yyyy/MM/dd");
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 77))
                    {
                        txtGDate.Text = n.HijriToGreg(txtHDate.Text, "yyyy/MM/dd");
                    }
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
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 77))
                    {
                        txtHDate.Text = n.GregToHijri(txtGDate.Text, "yyyy/MM/dd");
                    }
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
        private void GetInvTot()
        {
            double InvTot = 0.0;
            double InvCost = 0.0;
            double InvQty = 0.0;
            double InvDis = 0.0;
            double InvTax = 0.0;
            double ItmDisCount = 0.0;
            if (State == FormState.Saved)
            {
                return;
            }
            InvDis = double.Parse(VarGeneral.TString.TEmpty(txtDiscountVal.Text));
            for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
            {
                try
                {
                    InvTot += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38))));
                    InvCost += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 10)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 12))));
                    InvQty += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7))));
                    if (switchButton_TaxByTotal.Value)
                    {
                        double DisVal = 0.0;
                        try
                        {
                            DisVal = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 9)))) / 100.0);
                        }
                        catch
                        {
                        }
                        InvTax += (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) - DisVal) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 31)))) / 100.0);
                    }
                    else
                    {
                        InvTax += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 31)))) / 100.0);
                    }
                    ItmDisCount += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 9)))) / 100.0);
                }
                catch
                {
                }
            }
            txtTotalAm.Text = VarGeneral.TString.TEmpty(Math.Round(InvTot * RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
            txtDueAmount.Text = VarGeneral.TString.TEmpty(Math.Round((InvTot - InvDis) * RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
            txtTotalQ.Text = VarGeneral.TString.TEmpty(InvQty.ToString());
            txtInvCost.Text = VarGeneral.TString.TEmpty(Math.Round(InvCost, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
            txtCustNet.Text = VarGeneral.TString.TEmpty(Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(txtCustRep.Value))) + double.Parse(txtDueAmountLoc.Text), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
            txtTotalAmLoc.Text = VarGeneral.TString.TEmpty(Math.Round(InvTot, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
            txtDueAmountLoc.Text = VarGeneral.TString.TEmpty(Math.Round(InvTot - InvDis, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
            double Tax_Per = 0.0;
            try
            {
                Tax_Per = double.Parse(textBoxItem_TaxByNetValue.Text);
            }
            catch
            {
                Tax_Per = 0.0;
            }
            if (switchButton_TaxByNet.Value)
            {
                InvTax = ((!(Tax_Per <= 0.0) && !(txtDueAmountLoc.Value <= 0.0)) ? Math.Round(txtDueAmountLoc.Value * Tax_Per / 100.0, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) : 0.0);
            }
            txtTotTax.Text = VarGeneral.TString.TEmpty(Math.Round(InvTax, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
            txtTotTaxLoc.Text = VarGeneral.TString.TEmpty(Math.Round(InvTax * RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
            if (switchButton_TaxLines.Value)
            {
                if (!switchButton_Tax.Value)
                {
                    txtDueAmount.Text = VarGeneral.TString.TEmpty(Math.Round((InvTot - InvTax - InvDis) * RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
                }
                if (!switchButton_Tax.Value)
                {
                    txtDueAmountLoc.Text = VarGeneral.TString.TEmpty(Math.Round(InvTot - InvTax - InvDis, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
                }
                if (switchButton_TaxByNet.Value && InvTax > 0.0)
                {
                    if (switchButton_Tax.Value)
                    {
                        txtDueAmount.Text = VarGeneral.TString.TEmpty(Math.Round((InvTot + InvTax - InvDis) * RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
                    }
                    if (switchButton_Tax.Value)
                    {
                        txtDueAmountLoc.Text = VarGeneral.TString.TEmpty(Math.Round(InvTot + InvTax - InvDis, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
                    }
                }
            }
            else
            {
                if (switchButton_Tax.Value)
                {
                    txtDueAmount.Text = VarGeneral.TString.TEmpty(Math.Round((InvTot + InvTax - InvDis) * RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
                }
                if (switchButton_Tax.Value)
                {
                    txtDueAmountLoc.Text = VarGeneral.TString.TEmpty(Math.Round(InvTot + InvTax - InvDis, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
                }
            }
            txtTotDis.Value = (switchButton_Dis.Value ? (txtDiscountVal.Value + ItmDisCount) : txtDiscountVal.Value);
            txtTotDisLoc.Value = (switchButton_Dis.Value ? (txtDiscountValLoc.Value + ItmDisCount) : txtDiscountValLoc.Value);
            try
            {
                if (switchButton_Dis.Value && ItmDisCount > 0.0)
                {
                    txtTotalAm.Value += Math.Round(ItmDisCount * RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    txtTotalAmLoc.Value += Math.Round(ItmDisCount, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                }
            }
            catch
            {
            }
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 56))
            {
                txtTotalAm.Value = Math.Round(txtTotalAm.Value, 0);
                txtDueAmount.Value = Math.Round(txtDueAmount.Value, 0);
                txtTotalAmLoc.Value = Math.Round(txtTotalAmLoc.Value, 0);
                txtDueAmountLoc.Value = Math.Round(txtDueAmountLoc.Value, 0);
            }
        }
        private void CmbCurr_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CmbCurr.SelectedIndex == -1)
                {
                    return;
                }
                _Curency = db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString()));
                try
                {
                    if (CmbCurr.SelectedValue.ToString() == VarGeneral.Settings_Sys.ImportIp.ToString())
                    {
                        RateValue = 1.0;
                        doubleInput_Rate.Value = 1.0;
                    }
                    else
                    {
                        RateValue = _Curency.Rate.Value;
                        try
                        {
                            doubleInput_Rate.Value = _Curency.Rate.Value;
                        }
                        catch
                        {
                        }
                    }
                }
                catch
                {
                    RateValue = _Curency.Rate.Value;
                    try
                    {
                        doubleInput_Rate.Value = _Curency.Rate.Value;
                    }
                    catch
                    {
                    }
                }
                try
                {
                    GetInvTot();
                    txtDiscountVal_Leave(sender, e);
                }
                catch
                {
                }
            }
            catch
            {
            }
        }
        private void txtDiscountP_Leave(object sender, EventArgs e)
        {
            if (State != 0)
            {
                txtDiscountVal.Value = txtTotalAmLoc.Value * (txtDiscountP.Value / 100.0);
                txtDiscountValLoc.Value = txtDiscountVal.Value * RateValue;
                GetInvTot();
            }
        }
        private void txtDiscountVal_Leave(object sender, EventArgs e)
        {
            if (State == FormState.Saved)
            {
                return;
            }
            try
            {
                if (txtTotalAm.Value > 0.0)
                {
                    txtDiscountP.Value = Math.Round(txtDiscountVal.Value / txtTotalAmLoc.Value * 100.0, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                }
            }
            catch
            {
            }
            txtDiscountValLoc.Value = txtDiscountVal.Value * RateValue;
            GetInvTot();
        }
        private bool ChkBarCod(string BarCod)
        {
            DefPack = 0;
            T_Item _ItmBarCod = new T_Item();
            listItems = db.FillItemBarCode_2(BarCod).ToList();
            for (int iiCnt = 0; iiCnt < listItems.Count; iiCnt++)
            {
                _ItmBarCod = listItems[iiCnt];
                if (BarCod == _ItmBarCod.BarCod1)
                {
                    _Items = _ItmBarCod;
                    DefPack = 1;
                    return true;
                }
                if (BarCod == _ItmBarCod.BarCod2)
                {
                    _Items = _ItmBarCod;
                    DefPack = 2;
                    return true;
                }
                if (BarCod == _ItmBarCod.BarCod3)
                {
                    _Items = _ItmBarCod;
                    DefPack = 3;
                    return true;
                }
                if (BarCod == _ItmBarCod.BarCod4)
                {
                    _Items = _ItmBarCod;
                    DefPack = 4;
                    return true;
                }
                if (BarCod == _ItmBarCod.BarCod5)
                {
                    _Items = _ItmBarCod;
                    DefPack = 5;
                    return true;
                }
            }
            return false;
        }
        private void txtTime_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckTime(txtTime.Text))
                {
                    txtTime.Text = TimeSpan.Parse(txtTime.Text).ToString();
                }
                else
                {
                    txtTime.Text = DateTime.Now.ToString("HH:mm");
                }
            }
            catch
            {
                txtTime.Text = DateTime.Now.ToString("HH:mm");
            }
        }
        private void txtHDate_Click(object sender, EventArgs e)
        {
            txtHDate.SelectAll();
        }
        private void FMOpenQuantities_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                label24.Visible = false;
                label23.Visible = false;
                label22.Visible = false;
                label25.Visible = false;
                txtVCost.Visible = false;
                txtUnit.Visible = false;
                txtLCost.Visible = false;
                txtLPrice.Visible = false;
            }
            else if (e.KeyCode == Keys.Alt)
            {
                label24.Visible = false;
                label23.Visible = false;
                label22.Visible = false;
                label25.Visible = false;
                txtVCost.Visible = false;
                txtUnit.Visible = false;
                txtLCost.Visible = false;
                txtLPrice.Visible = false;
            }
        }
        private void FlxInv_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            try
            {
                if (FlxInv.Row > 0 && FlxInv.Col == 36 && VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 66))
                {
                    FlxInv.BeforeEdit -= FlxInv_BeforeEdit;
                    int vRowIndex = FlxInv.Row;
                    FrmInvDetNoteSrch frm = new FrmInvDetNoteSrch();
                    frm.Tag = LangArEn;
                    try
                    {
                        frm.textbox_Detailes.Text = FlxInv.GetData(vRowIndex, 36).ToString() ?? "";
                    }
                    catch
                    {
                        frm.textbox_Detailes.Text = "";
                    }
                    frm.TopMost = true;
                    frm.ShowDialog();
                    if (frm.SerachNo != "")
                    {
                        FlxInv.SetData(vRowIndex, 36, "");
                        FlxInv.SetData(vRowIndex, 36, FlxInv.GetData(vRowIndex, 36).ToString() + frm.SerachNo);
                    }
                    SendKeys.SendWait("{ENTER}");
                    FlxInv.BeforeEdit += FlxInv_BeforeEdit;
                }
            }
            catch
            {
                FlxInv.BeforeEdit += FlxInv_BeforeEdit;
            }
        }
        private void FillCombo()
        {
            int _CmbIndex = CmbInvPrice.SelectedIndex;
            CmbInvPrice.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                CmbInvPrice.Items.Add("");
                CmbInvPrice.Items.Add("آخر تكلفة");
                CmbInvPrice.Items.Add("متوسط التكلفة");
                CmbInvPrice.Items.Add("التكلفة الأفتتاحية");
                CmbInvPrice.Items.Add("أول تكلفة");
            }
            else
            {
                CmbInvPrice.Items.Add("");
                CmbInvPrice.Items.Add("Last Cost");
                CmbInvPrice.Items.Add("Average Cost");
                CmbInvPrice.Items.Add("Open Cost");
                CmbInvPrice.Items.Add("First Cost");
            }
            CmbInvPrice.SelectedIndex = _CmbIndex;
            _CmbIndex = CmbCurr.SelectedIndex;
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
        public void SetData(T_INVHED value)
        {
            switchButton_Lock.ValueChanged -= switchButton_Lock_ValueChanged;
            if (!RepetitionSts && !ReverseSts)
            {
                State = FormState.Saved;
                Button_Save.Enabled = false;
                textBox_ID.ButtonCustom.Visible = true;
                textBox_ID.Tag = value.InvHed_ID;
                try
                {
                    if (VarGeneral.CheckDate(value.GDat))
                    {
                        txtGDate.Text = Convert.ToDateTime(value.GDat).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        txtGDate.Text = n.FormatGreg(value.GDat, "yyyy/MM/dd");
                    }
                }
                catch
                {
                    txtGDate.Text = value.GDat;
                }
                try
                {
                    if (VarGeneral.CheckDate(value.HDat))
                    {
                        txtHDate.Text = Convert.ToDateTime(value.HDat).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        txtHDate.Text = n.FormatHijri(value.HDat, "yyyy/MM/dd");
                    }
                }
                catch
                {
                    txtHDate.Text = value.HDat;
                }
                if (VarGeneral.CheckTime(value.LTim))
                {
                    txtTime.Text = value.LTim;
                }
            }
            txtRemark.Text = value.Remark;
            txtDiscountP.Value = value.InvDisPrs.Value;
            txtDiscountVal.Value = value.InvDisVal.Value;
            txtDiscountValLoc.Value = value.InvDisValLocCur.Value;
            txtDueAmount.Value = value.InvNet.Value;
            txtDueAmountLoc.Value = value.InvNetLocCur.Value;
            txtRef.Text = value.RefNo;
            txtTotalAm.Value = value.InvTot.Value;
            txtTotalAmLoc.Value = value.InvTotLocCur.Value;
            txtTotalQ.Value = value.InvQty.Value;
            txtCustNet.Value = value.CustNet.Value;
            txtCustRep.Value = value.CustRep.Value;
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
                            label_LockeName.Text = ((LangArEn == 0) ? ("أقفلها المسؤول : \n" + dbc.RateUsr(data_this.SalsManNam).UsrNamA) : ("Closed By :\n" + dbc.RateUsr(data_this.SalsManNam).UsrNamE));
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
                textBox_Usr.Text = ((LangArEn == 0) ? dbc.RateUsr(value.SalsManNo).UsrNamA : dbc.RateUsr(value.SalsManNo).UsrNamE);
            }
            for (int iiCnt = 0; iiCnt < CmbCostC.Items.Count; iiCnt++)
            {
                CmbCostC.SelectedIndex = iiCnt;
                if (CmbCostC.SelectedValue != null && CmbCostC.SelectedValue.ToString() == value.InvCstNo.Value.ToString())
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
            if (CmbCurr.SelectedIndex != -1)
            {
                RateValue = db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value;
            }
            if (value.MndNo.HasValue)
            {
                CmbLegate.SelectedValue = value.MndNo;
            }
            else
            {
                CmbLegate.SelectedIndex = 0;
            }
            if (value.CustPri.HasValue)
            {
                CmbInvPrice.SelectedIndex = value.CustPri.Value;
            }
            if (value.InvCashPay.HasValue)
            {
                int? invCashPay = value.InvCashPay;
                if (invCashPay.Value == 0 && invCashPay.HasValue)
                {
                    checkBox_Chash.Checked = true;
                }
            }
            LDataThis = new BindingList<T_INVDET>(value.T_INVDETs).ToList();
            txtDebit1.Text = "";
            txtCredit1.Text = "";
            if (value.GadeId.HasValue)
            {
                listGdHead = db.StockGdHeadid((int)value.GadeId.Value);
                if (listGdHead.Count != 0)
                {
                    _GdHead = listGdHead[0];
                    listGdDet = _GdHead.T_GDDETs.ToList();
                    for (int i = 0; i < listGdDet.Count; i++)
                    {
                        if (listGdDet[i].gdValue > 0.0)
                        {
                            txtDebit1.Tag = listGdDet[i].AccNo;
                            txtDebit1.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(listGdDet[i].AccNo).Arb_Des : db.SelectAccRootByCode(listGdDet[i].AccNo).Eng_Des);
                        }
                        else
                        {
                            txtCredit1.Tag = listGdDet[i].AccNo;
                            txtCredit1.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(listGdDet[i].AccNo).Arb_Des : db.SelectAccRootByCode(listGdDet[i].AccNo).Eng_Des);
                        }
                    }
                }
                else
                {
                    _GdHead = new T_GDHEAD();
                }
            }
            txtDebit5.Text = "";
            txtCredit5.Text = "";
            txtTotTax.Value = value.InvAddTax.Value;
            txtTotTaxLoc.Value = value.InvAddTaxlLoc.Value;
            switchButton_Tax.ValueChanged -= switchButton_Tax_ValueChanged;
            if (value.IsTaxUse.Value)
            {
                switchButton_Tax.Value = true;
            }
            else
            {
                switchButton_Tax.Value = false;
            }
            switchButton_Tax.ValueChanged += switchButton_Tax_ValueChanged;
            switchButton_TaxLines.ValueChanged -= switchButton_TaxLines_ValueChanged;
            if (value.IsTaxLines.Value)
            {
                switchButton_TaxLines.Value = true;
            }
            else
            {
                switchButton_TaxLines.Value = false;
            }
            if (value.IsTaxByTotal.Value)
            {
                switchButton_TaxByTotal.Value = true;
            }
            else
            {
                switchButton_TaxByTotal.Value = false;
            }
            if (value.IsTaxByNet.Value)
            {
                switchButton_TaxByNet.Value = true;
            }
            else
            {
                switchButton_TaxByNet.Value = false;
            }
            textBoxItem_TaxByNetValue.Text = value.TaxByNetValue.Value.ToString();
            switchButton_TaxLines.ValueChanged += switchButton_TaxLines_ValueChanged;
            if (value.IsTaxGaid.HasValue)
            {
                checkBox_CostGaidTax.Checked = value.IsTaxGaid.Value;
            }
            else
            {
                checkBox_CostGaidTax_CheckedChanged(null, null);
            }
            if (value.TaxGaidID.HasValue)
            {
                listGdHeadCostTax = db.StockGdHeadid((int)value.TaxGaidID.Value);
                if (listGdHeadCostTax.Count != 0)
                {
                    _GdHeadCostTax = listGdHeadCostTax[0];
                    listGdDetCostTax = _GdHeadCostTax.T_GDDETs.ToList();
                    for (int i = 0; i < listGdDetCostTax.Count; i++)
                    {
                        if (listGdDetCostTax[i].gdValue > 0.0)
                        {
                            txtDebit5.Tag = listGdDetCostTax[i].AccNo;
                            txtDebit5.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(listGdDetCostTax[i].AccNo).Arb_Des : db.SelectAccRootByCode(listGdDetCostTax[i].AccNo).Eng_Des);
                        }
                        else
                        {
                            txtCredit5.Tag = listGdDetCostTax[i].AccNo;
                            txtCredit5.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(listGdDetCostTax[i].AccNo).Arb_Des : db.SelectAccRootByCode(listGdDetCostTax[i].AccNo).Eng_Des);
                        }
                    }
                }
                else
                {
                    _GdHeadCostTax = new T_GDHEAD();
                }
            }
            txtDebit6.Text = "";
            txtCredit6.Text = "";
            txtTotDis.Value = value.InvValGaidDis.Value;
            txtTotDisLoc.Value = value.InvValGaidDislLoc.Value;
            switchButton_Dis.ValueChanged -= switchButton_Dis_ValueChanged;
            if (value.IsDisUse1.Value)
            {
                switchButton_Dis.Value = true;
            }
            else
            {
                switchButton_Dis.Value = false;
            }
            switchButton_Dis.ValueChanged += switchButton_Dis_ValueChanged;
            if (value.IsDisGaid.HasValue)
            {
                checkBox_GaidDis.Checked = value.IsDisGaid.Value;
            }
            else
            {
                checkBox_GaidDis_CheckedChanged(null, null);
            }
            if (value.DisGaidID1.HasValue)
            {
                listGdHeadCostDis = db.StockGdHeadid((int)value.DisGaidID1.Value);
                if (listGdHeadCostDis.Count != 0)
                {
                    _GdHeadCostDis = listGdHeadCostDis[0];
                    listGdDetCostDis = _GdHeadCostDis.T_GDDETs.ToList();
                    for (int i = 0; i < listGdDetCostDis.Count; i++)
                    {
                        if (listGdDetCostDis[i].gdValue > 0.0)
                        {
                            txtDebit6.Tag = listGdDetCostDis[i].AccNo;
                            txtDebit6.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(listGdDetCostDis[i].AccNo).Arb_Des : db.SelectAccRootByCode(listGdDetCostDis[i].AccNo).Eng_Des);
                        }
                        else
                        {
                            txtCredit6.Tag = listGdDetCostDis[i].AccNo;
                            txtCredit6.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(listGdDetCostDis[i].AccNo).Arb_Des : db.SelectAccRootByCode(listGdDetCostDis[i].AccNo).Eng_Des);
                        }
                    }
                }
                else
                {
                    _GdHeadCostDis = new T_GDHEAD();
                }
            }
            SetLines(LDataThis);
            switchButton_Lock.ValueChanged += switchButton_Lock_ValueChanged;
        }
        public void SetLines(List<T_INVDET> listDet)
        {
            try
            {
                if (!RepetitionSts && !ReverseSts)
                {
                    FlxInv.Rows.Count = listDet.Count + 1;
                }
                FlxInv.Cols[27].Visible = false;
                FlxInv.Cols[35].Visible = false;
                for (int iiCnt = 1; iiCnt <= listDet.Count; iiCnt++)
                {
                    _InvDet = listDet[iiCnt - 1];
                    int Ser = _InvDet.InvSer.GetValueOrDefault();
                    FlxInv.SetData(iiCnt, 0, Ser.ToString());
                    FlxInv.SetData(iiCnt, 1, _InvDet.ItmNo.Trim());
                    FlxInv.SetData(iiCnt, 2, _InvDet.ItmDes.ToString());
                    FlxInv.SetData(iiCnt, 3, _InvDet.ItmUnt.ToString());
                    FlxInv.SetData(iiCnt, 4, _InvDet.ItmDesE.ToString());
                    FlxInv.SetData(iiCnt, 5, _InvDet.ItmUntE.ToString());
                    FlxInv.SetData(iiCnt, 6, _InvDet.StoreNo.Value);
                    FlxInv.SetData(iiCnt, 7, Math.Abs((decimal)_InvDet.Qty.Value));
                    FlxInv.SetData(iiCnt, 8, _InvDet.Price.Value);
                    FlxInv.SetData(iiCnt, 9, _InvDet.ItmDis);
                    FlxInv.SetData(iiCnt, 10, _InvDet.Cost.Value);
                    FlxInv.SetData(iiCnt, 11, _InvDet.ItmUntPak.Value);
                    FlxInv.SetData(iiCnt, 12, Math.Abs((decimal)_InvDet.RealQty.Value));
                    FlxInv.SetData(iiCnt, 13, _InvDet.itmInvDsc.Value);
                    FlxInv.SetData(iiCnt, 14, _InvDet.Cost.Value);
                    FlxInv.SetData(iiCnt, 15, _InvDet.ItmDes.ToString());
                    FlxInv.SetData(iiCnt, 16, _InvDet.Cost.Value);
                    FlxInv.SetData(iiCnt, 18, _InvDet.T_Item.DefultUnit.Value);
                    FlxInv.SetData(iiCnt, 19, _InvDet.T_Item.Price1.Value);
                    FlxInv.SetData(iiCnt, 20, _InvDet.T_Item.Price2.Value);
                    FlxInv.SetData(iiCnt, 21, _InvDet.T_Item.Price3.Value);
                    FlxInv.SetData(iiCnt, 22, _InvDet.T_Item.Price4.Value);
                    FlxInv.SetData(iiCnt, 23, _InvDet.T_Item.Price5.Value);
                    FlxInv.SetData(iiCnt, 25, _InvDet.InvDet_ID);
                    FlxInv.SetData(iiCnt, 27, _InvDet.DatExper ?? "");
                    if ((_InvDet.DatExper ?? "") != "" || (_InvDet.RunCod ?? "") != "")
                    {
                        FlxInv.Cols[27].Visible = true;
                        FlxInv.Cols[35].Visible = true;
                        FlxInv.SetData(iiCnt, 28, 1);
                    }
                    try
                    {
                        FlxInv.SetData(iiCnt, 33, (_InvDet.ItmWight.Value != 0.0) ? true : false);
                    }
                    catch
                    {
                        FlxInv.SetData(iiCnt, 33, false);
                    }
                    FlxInv.SetData(iiCnt, 32, _InvDet.ItmTyp.Value);
                    FlxInv.SetData(iiCnt, 38, _InvDet.Amount.Value);
                    FlxInv.SetData(iiCnt, 35, _InvDet.RunCod.Trim());
                    FlxInv.SetData(iiCnt, 36, _InvDet.LineDetails.Trim());
                    FlxInv.SetData(iiCnt, 31, _InvDet.ItmTax.Value);
                    listStkQty = (from t in db.T_STKSQTies
                                  where t.storeNo == (int?)_InvDet.StoreNo.Value
                                  where t.itmNo == _InvDet.ItmNo.Trim()
                                  select t).ToList();
                    if (listStkQty.Count != 0)
                    {
                        _StksQty = listStkQty[0];
                        FlxInv.SetData(iiCnt, 24, _InvDet.RealQty.Value + _StksQty.stkQty.Value);
                    }
                }
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? "حدث خطأ أثناء تعبئة الأسطر .." : "An error occurred while filling lines ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private bool ValidData()
        {
            if (textBox_ID.Text == "0" || textBox_ID.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ بدون رقم الفاتورة - السند" : "Can not save without the invoice number", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_ID.Focus();
                return false;
            }
            if (!VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 9) && (txtDueAmountLoc.Value == 0.0 || txtDueAmountLoc.Value == 0.0))
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ والصافي يساوي صفر" : "Can not save, and the total is equal to zero", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (txtTotalQ.Value <= 0.0)
            {
                MessageBox.Show((LangArEn == 0) ? "يجب ان لا يكون الكمية فارغة .. يرجى التأكد من وجود الأصناف في الفاتورة" : "We must not be empty value .. Please make sure there are items in the bill.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (State == FormState.Edit)
            {
                T_INVHED newData = db.StockInvHead(VarGeneral.InvTyp, textBox_ID.Text);
                if ((!string.IsNullOrEmpty(newData.InvNo) || newData.InvHed_ID > 0) && newData.InvHed_ID != data_this.InvHed_ID)
                {
                    MessageBox.Show((LangArEn == 0) ? " رقم الفاتورة مكرر يرجى تغييره" : "Employee No It's a existing", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_ID.Focus();
                    return false;
                }
            }
            for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
            {
                if (!(string.Concat(FlxInv.GetData(iiCnt, 1)) != ""))
                {
                    continue;
                }
                for (int i = 1; i < 7; i++)
                {
                    if (string.Concat(FlxInv.GetData(iiCnt, i)) == "")
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من تعبئة جميع البيانات المطلوبة" : "We must not be empty value .. Please make sure there are items in the bill.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        FlxInv.Row = iiCnt;
                        FlxInv.Col = i;
                        FlxInv.Focus();
                        return false;
                    }
                }
                if (VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7))) == "0")
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب ان لا يكون الكمية فارغة .. يرجى التأكد من وجود الأصناف في الفاتورة" : "We must not be empty value .. Please make sure there are items in the bill.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    FlxInv.Row = iiCnt;
                    FlxInv.Col = 7;
                    FlxInv.Focus();
                    return false;
                }
                if (_StorePr.Contains(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 6).ToString() ?? "")) && State == FormState.New)
                {
                    MessageBox.Show((LangArEn == 0) ? ("تم حظر استخدام المستودع رقم  [ " + VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 6).ToString() ?? "") + " ] عن هذا المستخدم .. يرجى مراجعة الصلاحيات  ") : (" The use of the repository has been blocked [" + VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 6).ToString() ?? "") + "] .. please see User Permissions"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    FlxInv.Row = iiCnt;
                    FlxInv.Col = 6;
                    FlxInv.Focus();
                    return false;
                }
                if (FlxInv.Cols[27].Visible)
                {
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 7) && VarGeneral.CheckDate(string.Concat(FlxInv.GetData(iiCnt, 27))) && string.Concat(FlxInv.GetData(iiCnt, 35)) == "")
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن حفظ تاريخ الصلاحية بدون رقم التصنيع .. الرجاء مراجعة صلاحيات المستخدم" : "Can not save the expiration date without Make No .. please see User Permissions", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        FlxInv.Row = iiCnt;
                        FlxInv.Col = 35;
                        FlxInv.Focus();
                        return false;
                    }
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 8) && !VarGeneral.CheckDate(string.Concat(FlxInv.GetData(iiCnt, 27))) && string.Concat(FlxInv.GetData(iiCnt, 35)) != "")
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن حفظ رقم التصنيع بدون تاريخ الصلاحية .. الرجاء مراجعة صلاحيات المستخدم" : "Can not save the Make No without expiration date .. please see User Permissions", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        FlxInv.Row = iiCnt;
                        FlxInv.Col = 27;
                        FlxInv.Focus();
                        return false;
                    }
                }
            }
            if (_InvSetting.InvSetting.Substring(1, 1) == "1" && VarGeneral.SSSTyp != 0)
            {
                if (txtDueAmountLoc.Value > 0.0 && string.IsNullOrEmpty(txtCredit1.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف الدائن للقيد .. راجع تهيئة النظام " : "You can not complete the operation .. Make sure the creditor under the party .. see the system configuration", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    superTabControl_Info.SelectedTabIndex = 1;
                    return false;
                }
                if (txtDueAmountLoc.Value > 0.0 && string.IsNullOrEmpty(txtDebit1.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف المدين للقيد .. راجع تهيئة النظام " : "You can not complete the operation .. Make sure the debtor under the party .. see the system configuration", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    superTabControl_Info.SelectedTabIndex = 1;
                    return false;
                }
                try
                {
                    if (txtDueAmountLoc.Value > 0.0)
                    {
                        List<T_AccDef> listAccDef = (from er in db.T_AccDefs
                                                     where er.Lev == (int?)4
                                                     where er.Sts == (int?)0
                                                     where er.AccDef_No == txtDebit1.Tag.ToString()
                                                     orderby er.AccDef_No
                                                     select er).ToList();
                        if (listAccDef.Count() <= 0)
                        {
                            MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. وذلك لأن حساب المدين لا يعمل - موقوف " : "You can not complete the operation .. This is because the debtor's account does not work - Suspended", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return false;
                        }
                        try
                        {
                            listAccDef.First().Debit = db.ExecuteQuery<double>(" select sum(T_GDDET.gdValue) from T_GDDET INNER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID where T_GDHEAD.gdLok = 0 and T_GDDET.gdValue > 0 and T_GDDET.AccNo ='" + listAccDef.First().AccDef_No + "'", new object[0]).FirstOrDefault();
                        }
                        catch
                        {
                            listAccDef.First().Debit = 0.0;
                        }
                        try
                        {
                            listAccDef.First().Credit = Math.Abs(db.ExecuteQuery<double>(" select sum(T_GDDET.gdValue) from T_GDDET INNER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID where T_GDHEAD.gdLok = 0 and T_GDDET.gdValue < 0 and T_GDDET.AccNo ='" + listAccDef.First().AccDef_No + "'", new object[0]).FirstOrDefault());
                        }
                        catch
                        {
                            listAccDef.First().Credit = 0.0;
                        }
                        try
                        {
                            listAccDef.First().Balance = db.ExecuteQuery<double>(" select sum(T_GDDET.gdValue) from T_GDDET INNER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID where T_GDHEAD.gdLok = 0 and T_GDDET.AccNo ='" + listAccDef.First().AccDef_No + "'", new object[0]).FirstOrDefault();
                        }
                        catch
                        {
                            listAccDef.First().Balance = 0.0;
                        }
                        T_AccDef _AccDef = listAccDef[0];
                        if (_AccDef.Balance.Value + txtDueAmountLoc.Value >= _AccDef.MaxLemt.Value && (_AccDef.MaxLemt.Value != 0.0 || _AccDef.MaxLemt.Value != 0.0 || _AccDef.MaxLemt.Value != 0.0))
                        {
                            MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. وذلك لأن حساب العميل / المورد تخطى الحد الأعلى " : "You can not complete the operation .. This is because the upper limit of the customer's / Supplier's account", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return false;
                        }
                    }
                }
                catch
                {
                }
            }
            if (checkBox_CostGaidTax.Checked && txtTotTax.Value <= 0.0)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن انشاء سند محاسبي بقيمة الضريبة واجمالي الضريبة يساوي صفر" : "You can not set up an accounting support tax and the total tax is equal to zero.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                superTabControl_Info.SelectedTabIndex = 5;
                return false;
            }
            if (checkBox_GaidDis.Checked && txtTotDis.Value <= 0.0)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن انشاء سند محاسبي بقيمة الخصم واجمالي الخصم يساوي صفر" : "You can not set up an accounting support Discount and the total Discount is equal to zero.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                superTabControl_Info.SelectedTabIndex = 5;
                return false;
            }
            if (!VarGeneral.CheckDate(txtGDate.Text))
            {
                txtGDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
            }
            if (!VarGeneral.CheckDate(txtHDate.Text))
            {
                txtHDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
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
               return false; if (SystemInformation.TerminalServerSession)
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
        private bool SaveData()
        {
            if (State == FormState.New)
            {
                dbInstance = null;
            }
            if (!ValidData())
            {
                return false;
            }
            string Acc0 = _GdAuto.Acc0.ToString();
            string AccCrdt = "";
            string AccDbt = "";
            string AccCrdt_Cost_Tax = "";
            string AccDbt_Cost_Tax = "";
            try
            {
                AccCrdt_Cost_Tax = txtCredit5.Tag.ToString();
            }
            catch
            {
                AccCrdt_Cost_Tax = "";
            }
            try
            {
                AccDbt_Cost_Tax = txtDebit5.Tag.ToString();
            }
            catch
            {
                AccDbt_Cost_Tax = "";
            }
            if (checkBox_CostGaidTax.Checked && (string.IsNullOrEmpty(AccDbt_Cost_Tax) || string.IsNullOrEmpty(AccCrdt_Cost_Tax) || string.IsNullOrEmpty(txtDebit5.Text) || string.IsNullOrEmpty(txtCredit5.Text)))
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة حسابات الدائن والمدين الخاص بقيمة الضريبة " : "You can not complete the operation ..verify the accounts of the private creditor and the debtor for Tax Value", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                superTabControl_Info.SelectedTabIndex = 5;
                return false;
            }
            string AccCrdt_Cost_Dis = "";
            string AccDbt_Cost_Dis = "";
            try
            {
                AccCrdt_Cost_Dis = txtCredit6.Tag.ToString();
            }
            catch
            {
                AccCrdt_Cost_Dis = "";
            }
            try
            {
                AccDbt_Cost_Dis = txtDebit6.Tag.ToString();
            }
            catch
            {
                AccDbt_Cost_Dis = "";
            }
            if (checkBox_GaidDis.Checked && (string.IsNullOrEmpty(AccDbt_Cost_Dis) || string.IsNullOrEmpty(AccCrdt_Cost_Dis) || string.IsNullOrEmpty(txtDebit6.Text) || string.IsNullOrEmpty(txtCredit6.Text)))
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة حسابات الدائن والمدين الخاص بقيمة الخصم " : "You can not complete the operation ..verify the accounts of the private creditor and the debtor for Discount Value", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                superTabControl_Info.SelectedTabIndex = 5;
                return false;
            }
            if (_InvSetting.InvSetting.Substring(1, 1) == "1" && VarGeneral.SSSTyp != 0)
            {
                AccCrdt = txtCredit1.Tag.ToString();
                AccDbt = txtDebit1.Tag.ToString();
                if (AccCrdt == "")
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف الدائن للقيد النقدي .. راجع تهيئة النظام " : "You can not complete the operation .. Make sure the creditor under the party .. see the system configuration", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    superTabControl_Info.SelectedTabIndex = 1;
                    return false;
                }
                if (AccDbt == "")
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف المدين للقيد النقدي .. راجع تهيئة النظام " : "You can not complete the operation .. Make sure the debtor under the party .. see the system configuration", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    superTabControl_Info.SelectedTabIndex = 1;
                    return false;
                }
            }
            IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
            if (data_this.TaxGaidID.HasValue && !checkBox_CostGaidTax.Checked)
            {
                db_.StartTransaction();
                db_.ClearParameters();
                db_.AddParameter("gdhead_ID", DbType.Int32, _GdHeadCostTax.gdhead_ID);
                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDHEAD_DELETE");
                db_.EndTransaction();
                data_this.TaxGaidID = null;
            }
            if (data_this.DisGaidID1.HasValue && !checkBox_GaidDis.Checked)
            {
                db_.StartTransaction();
                db_.ClearParameters();
                db_.AddParameter("gdhead_ID", DbType.Int32, _GdHeadCostDis.gdhead_ID);
                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDHEAD_DELETE");
                db_.EndTransaction();
                data_this.DisGaidID1 = null;
            }
            try
            {
                GetData();
                if (State == FormState.New)
                {
                    try
                    {
                        GetInvSetting();
                        textBox_ID.TextChanged -= textBox_ID_TextChanged;
                        T_INVHED newData = db.StockInvHead(VarGeneral.InvTyp, data_this.InvNo);
                        if (!string.IsNullOrEmpty(newData.InvNo) || newData.InvHed_ID > 0)
                        {
                            string max = "";
                            dbInstance = null;
                            max = db.MaxInvheadNo.ToString();
                            MessageBox.Show("الرمز مستخدم من قبل.\n سيتم الحفظ برقم جديد [" + max + "]", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            textBox_ID.Text = max ?? "";
                            data_this.InvNo = max ?? "";
                        }
                        textBox_ID.TextChanged += textBox_ID_TextChanged;
                        data_this.IfRet = 0;
                        data_this.DATE_CREATED = DateTime.Now;
                        data_this.SalsManNo = VarGeneral.UserNumber;
                        data_this.UserNew = VarGeneral.UserNumber;
                        data_this.SalsManNam = "";
                        IDatabase dbHead = Database.GetDatabase(VarGeneral.BranchCS);
                        dbHead.ClearParameters();
                        dbHead.AddOutParameter("InvHed_ID", DbType.Int32);
                        dbHead.AddParameter("InvId", DbType.Double, data_this.InvId);
                        dbHead.AddParameter("InvNo", DbType.String, data_this.InvNo);
                        dbHead.AddParameter("InvTyp", DbType.Int32, data_this.InvTyp);
                        dbHead.AddParameter("InvCashPay", DbType.Int32, data_this.InvCashPay);
                        dbHead.AddParameter("CusVenNo", DbType.String, data_this.CusVenNo);
                        dbHead.AddParameter("CusVenNm", DbType.String, data_this.CusVenNm);
                        dbHead.AddParameter("CusVenAdd", DbType.String, data_this.CusVenAdd);
                        dbHead.AddParameter("CusVenTel", DbType.String, data_this.CusVenTel);
                        dbHead.AddParameter("Remark", DbType.String, data_this.Remark);
                        dbHead.AddParameter("HDat", DbType.String, data_this.HDat);
                        dbHead.AddParameter("GDat", DbType.String, data_this.GDat);
                        dbHead.AddParameter("MndNo", DbType.Int32, data_this.MndNo);
                        dbHead.AddParameter("SalsManNo", DbType.String, data_this.SalsManNo);
                        dbHead.AddParameter("SalsManNam", DbType.String, data_this.SalsManNam);
                        dbHead.AddParameter("InvTot", DbType.Double, data_this.InvTot);
                        dbHead.AddParameter("InvTotLocCur", DbType.Double, data_this.InvTotLocCur);
                        dbHead.AddParameter("InvDisPrs", DbType.Double, data_this.InvDisPrs);
                        dbHead.AddParameter("InvDisVal", DbType.Double, data_this.InvDisVal);
                        dbHead.AddParameter("InvDisValLocCur", DbType.Double, data_this.InvDisValLocCur);
                        dbHead.AddParameter("InvNet", DbType.Double, data_this.InvNet);
                        dbHead.AddParameter("InvNetLocCur", DbType.Double, data_this.InvNetLocCur);
                        dbHead.AddParameter("CashPay", DbType.Double, data_this.CashPay);
                        dbHead.AddParameter("CashPayLocCur", DbType.Double, data_this.CashPayLocCur);
                        dbHead.AddParameter("IfRet", DbType.Int32, data_this.IfRet);
                        dbHead.AddParameter("GadeNo", DbType.Double, data_this.GadeNo);
                        dbHead.AddParameter("GadeId", DbType.Double, data_this.GadeId);
                        dbHead.AddParameter("IfDel", DbType.Int32, data_this.IfDel);
                        dbHead.AddParameter("RetNo", DbType.String, data_this.RetNo);
                        dbHead.AddParameter("RetId", DbType.Double, data_this.RetId);
                        dbHead.AddParameter("InvCstNo", DbType.Int32, data_this.InvCstNo);
                        dbHead.AddParameter("InvCashPayNm", DbType.String, data_this.InvCashPayNm);
                        dbHead.AddParameter("RefNo", DbType.String, data_this.RefNo);
                        dbHead.AddParameter("InvCost", DbType.Int32, data_this.InvCost);
                        dbHead.AddParameter("EstDat", DbType.String, data_this.EstDat);
                        dbHead.AddParameter("CustPri", DbType.Int32, data_this.CustPri);
                        dbHead.AddParameter("ArbTaf", DbType.String, data_this.ArbTaf);
                        dbHead.AddParameter("CurTyp", DbType.Int32, data_this.CurTyp);
                        dbHead.AddParameter("InvCash", DbType.String, data_this.InvCash);
                        dbHead.AddParameter("ToStore", DbType.String, data_this.ToStore);
                        dbHead.AddParameter("ToStoreNm", DbType.String, data_this.ToStoreNm);
                        dbHead.AddParameter("InvQty", DbType.Double, data_this.InvQty);
                        dbHead.AddParameter("EngTaf", DbType.String, data_this.EngTaf);
                        dbHead.AddParameter("IfTrans", DbType.Int32, data_this.IfTrans);
                        dbHead.AddParameter("CustRep", DbType.Double, data_this.CustRep);
                        dbHead.AddParameter("CustNet", DbType.Double, data_this.CustNet);
                        dbHead.AddParameter("InvWight_T", DbType.Double, data_this.InvWight_T);
                        dbHead.AddParameter("IfPrint", DbType.Int32, data_this.IfPrint);
                        dbHead.AddParameter("LTim", DbType.String, data_this.LTim);
                        dbHead.AddParameter("CREATED_BY", DbType.String, data_this.CREATED_BY);
                        dbHead.AddParameter("DATE_CREATED", DbType.DateTime, data_this.DATE_CREATED);
                        dbHead.AddParameter("MODIFIED_BY", DbType.String, data_this.MODIFIED_BY);
                        dbHead.AddParameter("DATE_MODIFIED", DbType.DateTime, data_this.DATE_MODIFIED);
                        dbHead.AddParameter("CreditPay", DbType.Double, data_this.CreditPay);
                        dbHead.AddParameter("CreditPayLocCur", DbType.Double, data_this.CreditPayLocCur);
                        dbHead.AddParameter("NetworkPay", DbType.Double, data_this.NetworkPay);
                        dbHead.AddParameter("NetworkPayLocCur", DbType.Double, data_this.NetworkPayLocCur);
                        dbHead.AddParameter("CommMnd_Inv", DbType.Double, data_this.CommMnd_Inv);
                        dbHead.AddParameter("MndExtrnal", DbType.Boolean, data_this.MndExtrnal);
                        dbHead.AddParameter("CompanyID", DbType.Int32, data_this.CompanyID);
                        dbHead.AddParameter("InvAddCost", DbType.Double, data_this.InvAddCost);
                        dbHead.AddParameter("InvAddCostLoc", DbType.Double, data_this.InvAddCostLoc);
                        dbHead.AddParameter("InvAddCostExtrnal", DbType.Double, data_this.InvAddCostExtrnal);
                        dbHead.AddParameter("InvAddCostExtrnalLoc", DbType.Double, data_this.InvAddCostExtrnalLoc);
                        dbHead.AddParameter("IsExtrnalGaid", DbType.Boolean, data_this.IsExtrnalGaid);
                        dbHead.AddParameter("ExtrnalCostGaidID", DbType.Double, data_this.ExtrnalCostGaidID);
                        dbHead.AddParameter("Puyaid", DbType.Double, data_this.Puyaid);
                        dbHead.AddParameter("Remming", DbType.Double, data_this.Remming);
                        dbHead.AddParameter("RoomNo", DbType.Int32, data_this.RoomNo);
                        dbHead.AddParameter("OrderTyp", DbType.Int32, data_this.OrderTyp);
                        dbHead.AddParameter("RoomSts", DbType.Boolean, data_this.RoomSts);
                        dbHead.AddParameter("chauffeurNo", DbType.Int32, data_this.chauffeurNo);
                        dbHead.AddParameter("RoomPerson", DbType.Int32, data_this.RoomPerson);
                        dbHead.AddParameter("ServiceValue", DbType.Double, data_this.ServiceValue);
                        dbHead.AddParameter("Sts", DbType.Boolean, data_this.Sts);
                        dbHead.AddParameter("PaymentOrderTyp", DbType.Int32, data_this.PaymentOrderTyp);
                        dbHead.AddParameter("AdminLock", DbType.Boolean, data_this.AdminLock);
                        dbHead.AddParameter("DeleteDate", DbType.String, data_this.DeleteDate);
                        dbHead.AddParameter("DeleteTime", DbType.String, data_this.DeleteTime);
                        dbHead.AddParameter("UserNew", DbType.String, data_this.UserNew);
                        dbHead.AddParameter("IfEnter", DbType.Int32, data_this.IfEnter);
                        dbHead.AddParameter("InvAddTax", DbType.Double, data_this.InvAddTax);
                        dbHead.AddParameter("InvAddTaxlLoc", DbType.Double, data_this.InvAddTaxlLoc);
                        dbHead.AddParameter("IsTaxGaid", DbType.Boolean, data_this.IsTaxGaid);
                        dbHead.AddParameter("TaxGaidID", DbType.Double, data_this.TaxGaidID);
                        dbHead.AddParameter("IsTaxUse", DbType.Boolean, data_this.IsTaxUse);
                        dbHead.AddParameter("InvValGaidDis", DbType.Double, data_this.InvValGaidDis);
                        dbHead.AddParameter("InvValGaidDislLoc", DbType.Double, data_this.InvValGaidDislLoc);
                        dbHead.AddParameter("IsDisGaid", DbType.Boolean, data_this.IsDisGaid);
                        dbHead.AddParameter("DisGaidID1", DbType.Double, data_this.DisGaidID1);
                        dbHead.AddParameter("IsDisUse1", DbType.Boolean, data_this.IsDisUse1);
                        dbHead.AddParameter("InvComm", DbType.Double, data_this.InvComm);
                        dbHead.AddParameter("InvCommLoc", DbType.Double, data_this.InvCommLoc);
                        dbHead.AddParameter("IsCommGaid", DbType.Boolean, data_this.IsCommGaid);
                        dbHead.AddParameter("CommGaidID", DbType.Double, data_this.CommGaidID);
                        dbHead.AddParameter("IsCommUse", DbType.Boolean, data_this.IsCommUse);
                        dbHead.AddParameter("IsTaxLines", DbType.Boolean, data_this.IsTaxLines);
                        dbHead.AddParameter("IsTaxByTotal", DbType.Boolean, data_this.IsTaxByTotal);
                        dbHead.AddParameter("IsTaxByNet", DbType.Boolean, data_this.IsTaxByNet);
                        dbHead.AddParameter("TaxByNetValue", DbType.Double, data_this.TaxByNetValue);
                        dbHead.AddParameter("DesPointsValue", DbType.Double, data_this.DesPointsValue);
                        dbHead.AddParameter("DesPointsValueLocCur", DbType.Double, data_this.DesPointsValueLocCur);
                        dbHead.AddParameter("PointsCount", DbType.Double, data_this.PointsCount);
                        dbHead.AddParameter("IsPoints", DbType.Boolean, data_this.IsPoints);
                        dbHead.AddParameter("tailor20", DbType.String, data_this.tailor20);
                        dbHead.ExecuteNonQuery(storedProcedure: true, "S_T_INVHED_INSERT");
                        data_this.InvHed_ID = int.Parse(dbHead.GetParameterValue("InvHed_ID").ToString());
                    }
                    catch (SqlException ex3)
                    {
                        try
                        {
                            VarGeneral.DebLog.writeLog("SaveData:", ex3, enable: true);
                        }
                        catch
                        {
                        }
                        string max = "";
                        dbInstance = null;
                        max = db.MaxInvheadNo.ToString();
                        if (ex3.Number == 2627)
                        {
                            MessageBox.Show("الرمز مستخدم من قبل.\n سيتم الحفظ برقم جديد [" + max + "]", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            textBox_ID.Text = max ?? "";
                            data_this.InvNo = max ?? "";
                            Button_Save_Click(null, null);
                        }
                    }
                    catch (Exception ex4)
                    {
                        try
                        {
                            VarGeneral.DebLog.writeLog("SaveData2:", ex4, enable: true);
                        }
                        catch
                        {
                        }
                        return false;
                    }
                }
                else
                {
                    data_this.SalsManNam = VarGeneral.UserNumber;
                    IDatabase dbHead = Database.GetDatabase(VarGeneral.BranchCS);
                    dbHead.ClearParameters();
                    dbHead.AddParameter("InvHed_ID", DbType.Int32, data_this.InvHed_ID);
                    dbHead.AddParameter("InvId", DbType.Double, data_this.InvId);
                    dbHead.AddParameter("InvNo", DbType.String, data_this.InvNo);
                    dbHead.AddParameter("InvTyp", DbType.Int32, data_this.InvTyp);
                    dbHead.AddParameter("InvCashPay", DbType.Int32, data_this.InvCashPay);
                    dbHead.AddParameter("CusVenNo", DbType.String, data_this.CusVenNo);
                    dbHead.AddParameter("CusVenNm", DbType.String, data_this.CusVenNm);
                    dbHead.AddParameter("CusVenAdd", DbType.String, data_this.CusVenAdd);
                    dbHead.AddParameter("CusVenTel", DbType.String, data_this.CusVenTel);
                    dbHead.AddParameter("Remark", DbType.String, data_this.Remark);
                    dbHead.AddParameter("HDat", DbType.String, data_this.HDat);
                    dbHead.AddParameter("GDat", DbType.String, data_this.GDat);
                    dbHead.AddParameter("MndNo", DbType.Int32, data_this.MndNo);
                    dbHead.AddParameter("SalsManNo", DbType.String, data_this.SalsManNo);
                    dbHead.AddParameter("SalsManNam", DbType.String, data_this.SalsManNam);
                    dbHead.AddParameter("InvTot", DbType.Double, data_this.InvTot);
                    dbHead.AddParameter("InvTotLocCur", DbType.Double, data_this.InvTotLocCur);
                    dbHead.AddParameter("InvDisPrs", DbType.Double, data_this.InvDisPrs);
                    dbHead.AddParameter("InvDisVal", DbType.Double, data_this.InvDisVal);
                    dbHead.AddParameter("InvDisValLocCur", DbType.Double, data_this.InvDisValLocCur);
                    dbHead.AddParameter("InvNet", DbType.Double, data_this.InvNet);
                    dbHead.AddParameter("InvNetLocCur", DbType.Double, data_this.InvNetLocCur);
                    dbHead.AddParameter("CashPay", DbType.Double, data_this.CashPay);
                    dbHead.AddParameter("CashPayLocCur", DbType.Double, data_this.CashPayLocCur);
                    dbHead.AddParameter("IfRet", DbType.Int32, data_this.IfRet);
                    dbHead.AddParameter("GadeNo", DbType.Double, data_this.GadeNo);
                    dbHead.AddParameter("GadeId", DbType.Double, data_this.GadeId);
                    dbHead.AddParameter("IfDel", DbType.Int32, data_this.IfDel);
                    dbHead.AddParameter("RetNo", DbType.String, data_this.RetNo);
                    dbHead.AddParameter("RetId", DbType.Double, data_this.RetId);
                    dbHead.AddParameter("InvCstNo", DbType.Int32, data_this.InvCstNo);
                    dbHead.AddParameter("InvCashPayNm", DbType.String, data_this.InvCashPayNm);
                    dbHead.AddParameter("RefNo", DbType.String, data_this.RefNo);
                    dbHead.AddParameter("InvCost", DbType.Int32, data_this.InvCost);
                    dbHead.AddParameter("EstDat", DbType.String, data_this.EstDat);
                    dbHead.AddParameter("CustPri", DbType.Int32, data_this.CustPri);
                    dbHead.AddParameter("ArbTaf", DbType.String, data_this.ArbTaf);
                    dbHead.AddParameter("CurTyp", DbType.Int32, data_this.CurTyp);
                    dbHead.AddParameter("InvCash", DbType.String, data_this.InvCash);
                    dbHead.AddParameter("ToStore", DbType.String, data_this.ToStore);
                    dbHead.AddParameter("ToStoreNm", DbType.String, data_this.ToStoreNm);
                    dbHead.AddParameter("InvQty", DbType.Double, data_this.InvQty);
                    dbHead.AddParameter("EngTaf", DbType.String, data_this.EngTaf);
                    dbHead.AddParameter("IfTrans", DbType.Int32, data_this.IfTrans);
                    dbHead.AddParameter("CustRep", DbType.Double, data_this.CustRep);
                    dbHead.AddParameter("CustNet", DbType.Double, data_this.CustNet);
                    dbHead.AddParameter("InvWight_T", DbType.Double, data_this.InvWight_T);
                    dbHead.AddParameter("IfPrint", DbType.Int32, data_this.IfPrint);
                    dbHead.AddParameter("LTim", DbType.String, data_this.LTim);
                    dbHead.AddParameter("CREATED_BY", DbType.String, data_this.CREATED_BY);
                    dbHead.AddParameter("DATE_CREATED", DbType.DateTime, data_this.DATE_CREATED);
                    dbHead.AddParameter("MODIFIED_BY", DbType.String, data_this.MODIFIED_BY);
                    dbHead.AddParameter("DATE_MODIFIED", DbType.DateTime, data_this.DATE_MODIFIED);
                    dbHead.AddParameter("CreditPay", DbType.Double, data_this.CreditPay);
                    dbHead.AddParameter("CreditPayLocCur", DbType.Double, data_this.CreditPayLocCur);
                    dbHead.AddParameter("NetworkPay", DbType.Double, data_this.NetworkPay);
                    dbHead.AddParameter("NetworkPayLocCur", DbType.Double, data_this.NetworkPayLocCur);
                    dbHead.AddParameter("CommMnd_Inv", DbType.Double, data_this.CommMnd_Inv);
                    dbHead.AddParameter("MndExtrnal", DbType.Boolean, data_this.MndExtrnal);
                    dbHead.AddParameter("CompanyID", DbType.Int32, data_this.CompanyID);
                    dbHead.AddParameter("InvAddCost", DbType.Double, data_this.InvAddCost);
                    dbHead.AddParameter("InvAddCostLoc", DbType.Double, data_this.InvAddCostLoc);
                    dbHead.AddParameter("InvAddCostExtrnal", DbType.Double, data_this.InvAddCostExtrnal);
                    dbHead.AddParameter("InvAddCostExtrnalLoc", DbType.Double, data_this.InvAddCostExtrnalLoc);
                    dbHead.AddParameter("IsExtrnalGaid", DbType.Boolean, data_this.IsExtrnalGaid);
                    dbHead.AddParameter("ExtrnalCostGaidID", DbType.Double, data_this.ExtrnalCostGaidID);
                    dbHead.AddParameter("Puyaid", DbType.Double, data_this.Puyaid);
                    dbHead.AddParameter("Remming", DbType.Double, data_this.Remming);
                    dbHead.AddParameter("RoomNo", DbType.Int32, data_this.RoomNo);
                    dbHead.AddParameter("OrderTyp", DbType.Int32, data_this.OrderTyp);
                    dbHead.AddParameter("RoomSts", DbType.Boolean, data_this.RoomSts);
                    dbHead.AddParameter("chauffeurNo", DbType.Int32, data_this.chauffeurNo);
                    dbHead.AddParameter("RoomPerson", DbType.Int32, data_this.RoomPerson);
                    dbHead.AddParameter("ServiceValue", DbType.Double, data_this.ServiceValue);
                    dbHead.AddParameter("Sts", DbType.Boolean, data_this.Sts);
                    dbHead.AddParameter("PaymentOrderTyp", DbType.Int32, data_this.PaymentOrderTyp);
                    dbHead.AddParameter("AdminLock", DbType.Boolean, data_this.AdminLock);
                    dbHead.AddParameter("DeleteDate", DbType.String, data_this.DeleteDate);
                    dbHead.AddParameter("DeleteTime", DbType.String, data_this.DeleteTime);
                    dbHead.AddParameter("UserNew", DbType.String, data_this.UserNew);
                    dbHead.AddParameter("IfEnter", DbType.Int32, data_this.IfEnter);
                    dbHead.AddParameter("InvAddTax", DbType.Double, data_this.InvAddTax);
                    dbHead.AddParameter("InvAddTaxlLoc", DbType.Double, data_this.InvAddTaxlLoc);
                    dbHead.AddParameter("IsTaxGaid", DbType.Boolean, data_this.IsTaxGaid);
                    dbHead.AddParameter("TaxGaidID", DbType.Double, data_this.TaxGaidID);
                    dbHead.AddParameter("IsTaxUse", DbType.Boolean, data_this.IsTaxUse);
                    dbHead.AddParameter("InvValGaidDis", DbType.Double, data_this.InvValGaidDis);
                    dbHead.AddParameter("InvValGaidDislLoc", DbType.Double, data_this.InvValGaidDislLoc);
                    dbHead.AddParameter("IsDisGaid", DbType.Boolean, data_this.IsDisGaid);
                    dbHead.AddParameter("DisGaidID1", DbType.Double, data_this.DisGaidID1);
                    dbHead.AddParameter("IsDisUse1", DbType.Boolean, data_this.IsDisUse1);
                    dbHead.AddParameter("InvComm", DbType.Double, data_this.InvComm);
                    dbHead.AddParameter("InvCommLoc", DbType.Double, data_this.InvCommLoc);
                    dbHead.AddParameter("IsCommGaid", DbType.Boolean, data_this.IsCommGaid);
                    dbHead.AddParameter("CommGaidID", DbType.Double, data_this.CommGaidID);
                    dbHead.AddParameter("IsCommUse", DbType.Boolean, data_this.IsCommUse);
                    dbHead.AddParameter("IsTaxLines", DbType.Boolean, data_this.IsTaxLines);
                    dbHead.AddParameter("IsTaxByTotal", DbType.Boolean, data_this.IsTaxByTotal);
                    dbHead.AddParameter("IsTaxByNet", DbType.Boolean, data_this.IsTaxByNet);
                    dbHead.AddParameter("TaxByNetValue", DbType.Double, data_this.TaxByNetValue);
                    dbHead.AddParameter("DesPointsValue", DbType.Double, data_this.DesPointsValue);
                    dbHead.AddParameter("DesPointsValueLocCur", DbType.Double, data_this.DesPointsValueLocCur);
                    dbHead.AddParameter("PointsCount", DbType.Double, data_this.PointsCount);
                    dbHead.AddParameter("IsPoints", DbType.Boolean, data_this.IsPoints);
                    dbHead.AddParameter("tailor20", DbType.String, data_this.tailor20);
                    dbHead.ExecuteNonQuery(storedProcedure: true, "S_T_INVHED_UPDATE");
                    for (int i = 0; i < data_this.T_INVDETs.Count; i++)
                    {
                        db_.ClearParameters();
                        db_.AddParameter("InvDet_ID", DbType.Int32, data_this.T_INVDETs[i].InvDet_ID);
                        db_.ExecuteNonQuery(storedProcedure: true, "S_T_INVDET_DELETE");
                    }
                }
                int iiCnt = 0;
                try
                {
                    for (iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
                    {
                        if (FlxInv.GetData(iiCnt, 1) == null)
                        {
                            continue;
                        }
                        bool _St = true;
                        if (State == FormState.New)
                        {
                            Stock_DataDataContext stock_DataDataContext = new Stock_DataDataContext(VarGeneral.BranchCS);
                            List<T_Item> listSer = new List<T_Item>();
                            listSer = (from t in stock_DataDataContext.T_Items
                                       where t.Itm_No == "" + FlxInv.GetData(iiCnt, 1)
                                       orderby t.Itm_No
                                       select t).ToList();
                            if (listSer.Count > 0)
                            {
                                _Items = new T_Item();
                                _Items = listSer[0];
                                if (_Items.AvrageCost.Value != 0.0 && _Items.AvrageCost.Value != 0.0)
                                {
                                    double QtyCheck = 0.0;
                                    try
                                    {
                                        QtyCheck = ((!(_Items.OpenQty.Value > 0.0)) ? 0.0 : _Items.OpenQty.Value);
                                    }
                                    catch
                                    {
                                        QtyCheck = 0.0;
                                    }
                                    double QtyT = QtyCheck + double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 12))));
                                    double CostT = _Items.AvrageCost.Value * QtyCheck + double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38))));
                                    if (QtyT > 0.0)
                                    {
                                        _Items.AvrageCost = CostT / QtyT;
                                    }
                                    _Items.StartCost = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))) / double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) / double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 11))));
                                    _Items.LastCost = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))) / double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) / double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 11))));
                                }
                                else
                                {
                                    _Items.AvrageCost = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))) / double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) / double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 11))));
                                    _Items.StartCost = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))) / double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) / double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 11))));
                                    _Items.LastCost = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))) / double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) / double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 11))));
                                    _Items.FirstCost = _Items.LastCost.Value;
                                }
                                try
                                {
                                    if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 45))
                                    {
                                        _Items.AvrageCost *= db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value;
                                        _Items.LastCost *= db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value;
                                        _Items.FirstCost *= db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value;
                                        _Items.StartCost *= db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value;
                                    }
                                }
                                catch
                                {
                                }
                                stock_DataDataContext.Log = VarGeneral.DebugLog;
                                stock_DataDataContext.SubmitChanges(ConflictMode.ContinueOnConflict);
                            }
                        }
                        if (State == FormState.Edit)
                        {
                            Stock_DataDataContext stock_DataDataContext = new Stock_DataDataContext(VarGeneral.BranchCS);
                            List<T_Item> listSer = new List<T_Item>();
                            listSer = (from t in stock_DataDataContext.T_Items
                                       where t.Itm_No == "" + FlxInv.GetData(iiCnt, 1)
                                       orderby t.Itm_No
                                       select t).ToList();
                            if (listSer.Count > 0)
                            {
                                _Items = new T_Item();
                                _Items = listSer[0];
                                if (!db.CheckIsPurchasInvoic(_Items.Itm_No, data_this.InvHed_ID))
                                {
                                    _Items.AvrageCost = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))) / double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) / double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 11))));
                                    _Items.StartCost = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))) / double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) / double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 11))));
                                    _Items.LastCost = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))) / double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) / double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 11))));
                                    _Items.FirstCost = _Items.LastCost.Value;
                                    try
                                    {
                                        if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 45))
                                        {
                                            _Items.AvrageCost *= db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value;
                                            _Items.LastCost *= db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value;
                                            _Items.FirstCost *= db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value;
                                            _Items.StartCost *= db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value;
                                        }
                                    }
                                    catch
                                    {
                                    }
                                    stock_DataDataContext.Log = VarGeneral.DebugLog;
                                    stock_DataDataContext.SubmitChanges(ConflictMode.ContinueOnConflict);
                                    _St = false;
                                }
                            }
                        }
                        db_.ClearParameters();
                        db_.AddParameter("InvDet_ID", DbType.Int32, 0);
                        db_.AddParameter("InvNo", DbType.String, textBox_ID.Text.Trim());
                        db_.AddParameter("InvId", DbType.Int32, data_this.InvHed_ID);
                        db_.AddParameter("InvSer", DbType.Int32, iiCnt);
                        db_.AddParameter("ItmNo", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 1)));
                        db_.AddParameter("Cost", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 10)))));
                        db_.AddParameter("Qty", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))));
                        db_.AddParameter("ItmDes", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 2)));
                        db_.AddParameter("ItmUnt", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 3)));
                        db_.AddParameter("ItmDesE", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 4)));
                        db_.AddParameter("ItmUntE", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 5)));
                        db_.AddParameter("ItmUntPak", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 11)))));
                        db_.AddParameter("StoreNo", DbType.Int32, int.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 6).ToString() ?? "")));
                        db_.AddParameter("Price", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))));
                        db_.AddParameter("Amount", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))));
                        db_.AddParameter("RealQty", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 12)))));
                        db_.AddParameter("itmInvDsc", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 13)))));
                        if (VarGeneral.CheckDate(string.Concat(FlxInv.GetData(iiCnt, 27))))
                        {
                            db_.AddParameter("DatExper", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 27)));
                        }
                        else
                        {
                            db_.AddParameter("DatExper", DbType.String, "");
                        }
                        db_.AddParameter("ItmDis", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 9)))));
                        db_.AddParameter("ItmTyp", DbType.Int32, int.Parse("0" + FlxInv.GetData(iiCnt, 32)));
                        db_.AddParameter("ItmIndex", DbType.Int32, 0);
                        try
                        {
                            db_.AddParameter("ItmWight", DbType.Double, ((bool)FlxInv.GetData(iiCnt, 33)) ? 1 : 0);
                        }
                        catch
                        {
                            db_.AddParameter("ItmWight", DbType.Double, 0);
                        }
                        db_.AddParameter("ItmWight_T", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 34)))));
                        if (!string.IsNullOrEmpty(string.Concat(FlxInv.GetData(iiCnt, 35))))
                        {
                            db_.AddParameter("RunCod", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 35)));
                        }
                        else
                        {
                            db_.AddParameter("RunCod", DbType.String, "");
                        }
                        db_.AddParameter("LineDetails", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 36)));
                        db_.AddParameter("Serial_Key", DbType.String, "");
                        db_.AddParameter("ItmTax", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 31)))));
                        db_.ExecuteNonQuery(storedProcedure: true, "S_T_INVDET_INSERT");
                        if (State == FormState.Edit && _St)
                        {
                            UpdateCost(iiCnt);
                        }
                    }
                }
                catch (Exception ex4)
                {
                    VarGeneral.DebLog.writeLog("LinesInv_Save_OpenQty:", ex4, enable: true);
                    MessageBox.Show(ex4.Message);
                    return false;
                }
                using (Stock_DataDataContext stock_DataDataContext = new Stock_DataDataContext(VarGeneral.BranchCS))
                {
                    if (txtDueAmountLoc.Value > 0.0 && !string.IsNullOrEmpty(AccCrdt) && !string.IsNullOrEmpty(AccDbt))
                    {
                        if (State == FormState.New || _GdHead.gdhead_ID == 0)
                        {
                            GetDataGd();
                            _GdHead.DATE_CREATED = DateTime.Now;
                            stock_DataDataContext.T_GDHEADs.InsertOnSubmit(_GdHead);
                            stock_DataDataContext.SubmitChanges();
                        }
                        else
                        {
                            dbInstance = null;
                            if (!data_this.GadeId.HasValue)
                            {
                                _GdHead = new T_GDHEAD();
                            }
                            textBox_ID_TextChanged(null, null);
                            GetDataGd();
                            if (!data_this.GadeId.HasValue)
                            {
                                stock_DataDataContext.T_GDHEADs.InsertOnSubmit(_GdHead);
                                stock_DataDataContext.SubmitChanges();
                            }
                            else
                            {
                                db.Log = VarGeneral.DebugLog;
                                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                            }
                            for (int i = 0; i < _GdHead.T_GDDETs.Count; i++)
                            {
                                db_.StartTransaction();
                                db_.ClearParameters();
                                db_.AddParameter("GDDET_ID", DbType.Int32, _GdHead.T_GDDETs[i].GDDET_ID);
                                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_DELETE");
                                db_.EndTransaction();
                            }
                        }
                        iiCnt = 0;
                        db_.StartTransaction();
                        db_.ClearParameters();
                        db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                        db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                        db_.AddParameter("gdNo", DbType.String, textBox_ID.Text);
                        db_.AddParameter("gdDes", DbType.String, "قيد تلقائي لفاتورة لبضاعة أول المدة رقم : " + textBox_ID.Text);
                        db_.AddParameter("gdDesE", DbType.String, "Auto Bound To open Quantities Invoice No : " + textBox_ID.Text);
                        db_.AddParameter("recptTyp", DbType.String, "14");
                        db_.AddParameter("AccNo", DbType.String, AccCrdt);
                        db_.AddParameter("AccName", DbType.String, "");
                        db_.AddParameter("gdValue", DbType.Double, 0.0 - double.Parse(txtDueAmountLoc.Text));
                        db_.AddParameter("recptNo", DbType.String, textBox_ID.Text);
                        db_.AddParameter("Lin", DbType.Int32, 1);
                        db_.AddParameter("AccNoDestruction", DbType.String, null);
                        db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                        db_.EndTransaction();
                        db_.StartTransaction();
                        db_.ClearParameters();
                        db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                        db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                        db_.AddParameter("gdNo", DbType.String, textBox_ID.Text);
                        db_.AddParameter("gdDes", DbType.String, "قيد تلقائي لفاتورة لبضاعة أول المدة رقم : " + textBox_ID.Text);
                        db_.AddParameter("gdDesE", DbType.String, "Auto Bound To open Quantities Invoice No : " + textBox_ID.Text);
                        db_.AddParameter("recptTyp", DbType.String, "14");
                        db_.AddParameter("AccNo", DbType.String, AccDbt);
                        db_.AddParameter("AccName", DbType.String, "");
                        db_.AddParameter("gdValue", DbType.Double, double.Parse(txtDueAmountLoc.Text));
                        db_.AddParameter("recptNo", DbType.String, textBox_ID.Text);
                        db_.AddParameter("Lin", DbType.Int32, 2);
                        db_.AddParameter("AccNoDestruction", DbType.String, null);
                        db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                        db_.EndTransaction();
                    }
                    else if (State == FormState.Edit && data_this.GadeId.HasValue)
                    {
                        db.ExecuteCommand("UPDATE T_GDHEAD SET T_GDHEAD.gdLok = 1  where gdhead_ID = " + data_this.GadeId);
                    }
                }
                dbInstance = null;
                textBox_ID_TextChanged(null, null);
                if (txtDueAmountLoc.Value > 0.0 && !string.IsNullOrEmpty(AccCrdt) && !string.IsNullOrEmpty(AccDbt))
                {
                    data_this.GadeId = _GdHead.gdhead_ID;
                    data_this.GadeNo = int.Parse(textBox_ID.Text);
                }
                else
                {
                    data_this.GadeId = null;
                    data_this.GadeNo = null;
                }
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                superTabControl_Info.SelectedTabIndex = 0;
                if (checkBox_CostGaidTax.Checked && !string.IsNullOrEmpty(txtDebit5.Tag.ToString()) && !string.IsNullOrEmpty(txtCredit5.Tag.ToString()) && txtTotTax.Value > 0.0)
                {
                    CreateCostGaidTax(AccCrdt_Cost_Tax, AccDbt_Cost_Tax);
                }
                if (checkBox_GaidDis.Checked && !string.IsNullOrEmpty(txtDebit6.Tag.ToString()) && !string.IsNullOrEmpty(txtCredit6.Tag.ToString()) && txtTotDis.Value > 0.0)
                {
                    CreateCostGaidDis(AccCrdt_Cost_Dis, AccDbt_Cost_Dis);
                }
            }
            catch (Exception ex4)
            {
                MessageBox.Show(ex4.Message);
                return false;
            }
            return true;
        }
        private void UpdateCost(int iiCnt)
        {
            try
            {
                Stock_DataDataContext tDB = new Stock_DataDataContext(VarGeneral.BranchCS);
                vDataRapir = new T_INVDET_Repair();
                vDataRapir.InvNo_Repair = textBox_ID.Text.Trim();
                vDataRapir.InvSer_Repair = iiCnt;
                vDataRapir.ItmNo_Repair = string.Concat(FlxInv.GetData(iiCnt, 1));
                vDataRapir.Cost_Repair = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 10))));
                vDataRapir.Qty_Repair = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7))));
                vDataRapir.ItmDes_Repair = string.Concat(FlxInv.GetData(iiCnt, 2));
                vDataRapir.ItmUnt_Repair = string.Concat(FlxInv.GetData(iiCnt, 3));
                vDataRapir.ItmDesE_Repair = string.Concat(FlxInv.GetData(iiCnt, 4));
                vDataRapir.ItmUntE_Repair = string.Concat(FlxInv.GetData(iiCnt, 5));
                vDataRapir.ItmUntPak_Repair = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 11))));
                vDataRapir.StoreNo_Repair = int.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 6).ToString() ?? ""));
                vDataRapir.Price_Repair = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8))));
                vDataRapir.Amount_Repair = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38))));
                vDataRapir.RealQty_Repair = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 12))));
                vDataRapir.ItmDis_Repair = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 9))));
                vDataRapir.TypeRepair = VarGeneral.InvTyp;
                vDataRapir.InvDet_ID = data_this.InvHed_ID;
                vDataRapir.Serial_Key_Repair = "";
                vDataRapir.ItmTax_Repair = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 31))));
                try
                {
                    vDataRapir.ItmWight_Repair = (from t in (from t in data_this.T_INVDETs
                                                             where t.InvNo == textBox_ID.Text.Trim()
                                                             where t.InvId == data_this.InvHed_ID
                                                             where t.ItmNo == string.Concat(FlxInv.GetData(iiCnt, 1))
                                                             select t).Where(delegate (T_INVDET t)
                                                         {
                                                             int? ifDel3 = t.T_INVHED.IfDel;
                                                             return ifDel3.Value == 0 && ifDel3.HasValue;
                                                         })
                                                  where t.T_INVHED.InvTyp == VarGeneral.InvTyp
                                                  select new
                                                  {
                                                      t.Qty
                                                  }).FirstOrDefault().Qty.Value;
                }
                catch
                {
                    vDataRapir.ItmWight_Repair = vDataRapir.Qty_Repair;
                }
                try
                {
                    vDataRapir.ItmWight_T_Repair = (from t in (from t in data_this.T_INVDETs
                                                               where t.InvNo == textBox_ID.Text.Trim()
                                                               where t.InvId == data_this.InvHed_ID
                                                               where t.ItmNo == string.Concat(FlxInv.GetData(iiCnt, 1))
                                                               select t).Where(delegate (T_INVDET t)
                                                           {
                                                               int? ifDel2 = t.T_INVHED.IfDel;
                                                               return ifDel2.Value == 0 && ifDel2.HasValue;
                                                           })
                                                    where t.T_INVHED.InvTyp == VarGeneral.InvTyp
                                                    select new
                                                    {
                                                        t.Price
                                                    }).FirstOrDefault().Price.Value;
                }
                catch
                {
                    vDataRapir.ItmWight_T_Repair = vDataRapir.Price_Repair;
                }
                List<T_INVDET> q = (from t in (from t in data_this.T_INVDETs
                                               where t.InvId == data_this.InvHed_ID
                                               where t.ItmNo == vDataRapir.ItmNo_Repair
                                               where t.InvSer == vDataRapir.InvSer_Repair
                                               where t.Price == vDataRapir.Price_Repair
                                               where t.Qty == vDataRapir.Qty_Repair
                                               where t.T_INVHED.InvTyp == vDataRapir.TypeRepair
                                               where t.Amount == vDataRapir.Amount_Repair
                                               where t.Cost == vDataRapir.Cost_Repair
                                               select t).Where(delegate (T_INVDET t)
                                           {
                                               int? ifDel = t.T_INVHED.IfDel;
                                               return ifDel.Value == 0 && ifDel.HasValue;
                                           })
                                    where t.T_INVHED.InvTyp == VarGeneral.InvTyp
                                    select t).ToList();
                if (q.Count <= 0)
                {
                    tDB.ExecuteCommand("DELETE FROM [T_INVDET_Repair] WHERE ItmNo_Repair = '" + FlxInv.GetData(iiCnt, 1).ToString() + "'");
                    tDB.T_INVDET_Repairs.InsertOnSubmit(vDataRapir);
                    tDB.SubmitChanges();
                }
            }
            catch
            {
            }
        }
        private void CreateCostGaidDis(string AccCrdt_Cost, string AccDbt_Cost)
        {
            IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
            using (Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS))
            {
                _GdHeadCostDis = new T_GDHEAD();
                if (!data_this.DisGaidID1.HasValue)
                {
                    GetDataGdCostDis();
                    _GdHeadCostDis.DATE_CREATED = DateTime.Now;
                    dbc.T_GDHEADs.InsertOnSubmit(_GdHeadCostDis);
                    dbc.SubmitChanges();
                }
                else
                {
                    _GdHeadCostDis = dbc.StockGdHeadid((int)data_this.DisGaidID1.Value).First();
                    GetDataGdCostDis();
                    dbc.Log = VarGeneral.DebugLog;
                    dbc.SubmitChanges(ConflictMode.ContinueOnConflict);
                    for (int i = 0; i < _GdHeadCostDis.T_GDDETs.Count; i++)
                    {
                        db_.StartTransaction();
                        db_.ClearParameters();
                        db_.AddParameter("GDDET_ID", DbType.Int32, _GdHeadCostDis.T_GDDETs[i].GDDET_ID);
                        db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_DELETE");
                        db_.EndTransaction();
                    }
                }
                db_.StartTransaction();
                db_.ClearParameters();
                db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                db_.AddParameter("gdID", DbType.Int32, _GdHeadCostDis.gdhead_ID);
                db_.AddParameter("gdNo", DbType.String, textBox_ID.Text);
                db_.AddParameter("gdDes", DbType.String, "سند بقيمة الخصم لفاتورة بضاعة اول المدة رقم : " + textBox_ID.Text);
                db_.AddParameter("gdDesE", DbType.String, "Discount Value To open Quantities Invoice No : " + textBox_ID.Text);
                db_.AddParameter("recptTyp", DbType.String, "1");
                db_.AddParameter("AccNo", DbType.String, AccCrdt_Cost);
                db_.AddParameter("AccName", DbType.String, "");
                db_.AddParameter("gdValue", DbType.Double, 0.0 - txtTotDis.Value);
                db_.AddParameter("recptNo", DbType.String, textBox_ID.Text);
                db_.AddParameter("Lin", DbType.Int32, 1);
                db_.AddParameter("AccNoDestruction", DbType.String, null);
                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                db_.EndTransaction();
                db_.StartTransaction();
                db_.ClearParameters();
                db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                db_.AddParameter("gdID", DbType.Int32, _GdHeadCostDis.gdhead_ID);
                db_.AddParameter("gdNo", DbType.String, textBox_ID.Text);
                db_.AddParameter("gdDes", DbType.String, "سند بقيمة الخصم لفاتورة بضاعة اول المدة رقم : " + textBox_ID.Text);
                db_.AddParameter("gdDesE", DbType.String, "Discount Value To open Quantities Invoice No : " + textBox_ID.Text);
                db_.AddParameter("recptTyp", DbType.String, "1");
                db_.AddParameter("AccNo", DbType.String, AccDbt_Cost);
                db_.AddParameter("AccName", DbType.String, "");
                db_.AddParameter("gdValue", DbType.Double, txtTotDis.Value);
                db_.AddParameter("recptNo", DbType.String, textBox_ID.Text);
                db_.AddParameter("Lin", DbType.Int32, 2);
                db_.AddParameter("AccNoDestruction", DbType.String, null);
                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                db_.EndTransaction();
            }
            dbInstance = null;
            textBox_ID_TextChanged(null, null);
            data_this.DisGaidID1 = _GdHeadCostDis.gdhead_ID;
            db.Log = VarGeneral.DebugLog;
            db.SubmitChanges(ConflictMode.ContinueOnConflict);
        }
        private void CreateCostGaidTax(string AccCrdt_Cost, string AccDbt_Cost)
        {
            IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
            using (Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS))
            {
                _GdHeadCostTax = new T_GDHEAD();
                if (!data_this.TaxGaidID.HasValue)
                {
                    GetDataGdCostTax();
                    _GdHeadCostTax.DATE_CREATED = DateTime.Now;
                    dbc.T_GDHEADs.InsertOnSubmit(_GdHeadCostTax);
                    dbc.SubmitChanges();
                }
                else
                {
                    _GdHeadCostTax = dbc.StockGdHeadid((int)data_this.TaxGaidID.Value).First();
                    GetDataGdCostTax();
                    dbc.Log = VarGeneral.DebugLog;
                    dbc.SubmitChanges(ConflictMode.ContinueOnConflict);
                    for (int i = 0; i < _GdHeadCostTax.T_GDDETs.Count; i++)
                    {
                        db_.StartTransaction();
                        db_.ClearParameters();
                        db_.AddParameter("GDDET_ID", DbType.Int32, _GdHeadCostTax.T_GDDETs[i].GDDET_ID);
                        db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_DELETE");
                        db_.EndTransaction();
                    }
                }
                db_.StartTransaction();
                db_.ClearParameters();
                db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                db_.AddParameter("gdID", DbType.Int32, _GdHeadCostTax.gdhead_ID);
                db_.AddParameter("gdNo", DbType.String, textBox_ID.Text);
                db_.AddParameter("gdDes", DbType.String, "سند بقيمة الضريبة لفاتورة بضاعة اول المدة رقم : " + textBox_ID.Text);
                db_.AddParameter("gdDesE", DbType.String, "Tax Value To open Quantities Invoice No : " + textBox_ID.Text);
                db_.AddParameter("recptTyp", DbType.String, "1");
                db_.AddParameter("AccNo", DbType.String, AccCrdt_Cost);
                db_.AddParameter("AccName", DbType.String, "");
                db_.AddParameter("gdValue", DbType.Double, 0.0 - txtTotTax.Value);
                db_.AddParameter("recptNo", DbType.String, textBox_ID.Text);
                db_.AddParameter("Lin", DbType.Int32, 1);
                db_.AddParameter("AccNoDestruction", DbType.String, null);
                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                db_.EndTransaction();
                db_.StartTransaction();
                db_.ClearParameters();
                db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                db_.AddParameter("gdID", DbType.Int32, _GdHeadCostTax.gdhead_ID);
                db_.AddParameter("gdNo", DbType.String, textBox_ID.Text);
                db_.AddParameter("gdDes", DbType.String, "سند بقيمة الضريبة لفاتورة بضاعة اول المدة رقم : " + textBox_ID.Text);
                db_.AddParameter("gdDesE", DbType.String, "Tax Value To open Quantities Invoice No : " + textBox_ID.Text);
                db_.AddParameter("recptTyp", DbType.String, "1");
                db_.AddParameter("AccNo", DbType.String, AccDbt_Cost);
                db_.AddParameter("AccName", DbType.String, "");
                db_.AddParameter("gdValue", DbType.Double, txtTotTax.Value);
                db_.AddParameter("recptNo", DbType.String, textBox_ID.Text);
                db_.AddParameter("Lin", DbType.Int32, 2);
                db_.AddParameter("AccNoDestruction", DbType.String, null);
                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                db_.EndTransaction();
            }
            dbInstance = null;
            textBox_ID_TextChanged(null, null);
            data_this.TaxGaidID = _GdHeadCostTax.gdhead_ID;
            db.Log = VarGeneral.DebugLog;
            db.SubmitChanges(ConflictMode.ContinueOnConflict);
        }
        private T_INVHED GetData()
        {
            GetInvTot();
            try
            {
                if (CmbInvPrice.SelectedIndex >= 0)
                {
                    data_this.CustPri = CmbInvPrice.SelectedIndex;
                }
                else
                {
                    data_this.CustPri = 0;
                }
            }
            catch
            {
                data_this.CustPri = 0;
            }
            data_this.IfEnter = 0;
            data_this.PaymentOrderTyp = 0;
            data_this.EstDat = "";
            data_this.InvCashPayNm = "";
            data_this.DeleteDate = "";
            data_this.DeleteTime = "";
            data_this.MndExtrnal = false;
            data_this.CommMnd_Inv = 0.0;
            data_this.Remark = txtRemark.Text;
            data_this.InvNo = textBox_ID.Text;
            data_this.CashPay = txtDueAmount.Value;
            try
            {
                data_this.CurTyp = int.Parse(CmbCurr.SelectedValue.ToString());
            }
            catch
            {
                data_this.CurTyp = null;
            }
            data_this.CustNet = txtCustNet.Value;
            data_this.CustRep = txtCustRep.Value;
            data_this.HDat = txtHDate.Text;
            data_this.GDat = txtGDate.Text;
            try
            {
                data_this.InvCashPay = 0;
            }
            catch
            {
                data_this.InvCashPay = 0;
            }
            try
            {
                data_this.InvCash = checkBox_Chash.Text;
            }
            catch
            {
                data_this.InvCash = "سند";
            }
            data_this.InvCost = txtInvCost.Value;
            try
            {
                data_this.InvCstNo = int.Parse(CmbCostC.SelectedValue.ToString());
            }
            catch
            {
                data_this.InvCstNo = null;
            }
            data_this.InvDisPrs = txtDiscountP.Value;
            data_this.InvDisVal = txtDiscountVal.Value;
            data_this.InvDisValLocCur = txtDiscountValLoc.Value;
            data_this.InvNet = txtDueAmount.Value;
            data_this.InvNetLocCur = txtDueAmountLoc.Value;
            data_this.InvQty = txtTotalQ.Value;
            data_this.InvTot = txtTotalAm.Value;
            data_this.InvTotLocCur = txtTotalAmLoc.Value;
            data_this.InvTyp = VarGeneral.InvTyp;
            data_this.IfDel = 0;
            data_this.LTim = txtTime.Text;
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
                data_this.MndNo = int.Parse(CmbLegate.SelectedValue.ToString());
            }
            else
            {
                data_this.MndNo = null;
            }
            data_this.RefNo = txtRef.Text;
            listCurency = db.Fillcurency_2("").ToList();
            if (listCurency.Count > 0)
            {
                _Curency = listCurency[0];
            }
            data_this.ArbTaf = ScriptNumber1.ScriptNum(decimal.Parse(VarGeneral.TString.TEmpty(txtDueAmountLoc.Text ?? ""))) + " " + _Curency.Arb_Des + " " + "فقط لاغير ";
            data_this.EngTaf = ScriptNumber1.TafEng(decimal.Parse(VarGeneral.TString.TEmpty(txtDueAmountLoc.Text ?? ""))) + " " + _Curency.Eng_Des;
            data_this.CreditPay = 0.0;
            data_this.NetworkPay = 0.0;
            data_this.CashPayLocCur = txtDueAmountLoc.Value;
            data_this.CreditPayLocCur = 0.0;
            data_this.NetworkPayLocCur = 0.0;
            data_this.Puyaid = 0.0;
            data_this.Remming = 0.0;
            data_this.CompanyID = 1;
            data_this.RoomNo = 1;
            data_this.OrderTyp = 1;
            data_this.RoomSts = false;
            data_this.RoomPerson = 1;
            data_this.ServiceValue = 0.0;
            data_this.Sts = false;
            data_this.chauffeurNo = null;
            data_this.tailor20 = "0";
            data_this.InvAddTax = txtTotTax.Value;
            data_this.InvAddTaxlLoc = txtTotTaxLoc.Value;
            if (switchButton_Tax.Value)
            {
                data_this.IsTaxUse = true;
            }
            else
            {
                data_this.IsTaxUse = false;
            }
            if (switchButton_TaxLines.Value)
            {
                data_this.IsTaxLines = true;
            }
            else
            {
                data_this.IsTaxLines = false;
            }
            if (switchButton_TaxByTotal.Value)
            {
                data_this.IsTaxByTotal = true;
            }
            else
            {
                data_this.IsTaxByTotal = false;
            }
            if (switchButton_TaxByNet.Value)
            {
                data_this.IsTaxByNet = true;
            }
            else
            {
                data_this.IsTaxByNet = false;
            }
            try
            {
                data_this.TaxByNetValue = double.Parse(textBoxItem_TaxByNetValue.Text);
            }
            catch
            {
                data_this.TaxByNetValue = 0.0;
            }
            data_this.IsTaxGaid = checkBox_CostGaidTax.Checked;
            data_this.InvValGaidDis = txtTotDis.Value;
            data_this.InvValGaidDislLoc = txtTotDisLoc.Value;
            if (switchButton_Dis.Value)
            {
                data_this.IsDisUse1 = true;
            }
            else
            {
                data_this.IsDisUse1 = false;
            }
            data_this.IsDisGaid = checkBox_GaidDis.Checked;
            data_this.InvComm = 0.0;
            data_this.InvCommLoc = 0.0;
            data_this.IsCommUse = false;
            data_this.IsCommGaid = false;
            data_this.DesPointsValue = 0.0;
            data_this.DesPointsValueLocCur = 0.0;
            data_this.PointsCount = 0.0;
            data_this.IsPoints = false;
            return data_this;
        }
        private T_GDHEAD GetDataGdCostDis()
        {
            _GdHeadCostDis.gdHDate = txtHDate.Text;
            _GdHeadCostDis.gdGDate = txtGDate.Text;
            _GdHeadCostDis.gdNo = textBox_ID.Text;
            _GdHeadCostDis.ArbTaf = ScriptNumber1.ScriptNum(decimal.Parse("0" + txtTotDis.Text));
            _GdHeadCostDis.BName = _GdHeadCostDis.BName;
            _GdHeadCostDis.ChekNo = _GdHeadCostDis.ChekNo;
            _GdHeadCostDis.CurTyp = int.Parse(CmbCurr.SelectedValue.ToString());
            _GdHeadCostDis.EngTaf = ScriptNumber1.TafEng(decimal.Parse("0" + txtTotDis.Text));
            _GdHeadCostDis.gdCstNo = int.Parse(CmbCostC.SelectedValue.ToString());
            _GdHeadCostDis.gdID = 0;
            _GdHeadCostDis.gdLok = false;
            _GdHeadCostDis.AdminLock = switchButton_Lock.Value;
            _GdHeadCostDis.gdMem = "سند بقيمة الخصم|Discount Value";
            if (CmbLegate.SelectedIndex > 0)
            {
                _GdHeadCostDis.gdMnd = int.Parse(CmbLegate.SelectedValue.ToString());
            }
            else
            {
                _GdHeadCostDis.gdMnd = null;
            }
            _GdHeadCostDis.gdRcptID = (_GdHeadCostDis.gdRcptID.HasValue ? _GdHeadCostDis.gdRcptID.Value : 0.0);
            _GdHeadCostDis.gdTot = txtTotDis.Value;
            _GdHeadCostDis.gdTp = (_GdHeadCostDis.gdTp.HasValue ? _GdHeadCostDis.gdTp.Value : 0);
            _GdHeadCostDis.gdTyp = VarGeneral.InvTyp;
            _GdHeadCostDis.RefNo = txtRef.Text;
            _GdHeadCostDis.DATE_MODIFIED = DateTime.Now;
            _GdHeadCostDis.salMonth = "";
            _GdHeadCostDis.gdUser = VarGeneral.UserNumber;
            _GdHeadCostDis.gdUserNam = VarGeneral.UserNameA;
            _GdHeadCostDis.CompanyID = 1;
            return _GdHeadCostDis;
        }
        private T_GDHEAD GetDataGdCostTax()
        {
            _GdHeadCostTax.gdHDate = txtHDate.Text;
            _GdHeadCostTax.gdGDate = txtGDate.Text;
            _GdHeadCostTax.gdNo = textBox_ID.Text;
            _GdHeadCostTax.ArbTaf = ScriptNumber1.ScriptNum(decimal.Parse("0" + txtTotTax.Text));
            _GdHeadCostTax.BName = _GdHeadCostTax.BName;
            _GdHeadCostTax.ChekNo = _GdHeadCostTax.ChekNo;
            _GdHeadCostTax.CurTyp = int.Parse(CmbCurr.SelectedValue.ToString());
            _GdHeadCostTax.EngTaf = ScriptNumber1.TafEng(decimal.Parse("0" + txtTotTax.Text));
            _GdHeadCostTax.gdCstNo = int.Parse(CmbCostC.SelectedValue.ToString());
            _GdHeadCostTax.gdID = 0;
            _GdHeadCostTax.gdLok = false;
            _GdHeadCostTax.AdminLock = switchButton_Lock.Value;
            _GdHeadCostTax.gdMem = "سند بقيمة الضريبة|Tax Value";
            if (CmbLegate.SelectedIndex > 0)
            {
                _GdHeadCostTax.gdMnd = int.Parse(CmbLegate.SelectedValue.ToString());
            }
            else
            {
                _GdHeadCostTax.gdMnd = null;
            }
            _GdHeadCostTax.gdRcptID = (_GdHeadCostTax.gdRcptID.HasValue ? _GdHeadCostTax.gdRcptID.Value : 0.0);
            _GdHeadCostTax.gdTot = txtTotTax.Value;
            _GdHeadCostTax.gdTp = (_GdHeadCostTax.gdTp.HasValue ? _GdHeadCostTax.gdTp.Value : 0);
            _GdHeadCostTax.gdTyp = VarGeneral.InvTyp;
            _GdHeadCostTax.RefNo = txtRef.Text;
            _GdHeadCostTax.DATE_MODIFIED = DateTime.Now;
            _GdHeadCostTax.salMonth = "";
            _GdHeadCostTax.gdUser = VarGeneral.UserNumber;
            _GdHeadCostTax.gdUserNam = VarGeneral.UserNameA;
            _GdHeadCostTax.CompanyID = 1;
            return _GdHeadCostTax;
        }
        private T_GDHEAD GetDataGd()
        {
            _GdHead.gdHDate = txtHDate.Text;
            _GdHead.gdGDate = txtGDate.Text;
            _GdHead.gdNo = textBox_ID.Text;
            _GdHead.ArbTaf = ScriptNumber1.ScriptNum(decimal.Parse("0" + txtDueAmountLoc.Text));
            _GdHead.BName = _GdHead.BName;
            _GdHead.ChekNo = _GdHead.ChekNo;
            _GdHead.CurTyp = int.Parse(CmbCurr.SelectedValue.ToString());
            _GdHead.EngTaf = ScriptNumber1.TafEng(decimal.Parse("0" + txtDueAmountLoc.Text));
            _GdHead.gdCstNo = int.Parse(CmbCostC.SelectedValue.ToString());
            _GdHead.gdID = 0;
            _GdHead.gdLok = false;
            _GdHead.gdMem = txtRemark.Text;
            _GdHead.AdminLock = switchButton_Lock.Value;
            if (CmbLegate.SelectedIndex > 0)
            {
                _GdHead.gdMnd = int.Parse(CmbLegate.SelectedValue.ToString());
            }
            else
            {
                _GdHead.gdMnd = null;
            }
            _GdHead.gdRcptID = (_GdHead.gdRcptID.HasValue ? _GdHead.gdRcptID.Value : 0.0);
            _GdHead.gdTot = txtDueAmountLoc.Value;
            _GdHead.gdTp = (_GdHead.gdTp.HasValue ? _GdHead.gdTp.Value : 0);
            _GdHead.gdTyp = VarGeneral.InvTyp;
            _GdHead.RefNo = txtRef.Text;
            _GdHead.DATE_MODIFIED = DateTime.Now;
            _GdHead.salMonth = "";
            _GdHead.gdUser = VarGeneral.UserNumber;
            _GdHead.gdUserNam = VarGeneral.UserNameA;
            _GdHead.CompanyID = 1;
            return _GdHead;
        }
        private void FlxInv_BeforeEdit(object sender, RowColEventArgs e)
        {
            if ((e.Col == 3 || e.Col == 5) && FlxInv.GetData(e.Row, e.Col) != null)
            {
                oldUnit = FlxInv.GetData(e.Row, e.Col).ToString() ?? "";
            }
            try
            {
                if (FlxInv.Col == 36 && VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 66))
                {
                    FlxInv.BeforeEdit -= FlxInv_BeforeEdit;
                    int vRowIndex = FlxInv.Row;
                    FrmInvDetNoteSrch frm = new FrmInvDetNoteSrch();
                    frm.Tag = LangArEn;
                    try
                    {
                        frm.textbox_Detailes.Text = FlxInv.GetData(vRowIndex, 36).ToString() ?? "";
                    }
                    catch
                    {
                        frm.textbox_Detailes.Text = "";
                    }
                    frm.TopMost = true;
                    frm.ShowDialog();
                    if (frm.SerachNo != "")
                    {
                        FlxInv.SetData(vRowIndex, 36, "");
                        FlxInv.SetData(vRowIndex, 36, FlxInv.GetData(vRowIndex, 36).ToString() + frm.SerachNo);
                    }
                    SendKeys.SendWait("{ENTER}");
                    FlxInv.BeforeEdit += FlxInv_BeforeEdit;
                }
            }
            catch
            {
                FlxInv.BeforeEdit += FlxInv_BeforeEdit;
            }
        }
        private void FlxInv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                FlxInv.RemoveItem(FlxInv.Row);
                GetInvTot();
            }
        }
        private void FlxInv_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                try
                {
                    if (string.Concat(FlxInv.GetData(FlxInv.RowSel, 1)) != "" && State != 0)
                    {
                        _Items = db.StockItem(string.Concat(FlxInv.GetData(FlxInv.RowSel, 1)));
                        txtVCost.Text = string.Concat(Math.Round(_Items.AvrageCost.Value * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 11)))) / RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2));
                        txtLCost.Text = string.Concat(Math.Round(_Items.LastCost.Value * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 11)))) / RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2));
                        LastPrice(_Items);
                    }
                }
                catch
                {
                }
                if (!(string.Concat(FlxInv.GetData(FlxInv.RowSel, 1)) != ""))
                {
                    return;
                }
                _Items = db.StockItem(string.Concat(FlxInv.GetData(FlxInv.RowSel, 1)));
                string CoA = "";
                string CoE = "";
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_Items.Unit1 == _Unit.Unit_ID)
                    {
                        if (CoA != "")
                        {
                            CoA += "|";
                            CoE += "|";
                        }
                        CoA += _Unit.Arb_Des;
                        CoE += _Unit.Eng_Des;
                        break;
                    }
                }
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_Items.Unit2 == _Unit.Unit_ID)
                    {
                        if (CoA != "")
                        {
                            CoA += "|";
                            CoE += "|";
                        }
                        CoA += _Unit.Arb_Des;
                        CoE += _Unit.Eng_Des;
                        break;
                    }
                }
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_Items.Unit3 == _Unit.Unit_ID)
                    {
                        if (CoA != "")
                        {
                            CoA += "|";
                            CoE += "|";
                        }
                        CoA += _Unit.Arb_Des;
                        CoE += _Unit.Eng_Des;
                        break;
                    }
                }
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_Items.Unit4 == _Unit.Unit_ID)
                    {
                        if (CoA != "")
                        {
                            CoA += "|";
                            CoE += "|";
                        }
                        CoA += _Unit.Arb_Des;
                        CoE += _Unit.Eng_Des;
                        break;
                    }
                }
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_Items.Unit5 == _Unit.Unit_ID)
                    {
                        if (CoA != "")
                        {
                            CoA += "|";
                            CoE += "|";
                        }
                        CoA += _Unit.Arb_Des;
                        CoE += _Unit.Eng_Des;
                        break;
                    }
                }
                FlxInv.Cols[3].ComboList = CoA;
                FlxInv.Cols[5].ComboList = CoE;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtItemName.Text = _Items.Arb_Des.Trim();
                }
                else
                {
                    txtItemName.Text = _Items.Eng_Des.Trim();
                }
                txtVCost.Text = string.Concat(Math.Round(_Items.AvrageCost.Value * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 11)))) / RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2));
                txtLCost.Text = string.Concat(Math.Round(_Items.LastCost.Value * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 11)))) / RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2));
                LastPrice(_Items);
                BindDataOfStkQty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 1)));
            }
            catch
            {
            }
        }
        private void FlxInv_RowColChange(object sender, EventArgs e)
        {
            if (FlxInv.Col == 1)
            {
                Framework.Keyboard.Language.Switch("English");
            }
            if (FlxInv.Col == 2)
            {
                Framework.Keyboard.Language.Switch("Arabic");
            }
            if (FlxInv.Col == 4)
            {
                Framework.Keyboard.Language.Switch("English");
            }
        }
        private void FlxInv_SelChange(object sender, EventArgs e)
        {
            try
            {
                if (RowSel == 0 || RowSel == FlxInv.Row || FlxInv.Row <= 0 || !(string.Concat(FlxInv.GetData(FlxInv.Row, 1)) != ""))
                {
                    return;
                }
                List<T_Item> listSer = new List<T_Item>();
                listSer = db.StockItemList(string.Concat(FlxInv.GetData(FlxInv.RowSel, 1)));
                if (listSer.Count == 0)
                {
                    return;
                }
                _Items = listSer[0];
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtItemName.Text = _Items.Arb_Des.Trim();
                }
                else
                {
                    txtItemName.Text = _Items.Eng_Des.Trim();
                }
                string CoA = "";
                string CoE = "";
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_Items.Unit1 == _Unit.Unit_ID)
                    {
                        if (CoA != "")
                        {
                            CoA += "|";
                            CoE += "|";
                        }
                        CoA += _Unit.Arb_Des;
                        CoE += _Unit.Eng_Des;
                        break;
                    }
                }
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_Items.Unit2 == _Unit.Unit_ID)
                    {
                        if (CoA != "")
                        {
                            CoA += "|";
                            CoE += "|";
                        }
                        CoA += _Unit.Arb_Des;
                        CoE += _Unit.Eng_Des;
                        break;
                    }
                }
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_Items.Unit3 == _Unit.Unit_ID)
                    {
                        if (CoA != "")
                        {
                            CoA += "|";
                            CoE += "|";
                        }
                        CoA += _Unit.Arb_Des;
                        CoE += _Unit.Eng_Des;
                        break;
                    }
                }
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_Items.Unit4 == _Unit.Unit_ID)
                    {
                        if (CoA != "")
                        {
                            CoA += "|";
                            CoE += "|";
                        }
                        CoA += _Unit.Arb_Des;
                        CoE += _Unit.Eng_Des;
                        break;
                    }
                }
                for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                {
                    _Unit = listUnit[iiCnt];
                    if (_Items.Unit5 == _Unit.Unit_ID)
                    {
                        if (CoA != "")
                        {
                            CoA += "|";
                            CoE += "|";
                        }
                        CoA += _Unit.Arb_Des;
                        CoE += _Unit.Eng_Des;
                        break;
                    }
                }
                FlxInv.Cols[3].ComboList = CoA;
                FlxInv.Cols[5].ComboList = CoE;
                txtVCost.Text = string.Concat(Math.Round((_Items.AvrageCost * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 11))))).Value / RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2));
                txtLCost.Text = string.Concat(Math.Round((_Items.LastCost * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 11))))).Value / RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2));
                BindDataOfStkQty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 1)));
            }
            catch
            {
            }
        }
        private void FlxDat_DoubleClick(object sender, EventArgs e)
        {
            if (FlxDat.MouseRow > 0)
            {
                FlxInv.SetData(FlxInv.Row, 27, FlxDat.GetData(FlxDat.Row, 0));
                FlxInv.SetData(FlxInv.Row, 24, FlxDat.GetData(FlxDat.Row, 1));
                FlxInv.SetData(FlxInv.Row, 35, FlxDat.GetData(FlxDat.Row, 2));
                FlxDat.Visible = false;
                FlxInv.Col = 6;
                FlxInv.Focus();
            }
        }
        private void FlxDat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && FlxDat.Row > 0)
            {
                FlxInv.SetData(FlxInv.Row, 27, FlxDat.GetData(FlxDat.Row, 0));
                FlxInv.SetData(FlxInv.Row, 24, FlxDat.GetData(FlxDat.Row, 1));
                FlxInv.SetData(FlxInv.Row, 35, FlxDat.GetData(FlxDat.Row, 2));
                FlxDat.Visible = false;
                FlxInv.Col = 6;
                FlxInv.Focus();
            }
        }
        private void FlxDat_Leave(object sender, EventArgs e)
        {
            if (FlxDat.Visible && State == FormState.New)
            {
                FlxDat.Focus();
            }
            else
            {
                FlxDat.Visible = false;
            }
        }
        private void FlxInv_AfterEdit(object sender, RowColEventArgs e)
        {
            double ItmDis = 0.0;
            double ItmAddTax = 0.0;
            ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
            if (!switchButton_TaxLines.Value || switchButton_TaxByTotal.Value)
            {
                ItmAddTax = 0.0;
            }
            ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 9)))) / 100.0);
            if (e.Col == 1)
            {
                BindDataOfItem();
            }
            else if (((e.Col == 2 || e.Col == 4) && (string)FlxInv.GetData(e.Row, 1) == "") || FlxInv.GetData(e.Row, 1) == null)
            {
                BindDataOfItem();
            }
            else if ((e.Col == 3 || e.Col == 5) && FlxInv.GetData(e.Row, e.Col).ToString() != oldUnit && FlxInv.GetData(e.Row, e.Col).ToString() != "")
            {
                int ItemIndex = -1;
                if (e.Col == 3)
                {
                    string[] Items = FlxInv.Cols[e.Col].ComboList.Split('|');
                    for (int i = 0; i < Items.Length; i++)
                    {
                        if (Items[i] == FlxInv.GetData(e.Row, e.Col).ToString())
                        {
                            ItemIndex = i + 1;
                        }
                    }
                    string[] Items2 = FlxInv.Cols[5].ComboList.Split('|');
                    if (Items2.Length > 1 && ItemIndex > -1)
                    {
                        FlxInv.SetData(e.Row, 5, Items2[ItemIndex - 1]);
                    }
                }
                else if (e.Col == 5)
                {
                    string[] Items = FlxInv.Cols[e.Col].ComboList.Split('|');
                    for (int i = 0; i < Items.Length; i++)
                    {
                        if (Items[i] == FlxInv.GetData(e.Row, e.Col).ToString())
                        {
                            ItemIndex = i + 1;
                        }
                    }
                    string[] Items2 = FlxInv.Cols[3].ComboList.Split('|');
                    if (Items2.Length > 1 && ItemIndex > -1)
                    {
                        FlxInv.SetData(e.Row, 3, Items2[ItemIndex - 1]);
                    }
                }
                switch (ItemIndex)
                {
                    case 1:
                        FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost.Value * _Items.Pack1.Value / RateValue);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack1);
                        break;
                    case 2:
                        FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost.Value * _Items.Pack2.Value / RateValue);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack2);
                        break;
                    case 3:
                        FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost.Value * _Items.Pack3.Value / RateValue);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack3);
                        break;
                    case 4:
                        FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost.Value * _Items.Pack4.Value / RateValue);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack4.Value);
                        break;
                    case 5:
                        FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost.Value * _Items.Pack5.Value / RateValue);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack5.Value);
                        break;
                }
                Pack = ItemIndex;
                BindDataofItemPrice();
                FlxInv.SetData(e.Row, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 11)))));
                FlxInv.SetData(e.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAddTax);
                if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) > 0.0)
                {
                    ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    FlxInv.SetData(e.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) + ItmAddTax);
                }
                PriceLoc = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8))));
                BindDataOfStkQty(FlxInv.GetData(e.Row, 1).ToString());
                if (CmbCurr.SelectedIndex != -1)
                {
                    List<T_Curency> listSer = db.StockCurrList(int.Parse(CmbCurr.SelectedValue.ToString()));
                    T_Curency _Curency = listSer[0];
                    double CurRate = _Curency.Rate.Value;
                }
                FlxInv.SetData(e.Row, 26, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) / 1.0);
                try
                {
                    ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 9)))) / 100.0);
                    ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    if (!switchButton_TaxLines.Value || switchButton_TaxByTotal.Value)
                    {
                        ItmAddTax = 0.0;
                    }
                    FlxInv.SetData(e.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAddTax);
                    if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) > 0.0)
                    {
                        ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                        FlxInv.SetData(e.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) + ItmAddTax);
                    }
                }
                catch
                {
                }
            }
            else if (e.Col == 6 && string.Concat(FlxInv.GetData(e.Row, 1)) != "")
            {
                listStkQty = (from t in db.T_STKSQTies
                              where t.itmNo == FlxInv.GetData(e.Row, 1).ToString()
                              where t.storeNo == (int?)int.Parse(FlxInv.GetData(e.Row, 6).ToString())
                              select t).ToList();
                if (listStkQty.Count != 0)
                {
                    _StksQty = listStkQty[0];
                    FlxInv.SetData(e.Row, 24, _StksQty.stkQty.ToString());
                }
                else
                {
                    FlxInv.SetData(e.Row, 24, 0);
                }
            }
            else if (e.Col == 7 || e.Col == 8)
            {
                double RealQ = 0.0;
                RealQ = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 11))));
                FlxInv.SetData(e.Row, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 11)))));
                FlxInv.SetData(e.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAddTax);
                if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) > 0.0)
                {
                    ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    FlxInv.SetData(e.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) + ItmAddTax);
                }
                chekReptItem(Col_1: false);
            }
            else if (e.Col == 9)
            {
                FlxInv.SetData(e.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAddTax);
                if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) > 0.0)
                {
                    ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    FlxInv.SetData(e.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) + ItmAddTax);
                }
            }
            else if (e.Col == 38)
            {
                if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) > 0.0)
                {
                    ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                }
                if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) != Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAddTax, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2))
                {
                    if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) == 0.0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يجب تحديد الكمية" : "Must Enter The Quantity", VarGeneral.ProdectNam);
                        FlxInv.SetData(e.Row, 38, 0);
                        FlxInv.Col = 7;
                        FlxInv.Row = e.Row;
                        FlxInv.Focus();
                    }
                    else
                    {
                        FlxInv.SetData(e.Row, 8, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) / double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))));
                        FlxInv.SetData(e.Row, 9, 0);
                    }
                }
                chekReptItem(Col_1: false);
            }
            else if (e.Col == 31)
            {
                FlxInv.SetData(e.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAddTax);
                if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) > 0.0)
                {
                    ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    FlxInv.SetData(e.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) + ItmAddTax);
                }
            }
            else if (e.Col == 33 && Convert.ToBoolean(FlxInv.GetData(e.Row, 33)))
            {
                ItmAddTax = 0.0;
                ItmDis = 0.0;
                FlxInv.SetData(e.Row, 8, 0);
                FlxInv.SetData(e.Row, 9, 0);
                FlxInv.SetData(e.Row, 31, 0);
                FlxInv.SetData(e.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAddTax);
            }
            VarGeneral.Flush();
            GetInvTot();
        }
        private void BindDataOfItem()
        {
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("Itm_No", new ColumnDictinary("رقم الصنف", "Item No", ifDefault: true, ""));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, ""));
            columns_Names_visible2.Add("StartCost", new ColumnDictinary("التكلفةالافتتاحية", "Start Cost", ifDefault: false, ""));
            columns_Names_visible2.Add("AvrageCost", new ColumnDictinary("متوسط التكلفة", "Average Cost", ifDefault: false, ""));
            columns_Names_visible2.Add("LastCost", new ColumnDictinary("آخر تكلفة", "Last Cost", ifDefault: false, ""));
            columns_Names_visible2.Add("Arb_Des_Cat", new ColumnDictinary("الاسم العربي لمجموعة الصنف", "CATEGORY Arabic Name", ifDefault: false, ""));
            columns_Names_visible2.Add("Eng_Des_Cat", new ColumnDictinary("الاسم الانجليزي لمجموعة الصنف", "CATEGORY English Name", ifDefault: false, ""));
            List<T_Item> listSer = new List<T_Item>();
            bool Barcod = false;
            if ((string)FlxInv.GetData(FlxInv.Row, 1) != "" && FlxInv.GetData(FlxInv.Row, 1) != null)
            {
                Barcod = ChkBarCod((string)FlxInv.GetData(FlxInv.Row, 1));
                if (!Barcod || (VarGeneral.SSSLev != "D" && VarGeneral.SSSLev != "G" && VarGeneral.SSSLev != "S" && VarGeneral.SSSLev != "B" && VarGeneral.SSSLev != "F" && VarGeneral.SSSLev != "C" && VarGeneral.SSSLev != "R" && VarGeneral.SSSLev != "H" && VarGeneral.SSSLev != "M"))
                {
                    listSer = db.StockItemList(FlxInv.GetData(FlxInv.Row, 1).ToString());
                    if (listSer.Count != 0)
                    {
                        _Items = listSer[0];
                    }
                }
            }
            else if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 30))
            {
                string _SearchNo = "";
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Items ";
                string Fields = "";
                Fields = ((LangArEn != 0) ? " T_Items.Itm_No as [ID Number], T_Items.Itm_No as [Item No] , T_Items.Arb_Des as [Arabic Description], T_Items.Eng_Des as [English Description] , T_Items.OpenQty as [Quantity]  " : " T_Items.Itm_No as [رقم التعريف], T_Items.Itm_No as [رقــم الصنــــف] , T_Items.Arb_Des as [الوصــف العربـــي], T_Items.Eng_Des as [الوصــف إنجلـــيزي] , T_Items.OpenQty as [الكمية] ");
                _RepShow.Rule = " Where 1 = 1 and T_Items.ItmTyp != 2 and T_Items.ItmTyp != 3 ";
                try
                {
                    db.ExecuteCommand("select " + Fields + " From " + _RepShow.Tables + _RepShow.Rule + " order by  CONVERT(INT, LEFT(T_Items.Itm_No, PATINDEX('%[^0-9]%', T_Items.Itm_No + 'z')-1)) ");
                    _RepShow.Rule += " order by  CONVERT(INT, LEFT(T_Items.Itm_No, PATINDEX('%[^0-9]%', T_Items.Itm_No + 'z')-1)) ";
                }
                catch
                {
                    _RepShow.Rule += " order by T_Items.Itm_No ";
                }
                if (!string.IsNullOrEmpty(Fields))
                {
                    _RepShow.Fields = Fields;
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                    if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                    {
                        return;
                    }
                    string ItmDes = "";
                    int ItmDesIndex = 1;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        if ((string)FlxInv.GetData(FlxInv.Row, 2) != "" && FlxInv.GetData(FlxInv.Row, 2) != null)
                        {
                            ItmDes = (string)FlxInv.GetData(FlxInv.Row, 2);
                            ItmDesIndex = 2;
                        }
                    }
                    else if ((string)FlxInv.GetData(FlxInv.Row, 4) != "" && FlxInv.GetData(FlxInv.Row, 4) != null)
                    {
                        ItmDes = (string)FlxInv.GetData(FlxInv.Row, 4);
                        ItmDesIndex = 3;
                    }
                    FMFind FmQuikSerch = new FMFind(ItmDes, ItmDesIndex);
                    FmQuikSerch.Tag = LangArEn;
                    FmQuikSerch.TopMost = true;
                    FmQuikSerch.ShowDialog();
                    _SearchNo = FmQuikSerch.SerachNo;
                }
                if (!(_SearchNo != ""))
                {
                    try
                    {
                        FlxInv.RemoveItem(FlxInv.Row);
                        try
                        {
                            FlxInv.Rows.Add();
                        }
                        catch
                        {
                        }
                        FlxInv.Row = FlxInv.RowSel;
                        FlxInv.Col = 1;
                    }
                    catch
                    {
                    }
                    return;
                }
                listSer = db.StockItemList(_SearchNo);
                _Items = listSer[0];
            }
            else
            {
                List<T_Item> q = (from t in db.T_Items
                                  where t.ItmTyp != (int?)3 && t.ItmTyp != (int?)2
                                  orderby t.Itm_No
                                  select t).ToList();
                if (q.Count == 0)
                {
                    return;
                }
                string ItmDes = "";
                int ItmDesIndex = 1;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    if ((string)FlxInv.GetData(FlxInv.Row, 2) != "" && FlxInv.GetData(FlxInv.Row, 2) != null)
                    {
                        ItmDes = (string)FlxInv.GetData(FlxInv.Row, 2);
                        ItmDesIndex = 2;
                    }
                }
                else if ((string)FlxInv.GetData(FlxInv.Row, 4) != "" && FlxInv.GetData(FlxInv.Row, 4) != null)
                {
                    ItmDes = (string)FlxInv.GetData(FlxInv.Row, 4);
                    ItmDesIndex = 3;
                }
                FrmSearch FmSerch = new FrmSearch();
                VarGeneral.SFrmTyp = "T_InvGrid";
                VarGeneral.vItmTyp = 3;
                FmSerch.Tag = LangArEn;
                VarGeneral.itmDes = ItmDes;
                VarGeneral.itmDesIndex = ItmDesIndex;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    FmSerch.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                }
                FmSerch.TopMost = true;
                FmSerch.ShowDialog();
                VarGeneral.itmDesIndex = 0;
                VarGeneral.itmDes = "";
                if (!(FmSerch.SerachNo != ""))
                {
                    try
                    {
                        FlxInv.RemoveItem(FlxInv.Row);
                        try
                        {
                            FlxInv.Rows.Add();
                        }
                        catch
                        {
                        }
                        FlxInv.Row = FlxInv.RowSel;
                        FlxInv.Col = 1;
                    }
                    catch
                    {
                    }
                    return;
                }
                listSer = db.StockItemList(FmSerch.SerachNo);
                _Items = listSer[0];
            }
            if ((!Barcod || (VarGeneral.SSSLev != "D" && VarGeneral.SSSLev != "G" && VarGeneral.SSSLev != "S" && VarGeneral.SSSLev != "B" && VarGeneral.SSSLev != "F" && VarGeneral.SSSLev != "C" && VarGeneral.SSSLev != "R" && VarGeneral.SSSLev != "H" && VarGeneral.SSSLev != "M")) && listSer.Count == 0)
            {
                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 30))
                {
                    string _SearchNo = "";
                    RepShow _RepShow = new RepShow();
                    _RepShow.Tables = " T_Items ";
                    string Fields = "";
                    Fields = ((LangArEn != 0) ? " T_Items.Itm_No as [ID Number], T_Items.Itm_No as [Item No] , T_Items.Arb_Des as [Arabic Description], T_Items.Eng_Des as [English Description] , T_Items.OpenQty as [Quantity]  " : " T_Items.Itm_No as [رقم التعريف], T_Items.Itm_No as [رقــم الصنــــف] , T_Items.Arb_Des as [الوصــف العربـــي], T_Items.Eng_Des as [الوصــف إنجلـــيزي] , T_Items.OpenQty as [الكمية] ");
                    _RepShow.Rule = " Where 1 = 1 and T_Items.ItmTyp != 2 and T_Items.ItmTyp != 3 ";
                    try
                    {
                        db.ExecuteCommand("select " + Fields + " From " + _RepShow.Tables + _RepShow.Rule + " order by  CONVERT(INT, LEFT(T_Items.Itm_No, PATINDEX('%[^0-9]%', T_Items.Itm_No + 'z')-1)) ");
                        _RepShow.Rule += " order by  CONVERT(INT, LEFT(T_Items.Itm_No, PATINDEX('%[^0-9]%', T_Items.Itm_No + 'z')-1)) ";
                    }
                    catch
                    {
                        _RepShow.Rule += " order by T_Items.Itm_No ";
                    }
                    if (!string.IsNullOrEmpty(Fields))
                    {
                        _RepShow.Fields = Fields;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                        {
                            return;
                        }
                        FMFind FmQuikSerch = new FMFind((string)FlxInv.GetData(FlxInv.Row, 1), 1);
                        FmQuikSerch.Tag = LangArEn;
                        FmQuikSerch.TopMost = true;
                        FmQuikSerch.ShowDialog();
                        _SearchNo = FmQuikSerch.SerachNo;
                    }
                    if (!(_SearchNo != ""))
                    {
                        try
                        {
                            FlxInv.RemoveItem(FlxInv.Row);
                            try
                            {
                                FlxInv.Rows.Add();
                            }
                            catch
                            {
                            }
                            FlxInv.Row = FlxInv.RowSel;
                            FlxInv.Col = 1;
                        }
                        catch
                        {
                        }
                        return;
                    }
                    listSer = db.StockItemList(_SearchNo);
                    _Items = listSer[0];
                }
                else
                {
                    List<T_Item> q = (from t in db.T_Items
                                      where t.ItmTyp != (int?)3 && t.ItmTyp != (int?)2
                                      orderby t.Itm_No
                                      select t).ToList();
                    if (q.Count == 0)
                    {
                        return;
                    }
                    FrmSearch FmSerch = new FrmSearch();
                    VarGeneral.SFrmTyp = "T_InvGrid";
                    VarGeneral.vItmTyp = 3;
                    FmSerch.Tag = LangArEn;
                    VarGeneral.itmDes = (string)FlxInv.GetData(FlxInv.Row, 1);
                    VarGeneral.itmDesIndex = 1;
                    ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
                    foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                    {
                        FmSerch.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                    }
                    FmSerch.TopMost = true;
                    FmSerch.ShowDialog();
                    VarGeneral.itmDesIndex = 0;
                    VarGeneral.itmDes = "";
                    if (!(FmSerch.SerachNo != ""))
                    {
                        try
                        {
                            FlxInv.RemoveItem(FlxInv.Row);
                            try
                            {
                                FlxInv.Rows.Add();
                            }
                            catch
                            {
                            }
                            FlxInv.Row = FlxInv.RowSel;
                            FlxInv.Col = 1;
                        }
                        catch
                        {
                        }
                        return;
                    }
                    listSer = db.StockItemList(FmSerch.SerachNo);
                    _Items = listSer[0];
                }
            }
            FlxInv.SetData(FlxInv.Row, 1, _Items.Itm_No.Trim());
            FlxInv.SetData(FlxInv.Row, 2, _Items.Arb_Des.Trim());
            FlxInv.SetData(FlxInv.Row, 4, _Items.Eng_Des.Trim());
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                txtItemName.Text = _Items.Arb_Des.Trim();
            }
            else
            {
                txtItemName.Text = _Items.Eng_Des.Trim();
            }
            FlxInv.SetData(FlxInv.Row, 6, 1);
            try
            {
                if (permission.DefStores.HasValue && permission.DefStores.Value > 0)
                {
                    FlxInv.SetData(FlxInv.Row, 6, permission.DefStores.Value);
                }
            }
            catch
            {
                FlxInv.SetData(FlxInv.Row, 6, 1);
            }
            string CoA = "";
            string CoE = "";
            string DefUnitA = "";
            string DefUnitE = "";
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (_Items.Unit1 == _Unit.Unit_ID)
                {
                    if (CoA != "")
                    {
                        CoA += "|";
                        CoE += "|";
                    }
                    CoA += _Unit.Arb_Des;
                    CoE += _Unit.Eng_Des;
                    if (_Items.DefultUnit == 1 && DefPack == 0)
                    {
                        Pack = _Items.Pack1.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost * _Items.Pack1);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack1);
                    }
                    else if (DefPack == 1)
                    {
                        Pack = _Items.Pack1.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost * _Items.Pack1);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack1);
                    }
                    break;
                }
            }
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (_Items.Unit2 == _Unit.Unit_ID)
                {
                    if (CoA != "")
                    {
                        CoA += "|";
                        CoE += "|";
                    }
                    CoA += _Unit.Arb_Des;
                    CoE += _Unit.Arb_Des;
                    if (_Items.DefultUnit == 2 && DefPack == 0)
                    {
                        Pack = _Items.Pack2.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost * _Items.Pack2);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack2);
                    }
                    else if (DefPack == 2)
                    {
                        Pack = _Items.Pack2.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost * _Items.Pack2);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack2);
                    }
                    break;
                }
            }
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (_Items.Unit3 == _Unit.Unit_ID)
                {
                    if (CoA != "")
                    {
                        CoA += "|";
                        CoE += "|";
                    }
                    CoA += _Unit.Arb_Des;
                    CoE += _Unit.Eng_Des;
                    if (_Items.DefultUnit == 3 && DefPack == 0)
                    {
                        Pack = _Items.Pack3.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost * _Items.Pack3);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack3);
                    }
                    else if (DefPack == 3)
                    {
                        Pack = _Items.Pack3.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost * _Items.Pack3);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack3);
                    }
                    break;
                }
            }
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (_Items.Unit4 == _Unit.Unit_ID)
                {
                    if (CoA != "")
                    {
                        CoA += "|";
                        CoE += "|";
                    }
                    CoA += _Unit.Arb_Des;
                    CoE += _Unit.Eng_Des;
                    if (_Items.DefultUnit == 4 && DefPack == 0)
                    {
                        Pack = _Items.Pack4.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost * _Items.Pack4);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack4);
                    }
                    else if (DefPack == 4)
                    {
                        Pack = _Items.Pack4.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost * _Items.Pack4);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack4);
                    }
                    break;
                }
            }
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (_Items.Unit5 == _Unit.Unit_ID)
                {
                    if (CoA != "")
                    {
                        CoA += "|";
                        CoE += "|";
                    }
                    CoA += _Unit.Arb_Des;
                    CoE += _Unit.Eng_Des;
                    if (_Items.DefultUnit == 5 && DefPack == 0)
                    {
                        Pack = _Items.Pack5.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost * _Items.Pack5);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack5);
                    }
                    else if (DefPack == 5)
                    {
                        Pack = _Items.Pack5.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost * _Items.Pack5);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack5);
                    }
                    break;
                }
            }
            FlxInv.Cols[3].ComboList = CoA;
            FlxInv.Cols[5].ComboList = CoE;
            double ItmPri = 0.0;
            FlxInv.SetData(FlxInv.Row, 3, DefUnitA);
            FlxInv.SetData(FlxInv.Row, 5, DefUnitE);
            BindDataofItemPrice();
            FlxInv.SetData(FlxInv.Row, 10, _Items.AvrageCost / RateValue);
            txtVCost.Text = string.Concat(Math.Round((_Items.AvrageCost * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 11))))).Value / RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2));
            FlxInv.SetData(FlxInv.Row, 30, _Items.LastCost * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 11)))) / RateValue);
            txtLCost.Text = string.Concat(Math.Round((_Items.LastCost * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 11))))).Value / RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2));
            FlxInv.SetData(FlxInv.Row, 28, _Items.Lot);
            if (_Items.Lot == 1)
            {
                FlxInv.Cols[27].Visible = true;
                FlxInv.Cols[35].Visible = true;
            }
            FlxInv.SetData(FlxInv.Row, 32, _Items.ItmTyp);
            FlxInv.SetData(FlxInv.Row, 33, _Items.ItmLoc);
            FlxInv.SetData(FlxInv.Row, 18, _Items.DefPack);
            FlxInv.SetData(FlxInv.Row, 19, _Items.Price1);
            FlxInv.SetData(FlxInv.Row, 20, _Items.Price2);
            FlxInv.SetData(FlxInv.Row, 21, _Items.Price3);
            FlxInv.SetData(FlxInv.Row, 22, _Items.Price4);
            FlxInv.SetData(FlxInv.Row, 23, _Items.Price5);
            FlxInv.SetData(FlxInv.Row, 8, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) / RateValue);
            if (FlxInv.Cols[9].Visible)
            {
                FlxInv.SetData(FlxInv.Row, 9, _Items.ItemDis.Value);
            }
            else
            {
                FlxInv.SetData(FlxInv.Row, 9, 0);
            }
            if (FlxInv.Cols[31].Visible)
            {
                FlxInv.SetData(FlxInv.Row, 31, VarGeneral.TString.ChkStatShow(_InvSetting.TaxOptions, 2) ? _Items.TaxPurchas : _Items.TaxSales);
            }
            else
            {
                FlxInv.SetData(FlxInv.Row, 31, 0);
            }
            PriceLoc = (double)FlxInv.GetData(FlxInv.Row, 8);
            BindDataOfStkQty(_Items.Itm_No.Trim());
            if (Barcod)
            {
                FlxInv.SetData(FlxInv.Row, 7, 1);
                FlxInv.SetData(FlxInv.Row, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 11)))));
                double ItmDis = 0.0;
                double ItmAddTax = 0.0;
                try
                {
                    ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 9)))) / 100.0);
                }
                catch
                {
                    ItmDis = 0.0;
                }
                try
                {
                    ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 31)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                }
                catch
                {
                    ItmAddTax = 0.0;
                }
                if (!switchButton_TaxLines.Value || switchButton_TaxByTotal.Value)
                {
                    ItmAddTax = 0.0;
                }
                FlxInv.SetData(FlxInv.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) - ItmDis + ItmAddTax);
                if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 38)))) > 0.0)
                {
                    ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 31)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    FlxInv.SetData(FlxInv.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 38)))) + ItmAddTax);
                }
                if (!chekReptItem(Col_1: true))
                {
                    FlxInv.Col = 0;
                    FlxInv.Row += 1;
                }
                else
                {
                    FlxInv.Col = 0;
                }
                GetInvTot();
            }
            else
            {
                chekRept();
            }
            VarGeneral.Flush();
        }
        private void BindDataOfStkQty(string ItmNo)
        {
            try
            {
                FlxStkQty.Clear(ClearFlags.Content, 1, 1, 1, 1);
                using (Stock_DataDataContext dbC = new Stock_DataDataContext(VarGeneral.BranchCS))
                {
                    listStkQty = dbC.T_STKSQTies.Where((T_STKSQTY t) => t.itmNo == ItmNo).ToList();
                }
                FlxInv.SetData(FlxInv.Row, 24, 0);
                for (int iiCnt = 0; iiCnt < listStkQty.Count; iiCnt++)
                {
                    _StksQty = listStkQty[iiCnt];
                    for (int I = 1; I < FlxStkQty.Rows.Count; I++)
                    {
                        if (_StksQty.storeNo.Value.ToString().Trim() == FlxStkQty.GetData(I, 0).ToString())
                        {
                            FlxStkQty.SetData(I, 1, _StksQty.stkQty / double.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(FlxInv.Row, 11).ToString())));
                            if (_StksQty.storeNo.Value.ToString().Trim() == FlxInv.GetData(FlxInv.RowSel, 6).ToString())
                            {
                                FlxInv.SetData(FlxInv.Row, 24, _StksQty.stkQty);
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }
        private void chekRept()
        {
            if (State == FormState.Saved || FlxInv.ColSel != 1)
            {
                return;
            }
            for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
            {
                if (string.IsNullOrEmpty(string.Concat(FlxInv.GetData(iiCnt, 1))) || iiCnt == FlxInv.RowSel)
                {
                    continue;
                }
                try
                {
                    if (FlxInv.GetData(iiCnt, 1).ToString() == FlxInv.GetData(FlxInv.RowSel, 1).ToString())
                    {
                        MessageBox.Show((LangArEn == 0) ? "تنبيه .. لقد قمت بأدخال هذا الصنف مسبقا\u064b في هذه الفاتورة" : "Alert .. You have entered already this product in this bill", VarGeneral.ProdectNam);
                        return;
                    }
                }
                catch
                {
                }
            }
        }
        private bool chekReptItem(bool Col_1)
        {
            if ((this.FlxInv.ColSel == 38 || this.FlxInv.ColSel == 7 || this.FlxInv.ColSel == 8 || Col_1 ? VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 17) : false))
            {
                double vQty = 0.0;
                try
                {
                    vQty = double.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(FlxInv.RowSel, 7).ToString()));
                }
                catch
                {
                    vQty = 0.0;
                }
                for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
                {
                    if (string.IsNullOrEmpty(string.Concat(FlxInv.GetData(iiCnt, 1))) || iiCnt == FlxInv.RowSel || !(FlxInv.GetData(iiCnt, 1).ToString() == FlxInv.GetData(FlxInv.RowSel, 1).ToString()) || !(FlxInv.GetData(iiCnt, 11).ToString() == FlxInv.GetData(FlxInv.RowSel, 11).ToString()) || !(FlxInv.GetData(iiCnt, 6).ToString() == FlxInv.GetData(FlxInv.RowSel, 6).ToString()))
                    {
                        continue;
                    }
                    double ItmDis = 0.0;
                    double ItmAddTax = 0.0;
                    try
                    {
                        FlxInv.SetData(iiCnt, 7, double.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 7).ToString() ?? "")) + vQty);
                    }
                    catch
                    {
                        FlxInv.SetData(iiCnt, 7, vQty);
                    }
                    ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 9)))) / 100.0);
                    ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 31)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    if (!switchButton_TaxLines.Value || switchButton_TaxByTotal.Value)
                    {
                        ItmAddTax = 0.0;
                    }
                    if (FlxInv.RowSel > 0)
                    {
                        FlxInv.RemoveItem(FlxInv.Row);
                        double RealQ = 0.0;
                        RealQ = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 11))));
                        FlxInv.SetData(iiCnt, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 11)))));
                        FlxInv.SetData(iiCnt, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) - ItmDis + ItmAddTax);
                        if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))) > 0.0)
                        {
                            ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 31)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                            FlxInv.SetData(iiCnt, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))) + ItmAddTax);
                        }
                        GetInvTot();
                        FlxInv.Row = FlxInv.RowSel;
                        FlxInv.Col = 0;
                    }
                    return true;
                }
            }
            return false;
        }
        private void BindDataofItemPrice()
        {
            if (CmbInvPrice.SelectedIndex == 0 && _Items.LastCost.Value != 0.0)
            {
                FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost.Value * Pack / RateValue);
            }
            else if (CmbInvPrice.SelectedIndex == 1 && _Items.AvrageCost.Value != 0.0)
            {
                FlxInv.SetData(FlxInv.Row, 8, _Items.AvrageCost.Value * Pack / RateValue);
            }
            else if (CmbInvPrice.SelectedIndex == 2 && _Items.StartCost.Value != 0.0)
            {
                FlxInv.SetData(FlxInv.Row, 8, _Items.StartCost.Value * Pack / RateValue);
            }
            else if (CmbInvPrice.SelectedIndex == 4 && (int)_Items.FirstCost.Value != 0)
            {
                FlxInv.SetData(FlxInv.Row, 8, _Items.FirstCost.Value * Pack / RateValue);
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
            if ((e.KeyCode == Keys.Enter && FlxInv.ColSel == 1) || (e.KeyCode == Keys.Enter && kk == 1))
            {
                {
                    SendKeys.Send("{Tab}");
                }
            }
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
            else if (e.KeyCode == Keys.F10 && Button_ExportTable2.Enabled && Button_ExportTable2.Visible && !expandableSplitter1.Expanded)
            {
                Button_ExportTable2_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F5)
            {
                if (expandableSplitter1.Expanded && buttonItem_Print.Enabled && buttonItem_Print.Visible && State == FormState.Saved)
                {
                    buttonItem_Print_Click(sender, e);
                }
                else if (Button_PrintTable.Enabled && Button_PrintTable.Visible && !expandableSplitter1.Expanded)
                {
                    Button_Print_Click(sender, e);
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
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
            else if (VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 6))
            {
                if (e.KeyCode == Keys.ControlKey)
                {
                    label24.Visible = true;
                    label23.Visible = true;
                    label22.Visible = true;
                    label25.Visible = true;
                    txtVCost.Visible = true;
                    txtUnit.Visible = true;
                    txtLCost.Visible = true;
                    txtLPrice.Visible = true;
                }
                else if (e.KeyCode == Keys.Alt)
                {
                    label24.Visible = true;
                    label23.Visible = true;
                    label22.Visible = true;
                    label25.Visible = true;
                    txtVCost.Visible = true;
                    txtUnit.Visible = true;
                    txtLCost.Visible = true;
                    txtLPrice.Visible = true;
                }
            }
        }
        private void txtRemark_ButtonCustomClick(object sender, EventArgs e)
        {
            txtRemark.Text = "";
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
                             where item.repTyp == (int?)14
                             where item.repNum == (int?)3
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
                    strfiled = ((!(_mInvPrint.pField == "PageNo")) ? VarGeneral.TString.TEmpty_Stock(string.Concat(VarGeneral.RepData.Tables[0].Rows[iiRnt][_mInvPrint.pField])) : (_page + " / " + _PageCount));
                    if (_mInvPrint.IsPrntHd == 1)
                    {
                        if (_mInvPrint.pField == "ItmNo")
                        {
                            StringFormat stringFormat = new StringFormat();
                            stringFormat.Alignment = StringAlignment.Far;
                            StringFormat format = stringFormat;
                            e.Graphics.DrawString(strfiled, _font, Brushes.Black, _mInvPrint.vCol.Value, _Row, format);
                        }
                        else
                        {
                            e.Graphics.DrawString(strfiled, _font, Brushes.Black, _mInvPrint.vCol.Value, _Row, strformat);
                        }
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
            _RepShow.Tables = "T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
            string vInvH = " T_INVHED.InvHed_ID, T_INVHED.InvId as vID, T_INVHED.InvNo, T_INVHED.InvTyp, T_INVHED.InvCashPay, T_INVHED.CusVenNo,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Arb_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNm,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Eng_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNmE, T_INVHED.CusVenAdd, T_INVHED.CusVenTel, T_INVHED.Remark, T_INVHED.HDat, T_INVHED.GDat, T_INVHED.MndNo, T_INVHED.SalsManNo, T_INVHED.SalsManNam, T_INVHED.InvTot, T_INVHED.InvDisPrs, ((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints, T_INVHED.InvNet, T_INVHED.InvNetLocCur, T_INVHED.CashPayLocCur, T_INVHED.IfRet, T_INVHED.CashPay, T_INVHED.InvTotLocCur, T_INVHED.InvDisValLocCur, T_INVHED.GadeNo, T_INVHED.GadeId, T_INVHED.RetNo, T_INVHED.RetId, T_INVHED.InvCashPayNm, T_INVHED.InvCost, T_INVHED.CustPri, T_INVHED.ArbTaf, T_INVHED.ToStore, T_INVHED.InvCash, T_INVHED.CurTyp, T_INVHED.EstDat,case when DATEDIFF(day, GETDATE(), EstDat) > 0 Then DATEDIFF(day, GETDATE(), EstDat) WHEN DATEDIFF(day, GETDATE(), InvCashPayNm) > 0 THEN DATEDIFF(day, GETDATE(), InvCashPayNm) Else '0' END as EstDatNote, T_INVHED.InvCstNo, T_INVHED.IfDel, T_INVHED.RefNo, T_INVHED.ToStoreNm, T_INVHED.EngTaf, T_INVHED.IfTrans, T_INVHED.InvQty, T_INVHED.CustNet, T_INVHED.CustRep, T_INVHED.InvWight_T, T_INVHED.IfPrint, T_INVHED.LTim, T_INVHED.DATE_CREATED, T_INVHED.MODIFIED_BY, T_INVHED.CreditPay, T_INVHED.DATE_MODIFIED, T_INVHED.CREATED_BY, T_INVHED.CreditPayLocCur, T_INVHED.NetworkPay, T_INVHED.NetworkPayLocCur, T_INVHED.MndExtrnal, T_INVHED.CompanyID, T_INVHED.InvAddCost, T_INVHED.InvAddCostExtrnal, T_INVHED.InvAddCostExtrnalLoc, T_INVHED.IsExtrnalGaid, T_INVHED.ExtrnalCostGaidID, T_INVHED.InvAddCostLoc, T_INVHED.CommMnd_Inv, T_INVHED.Puyaid, T_INVHED.Remming,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.PersonalNm from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as PersonalNm,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.City from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as City,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Email from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Email,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Mobile from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Mobile,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Telphone1 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Telphone1,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select vColStr1 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CustAge,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Telphone2 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Telphone2,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Fax from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Fax,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.zipCod from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as zipCod,T_SYSSETTING.LineGiftlNameA,T_SYSSETTING.LineGiftlNameE,T_Curency.Arb_Des as CurrnceyNm,T_Curency.Eng_Des as CurrnceyNmE,(select max(gdDes)from T_GDDET where gdID = T_INVHED.GadeId )as gdDes, (T_INVDET.Amount - (case when T_INVHED.IsTaxLines = 1 then (case when T_INVHED.IsTaxByTotal = 1 then (case when (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) > 0 then ((Abs(T_INVDET.Qty) *  T_INVDET.Price) - case when (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) > 0 then (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) else 0 end )* T_INVDET.ItmTax / 100   else 0 end) else (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) end) else 0 end )) as TotBeforeTax,(select invGdADesc from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as invGdADesc,(select invGdEDesc from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as invGdEDesc,(select T_CATEGORY.CAT_No from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CAT_No,(select T_CATEGORY.Arb_Des from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CatNmA,(select T_CATEGORY.Eng_Des from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CatNmE,(case when (select t.BarCod1 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit1 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod1 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit1 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt ))  when (select t.BarCod2 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit2 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod2 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit2 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod3 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit3 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod3 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit3 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod4 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit4 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod4 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit4 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod5 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit5 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod5 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit5 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) else T_Items.Itm_No  end) as ItmBarcod";
            string Fields = " Abs(T_INVDET.Qty) as QtyAbs , T_INVDET.InvDet_ID,T_INVHED.tailor1,T_INVHED.tailor2,T_INVHED.tailor3,T_INVHED.tailor4,T_INVHED.tailor5,T_INVHED.tailor6,T_INVHED.tailor7,T_INVHED.tailor8,T_INVHED.tailor9,T_INVHED.tailor10,T_INVHED.tailor11,T_INVHED.tailor12,T_INVHED.tailor13,T_INVHED.tailor14,T_INVHED.tailor15,T_INVHED.tailor16,T_INVHED.tailor17,T_INVHED.tailor18,T_INVHED.tailor19,T_INVHED.tailor20,T_INVHED.InvImg, T_INVDET.InvNo, T_INVDET.InvId, T_INVDET.InvSer, T_INVDET.ItmNo, T_INVDET.Cost, T_INVDET.Qty, T_INVDET.ItmUnt, T_INVDET.ItmDes,T_INVDET.ItmDesE , T_INVDET.ItmUntE, T_INVDET.ItmUntPak, T_INVDET.StoreNo, T_INVDET.Price, T_INVDET.Amount, T_INVDET.RealQty, T_INVDET.ItmTyp,T_INVDET.ItmDis, (Abs(T_INVDET.Qty) *  T_INVDET.Price) * (T_INVDET.ItmDis / 100) as ItmDisVal, T_INVDET.DatExper, T_INVDET.itmInvDsc,ItmIndex," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.LineGiftSts, vStr(VarGeneral.InvTyp)) ? " T_INVDET.ItmWight " : " 0 as ItmWight") + ", T_INVDET.ItmWight_T, T_INVDET.ItmAddCost, T_INVDET.RunCod, T_INVDET.LineDetails ,T_INVDET.Serial_Key, " + vInvH + ", T_Items.* , T_CstTbl.Arb_Des as CstTbl_Arb_Des , T_CstTbl.Eng_Des as CstTbl_Eng_Des , T_Mndob.Arb_Des as Mndob_Arb_Des , T_Mndob.Eng_Des as Mndob_Eng_Des,T_SYSSETTING.LogImg,(select max(T_AccDef.TaxNo) from T_AccDef where T_AccDef.AccDef_No = T_SYSSETTING.TaxAcc) as TaxAcc,T_SYSSETTING.TaxNoteInv,case when T_INVHED.IsTaxLines = 1 then (case when T_INVHED.IsTaxByTotal = 1 then (case when (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) > 0 then ((Abs(T_INVDET.Qty) *  T_INVDET.Price) - case when (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) > 0 then (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) else 0 end )* T_INVDET.ItmTax / 100   else 0 end) else (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) end) else 0 end as TaxValue ,(select InvNamA from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as InvNamA,(select InvNamE from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as InvNamE,(select T_Store.Arb_Des from T_Store where T_Store.Stor_ID = T_INVDET.StoreNo) as StoreNmA,(select T_Store.Eng_Des from T_Store where T_Store.Stor_ID = T_INVDET.StoreNo) as StoreNmE,(select defPrn from T_INVSETTING where CatID = (select ItmCat from T_Items where Itm_No = T_INVDET.ItmNo) ) as defPrn,case when T_INVHED.CusVenNo = '' THEN '0' ELSE (SELECT Sum(T_GDDET.gdValue) FROM T_GDHEAD INNER JOIN  T_GDDET ON T_GDHEAD.gdhead_ID = T_GDDET.gdID where T_GDDET.AccNo = T_INVHED.CusVenNo and T_GDHEAD.gdLok = 0 and (select T_AccDef.AccCat from T_AccDef where T_AccDef.AccDef_No = T_INVHED.CusVenNo) = '4') END as Balanc,T_INVDET.ItmTax,T_INVHED.InvAddTax,T_INVHED.InvAddTaxlLoc,T_INVHED.TaxGaidID,T_INVHED.IsTaxUse,T_INVHED.IsTaxLines,IsTaxByTotal,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.TaxNo from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as TaxCustNo,T_INVHED.OrderTyp," + ((data_this.IsTaxLines.Value && !VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65)) ? " T_INVHED.InvTotLocCur - T_INVHED.InvAddTax as TotWithTaxPoint " : " T_INVHED.InvTotLocCur as TotWithTaxPoint") + " ,T_INVHED.InvTotLocCur - T_INVHED.InvDisVal as TotBeforeDisVal,T_INVHED.IsTaxByNet,T_INVHED.TaxByNetValue," + (data_this.IsTaxUse.Value ? " T_INVHED.InvNetLocCur - T_INVHED.InvAddTax as NetWithoutTax " : " T_INVHED.InvNetLocCur as NetWithoutTax");
            VarGeneral.HeaderRep[0] = Text;
            VarGeneral.HeaderRep[1] = "";
            VarGeneral.HeaderRep[2] = "";
            _RepShow.Rule = " where T_INVHED.InvHed_ID = " + data_this.InvHed_ID;
            if (string.IsNullOrEmpty(Fields))
            {
                return;
            }
            _RepShow.Fields = Fields;
            try
            {
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                _RepShow = new RepShow();
                _RepShow.Rule = " WHERE T_Users.UsrNo = '" + data_this.SalsManNo + "'";
                _RepShow.Tables = " T_Branch INNER JOIN T_Users ON T_Branch.Branch_no = T_Users.Brn ";
                _RepShow.Fields = " T_Users.UsrNamA ,T_Branch.Branch_Name ,T_Users.UsrNamE ,T_Branch.Branch_NameE ,T_Users.UsrImg ";
                try
                {
                    VarGeneral.RepShowStock_Rat = "Rate";
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepShowStock_Rat = "";
                }
                catch (Exception ex2)
                {
                    VarGeneral.RepShowStock_Rat = "";
                    MessageBox.Show(ex2.Message);
                }
                try
                {
                    for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
                    {
                        if (string.IsNullOrEmpty(VarGeneral.RepData.Tables[0].Rows[i]["LogImg"].ToString()))
                        {
                            VarGeneral.RepData.Tables[0].Rows[i]["LogImg"] = VarGeneral.RepData.Tables[0].Rows[VarGeneral.RepData.Tables[0].Rows.Count - 1]["LogImg"];
                            VarGeneral.RepData.Tables[0].Rows[i]["LTim"] = VarGeneral.RepData.Tables[0].Rows[VarGeneral.RepData.Tables[0].Rows.Count - 1]["LTim"];
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
                    {
                        try
                        {
                            VarGeneral.RepData.Tables[0].Rows[i]["SalsManNam"] = _RepShow.RepData.Tables[0].Rows[0][(LangArEn == 0) ? "UsrNamA" : "UsrNamE"];
                        }
                        catch
                        {
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    if (VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 15))
                    {
                        _RepShow = new RepShow();
                        _RepShow.Rule = "";
                        _RepShow.Tables = "T_SINVDET LEFT OUTER JOIN T_INVHED ON T_SINVDET.SInvIdHEAD = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_SINVDET.SItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                        _RepShow.Fields = " Abs(T_SINVDET.SQty) as QtyAbs , SInvDet_ID as InvId, SInvNo as InvNo, SInvId as InvDet_ID, SInvSer as InvSer,SItmNo as ItmNo, SCost as Cost, SQty as Qty, SItmDes as ItmDes, SItmUnt as ItmUnt, SItmDesE as ItmDesE, SItmUntE as ItmUntE, SItmUntPak as ItmUntPak, SStoreNo as StoreNo, (SPrice * 0) as Price, (SAmount * 0) as Amount, SRealQty as RealQty, SitmInvDsc as itmInvDsc, SDatExper as DatExper, SItmDis as ItmDis, SItmTyp as ItmTyp,SItmIndex as ItmIndex, SItmWight_T as ItmWight_T, SItmWight as ItmWight , T_INVHED.* , T_Items.* , T_CstTbl.Arb_Des as CstTbl_Arb_Des , T_CstTbl.Eng_Des as CstTbl_Eng_Des , T_Mndob.Arb_Des as Mndob_Arb_Des , T_Mndob.Eng_Des as Mndob_Eng_Des,T_SYSSETTING.LogImg,(select max(T_AccDef.TaxNo) from T_AccDef where T_AccDef.AccDef_No = T_SYSSETTING.TaxAcc) as TaxAcc,T_SYSSETTING.TaxNoteInv";
                        _RepShow.Rule = " where T_INVHED.InvHed_ID = " + data_this.InvHed_ID;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData.Tables[0].Merge(_RepShow.RepData.Tables[0]);
                    }
                }
                catch
                {
                }
                iiRntP = 0;
                _page = 1;
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }
        private void txtDebit1_ButtonCustomClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            Button_Edit_Click(sender, e);
            columns_Names_visible2.Clear();
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
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != "")
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtDebit1.Tag = _AccDef.AccDef_No;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtDebit1.Text = _AccDef.Arb_Des;
                    }
                    else
                    {
                        txtDebit1.Text = _AccDef.Eng_Des;
                    }
                }
                else
                {
                    txtDebit1.Text = "";
                    txtDebit1.Tag = "";
                }
            }
            catch
            {
                txtDebit1.Text = "";
                txtDebit1.Tag = "";
            }
        }
        private void txtCredit1_ButtonCustomClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            Button_Edit_Click(sender, e);
            columns_Names_visible2.Clear();
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
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != "")
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtCredit1.Tag = _AccDef.AccDef_No;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtCredit1.Text = _AccDef.Arb_Des;
                    }
                    else
                    {
                        txtCredit1.Text = _AccDef.Eng_Des;
                    }
                }
                else
                {
                    txtCredit1.Text = "";
                    txtCredit1.Tag = "";
                }
            }
            catch
            {
                txtCredit1.Text = "";
                txtCredit1.Tag = "";
            }
        }
        private void LastPrice(T_Item vItm)
        {
            try
            {
                var q = (from t in db.T_INVDETs
                         where t.T_INVHED.InvTyp == (int?)VarGeneral.InvTyp
                         where t.ItmNo == vItm.Itm_No
                         orderby t.T_INVHED.InvHed_ID descending
                         select new
                         {
                             t.InvNo,
                             t.Price,
                             t.ItmUnt,
                             t.ItmUntE,
                             t.InvSer
                         }).ToList();
                if (q.Count > 0)
                {
                    T_INVHED vInvH = db.StockInvHead(VarGeneral.InvTyp, q.First().InvNo);
                    txtLPrice.Text = string.Concat(Math.Round(vInvH.T_INVDETs.Where((T_INVDET g) => g.ItmNo == vItm.Itm_No).Last().Price.Value / RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2));
                    txtUnit.Text = ((LangArEn == 0) ? vInvH.T_INVDETs.Last().ItmUnt : vInvH.T_INVDETs.Last().ItmUntE);
                }
                else
                {
                    txtLPrice.Text = "0";
                    txtUnit.Text = "";
                }
            }
            catch
            {
                txtLPrice.Text = "0";
                txtUnit.Text = "";
            }
        }
        private void button_AllItems_Click(object sender, EventArgs e)
        {
            if (State != FormState.New)
            {
                return;
            }
            List<T_Item> q = db.FillItem_2("").ToList();
            try
            {
                q = q.OrderBy((T_Item c) => int.Parse(c.Itm_No)).ToList();
            }
            catch
            {
                //      q = q.OrderBy((T_Item c) => c.Itm_No).ToList();
            }
            if (q.Count > 0)
            {
                FlxInv.Clear(ClearFlags.Content, 1, 1, FlxInv.Rows.Count - 1, 38);
                FlxStkQty.Clear(ClearFlags.Content, 1, 1, 1, 1);
                FlxInv.Rows.Count = q.Count + 100;
                for (int i = 0; i < q.Count; i++)
                {
                    FlxInv.SetData(i + 1, 1, q[i].Itm_No);
                    FlxInv.RowSel = i + 1;
                    FlxInv.ColSel = 1;
                    FlxInv.Row = i + 1;
                    FlxInv.Col = 1;
                    FlxInv_AfterEdit(sender, new RowColEventArgs(i + 1, 1));
                }
            }
        }
        private void button_SomeItems_Click(object sender, EventArgs e)
        {
            if (State != FormState.New)
            {
                return;
            }
            FrmInvCat frm = new FrmInvCat();
            frm.Tag = LangArEn;
            frm.TopMost = true;
            frm.ShowDialog();
            if (!frm.vSts_Op || string.IsNullOrEmpty(frm.List_Cat))
            {
                return;
            }
            List<T_Item> q = db.ExecuteQuery<T_Item>("select * from T_Items where 1 = 1" + frm.List_Cat, new object[0]).ToList();
            if (q.Count > 0)
            {
                FlxInv.Clear(ClearFlags.Content, 1, 1, FlxInv.Rows.Count - 1, 38);
                FlxStkQty.Clear(ClearFlags.Content, 1, 1, 1, 1);
                FlxInv.Rows.Count = q.Count + 100;
                for (int i = 0; i < q.Count; i++)
                {
                    FlxInv.SetData(i + 1, 1, q[i].Itm_No);
                    FlxInv.RowSel = i + 1;
                    FlxInv.ColSel = 1;
                    FlxInv.Row = i + 1;
                    FlxInv.Col = 1;
                    FlxInv_AfterEdit(sender, new RowColEventArgs(i + 1, 1));
                }
            }
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
        private void switchButton_Lock_ValueChanged(object sender, EventArgs e)
        {
            Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
        }
        private void button_Repetition_Click(object sender, EventArgs e)
        {
            try
            {
                string c = textBox_ID.Text;
                if (!string.IsNullOrEmpty(c))
                {
                    Button_Add_Click(sender, e);
                    RepetitionSts = true;
                    SetData(db.StockInvHead(VarGeneral.InvTyp, c));
                    _GdHead = new T_GDHEAD();
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_Repetition_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            RepetitionSts = false;
            ReverseSts = false;
        }
        private void textBox_ID_ButtonCustomClick(object sender, EventArgs e)
        {
            if (State != 0 || string.IsNullOrEmpty(textBox_ID.Text) || !CanEdit || switchButton_Lock.Value)
            {
                return;
            }
            string vNewNo = InputDialog.mostrar((LangArEn == 0) ? "أدخل رقم الفاتورة الجديد : " : "Insert New Invoice No : ", (LangArEn == 0) ? "تعديل رقم فاتورة" : "Invoice No Edite");
            if (string.IsNullOrEmpty(vNewNo))
            {
                return;
            }
            int ChkNo = 0;
            try
            {
                ChkNo = int.Parse(vNewNo);
            }
            catch
            {
                ChkNo = 0;
            }
            if (ChkNo <= 0)
            {
                MessageBox.Show((LangArEn == 0) ? " يجب استخدام الأرقام فقط لتعيين رقم الفاتورة" : "Numbers must be used only to set the invoice number", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_ID.Focus();
                return;
            }
            try
            {
                List<T_INVHED> q = (from t in db.T_INVHEDs
                                    where t.InvNo == vNewNo
                                    where t.InvTyp == (int?)VarGeneral.InvTyp
                                    where t.IfDel == (int?)0
                                    select t).ToList();
                if (q.Count > 0)
                {
                    MessageBox.Show((LangArEn == 0) ? " رقم الفاتورة مكرر يرجى تغييره" : "Employee No It's a existing", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_ID.Focus();
                    return;
                }
                textBox_ID.TextChanged -= textBox_ID_TextChanged;
                _StopMove = false;
                textBox_ID.Text = vNewNo;
                State = FormState.Edit;
                Button_Save.Enabled = true;
                Button_Save_Click(sender, e);
                textBox_ID.TextChanged += textBox_ID_TextChanged;
            }
            catch (Exception error)
            {
                textBox_ID.TextChanged += textBox_ID_TextChanged;
                VarGeneral.DebLog.writeLog("textBox_ID_ButtonCustomClick:", error, enable: true);
                MessageBox.Show((LangArEn == 0) ? "حصل خطأ ما .. لم يتم عملية التعديل بنجاح" : "Error .. Editing is not Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                MessageBox.Show(error.Message);
            }
            _StopMove = true;
        }
        private void switchButton_Tax_ValueChanged(object sender, EventArgs e)
        {
            GetInvTot();
        }
        private void checkBox_CostGaidTax_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_CostGaidTax.Checked)
            {
                txtDebit5.Enabled = true;
                txtCredit5.Enabled = true;
                if (VarGeneral.SSSTyp == 0)
                {
                    return;
                }
                if (checkBox_Chash.Checked)
                {
                    txtCredit5.Tag = ((_InvSetting.TaxCredit.Trim() != "***") ? _InvSetting.TaxCredit.Trim() : "");
                    if (!string.IsNullOrEmpty(txtCredit5.Tag.ToString()))
                    {
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                        {
                            txtCredit5.Text = db.SelectAccRootByCode(txtCredit5.Tag.ToString()).Arb_Des;
                        }
                        else
                        {
                            txtCredit5.Text = db.SelectAccRootByCode(txtCredit5.Tag.ToString()).Eng_Des;
                        }
                    }
                    else
                    {
                        txtCredit5.Text = "";
                    }
                    txtDebit5.Tag = ((_InvSetting.TaxDebit.Trim() != "***") ? _InvSetting.TaxDebit.Trim() : "");
                    if (!string.IsNullOrEmpty(txtDebit5.Tag.ToString()))
                    {
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                        {
                            txtDebit5.Text = db.SelectAccRootByCode(txtDebit5.Tag.ToString()).Arb_Des;
                        }
                        else
                        {
                            txtDebit5.Text = db.SelectAccRootByCode(txtDebit5.Tag.ToString()).Eng_Des;
                        }
                    }
                    else
                    {
                        txtDebit5.Text = "";
                    }
                    return;
                }
                txtCredit5.Tag = ((_InvSetting.TaxCreditCredit.Trim() != "***") ? _InvSetting.TaxCreditCredit.Trim() : "");
                if (!string.IsNullOrEmpty(txtCredit5.Tag.ToString()))
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtCredit5.Text = db.SelectAccRootByCode(txtCredit5.Tag.ToString()).Arb_Des;
                    }
                    else
                    {
                        txtCredit5.Text = db.SelectAccRootByCode(txtCredit5.Tag.ToString()).Eng_Des;
                    }
                }
                else
                {
                    txtCredit5.Text = "";
                }
                txtDebit5.Tag = ((_InvSetting.TaxDebitCredit.Trim() != "***") ? _InvSetting.TaxDebitCredit.Trim() : "");
                if (!string.IsNullOrEmpty(txtDebit5.Tag.ToString()))
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtDebit5.Text = db.SelectAccRootByCode(txtDebit5.Tag.ToString()).Arb_Des;
                    }
                    else
                    {
                        txtDebit5.Text = db.SelectAccRootByCode(txtDebit5.Tag.ToString()).Eng_Des;
                    }
                }
                else
                {
                    txtDebit5.Text = "";
                }
            }
            else
            {
                txtDebit5.Enabled = false;
                txtCredit5.Enabled = false;
            }
        }
        private void checkBox_GaidDis_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_GaidDis.Checked)
            {
                txtDebit6.Enabled = true;
                txtCredit6.Enabled = true;
                if (VarGeneral.SSSTyp == 0)
                {
                    return;
                }
                if (string.IsNullOrEmpty(txtCredit6.Text))
                {
                    txtCredit6.Tag = ((_InvSetting.DisCredit.Trim() != "***") ? _InvSetting.DisCredit.Trim() : "");
                    if (!string.IsNullOrEmpty(txtCredit6.Tag.ToString()))
                    {
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                        {
                            txtCredit6.Text = db.SelectAccRootByCode(txtCredit6.Tag.ToString()).Arb_Des;
                        }
                        else
                        {
                            txtCredit6.Text = db.SelectAccRootByCode(txtCredit6.Tag.ToString()).Eng_Des;
                        }
                    }
                    else
                    {
                        txtCredit6.Text = "";
                    }
                }
                if (!string.IsNullOrEmpty(txtDebit6.Text))
                {
                    return;
                }
                txtDebit6.Tag = ((_InvSetting.DisDebit.Trim() != "***") ? _InvSetting.DisDebit.Trim() : "");
                if (!string.IsNullOrEmpty(txtDebit6.Tag.ToString()))
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtDebit6.Text = db.SelectAccRootByCode(txtDebit6.Tag.ToString()).Arb_Des;
                    }
                    else
                    {
                        txtDebit6.Text = db.SelectAccRootByCode(txtDebit6.Tag.ToString()).Eng_Des;
                    }
                }
                else
                {
                    txtDebit6.Text = "";
                }
            }
            else
            {
                txtDebit6.Enabled = false;
                txtCredit6.Enabled = false;
            }
        }
        private void switchButton_Dis_ValueChanged(object sender, EventArgs e)
        {
            GetInvTot();
        }
        private void switchButton_TaxLines_ValueChanged(object sender, EventArgs e)
        {
            if (State == FormState.Saved)
            {
                return;
            }
            for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
            {
                if (string.Concat(FlxInv.GetData(iiCnt, 1)) != "")
                {
                    double ItmDis = 0.0;
                    double ItmAddTax = 0.0;
                    ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 9)))) / 100.0);
                    ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 31)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    if (!switchButton_TaxLines.Value || switchButton_TaxByTotal.Value)
                    {
                        ItmAddTax = 0.0;
                    }
                    FlxInv.SetData(iiCnt, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) - ItmDis + ItmAddTax);
                    if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))) > 0.0)
                    {
                        ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 31)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                        FlxInv.SetData(iiCnt, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))) + ItmAddTax);
                    }
                }
            }
            GetInvTot();
        }
        private void switchButton_TaxByNet_ValueChanged(object sender, EventArgs e)
        {
            if (switchButton_TaxByNet.Value)
            {
                textBoxItem_TaxByNetValue.Visible = true;
                labelItem_TaxByNetPer.Visible = true;
                switchButton_TaxByTotal.Visible = false;
            }
            else
            {
                textBoxItem_TaxByNetValue.Visible = false;
                labelItem_TaxByNetPer.Visible = false;
                switchButton_TaxByTotal.Visible = true;
            }
        }
        private void textBoxItem_TaxByNetValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b')) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
            }
            catch
            {
                e.Handled = true;
            }
        }
        private void textBoxItem_TaxByNetValue_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxItem_TaxByNetValue.Text))
                {
                    textBoxItem_TaxByNetValue.Text = "0";
                }
            }
            catch
            {
                textBoxItem_TaxByNetValue.Text = "0";
            }
            GetInvTot();
        }
        private void Button_BarcodPrint_Click(object sender, EventArgs e)
        {
            if (!(textBox_ID.Text != "") || State != 0)
            {
                return;
            }
            for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
            {
                try
                {
                    if (!(string.Concat(FlxInv.GetData(iiCnt, 1)) != ""))
                    {
                        continue;
                    }
                    vRowBarcode = iiCnt;
                    for (int i = 0; (double)i < ((VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 32) && _InvSettingBarCod.nTyp.Substring(2, 1) == "0") ? double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(vRowBarcode, 7)))) : 1.0); i++)
                    {
                        PrintSet2();
                        prnt_prev = new PrintPreviewDialog();
                        ToolStrip toollstr = (ToolStrip)prnt_prev.Controls["toolStrip1"];
                        toollstr.Items.RemoveAt(0);
                        toollstr.Items.Add("Print", null, PrintForm_Click);
                        prnt_prev.Controls.Add(toollstr);
                        prnt_prev.Document = prnt_doc2;
                        prnt_prev.ShowIcon = false;
                        prnt_prev.AllowTransparency = true;
                        prnt_prev.MdiParent = base.MdiParent;
                        PrintDialog PrintDialog1 = new PrintDialog();
                        printDialog1.Document = prnt_doc2;
                        try
                        {
                            if (_InvSettingBarCod.DefLines.Value > 0)
                            {
                                if (_InvSettingBarCod.InvTypA4 == "1")
                                {
                                    prnt_doc2.PrinterSettings.Collate = true;
                                }
                                else
                                {
                                    prnt_doc2.PrinterSettings.Collate = false;
                                }
                            }
                            else
                            {
                                prnt_doc2.PrinterSettings.Collate = false;
                            }
                        }
                        catch
                        {
                            prnt_doc2.PrinterSettings.Collate = false;
                        }
                        try
                        {
                            if (_InvSettingBarCod.nTyp.Substring(2, 1) == "0")
                            {
                                prnt_doc2.Print();
                                continue;
                            }
                            prnt_prev.TopMost = true;
                            prnt_prev.ShowDialog();
                        }
                        catch
                        {
                        }
                    }
                }
                catch
                {
                }
            }
        }
        private void PrintSet2()
        {
            string _PrinterName = prnt_doc2.PrinterSettings.PrinterName;
            prnt_doc2.PrinterSettings.PrinterName = _InvSettingBarCod.defPrn;
            if (!prnt_doc2.PrinterSettings.IsValid)
            {
                prnt_doc2.PrinterSettings.PrinterName = _PrinterName;
            }
        }
        private void PrintForm_Click(object sender, EventArgs e)
        {
            PrintDialog PrintDialog1 = new PrintDialog();
            printDialog1.Document = prnt_doc2;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                prnt_doc2.Print();
            }
        }
        private void prnt_doc2_BeginPrint(object sender, PrintEventArgs e)
        {
            CountPage = 0;
        }
        private void prnt_doc2_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                e.PageSettings.Margins.Bottom = 0;
                e.PageSettings.Margins.Top = Convert.ToInt32(_InvSettingBarCod.hAl);
                e.PageSettings.Margins.Left = Convert.ToInt32(_InvSettingBarCod.hYs);
                e.PageSettings.Margins.Right = 0;
                try
                {
                    e.PageSettings.PrinterSettings.Copies = short.Parse(_InvSettingBarCod.DefLines.Value.ToString());
                }
                catch
                {
                    e.PageSettings.PrinterSettings.Copies = 1;
                }
                List<T_mInvPrint> listmInvPrint = new List<T_mInvPrint>();
                T_mInvPrint _mInvPrint = new T_mInvPrint();
                listmInvPrint = (from item in db.T_mInvPrints
                                 where item.repTyp == (int?)22
                                 where item.repNum == (int?)4
                                 where item.IsPrint == (int?)1
                                 where item.BarcodeTyp == (int?)4
                                 select item).ToList();
                if (listmInvPrint.Count == 0)
                {
                    return;
                }
                double _isRows = 0.0;
                double _isCols = 0.0;
                float _Row = 0f;
                float _Col = 0f;
                double _PageLine = _InvSettingBarCod.lnPg.Value;
                double _LineSp = _InvSettingBarCod.lnSpc.Value;
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
                            if (_mInvPrint.pField == "InvNo")
                            {
                                try
                                {
                                    c1BarCode1.Text = textBox_ID.Text;
                                    e.Graphics.DrawImage(c1BarCode1.Image, _Col, _Row, float.Parse(_mInvPrint.MaxW.Value.ToString()), float.Parse(_mInvPrint.vSize.Value.ToString()));
                                }
                                catch
                                {
                                }
                            }
                            if (_mInvPrint.pField == "ItmBarC")
                            {
                                try
                                {
                                    c1BarCode1.Text = db.StockItemBarcod(FlxInv.GetData(vRowBarcode, 1).ToString(), FlxInv.GetData(vRowBarcode, 3).ToString(), FlxInv.GetData(vRowBarcode, 5).ToString());
                                    e.Graphics.DrawImage(c1BarCode1.Image, _Col, _Row, float.Parse(_mInvPrint.MaxW.Value.ToString()), float.Parse(_mInvPrint.vSize.Value.ToString()));
                                }
                                catch
                                {
                                }
                            }
                            else if (_mInvPrint.pField == "ItmNo")
                            {
                                StringFormat stringFormat = new StringFormat();
                                stringFormat.Alignment = StringAlignment.Far;
                                StringFormat format = stringFormat;
                                e.Graphics.DrawString(FlxInv.GetData(vRowBarcode, 1).ToString(), _font, Brushes.Black, _Col, _Row, format);
                            }
                            else if (_mInvPrint.pField == "ItmDes")
                            {
                                e.Graphics.DrawString(FlxInv.GetData(vRowBarcode, 2).ToString(), _font, Brushes.Black, _Col, _Row, strformat);
                            }
                            else if (_mInvPrint.pField == "ItmDesE")
                            {
                                e.Graphics.DrawString(FlxInv.GetData(vRowBarcode, 4).ToString(), _font, Brushes.Black, _Col, _Row, strformat);
                            }
                            else if (_mInvPrint.pField == "ItmUnt")
                            {
                                e.Graphics.DrawString(FlxInv.GetData(vRowBarcode, 3).ToString(), _font, Brushes.Black, _Col, _Row, strformat);
                            }
                            else if (_mInvPrint.pField == "ItmUntE")
                            {
                                e.Graphics.DrawString(FlxInv.GetData(vRowBarcode, 5).ToString(), _font, Brushes.Black, _Col, _Row, strformat);
                            }
                            else if (_mInvPrint.pField == "Qty")
                            {
                                e.Graphics.DrawString(FlxInv.GetData(vRowBarcode, 7).ToString(), _font, Brushes.Black, _Col, _Row, strformat);
                            }
                            else if (_mInvPrint.pField == "Price")
                            {
                                e.Graphics.DrawString(FlxInv.GetData(vRowBarcode, 8).ToString() + " " + _Curency.Symbol, _font, Brushes.Black, _Col, _Row, strformat);
                            }
                            else if (_mInvPrint.pField == "LineDetails")
                            {
                                e.Graphics.DrawString((VarGeneral.InvTyp == 2 || VarGeneral.InvTyp == 4 || VarGeneral.InvTyp == 9) ? FlxInv.GetData(vRowBarcode, 37).ToString() : FlxInv.GetData(vRowBarcode, 36).ToString(), _font, Brushes.Black, _Col, _Row, strformat);
                            }
                            else if (_mInvPrint.pField == "CompanyName")
                            {
                                e.Graphics.DrawString(_Company.CopNam, _font, Brushes.Black, _Col, _Row, strformat);
                            }
                            else if (_mInvPrint.pField == "CusVenNo")
                            {
                                e.Graphics.DrawString("", _font, Brushes.Black, _Col, _Row, strformat);
                            }
                            else if (_mInvPrint.pField == "CusVenNm")
                            {
                                e.Graphics.DrawString("", _font, Brushes.Black, _Col, _Row, strformat);
                            }
                            else if (_mInvPrint.pField == "HDat")
                            {
                                e.Graphics.DrawString(txtHDate.Text, _font, Brushes.Black, _Col, _Row, strformat);
                            }
                            else if (_mInvPrint.pField == "GDat")
                            {
                                e.Graphics.DrawString(txtGDate.Text, _font, Brushes.Black, _Col, _Row, strformat);
                            }
                            else if (_mInvPrint.pField == "ItmPrice")
                            {
                                try
                                {
                                    e.Graphics.DrawString(db.StockItemPrice(FlxInv.GetData(vRowBarcode, 1).ToString(), FlxInv.GetData(vRowBarcode, 3).ToString(), FlxInv.GetData(vRowBarcode, 5).ToString()) + " " + _Curency.Symbol, _font, Brushes.Black, _Col, _Row, strformat);
                                }
                                catch
                                {
                                }
                            }
                            else if (_mInvPrint.pField == "Puyaid")
                            {
                                try
                                {
                                    e.Graphics.DrawString("", _font, Brushes.Black, _Col, _Row, strformat);
                                }
                                catch
                                {
                                }
                            }
                            else if (_mInvPrint.pField == "Remming")
                            {
                                try
                                {
                                    e.Graphics.DrawString("", _font, Brushes.Black, _Col, _Row, strformat);
                                }
                                catch
                                {
                                }
                            }
                            else if (_mInvPrint.pField == "Remark")
                            {
                                try
                                {
                                    e.Graphics.DrawString(txtRemark.Text, _font, Brushes.Black, _Col, _Row, strformat);
                                }
                                catch
                                {
                                }
                            }
                            else if (_mInvPrint.pField == "EstDat")
                            {
                                try
                                {
                                    e.Graphics.DrawString("", _font, Brushes.Black, _Col, _Row, strformat);
                                }
                                catch
                                {
                                }
                            }
                            else if (_mInvPrint.pField == "RunCod")
                            {
                                try
                                {
                                    e.Graphics.DrawString(FlxInv.GetData(vRowBarcode, 35).ToString(), _font, Brushes.Black, _Col, _Row, strformat);
                                }
                                catch
                                {
                                }
                            }
                            else if (_mInvPrint.pField == "RefNo")
                            {
                                try
                                {
                                    e.Graphics.DrawString(txtRef.Text, _font, Brushes.Black, _Col, _Row, strformat);
                                }
                                catch
                                {
                                }
                            }
                            else if (_mInvPrint.pField == "rTrwes1" || _mInvPrint.pField == "rTrwes2" || _mInvPrint.pField == "rTrwes3" || _mInvPrint.pField == "rTrwes4" || _mInvPrint.pField == "lTrwes1" || _mInvPrint.pField == "lTrwes2" || _mInvPrint.pField == "lTrwes3" || _mInvPrint.pField == "lTrwes4")
                            {
                                try
                                {
                                    e.Graphics.DrawString((from t in db.T_InfoTbs
                                                           where t.fldFlag == _mInvPrint.pField.ToString()
                                                           select new
                                                           {
                                                               t.fldValue
                                                           }).FirstOrDefault().fldValue, _font, Brushes.Black, _Col, _Row, strformat);
                                }
                                catch
                                {
                                }
                            }
                            else if (_mInvPrint.pField == "CusVenAdd")
                            {
                                try
                                {
                                    e.Graphics.DrawString("", _font, Brushes.Black, _Col, _Row, strformat);
                                }
                                catch
                                {
                                }
                            }
                            else if (_mInvPrint.pField == "SalsManNam")
                            {
                                try
                                {
                                    e.Graphics.DrawString(textBox_Usr.Text, _font, Brushes.Black, _Col, _Row, strformat);
                                }
                                catch
                                {
                                }
                            }
                            else if (_mInvPrint.pField == "DatExper")
                            {
                                try
                                {
                                    e.Graphics.DrawString(FlxInv.GetData(vRowBarcode, 27).ToString(), _font, Brushes.Black, _Col, _Row, strformat);
                                }
                                catch
                                {
                                }
                            }
                            else if (_mInvPrint.pField == "TaxNoteInv")
                            {
                                try
                                {
                                    e.Graphics.DrawString(VarGeneral.Settings_Sys.TaxNoteInv, _font, Brushes.Black, _Col, _Row, strformat);
                                }
                                catch
                                {
                                }
                            }
                            else if (_mInvPrint.pField == "pationName_W")
                            {
                                try
                                {
                                    e.Graphics.DrawString((LangArEn == 0) ? "إسم المريض :" : "Patient name :", _font, Brushes.Black, _Col, _Row, strformat);
                                }
                                catch
                                {
                                }
                            }
                            else if (_mInvPrint.pField == "medicinName_W")
                            {
                                try
                                {
                                    e.Graphics.DrawString((LangArEn == 0) ? "الدواء :" : "Medicine :", _font, Brushes.Black, _Col, _Row, strformat);
                                }
                                catch
                                {
                                }
                            }
                            else if (_mInvPrint.pField == "ExpirDate_W")
                            {
                                try
                                {
                                    e.Graphics.DrawString((LangArEn == 0) ? "تاريخ الصلاحية :" : "Expiration date :", _font, Brushes.Black, _Col, _Row, strformat);
                                }
                                catch
                                {
                                }
                            }
                            else if (_mInvPrint.pField == "UseMethod_W")
                            {
                                try
                                {
                                    e.Graphics.DrawString((LangArEn == 0) ? "طريقة الإستخدام :" : "Usage :", _font, Brushes.Black, _Col, _Row, strformat);
                                }
                                catch
                                {
                                }
                            }
                        }
                        _isCols = _isCols + (double)_InvSettingBarCod.InvNum1.Value + _InvSettingBarCod.hYm.Value;
                    }
                    _isRows = _isRows + (double)_InvSettingBarCod.InvNum.Value + _InvSettingBarCod.hAs.Value;
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
        private void Button_Export_Click(object sender, EventArgs e)
        {
            try
            {
                FrmInvExport frm = new FrmInvExport();
                frm.Tag = LangArEn;
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.ExcelGridView.Rows.Count <= 0 || string.IsNullOrEmpty(frm.textBox_ItmNo.Text))
                {
                    return;
                }
                FlxInv.Clear(ClearFlags.Content, 1, 1, FlxInv.Rows.Count - 1, 38);
                FlxStkQty.Clear(ClearFlags.Content, 1, 1, 1, 1);
                FlxInv.Rows.Count = frm.ExcelGridView.Rows.Count + 2;
                int iiCnt;
                for (iiCnt = 1; iiCnt <= frm.ExcelGridView.Rows.Count; iiCnt++)
                {
                    T_Item newData = db.StockItem(frm.ExcelGridView.Rows[iiCnt - 1].Cells[frm.textBox_ItmNo.Text].Value.ToString());
                    if (newData == null || string.IsNullOrEmpty(newData.Itm_No))
                    {
                        continue;
                    }
                    FlxInv.SetData(iiCnt, 1, frm.ExcelGridView.Rows[iiCnt - 1].Cells[frm.textBox_ItmNo.Text].Value.ToString());
                    FlxInv.Row = iiCnt;
                    try
                    {
                        if (!(string.Concat(FlxInv.GetData(iiCnt, 1)) != ""))
                        {
                            continue;
                        }
                        FlxInv_AfterEdit(null, new RowColEventArgs(iiCnt, 1));
                        try
                        {
                            if (!string.IsNullOrEmpty(frm.textBox_Unt.Text))
                            {
                                try
                                {
                                    oldUnit = frm.ExcelGridView.Rows[iiCnt - 1].Cells[frm.textBox_Unt.Text].Value.ToString();
                                }
                                catch
                                {
                                    oldUnit = "";
                                }
                                if (!string.IsNullOrEmpty(oldUnit))
                                {
                                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                                    {
                                        FlxInv.Col = 3;
                                    }
                                    else
                                    {
                                        FlxInv.Col = 5;
                                    }
                                    string[] UNTS = FlxInv.Cols[FlxInv.Col].ComboList.Split('|');
                                    bool untState = false;
                                    for (int i = 0; i < UNTS.Length; i++)
                                    {
                                        if (UNTS[i] == oldUnit)
                                        {
                                            untState = true;
                                            break;
                                        }
                                    }
                                    if (untState)
                                    {
                                        FlxInv.SetData(iiCnt, FlxInv.Col, oldUnit);
                                        if (!string.IsNullOrEmpty(oldUnit) && FlxInv.GetData(FlxInv.Row, FlxInv.Col).ToString() != oldUnit && FlxInv.GetData(FlxInv.Row, FlxInv.Col).ToString() != "")
                                        {
                                            double ItmDis = 0.0;
                                            double ItmAddTax = 0.0;
                                            ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 31)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                                            if (!switchButton_TaxLines.Value || switchButton_TaxByTotal.Value)
                                            {
                                                ItmAddTax = 0.0;
                                            }
                                            ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 9)))) / 100.0);
                                            int ItemIndex = -1;
                                            if (FlxInv.Col == 3)
                                            {
                                                string[] Items = FlxInv.Cols[FlxInv.Col].ComboList.Split('|');
                                                for (int i = 0; i < Items.Length; i++)
                                                {
                                                    if (Items[i] == FlxInv.GetData(FlxInv.Row, FlxInv.Col).ToString())
                                                    {
                                                        ItemIndex = i + 1;
                                                    }
                                                }
                                                string[] Items2 = FlxInv.Cols[5].ComboList.Split('|');
                                                if (Items2.Length > 1 && ItemIndex > -1)
                                                {
                                                    FlxInv.SetData(FlxInv.Row, 5, Items2[ItemIndex - 1]);
                                                }
                                            }
                                            else if (FlxInv.Col == 5)
                                            {
                                                string[] Items = FlxInv.Cols[FlxInv.Col].ComboList.Split('|');
                                                for (int i = 0; i < Items.Length; i++)
                                                {
                                                    if (Items[i] == FlxInv.GetData(FlxInv.Row, FlxInv.Col).ToString())
                                                    {
                                                        ItemIndex = i + 1;
                                                    }
                                                }
                                                string[] Items2 = FlxInv.Cols[3].ComboList.Split('|');
                                                if (Items2.Length > 1 && ItemIndex > -1)
                                                {
                                                    FlxInv.SetData(FlxInv.Row, 3, Items2[ItemIndex - 1]);
                                                }
                                            }
                                            switch (ItemIndex)
                                            {
                                                case 1:
                                                    FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost.Value * _Items.Pack1.Value / RateValue);
                                                    FlxInv.SetData(FlxInv.Row, 11, _Items.Pack1);
                                                    break;
                                                case 2:
                                                    FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost.Value * _Items.Pack2.Value / RateValue);
                                                    FlxInv.SetData(FlxInv.Row, 11, _Items.Pack2);
                                                    break;
                                                case 3:
                                                    FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost.Value * _Items.Pack3.Value / RateValue);
                                                    FlxInv.SetData(FlxInv.Row, 11, _Items.Pack3);
                                                    break;
                                                case 4:
                                                    FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost.Value * _Items.Pack4.Value / RateValue);
                                                    FlxInv.SetData(FlxInv.Row, 11, _Items.Pack4.Value);
                                                    break;
                                                case 5:
                                                    FlxInv.SetData(FlxInv.Row, 8, _Items.LastCost.Value * _Items.Pack5.Value / RateValue);
                                                    FlxInv.SetData(FlxInv.Row, 11, _Items.Pack5.Value);
                                                    break;
                                            }
                                            Pack = ItemIndex;
                                            BindDataofItemPrice();
                                            FlxInv.SetData(FlxInv.Row, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 11)))));
                                            FlxInv.SetData(FlxInv.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) - ItmDis + ItmAddTax);
                                            if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 38)))) > 0.0)
                                            {
                                                ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 31)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                                                FlxInv.SetData(FlxInv.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 38)))) + ItmAddTax);
                                            }
                                            PriceLoc = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8))));
                                            BindDataOfStkQty(FlxInv.GetData(FlxInv.Row, 1).ToString());
                                            if (CmbCurr.SelectedIndex != -1)
                                            {
                                                List<T_Curency> listSer = db.StockCurrList(int.Parse(CmbCurr.SelectedValue.ToString()));
                                                T_Curency _Curency = listSer[0];
                                                double CurRate = _Curency.Rate.Value;
                                            }
                                            FlxInv.SetData(FlxInv.Row, 26, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) / 1.0);
                                            ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 9)))) / 100.0);
                                            ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 31)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                                            if (!switchButton_TaxLines.Value || switchButton_TaxByTotal.Value)
                                            {
                                                ItmAddTax = 0.0;
                                            }
                                            FlxInv.SetData(FlxInv.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) - ItmDis + ItmAddTax);
                                            if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 38)))) > 0.0)
                                            {
                                                ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 31)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                                                FlxInv.SetData(FlxInv.Row, 38, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 38)))) + ItmAddTax);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch
                        {
                        }
                        try
                        {
                            if (!string.IsNullOrEmpty(frm.textBox_Qty.Text))
                            {
                                if (double.Parse(frm.ExcelGridView.Rows[iiCnt - 1].Cells[frm.textBox_Qty.Text].Value.ToString()) > 0.0)
                                {
                                    FlxInv.SetData(iiCnt, 7, frm.ExcelGridView.Rows[iiCnt - 1].Cells[frm.textBox_Qty.Text].Value.ToString());
                                }
                                else
                                {
                                    FlxInv.SetData(iiCnt, 7, 1);
                                }
                            }
                            else
                            {
                                FlxInv.SetData(iiCnt, 7, 1);
                            }
                        }
                        catch
                        {
                            FlxInv.SetData(iiCnt, 7, 1);
                        }
                        try
                        {
                            if (!string.IsNullOrEmpty(frm.textBox_Price.Text) && double.Parse(frm.ExcelGridView.Rows[iiCnt - 1].Cells[frm.textBox_Price.Text].Value.ToString()) >= 0.0)
                            {
                                FlxInv.SetData(iiCnt, 8, frm.ExcelGridView.Rows[iiCnt - 1].Cells[frm.textBox_Price.Text].Value.ToString());
                            }
                        }
                        catch
                        {
                        }
                        try
                        {
                            if (!string.IsNullOrEmpty(frm.textBox_Discount.Text) && double.Parse(frm.ExcelGridView.Rows[iiCnt - 1].Cells[frm.textBox_Discount.Text].Value.ToString()) > 0.0)
                            {
                                FlxInv.SetData(iiCnt, 9, frm.ExcelGridView.Rows[iiCnt - 1].Cells[frm.textBox_Discount.Text].Value.ToString());
                            }
                        }
                        catch
                        {
                        }
                        try
                        {
                            if (!string.IsNullOrEmpty(frm.textBox_Tax.Text) && double.Parse(frm.ExcelGridView.Rows[iiCnt - 1].Cells[frm.textBox_Tax.Text].Value.ToString()) > 0.0)
                            {
                                FlxInv.SetData(iiCnt, 31, frm.ExcelGridView.Rows[iiCnt - 1].Cells[frm.textBox_Tax.Text].Value.ToString());
                            }
                        }
                        catch
                        {
                        }
                        try
                        {
                            if (!string.IsNullOrEmpty(frm.textBox_DateExpir.Text))
                            {
                                if (!string.IsNullOrEmpty(frm.ExcelGridView.Rows[iiCnt - 1].Cells[frm.textBox_DateExpir.Text].Value.ToString()) && _Items.Lot == 1)
                                {
                                    double d = double.Parse(frm.ExcelGridView.Rows[iiCnt - 1].Cells[frm.textBox_DateExpir.Text].Value.ToString());
                                    string dtToString = DateTime.FromOADate(d).ToString("yyyy/MM/dd");
                                    if (VarGeneral.CheckDate(dtToString))
                                    {
                                        FlxInv.SetData(iiCnt, 27, dtToString);
                                    }
                                    else
                                    {
                                        FlxInv.SetData(iiCnt, 27, "");
                                    }
                                }
                                else
                                {
                                    FlxInv.SetData(iiCnt, 27, "");
                                }
                            }
                            else
                            {
                                FlxInv.SetData(iiCnt, 27, "");
                            }
                        }
                        catch
                        {
                            FlxInv.SetData(iiCnt, 27, "");
                        }
                        try
                        {
                            if (!string.IsNullOrEmpty(frm.textBox_RunNo.Text))
                            {
                                if (!string.IsNullOrEmpty(frm.ExcelGridView.Rows[iiCnt - 1].Cells[frm.textBox_RunNo.Text].Value.ToString()) && _Items.Lot == 1)
                                {
                                    FlxInv.SetData(iiCnt, 35, frm.ExcelGridView.Rows[iiCnt - 1].Cells[frm.textBox_RunNo.Text].Value.ToString());
                                }
                                else
                                {
                                    FlxInv.SetData(iiCnt, 35, "");
                                }
                            }
                            else
                            {
                                FlxInv.SetData(iiCnt, 35, "");
                            }
                        }
                        catch
                        {
                            FlxInv.SetData(iiCnt, 35, "");
                        }
                        try
                        {
                            if (!string.IsNullOrEmpty(frm.textBox_Store.Text) && !string.IsNullOrEmpty(frm.ExcelGridView.Rows[iiCnt - 1].Cells[frm.textBox_Store.Text].Value.ToString()) && listStore.Where((T_Store g) => g.Stor_ID == int.Parse(frm.ExcelGridView.Rows[iiCnt - 1].Cells[frm.textBox_Store.Text].Value.ToString())).ToList().Count > 0)
                            {
                                FlxInv.SetData(iiCnt, 6, frm.ExcelGridView.Rows[iiCnt - 1].Cells[frm.textBox_Store.Text].Value.ToString());
                            }
                        }
                        catch
                        {
                        }
                        FlxInv_AfterEdit(null, new RowColEventArgs(iiCnt, 8));
                    }
                    catch
                    {
                    }
                }
                for (int iiCnt2 = 1; iiCnt2 < FlxInv.Rows.Count; iiCnt2++)
                {
                    if (string.Concat(FlxInv.GetData(iiCnt2, 1)) == "")
                    {
                        FlxInv.RemoveItem(iiCnt2);
                        iiCnt2 = 1;
                    }
                }
                FlxInv.Rows.Count += VarGeneral.Settings_Sys.LineOfInvoices.Value;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Button_Export_Click:", error, enable: true);
                FlxInv.Clear(ClearFlags.Content, 1, 1, FlxInv.Rows.Count - 1, 38);
                FlxInv.Rows.Count = VarGeneral.Settings_Sys.LineOfInvoices.Value;
            }
        }
        private void Button_PrintTableMulti_Click(object sender, EventArgs e)
        {
            if (State != 0 || string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            try
            {
                for (int i = 0; i < pkeys.Count; i++)
                {
                    try
                    {
                        GridRow crow = DGV_Main.PrimaryGrid.Rows[i] as GridRow;
                        if (crow.Checked)
                        {
                            ifMultiPrint = true;
                            data_this = new T_INVHED();
                            data_this = db.StockInvHead(VarGeneral.InvTyp, DGV_Main.PrimaryGrid.GetCell(crow.Index, 0).Value.ToString());
                            buttonItem_Print_Click(sender, e);
                            ifMultiPrint = false;
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
                ifMultiPrint = false;
            }
            textBox_ID_TextChanged(sender, e);
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMOpenQuantities));
            DevComponents.DotNetBar.Rendering.SuperTabPanelColorTable superTabPanelColorTable5 = new DevComponents.DotNetBar.Rendering.SuperTabPanelColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabPanelItemColorTable superTabPanelItemColorTable5 = new DevComponents.DotNetBar.Rendering.SuperTabPanelItemColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable superTabLinearGradientColorTable12 = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabItemColorTable superTabItemColorTable5 = new DevComponents.DotNetBar.Rendering.SuperTabItemColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabColorStates superTabColorStates5 = new DevComponents.DotNetBar.Rendering.SuperTabColorStates();
            DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable superTabItemStateColorTable5 = new DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable superTabLinearGradientColorTable13 = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabPanelColorTable superTabPanelColorTable6 = new DevComponents.DotNetBar.Rendering.SuperTabPanelColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabPanelItemColorTable superTabPanelItemColorTable6 = new DevComponents.DotNetBar.Rendering.SuperTabPanelItemColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable superTabLinearGradientColorTable14 = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabItemColorTable superTabItemColorTable6 = new DevComponents.DotNetBar.Rendering.SuperTabItemColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabColorStates superTabColorStates6 = new DevComponents.DotNetBar.Rendering.SuperTabColorStates();
            DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable superTabItemStateColorTable6 = new DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable superTabLinearGradientColorTable15 = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabPanelColorTable superTabPanelColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabPanelColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabPanelItemColorTable superTabPanelItemColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabPanelItemColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable superTabLinearGradientColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabItemColorTable superTabItemColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabItemColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabColorStates superTabColorStates1 = new DevComponents.DotNetBar.Rendering.SuperTabColorStates();
            DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable superTabItemStateColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable superTabLinearGradientColorTable2 = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabItemColorTable superTabItemColorTable2 = new DevComponents.DotNetBar.Rendering.SuperTabItemColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabColorStates superTabColorStates2 = new DevComponents.DotNetBar.Rendering.SuperTabColorStates();
            DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable superTabItemStateColorTable2 = new DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable superTabLinearGradientColorTable3 = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabColorTable superTabColorTable3 = new DevComponents.DotNetBar.Rendering.SuperTabColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable superTabLinearGradientColorTable6 = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabPanelColorTable superTabPanelColorTable2 = new DevComponents.DotNetBar.Rendering.SuperTabPanelColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabPanelItemColorTable superTabPanelItemColorTable2 = new DevComponents.DotNetBar.Rendering.SuperTabPanelItemColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable superTabLinearGradientColorTable4 = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabPanelColorTable superTabPanelColorTable3 = new DevComponents.DotNetBar.Rendering.SuperTabPanelColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabPanelItemColorTable superTabPanelItemColorTable3 = new DevComponents.DotNetBar.Rendering.SuperTabPanelItemColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable superTabLinearGradientColorTable5 = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabItemColorTable superTabItemColorTable3 = new DevComponents.DotNetBar.Rendering.SuperTabItemColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabColorStates superTabColorStates3 = new DevComponents.DotNetBar.Rendering.SuperTabColorStates();
            DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable superTabItemStateColorTable3 = new DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable superTabLinearGradientColorTable7 = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabColorTable superTabColorTable4 = new DevComponents.DotNetBar.Rendering.SuperTabColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable superTabLinearGradientColorTable8 = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabColorTable superTabColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable superTabLinearGradientColorTable9 = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable();
            DevComponents.DotNetBar.SuperGrid.Style.Background background9 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background10 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background11 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor5 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor6 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle5 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle6 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.Background background12 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.FlxDat = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.FlxInv = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.textBox_ID = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.switchButton_Lock = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.txtTime = new System.Windows.Forms.MaskedTextBox();
            this.txtHDate = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.Label26 = new System.Windows.Forms.Label();
            this.txtDueAmount = new DevComponents.Editors.DoubleInput();
            this.txtTotalAm = new DevComponents.Editors.DoubleInput();
            this.txtDiscountVal = new DevComponents.Editors.DoubleInput();
            this.txtDiscountP = new DevComponents.Editors.DoubleInput();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiscountValLoc = new DevComponents.Editors.DoubleInput();
            this.txtTotTax = new DevComponents.Editors.DoubleInput();
            this.txtTotalAmLoc = new DevComponents.Editors.DoubleInput();
            this.txtTotTaxLoc = new DevComponents.Editors.DoubleInput();
            this.txtDueAmountLoc = new DevComponents.Editors.DoubleInput();
            this.label9 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.superTabControl_Info = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel3 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.FlxStkQty = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtLPrice = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtLCost = new System.Windows.Forms.TextBox();
            this.txtVCost = new System.Windows.Forms.TextBox();
            this.superTabItem_items = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.txtCredit1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtDebit1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelC1 = new System.Windows.Forms.Label();
            this.labelD1 = new System.Windows.Forms.Label();
            this.superTabItem_Pay = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.label_LockeName = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.txtTotalQ = new DevComponents.Editors.DoubleInput();
            this.label30 = new System.Windows.Forms.Label();
            this.textBox_Usr = new System.Windows.Forms.TextBox();
            this.superTabItem_Detiles = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel4 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.txtRemark = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.superTabItem_Note = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel5 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.superTabControl_CostSts = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel6 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.switchButton_Tax = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.txtCredit5 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtDebit5 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.checkBox_CostGaidTax = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label36 = new System.Windows.Forms.Label();
            this.superTabItem_Tax = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel7 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.switchButton_Dis = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.label31 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.txtCredit6 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtDebit6 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label39 = new System.Windows.Forms.Label();
            this.txtTotDis = new DevComponents.Editors.DoubleInput();
            this.txtTotDisLoc = new DevComponents.Editors.DoubleInput();
            this.checkBox_GaidDis = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.superTabItem_Dis = new DevComponents.DotNetBar.SuperTabItem();
            this.switchButton_TaxLines = new DevComponents.DotNetBar.SwitchButtonItem();
            this.switchButton_TaxByTotal = new DevComponents.DotNetBar.SwitchButtonItem();
            this.switchButton_TaxByNet = new DevComponents.DotNetBar.SwitchButtonItem();
            this.textBoxItem_TaxByNetValue = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem_TaxByNetPer = new DevComponents.DotNetBar.LabelItem();
            this.superTabItem_Gaids = new DevComponents.DotNetBar.SuperTabItem();
            this.doubleInput_Rate = new DevComponents.Editors.DoubleInput();
            this.CmbCostC = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.CmbCurr = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.CmbLegate = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtRef = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.CmbInvPrice = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtInvCost = new DevComponents.Editors.DoubleInput();
            this.txtCustNet = new DevComponents.Editors.DoubleInput();
            this.txtCustRep = new DevComponents.Editors.DoubleInput();
            this.textBox2 = new DevComponents.Editors.DoubleInput();
            this.textBox1 = new DevComponents.Editors.DoubleInput();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBox_Chash = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.pictureBox_Cash = new System.Windows.Forms.PictureBox();
            this.txtGDate = new System.Windows.Forms.MaskedTextBox();
            this.groupPanel_Items = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.button_SomeItems = new DevComponents.DotNetBar.ButtonX();
            this.button_AllItems = new DevComponents.DotNetBar.ButtonX();
            this.c1BarCode1 = new C1.Win.C1BarCode.C1BarCode();
            this.ribbonBar_Tasks = new DevComponents.DotNetBar.RibbonBar();
            this.superTabControl_Main1 = new DevComponents.DotNetBar.SuperTabControl();
            this.Button_BarcodPrint = new DevComponents.DotNetBar.ButtonItem();
            this.button_Repetition = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Close = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem_Print = new DevComponents.DotNetBar.ButtonItem();
            this.printingsettings = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Search = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Delete = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Save = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Add = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Export = new DevComponents.DotNetBar.ButtonItem();
            this.superTabControl_Main2 = new DevComponents.DotNetBar.SuperTabControl();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.Button_First = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Prev = new DevComponents.DotNetBar.ButtonItem();
            this.TextBox_Index = new DevComponents.DotNetBar.TextBoxItem();
            this.Label_Count = new DevComponents.DotNetBar.LabelItem();
            this.lable_Records = new DevComponents.DotNetBar.LabelItem();
            this.Button_Next = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Last = new DevComponents.DotNetBar.ButtonItem();
            this.ToolStripMenuItem_Rep = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.timerInfoBallon = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_Det = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.prnt_doc = new System.Drawing.Printing.PrintDocument();
            this.prnt_prev = new System.Windows.Forms.PrintPreviewDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.DGV_Main = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.ribbonBar_DGV = new DevComponents.DotNetBar.RibbonBar();
            this.superTabControl_DGV = new DevComponents.DotNetBar.SuperTabControl();
            this.textBox_search = new DevComponents.DotNetBar.TextBoxItem();
            this.Button_ExportTable2 = new DevComponents.DotNetBar.ButtonItem();
            this.Button_PrintTable = new DevComponents.DotNetBar.ButtonItem();
            this.Button_PrintTableMulti = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem3 = new DevComponents.DotNetBar.LabelItem();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.barTaskList = new DevComponents.DotNetBar.Bar();
            this.panelDockContainer1 = new DevComponents.DotNetBar.PanelDockContainer();
            this.Panel_Navigate = new DevComponents.DotNetBar.DockContainerItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.prnt_doc2 = new System.Drawing.Printing.PrintDocument();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.PanelSpecialContainer.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlxDat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlxInv)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDueAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalAm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountValLoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalAmLoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotTaxLoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDueAmountLoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Info)).BeginInit();
            this.superTabControl_Info.SuspendLayout();
            this.superTabControlPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlxStkQty)).BeginInit();
            this.superTabControlPanel1.SuspendLayout();
            this.superTabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalQ)).BeginInit();
            this.superTabControlPanel4.SuspendLayout();
            this.superTabControlPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_CostSts)).BeginInit();
            this.superTabControl_CostSts.SuspendLayout();
            this.superTabControlPanel6.SuspendLayout();
            this.superTabControlPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotDis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotDisLoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_Rate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustNet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustRep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Cash)).BeginInit();
            this.groupPanel_Items.SuspendLayout();
            this.ribbonBar_Tasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main2)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelEx3.SuspendLayout();
            this.ribbonBar_DGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barTaskList)).BeginInit();
            this.barTaskList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelSpecialContainer
            // 
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar1);
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar_Tasks);
            this.PanelSpecialContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSpecialContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelSpecialContainer.Name = "PanelSpecialContainer";
            this.PanelSpecialContainer.Size = new System.Drawing.Size(1258, 480);
            this.PanelSpecialContainer.TabIndex = 1220;
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.Gainsboro;
            this.ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.Color.Gainsboro;
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.FlxDat);
            this.ribbonBar1.Controls.Add(this.FlxInv);
            this.ribbonBar1.Controls.Add(this.textBox_ID);
            this.ribbonBar1.Controls.Add(this.switchButton_Lock);
            this.ribbonBar1.Controls.Add(this.txtTime);
            this.ribbonBar1.Controls.Add(this.txtHDate);
            this.ribbonBar1.Controls.Add(this.groupBox1);
            this.ribbonBar1.Controls.Add(this.superTabControl_Info);
            this.ribbonBar1.Controls.Add(this.doubleInput_Rate);
            this.ribbonBar1.Controls.Add(this.CmbCostC);
            this.ribbonBar1.Controls.Add(this.CmbCurr);
            this.ribbonBar1.Controls.Add(this.CmbLegate);
            this.ribbonBar1.Controls.Add(this.txtRef);
            this.ribbonBar1.Controls.Add(this.label5);
            this.ribbonBar1.Controls.Add(this.label15);
            this.ribbonBar1.Controls.Add(this.label19);
            this.ribbonBar1.Controls.Add(this.label18);
            this.ribbonBar1.Controls.Add(this.label7);
            this.ribbonBar1.Controls.Add(this.Label2);
            this.ribbonBar1.Controls.Add(this.Label1);
            this.ribbonBar1.Controls.Add(this.CmbInvPrice);
            this.ribbonBar1.Controls.Add(this.txtInvCost);
            this.ribbonBar1.Controls.Add(this.txtCustNet);
            this.ribbonBar1.Controls.Add(this.txtCustRep);
            this.ribbonBar1.Controls.Add(this.textBox2);
            this.ribbonBar1.Controls.Add(this.textBox1);
            this.ribbonBar1.Controls.Add(this.groupBox5);
            this.ribbonBar1.Controls.Add(this.pictureBox_Cash);
            this.ribbonBar1.Controls.Add(this.txtGDate);
            this.ribbonBar1.Controls.Add(this.groupPanel_Items);
            this.ribbonBar1.Controls.Add(this.c1BarCode1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(1258, 429);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 867;
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
            // FlxDat
            // 
            this.FlxDat.AllowEditing = false;
            this.FlxDat.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
            this.FlxDat.ColumnInfo = resources.GetString("FlxDat.ColumnInfo");
            this.FlxDat.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FlxDat.Location = new System.Drawing.Point(424, 150);
            this.FlxDat.Name = "FlxDat";
            this.FlxDat.Rows.DefaultSize = 19;
            this.FlxDat.Size = new System.Drawing.Size(229, 96);
            this.FlxDat.StyleInfo = resources.GetString("FlxDat.StyleInfo");
            this.FlxDat.TabIndex = 1143;
            this.FlxDat.Visible = false;
            this.FlxDat.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Black;
            // 
            // FlxInv
            // 
            this.FlxInv.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.FlxInv.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.FlxInv.ColumnInfo = resources.GetString("FlxInv.ColumnInfo");
            this.FlxInv.ExtendLastCol = true;
            this.FlxInv.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FlxInv.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.FlxInv.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.FlxInv.Location = new System.Drawing.Point(68, 108);
            this.FlxInv.Name = "FlxInv";
            this.FlxInv.Rows.DefaultSize = 19;
            this.FlxInv.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
            this.FlxInv.Size = new System.Drawing.Size(1177, 167);
            this.FlxInv.StyleInfo = resources.GetString("FlxInv.StyleInfo");
            this.FlxInv.TabIndex = 8;
            this.FlxInv.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System;
            this.FlxInv.StartEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.FlxInv_StartEdit);
            this.FlxInv.LeaveEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.FlxInv_LeaveEdit);
            this.FlxInv.SizeChanged += new System.EventHandler(this.FlxInv_SizeChanged);
            // 
            // textBox_ID
            // 
            // 
            // 
            // 
            this.textBox_ID.Border.Class = "TextBoxBorder";
            this.textBox_ID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_ID.ButtonCustom.Visible = true;
            this.textBox_ID.Location = new System.Drawing.Point(823, 10);
            this.textBox_ID.Name = "textBox_ID";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_ID, false);
            this.textBox_ID.Size = new System.Drawing.Size(354, 20);
            this.textBox_ID.TabIndex = 1588;
            this.textBox_ID.ButtonCustomClick += new System.EventHandler(this.textBox_ID_ButtonCustomClick);
            this.textBox_ID.TextChanged += new System.EventHandler(this.textBox_ID_TextChanged_1);
            // 
            // switchButton_Lock
            // 
            // 
            // 
            // 
            this.switchButton_Lock.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_Lock.Font = new System.Drawing.Font("Tahoma", 7F);
            this.switchButton_Lock.Location = new System.Drawing.Point(659, 10);
            this.switchButton_Lock.Name = "switchButton_Lock";
            this.switchButton_Lock.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.switchButton_Lock.OffText = "لم يتم الموافقة";
            this.switchButton_Lock.OffTextColor = System.Drawing.Color.White;
            this.switchButton_Lock.OnText = "تمت الموافقة";
            this.switchButton_Lock.Size = new System.Drawing.Size(158, 40);
            this.switchButton_Lock.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_Lock.TabIndex = 1587;
            this.switchButton_Lock.ValueChanged += new System.EventHandler(this.switchButton_Lock_ValueChanged);
            this.switchButton_Lock.Click += new System.EventHandler(this.switchButton_Lock_Click);
            // 
            // txtTime
            // 
            this.txtTime.BackColor = System.Drawing.Color.White;
            this.txtTime.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtTime.Location = new System.Drawing.Point(823, 34);
            this.txtTime.Mask = "##:##";
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(116, 21);
            this.txtTime.TabIndex = 1146;
            this.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHDate
            // 
            this.txtHDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtHDate.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtHDate.Location = new System.Drawing.Point(945, 34);
            this.txtHDate.Mask = "0000/00/00";
            this.txtHDate.Name = "txtHDate";
            this.txtHDate.Size = new System.Drawing.Size(132, 21);
            this.txtHDate.TabIndex = 1145;
            this.txtHDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Controls.Add(this.Label26);
            this.groupBox1.Controls.Add(this.txtDueAmount);
            this.groupBox1.Controls.Add(this.txtTotalAm);
            this.groupBox1.Controls.Add(this.txtDiscountVal);
            this.groupBox1.Controls.Add(this.txtDiscountP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDiscountValLoc);
            this.groupBox1.Controls.Add(this.txtTotTax);
            this.groupBox1.Controls.Add(this.txtTotalAmLoc);
            this.groupBox1.Controls.Add(this.txtTotTaxLoc);
            this.groupBox1.Controls.Add(this.txtDueAmountLoc);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Location = new System.Drawing.Point(4, 274);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 135);
            this.groupBox1.TabIndex = 1142;
            this.groupBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(105, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 21);
            this.label8.TabIndex = 1114;
            this.label8.Text = "نسبة الخصم";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label33
            // 
            this.label33.BackColor = System.Drawing.Color.Transparent;
            this.label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label33.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label33.ForeColor = System.Drawing.Color.Navy;
            this.label33.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label33.Location = new System.Drawing.Point(204, 87);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(80, 21);
            this.label33.TabIndex = 1151;
            this.label33.Text = "قيمة الضريبه :";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label26
            // 
            this.Label26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Label26.ForeColor = System.Drawing.Color.White;
            this.Label26.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label26.Location = new System.Drawing.Point(204, 16);
            this.Label26.Name = "Label26";
            this.Label26.Size = new System.Drawing.Size(85, 21);
            this.Label26.TabIndex = 1113;
            this.Label26.Text = "قيمة الخصم";
            this.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDueAmount
            // 
            this.txtDueAmount.AllowEmptyState = false;
            this.txtDueAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtDueAmount.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.txtDueAmount.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDueAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDueAmount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtDueAmount.DisplayFormat = "0.00";
            this.txtDueAmount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDueAmount.Increment = 0D;
            this.txtDueAmount.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtDueAmount.IsInputReadOnly = true;
            this.txtDueAmount.Location = new System.Drawing.Point(6, 108);
            this.txtDueAmount.Name = "txtDueAmount";
            this.txtDueAmount.Size = new System.Drawing.Size(98, 21);
            this.txtDueAmount.TabIndex = 1081;
            // 
            // txtTotalAm
            // 
            this.txtTotalAm.AllowEmptyState = false;
            this.txtTotalAm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTotalAm.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.txtTotalAm.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTotalAm.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotalAm.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTotalAm.DisplayFormat = "0.00";
            this.txtTotalAm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalAm.Increment = 0D;
            this.txtTotalAm.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTotalAm.IsInputReadOnly = true;
            this.txtTotalAm.Location = new System.Drawing.Point(6, 62);
            this.txtTotalAm.Name = "txtTotalAm";
            this.txtTotalAm.Size = new System.Drawing.Size(98, 21);
            this.txtTotalAm.TabIndex = 1080;
            // 
            // txtDiscountVal
            // 
            this.txtDiscountVal.AllowEmptyState = false;
            this.txtDiscountVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtDiscountVal.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDiscountVal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDiscountVal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtDiscountVal.DisplayFormat = "0.00";
            this.txtDiscountVal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDiscountVal.Increment = 0D;
            this.txtDiscountVal.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtDiscountVal.Location = new System.Drawing.Point(204, 39);
            this.txtDiscountVal.Name = "txtDiscountVal";
            this.txtDiscountVal.Size = new System.Drawing.Size(85, 21);
            this.txtDiscountVal.TabIndex = 1079;
            // 
            // txtDiscountP
            // 
            this.txtDiscountP.AllowEmptyState = false;
            this.txtDiscountP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtDiscountP.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDiscountP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDiscountP.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtDiscountP.DisplayFormat = "0.00";
            this.txtDiscountP.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDiscountP.Increment = 0D;
            this.txtDiscountP.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtDiscountP.Location = new System.Drawing.Point(105, 39);
            this.txtDiscountP.Name = "txtDiscountP";
            this.txtDiscountP.Size = new System.Drawing.Size(98, 21);
            this.txtDiscountP.TabIndex = 1078;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 21);
            this.label3.TabIndex = 1091;
            this.label3.Text = "بالريــال";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDiscountValLoc
            // 
            this.txtDiscountValLoc.AllowEmptyState = false;
            this.txtDiscountValLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtDiscountValLoc.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.txtDiscountValLoc.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDiscountValLoc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDiscountValLoc.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtDiscountValLoc.DisplayFormat = "0.00";
            this.txtDiscountValLoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDiscountValLoc.Increment = 0D;
            this.txtDiscountValLoc.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtDiscountValLoc.IsInputReadOnly = true;
            this.txtDiscountValLoc.Location = new System.Drawing.Point(6, 39);
            this.txtDiscountValLoc.Name = "txtDiscountValLoc";
            this.txtDiscountValLoc.Size = new System.Drawing.Size(98, 21);
            this.txtDiscountValLoc.TabIndex = 1090;
            // 
            // txtTotTax
            // 
            this.txtTotTax.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtTotTax.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTotTax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotTax.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTotTax.DisplayFormat = "0.00";
            this.txtTotTax.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotTax.Increment = 0D;
            this.txtTotTax.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTotTax.IsInputReadOnly = true;
            this.txtTotTax.Location = new System.Drawing.Point(107, 85);
            this.txtTotTax.MinValue = 0D;
            this.txtTotTax.Name = "txtTotTax";
            this.txtTotTax.Size = new System.Drawing.Size(96, 21);
            this.txtTotTax.TabIndex = 1141;
            // 
            // txtTotalAmLoc
            // 
            this.txtTotalAmLoc.AllowEmptyState = false;
            this.txtTotalAmLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTotalAmLoc.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTotalAmLoc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotalAmLoc.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTotalAmLoc.DisplayFormat = "0.00";
            this.txtTotalAmLoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalAmLoc.Increment = 0D;
            this.txtTotalAmLoc.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTotalAmLoc.IsInputReadOnly = true;
            this.txtTotalAmLoc.Location = new System.Drawing.Point(105, 62);
            this.txtTotalAmLoc.Name = "txtTotalAmLoc";
            this.txtTotalAmLoc.Size = new System.Drawing.Size(98, 21);
            this.txtTotalAmLoc.TabIndex = 1088;
            // 
            // txtTotTaxLoc
            // 
            this.txtTotTaxLoc.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtTotTaxLoc.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.txtTotTaxLoc.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTotTaxLoc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotTaxLoc.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTotTaxLoc.DisplayFormat = "0.00";
            this.txtTotTaxLoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotTaxLoc.Increment = 0D;
            this.txtTotTaxLoc.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTotTaxLoc.IsInputReadOnly = true;
            this.txtTotTaxLoc.Location = new System.Drawing.Point(6, 85);
            this.txtTotTaxLoc.MinValue = 0D;
            this.txtTotTaxLoc.Name = "txtTotTaxLoc";
            this.txtTotTaxLoc.Size = new System.Drawing.Size(95, 21);
            this.txtTotTaxLoc.TabIndex = 1142;
            // 
            // txtDueAmountLoc
            // 
            this.txtDueAmountLoc.AllowEmptyState = false;
            this.txtDueAmountLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtDueAmountLoc.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.txtDueAmountLoc.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDueAmountLoc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDueAmountLoc.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtDueAmountLoc.DisplayFormat = "0.00";
            this.txtDueAmountLoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDueAmountLoc.Increment = 0D;
            this.txtDueAmountLoc.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtDueAmountLoc.IsInputReadOnly = true;
            this.txtDueAmountLoc.Location = new System.Drawing.Point(105, 108);
            this.txtDueAmountLoc.Name = "txtDueAmountLoc";
            this.txtDueAmountLoc.Size = new System.Drawing.Size(98, 21);
            this.txtDueAmountLoc.TabIndex = 1089;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label9.ForeColor = System.Drawing.Color.Navy;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(204, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 14);
            this.label9.TabIndex = 1092;
            this.label9.Text = "صافي الفاتورة :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label17.ForeColor = System.Drawing.Color.Navy;
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(204, 66);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(85, 14);
            this.label17.TabIndex = 1082;
            this.label17.Text = "قيمة الفاتـــورة :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // superTabControl_Info
            // 
            this.superTabControl_Info.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl_Info.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl_Info.ControlBox.MenuBox.Name = "";
            this.superTabControl_Info.ControlBox.Name = "";
            this.superTabControl_Info.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl_Info.ControlBox.MenuBox,
            this.superTabControl_Info.ControlBox.CloseBox});
            this.superTabControl_Info.Controls.Add(this.superTabControlPanel3);
            this.superTabControl_Info.Controls.Add(this.superTabControlPanel1);
            this.superTabControl_Info.Controls.Add(this.superTabControlPanel2);
            this.superTabControl_Info.Controls.Add(this.superTabControlPanel4);
            this.superTabControl_Info.Controls.Add(this.superTabControlPanel5);
            this.superTabControl_Info.ForeColor = System.Drawing.Color.Black;
            this.superTabControl_Info.Location = new System.Drawing.Point(303, 281);
            this.superTabControl_Info.Name = "superTabControl_Info";
            this.superTabControl_Info.ReorderTabsEnabled = true;
            this.superTabControl_Info.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.superTabControl_Info.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_Info.SelectedTabIndex = 0;
            this.superTabControl_Info.Size = new System.Drawing.Size(952, 128);
            this.superTabControl_Info.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Bottom;
            this.superTabControl_Info.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_Info.TabHorizontalSpacing = 11;
            this.superTabControl_Info.TabIndex = 1141;
            this.superTabControl_Info.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.SingleLineFit;
            this.superTabControl_Info.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem_items,
            this.superTabItem_Pay,
            this.superTabItem_Detiles,
            this.superTabItem_Note,
            this.superTabItem_Gaids});
            this.superTabControl_Info.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.VisualStudio2008Document;
            this.superTabControl_Info.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            // 
            // superTabControlPanel3
            // 
            this.superTabControlPanel3.Controls.Add(this.FlxStkQty);
            this.superTabControlPanel3.Controls.Add(this.txtUnit);
            this.superTabControlPanel3.Controls.Add(this.txtLPrice);
            this.superTabControlPanel3.Controls.Add(this.label25);
            this.superTabControlPanel3.Controls.Add(this.label22);
            this.superTabControlPanel3.Controls.Add(this.label23);
            this.superTabControlPanel3.Controls.Add(this.label24);
            this.superTabControlPanel3.Controls.Add(this.txtLCost);
            this.superTabControlPanel3.Controls.Add(this.txtVCost);
            this.superTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel3.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel3.Name = "superTabControlPanel3";
            superTabLinearGradientColorTable12.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.Gray,
        System.Drawing.Color.White};
            superTabPanelItemColorTable5.Background = superTabLinearGradientColorTable12;
            superTabPanelColorTable5.Default = superTabPanelItemColorTable5;
            this.superTabControlPanel3.PanelColor = superTabPanelColorTable5;
            this.superTabControlPanel3.Size = new System.Drawing.Size(952, 103);
            this.superTabControlPanel3.TabIndex = 0;
            this.superTabControlPanel3.TabItem = this.superTabItem_items;
            // 
            // FlxStkQty
            // 
            this.FlxStkQty.AllowEditing = false;
            this.FlxStkQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FlxStkQty.BackColor = System.Drawing.Color.Transparent;
            this.FlxStkQty.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            this.FlxStkQty.ColumnInfo = resources.GetString("FlxStkQty.ColumnInfo");
            this.FlxStkQty.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FlxStkQty.Location = new System.Drawing.Point(716, 3);
            this.FlxStkQty.Name = "FlxStkQty";
            this.FlxStkQty.Rows.DefaultSize = 19;
            this.FlxStkQty.Size = new System.Drawing.Size(233, 100);
            this.FlxStkQty.StyleInfo = resources.GetString("FlxStkQty.StyleInfo");
            this.FlxStkQty.TabIndex = 1079;
            this.FlxStkQty.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Black;
            // 
            // txtUnit
            // 
            this.txtUnit.BackColor = System.Drawing.Color.AliceBlue;
            this.txtUnit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUnit.Location = new System.Drawing.Point(417, 66);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtUnit, false);
            this.txtUnit.Size = new System.Drawing.Size(68, 13);
            this.txtUnit.TabIndex = 60;
            this.txtUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLPrice
            // 
            this.txtLPrice.BackColor = System.Drawing.Color.AliceBlue;
            this.txtLPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLPrice.Location = new System.Drawing.Point(417, 46);
            this.txtLPrice.Name = "txtLPrice";
            this.txtLPrice.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtLPrice, false);
            this.txtLPrice.Size = new System.Drawing.Size(68, 13);
            this.txtLPrice.TabIndex = 4;
            this.txtLPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Font = new System.Drawing.Font("Tahoma", 7F);
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label25.Location = new System.Drawing.Point(491, 66);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(31, 12);
            this.label25.TabIndex = 1078;
            this.label25.Text = "الوحدة";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Tahoma", 7F);
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(491, 46);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(103, 12);
            this.label22.TabIndex = 1077;
            this.label22.Text = "سعر اخر بضاعة اول مدة";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Tahoma", 7F);
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label23.Location = new System.Drawing.Point(491, 26);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(44, 12);
            this.label23.TabIndex = 1076;
            this.label23.Text = "أخر تكلفة";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Tahoma", 7F);
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label24.Location = new System.Drawing.Point(491, 6);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(67, 12);
            this.label24.TabIndex = 1075;
            this.label24.Text = "متوسط التكلفة";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLCost
            // 
            this.txtLCost.BackColor = System.Drawing.Color.AliceBlue;
            this.txtLCost.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLCost.Location = new System.Drawing.Point(417, 26);
            this.txtLCost.Name = "txtLCost";
            this.txtLCost.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtLCost, false);
            this.txtLCost.Size = new System.Drawing.Size(68, 13);
            this.txtLCost.TabIndex = 59;
            this.txtLCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtVCost
            // 
            this.txtVCost.BackColor = System.Drawing.Color.AliceBlue;
            this.txtVCost.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtVCost.Location = new System.Drawing.Point(417, 6);
            this.txtVCost.Name = "txtVCost";
            this.txtVCost.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtVCost, false);
            this.txtVCost.Size = new System.Drawing.Size(68, 13);
            this.txtVCost.TabIndex = 57;
            this.txtVCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // superTabItem_items
            // 
            this.superTabItem_items.AttachedControl = this.superTabControlPanel3;
            this.superTabItem_items.GlobalItem = false;
            this.superTabItem_items.Name = "superTabItem_items";
            superTabLinearGradientColorTable13.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.Empty};
            superTabItemStateColorTable5.Background = superTabLinearGradientColorTable13;
            superTabColorStates5.Normal = superTabItemStateColorTable5;
            superTabItemColorTable5.Default = superTabColorStates5;
            this.superTabItem_items.TabColor = superTabItemColorTable5;
            this.superTabItem_items.Text = "م.الصنف";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.txtCredit1);
            this.superTabControlPanel1.Controls.Add(this.txtDebit1);
            this.superTabControlPanel1.Controls.Add(this.labelC1);
            this.superTabControlPanel1.Controls.Add(this.labelD1);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            superTabLinearGradientColorTable14.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.Gray,
        System.Drawing.Color.White};
            superTabPanelItemColorTable6.Background = superTabLinearGradientColorTable14;
            superTabPanelColorTable6.Default = superTabPanelItemColorTable6;
            this.superTabControlPanel1.PanelColor = superTabPanelColorTable6;
            this.superTabControlPanel1.Size = new System.Drawing.Size(952, 103);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.superTabItem_Pay;
            // 
            // txtCredit1
            // 
            this.txtCredit1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtCredit1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCredit1.ButtonCustom.Visible = true;
            this.txtCredit1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtCredit1.ForeColor = System.Drawing.Color.Black;
            this.txtCredit1.Location = new System.Drawing.Point(202, 49);
            this.txtCredit1.Name = "txtCredit1";
            this.txtCredit1.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtCredit1, false);
            this.txtCredit1.Size = new System.Drawing.Size(672, 16);
            this.txtCredit1.TabIndex = 1115;
            this.txtCredit1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDebit1
            // 
            this.txtDebit1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDebit1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDebit1.ButtonCustom.Visible = true;
            this.txtDebit1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtDebit1.ForeColor = System.Drawing.Color.Black;
            this.txtDebit1.Location = new System.Drawing.Point(202, 20);
            this.txtDebit1.Name = "txtDebit1";
            this.txtDebit1.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtDebit1, false);
            this.txtDebit1.Size = new System.Drawing.Size(672, 16);
            this.txtDebit1.TabIndex = 1112;
            this.txtDebit1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelC1
            // 
            this.labelC1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelC1.AutoSize = true;
            this.labelC1.BackColor = System.Drawing.Color.Transparent;
            this.labelC1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelC1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelC1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelC1.Location = new System.Drawing.Point(879, 49);
            this.labelC1.Name = "labelC1";
            this.labelC1.Size = new System.Drawing.Size(53, 13);
            this.labelC1.TabIndex = 1099;
            this.labelC1.Text = "الدائـــن :";
            // 
            // labelD1
            // 
            this.labelD1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelD1.AutoSize = true;
            this.labelD1.BackColor = System.Drawing.Color.Transparent;
            this.labelD1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelD1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelD1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelD1.Location = new System.Drawing.Point(880, 20);
            this.labelD1.Name = "labelD1";
            this.labelD1.Size = new System.Drawing.Size(56, 13);
            this.labelD1.TabIndex = 1096;
            this.labelD1.Text = "المـــدين :";
            // 
            // superTabItem_Pay
            // 
            this.superTabItem_Pay.AttachedControl = this.superTabControlPanel1;
            this.superTabItem_Pay.GlobalItem = false;
            this.superTabItem_Pay.Name = "superTabItem_Pay";
            superTabLinearGradientColorTable15.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.Empty};
            superTabItemStateColorTable6.Background = superTabLinearGradientColorTable15;
            superTabColorStates6.Normal = superTabItemStateColorTable6;
            superTabItemColorTable6.Default = superTabColorStates6;
            this.superTabItem_Pay.TabColor = superTabItemColorTable6;
            this.superTabItem_Pay.Text = "السند المحاسبي";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Controls.Add(this.label_LockeName);
            this.superTabControlPanel2.Controls.Add(this.label27);
            this.superTabControlPanel2.Controls.Add(this.txtTotalQ);
            this.superTabControlPanel2.Controls.Add(this.label30);
            this.superTabControlPanel2.Controls.Add(this.textBox_Usr);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            superTabLinearGradientColorTable1.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.Gray,
        System.Drawing.Color.White};
            superTabPanelItemColorTable1.Background = superTabLinearGradientColorTable1;
            superTabPanelColorTable1.Default = superTabPanelItemColorTable1;
            this.superTabControlPanel2.PanelColor = superTabPanelColorTable1;
            this.superTabControlPanel2.Size = new System.Drawing.Size(952, 103);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.superTabItem_Detiles;
            // 
            // label_LockeName
            // 
            this.label_LockeName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label_LockeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_LockeName.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_LockeName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label_LockeName.ForeColor = System.Drawing.Color.Maroon;
            this.label_LockeName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_LockeName.Location = new System.Drawing.Point(0, 0);
            this.label_LockeName.Name = "label_LockeName";
            this.label_LockeName.Size = new System.Drawing.Size(132, 103);
            this.label_LockeName.TabIndex = 1119;
            this.label_LockeName.Text = "--";
            this.label_LockeName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label27.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label27.Location = new System.Drawing.Point(858, 55);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(67, 14);
            this.label27.TabIndex = 1056;
            this.label27.Text = "المستخدم :";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotalQ
            // 
            this.txtTotalQ.AllowEmptyState = false;
            this.txtTotalQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTotalQ.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTotalQ.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotalQ.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTotalQ.DisplayFormat = "0.00";
            this.txtTotalQ.Font = new System.Drawing.Font("Tahoma", 6.75F);
            this.txtTotalQ.Increment = 0D;
            this.txtTotalQ.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTotalQ.IsInputReadOnly = true;
            this.txtTotalQ.Location = new System.Drawing.Point(803, 21);
            this.txtTotalQ.Name = "txtTotalQ";
            this.txtTotalQ.Size = new System.Drawing.Size(53, 18);
            this.txtTotalQ.TabIndex = 1051;
            // 
            // label30
            // 
            this.label30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label30.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label30.Location = new System.Drawing.Point(858, 21);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(86, 14);
            this.label30.TabIndex = 1050;
            this.label30.Text = "إجمالي الكمية :";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_Usr
            // 
            this.textBox_Usr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Usr.BackColor = System.Drawing.Color.SteelBlue;
            this.textBox_Usr.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_Usr.ForeColor = System.Drawing.Color.White;
            this.textBox_Usr.Location = new System.Drawing.Point(582, 52);
            this.textBox_Usr.MaxLength = 30;
            this.textBox_Usr.Name = "textBox_Usr";
            this.textBox_Usr.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Usr, false);
            this.textBox_Usr.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_Usr.Size = new System.Drawing.Size(274, 20);
            this.textBox_Usr.TabIndex = 1058;
            this.textBox_Usr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // superTabItem_Detiles
            // 
            this.superTabItem_Detiles.AttachedControl = this.superTabControlPanel2;
            this.superTabItem_Detiles.GlobalItem = false;
            this.superTabItem_Detiles.Name = "superTabItem_Detiles";
            superTabLinearGradientColorTable2.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.Empty};
            superTabItemStateColorTable1.Background = superTabLinearGradientColorTable2;
            superTabColorStates1.Normal = superTabItemStateColorTable1;
            superTabItemColorTable1.Default = superTabColorStates1;
            this.superTabItem_Detiles.TabColor = superTabItemColorTable1;
            this.superTabItem_Detiles.Text = "تفاصيل";
            // 
            // superTabControlPanel4
            // 
            this.superTabControlPanel4.Controls.Add(this.txtRemark);
            this.superTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel4.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel4.Name = "superTabControlPanel4";
            this.superTabControlPanel4.Size = new System.Drawing.Size(952, 103);
            this.superTabControlPanel4.TabIndex = 2;
            this.superTabControlPanel4.TabItem = this.superTabItem_Note;
            // 
            // txtRemark
            // 
            this.txtRemark.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtRemark.Border.Class = "TextBoxBorder";
            this.txtRemark.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRemark.ButtonCustom.Visible = true;
            this.txtRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemark.ForeColor = System.Drawing.Color.Black;
            this.txtRemark.Location = new System.Drawing.Point(0, 0);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.netResize1.SetResizeTextBoxMultiline(this.txtRemark, false);
            this.txtRemark.Size = new System.Drawing.Size(952, 103);
            this.txtRemark.TabIndex = 480;
            this.txtRemark.WatermarkText = "ملاحظات الفاتورة";
            // 
            // superTabItem_Note
            // 
            this.superTabItem_Note.AttachedControl = this.superTabControlPanel4;
            this.superTabItem_Note.GlobalItem = false;
            this.superTabItem_Note.Name = "superTabItem_Note";
            superTabLinearGradientColorTable3.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.Empty};
            superTabItemStateColorTable2.Background = superTabLinearGradientColorTable3;
            superTabColorStates2.Normal = superTabItemStateColorTable2;
            superTabItemColorTable2.Default = superTabColorStates2;
            this.superTabItem_Note.TabColor = superTabItemColorTable2;
            this.superTabItem_Note.Text = "ملاحظات";
            // 
            // superTabControlPanel5
            // 
            this.superTabControlPanel5.Controls.Add(this.superTabControl_CostSts);
            this.superTabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel5.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel5.Name = "superTabControlPanel5";
            this.superTabControlPanel5.Size = new System.Drawing.Size(952, 103);
            this.superTabControlPanel5.TabIndex = 6;
            this.superTabControlPanel5.TabItem = this.superTabItem_Gaids;
            // 
            // superTabControl_CostSts
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl_CostSts.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl_CostSts.ControlBox.MenuBox.Name = "";
            this.superTabControl_CostSts.ControlBox.Name = "";
            this.superTabControl_CostSts.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl_CostSts.ControlBox.MenuBox,
            this.superTabControl_CostSts.ControlBox.CloseBox});
            this.superTabControl_CostSts.ControlBox.Visible = false;
            this.superTabControl_CostSts.Controls.Add(this.superTabControlPanel6);
            this.superTabControl_CostSts.Controls.Add(this.superTabControlPanel7);
            this.superTabControl_CostSts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl_CostSts.Location = new System.Drawing.Point(0, 0);
            this.superTabControl_CostSts.Name = "superTabControl_CostSts";
            this.superTabControl_CostSts.ReorderTabsEnabled = true;
            this.superTabControl_CostSts.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_CostSts.SelectedTabIndex = 0;
            this.superTabControl_CostSts.Size = new System.Drawing.Size(952, 103);
            this.superTabControl_CostSts.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_CostSts.TabIndex = 1024;
            this.superTabControl_CostSts.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem_Tax,
            this.superTabItem_Dis,
            this.switchButton_TaxLines,
            this.switchButton_TaxByTotal,
            this.switchButton_TaxByNet,
            this.textBoxItem_TaxByNetValue,
            this.labelItem_TaxByNetPer});
            superTabLinearGradientColorTable6.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.Gainsboro};
            superTabColorTable3.Background = superTabLinearGradientColorTable6;
            this.superTabControl_CostSts.TabStripColor = superTabColorTable3;
            this.superTabControl_CostSts.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.superTabControl_CostSts.Text = "superTabControl3";
            // 
            // superTabControlPanel6
            // 
            this.superTabControlPanel6.Controls.Add(this.switchButton_Tax);
            this.superTabControlPanel6.Controls.Add(this.label34);
            this.superTabControlPanel6.Controls.Add(this.label35);
            this.superTabControlPanel6.Controls.Add(this.txtCredit5);
            this.superTabControlPanel6.Controls.Add(this.txtDebit5);
            this.superTabControlPanel6.Controls.Add(this.checkBox_CostGaidTax);
            this.superTabControlPanel6.Controls.Add(this.label36);
            this.superTabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel6.Location = new System.Drawing.Point(0, 24);
            this.superTabControlPanel6.Name = "superTabControlPanel6";
            superTabLinearGradientColorTable4.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.Gray,
        System.Drawing.Color.White};
            superTabPanelItemColorTable2.Background = superTabLinearGradientColorTable4;
            superTabPanelColorTable2.Default = superTabPanelItemColorTable2;
            this.superTabControlPanel6.PanelColor = superTabPanelColorTable2;
            this.superTabControlPanel6.Size = new System.Drawing.Size(952, 79);
            this.superTabControlPanel6.TabIndex = 1;
            this.superTabControlPanel6.TabItem = this.superTabItem_Tax;
            // 
            // switchButton_Tax
            // 
            // 
            // 
            // 
            this.switchButton_Tax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_Tax.Font = new System.Drawing.Font("Tahoma", 7F);
            this.switchButton_Tax.Location = new System.Drawing.Point(6, 8);
            this.switchButton_Tax.Name = "switchButton_Tax";
            this.switchButton_Tax.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.switchButton_Tax.OffText = "غير معتمد";
            this.switchButton_Tax.OffTextColor = System.Drawing.Color.White;
            this.switchButton_Tax.OnText = "معتمد";
            this.switchButton_Tax.Size = new System.Drawing.Size(104, 21);
            this.switchButton_Tax.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_Tax.TabIndex = 1152;
            this.switchButton_Tax.Value = true;
            this.switchButton_Tax.ValueObject = "Y";
            this.switchButton_Tax.ValueChanged += new System.EventHandler(this.switchButton_Tax_ValueChanged);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.Transparent;
            this.label34.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label34.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label34.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label34.Location = new System.Drawing.Point(862, 34);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(55, 13);
            this.label34.TabIndex = 1150;
            this.label34.Text = "الدائـــــن :";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.Transparent;
            this.label35.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label35.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label35.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label35.Location = new System.Drawing.Point(862, 11);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(53, 13);
            this.label35.TabIndex = 1149;
            this.label35.Text = "المـــدين :";
            // 
            // txtCredit5
            // 
            this.txtCredit5.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtCredit5.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCredit5.ButtonCustom.Visible = true;
            this.txtCredit5.Enabled = false;
            this.txtCredit5.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtCredit5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCredit5.Location = new System.Drawing.Point(116, 37);
            this.txtCredit5.Name = "txtCredit5";
            this.txtCredit5.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtCredit5, false);
            this.txtCredit5.Size = new System.Drawing.Size(736, 14);
            this.txtCredit5.TabIndex = 1147;
            this.txtCredit5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDebit5
            // 
            this.txtDebit5.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtDebit5.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDebit5.ButtonCustom.Visible = true;
            this.txtDebit5.Enabled = false;
            this.txtDebit5.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtDebit5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDebit5.Location = new System.Drawing.Point(116, 14);
            this.txtDebit5.Name = "txtDebit5";
            this.txtDebit5.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtDebit5, false);
            this.txtDebit5.Size = new System.Drawing.Size(736, 14);
            this.txtDebit5.TabIndex = 1145;
            this.txtDebit5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkBox_CostGaidTax
            // 
            this.checkBox_CostGaidTax.AutoSize = true;
            this.checkBox_CostGaidTax.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBox_CostGaidTax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_CostGaidTax.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            this.checkBox_CostGaidTax.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            this.checkBox_CostGaidTax.CheckSignSize = new System.Drawing.Size(14, 14);
            this.checkBox_CostGaidTax.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.checkBox_CostGaidTax.Location = new System.Drawing.Point(7, 32);
            this.checkBox_CostGaidTax.Name = "checkBox_CostGaidTax";
            this.checkBox_CostGaidTax.Size = new System.Drawing.Size(97, 16);
            this.checkBox_CostGaidTax.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_CostGaidTax.TabIndex = 1144;
            this.checkBox_CostGaidTax.Text = "سند محاسبي";
            this.checkBox_CostGaidTax.CheckedChanged += new System.EventHandler(this.checkBox_CostGaidTax_CheckedChanged);
            // 
            // label36
            // 
            this.label36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label36.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label36.ForeColor = System.Drawing.Color.White;
            this.label36.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label36.Location = new System.Drawing.Point(336, 7);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(99, 21);
            this.label36.TabIndex = 1143;
            this.label36.Text = "بالريــــال";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label36.Visible = false;
            // 
            // superTabItem_Tax
            // 
            this.superTabItem_Tax.AttachedControl = this.superTabControlPanel6;
            this.superTabItem_Tax.GlobalItem = false;
            this.superTabItem_Tax.Name = "superTabItem_Tax";
            this.superTabItem_Tax.Text = "الضـــرائب";
            // 
            // superTabControlPanel7
            // 
            this.superTabControlPanel7.Controls.Add(this.switchButton_Dis);
            this.superTabControlPanel7.Controls.Add(this.label31);
            this.superTabControlPanel7.Controls.Add(this.label37);
            this.superTabControlPanel7.Controls.Add(this.label38);
            this.superTabControlPanel7.Controls.Add(this.txtCredit6);
            this.superTabControlPanel7.Controls.Add(this.txtDebit6);
            this.superTabControlPanel7.Controls.Add(this.label39);
            this.superTabControlPanel7.Controls.Add(this.txtTotDis);
            this.superTabControlPanel7.Controls.Add(this.txtTotDisLoc);
            this.superTabControlPanel7.Controls.Add(this.checkBox_GaidDis);
            this.superTabControlPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel7.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel7.Name = "superTabControlPanel7";
            superTabLinearGradientColorTable5.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.Gray,
        System.Drawing.Color.White};
            superTabPanelItemColorTable3.Background = superTabLinearGradientColorTable5;
            superTabPanelColorTable3.Default = superTabPanelItemColorTable3;
            this.superTabControlPanel7.PanelColor = superTabPanelColorTable3;
            this.superTabControlPanel7.Size = new System.Drawing.Size(952, 103);
            this.superTabControlPanel7.TabIndex = 0;
            this.superTabControlPanel7.TabItem = this.superTabItem_Dis;
            // 
            // switchButton_Dis
            // 
            // 
            // 
            // 
            this.switchButton_Dis.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_Dis.Font = new System.Drawing.Font("Tahoma", 7F);
            this.switchButton_Dis.Location = new System.Drawing.Point(6, 6);
            this.switchButton_Dis.Name = "switchButton_Dis";
            this.switchButton_Dis.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.switchButton_Dis.OffText = "+ السطــور";
            this.switchButton_Dis.OffTextColor = System.Drawing.Color.White;
            this.switchButton_Dis.OnText = "+ السطــور";
            this.switchButton_Dis.Size = new System.Drawing.Size(104, 21);
            this.switchButton_Dis.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_Dis.TabIndex = 1165;
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.Color.Transparent;
            this.label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label31.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label31.ForeColor = System.Drawing.Color.Navy;
            this.label31.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label31.Location = new System.Drawing.Point(823, 6);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(99, 21);
            this.label31.TabIndex = 1163;
            this.label31.Text = "إجمالي القيمة";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.BackColor = System.Drawing.Color.Transparent;
            this.label37.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label37.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label37.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label37.Location = new System.Drawing.Point(657, 33);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(55, 13);
            this.label37.TabIndex = 1162;
            this.label37.Text = "الدائـــــن :";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.BackColor = System.Drawing.Color.Transparent;
            this.label38.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label38.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label38.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label38.Location = new System.Drawing.Point(657, 10);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(53, 13);
            this.label38.TabIndex = 1161;
            this.label38.Text = "المـــدين :";
            // 
            // txtCredit6
            // 
            this.txtCredit6.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtCredit6.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCredit6.ButtonCustom.Visible = true;
            this.txtCredit6.Enabled = false;
            this.txtCredit6.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtCredit6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCredit6.Location = new System.Drawing.Point(116, 35);
            this.txtCredit6.Name = "txtCredit6";
            this.txtCredit6.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtCredit6, false);
            this.txtCredit6.Size = new System.Drawing.Size(535, 14);
            this.txtCredit6.TabIndex = 1159;
            this.txtCredit6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDebit6
            // 
            this.txtDebit6.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtDebit6.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDebit6.ButtonCustom.Visible = true;
            this.txtDebit6.Enabled = false;
            this.txtDebit6.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtDebit6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDebit6.Location = new System.Drawing.Point(116, 12);
            this.txtDebit6.Name = "txtDebit6";
            this.txtDebit6.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtDebit6, false);
            this.txtDebit6.Size = new System.Drawing.Size(535, 14);
            this.txtDebit6.TabIndex = 1157;
            this.txtDebit6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label39
            // 
            this.label39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label39.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label39.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label39.ForeColor = System.Drawing.Color.White;
            this.label39.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label39.Location = new System.Drawing.Point(722, 6);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(99, 21);
            this.label39.TabIndex = 1155;
            this.label39.Text = "بالريــــال";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotDis
            // 
            this.txtTotDis.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtTotDis.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTotDis.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotDis.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTotDis.DisplayFormat = "0.00";
            this.txtTotDis.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotDis.Increment = 0D;
            this.txtTotDis.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTotDis.IsInputReadOnly = true;
            this.txtTotDis.Location = new System.Drawing.Point(823, 29);
            this.txtTotDis.MinValue = 0D;
            this.txtTotDis.Name = "txtTotDis";
            this.txtTotDis.Size = new System.Drawing.Size(99, 21);
            this.txtTotDis.TabIndex = 1153;
            // 
            // txtTotDisLoc
            // 
            this.txtTotDisLoc.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtTotDisLoc.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.txtTotDisLoc.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTotDisLoc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotDisLoc.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTotDisLoc.DisplayFormat = "0.00";
            this.txtTotDisLoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotDisLoc.Increment = 0D;
            this.txtTotDisLoc.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTotDisLoc.IsInputReadOnly = true;
            this.txtTotDisLoc.Location = new System.Drawing.Point(722, 29);
            this.txtTotDisLoc.MinValue = 0D;
            this.txtTotDisLoc.Name = "txtTotDisLoc";
            this.txtTotDisLoc.Size = new System.Drawing.Size(99, 21);
            this.txtTotDisLoc.TabIndex = 1154;
            // 
            // checkBox_GaidDis
            // 
            this.checkBox_GaidDis.AutoSize = true;
            this.checkBox_GaidDis.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBox_GaidDis.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_GaidDis.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            this.checkBox_GaidDis.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            this.checkBox_GaidDis.CheckSignSize = new System.Drawing.Size(14, 14);
            this.checkBox_GaidDis.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.checkBox_GaidDis.Location = new System.Drawing.Point(7, 31);
            this.checkBox_GaidDis.Name = "checkBox_GaidDis";
            this.checkBox_GaidDis.Size = new System.Drawing.Size(97, 16);
            this.checkBox_GaidDis.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_GaidDis.TabIndex = 1156;
            this.checkBox_GaidDis.Text = "سند محاسبي";
            // 
            // superTabItem_Dis
            // 
            this.superTabItem_Dis.AttachedControl = this.superTabControlPanel7;
            this.superTabItem_Dis.GlobalItem = false;
            this.superTabItem_Dis.Name = "superTabItem_Dis";
            this.superTabItem_Dis.Text = "الخصـــــم";
            // 
            // switchButton_TaxLines
            // 
            this.switchButton_TaxLines.ButtonWidth = 110;
            this.switchButton_TaxLines.Name = "switchButton_TaxLines";
            this.switchButton_TaxLines.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.switchButton_TaxLines.OffText = "سطور الضريبة";
            this.switchButton_TaxLines.OffTextColor = System.Drawing.Color.White;
            this.switchButton_TaxLines.OnText = "سطور الضريبة";
            this.switchButton_TaxLines.SwitchWidth = 20;
            this.switchButton_TaxLines.Value = true;
            // 
            // switchButton_TaxByTotal
            // 
            this.switchButton_TaxByTotal.ButtonWidth = 110;
            this.switchButton_TaxByTotal.Name = "switchButton_TaxByTotal";
            this.switchButton_TaxByTotal.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.switchButton_TaxByTotal.OffText = "إجمالي السطر";
            this.switchButton_TaxByTotal.OffTextColor = System.Drawing.Color.White;
            this.switchButton_TaxByTotal.OnText = "إجمالي السطر";
            this.switchButton_TaxByTotal.SwitchWidth = 20;
            // 
            // switchButton_TaxByNet
            // 
            this.switchButton_TaxByNet.ButtonWidth = 100;
            this.switchButton_TaxByNet.Name = "switchButton_TaxByNet";
            this.switchButton_TaxByNet.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.switchButton_TaxByNet.OffText = "الصـافي";
            this.switchButton_TaxByNet.OffTextColor = System.Drawing.Color.White;
            this.switchButton_TaxByNet.OnText = "الصـافي";
            this.switchButton_TaxByNet.SwitchWidth = 20;
            // 
            // textBoxItem_TaxByNetValue
            // 
            this.textBoxItem_TaxByNetValue.Name = "textBoxItem_TaxByNetValue";
            this.textBoxItem_TaxByNetValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxItem_TaxByNetValue.Visible = false;
            this.textBoxItem_TaxByNetValue.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.textBoxItem_TaxByNetValue.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelItem_TaxByNetPer
            // 
            this.labelItem_TaxByNetPer.Name = "labelItem_TaxByNetPer";
            this.labelItem_TaxByNetPer.Text = "%";
            this.labelItem_TaxByNetPer.Visible = false;
            // 
            // superTabItem_Gaids
            // 
            this.superTabItem_Gaids.AttachedControl = this.superTabControlPanel5;
            this.superTabItem_Gaids.GlobalItem = false;
            this.superTabItem_Gaids.Name = "superTabItem_Gaids";
            superTabLinearGradientColorTable7.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.Empty};
            superTabItemStateColorTable3.Background = superTabLinearGradientColorTable7;
            superTabColorStates3.Normal = superTabItemStateColorTable3;
            superTabItemColorTable3.Default = superTabColorStates3;
            this.superTabItem_Gaids.TabColor = superTabItemColorTable3;
            this.superTabItem_Gaids.Text = "السنـــدات";
            // 
            // doubleInput_Rate
            // 
            this.doubleInput_Rate.AllowEmptyState = false;
            this.doubleInput_Rate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.doubleInput_Rate.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.doubleInput_Rate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.doubleInput_Rate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.doubleInput_Rate.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.doubleInput_Rate.DisplayFormat = "0.00";
            this.doubleInput_Rate.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.doubleInput_Rate.Increment = 0D;
            this.doubleInput_Rate.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.doubleInput_Rate.IsInputReadOnly = true;
            this.doubleInput_Rate.Location = new System.Drawing.Point(823, 58);
            this.doubleInput_Rate.Name = "doubleInput_Rate";
            this.doubleInput_Rate.Size = new System.Drawing.Size(54, 19);
            this.doubleInput_Rate.TabIndex = 1135;
            // 
            // CmbCostC
            // 
            this.CmbCostC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbCostC.DisplayMember = "Text";
            this.CmbCostC.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbCostC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCostC.FormattingEnabled = true;
            this.CmbCostC.ItemHeight = 14;
            this.CmbCostC.Location = new System.Drawing.Point(285, 10);
            this.CmbCostC.Name = "CmbCostC";
            this.CmbCostC.Size = new System.Drawing.Size(276, 20);
            this.CmbCostC.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbCostC.TabIndex = 6;
            // 
            // CmbCurr
            // 
            this.CmbCurr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbCurr.DisplayMember = "Text";
            this.CmbCurr.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbCurr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCurr.FormattingEnabled = true;
            this.CmbCurr.ItemHeight = 14;
            this.CmbCurr.Location = new System.Drawing.Point(883, 59);
            this.CmbCurr.Name = "CmbCurr";
            this.CmbCurr.Size = new System.Drawing.Size(293, 20);
            this.CmbCurr.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbCurr.TabIndex = 4;
            // 
            // CmbLegate
            // 
            this.CmbLegate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbLegate.DisplayMember = "Text";
            this.CmbLegate.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbLegate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbLegate.FormattingEnabled = true;
            this.CmbLegate.ItemHeight = 14;
            this.CmbLegate.Location = new System.Drawing.Point(334, 34);
            this.CmbLegate.Name = "CmbLegate";
            this.CmbLegate.Size = new System.Drawing.Size(227, 20);
            this.CmbLegate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbLegate.TabIndex = 8;
            // 
            // txtRef
            // 
            this.txtRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRef.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtRef.Location = new System.Drawing.Point(823, 82);
            this.txtRef.Name = "txtRef";
            this.netResize1.SetResizeTextBoxMultiline(this.txtRef, false);
            this.txtRef.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRef.Size = new System.Drawing.Size(354, 21);
            this.txtRef.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(567, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 1134;
            this.label5.Text = "السعر المعتمــد :";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(567, 14);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(85, 13);
            this.label15.TabIndex = 1125;
            this.label15.Text = "مركز التكلفـــــة :";
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label19.Location = new System.Drawing.Point(1183, 62);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(67, 13);
            this.label19.TabIndex = 1133;
            this.label19.Text = "العملــــــــة :";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(567, 38);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 13);
            this.label18.TabIndex = 1132;
            this.label18.Text = "المنـــــدوب :";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(1183, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 1124;
            this.label7.Text = "رقم المرجع :";
            // 
            // Label2
            // 
            this.Label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label2.Location = new System.Drawing.Point(1183, 38);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(66, 13);
            this.Label2.TabIndex = 1123;
            this.Label2.Text = "التاريــــــــخ :";
            // 
            // Label1
            // 
            this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label1.Location = new System.Drawing.Point(1183, 14);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(66, 13);
            this.Label1.TabIndex = 1122;
            this.Label1.Text = "رقم الفاتورة :";
            // 
            // CmbInvPrice
            // 
            this.CmbInvPrice.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbInvPrice.DisplayMember = "Text";
            this.CmbInvPrice.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbInvPrice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbInvPrice.FormattingEnabled = true;
            this.CmbInvPrice.ItemHeight = 14;
            this.CmbInvPrice.Location = new System.Drawing.Point(285, 58);
            this.CmbInvPrice.Name = "CmbInvPrice";
            this.CmbInvPrice.Size = new System.Drawing.Size(276, 20);
            this.CmbInvPrice.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbInvPrice.TabIndex = 7;
            // 
            // txtInvCost
            // 
            this.txtInvCost.AllowEmptyState = false;
            this.txtInvCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtInvCost.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtInvCost.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtInvCost.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtInvCost.DisplayFormat = "0.00";
            this.txtInvCost.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtInvCost.Increment = 0D;
            this.txtInvCost.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtInvCost.IsInputReadOnly = true;
            this.txtInvCost.Location = new System.Drawing.Point(792, 526);
            this.txtInvCost.Name = "txtInvCost";
            this.txtInvCost.Size = new System.Drawing.Size(109, 21);
            this.txtInvCost.TabIndex = 1059;
            // 
            // txtCustNet
            // 
            this.txtCustNet.AllowEmptyState = false;
            this.txtCustNet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtCustNet.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtCustNet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCustNet.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtCustNet.DisplayFormat = "0.00";
            this.txtCustNet.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtCustNet.Increment = 0D;
            this.txtCustNet.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtCustNet.IsInputReadOnly = true;
            this.txtCustNet.Location = new System.Drawing.Point(911, 526);
            this.txtCustNet.Name = "txtCustNet";
            this.txtCustNet.Size = new System.Drawing.Size(109, 21);
            this.txtCustNet.TabIndex = 1060;
            // 
            // txtCustRep
            // 
            this.txtCustRep.AllowEmptyState = false;
            this.txtCustRep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtCustRep.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtCustRep.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCustRep.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtCustRep.DisplayFormat = "0.00";
            this.txtCustRep.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtCustRep.Increment = 0D;
            this.txtCustRep.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtCustRep.IsInputReadOnly = true;
            this.txtCustRep.Location = new System.Drawing.Point(911, 553);
            this.txtCustRep.Name = "txtCustRep";
            this.txtCustRep.Size = new System.Drawing.Size(109, 21);
            this.txtCustRep.TabIndex = 1061;
            // 
            // textBox2
            // 
            this.textBox2.AllowEmptyState = false;
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.textBox2.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox2.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox2.DisplayFormat = "0.00";
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox2.Increment = 0D;
            this.textBox2.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox2.IsInputReadOnly = true;
            this.textBox2.Location = new System.Drawing.Point(792, 582);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(109, 21);
            this.textBox2.TabIndex = 1063;
            // 
            // textBox1
            // 
            this.textBox1.AllowEmptyState = false;
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.textBox1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox1.DisplayFormat = "0.00";
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox1.Increment = 0D;
            this.textBox1.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox1.IsInputReadOnly = true;
            this.textBox1.Location = new System.Drawing.Point(907, 584);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(109, 21);
            this.textBox1.TabIndex = 1056;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.checkBox_Chash);
            this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox5.Location = new System.Drawing.Point(224, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox5.Size = new System.Drawing.Size(169, 47);
            this.groupBox5.TabIndex = 1022;
            this.groupBox5.TabStop = false;
            // 
            // checkBox_Chash
            // 
            this.checkBox_Chash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_Chash.AutoSize = true;
            this.checkBox_Chash.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBox_Chash.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_Chash.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            this.checkBox_Chash.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            this.checkBox_Chash.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBox_Chash.CheckSignSize = new System.Drawing.Size(14, 14);
            this.checkBox_Chash.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.checkBox_Chash.Location = new System.Drawing.Point(46, 31);
            this.checkBox_Chash.Name = "checkBox_Chash";
            this.checkBox_Chash.Size = new System.Drawing.Size(56, 16);
            this.checkBox_Chash.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_Chash.TabIndex = 1020;
            this.checkBox_Chash.Text = "سنـــد";
            this.checkBox_Chash.Visible = false;
            // 
            // pictureBox_Cash
            // 
            this.pictureBox_Cash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Cash.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Cash.Image")));
            this.pictureBox_Cash.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox_Cash.Location = new System.Drawing.Point(-211, 53);
            this.pictureBox_Cash.Name = "pictureBox_Cash";
            this.pictureBox_Cash.Size = new System.Drawing.Size(169, 52);
            this.pictureBox_Cash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox_Cash.TabIndex = 1068;
            this.pictureBox_Cash.TabStop = false;
            // 
            // txtGDate
            // 
            this.txtGDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtGDate.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtGDate.Location = new System.Drawing.Point(1083, 34);
            this.txtGDate.Mask = "0000/00/00";
            this.txtGDate.Name = "txtGDate";
            this.txtGDate.Size = new System.Drawing.Size(94, 21);
            this.txtGDate.TabIndex = 1144;
            this.txtGDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGDate.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtGDate_MaskInputRejected);
            // 
            // groupPanel_Items
            // 
            this.groupPanel_Items.BackColor = System.Drawing.Color.White;
            this.groupPanel_Items.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel_Items.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel_Items.Controls.Add(this.button_SomeItems);
            this.groupPanel_Items.Controls.Add(this.button_AllItems);
            this.groupPanel_Items.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupPanel_Items.Location = new System.Drawing.Point(0, 110);
            this.groupPanel_Items.Name = "groupPanel_Items";
            this.groupPanel_Items.Size = new System.Drawing.Size(62, 164);
            // 
            // 
            // 
            this.groupPanel_Items.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel_Items.Style.BackColorGradientAngle = 90;
            this.groupPanel_Items.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel_Items.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Items.Style.BorderBottomWidth = 1;
            this.groupPanel_Items.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel_Items.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Items.Style.BorderLeftWidth = 1;
            this.groupPanel_Items.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Items.Style.BorderRightWidth = 1;
            this.groupPanel_Items.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Items.Style.BorderTopWidth = 1;
            this.groupPanel_Items.Style.CornerDiameter = 4;
            this.groupPanel_Items.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel_Items.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel_Items.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel_Items.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel_Items.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel_Items.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel_Items.TabIndex = 1586;
            this.groupPanel_Items.Text = "إدراج";
            // 
            // button_SomeItems
            // 
            this.button_SomeItems.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SomeItems.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.button_SomeItems.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button_SomeItems.Location = new System.Drawing.Point(1, 72);
            this.button_SomeItems.Name = "button_SomeItems";
            this.button_SomeItems.Size = new System.Drawing.Size(54, 69);
            this.button_SomeItems.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SomeItems.SymbolSize = 11F;
            this.button_SomeItems.TabIndex = 1587;
            this.button_SomeItems.Text = "حسب\r\nالتصنيف";
            this.button_SomeItems.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SomeItems.Click += new System.EventHandler(this.button_SomeItems_Click);
            // 
            // button_AllItems
            // 
            this.button_AllItems.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_AllItems.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.button_AllItems.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button_AllItems.Location = new System.Drawing.Point(1, 2);
            this.button_AllItems.Name = "button_AllItems";
            this.button_AllItems.Size = new System.Drawing.Size(54, 69);
            this.button_AllItems.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_AllItems.SymbolSize = 11F;
            this.button_AllItems.TabIndex = 1586;
            this.button_AllItems.Text = "جميع\r\nالأصناف";
            this.button_AllItems.TextColor = System.Drawing.Color.SteelBlue;
            this.button_AllItems.Click += new System.EventHandler(this.button_AllItems_Click);
            // 
            // c1BarCode1
            // 
            this.c1BarCode1.BarWide = 1;
            this.c1BarCode1.CodeType = C1.Win.C1BarCode.CodeTypeEnum.Code128;
            this.c1BarCode1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.c1BarCode1.Location = new System.Drawing.Point(960, 184);
            this.c1BarCode1.Name = "c1BarCode1";
            this.c1BarCode1.ShowText = true;
            this.c1BarCode1.Size = new System.Drawing.Size(142, 40);
            this.c1BarCode1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.c1BarCode1.TabIndex = 1589;
            this.c1BarCode1.Text = "1225";
            // 
            // ribbonBar_Tasks
            // 
            this.ribbonBar_Tasks.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar_Tasks.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar_Tasks.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar_Tasks.ContainerControlProcessDialogKey = true;
            this.ribbonBar_Tasks.Controls.Add(this.superTabControl_Main1);
            this.ribbonBar_Tasks.Controls.Add(this.superTabControl_Main2);
            this.ribbonBar_Tasks.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ribbonBar_Tasks.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar_Tasks.Location = new System.Drawing.Point(0, 429);
            this.ribbonBar_Tasks.Name = "ribbonBar_Tasks";
            this.ribbonBar_Tasks.Size = new System.Drawing.Size(1258, 51);
            this.ribbonBar_Tasks.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar_Tasks.TabIndex = 872;
            // 
            // 
            // 
            this.ribbonBar_Tasks.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar_Tasks.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar_Tasks.TitleVisible = false;
            // 
            // superTabControl_Main1
            // 
            this.superTabControl_Main1.BackColor = System.Drawing.Color.White;
            this.superTabControl_Main1.CausesValidation = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl_Main1.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl_Main1.ControlBox.MenuBox.Name = "";
            this.superTabControl_Main1.ControlBox.Name = "";
            this.superTabControl_Main1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl_Main1.ControlBox.MenuBox,
            this.superTabControl_Main1.ControlBox.CloseBox});
            this.superTabControl_Main1.ControlBox.Visible = false;
            this.superTabControl_Main1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl_Main1.ForeColor = System.Drawing.Color.Black;
            this.superTabControl_Main1.ItemPadding.Bottom = 4;
            this.superTabControl_Main1.ItemPadding.Left = 2;
            this.superTabControl_Main1.ItemPadding.Top = 4;
            this.superTabControl_Main1.Location = new System.Drawing.Point(0, 0);
            this.superTabControl_Main1.Name = "superTabControl_Main1";
            this.superTabControl_Main1.ReorderTabsEnabled = true;
            this.superTabControl_Main1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.superTabControl_Main1.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_Main1.SelectedTabIndex = -1;
            this.superTabControl_Main1.Size = new System.Drawing.Size(858, 51);
            this.superTabControl_Main1.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_Main1.TabIndex = 10;
            this.superTabControl_Main1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.Button_BarcodPrint,
            this.button_Repetition,
            this.Button_Close,
            this.buttonItem_Print,
            this.Button_Search,
            this.Button_Delete,
            this.Button_Save,
            this.Button_Add,
            this.Button_Export});
            superTabLinearGradientColorTable8.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.Empty};
            superTabColorTable4.Background = superTabLinearGradientColorTable8;
            this.superTabControl_Main1.TabStripColor = superTabColorTable4;
            this.superTabControl_Main1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.superTabControl_Main1.Text = "superTabControl3";
            this.superTabControl_Main1.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.superTabControl_Main1.RightToLeftChanged += new System.EventHandler(this.superTabControl_Main1_RightToLeftChanged);
            // 
            // Button_BarcodPrint
            // 
            this.Button_BarcodPrint.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_BarcodPrint.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.Button_BarcodPrint.FontBold = true;
            this.Button_BarcodPrint.ForeColor = System.Drawing.Color.Black;
            this.Button_BarcodPrint.Image = ((System.Drawing.Image)(resources.GetObject("Button_BarcodPrint.Image")));
            this.Button_BarcodPrint.ImageFixedSize = new System.Drawing.Size(22, 22);
            this.Button_BarcodPrint.ImagePaddingVertical = 11;
            this.Button_BarcodPrint.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_BarcodPrint.Name = "Button_BarcodPrint";
            this.Button_BarcodPrint.Stretch = true;
            this.Button_BarcodPrint.SubItemsExpandWidth = 11;
            this.Button_BarcodPrint.Symbol = "";
            this.Button_BarcodPrint.SymbolSize = 14F;
            this.Button_BarcodPrint.Text = "BC";
            this.Button_BarcodPrint.Click += new System.EventHandler(this.Button_BarcodPrint_Click);
            // 
            // button_Repetition
            // 
            this.button_Repetition.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.button_Repetition.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground;
            this.button_Repetition.FontBold = true;
            this.button_Repetition.FontItalic = true;
            this.button_Repetition.ForeColor = System.Drawing.Color.Maroon;
            this.button_Repetition.Image = ((System.Drawing.Image)(resources.GetObject("button_Repetition.Image")));
            this.button_Repetition.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.button_Repetition.ImagePaddingHorizontal = 15;
            this.button_Repetition.ImagePaddingVertical = 11;
            this.button_Repetition.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.button_Repetition.Name = "button_Repetition";
            this.button_Repetition.Stretch = true;
            this.button_Repetition.SubItemsExpandWidth = 14;
            this.button_Repetition.Symbol = "";
            this.button_Repetition.SymbolSize = 15F;
            this.button_Repetition.Text = "تكرار";
            this.button_Repetition.Click += new System.EventHandler(this.button_Repetition_Click);
            // 
            // Button_Close
            // 
            this.Button_Close.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Close.Checked = true;
            this.Button_Close.FontBold = true;
            this.Button_Close.FontItalic = true;
            this.Button_Close.ForeColor = System.Drawing.Color.Black;
            this.Button_Close.Image = ((System.Drawing.Image)(resources.GetObject("Button_Close.Image")));
            this.Button_Close.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Close.ImagePaddingHorizontal = 15;
            this.Button_Close.ImagePaddingVertical = 11;
            this.Button_Close.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Close.Name = "Button_Close";
            this.Button_Close.Stretch = true;
            this.Button_Close.SubItemsExpandWidth = 14;
            this.Button_Close.Symbol = "";
            this.Button_Close.SymbolSize = 15F;
            this.Button_Close.Text = "إغلاق";
            this.Button_Close.Tooltip = "إغلاق النافذة الحالية";
            // 
            // buttonItem_Print
            // 
            this.buttonItem_Print.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem_Print.FontBold = true;
            this.buttonItem_Print.FontItalic = true;
            this.buttonItem_Print.ForeColor = System.Drawing.Color.DimGray;
            this.buttonItem_Print.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem_Print.Image")));
            this.buttonItem_Print.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.buttonItem_Print.ImagePaddingHorizontal = 15;
            this.buttonItem_Print.ImagePaddingVertical = 11;
            this.buttonItem_Print.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem_Print.Name = "buttonItem_Print";
            this.buttonItem_Print.Stretch = true;
            this.buttonItem_Print.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.printingsettings});
            this.buttonItem_Print.SubItemsExpandWidth = 14;
            this.buttonItem_Print.Symbol = "";
            this.buttonItem_Print.SymbolSize = 15F;
            this.buttonItem_Print.Text = "طباعة";
            this.buttonItem_Print.Tooltip = "طباعة السجل الحالي";
            // 
            // printingsettings
            // 
            this.printingsettings.Name = "printingsettings";
            this.printingsettings.Symbol = "";
            this.printingsettings.Text = "اعدادات الطابعه";
            this.printingsettings.Click += new System.EventHandler(this.printingsettings_Click);
            // 
            // Button_Search
            // 
            this.Button_Search.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Search.FontBold = true;
            this.Button_Search.FontItalic = true;
            this.Button_Search.ForeColor = System.Drawing.Color.Green;
            this.Button_Search.Image = ((System.Drawing.Image)(resources.GetObject("Button_Search.Image")));
            this.Button_Search.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Search.ImagePaddingHorizontal = 15;
            this.Button_Search.ImagePaddingVertical = 11;
            this.Button_Search.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Search.Name = "Button_Search";
            this.Button_Search.Stretch = true;
            this.Button_Search.SubItemsExpandWidth = 14;
            this.Button_Search.Symbol = "";
            this.Button_Search.SymbolSize = 15F;
            this.Button_Search.Text = "بحث";
            this.Button_Search.Tooltip = "البحث عن سجل ما";
            // 
            // Button_Delete
            // 
            this.Button_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Delete.FontBold = true;
            this.Button_Delete.FontItalic = true;
            this.Button_Delete.ForeColor = System.Drawing.Color.SteelBlue;
            this.Button_Delete.Image = ((System.Drawing.Image)(resources.GetObject("Button_Delete.Image")));
            this.Button_Delete.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Delete.ImagePaddingHorizontal = 15;
            this.Button_Delete.ImagePaddingVertical = 11;
            this.Button_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Delete.Name = "Button_Delete";
            this.Button_Delete.Stretch = true;
            this.Button_Delete.SubItemsExpandWidth = 14;
            this.Button_Delete.Symbol = "";
            this.Button_Delete.SymbolSize = 15F;
            this.Button_Delete.Text = "حذف";
            this.Button_Delete.Tooltip = "حذف السجل الحالي";
            // 
            // Button_Save
            // 
            this.Button_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Save.FontBold = true;
            this.Button_Save.FontItalic = true;
            this.Button_Save.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Button_Save.Image = ((System.Drawing.Image)(resources.GetObject("Button_Save.Image")));
            this.Button_Save.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Save.ImagePaddingHorizontal = 15;
            this.Button_Save.ImagePaddingVertical = 11;
            this.Button_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Stretch = true;
            this.Button_Save.SubItemsExpandWidth = 14;
            this.Button_Save.Symbol = "";
            this.Button_Save.SymbolSize = 15F;
            this.Button_Save.Text = "حفظ";
            this.Button_Save.Tooltip = "حفظ التغييرات";
            // 
            // Button_Add
            // 
            this.Button_Add.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Add.FontBold = true;
            this.Button_Add.FontItalic = true;
            this.Button_Add.ForeColor = System.Drawing.Color.Blue;
            this.Button_Add.Image = ((System.Drawing.Image)(resources.GetObject("Button_Add.Image")));
            this.Button_Add.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Add.ImagePaddingHorizontal = 15;
            this.Button_Add.ImagePaddingVertical = 11;
            this.Button_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Add.Name = "Button_Add";
            this.Button_Add.Stretch = true;
            this.Button_Add.SubItemsExpandWidth = 14;
            this.Button_Add.Symbol = "";
            this.Button_Add.SymbolSize = 15F;
            this.Button_Add.Text = "إضافة";
            this.Button_Add.Tooltip = "إضافة سجل جديد";
            // 
            // Button_Export
            // 
            this.Button_Export.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Export.Checked = true;
            this.Button_Export.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.Button_Export.FontBold = true;
            this.Button_Export.FontItalic = true;
            this.Button_Export.ForeColor = System.Drawing.Color.White;
            this.Button_Export.Image = ((System.Drawing.Image)(resources.GetObject("Button_Export.Image")));
            this.Button_Export.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Export.ImagePaddingHorizontal = 15;
            this.Button_Export.ImagePaddingVertical = 11;
            this.Button_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Export.Name = "Button_Export";
            this.Button_Export.Stretch = true;
            this.Button_Export.SubItemsExpandWidth = 14;
            this.Button_Export.Symbol = "";
            this.Button_Export.SymbolSize = 15F;
            this.Button_Export.Text = "إستيراد";
            this.Button_Export.Tooltip = "إستيراد الأصناف من ملف أكسيل";
            this.Button_Export.Visible = false;
            this.Button_Export.Click += new System.EventHandler(this.Button_Export_Click);
            // 
            // superTabControl_Main2
            // 
            this.superTabControl_Main2.BackColor = System.Drawing.Color.White;
            this.superTabControl_Main2.CausesValidation = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl_Main2.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl_Main2.ControlBox.MenuBox.Name = "";
            this.superTabControl_Main2.ControlBox.Name = "";
            this.superTabControl_Main2.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl_Main2.ControlBox.MenuBox,
            this.superTabControl_Main2.ControlBox.CloseBox});
            this.superTabControl_Main2.ControlBox.Visible = false;
            this.superTabControl_Main2.Dock = System.Windows.Forms.DockStyle.Right;
            this.superTabControl_Main2.ForeColor = System.Drawing.Color.Black;
            this.superTabControl_Main2.ItemPadding.Bottom = 4;
            this.superTabControl_Main2.ItemPadding.Left = 4;
            this.superTabControl_Main2.ItemPadding.Right = 4;
            this.superTabControl_Main2.ItemPadding.Top = 4;
            this.superTabControl_Main2.Location = new System.Drawing.Point(858, 0);
            this.superTabControl_Main2.Name = "superTabControl_Main2";
            this.superTabControl_Main2.ReorderTabsEnabled = true;
            this.superTabControl_Main2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.superTabControl_Main2.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_Main2.SelectedTabIndex = -1;
            this.superTabControl_Main2.Size = new System.Drawing.Size(400, 51);
            this.superTabControl_Main2.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_Main2.TabIndex = 11;
            this.superTabControl_Main2.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem1,
            this.Button_First,
            this.Button_Prev,
            this.TextBox_Index,
            this.Label_Count,
            this.lable_Records,
            this.Button_Next,
            this.Button_Last});
            superTabLinearGradientColorTable9.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.Empty};
            superTabColorTable1.Background = superTabLinearGradientColorTable9;
            this.superTabControl_Main2.TabStripColor = superTabColorTable1;
            this.superTabControl_Main2.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.superTabControl_Main2.Text = "superTabControl1";
            this.superTabControl_Main2.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Width = 2;
            // 
            // Button_First
            // 
            this.Button_First.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_First.FontBold = true;
            this.Button_First.FontItalic = true;
            this.Button_First.ForeColor = System.Drawing.Color.SteelBlue;
            this.Button_First.Image = ((System.Drawing.Image)(resources.GetObject("Button_First.Image")));
            this.Button_First.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_First.ImagePaddingHorizontal = 15;
            this.Button_First.ImagePaddingVertical = 11;
            this.Button_First.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_First.Name = "Button_First";
            this.Button_First.SplitButton = true;
            this.Button_First.Stretch = true;
            this.Button_First.SubItemsExpandWidth = 14;
            this.Button_First.Symbol = "";
            this.Button_First.SymbolSize = 15F;
            this.Button_First.Text = "الأول";
            this.Button_First.Tooltip = "السجل الاول";
            // 
            // Button_Prev
            // 
            this.Button_Prev.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Prev.FontBold = true;
            this.Button_Prev.FontItalic = true;
            this.Button_Prev.ForeColor = System.Drawing.Color.SteelBlue;
            this.Button_Prev.Image = ((System.Drawing.Image)(resources.GetObject("Button_Prev.Image")));
            this.Button_Prev.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Prev.ImagePaddingHorizontal = 15;
            this.Button_Prev.ImagePaddingVertical = 11;
            this.Button_Prev.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Prev.Name = "Button_Prev";
            this.Button_Prev.SplitButton = true;
            this.Button_Prev.Stretch = true;
            this.Button_Prev.SubItemsExpandWidth = 14;
            this.Button_Prev.Symbol = "";
            this.Button_Prev.SymbolSize = 15F;
            this.Button_Prev.Text = "السابق";
            this.Button_Prev.Tooltip = "السجل السابق";
            // 
            // TextBox_Index
            // 
            this.TextBox_Index.Name = "TextBox_Index";
            this.TextBox_Index.TextBoxWidth = 50;
            this.TextBox_Index.Visible = false;
            this.TextBox_Index.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // Label_Count
            // 
            this.Label_Count.Name = "Label_Count";
            this.Label_Count.Visible = false;
            this.Label_Count.Width = 40;
            // 
            // lable_Records
            // 
            this.lable_Records.BackColor = System.Drawing.Color.SteelBlue;
            this.lable_Records.ForeColor = System.Drawing.Color.White;
            this.lable_Records.Name = "lable_Records";
            this.lable_Records.Text = "---";
            // 
            // Button_Next
            // 
            this.Button_Next.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Next.FontBold = true;
            this.Button_Next.FontItalic = true;
            this.Button_Next.ForeColor = System.Drawing.Color.SteelBlue;
            this.Button_Next.Image = ((System.Drawing.Image)(resources.GetObject("Button_Next.Image")));
            this.Button_Next.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Next.ImagePaddingHorizontal = 15;
            this.Button_Next.ImagePaddingVertical = 11;
            this.Button_Next.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Next.Name = "Button_Next";
            this.Button_Next.SplitButton = true;
            this.Button_Next.Stretch = true;
            this.Button_Next.SubItemsExpandWidth = 14;
            this.Button_Next.Symbol = "";
            this.Button_Next.SymbolSize = 15F;
            this.Button_Next.Text = "التالي";
            this.Button_Next.Tooltip = " السجل التالي";
            // 
            // Button_Last
            // 
            this.Button_Last.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Last.FontBold = true;
            this.Button_Last.FontItalic = true;
            this.Button_Last.ForeColor = System.Drawing.Color.SteelBlue;
            this.Button_Last.Image = ((System.Drawing.Image)(resources.GetObject("Button_Last.Image")));
            this.Button_Last.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Last.ImagePaddingHorizontal = 15;
            this.Button_Last.ImagePaddingVertical = 11;
            this.Button_Last.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Last.Name = "Button_Last";
            this.Button_Last.SplitButton = true;
            this.Button_Last.Stretch = true;
            this.Button_Last.SubItemsExpandWidth = 14;
            this.Button_Last.Symbol = "";
            this.Button_Last.SymbolSize = 15F;
            this.Button_Last.Text = "الأخير";
            this.Button_Last.Tooltip = " السجل الاخير";
            // 
            // ToolStripMenuItem_Rep
            // 
            this.ToolStripMenuItem_Rep.Checked = true;
            this.ToolStripMenuItem_Rep.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToolStripMenuItem_Rep.Name = "ToolStripMenuItem_Rep";
            this.ToolStripMenuItem_Rep.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem_Rep.Text = "إظهار التقرير";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "");
            this.imageList1.Images.SetKeyName(13, "");
            this.imageList1.Images.SetKeyName(14, "");
            this.imageList1.Images.SetKeyName(15, "");
            this.imageList1.Images.SetKeyName(16, "");
            this.imageList1.Images.SetKeyName(17, "");
            this.imageList1.Images.SetKeyName(18, "");
            this.imageList1.Images.SetKeyName(19, "");
            this.imageList1.Images.SetKeyName(20, "");
            this.imageList1.Images.SetKeyName(21, "");
            this.imageList1.Images.SetKeyName(22, "");
            this.imageList1.Images.SetKeyName(23, "");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // timerInfoBallon
            // 
            this.timerInfoBallon.Interval = 3000;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Det,
            this.ToolStripMenuItem_Rep});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip2.Size = new System.Drawing.Size(149, 48);
            // 
            // ToolStripMenuItem_Det
            // 
            this.ToolStripMenuItem_Det.Name = "ToolStripMenuItem_Det";
            this.ToolStripMenuItem_Det.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem_Det.Text = "إظهار التفاصيل";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "*.rtf";
            this.saveFileDialog1.FileName = "doc1";
            this.saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf|All Files(*.*)|*.*";
            this.saveFileDialog1.FilterIndex = 2;
            this.saveFileDialog1.Title = "Save File";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // prnt_doc
            // 
            this.prnt_doc.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.prnt_doc_BeginPrint);
            this.prnt_doc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.prnt_doc_PrintPage);
            // 
            // prnt_prev
            // 
            this.prnt_prev.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.prnt_prev.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.prnt_prev.ClientSize = new System.Drawing.Size(400, 300);
            this.prnt_prev.Document = this.prnt_doc;
            this.prnt_prev.Enabled = true;
            this.prnt_prev.Icon = ((System.Drawing.Icon)(resources.GetObject("prnt_prev.Icon")));
            this.prnt_prev.Name = "prnt_prev";
            this.prnt_prev.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelEx3);
            this.panel1.Controls.Add(this.expandableSplitter1);
            this.panel1.Controls.Add(this.panelEx2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1258, 480);
            this.panel1.TabIndex = 895;
            // 
            // panelEx3
            // 
            this.panelEx3.Controls.Add(this.DGV_Main);
            this.panelEx3.Controls.Add(this.ribbonBar_DGV);
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx3.Location = new System.Drawing.Point(0, 0);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(1258, 0);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.panelEx3.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 2;
            this.panelEx3.Text = "Fill Panel";
            // 
            // DGV_Main
            // 
            this.DGV_Main.BackColor = System.Drawing.Color.Transparent;
            background9.BackFillType = DevComponents.DotNetBar.SuperGrid.Style.BackFillType.VerticalCenter;
            background9.Color1 = System.Drawing.Color.Silver;
            background9.Color2 = System.Drawing.Color.White;
            this.DGV_Main.DefaultVisualStyles.GroupByStyles.Default.Background = background9;
            background10.BackFillType = DevComponents.DotNetBar.SuperGrid.Style.BackFillType.Center;
            background10.Color1 = System.Drawing.Color.LightSteelBlue;
            this.DGV_Main.DefaultVisualStyles.RowStyles.Default.Background = background10;
            background11.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DGV_Main.DefaultVisualStyles.RowStyles.MouseOver.Background = background11;
            this.DGV_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Main.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.DGV_Main.Font = new System.Drawing.Font("Tahoma", 9F);
            this.DGV_Main.ForeColor = System.Drawing.Color.Black;
            this.DGV_Main.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.DGV_Main.Location = new System.Drawing.Point(0, 0);
            this.DGV_Main.Name = "DGV_Main";
            this.DGV_Main.PrimaryGrid.ActiveRowIndicatorStyle = DevComponents.DotNetBar.SuperGrid.ActiveRowIndicatorStyle.Both;
            this.DGV_Main.PrimaryGrid.AllowEdit = false;
            this.DGV_Main.PrimaryGrid.Caption.BackgroundImageLayout = DevComponents.DotNetBar.SuperGrid.GridBackgroundImageLayout.Center;
            this.DGV_Main.PrimaryGrid.Caption.Text = "";
            this.DGV_Main.PrimaryGrid.Caption.Visible = false;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.TextColor = System.Drawing.Color.Black;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.TextColor = System.Drawing.Color.Black;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.CaptionStyles.Default.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.CaptionStyles.Default.TextColor = System.Drawing.Color.White;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.CaptionStyles.ReadOnly.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.CellStyles.Selected.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderRowStyles.Default.RowHeader.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            borderColor5.Bottom = System.Drawing.Color.Black;
            borderColor5.Left = System.Drawing.Color.Black;
            borderColor5.Right = System.Drawing.Color.Black;
            borderColor5.Top = System.Drawing.Color.Black;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.BorderColor = borderColor5;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.TextColor = System.Drawing.Color.SteelBlue;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.TextColor = System.Drawing.Color.White;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.FooterStyles.Default.TextColor = System.Drawing.Color.White;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            borderColor6.Bottom = System.Drawing.Color.Black;
            borderColor6.Left = System.Drawing.Color.Black;
            borderColor6.Right = System.Drawing.Color.Black;
            borderColor6.Top = System.Drawing.Color.Black;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.BorderColor = borderColor6;
            baseTreeButtonVisualStyle5.BorderColor = System.Drawing.Color.White;
            baseTreeButtonVisualStyle5.LineColor = System.Drawing.Color.White;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.CircleTreeButtonStyle.ExpandButton = baseTreeButtonVisualStyle5;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.HeaderHLinePattern = DevComponents.DotNetBar.SuperGrid.Style.LinePattern.None;
            background12.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            baseTreeButtonVisualStyle6.Background = background12;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.SquareTreeButtonStyle.ExpandButton = baseTreeButtonVisualStyle6;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.TextColor = System.Drawing.Color.White;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.TitleStyles.Default.RowHeaderStyle.TextAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.DGV_Main.PrimaryGrid.GroupByRow.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.Never;
            this.DGV_Main.PrimaryGrid.GroupByRow.Text = "جميــع السجــــلات";
            this.DGV_Main.PrimaryGrid.GroupByRow.Visible = true;
            this.DGV_Main.PrimaryGrid.GroupByRow.WatermarkText = "";
            this.DGV_Main.PrimaryGrid.InitialActiveRow = DevComponents.DotNetBar.SuperGrid.RelativeRow.None;
            this.DGV_Main.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.None;
            this.DGV_Main.PrimaryGrid.MultiSelect = false;
            this.DGV_Main.PrimaryGrid.ShowRowGridIndex = true;
            this.DGV_Main.PrimaryGrid.Title.AllowSelection = false;
            this.DGV_Main.PrimaryGrid.Title.Text = "";
            this.DGV_Main.PrimaryGrid.Title.Visible = false;
            this.DGV_Main.PrimaryGrid.Visible = false;
            this.DGV_Main.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DGV_Main.Size = new System.Drawing.Size(1258, 0);
            this.DGV_Main.TabIndex = 876;
            // 
            // ribbonBar_DGV
            // 
            this.ribbonBar_DGV.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar_DGV.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar_DGV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar_DGV.ContainerControlProcessDialogKey = true;
            this.ribbonBar_DGV.Controls.Add(this.superTabControl_DGV);
            this.ribbonBar_DGV.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ribbonBar_DGV.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar_DGV.Location = new System.Drawing.Point(0, -51);
            this.ribbonBar_DGV.Name = "ribbonBar_DGV";
            this.ribbonBar_DGV.Size = new System.Drawing.Size(1258, 51);
            this.ribbonBar_DGV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar_DGV.TabIndex = 877;
            // 
            // 
            // 
            this.ribbonBar_DGV.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar_DGV.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar_DGV.TitleVisible = false;
            // 
            // superTabControl_DGV
            // 
            this.superTabControl_DGV.BackColor = System.Drawing.Color.White;
            this.superTabControl_DGV.CausesValidation = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl_DGV.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl_DGV.ControlBox.MenuBox.Name = "";
            this.superTabControl_DGV.ControlBox.Name = "";
            this.superTabControl_DGV.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl_DGV.ControlBox.MenuBox,
            this.superTabControl_DGV.ControlBox.CloseBox});
            this.superTabControl_DGV.ControlBox.Visible = false;
            this.superTabControl_DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl_DGV.ForeColor = System.Drawing.Color.Black;
            this.superTabControl_DGV.ItemPadding.Bottom = 4;
            this.superTabControl_DGV.ItemPadding.Left = 4;
            this.superTabControl_DGV.ItemPadding.Right = 4;
            this.superTabControl_DGV.ItemPadding.Top = 4;
            this.superTabControl_DGV.Location = new System.Drawing.Point(0, 0);
            this.superTabControl_DGV.Name = "superTabControl_DGV";
            this.superTabControl_DGV.ReorderTabsEnabled = true;
            this.superTabControl_DGV.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.superTabControl_DGV.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_DGV.SelectedTabIndex = -1;
            this.superTabControl_DGV.Size = new System.Drawing.Size(1258, 51);
            this.superTabControl_DGV.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_DGV.TabIndex = 12;
            this.superTabControl_DGV.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.textBox_search,
            this.Button_ExportTable2,
            this.Button_PrintTable,
            this.Button_PrintTableMulti,
            this.labelItem3});
            this.superTabControl_DGV.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.superTabControl_DGV.Text = "superTabControl1";
            this.superTabControl_DGV.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            // 
            // textBox_search
            // 
            this.textBox_search.ButtonCustom.Text = "...";
            this.textBox_search.ButtonCustom.Visible = true;
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.TextBoxHeight = 44;
            this.textBox_search.TextBoxWidth = 150;
            this.textBox_search.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // Button_ExportTable2
            // 
            this.Button_ExportTable2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_ExportTable2.FontBold = true;
            this.Button_ExportTable2.FontItalic = true;
            this.Button_ExportTable2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Button_ExportTable2.Image = ((System.Drawing.Image)(resources.GetObject("Button_ExportTable2.Image")));
            this.Button_ExportTable2.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.Button_ExportTable2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_ExportTable2.Name = "Button_ExportTable2";
            this.Button_ExportTable2.SubItemsExpandWidth = 14;
            this.Button_ExportTable2.Symbol = "";
            this.Button_ExportTable2.SymbolSize = 15F;
            this.Button_ExportTable2.Text = "تصدير";
            this.Button_ExportTable2.Tooltip = "تصدير الى الأكسيل";
            // 
            // Button_PrintTable
            // 
            this.Button_PrintTable.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_PrintTable.Checked = true;
            this.Button_PrintTable.FontBold = true;
            this.Button_PrintTable.FontItalic = true;
            this.Button_PrintTable.Image = ((System.Drawing.Image)(resources.GetObject("Button_PrintTable.Image")));
            this.Button_PrintTable.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.Button_PrintTable.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_PrintTable.Name = "Button_PrintTable";
            this.Button_PrintTable.SubItemsExpandWidth = 14;
            this.Button_PrintTable.Symbol = "";
            this.Button_PrintTable.SymbolSize = 15F;
            this.Button_PrintTable.Text = "طباعة";
            this.Button_PrintTable.Tooltip = "طباعة";
            // 
            // Button_PrintTableMulti
            // 
            this.Button_PrintTableMulti.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_PrintTableMulti.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.Button_PrintTableMulti.FontBold = true;
            this.Button_PrintTableMulti.FontItalic = true;
            this.Button_PrintTableMulti.Image = ((System.Drawing.Image)(resources.GetObject("Button_PrintTableMulti.Image")));
            this.Button_PrintTableMulti.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.Button_PrintTableMulti.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_PrintTableMulti.Name = "Button_PrintTableMulti";
            this.Button_PrintTableMulti.SubItemsExpandWidth = 14;
            this.Button_PrintTableMulti.Symbol = "";
            this.Button_PrintTableMulti.SymbolSize = 15F;
            this.Button_PrintTableMulti.Text = "طباعة الفواتير المحددة";
            this.Button_PrintTableMulti.Tooltip = "طباعة الفواتير المحددة";
            this.Button_PrintTableMulti.Click += new System.EventHandler(this.Button_PrintTableMulti_Click);
            // 
            // labelItem3
            // 
            this.labelItem3.Name = "labelItem3";
            this.labelItem3.Width = 40;
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor = System.Drawing.Color.Black;
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            this.expandableSplitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.expandableSplitter1.ExpandableControl = this.panelEx2;
            this.expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.ExpandLineColor = System.Drawing.SystemColors.ControlText;
            this.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.ForeColor = System.Drawing.Color.Black;
            this.expandableSplitter1.GripDarkColor = System.Drawing.SystemColors.ControlText;
            this.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(142)))), ((int)(((byte)(75)))));
            this.expandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(139)))));
            this.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotExpandLineColor = System.Drawing.SystemColors.ControlText;
            this.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.expandableSplitter1.Location = new System.Drawing.Point(0, -14);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(1258, 14);
            this.expandableSplitter1.TabIndex = 1;
            this.expandableSplitter1.TabStop = false;
            // 
            // panelEx2
            // 
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx2.Location = new System.Drawing.Point(0, 0);
            this.panelEx2.MinimumSize = new System.Drawing.Size(824, 459);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(1258, 480);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 0;
            this.panelEx2.Text = "Click to collapse";
            // 
            // barTaskList
            // 
            this.barTaskList.AccessibleDescription = "DotNetBar Bar (barTaskList)";
            this.barTaskList.AccessibleName = "DotNetBar Bar";
            this.barTaskList.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.barTaskList.AutoHideAnimationTime = 0;
            this.barTaskList.AutoSyncBarCaption = true;
            this.barTaskList.CanAutoHide = false;
            this.barTaskList.CanDockTop = false;
            this.barTaskList.CloseSingleTab = true;
            this.barTaskList.Controls.Add(this.panelDockContainer1);
            this.barTaskList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barTaskList.DockedBorderStyle = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.barTaskList.DockSide = DevComponents.DotNetBar.eDockSide.Top;
            this.barTaskList.Font = new System.Drawing.Font("Tahoma", 8F);
            this.barTaskList.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.Caption;
            this.barTaskList.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.Panel_Navigate});
            this.barTaskList.ItemSpacing = 10;
            this.barTaskList.LayoutType = DevComponents.DotNetBar.eLayoutType.DockContainer;
            this.barTaskList.Location = new System.Drawing.Point(0, 391);
            this.barTaskList.Name = "barTaskList";
            this.barTaskList.PaddingBottom = 0;
            this.barTaskList.PaddingLeft = 0;
            this.barTaskList.PaddingRight = 0;
            this.barTaskList.PaddingTop = 0;
            this.barTaskList.SingleLineColor = System.Drawing.Color.Maroon;
            this.barTaskList.Size = new System.Drawing.Size(824, 119);
            this.barTaskList.Stretch = true;
            this.barTaskList.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.barTaskList.TabIndex = 889;
            this.barTaskList.TabStop = false;
            // 
            // panelDockContainer1
            // 
            this.panelDockContainer1.Location = new System.Drawing.Point(5, 25);
            this.panelDockContainer1.Name = "panelDockContainer1";
            this.panelDockContainer1.Size = new System.Drawing.Size(814, 89);
            this.panelDockContainer1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelDockContainer1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.panelDockContainer1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelDockContainer1.Style.GradientAngle = 90;
            this.panelDockContainer1.TabIndex = 1;
            // 
            // Panel_Navigate
            // 
            this.Panel_Navigate.Control = this.panelDockContainer1;
            this.Panel_Navigate.DefaultFloatingSize = new System.Drawing.Size(256, 196);
            this.Panel_Navigate.GlobalItem = true;
            this.Panel_Navigate.GlobalName = "dockTaskList";
            this.Panel_Navigate.Image = ((System.Drawing.Image)(resources.GetObject("Panel_Navigate.Image")));
            this.Panel_Navigate.Name = "Panel_Navigate";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.rtf";
            this.openFileDialog1.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf|All Files(*.*)|*.*";
            this.openFileDialog1.FilterIndex = 2;
            this.openFileDialog1.Title = "Open File";
            // 
            // txtItemName
            // 
            this.txtItemName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(217)))), ((int)(((byte)(243)))));
            this.txtItemName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtItemName.Location = new System.Drawing.Point(225, 231);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtItemName, false);
            this.txtItemName.Size = new System.Drawing.Size(374, 13);
            this.txtItemName.TabIndex = 1079;
            this.txtItemName.Visible = false;
            // 
            // printDialog1
            // 
            this.printDialog1.AllowSelection = true;
            this.printDialog1.AllowSomePages = true;
            this.printDialog1.Document = this.prnt_doc;
            this.printDialog1.UseEXDialog = true;
            // 
            // prnt_doc2
            // 
            this.prnt_doc2.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.prnt_doc2_BeginPrint);
            this.prnt_doc2.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.prnt_doc2_PrintPage);
            // 
            // netResize1
            // 
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            // 
            // FMOpenQuantities
            // 
            this.ClientSize = new System.Drawing.Size(1258, 480);
            this.Controls.Add(this.PanelSpecialContainer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtItemName);
            this.Icon = global::InvAcc.Properties.Resources.favicon;
            this.KeyPreview = true;
            this.Name = "FMOpenQuantities";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " بضاعة أول المدة";
            this.Load += new System.EventHandler(this.FMOpenQuantities_Load);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FMOpenQuantities_KeyUp);
            this.PanelSpecialContainer.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            this.ribbonBar1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlxDat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlxInv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDueAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalAm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountValLoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalAmLoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotTaxLoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDueAmountLoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Info)).EndInit();
            this.superTabControl_Info.ResumeLayout(false);
            this.superTabControlPanel3.ResumeLayout(false);
            this.superTabControlPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlxStkQty)).EndInit();
            this.superTabControlPanel1.ResumeLayout(false);
            this.superTabControlPanel1.PerformLayout();
            this.superTabControlPanel2.ResumeLayout(false);
            this.superTabControlPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalQ)).EndInit();
            this.superTabControlPanel4.ResumeLayout(false);
            this.superTabControlPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_CostSts)).EndInit();
            this.superTabControl_CostSts.ResumeLayout(false);
            this.superTabControlPanel6.ResumeLayout(false);
            this.superTabControlPanel6.PerformLayout();
            this.superTabControlPanel7.ResumeLayout(false);
            this.superTabControlPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotDis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotDisLoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_Rate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustNet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustRep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Cash)).EndInit();
            this.groupPanel_Items.ResumeLayout(false);
            this.ribbonBar_Tasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main2)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelEx3.ResumeLayout(false);
            this.ribbonBar_DGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barTaskList)).EndInit();
            this.barTaskList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private void textBox_ID_TextChanged_1(object sender, EventArgs e)
        {
        }
        private void txtGDate_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
        }
        private void printingsettings_Click(object sender, EventArgs e)
        {
            DroBoxSync.Frm_PrinterShow f = new DroBoxSync.Frm_PrinterShow(VarGeneral.InvTyp);
            f.TopMost = true;
            f.ShowDialog();
            _InvSetting.InvpRINTERInfo.nTyp = DroBoxSync.Frm_PrinterShow.PLSetting;
        }
        private void FlxInv_SizeChanged(object sender, EventArgs e)
        {
        }
        int kk = 0;
        private void FlxInv_LeaveEdit(object sender, RowColEventArgs e)
        {
            kk = 0;
        }
        private void FlxInv_StartEdit(object sender, RowColEventArgs e)
        {
            kk = 1;
        }
    }
}
