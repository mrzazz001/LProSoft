using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
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
    public partial  class FrmCar : Form
    { void avs(int arln)

{ 
 label12.Text=   (arln == 0 ? "  إسم الموظف :  " : "  Employee Name :") ; label2.Text=   (arln == 0 ? "  ماركة السيارة :  " : "  car brand:") ; label3.Text=   (arln == 0 ? "  سنة الصنـــع :  " : "  year of manufacture:") ; label1.Text=   (arln == 0 ? "  اللوحـــــــة :  " : "  The board:") ; label4.Text=   (arln == 0 ? "  اللون  " : "  the color") ; groupBox1.Text=   (arln == 0 ? "  بيانات كرت التشغيل  " : "  play card data") ; label_PlayCardExpDat.Text=   (arln == 0 ? "  الرقم  " : "  the number") ; label_CardPlayIssDat.Text=   (arln == 0 ? "  تاريخ الاصدار  " : "  Release Date") ; label_CardPlayNo.Text=   (arln == 0 ? "  تاريخ الانتهاء  " : "  Expiry date") ; label_FormExpDat.Text=   (arln == 0 ? "  رقم الاستمارة :  " : "  Form number:") ; label_FormIssDat.Text=   (arln == 0 ? "  تاريخهــــــــــا :  " : "  Its history:") ; label_FormNo.Text=   (arln == 0 ? "  انتهائها :  " : "  its end:") ; label_AllownceName.Text=   (arln == 0 ? "  شركة التأمين:  " : "  Insurance company:") ; label_AllowncExpDat.Text=   (arln == 0 ? "  انتهائها :  " : "  its end:") ; Label_AllowncIssDat.Text=   (arln == 0 ? "  تاريخهــــــــــا :  " : "  Its history:") ; label_AllownceNo.Text=   (arln == 0 ? "  رقم التأمــــين :  " : "  Insurance number:") ; label40.Text=   (arln == 0 ? "  إسم السيارة - انجليزي :  " : "  Car name - English:") ; label36.Text=   (arln == 0 ? "  إسم السيارة - عربـــي :  " : "  Car name - Arabic:") ; label38.Text=   (arln == 0 ? "  الرمـــــــــــــز :  " : "  Code:") ; superTabControl_Main1.Text=   (arln == 0 ? "  superTabControl3  " : "  superTabControl3") ; Button_Close.Text=   (arln == 0 ? "  إغلاق  " : "  Close") ; Button_Search.Text=   (arln == 0 ? "  بحث  " : "  Search") ; Button_Delete.Text=   (arln == 0 ? "  حذف  " : "  delete") ; Button_Save.Text=   (arln == 0 ? "  حفظ  " : "  save") ; Button_Add.Text=   (arln == 0 ? "  إضافة  " : "  addition") ; superTabControl_Main2.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; Button_First.Text=   (arln == 0 ? "  الأول  " : "  the first") ; Button_Prev.Text=   (arln == 0 ? "  السابق  " : "  the previous") ; lable_Records.Text=   (arln == 0 ? "  ---  " : "  ---") ; Button_Next.Text=   (arln == 0 ? "  التالي  " : "  next one") ; Button_Last.Text=   (arln == 0 ? "  الأخير  " : "  the last one") ; panelEx2.Text=   (arln == 0 ? "  Click to collapse  " : "  Click to collapse") ; DGV_Main.Text=   (arln == 0 ? "    " : "    ") ; DGV_Main.Text=   (arln == 0 ? "  جميــع السجــــلات  " : "  All records") ; DGV_Main.Text=   (arln == 0 ? "    " : "    ") ; panelEx3.Text=   (arln == 0 ? "  Fill Panel  " : "  Fill Panel") ; superTabControl_DGV.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; textBox_search.Text=   (arln == 0 ? "  ...  " : "  ...") ; Button_ExportTable2.Text=   (arln == 0 ? "  تصدير  " : "  Export") ; /*Button_PrintTable.Text=   (arln == 0 ? "  طباعة  " : "  Print") ; */ToolStripMenuItem_Rep.Text=   (arln == 0 ? "  إظهار التقرير  " : "  Show report") ; ToolStripMenuItem_Det.Text=   (arln == 0 ? "  إظهار التفاصيل  " : "  Show details") ; Text = "كــــــرت السيارات";this.Text=   (arln == 0 ? "  كــــــرت السيارات  " : "  car card") ;}
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
        private Dictionary<string, ColumnDictinary> Dir_ButSearch = new Dictionary<string, ColumnDictinary>();
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private T_AccDef _AccDefBind = new T_AccDef();
        private int LangArEn = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
#pragma warning disable CS0414 // The field 'FrmCar.FlagUpdate' is assigned but its value is never used
        private string FlagUpdate = "";
#pragma warning restore CS0414 // The field 'FrmCar.FlagUpdate' is assigned but its value is never used
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstance;
        private T_Car data_this;
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
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
                        frm.Repvalue = "CarRep";
                        frm.Repvalue = "CarRep";
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
        protected TextBox textBox_NameE;
        protected Label label40;
        protected TextBox textBox_NameA;
        protected Label label36;
        protected TextBox textBox_ID;
        protected Label label38;
        private TextBoxX textBox_Note;
        private GroupBox groupBox1;
        private Label label_PlayCardExpDat;
        private Label label_CardPlayIssDat;
        private Label label_CardPlayNo;
        private MaskedTextBox dateTimeInput_PlayCardEndDate;
        private MaskedTextBox dateTimeInput_PlayCardBeginDate;
        private TextBox textBox_PlayCardNo;
        private GroupBox groupBox2;
        private Label label_FormExpDat;
        private Label label_FormIssDat;
        private Label label_FormNo;
        private MaskedTextBox dateTimeInput_FormEndDate;
        private MaskedTextBox dateTimeInput_FormBeginDate;
        private TextBox textBox_FormNo;
        private GroupBox groupBox3;
        private Label label_AllownceName;
        private Label label_AllowncExpDat;
        private Label Label_AllowncIssDat;
        private Label label_AllownceNo;
        private MaskedTextBox dateTimeInput_AllownceBeginDate;
        private MaskedTextBox dateTimeInput_AllownceEndDate;
        private TextBox textBox_AllownceNo;
        private TextBox textBox_AllownceName;
        private MaskedTextBox textBox_PlateNo;
        private MaskedTextBox textBox_Model;
        private Label label3;
        private Label label1;
        private TextBox textBox_Color;
        private Label label4;
        private ComboBoxEx comboBox_CarTyp;
        private ButtonX button_AddCar;
        private ButtonX button_SrchCarTyp;
        protected Label label2;
        private ComboBoxEx comboBox_EmpNo;
        private ButtonX button_SrchEmp;
        private Label label12;
        private LabelItem lable_Records;
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
        public T_Car DataThis
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
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_FilStr, 41))
                    {
                        IfAdd = false;
                    }
                    else
                    {
                        IfAdd = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_FilStr, 42))
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_FilStr, 43))
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
                if (LangArEn == 0)
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
                if (LangArEn == 0)
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
                if (LangArEn == 0)
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
            if (LangArEn == 0)
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
            VarGeneral.SFrmTyp = "T_Car";
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
            List<T_Car> list = db.FillCars_2(textBox_search.TextBox.Text).ToList();
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                }
            }
            FillHDGV(list);
        }
        public void FillHDGV(IEnumerable<T_Car> new_data_enum)
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
            DGV_Main.PrimaryGrid.DataMember = "T_Car";
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
        public void Clear()
        {
            if (State == FormState.New)
            {
                return;
            }
            State = FormState.New;
            data_this = new T_Car();
            State = FormState.New;
            for (int i = 0; i < controls.Count; i++)
            {
                if (controls[i].GetType() == typeof(DateTimePicker))
                {
                    int? calendr = VarGeneral.Settings_Sys.Calendr;
                    if (calendr.GetValueOrDefault() == 0 && calendr.HasValue)
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
                        try
                        {
                            (controls[i] as ComboBox).SelectedIndex = 0;
                        }
                        catch
                        {
                            (controls[i] as ComboBox).SelectedIndex = -1;
                        }
                    }
                    else if (controls[i].GetType() == typeof(ComboBoxEx))
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
            textBox_ID.Focus();
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
            var qkeys = db.T_Cars.Select((T_Car item) => new
            {
                Code = item.Car_No + ""
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
        public FrmCar()
        {
            InitializeComponent();this.Load += langloads;
            controls = new List<Control>();
            controls.Add(textBox_ID);
            codeControl = textBox_ID;
            controls.Add(textBox_Color);
            controls.Add(textBox_NameA);
            controls.Add(textBox_NameE);
            controls.Add(textBox_Note);
            controls.Add(textBox_Model);
            controls.Add(textBox_PlateNo);
            controls.Add(textBox_AllownceName);
            controls.Add(textBox_AllownceNo);
            controls.Add(textBox_FormNo);
            controls.Add(textBox_PlayCardNo);
            controls.Add(dateTimeInput_AllownceBeginDate);
            controls.Add(dateTimeInput_AllownceEndDate);
            controls.Add(dateTimeInput_FormBeginDate);
            controls.Add(dateTimeInput_FormEndDate);
            controls.Add(dateTimeInput_PlayCardBeginDate);
            controls.Add(dateTimeInput_PlayCardEndDate);
            controls.Add(comboBox_CarTyp);
            controls.Add(comboBox_EmpNo);
            textBox_ID.KeyPress += textBox_ID_KeyPress;
            Button_Close.Click += Button_Close_Click;
            textBox_Color.Click += Button_Edit_Click;
            textBox_NameA.Click += Button_Edit_Click;
            textBox_NameE.Click += Button_Edit_Click;
            textBox_Note.Click += Button_Edit_Click;
            textBox_Model.Click += Button_Edit_Click;
            textBox_PlateNo.Click += Button_Edit_Click;
            textBox_AllownceName.Click += Button_Edit_Click;
            textBox_AllownceNo.Click += Button_Edit_Click;
            textBox_FormNo.Click += Button_Edit_Click;
            textBox_PlayCardNo.Click += Button_Edit_Click;
            comboBox_CarTyp.Click += Button_Edit_Click;
            comboBox_EmpNo.Click += Button_Edit_Click;
            dateTimeInput_AllownceBeginDate.Click += Button_Edit_Click;
            dateTimeInput_AllownceEndDate.Click += Button_Edit_Click;
            dateTimeInput_FormBeginDate.Click += Button_Edit_Click;
            dateTimeInput_FormEndDate.Click += Button_Edit_Click;
            dateTimeInput_PlayCardBeginDate.Click += Button_Edit_Click;
            dateTimeInput_PlayCardEndDate.Click += Button_Edit_Click;
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
            Button_PrintTable.Click += Button_Print_Click;
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmCar));
            if (base.Tag.ToString() == "0")
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
            if (LangArEn == 0)
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
                label38.Text = "الكود :";
                label36.Text = "الإسم - عربي :";
                label40.Text = "الإسم - إنجليزي :";
                textBox_Note.WatermarkText = "ملاحظـــــــات السيارة";
                Text = "كرت السيارات";
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
                label38.Text = "Code :";
                label36.Text = "Name - Arabic :";
                label40.Text = "Name - English :";
                textBox_Note.WatermarkText = "Notes";
                Text = "Cars Card";
            }
        }
        private void FrmDept_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmCar));
                if (base.Tag.ToString() == "0")
                {
                    SSSLanguage.Language.ChangeLanguage("ar-SA", this, resources);
                    LangArEn = 0;
                }
                else
                {
                    SSSLanguage.Language.ChangeLanguage("en", this, resources);
                    LangArEn = 1;
                }
                Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
                if (columns_Names_visible.Count == 0)
                {
                    columns_Names_visible.Add("Car_No", new ColumnDictinary("رقم السيارة", "Car No", ifDefault: true, ""));
                    columns_Names_visible.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
                    columns_Names_visible.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
                    columns_Names_visible.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: false, ""));
                }
                else
                {
                    Clear();
                    textBox_ID.Text = "";
                    TextBox_Index.TextBox.Text = "";
                }
                RibunButtons();
                FillCombo();
                RefreshPKeys();
                textBox_ID.Text = PKeys.FirstOrDefault();
                ViewDetails_Click(sender, e);
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
                T_Car newData = db.CarsEmp(no);
                if (newData == null || newData.Car_No == 0 || string.IsNullOrEmpty(newData.Car_ID))
                {
                    if (!Button_Add.Visible || !Button_Add.Enabled)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textBox_ID.TextChanged -= textBox_ID_TextChanged;
                        try
                        {
                            textBox_ID.Text = data_this.Car_No.ToString();
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
                    int indexA = PKeys.IndexOf(string.Concat(newData.Car_No));
                    indexA++;
                    TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                    TextBox_Index.TextBox.Text = string.Concat(indexA);
                    TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                }
            }
            catch
            {
            }
            UpdateVcr();
        }
        public void SetData(T_Car value)
        {
            try
            {
                State = FormState.Saved;
                Button_Save.Enabled = false;
                if (!string.IsNullOrEmpty(value.EmpID))
                {
                    comboBox_EmpNo.SelectedValue = value.EmpID;
                }
                else
                {
                    comboBox_EmpNo.SelectedIndex = 0;
                }
                textBox_Model.Text = value.Model;
                textBox_NameA.Text = value.NameA;
                textBox_NameE.Text = value.NameE;
                textBox_Note.Text = value.Note;
                textBox_PlateNo.Text = value.PlateNo;
                textBox_Color.Text = value.Color;
                textBox_AllownceName.Text = value.AllownceName;
                textBox_AllownceNo.Text = value.AllownceNo;
                textBox_FormNo.Text = value.FormNo;
                textBox_PlayCardNo.Text = value.PlayCardNo;
                try
                {
                    if (VarGeneral.CheckDate(value.AllownceBeginDate))
                    {
                        dateTimeInput_AllownceBeginDate.Text = Convert.ToDateTime(value.AllownceBeginDate).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        dateTimeInput_AllownceBeginDate.Text = "";
                    }
                }
                catch
                {
                    dateTimeInput_AllownceBeginDate.Text = "";
                }
                try
                {
                    if (VarGeneral.CheckDate(value.AllownceEndDate))
                    {
                        dateTimeInput_AllownceEndDate.Text = Convert.ToDateTime(value.AllownceEndDate).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        dateTimeInput_AllownceEndDate.Text = "";
                    }
                }
                catch
                {
                    dateTimeInput_AllownceEndDate.Text = "";
                }
                try
                {
                    if (VarGeneral.CheckDate(value.FormBeginDate))
                    {
                        dateTimeInput_FormBeginDate.Text = Convert.ToDateTime(value.FormBeginDate).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        dateTimeInput_FormBeginDate.Text = "";
                    }
                }
                catch
                {
                    dateTimeInput_FormBeginDate.Text = "";
                }
                try
                {
                    if (VarGeneral.CheckDate(value.FormEndDate))
                    {
                        dateTimeInput_FormEndDate.Text = Convert.ToDateTime(value.FormEndDate).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        dateTimeInput_FormEndDate.Text = "";
                    }
                }
                catch
                {
                    dateTimeInput_FormEndDate.Text = "";
                }
                try
                {
                    if (VarGeneral.CheckDate(value.PlayCardBeginDate))
                    {
                        dateTimeInput_PlayCardBeginDate.Text = Convert.ToDateTime(value.PlayCardBeginDate).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        dateTimeInput_PlayCardBeginDate.Text = "";
                    }
                }
                catch
                {
                    dateTimeInput_PlayCardBeginDate.Text = "";
                }
                try
                {
                    if (VarGeneral.CheckDate(value.PlayCardEndDate))
                    {
                        dateTimeInput_PlayCardEndDate.Text = Convert.ToDateTime(value.PlayCardEndDate).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        dateTimeInput_PlayCardEndDate.Text = "";
                    }
                }
                catch
                {
                    dateTimeInput_PlayCardEndDate.Text = "";
                }
                if (value.CarType.HasValue)
                {
                    comboBox_CarTyp.SelectedValue = value.CarType.Value;
                }
                textBox_ID.Tag = value.Car_ID;
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
        private T_Car GetData()
        {
            textBox_ID.Focus();
            try
            {
                data_this.Car_No = int.Parse(textBox_ID.Text);
            }
            catch
            {
            }
            try
            {
                if (comboBox_EmpNo.SelectedIndex > 0)
                {
                    data_this.EmpID = comboBox_EmpNo.SelectedValue.ToString();
                }
                else
                {
                    data_this.EmpID = null;
                }
            }
            catch
            {
                data_this.EmpID = null;
            }
            try
            {
                data_this.Model = textBox_Model.Text;
            }
            catch
            {
            }
            try
            {
                data_this.NameA = textBox_NameA.Text;
            }
            catch
            {
            }
            try
            {
                data_this.NameE = textBox_NameE.Text;
            }
            catch
            {
            }
            try
            {
                data_this.PlateNo = textBox_PlateNo.Text;
            }
            catch
            {
            }
            try
            {
                data_this.Note = textBox_Note.Text;
            }
            catch
            {
            }
            try
            {
                data_this.Color = textBox_Color.Text;
            }
            catch
            {
            }
            try
            {
                data_this.AllownceName = textBox_AllownceName.Text;
            }
            catch
            {
            }
            try
            {
                data_this.AllownceNo = textBox_AllownceNo.Text;
            }
            catch
            {
            }
            try
            {
                data_this.FormNo = textBox_FormNo.Text;
            }
            catch
            {
            }
            try
            {
                data_this.PlayCardNo = textBox_PlayCardNo.Text;
            }
            catch
            {
            }
            try
            {
                data_this.AllownceBeginDate = Convert.ToDateTime(dateTimeInput_AllownceBeginDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_AllownceBeginDate.Text = "";
                data_this.AllownceBeginDate = "";
            }
            try
            {
                data_this.AllownceEndDate = Convert.ToDateTime(dateTimeInput_AllownceEndDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_AllownceEndDate.Text = "";
                data_this.AllownceEndDate = "";
            }
            try
            {
                data_this.FormBeginDate = Convert.ToDateTime(dateTimeInput_FormBeginDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_FormBeginDate.Text = "";
                data_this.FormBeginDate = "";
            }
            try
            {
                data_this.FormEndDate = Convert.ToDateTime(dateTimeInput_FormEndDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_FormEndDate.Text = "";
                data_this.FormEndDate = "";
            }
            try
            {
                data_this.PlayCardBeginDate = Convert.ToDateTime(dateTimeInput_PlayCardBeginDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PlayCardBeginDate.Text = "";
                data_this.PlayCardBeginDate = "";
            }
            try
            {
                data_this.PlayCardEndDate = Convert.ToDateTime(dateTimeInput_PlayCardEndDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PlayCardEndDate.Text = "";
                data_this.PlayCardEndDate = "";
            }
            try
            {
                data_this.CarType = int.Parse(comboBox_CarTyp.SelectedValue.ToString());
            }
            catch
            {
                data_this.CarType = null;
            }
            try
            {
                data_this.CompanyID = 1;
            }
            catch
            {
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
                max = db.MaxCarsNo;
                Clear();
                textBox_ID.Text = max.ToString();
                Guid id = Guid.NewGuid();
                textBox_ID.Tag = id.ToString();
                State = FormState.New;
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
                if (textBox_ID.Text == "" || textBox_NameA.Text == "" || textBox_NameE.Text == "")
                {
                    MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الرمز او الإسم فارغا\u0651" : "Can not be a number or name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (comboBox_CarTyp.SelectedIndex == -1)
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب تحديد ماركة السيارة" : "Must Select Car Type", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (State == FormState.New)
                {
                    GetData();
                    try
                    {
                        data_this.Car_ID = textBox_ID.Tag.ToString();
                        db.T_Cars.InsertOnSubmit(data_this);
                        db.SubmitChanges();
                    }
                    catch (SqlException ex3)
                    {
                        int max = 0;
                        max = db.MaxCarsNo;
                        if (ex3.Number != 2627)
                        {
                            return;
                        }
                        MessageBox.Show("رقم السيارة مستخدم من قبل.\n سيتم الحفظ برقم جديد [" + max + "]", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question);
                        textBox_ID.Text = string.Concat(max);
                        data_this.Car_No = max;
                        Button_Save_Click(sender, e);
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
                else if (State == FormState.Edit)
                {
                    GetData();
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
                TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(string.Concat(data_this.Car_No)) + 1);
                SetReadOnly = true;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Save:", error, enable: true);
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
            string Code = "";
            Code = textBox_ID.Text;
            if (Code == "")
            {
                ifOkDelete = false;
                return;
            }
            try
            {
                if (data_this.Car_ID == "1")
                {
                    ifOkDelete = false;
                    return;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
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
            if (data_this == null || data_this.Car_No == 0 || string.IsNullOrEmpty(data_this.Car_ID) || !ifOkDelete)
            {
                return;
            }
            T_Emp returned = db.SelectDeptNoByReturnNo(DataThis.Car_No);
            int num;
            if (returned != null)
            {
                int? dept = returned.Dept;
                num = ((dept.GetValueOrDefault() == 0 && dept.HasValue) ? 1 : 0);
            }
            else
            {
                num = 1;
            }
            if (num == 0)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن حذف السيارة .. لانه مرتبط باحد الموظفين" : "can not be deleted This car .. because it is linked to one of the employee", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            data_this = db.CarsEmp(DataThis.Car_No);
            try
            {
                db.T_Cars.DeleteOnSubmit(DataThis);
                db.SubmitChanges();
            }
            catch (SqlException)
            {
                data_this = db.CarsEmp(DataThis.Car_No);
                return;
            }
            catch (Exception)
            {
                data_this = db.CarsEmp(DataThis.Car_No);
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
            if (dataMember != null && dataMember == "T_Car")
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
            panel.Columns["NameA"].Width = 250;
            panel.Columns["NameA"].Visible = columns_Names_visible["NameA"].IfDefault;
            panel.Columns["NameE"].Width = 250;
            panel.Columns["NameE"].Visible = columns_Names_visible["NameE"].IfDefault;
            panel.Columns["Car_No"].Width = 120;
            panel.Columns["Car_No"].Visible = columns_Names_visible["Car_No"].IfDefault;
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
                ExportExcel.ExportToExcel(DGV_Main, "تقرير السيارات");
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
        public void Button_Print_Click(object sender, EventArgs e)
        {
            if (ViewState == ViewState.Table)
            {
                VarGeneral.IsGeneralUsed = true;
                FrmReportsViewer frm = new FrmReportsViewer();
                frm.Repvalue = "CarRep";
                frm.Tag = LangArEn;
                frm.Repvalue = "CarRep";
                VarGeneral.vTitle = Text;
                frm.SqlWhere = "";
                frm.TopMost = true;
                frm.ShowDialog();
                VarGeneral.IsGeneralUsed = false;
            }
        }
        public void textBox_NameA_Leave(object sender, EventArgs e)
        {
            SSSLanguage.Language.Switch("AR");
        }
        public void textBox_NameE_Leave(object sender, EventArgs e)
        {
            SSSLanguage.Language.Switch("AR");
        }
        private void textBox_Note_Click(object sender, EventArgs e)
        {
            textBox_Note.SelectAll();
        }
        private void dateTimeInput_FormBeginDate_Click(object sender, EventArgs e)
        {
            dateTimeInput_FormBeginDate.SelectAll();
        }
        private void dateTimeInput_FormEndDate_Click(object sender, EventArgs e)
        {
            dateTimeInput_FormEndDate.SelectAll();
        }
        private void dateTimeInput_AllownceBeginDate_Click(object sender, EventArgs e)
        {
            dateTimeInput_AllownceBeginDate.SelectAll();
        }
        private void dateTimeInput_AllownceEndDate_Click(object sender, EventArgs e)
        {
            dateTimeInput_AllownceEndDate.SelectAll();
        }
        private void dateTimeInput_PlayCardBeginDate_Click(object sender, EventArgs e)
        {
            dateTimeInput_PlayCardBeginDate.SelectAll();
        }
        private void dateTimeInput_PlayCardEndDate_Click(object sender, EventArgs e)
        {
            dateTimeInput_PlayCardEndDate.SelectAll();
        }
        private void textBox_FormNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void dateTimeInput_FormBeginDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(dateTimeInput_FormBeginDate.Text))
                {
                    dateTimeInput_FormBeginDate.Text = Convert.ToDateTime(dateTimeInput_FormBeginDate.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_FormBeginDate.Text = "";
                }
            }
            catch
            {
                dateTimeInput_FormBeginDate.Text = "";
            }
        }
        private void dateTimeInput_FormEndDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(dateTimeInput_FormEndDate.Text))
                {
                    dateTimeInput_FormEndDate.Text = Convert.ToDateTime(dateTimeInput_FormEndDate.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_FormEndDate.Text = "";
                }
            }
            catch
            {
                dateTimeInput_FormEndDate.Text = "";
            }
        }
        private void dateTimeInput_AllownceBeginDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(dateTimeInput_AllownceBeginDate.Text))
                {
                    dateTimeInput_AllownceBeginDate.Text = Convert.ToDateTime(dateTimeInput_AllownceBeginDate.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_AllownceBeginDate.Text = "";
                }
            }
            catch
            {
                dateTimeInput_AllownceBeginDate.Text = "";
            }
        }
        private void dateTimeInput_AllownceEndDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(dateTimeInput_AllownceEndDate.Text))
                {
                    dateTimeInput_AllownceEndDate.Text = Convert.ToDateTime(dateTimeInput_AllownceEndDate.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_AllownceEndDate.Text = "";
                }
            }
            catch
            {
                dateTimeInput_AllownceEndDate.Text = "";
            }
        }
        private void dateTimeInput_PlayCardBeginDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(dateTimeInput_PlayCardBeginDate.Text))
                {
                    dateTimeInput_PlayCardBeginDate.Text = Convert.ToDateTime(dateTimeInput_PlayCardBeginDate.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_PlayCardBeginDate.Text = "";
                }
            }
            catch
            {
                dateTimeInput_PlayCardBeginDate.Text = "";
            }
        }
        private void dateTimeInput_PlayCardEndDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(dateTimeInput_PlayCardEndDate.Text))
                {
                    dateTimeInput_PlayCardEndDate.Text = Convert.ToDateTime(dateTimeInput_PlayCardEndDate.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_PlayCardEndDate.Text = "";
                }
            }
            catch
            {
                dateTimeInput_PlayCardEndDate.Text = "";
            }
        }
        public bool IsFormOpen(Form formType)
        {
            try
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (formType.Name == form.Name)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        private void button_AddCar_Click(object sender, EventArgs e)
        {
            if (IsFormOpen(new FrmCarTyp()))
            {
                return;
            }
            FrmCarTyp frm = new FrmCarTyp();
            frm.Tag = LangArEn;
            string vList = "";
            if (comboBox_CarTyp.SelectedIndex != -1)
            {
                vList = comboBox_CarTyp.SelectedValue.ToString();
            }
            frm.TopMost = true;
            frm.ShowDialog();
            using (new Stock_DataDataContext(VarGeneral.BranchCS))
            {
                List<T_CarTyp> listJob = new List<T_CarTyp>(db.T_CarTyps.Select((T_CarTyp item) => item).ToList());
                comboBox_CarTyp.DataSource = null;
                comboBox_CarTyp.DataSource = listJob;
                comboBox_CarTyp.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
                comboBox_CarTyp.ValueMember = "CarTyp_No";
                if (vList != "")
                {
                    for (int i = 0; i < comboBox_CarTyp.Items.Count; i++)
                    {
                        comboBox_CarTyp.SelectedIndex = i;
                        if (comboBox_CarTyp.SelectedValue.ToString() == vList)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    comboBox_CarTyp.SelectedIndex = -1;
                }
            }
        }
        private void button_SrchCarTyp_Click(object sender, ClickEventArgs e)
        {
            try
            {
                Dir_ButSearch.Add("CarTyp_No", new ColumnDictinary("الرقم", "No", ifDefault: true, ""));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, ""));
                Dir_ButSearch.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, ""));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                }
                VarGeneral.SFrmTyp = "T_CarTyp";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    comboBox_CarTyp.SelectedValue = int.Parse(frm.SerachNo);
                    Button_Edit_Click(sender, e);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void textBox_Model_Click(object sender, EventArgs e)
        {
            textBox_Model.SelectAll();
        }
        private void textBox_FormNo_Click(object sender, EventArgs e)
        {
            textBox_FormNo.SelectAll();
        }
        private void textBox_AllownceNo_Click(object sender, EventArgs e)
        {
            textBox_AllownceNo.SelectAll();
        }
        private void textBox_PlayCardNo_Click(object sender, EventArgs e)
        {
            textBox_PlayCardNo.SelectAll();
        }
        private void textBox_PlateNo_Click(object sender, EventArgs e)
        {
            textBox_PlateNo.SelectAll();
        }
        private void FillCombo()
        {
            List<T_CarTyp> listJob = new List<T_CarTyp>(db.T_CarTyps.Select((T_CarTyp item) => item).ToList());
            comboBox_CarTyp.DataSource = null;
            comboBox_CarTyp.DataSource = listJob;
            comboBox_CarTyp.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_CarTyp.ValueMember = "CarTyp_No";
            comboBox_CarTyp.SelectedIndex = -1;
            List<T_Emp> listEmps = new List<T_Emp>(db.T_Emps.Where((T_Emp item) => item.EmpState == (bool?)true).ToList());
            listEmps.Insert(0, new T_Emp());
            comboBox_EmpNo.DataSource = listEmps;
            comboBox_EmpNo.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_EmpNo.ValueMember = "Emp_ID";
            comboBox_EmpNo.SelectedIndex = 0;
        }
        private void button_SrchCarTyp_Click(object sender, EventArgs e)
        {
            try
            {
                Dir_ButSearch.Add("CarTyp_No", new ColumnDictinary("رقم النوع", "Type No", ifDefault: true, ""));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, ""));
                Dir_ButSearch.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, ""));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                }
                VarGeneral.SFrmTyp = "T_CarTyp";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    comboBox_CarTyp.SelectedValue = int.Parse(frm.SerachNo);
                    Button_Edit_Click(sender, e);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void textBox_AllownceName_Click(object sender, EventArgs e)
        {
            textBox_AllownceName.SelectAll();
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
    }
}
