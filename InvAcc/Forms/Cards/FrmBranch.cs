using Check_Data.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using Library.RepShow;
using Microsoft.Win32;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmBranch : Form
    { void avs(int arln)

{ 
 label17.Text=   (arln == 0 ? "  العنوان \\عربي :  " : "  Address \\ Arabic:") ; label15.Text=   (arln == 0 ? "  العنوان \\إنجليزي :  " : "  Address \\ English:") ; label16.Text=   (arln == 0 ? "  الشخص المسؤول :  " : "  responsible person :") ; label5.Text=   (arln == 0 ? "  فاكس الفرع :  " : "  Branch fax:") ; label4.Text=   (arln == 0 ? "  هاتف الفرع :  " : "  Branch phone:") ; label3.Text=   (arln == 0 ? "  رمز الفرع :  " : "  Branch Code:") ; label2.Text=   (arln == 0 ? "  إسم الفرع انجليزي :  " : "  English branch name:") ; label1.Text=   (arln == 0 ? "  اسم الفرع عربي :  " : "  Arabic branch name:") ; label9.Text=   (arln == 0 ? "  تاريخ الانتهاء :  " : "  Expiry date :") ; Label10.Text=   (arln == 0 ? "  تاريخ الأصدار :  " : "  Release Date :") ; label11.Text=   (arln == 0 ? "  رخصــــة البلدية :  " : "  Municipal license:") ; label6.Text=   (arln == 0 ? "  السجل التجاري :  " : "  Commercial Register :") ; label8.Text=   (arln == 0 ? "  تاريخ الانتهاء :  " : "  Expiry date :") ; label7.Text=   (arln == 0 ? "  تاريخ الأصدار :  " : "  Release Date :") ; superTabControl_Main1.Text=   (arln == 0 ? "  superTabControl3  " : "  superTabControl3") ; Button_Close.Text=   (arln == 0 ? "  إغلاق  " : "  Close") ; Button_Search.Text=   (arln == 0 ? "  بحث  " : "  Search") ; Button_Delete.Text=   (arln == 0 ? "  حذف  " : "  delete") ; Button_Save.Text=   (arln == 0 ? "  حفظ  " : "  save") ; Button_Add.Text=   (arln == 0 ? "  إضافة  " : "  addition") ; superTabControl_Main2.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; Button_First.Text=   (arln == 0 ? "  الأول  " : "  the first") ; Button_Prev.Text=   (arln == 0 ? "  السابق  " : "  the previous") ; lable_Records.Text=   (arln == 0 ? "  ---  " : "  ---") ; Button_Next.Text=   (arln == 0 ? "  التالي  " : "  next one") ; Button_Last.Text=   (arln == 0 ? "  الأخير  " : "  the last one") ; ToolStripMenuItem_Rep.Text=   (arln == 0 ? "  إظهار التقرير  " : "  Show report") ; ToolStripMenuItem_Det.Text=   (arln == 0 ? "  إظهار التفاصيل  " : "  Show details") ; panelEx3.Text=   (arln == 0 ? "  Fill Panel  " : "  Fill Panel") ; DGV_Main.Text=   (arln == 0 ? "    " : "    ") ; DGV_Main.Text=   (arln == 0 ? "  جميــع السجــــلات  " : "  All records") ; DGV_Main.Text=   (arln == 0 ? "    " : "    ") ; superTabControl_DGV.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; textBox_search.Text=   (arln == 0 ? "  ...  " : "  ...") ; Button_ExportTable2.Text=   (arln == 0 ? "  تصدير  " : "  Export") ; /*Button_PrintTable.Text=   (arln == 0 ? "  طباعة  " : "  Print") ; */panelEx2.Text=   (arln == 0 ? "  Click to collapse  " : "  Click to collapse") ; Text = "الفــــروع";this.Text=   (arln == 0 ? "  الفــــروع  " : "  branches") ;}
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
        protected ToolStripMenuItem ToolStripMenuItem_Det;
        protected ContextMenuStrip contextMenuStrip2;
        protected ContextMenuStrip contextMenuStrip1;
        protected IntegerInput Rep_RecCount;
        private Timer timerInfoBallon;
        private Timer timer1;
        private System.Windows.Forms. SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog  openFileDialog1;
        private ImageList imageList1;
        public DotNetBarManager dotNetBarManager1;
        private DockSite barBottomDockSite;
        private DockSite barLeftDockSite;
        private DockSite barRightDockSite;
        private DockSite barTopDockSite;
        private DockSite dockSite4;
        private DockSite dockSite1;
        private DockSite dockSite2;
        private DockSite dockSite3;
        private PanelEx panelEx3;
        private Panel panel1;
        private ExpandableSplitter expandableSplitter1;
        private PanelEx panelEx2;
        private RibbonBar ribbonBar1;
        private GroupBox groupBox1;
        private TextBox txtAddr;
        private Label label17;
        private TextBox txtRentEnd;
        private Label label15;
        private TextBox txtPersonalName;
        private Label label16;
        private TextBox txtFax;
        private Label label5;
        private TextBox txtTele;
        private Label label4;
        private TextBox textBox_ID;
        private Label label3;
        private TextBox txtEngDes;
        private Label label2;
        private TextBox txtArbDes;
        private Label label1;
        private GroupBox groupBox2;
        private Label label9;
        private Label Label10;
        private TextBox txtMun;
        private Label label11;
        private Label label6;
        private Label label8;
        private Label label7;
        private TextBox txtCrNo;
        private MaskedTextBox txtCrIssDat;
        private MaskedTextBox txtCrExpDat;
        private MaskedTextBox txtMunIssdat;
        private MaskedTextBox txtMunExpDat;
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
        protected SuperGridControl DGV_Main;
        private RibbonBar ribbonBar_DGV;
        private SuperTabControl superTabControl_DGV;
        protected TextBoxItem textBox_search;
        protected ButtonItem Button_ExportTable2;
        protected ButtonItem Button_PrintTable;
        protected LabelItem labelItem3;
        private LabelItem lable_Records;
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private int LangArEn = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
#pragma warning disable CS0414 // The field 'FrmBranch.FlagUpdate' is assigned but its value is never used
        private string FlagUpdate = "";
#pragma warning restore CS0414 // The field 'FrmBranch.FlagUpdate' is assigned but its value is never used
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private T_Branch data_this;
        private List<string> pkeys = new List<string>();
        private bool BronzOp = false;
        private Rate_DataDataContext dbInstance;
        private RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
        private T_User permission = new T_User();
        private Stock_DataDataContext dbInstanceStock;
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
        public T_Branch DataThis
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
        private Rate_DataDataContext dbc
        {
            get
            {
                if (dbInstance == null)
                {
                    dbInstance = new Rate_DataDataContext(VarGeneral.BranchRt);
                }
                return dbInstance;
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
                if (!VarGeneral.TString.ChkStatShow(value.FilStr, 21) || ((VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F" || VarGeneral.SSSLev == "C" || VarGeneral.SSSLev == "K" || VarGeneral.SSSLev == "Z") && !BronzOp))
                {
                    IfAdd = false;
                }
                else
                {
                    IfAdd = true;
                }
                if (!VarGeneral.TString.ChkStatShow(value.FilStr, 22))
                {
                    CanEdit = false;
                }
                else
                {
                    CanEdit = true;
                }
                if (!VarGeneral.TString.ChkStatShow(value.FilStr, 23) || ((VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F" || VarGeneral.SSSLev == "C" || VarGeneral.SSSLev == "K" || VarGeneral.SSSLev == "Z") && !BronzOp))
                {
                    IfDelete = false;
                }
                else
                {
                    IfDelete = true;
                }
                if (VarGeneral.gUserName == "runsetting" && VarGeneral.UserID != 1)
                {
                    IfAdd = false;
                    IfDelete = false;
                }
                if (!(VarGeneral.gUserName != "runsetting"))
                {
                    return;
                }
                long regval = 0L;
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
                    regval = long.Parse(hKey.GetValue("vRemotly").ToString());
                }
                if (regval == 1 && (VarGeneral.UserID != 1 || CalculateSupport() <= 0))
                {
                    IfAdd = false;
                    IfDelete = false;
                }
            }
        }
        private Stock_DataDataContext db
        {
            get
            {
                if (dbInstanceStock == null)
                {
                    dbInstanceStock = new Stock_DataDataContext(VarGeneral.BranchCS);
                }
                return dbInstanceStock;
            }
        }
        public void RefreshPKeys()
        {
            PKeys.Clear();
            var qkeys = from item in dbc.T_Branches
                        orderby item.Branch_no
                        select new
                        {
                            Code = item.Branch_no + ""
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
        public FrmBranch()
        {
            InitializeComponent();this.Load += langloads;
            textBox_ID.Click += Button_Edit_Click;
            txtAddr.Click += Button_Edit_Click;
            txtArbDes.Click += Button_Edit_Click;
            txtCrExpDat.Click += Button_Edit_Click;
            txtCrIssDat.Click += Button_Edit_Click;
            txtCrNo.Click += Button_Edit_Click;
            txtEngDes.Click += Button_Edit_Click;
            txtFax.Click += Button_Edit_Click;
            txtMun.Click += Button_Edit_Click;
            txtMunExpDat.Click += Button_Edit_Click;
            txtMunIssdat.Click += Button_Edit_Click;
            txtRentEnd.Click += Button_Edit_Click;
            txtPersonalName.Click += Button_Edit_Click;
            txtTele.Click += Button_Edit_Click;
            DGV_Main.PrimaryGrid.CheckBoxes = false;
            DGV_Main.PrimaryGrid.ShowCheckBox = false;
            DGV_Main.PrimaryGrid.ShowTreeButton = false;
            DGV_Main.PrimaryGrid.ShowTreeButtons = false;
            DGV_Main.PrimaryGrid.ShowTreeLines = false;
            DGV_Main.PrimaryGrid.RowHeaderWidth = 25;
            DGV_Main.DataBindingComplete += DGV_Main_DataBindingComplete;
            DGV_Main.CellClick += DGV_Main_CellClick;
            DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
            DGV_Main.GetCellStyle += DGV_MainGetCellStyle;
            DGV_Main.MouseDown += DGV_Main_MouseDown;
            DGV_Main.MouseDown += DGV_Main_MouseDown;
            expandableSplitter1.Click += expandableSplitter1_Click;
            ToolStripMenuItem_Det.Click += ToolStripMenuItem_Det_Click;
            Button_ExportTable2.Click += Button_ExportTable2_Click;
            textBox_search.InputTextChanged += TextBox_Search_InputTextChanged;
            textBox_search.ButtonCustomClick += TextBox_Search_ButtonCustomClick;
            TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
            Button_Close.Click += Button_Close_Click;
            Button_First.Click += Button_First_Click;
            Button_Prev.Click += Button_Prev_Click;
            Button_Next.Click += Button_Next_Click;
            Button_Last.Click += Button_Last_Click;
            Button_Add.Click += Button_Add_Click;
            Button_Search.Click += Button_Search_Click;
            Button_Delete.Click += Button_Delete_Click;
            Button_Save.Click += Button_Save_Click;
            TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
            Button_PrintTable.Click += Button_Print_Click;
            try
            {
                if (VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F" || VarGeneral.SSSLev == "C")
                {
                    RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
                    if (hKey != null)
                    {
                        try
                        {
                            object q = hKey.GetValue("vBr");
                            if (string.IsNullOrEmpty(q.ToString()))
                            {
                                hKey.CreateSubKey("vBr");
                                hKey.SetValue("vBr", "0");
                            }
                        }
                        catch
                        {
                            hKey.CreateSubKey("vBr");
                            hKey.SetValue("vBr", "0");
                        }
                        long regval = long.Parse(hKey.GetValue("vBr").ToString());
                        if (regval == 1)
                        {
                            BronzOp = true;
                            IfAdd = true;
                            IfDelete = true;
                        }
                        else
                        {
                            BronzOp = false;
                            IfAdd = false;
                            IfDelete = false;
                        }
                    }
                }
                else
                {
                    IfAdd = true;
                    IfDelete = true;
                }
            }
            catch
            {
                IfAdd = false;
                IfDelete = false;
            }
            if (VarGeneral.SSSLev == "K" || VarGeneral.SSSLev == "Z")
            {
                IfAdd = false;
                IfDelete = false;
            }
            if (VarGeneral.UserID != 1)
            {
                Button_Add.Enabled = false;
            }
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
        public void Button_Search_Click(object sender, EventArgs e)
        {
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_Branch";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                textBox_ID.Text = frm.SerachNo.ToString();
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
        private void TextBox_Search_InputTextChanged(object sender)
        {
            Fill_DGV_Main();
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
            List<T_Branch> list = dbc.FillBranch_2(textBox_search.TextBox.Text).ToList();
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                }
            }
            FillHDGV(list);
        }
        public void FillHDGV(IEnumerable<T_Branch> new_data_enum)
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
            DGV_Main.PrimaryGrid.DataMember = "T_Branch";
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
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmBranch));
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
                label3.Text = "رمز الفرع :";
                label16.Text = "الشخص المسؤول :";
                label1.Text = "الإسم - عربي :";
                label2.Text = "الإسم - إنجليزي :";
                label4.Text = "هاتف الفرع :";
                label5.Text = "فاكس الفرع :";
                label17.Text = "العنوان عربي :";
                label15.Text = "العنوان إنجليزي :";
                label6.Text = "السجل التجاري :";
                label7.Text = "تاريخ الإصدار :";
                label8.Text = "تاريخ الإنتهاء :";
                label9.Text = "تاريخ الإنتهاء :";
                Label10.Text = "تاريخ الإصدار :";
                label11.Text = "رخصــــة البلدية :";
                Text = "كرت الفـــروع";
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
                label3.Text = "Code :";
                label16.Text = "Person in charge :";
                label1.Text = "Name - Arabic :";
                label2.Text = "Name - English :";
                label4.Text = "Tel :";
                label5.Text = "Fax :";
                label17.Text = "Address Arabic :";
                label15.Text = "Address English :";
                label6.Text = "Record number :";
                label7.Text = "Date of issue :";
                label8.Text = "Expiration date :";
                label9.Text = "Expiration date :";
                Label10.Text = "Date of issue :";
                label11.Text = "Municipal license :";
                Text = "Branches Card";
            }
        }
        private void FrmBranch_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmBranch));
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
                    columns_Names_visible.Add("Branch_no", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
                    columns_Names_visible.Add("Branch_Name", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
                    columns_Names_visible.Add("Branch_NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
                    columns_Names_visible.Add("Branch_phone", new ColumnDictinary("الهاتف", "Phone", ifDefault: true, ""));
                    columns_Names_visible.Add("Branch_fax", new ColumnDictinary("الفاكس", "Fax", ifDefault: false, ""));
                    columns_Names_visible.Add("crNo", new ColumnDictinary("رقم السجل التجاري", "Cr No", ifDefault: true, ""));
                    columns_Names_visible.Add("BldNo", new ColumnDictinary("رقم رخصة البلدية", "Municipality Name", ifDefault: true, ""));
                }
                else
                {
                    Clear();
                    textBox_ID.Text = "";
                    TextBox_Index.TextBox.Text = "";
                }
                RefreshPKeys();
                RibunButtons();
                textBox_ID.Text = PKeys.FirstOrDefault();
                ViewDetails_Click(sender, e);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            if (VarGeneral.UserID != 1)
            {
                Button_Add.Enabled = false;
            }
        }
        private int CalculateSupport()
        {
            try
            {
                RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\MrdSoft\\Register", writable: true);
                string regval = "";
                string DT_H = "";
                try
                {
                    regval = n.FormatGreg(hKey.GetValue("DTBackup").ToString(), "yyyy/MM/dd");
                    DT_H = n.GregToHijri(regval);
                }
                catch
                {
                    regval = "";
                    DT_H = "";
                }
                if (!VarGeneral.CheckDate(regval))
                {
                    return 0;
                }
                if (Convert.ToDateTime(VarGeneral.Hdate) > Convert.ToDateTime(n.FormatHijri(DT_H, "yyyy/MM/dd")))
                {
                    return 0;
                }
                return n.vDiff(n.FormatHijri(DT_H, "yyyy/MM/dd"), VarGeneral.Hdate);
            }
            catch
            {
                return 0;
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
                T_Branch newData = dbc.RateBranch(no.ToString());
                if (newData == null || newData.Branch_ID == 0)
                {
                    if (!Button_Add.Visible || !Button_Add.Enabled)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
                    int indexA = PKeys.IndexOf(newData.Branch_no ?? "");
                    indexA++;
                    TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                    TextBox_Index.TextBox.Text = string.Concat(indexA);
                    TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                }
                try
                {
                    if (textBox_ID.Text == "1" || data_this.Branch_ID == 1)
                    {
                        IfDelete = false;
                    }
                    else
                    {
                        IfDelete = true;
                    }
                }
                catch
                {
                    IfDelete = true;
                }
            }
            catch
            {
            }
            UpdateVcr();
        }
        public void Clear()
        {
            if (State == FormState.New)
            {
                return;
            }
            State = FormState.New;
            data_this = new T_Branch();
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
            SetReadOnly = false;
        }
        public void SetData(T_Branch value)
        {
            try
            {
                State = FormState.Saved;
                Button_Save.Enabled = false;
                textBox_ID.Tag = value.Branch_ID;
                txtAddr.Text = value.Branch_address;
                txtArbDes.Text = value.Branch_Name;
                txtCrExpDat.Text = value.crExp;
                txtCrIssDat.Text = value.crIssu;
                txtCrNo.Text = value.crNo;
                txtEngDes.Text = value.Branch_NameE;
                txtFax.Text = value.Branch_fax;
                txtMun.Text = value.BldNo;
                txtMunExpDat.Text = value.BldExp;
                txtMunIssdat.Text = value.BldIssu;
                txtRentEnd.Text = value.EndEg;
                txtPersonalName.Text = value.StartEg;
                txtTele.Text = value.Branch_phone;
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
        private T_Branch GetData()
        {
            textBox_ID.Focus();
            try
            {
                data_this.BldExp = txtMunExpDat.Text;
            }
            catch
            {
            }
            try
            {
                data_this.BldIssu = txtMunIssdat.Text;
            }
            catch
            {
            }
            try
            {
                data_this.BldNo = txtMun.Text;
            }
            catch
            {
            }
            try
            {
                data_this.Branch_address = txtAddr.Text;
            }
            catch
            {
            }
            try
            {
                data_this.Branch_fax = txtFax.Text;
            }
            catch
            {
            }
            try
            {
                data_this.Branch_Name = txtArbDes.Text;
            }
            catch
            {
            }
            try
            {
                data_this.Branch_NameE = txtEngDes.Text;
            }
            catch
            {
            }
            try
            {
                data_this.Branch_no = textBox_ID.Text;
            }
            catch
            {
            }
            try
            {
                data_this.Branch_phone = txtTele.Text;
            }
            catch
            {
            }
            try
            {
                data_this.crExp = txtCrExpDat.Text;
            }
            catch
            {
            }
            try
            {
                data_this.crIssu = txtCrIssDat.Text;
            }
            catch
            {
            }
            try
            {
                data_this.crNo = txtCrNo.Text;
            }
            catch
            {
            }
            try
            {
                data_this.EndEg = txtRentEnd.Text;
            }
            catch
            {
            }
            try
            {
                data_this.StartEg = txtPersonalName.Text;
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
                max = dbc.MaxBranchNo;
                Clear();
                textBox_ID.Text = max.ToString();
                State = FormState.New;
            }
        }
        private void Button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.vEndYears || !Button_Save.Enabled)
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
                if (textBox_ID.Text == "" || txtArbDes.Text == "" || txtEngDes.Text == "")
                {
                    MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الرمز او الإسم فارغا\u0651" : "Can not be a number or name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (State == FormState.New)
                {
                    List<string> q = dbc.ExecuteQuery<string>("SELECT name FROM sys.databases Where name = 'PROSOFT_" + textBox_ID.Text + "' ORDER BY name ", new object[0]).ToList();
                    if (q.Count > 0)
                    {
                        MessageBox.Show((LangArEn == 0) ? " اسم قاعدة البيانات الجديدة موجود في السيرفر الحالي ..\n الرجاء تغيير الاسم والمحاولة مرة اخرى ؟" : " name the new database exists in the current server ..\n Please change the name and try again ?", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    if (File.Exists(Application.StartupPath + "\\SqlPath.xml"))
                    {
                        try
                        {
                            Stock_DataDataContext dbBranch = new Stock_DataDataContext("Server=" + VarGeneral.gServerName + ";Database=;UID=" + VarGeneral.UsrName + ";PWD=" + VarGeneral.UsrPass);
                            FrmMain frm = new FrmMain(dbBranch, null, textBox_ID.Text, 0);
                        }
                        catch (Exception error2)
                        {
                            MessageBox.Show((LangArEn == 0) ? ("خطأ .. لم يتم اضافة قاعدة البيانات بنجاح \n " + error2.Message) : ("Error .. Don't Add Data Base Successfully \n " + error2.Message), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            VarGeneral.DebLog.writeLog("buttonItem_AddData_Click:", error2, enable: true);
                            return;
                        }
                        GetData();
                        try
                        {
                            dbc.T_Branches.InsertOnSubmit(data_this);
                            dbc.SubmitChanges();
                        }
                        catch (SqlException ex4)
                        {
                            int max = 0;
                            max = dbc.MaxBranchNo;
                            if (ex4.Number != 2627)
                            {
                                return;
                            }
                            MessageBox.Show("الرمز مستخدم من قبل.\n سيتم الحفظ برقم جديد [" + max + "]", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            textBox_ID.Text = string.Concat(max);
                            data_this.Branch_no = string.Concat(max);
                            Button_Save_Click(sender, e);
                        }
                        catch (Exception)
                        {
                            return;
                        }
                        goto IL_03df;
                    }
                    MessageBox.Show((LangArEn == 0) ? "خطأ .. لم يتم الوصول الى الملف الخاص ببيانات السيرفر ؟" : "Error .. Not Found Data Server File ?", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (State == FormState.Edit)
                {
                    GetData();
                    try
                    {
                        dbc.Log = VarGeneral.DebugLog;
                        dbc.SubmitChanges(ConflictMode.ContinueOnConflict);
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
                goto IL_03df;
            IL_03df:
                State = FormState.Saved;
                RefreshPKeys();
                TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(data_this.Branch_no ?? "") + 1);
                SetReadOnly = true;
            }
            catch (Exception error2)
            {
                VarGeneral.DebLog.writeLog("Save:", error2, enable: true);
                MessageBox.Show(error2.Message);
            }
        }
        private void Button_Delete_Click(object sender, EventArgs e)
        {
            if (!Button_Delete.Enabled || !Button_Delete.Visible || State != 0)
            {
                ifOkDelete = false;
                return;
            }
            try
            {
                if (textBox_ID.Text == "1" || data_this.Branch_ID == 1)
                {
                    ifOkDelete = false;
                    return;
                }
            }
            catch (Exception error2)
            {
                MessageBox.Show(error2.Message);
                return;
            }
            try
            {
                IOrderedEnumerable<T_Branch> CheckOrder = from g in dbc.FillBranch_2("").ToList()
                                                          orderby g.Branch_ID
                                                          select g;
                if (CheckOrder.LastOrDefault().Branch_no != textBox_ID.Text)
                {
                    ifOkDelete = false;
                    return;
                }
            }
            catch (Exception error2)
            {
                MessageBox.Show(error2.Message);
                return;
            }
            string Code = "";
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
            if (data_this == null || data_this.Branch_ID == 0 || !ifOkDelete)
            {
                return;
            }
            T_User returned = dbc.SelectBrnchNoByReturnNo(DataThis.Branch_no);
            if ((returned != null && !string.IsNullOrEmpty(returned.Brn)) || textBox_ID.Text == "1")
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن حذف الفرع .. لانه مرتبط باحد المستخدمين" : "You can not delete Branch .. because it is Linked to a user", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            string oldBr_ = VarGeneral.BranchNumber;
            try
            {
                List<T_Branch> BrList = dbc.FillBranch_2("").ToList();
                for (int i = 0; i < BrList.Count; i++)
                {
                    VarGeneral.BranchNumber = BrList[i].Branch_no;
                    Stock_DataDataContext ct = new Stock_DataDataContext(VarGeneral.BranchCS);
                    List<T_INVHED> q = (from t in ct.T_INVHEDs
                                        where t.tailor20 == data_this.Branch_no
                                        where t.IfDel == (int?)0
                                        select t).ToList();
                    if (q.Count > 0)
                    {
                        MessageBox.Show((LangArEn == 0) ? ("لايمكن حذف الفرع .. لانه مرتبط باحد فواتير الفرع " + VarGeneral.BranchNumber) : "You can not delete Branch .. ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        dbInstance = null;
                        VarGeneral.BranchNumber = oldBr_;
                        return;
                    }
                }
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? ("لايمكن حذف الفرع .. لانه مرتبط باحد فواتير الفرع " + VarGeneral.BranchNumber) : "You can not delete Branch .. ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                dbInstance = null;
                VarGeneral.BranchNumber = oldBr_;
                return;
            }
            dbInstance = null;
            VarGeneral.BranchNumber = oldBr_;
            data_this = dbc.RateBranch(DataThis.Branch_no.ToString());
            try
            {
                if ("PROSOFT_" + textBox_ID.Text == VarGeneral.gDatabaseName + VarGeneral.BranchNumber)
                {
                    MessageBox.Show((LangArEn == 0) ? "خطأ ..لايمكن ازلة قاعدة البيانات .. لانها قيد الاستخدام الان" : "Error .. Can not titan database .. because it is in use now .. !", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                try
                {
                    db.ExecuteCommand("ALTER DATABASE " + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + textBox_ID.Text + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE;\r\n                                DROP DATABASE [" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + textBox_ID.Text + "]");
                    dbc.T_Branches.DeleteOnSubmit(DataThis);
                    dbc.SubmitChanges();
                    dbInstance = null;
                }
                catch (Exception error2)
                {
                    VarGeneral.DebLog.writeLog("Button_Sav_Click:", error2, enable: true);
                    MessageBox.Show(error2.Message);
                }
            }
            catch (SqlException)
            {
                data_this = dbc.RateBranch(DataThis.Branch_no.ToString());
                return;
            }
            catch (Exception)
            {
                data_this = dbc.RateBranch(DataThis.Branch_no.ToString());
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
            if (dataMember != null && dataMember == "T_Branch")
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
            panel.Columns["Branch_no"].Width = 120;
            panel.Columns["Branch_no"].Visible = columns_Names_visible["Branch_no"].IfDefault;
            panel.Columns["Branch_Name"].Width = 180;
            panel.Columns["Branch_Name"].Visible = columns_Names_visible["Branch_Name"].IfDefault;
            panel.Columns["Branch_NameE"].Width = 180;
            panel.Columns["Branch_NameE"].Visible = columns_Names_visible["Branch_NameE"].IfDefault;
            panel.Columns["Branch_phone"].Width = 110;
            panel.Columns["Branch_phone"].Visible = columns_Names_visible["Branch_phone"].IfDefault;
            panel.Columns["Branch_fax"].Width = 110;
            panel.Columns["Branch_fax"].Visible = columns_Names_visible["Branch_fax"].IfDefault;
            panel.Columns["crNo"].Width = 180;
            panel.Columns["crNo"].Visible = columns_Names_visible["crNo"].IfDefault;
            panel.Columns["BldNo"].Width = 180;
            panel.Columns["BldNo"].Visible = columns_Names_visible["BldNo"].IfDefault;
            panel.ReadOnly = true;
        }
        private void DGV_MainGetCellStyle(object sender, GridGetCellStyleEventArgs e)
        {
        }
        private void DGV_Main_CellClick(object sender, GridCellClickEventArgs e)
        {
            DGV_Main.PrimaryGrid.Tag = e.GridCell.RowIndex;
        }
        private void DGV_Main_CellDoubleClick(object sender, GridCellDoubleClickEventArgs e)
        {
            ToolStripMenuItem_Det_Click(sender, e);
        }
        private void Button_ExportTable2_Click(object sender, EventArgs e)
        {
            try
            {
                ExportExcel.ExportToExcel(DGV_Main, "تقرير الفروع");
            }
            catch
            {
            }
        }
        private void Button_Close_Click(object sender, EventArgs e)
        {
            Close_Form(sender, e);
        }
        public void Close_Form(object sender, EventArgs e)
        {
            if (State != 0 && Button_Save.Visible)
            {
                if (State == FormState.New)
                {
                    Close();
                }
                else
                {
                    Close();
                }
            }
            else
            {
                Close();
            }
        }
        private void ADD_Controls()
        {
            try
            {
                controls = new List<Control>();
                controls.Add(txtAddr);
                codeControl = textBox_ID;
                controls.Add(txtArbDes);
                controls.Add(txtCrExpDat);
                controls.Add(txtCrIssDat);
                controls.Add(txtCrNo);
                controls.Add(txtEngDes);
                controls.Add(txtFax);
                controls.Add(textBox_ID);
                controls.Add(txtMunExpDat);
                controls.Add(txtMun);
                controls.Add(txtMunIssdat);
                controls.Add(txtRentEnd);
                controls.Add(txtPersonalName);
                controls.Add(txtTele);
            }
            catch (SqlException)
            {
            }
        }
        private void textBox_ID_Click(object sender, EventArgs e)
        {
            textBox_ID.SelectAll();
        }
        private void txtCrNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void txtMun_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void txtPersonalName_Click(object sender, EventArgs e)
        {
            txtPersonalName.SelectAll();
        }
        private void txtCrNo_Click(object sender, EventArgs e)
        {
            txtCrNo.SelectAll();
        }
        private void txtMun_Click(object sender, EventArgs e)
        {
            txtMun.SelectAll();
        }
        private void txtCrIssDat_Click(object sender, EventArgs e)
        {
            txtCrIssDat.SelectAll();
        }
        private void txtMunIssdat_Click(object sender, EventArgs e)
        {
            txtMunIssdat.SelectAll();
        }
        private void txtCrExpDat_Click(object sender, EventArgs e)
        {
            txtCrExpDat.SelectAll();
        }
        private void txtMunExpDat_Click(object sender, EventArgs e)
        {
            txtMunExpDat.SelectAll();
        }
        private void txtCrIssDat_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtCrIssDat.Text))
                {
                    txtCrIssDat.Text = Convert.ToDateTime(txtCrIssDat.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    txtCrIssDat.Text = "";
                }
            }
            catch
            {
                txtCrIssDat.Text = "";
            }
        }
        private void txtMunIssdat_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtMunIssdat.Text))
                {
                    txtMunIssdat.Text = Convert.ToDateTime(txtMunIssdat.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    txtMunIssdat.Text = "";
                }
            }
            catch
            {
                txtMunIssdat.Text = "";
            }
        }
        private void txtCrExpDat_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtCrExpDat.Text))
                {
                    txtCrExpDat.Text = Convert.ToDateTime(txtCrExpDat.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    txtCrExpDat.Text = "";
                }
            }
            catch
            {
                txtCrExpDat.Text = "";
            }
        }
        private void txtMunExpDat_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtMunExpDat.Text))
                {
                    txtMunExpDat.Text = Convert.ToDateTime(txtMunExpDat.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    txtMunExpDat.Text = "";
                }
            }
            catch
            {
                txtMunExpDat.Text = "";
            }
        }
        private void txtArbDes_Enter(object sender, EventArgs e)
        {
            Language.Switch("AR");
        }
        private void txtEngDes_Enter(object sender, EventArgs e)
        {
            Language.Switch("EN");
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
                _RepShow.Tables = " T_Branch ";
                string Fields = "";
                Fields = " T_Branch.Branch_no as No , T_Branch.Branch_Name as NmA, T_Branch.Branch_NameE as NmE ";
                _RepShow.Rule = "";
                if (!string.IsNullOrEmpty(Fields))
                {
                    _RepShow.Fields = Fields;
                    try
                    {
                        VarGeneral.RepShowStock_Rat = "Rate";
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepShowStock_Rat = "";
                        VarGeneral.RepData = _RepShow.RepData;
                    }
                    catch (Exception ex2)
                    {
                        VarGeneral.RepShowStock_Rat = "";
                        MessageBox.Show(ex2.Message);
                    }
                    _RepShow = new RepShow();
                    _RepShow.Rule = "";
                    _RepShow.Tables = " T_SYSSETTING ";
                    _RepShow.Fields = " T_SYSSETTING.LogImg ";
                    _RepShow = _RepShow.Save();
                    _RepShow.RepData.Tables[0].Merge(VarGeneral.RepData.Tables[0]);
                    VarGeneral.RepData = _RepShow.RepData;
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
                else
                {
                    MessageBox.Show((LangArEn == 0) ? " يجب تحديد حقل واحد على الأقل للطباعة" : "You must select one field or more", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            catch (Exception)
            {
                VarGeneral.RepShowStock_Rat = "";
            }
        }
        private void txtFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b')) && e.KeyChar != '-' && e.KeyChar != '\\')
            {
                e.Handled = true;
            }
        }
        private void txtFax_Click(object sender, EventArgs e)
        {
            txtFax.SelectAll();
        }
        private void txtTele_Click(object sender, EventArgs e)
        {
            txtTele.SelectAll();
        }
        private void Button_Save_Click_1(object sender, EventArgs e)
        {
        }
    }
}
