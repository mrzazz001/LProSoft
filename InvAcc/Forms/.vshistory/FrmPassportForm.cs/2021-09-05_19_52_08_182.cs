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
    public partial  class FrmPassportForm : Form
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
            public ColumnDictinary(string aText)
            {
                AText = aText;
            }
        }
        public class familyPassport
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
            InitializeComponent();this.Load += langloads;
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
    }
}
