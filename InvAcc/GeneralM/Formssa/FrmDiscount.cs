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
    public partial class FrmDiscount : Form
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
        private string FlagUpdate = "";
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
        private IContainer components = null;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!keyData.ToString().Contains("Control") && !keyData.ToString().ToLower().Contains("delete") && keyData.ToString().Contains("Alt"))
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
        private SaveFileDialog saveFileDialog1;
        protected SuperGridControl DGV_Main;
        private PanelEx panelEx3;
        private Timer timerInfoBallon;
        private OpenFileDialog openFileDialog1;
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
            InitializeComponent();
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
                    Environment.Exit(0);
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
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background2 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background3 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor1 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor2 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle1 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle2 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.Background background4 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDiscount));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBox_Minute = new System.Windows.Forms.CheckBox();
            this.comboBox_AmontSleep = new System.Windows.Forms.ComboBox();
            this.comboBox_AmontLate = new System.Windows.Forms.ComboBox();
            this.textBox_Note = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label_lblDaysOfMonth = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_SubTotaly = new DevComponents.Editors.DoubleInput();
            this.textBox_SubValue = new DevComponents.Editors.DoubleInput();
            this.label8 = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.textBox_Count = new DevComponents.Editors.DoubleInput();
            this.lblNumber = new System.Windows.Forms.Label();
            this.comboBox_CalculateNo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDaysOfMonth = new System.Windows.Forms.Label();
            this.comboBox_SubTyp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_EmpNo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label12 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.switchButton_Sts = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.textBox_SalDate = new System.Windows.Forms.MaskedTextBox();
            this.textBox_DayOfMonth = new DevComponents.Editors.IntegerInput();
            this.button_SrchEmp = new DevComponents.DotNetBar.ButtonX();
            this.dateTimeInput_warnDate = new System.Windows.Forms.MaskedTextBox();
            this.ribbonBar_Tasks = new DevComponents.DotNetBar.RibbonBar();
            this.superTabControl_Main1 = new DevComponents.DotNetBar.SuperTabControl();
            this.Button_Close = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem_DisGeneral = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Search = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Delete = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Save = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Add = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
            this.superTabControl_Main2 = new DevComponents.DotNetBar.SuperTabControl();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.Button_First = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Prev = new DevComponents.DotNetBar.ButtonItem();
            this.TextBox_Index = new DevComponents.DotNetBar.TextBoxItem();
            this.Label_Count = new DevComponents.DotNetBar.LabelItem();
            this.lable_Records = new DevComponents.DotNetBar.LabelItem();
            this.Button_Next = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Last = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonBar_FlagCalclatLate = new DevComponents.DotNetBar.RibbonBar();
            this.buttonItem_Late = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem_Sleep = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem4 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem5 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem8 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem6 = new DevComponents.DotNetBar.LabelItem();
            this.buttonItem_SaveLate = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem_SaveAll = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem_Exit = new DevComponents.DotNetBar.ButtonItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.DGV_Main = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.ribbonBar_DGV = new DevComponents.DotNetBar.RibbonBar();
            this.superTabControl_DGV = new DevComponents.DotNetBar.SuperTabControl();
            this.textBox_search = new DevComponents.DotNetBar.TextBoxItem();
            this.Button_ExportTable2 = new DevComponents.DotNetBar.ButtonItem();
            this.Button_PrintTable = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem3 = new DevComponents.DotNetBar.LabelItem();
            this.timerInfoBallon = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.barTopDockSite = new DevComponents.DotNetBar.DockSite();
            this.barBottomDockSite = new DevComponents.DotNetBar.DockSite();
            this.dotNetBarManager1 = new DevComponents.DotNetBar.DotNetBarManager(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.barLeftDockSite = new DevComponents.DotNetBar.DockSite();
            this.barRightDockSite = new DevComponents.DotNetBar.DockSite();
            this.dockSite4 = new DevComponents.DotNetBar.DockSite();
            this.dockSite1 = new DevComponents.DotNetBar.DockSite();
            this.dockSite2 = new DevComponents.DotNetBar.DockSite();
            this.dockSite3 = new DevComponents.DotNetBar.DockSite();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_Rep = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Det = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.PanelSpecialContainer.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_SubTotaly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_SubValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_Count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_DayOfMonth)).BeginInit();
            this.ribbonBar_Tasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main2)).BeginInit();
            this.panelEx3.SuspendLayout();
            this.ribbonBar_DGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_DGV)).BeginInit();
            this.panel1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
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
            this.PanelSpecialContainer.Size = new System.Drawing.Size(649, 361);
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
            this.ribbonBar1.Controls.Add(this.panel2);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(649, 310);
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
            // panel2
            // 
            this.panel2.Controls.Add(this.checkBox_Minute);
            this.panel2.Controls.Add(this.comboBox_AmontSleep);
            this.panel2.Controls.Add(this.comboBox_AmontLate);
            this.panel2.Controls.Add(this.textBox_Note);
            this.panel2.Controls.Add(this.label_lblDaysOfMonth);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.textBox_SubTotaly);
            this.panel2.Controls.Add(this.textBox_SubValue);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.lblValue);
            this.panel2.Controls.Add(this.textBox_Count);
            this.panel2.Controls.Add(this.lblNumber);
            this.panel2.Controls.Add(this.comboBox_CalculateNo);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lblDaysOfMonth);
            this.panel2.Controls.Add(this.comboBox_SubTyp);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.comboBox_EmpNo);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label54);
            this.panel2.Controls.Add(this.textBox_ID);
            this.panel2.Controls.Add(this.label38);
            this.panel2.Controls.Add(this.switchButton_Sts);
            this.panel2.Controls.Add(this.textBox_SalDate);
            this.panel2.Controls.Add(this.textBox_DayOfMonth);
            this.panel2.Controls.Add(this.button_SrchEmp);
            this.panel2.Controls.Add(this.dateTimeInput_warnDate);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(649, 293);
            this.panel2.TabIndex = 6709;
            // 
            // checkBox_Minute
            // 
            this.checkBox_Minute.AutoSize = true;
            this.checkBox_Minute.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox_Minute.Location = new System.Drawing.Point(247, 114);
            this.checkBox_Minute.Name = "checkBox_Minute";
            this.checkBox_Minute.Size = new System.Drawing.Size(77, 17);
            this.checkBox_Minute.TabIndex = 6736;
            this.checkBox_Minute.Text = "بالدقـــائــق";
            this.checkBox_Minute.UseVisualStyleBackColor = true;
            this.checkBox_Minute.Visible = false;
            this.checkBox_Minute.CheckedChanged += new System.EventHandler(this.checkBox_Minute_CheckedChanged);
            // 
            // comboBox_AmontSleep
            // 
            this.comboBox_AmontSleep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_AmontSleep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_AmontSleep.FormattingEnabled = true;
            this.comboBox_AmontSleep.Location = new System.Drawing.Point(699, 67);
            this.comboBox_AmontSleep.Name = "comboBox_AmontSleep";
            this.comboBox_AmontSleep.Size = new System.Drawing.Size(130, 21);
            this.comboBox_AmontSleep.TabIndex = 6734;
            this.comboBox_AmontSleep.SelectedValueChanged += new System.EventHandler(this.comboBox_AmontSleep_SelectedValueChanged);
            // 
            // comboBox_AmontLate
            // 
            this.comboBox_AmontLate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_AmontLate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_AmontLate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_AmontLate.FormattingEnabled = true;
            this.comboBox_AmontLate.Location = new System.Drawing.Point(699, 192);
            this.comboBox_AmontLate.Name = "comboBox_AmontLate";
            this.comboBox_AmontLate.Size = new System.Drawing.Size(130, 21);
            this.comboBox_AmontLate.TabIndex = 6735;
            this.comboBox_AmontLate.SelectedValueChanged += new System.EventHandler(this.comboBox_AmontLate_SelectedValueChanged);
            // 
            // textBox_Note
            // 
            this.textBox_Note.BackColor = System.Drawing.Color.AliceBlue;
            // 
            // 
            // 
            this.textBox_Note.Border.Class = "TextBoxBorder";
            this.textBox_Note.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_Note.ButtonCustom.Visible = true;
            this.textBox_Note.ForeColor = System.Drawing.Color.Black;
            this.textBox_Note.Location = new System.Drawing.Point(69, 203);
            this.textBox_Note.Multiline = true;
            this.textBox_Note.Name = "textBox_Note";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Note, false);
            this.textBox_Note.Size = new System.Drawing.Size(423, 67);
            this.textBox_Note.TabIndex = 12;
            this.textBox_Note.WatermarkColor = System.Drawing.Color.RosyBrown;
            this.textBox_Note.WatermarkFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Note.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.textBox_Note.WatermarkText = "ملاحظـــــــات الخصــــــم";
            // 
            // label_lblDaysOfMonth
            // 
            this.label_lblDaysOfMonth.AutoSize = true;
            this.label_lblDaysOfMonth.BackColor = System.Drawing.Color.Transparent;
            this.label_lblDaysOfMonth.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label_lblDaysOfMonth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_lblDaysOfMonth.Location = new System.Drawing.Point(123, 145);
            this.label_lblDaysOfMonth.Name = "label_lblDaysOfMonth";
            this.label_lblDaysOfMonth.Size = new System.Drawing.Size(109, 13);
            this.label_lblDaysOfMonth.TabIndex = 6731;
            this.label_lblDaysOfMonth.Text = "يخصم من راتب شهـر :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(496, 203);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 6728;
            this.label9.Text = "الملاحظــــات :";
            // 
            // textBox_SubTotaly
            // 
            this.textBox_SubTotaly.AllowEmptyState = false;
            this.textBox_SubTotaly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_SubTotaly.AutoOffFreeTextEntry = true;
            this.textBox_SubTotaly.AutoResolveFreeTextEntries = false;
            // 
            // 
            // 
            this.textBox_SubTotaly.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.textBox_SubTotaly.BackgroundStyle.BorderBottomWidth = 1;
            this.textBox_SubTotaly.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_SubTotaly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_SubTotaly.BackgroundStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_SubTotaly.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_SubTotaly.DisplayFormat = "0.00";
            this.textBox_SubTotaly.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_SubTotaly.Increment = 1D;
            this.textBox_SubTotaly.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_SubTotaly.IsInputReadOnly = true;
            this.textBox_SubTotaly.Location = new System.Drawing.Point(258, 170);
            this.textBox_SubTotaly.Name = "textBox_SubTotaly";
            this.textBox_SubTotaly.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_SubTotaly.Size = new System.Drawing.Size(234, 21);
            this.textBox_SubTotaly.TabIndex = 10;
            // 
            // textBox_SubValue
            // 
            this.textBox_SubValue.AllowEmptyState = false;
            this.textBox_SubValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_SubValue.AutoOffFreeTextEntry = true;
            this.textBox_SubValue.AutoResolveFreeTextEntries = false;
            // 
            // 
            // 
            this.textBox_SubValue.BackgroundStyle.BorderBottomWidth = 1;
            this.textBox_SubValue.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_SubValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_SubValue.BackgroundStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_SubValue.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_SubValue.DisplayFormat = "0.00";
            this.textBox_SubValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_SubValue.Increment = 1D;
            this.textBox_SubValue.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_SubValue.Location = new System.Drawing.Point(258, 141);
            this.textBox_SubValue.Name = "textBox_SubValue";
            this.textBox_SubValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_SubValue.Size = new System.Drawing.Size(66, 21);
            this.textBox_SubValue.TabIndex = 8;
            this.textBox_SubValue.ValueChanged += new System.EventHandler(this.textBox_SubValue_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(496, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 6726;
            this.label8.Text = "الإجمالـــــــي :";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.BackColor = System.Drawing.Color.Transparent;
            this.lblValue.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblValue.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblValue.Location = new System.Drawing.Point(325, 145);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(69, 13);
            this.lblValue.TabIndex = 6725;
            this.lblValue.Text = "قيمة الخصم :";
            // 
            // textBox_Count
            // 
            this.textBox_Count.AllowEmptyState = false;
            this.textBox_Count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Count.AutoOffFreeTextEntry = true;
            this.textBox_Count.AutoResolveFreeTextEntries = false;
            // 
            // 
            // 
            this.textBox_Count.BackgroundStyle.BorderBottomWidth = 1;
            this.textBox_Count.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_Count.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_Count.BackgroundStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Count.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_Count.DisplayFormat = "0.00";
            this.textBox_Count.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_Count.Increment = 1D;
            this.textBox_Count.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_Count.Location = new System.Drawing.Point(426, 141);
            this.textBox_Count.Name = "textBox_Count";
            this.textBox_Count.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_Count.Size = new System.Drawing.Size(66, 21);
            this.textBox_Count.TabIndex = 7;
            this.textBox_Count.ValueChanged += new System.EventHandler(this.textBox_Count_ValueChanged);
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblNumber.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNumber.Location = new System.Drawing.Point(496, 145);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(37, 13);
            this.lblNumber.TabIndex = 6723;
            this.lblNumber.Text = "العدد :";
            // 
            // comboBox_CalculateNo
            // 
            this.comboBox_CalculateNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_CalculateNo.DisplayMember = "Text";
            this.comboBox_CalculateNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_CalculateNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_CalculateNo.FormattingEnabled = true;
            this.comboBox_CalculateNo.ItemHeight = 14;
            this.comboBox_CalculateNo.Location = new System.Drawing.Point(74, 83);
            this.comboBox_CalculateNo.Name = "comboBox_CalculateNo";
            this.comboBox_CalculateNo.Size = new System.Drawing.Size(418, 20);
            this.comboBox_CalculateNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_CalculateNo.TabIndex = 4;
            this.comboBox_CalculateNo.SelectedValueChanged += new System.EventHandler(this.comboBox_CalculateNo_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(496, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 6721;
            this.label2.Text = "احتساب حسب :";
            // 
            // lblDaysOfMonth
            // 
            this.lblDaysOfMonth.AutoSize = true;
            this.lblDaysOfMonth.BackColor = System.Drawing.Color.Transparent;
            this.lblDaysOfMonth.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblDaysOfMonth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDaysOfMonth.Location = new System.Drawing.Point(123, 116);
            this.lblDaysOfMonth.Name = "lblDaysOfMonth";
            this.lblDaysOfMonth.Size = new System.Drawing.Size(109, 13);
            this.lblDaysOfMonth.TabIndex = 6719;
            this.lblDaysOfMonth.Text = "عدد الأيام في الشهر :";
            // 
            // comboBox_SubTyp
            // 
            this.comboBox_SubTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_SubTyp.DisplayMember = "Text";
            this.comboBox_SubTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_SubTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_SubTyp.FormattingEnabled = true;
            this.comboBox_SubTyp.ItemHeight = 14;
            this.comboBox_SubTyp.Location = new System.Drawing.Point(328, 112);
            this.comboBox_SubTyp.Name = "comboBox_SubTyp";
            this.comboBox_SubTyp.Size = new System.Drawing.Size(164, 20);
            this.comboBox_SubTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_SubTyp.TabIndex = 5;
            this.comboBox_SubTyp.SelectedValueChanged += new System.EventHandler(this.comboBox_SubTyp_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(496, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 6717;
            this.label1.Text = "نوع الخصم :";
            // 
            // comboBox_EmpNo
            // 
            this.comboBox_EmpNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_EmpNo.DisplayMember = "Text";
            this.comboBox_EmpNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_EmpNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_EmpNo.FormattingEnabled = true;
            this.comboBox_EmpNo.ItemHeight = 14;
            this.comboBox_EmpNo.Location = new System.Drawing.Point(102, 54);
            this.comboBox_EmpNo.Name = "comboBox_EmpNo";
            this.comboBox_EmpNo.Size = new System.Drawing.Size(390, 20);
            this.comboBox_EmpNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_EmpNo.TabIndex = 3;
            this.comboBox_EmpNo.SelectedIndexChanged += new System.EventHandler(this.comboBox_EmpNo_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(496, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 6715;
            this.label12.Text = "الموظف :";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.BackColor = System.Drawing.Color.Transparent;
            this.label54.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label54.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label54.Location = new System.Drawing.Point(234, 29);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(42, 13);
            this.label54.TabIndex = 6712;
            this.label54.Text = "التاريخ :";
            this.label54.Click += new System.EventHandler(this.label54_Click);
            // 
            // textBox_ID
            // 
            this.textBox_ID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_ID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_ID.Location = new System.Drawing.Point(328, 25);
            this.textBox_ID.Name = "textBox_ID";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_ID, false);
            this.textBox_ID.Size = new System.Drawing.Size(164, 21);
            this.textBox_ID.TabIndex = 1;
            this.textBox_ID.Click += new System.EventHandler(this.textBox_ID_Click);
            this.textBox_ID.TextChanged += new System.EventHandler(this.textBox_ID_TextChanged);
            this.textBox_ID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ID_KeyPress);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.BackColor = System.Drawing.Color.Transparent;
            this.label38.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label38.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label38.Location = new System.Drawing.Point(496, 29);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(36, 13);
            this.label38.TabIndex = 6710;
            this.label38.Text = "الكود :";
            this.label38.Click += new System.EventHandler(this.label38_Click);
            // 
            // switchButton_Sts
            // 
            this.switchButton_Sts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.switchButton_Sts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_Sts.IsReadOnly = true;
            this.switchButton_Sts.Location = new System.Drawing.Point(73, 170);
            this.switchButton_Sts.Name = "switchButton_Sts";
            this.switchButton_Sts.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.switchButton_Sts.OffText = "لم يتم احتسابه";
            this.switchButton_Sts.OffTextColor = System.Drawing.Color.White;
            this.switchButton_Sts.OnText = "تم احتسابه";
            this.switchButton_Sts.Size = new System.Drawing.Size(154, 36);
            this.switchButton_Sts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_Sts.TabIndex = 11;
            // 
            // textBox_SalDate
            // 
            this.textBox_SalDate.BackColor = System.Drawing.Color.Red;
            this.textBox_SalDate.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_SalDate.ForeColor = System.Drawing.Color.White;
            this.textBox_SalDate.Location = new System.Drawing.Point(73, 141);
            this.textBox_SalDate.Mask = "0000/00";
            this.textBox_SalDate.Name = "textBox_SalDate";
            this.textBox_SalDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_SalDate.Size = new System.Drawing.Size(49, 21);
            this.textBox_SalDate.TabIndex = 9;
            this.textBox_SalDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_SalDate.Click += new System.EventHandler(this.textBox_SalDate_Click);
            this.textBox_SalDate.Leave += new System.EventHandler(this.textBox_SalDate_Leave);
            // 
            // textBox_DayOfMonth
            // 
            this.textBox_DayOfMonth.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_DayOfMonth.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_DayOfMonth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_DayOfMonth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_DayOfMonth.DisplayFormat = "0";
            this.textBox_DayOfMonth.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_DayOfMonth.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_DayOfMonth.Location = new System.Drawing.Point(74, 112);
            this.textBox_DayOfMonth.MaxValue = 31;
            this.textBox_DayOfMonth.MinValue = 1;
            this.textBox_DayOfMonth.Name = "textBox_DayOfMonth";
            this.textBox_DayOfMonth.Size = new System.Drawing.Size(48, 21);
            this.textBox_DayOfMonth.TabIndex = 6;
            this.textBox_DayOfMonth.Value = 1;
            this.textBox_DayOfMonth.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            this.textBox_DayOfMonth.ValueChanged += new System.EventHandler(this.textBox_DayOfMonth_ValueChanged);
            // 
            // button_SrchEmp
            // 
            this.button_SrchEmp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchEmp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchEmp.Location = new System.Drawing.Point(74, 54);
            this.button_SrchEmp.Name = "button_SrchEmp";
            this.button_SrchEmp.Size = new System.Drawing.Size(26, 20);
            this.button_SrchEmp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchEmp.Symbol = "";
            this.button_SrchEmp.SymbolSize = 12F;
            this.button_SrchEmp.TabIndex = 6714;
            this.button_SrchEmp.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchEmp.Click += new System.EventHandler(this.button_SrchEmp_Click);
            // 
            // dateTimeInput_warnDate
            // 
            this.dateTimeInput_warnDate.Location = new System.Drawing.Point(74, 25);
            this.dateTimeInput_warnDate.Mask = "0000/00/00";
            this.dateTimeInput_warnDate.Name = "dateTimeInput_warnDate";
            this.dateTimeInput_warnDate.Size = new System.Drawing.Size(153, 20);
            this.dateTimeInput_warnDate.TabIndex = 2;
            this.dateTimeInput_warnDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_warnDate.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.dateTimeInput_warnDate_MaskInputRejected);
            this.dateTimeInput_warnDate.Click += new System.EventHandler(this.dateTimeInput_warnDate_Click);
            this.dateTimeInput_warnDate.Leave += new System.EventHandler(this.dateTimeInput_warnDate_Leave);
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
            this.ribbonBar_Tasks.Controls.Add(this.ribbonBar_FlagCalclatLate);
            this.ribbonBar_Tasks.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ribbonBar_Tasks.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar_Tasks.Location = new System.Drawing.Point(0, 310);
            this.ribbonBar_Tasks.Name = "ribbonBar_Tasks";
            this.ribbonBar_Tasks.Size = new System.Drawing.Size(649, 51);
            this.ribbonBar_Tasks.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar_Tasks.TabIndex = 868;
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
            this.superTabControl_Main1.Size = new System.Drawing.Size(293, 51);
            this.superTabControl_Main1.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_Main1.TabIndex = 10;
            this.superTabControl_Main1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.Button_Close,
            this.buttonItem_DisGeneral,
            this.Button_Search,
            this.Button_Delete,
            this.Button_Save,
            this.Button_Add,
            this.labelItem2});
            this.superTabControl_Main1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.superTabControl_Main1.Text = "superTabControl3";
            this.superTabControl_Main1.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.superTabControl_Main1.RightToLeftChanged += new System.EventHandler(this.superTabControl_Main1_RightToLeftChanged);
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
            // buttonItem_DisGeneral
            // 
            this.buttonItem_DisGeneral.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem_DisGeneral.FontBold = true;
            this.buttonItem_DisGeneral.FontItalic = true;
            this.buttonItem_DisGeneral.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonItem_DisGeneral.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem_DisGeneral.Image")));
            this.buttonItem_DisGeneral.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.buttonItem_DisGeneral.ImagePaddingHorizontal = 15;
            this.buttonItem_DisGeneral.ImagePaddingVertical = 11;
            this.buttonItem_DisGeneral.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem_DisGeneral.Name = "buttonItem_DisGeneral";
            this.buttonItem_DisGeneral.Stretch = true;
            this.buttonItem_DisGeneral.SubItemsExpandWidth = 14;
            this.buttonItem_DisGeneral.Symbol = "";
            this.buttonItem_DisGeneral.SymbolSize = 15F;
            this.buttonItem_DisGeneral.Text = "تعميم";
            this.buttonItem_DisGeneral.Tooltip = "حفظ التغييرات";
            this.buttonItem_DisGeneral.Click += new System.EventHandler(this.buttonItem_DisGeneral_Click);
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
            // labelItem2
            // 
            this.labelItem2.Name = "labelItem2";
            this.labelItem2.Width = 40;
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
            this.superTabControl_Main2.Location = new System.Drawing.Point(293, 0);
            this.superTabControl_Main2.Name = "superTabControl_Main2";
            this.superTabControl_Main2.ReorderTabsEnabled = true;
            this.superTabControl_Main2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.superTabControl_Main2.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_Main2.SelectedTabIndex = -1;
            this.superTabControl_Main2.Size = new System.Drawing.Size(356, 51);
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
            this.TextBox_Index.TextBoxWidth = 35;
            this.TextBox_Index.Visible = false;
            this.TextBox_Index.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // Label_Count
            // 
            this.Label_Count.Name = "Label_Count";
            this.Label_Count.Visible = false;
            this.Label_Count.Width = 30;
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
            // ribbonBar_FlagCalclatLate
            // 
            this.ribbonBar_FlagCalclatLate.AutoOverflowEnabled = false;
            this.ribbonBar_FlagCalclatLate.AutoSizeItems = false;
            // 
            // 
            // 
            this.ribbonBar_FlagCalclatLate.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar_FlagCalclatLate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar_FlagCalclatLate.ContainerControlProcessDialogKey = true;
            this.ribbonBar_FlagCalclatLate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar_FlagCalclatLate.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem_Late,
            this.buttonItem_Sleep,
            this.labelItem4,
            this.labelItem5,
            this.labelItem8,
            this.labelItem6,
            this.buttonItem_SaveLate,
            this.buttonItem_SaveAll,
            this.buttonItem_Exit});
            this.ribbonBar_FlagCalclatLate.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar_FlagCalclatLate.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar_FlagCalclatLate.Name = "ribbonBar_FlagCalclatLate";
            this.ribbonBar_FlagCalclatLate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ribbonBar_FlagCalclatLate.Size = new System.Drawing.Size(649, 51);
            this.ribbonBar_FlagCalclatLate.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro;
            this.ribbonBar_FlagCalclatLate.TabIndex = 131;
            // 
            // 
            // 
            this.ribbonBar_FlagCalclatLate.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar_FlagCalclatLate.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar_FlagCalclatLate.TitleVisible = false;
            this.ribbonBar_FlagCalclatLate.Visible = false;
            // 
            // buttonItem_Late
            // 
            this.buttonItem_Late.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.TextOnlyAlways;
            this.buttonItem_Late.FontBold = true;
            this.buttonItem_Late.HotFontBold = true;
            this.buttonItem_Late.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.buttonItem_Late.ImagePaddingHorizontal = 15;
            this.buttonItem_Late.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem_Late.Name = "buttonItem_Late";
            this.buttonItem_Late.Stretch = true;
            this.buttonItem_Late.SubItemsExpandWidth = 14;
            this.buttonItem_Late.Text = "سجلات التأخير";
            this.buttonItem_Late.Click += new System.EventHandler(this.buttonItem_Late_Click);
            // 
            // buttonItem_Sleep
            // 
            this.buttonItem_Sleep.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.TextOnlyAlways;
            this.buttonItem_Sleep.FontBold = true;
            this.buttonItem_Sleep.HotFontBold = true;
            this.buttonItem_Sleep.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.buttonItem_Sleep.ImagePaddingHorizontal = 15;
            this.buttonItem_Sleep.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem_Sleep.Name = "buttonItem_Sleep";
            this.buttonItem_Sleep.Stretch = true;
            this.buttonItem_Sleep.SubItemsExpandWidth = 14;
            this.buttonItem_Sleep.Text = "سجلات الغيـاب";
            this.buttonItem_Sleep.Click += new System.EventHandler(this.buttonItem_Sleep_Click);
            // 
            // labelItem4
            // 
            this.labelItem4.Name = "labelItem4";
            this.labelItem4.Width = 40;
            // 
            // labelItem5
            // 
            this.labelItem5.Name = "labelItem5";
            this.labelItem5.Width = 40;
            // 
            // labelItem8
            // 
            this.labelItem8.Name = "labelItem8";
            this.labelItem8.Width = 60;
            // 
            // labelItem6
            // 
            this.labelItem6.Name = "labelItem6";
            this.labelItem6.Width = 40;
            // 
            // buttonItem_SaveLate
            // 
            this.buttonItem_SaveLate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem_SaveLate.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem_SaveLate.Image")));
            this.buttonItem_SaveLate.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.buttonItem_SaveLate.ImagePaddingHorizontal = 33;
            this.buttonItem_SaveLate.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem_SaveLate.Name = "buttonItem_SaveLate";
            this.buttonItem_SaveLate.Stretch = true;
            this.buttonItem_SaveLate.SubItemsExpandWidth = 14;
            this.buttonItem_SaveLate.Symbol = "";
            this.buttonItem_SaveLate.Text = "خصــــــم";
            this.buttonItem_SaveLate.Click += new System.EventHandler(this.buttonItem_SaveLate_Click);
            // 
            // buttonItem_SaveAll
            // 
            this.buttonItem_SaveAll.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem_SaveAll.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem_SaveAll.Image")));
            this.buttonItem_SaveAll.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.buttonItem_SaveAll.ImagePaddingHorizontal = 33;
            this.buttonItem_SaveAll.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem_SaveAll.Name = "buttonItem_SaveAll";
            this.buttonItem_SaveAll.Stretch = true;
            this.buttonItem_SaveAll.SubItemsExpandWidth = 14;
            this.buttonItem_SaveAll.Symbol = "";
            this.buttonItem_SaveAll.Text = "خصـم الكـل";
            this.buttonItem_SaveAll.Click += new System.EventHandler(this.buttonItem_SaveAll_Click);
            // 
            // buttonItem_Exit
            // 
            this.buttonItem_Exit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem_Exit.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.buttonItem_Exit.ImagePaddingHorizontal = 33;
            this.buttonItem_Exit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem_Exit.Name = "buttonItem_Exit";
            this.buttonItem_Exit.Stretch = true;
            this.buttonItem_Exit.SubItemsExpandWidth = 14;
            this.buttonItem_Exit.Symbol = "";
            this.buttonItem_Exit.Text = "الرجــــوع";
            this.buttonItem_Exit.Click += new System.EventHandler(this.buttonItem_Exit_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
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
            this.expandableSplitter1.Location = new System.Drawing.Point(0, -1);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(649, 14);
            this.expandableSplitter1.TabIndex = 1;
            this.expandableSplitter1.TabStop = false;
            // 
            // panelEx2
            // 
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx2.Location = new System.Drawing.Point(0, 13);
            this.panelEx2.MinimumSize = new System.Drawing.Size(649, 348);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(649, 348);
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
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "*.rtf";
            this.saveFileDialog1.FileName = "doc1";
            this.saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf|All Files(*.*)|*.*";
            this.saveFileDialog1.FilterIndex = 2;
            this.saveFileDialog1.Title = "Save File";
            // 
            // DGV_Main
            // 
            this.DGV_Main.BackColor = System.Drawing.Color.Transparent;
            background1.BackFillType = DevComponents.DotNetBar.SuperGrid.Style.BackFillType.VerticalCenter;
            background1.Color1 = System.Drawing.Color.Silver;
            background1.Color2 = System.Drawing.Color.White;
            this.DGV_Main.DefaultVisualStyles.GroupByStyles.Default.Background = background1;
            background2.BackFillType = DevComponents.DotNetBar.SuperGrid.Style.BackFillType.Center;
            background2.Color1 = System.Drawing.Color.LightSteelBlue;
            this.DGV_Main.DefaultVisualStyles.RowStyles.Default.Background = background2;
            background3.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DGV_Main.DefaultVisualStyles.RowStyles.MouseOver.Background = background3;
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
            borderColor1.Bottom = System.Drawing.Color.Black;
            borderColor1.Left = System.Drawing.Color.Black;
            borderColor1.Right = System.Drawing.Color.Black;
            borderColor1.Top = System.Drawing.Color.Black;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.BorderColor = borderColor1;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.TextColor = System.Drawing.Color.SteelBlue;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.TextColor = System.Drawing.Color.White;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.FooterStyles.Default.TextColor = System.Drawing.Color.White;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            borderColor2.Bottom = System.Drawing.Color.Black;
            borderColor2.Left = System.Drawing.Color.Black;
            borderColor2.Right = System.Drawing.Color.Black;
            borderColor2.Top = System.Drawing.Color.Black;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.BorderColor = borderColor2;
            baseTreeButtonVisualStyle1.BorderColor = System.Drawing.Color.White;
            baseTreeButtonVisualStyle1.LineColor = System.Drawing.Color.White;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.CircleTreeButtonStyle.ExpandButton = baseTreeButtonVisualStyle1;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.HeaderHLinePattern = DevComponents.DotNetBar.SuperGrid.Style.LinePattern.None;
            background4.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            baseTreeButtonVisualStyle2.Background = background4;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.SquareTreeButtonStyle.ExpandButton = baseTreeButtonVisualStyle2;
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
            this.DGV_Main.Size = new System.Drawing.Size(649, 0);
            this.DGV_Main.TabIndex = 862;
            // 
            // panelEx3
            // 
            this.panelEx3.Controls.Add(this.DGV_Main);
            this.panelEx3.Controls.Add(this.ribbonBar_DGV);
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx3.Location = new System.Drawing.Point(0, 0);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(649, 0);
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
            this.ribbonBar_DGV.Size = new System.Drawing.Size(649, 51);
            this.ribbonBar_DGV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar_DGV.TabIndex = 869;
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
            this.superTabControl_DGV.Size = new System.Drawing.Size(649, 51);
            this.superTabControl_DGV.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_DGV.TabIndex = 12;
            this.superTabControl_DGV.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.textBox_search,
            this.Button_ExportTable2,
            this.Button_PrintTable,
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
            this.Button_PrintTable.Click += new System.EventHandler(this.Button_PrintTable_Click);
            // 
            // labelItem3
            // 
            this.labelItem3.Name = "labelItem3";
            this.labelItem3.Width = 40;
            // 
            // timerInfoBallon
            // 
            this.timerInfoBallon.Interval = 3000;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.rtf";
            this.openFileDialog1.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf|All Files(*.*)|*.*";
            this.openFileDialog1.FilterIndex = 2;
            this.openFileDialog1.Title = "Open File";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelEx3);
            this.panel1.Controls.Add(this.expandableSplitter1);
            this.panel1.Controls.Add(this.panelEx2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(649, 361);
            this.panel1.TabIndex = 897;
            // 
            // barTopDockSite
            // 
            this.barTopDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barTopDockSite.Dock = System.Windows.Forms.DockStyle.Top;
            this.barTopDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barTopDockSite.Location = new System.Drawing.Point(0, 0);
            this.barTopDockSite.Name = "barTopDockSite";
            this.barTopDockSite.Size = new System.Drawing.Size(649, 0);
            this.barTopDockSite.TabIndex = 889;
            this.barTopDockSite.TabStop = false;
            // 
            // barBottomDockSite
            // 
            this.barBottomDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barBottomDockSite.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barBottomDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barBottomDockSite.Location = new System.Drawing.Point(0, 361);
            this.barBottomDockSite.Name = "barBottomDockSite";
            this.barBottomDockSite.Size = new System.Drawing.Size(649, 0);
            this.barBottomDockSite.TabIndex = 890;
            this.barBottomDockSite.TabStop = false;
            // 
            // dotNetBarManager1
            // 
            this.dotNetBarManager1.BottomDockSite = this.barBottomDockSite;
            this.dotNetBarManager1.Images = this.imageList1;
            this.dotNetBarManager1.LeftDockSite = this.barLeftDockSite;
            this.dotNetBarManager1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.dotNetBarManager1.MdiSystemItemVisible = false;
            this.dotNetBarManager1.ParentForm = null;
            this.dotNetBarManager1.RightDockSite = this.barRightDockSite;
            this.dotNetBarManager1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2000;
            this.dotNetBarManager1.ToolbarBottomDockSite = this.dockSite4;
            this.dotNetBarManager1.ToolbarLeftDockSite = this.dockSite1;
            this.dotNetBarManager1.ToolbarRightDockSite = this.dockSite2;
            this.dotNetBarManager1.ToolbarTopDockSite = this.dockSite3;
            this.dotNetBarManager1.TopDockSite = this.barTopDockSite;
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
            // barLeftDockSite
            // 
            this.barLeftDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barLeftDockSite.Dock = System.Windows.Forms.DockStyle.Left;
            this.barLeftDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barLeftDockSite.Location = new System.Drawing.Point(0, 0);
            this.barLeftDockSite.Name = "barLeftDockSite";
            this.barLeftDockSite.Size = new System.Drawing.Size(0, 361);
            this.barLeftDockSite.TabIndex = 891;
            this.barLeftDockSite.TabStop = false;
            // 
            // barRightDockSite
            // 
            this.barRightDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barRightDockSite.Dock = System.Windows.Forms.DockStyle.Right;
            this.barRightDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barRightDockSite.Location = new System.Drawing.Point(649, 0);
            this.barRightDockSite.Name = "barRightDockSite";
            this.barRightDockSite.Size = new System.Drawing.Size(0, 361);
            this.barRightDockSite.TabIndex = 892;
            this.barRightDockSite.TabStop = false;
            // 
            // dockSite4
            // 
            this.dockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite4.Location = new System.Drawing.Point(0, 361);
            this.dockSite4.Name = "dockSite4";
            this.dockSite4.Size = new System.Drawing.Size(649, 0);
            this.dockSite4.TabIndex = 896;
            this.dockSite4.TabStop = false;
            // 
            // dockSite1
            // 
            this.dockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite1.Location = new System.Drawing.Point(0, 0);
            this.dockSite1.Name = "dockSite1";
            this.dockSite1.Size = new System.Drawing.Size(0, 361);
            this.dockSite1.TabIndex = 893;
            this.dockSite1.TabStop = false;
            // 
            // dockSite2
            // 
            this.dockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite2.Location = new System.Drawing.Point(649, 0);
            this.dockSite2.Name = "dockSite2";
            this.dockSite2.Size = new System.Drawing.Size(0, 361);
            this.dockSite2.TabIndex = 894;
            this.dockSite2.TabStop = false;
            // 
            // dockSite3
            // 
            this.dockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite3.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite3.Location = new System.Drawing.Point(0, 0);
            this.dockSite3.Name = "dockSite3";
            this.dockSite3.Size = new System.Drawing.Size(649, 0);
            this.dockSite3.TabIndex = 895;
            this.dockSite3.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // ToolStripMenuItem_Rep
            // 
            this.ToolStripMenuItem_Rep.Checked = true;
            this.ToolStripMenuItem_Rep.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToolStripMenuItem_Rep.Name = "ToolStripMenuItem_Rep";
            this.ToolStripMenuItem_Rep.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem_Rep.Text = "إظهار التقرير";
            // 
            // ToolStripMenuItem_Det
            // 
            this.ToolStripMenuItem_Det.Name = "ToolStripMenuItem_Det";
            this.ToolStripMenuItem_Det.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem_Det.Text = "إظهار التفاصيل";
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
            // netResize1
            // 
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            // 
            // FrmDiscount
            // 
            this.ClientSize = new System.Drawing.Size(649, 361);
            this.Controls.Add(this.PanelSpecialContainer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barTopDockSite);
            this.Controls.Add(this.barBottomDockSite);
            this.Controls.Add(this.barLeftDockSite);
            this.Controls.Add(this.barRightDockSite);
            this.Controls.Add(this.dockSite4);
            this.Controls.Add(this.dockSite1);
            this.Controls.Add(this.dockSite2);
            this.Controls.Add(this.dockSite3);
            this.Icon = global::InvAcc.Properties.Resources.favicon;
            this.KeyPreview = true;
            this.Name = "FrmDiscount";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "كــــــرت الخصــــــم";
            this.Load += new System.EventHandler(this.FrmDiscount_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.PanelSpecialContainer.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_SubTotaly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_SubValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_Count)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_DayOfMonth)).EndInit();
            this.ribbonBar_Tasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main2)).EndInit();
            this.panelEx3.ResumeLayout(false);
            this.ribbonBar_DGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_DGV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
