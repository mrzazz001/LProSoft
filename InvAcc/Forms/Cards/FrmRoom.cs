using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
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
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmRoom : Form
    { void avs(int arln)

{ 
 panelEx2.Text=   (arln == 0 ? "  Click to collapse  " : "  Click to collapse") ; label17.Text=   (arln == 0 ? "  حالة الفرش :  " : "  Mattress condition:") ; label16.Text=   (arln == 0 ? "  عدد الصالات :  " : "  Number of halls:") ; label4.Text=   (arln == 0 ? "  عدد المطابخ :  " : "  Number of kitchens:") ; label3.Text=   (arln == 0 ? "  عدد الغرف :  " : "  The number of rooms :") ; label2.Text=   (arln == 0 ? "  المساحة :  " : "  Space:") ; label1.Text=   (arln == 0 ? "  حالة الغرفة :  " : "  room condition:") ; label15.Text=   (arln == 0 ? "  تلفــــاز :  " : "  Telephone:") ; label13.Text=   (arln == 0 ? "  وصف الحمام :  " : "  Bathroom description:") ; label12.Text=   (arln == 0 ? "  وصف السرير :  " : "  Bed Description:") ; label8.Text=   (arln == 0 ? "  السعر 2 - شهري :  " : "  Price 2-monthly:") ; label7.Text=   (arln == 0 ? "  السعر 2 - يومــي :  " : "  Price 2 - daily:") ; label5.Text=   (arln == 0 ? "  وصف مختصر :  " : "  Brief description:") ; label200.Text=   (arln == 0 ? "  نوع الغرفة :  " : "  room type:") ; label14.Text=   (arln == 0 ? "  شرفة / بلكونة :  " : "  Balcony / balcony:") ; label11.Text=   (arln == 0 ? "  عدد الحمامات :  " : "  number of bathrooms:") ; label10.Text=   (arln == 0 ? "  عدد السراير  :  " : "  number of beds:") ; label9.Text=   (arln == 0 ? "  السعر - شهري :  " : "  Price - Monthly:") ; label6.Text=   (arln == 0 ? "  السعر  - يومـي :  " : "  Price - daily:") ; label400.Text=   (arln == 0 ? "  عدّاد الكهرباء :  " : "  Electricity meter :") ; label300.Text=   (arln == 0 ? "  وصف الموقع :  " : "  Site Description:") ; label40.Text=   (arln == 0 ? "  النزيل :  " : "  Guest:") ; label36.Text=   (arln == 0 ? "  الدور / الطابق :  " : "  Floor / Floor:") ; label380.Text=   (arln == 0 ? "  رقم الغرفة :  " : "  room number :") ; superTabControl_Main1.Text=   (arln == 0 ? "  superTabControl3  " : "  superTabControl3") ; Button_Close.Text=   (arln == 0 ? "  إغلاق  " : "  Close") ; Button_Search.Text=   (arln == 0 ? "  بحث  " : "  Search") ; Button_Save.Text=   (arln == 0 ? "  حفظ  " : "  save") ; buttonItem_Digram.Text=   (arln == 0 ? "  تخطيط الغرف  " : "  room layout") ; superTabControl_Main2.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; Button_First.Text=   (arln == 0 ? "  الأول  " : "  the first") ; Button_Prev.Text=   (arln == 0 ? "  السابق  " : "  the previous") ; lable_Records.Text=   (arln == 0 ? "  ---  " : "  ---") ; Button_Next.Text=   (arln == 0 ? "  التالي  " : "  next one") ; Button_Last.Text=   (arln == 0 ? "  الأخير  " : "  the last one") ; DGV_Main.Text=   (arln == 0 ? " string.Empty " : " string.Empty") ; DGV_Main.Text=   (arln == 0 ? "  جميــع السجــــلات  " : "  All records") ; DGV_Main.Text=   (arln == 0 ? " string.Empty " : " string.Empty") ; panelEx3.Text=   (arln == 0 ? "  Fill Panel  " : "  Fill Panel") ; superTabControl_DGV.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; textBox_search.Text=   (arln == 0 ? "  ...  " : "  ...") ; Button_ExportTable2.Text=   (arln == 0 ? "  تصدير  " : "  Export") ; /*Button_PrintTable.Text=   (arln == 0 ? "  طباعة  " : "  Print") ; */ToolStripMenuItem_Rep.Text=   (arln == 0 ? "  إظهار التقرير  " : "  Show report") ; ToolStripMenuItem_Det.Text=   (arln == 0 ? "  إظهار التفاصيل  " : "  Show details") ; Text = "كرت الغـــــرف";this.Text=   (arln == 0 ? "  كرت الغـــــرف  " : "  room card") ;}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
        public class ColumnDictinary
        {
            public string AText = string.Empty;
            public string EText = string.Empty;
            public bool IfDefault = false;
            public string Format = string.Empty;
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
        private string FlagUpdate = string.Empty;
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstance;
        private T_Rom data_this;
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
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
        protected ButtonItem Button_Save;
        private RibbonBar ribbonBar_DGV;
        private SuperTabControl superTabControl_DGV;
        protected TextBoxItem textBox_search;
        protected ButtonItem Button_ExportTable2;
        protected ButtonItem Button_PrintTable;
        protected LabelItem labelItem3;
        private LabelItem lable_Records;
        private Panel panel2;
        protected Label label11;
        protected Label label10;
        protected Label label8;
        protected Label label9;
        private DoubleInput txtRoomPriceMonth2;
        private DoubleInput txtRoomPriceMonth1;
        protected Label label7;
        protected Label label6;
        private DoubleInput txtRoomPriceDaily2;
        private DoubleInput txtRoomPriceDaily1;
        protected TextBox txtRoomDescription;
        protected Label label5;
        protected TextBox txtRoomCounterNo;
        protected Label label400;
        protected Label label300;
        protected Label label200;
        private ComboBoxEx txtRoomTyp;
        private TextBoxX txtRoomSts;
        protected TextBox txtRoomGuest;
        protected Label label40;
        protected Label label36;
        protected TextBox textBox_ID;
        protected Label label380;
        protected Label label15;
        private ComboBoxEx txtRoomTv;
        protected Label label14;
        private ComboBoxEx txtRoomBalcony;
        protected Label label13;
        private ComboBoxEx txtRoomTwalitTyp;
        protected Label label12;
        private ComboBoxEx txtRoomBedTyp;
        private ComboBoxEx txtRoomDirction;
        private IntegerInput txtRoomBedCount;
        private IntegerInput txtRoomTwalitCount;
        private IntegerInput txtRoomFloor;
        protected Label label1;
        protected ButtonItem buttonItem_Digram;
        private ButtonX button_SrchLoc;
        private ButtonX button_SrchLocADD;
        protected Label label3;
        private IntegerInput txtRoomCount;
        protected Label label2;
        protected TextBox txtRoomArea;
        protected Label label17;
        private ComboBoxEx txtRoomFurnitur;
        protected Label label16;
        private IntegerInput txtSalaacount;
        protected Label label4;
        private IntegerInput txtKitchinCount;
        protected TextBox txtFloorName;
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
        public T_Rom DataThis
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
                if (value != null && value.UsrNo != string.Empty)
                {
                    permission = value;
                    if (!VarGeneral.TString.ChkStatShow(value.RepAcc1, 1))
                    {
                        CanEdit = false;
                        buttonItem_Digram.Enabled = false;
                    }
                    else
                    {
                        CanEdit = true;
                        buttonItem_Digram.Enabled = true;
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
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_Rom";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                textBox_ID.Text = frm.SerachNo.ToString();
            }
        }
        private void TextBox_Search_ButtonCustomClick(object sender, EventArgs e)
        {
            textBox_search.Text = string.Empty;
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
                if (int.Parse(Label_Count.Text ?? string.Empty) <= 0 || (Label_Count.Text ?? string.Empty) == string.Empty)
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
                if (int.Parse(Label_Count.Text ?? string.Empty) <= 0 || (Label_Count.Text ?? string.Empty) == string.Empty)
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
            List<T_Rom> list = db.FillRoom_2(textBox_search.TextBox.Text).ToList();
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                }
            }
            FillHDGV(list);
        }
        public void FillHDGV(IEnumerable<T_Rom> new_data_enum)
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
            DGV_Main.PrimaryGrid.DataMember = "T_Rom";
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
            data_this = new T_Rom();
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
                        controls[i].Text = string.Empty;
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
            if (e.KeyCode == Keys.F2 && Button_Save.Enabled && Button_Save.Visible && State != 0)
            {
                Button_Save_Click(sender, e);
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
            var qkeys = db.T_Roms.Select((T_Rom item) => new
            {
                Code = item.romno + string.Empty
            });
            int count = 0;
            foreach (var item2 in qkeys)
            {
                count++;
                PKeys.Add(item2.Code);
            }
            try
            {
                PKeys = PKeys.OrderBy((string c) => int.Parse(c)).ToList();
            }
            catch
            {
            }
            Label_Count.Text = string.Concat(count);
            UpdateVcr();
        }
        public FrmRoom()
        {
            InitializeComponent();this.Load += langloads;
            controls = new List<Control>();
            controls.Add(textBox_ID);
            codeControl = textBox_ID;
            controls.Add(txtRoomFloor);
            controls.Add(txtRoomGuest);
            controls.Add(txtFloorName);
            Button_Close.Click += Button_Close_Click;
            txtRoomBalcony.Click += Button_Edit_Click;
            txtRoomBedCount.Click += Button_Edit_Click;
            txtRoomFurnitur.Click += Button_Edit_Click;
            txtRoomCount.Click += Button_Edit_Click;
            txtSalaacount.Click += Button_Edit_Click;
            txtKitchinCount.Click += Button_Edit_Click;
            txtRoomArea.Click += Button_Edit_Click;
            txtRoomBedTyp.Click += Button_Edit_Click;
            txtRoomCounterNo.Click += Button_Edit_Click;
            txtRoomDescription.Click += Button_Edit_Click;
            txtRoomDirction.Click += Button_Edit_Click;
            txtRoomFloor.Click += Button_Edit_Click;
            txtRoomGuest.Click += Button_Edit_Click;
            txtRoomPriceDaily1.Click += Button_Edit_Click;
            txtRoomPriceDaily2.Click += Button_Edit_Click;
            txtRoomPriceMonth1.Click += Button_Edit_Click;
            txtRoomPriceMonth2.Click += Button_Edit_Click;
            txtRoomSts.Click += Button_Edit_Click;
            txtRoomTv.Click += Button_Edit_Click;
            txtRoomTwalitCount.Click += Button_Edit_Click;
            txtRoomTwalitTyp.Click += Button_Edit_Click;
            txtRoomTyp.Click += Button_Edit_Click;
            expandableSplitter1.Click += expandableSplitter1_Click;
            ToolStripMenuItem_Det.Click += ToolStripMenuItem_Det_Click;
            Button_ExportTable2.Click += Button_ExportTable2_Click;
            Button_First.Click += Button_First_Click;
            Button_Prev.Click += Button_Prev_Click;
            Button_Next.Click += Button_Next_Click;
            Button_Last.Click += Button_Last_Click;
            Button_Search.Click += Button_Search_Click;
            Button_Save.Click += Button_Save_Click;
            textBox_search.InputTextChanged += TextBox_Search_InputTextChanged;
            textBox_search.ButtonCustomClick += TextBox_Search_ButtonCustomClick;
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmRoom));
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                Button_First.Text = "الأول";
                Button_Last.Text = "الأخير";
                Button_Next.Text = "التالي";
                Button_Prev.Text = "السابق";
                Button_Close.Text = "اغلاق";
                Button_Save.Text = "حفظ";
                Button_Search.Text = "بحث";
                Button_First.Tooltip = "السجل الاول";
                Button_Last.Tooltip = "السجل الاخير";
                Button_Next.Tooltip = "السجل التالي";
                Button_Prev.Tooltip = "السجل السابق";
                Button_Close.Tooltip = "Esc";
                Button_Save.Tooltip = "F2";
                Button_Search.Tooltip = "F4";
                Button_PrintTable.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "طباعة" : "عــرض");
                Button_PrintTable.Tooltip = "F5";
                Button_ExportTable2.Text = "تصدير";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "جميع السجلات";
                Text = "كرت الغــرف";
            }
            else
            {
                Button_First.Text = "First";
                Button_Last.Text = "Last";
                Button_Next.Text = "Next";
                Button_Prev.Text = "Previous";
                Button_Close.Text = "Close";
                Button_Save.Text = "Save";
                Button_Search.Text = "Search";
                Button_First.Tooltip = "First Record";
                Button_Last.Tooltip = "Last Record";
                Button_Next.Tooltip = "Next Record";
                Button_Prev.Tooltip = "Previous Record";
                Button_Close.Tooltip = "Esc";
                Button_Save.Tooltip = "F2";
                Button_Search.Tooltip = "F4";
                Button_PrintTable.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "Print" : "Show");
                Button_PrintTable.Tooltip = "F5";
                Button_ExportTable2.Text = "Export";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "All Records";
                buttonItem_Digram.Text = "Room Diagram";
                Text = "Room Card";
            }
        }
        private void FrmRoom_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmRoom));
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
                    columns_Names_visible.Add("romno", new ColumnDictinary("رقم الغرفة", "Room No", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("flore", new ColumnDictinary("الطابق", "Floor", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("state", new ColumnDictinary("حالة الغرفة", "Room State", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("nmA", new ColumnDictinary("الإسم النزيل العربي", "Arabic Name", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("nmE", new ColumnDictinary("الإسم النزيل الانجليزي", "English Name", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("pri0", new ColumnDictinary("السعر 1 - يومي", "Price 1 - Daily", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("priM0", new ColumnDictinary("السعر 1 - شهري", "Price 1 - Monthly", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("bedno", new ColumnDictinary("عدد السراير", "Beds Count", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("wcno", new ColumnDictinary("عدد الحمامات", "TW Count", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("ShortDsc", new ColumnDictinary("ملاحظـــة", "Note", ifDefault: true, string.Empty));
                }
                else
                {
                    Clear();
                    textBox_ID.Text = string.Empty;
                    TextBox_Index.TextBox.Text = string.Empty;
                }
                RibunButtons();
                RefreshPKeys();
                FillCombo();
                if (VarGeneral._rr)
                {
                    textBox_ID.Text = VarGeneral._hotelrom.ToString();
                    superTabControl_Main2.Visible = false;
                    buttonItem_Digram.Visible = false;
                    Button_Search.Visible = false;
                    expandableSplitter1.Enabled = false;
                }
                else
                {
                    textBox_ID.Text = PKeys.FirstOrDefault();
                }
                ViewDetails_Click(sender, e);
                UpdateVcr();
                if (VarGeneral.vDemo && VarGeneral.UserID != 1)
                {
                    label7.Visible = false;
                    txtRoomPriceDaily2.Visible = false;
                    label8.Visible = false;
                    txtRoomPriceMonth2.Visible = false;
                }
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
                T_Rom newData = db.StockRoom(no);
                if (newData == null || newData.romno == 0)
                {
                    Clear();
                    TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                    TextBox_Index.TextBox.Text = string.Concat(PKeys.Count + 1);
                    TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                }
                else
                {
                    DataThis = newData;
                    int indexA = PKeys.IndexOf(string.Concat(newData.romno));
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
        private void FillCombo()
        {
            txtRoomTyp.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                txtRoomTyp.Items.Add("غرفة");
                txtRoomTyp.Items.Add("جناح");
                txtRoomTyp.Items.Add("فيلا");
                txtRoomTyp.Items.Add("شقة");
            }
            else
            {
                txtRoomTyp.Items.Add("Room");
                txtRoomTyp.Items.Add("suite");
                txtRoomTyp.Items.Add("villa");
                txtRoomTyp.Items.Add("apartment");
            }
            txtRoomTyp.SelectedIndex = 0;
            List<T_Loc> listAccCat = new List<T_Loc>(db.T_Locs.Select((T_Loc item) => item).ToList());
            txtRoomDirction.DataSource = listAccCat;
            txtRoomDirction.DisplayMember = ((LangArEn == 0) ? "Arb_Des" : "Eng_Des");
            txtRoomDirction.ValueMember = "Loc_ID";
            txtRoomDirction.SelectedIndex = 0;
            txtRoomBedTyp.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                txtRoomBedTyp.Items.Add("غير متوفر");
                txtRoomBedTyp.Items.Add("مزدوج");
                txtRoomBedTyp.Items.Add("فردي");
            }
            else
            {
                txtRoomBedTyp.Items.Add("not available");
                txtRoomBedTyp.Items.Add("Double");
                txtRoomBedTyp.Items.Add("Single");
            }
            txtRoomBedTyp.SelectedIndex = 0;
            txtRoomFurnitur.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                txtRoomFurnitur.Items.Add("غير مفـروشة");
                txtRoomFurnitur.Items.Add("مفــروشة");
            }
            else
            {
                txtRoomFurnitur.Items.Add("Not furnished");
                txtRoomFurnitur.Items.Add("Furnished");
            }
            txtRoomFurnitur.SelectedIndex = 0;
            txtRoomTwalitTyp.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                txtRoomTwalitTyp.Items.Add("غير متوفر");
                txtRoomTwalitTyp.Items.Add("مستقل داخلي");
                txtRoomTwalitTyp.Items.Add("مستقل خارجي");
                txtRoomTwalitTyp.Items.Add("مشترك");
            }
            else
            {
                txtRoomTwalitTyp.Items.Add("not available");
                txtRoomTwalitTyp.Items.Add("Independent");
                txtRoomTwalitTyp.Items.Add("Independent external");
                txtRoomTwalitTyp.Items.Add("Mutual");
            }
            txtRoomTwalitTyp.SelectedIndex = 0;
            txtRoomTv.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                txtRoomTv.Items.Add("متوفر");
                txtRoomTv.Items.Add("غير متوفر");
            }
            else
            {
                txtRoomTv.Items.Add("available");
                txtRoomTv.Items.Add("not available");
            }
            txtRoomTv.SelectedIndex = 0;
            txtRoomBalcony.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                txtRoomBalcony.Items.Add("متوفر");
                txtRoomBalcony.Items.Add("غير متوفر");
            }
            else
            {
                txtRoomBalcony.Items.Add("available");
                txtRoomBalcony.Items.Add("not available");
            }
            txtRoomBalcony.SelectedIndex = 0;
        }
        public void SetData(T_Rom value)
        {
            try
            {
                State = FormState.Saved;
                Button_Save.Enabled = false;
                textBox_ID.Tag = value.romno;
                txtRoomBalcony.SelectedIndex = value.bl.Value;
                txtRoomBedCount.Value = value.bedno.Value;
                txtRoomFurnitur.SelectedIndex = value.Furnished.Value;
                txtRoomCount.Value = value.RoomCount.Value;
                txtSalaacount.Value = value.loungesCount.Value;
                txtKitchinCount.Value = value.kitchensCount.Value;
                txtRoomArea.Text = value.AreaDetail;
                txtRoomBedTyp.SelectedIndex = value.bed.Value;
                txtRoomCounterNo.Text = value.Numcounter;
                txtRoomDescription.Text = value.ShortDsc;
                if (value.aline.HasValue)
                {
                    txtRoomDirction.SelectedValue = value.aline;
                }
                else
                {
                    txtRoomDirction.SelectedIndex = 0;
                }
                txtRoomFloor.Text = value.flore.ToString();
                txtRoomFloor_TextChanged(null, null);
                try
                {
                    if (value.perno.HasValue)
                    {
                        txtRoomGuest.Text = ((LangArEn == 0) ? db.StockPer(value.perno.Value).T_AccDef.Arb_Des : db.StockPer(value.perno.Value).T_AccDef.Eng_Des);
                    }
                    else
                    {
                        txtRoomGuest.Text = ((LangArEn == 0) ? "لا يوجد" : "not available");
                    }
                }
                catch
                {
                    txtRoomGuest.Text = ((LangArEn == 0) ? "لا يوجد" : "not available");
                }
                txtRoomPriceDaily1.Value = value.pri0.Value;
                txtRoomPriceDaily2.Value = value.pri1.Value;
                txtRoomPriceMonth1.Value = value.priM0.Value;
                txtRoomPriceMonth2.Value = value.priM1.Value;
                if (value.state.Value == 0)
                {
                    txtRoomSts.Text = ((LangArEn == 0) ? "صيانة" : "Repair");
                }
                if (value.state.Value == 1)
                {
                    txtRoomSts.Text = ((LangArEn == 0) ? "فارغة" : "Empty");
                }
                if (value.state.Value == 2)
                {
                    txtRoomSts.Text = ((LangArEn == 0) ? "نظافة" : "Cleaning");
                }
                if (value.state.Value == 3)
                {
                    txtRoomSts.Text = ((LangArEn == 0) ? "مشغولة" : "Bussy");
                }
                txtRoomTv.SelectedIndex = value.tv.Value;
                txtRoomTwalitCount.Value = value.wcno.Value;
                txtRoomTwalitTyp.SelectedIndex = value.wc.Value;
                txtRoomTyp.SelectedIndex = value.typ.Value;
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
        private T_Rom GetData()
        {
            textBox_ID.Focus();
            data_this.bl = txtRoomBalcony.SelectedIndex;
            data_this.bedno = txtRoomBedCount.Value;
            data_this.Furnished = txtRoomFurnitur.SelectedIndex;
            data_this.RoomCount = txtRoomCount.Value;
            data_this.loungesCount = txtSalaacount.Value;
            data_this.kitchensCount = txtKitchinCount.Value;
            data_this.AreaDetail = txtRoomArea.Text;
            data_this.bed = txtRoomBedTyp.SelectedIndex;
            data_this.Numcounter = txtRoomCounterNo.Text;
            data_this.ShortDsc = txtRoomDescription.Text;
            try
            {
                data_this.aline = int.Parse(txtRoomDirction.SelectedValue.ToString());
            }
            catch
            {
                data_this.aline = 1;
            }
            data_this.flore = txtRoomFloor.Value;
            data_this.pri0 = txtRoomPriceDaily1.Value;
            data_this.pri1 = txtRoomPriceDaily2.Value;
            data_this.priM0 = txtRoomPriceMonth1.Value;
            data_this.priM1 = txtRoomPriceMonth2.Value;
            data_this.tv = txtRoomTv.SelectedIndex;
            data_this.wcno = txtRoomTwalitCount.Value;
            data_this.wc = txtRoomTwalitTyp.SelectedIndex;
            data_this.typ = txtRoomTyp.SelectedIndex;
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
                if (State == FormState.New)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                textBox_ID.Focus();
                if (textBox_ID.Text == string.Empty || txtRoomFloor.Text == string.Empty || txtRoomGuest.Text == string.Empty)
                {
                    MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الرمز او الإسم فارغا\u0651" : "Can not be a number or name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (State == FormState.Edit)
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
                TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(string.Concat(data_this.romno)) + 1);
                SetReadOnly = true;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Save:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void DGV_Main_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            string dataMember = panel.DataMember;
            if (dataMember != null && dataMember == "T_Rom")
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
            panel.Columns["romno"].Width = 100;
            panel.Columns["romno"].Visible = columns_Names_visible["romno"].IfDefault;
            panel.Columns["flore"].Width = 100;
            panel.Columns["flore"].Visible = columns_Names_visible["flore"].IfDefault;
            panel.Columns["state"].Width = 150;
            panel.Columns["state"].Visible = columns_Names_visible["state"].IfDefault;
            panel.Columns["nmA"].Width = 250;
            panel.Columns["nmA"].Visible = columns_Names_visible["nmA"].IfDefault;
            panel.Columns["nmE"].Width = 250;
            panel.Columns["nmE"].Visible = columns_Names_visible["nmE"].IfDefault;
            panel.Columns["pri0"].Width = 150;
            panel.Columns["pri0"].Visible = columns_Names_visible["pri0"].IfDefault;
            panel.Columns["priM0"].Width = 150;
            panel.Columns["priM0"].Visible = columns_Names_visible["priM0"].IfDefault;
            panel.Columns["bedno"].Width = 100;
            panel.Columns["bedno"].Visible = columns_Names_visible["bedno"].IfDefault;
            panel.Columns["wcno"].Width = 100;
            panel.Columns["wcno"].Visible = columns_Names_visible["wcno"].IfDefault;
            panel.Columns["ShortDsc"].Width = 250;
            panel.Columns["ShortDsc"].Visible = columns_Names_visible["ShortDsc"].IfDefault;
            panel.ReadOnly = true;
        }
        private void DGV_MainGetCellStyle(object sender, GridGetCellStyleEventArgs e)
        {
        }
        private void Button_ExportTable2_Click(object sender, EventArgs e)
        {
            try
            {
                ExportExcel.ExportToExcel(DGV_Main, "تقرير مواصفات الغرف");
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
            if (ViewState != 0)
            {
                return;
            }
            try
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Rom left join T_SYSSETTING on T_SYSSETTING.SYSSETTING_ID = T_Rom.CompanyID ";
                string Fields = string.Empty;
                Fields = " T_Rom.romno as No, T_Rom.Arb_Des as NmA, T_Rom.Eng_Des as NmE,T_SYSSETTING.LogImg ";
                _RepShow.Rule = string.Empty;
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
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }
        private void DGV_Main_GetCellFormattedValue(object sender, GridGetCellFormattedValueEventArgs e)
        {
            try
            {
                if (!e.GridCell.GridColumn.Name.Equals("state") || e.GridCell.Value == null)
                {
                    return;
                }
                try
                {
                    if (e.GridCell.Value.ToString() == "0")
                    {
                        e.FormattedValue = ((LangArEn == 0) ? "صيانة" : "Repair");
                    }
                    if (e.GridCell.Value.ToString() == "1")
                    {
                        e.FormattedValue = ((LangArEn == 0) ? "فارغة" : "Empty");
                    }
                    if (e.GridCell.Value.ToString() == "2")
                    {
                        e.FormattedValue = ((LangArEn == 0) ? "نظافة" : "Cleaning");
                    }
                    if (e.GridCell.Value.ToString() == "3")
                    {
                        e.FormattedValue = ((LangArEn == 0) ? "مشغولة" : "Bussy");
                    }
                }
                catch
                {
                    e.FormattedValue = ((LangArEn == 0) ? "فارغة" : "Empty");
                }
            }
            catch
            {
            }
        }
        private void buttonItem_Digram_Click(object sender, EventArgs e)
        {
            if (State != 0)
            {
                return;
            }
            try
            {
                if (string.IsNullOrEmpty(textBox_ID.Text))
                {
                    return;
                }
            }
            catch
            {
                return;
            }
            FrmRoomDigram frm = new FrmRoomDigram();
            frm.Tag = LangArEn;
            VarGeneral._RunDiagram = true;
            frm.TopMost = true;
            frm.ShowDialog();
            dbInstance = null;
            RefreshPKeys();
            Button_Last_Click(sender, e);
        }
        private void button_SrchLocADD_Click(object sender, EventArgs e)
        {
            FrmLocation frm = new FrmLocation();
            frm.Tag = LangArEn;
            frm.TopMost = true;
            frm.ShowDialog();
            object c = txtRoomDirction.SelectedValue;
            try
            {
                txtRoomDirction.DataSource = null;
            }
            catch
            {
            }
            try
            {
                txtRoomDirction.Items.Clear();
            }
            catch
            {
            }
            List<T_Loc> listAccCat = new List<T_Loc>(db.T_Locs.Select((T_Loc item) => item).ToList());
            txtRoomDirction.DataSource = listAccCat;
            txtRoomDirction.DisplayMember = ((LangArEn == 0) ? "Arb_Des" : "Eng_Des");
            txtRoomDirction.ValueMember = "Loc_ID";
            txtRoomDirction.SelectedIndex = 0;
            txtRoomDirction.SelectedValue = c;
        }
        private void button_SrchLoc_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            if (State == FormState.Saved)
            {
                return;
            }
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("Loc_No", new ColumnDictinary("الرقـــم", "No", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_Loc";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                txtRoomDirction.SelectedValue = db.StockLoc(int.Parse(frm.Serach_No).ToString()).Loc_ID;
            }
            else
            {
                txtRoomDirction.SelectedIndex = 0;
            }
        }
        private void txtRoomFloor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtRoomFloor.Text))
                {
                    txtFloorName.Text = string.Empty;
                    return;
                }
                List<T_RomChart> q = db.T_RomCharts.Where((T_RomChart t) => t.ID == txtRoomFloor.Value).ToList();
                if (q.Count > 0)
                {
                    txtFloorName.Text = ((LangArEn == 0) ? q.FirstOrDefault().FName : q.FirstOrDefault().FNameE);
                }
                else
                {
                    txtFloorName.Text = string.Empty;
                }
            }
            catch
            {
                txtFloorName.Text = string.Empty;
            }
        }
    }
}
