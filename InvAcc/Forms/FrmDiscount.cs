using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Microsoft.Win32;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmDiscount : Form
    { void avs(int arln)

{ 
 checkBox_Minute.Text=   (arln == 0 ? "  بالدقـــائــق  " : "  in minutes") ; label_lblDaysOfMonth.Text=   (arln == 0 ? "  يخصم من راتب شهـر :  " : "  Deducted from one month's salary:") ; label9.Text=   (arln == 0 ? "  الملاحظــــات :  " : "  Notes:") ; label8.Text=   (arln == 0 ? "  الإجمالـــــــي :  " : "  Total:") ; lblValue.Text=   (arln == 0 ? "  قيمة الخصم :  " : "  discount value :") ; lblNumber.Text=   (arln == 0 ? "  العدد :  " : "  the number :") ; label2.Text=   (arln == 0 ? "  احتساب حسب :  " : "  Calculate by:") ; lblDaysOfMonth.Text=   (arln == 0 ? "  عدد الأيام في الشهر :  " : "  Number of days in a month:") ; label1.Text=   (arln == 0 ? "  نوع الخصم :  " : "  Discount type:") ; label12.Text=   (arln == 0 ? "  الموظف :  " : "  employee:") ; label54.Text=   (arln == 0 ? "  التاريخ :  " : "  Date :") ; label38.Text=   (arln == 0 ? "  الكود :  " : "  Code:") ; superTabControl_Main1.Text=   (arln == 0 ? "  superTabControl3  " : "  superTabControl3") ; Button_Close.Text=   (arln == 0 ? "  إغلاق  " : "  Close") ; buttonItem_DisGeneral.Text=   (arln == 0 ? "  تعميم  " : "  Generalization") ; Button_Search.Text=   (arln == 0 ? "  بحث  " : "  Search") ; Button_Delete.Text=   (arln == 0 ? "  حذف  " : "  delete") ; Button_Save.Text=   (arln == 0 ? "  حفظ  " : "  save") ; Button_Add.Text=   (arln == 0 ? "  إضافة  " : "  addition") ; superTabControl_Main2.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; Button_First.Text=   (arln == 0 ? "  الأول  " : "  the first") ; Button_Prev.Text=   (arln == 0 ? "  السابق  " : "  the previous") ; lable_Records.Text=   (arln == 0 ? "  ---  " : "  ---") ; Button_Next.Text=   (arln == 0 ? "  التالي  " : "  next one") ; Button_Last.Text=   (arln == 0 ? "  الأخير  " : "  the last one") ; buttonItem_Late.Text=   (arln == 0 ? "  سجلات التأخير  " : "  delay records") ; buttonItem_Sleep.Text=   (arln == 0 ? "  سجلات الغيـاب  " : "  Absence records") ; buttonItem_SaveLate.Text=   (arln == 0 ? "  خصــــــم  " : "  discount") ; buttonItem_SaveAll.Text=   (arln == 0 ? "  خصـم الكـل  " : "  discount all") ; buttonItem_Exit.Text=   (arln == 0 ? "  الرجــــوع  " : "  Back") ; panelEx2.Text=   (arln == 0 ? "  Click to collapse  " : "  Click to collapse") ; DGV_Main.Text=   (arln == 0 ? "    " : "    ") ; DGV_Main.Text=   (arln == 0 ? "  جميــع السجــــلات  " : "  All records") ; DGV_Main.Text=   (arln == 0 ? "    " : "    ") ; panelEx3.Text=   (arln == 0 ? "  Fill Panel  " : "  Fill Panel") ; superTabControl_DGV.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; textBox_search.Text=   (arln == 0 ? "  ...  " : "  ...") ; Button_ExportTable2.Text=   (arln == 0 ? "  تصدير  " : "  Export") ; /*Button_PrintTable.Text=   (arln == 0 ? "  طباعة  " : "  Print") ; */ToolStripMenuItem_Rep.Text=   (arln == 0 ? "  إظهار التقرير  " : "  Show report") ; ToolStripMenuItem_Det.Text=   (arln == 0 ? "  إظهار التفاصيل  " : "  Show details") ; Text = "كــــــرت الخصــــــم";this.Text=   (arln == 0 ? "  كــــــرت الخصــــــم  " : "  discount card") ;}
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
        public class ColumnDictinary_Dis
        {
            public string EmpNo;
            public ColumnDictinary_Dis(string empNo)
            {
                EmpNo = empNo;
            }
        }
        private Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private Dictionary<string, ColumnDictinary> Dir_ButSearch = new Dictionary<string, ColumnDictinary>();
        public Dictionary<string, ColumnDictinary_Dis> FlagLte = new Dictionary<string, ColumnDictinary_Dis>();
        public Dictionary<string, ColumnDictinary_Dis> FlagSlp = new Dictionary<string, ColumnDictinary_Dis>();
        public Dictionary<string, ColumnDictinary_Dis> FlagEmp = new Dictionary<string, ColumnDictinary_Dis>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private T_AccDef _AccDefBind = new T_AccDef();
        private int LangArEn = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
#pragma warning disable CS0414 // The field 'FrmDiscount.FlagUpdate' is assigned but its value is never used
        private string FlagUpdate = "";
#pragma warning restore CS0414 // The field 'FrmDiscount.FlagUpdate' is assigned but its value is never used
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstance;
        private T_SalDiscount data_this;
        private T_AttendOperat data_this_op;
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
        private string salDt;
        private bool vRequst = false;
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
                        frm.Repvalue = "DisRep";
                        frm.Repvalue = "DisRep";
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
        private Label label_lblDaysOfMonth;
        private Label label9;
        private DoubleInput textBox_SubTotaly;
        private DoubleInput textBox_SubValue;
        private Label label8;
        private Label lblValue;
        private DoubleInput textBox_Count;
        private Label lblNumber;
        private ComboBoxEx comboBox_CalculateNo;
        private Label label2;
        private IntegerInput textBox_DayOfMonth;
        private Label lblDaysOfMonth;
        private ComboBoxEx comboBox_SubTyp;
        private Label label1;
        private ComboBoxEx comboBox_EmpNo;
        private ButtonX button_SrchEmp;
        private Label label12;
        private MaskedTextBox dateTimeInput_warnDate;
        private Label label54;
        protected TextBox textBox_ID;
        protected Label label38;
        private SwitchButton switchButton_Sts;
        private TextBoxX textBox_Note;
        protected RibbonBar ribbonBar_FlagCalclatLate;
        protected ButtonItem buttonItem_Late;
        protected ButtonItem buttonItem_Sleep;
        protected LabelItem labelItem4;
        protected LabelItem labelItem5;
        protected LabelItem labelItem8;
        protected LabelItem labelItem6;
        protected ButtonItem buttonItem_SaveLate;
        protected ButtonItem buttonItem_SaveAll;
        protected ButtonItem buttonItem_Exit;
        private ComboBox comboBox_AmontSleep;
        private ComboBox comboBox_AmontLate;
        protected ButtonItem buttonItem_DisGeneral;
        private LabelItem lable_Records;
        private CheckBox checkBox_Minute;
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
        public T_SalDiscount DataThis
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
        public T_AttendOperat Data_this_op
        {
            get
            {
                return data_this_op;
            }
            set
            {
                data_this_op = value;
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
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_MovStr, 5))
                    {
                        IfAdd = false;
                    }
                    else
                    {
                        IfAdd = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_MovStr, 6) || switchButton_Sts.Value)
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_MovStr, 7) || switchButton_Sts.Value)
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
        public string SalDt
        {
            get
            {
                return salDt;
            }
            set
            {
                salDt = value;
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
            VarGeneral.SFrmTyp = "T_SalDiscount";
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
            List<T_SalDiscount> list = db.FillSalDiscount_2(textBox_search.TextBox.Text).ToList();
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                }
            }
            FillHDGV(list);
        }
        public void FillHDGV(IEnumerable<T_SalDiscount> new_data_enum)
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
            DGV_Main.PrimaryGrid.DataMember = "T_SalDiscount";
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
            comboBox_EmpNo.SelectedValueChanged -= comboBox_EmpNo_SelectedValueChanged;
            comboBox_EmpNo.DataSource = listEmps;
            comboBox_EmpNo.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_EmpNo.ValueMember = "Emp_ID";
            comboBox_EmpNo.SelectedValueChanged += comboBox_EmpNo_SelectedValueChanged;
            List<T_OpMethod> listOpMethod = new List<T_OpMethod>((from item in db.T_OpMethods
                                                                  orderby item.Method_No
                                                                  where item.Method_No != 7 && item.Method_No != 8 && item.Method_No != 9 && item.Method_No != 10 && item.Method_No != 10 && item.Method_No != 11 && item.Method_No != 12 && item.Method_No != 13
                                                                  select item).ToList());
            comboBox_CalculateNo.DataSource = listOpMethod;
            comboBox_CalculateNo.DisplayMember = ((LangArEn == 0) ? "Name" : "NameE");
            comboBox_CalculateNo.ValueMember = "Method_No";
            List<T_SubTyp> listSubTyp = new List<T_SubTyp>(db.T_SubTyps.Select((T_SubTyp item) => item).ToList());
            comboBox_SubTyp.DataSource = listSubTyp;
            comboBox_SubTyp.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_SubTyp.ValueMember = "SubNo";
            comboBox_SubTyp.SelectedIndex = -1;
        }
        public void Clear()
        {
            if (State == FormState.New)
            {
                return;
            }
            State = FormState.New;
            data_this = new T_SalDiscount();
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
            Guid id = Guid.NewGuid();
            textBox_ID.Tag = id.ToString();
            checkBox_Minute.Checked = false;
            checkBox_Minute.Visible = false;
            comboBox_SubTyp.SelectedIndex = -1;
            comboBox_SubTyp.SelectedIndex = 0;
            switchButton_Sts.Value = false;
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
        private void textBox_NameA_Enter(object sender, EventArgs e)
        {
            Framework.Keyboard.Language.Switch("Arabic");
        }
        private void textBox_NameE_Enter(object sender, EventArgs e)
        {
            Framework.Keyboard.Language.Switch("English");
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
            else if (e.KeyCode == Keys.F6 && buttonItem_DisGeneral.Enabled && buttonItem_DisGeneral.Visible && State == FormState.Saved)
            {
                buttonItem_DisGeneral_Click(sender, e);
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
            var qkeys = db.T_SalDiscounts.Select((T_SalDiscount item) => new
            {
                Code = item.warnNo + ""
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
        public FrmDiscount()
        {
            InitializeComponent();this.Load += langloads;
            ADD_Controls();
            textBox_ID.KeyPress += textBox_ID_KeyPress;
            Button_Close.Click += Button_Close_Click;
            textBox_Count.Click += Button_Edit_Click;
            textBox_DayOfMonth.Click += Button_Edit_Click;
            textBox_Note.Click += Button_Edit_Click;
            textBox_SalDate.Click += Button_Edit_Click;
            textBox_SubTotaly.Click += Button_Edit_Click;
            textBox_SubValue.Click += Button_Edit_Click;
            textBox_ID.Click += Button_Edit_Click;
            comboBox_CalculateNo.Click += Button_Edit_Click;
            comboBox_EmpNo.Click += Button_Edit_Click;
            comboBox_SubTyp.Click += Button_Edit_Click;
            checkBox_Minute.Click += Button_Edit_Click;
            dateTimeInput_warnDate.MouseDown += Button_Edit_Click;
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmDiscount));
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
                Button_PrintTable.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "طباعة" : "عــرض");
                Button_PrintTable.Tooltip = "F5";
                Button_ExportTable2.Text = "تصدير";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "جميع السجلات";
                buttonItem_Exit.Text = "إغلاق";
                buttonItem_SaveLate.Text = "خصــــــم";
                buttonItem_SaveAll.Text = "خصـم الكـل";
                buttonItem_Late.Text = "سجلات التأخير";
                buttonItem_Late.Text = "سجلات الغياب";
                label38.Text = "الكود :";
                textBox_Note.WatermarkText = "ملاحظـــــــات الخصــــم";
                buttonItem_DisGeneral.Text = "تعميم";
                buttonItem_DisGeneral.Tooltip = "F6";
                Text = "كـرت الخصـــــم";
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
                Button_PrintTable.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "Print" : "Show");
                Button_PrintTable.Tooltip = "F5";
                Button_ExportTable2.Text = "Export";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "All Records";
                buttonItem_Exit.Text = "Close";
                buttonItem_SaveLate.Text = "Discount";
                buttonItem_SaveAll.Text = "ALL Discount";
                buttonItem_Late.Text = "Delay Records";
                buttonItem_Late.Text = "Absence Records";
                label38.Text = "Code :";
                textBox_Note.WatermarkText = "Notes";
                buttonItem_DisGeneral.Text = "Generalization";
                buttonItem_DisGeneral.Tooltip = "F6";
                Text = "Discount Card";
            }
        }
        private void FrmDiscount_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmDiscount));
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
                if (!VarGeneral.FlagDis)
                {
                    FillCombo();
                    DiscoundLate_Auto();
                    buttonItem_SaveAll.Enabled = false;
                    buttonItem_SaveLate.Enabled = false;
                    buttonItem_Sleep_Click(sender, e);
                    buttonItem_Late_Click(sender, e);
                    expandableSplitter1.Expandable = false;
                }
                else
                {
                    if (columns_Names_visible.Count == 0)
                    {
                        columns_Names_visible.Add("warnNo", new ColumnDictinary("الرقم", "No", ifDefault: true, ""));
                        columns_Names_visible.Add("warnDate", new ColumnDictinary("التاريخ", "Date", ifDefault: true, ""));
                        columns_Names_visible.Add("EmpNm", new ColumnDictinary("اسم الموظف", "Employee Name", ifDefault: false, ""));
                        columns_Names_visible.Add("Emp_No", new ColumnDictinary("رقم الموظف", "Employee No", ifDefault: false, ""));
                        columns_Names_visible.Add("SalDate", new ColumnDictinary("يخصم من شهر", "Discounted To Month", ifDefault: false, ""));
                        columns_Names_visible.Add("SubValue", new ColumnDictinary("قيمة الخصم", " Discounted Value", ifDefault: true, ""));
                        columns_Names_visible.Add("ACount", new ColumnDictinary("العدد", "Count", ifDefault: true, ""));
                        columns_Names_visible.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, ""));
                    }
                    else
                    {
                        Clear();
                        textBox_ID.Text = "";
                        TextBox_Index.TextBox.Text = "";
                    }
                    FillCombo();
                    RefreshPKeys();
                    textBox_ID.Text = PKeys.FirstOrDefault();
                    ViewDetails_Click(sender, e);
                }
                RibunButtons();
                Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
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
            try
            {
                T_SalDiscount newData = db.SalDiscountEmp(no);
                if (newData == null || newData.warnNo == 0 || string.IsNullOrEmpty(newData.Discont_ID))
                {
                    if (!Button_Add.Visible || !Button_Add.Enabled)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textBox_ID.TextChanged -= textBox_ID_TextChanged;
                        try
                        {
                            textBox_ID.Text = data_this.warnNo.ToString();
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
                    int indexA = PKeys.IndexOf(string.Concat(newData.warnNo));
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
        public void SetData(T_SalDiscount value)
        {
            State = FormState.Saved;
            Button_Save.Enabled = false;
            textBox_Note.Text = value.Note;
            textBox_ID.Tag = value.Discont_ID;
            textBox_SalDate.Text = value.SalDate;
            checkBox_Minute.CheckedChanged -= checkBox_Minute_CheckedChanged;
            if (value.MinuteTyp.HasValue)
            {
                checkBox_Minute.Checked = value.MinuteTyp.Value;
            }
            else
            {
                checkBox_Minute.Checked = false;
            }
            checkBox_Minute.CheckedChanged += checkBox_Minute_CheckedChanged;
            try
            {
                if (VarGeneral.CheckDate(value.warnDate))
                {
                    dateTimeInput_warnDate.Text = Convert.ToDateTime(value.warnDate).ToString("yyyy/MM/dd");
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
            try
            {
                textBox_Count.Value = value.ACount.Value;
            }
            catch
            {
                textBox_Count.Value = 0.0;
            }
            try
            {
                textBox_SubValue.Value = value.SubValue.Value;
            }
            catch
            {
                textBox_SubValue.Value = 0.0;
            }
            try
            {
                textBox_SubTotaly.Value = value.SubTotaly.Value;
            }
            catch
            {
                textBox_SubTotaly.Value = 0.0;
            }
            if (value.IFState.HasValue)
            {
                switchButton_Sts.Value = value.IFState.Value;
            }
            else
            {
                switchButton_Sts.Value = false;
            }
            if (!string.IsNullOrEmpty(value.EmpID))
            {
                comboBox_EmpNo.SelectedValue = value.EmpID;
            }
            if (value.SubTyp.HasValue)
            {
                comboBox_SubTyp.SelectedValue = value.SubTyp;
            }
            if (value.CalculateNo.HasValue)
            {
                comboBox_CalculateNo.SelectedValue = value.CalculateNo;
            }
            try
            {
                textBox_DayOfMonth.Value = value.DayOfMonth.Value;
            }
            catch
            {
                textBox_DayOfMonth.Value = 0;
            }
            try
            {
                if (value.SubTyp.Value == 3 || value.SubTyp.Value == 4)
                {
                    lblNumber.Text = ((LangArEn == 0) ? "قيمة الخصم :" : "Value");
                    lblValue.Visible = false;
                    textBox_SubValue.Visible = false;
                }
            }
            catch
            {
            }
            try
            {
                switch (comboBox_SubTyp.SelectedIndex)
                {
                    case 0:
                        lblNumber.Text = ((LangArEn == 0) ? "العـدد :" : "Count :");
                        lblValue.Text = ((LangArEn == 0) ? "قيمة الخصم :" : "Value :");
                        lblValue.Visible = true;
                        textBox_SubValue.Visible = true;
                        break;
                    case 1:
                        lblNumber.Text = ((LangArEn == 0) ? "العـدد :" : "Count");
                        lblValue.Text = ((LangArEn == 0) ? "قيمة الخصم :" : "Value");
                        lblValue.Visible = true;
                        textBox_SubValue.Visible = true;
                        break;
                    case 2:
                    case 3:
                        lblNumber.Text = ((LangArEn == 0) ? "قيمة الخصم :" : "Value");
                        lblValue.Visible = false;
                        textBox_SubValue.Visible = false;
                        break;
                }
            }
            catch
            {
            }
            SetReadOnly = true;
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
        private T_SalDiscount GetData()
        {
            textBox_ID.Focus();
            try
            {
                data_this.warnNo = int.Parse(textBox_ID.Text);
            }
            catch
            {
            }
            try
            {
                data_this.ACount = textBox_Count.Value;
            }
            catch
            {
                data_this.ACount = 0.0;
            }
            try
            {
                data_this.DayOfMonth = textBox_DayOfMonth.Value;
            }
            catch
            {
                data_this.DayOfMonth = 0;
            }
            data_this.Note = textBox_Note.Text;
            try
            {
                data_this.SalDate = Convert.ToDateTime(textBox_SalDate.Text).ToString("yyyy/MM");
            }
            catch
            {
                data_this.SalDate = DateTime.Now.ToString("yyyy/MM");
            }
            data_this.MinuteTyp = checkBox_Minute.Checked;
            try
            {
                data_this.SubValue = textBox_SubValue.Value;
            }
            catch
            {
                data_this.SubValue = 0.0;
            }
            try
            {
                data_this.SubTotaly = textBox_SubTotaly.Value;
            }
            catch
            {
                data_this.SubTotaly = 0.0;
            }
            try
            {
                data_this.EmpID = comboBox_EmpNo.SelectedValue.ToString();
            }
            catch
            {
                data_this.EmpID = null;
            }
            try
            {
                data_this.CalculateNo = int.Parse(comboBox_CalculateNo.SelectedValue.ToString());
            }
            catch
            {
                data_this.CalculateNo = null;
            }
            try
            {
                data_this.SubTyp = int.Parse(comboBox_SubTyp.SelectedValue.ToString());
            }
            catch
            {
                data_this.SubTyp = null;
            }
            try
            {
                data_this.warnDate = Convert.ToDateTime(dateTimeInput_warnDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_warnDate.Text = "";
                data_this.warnDate = "";
            }
            try
            {
                data_this.IFState = switchButton_Sts.Value;
            }
            catch
            {
                data_this.IFState = false;
            }
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
            if (!Button_Add.Visible || !Button_Add.Enabled)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (State != FormState.Edit || MessageBox.Show((LangArEn == 0) ? "تم تعديل السجل الحالي دون حفظ التغييرات .. هل تريد المتابعة؟" : "Not saved the changes, do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                int max = 0;
                max = db.MaxSalDiscountNo;
                textBox_ID.Text = max.ToString();
                Clear();
                State = FormState.New;
            }
        }
        private void Button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                vRequst = false;
                if (!ValidData())
                {
                    return;
                }
                if (State == FormState.New)
                {
                    try
                    {
                        GetData();
                        data_this.Discont_ID = textBox_ID.Tag.ToString();
                        db.T_SalDiscounts.InsertOnSubmit(data_this);
                        db.SubmitChanges();
                    }
                    catch (SqlException error2)
                    {
                        int max = 0;
                        max = db.MaxSalDiscountNo;
                        if (error2.Number == 2627)
                        {
                            MessageBox.Show((LangArEn == 0) ? ("رقم الأمر مستخدم من قبل.\nسيتم الحفظ برقم جديد [" + max + "]") : ("This No is user before.\nWill be save a new number [" + max + "]"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            textBox_ID.TextChanged -= textBox_ID_TextChanged;
                            textBox_ID.Text = string.Concat(max);
                            textBox_ID.TextChanged += textBox_ID_TextChanged;
                            data_this.warnNo = max;
                            Button_Save_Click(sender, e);
                        }
                        else
                        {
                            VarGeneral.DebLog.writeLog("Button_Save_Click:", error2, enable: true);
                            MessageBox.Show(error2.Message);
                        }
                        return;
                    }
                }
                else if (State == FormState.Edit)
                {
                    GetData();
                    db.Log = VarGeneral.DebugLog;
                    db.SubmitChanges(ConflictMode.ContinueOnConflict);
                }
                State = FormState.Saved;
                RefreshPKeys();
                TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(string.Concat(data_this.warnNo)) + 1);
                SetReadOnly = true;
                vRequst = true;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Button_Save_Click:", error, enable: true);
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
                if (data_this != null && data_this.warnNo != 0 && !string.IsNullOrEmpty(data_this.Discont_ID) && ifOkDelete)
                {
                    data_this = db.SalDiscountEmp(DataThis.warnNo);
                    db.T_SalDiscounts.DeleteOnSubmit(DataThis);
                    db.SubmitChanges();
                    Clear();
                    RefreshPKeys();
                    textBox_ID.Text = PKeys.LastOrDefault();
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Button_Delete_Click:", error, enable: true);
                MessageBox.Show(error.Message);
                DataThis = db.SalDiscountEmp(DataThis.warnNo);
            }
        }
        private void DGV_Main_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            string dataMember = panel.DataMember;
            if (dataMember != null && dataMember == "T_SalDiscount")
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
            panel.Columns["warnNo"].Width = 120;
            panel.Columns["warnNo"].Visible = columns_Names_visible["warnNo"].IfDefault;
            panel.Columns["warnDate"].Width = 120;
            panel.Columns["warnDate"].Visible = columns_Names_visible["warnDate"].IfDefault;
            panel.Columns["Emp_No"].Width = 120;
            panel.Columns["Emp_No"].Visible = columns_Names_visible["Emp_No"].IfDefault;
            panel.Columns["EmpNm"].Width = 250;
            panel.Columns["EmpNm"].Visible = columns_Names_visible["EmpNm"].IfDefault;
            panel.Columns["SalDate"].Width = 100;
            panel.Columns["SalDate"].Visible = columns_Names_visible["SalDate"].IfDefault;
            panel.Columns["SubValue"].Width = 120;
            panel.Columns["SubValue"].Visible = columns_Names_visible["SubValue"].IfDefault;
            panel.Columns["ACount"].Width = 150;
            panel.Columns["ACount"].Visible = columns_Names_visible["ACount"].IfDefault;
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
                ExportExcel.ExportToExcel(DGV_Main, "تقرير الخصومات");
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
                controls.Add(textBox_Count);
                controls.Add(textBox_DayOfMonth);
                controls.Add(textBox_Note);
                controls.Add(textBox_SalDate);
                controls.Add(textBox_SubTotaly);
                controls.Add(textBox_SubValue);
                controls.Add(switchButton_Sts);
                controls.Add(comboBox_CalculateNo);
                controls.Add(comboBox_EmpNo);
                controls.Add(comboBox_SubTyp);
                controls.Add(dateTimeInput_warnDate);
                controls.Add(comboBox_AmontLate);
                controls.Add(comboBox_AmontSleep);
                controls.Add(checkBox_Minute);
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
                textBox_DayOfMonth.Enabled = false;
                if (VarGeneral.CheckDate(textBox_SalDate.Text))
                {
                    textBox_SalDate.Text = Convert.ToDateTime(textBox_SalDate.Text).ToString("yyyy/MM");
                }
                else
                {
                    textBox_DayOfMonth.Value = 1;
                    int? calendr = VarGeneral.Settings_Sys.Calendr;
                    if (calendr.Value == 0 && calendr.HasValue)
                    {
                        textBox_SalDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM");
                    }
                    else
                    {
                        textBox_SalDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM");
                    }
                }
                textBox_DayOfMonth.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textBox_SalDate.Text + "/01").ToString("yyyy/MM/dd"), GetDefault: true);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("textBox_SalDate_Leave:", error, enable: true);
            }
        }
        private void textBox_Count_Leave(object sender, EventArgs e)
        {
        }
        private void textBox_SubValue_Leave(object sender, EventArgs e)
        {
            try
            {
                textBox_SubTotaly.Value = textBox_Count.Value * textBox_SubValue.Value;
            }
            catch
            {
                textBox_SubTotaly.Value = 0.0;
            }
        }
        private bool ValidData()
        {
            try
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
                textBox_ID.Focus();
                if (textBox_ID.Text == "")
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب تحديد الرقم " : "Must Set the order number", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_ID.Focus();
                    return false;
                }
                T_SalDiscount q = db.SalDiscountEmp(int.Parse(textBox_ID.Text));
                if (!string.IsNullOrEmpty(q.Discont_ID) && State == FormState.New)
                {
                    MessageBox.Show((LangArEn == 0) ? " الرقم  موجود من قبل" : " No It's a existing", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_ID.Focus();
                    return false;
                }
                if (textBox_Count.Value <= 0.0)
                {
                    MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من قيمة العدد" : "Most Set Value For Count", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_Count.Focus();
                    return false;
                }
                if (textBox_SubTotaly.Value <= 0.0)
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من اجمالي الخصم" : "Must be a total discount is greater than zero", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_SubValue.Focus();
                    return false;
                }
                if (comboBox_EmpNo.Items.Count <= 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب تحديد موظف" : "Most Select Employee", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    comboBox_EmpNo.Focus();
                    return false;
                }
                if (textBox_SalDate.Text.Trim().Length != 7)
                {
                    MessageBox.Show((LangArEn == 0) ? "تاكد من تاريخ شهر الخصم" : "Make sure the date of salary", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_SalDate.Focus();
                    return false;
                }
                if (dateTimeInput_warnDate.Text.Length != 10)
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب تحديد التاريخ " : "You must specify the date", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    dateTimeInput_warnDate.Focus();
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
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("ValidData:", error, enable: true);
                MessageBox.Show(error.Message);
                return false;
            }
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
        private void comboBox_SubTyp_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_SubTyp.SelectedIndex == 1 && VarGeneral.FlagDis)
                {
                    checkBox_Minute.Visible = false;
                }
                else
                {
                    checkBox_Minute.Visible = false;
                }
                if (comboBox_SubTyp.SelectedIndex == 0)
                {
                    label1.Visible = true;
                    label1.Text = ((LangArEn == 0) ? "يـــــوم" : "Day");
                }
                else if (comboBox_SubTyp.SelectedIndex == 1)
                {
                    label1.Visible = true;
                    if (checkBox_Minute.Checked)
                    {
                        label1.Text = ((LangArEn == 0) ? "دقيقة" : "Minute");
                    }
                    else
                    {
                        label1.Text = ((LangArEn == 0) ? "ساعة" : "Hour");
                    }
                }
                else
                {
                    label1.Visible = false;
                }
                if (State == FormState.Saved || comboBox_EmpNo.SelectedIndex == -1 || comboBox_SubTyp.SelectedIndex == -1)
                {
                    return;
                }
                if (comboBox_SubTyp.SelectedIndex == 0 || comboBox_SubTyp.SelectedIndex == 1)
                {
                    comboBox_CalculateNo.Enabled = true;
                    textBox_DayOfMonth.Enabled = true;
                    label2.Enabled = true;
                    lblDaysOfMonth.Enabled = true;
                }
                else
                {
                    comboBox_CalculateNo.Enabled = false;
                    textBox_DayOfMonth.Enabled = false;
                    label2.Enabled = false;
                    lblDaysOfMonth.Enabled = false;
                }
                switch (comboBox_SubTyp.SelectedIndex)
                {
                    case 0:
                        lblNumber.Text = ((LangArEn == 0) ? "العـدد :" : "Count :");
                        lblValue.Text = ((LangArEn == 0) ? "القيمـة :" : "Value :");
                        lblValue.Visible = true;
                        textBox_SubValue.Visible = true;
                        textBox_SubValue.Value = 0.0;
                        textBox_SubValue.Value = GetDeductionValue(comboBox_EmpNo.SelectedValue.ToString());
                        break;
                    case 1:
                        lblNumber.Text = ((LangArEn == 0) ? "العـدد :" : "Count");
                        lblValue.Text = ((LangArEn == 0) ? "القيمـة :" : "Value");
                        lblValue.Visible = true;
                        textBox_SubValue.Visible = true;
                        textBox_SubValue.Value = 0.0;
                        if (checkBox_Minute.Checked && comboBox_SubTyp.SelectedIndex == 1)
                        {
                            textBox_SubValue.Value = GetDeductionValue(comboBox_EmpNo.SelectedValue.ToString()) / 60.0;
                        }
                        else
                        {
                            textBox_SubValue.Value = GetDeductionValue(comboBox_EmpNo.SelectedValue.ToString());
                        }
                        break;
                    case 2:
                    case 3:
                        lblNumber.Text = ((LangArEn == 0) ? "القيمـة :" : "Value");
                        lblValue.Visible = false;
                        textBox_SubValue.Visible = false;
                        textBox_SubValue.Value = 1.0;
                        break;
                }
                if (comboBox_CalculateNo.SelectedIndex == -1)
                {
                    comboBox_CalculateNo.SelectedIndex = 0;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("ComboBox_SubTyp_SelectedValueChanged:", error, enable: true);
            }
        }
        private void checkBox_Minute_CheckedChanged(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            comboBox_SubTyp_SelectedValueChanged(sender, e);
        }
        private double GetDeductionValue(string EmpID)
        {
            try
            {
                T_Emp newData = db.EmpsEmp(EmpID);
                if ((newData != null || newData.Emp_ID != "") && newData.MainSal.Value > 0.0)
                {
                    if (comboBox_SubTyp.SelectedValue.ToString() == "1")
                    {
                        switch (comboBox_CalculateNo.SelectedIndex)
                        {
                            case 0:
                                return Math.Round(newData.DisOneDay.Value, 2);
                            case 1:
                                return Math.Round(newData.MainSal.Value / (double)textBox_DayOfMonth.Value, 2);
                            case 2:
                                if (newData.HousingAllowance.Value > 0.0)
                                {
                                    return Math.Round((newData.HousingAllowance.Value / 12.0 + newData.MainSal.Value) / (double)textBox_DayOfMonth.Value, 2);
                                }
                                return Math.Round(newData.MainSal.Value / (double)textBox_DayOfMonth.Value, 2);
                            case 3:
                                {
                                    double I = 0.0;
                                    if (newData.HousingAllowance.Value > 0.0)
                                    {
                                        I = newData.HousingAllowance.Value / 12.0;
                                    }
                                    I += newData.MainSal.Value;
                                    I = I + newData.TransferAllowance.Value + newData.SubsistenceAllowance.Value + newData.NaturalWorkAllowance.Value + newData.OtherAllowance.Value;
                                    return Math.Round(I / (double)textBox_DayOfMonth.Value, 2);
                                }
                            case 4:
                                {
                                    double I = 0.0;
                                    if (newData.HousingAllowance.Value > 0.0)
                                    {
                                        I = newData.HousingAllowance.Value / 12.0;
                                    }
                                    I += newData.MainSal.Value;
                                    I += newData.TransferAllowance.Value;
                                    return Math.Round(I / (double)textBox_DayOfMonth.Value, 2);
                                }
                            case 5:
                                {
                                    double I = newData.MainSal.Value;
                                    I += newData.SubsistenceAllowance.Value;
                                    return Math.Round(I / (double)textBox_DayOfMonth.Value, 2);
                                }
                        }
                    }
                    else if (comboBox_SubTyp.SelectedValue.ToString() == "2")
                    {
                        switch (comboBox_CalculateNo.SelectedIndex)
                        {
                            case 0:
                                return Math.Round(newData.LateHours.Value, 2);
                            case 1:
                                {
                                    double I = Math.Round(newData.MainSal.Value / (double)textBox_DayOfMonth.Value, 2);
                                    return Math.Round(I / newData.WorkHours.Value, 2);
                                }
                            case 2:
                                {
                                    double I;
                                    if (newData.HousingAllowance.Value > 0.0)
                                    {
                                        I = Math.Round((newData.HousingAllowance.Value / 12.0 + newData.MainSal.Value) / (double)textBox_DayOfMonth.Value, 2);
                                        return Math.Round(I / newData.WorkHours.Value, 2);
                                    }
                                    I = Math.Round(newData.MainSal.Value / (double)textBox_DayOfMonth.Value, 2);
                                    return Math.Round(I / newData.WorkHours.Value, 2);
                                }
                            case 3:
                                {
                                    double I = 0.0;
                                    if (newData.HousingAllowance.Value > 0.0)
                                    {
                                        I = newData.HousingAllowance.Value / 12.0;
                                    }
                                    I += newData.MainSal.Value;
                                    I = I + newData.TransferAllowance.Value + newData.SubsistenceAllowance.Value + newData.NaturalWorkAllowance.Value + newData.OtherAllowance.Value;
                                    I /= (double)textBox_DayOfMonth.Value;
                                    return Math.Round(I / newData.WorkHours.Value, 2);
                                }
                            case 4:
                                {
                                    double I = 0.0;
                                    if (newData.HousingAllowance.Value > 0.0)
                                    {
                                        I = newData.HousingAllowance.Value / 12.0;
                                    }
                                    I += newData.MainSal.Value;
                                    I += newData.TransferAllowance.Value;
                                    I /= (double)textBox_DayOfMonth.Value;
                                    return Math.Round(I / newData.WorkHours.Value, 2);
                                }
                            case 5:
                                {
                                    double I = newData.MainSal.Value;
                                    I += newData.SubsistenceAllowance.Value;
                                    I /= (double)textBox_DayOfMonth.Value;
                                    return Math.Round(I / newData.WorkHours.Value, 2);
                                }
                        }
                    }
                }
                return 0.0;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("GetDeductionValue:", error, enable: true);
                MessageBox.Show(error.Message);
                return 0.0;
            }
        }
        private void comboBox_CalculateNo_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (State == FormState.Saved)
                {
                    return;
                }
                if (comboBox_CalculateNo.SelectedIndex != 0)
                {
                    if (!string.IsNullOrEmpty(textBox_SalDate.Text) && textBox_SalDate.Text.Length == 7 && textBox_SalDate.Text != "__/____")
                    {
                        textBox_DayOfMonth.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textBox_SalDate.Text + "/01").ToString("yyyy/MM/dd"), GetDefault: false);
                        lblDaysOfMonth.Enabled = true;
                        textBox_DayOfMonth.Enabled = true;
                    }
                    else
                    {
                        lblDaysOfMonth.Enabled = false;
                        textBox_DayOfMonth.Enabled = false;
                        comboBox_CalculateNo.SelectedIndex = 0;
                    }
                }
                else
                {
                    lblDaysOfMonth.Enabled = false;
                    textBox_DayOfMonth.Enabled = false;
                }
                comboBox_SubTyp_SelectedValueChanged(sender, e);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("comboBox_CalculateNo_SelectedValueChanged:", error, enable: true);
            }
        }
        private void comboBox_EmpNo_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (State == FormState.Saved)
                {
                    return;
                }
                if (VarGeneral.FlagDis)
                {
                    goto IL_00db;
                }
                if (comboBox_EmpNo.SelectedIndex == -1)
                {
                    return;
                }
                if (buttonItem_Late.Checked)
                {
                    if (comboBox_AmontLate.SelectedIndex != -1)
                    {
                        SetComboItem(comboBox_AmontLate, comboBox_EmpNo.SelectedValue.ToString());
                    }
                    try
                    {
                        comboBox_AmontLate_SelectedValueChanged(sender, e);
                    }
                    catch
                    {
                    }
                }
                else
                {
                    if (comboBox_AmontSleep.SelectedIndex != -1)
                    {
                        SetComboItem(comboBox_AmontSleep, comboBox_EmpNo.SelectedValue.ToString());
                    }
                    try
                    {
                        comboBox_AmontSleep_SelectedValueChanged(sender, e);
                    }
                    catch
                    {
                    }
                }
                goto IL_00db;
            IL_00db:
                comboBox_SubTyp_SelectedValueChanged(sender, e);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("comboBox_EmpNo_SelectedValueChanged:", error, enable: true);
            }
        }
        private void SetComboItem(ComboBox Cmbo, string Ind)
        {
            try
            {
                Cmbo.SelectedIndex = -1;
                for (int I = 0; I < Cmbo.Items.Count; I++)
                {
                    comboBox_AmontLate.SelectedValueChanged -= comboBox_AmontLate_SelectedValueChanged;
                    comboBox_AmontSleep.SelectedValueChanged -= comboBox_AmontSleep_SelectedValueChanged;
                    Cmbo.SelectedIndex = I;
                    comboBox_AmontLate.SelectedValueChanged += comboBox_AmontLate_SelectedValueChanged;
                    comboBox_AmontSleep.SelectedValueChanged += comboBox_AmontSleep_SelectedValueChanged;
                    string FlagSubstring = Cmbo.Text.Trim();
                    int ii;
                    for (ii = 0; ii < FlagSubstring.Length && !(FlagSubstring.Substring(ii, 1) == "/"); ii++)
                    {
                    }
                    if (FlagSubstring.Substring(0, ii).Trim() == Ind.Trim())
                    {
                        break;
                    }
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SetComboItem:", error, enable: true);
            }
        }
        private void textBox_Count_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(textBox_Count.Text == ""))
                {
                    double Amount = textBox_Count.Value - textBox_Count.Value;
                    if (textBox_Count.Value < 0.0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "تأكد من صحة قيمة العدد " : "The value of non-logical", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    else if (comboBox_SubTyp.SelectedIndex == 1 && Amount > 0.599)
                    {
                        MessageBox.Show((LangArEn == 0) ? "هناك خطأ في المدخلات ,,  " : "There is an error in the input,", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else if (comboBox_SubTyp.SelectedIndex == 1)
                    {
                        textBox_SubTotaly.Value = Math.Round((textBox_Count.Value + Amount / 60.0 * 100.0) * textBox_SubValue.Value, 2);
                    }
                    else
                    {
                        textBox_SubTotaly.Value = Math.Round(textBox_Count.Value * textBox_SubValue.Value, 2);
                    }
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("textBox_Count_ValueChanged:", error, enable: true);
            }
        }
        private void textBox_SubValue_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(textBox_SubValue.Text == ""))
                {
                    double Amount = textBox_Count.Value - textBox_Count.Value;
                    if (textBox_SubValue.Value < 0.0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "هناك خطأ في المدخلات ,,  " : "There is an error in the input,", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else if (comboBox_SubTyp.SelectedIndex == 1)
                    {
                        textBox_SubTotaly.Value = Math.Round((textBox_Count.Value + Amount / 60.0 * 100.0) * textBox_SubValue.Value, 2);
                    }
                    else
                    {
                        textBox_SubTotaly.Value = Math.Round(textBox_Count.Value * textBox_SubValue.Value, 2);
                    }
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("textBox_SubValue_ValueChanged:", error, enable: true);
            }
        }
        private void textBox_DayOfMonth_ValueChanged(object sender, EventArgs e)
        {
            if (textBox_DayOfMonth.Value > 0 && State != 0)
            {
                comboBox_SubTyp_SelectedValueChanged(sender, e);
            }
        }
        private void buttonItem_Sleep_Click(object sender, EventArgs e)
        {
            try
            {
                buttonItem_SaveAll.Enabled = true;
                buttonItem_SaveLate.Enabled = true;
                buttonItem_Late.Checked = false;
                buttonItem_Sleep.Checked = true;
                if (comboBox_EmpNo.Items.Count > 0 && !vRequst)
                {
                    comboBox_EmpNo.DataSource = null;
                }
                string EmpRef = "";
                textBox_Count.Value = 0.0;
                textBox_SubValue.Value = 0.0;
                for (int i = 0; i < comboBox_AmontSleep.Items.Count; i++)
                {
                    comboBox_AmontSleep.SelectedValueChanged -= comboBox_AmontSleep_SelectedValueChanged;
                    comboBox_AmontSleep.SelectedIndex = i;
                    comboBox_AmontSleep.SelectedValueChanged += comboBox_AmontSleep_SelectedValueChanged;
                    string FlagSubstring = comboBox_AmontSleep.Text.Trim();
                    int I = 0;
                    for (I = 0; I < FlagSubstring.Length && !(FlagSubstring.Substring(I, 1) == "/"); I++)
                    {
                    }
                    if (EmpRef != "")
                    {
                        EmpRef += ",";
                    }
                    EmpRef = EmpRef + "'" + FlagSubstring.Substring(0, I) + "'";
                }
                if (!(EmpRef == ""))
                {
                    string query = "SELECT * FROM T_Emp WHERE EmpState = " + 1 + " AND Emp_ID IN (" + EmpRef + ") ORDER BY [Emp_No]";
                    List<T_Emp> newData = db.ExecuteQuery<T_Emp>(query, new object[0]).ToList();
                    comboBox_EmpNo.DataSource = newData.ToList();
                    comboBox_EmpNo.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
                    comboBox_EmpNo.ValueMember = "Emp_ID";
                    textBox_Note.Text = ((LangArEn == 0) ? "قيمة غياب في شهر " : "Absence for Month ");
                    if (comboBox_EmpNo.Items.Count > 0)
                    {
                        comboBox_EmpNo.SelectedIndex = -1;
                        comboBox_EmpNo.SelectedIndex = 0;
                    }
                    if (comboBox_AmontSleep.Items.Count > 0)
                    {
                        comboBox_AmontSleep.SelectedIndex = -1;
                        comboBox_AmontSleep.SelectedIndex = 0;
                    }
                    if (comboBox_EmpNo.SelectedIndex != -1)
                    {
                        textBox_ID.Text = db.MaxSalDiscountNo.ToString();
                        MaskedTextBox maskedTextBox = dateTimeInput_warnDate;
                        int? calendr = VarGeneral.Settings_Sys.Calendr;
                        maskedTextBox.Text = ((calendr.Value == 0 && calendr.HasValue) ? VarGeneral.Gdate : VarGeneral.Hdate);
                    }
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("buttonItem_Sleep_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void buttonItem_Late_Click(object sender, EventArgs e)
        {
            try
            {
                buttonItem_SaveAll.Enabled = true;
                buttonItem_SaveLate.Enabled = true;
                buttonItem_Late.Checked = true;
                buttonItem_Sleep.Checked = false;
                if (comboBox_EmpNo.Items.Count > 0 && !vRequst)
                {
                    comboBox_EmpNo.DataSource = null;
                }
                string EmpRef = "";
                textBox_Count.Value = 0.0;
                textBox_SubValue.Value = 0.0;
                for (int i = 0; i < comboBox_AmontLate.Items.Count; i++)
                {
                    comboBox_AmontLate.SelectedValueChanged -= comboBox_AmontLate_SelectedValueChanged;
                    comboBox_AmontLate.SelectedIndex = i;
                    comboBox_AmontLate.SelectedValueChanged += comboBox_AmontLate_SelectedValueChanged;
                    string FlagSubstring = comboBox_AmontLate.Text.Trim();
                    int I = 0;
                    for (I = 0; I < FlagSubstring.Length && !(FlagSubstring.Substring(I, 1) == "/"); I++)
                    {
                    }
                    if (EmpRef != "")
                    {
                        EmpRef += ",";
                    }
                    EmpRef = EmpRef + "'" + FlagSubstring.Substring(0, I) + "'";
                }
                if (!(EmpRef == ""))
                {
                    string query = "SELECT * FROM [dbo].[T_Emp] as [t0] WHERE EmpState = " + 1 + " AND Emp_ID in ( " + EmpRef + " ) ORDER BY [Emp_No]";
                    List<T_Emp> newData = db.ExecuteQuery<T_Emp>(query, new object[0]).ToList();
                    comboBox_EmpNo.DataSource = newData.ToList();
                    comboBox_EmpNo.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
                    comboBox_EmpNo.ValueMember = "Emp_ID";
                    textBox_Note.Text = ((LangArEn == 0) ? "قيمة تأخير عن شهر " : "Later for Month ");
                    if (comboBox_EmpNo.Items.Count > 0)
                    {
                        comboBox_EmpNo.SelectedIndex = -1;
                        comboBox_EmpNo.SelectedIndex = 0;
                    }
                    if (comboBox_AmontLate.Items.Count > 0)
                    {
                        comboBox_AmontLate.SelectedIndex = -1;
                        comboBox_AmontLate.SelectedIndex = 0;
                    }
                    if (comboBox_EmpNo.SelectedIndex != -1)
                    {
                        textBox_ID.Text = db.MaxSalDiscountNo.ToString();
                        MaskedTextBox maskedTextBox = dateTimeInput_warnDate;
                        int? calendr = VarGeneral.Settings_Sys.Calendr;
                        maskedTextBox.Text = ((calendr.Value == 0 && calendr.HasValue) ? VarGeneral.Gdate : VarGeneral.Hdate);
                    }
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("buttonItem_Late_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void comboBox_AmontLate_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_AmontLate.SelectedIndex != -1)
                {
                    GetComboItem(comboBox_AmontLate, FlagKind: true);
                    comboBox_SubTyp_SelectedValueChanged(sender, e);
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("comboBox_AmontLate_SelectedValueChanged:", error, enable: true);
            }
        }
        private void comboBox_AmontSleep_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_AmontSleep.SelectedIndex != -1)
                {
                    GetComboItem(comboBox_AmontSleep, FlagKind: false);
                    comboBox_SubTyp_SelectedValueChanged(sender, e);
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("comboBox_AmontSleep_SelectedValueChanged:", error, enable: true);
            }
        }
        private void DiscoundLate_Auto()
        {
            try
            {
                ribbonBar_FlagCalclatLate.Visible = true;
                superTabControl_Main1.Visible = false;
                superTabControl_Main2.Visible = false;
                for (int iiCnt = 0; iiCnt < controls.Count; iiCnt++)
                {
                    if (controls[iiCnt].Name != "textBox_Note" && controls[iiCnt].Name != "dateTimeInput_warnDate" && controls[iiCnt].Name != "textBox_SalDate" && controls[iiCnt].Name != "textBox_DayOfMonth" && controls[iiCnt].Name != "comboBox_CalculateNo" && controls[iiCnt].Name != "comboBox_EmpNo" && controls[iiCnt].Name != "textBox_Count" && controls[iiCnt].Name != "textBox_SubValue")
                    {
                        controls[iiCnt].Enabled = false;
                    }
                    if (controls[iiCnt].Name == "comboBox_CalculateNo" && (controls[iiCnt] as ComboBox).Items.Count > 0)
                    {
                        (controls[iiCnt] as ComboBox).SelectedIndex = 0;
                    }
                }
                MaskedTextBox maskedTextBox = dateTimeInput_warnDate;
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                maskedTextBox.Text = ((calendr.Value == 0 && calendr.HasValue) ? VarGeneral.Gdate : VarGeneral.Hdate);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("DiscoundLate_Auto:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void GetComboItem(ComboBox combX, bool FlagKind)
        {
            try
            {
                if (combX.Items.Count <= 0 || comboBox_SubTyp.Items.Count <= 0)
                {
                    return;
                }
                if (FlagKind)
                {
                    comboBox_SubTyp.SelectedIndex = 1;
                    string FlagSubstring = combX.Text.Trim();
                    int I;
                    for (I = 0; I < FlagSubstring.Length && !(FlagSubstring.Substring(I, 1) == "/"); I++)
                    {
                    }
                    textBox_Count.Text = FlagSubstring.Substring(I + 1).Trim();
                }
                else if (!FlagKind)
                {
                    comboBox_SubTyp.SelectedIndex = 0;
                    string FlagSubstring = combX.Text.Trim();
                    int I;
                    for (I = 0; I < FlagSubstring.Length && !(FlagSubstring.Substring(I, 1) == "/"); I++)
                    {
                    }
                    try
                    {
                        textBox_Count.Text = FlagSubstring.Substring(I + 1).Trim();
                    }
                    catch (Exception error2)
                    {
                        VarGeneral.DebLog.writeLog("GetComboItem:", error2, enable: true);
                    }
                }
            }
            catch (Exception error2)
            {
                VarGeneral.DebLog.writeLog("GetComboItem:", error2, enable: true);
                MessageBox.Show(error2.Message);
            }
        }
        private void buttonItem_SaveLate_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_EmpNo.Items.Count == 0 || comboBox_EmpNo.SelectedIndex == -1)
                {
                    return;
                }
                if (textBox_ID.Text == "")
                {
                    textBox_ID.Text = db.MaxSalDiscountNo.ToString();
                }
                State = FormState.New;
                Button_Save_Click(sender, e);
                if (!vRequst)
                {
                    return;
                }
                vRequst = false;
                if (buttonItem_Sleep.Checked)
                {
                    List<T_AttendOperat> qEmp = db.ExecuteQuery<T_AttendOperat>("Select * from [T_AttendOperat] where [EmpID] = '" + comboBox_EmpNo.SelectedValue.ToString() + "' AND Time1 = 'xxx' AND [Date] Between '" + Convert.ToDateTime(salDt).ToString("yyyy/MM") + "/01' And '" + Convert.ToDateTime(salDt).ToString("yyyy/MM") + "/31'", new object[0]).ToList();
                    if (qEmp.Count > 0)
                    {
                        data_this_op = new T_AttendOperat();
                        for (int i = 0; i < qEmp.Count; i++)
                        {
                            Data_this_op = qEmp[i];
                            data_this_op.Time1 = "x-x";
                            data_this_op.Note = "تحول الى الخصم";
                            db.Log = VarGeneral.DebugLog;
                            db.SubmitChanges(ConflictMode.ContinueOnConflict);
                        }
                    }
                }
                else
                {
                    List<T_AttendOperat> qEmp = db.ExecuteQuery<T_AttendOperat>("Select * from [T_AttendOperat] where [EmpID] = '" + comboBox_EmpNo.SelectedValue.ToString() + "' AND Time1 <> 'xxx' AND [Date] Between '" + Convert.ToDateTime(salDt).ToString("yyyy/MM") + "/01' And '" + Convert.ToDateTime(salDt).ToString("yyyy/MM") + "/31'", new object[0]).ToList();
                    if (qEmp.Count > 0)
                    {
                        data_this_op = new T_AttendOperat();
                        for (int i = 0; i < qEmp.Count; i++)
                        {
                            Data_this_op = qEmp[i];
                            data_this_op.LateTime = 0.0;
                            data_this_op.Note = "تحول الى الخصم";
                            db.Log = VarGeneral.DebugLog;
                            db.SubmitChanges(ConflictMode.ContinueOnConflict);
                        }
                    }
                }
                comboBox_AmontSleep.SelectedValueChanged -= comboBox_AmontSleep_SelectedValueChanged;
                comboBox_AmontLate.SelectedValueChanged -= comboBox_AmontLate_SelectedValueChanged;
                comboBox_EmpNo.SelectedValueChanged -= comboBox_EmpNo_SelectedValueChanged;
                string vDef = comboBox_EmpNo.SelectedValue.ToString();
                if (buttonItem_Late.Checked)
                {
                    foreach (KeyValuePair<string, ColumnDictinary_Dis> kvp in FlagLte)
                    {
                        if (vDef == kvp.Value.EmpNo.ToString())
                        {
                            FlagLte.Remove(kvp.Key);
                            break;
                        }
                    }
                    if (FlagLte.Count > 0)
                    {
                        comboBox_AmontLate.DataSource = new BindingSource(FlagLte, null);
                        comboBox_AmontLate.DisplayMember = "Key";
                        comboBox_AmontLate.ValueMember = "Value";
                    }
                    else
                    {
                        comboBox_EmpNo.DataSource = null;
                        comboBox_AmontLate.DataSource = null;
                        Clear();
                    }
                    vRequst = true;
                    buttonItem_Late_Click(sender, e);
                    vRequst = false;
                }
                else
                {
                    foreach (KeyValuePair<string, ColumnDictinary_Dis> kvp in FlagSlp)
                    {
                        if (vDef == kvp.Value.EmpNo.ToString())
                        {
                            FlagSlp.Remove(kvp.Key);
                            break;
                        }
                    }
                    if (FlagSlp.Count > 0)
                    {
                        comboBox_AmontSleep.DataSource = new BindingSource(FlagSlp, null);
                        comboBox_AmontSleep.DisplayMember = "Key";
                        comboBox_AmontSleep.ValueMember = "Value";
                    }
                    else
                    {
                        comboBox_EmpNo.DataSource = null;
                        comboBox_AmontSleep.DataSource = null;
                        Clear();
                    }
                    vRequst = true;
                    buttonItem_Sleep_Click(sender, e);
                    vRequst = false;
                }
                comboBox_AmontSleep.SelectedValueChanged += comboBox_AmontSleep_SelectedValueChanged;
                comboBox_AmontLate.SelectedValueChanged += comboBox_AmontLate_SelectedValueChanged;
                comboBox_EmpNo.SelectedValueChanged += comboBox_EmpNo_SelectedValueChanged;
                if (comboBox_EmpNo.Items.Count > 0)
                {
                    comboBox_EmpNo.SelectedIndex = -1;
                    comboBox_EmpNo.SelectedIndex = 0;
                    return;
                }
                comboBox_SubTyp.SelectedIndex = -1;
                comboBox_CalculateNo.SelectedIndex = -1;
                textBox_ID.Text = "";
                textBox_Count.Value = 0.0;
                textBox_SubTotaly.Value = 0.0;
                textBox_SubValue.Value = 0.0;
                textBox_Note.Text = "";
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("buttonItem_SaveLate_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void buttonItem_SaveAll_Click(object sender, EventArgs e)
        {
            try
            {
                while (comboBox_EmpNo.Items.Count > 0 && comboBox_EmpNo.Items.Count != 0 && comboBox_EmpNo.SelectedIndex != -1)
                {
                    if (textBox_ID.Text == "")
                    {
                        textBox_ID.Text = db.MaxSalDiscountNo.ToString();
                    }
                    State = FormState.New;
                    Button_Save_Click(sender, e);
                    if (!vRequst)
                    {
                        break;
                    }
                    vRequst = false;
                    if (buttonItem_Sleep.Checked)
                    {
                        List<T_AttendOperat> qEmp = db.ExecuteQuery<T_AttendOperat>("Select * from [T_AttendOperat] where [EmpID] = '" + comboBox_EmpNo.SelectedValue.ToString() + "' AND Time1 = 'xxx' AND Time1 <> '~~~~' AND [Date] Between '" + Convert.ToDateTime(salDt).ToString("yyyy/MM") + "/01' And '" + Convert.ToDateTime(salDt).ToString("yyyy/MM") + "/31'", new object[0]).ToList();
                        if (qEmp.Count > 0)
                        {
                            data_this_op = new T_AttendOperat();
                            for (int i = 0; i < qEmp.Count; i++)
                            {
                                Data_this_op = qEmp[i];
                                data_this_op.Time1 = "x-x";
                                data_this_op.Note = "تحول الى الخصم";
                                db.Log = VarGeneral.DebugLog;
                                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                            }
                        }
                    }
                    else
                    {
                        List<T_AttendOperat> qEmp = db.ExecuteQuery<T_AttendOperat>("Select * from [T_AttendOperat] where [EmpID] = '" + comboBox_EmpNo.SelectedValue.ToString() + "' AND Time1 <> 'xxx' AND Time1 <> '~~~~' AND [Date] Between '" + Convert.ToDateTime(salDt).ToString("yyyy/MM") + "/01' And '" + Convert.ToDateTime(salDt).ToString("yyyy/MM") + "/31'", new object[0]).ToList();
                        if (qEmp.Count > 0)
                        {
                            data_this_op = new T_AttendOperat();
                            for (int i = 0; i < qEmp.Count; i++)
                            {
                                Data_this_op = qEmp[i];
                                data_this_op.LateTime = 0.0;
                                data_this_op.Note = "تحول الى الخصم";
                                db.Log = VarGeneral.DebugLog;
                                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                            }
                        }
                    }
                    comboBox_AmontSleep.SelectedValueChanged -= comboBox_AmontSleep_SelectedValueChanged;
                    comboBox_AmontLate.SelectedValueChanged -= comboBox_AmontLate_SelectedValueChanged;
                    comboBox_EmpNo.SelectedValueChanged -= comboBox_EmpNo_SelectedValueChanged;
                    string vDef = comboBox_EmpNo.SelectedValue.ToString();
                    if (buttonItem_Late.Checked)
                    {
                        foreach (KeyValuePair<string, ColumnDictinary_Dis> kvp in FlagLte)
                        {
                            if (vDef == kvp.Value.EmpNo.ToString())
                            {
                                FlagLte.Remove(kvp.Key);
                            }
                        }
                        if (FlagLte.Count > 0)
                        {
                            comboBox_AmontLate.DataSource = new BindingSource(FlagLte, null);
                            comboBox_AmontLate.DisplayMember = "Key";
                            comboBox_AmontLate.ValueMember = "Value";
                        }
                        else
                        {
                            comboBox_EmpNo.DataSource = null;
                            comboBox_AmontLate.DataSource = null;
                            Clear();
                        }
                        vRequst = true;
                        buttonItem_Late_Click(sender, e);
                        vRequst = false;
                    }
                    else
                    {
                        foreach (KeyValuePair<string, ColumnDictinary_Dis> kvp in FlagSlp)
                        {
                            if (vDef == kvp.Value.EmpNo.ToString())
                            {
                                FlagSlp.Remove(kvp.Key);
                                break;
                            }
                        }
                        if (FlagSlp.Count > 0)
                        {
                            comboBox_AmontSleep.DataSource = new BindingSource(FlagSlp, null);
                            comboBox_AmontSleep.DisplayMember = "Key";
                            comboBox_AmontSleep.ValueMember = "Value";
                        }
                        else
                        {
                            comboBox_EmpNo.DataSource = null;
                            comboBox_AmontSleep.DataSource = null;
                            Clear();
                        }
                        vRequst = true;
                        buttonItem_Sleep_Click(sender, e);
                        vRequst = false;
                    }
                    comboBox_AmontSleep.SelectedValueChanged += comboBox_AmontSleep_SelectedValueChanged;
                    comboBox_AmontLate.SelectedValueChanged += comboBox_AmontLate_SelectedValueChanged;
                    comboBox_EmpNo.SelectedValueChanged += comboBox_EmpNo_SelectedValueChanged;
                    if (comboBox_EmpNo.Items.Count > 0)
                    {
                        comboBox_EmpNo.SelectedIndex = -1;
                        comboBox_EmpNo.SelectedIndex = 0;
                        continue;
                    }
                    comboBox_SubTyp.SelectedIndex = -1;
                    comboBox_CalculateNo.SelectedIndex = -1;
                    textBox_ID.Text = "";
                    textBox_Count.Value = 0.0;
                    textBox_SubTotaly.Value = 0.0;
                    textBox_SubValue.Value = 0.0;
                    textBox_Note.Text = "";
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("buttonItem_SaveAll_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
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
        private void buttonItem_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void buttonItem_DisGeneral_Click(object sender, EventArgs e)
        {
            FrmDisGeneral frm = new FrmDisGeneral();
            frm.Tag = LangArEn;
            frm.TopMost = true;
            frm.ShowDialog();
            dbInstance = null;
            FrmDiscount_Load(null, null);
        }
        private void Button_PrintTable_Click(object sender, EventArgs e)
        {
            VarGeneral.IsGeneralUsed = true;
            FrmReportsViewer frm = new FrmReportsViewer();
            frm.Repvalue = "DisRep";
            frm.Tag = LangArEn;
            frm.Repvalue = "DisRep";
            VarGeneral.vTitle = Text;
            frm.SqlWhere = "";
            frm.TopMost = true;
            frm.ShowDialog();
            VarGeneral.IsGeneralUsed = false;
        }
        private void dateTimeInput_warnDate_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
        }
        private void label54_Click(object sender, EventArgs e)
        {
        }
        private void comboBox_EmpNo_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void label12_Click(object sender, EventArgs e)
        {
        }
        private void label38_Click(object sender, EventArgs e)
        {
        }
    }
}
