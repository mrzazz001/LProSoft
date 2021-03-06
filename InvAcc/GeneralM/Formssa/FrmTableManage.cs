using ControlHosting;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using DevComponents.Tree;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
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
    public partial class FrmTableManage : Form
    {
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

        private Panel panel_Head;
        private Label labelZoom;
        private TrackBar trackBar1;
        private SaveFileDialog saveFileDialog1;
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
            InitializeComponent();
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
                label51.Text = "???????????? ?????????????????? :";
                label52.Text = "???????????? ???????????? :";
                label48.Text = "???????????? ???????????? :";
                label54.Text = "???????????? ?????????????? :";
                buttonX_SaveTable.Text = "????????????????  F2";
                Button_Back.Text = "??????????????????  Esc";
                Node_TablesMap.Text = "???????????????? ????????????????";
                buttonX_Save.Text = "?????? ??????????  F2";
                buttonX_Print.Text = "??????????  F5";
                Text = "?????????? ????????????????????????";
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
                    newCard.Controls["labelName"].Text = ((LangArEn == 0) ? "?????????? ?????? : " : "Table No : ") + q[i].RomeNo;
                    newCard.Controls["labelName"].Tag = q[i].ID.ToString();
                    (newCard.Controls["TextBox_Chair"] as IntegerInput).Value = q[i].chair.Value;
                    newCard.Controls["textBox_Sts"].Text = ((LangArEn != 0) ? (q[i].Stop.Value ? "OFF" : (q[i].reserved.Value ? "reserved" : (q[i].RomeStatus.Value ? "Busy" : "Empty"))) : (q[i].Stop.Value ? "????????\u0651??" : (q[i].reserved.Value ? "????????????" : (q[i].RomeStatus.Value ? "????????????" : "??????????"))));
                    newCard.Controls["textBox_Waiter"].Text = ((!q[i].waiterNo.HasValue) ? ((LangArEn == 0) ? "???? ???????? ????????" : "No Waiter") : ((LangArEn == 0) ? q[i].T_Waiter.Arb_Des : q[i].T_Waiter.Eng_Des));
                    newCard.Controls["TextBox_Note"].Text = q[i].Note;
                    (newCard.Controls["checkBox_OFF"] as CheckBoxX).Checked = false;
                    (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Checked = false;
                    (newCard.Controls["checkBox_Clear"] as CheckBoxX).Checked = false;
                    newCard.Controls["buttonX_Transfer"].Visible = false;
                    if (newCard.Controls["textBox_Sts"].Text.Trim() == "????????????" || newCard.Controls["textBox_Sts"].Text.Trim() == "Busy")
                    {
                        (newCard.Controls["checkBox_OFF"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Enabled = false;
                        newCard.Controls["buttonX_Transfer"].Visible = true;
                    }
                    else if (newCard.Controls["textBox_Sts"].Text.Trim() == "????????????" || newCard.Controls["textBox_Sts"].Text.Trim() == "reserved")
                    {
                        (newCard.Controls["checkBox_OFF"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_Clear"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Checked = true;
                    }
                    else if (newCard.Controls["textBox_Sts"].Text.Trim() == "????????\u0651??" || newCard.Controls["textBox_Sts"].Text.Trim() == "OFF")
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
                    newCard.Controls["labelName"].Text = ((LangArEn == 0) ? "?????????? ?????? : " : "Table No : ") + q[i].RomeNo;
                    newCard.Controls["labelName"].Tag = q[i].ID.ToString();
                    (newCard.Controls["TextBox_Chair"] as IntegerInput).Value = q[i].chair.Value;
                    newCard.Controls["textBox_Sts"].Text = ((LangArEn != 0) ? (q[i].Stop.Value ? "OFF" : (q[i].reserved.Value ? "reserved" : (q[i].RomeStatus.Value ? "Busy" : "Empty"))) : (q[i].Stop.Value ? "????????\u0651??" : (q[i].reserved.Value ? "????????????" : (q[i].RomeStatus.Value ? "????????????" : "??????????"))));
                    newCard.Controls["textBox_Waiter"].Text = ((!q[i].waiterNo.HasValue) ? ((LangArEn == 0) ? "???? ???????? ????????" : "No Waiter") : ((LangArEn == 0) ? q[i].T_Waiter.Arb_Des : q[i].T_Waiter.Eng_Des));
                    newCard.Controls["TextBox_Note"].Text = q[i].Note;
                    (newCard.Controls["checkBox_OFF"] as CheckBoxX).Checked = false;
                    (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Checked = false;
                    (newCard.Controls["checkBox_Clear"] as CheckBoxX).Checked = false;
                    newCard.Controls["buttonX_Transfer"].Visible = false;
                    if (newCard.Controls["textBox_Sts"].Text.Trim() == "????????????" || newCard.Controls["textBox_Sts"].Text.Trim() == "Busy")
                    {
                        (newCard.Controls["checkBox_OFF"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Enabled = false;
                        newCard.Controls["buttonX_Transfer"].Visible = true;
                    }
                    else if (newCard.Controls["textBox_Sts"].Text.Trim() == "????????????" || newCard.Controls["textBox_Sts"].Text.Trim() == "reserved")
                    {
                        (newCard.Controls["checkBox_OFF"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_Clear"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Checked = true;
                    }
                    else if (newCard.Controls["textBox_Sts"].Text.Trim() == "????????\u0651??" || newCard.Controls["textBox_Sts"].Text.Trim() == "OFF")
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
                    newCard.Controls["labelName"].Text = ((LangArEn == 0) ? "?????????? ?????? : " : "Table No : ") + q[i].RomeNo;
                    newCard.Controls["labelName"].Tag = q[i].ID.ToString();
                    (newCard.Controls["TextBox_Chair"] as IntegerInput).Value = q[i].chair.Value;
                    newCard.Controls["textBox_Sts"].Text = ((LangArEn != 0) ? (q[i].Stop.Value ? "OFF" : (q[i].reserved.Value ? "reserved" : (q[i].RomeStatus.Value ? "Busy" : "Empty"))) : (q[i].Stop.Value ? "????????\u0651??" : (q[i].reserved.Value ? "????????????" : (q[i].RomeStatus.Value ? "????????????" : "??????????"))));
                    newCard.Controls["textBox_Waiter"].Text = ((!q[i].waiterNo.HasValue) ? ((LangArEn == 0) ? "???? ???????? ????????" : "No Waiter") : ((LangArEn == 0) ? q[i].T_Waiter.Arb_Des : q[i].T_Waiter.Eng_Des));
                    newCard.Controls["TextBox_Note"].Text = q[i].Note;
                    (newCard.Controls["checkBox_OFF"] as CheckBoxX).Checked = false;
                    (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Checked = false;
                    (newCard.Controls["checkBox_Clear"] as CheckBoxX).Checked = false;
                    newCard.Controls["buttonX_Transfer"].Visible = false;
                    if (newCard.Controls["textBox_Sts"].Text.Trim() == "????????????" || newCard.Controls["textBox_Sts"].Text.Trim() == "Busy")
                    {
                        (newCard.Controls["checkBox_OFF"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Enabled = false;
                        newCard.Controls["buttonX_Transfer"].Visible = true;
                    }
                    else if (newCard.Controls["textBox_Sts"].Text.Trim() == "????????????" || newCard.Controls["textBox_Sts"].Text.Trim() == "reserved")
                    {
                        (newCard.Controls["checkBox_OFF"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_Clear"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Checked = true;
                    }
                    else if (newCard.Controls["textBox_Sts"].Text.Trim() == "????????\u0651??" || newCard.Controls["textBox_Sts"].Text.Trim() == "OFF")
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
                    newCard.Controls["labelName"].Text = ((LangArEn == 0) ? "?????????? ?????? : " : "Table No : ") + q[i].RomeNo;
                    newCard.Controls["labelName"].Tag = q[i].ID.ToString();
                    (newCard.Controls["TextBox_Chair"] as IntegerInput).Value = q[i].chair.Value;
                    newCard.Controls["textBox_Sts"].Text = ((LangArEn != 0) ? (q[i].Stop.Value ? "OFF" : (q[i].reserved.Value ? "reserved" : (q[i].RomeStatus.Value ? "Busy" : "Empty"))) : (q[i].Stop.Value ? "????????\u0651??" : (q[i].reserved.Value ? "????????????" : (q[i].RomeStatus.Value ? "????????????" : "??????????"))));
                    newCard.Controls["textBox_Waiter"].Text = ((!q[i].waiterNo.HasValue) ? ((LangArEn == 0) ? "???? ???????? ????????" : "No Waiter") : ((LangArEn == 0) ? q[i].T_Waiter.Arb_Des : q[i].T_Waiter.Eng_Des));
                    newCard.Controls["TextBox_Note"].Text = q[i].Note;
                    (newCard.Controls["checkBox_OFF"] as CheckBoxX).Checked = false;
                    (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Checked = false;
                    (newCard.Controls["checkBox_Clear"] as CheckBoxX).Checked = false;
                    newCard.Controls["buttonX_Transfer"].Visible = false;
                    if (newCard.Controls["textBox_Sts"].Text.Trim() == "????????????" || newCard.Controls["textBox_Sts"].Text.Trim() == "Busy")
                    {
                        (newCard.Controls["checkBox_OFF"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Enabled = false;
                        newCard.Controls["buttonX_Transfer"].Visible = true;
                    }
                    else if (newCard.Controls["textBox_Sts"].Text.Trim() == "????????????" || newCard.Controls["textBox_Sts"].Text.Trim() == "reserved")
                    {
                        (newCard.Controls["checkBox_OFF"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_Clear"] as CheckBoxX).Enabled = false;
                        (newCard.Controls["checkBox_Reseve"] as CheckBoxX).Checked = true;
                    }
                    else if (newCard.Controls["textBox_Sts"].Text.Trim() == "????????\u0651??" || newCard.Controls["textBox_Sts"].Text.Trim() == "OFF")
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
                    MessageBox.Show((LangArEn == 0) ? "???? ???????????? ?????????? ?????? ???????????? ???????????? ?????? ???????? ???????????? ???????? ?????????????? ?????????????????? ???????? ??????????" : "You can not change the number of system tables until you close all Orders and the reservations it", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                    MessageBox.Show((LangArEn == 0) ? "???? ???????????? ?????????? ?????? ???????????? ???????????? ?????? ???????? ???????????? ???????? ?????????????? ?????????????????? ???????? ??????????" : "You can not change the number of system tables until you close all Orders and the reservations it", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                    MessageBox.Show((LangArEn == 0) ? "???? ???????????? ?????????? ?????? ???????????? ???????????? ?????? ???????? ???????????? ???????? ?????????????? ?????????????????? ???????? ??????????" : "You can not change the number of system tables until you close all Orders and the reservations it", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                    MessageBox.Show((LangArEn == 0) ? "???? ???????????? ?????????? ?????? ???????????? ???????????? ?????? ???????? ???????????? ???????? ?????????????? ?????????????????? ???????? ??????????" : "You can not change the number of system tables until you close all Orders and the reservations it", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                MessageBox.Show((LangArEn == 0) ? "?????? ???? ?????????? ???????????????? ???????????? ?????????? .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmTableManage));
            components = new System.ComponentModel.Container();

            panel_Head = new System.Windows.Forms.Panel();
            trackBar1 = new System.Windows.Forms.TrackBar();
            labelZoom = new System.Windows.Forms.Label();
            buttonX_Save = new DevComponents.DotNetBar.ButtonX();
            buttonX_Print = new DevComponents.DotNetBar.ButtonX();
            saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            TreeGX_Tables = new DevComponents.Tree.TreeGX();
            nodeConnector4 = new DevComponents.Tree.NodeConnector();
            Node_TablesMap = new DevComponents.Tree.Node();
            Node_FamilyTable = new DevComponents.Tree.Node();
            ElementStyle5 = new DevComponents.Tree.ElementStyle();
            Node_BoysTable = new DevComponents.Tree.Node();
            Node_ExtrnalTable = new DevComponents.Tree.Node();
            Node_OtherTable = new DevComponents.Tree.Node();
            ElementStyle2 = new DevComponents.Tree.ElementStyle();
            NodeConnector2 = new DevComponents.Tree.NodeConnector();
            ElementStyle1 = new DevComponents.Tree.ElementStyle();
            NodeConnector1 = new DevComponents.Tree.NodeConnector();
            NodeConnector3 = new DevComponents.Tree.NodeConnector();
            ElementStyle3 = new DevComponents.Tree.ElementStyle();
            ElementStyle4 = new DevComponents.Tree.ElementStyle();
            ElementStyle6 = new DevComponents.Tree.ElementStyle();
            ElementStyle7 = new DevComponents.Tree.ElementStyle();
            elementStyle8 = new DevComponents.Tree.ElementStyle();
            elementStyle9 = new DevComponents.Tree.ElementStyle();
            elementStyle10 = new DevComponents.Tree.ElementStyle();
            elementStyle11 = new DevComponents.Tree.ElementStyle();
            elementStyle12 = new DevComponents.Tree.ElementStyle();
            elementStyle13 = new DevComponents.Tree.ElementStyle();
            elementStyle14 = new DevComponents.Tree.ElementStyle();
            elementStyle15 = new DevComponents.Tree.ElementStyle();
            elementStyle16 = new DevComponents.Tree.ElementStyle();
            elementStyle17 = new DevComponents.Tree.ElementStyle();
            elementStyle18 = new DevComponents.Tree.ElementStyle();
            elementStyle19 = new DevComponents.Tree.ElementStyle();
            elementStyle20 = new DevComponents.Tree.ElementStyle();
            elementStyle21 = new DevComponents.Tree.ElementStyle();
            elementStyle22 = new DevComponents.Tree.ElementStyle();
            elementStyle23 = new DevComponents.Tree.ElementStyle();
            elementStyle24 = new DevComponents.Tree.ElementStyle();
            elementStyle25 = new DevComponents.Tree.ElementStyle();
            elementStyle26 = new DevComponents.Tree.ElementStyle();
            elementStyle27 = new DevComponents.Tree.ElementStyle();
            elementStyle28 = new DevComponents.Tree.ElementStyle();
            elementStyle29 = new DevComponents.Tree.ElementStyle();
            elementStyle30 = new DevComponents.Tree.ElementStyle();
            elementStyle31 = new DevComponents.Tree.ElementStyle();
            expandablePanel_Table = new DevComponents.DotNetBar.ExpandablePanel();
            buttonX_SaveTable = new DevComponents.DotNetBar.ButtonX();
            Button_Back = new DevComponents.DotNetBar.ButtonX();
            txtTablesBoys = new DevComponents.Editors.IntegerInput();
            txtTablesOut = new DevComponents.Editors.IntegerInput();
            txtTablesOther = new DevComponents.Editors.IntegerInput();
            label48 = new System.Windows.Forms.Label();
            label51 = new System.Windows.Forms.Label();
            label52 = new System.Windows.Forms.Label();
            label54 = new System.Windows.Forms.Label();
            txtTablesFamily = new DevComponents.Editors.IntegerInput();
            employeeCard1 = new ControlHosting.EmployeeCard();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();

            panel_Head.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TreeGX_Tables).BeginInit();
            expandablePanel_Table.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtTablesBoys).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtTablesOut).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtTablesOther).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtTablesFamily).BeginInit();
            SuspendLayout();
            panel_Head.AccessibleDescription = null;
            panel_Head.AccessibleName = null;
            resources.ApplyResources(panel_Head, "panel_Head");
            panel_Head.BackColor = System.Drawing.Color.AliceBlue;
            panel_Head.BackgroundImage = null;
            panel_Head.Controls.Add(trackBar1);
            panel_Head.Controls.Add(labelZoom);
            panel_Head.Controls.Add(buttonX_Save);
            panel_Head.Controls.Add(buttonX_Print);
            panel_Head.Font = null;
            panel_Head.Name = "panel_Head";
            trackBar1.AccessibleDescription = null;
            trackBar1.AccessibleName = null;
            resources.ApplyResources(trackBar1, "trackBar1");
            trackBar1.BackgroundImage = null;
            trackBar1.Font = null;
            trackBar1.LargeChange = 50;
            trackBar1.Maximum = 400;
            trackBar1.Minimum = 20;
            trackBar1.Name = "trackBar1";
            trackBar1.SmallChange = 10;
            trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            trackBar1.Value = 100;
            labelZoom.AccessibleDescription = null;
            labelZoom.AccessibleName = null;
            resources.ApplyResources(labelZoom, "labelZoom");
            labelZoom.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
            labelZoom.Name = "labelZoom";
            buttonX_Save.AccessibleDescription = null;
            buttonX_Save.AccessibleName = null;
            buttonX_Save.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(buttonX_Save, "buttonX_Save");
            buttonX_Save.BackgroundImage = null;
            buttonX_Save.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            buttonX_Save.CommandParameter = null;
            buttonX_Save.Name = "buttonX_Save";
            buttonX_Save.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            buttonX_Save.TextColor = System.Drawing.Color.White;
            buttonX_Save.Click += new System.EventHandler(buttonX_Save_Click);
            buttonX_Print.AccessibleDescription = null;
            buttonX_Print.AccessibleName = null;
            buttonX_Print.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(buttonX_Print, "buttonX_Print");
            buttonX_Print.BackgroundImage = null;
            buttonX_Print.Checked = true;
            buttonX_Print.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            buttonX_Print.CommandParameter = null;
            buttonX_Print.Name = "buttonX_Print";
            buttonX_Print.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            buttonX_Print.TextColor = System.Drawing.Color.SteelBlue;
            buttonX_Print.Click += new System.EventHandler(buttonX_Print_Click);
            saveFileDialog1.DefaultExt = "png";
            resources.ApplyResources(saveFileDialog1, "saveFileDialog1");
            printDocument1.OriginAtMargins = true;
            printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
            printPreviewDialog1.AccessibleDescription = null;
            printPreviewDialog1.AccessibleName = null;
            resources.ApplyResources(printPreviewDialog1, "printPreviewDialog1");
            printPreviewDialog1.BackgroundImage = null;
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Font = null;
            printPreviewDialog1.Name = "printPreviewDialog1";
            printPreviewDialog1.UseAntiAlias = true;
            TreeGX_Tables.AccessibleDescription = null;
            TreeGX_Tables.AccessibleName = null;
            TreeGX_Tables.AllowDrop = true;
            resources.ApplyResources(TreeGX_Tables, "TreeGX_Tables");
            TreeGX_Tables.BackgroundImage = null;
            TreeGX_Tables.BackgroundStyle.BackColor = System.Drawing.Color.Azure;
            TreeGX_Tables.BackgroundStyle.BackColor2 = System.Drawing.Color.FromArgb(255, 255, 255);
            TreeGX_Tables.BackgroundStyle.BackColorGradientAngle = 90;
            TreeGX_Tables.CellEdit = true;
            TreeGX_Tables.CommandBackColorGradientAngle = 90;
            TreeGX_Tables.CommandMouseOverBackColor2SchemePart = DevComponents.Tree.eColorSchemePart.ItemHotBackground2;
            TreeGX_Tables.CommandMouseOverBackColorGradientAngle = 90;
            TreeGX_Tables.DiagramLayoutFlow = DevComponents.Tree.eDiagramFlow.TopToBottom;
            TreeGX_Tables.ExpandButtonSize = new System.Drawing.Size(16, 16);
            TreeGX_Tables.ExpandButtonType = DevComponents.Tree.eExpandButtonType.Rectangle;
            TreeGX_Tables.ExpandLineColorSchemePart = DevComponents.Tree.eColorSchemePart.BarCaptionText;
            TreeGX_Tables.LicenseKey = "EB364C34-3CE3-4cd6-BB1B-13513ABE0D62";
            TreeGX_Tables.LinkConnector = nodeConnector4;
            TreeGX_Tables.Name = "TreeGX_Tables";
            TreeGX_Tables.NodeHorizontalSpacing = 22;
            TreeGX_Tables.Nodes.AddRange(new DevComponents.Tree.Node[1]
            {
                Node_TablesMap
            });
            TreeGX_Tables.NodesConnector = NodeConnector2;
            TreeGX_Tables.NodeStyle = ElementStyle1;
            TreeGX_Tables.NodeVerticalSpacing = 30;
            TreeGX_Tables.PathSeparator = ";";
            TreeGX_Tables.RootConnector = NodeConnector1;
            TreeGX_Tables.SelectedPathConnector = NodeConnector3;
            TreeGX_Tables.Styles.Add(ElementStyle1);
            TreeGX_Tables.Styles.Add(ElementStyle3);
            TreeGX_Tables.Styles.Add(ElementStyle2);
            TreeGX_Tables.Styles.Add(ElementStyle4);
            TreeGX_Tables.Styles.Add(ElementStyle5);
            TreeGX_Tables.Styles.Add(ElementStyle6);
            TreeGX_Tables.Styles.Add(ElementStyle7);
            TreeGX_Tables.Styles.Add(elementStyle8);
            TreeGX_Tables.Styles.Add(elementStyle9);
            TreeGX_Tables.Styles.Add(elementStyle10);
            TreeGX_Tables.Styles.Add(elementStyle11);
            TreeGX_Tables.Styles.Add(elementStyle12);
            TreeGX_Tables.Styles.Add(elementStyle13);
            TreeGX_Tables.Styles.Add(elementStyle14);
            TreeGX_Tables.Styles.Add(elementStyle15);
            TreeGX_Tables.Styles.Add(elementStyle16);
            TreeGX_Tables.Styles.Add(elementStyle17);
            TreeGX_Tables.Styles.Add(elementStyle18);
            TreeGX_Tables.Styles.Add(elementStyle19);
            TreeGX_Tables.Styles.Add(elementStyle20);
            TreeGX_Tables.Styles.Add(elementStyle21);
            TreeGX_Tables.Styles.Add(elementStyle22);
            TreeGX_Tables.Styles.Add(elementStyle23);
            TreeGX_Tables.Styles.Add(elementStyle24);
            TreeGX_Tables.Styles.Add(elementStyle25);
            TreeGX_Tables.Styles.Add(elementStyle26);
            TreeGX_Tables.Styles.Add(elementStyle27);
            TreeGX_Tables.Styles.Add(elementStyle28);
            TreeGX_Tables.Styles.Add(elementStyle29);
            TreeGX_Tables.Styles.Add(elementStyle30);
            TreeGX_Tables.Styles.Add(elementStyle31);
            TreeGX_Tables.SuspendPaint = false;
            nodeConnector4.LineWidth = 5;
            Node_TablesMap.Expanded = true;
            Node_TablesMap.Name = "Node_TablesMap";
            Node_TablesMap.Nodes.AddRange(new DevComponents.Tree.Node[4]
            {
                Node_FamilyTable,
                Node_BoysTable,
                Node_ExtrnalTable,
                Node_OtherTable
            });
            Node_TablesMap.Style = ElementStyle2;
            resources.ApplyResources(Node_TablesMap, "Node_TablesMap");
            Node_FamilyTable.Enabled = false;
            Node_FamilyTable.Expanded = true;
            Node_FamilyTable.Name = "Node_FamilyTable";
            Node_FamilyTable.Style = ElementStyle5;
            resources.ApplyResources(Node_FamilyTable, "Node_FamilyTable");
            ElementStyle5.BackColor = System.Drawing.Color.FromArgb(255, 244, 213);
            ElementStyle5.BackColor2 = System.Drawing.Color.FromArgb(255, 216, 105);
            ElementStyle5.BackColorGradientAngle = 90;
            ElementStyle5.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            ElementStyle5.BorderBottomWidth = 1;
            ElementStyle5.BorderColor = System.Drawing.Color.DarkGray;
            ElementStyle5.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            ElementStyle5.BorderLeftWidth = 1;
            ElementStyle5.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            ElementStyle5.BorderRightWidth = 1;
            ElementStyle5.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            ElementStyle5.BorderTopWidth = 1;
            ElementStyle5.CornerDiameter = 4;
            ElementStyle5.CornerType = DevComponents.Tree.eCornerType.Rounded;
            ElementStyle5.Description = "Yellow";
            ElementStyle5.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            ElementStyle5.Name = "ElementStyle5";
            ElementStyle5.PaddingBottom = 3;
            ElementStyle5.PaddingLeft = 3;
            ElementStyle5.PaddingRight = 3;
            ElementStyle5.PaddingTop = 3;
            ElementStyle5.TextColor = System.Drawing.Color.Black;
            Node_BoysTable.Enabled = false;
            Node_BoysTable.Expanded = true;
            Node_BoysTable.Name = "Node_BoysTable";
            Node_BoysTable.Style = ElementStyle5;
            resources.ApplyResources(Node_BoysTable, "Node_BoysTable");
            Node_ExtrnalTable.Enabled = false;
            Node_ExtrnalTable.Expanded = true;
            Node_ExtrnalTable.Name = "Node_ExtrnalTable";
            Node_ExtrnalTable.Style = ElementStyle5;
            resources.ApplyResources(Node_ExtrnalTable, "Node_ExtrnalTable");
            Node_OtherTable.Enabled = false;
            Node_OtherTable.Expanded = true;
            Node_OtherTable.Name = "Node_OtherTable";
            Node_OtherTable.Style = ElementStyle5;
            resources.ApplyResources(Node_OtherTable, "Node_OtherTable");
            ElementStyle2.BackColor = System.Drawing.Color.FromArgb(77, 108, 152);
            ElementStyle2.BackColor2 = System.Drawing.Color.Navy;
            ElementStyle2.BackColorGradientAngle = 90;
            ElementStyle2.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            ElementStyle2.BorderBottomWidth = 1;
            ElementStyle2.BorderColor = System.Drawing.Color.Navy;
            ElementStyle2.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            ElementStyle2.BorderLeftWidth = 1;
            ElementStyle2.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            ElementStyle2.BorderRightWidth = 1;
            ElementStyle2.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            ElementStyle2.BorderTopWidth = 1;
            ElementStyle2.CornerDiameter = 4;
            ElementStyle2.CornerType = DevComponents.Tree.eCornerType.Rounded;
            ElementStyle2.Description = "BlueNight";
            ElementStyle2.Font = new System.Drawing.Font("Tahoma", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            ElementStyle2.Name = "ElementStyle2";
            ElementStyle2.PaddingBottom = 3;
            ElementStyle2.PaddingLeft = 3;
            ElementStyle2.PaddingRight = 3;
            ElementStyle2.PaddingTop = 3;
            ElementStyle2.TextColor = System.Drawing.Color.White;
            NodeConnector2.LineWidth = 5;
            ElementStyle1.BackColor2SchemePart = DevComponents.Tree.eColorSchemePart.BarBackground2;
            ElementStyle1.BackColorGradientAngle = 90;
            ElementStyle1.BackColorSchemePart = DevComponents.Tree.eColorSchemePart.BarBackground;
            ElementStyle1.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            ElementStyle1.BorderBottomWidth = 1;
            ElementStyle1.BorderColorSchemePart = DevComponents.Tree.eColorSchemePart.BarDockedBorder;
            ElementStyle1.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            ElementStyle1.BorderLeftWidth = 1;
            ElementStyle1.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            ElementStyle1.BorderRightWidth = 1;
            ElementStyle1.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            ElementStyle1.BorderTopWidth = 1;
            ElementStyle1.CornerDiameter = 4;
            ElementStyle1.CornerType = DevComponents.Tree.eCornerType.Rounded;
            ElementStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            ElementStyle1.Name = "ElementStyle1";
            ElementStyle1.PaddingBottom = 3;
            ElementStyle1.PaddingLeft = 3;
            ElementStyle1.PaddingRight = 3;
            ElementStyle1.PaddingTop = 3;
            ElementStyle1.TextColor = System.Drawing.Color.FromArgb(0, 0, 128);
            NodeConnector1.LineWidth = 5;
            NodeConnector3.LineColor = System.Drawing.Color.Goldenrod;
            NodeConnector3.LineWidth = 5;
            ElementStyle3.BackColor = System.Drawing.Color.FromArgb(221, 230, 247);
            ElementStyle3.BackColor2 = System.Drawing.Color.FromArgb(138, 168, 228);
            ElementStyle3.BackColorGradientAngle = 90;
            ElementStyle3.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            ElementStyle3.BorderBottomWidth = 1;
            ElementStyle3.BorderColor = System.Drawing.Color.DarkGray;
            ElementStyle3.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            ElementStyle3.BorderLeftWidth = 1;
            ElementStyle3.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            ElementStyle3.BorderRightWidth = 1;
            ElementStyle3.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            ElementStyle3.BorderTopWidth = 1;
            ElementStyle3.CornerDiameter = 4;
            ElementStyle3.CornerType = DevComponents.Tree.eCornerType.Rounded;
            ElementStyle3.Description = "Blue";
            ElementStyle3.Name = "ElementStyle3";
            ElementStyle3.PaddingBottom = 3;
            ElementStyle3.PaddingLeft = 3;
            ElementStyle3.PaddingRight = 3;
            ElementStyle3.PaddingTop = 3;
            ElementStyle3.TextColor = System.Drawing.Color.Black;
            ElementStyle4.BackColor = System.Drawing.Color.FromArgb(249, 225, 226);
            ElementStyle4.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 151);
            ElementStyle4.BackColorGradientAngle = 90;
            ElementStyle4.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            ElementStyle4.BorderBottomWidth = 1;
            ElementStyle4.BorderColor = System.Drawing.Color.DarkGray;
            ElementStyle4.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            ElementStyle4.BorderLeftWidth = 1;
            ElementStyle4.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            ElementStyle4.BorderRightWidth = 1;
            ElementStyle4.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            ElementStyle4.BorderTopWidth = 1;
            ElementStyle4.CornerDiameter = 4;
            ElementStyle4.CornerType = DevComponents.Tree.eCornerType.Rounded;
            ElementStyle4.Description = "Red";
            ElementStyle4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            ElementStyle4.Name = "ElementStyle4";
            ElementStyle4.PaddingBottom = 3;
            ElementStyle4.PaddingLeft = 3;
            ElementStyle4.PaddingRight = 3;
            ElementStyle4.PaddingTop = 3;
            ElementStyle4.TextColor = System.Drawing.Color.FromArgb(66, 65, 66);
            ElementStyle6.BackColor = System.Drawing.Color.FromArgb(234, 240, 226);
            ElementStyle6.BackColor2 = System.Drawing.Color.FromArgb(183, 201, 151);
            ElementStyle6.BackColorGradientAngle = 90;
            ElementStyle6.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            ElementStyle6.BorderBottomWidth = 1;
            ElementStyle6.BorderColor = System.Drawing.Color.DarkGray;
            ElementStyle6.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            ElementStyle6.BorderLeftWidth = 1;
            ElementStyle6.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            ElementStyle6.BorderRightWidth = 1;
            ElementStyle6.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            ElementStyle6.BorderTopWidth = 1;
            ElementStyle6.CornerDiameter = 4;
            ElementStyle6.CornerType = DevComponents.Tree.eCornerType.Rounded;
            ElementStyle6.Description = "Green";
            ElementStyle6.Name = "ElementStyle6";
            ElementStyle6.PaddingBottom = 3;
            ElementStyle6.PaddingLeft = 3;
            ElementStyle6.PaddingRight = 3;
            ElementStyle6.PaddingTop = 3;
            ElementStyle6.TextColor = System.Drawing.Color.Black;
            ElementStyle7.Description = "White";
            ElementStyle7.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            ElementStyle7.Name = "ElementStyle7";
            ElementStyle7.TextColor = System.Drawing.Color.FromArgb(66, 65, 66);
            elementStyle8.BackColor = System.Drawing.Color.FromArgb(221, 230, 247);
            elementStyle8.BackColor2 = System.Drawing.Color.FromArgb(138, 168, 228);
            elementStyle8.BackColorGradientAngle = 90;
            elementStyle8.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle8.BorderBottomWidth = 1;
            elementStyle8.BorderColor = System.Drawing.Color.DarkGray;
            elementStyle8.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle8.BorderLeftWidth = 1;
            elementStyle8.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle8.BorderRightWidth = 1;
            elementStyle8.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle8.BorderTopWidth = 1;
            elementStyle8.CornerDiameter = 4;
            elementStyle8.CornerType = DevComponents.Tree.eCornerType.Rounded;
            elementStyle8.Description = "Blue";
            elementStyle8.Name = "elementStyle8";
            elementStyle8.PaddingBottom = 3;
            elementStyle8.PaddingLeft = 3;
            elementStyle8.PaddingRight = 3;
            elementStyle8.PaddingTop = 3;
            elementStyle8.TextColor = System.Drawing.Color.Black;
            elementStyle9.BackColor = System.Drawing.Color.FromArgb(205, 236, 240);
            elementStyle9.BackColor2 = System.Drawing.Color.FromArgb(78, 188, 202);
            elementStyle9.BackColorGradientAngle = 90;
            elementStyle9.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle9.BorderBottomWidth = 1;
            elementStyle9.BorderColor = System.Drawing.Color.DarkGray;
            elementStyle9.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle9.BorderLeftWidth = 1;
            elementStyle9.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle9.BorderRightWidth = 1;
            elementStyle9.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle9.BorderTopWidth = 1;
            elementStyle9.CornerDiameter = 4;
            elementStyle9.CornerType = DevComponents.Tree.eCornerType.Rounded;
            elementStyle9.Description = "Teal";
            elementStyle9.Name = "elementStyle9";
            elementStyle9.PaddingBottom = 3;
            elementStyle9.PaddingLeft = 3;
            elementStyle9.PaddingRight = 3;
            elementStyle9.PaddingTop = 3;
            elementStyle9.TextColor = System.Drawing.Color.Black;
            elementStyle10.BackColor = System.Drawing.Color.FromArgb(234, 240, 226);
            elementStyle10.BackColor2 = System.Drawing.Color.FromArgb(183, 201, 151);
            elementStyle10.BackColorGradientAngle = 90;
            elementStyle10.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle10.BorderBottomWidth = 1;
            elementStyle10.BorderColor = System.Drawing.Color.DarkGray;
            elementStyle10.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle10.BorderLeftWidth = 1;
            elementStyle10.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle10.BorderRightWidth = 1;
            elementStyle10.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle10.BorderTopWidth = 1;
            elementStyle10.CornerDiameter = 4;
            elementStyle10.CornerType = DevComponents.Tree.eCornerType.Rounded;
            elementStyle10.Description = "Green";
            elementStyle10.Name = "elementStyle10";
            elementStyle10.PaddingBottom = 3;
            elementStyle10.PaddingLeft = 3;
            elementStyle10.PaddingRight = 3;
            elementStyle10.PaddingTop = 3;
            elementStyle10.TextColor = System.Drawing.Color.Black;
            elementStyle11.BackColor = System.Drawing.Color.FromArgb(234, 240, 226);
            elementStyle11.BackColor2 = System.Drawing.Color.FromArgb(183, 201, 151);
            elementStyle11.BackColorGradientAngle = 90;
            elementStyle11.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle11.BorderBottomWidth = 1;
            elementStyle11.BorderColor = System.Drawing.Color.DarkGray;
            elementStyle11.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle11.BorderLeftWidth = 1;
            elementStyle11.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle11.BorderRightWidth = 1;
            elementStyle11.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle11.BorderTopWidth = 1;
            elementStyle11.CornerDiameter = 4;
            elementStyle11.CornerType = DevComponents.Tree.eCornerType.Rounded;
            elementStyle11.Description = "Green";
            elementStyle11.Name = "elementStyle11";
            elementStyle11.PaddingBottom = 3;
            elementStyle11.PaddingLeft = 3;
            elementStyle11.PaddingRight = 3;
            elementStyle11.PaddingTop = 3;
            elementStyle11.TextColor = System.Drawing.Color.Black;
            elementStyle12.BackColor = System.Drawing.Color.FromArgb(77, 108, 152);
            elementStyle12.BackColor2 = System.Drawing.Color.Navy;
            elementStyle12.BackColorGradientAngle = 90;
            elementStyle12.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle12.BorderBottomWidth = 1;
            elementStyle12.BorderColor = System.Drawing.Color.Navy;
            elementStyle12.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle12.BorderLeftWidth = 1;
            elementStyle12.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle12.BorderRightWidth = 1;
            elementStyle12.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle12.BorderTopWidth = 1;
            elementStyle12.CornerDiameter = 4;
            elementStyle12.CornerType = DevComponents.Tree.eCornerType.Rounded;
            elementStyle12.Description = "BlueNight";
            elementStyle12.Name = "elementStyle12";
            elementStyle12.PaddingBottom = 3;
            elementStyle12.PaddingLeft = 3;
            elementStyle12.PaddingRight = 3;
            elementStyle12.PaddingTop = 3;
            elementStyle12.TextColor = System.Drawing.Color.White;
            elementStyle13.BackColor = System.Drawing.Color.FromArgb(234, 227, 245);
            elementStyle13.BackColor2 = System.Drawing.Color.FromArgb(180, 158, 222);
            elementStyle13.BackColorGradientAngle = 90;
            elementStyle13.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle13.BorderBottomWidth = 1;
            elementStyle13.BorderColor = System.Drawing.Color.DarkGray;
            elementStyle13.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle13.BorderLeftWidth = 1;
            elementStyle13.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle13.BorderRightWidth = 1;
            elementStyle13.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle13.BorderTopWidth = 1;
            elementStyle13.CornerDiameter = 4;
            elementStyle13.CornerType = DevComponents.Tree.eCornerType.Rounded;
            elementStyle13.Description = "Purple";
            elementStyle13.Name = "elementStyle13";
            elementStyle13.PaddingBottom = 3;
            elementStyle13.PaddingLeft = 3;
            elementStyle13.PaddingRight = 3;
            elementStyle13.PaddingTop = 3;
            elementStyle13.TextColor = System.Drawing.Color.Black;
            elementStyle14.BackColor = System.Drawing.Color.FromArgb(255, 239, 201);
            elementStyle14.BackColor2 = System.Drawing.Color.FromArgb(242, 210, 132);
            elementStyle14.BackColorGradientAngle = 90;
            elementStyle14.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle14.BorderBottomWidth = 1;
            elementStyle14.BorderColor = System.Drawing.Color.DarkGray;
            elementStyle14.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle14.BorderLeftWidth = 1;
            elementStyle14.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle14.BorderRightWidth = 1;
            elementStyle14.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle14.BorderTopWidth = 1;
            elementStyle14.CornerDiameter = 4;
            elementStyle14.CornerType = DevComponents.Tree.eCornerType.Rounded;
            elementStyle14.Description = "OrangeLight";
            elementStyle14.Name = "elementStyle14";
            elementStyle14.PaddingBottom = 3;
            elementStyle14.PaddingLeft = 3;
            elementStyle14.PaddingRight = 3;
            elementStyle14.PaddingTop = 3;
            elementStyle14.TextColor = System.Drawing.Color.FromArgb(117, 83, 2);
            elementStyle15.BackColor = System.Drawing.Color.FromArgb(249, 225, 226);
            elementStyle15.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 151);
            elementStyle15.BackColorGradientAngle = 90;
            elementStyle15.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle15.BorderBottomWidth = 1;
            elementStyle15.BorderColor = System.Drawing.Color.DarkGray;
            elementStyle15.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle15.BorderLeftWidth = 1;
            elementStyle15.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle15.BorderRightWidth = 1;
            elementStyle15.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle15.BorderTopWidth = 1;
            elementStyle15.CornerDiameter = 4;
            elementStyle15.CornerType = DevComponents.Tree.eCornerType.Rounded;
            elementStyle15.Description = "Red";
            elementStyle15.Name = "elementStyle15";
            elementStyle15.PaddingBottom = 3;
            elementStyle15.PaddingLeft = 3;
            elementStyle15.PaddingRight = 3;
            elementStyle15.PaddingTop = 3;
            elementStyle15.TextColor = System.Drawing.Color.Black;
            elementStyle16.BackColor = System.Drawing.Color.FromArgb(252, 253, 215);
            elementStyle16.BackColor2 = System.Drawing.Color.FromArgb(245, 249, 111);
            elementStyle16.BackColorGradientAngle = 90;
            elementStyle16.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle16.BorderBottomWidth = 1;
            elementStyle16.BorderColor = System.Drawing.Color.DarkGray;
            elementStyle16.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle16.BorderLeftWidth = 1;
            elementStyle16.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle16.BorderRightWidth = 1;
            elementStyle16.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle16.BorderTopWidth = 1;
            elementStyle16.CornerDiameter = 4;
            elementStyle16.CornerType = DevComponents.Tree.eCornerType.Rounded;
            elementStyle16.Description = "Lemon";
            elementStyle16.Name = "elementStyle16";
            elementStyle16.PaddingBottom = 3;
            elementStyle16.PaddingLeft = 3;
            elementStyle16.PaddingRight = 3;
            elementStyle16.PaddingTop = 3;
            elementStyle16.TextColor = System.Drawing.Color.Black;
            elementStyle17.BackColor = System.Drawing.Color.FromArgb(232, 227, 234);
            elementStyle17.BackColor2 = System.Drawing.Color.FromArgb(171, 156, 183);
            elementStyle17.BackColorGradientAngle = 90;
            elementStyle17.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle17.BorderBottomWidth = 1;
            elementStyle17.BorderColor = System.Drawing.Color.DarkGray;
            elementStyle17.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle17.BorderLeftWidth = 1;
            elementStyle17.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle17.BorderRightWidth = 1;
            elementStyle17.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle17.BorderTopWidth = 1;
            elementStyle17.CornerDiameter = 4;
            elementStyle17.CornerType = DevComponents.Tree.eCornerType.Rounded;
            elementStyle17.Description = "PurpleMist";
            elementStyle17.Name = "elementStyle17";
            elementStyle17.PaddingBottom = 3;
            elementStyle17.PaddingLeft = 3;
            elementStyle17.PaddingRight = 3;
            elementStyle17.PaddingTop = 3;
            elementStyle17.TextColor = System.Drawing.Color.Black;
            elementStyle18.BackColor = System.Drawing.Color.FromArgb(243, 244, 250);
            elementStyle18.BackColor2 = System.Drawing.Color.FromArgb(155, 153, 183);
            elementStyle18.BackColorGradientAngle = 90;
            elementStyle18.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle18.BorderBottomWidth = 1;
            elementStyle18.BorderColor = System.Drawing.Color.DarkGray;
            elementStyle18.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle18.BorderLeftWidth = 1;
            elementStyle18.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle18.BorderRightWidth = 1;
            elementStyle18.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle18.BorderTopWidth = 1;
            elementStyle18.CornerDiameter = 4;
            elementStyle18.CornerType = DevComponents.Tree.eCornerType.Rounded;
            elementStyle18.Description = "SilverMist";
            elementStyle18.Name = "elementStyle18";
            elementStyle18.PaddingBottom = 3;
            elementStyle18.PaddingLeft = 3;
            elementStyle18.PaddingRight = 3;
            elementStyle18.PaddingTop = 3;
            elementStyle18.TextColor = System.Drawing.Color.FromArgb(87, 86, 113);
            elementStyle19.BackColor = System.Drawing.Color.FromArgb(221, 230, 247);
            elementStyle19.BackColor2 = System.Drawing.Color.FromArgb(138, 168, 228);
            elementStyle19.BackColorGradientAngle = 90;
            elementStyle19.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle19.BorderBottomWidth = 1;
            elementStyle19.BorderColor = System.Drawing.Color.DarkGray;
            elementStyle19.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle19.BorderLeftWidth = 1;
            elementStyle19.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle19.BorderRightWidth = 1;
            elementStyle19.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle19.BorderTopWidth = 1;
            elementStyle19.CornerDiameter = 4;
            elementStyle19.CornerType = DevComponents.Tree.eCornerType.Rounded;
            elementStyle19.Description = "Blue";
            elementStyle19.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            elementStyle19.Name = "elementStyle19";
            elementStyle19.PaddingBottom = 3;
            elementStyle19.PaddingLeft = 3;
            elementStyle19.PaddingRight = 3;
            elementStyle19.PaddingTop = 3;
            elementStyle19.TextColor = System.Drawing.Color.FromArgb(66, 65, 66);
            elementStyle20.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            elementStyle20.BackColor2 = System.Drawing.Color.FromArgb(210, 224, 252);
            elementStyle20.BackColorGradientAngle = 90;
            elementStyle20.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle20.BorderBottomWidth = 1;
            elementStyle20.BorderColor = System.Drawing.Color.DarkGray;
            elementStyle20.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle20.BorderLeftWidth = 1;
            elementStyle20.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle20.BorderRightWidth = 1;
            elementStyle20.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle20.BorderTopWidth = 1;
            elementStyle20.CornerDiameter = 4;
            elementStyle20.CornerType = DevComponents.Tree.eCornerType.Rounded;
            elementStyle20.Description = "BlueLight";
            elementStyle20.Name = "elementStyle20";
            elementStyle20.PaddingBottom = 3;
            elementStyle20.PaddingLeft = 3;
            elementStyle20.PaddingRight = 3;
            elementStyle20.PaddingTop = 3;
            elementStyle20.TextColor = System.Drawing.Color.FromArgb(69, 84, 115);
            elementStyle21.BackColor = System.Drawing.Color.FromArgb(252, 233, 217);
            elementStyle21.BackColor2 = System.Drawing.Color.FromArgb(246, 176, 120);
            elementStyle21.BackColorGradientAngle = 90;
            elementStyle21.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle21.BorderBottomWidth = 1;
            elementStyle21.BorderColor = System.Drawing.Color.DarkGray;
            elementStyle21.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle21.BorderLeftWidth = 1;
            elementStyle21.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle21.BorderRightWidth = 1;
            elementStyle21.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle21.BorderTopWidth = 1;
            elementStyle21.CornerDiameter = 4;
            elementStyle21.CornerType = DevComponents.Tree.eCornerType.Rounded;
            elementStyle21.Description = "Orange";
            elementStyle21.Name = "elementStyle21";
            elementStyle21.PaddingBottom = 3;
            elementStyle21.PaddingLeft = 3;
            elementStyle21.PaddingRight = 3;
            elementStyle21.PaddingTop = 3;
            elementStyle21.TextColor = System.Drawing.Color.Black;
            elementStyle22.BackColor = System.Drawing.Color.FromArgb(234, 240, 226);
            elementStyle22.BackColor2 = System.Drawing.Color.FromArgb(183, 201, 151);
            elementStyle22.BackColorGradientAngle = 90;
            elementStyle22.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle22.BorderBottomWidth = 1;
            elementStyle22.BorderColor = System.Drawing.Color.DarkGray;
            elementStyle22.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle22.BorderLeftWidth = 1;
            elementStyle22.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle22.BorderRightWidth = 1;
            elementStyle22.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle22.BorderTopWidth = 1;
            elementStyle22.CornerDiameter = 4;
            elementStyle22.CornerType = DevComponents.Tree.eCornerType.Rounded;
            elementStyle22.Description = "Green";
            elementStyle22.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            elementStyle22.Name = "elementStyle22";
            elementStyle22.PaddingBottom = 3;
            elementStyle22.PaddingLeft = 3;
            elementStyle22.PaddingRight = 3;
            elementStyle22.PaddingTop = 3;
            elementStyle22.TextColor = System.Drawing.Color.FromArgb(66, 65, 66);
            elementStyle23.BackColor = System.Drawing.Color.FromArgb(227, 236, 243);
            elementStyle23.BackColor2 = System.Drawing.Color.FromArgb(155, 187, 210);
            elementStyle23.BackColorGradientAngle = 90;
            elementStyle23.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle23.BorderBottomWidth = 1;
            elementStyle23.BorderColor = System.Drawing.Color.DarkGray;
            elementStyle23.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle23.BorderLeftWidth = 1;
            elementStyle23.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle23.BorderRightWidth = 1;
            elementStyle23.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle23.BorderTopWidth = 1;
            elementStyle23.CornerDiameter = 4;
            elementStyle23.CornerType = DevComponents.Tree.eCornerType.Rounded;
            elementStyle23.Description = "Cyan";
            elementStyle23.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            elementStyle23.Name = "elementStyle23";
            elementStyle23.PaddingBottom = 3;
            elementStyle23.PaddingLeft = 3;
            elementStyle23.PaddingRight = 3;
            elementStyle23.PaddingTop = 3;
            elementStyle23.TextColor = System.Drawing.Color.Black;
            elementStyle24.BackColor = System.Drawing.Color.FromArgb(243, 229, 236);
            elementStyle24.BackColor2 = System.Drawing.Color.FromArgb(213, 164, 187);
            elementStyle24.BackColorGradientAngle = 90;
            elementStyle24.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle24.BorderBottomWidth = 1;
            elementStyle24.BorderColor = System.Drawing.Color.DarkGray;
            elementStyle24.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle24.BorderLeftWidth = 1;
            elementStyle24.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle24.BorderRightWidth = 1;
            elementStyle24.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle24.BorderTopWidth = 1;
            elementStyle24.CornerDiameter = 4;
            elementStyle24.CornerType = DevComponents.Tree.eCornerType.Rounded;
            elementStyle24.Description = "Magenta";
            elementStyle24.Name = "elementStyle24";
            elementStyle24.PaddingBottom = 3;
            elementStyle24.PaddingLeft = 3;
            elementStyle24.PaddingRight = 3;
            elementStyle24.PaddingTop = 3;
            elementStyle24.TextColor = System.Drawing.Color.Black;
            elementStyle25.BackColor = System.Drawing.Color.FromArgb(243, 244, 250);
            elementStyle25.BackColor2 = System.Drawing.Color.FromArgb(155, 153, 183);
            elementStyle25.BackColorGradientAngle = 90;
            elementStyle25.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle25.BorderBottomWidth = 1;
            elementStyle25.BorderColor = System.Drawing.Color.DarkGray;
            elementStyle25.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle25.BorderLeftWidth = 1;
            elementStyle25.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle25.BorderRightWidth = 1;
            elementStyle25.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle25.BorderTopWidth = 1;
            elementStyle25.CornerDiameter = 4;
            elementStyle25.CornerType = DevComponents.Tree.eCornerType.Rounded;
            elementStyle25.Description = "SilverMist";
            elementStyle25.Name = "elementStyle25";
            elementStyle25.PaddingBottom = 3;
            elementStyle25.PaddingLeft = 3;
            elementStyle25.PaddingRight = 3;
            elementStyle25.PaddingTop = 3;
            elementStyle25.TextColor = System.Drawing.Color.FromArgb(87, 86, 113);
            elementStyle26.BackColor = System.Drawing.Color.FromArgb(243, 244, 250);
            elementStyle26.BackColor2 = System.Drawing.Color.FromArgb(155, 153, 183);
            elementStyle26.BackColorGradientAngle = 90;
            elementStyle26.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle26.BorderBottomWidth = 1;
            elementStyle26.BorderColor = System.Drawing.Color.DarkGray;
            elementStyle26.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle26.BorderLeftWidth = 1;
            elementStyle26.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle26.BorderRightWidth = 1;
            elementStyle26.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle26.BorderTopWidth = 1;
            elementStyle26.CornerDiameter = 4;
            elementStyle26.CornerType = DevComponents.Tree.eCornerType.Rounded;
            elementStyle26.Description = "SilverMist";
            elementStyle26.Name = "elementStyle26";
            elementStyle26.PaddingBottom = 3;
            elementStyle26.PaddingLeft = 3;
            elementStyle26.PaddingRight = 3;
            elementStyle26.PaddingTop = 3;
            elementStyle26.TextColor = System.Drawing.Color.FromArgb(87, 86, 113);
            elementStyle27.BackColor = System.Drawing.Color.White;
            elementStyle27.BackColor2 = System.Drawing.Color.FromArgb(228, 228, 240);
            elementStyle27.BackColorGradientAngle = 90;
            elementStyle27.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle27.BorderBottomWidth = 1;
            elementStyle27.BorderColor = System.Drawing.Color.DarkGray;
            elementStyle27.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle27.BorderLeftWidth = 1;
            elementStyle27.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle27.BorderRightWidth = 1;
            elementStyle27.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle27.BorderTopWidth = 1;
            elementStyle27.CornerDiameter = 4;
            elementStyle27.CornerType = DevComponents.Tree.eCornerType.Rounded;
            elementStyle27.Description = "Gray";
            elementStyle27.Name = "elementStyle27";
            elementStyle27.PaddingBottom = 3;
            elementStyle27.PaddingLeft = 3;
            elementStyle27.PaddingRight = 3;
            elementStyle27.PaddingTop = 3;
            elementStyle27.TextColor = System.Drawing.Color.Black;
            elementStyle28.BackColor = System.Drawing.Color.FromArgb(232, 248, 224);
            elementStyle28.BackColor2 = System.Drawing.Color.FromArgb(173, 231, 146);
            elementStyle28.BackColorGradientAngle = 90;
            elementStyle28.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle28.BorderBottomWidth = 1;
            elementStyle28.BorderColor = System.Drawing.Color.DarkGray;
            elementStyle28.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle28.BorderLeftWidth = 1;
            elementStyle28.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle28.BorderRightWidth = 1;
            elementStyle28.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle28.BorderTopWidth = 1;
            elementStyle28.CornerDiameter = 4;
            elementStyle28.CornerType = DevComponents.Tree.eCornerType.Rounded;
            elementStyle28.Description = "Apple";
            elementStyle28.Name = "elementStyle28";
            elementStyle28.PaddingBottom = 3;
            elementStyle28.PaddingLeft = 3;
            elementStyle28.PaddingRight = 3;
            elementStyle28.PaddingTop = 3;
            elementStyle28.TextColor = System.Drawing.Color.Black;
            elementStyle29.BackColor = System.Drawing.Color.FromArgb(227, 236, 243);
            elementStyle29.BackColor2 = System.Drawing.Color.FromArgb(155, 187, 210);
            elementStyle29.BackColorGradientAngle = 90;
            elementStyle29.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle29.BorderBottomWidth = 1;
            elementStyle29.BorderColor = System.Drawing.Color.DarkGray;
            elementStyle29.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle29.BorderLeftWidth = 1;
            elementStyle29.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle29.BorderRightWidth = 1;
            elementStyle29.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle29.BorderTopWidth = 1;
            elementStyle29.CornerDiameter = 4;
            elementStyle29.CornerType = DevComponents.Tree.eCornerType.Rounded;
            elementStyle29.Description = "Cyan";
            elementStyle29.Name = "elementStyle29";
            elementStyle29.PaddingBottom = 3;
            elementStyle29.PaddingLeft = 3;
            elementStyle29.PaddingRight = 3;
            elementStyle29.PaddingTop = 3;
            elementStyle29.TextColor = System.Drawing.Color.Black;
            elementStyle30.BackColor = System.Drawing.Color.White;
            elementStyle30.BackColor2 = System.Drawing.Color.FromArgb(228, 228, 240);
            elementStyle30.BackColorGradientAngle = 90;
            elementStyle30.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle30.BorderBottomWidth = 1;
            elementStyle30.BorderColor = System.Drawing.Color.DarkGray;
            elementStyle30.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle30.BorderLeftWidth = 1;
            elementStyle30.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle30.BorderRightWidth = 1;
            elementStyle30.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle30.BorderTopWidth = 1;
            elementStyle30.CornerDiameter = 4;
            elementStyle30.CornerType = DevComponents.Tree.eCornerType.Rounded;
            elementStyle30.Description = "Gray";
            elementStyle30.Name = "elementStyle30";
            elementStyle30.PaddingBottom = 3;
            elementStyle30.PaddingLeft = 3;
            elementStyle30.PaddingRight = 3;
            elementStyle30.PaddingTop = 3;
            elementStyle30.TextColor = System.Drawing.Color.Black;
            elementStyle31.BackColor = System.Drawing.Color.FromArgb(205, 236, 240);
            elementStyle31.BackColor2 = System.Drawing.Color.FromArgb(78, 188, 202);
            elementStyle31.BackColorGradientAngle = 90;
            elementStyle31.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle31.BorderBottomWidth = 1;
            elementStyle31.BorderColor = System.Drawing.Color.DarkGray;
            elementStyle31.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle31.BorderLeftWidth = 1;
            elementStyle31.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle31.BorderRightWidth = 1;
            elementStyle31.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            elementStyle31.BorderTopWidth = 1;
            elementStyle31.CornerDiameter = 4;
            elementStyle31.CornerType = DevComponents.Tree.eCornerType.Rounded;
            elementStyle31.Description = "Teal";
            elementStyle31.Name = "elementStyle31";
            elementStyle31.PaddingBottom = 3;
            elementStyle31.PaddingLeft = 3;
            elementStyle31.PaddingRight = 3;
            elementStyle31.PaddingTop = 3;
            elementStyle31.TextColor = System.Drawing.Color.Black;
            expandablePanel_Table.AccessibleDescription = null;
            expandablePanel_Table.AccessibleName = null;
            resources.ApplyResources(expandablePanel_Table, "expandablePanel_Table");
            expandablePanel_Table.CanvasColor = System.Drawing.SystemColors.Control;
            expandablePanel_Table.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            expandablePanel_Table.Controls.Add(buttonX_SaveTable);
            expandablePanel_Table.Controls.Add(Button_Back);
            expandablePanel_Table.Controls.Add(txtTablesBoys);
            expandablePanel_Table.Controls.Add(txtTablesOut);
            expandablePanel_Table.Controls.Add(txtTablesOther);
            expandablePanel_Table.Controls.Add(label48);
            expandablePanel_Table.Controls.Add(label51);
            expandablePanel_Table.Controls.Add(label52);
            expandablePanel_Table.Controls.Add(label54);
            expandablePanel_Table.Controls.Add(txtTablesFamily);
            expandablePanel_Table.ExpandButtonVisible = false;
            expandablePanel_Table.Expanded = false;
            expandablePanel_Table.ExpandedBounds = new System.Drawing.Rectangle(0, 499, 822, 164);
            expandablePanel_Table.ExpandOnTitleClick = true;
            expandablePanel_Table.MinimumSize = new System.Drawing.Size(822, 53);
            expandablePanel_Table.Name = "expandablePanel_Table";
            expandablePanel_Table.Style.Alignment = System.Drawing.StringAlignment.Center;
            expandablePanel_Table.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            expandablePanel_Table.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            expandablePanel_Table.Style.BorderColor.Color = System.Drawing.Color.White;
            expandablePanel_Table.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            expandablePanel_Table.Style.GradientAngle = 90;
            expandablePanel_Table.Tag = "";
            expandablePanel_Table.TitleHeight = 50;
            expandablePanel_Table.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            expandablePanel_Table.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            expandablePanel_Table.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            expandablePanel_Table.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            expandablePanel_Table.TitleStyle.ForeColor.Color = System.Drawing.Color.FromArgb(64, 64, 64);
            expandablePanel_Table.TitleStyle.GradientAngle = 90;
            expandablePanel_Table.ExpandedChanged += new DevComponents.DotNetBar.ExpandChangeEventHandler(expandablePanel_Table_ExpandedChanged);
            buttonX_SaveTable.AccessibleDescription = null;
            buttonX_SaveTable.AccessibleName = null;
            buttonX_SaveTable.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(buttonX_SaveTable, "buttonX_SaveTable");
            buttonX_SaveTable.BackgroundImage = null;
            buttonX_SaveTable.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            buttonX_SaveTable.CommandParameter = null;
            buttonX_SaveTable.Name = "buttonX_SaveTable";
            buttonX_SaveTable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            buttonX_SaveTable.Symbol = "\uf00c";
            buttonX_SaveTable.SymbolSize = 16f;
            buttonX_SaveTable.TextColor = System.Drawing.Color.White;
            buttonX_SaveTable.Click += new System.EventHandler(buttonX_SaveTable_Click);
            Button_Back.AccessibleDescription = null;
            Button_Back.AccessibleName = null;
            Button_Back.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(Button_Back, "Button_Back");
            Button_Back.BackgroundImage = null;
            Button_Back.Checked = true;
            Button_Back.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            Button_Back.CommandParameter = null;
            Button_Back.Name = "Button_Back";
            Button_Back.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            Button_Back.Symbol = "\uf00d";
            Button_Back.SymbolSize = 16f;
            Button_Back.TextColor = System.Drawing.Color.Navy;
            Button_Back.Click += new System.EventHandler(Button_Back_Click);
            txtTablesBoys.AccessibleDescription = null;
            txtTablesBoys.AccessibleName = null;
            txtTablesBoys.AllowEmptyState = false;
            resources.ApplyResources(txtTablesBoys, "txtTablesBoys");
            txtTablesBoys.BackgroundImage = null;
            txtTablesBoys.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            txtTablesBoys.BackgroundStyle.Class = "DateTimeInputBackground";
            txtTablesBoys.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            txtTablesBoys.ButtonCalculator.DisplayPosition = (int)resources.GetObject("txtTablesBoys.ButtonCalculator.DisplayPosition");
            txtTablesBoys.ButtonCalculator.Image = null;
            txtTablesBoys.ButtonCalculator.Text = resources.GetString("txtTablesBoys.ButtonCalculator.Text");
            txtTablesBoys.ButtonClear.DisplayPosition = (int)resources.GetObject("txtTablesBoys.ButtonClear.DisplayPosition");
            txtTablesBoys.ButtonClear.Image = null;
            txtTablesBoys.ButtonClear.Text = resources.GetString("txtTablesBoys.ButtonClear.Text");
            txtTablesBoys.ButtonCustom.DisplayPosition = (int)resources.GetObject("txtTablesBoys.ButtonCustom.DisplayPosition");
            txtTablesBoys.ButtonCustom.Image = null;
            txtTablesBoys.ButtonCustom.Text = resources.GetString("txtTablesBoys.ButtonCustom.Text");
            txtTablesBoys.ButtonCustom2.DisplayPosition = (int)resources.GetObject("txtTablesBoys.ButtonCustom2.DisplayPosition");
            txtTablesBoys.ButtonCustom2.Image = null;
            txtTablesBoys.ButtonCustom2.Text = resources.GetString("txtTablesBoys.ButtonCustom2.Text");
            txtTablesBoys.ButtonDropDown.DisplayPosition = (int)resources.GetObject("txtTablesBoys.ButtonDropDown.DisplayPosition");
            txtTablesBoys.ButtonDropDown.Image = null;
            txtTablesBoys.ButtonDropDown.Text = resources.GetString("txtTablesBoys.ButtonDropDown.Text");
            txtTablesBoys.ButtonFreeText.DisplayPosition = (int)resources.GetObject("txtTablesBoys.ButtonFreeText.DisplayPosition");
            txtTablesBoys.ButtonFreeText.Image = null;
            txtTablesBoys.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            txtTablesBoys.ButtonFreeText.Text = resources.GetString("txtTablesBoys.ButtonFreeText.Text");
            txtTablesBoys.CommandParameter = null;
            txtTablesBoys.DisplayFormat = "0";
            txtTablesBoys.FocusHighlightEnabled = true;
            txtTablesBoys.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            txtTablesBoys.MinValue = 0;
            txtTablesBoys.Name = "txtTablesBoys";
            txtTablesBoys.ShowUpDown = true;
            txtTablesBoys.ValueChanged += new System.EventHandler(txtTablesBoys_ValueChanged);
            txtTablesOut.AccessibleDescription = null;
            txtTablesOut.AccessibleName = null;
            txtTablesOut.AllowEmptyState = false;
            resources.ApplyResources(txtTablesOut, "txtTablesOut");
            txtTablesOut.BackgroundImage = null;
            txtTablesOut.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            txtTablesOut.BackgroundStyle.Class = "DateTimeInputBackground";
            txtTablesOut.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            txtTablesOut.ButtonCalculator.DisplayPosition = (int)resources.GetObject("txtTablesOut.ButtonCalculator.DisplayPosition");
            txtTablesOut.ButtonCalculator.Image = null;
            txtTablesOut.ButtonCalculator.Text = resources.GetString("txtTablesOut.ButtonCalculator.Text");
            txtTablesOut.ButtonClear.DisplayPosition = (int)resources.GetObject("txtTablesOut.ButtonClear.DisplayPosition");
            txtTablesOut.ButtonClear.Image = null;
            txtTablesOut.ButtonClear.Text = resources.GetString("txtTablesOut.ButtonClear.Text");
            txtTablesOut.ButtonCustom.DisplayPosition = (int)resources.GetObject("txtTablesOut.ButtonCustom.DisplayPosition");
            txtTablesOut.ButtonCustom.Image = null;
            txtTablesOut.ButtonCustom.Text = resources.GetString("txtTablesOut.ButtonCustom.Text");
            txtTablesOut.ButtonCustom2.DisplayPosition = (int)resources.GetObject("txtTablesOut.ButtonCustom2.DisplayPosition");
            txtTablesOut.ButtonCustom2.Image = null;
            txtTablesOut.ButtonCustom2.Text = resources.GetString("txtTablesOut.ButtonCustom2.Text");
            txtTablesOut.ButtonDropDown.DisplayPosition = (int)resources.GetObject("txtTablesOut.ButtonDropDown.DisplayPosition");
            txtTablesOut.ButtonDropDown.Image = null;
            txtTablesOut.ButtonDropDown.Text = resources.GetString("txtTablesOut.ButtonDropDown.Text");
            txtTablesOut.ButtonFreeText.DisplayPosition = (int)resources.GetObject("txtTablesOut.ButtonFreeText.DisplayPosition");
            txtTablesOut.ButtonFreeText.Image = null;
            txtTablesOut.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            txtTablesOut.ButtonFreeText.Text = resources.GetString("txtTablesOut.ButtonFreeText.Text");
            txtTablesOut.CommandParameter = null;
            txtTablesOut.DisplayFormat = "0";
            txtTablesOut.FocusHighlightEnabled = true;
            txtTablesOut.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            txtTablesOut.MinValue = 0;
            txtTablesOut.Name = "txtTablesOut";
            txtTablesOut.ShowUpDown = true;
            txtTablesOut.ValueChanged += new System.EventHandler(txtTablesOut_ValueChanged);
            txtTablesOther.AccessibleDescription = null;
            txtTablesOther.AccessibleName = null;
            txtTablesOther.AllowEmptyState = false;
            resources.ApplyResources(txtTablesOther, "txtTablesOther");
            txtTablesOther.BackgroundImage = null;
            txtTablesOther.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            txtTablesOther.BackgroundStyle.Class = "DateTimeInputBackground";
            txtTablesOther.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            txtTablesOther.ButtonCalculator.DisplayPosition = (int)resources.GetObject("txtTablesOther.ButtonCalculator.DisplayPosition");
            txtTablesOther.ButtonCalculator.Image = null;
            txtTablesOther.ButtonCalculator.Text = resources.GetString("txtTablesOther.ButtonCalculator.Text");
            txtTablesOther.ButtonClear.DisplayPosition = (int)resources.GetObject("txtTablesOther.ButtonClear.DisplayPosition");
            txtTablesOther.ButtonClear.Image = null;
            txtTablesOther.ButtonClear.Text = resources.GetString("txtTablesOther.ButtonClear.Text");
            txtTablesOther.ButtonCustom.DisplayPosition = (int)resources.GetObject("txtTablesOther.ButtonCustom.DisplayPosition");
            txtTablesOther.ButtonCustom.Image = null;
            txtTablesOther.ButtonCustom.Text = resources.GetString("txtTablesOther.ButtonCustom.Text");
            txtTablesOther.ButtonCustom2.DisplayPosition = (int)resources.GetObject("txtTablesOther.ButtonCustom2.DisplayPosition");
            txtTablesOther.ButtonCustom2.Image = null;
            txtTablesOther.ButtonCustom2.Text = resources.GetString("txtTablesOther.ButtonCustom2.Text");
            txtTablesOther.ButtonDropDown.DisplayPosition = (int)resources.GetObject("txtTablesOther.ButtonDropDown.DisplayPosition");
            txtTablesOther.ButtonDropDown.Image = null;
            txtTablesOther.ButtonDropDown.Text = resources.GetString("txtTablesOther.ButtonDropDown.Text");
            txtTablesOther.ButtonFreeText.DisplayPosition = (int)resources.GetObject("txtTablesOther.ButtonFreeText.DisplayPosition");
            txtTablesOther.ButtonFreeText.Image = null;
            txtTablesOther.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            txtTablesOther.ButtonFreeText.Text = resources.GetString("txtTablesOther.ButtonFreeText.Text");
            txtTablesOther.CommandParameter = null;
            txtTablesOther.DisplayFormat = "0";
            txtTablesOther.FocusHighlightEnabled = true;
            txtTablesOther.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            txtTablesOther.MinValue = 0;
            txtTablesOther.Name = "txtTablesOther";
            txtTablesOther.ShowUpDown = true;
            txtTablesOther.ValueChanged += new System.EventHandler(txtTablesOther_ValueChanged);
            label48.AccessibleDescription = null;
            label48.AccessibleName = null;
            resources.ApplyResources(label48, "label48");
            label48.BackColor = System.Drawing.Color.Transparent;
            label48.Name = "label48";
            label51.AccessibleDescription = null;
            label51.AccessibleName = null;
            resources.ApplyResources(label51, "label51");
            label51.BackColor = System.Drawing.Color.Transparent;
            label51.Name = "label51";
            label52.AccessibleDescription = null;
            label52.AccessibleName = null;
            resources.ApplyResources(label52, "label52");
            label52.BackColor = System.Drawing.Color.Transparent;
            label52.Name = "label52";
            label54.AccessibleDescription = null;
            label54.AccessibleName = null;
            resources.ApplyResources(label54, "label54");
            label54.BackColor = System.Drawing.Color.Transparent;
            label54.Name = "label54";
            txtTablesFamily.AccessibleDescription = null;
            txtTablesFamily.AccessibleName = null;
            txtTablesFamily.AllowEmptyState = false;
            resources.ApplyResources(txtTablesFamily, "txtTablesFamily");
            txtTablesFamily.BackgroundImage = null;
            txtTablesFamily.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            txtTablesFamily.BackgroundStyle.Class = "DateTimeInputBackground";
            txtTablesFamily.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            txtTablesFamily.ButtonCalculator.DisplayPosition = (int)resources.GetObject("txtTablesFamily.ButtonCalculator.DisplayPosition");
            txtTablesFamily.ButtonCalculator.Image = null;
            txtTablesFamily.ButtonCalculator.Text = resources.GetString("txtTablesFamily.ButtonCalculator.Text");
            txtTablesFamily.ButtonClear.DisplayPosition = (int)resources.GetObject("txtTablesFamily.ButtonClear.DisplayPosition");
            txtTablesFamily.ButtonClear.Image = null;
            txtTablesFamily.ButtonClear.Text = resources.GetString("txtTablesFamily.ButtonClear.Text");
            txtTablesFamily.ButtonCustom.DisplayPosition = (int)resources.GetObject("txtTablesFamily.ButtonCustom.DisplayPosition");
            txtTablesFamily.ButtonCustom.Image = null;
            txtTablesFamily.ButtonCustom.Text = resources.GetString("txtTablesFamily.ButtonCustom.Text");
            txtTablesFamily.ButtonCustom2.DisplayPosition = (int)resources.GetObject("txtTablesFamily.ButtonCustom2.DisplayPosition");
            txtTablesFamily.ButtonCustom2.Image = null;
            txtTablesFamily.ButtonCustom2.Text = resources.GetString("txtTablesFamily.ButtonCustom2.Text");
            txtTablesFamily.ButtonDropDown.DisplayPosition = (int)resources.GetObject("txtTablesFamily.ButtonDropDown.DisplayPosition");
            txtTablesFamily.ButtonDropDown.Image = null;
            txtTablesFamily.ButtonDropDown.Text = resources.GetString("txtTablesFamily.ButtonDropDown.Text");
            txtTablesFamily.ButtonFreeText.DisplayPosition = (int)resources.GetObject("txtTablesFamily.ButtonFreeText.DisplayPosition");
            txtTablesFamily.ButtonFreeText.Image = null;
            txtTablesFamily.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            txtTablesFamily.ButtonFreeText.Text = resources.GetString("txtTablesFamily.ButtonFreeText.Text");
            txtTablesFamily.CommandParameter = null;
            txtTablesFamily.DisplayFormat = "0";
            txtTablesFamily.FocusHighlightEnabled = true;
            txtTablesFamily.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            txtTablesFamily.MinValue = 0;
            txtTablesFamily.Name = "txtTablesFamily";
            txtTablesFamily.ShowUpDown = true;
            txtTablesFamily.ValueChanged += new System.EventHandler(txtTablesFamily_ValueChanged);
            employeeCard1.AccessibleDescription = null;
            employeeCard1.AccessibleName = null;
            resources.ApplyResources(employeeCard1, "employeeCard1");
            employeeCard1.BackColor = System.Drawing.Color.White;
            employeeCard1.BackgroundImage = null;
            employeeCard1.EmployeeBlog = "????????????????????";
            employeeCard1.EmployeeName = "RoomNo";
            employeeCard1.EmployeePhone = "????????????????????";
            employeeCard1.EmployeeTitle = "?????????????? ";
            employeeCard1.Expanded = false;
            employeeCard1.Font = null;
            employeeCard1.Name = "employeeCard1";
            base.AccessibleDescription = null;
            base.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.AliceBlue;
            BackgroundImage = null;
            base.Controls.Add(TreeGX_Tables);
            base.Controls.Add(panel_Head);
            base.Controls.Add(expandablePanel_Table);
            Font = null;
            base.KeyPreview = true;
            base.MinimizeBox = false;
            base.Name = "FrmTableManage";
            base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            base.Load += new System.EventHandler(FrmTableManage_Load);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmTableManage_KeyDown);
            panel_Head.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)TreeGX_Tables).EndInit();
            expandablePanel_Table.ResumeLayout(false);
            expandablePanel_Table.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtTablesBoys).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtTablesOut).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtTablesOther).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtTablesFamily).EndInit();
            ResumeLayout(false);
        }
    }
}
