using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Library.RepShow;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmUsr : Form
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
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private int LangArEn = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
        private string FlagUpdate = "";
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private T_Store _Store = new T_Store();
        private List<T_Store> listStore = new List<T_Store>();
        private bool canUpdate = true;
        private T_User data_this;
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstanceStock;
        private Rate_DataDataContext dbInstance;
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
            //this.WindowState = FormWindowState.Minimized;
            //this.WindowState = FormWindowState.Maximized;
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
        private RibbonBar ribbonBar1;
        private ImageList imageList1;
        protected ContextMenuStrip contextMenuStrip1;
        protected ContextMenuStrip contextMenuStrip2;
        protected ToolStripMenuItem ToolStripMenuItem_Det;
        protected IntegerInput Rep_RecCount;
        private OpenFileDialog openFileDialog1;
        private Timer timerInfoBallon;
        private SaveFileDialog saveFileDialog1;
        private PanelEx panelEx3;
        private Timer timer1;
        private PanelEx panelEx2;
        private ExpandableSplitter expandableSplitter1;
        private Panel panel1;
        private Label label5;
        private TextBox txtUserNameE;
        private TextBox txtPassConf;
        private TextBox txtPass;
        private TextBox textBox_ID;
        private Label label8;
        private Label label6;
        private Label label7;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtUserName;
        private Label label1;
        private ComboBoxEx CmbStatus;
        private ComboBoxEx CmbLanguge;
        private ComboBoxEx CmbBranch;
        private RibbonControl ribbonControl_Setting;
        private ButtonItem buttonItem1;
        private RibbonPanel ribbonPanel1;
        private RibbonTabItem ribbonTabItem_Files;
        private RibbonPanel ribbonPanel2;
        private C1FlexGrid FlxFiles;
        private RibbonPanel ribbonPanel3;
        private RibbonPanel ribbonPanel4;
        private RibbonPanel ribbonPanel5;
        private RibbonPanel ribbonPanel6;
        private RibbonTabItem ribbonTabItem_Inv;
        private RibbonTabItem ribbonTabItem_ACC;
        private RibbonTabItem ribbonTabItem_RepStocks;
        private RibbonTabItem ribbonTabItem_RepAcc;
        private RibbonTabItem ribbonTabItem_General;
        private C1FlexGrid FlxInvoices;
        private C1FlexGrid FlxAccounting;
        private C1FlexGrid FlxSRep;
        private RibbonPanel ribbonPanel7;
        private RibbonTabItem ribbonTabItem_Other;
        private QatCustomizeItem qatCustomizeItem1;
        private ButtonItem buttonItem_SelectAll;
        private ButtonItem buttonItem_UnSelectAll;
        private C1FlexGrid FlxAccRep;
        private CheckBoxX chk1;
        private CheckBoxX chk2;
        private CheckBoxX chk3;
        private CheckBoxX chk7;
        private CheckBoxX chk4;
        private CheckBoxX chk5;
        private CheckBoxX chk6;
        private RibbonBar ribbonBar_Tasks;
        private SuperTabControl superTabControl_Main1;
        protected ButtonItem Button_Close;
        protected ButtonItem Button_Search;
        protected ButtonItem Button_Delete;
        protected ButtonItem Button_Save;
        protected ButtonItem Button_Add;
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
        private C1FlexGrid FlxSetups;
        private RibbonPanel ribbonPanel8;
        private RibbonTabItem ribbonTabItem_Emps;
        private NavigationPane navigationPane_Emps;
        private NavigationPanePanel navigationPanePanel5;
        private C1FlexGrid dataGridViewX_MenuPer;
        private ButtonItem MenuPer;
        private NavigationPanePanel navigationPanePanel4;
        private C1FlexGrid dataGridViewX_MovePre;
        private ButtonItem MovePre;
        private NavigationPanePanel navigationPanePanel3;
        private C1FlexGrid dataGridViewX_SalPer;
        private ButtonItem SalPer;
        private NavigationPanePanel navigationPanePanel2;
        private C1FlexGrid dataGridViewX_RepPre;
        private ButtonItem RepPre;
        private NavigationPanePanel navigationPanePanel1;
        private C1FlexGrid dataGridViewX_GenralPre;
        private ButtonItem GenralPre;
        private LabelItem lable_Records;
        private CheckBoxX chk8;
        private CheckBoxX chk9;
        private GroupBox groupBox_Comm;
        private Label label9;
        private Label label10;
        protected Label label11;
        private DoubleInput textBox_CommGaid;
        protected Label label12;
        private DoubleInput textBox_CommInv;
        private CheckBoxX chk10;
        private SwitchButton switchButton_AdminOp;
        private ComboBoxEx CmbInvPrice;
        private Label label13;
        private ComboBoxEx CmbSendOption;
        private Label label14;
        private ComboBoxEx CmbInvPriceStop;
        private Label label15;
        private CheckBoxX chk12;
        private RibbonPanel ribbonTabItem_Hotel;
        private RibbonTabItem ribbonTabItem_Hotels;
        private NavigationPane navigationPane_Hotel;
        private NavigationPanePanel navigationPanePanel6;
        private C1FlexGrid dataGridViewX_HotelMenuPer;
        private ButtonItem HotelMenuPer;
        private NavigationPanePanel navigationPanePanel7;
        private C1FlexGrid dataGridViewX_HotelMovePre;
        private ButtonItem HotelMovePre;
        private NavigationPanePanel navigationPanePanel8;
        private C1FlexGrid dataGridViewX_HotelRepPre;
        private ButtonItem HotelRepPre;
        private NavigationPanePanel navigationPanePanel9;
        private C1FlexGrid dataGridViewX_HotelGenralPre;
        private ButtonItem HotelGenralPre;
        private ComboBoxEx CmbCommTyp;
        private Label label19;
        private Panel panel_Prices;
        private CheckBoxX chk13;
        private Label label18;
        private ComboBoxEx Combo1;
        private Label label17;
        private ComboBoxEx Combo3;
        private Label label16;
        private CheckBoxX chk14;
        private GroupPanel groupPanel_InvoiceType;
        private C1FlexGrid FlexType;
        private CheckBoxX chk15;
        private GroupPanel groupPanel_Stores;
        private C1FlexGrid FlxStkQty;
        private ComboBoxEx CmbStores;
        private Label label20;
        private CheckBoxX chk16;
        private SwitchButton switchButton_ControlHeadOFRep;
        private CheckBoxX chk17;
        private CheckBoxX chk18;
        private CheckBoxX chk19;
        private CheckBoxX chk20;
        private CheckBoxX chk21;
        private GroupPanel groupPanel_Banner;
        private PictureBox PicItemImg;
        private ButtonX button_ClearPic;
        private ButtonX button_EnterImg;
        private Label label21;
        private IntegerInput txtHeight;
        private Label label34;
        private IntegerInput txtWidth;
        private CheckBoxX chk22;
        private GroupBox groupBox1;
        private Label label23;
        protected Label label25;
        private DoubleInput textBox_MaxDis;
        private CheckBoxX chk23;
        private RibbonPanel ribbonPanel9;
        private RibbonTabItem ribbonTabItem_Eqar;
        private NavigationPane navigationPane_Eqar;
        private NavigationPanePanel navigationPanePanel12;
        private C1FlexGrid dataGridViewX_Tenants;
        private ButtonItem EqarTenant;
        private NavigationPanePanel navigationPanePanel13;
        private C1FlexGrid dataGridViewX_GenralEqar;
        private ButtonItem EqarGenarl;
        private NavigationPanePanel navigationPanePanel10;
        private C1FlexGrid dataGridViewX_RepEqar;
        private ButtonItem EqarsRep;
        private NavigationPanePanel navigationPanePanel11;
        private C1FlexGrid dataGridViewX_EqarFiles;
        private CheckBoxItem chk11;
        private ButtonItem EqarFiles;
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
        public T_User DataThis
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
        public void RefreshPKeys()
        {
            PKeys.Clear();
            var qkeys = from item in dbc.T_Users
                        orderby item.UsrNo
                        where item.Usr_ID != 1
                        select new
                        {
                            Code = item.UsrNo + ""
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
        public FrmUsr()
        {
            InitializeComponent();
            textBox_ID.Click += Button_Edit_Click;
            txtWidth.Click += Button_Edit_Click;
            txtHeight.Click += Button_Edit_Click;
            txtPass.Click += Button_Edit_Click;
            txtPassConf.Click += Button_Edit_Click;
            txtUserName.Click += Button_Edit_Click;
            txtUserNameE.Click += Button_Edit_Click;
            CmbBranch.Click += Button_Edit_Click;
            CmbLanguge.Click += Button_Edit_Click;
            CmbStatus.Click += Button_Edit_Click;
            CmbStores.Click += Button_Edit_Click;
            CmbInvPrice.Click += Button_Edit_Click;
            CmbInvPriceStop.Click += Button_Edit_Click;
            CmbSendOption.Click += Button_Edit_Click;
            FlxAccounting.Click += Button_Edit_Click;
            FlxAccRep.Click += Button_Edit_Click;
            FlxFiles.Click += Button_Edit_Click;
            FlexType.Click += Button_Edit_Click;
            FlxStkQty.Click += Button_Edit_Click;
            textBox_CommInv.Click += Button_Edit_Click;
            textBox_CommGaid.Click += Button_Edit_Click;
            switchButton_AdminOp.Click += Button_Edit_Click;
            textBox_MaxDis.Click += Button_Edit_Click;
            chk1.Click += Button_Edit_Click;
            chk2.Click += Button_Edit_Click;
            chk3.Click += Button_Edit_Click;
            chk4.Click += Button_Edit_Click;
            chk5.Click += Button_Edit_Click;
            chk6.Click += Button_Edit_Click;
            chk7.Click += Button_Edit_Click;
            chk8.Click += Button_Edit_Click;
            chk9.Click += Button_Edit_Click;
            chk10.Click += Button_Edit_Click;
            chk11.Click += Button_Edit_Click;
            chk12.Click += Button_Edit_Click;
            chk13.Click += Button_Edit_Click;
            chk14.Click += Button_Edit_Click;
            chk15.Click += Button_Edit_Click;
            chk16.Click += Button_Edit_Click;
            chk17.Click += Button_Edit_Click;
            chk18.Click += Button_Edit_Click;
            chk19.Click += Button_Edit_Click;
            chk20.Click += Button_Edit_Click;
            chk21.Click += Button_Edit_Click;
            chk22.Click += Button_Edit_Click;
            chk23.Click += Button_Edit_Click;
            switchButton_ControlHeadOFRep.Click += Button_Edit_Click;
            FlxInvoices.Click += Button_Edit_Click;
            FlxSetups.Click += Button_Edit_Click;
            FlxSRep.Click += Button_Edit_Click;
            dataGridViewX_GenralPre.Click += Button_Edit_Click;
            dataGridViewX_MenuPer.Click += Button_Edit_Click;
            dataGridViewX_MovePre.Click += Button_Edit_Click;
            dataGridViewX_RepPre.Click += Button_Edit_Click;
            dataGridViewX_SalPer.Click += Button_Edit_Click;
            dataGridViewX_HotelMenuPer.Click += Button_Edit_Click;
            dataGridViewX_HotelMovePre.Click += Button_Edit_Click;
            dataGridViewX_HotelRepPre.Click += Button_Edit_Click;
            dataGridViewX_HotelGenralPre.Click += Button_Edit_Click;
            dataGridViewX_EqarFiles.Click += Button_Edit_Click;
            dataGridViewX_GenralEqar.Click += Button_Edit_Click;
            dataGridViewX_RepEqar.Click += Button_Edit_Click;
            dataGridViewX_Tenants.Click += Button_Edit_Click;
            Combo1.Click += Button_Edit_Click;
            Combo3.Click += Button_Edit_Click;
            CmbCommTyp.Click += Button_Edit_Click;
            DGV_Main.PrimaryGrid.CheckBoxes = false;
            DGV_Main.PrimaryGrid.ShowCheckBox = false;
            DGV_Main.PrimaryGrid.ShowTreeButton = false;
            DGV_Main.PrimaryGrid.ShowTreeButtons = false;
            DGV_Main.PrimaryGrid.ShowTreeLines = false;
            DGV_Main.PrimaryGrid.RowHeaderWidth = 25;
            DGV_Main.MouseDown += DGV_Main_MouseDown;
            DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
            DGV_Main.CellClick += DGV_Main_CellClick;
            DGV_Main.GetCellStyle += DGV_MainGetCellStyle;
            DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
            DGV_Main.DataBindingComplete += DGV_Main_DataBindingComplete;
            expandableSplitter1.Click += expandableSplitter1_Click;
            ToolStripMenuItem_Det.Click += ToolStripMenuItem_Det_Click;
            Button_ExportTable2.Click += Button_ExportTable2_Click;
            DGV_Main.GetCellStyle += DGV_MainGetCellStyle;
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
            if (VarGeneral.SSSLev != "D" && VarGeneral.SSSLev != "E")
            {
                ribbonTabItem_Emps.Visible = false;
            }
            if (VarGeneral.SSSTyp == 0)
            {
                label14.Visible = false;
                CmbSendOption.Visible = false;
                if (VarGeneral.SSSLev == "M")
                {
                    chk4.Visible = false;
                    ribbonTabItem_ACC.Visible = false;
                }
                ribbonTabItem_RepAcc.Visible = false;
            }
            else if (VarGeneral.SSSTyp == 1)
            {
                ribbonTabItem_Inv.Visible = false;
                ribbonTabItem_Other.Visible = false;
            }
            if (VarGeneral.SSSLev != "H" && VarGeneral.SSSLev != "X")
            {
                ribbonTabItem_Hotels.Visible = false;
            }
            if (VarGeneral.SSSLev != "Q")
            {
                ribbonTabItem_Eqar.Visible = false;
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
            VarGeneral.SFrmTyp = "T_User";
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
            List<T_User> list = dbc.FillUsr_2(textBox_search.TextBox.Text).ToList();
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                }
            }
            FillHDGV(list);
        }
        public void FillHDGV(IEnumerable<T_User> new_data_enum)
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
            DGV_Main.PrimaryGrid.DataMember = "T_User";
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmUsr));
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
                label1.Text = "رقم المستخدم :";
                label2.Text = "كلمة المرور :";
                label3.Text = "تأكيد كلمة المرور :";
                label4.Text = "الإسم العربي :";
                label5.Text = "الإسم الانجليزي :";
                label6.Text = "الفرع الإفتراضي :";
                label7.Text = "حالة المستخدم :";
                label8.Text = "اللغة الافتراضية :";
                ribbonTabItem_General.Text = "عـــام";
                ribbonTabItem_ACC.Text = "الحسابات";
                ribbonTabItem_Files.Text = "الكروت";
                ribbonTabItem_Inv.Text = "الفواتير";
                ribbonTabItem_Other.Text = "أخرى";
                ribbonTabItem_RepAcc.Text = "تقارير الحسابات";
                ribbonTabItem_RepStocks.Text = "تقارير المخزون";
                ribbonTabItem_Emps.Text = "شؤون الموظفين";
                ribbonTabItem_Hotel.Text = "إدارة الفندق";
                MenuPer.Text = "الكـــروت";
                MenuPer.Tooltip = "إضغط هنا لعرض صلاحيات الكــروت";
                MovePre.Text = "الحركـــات";
                MovePre.Tooltip = "إضغط هنا لعرض صلاحيات الحــركــة";
                SalPer.Text = "عمليـــات الـــرواتب";
                SalPer.Tooltip = "إضغط هنا لعرض صلاحيات الــرواتــب";
                RepPre.Text = "التقـــارير";
                RepPre.Tooltip = "إضغط هنا لعرض صلاحيات التقـــارير";
                GenralPre.Text = "عـــــــام";
                GenralPre.Tooltip = "إضغط هنا لعرض الصلاحيــات العـامة";
                HotelMenuPer.Text = "الملفــــات";
                HotelMenuPer.Tooltip = "إضغط هنا لعرض صلاحيات الملفــــات";
                HotelMovePre.Text = "الحركـــات";
                HotelMovePre.Tooltip = "إضغط هنا لعرض صلاحيات الحــركــة";
                HotelRepPre.Text = "التقـــارير";
                HotelRepPre.Tooltip = "إضغط هنا لعرض صلاحيات التقـــارير";
                HotelGenralPre.Text = "عـــــــام";
                HotelGenralPre.Tooltip = "إضغط هنا لعرض الصلاحيــات العـامة";
                Text = "صلاحيات المستخدمين";
                buttonItem_SelectAll.Text = "تحديد الكل";
                buttonItem_UnSelectAll.Text = "إلغاء التحديد";
                switchButton_AdminOp.OffText = "مسؤول الموافقات";
                switchButton_AdminOp.OnText = "مسؤول الموافقات";
                chk11.Text = "موافقة تلقائية";
                groupPanel_InvoiceType.Text = "تغيير ورقة الطباعة حسب";
                groupPanel_Stores.Text = "ايقاف المستودع";
                switchButton_ControlHeadOFRep.OffText = "التحكم في الترويسة";
                switchButton_ControlHeadOFRep.OnText = "التحكم في الترويسة";
                if (VarGeneral.SSSTyp == 0)
                {
                    groupBox_Comm.Text = "نسبة عمولة المستخدم في المبيعات";
                }
                else if (VarGeneral.SSSTyp == 1)
                {
                    groupBox_Comm.Text = "نسبة عمولة المستخدم في الإيرادات";
                }
                else
                {
                    groupBox_Comm.Text = "نسبة عمولة المستخـــدم في";
                }
                groupPanel_Banner.Text = "صورة المستخدم";
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
                label1.Text = "User No :";
                label2.Text = "Password :";
                label3.Text = "Password Confirm :";
                label4.Text = "Name - Arabic :";
                label5.Text = "Name - English :";
                label6.Text = "Branch :";
                label7.Text = "User State :";
                label8.Text = "Language :";
                ribbonTabItem_General.Text = "General";
                ribbonTabItem_ACC.Text = "Accounts";
                ribbonTabItem_Files.Text = "Cards";
                ribbonTabItem_Inv.Text = "Invoices";
                ribbonTabItem_Other.Text = "Other";
                ribbonTabItem_RepAcc.Text = "Accounting Reports";
                ribbonTabItem_RepStocks.Text = "Inventory Reports";
                ribbonTabItem_Emps.Text = "Emp";
                ribbonTabItem_Hotel.Text = "Hotel";
                Text = "Users Permissions";
                buttonItem_SelectAll.Text = "Select All";
                buttonItem_UnSelectAll.Text = "UnSelect";
                switchButton_AdminOp.OffText = "Official approvals";
                switchButton_AdminOp.OnText = "Official approvals";
                switchButton_ControlHeadOFRep.OffText = "Control of Header";
                switchButton_ControlHeadOFRep.OnText = "Control of Header";
                if (VarGeneral.SSSTyp == 0)
                {
                    groupBox_Comm.Text = "Percentage commission user in Sales";
                }
                else if (VarGeneral.SSSTyp == 1)
                {
                    groupBox_Comm.Text = "Percentage commission user in Bounds";
                }
                else
                {
                    groupBox_Comm.Text = "Percentage commission user in";
                }
                chk11.Text = "Auto approval";
                groupPanel_InvoiceType.Text = "Change printing sheet by";
                groupPanel_Stores.Text = "Store Stop";
                groupPanel_Banner.Text = "User Pic";
            }
        }
        private void FrmUsr_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmUsr));
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    Language.ChangeLanguage("ar-SA", this, resources);
                    ribbonControl_Setting.RightToLeft = RightToLeft.Yes;
                    LangArEn = 0;
                }
                else
                {
                    Language.ChangeLanguage("en", this, resources);
                    ribbonControl_Setting.RightToLeft = RightToLeft.No;
                    LangArEn = 1;
                }
                ADD_Controls();
                if (VarGeneral.SSSTyp == 0)
                {
                    label2.Visible = false;
                    label10.Visible = false;
                    label3.Visible = false;
                    if (LangArEn == 1)
                    {
                        label9.Visible = false;
                    }
                    label11.Visible = false;
                    label12.Visible = false;
                    textBox_CommGaid.Visible = false;
                    textBox_CommInv.Width = 177;
                    textBox_CommInv.Location = new Point(30, 37);
                    Refresh();
                }
                else if (VarGeneral.SSSTyp == 1)
                {
                    label12.Visible = false;
                    label11.Visible = false;
                    label2.Visible = false;
                    label10.Visible = false;
                    label3.Visible = false;
                    if (LangArEn == 1)
                    {
                        label9.Visible = false;
                    }
                    textBox_CommInv.Visible = false;
                    textBox_CommGaid.Width = 177;
                    textBox_CommGaid.Location = new Point(30, 37);
                    groupBox1.Visible = false;
                    Refresh();
                }
                if (columns_Names_visible.Count == 0)
                {
                    columns_Names_visible.Add("UsrNo", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
                    columns_Names_visible.Add("UsrNamA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
                    columns_Names_visible.Add("UsrNamE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
                }
                else
                {
                    Clear();
                    textBox_ID.Text = "";
                    TextBox_Index.TextBox.Text = "";
                }
                listStore = db.FillStore_2("").ToList();
                FlxStkQty.Rows.Count = listStore.Count;
                for (int iiCnt = 0; iiCnt < listStore.Count; iiCnt++)
                {
                    _Store = listStore[iiCnt];
                    FlxStkQty.SetData(iiCnt, 0, _Store.Stor_ID.ToString());
                    FlxStkQty.SetData(iiCnt, 1, false);
                    FlxStkQty.SetData(iiCnt, 2, ((LangArEn == 0) ? _Store.Arb_Des : _Store.Eng_Des).ToString());
                }
                RefreshPKeys();
                FillFlex();
                FillCombo();
                textBox_ID.Text = PKeys.FirstOrDefault();
                ViewDetails_Click(sender, e);
                UpdateVcr();
                if (VarGeneral.vDemo && VarGeneral.UserID != 1)
                {
                    panel_Prices.Visible = false;
                }
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptTegnicalCollage.dll"))
                {
                    TegnicalCollage();
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void TegnicalCollage()
        {
            groupBox_Comm.Visible = false;
            label19.Visible = false;
            CmbCommTyp.Visible = false;
        }
        private void FillCombo()
        {
            int _CmbIndex = 0;
            RibunButtons();
            CmbInvPrice.Items.Clear();
            CmbInvPriceStop.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                CmbInvPrice.Items.Add("   ");
                CmbInvPrice.Items.Add("الإفتراضي فقط");
                CmbInvPrice.Items.Add("سعر الجملة");
                CmbInvPrice.Items.Add("سعر الموزع");
                CmbInvPrice.Items.Add("سعر المندوب");
                CmbInvPrice.Items.Add("سعر التجزئة");
                CmbInvPrice.Items.Add("سعر آخر");
                CmbInvPriceStop.Items.Add("   ");
                CmbInvPriceStop.Items.Add("الإفتراضي فقط");
                CmbInvPriceStop.Items.Add("سعر الجملة");
                CmbInvPriceStop.Items.Add("سعر الموزع");
                CmbInvPriceStop.Items.Add("سعر المندوب");
                CmbInvPriceStop.Items.Add("سعر التجزئة");
                CmbInvPriceStop.Items.Add("سعر آخر");
                Combo1.Items.Clear();
                Combo1.Items.Add("السعر الأول");
                Combo1.Items.Add("السعر الثاني");
                Combo1.SelectedIndex = 0;
                Combo3.Items.Clear();
                Combo3.Items.Add("السعر الأول");
                Combo3.Items.Add("السعر الثاني");
                Combo3.SelectedIndex = 0;
                CmbCommTyp.Items.Clear();
                CmbCommTyp.Items.Add("نسبة مئوية");
                CmbCommTyp.Items.Add("مبلغ ثابت");
                CmbCommTyp.SelectedIndex = 0;
            }
            else
            {
                CmbInvPrice.Items.Add("   ");
                CmbInvPrice.Items.Add("Only Default");
                CmbInvPrice.Items.Add("Wholesale price");
                CmbInvPrice.Items.Add("Distributor price");
                CmbInvPrice.Items.Add("Legates Price");
                CmbInvPrice.Items.Add("Retail price");
                CmbInvPrice.Items.Add("Other price");
                CmbInvPriceStop.Items.Add("   ");
                CmbInvPriceStop.Items.Add("Only Default");
                CmbInvPriceStop.Items.Add("Wholesale price");
                CmbInvPriceStop.Items.Add("Distributor price");
                CmbInvPriceStop.Items.Add("Legates Price");
                CmbInvPriceStop.Items.Add("Retail price");
                CmbInvPriceStop.Items.Add("Other price");
                Combo1.Items.Clear();
                Combo1.Items.Add("First Price");
                Combo1.Items.Add("Second Price");
                Combo1.SelectedIndex = 0;
                Combo3.Items.Clear();
                Combo3.Items.Add("First Price");
                Combo3.Items.Add("Second Price");
                Combo3.SelectedIndex = 0;
                CmbCommTyp.Items.Clear();
                CmbCommTyp.Items.Add("percent %");
                CmbCommTyp.Items.Add("fixed amount");
                CmbCommTyp.SelectedIndex = 0;
            }
            CmbInvPrice.SelectedIndex = _CmbIndex;
            CmbInvPriceStop.SelectedIndex = _CmbIndex;
            CmbSendOption.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                CmbSendOption.Items.Add("تحكم ذاتي");
                CmbSendOption.Items.Add("إرسال إيميل");
                CmbSendOption.Items.Add("إرسال رسالة نصية");
                CmbSendOption.Items.Add("الكل");
            }
            else
            {
                CmbSendOption.Items.Add("Self-control");
                CmbSendOption.Items.Add("Send Email");
                CmbSendOption.Items.Add("Send SMS");
                CmbSendOption.Items.Add("ALL");
            }
            CmbSendOption.SelectedIndex = 0;
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                _CmbIndex = CmbStatus.SelectedIndex;
                CmbStatus.Items.Clear();
                CmbStatus.Items.Add("يعمل");
                CmbStatus.Items.Add("إيقاف");
                CmbStatus.SelectedIndex = 0;
                _CmbIndex = CmbLanguge.SelectedIndex;
                CmbLanguge.Items.Clear();
                CmbLanguge.Items.Add("عربي");
                CmbLanguge.Items.Add("أنجليزي");
                CmbLanguge.SelectedIndex = 0;
                _CmbIndex = CmbBranch.SelectedIndex;
                List<T_Branch> listBranch = new List<T_Branch>(dbc.T_Branches.Select((T_Branch item) => item).ToList());
                CmbBranch.DataSource = listBranch;
                CmbBranch.DisplayMember = "Branch_Name";
                CmbBranch.ValueMember = "Branch_no";
                CmbBranch.SelectedIndex = _CmbIndex;
                _CmbIndex = CmbStores.SelectedIndex;
                List<T_Store> _StoresLst = new List<T_Store>(db.T_Stores.OrderBy((T_Store item) => item.Stor_ID).ToList());
                _StoresLst.Insert(0, new T_Store());
                CmbStores.DataSource = _StoresLst;
                CmbStores.DisplayMember = "Arb_Des";
                CmbStores.ValueMember = "Stor_ID";
                CmbStores.SelectedIndex = _CmbIndex;
                FlxFiles.SetData(0, 0, "*");
                FlxFiles.SetData(0, 1, "تفعيل");
                FlxFiles.SetData(0, 2, "إضافة");
                FlxFiles.SetData(0, 3, "تعديل");
                FlxFiles.SetData(0, 4, "حذف");
                FlxFiles.SetData(1, 0, "التصنيف");
                FlxFiles.SetData(2, 0, "تعريف صنف");
                FlxFiles.SetData(3, 0, "الوحدات");
                FlxFiles.SetData(4, 0, "العملات");
                FlxFiles.SetData(5, 0, "مركز التكلفة");
                FlxFiles.SetData(6, 0, "بيانات الفروع");
                FlxFiles.SetData(7, 0, "المندوبين");
                FlxFiles.SetData(8, 0, "المستودعات");
                FlxFiles.SetData(9, 0, "بيانات العملاء");
                FlxFiles.SetData(10, 0, "بيانات الموردين");
                FlxFiles.SetData(11, 0, "بيانات الموظفين");
                FlxFiles.SetData(12, 0, "نادل المطعم");
                FlxFiles.SetData(13, 0, "سائقين المطعم");
                FlxFiles.SetData(14, 0, "الإضافات الخاصة");
                FlxFiles.SetData(15, 0, "شاشة التنفيذ   ");
                if (VarGeneral.SSSTyp == 0)
                {
                    if (VarGeneral.SSSLev == "M")
                    {
                        FlxFiles.Rows[9].Visible = false;
                        FlxFiles.Rows[10].Visible = false;
                    }
                    FlxFiles.Rows[5].Visible = false;
                    FlxFiles.Rows[11].Visible = false;
                }
                else if (VarGeneral.SSSTyp == 1)
                {
                    FlxFiles.Rows[1].Visible = false;
                    FlxFiles.Rows[2].Visible = false;
                    FlxFiles.Rows[3].Visible = false;
                    FlxFiles.Rows[8].Visible = false;
                    FlxFiles.Rows[11].Visible = false;
                }
                if (VarGeneral.SSSLev == "D" || VarGeneral.SSSLev == "E")
                {
                    FlxFiles.Rows[11].Visible = false;
                }
                if (VarGeneral.SSSLev == "S")
                {
                    FlxFiles.Rows[5].Visible = false;
                }
                if (Program.iscarversion())
                {
                    FlxFiles.Rows[15].Visible = true;
                }
                else
                    FlxFiles.Rows[15].Visible = false;
                if (VarGeneral.SSSLev != "R" || VarGeneral.SSSLev == "C" || VarGeneral.SSSLev != "H")
                {
                    FlxFiles.Rows[12].Visible = false;
                    FlxFiles.Rows[13].Visible = false;
                    FlxFiles.Rows[14].Visible = false;
                }
                FlxInvoices.SetData(0, 0, "*");
                FlxInvoices.SetData(0, 1, "تفعيل");
                FlxInvoices.SetData(0, 2, "إضافة");
                FlxInvoices.SetData(0, 3, "تعديل");
                FlxInvoices.SetData(0, 4, "حذف");
                FlxInvoices.SetData(1, 0, "المبيعات");
                FlxInvoices.SetData(2, 0, "مرتجع المبيعات");
                FlxInvoices.SetData(3, 0, "المشتريات");
                FlxInvoices.SetData(4, 0, "مرتجع المشتريات");
                FlxInvoices.SetData(5, 0, "عرض سعر للعملاء");
                FlxInvoices.SetData(6, 0, "عرض سعر للموردين");
                FlxInvoices.SetData(7, 0, "طلب شراء");
                FlxInvoices.SetData(8, 0, "بضاعة اول المدة");
                FlxInvoices.SetData(9, 0, "إدخال بضاعة");
                FlxInvoices.SetData(10, 0, "إخراج بضاعة");
                FlxInvoices.SetData(11, 0, "صرف بضاعة");
                FlxInvoices.SetData(12, 0, "مرتجع صرف بضاعة");
                FlxInvoices.SetData(13, 0, "فاتورة تسوية البضاعة");
                FlxInvoices.SetData(14, 0, "العـــروض الخــاصــة");
                FlxAccounting.SetData(0, 0, "*");
                FlxAccounting.SetData(0, 1, "تفعيل");
                FlxAccounting.SetData(0, 2, "إضافة");
                FlxAccounting.SetData(0, 3, "تعديل");
                FlxAccounting.SetData(0, 4, "حذف");
                FlxAccounting.SetData(1, 0, "تصنيف الحسابات");
                FlxAccounting.SetData(2, 0, "كرت الحسابات");
                FlxAccounting.SetData(3, 0, "القيود اليومية");
                FlxAccounting.SetData(4, 0, "سند قبض");
                FlxAccounting.SetData(5, 0, "سند صرف");
                FlxAccounting.SetData(6, 0, "البنــوك");
                FlxAccounting.SetData(7, 0, "فــروع البنــوك");
                FlxAccounting.SetData(8, 0, "أوراق القبض والدفع");
                FlxAccounting.SetData(9, 0, "عمليات السحب والإيداع");
                FlxAccounting.SetData(10, 0, "إدارة الصناديق - الخزينة");
                if (VarGeneral.SSSTyp == 0)
                {
                    if (VarGeneral.SSSLev == "M")
                    {
                        FlxAccounting.Visible = false;
                    }
                    FlxAccounting.Rows[1].Visible = false;
                    FlxAccounting.Rows[2].Visible = false;
                    FlxAccounting.Rows[3].Visible = false;
                    FlxAccounting.Rows[6].Visible = false;
                    FlxAccounting.Rows[7].Visible = false;
                    FlxAccounting.Rows[8].Visible = false;
                    FlxAccounting.Rows[9].Visible = false;
                    FlxAccounting.Rows[10].Visible = false;
                }
                FlxAccounting.Rows[7].Visible = false;
                FlxSRep.SetData(0, 0, "*");
                FlxSRep.SetData(0, 1, "*");
                FlxSRep.SetData(0, 2, "تفعيل");
                FlxSRep.SetData(1, 1, "بيانات الأصناف");
                FlxSRep.SetData(2, 1, "بيانات الأصناف وكمياتها");
                FlxSRep.SetData(3, 1, "بيانات الأصناف وتكلفتها");
                FlxSRep.SetData(4, 1, "حركة صنف");
                FlxSRep.SetData(5, 1, "الأصناف بتاريخ الصلاحية وحركاتها");
                FlxSRep.SetData(6, 1, "الأصناف الواجب توفرها");
                FlxSRep.SetData(7, 1, "الأصناف الراكدة");
                FlxSRep.SetData(8, 1, "طباعة حركة صنف");
                FlxSRep.SetData(9, 1, "تقرير حركة صنف في فواتير المبيعات");
                FlxSRep.SetData(10, 1, "تقرير حركة صنف في فواتير مرتجع المبيعات");
                FlxSRep.SetData(11, 1, "تقرير حركة صنف في فواتير المشتريات");
                FlxSRep.SetData(12, 1, "تقرير حركة صنف في فواتير مرتجع المشتريات");
                FlxSRep.SetData(13, 1, "تقرير حركة صنف في فواتير عرض سعر العملاء");
                FlxSRep.SetData(14, 1, "تقرير حركة صنف في فواتير عرض سعر الموردين");
                FlxSRep.SetData(15, 1, "تقرير حركة صنف في فواتير امر الشراء");
                FlxSRep.SetData(16, 1, "تقرير حركة صنف في فواتير بضاعة اول المدة");
                FlxSRep.SetData(17, 1, "تقرير حركة صنف في فواتير إدخال بضاعة");
                FlxSRep.SetData(18, 1, "تقرير حركة صنف في فواتير إخراج بضاعة");
                FlxSRep.SetData(19, 1, "تقرير حركة صنف في فواتير صرف بضاعة");
                FlxSRep.SetData(20, 1, "تقرير حركة صنف في فواتير مرتجع صرف بضاعة");
                FlxSRep.SetData(21, 1, "تقرير حركة صنف في فواتير تسوية البضاعة");
                FlxSRep.SetData(22, 1, "أرصدة العملاء");
                FlxSRep.SetData(23, 1, "العملاء الراكدون");
                FlxSRep.SetData(24, 1, "ذمم العملاء");
                FlxSRep.SetData(25, 1, "أرصدة الموردين");
                FlxSRep.SetData(26, 1, "الموردين الراكدون");
                FlxSRep.SetData(27, 1, "ذمم الموردين");
                FlxSRep.SetData(28, 1, "البضاعة المصروفة - عميل");
                FlxSRep.SetData(29, 1, "البضاعة المصروفة - مـورد");
                FlxSRep.SetData(30, 1, "تقــريـر الفواتـــير");
                if (VarGeneral.SSSTyp == 1)
                {
                    ribbonTabItem_RepStocks.Text = "حركات العملاء والموردين";
                    FlxSRep.Rows[0].Visible = false;
                    FlxSRep.Rows[1].Visible = false;
                    FlxSRep.Rows[2].Visible = false;
                    FlxSRep.Rows[3].Visible = false;
                    FlxSRep.Rows[4].Visible = false;
                    FlxSRep.Rows[5].Visible = false;
                    FlxSRep.Rows[6].Visible = false;
                    FlxSRep.Rows[7].Visible = false;
                    FlxSRep.Rows[8].Visible = false;
                    FlxSRep.Rows[9].Visible = false;
                    FlxSRep.Rows[10].Visible = false;
                    FlxSRep.Rows[11].Visible = false;
                    FlxSRep.Rows[12].Visible = false;
                    FlxSRep.Rows[13].Visible = false;
                    FlxSRep.Rows[14].Visible = false;
                    FlxSRep.Rows[15].Visible = false;
                    FlxSRep.Rows[16].Visible = false;
                    FlxSRep.Rows[17].Visible = false;
                    FlxSRep.Rows[18].Visible = false;
                    FlxSRep.Rows[19].Visible = false;
                    FlxSRep.Rows[20].Visible = false;
                    FlxSRep.Rows[21].Visible = false;
                    FlxSRep.Rows[28].Visible = false;
                    FlxSRep.Rows[29].Visible = false;
                    FlxSRep.Rows[30].Visible = false;
                }
                FlxAccRep.SetData(0, 0, "*");
                FlxAccRep.SetData(0, 1, "تفعيل");
                FlxAccRep.SetData(1, 0, "كشف حساب تفصيلي");
                FlxAccRep.SetData(2, 0, "كشف بأكثر من حساب");
                FlxAccRep.SetData(3, 0, "كرت الحسابات");
                FlxAccRep.SetData(4, 0, "الأستاذ العام");
                FlxAccRep.SetData(5, 0, "اليومية العامة");
                FlxAccRep.SetData(6, 0, "ميزان مراجعة بالحركة");
                FlxAccRep.SetData(7, 0, "ميزان مراجعة بالأرصدة");
                FlxAccRep.SetData(8, 0, "ميزان مراجعة بالمجاميع");
                FlxAccRep.SetData(9, 0, "ميزان مراجعة بالأرصدة والمجاميع");
                FlxAccRep.SetData(10, 0, "حساب المتاجرة");
                FlxAccRep.SetData(11, 0, "حساب الأرباح والخسائر");
                FlxAccRep.SetData(12, 0, "الميزانية العمومية");
                FlxAccRep.SetData(13, 0, "تقريـر السندات المـاليـة");
                FlxAccRep.SetData(14, 0, "إحتساب الضريبة المستحقة");
                FlxSetups.SetData(0, 0, "*");
                FlxSetups.SetData(0, 1, "تفعيل");
                FlxSetups.SetData(1, 0, "تهيئة النظام");
                FlxSetups.SetData(2, 0, "الصلاحيات");
                FlxSetups.SetData(3, 0, "تغيير الفروع");
                FlxSetups.SetData(4, 0, "النسخ الأحتياطي للبيانات");
                FlxSetups.SetData(5, 0, "استرجاع قاعدة بيانات");
                FlxSetups.SetData(6, 0, "تعديل أسعار الصنف");
                FlxSetups.SetData(7, 0, "تنبيه حد الطلب");
                FlxSetups.SetData(8, 0, "تنبيه تاريخ انتهاء صلاحية الأصناف");
                FlxSetups.SetData(9, 0, "أقفال السنة");
                FlxSetups.SetData(10, 0, "تفعيل المنتج");
                FlxSetups.SetData(11, 0, "إعدادات طباعة الباركود");
                FlxSetups.SetData(12, 0, "إعدادات طباعة الفواتير");
                FlxSetups.SetData(13, 0, "إعدادات طباعة السندات");
                FlxSetups.SetData(14, 0, "إضافة قاعدة بيانات");
                FlxSetups.SetData(15, 0, "تغيير قاعدة البيانات");
                FlxSetups.SetData(16, 0, "قراءة بيانات مقفلة");
                FlxSetups.SetData(17, 0, "نقل البيانات بين الفروع");
                FlxSetups.SetData(18, 0, "تحصيل اوراق القبض والدفع");
                FlxSetups.SetData(19, 0, "رفض اوراق القبض والدفع");
                FlxSetups.SetData(20, 0, "التراجع عن سداد الورقة");
                FlxSetups.SetData(21, 0, "التراجع عن رفض الورقة");
                FlxSetups.SetData(22, 0, "ترحيل عملية السحب والإيداع");
                FlxSetups.SetData(23, 0, "التراجع عن ترحيل عملية السحب والإيداع");
                FlxSetups.SetData(24, 0, "ترحيل حسابات الصناديق - الخزينة");
                FlxSetups.SetData(25, 0, "السماح بترحيل حسابات الصناديق الفارغة");
                FlxSetups.SetData(26, 0, "انشاء الأرصدة الإفتتاحية");
                FlxSetups.SetData(27, 0, "الرسائل النصــية");
                FlxSetups.SetData(28, 0, "إصدار الرواتب");
                FlxSetups.SetData(29, 0, "ترحيل الرواتب");
                FlxSetups.SetData(30, 0, "التراجع عن ترحيل الرواتب");
                FlxSetups.SetData(31, 0, "طباعة مسي\u0651ر الرواتب");
                FlxSetups.SetData(32, 0, "تعيين مستخدمين نقاط البيع");
                FlxSetups.SetData(33, 0, "إزالة مستخدمين نقاط البيع");
                FlxSetups.SetData(34, 0, "إعادة ترقيم صناديق الكاشيير");
                FlxSetups.SetData(35, 0, "حذف قاعدة بيانات");
                FlxSetups.SetData(36, 0, "تقرير نسبة الشركاء من المبيعات");
                FlxSetups.SetData(37, 0, "تعيين السنة المالية");
                FlxSetups.SetData(38, 0, "تحديث اسعار تكلفة المشتريات");
                FlxSetups.SetData(39, 0, "تحديث اسعار تكلفة المبيعات");
                FlxSetups.SetData(40, 0, "التحكم في سيريالات الصنف");
                FlxSetups.SetData(41, 0, "التحكم في اعتمادات الطلبات المحلية");
                FlxSetups.SetData(42, 0, "إزالة الطلبات المحلية");
                FlxSetups.SetData(43, 0, "تحويل الطلبات بين الطاولات");
                FlxSetups.SetData(44, 0, "التحكم برقم الفاتورة يدويا\u0651");
                FlxSetups.SetData(45, 0, "تقارير بيانات نقاط العملاء");
                FlxSetups.SetData(46, 0, "إخفاء عمود السعر لفاتورة طلب شراء");
                FlxSetups.SetData(47, 0, "السماح بتعديل التكلفة يدويا\u064e في شاشة صيانة المشتريات");
                FlxSetups.SetData(48, 0, "استخدام عمليات الزيادة والنقصان في كرت الصنف");
                FlxSetups.SetData(49, 0, "تفعيل اجباري لخيار الباركود في المبيعات");
                FlxSetups.SetData(50, 0, "التحكم في حسابات الدفع في فواتير البيع والشراء");
                FlxSetups.SetData(51, 0, "تفعيل زر فتح الدرج لنقاط البيع");
                FlxSetups.SetData(52, 0, "السماح بعرض تقرير بالفواتير المحذوفة");
                FlxSetups.SetData(53, 0, "تعين المستخدم كمستخدم تابلت");
                if (VarGeneral.SSSTyp == 0)
                {
                    if (VarGeneral.SSSLev == "M")
                    {
                        FlxSetups.Rows[32].Visible = false;
                        FlxSetups.Rows[33].Visible = false;
                        FlxSetups.Rows[34].Visible = false;
                    }
                    FlxSetups.Rows[13].Visible = false;
                    FlxSetups.Rows[18].Visible = false;
                    FlxSetups.Rows[19].Visible = false;
                    FlxSetups.Rows[20].Visible = false;
                    FlxSetups.Rows[21].Visible = false;
                    FlxSetups.Rows[22].Visible = false;
                    FlxSetups.Rows[23].Visible = false;
                    FlxSetups.Rows[24].Visible = false;
                    FlxSetups.Rows[25].Visible = false;
                    FlxSetups.Rows[26].Visible = false;
                    FlxSetups.Rows[28].Visible = false;
                    FlxSetups.Rows[29].Visible = false;
                    FlxSetups.Rows[30].Visible = false;
                    FlxSetups.Rows[31].Visible = false;
                    FlxSetups.Rows[36].Visible = false;
                }
                else if (VarGeneral.SSSTyp == 1)
                {
                    FlxSetups.Rows[6].Visible = false;
                    FlxSetups.Rows[7].Visible = false;
                    FlxSetups.Rows[8].Visible = false;
                    FlxSetups.Rows[11].Visible = false;
                    FlxSetups.Rows[12].Visible = false;
                    FlxSetups.Rows[28].Visible = false;
                    FlxSetups.Rows[29].Visible = false;
                    FlxSetups.Rows[30].Visible = false;
                    FlxSetups.Rows[31].Visible = false;
                    FlxSetups.Rows[32].Visible = false;
                    FlxSetups.Rows[33].Visible = false;
                    FlxSetups.Rows[34].Visible = false;
                    FlxSetups.Rows[38].Visible = false;
                    FlxSetups.Rows[39].Visible = false;
                    FlxSetups.Rows[46].Visible = false;
                    FlxSetups.Rows[47].Visible = false;
                    FlxSetups.Rows[48].Visible = false;
                    FlxSetups.Rows[49].Visible = false;
                    FlxSetups.Rows[50].Visible = false;
                    FlxSetups.Rows[51].Visible = false;
                }
                if (VarGeneral.SSSLev == "D" || VarGeneral.SSSLev == "E")
                {
                    FlxSetups.Rows[28].Visible = false;
                    FlxSetups.Rows[29].Visible = false;
                    FlxSetups.Rows[30].Visible = false;
                    FlxSetups.Rows[31].Visible = false;
                }
                if (VarGeneral.SSSLev == "R" || VarGeneral.SSSLev == "C" || VarGeneral.SSSLev == "H")
                {
                    FlxSetups.Rows[41].Visible = true;
                    FlxSetups.Rows[42].Visible = true;
                    FlxSetups.Rows[43].Visible = true;
                }
                else
                {
                    FlxSetups.Rows[41].Visible = false;
                    FlxSetups.Rows[42].Visible = false;
                    FlxSetups.Rows[43].Visible = false;
                }
                if (Program.iscarversion())
                    FlxSetups.Rows[53].Visible = false;
                dataGridViewX_MenuPer.SetData(0, 0, "*");
                dataGridViewX_MenuPer.SetData(0, 1, "تفعيل");
                dataGridViewX_MenuPer.SetData(0, 2, "إضافة");
                dataGridViewX_MenuPer.SetData(0, 3, "تعديل");
                dataGridViewX_MenuPer.SetData(0, 4, "حذف");
                dataGridViewX_MenuPer.SetData(1, 0, "الموظفين");
                dataGridViewX_MenuPer.SetData(2, 0, "الإدارات");
                dataGridViewX_MenuPer.SetData(3, 0, "الأقســام");
                dataGridViewX_MenuPer.SetData(4, 0, "الوظــائف");
                dataGridViewX_MenuPer.SetData(5, 0, "الكفـــلاء");
                dataGridViewX_MenuPer.SetData(6, 0, "المشــاريع");
                dataGridViewX_MenuPer.SetData(7, 0, "الجنسيــات");
                dataGridViewX_MenuPer.SetData(8, 0, "أنواع العقــود");
                dataGridViewX_MenuPer.SetData(9, 0, "أنواع الإجـازات");
                dataGridViewX_MenuPer.SetData(10, 0, "المــدن");
                dataGridViewX_MenuPer.SetData(11, 0, "الــديـانـات");
                dataGridViewX_MenuPer.SetData(12, 0, "السيــارات");
                dataGridViewX_MenuPer.SetData(13, 0, "المعــامـلات");
                dataGridViewX_MovePre.SetData(0, 0, "*");
                dataGridViewX_MovePre.SetData(0, 1, "تفعيل");
                dataGridViewX_MovePre.SetData(0, 2, "إضافة");
                dataGridViewX_MovePre.SetData(0, 3, "تعديل");
                dataGridViewX_MovePre.SetData(0, 4, "حذف");
                dataGridViewX_MovePre.SetData(1, 0, "الإضافــي");
                dataGridViewX_MovePre.SetData(2, 0, "الخصـــــم");
                dataGridViewX_MovePre.SetData(3, 0, "الإجـــازات");
                dataGridViewX_MovePre.SetData(4, 0, "التذاكــــر");
                dataGridViewX_MovePre.SetData(5, 0, "السلفيـــات");
                dataGridViewX_MovePre.SetData(6, 0, "المكالمــــات");
                dataGridViewX_MovePre.SetData(7, 0, "الحوافز والمكافآت");
                dataGridViewX_MovePre.SetData(8, 0, "الإستئـــذان");
                dataGridViewX_MovePre.SetData(9, 0, "العهــــد");
                dataGridViewX_MovePre.SetData(10, 0, "تأشيرة الخروج والعودة");
                dataGridViewX_MovePre.SetData(11, 0, "نهاية الخدمة");
                dataGridViewX_MovePre.SetData(12, 0, "التعقــيب");
                dataGridViewX_SalPer.SetData(0, 0, "*");
                dataGridViewX_SalPer.SetData(0, 1, "تفعيل");
                dataGridViewX_SalPer.SetData(1, 0, "إصدار الرواتب");
                dataGridViewX_SalPer.SetData(2, 0, "ترحيل الرواتب");
                dataGridViewX_SalPer.SetData(3, 0, "إلغاء ترحيـــل الرواتب");
                dataGridViewX_SalPer.SetData(4, 0, "طباعة مسي\u0651ر الرواتب");
                dataGridViewX_SalPer.SetData(5, 0, "العمليات على الرواتب");
                dataGridViewX_SalPer.SetData(6, 0, "تقرير الزيادة والنقصان");
                dataGridViewX_SalPer.SetData(7, 0, "تقرير راتــــب الموظف");
                dataGridViewX_SalPer.SetData(8, 0, "تقرير تأمينات الموظف");
                dataGridViewX_SalPer.SetData(9, 0, "تعميـــــم الحســــابات");
                dataGridViewX_SalPer.SetData(10, 0, "انشاء قيد عند ترحيل الراتب");
                dataGridViewX_RepPre.SetData(0, 0, "*");
                dataGridViewX_RepPre.SetData(0, 1, "تفعيل");
                dataGridViewX_RepPre.SetData(1, 0, "تقرير الموظفين");
                dataGridViewX_RepPre.SetData(2, 0, "هويات الموظفين");
                dataGridViewX_RepPre.SetData(3, 0, "جوازات الموظفين");
                dataGridViewX_RepPre.SetData(4, 0, "إستمارات الموظفين");
                dataGridViewX_RepPre.SetData(5, 0, "رخــص الموظفين");
                dataGridViewX_RepPre.SetData(6, 0, "التأمين الصحي");
                dataGridViewX_RepPre.SetData(7, 0, "تجديـــد الوثائــق");
                dataGridViewX_RepPre.SetData(8, 0, "تجديد شركات التأمـين");
                dataGridViewX_RepPre.SetData(9, 0, "تقرير الإجازات");
                dataGridViewX_RepPre.SetData(10, 0, "تقرير التذاكر");
                dataGridViewX_RepPre.SetData(11, 0, "تقرير الإستئذان");
                dataGridViewX_RepPre.SetData(12, 0, "تقرير العهــــد");
                dataGridViewX_RepPre.SetData(13, 0, "تقرير تأشيرة الخروج والعودة");
                dataGridViewX_RepPre.SetData(14, 0, "تقرير نهاية الخدمة");
                dataGridViewX_RepPre.SetData(15, 0, "تقرير الإضافي");
                dataGridViewX_RepPre.SetData(16, 0, "تقرير الحوافز والمكافآت");
                dataGridViewX_RepPre.SetData(17, 0, "تقرير السلف");
                dataGridViewX_RepPre.SetData(18, 0, "تقرير المكالمــــات");
                dataGridViewX_RepPre.SetData(19, 0, "تقرير الخصم");
                dataGridViewX_RepPre.SetData(20, 0, "تقرير عمليات التعقيب");
                dataGridViewX_RepPre.SetData(21, 0, "تقرير السيارات");
                dataGridViewX_RepPre.SetData(22, 0, "تقرير الحضور والإنصراف");
                dataGridViewX_RepPre.SetData(23, 0, "فرز الموظف حسب المشروع");
                dataGridViewX_GenralPre.SetData(0, 0, "*");
                dataGridViewX_GenralPre.SetData(0, 1, "تفعيل");
                dataGridViewX_GenralPre.SetData(1, 0, "نظــام الـــدوام");
                dataGridViewX_GenralPre.SetData(2, 0, "تسجيل الحضور والإنصراف");
                dataGridViewX_GenralPre.SetData(3, 0, "الحضور والإنصراف اليدوي");
                dataGridViewX_GenralPre.SetData(4, 0, "استيراد بيانات الــدوام");
                dataGridViewX_GenralPre.SetData(5, 0, "تعميم أوقات الدوام");
                dataGridViewX_GenralPre.SetData(6, 0, "التعديل على الدوام");
                dataGridViewX_GenralPre.SetData(7, 0, "معالجة بيانات الدوام");
                dataGridViewX_GenralPre.SetData(8, 0, "ترحيل الإجازات");
                dataGridViewX_GenralPre.SetData(9, 0, "ترحيل التذاكر");
                dataGridViewX_GenralPre.SetData(10, 0, "ترحيل العهــــد");
                dataGridViewX_GenralPre.SetData(11, 0, "إستمارة الجوازات");
                dataGridViewX_GenralPre.SetData(12, 0, "تجديد وثائق الموظف");
                dataGridViewX_GenralPre.SetData(13, 0, "التحكم بموافقات الإجازات");
                dataGridViewX_HotelMenuPer.SetData(0, 0, "*");
                dataGridViewX_HotelMenuPer.SetData(0, 1, "تفعيل");
                dataGridViewX_HotelMenuPer.SetData(0, 2, "إضافة");
                dataGridViewX_HotelMenuPer.SetData(0, 3, "تعديل");
                dataGridViewX_HotelMenuPer.SetData(0, 4, "حذف");
                dataGridViewX_HotelMenuPer.SetData(1, 0, "أنواع الهويات");
                dataGridViewX_HotelMenuPer.SetData(2, 0, "الوظــائف");
                dataGridViewX_HotelMenuPer.SetData(3, 0, "أنواع الخدمات ");
                dataGridViewX_HotelMenuPer.SetData(4, 0, "الجنسيــات");
                dataGridViewX_HotelMovePre.SetData(0, 0, "*");
                dataGridViewX_HotelMovePre.SetData(0, 1, "تفعيل");
                dataGridViewX_HotelMovePre.SetData(0, 2, "إضافة");
                dataGridViewX_HotelMovePre.SetData(0, 3, "تعديل");
                dataGridViewX_HotelMovePre.SetData(0, 4, "حذف");
                dataGridViewX_HotelMovePre.SetData(1, 0, "تقديم خدمة للنزلاء");
                dataGridViewX_HotelMovePre.SetData(2, 0, "المكالمات الهاتفية");
                dataGridViewX_HotelMovePre.SetData(3, 0, "النزلاء المحظورين");
                dataGridViewX_HotelMovePre.SetData(4, 0, "بيانات غرف النزلاء");
                dataGridViewX_HotelMovePre.SetData(5, 0, "بيانات الحجوزات");
                dataGridViewX_HotelMovePre.SetData(6, 0, "سندات قبض النزلاء");
                dataGridViewX_HotelMovePre.SetData(7, 0, "سندات صرف النزلاء");
                dataGridViewX_HotelRepPre.SetData(0, 0, "*");
                dataGridViewX_HotelRepPre.SetData(0, 1, "تفعيل");
                dataGridViewX_HotelRepPre.SetData(1, 0, "كشف بإيراد اليوم - الإستقبال");
                dataGridViewX_HotelRepPre.SetData(2, 0, "تقرير ببيانات جميع النزلاء");
                dataGridViewX_HotelRepPre.SetData(3, 0, "كشف حساب النزلاء الحاجزين");
                dataGridViewX_HotelRepPre.SetData(4, 0, "كشف حساب النزلاء");
                dataGridViewX_HotelRepPre.SetData(5, 0, "كشف حساب نزيل");
                dataGridViewX_HotelRepPre.SetData(6, 0, "الخدمات المقدمة للنزلاء");
                dataGridViewX_HotelRepPre.SetData(7, 0, "حركة مكالمات النزلاء");
                dataGridViewX_HotelRepPre.SetData(8, 0, "كشف حساب غرفة خلال فترة");
                dataGridViewX_HotelRepPre.SetData(9, 0, "مواصفات الغرفة");
                dataGridViewX_HotelRepPre.SetData(10, 0, "حركة الغرف خلال فترة");
                dataGridViewX_HotelRepPre.SetData(11, 0, "صيانة الغرفة خلال فترة");
                dataGridViewX_HotelRepPre.SetData(12, 0, "نقل السكان خلال فترة");
                dataGridViewX_HotelGenralPre.SetData(0, 0, "*");
                dataGridViewX_HotelGenralPre.SetData(0, 1, "تفعيل");
                dataGridViewX_HotelGenralPre.SetData(1, 0, "نقل ساكن");
                dataGridViewX_HotelGenralPre.SetData(2, 0, "إضافة ملحق");
                dataGridViewX_HotelGenralPre.SetData(3, 0, "تغيير سعر الغرفة");
                dataGridViewX_HotelGenralPre.SetData(4, 0, "تغيير نوع السكن");
                dataGridViewX_HotelGenralPre.SetData(5, 0, "تغيير عدد الأيام المطلوبة");
                dataGridViewX_HotelGenralPre.SetData(6, 0, "مغادرة الغرفة");
                dataGridViewX_HotelGenralPre.SetData(7, 0, "تصليح الغرفة");
                dataGridViewX_HotelGenralPre.SetData(8, 0, "إنهاء التصليحات");
                dataGridViewX_HotelGenralPre.SetData(9, 0, "تنظيف الغرفة");
                dataGridViewX_HotelGenralPre.SetData(10, 0, "إنهاء التنظيفات");
                dataGridViewX_HotelGenralPre.SetData(11, 0, "بيانات الغرف");
                dataGridViewX_HotelGenralPre.SetData(12, 0, "أسعار المكالمات");
                dataGridViewX_HotelGenralPre.SetData(13, 0, "تعديل خدمات النزلاء المغادرين");
                dataGridViewX_HotelGenralPre.SetData(14, 0, "تعديل مكالمات النزلاء المغادرين");
                dataGridViewX_HotelGenralPre.SetData(15, 0, "القيود التلقائية بقيمة فترة الإقامة");
                if (VarGeneral.vDemo && VarGeneral.UserID != 1)
                {
                    dataGridViewX_HotelGenralPre.Rows[12].Visible = false;
                }
                dataGridViewX_EqarFiles.SetData(0, 0, "*");
                dataGridViewX_EqarFiles.SetData(0, 1, "تفعيل");
                dataGridViewX_EqarFiles.SetData(0, 2, "إضافة");
                dataGridViewX_EqarFiles.SetData(0, 3, "تعديل");
                dataGridViewX_EqarFiles.SetData(0, 4, "حذف");
                dataGridViewX_EqarFiles.SetData(1, 0, "المـــدن");
                dataGridViewX_EqarFiles.SetData(2, 0, "الجنسيـــات");
                dataGridViewX_EqarFiles.SetData(3, 0, "أنواع العقار");
                dataGridViewX_EqarFiles.SetData(4, 0, "طبيعة العقار");
                dataGridViewX_EqarFiles.SetData(5, 0, "العقــــــارات");
                dataGridViewX_EqarFiles.SetData(6, 0, "بيع عقـــار");
                dataGridViewX_EqarFiles.SetData(7, 0, "المـــــــــلاك");
                dataGridViewX_Tenants.SetData(0, 0, "*");
                dataGridViewX_Tenants.SetData(0, 1, "تفعيل");
                dataGridViewX_Tenants.SetData(0, 2, "إضافة");
                dataGridViewX_Tenants.SetData(0, 3, "تعديل");
                dataGridViewX_Tenants.SetData(0, 4, "حذف");
                dataGridViewX_Tenants.SetData(1, 0, "بيانات المستأجرين");
                dataGridViewX_Tenants.SetData(2, 0, "سند قبض مستأجر");
                dataGridViewX_Tenants.SetData(3, 0, "سند صرف مستأجر");
                dataGridViewX_Tenants.SetData(4, 0, "إشعارات المستأجرين");
                dataGridViewX_RepEqar.SetData(0, 0, "*");
                dataGridViewX_RepEqar.SetData(0, 1, "تفعيل");
                dataGridViewX_RepEqar.SetData(1, 0, "الإستعلامــــــات");
                dataGridViewX_RepEqar.SetData(2, 0, "كشف حساب المستأجرين");
                dataGridViewX_RepEqar.SetData(3, 0, "كشف حساب عقــــار");
                dataGridViewX_RepEqar.SetData(4, 0, "كشف حساب المـــلاك");
                dataGridViewX_RepEqar.SetData(5, 0, "كشف الحســـــاب");
                dataGridViewX_RepEqar.SetData(6, 0, "تقرير تحصيل الإيجار");
                dataGridViewX_RepEqar.Rows[4].Visible = false;
                dataGridViewX_RepEqar.Rows[5].Visible = false;
                dataGridViewX_GenralEqar.SetData(0, 0, "*");
                dataGridViewX_GenralEqar.SetData(0, 1, "تفعيل");
                dataGridViewX_GenralEqar.SetData(1, 0, "تصميم العقود");
            }
            else
            {
                _CmbIndex = CmbStatus.SelectedIndex;
                CmbStatus.Items.Clear();
                CmbStatus.Items.Add("ON");
                CmbStatus.Items.Add("Off");
                CmbStatus.SelectedIndex = 0;
                _CmbIndex = CmbLanguge.SelectedIndex;
                CmbLanguge.Items.Clear();
                CmbLanguge.Items.Add("Arabic");
                CmbLanguge.Items.Add("English");
                CmbLanguge.SelectedIndex = 0;
                _CmbIndex = CmbBranch.SelectedIndex;
                List<T_Branch> listBranch = new List<T_Branch>(dbc.T_Branches.Select((T_Branch item) => item).ToList());
                CmbBranch.DataSource = listBranch;
                CmbBranch.DisplayMember = "Branch_NameE";
                CmbBranch.ValueMember = "Branch_no";
                CmbBranch.SelectedIndex = _CmbIndex;
                _CmbIndex = CmbStores.SelectedIndex;
                List<T_Store> _StoresLst = new List<T_Store>(db.T_Stores.OrderBy((T_Store item) => item.Stor_ID).ToList());
                _StoresLst.Insert(0, new T_Store());
                CmbStores.DataSource = _StoresLst;
                CmbStores.DisplayMember = "Eng_Des";
                CmbStores.ValueMember = "Stor_ID";
                CmbStores.SelectedIndex = _CmbIndex;
                FlxFiles.SetData(0, 0, "*");
                FlxFiles.SetData(0, 1, "Activation");
                FlxFiles.SetData(0, 2, "Add");
                FlxFiles.SetData(0, 3, "Edit");
                FlxFiles.SetData(0, 4, "Delete");
                FlxFiles.SetData(1, 0, "Category");
                FlxFiles.SetData(2, 0, "Define Item");
                FlxFiles.SetData(3, 0, "Unit");
                FlxFiles.SetData(4, 0, "Currency");
                FlxFiles.SetData(5, 0, "Cost Center");
                FlxFiles.SetData(6, 0, "Branch");
                FlxFiles.SetData(7, 0, "Delegates");
                FlxFiles.SetData(8, 0, "Stores");
                FlxFiles.SetData(9, 0, "Customers");
                FlxFiles.SetData(10, 0, "Suppliers");
                FlxFiles.SetData(11, 0, "Employees");
                FlxFiles.SetData(12, 0, "Waiters");
                FlxFiles.SetData(13, 0, "Drivers");
                FlxFiles.SetData(14, 0, "Special Additions");
                FlxFiles.SetData(15, 0, "Execution Screen");
                if (VarGeneral.SSSTyp == 0)
                {
                    if (VarGeneral.SSSLev == "M")
                    {
                        FlxFiles.Rows[9].Visible = false;
                        FlxFiles.Rows[10].Visible = false;
                    }
                    FlxFiles.Rows[5].Visible = false;
                    FlxFiles.Rows[11].Visible = false;
                }
                else if (VarGeneral.SSSTyp == 1)
                {
                    FlxFiles.Rows[1].Visible = false;
                    FlxFiles.Rows[2].Visible = false;
                    FlxFiles.Rows[3].Visible = false;
                    FlxFiles.Rows[8].Visible = false;
                    FlxFiles.Rows[11].Visible = false;
                }
                if (VarGeneral.SSSLev == "D" || VarGeneral.SSSLev == "E")
                {
                    FlxFiles.Rows[11].Visible = false;
                }
                if (VarGeneral.SSSLev == "S")
                {
                    FlxFiles.Rows[5].Visible = false;
                }
                if (VarGeneral.SSSLev != "R" || VarGeneral.SSSLev == "C" || VarGeneral.SSSLev != "H")
                {
                    FlxFiles.Rows[12].Visible = false;
                    FlxFiles.Rows[13].Visible = false;
                    FlxFiles.Rows[14].Visible = false;
                }
                FlxInvoices.SetData(0, 0, "*");
                FlxInvoices.SetData(0, 1, "Activation");
                FlxInvoices.SetData(0, 2, "Add");
                FlxInvoices.SetData(0, 3, "Edit");
                FlxInvoices.SetData(0, 4, "Delete");
                FlxInvoices.SetData(1, 0, "Sales Invoice");
                FlxInvoices.SetData(2, 0, "Returns Sales Invoice");
                FlxInvoices.SetData(3, 0, "Purchase Invoice");
                FlxInvoices.SetData(4, 0, "Returns Purchase Invoice");
                FlxInvoices.SetData(5, 0, "Customer Qutation");
                FlxInvoices.SetData(6, 0, "Supplier Qutation");
                FlxInvoices.SetData(7, 0, "Purchase Order");
                FlxInvoices.SetData(8, 0, "Open Quantities");
                FlxInvoices.SetData(9, 0, "The introduction of goods");
                FlxInvoices.SetData(10, 0, "The Exiting of goods");
                FlxInvoices.SetData(11, 0, "Payment Order");
                FlxInvoices.SetData(12, 0, "Returns Payment Order");
                FlxInvoices.SetData(13, 0, "Settlement goods");
                FlxInvoices.SetData(14, 0, "Spicial Offers");
                FlxAccounting.SetData(0, 0, "*");
                FlxAccounting.SetData(0, 1, "Activation");
                FlxAccounting.SetData(0, 2, "Add");
                FlxAccounting.SetData(0, 3, "Edit");
                FlxAccounting.SetData(0, 4, "Delete");
                FlxAccounting.SetData(1, 0, "Classification of accounts");
                FlxAccounting.SetData(2, 0, "Accounting Card");
                FlxAccounting.SetData(3, 0, "Daily restrictions");
                FlxAccounting.SetData(4, 0, "Catch Bill");
                FlxAccounting.SetData(5, 0, "Exchange Bill");
                FlxAccounting.SetData(6, 0, "Banks");
                FlxAccounting.SetData(7, 0, "Branches of Banks");
                FlxAccounting.SetData(8, 0, "Peapers Catch and payment");
                FlxAccounting.SetData(9, 0, "Withdraw and deposit Opearations");
                FlxAccounting.SetData(10, 0, "Monetary fund");
                if (VarGeneral.SSSTyp == 0)
                {
                    if (VarGeneral.SSSLev == "M")
                    {
                        FlxAccounting.Visible = false;
                    }
                    FlxAccounting.Rows[1].Visible = false;
                    FlxAccounting.Rows[2].Visible = false;
                    FlxAccounting.Rows[3].Visible = false;
                    FlxAccounting.Rows[6].Visible = false;
                    FlxAccounting.Rows[7].Visible = false;
                    FlxAccounting.Rows[8].Visible = false;
                    FlxAccounting.Rows[9].Visible = false;
                    FlxAccounting.Rows[10].Visible = false;
                }
                FlxAccounting.Rows[7].Visible = false;
                FlxSRep.SetData(0, 0, "*");
                FlxSRep.SetData(0, 1, "*");
                FlxSRep.SetData(0, 2, "Activation");
                FlxSRep.SetData(1, 1, "Items Data");
                FlxSRep.SetData(2, 1, "Items Data And Quantity");
                FlxSRep.SetData(3, 1, "Item Data And Cost");
                FlxSRep.SetData(4, 1, "Item Movement");
                FlxSRep.SetData(5, 1, "Items With Date Expiration and Movements");
                FlxSRep.SetData(6, 1, "Items must be met");
                FlxSRep.SetData(7, 1, "Inactive Items");
                FlxSRep.SetData(8, 1, "Item Movement Printing");
                FlxSRep.SetData(9, 1, "Item Movement Report in Sales Invoice");
                FlxSRep.SetData(10, 1, "Item Movement Report in Returns Sales Invoice");
                FlxSRep.SetData(11, 1, "Item Movement Report in Purchase Invoice");
                FlxSRep.SetData(12, 1, "Item Movement Report in Returns Purchase Invoice");
                FlxSRep.SetData(13, 1, "Item Movement Report in Customer Qutation Invoice");
                FlxSRep.SetData(14, 1, "Item Movement Report in Supplier Qutation Invoice");
                FlxSRep.SetData(15, 1, "Item Movement Report in Purchase Order Invoice");
                FlxSRep.SetData(16, 1, "Item Movement Report in Open Quantities Invoice");
                FlxSRep.SetData(17, 1, "Item Movement Report in The introduction of goods");
                FlxSRep.SetData(18, 1, "Item Movement Report in The Exiting of goods");
                FlxSRep.SetData(19, 1, "Item Movement Report in Payment Order");
                FlxSRep.SetData(20, 1, "Item Movement Report in Returns Payment Order");
                FlxSRep.SetData(21, 1, "Item Movement Report in Settlement goods");
                FlxSRep.SetData(22, 1, "The customer balances");
                FlxSRep.SetData(23, 1, "Customers inactive");
                FlxSRep.SetData(24, 1, "Customers Acconuts");
                FlxSRep.SetData(25, 1, "The suppliers balances");
                FlxSRep.SetData(26, 1, "suppliers inactive");
                FlxSRep.SetData(27, 1, "suppliers Acconuts");
                FlxSRep.SetData(28, 1, "Goods Disbursed To Cust");
                FlxSRep.SetData(29, 1, "Goods Disbursed To Supp");
                FlxSRep.SetData(30, 1, "Invoices Report");
                if (VarGeneral.SSSTyp == 1)
                {
                    ribbonTabItem_RepStocks.Text = "Customers and Suppliers";
                    FlxSRep.Rows[0].Visible = false;
                    FlxSRep.Rows[1].Visible = false;
                    FlxSRep.Rows[2].Visible = false;
                    FlxSRep.Rows[3].Visible = false;
                    FlxSRep.Rows[4].Visible = false;
                    FlxSRep.Rows[5].Visible = false;
                    FlxSRep.Rows[6].Visible = false;
                    FlxSRep.Rows[7].Visible = false;
                    FlxSRep.Rows[8].Visible = false;
                    FlxSRep.Rows[9].Visible = false;
                    FlxSRep.Rows[10].Visible = false;
                    FlxSRep.Rows[11].Visible = false;
                    FlxSRep.Rows[12].Visible = false;
                    FlxSRep.Rows[13].Visible = false;
                    FlxSRep.Rows[14].Visible = false;
                    FlxSRep.Rows[15].Visible = false;
                    FlxSRep.Rows[16].Visible = false;
                    FlxSRep.Rows[17].Visible = false;
                    FlxSRep.Rows[18].Visible = false;
                    FlxSRep.Rows[19].Visible = false;
                    FlxSRep.Rows[20].Visible = false;
                    FlxSRep.Rows[21].Visible = false;
                    FlxSRep.Rows[28].Visible = false;
                    FlxSRep.Rows[29].Visible = false;
                    FlxSRep.Rows[30].Visible = false;
                }
                FlxAccRep.SetData(0, 0, "*");
                FlxAccRep.SetData(0, 1, "Activation");
                FlxAccRep.SetData(1, 0, "detailed account report");
                FlxAccRep.SetData(2, 0, "Report to more than one account");
                FlxAccRep.SetData(3, 0, "Card Accounts");
                FlxAccRep.SetData(4, 0, "General Ledger");
                FlxAccRep.SetData(5, 0, "General Daily");
                FlxAccRep.SetData(6, 0, "Balance of movement");
                FlxAccRep.SetData(7, 0, "Balance Trail Balance");
                FlxAccRep.SetData(8, 0, "Balance of aggregates");
                FlxAccRep.SetData(9, 0, "Balance of stocks and aggregates");
                FlxAccRep.SetData(10, 0, "Trading account");
                FlxAccRep.SetData(11, 0, "Profit and loss account");
                FlxAccRep.SetData(12, 0, "Balance Sheet");
                FlxAccRep.SetData(13, 0, "Bounds Report");
                FlxAccRep.SetData(14, 0, "Calculation of due tax");
                FlxSetups.SetData(0, 0, "*");
                FlxSetups.SetData(0, 1, "Activation");
                FlxSetups.SetData(1, 0, "System Setting");
                FlxSetups.SetData(2, 0, "Users");
                FlxSetups.SetData(3, 0, "Changing Branche");
                FlxSetups.SetData(4, 0, "Backup Data Base");
                FlxSetups.SetData(5, 0, "Restore Data Base");
                FlxSetups.SetData(6, 0, "Edite Items Prices");
                FlxSetups.SetData(7, 0, "Alert demand an end");
                FlxSetups.SetData(8, 0, "Alert expiration date Items");
                FlxSetups.SetData(9, 0, "End Years");
                FlxSetups.SetData(10, 0, "Activation Version");
                FlxSetups.SetData(11, 0, "Barcode Setting");
                FlxSetups.SetData(12, 0, "Invoice Setting");
                FlxSetups.SetData(13, 0, "Gaid Setting");
                FlxSetups.SetData(14, 0, "ADD New Data Base");
                FlxSetups.SetData(15, 0, "Change Data Base");
                FlxSetups.SetData(16, 0, "Read Data Closed");
                FlxSetups.SetData(17, 0, "Transfer Data Between Branches");
                FlxSetups.SetData(18, 0, "The collection of Peapers receivable and payment");
                FlxSetups.SetData(19, 0, "Rejection of Peapers receivable and payment");
                FlxSetups.SetData(20, 0, "Undo repayment paper");
                FlxSetups.SetData(21, 0, "Undo rejected paper");
                FlxSetups.SetData(22, 0, "Withdrawals and deposits deportation");
                FlxSetups.SetData(23, 0, "Withdrawals and deposits deportation Back");
                FlxSetups.SetData(24, 0, "Deportation fund accounts - Treasury");
                FlxSetups.SetData(25, 0, "Allowing the deportation of empty fund accounts");
                FlxSetups.SetData(26, 0, "Create Opened Balances");
                FlxSetups.SetData(27, 0, "Messages SMS");
                FlxSetups.SetData(28, 0, "Calculating salaries");
                FlxSetups.SetData(29, 0, "Relay salaries");
                FlxSetups.SetData(30, 0, "Undo Relay salaries");
                FlxSetups.SetData(31, 0, "Salaries Printing");
                FlxSetups.SetData(32, 0, "Set POS Users");
                FlxSetups.SetData(33, 0, "Delete POS Users");
                FlxSetups.SetData(34, 0, "Re numbering cashier boxes");
                FlxSetups.SetData(35, 0, "Data Base Delete");
                FlxSetups.SetData(36, 0, "Sales Partner Ratio Report");
                FlxSetups.SetData(37, 0, "The appointment of the fiscal year");
                FlxSetups.SetData(38, 0, "Update Cost Price of Purchaes");
                FlxSetups.SetData(39, 0, "Update Cost Price of Sales");
                FlxSetups.SetData(40, 0, "Control of Items Serials");
                FlxSetups.SetData(41, 0, "Control of Local Orders approval");
                FlxSetups.SetData(42, 0, "Remove Local Orders");
                FlxSetups.SetData(43, 0, "Transfer Orders Between Tables");
                FlxSetups.SetData(44, 0, "Manually control invoice number");
                FlxSetups.SetData(45, 0, "Points of Customers Reports");
                FlxSetups.SetData(46, 0, "Hide price column for purchase order invoice");
                FlxSetups.SetData(47, 0, "Allow manual cost on the Procurement Maintenance");
                FlxSetups.SetData(48, 0, "Use increases and decreases to items");
                FlxSetups.SetData(49, 0, "Activate the compulsory barcode option in sales");
                FlxSetups.SetData(50, 0, "Controlling Accounts Payable in Bills of Sale and Purchase");
                FlxSetups.SetData(51, 0, "Activate the button to open the POS box");
                FlxSetups.SetData(52, 0, "Allow to show deleted invoices");
                if (VarGeneral.SSSTyp == 0)
                {
                    if (VarGeneral.SSSLev == "M")
                    {
                        FlxSetups.Rows[32].Visible = false;
                        FlxSetups.Rows[33].Visible = false;
                        FlxSetups.Rows[34].Visible = false;
                    }
                    FlxSetups.Rows[13].Visible = false;
                    FlxSetups.Rows[18].Visible = false;
                    FlxSetups.Rows[19].Visible = false;
                    FlxSetups.Rows[20].Visible = false;
                    FlxSetups.Rows[21].Visible = false;
                    FlxSetups.Rows[22].Visible = false;
                    FlxSetups.Rows[23].Visible = false;
                    FlxSetups.Rows[24].Visible = false;
                    FlxSetups.Rows[25].Visible = false;
                    FlxSetups.Rows[26].Visible = false;
                    FlxSetups.Rows[28].Visible = false;
                    FlxSetups.Rows[29].Visible = false;
                    FlxSetups.Rows[30].Visible = false;
                    FlxSetups.Rows[31].Visible = false;
                    FlxSetups.Rows[36].Visible = false;
                }
                else if (VarGeneral.SSSTyp == 1)
                {
                    FlxSetups.Rows[6].Visible = false;
                    FlxSetups.Rows[7].Visible = false;
                    FlxSetups.Rows[8].Visible = false;
                    FlxSetups.Rows[11].Visible = false;
                    FlxSetups.Rows[12].Visible = false;
                    FlxSetups.Rows[28].Visible = false;
                    FlxSetups.Rows[29].Visible = false;
                    FlxSetups.Rows[30].Visible = false;
                    FlxSetups.Rows[31].Visible = false;
                    FlxSetups.Rows[32].Visible = false;
                    FlxSetups.Rows[33].Visible = false;
                    FlxSetups.Rows[34].Visible = false;
                    FlxSetups.Rows[38].Visible = false;
                    FlxSetups.Rows[39].Visible = false;
                    FlxSetups.Rows[46].Visible = false;
                    FlxSetups.Rows[47].Visible = false;
                    FlxSetups.Rows[48].Visible = false;
                    FlxSetups.Rows[49].Visible = false;
                    FlxSetups.Rows[50].Visible = false;
                    FlxSetups.Rows[51].Visible = false;
                }
                if (VarGeneral.SSSLev == "D" || VarGeneral.SSSLev == "E")
                {
                    FlxSetups.Rows[28].Visible = false;
                    FlxSetups.Rows[29].Visible = false;
                    FlxSetups.Rows[30].Visible = false;
                    FlxSetups.Rows[31].Visible = false;
                }
                if (VarGeneral.SSSLev == "R" || VarGeneral.SSSLev == "C" || VarGeneral.SSSLev == "H")
                {
                    FlxSetups.Rows[41].Visible = true;
                    FlxSetups.Rows[42].Visible = true;
                    FlxSetups.Rows[43].Visible = true;
                }
                else
                {
                    FlxSetups.Rows[41].Visible = false;
                    FlxSetups.Rows[42].Visible = false;
                    FlxSetups.Rows[43].Visible = false;
                }
                dataGridViewX_MenuPer.SetData(0, 0, "*");
                dataGridViewX_MenuPer.SetData(0, 1, "Activation");
                dataGridViewX_MenuPer.SetData(0, 2, "Add");
                dataGridViewX_MenuPer.SetData(0, 3, "Edit");
                dataGridViewX_MenuPer.SetData(0, 4, "Delete");
                dataGridViewX_MenuPer.SetData(1, 0, "Employee");
                dataGridViewX_MenuPer.SetData(2, 0, "Departments");
                dataGridViewX_MenuPer.SetData(3, 0, "Sections");
                dataGridViewX_MenuPer.SetData(4, 0, "Jobs");
                dataGridViewX_MenuPer.SetData(5, 0, "Sponsors");
                dataGridViewX_MenuPer.SetData(6, 0, "Projects");
                dataGridViewX_MenuPer.SetData(7, 0, "Nationalities");
                dataGridViewX_MenuPer.SetData(8, 0, "Contracts");
                dataGridViewX_MenuPer.SetData(9, 0, "Vacations Type");
                dataGridViewX_MenuPer.SetData(10, 0, "Cities");
                dataGridViewX_MenuPer.SetData(11, 0, "Religions");
                dataGridViewX_MenuPer.SetData(12, 0, "Cars");
                dataGridViewX_MenuPer.SetData(13, 0, "Treatments");
                dataGridViewX_MovePre.SetData(0, 0, "*");
                dataGridViewX_MovePre.SetData(0, 1, "Activation");
                dataGridViewX_MovePre.SetData(0, 2, "Add");
                dataGridViewX_MovePre.SetData(0, 3, "Edit");
                dataGridViewX_MovePre.SetData(0, 4, "Delete");
                dataGridViewX_MovePre.SetData(1, 0, "ADD");
                dataGridViewX_MovePre.SetData(2, 0, "Discount");
                dataGridViewX_MovePre.SetData(3, 0, "Vacations");
                dataGridViewX_MovePre.SetData(4, 0, "Tickets");
                dataGridViewX_MovePre.SetData(5, 0, "Advances");
                dataGridViewX_MovePre.SetData(6, 0, "Call");
                dataGridViewX_MovePre.SetData(7, 0, "Rewards");
                dataGridViewX_MovePre.SetData(8, 0, "Authorization");
                dataGridViewX_MovePre.SetData(9, 0, "Secretariats");
                dataGridViewX_MovePre.SetData(10, 0, "Visa Go And Back");
                dataGridViewX_MovePre.SetData(11, 0, "End Services");
                dataGridViewX_MovePre.SetData(12, 0, "Commentary");
                dataGridViewX_SalPer.SetData(0, 0, "*");
                dataGridViewX_SalPer.SetData(0, 1, "Activation");
                dataGridViewX_SalPer.SetData(1, 0, "Salaries Issuing");
                dataGridViewX_SalPer.SetData(2, 0, "Salaries Relay");
                dataGridViewX_SalPer.SetData(3, 0, "Cancel Salaries Relay");
                dataGridViewX_SalPer.SetData(4, 0, "Print Messier salaries");
                dataGridViewX_SalPer.SetData(5, 0, "Operation of Salaries");
                dataGridViewX_SalPer.SetData(6, 0, "increases and decreases Report");
                dataGridViewX_SalPer.SetData(7, 0, "Salary of Employee Report");
                dataGridViewX_SalPer.SetData(8, 0, "Allownce Employee");
                dataGridViewX_SalPer.SetData(9, 0, "Acconuns Generalization");
                dataGridViewX_SalPer.SetData(10, 0, "Create Gaid with Relay Salary");
                dataGridViewX_RepPre.SetData(0, 0, "*");
                dataGridViewX_RepPre.SetData(0, 1, "Activation");
                dataGridViewX_RepPre.SetData(1, 0, "Employee Report");
                dataGridViewX_RepPre.SetData(2, 0, "Employee ID");
                dataGridViewX_RepPre.SetData(3, 0, "Employee Passport");
                dataGridViewX_RepPre.SetData(4, 0, "Employee Forms");
                dataGridViewX_RepPre.SetData(5, 0, "Employee Licenses");
                dataGridViewX_RepPre.SetData(6, 0, "Employee Medical Allownce");
                dataGridViewX_RepPre.SetData(7, 0, "Update Documents");
                dataGridViewX_RepPre.SetData(8, 0, "Update Allownce Company");
                dataGridViewX_RepPre.SetData(9, 0, "Vacations Report");
                dataGridViewX_RepPre.SetData(10, 0, "Tickets Report");
                dataGridViewX_RepPre.SetData(11, 0, "Authorization Report");
                dataGridViewX_RepPre.SetData(12, 0, "Secretariats Report");
                dataGridViewX_RepPre.SetData(13, 0, "Visa Go And Back Report");
                dataGridViewX_RepPre.SetData(14, 0, "End Services Report");
                dataGridViewX_RepPre.SetData(15, 0, "Add Report");
                dataGridViewX_RepPre.SetData(16, 0, "Rewards Report");
                dataGridViewX_RepPre.SetData(17, 0, "Advances Report");
                dataGridViewX_RepPre.SetData(18, 0, "Call Report");
                dataGridViewX_RepPre.SetData(19, 0, "Discount Report");
                dataGridViewX_RepPre.SetData(20, 0, "Commentary Report");
                dataGridViewX_RepPre.SetData(21, 0, "Cars Report");
                dataGridViewX_RepPre.SetData(22, 0, "attend and leave Report");
                dataGridViewX_RepPre.SetData(23, 0, "Employee depend on Project");
                dataGridViewX_GenralPre.SetData(0, 0, "*");
                dataGridViewX_GenralPre.SetData(0, 1, "Activation");
                dataGridViewX_GenralPre.SetData(1, 0, "attend and Leave System");
                dataGridViewX_GenralPre.SetData(2, 0, "attend and Leave");
                dataGridViewX_GenralPre.SetData(3, 0, "attend and Leave Menual");
                dataGridViewX_GenralPre.SetData(4, 0, "Import attend and Leave Data");
                dataGridViewX_GenralPre.SetData(5, 0, "Generalization Attend and Leave");
                dataGridViewX_GenralPre.SetData(6, 0, "Edite Attend and Leave");
                dataGridViewX_GenralPre.SetData(7, 0, "Processing Attend and Leave");
                dataGridViewX_GenralPre.SetData(8, 0, "Relay Vacations");
                dataGridViewX_GenralPre.SetData(9, 0, "Relay Tickets");
                dataGridViewX_GenralPre.SetData(10, 0, "Relay Secretariats");
                dataGridViewX_GenralPre.SetData(11, 0, "Passport Forms");
                dataGridViewX_GenralPre.SetData(12, 0, "Update Documents");
                dataGridViewX_GenralPre.SetData(13, 0, "Approval of leave");
                dataGridViewX_HotelMenuPer.SetData(0, 0, "*");
                dataGridViewX_HotelMenuPer.SetData(0, 1, "Activation");
                dataGridViewX_HotelMenuPer.SetData(0, 2, "Add");
                dataGridViewX_HotelMenuPer.SetData(0, 3, "Edit");
                dataGridViewX_HotelMenuPer.SetData(0, 4, "Delete");
                dataGridViewX_HotelMenuPer.SetData(1, 0, "ID Types");
                dataGridViewX_HotelMenuPer.SetData(2, 0, "Jobs");
                dataGridViewX_HotelMenuPer.SetData(3, 0, "Services Types");
                dataGridViewX_HotelMenuPer.SetData(4, 0, "Nationalities");
                dataGridViewX_HotelMovePre.SetData(0, 0, "*");
                dataGridViewX_HotelMovePre.SetData(0, 1, "Activation");
                dataGridViewX_HotelMovePre.SetData(0, 2, "Add");
                dataGridViewX_HotelMovePre.SetData(0, 3, "Edit");
                dataGridViewX_HotelMovePre.SetData(0, 4, "Delete");
                dataGridViewX_HotelMovePre.SetData(1, 0, "Provide service");
                dataGridViewX_HotelMovePre.SetData(2, 0, "Phone calls");
                dataGridViewX_HotelMovePre.SetData(3, 0, "Black List");
                dataGridViewX_HotelMovePre.SetData(4, 0, "Guestroom data");
                dataGridViewX_HotelMovePre.SetData(5, 0, "Reservation data");
                dataGridViewX_HotelMovePre.SetData(6, 0, "Catch Bill For Guests");
                dataGridViewX_HotelMovePre.SetData(7, 0, "Exchange Bill For Guests");
                dataGridViewX_HotelRepPre.SetData(0, 0, "*");
                dataGridViewX_HotelRepPre.SetData(0, 1, "Activation");
                dataGridViewX_HotelRepPre.SetData(1, 0, "Daily Revenue");
                dataGridViewX_HotelRepPre.SetData(2, 0, "Guests Data");
                dataGridViewX_HotelRepPre.SetData(3, 0, "Report of inmates booking");
                dataGridViewX_HotelRepPre.SetData(4, 0, "Guest account report");
                dataGridViewX_HotelRepPre.SetData(5, 0, "Total guest account");
                dataGridViewX_HotelRepPre.SetData(6, 0, "Traffic service");
                dataGridViewX_HotelRepPre.SetData(7, 0, "Traffic Calls");
                dataGridViewX_HotelRepPre.SetData(8, 0, "Report room account");
                dataGridViewX_HotelRepPre.SetData(9, 0, "Room specifications");
                dataGridViewX_HotelRepPre.SetData(10, 0, "Movement of rooms");
                dataGridViewX_HotelRepPre.SetData(11, 0, "Maintenance of the room");
                dataGridViewX_HotelRepPre.SetData(12, 0, "Population transfer");
                dataGridViewX_HotelGenralPre.SetData(0, 0, "*");
                dataGridViewX_HotelGenralPre.SetData(0, 1, "Activation");
                dataGridViewX_HotelGenralPre.SetData(1, 0, "Transfer a guest");
                dataGridViewX_HotelGenralPre.SetData(2, 0, "Add Room");
                dataGridViewX_HotelGenralPre.SetData(3, 0, "Change Room Price");
                dataGridViewX_HotelGenralPre.SetData(4, 0, "Change Room Type");
                dataGridViewX_HotelGenralPre.SetData(5, 0, "Change Days Count");
                dataGridViewX_HotelGenralPre.SetData(6, 0, "Leave Room");
                dataGridViewX_HotelGenralPre.SetData(7, 0, "Room Maintenance");
                dataGridViewX_HotelGenralPre.SetData(8, 0, "End Of Room Maintenance");
                dataGridViewX_HotelGenralPre.SetData(9, 0, "Clear Room");
                dataGridViewX_HotelGenralPre.SetData(10, 0, "End of Clearing Room");
                dataGridViewX_HotelGenralPre.SetData(11, 0, "Room Data");
                dataGridViewX_HotelGenralPre.SetData(12, 0, "Call Rates");
                dataGridViewX_HotelGenralPre.SetData(13, 0, "Amendment of Departing Services");
                dataGridViewX_HotelGenralPre.SetData(14, 0, "Modify outgoing guest calls");
                dataGridViewX_HotelGenralPre.SetData(15, 0, "Auto Bound for stay Value");
                if (VarGeneral.vDemo && VarGeneral.UserID != 1)
                {
                    dataGridViewX_HotelGenralPre.Rows[12].Visible = false;
                }
                dataGridViewX_EqarFiles.SetData(0, 0, "*");
                dataGridViewX_EqarFiles.SetData(0, 1, "Activation");
                dataGridViewX_EqarFiles.SetData(0, 2, "Add");
                dataGridViewX_EqarFiles.SetData(0, 3, "Edit");
                dataGridViewX_EqarFiles.SetData(0, 4, "Delete");
                dataGridViewX_EqarFiles.SetData(1, 0, "Cities");
                dataGridViewX_EqarFiles.SetData(2, 0, "Nationalities");
                dataGridViewX_EqarFiles.SetData(3, 0, "Real estate Type");
                dataGridViewX_EqarFiles.SetData(4, 0, "Real estate Nature");
                dataGridViewX_EqarFiles.SetData(5, 0, "Real estate");
                dataGridViewX_EqarFiles.SetData(6, 0, "Real estate Sale");
                dataGridViewX_EqarFiles.SetData(7, 0, "Owners");
                dataGridViewX_Tenants.SetData(0, 0, "*");
                dataGridViewX_Tenants.SetData(0, 1, "Activation");
                dataGridViewX_Tenants.SetData(0, 2, "Add");
                dataGridViewX_Tenants.SetData(0, 3, "Edit");
                dataGridViewX_Tenants.SetData(0, 4, "Delete");
                dataGridViewX_Tenants.SetData(1, 0, "Tenant Data");
                dataGridViewX_Tenants.SetData(2, 0, "Tenant receipt voucher");
                dataGridViewX_Tenants.SetData(3, 0, "Tenant exchange voucher");
                dataGridViewX_Tenants.SetData(4, 0, "Tenant notices");
                dataGridViewX_RepEqar.SetData(0, 0, "*");
                dataGridViewX_RepEqar.SetData(0, 1, "Activation");
                dataGridViewX_RepEqar.SetData(1, 0, "Inquiries");
                dataGridViewX_RepEqar.SetData(2, 0, "Tenants' statement of account");
                dataGridViewX_RepEqar.SetData(3, 0, "Real estate account statement");
                dataGridViewX_RepEqar.SetData(4, 0, "Account statement of owners");
                dataGridViewX_RepEqar.SetData(5, 0, "Account detection");
                dataGridViewX_RepEqar.SetData(6, 0, "Rent collection report");
                dataGridViewX_RepEqar.Rows[4].Visible = false;
                dataGridViewX_RepEqar.Rows[5].Visible = false;
                dataGridViewX_GenralEqar.SetData(0, 0, "*");
                dataGridViewX_GenralEqar.SetData(0, 1, "Activation");
                dataGridViewX_GenralEqar.SetData(1, 0, "Contract design");
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptTegnicalCollage.dll"))
            {
                FlxFiles.SetData(7, 0, "الأســـاتذة");
                FlxFiles.SetData(9, 0, "الطــلاب");
                FlxInvoices.SetData(11, 0, "فاتورة اصدار عهدة");
                FlxInvoices.SetData(12, 0, "فاتورة إرجاع عهدة");
                FlxSRep.SetData(19, 1, "تقرير حركة صنف في فواتير اصدار عهدة");
                FlxSRep.SetData(20, 1, "تقرير حركة صنف في فواتير إرجاع عهدة");
                FlxSRep.SetData(28, 1, "البضاعة المصروفة - طالب");
                FlxFiles.Rows[12].Visible = false;
                FlxFiles.Rows[13].Visible = false;
                FlxFiles.Rows[14].Visible = false;
                FlxInvoices.Rows[1].Visible = false;
                FlxInvoices.Rows[2].Visible = false;
                FlxInvoices.Rows[5].Visible = false;
                FlxInvoices.Rows[6].Visible = false;
                FlxInvoices.Rows[9].Visible = false;
                FlxInvoices.Rows[10].Visible = false;
                FlxInvoices.Rows[14].Visible = false;
                FlxSRep.Rows[5].Visible = false;
                FlxSRep.Rows[6].Visible = false;
                FlxSRep.Rows[7].Visible = false;
                FlxSRep.Rows[9].Visible = false;
                FlxSRep.Rows[10].Visible = false;
                FlxSRep.Rows[11].Visible = false;
                FlxSRep.Rows[13].Visible = false;
                FlxSRep.Rows[14].Visible = false;
                FlxSRep.Rows[17].Visible = false;
                FlxSRep.Rows[18].Visible = false;
                FlxSRep.Rows[22].Visible = false;
                FlxSRep.Rows[23].Visible = false;
                FlxSRep.Rows[24].Visible = false;
                FlxSRep.Rows[25].Visible = false;
                FlxSRep.Rows[26].Visible = false;
                FlxSRep.Rows[27].Visible = false;
                FlxSetups.Rows[7].Visible = false;
                FlxSetups.Rows[8].Visible = false;
                FlxSetups.Rows[17].Visible = false;
                FlxSetups.Rows[32].Visible = false;
                FlxSetups.Rows[33].Visible = false;
                FlxSetups.Rows[34].Visible = false;
                FlxSetups.Rows[39].Visible = false;
                FlxSetups.Rows[40].Visible = false;
                FlxSetups.Rows[41].Visible = false;
                FlxSetups.Rows[42].Visible = false;
                FlxSetups.Rows[43].Visible = false;
                FlxSetups.Rows[45].Visible = false;
                FlxSetups.Rows[46].Visible = false;
                FlxSetups.Rows[47].Visible = false;
                ribbonTabItem_ACC.Visible = false;
                FlexType.Rows[0].Visible = false;
                FlexType.Rows[1].Visible = false;
                FlexType.Rows[4].Visible = false;
                FlexType.Rows[5].Visible = false;
                FlexType.Rows[8].Visible = false;
                FlexType.Rows[9].Visible = false;
                FlexType.SetData(10, 1, "فاتورة إصدار عهدة");
                FlexType.SetData(11, 1, "فاتورة إرجاع عهدة");
                if (VarGeneral.UserID != 1)
                {
                    ribbonTabItem_Other.Visible = false;
                }
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptWaterPackages.dll"))
            {
                FlxInvoices.Rows[11].Visible = false;
                FlxInvoices.Rows[12].Visible = false;
                FlxInvoices.Rows[14].Visible = false;
                FlxSRep.Rows[19].Visible = false;
                FlxSRep.Rows[20].Visible = false;
                FlexType.Rows[10].Visible = false;
                FlexType.Rows[11].Visible = false;
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
                T_User newData = dbc.RateUsr(no.ToString());
                if (newData == null || newData.Usr_ID == 0)
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
                    int indexA = PKeys.IndexOf(newData.UsrNo ?? "");
                    indexA++;
                    TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                    TextBox_Index.TextBox.Text = string.Concat(indexA);
                    TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                }
                try
                {
                    if (textBox_ID.Text == "1" || data_this.Usr_ID == 1)
                    {
                        IfDelete = false;
                        ribbonBar1.Enabled = false;
                    }
                    else
                    {
                        ribbonBar1.Enabled = true;
                        IfDelete = true;
                    }
                }
                catch
                {
                    IfDelete = false;
                    ribbonBar1.Enabled = false;
                }
                try
                {
                    if (textBox_ID.Text == "2" || data_this.Usr_ID == 2)
                    {
                        ifOkDelete = false;
                        return;
                    }
                }
                catch
                {
                    ifOkDelete = false;
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
            data_this = new T_User();
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
                else if (controls[i].GetType() == typeof(CheckBox) || controls.GetType() == typeof(CheckBoxX))
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
            PicItemImg.Image = null;
            switchButton_ControlHeadOFRep.Value = false;
            chk11.Checked = false;
            switchButton_AdminOp.Value = false;
            CmbLanguge.SelectedIndex = 0;
            CmbStatus.SelectedIndex = 0;
            CmbBranch.SelectedIndex = 0;
            CmbInvPrice.SelectedIndex = 0;
            CmbInvPriceStop.SelectedIndex = 0;
            CmbSendOption.SelectedIndex = 0;
            CmbCommTyp.SelectedIndex = 0;
            CmbStores.SelectedIndex = 0;
            textBox_ID.Focus();
            for (int i = 0; i < FlexType.Rows.Count; i++)
            {
                try
                {
                    FlexType.SetData(i, 0, false);
                }
                catch
                {
                }
            }
            for (int iiCnt = 0; iiCnt < listStore.Count; iiCnt++)
            {
                try
                {
                    FlxStkQty.SetData(iiCnt, 1, false);
                }
                catch
                {
                }
            }
            SetReadOnly = false;
        }
        public void SetData(T_User value)
        {
            try
            {
                State = FormState.Saved;
                Button_Save.Enabled = false;
                int iiCnt = 0;
                textBox_ID.Tag = value.Usr_ID.ToString();
                txtUserName.Text = value.UsrNamA;
                txtUserNameE.Text = value.UsrNamE;
                txtPass.Text = VarGeneral.Decrypt(value.Pass);
                txtPassConf.Text = VarGeneral.Decrypt(value.Pass);
                switchButton_AdminOp.Value = VarGeneral.TString.ChkStatShow(value.RepInv1, 0);
                textBox_CommInv.Value = value.Comm_Inv.Value;
                textBox_CommGaid.Value = value.Comm_Gaid.Value;
                textBox_MaxDis.Value = value.MaxDiscountSals.Value;
                for (iiCnt = 0; iiCnt < CmbBranch.Items.Count; iiCnt++)
                {
                    CmbBranch.SelectedIndex = iiCnt;
                    if (CmbBranch.SelectedValue != null && CmbBranch.SelectedValue.ToString() == value.Brn)
                    {
                        break;
                    }
                }
                CmbLanguge.SelectedIndex = value.ProLng.Value;
                CmbStatus.SelectedIndex = value.Sts.Value;
                try
                {
                    if (value.DefStores.HasValue)
                    {
                        if (value.DefStores.Value > 0)
                        {
                            CmbStores.SelectedValue = value.DefStores.Value;
                        }
                        else
                        {
                            CmbStores.SelectedIndex = 0;
                        }
                    }
                }
                catch
                {
                    CmbStores.SelectedIndex = 0;
                }
                try
                {
                    CmbCommTyp.SelectedIndex = int.Parse(value.RepInv6);
                }
                catch
                {
                    CmbCommTyp.SelectedIndex = 0;
                }
                try
                {
                    CmbInvPrice.SelectedIndex = int.Parse(value.RepInv2.Trim());
                }
                catch
                {
                    CmbInvPrice.SelectedIndex = 0;
                }
                try
                {
                    CmbSendOption.SelectedIndex = int.Parse(value.RepInv3.Trim());
                }
                catch
                {
                    CmbSendOption.SelectedIndex = 0;
                }
                try
                {
                    CmbInvPriceStop.SelectedIndex = int.Parse(value.RepInv4.Trim());
                }
                catch
                {
                    CmbInvPriceStop.SelectedIndex = 0;
                }
                if (value.UsrImg != null)
                {
                    byte[] arr = value.UsrImg.ToArray();
                    MemoryStream stream = new MemoryStream(arr);
                    PicItemImg.Image = Image.FromStream(stream);
                }
                else
                {
                    PicItemImg.Image = null;
                }
                int Rat = 0;
                for (iiCnt = 1; iiCnt < FlxFiles.Rows.Count; iiCnt++)
                {
                    for (int I = 1; I < 5; I++)
                    {
                        if (FlxFiles.GetData(iiCnt, 0).ToString().Contains("تنفيذ"))
                        {
                        }
                        FlxFiles.SetData(iiCnt, I, VarGeneral.TString.ChkStatShow(value.FilStr, Rat));
                        Rat++;
                    }
                }
                Rat = 0;
                for (iiCnt = 1; iiCnt < FlxAccounting.Rows.Count; iiCnt++)
                {
                    for (int I = 1; I < 5; I++)
                    {
                        FlxAccounting.SetData(iiCnt, I, VarGeneral.TString.ChkStatShow(value.SndStr, Rat));
                        Rat++;
                    }
                }
                Rat = 0;
                for (iiCnt = 1; iiCnt < FlxInvoices.Rows.Count; iiCnt++)
                {
                    for (int I = 1; I < 5; I++)
                    {
                        FlxInvoices.SetData(iiCnt, I, VarGeneral.TString.ChkStatShow(value.InvStr, Rat));
                        Rat++;
                    }
                }
                for (iiCnt = 1; iiCnt < FlxInvoices.Rows.Count; iiCnt++)
                {
                    for (int I = 5; I < 6; I++)
                    {
                        FlxInvoices.SetData(iiCnt, I, VarGeneral.TString.ChkStatShow(value.InvStr, Rat));
                        Rat++;
                    }
                }
                Rat = 0;
                for (iiCnt = 1; iiCnt < FlxSRep.Rows.Count; iiCnt++)
                {
                    FlxSRep.SetData(iiCnt, 2, VarGeneral.TString.ChkStatShow(value.StkRep, Rat));
                    Rat++;
                }
                Rat = 0;
                for (iiCnt = 1; iiCnt < FlxAccRep.Rows.Count; iiCnt++)
                {
                    FlxAccRep.SetData(iiCnt, 1, VarGeneral.TString.ChkStatShow(value.AccRep, Rat));
                    Rat++;
                }
                Rat = 0;
                for (iiCnt = 1; iiCnt < FlxSetups.Rows.Count; iiCnt++)
                {
                    FlxSetups.SetData(iiCnt, 1, VarGeneral.TString.ChkStatShow(value.SetStr, Rat));
                    Rat++;
                }
                chk1.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 0);
                chk2.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 1);
                chk3.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 2);
                chk4.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 3);
                chk5.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 4);
                chk6.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 5);
                chk7.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 6);
                chk8.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 7);
                chk9.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 8);
                chk10.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 9);
                chk11.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 10);
                chk12.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 11);
                chk14.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 12);
                chk15.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 13);
                chk17.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 14);
                chk18.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 15);
                chk19.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 16);
                chk20.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 17);
                chk21.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 18);
                chk23.Checked = VarGeneral.TString.ChkStatShow(value.PassQty, 19);
                Rat = 0;
                for (iiCnt = 1; iiCnt < dataGridViewX_MenuPer.Rows.Count; iiCnt++)
                {
                    for (int I = 1; I < 5; I++)
                    {
                        dataGridViewX_MenuPer.SetData(iiCnt, I, VarGeneral.TString.ChkStatShow(value.Emp_FilStr, Rat));
                        Rat++;
                    }
                }
                Rat = 0;
                for (iiCnt = 1; iiCnt < dataGridViewX_MovePre.Rows.Count; iiCnt++)
                {
                    for (int I = 1; I < 5; I++)
                    {
                        dataGridViewX_MovePre.SetData(iiCnt, I, VarGeneral.TString.ChkStatShow(value.Emp_MovStr, Rat));
                        Rat++;
                    }
                }
                Rat = 0;
                for (iiCnt = 1; iiCnt < dataGridViewX_SalPer.Rows.Count; iiCnt++)
                {
                    dataGridViewX_SalPer.SetData(iiCnt, 1, VarGeneral.TString.ChkStatShow(value.Emp_SalStr, Rat));
                    Rat++;
                }
                Rat = 0;
                for (iiCnt = 1; iiCnt < dataGridViewX_RepPre.Rows.Count; iiCnt++)
                {
                    dataGridViewX_RepPre.SetData(iiCnt, 1, VarGeneral.TString.ChkStatShow(value.Emp_RepStr, Rat));
                    Rat++;
                }
                Rat = 0;
                for (iiCnt = 1; iiCnt < dataGridViewX_GenralPre.Rows.Count; iiCnt++)
                {
                    dataGridViewX_GenralPre.SetData(iiCnt, 1, VarGeneral.TString.ChkStatShow(value.Emp_GenStr, Rat));
                    Rat++;
                }
                Rat = 0;
                for (iiCnt = 1; iiCnt < dataGridViewX_HotelMenuPer.Rows.Count; iiCnt++)
                {
                    for (int I = 1; I < 5; I++)
                    {
                        dataGridViewX_HotelMenuPer.SetData(iiCnt, I, VarGeneral.TString.ChkStatShow(value.RepAcc1, Rat));
                        Rat++;
                    }
                }
                Rat = 0;
                for (iiCnt = 1; iiCnt < dataGridViewX_HotelMovePre.Rows.Count; iiCnt++)
                {
                    for (int I = 1; I < 5; I++)
                    {
                        dataGridViewX_HotelMovePre.SetData(iiCnt, I, VarGeneral.TString.ChkStatShow(value.RepAcc2, Rat));
                        Rat++;
                    }
                }
                Rat = 0;
                for (iiCnt = 1; iiCnt < dataGridViewX_HotelRepPre.Rows.Count; iiCnt++)
                {
                    dataGridViewX_HotelRepPre.SetData(iiCnt, 1, VarGeneral.TString.ChkStatShow(value.RepAcc3, Rat));
                    Rat++;
                }
                Rat = 0;
                for (iiCnt = 1; iiCnt < dataGridViewX_HotelGenralPre.Rows.Count; iiCnt++)
                {
                    dataGridViewX_HotelGenralPre.SetData(iiCnt, 1, VarGeneral.TString.ChkStatShow(value.RepAcc4, Rat));
                    Rat++;
                }
                Combo1.SelectedIndex = int.Parse(value.RepAcc5);
                Combo3.SelectedIndex = int.Parse(value.RepAcc6);
                try
                {
                    if (value.RepInv5 == "1")
                    {
                        chk13.Checked = true;
                    }
                    else
                    {
                        chk13.Checked = false;
                    }
                }
                catch
                {
                    chk13.Checked = false;
                }
                for (int i = 0; i < FlexType.Rows.Count; i++)
                {
                    try
                    {
                        FlexType.SetData(i, 0, VarGeneral.TString.ChkStatShow(value.PeaperTyp, i));
                    }
                    catch
                    {
                        FlexType.SetData(i, 0, false);
                    }
                }
                switchButton_ControlHeadOFRep.Value = VarGeneral.TString.ChkStatShow(value.StopBanner, 0);
                chk16.Checked = VarGeneral.TString.ChkStatShow(value.StopBanner, 1);
                chk22.Checked = VarGeneral.TString.ChkStatShow(value.StopBanner, 2);
                for (int j = 0; j < listStore.Count; j++)
                {
                    try
                    {
                        FlxStkQty.SetData(j, 1, false);
                    }
                    catch
                    {
                    }
                }
                List<string> _StorePr = value.StorePrmission.Split(',').ToList();
                for (int c = 0; c < _StorePr.Count; c++)
                {
                    if (string.IsNullOrEmpty(_StorePr[c]))
                    {
                        continue;
                    }
                    for (int i = 0; i < FlxStkQty.Rows.Count; i++)
                    {
                        try
                        {
                            if (FlxStkQty.Rows[i][0].ToString() == _StorePr[c])
                            {
                                FlxStkQty.SetData(i, 1, true);
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                Rat = 0;
                for (iiCnt = 1; iiCnt < dataGridViewX_EqarFiles.Rows.Count; iiCnt++)
                {
                    for (int I = 1; I < 5; I++)
                    {
                        dataGridViewX_EqarFiles.SetData(iiCnt, I, VarGeneral.TString.ChkStatShow(value.Eqar_FilStr, Rat));
                        Rat++;
                    }
                }
                Rat = 0;
                for (iiCnt = 1; iiCnt < dataGridViewX_Tenants.Rows.Count; iiCnt++)
                {
                    for (int I = 1; I < 5; I++)
                    {
                        dataGridViewX_Tenants.SetData(iiCnt, I, VarGeneral.TString.ChkStatShow(value.Eqar_TenantStr, Rat));
                        Rat++;
                    }
                }
                Rat = 0;
                for (iiCnt = 1; iiCnt < dataGridViewX_RepEqar.Rows.Count; iiCnt++)
                {
                    dataGridViewX_RepEqar.SetData(iiCnt, 1, VarGeneral.TString.ChkStatShow(value.Eqar_RepStr, Rat));
                    Rat++;
                }
                Rat = 0;
                for (iiCnt = 1; iiCnt < dataGridViewX_GenralEqar.Rows.Count; iiCnt++)
                {
                    dataGridViewX_GenralEqar.SetData(iiCnt, 1, VarGeneral.TString.ChkStatShow(value.Eqar_GenStr, Rat));
                    Rat++;
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
        private void button_EnterImg_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|TIFF Files (*.tiff)|*.tiff|BMP Files (*.bmp)|*.bmp";
                try
                {
                    if (VarGeneral.gUserName == "runsetting")
                    {
                        openFileDialog1.InitialDirectory = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
                    }
                }
                catch
                {
                }
                openFileDialog1.ShowDialog();
                string mypic_path = openFileDialog1.FileName;
                if (File.Exists(mypic_path))
                {
                    if (txtWidth.LockUpdateChecked && txtHeight.LockUpdateChecked)
                    {
                        PicItemImg.Image = resizeImage(Image.FromFile(mypic_path), new Size(txtWidth.Value, txtHeight.Value));
                    }
                    else
                    {
                        PicItemImg.Image = Image.FromFile(mypic_path);
                    }
                    Bitmap OriginalBM = new Bitmap(PicItemImg.Image);
                    PicItemImg.Image = OriginalBM;
                }
                Button_Edit_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button_ClearPic_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            PicItemImg.Image = null;
        }
        private T_User GetData()
        {
            textBox_ID.Focus();
            data_this.UsrNo = textBox_ID.Text;
            data_this.UsrNamA = txtUserName.Text;
            data_this.UsrNamE = txtUserNameE.Text;
            data_this.Pass = VarGeneral.Encrypt(txtPass.Text);
            data_this.Brn = CmbBranch.SelectedValue.ToString();
            data_this.ProLng = CmbLanguge.SelectedIndex;
            if (CmbStores.SelectedIndex > 0)
            {
                data_this.DefStores = int.Parse(CmbStores.SelectedValue.ToString());
            }
            else
            {
                data_this.DefStores = 0;
            }
            data_this.RepInv6 = CmbCommTyp.SelectedIndex.ToString();
            data_this.Sts = CmbStatus.SelectedIndex;
            data_this.RepInv2 = CmbInvPrice.SelectedIndex.ToString().Trim();
            data_this.RepInv3 = CmbSendOption.SelectedIndex.ToString().Trim();
            data_this.RepInv4 = CmbInvPriceStop.SelectedIndex.ToString().Trim();
            data_this.Comm_Inv = textBox_CommInv.Value;
            data_this.Comm_Gaid = textBox_CommGaid.Value;
            data_this.MaxDiscountSals = textBox_MaxDis.Value;
            data_this.MaxDiscountPurchaes = textBox_MaxDis.Value;
            data_this.vColumnStr1 = "";
            data_this.vColumnStr2 = "";
            data_this.vColumnStr3 = "";
            data_this.vColumnStr4 = "";
            data_this.vColumnNum1 = 0.0;
            data_this.vColumnNum2 = 0;
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                try
                {
                    if (switchButton_AdminOp.Value)
                    {
                        data_this.RepInv1 = "1";
                    }
                    else
                    {
                        data_this.RepInv1 = "0";
                    }
                }
                catch
                {
                    data_this.RepInv1 = "0";
                }
            }
            if (PicItemImg.Image != null)
            {
                MemoryStream stream = new MemoryStream();
                PicItemImg.Image.Save(stream, ImageFormat.Jpeg);
                byte[] arr = stream.GetBuffer();
                data_this.UsrImg = arr;
            }
            else
            {
                data_this.UsrImg = null;
            }
            string StrPR = "";
            for (int iiCnt = 1; iiCnt < FlxFiles.Rows.Count; iiCnt++)
            {
                for (int I = 1; I < 5; I++)
                {
                    StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(FlxFiles.GetData(iiCnt, I)));
                }
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.FilStr = StrPR;
            }
            StrPR = "";
            for (int iiCnt = 1; iiCnt < FlxAccounting.Rows.Count; iiCnt++)
            {
                for (int I = 1; I < 5; I++)
                {
                    StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(FlxAccounting.GetData(iiCnt, I)));
                }
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.SndStr = StrPR;
            }
            StrPR = "";
            for (int iiCnt = 1; iiCnt < FlxInvoices.Rows.Count; iiCnt++)
            {
                for (int I = 1; I < 5; I++)
                {
                    StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(FlxInvoices.GetData(iiCnt, I)));
                }
            }
            for (int iiCnt = 1; iiCnt < FlxInvoices.Rows.Count; iiCnt++)
            {
                for (int I = 5; I < 6; I++)
                {
                    StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(FlxInvoices.GetData(iiCnt, I)));
                }
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.InvStr = StrPR;
            }
            StrPR = "";
            for (int iiCnt = 1; iiCnt < FlxSRep.Rows.Count; iiCnt++)
            {
                StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(FlxSRep.GetData(iiCnt, 2)));
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.StkRep = StrPR;
            }
            StrPR = "";
            for (int iiCnt = 1; iiCnt < FlxAccRep.Rows.Count; iiCnt++)
            {
                StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(FlxAccRep.GetData(iiCnt, 1)));
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.AccRep = StrPR;
            }
            StrPR = "";
            for (int iiCnt = 1; iiCnt < FlxSetups.Rows.Count; iiCnt++)
            {
                StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(FlxSetups.GetData(iiCnt, 1)));
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.SetStr = StrPR + "00";
            }
            StrPR = "";
            StrPR += VarGeneral.TString.ChkStatSave(chk1.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk2.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk3.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk4.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk5.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk6.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk7.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk8.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk9.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk10.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk11.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk12.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk14.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk15.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk17.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk18.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk19.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk20.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk21.Checked);
            StrPR += VarGeneral.TString.ChkStatSave(chk23.Checked);
            data_this.PassQty = StrPR.Trim();
            StrPR = "";
            for (int iiCnt = 1; iiCnt < dataGridViewX_MenuPer.Rows.Count; iiCnt++)
            {
                for (int I = 1; I < 5; I++)
                {
                    StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(dataGridViewX_MenuPer.GetData(iiCnt, I)));
                }
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.Emp_FilStr = StrPR;
            }
            StrPR = "";
            for (int iiCnt = 1; iiCnt < dataGridViewX_MovePre.Rows.Count; iiCnt++)
            {
                for (int I = 1; I < 5; I++)
                {
                    StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(dataGridViewX_MovePre.GetData(iiCnt, I)));
                }
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.Emp_MovStr = StrPR;
            }
            StrPR = "";
            for (int iiCnt = 1; iiCnt < dataGridViewX_SalPer.Rows.Count; iiCnt++)
            {
                StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(dataGridViewX_SalPer.GetData(iiCnt, 1)));
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.Emp_SalStr = StrPR;
            }
            StrPR = "";
            for (int iiCnt = 1; iiCnt < dataGridViewX_RepPre.Rows.Count; iiCnt++)
            {
                StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(dataGridViewX_RepPre.GetData(iiCnt, 1)));
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.Emp_RepStr = StrPR;
            }
            StrPR = "";
            for (int iiCnt = 1; iiCnt < dataGridViewX_GenralPre.Rows.Count; iiCnt++)
            {
                StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(dataGridViewX_GenralPre.GetData(iiCnt, 1)));
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.Emp_GenStr = StrPR;
            }
            StrPR = "";
            for (int iiCnt = 1; iiCnt < dataGridViewX_HotelMenuPer.Rows.Count; iiCnt++)
            {
                for (int I = 1; I < 5; I++)
                {
                    StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(dataGridViewX_HotelMenuPer.GetData(iiCnt, I)));
                }
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.RepAcc1 = StrPR;
            }
            StrPR = "";
            for (int iiCnt = 1; iiCnt < dataGridViewX_HotelMovePre.Rows.Count; iiCnt++)
            {
                for (int I = 1; I < 5; I++)
                {
                    StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(dataGridViewX_HotelMovePre.GetData(iiCnt, I)));
                }
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.RepAcc2 = StrPR;
            }
            StrPR = "";
            for (int iiCnt = 1; iiCnt < dataGridViewX_HotelRepPre.Rows.Count; iiCnt++)
            {
                StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(dataGridViewX_HotelRepPre.GetData(iiCnt, 1)));
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.RepAcc3 = StrPR;
            }
            StrPR = "";
            for (int iiCnt = 1; iiCnt < dataGridViewX_HotelGenralPre.Rows.Count; iiCnt++)
            {
                StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(dataGridViewX_HotelGenralPre.GetData(iiCnt, 1)));
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.RepAcc4 = StrPR;
            }
            data_this.RepAcc5 = Combo1.SelectedIndex.ToString();
            data_this.RepAcc6 = Combo3.SelectedIndex.ToString();
            data_this.RepInv5 = (chk13.Checked ? "1" : "0");
            string _peaperTp = "";
            for (int i = 0; i < FlexType.Rows.Count; i++)
            {
                try
                {
                    _peaperTp = (Convert.ToBoolean(FlexType.Rows[i][0].ToString()) ? (_peaperTp + "1") : (_peaperTp + "0"));
                }
                catch
                {
                    _peaperTp += "0";
                }
            }
            data_this.PeaperTyp = _peaperTp;
            data_this.StopBanner = VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(switchButton_ControlHeadOFRep.Value)) + VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(chk16.Checked)) + VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(chk22.Checked));
            string _StorePr = "";
            for (int i = 0; i < FlxStkQty.Rows.Count; i++)
            {
                try
                {
                    if (Convert.ToBoolean(FlxStkQty.Rows[i][1].ToString()))
                    {
                        _StorePr = _StorePr + "," + FlxStkQty.Rows[i][0].ToString();
                    }
                }
                catch
                {
                }
            }
            data_this.StorePrmission = _StorePr;
            StrPR = "";
            for (int iiCnt = 1; iiCnt < dataGridViewX_EqarFiles.Rows.Count; iiCnt++)
            {
                for (int I = 1; I < 5; I++)
                {
                    StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(dataGridViewX_EqarFiles.GetData(iiCnt, I)));
                }
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.Eqar_FilStr = StrPR;
            }
            StrPR = "";
            for (int iiCnt = 1; iiCnt < dataGridViewX_Tenants.Rows.Count; iiCnt++)
            {
                for (int I = 1; I < 5; I++)
                {
                    StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(dataGridViewX_Tenants.GetData(iiCnt, I)));
                }
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.Eqar_TenantStr = StrPR;
            }
            StrPR = "";
            for (int iiCnt = 1; iiCnt < dataGridViewX_RepEqar.Rows.Count; iiCnt++)
            {
                StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(dataGridViewX_RepEqar.GetData(iiCnt, 1)));
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.Eqar_RepStr = StrPR;
            }
            StrPR = "";
            for (int iiCnt = 1; iiCnt < dataGridViewX_GenralEqar.Rows.Count; iiCnt++)
            {
                StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(dataGridViewX_GenralEqar.GetData(iiCnt, 1)));
            }
            if (textBox_ID.Text != "1" && textBox_ID.Text != "2")
            {
                data_this.Eqar_GenStr = StrPR;
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
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return new Bitmap(imgToResize, size);
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
                max = dbc.MaxUsrNo;
                Clear();
                textBox_ID.Text = max.ToString();
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
                if (textBox_ID.Text == "")
                {
                    MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الرقم فارغا\u0651 " : "Can't No empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_ID.Focus();
                    return;
                }
                if (txtUserName.Text == "")
                {
                    MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الاسم العربي فارغا\u0651 " : "Can't Arabic name empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtUserName.Focus();
                    return;
                }
                if (txtUserNameE.Text == "")
                {
                    MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الاسم الانجليزي فارغا\u0651 " : "Can't English Name empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtUserNameE.Focus();
                    return;
                }
                if (txtPass.Text == "")
                {
                    MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الرقم السري فارغا\u0651 " : "Can't password empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtPass.Focus();
                    return;
                }
                if (txtPass.Text.Trim() != txtPassConf.Text.Trim())
                {
                    MessageBox.Show((LangArEn == 0) ? "كلمة المرور غير متطابقة حاول مرة اخرى " : "Password is UnCorrecte", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtPass.Focus();
                    return;
                }
                if (State == FormState.New)
                {
                    GetData();
                    try
                    {
                        data_this.CreateGaid = 0;
                        data_this.UserPointTyp = 0;
                        data_this.CashAccNo_C = "";
                        data_this.CashAccNo_D = "";
                        data_this.NetworkAccNo_C = "";
                        data_this.NetworkAccNo_D = "";
                        data_this.CreaditAccNo_C = "";
                        data_this.CreaditAccNo_D = "";
                        data_this.CashAccNo_C_R = "";
                        data_this.CashAccNo_D_R = "";
                        data_this.NetworkAccNo_C_R = "";
                        data_this.NetworkAccNo_D_R = "";
                        data_this.CreaditAccNo_C_R = "";
                        data_this.CreaditAccNo_D_R = "";
                        dbc.T_Users.InsertOnSubmit(data_this);
                        dbc.SubmitChanges();
                       
                        //	db.ExecuteCommand(DBUdate.DbUpdates.CopySttingString.Replace("usIds", data_this.Usr_ID.ToString()));
                    }
                    catch (SqlException ex3)
                    {
                        int max = 0;
                        max = dbc.MaxUsrNo;
                        if (ex3.Number != 2627)
                        {
                            return;
                        }
                        MessageBox.Show("الرمز مستخدم من قبل.\n سيتم الحفظ برقم جديد [" + max + "]", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        textBox_ID.Text = string.Concat(max);
                        data_this.UsrNo = string.Concat(max);
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
                State = FormState.Saved;
                RefreshPKeys();
                TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(data_this.UsrNo ?? "") + 1);
                SetReadOnly = true;
                DBUdate.DbUpdates.updateusersettings();
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
            if (codeControl != null)
            {
                Code = codeControl.Text;
            }
            if (Code == "")
            {
                ifOkDelete = false;
                return;
            }
            try
            {
                if (textBox_ID.Text == "1" || data_this.Usr_ID == 1)
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
            try
            {
                if (textBox_ID.Text == "2" || data_this.Usr_ID == 2)
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
            if (data_this == null || data_this.Usr_ID == 0 || !ifOkDelete)
            {
                return;
            }
            T_GDHEAD returned = db.SelectUsrNoByReturnNo(DataThis.UsrNo);
            if (returned != null && !string.IsNullOrEmpty(returned.gdUser))
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن حذف المستخدم .. لانه مرتبط باحد القيود" : "You can not delete User .. because it is tied to a Gaid", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            data_this = dbc.RateUsr(DataThis.UsrNo.ToString());
            try
            {
                dbc.T_Users.DeleteOnSubmit(DataThis);
                dbc.SubmitChanges();
            }
            catch (SqlException)
            {
                data_this = dbc.RateUsr(DataThis.UsrNo.ToString());
                return;
            }
            catch (Exception)
            {
                data_this = dbc.RateUsr(DataThis.UsrNo.ToString());
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
            if (dataMember != null && dataMember == "T_User")
            {
                PropUsrPanel(panel);
            }
        }
        private void PropUsrPanel(GridPanel panel)
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
            panel.Columns["UsrNo"].Width = 165;
            panel.Columns["UsrNo"].Visible = columns_Names_visible["UsrNo"].IfDefault;
            panel.Columns["UsrNamA"].Width = 280;
            panel.Columns["UsrNamA"].Visible = columns_Names_visible["UsrNamA"].IfDefault;
            panel.Columns["UsrNamE"].Width = 280;
            panel.Columns["UsrNamE"].Visible = columns_Names_visible["UsrNamE"].IfDefault;
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
                ExportExcel.ExportToExcel(DGV_Main, "تقرير المستخدمين");
            }
            catch
            {
            }
        }
        private void Button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ADD_Controls()
        {
            try
            {
                controls = new List<Control>();
                controls.Add(txtPass);
                codeControl = textBox_ID;
                controls.Add(textBox_CommInv);
                controls.Add(textBox_CommGaid);
                controls.Add(textBox_MaxDis);
                controls.Add(txtPassConf);
                controls.Add(txtUserName);
                controls.Add(txtUserNameE);
                controls.Add(CmbBranch);
                controls.Add(CmbLanguge);
                controls.Add(CmbStores);
                controls.Add(CmbStatus);
                controls.Add(CmbInvPrice);
                controls.Add(CmbInvPriceStop);
                controls.Add(CmbSendOption);
                controls.Add(FlxAccounting);
                controls.Add(textBox_ID);
                controls.Add(FlxAccRep);
                controls.Add(FlxFiles);
                controls.Add(PicItemImg);
                controls.Add(chk1);
                controls.Add(chk2);
                controls.Add(chk3);
                controls.Add(chk4);
                controls.Add(chk5);
                controls.Add(chk6);
                controls.Add(chk7);
                controls.Add(chk8);
                controls.Add(chk9);
                controls.Add(chk10);
                controls.Add(chk12);
                controls.Add(chk13);
                controls.Add(chk14);
                controls.Add(chk15);
                controls.Add(chk16);
                controls.Add(chk17);
                controls.Add(chk18);
                controls.Add(chk19);
                controls.Add(chk20);
                controls.Add(chk21);
                controls.Add(chk22);
                controls.Add(chk23);
                controls.Add(switchButton_ControlHeadOFRep);
                controls.Add(FlxInvoices);
                controls.Add(FlxSetups);
                controls.Add(dataGridViewX_GenralPre);
                controls.Add(dataGridViewX_MenuPer);
                controls.Add(dataGridViewX_MovePre);
                controls.Add(dataGridViewX_RepPre);
                controls.Add(dataGridViewX_SalPer);
                controls.Add(FlxSRep);
                controls.Add(Combo1);
                controls.Add(dataGridViewX_HotelGenralPre);
                controls.Add(dataGridViewX_HotelMenuPer);
                controls.Add(dataGridViewX_HotelMovePre);
                controls.Add(dataGridViewX_HotelRepPre);
                controls.Add(Combo3);
                controls.Add(CmbCommTyp);
                controls.Add(dataGridViewX_EqarFiles);
                controls.Add(dataGridViewX_Tenants);
                controls.Add(dataGridViewX_RepEqar);
                controls.Add(dataGridViewX_GenralEqar);
            }
            catch (SqlException)
            {
            }
        }
        private void FrmUsr_KeyDown(object sender, KeyEventArgs e)
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
        private void txtUserName_Enter(object sender, EventArgs e)
        {
            Language.Switch("AR");
        }
        private void txtUserNameE_Enter(object sender, EventArgs e)
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
        private void buttonItem_SelectAll_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            if (ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_General")
            {
                for (int i = 1; i < FlxSetups.Rows.Count; i++)
                {
                    FlxSetups.SetData(i, 1, true);
                }
            }
            else if (ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_Files")
            {
                for (int i = 1; i < FlxFiles.Rows.Count; i++)
                {
                    FlxFiles.SetData(i, 1, true);
                    FlxFiles.SetData(i, 2, true);
                    FlxFiles.SetData(i, 3, true);
                    FlxFiles.SetData(i, 4, true);
                }
            }
            else if (ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_ACC")
            {
                for (int i = 1; i < FlxAccounting.Rows.Count; i++)
                {
                    FlxAccounting.SetData(i, 1, true);
                    FlxAccounting.SetData(i, 2, true);
                    FlxAccounting.SetData(i, 3, true);
                    FlxAccounting.SetData(i, 4, true);
                }
            }
            else if (ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_Inv")
            {
                for (int i = 1; i < FlxInvoices.Rows.Count; i++)
                {
                    FlxInvoices.SetData(i, 1, true);
                    FlxInvoices.SetData(i, 2, true);
                    FlxInvoices.SetData(i, 3, true);
                    FlxInvoices.SetData(i, 4, true);
                    FlxInvoices.SetData(i, 5, true);
                }
            }
            else if (ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_RepStocks")
            {
                for (int i = 1; i < FlxSRep.Rows.Count; i++)
                {
                    FlxSRep.SetData(i, 2, true);
                }
            }
            else if (ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_RepAcc")
            {
                for (int i = 1; i < FlxAccRep.Rows.Count; i++)
                {
                    FlxAccRep.SetData(i, 1, true);
                }
            }
            else if (ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_Emps")
            {
                if (MenuPer.Checked)
                {
                    for (int i = 1; i < dataGridViewX_MenuPer.Rows.Count; i++)
                    {
                        dataGridViewX_MenuPer.SetData(i, 1, true);
                        dataGridViewX_MenuPer.SetData(i, 2, true);
                        dataGridViewX_MenuPer.SetData(i, 3, true);
                        dataGridViewX_MenuPer.SetData(i, 4, true);
                    }
                }
                else if (MovePre.Checked)
                {
                    for (int i = 1; i < dataGridViewX_MovePre.Rows.Count; i++)
                    {
                        dataGridViewX_MovePre.SetData(i, 1, true);
                        dataGridViewX_MovePre.SetData(i, 2, true);
                        dataGridViewX_MovePre.SetData(i, 3, true);
                        dataGridViewX_MovePre.SetData(i, 4, true);
                    }
                }
                else if (SalPer.Checked)
                {
                    for (int i = 1; i < dataGridViewX_SalPer.Rows.Count; i++)
                    {
                        dataGridViewX_SalPer.SetData(i, 1, true);
                    }
                }
                else if (RepPre.Checked)
                {
                    for (int i = 1; i < dataGridViewX_RepPre.Rows.Count; i++)
                    {
                        dataGridViewX_RepPre.SetData(i, 1, true);
                    }
                }
                else if (GenralPre.Checked)
                {
                    for (int i = 1; i < dataGridViewX_GenralPre.Rows.Count; i++)
                    {
                        dataGridViewX_GenralPre.SetData(i, 1, true);
                    }
                }
            }
            else if (ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_Hotels")
            {
                if (HotelMenuPer.Checked)
                {
                    for (int i = 1; i < dataGridViewX_HotelMenuPer.Rows.Count; i++)
                    {
                        dataGridViewX_HotelMenuPer.SetData(i, 1, true);
                        dataGridViewX_HotelMenuPer.SetData(i, 2, true);
                        dataGridViewX_HotelMenuPer.SetData(i, 3, true);
                        dataGridViewX_HotelMenuPer.SetData(i, 4, true);
                    }
                }
                else if (HotelMovePre.Checked)
                {
                    for (int i = 1; i < dataGridViewX_HotelMovePre.Rows.Count; i++)
                    {
                        dataGridViewX_HotelMovePre.SetData(i, 1, true);
                        dataGridViewX_HotelMovePre.SetData(i, 2, true);
                        dataGridViewX_HotelMovePre.SetData(i, 3, true);
                        dataGridViewX_HotelMovePre.SetData(i, 4, true);
                    }
                }
                else if (HotelRepPre.Checked)
                {
                    for (int i = 1; i < dataGridViewX_HotelRepPre.Rows.Count; i++)
                    {
                        dataGridViewX_HotelRepPre.SetData(i, 1, true);
                    }
                }
                else if (HotelGenralPre.Checked)
                {
                    for (int i = 1; i < dataGridViewX_HotelGenralPre.Rows.Count; i++)
                    {
                        dataGridViewX_HotelGenralPre.SetData(i, 1, true);
                    }
                }
            }
            else
            {
                if (!(ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_Eqar"))
                {
                    return;
                }
                if (EqarFiles.Checked)
                {
                    for (int i = 1; i < dataGridViewX_EqarFiles.Rows.Count; i++)
                    {
                        dataGridViewX_EqarFiles.SetData(i, 1, true);
                        dataGridViewX_EqarFiles.SetData(i, 2, true);
                        dataGridViewX_EqarFiles.SetData(i, 3, true);
                        dataGridViewX_EqarFiles.SetData(i, 4, true);
                    }
                }
                else if (EqarTenant.Checked)
                {
                    for (int i = 1; i < dataGridViewX_Tenants.Rows.Count; i++)
                    {
                        dataGridViewX_Tenants.SetData(i, 1, true);
                        dataGridViewX_Tenants.SetData(i, 2, true);
                        dataGridViewX_Tenants.SetData(i, 3, true);
                        dataGridViewX_Tenants.SetData(i, 4, true);
                    }
                }
                else if (EqarsRep.Checked)
                {
                    for (int i = 1; i < dataGridViewX_RepEqar.Rows.Count; i++)
                    {
                        dataGridViewX_RepEqar.SetData(i, 1, true);
                    }
                }
                else if (EqarGenarl.Checked)
                {
                    for (int i = 1; i < dataGridViewX_GenralEqar.Rows.Count; i++)
                    {
                        dataGridViewX_GenralEqar.SetData(i, 1, true);
                    }
                }
            }
        }
        private void buttonItem_UnSelectAll_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            if (ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_General")
            {
                for (int i = 1; i < FlxSetups.Rows.Count; i++)
                {
                    FlxSetups.SetData(i, 1, false);
                }
            }
            else if (ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_Files")
            {
                for (int i = 1; i < FlxFiles.Rows.Count; i++)
                {
                    FlxFiles.SetData(i, 1, false);
                    FlxFiles.SetData(i, 2, false);
                    FlxFiles.SetData(i, 3, false);
                    FlxFiles.SetData(i, 4, false);
                }
            }
            else if (ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_ACC")
            {
                for (int i = 1; i < FlxAccounting.Rows.Count; i++)
                {
                    FlxAccounting.SetData(i, 1, false);
                    FlxAccounting.SetData(i, 2, false);
                    FlxAccounting.SetData(i, 3, false);
                    FlxAccounting.SetData(i, 4, false);
                }
            }
            else if (ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_Inv")
            {
                for (int i = 1; i < FlxInvoices.Rows.Count; i++)
                {
                    FlxInvoices.SetData(i, 1, false);
                    FlxInvoices.SetData(i, 2, false);
                    FlxInvoices.SetData(i, 3, false);
                    FlxInvoices.SetData(i, 4, false);
                    FlxInvoices.SetData(i, 5, false);
                }
            }
            else if (ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_RepStocks")
            {
                for (int i = 1; i < FlxSRep.Rows.Count; i++)
                {
                    FlxSRep.SetData(i, 2, false);
                }
            }
            else if (ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_RepAcc")
            {
                for (int i = 1; i < FlxAccRep.Rows.Count; i++)
                {
                    FlxAccRep.SetData(i, 1, false);
                }
            }
            else if (ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_Emps")
            {
                if (MenuPer.Checked)
                {
                    for (int i = 1; i < dataGridViewX_MenuPer.Rows.Count; i++)
                    {
                        dataGridViewX_MenuPer.SetData(i, 1, false);
                        dataGridViewX_MenuPer.SetData(i, 2, false);
                        dataGridViewX_MenuPer.SetData(i, 3, false);
                        dataGridViewX_MenuPer.SetData(i, 4, false);
                    }
                }
                else if (MovePre.Checked)
                {
                    for (int i = 1; i < dataGridViewX_MovePre.Rows.Count; i++)
                    {
                        dataGridViewX_MovePre.SetData(i, 1, false);
                        dataGridViewX_MovePre.SetData(i, 2, false);
                        dataGridViewX_MovePre.SetData(i, 3, false);
                        dataGridViewX_MovePre.SetData(i, 4, false);
                    }
                }
                else if (SalPer.Checked)
                {
                    for (int i = 1; i < dataGridViewX_SalPer.Rows.Count; i++)
                    {
                        dataGridViewX_SalPer.SetData(i, 1, false);
                    }
                }
                else if (RepPre.Checked)
                {
                    for (int i = 1; i < dataGridViewX_RepPre.Rows.Count; i++)
                    {
                        dataGridViewX_RepPre.SetData(i, 1, false);
                    }
                }
                else if (GenralPre.Checked)
                {
                    for (int i = 1; i < dataGridViewX_GenralPre.Rows.Count; i++)
                    {
                        dataGridViewX_GenralPre.SetData(i, 1, false);
                    }
                }
            }
            else if (ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_Hotels")
            {
                if (HotelMenuPer.Checked)
                {
                    for (int i = 1; i < dataGridViewX_HotelMenuPer.Rows.Count; i++)
                    {
                        dataGridViewX_HotelMenuPer.SetData(i, 1, false);
                        dataGridViewX_HotelMenuPer.SetData(i, 2, false);
                        dataGridViewX_HotelMenuPer.SetData(i, 3, false);
                        dataGridViewX_HotelMenuPer.SetData(i, 4, false);
                    }
                }
                else if (HotelMovePre.Checked)
                {
                    for (int i = 1; i < dataGridViewX_HotelMovePre.Rows.Count; i++)
                    {
                        dataGridViewX_HotelMovePre.SetData(i, 1, false);
                        dataGridViewX_HotelMovePre.SetData(i, 2, false);
                        dataGridViewX_HotelMovePre.SetData(i, 3, false);
                        dataGridViewX_HotelMovePre.SetData(i, 4, false);
                    }
                }
                else if (HotelRepPre.Checked)
                {
                    for (int i = 1; i < dataGridViewX_HotelRepPre.Rows.Count; i++)
                    {
                        dataGridViewX_HotelRepPre.SetData(i, 1, false);
                    }
                }
                else if (HotelGenralPre.Checked)
                {
                    for (int i = 1; i < dataGridViewX_HotelGenralPre.Rows.Count; i++)
                    {
                        dataGridViewX_HotelGenralPre.SetData(i, 1, false);
                    }
                }
            }
            else
            {
                if (!(ribbonControl_Setting.SelectedRibbonTabItem.Name == "ribbonTabItem_Eqar"))
                {
                    return;
                }
                if (EqarFiles.Checked)
                {
                    for (int i = 1; i < dataGridViewX_EqarFiles.Rows.Count; i++)
                    {
                        dataGridViewX_EqarFiles.SetData(i, 1, false);
                        dataGridViewX_EqarFiles.SetData(i, 2, false);
                        dataGridViewX_EqarFiles.SetData(i, 3, false);
                        dataGridViewX_EqarFiles.SetData(i, 4, false);
                    }
                }
                else if (EqarTenant.Checked)
                {
                    for (int i = 1; i < dataGridViewX_Tenants.Rows.Count; i++)
                    {
                        dataGridViewX_Tenants.SetData(i, 1, false);
                        dataGridViewX_Tenants.SetData(i, 2, false);
                        dataGridViewX_Tenants.SetData(i, 3, false);
                        dataGridViewX_Tenants.SetData(i, 4, false);
                    }
                }
                else if (EqarsRep.Checked)
                {
                    for (int i = 1; i < dataGridViewX_RepEqar.Rows.Count; i++)
                    {
                        dataGridViewX_RepEqar.SetData(i, 1, false);
                    }
                }
                else if (EqarGenarl.Checked)
                {
                    for (int i = 1; i < dataGridViewX_GenralEqar.Rows.Count; i++)
                    {
                        dataGridViewX_GenralEqar.SetData(i, 1, false);
                    }
                }
            }
        }
        private void txtPass_Click(object sender, EventArgs e)
        {
            txtPass.SelectAll();
        }
        private void txtPassConf_Click(object sender, EventArgs e)
        {
            txtPassConf.SelectAll();
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
                _RepShow.Tables = " T_Users ";
                string Fields = "";
                Fields = " T_Users.UsrNo as No , T_Users.UsrNamA as NmA, T_Users.UsrNamE as NmE ";
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
        private void switchButton_AdminOp_ValueChanged(object sender, EventArgs e)
        {
            if (switchButton_AdminOp.Value)
            {
                chk11.Visible = true;
            }
            else
            {
                chk11.Visible = false;
            }
            superTabControl_Main1.Refresh();
        }
        private void FillFlex()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                FlexType.Rows.Count = 13;
                FlexType.SetData(0, 0, false);
                FlexType.SetData(0, 1, "مبيعات");
                FlexType.SetData(0, 2, "1");
                FlexType.SetData(1, 0, false);
                FlexType.SetData(1, 1, "مرتجع مبيعات");
                FlexType.SetData(1, 2, "3");
                FlexType.SetData(2, 0, false);
                FlexType.SetData(2, 1, "مشتريات");
                FlexType.SetData(2, 2, "2");
                FlexType.SetData(3, 0, false);
                FlexType.SetData(3, 1, "مرتجع مشتريات");
                FlexType.SetData(3, 2, "4");
                FlexType.SetData(4, 0, false);
                FlexType.SetData(4, 1, "عرض سعر عملاء");
                FlexType.SetData(4, 2, "7");
                FlexType.SetData(5, 0, false);
                FlexType.SetData(5, 1, "عرض سعر مورد");
                FlexType.SetData(5, 2, "8");
                FlexType.SetData(6, 0, false);
                FlexType.SetData(6, 1, "طلب شراء");
                FlexType.SetData(6, 2, "9");
                FlexType.SetData(7, 0, false);
                FlexType.SetData(7, 1, "بضاعة أول المدة");
                FlexType.SetData(7, 2, "14");
                FlexType.SetData(8, 0, false);
                FlexType.SetData(8, 1, "إدخال بضاعة");
                FlexType.SetData(8, 2, "5");
                FlexType.SetData(9, 0, false);
                FlexType.SetData(9, 1, "إخراج بضاعة");
                FlexType.SetData(9, 2, "6");
                FlexType.SetData(10, 0, false);
                FlexType.SetData(10, 1, "صرف بضاعة");
                FlexType.SetData(10, 2, "17");
                FlexType.SetData(11, 0, false);
                FlexType.SetData(11, 1, "مرتجع صرف بضاعة");
                FlexType.SetData(11, 2, "20");
                FlexType.SetData(12, 0, false);
                FlexType.SetData(12, 1, "تسوية البضاعة");
                FlexType.SetData(12, 2, "10");
            }
            else
            {
                FlexType.Rows.Count = 13;
                FlexType.SetData(0, 0, false);
                FlexType.SetData(0, 1, "Sales");
                FlexType.SetData(0, 2, "1");
                FlexType.SetData(1, 0, false);
                FlexType.SetData(1, 1, "Returned sales");
                FlexType.SetData(1, 2, "3");
                FlexType.SetData(2, 0, false);
                FlexType.SetData(2, 1, "Purchases");
                FlexType.SetData(2, 2, "2");
                FlexType.SetData(3, 0, false);
                FlexType.SetData(3, 1, "Returned Purchases");
                FlexType.SetData(3, 2, "4");
                FlexType.SetData(4, 0, false);
                FlexType.SetData(4, 1, "Quote Cust");
                FlexType.SetData(4, 2, "7");
                FlexType.SetData(5, 0, false);
                FlexType.SetData(5, 1, "Quote Supp");
                FlexType.SetData(5, 2, "8");
                FlexType.SetData(6, 0, false);
                FlexType.SetData(6, 1, "Purchase Order");
                FlexType.SetData(6, 2, "9");
                FlexType.SetData(7, 0, false);
                FlexType.SetData(7, 1, "Quantitative opening");
                FlexType.SetData(7, 2, "14");
                FlexType.SetData(8, 0, false);
                FlexType.SetData(8, 1, "introduction goods");
                FlexType.SetData(8, 2, "5");
                FlexType.SetData(9, 0, false);
                FlexType.SetData(9, 1, "Directed goods");
                FlexType.SetData(9, 2, "6");
                FlexType.SetData(10, 0, false);
                FlexType.SetData(10, 1, "Exchange goods");
                FlexType.SetData(10, 2, "17");
                FlexType.SetData(11, 0, false);
                FlexType.SetData(11, 1, "Return Exchange goods");
                FlexType.SetData(11, 2, "20");
                FlexType.SetData(12, 0, false);
                FlexType.SetData(12, 1, "Settlement goods");
                FlexType.SetData(12, 2, "10");
            }
        }
        private void switchButton_ControlHeadOFRep_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (switchButton_ControlHeadOFRep.Value)
                {
                    chk16.Enabled = true;
                }
                else
                {
                    chk16.Enabled = false;
                }
                chk16.Checked = false;
            }
            catch
            {
                chk16.Enabled = false;
            }
        }
        private void txtWidth_LockUpdateChanged(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            txtWidth.LockUpdateChanged -= txtWidth_LockUpdateChanged;
            txtHeight.LockUpdateChanged -= txtHeight_LockUpdateChanged;
            try
            {
                if (txtWidth.LockUpdateChecked)
                {
                    txtWidth.LockUpdateChecked = true;
                    txtHeight.LockUpdateChecked = true;
                }
                else
                {
                    txtWidth.LockUpdateChecked = false;
                    txtHeight.LockUpdateChecked = false;
                }
            }
            catch
            {
            }
            txtWidth.LockUpdateChanged += txtWidth_LockUpdateChanged;
            txtHeight.LockUpdateChanged += txtHeight_LockUpdateChanged;
        }
        private void txtHeight_LockUpdateChanged(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            txtWidth.LockUpdateChanged -= txtWidth_LockUpdateChanged;
            txtHeight.LockUpdateChanged -= txtHeight_LockUpdateChanged;
            try
            {
                if (txtHeight.LockUpdateChecked)
                {
                    txtWidth.LockUpdateChecked = true;
                    txtHeight.LockUpdateChecked = true;
                }
                else
                {
                    txtWidth.LockUpdateChecked = false;
                    txtHeight.LockUpdateChecked = false;
                }
            }
            catch
            {
            }
            txtWidth.LockUpdateChanged += txtWidth_LockUpdateChanged;
            txtHeight.LockUpdateChanged += txtHeight_LockUpdateChanged;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsr));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.label19 = new System.Windows.Forms.Label();
            this.CmbCommTyp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.CmbBranch = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.groupBox_Comm = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_CommGaid = new DevComponents.Editors.DoubleInput();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_CommInv = new DevComponents.Editors.DoubleInput();
            this.CmbStatus = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.CmbLanguge = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtUserNameE = new System.Windows.Forms.TextBox();
            this.txtPassConf = new System.Windows.Forms.TextBox();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.ribbonControl_Setting = new DevComponents.DotNetBar.RibbonControl();
            this.ribbonPanel6 = new DevComponents.DotNetBar.RibbonPanel();
            this.groupPanel_Banner = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label21 = new System.Windows.Forms.Label();
            this.txtHeight = new DevComponents.Editors.IntegerInput();
            this.label34 = new System.Windows.Forms.Label();
            this.txtWidth = new DevComponents.Editors.IntegerInput();
            this.PicItemImg = new System.Windows.Forms.PictureBox();
            this.button_ClearPic = new DevComponents.DotNetBar.ButtonX();
            this.button_EnterImg = new DevComponents.DotNetBar.ButtonX();
            this.FlxSetups = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.ribbonPanel3 = new DevComponents.DotNetBar.RibbonPanel();
            this.FlxAccounting = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.ribbonPanel4 = new DevComponents.DotNetBar.RibbonPanel();
            this.FlxSRep = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.ribbonPanel5 = new DevComponents.DotNetBar.RibbonPanel();
            this.FlxAccRep = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.ribbonPanel7 = new DevComponents.DotNetBar.RibbonPanel();
            this.chk23 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.textBox_MaxDis = new DevComponents.Editors.DoubleInput();
            this.chk21 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk20 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk19 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk18 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk17 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk15 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk14 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk12 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.CmbInvPriceStop = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label15 = new System.Windows.Forms.Label();
            this.CmbSendOption = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label14 = new System.Windows.Forms.Label();
            this.CmbInvPrice = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label13 = new System.Windows.Forms.Label();
            this.chk10 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk9 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk8 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk6 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk5 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk3 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk7 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk4 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.ribbonPanel9 = new DevComponents.DotNetBar.RibbonPanel();
            this.navigationPane_Eqar = new DevComponents.DotNetBar.NavigationPane();
            this.navigationPanePanel11 = new DevComponents.DotNetBar.NavigationPanePanel();
            this.dataGridViewX_EqarFiles = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.EqarFiles = new DevComponents.DotNetBar.ButtonItem();
            this.navigationPanePanel13 = new DevComponents.DotNetBar.NavigationPanePanel();
            this.dataGridViewX_GenralEqar = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.EqarGenarl = new DevComponents.DotNetBar.ButtonItem();
            this.navigationPanePanel12 = new DevComponents.DotNetBar.NavigationPanePanel();
            this.dataGridViewX_Tenants = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.EqarTenant = new DevComponents.DotNetBar.ButtonItem();
            this.navigationPanePanel10 = new DevComponents.DotNetBar.NavigationPanePanel();
            this.dataGridViewX_RepEqar = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.EqarsRep = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonTabItem_Hotel = new DevComponents.DotNetBar.RibbonPanel();
            this.navigationPane_Hotel = new DevComponents.DotNetBar.NavigationPane();
            this.navigationPanePanel6 = new DevComponents.DotNetBar.NavigationPanePanel();
            this.dataGridViewX_HotelMenuPer = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.HotelMenuPer = new DevComponents.DotNetBar.ButtonItem();
            this.navigationPanePanel9 = new DevComponents.DotNetBar.NavigationPanePanel();
            this.panel_Prices = new System.Windows.Forms.Panel();
            this.chk13 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label18 = new System.Windows.Forms.Label();
            this.Combo1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label17 = new System.Windows.Forms.Label();
            this.Combo3 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label16 = new System.Windows.Forms.Label();
            this.dataGridViewX_HotelGenralPre = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.HotelGenralPre = new DevComponents.DotNetBar.ButtonItem();
            this.navigationPanePanel8 = new DevComponents.DotNetBar.NavigationPanePanel();
            this.dataGridViewX_HotelRepPre = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.HotelRepPre = new DevComponents.DotNetBar.ButtonItem();
            this.navigationPanePanel7 = new DevComponents.DotNetBar.NavigationPanePanel();
            this.dataGridViewX_HotelMovePre = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.HotelMovePre = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonPanel8 = new DevComponents.DotNetBar.RibbonPanel();
            this.navigationPane_Emps = new DevComponents.DotNetBar.NavigationPane();
            this.navigationPanePanel5 = new DevComponents.DotNetBar.NavigationPanePanel();
            this.dataGridViewX_MenuPer = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.MenuPer = new DevComponents.DotNetBar.ButtonItem();
            this.navigationPanePanel3 = new DevComponents.DotNetBar.NavigationPanePanel();
            this.dataGridViewX_SalPer = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.SalPer = new DevComponents.DotNetBar.ButtonItem();
            this.navigationPanePanel2 = new DevComponents.DotNetBar.NavigationPanePanel();
            this.dataGridViewX_RepPre = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.RepPre = new DevComponents.DotNetBar.ButtonItem();
            this.navigationPanePanel4 = new DevComponents.DotNetBar.NavigationPanePanel();
            this.dataGridViewX_MovePre = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.MovePre = new DevComponents.DotNetBar.ButtonItem();
            this.navigationPanePanel1 = new DevComponents.DotNetBar.NavigationPanePanel();
            this.dataGridViewX_GenralPre = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.GenralPre = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonPanel2 = new DevComponents.DotNetBar.RibbonPanel();
            this.groupPanel_Stores = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label20 = new System.Windows.Forms.Label();
            this.CmbStores = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.FlxStkQty = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.chk22 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.groupPanel_InvoiceType = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.switchButton_ControlHeadOFRep = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.FlexType = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.chk16 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.FlxInvoices = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.ribbonPanel1 = new DevComponents.DotNetBar.RibbonPanel();
            this.FlxFiles = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.ribbonTabItem_General = new DevComponents.DotNetBar.RibbonTabItem();
            this.ribbonTabItem_Files = new DevComponents.DotNetBar.RibbonTabItem();
            this.ribbonTabItem_ACC = new DevComponents.DotNetBar.RibbonTabItem();
            this.ribbonTabItem_Inv = new DevComponents.DotNetBar.RibbonTabItem();
            this.ribbonTabItem_RepStocks = new DevComponents.DotNetBar.RibbonTabItem();
            this.ribbonTabItem_RepAcc = new DevComponents.DotNetBar.RibbonTabItem();
            this.ribbonTabItem_Emps = new DevComponents.DotNetBar.RibbonTabItem();
            this.ribbonTabItem_Hotels = new DevComponents.DotNetBar.RibbonTabItem();
            this.ribbonTabItem_Eqar = new DevComponents.DotNetBar.RibbonTabItem();
            this.ribbonTabItem_Other = new DevComponents.DotNetBar.RibbonTabItem();
            this.buttonItem_SelectAll = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem_UnSelectAll = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.qatCustomizeItem1 = new DevComponents.DotNetBar.QatCustomizeItem();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.switchButton_AdminOp = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.ribbonBar_Tasks = new DevComponents.DotNetBar.RibbonBar();
            this.superTabControl_Main1 = new DevComponents.DotNetBar.SuperTabControl();
            this.Button_Close = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Search = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Delete = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Save = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Add = new DevComponents.DotNetBar.ButtonItem();
            this.chk11 = new DevComponents.DotNetBar.CheckBoxItem();
            this.superTabControl_Main2 = new DevComponents.DotNetBar.SuperTabControl();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.Button_First = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Prev = new DevComponents.DotNetBar.ButtonItem();
            this.TextBox_Index = new DevComponents.DotNetBar.TextBoxItem();
            this.Label_Count = new DevComponents.DotNetBar.LabelItem();
            this.lable_Records = new DevComponents.DotNetBar.LabelItem();
            this.Button_Next = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Last = new DevComponents.DotNetBar.ButtonItem();
            this.ToolStripMenuItem_Rep = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_Det = new System.Windows.Forms.ToolStripMenuItem();
            this.Rep_RecCount = new DevComponents.Editors.IntegerInput();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timerInfoBallon = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.DGV_Main = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.ribbonBar_DGV = new DevComponents.DotNetBar.RibbonBar();
            this.superTabControl_DGV = new DevComponents.DotNetBar.SuperTabControl();
            this.textBox_search = new DevComponents.DotNetBar.TextBoxItem();
            this.Button_ExportTable2 = new DevComponents.DotNetBar.ButtonItem();
            this.Button_PrintTable = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem3 = new DevComponents.DotNetBar.LabelItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.PanelSpecialContainer.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            this.groupBox_Comm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_CommGaid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_CommInv)).BeginInit();
            this.ribbonControl_Setting.SuspendLayout();
            this.ribbonPanel6.SuspendLayout();
            this.groupPanel_Banner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicItemImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlxSetups)).BeginInit();
            this.ribbonPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlxAccounting)).BeginInit();
            this.ribbonPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlxSRep)).BeginInit();
            this.ribbonPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlxAccRep)).BeginInit();
            this.ribbonPanel7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_MaxDis)).BeginInit();
            this.ribbonPanel9.SuspendLayout();
            this.navigationPane_Eqar.SuspendLayout();
            this.navigationPanePanel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX_EqarFiles)).BeginInit();
            this.navigationPanePanel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX_GenralEqar)).BeginInit();
            this.navigationPanePanel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX_Tenants)).BeginInit();
            this.navigationPanePanel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX_RepEqar)).BeginInit();
            this.ribbonTabItem_Hotel.SuspendLayout();
            this.navigationPane_Hotel.SuspendLayout();
            this.navigationPanePanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX_HotelMenuPer)).BeginInit();
            this.navigationPanePanel9.SuspendLayout();
            this.panel_Prices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX_HotelGenralPre)).BeginInit();
            this.navigationPanePanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX_HotelRepPre)).BeginInit();
            this.navigationPanePanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX_HotelMovePre)).BeginInit();
            this.ribbonPanel8.SuspendLayout();
            this.navigationPane_Emps.SuspendLayout();
            this.navigationPanePanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX_MenuPer)).BeginInit();
            this.navigationPanePanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX_SalPer)).BeginInit();
            this.navigationPanePanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX_RepPre)).BeginInit();
            this.navigationPanePanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX_MovePre)).BeginInit();
            this.navigationPanePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX_GenralPre)).BeginInit();
            this.ribbonPanel2.SuspendLayout();
            this.groupPanel_Stores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlxStkQty)).BeginInit();
            this.groupPanel_InvoiceType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlexType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlxInvoices)).BeginInit();
            this.ribbonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlxFiles)).BeginInit();
            this.ribbonBar_Tasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main2)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Rep_RecCount)).BeginInit();
            this.panelEx3.SuspendLayout();
            this.ribbonBar_DGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_DGV)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.PanelSpecialContainer.Size = new System.Drawing.Size(826, 467);
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
            this.ribbonBar1.Controls.Add(this.label19);
            this.ribbonBar1.Controls.Add(this.CmbCommTyp);
            this.ribbonBar1.Controls.Add(this.CmbBranch);
            this.ribbonBar1.Controls.Add(this.groupBox_Comm);
            this.ribbonBar1.Controls.Add(this.CmbStatus);
            this.ribbonBar1.Controls.Add(this.CmbLanguge);
            this.ribbonBar1.Controls.Add(this.txtUserNameE);
            this.ribbonBar1.Controls.Add(this.txtPassConf);
            this.ribbonBar1.Controls.Add(this.textBox_ID);
            this.ribbonBar1.Controls.Add(this.txtUserName);
            this.ribbonBar1.Controls.Add(this.txtPass);
            this.ribbonBar1.Controls.Add(this.ribbonControl_Setting);
            this.ribbonBar1.Controls.Add(this.label5);
            this.ribbonBar1.Controls.Add(this.label6);
            this.ribbonBar1.Controls.Add(this.label4);
            this.ribbonBar1.Controls.Add(this.label1);
            this.ribbonBar1.Controls.Add(this.label8);
            this.ribbonBar1.Controls.Add(this.label3);
            this.ribbonBar1.Controls.Add(this.label7);
            this.ribbonBar1.Controls.Add(this.label2);
            this.ribbonBar1.Controls.Add(this.switchButton_AdminOp);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(826, 416);
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
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Gainsboro;
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label19.Location = new System.Drawing.Point(118, 326);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(124, 20);
            this.label19.TabIndex = 939;
            this.label19.Text = "إحتساب العمولة حسب";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CmbCommTyp
            // 
            this.CmbCommTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbCommTyp.DisplayMember = "Text";
            this.CmbCommTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbCommTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCommTyp.FormattingEnabled = true;
            this.CmbCommTyp.ItemHeight = 14;
            this.CmbCommTyp.Location = new System.Drawing.Point(14, 326);
            this.CmbCommTyp.Name = "CmbCommTyp";
            this.CmbCommTyp.Size = new System.Drawing.Size(102, 20);
            this.CmbCommTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbCommTyp.TabIndex = 938;
            // 
            // CmbBranch
            // 
            this.CmbBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbBranch.DisplayMember = "Text";
            this.CmbBranch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBranch.FormattingEnabled = true;
            this.CmbBranch.ItemHeight = 14;
            this.CmbBranch.Location = new System.Drawing.Point(538, 356);
            this.CmbBranch.Name = "CmbBranch";
            this.CmbBranch.Size = new System.Drawing.Size(173, 20);
            this.CmbBranch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbBranch.TabIndex = 6;
            // 
            // groupBox_Comm
            // 
            this.groupBox_Comm.Controls.Add(this.label9);
            this.groupBox_Comm.Controls.Add(this.label10);
            this.groupBox_Comm.Controls.Add(this.label11);
            this.groupBox_Comm.Controls.Add(this.textBox_CommGaid);
            this.groupBox_Comm.Controls.Add(this.label12);
            this.groupBox_Comm.Controls.Add(this.textBox_CommInv);
            this.groupBox_Comm.Font = new System.Drawing.Font("Tahoma", 8F);
            this.groupBox_Comm.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox_Comm.Location = new System.Drawing.Point(13, 258);
            this.groupBox_Comm.Name = "groupBox_Comm";
            this.groupBox_Comm.Size = new System.Drawing.Size(229, 64);
            this.groupBox_Comm.TabIndex = 934;
            this.groupBox_Comm.TabStop = false;
            this.groupBox_Comm.Text = "نسبة عمولة المستخدم";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(9, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 13);
            this.label9.TabIndex = 938;
            this.label9.Text = "%";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(114, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 13);
            this.label10.TabIndex = 937;
            this.label10.Text = "%";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(50, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 936;
            this.label11.Text = "الإيرادات";
            // 
            // textBox_CommGaid
            // 
            this.textBox_CommGaid.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_CommGaid.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.textBox_CommGaid.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_CommGaid.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_CommGaid.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_CommGaid.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_CommGaid.Increment = 1D;
            this.textBox_CommGaid.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_CommGaid.Location = new System.Drawing.Point(30, 37);
            this.textBox_CommGaid.MinValue = 0D;
            this.textBox_CommGaid.Name = "textBox_CommGaid";
            this.textBox_CommGaid.Size = new System.Drawing.Size(73, 20);
            this.textBox_CommGaid.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(150, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 934;
            this.label12.Text = "المبيعات";
            // 
            // textBox_CommInv
            // 
            this.textBox_CommInv.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_CommInv.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.textBox_CommInv.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_CommInv.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_CommInv.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_CommInv.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_CommInv.Increment = 1D;
            this.textBox_CommInv.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_CommInv.Location = new System.Drawing.Point(134, 37);
            this.textBox_CommInv.MinValue = 0D;
            this.textBox_CommInv.Name = "textBox_CommInv";
            this.textBox_CommInv.Size = new System.Drawing.Size(73, 20);
            this.textBox_CommInv.TabIndex = 6;
            // 
            // CmbStatus
            // 
            this.CmbStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbStatus.DisplayMember = "Text";
            this.CmbStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbStatus.FormattingEnabled = true;
            this.CmbStatus.ItemHeight = 14;
            this.CmbStatus.Location = new System.Drawing.Point(280, 355);
            this.CmbStatus.Name = "CmbStatus";
            this.CmbStatus.Size = new System.Drawing.Size(122, 20);
            this.CmbStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbStatus.TabIndex = 7;
            // 
            // CmbLanguge
            // 
            this.CmbLanguge.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbLanguge.DisplayMember = "Text";
            this.CmbLanguge.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbLanguge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbLanguge.FormattingEnabled = true;
            this.CmbLanguge.ItemHeight = 14;
            this.CmbLanguge.Location = new System.Drawing.Point(280, 323);
            this.CmbLanguge.Name = "CmbLanguge";
            this.CmbLanguge.Size = new System.Drawing.Size(122, 20);
            this.CmbLanguge.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbLanguge.TabIndex = 8;
            // 
            // txtUserNameE
            // 
            this.txtUserNameE.Location = new System.Drawing.Point(538, 323);
            this.txtUserNameE.MaxLength = 50;
            this.txtUserNameE.Name = "txtUserNameE";
            this.netResize1.SetResizeTextBoxMultiline(this.txtUserNameE, false);
            this.txtUserNameE.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUserNameE.Size = new System.Drawing.Size(173, 20);
            this.txtUserNameE.TabIndex = 5;
            this.txtUserNameE.Enter += new System.EventHandler(this.txtUserNameE_Enter);
            this.txtUserNameE.Leave += new System.EventHandler(this.txtUserName_Enter);
            // 
            // txtPassConf
            // 
            this.txtPassConf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtPassConf.Location = new System.Drawing.Point(280, 291);
            this.txtPassConf.MaxLength = 10;
            this.txtPassConf.Name = "txtPassConf";
            this.txtPassConf.PasswordChar = '*';
            this.netResize1.SetResizeTextBoxMultiline(this.txtPassConf, false);
            this.txtPassConf.Size = new System.Drawing.Size(122, 20);
            this.txtPassConf.TabIndex = 3;
            this.txtPassConf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPassConf.Click += new System.EventHandler(this.txtPassConf_Click);
            // 
            // textBox_ID
            // 
            this.textBox_ID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.textBox_ID.Location = new System.Drawing.Point(538, 259);
            this.textBox_ID.MaxLength = 3;
            this.textBox_ID.Name = "textBox_ID";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_ID, false);
            this.textBox_ID.Size = new System.Drawing.Size(173, 20);
            this.textBox_ID.TabIndex = 1;
            this.textBox_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_ID.TextChanged += new System.EventHandler(this.textBox_ID_TextChanged);
            this.textBox_ID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ID_KeyPress);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(538, 291);
            this.txtUserName.MaxLength = 50;
            this.txtUserName.Name = "txtUserName";
            this.netResize1.SetResizeTextBoxMultiline(this.txtUserName, false);
            this.txtUserName.Size = new System.Drawing.Size(173, 20);
            this.txtUserName.TabIndex = 4;
            this.txtUserName.Enter += new System.EventHandler(this.txtUserName_Enter);
            this.txtUserName.Leave += new System.EventHandler(this.txtUserName_Enter);
            // 
            // txtPass
            // 
            this.txtPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtPass.Location = new System.Drawing.Point(280, 259);
            this.txtPass.MaxLength = 10;
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.netResize1.SetResizeTextBoxMultiline(this.txtPass, false);
            this.txtPass.Size = new System.Drawing.Size(122, 20);
            this.txtPass.TabIndex = 2;
            this.txtPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPass.Click += new System.EventHandler(this.txtPass_Click);
            // 
            // ribbonControl_Setting
            // 
            this.ribbonControl_Setting.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.ribbonControl_Setting.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonControl_Setting.CategorizeMode = DevComponents.DotNetBar.eCategorizeMode.Categories;
            this.ribbonControl_Setting.Controls.Add(this.ribbonPanel6);
            this.ribbonControl_Setting.Controls.Add(this.ribbonPanel3);
            this.ribbonControl_Setting.Controls.Add(this.ribbonPanel4);
            this.ribbonControl_Setting.Controls.Add(this.ribbonPanel5);
            this.ribbonControl_Setting.Controls.Add(this.ribbonPanel7);
            this.ribbonControl_Setting.Controls.Add(this.ribbonPanel9);
            this.ribbonControl_Setting.Controls.Add(this.ribbonTabItem_Hotel);
            this.ribbonControl_Setting.Controls.Add(this.ribbonPanel8);
            this.ribbonControl_Setting.Controls.Add(this.ribbonPanel2);
            this.ribbonControl_Setting.Controls.Add(this.ribbonPanel1);
            this.ribbonControl_Setting.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonControl_Setting.ForeColor = System.Drawing.Color.Black;
            this.ribbonControl_Setting.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.ribbonTabItem_General,
            this.ribbonTabItem_Files,
            this.ribbonTabItem_ACC,
            this.ribbonTabItem_Inv,
            this.ribbonTabItem_RepStocks,
            this.ribbonTabItem_RepAcc,
            this.ribbonTabItem_Emps,
            this.ribbonTabItem_Hotels,
            this.ribbonTabItem_Eqar,
            this.ribbonTabItem_Other,
            this.buttonItem_SelectAll,
            this.buttonItem_UnSelectAll});
            this.ribbonControl_Setting.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.ribbonControl_Setting.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl_Setting.Name = "ribbonControl_Setting";
            this.ribbonControl_Setting.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.ribbonControl_Setting.QuickToolbarItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem1,
            this.qatCustomizeItem1});
            this.ribbonControl_Setting.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ribbonControl_Setting.Size = new System.Drawing.Size(826, 253);
            this.ribbonControl_Setting.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonControl_Setting.SystemText.MaximizeRibbonText = "&Maximize the Ribbon";
            this.ribbonControl_Setting.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon";
            this.ribbonControl_Setting.SystemText.QatAddItemText = "&Add to Quick Access Toolbar";
            this.ribbonControl_Setting.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>";
            this.ribbonControl_Setting.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar...";
            this.ribbonControl_Setting.SystemText.QatDialogAddButton = "&Add >>";
            this.ribbonControl_Setting.SystemText.QatDialogCancelButton = "Cancel";
            this.ribbonControl_Setting.SystemText.QatDialogCaption = "Customize Quick Access Toolbar";
            this.ribbonControl_Setting.SystemText.QatDialogCategoriesLabel = "&Choose commands from:";
            this.ribbonControl_Setting.SystemText.QatDialogOkButton = "OK";
            this.ribbonControl_Setting.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControl_Setting.SystemText.QatDialogRemoveButton = "&Remove";
            this.ribbonControl_Setting.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon";
            this.ribbonControl_Setting.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControl_Setting.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar";
            this.ribbonControl_Setting.TabGroupHeight = 14;
            this.ribbonControl_Setting.TabIndex = 923;
            // 
            // ribbonPanel6
            // 
            this.ribbonPanel6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel6.Controls.Add(this.groupPanel_Banner);
            this.ribbonPanel6.Controls.Add(this.FlxSetups);
            this.ribbonPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel6.Location = new System.Drawing.Point(0, 26);
            this.ribbonPanel6.Name = "ribbonPanel6";
            this.ribbonPanel6.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel6.Size = new System.Drawing.Size(826, 224);
            // 
            // 
            // 
            this.ribbonPanel6.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel6.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel6.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel6.TabIndex = 6;
            // 
            // groupPanel_Banner
            // 
            this.groupPanel_Banner.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel_Banner.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel_Banner.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel_Banner.Controls.Add(this.label21);
            this.groupPanel_Banner.Controls.Add(this.txtHeight);
            this.groupPanel_Banner.Controls.Add(this.label34);
            this.groupPanel_Banner.Controls.Add(this.txtWidth);
            this.groupPanel_Banner.Controls.Add(this.PicItemImg);
            this.groupPanel_Banner.Controls.Add(this.button_ClearPic);
            this.groupPanel_Banner.Controls.Add(this.button_EnterImg);
            this.groupPanel_Banner.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupPanel_Banner.Location = new System.Drawing.Point(3, 0);
            this.groupPanel_Banner.Name = "groupPanel_Banner";
            this.groupPanel_Banner.Size = new System.Drawing.Size(272, 221);
            // 
            // 
            // 
            this.groupPanel_Banner.Style.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupPanel_Banner.Style.BackColorGradientAngle = 90;
            this.groupPanel_Banner.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel_Banner.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Banner.Style.BorderBottomWidth = 1;
            this.groupPanel_Banner.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel_Banner.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Banner.Style.BorderLeftWidth = 1;
            this.groupPanel_Banner.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Banner.Style.BorderRightWidth = 1;
            this.groupPanel_Banner.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Banner.Style.BorderTopWidth = 1;
            this.groupPanel_Banner.Style.CornerDiameter = 4;
            this.groupPanel_Banner.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel_Banner.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel_Banner.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel_Banner.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel_Banner.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel_Banner.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel_Banner.TabIndex = 104;
            this.groupPanel_Banner.Text = "صورة المستخدم";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label21.ForeColor = System.Drawing.Color.Blue;
            this.label21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label21.Location = new System.Drawing.Point(200, 148);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(58, 13);
            this.label21.TabIndex = 1011;
            this.label21.Text = "الإرتفــــاع";
            // 
            // txtHeight
            // 
            this.txtHeight.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtHeight.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtHeight.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtHeight.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtHeight.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtHeight.DisplayFormat = "0";
            this.txtHeight.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtHeight.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtHeight.Location = new System.Drawing.Point(195, 170);
            this.txtHeight.LockUpdateChecked = false;
            this.txtHeight.MinValue = 140;
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.ShowCheckBox = true;
            this.txtHeight.ShowUpDown = true;
            this.txtHeight.Size = new System.Drawing.Size(68, 21);
            this.txtHeight.TabIndex = 1010;
            this.txtHeight.Value = 140;
            this.txtHeight.LockUpdateChanged += new System.EventHandler(this.txtHeight_LockUpdateChanged);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label34.ForeColor = System.Drawing.Color.Blue;
            this.label34.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label34.Location = new System.Drawing.Point(203, 89);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(52, 13);
            this.label34.TabIndex = 1009;
            this.label34.Text = "العـــرض";
            // 
            // txtWidth
            // 
            this.txtWidth.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtWidth.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtWidth.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtWidth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtWidth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtWidth.DisplayFormat = "0";
            this.txtWidth.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtWidth.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtWidth.Location = new System.Drawing.Point(195, 111);
            this.txtWidth.LockUpdateChecked = false;
            this.txtWidth.MinValue = 140;
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.ShowCheckBox = true;
            this.txtWidth.ShowUpDown = true;
            this.txtWidth.Size = new System.Drawing.Size(68, 21);
            this.txtWidth.TabIndex = 1008;
            this.txtWidth.Value = 140;
            this.txtWidth.LockUpdateChanged += new System.EventHandler(this.txtWidth_LockUpdateChanged);
            // 
            // PicItemImg
            // 
            this.PicItemImg.BackColor = System.Drawing.Color.Transparent;
            this.PicItemImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PicItemImg.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.PicItemImg.Location = new System.Drawing.Point(4, 6);
            this.PicItemImg.Name = "PicItemImg";
            this.PicItemImg.Size = new System.Drawing.Size(185, 185);
            this.PicItemImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicItemImg.TabIndex = 928;
            this.PicItemImg.TabStop = false;
            // 
            // button_ClearPic
            // 
            this.button_ClearPic.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_ClearPic.Checked = true;
            this.button_ClearPic.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_ClearPic.Location = new System.Drawing.Point(192, 7);
            this.button_ClearPic.Name = "button_ClearPic";
            this.button_ClearPic.Size = new System.Drawing.Size(19, 20);
            this.button_ClearPic.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_ClearPic.Symbol = "";
            this.button_ClearPic.SymbolSize = 11F;
            this.button_ClearPic.TabIndex = 926;
            this.button_ClearPic.TextColor = System.Drawing.Color.SteelBlue;
            this.button_ClearPic.Tooltip = "إزالة الصورة";
            this.button_ClearPic.Click += new System.EventHandler(this.button_ClearPic_Click);
            // 
            // button_EnterImg
            // 
            this.button_EnterImg.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_EnterImg.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_EnterImg.Location = new System.Drawing.Point(192, 29);
            this.button_EnterImg.Name = "button_EnterImg";
            this.button_EnterImg.Size = new System.Drawing.Size(19, 20);
            this.button_EnterImg.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_EnterImg.Symbol = "";
            this.button_EnterImg.SymbolSize = 11F;
            this.button_EnterImg.TabIndex = 927;
            this.button_EnterImg.TextColor = System.Drawing.Color.SteelBlue;
            this.button_EnterImg.Tooltip = "إضافة صورة";
            this.button_EnterImg.Click += new System.EventHandler(this.button_EnterImg_Click);
            // 
            // FlxSetups
            // 
            this.FlxSetups.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.FlxSetups.ColumnInfo = resources.GetString("FlxSetups.ColumnInfo");
            this.FlxSetups.Dock = System.Windows.Forms.DockStyle.Right;
            this.FlxSetups.Location = new System.Drawing.Point(280, 0);
            this.FlxSetups.Name = "FlxSetups";
            this.FlxSetups.Rows.Count = 55;
            this.FlxSetups.Rows.DefaultSize = 19;
            this.FlxSetups.Size = new System.Drawing.Size(543, 221);
            this.FlxSetups.TabIndex = 9;
            this.FlxSetups.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue;
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.AutoSize = true;
            this.ribbonPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel3.Controls.Add(this.FlxAccounting);
            this.ribbonPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel3.Location = new System.Drawing.Point(0, 26);
            this.ribbonPanel3.Name = "ribbonPanel3";
            this.ribbonPanel3.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel3.Size = new System.Drawing.Size(826, 224);
            // 
            // 
            // 
            this.ribbonPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel3.TabIndex = 3;
            this.ribbonPanel3.Visible = false;
            // 
            // FlxAccounting
            // 
            this.FlxAccounting.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.FlxAccounting.ColumnInfo = resources.GetString("FlxAccounting.ColumnInfo");
            this.FlxAccounting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlxAccounting.Location = new System.Drawing.Point(3, 0);
            this.FlxAccounting.Name = "FlxAccounting";
            this.FlxAccounting.Rows.Count = 11;
            this.FlxAccounting.Rows.DefaultSize = 19;
            this.FlxAccounting.Size = new System.Drawing.Size(820, 221);
            this.FlxAccounting.TabIndex = 11;
            this.FlxAccounting.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue;
            // 
            // ribbonPanel4
            // 
            this.ribbonPanel4.AutoSize = true;
            this.ribbonPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel4.Controls.Add(this.FlxSRep);
            this.ribbonPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel4.Location = new System.Drawing.Point(0, 26);
            this.ribbonPanel4.Name = "ribbonPanel4";
            this.ribbonPanel4.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel4.Size = new System.Drawing.Size(826, 224);
            // 
            // 
            // 
            this.ribbonPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel4.TabIndex = 4;
            this.ribbonPanel4.Visible = false;
            // 
            // FlxSRep
            // 
            this.FlxSRep.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.FlxSRep.ColumnInfo = resources.GetString("FlxSRep.ColumnInfo");
            this.FlxSRep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlxSRep.Location = new System.Drawing.Point(3, 0);
            this.FlxSRep.Name = "FlxSRep";
            this.FlxSRep.Rows.Count = 31;
            this.FlxSRep.Rows.DefaultSize = 19;
            this.FlxSRep.Size = new System.Drawing.Size(820, 221);
            this.FlxSRep.TabIndex = 13;
            this.FlxSRep.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue;
            // 
            // ribbonPanel5
            // 
            this.ribbonPanel5.AutoSize = true;
            this.ribbonPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel5.Controls.Add(this.FlxAccRep);
            this.ribbonPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel5.Location = new System.Drawing.Point(0, 26);
            this.ribbonPanel5.Name = "ribbonPanel5";
            this.ribbonPanel5.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel5.Size = new System.Drawing.Size(826, 224);
            // 
            // 
            // 
            this.ribbonPanel5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel5.TabIndex = 5;
            this.ribbonPanel5.Visible = false;
            // 
            // FlxAccRep
            // 
            this.FlxAccRep.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.FlxAccRep.ColumnInfo = resources.GetString("FlxAccRep.ColumnInfo");
            this.FlxAccRep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlxAccRep.Location = new System.Drawing.Point(3, 0);
            this.FlxAccRep.Name = "FlxAccRep";
            this.FlxAccRep.Rows.Count = 15;
            this.FlxAccRep.Rows.DefaultSize = 19;
            this.FlxAccRep.Size = new System.Drawing.Size(820, 221);
            this.FlxAccRep.TabIndex = 14;
            this.FlxAccRep.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue;
            // 
            // ribbonPanel7
            // 
            this.ribbonPanel7.AutoSize = true;
            this.ribbonPanel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ribbonPanel7.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel7.Controls.Add(this.chk23);
            this.ribbonPanel7.Controls.Add(this.groupBox1);
            this.ribbonPanel7.Controls.Add(this.chk21);
            this.ribbonPanel7.Controls.Add(this.chk20);
            this.ribbonPanel7.Controls.Add(this.chk19);
            this.ribbonPanel7.Controls.Add(this.chk18);
            this.ribbonPanel7.Controls.Add(this.chk17);
            this.ribbonPanel7.Controls.Add(this.chk15);
            this.ribbonPanel7.Controls.Add(this.chk14);
            this.ribbonPanel7.Controls.Add(this.chk12);
            this.ribbonPanel7.Controls.Add(this.CmbInvPriceStop);
            this.ribbonPanel7.Controls.Add(this.label15);
            this.ribbonPanel7.Controls.Add(this.CmbSendOption);
            this.ribbonPanel7.Controls.Add(this.label14);
            this.ribbonPanel7.Controls.Add(this.CmbInvPrice);
            this.ribbonPanel7.Controls.Add(this.label13);
            this.ribbonPanel7.Controls.Add(this.chk10);
            this.ribbonPanel7.Controls.Add(this.chk9);
            this.ribbonPanel7.Controls.Add(this.chk8);
            this.ribbonPanel7.Controls.Add(this.chk6);
            this.ribbonPanel7.Controls.Add(this.chk5);
            this.ribbonPanel7.Controls.Add(this.chk1);
            this.ribbonPanel7.Controls.Add(this.chk2);
            this.ribbonPanel7.Controls.Add(this.chk3);
            this.ribbonPanel7.Controls.Add(this.chk7);
            this.ribbonPanel7.Controls.Add(this.chk4);
            this.ribbonPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel7.Location = new System.Drawing.Point(0, 26);
            this.ribbonPanel7.Name = "ribbonPanel7";
            this.ribbonPanel7.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.netResize1.SetResizeChildren(this.ribbonPanel7, false);
            this.netResize1.SetResizeControl(this.ribbonPanel7, false);
            this.netResize1.SetResizeFont(this.ribbonPanel7, false);
            this.ribbonPanel7.Size = new System.Drawing.Size(826, 224);
            // 
            // 
            // 
            this.ribbonPanel7.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel7.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel7.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel7.TabIndex = 7;
            this.ribbonPanel7.Visible = false;
            // 
            // chk23
            // 
            this.chk23.AutoSize = true;
            this.chk23.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk23.Location = new System.Drawing.Point(327, 114);
            this.chk23.Name = "chk23";
            this.chk23.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk23.Size = new System.Drawing.Size(154, 15);
            this.chk23.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk23.TabIndex = 1004;
            this.chk23.Text = "إظهار لوحة المعلومات السريعة";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.textBox_MaxDis);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Location = new System.Drawing.Point(13, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 73);
            this.groupBox1.TabIndex = 1003;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "الحد الأقصى لنسبة الخصم";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label23.Location = new System.Drawing.Point(7, 50);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(18, 13);
            this.label23.TabIndex = 937;
            this.label23.Text = "%";
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label25.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label25.ForeColor = System.Drawing.Color.Red;
            this.label25.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label25.Location = new System.Drawing.Point(30, 24);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(177, 20);
            this.label25.TabIndex = 934;
            this.label25.Text = "المبيعات ومرتجع المبيعات";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_MaxDis
            // 
            this.textBox_MaxDis.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_MaxDis.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.textBox_MaxDis.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_MaxDis.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_MaxDis.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_MaxDis.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_MaxDis.Increment = 1D;
            this.textBox_MaxDis.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_MaxDis.Location = new System.Drawing.Point(30, 46);
            this.textBox_MaxDis.MaxValue = 100D;
            this.textBox_MaxDis.MinValue = 0D;
            this.textBox_MaxDis.Name = "textBox_MaxDis";
            this.textBox_MaxDis.Size = new System.Drawing.Size(177, 20);
            this.textBox_MaxDis.TabIndex = 6;
            // 
            // chk21
            // 
            this.chk21.AutoSize = true;
            this.chk21.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk21.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk21.Location = new System.Drawing.Point(282, 93);
            this.chk21.Name = "chk21";
            this.chk21.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk21.Size = new System.Drawing.Size(199, 15);
            this.chk21.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk21.TabIndex = 1002;
            this.chk21.Text = "عدم السماح بتكرار أرقام الجوالات للعملاء";
            // 
            // chk20
            // 
            this.chk20.AutoSize = true;
            this.chk20.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk20.Location = new System.Drawing.Point(292, 72);
            this.chk20.Name = "chk20";
            this.chk20.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk20.Size = new System.Drawing.Size(189, 15);
            this.chk20.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk20.TabIndex = 1001;
            this.chk20.Text = "انهاء الفواتير المعلقة قبل اغلاق النافذة";
            // 
            // chk19
            // 
            this.chk19.AutoSize = true;
            this.chk19.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk19.Location = new System.Drawing.Point(334, 51);
            this.chk19.Name = "chk19";
            this.chk19.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk19.Size = new System.Drawing.Size(147, 15);
            this.chk19.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk19.TabIndex = 1000;
            this.chk19.Text = "إيقــــاف خصــــــم الفـــاتــورة";
            // 
            // chk18
            // 
            this.chk18.AutoSize = true;
            this.chk18.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk18.Location = new System.Drawing.Point(281, 30);
            this.chk18.Name = "chk18";
            this.chk18.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk18.Size = new System.Drawing.Size(200, 15);
            this.chk18.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk18.TabIndex = 999;
            this.chk18.Text = "إيقاف خصـــم سطـــور الأصنــاف للفواتــير";
            // 
            // chk17
            // 
            this.chk17.AutoSize = true;
            this.chk17.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk17.Location = new System.Drawing.Point(265, 9);
            this.chk17.Name = "chk17";
            this.chk17.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk17.Size = new System.Drawing.Size(216, 15);
            this.chk17.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk17.TabIndex = 998;
            this.chk17.Text = "إرسال رسالة تاكيد للعميل الجديد قبل الحفظ";
            // 
            // chk15
            // 
            this.chk15.AutoSize = true;
            this.chk15.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk15.Location = new System.Drawing.Point(602, 198);
            this.chk15.Name = "chk15";
            this.chk15.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk15.Size = new System.Drawing.Size(208, 15);
            this.chk15.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk15.TabIndex = 997;
            this.chk15.Text = "السماح بادخال واخراج البضاعة بدون كميات";
            // 
            // chk14
            // 
            this.chk14.AutoSize = true;
            this.chk14.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk14.Location = new System.Drawing.Point(500, 72);
            this.chk14.Name = "chk14";
            this.chk14.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk14.Size = new System.Drawing.Size(310, 15);
            this.chk14.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk14.TabIndex = 996;
            this.chk14.Text = "عدم السماح بالبيع في حال صافي الفاتورة اقل من إجمالي التكلفة";
            // 
            // chk12
            // 
            this.chk12.AutoSize = true;
            this.chk12.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk12.Location = new System.Drawing.Point(574, 177);
            this.chk12.Name = "chk12";
            this.chk12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk12.Size = new System.Drawing.Size(236, 15);
            this.chk12.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk12.TabIndex = 995;
            this.chk12.Text = "السماح بإرجاع صنف بدون اصدار فاتورة مبيعات لها";
            // 
            // CmbInvPriceStop
            // 
            this.CmbInvPriceStop.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbInvPriceStop.DisplayMember = "Text";
            this.CmbInvPriceStop.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbInvPriceStop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbInvPriceStop.FormattingEnabled = true;
            this.CmbInvPriceStop.ItemHeight = 14;
            this.CmbInvPriceStop.Location = new System.Drawing.Point(14, 191);
            this.CmbInvPriceStop.Name = "CmbInvPriceStop";
            this.CmbInvPriceStop.Size = new System.Drawing.Size(222, 20);
            this.CmbInvPriceStop.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbInvPriceStop.TabIndex = 993;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.Maroon;
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(33, 174);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(184, 13);
            this.label15.TabIndex = 994;
            this.label15.Text = "عدم السماح بالبيــع بسعـر يتجـــاوز";
            // 
            // CmbSendOption
            // 
            this.CmbSendOption.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbSendOption.DisplayMember = "Text";
            this.CmbSendOption.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbSendOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSendOption.FormattingEnabled = true;
            this.CmbSendOption.ItemHeight = 14;
            this.CmbSendOption.Location = new System.Drawing.Point(14, 111);
            this.CmbSendOption.Name = "CmbSendOption";
            this.CmbSendOption.Size = new System.Drawing.Size(222, 20);
            this.CmbSendOption.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbSendOption.TabIndex = 991;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.Maroon;
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(31, 94);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(191, 13);
            this.label14.TabIndex = 992;
            this.label14.Text = "خيارات الرسائل عند ترحيل الصندوق";
            // 
            // CmbInvPrice
            // 
            this.CmbInvPrice.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbInvPrice.DisplayMember = "Text";
            this.CmbInvPrice.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbInvPrice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbInvPrice.FormattingEnabled = true;
            this.CmbInvPrice.ItemHeight = 14;
            this.CmbInvPrice.Location = new System.Drawing.Point(14, 151);
            this.CmbInvPrice.Name = "CmbInvPrice";
            this.CmbInvPrice.Size = new System.Drawing.Size(222, 20);
            this.CmbInvPrice.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbInvPrice.TabIndex = 989;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.Maroon;
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(31, 134);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(188, 13);
            this.label13.TabIndex = 990;
            this.label13.Text = "البيع حسب سعر البيع الإفتراضي و ";
            // 
            // chk10
            // 
            this.chk10.AutoSize = true;
            this.chk10.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk10.Location = new System.Drawing.Point(583, 156);
            this.chk10.Name = "chk10";
            this.chk10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk10.Size = new System.Drawing.Size(227, 15);
            this.chk10.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk10.TabIndex = 986;
            this.chk10.Text = "السماح بحفظ الفاتورة التي اجمالي قيمتها صفر";
            // 
            // chk9
            // 
            this.chk9.AutoSize = true;
            this.chk9.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk9.Location = new System.Drawing.Point(537, 135);
            this.chk9.Name = "chk9";
            this.chk9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk9.Size = new System.Drawing.Size(273, 15);
            this.chk9.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk9.TabIndex = 985;
            this.chk9.Text = "السماح بحفظ رقم التصنيع في الفاتورة دون تاريخ الصلاحية";
            // 
            // chk8
            // 
            this.chk8.AutoSize = true;
            this.chk8.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk8.Location = new System.Drawing.Point(537, 114);
            this.chk8.Name = "chk8";
            this.chk8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk8.Size = new System.Drawing.Size(273, 15);
            this.chk8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk8.TabIndex = 984;
            this.chk8.Text = "السماح بحفظ تاريخ الصلاحية في الفاتورة دون رقم التصنيع";
            // 
            // chk6
            // 
            this.chk6.AutoSize = true;
            this.chk6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk6.Location = new System.Drawing.Point(44, 534);
            this.chk6.Name = "chk6";
            this.chk6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk6.Size = new System.Drawing.Size(175, 15);
            this.chk6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk6.TabIndex = 19;
            this.chk6.Text = "السماح بالبيع بأقل من سعر الوحدة";
            // 
            // chk5
            // 
            this.chk5.AutoSize = true;
            this.chk5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk5.Location = new System.Drawing.Point(26, 462);
            this.chk5.Name = "chk5";
            this.chk5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk5.Size = new System.Drawing.Size(192, 15);
            this.chk5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk5.TabIndex = 983;
            this.chk5.Text = "ظهور التنبيه التلقائي الخاص بالموظفين";
            // 
            // chk1
            // 
            this.chk1.AutoSize = true;
            this.chk1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk1.Location = new System.Drawing.Point(76, 498);
            this.chk1.Name = "chk1";
            this.chk1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk1.Size = new System.Drawing.Size(144, 15);
            this.chk1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk1.TabIndex = 16;
            this.chk1.Text = "السماح بتعديل سعر التكلفة";
            // 
            // chk2
            // 
            this.chk2.AutoSize = true;
            this.chk2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk2.Location = new System.Drawing.Point(536, 30);
            this.chk2.Name = "chk2";
            this.chk2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk2.Size = new System.Drawing.Size(274, 15);
            this.chk2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk2.TabIndex = 17;
            this.chk2.Text = "السماح بالبيع حتى لو ان الكمية اصغر من او يساوي الصفر";
            // 
            // chk3
            // 
            this.chk3.AutoSize = true;
            this.chk3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk3.Location = new System.Drawing.Point(585, 51);
            this.chk3.Name = "chk3";
            this.chk3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk3.Size = new System.Drawing.Size(225, 15);
            this.chk3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk3.TabIndex = 18;
            this.chk3.Text = "السماح بالبيع بسعر اقل من سعر تكلفة الصنف";
            // 
            // chk7
            // 
            this.chk7.AutoSize = true;
            this.chk7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk7.Location = new System.Drawing.Point(658, 9);
            this.chk7.Name = "chk7";
            this.chk7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk7.Size = new System.Drawing.Size(152, 15);
            this.chk7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk7.TabIndex = 15;
            this.chk7.Text = "ظهور سعر التكلفة في الفواتير";
            // 
            // chk4
            // 
            this.chk4.AutoSize = true;
            this.chk4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk4.Location = new System.Drawing.Point(560, 93);
            this.chk4.Name = "chk4";
            this.chk4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk4.Size = new System.Drawing.Size(250, 15);
            this.chk4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk4.TabIndex = 20;
            this.chk4.Text = "السماح بالتجاوز عن الحد المديونية للعملاء والموردين";
            // 
            // ribbonPanel9
            // 
            this.ribbonPanel9.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel9.Controls.Add(this.navigationPane_Eqar);
            this.ribbonPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel9.Location = new System.Drawing.Point(0, 26);
            this.ribbonPanel9.Name = "ribbonPanel9";
            this.ribbonPanel9.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel9.Size = new System.Drawing.Size(826, 224);
            // 
            // 
            // 
            this.ribbonPanel9.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel9.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel9.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel9.TabIndex = 10;
            this.ribbonPanel9.Visible = false;
            // 
            // navigationPane_Eqar
            // 
            this.navigationPane_Eqar.BackColor = System.Drawing.Color.White;
            this.navigationPane_Eqar.CanCollapse = true;
            this.navigationPane_Eqar.ConfigureItemVisible = false;
            this.navigationPane_Eqar.Controls.Add(this.navigationPanePanel11);
            this.navigationPane_Eqar.Controls.Add(this.navigationPanePanel13);
            this.navigationPane_Eqar.Controls.Add(this.navigationPanePanel12);
            this.navigationPane_Eqar.Controls.Add(this.navigationPanePanel10);
            this.navigationPane_Eqar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPane_Eqar.ForeColor = System.Drawing.Color.Black;
            this.navigationPane_Eqar.ItemPaddingBottom = 2;
            this.navigationPane_Eqar.ItemPaddingTop = 2;
            this.navigationPane_Eqar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.EqarGenarl,
            this.EqarsRep,
            this.EqarTenant,
            this.EqarFiles});
            this.navigationPane_Eqar.Location = new System.Drawing.Point(3, 0);
            this.navigationPane_Eqar.Name = "navigationPane_Eqar";
            this.navigationPane_Eqar.NavigationBarHeight = 36;
            this.navigationPane_Eqar.Padding = new System.Windows.Forms.Padding(1);
            this.navigationPane_Eqar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.navigationPane_Eqar.Size = new System.Drawing.Size(820, 221);
            this.navigationPane_Eqar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.navigationPane_Eqar.TabIndex = 986;
            // 
            // 
            // 
            this.navigationPane_Eqar.TitlePanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.navigationPane_Eqar.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.navigationPane_Eqar.TitlePanel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.navigationPane_Eqar.TitlePanel.Location = new System.Drawing.Point(1, 1);
            this.navigationPane_Eqar.TitlePanel.Name = "panelEx1";
            this.navigationPane_Eqar.TitlePanel.Size = new System.Drawing.Size(818, 24);
            this.navigationPane_Eqar.TitlePanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.navigationPane_Eqar.TitlePanel.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.navigationPane_Eqar.TitlePanel.Style.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.navigationPane_Eqar.TitlePanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.navigationPane_Eqar.TitlePanel.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom;
            this.navigationPane_Eqar.TitlePanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.navigationPane_Eqar.TitlePanel.Style.GradientAngle = 90;
            this.navigationPane_Eqar.TitlePanel.Style.MarginLeft = 4;
            this.navigationPane_Eqar.TitlePanel.TabIndex = 0;
            this.navigationPane_Eqar.TitlePanel.Text = "المستأجـــرين";
            // 
            // navigationPanePanel11
            // 
            this.navigationPanePanel11.AutoSize = true;
            this.navigationPanePanel11.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.navigationPanePanel11.Controls.Add(this.dataGridViewX_EqarFiles);
            this.navigationPanePanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanePanel11.Location = new System.Drawing.Point(1, 25);
            this.navigationPanePanel11.Name = "navigationPanePanel11";
            this.navigationPanePanel11.ParentItem = this.EqarFiles;
            this.navigationPanePanel11.Size = new System.Drawing.Size(818, 159);
            this.navigationPanePanel11.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel11.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.navigationPanePanel11.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            this.navigationPanePanel11.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.navigationPanePanel11.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.navigationPanePanel11.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.navigationPanePanel11.Style.GradientAngle = 90;
            this.navigationPanePanel11.Style.WordWrap = true;
            this.navigationPanePanel11.StyleMouseDown.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel11.StyleMouseDown.WordWrap = true;
            this.navigationPanePanel11.StyleMouseOver.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel11.StyleMouseOver.WordWrap = true;
            this.navigationPanePanel11.TabIndex = 6;
            this.navigationPanePanel11.Text = "Drop your controls here and erase Text property";
            // 
            // dataGridViewX_EqarFiles
            // 
            this.dataGridViewX_EqarFiles.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.dataGridViewX_EqarFiles.ColumnInfo = resources.GetString("dataGridViewX_EqarFiles.ColumnInfo");
            this.dataGridViewX_EqarFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX_EqarFiles.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX_EqarFiles.Name = "dataGridViewX_EqarFiles";
            this.dataGridViewX_EqarFiles.Rows.Count = 8;
            this.dataGridViewX_EqarFiles.Rows.DefaultSize = 19;
            this.dataGridViewX_EqarFiles.Size = new System.Drawing.Size(818, 159);
            this.dataGridViewX_EqarFiles.TabIndex = 20;
            this.dataGridViewX_EqarFiles.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue;
            // 
            // EqarFiles
            // 
            this.EqarFiles.Checked = true;
            this.EqarFiles.Image = ((System.Drawing.Image)(resources.GetObject("EqarFiles.Image")));
            this.EqarFiles.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.EqarFiles.Name = "EqarFiles";
            this.EqarFiles.OptionGroup = "navBar";
            this.EqarFiles.SubItemsExpandWidth = 11;
            this.EqarFiles.Symbol = "";
            this.EqarFiles.Text = "الملفــــات";
            this.EqarFiles.Tooltip = "إضغط هنا لعرض صلاحيات الملفــــات";
            // 
            // navigationPanePanel13
            // 
            this.navigationPanePanel13.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.navigationPanePanel13.Controls.Add(this.dataGridViewX_GenralEqar);
            this.navigationPanePanel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanePanel13.Location = new System.Drawing.Point(1, 1);
            this.navigationPanePanel13.Name = "navigationPanePanel13";
            this.navigationPanePanel13.Padding = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.navigationPanePanel13.ParentItem = this.EqarGenarl;
            this.navigationPanePanel13.Size = new System.Drawing.Size(818, 183);
            this.navigationPanePanel13.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel13.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.navigationPanePanel13.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            this.navigationPanePanel13.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.navigationPanePanel13.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.navigationPanePanel13.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.navigationPanePanel13.Style.GradientAngle = 90;
            this.navigationPanePanel13.StyleMouseDown.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel13.StyleMouseOver.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel13.TabIndex = 2;
            // 
            // dataGridViewX_GenralEqar
            // 
            this.dataGridViewX_GenralEqar.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.dataGridViewX_GenralEqar.ColumnInfo = resources.GetString("dataGridViewX_GenralEqar.ColumnInfo");
            this.dataGridViewX_GenralEqar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX_GenralEqar.Location = new System.Drawing.Point(1, 1);
            this.dataGridViewX_GenralEqar.Name = "dataGridViewX_GenralEqar";
            this.dataGridViewX_GenralEqar.Rows.Count = 2;
            this.dataGridViewX_GenralEqar.Rows.DefaultSize = 19;
            this.dataGridViewX_GenralEqar.Size = new System.Drawing.Size(816, 182);
            this.dataGridViewX_GenralEqar.TabIndex = 12;
            this.dataGridViewX_GenralEqar.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue;
            // 
            // EqarGenarl
            // 
            this.EqarGenarl.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.EqarGenarl.Name = "EqarGenarl";
            this.EqarGenarl.OptionGroup = "navBar";
            this.EqarGenarl.SubItemsExpandWidth = 11;
            this.EqarGenarl.Symbol = "";
            // 
            // navigationPanePanel12
            // 
            this.navigationPanePanel12.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.navigationPanePanel12.Controls.Add(this.dataGridViewX_Tenants);
            this.navigationPanePanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanePanel12.Location = new System.Drawing.Point(1, 1);
            this.navigationPanePanel12.Name = "navigationPanePanel12";
            this.navigationPanePanel12.ParentItem = this.EqarTenant;
            this.navigationPanePanel12.Size = new System.Drawing.Size(818, 183);
            this.navigationPanePanel12.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel12.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.navigationPanePanel12.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            this.navigationPanePanel12.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.navigationPanePanel12.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.navigationPanePanel12.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.navigationPanePanel12.Style.GradientAngle = 90;
            this.navigationPanePanel12.Style.WordWrap = true;
            this.navigationPanePanel12.StyleMouseDown.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel12.StyleMouseDown.WordWrap = true;
            this.navigationPanePanel12.StyleMouseOver.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel12.StyleMouseOver.WordWrap = true;
            this.navigationPanePanel12.TabIndex = 5;
            this.navigationPanePanel12.Text = "Drop your controls here and erase Text property";
            // 
            // dataGridViewX_Tenants
            // 
            this.dataGridViewX_Tenants.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.dataGridViewX_Tenants.ColumnInfo = resources.GetString("dataGridViewX_Tenants.ColumnInfo");
            this.dataGridViewX_Tenants.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX_Tenants.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX_Tenants.Name = "dataGridViewX_Tenants";
            this.dataGridViewX_Tenants.Rows.Count = 5;
            this.dataGridViewX_Tenants.Rows.DefaultSize = 19;
            this.dataGridViewX_Tenants.Size = new System.Drawing.Size(818, 183);
            this.dataGridViewX_Tenants.TabIndex = 21;
            this.dataGridViewX_Tenants.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue;
            // 
            // EqarTenant
            // 
            this.EqarTenant.Image = ((System.Drawing.Image)(resources.GetObject("EqarTenant.Image")));
            this.EqarTenant.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.EqarTenant.Name = "EqarTenant";
            this.EqarTenant.OptionGroup = "navBar";
            this.EqarTenant.SubItemsExpandWidth = 11;
            this.EqarTenant.Symbol = "";
            this.EqarTenant.Text = "المستأجـــرين";
            this.EqarTenant.Tooltip = "إضغط هنا لعرض صلاحيات المستأجرين";
            // 
            // navigationPanePanel10
            // 
            this.navigationPanePanel10.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.navigationPanePanel10.Controls.Add(this.dataGridViewX_RepEqar);
            this.navigationPanePanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanePanel10.Location = new System.Drawing.Point(1, 1);
            this.navigationPanePanel10.Name = "navigationPanePanel10";
            this.navigationPanePanel10.ParentItem = this.EqarsRep;
            this.navigationPanePanel10.Size = new System.Drawing.Size(818, 183);
            this.navigationPanePanel10.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel10.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.navigationPanePanel10.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            this.navigationPanePanel10.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.navigationPanePanel10.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.navigationPanePanel10.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.navigationPanePanel10.Style.GradientAngle = 90;
            this.navigationPanePanel10.Style.WordWrap = true;
            this.navigationPanePanel10.StyleMouseDown.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel10.StyleMouseDown.WordWrap = true;
            this.navigationPanePanel10.StyleMouseOver.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel10.StyleMouseOver.WordWrap = true;
            this.navigationPanePanel10.TabIndex = 3;
            this.navigationPanePanel10.Text = "Drop your controls here and erase Text property";
            // 
            // dataGridViewX_RepEqar
            // 
            this.dataGridViewX_RepEqar.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.dataGridViewX_RepEqar.ColumnInfo = resources.GetString("dataGridViewX_RepEqar.ColumnInfo");
            this.dataGridViewX_RepEqar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX_RepEqar.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX_RepEqar.Name = "dataGridViewX_RepEqar";
            this.dataGridViewX_RepEqar.Rows.Count = 7;
            this.dataGridViewX_RepEqar.Rows.DefaultSize = 19;
            this.dataGridViewX_RepEqar.Size = new System.Drawing.Size(818, 183);
            this.dataGridViewX_RepEqar.TabIndex = 11;
            this.dataGridViewX_RepEqar.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue;
            // 
            // EqarsRep
            // 
            this.EqarsRep.Image = ((System.Drawing.Image)(resources.GetObject("EqarsRep.Image")));
            this.EqarsRep.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.EqarsRep.Name = "EqarsRep";
            this.EqarsRep.OptionGroup = "navBar";
            this.EqarsRep.SubItemsExpandWidth = 11;
            this.EqarsRep.Symbol = "";
            this.EqarsRep.Text = "التقـــارير";
            this.EqarsRep.Tooltip = "إضغط هنا لعرض صلاحيات التقـــارير";
            // 
            // ribbonTabItem_Hotel
            // 
            this.ribbonTabItem_Hotel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonTabItem_Hotel.Controls.Add(this.navigationPane_Hotel);
            this.ribbonTabItem_Hotel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonTabItem_Hotel.Location = new System.Drawing.Point(0, 26);
            this.ribbonTabItem_Hotel.Name = "ribbonTabItem_Hotel";
            this.ribbonTabItem_Hotel.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonTabItem_Hotel.Size = new System.Drawing.Size(826, 224);
            // 
            // 
            // 
            this.ribbonTabItem_Hotel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonTabItem_Hotel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonTabItem_Hotel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonTabItem_Hotel.TabIndex = 9;
            this.ribbonTabItem_Hotel.Visible = false;
            // 
            // navigationPane_Hotel
            // 
            this.navigationPane_Hotel.BackColor = System.Drawing.Color.White;
            this.navigationPane_Hotel.CanCollapse = true;
            this.navigationPane_Hotel.ConfigureItemVisible = false;
            this.navigationPane_Hotel.Controls.Add(this.navigationPanePanel6);
            this.navigationPane_Hotel.Controls.Add(this.navigationPanePanel9);
            this.navigationPane_Hotel.Controls.Add(this.navigationPanePanel8);
            this.navigationPane_Hotel.Controls.Add(this.navigationPanePanel7);
            this.navigationPane_Hotel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPane_Hotel.ForeColor = System.Drawing.Color.Black;
            this.navigationPane_Hotel.ItemPaddingBottom = 2;
            this.navigationPane_Hotel.ItemPaddingTop = 2;
            this.navigationPane_Hotel.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.HotelGenralPre,
            this.HotelRepPre,
            this.HotelMovePre,
            this.HotelMenuPer});
            this.navigationPane_Hotel.Location = new System.Drawing.Point(3, 0);
            this.navigationPane_Hotel.Name = "navigationPane_Hotel";
            this.navigationPane_Hotel.NavigationBarHeight = 36;
            this.navigationPane_Hotel.Padding = new System.Windows.Forms.Padding(1);
            this.navigationPane_Hotel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.navigationPane_Hotel.Size = new System.Drawing.Size(820, 221);
            this.navigationPane_Hotel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.navigationPane_Hotel.TabIndex = 986;
            // 
            // 
            // 
            this.navigationPane_Hotel.TitlePanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.navigationPane_Hotel.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.navigationPane_Hotel.TitlePanel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.navigationPane_Hotel.TitlePanel.Location = new System.Drawing.Point(1, 1);
            this.navigationPane_Hotel.TitlePanel.Name = "panelEx1";
            this.navigationPane_Hotel.TitlePanel.Size = new System.Drawing.Size(818, 24);
            this.navigationPane_Hotel.TitlePanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.navigationPane_Hotel.TitlePanel.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.navigationPane_Hotel.TitlePanel.Style.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.navigationPane_Hotel.TitlePanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.navigationPane_Hotel.TitlePanel.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom;
            this.navigationPane_Hotel.TitlePanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.navigationPane_Hotel.TitlePanel.Style.GradientAngle = 90;
            this.navigationPane_Hotel.TitlePanel.Style.MarginLeft = 4;
            this.navigationPane_Hotel.TitlePanel.TabIndex = 0;
            this.navigationPane_Hotel.TitlePanel.Text = "الملفـــات";
            // 
            // navigationPanePanel6
            // 
            this.navigationPanePanel6.AutoSize = true;
            this.navigationPanePanel6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.navigationPanePanel6.Controls.Add(this.dataGridViewX_HotelMenuPer);
            this.navigationPanePanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanePanel6.Location = new System.Drawing.Point(1, 25);
            this.navigationPanePanel6.Name = "navigationPanePanel6";
            this.navigationPanePanel6.ParentItem = this.HotelMenuPer;
            this.navigationPanePanel6.Size = new System.Drawing.Size(818, 159);
            this.navigationPanePanel6.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel6.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.navigationPanePanel6.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            this.navigationPanePanel6.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.navigationPanePanel6.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.navigationPanePanel6.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.navigationPanePanel6.Style.GradientAngle = 90;
            this.navigationPanePanel6.Style.WordWrap = true;
            this.navigationPanePanel6.StyleMouseDown.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel6.StyleMouseDown.WordWrap = true;
            this.navigationPanePanel6.StyleMouseOver.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel6.StyleMouseOver.WordWrap = true;
            this.navigationPanePanel6.TabIndex = 6;
            this.navigationPanePanel6.Text = "Drop your controls here and erase Text property";
            // 
            // dataGridViewX_HotelMenuPer
            // 
            this.dataGridViewX_HotelMenuPer.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.dataGridViewX_HotelMenuPer.ColumnInfo = resources.GetString("dataGridViewX_HotelMenuPer.ColumnInfo");
            this.dataGridViewX_HotelMenuPer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX_HotelMenuPer.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX_HotelMenuPer.Name = "dataGridViewX_HotelMenuPer";
            this.dataGridViewX_HotelMenuPer.Rows.Count = 5;
            this.dataGridViewX_HotelMenuPer.Rows.DefaultSize = 19;
            this.dataGridViewX_HotelMenuPer.Size = new System.Drawing.Size(818, 159);
            this.dataGridViewX_HotelMenuPer.TabIndex = 20;
            this.dataGridViewX_HotelMenuPer.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue;
            // 
            // HotelMenuPer
            // 
            this.HotelMenuPer.Checked = true;
            this.HotelMenuPer.Image = ((System.Drawing.Image)(resources.GetObject("HotelMenuPer.Image")));
            this.HotelMenuPer.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.HotelMenuPer.Name = "HotelMenuPer";
            this.HotelMenuPer.OptionGroup = "navBar";
            this.HotelMenuPer.SubItemsExpandWidth = 11;
            this.HotelMenuPer.Symbol = "";
            this.HotelMenuPer.Text = "الملفـــات";
            this.HotelMenuPer.Tooltip = "إضغط هنا لعرض صلاحيات الملفات";
            // 
            // navigationPanePanel9
            // 
            this.navigationPanePanel9.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.navigationPanePanel9.Controls.Add(this.panel_Prices);
            this.navigationPanePanel9.Controls.Add(this.dataGridViewX_HotelGenralPre);
            this.navigationPanePanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanePanel9.Location = new System.Drawing.Point(1, 1);
            this.navigationPanePanel9.Name = "navigationPanePanel9";
            this.navigationPanePanel9.Padding = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.navigationPanePanel9.ParentItem = this.HotelGenralPre;
            this.navigationPanePanel9.Size = new System.Drawing.Size(818, 183);
            this.navigationPanePanel9.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel9.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.navigationPanePanel9.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            this.navigationPanePanel9.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.navigationPanePanel9.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.navigationPanePanel9.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.navigationPanePanel9.Style.GradientAngle = 90;
            this.navigationPanePanel9.StyleMouseDown.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel9.StyleMouseOver.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel9.TabIndex = 2;
            // 
            // panel_Prices
            // 
            this.panel_Prices.Controls.Add(this.chk13);
            this.panel_Prices.Controls.Add(this.label18);
            this.panel_Prices.Controls.Add(this.Combo1);
            this.panel_Prices.Controls.Add(this.label17);
            this.panel_Prices.Controls.Add(this.Combo3);
            this.panel_Prices.Controls.Add(this.label16);
            this.panel_Prices.Location = new System.Drawing.Point(5, 4);
            this.panel_Prices.Name = "panel_Prices";
            this.panel_Prices.Size = new System.Drawing.Size(231, 152);
            this.panel_Prices.TabIndex = 118;
            // 
            // chk13
            // 
            this.chk13.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk13.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.chk13.BackgroundStyle.BorderBottomWidth = 1;
            this.chk13.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionBackground;
            this.chk13.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.chk13.BackgroundStyle.BorderLeftWidth = 1;
            this.chk13.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.chk13.BackgroundStyle.BorderRightWidth = 1;
            this.chk13.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.chk13.BackgroundStyle.BorderTopWidth = 1;
            this.chk13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk13.Location = new System.Drawing.Point(9, 120);
            this.chk13.Name = "chk13";
            this.chk13.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk13.Size = new System.Drawing.Size(206, 22);
            this.chk13.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk13.TabIndex = 123;
            this.chk13.Text = "السماح بحذف سندات النزلاء المغادرين";
            this.chk13.Visible = false;
            // 
            // label18
            // 
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label18.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(9, 10);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(206, 22);
            this.label18.TabIndex = 122;
            this.label18.Text = "أسعار الغرف المعتمدة";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Combo1
            // 
            this.Combo1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Combo1.DisplayMember = "Text";
            this.Combo1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Combo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo1.FormattingEnabled = true;
            this.Combo1.ItemHeight = 14;
            this.Combo1.Location = new System.Drawing.Point(9, 54);
            this.Combo1.Name = "Combo1";
            this.Combo1.Size = new System.Drawing.Size(122, 20);
            this.Combo1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Combo1.TabIndex = 120;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(135, 58);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(87, 13);
            this.label17.TabIndex = 121;
            this.label17.Text = "السعر اليومـــي :";
            // 
            // Combo3
            // 
            this.Combo3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Combo3.DisplayMember = "Text";
            this.Combo3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Combo3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo3.FormattingEnabled = true;
            this.Combo3.ItemHeight = 14;
            this.Combo3.Location = new System.Drawing.Point(9, 84);
            this.Combo3.Name = "Combo3";
            this.Combo3.Size = new System.Drawing.Size(122, 20);
            this.Combo3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Combo3.TabIndex = 118;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(135, 88);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(85, 13);
            this.label16.TabIndex = 119;
            this.label16.Text = "السعر الشهري :";
            // 
            // dataGridViewX_HotelGenralPre
            // 
            this.dataGridViewX_HotelGenralPre.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.dataGridViewX_HotelGenralPre.ColumnInfo = resources.GetString("dataGridViewX_HotelGenralPre.ColumnInfo");
            this.dataGridViewX_HotelGenralPre.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridViewX_HotelGenralPre.Location = new System.Drawing.Point(238, 1);
            this.dataGridViewX_HotelGenralPre.Name = "dataGridViewX_HotelGenralPre";
            this.dataGridViewX_HotelGenralPre.Rows.Count = 16;
            this.dataGridViewX_HotelGenralPre.Rows.DefaultSize = 19;
            this.dataGridViewX_HotelGenralPre.Size = new System.Drawing.Size(579, 182);
            this.dataGridViewX_HotelGenralPre.TabIndex = 12;
            this.dataGridViewX_HotelGenralPre.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue;
            // 
            // HotelGenralPre
            // 
            this.HotelGenralPre.Image = ((System.Drawing.Image)(resources.GetObject("HotelGenralPre.Image")));
            this.HotelGenralPre.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.HotelGenralPre.Name = "HotelGenralPre";
            this.HotelGenralPre.OptionGroup = "navBar";
            this.HotelGenralPre.SubItemsExpandWidth = 11;
            this.HotelGenralPre.Symbol = "";
            this.HotelGenralPre.Text = "عـــــــام";
            this.HotelGenralPre.Tooltip = "إضغط هنا لعرض الصلاحيــات العـامة";
            // 
            // navigationPanePanel8
            // 
            this.navigationPanePanel8.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.navigationPanePanel8.Controls.Add(this.dataGridViewX_HotelRepPre);
            this.navigationPanePanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanePanel8.Location = new System.Drawing.Point(1, 1);
            this.navigationPanePanel8.Name = "navigationPanePanel8";
            this.navigationPanePanel8.ParentItem = this.HotelRepPre;
            this.navigationPanePanel8.Size = new System.Drawing.Size(818, 183);
            this.navigationPanePanel8.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel8.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.navigationPanePanel8.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            this.navigationPanePanel8.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.navigationPanePanel8.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.navigationPanePanel8.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.navigationPanePanel8.Style.GradientAngle = 90;
            this.navigationPanePanel8.Style.WordWrap = true;
            this.navigationPanePanel8.StyleMouseDown.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel8.StyleMouseDown.WordWrap = true;
            this.navigationPanePanel8.StyleMouseOver.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel8.StyleMouseOver.WordWrap = true;
            this.navigationPanePanel8.TabIndex = 3;
            this.navigationPanePanel8.Text = "Drop your controls here and erase Text property";
            // 
            // dataGridViewX_HotelRepPre
            // 
            this.dataGridViewX_HotelRepPre.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.dataGridViewX_HotelRepPre.ColumnInfo = resources.GetString("dataGridViewX_HotelRepPre.ColumnInfo");
            this.dataGridViewX_HotelRepPre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX_HotelRepPre.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX_HotelRepPre.Name = "dataGridViewX_HotelRepPre";
            this.dataGridViewX_HotelRepPre.Rows.Count = 13;
            this.dataGridViewX_HotelRepPre.Rows.DefaultSize = 19;
            this.dataGridViewX_HotelRepPre.Size = new System.Drawing.Size(818, 183);
            this.dataGridViewX_HotelRepPre.TabIndex = 11;
            this.dataGridViewX_HotelRepPre.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue;
            // 
            // HotelRepPre
            // 
            this.HotelRepPre.Image = ((System.Drawing.Image)(resources.GetObject("HotelRepPre.Image")));
            this.HotelRepPre.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.HotelRepPre.Name = "HotelRepPre";
            this.HotelRepPre.OptionGroup = "navBar";
            this.HotelRepPre.SubItemsExpandWidth = 11;
            this.HotelRepPre.Symbol = "";
            this.HotelRepPre.Text = "التقـــارير";
            this.HotelRepPre.Tooltip = "إضغط هنا لعرض صلاحيات التقـــارير";
            // 
            // navigationPanePanel7
            // 
            this.navigationPanePanel7.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.navigationPanePanel7.Controls.Add(this.dataGridViewX_HotelMovePre);
            this.navigationPanePanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanePanel7.Location = new System.Drawing.Point(1, 1);
            this.navigationPanePanel7.Name = "navigationPanePanel7";
            this.navigationPanePanel7.ParentItem = this.HotelMovePre;
            this.navigationPanePanel7.Size = new System.Drawing.Size(818, 183);
            this.navigationPanePanel7.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel7.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.navigationPanePanel7.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            this.navigationPanePanel7.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.navigationPanePanel7.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.navigationPanePanel7.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.navigationPanePanel7.Style.GradientAngle = 90;
            this.navigationPanePanel7.Style.WordWrap = true;
            this.navigationPanePanel7.StyleMouseDown.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel7.StyleMouseDown.WordWrap = true;
            this.navigationPanePanel7.StyleMouseOver.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel7.StyleMouseOver.WordWrap = true;
            this.navigationPanePanel7.TabIndex = 5;
            this.navigationPanePanel7.Text = "Drop your controls here and erase Text property";
            // 
            // dataGridViewX_HotelMovePre
            // 
            this.dataGridViewX_HotelMovePre.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.dataGridViewX_HotelMovePre.ColumnInfo = resources.GetString("dataGridViewX_HotelMovePre.ColumnInfo");
            this.dataGridViewX_HotelMovePre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX_HotelMovePre.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX_HotelMovePre.Name = "dataGridViewX_HotelMovePre";
            this.dataGridViewX_HotelMovePre.Rows.Count = 8;
            this.dataGridViewX_HotelMovePre.Rows.DefaultSize = 19;
            this.dataGridViewX_HotelMovePre.Size = new System.Drawing.Size(818, 183);
            this.dataGridViewX_HotelMovePre.TabIndex = 21;
            this.dataGridViewX_HotelMovePre.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue;
            // 
            // HotelMovePre
            // 
            this.HotelMovePre.Image = ((System.Drawing.Image)(resources.GetObject("HotelMovePre.Image")));
            this.HotelMovePre.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.HotelMovePre.Name = "HotelMovePre";
            this.HotelMovePre.OptionGroup = "navBar";
            this.HotelMovePre.SubItemsExpandWidth = 11;
            this.HotelMovePre.Symbol = "";
            this.HotelMovePre.Text = "الحركـــات";
            this.HotelMovePre.Tooltip = "إضغط هنا لعرض صلاحيات الحــركــة";
            // 
            // ribbonPanel8
            // 
            this.ribbonPanel8.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel8.Controls.Add(this.navigationPane_Emps);
            this.ribbonPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel8.Location = new System.Drawing.Point(0, 26);
            this.ribbonPanel8.Name = "ribbonPanel8";
            this.ribbonPanel8.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel8.Size = new System.Drawing.Size(826, 224);
            // 
            // 
            // 
            this.ribbonPanel8.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel8.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel8.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel8.TabIndex = 8;
            this.ribbonPanel8.Visible = false;
            // 
            // navigationPane_Emps
            // 
            this.navigationPane_Emps.BackColor = System.Drawing.Color.White;
            this.navigationPane_Emps.CanCollapse = true;
            this.navigationPane_Emps.ConfigureItemVisible = false;
            this.navigationPane_Emps.Controls.Add(this.navigationPanePanel5);
            this.navigationPane_Emps.Controls.Add(this.navigationPanePanel3);
            this.navigationPane_Emps.Controls.Add(this.navigationPanePanel2);
            this.navigationPane_Emps.Controls.Add(this.navigationPanePanel4);
            this.navigationPane_Emps.Controls.Add(this.navigationPanePanel1);
            this.navigationPane_Emps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPane_Emps.ForeColor = System.Drawing.Color.Black;
            this.navigationPane_Emps.ItemPaddingBottom = 2;
            this.navigationPane_Emps.ItemPaddingTop = 2;
            this.navigationPane_Emps.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.GenralPre,
            this.RepPre,
            this.SalPer,
            this.MovePre,
            this.MenuPer});
            this.navigationPane_Emps.Location = new System.Drawing.Point(3, 0);
            this.navigationPane_Emps.Name = "navigationPane_Emps";
            this.navigationPane_Emps.NavigationBarHeight = 36;
            this.navigationPane_Emps.Padding = new System.Windows.Forms.Padding(1);
            this.navigationPane_Emps.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.navigationPane_Emps.Size = new System.Drawing.Size(820, 221);
            this.navigationPane_Emps.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.navigationPane_Emps.TabIndex = 985;
            // 
            // 
            // 
            this.navigationPane_Emps.TitlePanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.navigationPane_Emps.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.navigationPane_Emps.TitlePanel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.navigationPane_Emps.TitlePanel.Location = new System.Drawing.Point(1, 1);
            this.navigationPane_Emps.TitlePanel.Name = "panelEx1";
            this.navigationPane_Emps.TitlePanel.Size = new System.Drawing.Size(818, 24);
            this.navigationPane_Emps.TitlePanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.navigationPane_Emps.TitlePanel.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.navigationPane_Emps.TitlePanel.Style.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.navigationPane_Emps.TitlePanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.navigationPane_Emps.TitlePanel.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom;
            this.navigationPane_Emps.TitlePanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.navigationPane_Emps.TitlePanel.Style.GradientAngle = 90;
            this.navigationPane_Emps.TitlePanel.Style.MarginLeft = 4;
            this.navigationPane_Emps.TitlePanel.TabIndex = 0;
            this.navigationPane_Emps.TitlePanel.Text = "الكـــروت";
            // 
            // navigationPanePanel5
            // 
            this.navigationPanePanel5.AutoSize = true;
            this.navigationPanePanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.navigationPanePanel5.Controls.Add(this.dataGridViewX_MenuPer);
            this.navigationPanePanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanePanel5.Location = new System.Drawing.Point(1, 25);
            this.navigationPanePanel5.Name = "navigationPanePanel5";
            this.navigationPanePanel5.ParentItem = this.MenuPer;
            this.navigationPanePanel5.Size = new System.Drawing.Size(818, 159);
            this.navigationPanePanel5.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel5.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.navigationPanePanel5.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            this.navigationPanePanel5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.navigationPanePanel5.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.navigationPanePanel5.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.navigationPanePanel5.Style.GradientAngle = 90;
            this.navigationPanePanel5.Style.WordWrap = true;
            this.navigationPanePanel5.StyleMouseDown.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel5.StyleMouseDown.WordWrap = true;
            this.navigationPanePanel5.StyleMouseOver.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel5.StyleMouseOver.WordWrap = true;
            this.navigationPanePanel5.TabIndex = 6;
            this.navigationPanePanel5.Text = "Drop your controls here and erase Text property";
            // 
            // dataGridViewX_MenuPer
            // 
            this.dataGridViewX_MenuPer.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.dataGridViewX_MenuPer.ColumnInfo = resources.GetString("dataGridViewX_MenuPer.ColumnInfo");
            this.dataGridViewX_MenuPer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX_MenuPer.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX_MenuPer.Name = "dataGridViewX_MenuPer";
            this.dataGridViewX_MenuPer.Rows.Count = 14;
            this.dataGridViewX_MenuPer.Rows.DefaultSize = 19;
            this.dataGridViewX_MenuPer.Size = new System.Drawing.Size(818, 159);
            this.dataGridViewX_MenuPer.TabIndex = 20;
            this.dataGridViewX_MenuPer.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue;
            // 
            // MenuPer
            // 
            this.MenuPer.Checked = true;
            this.MenuPer.Image = ((System.Drawing.Image)(resources.GetObject("MenuPer.Image")));
            this.MenuPer.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.MenuPer.Name = "MenuPer";
            this.MenuPer.OptionGroup = "navBar";
            this.MenuPer.SubItemsExpandWidth = 11;
            this.MenuPer.Symbol = "";
            this.MenuPer.Text = "الكـــروت";
            this.MenuPer.Tooltip = "إضغط هنا لعرض صلاحيات الكــروت";
            // 
            // navigationPanePanel3
            // 
            this.navigationPanePanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.navigationPanePanel3.Controls.Add(this.dataGridViewX_SalPer);
            this.navigationPanePanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanePanel3.Location = new System.Drawing.Point(1, 1);
            this.navigationPanePanel3.Name = "navigationPanePanel3";
            this.navigationPanePanel3.ParentItem = this.SalPer;
            this.navigationPanePanel3.Size = new System.Drawing.Size(818, 183);
            this.navigationPanePanel3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.navigationPanePanel3.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            this.navigationPanePanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.navigationPanePanel3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.navigationPanePanel3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.navigationPanePanel3.Style.GradientAngle = 90;
            this.navigationPanePanel3.Style.WordWrap = true;
            this.navigationPanePanel3.StyleMouseDown.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel3.StyleMouseDown.WordWrap = true;
            this.navigationPanePanel3.StyleMouseOver.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel3.StyleMouseOver.WordWrap = true;
            this.navigationPanePanel3.TabIndex = 4;
            this.navigationPanePanel3.Text = "Drop your controls here and erase Text property";
            // 
            // dataGridViewX_SalPer
            // 
            this.dataGridViewX_SalPer.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.dataGridViewX_SalPer.ColumnInfo = resources.GetString("dataGridViewX_SalPer.ColumnInfo");
            this.dataGridViewX_SalPer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX_SalPer.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX_SalPer.Name = "dataGridViewX_SalPer";
            this.dataGridViewX_SalPer.Rows.Count = 11;
            this.dataGridViewX_SalPer.Rows.DefaultSize = 19;
            this.dataGridViewX_SalPer.Size = new System.Drawing.Size(818, 183);
            this.dataGridViewX_SalPer.TabIndex = 10;
            this.dataGridViewX_SalPer.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue;
            // 
            // SalPer
            // 
            this.SalPer.Image = ((System.Drawing.Image)(resources.GetObject("SalPer.Image")));
            this.SalPer.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.SalPer.Name = "SalPer";
            this.SalPer.OptionGroup = "navBar";
            this.SalPer.SubItemsExpandWidth = 11;
            this.SalPer.Symbol = "";
            this.SalPer.Text = "عمليـــات الـــرواتب";
            this.SalPer.Tooltip = "إضغط هنا لعرض صلاحيات الــرواتــب";
            // 
            // navigationPanePanel2
            // 
            this.navigationPanePanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.navigationPanePanel2.Controls.Add(this.dataGridViewX_RepPre);
            this.navigationPanePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanePanel2.Location = new System.Drawing.Point(1, 1);
            this.navigationPanePanel2.Name = "navigationPanePanel2";
            this.navigationPanePanel2.ParentItem = this.RepPre;
            this.navigationPanePanel2.Size = new System.Drawing.Size(818, 183);
            this.navigationPanePanel2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.navigationPanePanel2.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            this.navigationPanePanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.navigationPanePanel2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.navigationPanePanel2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.navigationPanePanel2.Style.GradientAngle = 90;
            this.navigationPanePanel2.Style.WordWrap = true;
            this.navigationPanePanel2.StyleMouseDown.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel2.StyleMouseDown.WordWrap = true;
            this.navigationPanePanel2.StyleMouseOver.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel2.StyleMouseOver.WordWrap = true;
            this.navigationPanePanel2.TabIndex = 3;
            this.navigationPanePanel2.Text = "Drop your controls here and erase Text property";
            // 
            // dataGridViewX_RepPre
            // 
            this.dataGridViewX_RepPre.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.dataGridViewX_RepPre.ColumnInfo = resources.GetString("dataGridViewX_RepPre.ColumnInfo");
            this.dataGridViewX_RepPre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX_RepPre.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX_RepPre.Name = "dataGridViewX_RepPre";
            this.dataGridViewX_RepPre.Rows.Count = 24;
            this.dataGridViewX_RepPre.Rows.DefaultSize = 19;
            this.dataGridViewX_RepPre.Size = new System.Drawing.Size(818, 183);
            this.dataGridViewX_RepPre.TabIndex = 11;
            this.dataGridViewX_RepPre.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue;
            // 
            // RepPre
            // 
            this.RepPre.Image = ((System.Drawing.Image)(resources.GetObject("RepPre.Image")));
            this.RepPre.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.RepPre.Name = "RepPre";
            this.RepPre.OptionGroup = "navBar";
            this.RepPre.SubItemsExpandWidth = 11;
            this.RepPre.Symbol = "";
            this.RepPre.Text = "التقـــارير";
            this.RepPre.Tooltip = "إضغط هنا لعرض صلاحيات التقـــارير";
            // 
            // navigationPanePanel4
            // 
            this.navigationPanePanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.navigationPanePanel4.Controls.Add(this.dataGridViewX_MovePre);
            this.navigationPanePanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanePanel4.Location = new System.Drawing.Point(1, 1);
            this.navigationPanePanel4.Name = "navigationPanePanel4";
            this.navigationPanePanel4.ParentItem = this.MovePre;
            this.navigationPanePanel4.Size = new System.Drawing.Size(818, 183);
            this.navigationPanePanel4.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel4.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.navigationPanePanel4.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            this.navigationPanePanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.navigationPanePanel4.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.navigationPanePanel4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.navigationPanePanel4.Style.GradientAngle = 90;
            this.navigationPanePanel4.Style.WordWrap = true;
            this.navigationPanePanel4.StyleMouseDown.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel4.StyleMouseDown.WordWrap = true;
            this.navigationPanePanel4.StyleMouseOver.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel4.StyleMouseOver.WordWrap = true;
            this.navigationPanePanel4.TabIndex = 5;
            this.navigationPanePanel4.Text = "Drop your controls here and erase Text property";
            // 
            // dataGridViewX_MovePre
            // 
            this.dataGridViewX_MovePre.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.dataGridViewX_MovePre.ColumnInfo = resources.GetString("dataGridViewX_MovePre.ColumnInfo");
            this.dataGridViewX_MovePre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX_MovePre.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX_MovePre.Name = "dataGridViewX_MovePre";
            this.dataGridViewX_MovePre.Rows.Count = 13;
            this.dataGridViewX_MovePre.Rows.DefaultSize = 19;
            this.dataGridViewX_MovePre.Size = new System.Drawing.Size(818, 183);
            this.dataGridViewX_MovePre.TabIndex = 21;
            this.dataGridViewX_MovePre.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue;
            // 
            // MovePre
            // 
            this.MovePre.Image = ((System.Drawing.Image)(resources.GetObject("MovePre.Image")));
            this.MovePre.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.MovePre.Name = "MovePre";
            this.MovePre.OptionGroup = "navBar";
            this.MovePre.SubItemsExpandWidth = 11;
            this.MovePre.Symbol = "";
            this.MovePre.Text = "الحركـــات";
            this.MovePre.Tooltip = "إضغط هنا لعرض صلاحيات الحــركــة";
            // 
            // navigationPanePanel1
            // 
            this.navigationPanePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.navigationPanePanel1.Controls.Add(this.dataGridViewX_GenralPre);
            this.navigationPanePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanePanel1.Location = new System.Drawing.Point(1, 1);
            this.navigationPanePanel1.Name = "navigationPanePanel1";
            this.navigationPanePanel1.Padding = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.navigationPanePanel1.ParentItem = this.GenralPre;
            this.navigationPanePanel1.Size = new System.Drawing.Size(818, 183);
            this.navigationPanePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.navigationPanePanel1.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            this.navigationPanePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.navigationPanePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.navigationPanePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.navigationPanePanel1.Style.GradientAngle = 90;
            this.navigationPanePanel1.StyleMouseDown.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel1.StyleMouseOver.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel1.TabIndex = 2;
            // 
            // dataGridViewX_GenralPre
            // 
            this.dataGridViewX_GenralPre.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.dataGridViewX_GenralPre.ColumnInfo = resources.GetString("dataGridViewX_GenralPre.ColumnInfo");
            this.dataGridViewX_GenralPre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX_GenralPre.Location = new System.Drawing.Point(1, 1);
            this.dataGridViewX_GenralPre.Name = "dataGridViewX_GenralPre";
            this.dataGridViewX_GenralPre.Rows.Count = 14;
            this.dataGridViewX_GenralPre.Rows.DefaultSize = 19;
            this.dataGridViewX_GenralPre.Size = new System.Drawing.Size(816, 182);
            this.dataGridViewX_GenralPre.TabIndex = 12;
            this.dataGridViewX_GenralPre.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue;
            // 
            // GenralPre
            // 
            this.GenralPre.Image = ((System.Drawing.Image)(resources.GetObject("GenralPre.Image")));
            this.GenralPre.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.GenralPre.Name = "GenralPre";
            this.GenralPre.OptionGroup = "navBar";
            this.GenralPre.SubItemsExpandWidth = 11;
            this.GenralPre.Symbol = "";
            this.GenralPre.Text = "عـــــــام";
            this.GenralPre.Tooltip = "إضغط هنا لعرض الصلاحيــات العـامة";
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.AutoSize = true;
            this.ribbonPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel2.Controls.Add(this.groupPanel_Stores);
            this.ribbonPanel2.Controls.Add(this.groupPanel_InvoiceType);
            this.ribbonPanel2.Controls.Add(this.FlxInvoices);
            this.ribbonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel2.Location = new System.Drawing.Point(0, 26);
            this.ribbonPanel2.Name = "ribbonPanel2";
            this.ribbonPanel2.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel2.Size = new System.Drawing.Size(826, 224);
            // 
            // 
            // 
            this.ribbonPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel2.TabIndex = 2;
            this.ribbonPanel2.Visible = false;
            // 
            // groupPanel_Stores
            // 
            this.groupPanel_Stores.BackColor = System.Drawing.Color.White;
            this.groupPanel_Stores.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel_Stores.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel_Stores.Controls.Add(this.label20);
            this.groupPanel_Stores.Controls.Add(this.CmbStores);
            this.groupPanel_Stores.Controls.Add(this.FlxStkQty);
            this.groupPanel_Stores.Controls.Add(this.chk22);
            this.groupPanel_Stores.Location = new System.Drawing.Point(156, 3);
            this.groupPanel_Stores.Name = "groupPanel_Stores";
            this.groupPanel_Stores.Size = new System.Drawing.Size(139, 221);
            // 
            // 
            // 
            this.groupPanel_Stores.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel_Stores.Style.BackColorGradientAngle = 90;
            this.groupPanel_Stores.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel_Stores.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Stores.Style.BorderBottomWidth = 1;
            this.groupPanel_Stores.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel_Stores.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Stores.Style.BorderLeftWidth = 1;
            this.groupPanel_Stores.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Stores.Style.BorderRightWidth = 1;
            this.groupPanel_Stores.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Stores.Style.BorderTopWidth = 1;
            this.groupPanel_Stores.Style.CornerDiameter = 4;
            this.groupPanel_Stores.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel_Stores.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel_Stores.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel_Stores.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel_Stores.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel_Stores.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel_Stores.TabIndex = 14;
            this.groupPanel_Stores.Text = "ايقاف المستودع";
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label20.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label20.Location = new System.Drawing.Point(0, 140);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(133, 20);
            this.label20.TabIndex = 881;
            this.label20.Text = "المستودع الإفتراضي";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CmbStores
            // 
            this.CmbStores.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbStores.DisplayMember = "Text";
            this.CmbStores.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CmbStores.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbStores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbStores.FormattingEnabled = true;
            this.CmbStores.ItemHeight = 14;
            this.CmbStores.Location = new System.Drawing.Point(0, 160);
            this.CmbStores.Name = "CmbStores";
            this.CmbStores.Size = new System.Drawing.Size(133, 20);
            this.CmbStores.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbStores.TabIndex = 880;
            // 
            // FlxStkQty
            // 
            this.FlxStkQty.BackColor = System.Drawing.Color.Transparent;
            this.FlxStkQty.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            this.FlxStkQty.ColumnInfo = resources.GetString("FlxStkQty.ColumnInfo");
            this.FlxStkQty.Dock = System.Windows.Forms.DockStyle.Top;
            this.FlxStkQty.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FlxStkQty.Location = new System.Drawing.Point(0, 0);
            this.FlxStkQty.Name = "FlxStkQty";
            this.FlxStkQty.Rows.Count = 1;
            this.FlxStkQty.Rows.DefaultSize = 19;
            this.FlxStkQty.Rows.Fixed = 0;
            this.FlxStkQty.Size = new System.Drawing.Size(133, 137);
            this.FlxStkQty.StyleInfo = resources.GetString("FlxStkQty.StyleInfo");
            this.FlxStkQty.TabIndex = 879;
            this.FlxStkQty.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System;
            // 
            // chk22
            // 
            this.chk22.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk22.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.chk22.BackgroundStyle.BorderBottomWidth = 1;
            this.chk22.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionInactiveText;
            this.chk22.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.chk22.BackgroundStyle.BorderLeftWidth = 1;
            this.chk22.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.chk22.BackgroundStyle.BorderRightWidth = 1;
            this.chk22.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.chk22.BackgroundStyle.BorderTopWidth = 1;
            this.chk22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk22.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chk22.Location = new System.Drawing.Point(0, 180);
            this.chk22.Name = "chk22";
            this.chk22.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk22.Size = new System.Drawing.Size(133, 20);
            this.chk22.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk22.TabIndex = 6742;
            this.chk22.Text = "عكس الطباعة الإفتراضية";
            // 
            // groupPanel_InvoiceType
            // 
            this.groupPanel_InvoiceType.BackColor = System.Drawing.Color.White;
            this.groupPanel_InvoiceType.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel_InvoiceType.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel_InvoiceType.Controls.Add(this.switchButton_ControlHeadOFRep);
            this.groupPanel_InvoiceType.Controls.Add(this.FlexType);
            this.groupPanel_InvoiceType.Controls.Add(this.chk16);
            this.groupPanel_InvoiceType.Location = new System.Drawing.Point(6, 3);
            this.groupPanel_InvoiceType.Name = "groupPanel_InvoiceType";
            this.groupPanel_InvoiceType.Size = new System.Drawing.Size(148, 221);
            // 
            // 
            // 
            this.groupPanel_InvoiceType.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel_InvoiceType.Style.BackColorGradientAngle = 90;
            this.groupPanel_InvoiceType.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel_InvoiceType.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_InvoiceType.Style.BorderBottomWidth = 1;
            this.groupPanel_InvoiceType.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel_InvoiceType.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_InvoiceType.Style.BorderLeftWidth = 1;
            this.groupPanel_InvoiceType.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_InvoiceType.Style.BorderRightWidth = 1;
            this.groupPanel_InvoiceType.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_InvoiceType.Style.BorderTopWidth = 1;
            this.groupPanel_InvoiceType.Style.CornerDiameter = 4;
            this.groupPanel_InvoiceType.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel_InvoiceType.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel_InvoiceType.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel_InvoiceType.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel_InvoiceType.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel_InvoiceType.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel_InvoiceType.TabIndex = 13;
            this.groupPanel_InvoiceType.Text = "تغيير ورقة الطباعة حسب";
            // 
            // switchButton_ControlHeadOFRep
            // 
            // 
            // 
            // 
            this.switchButton_ControlHeadOFRep.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_ControlHeadOFRep.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.switchButton_ControlHeadOFRep.Font = new System.Drawing.Font("Tahoma", 7F);
            this.switchButton_ControlHeadOFRep.Location = new System.Drawing.Point(0, 158);
            this.switchButton_ControlHeadOFRep.Name = "switchButton_ControlHeadOFRep";
            this.switchButton_ControlHeadOFRep.OffText = "التحكم في الترويسة";
            this.switchButton_ControlHeadOFRep.OnText = "التحكم في الترويسة";
            this.switchButton_ControlHeadOFRep.Size = new System.Drawing.Size(142, 22);
            this.switchButton_ControlHeadOFRep.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_ControlHeadOFRep.TabIndex = 6742;
            this.switchButton_ControlHeadOFRep.ValueChanged += new System.EventHandler(this.switchButton_ControlHeadOFRep_ValueChanged);
            // 
            // FlexType
            // 
            this.FlexType.BackColor = System.Drawing.Color.White;
            this.FlexType.ColumnInfo = resources.GetString("FlexType.ColumnInfo");
            this.FlexType.Dock = System.Windows.Forms.DockStyle.Top;
            this.FlexType.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FlexType.Location = new System.Drawing.Point(0, 0);
            this.FlexType.Name = "FlexType";
            this.FlexType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FlexType.Rows.Count = 13;
            this.FlexType.Rows.DefaultSize = 19;
            this.FlexType.Rows.Fixed = 0;
            this.FlexType.Size = new System.Drawing.Size(142, 155);
            this.FlexType.StyleInfo = resources.GetString("FlexType.StyleInfo");
            this.FlexType.TabIndex = 6740;
            this.FlexType.Tag = "";
            this.FlexType.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System;
            // 
            // chk16
            // 
            this.chk16.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk16.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.chk16.BackgroundStyle.BorderBottomWidth = 1;
            this.chk16.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionInactiveText;
            this.chk16.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.chk16.BackgroundStyle.BorderLeftWidth = 1;
            this.chk16.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.chk16.BackgroundStyle.BorderRightWidth = 1;
            this.chk16.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.chk16.BackgroundStyle.BorderTopWidth = 1;
            this.chk16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk16.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chk16.Enabled = false;
            this.chk16.Location = new System.Drawing.Point(0, 180);
            this.chk16.Name = "chk16";
            this.chk16.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk16.Size = new System.Drawing.Size(142, 20);
            this.chk16.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk16.TabIndex = 6741;
            this.chk16.Text = "ايقاف ترويسة التقارير";
            // 
            // FlxInvoices
            // 
            this.FlxInvoices.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.FlxInvoices.ColumnInfo = resources.GetString("FlxInvoices.ColumnInfo");
            this.FlxInvoices.Dock = System.Windows.Forms.DockStyle.Right;
            this.FlxInvoices.Location = new System.Drawing.Point(297, 0);
            this.FlxInvoices.Name = "FlxInvoices";
            this.FlxInvoices.Rows.Count = 15;
            this.FlxInvoices.Rows.DefaultSize = 19;
            this.FlxInvoices.Size = new System.Drawing.Size(526, 221);
            this.FlxInvoices.TabIndex = 12;
            this.FlxInvoices.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue;
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.AutoSize = true;
            this.ribbonPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel1.Controls.Add(this.FlxFiles);
            this.ribbonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel1.Location = new System.Drawing.Point(0, 26);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel1.Size = new System.Drawing.Size(826, 224);
            // 
            // 
            // 
            this.ribbonPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel1.TabIndex = 1;
            this.ribbonPanel1.Visible = false;
            // 
            // FlxFiles
            // 
            this.FlxFiles.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.FlxFiles.ColumnInfo = resources.GetString("FlxFiles.ColumnInfo");
            this.FlxFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlxFiles.Location = new System.Drawing.Point(3, 0);
            this.FlxFiles.Name = "FlxFiles";
            this.FlxFiles.Rows.Count = 16;
            this.FlxFiles.Rows.DefaultSize = 19;
            this.FlxFiles.Size = new System.Drawing.Size(820, 221);
            this.FlxFiles.TabIndex = 19;
            this.FlxFiles.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue;
            // 
            // ribbonTabItem_General
            // 
            this.ribbonTabItem_General.Checked = true;
            this.ribbonTabItem_General.Name = "ribbonTabItem_General";
            this.ribbonTabItem_General.Panel = this.ribbonPanel6;
            this.ribbonTabItem_General.Text = "عـــام";
            // 
            // ribbonTabItem_Files
            // 
            this.ribbonTabItem_Files.Name = "ribbonTabItem_Files";
            this.ribbonTabItem_Files.Panel = this.ribbonPanel1;
            this.ribbonTabItem_Files.Text = "الكروت";
            // 
            // ribbonTabItem_ACC
            // 
            this.ribbonTabItem_ACC.Name = "ribbonTabItem_ACC";
            this.ribbonTabItem_ACC.Panel = this.ribbonPanel3;
            this.ribbonTabItem_ACC.Text = "الحسابات";
            // 
            // ribbonTabItem_Inv
            // 
            this.ribbonTabItem_Inv.Name = "ribbonTabItem_Inv";
            this.ribbonTabItem_Inv.Panel = this.ribbonPanel2;
            this.ribbonTabItem_Inv.Text = "الفواتير";
            // 
            // ribbonTabItem_RepStocks
            // 
            this.ribbonTabItem_RepStocks.Name = "ribbonTabItem_RepStocks";
            this.ribbonTabItem_RepStocks.Panel = this.ribbonPanel4;
            this.ribbonTabItem_RepStocks.Text = "تقارير المخزون";
            // 
            // ribbonTabItem_RepAcc
            // 
            this.ribbonTabItem_RepAcc.Name = "ribbonTabItem_RepAcc";
            this.ribbonTabItem_RepAcc.Panel = this.ribbonPanel5;
            this.ribbonTabItem_RepAcc.Text = "تقارير الحسابات";
            // 
            // ribbonTabItem_Emps
            // 
            this.ribbonTabItem_Emps.Name = "ribbonTabItem_Emps";
            this.ribbonTabItem_Emps.Panel = this.ribbonPanel8;
            this.ribbonTabItem_Emps.Text = "شؤون الموظفين";
            this.ribbonTabItem_Emps.Click += new System.EventHandler(this.ribbonTabItem_Emps_Click);
            // 
            // ribbonTabItem_Hotels
            // 
            this.ribbonTabItem_Hotels.Name = "ribbonTabItem_Hotels";
            this.ribbonTabItem_Hotels.Panel = this.ribbonTabItem_Hotel;
            this.ribbonTabItem_Hotels.Text = "إدارة الفندق";
            // 
            // ribbonTabItem_Eqar
            // 
            this.ribbonTabItem_Eqar.Name = "ribbonTabItem_Eqar";
            this.ribbonTabItem_Eqar.Panel = this.ribbonPanel9;
            this.ribbonTabItem_Eqar.Text = "العقار";
            // 
            // ribbonTabItem_Other
            // 
            this.ribbonTabItem_Other.Name = "ribbonTabItem_Other";
            this.ribbonTabItem_Other.Panel = this.ribbonPanel7;
            this.ribbonTabItem_Other.Text = "أخرى";
            // 
            // buttonItem_SelectAll
            // 
            this.buttonItem_SelectAll.BeginGroup = true;
            this.buttonItem_SelectAll.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem_SelectAll.Checked = true;
            this.buttonItem_SelectAll.FontItalic = true;
            this.buttonItem_SelectAll.Name = "buttonItem_SelectAll";
            this.buttonItem_SelectAll.Symbol = "";
            this.buttonItem_SelectAll.SymbolSize = 7F;
            this.buttonItem_SelectAll.Text = "الكل";
            this.buttonItem_SelectAll.Click += new System.EventHandler(this.buttonItem_SelectAll_Click);
            // 
            // buttonItem_UnSelectAll
            // 
            this.buttonItem_UnSelectAll.BeginGroup = true;
            this.buttonItem_UnSelectAll.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem_UnSelectAll.Checked = true;
            this.buttonItem_UnSelectAll.FontItalic = true;
            this.buttonItem_UnSelectAll.Name = "buttonItem_UnSelectAll";
            this.buttonItem_UnSelectAll.Symbol = "";
            this.buttonItem_UnSelectAll.SymbolSize = 7F;
            this.buttonItem_UnSelectAll.Text = "إلغاء";
            this.buttonItem_UnSelectAll.Click += new System.EventHandler(this.buttonItem_UnSelectAll_Click);
            // 
            // buttonItem1
            // 
            this.buttonItem1.Name = "buttonItem1";
            // 
            // qatCustomizeItem1
            // 
            this.qatCustomizeItem1.Name = "qatCustomizeItem1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(713, 327);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 121;
            this.label5.Text = "الإسم الانجليزي :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(713, 359);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 110;
            this.label6.Text = "الفرع الإفتراضي :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(713, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 108;
            this.label4.Text = "الإسم العربي :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(713, 263);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 105;
            this.label1.Text = "رقم المستخدم :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(404, 327);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 111;
            this.label8.Text = "اللغة الافتراضية :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(404, 295);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 107;
            this.label3.Text = "تأكيد كلمة المرور :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(404, 359);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 109;
            this.label7.Text = "حالة المستخدم :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(404, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 106;
            this.label2.Text = "كلمة المرور :";
            // 
            // switchButton_AdminOp
            // 
            // 
            // 
            // 
            this.switchButton_AdminOp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_AdminOp.Location = new System.Drawing.Point(14, 349);
            this.switchButton_AdminOp.Name = "switchButton_AdminOp";
            this.switchButton_AdminOp.OffText = "مسؤول الموافقات";
            this.switchButton_AdminOp.OnText = "مسؤول الموافقات";
            this.switchButton_AdminOp.Size = new System.Drawing.Size(228, 30);
            this.switchButton_AdminOp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_AdminOp.TabIndex = 935;
            this.switchButton_AdminOp.ValueChanged += new System.EventHandler(this.switchButton_AdminOp_ValueChanged);
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
            this.ribbonBar_Tasks.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ribbonBar_Tasks.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar_Tasks.Location = new System.Drawing.Point(0, 416);
            this.ribbonBar_Tasks.Name = "ribbonBar_Tasks";
            this.ribbonBar_Tasks.Size = new System.Drawing.Size(826, 51);
            this.ribbonBar_Tasks.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar_Tasks.TabIndex = 870;
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
            this.superTabControl_Main1.Size = new System.Drawing.Size(429, 51);
            this.superTabControl_Main1.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_Main1.TabIndex = 10;
            this.superTabControl_Main1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.Button_Close,
            this.Button_Search,
            this.Button_Delete,
            this.Button_Save,
            this.Button_Add,
            this.chk11});
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
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
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
            this.Button_Add.Click += new System.EventHandler(this.Button_Add_Click_1);
            // 
            // chk11
            // 
            this.chk11.BeginGroup = true;
            this.chk11.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
            this.chk11.CheckSignSize = new System.Drawing.Size(16, 16);
            this.chk11.Name = "chk11";
            this.chk11.Stretch = true;
            this.chk11.Text = "موافقة تلقائية";
            this.chk11.TextColor = System.Drawing.Color.SteelBlue;
            this.chk11.Visible = false;
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
            this.superTabControl_Main2.Location = new System.Drawing.Point(429, 0);
            this.superTabControl_Main2.Name = "superTabControl_Main2";
            this.superTabControl_Main2.ReorderTabsEnabled = true;
            this.superTabControl_Main2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.superTabControl_Main2.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_Main2.SelectedTabIndex = -1;
            this.superTabControl_Main2.Size = new System.Drawing.Size(397, 51);
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
            this.TextBox_Index.TextBoxWidth = 50;
            this.TextBox_Index.Visible = false;
            this.TextBox_Index.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // Label_Count
            // 
            this.Label_Count.Name = "Label_Count";
            this.Label_Count.Visible = false;
            this.Label_Count.Width = 40;
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
            // ToolStripMenuItem_Rep
            // 
            this.ToolStripMenuItem_Rep.Checked = true;
            this.ToolStripMenuItem_Rep.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToolStripMenuItem_Rep.Name = "ToolStripMenuItem_Rep";
            this.ToolStripMenuItem_Rep.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem_Rep.Text = "إظهار التقرير";
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
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
            // ToolStripMenuItem_Det
            // 
            this.ToolStripMenuItem_Det.Name = "ToolStripMenuItem_Det";
            this.ToolStripMenuItem_Det.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem_Det.Text = "إظهار التفاصيل";
            // 
            // Rep_RecCount
            // 
            this.Rep_RecCount.AllowEmptyState = false;
            // 
            // 
            // 
            this.Rep_RecCount.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Rep_RecCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Rep_RecCount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.Rep_RecCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Rep_RecCount.Increment = 0;
            this.Rep_RecCount.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.Rep_RecCount.IsInputReadOnly = true;
            this.Rep_RecCount.Location = new System.Drawing.Point(761, 495);
            this.Rep_RecCount.Name = "Rep_RecCount";
            this.Rep_RecCount.Size = new System.Drawing.Size(73, 21);
            this.Rep_RecCount.TabIndex = 868;
            this.Rep_RecCount.Visible = false;
            this.Rep_RecCount.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.rtf";
            this.openFileDialog1.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf|All Files(*.*)|*.*";
            this.openFileDialog1.FilterIndex = 2;
            this.openFileDialog1.Title = "Open File";
            // 
            // timerInfoBallon
            // 
            this.timerInfoBallon.Interval = 3000;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "*.rtf";
            this.saveFileDialog1.FileName = "doc1";
            this.saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf|All Files(*.*)|*.*";
            this.saveFileDialog1.FilterIndex = 2;
            this.saveFileDialog1.Title = "Save File";
            // 
            // panelEx3
            // 
            this.panelEx3.Controls.Add(this.DGV_Main);
            this.panelEx3.Controls.Add(this.ribbonBar_DGV);
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx3.Location = new System.Drawing.Point(0, 0);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(826, 0);
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
            this.DGV_Main.Size = new System.Drawing.Size(826, 0);
            this.DGV_Main.TabIndex = 874;
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
            this.ribbonBar_DGV.Size = new System.Drawing.Size(826, 51);
            this.ribbonBar_DGV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar_DGV.TabIndex = 875;
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
            this.superTabControl_DGV.Size = new System.Drawing.Size(826, 51);
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
            // 
            // labelItem3
            // 
            this.labelItem3.Name = "labelItem3";
            this.labelItem3.Width = 40;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // panelEx2
            // 
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx2.Location = new System.Drawing.Point(0, 14);
            this.panelEx2.MinimumSize = new System.Drawing.Size(723, 453);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(826, 453);
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
            this.expandableSplitter1.Location = new System.Drawing.Point(0, 0);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(826, 14);
            this.expandableSplitter1.TabIndex = 1;
            this.expandableSplitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelEx3);
            this.panel1.Controls.Add(this.expandableSplitter1);
            this.panel1.Controls.Add(this.panelEx2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(826, 467);
            this.panel1.TabIndex = 877;
            // 
            // netResize1
            // 
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.DataGridViewAutoResize = true;
            this.netResize1.DataGridViewAutoResizeCols = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            this.netResize1.ListViewAutoResize = true;
            this.netResize1.ParentControl = this;
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            // 
            // FrmUsr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 467);
            this.Controls.Add(this.PanelSpecialContainer);
            this.Controls.Add(this.Rep_RecCount);
            this.Controls.Add(this.panel1);
            this.Icon = global::InvAcc.Properties.Resources.favicon;
            this.KeyPreview = true;
            this.Name = "FrmUsr";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "صلاحيات المستخدمين ";
            this.Load += new System.EventHandler(this.FrmUsr_Load);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmUsr_KeyDown);
            this.PanelSpecialContainer.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            this.ribbonBar1.PerformLayout();
            this.groupBox_Comm.ResumeLayout(false);
            this.groupBox_Comm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_CommGaid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_CommInv)).EndInit();
            this.ribbonControl_Setting.ResumeLayout(false);
            this.ribbonControl_Setting.PerformLayout();
            this.ribbonPanel6.ResumeLayout(false);
            this.groupPanel_Banner.ResumeLayout(false);
            this.groupPanel_Banner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicItemImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlxSetups)).EndInit();
            this.ribbonPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FlxAccounting)).EndInit();
            this.ribbonPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FlxSRep)).EndInit();
            this.ribbonPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FlxAccRep)).EndInit();
            this.ribbonPanel7.ResumeLayout(false);
            this.ribbonPanel7.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_MaxDis)).EndInit();
            this.ribbonPanel9.ResumeLayout(false);
            this.navigationPane_Eqar.ResumeLayout(false);
            this.navigationPane_Eqar.PerformLayout();
            this.navigationPanePanel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX_EqarFiles)).EndInit();
            this.navigationPanePanel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX_GenralEqar)).EndInit();
            this.navigationPanePanel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX_Tenants)).EndInit();
            this.navigationPanePanel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX_RepEqar)).EndInit();
            this.ribbonTabItem_Hotel.ResumeLayout(false);
            this.navigationPane_Hotel.ResumeLayout(false);
            this.navigationPane_Hotel.PerformLayout();
            this.navigationPanePanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX_HotelMenuPer)).EndInit();
            this.navigationPanePanel9.ResumeLayout(false);
            this.panel_Prices.ResumeLayout(false);
            this.panel_Prices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX_HotelGenralPre)).EndInit();
            this.navigationPanePanel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX_HotelRepPre)).EndInit();
            this.navigationPanePanel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX_HotelMovePre)).EndInit();
            this.ribbonPanel8.ResumeLayout(false);
            this.navigationPane_Emps.ResumeLayout(false);
            this.navigationPane_Emps.PerformLayout();
            this.navigationPanePanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX_MenuPer)).EndInit();
            this.navigationPanePanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX_SalPer)).EndInit();
            this.navigationPanePanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX_RepPre)).EndInit();
            this.navigationPanePanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX_MovePre)).EndInit();
            this.navigationPanePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX_GenralPre)).EndInit();
            this.ribbonPanel2.ResumeLayout(false);
            this.groupPanel_Stores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FlxStkQty)).EndInit();
            this.groupPanel_InvoiceType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FlexType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlxInvoices)).EndInit();
            this.ribbonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FlxFiles)).EndInit();
            this.ribbonBar_Tasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main2)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Rep_RecCount)).EndInit();
            this.panelEx3.ResumeLayout(false);
            this.ribbonBar_DGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_DGV)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);
        }
        private void ribbonTabItem_Emps_Click(object sender, EventArgs e)
        {
        }
        private void Button_Add_Click_1(object sender, EventArgs e)
        {
        }
    }
}
