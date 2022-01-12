using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using Framework.Data;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using Microsoft.Win32;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmAdvances : Form
    { void avs(int arln)

{ 
 panelEx2.Text=   (arln == 0 ? "  Click to collapse  " : "  Click to collapse") ; label7.Text=   (arln == 0 ? "  الـــــــراتب :  " : "  salary:") ; label1.Text=   (arln == 0 ? "  يخصم بدءاُ :  " : "  deduct starting with:") ; checkBox_AccID.Text=   (arln == 0 ? "  إصدار قيد محاسبي تلقائي  " : "  Issuance of automatic accounting entry") ; button_SavePremuim.Text=   (arln == 0 ? "  حفظ الأقساط  " : "  Save installments") ; buttonItem_Cancel.Text=   (arln == 0 ? "  إلغاء  " : "  Cancellation") ; label4.Text=   (arln == 0 ? "  إجمالي السلف التي عليه  " : "  Total advances on it") ; label3.Text=   (arln == 0 ? "  المتبقــــــــي :  " : "  Remaining:") ; label11.Text=   (arln == 0 ? "  عـدد الأقساط :  " : "  The number of installments:") ; label2.Text=   (arln == 0 ? "  قيمة السلفـة :  " : "  Advance value:") ; groupPanel1.Text=   (arln == 0 ? "  جـــدول الأقســــاط  " : "  Installment Table") ; label12.Text=   (arln == 0 ? "  الموظف :  " : "  employee:") ; label38.Text=   (arln == 0 ? "  الكود :  " : "  Code:") ; label8.Text=   (arln == 0 ? "  العملــــــــة :  " : "  work:") ; label5.Text=   (arln == 0 ? "  حساب سلف الموظف :  " : "  Employee advance account:") ; label6.Text=   (arln == 0 ? "  مركز التكلفة :  " : "  cost center:") ; superTabControl_Main1.Text=   (arln == 0 ? "  superTabControl3  " : "  superTabControl3") ; Button_Close.Text=   (arln == 0 ? "  إغلاق  " : "  Close") ; Button_Search.Text=   (arln == 0 ? "  بحث  " : "  Search") ; Button_Delete.Text=   (arln == 0 ? "  حذف  " : "  delete") ; Button_Save.Text=   (arln == 0 ? "  حفظ  " : "  save") ; Button_Add.Text=   (arln == 0 ? "  إضافة  " : "  addition") ; superTabControl_Main2.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; Button_First.Text=   (arln == 0 ? "  الأول  " : "  the first") ; Button_Prev.Text=   (arln == 0 ? "  السابق  " : "  the previous") ; lable_Records.Text=   (arln == 0 ? "  ---  " : "  ---") ; Button_Next.Text=   (arln == 0 ? "  التالي  " : "  next one") ; Button_Last.Text=   (arln == 0 ? "  الأخير  " : "  the last one") ; DGV_Main.Text=   (arln == 0 ? "    " : "    ") ; DGV_Main.Text=   (arln == 0 ? "  جميــع السجــــلات  " : "  All records") ; DGV_Main.Text=   (arln == 0 ? "    " : "    ") ; panelEx3.Text=   (arln == 0 ? "  Fill Panel  " : "  Fill Panel") ; superTabControl_DGV.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; textBox_search.Text=   (arln == 0 ? "  ...  " : "  ...") ; Button_ExportTable2.Text=   (arln == 0 ? "  تصدير  " : "  Export") ; /*Button_PrintTable.Text=   (arln == 0 ? "  طباعة  " : "  Print") ; */ToolStripMenuItem_Rep.Text=   (arln == 0 ? "  إظهار التقرير  " : "  Show report") ; ToolStripMenuItem_Det.Text=   (arln == 0 ? "  إظهار التفاصيل  " : "  Show details") ; Text = "كرت السلفيـــات";this.Text=   (arln == 0 ? "  كرت السلفيـــات  " : "  credit card") ;}
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
                        frm.Repvalue = "AdvancRep";
                        frm.Repvalue = "AdvancRep";
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
        private Timer timer1;
        private ExpandableSplitter expandableSplitter1;
        private PanelEx panelEx2;
        private RibbonBar ribbonBar1;
        private System.Windows.Forms. SaveFileDialog saveFileDialog1;
        protected SuperGridControl DGV_Main;
        private PanelEx panelEx3;
        private Timer timerInfoBallon;
        private System.Windows.Forms.OpenFileDialog  openFileDialog1;
        private Panel panel1;
        private DockSite barTopDockSite;
        private DockSite barBottomDockSite;
        public DotNetBarManager dotNetBarManager1;
        private ImageList imageList1;
        private DockSite barLeftDockSite;
        private DockSite barRightDockSite;
        private DockSite dockSite4;
        private DockSite dockSite1;
        private DockSite dockSite2;
        private DockSite dockSite3;
        protected ContextMenuStrip contextMenuStrip1;
        protected ToolStripMenuItem ToolStripMenuItem_Rep;
        protected ToolStripMenuItem ToolStripMenuItem_Det;
        protected ContextMenuStrip contextMenuStrip2;
        private RibbonBar ribbonBar_Tasks;
        private SuperTabControl superTabControl_Main2;
        protected LabelItem labelItem1;
        protected ButtonItem Button_First;
        protected ButtonItem Button_Prev;
        protected TextBoxItem TextBox_Index;
        protected LabelItem Label_Count;
        protected ButtonItem Button_Next;
        protected ButtonItem Button_Last;
        private SuperTabControl superTabControl_Main1;
        protected ButtonItem Button_Close;
        protected ButtonItem Button_Search;
        protected ButtonItem Button_Delete;
        protected ButtonItem Button_Save;
        protected ButtonItem Button_Add;
        protected LabelItem labelItem2;
        private RibbonBar ribbonBar_DGV;
        private SuperTabControl superTabControl_DGV;
        protected TextBoxItem textBox_search;
        protected ButtonItem Button_ExportTable2;
        protected ButtonItem Button_PrintTable;
        protected LabelItem labelItem3;
        private Panel panel2;
        private MaskedTextBox textBox_SalDate;
        private ComboBoxEx comboBox_EmpNo;
        private ButtonX button_SrchEmp;
        private Label label12;
        private MaskedTextBox dateTimeInput_warnDate;
        protected TextBox textBox_ID;
        protected Label label38;
        private TextBoxX textBox_Note;
        private DataGridViewX dataGridViewX_Advances;
        private IntegerInput textBox_TotalPremiums;
        private DoubleInput textBox_ValueAdvances;
        private Label label11;
        private Label label2;
        private GroupPanel groupPanel1;
        private Panel panel3;
        private Panel panel4;
        private Panel panel_Acc;
        private SwitchButton switchButton_AccType;
        private TextBox txtBXBankName;
        private ButtonX button_SrchBXBankNo;
        private TextBox txtBXBankNo;
        private CheckBoxX checkBox_AccID;
        private Panel panel6;
        private DoubleInput textBox_ValuePremium;
        private DataGridViewTextBoxColumn Premiums_No;
        private DataGridViewTextBoxColumn PremiumsDate;
        private DataGridViewDoubleInputColumn ValuePremiums;
        private DataGridViewDoubleInputColumn Paying;
        private DataGridViewCheckBoxColumn IFState;
        private DataGridViewTextBoxColumn Premiums_ID;
        private DataGridViewTextBoxColumn Advances_No;
        private Label label1;
        private DoubleInput textBox_ResidualValue;
        private Label label4;
        private DoubleInput textBox_Remaining;
        private Label label3;
        private ButtonX button_SavePremuim;
        private ButtonItem buttonItem_Cancel;
        private TextBox txtBXLoanNo;
        internal Label label5;
        private ButtonX button_ScrhLoan;
        private TextBox txtBXLoanName;
        private TextBox txtBXCostCenterNo;
        private TextBox txtBXCostCenterName;
        private ButtonX button_SrchCostCenter;
        internal Label label6;
        private ButtonX button_CustD3;
        private ButtonX button_CustD1;
        private DoubleInput textBox_Salary;
        private Label label7;
        private LabelItem lable_Records;
        internal Label label8;
        private ComboBoxEx CmbCurr;
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private T_AccDef _AccDefBind = new T_AccDef();
        private int LangArEn = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
#pragma warning disable CS0414 // The field 'FrmAdvances.FlagUpdate' is assigned but its value is never used
        private string FlagUpdate = "";
#pragma warning restore CS0414 // The field 'FrmAdvances.FlagUpdate' is assigned but its value is never used
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstance;
        private T_Advance data_this;
        private BindingList<T_Premium> Ldata_instance;
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
        private Dictionary<string, ColumnDictinary> Dir_ButSearch = new Dictionary<string, ColumnDictinary>();
        private T_GDHEAD _GdHead = new T_GDHEAD();
        private List<T_GDHEAD> listGdHead = new List<T_GDHEAD>();
        private T_GDDET _GdDet = new T_GDDET();
        private List<T_GDDET> listGdDet = new List<T_GDDET>();
        private bool StopSetData = false;
        private ScriptNumber ScriptNumber1 = new ScriptNumber();
        private T_Premium data_this_Pre;
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
        private double oldValue = 0.0;
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
        public T_Advance DataThis
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
        public T_Premium getLineNewInstance => new T_Premium();
        public BindingList<T_Premium> LDataThis
        {
            get
            {
                return Ldata_instance;
            }
            set
            {
                Ldata_instance = value;
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
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_MovStr, 17))
                    {
                        IfAdd = false;
                    }
                    else
                    {
                        IfAdd = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_MovStr, 18) || !canUpdate)
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_MovStr, 19) || !canUpdate)
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
        public T_Premium DataThisPre
        {
            get
            {
                return data_this_Pre;
            }
            set
            {
                data_this_Pre = value;
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
        public void Button_Search_Click(object sender, EventArgs e)
        {
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_Advance";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                textBox_ID.Text = frm.SerachNo.ToString();
            }
        }
        private void TextBox_Search_ButtonCustomClick(object sender, EventArgs e)
        {
            textBox_search.Text = "";
        }
        private void textBox_Note_ButtonCustomClick(object sender, EventArgs e)
        {
            textBox_Note.Text = "";
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
            List<T_Advance> list = db.FillAdvances_2(textBox_search.TextBox.Text).ToList();
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                }
            }
            FillHDGV(list);
        }
        public void FillHDGV(IEnumerable<T_Advance> new_data_enum)
        {
            bool contextMenuSet = false;
            if (contextMenuStrip1.Items.Count > 0)
            {
                contextMenuSet = true;
            }
            for (int i = 0; i < DGV_Main.PrimaryGrid.Columns.Count; i++)
            {
                if (columns_Names_visible.ContainsKey(DGV_Main.PrimaryGrid.Columns[i].Name) && DGV_Main.PrimaryGrid.Columns[i].Name != "EmpNm" && DGV_Main.PrimaryGrid.Columns[i].Name != "Emp_No")
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
            DGV_Main.PrimaryGrid.DataMember = "T_Advance";
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
        private void TextBox_Search_InputTextChanged(object sender)
        {
            Fill_DGV_Main();
        }
        public void FillCombo()
        {
            List<T_Emp> listEmps = new List<T_Emp>(db.T_Emps.Select((T_Emp item) => item).ToList());
            comboBox_EmpNo.DataSource = listEmps;
            comboBox_EmpNo.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_EmpNo.ValueMember = "Emp_ID";
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
            try
            {
                CmbCurr.SelectedValue = int.Parse(VarGeneral.Settings_Sys.ImportIp.ToString());
            }
            catch
            {
            }
        }
        public void Clear()
        {
            if (State == FormState.New)
            {
                return;
            }
            State = FormState.New;
            data_this = new T_Advance();
            _GdHead = new T_GDHEAD();
            State = FormState.New;
            int? calendr;
            for (int i = 0; i < controls.Count; i++)
            {
                if (controls[i].GetType() == typeof(DateTimePicker))
                {
                    calendr = VarGeneral.Settings_Sys.Calendr;
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
                    else if (controls[i].GetType() == typeof(ComboBox) && (controls[i] as ComboBox).Items.Count > 0)
                    {
                        try
                        {
                            (controls[i] as ComboBox).SelectedIndex = 0;
                        }
                        catch
                        {
                            (controls[i] as ComboBox).SelectedIndex = -1;
                        }
                    }
                    else if (controls[i].GetType() == typeof(ComboBoxEx) && (controls[i] as ComboBoxEx).Items.Count > 0)
                    {
                        try
                        {
                            (controls[i] as ComboBoxEx).SelectedIndex = 0;
                        }
                        catch
                        {
                            (controls[i] as ComboBoxEx).SelectedIndex = -1;
                        }
                    }
                }
            }
            try
            {
                if (dataGridViewX_Advances.Rows.Count > 0)
                {
                    dataGridViewX_Advances.Rows.Clear();
                }
            }
            catch
            {
            }
            Guid id = Guid.NewGuid();
            textBox_ID.Tag = id.ToString();
            calendr = VarGeneral.Settings_Sys.Calendr;
            if (calendr.Value == 0 && calendr.HasValue)
            {
                textBox_SalDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM");
                dateTimeInput_warnDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
            }
            else
            {
                textBox_SalDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM");
                dateTimeInput_warnDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
            }
            if (comboBox_EmpNo.Items.Count > 0)
            {
                comboBox_EmpNo.SelectedValueChanged -= comboBox_EmpNo_SelectedValueChanged;
                comboBox_EmpNo.SelectedIndex = 0;
                comboBox_EmpNo.SelectedValueChanged += comboBox_EmpNo_SelectedValueChanged;
                comboBox_EmpNo_SelectedValueChanged(null, null);
            }
            checkBox_AccID.CheckedChanged -= checkBox_AccID_CheckedChanged;
            checkBox_AccID.Checked = false;
            checkBox_AccID.CheckedChanged += checkBox_AccID_CheckedChanged;
            checkBox_AccID_CheckedChanged(null, null);
            switchButton_AccType.ValueChanged -= switchButton_AccType_ValueChanged;
            switchButton_AccType.Value = false;
            switchButton_AccType.ValueChanged += switchButton_AccType_ValueChanged;
            switchButton_AccType_ValueChanged(null, null);
            canUpdate = true;
            button_SavePremuim.Visible = false;
            try
            {
                CmbCurr.SelectedValue = int.Parse(VarGeneral.Settings_Sys.ImportIp.ToString());
            }
            catch
            {
            }
            SetReadOnly = false;
        }
        private void Button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void DGV_Main_CellClick(object sender, GridCellClickEventArgs e)
        {
            DGV_Main.PrimaryGrid.Tag = e.GridCell.RowIndex;
        }
        private void DGV_Main_CellDoubleClick(object sender, GridCellDoubleClickEventArgs e)
        {
            ToolStripMenuItem_Det_Click(sender, e);
        }
        private void textBox_ID_Click(object sender, EventArgs e)
        {
            textBox_ID.SelectAll();
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
                Button_PrintTable_Click(sender, e);
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
            var qkeys = db.T_Advances.Select((T_Advance item) => new
            {
                Code = item.Advances_No + ""
            });
            int count = 0;
            foreach (var item2 in qkeys)
            {
                count++;
                PKeys.Add(item2.Code);
            }
            Label_Count.Text = string.Concat(count);
            UpdateVcr();
        }
        public FrmAdvances()
        {
            InitializeComponent();this.Load += langloads;
            textBox_Note.Click += Button_Edit_Click;
            textBox_SalDate.Click += Button_Edit_Click;
            textBox_TotalPremiums.Click += Button_Edit_Click;
            textBox_ValueAdvances.Click += Button_Edit_Click;
            textBox_ValuePremium.Click += Button_Edit_Click;
            dateTimeInput_warnDate.MouseDown += Button_Edit_Click;
            comboBox_EmpNo.Click += Button_Edit_Click;
            textBox_ID.KeyPress += textBox_ID_KeyPress;
            Button_Close.Click += Button_Close_Click;
            expandableSplitter1.Click += expandableSplitter1_Click;
            ToolStripMenuItem_Det.Click += ToolStripMenuItem_Det_Click;
            Button_ExportTable2.Click += Button_ExportTable2_Click;
            Button_First.Click += Button_First_Click;
            Button_Prev.Click += Button_Prev_Click;
            Button_Next.Click += Button_Next_Click;
            Button_Last.Click += Button_Last_Click;
            Button_Add.Click += Button_Add_Click;
            Button_Search.Click += Button_Search_Click;
            Button_Delete.Click += Button_Delete_Click;
            Button_Save.Click += Button_Save_Click;
            textBox_search.InputTextChanged += TextBox_Search_InputTextChanged;
            textBox_search.ButtonCustomClick += TextBox_Search_ButtonCustomClick;
            textBox_Note.ButtonCustomClick += textBox_Note_ButtonCustomClick;
            TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
            DGV_Main.MouseDown += DGV_Main_MouseDown;
            DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
            DGV_Main.CellClick += DGV_Main_CellClick;
            DGV_Main.GetCellStyle += DGV_MainGetCellStyle;
            DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
            DGV_Main.DataBindingComplete += DGV_Main_DataBindingComplete;
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmAdvances));
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
            RibunButtons();
            FillCombo();
            GridSetting();
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
                Button_PrintTable.Text = ((VarGeneral.GeneralPrinter.ISdirectPrinting) ? "طباعة" : "عــرض");
                Button_PrintTable.Tooltip = "F5";
                Button_ExportTable2.Text = "تصدير";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "جميع السجلات";
                label38.Text = "الكود :";
                textBox_Note.WatermarkText = "ملاحظـــــــات السلفيـــــات";
                button_CustD1.Tooltip = "إستدعاء الإفتراضي من شاشة الموظف";
                button_CustD3.Tooltip = "إستدعاء الإفتراضي من شاشة الموظف";
                Text = "كرت السلفيـــات";
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
                label38.Text = "Code :";
                textBox_Note.WatermarkText = "Notes";
                button_CustD1.Tooltip = "Call Auto Account from Employe form";
                button_CustD3.Tooltip = "Call Auto Account from Employe form";
                Text = "Advances Card";
            }
        }
        private void GridSetting()
        {
            try
            {
                dataGridViewX_Advances.Columns["Premiums_No"].Visible = true;
                dataGridViewX_Advances.Columns["Premiums_No"].MinimumWidth = 55;
                dataGridViewX_Advances.Columns["Premiums_No"].HeaderText = ((LangArEn == 0) ? "القسط" : "Loan No");
                dataGridViewX_Advances.Columns["PremiumsDate"].Visible = true;
                dataGridViewX_Advances.Columns["PremiumsDate"].Width = 75;
                dataGridViewX_Advances.Columns["PremiumsDate"].HeaderText = ((LangArEn == 0) ? "يخصم في شهر" : "Loan Date");
                dataGridViewX_Advances.Columns["ValuePremiums"].Visible = true;
                dataGridViewX_Advances.Columns["ValuePremiums"].Width = 115;
                dataGridViewX_Advances.Columns["ValuePremiums"].HeaderText = ((LangArEn == 0) ? "قيمة القسط" : "Loan Value");
                dataGridViewX_Advances.Columns["Paying"].Visible = true;
                dataGridViewX_Advances.Columns["Paying"].Width = 115;
                dataGridViewX_Advances.Columns["Paying"].HeaderText = ((LangArEn == 0) ? "المدفوع" : "Paid");
                dataGridViewX_Advances.Columns["IFState"].Visible = true;
                dataGridViewX_Advances.Columns["IFState"].Width = 63;
                dataGridViewX_Advances.Columns["IFState"].HeaderText = ((LangArEn == 0) ? "الحالة" : "Curryover");
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("GridSetting:", error, enable: true);
            }
        }
        private void FrmAdvances_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmAdvances));
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
                ADD_Controls();
                Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
                if (columns_Names_visible.Count == 0)
                {
                    columns_Names_visible.Add("Advances_No", new ColumnDictinary("رقم العملية", "No", ifDefault: true, ""));
                    columns_Names_visible.Add("EmpNm", new ColumnDictinary("اسم الموظف", "Employee Name", ifDefault: false, ""));
                    columns_Names_visible.Add("Emp_No", new ColumnDictinary("رقم الموظف", "Employee No", ifDefault: false, ""));
                    columns_Names_visible.Add("ResolutionDate", new ColumnDictinary("تاريخ العملية", "Date", ifDefault: true, ""));
                    columns_Names_visible.Add("ValueAdvances", new ColumnDictinary("قيمة السلفة", "Advance Value", ifDefault: true, ""));
                    columns_Names_visible.Add("TotalPremiums", new ColumnDictinary("عدد الأقساط", "Total Premiums", ifDefault: true, ""));
                    columns_Names_visible.Add("SalDate", new ColumnDictinary("تاريخ بداية الخصم", "Date Advance", ifDefault: true, ""));
                    columns_Names_visible.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, ""));
                }
                else
                {
                    Clear();
                    textBox_ID.Text = "";
                    TextBox_Index.TextBox.Text = "";
                }
                RibunButtons();
                GridSetting();
                FillCombo();
                RefreshPKeys();
                textBox_ID.Text = PKeys.FirstOrDefault();
                ViewDetails_Click(sender, e);
                UpdateVcr();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void textBox_ID_TextChanged(object sender, EventArgs e)
        {
            int no = 0;
            try
            {
                no = int.Parse(textBox_ID.Text);
            }
            catch
            {
            }
            textBox_TotalPremiums.ValueChanged -= textBox_TotalPremiums_ValueChanged;
            try
            {
                T_Advance newData = db.AdvanceEmp(no);
                if (newData == null || newData.Advances_No == 0 || string.IsNullOrEmpty(newData.Advances_ID))
                {
                    if (!Button_Add.Visible || !Button_Add.Enabled)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textBox_ID.TextChanged -= textBox_ID_TextChanged;
                        try
                        {
                            textBox_ID.Text = data_this.Advances_No.ToString();
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
                    int indexA = PKeys.IndexOf(string.Concat(newData.Advances_No));
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
            button_SavePremuim.Visible = false;
            textBox_TotalPremiums.ValueChanged += textBox_TotalPremiums_ValueChanged;
            UpdateVcr();
        }
        public void SetData(T_Advance value)
        {
            State = FormState.Saved;
            Button_Save.Enabled = false;
            canUpdate = true;
            textBox_ID.Tag = value.Advances_ID;
            textBox_Note.Text = value.Note;
            textBox_Remaining.Value = value.Remaining.Value;
            textBox_SalDate.Text = value.SalDate;
            textBox_Salary.Value = value.Salary.Value;
            textBox_TotalPremiums.Value = value.TotalPremiums.Value;
            textBox_ValueAdvances.Value = value.ValueAdvances.Value;
            textBox_ValuePremium.Value = value.ValuePremium.Value;
            checkBox_AccID.Checked = value.AccID.Value;
            switchButton_AccType.Value = value.AutoDisFromSalary.Value;
            try
            {
                if (VarGeneral.CheckDate(value.ResolutionDate))
                {
                    dateTimeInput_warnDate.Text = Convert.ToDateTime(value.ResolutionDate).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_warnDate.Text = "";
                }
            }
            catch
            {
                dateTimeInput_warnDate.Text = "";
            }
            if (!string.IsNullOrEmpty(value.EmpID))
            {
                comboBox_EmpNo.SelectedValue = value.EmpID;
            }
            comboBox_EmpNo_SelectedValueChanged(null, null);
            FillGrid(value.Advances_No);
            if (value.GadeId.HasValue && checkBox_AccID.Checked)
            {
                listGdHead = db.StockGdHeadid((int)value.GadeId.Value);
                if (listGdHead.Count != 0)
                {
                    _GdHead = listGdHead[0];
                    if (_GdHead.gdCstNo.HasValue && !StopSetData)
                    {
                        txtBXCostCenterNo.Text = _GdHead.gdCstNo.Value.ToString();
                        txtBXCostCenterName.Text = ((LangArEn == 0) ? _GdHead.T_CstTbl.Arb_Des : _GdHead.T_CstTbl.Eng_Des);
                    }
                    listGdDet = _GdHead.T_GDDETs.ToList();
                    if (value.AutoDisFromSalary.Value)
                    {
                        int j = 0;
                        while (true)
                        {
                            if (j >= listGdDet.Count)
                            {
                                break;
                            }
                            if (listGdDet[j].gdValue < 0.0)
                            {
                                List<T_AccDef> q = db.T_AccDefs.Where((T_AccDef t) => t.AccDef_No == listGdDet[j].T_AccDef.ParAcc).ToList();
                                txtBXBankNo.Text = q.First().AccDef_No;
                                txtBXBankName.Text = ((LangArEn == 0) ? q.First().Arb_Des : q.First().Eng_Des);
                            }
                            else
                            {
                                txtBXLoanNo.Text = listGdDet[j].AccNo;
                                txtBXLoanName.Text = ((LangArEn == 0) ? listGdDet[j].T_AccDef.Arb_Des : listGdDet[j].T_AccDef.Eng_Des);
                            }
                            j++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        while (true)
                        {
                            if (i >= listGdDet.Count)
                            {
                                break;
                            }
                            if (listGdDet[i].gdValue < 0.0)
                            {
                                List<T_AccDef> q = db.T_AccDefs.Where((T_AccDef t) => t.AccDef_No == listGdDet[i].T_AccDef.ParAcc).ToList();
                                txtBXBankNo.Text = listGdDet[i].AccNo;
                                txtBXBankName.Text = ((LangArEn == 0) ? listGdDet[i].T_AccDef.Arb_Des : listGdDet[i].T_AccDef.Eng_Des);
                            }
                            else
                            {
                                txtBXLoanNo.Text = listGdDet[i].AccNo;
                                txtBXLoanName.Text = ((LangArEn == 0) ? listGdDet[i].T_AccDef.Arb_Des : listGdDet[i].T_AccDef.Eng_Des);
                            }
                            i++;
                        }
                    }
                    try
                    {
                        CmbCurr.SelectedValue = _GdHead.CurTyp.Value;
                    }
                    catch
                    {
                        try
                        {
                            CmbCurr.SelectedValue = int.Parse(VarGeneral.Settings_Sys.ImportIp.ToString());
                        }
                        catch
                        {
                        }
                    }
                }
                else
                {
                    _GdHead = new T_GDHEAD();
                    try
                    {
                        CmbCurr.SelectedValue = int.Parse(VarGeneral.Settings_Sys.ImportIp.ToString());
                    }
                    catch
                    {
                    }
                }
            }
            SetReadOnly = true;
        }
        private void FillGrid(int vEmp)
        {
            try
            {
                try
                {
                    if (dataGridViewX_Advances.Rows.Count > 0)
                    {
                        dataGridViewX_Advances.Rows.Clear();
                    }
                }
                catch
                {
                }
                var q = (from t in db.T_Premiums
                         where t.Advances_No == (int?)vEmp
                         orderby t.Premiums_No
                         select new
                         {
                             t.Advances_No,
                             t.Premiums_ID,
                             t.Premiums_No,
                             t.PremiumsDate,
                             t.ValuePremiums,
                             t.Paying,
                             t.IFState
                         }).ToList();
                for (int i = 0; i < q.Count; i++)
                {
                    dataGridViewX_Advances.Rows.Add();
                    dataGridViewX_Advances.Rows[i].Cells["Premiums_ID"].Value = q[i].Premiums_ID;
                    dataGridViewX_Advances.Rows[i].Cells["Advances_No"].Value = q[i].Advances_No;
                    dataGridViewX_Advances.Rows[i].Cells["Premiums_No"].Value = q[i].Premiums_No;
                    dataGridViewX_Advances.Rows[i].Cells["PremiumsDate"].Value = q[i].PremiumsDate;
                    dataGridViewX_Advances.Rows[i].Cells["ValuePremiums"].Value = q[i].ValuePremiums.Value;
                    dataGridViewX_Advances.Rows[i].Cells["Paying"].Value = q[i].Paying.Value;
                    dataGridViewX_Advances.Rows[i].Cells["IFState"].Value = q[i].IFState.Value;
                    if ((bool)dataGridViewX_Advances.Rows[i].Cells["IFState"].Value)
                    {
                        canUpdate = false;
                    }
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FillGrid:", error, enable: true);
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
        private T_Advance GetData()
        {
            textBox_ID.Focus();
            try
            {
                data_this.Advances_No = int.Parse(textBox_ID.Text);
            }
            catch
            {
            }
            data_this.ResolutionNo = "1";
            data_this.Note = textBox_Note.Text;
            try
            {
                data_this.Remaining = textBox_Remaining.Value;
            }
            catch
            {
                data_this.Remaining = 0.0;
            }
            try
            {
                data_this.ValuePremiumEdit = textBox_ValuePremium.Value;
            }
            catch
            {
                data_this.ValuePremiumEdit = textBox_ValuePremium.Value;
            }
            try
            {
                data_this.TotalPremiums = textBox_TotalPremiums.Value;
            }
            catch
            {
                data_this.TotalPremiums = 0;
            }
            try
            {
                data_this.ValueAdvances = textBox_ValueAdvances.Value;
            }
            catch
            {
                data_this.ValueAdvances = 0.0;
            }
            try
            {
                data_this.ValuePremium = textBox_ValuePremium.Value;
            }
            catch
            {
                data_this.ValuePremium = textBox_ValuePremium.Value;
            }
            try
            {
                data_this.ResolutionDate = Convert.ToDateTime(dateTimeInput_warnDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_warnDate.Text = "";
                data_this.ResolutionDate = "";
            }
            try
            {
                data_this.SalDate = Convert.ToDateTime(textBox_SalDate.Text).ToString("yyyy/MM");
            }
            catch
            {
                data_this.SalDate = DateTime.Now.ToString("yyyy/MM");
            }
            data_this.Salary = textBox_Salary.Value;
            try
            {
                data_this.EmpID = comboBox_EmpNo.SelectedValue.ToString();
            }
            catch
            {
                data_this.EmpID = null;
            }
            data_this.AccID = checkBox_AccID.Checked;
            data_this.AutoDisFromSalary = switchButton_AccType.Value;
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
                SetReadOnly = false;
            }
        }
        private void Button_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Button_Add.Visible || !Button_Add.Enabled)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا تملك الصلاحية هذه العملية .. يرجى مراجعة الصلاحيات" : "You are not permission this operation .. Please check permissions", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else if (State != FormState.Edit || !(textBox_ID.Text != "") || MessageBox.Show((LangArEn == 0) ? "لم يتم حفظ التغيرات, هل حقا\u064b تريد المتابعة؟" : "Not saved the changes, do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    int max = 0;
                    max = db.MaxAdvanceNo;
                    textBox_ID.Text = max.ToString();
                    textBox_ValueAdvances.ValueChanged -= textBox_ValueAdvances_ValueChanged;
                    Clear();
                    textBox_ValueAdvances.ValueChanged += textBox_ValueAdvances_ValueChanged;
                    State = FormState.New;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Button_Add_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private bool ValidData()
        {
            try
            {
                if (int.Parse(textBox_ID.Text) <= 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "هناك خطأ في المدخلات ,, الرجاء التأكد من الرقم " : "There is an error in the input, please make sure of the No", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_ID.Focus();
                    return false;
                }
            }
            catch
            {
            }
            if (!Button_Save.Enabled)
            {
                return false;
            }
            if (State == FormState.Edit && !CanEdit)
            {
                MessageBox.Show((LangArEn == 0) ? "لا تملك الصلاحية هذه العملية .. يرجى مراجعة الصلاحيات" : "You are not permission this operation .. Please check permissions", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (State == FormState.New && !Button_Add.Enabled)
            {
                MessageBox.Show((LangArEn == 0) ? "لا تملك الصلاحية هذه العملية .. يرجى مراجعة الصلاحيات" : "You are not permission this operation .. Please check permissions", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (textBox_ID.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "لابد من تحديد الرقم التسلسلي " : "Most Set Auto No", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_ID.Focus();
                return false;
            }
            if (comboBox_EmpNo.Items.Count <= 0)
            {
                MessageBox.Show((LangArEn == 0) ? "لابد من اختيار موظف" : "Most Select Employee", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                comboBox_EmpNo.Focus();
                return false;
            }
            if (textBox_SalDate.Text.Trim().Length != 7)
            {
                MessageBox.Show((LangArEn == 0) ? "تاكد من تاريخ الراتب" : "Make sure the date of salary", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_SalDate.Focus();
                return false;
            }
            if (dateTimeInput_warnDate.Text.Length != 10)
            {
                MessageBox.Show((LangArEn == 0) ? "يجب تحديد تاريخ القرار" : "You must specify the date of the decision", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                dateTimeInput_warnDate.Focus();
                return false;
            }
            if (textBox_ValueAdvances.Value <= 0.0)
            {
                MessageBox.Show((LangArEn == 0) ? "عفوا\u064b , يجب تحديد قيمة السلفة " : "Sorry .. Most Set Loan Value !", VarGeneral.ProdectNam);
                textBox_ValueAdvances.Focus();
                return false;
            }
            if (textBox_TotalPremiums.Value <= 0)
            {
                MessageBox.Show((LangArEn == 0) ? "عفوا\u064b , يجب تحديد عدد الأقساط " : "Sorry .. Most Set Loan Count", VarGeneral.ProdectNam);
                textBox_TotalPremiums.Focus();
                return false;
            }
            if (textBox_ValueAdvances.Value > textBox_Salary.Value && MessageBox.Show((LangArEn == 0) ? "قيمة القسط اكبر من قيمة الراتب .. هل حقا تريد المتابعة؟؟" : "The value of the premium is greater than the value of the salary .. Do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
            {
                return false;
            }
            if (checkBox_AccID.Checked && txtBXBankName.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "تأكد من حساب الدائن (الصندوق-البنك)" : "Credit Account is Rong", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtBXBankName.Focus();
                return false;
            }
            if (checkBox_AccID.Checked && txtBXLoanName.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "تأكد من حساب المدين (حساب سلف الموظف)" : "Debit Account is Rong", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtBXLoanName.Focus();
                return false;
            }
            double vSum = 0.0;
            for (int i = 0; i < dataGridViewX_Advances.Rows.Count; i++)
            {
                vSum += Math.Abs((double)dataGridViewX_Advances.Rows[i].Cells["ValuePremiums"].Value + 0.0);
            }
            if (Math.Round(vSum, 0) != Math.Round(textBox_ValueAdvances.Value, 0))
            {
                if (MessageBox.Show((LangArEn == 0) ? " مجموع الأقساط لا يساوي إجمالي السلفة .. هل تريد استرجاع الاقساط السابقة؟" : "Total premiums are not equal to the total advance .. Do you want to retrieve the previous installments?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.No)
                {
                    dbInstance = null;
                    textBox_TotalPremiums_ValueChanged(null, null);
                }
                return false;
            }
            if (false)
            {
#pragma warning disable CS0162 // Unreachable code detected
                Environment.Exit(0);
#pragma warning restore CS0162 // Unreachable code detected
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
                            string dtAction = (n.IsHijri(textBox_SalDate.Text + "/01") ? (textBox_SalDate.Text + "/01") : n.GregToHijri(textBox_SalDate.Text + "/01", "yyyy/MM/dd"));
                            if (Convert.ToDateTime(n.GregToHijri(hKeyNew.GetValue("vBackup_New").ToString(), "yyyy/MM/dd")) < Convert.ToDateTime(n.FormatHijri(dtAction, "yyyy/MM/dd")))
                            {
                                MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. لقد تخطيت السنة المالية المحدد للنظام \n يرجى التواصل مع الإدارة لللإشتراك في خدمات النسخة " : "We can not complete the operation .. have you skip the fiscal year specified for the system", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return false;
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
        private void Button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                textBox_ID.Focus();
                if (!ValidData())
                {
                    return;
                }
                string AccCrdt = "";
                string AccDbt = "";
                if (!checkBox_AccID.Checked)
                {
                    goto IL_00d4;
                }
                AccCrdt = txtBXBankNo.Text;
                AccDbt = txtBXLoanNo.Text;
                if (AccCrdt == "")
                {
                    MessageBox.Show((LangArEn == 0) ? " تأكد من صحة الطرف الدائن ( حساب البنك - الصندوق ) .. ثم المحاولة مرة اخرى .. " : "You can not complete the operation .. Make sure the creditor Account ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (!(AccDbt == ""))
                {
                    goto IL_00d4;
                }
                MessageBox.Show((LangArEn == 0) ? " تأكد من صحة الطرف المدين ( حساب السلف ) .. ثم المحاولة مرة اخرى " : "You can not complete the operation .. Make sure the debtor Account", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                goto end_IL_0001;
            IL_036d:
                IDatabase db_;
                if (textBox_ValueAdvances.Value > 0.0 && checkBox_AccID.Checked)
                {
                    Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
                    if (State == FormState.New || _GdHead.gdhead_ID == 0)
                    {
                        GetDataGd();
                        _GdHead.DATE_CREATED = DateTime.Now;
                        dbc.T_GDHEADs.InsertOnSubmit(_GdHead);
                        dbc.SubmitChanges();
                    }
                    else
                    {
                        dbInstance = null;
                        StopSetData = true;
                        textBox_ID_TextChanged(null, null);
                        StopSetData = false;
                        GetDataGd();
                        db.Log = VarGeneral.DebugLog;
                        db.SubmitChanges(ConflictMode.ContinueOnConflict);
                        for (int i = 0; i < _GdHead.T_GDDETs.Count; i++)
                        {
                            db_.StartTransaction();
                            db_.ClearParameters();
                            db_.AddParameter("GDDET_ID", DbType.Int32, _GdHead.T_GDDETs[i].GDDET_ID);
                            db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_DELETE");
                            db_.EndTransaction();
                        }
                    }
                    db_.StartTransaction();
                    db_.ClearParameters();
                    db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                    db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                    db_.AddParameter("gdNo", DbType.String, _GdHead.gdNo);
                    db_.AddParameter("gdDes", DbType.String, "سند قيد لصرف سلفة الى الموظف :" + data_this.T_Emp.NameA);
                    db_.AddParameter("gdDesE", DbType.String, "Sand advance to the employee : " + data_this.T_Emp.NameE);
                    db_.AddParameter("recptTyp", DbType.String, "16");
                    db_.AddParameter("AccNo", DbType.String, AccCrdt);
                    db_.AddParameter("AccName", DbType.String, "");
                    db_.AddParameter("gdValue", DbType.Double, 0.0 - double.Parse(textBox_ValueAdvances.Text));
                    db_.AddParameter("recptNo", DbType.String, _GdHead.gdNo);
                    db_.AddParameter("Lin", DbType.Int32, 1);
                    db_.AddParameter("AccNoDestruction", DbType.String, null);
                    db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                    db_.EndTransaction();
                    db_.StartTransaction();
                    db_.ClearParameters();
                    db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                    db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                    db_.AddParameter("gdNo", DbType.String, _GdHead.gdNo);
                    db_.AddParameter("gdDes", DbType.String, "سند قيد لصرف سلفة الى الموظف :" + data_this.T_Emp.NameA);
                    db_.AddParameter("gdDesE", DbType.String, "Sand advance to the employee : " + data_this.T_Emp.NameE);
                    db_.AddParameter("recptTyp", DbType.String, "16");
                    db_.AddParameter("AccNo", DbType.String, AccDbt);
                    db_.AddParameter("AccName", DbType.String, "");
                    db_.AddParameter("gdValue", DbType.Double, double.Parse(textBox_ValueAdvances.Text));
                    db_.AddParameter("recptNo", DbType.String, _GdHead.gdNo);
                    db_.AddParameter("Lin", DbType.Int32, 2);
                    db_.AddParameter("AccNoDestruction", DbType.String, null);
                    db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                    db_.EndTransaction();
                }
                dbInstance = null;
                textBox_ID_TextChanged(null, null);
                data_this.GadeId = _GdHead.gdhead_ID;
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                State = FormState.Saved;
                RefreshPKeys();
                TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(string.Concat(data_this.Advances_No)) + 1);
                SetReadOnly = true;
                goto end_IL_0001;
            IL_02f6:
                GetData();
                if (db.CheckEmp_Premium(data_this.Advances_No))
                {
                    db.T_Premiums.DeleteAllOnSubmit(DataThis.T_Premiums);
                    db.SubmitChanges();
                }
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                AqsaatOp();
                goto IL_036d;
            IL_00d4:
                db_ = Database.GetDatabase(VarGeneral.BranchCS);
                if (State == FormState.New)
                {
                    GetData();
                    try
                    {
                        data_this.Advances_ID = textBox_ID.Tag.ToString();
                        db.T_Advances.InsertOnSubmit(data_this);
                        db.SubmitChanges();
                        AqsaatOp();
                    }
                    catch (SqlException error2)
                    {
                        int max = 0;
                        max = db.MaxAdvanceNo;
                        if (error2.Number == 2627)
                        {
                            MessageBox.Show((LangArEn == 0) ? ("رقم الأمر مستخدم من قبل.\nسيتم الحفظ برقم جديد [" + max + "]") : ("This No is user before.\nWill be save a new number [" + max + "]"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            textBox_ID.TextChanged -= textBox_ID_TextChanged;
                            textBox_ID.Text = string.Concat(max);
                            textBox_ID.TextChanged += textBox_ID_TextChanged;
                            data_this.Advances_No = max;
                            Button_Save_Click(sender, e);
                        }
                        else
                        {
                            VarGeneral.DebLog.writeLog("Button_Save_Click:", error2, enable: true);
                            MessageBox.Show(error2.Message);
                        }
                        return;
                    }
                    goto IL_036d;
                }
                if (State != FormState.Edit)
                {
                    goto IL_036d;
                }
                if (!data_this.AccID.Value || checkBox_AccID.Checked)
                {
                    goto IL_02f6;
                }
                if (MessageBox.Show((LangArEn == 0) ? "لهذا السلفة قيد محاسبي سابق سيتم حذفه .. هل تريد المتابعة؟" : "This advance is a former accounting entry will be deleted .. Do you want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    return;
                }
                db_.StartTransaction();
                db_.ClearParameters();
                db_.AddParameter("gdhead_ID", DbType.Int32, _GdHead.gdhead_ID);
                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDHEAD_DELETE");
                db_.EndTransaction();
                goto IL_02f6;
            end_IL_0001:;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Button_Save_Click:", error, enable: true);
                MessageBox.Show(error.Message);
                StopSetData = false;
            }
        }
        private T_GDHEAD GetDataGd()
        {
            _GdHead.gdHDate = (n.IsHijri(dateTimeInput_warnDate.Text) ? dateTimeInput_warnDate.Text : n.GregToHijri(dateTimeInput_warnDate.Text, "yyyy/MM/dd"));
            _GdHead.gdGDate = (n.IsGreg(dateTimeInput_warnDate.Text) ? dateTimeInput_warnDate.Text : n.HijriToGreg(dateTimeInput_warnDate.Text, "yyyy/MM/dd"));
            if (string.IsNullOrEmpty(_GdHead.gdNo) || State == FormState.New)
            {
                _GdHead.gdNo = db.MaxGDHEADsNo.ToString();
            }
            _GdHead.ArbTaf = ScriptNumber1.ScriptNum(decimal.Parse("0" + textBox_ValueAdvances.Text));
            _GdHead.BName = _GdHead.BName;
            _GdHead.ChekNo = "EmpAdvance";
            _GdHead.CurTyp = int.Parse(CmbCurr.SelectedValue.ToString());
            _GdHead.EngTaf = ScriptNumber1.TafEng(decimal.Parse("0" + textBox_ValueAdvances.Text));
            if (!string.IsNullOrEmpty(txtBXCostCenterNo.Text))
            {
                _GdHead.gdCstNo = int.Parse(txtBXCostCenterNo.Text);
            }
            else
            {
                _GdHead.gdCstNo = null;
            }
            _GdHead.gdID = 0;
            _GdHead.gdLok = false;
            _GdHead.AdminLock = false;
            _GdHead.gdMem = ((LangArEn == 0) ? ("سند قيد لصرف سلفة الى الموظف :" + data_this.T_Emp.NameA) : ("Sand advance to the employee : " + data_this.T_Emp.NameE));
            _GdHead.gdMnd = null;
            _GdHead.gdRcptID = (_GdHead.gdRcptID.HasValue ? _GdHead.gdRcptID.Value : 0.0);
            _GdHead.gdTot = textBox_ValueAdvances.Value;
            _GdHead.gdTp = (_GdHead.gdTp.HasValue ? _GdHead.gdTp.Value : 0);
            _GdHead.gdTyp = 16;
            _GdHead.RefNo = "";
            _GdHead.DATE_MODIFIED = DateTime.Now;
            _GdHead.salMonth = "";
            _GdHead.gdUser = VarGeneral.UserNumber;
            _GdHead.gdUserNam = VarGeneral.UserNameA;
            _GdHead.CompanyID = 1;
            return _GdHead;
        }
        private void AqsaatOp()
        {
            if (db.CheckEmp_Premium(int.Parse(textBox_ID.Text)))
            {
                db.T_Premiums.DeleteAllOnSubmit(DataThis.T_Premiums);
                db.SubmitChanges();
            }
            SavePremuim();
        }
        private void SavePremuim()
        {
            try
            {
                for (int i = 0; i < dataGridViewX_Advances.Rows.Count; i++)
                {
                    DataThisPre = new T_Premium();
                    data_this_Pre.Premiums_ID = dataGridViewX_Advances.Rows[i].Cells["Premiums_ID"].Value.ToString();
                    data_this_Pre.Advances_No = int.Parse(dataGridViewX_Advances.Rows[i].Cells["Advances_No"].Value.ToString());
                    data_this_Pre.IFState = Convert.ToBoolean(dataGridViewX_Advances.Rows[i].Cells["IFState"].Value);
                    data_this_Pre.Paying = double.Parse(dataGridViewX_Advances.Rows[i].Cells["Paying"].Value.ToString());
                    data_this_Pre.Premiums_No = int.Parse(dataGridViewX_Advances.Rows[i].Cells["Premiums_No"].Value.ToString());
                    data_this_Pre.PremiumsDate = dataGridViewX_Advances.Rows[i].Cells["PremiumsDate"].Value.ToString();
                    data_this_Pre.ValuePremiums = double.Parse(dataGridViewX_Advances.Rows[i].Cells["ValuePremiums"].Value.ToString());
                    db.T_Premiums.InsertOnSubmit(data_this_Pre);
                    db.SubmitChanges();
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SavePremuim:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void Button_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Button_Delete.Enabled || !Button_Delete.Visible)
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
                if (MessageBox.Show((LangArEn == 0) ? ("هل أنت متاكد من حذف السجل " + Code) : ("Are you sure you want to delete the record ? " + Code), VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ifOkDelete = true;
                }
                else
                {
                    ifOkDelete = false;
                }
                if (data_this == null || data_this.Advances_No == 0 || string.IsNullOrEmpty(data_this.Advances_ID) || !ifOkDelete)
                {
                    return;
                }
                data_this = db.AdvanceEmp(DataThis.Advances_No);
                try
                {
                    if (data_this.AccID.Value)
                    {
                        if (MessageBox.Show((LangArEn == 0) ? "لهذا السلفة قيد محاسبي سابق سيتم حذفه .. هل تريد المتابعة؟" : "This advance is a former accounting entry will be deleted .. Do you want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                        {
                            return;
                        }
                        IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
                        db_.StartTransaction();
                        db_.ClearParameters();
                        db_.AddParameter("gdhead_ID", DbType.Int32, _GdHead.gdhead_ID);
                        db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDHEAD_DELETE");
                        db_.EndTransaction();
                    }
                }
                catch (Exception error2)
                {
                    VarGeneral.DebLog.writeLog("Del Gaid:", error2, enable: true);
                    MessageBox.Show(error2.Message);
                }
                if (db.CheckEmp_Premium(int.Parse(textBox_ID.Text)))
                {
                    db.T_Premiums.DeleteAllOnSubmit(data_this.T_Premiums);
                    db.SubmitChanges();
                }
                db.T_Advances.DeleteOnSubmit(DataThis);
                db.SubmitChanges();
                Clear();
                RefreshPKeys();
                textBox_ID.Text = PKeys.LastOrDefault();
            }
            catch (Exception error2)
            {
                VarGeneral.DebLog.writeLog("Button_Delete_Click:", error2, enable: true);
                MessageBox.Show(error2.Message);
                DataThis = db.AdvanceEmp(DataThis.Advances_No);
            }
        }
        private void DGV_Main_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            string dataMember = panel.DataMember;
            if (dataMember != null && dataMember == "T_Advance")
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
            panel.Columns["Advances_No"].Width = 120;
            panel.Columns["Advances_No"].Visible = columns_Names_visible["Advances_No"].IfDefault;
            panel.Columns["ResolutionDate"].Width = 120;
            panel.Columns["ResolutionDate"].Visible = columns_Names_visible["ResolutionDate"].IfDefault;
            panel.Columns["Emp_No"].Width = 120;
            panel.Columns["Emp_No"].Visible = columns_Names_visible["Emp_No"].IfDefault;
            panel.Columns["EmpNm"].Width = 250;
            panel.Columns["EmpNm"].Visible = columns_Names_visible["EmpNm"].IfDefault;
            panel.Columns["ValueAdvances"].Width = 120;
            panel.Columns["ValueAdvances"].Visible = columns_Names_visible["ValueAdvances"].IfDefault;
            panel.Columns["TotalPremiums"].Width = 120;
            panel.Columns["TotalPremiums"].Visible = columns_Names_visible["TotalPremiums"].IfDefault;
            panel.Columns["SalDate"].Width = 100;
            panel.Columns["SalDate"].Visible = columns_Names_visible["SalDate"].IfDefault;
            panel.Columns["Note"].Width = 350;
            panel.Columns["Note"].Visible = columns_Names_visible["Note"].IfDefault;
            panel.ReadOnly = true;
        }
        private void DGV_MainGetCellStyle(object sender, GridGetCellStyleEventArgs e)
        {
        }
        private void Button_ExportTable2_Click(object sender, EventArgs e)
        {
            try
            {
                ExportExcel.ExportToExcel(DGV_Main, "تقرير سلفيات الموظفين");
            }
            catch
            {
            }
        }
        private void textBox_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void textBox_Note_Click(object sender, EventArgs e)
        {
            textBox_Note.SelectAll();
        }
        private void dateTimeInput_warnDate_Click(object sender, EventArgs e)
        {
            dateTimeInput_warnDate.SelectAll();
        }
        private void textBox_SalDate_Click(object sender, EventArgs e)
        {
            textBox_SalDate.SelectAll();
        }
        private void ADD_Controls()
        {
            try
            {
                controls = new List<Control>();
                controls.Add(textBox_ID);
                codeControl = textBox_ID;
                controls.Add(textBox_Note);
                controls.Add(textBox_ResidualValue);
                controls.Add(textBox_SalDate);
                controls.Add(textBox_Salary);
                controls.Add(textBox_TotalPremiums);
                controls.Add(textBox_ValueAdvances);
                controls.Add(textBox_ValuePremium);
                controls.Add(textBox_Remaining);
                controls.Add(dateTimeInput_warnDate);
                controls.Add(checkBox_AccID);
                controls.Add(switchButton_AccType);
                controls.Add(comboBox_EmpNo);
                controls.Add(txtBXBankName);
                controls.Add(txtBXBankNo);
                controls.Add(txtBXLoanName);
                controls.Add(txtBXLoanNo);
                controls.Add(txtBXCostCenterName);
                controls.Add(txtBXCostCenterNo);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("ADD_Controls:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void textBox_SalDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(textBox_SalDate.Text))
                {
                    textBox_SalDate.Text = Convert.ToDateTime(textBox_SalDate.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    textBox_SalDate.Text = "";
                }
            }
            catch
            {
                textBox_SalDate.Text = "";
                return;
            }
            textBox_TotalPremiums_ValueChanged(sender, e);
        }
        private void dateTimeInput_warnDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(dateTimeInput_warnDate.Text))
                {
                    dateTimeInput_warnDate.Text = Convert.ToDateTime(dateTimeInput_warnDate.Text).ToString("yyyy/MM/dd");
                    return;
                }
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                if (calendr.Value == 0 && calendr.HasValue)
                {
                    dateTimeInput_warnDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_warnDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                }
            }
            catch
            {
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                if (calendr.Value == 0 && calendr.HasValue)
                {
                    dateTimeInput_warnDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_warnDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                }
            }
        }
        private void button_SrchEmp_Click(object sender, EventArgs e)
        {
            if (!comboBox_EmpNo.Enabled)
            {
                return;
            }
            try
            {
                Dir_ButSearch.Add("Emp_No", new ColumnDictinary("رقم الموظف", "Employee No", ifDefault: true, ""));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, ""));
                Dir_ButSearch.Add("DateAppointment", new ColumnDictinary("تاريخ التعيين", "Appointment Date", ifDefault: false, ""));
                Dir_ButSearch.Add("StartContr", new ColumnDictinary("بداية العقد", "Start Contract Date", ifDefault: false, ""));
                Dir_ButSearch.Add("EndContr", new ColumnDictinary("نهاية العقد", "End Contract Date", ifDefault: false, ""));
                Dir_ButSearch.Add("MainSal", new ColumnDictinary("الراتب الأساسي", "Main Salary", ifDefault: false, ""));
                Dir_ButSearch.Add("ID_No", new ColumnDictinary("رقم الهوية", "ID No", ifDefault: false, ""));
                Dir_ButSearch.Add("Passport_No", new ColumnDictinary("رقم الجواز", "Passport No", ifDefault: false, ""));
                Dir_ButSearch.Add("AddressA", new ColumnDictinary("العنوان", "Address", ifDefault: false, ""));
                Dir_ButSearch.Add("Tel", new ColumnDictinary("الهاتف", "Tel", ifDefault: false, ""));
                Dir_ButSearch.Add("Note", new ColumnDictinary(" الملاحظــات", "Note", ifDefault: false, ""));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                }
                VarGeneral.SFrmTyp = "T_Emp";
                VarGeneral.FrmEmpStat = true;
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    frm.Serach_No = db.EmpsEmpNo(frm.Serach_No).Emp_ID;
                    comboBox_EmpNo.SelectedValue = frm.SerachNo;
                }
                Dir_ButSearch.Clear();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_SrchEmp_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void textBox_ValueAdvances_ValueChanged(object sender, EventArgs e)
        {
            if (State == FormState.Saved)
            {
                return;
            }
            if (!VarGeneral.CheckDate(textBox_SalDate.Text))
            {
                try
                {
                    if (dataGridViewX_Advances.Rows.Count > 0)
                    {
                        dataGridViewX_Advances.Rows.Clear();
                    }
                }
                catch
                {
                }
                return;
            }
            textBox_Remaining.Value = textBox_ValueAdvances.Value;
            if (textBox_ValueAdvances.Value > 0.0 && textBox_TotalPremiums.Value > 0)
            {
                textBox_ValuePremium.Value = Math.Round(textBox_ValueAdvances.Value / (double)textBox_TotalPremiums.Value, 2);
                textBox_ValuePremium_ValueChanged(sender, e);
                return;
            }
            try
            {
                if (dataGridViewX_Advances.Rows.Count > 0)
                {
                    dataGridViewX_Advances.Rows.Clear();
                }
            }
            catch
            {
            }
        }
        private void textBox_TotalPremiums_ValueChanged(object sender, EventArgs e)
        {
            if (State == FormState.Saved)
            {
                button_SavePremuim.Visible = true;
                try
                {
                    if (State == FormState.Saved && dataGridViewX_Advances.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataGridViewX_Advances.Rows.Count; i++)
                        {
                            if (!(dataGridViewX_Advances.Rows[i].Cells["IFState"].Value.ToString() == "False"))
                            {
                                continue;
                            }
                            for (int ii = i; ii < dataGridViewX_Advances.Rows.Count; ii++)
                            {
                                if (dataGridViewX_Advances.Rows[ii].Cells["IFState"].Value.ToString() == "True")
                                {
                                    MessageBox.Show((LangArEn == 0) ? "لايمكن تعديل القسط .. الرجاء التأكد من صحة حساب الرواتب السابقة وترحيلها !" : "Can not be modified Loan .. Please confirm previous salary account and carryover!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    buttonItem_Cancel_Click(sender, e);
                                    return;
                                }
                            }
                        }
                    }
                }
                catch
                {
                    buttonItem_Cancel_Click(sender, e);
                    return;
                }
            }
            else
            {
                button_SavePremuim.Visible = false;
            }
            try
            {
                if (dataGridViewX_Advances.Rows.Count > 0)
                {
                    dataGridViewX_Advances.Rows.Clear();
                }
            }
            catch
            {
            }
            if (!VarGeneral.CheckDate(textBox_SalDate.Text))
            {
                return;
            }
            textBox_Remaining.Value = textBox_ValueAdvances.Value;
            if (textBox_ValueAdvances.Value > 0.0 && textBox_TotalPremiums.Value > 0)
            {
                textBox_ValuePremium.Value = Math.Round(textBox_ValueAdvances.Value / (double)textBox_TotalPremiums.Value, 2);
                textBox_ValuePremium_ValueChanged(sender, e);
                return;
            }
            try
            {
                if (dataGridViewX_Advances.Rows.Count > 0)
                {
                    dataGridViewX_Advances.Rows.Clear();
                }
            }
            catch
            {
            }
        }
        private void comboBox_EmpNo_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_EmpNo.SelectedIndex == -1)
                {
                    textBox_ResidualValue.Value = 0.0;
                    checkBox_AccID_CheckedChanged(sender, e);
                    return;
                }
            }
            catch
            {
                textBox_ResidualValue.Value = 0.0;
                checkBox_AccID_CheckedChanged(sender, e);
            }
            try
            {
                textBox_ResidualValue.Value = (from t in db.T_Premiums
                                               where t.T_Advance.T_Emp.Emp_ID == comboBox_EmpNo.SelectedValue.ToString()
                                               select t.ValuePremiums).Sum().Value - (from t in db.T_Premiums
                                                                                      where t.T_Advance.T_Emp.Emp_ID == comboBox_EmpNo.SelectedValue.ToString()
                                                                                      select t.Paying).Sum().Value;
            }
            catch
            {
                textBox_ResidualValue.Value = 0.0;
            }
            try
            {
                if (State == FormState.New)
                {
                    T_Emp q = db.EmpsEmp(comboBox_EmpNo.SelectedValue.ToString());
                    textBox_Salary.Value = q.MainSal.Value;
                    txtBXLoanNo.Text = q.LoanAcc;
                    if (!string.IsNullOrEmpty(txtBXLoanNo.Text))
                    {
                        txtBXLoanName.Text = ((LangArEn == 0) ? q.T_AccDef3.Arb_Des : q.T_AccDef3.Eng_Des);
                    }
                    else
                    {
                        txtBXLoanName.Text = "";
                    }
                    if (q.CostCenterEmp.HasValue)
                    {
                        txtBXCostCenterNo.Text = q.CostCenterEmp.Value.ToString();
                        txtBXCostCenterName.Text = ((LangArEn == 0) ? q.T_CstTbl.Arb_Des : q.T_CstTbl.Eng_Des);
                    }
                    else
                    {
                        txtBXCostCenterName.Text = "";
                        txtBXCostCenterNo.Text = "";
                    }
                    switchButton_AccType.Value = false;
                    txtBXBankNo.Text = "";
                    txtBXBankName.Text = "";
                }
            }
            catch
            {
                switchButton_AccType.Value = false;
                txtBXBankNo.Text = "";
                txtBXBankName.Text = "";
                txtBXLoanName.Text = "";
                txtBXLoanNo.Text = "";
                txtBXCostCenterName.Text = "";
                txtBXCostCenterNo.Text = "";
                textBox_Salary.Value = 0.0;
            }
        }
        private void checkBox_AccID_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_AccID.Checked)
            {
                panel_Acc.Enabled = true;
                comboBox_EmpNo_SelectedValueChanged(sender, e);
                return;
            }
            panel_Acc.Enabled = false;
            if (State == FormState.New)
            {
                txtBXBankName.Text = "";
                txtBXBankNo.Text = "";
                txtBXLoanName.Text = "";
                txtBXLoanNo.Text = "";
                txtBXCostCenterName.Text = "";
                txtBXCostCenterNo.Text = "";
            }
        }
        private void button_SrchBXBankNo_Click(object sender, EventArgs e)
        {
            FrmSearch frm;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection;
            if (!switchButton_AccType.Value)
            {
                columns_Names_visible2.Clear();
                columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
                columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
                columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
                columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
                columns_Names_visible2.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, ""));
                frm = new FrmSearch();
                frm.Tag = LangArEn;
                animalsAsCollection = columns_Names_visible2;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                }
                VarGeneral.SFrmTyp = "T_AccDef2";
                VarGeneral.AccTyp = 2;
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    Button_Edit_Click(sender, e);
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtBXBankNo.Text = _AccDef.AccDef_No.ToString();
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtBXBankName.Text = _AccDef.Arb_Des.ToString();
                    }
                    else
                    {
                        txtBXBankName.Text = _AccDef.Eng_Des.ToString();
                    }
                }
                else
                {
                    txtBXBankNo.Text = "";
                    txtBXBankName.Text = "";
                }
                return;
            }
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
            columns_Names_visible2.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, ""));
            frm = new FrmSearch();
            frm.Tag = LangArEn;
            animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_AccDef2";
            VarGeneral.AccTyp = 3;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                Button_Edit_Click(sender, e);
                T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                txtBXBankNo.Text = _AccDef.AccDef_No.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtBXBankName.Text = _AccDef.Arb_Des.ToString();
                }
                else
                {
                    txtBXBankName.Text = _AccDef.Eng_Des.ToString();
                }
            }
            else
            {
                txtBXBankNo.Text = "";
                txtBXBankName.Text = "";
            }
        }
        private void dataGridViewX_Advances_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if ((bool)dataGridViewX_Advances.Rows[e.RowIndex].Cells["IFState"].Value)
                {
                    MessageBox.Show((LangArEn == 0) ? " لايمكن تعديل قيمة القسط ,, لانه مرحل" : "Can not adjust the value of the premium, because it is a relay", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_ID.Focus();
                }
            }
            catch
            {
            }
        }
        private void dataGridViewX_Advances_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
        }
        private void checkBox_AccID_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
        }
        private void textBox_ValuePremium_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewX_Advances.Rows.Count > 0)
                {
                    dataGridViewX_Advances.Rows.Clear();
                }
            }
            catch
            {
            }
            if (State == FormState.Edit || button_SavePremuim.Visible)
            {
                if (textBox_Remaining.Value <= 0.0 || db.T_Premiums.Where((T_Premium t) => t.Advances_No == (int?)data_this.Advances_No && !t.IFState.Value).ToList().Count == 0)
                {
                    return;
                }
                if (dataGridViewX_Advances.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridViewX_Advances.Rows.Count; i++)
                    {
                        if (!(dataGridViewX_Advances.Rows[i].Cells["IFState"].Value.ToString() == "False"))
                        {
                            continue;
                        }
                        for (int ii = i; ii < dataGridViewX_Advances.Rows.Count; ii++)
                        {
                            if (dataGridViewX_Advances.Rows[ii].Cells["IFState"].Value.ToString() == "True")
                            {
                                MessageBox.Show((LangArEn == 0) ? "لايمكن تعديل القسط .. الرجاء التأكد من صحة حساب الرواتب السابقة وترحيلها !" : "Can not be modified Loan .. Please confirm previous salary account and carryover!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return;
                            }
                        }
                    }
                }
                List<T_Premium> q = (from t in db.T_Premiums
                                     where t.Advances_No == (int?)int.Parse(textBox_ID.Text)
                                     where t.IFState == (bool?)true
                                     orderby t.Premiums_No
                                     select t).ToList();
                int iiCnt = 0;
                if (q.Count > 0)
                {
                    for (iiCnt = 0; iiCnt < q.Count; iiCnt++)
                    {
                        dataGridViewX_Advances.Rows.Add();
                        dataGridViewX_Advances.Rows[iiCnt].Cells["Premiums_ID"].Value = q[iiCnt].Premiums_ID.ToString();
                        dataGridViewX_Advances.Rows[iiCnt].Cells["Advances_No"].Value = q[iiCnt].Advances_No.Value.ToString();
                        dataGridViewX_Advances.Rows[iiCnt].Cells["Premiums_No"].Value = q[iiCnt].Premiums_No;
                        dataGridViewX_Advances.Rows[iiCnt].Cells["PremiumsDate"].Value = q[iiCnt].PremiumsDate;
                        dataGridViewX_Advances.Rows[iiCnt].Cells["ValuePremiums"].Value = q[iiCnt].ValuePremiums.Value;
                        dataGridViewX_Advances.Rows[iiCnt].Cells["Paying"].Value = q[iiCnt].Paying.Value;
                        dataGridViewX_Advances.Rows[iiCnt].Cells["IFState"].Value = q[iiCnt].IFState.Value;
                    }
                }
                int vValue1 = textBox_TotalPremiums.Value - dataGridViewX_Advances.Rows.Count;
                double vPaying = 0.0;
                try
                {
                    vPaying = double.Parse(VarGeneral.TString.TEmpty(string.Concat((from t in db.T_Premiums
                                                                                    where t.Advances_No == (int?)data_this.Advances_No
                                                                                    where t.Advances_No == (int?)data_this.Advances_No && t.IFState.Value
                                                                                    select t.Paying).Sum().Value)));
                }
                catch
                {
                    vPaying = 0.0;
                }
                double vValue2 = Math.Round(textBox_ValueAdvances.Value - vPaying, 2);
                double vValue3 = Math.Round(vValue2 / (double)vValue1, 2);
                for (int i = iiCnt; i < textBox_TotalPremiums.Value; i++)
                {
                    dataGridViewX_Advances.Rows.Add();
                    Guid id = Guid.NewGuid();
                    dataGridViewX_Advances.Rows[i].Cells["Premiums_ID"].Value = id.ToString();
                    dataGridViewX_Advances.Rows[i].Cells["Advances_No"].Value = int.Parse(textBox_ID.Text);
                    dataGridViewX_Advances.Rows[i].Cells["IFState"].Value = false;
                    dataGridViewX_Advances.Rows[i].Cells["Paying"].Value = 0;
                    dataGridViewX_Advances.Rows[i].Cells["Premiums_No"].Value = i + 1;
                    dataGridViewX_Advances.Rows[i].Cells["PremiumsDate"].Value = Convert.ToDateTime(dateTimeInput_warnDate.Text).AddMonths(i).ToString("yyyy/MM");
                    dataGridViewX_Advances.Rows[i].Cells["ValuePremiums"].Value = vValue3;
                }
            }
            else
            {
                for (int i = 0; i < textBox_TotalPremiums.Value; i++)
                {
                    dataGridViewX_Advances.Rows.Add();
                    Guid id = Guid.NewGuid();
                    dataGridViewX_Advances.Rows[i].Cells["Premiums_ID"].Value = id.ToString();
                    dataGridViewX_Advances.Rows[i].Cells["Advances_No"].Value = int.Parse(textBox_ID.Text);
                    dataGridViewX_Advances.Rows[i].Cells["IFState"].Value = false;
                    dataGridViewX_Advances.Rows[i].Cells["Paying"].Value = 0;
                    dataGridViewX_Advances.Rows[i].Cells["Premiums_No"].Value = i + 1;
                    dataGridViewX_Advances.Rows[i].Cells["PremiumsDate"].Value = Convert.ToDateTime(textBox_SalDate.Text).AddMonths(i).ToString("yyyy/MM");
                    dataGridViewX_Advances.Rows[i].Cells["ValuePremiums"].Value = textBox_ValuePremium.Value;
                }
            }
        }
        private void textBox_Remaining_ValueChanged(object sender, EventArgs e)
        {
            if (State == FormState.New || State == FormState.Edit)
            {
                return;
            }
            try
            {
                List<T_Premium> q = (from tt in db.T_Premiums
                                     orderby tt.Premiums_No
                                     where tt.Advances_No == (int?)int.Parse(textBox_ID.Text) && tt.IFState == (bool?)false
                                     select tt).ToList();
                textBox_Remaining.Value = ((q.Count == 0) ? data_this.ValueAdvances.Value : q.Sum((T_Premium g) => g.ValuePremiums.Value));
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("textBox_Remaining_ValueChanged:", error, enable: true);
            }
        }
        private void buttonItem_Cancel_Click(object sender, EventArgs e)
        {
            textBox_ID_TextChanged(sender, e);
        }
        private void button_SavePremuim_Click(object sender, EventArgs e)
        {
            double vSum = 0.0;
            for (int i = 0; i < dataGridViewX_Advances.Rows.Count; i++)
            {
                vSum += Math.Abs((double)dataGridViewX_Advances.Rows[i].Cells["ValuePremiums"].Value + 0.0);
            }
            if (Math.Round(vSum, 0) != Math.Round(data_this.ValueAdvances.Value, 0))
            {
                if (MessageBox.Show((LangArEn == 0) ? " مجموع الأقساط لا يساوي إجمالي السلفة .. هل تريد استرجاع الاقساط السابقة؟" : "Total premiums are not equal to the total advance .. Do you want to retrieve the previous installments?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.No)
                {
                    buttonItem_Cancel_Click(sender, e);
                }
                return;
            }
            if (db.CheckEmp_Premium(data_this.Advances_No))
            {
                db.T_Premiums.DeleteAllOnSubmit(DataThis.T_Premiums);
                db.SubmitChanges();
            }
            try
            {
                data_this.TotalPremiums = textBox_TotalPremiums.Value;
            }
            catch
            {
                data_this.TotalPremiums = 0;
            }
            db.Log = VarGeneral.DebugLog;
            db.SubmitChanges(ConflictMode.ContinueOnConflict);
            AqsaatOp();
            buttonItem_Cancel_Click(sender, e);
        }
        private void button_SavePremuim_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (State != 0)
                {
                    textBox_ValueAdvances.IsInputReadOnly = false;
                }
                else if (button_SavePremuim.Visible)
                {
                    textBox_ValueAdvances.Value = data_this.ValueAdvances.Value;
                    textBox_ValueAdvances.IsInputReadOnly = true;
                }
                else
                {
                    textBox_ValueAdvances.IsInputReadOnly = false;
                }
            }
            catch
            {
                textBox_ValueAdvances.IsInputReadOnly = false;
            }
        }
        private void button_ScrhLoan_Click(object sender, EventArgs e)
        {
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
            if (frm.SerachNo != "")
            {
                Button_Edit_Click(sender, e);
                txtBXLoanNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtBXLoanName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
                else
                {
                    txtBXLoanName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
            }
            else
            {
                txtBXLoanNo.Text = "";
                txtBXLoanName.Text = "";
            }
        }
        private void switchButton_AccType_ValueChanged(object sender, EventArgs e)
        {
            if (!switchButton_AccType.Value)
            {
                button_CustD1.Enabled = false;
            }
            else
            {
                button_CustD1.Enabled = true;
            }
            txtBXBankNo.Text = "";
            txtBXBankName.Text = "";
        }
        private void button_SrchCostCenter_Click(object sender, EventArgs e)
        {
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("Cst_No", new ColumnDictinary("الرقم", "No", ifDefault: true, ""));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_CstTbl";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                Button_Edit_Click(sender, e);
                txtBXCostCenterNo.Text = db.StockCst(frm.Serach_No).Cst_ID.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtBXCostCenterName.Text = db.StockCst(frm.Serach_No).Arb_Des.ToString();
                }
                else
                {
                    txtBXCostCenterName.Text = db.StockCst(frm.Serach_No).Eng_Des.ToString();
                }
            }
            else
            {
                txtBXCostCenterNo.Text = "";
                txtBXCostCenterName.Text = "";
            }
        }
        private void switchButton_AccType_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
        }
        private void button_CustD1_Click(object sender, EventArgs e)
        {
            if (State == FormState.Saved || comboBox_EmpNo.SelectedIndex == -1 || comboBox_EmpNo.SelectedIndex < 0)
            {
                return;
            }
            T_Emp q = db.EmpsEmp(comboBox_EmpNo.SelectedValue.ToString());
            if (!string.IsNullOrEmpty(q.AccountID))
            {
                txtBXBankNo.Text = q.AccountID;
                if (!string.IsNullOrEmpty(txtBXBankNo.Text))
                {
                    txtBXBankName.Text = ((LangArEn == 0) ? q.T_AccDef.Arb_Des : q.T_AccDef.Eng_Des);
                }
            }
        }
        private void button_CustD3_Click(object sender, EventArgs e)
        {
            if (State != 0 && comboBox_EmpNo.SelectedIndex != -1 && comboBox_EmpNo.SelectedIndex >= 0)
            {
                T_Emp q = db.EmpsEmp(comboBox_EmpNo.SelectedValue.ToString());
                txtBXLoanNo.Text = q.LoanAcc;
                if (!string.IsNullOrEmpty(txtBXLoanNo.Text))
                {
                    txtBXLoanName.Text = ((LangArEn == 0) ? q.T_AccDef3.Arb_Des : q.T_AccDef3.Eng_Des);
                }
            }
        }
        private void Button_PrintTable_Click(object sender, EventArgs e)
        {
            VarGeneral.IsGeneralUsed = true;
            FrmReportsViewer frm = new FrmReportsViewer();
            frm.Repvalue = "AdvancRep";
            frm.Tag = LangArEn;
            frm.Repvalue = "AdvancRep";
            VarGeneral.vTitle = Text;
            frm.SqlWhere = "";
            frm.TopMost = true;
            frm.ShowDialog();
            VarGeneral.IsGeneralUsed = false;
        }
        private void dataGridViewX_Advances_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2 && dataGridViewX_Advances.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    oldValue = double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridViewX_Advances.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)));
                }
            }
            catch
            {
            }
        }
        private void dataGridViewX_Advances_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2 && double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridViewX_Advances.Rows[e.RowIndex].Cells[2].Value))) != oldValue)
                {
                    double newValue = 0.0;
                    newValue = oldValue - double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridViewX_Advances.Rows[e.RowIndex].Cells[2].Value)));
                    dataGridViewX_Advances.Rows[dataGridViewX_Advances.Rows.Count - 1].Cells[e.ColumnIndex].Value = double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridViewX_Advances.Rows[dataGridViewX_Advances.Rows.Count - 1].Cells[e.ColumnIndex].Value))) + newValue;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("dataGridViewX_Advances_CellEndEdit:", error, enable: true);
            }
        }
    }
}
