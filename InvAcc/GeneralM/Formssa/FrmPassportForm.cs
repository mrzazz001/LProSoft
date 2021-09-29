//
using CrystalDecisions.CrystalReports.Engine;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using DevComponents.Editors.DateTimeAdv;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmPassportForm : Form
    {
        public class ColumnDictinary
        {
            public string AText = "";
            public ColumnDictinary(string aText)
            {
                AText = aText;
            }
        }
        public partial class FamilyPassport
        {
            public string IND = "";
            public string ID = "";
            public string name = "";
            public string BornDate = "";
            public string Link = "";
            public string PassNo = "";
            public string PassEnd = "";
            public string EnteryPort = "";
            public string EnteryNo = "";
            public familyPassport(string ind, string id, string nam, string borndate, string link, string passno, string passend, string enteryport, string enteryno)
            {
                IND = ind;
                ID = id;
                name = nam;
                BornDate = borndate;
                Link = link;
                PassNo = passno;
                PassEnd = passend;
                EnteryPort = enteryport;
                EnteryNo = enteryno;
            }
        }
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private Dictionary<long, familyPassport> vFamilyPassport = new Dictionary<long, familyPassport>();
        private Dictionary<string, ColumnDictinary> Dir_ButSearch = new Dictionary<string, ColumnDictinary>();
        private int LangArEn = 0;
        private bool relaystate = false;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
        private string FlagUpdate = "";
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private T_Emp data_this;
        private Stock_DataDataContext dbInstance;
        private ReportDocument MainCryRep = new ReportDocument();
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
        protected PanelEx Main_Panel;
        private CheckBox checkBox_CreateIdentity;
        private Panel panel1;
        private ComboBox comboBox_IDMonths;
        private Label label1;
        private ComboBox comboBox_ID;
        private Label label3;
        private CheckBox checkBox_CreatePassport;
        private Panel panel2;
        private Label label4;
        private ComboBox comboBox_PassportDay;
        private Label label5;
        private ComboBox comboBox_Passport;
        private Label label2;
        private Label label6;
        private CheckBox checkBox_SponsorTransfer;
        private Panel panel3;
        private Label label8;
        private ComboBox comboBox_GuarTrans;
        private Label label7;
        private CheckBox checkBox_AddExtension;
        private TextBox textBox_Others;
        private Panel panel5;
        private Label label97;
        private TextBox textBox_ID_No;
        private Label label9;
        private TextBox textBox_SponsorID;
        private Label label92;
        private Panel panel6;
        private Label label12;
        private Label label13;
        private TextBox textBox_PortEntry;
        private Label label11;
        private Label label10;
        private TextBox textBox_NoBorderEntery;
        private Panel panel7;
        private ComboBox comboBox_EmpNo;
        private Label label14;
        private Label label15;
        private TextBox textBox_FristNameA;
        private Label label17;
        private Label label16;
        private TextBox textBox_FatherA;
        private TextBox textBox_GrandA;
        private Label label18;
        private TextBox textBox_FamilyA;
        private Label label19;
        private TextBox textBox_FamilyE;
        private Label label20;
        private Label label21;
        private TextBox textBox_FatherE;
        private TextBox textBox_GrandE;
        private Label label23;
        private TextBox textBox_FirstNameE;
        private Label label24;
        private TextBox textBox_Nationalty;
        private Label label27;
        private Label label26;
        private TextBox textBox_Religon;
        private Label label25;
        private TextBox textBox_Job;
        private Label label30;
        private Label label29;
        private Label label28;
        private TextBox textBox_PassportNo;
        private Label label31;
        private TextBox textBox_PassportCreatePlace;
        private Panel panel8;
        private Label label33;
        private TextBox textBox_Address;
        private ComboBox comboBox_SponsorName;
        private Label label32;
        private RadioButton radioButton_PersonSide;
        private RadioButton radioButton_CompanySide;
        private RadioButton radioButton_FoundationSide;
        private RadioButton radioButton_GovSide;
        private Label label34;
        private TextBox textBox_Tel;
        private TextBox textBox_ID;
        private MaskedTextBox dateTimeInput_ID_DateEnd;
        private MaskedTextBox dateTimeInput_EntryDate;
        private MaskedTextBox dateTimeInput_PassportEndDate;
        private ExpandablePanel expandablePanel_Escorts;
        private Panel panel10;
        private MaskedTextBox dateTimeInput_BirthDate;
        private MaskedTextBox dateTimeInput_PassportCreateDate;
        private Panel panel4;
        private Panel panel11;
        private Label label45;
        private Label label46;
        private TextBox textBox_EnterNo15;
        private TextBox textBox_Port15;
        private TextBox textBox_EnterNo14;
        private TextBox textBox_Port14;
        private TextBox textBox_EnterNo13;
        private TextBox textBox_Port13;
        private TextBox textBox_EnterNo12;
        private TextBox textBox_Port12;
        private TextBox textBox_EnterNo11;
        private TextBox textBox_Port11;
        private TextBox textBox_EnterNo10;
        private TextBox textBox_Port10;
        private TextBox textBox_EnterNo9;
        private TextBox textBox_Port9;
        private TextBox textBox_EnterNo8;
        private TextBox textBox_Port8;
        private TextBox textBox_EnterNo7;
        private TextBox textBox_Port7;
        private TextBox textBox_EnterNo6;
        private TextBox textBox_Port6;
        private TextBox textBox_EnterNo5;
        private TextBox textBox_Port5;
        private TextBox textBox_EnterNo4;
        private TextBox textBox_Port4;
        private TextBox textBox_EnterNo3;
        private TextBox textBox_Port3;
        private TextBox textBox_EnterNo2;
        private TextBox textBox_Port2;
        private TextBox textBox_EnterNo1;
        private TextBox textBox_Port1;
        private MaskedTextBox dateTimeInput_PassportDateEnd15;
        private MaskedTextBox dateTimeInput_PassportDateEnd14;
        private MaskedTextBox dateTimeInput_PassportDateEnd13;
        private MaskedTextBox dateTimeInput_PassportDateEnd12;
        private MaskedTextBox dateTimeInput_PassportDateEnd11;
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
        private MaskedTextBox dateTimeInput_BirthDate15;
        private MaskedTextBox dateTimeInput_BirthDate14;
        private MaskedTextBox dateTimeInput_BirthDate13;
        private MaskedTextBox dateTimeInput_BirthDate12;
        private MaskedTextBox dateTimeInput_BirthDate11;
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
        private Label label40;
        private Label label41;
        private Label label42;
        private Label label43;
        private TextBox textBox_PassporntNo15;
        private TextBox textBox_Relation15;
        private TextBox textBox_Name15;
        private TextBox textBox_PassporntNo14;
        private TextBox textBox_Relation14;
        private TextBox textBox_Name14;
        private TextBox textBox_PassporntNo13;
        private TextBox textBox_Relation13;
        private TextBox textBox_Name13;
        private TextBox textBox_PassporntNo12;
        private TextBox textBox_Relation12;
        private TextBox textBox_Name12;
        private TextBox textBox_PassporntNo11;
        private TextBox textBox_Relation11;
        private TextBox textBox_Name11;
        private TextBox textBox_PassporntNo10;
        private TextBox textBox_Relation10;
        private TextBox textBox_Name10;
        private TextBox textBox_PassporntNo9;
        private TextBox textBox_Relation9;
        private TextBox textBox_Name9;
        private TextBox textBox_PassporntNo8;
        private TextBox textBox_Relation8;
        private TextBox textBox_Name8;
        private TextBox textBox_PassporntNo7;
        private TextBox textBox_Relation7;
        private TextBox textBox_Name7;
        private TextBox textBox_PassporntNo6;
        private TextBox textBox_Relation6;
        private TextBox textBox_Name6;
        private TextBox textBox_PassporntNo5;
        private TextBox textBox_Relation5;
        private TextBox textBox_Name5;
        private TextBox textBox_PassporntNo4;
        private TextBox textBox_Relation4;
        private TextBox textBox_Name4;
        private TextBox textBox_PassporntNo3;
        private TextBox textBox_Relation3;
        private TextBox textBox_Name3;
        private TextBox textBox_PassporntNo2;
        private TextBox textBox_Relation2;
        private TextBox textBox_Name2;
        private TextBox textBox_PassporntNo1;
        private TextBox textBox_Relation1;
        private TextBox textBox_Name1;
        private Label label44;
        private DataGridView dataGridView_Family;
        private DataGridViewTextBoxColumn IND;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn BornDate;
        private DataGridViewTextBoxColumn Link;
        private DataGridViewTextBoxColumn PassNo;
        private DataGridViewTextBoxColumn PassEnd;
        private DataGridViewTextBoxColumn EnteryPort;
        private DataGridViewTextBoxColumn EnteryNo;
        private Label label39;
        private TextBox textBox_Place;
        private Panel panel9;
        private Label label38;
        private TextBox textBox_NewSponsorNo;
        private Label label35;
        private TextBox textBox_TelTransfer;
        private Label label36;
        private TextBox textBox_AddressTransfer;
        private Label label37;
        private RadioButton radioButton_PersonSideTransfer;
        private RadioButton radioButton_CompanySideTransfer;
        private RadioButton radioButton_FoundationSideTransfer;
        private RadioButton radioButton_GovSideTransfer;
        private ComboBox comboBox_SponsorNameTransfer;
        private ButtonX button_Family;
        private Label label22;
        private Label label47;
        private Label label48;
        private Panel panel12;
        private Label label49;
        private Label label50;
        private ButtonX button_Exit;
        private ButtonX button_Print;
        private ButtonX button_Back;
        public bool RelayState
        {
            get
            {
                return relaystate;
            }
            set
            {
                relaystate = value;
            }
        }
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
        public T_Emp DataThis
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
        public FrmPassportForm()
        {
            InitializeComponent();
            dateTimeInput_BirthDate1.Click += dateTimeInput_BirthDate1_Click;
            dateTimeInput_BirthDate2.Click += dateTimeInput_BirthDate2_Click;
            dateTimeInput_BirthDate3.Click += dateTimeInput_BirthDate3_Click;
            dateTimeInput_BirthDate4.Click += dateTimeInput_BirthDate4_Click;
            dateTimeInput_BirthDate5.Click += dateTimeInput_BirthDate5_Click;
            dateTimeInput_BirthDate6.Click += dateTimeInput_BirthDate6_Click;
            dateTimeInput_BirthDate7.Click += dateTimeInput_BirthDate7_Click;
            dateTimeInput_BirthDate8.Click += dateTimeInput_BirthDate8_Click;
            dateTimeInput_BirthDate9.Click += dateTimeInput_BirthDate9_Click;
            dateTimeInput_BirthDate10.Click += dateTimeInput_BirthDate10_Click;
            dateTimeInput_BirthDate11.Click += dateTimeInput_BirthDate11_Click;
            dateTimeInput_BirthDate12.Click += dateTimeInput_BirthDate12_Click;
            dateTimeInput_BirthDate13.Click += dateTimeInput_BirthDate13_Click;
            dateTimeInput_BirthDate14.Click += dateTimeInput_BirthDate14_Click;
            dateTimeInput_BirthDate15.Click += dateTimeInput_BirthDate15_Click;
            dateTimeInput_PassportDateEnd1.Click += dateTimeInput_PassportDateEnd1_Click;
            dateTimeInput_PassportDateEnd2.Click += dateTimeInput_PassportDateEnd2_Click;
            dateTimeInput_PassportDateEnd3.Click += dateTimeInput_PassportDateEnd3_Click;
            dateTimeInput_PassportDateEnd4.Click += dateTimeInput_PassportDateEnd4_Click;
            dateTimeInput_PassportDateEnd5.Click += dateTimeInput_PassportDateEnd5_Click;
            dateTimeInput_PassportDateEnd6.Click += dateTimeInput_PassportDateEnd6_Click;
            dateTimeInput_PassportDateEnd7.Click += dateTimeInput_PassportDateEnd7_Click;
            dateTimeInput_PassportDateEnd8.Click += dateTimeInput_PassportDateEnd8_Click;
            dateTimeInput_PassportDateEnd9.Click += dateTimeInput_PassportDateEnd9_Click;
            dateTimeInput_PassportDateEnd10.Click += dateTimeInput_PassportDateEnd10_Click;
            dateTimeInput_PassportDateEnd11.Click += dateTimeInput_PassportDateEnd11_Click;
            dateTimeInput_PassportDateEnd12.Click += dateTimeInput_PassportDateEnd12_Click;
            dateTimeInput_PassportDateEnd13.Click += dateTimeInput_PassportDateEnd13_Click;
            dateTimeInput_PassportDateEnd14.Click += dateTimeInput_PassportDateEnd14_Click;
            dateTimeInput_PassportDateEnd15.Click += dateTimeInput_PassportDateEnd15_Click;
            dateTimeInput_BirthDate1.Leave += dateTimeInput_BirthDate1_Leave;
            dateTimeInput_BirthDate2.Leave += dateTimeInput_BirthDate2_Leave;
            dateTimeInput_BirthDate3.Leave += dateTimeInput_BirthDate3_Leave;
            dateTimeInput_BirthDate4.Leave += dateTimeInput_BirthDate4_Leave;
            dateTimeInput_BirthDate5.Leave += dateTimeInput_BirthDate5_Leave;
            dateTimeInput_BirthDate6.Leave += dateTimeInput_BirthDate6_Leave;
            dateTimeInput_BirthDate7.Leave += dateTimeInput_BirthDate7_Leave;
            dateTimeInput_BirthDate8.Leave += dateTimeInput_BirthDate8_Leave;
            dateTimeInput_BirthDate9.Leave += dateTimeInput_BirthDate9_Leave;
            dateTimeInput_BirthDate10.Leave += dateTimeInput_BirthDate10_Leave;
            dateTimeInput_BirthDate11.Leave += dateTimeInput_BirthDate11_Leave;
            dateTimeInput_BirthDate12.Leave += dateTimeInput_BirthDate12_Leave;
            dateTimeInput_BirthDate13.Leave += dateTimeInput_BirthDate13_Leave;
            dateTimeInput_BirthDate14.Leave += dateTimeInput_BirthDate14_Leave;
            dateTimeInput_BirthDate15.Leave += dateTimeInput_BirthDate15_Leave;
            dateTimeInput_PassportDateEnd1.Leave += dateTimeInput_PassportDateEnd1_Leave;
            dateTimeInput_PassportDateEnd2.Leave += dateTimeInput_PassportDateEnd2_Leave;
            dateTimeInput_PassportDateEnd3.Leave += dateTimeInput_PassportDateEnd3_Leave;
            dateTimeInput_PassportDateEnd4.Leave += dateTimeInput_PassportDateEnd4_Leave;
            dateTimeInput_PassportDateEnd5.Leave += dateTimeInput_PassportDateEnd5_Leave;
            dateTimeInput_PassportDateEnd6.Leave += dateTimeInput_PassportDateEnd6_Leave;
            dateTimeInput_PassportDateEnd7.Leave += dateTimeInput_PassportDateEnd7_Leave;
            dateTimeInput_PassportDateEnd8.Leave += dateTimeInput_PassportDateEnd8_Leave;
            dateTimeInput_PassportDateEnd9.Leave += dateTimeInput_PassportDateEnd9_Leave;
            dateTimeInput_PassportDateEnd10.Leave += dateTimeInput_PassportDateEnd10_Leave;
            dateTimeInput_PassportDateEnd11.Leave += dateTimeInput_PassportDateEnd11_Leave;
            dateTimeInput_PassportDateEnd12.Leave += dateTimeInput_PassportDateEnd12_Leave;
            dateTimeInput_PassportDateEnd13.Leave += dateTimeInput_PassportDateEnd13_Leave;
            dateTimeInput_PassportDateEnd14.Leave += dateTimeInput_PassportDateEnd14_Leave;
            dateTimeInput_PassportDateEnd15.Leave += dateTimeInput_PassportDateEnd15_Leave;
            dateTimeInput_BirthDate1.Click += dateTimeInput_BirthDate1_Click;
            dateTimeInput_BirthDate1.Click += dateTimeInput_BirthDate1_Click;
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmPassportForm));
                if (base.Parent.RightToLeft == RightToLeft.Yes)
                {
                    Language.ChangeLanguage("ar-SA", this, resources);
                    LangArEn = 0;
                }
                else
                {
                    Language.ChangeLanguage("en", this, resources);
                    LangArEn = 1;
                }
            }
            RibunButtons();
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
                expandablePanel_Escorts.TitleText = "المرافقين";
                button_Print.Text = "طبـــاعة";
                button_Exit.Text = "خـــروج";
                button_Family.Text = "طبـــاعة";
                button_Back.Text = "رجــــوع";
                Text = "تعبئة إستمارة الجوازات";
            }
            else
            {
                expandablePanel_Escorts.TitleText = "Escorts";
                button_Print.Text = "Print";
                button_Exit.Text = "Close";
                button_Family.Text = "Print";
                button_Back.Text = "Back";
                Text = "Passport Form";
            }
        }
        private void FrmPassportForm_Load(object sender, EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmPassportForm));
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
            comboBox_EmpNo.SelectedValueChanged -= comboBox_EmpNo_SelectedValueChanged;
            comboBox_SponsorName.SelectedValueChanged -= comboBox_SponsorName_SelectedValueChanged;
            comboBox_SponsorNameTransfer.SelectedValueChanged -= comboBox_SponsorNameTransfer_SelectedValueChanged;
            try
            {
                ADD_Controls();
                RibunButtons();
                FillCombo();
                Clear();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FrmPassport_Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            comboBox_EmpNo.SelectedValueChanged += comboBox_EmpNo_SelectedValueChanged;
            comboBox_SponsorName.SelectedValueChanged += comboBox_SponsorName_SelectedValueChanged;
            comboBox_SponsorNameTransfer.SelectedValueChanged += comboBox_SponsorNameTransfer_SelectedValueChanged;
        }
        private void ADD_Controls()
        {
            try
            {
                controls = new List<Control>();
                controls.Add(textBox_ID);
                codeControl = textBox_ID;
                controls.Add(textBox_Address);
                controls.Add(textBox_AddressTransfer);
                controls.Add(textBox_Others);
                controls.Add(textBox_FamilyA);
                controls.Add(textBox_FamilyE);
                controls.Add(textBox_FatherA);
                controls.Add(textBox_FatherE);
                controls.Add(textBox_FirstNameE);
                controls.Add(textBox_FristNameA);
                controls.Add(textBox_GrandA);
                controls.Add(textBox_GrandE);
                controls.Add(textBox_ID_No);
                controls.Add(textBox_Job);
                controls.Add(textBox_Place);
                controls.Add(textBox_Nationalty);
                controls.Add(textBox_NewSponsorNo);
                controls.Add(textBox_NoBorderEntery);
                controls.Add(textBox_PassportCreatePlace);
                controls.Add(textBox_PassportNo);
                controls.Add(textBox_PortEntry);
                controls.Add(textBox_Religon);
                controls.Add(textBox_SponsorID);
                controls.Add(textBox_Tel);
                controls.Add(textBox_TelTransfer);
                controls.Add(dateTimeInput_BirthDate);
                controls.Add(dateTimeInput_EntryDate);
                controls.Add(dateTimeInput_ID_DateEnd);
                controls.Add(dateTimeInput_PassportCreateDate);
                controls.Add(dateTimeInput_PassportEndDate);
                controls.Add(comboBox_EmpNo);
                controls.Add(comboBox_GuarTrans);
                controls.Add(comboBox_ID);
                controls.Add(comboBox_IDMonths);
                controls.Add(comboBox_Passport);
                controls.Add(comboBox_PassportDay);
                controls.Add(comboBox_SponsorName);
                controls.Add(comboBox_SponsorNameTransfer);
                controls.Add(checkBox_AddExtension);
                controls.Add(checkBox_CreateIdentity);
                controls.Add(checkBox_CreatePassport);
                controls.Add(checkBox_SponsorTransfer);
                controls.Add(radioButton_CompanySide);
                controls.Add(radioButton_CompanySideTransfer);
                controls.Add(radioButton_FoundationSide);
                controls.Add(radioButton_FoundationSideTransfer);
                controls.Add(radioButton_GovSide);
                controls.Add(radioButton_GovSideTransfer);
                controls.Add(radioButton_PersonSide);
                controls.Add(radioButton_PersonSideTransfer);
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
                controls.Add(dateTimeInput_BirthDate11);
                controls.Add(dateTimeInput_BirthDate12);
                controls.Add(dateTimeInput_BirthDate13);
                controls.Add(dateTimeInput_BirthDate14);
                controls.Add(dateTimeInput_BirthDate15);
                controls.Add(dateTimeInput_PassportDateEnd1);
                controls.Add(dateTimeInput_PassportDateEnd2);
                controls.Add(dateTimeInput_PassportDateEnd3);
                controls.Add(dateTimeInput_PassportDateEnd4);
                controls.Add(dateTimeInput_PassportDateEnd5);
                controls.Add(dateTimeInput_PassportDateEnd6);
                controls.Add(dateTimeInput_PassportDateEnd6);
                controls.Add(dateTimeInput_PassportDateEnd6);
                controls.Add(dateTimeInput_PassportDateEnd9);
                controls.Add(dateTimeInput_PassportDateEnd10);
                controls.Add(dateTimeInput_PassportDateEnd11);
                controls.Add(dateTimeInput_PassportDateEnd12);
                controls.Add(dateTimeInput_PassportDateEnd13);
                controls.Add(dateTimeInput_PassportDateEnd14);
                controls.Add(dateTimeInput_PassportDateEnd15);
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
                controls.Add(textBox_Name11);
                controls.Add(textBox_Name12);
                controls.Add(textBox_Name13);
                controls.Add(textBox_Name14);
                controls.Add(textBox_Name15);
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
                controls.Add(textBox_PassporntNo11);
                controls.Add(textBox_PassporntNo12);
                controls.Add(textBox_PassporntNo13);
                controls.Add(textBox_PassporntNo14);
                controls.Add(textBox_PassporntNo15);
                controls.Add(textBox_Relation1);
                controls.Add(textBox_Relation2);
                controls.Add(textBox_Relation3);
                controls.Add(textBox_Relation4);
                controls.Add(textBox_Relation5);
                controls.Add(textBox_Relation6);
                controls.Add(textBox_Relation7);
                controls.Add(textBox_Relation8);
                controls.Add(textBox_Relation9);
                controls.Add(textBox_Relation10);
                controls.Add(textBox_Relation11);
                controls.Add(textBox_Relation12);
                controls.Add(textBox_Relation13);
                controls.Add(textBox_Relation14);
                controls.Add(textBox_Relation15);
                controls.Add(textBox_Port1);
                controls.Add(textBox_Port2);
                controls.Add(textBox_Port3);
                controls.Add(textBox_Port4);
                controls.Add(textBox_Port5);
                controls.Add(textBox_Port6);
                controls.Add(textBox_Port7);
                controls.Add(textBox_Port8);
                controls.Add(textBox_Port9);
                controls.Add(textBox_Port10);
                controls.Add(textBox_Port11);
                controls.Add(textBox_Port12);
                controls.Add(textBox_Port13);
                controls.Add(textBox_Port14);
                controls.Add(textBox_Port15);
                controls.Add(textBox_EnterNo1);
                controls.Add(textBox_EnterNo2);
                controls.Add(textBox_EnterNo3);
                controls.Add(textBox_EnterNo4);
                controls.Add(textBox_EnterNo5);
                controls.Add(textBox_EnterNo6);
                controls.Add(textBox_EnterNo7);
                controls.Add(textBox_EnterNo8);
                controls.Add(textBox_EnterNo9);
                controls.Add(textBox_EnterNo10);
                controls.Add(textBox_EnterNo11);
                controls.Add(textBox_EnterNo12);
                controls.Add(textBox_EnterNo13);
                controls.Add(textBox_EnterNo14);
                controls.Add(textBox_EnterNo15);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("ADD_Controls:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        public void Clear()
        {
            data_this = new T_Emp();
            for (int i = 0; i < controls.Count; i++)
            {
                if (controls[i].GetType() == typeof(DateTimePicker))
                {
                    int? calendr = VarGeneral.Settings_Sys.Calendr;
                    if (calendr.Value == 0 && calendr.HasValue)
                    {
                        (controls[i] as DateTimePicker).Text = VarGeneral.Gdate;
                    }
                    else
                    {
                        (controls[i] as DateTimePicker).Text = VarGeneral.Hdate;
                    }
                }
                else if (controls[i].GetType() == typeof(DateTimeInput))
                {
                    (controls[i] as DateTimeInput).Value = DateTime.Now;
                }
                else if (controls[i].GetType() == typeof(ComboBox) && (controls[i] as ComboBox).Items.Count > 0)
                {
                    try
                    {
                        (controls[i] as ComboBox).SelectedIndex = -1;
                    }
                    catch
                    {
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
                }
            }
        }
        public void FillCombo()
        {
            List<T_Emp> listEmps = new List<T_Emp>(db.T_Emps.Where((T_Emp item) => item.EmpState == (bool?)true).ToList());
            listEmps.Insert(0, new T_Emp());
            comboBox_EmpNo.DataSource = listEmps;
            comboBox_EmpNo.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_EmpNo.ValueMember = "Emp_ID";
            List<T_Guarantor> listGuarantor = new List<T_Guarantor>(db.T_Guarantors.Select((T_Guarantor item) => item).ToList());
            listGuarantor.Insert(0, new T_Guarantor());
            comboBox_SponsorName.DataSource = listGuarantor;
            comboBox_SponsorName.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_SponsorName.ValueMember = "Guarantor_No";
            List<T_Guarantor> listGuarantor2 = new List<T_Guarantor>(db.T_Guarantors.Select((T_Guarantor item) => item).ToList());
            listGuarantor2.Insert(0, new T_Guarantor());
            comboBox_SponsorNameTransfer.DataSource = listGuarantor2;
            comboBox_SponsorNameTransfer.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_SponsorNameTransfer.ValueMember = "Guarantor_No";
        }
        public void SetData(T_Emp value)
        {
            string[] names = value.NameA.Split(' ');
            string[] namesE = value.NameE.Split(' ');
            try
            {
                if (names.Count() > 0)
                {
                    textBox_FristNameA.Text = names[0];
                }
                else
                {
                    textBox_FristNameA.Text = "";
                }
            }
            catch
            {
                textBox_FristNameA.Text = "";
            }
            try
            {
                if (names.Count() > 1)
                {
                    textBox_FatherA.Text = names[1];
                }
                else
                {
                    textBox_FatherA.Text = "";
                }
            }
            catch
            {
                textBox_FatherA.Text = "";
            }
            try
            {
                if (names.Count() > 2)
                {
                    textBox_GrandA.Text = names[2];
                }
                else
                {
                    textBox_GrandA.Text = "";
                }
            }
            catch
            {
                textBox_GrandA.Text = "";
            }
            try
            {
                if (names.Count() > 0)
                {
                    textBox_FamilyA.Text = names.Last();
                }
                else
                {
                    textBox_FamilyA.Text = "";
                }
            }
            catch
            {
                textBox_FamilyA.Text = "";
            }
            try
            {
                if (namesE.Count() > 0)
                {
                    textBox_FirstNameE.Text = namesE[0];
                }
                else
                {
                    textBox_FirstNameE.Text = "";
                }
            }
            catch
            {
                textBox_FirstNameE.Text = "";
            }
            try
            {
                if (namesE.Count() > 1)
                {
                    textBox_FatherE.Text = namesE[1];
                }
                else
                {
                    textBox_FatherE.Text = "";
                }
            }
            catch
            {
                textBox_FatherE.Text = "";
            }
            try
            {
                if (namesE.Count() > 2)
                {
                    textBox_GrandE.Text = namesE[2];
                }
                else
                {
                    textBox_GrandE.Text = "";
                }
            }
            catch
            {
                textBox_GrandE.Text = "";
            }
            try
            {
                if (namesE.Count() > 0)
                {
                    textBox_FamilyE.Text = namesE.Last();
                }
                else
                {
                    textBox_FamilyE.Text = "";
                }
            }
            catch
            {
                textBox_FamilyE.Text = "";
            }
            if (value.Nationalty.HasValue)
            {
                textBox_Nationalty.Text = ((LangArEn == 0) ? value.T_Nationality.NameA : value.T_Nationality.NameE);
            }
            if (value.Job.HasValue)
            {
                textBox_Job.Text = ((LangArEn == 0) ? value.T_Job.NameA : value.T_Job.NameE);
            }
            if (value.Religion.HasValue)
            {
                textBox_Religon.Text = ((LangArEn == 0) ? value.T_Religion.NameA : value.T_Religion.NameE);
            }
            if (VarGeneral.CheckDate(value.BirthDate))
            {
                dateTimeInput_BirthDate.Text = value.BirthDate;
            }
            else
            {
                dateTimeInput_BirthDate.Text = "";
            }
            textBox_PassportNo.Text = value.Passport_No;
            if (VarGeneral.CheckDate(value.Passport_Date))
            {
                dateTimeInput_PassportCreateDate.Text = value.Passport_Date;
            }
            else
            {
                dateTimeInput_PassportCreateDate.Text = "";
            }
            if (VarGeneral.CheckDate(value.Passport_DateEnd))
            {
                dateTimeInput_PassportEndDate.Text = value.Passport_DateEnd;
            }
            else
            {
                dateTimeInput_PassportEndDate.Text = "";
            }
            try
            {
                textBox_PassportCreatePlace.Text = ((LangArEn == 0) ? value.T_City2.NameA : value.T_City.NameE);
            }
            catch
            {
                textBox_PassportCreatePlace.Text = "";
            }
            try
            {
                if (value.Guarantor.HasValue)
                {
                    comboBox_SponsorName.SelectedValue = value.Guarantor;
                    comboBox_SponsorName_SelectedValueChanged(null, null);
                }
            }
            catch
            {
            }
            textBox_ID_No.Text = value.ID_No;
            if (VarGeneral.CheckDate(value.ID_DateEnd))
            {
                dateTimeInput_ID_DateEnd.Text = value.ID_DateEnd;
            }
            else
            {
                dateTimeInput_ID_DateEnd.Text = "";
            }
            textBox_NoBorderEntery.Text = value.VisaEnterNo;
            if (VarGeneral.CheckDate(value.VisaDate))
            {
                dateTimeInput_EntryDate.Text = value.VisaDate;
            }
            textBox_PortEntry.Text = value.VisaCountry;
            BindingList<T_Family> Family_line = new BindingList<T_Family>(value.T_Families);
            FillFamilyBox(Family_line);
        }
        private void FillFamilyBox(BindingList<T_Family> linesList)
        {
            if (linesList.Count <= 0)
            {
                return;
            }
            for (int i = 0; i < linesList.Count; i++)
            {
                if (i == 0)
                {
                    textBox_Name1.Text = linesList[i].Name;
                    textBox_Relation1.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate1.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate1.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd1.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd1.Text = "";
                    }
                    textBox_PassporntNo1.Text = linesList[i].PassNo;
                }
                if (i == 1)
                {
                    textBox_Name2.Text = linesList[i].Name;
                    textBox_Relation2.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate2.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate2.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd2.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd2.Text = "";
                    }
                    textBox_PassporntNo2.Text = linesList[i].PassNo;
                }
                if (i == 2)
                {
                    textBox_Name3.Text = linesList[i].Name;
                    textBox_Relation3.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate3.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate3.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd3.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd3.Text = "";
                    }
                    textBox_PassporntNo3.Text = linesList[i].PassNo;
                }
                if (i == 3)
                {
                    textBox_Name4.Text = linesList[i].Name;
                    textBox_Relation4.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate4.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate4.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd4.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd4.Text = "";
                    }
                    textBox_PassporntNo4.Text = linesList[i].PassNo;
                }
                if (i == 4)
                {
                    textBox_Name5.Text = linesList[i].Name;
                    textBox_Relation5.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate5.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate5.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd5.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd5.Text = "";
                    }
                    textBox_PassporntNo5.Text = linesList[i].PassNo;
                }
                if (i == 5)
                {
                    textBox_Name6.Text = linesList[i].Name;
                    textBox_Relation6.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate6.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate6.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd6.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd6.Text = "";
                    }
                    textBox_PassporntNo6.Text = linesList[i].PassNo;
                }
                if (i == 6)
                {
                    textBox_Name7.Text = linesList[i].Name;
                    textBox_Relation7.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate7.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate7.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd6.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd6.Text = "";
                    }
                    textBox_PassporntNo7.Text = linesList[i].PassNo;
                }
                if (i == 7)
                {
                    textBox_Name8.Text = linesList[i].Name;
                    textBox_Relation8.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate8.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate8.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd6.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd6.Text = "";
                    }
                    textBox_PassporntNo8.Text = linesList[i].PassNo;
                }
                if (i == 8)
                {
                    textBox_Name9.Text = linesList[i].Name;
                    textBox_Relation9.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate9.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate9.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd9.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd9.Text = "";
                    }
                    textBox_PassporntNo9.Text = linesList[i].PassNo;
                }
                if (i == 9)
                {
                    textBox_Name10.Text = linesList[i].Name;
                    textBox_Relation10.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate10.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate10.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd10.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd10.Text = "";
                    }
                    textBox_PassporntNo10.Text = linesList[i].PassNo;
                }
                if (i == 10)
                {
                    textBox_Name11.Text = linesList[i].Name;
                    textBox_Relation11.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate11.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate11.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd11.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd11.Text = "";
                    }
                    textBox_PassporntNo11.Text = linesList[i].PassNo;
                }
                if (i == 11)
                {
                    textBox_Name12.Text = linesList[i].Name;
                    textBox_Relation12.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate12.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate12.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd12.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd12.Text = "";
                    }
                    textBox_PassporntNo12.Text = linesList[i].PassNo;
                }
                if (i == 12)
                {
                    textBox_Name13.Text = linesList[i].Name;
                    textBox_Relation13.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate13.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate13.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd13.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd13.Text = "";
                    }
                    textBox_PassporntNo13.Text = linesList[i].PassNo;
                }
                if (i == 13)
                {
                    textBox_Name14.Text = linesList[i].Name;
                    textBox_Relation14.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate14.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate14.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd14.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd14.Text = "";
                    }
                    textBox_PassporntNo14.Text = linesList[i].PassNo;
                }
                if (i == 14)
                {
                    textBox_Name15.Text = linesList[i].Name;
                    textBox_Relation15.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate15.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate15.Text = "";
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd15.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd15.Text = "";
                    }
                    textBox_PassporntNo15.Text = linesList[i].PassNo;
                }
            }
        }
        private void comboBox_EmpNo_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_EmpNo.SelectedIndex > 0)
                {
                    if (!string.IsNullOrEmpty(comboBox_EmpNo.SelectedValue.ToString()))
                    {
                        textBox_ID.Text = comboBox_EmpNo.SelectedValue.ToString();
                    }
                }
                else
                {
                    textBox_ID.Text = "";
                    Clear();
                }
            }
            catch
            {
            }
        }
        private void textBox_ID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                T_Emp newData = db.EmpsEmp(textBox_ID.Text);
                if (newData == null || string.IsNullOrEmpty(newData.Emp_ID))
                {
                    Clear();
                }
                else
                {
                    DataThis = newData;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("textBox_ID_TextChanged:", error, enable: true);
            }
        }
        private void comboBox_SponsorNameTransfer_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_SponsorNameTransfer.SelectedIndex > 0)
                {
                    if (!string.IsNullOrEmpty(comboBox_SponsorNameTransfer.SelectedValue.ToString()))
                    {
                        T_Guarantor newData = db.GuarantorEmp(int.Parse(comboBox_SponsorNameTransfer.SelectedValue.ToString()));
                        if (newData == null || newData.Guarantor_No == 0 || string.IsNullOrEmpty(newData.Guarantor_ID))
                        {
                            textBox_NewSponsorNo.Text = "";
                            textBox_AddressTransfer.Text = "";
                            textBox_TelTransfer.Text = "";
                        }
                        else
                        {
                            textBox_NewSponsorNo.Text = newData.CodPc;
                            textBox_AddressTransfer.Text = newData.Address;
                            textBox_TelTransfer.Text = newData.Tel;
                        }
                    }
                }
                else
                {
                    textBox_NewSponsorNo.Text = "";
                    textBox_AddressTransfer.Text = "";
                    textBox_TelTransfer.Text = "";
                }
            }
            catch
            {
            }
        }
        private void comboBox_SponsorName_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_SponsorName.SelectedIndex > 0)
                {
                    if (!string.IsNullOrEmpty(comboBox_SponsorName.SelectedValue.ToString()))
                    {
                        T_Guarantor newData = db.GuarantorEmp(int.Parse(comboBox_SponsorName.SelectedValue.ToString()));
                        if (newData == null || newData.Guarantor_No == 0 || string.IsNullOrEmpty(newData.Guarantor_ID))
                        {
                            textBox_SponsorID.Text = "";
                            textBox_Address.Text = "";
                            textBox_Tel.Text = "";
                        }
                        else
                        {
                            textBox_SponsorID.Text = newData.CodPc;
                            textBox_Address.Text = newData.Address;
                            textBox_Tel.Text = newData.Tel;
                        }
                    }
                }
                else
                {
                    textBox_SponsorID.Text = "";
                    textBox_Address.Text = "";
                    textBox_Tel.Text = "";
                }
            }
            catch
            {
            }
        }
        private void button_Print_Click(object sender, EventArgs e)
        {
            try
            {
                PrintForm2();
                FrmReportsViewer frm = new FrmReportsViewer();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible_Passport.Add(kvp.Key, new FrmReportsViewer.ColumnDictinaryPassport(kvp.Value.AText));
                }
                frm.Repvalue = "PassportForms";
                VarGeneral.vTitle = Text;
                frm.TopMost = true;
                frm.ShowDialog();
                columns_Names_visible.Clear();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_Print_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private string GetRightNumber(string Txt, int PosNo)
        {
            if (Txt.Length < PosNo)
            {
                return " ";
            }
            return Txt.Substring(Txt.Length - PosNo, 1);
        }
        private void PrintForm2()
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("Nationality", new ColumnDictinary(textBox_Nationalty.Text));
            columns_Names_visible.Add("Type1", new ColumnDictinary(""));
            columns_Names_visible.Add("Type2", new ColumnDictinary(""));
            columns_Names_visible.Add("Type3", new ColumnDictinary(""));
            columns_Names_visible.Add("Type4", new ColumnDictinary(""));
            columns_Names_visible.Add("Type1_1", new ColumnDictinary(""));
            columns_Names_visible.Add("Type1_2", new ColumnDictinary(""));
            columns_Names_visible.Add("Type2_1", new ColumnDictinary(""));
            columns_Names_visible.Add("Type2_2", new ColumnDictinary(""));
            columns_Names_visible.Add("Type2_3", new ColumnDictinary(""));
            columns_Names_visible.Add("Type4_1", new ColumnDictinary(""));
            columns_Names_visible.Add("Type3_1", new ColumnDictinary(""));
            columns_Names_visible.Add("Type3_2", new ColumnDictinary(""));
            columns_Names_visible.Add("Type3_3", new ColumnDictinary(""));
            columns_Names_visible.Add("SponsorType1", new ColumnDictinary(""));
            columns_Names_visible.Add("SponsorType2", new ColumnDictinary(""));
            columns_Names_visible.Add("SponsorType3", new ColumnDictinary(""));
            columns_Names_visible.Add("SponsorType4", new ColumnDictinary(""));
            columns_Names_visible.Add("Igama_1", new ColumnDictinary(""));
            columns_Names_visible.Add("Igama_2", new ColumnDictinary(""));
            columns_Names_visible.Add("Igama_3", new ColumnDictinary(""));
            columns_Names_visible.Add("Igama_4", new ColumnDictinary(""));
            columns_Names_visible.Add("Igama_5", new ColumnDictinary(""));
            columns_Names_visible.Add("Igama_6", new ColumnDictinary(""));
            columns_Names_visible.Add("Igama_7", new ColumnDictinary(""));
            columns_Names_visible.Add("Igama_8", new ColumnDictinary(""));
            columns_Names_visible.Add("Igama_9", new ColumnDictinary(""));
            columns_Names_visible.Add("Igama_10", new ColumnDictinary(""));
            columns_Names_visible.Add("S_1", new ColumnDictinary(""));
            columns_Names_visible.Add("S_2", new ColumnDictinary(""));
            columns_Names_visible.Add("S_3", new ColumnDictinary(""));
            columns_Names_visible.Add("S_4", new ColumnDictinary(""));
            columns_Names_visible.Add("S_5", new ColumnDictinary(""));
            columns_Names_visible.Add("S_6", new ColumnDictinary(""));
            columns_Names_visible.Add("S_7", new ColumnDictinary(""));
            columns_Names_visible.Add("S_8", new ColumnDictinary(""));
            columns_Names_visible.Add("S_9", new ColumnDictinary(""));
            columns_Names_visible.Add("S_10", new ColumnDictinary(""));
            columns_Names_visible.Add("E_1", new ColumnDictinary(""));
            columns_Names_visible.Add("E_2", new ColumnDictinary(""));
            columns_Names_visible.Add("E_3", new ColumnDictinary(""));
            columns_Names_visible.Add("E_4", new ColumnDictinary(""));
            columns_Names_visible.Add("E_5", new ColumnDictinary(""));
            columns_Names_visible.Add("E_6", new ColumnDictinary(""));
            columns_Names_visible.Add("E_7", new ColumnDictinary(""));
            columns_Names_visible.Add("E_8", new ColumnDictinary(""));
            columns_Names_visible.Add("E_9", new ColumnDictinary(""));
            columns_Names_visible.Add("E_10", new ColumnDictinary(""));
            columns_Names_visible.Add("NS_1", new ColumnDictinary(""));
            columns_Names_visible.Add("NS_2", new ColumnDictinary(""));
            columns_Names_visible.Add("NS_3", new ColumnDictinary(""));
            columns_Names_visible.Add("NS_4", new ColumnDictinary(""));
            columns_Names_visible.Add("NS_5", new ColumnDictinary(""));
            columns_Names_visible.Add("NS_6", new ColumnDictinary(""));
            columns_Names_visible.Add("NS_7", new ColumnDictinary(""));
            columns_Names_visible.Add("NS_8", new ColumnDictinary(""));
            columns_Names_visible.Add("NS_9", new ColumnDictinary(""));
            columns_Names_visible.Add("NS_10", new ColumnDictinary(""));
            columns_Names_visible.Add("PassPorts", new ColumnDictinary(""));
            columns_Names_visible.Add("OrderName", new ColumnDictinary(""));
            columns_Names_visible.Add("SponsorNo", new ColumnDictinary(""));
            columns_Names_visible.Add("OrderType1", new ColumnDictinary(""));
            columns_Names_visible.Add("OrderType2", new ColumnDictinary(""));
            columns_Names_visible.Add("OrderType3", new ColumnDictinary(""));
            columns_Names_visible.Add("OrderType4", new ColumnDictinary(""));
            columns_Names_visible.Add("OrderType1_1", new ColumnDictinary(""));
            columns_Names_visible.Add("OrderType1_2", new ColumnDictinary(""));
            columns_Names_visible.Add("OrderType1_3", new ColumnDictinary(""));
            columns_Names_visible.Add("OrderType2_1", new ColumnDictinary(""));
            columns_Names_visible.Add("OrderType2_2", new ColumnDictinary(""));
            columns_Names_visible.Add("OrderType2_3", new ColumnDictinary(""));
            columns_Names_visible.Add("OrderType2_4", new ColumnDictinary(""));
            columns_Names_visible.Add("OrderType3_1", new ColumnDictinary(""));
            columns_Names_visible.Add("OrderType3_2", new ColumnDictinary(""));
            columns_Names_visible.Add("OrderType3_3", new ColumnDictinary(""));
            columns_Names_visible.Add("OrderType3_4", new ColumnDictinary(""));
            columns_Names_visible.Add("IgamaExpire", new ColumnDictinary(""));
            columns_Names_visible.Add("EnteryDate", new ColumnDictinary(""));
            columns_Names_visible.Add("EnteryPort", new ColumnDictinary(""));
            columns_Names_visible.Add("fName", new ColumnDictinary(""));
            columns_Names_visible.Add("fFather", new ColumnDictinary(""));
            columns_Names_visible.Add("fGrand", new ColumnDictinary(""));
            columns_Names_visible.Add("fFamily", new ColumnDictinary(""));
            columns_Names_visible.Add("EfName", new ColumnDictinary(""));
            columns_Names_visible.Add("EfFather", new ColumnDictinary(""));
            columns_Names_visible.Add("EfGrand", new ColumnDictinary(""));
            columns_Names_visible.Add("EfFamily", new ColumnDictinary(""));
            columns_Names_visible.Add("fNameJob", new ColumnDictinary(""));
            columns_Names_visible.Add("fNameNationality", new ColumnDictinary(""));
            columns_Names_visible.Add("fNameReligion", new ColumnDictinary(""));
            columns_Names_visible.Add("BirthDate", new ColumnDictinary(""));
            columns_Names_visible.Add("PassPortNo", new ColumnDictinary(""));
            columns_Names_visible.Add("PassportDate", new ColumnDictinary(""));
            columns_Names_visible.Add("PassPortExpire", new ColumnDictinary(""));
            columns_Names_visible.Add("PassPortPlace", new ColumnDictinary(""));
            columns_Names_visible.Add("SponsorName", new ColumnDictinary(""));
            columns_Names_visible.Add("SponsorType", new ColumnDictinary(""));
            columns_Names_visible.Add("SponsorAddress", new ColumnDictinary(""));
            columns_Names_visible.Add("SponsorTel", new ColumnDictinary(""));
            columns_Names_visible.Add("NewSponsorName", new ColumnDictinary(""));
            columns_Names_visible.Add("NewSponsorType", new ColumnDictinary(""));
            columns_Names_visible.Add("NewSponsorAddress", new ColumnDictinary(""));
            columns_Names_visible.Add("NewSponsorTel", new ColumnDictinary(""));
            columns_Names_visible.Add("NewSponsorNo", new ColumnDictinary(""));
            columns_Names_visible.Add("EnteryNo", new ColumnDictinary(""));
            columns_Names_visible.Add("IgamaNo", new ColumnDictinary(""));
            columns_Names_visible["PassPorts"].AText = textBox_Place.Text;
            columns_Names_visible["IgamaNo"].AText = textBox_ID_No.Text;
            columns_Names_visible["OrderName"].AText = comboBox_EmpNo.Text;
            columns_Names_visible["fNameNationality"].AText = textBox_Nationalty.Text;
            columns_Names_visible["fNameJob"].AText = textBox_Job.Text;
            columns_Names_visible["fNameReligion"].AText = textBox_Religon.Text;
            columns_Names_visible["OrderType1"].AText = (checkBox_CreateIdentity.Checked ? "1" : "0");
            columns_Names_visible["OrderType2"].AText = (checkBox_CreatePassport.Checked ? "1" : "0");
            columns_Names_visible["OrderType3"].AText = (checkBox_SponsorTransfer.Checked ? "1" : "0");
            columns_Names_visible["OrderType4"].AText = (checkBox_AddExtension.Checked ? "1" : "0");
            columns_Names_visible["PassPortNo"].AText = textBox_PassportNo.Text;
            if (checkBox_CreateIdentity.Checked)
            {
                if (comboBox_ID.SelectedIndex == 0)
                {
                    columns_Names_visible["OrderType1_1"].AText = "0";
                }
                else
                {
                    columns_Names_visible["OrderType1_1"].AText = "1";
                }
            }
            columns_Names_visible["OrderType2_1"].AText = "0";
            columns_Names_visible["OrderType2_2"].AText = "0";
            columns_Names_visible["OrderType2_3"].AText = "0";
            if (comboBox_Passport.SelectedIndex == 0)
            {
                columns_Names_visible["OrderType2_1"].AText = "1";
                columns_Names_visible["OrderType2_2"].AText = "0";
                columns_Names_visible["OrderType2_3"].AText = "0";
            }
            else if (comboBox_Passport.SelectedIndex == 1)
            {
                columns_Names_visible["OrderType2_1"].AText = "0";
                columns_Names_visible["OrderType2_2"].AText = "1";
                columns_Names_visible["OrderType2_3"].AText = "0";
            }
            else if (comboBox_Passport.SelectedIndex == 2)
            {
                columns_Names_visible["OrderType2_1"].AText = "0";
                columns_Names_visible["OrderType2_2"].AText = "0";
                columns_Names_visible["OrderType2_3"].AText = "1";
            }
            columns_Names_visible["OrderType3_1"].AText = "0";
            columns_Names_visible["OrderType3_2"].AText = "0";
            columns_Names_visible["OrderType3_3"].AText = "0";
            if (comboBox_GuarTrans.SelectedIndex == 0)
            {
                columns_Names_visible["OrderType3_1"].AText = "1";
                columns_Names_visible["OrderType3_2"].AText = "0";
                columns_Names_visible["OrderType3_3"].AText = "0";
            }
            else if (comboBox_GuarTrans.SelectedIndex == 1)
            {
                columns_Names_visible["OrderType3_1"].AText = "0";
                columns_Names_visible["OrderType3_2"].AText = "1";
                columns_Names_visible["OrderType3_3"].AText = "0";
            }
            else if (comboBox_GuarTrans.SelectedIndex == 2)
            {
                columns_Names_visible["OrderType3_1"].AText = "0";
                columns_Names_visible["OrderType3_2"].AText = "0";
                columns_Names_visible["OrderType3_3"].AText = "1";
            }
            columns_Names_visible["OrderType1_3"].AText = comboBox_IDMonths.Text;
            columns_Names_visible["OrderType2_4"].AText = comboBox_PassportDay.Text;
            columns_Names_visible["OrderType3_4"].AText = textBox_Others.Text;
            columns_Names_visible["IgamaExpire"].AText = (VarGeneral.CheckDate(dateTimeInput_ID_DateEnd.Text) ? dateTimeInput_ID_DateEnd.Text : "");
            columns_Names_visible["SponsorNo"].AText = textBox_SponsorID.Text;
            columns_Names_visible["EnteryPort"].AText = textBox_PortEntry.Text;
            columns_Names_visible["EnteryDate"].AText = (VarGeneral.CheckDate(dateTimeInput_EntryDate.Text) ? dateTimeInput_EntryDate.Text : "");
            columns_Names_visible["EnteryNo"].AText = textBox_NoBorderEntery.Text;
            columns_Names_visible["fName"].AText = textBox_FristNameA.Text;
            columns_Names_visible["fFather"].AText = textBox_FatherA.Text;
            columns_Names_visible["fGrand"].AText = textBox_GrandA.Text;
            columns_Names_visible["fFamily"].AText = textBox_FamilyA.Text;
            columns_Names_visible["EfName"].AText = textBox_FirstNameE.Text;
            columns_Names_visible["EfFather"].AText = textBox_FatherE.Text;
            columns_Names_visible["EfGrand"].AText = textBox_GrandE.Text;
            columns_Names_visible["EfFamily"].AText = textBox_FamilyE.Text;
            columns_Names_visible["BirthDate"].AText = (VarGeneral.CheckDate(dateTimeInput_BirthDate.Text) ? dateTimeInput_BirthDate.Text : "");
            columns_Names_visible["PassportDate"].AText = (VarGeneral.CheckDate(dateTimeInput_PassportCreateDate.Text) ? dateTimeInput_PassportCreateDate.Text : "");
            columns_Names_visible["PassPortExpire"].AText = (VarGeneral.CheckDate(dateTimeInput_PassportEndDate.Text) ? dateTimeInput_PassportEndDate.Text : "");
            columns_Names_visible["PassPortPlace"].AText = textBox_PassportCreatePlace.Text;
            if (comboBox_SponsorName.Text != "")
            {
                if (radioButton_GovSide.Checked)
                {
                    columns_Names_visible["SponsorType"].AText = "0";
                }
                else if (radioButton_FoundationSide.Checked)
                {
                    columns_Names_visible["SponsorType"].AText = "1";
                }
                else if (radioButton_CompanySide.Checked)
                {
                    columns_Names_visible["SponsorType"].AText = "2";
                }
                else if (radioButton_PersonSide.Checked)
                {
                    columns_Names_visible["SponsorType"].AText = "3";
                }
                columns_Names_visible["SponsorName"].AText = comboBox_SponsorName.Text;
                columns_Names_visible["SponsorAddress"].AText = textBox_Address.Text;
                columns_Names_visible["SponsorTel"].AText = textBox_Tel.Text;
            }
            else
            {
                columns_Names_visible["SponsorType"].AText = "-1";
                columns_Names_visible["SponsorName"].AText = "";
                columns_Names_visible["SponsorAddress"].AText = "";
                columns_Names_visible["SponsorTel"].AText = "";
            }
            if (comboBox_SponsorNameTransfer.Text != "")
            {
                if (radioButton_GovSideTransfer.Checked)
                {
                    columns_Names_visible["NewSponsorType"].AText = "0";
                }
                else if (radioButton_FoundationSideTransfer.Checked)
                {
                    columns_Names_visible["NewSponsorType"].AText = "1";
                }
                else if (radioButton_CompanySideTransfer.Checked)
                {
                    columns_Names_visible["NewSponsorType"].AText = "2";
                }
                else if (radioButton_PersonSideTransfer.Checked)
                {
                    columns_Names_visible["NewSponsorType"].AText = "3";
                }
                columns_Names_visible["NewSponsorName"].AText = comboBox_SponsorNameTransfer.Text;
                columns_Names_visible["NewSponsorAddress"].AText = textBox_AddressTransfer.Text;
                columns_Names_visible["NewSponsorTel"].AText = textBox_TelTransfer.Text;
                columns_Names_visible["NewSponsorNo"].AText = textBox_NewSponsorNo.Text;
            }
            else
            {
                columns_Names_visible["NewSponsorType"].AText = "-1";
                columns_Names_visible["NewSponsorName"].AText = "";
                columns_Names_visible["NewSponsorAddress"].AText = "";
                columns_Names_visible["NewSponsorTel"].AText = "";
                columns_Names_visible["NewSponsorNo"].AText = "";
            }
            int i = 0;
            try
            {
                for (i = 0; i <= columns_Names_visible["IgamaNo"].AText.Trim().Length; i++)
                {
                    if (i < columns_Names_visible["IgamaNo"].AText.Trim().Length && i < 10)
                    {
                        if (i == 0)
                        {
                            columns_Names_visible["Igama_10"].AText = columns_Names_visible["IgamaNo"].AText.Substring(i, 1);
                        }
                        if (i == 1)
                        {
                            columns_Names_visible["Igama_9"].AText = columns_Names_visible["IgamaNo"].AText.Substring(i, 1);
                        }
                        if (i == 2)
                        {
                            columns_Names_visible["Igama_8"].AText = columns_Names_visible["IgamaNo"].AText.Substring(i, 1);
                        }
                        if (i == 3)
                        {
                            columns_Names_visible["Igama_7"].AText = columns_Names_visible["IgamaNo"].AText.Substring(i, 1);
                        }
                        if (i == 4)
                        {
                            columns_Names_visible["Igama_6"].AText = columns_Names_visible["IgamaNo"].AText.Substring(i, 1);
                        }
                        if (i == 5)
                        {
                            columns_Names_visible["Igama_5"].AText = columns_Names_visible["IgamaNo"].AText.Substring(i, 1);
                        }
                        if (i == 6)
                        {
                            columns_Names_visible["Igama_4"].AText = columns_Names_visible["IgamaNo"].AText.Substring(i, 1);
                        }
                        if (i == 7)
                        {
                            columns_Names_visible["Igama_3"].AText = columns_Names_visible["IgamaNo"].AText.Substring(i, 1);
                        }
                        if (i == 8)
                        {
                            columns_Names_visible["Igama_2"].AText = columns_Names_visible["IgamaNo"].AText.Substring(i, 1);
                        }
                        if (i == 9)
                        {
                            columns_Names_visible["Igama_1"].AText = columns_Names_visible["IgamaNo"].AText.Substring(i, 1);
                        }
                    }
                }
            }
            catch
            {
            }
            try
            {
                for (i = 0; i <= columns_Names_visible["EnteryNo"].AText.Trim().Length; i++)
                {
                    if (i < columns_Names_visible["EnteryNo"].AText.Trim().Length && i < 10)
                    {
                        if (i == 0)
                        {
                            columns_Names_visible["E_10"].AText = columns_Names_visible["EnteryNo"].AText.Substring(i, 1);
                        }
                        if (i == 1)
                        {
                            columns_Names_visible["E_9"].AText = columns_Names_visible["EnteryNo"].AText.Substring(i, 1);
                        }
                        if (i == 2)
                        {
                            columns_Names_visible["E_8"].AText = columns_Names_visible["EnteryNo"].AText.Substring(i, 1);
                        }
                        if (i == 3)
                        {
                            columns_Names_visible["E_7"].AText = columns_Names_visible["EnteryNo"].AText.Substring(i, 1);
                        }
                        if (i == 4)
                        {
                            columns_Names_visible["E_6"].AText = columns_Names_visible["EnteryNo"].AText.Substring(i, 1);
                        }
                        if (i == 5)
                        {
                            columns_Names_visible["E_5"].AText = columns_Names_visible["EnteryNo"].AText.Substring(i, 1);
                        }
                        if (i == 6)
                        {
                            columns_Names_visible["E_4"].AText = columns_Names_visible["EnteryNo"].AText.Substring(i, 1);
                        }
                        if (i == 7)
                        {
                            columns_Names_visible["E_3"].AText = columns_Names_visible["EnteryNo"].AText.Substring(i, 1);
                        }
                        if (i == 8)
                        {
                            columns_Names_visible["E_2"].AText = columns_Names_visible["EnteryNo"].AText.Substring(i, 1);
                        }
                        if (i == 9)
                        {
                            columns_Names_visible["E_1"].AText = columns_Names_visible["EnteryNo"].AText.Substring(i, 1);
                        }
                    }
                }
            }
            catch
            {
            }
            try
            {
                for (i = 0; i <= columns_Names_visible["SponsorNo"].AText.Trim().Length; i++)
                {
                    if (i < columns_Names_visible["SponsorNo"].AText.Trim().Length && i < 10)
                    {
                        if (i == 0)
                        {
                            columns_Names_visible["S_10"].AText = columns_Names_visible["SponsorNo"].AText.Substring(i, 1);
                        }
                        if (i == 1)
                        {
                            columns_Names_visible["S_9"].AText = columns_Names_visible["SponsorNo"].AText.Substring(i, 1);
                        }
                        if (i == 2)
                        {
                            columns_Names_visible["S_8"].AText = columns_Names_visible["SponsorNo"].AText.Substring(i, 1);
                        }
                        if (i == 3)
                        {
                            columns_Names_visible["S_7"].AText = columns_Names_visible["SponsorNo"].AText.Substring(i, 1);
                        }
                        if (i == 4)
                        {
                            columns_Names_visible["S_6"].AText = columns_Names_visible["SponsorNo"].AText.Substring(i, 1);
                        }
                        if (i == 5)
                        {
                            columns_Names_visible["S_5"].AText = columns_Names_visible["SponsorNo"].AText.Substring(i, 1);
                        }
                        if (i == 6)
                        {
                            columns_Names_visible["S_4"].AText = columns_Names_visible["SponsorNo"].AText.Substring(i, 1);
                        }
                        if (i == 7)
                        {
                            columns_Names_visible["S_3"].AText = columns_Names_visible["SponsorNo"].AText.Substring(i, 1);
                        }
                        if (i == 8)
                        {
                            columns_Names_visible["S_2"].AText = columns_Names_visible["SponsorNo"].AText.Substring(i, 1);
                        }
                        if (i == 9)
                        {
                            columns_Names_visible["S_1"].AText = columns_Names_visible["SponsorNo"].AText.Substring(i, 1);
                        }
                    }
                }
            }
            catch
            {
            }
            try
            {
                for (i = 0; i < columns_Names_visible["NewSponsorNo"].AText.Trim().Length; i++)
                {
                    if (i < columns_Names_visible["NewSponsorNo"].AText.Trim().Length && i < 10)
                    {
                        if (i == 0)
                        {
                            columns_Names_visible["NS_10"].AText = columns_Names_visible["NewSponsorNo"].AText.Substring(i, 1);
                        }
                        if (i == 1)
                        {
                            columns_Names_visible["NS_9"].AText = columns_Names_visible["NewSponsorNo"].AText.Substring(i, 1);
                        }
                        if (i == 2)
                        {
                            columns_Names_visible["NS_8"].AText = columns_Names_visible["NewSponsorNo"].AText.Substring(i, 1);
                        }
                        if (i == 3)
                        {
                            columns_Names_visible["NS_7"].AText = columns_Names_visible["NewSponsorNo"].AText.Substring(i, 1);
                        }
                        if (i == 4)
                        {
                            columns_Names_visible["NS_6"].AText = columns_Names_visible["NewSponsorNo"].AText.Substring(i, 1);
                        }
                        if (i == 5)
                        {
                            columns_Names_visible["NS_5"].AText = columns_Names_visible["NewSponsorNo"].AText.Substring(i, 1);
                        }
                        if (i == 6)
                        {
                            columns_Names_visible["NS_4"].AText = columns_Names_visible["NewSponsorNo"].AText.Substring(i, 1);
                        }
                        if (i == 7)
                        {
                            columns_Names_visible["NS_3"].AText = columns_Names_visible["NewSponsorNo"].AText.Substring(i, 1);
                        }
                        if (i == 8)
                        {
                            columns_Names_visible["NS_2"].AText = columns_Names_visible["NewSponsorNo"].AText.Substring(i, 1);
                        }
                        if (i == 9)
                        {
                            columns_Names_visible["NS_1"].AText = columns_Names_visible["NewSponsorNo"].AText.Substring(i, 1);
                        }
                    }
                }
            }
            catch
            {
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
        private void dateTimeInput_EntryDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_EntryDate.Text = Convert.ToDateTime(dateTimeInput_EntryDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_EntryDate.Text = "";
            }
        }
        private void dateTimeInput_PassportEndDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportEndDate.Text = Convert.ToDateTime(dateTimeInput_PassportEndDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportEndDate.Text = "";
            }
        }
        private void dateTimeInput_ID_DateEnd_Click(object sender, EventArgs e)
        {
            dateTimeInput_ID_DateEnd.SelectAll();
        }
        private void dateTimeInput_PassportEndDate_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportEndDate.SelectAll();
        }
        private void dateTimeInput_EntryDate_Click(object sender, EventArgs e)
        {
            dateTimeInput_EntryDate.SelectAll();
        }
        private void FrmPassportForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void FrmPassportForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && button_Print.Enabled && button_Print.Visible)
            {
                button_Print_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void textBox_ID_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void textBox_EnterNo15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
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
        private void dateTimeInput_BirthDate11_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate11.Text = Convert.ToDateTime(dateTimeInput_BirthDate11.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate11.Text = "";
            }
        }
        private void dateTimeInput_BirthDate12_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate12.Text = Convert.ToDateTime(dateTimeInput_BirthDate12.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate12.Text = "";
            }
        }
        private void dateTimeInput_BirthDate13_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate13.Text = Convert.ToDateTime(dateTimeInput_BirthDate13.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate13.Text = "";
            }
        }
        private void dateTimeInput_BirthDate14_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate14.Text = Convert.ToDateTime(dateTimeInput_BirthDate14.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate14.Text = "";
            }
        }
        private void dateTimeInput_BirthDate15_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate15.Text = Convert.ToDateTime(dateTimeInput_BirthDate15.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate15.Text = "";
            }
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
                dateTimeInput_PassportDateEnd6.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd6.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd6.Text = "";
            }
        }
        private void dateTimeInput_PassportDateEnd8_Leave(object sender, EventArgs e)
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
        private void dateTimeInput_PassportDateEnd11_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd11.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd11.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd11.Text = "";
            }
        }
        private void dateTimeInput_PassportDateEnd12_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd12.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd12.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd12.Text = "";
            }
        }
        private void dateTimeInput_PassportDateEnd13_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd13.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd13.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd13.Text = "";
            }
        }
        private void dateTimeInput_PassportDateEnd14_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd14.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd14.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd14.Text = "";
            }
        }
        private void dateTimeInput_PassportDateEnd15_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd15.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd15.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd15.Text = "";
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
        private void dateTimeInput_BirthDate11_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate11.SelectAll();
        }
        private void dateTimeInput_BirthDate12_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate12.SelectAll();
        }
        private void dateTimeInput_BirthDate13_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate13.SelectAll();
        }
        private void dateTimeInput_BirthDate14_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate14.SelectAll();
        }
        private void dateTimeInput_BirthDate15_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate15.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd15_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd15.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd14_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd14.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd13_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd13.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd12_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd12.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd11_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd11.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd10_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd10.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd9_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd9.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd8_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd8.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd7_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd7.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd6_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd6.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd5_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd5.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd4_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd4.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd3_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd3.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd2_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd2.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd1_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd1.SelectAll();
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
        private void dateTimeInput_PassportCreateDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportCreateDate.Text = Convert.ToDateTime(dateTimeInput_PassportCreateDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportCreateDate.Text = "";
            }
        }
        private void dateTimeInput_PassportCreateDate_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportCreateDate.SelectAll();
        }
        private void button_Family_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView_Family.Rows.Clear();
                dataGridView_Family.DataSource = null;
                dataGridView_Family.Rows.Add(15);
                dataGridView_Family.Rows[0].Cells["name"].Value = textBox_Name1.Text;
                dataGridView_Family.Rows[0].Cells["BornDate"].Value = (VarGeneral.CheckDate(dateTimeInput_BirthDate1.Text) ? dateTimeInput_BirthDate1.Text : "");
                dataGridView_Family.Rows[0].Cells["Link"].Value = textBox_Relation1.Text;
                dataGridView_Family.Rows[0].Cells["PassNo"].Value = textBox_PassporntNo1.Text;
                dataGridView_Family.Rows[0].Cells["PassEnd"].Value = (VarGeneral.CheckDate(dateTimeInput_PassportDateEnd1.Text) ? dateTimeInput_PassportDateEnd1.Text : "");
                dataGridView_Family.Rows[0].Cells["EnteryPort"].Value = textBox_Port1.Text;
                dataGridView_Family.Rows[0].Cells["EnteryNo"].Value = textBox_EnterNo1.Text;
                dataGridView_Family.Rows[1].Cells["name"].Value = textBox_Name2.Text;
                dataGridView_Family.Rows[1].Cells["BornDate"].Value = (VarGeneral.CheckDate(dateTimeInput_BirthDate2.Text) ? dateTimeInput_BirthDate2.Text : "");
                dataGridView_Family.Rows[1].Cells["Link"].Value = textBox_Relation2.Text;
                dataGridView_Family.Rows[1].Cells["PassNo"].Value = textBox_PassporntNo2.Text;
                dataGridView_Family.Rows[1].Cells["PassEnd"].Value = (VarGeneral.CheckDate(dateTimeInput_PassportDateEnd2.Text) ? dateTimeInput_PassportDateEnd2.Text : "");
                dataGridView_Family.Rows[1].Cells["EnteryPort"].Value = textBox_Port2.Text;
                dataGridView_Family.Rows[1].Cells["EnteryNo"].Value = textBox_EnterNo2.Text;
                dataGridView_Family.Rows[2].Cells["name"].Value = textBox_Name3.Text;
                dataGridView_Family.Rows[2].Cells["BornDate"].Value = (VarGeneral.CheckDate(dateTimeInput_BirthDate3.Text) ? dateTimeInput_BirthDate3.Text : "");
                dataGridView_Family.Rows[2].Cells["Link"].Value = textBox_Relation3.Text;
                dataGridView_Family.Rows[2].Cells["PassNo"].Value = textBox_PassporntNo3.Text;
                dataGridView_Family.Rows[2].Cells["PassEnd"].Value = (VarGeneral.CheckDate(dateTimeInput_PassportDateEnd3.Text) ? dateTimeInput_PassportDateEnd3.Text : "");
                dataGridView_Family.Rows[2].Cells["EnteryPort"].Value = textBox_Port3.Text;
                dataGridView_Family.Rows[2].Cells["EnteryNo"].Value = textBox_EnterNo3.Text;
                dataGridView_Family.Rows[3].Cells["name"].Value = textBox_Name4.Text;
                dataGridView_Family.Rows[3].Cells["BornDate"].Value = (VarGeneral.CheckDate(dateTimeInput_BirthDate4.Text) ? dateTimeInput_BirthDate4.Text : "");
                dataGridView_Family.Rows[3].Cells["Link"].Value = textBox_Relation4.Text;
                dataGridView_Family.Rows[3].Cells["PassNo"].Value = textBox_PassporntNo4.Text;
                dataGridView_Family.Rows[3].Cells["PassEnd"].Value = (VarGeneral.CheckDate(dateTimeInput_PassportDateEnd4.Text) ? dateTimeInput_PassportDateEnd4.Text : "");
                dataGridView_Family.Rows[3].Cells["EnteryPort"].Value = textBox_Port4.Text;
                dataGridView_Family.Rows[3].Cells["EnteryNo"].Value = textBox_EnterNo4.Text;
                dataGridView_Family.Rows[4].Cells["name"].Value = textBox_Name5.Text;
                dataGridView_Family.Rows[4].Cells["BornDate"].Value = (VarGeneral.CheckDate(dateTimeInput_BirthDate5.Text) ? dateTimeInput_BirthDate5.Text : "");
                dataGridView_Family.Rows[4].Cells["Link"].Value = textBox_Relation5.Text;
                dataGridView_Family.Rows[4].Cells["PassNo"].Value = textBox_PassporntNo5.Text;
                dataGridView_Family.Rows[4].Cells["PassEnd"].Value = (VarGeneral.CheckDate(dateTimeInput_PassportDateEnd5.Text) ? dateTimeInput_PassportDateEnd5.Text : "");
                dataGridView_Family.Rows[4].Cells["EnteryPort"].Value = textBox_Port5.Text;
                dataGridView_Family.Rows[4].Cells["EnteryNo"].Value = textBox_EnterNo5.Text;
                dataGridView_Family.Rows[5].Cells["name"].Value = textBox_Name6.Text;
                dataGridView_Family.Rows[5].Cells["BornDate"].Value = (VarGeneral.CheckDate(dateTimeInput_BirthDate6.Text) ? dateTimeInput_BirthDate6.Text : "");
                dataGridView_Family.Rows[5].Cells["Link"].Value = textBox_Relation6.Text;
                dataGridView_Family.Rows[5].Cells["PassNo"].Value = textBox_PassporntNo6.Text;
                dataGridView_Family.Rows[5].Cells["PassEnd"].Value = (VarGeneral.CheckDate(dateTimeInput_PassportDateEnd6.Text) ? dateTimeInput_PassportDateEnd6.Text : "");
                dataGridView_Family.Rows[5].Cells["EnteryPort"].Value = textBox_Port6.Text;
                dataGridView_Family.Rows[5].Cells["EnteryNo"].Value = textBox_EnterNo6.Text;
                dataGridView_Family.Rows[6].Cells["name"].Value = textBox_Name7.Text;
                dataGridView_Family.Rows[6].Cells["BornDate"].Value = (VarGeneral.CheckDate(dateTimeInput_BirthDate7.Text) ? dateTimeInput_BirthDate7.Text : "");
                dataGridView_Family.Rows[6].Cells["Link"].Value = textBox_Relation7.Text;
                dataGridView_Family.Rows[6].Cells["PassNo"].Value = textBox_PassporntNo7.Text;
                dataGridView_Family.Rows[6].Cells["PassEnd"].Value = (VarGeneral.CheckDate(dateTimeInput_PassportDateEnd7.Text) ? dateTimeInput_PassportDateEnd7.Text : "");
                dataGridView_Family.Rows[6].Cells["EnteryPort"].Value = textBox_Port7.Text;
                dataGridView_Family.Rows[6].Cells["EnteryNo"].Value = textBox_EnterNo7.Text;
                dataGridView_Family.Rows[7].Cells["name"].Value = textBox_Name8.Text;
                dataGridView_Family.Rows[7].Cells["BornDate"].Value = (VarGeneral.CheckDate(dateTimeInput_BirthDate8.Text) ? dateTimeInput_BirthDate8.Text : "");
                dataGridView_Family.Rows[7].Cells["Link"].Value = textBox_Relation8.Text;
                dataGridView_Family.Rows[7].Cells["PassNo"].Value = textBox_PassporntNo8.Text;
                dataGridView_Family.Rows[7].Cells["PassEnd"].Value = (VarGeneral.CheckDate(dateTimeInput_PassportDateEnd8.Text) ? dateTimeInput_PassportDateEnd8.Text : "");
                dataGridView_Family.Rows[7].Cells["EnteryPort"].Value = textBox_Port8.Text;
                dataGridView_Family.Rows[7].Cells["EnteryNo"].Value = textBox_EnterNo8.Text;
                dataGridView_Family.Rows[8].Cells["name"].Value = textBox_Name9.Text;
                dataGridView_Family.Rows[8].Cells["BornDate"].Value = (VarGeneral.CheckDate(dateTimeInput_BirthDate9.Text) ? dateTimeInput_BirthDate9.Text : "");
                dataGridView_Family.Rows[8].Cells["Link"].Value = textBox_Relation9.Text;
                dataGridView_Family.Rows[8].Cells["PassNo"].Value = textBox_PassporntNo9.Text;
                dataGridView_Family.Rows[8].Cells["PassEnd"].Value = (VarGeneral.CheckDate(dateTimeInput_PassportDateEnd9.Text) ? dateTimeInput_PassportDateEnd9.Text : "");
                dataGridView_Family.Rows[8].Cells["EnteryPort"].Value = textBox_Port9.Text;
                dataGridView_Family.Rows[8].Cells["EnteryNo"].Value = textBox_EnterNo9.Text;
                dataGridView_Family.Rows[9].Cells["name"].Value = textBox_Name10.Text;
                dataGridView_Family.Rows[9].Cells["BornDate"].Value = (VarGeneral.CheckDate(dateTimeInput_BirthDate10.Text) ? dateTimeInput_BirthDate10.Text : "");
                dataGridView_Family.Rows[9].Cells["Link"].Value = textBox_Relation10.Text;
                dataGridView_Family.Rows[9].Cells["PassNo"].Value = textBox_PassporntNo10.Text;
                dataGridView_Family.Rows[9].Cells["PassEnd"].Value = (VarGeneral.CheckDate(dateTimeInput_PassportDateEnd10.Text) ? dateTimeInput_PassportDateEnd10.Text : "");
                dataGridView_Family.Rows[9].Cells["EnteryPort"].Value = textBox_Port10.Text;
                dataGridView_Family.Rows[9].Cells["EnteryNo"].Value = textBox_EnterNo10.Text;
                dataGridView_Family.Rows[10].Cells["name"].Value = textBox_Name11.Text;
                dataGridView_Family.Rows[10].Cells["BornDate"].Value = (VarGeneral.CheckDate(dateTimeInput_BirthDate11.Text) ? dateTimeInput_BirthDate11.Text : "");
                dataGridView_Family.Rows[10].Cells["Link"].Value = textBox_Relation11.Text;
                dataGridView_Family.Rows[10].Cells["PassNo"].Value = textBox_PassporntNo11.Text;
                dataGridView_Family.Rows[10].Cells["PassEnd"].Value = (VarGeneral.CheckDate(dateTimeInput_PassportDateEnd11.Text) ? dateTimeInput_PassportDateEnd11.Text : "");
                dataGridView_Family.Rows[10].Cells["EnteryPort"].Value = textBox_Port11.Text;
                dataGridView_Family.Rows[10].Cells["EnteryNo"].Value = textBox_EnterNo11.Text;
                dataGridView_Family.Rows[11].Cells["name"].Value = textBox_Name12.Text;
                dataGridView_Family.Rows[11].Cells["BornDate"].Value = (VarGeneral.CheckDate(dateTimeInput_BirthDate12.Text) ? dateTimeInput_BirthDate12.Text : "");
                dataGridView_Family.Rows[11].Cells["Link"].Value = textBox_Relation12.Text;
                dataGridView_Family.Rows[11].Cells["PassNo"].Value = textBox_PassporntNo12.Text;
                dataGridView_Family.Rows[11].Cells["PassEnd"].Value = (VarGeneral.CheckDate(dateTimeInput_PassportDateEnd12.Text) ? dateTimeInput_PassportDateEnd12.Text : "");
                dataGridView_Family.Rows[11].Cells["EnteryPort"].Value = textBox_Port12.Text;
                dataGridView_Family.Rows[11].Cells["EnteryNo"].Value = textBox_EnterNo12.Text;
                dataGridView_Family.Rows[12].Cells["name"].Value = textBox_Name13.Text;
                dataGridView_Family.Rows[12].Cells["BornDate"].Value = (VarGeneral.CheckDate(dateTimeInput_BirthDate13.Text) ? dateTimeInput_BirthDate13.Text : "");
                dataGridView_Family.Rows[12].Cells["Link"].Value = textBox_Relation13.Text;
                dataGridView_Family.Rows[12].Cells["PassNo"].Value = textBox_PassporntNo13.Text;
                dataGridView_Family.Rows[12].Cells["PassEnd"].Value = (VarGeneral.CheckDate(dateTimeInput_PassportDateEnd13.Text) ? dateTimeInput_PassportDateEnd13.Text : "");
                dataGridView_Family.Rows[12].Cells["EnteryPort"].Value = textBox_Port13.Text;
                dataGridView_Family.Rows[12].Cells["EnteryNo"].Value = textBox_EnterNo13.Text;
                dataGridView_Family.Rows[13].Cells["name"].Value = textBox_Name14.Text;
                dataGridView_Family.Rows[13].Cells["BornDate"].Value = (VarGeneral.CheckDate(dateTimeInput_BirthDate14.Text) ? dateTimeInput_BirthDate14.Text : "");
                dataGridView_Family.Rows[13].Cells["Link"].Value = textBox_Relation14.Text;
                dataGridView_Family.Rows[13].Cells["PassNo"].Value = textBox_PassporntNo14.Text;
                dataGridView_Family.Rows[13].Cells["PassEnd"].Value = (VarGeneral.CheckDate(dateTimeInput_PassportDateEnd14.Text) ? dateTimeInput_PassportDateEnd14.Text : "");
                dataGridView_Family.Rows[13].Cells["EnteryPort"].Value = textBox_Port14.Text;
                dataGridView_Family.Rows[13].Cells["EnteryNo"].Value = textBox_EnterNo14.Text;
                dataGridView_Family.Rows[14].Cells["name"].Value = textBox_Name15.Text;
                dataGridView_Family.Rows[14].Cells["BornDate"].Value = (VarGeneral.CheckDate(dateTimeInput_BirthDate15.Text) ? dateTimeInput_BirthDate15.Text : "");
                dataGridView_Family.Rows[14].Cells["Link"].Value = textBox_Relation15.Text;
                dataGridView_Family.Rows[14].Cells["PassNo"].Value = textBox_PassporntNo15.Text;
                dataGridView_Family.Rows[14].Cells["PassEnd"].Value = (VarGeneral.CheckDate(dateTimeInput_PassportDateEnd15.Text) ? dateTimeInput_PassportDateEnd15.Text : "");
                dataGridView_Family.Rows[14].Cells["EnteryPort"].Value = textBox_Port15.Text;
                dataGridView_Family.Rows[14].Cells["EnteryNo"].Value = textBox_EnterNo15.Text;
                while (true)
                {
                IL_1764:
                    int i = 0;
                    while (true)
                    {
                        if (i < dataGridView_Family.Rows.Count)
                        {
                            try
                            {
                                if (string.IsNullOrEmpty(dataGridView_Family.Rows[i].Cells["name"].Value.ToString()))
                                {
                                    dataGridView_Family.Rows.Remove(dataGridView_Family.Rows[i]);
                                    goto IL_1764;
                                }
                            }
                            catch
                            {
                            }
                            i++;
                            continue;
                        }
                        for (i = 0; i < dataGridView_Family.Rows.Count; i++)
                        {
                            dataGridView_Family.Rows[i].Cells["IND"].Value = i + 1;
                        }
                        vFamilyPassport.Clear();
                        for (i = 0; i < dataGridView_Family.Rows.Count; i++)
                        {
                            vFamilyPassport.Add(i + 1, new familyPassport(dataGridView_Family.Rows[i].Cells["IND"].Value.ToString(), dataGridView_Family.Rows[i].Cells["IND"].Value.ToString(), dataGridView_Family.Rows[i].Cells["name"].Value.ToString(), dataGridView_Family.Rows[i].Cells["BornDate"].Value.ToString(), dataGridView_Family.Rows[i].Cells["Link"].Value.ToString(), dataGridView_Family.Rows[i].Cells["PassNo"].Value.ToString(), dataGridView_Family.Rows[i].Cells["PassEnd"].Value.ToString(), dataGridView_Family.Rows[i].Cells["EnteryPort"].Value.ToString(), dataGridView_Family.Rows[i].Cells["EnteryNo"].Value.ToString()));
                        }
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Tag = LangArEn;
                        ICollection<KeyValuePair<long, familyPassport>> animalsAsCollection = vFamilyPassport;
                        foreach (KeyValuePair<long, familyPassport> kvp in animalsAsCollection)
                        {
                            frm.vFamilyPassport.Add(kvp.Key, new FrmReportsViewer.familyPassport(kvp.Value.IND, kvp.Value.ID, kvp.Value.name, kvp.Value.BornDate, kvp.Value.Link, kvp.Value.PassNo, kvp.Value.PassEnd, kvp.Value.EnteryPort, kvp.Value.EnteryNo));
                        }
                        frm.Repvalue = "FamilyPassport";
                        frm.TopMost = true;
                        frm.ShowDialog();
                        break;
                    }
                    break;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_Family_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void button_Back_Click(object sender, EventArgs e)
        {
            expandablePanel_Escorts.Expanded = false;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmPassportForm));
            components = new System.ComponentModel.Container();
            Main_Panel = new DevComponents.DotNetBar.PanelEx();
            expandablePanel_Escorts = new DevComponents.DotNetBar.ExpandablePanel();
            panel10 = new System.Windows.Forms.Panel();
            button_Back = new DevComponents.DotNetBar.ButtonX();
            button_Family = new DevComponents.DotNetBar.ButtonX();
            label45 = new System.Windows.Forms.Label();
            label46 = new System.Windows.Forms.Label();
            textBox_EnterNo15 = new System.Windows.Forms.TextBox();
            textBox_Port15 = new System.Windows.Forms.TextBox();
            textBox_EnterNo14 = new System.Windows.Forms.TextBox();
            textBox_Port14 = new System.Windows.Forms.TextBox();
            textBox_EnterNo13 = new System.Windows.Forms.TextBox();
            textBox_Port13 = new System.Windows.Forms.TextBox();
            textBox_EnterNo12 = new System.Windows.Forms.TextBox();
            textBox_Port12 = new System.Windows.Forms.TextBox();
            textBox_EnterNo11 = new System.Windows.Forms.TextBox();
            textBox_Port11 = new System.Windows.Forms.TextBox();
            textBox_EnterNo10 = new System.Windows.Forms.TextBox();
            textBox_Port10 = new System.Windows.Forms.TextBox();
            textBox_EnterNo9 = new System.Windows.Forms.TextBox();
            textBox_Port9 = new System.Windows.Forms.TextBox();
            textBox_EnterNo8 = new System.Windows.Forms.TextBox();
            textBox_Port8 = new System.Windows.Forms.TextBox();
            textBox_EnterNo7 = new System.Windows.Forms.TextBox();
            textBox_Port7 = new System.Windows.Forms.TextBox();
            textBox_EnterNo6 = new System.Windows.Forms.TextBox();
            textBox_Port6 = new System.Windows.Forms.TextBox();
            textBox_EnterNo5 = new System.Windows.Forms.TextBox();
            textBox_Port5 = new System.Windows.Forms.TextBox();
            textBox_EnterNo4 = new System.Windows.Forms.TextBox();
            textBox_Port4 = new System.Windows.Forms.TextBox();
            textBox_EnterNo3 = new System.Windows.Forms.TextBox();
            textBox_Port3 = new System.Windows.Forms.TextBox();
            textBox_EnterNo2 = new System.Windows.Forms.TextBox();
            textBox_Port2 = new System.Windows.Forms.TextBox();
            textBox_EnterNo1 = new System.Windows.Forms.TextBox();
            textBox_Port1 = new System.Windows.Forms.TextBox();
            dateTimeInput_PassportDateEnd15 = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_PassportDateEnd14 = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_PassportDateEnd13 = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_PassportDateEnd12 = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_PassportDateEnd11 = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_PassportDateEnd10 = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_PassportDateEnd9 = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_PassportDateEnd8 = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_PassportDateEnd7 = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_PassportDateEnd6 = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_PassportDateEnd5 = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_PassportDateEnd4 = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_PassportDateEnd3 = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_PassportDateEnd2 = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_PassportDateEnd1 = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_BirthDate15 = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_BirthDate14 = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_BirthDate13 = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_BirthDate12 = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_BirthDate11 = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_BirthDate10 = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_BirthDate9 = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_BirthDate8 = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_BirthDate7 = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_BirthDate6 = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_BirthDate5 = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_BirthDate4 = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_BirthDate3 = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_BirthDate2 = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_BirthDate1 = new System.Windows.Forms.MaskedTextBox();
            label40 = new System.Windows.Forms.Label();
            label41 = new System.Windows.Forms.Label();
            label42 = new System.Windows.Forms.Label();
            label43 = new System.Windows.Forms.Label();
            textBox_PassporntNo15 = new System.Windows.Forms.TextBox();
            textBox_Relation15 = new System.Windows.Forms.TextBox();
            textBox_Name15 = new System.Windows.Forms.TextBox();
            textBox_PassporntNo14 = new System.Windows.Forms.TextBox();
            textBox_Relation14 = new System.Windows.Forms.TextBox();
            textBox_Name14 = new System.Windows.Forms.TextBox();
            textBox_PassporntNo13 = new System.Windows.Forms.TextBox();
            textBox_Relation13 = new System.Windows.Forms.TextBox();
            textBox_Name13 = new System.Windows.Forms.TextBox();
            textBox_PassporntNo12 = new System.Windows.Forms.TextBox();
            textBox_Relation12 = new System.Windows.Forms.TextBox();
            textBox_Name12 = new System.Windows.Forms.TextBox();
            textBox_PassporntNo11 = new System.Windows.Forms.TextBox();
            textBox_Relation11 = new System.Windows.Forms.TextBox();
            textBox_Name11 = new System.Windows.Forms.TextBox();
            textBox_PassporntNo10 = new System.Windows.Forms.TextBox();
            textBox_Relation10 = new System.Windows.Forms.TextBox();
            textBox_Name10 = new System.Windows.Forms.TextBox();
            textBox_PassporntNo9 = new System.Windows.Forms.TextBox();
            textBox_Relation9 = new System.Windows.Forms.TextBox();
            textBox_Name9 = new System.Windows.Forms.TextBox();
            textBox_PassporntNo8 = new System.Windows.Forms.TextBox();
            textBox_Relation8 = new System.Windows.Forms.TextBox();
            textBox_Name8 = new System.Windows.Forms.TextBox();
            textBox_PassporntNo7 = new System.Windows.Forms.TextBox();
            textBox_Relation7 = new System.Windows.Forms.TextBox();
            textBox_Name7 = new System.Windows.Forms.TextBox();
            textBox_PassporntNo6 = new System.Windows.Forms.TextBox();
            textBox_Relation6 = new System.Windows.Forms.TextBox();
            textBox_Name6 = new System.Windows.Forms.TextBox();
            textBox_PassporntNo5 = new System.Windows.Forms.TextBox();
            textBox_Relation5 = new System.Windows.Forms.TextBox();
            textBox_Name5 = new System.Windows.Forms.TextBox();
            textBox_PassporntNo4 = new System.Windows.Forms.TextBox();
            textBox_Relation4 = new System.Windows.Forms.TextBox();
            textBox_Name4 = new System.Windows.Forms.TextBox();
            textBox_PassporntNo3 = new System.Windows.Forms.TextBox();
            textBox_Relation3 = new System.Windows.Forms.TextBox();
            textBox_Name3 = new System.Windows.Forms.TextBox();
            textBox_PassporntNo2 = new System.Windows.Forms.TextBox();
            textBox_Relation2 = new System.Windows.Forms.TextBox();
            textBox_Name2 = new System.Windows.Forms.TextBox();
            textBox_PassporntNo1 = new System.Windows.Forms.TextBox();
            textBox_Relation1 = new System.Windows.Forms.TextBox();
            textBox_Name1 = new System.Windows.Forms.TextBox();
            label44 = new System.Windows.Forms.Label();
            dataGridView_Family = new System.Windows.Forms.DataGridView();
            IND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            BornDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Link = new System.Windows.Forms.DataGridViewTextBoxColumn();
            PassNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            PassEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            EnteryPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            EnteryNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            button_Exit = new DevComponents.DotNetBar.ButtonX();
            button_Print = new DevComponents.DotNetBar.ButtonX();
            panel12 = new System.Windows.Forms.Panel();
            label49 = new System.Windows.Forms.Label();
            label50 = new System.Windows.Forms.Label();
            textBox_Place = new System.Windows.Forms.TextBox();
            label39 = new System.Windows.Forms.Label();
            panel9 = new System.Windows.Forms.Panel();
            label38 = new System.Windows.Forms.Label();
            textBox_NewSponsorNo = new System.Windows.Forms.TextBox();
            label35 = new System.Windows.Forms.Label();
            textBox_TelTransfer = new System.Windows.Forms.TextBox();
            label36 = new System.Windows.Forms.Label();
            textBox_AddressTransfer = new System.Windows.Forms.TextBox();
            label37 = new System.Windows.Forms.Label();
            radioButton_PersonSideTransfer = new System.Windows.Forms.RadioButton();
            radioButton_CompanySideTransfer = new System.Windows.Forms.RadioButton();
            radioButton_FoundationSideTransfer = new System.Windows.Forms.RadioButton();
            radioButton_GovSideTransfer = new System.Windows.Forms.RadioButton();
            comboBox_SponsorNameTransfer = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            checkBox_CreatePassport = new System.Windows.Forms.CheckBox();
            checkBox_CreateIdentity = new System.Windows.Forms.CheckBox();
            panel8 = new System.Windows.Forms.Panel();
            textBox_ID = new System.Windows.Forms.TextBox();
            label34 = new System.Windows.Forms.Label();
            textBox_Tel = new System.Windows.Forms.TextBox();
            label33 = new System.Windows.Forms.Label();
            textBox_Address = new System.Windows.Forms.TextBox();
            label32 = new System.Windows.Forms.Label();
            radioButton_PersonSide = new System.Windows.Forms.RadioButton();
            radioButton_CompanySide = new System.Windows.Forms.RadioButton();
            radioButton_FoundationSide = new System.Windows.Forms.RadioButton();
            radioButton_GovSide = new System.Windows.Forms.RadioButton();
            comboBox_SponsorName = new System.Windows.Forms.ComboBox();
            panel7 = new System.Windows.Forms.Panel();
            dateTimeInput_BirthDate = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_PassportCreateDate = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_PassportEndDate = new System.Windows.Forms.MaskedTextBox();
            label31 = new System.Windows.Forms.Label();
            textBox_PassportCreatePlace = new System.Windows.Forms.TextBox();
            label30 = new System.Windows.Forms.Label();
            label29 = new System.Windows.Forms.Label();
            label28 = new System.Windows.Forms.Label();
            textBox_PassportNo = new System.Windows.Forms.TextBox();
            label27 = new System.Windows.Forms.Label();
            label26 = new System.Windows.Forms.Label();
            textBox_Religon = new System.Windows.Forms.TextBox();
            label25 = new System.Windows.Forms.Label();
            textBox_Job = new System.Windows.Forms.TextBox();
            label24 = new System.Windows.Forms.Label();
            textBox_Nationalty = new System.Windows.Forms.TextBox();
            label19 = new System.Windows.Forms.Label();
            textBox_FamilyE = new System.Windows.Forms.TextBox();
            label20 = new System.Windows.Forms.Label();
            label21 = new System.Windows.Forms.Label();
            textBox_FatherE = new System.Windows.Forms.TextBox();
            textBox_GrandE = new System.Windows.Forms.TextBox();
            label23 = new System.Windows.Forms.Label();
            textBox_FirstNameE = new System.Windows.Forms.TextBox();
            label18 = new System.Windows.Forms.Label();
            textBox_FamilyA = new System.Windows.Forms.TextBox();
            label17 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            textBox_FatherA = new System.Windows.Forms.TextBox();
            textBox_GrandA = new System.Windows.Forms.TextBox();
            label15 = new System.Windows.Forms.Label();
            textBox_FristNameA = new System.Windows.Forms.TextBox();
            comboBox_EmpNo = new System.Windows.Forms.ComboBox();
            label14 = new System.Windows.Forms.Label();
            panel6 = new System.Windows.Forms.Panel();
            label13 = new System.Windows.Forms.Label();
            textBox_PortEntry = new System.Windows.Forms.TextBox();
            label11 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            textBox_NoBorderEntery = new System.Windows.Forms.TextBox();
            label12 = new System.Windows.Forms.Label();
            dateTimeInput_EntryDate = new System.Windows.Forms.MaskedTextBox();
            panel5 = new System.Windows.Forms.Panel();
            dateTimeInput_ID_DateEnd = new System.Windows.Forms.MaskedTextBox();
            label9 = new System.Windows.Forms.Label();
            textBox_SponsorID = new System.Windows.Forms.TextBox();
            label92 = new System.Windows.Forms.Label();
            label97 = new System.Windows.Forms.Label();
            textBox_ID_No = new System.Windows.Forms.TextBox();
            label7 = new System.Windows.Forms.Label();
            checkBox_AddExtension = new System.Windows.Forms.CheckBox();
            label6 = new System.Windows.Forms.Label();
            checkBox_SponsorTransfer = new System.Windows.Forms.CheckBox();
            panel3 = new System.Windows.Forms.Panel();
            textBox_Others = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            comboBox_GuarTrans = new System.Windows.Forms.ComboBox();
            panel2 = new System.Windows.Forms.Panel();
            label4 = new System.Windows.Forms.Label();
            comboBox_PassportDay = new System.Windows.Forms.ComboBox();
            label5 = new System.Windows.Forms.Label();
            comboBox_Passport = new System.Windows.Forms.ComboBox();
            label22 = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            label2 = new System.Windows.Forms.Label();
            comboBox_IDMonths = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            comboBox_ID = new System.Windows.Forms.ComboBox();
            panel4 = new System.Windows.Forms.Panel();
            label48 = new System.Windows.Forms.Label();
            label47 = new System.Windows.Forms.Label();
            panel11 = new System.Windows.Forms.Panel();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            Main_Panel.SuspendLayout();
            expandablePanel_Escorts.SuspendLayout();
            panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Family).BeginInit();
            panel12.SuspendLayout();
            panel9.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            Main_Panel.AccessibleDescription = null;
            Main_Panel.AccessibleName = null;
            resources.ApplyResources(Main_Panel, "Main_Panel");
            Main_Panel.CanvasColor = System.Drawing.SystemColors.ControlDark;
            Main_Panel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            Main_Panel.Controls.Add(expandablePanel_Escorts);
            Main_Panel.Controls.Add(label7);
            Main_Panel.Controls.Add(checkBox_AddExtension);
            Main_Panel.Controls.Add(panel11);
            Main_Panel.Controls.Add(button_Exit);
            Main_Panel.Controls.Add(button_Print);
            Main_Panel.Controls.Add(panel12);
            Main_Panel.Controls.Add(textBox_Place);
            Main_Panel.Controls.Add(label39);
            Main_Panel.Controls.Add(panel9);
            Main_Panel.Controls.Add(label3);
            Main_Panel.Controls.Add(checkBox_CreatePassport);
            Main_Panel.Controls.Add(checkBox_CreateIdentity);
            Main_Panel.Controls.Add(panel8);
            Main_Panel.Controls.Add(panel7);
            Main_Panel.Controls.Add(panel6);
            Main_Panel.Controls.Add(panel5);
            Main_Panel.Controls.Add(label6);
            Main_Panel.Controls.Add(checkBox_SponsorTransfer);
            Main_Panel.Controls.Add(panel3);
            Main_Panel.Controls.Add(panel2);
            Main_Panel.Controls.Add(label22);
            Main_Panel.Controls.Add(panel1);
            Main_Panel.Controls.Add(panel4);
            Main_Panel.Font = null;
            Main_Panel.Name = "Main_Panel";
            Main_Panel.Style.Alignment = System.Drawing.StringAlignment.Center;
            Main_Panel.Style.BackColor1.Color = System.Drawing.Color.AliceBlue;
            Main_Panel.Style.BackColor2.Color = System.Drawing.SystemColors.GradientActiveCaption;
            Main_Panel.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            Main_Panel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            Main_Panel.Style.GradientAngle = 90;
            Main_Panel.Style.WordWrap = true;
            expandablePanel_Escorts.AccessibleDescription = null;
            expandablePanel_Escorts.AccessibleName = null;
            resources.ApplyResources(expandablePanel_Escorts, "expandablePanel_Escorts");
            expandablePanel_Escorts.CanvasColor = System.Drawing.Color.Transparent;
            expandablePanel_Escorts.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.TopToBottom;
            expandablePanel_Escorts.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            expandablePanel_Escorts.Controls.Add(panel10);
            expandablePanel_Escorts.Expanded = false;
            expandablePanel_Escorts.ExpandedBounds = new System.Drawing.Rectangle(0, 0, 645, 566);
            expandablePanel_Escorts.Name = "expandablePanel_Escorts";
            expandablePanel_Escorts.Style.Alignment = System.Drawing.StringAlignment.Center;
            expandablePanel_Escorts.Style.BackColor1.Color = System.Drawing.Color.FromArgb(227, 239, 255);
            expandablePanel_Escorts.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            expandablePanel_Escorts.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            expandablePanel_Escorts.Style.GradientAngle = 90;
            expandablePanel_Escorts.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            expandablePanel_Escorts.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            expandablePanel_Escorts.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            expandablePanel_Escorts.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            expandablePanel_Escorts.TitleStyle.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            expandablePanel_Escorts.TitleStyle.ForeColor.Color = System.Drawing.Color.FromArgb(64, 64, 64);
            expandablePanel_Escorts.TitleStyle.GradientAngle = 90;
            panel10.AccessibleDescription = null;
            panel10.AccessibleName = null;
            resources.ApplyResources(panel10, "panel10");
            panel10.BackColor = System.Drawing.Color.AliceBlue;
            panel10.BackgroundImage = null;
            panel10.Controls.Add(button_Back);
            panel10.Controls.Add(button_Family);
            panel10.Controls.Add(label45);
            panel10.Controls.Add(label46);
            panel10.Controls.Add(textBox_EnterNo15);
            panel10.Controls.Add(textBox_Port15);
            panel10.Controls.Add(textBox_EnterNo14);
            panel10.Controls.Add(textBox_Port14);
            panel10.Controls.Add(textBox_EnterNo13);
            panel10.Controls.Add(textBox_Port13);
            panel10.Controls.Add(textBox_EnterNo12);
            panel10.Controls.Add(textBox_Port12);
            panel10.Controls.Add(textBox_EnterNo11);
            panel10.Controls.Add(textBox_Port11);
            panel10.Controls.Add(textBox_EnterNo10);
            panel10.Controls.Add(textBox_Port10);
            panel10.Controls.Add(textBox_EnterNo9);
            panel10.Controls.Add(textBox_Port9);
            panel10.Controls.Add(textBox_EnterNo8);
            panel10.Controls.Add(textBox_Port8);
            panel10.Controls.Add(textBox_EnterNo7);
            panel10.Controls.Add(textBox_Port7);
            panel10.Controls.Add(textBox_EnterNo6);
            panel10.Controls.Add(textBox_Port6);
            panel10.Controls.Add(textBox_EnterNo5);
            panel10.Controls.Add(textBox_Port5);
            panel10.Controls.Add(textBox_EnterNo4);
            panel10.Controls.Add(textBox_Port4);
            panel10.Controls.Add(textBox_EnterNo3);
            panel10.Controls.Add(textBox_Port3);
            panel10.Controls.Add(textBox_EnterNo2);
            panel10.Controls.Add(textBox_Port2);
            panel10.Controls.Add(textBox_EnterNo1);
            panel10.Controls.Add(textBox_Port1);
            panel10.Controls.Add(dateTimeInput_PassportDateEnd15);
            panel10.Controls.Add(dateTimeInput_PassportDateEnd14);
            panel10.Controls.Add(dateTimeInput_PassportDateEnd13);
            panel10.Controls.Add(dateTimeInput_PassportDateEnd12);
            panel10.Controls.Add(dateTimeInput_PassportDateEnd11);
            panel10.Controls.Add(dateTimeInput_PassportDateEnd10);
            panel10.Controls.Add(dateTimeInput_PassportDateEnd9);
            panel10.Controls.Add(dateTimeInput_PassportDateEnd8);
            panel10.Controls.Add(dateTimeInput_PassportDateEnd7);
            panel10.Controls.Add(dateTimeInput_PassportDateEnd6);
            panel10.Controls.Add(dateTimeInput_PassportDateEnd5);
            panel10.Controls.Add(dateTimeInput_PassportDateEnd4);
            panel10.Controls.Add(dateTimeInput_PassportDateEnd3);
            panel10.Controls.Add(dateTimeInput_PassportDateEnd2);
            panel10.Controls.Add(dateTimeInput_PassportDateEnd1);
            panel10.Controls.Add(dateTimeInput_BirthDate15);
            panel10.Controls.Add(dateTimeInput_BirthDate14);
            panel10.Controls.Add(dateTimeInput_BirthDate13);
            panel10.Controls.Add(dateTimeInput_BirthDate12);
            panel10.Controls.Add(dateTimeInput_BirthDate11);
            panel10.Controls.Add(dateTimeInput_BirthDate10);
            panel10.Controls.Add(dateTimeInput_BirthDate9);
            panel10.Controls.Add(dateTimeInput_BirthDate8);
            panel10.Controls.Add(dateTimeInput_BirthDate7);
            panel10.Controls.Add(dateTimeInput_BirthDate6);
            panel10.Controls.Add(dateTimeInput_BirthDate5);
            panel10.Controls.Add(dateTimeInput_BirthDate4);
            panel10.Controls.Add(dateTimeInput_BirthDate3);
            panel10.Controls.Add(dateTimeInput_BirthDate2);
            panel10.Controls.Add(dateTimeInput_BirthDate1);
            panel10.Controls.Add(label40);
            panel10.Controls.Add(label41);
            panel10.Controls.Add(label42);
            panel10.Controls.Add(label43);
            panel10.Controls.Add(textBox_PassporntNo15);
            panel10.Controls.Add(textBox_Relation15);
            panel10.Controls.Add(textBox_Name15);
            panel10.Controls.Add(textBox_PassporntNo14);
            panel10.Controls.Add(textBox_Relation14);
            panel10.Controls.Add(textBox_Name14);
            panel10.Controls.Add(textBox_PassporntNo13);
            panel10.Controls.Add(textBox_Relation13);
            panel10.Controls.Add(textBox_Name13);
            panel10.Controls.Add(textBox_PassporntNo12);
            panel10.Controls.Add(textBox_Relation12);
            panel10.Controls.Add(textBox_Name12);
            panel10.Controls.Add(textBox_PassporntNo11);
            panel10.Controls.Add(textBox_Relation11);
            panel10.Controls.Add(textBox_Name11);
            panel10.Controls.Add(textBox_PassporntNo10);
            panel10.Controls.Add(textBox_Relation10);
            panel10.Controls.Add(textBox_Name10);
            panel10.Controls.Add(textBox_PassporntNo9);
            panel10.Controls.Add(textBox_Relation9);
            panel10.Controls.Add(textBox_Name9);
            panel10.Controls.Add(textBox_PassporntNo8);
            panel10.Controls.Add(textBox_Relation8);
            panel10.Controls.Add(textBox_Name8);
            panel10.Controls.Add(textBox_PassporntNo7);
            panel10.Controls.Add(textBox_Relation7);
            panel10.Controls.Add(textBox_Name7);
            panel10.Controls.Add(textBox_PassporntNo6);
            panel10.Controls.Add(textBox_Relation6);
            panel10.Controls.Add(textBox_Name6);
            panel10.Controls.Add(textBox_PassporntNo5);
            panel10.Controls.Add(textBox_Relation5);
            panel10.Controls.Add(textBox_Name5);
            panel10.Controls.Add(textBox_PassporntNo4);
            panel10.Controls.Add(textBox_Relation4);
            panel10.Controls.Add(textBox_Name4);
            panel10.Controls.Add(textBox_PassporntNo3);
            panel10.Controls.Add(textBox_Relation3);
            panel10.Controls.Add(textBox_Name3);
            panel10.Controls.Add(textBox_PassporntNo2);
            panel10.Controls.Add(textBox_Relation2);
            panel10.Controls.Add(textBox_Name2);
            panel10.Controls.Add(textBox_PassporntNo1);
            panel10.Controls.Add(textBox_Relation1);
            panel10.Controls.Add(textBox_Name1);
            panel10.Controls.Add(label44);
            panel10.Controls.Add(dataGridView_Family);
            panel10.Font = null;
            panel10.Name = "panel10";
            button_Back.AccessibleDescription = null;
            button_Back.AccessibleName = null;
            button_Back.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_Back, "button_Back");
            button_Back.BackgroundImage = null;
            button_Back.Checked = true;
            button_Back.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            button_Back.CommandParameter = null;
            button_Back.Name = "button_Back";
            button_Back.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_Back.Symbol = "\uf011";
            button_Back.SymbolSize = 16f;
            button_Back.TextColor = System.Drawing.Color.Black;
            button_Back.Click += new System.EventHandler(button_Back_Click);
            button_Family.AccessibleDescription = null;
            button_Family.AccessibleName = null;
            button_Family.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_Family, "button_Family");
            button_Family.BackgroundImage = null;
            button_Family.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            button_Family.CommandParameter = null;
            button_Family.Name = "button_Family";
            button_Family.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_Family.Symbol = "\uf011";
            button_Family.SymbolSize = 16f;
            button_Family.TextColor = System.Drawing.Color.White;
            button_Family.Click += new System.EventHandler(button_Family_Click);
            label45.AccessibleDescription = null;
            label45.AccessibleName = null;
            resources.ApplyResources(label45, "label45");
            label45.BackColor = System.Drawing.Color.SteelBlue;
            label45.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label45.ForeColor = System.Drawing.Color.White;
            label45.Name = "label45";
            label46.AccessibleDescription = null;
            label46.AccessibleName = null;
            resources.ApplyResources(label46, "label46");
            label46.BackColor = System.Drawing.Color.SteelBlue;
            label46.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label46.ForeColor = System.Drawing.Color.White;
            label46.Name = "label46";
            textBox_EnterNo15.AccessibleDescription = null;
            textBox_EnterNo15.AccessibleName = null;
            resources.ApplyResources(textBox_EnterNo15, "textBox_EnterNo15");
            textBox_EnterNo15.BackColor = System.Drawing.Color.White;
            textBox_EnterNo15.BackgroundImage = null;
            textBox_EnterNo15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_EnterNo15.Name = "textBox_EnterNo15";
            textBox_Port15.AccessibleDescription = null;
            textBox_Port15.AccessibleName = null;
            resources.ApplyResources(textBox_Port15, "textBox_Port15");
            textBox_Port15.BackColor = System.Drawing.Color.White;
            textBox_Port15.BackgroundImage = null;
            textBox_Port15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Port15.Name = "textBox_Port15";
            textBox_EnterNo14.AccessibleDescription = null;
            textBox_EnterNo14.AccessibleName = null;
            resources.ApplyResources(textBox_EnterNo14, "textBox_EnterNo14");
            textBox_EnterNo14.BackColor = System.Drawing.Color.White;
            textBox_EnterNo14.BackgroundImage = null;
            textBox_EnterNo14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_EnterNo14.Name = "textBox_EnterNo14";
            textBox_Port14.AccessibleDescription = null;
            textBox_Port14.AccessibleName = null;
            resources.ApplyResources(textBox_Port14, "textBox_Port14");
            textBox_Port14.BackColor = System.Drawing.Color.White;
            textBox_Port14.BackgroundImage = null;
            textBox_Port14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Port14.Name = "textBox_Port14";
            textBox_EnterNo13.AccessibleDescription = null;
            textBox_EnterNo13.AccessibleName = null;
            resources.ApplyResources(textBox_EnterNo13, "textBox_EnterNo13");
            textBox_EnterNo13.BackColor = System.Drawing.Color.White;
            textBox_EnterNo13.BackgroundImage = null;
            textBox_EnterNo13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_EnterNo13.Name = "textBox_EnterNo13";
            textBox_Port13.AccessibleDescription = null;
            textBox_Port13.AccessibleName = null;
            resources.ApplyResources(textBox_Port13, "textBox_Port13");
            textBox_Port13.BackColor = System.Drawing.Color.White;
            textBox_Port13.BackgroundImage = null;
            textBox_Port13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Port13.Name = "textBox_Port13";
            textBox_EnterNo12.AccessibleDescription = null;
            textBox_EnterNo12.AccessibleName = null;
            resources.ApplyResources(textBox_EnterNo12, "textBox_EnterNo12");
            textBox_EnterNo12.BackColor = System.Drawing.Color.White;
            textBox_EnterNo12.BackgroundImage = null;
            textBox_EnterNo12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_EnterNo12.Name = "textBox_EnterNo12";
            textBox_Port12.AccessibleDescription = null;
            textBox_Port12.AccessibleName = null;
            resources.ApplyResources(textBox_Port12, "textBox_Port12");
            textBox_Port12.BackColor = System.Drawing.Color.White;
            textBox_Port12.BackgroundImage = null;
            textBox_Port12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Port12.Name = "textBox_Port12";
            textBox_EnterNo11.AccessibleDescription = null;
            textBox_EnterNo11.AccessibleName = null;
            resources.ApplyResources(textBox_EnterNo11, "textBox_EnterNo11");
            textBox_EnterNo11.BackColor = System.Drawing.Color.White;
            textBox_EnterNo11.BackgroundImage = null;
            textBox_EnterNo11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_EnterNo11.Name = "textBox_EnterNo11";
            textBox_Port11.AccessibleDescription = null;
            textBox_Port11.AccessibleName = null;
            resources.ApplyResources(textBox_Port11, "textBox_Port11");
            textBox_Port11.BackColor = System.Drawing.Color.White;
            textBox_Port11.BackgroundImage = null;
            textBox_Port11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Port11.Name = "textBox_Port11";
            textBox_EnterNo10.AccessibleDescription = null;
            textBox_EnterNo10.AccessibleName = null;
            resources.ApplyResources(textBox_EnterNo10, "textBox_EnterNo10");
            textBox_EnterNo10.BackColor = System.Drawing.Color.White;
            textBox_EnterNo10.BackgroundImage = null;
            textBox_EnterNo10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_EnterNo10.Name = "textBox_EnterNo10";
            textBox_Port10.AccessibleDescription = null;
            textBox_Port10.AccessibleName = null;
            resources.ApplyResources(textBox_Port10, "textBox_Port10");
            textBox_Port10.BackColor = System.Drawing.Color.White;
            textBox_Port10.BackgroundImage = null;
            textBox_Port10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Port10.Name = "textBox_Port10";
            textBox_EnterNo9.AccessibleDescription = null;
            textBox_EnterNo9.AccessibleName = null;
            resources.ApplyResources(textBox_EnterNo9, "textBox_EnterNo9");
            textBox_EnterNo9.BackColor = System.Drawing.Color.White;
            textBox_EnterNo9.BackgroundImage = null;
            textBox_EnterNo9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_EnterNo9.Name = "textBox_EnterNo9";
            textBox_Port9.AccessibleDescription = null;
            textBox_Port9.AccessibleName = null;
            resources.ApplyResources(textBox_Port9, "textBox_Port9");
            textBox_Port9.BackColor = System.Drawing.Color.White;
            textBox_Port9.BackgroundImage = null;
            textBox_Port9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Port9.Name = "textBox_Port9";
            textBox_EnterNo8.AccessibleDescription = null;
            textBox_EnterNo8.AccessibleName = null;
            resources.ApplyResources(textBox_EnterNo8, "textBox_EnterNo8");
            textBox_EnterNo8.BackColor = System.Drawing.Color.White;
            textBox_EnterNo8.BackgroundImage = null;
            textBox_EnterNo8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_EnterNo8.Name = "textBox_EnterNo8";
            textBox_Port8.AccessibleDescription = null;
            textBox_Port8.AccessibleName = null;
            resources.ApplyResources(textBox_Port8, "textBox_Port8");
            textBox_Port8.BackColor = System.Drawing.Color.White;
            textBox_Port8.BackgroundImage = null;
            textBox_Port8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Port8.Name = "textBox_Port8";
            textBox_EnterNo7.AccessibleDescription = null;
            textBox_EnterNo7.AccessibleName = null;
            resources.ApplyResources(textBox_EnterNo7, "textBox_EnterNo7");
            textBox_EnterNo7.BackColor = System.Drawing.Color.White;
            textBox_EnterNo7.BackgroundImage = null;
            textBox_EnterNo7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_EnterNo7.Name = "textBox_EnterNo7";
            textBox_Port7.AccessibleDescription = null;
            textBox_Port7.AccessibleName = null;
            resources.ApplyResources(textBox_Port7, "textBox_Port7");
            textBox_Port7.BackColor = System.Drawing.Color.White;
            textBox_Port7.BackgroundImage = null;
            textBox_Port7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Port7.Name = "textBox_Port7";
            textBox_EnterNo6.AccessibleDescription = null;
            textBox_EnterNo6.AccessibleName = null;
            resources.ApplyResources(textBox_EnterNo6, "textBox_EnterNo6");
            textBox_EnterNo6.BackColor = System.Drawing.Color.White;
            textBox_EnterNo6.BackgroundImage = null;
            textBox_EnterNo6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_EnterNo6.Name = "textBox_EnterNo6";
            textBox_Port6.AccessibleDescription = null;
            textBox_Port6.AccessibleName = null;
            resources.ApplyResources(textBox_Port6, "textBox_Port6");
            textBox_Port6.BackColor = System.Drawing.Color.White;
            textBox_Port6.BackgroundImage = null;
            textBox_Port6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Port6.Name = "textBox_Port6";
            textBox_EnterNo5.AccessibleDescription = null;
            textBox_EnterNo5.AccessibleName = null;
            resources.ApplyResources(textBox_EnterNo5, "textBox_EnterNo5");
            textBox_EnterNo5.BackColor = System.Drawing.Color.White;
            textBox_EnterNo5.BackgroundImage = null;
            textBox_EnterNo5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_EnterNo5.Name = "textBox_EnterNo5";
            textBox_Port5.AccessibleDescription = null;
            textBox_Port5.AccessibleName = null;
            resources.ApplyResources(textBox_Port5, "textBox_Port5");
            textBox_Port5.BackColor = System.Drawing.Color.White;
            textBox_Port5.BackgroundImage = null;
            textBox_Port5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Port5.Name = "textBox_Port5";
            textBox_EnterNo4.AccessibleDescription = null;
            textBox_EnterNo4.AccessibleName = null;
            resources.ApplyResources(textBox_EnterNo4, "textBox_EnterNo4");
            textBox_EnterNo4.BackColor = System.Drawing.Color.White;
            textBox_EnterNo4.BackgroundImage = null;
            textBox_EnterNo4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_EnterNo4.Name = "textBox_EnterNo4";
            textBox_Port4.AccessibleDescription = null;
            textBox_Port4.AccessibleName = null;
            resources.ApplyResources(textBox_Port4, "textBox_Port4");
            textBox_Port4.BackColor = System.Drawing.Color.White;
            textBox_Port4.BackgroundImage = null;
            textBox_Port4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Port4.Name = "textBox_Port4";
            textBox_EnterNo3.AccessibleDescription = null;
            textBox_EnterNo3.AccessibleName = null;
            resources.ApplyResources(textBox_EnterNo3, "textBox_EnterNo3");
            textBox_EnterNo3.BackColor = System.Drawing.Color.White;
            textBox_EnterNo3.BackgroundImage = null;
            textBox_EnterNo3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_EnterNo3.Name = "textBox_EnterNo3";
            textBox_Port3.AccessibleDescription = null;
            textBox_Port3.AccessibleName = null;
            resources.ApplyResources(textBox_Port3, "textBox_Port3");
            textBox_Port3.BackColor = System.Drawing.Color.White;
            textBox_Port3.BackgroundImage = null;
            textBox_Port3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Port3.Name = "textBox_Port3";
            textBox_EnterNo2.AccessibleDescription = null;
            textBox_EnterNo2.AccessibleName = null;
            resources.ApplyResources(textBox_EnterNo2, "textBox_EnterNo2");
            textBox_EnterNo2.BackColor = System.Drawing.Color.White;
            textBox_EnterNo2.BackgroundImage = null;
            textBox_EnterNo2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_EnterNo2.Name = "textBox_EnterNo2";
            textBox_Port2.AccessibleDescription = null;
            textBox_Port2.AccessibleName = null;
            resources.ApplyResources(textBox_Port2, "textBox_Port2");
            textBox_Port2.BackColor = System.Drawing.Color.White;
            textBox_Port2.BackgroundImage = null;
            textBox_Port2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Port2.Name = "textBox_Port2";
            textBox_EnterNo1.AccessibleDescription = null;
            textBox_EnterNo1.AccessibleName = null;
            resources.ApplyResources(textBox_EnterNo1, "textBox_EnterNo1");
            textBox_EnterNo1.BackColor = System.Drawing.Color.White;
            textBox_EnterNo1.BackgroundImage = null;
            textBox_EnterNo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_EnterNo1.Name = "textBox_EnterNo1";
            textBox_Port1.AccessibleDescription = null;
            textBox_Port1.AccessibleName = null;
            resources.ApplyResources(textBox_Port1, "textBox_Port1");
            textBox_Port1.BackColor = System.Drawing.Color.White;
            textBox_Port1.BackgroundImage = null;
            textBox_Port1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Port1.Name = "textBox_Port1";
            dateTimeInput_PassportDateEnd15.AccessibleDescription = null;
            dateTimeInput_PassportDateEnd15.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_PassportDateEnd15, "dateTimeInput_PassportDateEnd15");
            dateTimeInput_PassportDateEnd15.BackgroundImage = null;
            dateTimeInput_PassportDateEnd15.Name = "dateTimeInput_PassportDateEnd15";
            dateTimeInput_PassportDateEnd14.AccessibleDescription = null;
            dateTimeInput_PassportDateEnd14.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_PassportDateEnd14, "dateTimeInput_PassportDateEnd14");
            dateTimeInput_PassportDateEnd14.BackgroundImage = null;
            dateTimeInput_PassportDateEnd14.Name = "dateTimeInput_PassportDateEnd14";
            dateTimeInput_PassportDateEnd13.AccessibleDescription = null;
            dateTimeInput_PassportDateEnd13.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_PassportDateEnd13, "dateTimeInput_PassportDateEnd13");
            dateTimeInput_PassportDateEnd13.BackgroundImage = null;
            dateTimeInput_PassportDateEnd13.Name = "dateTimeInput_PassportDateEnd13";
            dateTimeInput_PassportDateEnd12.AccessibleDescription = null;
            dateTimeInput_PassportDateEnd12.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_PassportDateEnd12, "dateTimeInput_PassportDateEnd12");
            dateTimeInput_PassportDateEnd12.BackgroundImage = null;
            dateTimeInput_PassportDateEnd12.Name = "dateTimeInput_PassportDateEnd12";
            dateTimeInput_PassportDateEnd11.AccessibleDescription = null;
            dateTimeInput_PassportDateEnd11.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_PassportDateEnd11, "dateTimeInput_PassportDateEnd11");
            dateTimeInput_PassportDateEnd11.BackgroundImage = null;
            dateTimeInput_PassportDateEnd11.Name = "dateTimeInput_PassportDateEnd11";
            dateTimeInput_PassportDateEnd10.AccessibleDescription = null;
            dateTimeInput_PassportDateEnd10.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_PassportDateEnd10, "dateTimeInput_PassportDateEnd10");
            dateTimeInput_PassportDateEnd10.BackgroundImage = null;
            dateTimeInput_PassportDateEnd10.Name = "dateTimeInput_PassportDateEnd10";
            dateTimeInput_PassportDateEnd9.AccessibleDescription = null;
            dateTimeInput_PassportDateEnd9.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_PassportDateEnd9, "dateTimeInput_PassportDateEnd9");
            dateTimeInput_PassportDateEnd9.BackgroundImage = null;
            dateTimeInput_PassportDateEnd9.Name = "dateTimeInput_PassportDateEnd9";
            dateTimeInput_PassportDateEnd8.AccessibleDescription = null;
            dateTimeInput_PassportDateEnd8.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_PassportDateEnd8, "dateTimeInput_PassportDateEnd8");
            dateTimeInput_PassportDateEnd8.BackgroundImage = null;
            dateTimeInput_PassportDateEnd8.Name = "dateTimeInput_PassportDateEnd8";
            dateTimeInput_PassportDateEnd7.AccessibleDescription = null;
            dateTimeInput_PassportDateEnd7.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_PassportDateEnd7, "dateTimeInput_PassportDateEnd7");
            dateTimeInput_PassportDateEnd7.BackgroundImage = null;
            dateTimeInput_PassportDateEnd7.Name = "dateTimeInput_PassportDateEnd7";
            dateTimeInput_PassportDateEnd6.AccessibleDescription = null;
            dateTimeInput_PassportDateEnd6.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_PassportDateEnd6, "dateTimeInput_PassportDateEnd6");
            dateTimeInput_PassportDateEnd6.BackgroundImage = null;
            dateTimeInput_PassportDateEnd6.Name = "dateTimeInput_PassportDateEnd6";
            dateTimeInput_PassportDateEnd5.AccessibleDescription = null;
            dateTimeInput_PassportDateEnd5.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_PassportDateEnd5, "dateTimeInput_PassportDateEnd5");
            dateTimeInput_PassportDateEnd5.BackgroundImage = null;
            dateTimeInput_PassportDateEnd5.Name = "dateTimeInput_PassportDateEnd5";
            dateTimeInput_PassportDateEnd4.AccessibleDescription = null;
            dateTimeInput_PassportDateEnd4.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_PassportDateEnd4, "dateTimeInput_PassportDateEnd4");
            dateTimeInput_PassportDateEnd4.BackgroundImage = null;
            dateTimeInput_PassportDateEnd4.Name = "dateTimeInput_PassportDateEnd4";
            dateTimeInput_PassportDateEnd3.AccessibleDescription = null;
            dateTimeInput_PassportDateEnd3.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_PassportDateEnd3, "dateTimeInput_PassportDateEnd3");
            dateTimeInput_PassportDateEnd3.BackgroundImage = null;
            dateTimeInput_PassportDateEnd3.Name = "dateTimeInput_PassportDateEnd3";
            dateTimeInput_PassportDateEnd2.AccessibleDescription = null;
            dateTimeInput_PassportDateEnd2.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_PassportDateEnd2, "dateTimeInput_PassportDateEnd2");
            dateTimeInput_PassportDateEnd2.BackgroundImage = null;
            dateTimeInput_PassportDateEnd2.Name = "dateTimeInput_PassportDateEnd2";
            dateTimeInput_PassportDateEnd1.AccessibleDescription = null;
            dateTimeInput_PassportDateEnd1.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_PassportDateEnd1, "dateTimeInput_PassportDateEnd1");
            dateTimeInput_PassportDateEnd1.BackgroundImage = null;
            dateTimeInput_PassportDateEnd1.Name = "dateTimeInput_PassportDateEnd1";
            dateTimeInput_BirthDate15.AccessibleDescription = null;
            dateTimeInput_BirthDate15.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_BirthDate15, "dateTimeInput_BirthDate15");
            dateTimeInput_BirthDate15.BackgroundImage = null;
            dateTimeInput_BirthDate15.Name = "dateTimeInput_BirthDate15";
            dateTimeInput_BirthDate14.AccessibleDescription = null;
            dateTimeInput_BirthDate14.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_BirthDate14, "dateTimeInput_BirthDate14");
            dateTimeInput_BirthDate14.BackgroundImage = null;
            dateTimeInput_BirthDate14.Name = "dateTimeInput_BirthDate14";
            dateTimeInput_BirthDate13.AccessibleDescription = null;
            dateTimeInput_BirthDate13.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_BirthDate13, "dateTimeInput_BirthDate13");
            dateTimeInput_BirthDate13.BackgroundImage = null;
            dateTimeInput_BirthDate13.Name = "dateTimeInput_BirthDate13";
            dateTimeInput_BirthDate12.AccessibleDescription = null;
            dateTimeInput_BirthDate12.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_BirthDate12, "dateTimeInput_BirthDate12");
            dateTimeInput_BirthDate12.BackgroundImage = null;
            dateTimeInput_BirthDate12.Name = "dateTimeInput_BirthDate12";
            dateTimeInput_BirthDate11.AccessibleDescription = null;
            dateTimeInput_BirthDate11.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_BirthDate11, "dateTimeInput_BirthDate11");
            dateTimeInput_BirthDate11.BackgroundImage = null;
            dateTimeInput_BirthDate11.Name = "dateTimeInput_BirthDate11";
            dateTimeInput_BirthDate10.AccessibleDescription = null;
            dateTimeInput_BirthDate10.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_BirthDate10, "dateTimeInput_BirthDate10");
            dateTimeInput_BirthDate10.BackgroundImage = null;
            dateTimeInput_BirthDate10.Name = "dateTimeInput_BirthDate10";
            dateTimeInput_BirthDate9.AccessibleDescription = null;
            dateTimeInput_BirthDate9.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_BirthDate9, "dateTimeInput_BirthDate9");
            dateTimeInput_BirthDate9.BackgroundImage = null;
            dateTimeInput_BirthDate9.Name = "dateTimeInput_BirthDate9";
            dateTimeInput_BirthDate8.AccessibleDescription = null;
            dateTimeInput_BirthDate8.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_BirthDate8, "dateTimeInput_BirthDate8");
            dateTimeInput_BirthDate8.BackgroundImage = null;
            dateTimeInput_BirthDate8.Name = "dateTimeInput_BirthDate8";
            dateTimeInput_BirthDate7.AccessibleDescription = null;
            dateTimeInput_BirthDate7.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_BirthDate7, "dateTimeInput_BirthDate7");
            dateTimeInput_BirthDate7.BackgroundImage = null;
            dateTimeInput_BirthDate7.Name = "dateTimeInput_BirthDate7";
            dateTimeInput_BirthDate6.AccessibleDescription = null;
            dateTimeInput_BirthDate6.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_BirthDate6, "dateTimeInput_BirthDate6");
            dateTimeInput_BirthDate6.BackgroundImage = null;
            dateTimeInput_BirthDate6.Name = "dateTimeInput_BirthDate6";
            dateTimeInput_BirthDate5.AccessibleDescription = null;
            dateTimeInput_BirthDate5.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_BirthDate5, "dateTimeInput_BirthDate5");
            dateTimeInput_BirthDate5.BackgroundImage = null;
            dateTimeInput_BirthDate5.Name = "dateTimeInput_BirthDate5";
            dateTimeInput_BirthDate4.AccessibleDescription = null;
            dateTimeInput_BirthDate4.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_BirthDate4, "dateTimeInput_BirthDate4");
            dateTimeInput_BirthDate4.BackgroundImage = null;
            dateTimeInput_BirthDate4.Name = "dateTimeInput_BirthDate4";
            dateTimeInput_BirthDate3.AccessibleDescription = null;
            dateTimeInput_BirthDate3.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_BirthDate3, "dateTimeInput_BirthDate3");
            dateTimeInput_BirthDate3.BackgroundImage = null;
            dateTimeInput_BirthDate3.Name = "dateTimeInput_BirthDate3";
            dateTimeInput_BirthDate2.AccessibleDescription = null;
            dateTimeInput_BirthDate2.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_BirthDate2, "dateTimeInput_BirthDate2");
            dateTimeInput_BirthDate2.BackgroundImage = null;
            dateTimeInput_BirthDate2.Name = "dateTimeInput_BirthDate2";
            dateTimeInput_BirthDate1.AccessibleDescription = null;
            dateTimeInput_BirthDate1.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_BirthDate1, "dateTimeInput_BirthDate1");
            dateTimeInput_BirthDate1.BackgroundImage = null;
            dateTimeInput_BirthDate1.Name = "dateTimeInput_BirthDate1";
            label40.AccessibleDescription = null;
            label40.AccessibleName = null;
            resources.ApplyResources(label40, "label40");
            label40.BackColor = System.Drawing.Color.SteelBlue;
            label40.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label40.ForeColor = System.Drawing.Color.White;
            label40.Name = "label40";
            label41.AccessibleDescription = null;
            label41.AccessibleName = null;
            resources.ApplyResources(label41, "label41");
            label41.BackColor = System.Drawing.Color.SteelBlue;
            label41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label41.ForeColor = System.Drawing.Color.White;
            label41.Name = "label41";
            label42.AccessibleDescription = null;
            label42.AccessibleName = null;
            resources.ApplyResources(label42, "label42");
            label42.BackColor = System.Drawing.Color.SteelBlue;
            label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label42.ForeColor = System.Drawing.Color.White;
            label42.Name = "label42";
            label43.AccessibleDescription = null;
            label43.AccessibleName = null;
            resources.ApplyResources(label43, "label43");
            label43.BackColor = System.Drawing.Color.SteelBlue;
            label43.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label43.ForeColor = System.Drawing.Color.White;
            label43.Name = "label43";
            textBox_PassporntNo15.AccessibleDescription = null;
            textBox_PassporntNo15.AccessibleName = null;
            resources.ApplyResources(textBox_PassporntNo15, "textBox_PassporntNo15");
            textBox_PassporntNo15.BackColor = System.Drawing.Color.White;
            textBox_PassporntNo15.BackgroundImage = null;
            textBox_PassporntNo15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_PassporntNo15.Name = "textBox_PassporntNo15";
            textBox_Relation15.AccessibleDescription = null;
            textBox_Relation15.AccessibleName = null;
            resources.ApplyResources(textBox_Relation15, "textBox_Relation15");
            textBox_Relation15.BackColor = System.Drawing.Color.White;
            textBox_Relation15.BackgroundImage = null;
            textBox_Relation15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Relation15.Name = "textBox_Relation15";
            textBox_Name15.AccessibleDescription = null;
            textBox_Name15.AccessibleName = null;
            resources.ApplyResources(textBox_Name15, "textBox_Name15");
            textBox_Name15.BackColor = System.Drawing.Color.White;
            textBox_Name15.BackgroundImage = null;
            textBox_Name15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Name15.Name = "textBox_Name15";
            textBox_PassporntNo14.AccessibleDescription = null;
            textBox_PassporntNo14.AccessibleName = null;
            resources.ApplyResources(textBox_PassporntNo14, "textBox_PassporntNo14");
            textBox_PassporntNo14.BackColor = System.Drawing.Color.White;
            textBox_PassporntNo14.BackgroundImage = null;
            textBox_PassporntNo14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_PassporntNo14.Name = "textBox_PassporntNo14";
            textBox_Relation14.AccessibleDescription = null;
            textBox_Relation14.AccessibleName = null;
            resources.ApplyResources(textBox_Relation14, "textBox_Relation14");
            textBox_Relation14.BackColor = System.Drawing.Color.White;
            textBox_Relation14.BackgroundImage = null;
            textBox_Relation14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Relation14.Name = "textBox_Relation14";
            textBox_Name14.AccessibleDescription = null;
            textBox_Name14.AccessibleName = null;
            resources.ApplyResources(textBox_Name14, "textBox_Name14");
            textBox_Name14.BackColor = System.Drawing.Color.White;
            textBox_Name14.BackgroundImage = null;
            textBox_Name14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Name14.Name = "textBox_Name14";
            textBox_PassporntNo13.AccessibleDescription = null;
            textBox_PassporntNo13.AccessibleName = null;
            resources.ApplyResources(textBox_PassporntNo13, "textBox_PassporntNo13");
            textBox_PassporntNo13.BackColor = System.Drawing.Color.White;
            textBox_PassporntNo13.BackgroundImage = null;
            textBox_PassporntNo13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_PassporntNo13.Name = "textBox_PassporntNo13";
            textBox_Relation13.AccessibleDescription = null;
            textBox_Relation13.AccessibleName = null;
            resources.ApplyResources(textBox_Relation13, "textBox_Relation13");
            textBox_Relation13.BackColor = System.Drawing.Color.White;
            textBox_Relation13.BackgroundImage = null;
            textBox_Relation13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Relation13.Name = "textBox_Relation13";
            textBox_Name13.AccessibleDescription = null;
            textBox_Name13.AccessibleName = null;
            resources.ApplyResources(textBox_Name13, "textBox_Name13");
            textBox_Name13.BackColor = System.Drawing.Color.White;
            textBox_Name13.BackgroundImage = null;
            textBox_Name13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Name13.Name = "textBox_Name13";
            textBox_PassporntNo12.AccessibleDescription = null;
            textBox_PassporntNo12.AccessibleName = null;
            resources.ApplyResources(textBox_PassporntNo12, "textBox_PassporntNo12");
            textBox_PassporntNo12.BackColor = System.Drawing.Color.White;
            textBox_PassporntNo12.BackgroundImage = null;
            textBox_PassporntNo12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_PassporntNo12.Name = "textBox_PassporntNo12";
            textBox_Relation12.AccessibleDescription = null;
            textBox_Relation12.AccessibleName = null;
            resources.ApplyResources(textBox_Relation12, "textBox_Relation12");
            textBox_Relation12.BackColor = System.Drawing.Color.White;
            textBox_Relation12.BackgroundImage = null;
            textBox_Relation12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Relation12.Name = "textBox_Relation12";
            textBox_Name12.AccessibleDescription = null;
            textBox_Name12.AccessibleName = null;
            resources.ApplyResources(textBox_Name12, "textBox_Name12");
            textBox_Name12.BackColor = System.Drawing.Color.White;
            textBox_Name12.BackgroundImage = null;
            textBox_Name12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Name12.Name = "textBox_Name12";
            textBox_PassporntNo11.AccessibleDescription = null;
            textBox_PassporntNo11.AccessibleName = null;
            resources.ApplyResources(textBox_PassporntNo11, "textBox_PassporntNo11");
            textBox_PassporntNo11.BackColor = System.Drawing.Color.White;
            textBox_PassporntNo11.BackgroundImage = null;
            textBox_PassporntNo11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_PassporntNo11.Name = "textBox_PassporntNo11";
            textBox_Relation11.AccessibleDescription = null;
            textBox_Relation11.AccessibleName = null;
            resources.ApplyResources(textBox_Relation11, "textBox_Relation11");
            textBox_Relation11.BackColor = System.Drawing.Color.White;
            textBox_Relation11.BackgroundImage = null;
            textBox_Relation11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Relation11.Name = "textBox_Relation11";
            textBox_Name11.AccessibleDescription = null;
            textBox_Name11.AccessibleName = null;
            resources.ApplyResources(textBox_Name11, "textBox_Name11");
            textBox_Name11.BackColor = System.Drawing.Color.White;
            textBox_Name11.BackgroundImage = null;
            textBox_Name11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Name11.Name = "textBox_Name11";
            textBox_PassporntNo10.AccessibleDescription = null;
            textBox_PassporntNo10.AccessibleName = null;
            resources.ApplyResources(textBox_PassporntNo10, "textBox_PassporntNo10");
            textBox_PassporntNo10.BackColor = System.Drawing.Color.White;
            textBox_PassporntNo10.BackgroundImage = null;
            textBox_PassporntNo10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_PassporntNo10.Name = "textBox_PassporntNo10";
            textBox_Relation10.AccessibleDescription = null;
            textBox_Relation10.AccessibleName = null;
            resources.ApplyResources(textBox_Relation10, "textBox_Relation10");
            textBox_Relation10.BackColor = System.Drawing.Color.White;
            textBox_Relation10.BackgroundImage = null;
            textBox_Relation10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Relation10.Name = "textBox_Relation10";
            textBox_Name10.AccessibleDescription = null;
            textBox_Name10.AccessibleName = null;
            resources.ApplyResources(textBox_Name10, "textBox_Name10");
            textBox_Name10.BackColor = System.Drawing.Color.White;
            textBox_Name10.BackgroundImage = null;
            textBox_Name10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Name10.Name = "textBox_Name10";
            textBox_PassporntNo9.AccessibleDescription = null;
            textBox_PassporntNo9.AccessibleName = null;
            resources.ApplyResources(textBox_PassporntNo9, "textBox_PassporntNo9");
            textBox_PassporntNo9.BackColor = System.Drawing.Color.White;
            textBox_PassporntNo9.BackgroundImage = null;
            textBox_PassporntNo9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_PassporntNo9.Name = "textBox_PassporntNo9";
            textBox_Relation9.AccessibleDescription = null;
            textBox_Relation9.AccessibleName = null;
            resources.ApplyResources(textBox_Relation9, "textBox_Relation9");
            textBox_Relation9.BackColor = System.Drawing.Color.White;
            textBox_Relation9.BackgroundImage = null;
            textBox_Relation9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Relation9.Name = "textBox_Relation9";
            textBox_Name9.AccessibleDescription = null;
            textBox_Name9.AccessibleName = null;
            resources.ApplyResources(textBox_Name9, "textBox_Name9");
            textBox_Name9.BackColor = System.Drawing.Color.White;
            textBox_Name9.BackgroundImage = null;
            textBox_Name9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Name9.Name = "textBox_Name9";
            textBox_PassporntNo8.AccessibleDescription = null;
            textBox_PassporntNo8.AccessibleName = null;
            resources.ApplyResources(textBox_PassporntNo8, "textBox_PassporntNo8");
            textBox_PassporntNo8.BackColor = System.Drawing.Color.White;
            textBox_PassporntNo8.BackgroundImage = null;
            textBox_PassporntNo8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_PassporntNo8.Name = "textBox_PassporntNo8";
            textBox_Relation8.AccessibleDescription = null;
            textBox_Relation8.AccessibleName = null;
            resources.ApplyResources(textBox_Relation8, "textBox_Relation8");
            textBox_Relation8.BackColor = System.Drawing.Color.White;
            textBox_Relation8.BackgroundImage = null;
            textBox_Relation8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Relation8.Name = "textBox_Relation8";
            textBox_Name8.AccessibleDescription = null;
            textBox_Name8.AccessibleName = null;
            resources.ApplyResources(textBox_Name8, "textBox_Name8");
            textBox_Name8.BackColor = System.Drawing.Color.White;
            textBox_Name8.BackgroundImage = null;
            textBox_Name8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Name8.Name = "textBox_Name8";
            textBox_PassporntNo7.AccessibleDescription = null;
            textBox_PassporntNo7.AccessibleName = null;
            resources.ApplyResources(textBox_PassporntNo7, "textBox_PassporntNo7");
            textBox_PassporntNo7.BackColor = System.Drawing.Color.White;
            textBox_PassporntNo7.BackgroundImage = null;
            textBox_PassporntNo7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_PassporntNo7.Name = "textBox_PassporntNo7";
            textBox_Relation7.AccessibleDescription = null;
            textBox_Relation7.AccessibleName = null;
            resources.ApplyResources(textBox_Relation7, "textBox_Relation7");
            textBox_Relation7.BackColor = System.Drawing.Color.White;
            textBox_Relation7.BackgroundImage = null;
            textBox_Relation7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Relation7.Name = "textBox_Relation7";
            textBox_Name7.AccessibleDescription = null;
            textBox_Name7.AccessibleName = null;
            resources.ApplyResources(textBox_Name7, "textBox_Name7");
            textBox_Name7.BackColor = System.Drawing.Color.White;
            textBox_Name7.BackgroundImage = null;
            textBox_Name7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Name7.Name = "textBox_Name7";
            textBox_PassporntNo6.AccessibleDescription = null;
            textBox_PassporntNo6.AccessibleName = null;
            resources.ApplyResources(textBox_PassporntNo6, "textBox_PassporntNo6");
            textBox_PassporntNo6.BackColor = System.Drawing.Color.White;
            textBox_PassporntNo6.BackgroundImage = null;
            textBox_PassporntNo6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_PassporntNo6.Name = "textBox_PassporntNo6";
            textBox_Relation6.AccessibleDescription = null;
            textBox_Relation6.AccessibleName = null;
            resources.ApplyResources(textBox_Relation6, "textBox_Relation6");
            textBox_Relation6.BackColor = System.Drawing.Color.White;
            textBox_Relation6.BackgroundImage = null;
            textBox_Relation6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Relation6.Name = "textBox_Relation6";
            textBox_Name6.AccessibleDescription = null;
            textBox_Name6.AccessibleName = null;
            resources.ApplyResources(textBox_Name6, "textBox_Name6");
            textBox_Name6.BackColor = System.Drawing.Color.White;
            textBox_Name6.BackgroundImage = null;
            textBox_Name6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Name6.Name = "textBox_Name6";
            textBox_PassporntNo5.AccessibleDescription = null;
            textBox_PassporntNo5.AccessibleName = null;
            resources.ApplyResources(textBox_PassporntNo5, "textBox_PassporntNo5");
            textBox_PassporntNo5.BackColor = System.Drawing.Color.White;
            textBox_PassporntNo5.BackgroundImage = null;
            textBox_PassporntNo5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_PassporntNo5.Name = "textBox_PassporntNo5";
            textBox_Relation5.AccessibleDescription = null;
            textBox_Relation5.AccessibleName = null;
            resources.ApplyResources(textBox_Relation5, "textBox_Relation5");
            textBox_Relation5.BackColor = System.Drawing.Color.White;
            textBox_Relation5.BackgroundImage = null;
            textBox_Relation5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Relation5.Name = "textBox_Relation5";
            textBox_Name5.AccessibleDescription = null;
            textBox_Name5.AccessibleName = null;
            resources.ApplyResources(textBox_Name5, "textBox_Name5");
            textBox_Name5.BackColor = System.Drawing.Color.White;
            textBox_Name5.BackgroundImage = null;
            textBox_Name5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Name5.Name = "textBox_Name5";
            textBox_PassporntNo4.AccessibleDescription = null;
            textBox_PassporntNo4.AccessibleName = null;
            resources.ApplyResources(textBox_PassporntNo4, "textBox_PassporntNo4");
            textBox_PassporntNo4.BackColor = System.Drawing.Color.White;
            textBox_PassporntNo4.BackgroundImage = null;
            textBox_PassporntNo4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_PassporntNo4.Name = "textBox_PassporntNo4";
            textBox_Relation4.AccessibleDescription = null;
            textBox_Relation4.AccessibleName = null;
            resources.ApplyResources(textBox_Relation4, "textBox_Relation4");
            textBox_Relation4.BackColor = System.Drawing.Color.White;
            textBox_Relation4.BackgroundImage = null;
            textBox_Relation4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Relation4.Name = "textBox_Relation4";
            textBox_Name4.AccessibleDescription = null;
            textBox_Name4.AccessibleName = null;
            resources.ApplyResources(textBox_Name4, "textBox_Name4");
            textBox_Name4.BackColor = System.Drawing.Color.White;
            textBox_Name4.BackgroundImage = null;
            textBox_Name4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Name4.Name = "textBox_Name4";
            textBox_PassporntNo3.AccessibleDescription = null;
            textBox_PassporntNo3.AccessibleName = null;
            resources.ApplyResources(textBox_PassporntNo3, "textBox_PassporntNo3");
            textBox_PassporntNo3.BackColor = System.Drawing.Color.White;
            textBox_PassporntNo3.BackgroundImage = null;
            textBox_PassporntNo3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_PassporntNo3.Name = "textBox_PassporntNo3";
            textBox_Relation3.AccessibleDescription = null;
            textBox_Relation3.AccessibleName = null;
            resources.ApplyResources(textBox_Relation3, "textBox_Relation3");
            textBox_Relation3.BackColor = System.Drawing.Color.White;
            textBox_Relation3.BackgroundImage = null;
            textBox_Relation3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Relation3.Name = "textBox_Relation3";
            textBox_Name3.AccessibleDescription = null;
            textBox_Name3.AccessibleName = null;
            resources.ApplyResources(textBox_Name3, "textBox_Name3");
            textBox_Name3.BackColor = System.Drawing.Color.White;
            textBox_Name3.BackgroundImage = null;
            textBox_Name3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Name3.Name = "textBox_Name3";
            textBox_PassporntNo2.AccessibleDescription = null;
            textBox_PassporntNo2.AccessibleName = null;
            resources.ApplyResources(textBox_PassporntNo2, "textBox_PassporntNo2");
            textBox_PassporntNo2.BackColor = System.Drawing.Color.White;
            textBox_PassporntNo2.BackgroundImage = null;
            textBox_PassporntNo2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_PassporntNo2.Name = "textBox_PassporntNo2";
            textBox_Relation2.AccessibleDescription = null;
            textBox_Relation2.AccessibleName = null;
            resources.ApplyResources(textBox_Relation2, "textBox_Relation2");
            textBox_Relation2.BackColor = System.Drawing.Color.White;
            textBox_Relation2.BackgroundImage = null;
            textBox_Relation2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Relation2.Name = "textBox_Relation2";
            textBox_Name2.AccessibleDescription = null;
            textBox_Name2.AccessibleName = null;
            resources.ApplyResources(textBox_Name2, "textBox_Name2");
            textBox_Name2.BackColor = System.Drawing.Color.White;
            textBox_Name2.BackgroundImage = null;
            textBox_Name2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Name2.Name = "textBox_Name2";
            textBox_PassporntNo1.AccessibleDescription = null;
            textBox_PassporntNo1.AccessibleName = null;
            resources.ApplyResources(textBox_PassporntNo1, "textBox_PassporntNo1");
            textBox_PassporntNo1.BackColor = System.Drawing.Color.White;
            textBox_PassporntNo1.BackgroundImage = null;
            textBox_PassporntNo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_PassporntNo1.Name = "textBox_PassporntNo1";
            textBox_Relation1.AccessibleDescription = null;
            textBox_Relation1.AccessibleName = null;
            resources.ApplyResources(textBox_Relation1, "textBox_Relation1");
            textBox_Relation1.BackColor = System.Drawing.Color.White;
            textBox_Relation1.BackgroundImage = null;
            textBox_Relation1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Relation1.Name = "textBox_Relation1";
            textBox_Name1.AccessibleDescription = null;
            textBox_Name1.AccessibleName = null;
            resources.ApplyResources(textBox_Name1, "textBox_Name1");
            textBox_Name1.BackColor = System.Drawing.Color.White;
            textBox_Name1.BackgroundImage = null;
            textBox_Name1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Name1.Name = "textBox_Name1";
            label44.AccessibleDescription = null;
            label44.AccessibleName = null;
            resources.ApplyResources(label44, "label44");
            label44.BackColor = System.Drawing.Color.SteelBlue;
            label44.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label44.ForeColor = System.Drawing.Color.White;
            label44.Name = "label44";
            dataGridView_Family.AccessibleDescription = null;
            dataGridView_Family.AccessibleName = null;
            dataGridView_Family.AllowUserToAddRows = false;
            resources.ApplyResources(dataGridView_Family, "dataGridView_Family");
            dataGridView_Family.BackgroundImage = null;
            dataGridView_Family.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_Family.Columns.AddRange(IND, name, BornDate, Link, PassNo, PassEnd, EnteryPort, EnteryNo);
            dataGridView_Family.Font = null;
            dataGridView_Family.Name = "dataGridView_Family";
            resources.ApplyResources(IND, "IND");
            IND.Name = "IND";
            resources.ApplyResources(name, "name");
            name.Name = "name";
            resources.ApplyResources(BornDate, "BornDate");
            BornDate.Name = "BornDate";
            resources.ApplyResources(Link, "Link");
            Link.Name = "Link";
            resources.ApplyResources(PassNo, "PassNo");
            PassNo.Name = "PassNo";
            resources.ApplyResources(PassEnd, "PassEnd");
            PassEnd.Name = "PassEnd";
            resources.ApplyResources(EnteryPort, "EnteryPort");
            EnteryPort.Name = "EnteryPort";
            resources.ApplyResources(EnteryNo, "EnteryNo");
            EnteryNo.Name = "EnteryNo";
            button_Exit.AccessibleDescription = null;
            button_Exit.AccessibleName = null;
            button_Exit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_Exit, "button_Exit");
            button_Exit.BackgroundImage = null;
            button_Exit.Checked = true;
            button_Exit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            button_Exit.CommandParameter = null;
            button_Exit.Name = "button_Exit";
            button_Exit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_Exit.Symbol = "\uf011";
            button_Exit.SymbolSize = 16f;
            button_Exit.TextColor = System.Drawing.Color.Black;
            button_Exit.Click += new System.EventHandler(button_Exit_Click);
            button_Print.AccessibleDescription = null;
            button_Print.AccessibleName = null;
            button_Print.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_Print, "button_Print");
            button_Print.BackgroundImage = null;
            button_Print.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            button_Print.CommandParameter = null;
            button_Print.Name = "button_Print";
            button_Print.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_Print.Symbol = "\uf0c5";
            button_Print.SymbolSize = 16f;
            button_Print.TextColor = System.Drawing.Color.White;
            button_Print.Click += new System.EventHandler(button_Print_Click);
            panel12.AccessibleDescription = null;
            panel12.AccessibleName = null;
            resources.ApplyResources(panel12, "panel12");
            panel12.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            panel12.BackgroundImage = null;
            panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel12.Controls.Add(label49);
            panel12.Controls.Add(label50);
            panel12.Font = null;
            panel12.Name = "panel12";
            label49.AccessibleDescription = null;
            label49.AccessibleName = null;
            resources.ApplyResources(label49, "label49");
            label49.BackColor = System.Drawing.Color.Transparent;
            label49.ForeColor = System.Drawing.Color.Maroon;
            label49.Name = "label49";
            label50.AccessibleDescription = null;
            label50.AccessibleName = null;
            resources.ApplyResources(label50, "label50");
            label50.BackColor = System.Drawing.Color.Transparent;
            label50.Name = "label50";
            textBox_Place.AccessibleDescription = null;
            textBox_Place.AccessibleName = null;
            resources.ApplyResources(textBox_Place, "textBox_Place");
            textBox_Place.BackColor = System.Drawing.Color.Yellow;
            textBox_Place.BackgroundImage = null;
            textBox_Place.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Place.Name = "textBox_Place";
            label39.AccessibleDescription = null;
            label39.AccessibleName = null;
            resources.ApplyResources(label39, "label39");
            label39.BackColor = System.Drawing.Color.Transparent;
            label39.Name = "label39";
            panel9.AccessibleDescription = null;
            panel9.AccessibleName = null;
            resources.ApplyResources(panel9, "panel9");
            panel9.BackColor = System.Drawing.Color.Transparent;
            panel9.BackgroundImage = null;
            panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel9.Controls.Add(label38);
            panel9.Controls.Add(textBox_NewSponsorNo);
            panel9.Controls.Add(label35);
            panel9.Controls.Add(textBox_TelTransfer);
            panel9.Controls.Add(label36);
            panel9.Controls.Add(textBox_AddressTransfer);
            panel9.Controls.Add(label37);
            panel9.Controls.Add(radioButton_PersonSideTransfer);
            panel9.Controls.Add(radioButton_CompanySideTransfer);
            panel9.Controls.Add(radioButton_FoundationSideTransfer);
            panel9.Controls.Add(radioButton_GovSideTransfer);
            panel9.Controls.Add(comboBox_SponsorNameTransfer);
            panel9.Font = null;
            panel9.Name = "panel9";
            label38.AccessibleDescription = null;
            label38.AccessibleName = null;
            resources.ApplyResources(label38, "label38");
            label38.BackColor = System.Drawing.Color.Transparent;
            label38.Name = "label38";
            textBox_NewSponsorNo.AccessibleDescription = null;
            textBox_NewSponsorNo.AccessibleName = null;
            resources.ApplyResources(textBox_NewSponsorNo, "textBox_NewSponsorNo");
            textBox_NewSponsorNo.BackColor = System.Drawing.Color.White;
            textBox_NewSponsorNo.BackgroundImage = null;
            textBox_NewSponsorNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_NewSponsorNo.Font = null;
            textBox_NewSponsorNo.Name = "textBox_NewSponsorNo";
            textBox_NewSponsorNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox_ID_No_KeyPress);
            label35.AccessibleDescription = null;
            label35.AccessibleName = null;
            resources.ApplyResources(label35, "label35");
            label35.BackColor = System.Drawing.Color.Transparent;
            label35.Name = "label35";
            textBox_TelTransfer.AccessibleDescription = null;
            textBox_TelTransfer.AccessibleName = null;
            resources.ApplyResources(textBox_TelTransfer, "textBox_TelTransfer");
            textBox_TelTransfer.BackColor = System.Drawing.Color.White;
            textBox_TelTransfer.BackgroundImage = null;
            textBox_TelTransfer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_TelTransfer.Font = null;
            textBox_TelTransfer.Name = "textBox_TelTransfer";
            textBox_TelTransfer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox_ID_No_KeyPress);
            label36.AccessibleDescription = null;
            label36.AccessibleName = null;
            resources.ApplyResources(label36, "label36");
            label36.BackColor = System.Drawing.Color.Transparent;
            label36.Name = "label36";
            textBox_AddressTransfer.AccessibleDescription = null;
            textBox_AddressTransfer.AccessibleName = null;
            resources.ApplyResources(textBox_AddressTransfer, "textBox_AddressTransfer");
            textBox_AddressTransfer.BackColor = System.Drawing.Color.White;
            textBox_AddressTransfer.BackgroundImage = null;
            textBox_AddressTransfer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_AddressTransfer.Font = null;
            textBox_AddressTransfer.Name = "textBox_AddressTransfer";
            label37.AccessibleDescription = null;
            label37.AccessibleName = null;
            resources.ApplyResources(label37, "label37");
            label37.BackColor = System.Drawing.Color.Transparent;
            label37.Name = "label37";
            radioButton_PersonSideTransfer.AccessibleDescription = null;
            radioButton_PersonSideTransfer.AccessibleName = null;
            resources.ApplyResources(radioButton_PersonSideTransfer, "radioButton_PersonSideTransfer");
            radioButton_PersonSideTransfer.BackColor = System.Drawing.Color.Transparent;
            radioButton_PersonSideTransfer.BackgroundImage = null;
            radioButton_PersonSideTransfer.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            radioButton_PersonSideTransfer.Name = "radioButton_PersonSideTransfer";
            radioButton_PersonSideTransfer.UseVisualStyleBackColor = false;
            radioButton_CompanySideTransfer.AccessibleDescription = null;
            radioButton_CompanySideTransfer.AccessibleName = null;
            resources.ApplyResources(radioButton_CompanySideTransfer, "radioButton_CompanySideTransfer");
            radioButton_CompanySideTransfer.BackColor = System.Drawing.Color.Transparent;
            radioButton_CompanySideTransfer.BackgroundImage = null;
            radioButton_CompanySideTransfer.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            radioButton_CompanySideTransfer.Name = "radioButton_CompanySideTransfer";
            radioButton_CompanySideTransfer.UseVisualStyleBackColor = false;
            radioButton_FoundationSideTransfer.AccessibleDescription = null;
            radioButton_FoundationSideTransfer.AccessibleName = null;
            resources.ApplyResources(radioButton_FoundationSideTransfer, "radioButton_FoundationSideTransfer");
            radioButton_FoundationSideTransfer.BackColor = System.Drawing.Color.Transparent;
            radioButton_FoundationSideTransfer.BackgroundImage = null;
            radioButton_FoundationSideTransfer.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            radioButton_FoundationSideTransfer.Name = "radioButton_FoundationSideTransfer";
            radioButton_FoundationSideTransfer.UseVisualStyleBackColor = false;
            radioButton_GovSideTransfer.AccessibleDescription = null;
            radioButton_GovSideTransfer.AccessibleName = null;
            resources.ApplyResources(radioButton_GovSideTransfer, "radioButton_GovSideTransfer");
            radioButton_GovSideTransfer.BackColor = System.Drawing.Color.Transparent;
            radioButton_GovSideTransfer.BackgroundImage = null;
            radioButton_GovSideTransfer.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            radioButton_GovSideTransfer.Name = "radioButton_GovSideTransfer";
            radioButton_GovSideTransfer.UseVisualStyleBackColor = false;
            comboBox_SponsorNameTransfer.AccessibleDescription = null;
            comboBox_SponsorNameTransfer.AccessibleName = null;
            resources.ApplyResources(comboBox_SponsorNameTransfer, "comboBox_SponsorNameTransfer");
            comboBox_SponsorNameTransfer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            comboBox_SponsorNameTransfer.BackColor = System.Drawing.Color.White;
            comboBox_SponsorNameTransfer.BackgroundImage = null;
            comboBox_SponsorNameTransfer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_SponsorNameTransfer.Font = null;
            comboBox_SponsorNameTransfer.FormattingEnabled = true;
            comboBox_SponsorNameTransfer.Name = "comboBox_SponsorNameTransfer";
            comboBox_SponsorNameTransfer.SelectedValueChanged += new System.EventHandler(comboBox_SponsorNameTransfer_SelectedValueChanged);
            label3.AccessibleDescription = null;
            label3.AccessibleName = null;
            resources.ApplyResources(label3, "label3");
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Font = null;
            label3.Name = "label3";
            checkBox_CreatePassport.AccessibleDescription = null;
            checkBox_CreatePassport.AccessibleName = null;
            resources.ApplyResources(checkBox_CreatePassport, "checkBox_CreatePassport");
            checkBox_CreatePassport.BackColor = System.Drawing.Color.Transparent;
            checkBox_CreatePassport.BackgroundImage = null;
            checkBox_CreatePassport.Name = "checkBox_CreatePassport";
            checkBox_CreatePassport.UseVisualStyleBackColor = false;
            checkBox_CreateIdentity.AccessibleDescription = null;
            checkBox_CreateIdentity.AccessibleName = null;
            resources.ApplyResources(checkBox_CreateIdentity, "checkBox_CreateIdentity");
            checkBox_CreateIdentity.BackColor = System.Drawing.Color.Transparent;
            checkBox_CreateIdentity.BackgroundImage = null;
            checkBox_CreateIdentity.Name = "checkBox_CreateIdentity";
            checkBox_CreateIdentity.UseVisualStyleBackColor = false;
            panel8.AccessibleDescription = null;
            panel8.AccessibleName = null;
            resources.ApplyResources(panel8, "panel8");
            panel8.BackColor = System.Drawing.Color.Transparent;
            panel8.BackgroundImage = null;
            panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel8.Controls.Add(textBox_ID);
            panel8.Controls.Add(label34);
            panel8.Controls.Add(textBox_Tel);
            panel8.Controls.Add(label33);
            panel8.Controls.Add(textBox_Address);
            panel8.Controls.Add(label32);
            panel8.Controls.Add(radioButton_PersonSide);
            panel8.Controls.Add(radioButton_CompanySide);
            panel8.Controls.Add(radioButton_FoundationSide);
            panel8.Controls.Add(radioButton_GovSide);
            panel8.Controls.Add(comboBox_SponsorName);
            panel8.Font = null;
            panel8.Name = "panel8";
            textBox_ID.AccessibleDescription = null;
            textBox_ID.AccessibleName = null;
            resources.ApplyResources(textBox_ID, "textBox_ID");
            textBox_ID.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
            textBox_ID.BackgroundImage = null;
            textBox_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_ID.Name = "textBox_ID";
            textBox_ID.TextChanged += new System.EventHandler(textBox_ID_TextChanged);
            label34.AccessibleDescription = null;
            label34.AccessibleName = null;
            resources.ApplyResources(label34, "label34");
            label34.BackColor = System.Drawing.Color.Transparent;
            label34.Name = "label34";
            textBox_Tel.AccessibleDescription = null;
            textBox_Tel.AccessibleName = null;
            resources.ApplyResources(textBox_Tel, "textBox_Tel");
            textBox_Tel.BackColor = System.Drawing.Color.White;
            textBox_Tel.BackgroundImage = null;
            textBox_Tel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Tel.Font = null;
            textBox_Tel.Name = "textBox_Tel";
            textBox_Tel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox_ID_No_KeyPress);
            label33.AccessibleDescription = null;
            label33.AccessibleName = null;
            resources.ApplyResources(label33, "label33");
            label33.BackColor = System.Drawing.Color.Transparent;
            label33.Name = "label33";
            textBox_Address.AccessibleDescription = null;
            textBox_Address.AccessibleName = null;
            resources.ApplyResources(textBox_Address, "textBox_Address");
            textBox_Address.BackColor = System.Drawing.Color.White;
            textBox_Address.BackgroundImage = null;
            textBox_Address.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Address.Font = null;
            textBox_Address.Name = "textBox_Address";
            label32.AccessibleDescription = null;
            label32.AccessibleName = null;
            resources.ApplyResources(label32, "label32");
            label32.BackColor = System.Drawing.Color.Transparent;
            label32.Name = "label32";
            radioButton_PersonSide.AccessibleDescription = null;
            radioButton_PersonSide.AccessibleName = null;
            resources.ApplyResources(radioButton_PersonSide, "radioButton_PersonSide");
            radioButton_PersonSide.BackColor = System.Drawing.Color.Transparent;
            radioButton_PersonSide.BackgroundImage = null;
            radioButton_PersonSide.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            radioButton_PersonSide.Name = "radioButton_PersonSide";
            radioButton_PersonSide.UseVisualStyleBackColor = false;
            radioButton_CompanySide.AccessibleDescription = null;
            radioButton_CompanySide.AccessibleName = null;
            resources.ApplyResources(radioButton_CompanySide, "radioButton_CompanySide");
            radioButton_CompanySide.BackColor = System.Drawing.Color.Transparent;
            radioButton_CompanySide.BackgroundImage = null;
            radioButton_CompanySide.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            radioButton_CompanySide.Name = "radioButton_CompanySide";
            radioButton_CompanySide.UseVisualStyleBackColor = false;
            radioButton_FoundationSide.AccessibleDescription = null;
            radioButton_FoundationSide.AccessibleName = null;
            resources.ApplyResources(radioButton_FoundationSide, "radioButton_FoundationSide");
            radioButton_FoundationSide.BackColor = System.Drawing.Color.Transparent;
            radioButton_FoundationSide.BackgroundImage = null;
            radioButton_FoundationSide.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            radioButton_FoundationSide.Name = "radioButton_FoundationSide";
            radioButton_FoundationSide.UseVisualStyleBackColor = false;
            radioButton_GovSide.AccessibleDescription = null;
            radioButton_GovSide.AccessibleName = null;
            resources.ApplyResources(radioButton_GovSide, "radioButton_GovSide");
            radioButton_GovSide.BackColor = System.Drawing.Color.Transparent;
            radioButton_GovSide.BackgroundImage = null;
            radioButton_GovSide.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            radioButton_GovSide.Name = "radioButton_GovSide";
            radioButton_GovSide.UseVisualStyleBackColor = false;
            comboBox_SponsorName.AccessibleDescription = null;
            comboBox_SponsorName.AccessibleName = null;
            resources.ApplyResources(comboBox_SponsorName, "comboBox_SponsorName");
            comboBox_SponsorName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            comboBox_SponsorName.BackColor = System.Drawing.Color.White;
            comboBox_SponsorName.BackgroundImage = null;
            comboBox_SponsorName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_SponsorName.Font = null;
            comboBox_SponsorName.FormattingEnabled = true;
            comboBox_SponsorName.Name = "comboBox_SponsorName";
            comboBox_SponsorName.SelectedValueChanged += new System.EventHandler(comboBox_SponsorName_SelectedValueChanged);
            panel7.AccessibleDescription = null;
            panel7.AccessibleName = null;
            resources.ApplyResources(panel7, "panel7");
            panel7.BackColor = System.Drawing.Color.Transparent;
            panel7.BackgroundImage = null;
            panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel7.Controls.Add(dateTimeInput_BirthDate);
            panel7.Controls.Add(dateTimeInput_PassportCreateDate);
            panel7.Controls.Add(dateTimeInput_PassportEndDate);
            panel7.Controls.Add(label31);
            panel7.Controls.Add(textBox_PassportCreatePlace);
            panel7.Controls.Add(label30);
            panel7.Controls.Add(label29);
            panel7.Controls.Add(label28);
            panel7.Controls.Add(textBox_PassportNo);
            panel7.Controls.Add(label27);
            panel7.Controls.Add(label26);
            panel7.Controls.Add(textBox_Religon);
            panel7.Controls.Add(label25);
            panel7.Controls.Add(textBox_Job);
            panel7.Controls.Add(label24);
            panel7.Controls.Add(textBox_Nationalty);
            panel7.Controls.Add(label19);
            panel7.Controls.Add(textBox_FamilyE);
            panel7.Controls.Add(label20);
            panel7.Controls.Add(label21);
            panel7.Controls.Add(textBox_FatherE);
            panel7.Controls.Add(textBox_GrandE);
            panel7.Controls.Add(label23);
            panel7.Controls.Add(textBox_FirstNameE);
            panel7.Controls.Add(label18);
            panel7.Controls.Add(textBox_FamilyA);
            panel7.Controls.Add(label17);
            panel7.Controls.Add(label16);
            panel7.Controls.Add(textBox_FatherA);
            panel7.Controls.Add(textBox_GrandA);
            panel7.Controls.Add(label15);
            panel7.Controls.Add(textBox_FristNameA);
            panel7.Controls.Add(comboBox_EmpNo);
            panel7.Controls.Add(label14);
            panel7.Font = null;
            panel7.Name = "panel7";
            dateTimeInput_BirthDate.AccessibleDescription = null;
            dateTimeInput_BirthDate.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_BirthDate, "dateTimeInput_BirthDate");
            dateTimeInput_BirthDate.BackColor = System.Drawing.Color.White;
            dateTimeInput_BirthDate.BackgroundImage = null;
            dateTimeInput_BirthDate.Font = null;
            dateTimeInput_BirthDate.Name = "dateTimeInput_BirthDate";
            dateTimeInput_BirthDate.Leave += new System.EventHandler(dateTimeInput_BirthDate_Leave);
            dateTimeInput_BirthDate.Click += new System.EventHandler(dateTimeInput_BirthDate_Click);
            dateTimeInput_PassportCreateDate.AccessibleDescription = null;
            dateTimeInput_PassportCreateDate.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_PassportCreateDate, "dateTimeInput_PassportCreateDate");
            dateTimeInput_PassportCreateDate.BackgroundImage = null;
            dateTimeInput_PassportCreateDate.Font = null;
            dateTimeInput_PassportCreateDate.Name = "dateTimeInput_PassportCreateDate";
            dateTimeInput_PassportCreateDate.Leave += new System.EventHandler(dateTimeInput_PassportCreateDate_Leave);
            dateTimeInput_PassportCreateDate.Click += new System.EventHandler(dateTimeInput_PassportCreateDate_Click);
            dateTimeInput_PassportEndDate.AccessibleDescription = null;
            dateTimeInput_PassportEndDate.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_PassportEndDate, "dateTimeInput_PassportEndDate");
            dateTimeInput_PassportEndDate.BackColor = System.Drawing.Color.White;
            dateTimeInput_PassportEndDate.BackgroundImage = null;
            dateTimeInput_PassportEndDate.Font = null;
            dateTimeInput_PassportEndDate.Name = "dateTimeInput_PassportEndDate";
            dateTimeInput_PassportEndDate.Leave += new System.EventHandler(dateTimeInput_PassportEndDate_Leave);
            dateTimeInput_PassportEndDate.Click += new System.EventHandler(dateTimeInput_PassportEndDate_Click);
            label31.AccessibleDescription = null;
            label31.AccessibleName = null;
            resources.ApplyResources(label31, "label31");
            label31.BackColor = System.Drawing.Color.Transparent;
            label31.Name = "label31";
            textBox_PassportCreatePlace.AccessibleDescription = null;
            textBox_PassportCreatePlace.AccessibleName = null;
            resources.ApplyResources(textBox_PassportCreatePlace, "textBox_PassportCreatePlace");
            textBox_PassportCreatePlace.BackColor = System.Drawing.Color.White;
            textBox_PassportCreatePlace.BackgroundImage = null;
            textBox_PassportCreatePlace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_PassportCreatePlace.Font = null;
            textBox_PassportCreatePlace.Name = "textBox_PassportCreatePlace";
            label30.AccessibleDescription = null;
            label30.AccessibleName = null;
            resources.ApplyResources(label30, "label30");
            label30.BackColor = System.Drawing.Color.Transparent;
            label30.Name = "label30";
            label29.AccessibleDescription = null;
            label29.AccessibleName = null;
            resources.ApplyResources(label29, "label29");
            label29.BackColor = System.Drawing.Color.Transparent;
            label29.Name = "label29";
            label28.AccessibleDescription = null;
            label28.AccessibleName = null;
            resources.ApplyResources(label28, "label28");
            label28.BackColor = System.Drawing.Color.Transparent;
            label28.Name = "label28";
            textBox_PassportNo.AccessibleDescription = null;
            textBox_PassportNo.AccessibleName = null;
            resources.ApplyResources(textBox_PassportNo, "textBox_PassportNo");
            textBox_PassportNo.BackColor = System.Drawing.Color.White;
            textBox_PassportNo.BackgroundImage = null;
            textBox_PassportNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_PassportNo.Font = null;
            textBox_PassportNo.Name = "textBox_PassportNo";
            textBox_PassportNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox_ID_No_KeyPress);
            label27.AccessibleDescription = null;
            label27.AccessibleName = null;
            resources.ApplyResources(label27, "label27");
            label27.BackColor = System.Drawing.Color.Transparent;
            label27.Name = "label27";
            label26.AccessibleDescription = null;
            label26.AccessibleName = null;
            resources.ApplyResources(label26, "label26");
            label26.BackColor = System.Drawing.Color.Transparent;
            label26.Name = "label26";
            textBox_Religon.AccessibleDescription = null;
            textBox_Religon.AccessibleName = null;
            resources.ApplyResources(textBox_Religon, "textBox_Religon");
            textBox_Religon.BackColor = System.Drawing.Color.White;
            textBox_Religon.BackgroundImage = null;
            textBox_Religon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Religon.Font = null;
            textBox_Religon.Name = "textBox_Religon";
            label25.AccessibleDescription = null;
            label25.AccessibleName = null;
            resources.ApplyResources(label25, "label25");
            label25.BackColor = System.Drawing.Color.Transparent;
            label25.Name = "label25";
            textBox_Job.AccessibleDescription = null;
            textBox_Job.AccessibleName = null;
            resources.ApplyResources(textBox_Job, "textBox_Job");
            textBox_Job.BackColor = System.Drawing.Color.White;
            textBox_Job.BackgroundImage = null;
            textBox_Job.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Job.Font = null;
            textBox_Job.Name = "textBox_Job";
            label24.AccessibleDescription = null;
            label24.AccessibleName = null;
            resources.ApplyResources(label24, "label24");
            label24.BackColor = System.Drawing.Color.Transparent;
            label24.Name = "label24";
            textBox_Nationalty.AccessibleDescription = null;
            textBox_Nationalty.AccessibleName = null;
            resources.ApplyResources(textBox_Nationalty, "textBox_Nationalty");
            textBox_Nationalty.BackColor = System.Drawing.Color.White;
            textBox_Nationalty.BackgroundImage = null;
            textBox_Nationalty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Nationalty.Font = null;
            textBox_Nationalty.Name = "textBox_Nationalty";
            label19.AccessibleDescription = null;
            label19.AccessibleName = null;
            resources.ApplyResources(label19, "label19");
            label19.BackColor = System.Drawing.Color.Transparent;
            label19.Name = "label19";
            textBox_FamilyE.AccessibleDescription = null;
            textBox_FamilyE.AccessibleName = null;
            resources.ApplyResources(textBox_FamilyE, "textBox_FamilyE");
            textBox_FamilyE.BackColor = System.Drawing.Color.White;
            textBox_FamilyE.BackgroundImage = null;
            textBox_FamilyE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_FamilyE.Font = null;
            textBox_FamilyE.Name = "textBox_FamilyE";
            label20.AccessibleDescription = null;
            label20.AccessibleName = null;
            resources.ApplyResources(label20, "label20");
            label20.BackColor = System.Drawing.Color.Transparent;
            label20.Name = "label20";
            label21.AccessibleDescription = null;
            label21.AccessibleName = null;
            resources.ApplyResources(label21, "label21");
            label21.BackColor = System.Drawing.Color.Transparent;
            label21.Name = "label21";
            textBox_FatherE.AccessibleDescription = null;
            textBox_FatherE.AccessibleName = null;
            resources.ApplyResources(textBox_FatherE, "textBox_FatherE");
            textBox_FatherE.BackColor = System.Drawing.Color.White;
            textBox_FatherE.BackgroundImage = null;
            textBox_FatherE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_FatherE.Font = null;
            textBox_FatherE.Name = "textBox_FatherE";
            textBox_GrandE.AccessibleDescription = null;
            textBox_GrandE.AccessibleName = null;
            resources.ApplyResources(textBox_GrandE, "textBox_GrandE");
            textBox_GrandE.BackColor = System.Drawing.Color.White;
            textBox_GrandE.BackgroundImage = null;
            textBox_GrandE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_GrandE.Font = null;
            textBox_GrandE.Name = "textBox_GrandE";
            label23.AccessibleDescription = null;
            label23.AccessibleName = null;
            resources.ApplyResources(label23, "label23");
            label23.BackColor = System.Drawing.Color.Transparent;
            label23.Name = "label23";
            textBox_FirstNameE.AccessibleDescription = null;
            textBox_FirstNameE.AccessibleName = null;
            resources.ApplyResources(textBox_FirstNameE, "textBox_FirstNameE");
            textBox_FirstNameE.BackColor = System.Drawing.Color.White;
            textBox_FirstNameE.BackgroundImage = null;
            textBox_FirstNameE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_FirstNameE.Font = null;
            textBox_FirstNameE.Name = "textBox_FirstNameE";
            label18.AccessibleDescription = null;
            label18.AccessibleName = null;
            resources.ApplyResources(label18, "label18");
            label18.BackColor = System.Drawing.Color.Transparent;
            label18.Name = "label18";
            textBox_FamilyA.AccessibleDescription = null;
            textBox_FamilyA.AccessibleName = null;
            resources.ApplyResources(textBox_FamilyA, "textBox_FamilyA");
            textBox_FamilyA.BackColor = System.Drawing.Color.White;
            textBox_FamilyA.BackgroundImage = null;
            textBox_FamilyA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_FamilyA.Font = null;
            textBox_FamilyA.Name = "textBox_FamilyA";
            label17.AccessibleDescription = null;
            label17.AccessibleName = null;
            resources.ApplyResources(label17, "label17");
            label17.BackColor = System.Drawing.Color.Transparent;
            label17.Name = "label17";
            label16.AccessibleDescription = null;
            label16.AccessibleName = null;
            resources.ApplyResources(label16, "label16");
            label16.BackColor = System.Drawing.Color.Transparent;
            label16.Name = "label16";
            textBox_FatherA.AccessibleDescription = null;
            textBox_FatherA.AccessibleName = null;
            resources.ApplyResources(textBox_FatherA, "textBox_FatherA");
            textBox_FatherA.BackColor = System.Drawing.Color.White;
            textBox_FatherA.BackgroundImage = null;
            textBox_FatherA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_FatherA.Font = null;
            textBox_FatherA.Name = "textBox_FatherA";
            textBox_GrandA.AccessibleDescription = null;
            textBox_GrandA.AccessibleName = null;
            resources.ApplyResources(textBox_GrandA, "textBox_GrandA");
            textBox_GrandA.BackColor = System.Drawing.Color.White;
            textBox_GrandA.BackgroundImage = null;
            textBox_GrandA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_GrandA.Font = null;
            textBox_GrandA.Name = "textBox_GrandA";
            label15.AccessibleDescription = null;
            label15.AccessibleName = null;
            resources.ApplyResources(label15, "label15");
            label15.BackColor = System.Drawing.Color.Transparent;
            label15.Name = "label15";
            textBox_FristNameA.AccessibleDescription = null;
            textBox_FristNameA.AccessibleName = null;
            resources.ApplyResources(textBox_FristNameA, "textBox_FristNameA");
            textBox_FristNameA.BackColor = System.Drawing.Color.White;
            textBox_FristNameA.BackgroundImage = null;
            textBox_FristNameA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_FristNameA.Font = null;
            textBox_FristNameA.Name = "textBox_FristNameA";
            comboBox_EmpNo.AccessibleDescription = null;
            comboBox_EmpNo.AccessibleName = null;
            resources.ApplyResources(comboBox_EmpNo, "comboBox_EmpNo");
            comboBox_EmpNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            comboBox_EmpNo.BackColor = System.Drawing.Color.White;
            comboBox_EmpNo.BackgroundImage = null;
            comboBox_EmpNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_EmpNo.Font = null;
            comboBox_EmpNo.FormattingEnabled = true;
            comboBox_EmpNo.Name = "comboBox_EmpNo";
            comboBox_EmpNo.SelectedValueChanged += new System.EventHandler(comboBox_EmpNo_SelectedValueChanged);
            label14.AccessibleDescription = null;
            label14.AccessibleName = null;
            resources.ApplyResources(label14, "label14");
            label14.BackColor = System.Drawing.Color.Transparent;
            label14.Name = "label14";
            panel6.AccessibleDescription = null;
            panel6.AccessibleName = null;
            resources.ApplyResources(panel6, "panel6");
            panel6.BackColor = System.Drawing.Color.Transparent;
            panel6.BackgroundImage = null;
            panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel6.Controls.Add(label13);
            panel6.Controls.Add(textBox_PortEntry);
            panel6.Controls.Add(label11);
            panel6.Controls.Add(label10);
            panel6.Controls.Add(textBox_NoBorderEntery);
            panel6.Controls.Add(label12);
            panel6.Controls.Add(dateTimeInput_EntryDate);
            panel6.Font = null;
            panel6.Name = "panel6";
            label13.AccessibleDescription = null;
            label13.AccessibleName = null;
            resources.ApplyResources(label13, "label13");
            label13.BackColor = System.Drawing.Color.Transparent;
            label13.Name = "label13";
            textBox_PortEntry.AccessibleDescription = null;
            textBox_PortEntry.AccessibleName = null;
            resources.ApplyResources(textBox_PortEntry, "textBox_PortEntry");
            textBox_PortEntry.BackColor = System.Drawing.Color.White;
            textBox_PortEntry.BackgroundImage = null;
            textBox_PortEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_PortEntry.Font = null;
            textBox_PortEntry.Name = "textBox_PortEntry";
            label11.AccessibleDescription = null;
            label11.AccessibleName = null;
            resources.ApplyResources(label11, "label11");
            label11.BackColor = System.Drawing.Color.Transparent;
            label11.Name = "label11";
            label10.AccessibleDescription = null;
            label10.AccessibleName = null;
            resources.ApplyResources(label10, "label10");
            label10.BackColor = System.Drawing.Color.Transparent;
            label10.Name = "label10";
            textBox_NoBorderEntery.AccessibleDescription = null;
            textBox_NoBorderEntery.AccessibleName = null;
            resources.ApplyResources(textBox_NoBorderEntery, "textBox_NoBorderEntery");
            textBox_NoBorderEntery.BackColor = System.Drawing.Color.White;
            textBox_NoBorderEntery.BackgroundImage = null;
            textBox_NoBorderEntery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_NoBorderEntery.Font = null;
            textBox_NoBorderEntery.Name = "textBox_NoBorderEntery";
            textBox_NoBorderEntery.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox_ID_No_KeyPress);
            label12.AccessibleDescription = null;
            label12.AccessibleName = null;
            resources.ApplyResources(label12, "label12");
            label12.BackColor = System.Drawing.Color.Transparent;
            label12.Name = "label12";
            dateTimeInput_EntryDate.AccessibleDescription = null;
            dateTimeInput_EntryDate.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_EntryDate, "dateTimeInput_EntryDate");
            dateTimeInput_EntryDate.BackgroundImage = null;
            dateTimeInput_EntryDate.Font = null;
            dateTimeInput_EntryDate.Name = "dateTimeInput_EntryDate";
            dateTimeInput_EntryDate.Leave += new System.EventHandler(dateTimeInput_EntryDate_Leave);
            dateTimeInput_EntryDate.Click += new System.EventHandler(dateTimeInput_EntryDate_Click);
            panel5.AccessibleDescription = null;
            panel5.AccessibleName = null;
            resources.ApplyResources(panel5, "panel5");
            panel5.BackColor = System.Drawing.Color.Transparent;
            panel5.BackgroundImage = null;
            panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel5.Controls.Add(dateTimeInput_ID_DateEnd);
            panel5.Controls.Add(label9);
            panel5.Controls.Add(textBox_SponsorID);
            panel5.Controls.Add(label92);
            panel5.Controls.Add(label97);
            panel5.Controls.Add(textBox_ID_No);
            panel5.Name = "panel5";
            dateTimeInput_ID_DateEnd.AccessibleDescription = null;
            dateTimeInput_ID_DateEnd.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_ID_DateEnd, "dateTimeInput_ID_DateEnd");
            dateTimeInput_ID_DateEnd.BackColor = System.Drawing.Color.White;
            dateTimeInput_ID_DateEnd.BackgroundImage = null;
            dateTimeInput_ID_DateEnd.Font = null;
            dateTimeInput_ID_DateEnd.Name = "dateTimeInput_ID_DateEnd";
            dateTimeInput_ID_DateEnd.Leave += new System.EventHandler(dateTimeInput_ID_DateEnd_Leave);
            dateTimeInput_ID_DateEnd.Click += new System.EventHandler(dateTimeInput_ID_DateEnd_Click);
            label9.AccessibleDescription = null;
            label9.AccessibleName = null;
            resources.ApplyResources(label9, "label9");
            label9.BackColor = System.Drawing.Color.Transparent;
            label9.Name = "label9";
            textBox_SponsorID.AccessibleDescription = null;
            textBox_SponsorID.AccessibleName = null;
            resources.ApplyResources(textBox_SponsorID, "textBox_SponsorID");
            textBox_SponsorID.BackColor = System.Drawing.Color.White;
            textBox_SponsorID.BackgroundImage = null;
            textBox_SponsorID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_SponsorID.Font = null;
            textBox_SponsorID.Name = "textBox_SponsorID";
            textBox_SponsorID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox_ID_No_KeyPress);
            label92.AccessibleDescription = null;
            label92.AccessibleName = null;
            resources.ApplyResources(label92, "label92");
            label92.BackColor = System.Drawing.Color.Transparent;
            label92.Name = "label92";
            label97.AccessibleDescription = null;
            label97.AccessibleName = null;
            resources.ApplyResources(label97, "label97");
            label97.BackColor = System.Drawing.Color.Transparent;
            label97.Name = "label97";
            textBox_ID_No.AccessibleDescription = null;
            textBox_ID_No.AccessibleName = null;
            resources.ApplyResources(textBox_ID_No, "textBox_ID_No");
            textBox_ID_No.BackColor = System.Drawing.Color.White;
            textBox_ID_No.BackgroundImage = null;
            textBox_ID_No.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_ID_No.Font = null;
            textBox_ID_No.Name = "textBox_ID_No";
            textBox_ID_No.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox_ID_No_KeyPress);
            label7.AccessibleDescription = null;
            label7.AccessibleName = null;
            resources.ApplyResources(label7, "label7");
            label7.BackColor = System.Drawing.Color.Transparent;
            label7.Font = null;
            label7.Name = "label7";
            checkBox_AddExtension.AccessibleDescription = null;
            checkBox_AddExtension.AccessibleName = null;
            resources.ApplyResources(checkBox_AddExtension, "checkBox_AddExtension");
            checkBox_AddExtension.BackColor = System.Drawing.Color.Transparent;
            checkBox_AddExtension.BackgroundImage = null;
            checkBox_AddExtension.Name = "checkBox_AddExtension";
            checkBox_AddExtension.UseVisualStyleBackColor = false;
            label6.AccessibleDescription = null;
            label6.AccessibleName = null;
            resources.ApplyResources(label6, "label6");
            label6.BackColor = System.Drawing.Color.Transparent;
            label6.Font = null;
            label6.Name = "label6";
            checkBox_SponsorTransfer.AccessibleDescription = null;
            checkBox_SponsorTransfer.AccessibleName = null;
            resources.ApplyResources(checkBox_SponsorTransfer, "checkBox_SponsorTransfer");
            checkBox_SponsorTransfer.BackColor = System.Drawing.Color.Transparent;
            checkBox_SponsorTransfer.BackgroundImage = null;
            checkBox_SponsorTransfer.Name = "checkBox_SponsorTransfer";
            checkBox_SponsorTransfer.UseVisualStyleBackColor = false;
            panel3.AccessibleDescription = null;
            panel3.AccessibleName = null;
            resources.ApplyResources(panel3, "panel3");
            panel3.BackColor = System.Drawing.Color.Transparent;
            panel3.BackgroundImage = null;
            panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel3.Controls.Add(textBox_Others);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(comboBox_GuarTrans);
            panel3.Font = null;
            panel3.Name = "panel3";
            textBox_Others.AccessibleDescription = null;
            textBox_Others.AccessibleName = null;
            resources.ApplyResources(textBox_Others, "textBox_Others");
            textBox_Others.BackgroundImage = null;
            textBox_Others.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_Others.Font = null;
            textBox_Others.Name = "textBox_Others";
            label8.AccessibleDescription = null;
            label8.AccessibleName = null;
            resources.ApplyResources(label8, "label8");
            label8.BackColor = System.Drawing.Color.Transparent;
            label8.Name = "label8";
            comboBox_GuarTrans.AccessibleDescription = null;
            comboBox_GuarTrans.AccessibleName = null;
            resources.ApplyResources(comboBox_GuarTrans, "comboBox_GuarTrans");
            comboBox_GuarTrans.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            comboBox_GuarTrans.BackgroundImage = null;
            comboBox_GuarTrans.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_GuarTrans.Font = null;
            comboBox_GuarTrans.FormattingEnabled = true;
            comboBox_GuarTrans.Items.AddRange(new object[4]
            {
                resources.GetString("comboBox_GuarTrans.Items"),
                resources.GetString("comboBox_GuarTrans.Items1"),
                resources.GetString("comboBox_GuarTrans.Items2"),
                resources.GetString("comboBox_GuarTrans.Items3")
            });
            comboBox_GuarTrans.Name = "comboBox_GuarTrans";
            panel2.AccessibleDescription = null;
            panel2.AccessibleName = null;
            resources.ApplyResources(panel2, "panel2");
            panel2.BackColor = System.Drawing.Color.Transparent;
            panel2.BackgroundImage = null;
            panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel2.Controls.Add(label4);
            panel2.Controls.Add(comboBox_PassportDay);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(comboBox_Passport);
            panel2.Font = null;
            panel2.Name = "panel2";
            label4.AccessibleDescription = null;
            label4.AccessibleName = null;
            resources.ApplyResources(label4, "label4");
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.Name = "label4";
            comboBox_PassportDay.AccessibleDescription = null;
            comboBox_PassportDay.AccessibleName = null;
            resources.ApplyResources(comboBox_PassportDay, "comboBox_PassportDay");
            comboBox_PassportDay.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            comboBox_PassportDay.BackgroundImage = null;
            comboBox_PassportDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_PassportDay.Font = null;
            comboBox_PassportDay.FormattingEnabled = true;
            comboBox_PassportDay.Items.AddRange(new object[4]
            {
                resources.GetString("comboBox_PassportDay.Items"),
                resources.GetString("comboBox_PassportDay.Items1"),
                resources.GetString("comboBox_PassportDay.Items2"),
                resources.GetString("comboBox_PassportDay.Items3")
            });
            comboBox_PassportDay.Name = "comboBox_PassportDay";
            label5.AccessibleDescription = null;
            label5.AccessibleName = null;
            resources.ApplyResources(label5, "label5");
            label5.BackColor = System.Drawing.Color.Transparent;
            label5.Name = "label5";
            comboBox_Passport.AccessibleDescription = null;
            comboBox_Passport.AccessibleName = null;
            resources.ApplyResources(comboBox_Passport, "comboBox_Passport");
            comboBox_Passport.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            comboBox_Passport.BackgroundImage = null;
            comboBox_Passport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_Passport.Font = null;
            comboBox_Passport.FormattingEnabled = true;
            comboBox_Passport.Items.AddRange(new object[3]
            {
                resources.GetString("comboBox_Passport.Items"),
                resources.GetString("comboBox_Passport.Items1"),
                resources.GetString("comboBox_Passport.Items2")
            });
            comboBox_Passport.Name = "comboBox_Passport";
            label22.AccessibleDescription = null;
            label22.AccessibleName = null;
            resources.ApplyResources(label22, "label22");
            label22.BackColor = System.Drawing.Color.Transparent;
            label22.Font = null;
            label22.Name = "label22";
            panel1.AccessibleDescription = null;
            panel1.AccessibleName = null;
            resources.ApplyResources(panel1, "panel1");
            panel1.BackColor = System.Drawing.Color.Transparent;
            panel1.BackgroundImage = null;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(comboBox_IDMonths);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(comboBox_ID);
            panel1.Font = null;
            panel1.Name = "panel1";
            label2.AccessibleDescription = null;
            label2.AccessibleName = null;
            resources.ApplyResources(label2, "label2");
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Name = "label2";
            comboBox_IDMonths.AccessibleDescription = null;
            comboBox_IDMonths.AccessibleName = null;
            resources.ApplyResources(comboBox_IDMonths, "comboBox_IDMonths");
            comboBox_IDMonths.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            comboBox_IDMonths.BackgroundImage = null;
            comboBox_IDMonths.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_IDMonths.Font = null;
            comboBox_IDMonths.FormattingEnabled = true;
            comboBox_IDMonths.Items.AddRange(new object[2]
            {
                resources.GetString("comboBox_IDMonths.Items"),
                resources.GetString("comboBox_IDMonths.Items1")
            });
            comboBox_IDMonths.Name = "comboBox_IDMonths";
            label1.AccessibleDescription = null;
            label1.AccessibleName = null;
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Name = "label1";
            comboBox_ID.AccessibleDescription = null;
            comboBox_ID.AccessibleName = null;
            resources.ApplyResources(comboBox_ID, "comboBox_ID");
            comboBox_ID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            comboBox_ID.BackgroundImage = null;
            comboBox_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_ID.Font = null;
            comboBox_ID.FormattingEnabled = true;
            comboBox_ID.Items.AddRange(new object[2]
            {
                resources.GetString("comboBox_ID.Items"),
                resources.GetString("comboBox_ID.Items1")
            });
            comboBox_ID.Name = "comboBox_ID";
            panel4.AccessibleDescription = null;
            panel4.AccessibleName = null;
            resources.ApplyResources(panel4, "panel4");
            panel4.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            panel4.BackgroundImage = null;
            panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel4.Controls.Add(label48);
            panel4.Controls.Add(label47);
            panel4.Font = null;
            panel4.Name = "panel4";
            label48.AccessibleDescription = null;
            label48.AccessibleName = null;
            resources.ApplyResources(label48, "label48");
            label48.BackColor = System.Drawing.Color.Transparent;
            label48.ForeColor = System.Drawing.Color.Maroon;
            label48.Name = "label48";
            label47.AccessibleDescription = null;
            label47.AccessibleName = null;
            resources.ApplyResources(label47, "label47");
            label47.BackColor = System.Drawing.Color.Transparent;
            label47.Name = "label47";
            panel11.AccessibleDescription = null;
            panel11.AccessibleName = null;
            resources.ApplyResources(panel11, "panel11");
            panel11.BackColor = System.Drawing.Color.Transparent;
            panel11.BackgroundImage = null;
            panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel11.Font = null;
            panel11.Name = "panel11";
            base.AccessibleDescription = null;
            base.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImage = null;
            base.Controls.Add(Main_Panel);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.Name = "FrmPassportForm";
            base.Load += new System.EventHandler(FrmPassportForm_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(FrmPassportForm_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmPassportForm_KeyDown);
            Main_Panel.ResumeLayout(false);
            Main_Panel.PerformLayout();
            expandablePanel_Escorts.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Family).EndInit();
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }
    }
}
