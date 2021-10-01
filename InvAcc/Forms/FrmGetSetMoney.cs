using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using Framework.Data;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using SSSDateTime.Date;
using SuperGridDemo;
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
    public partial  class FrmGetSetMoney : Form
    { void avs(int arln)

{ 
}
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
        private void netResize1_AfterControlResize(object sender, Softgroup.NetResize.AfterControlResizeEventArgs e)
        {
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
        public Softgroup.NetResize.NetResize netResize1;
        protected ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.OpenFileDialog  openFileDialog1;
        private System.Windows.Forms. SaveFileDialog saveFileDialog1;
        private Panel panel1;
        private ImageList imageList1;
        private Timer timerInfoBallon;
        private Timer timer1;
        private GroupPanel groupPanel2;
        private SwitchButton switchButton_PageTyp;
        internal Label label1;
        private TextBox txtBrancheNo;
        private ButtonX button_OK;
        private ButtonX button_Return;
        private SuperTabStrip superTabStrip1;
        private SuperTabItem superTabItem;
        protected SuperGridControl DGV_Main;
        internal GroupBox groupBox5;
        private CheckBoxX checkBox_Yes;
        private CheckBoxX checkBox_No;
        private TextBox txtBrancheName;
        private VcrControl vcr1;
        private ButtonItem button_AddPage;
        private ButtonItem buttonItem_Close;
        private TextBox txtBXBankName;
        private ButtonX button_SrchBXBankNo;
        private TextBox txtBXBankNo;
        private SwitchButton switchButton_AccType;
        private ButtonX button_SrchBrancheNo;
        internal Label label2;
        private ComboBoxEx CmbCurr;
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private T_AccDef _AccDefBind = new T_AccDef();
        private int LangArEn = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
#pragma warning disable CS0414 // The field 'FrmGetSetMoney.FlagUpdate' is assigned but its value is never used
        private string FlagUpdate = "";
#pragma warning restore CS0414 // The field 'FrmGetSetMoney.FlagUpdate' is assigned but its value is never used
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private T_GDHEAD _GdHead = new T_GDHEAD();
        private List<T_GDHEAD> listGdHead = new List<T_GDHEAD>();
        private T_GDDET _GdDet = new T_GDDET();
        private List<T_GDDET> listGdDet = new List<T_GDDET>();
        private BindingManagerBase _Bm;
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstance;
        private T_BankPeaper data_this;
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
        private ScriptNumber ScriptNumber1 = new ScriptNumber();
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
        internal BindingManagerBase Bm
        {
            get
            {
                return _Bm;
            }
            set
            {
                if (_Bm != null)
                {
                    _Bm.PositionChanged -= BmPositionChanged;
                }
                _Bm = value;
                if (_Bm != null)
                {
                    _Bm.PositionChanged += BmPositionChanged;
                }
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
            }
        }
        public void Fill_DGV_Main()
        {
            data_this = new T_BankPeaper();
            DGV_Main.PrimaryGrid.DataSource = null;
            DGV_Main.PrimaryGrid.VirtualMode = false;
            List<T_BankPeaper> list = db.FillBankPeaper_2(VarGeneral.InvTyp, "", checkBox_No.Checked ? int.Parse(checkBox_No.Tag.ToString()) : int.Parse(checkBox_Yes.Tag.ToString())).ToList();
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                }
            }
            FillHDGV(list);
            try
            {
                object context = null;
                context = DGV_Main.PrimaryGrid.DataSource;
                Bm = ((DGV_Main.PrimaryGrid.DataSource != null) ? DGV_Main.BindingContext[context] : null);
                UpdateVcr();
            }
            catch (Exception error)
            {
                Bm = null;
                VarGeneral.DebLog.writeLog("Fill_Main:", error, enable: true);
                MessageBox.Show(error.Message);
            }
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
        private void Button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void textBox_NameA_Enter(object sender, EventArgs e)
        {
            Framework.Keyboard.Language.Switch("Arabic");
        }
        private void textBox_NameE_Enter(object sender, EventArgs e)
        {
            Framework.Keyboard.Language.Switch("English");
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
            if (e.KeyCode == Keys.F1 && button_AddPage.Enabled && button_AddPage.Visible)
            {
                button_AddPage_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        public FrmGetSetMoney()
        {
            InitializeComponent();this.Load += langloads;
            DGV_Main.MouseDown += DGV_Main_MouseDown;
            DGV_Main.DataBindingComplete += DGV_Main_DataBindingComplete;
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                button_AddPage.Text = "تسجيل العمليــات البنكية وتعديلها  F1";
                button_AddPage.Tooltip = "F1";
                buttonItem_Close.Tooltip = "ESC - اغلاق النافذة";
                Text = "العمليات البنكية";
                label1.Text = "حساب المدين :";
                label2.Text = "حساب الدائن :";
            }
            else
            {
                button_AddPage.Text = "Write The Bank Opearations F1";
                button_AddPage.Tooltip = "F1";
                buttonItem_Close.Tooltip = "Close Window - ESC";
                Text = "Bank Opearations";
                label1.Text = "Debtor Acc";
                label2.Text = "Creditor Acc";
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
            try
            {
                CmbCurr.SelectedValue = int.Parse(VarGeneral.Settings_Sys.ImportIp.ToString());
            }
            catch
            {
            }
        }
        private void FrmGetSetMoney_Load(object sender, EventArgs e)
        {
            try
            {
                switchButton_PageTyp.Click -= switchButton_PageTyp_ValueChanged;
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmGetSetMoney));
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
                if (columns_Names_visible.Count == 0)
                {
                    columns_Names_visible.Add("PageNo", new ColumnDictinary("رقم الإيصال", "Peaper No", ifDefault: true, ""));
                    columns_Names_visible.Add("PageDate", new ColumnDictinary("تاريخ التحرير", "Date", ifDefault: true, ""));
                    columns_Names_visible.Add("BranchAcc", new ColumnDictinary("حساب البنك", "Bank ACC", ifDefault: true, ""));
                    columns_Names_visible.Add("Amount", new ColumnDictinary("المبلــغ", "Value", ifDefault: true, ""));
                    columns_Names_visible.Add("ID", new ColumnDictinary("الرقم التسلسلي", "Auto No", ifDefault: false, ""));
                }
                RibunButtons();
                if (switchButton_PageTyp.Value)
                {
                    VarGeneral.InvTyp = 26;
                    DGV_Main.PrimaryGrid.GroupByRow.Text = "عملية سحب بنكي";
                    DGV_Main.PrimaryGrid.GroupByRow.Tag = "The Pull Process";
                }
                else
                {
                    VarGeneral.InvTyp = 25;
                    DGV_Main.PrimaryGrid.GroupByRow.Text = "عملية إيداع بنكي";
                    DGV_Main.PrimaryGrid.GroupByRow.Tag = "The Deposit Process";
                }
                FillCombo();
                txtBXBankNo.Text = "";
                txtBXBankName.Text = "";
                txtBrancheNo.Text = "";
                txtBrancheName.Text = "";
                _GdHead = new T_GDHEAD();
                data_this = new T_BankPeaper();
                permission = dbc.Get_PermissionID(VarGeneral.UserID);
                Fill_DGV_Main();
                switchButton_PageTyp.Click += switchButton_PageTyp_ValueChanged;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
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
            DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background.Color1 = Color.LightYellow;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background.Color2 = Color.LightYellow;
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
            panel.Columns["BranchAcc"].Width = 200;
            panel.Columns["BranchAcc"].Visible = columns_Names_visible["BranchAcc"].IfDefault;
            panel.Columns["Amount"].Width = 120;
            panel.Columns["Amount"].Visible = columns_Names_visible["Amount"].IfDefault;
            panel.Columns["ID"].Width = 100;
            panel.Columns["ID"].Visible = columns_Names_visible["ID"].IfDefault;
            panel.ReadOnly = true;
        }
        private void DGV_Main_RowClick(object sender, GridRowClickEventArgs e)
        {
            vRowSel(e.GridRow.RowIndex);
        }
        private void vRowSel(int Row)
        {
            try
            {
                if (DGV_Main.PrimaryGrid.Rows.Count <= 0)
                {
                    return;
                }
                data_this = new T_BankPeaper();
                int no = 0;
                try
                {
                    no = int.Parse(DGV_Main.PrimaryGrid.GetCell(Row, 4).Value.ToString());
                }
                catch
                {
                }
                T_BankPeaper newData = db.StockBankPeaper(no);
                if (newData == null || newData.ID == 0)
                {
                    return;
                }
                DataThis = newData;
                try
                {
                    if (checkBox_Yes.Checked)
                    {
                        for (int i = 0; i < data_this.T_GDHEAD.T_GDDETs.Count; i++)
                        {
                            if (data_this.T_GDHEAD.T_GDDETs[i].gdValue > 0.0)
                            {
                                button_SrchBXBankNo.Enabled = false;
                                button_SrchBrancheNo.Enabled = false;
                                txtBrancheNo.Text = data_this.T_GDHEAD.T_GDDETs[i].AccNo;
                                txtBrancheName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(data_this.T_GDHEAD.T_GDDETs[i].AccNo).Arb_Des : db.StockAccDefWithOutBalance(data_this.T_GDHEAD.T_GDDETs[i].AccNo).Eng_Des);
                            }
                            else
                            {
                                button_SrchBXBankNo.Enabled = false;
                                button_SrchBrancheNo.Enabled = false;
                                txtBXBankNo.Text = data_this.T_GDHEAD.T_GDDETs[i].AccNo;
                                txtBXBankName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(data_this.T_GDHEAD.T_GDDETs[i].AccNo).Arb_Des : db.StockAccDefWithOutBalance(data_this.T_GDHEAD.T_GDDETs[i].AccNo).Eng_Des);
                            }
                        }
                        CmbCurr.SelectedValue = data_this.T_GDHEAD.CurTyp.Value;
                    }
                    else
                    {
                        if (!switchButton_PageTyp.Value)
                        {
                            button_SrchBXBankNo.Enabled = false;
                            button_SrchBrancheNo.Enabled = true;
                            txtBXBankNo.Text = data_this.BranchAcc;
                            txtBXBankName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(data_this.BranchAcc).Arb_Des : db.StockAccDefWithOutBalance(data_this.BranchAcc).Eng_Des);
                        }
                        else
                        {
                            button_SrchBXBankNo.Enabled = true;
                            button_SrchBrancheNo.Enabled = false;
                            txtBrancheNo.Text = data_this.BranchAcc;
                            txtBrancheName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(data_this.BranchAcc).Arb_Des : db.StockAccDefWithOutBalance(data_this.BranchAcc).Eng_Des);
                        }
                        try
                        {
                            CmbCurr.SelectedValue = int.Parse(VarGeneral.Settings_Sys.ImportIp.ToString());
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
            catch
            {
                VcrFirstClick(null, null);
            }
        }
        private void BmPositionChanged(object sender, EventArgs e)
        {
            UpdateVcr();
        }
        private void VcrFirstClick(object sender, EventArgs e)
        {
            if (_Bm != null)
            {
                _Bm.Position = 0;
            }
            UpdateVcr();
        }
        private void VcrPreviousClick(object sender, EventArgs e)
        {
            if (_Bm != null)
            {
                _Bm.Position--;
            }
            UpdateVcr();
        }
        private void VcrNextClick(object sender, EventArgs e)
        {
            if (_Bm != null)
            {
                _Bm.Position++;
            }
            UpdateVcr();
        }
        private void VcrLastClick(object sender, EventArgs e)
        {
            if (_Bm != null)
            {
                _Bm.Position = _Bm.Count;
            }
            UpdateVcr();
        }
        private void UpdateVcr()
        {
            if (_Bm == null || _Bm.Count <= 1)
            {
                vcr1.FirstButton.Enabled = false;
                vcr1.PreviousButton.Enabled = false;
                vcr1.NextButton.Enabled = false;
                vcr1.LastButton.Enabled = false;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    vcr1.Label.Text = ((_Bm == null || _Bm.Count == 0) ? "لايوجد سجلات" : "سجل واحد فقط");
                }
                else
                {
                    vcr1.Label.Text = ((_Bm == null || _Bm.Count == 0) ? "No records" : "Only Record");
                }
                if (_Bm.Count == 1)
                {
                    vRowSel(0);
                }
                return;
            }
            if (_Bm.Position == 0)
            {
                Button firstButton = vcr1.FirstButton;
                bool enabled = (vcr1.PreviousButton.Enabled = false);
                firstButton.Enabled = enabled;
                Button lastButton = vcr1.LastButton;
                enabled = (vcr1.NextButton.Enabled = _Bm.Count > 1);
                lastButton.Enabled = enabled;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    vcr1.Label.Text = "الأول من " + _Bm.Count + " سجلات";
                }
                else
                {
                    vcr1.Label.Text = "First of " + _Bm.Count + " records";
                }
                vRowSel(_Bm.Position);
                return;
            }
            if (_Bm.Position == _Bm.Count - 1)
            {
                vcr1.LastButton.Enabled = false;
                vcr1.NextButton.Enabled = false;
                Button firstButton2 = vcr1.FirstButton;
                bool enabled = (vcr1.PreviousButton.Enabled = _Bm.Count > 1);
                firstButton2.Enabled = enabled;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    vcr1.Label.Text = "الأخير من " + _Bm.Count + " سجلات";
                }
                else
                {
                    vcr1.Label.Text = "Last of " + _Bm.Count + " records";
                }
                vRowSel(_Bm.Position);
                return;
            }
            vcr1.FirstButton.Enabled = true;
            vcr1.PreviousButton.Enabled = true;
            vcr1.NextButton.Enabled = true;
            vcr1.LastButton.Enabled = true;
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                vcr1.Label.Text = "السجل " + (_Bm.Position + 1) + " من " + _Bm.Count;
            }
            else
            {
                vcr1.Label.Text = "Record " + (_Bm.Position + 1) + " of " + _Bm.Count;
            }
            vRowSel(_Bm.Position);
        }
        private void switchButton_PageTyp_ValueChanged(object sender, EventArgs e)
        {
            if (switchButton_PageTyp.Value)
            {
                VarGeneral.InvTyp = 26;
                DGV_Main.PrimaryGrid.GroupByRow.Text = "عملية سحب بنكي";
                DGV_Main.PrimaryGrid.GroupByRow.Tag = "The Pull Process";
            }
            else
            {
                VarGeneral.InvTyp = 25;
                DGV_Main.PrimaryGrid.GroupByRow.Text = "عملية إيداع بنكي";
                DGV_Main.PrimaryGrid.GroupByRow.Tag = "The Deposit Process";
            }
            FrmGetSetMoney_Load(sender, e);
        }
        private void checkBox_No_CheckedChanged(object sender, EventArgs e)
        {
            txtBXBankNo.Text = "";
            txtBXBankName.Text = "";
            txtBrancheNo.Text = "";
            txtBrancheName.Text = "";
            FrmGetSetMoney_Load(sender, e);
            button_Return.Visible = false;
            button_OK.Visible = true;
            switchButton_AccType.Visible = true;
            button_SrchBrancheNo.Enabled = true;
            button_SrchBXBankNo.Enabled = true;
        }
        private void checkBox_Yes_CheckedChanged(object sender, EventArgs e)
        {
            txtBXBankNo.Text = "";
            txtBXBankName.Text = "";
            txtBrancheNo.Text = "";
            txtBrancheName.Text = "";
            FrmGetSetMoney_Load(sender, e);
            button_Return.Visible = true;
            button_OK.Visible = false;
            button_SrchBrancheNo.Enabled = false;
            button_SrchBXBankNo.Enabled = false;
        }
        private T_GDHEAD GetDataGd()
        {
            if (n.IsHijri(data_this.PageDate))
            {
                _GdHead.gdHDate = data_this.PageDate;
            }
            else
            {
                _GdHead.gdHDate = n.GregToHijri(data_this.PageDate);
            }
            if (n.IsGreg(data_this.PageDate))
            {
                _GdHead.gdGDate = data_this.PageDate;
            }
            else
            {
                _GdHead.gdGDate = n.HijriToGreg(data_this.PageDate);
            }
            _GdHead.gdNo = data_this.ID.ToString();
            _GdHead.ArbTaf = ScriptNumber1.ScriptNum(decimal.Parse("0" + data_this.Amount.Value));
            _GdHead.BName = _GdHead.BName;
            _GdHead.ChekNo = _GdHead.ChekNo;
            _GdHead.CurTyp = int.Parse(CmbCurr.SelectedValue.ToString());
            _GdHead.EngTaf = ScriptNumber1.TafEng(decimal.Parse("0" + data_this.Amount.Value));
            _GdHead.gdCstNo = 1;
            _GdHead.gdID = 0;
            _GdHead.gdLok = false;
            _GdHead.gdMem = "";
            _GdHead.AdminLock = false;
            _GdHead.gdMnd = null;
            _GdHead.gdRcptID = (_GdHead.gdRcptID.HasValue ? _GdHead.gdRcptID.Value : 0.0);
            _GdHead.gdTot = data_this.Amount.Value;
            _GdHead.gdTp = (_GdHead.gdTp.HasValue ? _GdHead.gdTp.Value : 0);
            _GdHead.gdTyp = VarGeneral.InvTyp;
            _GdHead.RefNo = "";
            _GdHead.DATE_MODIFIED = DateTime.Now;
            _GdHead.salMonth = "";
            _GdHead.gdUser = VarGeneral.UserNumber;
            _GdHead.gdUserNam = VarGeneral.UserNameA;
            _GdHead.CompanyID = 1;
            return _GdHead;
        }
        private void button_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!VarGeneral.TString.ChkStatShow(permission.SetStr, 21))
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (string.IsNullOrEmpty(txtBXBankNo.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب تحديد حساب الصندوق او البنك لاتمام عملية التحصيل " : "You must specify the expense of the Fund and the Bank to complete the collection process ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                try
                {
                    if (data_this == null || data_this.ID == 0)
                    {
                        MessageBox.Show((LangArEn == 0) ? " يجب تحديد الأيصال المراد تحصيلها من قائمة العمليات البنكية ثم المحالة مرة اخرى " : "You must select the paper to be collected from a list of banknotes and then transferred again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show((LangArEn == 0) ? " يجب تحديد الأيصال المراد تحصيلها من قائمة العمليات البنكية ثم المحالة مرة اخرى " : "You must select the paper to be collected from a list of banknotes and then transferred again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                string AccCrdt = "";
                string AccDbt = "";
                List<T_BankPeaper> q = db.T_BankPeapers.Where((T_BankPeaper t) => t.ID == data_this.ID).ToList();
                if (q.Count <= 0)
                {
                    goto IL_06ce;
                }
                if (!switchButton_PageTyp.Value)
                {
                    AccCrdt = q.First().BranchAcc;
                    AccDbt = txtBrancheNo.Text;
                }
                else
                {
                    AccDbt = q.First().BranchAcc;
                    AccCrdt = txtBXBankNo.Text;
                }
                if (AccCrdt == "")
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف الدائن .. " : "You can not complete the operation .. Make sure the creditor ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (AccDbt == "")
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف المدين .. " : "You can not complete the operation .. Make sure the debtor ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
                using (Stock_DataDataContext DDB = new Stock_DataDataContext(VarGeneral.BranchCS))
                {
                    try
                    {
                        GetDataGd();
                        _GdHead.DATE_CREATED = DateTime.Now;
                        DDB.T_GDHEADs.InsertOnSubmit(_GdHead);
                        DDB.SubmitChanges();
                    }
                    catch (SqlException ex2)
                    {
                        string max = db.MaxGDHEADsNo.ToString();
                        if (ex2.Number == 2627)
                        {
                            MessageBox.Show("الرمز مستخدم من قبل.\n سيتم الحفظ برقم جديد [" + max + "]", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            _GdHead.gdNo = max ?? "";
                            button_OK_Click(sender, e);
                        }
                    }
                    if (data_this.Amount.Value > 0.0 && !string.IsNullOrEmpty(AccCrdt) && !string.IsNullOrEmpty(AccDbt))
                    {
                        db_.StartTransaction();
                        db_.ClearParameters();
                        db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                        db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                        db_.AddParameter("gdNo", DbType.String, data_this.ID.ToString());
                        try
                        {
                            db_.AddParameter("gdDes", DbType.String, DGV_Main.PrimaryGrid.GroupByRow.Text);
                        }
                        catch
                        {
                            db_.AddParameter("gdDes", DbType.String, "-");
                        }
                        try
                        {
                            db_.AddParameter("gdDesE", DbType.String, DGV_Main.PrimaryGrid.GroupByRow.Tag.ToString());
                        }
                        catch
                        {
                            db_.AddParameter("gdDesE", DbType.String, "-");
                        }
                        db_.AddParameter("recptTyp", DbType.String, VarGeneral.InvTyp);
                        db_.AddParameter("AccNo", DbType.String, AccCrdt);
                        db_.AddParameter("AccName", DbType.String, "");
                        db_.AddParameter("gdValue", DbType.Double, 0.0 - data_this.Amount.Value);
                        db_.AddParameter("recptNo", DbType.String, data_this.ID.ToString());
                        db_.AddParameter("Lin", DbType.Int32, 1);
                        db_.AddParameter("AccNoDestruction", DbType.String, null);
                        db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                        db_.EndTransaction();
                        db_.StartTransaction();
                        db_.ClearParameters();
                        db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                        db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                        db_.AddParameter("gdNo", DbType.String, data_this.ID.ToString());
                        try
                        {
                            db_.AddParameter("gdDes", DbType.String, DGV_Main.PrimaryGrid.GroupByRow.Text);
                        }
                        catch
                        {
                            db_.AddParameter("gdDes", DbType.String, "");
                        }
                        try
                        {
                            db_.AddParameter("gdDesE", DbType.String, DGV_Main.PrimaryGrid.GroupByRow.Tag.ToString());
                        }
                        catch
                        {
                            db_.AddParameter("gdDesE", DbType.String, "");
                        }
                        db_.AddParameter("recptTyp", DbType.String, VarGeneral.InvTyp);
                        db_.AddParameter("AccNo", DbType.String, AccDbt);
                        db_.AddParameter("AccName", DbType.String, "");
                        db_.AddParameter("gdValue", DbType.Double, data_this.Amount.Value);
                        db_.AddParameter("recptNo", DbType.String, data_this.ID.ToString());
                        db_.AddParameter("Lin", DbType.Int32, 2);
                        db_.AddParameter("AccNoDestruction", DbType.String, null);
                        db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                        db_.EndTransaction();
                    }
                }
                goto IL_06ce;
            IL_06ce:
                dbInstance = null;
                vRowSel(_Bm.Position);
                data_this.PayState = 1;
                data_this.gdID = _GdHead.gdhead_ID;
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                MessageBox.Show((LangArEn == 0) ? "تمت العملية بنجاح .." : "Process Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                dbInstance = null;
                FrmGetSetMoney_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                VarGeneral.DebLog.writeLog("button_OK_Click:", ex, enable: true);
            }
        }
        private void button_Return_Click(object sender, EventArgs e)
        {
            try
            {
                if (!VarGeneral.TString.ChkStatShow(permission.SetStr, 22))
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                try
                {
                    if (data_this == null || data_this.ID == 0)
                    {
                        MessageBox.Show((LangArEn == 0) ? " يجب تحديد الأيصال المراد تحصيلها من قائمة الأوراق البنكية ثم المحالة مرة اخرى " : "You must select the paper to be collected from a list of banknotes and then transferred again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show((LangArEn == 0) ? " يجب تحديد الأيصال المراد تحصيلها من قائمة الأوراق البنكية ثم المحالة مرة اخرى " : "You must select the paper to be collected from a list of banknotes and then transferred again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
                try
                {
                    db_.StartTransaction();
                    db_.ClearParameters();
                    db_.AddParameter("gdhead_ID", DbType.Int32, data_this.T_GDHEAD.gdhead_ID);
                    db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDHEAD_DELETE");
                    db_.EndTransaction();
                }
                catch (SqlException)
                {
                    return;
                }
                data_this.PayState = 0;
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                MessageBox.Show((LangArEn == 0) ? "تمت العملية بنجاح .." : "Process Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                FrmGetSetMoney_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                VarGeneral.DebLog.writeLog("button_Return_Click:", ex, enable: true);
            }
        }
        private void switchButton_AccType_ValueChanged(object sender, EventArgs e)
        {
            txtBXBankNo.Text = "";
            txtBXBankName.Text = "";
            txtBrancheNo.Text = "";
            txtBrancheName.Text = "";
        }
        private void button_SrchBrancheNo_Click(object sender, EventArgs e)
        {
            if (!checkBox_No.Checked)
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
            VarGeneral.SFrmTyp = "T_AccDef2";
            VarGeneral.AccTyp = 3;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                txtBrancheNo.Text = _AccDef.AccDef_No.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtBrancheName.Text = _AccDef.Arb_Des.ToString();
                }
                else
                {
                    txtBrancheName.Text = _AccDef.Eng_Des.ToString();
                }
            }
            else
            {
                txtBrancheNo.Text = "";
                txtBrancheName.Text = "";
            }
        }
        private void buttonItem_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button_AddPage_Click(object sender, EventArgs e)
        {
            FrmNewGetSetMoney frm = new FrmNewGetSetMoney("", switchButton_PageTyp.Value);
            if (!switchButton_PageTyp.Value)
            {
                VarGeneral.InvTyp = 25;
            }
            else
            {
                VarGeneral.InvTyp = 26;
            }
            frm.Tag = LangArEn;
            frm.TopMost = true;
            frm.ShowDialog();
            FrmGetSetMoney_Load(sender, e);
        }
        private void button_SrchBXBankNo_Click(object sender, EventArgs e)
        {
            if (!checkBox_No.Checked)
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
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
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
    }
}
