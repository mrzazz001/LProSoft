using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Library.RepShow;
using Microsoft.Win32;
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
namespace InvAcc.Forms
{
    public partial  class FrmNewPeaper : Form
    { void avs(int arln)

{ 
}
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
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private T_AccDef _AccDefBind = new T_AccDef();
        private int LangArEn = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
        private string FlagUpdate = "";
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        private T_SYSSETTING _SysSetting = new T_SYSSETTING();
        private List<T_SYSSETTING> listSysSetting = new List<T_SYSSETTING>();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private List<T_INVSETTING> listInvSetting = new List<T_INVSETTING>();
        private T_GDHEAD _GdHead = new T_GDHEAD();
        private List<T_GDHEAD> listGdHead = new List<T_GDHEAD>();
        private T_GDDET _GdDet = new T_GDDET();
        private List<T_GDDET> listGdDet = new List<T_GDDET>();
        private List<T_GdAuto> listGdAuto = new List<T_GdAuto>();
        private T_GdAuto _GdAuto = new T_GdAuto();
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstance;
        private T_BankPeaper data_this;
        private string vTextID = "";
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
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
                        frm.Repvalue = "RepBankPeaperList";
                        frm.Repvalue = "RepGaidBankPeaper";
                        frm.Repvalue = "RepBankPeaperList";
                        frm.Repvalue = "RepGaidBankPeaper";
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
        private ExpandableSplitter expandableSplitter1;
        private PanelEx panelEx2;
        private RibbonBar ribbonBar1;
        private GroupPanel groupPanel2;
        private Timer timer1;
        private Panel panel1;
        private PanelEx panelEx3;
        protected SuperGridControl DGV_Main;
        private RibbonBar ribbonBar_DGV;
        private SuperTabControl superTabControl_DGV;
        protected TextBoxItem textBox_search;
        protected ButtonItem Button_ExportTable2;
        protected ButtonItem Button_PrintTable;
        protected LabelItem labelItem3;
        private Timer timerInfoBallon;
        private ImageList imageList1;
        private System.Windows.Forms. SaveFileDialog saveFileDialog1;
        protected ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.OpenFileDialog  openFileDialog1;
        protected ContextMenuStrip contextMenuStrip2;
        protected ToolStripMenuItem ToolStripMenuItem_Det;
        private SwitchButton switchButton_AccType;
        internal Label label4;
        private ComboBoxEx CmbCustSupp;
        private Label label3;
        private Label label1;
        internal Label label6;
        private MaskedTextBox txtDatePay;
        internal Label label5;
        private MaskedTextBox txtDate;
        internal GroupBox groupBox5;
        private CheckBoxX checkBox_Campiala;
        private CheckBoxX checkBox_Check;
        internal TextBox txtPeaperNo;
        internal Label label7;
        internal Label label8;
        private DoubleInput txtAmount;
        protected TextBox textBox_ID;
        private ButtonX buttonItem_PuySts;
        private ComboBoxEx CmbBranche;
        private TextBox textBox_Usr;
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
        internal PrintPreviewDialog prnt_prev;
        private PrintDocument prnt_doc;
        private ImageList imageList2;
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
        public T_BankPeaper DataThis
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
                    if (!VarGeneral.TString.ChkStatShow(value.SndStr, 29))
                    {
                        IfAdd = false;
                    }
                    else
                    {
                        IfAdd = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.SndStr, 30))
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.SndStr, 31))
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
            VarGeneral.SFrmTyp = "T_BankPeaper";
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
            List<T_BankPeaper> list = db.FillBankPeaper_2(VarGeneral.InvTyp, textBox_search.TextBox.Text, 3).ToList();
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                }
            }
            FillHDGV(list);
        }
        public void FillHDGV(IEnumerable<T_BankPeaper> new_data_enum)
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
            DGV_Main.PrimaryGrid.DataMember = "T_BankPeaper";
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
            data_this = new T_BankPeaper();
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
            textBox_ID.Focus();
            buttonItem_PuySts.Text = "";
            buttonItem_PuySts.Visible = false;
            textBox_Usr.Text = ((LangArEn == 0) ? VarGeneral.UserNameA : VarGeneral.UserNameE);
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
            var qkeys = from item in db.T_BankPeapers
                        where item.gdTyp == (int?)VarGeneral.InvTyp
                        where item.IfDel == (int?)0
                        select new
                        {
                            Code = item.ID + ""
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
        public FrmNewPeaper(string vValue, bool Sts)
        {
            InitializeComponent();this.Load += langloads;
            vTextID = vValue;
            switchButton_AccType.Value = Sts;
            controls = new List<Control>();
            controls.Add(textBox_ID);
            codeControl = textBox_ID;
            controls.Add(txtAmount);
            controls.Add(CmbBranche);
            controls.Add(txtDate);
            controls.Add(txtDatePay);
            controls.Add(txtPeaperNo);
            controls.Add(checkBox_Campiala);
            controls.Add(checkBox_Check);
            controls.Add(switchButton_AccType);
            controls.Add(CmbCustSupp);
            Button_Close.Click += Button_Close_Click;
            txtAmount.Click += Button_Edit_Click;
            CmbBranche.Click += Button_Edit_Click;
            txtDate.Click += Button_Edit_Click;
            txtDatePay.Click += Button_Edit_Click;
            txtPeaperNo.Click += Button_Edit_Click;
            txtPeaperNo.Click += Button_Edit_Click;
            checkBox_Campiala.Click += Button_Edit_Click;
            checkBox_Check.Click += Button_Edit_Click;
            switchButton_AccType.Click += Button_Edit_Click;
            CmbCustSupp.Click += Button_Edit_Click;
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
            TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
            DGV_Main.MouseDown += DGV_Main_MouseDown;
            DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
            DGV_Main.CellClick += DGV_Main_CellClick;
            DGV_Main.GetCellStyle += DGV_MainGetCellStyle;
            DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
            DGV_Main.DataBindingComplete += DGV_Main_DataBindingComplete;
            Button_PrintTable.Click += Button_Print_Click;
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
            {
                txtAmount.DisplayFormat = VarGeneral.DicemalMask;
            }
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmNewPeaper));
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
                buttonItem_Print.Text = ((_InvSetting.InvpRINTERInfo.nTyp.Substring(2, 1) == "1") ? "طباعة" : "عــرض");
                buttonItem_Print.Tooltip = "F5";
                Button_ExportTable2.Text = "تصدير";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "جميع السجلات";
                Text = "الأوراق البنكية";
                buttonItem_PuySts.Text = "";
                if (!switchButton_AccType.Value)
                {
                    label3.Text = "وارد مـــــن :";
                }
                else
                {
                    label3.Text = "محـــرر لـــ :";
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
                Button_PrintTable.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "Print" : "Show");
                buttonItem_Print.Text = ((_InvSetting.InvpRINTERInfo.nTyp.Substring(2, 1) == "1") ? "Print" : "Show");
                buttonItem_Print.Tooltip = "F5";
                Button_ExportTable2.Text = "Export";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "All Records";
                Text = "Bank Peapers";
                buttonItem_PuySts.Text = "";
                if (!switchButton_AccType.Value)
                {
                    label3.Text = "Issued by :";
                }
                else
                {
                    label3.Text = "Editor :";
                }
            }
        }
        private void FillCombo()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                List<T_AccDef> LAccDef = (from t in db.T_AccDefs
                                          where t.Lev == (int?)4 && t.Sts == (int?)0 && (t.AccCat == (int?)4 || t.AccCat == (int?)5)
                                          orderby t.AccDef_No
                                          select t).ToList();
                if (LAccDef.Count() > 0)
                {
                    for (int i = 0; i < LAccDef.Count; i++)
                    {
                        LAccDef[i].Debit = LAccDef[i].T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.gdValue > 0.0).Sum((T_GDDET g) => g.gdValue.Value);
                        LAccDef[i].Credit = Math.Abs(LAccDef[i].T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.gdValue < 0.0).Sum((T_GDDET g) => g.gdValue.Value));
                        LAccDef[i].Balance = LAccDef[i].T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok).Sum((T_GDDET g) => g.gdValue.Value);
                    }
                }
                LAccDef.Insert(0, new T_AccDef());
                CmbCustSupp.DataSource = LAccDef;
                CmbCustSupp.DisplayMember = "Arb_Des";
                CmbCustSupp.ValueMember = "AccDef_No";
                LAccDef = (from t in db.T_AccDefs
                           where t.Lev == (int?)4 && t.AccCat == (int?)3 && t.Sts == (int?)0
                           orderby t.AccDef_No
                           select t).ToList();
                for (int i = 0; i < LAccDef.Count; i++)
                {
                    LAccDef[i].Debit = LAccDef[i].T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.gdValue > 0.0).Sum((T_GDDET g) => g.gdValue.Value);
                    LAccDef[i].Credit = Math.Abs(LAccDef[i].T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.gdValue < 0.0).Sum((T_GDDET g) => g.gdValue.Value));
                    LAccDef[i].Balance = LAccDef[i].T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok).Sum((T_GDDET g) => g.gdValue.Value);
                }
                LAccDef.Insert(0, new T_AccDef());
                CmbBranche.DataSource = LAccDef;
                CmbBranche.DisplayMember = "Arb_Des";
                CmbBranche.ValueMember = "AccDef_No";
            }
            else
            {
                List<T_AccDef> LAccDef = (from t in db.T_AccDefs
                                          where t.Lev == (int?)4 && t.Sts == (int?)0 && (t.AccCat == (int?)4 || t.AccCat == (int?)5)
                                          orderby t.AccDef_No
                                          select t).ToList();
                if (LAccDef.Count() > 0)
                {
                    for (int i = 0; i < LAccDef.Count; i++)
                    {
                        LAccDef[i].Debit = LAccDef[i].T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.gdValue > 0.0).Sum((T_GDDET g) => g.gdValue.Value);
                        LAccDef[i].Credit = Math.Abs(LAccDef[i].T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.gdValue < 0.0).Sum((T_GDDET g) => g.gdValue.Value));
                        LAccDef[i].Balance = LAccDef[i].T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok).Sum((T_GDDET g) => g.gdValue.Value);
                    }
                }
                LAccDef.Insert(0, new T_AccDef());
                CmbCustSupp.DataSource = LAccDef;
                CmbCustSupp.DisplayMember = "Eng_Des";
                CmbCustSupp.ValueMember = "AccDef_No";
                LAccDef = (from t in db.T_AccDefs
                           where t.Lev == (int?)4 && t.AccCat == (int?)3 && t.Sts == (int?)0
                           orderby t.AccDef_No
                           select t).ToList();
                for (int i = 0; i < LAccDef.Count; i++)
                {
                    LAccDef[i].Debit = LAccDef[i].T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.gdValue > 0.0).Sum((T_GDDET g) => g.gdValue.Value);
                    LAccDef[i].Credit = Math.Abs(LAccDef[i].T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.gdValue < 0.0).Sum((T_GDDET g) => g.gdValue.Value));
                    LAccDef[i].Balance = LAccDef[i].T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok).Sum((T_GDDET g) => g.gdValue.Value);
                }
                LAccDef.Insert(0, new T_AccDef());
                CmbBranche.DataSource = LAccDef;
                CmbBranche.DisplayMember = "Eng_Des";
                CmbBranche.ValueMember = "AccDef_No";
            }
            CmbCustSupp.SelectedIndex = 0;
            CmbBranche.SelectedIndex = 0;
        }
        private void ADD_Controls()
        {
            try
            {
                controls = new List<Control>();
                controls.Add(textBox_ID);
                codeControl = textBox_ID;
                controls.Add(txtAmount);
                controls.Add(txtDate);
                controls.Add(txtDatePay);
                controls.Add(txtPeaperNo);
                controls.Add(checkBox_Campiala);
                controls.Add(checkBox_Check);
                controls.Add(CmbBranche);
                controls.Add(CmbCustSupp);
                controls.Add(textBox_Usr);
            }
            catch (SqlException)
            {
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
        }
        private void FrmNewPeaper_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmNewPeaper));
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
                if (columns_Names_visible.Count == 0)
                {
                    columns_Names_visible.Add("PageNo", new ColumnDictinary("رقم الورقة", "Peaper No", ifDefault: true, ""));
                    columns_Names_visible.Add("PageDate", new ColumnDictinary("تاريخ التحرير", "Date", ifDefault: true, ""));
                    columns_Names_visible.Add("PageDatePay", new ColumnDictinary("تاريخ الإستحقاق", "Pay Date", ifDefault: true, ""));
                    columns_Names_visible.Add("BankAcc", new ColumnDictinary("حساب البنك", "Bank ACC", ifDefault: true, ""));
                    columns_Names_visible.Add("BranchAcc", new ColumnDictinary("حساب الفرع", "Branche ACC", ifDefault: true, ""));
                    columns_Names_visible.Add("Amount", new ColumnDictinary("المبلــغ", "Value", ifDefault: false, ""));
                    columns_Names_visible.Add("gdID", new ColumnDictinary("رقم القيد المحاسبي", "Gaid No", ifDefault: false, ""));
                    columns_Names_visible.Add("ID", new ColumnDictinary("الرقم التسلسلي", "Auto No", ifDefault: false, ""));
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
                if (!string.IsNullOrEmpty(vTextID))
                {
                    textBox_ID.Text = vTextID;
                }
                else
                {
                    textBox_ID.Text = PKeys.FirstOrDefault();
                }
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
                T_BankPeaper newData = db.StockBankPeaper(no);
                if (newData == null || newData.ID == 0)
                {
                    if (!Button_Add.Visible || !Button_Add.Enabled)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textBox_ID.TextChanged -= textBox_ID_TextChanged;
                        try
                        {
                            textBox_ID.Text = data_this.ID.ToString();
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
                    int indexA = PKeys.IndexOf(newData.ID.ToString() ?? "");
                    indexA++;
                    TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                    TextBox_Index.TextBox.Text = string.Concat(indexA);
                    TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                }
                try
                {
                    if (data_this.PayState.HasValue)
                    {
                        if (data_this.PayState.Value == 0)
                        {
                            CanEdit = true;
                            buttonItem_PuySts.Text = ((LangArEn == 0) ? "غير مســدد" : "Unsettled");
                            buttonItem_PuySts.Symbol = "\uf088";
                            buttonItem_PuySts.Visible = true;
                        }
                        else if (data_this.PayState.Value == 1)
                        {
                            CanEdit = false;
                            buttonItem_PuySts.Text = ((LangArEn == 0) ? "تم الســداد" : "Settled");
                            buttonItem_PuySts.Symbol = "\uf087";
                            buttonItem_PuySts.Visible = true;
                        }
                        else
                        {
                            CanEdit = false;
                            buttonItem_PuySts.Text = ((LangArEn == 0) ? "مرفـــــوض" : "Unacceptable");
                            buttonItem_PuySts.Symbol = "\uf00d";
                            buttonItem_PuySts.Visible = true;
                        }
                    }
                    else
                    {
                        buttonItem_PuySts.Text = "";
                        buttonItem_PuySts.Visible = false;
                    }
                }
                catch
                {
                    CanEdit = false;
                    buttonItem_PuySts.Text = "";
                    buttonItem_PuySts.Visible = false;
                }
            }
            catch
            {
            }
            UpdateVcr();
        }
        public void SetData(T_BankPeaper value)
        {
            try
            {
                State = FormState.Saved;
                Button_Save.Enabled = false;
                txtPeaperNo.Text = value.PageNo;
                txtAmount.Value = value.Amount.Value;
                if (VarGeneral.CheckDate(value.PageDate))
                {
                    txtDate.Text = Convert.ToDateTime(value.PageDate).ToString("yyyy/MM/dd");
                }
                if (VarGeneral.CheckDate(value.PageDatePay))
                {
                    txtDatePay.Text = Convert.ToDateTime(value.PageDatePay).ToString("yyyy/MM/dd");
                }
                try
                {
                    for (int iiCnt = 0; iiCnt < CmbCustSupp.Items.Count; iiCnt++)
                    {
                        CmbCustSupp.SelectedIndex = iiCnt;
                        if (CmbCustSupp.SelectedValue != null)
                        {
                            if (CmbCustSupp.SelectedValue.ToString() == value.CustAcc)
                            {
                                break;
                            }
                            CmbCustSupp.SelectedIndex = 0;
                        }
                    }
                }
                catch
                {
                    CmbCustSupp.SelectedIndex = 0;
                }
                try
                {
                    for (int iiCnt = 0; iiCnt < CmbBranche.Items.Count; iiCnt++)
                    {
                        CmbBranche.SelectedIndex = iiCnt;
                        if (CmbBranche.SelectedValue != null)
                        {
                            if (CmbBranche.SelectedValue.ToString() == value.BranchAcc)
                            {
                                break;
                            }
                            CmbBranche.SelectedIndex = 0;
                        }
                    }
                }
                catch
                {
                    CmbBranche.SelectedIndex = 0;
                }
                if (value.PageType.HasValue)
                {
                    switchButton_AccType.Value = value.PageType.Value;
                }
                if (value.vTyp.HasValue)
                {
                    if (value.vTyp.Value)
                    {
                        checkBox_Check.Checked = true;
                        checkBox_Campiala.Checked = false;
                    }
                    else
                    {
                        checkBox_Check.Checked = false;
                        checkBox_Campiala.Checked = true;
                    }
                }
                textBox_Usr.Text = ((LangArEn == 0) ? dbc.RateUsr(value.gdUser).UsrNamA : dbc.RateUsr(value.gdUser).UsrNamE);
                if (value.gdID.HasValue)
                {
                    listGdHead = db.StockGdHeadid(value.gdID.Value);
                    if (listGdHead.Count != 0)
                    {
                        _GdHead = listGdHead[0];
                        listGdDet = _GdHead.T_GDDETs.ToList();
                    }
                    else
                    {
                        _GdHead = new T_GDHEAD();
                    }
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
        private T_BankPeaper GetData()
        {
            textBox_ID.Focus();
            data_this.PageNo = txtPeaperNo.Text;
            data_this.Amount = txtAmount.Value;
            data_this.IfDel = 0;
            data_this.gdUser = VarGeneral.UserNumber;
            data_this.gdTyp = VarGeneral.InvTyp;
            data_this.PageDate = txtDate.Text;
            data_this.PageDatePay = txtDatePay.Text;
            if (CmbCustSupp.SelectedIndex > 0)
            {
                data_this.CustAcc = CmbCustSupp.SelectedValue.ToString();
            }
            else
            {
                data_this.CustAcc = null;
            }
            data_this.BankAcc = null;
            if (CmbBranche.SelectedIndex > 0)
            {
                data_this.BranchAcc = CmbBranche.SelectedValue.ToString();
            }
            else
            {
                data_this.BranchAcc = null;
            }
            if (checkBox_Check.Checked)
            {
                data_this.vTyp = true;
            }
            else
            {
                data_this.vTyp = false;
            }
            data_this.PageType = switchButton_AccType.Value;
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
            else
            {
                if (State == FormState.Edit && MessageBox.Show((LangArEn == 0) ? "تم تعديل السجل الحالي دون حفظ التغييرات .. هل تريد المتابعة؟" : "Not saved the changes, do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    return;
                }
                Clear();
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                if (calendr.Value == 0 && calendr.HasValue)
                {
                    txtDate.Text = VarGeneral.Gdate;
                }
                else
                {
                    txtDate.Text = VarGeneral.Hdate;
                }
                textBox_ID.Text = "";
                int max = 1;
                try
                {
                    max = db.T_BankPeapers.Where((T_BankPeaper t) => t.gdTyp == (int?)VarGeneral.InvTyp).Max((T_BankPeaper lgl) => Convert.ToInt32(lgl.PageNo)) + 1;
                }
                catch
                {
                }
                txtPeaperNo.Text = max.ToString();
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
                if (txtPeaperNo.Text == "")
                {
                    MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون رقم الورقة فارغا" : "Can not be a page number empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtPeaperNo.Focus();
                    return;
                }
                if (CmbCustSupp.SelectedIndex <= 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من اسم العميل او المورد ثم حاول مرة اخرى" : "Check customer or supplier", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    CmbCustSupp.Focus();
                    return;
                }
                if (CmbBranche.SelectedIndex <= 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من اسم البنك ثم حاول مرة اخرى" : "Check Bank Name", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    CmbBranche.Focus();
                    return;
                }
                if (txtAmount.Value <= 0.0)
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من المبلغ ثم حاول مرة اخرى" : "Check Value", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtAmount.Focus();
                    return;
                }
                if (!VarGeneral.CheckDate(txtDatePay.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من تاريخ الإستحقاق ثم حاول مرة اخرى" : "Check Puy Date", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtDatePay.Focus();
                    return;
                }
                if (!VarGeneral.CheckDate(txtDate.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من تاريخ التحرير ثم حاول مرة اخرى" : "Check Date", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtDate.Focus();
                    return;
                }
                if (false)
                {
                    Environment.Exit(0);
                    return;
                }
                List<T_BankPeaper> returned;
                if (State == FormState.New)
                {
                    returned = (from t in db.T_BankPeapers
                                where t.PageNo == txtPeaperNo.Text
                                where t.gdTyp == (int?)VarGeneral.InvTyp
                                select t).ToList();
                    if (returned.Count > 0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "رقم الورقة - الإيصال - مستخدم يرجى ادخال رقم ورقة جديد ثم المحاولة مرة اخرى" : "No. paper Repeater", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question);
                        txtPeaperNo.Focus();
                        return;
                    }
                    GetData();
                    try
                    {
                        data_this.PayState = 0;
                        db.T_BankPeapers.InsertOnSubmit(data_this);
                        db.SubmitChanges();
                    }
                    catch (SqlException ex3)
                    {
                        if (ex3.Number != 2627)
                        {
                            return;
                        }
                        Button_Save_Click(sender, e);
                    }
                    catch (Exception)
                    {
                        return;
                    }
                    goto IL_07c8;
                }
                if (State != FormState.Edit)
                {
                    goto IL_07c8;
                }
                returned = (from t in db.T_BankPeapers
                            where t.PageNo == txtPeaperNo.Text && t.ID != int.Parse(textBox_ID.Text)
                            where t.gdTyp == (int?)VarGeneral.InvTyp
                            select t).ToList();
                if (returned.Count > 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "رقم الورقة - الإيصال - مستخدم يرجى ادخال رقم ورقة جديد ثم المحاولة مرة اخرى" : "No. paper Repeater", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    txtPeaperNo.Focus();
                    return;
                }
                GetData();
                try
                {
                    db.Log = VarGeneral.DebugLog;
                    db.SubmitChanges(ConflictMode.ContinueOnConflict);
                    if (data_this.gdID.HasValue && data_this.gdID > 0 && State == FormState.Edit)
                    {
                        _GdHead.gdTot = txtAmount.Value;
                        for (int i = 0; i < _GdHead.T_GDDETs.Count; i++)
                        {
                            if (_GdHead.T_GDDETs[i].gdValue < 0.0)
                            {
                                _GdDet.gdValue = 0.0 - txtAmount.Value;
                            }
                            else
                            {
                                _GdDet.gdValue = txtAmount.Value;
                            }
                            db.Log = VarGeneral.DebugLog;
                            db.SubmitChanges(ConflictMode.ContinueOnConflict);
                        }
                    }
                }
                catch (SqlException)
                {
                    return;
                }
                catch (Exception)
                {
                    return;
                }
                goto IL_07c8;
            IL_07c8:
                State = FormState.Saved;
                RefreshPKeys();
                TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(string.Concat(data_this.ID)) + 1);
                SetReadOnly = true;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Save:", error, enable: true);
                MessageBox.Show(error.Message);
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
                            string dtAction = (n.IsHijri(txtDate.Text) ? txtDate.Text : n.GregToHijri(txtDate.Text, "yyyy/MM/dd"));
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
            if (data_this == null || data_this.ID == 0 || !ifOkDelete)
            {
                return;
            }
            data_this = db.StockBankPeaper(DataThis.ID);
            try
            {
                if (data_this.gdID.HasValue)
                {
                    _GdHead.gdLok = true;
                }
                data_this.IfDel = 1;
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
            catch (SqlException)
            {
                data_this = db.StockBankPeaper(DataThis.ID);
                return;
            }
            catch (Exception)
            {
                data_this = db.StockBankPeaper(DataThis.ID);
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
            if (dataMember != null && dataMember == "T_BankPeaper")
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
            panel.Columns["PageNo"].Width = 200;
            panel.Columns["PageNo"].Visible = columns_Names_visible["PageNo"].IfDefault;
            panel.Columns["PageDate"].Width = 120;
            panel.Columns["PageDate"].Visible = columns_Names_visible["PageDate"].IfDefault;
            panel.Columns["PageDatePay"].Width = 120;
            panel.Columns["PageDatePay"].Visible = columns_Names_visible["PageDatePay"].IfDefault;
            panel.Columns["BankAcc"].Width = 200;
            panel.Columns["BankAcc"].Visible = columns_Names_visible["BankAcc"].IfDefault;
            panel.Columns["BranchAcc"].Width = 200;
            panel.Columns["BranchAcc"].Visible = columns_Names_visible["BranchAcc"].IfDefault;
            panel.Columns["Amount"].Width = 120;
            panel.Columns["Amount"].Visible = columns_Names_visible["Amount"].IfDefault;
            panel.Columns["gdID"].Width = 120;
            panel.Columns["gdID"].Visible = columns_Names_visible["gdID"].IfDefault;
            panel.Columns["ID"].Width = 100;
            panel.Columns["ID"].Visible = columns_Names_visible["ID"].IfDefault;
            panel.ReadOnly = true;
        }
        private void DGV_MainGetCellStyle(object sender, GridGetCellStyleEventArgs e)
        {
        }
        private void Button_ExportTable2_Click(object sender, EventArgs e)
        {
            try
            {
                ExportExcel.ExportToExcel(DGV_Main, "تقرير أوراق الدفع والقبض");
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
                _RepShow.Tables = "T_BankPeaper LEFT OUTER JOIN T_AccDef ON T_BankPeaper.CustAcc = T_AccDef.AccDef_No AND T_BankPeaper.BankAcc = T_AccDef.AccDef_No AND T_BankPeaper.BranchAcc = T_AccDef.AccDef_No LEFT OUTER JOIN T_SYSSETTING ON T_BankPeaper.CompanyID = T_SYSSETTING.SYSSETTING_ID LEFT OUTER JOIN T_INVSETTING ON T_BankPeaper.gdTyp = T_INVSETTING.InvID   ";
                string Fields = "";
                Fields = ((LangArEn != 0) ? " T_BankPeaper.PageNo, T_BankPeaper.PageDatePay, T_BankPeaper.Amount, T_BankPeaper.PageDate, T_BankPeaper.PayState,(select Eng_Des from T_AccDef as x  where x.AccDef_No = T_BankPeaper.CustAcc ) as CusVenNm,(select Eng_Des from T_AccDef as x  where x.AccDef_No = T_BankPeaper.BankAcc ) as AccDefNmBank,(select Eng_Des from T_AccDef as x  where x.AccDef_No = T_BankPeaper.BranchAcc ) as AccDefNmBr, T_SYSSETTING.LogImg,T_INVSETTING.InvNamE as InvNm ,case when vTyp = 1 then 'Check' else 'Draft' end as vTyp,T_INVSETTING.InvID,gdID,ID, PayState" : " T_BankPeaper.PageNo, T_BankPeaper.PageDatePay, T_BankPeaper.Amount, T_BankPeaper.PageDate, T_BankPeaper.PayState,(select Arb_Des from T_AccDef as x  where x.AccDef_No = T_BankPeaper.CustAcc ) as CusVenNm,(select Arb_Des from T_AccDef as x  where x.AccDef_No = T_BankPeaper.BankAcc ) as AccDefNmBank,(select Arb_Des from T_AccDef as x  where x.AccDef_No = T_BankPeaper.BranchAcc ) as AccDefNmBr, T_SYSSETTING.LogImg,T_INVSETTING.InvNamA as InvNm ,case when vTyp = 1 then 'شيك' else 'كمبيالة' end as vTyp,T_INVSETTING.InvID,gdID,ID, PayState");
                _RepShow.Rule = " where gdTyp = " + VarGeneral.InvTyp;
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
                    frm.Repvalue = "RepBankPeaperList";
                    frm.Repvalue = "RepGaidBankPeaper";
                    frm.Tag = LangArEn;
                    frm.Repvalue = "RepBankPeaperList";
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
        private void txtDate_Click(object sender, EventArgs e)
        {
            txtDate.SelectAll();
        }
        private void txtDatePay_Click(object sender, EventArgs e)
        {
            txtDatePay.SelectAll();
        }
        private void txtPeaperNo_Click(object sender, EventArgs e)
        {
            txtPeaperNo.SelectAll();
        }
        private void txtDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtDate.Text))
                {
                    txtDate.Text = Convert.ToDateTime(txtDate.Text).ToString("yyyy/MM/dd");
                    return;
                }
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                if (calendr.Value == 0 && calendr.HasValue)
                {
                    txtDate.Text = VarGeneral.Gdate;
                }
                else
                {
                    txtDate.Text = VarGeneral.Hdate;
                }
            }
            catch
            {
                txtDate.Text = "";
            }
        }
        private void txtDatePay_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtDatePay.Text))
                {
                    txtDatePay.Text = Convert.ToDateTime(txtDatePay.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    txtDatePay.Text = "";
                }
            }
            catch
            {
                txtDatePay.Text = "";
            }
        }
        private void buttonItem_Print_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(txtPeaperNo.Text != "") || State != 0)
                {
                    return;
                }
                if (_InvSetting.InvpRINTERInfo.nTyp.Substring(0, 1) == "1")
                {
                    RepShow _RepShow = new RepShow();
                    _RepShow.Tables = "T_BankPeaper LEFT OUTER JOIN T_AccDef ON T_BankPeaper.CustAcc = T_AccDef.AccDef_No AND T_BankPeaper.BankAcc = T_AccDef.AccDef_No AND T_BankPeaper.BranchAcc = T_AccDef.AccDef_No LEFT OUTER JOIN T_SYSSETTING ON T_BankPeaper.CompanyID = T_SYSSETTING.SYSSETTING_ID LEFT OUTER JOIN T_INVSETTING ON T_BankPeaper.gdTyp = T_INVSETTING.InvID   ";
                    string Fields = "";
                    Fields = ((LangArEn != 0) ? " T_BankPeaper.PageNo, T_BankPeaper.PageDatePay, T_BankPeaper.Amount, T_BankPeaper.PageDate, T_BankPeaper.PayState,(select Eng_Des from T_AccDef as x  where x.AccDef_No = T_BankPeaper.CustAcc ) as CusVenNm,(select Eng_Des from T_AccDef as x  where x.AccDef_No = T_BankPeaper.BankAcc ) as AccDefNmBank,(select Eng_Des from T_AccDef as x  where x.AccDef_No = T_BankPeaper.BranchAcc ) as AccDefNmBr, T_SYSSETTING.LogImg,T_INVSETTING.InvNamE as InvNm ,case when vTyp = 1 then 'Check' else 'Draft' end as vTyp,T_INVSETTING.InvID,gdID,ID, PayState" : " T_BankPeaper.PageNo, T_BankPeaper.PageDatePay, T_BankPeaper.Amount, T_BankPeaper.PageDate, T_BankPeaper.PayState,(select Arb_Des from T_AccDef as x  where x.AccDef_No = T_BankPeaper.CustAcc ) as CusVenNm,(select Arb_Des from T_AccDef as x  where x.AccDef_No = T_BankPeaper.BankAcc ) as AccDefNmBank,(select Arb_Des from T_AccDef as x  where x.AccDef_No = T_BankPeaper.BranchAcc ) as AccDefNmBr, T_SYSSETTING.LogImg,T_INVSETTING.InvNamA as InvNm ,case when vTyp = 1 then 'شيك' else 'كمبيالة' end as vTyp,T_INVSETTING.InvID,gdID,ID, PayState");
                    VarGeneral.HeaderRep[0] = Text;
                    VarGeneral.HeaderRep[1] = "";
                    VarGeneral.HeaderRep[2] = "";
                    _RepShow.Rule = " where gdTyp = " + VarGeneral.InvTyp + " and T_BankPeaper.PageNo = '" + data_this.PageNo + "'";
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
                            VarGeneral.IsGeneralUsed = true;
                            FrmReportsViewer frm = new FrmReportsViewer();
                            frm.Repvalue = "RepBankPeaperList";
                            frm.Repvalue = "RepGaidBankPeaper";
                            frm.Tag = LangArEn;
                            frm.Repvalue = "RepGaidBankPeaper";
                            VarGeneral.vTitle = Text;
                            frm.TopMost = true;
                            frm.ShowDialog();
                            VarGeneral.IsGeneralUsed = false;
                        }
                        catch (Exception error)
                        {
                            VarGeneral.DebLog.writeLog("buttonItem_Print_Click:", error, enable: true);
                            MessageBox.Show(error.Message);
                        }
                    }
                }
                else
                {
                    PrintSet();
                    prnt_doc.Print();
                }
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
        private void prnt_doc_BeginPrint(object sender, PrintEventArgs e)
        {
            if (!(textBox_ID.Text != ""))
            {
                return;
            }
            RepShow _RepShow = new RepShow();
            _RepShow.Tables = "T_BankPeaper LEFT OUTER JOIN T_AccDef ON T_BankPeaper.CustAcc = T_AccDef.AccDef_No AND T_BankPeaper.BankAcc = T_AccDef.AccDef_No AND T_BankPeaper.BranchAcc = T_AccDef.AccDef_No LEFT OUTER JOIN T_SYSSETTING ON T_BankPeaper.CompanyID = T_SYSSETTING.SYSSETTING_ID LEFT OUTER JOIN T_INVSETTING ON T_BankPeaper.gdTyp = T_INVSETTING.InvID   ";
            string Fields = "";
            Fields = ((LangArEn != 0) ? " T_BankPeaper.PageNo, T_BankPeaper.PageDatePay, T_BankPeaper.Amount, T_BankPeaper.PageDate, T_BankPeaper.PayState,(select Eng_Des from T_AccDef as x  where x.AccDef_No = T_BankPeaper.CustAcc ) as CusVenNm,(select Eng_Des from T_AccDef as x  where x.AccDef_No = T_BankPeaper.BankAcc ) as AccDefNmBank,(select Eng_Des from T_AccDef as x  where x.AccDef_No = T_BankPeaper.BranchAcc ) as AccDefNmBr, T_SYSSETTING.LogImg,,T_INVSETTING.InvNamE as InvNm ,case when vTyp = 1 then 'Check' else 'Draft' end as vTyp" : " T_BankPeaper.PageNo, T_BankPeaper.PageDatePay, T_BankPeaper.Amount, T_BankPeaper.PageDate, T_BankPeaper.PayState,(select Arb_Des from T_AccDef as x  where x.AccDef_No = T_BankPeaper.CustAcc ) as CusVenNm,(select Arb_Des from T_AccDef as x  where x.AccDef_No = T_BankPeaper.BankAcc ) as AccDefNmBank,(select Arb_Des from T_AccDef as x  where x.AccDef_No = T_BankPeaper.BranchAcc ) as AccDefNmBr, T_SYSSETTING.LogImg,,T_INVSETTING.InvNamA as InvNm ,case when vTyp = 1 then 'شيك' else 'كمبيالة' end as vTyp");
            VarGeneral.HeaderRep[0] = Text;
            VarGeneral.HeaderRep[1] = "";
            VarGeneral.HeaderRep[2] = "";
            _RepShow.Rule = " where T_BankPeaper.PageNo = '" + data_this.PageNo + "'";
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
        private void prnt_doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
            {
                return;
            }
            List<T_mInvPrint> listmInvPrint = new List<T_mInvPrint>();
            T_mInvPrint _mInvPrint = new T_mInvPrint();
            listmInvPrint = (from item in db.T_mInvPrints
                             where item.repTyp == (int?)VarGeneral.InvTyp
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
    }
}
