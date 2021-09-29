using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using Framework.Data;
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
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmSndTenant : Form
    { void avs(int arln)

{ 
 panelEx2.Text=   (arln == 0 ? "  Click to collapse  " : "  Click to collapse") ; label9.Text=   (arln == 0 ? "  نوع العين :  " : "  eye type:") ; label8.Text=   (arln == 0 ? "  رقم العين :  " : "  eye number:") ; label6.Text=   (arln == 0 ? "  رقم العقار :  " : "  Property ID :") ; label4.Text=   (arln == 0 ? "  الوصف إنجليزي :  " : "  English description:") ; button_Payment.Text=   (arln == 0 ? "  الدفعـــات  " : "  Payments") ; label19.Text=   (arln == 0 ? "  العملة :  " : "  the currency :") ; Label2.Text=   (arln == 0 ? "  التاريــــــــخ :  " : "  date:") ; label3.Text=   (arln == 0 ? "  الوصـــف عربي :  " : "  Arabic description:") ; label1.Text=   (arln == 0 ? "  المبلــــــــــــــغ :  " : "  Amount:") ; label36.Text=   (arln == 0 ? "  رقم العقـــــــــد :  " : "  Contract number:") ; label38.Text=   (arln == 0 ? "  رقم السنــــــــد :  " : "  bond number:") ; labelD1.Text=   (arln == 0 ? "  المدين :  " : "  Debtor:") ; labelC1.Text=   (arln == 0 ? "  الدائن :  " : "  creditor:") ; label7.Text=   (arln == 0 ? "  رقم الشيك / المرجع :  " : "  Check No. / Reference:") ; label5.Text=   (arln == 0 ? "  المستأجـــــــــر :  " : "  Tenant:") ; superTabControl_Main1.Text=   (arln == 0 ? "  superTabControl3  " : "  superTabControl3") ; Button_Close.Text=   (arln == 0 ? "  إغلاق  " : "  Close") ; /*buttonItem_Print.Text=   (arln == 0 ? "  طباعة  " : "  Print") ;*/ Button_Search.Text=   (arln == 0 ? "  بحث  " : "  Search") ; Button_Delete.Text=   (arln == 0 ? "  حذف  " : "  delete") ; Button_Save.Text=   (arln == 0 ? "  حفظ  " : "  save") ; Button_Add.Text=   (arln == 0 ? "  إضافة  " : "  addition") ; superTabControl_Main2.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; Button_First.Text=   (arln == 0 ? "  الأول  " : "  the first") ; Button_Prev.Text=   (arln == 0 ? "  السابق  " : "  the previous") ; lable_Records.Text=   (arln == 0 ? "  ---  " : "  ---") ; Button_Next.Text=   (arln == 0 ? "  التالي  " : "  next one") ; Button_Last.Text=   (arln == 0 ? "  الأخير  " : "  the last one") ; DGV_Main.Text=   (arln == 0 ? "    " : "    ") ; DGV_Main.Text=   (arln == 0 ? "  جميــع السجــــلات  " : "  All records") ; DGV_Main.Text=   (arln == 0 ? "    " : "    ") ; panelEx3.Text=   (arln == 0 ? "  Fill Panel  " : "  Fill Panel") ; superTabControl_DGV.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; textBox_search.Text=   (arln == 0 ? "  ...  " : "  ...") ; Button_ExportTable2.Text=   (arln == 0 ? "  تصدير  " : "  Export") ; ToolStripMenuItem_Rep.Text=   (arln == 0 ? "  إظهار التقرير  " : "  Show report") ; ToolStripMenuItem_Det.Text=   (arln == 0 ? "  إظهار التفاصيل  " : "  Show details") ; Text = "سندات المستأجرين";this.Text=   (arln == 0 ? "  سندات المستأجرين  " : "  Tenant Bonds") ;}
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
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private T_AccDef _AccDefBind = new T_AccDef();
        private int LangArEn = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
        private string FlagUpdate = "";
        public int ProcessTyp = 0;
        public string TenantNo_ = "";
        public string TenantID_ = "";
        public int ContractNo;
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstance;
        private T_GDHEAD data_this;
        private List<T_GDDET> LData_This;
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private List<T_INVSETTING> listInvSetting = new List<T_INVSETTING>();
        private ScriptNumber ScriptNumber1 = new ScriptNumber();
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
        private int iiRntP = 0;
        private int _page = 1;
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
                        frm.Repvalue = "RepGaidCatchTenant";
                        frm.Repvalue = "RepGaidSerfTenant";
                        frm.Repvalue = "RepGaidCatchTenant";
                        frm.Repvalue = "RepGaidSerfTenant";
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
        private RibbonBar ribbonBar_DGV;
        private SuperTabControl superTabControl_DGV;
        protected TextBoxItem textBox_search;
        protected ButtonItem Button_ExportTable2;
        protected LabelItem labelItem3;
        private LabelItem lable_Records;
        private Panel panel2;
        protected TextBox txtName;
        protected Label label36;
        protected TextBox textBox_ID;
        protected Label label38;
        internal Label Label2;
        private MaskedTextBox txtGDate;
        private ComboBoxEx CmbCurr;
        internal Label label19;
        protected Label label3;
        protected Label label1;
        private TextBoxX txtRemark;
        private Label label5;
        protected ButtonItem buttonItem_Print;
        private Panel panel_Gaid;
        private TextBoxX txtDebit1;
        private TextBoxX txtCredit1;
        internal Label labelD1;
        internal Label labelC1;
        internal PrintPreviewDialog prnt_prev;
        private PrintDocument prnt_doc;
        private System.Windows.Forms.OpenFileDialog  openFileDialog2;
        internal Label label7;
        internal TextBox txtRef;
        private ButtonX button_SrchTenantNo;
        private ButtonX button_CustC1;
        public DoubleInput txtValue;
        private MaskedTextBox txtHDate;
        private ButtonX button_CustD1;
        private ButtonX button_Payment;
        private TextBoxX txtRemarkE;
        protected Label label4;
        internal TextBox txtEyeNo;
        protected Label label8;
        internal TextBox txtEqarNo;
        protected Label label6;
        internal TextBox txtContractNo;
        private TextBox txtTenantNo;
        internal TextBox txtEyeTyp;
        protected Label label9;
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
                button_Payment.Enabled = !value;
                if (State == FormState.Saved)
                {
                    button_Payment.Enabled = true;
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
                if (VarGeneral.InvTyp == 29)
                {
                    if (!VarGeneral.TString.ChkStatShow(value.Eqar_TenantStr, 5))
                    {
                        IfAdd = false;
                    }
                    else
                    {
                        IfAdd = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Eqar_TenantStr, 6))
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Eqar_TenantStr, 7))
                    {
                        IfDelete = false;
                    }
                    else
                    {
                        IfDelete = true;
                    }
                }
                else
                {
                    if (!VarGeneral.TString.ChkStatShow(value.Eqar_TenantStr, 9))
                    {
                        IfAdd = false;
                    }
                    else
                    {
                        IfAdd = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Eqar_TenantStr, 10))
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Eqar_TenantStr, 11))
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
            VarGeneral.SFrmTyp = "T_Gaid";
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
            List<T_GDHEAD> list = db.FillGDHEAD_2(VarGeneral.InvTyp, textBox_search.TextBox.Text).ToList();
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                }
            }
            FillHDGV(list);
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
            DGV_Main.PrimaryGrid.DataMember = "T_GDHEAD";
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
            data_this = new T_GDHEAD();
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
            textBox_ID.Focus();
            txtContractNo.Tag = "";
            txtTenantNo.Tag = "";
            txtDebit1.Tag = "";
            txtCredit1.Tag = "";
            txtValue.Tag = "";
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
        public void RefreshPKeys()
        {
            PKeys.Clear();
            try
            {
                PKeys = db.ExecuteQuery<string>("select gdNo from T_GDHEAD where gdTyp =" + VarGeneral.InvTyp + " and gdLok = 0 ", new object[0]).ToList();
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
        public FrmSndTenant()
        {
            InitializeComponent();this.Load += langloads;
            controls = new List<Control>();
            controls.Add(textBox_ID);
            codeControl = textBox_ID;
            controls.Add(txtCredit1);
            controls.Add(txtDebit1);
            controls.Add(txtGDate);
            controls.Add(txtHDate);
            controls.Add(txtRemark);
            controls.Add(txtRemarkE);
            controls.Add(txtValue);
            controls.Add(CmbCurr);
            controls.Add(txtTenantNo);
            controls.Add(txtRef);
            controls.Add(txtContractNo);
            controls.Add(txtEqarNo);
            controls.Add(txtEyeNo);
            controls.Add(txtEyeTyp);
            Button_Close.Click += Button_Close_Click;
            txtGDate.Click += Button_Edit_Click;
            txtHDate.Click += Button_Edit_Click;
            txtRemark.Click += Button_Edit_Click;
            txtRemarkE.Click += Button_Edit_Click;
            txtValue.Click += Button_Edit_Click;
            CmbCurr.Click += Button_Edit_Click;
            txtDebit1.Click += Button_Edit_Click;
            txtCredit1.Click += Button_Edit_Click;
            txtRef.Click += Button_Edit_Click;
            txtContractNo.Click += Button_Edit_Click;
            txtEqarNo.Click += Button_Edit_Click;
            txtEyeNo.Click += Button_Edit_Click;
            txtEyeTyp.Click += Button_Edit_Click;
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
            txtDebit1.ButtonCustomClick += txtDebit1_ButtonCustomClick;
            txtCredit1.ButtonCustomClick += txtCredit1_ButtonCustomClick;
            textBox_search.InputTextChanged += TextBox_Search_InputTextChanged;
            textBox_search.ButtonCustomClick += TextBox_Search_ButtonCustomClick;
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmSndTenant));
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
        private void GetInvSetting()
        {
            _InvSetting = new T_INVSETTING();
            _InvSetting = db.StockInvSetting(VarGeneral.UserID, VarGeneral.InvTyp);
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
                DGV_Main.PrimaryGrid.GroupByRow.Text = "جميع السجلات";
                button_Payment.Text = "الدفعات";
                if (VarGeneral.InvTyp == 29)
                {
                    Text = "سند قبض مستأجر";
                    txtCredit1.ButtonCustom.Visible = false;
                }
                else
                {
                    Text = "سند صرف مستأجر";
                    txtDebit1.ButtonCustom.Visible = false;
                }
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
                button_Payment.Text = "Payments";
                if (VarGeneral.InvTyp == 29)
                {
                    Text = "Under arrest Tenant";
                    txtCredit1.ButtonCustom.Visible = false;
                }
                else
                {
                    Text = "Under Exchange Tenant";
                    txtDebit1.ButtonCustom.Visible = false;
                }
            }
        }
        private void FrmSndTenant_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmSndTenant));
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
                Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
                if (columns_Names_visible.Count == 0)
                {
                    columns_Names_visible.Add("gdNo", new ColumnDictinary("رقم القيد", "Gaid No", ifDefault: true, ""));
                    columns_Names_visible.Add("gdHDate", new ColumnDictinary("التاريخ الهجري", "Date Hijri", ifDefault: false, ""));
                    columns_Names_visible.Add("gdGDate", new ColumnDictinary("التاريخ الميلادي", "Date Gregorian", ifDefault: true, ""));
                    columns_Names_visible.Add("gdTot", new ColumnDictinary("القيمة", "Value", ifDefault: true, ""));
                    columns_Names_visible.Add("gdMem", new ColumnDictinary("المستأجر", "Tenant", ifDefault: true, ""));
                    columns_Names_visible.Add("RefNo", new ColumnDictinary("رقم المرجع", "Ref No", ifDefault: true, ""));
                }
                else
                {
                    Clear();
                    textBox_ID.Text = "";
                    TextBox_Index.TextBox.Text = "";
                }
                GetInvSetting();
                RibunButtons();
                RefreshPKeys();
                FillCombo();
                if (ProcessTyp == 1)
                {
                    Button_Add_Click(sender, e);
                    if (ContractNo > 0)
                    {
                        ContractTenantData(db.StockTenantContractData(ContractNo, int.Parse(TenantID_)).ContractID.ToString());
                    }
                    base.ActiveControl = txtValue;
                }
                else
                {
                    textBox_ID.Text = PKeys.FirstOrDefault();
                }
                ViewDetails_Click(sender, e);
                UpdateVcr();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void FillCombo()
        {
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
            CmbCurr.SelectedIndex = 0;
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
                            textBox_ID.Text = data_this.gdNo.ToString();
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
            }
            catch
            {
            }
            UpdateVcr();
        }
        public void SetData(T_GDHEAD value)
        {
            try
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
                txtRef.Text = value.RefNo.Trim();
                txtRemark.Text = value.T_GDDETs.FirstOrDefault().gdDes;
                txtRemarkE.Text = value.T_GDDETs.FirstOrDefault().gdDesE;
                txtContractNo.Text = value.T_TenantContract.ContractNo.ToString();
                txtContractNo.Tag = value.gdTp.Value;
                try
                {
                    txtEqarNo.Text = value.T_TenantContract.T_EqarsData.EqarNo.ToString();
                }
                catch
                {
                    txtEqarNo.Text = "";
                }
                try
                {
                    txtEyeNo.Text = value.T_TenantContract.T_AinsData.AinNo.ToString();
                }
                catch
                {
                    txtEyeNo.Text = "";
                }
                try
                {
                    txtEyeTyp.Text = ((LangArEn == 0) ? value.T_TenantContract.T_AinsData.T_AinTyp.NameA : value.T_TenantContract.T_AinsData.T_AinTyp.NameE);
                }
                catch
                {
                    txtEyeTyp.Text = "";
                }
                for (int iiCnt = 0; iiCnt < CmbCurr.Items.Count; iiCnt++)
                {
                    CmbCurr.SelectedIndex = iiCnt;
                    if (CmbCurr.SelectedValue != null && CmbCurr.SelectedValue.ToString() == value.CurTyp.Value.ToString())
                    {
                        break;
                    }
                }
                txtTenantNo.Text = value.T_TenantContract.T_Tenant.tenantNo.ToString();
                txtTenantNo.Tag = value.T_TenantContract.tenant_ID;
                txtName.Text = ((LangArEn == 0) ? value.T_TenantContract.T_Tenant.NameA : value.T_TenantContract.T_Tenant.NameE);
                txtValue.Value = value.gdTot.Value;
                if (value.gdRcptID.HasValue)
                {
                    txtValue.Tag = value.gdRcptID.Value;
                }
                LDataThis = new BindingList<T_GDDET>(value.T_GDDETs).OrderBy((T_GDDET g) => g.Lin.Value).ToList();
                txtDebit1.Text = "";
                txtCredit1.Text = "";
                if (LDataThis.Count != 0)
                {
                    for (int i = 0; i < LDataThis.Count; i++)
                    {
                        if (LDataThis[i].Lin == 1)
                        {
                            if (LDataThis[i].gdValue > 0.0)
                            {
                                txtDebit1.Tag = LDataThis[i].AccNo;
                                txtDebit1.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(LDataThis[i].AccNo).Arb_Des : db.SelectAccRootByCode(LDataThis[i].AccNo).Eng_Des);
                            }
                            else
                            {
                                txtCredit1.Tag = LDataThis[i].AccNo;
                                txtCredit1.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(LDataThis[i].AccNo).Arb_Des : db.SelectAccRootByCode(LDataThis[i].AccNo).Eng_Des);
                            }
                        }
                    }
                }
                else
                {
                    data_this = new T_GDHEAD();
                }
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
        private T_GDHEAD GetData()
        {
            textBox_ID.Focus();
            data_this.gdHDate = txtHDate.Text;
            data_this.gdGDate = txtGDate.Text;
            data_this.gdNo = textBox_ID.Text;
            data_this.ArbTaf = ScriptNumber1.ScriptNum(decimal.Parse("0" + txtValue.Text));
            data_this.BName = data_this.BName;
            data_this.ChekNo = data_this.ChekNo;
            data_this.CurTyp = int.Parse(CmbCurr.SelectedValue.ToString());
            data_this.EngTaf = ScriptNumber1.TafEng(decimal.Parse("0" + txtValue.Text));
            data_this.gdCstNo = 1;
            data_this.gdID = 0;
            data_this.gdLok = false;
            data_this.gdMem = txtName.Text;
            data_this.gdMnd = null;
            data_this.gdRcptID = double.Parse(txtValue.Tag.ToString());
            data_this.gdTot = txtValue.Value;
            data_this.gdTp = int.Parse(txtContractNo.Tag.ToString());
            data_this.gdTyp = VarGeneral.InvTyp;
            data_this.RefNo = txtRef.Text;
            data_this.AdminLock = false;
            data_this.DATE_MODIFIED = DateTime.Now;
            data_this.salMonth = "";
            data_this.gdUser = VarGeneral.UserNumber;
            data_this.gdUserNam = VarGeneral.UserNameA;
            data_this.CompanyID = 1;
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
                Clear();
                textBox_ID.Text = db.MaxGDHEADsNo.ToString();
                txtGDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                txtHDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                txtRemark.Text = ((VarGeneral.InvTyp == 29) ? ("سند قبض مستأجر رقم : " + textBox_ID.Text) : ("سند صرف مستأجر رقم : " + textBox_ID.Text));
                txtRemarkE.Text = ((VarGeneral.InvTyp == 29) ? ("Bound Catch To Tenant No : " + textBox_ID.Text) : ("Bound exchange To Tenant No : " + textBox_ID.Text));
                State = FormState.New;
            }
        }
        private void AutoGaidAcc()
        {
            if (!(_InvSetting.InvSetting.Substring(1, 1) == "1"))
            {
                return;
            }
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
                            string dtAction = (n.IsHijri(txtGDate.Text) ? txtGDate.Text : n.GregToHijri(txtGDate.Text, "yyyy/MM/dd"));
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
        private void Button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Button_Save.Enabled)
                {
                    return;
                }
                textBox_ID.Focus();
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
                if (textBox_ID.Text == "")
                {
                    MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الرقم فارغا\u0651" : "Can not be a number or name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_ID.Focus();
                    return;
                }
                try
                {
                    if (string.IsNullOrEmpty(txtTenantNo.Text) || string.IsNullOrEmpty(txtTenantNo.Tag.ToString()))
                    {
                        MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون رقم المستأجر فارغا\u0651" : "Can not be tenant number is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        txtTenantNo.Focus();
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون رقم المستأجر فارغا\u0651" : "Can not be tenant number is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtTenantNo.Focus();
                    return;
                }
                if (txtValue.Value <= 0.0)
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من قيمة السند" : "Make sure the value ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtValue.Focus();
                    return;
                }
                try
                {
                    if (string.IsNullOrEmpty(txtContractNo.Text) || string.IsNullOrEmpty(txtContractNo.Tag.ToString()))
                    {
                        MessageBox.Show((LangArEn == 0) ? "تأكد من رقم العقد" : "Make sure the Contract No ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        txtContractNo.Focus();
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من رقم العقد" : "Make sure the Contract No ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtContractNo.Focus();
                    return;
                }
                try
                {
                    if (string.IsNullOrEmpty(txtValue.Tag.ToString()))
                    {
                        MessageBox.Show((LangArEn == 0) ? "يرجى تحديد دفعة قبل اتمام عملية الحفظ" : "Please select a payment before saving ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        button_Payment.Focus();
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show((LangArEn == 0) ? "يرجى تحديد دفعة قبل اتمام عملية الحفظ" : "Please select a payment before saving ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    button_Payment.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtRemark.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون االوصف فارغا\u0651" : "Can not be the description is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtRemark.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtRemarkE.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون االوصف فارغا\u0651" : "Can not be the description is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtRemarkE.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtCredit1.Text) || string.IsNullOrEmpty(txtDebit1.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف الدائن والمدين للقيد .. " : "You can not complete the operation .. Make sure the creditor and debitor under the party ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (false)
                {
                    Environment.Exit(0);
                    return;
                }
                string AccCrdt = "";
                string AccDbt = "";
                if (txtValue.Value > 0.0)
                {
                    AccCrdt = txtCredit1.Tag.ToString();
                    AccDbt = txtDebit1.Tag.ToString();
                }
                if (AccCrdt == "" && txtValue.Value > 0.0)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف الدائن للقيد .. " : "You can not complete the operation .. Make sure the creditor under the party ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (AccDbt == "" && txtValue.Value > 0.0)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف المدين للقيد .. " : "You can not complete the operation .. Make sure the debtor under the party ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (txtValue.Value > 0.0 && !string.IsNullOrEmpty(AccCrdt) && !string.IsNullOrEmpty(AccDbt))
                {
                    IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
                    if (State == FormState.New)
                    {
                        Stock_DataDataContext dbGaid = new Stock_DataDataContext(VarGeneral.BranchCS);
                        try
                        {
                            GetInvSetting();
                            textBox_ID.TextChanged -= textBox_ID_TextChanged;
                            data_this = new T_GDHEAD();
                            GetData();
                            string max = "";
                            max = dbGaid.MaxGDHEADsNo.ToString();
                            textBox_ID.Text = max ?? "";
                            data_this.gdNo = max ?? "";
                            textBox_ID.TextChanged += textBox_ID_TextChanged;
                            data_this.DATE_CREATED = DateTime.Now;
                            data_this.gdUser = VarGeneral.UserNumber;
                            data_this.gdUserNam = VarGeneral.UserNameA;
                            data_this.MODIFIED_BY = "";
                            dbGaid.T_GDHEADs.InsertOnSubmit(data_this);
                            dbGaid.SubmitChanges();
                        }
                        catch (SqlException ex2)
                        {
                            string max = "";
                            max = dbGaid.MaxGDHEADsNo.ToString();
                            if (ex2.Number == 2627)
                            {
                                MessageBox.Show("الرمز مستخدم من قبل.\n سيتم الحفظ برقم جديد [" + max + "]", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                textBox_ID.Text = max ?? "";
                                data_this.gdNo = max ?? "";
                                Button_Save_Click(null, null);
                            }
                        }
                        catch (Exception ex)
                        {
                            VarGeneral.DebLog.writeLog("SaveData Er:", ex, enable: true);
                            MessageBox.Show(ex.Message);
                            return;
                        }
                    }
                    else
                    {
                        db.ExecuteCommand("UPDATE T_TenantPayment SET T_TenantPayment.SndNo = null  where PaymentID = " + data_this.gdRcptID.Value);
                        GetData();
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
                    if (txtValue.Value > 0.0 && !string.IsNullOrEmpty(AccCrdt) && !string.IsNullOrEmpty(AccDbt))
                    {
                        db_.StartTransaction();
                        db_.ClearParameters();
                        db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                        db_.AddParameter("gdID", DbType.Int32, data_this.gdhead_ID);
                        db_.AddParameter("gdNo", DbType.String, textBox_ID.Text);
                        db_.AddParameter("gdDes", DbType.String, txtRemark.Text);
                        db_.AddParameter("gdDesE", DbType.String, txtRemarkE.Text);
                        db_.AddParameter("recptTyp", DbType.String, "1");
                        db_.AddParameter("AccNo", DbType.String, AccCrdt);
                        db_.AddParameter("AccName", DbType.String, "");
                        db_.AddParameter("gdValue", DbType.Double, 0.0 - double.Parse(txtValue.Text));
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
                        db_.AddParameter("gdDes", DbType.String, txtRemark.Text);
                        db_.AddParameter("gdDesE", DbType.String, txtRemarkE.Text);
                        db_.AddParameter("recptTyp", DbType.String, "1");
                        db_.AddParameter("AccNo", DbType.String, AccDbt);
                        db_.AddParameter("AccName", DbType.String, "");
                        db_.AddParameter("gdValue", DbType.Double, double.Parse(txtValue.Text));
                        db_.AddParameter("recptNo", DbType.String, textBox_ID.Text);
                        db_.AddParameter("Lin", DbType.Int32, 1);
                        db_.AddParameter("AccNoDestruction", DbType.String, null);
                        db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                        db_.EndTransaction();
                    }
                }
                db.ExecuteCommand("UPDATE T_TenantPayment SET T_TenantPayment.SndNo = " + data_this.gdhead_ID + "  where PaymentID = " + int.Parse(txtValue.Tag.ToString()));
                dbInstance = null;
                textBox_ID_TextChanged(null, null);
                State = FormState.Saved;
                RefreshPKeys();
                TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(data_this.gdNo ?? "") + 1);
                textBox_ID_TextChanged(null, null);
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
                    db.ExecuteCommand("UPDATE T_TenantPayment SET T_TenantPayment.SndNo = null  where PaymentID = " + data_this.gdRcptID.Value);
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
        private void DGV_Main_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            string dataMember = panel.DataMember;
            if (dataMember != null && dataMember == "T_GDHEAD")
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
            panel.Columns["gdNo"].Width = 120;
            panel.Columns["gdNo"].Visible = columns_Names_visible["gdNo"].IfDefault;
            panel.Columns["gdHDate"].Width = 100;
            panel.Columns["gdHDate"].Visible = columns_Names_visible["gdHDate"].IfDefault;
            panel.Columns["gdGDate"].Width = 100;
            panel.Columns["gdGDate"].Visible = columns_Names_visible["gdGDate"].IfDefault;
            panel.Columns["gdTot"].Width = 150;
            panel.Columns["gdTot"].Visible = columns_Names_visible["gdTot"].IfDefault;
            panel.Columns["gdMem"].Width = 200;
            panel.Columns["gdMem"].Visible = columns_Names_visible["gdMem"].IfDefault;
            panel.Columns["RefNo"].Width = 100;
            panel.Columns["RefNo"].Visible = columns_Names_visible["RefNo"].IfDefault;
            panel.ReadOnly = true;
        }
        private void DGV_MainGetCellStyle(object sender, GridGetCellStyleEventArgs e)
        {
        }
        private void Button_ExportTable2_Click(object sender, EventArgs e)
        {
            try
            {
                ExportExcel.ExportToExcel(DGV_Main, "تقرير سندات المستأجرين");
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
        private void txtDate_Click(object sender, EventArgs e)
        {
            txtGDate.SelectAll();
        }
        private void txtDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtGDate.Text))
                {
                    txtGDate.Text = Convert.ToDateTime(txtGDate.Text).ToString("yyyy/MM/dd");
                    return;
                }
                MaskedTextBox maskedTextBox = txtGDate;
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                maskedTextBox.Text = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
            }
            catch
            {
                MaskedTextBox maskedTextBox2 = txtGDate;
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                maskedTextBox2.Text = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
            }
        }
        private void buttonItem_Print_Click(object sender, EventArgs e)
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
                    _RepShow.Tables = "T_GDDET LEFT OUTER JOIN T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID LEFT OUTER JOIN T_INVSETTING ON T_GDHEAD.gdTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_GDHEAD.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_GDHEAD.gdCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_GDHEAD.gdMnd = T_Mndob.Mnd_ID LEFT OUTER JOIN T_AccDef ON T_GDDET.AccNo = T_AccDef.AccDef_No LEFT OUTER JOIN T_SYSSETTING ON T_GDHEAD.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                    string Fields = " CASE WHEN T_GDDET.gdValue > 0 THEN T_GDDET.gdValue ELSE 0 END as DebitBala , CASE WHEN T_GDDET.gdValue < 0 THEN Abs(T_GDDET.gdValue) ELSE 0 END as CreditBala ," + ((LangArEn == 0) ? " T_Curency.Arb_Des " : " T_Curency.Eng_Des ") + " as CurrnceyNm, T_Curency.Rate ," + ((LangArEn == 0) ? " T_CstTbl.Arb_Des as CostCenteNm " : "T_CstTbl.Eng_Des as CostCenteNm") + " , T_Mndob.Arb_Des as MndNm , T_GDHEAD.* , T_GDDET.AccNo as AccDef_No," + ((LangArEn == 0) ? "T_AccDef.Arb_Des as AccDefNm" : "T_AccDef.Eng_Des as AccDefNm") + "," + ((LangArEn == 0) ? " T_GDDET.gdDes as gdDesDet " : " T_GDDET.gdDesE as gdDesDet ") + ",T_SYSSETTING.LogImg,(T_GDHEAD.ArbTaf + T_Curency.Arb_Des) as ArbTafCurr,(T_GDHEAD.EngTaf + T_Curency.Eng_Des) as EngTafCurr,T_CstTbl.Cst_No,'" + VarGeneral.BranchNameA + "' as BrnchNmA,'" + VarGeneral.BranchNameE + "' as BrnchNmE,(select max(x.AccNo) from T_GDDET as x where x.gdID = (T_GDHEAD.gdhead_ID) and  x.gdValue > 0) as MainAccNo,(select max(T_AccDef.Arb_Des) from T_AccDef right JOIN T_GDDET ON T_AccDef.AccDef_No = T_GDDET.AccNo where T_GDDET.gdID = (T_GDHEAD.gdhead_ID) and  T_GDDET.gdValue > 0) as ManiAccNmA,(select max(T_AccDef.Eng_Des) from T_AccDef right JOIN T_GDDET ON T_AccDef.AccDef_No = T_GDDET.AccNo where T_GDDET.gdID = (T_GDHEAD.gdhead_ID) and  T_GDDET.gdValue > 0) as ManiAccNmE,(select max(T_AccDef.Arb_Des) from T_AccDef where AccDef_No = (select max(x.AccNo) from T_GDDET x where x.gdID = (T_GDDET.gdID) and Lin = 1)) as CusVenNm,(select max(T_AccDef.Eng_Des) from T_AccDef where AccDef_No = (select max(x.AccNo) from T_GDDET x where x.gdID = (T_GDDET.gdID) and Lin = 1)) as CusVenNmE,(select max(T_AccDef.PersonalNm) from T_AccDef where AccDef_No = (select max(x.AccNo) from T_GDDET x where x.gdID = (T_GDDET.gdID) and Lin = 1)) as PersonalNm,(select max(T_AccDef.City) from T_AccDef where AccDef_No = (select max(x.AccNo) from T_GDDET x where x.gdID = (T_GDDET.gdID) and Lin = 1)) as City,(select max(T_AccDef.Email) from T_AccDef where AccDef_No = (select max(x.AccNo) from T_GDDET x where x.gdID = (T_GDDET.gdID) and Lin = 1)) as Email,(select max(T_AccDef.Mobile) from T_AccDef where AccDef_No = (select max(x.AccNo) from T_GDDET x where x.gdID = (T_GDDET.gdID) and Lin = 1)) as Mobile";
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
                    if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                    {
                        return;
                    }
                    try
                    {
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "RepGaidCatchTenant";
                        frm.Repvalue = "RepGaidSerfTenant";
                        frm.Tag = LangArEn;
                        if (VarGeneral.InvTyp == 29)
                        {
                            frm.Repvalue = "RepGaidCatchTenant";
                        }
                        else
                        {
                            frm.Repvalue = "RepGaidSerfTenant";
                        }
                        VarGeneral.vTitle = Text;
                        frm.TopMost = true;
                        frm.ShowDialog();
                    }
                    catch (Exception error)
                    {
                        VarGeneral.DebLog.writeLog("button_ShowRep_Click:", error, enable: true);
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
            columns_Names_visible2.Add("tenantNo", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
            columns_Names_visible2.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible2.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_Tenant";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != "")
                {
                    T_Tenant q = db.StockTenantData(int.Parse(frm.Serach_No));
                    txtCredit1.Tag = q.T_AccDef.AccDef_No;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtCredit1.Text = q.T_AccDef.Arb_Des;
                    }
                    else
                    {
                        txtCredit1.Text = q.T_AccDef.Eng_Des;
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
        private void prnt_doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
            {
                return;
            }
            List<T_mInvPrint> listmInvPrint = new List<T_mInvPrint>();
            T_mInvPrint _mInvPrint = new T_mInvPrint();
            listmInvPrint = (from item in db.T_mInvPrints
                             where item.repTyp == (int?)12
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
                     if(_mInvPrint.pField.Contains("PageTotel"))
                    _mInvPrint.pField = (_mInvPrint.pField.Contains("PageTotelE") ? "StoreNmE" : "StoreNmA");
                  strfiled = ((!(_mInvPrint.pField == "PageNo")) ? VarGeneral.TString.TEmpty_Stock(string.Concat(VarGeneral.RepData.Tables[0].Rows[iiRnt][_mInvPrint.pField])) : (_page + " / " + _PageCount));
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
            string Fields = " CASE WHEN T_GDDET.gdValue > 0 THEN T_GDDET.gdValue ELSE 0 END as DebitBala , CASE WHEN T_GDDET.gdValue < 0 THEN Abs(T_GDDET.gdValue) ELSE 0 END as CreditBala , T_Curency.Arb_Des as Arb_Cur , T_Curency.Eng_Des as Eng_Cur, T_Curency.Rate , T_CstTbl.Arb_Des as Arb_Cst, T_CstTbl.Eng_Des as Eng_Cst , T_Mndob.Arb_Des as Arb_Mnd, T_Mndob.Eng_Des as Eng_Mnd , T_GDHEAD.* , T_GDDET.AccNo as AccDef_No,T_AccDef.Arb_Des ,T_AccDef.Eng_Des ,T_GDDET.gdDes,T_GDDET.gdDesE,T_SYSSETTING.LogImg,(select InvNamA from T_INVSETTING where T_GDHEAD.gdTyp = T_INVSETTING.InvID ) as InvNamA,(select InvNamE from T_INVSETTING where T_GDHEAD.gdTyp = T_INVSETTING.InvID ) as InvNamE,(select InvTypA0 from T_INVSETTING where T_GDHEAD.gdTyp = T_INVSETTING.InvID ) as InvTypA0 ,T_CstTbl.Cst_No,(select T_AccDef.Arb_Des from T_AccDef where T_AccDef.AccDef_No = (select (x.AccNo) from T_GDDET as x where x.gdID = (T_GDDET.gdID) and x.Lin = 1 )) as ch,(select T_AccDef.Eng_Des from T_AccDef where T_AccDef.AccDef_No = (select (x.AccNo) from T_GDDET as x where x.gdID = (T_GDDET.gdID) and x.Lin = 1 )) as tm,(select T_AccDef.Arb_Des from T_AccDef where T_AccDef.AccDef_No = (select (x.AccNo) from T_GDDET as x where x.gdID = (T_GDDET.gdID) and x.Lin = 0 )) as dt,(select T_AccDef.Eng_Des from T_AccDef where T_AccDef.AccDef_No = (select (x.AccNo) from T_GDDET as x where x.gdID = (T_GDDET.gdID) and x.Lin = 0 )) as curr,(select max(T_AccDef.Arb_Des) from T_AccDef where AccDef_No = (select max(x.AccNo) from T_GDDET x where x.gdID = (T_GDDET.gdID) and Lin = 1)) as CusVenNm,(select max(T_AccDef.Eng_Des) from T_AccDef where AccDef_No = (select max(x.AccNo) from T_GDDET x where x.gdID = (T_GDDET.gdID) and Lin = 1)) as CusVenNmE,(select max(T_AccDef.PersonalNm) from T_AccDef where AccDef_No = (select max(x.AccNo) from T_GDDET x where x.gdID = (T_GDDET.gdID) and Lin = 1)) as PersonalNm,(select max(T_AccDef.City) from T_AccDef where AccDef_No = (select max(x.AccNo) from T_GDDET x where x.gdID = (T_GDDET.gdID) and Lin = 1)) as City,(select max(T_AccDef.Email) from T_AccDef where AccDef_No = (select max(x.AccNo) from T_GDDET x where x.gdID = (T_GDDET.gdID) and Lin = 1)) as Email,(select max(T_AccDef.Mobile) from T_AccDef where AccDef_No = (select max(x.AccNo) from T_GDDET x where x.gdID = (T_GDDET.gdID) and Lin = 1)) as Mobile";
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
        private void button_CustD1_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                T_TenantContract q = db.StockTenantContractDataID(int.Parse(txtContractNo.Tag.ToString()));
                txtDebit1.Tag = ((VarGeneral.InvTyp == 29) ? q.T_EqarsData.T_AccDef.AccDef_No : q.T_Tenant.T_AccDef.AccDef_No);
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtDebit1.Text = ((VarGeneral.InvTyp == 29) ? q.T_EqarsData.T_AccDef.Arb_Des : q.T_Tenant.T_AccDef.Arb_Des);
                }
                else
                {
                    txtDebit1.Text = ((VarGeneral.InvTyp == 29) ? q.T_EqarsData.T_AccDef.Eng_Des : q.T_Tenant.T_AccDef.Eng_Des);
                }
            }
            catch
            {
                txtDebit1.Text = "";
                txtDebit1.Tag = "";
            }
        }
        private void button_CustC1_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                T_TenantContract q = db.StockTenantContractDataID(int.Parse(txtContractNo.Tag.ToString()));
                txtCredit1.Tag = ((VarGeneral.InvTyp == 29) ? q.T_Tenant.T_AccDef.AccDef_No : q.T_EqarsData.T_AccDef.AccDef_No);
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtCredit1.Text = ((VarGeneral.InvTyp == 29) ? q.T_Tenant.T_AccDef.Arb_Des : q.T_EqarsData.T_AccDef.Arb_Des);
                }
                else
                {
                    txtCredit1.Text = ((VarGeneral.InvTyp == 29) ? q.T_Tenant.T_AccDef.Eng_Des : q.T_EqarsData.T_AccDef.Eng_Des);
                }
            }
            catch
            {
                txtCredit1.Text = "";
                txtCredit1.Tag = "";
            }
        }
        private void button_SrchTenantNo_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            if (State == FormState.Saved)
            {
                return;
            }
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("ContractNo", new ColumnDictinary("رقم العقد", "Contract No", ifDefault: true, ""));
            columns_Names_visible2.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible2.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            columns_Names_visible2.Add("ContractID", new ColumnDictinary("تسلسل العقد ", " Seq", ifDefault: true, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_TenantContract";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                ContractTenantData(frm.Serach_No);
            }
        }
        private void ContractTenantData(string Serach_No)
        {
            T_TenantContract q = db.StockTenantContractDataID(int.Parse(Serach_No));
            txtTenantNo.Text = q.T_Tenant.tenantNo.ToString();
            txtTenantNo.Tag = q.tenant_ID;
            txtName.Text = ((LangArEn == 0) ? q.T_Tenant.NameA : q.T_Tenant.NameE);
            txtContractNo.Text = q.ContractNo.ToString();
            txtContractNo.Tag = q.ContractID;
            txtValue.Tag = "";
            try
            {
                txtEqarNo.Text = q.T_EqarsData.EqarNo.ToString();
            }
            catch
            {
                txtEqarNo.Text = "";
            }
            try
            {
                txtEyeNo.Text = q.T_AinsData.AinNo.ToString();
            }
            catch
            {
                txtEyeNo.Text = "";
            }
            try
            {
                txtEyeTyp.Text = ((LangArEn == 0) ? q.T_AinsData.T_AinTyp.NameA : q.T_AinsData.T_AinTyp.NameE);
            }
            catch
            {
                txtEyeTyp.Text = "";
            }
            try
            {
                try
                {
                    txtDebit1.Tag = ((VarGeneral.InvTyp == 29) ? q.T_EqarsData.T_AccDef.AccDef_No : q.T_Tenant.T_AccDef.AccDef_No);
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtDebit1.Text = ((VarGeneral.InvTyp == 29) ? q.T_EqarsData.T_AccDef.Arb_Des : q.T_Tenant.T_AccDef.Arb_Des);
                    }
                    else
                    {
                        txtDebit1.Text = ((VarGeneral.InvTyp == 29) ? q.T_EqarsData.T_AccDef.Eng_Des : q.T_Tenant.T_AccDef.Arb_Des);
                    }
                }
                catch
                {
                    txtDebit1.Text = "";
                    txtDebit1.Tag = "";
                }
                try
                {
                    txtCredit1.Tag = ((VarGeneral.InvTyp == 29) ? q.T_Tenant.T_AccDef.AccDef_No : q.T_EqarsData.T_AccDef.AccDef_No);
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtCredit1.Text = ((VarGeneral.InvTyp == 29) ? q.T_Tenant.T_AccDef.Arb_Des : q.T_EqarsData.T_AccDef.Arb_Des);
                    }
                    else
                    {
                        txtCredit1.Text = ((VarGeneral.InvTyp == 29) ? q.T_Tenant.T_AccDef.Arb_Des : q.T_EqarsData.T_AccDef.Eng_Des);
                    }
                }
                catch
                {
                    txtCredit1.Text = "";
                    txtCredit1.Tag = "";
                }
            }
            catch
            {
            }
        }
        private void button_Payment_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            if (State != FormState.New && State != FormState.Edit)
            {
                return;
            }
            int ContractN_ = 0;
            try
            {
                ContractN_ = int.Parse(txtContractNo.Tag.ToString());
            }
            catch
            {
                ContractN_ = 0;
            }
            if (ContractN_ <= 0)
            {
                MessageBox.Show((LangArEn == 0) ? "يرجى اختيار عقد محدد لاتمام العملية" : "Please select a specific contract to complete the process", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            FrmTenantPayment frm = new FrmTenantPayment();
            frm.Tag = LangArEn;
            T_TenantContract q = db.StockTenantContractDataID(ContractN_);
            if (new BindingList<T_TenantPayment>(q.T_TenantPayments).OrderBy((T_TenantPayment g) => g.PaymentNo).ToList().Count <= 0)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يوجد دفعات مقسمة لهذا المستأجر" : "There is no split payments for this tenant", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            frm.data_this = q;
            frm.FrmTyp = true;
            frm.SelectPayment = true;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.PaymentNo > 0)
            {
                T_TenantPayment QData = db.StockTenantPaymentDataID(frm.PaymentNo);
                if (QData != null && QData.PaymentID > 0)
                {
                    txtValue.Tag = QData.PaymentID;
                    txtValue.Value = QData.Value.Value;
                }
            }
        }
    }
}
