using DevComponents.AdvTree;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
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
    public partial  class FrmAccDef_ : Form
    { void avs(int arln)

{ 
 label6.Text=   (arln == 0 ? "  مستوى الحساب الأب  " : "  parent account level مستوى") ; label10.Text=   (arln == 0 ? "  الحالة  " : "  Status") ; label5.Text=   (arln == 0 ? "  المستوى :  " : "  the level :") ; label7.Text=   (arln == 0 ? "  الحساب الرئيسي :  " : "  main account:") ; label4.Text=   (arln == 0 ? "  رقم الحساب :  " : "  account number :") ; label2.Text=   (arln == 0 ? "  إسم الحساب انجليزي :  " : "  English account name:") ; label1.Text=   (arln == 0 ? "  إسم الحساب  عربي :  " : "  Arabic account name:") ; label17.Text=   (arln == 0 ? "  النسبة من المبيعات  " : "  percentage of sales") ; label18.Text=   (arln == 0 ? "  %  " : "  %") ; label16.Text=   (arln == 0 ? "  رقم ضريبـــي :  " : "  tax number:") ; checkBoxX_Stoped.Text=   (arln == 0 ? "  حظــر الحســــاب  " : "  Ban Account") ; label15.Text=   (arln == 0 ? "  *  " : "  *") ; label8.Text=   (arln == 0 ? "  ترحيـــل إلى :  " : "  Relay to:") ; label3.Text=   (arln == 0 ? "  التصنيــــــف :  " : "  Classification:") ; groupBox5.Text=   (arln == 0 ? "  نوع الحساب  " : "  account type") ; checkBox_Credit.Text=   (arln == 0 ? "  دائــن  " : "  creditor") ; checkBox_Debit.Text=   (arln == 0 ? "  مــدين  " : "  owe") ; label9.Text=   (arln == 0 ? "  رصيد إفتتاحي :  " : "  Opening balance :") ; label14.Text=   (arln == 0 ? "  حد المديونيـــة  " : "  indebtedness limit") ; label13.Text=   (arln == 0 ? "  الرصيد  " : "  Balance") ; label12.Text=   (arln == 0 ? "  أجمالي المدين  " : "  total debit") ; label11.Text=   (arln == 0 ? "  أجمالي الدائن  " : "  total creditor") ; treeView1.Text=   (arln == 0 ? "  advTree2  " : "  advTree2") ; superTabControl_Main1.Text=   (arln == 0 ? "  superTabControl3  " : "  superTabControl3") ; Button_Close.Text=   (arln == 0 ? "  إغلاق  " : "  Close") ; Button_Search.Text=   (arln == 0 ? "  بحث  " : "  Search") ; Button_Delete.Text=   (arln == 0 ? "  حذف  " : "  delete") ; Button_Save.Text=   (arln == 0 ? "  حفظ  " : "  save") ; Button_Add.Text=   (arln == 0 ? "  إضافة  " : "  addition") ; superTabControl_Main2.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; Button_First.Text=   (arln == 0 ? "  الأول  " : "  the first") ; Button_Prev.Text=   (arln == 0 ? "  السابق  " : "  the previous") ; lable_Records.Text=   (arln == 0 ? "  ---  " : "  ---") ; Button_Next.Text=   (arln == 0 ? "  التالي  " : "  next one") ; Button_Last.Text=   (arln == 0 ? "  الأخير  " : "  the last one") ; superTabControl_DGV.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; textBox_search.Text=   (arln == 0 ? "  ...  " : "  ...") ; Button_ExportTable2.Text=   (arln == 0 ? "  تصدير  " : "  Export") ; /*Button_PrintTable.Text=   (arln == 0 ? "  طباعة  " : "  Print") ; */DGV_Main.Text=   (arln == 0 ? "    " : "    ") ; DGV_Main.Text=   (arln == 0 ? "  جميــع السجــــلات  " : "  All records") ; DGV_Main.Text=   (arln == 0 ? "    " : "    ") ; panelEx3.Text=   (arln == 0 ? "  Fill Panel  " : "  Fill Panel") ; ToolStripMenuItem_Det.Text=   (arln == 0 ? "  إظهار التفاصيل  " : "  Show details") ; panelEx2.Text=   (arln == 0 ? "  Click to collapse  " : "  Click to collapse") ; ToolStripMenuItem_Rep.Text=   (arln == 0 ? "  إظهار التقرير  " : "  Show report") ; node4.Text=   (arln == 0 ? "  <b>AdvTree</b> Control  " : "  <b>AdvTree</b> Control") ; node15.Text=   (arln == 0 ? "  Check-boxes  " : "  Check-boxes") ; node17.Text=   (arln == 0 ? "  Option 2  " : "  Option 2") ; node18.Text=   (arln == 0 ? "  Option 3  " : "  Option 3") ; cell17.Text=   (arln == 0 ? "  Option 3  " : "  Option 3") ; node19.Text=   (arln == 0 ? "  Radio-buttons  " : "  Radio-buttons") ; node20.Text=   (arln == 0 ? "  Option 1  " : "  Option 1") ; node21.Text=   (arln == 0 ? "  Option 2  " : "  Option 2") ; node22.Text=   (arln == 0 ? "  Option 3  " : "  Option 3") ; node23.Text=   (arln == 0 ? "  Images  " : "  Images") ; node24.Text=   (arln == 0 ? "  Multiple images per node  " : "  Multiple images per node") ; node25.Text=   (arln == 0 ? "  Image/text alignment  " : "  Image/text alignment") ; node26.Text=   (arln == 0 ? "  Orientation  " : "  Orientation") ; node27.Text=   (arln == 0 ? "  Text-markup support  " : "  Text-markup support") ; node28.Text=   (arln == 0 ? "  DotNetBar <a href" : "  DotNetBar <a href") ; node29.Text=   (arln == 0 ? "  Windows Forms Control Hosting  " : "  Windows Forms Control Hosting") ; node30.Text=   (arln == 0 ? "  Progress bar  " : "  Progress bar") ; tabItem1.Text=   (arln == 0 ? "  Advanced Features  " : "  Advanced Features") ; tabItem3.Text=   (arln == 0 ? "  Data-Binding  " : "  Data-Binding") ; columnHeader7.Text=   (arln == 0 ? "  Invoice Number  " : "  Invoice Number") ; columnHeader8.Text=   (arln == 0 ? "  Customer  " : "  Customer") ; node31.Text=   (arln == 0 ? "  102-290120  " : "  102-290120") ; node38.Text=   (arln == 0 ? "  10  " : "  10") ; cell28.Text=   (arln == 0 ? "  Refurbished Rubber Band  " : "  Refurbished Rubber Band") ; cell29.Text=   (arln == 0 ? "  $10.00  " : "  $10.00") ; node39.Text=   (arln == 0 ? "  1  " : "  1") ; cell30.Text=   (arln == 0 ? "  Toy Rocket Engine  " : "  Toy Rocket Engine") ; cell31.Text=   (arln == 0 ? "  $50.00  " : "  $50.00") ; node32.Text=   (arln == 0 ? "  102-290122  " : "  102-290122") ; node34.Text=   (arln == 0 ? "  1  " : "  1") ; cell22.Text=   (arln == 0 ? "  Giant Rubber Band (for tripping Road Runners)  " : "  Giant Rubber Band (for tripping Road Runners)") ; cell23.Text=   (arln == 0 ? "  $349.00  " : "  $349.00") ; node35.Text=   (arln == 0 ? "  1  " : "  1") ; cell24.Text=   (arln == 0 ? "  Acme Rocket Sled  " : "  Acme Rocket Sled") ; cell25.Text=   (arln == 0 ? "  $982.00  " : "  $982.00") ; node36.Text=   (arln == 0 ? "  1  " : "  1") ; cell26.Text=   (arln == 0 ? "  Bat-Man Outfit  " : "  Bat-Man Outfit") ; cell27.Text=   (arln == 0 ? "  $99.00  " : "  $99.00") ; node33.Text=   (arln == 0 ? "  102-290123  " : "  102-290123") ; node37.Text=   (arln == 0 ? "  1  " : "  1") ; cell32.Text=   (arln == 0 ? "  Black Silk Role 50m  " : "  Black Silk Role 50m") ; cell33.Text=   (arln == 0 ? "  $115.99  " : "  $115.99") ; tabItem2.Text=   (arln == 0 ? "  Node Columns  " : "  Node Columns") ; columnHeader4.Text=   (arln == 0 ? "  From  " : "  From") ; columnHeader5.Text=   (arln == 0 ? "  Subject  " : "  Subject") ; columnHeader6.Text=   (arln == 0 ? "  Received  " : "  Received") ; node1.Text=   (arln == 0 ? "  Personal Folders  " : "  Personal Folders") ; node2.Text=   (arln == 0 ? "  Deleted Items <font color" : "  Deleted Items <font color") ; node5.Text=   (arln == 0 ? "  Inbox  " : "  Inbox") ; node10.Text=   (arln == 0 ? "  NewEgg  " : "  NewEgg") ; cell7.Text=   (arln == 0 ? "  Free Shipping on Acer Notebook $549.99, and Don’t Miss Our Canon SD1100 Sweepstak  +" : "  Free Shipping on Acer Notebook $549.99, and Don't Miss Our Canon SD1100 Sweepstak +") ; cell8.Text=   (arln == 0 ? "  Thu 4/10/2008 6:38 AM  " : "  Thu 4/10/2008 6:38 AM") ; node8.Text=   (arln == 0 ? "  Denis Basaric (DevComponents)  " : "  Denis Basaric (DevComponents)") ; cell15.Text=   (arln == 0 ? "  DotNetBar for Windows Forms 7.3 Released  " : "  DotNetBar for Windows Forms 7.3 Released") ; cell16.Text=   (arln == 0 ? "  Wed 4/30/2008 8:00 PM  " : "  Wed 4/30/2008 8:00 PM") ; node9.Text=   (arln == 0 ? "  GoDaddy.com  " : "  GoDaddy.com") ; cell13.Text=   (arln == 0 ? "  Certified GoDaddy.com Renewal Notice  " : "  Certified GoDaddy.com Renewal Notice") ; cell14.Text=   (arln == 0 ? "  Wed 4/2/2008 7:09 AM  " : "  Wed 4/2/2008 7:09 AM") ; node11.Text=   (arln == 0 ? "  DevComponents  " : "  DevComponents") ; cell1.Text=   (arln == 0 ? "  DotNetBar now includes advanced Tree control  " : "  DotNetBar now includes advanced Tree control") ; cell2.Text=   (arln == 0 ? "  Fri 4/11/2008 11:45 AM  " : "  Fri 4/11/2008 11:45 AM") ; node12.Text=   (arln == 0 ? "  Autoblog  " : "  Autoblog") ; cell3.Text=   (arln == 0 ? "  VW brings back Golf GTI Pirelli in the UK  " : "  VW brings back Golf GTI Pirelli in the UK") ; cell4.Text=   (arln == 0 ? "  Fri 4/10/2008 9:01 AM  " : "  Fri 10/04/2008 9:01 AM") ; node13.Text=   (arln == 0 ? "  Engadget  " : "  Engadget") ; cell5.Text=   (arln == 0 ? "  Canon\'s Rebel XSi turns up in retail spy shot  " : "  Canon\'s Rebel XSi turns up in retail spy shot") ; cell6.Text=   (arln == 0 ? "  Fri 4/10/2008 9:01 AM  " : "  Fri 10/04/2008 9:01 AM") ; node6.Text=   (arln == 0 ? "  Junk E-mail  " : "  Junk E-mail") ; node14.Text=   (arln == 0 ? "  ZipZoomfly  " : "  ZipZoomfly") ; cell9.Text=   (arln == 0 ? "  ZipZoomfly Your Luck is Here  " : "  ZipZoomfly Your Luck is Here") ; cell10.Text=   (arln == 0 ? "  Tue 3/4/2008 1:38 PM  " : "  Tue 3/4/2008 1:38 PM") ; node7.Text=   (arln == 0 ? "  Outbox  " : "  Outbox") ; Text = "كرت الحســــابات";this.Text=   (arln == 0 ? "  كرت الحســــابات  " : "  account card") ;}
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
        private Timer timer1;
        private SuperTabControl superTabControl_DGV;
        protected ButtonItem Button_ExportTable2;
        protected ButtonItem Button_PrintTable;
        protected LabelItem labelItem3;
        protected SuperGridControl DGV_Main;
        protected LabelItem Label_Count;
        private PanelEx panelEx3;
        private RibbonBar ribbonBar_DGV;
        protected ButtonItem Button_Next;
        protected TextBoxItem TextBox_Index;
        protected ButtonItem Button_Last;
        private Timer timerInfoBallon;
        private System.Windows.Forms. SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog  openFileDialog1;
        protected ContextMenuStrip contextMenuStrip1;
        protected ToolStripMenuItem ToolStripMenuItem_Det;
        private Panel panel1;
        private ExpandableSplitter expandableSplitter1;
        private RibbonBar ribbonBar1;
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
        protected ToolStripMenuItem ToolStripMenuItem_Rep;
        private ImageList imageList1;
        private DockSite barTopDockSite;
        private DockSite barLeftDockSite;
        private DockSite barBottomDockSite;
        private DockSite barRightDockSite;
        private DockSite dockSite4;
        private DockSite dockSite1;
        public DotNetBarManager dotNetBarManager1;
        private DockSite dockSite2;
        private DockSite dockSite3;
        protected ContextMenuStrip contextMenuStrip2;
        private DevComponents.DotNetBar.TabControl tabControl1;
        private TabControlPanel tabControlPanel1;
        private AdvTree advTree3;
        private ProgressBarX progressBarX1;
        private Node node4;
        private Node node15;
        private Node node17;
        private Node node18;
        private Cell cell17;
        private Node node19;
        private Node node20;
        private Node node21;
        private Node node22;
        private Node node23;
        private Node node24;
        private Cell cell18;
        private Node node25;
        private Node node26;
        private Node node27;
        private Node node28;
        private Node node29;
        private Node node30;
        private ElementStyle elementStyle4;
        private NodeConnector nodeConnector1;
        private ElementStyle elementStyle3;
        private TabItem tabItem1;
        private TabControlPanel tabControlPanel3;
        private AdvTree advTree5;
        private ElementStyle elementStyle6;
        private TabItem tabItem3;
        private TabControlPanel tabControlPanel2;
        private AdvTree advTree4;
        private DevComponents.AdvTree.ColumnHeader columnHeader7;
        private DevComponents.AdvTree.ColumnHeader columnHeader8;
        private Node node31;
        private Node node38;
        private Cell cell28;
        private Cell cell29;
        private Node node39;
        private Cell cell30;
        private Cell cell31;
        private Node node32;
        private Node node34;
        private Cell cell22;
        private Cell cell23;
        private Node node35;
        private Cell cell24;
        private Cell cell25;
        private Node node36;
        private Cell cell26;
        private Cell cell27;
        private Node node33;
        private Node node37;
        private Cell cell32;
        private Cell cell33;
        private ElementStyle elementStyle5;
        private TabItem tabItem2;
        private AdvTree advTree2;
        private DevComponents.AdvTree.ColumnHeader columnHeader4;
        private DevComponents.AdvTree.ColumnHeader columnHeader5;
        private DevComponents.AdvTree.ColumnHeader columnHeader6;
        private Node node1;
        private Node node2;
        private Node node5;
        private Node node10;
        private Cell cell7;
        private Cell cell8;
        private ElementStyle unreadEmailStyle;
        private Node node8;
        private Cell cell15;
        private Cell cell16;
        private Node node9;
        private Cell cell13;
        private Cell cell14;
        private Node node11;
        private Cell cell1;
        private Cell cell2;
        private Node node12;
        private Cell cell3;
        private Cell cell4;
        private Node node13;
        private Cell cell5;
        private Cell cell6;
        private Node node6;
        private Node node14;
        private Cell cell9;
        private Cell cell10;
        private Node node7;
        private ElementStyle elementStyle2;
        private TextBox txtParLevel;
        private Label label6;
        private TextBox txtAccDefId;
        private Label label10;
        private ComboBox CmbStat;
        private GroupBox groupBox1;
        private TextBox txtAccLevel;
        private Label label5;
        private TextBox txtParName;
        private ButtonX button_SrchAccFrom;
        private Label label7;
        private TextBox textBox_ID;
        private Label label4;
        private TextBox txtEngDes;
        private Label label2;
        private TextBox txtArbDes;
        private Label label1;
        private TextBox txtParAcc;
        private GroupBox groupBox2;
        private DoubleInput txtCreditLimit;
        private Label label14;
        private Label label8;
        private ComboBoxEx CmbPosting;
        private ComboBoxEx CmbClass;
        private Label label3;
        internal GroupBox groupBox5;
        private CheckBoxX checkBox_Credit;
        private CheckBoxX checkBox_Debit;
        private GroupBox groupBox3;
        private DoubleInput txtTDebit;
        private DoubleInput txtTCredit;
        private DoubleInput txtBalance;
        private Label label13;
        private Label label12;
        private Label label11;
        protected PanelEx panelEx2;
        protected TextBoxItem textBox_search;
        private ImageList imageList_AccTree;
        private ButtonX buttonX_Expand;
        private AdvTree treeView1;
        private ElementStyle elementStyle1;
        private ElementStyle elementStyle7;
        private ElementStyle elementStyle8;
        private ElementStyle elementStyle9;
        private ElementStyle elementStyle10;
        private ElementStyle elementStyle11;
        private ElementStyle elementStyle12;
        private ElementStyle elementStyle13;
        private ElementStyle elementStyle14;
        private ElementStyle elementStyle15;
        private ElementStyle elementStyle16;
        private ElementStyle elementStyle17;
        private ButtonX buttonX_Collaps;
        private ElementStyle elementStyle18;
        private DoubleInput txtOpenAcc;
        private Label label9;
        private Label label15;
        private LabelItem lable_Records;
        private CheckBoxX checkBoxX_Stoped;
        private TextBox txtTaxNo;
        private Label label16;
        private DoubleInput txtPerSales;
        private Label label17;
        private Label label18;
        private T_AccDef _AccDef = new T_AccDef();
        private T_AccDef _AccDefBind = new T_AccDef();
#pragma warning disable CS0414 // The field 'FrmAccDef_.ItemIndex' is assigned but its value is never used
        private int ItemIndex = 0;
#pragma warning restore CS0414 // The field 'FrmAccDef_.ItemIndex' is assigned but its value is never used
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private int LangArEn = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
#pragma warning disable CS0414 // The field 'FrmAccDef_.FlagUpdate' is assigned but its value is never used
        private string FlagUpdate = "";
#pragma warning restore CS0414 // The field 'FrmAccDef_.FlagUpdate' is assigned but its value is never used
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private List<string> pkeys = new List<string>();
        private T_AccDef data_this;
#pragma warning disable CS0169 // The field 'FrmAccDef_.T1' is never used
        private long T1;
#pragma warning restore CS0169 // The field 'FrmAccDef_.T1' is never used
        private long T2;
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
#pragma warning disable CS0414 // The field 'FrmAccDef_.indColumn' is assigned but its value is never used
        private int indColumn = 0;
#pragma warning restore CS0414 // The field 'FrmAccDef_.indColumn' is assigned but its value is never used
#pragma warning disable CS0169 // The field 'FrmAccDef_.cellValue' is never used
        private string cellValue;
#pragma warning restore CS0169 // The field 'FrmAccDef_.cellValue' is never used
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
                superTabControl_Main1.Refresh();
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
                superTabControl_Main1.Refresh();
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
        public T_AccDef DataThis
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
                    if (!VarGeneral.TString.ChkStatShow(value.SndStr, 5))
                    {
                        IfAdd = false;
                    }
                    else
                    {
                        IfAdd = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.SndStr, 6))
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.SndStr, 7) || txtAccLevel.Text == "1")
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
        public bool SetReadOnly
        {
            set
            {
                if (value)
                {
                    State = FormState.Saved;
                }
                Button_Save.Enabled = !value;
                if (State == FormState.New)
                {
                    button_SrchAccFrom.Enabled = true;
                }
                else
                {
                    button_SrchAccFrom.Enabled = false;
                }
            }
        }
        public void RefreshPKeys()
        {
            PKeys.Clear();
            Stock_DataDataContext db = new Stock_DataDataContext(VarGeneral.BranchCS);
            var qkeys = from item in db.T_AccDefs
                        orderby item.AccDef_No
                        select new
                        {
                            Code = item.AccDef_No + ""
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
        public void Fill_DGV_Main()
        {
            DGV_Main.PrimaryGrid.VirtualMode = true;
            Stock_DataDataContext db = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_AccDef> list = db.FillAccDef_2(textBox_search.TextBox.Text).ToList();
            DGV_Main.PrimaryGrid.VirtualRowCount = list.Count;
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                }
            }
            FillHDGV(list);
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
        public void FillHDGV(IEnumerable<T_AccDef> new_data_enum)
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
            DGV_Main.PrimaryGrid.DataMember = "T_AccDef";
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
        public FrmAccDef_()
        {
            InitializeComponent();this.Load += langloads;
            ADD_Controls();
            for (int i = 0; i < controls.Count; i++)
            {
                if (controls[i].GetType() != typeof(AdvTree))
                {
                    controls[i].Click += Button_Edit_Click;
                }
            }
            checkBoxX_Stoped.Click += Button_Edit_Click;
            DGV_Main.PrimaryGrid.RowHeaderWidth = 25;
            DGV_Main.PrimaryGrid.VirtualMode = true;
            DGV_Main.DataBindingComplete += DGV_Main_DataBindingComplete;
            expandableSplitter1.Click += expandableSplitter1_Click;
            DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
            DGV_Main.CellClick += DGV_Main_CellClick;
            ToolStripMenuItem_Det.Click += ToolStripMenuItem_Det_Click;
            Button_ExportTable2.Click += Button_ExportTable2_Click;
            DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
            textBox_search.InputTextChanged += TextBox_Search_InputTextChanged;
            textBox_search.ButtonCustomClick += TextBox_Search_ButtonCustomClick;
            TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
            DGV_Main.DataBindingComplete += DGV_Main_DataBindingComplete;
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
            DGV_Main.PrimaryGrid.CheckBoxes = false;
            DGV_Main.PrimaryGrid.ShowCheckBox = false;
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
            {
                txtCreditLimit.DisplayFormat = VarGeneral.DicemalMask;
                txtOpenAcc.DisplayFormat = VarGeneral.DicemalMask;
                txtTDebit.DisplayFormat = VarGeneral.DicemalMask;
                txtTCredit.DisplayFormat = VarGeneral.DicemalMask;
                txtBalance.DisplayFormat = VarGeneral.DicemalMask;
                txtPerSales.DisplayFormat = VarGeneral.DicemalMask;
            }
        }
        public void Button_First_Click(object sender, EventArgs e)
        {
            if (ContinueIfEditOrNew())
            {
                TextBox_Index.TextBox.Text = string.Concat(1);
                UpdateVcr();
                textBox_ID.Focus();
                superTabControl_Main1.Refresh();
            }
        }
        private void Button_Close_Click(object sender, EventArgs e)
        {
            Close();
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
                superTabControl_Main1.Refresh();
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
                superTabControl_Main1.Refresh();
            }
        }
        public void Button_Last_Click(object sender, EventArgs e)
        {
            if (ContinueIfEditOrNew())
            {
                TextBox_Index.TextBox.Text = Label_Count.Text;
                UpdateVcr();
                superTabControl_Main1.Refresh();
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
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmAccDef_));
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
            FillTree();
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
                buttonX_Collaps.Tooltip = "طي الكل";
                buttonX_Expand.Tooltip = "فتح الكل";
                Text = "كرت الحسابات";
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
                buttonX_Collaps.Tooltip = "Collapse all";
                buttonX_Expand.Tooltip = "Expand All";
                label4.Text = "Account NO :";
                label5.Text = "Level :";
                label1.Text = "Account Arabic NAme:";
                label2.Text = "Account English Name:";
                label7.Text = "Main Account:";
                label3.Text = "Category :";
                checkBoxX_Stoped.Text = "Block Account:";
                label8.Text = "Transfer TO:";
                groupBox5.Text = "Account Type:";
                label16.Text = "Tax Acc:";
                checkBox_Debit.Text = "Debit";
                checkBox_Credit.Text = "Credit";
                label9.Text = "Open Account:";
                label12.Text = "Debit Total:";
                label11.Text = "Credit Total:";
                label13.Text = "Balance:";
                label14.Text = "Debit Limit:";
                label17.Text = "Sales%:";
                Text = "Card of accounts";
            }
        }
        private void FrmAccDef__Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmAccDef_));
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
                    columns_Names_visible.Add("AccDef_No", new ColumnDictinary("رقم الحساب", "Account No", ifDefault: true, ""));
                    columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الإسم عربي", "Arabic Name", ifDefault: true, ""));
                    columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الإسم إنجليزي", "English Name", ifDefault: true, ""));
                    columns_Names_visible.Add("Telphone1", new ColumnDictinary("هاتف 1", "Phone 1", ifDefault: true, ""));
                    columns_Names_visible.Add("Telphone2", new ColumnDictinary("هاتف 2", "Phone 2", ifDefault: false, ""));
                    columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: true, ""));
                    columns_Names_visible.Add("City", new ColumnDictinary("المدينة", "City", ifDefault: false, ""));
                    columns_Names_visible.Add("Adders", new ColumnDictinary("العنوان", "Address", ifDefault: true, ""));
                    columns_Names_visible.Add("TaxNo", new ColumnDictinary("الرقم الضريبي", "Tax No", ifDefault: false, ""));
                }
                else
                {
                    Clear();
                    textBox_ID.Text = "";
                    TextBox_Index.TextBox.Text = "";
                }
                RefreshPKeys();
                RibunButtons();
                FillCombo();
                FillTree();
                textBox_ID.Text = PKeys.FirstOrDefault();
                UpdateVcr();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void Button_ExportTable2_Click(object sender, EventArgs e)
        {
            try
            {
                ExportExcel.ExportToExcel(DGV_Main, "تقرير كرت الحسابات");
            }
            catch
            {
            }
        }
        private void TextBox_Search_ButtonCustomClick(object sender, EventArgs e)
        {
            textBox_search.Text = "";
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
            VarGeneral.SFrmTyp = "T_AccDef4";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                textBox_ID.Text = frm.SerachNo.ToString();
            }
        }
        private void DGV_Main_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            string dataMember = panel.DataMember;
            if (dataMember != null && dataMember == "T_AccDef")
            {
                PropHIOfferPanel(panel);
            }
            T2 = DateTime.Now.Ticks;
        }
        private void PropHIOfferPanel(GridPanel panel)
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
            panel.Columns["Arb_Des"].Width = 220;
            panel.Columns["Arb_Des"].Visible = columns_Names_visible["Arb_Des"].IfDefault;
            panel.Columns["Eng_Des"].Width = 220;
            panel.Columns["Eng_Des"].Visible = columns_Names_visible["Eng_Des"].IfDefault;
            panel.Columns["AccDef_No"].Width = 150;
            panel.Columns["AccDef_No"].Visible = columns_Names_visible["AccDef_No"].IfDefault;
            panel.Columns["Telphone1"].Width = 100;
            panel.Columns["Telphone1"].Visible = columns_Names_visible["Telphone1"].IfDefault;
            panel.Columns["Telphone2"].Width = 100;
            panel.Columns["Telphone2"].Visible = columns_Names_visible["Telphone2"].IfDefault;
            panel.Columns["Mobile"].Width = 100;
            panel.Columns["Mobile"].Visible = columns_Names_visible["Mobile"].IfDefault;
            panel.Columns["City"].Width = 150;
            panel.Columns["City"].Visible = columns_Names_visible["City"].IfDefault;
            panel.Columns["Adders"].Width = 180;
            panel.Columns["Adders"].Visible = columns_Names_visible["Adders"].IfDefault;
            panel.Columns["TaxNo"].Width = 180;
            panel.Columns["TaxNo"].Visible = columns_Names_visible["TaxNo"].IfDefault;
            panel.ReadOnly = true;
        }
        private void DateTimePicker_Search_From_ValueChanged(object sender, EventArgs e)
        {
            Fill_DGV_Main();
        }
        private void TextBox_Search_InputTextChanged(object sender)
        {
            Fill_DGV_Main();
        }
        private void Button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                textBox_ID.Focus();
                if (SaveData())
                {
                    State = FormState.Saved;
                    RefreshPKeys();
                    TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(data_this.AccDef_No ?? "") + 1);
                    dbInstance = null;
                    textBox_ID_TextChanged(sender, e);
                    SetReadOnly = true;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Button_Save_Click:", error, enable: true);
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
            if (data_this == null || data_this.AccDef_No == 0.ToString() || !ifOkDelete)
            {
                return;
            }
            try
            {
                if (!string.IsNullOrEmpty(textBox_ID.Text))
                {
                    T_GdAuto _GdAuto = db.GdAutoStock();
                    if (_GdAuto != null && _GdAuto.GdAuto_Id != 0 && (_GdAuto.Acc0.ToString() == textBox_ID.Text || _GdAuto.Acc1.ToString() == textBox_ID.Text || _GdAuto.Acc2.ToString() == textBox_ID.Text || _GdAuto.Acc3.ToString() == textBox_ID.Text))
                    {
                        MessageBox.Show("عفوا\u064b ... لا يمكن حذف السجل لأنه حساب افتراضي \n Default >>> Can Not be DELETED", VarGeneral.ProdectNam);
                        return;
                    }
                }
            }
            catch
            {
            }
            try
            {
                List<T_GdAuto> q = db.T_GdAutos.Where((T_GdAuto t) => t.Acc0.ToString().StartsWith(textBox_ID.Text) || t.Acc1.ToString().StartsWith(textBox_ID.Text) || t.Acc2.ToString().StartsWith(textBox_ID.Text) || t.Acc3.ToString().StartsWith(textBox_ID.Text)).ToList();
                if (q.Count > 0)
                {
                    MessageBox.Show("عفوا\u064b ... لا يمكن حذف السجل لأنه حساب افتراضي \n Default >>> Can Not be DELETED", VarGeneral.ProdectNam);
                    return;
                }
            }
            catch
            {
            }
            T_GDDET returned = db.SelectAccDefNoByReturnNo(textBox_ID.Text.Trim());
            T_sertyp returnedServType = db.SelectSerTypeoByReturnNo(textBox_ID.Text.Trim());
            T_telmn returnedTelMn = db.SelectTelMnoByReturnNo(textBox_ID.Text.Trim());
            T_per returnedPer = db.SelectPerByReturnNo(textBox_ID.Text.Trim());
            T_SYSSETTING returnedTax = db.SelectSyssettingReturnNo(textBox_ID.Text.Trim());
            T_INVSETTING returnedTaxOption = db.SelectTaxOptionReturnNo(textBox_ID.Text.Trim());
            if (returned != null && returned.GDDET_ID != 0)
            {
                MessageBox.Show("عفوا\u064b ... لا يمكن حذف السجل لأنه مستخدم \n USED >>> Can Not be DELETED", VarGeneral.ProdectNam);
                return;
            }
            if (returnedServType != null && returnedServType.Serv_ID != 0)
            {
                MessageBox.Show("عفوا\u064b ... لا يمكن حذف السجل لأنه مستخدم \n USED >>> Can Not be DELETED", VarGeneral.ProdectNam);
                return;
            }
            if (returnedTelMn != null)
            {
                MessageBox.Show("عفوا\u064b ... لا يمكن حذف السجل لأنه مستخدم \n USED >>> Can Not be DELETED", VarGeneral.ProdectNam);
                return;
            }
            if (returnedTax != null && returnedTax.SYSSETTING_ID != 0)
            {
                MessageBox.Show("عفوا\u064b ... لا يمكن حذف السجل لأنه مستخدم \n USED >>> Can Not be DELETED", VarGeneral.ProdectNam);
                return;
            }
            if (returnedTaxOption != null && returnedTaxOption.InvSet_ID != 0)
            {
                MessageBox.Show("عفوا\u064b ... لا يمكن حذف السجل لأنه مستخدم \n USED >>> Can Not be DELETED", VarGeneral.ProdectNam);
                return;
            }
            if (returnedPer != null && returnedPer.perno != 0)
            {
                MessageBox.Show("عفوا\u064b ... لا يمكن حذف السجل لأنه مستخدم \n USED >>> Can Not be DELETED", VarGeneral.ProdectNam);
                return;
            }
            string c = "Select * from T_GDDET where AccNo LIKE '" + textBox_ID.Text.Trim() + "%'";
            List<T_GDDET> ListAcc = db.ExecuteQuery<T_GDDET>("Select * from T_GDDET where AccNo LIKE '" + textBox_ID.Text.Trim() + "%'", new object[0]).ToList();
            if (ListAcc.Count > 0)
            {
                MessageBox.Show("عفوا\u064b ... لا يمكن حذف السجل لأن هناك حسابات اخرى عليها قيود ومرتبطة بهذا الحساب \n Sorry ... can not delete the record because there are other accounts and the restrictions associated with this account", VarGeneral.ProdectNam);
                return;
            }
            if (VarGeneral.SSSLev == "E" || VarGeneral.SSSLev == "D")
            {
                T_Emp returned2 = db.SelectEmpAccDefNoByReturnNo(textBox_ID.Text.Trim());
                if (returned2 != null && !string.IsNullOrEmpty(returned2.Emp_ID))
                {
                    MessageBox.Show("عفوا\u064b ... لا يمكن حذف السجل لأنه مرتبط بموظف \n USED >>> Can Not be DELETED", VarGeneral.ProdectNam);
                    return;
                }
                T_Advance returned3 = db.SelectAdvanceAccDefNoByReturnNo(textBox_ID.Text.Trim());
                if (returned3 != null && !string.IsNullOrEmpty(returned3.Advances_ID))
                {
                    MessageBox.Show("عفوا\u064b ... لا يمكن حذف السجل لأنه مرتبط بسجل السلف \n USED >>> Can Not be DELETED", VarGeneral.ProdectNam);
                    return;
                }
            }
            data_this = db.StockAccDefWithOutBalance(DataThis.AccDef_No);
            try
            {
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [GuestAcc] = '' where [GuestAcc] = '" + textBox_ID.Text.Trim() + "'");
                    VarGeneral.Settings_Sys.GuestAcc = "";
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [GuestBoxAcc] = '' where [GuestBoxAcc] = '" + textBox_ID.Text.Trim() + "'");
                    VarGeneral.Settings_Sys.GuestBoxAcc = "";
                }
                catch
                {
                }
                db.ExecuteCommand("delete from T_AccDef where AccDef_No LIKE '" + textBox_ID.Text.Trim() + "%'");
            }
            catch (SqlException)
            {
                data_this = db.StockAccDefWithOutBalance(DataThis.AccDef_No);
                return;
            }
            catch (Exception)
            {
                data_this = db.StockAccDefWithOutBalance(DataThis.AccDef_No);
                return;
            }
            Clear();
            RefreshPKeys();
            textBox_ID.Text = PKeys.LastOrDefault();
            FillTree();
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
                txtParAcc.Focus();
                State = FormState.New;
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
                SetReadOnly = false;
            }
        }
        public void Clear()
        {
            if (State == FormState.New)
            {
                return;
            }
            State = FormState.New;
            data_this = new T_AccDef();
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
            if (State == FormState.New)
            {
                txtAccLevel.ReadOnly = true;
                txtParLevel.ReadOnly = false;
                txtParName.ReadOnly = false;
            }
            else
            {
                txtAccLevel.ReadOnly = true;
                txtParLevel.ReadOnly = true;
                txtParName.ReadOnly = true;
            }
            checkBox_Debit.Checked = true;
            SetReadOnly = false;
        }
        private T_AccDef GetData()
        {
            data_this.TaxNo = txtTaxNo.Text;
            data_this.DepreciationPercent = txtPerSales.Value;
            data_this.Arb_Des = txtArbDes.Text;
            data_this.Eng_Des = txtEngDes.Text;
            data_this.AccDef_No = textBox_ID.Text;
            data_this.Lev = int.Parse(txtAccLevel.Text);
            data_this.ParAcc = txtParAcc.Text;
            if (CmbClass.SelectedValue != null && CmbClass.SelectedValue.ToString() != "0")
            {
                data_this.AccCat = int.Parse(CmbClass.SelectedValue.ToString());
            }
            else
            {
                data_this.AccCat = null;
            }
            if (checkBox_Debit.Checked)
            {
                data_this.DC = 0;
            }
            else
            {
                data_this.DC = 1;
            }
            data_this.Sts = CmbStat.SelectedIndex;
            double value = 0.0;
            try
            {
                if (double.TryParse(txtCreditLimit.Text, out value))
                {
                    data_this.MaxLemt = value;
                }
                else
                {
                    data_this.MaxLemt = 0.0;
                }
            }
            catch
            {
                data_this.MaxLemt = 0.0;
            }
            value = 0.0;
            try
            {
                if (double.TryParse(data_this.Credit.Value.ToString(), out value))
                {
                    data_this.Credit = value;
                }
                else
                {
                    data_this.Credit = 0.0;
                }
            }
            catch
            {
                data_this.Credit = 0.0;
            }
            value = 0.0;
            try
            {
                if (double.TryParse(data_this.Debit.Value.ToString(), out value))
                {
                    data_this.Debit = value;
                }
                else
                {
                    data_this.Debit = 0.0;
                }
            }
            catch
            {
                data_this.Debit = 0.0;
            }
            value = 0.0;
            try
            {
                if (double.TryParse(data_this.Balance.Value.ToString(), out value))
                {
                    data_this.Balance = value;
                }
                else
                {
                    data_this.Balance = 0.0;
                }
            }
            catch
            {
                data_this.Balance = 0.0;
            }
            data_this.Trn = CmbPosting.SelectedIndex;
            data_this.Typ = data_this.Typ;
            data_this.City = data_this.City;
            data_this.Email = data_this.Email;
            data_this.Telphone1 = data_this.Telphone1;
            data_this.Telphone2 = data_this.Telphone2;
            data_this.Fax = data_this.Fax;
            data_this.Mobile = data_this.Mobile;
            data_this.DesPers = data_this.DesPers;
            data_this.StrAm = data_this.StrAm;
            data_this.Adders = data_this.Adders;
            data_this.Mnd = data_this.Mnd;
            data_this.Price = data_this.Price;
            data_this.StopedState = checkBoxX_Stoped.Checked;
            if (State == FormState.New)
            {
                data_this.BankComm = 0.0;
                data_this.TotPoints = 0.0;
                data_this.MaxDisCust = 0.0;
                data_this.vColNum1 = 0.0;
                data_this.vColNum2 = 0.0;
                data_this.vColStr1 = "";
                data_this.vColStr2 = "";
                data_this.vColStr3 = "";
            }
            data_this.CompanyID = 1;
            return data_this;
        }
        public void SetData(T_AccDef value)
        {
            try
            {
                State = FormState.Saved;
                Button_Save.Enabled = false;
                button_SrchAccFrom.Enabled = false;
                txtAccDefId.Text = value.AccDef_ID.ToString();
                txtEngDes.Text = value.Eng_Des;
                txtArbDes.Text = value.Arb_Des;
                txtTaxNo.Text = value.TaxNo;
                txtPerSales.Value = value.DepreciationPercent.Value;
                textBox_ID.Text = value.AccDef_No;
                txtAccLevel.Text = value.Lev.ToString();
                txtParAcc.Text = value.ParAcc;
                txtBalance.Value = value.Balance.Value;
                txtTCredit.Value = value.Credit.Value;
                txtTDebit.Value = value.Debit.Value;
                try
                {
                    if (value.AccCat.HasValue)
                    {
                        CmbClass.SelectedValue = value.AccCat.ToString();
                    }
                    else
                    {
                        CmbClass.SelectedIndex = -1;
                    }
                }
                catch
                {
                    CmbClass.SelectedIndex = -1;
                }
                if (value.DC.HasValue)
                {
                    if (value.DC.Value == 0)
                    {
                        checkBox_Debit.Checked = true;
                    }
                    else
                    {
                        checkBox_Credit.Checked = true;
                    }
                }
                CmbStat.SelectedIndex = value.Sts.Value;
                if (value.MaxLemt.HasValue)
                {
                    txtCreditLimit.Value = value.MaxLemt.Value;
                }
                else
                {
                    txtCreditLimit.Value = 0.0;
                }
                try
                {
                    txtOpenAcc.Value = db.OpenAccDebit(value.AccDef_No) - Math.Abs(db.OpenAccCredit(value.AccDef_No));
                }
                catch
                {
                    txtOpenAcc.Value = 0.0;
                }
                CmbPosting.SelectedIndex = int.Parse(VarGeneral.TString.TEmpty(string.Concat(value.Trn)));
                if (value.ParAcc != "")
                {
                    List<string> _pky = pkeys;
                    try
                    {
                        if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 76) && _pky.Count > 0)
                        {
                            _pky = new List<string>();
                            _pky = db.ExecuteQuery<string>("Select AccDef_No from T_AccDef where Lev != 4 order by AccDef_No", new object[0]).ToList();
                        }
                    }
                    catch
                    {
                        _pky = pkeys;
                    }
                    for (int iiCnt = 0; iiCnt < _pky.Count; iiCnt++)
                    {
                        _AccDefBind = db.StockAccDefWithOutBalance(_pky[iiCnt]);
                        if (_AccDefBind.AccDef_No == value.ParAcc)
                        {
                            if (RightToLeft == RightToLeft.Yes)
                            {
                                txtParName.Text = _AccDefBind.Arb_Des;
                            }
                            else if (RightToLeft == RightToLeft.No)
                            {
                                txtParName.Text = _AccDefBind.Eng_Des;
                            }
                            txtParLevel.Text = _AccDefBind.Lev.ToString();
                            break;
                        }
                    }
                }
                else
                {
                    txtParName.Text = "";
                    txtParLevel.Text = "";
                }
                try
                {
                    checkBoxX_Stoped.Checked = value.StopedState.Value;
                }
                catch
                {
                    checkBoxX_Stoped.Checked = false;
                }
                Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SetData:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void FillTree()
        {
            treeView1.Nodes.Clear();
            List<string> _pky = pkeys;
            try
            {
                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 76) && _pky.Count > 0)
                {
                    _pky = new List<string>();
                    _pky = db.ExecuteQuery<string>("Select AccDef_No from T_AccDef where Lev != 4 order by AccDef_No", new object[0]).ToList();
                }
            }
            catch
            {
                _pky = pkeys;
            }
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                List<Node> MainNodeList = new List<Node>();
                Node Child = new Node();
                for (int iiCnt = 0; iiCnt < _pky.Count; iiCnt++)
                {
                    _AccDef = db.StockAccDefWithOutBalance(_pky[iiCnt]);
                    string _ParAcc = _AccDef.ParAcc;
                    if (_ParAcc == "" || _ParAcc == null)
                    {
                        Node MainNode = new Node();
                        MainNode.Tag = _AccDef.AccDef_No;
                        MainNode.Text = _AccDef.Arb_Des;
                        MainNodeList.Add(MainNode);
                        continue;
                    }
                    Child = new Node();
                    Child.Tag = _AccDef.AccDef_No;
                    Child.Text = _AccDef.Arb_Des;
                    foreach (Node mainNode in MainNodeList)
                    {
                        if (mainNode.Tag.ToString()[0] == Child.Tag.ToString()[0])
                        {
                            FindParent(mainNode, _AccDef.ParAcc)?.Nodes.Add(Child);
                        }
                    }
                }
                foreach (Node node in MainNodeList)
                {
                    treeView1.Nodes.Add(node);
                }
            }
            else
            {
                List<Node> MainNodeList = new List<Node>();
                Node Child = new Node();
                for (int iiCnt = 0; iiCnt < _pky.Count; iiCnt++)
                {
                    _AccDef = db.StockAccDefWithOutBalance(_pky[iiCnt]);
                    string _ParAcc = _AccDef.ParAcc;
                    if (_ParAcc == "" || _ParAcc == null)
                    {
                        Node MainNode = new Node();
                        MainNode.Tag = _AccDef.AccDef_No;
                        MainNode.Text = _AccDef.Eng_Des;
                        MainNodeList.Add(MainNode);
                        continue;
                    }
                    Child = new Node();
                    Child.Tag = _AccDef.AccDef_No;
                    Child.Text = _AccDef.Eng_Des;
                    foreach (Node mainNode in MainNodeList)
                    {
                        if (mainNode.Tag.ToString()[0] == Child.Tag.ToString()[0])
                        {
                            FindParent(mainNode, _AccDef.ParAcc)?.Nodes.Add(Child);
                        }
                    }
                }
                foreach (Node node in MainNodeList)
                {
                    treeView1.Nodes.Add(node);
                }
            }
            try
            {
                treeView1.Nodes[0].Image = imageList_AccTree.Images[0];
                treeView1.Nodes[1].Image = imageList_AccTree.Images[0];
                treeView1.Nodes[2].Image = imageList_AccTree.Images[0];
                treeView1.Nodes[3].Image = imageList_AccTree.Images[0];
            }
            catch
            {
            }
        }
        private Node FindParent(Node node, string ParentNo)
        {
            if (node.Tag.ToString() == ParentNo)
            {
                return node;
            }
            if (node.Nodes.Count > 0)
            {
                foreach (Node childNode in node.Nodes)
                {
                    if (childNode.Tag.ToString() == ParentNo)
                    {
                        return childNode;
                    }
                }
                foreach (Node childNode in node.Nodes)
                {
                    if (childNode.Nodes.Count > 0)
                    {
                        Node found = FindParent(childNode, ParentNo);
                        if (found != null)
                        {
                            return found;
                        }
                    }
                }
                return null;
            }
            return null;
        }
        public void TextBox_Index_InputTextChanged(object sender)
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
        private void FillCombo()
        {
            int _CmbIndex = CmbStat.SelectedIndex;
            CmbStat.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                CmbStat.Items.Add("شغال");
                CmbStat.Items.Add("موقوف");
            }
            else
            {
                CmbStat.Items.Add("On");
                CmbStat.Items.Add("Off");
            }
            CmbStat.SelectedIndex = _CmbIndex;
            _CmbIndex = CmbPosting.SelectedIndex;
            CmbPosting.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                CmbPosting.Items.Add("-----------");
                CmbPosting.Items.Add("متاجرة");
                CmbPosting.Items.Add("أرباح وخسائر");
                CmbPosting.Items.Add("الميزانية العمومية");
            }
            else
            {
                CmbPosting.Items.Add("-----------");
                CmbPosting.Items.Add("Trading");
                CmbPosting.Items.Add("Profits and Losses");
                CmbPosting.Items.Add("General Budget");
            }
            CmbPosting.SelectedIndex = _CmbIndex;
            _CmbIndex = CmbClass.SelectedIndex;
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                List<T_AccCat> listAccCat = new List<T_AccCat>(db.T_AccCats.Select((T_AccCat item) => item).ToList());
                listAccCat.Insert(0, new T_AccCat());
                CmbClass.DataSource = listAccCat;
                CmbClass.DisplayMember = "Arb_Des";
                CmbClass.ValueMember = "AccCat_No";
                CmbClass.SelectedIndex = _CmbIndex;
            }
            else
            {
                List<T_AccCat> listAccCat = new List<T_AccCat>(db.T_AccCats.Select((T_AccCat item) => item).ToList());
                listAccCat.Insert(0, new T_AccCat());
                CmbClass.DataSource = listAccCat;
                CmbClass.DisplayMember = "Eng_Des";
                CmbClass.ValueMember = "AccCat_No";
                CmbClass.SelectedIndex = _CmbIndex;
            }
            CmbClass.SelectedIndex = _CmbIndex;
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
                T_AccDef newData = db.StockAccDef(no);
                if (newData == null || string.IsNullOrEmpty(newData.AccDef_No))
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
                    int indexA = PKeys.IndexOf(newData.AccDef_No ?? "");
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
        private void Button_Filter_Click(object sender, EventArgs e)
        {
            Fill_DGV_Main();
        }
        private void ToolStripMenuItem_Det_Click(object sender, EventArgs e)
        {
            int rowIndex = Convert.ToInt32(DGV_Main.PrimaryGrid.Tag);
            TextBox_Index.TextBox.Text = string.Concat(rowIndex + 1);
            expandableSplitter1.Expanded = true;
            ViewDetails_Click(sender, e);
        }
        private void DGV_Main_CellMouseDown(object sender, GridCellMouseEventArgs e)
        {
            DGV_Main.PrimaryGrid.Tag = e.GridCell.RowIndex;
        }
        private void DGV_Main_CellDoubleClick(object sender, GridCellDoubleClickEventArgs e)
        {
            ToolStripMenuItem_Det_Click(sender, e);
        }
        private void DGV_Main_CellClick(object sender, GridCellClickEventArgs e)
        {
            DGV_Main.PrimaryGrid.Tag = e.GridCell.RowIndex;
        }
        private void ADD_Controls()
        {
            try
            {
                controls = new List<Control>();
                controls.Add(textBox_ID);
                codeControl = textBox_ID;
                controls.Add(txtAccDefId);
                controls.Add(txtAccLevel);
                controls.Add(txtArbDes);
                controls.Add(txtTaxNo);
                controls.Add(txtPerSales);
                controls.Add(txtBalance);
                controls.Add(txtCreditLimit);
                controls.Add(checkBoxX_Stoped);
                controls.Add(txtOpenAcc);
                controls.Add(txtEngDes);
                controls.Add(txtParAcc);
                controls.Add(txtParLevel);
                controls.Add(txtParName);
                controls.Add(txtTCredit);
                controls.Add(txtTDebit);
                controls.Add(checkBox_Credit);
                controls.Add(checkBox_Debit);
                controls.Add(CmbClass);
                controls.Add(CmbPosting);
                controls.Add(CmbStat);
                controls.Add(treeView1);
            }
            catch (SqlException)
            {
            }
        }
        private bool SaveData()
        {
            try
            {
                if (!Button_Save.Enabled)
                {
                    return false;
                }
                if (State == FormState.Edit && !CanEdit)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
                if (State == FormState.New && !Button_Add.Enabled)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
                textBox_ID.Focus();
                if (textBox_ID.Text == "" || txtArbDes.Text == "" || txtEngDes.Text == "")
                {
                    MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون رقم الحساب او إسم الحساب فارغا\u064c" : "Can not be a number or name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
                try
                {
                    if (CmbClass.SelectedIndex <= 0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يجب تحديد التصنيف" : "You must select Category", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return false;
                    }
                }
                catch
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب تحديد التصنيف" : "You must select Category", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
                if (CmbPosting.SelectedIndex > 0)
                {
                    if (textBox_ID.Text == "1" || textBox_ID.Text == "2")
                    {
                        if (CmbPosting.SelectedIndex != 3)
                        {
                            MessageBox.Show((LangArEn == 0) ? "يجب ان يكون جهة ترحيل هذا الحساب إلى : الميزانية العمومية" : "Must be hand carried over to this account: the balance sheet", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            CmbPosting.Focus();
                            return false;
                        }
                    }
                    else if (textBox_ID.Text == "3")
                    {
                        if (CmbPosting.SelectedIndex != 1)
                        {
                            MessageBox.Show((LangArEn == 0) ? "يجب ان يكون جهة ترحيل هذا الحساب إلى : المتاجرة" : "We must be hand carried over to this account: trading", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            CmbPosting.Focus();
                            return false;
                        }
                    }
                    else if (textBox_ID.Text == "4")
                    {
                        if (CmbPosting.SelectedIndex != 2)
                        {
                            MessageBox.Show((LangArEn == 0) ? "يجب ان يكون جهة ترحيل هذا الحساب إلى : الأرباح والخسائر" : "We must be hand carried over to this account: profit and loss", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            CmbPosting.Focus();
                            return false;
                        }
                    }
                    else if (textBox_ID.Text.Substring(0, 1) == "1" || textBox_ID.Text.Substring(0, 1) == "2")
                    {
                        if (CmbPosting.SelectedIndex != 3)
                        {
                            try
                            {
                                T_GdAuto _GdAuto = db.GdAutoStock();
                                if (_GdAuto == null || _GdAuto.GdAuto_Id == 0)
                                {
                                    MessageBox.Show((LangArEn == 0) ? "يجب ان يكون جهة ترحيل هذا الحساب إلى : الميزانية العمومية" : "Must be hand carried over to this account: the balance sheet", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    CmbPosting.Focus();
                                    return false;
                                }
                                if (!(_GdAuto.Acc2.ToString() == textBox_ID.Text) && !(_GdAuto.Acc3.ToString() == textBox_ID.Text))
                                {
                                    MessageBox.Show((LangArEn == 0) ? "يجب ان يكون جهة ترحيل هذا الحساب إلى : الميزانية العمومية" : "Must be hand carried over to this account: the balance sheet", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    CmbPosting.Focus();
                                    return false;
                                }
                                if (CmbPosting.SelectedIndex != 1)
                                {
                                    MessageBox.Show((LangArEn == 0) ? "يجب ان يكون جهة ترحيل هذا الحساب إلى : الميزانية العمومية" : "Must be hand carried over to this account: the balance sheet", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    CmbPosting.Focus();
                                    return false;
                                }
                            }
                            catch (Exception ex2)
                            {
                                MessageBox.Show(ex2.ToString());
                                MessageBox.Show((LangArEn == 0) ? "يجب ان يكون جهة ترحيل هذا الحساب إلى : الميزانية العمومية" : "Must be hand carried over to this account: the balance sheet", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                CmbPosting.Focus();
                                return false;
                            }
                        }
                    }
                    else if (textBox_ID.Text.Substring(0, 1) == "3")
                    {
                        if (CmbPosting.SelectedIndex != 1)
                        {
                            MessageBox.Show((LangArEn == 0) ? "يجب ان يكون جهة ترحيل هذا الحساب إلى : المتاجرة" : "We must be hand carried over to this account: trading", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            CmbPosting.Focus();
                            return false;
                        }
                    }
                    else if (textBox_ID.Text.Substring(0, 1) == "4" && CmbPosting.SelectedIndex != 2)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يجب ان يكون جهة ترحيل هذا الحساب إلى : الأرباح والخسائر" : "We must be hand carried over to this account: profit and loss", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        CmbPosting.Focus();
                        return false;
                    }
                }
                GetData();
                if (State == FormState.New)
                {
                    data_this.MainSal = 0.0;
                    db.T_AccDefs.InsertOnSubmit(data_this);
                    db.SubmitChanges();
                }
                else
                {
                    try
                    {
                        T_per returnedPer = db.SelectPerByReturnNo(textBox_ID.Text.Trim());
                        if (returnedPer != null && returnedPer.perno != 0)
                        {
                            db.ExecuteCommand("update T_per set nm='" + data_this.Arb_Des + "' where Cust_no='" + textBox_ID.Text.Trim() + "'");
                        }
                    }
                    catch
                    {
                    }
                    db.Log = VarGeneral.DebugLog;
                    db.SubmitChanges(ConflictMode.ContinueOnConflict);
                }
                MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                RefreshPKeys();
                FillTree();
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
                return false;
            }
            return true;
        }
        private void txtArbDes_Enter(object sender, EventArgs e)
        {
            Framework.Keyboard.Language.Switch("Arabic");
        }
        private void txtEngDes_Enter(object sender, EventArgs e)
        {
            Framework.Keyboard.Language.Switch("English");
        }
        private void FrmAccDef_KeyDown(object sender, KeyEventArgs e)
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
        private void FrmAccDef_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void button_SrchAccFrom_Click(object sender, EventArgs e)
        {
            textBox_ID.TextChanged -= textBox_ID_TextChanged;
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_AccDef5";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                _AccDefBind = db.StockAccDefWithOutBalance(frm.SerachNo);
                txtParAcc.Text = _AccDefBind.AccDef_No;
                txtParLevel.Text = _AccDefBind.Lev.ToString();
                txtParName.Text = _AccDefBind.Arb_Des;
                int Value = _AccDefBind.Lev.Value + 1;
                txtAccLevel.Text = string.Concat(Value);
                List<T_AccDef> listFilter = (from t in db.T_AccDefs
                                             where t.ParAcc == _AccDefBind.AccDef_No
                                             orderby t.AccDef_ID
                                             select t).ToList();
                if (listFilter.Count == 0)
                {
                    if (_AccDefBind.Lev == 3)
                    {
                        textBox_ID.Text = txtParAcc.Text + "001";
                    }
                    else if (_AccDefBind.Lev == 2)
                    {
                        textBox_ID.Text = txtParAcc.Text + "1";
                    }
                    else if (_AccDefBind.Lev == 1)
                    {
                        textBox_ID.Text = txtParAcc.Text + "01";
                    }
                }
                else
                {
                    _AccDefBind = listFilter[listFilter.Count - 1];
                    string _Zero = "";
                    for (int i = 0; i < _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Length && _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Substring(i, 1) == "0"; i++)
                    {
                        _Zero += _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Substring(i, 1);
                    }
                    Value = int.Parse(_AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length)) + 1;
                    if (!string.IsNullOrEmpty(_Zero))
                    {
                        textBox_ID.Text = _AccDefBind.ParAcc + _Zero + Value;
                    }
                    else
                    {
                        textBox_ID.Text = _AccDefBind.ParAcc + Value;
                    }
                }
                try
                {
                    if (txtParAcc.Text.Substring(0, 1) == "1" || txtParAcc.Text.Substring(0, 1) == "2")
                    {
                        CmbPosting.SelectedIndex = 3;
                    }
                    else if (txtParAcc.Text.Substring(0, 1) == "3")
                    {
                        CmbPosting.SelectedIndex = 1;
                    }
                    else
                    {
                        CmbPosting.SelectedIndex = 2;
                    }
                }
                catch
                {
                    CmbPosting.SelectedIndex = 0;
                }
            }
            textBox_ID.TextChanged += textBox_ID_TextChanged;
        }
        private void Button_Save_EnabledChanged(object sender, EventArgs e)
        {
            if (Button_Save.Enabled)
            {
                CmbClass.Enabled = true;
                CmbPosting.Enabled = true;
                CmbStat.Enabled = true;
                treeView1.Enabled = false;
            }
            else
            {
                CmbClass.Enabled = false;
                CmbPosting.Enabled = false;
                CmbStat.Enabled = false;
                treeView1.Enabled = true;
            }
        }
        private void textBox_ID_Click(object sender, EventArgs e)
        {
            textBox_ID.SelectAll();
        }
        private void buttonX_Expand_Click(object sender, EventArgs e)
        {
            if (treeView1.Enabled)
            {
                treeView1.ExpandAll();
            }
        }
        private void buttonX_Collaps_Click(object sender, EventArgs e)
        {
            if (treeView1.Enabled)
            {
                treeView1.CollapseAll();
            }
        }
        private void Button_PrintTable_Click(object sender, EventArgs e)
        {
            try
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_AccDef left join T_SYSSETTING on T_SYSSETTING.SYSSETTING_ID = T_AccDef.CompanyID ";
                string Fields = "";
                Fields = "  Str(T_AccDef.AccDef_ID) , T_AccDef.AccDef_No as No , T_AccDef.Arb_Des as NmA, T_AccDef.Eng_Des as NmE,T_SYSSETTING.LogImg ";
                _RepShow.Rule = " Order by T_AccDef.AccDef_No ";
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
                        VarGeneral.vTitle = ((LangArEn == 0) ? "كرت الحسابات" : "Chart of Accounts");
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
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }
        private void treeView1_NodeClick(object sender, TreeNodeMouseEventArgs e)
        {
            try
            {
                if (!ContinueIfEditOrNew())
                {
                    return;
                }
                List<string> _pky = pkeys;
                try
                {
                    if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 76) && _pky.Count > 0)
                    {
                        _pky = new List<string>();
                        _pky = db.ExecuteQuery<string>("Select AccDef_No from T_AccDef where Lev != 4 order by AccDef_No", new object[0]).ToList();
                    }
                }
                catch
                {
                    _pky = pkeys;
                }
                string SelectedValue = e.Node.Tag.ToString();
                for (int iiCnt = 0; iiCnt < _pky.Count; iiCnt++)
                {
                    _AccDef = db.StockAccDef(_pky[iiCnt]);
                    string _AccNo = _AccDef.AccDef_No;
                    if (SelectedValue == _AccNo)
                    {
                        SetData(_AccDef);
                        break;
                    }
                }
            }
            catch
            {
            }
        }
        private void txtOpenAcc_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBalance.Value > 0.0)
                {
                    label15.Text = ((LangArEn == 0) ? "مدين" : "Debit");
                }
                else if (txtBalance.Value < 0.0)
                {
                    label15.Text = ((LangArEn == 0) ? "دائـن" : "Credit");
                }
                else
                {
                    label15.Text = "";
                }
            }
            catch
            {
                label15.Text = "";
            }
        }
        private void checkBox_Debit_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void label13_Click(object sender, EventArgs e)
        {
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }
    }
}
