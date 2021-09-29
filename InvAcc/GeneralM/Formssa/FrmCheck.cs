using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using Framework.Data;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
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
    public partial class FrmCheck : Form
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
        private IContainer components = null;
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
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private Panel panel1;
        private ImageList imageList1;
        private Timer timerInfoBallon;
        private Timer timer1;
        private GroupPanel groupPanel2;
        private SwitchButton switchButton_PageTyp;
        private SwitchButton switchButton_AccType;
        internal Label label1;
        private ButtonX button_SrchBrancheNo;
        private TextBox txtBrancheNo;
        private ButtonX button_SrchBXBankNo;
        private ButtonX button_OK;
        private ButtonX button_Return;
        private TextBox txtBXBankNo;
        private SuperTabStrip superTabStrip1;
        private SuperTabItem superTabItem;
        protected SuperGridControl DGV_Main;
        internal GroupBox groupBox5;
        private CheckBoxX checkBox_Cancel;
        private CheckBoxX checkBox_Yes;
        private CheckBoxX checkBox_No;
        private ButtonX button_BackPay;
        private ButtonX button_BackCancel;
        private TextBox txtBrancheName;
        private TextBox txtBXBankName;
        private VcrControl vcr1;
        internal Label label2;
        private ButtonItem button_AddPage;
        private ButtonItem buttonItem_Close;
        private ComboBoxEx CmbCurr;
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
            List<T_BankPeaper> list = db.FillBankPeaper_2(VarGeneral.InvTyp, "", checkBox_No.Checked ? int.Parse(checkBox_No.Tag.ToString()) : (checkBox_Yes.Checked ? int.Parse(checkBox_Yes.Tag.ToString()) : int.Parse(checkBox_Cancel.Tag.ToString()))).ToList();
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
        public FrmCheck()
        {
            InitializeComponent();
            DGV_Main.MouseDown += DGV_Main_MouseDown;
            DGV_Main.DataBindingComplete += DGV_Main_DataBindingComplete;
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                button_AddPage.Text = "تسجيل الأوراق البنكية وتعديلها F1";
                button_AddPage.Tooltip = "F1";
                buttonItem_Close.Tooltip = "ESC - اغلاق النافذة";
                Text = "الأوراق البنكية";
            }
            else
            {
                button_AddPage.Text = "Write The Bank Peaper F1";
                button_AddPage.Tooltip = "F1";
                buttonItem_Close.Tooltip = "Close Window - ESC";
                Text = "Bank Peapers";
            }
        }
        private void FrmCheck_Load(object sender, EventArgs e)
        {
            try
            {
                switchButton_PageTyp.Click -= switchButton_PageTyp_ValueChanged;
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmCheck));
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
                    columns_Names_visible.Add("PageNo", new ColumnDictinary("رقم الورقة", "Peaper No", ifDefault: true, ""));
                    columns_Names_visible.Add("PageDate", new ColumnDictinary("تاريخ التحرير", "Date", ifDefault: true, ""));
                    columns_Names_visible.Add("PageDatePay", new ColumnDictinary("تاريخ الإستحقاق", "Pay Date", ifDefault: true, ""));
                    columns_Names_visible.Add("BranchAcc", new ColumnDictinary("حساب البنك", "Bank ACC", ifDefault: true, ""));
                    columns_Names_visible.Add("Amount", new ColumnDictinary("المبلــغ", "Value", ifDefault: false, ""));
                    columns_Names_visible.Add("ID", new ColumnDictinary("الرقم التسلسلي", "Auto No", ifDefault: false, ""));
                }
                if (switchButton_PageTyp.Value)
                {
                    VarGeneral.InvTyp = 24;
                    DGV_Main.PrimaryGrid.GroupByRow.Text = "ورقة دفع بنكي";
                    DGV_Main.PrimaryGrid.GroupByRow.Tag = "Paper paying ";
                }
                else
                {
                    VarGeneral.InvTyp = 23;
                    DGV_Main.PrimaryGrid.GroupByRow.Text = "ورقة قبض بنكي";
                    DGV_Main.PrimaryGrid.GroupByRow.Tag = "Paper catch";
                }
                RibunButtons();
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
            panel.Columns["PageDatePay"].Width = 120;
            panel.Columns["PageDatePay"].Visible = columns_Names_visible["PageDatePay"].IfDefault;
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
                    no = int.Parse(DGV_Main.PrimaryGrid.GetCell(Row, 5).Value.ToString());
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
                                txtBXBankNo.Text = data_this.T_GDHEAD.T_GDDETs[i].AccNo;
                                txtBXBankName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(data_this.T_GDHEAD.T_GDDETs[i].AccNo).Arb_Des : db.StockAccDefWithOutBalance(data_this.T_GDHEAD.T_GDDETs[i].AccNo).Eng_Des);
                            }
                            else
                            {
                                txtBrancheNo.Text = data_this.T_GDHEAD.T_GDDETs[i].AccNo;
                                txtBrancheName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(data_this.T_GDHEAD.T_GDDETs[i].AccNo).Arb_Des : db.StockAccDefWithOutBalance(data_this.T_GDHEAD.T_GDDETs[i].AccNo).Eng_Des);
                            }
                        }
                        CmbCurr.SelectedValue = data_this.T_GDHEAD.CurTyp.Value;
                    }
                    else
                    {
                        switchButton_AccType.Value = true;
                        txtBXBankNo.Text = newData.BranchAcc;
                        txtBXBankName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(newData.BranchAcc).Arb_Des : db.StockAccDefWithOutBalance(newData.BranchAcc).Eng_Des);
                        txtBrancheNo.Text = newData.CustAcc;
                        txtBrancheName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(newData.CustAcc).Arb_Des : db.StockAccDefWithOutBalance(newData.CustAcc).Eng_Des);
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
                VarGeneral.InvTyp = 24;
                DGV_Main.PrimaryGrid.GroupByRow.Text = "ورقة دفع بنكي";
                DGV_Main.PrimaryGrid.GroupByRow.Tag = "Paper paying ";
            }
            else
            {
                VarGeneral.InvTyp = 23;
                DGV_Main.PrimaryGrid.GroupByRow.Text = "ورقة قبض بنكي";
                DGV_Main.PrimaryGrid.GroupByRow.Tag = "Paper catch";
            }
            FrmCheck_Load(sender, e);
        }
        private void checkBox_No_CheckedChanged(object sender, EventArgs e)
        {
            txtBXBankNo.Text = "";
            txtBXBankName.Text = "";
            txtBrancheNo.Text = "";
            txtBrancheName.Text = "";
            FrmCheck_Load(sender, e);
            button_BackPay.Visible = false;
            button_BackCancel.Visible = false;
            button_OK.Visible = true;
            button_Return.Visible = true;
            switchButton_AccType.Visible = true;
            label2.Text = ((LangArEn == 0) ? "حســـاب المديـــن :" : " Debtor Account");
            label1.Text = ((LangArEn == 0) ? "حســـاب الدائـــن :" : "Creditor Account");
            label1.Visible = false;
            txtBrancheNo.Visible = false;
            button_SrchBrancheNo.Visible = false;
            txtBrancheName.Visible = false;
        }
        private void checkBox_Yes_CheckedChanged(object sender, EventArgs e)
        {
            txtBXBankNo.Text = "";
            txtBXBankName.Text = "";
            txtBrancheNo.Text = "";
            txtBrancheName.Text = "";
            FrmCheck_Load(sender, e);
            button_BackPay.Visible = true;
            button_BackCancel.Visible = false;
            button_OK.Visible = false;
            button_Return.Visible = false;
            switchButton_AccType.Visible = false;
            label2.Text = ((LangArEn == 0) ? "حســـاب المديـــن :" : " Debtor Account");
            label1.Text = ((LangArEn == 0) ? "حســـاب الدائـــن :" : "Creditor Account");
            label1.Visible = true;
            txtBrancheNo.Visible = true;
            button_SrchBrancheNo.Visible = true;
            txtBrancheName.Visible = true;
        }
        private void checkBox_Cancel_CheckedChanged(object sender, EventArgs e)
        {
            txtBXBankNo.Text = "";
            txtBXBankName.Text = "";
            txtBrancheNo.Text = "";
            txtBrancheName.Text = "";
            FrmCheck_Load(sender, e);
            button_BackPay.Visible = false;
            button_BackCancel.Visible = true;
            button_OK.Visible = false;
            button_Return.Visible = false;
            switchButton_AccType.Visible = true;
            label2.Text = ((LangArEn == 0) ? "حســـاب المديـــن :" : " Debtor Account");
            label1.Text = ((LangArEn == 0) ? "حســـاب الدائـــن :" : "Creditor Account");
            label1.Visible = false;
            txtBrancheNo.Visible = false;
            button_SrchBrancheNo.Visible = false;
            txtBrancheName.Visible = false;
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
                if (!VarGeneral.TString.ChkStatShow(permission.SetStr, 17))
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (string.IsNullOrEmpty(txtBXBankNo.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب تحديد حساب الصندوق او البنك لاتمام عملية التحصيل " : "You must specify the expense of the Fund and the Bank to complete the collection process ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                if (switchButton_AccType.Value && string.IsNullOrEmpty(txtBXBankNo.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب تحديد حساب البنك لاتمام عملية التحصيل " : "You must specify the Bank to complete the collection process ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                try
                {
                    if (data_this == null || data_this.ID == 0)
                    {
                        MessageBox.Show((LangArEn == 0) ? " يجب تحديد الورقة المراد تحصيلها من قائمة الأوراق البنكية ثم المحالة مرة اخرى " : "You must select the paper to be collected from a list of banknotes and then transferred again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show((LangArEn == 0) ? " يجب تحديد الورقة المراد تحصيلها من قائمة الأوراق البنكية ثم المحالة مرة اخرى " : "You must select the paper to be collected from a list of banknotes and then transferred again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                string AccCrdt = "";
                string AccDbt = "";
                List<T_BankPeaper> q = db.T_BankPeapers.Where((T_BankPeaper t) => t.ID == data_this.ID).ToList();
                if (q.Count <= 0)
                {
                    goto IL_06ef;
                }
                if (!switchButton_PageTyp.Value)
                {
                    AccCrdt = q.First().CustAcc;
                    AccDbt = (switchButton_AccType.Value ? txtBXBankNo.Text : txtBXBankNo.Text);
                }
                else
                {
                    AccCrdt = (switchButton_AccType.Value ? txtBXBankNo.Text : txtBXBankNo.Text);
                    AccDbt = q.First().CustAcc;
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
                        db_.AddParameter("gdDes", DbType.String, DGV_Main.PrimaryGrid.GroupByRow.Text);
                        db_.AddParameter("gdDesE", DbType.String, DGV_Main.PrimaryGrid.GroupByRow.Tag.ToString());
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
                        db_.AddParameter("gdDes", DbType.String, DGV_Main.PrimaryGrid.GroupByRow.Text);
                        db_.AddParameter("gdDesE", DbType.String, DGV_Main.PrimaryGrid.GroupByRow.Tag.ToString());
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
                goto IL_06ef;
            IL_06ef:
                dbInstance = null;
                vRowSel(_Bm.Position);
                data_this.PayState = 1;
                data_this.gdID = _GdHead.gdhead_ID;
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                MessageBox.Show((LangArEn == 0) ? "تمت العملية بنجاح .." : "Process Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                dbInstance = null;
                FrmCheck_Load(sender, e);
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
                if (!VarGeneral.TString.ChkStatShow(permission.SetStr, 18))
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                try
                {
                    if (data_this == null || data_this.ID == 0)
                    {
                        MessageBox.Show((LangArEn == 0) ? " يجب تحديد الورقة المراد تحصيلها من قائمة الأوراق البنكية ثم المحالة مرة اخرى " : "You must select the paper to be collected from a list of banknotes and then transferred again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show((LangArEn == 0) ? " يجب تحديد الورقة المراد تحصيلها من قائمة الأوراق البنكية ثم المحالة مرة اخرى " : "You must select the paper to be collected from a list of banknotes and then transferred again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                data_this.PayState = 2;
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                MessageBox.Show((LangArEn == 0) ? "تمت العملية بنجاح .." : "Process Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                FrmCheck_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                VarGeneral.DebLog.writeLog("button_Return_Click:", ex, enable: true);
            }
        }
        private void button_BackCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!VarGeneral.TString.ChkStatShow(permission.SetStr, 20))
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                try
                {
                    if (data_this == null || data_this.ID == 0)
                    {
                        MessageBox.Show((LangArEn == 0) ? " يجب تحديد الورقة المراد تحصيلها من قائمة الأوراق البنكية ثم المحالة مرة اخرى " : "You must select the paper to be collected from a list of banknotes and then transferred again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show((LangArEn == 0) ? " يجب تحديد الورقة المراد تحصيلها من قائمة الأوراق البنكية ثم المحالة مرة اخرى " : "You must select the paper to be collected from a list of banknotes and then transferred again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                data_this.PayState = 0;
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                MessageBox.Show((LangArEn == 0) ? "تمت العملية بنجاح .." : "Process Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                FrmCheck_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                VarGeneral.DebLog.writeLog("button_BackCancel_Click:", ex, enable: true);
            }
        }
        private void button_BackPay_Click(object sender, EventArgs e)
        {
            try
            {
                if (!VarGeneral.TString.ChkStatShow(permission.SetStr, 19))
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                try
                {
                    if (data_this == null || data_this.ID == 0)
                    {
                        MessageBox.Show((LangArEn == 0) ? " يجب تحديد الورقة المراد تحصيلها من قائمة الأوراق البنكية ثم المحالة مرة اخرى " : "You must select the paper to be collected from a list of banknotes and then transferred again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show((LangArEn == 0) ? " يجب تحديد الورقة المراد تحصيلها من قائمة الأوراق البنكية ثم المحالة مرة اخرى " : "You must select the paper to be collected from a list of banknotes and then transferred again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                FrmCheck_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                VarGeneral.DebLog.writeLog("button_BackPay_Click:", ex, enable: true);
            }
        }
        private void switchButton_AccType_ValueChanged(object sender, EventArgs e)
        {
            txtBXBankNo.Text = "";
            txtBXBankName.Text = "";
            txtBrancheNo.Text = "";
            txtBrancheName.Text = "";
        }
        private void button_SrchBXBankNo_Click(object sender, EventArgs e)
        {
            if (!checkBox_No.Checked)
            {
                return;
            }
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
        }
        private void button_SrchBrancheNo_Click(object sender, EventArgs e)
        {
            if (!checkBox_No.Checked || !switchButton_AccType.Value || string.IsNullOrEmpty(txtBXBankNo.Text))
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
            VarGeneral.SFrmTyp = "Acc_BankBr";
            VarGeneral.AccTyp = int.Parse(txtBXBankNo.Text);
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
        }
        private void buttonItem_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button_AddPage_Click(object sender, EventArgs e)
        {
            FrmNewPeaper frm = new FrmNewPeaper("", switchButton_PageTyp.Value);
            if (!switchButton_PageTyp.Value)
            {
                VarGeneral.InvTyp = 23;
            }
            else
            {
                VarGeneral.InvTyp = 24;
            }
            frm.Tag = LangArEn;
            frm.TopMost = true;
            frm.ShowDialog();
            FrmCheck_Load(sender, e);
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmCheck));
            DevComponents.DotNetBar.SuperGrid.Style.Background background5 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background6 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background7 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor3 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor4 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle3 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle4 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.Background background8 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            panel1 = new System.Windows.Forms.Panel();
            DGV_Main = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            CmbCurr = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            switchButton_AccType = new DevComponents.DotNetBar.Controls.SwitchButton();
            txtBrancheName = new System.Windows.Forms.TextBox();
            txtBXBankName = new System.Windows.Forms.TextBox();
            switchButton_PageTyp = new DevComponents.DotNetBar.Controls.SwitchButton();
            label1 = new System.Windows.Forms.Label();
            button_SrchBrancheNo = new DevComponents.DotNetBar.ButtonX();
            txtBrancheNo = new System.Windows.Forms.TextBox();
            button_SrchBXBankNo = new DevComponents.DotNetBar.ButtonX();
            groupBox5 = new System.Windows.Forms.GroupBox();
            checkBox_Yes = new DevComponents.DotNetBar.Controls.CheckBoxX();
            checkBox_No = new DevComponents.DotNetBar.Controls.CheckBoxX();
            checkBox_Cancel = new DevComponents.DotNetBar.Controls.CheckBoxX();
            txtBXBankNo = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            button_OK = new DevComponents.DotNetBar.ButtonX();
            button_Return = new DevComponents.DotNetBar.ButtonX();
            button_BackCancel = new DevComponents.DotNetBar.ButtonX();
            button_BackPay = new DevComponents.DotNetBar.ButtonX();
            vcr1 = new SuperGridDemo.VcrControl();
            imageList1 = new System.Windows.Forms.ImageList(components);
            timerInfoBallon = new System.Windows.Forms.Timer(components);
            timer1 = new System.Windows.Forms.Timer(components);
            superTabStrip1 = new DevComponents.DotNetBar.SuperTabStrip();
            superTabItem = new DevComponents.DotNetBar.SuperTabItem();
            buttonItem_Close = new DevComponents.DotNetBar.ButtonItem();
            button_AddPage = new DevComponents.DotNetBar.ButtonItem();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();

            panel1.SuspendLayout();
            groupPanel2.SuspendLayout();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)superTabStrip1).BeginInit();
            SuspendLayout();
            contextMenuStrip1.AccessibleDescription = null;
            contextMenuStrip1.AccessibleName = null;
            resources.ApplyResources(contextMenuStrip1, "contextMenuStrip1");
            contextMenuStrip1.BackgroundImage = null;
            contextMenuStrip1.Font = null;
            contextMenuStrip1.Name = "contextMenuStrip1";
            openFileDialog1.DefaultExt = "*.rtf";
            resources.ApplyResources(openFileDialog1, "openFileDialog1");
            openFileDialog1.FilterIndex = 2;
            saveFileDialog1.DefaultExt = "*.rtf";
            saveFileDialog1.FileName = "doc1";
            resources.ApplyResources(saveFileDialog1, "saveFileDialog1");
            saveFileDialog1.FilterIndex = 2;
            panel1.AccessibleDescription = null;
            panel1.AccessibleName = null;
            resources.ApplyResources(panel1, "panel1");
            panel1.BackgroundImage = null;
            panel1.Controls.Add(DGV_Main);
            panel1.Controls.Add(groupPanel2);
            panel1.Controls.Add(vcr1);
            panel1.Font = null;
            panel1.Name = "panel1";
            DGV_Main.AccessibleDescription = null;
            DGV_Main.AccessibleName = null;
            resources.ApplyResources(DGV_Main, "DGV_Main");
            DGV_Main.BackColor = System.Drawing.Color.Transparent;
            DGV_Main.BackgroundImage = null;
            background5.BackFillType = DevComponents.DotNetBar.SuperGrid.Style.BackFillType.ForwardDiagonalCenter;
            background5.Color1 = System.Drawing.SystemColors.GradientActiveCaption;
            background5.Color2 = System.Drawing.Color.White;
            DGV_Main.DefaultVisualStyles.GroupByStyles.Default.Background = background5;
            background6.BackFillType = DevComponents.DotNetBar.SuperGrid.Style.BackFillType.Center;
            background6.Color1 = System.Drawing.Color.LightSteelBlue;
            DGV_Main.DefaultVisualStyles.RowStyles.Default.Background = background6;
            background7.Color1 = System.Drawing.Color.FromArgb(255, 255, 192);
            DGV_Main.DefaultVisualStyles.RowStyles.MouseOver.Background = background7;
            DGV_Main.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            DGV_Main.ForeColor = System.Drawing.Color.Black;
            DGV_Main.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            DGV_Main.Name = "DGV_Main";
            DGV_Main.PrimaryGrid.ActiveRowIndicatorStyle = DevComponents.DotNetBar.SuperGrid.ActiveRowIndicatorStyle.Both;
            DGV_Main.PrimaryGrid.AllowEdit = false;
            DGV_Main.PrimaryGrid.Caption.BackgroundImageLayout = DevComponents.DotNetBar.SuperGrid.GridBackgroundImageLayout.Center;
            DGV_Main.PrimaryGrid.Caption.Text = "";
            DGV_Main.PrimaryGrid.Caption.Visible = false;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.TextColor = System.Drawing.Color.Black;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.TextColor = System.Drawing.Color.Black;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.CaptionStyles.Default.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            DGV_Main.PrimaryGrid.DefaultVisualStyles.CaptionStyles.Default.TextColor = System.Drawing.Color.White;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.CaptionStyles.ReadOnly.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.CellStyles.Selected.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderRowStyles.Default.RowHeader.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            borderColor3.Bottom = System.Drawing.Color.Black;
            borderColor3.Left = System.Drawing.Color.Black;
            borderColor3.Right = System.Drawing.Color.Black;
            borderColor3.Top = System.Drawing.Color.Black;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.BorderColor = borderColor3;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.TextColor = System.Drawing.Color.SteelBlue;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.TextColor = System.Drawing.Color.White;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.FooterStyles.Default.TextColor = System.Drawing.Color.White;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            borderColor4.Bottom = System.Drawing.Color.Black;
            borderColor4.Left = System.Drawing.Color.Black;
            borderColor4.Right = System.Drawing.Color.Black;
            borderColor4.Top = System.Drawing.Color.Black;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.BorderColor = borderColor4;
            baseTreeButtonVisualStyle3.BorderColor = System.Drawing.Color.White;
            baseTreeButtonVisualStyle3.LineColor = System.Drawing.Color.White;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.CircleTreeButtonStyle.ExpandButton = baseTreeButtonVisualStyle3;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.HeaderHLinePattern = DevComponents.DotNetBar.SuperGrid.Style.LinePattern.None;
            background8.Color1 = System.Drawing.Color.FromArgb(255, 255, 192);
            baseTreeButtonVisualStyle4.Background = background8;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.SquareTreeButtonStyle.ExpandButton = baseTreeButtonVisualStyle4;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.TextColor = System.Drawing.Color.White;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.TitleStyles.Default.RowHeaderStyle.TextAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            DGV_Main.PrimaryGrid.GroupByRow.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.Never;
            DGV_Main.PrimaryGrid.GroupByRow.Text = "أوراق القبــــــض";
            DGV_Main.PrimaryGrid.GroupByRow.WatermarkText = "";
            DGV_Main.PrimaryGrid.InitialActiveRow = DevComponents.DotNetBar.SuperGrid.RelativeRow.None;
            DGV_Main.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.None;
            DGV_Main.PrimaryGrid.MultiSelect = false;
            DGV_Main.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            DGV_Main.PrimaryGrid.ShowRowHeaders = false;
            DGV_Main.PrimaryGrid.Title.AllowSelection = false;
            DGV_Main.PrimaryGrid.Title.Text = "";
            DGV_Main.PrimaryGrid.Title.Visible = false;
            DGV_Main.PrimaryGrid.Visible = false;
            DGV_Main.RowClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowClickEventArgs>(DGV_Main_RowClick);
            groupPanel2.AccessibleDescription = null;
            groupPanel2.AccessibleName = null;
            resources.ApplyResources(groupPanel2, "groupPanel2");
            groupPanel2.BackColor = System.Drawing.Color.Transparent;
            groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            groupPanel2.Controls.Add(CmbCurr);
            groupPanel2.Controls.Add(switchButton_AccType);
            groupPanel2.Controls.Add(txtBrancheName);
            groupPanel2.Controls.Add(txtBXBankName);
            groupPanel2.Controls.Add(switchButton_PageTyp);
            groupPanel2.Controls.Add(label1);
            groupPanel2.Controls.Add(button_SrchBrancheNo);
            groupPanel2.Controls.Add(txtBrancheNo);
            groupPanel2.Controls.Add(button_SrchBXBankNo);
            groupPanel2.Controls.Add(groupBox5);
            groupPanel2.Controls.Add(txtBXBankNo);
            groupPanel2.Controls.Add(label2);
            groupPanel2.Controls.Add(button_OK);
            groupPanel2.Controls.Add(button_Return);
            groupPanel2.Controls.Add(button_BackCancel);
            groupPanel2.Controls.Add(button_BackPay);
            groupPanel2.Font = null;
            groupPanel2.Name = "groupPanel2";
            groupPanel2.Style.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            groupPanel2.Style.BackColorGradientAngle = 90;
            groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel2.Style.BorderBottomWidth = 1;
            groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel2.Style.BorderLeftWidth = 1;
            groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel2.Style.BorderRightWidth = 1;
            groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel2.Style.BorderTopWidth = 1;
            groupPanel2.Style.CornerDiameter = 4;
            groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            groupPanel2.TitleImagePosition = DevComponents.DotNetBar.eTitleImagePosition.Center;
            CmbCurr.AccessibleDescription = null;
            CmbCurr.AccessibleName = null;
            resources.ApplyResources(CmbCurr, "CmbCurr");
            CmbCurr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            CmbCurr.BackgroundImage = null;
            CmbCurr.CommandParameter = null;
            CmbCurr.DisplayMember = "Text";
            CmbCurr.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            CmbCurr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CmbCurr.FormattingEnabled = true;
            CmbCurr.Name = "CmbCurr";
            CmbCurr.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            switchButton_AccType.AccessibleDescription = null;
            switchButton_AccType.AccessibleName = null;
            resources.ApplyResources(switchButton_AccType, "switchButton_AccType");
            switchButton_AccType.BackgroundImage = null;
            switchButton_AccType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            switchButton_AccType.CommandParameter = null;
            switchButton_AccType.Font = null;
            switchButton_AccType.Name = "switchButton_AccType";
            switchButton_AccType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            switchButton_AccType.ValueChanged += new System.EventHandler(switchButton_AccType_ValueChanged);
            txtBrancheName.AccessibleDescription = null;
            txtBrancheName.AccessibleName = null;
            resources.ApplyResources(txtBrancheName, "txtBrancheName");
            txtBrancheName.BackColor = System.Drawing.Color.White;
            txtBrancheName.BackgroundImage = null;
            txtBrancheName.Font = null;
            txtBrancheName.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            txtBrancheName.Name = "txtBrancheName";
            txtBrancheName.ReadOnly = true;
            txtBXBankName.AccessibleDescription = null;
            txtBXBankName.AccessibleName = null;
            resources.ApplyResources(txtBXBankName, "txtBXBankName");
            txtBXBankName.BackColor = System.Drawing.Color.White;
            txtBXBankName.BackgroundImage = null;
            txtBXBankName.Font = null;
            txtBXBankName.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            txtBXBankName.Name = "txtBXBankName";
            txtBXBankName.ReadOnly = true;
            switchButton_PageTyp.AccessibleDescription = null;
            switchButton_PageTyp.AccessibleName = null;
            resources.ApplyResources(switchButton_PageTyp, "switchButton_PageTyp");
            switchButton_PageTyp.BackgroundImage = null;
            switchButton_PageTyp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            switchButton_PageTyp.CommandParameter = null;
            switchButton_PageTyp.Font = null;
            switchButton_PageTyp.Name = "switchButton_PageTyp";
            switchButton_PageTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            switchButton_PageTyp.ValueChanged += new System.EventHandler(switchButton_PageTyp_ValueChanged);
            label1.AccessibleDescription = null;
            label1.AccessibleName = null;
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label1.Name = "label1";
            button_SrchBrancheNo.AccessibleDescription = null;
            button_SrchBrancheNo.AccessibleName = null;
            button_SrchBrancheNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_SrchBrancheNo, "button_SrchBrancheNo");
            button_SrchBrancheNo.BackgroundImage = null;
            button_SrchBrancheNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            button_SrchBrancheNo.CommandParameter = null;
            button_SrchBrancheNo.Font = null;
            button_SrchBrancheNo.Name = "button_SrchBrancheNo";
            button_SrchBrancheNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_SrchBrancheNo.Symbol = "\uf002";
            button_SrchBrancheNo.SymbolSize = 12f;
            button_SrchBrancheNo.TextColor = System.Drawing.Color.SteelBlue;
            button_SrchBrancheNo.Click += new System.EventHandler(button_SrchBrancheNo_Click);
            txtBrancheNo.AccessibleDescription = null;
            txtBrancheNo.AccessibleName = null;
            resources.ApplyResources(txtBrancheNo, "txtBrancheNo");
            txtBrancheNo.BackColor = System.Drawing.Color.White;
            txtBrancheNo.BackgroundImage = null;
            txtBrancheNo.Font = null;
            txtBrancheNo.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            txtBrancheNo.Name = "txtBrancheNo";
            txtBrancheNo.ReadOnly = true;
            button_SrchBXBankNo.AccessibleDescription = null;
            button_SrchBXBankNo.AccessibleName = null;
            button_SrchBXBankNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_SrchBXBankNo, "button_SrchBXBankNo");
            button_SrchBXBankNo.BackgroundImage = null;
            button_SrchBXBankNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            button_SrchBXBankNo.CommandParameter = null;
            button_SrchBXBankNo.Font = null;
            button_SrchBXBankNo.Name = "button_SrchBXBankNo";
            button_SrchBXBankNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_SrchBXBankNo.Symbol = "\uf002";
            button_SrchBXBankNo.SymbolSize = 12f;
            button_SrchBXBankNo.TextColor = System.Drawing.Color.SteelBlue;
            button_SrchBXBankNo.Click += new System.EventHandler(button_SrchBXBankNo_Click);
            groupBox5.AccessibleDescription = null;
            groupBox5.AccessibleName = null;
            resources.ApplyResources(groupBox5, "groupBox5");
            groupBox5.BackColor = System.Drawing.Color.Transparent;
            groupBox5.BackgroundImage = null;
            groupBox5.Controls.Add(checkBox_Yes);
            groupBox5.Controls.Add(checkBox_No);
            groupBox5.Controls.Add(checkBox_Cancel);
            groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            groupBox5.ForeColor = System.Drawing.Color.FromArgb(128, 64, 64);
            groupBox5.Name = "groupBox5";
            groupBox5.TabStop = false;
            checkBox_Yes.AccessibleDescription = null;
            checkBox_Yes.AccessibleName = null;
            resources.ApplyResources(checkBox_Yes, "checkBox_Yes");
            checkBox_Yes.BackColor = System.Drawing.Color.Transparent;
            checkBox_Yes.BackgroundImage = null;
            checkBox_Yes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            checkBox_Yes.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            checkBox_Yes.CheckSignSize = new System.Drawing.Size(14, 14);
            checkBox_Yes.CommandParameter = null;
            checkBox_Yes.Name = "checkBox_Yes";
            checkBox_Yes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            checkBox_Yes.Tag = "1";
            checkBox_Yes.CheckedChanged += new System.EventHandler(checkBox_Yes_CheckedChanged);
            checkBox_No.AccessibleDescription = null;
            checkBox_No.AccessibleName = null;
            resources.ApplyResources(checkBox_No, "checkBox_No");
            checkBox_No.BackColor = System.Drawing.Color.Transparent;
            checkBox_No.BackgroundImage = null;
            checkBox_No.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            checkBox_No.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            checkBox_No.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            checkBox_No.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            checkBox_No.Checked = true;
            checkBox_No.CheckSignSize = new System.Drawing.Size(14, 14);
            checkBox_No.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBox_No.CheckValue = "Y";
            checkBox_No.CommandParameter = null;
            checkBox_No.Name = "checkBox_No";
            checkBox_No.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            checkBox_No.Tag = "0";
            checkBox_No.CheckedChanged += new System.EventHandler(checkBox_No_CheckedChanged);
            checkBox_Cancel.AccessibleDescription = null;
            checkBox_Cancel.AccessibleName = null;
            resources.ApplyResources(checkBox_Cancel, "checkBox_Cancel");
            checkBox_Cancel.BackColor = System.Drawing.Color.Transparent;
            checkBox_Cancel.BackgroundImage = null;
            checkBox_Cancel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            checkBox_Cancel.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            checkBox_Cancel.CheckSignSize = new System.Drawing.Size(14, 14);
            checkBox_Cancel.CommandParameter = null;
            checkBox_Cancel.Name = "checkBox_Cancel";
            checkBox_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            checkBox_Cancel.Tag = "2";
            checkBox_Cancel.CheckedChanged += new System.EventHandler(checkBox_Cancel_CheckedChanged);
            txtBXBankNo.AccessibleDescription = null;
            txtBXBankNo.AccessibleName = null;
            resources.ApplyResources(txtBXBankNo, "txtBXBankNo");
            txtBXBankNo.BackColor = System.Drawing.Color.White;
            txtBXBankNo.BackgroundImage = null;
            txtBXBankNo.Font = null;
            txtBXBankNo.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            txtBXBankNo.Name = "txtBXBankNo";
            txtBXBankNo.ReadOnly = true;
            label2.AccessibleDescription = null;
            label2.AccessibleName = null;
            resources.ApplyResources(label2, "label2");
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label2.Name = "label2";
            button_OK.AccessibleDescription = null;
            button_OK.AccessibleName = null;
            button_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_OK, "button_OK");
            button_OK.BackgroundImage = null;
            button_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            button_OK.CommandParameter = null;
            button_OK.Name = "button_OK";
            button_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_OK.Symbol = "\uf00c";
            button_OK.SymbolSize = 12f;
            button_OK.TextColor = System.Drawing.Color.White;
            button_OK.Click += new System.EventHandler(button_OK_Click);
            button_Return.AccessibleDescription = null;
            button_Return.AccessibleName = null;
            button_Return.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_Return, "button_Return");
            button_Return.BackgroundImage = null;
            button_Return.Checked = true;
            button_Return.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            button_Return.CommandParameter = null;
            button_Return.Name = "button_Return";
            button_Return.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_Return.Symbol = "\uf00d";
            button_Return.SymbolSize = 12f;
            button_Return.TextColor = System.Drawing.Color.Black;
            button_Return.Click += new System.EventHandler(button_Return_Click);
            button_BackCancel.AccessibleDescription = null;
            button_BackCancel.AccessibleName = null;
            button_BackCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_BackCancel, "button_BackCancel");
            button_BackCancel.BackgroundImage = null;
            button_BackCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            button_BackCancel.CommandParameter = null;
            button_BackCancel.Name = "button_BackCancel";
            button_BackCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_BackCancel.Symbol = "\uf00c";
            button_BackCancel.SymbolSize = 12f;
            button_BackCancel.TextColor = System.Drawing.Color.White;
            button_BackCancel.Click += new System.EventHandler(button_BackCancel_Click);
            button_BackPay.AccessibleDescription = null;
            button_BackPay.AccessibleName = null;
            button_BackPay.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_BackPay, "button_BackPay");
            button_BackPay.BackgroundImage = null;
            button_BackPay.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            button_BackPay.CommandParameter = null;
            button_BackPay.Name = "button_BackPay";
            button_BackPay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_BackPay.Symbol = "\uf00c";
            button_BackPay.SymbolSize = 12f;
            button_BackPay.TextColor = System.Drawing.Color.White;
            button_BackPay.Click += new System.EventHandler(button_BackPay_Click);
            vcr1.AccessibleDescription = null;
            vcr1.AccessibleName = null;
            resources.ApplyResources(vcr1, "vcr1");
            vcr1.BackColor = System.Drawing.Color.Transparent;
            vcr1.BackgroundImage = null;
            vcr1.Font = null;
            vcr1.Name = "vcr1";
            vcr1.NextClick += new System.EventHandler<System.EventArgs>(VcrNextClick);
            vcr1.LastClick += new System.EventHandler<System.EventArgs>(VcrLastClick);
            vcr1.PreviousClick += new System.EventHandler<System.EventArgs>(VcrPreviousClick);
            vcr1.FirstClick += new System.EventHandler<System.EventArgs>(VcrFirstClick);
            imageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = System.Drawing.Color.Magenta;
            imageList1.Images.SetKeyName(0, "");
            imageList1.Images.SetKeyName(1, "");
            imageList1.Images.SetKeyName(2, "");
            imageList1.Images.SetKeyName(3, "");
            imageList1.Images.SetKeyName(4, "");
            imageList1.Images.SetKeyName(5, "");
            imageList1.Images.SetKeyName(6, "");
            imageList1.Images.SetKeyName(7, "");
            imageList1.Images.SetKeyName(8, "");
            imageList1.Images.SetKeyName(9, "");
            imageList1.Images.SetKeyName(10, "");
            imageList1.Images.SetKeyName(11, "");
            imageList1.Images.SetKeyName(12, "");
            imageList1.Images.SetKeyName(13, "");
            imageList1.Images.SetKeyName(14, "");
            imageList1.Images.SetKeyName(15, "");
            imageList1.Images.SetKeyName(16, "");
            imageList1.Images.SetKeyName(17, "");
            imageList1.Images.SetKeyName(18, "");
            imageList1.Images.SetKeyName(19, "");
            imageList1.Images.SetKeyName(20, "");
            imageList1.Images.SetKeyName(21, "");
            imageList1.Images.SetKeyName(22, "");
            imageList1.Images.SetKeyName(23, "");
            timerInfoBallon.Interval = 3000;
            timer1.Interval = 1000;
            superTabStrip1.AccessibleDescription = null;
            superTabStrip1.AccessibleName = null;
            resources.ApplyResources(superTabStrip1, "superTabStrip1");
            superTabStrip1.AutoSelectAttachedControl = false;
            superTabStrip1.BackgroundImage = null;
            superTabStrip1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            superTabStrip1.ContainerControlProcessDialogKey = true;
            superTabStrip1.ControlBox.Category = resources.GetString("superTabStrip1.ControlBox.Category");
            superTabStrip1.ControlBox.CloseBox.Category = resources.GetString("superTabStrip1.ControlBox.CloseBox.Category");
            superTabStrip1.ControlBox.CloseBox.CommandParameter = null;
            superTabStrip1.ControlBox.CloseBox.Description = resources.GetString("superTabStrip1.ControlBox.CloseBox.Description");
            superTabStrip1.ControlBox.CloseBox.Name = "";
            superTabStrip1.ControlBox.CloseBox.Tag = resources.GetString("superTabStrip1.ControlBox.CloseBox.Tag");
            superTabStrip1.ControlBox.CloseBox.Text = resources.GetString("superTabStrip1.ControlBox.CloseBox.Text");
            superTabStrip1.ControlBox.CloseBox.Tooltip = resources.GetString("superTabStrip1.ControlBox.CloseBox.Tooltip");
            superTabStrip1.ControlBox.CommandParameter = null;
            superTabStrip1.ControlBox.Description = resources.GetString("superTabStrip1.ControlBox.Description");
            superTabStrip1.ControlBox.MenuBox.Category = resources.GetString("superTabStrip1.ControlBox.MenuBox.Category");
            superTabStrip1.ControlBox.MenuBox.CommandParameter = null;
            superTabStrip1.ControlBox.MenuBox.Description = resources.GetString("superTabStrip1.ControlBox.MenuBox.Description");
            superTabStrip1.ControlBox.MenuBox.Name = "";
            superTabStrip1.ControlBox.MenuBox.Tag = resources.GetString("superTabStrip1.ControlBox.MenuBox.Tag");
            superTabStrip1.ControlBox.MenuBox.Text = resources.GetString("superTabStrip1.ControlBox.MenuBox.Text");
            superTabStrip1.ControlBox.MenuBox.Tooltip = resources.GetString("superTabStrip1.ControlBox.MenuBox.Tooltip");
            superTabStrip1.ControlBox.Name = "";
            superTabStrip1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[2]
            {
                superTabStrip1.ControlBox.MenuBox,
                superTabStrip1.ControlBox.CloseBox
            });
            superTabStrip1.ControlBox.Tag = resources.GetString("superTabStrip1.ControlBox.Tag");
            superTabStrip1.ControlBox.Text = resources.GetString("superTabStrip1.ControlBox.Text");
            superTabStrip1.ControlBox.Tooltip = resources.GetString("superTabStrip1.ControlBox.Tooltip");
            superTabStrip1.ControlBox.Visible = false;
            superTabStrip1.Font = null;
            superTabStrip1.Name = "superTabStrip1";
            superTabStrip1.ReorderTabsEnabled = true;
            superTabStrip1.SelectedTabIndex = 0;
            superTabStrip1.TabCloseButtonHot = null;
            superTabStrip1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[3]
            {
                superTabItem,
                buttonItem_Close,
                button_AddPage
            });
            resources.ApplyResources(superTabItem, "superTabItem");
            superTabItem.CommandParameter = null;
            superTabItem.GlobalItem = false;
            superTabItem.ImageAlignment = DevComponents.DotNetBar.ImageAlignment.MiddleCenter;
            superTabItem.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            superTabItem.Name = "superTabItem";
            superTabItem.Stretch = true;
            superTabItem.TabFont = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            superTabItem.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            resources.ApplyResources(buttonItem_Close, "buttonItem_Close");
            buttonItem_Close.Checked = true;
            buttonItem_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            buttonItem_Close.CommandParameter = null;
            buttonItem_Close.Name = "buttonItem_Close";
            buttonItem_Close.Stretch = true;
            buttonItem_Close.Symbol = "\uf00d";
            buttonItem_Close.SymbolSize = 12f;
            buttonItem_Close.Click += new System.EventHandler(Button_Close_Click);
            resources.ApplyResources(button_AddPage, "button_AddPage");
            button_AddPage.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            button_AddPage.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            button_AddPage.CommandParameter = null;
            button_AddPage.Name = "button_AddPage";
            button_AddPage.Stretch = true;
            button_AddPage.Symbol = "\uf067";
            button_AddPage.SymbolSize = 12f;
            button_AddPage.Click += new System.EventHandler(button_AddPage_Click);
            base.AccessibleDescription = null;
            base.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            BackgroundImage = null;
            base.Controls.Add(panel1);
            base.Controls.Add(superTabStrip1);
            Font = null;
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.Name = "FrmCheck";
            base.Load += new System.EventHandler(FrmCheck_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Frm_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(Frm_KeyDown);
            panel1.ResumeLayout(false);
            groupPanel2.ResumeLayout(false);
            groupPanel2.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)superTabStrip1).EndInit();
            ResumeLayout(false);
        }
    }
}
