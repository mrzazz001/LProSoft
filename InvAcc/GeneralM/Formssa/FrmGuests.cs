using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using InputKey;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Library.RepShow;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using SSSDateTime.Date;
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
    public partial class FrmGuests : Form
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
        private T_per1 DataThis_Family;
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstance;
        private T_per data_this;
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
        private int R1;
        private int R2;
        private int R3;
        private int R4;
        private int Fin;
        private int M;
        private int Mm;
        private string aa;
        private int SS;
        private double Tot = 0.0;
        private string CDat;
        private int CDat2;
        private int bb = 0;
        private T_SYSSETTING _SysSetting = new T_SYSSETTING();
        private List<T_SYSSETTING> listSysSetting = new List<T_SYSSETTING>();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private List<T_INVSETTING> listInvSetting = new List<T_INVSETTING>();
        private T_Company _Company = new T_Company();
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
        private double tmp = 0.0;
        private IContainer components = null;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!keyData.ToString().Contains("Control") && !keyData.ToString().ToLower().Contains("delete") && keyData.ToString().Contains("Alt"))
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
                        frm.Repvalue = "RepGeneral";
                        frm.Repvalue = "RepGuestDataPer_1";

                        frm.Repvalue = "RepGeneral";
                        frm.Repvalue = "RepGuestDataPer_1";
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
        protected ButtonItem Button_Save;
        protected ButtonItem Button_Add;
        private RibbonBar ribbonBar_DGV;
        private SuperTabControl superTabControl_DGV;
        protected TextBoxItem textBox_search;
        protected ButtonItem Button_ExportTable2;
        protected ButtonItem Button_PrintTable;
        protected LabelItem labelItem3;
        private LabelItem lable_Records;
        private Panel panel2;
        private DevComponents.DotNetBar.TabControl tabControl1;
        private TabControlPanel tabControlPanel1;
        private TabItem tabItem_GuestsData;
        private TabControlPanel tabControlPanel2;
        private TabItem tabItem_FamilyData;
        private ComboBoxEx comboBox_Rooms;
        internal Label label5;
        protected TextBox textBox_NameA;
        protected Label label36;
        protected TextBox textBox_ID;
        protected Label label38;
        internal GroupBox groupBox_PaidTyp;
        private CheckBoxX checkBox_NetWork;
        private CheckBoxX checkBox_Credit;
        private CheckBoxX checkBox_Chash;
        private TextBox txtCustNo;
        internal Label label4;
        private ComboBoxEx comboBox_RoomTyp;
        internal Label label1;
        private Panel panel_GustData;
        private ComboBoxEx comboBox_Nationality;
        private ComboBoxEx comboBox_BirthPlace;
        private ComboBoxEx comboBox_Religion;
        private MaskedTextBox dateTimeInput_BirthDate;
        private Label label115;
        private Label label113;
        private ComboBoxEx CmbIDTyp;
        private Label label2;
        private TextBox textBox_ID_No;
        private Label label97;
        private ComboBoxEx comboBox_ID_From;
        private Label label95;
        private MaskedTextBox dateTimeInput_ID_Date;
        private MaskedTextBox dateTimeInput_ID_DateEnd;
        private Label label88;
        private Label label92;
        private TextBox textBox_Mobile;
        private Label label124;
        private ComboBoxEx comboBox_Job;
        private Label label3;
        private TextBoxX textBox_Note;
        private Panel panel_GuestDaysData;
        private Label label6;
        private IntegerInput textBox_DayCount;
        private Label label8;
        private Label label7;
        private IntegerInput textBox_DayRequest;
        private DoubleInput textBox_RoomPrice;
        private ComboBoxEx comboBox_Curr;
        internal Label label19;
        private Label label10;
        private DoubleInput TextBox_TotalAm;
        private Label label9;
        private DoubleInput Textbox_DiscountVal;
        private ComboBoxEx comboBox_DisTo;
        internal Label label12;
        private ComboBoxEx comboBox_DisType;
        private Label label14;
        private DoubleInput TextBox_Remming;
        private Label label13;
        private DoubleInput TextBox_Paid;
        internal Label label11;
        private MaskedTextBox textBox_Date;
        internal Label label15;
        private MaskedTextBox textBox_Time;
        internal GroupBox groupBox_AmPm;
        private CheckBoxX checkBoxX1;
        private CheckBoxX RadioBox_AllowPM;
        private CheckBoxX RadioBox_AllowAM;
        private PictureBox PicItemImg;
        private ButtonX button_ClearPic;
        private ButtonX button_EnterImg;
        private Label label17;
        private Label label16;
        protected ButtonItem buttonItem_Menue;
        private ButtonItem buttonItem_GuestMove;
        private ButtonItem buttonItem_AddRoom;
        private ButtonItem buttonItem_ChangeRoomPrice;
        private ButtonItem buttonItem_ChangeRoomType;
        private TextBox textBox_RoomStat;
        protected Label label18;
        protected Label label20;
        protected Label label21;
        private TextBox Text_19;
        private TextBox Text_1;
        private DoubleInput Text_11;
        private DoubleInput Text_12;
        internal Label label22;
        private MaskedTextBox dateTimeInput_PassportDateEnd10;
        private MaskedTextBox dateTimeInput_PassportDateEnd9;
        private MaskedTextBox dateTimeInput_PassportDateEnd8;
        private MaskedTextBox dateTimeInput_PassportDateEnd7;
        private MaskedTextBox dateTimeInput_PassportDateEnd6;
        private MaskedTextBox dateTimeInput_PassportDateEnd5;
        private MaskedTextBox dateTimeInput_PassportDateEnd4;
        private MaskedTextBox dateTimeInput_PassportDateEnd3;
        private MaskedTextBox dateTimeInput_PassportDateEnd2;
        private MaskedTextBox dateTimeInput_PassportDateEnd1;
        private MaskedTextBox dateTimeInput_BirthDate10;
        private MaskedTextBox dateTimeInput_BirthDate9;
        private MaskedTextBox dateTimeInput_BirthDate8;
        private MaskedTextBox dateTimeInput_BirthDate7;
        private MaskedTextBox dateTimeInput_BirthDate6;
        private MaskedTextBox dateTimeInput_BirthDate5;
        private MaskedTextBox dateTimeInput_BirthDate4;
        private MaskedTextBox dateTimeInput_BirthDate3;
        private MaskedTextBox dateTimeInput_BirthDate2;
        private MaskedTextBox dateTimeInput_BirthDate1;
        private Label label122;
        private Label label123;
        private Label label129;
        private TextBox textBox_PassporntNo10;
        private TextBox textBox_Name10;
        private TextBox textBox_PassporntNo9;
        private TextBox textBox_Name9;
        private TextBox textBox_PassporntNo8;
        private TextBox textBox_Name8;
        private TextBox textBox_PassporntNo7;
        private TextBox textBox_Name7;
        private TextBox textBox_PassporntNo6;
        private TextBox textBox_Name6;
        private TextBox textBox_PassporntNo5;
        private TextBox textBox_Name5;
        private TextBox textBox_PassporntNo4;
        private TextBox textBox_Name4;
        private TextBox textBox_PassporntNo3;
        private TextBox textBox_Name3;
        private TextBox textBox_PassporntNo2;
        private TextBox textBox_Name2;
        private TextBox textBox_PassporntNo1;
        private TextBox textBox_Name1;
        private Label label132;
        private MaskedTextBox dateTimeInput_PassportDateStart10;
        private MaskedTextBox dateTimeInput_PassportDateStart9;
        private MaskedTextBox dateTimeInput_PassportDateStart8;
        private MaskedTextBox dateTimeInput_PassportDateStart7;
        private MaskedTextBox dateTimeInput_PassportDateStart6;
        private MaskedTextBox dateTimeInput_PassportDateStart5;
        private MaskedTextBox dateTimeInput_PassportDateStart4;
        private MaskedTextBox dateTimeInput_PassportDateStart3;
        private MaskedTextBox dateTimeInput_PassportDateStart2;
        private MaskedTextBox dateTimeInput_PassportDateStart1;
        private Label label23;
        private ButtonItem buttonItem_EditDays;
        protected ButtonItem buttonItem_Print;
        private ButtonX button_SrchCustNo;
        private ButtonItem buttonItem_SendSms;
        protected TextBox textBox_NameE;
        protected Label label24;
        private ButtonItem buttonItem_RepAcc;
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
        public T_per1 DataThisFamily
        {
            get
            {
                return DataThis_Family;
            }
            set
            {
                DataThis_Family = value;
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
        public T_per DataThis
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
                    if (!VarGeneral.TString.ChkStatShow(value.RepAcc2, 13))
                    {
                        IfAdd = false;
                    }
                    else
                    {
                        IfAdd = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.RepAcc2, 14))
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.RepAcc4, 0))
                    {
                        buttonItem_GuestMove.Enabled = false;
                    }
                    else
                    {
                        buttonItem_GuestMove.Enabled = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.RepAcc4, 1))
                    {
                        buttonItem_AddRoom.Enabled = false;
                    }
                    else
                    {
                        buttonItem_AddRoom.Enabled = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.RepAcc4, 2))
                    {
                        buttonItem_ChangeRoomPrice.Enabled = false;
                    }
                    else
                    {
                        buttonItem_ChangeRoomPrice.Enabled = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.RepAcc4, 3))
                    {
                        buttonItem_ChangeRoomType.Enabled = false;
                    }
                    else
                    {
                        buttonItem_ChangeRoomType.Enabled = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.RepAcc4, 4))
                    {
                        buttonItem_EditDays.Enabled = false;
                    }
                    else
                    {
                        buttonItem_EditDays.Enabled = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.RepAcc3, 4))
                    {
                        buttonItem_RepAcc.Enabled = false;
                    }
                    else
                    {
                        buttonItem_RepAcc.Enabled = true;
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
            VarGeneral.SFrmTyp = "T_per";
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
            List<T_per> list = db.FillPer_2(textBox_search.TextBox.Text).ToList();
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                }
            }
            FillHDGV(list);
        }
        public void FillHDGV(IEnumerable<T_per> new_data_enum)
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
            DGV_Main.PrimaryGrid.DataMember = "T_per";
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
            data_this = new T_per();
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
            textBox_NameA.Focus();
            checkBox_Chash.Checked = true;
            RadioBox_AllowAM.Checked = true;
            try
            {
                comboBox_Curr.SelectedValue = int.Parse(VarGeneral.Settings_Sys.ImportIp.ToString());
            }
            catch
            {
            }
            if (R3 == 0)
            {
                comboBox_Rooms.Enabled = false;
                superTabControl_Main2.Enabled = false;
                Button_Add.Enabled = false;
                Button_Search.Enabled = false;
                buttonItem_Menue.Enabled = false;
                expandableSplitter1.Expandable = false;
                expandableSplitter1.Enabled = false;
            }
            else
            {
                comboBox_Rooms.Enabled = true;
                superTabControl_Main2.Enabled = true;
                Button_Add.Enabled = true;
                Button_Search.Enabled = true;
                buttonItem_Menue.Enabled = true;
                expandableSplitter1.Expandable = true;
            }
            M = 0;
            Mm = 0;
            VarGeneral.ChkMove = 0;
            VarGeneral.ChkAddRoom = 0;
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
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                Framework.Keyboard.Language.Switch("Arabic");
            }
            else
            {
                Framework.Keyboard.Language.Switch("English");
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
            else if (e.KeyCode == Keys.Escape)
            {
                if (State == FormState.Saved)
                {
                    Close();
                }
                else if (State != FormState.New)
                {
                    textBox_ID_TextChanged(sender, e);
                }
                else
                {
                    Close();
                }
            }
        }
        public void RefreshPKeys()
        {
            PKeys.Clear();
            var qkeys = from item in db.T_pers
                        where item.ch == (int?)2
                        select new
                        {
                            Code = item.perno + ""
                        };
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
        private void ADD_Controls()
        {
            try
            {
                controls = new List<Control>();
                controls.Add(textBox_ID);
                codeControl = textBox_ID;
                controls.Add(textBox_Date);
                controls.Add(textBox_DayCount);
                controls.Add(textBox_DayRequest);
                controls.Add(textBox_ID_No);
                controls.Add(textBox_Mobile);
                controls.Add(textBox_NameA);
                controls.Add(textBox_Note);
                controls.Add(TextBox_Paid);
                controls.Add(TextBox_Remming);
                controls.Add(textBox_RoomPrice);
                controls.Add(textBox_Time);
                controls.Add(TextBox_TotalAm);
                controls.Add(RadioBox_AllowAM);
                controls.Add(RadioBox_AllowPM);
                controls.Add(comboBox_BirthPlace);
                controls.Add(comboBox_Nationality);
                controls.Add(comboBox_Curr);
                controls.Add(comboBox_DisTo);
                controls.Add(comboBox_DisType);
                controls.Add(comboBox_ID_From);
                controls.Add(comboBox_Job);
                controls.Add(comboBox_Rooms);
                controls.Add(comboBox_RoomTyp);
                controls.Add(Textbox_DiscountVal);
                controls.Add(textBox_NameE);
                controls.Add(txtCustNo);
                controls.Add(dateTimeInput_BirthDate);
                controls.Add(dateTimeInput_ID_Date);
                controls.Add(dateTimeInput_ID_DateEnd);
                controls.Add(textBox_RoomStat);
                controls.Add(Text_11);
                controls.Add(Text_12);
                controls.Add(Text_19);
                controls.Add(Text_1);
                controls.Add(textBox_Name1);
                controls.Add(textBox_Name2);
                controls.Add(textBox_Name3);
                controls.Add(textBox_Name4);
                controls.Add(textBox_Name5);
                controls.Add(textBox_Name6);
                controls.Add(textBox_Name7);
                controls.Add(textBox_Name8);
                controls.Add(textBox_Name9);
                controls.Add(textBox_Name10);
                controls.Add(dateTimeInput_BirthDate1);
                controls.Add(dateTimeInput_BirthDate2);
                controls.Add(dateTimeInput_BirthDate3);
                controls.Add(dateTimeInput_BirthDate4);
                controls.Add(dateTimeInput_BirthDate5);
                controls.Add(dateTimeInput_BirthDate6);
                controls.Add(dateTimeInput_BirthDate7);
                controls.Add(dateTimeInput_BirthDate8);
                controls.Add(dateTimeInput_BirthDate9);
                controls.Add(dateTimeInput_BirthDate10);
                controls.Add(textBox_PassporntNo1);
                controls.Add(textBox_PassporntNo2);
                controls.Add(textBox_PassporntNo3);
                controls.Add(textBox_PassporntNo4);
                controls.Add(textBox_PassporntNo5);
                controls.Add(textBox_PassporntNo6);
                controls.Add(textBox_PassporntNo7);
                controls.Add(textBox_PassporntNo8);
                controls.Add(textBox_PassporntNo9);
                controls.Add(textBox_PassporntNo10);
                controls.Add(dateTimeInput_PassportDateStart1);
                controls.Add(dateTimeInput_PassportDateStart2);
                controls.Add(dateTimeInput_PassportDateStart3);
                controls.Add(dateTimeInput_PassportDateStart4);
                controls.Add(dateTimeInput_PassportDateStart5);
                controls.Add(dateTimeInput_PassportDateStart6);
                controls.Add(dateTimeInput_PassportDateStart7);
                controls.Add(dateTimeInput_PassportDateStart8);
                controls.Add(dateTimeInput_PassportDateStart9);
                controls.Add(dateTimeInput_PassportDateStart10);
                controls.Add(dateTimeInput_PassportDateEnd1);
                controls.Add(dateTimeInput_PassportDateEnd2);
                controls.Add(dateTimeInput_PassportDateEnd3);
                controls.Add(dateTimeInput_PassportDateEnd4);
                controls.Add(dateTimeInput_PassportDateEnd5);
                controls.Add(dateTimeInput_PassportDateEnd6);
                controls.Add(dateTimeInput_PassportDateEnd7);
                controls.Add(dateTimeInput_PassportDateEnd8);
                controls.Add(dateTimeInput_PassportDateEnd9);
                controls.Add(dateTimeInput_PassportDateEnd10);
            }
            catch (SqlException)
            {
            }
        }
        public FrmGuests()
        {
            InitializeComponent();
            Button_Close.Click += Button_Close_Click;
            textBox_Date.Click += Button_Edit_Click;
            textBox_DayRequest.Click += Button_Edit_Click;
            Textbox_DiscountVal.Click += Button_Edit_Click;
            textBox_Mobile.Click += Button_Edit_Click;
            textBox_NameA.Click += Button_Edit_Click;
            textBox_NameE.Click += Button_Edit_Click;
            textBox_Note.Click += Button_Edit_Click;
            textBox_RoomPrice.Click += Button_Edit_Click;
            textBox_Time.Click += Button_Edit_Click;
            dateTimeInput_BirthDate.Click += Button_Edit_Click;
            dateTimeInput_ID_Date.Click += Button_Edit_Click;
            dateTimeInput_ID_DateEnd.Click += Button_Edit_Click;
            CmbIDTyp.Click += Button_Edit_Click;
            comboBox_BirthPlace.Click += Button_Edit_Click;
            comboBox_Curr.Click += Button_Edit_Click;
            comboBox_DisTo.Click += Button_Edit_Click;
            comboBox_DisType.Click += Button_Edit_Click;
            comboBox_ID_From.Click += Button_Edit_Click;
            comboBox_Job.Click += Button_Edit_Click;
            comboBox_Nationality.Click += Button_Edit_Click;
            comboBox_Religion.Click += Button_Edit_Click;
            RadioBox_AllowPM.Click += Button_Edit_Click;
            RadioBox_AllowAM.Click += Button_Edit_Click;
            checkBox_Chash.Click += Button_Edit_Click;
            checkBox_Credit.Click += Button_Edit_Click;
            textBox_ID_No.Click += Button_Edit_Click;
            comboBox_RoomTyp.Click += Button_Edit_Click;
            textBox_Name1.Click += Button_Edit_Click;
            textBox_Name2.Click += Button_Edit_Click;
            textBox_Name3.Click += Button_Edit_Click;
            textBox_Name4.Click += Button_Edit_Click;
            textBox_Name5.Click += Button_Edit_Click;
            textBox_Name6.Click += Button_Edit_Click;
            textBox_Name7.Click += Button_Edit_Click;
            textBox_Name8.Click += Button_Edit_Click;
            textBox_Name9.Click += Button_Edit_Click;
            textBox_Name10.Click += Button_Edit_Click;
            dateTimeInput_BirthDate1.Click += Button_Edit_Click;
            dateTimeInput_BirthDate2.Click += Button_Edit_Click;
            dateTimeInput_BirthDate3.Click += Button_Edit_Click;
            dateTimeInput_BirthDate4.Click += Button_Edit_Click;
            dateTimeInput_BirthDate5.Click += Button_Edit_Click;
            dateTimeInput_BirthDate6.Click += Button_Edit_Click;
            dateTimeInput_BirthDate7.Click += Button_Edit_Click;
            dateTimeInput_BirthDate8.Click += Button_Edit_Click;
            dateTimeInput_BirthDate9.Click += Button_Edit_Click;
            dateTimeInput_BirthDate10.Click += Button_Edit_Click;
            textBox_PassporntNo1.Click += Button_Edit_Click;
            textBox_PassporntNo2.Click += Button_Edit_Click;
            textBox_PassporntNo3.Click += Button_Edit_Click;
            textBox_PassporntNo4.Click += Button_Edit_Click;
            textBox_PassporntNo5.Click += Button_Edit_Click;
            textBox_PassporntNo6.Click += Button_Edit_Click;
            textBox_PassporntNo7.Click += Button_Edit_Click;
            textBox_PassporntNo8.Click += Button_Edit_Click;
            textBox_PassporntNo9.Click += Button_Edit_Click;
            textBox_PassporntNo10.Click += Button_Edit_Click;
            dateTimeInput_PassportDateStart1.Click += Button_Edit_Click;
            dateTimeInput_PassportDateStart2.Click += Button_Edit_Click;
            dateTimeInput_PassportDateStart3.Click += Button_Edit_Click;
            dateTimeInput_PassportDateStart4.Click += Button_Edit_Click;
            dateTimeInput_PassportDateStart5.Click += Button_Edit_Click;
            dateTimeInput_PassportDateStart6.Click += Button_Edit_Click;
            dateTimeInput_PassportDateStart7.Click += Button_Edit_Click;
            dateTimeInput_PassportDateStart8.Click += Button_Edit_Click;
            dateTimeInput_PassportDateStart9.Click += Button_Edit_Click;
            dateTimeInput_PassportDateStart10.Click += Button_Edit_Click;
            dateTimeInput_PassportDateEnd1.Click += Button_Edit_Click;
            dateTimeInput_PassportDateEnd2.Click += Button_Edit_Click;
            dateTimeInput_PassportDateEnd3.Click += Button_Edit_Click;
            dateTimeInput_PassportDateEnd4.Click += Button_Edit_Click;
            dateTimeInput_PassportDateEnd5.Click += Button_Edit_Click;
            dateTimeInput_PassportDateEnd6.Click += Button_Edit_Click;
            dateTimeInput_PassportDateEnd7.Click += Button_Edit_Click;
            dateTimeInput_PassportDateEnd8.Click += Button_Edit_Click;
            dateTimeInput_PassportDateEnd9.Click += Button_Edit_Click;
            dateTimeInput_PassportDateEnd10.Click += Button_Edit_Click;
            expandableSplitter1.Click += expandableSplitter1_Click;
            ToolStripMenuItem_Det.Click += ToolStripMenuItem_Det_Click;
            Button_ExportTable2.Click += Button_ExportTable2_Click;
            Button_First.Click += Button_First_Click;
            Button_Prev.Click += Button_Prev_Click;
            Button_Next.Click += Button_Next_Click;
            Button_Last.Click += Button_Last_Click;
            Button_Add.Click += Button_Add_Click;
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmGuests));
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
                Button_Save.Text = "حفظ";
                Button_Search.Text = "بحث";
                Button_First.Tooltip = "السجل الاول";
                Button_Last.Tooltip = "السجل الاخير";
                Button_Next.Tooltip = "السجل التالي";
                Button_Prev.Tooltip = "السجل السابق";
                buttonItem_Print.Text = ((_InvSetting.InvpRINTERInfo.nTyp.Substring(2, 1) == "0") ? "طباعة" : "عــرض");
                buttonItem_Print.Tooltip = "F5";
                Button_Add.Tooltip = "F1";
                Button_Close.Tooltip = "Esc";
                Button_Save.Tooltip = "F2";
                Button_Search.Tooltip = "F4";
                Button_PrintTable.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "طباعة" : "عــرض");
                Button_PrintTable.Tooltip = "F5";
                Button_ExportTable2.Text = "تصدير";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "جميع السجلات";
                buttonItem_EditDays.Text = "تعديل الشهور المطلوبة";
                buttonItem_SendSms.Text = "إرسال رسالة نصية";
                buttonItem_GuestMove.Text = "نقل الساكن";
                buttonItem_AddRoom.Text = " إضافة ملحق";
                buttonItem_ChangeRoomPrice.Text = "تغيير السعــر";
                buttonItem_ChangeRoomType.Text = "تغيير نوع السـكن";
                buttonItem_RepAcc.Text = "كشف حساب النزيل";
                Text = "كرت بيانات النزلاء";
            }
            else
            {
                Button_First.Text = "First";
                Button_Last.Text = "Last";
                Button_Next.Text = "Next";
                Button_Prev.Text = "Previous";
                Button_Add.Text = "New";
                Button_Close.Text = "Close";
                Button_Save.Text = "Save";
                Button_Search.Text = "Search";
                Button_First.Tooltip = "First Record";
                Button_Last.Tooltip = "Last Record";
                Button_Next.Tooltip = "Next Record";
                Button_Prev.Tooltip = "Previous Record";
                buttonItem_Print.Text = ((_InvSetting.InvpRINTERInfo.nTyp.Substring(2, 1) == "0") ? "Print" : "Show");
                buttonItem_Print.Tooltip = "F5";
                Button_Add.Tooltip = "F1";
                Button_Close.Tooltip = "Esc";
                Button_Save.Tooltip = "F2";
                Button_Search.Tooltip = "F4";
                Button_PrintTable.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "Print" : "Show");
                Button_PrintTable.Tooltip = "F5";
                Button_ExportTable2.Text = "Export";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "All Records";
                textBox_Note.WatermarkText = "Note";
                tabItem_GuestsData.Text = "Guest Data";
                tabItem_FamilyData.Text = "Family Data";
                buttonItem_EditDays.Text = "Modification of required months";
                buttonItem_SendSms.Text = "Send SMS";
                buttonItem_GuestMove.Text = "Guest Move";
                buttonItem_AddRoom.Text = "Add Room";
                buttonItem_ChangeRoomPrice.Text = "Price Change";
                buttonItem_ChangeRoomType.Text = "Accommodation Type Change";
                buttonItem_RepAcc.Text = "Guest account statement";
                Text = "Guests Data Card";
            }
        }
        private void FrmGuests_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmGuests));
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
                    columns_Names_visible.Add("perno", new ColumnDictinary("رقم النزيل", "Ghoust No", ifDefault: true, ""));
                    columns_Names_visible.Add("nmA", new ColumnDictinary("الإسم العربي", "Arabic Name", ifDefault: true, ""));
                    columns_Names_visible.Add("nmE", new ColumnDictinary("الإسم الانجليزي", "English Name", ifDefault: false, ""));
                    columns_Names_visible.Add("price", new ColumnDictinary("سعر الغرفة", "Price", ifDefault: true, ""));
                    columns_Names_visible.Add("day", new ColumnDictinary("الأيام المطلوبة", "Days", ifDefault: true, ""));
                    columns_Names_visible.Add("pasno", new ColumnDictinary("رقم الهوية", "ID No", ifDefault: true, ""));
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
                R1 = VarGeneral.Trn;
                if (R1 == 4)
                {
                    R2 = VarGeneral.Tmp4;
                    R3 = VarGeneral._hotelper;
                    VarGeneral.Trn = 0;
                }
                else
                {
                    R2 = VarGeneral._hotelrom;
                    R3 = VarGeneral._hotelper;
                }
                FillCombo();
                GetInvSetting();
                ViewDetails_Click(sender, e);
                UpdateVcr();
                if (R3 == 0)
                {
                    if (VarGeneral.vGuestData == 0)
                    {
                        Button_Add.Visible = false;
                        textBox_ID.TextChanged += textBox_ID_TextChanged;
                        textBox_ID.Text = PKeys.FirstOrDefault();
                    }
                    else
                    {
                        buttonItem_Print.Visible = false;
                        Button_Add_Click(sender, e);
                        superTabControl_Main2.Visible = false;
                        Button_Search.Visible = false;
                        expandableSplitter1.Expandable = false;
                        expandableSplitter1.Enabled = false;
                        comboBox_RoomTyp_Leave(sender, e);
                    }
                }
                else if (R3 > 0 && R2 > 0 && db.StockRoom(R2).state.Value == 3)
                {
                    Button_Add.Visible = false;
                    textBox_ID.TextChanged += textBox_ID_TextChanged;
                    comboBox_Rooms.Enabled = false;
                    textBox_ID.Text = R3.ToString();
                    superTabControl_Main2.Visible = false;
                    Button_Search.Visible = false;
                    expandableSplitter1.Expandable = false;
                    expandableSplitter1.Enabled = false;
                }
                base.ActiveControl = textBox_NameA;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        public void FillCombo()
        {
            comboBox_DisType.Items.Clear();
            comboBox_DisType.Items.Add((LangArEn == 0) ? "بدون خصم" : "Without Discount");
            comboBox_DisType.Items.Add((LangArEn == 0) ? "خصم نسبة" : "Discount %");
            comboBox_DisType.Items.Add((LangArEn == 0) ? "خصم قيمة" : "Discount Value");
            comboBox_DisType.SelectedIndex = 0;
            comboBox_DisTo.Items.Clear();
            comboBox_DisTo.Items.Add((LangArEn == 0) ? "قيمة الإقامة" : "Residence Value");
            comboBox_DisTo.Items.Add((LangArEn == 0) ? "الإجمالي" : "Total");
            comboBox_DisTo.SelectedIndex = 0;
            comboBox_RoomTyp.Items.Clear();
            comboBox_RoomTyp.Items.Add((LangArEn == 0) ? "يومي" : "Daily");
            comboBox_RoomTyp.Items.Add((LangArEn == 0) ? "شهري" : "Monthly");
            comboBox_RoomTyp.SelectedIndex = -1;
            List<T_IDType> listIDType = new List<T_IDType>(db.T_IDTypes.Select((T_IDType item) => item).ToList());
            CmbIDTyp.DataSource = null;
            CmbIDTyp.DataSource = listIDType;
            CmbIDTyp.DisplayMember = ((LangArEn == 0) ? "Arb_Des" : "Eng_Des");
            CmbIDTyp.ValueMember = "IDType_ID";
            List<T_Job> listJob = new List<T_Job>(db.T_Jobs.Select((T_Job item) => item).ToList());
            listJob.Insert(0, new T_Job());
            comboBox_Job.DataSource = null;
            comboBox_Job.DataSource = listJob;
            comboBox_Job.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Job.ValueMember = "Job_No";
            List<T_Religion> listReligion = new List<T_Religion>(db.T_Religions.Select((T_Religion item) => item).ToList());
            listReligion.Insert(0, new T_Religion());
            comboBox_Religion.DataSource = null;
            comboBox_Religion.DataSource = listReligion;
            comboBox_Religion.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Religion.ValueMember = "Religion_No";
            List<T_BirthPlace> listBirthPlace = new List<T_BirthPlace>(db.T_BirthPlaces.Select((T_BirthPlace item) => item).ToList());
            listBirthPlace.Insert(0, new T_BirthPlace());
            comboBox_BirthPlace.DataSource = null;
            comboBox_BirthPlace.DataSource = listBirthPlace;
            comboBox_BirthPlace.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_BirthPlace.ValueMember = "BirthPlaceNo";
            List<T_City> listIDFrom = new List<T_City>(db.T_Cities.Select((T_City item) => item).ToList());
            listIDFrom.Insert(0, new T_City());
            comboBox_ID_From.DataSource = null;
            comboBox_ID_From.DataSource = listIDFrom;
            comboBox_ID_From.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_ID_From.ValueMember = "City_No";
            List<T_Nationality> listNation = new List<T_Nationality>(db.T_Nationalities.Select((T_Nationality item) => item).ToList());
            listNation.Insert(0, new T_Nationality());
            comboBox_Nationality.DataSource = null;
            comboBox_Nationality.DataSource = listNation;
            comboBox_Nationality.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Nationality.ValueMember = "Nation_No";
            List<T_Curency> listCurr = new List<T_Curency>(db.T_Curencies.Select((T_Curency item) => item).ToList());
            comboBox_Curr.DataSource = listCurr;
            comboBox_Curr.DisplayMember = ((LangArEn == 0) ? "Arb_Des" : "Eng_Des");
            comboBox_Curr.ValueMember = "Curency_ID";
            comboBox_Curr.SelectedIndex = 0;
            List<T_Rom> listRoms = new List<T_Rom>(db.T_Roms.Select((T_Rom item) => item).ToList());
            comboBox_Rooms.DataSource = listRoms;
            comboBox_Rooms.DisplayMember = "romno";
            comboBox_Rooms.ValueMember = "romno";
            comboBox_Rooms.SelectedIndex = -1;
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
                T_per newData = db.StockPer(no);
                if (newData == null || newData.perno == 0)
                {
                    if (!Button_Add.Visible)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textBox_ID.TextChanged -= textBox_ID_TextChanged;
                        try
                        {
                            textBox_ID.Text = data_this.perno.ToString();
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
                    int indexA = PKeys.IndexOf(string.Concat(newData.perno));
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
        private void RomFill()
        {
            SS = 0;
            aa = "";
            T_Rom q = db.StockRoom(R2);
            if (q.typ.Value == 0)
            {
                label5.Text = ((LangArEn == 0) ? "رقم الغرفة" : "Room No :");
                label8.Text = ((LangArEn == 0) ? "سعر الغرفة" : "Price :");
            }
            else if (q.typ.Value == 1)
            {
                label5.Text = ((LangArEn == 0) ? "رقم الجناح" : "suite No :");
                label8.Text = ((LangArEn == 0) ? "سعر الجناح" : "Price :");
            }
            else if (q.typ.Value == 2)
            {
                label5.Text = ((LangArEn == 0) ? "رقم الفيلا" : "villa No :");
                label8.Text = ((LangArEn == 0) ? "سعر الفيلا" : "Price :");
            }
            else if (q.typ.Value == 3)
            {
                label5.Text = ((LangArEn == 0) ? "رقم الشقة" : "apartment :");
                label8.Text = ((LangArEn == 0) ? "سعر الشقة" : "Price :");
            }
            if (R1 == 0)
            {
                if (q.state.Value == 2)
                {
                    label11.Text = ((LangArEn == 0) ? "تاريخ الحجز :" : "booking date");
                }
                else if (q.state.Value == 3)
                {
                    label11.Text = ((LangArEn == 0) ? "تاريخ السكن :" : "Date :");
                }
            }
            else if (R1 == 1)
            {
                label11.Text = ((LangArEn == 0) ? "تاريخ الحجز :" : "booking date");
            }
            else if (R1 == 2 || R1 == 4)
            {
                label11.Text = ((LangArEn == 0) ? "تاريخ السكن :" : "Date :");
            }
            List<T_Rom> listRoms = new List<T_Rom>(db.T_Roms.Select((T_Rom item) => item).ToList());
            List<T_Rom> _list = new List<T_Rom>();
            if (R1 == 0)
            {
                for (int i = 0; i < listRoms.Count; i++)
                {
                    if (listRoms[i].state.Value == 3)
                    {
                        aa = "1";
                        _list.Add(listRoms[i]);
                    }
                }
                comboBox_Rooms.DataSource = _list;
                comboBox_Rooms.DisplayMember = "romno";
                comboBox_Rooms.ValueMember = "perno";
            }
            else if (R1 == 4)
            {
                for (int i = 0; i < listRoms.Count; i++)
                {
                    if (listRoms[i].state.Value == 1)
                    {
                        aa = "1";
                        _list.Add(listRoms[i]);
                    }
                }
                comboBox_Rooms.DataSource = _list;
                comboBox_Rooms.DisplayMember = "romno";
                comboBox_Rooms.ValueMember = "perno";
            }
            else if (R1 == 1 || R1 == 2)
            {
                for (int i = 0; i < listRoms.Count; i++)
                {
                    if (listRoms[i].state.Value == 1)
                    {
                        aa = "1";
                        _list.Add(listRoms[i]);
                    }
                }
                comboBox_Rooms.DataSource = _list;
                comboBox_Rooms.DisplayMember = "romno";
                comboBox_Rooms.ValueMember = "perno";
            }
            comboBox_Rooms.SelectedIndex = 0;
            M = 0;
            Mm = 0;
            comboBox_Rooms.SelectedValue = R2;
        }
        public void SetData(T_per value)
        {
            try
            {
                State = FormState.Saved;
                Button_Save.Enabled = false;
                ButtonItem buttonItem = buttonItem_AddRoom;
                int? hed = db.StockRoom(value.romno.Value).hed;
                buttonItem.Enabled = ((hed.GetValueOrDefault() != 0 || !hed.HasValue) ? true : false);
                if (db.StockRoom(value.romno.Value).typ.Value == 0)
                {
                    label5.Text = ((LangArEn == 0) ? "رقم الغرفة :" : "Room No :");
                    if (LangArEn == 1)
                    {
                        label5.Left += 10;
                    }
                    label8.Text = ((LangArEn == 0) ? "سعر الغرفة :" : "Price :");
                }
                else if (db.StockRoom(value.romno.Value).typ.Value == 1)
                {
                    label5.Text = ((LangArEn == 0) ? "رقم الجنـاح :" : "suite No :");
                    if (LangArEn == 1)
                    {
                        label5.Left += 10;
                    }
                    label8.Text = ((LangArEn == 0) ? "سعر الجنـاح :" : "Price :");
                }
                else if (db.StockRoom(value.romno.Value).typ.Value == 2)
                {
                    label5.Text = ((LangArEn == 0) ? "رقم الفيلا :" : "villa No :");
                    if (LangArEn == 1)
                    {
                        label5.Left += 10;
                    }
                    label8.Text = ((LangArEn == 0) ? "سعر الفيلا :" : "Price :");
                }
                else if (db.StockRoom(value.romno.Value).typ.Value == 3)
                {
                    label5.Text = ((LangArEn == 0) ? "رقم الشقـة :" : "apartment :");
                    label8.Text = ((LangArEn == 0) ? "سعر الشقـة :" : "Price :");
                }
                if (R1 == 0)
                {
                    if (db.StockRoom(value.romno.Value).state.Value == 2)
                    {
                        label11.Text = ((LangArEn == 0) ? "تاريخ الحجز :" : "booking date");
                    }
                    else if (db.StockRoom(value.romno.Value).state.Value == 3)
                    {
                        label11.Text = ((LangArEn == 0) ? "تاريخ السكن :" : "Date :");
                        if (LangArEn == 1)
                        {
                            label11.Left = label6.Left + 18;
                        }
                    }
                }
                else if (R1 == 1)
                {
                    label11.Text = ((LangArEn == 0) ? "تاريخ الحجز :" : "booking date");
                }
                else if (R1 == 2 || R1 == 4)
                {
                    label11.Text = ((LangArEn == 0) ? "تاريخ السكن :" : "Date :");
                    if (LangArEn == 1)
                    {
                        label11.Left = label6.Left + 18;
                    }
                }
                if (db.StockRoom(value.romno.Value).state == 1)
                {
                    textBox_RoomStat.Text = ((LangArEn == 0) ? "فارغة" : "Empty");
                }
                else if (db.StockRoom(value.romno.Value).state == 2)
                {
                    textBox_RoomStat.Text = ((LangArEn == 0) ? "محجوزة" : "Reserved");
                }
                else if (db.StockRoom(value.romno.Value).state == 3)
                {
                    textBox_RoomStat.Text = ((LangArEn == 0) ? "مشغولة" : "Busy");
                }
                comboBox_DisType.SelectedIndex = value.disknd.Value;
                comboBox_DisTo.SelectedIndex = value.distyp.Value;
                comboBox_RoomTyp.SelectedIndex = value.KindPer.Value;
                try
                {
                    if (!string.IsNullOrEmpty(value.Cust_no))
                    {
                        txtCustNo.Text = value.Cust_no.ToString();
                        textBox_NameA.Text = db.StockAccDefWithOutBalance(value.Cust_no).Arb_Des;
                        textBox_NameE.Text = db.StockAccDefWithOutBalance(value.Cust_no).Eng_Des;
                    }
                    else
                    {
                        txtCustNo.Text = "";
                    }
                }
                catch
                {
                    txtCustNo.Text = "";
                }
                if (value.nath.HasValue)
                {
                    comboBox_Nationality.SelectedValue = value.nath;
                }
                else
                {
                    comboBox_Nationality.SelectedIndex = 0;
                }
                if (value.pastyp.HasValue)
                {
                    CmbIDTyp.SelectedValue = value.pastyp;
                }
                else
                {
                    CmbIDTyp.SelectedIndex = 0;
                }
                if (value.job.HasValue)
                {
                    comboBox_Job.SelectedValue = value.job;
                }
                else
                {
                    comboBox_Job.SelectedIndex = 0;
                }
                if (value.curr.HasValue)
                {
                    comboBox_Curr.SelectedValue = value.curr;
                }
                else
                {
                    comboBox_Curr.SelectedIndex = 0;
                }
                if (value.romno.HasValue)
                {
                    comboBox_Rooms.SelectedValue = value.romno.Value;
                }
                if (!string.IsNullOrEmpty(value.bpls))
                {
                    comboBox_BirthPlace.SelectedValue = int.Parse(value.bpls);
                }
                else
                {
                    comboBox_BirthPlace.SelectedIndex = 0;
                }
                if (value.vip.HasValue)
                {
                    comboBox_Religion.SelectedValue = value.vip;
                }
                else
                {
                    comboBox_Religion.SelectedIndex = 0;
                }
                if (!string.IsNullOrEmpty(value.paspls))
                {
                    comboBox_ID_From.SelectedValue = int.Parse(value.paspls);
                }
                else
                {
                    comboBox_ID_From.SelectedIndex = 0;
                }
                if (value.cc.HasValue)
                {
                    hed = value.cc;
                    if (hed.Value == 0 && hed.HasValue)
                    {
                        checkBox_Chash.Checked = true;
                    }
                    else if (value.cc == 1)
                    {
                        checkBox_Credit.Checked = true;
                    }
                }
                if (value.pict != null)
                {
                    byte[] arr = value.pict.ToArray();
                    MemoryStream stream = new MemoryStream(arr);
                    PicItemImg.Image = Image.FromStream(stream);
                }
                else
                {
                    PicItemImg.Image = null;
                }
                textBox_ID.Tag = value.perno;
                textBox_DayCount.Text = value.day;
                dateTimeInput_BirthDate.Text = value.bdt;
                textBox_ID_No.Text = value.pasno;
                dateTimeInput_ID_Date.Text = value.passt;
                dateTimeInput_ID_DateEnd.Text = value.pasend;
                textBox_Mobile.Text = value.enddt;
                textBox_Note.Text = value.jobpls;
                try
                {
                    Text_11.Value = value.ser.Value;
                }
                catch
                {
                    Text_11.Value = 0.0;
                }
                try
                {
                    Text_12.Value = value.tax.Value;
                }
                catch
                {
                    Text_12.Value = 0.0;
                }
                textBox_RoomPrice.Value = value.price.Value;
                Textbox_DiscountVal.Value = value.dis.Value;
                textBox_DayRequest.Value = value.DayImport.Value;
                if (value.DayOfM.HasValue)
                {
                    VarGeneral.GDayM = value.DayOfM.Value;
                }
                else
                {
                    VarGeneral.GDayM = 0;
                }
                try
                {
                    if (VarGeneral.GDayM == 0)
                    {
                        VarGeneral.GDayM = VarGeneral.Settings_Sys.DayOfM.Value;
                    }
                }
                catch
                {
                }
                BindingList<T_per1> Family_line = new BindingList<T_per1>(value.T_per1s);
                FillFamilyBox(Family_line);
                if (R1 != 0)
                {
                    return;
                }
                if (db.StockRoom(value.romno.Value).state.Value == 2)
                {
                    label11.Text = ((LangArEn == 0) ? "تاريخ الحجز :" : "booking date");
                    textBox_Time.Text = value.tm1;
                    textBox_Date.Text = db.StockRoom(value.romno.Value).dt;
                    if (value.vAmPm == "AM")
                    {
                        RadioBox_AllowAM.Checked = true;
                    }
                    else
                    {
                        RadioBox_AllowPM.Checked = true;
                    }
                }
                else if (db.StockRoom(value.romno.Value).state.Value == 3)
                {
                    label11.Text = ((LangArEn == 0) ? "تاريخ السكن :" : "Date :");
                    if (LangArEn == 1)
                    {
                        label11.Left = label6.Left + 18;
                    }
                    if (comboBox_RoomTyp.SelectedIndex == 0)
                    {
                        textBox_DayCount.Value = VarGeneral.Dy(db.StockRoom(value.romno.Value).dt, db.StockRoom(value.romno.Value).tm);
                    }
                    else
                    {
                        textBox_DayCount.Value = VarGeneral.Dy(db.StockRoom(value.romno.Value).dt, db.StockRoom(value.romno.Value).tm);
                        VarGeneral.Dy2(db.StockRoom(value.romno.Value).dt, db.StockRoom(value.romno.Value).tm);
                        textBox_DayRequest.Enabled = false;
                    }
                    Total();
                    textBox_Time.Text = value.tm1;
                    textBox_Date.Text = db.StockRoom(value.romno.Value).dt;
                    if (value.vAmPm == "AM")
                    {
                        RadioBox_AllowAM.Checked = true;
                    }
                    else
                    {
                        RadioBox_AllowPM.Checked = true;
                    }
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SetData:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void FillFamilyBox(BindingList<T_per1> linesList)
        {
            if (linesList.Count <= 0)
            {
                return;
            }
            linesList.OrderBy((T_per1 g) => g.ID);
            for (int i = 0; i < linesList.Count; i++)
            {
                if (i == 0)
                {
                    textBox_Name1.Text = linesList[i].nm;
                    try
                    {
                        dateTimeInput_BirthDate1.Text = Convert.ToDateTime(linesList[i].bpls).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate1.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd1.Text = Convert.ToDateTime(linesList[i].pasend).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd1.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateStart1.Text = Convert.ToDateTime(linesList[i].passt).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart1.Text = "";
                    }
                    textBox_PassporntNo1.Text = linesList[i].pasno;
                }
                if (i == 1)
                {
                    textBox_Name2.Text = linesList[i].nm;
                    try
                    {
                        dateTimeInput_BirthDate2.Text = Convert.ToDateTime(linesList[i].bpls).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate2.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd2.Text = Convert.ToDateTime(linesList[i].pasend).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd2.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateStart2.Text = Convert.ToDateTime(linesList[i].passt).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart2.Text = "";
                    }
                    textBox_PassporntNo2.Text = linesList[i].pasno;
                }
                if (i == 2)
                {
                    textBox_Name3.Text = linesList[i].nm;
                    try
                    {
                        dateTimeInput_BirthDate3.Text = Convert.ToDateTime(linesList[i].bpls).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate3.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd3.Text = Convert.ToDateTime(linesList[i].pasend).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd3.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateStart3.Text = Convert.ToDateTime(linesList[i].passt).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart3.Text = "";
                    }
                    textBox_PassporntNo3.Text = linesList[i].pasno;
                }
                if (i == 3)
                {
                    textBox_Name4.Text = linesList[i].nm;
                    try
                    {
                        dateTimeInput_BirthDate4.Text = Convert.ToDateTime(linesList[i].bpls).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate4.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd4.Text = Convert.ToDateTime(linesList[i].pasend).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd4.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateStart4.Text = Convert.ToDateTime(linesList[i].passt).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart4.Text = "";
                    }
                    textBox_PassporntNo4.Text = linesList[i].pasno;
                }
                if (i == 4)
                {
                    textBox_Name5.Text = linesList[i].nm;
                    try
                    {
                        dateTimeInput_BirthDate5.Text = Convert.ToDateTime(linesList[i].bpls).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate5.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd5.Text = Convert.ToDateTime(linesList[i].pasend).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd5.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateStart5.Text = Convert.ToDateTime(linesList[i].passt).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart5.Text = "";
                    }
                    textBox_PassporntNo5.Text = linesList[i].pasno;
                }
                if (i == 5)
                {
                    textBox_Name6.Text = linesList[i].nm;
                    try
                    {
                        dateTimeInput_BirthDate6.Text = Convert.ToDateTime(linesList[i].bpls).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate6.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd6.Text = Convert.ToDateTime(linesList[i].pasend).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd6.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateStart6.Text = Convert.ToDateTime(linesList[i].passt).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart6.Text = "";
                    }
                    textBox_PassporntNo6.Text = linesList[i].pasno;
                }
                if (i == 6)
                {
                    textBox_Name7.Text = linesList[i].nm;
                    try
                    {
                        dateTimeInput_BirthDate7.Text = Convert.ToDateTime(linesList[i].bpls).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate7.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd6.Text = Convert.ToDateTime(linesList[i].pasend).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd6.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateStart7.Text = Convert.ToDateTime(linesList[i].passt).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart7.Text = "";
                    }
                    textBox_PassporntNo7.Text = linesList[i].pasno;
                }
                if (i == 7)
                {
                    textBox_Name8.Text = linesList[i].nm;
                    try
                    {
                        dateTimeInput_BirthDate8.Text = Convert.ToDateTime(linesList[i].bpls).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate8.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd6.Text = Convert.ToDateTime(linesList[i].pasend).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd6.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateStart8.Text = Convert.ToDateTime(linesList[i].passt).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart8.Text = "";
                    }
                    textBox_PassporntNo8.Text = linesList[i].pasno;
                }
                if (i == 8)
                {
                    textBox_Name9.Text = linesList[i].nm;
                    try
                    {
                        dateTimeInput_BirthDate9.Text = Convert.ToDateTime(linesList[i].bpls).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate9.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd9.Text = Convert.ToDateTime(linesList[i].pasend).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd9.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateStart9.Text = Convert.ToDateTime(linesList[i].passt).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart9.Text = "";
                    }
                    textBox_PassporntNo9.Text = linesList[i].pasno;
                }
                if (i == 9)
                {
                    textBox_Name10.Text = linesList[i].nm;
                    try
                    {
                        dateTimeInput_BirthDate10.Text = Convert.ToDateTime(linesList[i].bpls).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate10.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd10.Text = Convert.ToDateTime(linesList[i].pasend).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd10.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateStart10.Text = Convert.ToDateTime(linesList[i].passt).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart10.Text = "";
                    }
                    textBox_PassporntNo10.Text = linesList[i].pasno;
                }
            }
        }
        private void Total()
        {
            try
            {
                double Tot1 = 0.0;
                double Tot3 = 0.0;
                double Tot4 = 0.0;
                double Tot5 = 0.0;
                double Tot6 = 0.0;
                double Tot7 = 0.0;
                double Tot8 = 0.0;
                double Tot9 = 0.0;
                double Tot2 = 0.0;
                if (db.StockRoom(data_this.romno.Value).hed.Value == 1 || db.StockRoom(data_this.romno.Value).hed.Value == 0)
                {
                    try
                    {
                        List<double> sqlst = db.ExecuteQuery<double>("select sum(price) as SumPrice from [T_tran] where perno=" + textBox_ID.Text, new object[0]).ToList();
                        if (sqlst.Count > 0)
                        {
                            Tot1 = ((!string.IsNullOrEmpty(sqlst.FirstOrDefault().ToString())) ? sqlst.FirstOrDefault() : 0.0);
                        }
                    }
                    catch
                    {
                        Tot1 = 0.0;
                    }
                    try
                    {
                        List<double> sqlst = db.ExecuteQuery<double>("select sum(price) as SumPrice from [T_tel] where perno=" + textBox_ID.Text, new object[0]).ToList();
                        if (sqlst.Count > 0)
                        {
                            Tot3 = ((!string.IsNullOrEmpty(sqlst.FirstOrDefault().ToString())) ? sqlst.FirstOrDefault() : 0.0);
                        }
                    }
                    catch
                    {
                        Tot3 = 0.0;
                    }
                    try
                    {
                        List<double> sqlst = db.ExecuteQuery<double>("SELECT Sum(case when [T_Snd].[typ]=1 then [T_Snd].[price]*[T_Snd].[curcost] else -[T_Snd].[price]*[T_Snd].[curcost] end) AS SumPrice FROM [T_Snd] where perno=" + textBox_ID.Text + " and ch<>3", new object[0]).ToList();
                        if (sqlst.Count > 0)
                        {
                            Tot4 = ((!string.IsNullOrEmpty(sqlst.FirstOrDefault().ToString())) ? sqlst.FirstOrDefault() : 0.0);
                        }
                    }
                    catch
                    {
                        Tot4 = 0.0;
                    }
                }
                if (data_this.DayOfM.HasValue)
                {
                    VarGeneral.GDayM = data_this.DayOfM.Value;
                }
                else
                {
                    VarGeneral.GDayM = 0;
                }
                try
                {
                    if (VarGeneral.GDayM == 0)
                    {
                        VarGeneral.GDayM = VarGeneral.Settings_Sys.DayOfM.Value;
                    }
                }
                catch
                {
                }
                Tot5 = ((comboBox_RoomTyp.SelectedIndex != 1) ? (textBox_RoomPrice.Value * double.Parse(textBox_DayCount.Text)) : (textBox_RoomPrice.Value * (double)VarGeneral.CS));
                Text_1.Text = Tot5.ToString();
                Tot2 = Tot1 + Tot3 + Tot5;
                Tot6 = Tot5 * data_this.tax.Value / 100.0;
                Tot7 = Tot5 * data_this.ser.Value / 100.0;
                Tot2 = Tot1 + Tot3 + Tot5 + Tot6 + Tot7;
                if (comboBox_DisType.SelectedIndex == 1)
                {
                    if (comboBox_DisTo.SelectedIndex == 0)
                    {
                        Tot8 = Tot5 * Textbox_DiscountVal.Value / 100.0;
                        Tot5 -= Tot8;
                        Tot6 = Tot5 * data_this.tax.Value / 100.0;
                        Tot7 = Tot5 * data_this.ser.Value / 100.0;
                    }
                    else if (comboBox_DisTo.SelectedIndex == 1)
                    {
                        Tot9 = Tot2 * Textbox_DiscountVal.Value / 100.0;
                    }
                }
                else if (comboBox_DisType.SelectedIndex == 2)
                {
                    if (comboBox_DisTo.SelectedIndex == 0)
                    {
                        Tot8 = Textbox_DiscountVal.Value * (double)textBox_DayCount.Value;
                        Tot5 -= Tot8;
                        Tot6 = Tot5 * data_this.tax.Value / 100.0;
                        Tot7 = Tot5 * data_this.ser.Value / 100.0;
                    }
                    else if (comboBox_DisTo.SelectedIndex == 1)
                    {
                        Tot9 = Textbox_DiscountVal.Value;
                    }
                }
                Tot2 = Tot1 + Tot3 + Tot5 + Tot6 + Tot7 - Tot9;
                Tot = Tot2 - Tot4;
                TextBox_TotalAm.Value = Tot2;
                TextBox_Paid.Value = Tot4;
                TextBox_Remming.Value = Tot;
                if (TextBox_Remming.Value < 0.0)
                {
                    TextBox_Remming.ForeColor = Color.Red;
                }
                else
                {
                    TextBox_Remming.ForeColor = Color.Blue;
                }
                VarGeneral.CS = 1;
            }
            catch
            {
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
        private void CDatt()
        {
            CDat2 = textBox_DayRequest.Value;
            CDat = Convert.ToDateTime(textBox_Date.Text).AddDays(CDat2).ToString("yyyy/MM/dd");
        }
        private void SvFamily()
        {
            for (int i = 1; i <= 10; i++)
            {
                DataThisFamily = new T_per1();
                if (i == 1 && !string.IsNullOrEmpty(textBox_Name1.Text))
                {
                    DataThisFamily.perno = int.Parse(textBox_ID.Text);
                    try
                    {
                        DataThisFamily.nm = textBox_Name1.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasno = textBox_PassporntNo1.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasend = Convert.ToDateTime(dateTimeInput_PassportDateEnd1.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd1.Text = "";
                        DataThisFamily.pasend = "";
                    }
                    try
                    {
                        DataThisFamily.passt = Convert.ToDateTime(dateTimeInput_PassportDateStart1.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart1.Text = "";
                        DataThisFamily.passt = "";
                    }
                    try
                    {
                        DataThisFamily.bpls = Convert.ToDateTime(dateTimeInput_BirthDate1.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate1.Text = "";
                        DataThisFamily.bpls = "";
                    }
                    db.T_per1s.InsertOnSubmit(DataThisFamily);
                    db.SubmitChanges();
                }
                if (i == 2 && !string.IsNullOrEmpty(textBox_Name2.Text) && !string.IsNullOrEmpty(textBox_Name1.Text))
                {
                    DataThisFamily.perno = int.Parse(textBox_ID.Text);
                    try
                    {
                        DataThisFamily.nm = textBox_Name2.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasno = textBox_PassporntNo2.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasend = Convert.ToDateTime(dateTimeInput_PassportDateEnd2.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd2.Text = "";
                        DataThisFamily.pasend = "";
                    }
                    try
                    {
                        DataThisFamily.bpls = Convert.ToDateTime(dateTimeInput_BirthDate2.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate2.Text = "";
                        DataThisFamily.bpls = "";
                    }
                    try
                    {
                        DataThisFamily.passt = Convert.ToDateTime(dateTimeInput_PassportDateStart2.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart2.Text = "";
                        DataThisFamily.passt = "";
                    }
                    db.T_per1s.InsertOnSubmit(DataThisFamily);
                    db.SubmitChanges();
                }
                if (i == 3 && !string.IsNullOrEmpty(textBox_Name3.Text) && !string.IsNullOrEmpty(textBox_Name2.Text))
                {
                    DataThisFamily.perno = int.Parse(textBox_ID.Text);
                    try
                    {
                        DataThisFamily.nm = textBox_Name3.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasno = textBox_PassporntNo3.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasend = Convert.ToDateTime(dateTimeInput_PassportDateEnd3.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd3.Text = "";
                        DataThisFamily.pasend = "";
                    }
                    try
                    {
                        DataThisFamily.bpls = Convert.ToDateTime(dateTimeInput_BirthDate3.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate3.Text = "";
                        DataThisFamily.bpls = "";
                    }
                    try
                    {
                        DataThisFamily.passt = Convert.ToDateTime(dateTimeInput_PassportDateStart3.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart3.Text = "";
                        DataThisFamily.passt = "";
                    }
                    db.T_per1s.InsertOnSubmit(DataThisFamily);
                    db.SubmitChanges();
                }
                if (i == 4 && !string.IsNullOrEmpty(textBox_Name4.Text) && !string.IsNullOrEmpty(textBox_Name3.Text))
                {
                    DataThisFamily.perno = int.Parse(textBox_ID.Text);
                    try
                    {
                        DataThisFamily.nm = textBox_Name4.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasno = textBox_PassporntNo4.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasend = Convert.ToDateTime(dateTimeInput_PassportDateEnd4.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd4.Text = "";
                        DataThisFamily.pasend = "";
                    }
                    try
                    {
                        DataThisFamily.bpls = Convert.ToDateTime(dateTimeInput_BirthDate4.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate4.Text = "";
                        DataThisFamily.bpls = "";
                    }
                    try
                    {
                        DataThisFamily.passt = Convert.ToDateTime(dateTimeInput_PassportDateStart4.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart4.Text = "";
                        DataThisFamily.passt = "";
                    }
                    db.T_per1s.InsertOnSubmit(DataThisFamily);
                    db.SubmitChanges();
                }
                if (i == 5 && !string.IsNullOrEmpty(textBox_Name5.Text) && !string.IsNullOrEmpty(textBox_Name4.Text))
                {
                    DataThisFamily.perno = int.Parse(textBox_ID.Text);
                    try
                    {
                        DataThisFamily.nm = textBox_Name5.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasno = textBox_PassporntNo5.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasend = Convert.ToDateTime(dateTimeInput_PassportDateEnd5.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd5.Text = "";
                        DataThisFamily.pasend = "";
                    }
                    try
                    {
                        DataThisFamily.bpls = Convert.ToDateTime(dateTimeInput_BirthDate5.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate5.Text = "";
                        DataThisFamily.bpls = "";
                    }
                    try
                    {
                        DataThisFamily.passt = Convert.ToDateTime(dateTimeInput_PassportDateStart5.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart5.Text = "";
                        DataThisFamily.passt = "";
                    }
                    db.T_per1s.InsertOnSubmit(DataThisFamily);
                    db.SubmitChanges();
                }
                if (i == 6 && !string.IsNullOrEmpty(textBox_Name6.Text) && !string.IsNullOrEmpty(textBox_Name5.Text))
                {
                    DataThisFamily.perno = int.Parse(textBox_ID.Text);
                    try
                    {
                        DataThisFamily.nm = textBox_Name6.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasno = textBox_PassporntNo6.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasend = Convert.ToDateTime(dateTimeInput_PassportDateEnd6.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd6.Text = "";
                        DataThisFamily.pasend = "";
                    }
                    try
                    {
                        DataThisFamily.bpls = Convert.ToDateTime(dateTimeInput_BirthDate6.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate6.Text = "";
                        DataThisFamily.bpls = "";
                    }
                    try
                    {
                        DataThisFamily.passt = Convert.ToDateTime(dateTimeInput_PassportDateStart6.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart6.Text = "";
                        DataThisFamily.passt = "";
                    }
                    db.T_per1s.InsertOnSubmit(DataThisFamily);
                    db.SubmitChanges();
                }
                if (i == 7 && !string.IsNullOrEmpty(textBox_Name7.Text) && !string.IsNullOrEmpty(textBox_Name6.Text))
                {
                    DataThisFamily.perno = int.Parse(textBox_ID.Text);
                    try
                    {
                        DataThisFamily.nm = textBox_Name7.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasno = textBox_PassporntNo7.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasend = Convert.ToDateTime(dateTimeInput_PassportDateEnd6.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd6.Text = "";
                        DataThisFamily.pasend = "";
                    }
                    try
                    {
                        DataThisFamily.bpls = Convert.ToDateTime(dateTimeInput_BirthDate7.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate7.Text = "";
                        DataThisFamily.bpls = "";
                    }
                    try
                    {
                        DataThisFamily.passt = Convert.ToDateTime(dateTimeInput_PassportDateStart7.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart7.Text = "";
                        DataThisFamily.passt = "";
                    }
                    db.T_per1s.InsertOnSubmit(DataThisFamily);
                    db.SubmitChanges();
                }
                if (i == 8 && !string.IsNullOrEmpty(textBox_Name8.Text) && !string.IsNullOrEmpty(textBox_Name7.Text))
                {
                    DataThisFamily.perno = int.Parse(textBox_ID.Text);
                    try
                    {
                        DataThisFamily.nm = textBox_Name8.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasno = textBox_PassporntNo8.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasend = Convert.ToDateTime(dateTimeInput_PassportDateEnd6.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd6.Text = "";
                        DataThisFamily.pasend = "";
                    }
                    try
                    {
                        DataThisFamily.bpls = Convert.ToDateTime(dateTimeInput_BirthDate8.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate8.Text = "";
                        DataThisFamily.bpls = "";
                    }
                    try
                    {
                        DataThisFamily.passt = Convert.ToDateTime(dateTimeInput_PassportDateStart8.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart8.Text = "";
                        DataThisFamily.passt = "";
                    }
                    db.T_per1s.InsertOnSubmit(DataThisFamily);
                    db.SubmitChanges();
                }
                if (i == 9 && !string.IsNullOrEmpty(textBox_Name9.Text) && !string.IsNullOrEmpty(textBox_Name8.Text))
                {
                    DataThisFamily.perno = int.Parse(textBox_ID.Text);
                    try
                    {
                        DataThisFamily.nm = textBox_Name9.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasno = textBox_PassporntNo9.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasend = Convert.ToDateTime(dateTimeInput_PassportDateEnd9.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd9.Text = "";
                        DataThisFamily.pasend = "";
                    }
                    try
                    {
                        DataThisFamily.bpls = Convert.ToDateTime(dateTimeInput_BirthDate9.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate9.Text = "";
                        DataThisFamily.bpls = "";
                    }
                    try
                    {
                        DataThisFamily.passt = Convert.ToDateTime(dateTimeInput_PassportDateStart9.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart9.Text = "";
                        DataThisFamily.passt = "";
                    }
                    db.T_per1s.InsertOnSubmit(DataThisFamily);
                    db.SubmitChanges();
                }
                if (i == 10 && !string.IsNullOrEmpty(textBox_Name10.Text) && !string.IsNullOrEmpty(textBox_Name9.Text))
                {
                    DataThisFamily.perno = int.Parse(textBox_ID.Text);
                    try
                    {
                        DataThisFamily.nm = textBox_Name10.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasno = textBox_PassporntNo10.Text;
                    }
                    catch
                    {
                    }
                    try
                    {
                        DataThisFamily.pasend = Convert.ToDateTime(dateTimeInput_PassportDateEnd10.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd10.Text = "";
                        DataThisFamily.pasend = "";
                    }
                    try
                    {
                        DataThisFamily.bpls = Convert.ToDateTime(dateTimeInput_BirthDate10.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate10.Text = "";
                        DataThisFamily.bpls = "";
                    }
                    try
                    {
                        DataThisFamily.passt = Convert.ToDateTime(dateTimeInput_PassportDateStart10.Text).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateStart10.Text = "";
                        DataThisFamily.passt = "";
                    }
                    db.T_per1s.InsertOnSubmit(DataThisFamily);
                    db.SubmitChanges();
                }
            }
        }
        private void ExtThisFrm(List<T_Reserv> _ReservChk)
        {
            FrmShowReserv frm = new FrmShowReserv();
            frm.Tag = LangArEn;
            frm.VS.Cols[7].Visible = true;
            frm.VS.Rows.Count = _ReservChk.Count + 1;
            for (int i = 1; i <= _ReservChk.Count; i++)
            {
                frm.VS.SetData(i, 0, i);
                frm.VS.SetData(i, 1, _ReservChk[i - 1].ResrvNo);
                frm.VS.SetData(i, 2, _ReservChk[i - 1].Dat);
                frm.VS.SetData(i, 3, _ReservChk[i - 1].PerNm);
                if (_ReservChk[i - 1].Nat.HasValue)
                {
                    frm.VS.SetData(i, 4, (LangArEn == 0) ? db.NationEmp(_ReservChk[i - 1].Nat.Value).NameA : db.NationEmp(_ReservChk[i - 1].Nat.Value).NameE);
                }
                else
                {
                    frm.VS.SetData(i, 4, (LangArEn == 0) ? "لا يوجد" : "non");
                }
                frm.VS.SetData(i, 5, _ReservChk[i - 1].IdNo);
                frm.VS.SetData(i, 6, _ReservChk[i - 1].Rom);
                frm.VS.SetData(i, 7, "ساري الحجز");
                frm.VS.SetData(i, 8, _ReservChk[i - 1].Sts);
                frm.VS.SetData(i, 9, _ReservChk[i - 1].Dat2);
            }
            Hide();
            frm.TopMost = true;
            frm.ShowDialog();
            Close();
        }
        private T_per GetData()
        {
            bb = 0;
            textBox_NameA.Focus();
            CDatt();
            List<T_Reserv> _ReservChk = db.ExecuteQuery<T_Reserv>("SELECT T_Reserv.ResrvNo, T_Reserv.Dat, T_Reserv.Rom, T_Reserv.Sts, T_Reserv.PerNm, T_Reserv.IdNo, T_Reserv.Nat , T_Reserv.Dat2 FROM T_Reserv where T_Reserv.Rom = " + R2 + " and T_Reserv.sts=0 and ((T_Reserv.Dat < '" + textBox_Date.Text + "' and T_Reserv.Dat >= '" + CDat + "') or (T_Reserv.Dat2 > '" + textBox_Date.Text + "' and T_Reserv.Dat2 < '" + CDat + "') or (  '" + CDat + "' <= T_Reserv.Dat2 and '" + textBox_Date.Text + "' >= T_Reserv.Dat)) or ((T_Reserv.Dat < '" + CDat + "' and T_Reserv.Dat > '" + textBox_Date.Text + "' ) and T_Reserv.Rom = " + R2 + " )", new object[0]).ToList();
            if (_ReservChk.Count > 0 && !(_ReservChk[0].ResrvNo.ToString() == VarGeneral.Tmp6))
            {
                MessageBox.Show(" لايمكن اتمام العملية  لان الغرفة محجوزة في هذه الفترة ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ExtThisFrm(_ReservChk);
                bb = 1;
                return data_this;
            }
            if (R1 == 4 && M != 2)
            {
                T_Reserv rsTmp = db.StockReserv(int.Parse(VarGeneral.Tmp6));
                if (rsTmp != null)
                {
                    db.ExecuteCommand(" UPDATE [T_Reserv] Set [Sts] = 1 where ResrvNo = " + VarGeneral.Tmp6);
                    R1 = 2;
                }
            }
            if ((R1 == 1 || R1 == 2 || R1 == 4) && M != 2)
            {
                data_this.ps1 = VarGeneral.UserNo;
                data_this.perno = int.Parse(textBox_ID.Text);
                data_this.romno = int.Parse(comboBox_Rooms.SelectedValue.ToString());
                data_this.tm1 = textBox_Time.Text;
                if (RadioBox_AllowAM.Checked)
                {
                    data_this.vAmPm = "AM";
                }
                else
                {
                    data_this.vAmPm = "PM";
                }
                data_this.day = textBox_DayCount.Text;
                data_this.nm = textBox_NameA.Text;
                if (VarGeneral.CheckDate(dateTimeInput_BirthDate.Text))
                {
                    data_this.bdt = dateTimeInput_BirthDate.Text;
                }
                else
                {
                    data_this.bdt = "";
                }
                if (comboBox_BirthPlace.SelectedIndex > 0)
                {
                    data_this.bpls = comboBox_BirthPlace.SelectedValue.ToString();
                }
                else
                {
                    data_this.bpls = null;
                }
                data_this.pasno = textBox_ID_No.Text;
                if (comboBox_ID_From.SelectedIndex > 0)
                {
                    data_this.paspls = comboBox_ID_From.SelectedValue.ToString();
                }
                else
                {
                    data_this.paspls = null;
                }
                if (VarGeneral.CheckDate(dateTimeInput_ID_Date.Text))
                {
                    data_this.passt = dateTimeInput_ID_Date.Text;
                }
                else
                {
                    data_this.passt = "";
                }
                if (VarGeneral.CheckDate(dateTimeInput_ID_DateEnd.Text))
                {
                    data_this.pasend = dateTimeInput_ID_DateEnd.Text;
                }
                else
                {
                    data_this.pasend = "";
                }
                data_this.enddt = textBox_Mobile.Text;
                data_this.jobpls = textBox_Note.Text;
                if (comboBox_Religion.SelectedIndex > 0)
                {
                    data_this.vip = int.Parse(comboBox_Religion.SelectedValue.ToString());
                }
                else
                {
                    data_this.vip = null;
                }
                data_this.ser = Text_11.Value;
                data_this.tax = Text_12.Value;
                data_this.price = textBox_RoomPrice.Value;
                data_this.DayImport = textBox_DayRequest.Value;
                data_this.dt4 = CDat;
                data_this.KindPer = comboBox_RoomTyp.SelectedIndex;
                if (!data_this.DayOfM.HasValue && comboBox_RoomTyp.SelectedIndex == 1)
                {
                    data_this.DayOfM = VarGeneral.GDayM;
                }
                if (comboBox_DisType.SelectedIndex > 0)
                {
                    data_this.dis = Textbox_DiscountVal.Value;
                }
                else
                {
                    data_this.dis = 0.0;
                }
                if (R1 == 1)
                {
                    data_this.dt1 = textBox_Date.Text;
                }
                else if (R1 == 2 || R1 == 4)
                {
                    data_this.dt2 = textBox_Date.Text;
                }
                data_this.ch = R1;
                if (!string.IsNullOrEmpty(txtCustNo.Text))
                {
                    data_this.Cust_no = txtCustNo.Text;
                }
                else
                {
                    data_this.Cust_no = null;
                }
                if (comboBox_Nationality.SelectedIndex > 0)
                {
                    data_this.nath = int.Parse(comboBox_Nationality.SelectedValue.ToString());
                }
                else
                {
                    data_this.nath = null;
                }
                if (CmbIDTyp.SelectedIndex >= 0)
                {
                    data_this.pastyp = int.Parse(CmbIDTyp.SelectedValue.ToString());
                }
                else
                {
                    data_this.pastyp = null;
                }
                if (comboBox_Job.SelectedIndex > 0)
                {
                    data_this.job = int.Parse(comboBox_Job.SelectedValue.ToString());
                }
                else
                {
                    data_this.job = null;
                }
                try
                {
                    data_this.curr = int.Parse(comboBox_Curr.SelectedValue.ToString());
                }
                catch
                {
                    data_this.curr = null;
                }
                data_this.disknd = comboBox_DisType.SelectedIndex;
                data_this.distyp = comboBox_DisTo.SelectedIndex;
                try
                {
                    if (checkBox_Credit.Checked)
                    {
                        data_this.cc = 1;
                    }
                    else
                    {
                        data_this.cc = 0;
                    }
                }
                catch
                {
                    data_this.cc = 0;
                }
                data_this.fat = 0.0;
                SvFamily();
            }
            else if (M == 2)
            {
                db.ExecuteCommand("DELETE FROM [T_per1] WHERE perno=" + textBox_ID.Text);
                SvFamily();
                data_this.fat = 0.0;
                data_this.day = textBox_DayCount.Text;
                data_this.nm = textBox_NameA.Text;
                if (VarGeneral.CheckDate(dateTimeInput_BirthDate.Text))
                {
                    data_this.bdt = dateTimeInput_BirthDate.Text;
                }
                else
                {
                    data_this.bdt = "";
                }
                if (comboBox_BirthPlace.SelectedIndex > 0)
                {
                    data_this.bpls = comboBox_BirthPlace.SelectedValue.ToString();
                }
                else
                {
                    data_this.bpls = "0";
                }
                data_this.pasno = textBox_ID_No.Text;
                if (comboBox_ID_From.SelectedIndex > 0)
                {
                    data_this.paspls = comboBox_ID_From.SelectedValue.ToString();
                }
                else
                {
                    data_this.paspls = "0";
                }
                data_this.passt = dateTimeInput_ID_Date.Text;
                data_this.pasend = dateTimeInput_ID_DateEnd.Text;
                data_this.enddt = textBox_Mobile.Text;
                data_this.jobpls = textBox_Note.Text;
                if (comboBox_Religion.SelectedIndex > 0)
                {
                    data_this.vip = int.Parse(comboBox_Religion.SelectedValue.ToString());
                }
                else
                {
                    data_this.vip = null;
                }
                data_this.ser = Text_11.Value;
                data_this.tax = Text_12.Value;
                data_this.price = textBox_RoomPrice.Value;
                data_this.DayImport = textBox_DayRequest.Value;
                data_this.dt4 = CDat;
                data_this.KindPer = comboBox_RoomTyp.SelectedIndex;
                if (!data_this.DayOfM.HasValue && comboBox_RoomTyp.SelectedIndex == 1)
                {
                    data_this.DayOfM = VarGeneral.GDayM;
                }
                if (comboBox_RoomTyp.SelectedIndex == 0)
                {
                    data_this.DayOfM = null;
                }
                if (comboBox_DisType.SelectedIndex > 0)
                {
                    data_this.dis = Textbox_DiscountVal.Value;
                }
                else
                {
                    data_this.dis = 0.0;
                }
                aa = textBox_Date.Text;
                if (db.StockRoom(data_this.romno.Value).state == 2)
                {
                    data_this.dt1 = textBox_Date.Text;
                }
                else if (db.StockRoom(data_this.romno.Value).state == 3)
                {
                    data_this.dt2 = textBox_Date.Text;
                }
                data_this.ch = R1;
                if (!string.IsNullOrEmpty(txtCustNo.Text))
                {
                    data_this.Cust_no = txtCustNo.Text;
                }
                else
                {
                    data_this.Cust_no = null;
                }
                if (comboBox_Nationality.SelectedIndex > 0)
                {
                    data_this.nath = int.Parse(comboBox_Nationality.SelectedValue.ToString());
                }
                else
                {
                    data_this.nath = null;
                }
                if (CmbIDTyp.SelectedIndex >= 0)
                {
                    data_this.pastyp = int.Parse(CmbIDTyp.SelectedValue.ToString());
                }
                else
                {
                    data_this.pastyp = null;
                }
                if (comboBox_Job.SelectedIndex > 0)
                {
                    data_this.job = int.Parse(comboBox_Job.SelectedValue.ToString());
                }
                else
                {
                    data_this.job = null;
                }
                if (comboBox_Curr.SelectedIndex > 0)
                {
                    data_this.curr = int.Parse(comboBox_Curr.SelectedValue.ToString());
                }
                else
                {
                    data_this.curr = null;
                }
                data_this.disknd = comboBox_DisType.SelectedIndex;
                data_this.distyp = comboBox_DisTo.SelectedIndex;
                try
                {
                    if (checkBox_Credit.Checked)
                    {
                        data_this.cc = 1;
                    }
                    else
                    {
                        data_this.cc = 0;
                    }
                }
                catch
                {
                    data_this.cc = 0;
                }
                data_this.tm1 = textBox_Time.Text;
                if (RadioBox_AllowAM.Checked)
                {
                    data_this.vAmPm = "AM";
                }
                else
                {
                    data_this.vAmPm = "PM";
                }
            }
            return data_this;
        }
        private void Sv()
        {
            if (R1 == 1)
            {
                db.ExecuteCommand("UPDATE [dbo].[T_Rom] SET [state] = 2,[perno] = " + textBox_ID.Text + ",[price] = " + textBox_RoomPrice.Value + ",[hed] = 1,[tax] = " + Text_12.Value + ",[ser] = " + Text_11.Value + ",[dt] = '" + textBox_Date.Text + "',[tm] = '" + textBox_Time.Text + (RadioBox_AllowAM.Checked ? " AM" : " PM") + "'  WHERE [romno] =" + comboBox_Rooms.SelectedValue.ToString());
            }
            else if ((R1 == 2 || R1 == 4) && M == 0)
            {
                db.ExecuteCommand("UPDATE [dbo].[T_Rom] SET [state] = 3,[perno] = " + textBox_ID.Text + ",[price] = " + textBox_RoomPrice.Value + ",[hed] = 1,[tax] = " + Text_12.Value + ",[ser] = " + Text_11.Value + ",[dt] = '" + textBox_Date.Text + "',[tm] = '" + textBox_Time.Text + (RadioBox_AllowAM.Checked ? " AM" : " PM") + "'  WHERE [romno] =" + comboBox_Rooms.SelectedValue.ToString());
            }
            else if ((R1 == 2 || R1 == 4) && M == 2)
            {
                db.ExecuteCommand("UPDATE [dbo].[T_Rom] SET [state] = 3,[perno] = " + textBox_ID.Text + ",[price] = " + textBox_RoomPrice.Value + ",[tax] = " + Text_12.Value + ",[ser] = " + Text_11.Value + ",[dt] = '" + textBox_Date.Text + "',[tm] = '" + textBox_Time.Text + (RadioBox_AllowAM.Checked ? " AM" : " PM") + "'  WHERE [romno] =" + comboBox_Rooms.SelectedValue.ToString());
            }
            else if (R1 == 0 && M == 2)
            {
                db.ExecuteCommand("UPDATE [dbo].[T_Rom] SET [dt] = '" + textBox_Date.Text + "'  WHERE [romno] =" + comboBox_Rooms.SelectedValue.ToString());
            }
        }
        private void Button_Edit_Click(object sender, EventArgs e)
        {
            if (CanEdit && State != FormState.Edit && State != FormState.New && !string.IsNullOrEmpty(textBox_ID.Text))
            {
                if (State != FormState.New)
                {
                    State = FormState.Edit;
                }
                M = 2;
                if (textBox_RoomStat.Text == "مشغولة" || textBox_RoomStat.Text == "Busy")
                {
                    R1 = 2;
                }
                else if (textBox_RoomStat.Text == "محجوزة" || textBox_RoomStat.Text == "Reserved")
                {
                    R1 = 1;
                }
                SetReadOnly = false;
            }
        }
        private void Button_Add_Click(object sender, EventArgs e)
        {
            if (!Button_Add.Visible)
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
                MaskedTextBox maskedTextBox = textBox_Date;
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                maskedTextBox.Text = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
                textBox_Time.Text = DateTime.Now.ToString("hh:mm:ss");
                if (DateTime.Now.ToString("hh:mm:ss tt").ToString().ToUpper()
                    .Contains("AM"))
                {
                    RadioBox_AllowAM.Checked = true;
                }
                else
                {
                    RadioBox_AllowPM.Checked = true;
                }
                GetInvSetting();
                textBox_ID.Text = db.MaxPerNo.ToString();
                if (VarGeneral._hotelper == 0)
                {
                    comboBox_Rooms.SelectedValue = R2;
                    comboBox_RoomTyp.SelectedIndex = 0;
                    if (!string.IsNullOrEmpty(VarGeneral.Settings_Sys.GuestAcc))
                    {
                        int Value = 0;
                        List<T_AccDef> q = (from t in db.T_AccDefs
                                            where t.ParAcc == VarGeneral.Settings_Sys.GuestAcc
                                            orderby t.AccDef_ID
                                            select t).ToList();
                        if (q.Count == 0)
                        {
                            txtCustNo.Text = VarGeneral.Settings_Sys.GuestAcc + "001";
                        }
                        else
                        {
                            _AccDefBind = q[q.Count - 1];
                            string _Zero = "";
                            for (int iiCnt = 0; iiCnt < _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Length && _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Substring(iiCnt, 1) == "0"; iiCnt++)
                            {
                                _Zero += _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Substring(iiCnt, 1);
                            }
                            Value = int.Parse(_AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length)) + 1;
                            if (!string.IsNullOrEmpty(_Zero))
                            {
                                txtCustNo.Text = _AccDefBind.ParAcc + _Zero + Value;
                            }
                            else
                            {
                                txtCustNo.Text = _AccDefBind.ParAcc + Value;
                            }
                        }
                    }
                    if (R1 == 4)
                    {
                        textBox_RoomPrice.Value = ((permission.RepAcc5 == "0") ? db.StockRoom(VarGeneral._hotelrom).pri0.Value : db.StockRoom(VarGeneral._hotelrom).pri1.Value);
                        textBox_NameA.Text = VarGeneral.Tmp2;
                        textBox_NameE.Text = VarGeneral.Tmp2;
                        textBox_ID_No.Text = VarGeneral.Tmp3;
                        textBox_DayRequest.Text = VarGeneral.Tmp7;
                        label11.Text = ((LangArEn == 0) ? "تاريخ الحجز :" : "booking date");
                        Mm = 1;
                    }
                }
                State = FormState.New;
                textBox_NameA.Focus();
            }
        }
        private void GetInvSetting()
        {
            _InvSetting = new T_INVSETTING();
            _SysSetting = new T_SYSSETTING();
            _InvSetting = db.StockInvSetting(VarGeneral.UserID, VarGeneral.InvTyp);
            _SysSetting = db.SystemSettingStock();
            _Company = db.StockCompanyList().FirstOrDefault();
        }
        private bool ValidData()
        {
            if (!Button_Save.Visible)
            {
                return false;
            }
            if (State == FormState.Edit && !CanEdit)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (State == FormState.New && !Button_Add.Visible)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (textBox_ID.Text == "0" || textBox_ID.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ بدون رقم النزيل" : "Can not save without Ghoust No", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_ID.Focus();
                return false;
            }
            if (textBox_NameA.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الإسم فارغا\u0651" : "Can not be name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_NameA.Focus();
                return false;
            }
            if (textBox_NameE.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الإسم فارغا\u0651" : "Can not be name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_NameE.Focus();
                return false;
            }
            if (textBox_ID_No.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون رقم الهوية فارغا\u0651" : "Can not be ID No is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_ID_No.Focus();
                return false;
            }
            List<T_BlackList> q = db.T_BlackLists.Where((T_BlackList t) => t.IdNo == textBox_ID_No.Text).ToList();
            if (q.Count > 0)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ .. هذا النزيل ضمن قائمة النزلاء المحظورين" : "Can not save .. This download is blacklisted", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_ID_No.Focus();
                return false;
            }
            if (comboBox_Rooms.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون رقم الغرفة فارغا\u0651" : "Can not be Room No is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                comboBox_Rooms.Focus();
                return false;
            }
            if (!VarGeneral.CheckTime(textBox_Time.Text))
            {
                MessageBox.Show((LangArEn == 0) ? "تأكد من صحة الوقت" : "Make sure the time is correct", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_Time.Focus();
                return false;
            }
            if (txtCustNo.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ بدون رقم حساب النزيل" : "Can not save without the customer's account number.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtCustNo.Focus();
                return false;
            }
            if (!VarGeneral.CheckDate(textBox_Date.Text))
            {
                MaskedTextBox maskedTextBox = textBox_Date;
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                maskedTextBox.Text = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
            }
            return true;
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
                            string dtAction = (n.IsHijri(textBox_Date.Text) ? textBox_Date.Text : n.GregToHijri(textBox_Date.Text, "yyyy/MM/dd"));
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
                if (!ValidData())
                {
                    return;
                }
                textBox_NameA.Focus();
                if (State == FormState.New)
                {
                    GetData();
                    if (bb != 1)
                    {
                        if (!string.IsNullOrEmpty(txtCustNo.Text))
                        {
                            T_AccDef c = db.StockAccDefWithOutBalance(txtCustNo.Text);
                            if (c == null || c.AccDef_ID == 0)
                            {
                                if (!string.IsNullOrEmpty(VarGeneral.Settings_Sys.GuestAcc))
                                {
                                    int Value = 0;
                                    List<T_AccDef> q = (from t in db.T_AccDefs
                                                        where t.ParAcc == VarGeneral.Settings_Sys.GuestAcc
                                                        orderby t.AccDef_ID
                                                        select t).ToList();
                                    if (q.Count == 0)
                                    {
                                        txtCustNo.Text = VarGeneral.Settings_Sys.GuestAcc + "001";
                                    }
                                    else
                                    {
                                        _AccDefBind = q[q.Count - 1];
                                        string _Zero = "";
                                        for (int iiCnt = 0; iiCnt < _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Length && _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Substring(iiCnt, 1) == "0"; iiCnt++)
                                        {
                                            _Zero += _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Substring(iiCnt, 1);
                                        }
                                        Value = int.Parse(_AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length)) + 1;
                                        if (!string.IsNullOrEmpty(_Zero))
                                        {
                                            txtCustNo.Text = _AccDefBind.ParAcc + _Zero + Value;
                                        }
                                        else
                                        {
                                            txtCustNo.Text = _AccDefBind.ParAcc + Value;
                                        }
                                    }
                                }
                                if (string.IsNullOrEmpty(txtCustNo.Text))
                                {
                                    MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ بدون رقم حساب النزيل" : "Can not save without the customer's account number.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    txtCustNo.Focus();
                                    return;
                                }
                                data_this.Cust_no = txtCustNo.Text;
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [DepreciationPercent], [ProofAcc], [RelayAcc],[MaxDisCust],[vColNum1],[vColNum2],[vColStr1],[vColStr2],[vColStr3]) VALUES (N'" + txtCustNo.Text + "', N'" + textBox_NameA.Text + "', N'" + textBox_NameE.Text + "', N'" + VarGeneral.Settings_Sys.GuestAcc + "', 4, NULL, 11, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, '" + textBox_Mobile.Text + "', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL,0,0,0,'','','')");
                            }
                            else
                            {
                                data_this.Cust_no = txtCustNo.Text;
                            }
                        }
                        try
                        {
                            db.T_pers.InsertOnSubmit(data_this);
                            db.SubmitChanges();
                        }
                        catch (SqlException ex4)
                        {
                            int max = 0;
                            max = db.MaxPerNo;
                            if (ex4.Number != 2627)
                            {
                                return;
                            }
                            MessageBox.Show("رقم الوحدة مستخدم من قبل.\n سيتم الحفظ برقم جديد [" + max + "]", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question);
                            textBox_ID.Text = string.Concat(max);
                            data_this.perno = max;
                            Button_Save_Click(sender, e);
                        }
                        catch (Exception)
                        {
                            return;
                        }
                        if ((R1 == 1 || R1 == 2 || R1 == 4) && M != 2)
                        {
                            Sv();
                            T_romtrn dataThis_RomTrn = new T_romtrn();
                            dataThis_RomTrn.ID = db.MaxRomTrnNo;
                            dataThis_RomTrn.romno1 = data_this.romno.Value;
                            dataThis_RomTrn.romno2 = null;
                            dataThis_RomTrn.perno = data_this.perno;
                            int? calendr = VarGeneral.Settings_Sys.Calendr;
                            dataThis_RomTrn.dt = ((calendr.Value == 0 && calendr.HasValue) ? VarGeneral.Gdate : VarGeneral.Hdate);
                            dataThis_RomTrn.tm = DateTime.Now.ToString("hh:mm:ss tt");
                            dataThis_RomTrn.Usr = VarGeneral.UserNumber;
                            dataThis_RomTrn.typ = R1;
                            dataThis_RomTrn.UsrNam = ((LangArEn == 0) ? VarGeneral.UserNameA : VarGeneral.UserNameE);
                            db.T_romtrns.InsertOnSubmit(dataThis_RomTrn);
                            db.SubmitChanges();
                        }
                        goto IL_0750;
                    }
                }
                else
                {
                    if (State != FormState.Edit)
                    {
                        goto IL_0750;
                    }
                    GetData();
                    if (bb != 1)
                    {
                        try
                        {
                            db.ExecuteCommand("update [dbo].[T_AccDef] Set [Mobile] = '" + textBox_Mobile.Text + "' , [Arb_Des] = '" + textBox_NameA.Text + "' , [Eng_Des] = '" + textBox_NameE.Text + "' where AccDef_No = '" + txtCustNo.Text + "'");
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
                        if (M == 2)
                        {
                            Sv();
                        }
                        goto IL_0750;
                    }
                }
                goto end_IL_0001;
            IL_0750:
                if (VarGeneral.vGuestData == 1)
                {
                    if (State == FormState.New && !string.IsNullOrEmpty(textBox_Mobile.Text) && MessageBox.Show((LangArEn == 0) ? "هل تريد ارسال رسالة نصية .. للعميل ؟" : "Do you want to send a text message to the customer?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        buttonItem_SendSms_Click(sender, e);
                    }
                    Close();
                }
                else
                {
                    State = FormState.Saved;
                    RefreshPKeys();
                    TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(string.Concat(data_this.perno)) + 1);
                    SetReadOnly = true;
                }
            end_IL_0001:;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Save:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            Button_Close_Click(sender, e);
        }
        private void DGV_Main_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            string dataMember = panel.DataMember;
            if (dataMember != null && dataMember == "T_per")
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
            panel.Columns["perno"].Width = 200;
            panel.Columns["perno"].Visible = columns_Names_visible["perno"].IfDefault;
            panel.Columns["nmA"].Width = 250;
            panel.Columns["nmA"].Visible = columns_Names_visible["nmA"].IfDefault;
            panel.Columns["nmE"].Width = 250;
            panel.Columns["nmE"].Visible = columns_Names_visible["nmE"].IfDefault;
            panel.Columns["price"].Width = 200;
            panel.Columns["price"].Visible = columns_Names_visible["price"].IfDefault;
            panel.Columns["day"].Width = 200;
            panel.Columns["day"].Visible = columns_Names_visible["day"].IfDefault;
            panel.ReadOnly = true;
        }
        private void DGV_MainGetCellStyle(object sender, GridGetCellStyleEventArgs e)
        {
        }
        private void Button_ExportTable2_Click(object sender, EventArgs e)
        {
            try
            {
                ExportExcel.ExportToExcel(DGV_Main, "تقرير بيانات النزلاء");
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
                _RepShow.Tables = " T_per left join T_SYSSETTING on T_SYSSETTING.SYSSETTING_ID = T_per.CompanyID ";
                string Fields = "";
                Fields = " T_per.perno as No, T_per.nm as NmA, T_per.Eng_Des as NmE,T_SYSSETTING.LogImg ";
                _RepShow.Rule = "";
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
                    frm.Repvalue = "RepGuestDataPer_1";



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
        private void textBox_Date_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(textBox_Date.Text))
                {
                    textBox_Date.Text = Convert.ToDateTime(textBox_Date.Text).ToString("yyyy/MM/dd");
                    return;
                }
                MaskedTextBox maskedTextBox = textBox_Date;
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                maskedTextBox.Text = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
            }
            catch
            {
                MaskedTextBox maskedTextBox2 = textBox_Date;
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                maskedTextBox2.Text = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
            }
        }
        private void textBox_Date_Click(object sender, EventArgs e)
        {
            textBox_Date.SelectAll();
        }
        private void textBox_Time_Click(object sender, EventArgs e)
        {
            textBox_Time.SelectAll();
        }
        private void textBox_Time_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckTime(textBox_Time.Text))
                {
                    textBox_Time.Text = TimeSpan.Parse(textBox_Time.Text).ToString();
                }
                else
                {
                    textBox_Time.Text = DateTime.Now.ToString("hh:mm:ss");
                }
            }
            catch
            {
                textBox_Time.Text = DateTime.Now.ToString("hh:mm:ss");
            }
            try
            {
                if (int.Parse(textBox_Time.Text.Substring(0, 2)) > 12 || textBox_Time.Text.Substring(0, 2) == "00")
                {
                    if (textBox_Time.Text.Substring(0, 2) == "13")
                    {
                        textBox_Time.Text = "01" + textBox_Time.Text.Remove(0, 2);
                    }
                    else if (textBox_Time.Text.Substring(0, 2) == "14")
                    {
                        textBox_Time.Text = "02" + textBox_Time.Text.Remove(0, 2);
                    }
                    else if (textBox_Time.Text.Substring(0, 2) == "15")
                    {
                        textBox_Time.Text = "03" + textBox_Time.Text.Remove(0, 2);
                    }
                    else if (textBox_Time.Text.Substring(0, 2) == "16")
                    {
                        textBox_Time.Text = "04" + textBox_Time.Text.Remove(0, 2);
                    }
                    else if (textBox_Time.Text.Substring(0, 2) == "17")
                    {
                        textBox_Time.Text = "05" + textBox_Time.Text.Remove(0, 2);
                    }
                    else if (textBox_Time.Text.Substring(0, 2) == "18")
                    {
                        textBox_Time.Text = "06" + textBox_Time.Text.Remove(0, 2);
                    }
                    else if (textBox_Time.Text.Substring(0, 2) == "19")
                    {
                        textBox_Time.Text = "07" + textBox_Time.Text.Remove(0, 2);
                    }
                    else if (textBox_Time.Text.Substring(0, 2) == "20")
                    {
                        textBox_Time.Text = "08" + textBox_Time.Text.Remove(0, 2);
                    }
                    else if (textBox_Time.Text.Substring(0, 2) == "21")
                    {
                        textBox_Time.Text = "09" + textBox_Time.Text.Remove(0, 2);
                    }
                    else if (textBox_Time.Text.Substring(0, 2) == "22")
                    {
                        textBox_Time.Text = "10" + textBox_Time.Text.Remove(0, 2);
                    }
                    else if (textBox_Time.Text.Substring(0, 2) == "23")
                    {
                        textBox_Time.Text = "11" + textBox_Time.Text.Remove(0, 2);
                    }
                    else if (textBox_Time.Text.Substring(0, 2) == "00")
                    {
                        textBox_Time.Text = "12" + textBox_Time.Text.Remove(0, 2);
                    }
                }
            }
            catch
            {
            }
        }
        private void comboBox_DisType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_DisType.SelectedIndex <= 0)
            {
                Textbox_DiscountVal.Enabled = false;
                Textbox_DiscountVal.Value = 0.0;
            }
            else
            {
                Textbox_DiscountVal.Enabled = true;
            }
        }
        private void dateTimeInput_BirthDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate.Text = Convert.ToDateTime(dateTimeInput_BirthDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate.Text = "";
            }
        }
        private void dateTimeInput_BirthDate_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate.SelectAll();
        }
        private void dateTimeInput_ID_Date_Click(object sender, EventArgs e)
        {
            dateTimeInput_ID_Date.SelectAll();
        }
        private void dateTimeInput_ID_Date_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_ID_Date.Text = Convert.ToDateTime(dateTimeInput_ID_Date.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_ID_Date.Text = "";
            }
        }
        private void dateTimeInput_ID_DateEnd_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_ID_DateEnd.Text = Convert.ToDateTime(dateTimeInput_ID_DateEnd.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_ID_DateEnd.Text = "";
            }
        }
        private void dateTimeInput_ID_DateEnd_Click(object sender, EventArgs e)
        {
            dateTimeInput_ID_DateEnd.SelectAll();
        }
        private void comboBox_Rooms_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (State == FormState.Saved)
                {
                    return;
                }
                T_Rom Q = db.StockRoom(int.Parse(comboBox_Rooms.SelectedValue.ToString()));
                if (Q != null && Q.romno != 0)
                {
                    if (Q.state.Value == 0)
                    {
                        textBox_RoomStat.Text = ((LangArEn == 0) ? "صيانة" : "Repair");
                    }
                    if (Q.state.Value == 1)
                    {
                        textBox_RoomStat.Text = ((LangArEn == 0) ? "فارغة" : "Empty");
                    }
                    if (Q.state.Value == 2)
                    {
                        textBox_RoomStat.Text = ((LangArEn == 0) ? "نظافة" : "Cleaning");
                    }
                    if (Q.state.Value == 3)
                    {
                        textBox_RoomStat.Text = ((LangArEn == 0) ? "مشغولة" : "Busy");
                    }
                }
            }
            catch
            {
            }
        }
        private void comboBox_RoomTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_RoomTyp.SelectedIndex == 0)
            {
                buttonItem_EditDays.Visible = false;
            }
            else
            {
                buttonItem_EditDays.Visible = true;
            }
        }
        private void button_ClearPic_Click(object sender, EventArgs e)
        {
            try
            {
                if (State != FormState.New)
                {
                    Button_Edit_Click(null, null);
                }
                PicItemImg.Image = null;
            }
            catch
            {
            }
        }
        private void button_EnterImg_Click(object sender, EventArgs e)
        {
            try
            {
                if (State != FormState.New)
                {
                    Button_Edit_Click(null, null);
                }
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
                    PicItemImg.Image = Image.FromFile(mypic_path);
                    Bitmap OriginalBM = new Bitmap(newSize: new Size(88, 100), original: PicItemImg.Image);
                    PicItemImg.Image = OriginalBM;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dateTimeInput_BirthDate1_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate1.SelectAll();
        }
        private void dateTimeInput_BirthDate2_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate2.SelectAll();
        }
        private void dateTimeInput_BirthDate3_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate3.SelectAll();
        }
        private void dateTimeInput_BirthDate4_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate4.SelectAll();
        }
        private void dateTimeInput_BirthDate5_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate5.SelectAll();
        }
        private void dateTimeInput_BirthDate6_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate6.SelectAll();
        }
        private void dateTimeInput_BirthDate7_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate7.SelectAll();
        }
        private void dateTimeInput_BirthDate8_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate8.SelectAll();
        }
        private void dateTimeInput_BirthDate9_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate9.SelectAll();
        }
        private void dateTimeInput_BirthDate10_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate10.SelectAll();
        }
        private void dateTimeInput_BirthDate1_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate1.Text = Convert.ToDateTime(dateTimeInput_BirthDate1.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate1.Text = "";
            }
        }
        private void dateTimeInput_BirthDate2_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate2.Text = Convert.ToDateTime(dateTimeInput_BirthDate2.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate2.Text = "";
            }
        }
        private void dateTimeInput_BirthDate3_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate3.Text = Convert.ToDateTime(dateTimeInput_BirthDate3.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate3.Text = "";
            }
        }
        private void dateTimeInput_BirthDate4_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate4.Text = Convert.ToDateTime(dateTimeInput_BirthDate4.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate4.Text = "";
            }
        }
        private void dateTimeInput_BirthDate5_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate5.Text = Convert.ToDateTime(dateTimeInput_BirthDate5.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate5.Text = "";
            }
        }
        private void dateTimeInput_BirthDate6_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate6.Text = Convert.ToDateTime(dateTimeInput_BirthDate6.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate6.Text = "";
            }
        }
        private void dateTimeInput_BirthDate7_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate7.Text = Convert.ToDateTime(dateTimeInput_BirthDate7.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate7.Text = "";
            }
        }
        private void dateTimeInput_BirthDate8_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate8.Text = Convert.ToDateTime(dateTimeInput_BirthDate8.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate8.Text = "";
            }
        }
        private void dateTimeInput_BirthDate9_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate9.Text = Convert.ToDateTime(dateTimeInput_BirthDate9.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate9.Text = "";
            }
        }
        private void dateTimeInput_BirthDate10_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate10.Text = Convert.ToDateTime(dateTimeInput_BirthDate10.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate10.Text = "";
            }
        }
        private void dateTimeInput_PassportDateStart1_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateStart1.Text = Convert.ToDateTime(dateTimeInput_PassportDateStart1.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateStart1.Text = "";
            }
        }
        private void dateTimeInput_PassportDateStart2_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateStart2.Text = Convert.ToDateTime(dateTimeInput_PassportDateStart2.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateStart2.Text = "";
            }
        }
        private void dateTimeInput_PassportDateStart3_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateStart3.Text = Convert.ToDateTime(dateTimeInput_PassportDateStart3.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateStart3.Text = "";
            }
        }
        private void dateTimeInput_PassportDateStart4_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateStart4.Text = Convert.ToDateTime(dateTimeInput_PassportDateStart4.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateStart4.Text = "";
            }
        }
        private void dateTimeInput_PassportDateStart5_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateStart5.Text = Convert.ToDateTime(dateTimeInput_PassportDateStart5.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateStart5.Text = "";
            }
        }
        private void dateTimeInput_PassportDateStart6_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateStart6.Text = Convert.ToDateTime(dateTimeInput_PassportDateStart6.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateStart6.Text = "";
            }
        }
        private void dateTimeInput_PassportDateStart7_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateStart7.Text = Convert.ToDateTime(dateTimeInput_PassportDateStart7.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateStart7.Text = "";
            }
        }
        private void dateTimeInput_PassportDateStart8_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateStart8.Text = Convert.ToDateTime(dateTimeInput_PassportDateStart8.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateStart8.Text = "";
            }
        }
        private void dateTimeInput_PassportDateStart9_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateStart9.Text = Convert.ToDateTime(dateTimeInput_PassportDateStart9.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateStart9.Text = "";
            }
        }
        private void dateTimeInput_PassportDateStart10_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateStart10.Text = Convert.ToDateTime(dateTimeInput_PassportDateStart10.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateStart10.Text = "";
            }
        }
        private void dateTimeInput_PassportDateStart1_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateStart1.SelectAll();
        }
        private void dateTimeInput_PassportDateStart2_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateStart2.SelectAll();
        }
        private void dateTimeInput_PassportDateStart3_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateStart3.SelectAll();
        }
        private void dateTimeInput_PassportDateStart4_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateStart4.SelectAll();
        }
        private void dateTimeInput_PassportDateStart5_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateStart5.SelectAll();
        }
        private void dateTimeInput_PassportDateStart6_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateStart6.SelectAll();
        }
        private void dateTimeInput_PassportDateStart7_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateStart7.SelectAll();
        }
        private void dateTimeInput_PassportDateStart8_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateStart8.SelectAll();
        }
        private void dateTimeInput_PassportDateStart9_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateStart9.SelectAll();
        }
        private void dateTimeInput_PassportDateStart10_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateStart10.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd1_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd1.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd1.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd1.Text = "";
            }
        }
        private void dateTimeInput_PassportDateEnd2_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd2.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd2.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd2.Text = "";
            }
        }
        private void dateTimeInput_PassportDateEnd3_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd3.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd3.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd3.Text = "";
            }
        }
        private void dateTimeInput_PassportDateEnd4_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd4.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd4.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd4.Text = "";
            }
        }
        private void dateTimeInput_PassportDateEnd5_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd5.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd5.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd5.Text = "";
            }
        }
        private void dateTimeInput_PassportDateEnd6_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd6.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd6.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd6.Text = "";
            }
        }
        private void dateTimeInput_PassportDateEnd7_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd7.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd7.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd7.Text = "";
            }
        }
        private void dateTimeInput_PassportDateEnd8_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd8.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd8.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd8.Text = "";
            }
        }
        private void dateTimeInput_PassportDateEnd9_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd9.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd9.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd9.Text = "";
            }
        }
        private void dateTimeInput_PassportDateEnd10_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd10.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd10.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd10.Text = "";
            }
        }
        private void dateTimeInput_PassportDateEnd1_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd1.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd2_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd2.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd3_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd3.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd4_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd4.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd5_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd5.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd6_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd6.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd7_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd7.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd8_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd8.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd9_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd9.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd10_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd10.SelectAll();
        }
        private void textBox_Name1_Click(object sender, EventArgs e)
        {
            textBox_Name1.SelectAll();
        }
        private void textBox_Name2_Click(object sender, EventArgs e)
        {
            textBox_Name2.SelectAll();
        }
        private void textBox_Name3_Click(object sender, EventArgs e)
        {
            textBox_Name3.SelectAll();
        }
        private void textBox_Name4_Click(object sender, EventArgs e)
        {
            textBox_Name4.SelectAll();
        }
        private void textBox_Name5_Click(object sender, EventArgs e)
        {
            textBox_Name5.SelectAll();
        }
        private void textBox_Name6_Click(object sender, EventArgs e)
        {
            textBox_Name6.SelectAll();
        }
        private void textBox_Name7_Click(object sender, EventArgs e)
        {
            textBox_Name7.SelectAll();
        }
        private void textBox_Name8_Click(object sender, EventArgs e)
        {
            textBox_Name8.SelectAll();
        }
        private void textBox_Name9_Click(object sender, EventArgs e)
        {
            textBox_Name9.SelectAll();
        }
        private void textBox_Name10_Click(object sender, EventArgs e)
        {
            textBox_Name10.SelectAll();
        }
        private void textBox_PassporntNo1_Click(object sender, EventArgs e)
        {
            textBox_PassporntNo1.SelectAll();
        }
        private void textBox_PassporntNo2_Click(object sender, EventArgs e)
        {
            textBox_PassporntNo2.SelectAll();
        }
        private void textBox_PassporntNo3_Click(object sender, EventArgs e)
        {
            textBox_PassporntNo3.SelectAll();
        }
        private void textBox_PassporntNo4_Click(object sender, EventArgs e)
        {
            textBox_PassporntNo4.SelectAll();
        }
        private void textBox_PassporntNo5_Click(object sender, EventArgs e)
        {
            textBox_PassporntNo5.SelectAll();
        }
        private void textBox_PassporntNo6_Click(object sender, EventArgs e)
        {
            textBox_PassporntNo6.SelectAll();
        }
        private void textBox_PassporntNo7_Click(object sender, EventArgs e)
        {
            textBox_PassporntNo7.SelectAll();
        }
        private void textBox_PassporntNo8_Click(object sender, EventArgs e)
        {
            textBox_PassporntNo8.SelectAll();
        }
        private void textBox_PassporntNo9_Click(object sender, EventArgs e)
        {
            textBox_PassporntNo9.SelectAll();
        }
        private void textBox_PassporntNo10_Click(object sender, EventArgs e)
        {
            textBox_PassporntNo10.SelectAll();
        }
        private void buttonItem_GuestMove_Click(object sender, EventArgs e)
        {
            if (State != 0 || string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            string MyTime = VarGeneral.Settings_Sys.vStart + " " + VarGeneral.Settings_Sys.vStartTyp;
            string MyTime2 = VarGeneral.Settings_Sys.vEnd + " " + VarGeneral.Settings_Sys.vEndTyp;
            if (Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss tt")).TimeOfDay >= Convert.ToDateTime(Convert.ToDateTime(MyTime).ToString("HH:mm:ss tt")).TimeOfDay && Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss tt")).TimeOfDay <= Convert.ToDateTime(Convert.ToDateTime(MyTime2).ToString("HH:mm:ss tt")).TimeOfDay)
            {
                VarGeneral.RomNum = int.Parse(comboBox_Rooms.SelectedValue.ToString());
                VarGeneral.TotPer = TextBox_Remming.Value;
                FrmGuestMove frm = new FrmGuestMove(TextBox_TotalAm.Value, textBox_DayCount.Value);
                frm.Tag = LangArEn;
                frm.TopMost = true;
                frm.ShowDialog();
                if (VarGeneral.ChkMove == 1)
                {
                    Close();
                }
            }
            else
            {
                MessageBox.Show((LangArEn == 0) ? " يجب ان يتم عملية نقل الساكن بين فترة السماح و المغادرة" : "The transfer of residence must take place between the grace period and the departure", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void buttonItem_ChangeRoomPrice_Click(object sender, EventArgs e)
        {
            if (State != 0 || string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            string MyTime = VarGeneral.Settings_Sys.vStart + " " + VarGeneral.Settings_Sys.vStartTyp;
            string MyTime2 = VarGeneral.Settings_Sys.vEnd + " " + VarGeneral.Settings_Sys.vEndTyp;
            if (Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss tt")).TimeOfDay >= Convert.ToDateTime(Convert.ToDateTime(MyTime).ToString("HH:mm:ss tt")).TimeOfDay && Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss tt")).TimeOfDay <= Convert.ToDateTime(Convert.ToDateTime(MyTime2).ToString("HH:mm:ss tt")).TimeOfDay)
            {
                VarGeneral.RomNum = int.Parse(comboBox_Rooms.SelectedValue.ToString());
                VarGeneral.TotPer = TextBox_Remming.Value;
                if (data_this.DayOfM.HasValue)
                {
                    VarGeneral.GDayM = data_this.DayOfM.Value;
                }
                else
                {
                    VarGeneral.GDayM = 0;
                }
                try
                {
                    if (VarGeneral.GDayM == 0)
                    {
                        VarGeneral.GDayM = VarGeneral.Settings_Sys.DayOfM.Value;
                    }
                }
                catch
                {
                }
                VarGeneral.Dy2(db.StockRoom(data_this.romno.Value).dt, db.StockRoom(data_this.romno.Value).tm);
                VarGeneral.Ft = VarGeneral.CS;
                FrmGuestChPri frm = new FrmGuestChPri(textBox_DayCount.Value, textBox_RoomPrice.Value, TextBox_TotalAm.Value);
                frm.Tag = LangArEn;
                frm.TopMost = true;
                frm.ShowDialog();
                if (VarGeneral.ChkMove == 1)
                {
                    Close();
                }
            }
            else
            {
                MessageBox.Show((LangArEn == 0) ? " يجب ان يتم عملية نقل الساكن بين فترة السماح و المغادرة" : "The transfer of residence must take place between the grace period and the departure", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void buttonItem_AddRoom_Click(object sender, EventArgs e)
        {
            if (State == FormState.Saved && !string.IsNullOrEmpty(textBox_ID.Text))
            {
                FrmGuestAddRoom frm = new FrmGuestAddRoom();
                frm.Tag = LangArEn;
                frm.TopMost = true;
                frm.ShowDialog();
                if (VarGeneral.ChkAddRoom == 1)
                {
                    Close();
                }
            }
        }
        private void buttonItem_ChangeRoomType_Click(object sender, EventArgs e)
        {
            if (State != 0 || string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            T_Rom Q = db.StockRoom(int.Parse(comboBox_Rooms.SelectedValue.ToString()));
            if (Q == null || Q.romno == 0)
            {
                return;
            }
            VarGeneral.RomNum = int.Parse(comboBox_Rooms.SelectedValue.ToString());
            VarGeneral.TotPer = TextBox_Remming.Value;
            try
            {
                if (data_this.DayOfM.HasValue)
                {
                    VarGeneral.GDayM = data_this.DayOfM.Value;
                }
                else
                {
                    VarGeneral.GDayM = 0;
                }
            }
            catch
            {
                VarGeneral.GDayM = 0;
            }
            try
            {
                if (VarGeneral.GDayM == 0)
                {
                    VarGeneral.GDayM = VarGeneral.Settings_Sys.DayOfM.Value;
                }
            }
            catch
            {
            }
            VarGeneral.Dy2(Q.dt, Q.tm);
            VarGeneral.Ft = VarGeneral.CS;
            FrmKindPer frm = new FrmKindPer(textBox_DayCount.Value, textBox_RoomPrice.Value);
            frm.Tag = LangArEn;
            frm.TopMost = true;
            frm.ShowDialog();
            if (VarGeneral.ChKindMove == 1)
            {
                Close();
            }
        }
        private void up()
        {
            try
            {
                T_Rom Q = db.StockRoom(int.Parse(comboBox_Rooms.SelectedValue.ToString()));
                if (Q == null || Q.romno == 0)
                {
                    return;
                }
                if (comboBox_RoomTyp.SelectedIndex == 0)
                {
                    tmp = ((permission.RepAcc5 == "0") ? Q.pri0.Value : Q.pri1.Value);
                    textBox_DayRequest.Enabled = true;
                    textBox_DayRequest.Value = 1;
                    textBox_RoomPrice.Value = tmp;
                    if (R1 == 2 && M != 2)
                    {
                        textBox_DayCount.Value = 1;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(Q.dt))
                        {
                            int? calendr = VarGeneral.Settings_Sys.Calendr;
                            Q.dt = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
                        }
                        if (!VarGeneral.CheckTime(Q.tm))
                        {
                            Q.tm = DateTime.Now.ToString("hh:mm:ss");
                        }
                        textBox_DayCount.Value = VarGeneral.Dy(Q.dt, Q.tm);
                    }
                    Total();
                    return;
                }
                tmp = ((permission.RepAcc6 == "0") ? Q.priM0.Value : Q.priM1.Value);
                textBox_RoomPrice.Value = tmp;
                try
                {
                    if (data_this.DayOfM.HasValue)
                    {
                        VarGeneral.GDayM = data_this.DayOfM.Value;
                    }
                    else
                    {
                        VarGeneral.GDayM = 0;
                    }
                }
                catch
                {
                    VarGeneral.GDayM = 0;
                }
                try
                {
                    if (VarGeneral.GDayM == 0)
                    {
                        VarGeneral.GDayM = VarGeneral.Settings_Sys.DayOfM.Value;
                    }
                }
                catch
                {
                }
                if (R1 == 2 && M != 2)
                {
                    textBox_DayCount.Value = 1;
                    VarGeneral.CS = 1;
                }
                else
                {
                    if (string.IsNullOrEmpty(Q.dt))
                    {
                        int? calendr = VarGeneral.Settings_Sys.Calendr;
                        Q.dt = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
                    }
                    if (!VarGeneral.CheckTime(Q.tm))
                    {
                        Q.tm = DateTime.Now.ToString("hh:mm:ss");
                    }
                    textBox_DayCount.Value = VarGeneral.Dy(Q.dt, Q.tm);
                    VarGeneral.Dy2(Q.dt, Q.tm);
                }
                textBox_DayRequest.Enabled = false;
                textBox_DayRequest.Value = VarGeneral.GDayM * VarGeneral.CS;
                Total();
            }
            catch
            {
            }
        }
        private void comboBox_RoomTyp_Leave(object sender, EventArgs e)
        {
            if (State != 0)
            {
                up();
            }
        }
        private void buttonItem_EditDays_Click(object sender, EventArgs e)
        {
            if (State == FormState.Saved && !string.IsNullOrEmpty(textBox_ID.Text))
            {
                string vNewNo = InputDialog.mostrar((LangArEn == 0) ? "أدخل عدد الشهور المراد إضافته : " : "Enter the number of months to add : ", (LangArEn == 0) ? "تعديل عدد الشهور" : "Modify the number of months");
                if (!string.IsNullOrEmpty(vNewNo) && Information.IsNumeric(vNewNo))
                {
                    Button_Edit_Click(sender, e);
                    textBox_DayRequest.Value += VarGeneral.Settings_Sys.DayOfM.Value * int.Parse(vNewNo);
                    Button_Save_Click(sender, e);
                }
            }
        }
        private void button_SrchCustNo_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            if (State == FormState.Saved)
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
            VarGeneral.SFrmTyp = "T_AccDef_Suppliers";
            VarGeneral.AccTyp = 11;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtCustNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                textBox_NameA.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                textBox_NameE.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                textBox_Mobile.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Mobile;
            }
            else
            {
                txtCustNo.Text = "";
            }
        }
        private void textBox_Mobile_Click(object sender, EventArgs e)
        {
            textBox_Mobile.SelectAll();
        }
        private void buttonItem_SendSms_Click(object sender, EventArgs e)
        {
            if (State == FormState.Saved && !string.IsNullOrEmpty(textBox_ID.Text))
            {
                FrmSMS frm = new FrmSMS(textBox_Mobile.Text);
                frm.Tag = LangArEn;
                frm.TopMost = true;
                frm.ShowDialog();
            }
        }
        private void textBox_NameE_Enter(object sender, EventArgs e)
        {
            Framework.Keyboard.Language.Switch("English");
        }
        private void buttonItem_Print_Click(object sender, EventArgs e)
        {
            if (!(textBox_ID.Text != "") || State != 0)
            {
                return;
            }
            RepShow _RepShow = new RepShow();
            _RepShow.Tables = "  T_per left JOIN\r\n                                  T_per1 ON T_per.perno = T_per1.perno left JOIN\r\n                                  T_IDType ON T_per.pastyp = T_IDType.IDType_ID left JOIN\r\n                                  T_Job ON T_per.job = T_Job.Job_No left JOIN\r\n                                  T_Nationalities ON T_per.nath = T_Nationalities.Nation_No left JOIN\r\n                                  T_BirthPlace ON T_per.bpls = T_BirthPlace.BirthPlaceNo left JOIN\r\n                                  T_AccDef ON T_per.Cust_no = T_AccDef.AccDef_No left JOIN\r\n                                  T_Religion ON T_per.vip = T_Religion.Religion_No left JOIN\r\n                                  T_City ON T_per.paspls = T_City.City_No ";
            string Fields = "  T_per.perno, T_per.romno, T_per.nm,T_Nationalities.NameA as nathA,T_Nationalities.NameE as nathE, T_per.day, T_per.dt1, T_per.price, T_per.pasno, T_per.dt2, T_per.dt3, T_per.ch, T_per.dis, T_per.actyp, T_per.ps1, T_per.ps2, T_per.cc, T_IDType.Arb_Des as pastypA, T_IDType.Eng_Des as pastypE, T_per.tm1, T_per.tm2, T_per.tax, T_per.ser, T_per.DOL, T_per.vip,T_Job.NameA as jobA,T_Job.NameE as jobE, T_per.curr, T_per.distyp, T_per.cust, T_per.disknd, T_per.jobpls, T_per.bdt,\r\n                                T_BirthPlace.NameA as bplsA,T_Religion.NameA as vip,T_BirthPlace.NameE as bplsE,T_City.NameA as pasplsA,T_City.NameE as pasplsE, T_per.passt, T_per.pasend, T_per.enddt, T_per.pict, T_per.fat, T_per.gropno, T_per.Cust_no, T_per.Totel, T_per.DayEdit, T_per.DayImport, T_per.dt4, T_per.KindPer, T_per.DayOfM, T_per.vAmPm,T_AccDef.AccDef_No , T_AccDef.Arb_Des as AccDefNm, T_AccDef.Eng_Des as AccDefNmE ,(select LogImg from T_SYSSETTING where T_SYSSETTING.SYSSETTING_ID = 1) as LogImg,T_per1.nm as a,T_per1.bpls as b,T_per1.pasno as c,T_per1.passt as d,T_per1.pasend as e";
            _RepShow.Rule = "  Where T_per.ch=2 and T_per.perno = " + data_this.perno + " order by T_per.perno";
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
                MessageBox.Show((LangArEn == 0) ? "عفوا .. لا يوجد بيانات لعرضها في التقرير " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            try
            {
                VarGeneral.IsGeneralUsed = true;
                FrmReportsViewer frm = new FrmReportsViewer();
                frm.Repvalue = "RepGeneral";
                frm.Repvalue = "RepGuestDataPer_1";



                frm.Tag = LangArEn;
                frm.Repvalue = "RepGuestDataPer_1";
                VarGeneral.vTitle = Text;
                frm.TopMost = true;
                frm.ShowDialog();
                VarGeneral.IsGeneralUsed = false;

            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("buttonItem_RepGuestsData_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void textBox_ID_No_Click(object sender, EventArgs e)
        {
            textBox_ID.SelectAll();
        }
        private void buttonItem_RepAcc_Click(object sender, EventArgs e)
        {
            if (State == FormState.Saved && !string.IsNullOrEmpty(textBox_ID.Text))
            {
                FrmRepRevenue frm = new FrmRepRevenue(13);
                frm.Tag = LangArEn;
                frm.Text = buttonItem_RepAcc.Text;
                frm.FillCombo();
                frm.SerTypeCount += db.FillServTyp_2("").ToList().Count;
                frm.txtUserNo.Text = data_this.perno.ToString();
                frm.ButOk_Click(sender, e);
            }
        }
        private void FrmGuests_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                VarGeneral.Tmp6 = "";
            }
            catch
            {
            }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGuests));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.textBox_NameE = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.Text_1 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.Text_19 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox_RoomStat = new System.Windows.Forms.TextBox();
            this.panel_GuestDaysData = new System.Windows.Forms.Panel();
            this.textBox_RoomPrice = new DevComponents.Editors.DoubleInput();
            this.textBox_Time = new System.Windows.Forms.MaskedTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.comboBox_Curr = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label19 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_DayRequest = new DevComponents.Editors.IntegerInput();
            this.groupBox_AmPm = new System.Windows.Forms.GroupBox();
            this.RadioBox_AllowPM = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.RadioBox_AllowAM = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_Date = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_DayCount = new DevComponents.Editors.IntegerInput();
            this.label14 = new System.Windows.Forms.Label();
            this.TextBox_Remming = new DevComponents.Editors.DoubleInput();
            this.label13 = new System.Windows.Forms.Label();
            this.TextBox_Paid = new DevComponents.Editors.DoubleInput();
            this.comboBox_DisTo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox_DisType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label10 = new System.Windows.Forms.Label();
            this.TextBox_TotalAm = new DevComponents.Editors.DoubleInput();
            this.label9 = new System.Windows.Forms.Label();
            this.Textbox_DiscountVal = new DevComponents.Editors.DoubleInput();
            this.panel_GustData = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.button_ClearPic = new DevComponents.DotNetBar.ButtonX();
            this.button_EnterImg = new DevComponents.DotNetBar.ButtonX();
            this.PicItemImg = new System.Windows.Forms.PictureBox();
            this.label97 = new System.Windows.Forms.Label();
            this.textBox_Note = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.comboBox_Job = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Mobile = new System.Windows.Forms.TextBox();
            this.label124 = new System.Windows.Forms.Label();
            this.dateTimeInput_ID_DateEnd = new System.Windows.Forms.MaskedTextBox();
            this.label88 = new System.Windows.Forms.Label();
            this.label92 = new System.Windows.Forms.Label();
            this.comboBox_ID_From = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label95 = new System.Windows.Forms.Label();
            this.CmbIDTyp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_BirthPlace = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboBox_Religion = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.dateTimeInput_BirthDate = new System.Windows.Forms.MaskedTextBox();
            this.label113 = new System.Windows.Forms.Label();
            this.label115 = new System.Windows.Forms.Label();
            this.dateTimeInput_ID_Date = new System.Windows.Forms.MaskedTextBox();
            this.textBox_ID_No = new System.Windows.Forms.TextBox();
            this.comboBox_Nationality = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboBox_RoomTyp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox_PaidTyp = new System.Windows.Forms.GroupBox();
            this.checkBox_NetWork = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBox_Credit = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBox_Chash = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.txtCustNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_Rooms = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_NameA = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.Text_11 = new DevComponents.Editors.DoubleInput();
            this.Text_12 = new DevComponents.Editors.DoubleInput();
            this.button_SrchCustNo = new DevComponents.DotNetBar.ButtonX();
            this.tabItem_GuestsData = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.dateTimeInput_PassportDateStart10 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_PassportDateStart9 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_PassportDateStart8 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_PassportDateStart7 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_PassportDateStart6 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_PassportDateStart5 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_PassportDateStart4 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_PassportDateStart3 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_PassportDateStart2 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_PassportDateStart1 = new System.Windows.Forms.MaskedTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.dateTimeInput_PassportDateEnd10 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_PassportDateEnd9 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_PassportDateEnd8 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_PassportDateEnd7 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_PassportDateEnd6 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_PassportDateEnd5 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_PassportDateEnd4 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_PassportDateEnd3 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_PassportDateEnd2 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_PassportDateEnd1 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_BirthDate10 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_BirthDate9 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_BirthDate8 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_BirthDate7 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_BirthDate6 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_BirthDate5 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_BirthDate4 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_BirthDate3 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_BirthDate2 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_BirthDate1 = new System.Windows.Forms.MaskedTextBox();
            this.label122 = new System.Windows.Forms.Label();
            this.label123 = new System.Windows.Forms.Label();
            this.label129 = new System.Windows.Forms.Label();
            this.textBox_PassporntNo10 = new System.Windows.Forms.TextBox();
            this.textBox_Name10 = new System.Windows.Forms.TextBox();
            this.textBox_PassporntNo9 = new System.Windows.Forms.TextBox();
            this.textBox_Name9 = new System.Windows.Forms.TextBox();
            this.textBox_PassporntNo8 = new System.Windows.Forms.TextBox();
            this.textBox_Name8 = new System.Windows.Forms.TextBox();
            this.textBox_PassporntNo7 = new System.Windows.Forms.TextBox();
            this.textBox_Name7 = new System.Windows.Forms.TextBox();
            this.textBox_PassporntNo6 = new System.Windows.Forms.TextBox();
            this.textBox_Name6 = new System.Windows.Forms.TextBox();
            this.textBox_PassporntNo5 = new System.Windows.Forms.TextBox();
            this.textBox_Name5 = new System.Windows.Forms.TextBox();
            this.textBox_PassporntNo4 = new System.Windows.Forms.TextBox();
            this.textBox_Name4 = new System.Windows.Forms.TextBox();
            this.textBox_PassporntNo3 = new System.Windows.Forms.TextBox();
            this.textBox_Name3 = new System.Windows.Forms.TextBox();
            this.textBox_PassporntNo2 = new System.Windows.Forms.TextBox();
            this.textBox_Name2 = new System.Windows.Forms.TextBox();
            this.textBox_PassporntNo1 = new System.Windows.Forms.TextBox();
            this.textBox_Name1 = new System.Windows.Forms.TextBox();
            this.label132 = new System.Windows.Forms.Label();
            this.tabItem_FamilyData = new DevComponents.DotNetBar.TabItem(this.components);
            this.ribbonBar_Tasks = new DevComponents.DotNetBar.RibbonBar();
            this.superTabControl_Main1 = new DevComponents.DotNetBar.SuperTabControl();
            this.Button_Close = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem_Print = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Search = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Save = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Add = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem_Menue = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem_GuestMove = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem_AddRoom = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem_ChangeRoomPrice = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem_ChangeRoomType = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem_EditDays = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem_RepAcc = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem_SendSms = new DevComponents.DotNetBar.ButtonItem();
            this.superTabControl_Main2 = new DevComponents.DotNetBar.SuperTabControl();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.Button_First = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Prev = new DevComponents.DotNetBar.ButtonItem();
            this.TextBox_Index = new DevComponents.DotNetBar.TextBoxItem();
            this.Label_Count = new DevComponents.DotNetBar.LabelItem();
            this.lable_Records = new DevComponents.DotNetBar.LabelItem();
            this.Button_Next = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Last = new DevComponents.DotNetBar.ButtonItem();
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
            this.panelEx2.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.panel_GuestDaysData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_RoomPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_DayRequest)).BeginInit();
            this.groupBox_AmPm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_DayCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox_Remming)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox_Paid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox_TotalAm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Textbox_DiscountVal)).BeginInit();
            this.panel_GustData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicItemImg)).BeginInit();
            this.groupBox_PaidTyp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Text_11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text_12)).BeginInit();
            this.tabControlPanel2.SuspendLayout();
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
            this.PanelSpecialContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelSpecialContainer.Name = "PanelSpecialContainer";
            this.PanelSpecialContainer.Size = new System.Drawing.Size(200, 100);
            this.PanelSpecialContainer.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
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
            this.expandableSplitter1.Location = new System.Drawing.Point(0, -2);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(673, 14);
            this.expandableSplitter1.TabIndex = 1;
            this.expandableSplitter1.TabStop = false;
            // 
            // panelEx2
            // 
            this.panelEx2.Controls.Add(this.ribbonBar1);
            this.panelEx2.Controls.Add(this.ribbonBar_Tasks);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx2.Location = new System.Drawing.Point(0, 12);
            this.panelEx2.MinimumSize = new System.Drawing.Size(673, 488);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(673, 488);
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
            this.ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.panel2);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(673, 437);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 867;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(673, 420);
            this.panel2.TabIndex = 84;
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.Color.Transparent;
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.Controls.Add(this.tabControlPanel2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(673, 420);
            this.tabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.Metro;
            this.tabControl1.TabIndex = 1069;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabItem_GuestsData);
            this.tabControl1.Tabs.Add(this.tabItem_FamilyData);
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.textBox_NameE);
            this.tabControlPanel1.Controls.Add(this.label24);
            this.tabControlPanel1.Controls.Add(this.label22);
            this.tabControlPanel1.Controls.Add(this.Text_1);
            this.tabControlPanel1.Controls.Add(this.label21);
            this.tabControlPanel1.Controls.Add(this.Text_19);
            this.tabControlPanel1.Controls.Add(this.label18);
            this.tabControlPanel1.Controls.Add(this.label20);
            this.tabControlPanel1.Controls.Add(this.textBox_RoomStat);
            this.tabControlPanel1.Controls.Add(this.panel_GuestDaysData);
            this.tabControlPanel1.Controls.Add(this.panel_GustData);
            this.tabControlPanel1.Controls.Add(this.comboBox_RoomTyp);
            this.tabControlPanel1.Controls.Add(this.label1);
            this.tabControlPanel1.Controls.Add(this.groupBox_PaidTyp);
            this.tabControlPanel1.Controls.Add(this.txtCustNo);
            this.tabControlPanel1.Controls.Add(this.label4);
            this.tabControlPanel1.Controls.Add(this.comboBox_Rooms);
            this.tabControlPanel1.Controls.Add(this.label5);
            this.tabControlPanel1.Controls.Add(this.textBox_NameA);
            this.tabControlPanel1.Controls.Add(this.label36);
            this.tabControlPanel1.Controls.Add(this.textBox_ID);
            this.tabControlPanel1.Controls.Add(this.label38);
            this.tabControlPanel1.Controls.Add(this.Text_11);
            this.tabControlPanel1.Controls.Add(this.Text_12);
            this.tabControlPanel1.Controls.Add(this.button_SrchCustNo);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(673, 393);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItem_GuestsData;
            // 
            // textBox_NameE
            // 
            this.textBox_NameE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_NameE.Font = new System.Drawing.Font("Tahoma", 8F);
            this.textBox_NameE.ForeColor = System.Drawing.Color.Black;
            this.textBox_NameE.Location = new System.Drawing.Point(380, 74);
            this.textBox_NameE.MaxLength = 100;
            this.textBox_NameE.Name = "textBox_NameE";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_NameE, false);
            this.textBox_NameE.Size = new System.Drawing.Size(192, 20);
            this.textBox_NameE.TabIndex = 6;
            this.textBox_NameE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_NameE.Enter += new System.EventHandler(this.textBox_NameE_Enter);
            this.textBox_NameE.Leave += new System.EventHandler(this.textBox_NameA_Enter);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label24.Location = new System.Drawing.Point(573, 78);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(89, 13);
            this.label24.TabIndex = 6785;
            this.label24.Text = "الإسم - إنجليزي :";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(289, 19);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(51, 13);
            this.label22.TabIndex = 6782;
            this.label22.Text = "الحــــالة :";
            // 
            // Text_1
            // 
            this.Text_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Text_1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Text_1.Location = new System.Drawing.Point(707, 356);
            this.Text_1.MaxLength = 15;
            this.Text_1.Name = "Text_1";
            this.netResize1.SetResizeTextBoxMultiline(this.Text_1, false);
            this.Text_1.Size = new System.Drawing.Size(103, 21);
            this.Text_1.TabIndex = 6779;
            this.Text_1.Visible = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label21.Location = new System.Drawing.Point(725, 122);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(74, 13);
            this.label21.TabIndex = 6777;
            this.label21.Text = "تاريخ المغادرة :";
            this.label21.Visible = false;
            // 
            // Text_19
            // 
            this.Text_19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Text_19.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Text_19.Location = new System.Drawing.Point(695, 138);
            this.Text_19.MaxLength = 15;
            this.Text_19.Name = "Text_19";
            this.netResize1.SetResizeTextBoxMultiline(this.Text_19, false);
            this.Text_19.Size = new System.Drawing.Size(103, 21);
            this.Text_19.TabIndex = 6778;
            this.Text_19.Visible = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(754, 76);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 13);
            this.label18.TabIndex = 6773;
            this.label18.Text = "الضريبة :";
            this.label18.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label20.Location = new System.Drawing.Point(756, 24);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(45, 13);
            this.label20.TabIndex = 6775;
            this.label20.Text = "الخدمة :";
            this.label20.Visible = false;
            // 
            // textBox_RoomStat
            // 
            this.textBox_RoomStat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_RoomStat.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_RoomStat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox_RoomStat.Location = new System.Drawing.Point(182, 15);
            this.textBox_RoomStat.MaxLength = 50;
            this.textBox_RoomStat.Name = "textBox_RoomStat";
            this.textBox_RoomStat.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_RoomStat, false);
            this.textBox_RoomStat.Size = new System.Drawing.Size(103, 21);
            this.textBox_RoomStat.TabIndex = 3;
            this.textBox_RoomStat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel_GuestDaysData
            // 
            this.panel_GuestDaysData.BackColor = System.Drawing.Color.Transparent;
            this.panel_GuestDaysData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_GuestDaysData.Controls.Add(this.textBox_RoomPrice);
            this.panel_GuestDaysData.Controls.Add(this.textBox_Time);
            this.panel_GuestDaysData.Controls.Add(this.label15);
            this.panel_GuestDaysData.Controls.Add(this.comboBox_Curr);
            this.panel_GuestDaysData.Controls.Add(this.label19);
            this.panel_GuestDaysData.Controls.Add(this.label7);
            this.panel_GuestDaysData.Controls.Add(this.textBox_DayRequest);
            this.panel_GuestDaysData.Controls.Add(this.groupBox_AmPm);
            this.panel_GuestDaysData.Controls.Add(this.label11);
            this.panel_GuestDaysData.Controls.Add(this.textBox_Date);
            this.panel_GuestDaysData.Controls.Add(this.label8);
            this.panel_GuestDaysData.Controls.Add(this.label6);
            this.panel_GuestDaysData.Controls.Add(this.textBox_DayCount);
            this.panel_GuestDaysData.Controls.Add(this.label14);
            this.panel_GuestDaysData.Controls.Add(this.TextBox_Remming);
            this.panel_GuestDaysData.Controls.Add(this.label13);
            this.panel_GuestDaysData.Controls.Add(this.TextBox_Paid);
            this.panel_GuestDaysData.Controls.Add(this.comboBox_DisTo);
            this.panel_GuestDaysData.Controls.Add(this.label12);
            this.panel_GuestDaysData.Controls.Add(this.comboBox_DisType);
            this.panel_GuestDaysData.Controls.Add(this.label10);
            this.panel_GuestDaysData.Controls.Add(this.TextBox_TotalAm);
            this.panel_GuestDaysData.Controls.Add(this.label9);
            this.panel_GuestDaysData.Controls.Add(this.Textbox_DiscountVal);
            this.panel_GuestDaysData.Location = new System.Drawing.Point(6, 310);
            this.panel_GuestDaysData.Name = "panel_GuestDaysData";
            this.panel_GuestDaysData.Size = new System.Drawing.Size(663, 81);
            this.panel_GuestDaysData.TabIndex = 20;
            // 
            // textBox_RoomPrice
            // 
            this.textBox_RoomPrice.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_RoomPrice.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_RoomPrice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_RoomPrice.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_RoomPrice.DisplayFormat = "0.00";
            this.textBox_RoomPrice.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_RoomPrice.Increment = 0D;
            this.textBox_RoomPrice.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_RoomPrice.Location = new System.Drawing.Point(298, 29);
            this.textBox_RoomPrice.Name = "textBox_RoomPrice";
            this.textBox_RoomPrice.Size = new System.Drawing.Size(289, 21);
            this.textBox_RoomPrice.TabIndex = 22;
            // 
            // textBox_Time
            // 
            this.textBox_Time.BackColor = System.Drawing.Color.Maroon;
            this.textBox_Time.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_Time.ForeColor = System.Drawing.Color.White;
            this.textBox_Time.Location = new System.Drawing.Point(389, 52);
            this.textBox_Time.Mask = "##:##:##";
            this.textBox_Time.Name = "textBox_Time";
            this.textBox_Time.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_Time.Size = new System.Drawing.Size(54, 21);
            this.textBox_Time.TabIndex = 24;
            this.textBox_Time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Time.Click += new System.EventHandler(this.textBox_Time_Click);
            this.textBox_Time.Leave += new System.EventHandler(this.textBox_Time_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(444, 56);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 13);
            this.label15.TabIndex = 6728;
            this.label15.Text = "الـوقــــت :";
            // 
            // comboBox_Curr
            // 
            this.comboBox_Curr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Curr.DisplayMember = "Text";
            this.comboBox_Curr.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_Curr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Curr.FormattingEnabled = true;
            this.comboBox_Curr.ItemHeight = 14;
            this.comboBox_Curr.Location = new System.Drawing.Point(296, 29);
            this.comboBox_Curr.Name = "comboBox_Curr";
            this.comboBox_Curr.Size = new System.Drawing.Size(147, 20);
            this.comboBox_Curr.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_Curr.TabIndex = 25;
            this.comboBox_Curr.Visible = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label19.Location = new System.Drawing.Point(444, 33);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(55, 13);
            this.label19.TabIndex = 6712;
            this.label19.Text = "العملــــة :";
            this.label19.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(444, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 6707;
            this.label7.Text = "الأيام المطلوبة :";
            // 
            // textBox_DayRequest
            // 
            this.textBox_DayRequest.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_DayRequest.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_DayRequest.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_DayRequest.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_DayRequest.DisplayFormat = "0";
            this.textBox_DayRequest.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_DayRequest.ForeColor = System.Drawing.Color.Black;
            this.textBox_DayRequest.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_DayRequest.Location = new System.Drawing.Point(296, 3);
            this.textBox_DayRequest.MinValue = 1;
            this.textBox_DayRequest.Name = "textBox_DayRequest";
            this.textBox_DayRequest.Size = new System.Drawing.Size(148, 21);
            this.textBox_DayRequest.TabIndex = 21;
            this.textBox_DayRequest.Value = 1;
            // 
            // groupBox_AmPm
            // 
            this.groupBox_AmPm.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_AmPm.Controls.Add(this.RadioBox_AllowPM);
            this.groupBox_AmPm.Controls.Add(this.checkBoxX1);
            this.groupBox_AmPm.Controls.Add(this.RadioBox_AllowAM);
            this.groupBox_AmPm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox_AmPm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox_AmPm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox_AmPm.Location = new System.Drawing.Point(298, 45);
            this.groupBox_AmPm.Name = "groupBox_AmPm";
            this.groupBox_AmPm.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox_AmPm.Size = new System.Drawing.Size(90, 30);
            this.groupBox_AmPm.TabIndex = 6730;
            this.groupBox_AmPm.TabStop = false;
            // 
            // RadioBox_AllowPM
            // 
            this.RadioBox_AllowPM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RadioBox_AllowPM.AutoSize = true;
            this.RadioBox_AllowPM.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.RadioBox_AllowPM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.RadioBox_AllowPM.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.RadioBox_AllowPM.CheckSignSize = new System.Drawing.Size(14, 14);
            this.RadioBox_AllowPM.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold);
            this.RadioBox_AllowPM.Location = new System.Drawing.Point(6, 10);
            this.RadioBox_AllowPM.Name = "RadioBox_AllowPM";
            this.RadioBox_AllowPM.Size = new System.Drawing.Size(29, 16);
            this.RadioBox_AllowPM.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.RadioBox_AllowPM.TabIndex = 26;
            this.RadioBox_AllowPM.Text = "م";
            // 
            // checkBoxX1
            // 
            this.checkBoxX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxX1.AutoSize = true;
            this.checkBoxX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBoxX1.CheckSignSize = new System.Drawing.Size(14, 14);
            this.checkBoxX1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.checkBoxX1.Location = new System.Drawing.Point(2, 54);
            this.checkBoxX1.Name = "checkBoxX1";
            this.checkBoxX1.Size = new System.Drawing.Size(63, 16);
            this.checkBoxX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX1.TabIndex = 1022;
            this.checkBoxX1.Text = "شبكـــة";
            // 
            // RadioBox_AllowAM
            // 
            this.RadioBox_AllowAM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RadioBox_AllowAM.AutoSize = true;
            this.RadioBox_AllowAM.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.RadioBox_AllowAM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.RadioBox_AllowAM.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            this.RadioBox_AllowAM.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            this.RadioBox_AllowAM.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.RadioBox_AllowAM.Checked = true;
            this.RadioBox_AllowAM.CheckSignSize = new System.Drawing.Size(14, 14);
            this.RadioBox_AllowAM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RadioBox_AllowAM.CheckValue = "Y";
            this.RadioBox_AllowAM.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold);
            this.RadioBox_AllowAM.Location = new System.Drawing.Point(45, 10);
            this.RadioBox_AllowAM.Name = "RadioBox_AllowAM";
            this.RadioBox_AllowAM.Size = new System.Drawing.Size(35, 16);
            this.RadioBox_AllowAM.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.RadioBox_AllowAM.TabIndex = 25;
            this.RadioBox_AllowAM.Text = "ص";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(589, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 6727;
            this.label11.Text = "تاريخ السكن :";
            // 
            // textBox_Date
            // 
            this.textBox_Date.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox_Date.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_Date.Location = new System.Drawing.Point(526, 52);
            this.textBox_Date.Mask = "0000/00/00";
            this.textBox_Date.Name = "textBox_Date";
            this.textBox_Date.Size = new System.Drawing.Size(61, 21);
            this.textBox_Date.TabIndex = 23;
            this.textBox_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Date.Click += new System.EventHandler(this.textBox_Date_Click);
            this.textBox_Date.Leave += new System.EventHandler(this.textBox_Date_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(589, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 6709;
            this.label8.Text = "سعر الغرفة :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(589, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 6705;
            this.label6.Text = "عـدد الأيــام :";
            // 
            // textBox_DayCount
            // 
            this.textBox_DayCount.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_DayCount.BackgroundStyle.BackColor = System.Drawing.Color.SlateGray;
            this.textBox_DayCount.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_DayCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_DayCount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_DayCount.DisplayFormat = "0";
            this.textBox_DayCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_DayCount.ForeColor = System.Drawing.Color.White;
            this.textBox_DayCount.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_DayCount.IsInputReadOnly = true;
            this.textBox_DayCount.Location = new System.Drawing.Point(527, 3);
            this.textBox_DayCount.MinValue = 1;
            this.textBox_DayCount.Name = "textBox_DayCount";
            this.textBox_DayCount.Size = new System.Drawing.Size(60, 21);
            this.textBox_DayCount.TabIndex = 20;
            this.textBox_DayCount.Value = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(81, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 13);
            this.label14.TabIndex = 6725;
            this.label14.Text = "المتبقي :";
            // 
            // TextBox_Remming
            // 
            this.TextBox_Remming.AllowEmptyState = false;
            // 
            // 
            // 
            this.TextBox_Remming.BackgroundStyle.Class = "DateTimeInputBackground";
            this.TextBox_Remming.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TextBox_Remming.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.TextBox_Remming.DisplayFormat = "0.00";
            this.TextBox_Remming.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.TextBox_Remming.Increment = 0D;
            this.TextBox_Remming.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.TextBox_Remming.IsInputReadOnly = true;
            this.TextBox_Remming.Location = new System.Drawing.Point(11, 56);
            this.TextBox_Remming.Name = "TextBox_Remming";
            this.TextBox_Remming.Size = new System.Drawing.Size(70, 21);
            this.TextBox_Remming.TabIndex = 32;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(220, 60);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 13);
            this.label13.TabIndex = 6723;
            this.label13.Text = "المدفوعات :";
            // 
            // TextBox_Paid
            // 
            this.TextBox_Paid.AllowEmptyState = false;
            // 
            // 
            // 
            this.TextBox_Paid.BackgroundStyle.Class = "DateTimeInputBackground";
            this.TextBox_Paid.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TextBox_Paid.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.TextBox_Paid.DisplayFormat = "0.00";
            this.TextBox_Paid.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.TextBox_Paid.Increment = 0D;
            this.TextBox_Paid.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.TextBox_Paid.IsInputReadOnly = true;
            this.TextBox_Paid.Location = new System.Drawing.Point(135, 56);
            this.TextBox_Paid.Name = "TextBox_Paid";
            this.TextBox_Paid.Size = new System.Drawing.Size(83, 21);
            this.TextBox_Paid.TabIndex = 31;
            // 
            // comboBox_DisTo
            // 
            this.comboBox_DisTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_DisTo.DisplayMember = "Text";
            this.comboBox_DisTo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_DisTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DisTo.FormattingEnabled = true;
            this.comboBox_DisTo.ItemHeight = 14;
            this.comboBox_DisTo.Location = new System.Drawing.Point(135, 30);
            this.comboBox_DisTo.Name = "comboBox_DisTo";
            this.comboBox_DisTo.Size = new System.Drawing.Size(83, 20);
            this.comboBox_DisTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_DisTo.TabIndex = 29;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(220, 34);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 6721;
            this.label12.Text = "خصم على :";
            // 
            // comboBox_DisType
            // 
            this.comboBox_DisType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_DisType.DisplayMember = "Text";
            this.comboBox_DisType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_DisType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DisType.FormattingEnabled = true;
            this.comboBox_DisType.ItemHeight = 14;
            this.comboBox_DisType.Location = new System.Drawing.Point(11, 3);
            this.comboBox_DisType.Name = "comboBox_DisType";
            this.comboBox_DisType.Size = new System.Drawing.Size(122, 20);
            this.comboBox_DisType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_DisType.TabIndex = 28;
            this.comboBox_DisType.SelectedIndexChanged += new System.EventHandler(this.comboBox_DisType_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(81, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 6717;
            this.label10.Text = "الإجمالي :";
            // 
            // TextBox_TotalAm
            // 
            this.TextBox_TotalAm.AllowEmptyState = false;
            // 
            // 
            // 
            this.TextBox_TotalAm.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.TextBox_TotalAm.BackgroundStyle.Class = "DateTimeInputBackground";
            this.TextBox_TotalAm.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TextBox_TotalAm.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.TextBox_TotalAm.DisplayFormat = "0.00";
            this.TextBox_TotalAm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.TextBox_TotalAm.Increment = 0D;
            this.TextBox_TotalAm.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.TextBox_TotalAm.IsInputReadOnly = true;
            this.TextBox_TotalAm.Location = new System.Drawing.Point(11, 30);
            this.TextBox_TotalAm.Name = "TextBox_TotalAm";
            this.TextBox_TotalAm.Size = new System.Drawing.Size(70, 21);
            this.TextBox_TotalAm.TabIndex = 39;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(220, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 6715;
            this.label9.Text = "الخصـــم :";
            // 
            // Textbox_DiscountVal
            // 
            this.Textbox_DiscountVal.AllowEmptyState = false;
            // 
            // 
            // 
            this.Textbox_DiscountVal.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Textbox_DiscountVal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Textbox_DiscountVal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.Textbox_DiscountVal.DisplayFormat = "0.00";
            this.Textbox_DiscountVal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Textbox_DiscountVal.Increment = 0D;
            this.Textbox_DiscountVal.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.Textbox_DiscountVal.Location = new System.Drawing.Point(135, 3);
            this.Textbox_DiscountVal.Name = "Textbox_DiscountVal";
            this.Textbox_DiscountVal.Size = new System.Drawing.Size(83, 21);
            this.Textbox_DiscountVal.TabIndex = 27;
            // 
            // panel_GustData
            // 
            this.panel_GustData.BackColor = System.Drawing.Color.Transparent;
            this.panel_GustData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_GustData.Controls.Add(this.label17);
            this.panel_GustData.Controls.Add(this.label16);
            this.panel_GustData.Controls.Add(this.button_ClearPic);
            this.panel_GustData.Controls.Add(this.button_EnterImg);
            this.panel_GustData.Controls.Add(this.PicItemImg);
            this.panel_GustData.Controls.Add(this.label97);
            this.panel_GustData.Controls.Add(this.textBox_Note);
            this.panel_GustData.Controls.Add(this.comboBox_Job);
            this.panel_GustData.Controls.Add(this.label3);
            this.panel_GustData.Controls.Add(this.textBox_Mobile);
            this.panel_GustData.Controls.Add(this.label124);
            this.panel_GustData.Controls.Add(this.dateTimeInput_ID_DateEnd);
            this.panel_GustData.Controls.Add(this.label88);
            this.panel_GustData.Controls.Add(this.label92);
            this.panel_GustData.Controls.Add(this.comboBox_ID_From);
            this.panel_GustData.Controls.Add(this.label95);
            this.panel_GustData.Controls.Add(this.CmbIDTyp);
            this.panel_GustData.Controls.Add(this.label2);
            this.panel_GustData.Controls.Add(this.comboBox_BirthPlace);
            this.panel_GustData.Controls.Add(this.comboBox_Religion);
            this.panel_GustData.Controls.Add(this.dateTimeInput_BirthDate);
            this.panel_GustData.Controls.Add(this.label113);
            this.panel_GustData.Controls.Add(this.label115);
            this.panel_GustData.Controls.Add(this.dateTimeInput_ID_Date);
            this.panel_GustData.Controls.Add(this.textBox_ID_No);
            this.panel_GustData.Controls.Add(this.comboBox_Nationality);
            this.panel_GustData.Location = new System.Drawing.Point(6, 102);
            this.panel_GustData.Name = "panel_GustData";
            this.panel_GustData.Size = new System.Drawing.Size(663, 204);
            this.panel_GustData.TabIndex = 7;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(565, 66);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(83, 13);
            this.label17.TabIndex = 887;
            this.label17.Text = "تاريـخ الميــــلاد :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(355, 66);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(90, 13);
            this.label16.TabIndex = 881;
            this.label16.Text = "مكــان الميـــــلاد :";
            // 
            // button_ClearPic
            // 
            this.button_ClearPic.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_ClearPic.Checked = true;
            this.button_ClearPic.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_ClearPic.Location = new System.Drawing.Point(14, 176);
            this.button_ClearPic.Name = "button_ClearPic";
            this.button_ClearPic.Size = new System.Drawing.Size(18, 18);
            this.button_ClearPic.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_ClearPic.Symbol = "";
            this.button_ClearPic.SymbolSize = 11F;
            this.button_ClearPic.TabIndex = 34534534;
            this.button_ClearPic.TextColor = System.Drawing.Color.SteelBlue;
            this.button_ClearPic.Tooltip = "إزالة الصورة";
            this.button_ClearPic.Click += new System.EventHandler(this.button_ClearPic_Click);
            // 
            // button_EnterImg
            // 
            this.button_EnterImg.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_EnterImg.Checked = true;
            this.button_EnterImg.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_EnterImg.Location = new System.Drawing.Point(34, 176);
            this.button_EnterImg.Name = "button_EnterImg";
            this.button_EnterImg.Size = new System.Drawing.Size(18, 18);
            this.button_EnterImg.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_EnterImg.Symbol = "";
            this.button_EnterImg.SymbolSize = 11F;
            this.button_EnterImg.TabIndex = 2112321;
            this.button_EnterImg.TextColor = System.Drawing.Color.SteelBlue;
            this.button_EnterImg.Tooltip = "إضافة صورة للصنف";
            this.button_EnterImg.Click += new System.EventHandler(this.button_EnterImg_Click);
            // 
            // PicItemImg
            // 
            this.PicItemImg.BackColor = System.Drawing.Color.Transparent;
            this.PicItemImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PicItemImg.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.PicItemImg.Location = new System.Drawing.Point(10, 87);
            this.PicItemImg.Name = "PicItemImg";
            this.PicItemImg.Size = new System.Drawing.Size(168, 111);
            this.PicItemImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicItemImg.TabIndex = 6765;
            this.PicItemImg.TabStop = false;
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.BackColor = System.Drawing.Color.Transparent;
            this.label97.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label97.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label97.Location = new System.Drawing.Point(355, 16);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(90, 13);
            this.label97.TabIndex = 6704;
            this.label97.Text = "رقـــم الهـــــــوية :";
            // 
            // textBox_Note
            // 
            this.textBox_Note.BackColor = System.Drawing.Color.AliceBlue;
            // 
            // 
            // 
            this.textBox_Note.Border.Class = "TextBoxBorder";
            this.textBox_Note.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_Note.ButtonCustom.Checked = true;
            this.textBox_Note.ButtonCustom.Visible = true;
            this.textBox_Note.ForeColor = System.Drawing.Color.Black;
            this.textBox_Note.Location = new System.Drawing.Point(184, 138);
            this.textBox_Note.MaxLength = 150;
            this.textBox_Note.Multiline = true;
            this.textBox_Note.Name = "textBox_Note";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Note, false);
            this.textBox_Note.Size = new System.Drawing.Size(462, 59);
            this.textBox_Note.TabIndex = 19;
            this.textBox_Note.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Note.WatermarkText = "ملاحظة";
            // 
            // comboBox_Job
            // 
            this.comboBox_Job.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Job.DisplayMember = "Text";
            this.comboBox_Job.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_Job.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Job.FormattingEnabled = true;
            this.comboBox_Job.ItemHeight = 14;
            this.comboBox_Job.Location = new System.Drawing.Point(184, 87);
            this.comboBox_Job.Name = "comboBox_Job";
            this.comboBox_Job.Size = new System.Drawing.Size(380, 20);
            this.comboBox_Job.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_Job.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(565, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 6761;
            this.label3.Text = " الوظيفــــــــــــة :";
            // 
            // textBox_Mobile
            // 
            this.textBox_Mobile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Mobile.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_Mobile.Location = new System.Drawing.Point(461, 112);
            this.textBox_Mobile.MaxLength = 10;
            this.textBox_Mobile.Name = "textBox_Mobile";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Mobile, false);
            this.textBox_Mobile.Size = new System.Drawing.Size(103, 21);
            this.textBox_Mobile.TabIndex = 17;
            this.textBox_Mobile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Mobile.Click += new System.EventHandler(this.textBox_Mobile_Click);
            this.textBox_Mobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ID_KeyPress);
            // 
            // label124
            // 
            this.label124.AutoSize = true;
            this.label124.BackColor = System.Drawing.Color.Transparent;
            this.label124.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label124.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label124.Location = new System.Drawing.Point(565, 116);
            this.label124.Name = "label124";
            this.label124.Size = new System.Drawing.Size(84, 13);
            this.label124.TabIndex = 6759;
            this.label124.Text = "الجــــــــــــــوال :";
            // 
            // dateTimeInput_ID_DateEnd
            // 
            this.dateTimeInput_ID_DateEnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dateTimeInput_ID_DateEnd.Location = new System.Drawing.Point(240, 37);
            this.dateTimeInput_ID_DateEnd.Mask = "0000/00/00";
            this.dateTimeInput_ID_DateEnd.Name = "dateTimeInput_ID_DateEnd";
            this.dateTimeInput_ID_DateEnd.Size = new System.Drawing.Size(111, 20);
            this.dateTimeInput_ID_DateEnd.TabIndex = 11;
            this.dateTimeInput_ID_DateEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_ID_DateEnd.Click += new System.EventHandler(this.dateTimeInput_ID_DateEnd_Click);
            this.dateTimeInput_ID_DateEnd.Leave += new System.EventHandler(this.dateTimeInput_ID_DateEnd_Leave);
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.BackColor = System.Drawing.Color.Transparent;
            this.label88.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label88.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label88.Location = new System.Drawing.Point(565, 41);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(83, 13);
            this.label88.TabIndex = 6756;
            this.label88.Text = "تاريخ إصدارهـــا :";
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.BackColor = System.Drawing.Color.Transparent;
            this.label92.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label92.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label92.Location = new System.Drawing.Point(355, 41);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(90, 13);
            this.label92.TabIndex = 6757;
            this.label92.Text = "تاريخ إنتهائهـــــــا :";
            // 
            // comboBox_ID_From
            // 
            this.comboBox_ID_From.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_ID_From.DisplayMember = "Text";
            this.comboBox_ID_From.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_ID_From.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ID_From.FormattingEnabled = true;
            this.comboBox_ID_From.ItemHeight = 14;
            this.comboBox_ID_From.Location = new System.Drawing.Point(10, 37);
            this.comboBox_ID_From.Name = "comboBox_ID_From";
            this.comboBox_ID_From.Size = new System.Drawing.Size(168, 20);
            this.comboBox_ID_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_ID_From.TabIndex = 12;
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.BackColor = System.Drawing.Color.Transparent;
            this.label95.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label95.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label95.Location = new System.Drawing.Point(180, 41);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(49, 13);
            this.label95.TabIndex = 6751;
            this.label95.Text = "المصـدر :";
            // 
            // CmbIDTyp
            // 
            this.CmbIDTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbIDTyp.DisplayMember = "Text";
            this.CmbIDTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbIDTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbIDTyp.FormattingEnabled = true;
            this.CmbIDTyp.ItemHeight = 14;
            this.CmbIDTyp.Location = new System.Drawing.Point(461, 12);
            this.CmbIDTyp.Name = "CmbIDTyp";
            this.CmbIDTyp.Size = new System.Drawing.Size(103, 20);
            this.CmbIDTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbIDTyp.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(565, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 6702;
            this.label2.Text = "نـــوع الهـــــوية :";
            // 
            // comboBox_BirthPlace
            // 
            this.comboBox_BirthPlace.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_BirthPlace.DisplayMember = "Text";
            this.comboBox_BirthPlace.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_BirthPlace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_BirthPlace.FormattingEnabled = true;
            this.comboBox_BirthPlace.ItemHeight = 14;
            this.comboBox_BirthPlace.Location = new System.Drawing.Point(240, 62);
            this.comboBox_BirthPlace.Name = "comboBox_BirthPlace";
            this.comboBox_BirthPlace.Size = new System.Drawing.Size(111, 20);
            this.comboBox_BirthPlace.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_BirthPlace.TabIndex = 14;
            // 
            // comboBox_Religion
            // 
            this.comboBox_Religion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Religion.DisplayMember = "Text";
            this.comboBox_Religion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_Religion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Religion.FormattingEnabled = true;
            this.comboBox_Religion.ItemHeight = 14;
            this.comboBox_Religion.Location = new System.Drawing.Point(14, 62);
            this.comboBox_Religion.Name = "comboBox_Religion";
            this.comboBox_Religion.Size = new System.Drawing.Size(164, 20);
            this.comboBox_Religion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_Religion.TabIndex = 15;
            // 
            // dateTimeInput_BirthDate
            // 
            this.dateTimeInput_BirthDate.Location = new System.Drawing.Point(461, 62);
            this.dateTimeInput_BirthDate.Mask = "0000/00/00";
            this.dateTimeInput_BirthDate.Name = "dateTimeInput_BirthDate";
            this.dateTimeInput_BirthDate.Size = new System.Drawing.Size(103, 20);
            this.dateTimeInput_BirthDate.TabIndex = 13;
            this.dateTimeInput_BirthDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_BirthDate.Click += new System.EventHandler(this.dateTimeInput_BirthDate_Click);
            this.dateTimeInput_BirthDate.Leave += new System.EventHandler(this.dateTimeInput_BirthDate_Leave);
            // 
            // label113
            // 
            this.label113.AutoSize = true;
            this.label113.BackColor = System.Drawing.Color.Transparent;
            this.label113.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label113.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label113.Location = new System.Drawing.Point(180, 66);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(50, 13);
            this.label113.TabIndex = 873;
            this.label113.Text = "الـــديانة :";
            // 
            // label115
            // 
            this.label115.AutoSize = true;
            this.label115.BackColor = System.Drawing.Color.Transparent;
            this.label115.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label115.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label115.Location = new System.Drawing.Point(355, 116);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(53, 13);
            this.label115.TabIndex = 877;
            this.label115.Text = "الجنسية :";
            // 
            // dateTimeInput_ID_Date
            // 
            this.dateTimeInput_ID_Date.Location = new System.Drawing.Point(461, 37);
            this.dateTimeInput_ID_Date.Mask = "0000/00/00";
            this.dateTimeInput_ID_Date.Name = "dateTimeInput_ID_Date";
            this.dateTimeInput_ID_Date.Size = new System.Drawing.Size(103, 20);
            this.dateTimeInput_ID_Date.TabIndex = 10;
            this.dateTimeInput_ID_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_ID_Date.Click += new System.EventHandler(this.dateTimeInput_ID_Date_Click);
            this.dateTimeInput_ID_Date.Leave += new System.EventHandler(this.dateTimeInput_ID_Date_Leave);
            // 
            // textBox_ID_No
            // 
            this.textBox_ID_No.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox_ID_No.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_ID_No.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_ID_No.ForeColor = System.Drawing.Color.Maroon;
            this.textBox_ID_No.Location = new System.Drawing.Point(10, 12);
            this.textBox_ID_No.MaxLength = 15;
            this.textBox_ID_No.Name = "textBox_ID_No";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_ID_No, false);
            this.textBox_ID_No.Size = new System.Drawing.Size(341, 21);
            this.textBox_ID_No.TabIndex = 9;
            this.textBox_ID_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_ID_No.Click += new System.EventHandler(this.textBox_ID_No_Click);
            this.textBox_ID_No.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ID_KeyPress);
            // 
            // comboBox_Nationality
            // 
            this.comboBox_Nationality.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Nationality.DisplayMember = "Text";
            this.comboBox_Nationality.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_Nationality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Nationality.FormattingEnabled = true;
            this.comboBox_Nationality.ItemHeight = 14;
            this.comboBox_Nationality.Location = new System.Drawing.Point(184, 112);
            this.comboBox_Nationality.Name = "comboBox_Nationality";
            this.comboBox_Nationality.Size = new System.Drawing.Size(167, 20);
            this.comboBox_Nationality.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_Nationality.TabIndex = 18;
            // 
            // comboBox_RoomTyp
            // 
            this.comboBox_RoomTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_RoomTyp.DisplayMember = "Text";
            this.comboBox_RoomTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_RoomTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_RoomTyp.FormattingEnabled = true;
            this.comboBox_RoomTyp.ItemHeight = 14;
            this.comboBox_RoomTyp.Location = new System.Drawing.Point(6, 15);
            this.comboBox_RoomTyp.Name = "comboBox_RoomTyp";
            this.comboBox_RoomTyp.Size = new System.Drawing.Size(99, 20);
            this.comboBox_RoomTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_RoomTyp.TabIndex = 4;
            this.comboBox_RoomTyp.SelectedIndexChanged += new System.EventHandler(this.comboBox_RoomTyp_SelectedIndexChanged);
            this.comboBox_RoomTyp.Leave += new System.EventHandler(this.comboBox_RoomTyp_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(111, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1223;
            this.label1.Text = "نوع السكن :";
            // 
            // groupBox_PaidTyp
            // 
            this.groupBox_PaidTyp.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_PaidTyp.Controls.Add(this.checkBox_NetWork);
            this.groupBox_PaidTyp.Controls.Add(this.checkBox_Credit);
            this.groupBox_PaidTyp.Controls.Add(this.checkBox_Chash);
            this.groupBox_PaidTyp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox_PaidTyp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox_PaidTyp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox_PaidTyp.Location = new System.Drawing.Point(2, 42);
            this.groupBox_PaidTyp.Name = "groupBox_PaidTyp";
            this.groupBox_PaidTyp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox_PaidTyp.Size = new System.Drawing.Size(169, 56);
            this.groupBox_PaidTyp.TabIndex = 12153;
            this.groupBox_PaidTyp.TabStop = false;
            this.groupBox_PaidTyp.Text = "طريقة الدفع";
            // 
            // checkBox_NetWork
            // 
            this.checkBox_NetWork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_NetWork.AutoSize = true;
            this.checkBox_NetWork.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBox_NetWork.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_NetWork.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBox_NetWork.CheckSignSize = new System.Drawing.Size(14, 14);
            this.checkBox_NetWork.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.checkBox_NetWork.Location = new System.Drawing.Point(81, 54);
            this.checkBox_NetWork.Name = "checkBox_NetWork";
            this.checkBox_NetWork.Size = new System.Drawing.Size(63, 16);
            this.checkBox_NetWork.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_NetWork.TabIndex = 1022333;
            this.checkBox_NetWork.Text = "شبكـــة";
            this.checkBox_NetWork.Visible = false;
            // 
            // checkBox_Credit
            // 
            this.checkBox_Credit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_Credit.AutoSize = true;
            this.checkBox_Credit.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBox_Credit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_Credit.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBox_Credit.CheckSignSize = new System.Drawing.Size(14, 14);
            this.checkBox_Credit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.checkBox_Credit.Location = new System.Drawing.Point(16, 26);
            this.checkBox_Credit.Name = "checkBox_Credit";
            this.checkBox_Credit.Size = new System.Drawing.Size(54, 16);
            this.checkBox_Credit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_Credit.TabIndex = 36;
            this.checkBox_Credit.Text = "أجـــل";
            // 
            // checkBox_Chash
            // 
            this.checkBox_Chash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_Chash.AutoSize = true;
            this.checkBox_Chash.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBox_Chash.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_Chash.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            this.checkBox_Chash.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            this.checkBox_Chash.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBox_Chash.CheckSignSize = new System.Drawing.Size(14, 14);
            this.checkBox_Chash.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.checkBox_Chash.Location = new System.Drawing.Point(84, 26);
            this.checkBox_Chash.Name = "checkBox_Chash";
            this.checkBox_Chash.Size = new System.Drawing.Size(60, 16);
            this.checkBox_Chash.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_Chash.TabIndex = 35;
            this.checkBox_Chash.Text = "نقـــدي";
            // 
            // txtCustNo
            // 
            this.txtCustNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtCustNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtCustNo.Location = new System.Drawing.Point(182, 77);
            this.txtCustNo.MaxLength = 50;
            this.txtCustNo.Name = "txtCustNo";
            this.txtCustNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtCustNo, false);
            this.txtCustNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCustNo.Size = new System.Drawing.Size(117, 20);
            this.txtCustNo.TabIndex = 700;
            this.txtCustNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(300, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 1219;
            this.label4.Text = "حساب النزيل :";
            // 
            // comboBox_Rooms
            // 
            this.comboBox_Rooms.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Rooms.DisplayMember = "Text";
            this.comboBox_Rooms.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_Rooms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Rooms.Enabled = false;
            this.comboBox_Rooms.FormattingEnabled = true;
            this.comboBox_Rooms.ItemHeight = 14;
            this.comboBox_Rooms.Location = new System.Drawing.Point(364, 15);
            this.comboBox_Rooms.Name = "comboBox_Rooms";
            this.comboBox_Rooms.Size = new System.Drawing.Size(76, 20);
            this.comboBox_Rooms.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_Rooms.TabIndex = 2;
            this.comboBox_Rooms.SelectedValueChanged += new System.EventHandler(this.comboBox_Rooms_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(443, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 1074;
            this.label5.Text = "رقم الغرفة :";
            // 
            // textBox_NameA
            // 
            this.textBox_NameA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_NameA.Font = new System.Drawing.Font("Tahoma", 8F);
            this.textBox_NameA.ForeColor = System.Drawing.Color.Black;
            this.textBox_NameA.Location = new System.Drawing.Point(182, 46);
            this.textBox_NameA.MaxLength = 100;
            this.textBox_NameA.Name = "textBox_NameA";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_NameA, false);
            this.textBox_NameA.Size = new System.Drawing.Size(390, 20);
            this.textBox_NameA.TabIndex = 5;
            this.textBox_NameA.Enter += new System.EventHandler(this.textBox_NameA_Enter);
            this.textBox_NameA.Leave += new System.EventHandler(this.textBox_NameA_Enter);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.Transparent;
            this.label36.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label36.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label36.Location = new System.Drawing.Point(573, 50);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(88, 13);
            this.label36.TabIndex = 1072;
            this.label36.Text = "الإسم - عـــربي :";
            // 
            // textBox_ID
            // 
            this.textBox_ID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.textBox_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_ID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_ID.Location = new System.Drawing.Point(512, 15);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_ID, false);
            this.textBox_ID.Size = new System.Drawing.Size(60, 21);
            this.textBox_ID.TabIndex = 1;
            this.textBox_ID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ID_KeyPress);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.BackColor = System.Drawing.Color.Transparent;
            this.label38.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label38.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label38.Location = new System.Drawing.Point(573, 19);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(90, 13);
            this.label38.TabIndex = 1071;
            this.label38.Text = "رقــم النــــــزيــل :";
            // 
            // Text_11
            // 
            this.Text_11.AllowEmptyState = false;
            // 
            // 
            // 
            this.Text_11.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Text_11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Text_11.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.Text_11.DisplayFormat = "0.00";
            this.Text_11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Text_11.Increment = 0D;
            this.Text_11.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.Text_11.Location = new System.Drawing.Point(695, 42);
            this.Text_11.Name = "Text_11";
            this.Text_11.Size = new System.Drawing.Size(103, 21);
            this.Text_11.TabIndex = 6780;
            this.Text_11.Visible = false;
            // 
            // Text_12
            // 
            this.Text_12.AllowEmptyState = false;
            // 
            // 
            // 
            this.Text_12.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Text_12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Text_12.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.Text_12.DisplayFormat = "0.00";
            this.Text_12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Text_12.Increment = 0D;
            this.Text_12.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.Text_12.Location = new System.Drawing.Point(692, 92);
            this.Text_12.Name = "Text_12";
            this.Text_12.Size = new System.Drawing.Size(103, 21);
            this.Text_12.TabIndex = 6781;
            this.Text_12.Visible = false;
            // 
            // button_SrchCustNo
            // 
            this.button_SrchCustNo.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.button_SrchCustNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCustNo.Location = new System.Drawing.Point(208, 77);
            this.button_SrchCustNo.Name = "button_SrchCustNo";
            this.button_SrchCustNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchCustNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCustNo.Symbol = "";
            this.button_SrchCustNo.SymbolSize = 12F;
            this.button_SrchCustNo.TabIndex = 6783;
            this.button_SrchCustNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchCustNo.Visible = false;
            this.button_SrchCustNo.Click += new System.EventHandler(this.button_SrchCustNo_Click);
            // 
            // tabItem_GuestsData
            // 
            this.tabItem_GuestsData.AttachedControl = this.tabControlPanel1;
            this.tabItem_GuestsData.Name = "tabItem_GuestsData";
            this.tabItem_GuestsData.Text = "بيانات النزيل";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.dateTimeInput_PassportDateStart10);
            this.tabControlPanel2.Controls.Add(this.dateTimeInput_PassportDateStart9);
            this.tabControlPanel2.Controls.Add(this.dateTimeInput_PassportDateStart8);
            this.tabControlPanel2.Controls.Add(this.dateTimeInput_PassportDateStart7);
            this.tabControlPanel2.Controls.Add(this.dateTimeInput_PassportDateStart6);
            this.tabControlPanel2.Controls.Add(this.dateTimeInput_PassportDateStart5);
            this.tabControlPanel2.Controls.Add(this.dateTimeInput_PassportDateStart4);
            this.tabControlPanel2.Controls.Add(this.dateTimeInput_PassportDateStart3);
            this.tabControlPanel2.Controls.Add(this.dateTimeInput_PassportDateStart2);
            this.tabControlPanel2.Controls.Add(this.dateTimeInput_PassportDateStart1);
            this.tabControlPanel2.Controls.Add(this.label23);
            this.tabControlPanel2.Controls.Add(this.dateTimeInput_PassportDateEnd10);
            this.tabControlPanel2.Controls.Add(this.dateTimeInput_PassportDateEnd9);
            this.tabControlPanel2.Controls.Add(this.dateTimeInput_PassportDateEnd8);
            this.tabControlPanel2.Controls.Add(this.dateTimeInput_PassportDateEnd7);
            this.tabControlPanel2.Controls.Add(this.dateTimeInput_PassportDateEnd6);
            this.tabControlPanel2.Controls.Add(this.dateTimeInput_PassportDateEnd5);
            this.tabControlPanel2.Controls.Add(this.dateTimeInput_PassportDateEnd4);
            this.tabControlPanel2.Controls.Add(this.dateTimeInput_PassportDateEnd3);
            this.tabControlPanel2.Controls.Add(this.dateTimeInput_PassportDateEnd2);
            this.tabControlPanel2.Controls.Add(this.dateTimeInput_PassportDateEnd1);
            this.tabControlPanel2.Controls.Add(this.dateTimeInput_BirthDate10);
            this.tabControlPanel2.Controls.Add(this.dateTimeInput_BirthDate9);
            this.tabControlPanel2.Controls.Add(this.dateTimeInput_BirthDate8);
            this.tabControlPanel2.Controls.Add(this.dateTimeInput_BirthDate7);
            this.tabControlPanel2.Controls.Add(this.dateTimeInput_BirthDate6);
            this.tabControlPanel2.Controls.Add(this.dateTimeInput_BirthDate5);
            this.tabControlPanel2.Controls.Add(this.dateTimeInput_BirthDate4);
            this.tabControlPanel2.Controls.Add(this.dateTimeInput_BirthDate3);
            this.tabControlPanel2.Controls.Add(this.dateTimeInput_BirthDate2);
            this.tabControlPanel2.Controls.Add(this.dateTimeInput_BirthDate1);
            this.tabControlPanel2.Controls.Add(this.label122);
            this.tabControlPanel2.Controls.Add(this.label123);
            this.tabControlPanel2.Controls.Add(this.label129);
            this.tabControlPanel2.Controls.Add(this.textBox_PassporntNo10);
            this.tabControlPanel2.Controls.Add(this.textBox_Name10);
            this.tabControlPanel2.Controls.Add(this.textBox_PassporntNo9);
            this.tabControlPanel2.Controls.Add(this.textBox_Name9);
            this.tabControlPanel2.Controls.Add(this.textBox_PassporntNo8);
            this.tabControlPanel2.Controls.Add(this.textBox_Name8);
            this.tabControlPanel2.Controls.Add(this.textBox_PassporntNo7);
            this.tabControlPanel2.Controls.Add(this.textBox_Name7);
            this.tabControlPanel2.Controls.Add(this.textBox_PassporntNo6);
            this.tabControlPanel2.Controls.Add(this.textBox_Name6);
            this.tabControlPanel2.Controls.Add(this.textBox_PassporntNo5);
            this.tabControlPanel2.Controls.Add(this.textBox_Name5);
            this.tabControlPanel2.Controls.Add(this.textBox_PassporntNo4);
            this.tabControlPanel2.Controls.Add(this.textBox_Name4);
            this.tabControlPanel2.Controls.Add(this.textBox_PassporntNo3);
            this.tabControlPanel2.Controls.Add(this.textBox_Name3);
            this.tabControlPanel2.Controls.Add(this.textBox_PassporntNo2);
            this.tabControlPanel2.Controls.Add(this.textBox_Name2);
            this.tabControlPanel2.Controls.Add(this.textBox_PassporntNo1);
            this.tabControlPanel2.Controls.Add(this.textBox_Name1);
            this.tabControlPanel2.Controls.Add(this.label132);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(673, 393);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(213)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(216)))), ((int)(((byte)(105)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = -90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tabItem_FamilyData;
            // 
            // dateTimeInput_PassportDateStart10
            // 
            this.dateTimeInput_PassportDateStart10.Location = new System.Drawing.Point(111, 329);
            this.dateTimeInput_PassportDateStart10.Mask = "0000/00/00";
            this.dateTimeInput_PassportDateStart10.Name = "dateTimeInput_PassportDateStart10";
            this.dateTimeInput_PassportDateStart10.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_PassportDateStart10.TabIndex = 368;
            this.dateTimeInput_PassportDateStart10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_PassportDateStart10.Click += new System.EventHandler(this.dateTimeInput_PassportDateStart10_Click);
            this.dateTimeInput_PassportDateStart10.Leave += new System.EventHandler(this.dateTimeInput_PassportDateStart10_Leave);
            // 
            // dateTimeInput_PassportDateStart9
            // 
            this.dateTimeInput_PassportDateStart9.Location = new System.Drawing.Point(111, 300);
            this.dateTimeInput_PassportDateStart9.Mask = "0000/00/00";
            this.dateTimeInput_PassportDateStart9.Name = "dateTimeInput_PassportDateStart9";
            this.dateTimeInput_PassportDateStart9.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_PassportDateStart9.TabIndex = 367;
            this.dateTimeInput_PassportDateStart9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_PassportDateStart9.Click += new System.EventHandler(this.dateTimeInput_PassportDateStart9_Click);
            this.dateTimeInput_PassportDateStart9.Leave += new System.EventHandler(this.dateTimeInput_PassportDateStart9_Leave);
            // 
            // dateTimeInput_PassportDateStart8
            // 
            this.dateTimeInput_PassportDateStart8.Location = new System.Drawing.Point(111, 271);
            this.dateTimeInput_PassportDateStart8.Mask = "0000/00/00";
            this.dateTimeInput_PassportDateStart8.Name = "dateTimeInput_PassportDateStart8";
            this.dateTimeInput_PassportDateStart8.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_PassportDateStart8.TabIndex = 366;
            this.dateTimeInput_PassportDateStart8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_PassportDateStart8.Click += new System.EventHandler(this.dateTimeInput_PassportDateStart8_Click);
            this.dateTimeInput_PassportDateStart8.Leave += new System.EventHandler(this.dateTimeInput_PassportDateStart8_Leave);
            // 
            // dateTimeInput_PassportDateStart7
            // 
            this.dateTimeInput_PassportDateStart7.Location = new System.Drawing.Point(111, 242);
            this.dateTimeInput_PassportDateStart7.Mask = "0000/00/00";
            this.dateTimeInput_PassportDateStart7.Name = "dateTimeInput_PassportDateStart7";
            this.dateTimeInput_PassportDateStart7.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_PassportDateStart7.TabIndex = 365;
            this.dateTimeInput_PassportDateStart7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_PassportDateStart7.Click += new System.EventHandler(this.dateTimeInput_PassportDateStart7_Click);
            this.dateTimeInput_PassportDateStart7.Leave += new System.EventHandler(this.dateTimeInput_PassportDateStart7_Leave);
            // 
            // dateTimeInput_PassportDateStart6
            // 
            this.dateTimeInput_PassportDateStart6.Location = new System.Drawing.Point(111, 213);
            this.dateTimeInput_PassportDateStart6.Mask = "0000/00/00";
            this.dateTimeInput_PassportDateStart6.Name = "dateTimeInput_PassportDateStart6";
            this.dateTimeInput_PassportDateStart6.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_PassportDateStart6.TabIndex = 364;
            this.dateTimeInput_PassportDateStart6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_PassportDateStart6.Click += new System.EventHandler(this.dateTimeInput_PassportDateStart6_Click);
            this.dateTimeInput_PassportDateStart6.Leave += new System.EventHandler(this.dateTimeInput_PassportDateStart6_Leave);
            // 
            // dateTimeInput_PassportDateStart5
            // 
            this.dateTimeInput_PassportDateStart5.Location = new System.Drawing.Point(111, 184);
            this.dateTimeInput_PassportDateStart5.Mask = "0000/00/00";
            this.dateTimeInput_PassportDateStart5.Name = "dateTimeInput_PassportDateStart5";
            this.dateTimeInput_PassportDateStart5.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_PassportDateStart5.TabIndex = 363;
            this.dateTimeInput_PassportDateStart5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_PassportDateStart5.Click += new System.EventHandler(this.dateTimeInput_PassportDateStart5_Click);
            this.dateTimeInput_PassportDateStart5.Leave += new System.EventHandler(this.dateTimeInput_PassportDateStart5_Leave);
            // 
            // dateTimeInput_PassportDateStart4
            // 
            this.dateTimeInput_PassportDateStart4.Location = new System.Drawing.Point(111, 155);
            this.dateTimeInput_PassportDateStart4.Mask = "0000/00/00";
            this.dateTimeInput_PassportDateStart4.Name = "dateTimeInput_PassportDateStart4";
            this.dateTimeInput_PassportDateStart4.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_PassportDateStart4.TabIndex = 362;
            this.dateTimeInput_PassportDateStart4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_PassportDateStart4.Click += new System.EventHandler(this.dateTimeInput_PassportDateStart4_Click);
            this.dateTimeInput_PassportDateStart4.Leave += new System.EventHandler(this.dateTimeInput_PassportDateStart4_Leave);
            // 
            // dateTimeInput_PassportDateStart3
            // 
            this.dateTimeInput_PassportDateStart3.Location = new System.Drawing.Point(111, 126);
            this.dateTimeInput_PassportDateStart3.Mask = "0000/00/00";
            this.dateTimeInput_PassportDateStart3.Name = "dateTimeInput_PassportDateStart3";
            this.dateTimeInput_PassportDateStart3.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_PassportDateStart3.TabIndex = 361;
            this.dateTimeInput_PassportDateStart3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_PassportDateStart3.Click += new System.EventHandler(this.dateTimeInput_PassportDateStart3_Click);
            this.dateTimeInput_PassportDateStart3.Leave += new System.EventHandler(this.dateTimeInput_PassportDateStart3_Leave);
            // 
            // dateTimeInput_PassportDateStart2
            // 
            this.dateTimeInput_PassportDateStart2.Location = new System.Drawing.Point(111, 97);
            this.dateTimeInput_PassportDateStart2.Mask = "0000/00/00";
            this.dateTimeInput_PassportDateStart2.Name = "dateTimeInput_PassportDateStart2";
            this.dateTimeInput_PassportDateStart2.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_PassportDateStart2.TabIndex = 360;
            this.dateTimeInput_PassportDateStart2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_PassportDateStart2.Click += new System.EventHandler(this.dateTimeInput_PassportDateStart2_Click);
            this.dateTimeInput_PassportDateStart2.Leave += new System.EventHandler(this.dateTimeInput_PassportDateStart2_Leave);
            // 
            // dateTimeInput_PassportDateStart1
            // 
            this.dateTimeInput_PassportDateStart1.Location = new System.Drawing.Point(111, 68);
            this.dateTimeInput_PassportDateStart1.Mask = "0000/00/00";
            this.dateTimeInput_PassportDateStart1.Name = "dateTimeInput_PassportDateStart1";
            this.dateTimeInput_PassportDateStart1.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_PassportDateStart1.TabIndex = 359;
            this.dateTimeInput_PassportDateStart1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_PassportDateStart1.Click += new System.EventHandler(this.dateTimeInput_PassportDateStart1_Click);
            this.dateTimeInput_PassportDateStart1.Leave += new System.EventHandler(this.dateTimeInput_PassportDateStart1_Leave);
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.Maroon;
            this.label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label23.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label23.Location = new System.Drawing.Point(111, 20);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(98, 40);
            this.label23.TabIndex = 369;
            this.label23.Text = "تاريخ الإصدار";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateTimeInput_PassportDateEnd10
            // 
            this.dateTimeInput_PassportDateEnd10.Location = new System.Drawing.Point(7, 329);
            this.dateTimeInput_PassportDateEnd10.Mask = "0000/00/00";
            this.dateTimeInput_PassportDateEnd10.Name = "dateTimeInput_PassportDateEnd10";
            this.dateTimeInput_PassportDateEnd10.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_PassportDateEnd10.TabIndex = 353;
            this.dateTimeInput_PassportDateEnd10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_PassportDateEnd10.Click += new System.EventHandler(this.dateTimeInput_PassportDateEnd10_Click);
            this.dateTimeInput_PassportDateEnd10.Leave += new System.EventHandler(this.dateTimeInput_PassportDateEnd10_Leave);
            // 
            // dateTimeInput_PassportDateEnd9
            // 
            this.dateTimeInput_PassportDateEnd9.Location = new System.Drawing.Point(7, 300);
            this.dateTimeInput_PassportDateEnd9.Mask = "0000/00/00";
            this.dateTimeInput_PassportDateEnd9.Name = "dateTimeInput_PassportDateEnd9";
            this.dateTimeInput_PassportDateEnd9.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_PassportDateEnd9.TabIndex = 348;
            this.dateTimeInput_PassportDateEnd9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_PassportDateEnd9.Click += new System.EventHandler(this.dateTimeInput_PassportDateEnd9_Click);
            this.dateTimeInput_PassportDateEnd9.Leave += new System.EventHandler(this.dateTimeInput_PassportDateEnd9_Leave);
            // 
            // dateTimeInput_PassportDateEnd8
            // 
            this.dateTimeInput_PassportDateEnd8.Location = new System.Drawing.Point(7, 271);
            this.dateTimeInput_PassportDateEnd8.Mask = "0000/00/00";
            this.dateTimeInput_PassportDateEnd8.Name = "dateTimeInput_PassportDateEnd8";
            this.dateTimeInput_PassportDateEnd8.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_PassportDateEnd8.TabIndex = 343;
            this.dateTimeInput_PassportDateEnd8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_PassportDateEnd8.Click += new System.EventHandler(this.dateTimeInput_PassportDateEnd8_Click);
            this.dateTimeInput_PassportDateEnd8.Leave += new System.EventHandler(this.dateTimeInput_PassportDateEnd8_Leave);
            // 
            // dateTimeInput_PassportDateEnd7
            // 
            this.dateTimeInput_PassportDateEnd7.Location = new System.Drawing.Point(7, 242);
            this.dateTimeInput_PassportDateEnd7.Mask = "0000/00/00";
            this.dateTimeInput_PassportDateEnd7.Name = "dateTimeInput_PassportDateEnd7";
            this.dateTimeInput_PassportDateEnd7.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_PassportDateEnd7.TabIndex = 338;
            this.dateTimeInput_PassportDateEnd7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_PassportDateEnd7.Click += new System.EventHandler(this.dateTimeInput_PassportDateEnd7_Click);
            this.dateTimeInput_PassportDateEnd7.Leave += new System.EventHandler(this.dateTimeInput_PassportDateEnd7_Leave);
            // 
            // dateTimeInput_PassportDateEnd6
            // 
            this.dateTimeInput_PassportDateEnd6.Location = new System.Drawing.Point(7, 213);
            this.dateTimeInput_PassportDateEnd6.Mask = "0000/00/00";
            this.dateTimeInput_PassportDateEnd6.Name = "dateTimeInput_PassportDateEnd6";
            this.dateTimeInput_PassportDateEnd6.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_PassportDateEnd6.TabIndex = 333;
            this.dateTimeInput_PassportDateEnd6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_PassportDateEnd6.Click += new System.EventHandler(this.dateTimeInput_PassportDateEnd6_Click);
            this.dateTimeInput_PassportDateEnd6.Leave += new System.EventHandler(this.dateTimeInput_PassportDateEnd6_Leave);
            // 
            // dateTimeInput_PassportDateEnd5
            // 
            this.dateTimeInput_PassportDateEnd5.Location = new System.Drawing.Point(7, 184);
            this.dateTimeInput_PassportDateEnd5.Mask = "0000/00/00";
            this.dateTimeInput_PassportDateEnd5.Name = "dateTimeInput_PassportDateEnd5";
            this.dateTimeInput_PassportDateEnd5.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_PassportDateEnd5.TabIndex = 328;
            this.dateTimeInput_PassportDateEnd5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_PassportDateEnd5.Click += new System.EventHandler(this.dateTimeInput_PassportDateEnd5_Click);
            this.dateTimeInput_PassportDateEnd5.Leave += new System.EventHandler(this.dateTimeInput_PassportDateEnd5_Leave);
            // 
            // dateTimeInput_PassportDateEnd4
            // 
            this.dateTimeInput_PassportDateEnd4.Location = new System.Drawing.Point(7, 155);
            this.dateTimeInput_PassportDateEnd4.Mask = "0000/00/00";
            this.dateTimeInput_PassportDateEnd4.Name = "dateTimeInput_PassportDateEnd4";
            this.dateTimeInput_PassportDateEnd4.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_PassportDateEnd4.TabIndex = 323;
            this.dateTimeInput_PassportDateEnd4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_PassportDateEnd4.Click += new System.EventHandler(this.dateTimeInput_PassportDateEnd4_Click);
            this.dateTimeInput_PassportDateEnd4.Leave += new System.EventHandler(this.dateTimeInput_PassportDateEnd4_Leave);
            // 
            // dateTimeInput_PassportDateEnd3
            // 
            this.dateTimeInput_PassportDateEnd3.Location = new System.Drawing.Point(7, 126);
            this.dateTimeInput_PassportDateEnd3.Mask = "0000/00/00";
            this.dateTimeInput_PassportDateEnd3.Name = "dateTimeInput_PassportDateEnd3";
            this.dateTimeInput_PassportDateEnd3.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_PassportDateEnd3.TabIndex = 318;
            this.dateTimeInput_PassportDateEnd3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_PassportDateEnd3.Click += new System.EventHandler(this.dateTimeInput_PassportDateEnd3_Click);
            this.dateTimeInput_PassportDateEnd3.Leave += new System.EventHandler(this.dateTimeInput_PassportDateEnd3_Leave);
            // 
            // dateTimeInput_PassportDateEnd2
            // 
            this.dateTimeInput_PassportDateEnd2.Location = new System.Drawing.Point(7, 97);
            this.dateTimeInput_PassportDateEnd2.Mask = "0000/00/00";
            this.dateTimeInput_PassportDateEnd2.Name = "dateTimeInput_PassportDateEnd2";
            this.dateTimeInput_PassportDateEnd2.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_PassportDateEnd2.TabIndex = 313;
            this.dateTimeInput_PassportDateEnd2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_PassportDateEnd2.Click += new System.EventHandler(this.dateTimeInput_PassportDateEnd2_Click);
            this.dateTimeInput_PassportDateEnd2.Leave += new System.EventHandler(this.dateTimeInput_PassportDateEnd2_Leave);
            // 
            // dateTimeInput_PassportDateEnd1
            // 
            this.dateTimeInput_PassportDateEnd1.Location = new System.Drawing.Point(7, 68);
            this.dateTimeInput_PassportDateEnd1.Mask = "0000/00/00";
            this.dateTimeInput_PassportDateEnd1.Name = "dateTimeInput_PassportDateEnd1";
            this.dateTimeInput_PassportDateEnd1.Size = new System.Drawing.Size(98, 20);
            this.dateTimeInput_PassportDateEnd1.TabIndex = 307;
            this.dateTimeInput_PassportDateEnd1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_PassportDateEnd1.Click += new System.EventHandler(this.dateTimeInput_PassportDateEnd1_Click);
            this.dateTimeInput_PassportDateEnd1.Leave += new System.EventHandler(this.dateTimeInput_PassportDateEnd1_Leave);
            // 
            // dateTimeInput_BirthDate10
            // 
            this.dateTimeInput_BirthDate10.Location = new System.Drawing.Point(362, 329);
            this.dateTimeInput_BirthDate10.Mask = "0000/00/00";
            this.dateTimeInput_BirthDate10.Name = "dateTimeInput_BirthDate10";
            this.dateTimeInput_BirthDate10.Size = new System.Drawing.Size(118, 20);
            this.dateTimeInput_BirthDate10.TabIndex = 350;
            this.dateTimeInput_BirthDate10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_BirthDate10.Click += new System.EventHandler(this.dateTimeInput_BirthDate10_Click);
            this.dateTimeInput_BirthDate10.Leave += new System.EventHandler(this.dateTimeInput_BirthDate10_Leave);
            // 
            // dateTimeInput_BirthDate9
            // 
            this.dateTimeInput_BirthDate9.Location = new System.Drawing.Point(362, 300);
            this.dateTimeInput_BirthDate9.Mask = "0000/00/00";
            this.dateTimeInput_BirthDate9.Name = "dateTimeInput_BirthDate9";
            this.dateTimeInput_BirthDate9.Size = new System.Drawing.Size(118, 20);
            this.dateTimeInput_BirthDate9.TabIndex = 345;
            this.dateTimeInput_BirthDate9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_BirthDate9.Click += new System.EventHandler(this.dateTimeInput_BirthDate9_Click);
            this.dateTimeInput_BirthDate9.Leave += new System.EventHandler(this.dateTimeInput_BirthDate9_Leave);
            // 
            // dateTimeInput_BirthDate8
            // 
            this.dateTimeInput_BirthDate8.Location = new System.Drawing.Point(362, 271);
            this.dateTimeInput_BirthDate8.Mask = "0000/00/00";
            this.dateTimeInput_BirthDate8.Name = "dateTimeInput_BirthDate8";
            this.dateTimeInput_BirthDate8.Size = new System.Drawing.Size(118, 20);
            this.dateTimeInput_BirthDate8.TabIndex = 340;
            this.dateTimeInput_BirthDate8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_BirthDate8.Click += new System.EventHandler(this.dateTimeInput_BirthDate8_Click);
            this.dateTimeInput_BirthDate8.Leave += new System.EventHandler(this.dateTimeInput_BirthDate8_Leave);
            // 
            // dateTimeInput_BirthDate7
            // 
            this.dateTimeInput_BirthDate7.Location = new System.Drawing.Point(362, 242);
            this.dateTimeInput_BirthDate7.Mask = "0000/00/00";
            this.dateTimeInput_BirthDate7.Name = "dateTimeInput_BirthDate7";
            this.dateTimeInput_BirthDate7.Size = new System.Drawing.Size(118, 20);
            this.dateTimeInput_BirthDate7.TabIndex = 335;
            this.dateTimeInput_BirthDate7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_BirthDate7.Click += new System.EventHandler(this.dateTimeInput_BirthDate7_Click);
            this.dateTimeInput_BirthDate7.Leave += new System.EventHandler(this.dateTimeInput_BirthDate7_Leave);
            // 
            // dateTimeInput_BirthDate6
            // 
            this.dateTimeInput_BirthDate6.Location = new System.Drawing.Point(362, 213);
            this.dateTimeInput_BirthDate6.Mask = "0000/00/00";
            this.dateTimeInput_BirthDate6.Name = "dateTimeInput_BirthDate6";
            this.dateTimeInput_BirthDate6.Size = new System.Drawing.Size(118, 20);
            this.dateTimeInput_BirthDate6.TabIndex = 330;
            this.dateTimeInput_BirthDate6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_BirthDate6.Click += new System.EventHandler(this.dateTimeInput_BirthDate6_Click);
            this.dateTimeInput_BirthDate6.Leave += new System.EventHandler(this.dateTimeInput_BirthDate6_Leave);
            // 
            // dateTimeInput_BirthDate5
            // 
            this.dateTimeInput_BirthDate5.Location = new System.Drawing.Point(362, 184);
            this.dateTimeInput_BirthDate5.Mask = "0000/00/00";
            this.dateTimeInput_BirthDate5.Name = "dateTimeInput_BirthDate5";
            this.dateTimeInput_BirthDate5.Size = new System.Drawing.Size(118, 20);
            this.dateTimeInput_BirthDate5.TabIndex = 325;
            this.dateTimeInput_BirthDate5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_BirthDate5.Click += new System.EventHandler(this.dateTimeInput_BirthDate5_Click);
            this.dateTimeInput_BirthDate5.Leave += new System.EventHandler(this.dateTimeInput_BirthDate5_Leave);
            // 
            // dateTimeInput_BirthDate4
            // 
            this.dateTimeInput_BirthDate4.Location = new System.Drawing.Point(362, 155);
            this.dateTimeInput_BirthDate4.Mask = "0000/00/00";
            this.dateTimeInput_BirthDate4.Name = "dateTimeInput_BirthDate4";
            this.dateTimeInput_BirthDate4.Size = new System.Drawing.Size(118, 20);
            this.dateTimeInput_BirthDate4.TabIndex = 320;
            this.dateTimeInput_BirthDate4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_BirthDate4.Click += new System.EventHandler(this.dateTimeInput_BirthDate4_Click);
            this.dateTimeInput_BirthDate4.Leave += new System.EventHandler(this.dateTimeInput_BirthDate4_Leave);
            // 
            // dateTimeInput_BirthDate3
            // 
            this.dateTimeInput_BirthDate3.Location = new System.Drawing.Point(362, 126);
            this.dateTimeInput_BirthDate3.Mask = "0000/00/00";
            this.dateTimeInput_BirthDate3.Name = "dateTimeInput_BirthDate3";
            this.dateTimeInput_BirthDate3.Size = new System.Drawing.Size(118, 20);
            this.dateTimeInput_BirthDate3.TabIndex = 315;
            this.dateTimeInput_BirthDate3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_BirthDate3.Click += new System.EventHandler(this.dateTimeInput_BirthDate3_Click);
            this.dateTimeInput_BirthDate3.Leave += new System.EventHandler(this.dateTimeInput_BirthDate3_Leave);
            // 
            // dateTimeInput_BirthDate2
            // 
            this.dateTimeInput_BirthDate2.Location = new System.Drawing.Point(362, 97);
            this.dateTimeInput_BirthDate2.Mask = "0000/00/00";
            this.dateTimeInput_BirthDate2.Name = "dateTimeInput_BirthDate2";
            this.dateTimeInput_BirthDate2.Size = new System.Drawing.Size(118, 20);
            this.dateTimeInput_BirthDate2.TabIndex = 310;
            this.dateTimeInput_BirthDate2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_BirthDate2.Click += new System.EventHandler(this.dateTimeInput_BirthDate2_Click);
            this.dateTimeInput_BirthDate2.Leave += new System.EventHandler(this.dateTimeInput_BirthDate2_Leave);
            // 
            // dateTimeInput_BirthDate1
            // 
            this.dateTimeInput_BirthDate1.Location = new System.Drawing.Point(362, 68);
            this.dateTimeInput_BirthDate1.Mask = "0000/00/00";
            this.dateTimeInput_BirthDate1.Name = "dateTimeInput_BirthDate1";
            this.dateTimeInput_BirthDate1.Size = new System.Drawing.Size(118, 20);
            this.dateTimeInput_BirthDate1.TabIndex = 305;
            this.dateTimeInput_BirthDate1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_BirthDate1.Click += new System.EventHandler(this.dateTimeInput_BirthDate1_Click);
            this.dateTimeInput_BirthDate1.Leave += new System.EventHandler(this.dateTimeInput_BirthDate1_Leave);
            // 
            // label122
            // 
            this.label122.BackColor = System.Drawing.Color.Maroon;
            this.label122.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label122.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label122.ForeColor = System.Drawing.Color.White;
            this.label122.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label122.Location = new System.Drawing.Point(7, 19);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(98, 40);
            this.label122.TabIndex = 358;
            this.label122.Text = "تاريخ الإنتهاء";
            this.label122.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label123
            // 
            this.label123.BackColor = System.Drawing.Color.Transparent;
            this.label123.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label123.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label123.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label123.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label123.Location = new System.Drawing.Point(215, 19);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(141, 40);
            this.label123.TabIndex = 357;
            this.label123.Text = "رقم الهوية";
            this.label123.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label129
            // 
            this.label129.BackColor = System.Drawing.Color.Transparent;
            this.label129.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label129.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label129.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label129.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label129.Location = new System.Drawing.Point(362, 19);
            this.label129.Name = "label129";
            this.label129.Size = new System.Drawing.Size(118, 40);
            this.label129.TabIndex = 355;
            this.label129.Text = "تاريخ الميلاد";
            this.label129.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_PassporntNo10
            // 
            this.textBox_PassporntNo10.BackColor = System.Drawing.Color.White;
            this.textBox_PassporntNo10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_PassporntNo10.Location = new System.Drawing.Point(215, 329);
            this.textBox_PassporntNo10.MaxLength = 15;
            this.textBox_PassporntNo10.Name = "textBox_PassporntNo10";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_PassporntNo10, false);
            this.textBox_PassporntNo10.Size = new System.Drawing.Size(141, 20);
            this.textBox_PassporntNo10.TabIndex = 352;
            this.textBox_PassporntNo10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_PassporntNo10.Click += new System.EventHandler(this.textBox_PassporntNo10_Click);
            this.textBox_PassporntNo10.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ID_KeyPress);
            // 
            // textBox_Name10
            // 
            this.textBox_Name10.BackColor = System.Drawing.Color.White;
            this.textBox_Name10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Name10.Location = new System.Drawing.Point(486, 329);
            this.textBox_Name10.MaxLength = 20;
            this.textBox_Name10.Name = "textBox_Name10";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Name10, false);
            this.textBox_Name10.Size = new System.Drawing.Size(182, 20);
            this.textBox_Name10.TabIndex = 349;
            this.textBox_Name10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Name10.Click += new System.EventHandler(this.textBox_Name10_Click);
            this.textBox_Name10.Enter += new System.EventHandler(this.textBox_NameA_Enter);
            // 
            // textBox_PassporntNo9
            // 
            this.textBox_PassporntNo9.BackColor = System.Drawing.Color.White;
            this.textBox_PassporntNo9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_PassporntNo9.Location = new System.Drawing.Point(215, 300);
            this.textBox_PassporntNo9.MaxLength = 15;
            this.textBox_PassporntNo9.Name = "textBox_PassporntNo9";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_PassporntNo9, false);
            this.textBox_PassporntNo9.Size = new System.Drawing.Size(141, 20);
            this.textBox_PassporntNo9.TabIndex = 347;
            this.textBox_PassporntNo9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_PassporntNo9.Click += new System.EventHandler(this.textBox_PassporntNo9_Click);
            this.textBox_PassporntNo9.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ID_KeyPress);
            // 
            // textBox_Name9
            // 
            this.textBox_Name9.BackColor = System.Drawing.Color.White;
            this.textBox_Name9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Name9.Location = new System.Drawing.Point(486, 300);
            this.textBox_Name9.MaxLength = 20;
            this.textBox_Name9.Name = "textBox_Name9";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Name9, false);
            this.textBox_Name9.Size = new System.Drawing.Size(182, 20);
            this.textBox_Name9.TabIndex = 344;
            this.textBox_Name9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Name9.Click += new System.EventHandler(this.textBox_Name9_Click);
            this.textBox_Name9.Enter += new System.EventHandler(this.textBox_NameA_Enter);
            // 
            // textBox_PassporntNo8
            // 
            this.textBox_PassporntNo8.BackColor = System.Drawing.Color.White;
            this.textBox_PassporntNo8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_PassporntNo8.Location = new System.Drawing.Point(215, 271);
            this.textBox_PassporntNo8.MaxLength = 15;
            this.textBox_PassporntNo8.Name = "textBox_PassporntNo8";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_PassporntNo8, false);
            this.textBox_PassporntNo8.Size = new System.Drawing.Size(141, 20);
            this.textBox_PassporntNo8.TabIndex = 342;
            this.textBox_PassporntNo8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_PassporntNo8.Click += new System.EventHandler(this.textBox_PassporntNo8_Click);
            this.textBox_PassporntNo8.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ID_KeyPress);
            // 
            // textBox_Name8
            // 
            this.textBox_Name8.BackColor = System.Drawing.Color.White;
            this.textBox_Name8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Name8.Location = new System.Drawing.Point(486, 271);
            this.textBox_Name8.MaxLength = 20;
            this.textBox_Name8.Name = "textBox_Name8";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Name8, false);
            this.textBox_Name8.Size = new System.Drawing.Size(182, 20);
            this.textBox_Name8.TabIndex = 339;
            this.textBox_Name8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Name8.Click += new System.EventHandler(this.textBox_Name8_Click);
            this.textBox_Name8.Enter += new System.EventHandler(this.textBox_NameA_Enter);
            // 
            // textBox_PassporntNo7
            // 
            this.textBox_PassporntNo7.BackColor = System.Drawing.Color.White;
            this.textBox_PassporntNo7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_PassporntNo7.Location = new System.Drawing.Point(215, 242);
            this.textBox_PassporntNo7.MaxLength = 15;
            this.textBox_PassporntNo7.Name = "textBox_PassporntNo7";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_PassporntNo7, false);
            this.textBox_PassporntNo7.Size = new System.Drawing.Size(141, 20);
            this.textBox_PassporntNo7.TabIndex = 337;
            this.textBox_PassporntNo7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_PassporntNo7.Click += new System.EventHandler(this.textBox_PassporntNo7_Click);
            this.textBox_PassporntNo7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ID_KeyPress);
            // 
            // textBox_Name7
            // 
            this.textBox_Name7.BackColor = System.Drawing.Color.White;
            this.textBox_Name7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Name7.Location = new System.Drawing.Point(486, 242);
            this.textBox_Name7.MaxLength = 20;
            this.textBox_Name7.Name = "textBox_Name7";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Name7, false);
            this.textBox_Name7.Size = new System.Drawing.Size(182, 20);
            this.textBox_Name7.TabIndex = 334;
            this.textBox_Name7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Name7.Click += new System.EventHandler(this.textBox_Name7_Click);
            this.textBox_Name7.Enter += new System.EventHandler(this.textBox_NameA_Enter);
            // 
            // textBox_PassporntNo6
            // 
            this.textBox_PassporntNo6.BackColor = System.Drawing.Color.White;
            this.textBox_PassporntNo6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_PassporntNo6.Location = new System.Drawing.Point(215, 213);
            this.textBox_PassporntNo6.MaxLength = 15;
            this.textBox_PassporntNo6.Name = "textBox_PassporntNo6";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_PassporntNo6, false);
            this.textBox_PassporntNo6.Size = new System.Drawing.Size(141, 20);
            this.textBox_PassporntNo6.TabIndex = 332;
            this.textBox_PassporntNo6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_PassporntNo6.Click += new System.EventHandler(this.textBox_PassporntNo6_Click);
            this.textBox_PassporntNo6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ID_KeyPress);
            // 
            // textBox_Name6
            // 
            this.textBox_Name6.BackColor = System.Drawing.Color.White;
            this.textBox_Name6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Name6.Location = new System.Drawing.Point(486, 213);
            this.textBox_Name6.MaxLength = 20;
            this.textBox_Name6.Name = "textBox_Name6";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Name6, false);
            this.textBox_Name6.Size = new System.Drawing.Size(182, 20);
            this.textBox_Name6.TabIndex = 329;
            this.textBox_Name6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Name6.Click += new System.EventHandler(this.textBox_Name6_Click);
            this.textBox_Name6.Enter += new System.EventHandler(this.textBox_NameA_Enter);
            // 
            // textBox_PassporntNo5
            // 
            this.textBox_PassporntNo5.BackColor = System.Drawing.Color.White;
            this.textBox_PassporntNo5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_PassporntNo5.Location = new System.Drawing.Point(215, 184);
            this.textBox_PassporntNo5.MaxLength = 15;
            this.textBox_PassporntNo5.Name = "textBox_PassporntNo5";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_PassporntNo5, false);
            this.textBox_PassporntNo5.Size = new System.Drawing.Size(141, 20);
            this.textBox_PassporntNo5.TabIndex = 327;
            this.textBox_PassporntNo5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_PassporntNo5.Click += new System.EventHandler(this.textBox_PassporntNo5_Click);
            this.textBox_PassporntNo5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ID_KeyPress);
            // 
            // textBox_Name5
            // 
            this.textBox_Name5.BackColor = System.Drawing.Color.White;
            this.textBox_Name5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Name5.Location = new System.Drawing.Point(486, 184);
            this.textBox_Name5.MaxLength = 20;
            this.textBox_Name5.Name = "textBox_Name5";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Name5, false);
            this.textBox_Name5.Size = new System.Drawing.Size(182, 20);
            this.textBox_Name5.TabIndex = 324;
            this.textBox_Name5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Name5.Click += new System.EventHandler(this.textBox_Name5_Click);
            this.textBox_Name5.Enter += new System.EventHandler(this.textBox_NameA_Enter);
            // 
            // textBox_PassporntNo4
            // 
            this.textBox_PassporntNo4.BackColor = System.Drawing.Color.White;
            this.textBox_PassporntNo4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_PassporntNo4.Location = new System.Drawing.Point(215, 155);
            this.textBox_PassporntNo4.MaxLength = 15;
            this.textBox_PassporntNo4.Name = "textBox_PassporntNo4";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_PassporntNo4, false);
            this.textBox_PassporntNo4.Size = new System.Drawing.Size(141, 20);
            this.textBox_PassporntNo4.TabIndex = 322;
            this.textBox_PassporntNo4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_PassporntNo4.Click += new System.EventHandler(this.textBox_PassporntNo4_Click);
            this.textBox_PassporntNo4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ID_KeyPress);
            // 
            // textBox_Name4
            // 
            this.textBox_Name4.BackColor = System.Drawing.Color.White;
            this.textBox_Name4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Name4.Location = new System.Drawing.Point(486, 155);
            this.textBox_Name4.MaxLength = 20;
            this.textBox_Name4.Name = "textBox_Name4";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Name4, false);
            this.textBox_Name4.Size = new System.Drawing.Size(182, 20);
            this.textBox_Name4.TabIndex = 319;
            this.textBox_Name4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Name4.Click += new System.EventHandler(this.textBox_Name4_Click);
            this.textBox_Name4.Enter += new System.EventHandler(this.textBox_NameA_Enter);
            // 
            // textBox_PassporntNo3
            // 
            this.textBox_PassporntNo3.BackColor = System.Drawing.Color.White;
            this.textBox_PassporntNo3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_PassporntNo3.Location = new System.Drawing.Point(215, 126);
            this.textBox_PassporntNo3.MaxLength = 15;
            this.textBox_PassporntNo3.Name = "textBox_PassporntNo3";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_PassporntNo3, false);
            this.textBox_PassporntNo3.Size = new System.Drawing.Size(141, 20);
            this.textBox_PassporntNo3.TabIndex = 317;
            this.textBox_PassporntNo3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_PassporntNo3.Click += new System.EventHandler(this.textBox_PassporntNo3_Click);
            this.textBox_PassporntNo3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ID_KeyPress);
            // 
            // textBox_Name3
            // 
            this.textBox_Name3.BackColor = System.Drawing.Color.White;
            this.textBox_Name3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Name3.Location = new System.Drawing.Point(486, 126);
            this.textBox_Name3.MaxLength = 20;
            this.textBox_Name3.Name = "textBox_Name3";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Name3, false);
            this.textBox_Name3.Size = new System.Drawing.Size(182, 20);
            this.textBox_Name3.TabIndex = 314;
            this.textBox_Name3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Name3.Click += new System.EventHandler(this.textBox_Name3_Click);
            this.textBox_Name3.Enter += new System.EventHandler(this.textBox_NameA_Enter);
            // 
            // textBox_PassporntNo2
            // 
            this.textBox_PassporntNo2.BackColor = System.Drawing.Color.White;
            this.textBox_PassporntNo2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_PassporntNo2.Location = new System.Drawing.Point(215, 97);
            this.textBox_PassporntNo2.MaxLength = 15;
            this.textBox_PassporntNo2.Name = "textBox_PassporntNo2";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_PassporntNo2, false);
            this.textBox_PassporntNo2.Size = new System.Drawing.Size(141, 20);
            this.textBox_PassporntNo2.TabIndex = 312;
            this.textBox_PassporntNo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_PassporntNo2.Click += new System.EventHandler(this.textBox_PassporntNo2_Click);
            this.textBox_PassporntNo2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ID_KeyPress);
            // 
            // textBox_Name2
            // 
            this.textBox_Name2.BackColor = System.Drawing.Color.White;
            this.textBox_Name2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Name2.Location = new System.Drawing.Point(486, 97);
            this.textBox_Name2.MaxLength = 20;
            this.textBox_Name2.Name = "textBox_Name2";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Name2, false);
            this.textBox_Name2.Size = new System.Drawing.Size(182, 20);
            this.textBox_Name2.TabIndex = 309;
            this.textBox_Name2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Name2.Click += new System.EventHandler(this.textBox_Name2_Click);
            this.textBox_Name2.Enter += new System.EventHandler(this.textBox_NameA_Enter);
            // 
            // textBox_PassporntNo1
            // 
            this.textBox_PassporntNo1.BackColor = System.Drawing.Color.White;
            this.textBox_PassporntNo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_PassporntNo1.Location = new System.Drawing.Point(215, 68);
            this.textBox_PassporntNo1.MaxLength = 15;
            this.textBox_PassporntNo1.Name = "textBox_PassporntNo1";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_PassporntNo1, false);
            this.textBox_PassporntNo1.Size = new System.Drawing.Size(141, 20);
            this.textBox_PassporntNo1.TabIndex = 308;
            this.textBox_PassporntNo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_PassporntNo1.Click += new System.EventHandler(this.textBox_PassporntNo1_Click);
            this.textBox_PassporntNo1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ID_KeyPress);
            // 
            // textBox_Name1
            // 
            this.textBox_Name1.BackColor = System.Drawing.Color.White;
            this.textBox_Name1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Name1.Location = new System.Drawing.Point(486, 68);
            this.textBox_Name1.MaxLength = 20;
            this.textBox_Name1.Name = "textBox_Name1";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Name1, false);
            this.textBox_Name1.Size = new System.Drawing.Size(182, 20);
            this.textBox_Name1.TabIndex = 304;
            this.textBox_Name1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Name1.Click += new System.EventHandler(this.textBox_Name1_Click);
            this.textBox_Name1.Enter += new System.EventHandler(this.textBox_NameA_Enter);
            // 
            // label132
            // 
            this.label132.BackColor = System.Drawing.Color.Transparent;
            this.label132.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label132.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label132.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label132.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label132.Location = new System.Drawing.Point(486, 19);
            this.label132.Name = "label132";
            this.label132.Size = new System.Drawing.Size(182, 40);
            this.label132.TabIndex = 354;
            this.label132.Text = "إسم المـــــرافق";
            this.label132.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabItem_FamilyData
            // 
            this.tabItem_FamilyData.AttachedControl = this.tabControlPanel2;
            this.tabItem_FamilyData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(213)))));
            this.tabItem_FamilyData.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(216)))), ((int)(((byte)(105)))));
            this.tabItem_FamilyData.Name = "tabItem_FamilyData";
            this.tabItem_FamilyData.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Yellow;
            this.tabItem_FamilyData.Text = "بيانات المرافقين";
            this.tabItem_FamilyData.TextColor = System.Drawing.Color.Black;
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
            this.ribbonBar_Tasks.Location = new System.Drawing.Point(0, 437);
            this.ribbonBar_Tasks.Name = "ribbonBar_Tasks";
            this.ribbonBar_Tasks.Size = new System.Drawing.Size(673, 51);
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
            this.superTabControl_Main1.Size = new System.Drawing.Size(298, 51);
            this.superTabControl_Main1.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_Main1.TabIndex = 10;
            this.superTabControl_Main1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.Button_Close,
            this.buttonItem_Print,
            this.Button_Search,
            this.Button_Save,
            this.Button_Add,
            this.buttonItem_Menue});
            this.superTabControl_Main1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.superTabControl_Main1.Text = "superTabControl3";
            this.superTabControl_Main1.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
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
            // buttonItem_Print
            // 
            this.buttonItem_Print.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem_Print.FontBold = true;
            this.buttonItem_Print.FontItalic = true;
            this.buttonItem_Print.ForeColor = System.Drawing.Color.DimGray;
            this.buttonItem_Print.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem_Print.Image")));
            this.buttonItem_Print.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.buttonItem_Print.ImagePaddingHorizontal = 15;
            this.buttonItem_Print.ImagePaddingVertical = 11;
            this.buttonItem_Print.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem_Print.Name = "buttonItem_Print";
            this.buttonItem_Print.Stretch = true;
            this.buttonItem_Print.SubItemsExpandWidth = 14;
            this.buttonItem_Print.Symbol = "";
            this.buttonItem_Print.SymbolSize = 15F;
            this.buttonItem_Print.Text = "طباعة";
            this.buttonItem_Print.Tooltip = "طباعة السجل الحالي";
            this.buttonItem_Print.Click += new System.EventHandler(this.buttonItem_Print_Click);
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
            // buttonItem_Menue
            // 
            this.buttonItem_Menue.AutoExpandOnClick = true;
            this.buttonItem_Menue.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem_Menue.FontBold = true;
            this.buttonItem_Menue.FontItalic = true;
            this.buttonItem_Menue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonItem_Menue.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem_Menue.Image")));
            this.buttonItem_Menue.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.buttonItem_Menue.ImagePaddingHorizontal = 15;
            this.buttonItem_Menue.ImagePaddingVertical = 11;
            this.buttonItem_Menue.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem_Menue.Name = "buttonItem_Menue";
            this.buttonItem_Menue.PopupSide = DevComponents.DotNetBar.ePopupSide.Top;
            this.buttonItem_Menue.ShowSubItems = false;
            this.buttonItem_Menue.Stretch = true;
            this.buttonItem_Menue.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem_GuestMove,
            this.buttonItem_AddRoom,
            this.buttonItem_ChangeRoomPrice,
            this.buttonItem_ChangeRoomType,
            this.buttonItem_EditDays,
            this.buttonItem_RepAcc,
            this.buttonItem_SendSms});
            this.buttonItem_Menue.SubItemsExpandWidth = 14;
            this.buttonItem_Menue.Symbol = "";
            this.buttonItem_Menue.SymbolSize = 15F;
            this.buttonItem_Menue.Text = "...";
            // 
            // buttonItem_GuestMove
            // 
            this.buttonItem_GuestMove.BeginGroup = true;
            this.buttonItem_GuestMove.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.buttonItem_GuestMove.FontBold = true;
            this.buttonItem_GuestMove.Name = "buttonItem_GuestMove";
            this.buttonItem_GuestMove.Symbol = "";
            this.buttonItem_GuestMove.Text = "نقل الساكن";
            this.buttonItem_GuestMove.Click += new System.EventHandler(this.buttonItem_GuestMove_Click);
            // 
            // buttonItem_AddRoom
            // 
            this.buttonItem_AddRoom.BeginGroup = true;
            this.buttonItem_AddRoom.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.buttonItem_AddRoom.FontBold = true;
            this.buttonItem_AddRoom.Name = "buttonItem_AddRoom";
            this.buttonItem_AddRoom.Symbol = "";
            this.buttonItem_AddRoom.Text = "إضافة ملحق";
            this.buttonItem_AddRoom.Click += new System.EventHandler(this.buttonItem_AddRoom_Click);
            // 
            // buttonItem_ChangeRoomPrice
            // 
            this.buttonItem_ChangeRoomPrice.BeginGroup = true;
            this.buttonItem_ChangeRoomPrice.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.buttonItem_ChangeRoomPrice.FontBold = true;
            this.buttonItem_ChangeRoomPrice.Name = "buttonItem_ChangeRoomPrice";
            this.buttonItem_ChangeRoomPrice.Symbol = "";
            this.buttonItem_ChangeRoomPrice.Text = "تغيير سعر الغرفة";
            this.buttonItem_ChangeRoomPrice.Click += new System.EventHandler(this.buttonItem_ChangeRoomPrice_Click);
            // 
            // buttonItem_ChangeRoomType
            // 
            this.buttonItem_ChangeRoomType.BeginGroup = true;
            this.buttonItem_ChangeRoomType.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.buttonItem_ChangeRoomType.FontBold = true;
            this.buttonItem_ChangeRoomType.Name = "buttonItem_ChangeRoomType";
            this.buttonItem_ChangeRoomType.Symbol = "";
            this.buttonItem_ChangeRoomType.Text = "تغيير نوع السـكن";
            this.buttonItem_ChangeRoomType.Click += new System.EventHandler(this.buttonItem_ChangeRoomType_Click);
            // 
            // buttonItem_EditDays
            // 
            this.buttonItem_EditDays.BeginGroup = true;
            this.buttonItem_EditDays.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.buttonItem_EditDays.FontBold = true;
            this.buttonItem_EditDays.Name = "buttonItem_EditDays";
            this.buttonItem_EditDays.Symbol = "";
            this.buttonItem_EditDays.Text = "تعديل الشهور المطلوبة";
            this.buttonItem_EditDays.Click += new System.EventHandler(this.buttonItem_EditDays_Click);
            // 
            // buttonItem_RepAcc
            // 
            this.buttonItem_RepAcc.BeginGroup = true;
            this.buttonItem_RepAcc.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.buttonItem_RepAcc.FontBold = true;
            this.buttonItem_RepAcc.Name = "buttonItem_RepAcc";
            this.buttonItem_RepAcc.Symbol = "";
            this.buttonItem_RepAcc.Text = "كشف حساب النزيل";
            this.buttonItem_RepAcc.Click += new System.EventHandler(this.buttonItem_RepAcc_Click);
            // 
            // buttonItem_SendSms
            // 
            this.buttonItem_SendSms.BeginGroup = true;
            this.buttonItem_SendSms.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.buttonItem_SendSms.FontBold = true;
            this.buttonItem_SendSms.Name = "buttonItem_SendSms";
            this.buttonItem_SendSms.Symbol = "";
            this.buttonItem_SendSms.Text = "إرسال رسالة نصية";
            this.buttonItem_SendSms.Click += new System.EventHandler(this.buttonItem_SendSms_Click);
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
            this.superTabControl_Main2.Location = new System.Drawing.Point(298, 0);
            this.superTabControl_Main2.Name = "superTabControl_Main2";
            this.superTabControl_Main2.ReorderTabsEnabled = true;
            this.superTabControl_Main2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.superTabControl_Main2.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_Main2.SelectedTabIndex = -1;
            this.superTabControl_Main2.Size = new System.Drawing.Size(375, 51);
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
            this.DGV_Main.Size = new System.Drawing.Size(673, 0);
            this.DGV_Main.TabIndex = 862;
            // 
            // panelEx3
            // 
            this.panelEx3.Controls.Add(this.DGV_Main);
            this.panelEx3.Controls.Add(this.ribbonBar_DGV);
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx3.Location = new System.Drawing.Point(0, 0);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(673, 0);
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
            this.ribbonBar_DGV.Size = new System.Drawing.Size(673, 51);
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
            this.superTabControl_DGV.Size = new System.Drawing.Size(673, 51);
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
            this.Button_PrintTable.Visible = false;
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
            this.panel1.Size = new System.Drawing.Size(673, 500);
            this.panel1.TabIndex = 897;
            // 
            // barTopDockSite
            // 
            this.barTopDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barTopDockSite.Dock = System.Windows.Forms.DockStyle.Top;
            this.barTopDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barTopDockSite.Location = new System.Drawing.Point(0, 0);
            this.barTopDockSite.Name = "barTopDockSite";
            this.barTopDockSite.Size = new System.Drawing.Size(673, 0);
            this.barTopDockSite.TabIndex = 889;
            this.barTopDockSite.TabStop = false;
            // 
            // barBottomDockSite
            // 
            this.barBottomDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barBottomDockSite.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barBottomDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barBottomDockSite.Location = new System.Drawing.Point(0, 500);
            this.barBottomDockSite.Name = "barBottomDockSite";
            this.barBottomDockSite.Size = new System.Drawing.Size(673, 0);
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
            this.barLeftDockSite.Size = new System.Drawing.Size(0, 500);
            this.barLeftDockSite.TabIndex = 891;
            this.barLeftDockSite.TabStop = false;
            // 
            // barRightDockSite
            // 
            this.barRightDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barRightDockSite.Dock = System.Windows.Forms.DockStyle.Right;
            this.barRightDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barRightDockSite.Location = new System.Drawing.Point(673, 0);
            this.barRightDockSite.Name = "barRightDockSite";
            this.barRightDockSite.Size = new System.Drawing.Size(0, 500);
            this.barRightDockSite.TabIndex = 892;
            this.barRightDockSite.TabStop = false;
            // 
            // dockSite4
            // 
            this.dockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite4.Location = new System.Drawing.Point(0, 500);
            this.dockSite4.Name = "dockSite4";
            this.dockSite4.Size = new System.Drawing.Size(673, 0);
            this.dockSite4.TabIndex = 896;
            this.dockSite4.TabStop = false;
            // 
            // dockSite1
            // 
            this.dockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite1.Location = new System.Drawing.Point(0, 0);
            this.dockSite1.Name = "dockSite1";
            this.dockSite1.Size = new System.Drawing.Size(0, 500);
            this.dockSite1.TabIndex = 893;
            this.dockSite1.TabStop = false;
            // 
            // dockSite2
            // 
            this.dockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite2.Location = new System.Drawing.Point(673, 0);
            this.dockSite2.Name = "dockSite2";
            this.dockSite2.Size = new System.Drawing.Size(0, 500);
            this.dockSite2.TabIndex = 894;
            this.dockSite2.TabStop = false;
            // 
            // dockSite3
            // 
            this.dockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite3.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite3.Location = new System.Drawing.Point(0, 0);
            this.dockSite3.Name = "dockSite3";
            this.dockSite3.Size = new System.Drawing.Size(673, 0);
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
            // FrmGuests
            // 
            this.ClientSize = new System.Drawing.Size(673, 500);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barTopDockSite);
            this.Controls.Add(this.barBottomDockSite);
            this.Controls.Add(this.barLeftDockSite);
            this.Controls.Add(this.barRightDockSite);
            this.Controls.Add(this.dockSite4);
            this.Controls.Add(this.dockSite1);
            this.Controls.Add(this.dockSite2);
            this.Controls.Add(this.dockSite3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = global::InvAcc.Properties.Resources.favicon;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmGuests";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmGuests_FormClosed);
            this.Load += new System.EventHandler(this.FrmGuests_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.panelEx2.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            this.tabControlPanel1.PerformLayout();
            this.panel_GuestDaysData.ResumeLayout(false);
            this.panel_GuestDaysData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_RoomPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_DayRequest)).EndInit();
            this.groupBox_AmPm.ResumeLayout(false);
            this.groupBox_AmPm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_DayCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox_Remming)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox_Paid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox_TotalAm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Textbox_DiscountVal)).EndInit();
            this.panel_GustData.ResumeLayout(false);
            this.panel_GustData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicItemImg)).EndInit();
            this.groupBox_PaidTyp.ResumeLayout(false);
            this.groupBox_PaidTyp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Text_11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text_12)).EndInit();
            this.tabControlPanel2.ResumeLayout(false);
            this.tabControlPanel2.PerformLayout();
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
