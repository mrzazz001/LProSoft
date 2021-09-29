using C1.Win.C1BarCode;
using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using Framework.Data;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Library.RepShow;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using TFG;
namespace InvAcc.Forms
{
    public partial  class FrmInvOffer : Form
    { void avs(int arln)

{ 
 labelPharmacy3.Text=   (arln == 0 ? "  يوم  " : "  day") ; labelPharmacy2.Text=   (arln == 0 ? "  يوم ,يصرف منها  " : "  day, spent") ; labelPharmacy1.Text=   (arln == 0 ? "  مدة العلاج :  " : "  Duration of treatment:") ; c1BarCode1.Text=   (arln == 0 ? "  1225  " : "  1225") ; label7.Text=   (arln == 0 ? "  إســم العـــرض :  " : "  Offer name:") ; txtRemark.Text=   (arln == 0 ? "  ملاحظة  " : "  Notice") ; label27.Text=   (arln == 0 ? "  المستخدم :  " : "  the user :") ; label3.Text=   (arln == 0 ? "  تاريخ النهاية :  " : "  Expiry date :") ; groupBox5.Text=   (arln == 0 ? "  طريقة الخصم  " : "  Discount method") ; checkBox_NetWork.Text=   (arln == 0 ? "  شبكـــة  " : "  network") ; checkBox_DisRate.Text=   (arln == 0 ? "  نسبـــة  " : "  ratio") ; checkBox_DisVal.Text=   (arln == 0 ? "  قيمـــة  " : "  value") ; label4.Text=   (arln == 0 ? "  حساب العميــل :  " : "  Customer account:") ; Label2.Text=   (arln == 0 ? "  تاريخ البداية :  " : "  Start Date :") ; Label1.Text=   (arln == 0 ? "  رقم العرض :  " : "  Display number:") ; label5.Text=   (arln == 0 ? "  السعر المعتمــد :  " : "  Approved price:") ; superTabControl_Main1.Text=   (arln == 0 ? "  superTabControl3  " : "  superTabControl3") ; Button_Close.Text=   (arln == 0 ? "  إغلاق  " : "  Close") ; Button_Search.Text=   (arln == 0 ? "  بحث  " : "  Search") ; Button_Delete.Text=   (arln == 0 ? "  حذف  " : "  delete") ; Button_Save.Text=   (arln == 0 ? "  حفظ  " : "  save") ; Button_Add.Text=   (arln == 0 ? "  إضافة  " : "  addition") ; superTabControl_Main2.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; Button_First.Text=   (arln == 0 ? "  الأول  " : "  the first") ; Button_Prev.Text=   (arln == 0 ? "  السابق  " : "  the previous") ; lable_Records.Text=   (arln == 0 ? "  ---  " : "  ---") ; Button_Next.Text=   (arln == 0 ? "  التالي  " : "  next one") ; Button_Last.Text=   (arln == 0 ? "  الأخير  " : "  the last one") ; ToolStripMenuItem_Rep.Text=   (arln == 0 ? "  إظهار التقرير  " : "  Show report") ; ToolStripMenuItem_Det.Text=   (arln == 0 ? "  إظهار التفاصيل  " : "  Show details") ; panelEx3.Text=   (arln == 0 ? "  Fill Panel  " : "  Fill Panel") ; DGV_Main.Text=   (arln == 0 ? "    " : "    ") ; DGV_Main.Text=   (arln == 0 ? "  جميــع السجــــلات  " : "  All records") ; DGV_Main.Text=   (arln == 0 ? "    " : "    ") ; superTabControl_DGV.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; textBox_search.Text=   (arln == 0 ? "  ...  " : "  ...") ; panelEx2.Text=   (arln == 0 ? "  Click to collapse  " : "  Click to collapse") ; Text = "العـــروض الخـــاصة";this.Text=   (arln == 0 ? "  العـــروض الخـــاصة  " : "  Special Offers") ;}
        private void langloads(object sender, EventArgs e)
        {
            int k = 0;
       
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
        private RibbonBar ribbonBar1;
        private ImageList imageList1;
        protected ContextMenuStrip contextMenuStrip1;
        protected ContextMenuStrip contextMenuStrip2;
        protected ToolStripMenuItem ToolStripMenuItem_Det;
        private System.Windows.Forms. SaveFileDialog saveFileDialog1;
        private PanelEx panelEx3;
        private PanelEx panelEx2;
        private ExpandableSplitter expandableSplitter1;
        private Panel panel1;
        private RibbonBar ribbonBar_Tasks;
        private SuperTabControl superTabControl_Main1;
        protected ButtonItem Button_Close;
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
        protected SuperGridControl DGV_Main;
        private RibbonBar ribbonBar_DGV;
        private SuperTabControl superTabControl_DGV;
        protected TextBoxItem textBox_search;
        protected LabelItem labelItem3;
        private ControlContainerItem controlContainerItem1;
        private LabelItem lable_Records;
        private C1BarCode c1BarCode1;
        internal Label labelPharmacy3;
        internal Label labelPharmacy2;
        internal Label labelPharmacy1;
        private SuperTabControlPanel superTabControlPanel10;
        internal Label label44;
        internal Label label45;
        internal Label label46;
        private TextBoxX txtCredit8;
        internal Label label47;
        private ExpandableSplitter expandableSplitter2;
        private PanelEx panelEx3x;
        private C1FlexGrid FlxInvDet;
        private PanelEx panelEx2x;
        private C1FlexGrid FlxInv;
        private Panel panel2;
        protected TextBox textBox_OfferName;
        internal Label label7;
        private TextBoxX txtRemark;
        internal Label label27;
        private TextBox textBox_Usr;
        internal Label label3;
        internal GroupBox groupBox5;
        private CheckBoxX checkBox_NetWork;
        private CheckBoxX checkBox_DisRate;
        private CheckBoxX checkBox_DisVal;
        private TextBoxX textBox_ID;
        private ButtonX button_SrchCustNo;
        private TextBox txtCustNo;
        internal TextBox txtCustName;
        internal Label label4;
        private ComboBoxEx CmbInvPrice;
        internal Label Label2;
        internal Label Label1;
        private MaskedTextBox txtStartDate;
        private MaskedTextBox txtEndDate;
        internal Label label5;
        private SwitchButton switchButton_OfferTyp;
        private C1FlexGrid FlxDat;
        private ScriptNumber ScriptNumber1 = new ScriptNumber();
        public Dictionary<string, string> columns_Nams_Sums = new Dictionary<string, string>();
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private int RowSel = 0;
        private string oldUnit = "";
        private string oldUnitDet = "";
        private int DefPack = 0;
        private double Pack = 0.0;
        private double PackDet = 0.0;
        public static int LangArEn = 0;
        public string DocType = "";
        private T_SYSSETTING _SysSetting = new T_SYSSETTING();
        private List<T_SYSSETTING> listSysSetting = new List<T_SYSSETTING>();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private List<T_INVSETTING> listInvSetting = new List<T_INVSETTING>();
        private T_Unit _Unit = new T_Unit();
        private List<T_Unit> listUnit = new List<T_Unit>();
        private T_Item _Items = new T_Item();
        private List<T_Item> listItems = new List<T_Item>();
        private T_OfferDet _InvDet = new T_OfferDet();
        private T_OfferQFree _InvDetQFree = new T_OfferQFree();
        private T_Offer data_this;
        private T_STKSQTY data_this_stkQ;
        private List<T_OfferDet> LData_This;
        private List<T_OfferQFree> LData_ThisQFree;
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
        private Stock_DataDataContext dbInstanceReturn;
        private T_User permission = new T_User();
        private List<string> _StorePr = new List<string>();
        private T_Store _Store = new T_Store();
        private List<T_Store> listStore = new List<T_Store>();
        private List<T_STKSQTY> listStkQty = new List<T_STKSQTY>();
        private List<T_QTYEXP> listQtyExp = new List<T_QTYEXP>();
        private T_QTYEXP _QtyExp = new T_QTYEXP();
        private T_STKSQTY _StksQty = new T_STKSQTY();
        public T_Offer DataThis
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
        public List<T_OfferDet> LDataThis
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
        public List<T_OfferQFree> LDataThisQFree
        {
            get
            {
                return LData_ThisQFree;
            }
            set
            {
                LData_ThisQFree = value;
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
        private Stock_DataDataContext dbReturn
        {
            get
            {
                if (dbInstanceReturn == null)
                {
                    dbInstanceReturn = new Stock_DataDataContext(VarGeneral.BranchCS);
                }
                return dbInstanceReturn;
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
                    if (!VarGeneral.TString.ChkStatShow(value.InvStr, 53))
                    {
                        IfAdd = false;
                    }
                    else
                    {
                        IfAdd = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.InvStr, 54))
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.InvStr, 55))
                    {
                        IfDelete = false;
                    }
                    else
                    {
                        IfDelete = true;
                    }
                    if (VarGeneral.vDemo && VarGeneral.UserID != 1)
                    {
                        IfDelete = false;
                    }
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
        public void FillHDGV(IEnumerable<T_Offer> new_data_enum)
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
            DGV_Main.PrimaryGrid.DataMember = "T_Offer";
        }
        public void FillHDGVQ(IQueryable new_data_enum)
        {
            SetReadOnly = true;
            DGV_Main.PrimaryGrid.DataSource = new_data_enum;
            DGV_Main.PrimaryGrid.DataMember = "T_Offer";
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
                FlxInvDet.Rows.Count = FlxInvDet.Rows.Count + VarGeneral.Settings_Sys.LineOfInvoices.Value;
                SetReadOnly = false;
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
        private void textBox_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void FrmInvices_CheckFouce(object sender, EventArgs e)
        {
            if (switchButton_OfferTyp.Value)
            {
                VarGeneral.InvTyp = 1;
            }
            else
            {
                VarGeneral.InvTyp = 0;
            }
        }
        public FrmInvOffer()
        {
            InitializeComponent();this.Load += langloads;
            base.Activated += FrmInvices_CheckFouce;
            textBox_ID.KeyPress += textBox_ID_KeyPress;
            textBox_OfferName.Click += Button_Edit_Click;
            textBox_Type.Click += Button_Edit_Click;
            txtCustName.Click += Button_Edit_Click;
            txtCustNo.Click += Button_Edit_Click;
            txtStartDate.Click += Button_Edit_Click;
            txtEndDate.Click += Button_Edit_Click;
            txtRemark.Click += Button_Edit_Click;
            checkBox_DisVal.Click += Button_Edit_Click;
            checkBox_DisRate.Click += Button_Edit_Click;
            CmbInvPrice.Click += Button_Edit_Click;
            switchButton_OfferTyp.Click += Button_Edit_Click;
            expandableSplitter1.Click += expandableSplitter1_Click;
            ToolStripMenuItem_Det.Click += ToolStripMenuItem_Det_Click;
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
            FlxDat.DoubleClick += FlxDat_DoubleClick;
            FlxDat.KeyDown += FlxDat_KeyDown;
            FlxDat.Leave += FlxDat_Leave;
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
            txtEndDate.Click += txtHDate_Click;
            txtEndDate.Leave += txtHDate_Leave;
            txtStartDate.Click += txtGDate_Click;
            txtStartDate.Leave += txtGDate_Leave;
            button_SrchCustNo.Click += button_SrchCustNo_Click;
            FlxInv.Click += FlxInv_Click;
            FlxInv.AfterEdit += FlxInv_AfterEdit;
            FlxInv.BeforeEdit += FlxInv_BeforeEdit;
            FlxInv.KeyDown += FlxInv_KeyDown;
            FlxInv.RowColChange += FlxInv_RowColChange;
            FlxInv.SelChange += FlxInv_SelChange;
            FlxInv.MouseDown += FlxInv_MouseDown;
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
            {
                FlxInv.Cols[6].Format = VarGeneral.DicimalNN;
                FlxInv.Cols[7].Format = VarGeneral.DicimalNN;
                FlxInv.Cols[8].Format = VarGeneral.DicimalNN;
                FlxInv.Cols[9].Format = VarGeneral.DicimalNN;
                FlxInv.Cols[10].Format = VarGeneral.DicimalNN;
                FlxInvDet.Cols[7].Format = VarGeneral.DicimalNN;
                FlxInvDet.Cols[8].Format = VarGeneral.DicimalNN;
                FlxInvDet.Cols[9].Format = VarGeneral.DicimalNN;
                FlxInvDet.Cols[10].Format = VarGeneral.DicimalNN;
                FlxInvDet.Cols[11].Format = VarGeneral.DicimalNN;
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
            VarGeneral.SFrmTyp = "T_Offer";
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
                case "T_Offer":
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
            data_this = new T_Offer();
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
                    else
                    {
                        if (controls[i].GetType() != typeof(ComboBoxEx))
                        {
                            continue;
                        }
                        try
                        {
                            if (controls[i].Name != "CmbInvPrice")
                            {
                                (controls[i] as ComboBoxEx).SelectedIndex = 0;
                            }
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
                FlxInv.Clear(ClearFlags.Content, 1, 1, FlxInv.Rows.Count - 1, 10);
            }
            if (FlxInvDet.Rows.Count <= 1)
            {
                FlxInvDet.Rows.Count = VarGeneral.Settings_Sys.LineOfInvoices.Value;
            }
            else
            {
                FlxInvDet.Clear(ClearFlags.Content, 1, 1, FlxInvDet.Rows.Count - 1, 16);
            }
            checkBox_DisVal.Checked = true;
            checkBox_DisRate.Checked = false;
            textBox_Usr.Text = ((LangArEn == 0) ? VarGeneral.UserNameA : VarGeneral.UserNameE);
            FillLines();
            SetReadOnly = false;
        }
        private void button_SrchCustNo_Click(object sender, EventArgs e)
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
            VarGeneral.AccTyp = 4;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtCustNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtCustName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
                else
                {
                    txtCustName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
            }
            else
            {
                txtCustNo.Text = "";
                txtCustName.Text = "";
            }
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
                FlxInv.Cols[6].Caption = "السعر";
                FlxInv.Cols[7].Caption = "قيمة الخصم";
                FlxInv.Cols[8].Caption = "السعر الجديد";
                FlxInv.Cols[9].Caption = "من الكمية";
                FlxInv.Cols[10].Caption = "إلى الكمية";
                FlxInvDet.Cols[1].Caption = "رمز الصنف";
                FlxInvDet.Cols[2].Visible = true;
                FlxInvDet.Cols[3].Visible = true;
                FlxInvDet.Cols[4].Visible = false;
                FlxInvDet.Cols[5].Visible = false;
                FlxInvDet.Cols[6].Caption = "مستودع";
                FlxInvDet.Cols[7].Caption = "السعر";
                FlxInvDet.Cols[8].Caption = "قيمة الخصم";
                FlxInvDet.Cols[9].Caption = "السعر الجديد";
                FlxInvDet.Cols[10].Caption = "الكميــة";
                FlxInvDet.Cols[16].Caption = "س.الرئيسي";
                FlxInvDet.Cols[11].Caption = "ضريبة %";
                FlxInvDet.Cols[14].Caption = "تاريخ صلاحية";
                FlxInvDet.Cols[15].Caption = "رقم تصنيع";
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
                FlxInv.Cols[6].Caption = "Price";
                FlxInv.Cols[7].Caption = "Dis Val";
                FlxInv.Cols[8].Caption = "New Price";
                FlxInv.Cols[9].Caption = "From Quantity";
                FlxInv.Cols[10].Caption = "To Quantity";
                FlxInvDet.Cols[1].Caption = "Item Code";
                FlxInvDet.Cols[2].Visible = false;
                FlxInvDet.Cols[3].Visible = false;
                FlxInvDet.Cols[4].Visible = true;
                FlxInvDet.Cols[5].Visible = true;
                FlxInvDet.Cols[6].Caption = "Store";
                FlxInvDet.Cols[7].Caption = "Price";
                FlxInvDet.Cols[8].Caption = "Dis Val";
                FlxInvDet.Cols[9].Caption = "New Price";
                FlxInvDet.Cols[10].Caption = "Quantity";
                FlxInvDet.Cols[16].Caption = "Main Line";
                FlxInvDet.Cols[11].Caption = "Tax %";
                FlxInvDet.Cols[14].Caption = "Expir Date";
                FlxInvDet.Cols[15].Caption = "Make No";
                FlxDat.Cols[0].Caption = "Expir Date";
                FlxDat.Cols[1].Caption = "Quantity";
                FlxDat.Cols[2].Caption = "Make No";
            }
            if (!switchButton_OfferTyp.Value)
            {
                FlxInv.Cols[6].Visible = true;
                FlxInv.Cols[7].Visible = true;
                FlxInv.Cols[8].Visible = true;
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
                controls.Add(txtCustName);
                controls.Add(txtCustNo);
                controls.Add(txtStartDate);
                controls.Add(txtEndDate);
                controls.Add(txtRemark);
                controls.Add(checkBox_DisVal);
                controls.Add(checkBox_DisRate);
                controls.Add(textBox_OfferName);
                controls.Add(CmbInvPrice);
                controls.Add(switchButton_OfferTyp);
                controls.Add(textBox_Usr);
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
            if (data_this != null && !(data_this.OfferHeadNo == 0.ToString()) && ifOkDelete)
            {
                data_this = db.StockOffer(VarGeneral.InvTyp, DataThis.OfferHeadNo);
                try
                {
                    db.ExecuteCommand("DELETE FROM [dbo].[T_OfferQFree] WHERE OfferIDQ =" + DataThis.OfferHeadID);
                    db.ExecuteCommand("DELETE FROM [dbo].[T_OfferDet] WHERE OfferID =" + DataThis.OfferHeadID);
                    db.T_Offers.DeleteOnSubmit(DataThis);
                    db.SubmitChanges();
                }
                catch (SqlException)
                {
                    data_this = db.StockOffer(VarGeneral.InvTyp, DataThis.OfferHeadNo);
                    return;
                }
                catch (Exception)
                {
                    data_this = db.StockOffer(VarGeneral.InvTyp, DataThis.OfferHeadNo);
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
                MaskedTextBox maskedTextBox = txtStartDate;
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                maskedTextBox.Text = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
                GetInvSetting();
                textBox_ID.Text = db.MaxOfferNo.ToString();
                FlxInv.Rows.Count = VarGeneral.Settings_Sys.LineOfInvoices.Value;
                FlxInvDet.Rows.Count = VarGeneral.Settings_Sys.LineOfInvoices.Value;
                State = FormState.New;
                try
                {
                    base.ActiveControl = FlxInv;
                    FlxInv.Row = 1;
                    FlxInv.Col = 1;
                }
                catch
                {
                }
            }
        }
        public void RefreshPKeys()
        {
            PKeys.Clear();
            try
            {
                PKeys = db.ExecuteQuery<string>("select OfferHeadNo from T_Offer where OfferHeadTyp =" + (switchButton_OfferTyp.Value ? 1 : 0), new object[0]).ToList();
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
            List<T_Offer> list = db.FillInvOffer_2(VarGeneral.InvTyp, textBox_search.TextBox.Text).ToList();
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmInvOffer));
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
                DGV_Main.PrimaryGrid.GroupByRow.Text = "جميع السجلات";
                checkBox_DisVal.Text = "قيمـــة";
                checkBox_DisRate.Text = "نسبـــة";
                switchButton_OfferTyp.OffText = "تخفيض الأسعـــار";
                switchButton_OfferTyp.OnText = "كميــات مجــانيـة";
                txtRemark.ButtonCustom.Text = "ملاحظــة";
                groupBox5.Text = "طريقة الخصم";
                Text = "العــروض الخـــاصة";
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
                DGV_Main.PrimaryGrid.GroupByRow.Text = "All Records";
                checkBox_DisVal.Text = "Value";
                checkBox_DisRate.Text = "Rate";
                switchButton_OfferTyp.OffText = "Low prices";
                switchButton_OfferTyp.OnText = "Free quantities";
                txtRemark.ButtonCustom.Text = "Note";
                groupBox5.Text = "Discound Method";
                Text = "Spicial Offers";
            }
        }
        private void _ownerDraw(object sender, OwnerDrawCellEventArgs e)
        {
            if (e.Col == 0 && e.Row > 0)
            {
                e.Text = e.Row.ToString();
            }
        }
        private void FrmInvOffer_Load(object sender, EventArgs e)
        {
            try
            {
                Location = Frm_Main.loc;
                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 85))
            {
               //switchButton_Lock.Visible = false;
            }
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmInvOffer));
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
                    columns_Names_visible.Add("OfferHeadNo", new ColumnDictinary("رقم العــرض", "offer No", ifDefault: true, ""));
                    columns_Names_visible.Add("OfferHeadName", new ColumnDictinary("إسم العرض", "Offer Name", ifDefault: true, ""));
                    columns_Names_visible.Add("OfferSalsManNo", new ColumnDictinary("رقم البائع", "SalsMan No", ifDefault: false, ""));
                    columns_Names_visible.Add("EndDat", new ColumnDictinary("تاريخ البداية", "Start Date", ifDefault: true, ""));
                    columns_Names_visible.Add("StartDat", new ColumnDictinary("تاريخ النهاية", "End Date", ifDefault: true, ""));
                }
                else
                {
                    Clear();
                    textBox_ID.Text = "";
                    TextBox_Index.TextBox.Text = "";
                }
                VarGeneral.InvTyp = 0;
                MainProcess();
                string Co = "";
                for (int iiCnt = 0; iiCnt < listStore.Count; iiCnt++)
                {
                    _Store = listStore[iiCnt];
                    Co = ((!(Co != "")) ? _Store.Stor_ID.ToString() : (Co + "|" + _Store.Stor_ID));
                }
                FlxInvDet.Cols[6].ComboList = Co;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            FlxInv.DrawMode = DrawModeEnum.OwnerDraw;
            FlxInv.OwnerDrawCell += _ownerDraw;
        }
        private void MainProcess()
        {
            FillCombo();
            GetInvSetting();
            ArbEng();
            RefreshPKeys();
            textBox_ID.Text = PKeys.FirstOrDefault();
            listUnit = new List<T_Unit>();
            listUnit = db.FillUnit_2("").ToList();
            listStore = db.FillStore_2("").ToList();
            UpdateVcr();
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
                var q = db.StockOffer(VarGeneral.InvTyp, crow.Cells["OfferHeadNo"].Value.ToString()).T_OfferDets.Select((T_OfferDet item) => new
                {
                    ItmNo = item.ItmNo,
                    Arb_Des = item.T_Item.Arb_Des,
                    Eng_Des = item.T_Item.Eng_Des,
                    UntNm_A = item.T_Unit.Arb_Des,
                    UntNm_E = item.T_Unit.Eng_Des,
                    Price = item.Price,
                    DisVal = item.DisVal,
                    UnitPriVal = item.UnitPriVal
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
            panel.Columns["OfferHeadNo"].Width = 150;
            panel.Columns["OfferHeadNo"].Visible = columns_Names_visible["OfferHeadNo"].IfDefault;
            panel.Columns["OfferHeadName"].Width = 200;
            panel.Columns["OfferHeadName"].Visible = columns_Names_visible["OfferHeadName"].IfDefault;
            panel.Columns["OfferSalsManNo"].Width = 100;
            panel.Columns["OfferSalsManNo"].Visible = columns_Names_visible["OfferSalsManNo"].IfDefault;
            panel.Columns["EndDat"].Width = 100;
            panel.Columns["EndDat"].Visible = columns_Names_visible["EndDat"].IfDefault;
            panel.Columns["StartDat"].Width = 100;
            panel.Columns["StartDat"].Visible = columns_Names_visible["StartDat"].IfDefault;
        }
        private void PropLOfferPanel(GridPanel panel)
        {
            panel.ColumnAutoSizeMode = ColumnAutoSizeMode.DisplayedCells;
            panel.Columns["ItmNo"].HeaderText = ((LangArEn == 0) ? "رقم الصنف" : "Item No");
            panel.Columns["Arb_Des"].HeaderText = ((LangArEn == 0) ? "الوصف " : "Description");
            panel.Columns["Eng_Des"].HeaderText = ((LangArEn == 0) ? "الوصف" : "Description");
            panel.Columns["UntNm_A"].HeaderText = ((LangArEn == 0) ? "الوحدة" : "Unit");
            panel.Columns["UntNm_E"].HeaderText = ((LangArEn == 0) ? "الوحدة" : "Unit");
            panel.Columns["Price"].HeaderText = ((LangArEn == 0) ? "السعر" : "Price");
            panel.Columns["DisVal"].HeaderText = ((LangArEn == 0) ? "الخصم" : "Discount");
            panel.Columns["UnitPriVal"].HeaderText = ((LangArEn == 0) ? "السعر الجديد" : "New Pric");
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
                panel.Columns["Eng_Des"].Visible = false;
                panel.Columns["UntNm_E"].Visible = false;
                panel.Columns["Arb_Des"].Visible = true;
                panel.Columns["UntNm_A"].Visible = true;
            }
            else
            {
                panel.Columns["Arb_Des"].Visible = false;
                panel.Columns["UntNm_A"].Visible = false;
                panel.Columns["Eng_Des"].Visible = true;
                panel.Columns["UntNm_E"].Visible = true;
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
                    TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(data_this.OfferHeadNo ?? "") + 1);
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
            _InvSetting = db.StockInvSetting(VarGeneral.UserID, 1);
            _SysSetting = db.SystemSettingStock();
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
                T_Offer newData = db.StockOffer(VarGeneral.InvTyp, no);
                if (newData == null || string.IsNullOrEmpty(newData.OfferHeadNo))
                {
                    if (!Button_Add.Visible || !Button_Add.Enabled)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textBox_ID.TextChanged -= textBox_ID_TextChanged;
                        try
                        {
                            textBox_ID.Text = data_this.OfferHeadNo;
                        }
                        catch
                        {
                        }
                        textBox_ID.TextChanged += textBox_ID_TextChanged;
                        return;
                    }
                    Clear();
                    FlxInv.Rows.Count = VarGeneral.Settings_Sys.LineOfInvoices.Value;
                    FlxInvDet.Rows.Count = VarGeneral.Settings_Sys.LineOfInvoices.Value;
                    State = FormState.New;
                    TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                    TextBox_Index.TextBox.Text = string.Concat(PKeys.Count + 1);
                    TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                }
                else
                {
                    DataThis = newData;
                    int indexA = PKeys.IndexOf(newData.OfferHeadNo ?? "");
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
                txtEndDate.Text = Convert.ToDateTime(txtEndDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                txtEndDate.Text = "";
            }
        }
        private void txtGDate_Leave(object sender, EventArgs e)
        {
            try
            {
                txtStartDate.Text = Convert.ToDateTime(txtStartDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                txtStartDate.Text = "";
            }
        }
        private void txtGDate_Click(object sender, EventArgs e)
        {
            txtStartDate.SelectAll();
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
            else if (e.KeyCode == Keys.F9)
            {
                try
                {
                    PrintDocument prnt_doc = new PrintDocument();
                    T_INVSETTING _InvSetting = new T_INVSETTING();
                    _InvSetting = db.StockInvSetting(VarGeneral.UserID, VarGeneral.InvTyp);
                    string _PrinterName = prnt_doc.PrinterSettings.PrinterName;
                    try
                    {
                        prnt_doc.PrinterSettings.PrinterName = _InvSetting.InvpRINTERInfo.defPrn;
                        if (prnt_doc.PrinterSettings.IsValid)
                        {
                            _PrinterName = _InvSetting.defPrn;
                        }
                    }
                    catch
                    {
                    }
                    CashDrawer.OpenDrawer(_PrinterName);
                }
                catch (Exception error)
                {
                    try
                    {
                        VarGeneral.DebLog.writeLog("button_openCasheir_Click:", error, enable: true);
                    }
                    catch
                    {
                    }
                }
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
        private void txtHDate_Click(object sender, EventArgs e)
        {
            txtEndDate.SelectAll();
        }
        private void FlxInv_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
        }
        private void FillCombo()
        {
            CmbInvPrice.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                CmbInvPrice.Items.Add("الأفتراضي");
                CmbInvPrice.Items.Add("سعر الجملة");
                CmbInvPrice.Items.Add("سعر الموزع");
                CmbInvPrice.Items.Add("سعر المندوب");
                CmbInvPrice.Items.Add("سعر التجزئة");
                CmbInvPrice.Items.Add("سعر آخر");
            }
            else
            {
                CmbInvPrice.Items.Add("Default");
                CmbInvPrice.Items.Add("Wholesale price");
                CmbInvPrice.Items.Add("Distributor price");
                CmbInvPrice.Items.Add("Legates Price");
                CmbInvPrice.Items.Add("Retail price");
                CmbInvPrice.Items.Add("Other price");
            }
            CmbInvPrice.SelectedIndex = 0;
        }
        public void SetData(T_Offer value)
        {
            switchButton_OfferTyp.ValueChanged -= switchButton_OfferTyp_ValueChanged;
            try
            {
                State = FormState.Saved;
                Button_Save.Enabled = false;
                textBox_OfferName.Text = value.OfferHeadName;
                textBox_ID.Tag = value.OfferHeadID;
                try
                {
                    if (VarGeneral.CheckDate(value.StartDat))
                    {
                        txtStartDate.Text = Convert.ToDateTime(value.StartDat).ToString("yyyy/MM/dd");
                    }
                }
                catch
                {
                    txtStartDate.Text = value.StartDat;
                }
                try
                {
                    if (VarGeneral.CheckDate(value.EndDat))
                    {
                        txtEndDate.Text = Convert.ToDateTime(value.EndDat).ToString("yyyy/MM/dd");
                    }
                }
                catch
                {
                    txtEndDate.Text = value.EndDat;
                }
                txtCustNo.Text = value.CusVenNo.ToString();
                try
                {
                    if (!string.IsNullOrEmpty(value.CusVenNo))
                    {
                        txtCustName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(value.CusVenNo).Arb_Des : db.StockAccDefWithOutBalance(value.CusVenNo).Eng_Des);
                    }
                    else
                    {
                        txtCustName.Text = "";
                    }
                }
                catch
                {
                    txtCustName.Text = "";
                }
                if (VarGeneral.SSSLev == "M")
                {
                    txtCustNo.Text = "";
                }
                txtRemark.Text = value.OfferRemark;
                textBox_Usr.Text = ((LangArEn == 0) ? dbc.RateUsr(value.OfferSalsManNo).UsrNamA : dbc.RateUsr(value.OfferSalsManNo).UsrNamE);
                if (value.CustPri.HasValue)
                {
                    CmbInvPrice.SelectedIndex = value.CustPri.Value;
                }
                switchButton_OfferTyp.Value = ((value.OfferHeadTyp.Value == 1) ? true : false);
                if (value.OfferHeadCashCredit.HasValue)
                {
                    int? offerHeadCashCredit = value.OfferHeadCashCredit;
                    if (offerHeadCashCredit.Value == 0 && offerHeadCashCredit.HasValue)
                    {
                        checkBox_DisVal.Checked = true;
                    }
                    else if (value.OfferHeadCashCredit == 1)
                    {
                        checkBox_DisRate.Checked = true;
                    }
                }
                LDataThis = new BindingList<T_OfferDet>(value.T_OfferDets).ToList();
                SetLines(LDataThis);
                if (switchButton_OfferTyp.Value)
                {
                    LDataThisQFree = new BindingList<T_OfferQFree>(value.T_OfferQFrees).ToList();
                    SetLinesQFree(LDataThisQFree);
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SetData:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            switchButton_OfferTyp.ValueChanged += switchButton_OfferTyp_ValueChanged;
        }
        public void SetLines(List<T_OfferDet> listDet)
        {
            try
            {
                FlxInv.Rows.Count = listDet.Count + 1;
                for (int iiCnt = 1; iiCnt <= listDet.Count; iiCnt++)
                {
                    _InvDet = listDet[iiCnt - 1];
                    int Ser = _InvDet.OfferDetSer.GetValueOrDefault();
                    FlxInv.SetData(iiCnt, 0, Ser.ToString());
                    FlxInv.SetData(iiCnt, 1, _InvDet.ItmNo.Trim());
                    FlxInv.SetData(iiCnt, 2, _InvDet.T_Item.Arb_Des.ToString());
                    FlxInv.SetData(iiCnt, 3, _InvDet.T_Unit.Arb_Des.ToString());
                    FlxInv.SetData(iiCnt, 4, _InvDet.T_Item.Eng_Des.ToString());
                    FlxInv.SetData(iiCnt, 5, _InvDet.T_Unit.Eng_Des.ToString());
                    FlxInv.SetData(iiCnt, 6, _InvDet.Price.Value);
                    FlxInv.SetData(iiCnt, 7, _InvDet.DisVal.Value);
                    FlxInv.SetData(iiCnt, 8, _InvDet.UnitPriVal.Value);
                    FlxInv.SetData(iiCnt, 9, _InvDet.Qty.Value);
                    FlxInv.SetData(iiCnt, 10, _InvDet.QtyTo.Value);
                }
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? "حدث خطأ أثناء تعبئة الأسطر .." : "An error occurred while filling lines ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        public void SetLinesQFree(List<T_OfferQFree> listDet)
        {
            try
            {
                FillLines();
                FlxInvDet.Rows.Count = listDet.Count + 1;
                for (int iiCnt = 1; iiCnt <= listDet.Count; iiCnt++)
                {
                    _InvDetQFree = listDet[iiCnt - 1];
                    int Ser = _InvDetQFree.OfferQFreeSer.GetValueOrDefault();
                    FlxInvDet.SetData(iiCnt, 0, Ser.ToString());
                    FlxInvDet.SetData(iiCnt, 1, _InvDetQFree.OfferQFreeItmNo.Trim());
                    FlxInvDet.SetData(iiCnt, 2, _InvDetQFree.T_Item.Arb_Des.ToString());
                    FlxInvDet.SetData(iiCnt, 3, _InvDetQFree.T_Unit.Arb_Des.ToString());
                    FlxInvDet.SetData(iiCnt, 4, _InvDetQFree.T_Item.Eng_Des.ToString());
                    FlxInvDet.SetData(iiCnt, 5, _InvDetQFree.T_Unit.Eng_Des.ToString());
                    FlxInvDet.SetData(iiCnt, 6, _InvDetQFree.OfferQFreeStoreNo.Value);
                    FlxInvDet.SetData(iiCnt, 7, _InvDetQFree.OfferQFreePrice.Value);
                    FlxInvDet.SetData(iiCnt, 8, _InvDetQFree.OfferQFreeDisVal.Value);
                    FlxInvDet.SetData(iiCnt, 9, _InvDetQFree.OfferQFreeUnitPriVal.Value);
                    FlxInvDet.SetData(iiCnt, 10, _InvDetQFree.OfferQFreeQty.Value);
                    FlxInvDet.SetData(iiCnt, 16, LDataThis.Where((T_OfferDet g) => g.OfferDet_ID == _InvDetQFree.OfferQFreeID).FirstOrDefault().OfferDetSer);
                    FlxInvDet.SetData(iiCnt, 12, LDataThis.Where((T_OfferDet g) => g.OfferDet_ID == _InvDetQFree.OfferQFreeID).FirstOrDefault().ItmNo);
                    FlxInvDet.SetData(iiCnt, 13, LDataThis.Where((T_OfferDet g) => g.OfferDet_ID == _InvDetQFree.OfferQFreeID).FirstOrDefault().T_Unit.Arb_Des);
                    FlxInvDet.SetData(iiCnt, 14, _InvDetQFree.OfferQFreeDatExper);
                    FlxInvDet.SetData(iiCnt, 15, _InvDetQFree.OfferQFreeRunCod);
                    FlxInvDet.SetData(iiCnt, 11, _InvDetQFree.OfferQFreeItmTax.Value);
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
                MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ بدون رقم العــرض - السند" : "Can not save without the offer number", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_ID.Focus();
                return false;
            }
            for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
            {
                if (!(string.Concat(FlxInv.GetData(iiCnt, 1)) != ""))
                {
                    continue;
                }
                for (int i = 1; i < 9; i++)
                {
                    if ((!switchButton_OfferTyp.Value || i != 9) && (switchButton_OfferTyp.Value || (i != 6 && i != 7 && i != 8)) && string.Concat(FlxInv.GetData(iiCnt, i)) == "")
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من تعبئة جميع البيانات المطلوبة" : "We must not be empty value .. Please make sure there are items in the bill.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        FlxInv.Row = iiCnt;
                        FlxInv.Col = i;
                        FlxInv.Focus();
                        return false;
                    }
                }
                if (!switchButton_OfferTyp.Value)
                {
                    if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7))).ToString()) <= 0.0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من صحة قيمة الخصم" : "Please confirm discount value are correct", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        FlxInv.Row = iiCnt;
                        FlxInv.Col = 7;
                        FlxInv.Focus();
                        return false;
                    }
                    if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8))).ToString()) < 0.0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من صحة الأسعار الجديدة" : "Please confirm new prices are correct", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        FlxInv.Row = iiCnt;
                        FlxInv.Col = 8;
                        FlxInv.Focus();
                        return false;
                    }
                }
                if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 9))).ToString()) <= 0.0)
                {
                    MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من صحة الكمية" : "Please confirm Quantity are correct", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    FlxInv.Row = iiCnt;
                    FlxInv.Col = 9;
                    FlxInv.Focus();
                    return false;
                }
                for (int c = 1; c < FlxInv.Rows.Count; c++)
                {
                    try
                    {
                        if (string.Concat(FlxInv.GetData(c, 1)) != "" && !string.IsNullOrEmpty(string.Concat(FlxInv.GetData(c, 1))) && c != iiCnt && FlxInv.GetData(c, 1).ToString() == FlxInv.GetData(iiCnt, 1).ToString() && FlxInv.GetData(c, 3).ToString() == FlxInv.GetData(iiCnt, 3).ToString())
                        {
                            MessageBox.Show((LangArEn == 0) ? "يجب عدم تكرار الصنف أكثر من مرة .. يرجى التأكد من السطور والمحاولة مجددا" : "The category should not be repeated more than once .. Please specify the lines and try again", VarGeneral.ProdectNam);
                            return false;
                        }
                    }
                    catch
                    {
                    }
                }
                if (!switchButton_OfferTyp.Value)
                {
                    continue;
                }
                for (int j = 1; j < FlxInvDet.Rows.Count; j++)
                {
                    if (j >= FlxInvDet.Rows.Count - 1)
                    {
                        MessageBox.Show((LangArEn == 0) ? "هناك اصناف لم يتم ربطها بأصناف أخرى ككميات مجانية .. يرجى التاكد من صحة الإدخال والمحاولة مجددا" : "There are varieties that are not matched by other varieties free quantities .. Please check the validity of the assistant and try again", VarGeneral.ProdectNam);
                        return false;
                    }
                    try
                    {
                        if (string.Concat(FlxInvDet.GetData(j, 1)) != "")
                        {
                            string xx = FlxInvDet.GetData(j, 16).ToString();
                            string xxxx = iiCnt.ToString();
                            if (FlxInvDet.GetData(j, 16).ToString() == iiCnt.ToString())
                            {
                                goto IL_052c;
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            IL_052c:;
            }
            for (int iiCnt = 1; iiCnt < FlxInvDet.Rows.Count; iiCnt++)
            {
                if (!(string.Concat(FlxInvDet.GetData(iiCnt, 1)) != ""))
                {
                    continue;
                }
                for (int i = 1; i < 17; i++)
                {
                    if (i != 14 && i != 15 && i != 6 && string.Concat(FlxInvDet.GetData(iiCnt, i)) == "")
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من تعبئة جميع البيانات المطلوبة" : "We must not be empty value .. Please make sure there are items in the bill.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        FlxInvDet.Row = iiCnt;
                        FlxInvDet.Col = i;
                        FlxInvDet.Focus();
                        return false;
                    }
                }
                if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(iiCnt, 9))).ToString()) < 0.0)
                {
                    MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من صحة الأسعار الجديدة" : "Please confirm new prices are correct", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    FlxInvDet.Row = iiCnt;
                    FlxInvDet.Col = 9;
                    FlxInvDet.Focus();
                    return false;
                }
                if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(iiCnt, 10))).ToString()) <= 0.0)
                {
                    MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من صحة الكمية" : "Please confirm Quantity are correct", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    FlxInvDet.Row = iiCnt;
                    FlxInvDet.Col = 10;
                    FlxInvDet.Focus();
                    return false;
                }
                for (int j = 1; j < FlxInv.Rows.Count; j++)
                {
                    if (j >= FlxInv.Rows.Count - 1)
                    {
                        MessageBox.Show((LangArEn == 0) ? "هناك اصناف لم يتم ربطها بأصناف أخرى ككميات مجانية .. يرجى التاكد من صحة الإدخال والمحاولة مجددا" : "There are varieties that are not matched by other varieties free quantities .. Please check the validity of the assistant and try again", VarGeneral.ProdectNam);
                        return false;
                    }
                    try
                    {
                        if (string.Concat(FlxInv.GetData(j, 1)) != "")
                        {
                            int xx2 = j;
                            string xxxx = FlxInvDet.GetData(iiCnt, 16).ToString();
                            if (j.ToString() == FlxInvDet.GetData(iiCnt, 16).ToString())
                            {
                                goto IL_082e;
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            IL_082e:;
            }
            if (State == FormState.Edit)
            {
                T_Offer newData = db.StockOffer(VarGeneral.InvTyp, textBox_ID.Text);
                if ((!string.IsNullOrEmpty(newData.OfferHeadNo) || newData.OfferHeadID > 0) && newData.OfferHeadID != data_this.OfferHeadID)
                {
                    MessageBox.Show((LangArEn == 0) ? " رقم العــرض مكرر يرجى تغييره" : "Employee No It's a existing", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_ID.Focus();
                    return false;
                }
            }
            if (!VarGeneral.CheckDate(txtStartDate.Text))
            {
                MessageBox.Show((LangArEn == 0) ? " يرجى التاكد من صحة تاريخ البداية" : "Please make sure the date is correct", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtStartDate.Focus();
                return false;
            }
            if (!VarGeneral.CheckDate(txtEndDate.Text))
            {
                MessageBox.Show((LangArEn == 0) ? " يرجى التاكد من صحة تاريخ النهاية" : "Please make sure the date is correct", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtEndDate.Focus();
                return false;
            }
            if (Convert.ToDateTime(txtEndDate.Text) < Convert.ToDateTime(txtStartDate.Text))
            {
                MessageBox.Show((LangArEn == 0) ? "تأكد من صحة تاريخ البداية والنهاية " : "Start Date and End Date is Uncorrecte", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtEndDate.Text = "";
                txtStartDate.Focus();
                return false;
            }
            return true;
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
            IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
            try
            {
                GetData();
                if (State == FormState.New)
                {
                    try
                    {
                        GetInvSetting();
                        textBox_ID.TextChanged -= textBox_ID_TextChanged;
                        T_Offer newData = db.StockOffer(VarGeneral.InvTyp, data_this.OfferHeadNo);
                        if (!string.IsNullOrEmpty(newData.OfferHeadNo) || newData.OfferHeadID > 0)
                        {
                            string max = "";
                            dbInstance = null;
                            max = db.MaxOfferNo.ToString();
                            MessageBox.Show("الرمز مستخدم من قبل.\n سيتم الحفظ برقم جديد [" + max + "]", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            textBox_ID.Text = max ?? "";
                            data_this.OfferHeadNo = max ?? "";
                        }
                        textBox_ID.TextChanged += textBox_ID_TextChanged;
                        data_this.OfferSalsManNo = VarGeneral.UserNumber;
                        db.T_Offers.InsertOnSubmit(data_this);
                        db.SubmitChanges();
                    }
                    catch (SqlException ex2)
                    {
                        try
                        {
                            VarGeneral.DebLog.writeLog("SaveData:", ex2, enable: true);
                        }
                        catch
                        {
                        }
                        string max = "";
                        dbInstance = null;
                        max = db.MaxOfferNo.ToString();
                        if (ex2.Number == 2627)
                        {
                            MessageBox.Show("الرمز مستخدم من قبل.\n سيتم الحفظ برقم جديد [" + max + "]", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            textBox_ID.Text = max ?? "";
                            data_this.OfferHeadNo = max ?? "";
                            Button_Save_Click(null, null);
                        }
                    }
                    catch (Exception ex3)
                    {
                        try
                        {
                            VarGeneral.DebLog.writeLog("SaveData2:", ex3, enable: true);
                        }
                        catch
                        {
                        }
                        return false;
                    }
                }
                else
                {
                    db.ExecuteCommand("DELETE FROM [dbo].[T_OfferQFree] WHERE OfferIDQ =" + DataThis.OfferHeadID);
                    db.ExecuteCommand("DELETE FROM [dbo].[T_OfferDet] WHERE OfferID =" + DataThis.OfferHeadID);
                    db.Log = VarGeneral.DebugLog;
                    db.SubmitChanges(ConflictMode.ContinueOnConflict);
                }
                int iiCnt = 0;
                int seqID = 1;
                int seqIDQFree = 1;
                int i;
                for (iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
                {
                    if (FlxInv.GetData(iiCnt, 1) == null)
                    {
                        continue;
                    }
                    T_OfferDet _data = new T_OfferDet();
                    _data.DisVal = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7))));
                    _data.ItmNo = FlxInv.GetData(iiCnt, 1).ToString();
                    _data.ItmUnt = db.T_Units.Where((T_Unit t) => t.Arb_Des == FlxInv.GetData(iiCnt, 3).ToString()).ToList().FirstOrDefault()
                        .Unit_ID;
                    _data.OfferDetNo = textBox_ID.Text.Trim();
                    _data.OfferDetSer = seqID;
                    _data.OfferID = data_this.OfferHeadID;
                    _data.Price = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 6))));
                    _data.UnitPriVal = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8))));
                    try
                    {
                        _data.Qty = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 9))));
                    }
                    catch
                    {
                        _data.Qty = 1.0;
                    }
                    if (_data.Qty.Value <= 0.0)
                    {
                        _data.Qty = 1.0;
                    }
                    try
                    {
                        _data.QtyTo = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 10))));
                    }
                    catch
                    {
                        _data.QtyTo = 0.0;
                    }
                    if (_data.QtyTo.Value < 0.0)
                    {
                        _data.QtyTo = 0.0;
                    }
                    if (_data.QtyTo < _data.Qty)
                    {
                        _data.QtyTo = 0.0;
                    }
                    db.T_OfferDets.InsertOnSubmit(_data);
                    db.SubmitChanges();
                    seqID++;
                    if (!switchButton_OfferTyp.Value)
                    {
                        continue;
                    }
                    i = 1;
                    while (true)
                    {
                        if (i >= FlxInvDet.Rows.Count)
                        {
                            break;
                        }
                        if (FlxInvDet.GetData(i, 1) != null && FlxInvDet.GetData(i, 16) != null && FlxInvDet.GetData(i, 12).ToString() == _data.ItmNo && db.T_Units.Where((T_Unit t) => t.Arb_Des == FlxInvDet.GetData(iiCnt, 13).ToString()).ToList().FirstOrDefault()
                            .Unit_ID == _data.ItmUnt.Value)
                        {
                            T_OfferQFree _dataQFree = new T_OfferQFree();
                            _dataQFree.OfferQFreeDisVal = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(i, 8))));
                            _dataQFree.OfferQFreeItmNo = FlxInvDet.GetData(i, 1).ToString();
                            _dataQFree.OfferQFreeItmUnt = db.T_Units.Where((T_Unit t) => t.Arb_Des == FlxInvDet.GetData(i, 3).ToString()).ToList().FirstOrDefault()
                                .Unit_ID;
                            _dataQFree.OfferQFreeNo = textBox_ID.Text.Trim();
                            _dataQFree.OfferQFreeSer = seqIDQFree;
                            _dataQFree.OfferQFreeID = _data.OfferDet_ID;
                            _dataQFree.OfferQFreeStoreNo = int.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(i, 6))));
                            _dataQFree.OfferQFreePrice = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(i, 7))));
                            _dataQFree.OfferQFreeUnitPriVal = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(i, 9))));
                            _dataQFree.OfferQFreeQty = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(i, 10))));
                            _dataQFree.OfferQFreeItmTax = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(i, 11))));
                            _dataQFree.OfferQFreeDatExper = FlxInvDet.GetData(i, 14).ToString();
                            _dataQFree.OfferQFreeRunCod = FlxInvDet.GetData(i, 15).ToString();
                            _dataQFree.OfferIDQ = data_this.OfferHeadID;
                            db.T_OfferQFrees.InsertOnSubmit(_dataQFree);
                            db.SubmitChanges();
                            seqIDQFree++;
                        }
                        i++;
                    }
                }
                MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex3)
            {
                VarGeneral.DebLog.writeLog("MainSaveData:", ex3, enable: true);
                MessageBox.Show(ex3.Message);
                return false;
            }
            return true;
        }
        private T_Offer GetData()
        {
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
            data_this.OfferHeadTyp = (switchButton_OfferTyp.Value ? 1 : 0);
            data_this.CusVenNo = txtCustNo.Text;
            data_this.OfferRemark = txtRemark.Text;
            data_this.OfferHeadNo = textBox_ID.Text;
            data_this.EndDat = txtEndDate.Text;
            data_this.StartDat = txtStartDate.Text;
            data_this.OfferHeadName = textBox_OfferName.Text;
            try
            {
                if (checkBox_DisVal.Checked)
                {
                    data_this.OfferHeadCashCredit = 0;
                }
                else if (checkBox_DisRate.Checked)
                {
                    data_this.OfferHeadCashCredit = 1;
                }
                else
                {
                    data_this.OfferHeadCashCredit = 3;
                }
            }
            catch
            {
                data_this.OfferHeadCashCredit = 3;
            }
            return data_this;
        }
        private void FlxInv_AfterEdit(object sender, RowColEventArgs e)
        {
            double ItmDis = 0.0;
            try
            {
                if (checkBox_DisRate.Checked && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) > 0.0)
                {
                    ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 6)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) / 100.0);
                }
            }
            catch
            {
            }
            if (e.Col == 1)
            {
                BindDataOfItem();
            }
            else if (((e.Col == 2 || e.Col == 4) && (string)FlxInv.GetData(e.Row, 1) == "") || FlxInv.GetData(e.Row, 1) == null)
            {
                BindDataOfItem();
            }
            else if ((e.Col == 3 || e.Col == 5) && FlxInv.GetData(e.Row, e.Col).ToString() != oldUnit)
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
                        FlxInv.SetData(FlxInv.Row, 6, _Items.UntPri1);
                        break;
                    case 2:
                        FlxInv.SetData(FlxInv.Row, 6, _Items.UntPri2);
                        break;
                    case 3:
                        FlxInv.SetData(FlxInv.Row, 6, _Items.UntPri3);
                        break;
                    case 4:
                        FlxInv.SetData(FlxInv.Row, 6, _Items.UntPri4);
                        break;
                    case 5:
                        FlxInv.SetData(FlxInv.Row, 6, _Items.UntPri5);
                        break;
                }
                Pack = ItemIndex;
                BindDataofItemPrice();
                FlxInv.SetData(e.Row, 8, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 6)))) - (checkBox_DisVal.Checked ? double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) : ItmDis));
            }
            else if (e.Col == 7)
            {
                FlxInv.SetData(e.Row, 8, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 6)))) - (checkBox_DisVal.Checked ? double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) : ItmDis));
            }
        }
        private void FillLines()
        {
            string Co = " ";
            for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
            {
                if (string.Concat(FlxInv.GetData(iiCnt, 1)) != "")
                {
                    Co = ((!(Co != "")) ? iiCnt.ToString() : (Co + "|" + iiCnt));
                }
            }
            FlxInvDet.Cols[16].ComboList = Co;
        }
        private void FlxInv_BeforeEdit(object sender, RowColEventArgs e)
        {
            try
            {
                if ((e.Col == 3 || e.Col == 5) && FlxInv.GetData(e.Row, e.Col) != null)
                {
                    oldUnit = FlxInv.GetData(e.Row, 3).ToString() ?? "";
                }
            }
            catch
            {
            }
        }
        private void FlxInv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
            {
                return;
            }
            try
            {
                if (FlxInv.GetData(RowSel, 1).ToString() != null)
                {
                    FlxInv.RemoveItem(FlxInv.Row);
                }
            }
            catch
            {
                FlxInv.RemoveItem(FlxInv.Row);
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
            }
            catch
            {
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
                    }
                }
                catch
                {
                }
                if (string.Concat(FlxInv.GetData(FlxInv.RowSel, 1)) != "")
                {
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
                }
            }
            catch
            {
            }
            FillLines();
        }
        private void BindDataOfItem()
        {
            if (!base.Visible)
            {
                return;
            }
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
                _RepShow.Rule = " Where 1 = 1 and T_Items.ItmTyp != 1 and InvSaleStoped = 0 ";
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
                                  where t.ItmTyp != (int?)1 && !t.InvSaleStoped.Value
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
                VarGeneral.vItmTyp = 1;
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
                    _RepShow.Rule = " Where 1 = 1 and T_Items.ItmTyp != 1 and InvSaleStoped = 0";
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
                                      where t.ItmTyp != (int?)1 && !t.InvSaleStoped.Value
                                      orderby t.Itm_No
                                      select t).ToList();
                    if (q.Count == 0)
                    {
                        return;
                    }
                    FrmSearch FmSerch = new FrmSearch();
                    VarGeneral.SFrmTyp = "T_InvGrid";
                    VarGeneral.vItmTyp = 1;
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
            double ItmDis = 0.0;
            FlxInv.SetData(FlxInv.Row, 1, _Items.Itm_No.Trim());
            FlxInv.SetData(FlxInv.Row, 2, _Items.Arb_Des.Trim());
            FlxInv.SetData(FlxInv.Row, 4, _Items.Eng_Des.Trim());
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
                        FlxInv.SetData(FlxInv.Row, 6, _Items.UntPri1.Value);
                    }
                    else if (DefPack == 1)
                    {
                        Pack = _Items.Pack1.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 6, _Items.UntPri1.Value);
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
                        FlxInv.SetData(FlxInv.Row, 6, _Items.UntPri2.Value);
                    }
                    else if (DefPack == 2)
                    {
                        Pack = _Items.Pack2.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 6, _Items.UntPri2.Value);
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
                        FlxInv.SetData(FlxInv.Row, 6, _Items.UntPri3.Value);
                    }
                    else if (DefPack == 3)
                    {
                        Pack = _Items.Pack3.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 6, _Items.UntPri3.Value);
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
                        FlxInv.SetData(FlxInv.Row, 6, _Items.UntPri4.Value);
                    }
                    else if (DefPack == 4)
                    {
                        Pack = _Items.Pack4.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 6, _Items.UntPri4.Value);
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
                        FlxInv.SetData(FlxInv.Row, 6, _Items.UntPri5.Value);
                    }
                    else if (DefPack == 5)
                    {
                        Pack = _Items.Pack5.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 6, _Items.UntPri5.Value);
                    }
                    break;
                }
            }
            FlxInv.Cols[3].ComboList = CoA;
            FlxInv.Cols[5].ComboList = CoE;
            FlxInv.SetData(FlxInv.Row, 3, DefUnitA);
            FlxInv.SetData(FlxInv.Row, 5, DefUnitE);
            BindDataofItemPrice();
            FlxInv.SetData(FlxInv.Row, 6, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 6)))));
            FlxInv.SetData(FlxInv.Row, 7, 0);
            FlxInv.SetData(FlxInv.Row, 8, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 6)))) - (checkBox_DisVal.Checked ? double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 7)))) : ItmDis));
            FlxInv.SetData(FlxInv.Row, 9, 1);
            FlxInv.SetData(FlxInv.Row, 10, 0);
            FillLines();
        }
        private void BindDataofItemPrice()
        {
            if (CmbInvPrice.SelectedIndex == 1 && _Items.Price1.HasValue)
            {
                FlxInv.SetData(FlxInv.Row, 6, _Items.Price1.Value / _Items.DefPack.Value * Pack);
            }
            else if (CmbInvPrice.SelectedIndex == 2 && _Items.Price2.HasValue)
            {
                FlxInv.SetData(FlxInv.Row, 6, _Items.Price2.Value / _Items.DefPack.Value * Pack);
            }
            else if (CmbInvPrice.SelectedIndex == 3 && _Items.Price3.HasValue)
            {
                FlxInv.SetData(FlxInv.Row, 6, _Items.Price3.Value / _Items.DefPack.Value * Pack);
            }
            else if (CmbInvPrice.SelectedIndex == 4 && _Items.Price4.HasValue)
            {
                FlxInv.SetData(FlxInv.Row, 6, _Items.Price4.Value / _Items.DefPack.Value * Pack);
            }
            else if (CmbInvPrice.SelectedIndex == 5 && _Items.Price5.HasValue)
            {
                FlxInv.SetData(FlxInv.Row, 6, _Items.Price5.Value / _Items.DefPack.Value * Pack);
            }
        }
        private void FlxInvDet_BeforeEdit(object sender, RowColEventArgs e)
        {
            try
            {
                if ((e.Col == 3 || e.Col == 5) && FlxInvDet.GetData(e.Row, e.Col) != null)
                {
                    oldUnitDet = FlxInvDet.GetData(e.Row, 3).ToString() ?? "";
                }
            }
            catch
            {
            }
        }
        private void FlxInvDet_AfterEdit(object sender, RowColEventArgs e)
        {
            try
            {
                if (int.Parse(FlxInvDet.GetData(FlxInvDet.Row, 16).ToString()) <= 0)
                {
                    FlxInvDet.SetData(e.Row, 1, "");
                    FlxInvDet.SetData(e.Row, 2, "");
                    FlxInvDet.SetData(e.Row, 3, "");
                    FlxInvDet.SetData(e.Row, 4, "");
                    FlxInvDet.SetData(e.Row, 5, "");
                    FlxInvDet.SetData(e.Row, 7, 0);
                    FlxInvDet.SetData(e.Row, 8, 0);
                    FlxInvDet.SetData(e.Row, 9, 0);
                    FlxInvDet.SetData(e.Row, 10, 0);
                    FlxInvDet.SetData(e.Row, 11, 0);
                    FlxInvDet.SetData(e.Row, 12, "");
                    FlxInvDet.SetData(e.Row, 13, "");
                    FlxInvDet.SetData(e.Row, 14, "");
                    FlxInvDet.SetData(e.Row, 15, "");
                    return;
                }
            }
            catch
            {
                FlxInvDet.SetData(e.Row, 1, "");
                FlxInvDet.SetData(e.Row, 2, "");
                FlxInvDet.SetData(e.Row, 3, "");
                FlxInvDet.SetData(e.Row, 4, "");
                FlxInvDet.SetData(e.Row, 5, "");
                FlxInvDet.SetData(e.Row, 7, 0);
                FlxInvDet.SetData(e.Row, 8, 0);
                FlxInvDet.SetData(e.Row, 9, 0);
                FlxInvDet.SetData(e.Row, 10, 0);
                FlxInvDet.SetData(e.Row, 11, 0);
                FlxInvDet.SetData(e.Row, 12, "");
                FlxInvDet.SetData(e.Row, 13, "");
                FlxInvDet.SetData(e.Row, 14, "");
                FlxInvDet.SetData(e.Row, 15, "");
                return;
            }
            if (e.Col == 16)
            {
                try
                {
                    int c = int.Parse(FlxInvDet.GetData(e.Row, 16).ToString());
                    FlxInvDet.SetData(e.Row, 12, FlxInv.GetData(c, 1));
                    FlxInvDet.SetData(e.Row, 13, FlxInv.GetData(c, 3));
                }
                catch
                {
                    FlxInvDet.SetData(e.Row, 1, "");
                    FlxInvDet.SetData(e.Row, 2, "");
                    FlxInvDet.SetData(e.Row, 3, "");
                    FlxInvDet.SetData(e.Row, 4, "");
                    FlxInvDet.SetData(e.Row, 5, "");
                    FlxInvDet.SetData(e.Row, 7, 0);
                    FlxInvDet.SetData(e.Row, 8, 0);
                    FlxInvDet.SetData(e.Row, 9, 0);
                    FlxInvDet.SetData(e.Row, 10, 0);
                    FlxInvDet.SetData(e.Row, 11, 0);
                    FlxInvDet.SetData(e.Row, 12, "");
                    FlxInvDet.SetData(e.Row, 13, "");
                    FlxInvDet.SetData(e.Row, 14, "");
                    FlxInvDet.SetData(e.Row, 15, "");
                }
                return;
            }
            double ItmDis = 0.0;
            try
            {
                if (checkBox_DisRate.Checked && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(e.Row, 8)))) > 0.0)
                {
                    ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(e.Row, 7)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(e.Row, 8)))) / 100.0);
                }
            }
            catch
            {
            }
            if (e.Col == 1)
            {
                BindDataOfItemDet();
            }
            else if (((e.Col == 2 || e.Col == 4) && (string)FlxInvDet.GetData(e.Row, 1) == "") || FlxInvDet.GetData(e.Row, 1) == null)
            {
                BindDataOfItemDet();
            }
            else if ((e.Col == 3 || e.Col == 5) && FlxInvDet.GetData(e.Row, e.Col).ToString() != oldUnitDet)
            {
                int ItemIndex = -1;
                if (e.Col == 3)
                {
                    string[] Items = FlxInvDet.Cols[e.Col].ComboList.Split('|');
                    for (int i = 0; i < Items.Length; i++)
                    {
                        if (Items[i] == FlxInvDet.GetData(e.Row, e.Col).ToString())
                        {
                            ItemIndex = i + 1;
                        }
                    }
                    string[] Items2 = FlxInvDet.Cols[5].ComboList.Split('|');
                    if (Items2.Length > 1 && ItemIndex > -1)
                    {
                        FlxInvDet.SetData(e.Row, 5, Items2[ItemIndex - 1]);
                    }
                }
                else if (e.Col == 5)
                {
                    string[] Items = FlxInvDet.Cols[e.Col].ComboList.Split('|');
                    for (int i = 0; i < Items.Length; i++)
                    {
                        if (Items[i] == FlxInvDet.GetData(e.Row, e.Col).ToString())
                        {
                            ItemIndex = i + 1;
                        }
                    }
                    string[] Items2 = FlxInvDet.Cols[3].ComboList.Split('|');
                    if (Items2.Length > 1 && ItemIndex > -1)
                    {
                        FlxInvDet.SetData(e.Row, 3, Items2[ItemIndex - 1]);
                    }
                }
                switch (ItemIndex)
                {
                    case 1:
                        FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.UntPri1);
                        break;
                    case 2:
                        FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.UntPri2);
                        break;
                    case 3:
                        FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.UntPri3);
                        break;
                    case 4:
                        FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.UntPri4);
                        break;
                    case 5:
                        FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.UntPri5);
                        break;
                }
                PackDet = ItemIndex;
                BindDataofItemPriceDet();
                FlxInvDet.SetData(e.Row, 9, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(e.Row, 7)))) - (checkBox_DisVal.Checked ? double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(e.Row, 8)))) : ItmDis));
            }
            else if (e.Col == 6)
            {
                listStkQty = (from t in db.T_STKSQTies
                              where t.itmNo == FlxInvDet.GetData(e.Row, 1).ToString()
                              where t.storeNo == (int?)int.Parse(FlxInvDet.GetData(e.Row, 6).ToString())
                              select t).ToList();
                FlxInvDet.SetData(e.Row, 14, "");
                FlxInvDet.SetData(e.Row, 15, "");
                try
                {
                    FlxDat.Clear(ClearFlags.Content, 1, 0, FlxDat.Rows.Count - 1, 1);
                    listQtyExp = (from t in db.T_QTYEXPs
                                  orderby t.DatExper
                                  where t.itmNo == FlxInvDet.GetData(e.Row, 1).ToString()
                                  where t.storeNo == (int?)int.Parse(FlxInvDet.GetData(e.Row, 6).ToString())
                                  select t).ToList();
                    if (listQtyExp.Count != 0)
                    {
                        for (int iiCnt = 0; iiCnt < listQtyExp.Count; iiCnt++)
                        {
                            _QtyExp = listQtyExp[iiCnt];
                            FlxDat.Rows.Count = iiCnt + 2;
                            FlxDat.SetData(iiCnt + 1, 0, _QtyExp.DatExper.ToString());
                            FlxDat.SetData(iiCnt + 1, 1, _QtyExp.stkQty.Value.ToString());
                            FlxDat.SetData(iiCnt + 1, 2, _QtyExp.RunCod.ToString());
                        }
                        FlxDat.Visible = true;
                        FlxDat.Focus();
                    }
                    else
                    {
                        FlxDat.Visible = false;
                    }
                }
                catch
                {
                    FlxDat.Visible = false;
                }
            }
            else if (e.Col == 8)
            {
                FlxInvDet.SetData(e.Row, 9, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(e.Row, 7)))) - (checkBox_DisVal.Checked ? double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(e.Row, 8)))) : ItmDis));
            }
        }
        private void BindDataOfItemDet()
        {
            if (!base.Visible)
            {
                return;
            }
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
            if ((string)FlxInvDet.GetData(FlxInvDet.Row, 1) != "" && FlxInvDet.GetData(FlxInvDet.Row, 1) != null)
            {
                Barcod = ChkBarCod((string)FlxInvDet.GetData(FlxInvDet.Row, 1));
                if (!Barcod || (VarGeneral.SSSLev != "D" && VarGeneral.SSSLev != "G" && VarGeneral.SSSLev != "S" && VarGeneral.SSSLev != "B" && VarGeneral.SSSLev != "F" && VarGeneral.SSSLev != "C" && VarGeneral.SSSLev != "R" && VarGeneral.SSSLev != "H" && VarGeneral.SSSLev != "M"))
                {
                    listSer = db.StockItemList(FlxInvDet.GetData(FlxInvDet.Row, 1).ToString());
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
                _RepShow.Rule = " Where 1 = 1 and T_Items.ItmTyp != 1 and InvSaleStoped = 0 ";
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
                        if ((string)FlxInvDet.GetData(FlxInvDet.Row, 2) != "" && FlxInvDet.GetData(FlxInvDet.Row, 2) != null)
                        {
                            ItmDes = (string)FlxInvDet.GetData(FlxInvDet.Row, 2);
                            ItmDesIndex = 2;
                        }
                    }
                    else if ((string)FlxInvDet.GetData(FlxInvDet.Row, 4) != "" && FlxInvDet.GetData(FlxInvDet.Row, 4) != null)
                    {
                        ItmDes = (string)FlxInvDet.GetData(FlxInvDet.Row, 4);
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
                        FlxInvDet.RemoveItem(FlxInvDet.Row);
                        try
                        {
                            FlxInvDet.Rows.Add();
                        }
                        catch
                        {
                        }
                        FlxInvDet.Row = FlxInvDet.RowSel;
                        FlxInvDet.Col = 1;
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
                                  where t.ItmTyp != (int?)1 && !t.InvSaleStoped.Value
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
                    if ((string)FlxInvDet.GetData(FlxInvDet.Row, 2) != "" && FlxInvDet.GetData(FlxInvDet.Row, 2) != null)
                    {
                        ItmDes = (string)FlxInvDet.GetData(FlxInvDet.Row, 2);
                        ItmDesIndex = 2;
                    }
                }
                else if ((string)FlxInvDet.GetData(FlxInvDet.Row, 4) != "" && FlxInvDet.GetData(FlxInvDet.Row, 4) != null)
                {
                    ItmDes = (string)FlxInvDet.GetData(FlxInvDet.Row, 4);
                    ItmDesIndex = 3;
                }
                FrmSearch FmSerch = new FrmSearch();
                VarGeneral.SFrmTyp = "T_InvGrid";
                VarGeneral.vItmTyp = 1;
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
                        FlxInvDet.RemoveItem(FlxInvDet.Row);
                        try
                        {
                            FlxInvDet.Rows.Add();
                        }
                        catch
                        {
                        }
                        FlxInvDet.Row = FlxInvDet.RowSel;
                        FlxInvDet.Col = 1;
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
                    _RepShow.Rule = " Where 1 = 1 and T_Items.ItmTyp != 1 and InvSaleStoped = 0";
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
                        FMFind FmQuikSerch = new FMFind((string)FlxInvDet.GetData(FlxInvDet.Row, 1), 1);
                        FmQuikSerch.Tag = LangArEn;
                        FmQuikSerch.TopMost = true;
                        FmQuikSerch.ShowDialog();
                        _SearchNo = FmQuikSerch.SerachNo;
                    }
                    if (!(_SearchNo != ""))
                    {
                        try
                        {
                            FlxInvDet.RemoveItem(FlxInvDet.Row);
                            try
                            {
                                FlxInvDet.Rows.Add();
                            }
                            catch
                            {
                            }
                            FlxInvDet.Row = FlxInvDet.RowSel;
                            FlxInvDet.Col = 1;
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
                                      where t.ItmTyp != (int?)1 && !t.InvSaleStoped.Value
                                      orderby t.Itm_No
                                      select t).ToList();
                    if (q.Count == 0)
                    {
                        return;
                    }
                    FrmSearch FmSerch = new FrmSearch();
                    VarGeneral.SFrmTyp = "T_InvGrid";
                    VarGeneral.vItmTyp = 1;
                    FmSerch.Tag = LangArEn;
                    VarGeneral.itmDes = (string)FlxInvDet.GetData(FlxInvDet.Row, 1);
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
                            FlxInvDet.RemoveItem(FlxInvDet.Row);
                            try
                            {
                                FlxInvDet.Rows.Add();
                            }
                            catch
                            {
                            }
                            FlxInvDet.Row = FlxInvDet.RowSel;
                            FlxInvDet.Col = 1;
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
            double ItmDis = 0.0;
            FlxInvDet.SetData(FlxInvDet.Row, 1, _Items.Itm_No.Trim());
            FlxInvDet.SetData(FlxInvDet.Row, 2, _Items.Arb_Des.Trim());
            FlxInvDet.SetData(FlxInvDet.Row, 4, _Items.Eng_Des.Trim());
            FlxInvDet.SetData(FlxInvDet.Row, 6, 1);
            try
            {
                if (permission.DefStores.HasValue && permission.DefStores.Value > 0)
                {
                    FlxInvDet.SetData(FlxInvDet.Row, 6, permission.DefStores.Value);
                }
            }
            catch
            {
                FlxInvDet.SetData(FlxInvDet.Row, 6, 1);
            }
            FlxInvDet.SetData(FlxInvDet.Row, 14, "");
            FlxInvDet.SetData(FlxInvDet.Row, 15, "");
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
                        PackDet = _Items.Pack1.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.UntPri1.Value);
                    }
                    else if (DefPack == 1)
                    {
                        PackDet = _Items.Pack1.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.UntPri1.Value);
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
                        PackDet = _Items.Pack2.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.UntPri2.Value);
                    }
                    else if (DefPack == 2)
                    {
                        PackDet = _Items.Pack2.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.UntPri2.Value);
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
                        PackDet = _Items.Pack3.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.UntPri3.Value);
                    }
                    else if (DefPack == 3)
                    {
                        PackDet = _Items.Pack3.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.UntPri3.Value);
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
                        PackDet = _Items.Pack4.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.UntPri4.Value);
                    }
                    else if (DefPack == 4)
                    {
                        PackDet = _Items.Pack4.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.UntPri4.Value);
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
                        PackDet = _Items.Pack5.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.UntPri5.Value);
                    }
                    else if (DefPack == 5)
                    {
                        PackDet = _Items.Pack5.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.UntPri5.Value);
                    }
                    break;
                }
            }
            FlxInvDet.Cols[3].ComboList = CoA;
            FlxInvDet.Cols[5].ComboList = CoE;
            FlxInvDet.SetData(FlxInvDet.Row, 3, DefUnitA);
            FlxInvDet.SetData(FlxInvDet.Row, 5, DefUnitE);
            BindDataofItemPrice();
            FlxInvDet.SetData(FlxInvDet.Row, 7, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(FlxInvDet.Row, 7)))));
            FlxInvDet.SetData(FlxInvDet.Row, 8, 0);
            FlxInvDet.SetData(FlxInvDet.Row, 9, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(FlxInvDet.Row, 7)))) - (checkBox_DisVal.Checked ? double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(FlxInvDet.Row, 8)))) : ItmDis));
            FlxInvDet.SetData(FlxInvDet.Row, 10, 1);
            if (FlxInvDet.Cols[11].Visible)
            {
                FlxInvDet.SetData(FlxInvDet.Row, 11, VarGeneral.TString.ChkStatShow(_InvSetting.TaxOptions, 2) ? _Items.TaxPurchas : _Items.TaxSales);
            }
            else
            {
                FlxInvDet.SetData(FlxInvDet.Row, 11, 0);
            }
        }
        private void BindDataofItemPriceDet()
        {
            if (CmbInvPrice.SelectedIndex == 1 && _Items.Price1.HasValue)
            {
                FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.Price1.Value / _Items.DefPack.Value * PackDet);
            }
            else if (CmbInvPrice.SelectedIndex == 2 && _Items.Price2.HasValue)
            {
                FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.Price2.Value / _Items.DefPack.Value * PackDet);
            }
            else if (CmbInvPrice.SelectedIndex == 3 && _Items.Price3.HasValue)
            {
                FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.Price3.Value / _Items.DefPack.Value * PackDet);
            }
            else if (CmbInvPrice.SelectedIndex == 4 && _Items.Price4.HasValue)
            {
                FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.Price4.Value / _Items.DefPack.Value * PackDet);
            }
            else if (CmbInvPrice.SelectedIndex == 5 && _Items.Price5.HasValue)
            {
                FlxInvDet.SetData(FlxInvDet.Row, 7, _Items.Price5.Value / _Items.DefPack.Value * PackDet);
            }
        }
        int kk = 0;
        private void FlxInvDet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
            {
                return;
            }
            try
            {
                if (FlxInvDet.GetData(RowSel, 1).ToString() != null)
                {
                    FlxInvDet.RemoveItem(FlxInvDet.Row);
                }
            }
            catch
            {
                FlxInvDet.RemoveItem(FlxInvDet.Row);
            }
        }
        private void FlxInvDet_RowColChange(object sender, EventArgs e)
        {
            if (FlxInvDet.Col == 1)
            {
                Framework.Keyboard.Language.Switch("English");
            }
            if (FlxInvDet.Col == 2)
            {
                Framework.Keyboard.Language.Switch("Arabic");
            }
            if (FlxInvDet.Col == 4)
            {
                Framework.Keyboard.Language.Switch("English");
            }
        }
        private void FlxInvDet_SelChange(object sender, EventArgs e)
        {
            try
            {
                if (RowSel == 0 || RowSel == FlxInvDet.Row || FlxInvDet.Row <= 0 || !(string.Concat(FlxInvDet.GetData(FlxInvDet.Row, 1)) != ""))
                {
                    return;
                }
                List<T_Item> listSer = new List<T_Item>();
                listSer = db.StockItemList(string.Concat(FlxInvDet.GetData(FlxInvDet.RowSel, 1)));
                if (listSer.Count == 0)
                {
                    return;
                }
                _Items = listSer[0];
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
                FlxInvDet.Cols[3].ComboList = CoA;
                FlxInvDet.Cols[5].ComboList = CoE;
            }
            catch
            {
            }
        }
        private void FlxInvDet_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                try
                {
                    if (string.Concat(FlxInvDet.GetData(FlxInvDet.RowSel, 1)) != "" && State != 0)
                    {
                        _Items = db.StockItem(string.Concat(FlxInvDet.GetData(FlxInvDet.RowSel, 1)));
                    }
                }
                catch
                {
                }
                if (string.Concat(FlxInvDet.GetData(FlxInvDet.RowSel, 1)) != "")
                {
                    _Items = db.StockItem(string.Concat(FlxInvDet.GetData(FlxInvDet.RowSel, 1)));
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
                    FlxInvDet.Cols[3].ComboList = CoA;
                    FlxInvDet.Cols[5].ComboList = CoE;
                }
            }
            catch
            {
            }
            FillLines();
        }
        private void FlxDat_DoubleClick(object sender, EventArgs e)
        {
            if (FlxDat.MouseRow > 0)
            {
                FlxInvDet.SetData(FlxInvDet.Row, 14, FlxDat.GetData(FlxDat.Row, 0));
                FlxInvDet.SetData(FlxInvDet.Row, 15, FlxDat.GetData(FlxDat.Row, 2));
                FlxDat.Visible = false;
                FlxInvDet.Col = 6;
                FlxInvDet.Focus();
            }
        }
        private void FlxDat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && FlxDat.Row > 0)
            {
                FlxInvDet.SetData(FlxInvDet.Row, 14, FlxDat.GetData(FlxDat.Row, 0));
                FlxInvDet.SetData(FlxInvDet.Row, 15, FlxDat.GetData(FlxDat.Row, 2));
                FlxDat.Visible = false;
                FlxInvDet.Col = 6;
                FlxInvDet.Focus();
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
        private void switchButton_OfferTyp_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (switchButton_OfferTyp.Value)
                {
                    expandableSplitter2.Expanded = true;
                    VarGeneral.InvTyp = 1;
                }
                else
                {
                    expandableSplitter2.Expanded = false;
                    VarGeneral.InvTyp = 0;
                }
                textBox_ID.TextChanged -= textBox_ID_TextChanged;
                textBox_ID.Text = "";
                textBox_ID.TextChanged += textBox_ID_TextChanged;
                State = FormState.Saved;
                Clear();
                MainProcess();
            }
            catch
            {
            }
        }
        private void checkBox_Chash_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_DisVal.Checked)
            {
                FlxInv.Cols[7].Caption = ((LangArEn == 0) ? "قيمة الخصم" : "Dis Value");
                FlxInvDet.Cols[8].Caption = ((LangArEn == 0) ? "قيمة الخصم" : "Dis Value");
            }
            else
            {
                FlxInv.Cols[7].Caption = ((LangArEn == 0) ? "نسبة الخصم" : "Rate Value");
                FlxInvDet.Cols[8].Caption = ((LangArEn == 0) ? "نسبة الخصم" : "Rate Value");
            }
            try
            {
                for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
                {
                    try
                    {
                        if (!(string.Concat(FlxInv.GetData(iiCnt, 1)) != ""))
                        {
                            continue;
                        }
                        double ItmDis = 0.0;
                        try
                        {
                            if (checkBox_DisRate.Checked && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) > 0.0)
                            {
                                ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 6)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) / 100.0);
                            }
                        }
                        catch
                        {
                        }
                        FlxInv.SetData(iiCnt, 8, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 6)))) - (checkBox_DisVal.Checked ? double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) : ItmDis));
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
                for (int iiCnt = 1; iiCnt < FlxInvDet.Rows.Count; iiCnt++)
                {
                    try
                    {
                        if (!(string.Concat(FlxInvDet.GetData(iiCnt, 1)) != ""))
                        {
                            continue;
                        }
                        double ItmDis = 0.0;
                        try
                        {
                            if (checkBox_DisRate.Checked && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(iiCnt, 8)))) > 0.0)
                            {
                                ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(iiCnt, 7)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(iiCnt, 8)))) / 100.0);
                            }
                        }
                        catch
                        {
                        }
                        FlxInvDet.SetData(iiCnt, 9, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(iiCnt, 7)))) - (checkBox_DisVal.Checked ? double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInvDet.GetData(iiCnt, 8)))) : ItmDis));
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

        private void FlxInv_StartEdit(object sender, RowColEventArgs e)
        {
            kk = 1;
        }

        private void FlxInv_LeaveEdit(object sender, RowColEventArgs e)
        {
            kk = 0;
        }

        private void ribbonBar1_ItemClick(object sender, EventArgs e)
        {

        }
    }
}
