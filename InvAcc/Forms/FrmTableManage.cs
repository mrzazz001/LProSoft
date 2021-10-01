using ControlHosting;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using DevComponents.Tree;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmTableManage : Form
    { void avs(int arln)

{ 
}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private int LangArEn = 0;
        private Stock_DataDataContext dbInstance;
        private List<T_SYSSETTING> listSysSetting = new List<T_SYSSETTING>();
        private T_SYSSETTING _SysSetting = new T_SYSSETTING();
        private List<T_Room> listTableFamily = new List<T_Room>();
        private T_Room _TableFamily = new T_Room();
        private List<T_Room> listTableBoys = new List<T_Room>();
        private T_Room _TableBoys = new T_Room();
        private List<T_Room> listTableOut = new List<T_Room>();
        private T_Room _TableOut = new T_Room();
        private List<T_Room> listTableOther = new List<T_Room>();
        private T_Room _TableOther = new T_Room();
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
        private Panel panel_Head;
        private Label labelZoom;
        private TrackBar trackBar1;
        private System.Windows.Forms. SaveFileDialog saveFileDialog1;
        private PrintDocument printDocument1;
        private PrintPreviewDialog printPreviewDialog1;
        internal TreeGX TreeGX_Tables;
        private NodeConnector nodeConnector4;
        internal Node Node_TablesMap;
        internal Node Node_FamilyTable;
        internal DevComponents.Tree.ElementStyle ElementStyle4;
        internal Node Node_ExtrnalTable;
        private DevComponents.Tree.ElementStyle elementStyle22;
        internal Node Node_OtherTable;
        internal DevComponents.Tree.ElementStyle ElementStyle7;
        internal Node Node_BoysTable;
        private DevComponents.Tree.ElementStyle elementStyle19;
        internal DevComponents.Tree.ElementStyle ElementStyle5;
        internal NodeConnector NodeConnector2;
        internal DevComponents.Tree.ElementStyle ElementStyle1;
        internal NodeConnector NodeConnector1;
        internal NodeConnector NodeConnector3;
        internal DevComponents.Tree.ElementStyle ElementStyle3;
        internal DevComponents.Tree.ElementStyle ElementStyle2;
        internal DevComponents.Tree.ElementStyle ElementStyle6;
        private DevComponents.Tree.ElementStyle elementStyle8;
        private DevComponents.Tree.ElementStyle elementStyle9;
        private DevComponents.Tree.ElementStyle elementStyle10;
        private DevComponents.Tree.ElementStyle elementStyle11;
        private DevComponents.Tree.ElementStyle elementStyle12;
        private DevComponents.Tree.ElementStyle elementStyle13;
        private DevComponents.Tree.ElementStyle elementStyle14;
        private DevComponents.Tree.ElementStyle elementStyle15;
        private DevComponents.Tree.ElementStyle elementStyle16;
        private DevComponents.Tree.ElementStyle elementStyle17;
        private DevComponents.Tree.ElementStyle elementStyle18;
        private DevComponents.Tree.ElementStyle elementStyle20;
        private DevComponents.Tree.ElementStyle elementStyle21;
        private DevComponents.Tree.ElementStyle elementStyle23;
        private DevComponents.Tree.ElementStyle elementStyle24;
        private DevComponents.Tree.ElementStyle elementStyle25;
        private DevComponents.Tree.ElementStyle elementStyle26;
        private DevComponents.Tree.ElementStyle elementStyle27;
        private DevComponents.Tree.ElementStyle elementStyle28;
        private DevComponents.Tree.ElementStyle elementStyle29;
        private DevComponents.Tree.ElementStyle elementStyle30;
        private DevComponents.Tree.ElementStyle elementStyle31;
        private ButtonX buttonX_Print;
        private ButtonX buttonX_Save;
        private EmployeeCard employeeCard1;
        private ExpandablePanel expandablePanel_Table;
        private IntegerInput txtTablesBoys;
        private IntegerInput txtTablesOut;
        private IntegerInput txtTablesOther;
        private Label label48;
        private Label label51;
        private Label label52;
        private Label label54;
        private IntegerInput txtTablesFamily;
        private ButtonX buttonX_SaveTable;
        private ButtonX Button_Back;
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
        public FrmTableManage()
        {
            InitializeComponent();this.Load += langloads;
            trackBar1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trackBar1.AutoSize = false;
            trackBar1.LargeChange = 50;
            trackBar1.Location = new Point(216, 4);
            trackBar1.Maximum = 400;
            trackBar1.Minimum = 20;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(300, 24);
            trackBar1.SmallChange = 10;
            trackBar1.TabIndex = 0;
            trackBar1.TickStyle = TickStyle.None;
            trackBar1.Value = 100;
            trackBar1.ValueChanged += trackBar1_ValueChanged;
        }
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            TreeGX_Tables.Zoom = (float)trackBar1.Value / 100f;
            labelZoom.Text = trackBar1.Value + "%";
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                label51.Text = "طاولات العــوائل :";
                label52.Text = "طاولات الشباب :";
                label48.Text = "طاولات خارجية :";
                label54.Text = "طاولات آخـــرى :";
                buttonX_SaveTable.Text = "تعـــيين  F2";
                Button_Back.Text = "تـراجـــع  Esc";
                Node_TablesMap.Text = "طــاولات المطعــم";
                buttonX_Save.Text = "حفظ كصورة  F2";
                buttonX_Print.Text = "طباعة  F5";
                Text = "إدارة الطــــاولات";
            }
            else
            {
                label51.Text = "Family Tables :";
                label52.Text = "Boys Tables :";
                label48.Text = "Extrnal Tables :";
                label54.Text = "Other Tables :";
                buttonX_SaveTable.Text = "Ok  F2";
                Button_Back.Text = "Back  Esc";
                Node_TablesMap.Text = "Resturant Tables";
                buttonX_Save.Text = "Save as  F2";
                buttonX_Print.Text = "Print  F5";
                Text = "Tables Management";
            }
        }
        private void FrmTableManage_Load(object sender, EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmTableManage));
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                Language.ChangeLanguage("ar-SA", this, resources);
                LangArEn = 0;
            }
            else
            {
                Language.ChangeLanguage("en", this, resources);
                LangArEn = 1;
                buttonX_Print.Text = "Print  F5";
                buttonX_Save.Text = "save image  F2";
                buttonX_SaveTable.Text = "Ok  F2";
                Button_Back.Text = "Back  F2";
                expandablePanel_Table.TitleText = "Set Resturant Tables";
                Node_TablesMap.Text = "Tables of Resturant";
                Node_FamilyTable.Text = "Family Tables";
                Node_BoysTable.Text = "Boys Tables";
                Node_ExtrnalTable.Text = "Extrnal Tables";
                Node_OtherTable.Text = "Other Table";
                Text = "Tables Management";
            }
            RibunButtons();
            FillTable();
            expandablePanel_Table.TitleHeight = 50;
        }
        private void BindData()
        {
            try
            {
                txtTablesFamily.ValueChanged -= txtTablesFamily_ValueChanged;
                txtTablesBoys.ValueChanged -= txtTablesBoys_ValueChanged;
                txtTablesOut.ValueChanged -= txtTablesOut_ValueChanged;
                txtTablesOther.ValueChanged -= txtTablesOther_ValueChanged;
                try
                {
                    txtTablesFamily.Value = _SysSetting.TableFamily.Value;
                }
                catch
                {
                    txtTablesFamily.Value = 0;
                }
                try
                {
                    txtTablesBoys.Value = _SysSetting.TableBoys.Value;
                }
                catch
                {
                    txtTablesBoys.Value = 0;
                }
                try
                {
                    txtTablesOut.Value = _SysSetting.TableExtrnal.Value;
                }
                catch
                {
                    txtTablesOut.Value = 0;
                }
                try
                {
                    txtTablesOther.Value = _SysSetting.TableOther.Value;
                }
                catch
                {
                    txtTablesOther.Value = 0;
                }
                txtTablesFamily.ValueChanged += txtTablesFamily_ValueChanged;
                txtTablesBoys.ValueChanged += txtTablesBoys_ValueChanged;
                txtTablesOut.ValueChanged += txtTablesOut_ValueChanged;
                txtTablesOther.ValueChanged += txtTablesOther_ValueChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void FillTable()
        {
            try
            {
                Node_FamilyTable.Nodes.Clear();
                Node_BoysTable.Nodes.Clear();
                Node_ExtrnalTable.Nodes.Clear();
                Node_OtherTable.Nodes.Clear();
                List<T_Room> q = new List<T_Room>();
                q = db.FillTable_2(1).ToList();
                for (int i = 0; i < q.Count; i++)
                {
                    Node NewNode = new Node();
                    NewNode.Name = "FamilyNode" + q[i].RomeNo;
                    NewNode.Style = elementStyle15;
                    EmployeeCard newCard = new EmployeeCard();
                    newCard.Size = new Size(277, 30);
                    newCard.Controls["labelName"].Text = ((LangArEn == 0) ? "طاولة رقم : " : "Table No : ") + q[i].RomeNo;
                    newCard.Controls["labelName"].Tag = q[i].ID.ToString();
                    (newCard.Controls["TextBox_Chair"] as IntegerInput).Value = q[i].chair.Value;
                    newCard.Controls["textBox_Sts"].Text = ((LangArEn != 0) ? (q[i].Stop.Value ? "OFF" : (q[i].reserved.Value ? "reserved" : (q[i].RomeStatus.Value ? "Busy" : "Empty"))) : (q[i].Stop.Value ? "معطل\u0651ة" : (q[i].reserved.Value ? "محجوزة" : (q[i].RomeStatus.Value ? "مشغولة" : "فارغة"))));
                    newCard.Controls["textBox_Waiter"].Text = ((!q[i].waiterNo.HasValue) ? ((LangArEn == 0) ? "لا يوجد نادل" : "No Waiter") : ((LangArEn == 0) ? q[i].T_Waiter.Arb_Des : q[i].T_Waiter.Eng_Des));
                    newCard.Controls["TextBox_Note"].Text = q[i].Note;
                    (newCard.Controls["checkBox_OFF"] as CheckBoxX).Checked = false;
                    (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Checked = false;
                    (newCard.Controls["checkBox_Clear"] as CheckBoxX).Checked = false;
                    newCard.Controls["buttonX_Transfer"].Visible = false;
                    if (newCard.Controls["textBox_Sts"].Text.Trim() == "مشغولة" || newCard.Controls["textBox_Sts"].Text.Trim() == "Busy")
                    {
                        (newCard.Controls["checkBox_OFF"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Enabled = false;
                        newCard.Controls["buttonX_Transfer"].Visible = true;
                    }
                    else if (newCard.Controls["textBox_Sts"].Text.Trim() == "محجوزة" || newCard.Controls["textBox_Sts"].Text.Trim() == "reserved")
                    {
                        (newCard.Controls["checkBox_OFF"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_Clear"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Checked = true;
                    }
                    else if (newCard.Controls["textBox_Sts"].Text.Trim() == "معطل\u0651ة" || newCard.Controls["textBox_Sts"].Text.Trim() == "OFF")
                    {
                        (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_Clear"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_OFF"] as CheckBoxX).Checked = true;
                    }
                    else
                    {
                        (newCard.Controls["checkBox_Clear"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_OFF"] as CheckBoxX).Enabled = true;
                        (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Enabled = true;
                    }
                    newCard.Controls["buttonX_Save"].Tag = q[i].ID.ToString();
                    NewNode.HostedControl = newCard;
                    if (LangArEn == 1)
                    {
                        (newCard.Controls["labelChair"] as Label).Text = "Chaires";
                        (newCard.Controls["labelSts"] as Label).Text = "Status";
                        (newCard.Controls["labelWaiter"] as Label).Text = "Waiter";
                        (newCard.Controls["labelNote"] as Label).Text = "Note";
                        (newCard.Controls["buttonX_Save"] as ButtonX).Text = "Save";
                        (newCard.Controls["buttonX_Transfer"] as ButtonX).Text = "Transfer";
                        (newCard.Controls["checkBox_Clear"] as CheckBoxX).Text = "emptying";
                        (newCard.Controls["checkBox_OFF"] as CheckBoxX).Text = "OFF";
                        (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Text = "Reseved";
                    }
                    Node_FamilyTable.Nodes.AddRange(new Node[1]
                    {
                        NewNode
                    });
                }
                q = db.FillTable_2(2).ToList();
                for (int i = 0; i < q.Count; i++)
                {
                    Node NewNode = new Node();
                    NewNode.Name = "BoyNode" + q[i].RomeNo;
                    NewNode.Style = elementStyle19;
                    EmployeeCard newCard = new EmployeeCard();
                    newCard.Size = new Size(277, 30);
                    newCard.Controls["labelName"].Text = ((LangArEn == 0) ? "طاولة رقم : " : "Table No : ") + q[i].RomeNo;
                    newCard.Controls["labelName"].Tag = q[i].ID.ToString();
                    (newCard.Controls["TextBox_Chair"] as IntegerInput).Value = q[i].chair.Value;
                    newCard.Controls["textBox_Sts"].Text = ((LangArEn != 0) ? (q[i].Stop.Value ? "OFF" : (q[i].reserved.Value ? "reserved" : (q[i].RomeStatus.Value ? "Busy" : "Empty"))) : (q[i].Stop.Value ? "معطل\u0651ة" : (q[i].reserved.Value ? "محجوزة" : (q[i].RomeStatus.Value ? "مشغولة" : "فارغة"))));
                    newCard.Controls["textBox_Waiter"].Text = ((!q[i].waiterNo.HasValue) ? ((LangArEn == 0) ? "لا يوجد نادل" : "No Waiter") : ((LangArEn == 0) ? q[i].T_Waiter.Arb_Des : q[i].T_Waiter.Eng_Des));
                    newCard.Controls["TextBox_Note"].Text = q[i].Note;
                    (newCard.Controls["checkBox_OFF"] as CheckBoxX).Checked = false;
                    (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Checked = false;
                    (newCard.Controls["checkBox_Clear"] as CheckBoxX).Checked = false;
                    newCard.Controls["buttonX_Transfer"].Visible = false;
                    if (newCard.Controls["textBox_Sts"].Text.Trim() == "مشغولة" || newCard.Controls["textBox_Sts"].Text.Trim() == "Busy")
                    {
                        (newCard.Controls["checkBox_OFF"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Enabled = false;
                        newCard.Controls["buttonX_Transfer"].Visible = true;
                    }
                    else if (newCard.Controls["textBox_Sts"].Text.Trim() == "محجوزة" || newCard.Controls["textBox_Sts"].Text.Trim() == "reserved")
                    {
                        (newCard.Controls["checkBox_OFF"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_Clear"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Checked = true;
                    }
                    else if (newCard.Controls["textBox_Sts"].Text.Trim() == "معطل\u0651ة" || newCard.Controls["textBox_Sts"].Text.Trim() == "OFF")
                    {
                        (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_Clear"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_OFF"] as CheckBoxX).Checked = true;
                    }
                    else
                    {
                        (newCard.Controls["checkBox_Clear"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_OFF"] as CheckBoxX).Enabled = true;
                        (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Enabled = true;
                    }
                    newCard.Controls["buttonX_Save"].Tag = q[i].ID.ToString();
                    NewNode.HostedControl = newCard;
                    if (LangArEn == 1)
                    {
                        (newCard.Controls["labelChair"] as Label).Text = "Chaires";
                        (newCard.Controls["labelSts"] as Label).Text = "Status";
                        (newCard.Controls["labelWaiter"] as Label).Text = "Waiter";
                        (newCard.Controls["labelNote"] as Label).Text = "Note";
                        (newCard.Controls["buttonX_Save"] as ButtonX).Text = "Save";
                        (newCard.Controls["buttonX_Transfer"] as ButtonX).Text = "Transfer";
                        (newCard.Controls["checkBox_Clear"] as CheckBoxX).Text = "emptying";
                        (newCard.Controls["checkBox_OFF"] as CheckBoxX).Text = "OFF";
                        (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Text = "Reseved";
                    }
                    Node_BoysTable.Nodes.AddRange(new Node[1]
                    {
                        NewNode
                    });
                }
                q = db.FillTable_2(3).ToList();
                for (int i = 0; i < q.Count; i++)
                {
                    Node NewNode = new Node();
                    NewNode.Name = "ExtrnalNode" + q[i].RomeNo;
                    NewNode.Style = elementStyle23;
                    EmployeeCard newCard = new EmployeeCard();
                    newCard.Size = new Size(277, 30);
                    newCard.Controls["labelName"].Text = ((LangArEn == 0) ? "طاولة رقم : " : "Table No : ") + q[i].RomeNo;
                    newCard.Controls["labelName"].Tag = q[i].ID.ToString();
                    (newCard.Controls["TextBox_Chair"] as IntegerInput).Value = q[i].chair.Value;
                    newCard.Controls["textBox_Sts"].Text = ((LangArEn != 0) ? (q[i].Stop.Value ? "OFF" : (q[i].reserved.Value ? "reserved" : (q[i].RomeStatus.Value ? "Busy" : "Empty"))) : (q[i].Stop.Value ? "معطل\u0651ة" : (q[i].reserved.Value ? "محجوزة" : (q[i].RomeStatus.Value ? "مشغولة" : "فارغة"))));
                    newCard.Controls["textBox_Waiter"].Text = ((!q[i].waiterNo.HasValue) ? ((LangArEn == 0) ? "لا يوجد نادل" : "No Waiter") : ((LangArEn == 0) ? q[i].T_Waiter.Arb_Des : q[i].T_Waiter.Eng_Des));
                    newCard.Controls["TextBox_Note"].Text = q[i].Note;
                    (newCard.Controls["checkBox_OFF"] as CheckBoxX).Checked = false;
                    (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Checked = false;
                    (newCard.Controls["checkBox_Clear"] as CheckBoxX).Checked = false;
                    newCard.Controls["buttonX_Transfer"].Visible = false;
                    if (newCard.Controls["textBox_Sts"].Text.Trim() == "مشغولة" || newCard.Controls["textBox_Sts"].Text.Trim() == "Busy")
                    {
                        (newCard.Controls["checkBox_OFF"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Enabled = false;
                        newCard.Controls["buttonX_Transfer"].Visible = true;
                    }
                    else if (newCard.Controls["textBox_Sts"].Text.Trim() == "محجوزة" || newCard.Controls["textBox_Sts"].Text.Trim() == "reserved")
                    {
                        (newCard.Controls["checkBox_OFF"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_Clear"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Checked = true;
                    }
                    else if (newCard.Controls["textBox_Sts"].Text.Trim() == "معطل\u0651ة" || newCard.Controls["textBox_Sts"].Text.Trim() == "OFF")
                    {
                        (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_Clear"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_OFF"] as CheckBoxX).Checked = true;
                    }
                    else
                    {
                        (newCard.Controls["checkBox_Clear"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_OFF"] as CheckBoxX).Enabled = true;
                        (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Enabled = true;
                    }
                    newCard.Controls["buttonX_Save"].Tag = q[i].ID.ToString();
                    NewNode.HostedControl = newCard;
                    if (LangArEn == 1)
                    {
                        (newCard.Controls["labelChair"] as Label).Text = "Chaires";
                        (newCard.Controls["labelSts"] as Label).Text = "Status";
                        (newCard.Controls["labelWaiter"] as Label).Text = "Waiter";
                        (newCard.Controls["labelNote"] as Label).Text = "Note";
                        (newCard.Controls["buttonX_Save"] as ButtonX).Text = "Save";
                        (newCard.Controls["buttonX_Transfer"] as ButtonX).Text = "Transfer";
                        (newCard.Controls["checkBox_Clear"] as CheckBoxX).Text = "emptying";
                        (newCard.Controls["checkBox_OFF"] as CheckBoxX).Text = "OFF";
                        (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Text = "Reseved";
                    }
                    Node_ExtrnalTable.Nodes.AddRange(new Node[1]
                    {
                        NewNode
                    });
                }
                q = db.FillTable_2(4).ToList();
                for (int i = 0; i < q.Count; i++)
                {
                    Node NewNode = new Node();
                    NewNode.Name = "OtherNode" + q[i].RomeNo;
                    NewNode.Style = elementStyle22;
                    EmployeeCard newCard = new EmployeeCard();
                    newCard.Size = new Size(277, 30);
                    newCard.Controls["labelName"].Text = ((LangArEn == 0) ? "طاولة رقم : " : "Table No : ") + q[i].RomeNo;
                    newCard.Controls["labelName"].Tag = q[i].ID.ToString();
                    (newCard.Controls["TextBox_Chair"] as IntegerInput).Value = q[i].chair.Value;
                    newCard.Controls["textBox_Sts"].Text = ((LangArEn != 0) ? (q[i].Stop.Value ? "OFF" : (q[i].reserved.Value ? "reserved" : (q[i].RomeStatus.Value ? "Busy" : "Empty"))) : (q[i].Stop.Value ? "معطل\u0651ة" : (q[i].reserved.Value ? "محجوزة" : (q[i].RomeStatus.Value ? "مشغولة" : "فارغة"))));
                    newCard.Controls["textBox_Waiter"].Text = ((!q[i].waiterNo.HasValue) ? ((LangArEn == 0) ? "لا يوجد نادل" : "No Waiter") : ((LangArEn == 0) ? q[i].T_Waiter.Arb_Des : q[i].T_Waiter.Eng_Des));
                    newCard.Controls["TextBox_Note"].Text = q[i].Note;
                    (newCard.Controls["checkBox_OFF"] as CheckBoxX).Checked = false;
                    (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Checked = false;
                    (newCard.Controls["checkBox_Clear"] as CheckBoxX).Checked = false;
                    newCard.Controls["buttonX_Transfer"].Visible = false;
                    if (newCard.Controls["textBox_Sts"].Text.Trim() == "مشغولة" || newCard.Controls["textBox_Sts"].Text.Trim() == "Busy")
                    {
                        (newCard.Controls["checkBox_OFF"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Enabled = false;
                        newCard.Controls["buttonX_Transfer"].Visible = true;
                    }
                    else if (newCard.Controls["textBox_Sts"].Text.Trim() == "محجوزة" || newCard.Controls["textBox_Sts"].Text.Trim() == "reserved")
                    {
                        (newCard.Controls["checkBox_OFF"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_Clear"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Checked = true;
                    }
                    else if (newCard.Controls["textBox_Sts"].Text.Trim() == "معطل\u0651ة" || newCard.Controls["textBox_Sts"].Text.Trim() == "OFF")
                    {
                        (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_Clear"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_OFF"] as CheckBoxX).Checked = true;
                    }
                    else
                    {
                        (newCard.Controls["checkBox_Clear"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_OFF"] as CheckBoxX).Enabled = true;
                        (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Enabled = true;
                    }
                    newCard.Controls["buttonX_Save"].Tag = q[i].ID.ToString();
                    NewNode.HostedControl = newCard;
                    if (LangArEn == 1)
                    {
                        (newCard.Controls["labelChair"] as Label).Text = "Chaires";
                        (newCard.Controls["labelSts"] as Label).Text = "Status";
                        (newCard.Controls["labelWaiter"] as Label).Text = "Waiter";
                        (newCard.Controls["labelNote"] as Label).Text = "Note";
                        (newCard.Controls["buttonX_Save"] as ButtonX).Text = "Save";
                        (newCard.Controls["buttonX_Transfer"] as ButtonX).Text = "Transfer";
                        (newCard.Controls["checkBox_Clear"] as CheckBoxX).Text = "emptying";
                        (newCard.Controls["checkBox_OFF"] as CheckBoxX).Text = "OFF";
                        (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Text = "Reseved";
                    }
                    Node_OtherTable.Nodes.AddRange(new Node[1]
                    {
                        NewNode
                    });
                }
                Node_FamilyTable.Expanded = false;
                Node_BoysTable.Expanded = false;
                Node_ExtrnalTable.Expanded = false;
                Node_OtherTable.Expanded = false;
                Refresh();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FillTable:", error, enable: true);
                Node_FamilyTable.Nodes.Clear();
                Node_BoysTable.Nodes.Clear();
                Node_ExtrnalTable.Nodes.Clear();
                Node_OtherTable.Nodes.Clear();
                Refresh();
            }
        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Point p = new Point((e.PageBounds.Width - TreeGX_Tables.TreeSize.Width) / 2, (e.PageBounds.Height - TreeGX_Tables.TreeSize.Height) / 2);
            if (p.X > 0 && p.Y > 0)
            {
                e.Graphics.TranslateTransform(p.X, p.Y, MatrixOrder.Append);
            }
            TreeGX_Tables.PaintTo(e.Graphics, background: false, e.PageBounds);
        }
        private void buttonX_Save_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            Bitmap bmp = new Bitmap(TreeGX_Tables.TreeSize.Width, TreeGX_Tables.TreeSize.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                TreeGX_Tables.PaintTo(g, background: true, Rectangle.Empty);
            }
            bmp.Save(saveFileDialog1.FileName, ImageFormat.Png);
        }
        private void buttonX_Print_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Bounds = base.Bounds;
            printPreviewDialog1.ShowDialog();
        }
        private void FrmTableManage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (expandablePanel_Table.Expanded)
                {
                    buttonX_SaveTable_Click(sender, e);
                }
                else
                {
                    buttonX_Save_Click(sender, e);
                }
            }
            else if (e.KeyCode == Keys.F5)
            {
                buttonX_Print_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (expandablePanel_Table.Expanded)
                {
                    Button_Back_Click(sender, e);
                }
                else
                {
                    Close();
                }
            }
        }
        private void expandablePanel_Table_ExpandedChanged(object sender, ExpandedChangeEventArgs e)
        {
            if (expandablePanel_Table.Expanded)
            {
                Node_FamilyTable.Expanded = false;
                Node_BoysTable.Expanded = false;
                Node_ExtrnalTable.Expanded = false;
                Node_OtherTable.Expanded = false;
                TreeGX_Tables.Enabled = false;
                panel_Head.Enabled = false;
                _SysSetting = db.SystemSettingStock();
                BindData();
                listTableFamily = db.FillTable_2(1).ToList();
                listTableBoys = db.FillTable_2(2).ToList();
                listTableOut = db.FillTable_2(3).ToList();
                listTableOther = db.FillTable_2(4).ToList();
            }
            else
            {
                TreeGX_Tables.Enabled = true;
                panel_Head.Enabled = true;
            }
        }
        private void txtTablesFamily_ValueChanged(object sender, EventArgs e)
        {
            txtTablesFamily.ValueChanged -= txtTablesFamily_ValueChanged;
            try
            {
                List<T_Room> q = (from t in db.T_Rooms
                                  where t.RomeStatus.Value
                                  where t.Type == (int?)1
                                  select t).ToList();
                if (q.Count > 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "لن تستطيع تغيير عدد طاولات النظام حتى تقوم بإغلاق جميع الطلبات والحجوزات التي عليها" : "You can not change the number of system tables until you close all Orders and the reservations it", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtTablesFamily.Value = _SysSetting.TableFamily.Value;
                    return;
                }
            }
            catch
            {
                txtTablesFamily.Value = _SysSetting.TableFamily.Value;
                return;
            }
            txtTablesFamily.ValueChanged += txtTablesFamily_ValueChanged;
        }
        private void txtTablesBoys_ValueChanged(object sender, EventArgs e)
        {
            txtTablesBoys.ValueChanged -= txtTablesBoys_ValueChanged;
            try
            {
                List<T_Room> q = (from t in db.T_Rooms
                                  where t.RomeStatus.Value
                                  where t.Type == (int?)2
                                  select t).ToList();
                if (q.Count > 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "لن تستطيع تغيير عدد طاولات النظام حتى تقوم بإغلاق جميع الطلبات والحجوزات التي عليها" : "You can not change the number of system tables until you close all Orders and the reservations it", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtTablesBoys.Value = _SysSetting.TableBoys.Value;
                    return;
                }
            }
            catch
            {
                txtTablesBoys.Value = _SysSetting.TableBoys.Value;
                return;
            }
            txtTablesBoys.ValueChanged += txtTablesBoys_ValueChanged;
        }
        private void txtTablesOut_ValueChanged(object sender, EventArgs e)
        {
            txtTablesOut.ValueChanged -= txtTablesOut_ValueChanged;
            try
            {
                List<T_Room> q = (from t in db.T_Rooms
                                  where t.RomeStatus.Value
                                  where t.Type == (int?)3
                                  select t).ToList();
                if (q.Count > 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "لن تستطيع تغيير عدد طاولات النظام حتى تقوم بإغلاق جميع الطلبات والحجوزات التي عليها" : "You can not change the number of system tables until you close all Orders and the reservations it", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtTablesOut.Value = _SysSetting.TableExtrnal.Value;
                    return;
                }
            }
            catch
            {
                txtTablesOut.Value = _SysSetting.TableExtrnal.Value;
                return;
            }
            txtTablesOut.ValueChanged += txtTablesOut_ValueChanged;
        }
        private void txtTablesOther_ValueChanged(object sender, EventArgs e)
        {
            txtTablesOut.ValueChanged -= txtTablesOut_ValueChanged;
            try
            {
                List<T_Room> q = (from t in db.T_Rooms
                                  where t.RomeStatus.Value
                                  where t.Type == (int?)4
                                  select t).ToList();
                if (q.Count > 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "لن تستطيع تغيير عدد طاولات النظام حتى تقوم بإغلاق جميع الطلبات والحجوزات التي عليها" : "You can not change the number of system tables until you close all Orders and the reservations it", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtTablesOut.Value = _SysSetting.TableExtrnal.Value;
                    return;
                }
            }
            catch
            {
                txtTablesOut.Value = _SysSetting.TableExtrnal.Value;
                return;
            }
            txtTablesOut.ValueChanged += txtTablesOut_ValueChanged;
        }
        private void buttonX_SaveTable_Click(object sender, EventArgs e)
        {
            SaveData();
        }
        private void SaveData()
        {
            try
            {
                if (_SysSetting.TableFamily != txtTablesFamily.Value)
                {
                    for (int i = 0; i < listTableFamily.Count; i++)
                    {
                        _TableFamily = new T_Room();
                        _TableFamily = listTableFamily[i];
                        db.T_Rooms.DeleteOnSubmit(_TableFamily);
                        db.SubmitChanges();
                    }
                    for (int i = 0; i < txtTablesFamily.Value; i++)
                    {
                        _TableFamily = new T_Room();
                        _TableFamily.RomeNo = i + 1;
                        _TableFamily.RomeStatus = false;
                        _TableFamily.Type = 1;
                        _TableFamily.Stop = false;
                        _TableFamily.reserved = false;
                        _TableFamily.chair = 1;
                        _TableFamily.Note = "";
                        db.T_Rooms.InsertOnSubmit(_TableFamily);
                        db.SubmitChanges();
                    }
                }
                if (_SysSetting.TableBoys != txtTablesBoys.Value)
                {
                    for (int i = 0; i < listTableBoys.Count; i++)
                    {
                        _TableBoys = new T_Room();
                        _TableBoys = listTableBoys[i];
                        db.T_Rooms.DeleteOnSubmit(_TableBoys);
                        db.SubmitChanges();
                    }
                    for (int i = 0; i < txtTablesBoys.Value; i++)
                    {
                        _TableBoys = new T_Room();
                        _TableBoys.RomeNo = i + 1;
                        _TableBoys.RomeStatus = false;
                        _TableBoys.Type = 2;
                        _TableBoys.Stop = false;
                        _TableBoys.reserved = false;
                        _TableBoys.chair = 1;
                        _TableBoys.Note = "";
                        db.T_Rooms.InsertOnSubmit(_TableBoys);
                        db.SubmitChanges();
                    }
                }
                if (_SysSetting.TableExtrnal != txtTablesOut.Value)
                {
                    for (int i = 0; i < listTableOut.Count; i++)
                    {
                        _TableOut = new T_Room();
                        _TableOut = listTableOut[i];
                        db.T_Rooms.DeleteOnSubmit(_TableOut);
                        db.SubmitChanges();
                    }
                    for (int i = 0; i < txtTablesOut.Value; i++)
                    {
                        _TableOut = new T_Room();
                        _TableOut.RomeNo = i + 1;
                        _TableOut.RomeStatus = false;
                        _TableOut.Type = 3;
                        _TableOut.Stop = false;
                        _TableOut.reserved = false;
                        _TableOut.chair = 1;
                        _TableOut.Note = "";
                        db.T_Rooms.InsertOnSubmit(_TableOut);
                        db.SubmitChanges();
                    }
                }
                if (_SysSetting.TableOther != txtTablesOther.Value)
                {
                    for (int i = 0; i < listTableOther.Count; i++)
                    {
                        _TableOther = new T_Room();
                        _TableOther = listTableOther[i];
                        db.T_Rooms.DeleteOnSubmit(_TableOther);
                        db.SubmitChanges();
                    }
                    for (int i = 0; i < txtTablesOther.Value; i++)
                    {
                        _TableOther = new T_Room();
                        _TableOther.RomeNo = i + 1;
                        _TableOther.RomeStatus = false;
                        _TableOther.Type = 4;
                        _TableOther.Stop = false;
                        _TableOther.reserved = false;
                        _TableOther.chair = 1;
                        _TableOther.Note = "";
                        db.T_Rooms.InsertOnSubmit(_TableOther);
                        db.SubmitChanges();
                    }
                }
                _SysSetting.TableFamily = txtTablesFamily.Value;
                _SysSetting.TableBoys = txtTablesBoys.Value;
                _SysSetting.TableExtrnal = txtTablesOut.Value;
                _SysSetting.TableOther = txtTablesOther.Value;
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                MessageBox.Show((LangArEn == 0) ? "لقد تم تعيين طــاولات النظام بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                try
                {
                    Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
                    VarGeneral.Settings_Sys = new T_SYSSETTING();
                    VarGeneral.Settings_Sys = dbc.SystemSettingStock();
                }
                catch
                {
                    Close();
                }
                Button_Back_Click(null, null);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Save:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void Button_Back_Click(object sender, EventArgs e)
        {
            expandablePanel_Table.Expanded = false;
            FillTable();
        }
    }
}
