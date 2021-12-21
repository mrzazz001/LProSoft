using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using Library.RepShow;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmTailor : Form
    { void avs(int arln)

{ 
}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
        public Dictionary<string, string> columns_Nams_Sums = new Dictionary<string, string>();
        public static int LangArEn = 0;
        private T_INVHED data_this;
        private List<T_INVDET> LData_This;
        private T_SYSSETTING _SysSetting = new T_SYSSETTING();
        private List<T_SYSSETTING> listSysSetting = new List<T_SYSSETTING>();
        private Stock_DataDataContext dbInstance;
        public List<Control> controls;
        public Control codeControl = new Control();
        public FormState statex;
        public bool CanEdit = true;
        protected bool ifOkDelete;
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private List<T_INVSETTING> listInvSetting = new List<T_INVSETTING>();
       // private IContainer components = null;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData.ToString().Contains("Control") && !keyData.ToString().ToLower().Contains("delete") && keyData.ToString().Contains("Alt"))
            {
                try
                {
                    VarGeneral.Print_set_Gen_Stat = true;
                    FrmReportsViewer.IsSettingOnly = true;
                    {
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "InvSalTailor";
                        frm.Repvalue = "InvSalTailor";
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
        public Label label6;
        public Label label9;
        public Label label12;
        public Label label13;
        public Label label11;
        public Label label10;
        public Panel panel3;
        public Panel panel2;
        public Line line2;
        public Line line1;
        public Label label16;
        public Label label17;
        public Label label22;
        public Label label15;
        public Label label18;
        public Label label19;
        public Label label20;
        public Label label21;
        public Panel panel4;
        public Label label25;
        public Label label24;
        public Label label23;
        public Label label14;
        public Label label27;
        public Panel panel5;
        public Line line3;
        public Panel panel6;
        public Label label28;
        public Label label29;
        public Line line4;
        public Panel panel7;
        public Panel panel9;
        public Panel panel8;
        public Label label30;
        public Label label31;
        public Label label32;
        public Panel panel13;
        public Panel panel10;
        public Panel panel12;
        public Panel panel11;
        public Panel panel14;
        public Label label34;
        public Label label33;
        public Panel panel15;
        public Panel panel16;
        public Panel panel21;
        public Panel panel22;
        public Panel panel23;
        public Panel panel24;
        public Panel panel25;
        public Panel panel17;
        public Line line7;
        public Line line6;
        public Line line5;
        public Panel panel18;
        public Panel panel_Main;
        public Panel panel20;
        public Panel x;
        public CheckBoxX text_tailor1_24;
        public PictureBox Image8;
        public Panel panel27;
        public CheckBoxX text_tailor1_28;
        public PictureBox Image12;
        public Panel panel28;
        public CheckBoxX text_tailor1_25;
        public Panel panel29;
        public CheckBoxX text_tailor1_26;
        public Panel panel30;
        public CheckBoxX text_tailor1_27;
        public PictureBox Image11;
        public PictureBox Image10;
        public PictureBox Image9;
        public Panel panel31;
        public Panel panel32;
        public CheckBoxX text_tailor1_23;
        public CheckBoxX text_tailor1_22;
        public CheckBoxX text_tailor1_21;
        public CheckBoxX text_tailor1_20;
        public Line line8;
        public Line line9;
        public Line line10;
        public PictureBox Image7;
        public PictureBox Image6;
        public PictureBox Image5;
        public PictureBox Image4;
        public Panel panel33;
        public CheckBoxX text_tailor1_19;
        public Panel panel34;
        public CheckBoxX text_tailor1_18;
        public Label label35;
        public Label label36;
        public Panel panel35;
        public PictureBox Image3;
        public PictureBox Image2;
        public Panel panel36;
        public CheckBoxX text_tailor1_15;
        public PictureBox Image1;
        public Panel panel37;
        public CheckBoxX text_tailor1_17;
        public Panel panel38;
        public CheckBoxX text_tailor1_16;
        public Panel panel39;
        public CheckBoxX text_tailor1_12;
        public Label label37;
        public Label label38;
        public Label label39;
        public Panel panel40;
        public CheckBoxX text_tailor1_14;
        public Panel panel41;
        public CheckBoxX text_tailor1_13;
        public Panel panel42;
        public CheckBoxX text_tailor1_7;
        public CheckBoxX text_tailor1_6;
        public Label label40;
        public Label label41;
        public Panel panel43;
        public CheckBoxX text_tailor1_5;
        public CheckBoxX text_tailor1_4;
        public Line line11;
        public TextBoxX text_tailor10;
        public TextBoxX text_tailor14;
        public Label label42;
        public Panel panel44;
        public CheckBoxX text_tailor1_11;
        public CheckBoxX text_tailor1_10;
        public CheckBoxX text_tailor1_9;
        public CheckBoxX text_tailor1_8;
        public Label label43;
        public Label label44;
        public Label label45;
        public Label label46;
        public TextBoxX text_tailor13;
        public TextBoxX text_tailor12;
        public Label label47;
        public Label label48;
        public Label label49;
        public Label label50;
        public Label label51;
        public Label label52;
        public Label label53;
        public Label label54;
        public Panel panel45;
        public CheckBoxX text_tailor1_3;
        public CheckBoxX text_tailor1_2;
        public Line line12;
        public Panel panel46;
        public CheckBoxX text_tailor1_1;
        public CheckBoxX text_tailor1_0;
        public Line line13;
        public TextBoxX text_tailor8;
        public TextBoxX text_tailor9;
        public TextBoxX text_tailor11;
        public Label label55;
        public Label label56;
        public Label label57;
        public Label label58;
        public Label label59;
        public Label label60;
        public Label label61;
        public Label label62;
        public Label label63;
        public Label label64;
        public Label label65;
        public Label label66;
        public Label label67;
        public Label label68;
        public LabelX labelX2;
        public Line line14;
        public LabelX labelX1;
        public Panel panel1;
        public ButtonX buttonX_Close;
        public ButtonX Button_Save;
        public ButtonX buttonItem_Print;
        public TextBoxX text_tailor6;
        public Label label8;
        public Label label3;
        public Label label4;
        public Label label5;
        public TextBoxX text_tailor5;
        public TextBoxX text_tailor7;
        public TextBoxX text_tailor4;
        public TextBoxX text_tailor2;
        public Label label7;
        public Label label2;
        public TextBoxX text_tailor3;
        public Label label1;
        public Label Label26;
        public T_INVHED DataThis
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
        public List<T_INVDET> LDataThis
        {
            get
            {
                return LData_This;
            }
            set
            {
                LData_This = value;
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
        public FrmTailor(T_INVHED vData)
        {
            InitializeComponent();this.Load += langloads;
            _InvSetting = new T_INVSETTING();
            _SysSetting = new T_SYSSETTING();
            _InvSetting = db.StockInvSetting( VarGeneral.InvTyp);
            _SysSetting = db.SystemSettingStock();
            buttonItem_Print.Text = ((_InvSetting.InvpRINTERInfo.nTyp.Substring(2, 1) == "1") ? "طباعة" : "عــرض");
            buttonItem_Print.Tooltip = "F5";
            text_tailor1_0.Click += Button_Edit_Click;
            text_tailor1_0.Click += Button_Edit_Click;
            text_tailor1_1.Click += Button_Edit_Click;
            text_tailor1_10.Click += Button_Edit_Click;
            text_tailor1_11.Click += Button_Edit_Click;
            text_tailor1_12.Click += Button_Edit_Click;
            text_tailor1_13.Click += Button_Edit_Click;
            text_tailor1_14.Click += Button_Edit_Click;
            text_tailor1_15.Click += Button_Edit_Click;
            text_tailor1_16.Click += Button_Edit_Click;
            text_tailor1_17.Click += Button_Edit_Click;
            text_tailor1_18.Click += Button_Edit_Click;
            text_tailor1_19.Click += Button_Edit_Click;
            text_tailor1_2.Click += Button_Edit_Click;
            text_tailor1_20.Click += Button_Edit_Click;
            text_tailor1_21.Click += Button_Edit_Click;
            text_tailor1_22.Click += Button_Edit_Click;
            text_tailor1_23.Click += Button_Edit_Click;
            text_tailor1_24.Click += Button_Edit_Click;
            text_tailor1_25.Click += Button_Edit_Click;
            text_tailor1_26.Click += Button_Edit_Click;
            text_tailor1_27.Click += Button_Edit_Click;
            text_tailor1_28.Click += Button_Edit_Click;
            text_tailor1_3.Click += Button_Edit_Click;
            text_tailor1_4.Click += Button_Edit_Click;
            text_tailor1_5.Click += Button_Edit_Click;
            text_tailor1_6.Click += Button_Edit_Click;
            text_tailor1_7.Click += Button_Edit_Click;
            text_tailor1_8.Click += Button_Edit_Click;
            text_tailor1_9.Click += Button_Edit_Click;
            text_tailor10.Click += Button_Edit_Click;
            text_tailor11.Click += Button_Edit_Click;
            text_tailor12.Click += Button_Edit_Click;
            text_tailor13.Click += Button_Edit_Click;
            text_tailor14.Click += Button_Edit_Click;
            text_tailor2.Click += Button_Edit_Click;
            text_tailor3.Click += Button_Edit_Click;
            text_tailor4.Click += Button_Edit_Click;
            text_tailor5.Click += Button_Edit_Click;
            text_tailor6.Click += Button_Edit_Click;
            text_tailor7.Click += Button_Edit_Click;
            text_tailor8.Click += Button_Edit_Click;
            text_tailor9.Click += Button_Edit_Click;
            try
            {
                DataThis = vData;
            }
            catch
            {
            }
        }
        private void ADD_Controls()
        {
            try
            {
                controls = new List<Control>();
                controls.Add(text_tailor1_0);
                controls.Add(text_tailor1_1);
                controls.Add(text_tailor1_10);
                controls.Add(text_tailor1_11);
                controls.Add(text_tailor1_12);
                controls.Add(text_tailor1_13);
                controls.Add(text_tailor1_14);
                controls.Add(text_tailor1_15);
                controls.Add(text_tailor1_16);
                controls.Add(text_tailor1_17);
                controls.Add(text_tailor1_18);
                controls.Add(text_tailor1_19);
                controls.Add(text_tailor1_2);
                controls.Add(text_tailor1_20);
                controls.Add(text_tailor1_21);
                controls.Add(text_tailor1_22);
                controls.Add(text_tailor1_23);
                controls.Add(text_tailor1_24);
                controls.Add(text_tailor1_25);
                controls.Add(text_tailor1_26);
                controls.Add(text_tailor1_27);
                controls.Add(text_tailor1_28);
                controls.Add(text_tailor1_3);
                controls.Add(text_tailor1_4);
                controls.Add(text_tailor1_5);
                controls.Add(text_tailor1_6);
                controls.Add(text_tailor1_7);
                controls.Add(text_tailor1_8);
                controls.Add(text_tailor1_9);
                controls.Add(text_tailor10);
                controls.Add(text_tailor11);
                controls.Add(text_tailor12);
                controls.Add(text_tailor13);
                controls.Add(text_tailor14);
                controls.Add(text_tailor2);
                controls.Add(text_tailor3);
                controls.Add(text_tailor4);
                controls.Add(text_tailor5);
                controls.Add(text_tailor6);
                controls.Add(text_tailor7);
                controls.Add(text_tailor8);
                controls.Add(text_tailor9);
            }
            catch (SqlException)
            {
            }
        }
        private void FrmTailor_Load(object sender, EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmTailor));
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                Language.ChangeLanguage("ar-SA", this, resources);
                LangArEn = 0;
            }
            else if (VarGeneral.CurrentLang.ToString() == "2")
            {
                Language.ChangeLanguage("af", this, resources);
                base.Size = new Size(578, 182);
                LangArEn = 0;
            }
            else
            {
                Language.ChangeLanguage("en", this, resources);
                LangArEn = 1;
            }
            base.ActiveControl = panel_Main;
            try
            {
                if (data_this == null || string.IsNullOrEmpty(data_this.InvNo))
                {
                    State = FormState.New;
                    SetReadOnly = false;
                }
                else
                {
                    T_INVHED newData = db.StockInvHead(VarGeneral.InvTyp, data_this.InvNo);
                    DataThis = new T_INVHED();
                    DataThis = newData;
                }
            }
            catch
            {
            }
            Button_Save_EnabledChanged(sender, e);
        }
        private void Button_Edit_Click(object sender, EventArgs e)
        {
            if (CanEdit && State != FormState.Edit && State != FormState.New && !string.IsNullOrEmpty(data_this.InvNo))
            {
                if (State != FormState.New)
                {
                    State = FormState.Edit;
                }
                SetReadOnly = false;
            }
        }
        public void SetData(T_INVHED value)
        {
            State = FormState.Saved;
            Button_Save.Enabled = false;
            try
            {
                if (string.IsNullOrEmpty(value.tailor1))
                {
                    return;
                }
            }
            catch
            {
            }
            text_tailor2.Text = value.tailor2;
            text_tailor3.Text = value.tailor3;
            text_tailor4.Text = value.tailor4;
            text_tailor5.Text = value.tailor5;
            text_tailor6.Text = value.tailor6;
            text_tailor7.Text = value.tailor7;
            text_tailor8.Text = value.tailor8;
            text_tailor9.Text = value.tailor9;
            text_tailor10.Text = value.tailor10;
            text_tailor11.Text = value.tailor11;
            text_tailor12.Text = value.tailor12;
            text_tailor13.Text = value.tailor13;
            text_tailor14.Text = value.tailor14;
            text_tailor1_0.Checked = VarGeneral.TString.ChkStatShow(value.tailor1, 0);
            text_tailor1_1.Checked = VarGeneral.TString.ChkStatShow(value.tailor1, 1);
            text_tailor1_2.Checked = VarGeneral.TString.ChkStatShow(value.tailor1, 2);
            text_tailor1_3.Checked = VarGeneral.TString.ChkStatShow(value.tailor1, 3);
            text_tailor1_4.Checked = VarGeneral.TString.ChkStatShow(value.tailor1, 4);
            text_tailor1_5.Checked = VarGeneral.TString.ChkStatShow(value.tailor1, 5);
            text_tailor1_6.Checked = VarGeneral.TString.ChkStatShow(value.tailor1, 6);
            text_tailor1_7.Checked = VarGeneral.TString.ChkStatShow(value.tailor1, 7);
            text_tailor1_8.Checked = VarGeneral.TString.ChkStatShow(value.tailor1, 8);
            text_tailor1_9.Checked = VarGeneral.TString.ChkStatShow(value.tailor1, 9);
            text_tailor1_10.Checked = VarGeneral.TString.ChkStatShow(value.tailor1, 10);
            text_tailor1_11.Checked = VarGeneral.TString.ChkStatShow(value.tailor1, 11);
            text_tailor1_12.Checked = VarGeneral.TString.ChkStatShow(value.tailor1, 12);
            text_tailor1_13.Checked = VarGeneral.TString.ChkStatShow(value.tailor1, 13);
            text_tailor1_14.Checked = VarGeneral.TString.ChkStatShow(value.tailor1, 14);
            text_tailor1_15.Checked = VarGeneral.TString.ChkStatShow(value.tailor1, 15);
            text_tailor1_16.Checked = VarGeneral.TString.ChkStatShow(value.tailor1, 16);
            text_tailor1_17.Checked = VarGeneral.TString.ChkStatShow(value.tailor1, 17);
            text_tailor1_18.Checked = VarGeneral.TString.ChkStatShow(value.tailor1, 18);
            text_tailor1_19.Checked = VarGeneral.TString.ChkStatShow(value.tailor1, 19);
            text_tailor1_20.Checked = VarGeneral.TString.ChkStatShow(value.tailor1, 20);
            text_tailor1_21.Checked = VarGeneral.TString.ChkStatShow(value.tailor1, 21);
            text_tailor1_22.Checked = VarGeneral.TString.ChkStatShow(value.tailor1, 22);
            text_tailor1_23.Checked = VarGeneral.TString.ChkStatShow(value.tailor1, 23);
            text_tailor1_24.Checked = VarGeneral.TString.ChkStatShow(value.tailor1, 24);
            text_tailor1_25.Checked = VarGeneral.TString.ChkStatShow(value.tailor1, 25);
            text_tailor1_26.Checked = VarGeneral.TString.ChkStatShow(value.tailor1, 26);
            text_tailor1_27.Checked = VarGeneral.TString.ChkStatShow(value.tailor1, 27);
            text_tailor1_28.Checked = VarGeneral.TString.ChkStatShow(value.tailor1, 28);
        }
        private void buttonX_Close_Click(object sender, EventArgs e)
        {
            VarGeneral.CurrentLang = "x";
            Close();
        }
        private void buttonX_Ok_Click(object sender, EventArgs e)
        {
            string setting = "";
            setting += VarGeneral.TString.ChkStatSave(text_tailor1_0.Checked);
            setting += VarGeneral.TString.ChkStatSave(text_tailor1_1.Checked);
            setting += VarGeneral.TString.ChkStatSave(text_tailor1_2.Checked);
            setting += VarGeneral.TString.ChkStatSave(text_tailor1_3.Checked);
            setting += VarGeneral.TString.ChkStatSave(text_tailor1_4.Checked);
            setting += VarGeneral.TString.ChkStatSave(text_tailor1_5.Checked);
            setting += VarGeneral.TString.ChkStatSave(text_tailor1_6.Checked);
            setting += VarGeneral.TString.ChkStatSave(text_tailor1_7.Checked);
            setting += VarGeneral.TString.ChkStatSave(text_tailor1_8.Checked);
            setting += VarGeneral.TString.ChkStatSave(text_tailor1_9.Checked);
            setting += VarGeneral.TString.ChkStatSave(text_tailor1_10.Checked);
            setting += VarGeneral.TString.ChkStatSave(text_tailor1_11.Checked);
            setting += VarGeneral.TString.ChkStatSave(text_tailor1_12.Checked);
            setting += VarGeneral.TString.ChkStatSave(text_tailor1_13.Checked);
            setting += VarGeneral.TString.ChkStatSave(text_tailor1_14.Checked);
            setting += VarGeneral.TString.ChkStatSave(text_tailor1_15.Checked);
            setting += VarGeneral.TString.ChkStatSave(text_tailor1_16.Checked);
            setting += VarGeneral.TString.ChkStatSave(text_tailor1_17.Checked);
            setting += VarGeneral.TString.ChkStatSave(text_tailor1_18.Checked);
            setting += VarGeneral.TString.ChkStatSave(text_tailor1_19.Checked);
            setting += VarGeneral.TString.ChkStatSave(text_tailor1_20.Checked);
            setting += VarGeneral.TString.ChkStatSave(text_tailor1_21.Checked);
            setting += VarGeneral.TString.ChkStatSave(text_tailor1_22.Checked);
            setting += VarGeneral.TString.ChkStatSave(text_tailor1_23.Checked);
            setting += VarGeneral.TString.ChkStatSave(text_tailor1_24.Checked);
            setting += VarGeneral.TString.ChkStatSave(text_tailor1_25.Checked);
            setting += VarGeneral.TString.ChkStatSave(text_tailor1_26.Checked);
            setting += VarGeneral.TString.ChkStatSave(text_tailor1_27.Checked);
            setting += VarGeneral.TString.ChkStatSave(text_tailor1_28.Checked);
            data_this.tailor1 = setting;
            data_this.tailor2 = text_tailor2.Text;
            data_this.tailor3 = text_tailor3.Text;
            data_this.tailor4 = text_tailor4.Text;
            data_this.tailor5 = text_tailor5.Text;
            data_this.tailor6 = text_tailor6.Text;
            data_this.tailor7 = text_tailor7.Text;
            data_this.tailor8 = text_tailor8.Text;
            data_this.tailor9 = text_tailor9.Text;
            data_this.tailor10 = text_tailor10.Text;
            data_this.tailor11 = text_tailor11.Text;
            data_this.tailor12 = text_tailor12.Text;
            data_this.tailor13 = text_tailor13.Text;
            data_this.tailor14 = text_tailor14.Text;
            try
            {
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
            State = FormState.Saved;
            SetReadOnly = true;
        }
        private void FrmTailor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && Button_Save.Enabled && Button_Save.Visible && State != 0)
            {
                buttonX_Ok_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F5)
            {
                if (buttonItem_Print.Enabled && buttonItem_Print.Visible && State == FormState.Saved)
                {
                    buttonItem_Print_Click(sender, e);
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void FrmTailor_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        private void buttonItem_Print_Click(object sender, EventArgs e)
        {
            try
            {
                VarGeneral.Print_set_Gen_Stat = false;
                if (data_this.InvNo != "" && State == FormState.Saved)
                {
                    _PrintInv(data_this.InvHed_ID, data_this.SalsManNo);
                }
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            VarGeneral.Print_set_Gen_Stat = false;
        }
        private int vStr(int vTy)
        {
            if (VarGeneral.InvTyp == 1)
            {
                if (VarGeneral._IsPOS)
                {
                    return 27;
                }
                return 1;
            }
            if (VarGeneral.InvTyp == 1)
            {
                return 1;
            }
            if (VarGeneral.InvTyp == 2)
            {
                return 5;
            }
            if (VarGeneral.InvTyp == 3)
            {
                return 3;
            }
            if (VarGeneral.InvTyp == 4)
            {
                return 7;
            }
            if (VarGeneral.InvTyp == 7)
            {
                return 9;
            }
            if (VarGeneral.InvTyp == 8)
            {
                return 11;
            }
            if (VarGeneral.InvTyp == 9)
            {
                return 13;
            }
            if (VarGeneral.InvTyp == 14)
            {
                return 15;
            }
            if (VarGeneral.InvTyp == 5)
            {
                return 17;
            }
            if (VarGeneral.InvTyp == 6)
            {
                return 19;
            }
            if (VarGeneral.InvTyp == 17)
            {
                return 21;
            }
            if (VarGeneral.InvTyp == 20)
            {
                return 23;
            }
            return 25;
        }
        private void _PrintInv(int _invHd, string _UserNo)
        {
            RepShow _RepShow = new RepShow();
            _RepShow.Tables = "T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
            string vInvH = " T_INVHED.InvHed_ID, T_INVHED.InvId as vID, T_INVHED.InvNo, T_INVHED.InvTyp, T_INVHED.InvCashPay, T_INVHED.CusVenNo,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Arb_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNm,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Eng_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNmE, T_INVHED.CusVenAdd, T_INVHED.CusVenTel, T_INVHED.Remark, T_INVHED.HDat, T_INVHED.GDat, T_INVHED.MndNo, T_INVHED.SalsManNo, T_INVHED.SalsManNam, T_INVHED.InvTot, T_INVHED.InvDisPrs, ((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints, T_INVHED.InvNet, T_INVHED.InvNetLocCur, T_INVHED.CashPayLocCur, T_INVHED.IfRet, T_INVHED.CashPay, T_INVHED.InvTotLocCur, T_INVHED.InvDisValLocCur, T_INVHED.GadeNo, T_INVHED.GadeId, T_INVHED.RetNo, T_INVHED.RetId, T_INVHED.InvCashPayNm, T_INVHED.InvCost, T_INVHED.CustPri, T_INVHED.ArbTaf, T_INVHED.ToStore, T_INVHED.InvCash, T_INVHED.CurTyp, T_INVHED.EstDat,case when DATEDIFF(day, GETDATE(), EstDat) > 0 Then DATEDIFF(day, GETDATE(), EstDat) WHEN DATEDIFF(day, GETDATE(), InvCashPayNm) > 0 THEN DATEDIFF(day, GETDATE(), InvCashPayNm) Else '0' END as EstDatNote, T_INVHED.InvCstNo, T_INVHED.IfDel, T_INVHED.RefNo, T_INVHED.ToStoreNm, T_INVHED.EngTaf, T_INVHED.IfTrans, T_INVHED.InvQty, T_INVHED.CustNet, T_INVHED.CustRep, T_INVHED.InvWight_T, T_INVHED.IfPrint, T_INVHED.LTim, T_INVHED.DATE_CREATED, T_INVHED.MODIFIED_BY, T_INVHED.CreditPay, T_INVHED.DATE_MODIFIED, T_INVHED.CREATED_BY, T_INVHED.CreditPayLocCur, T_INVHED.NetworkPay, T_INVHED.NetworkPayLocCur, T_INVHED.MndExtrnal, T_INVHED.CompanyID, T_INVHED.InvAddCost, T_INVHED.InvAddCostExtrnal, T_INVHED.InvAddCostExtrnalLoc, T_INVHED.IsExtrnalGaid, T_INVHED.ExtrnalCostGaidID, T_INVHED.InvAddCostLoc, T_INVHED.CommMnd_Inv, T_INVHED.Puyaid, T_INVHED.Remming,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.PersonalNm from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as PersonalNm,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.City from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as City,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Email from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Email,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Mobile from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Mobile,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Telphone1 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Telphone1,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select vColStr1 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CustAge,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Telphone2 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Telphone2,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Fax from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Fax,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.zipCod from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as zipCod,T_SYSSETTING.LineGiftlNameA,T_SYSSETTING.LineGiftlNameE,T_Curency.Arb_Des as CurrnceyNm,T_Curency.Eng_Des as CurrnceyNmE,(select max(gdDes)from T_GDDET where gdID = T_INVHED.GadeId )as gdDes, (T_INVDET.Amount - (case when T_INVHED.IsTaxLines = 1 then (case when T_INVHED.IsTaxByTotal = 1 then (case when (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) > 0 then ((Abs(T_INVDET.Qty) *  T_INVDET.Price) - case when (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) > 0 then (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) else 0 end )* T_INVDET.ItmTax / 100   else 0 end) else (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) end) else 0 end )) as TotBeforeTax,(select invGdADesc from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as invGdADesc,(select invGdEDesc from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as invGdEDesc,(select T_CATEGORY.CAT_No from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CAT_No,(select T_CATEGORY.Arb_Des from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CatNmA,(select T_CATEGORY.Eng_Des from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CatNmE,(case when (select t.BarCod1 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit1 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod1 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit1 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt ))  when (select t.BarCod2 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit2 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod2 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit2 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod3 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit3 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod3 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit3 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod4 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit4 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod4 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit4 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod5 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit5 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod5 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit5 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) else T_Items.Itm_No  end) as ItmBarcod";
            string Fields = " Abs(T_INVDET.Qty) as QtyAbs , T_INVDET.InvDet_ID,T_INVHED.tailor1,T_INVHED.tailor2,T_INVHED.tailor3,T_INVHED.tailor4,T_INVHED.tailor5,T_INVHED.tailor6,T_INVHED.tailor7,T_INVHED.tailor8,T_INVHED.tailor9,T_INVHED.tailor10,T_INVHED.tailor11,T_INVHED.tailor12,T_INVHED.tailor13,T_INVHED.tailor14,T_INVHED.tailor15,T_INVHED.tailor16,T_INVHED.tailor17,T_INVHED.tailor18,T_INVHED.tailor19,T_INVHED.tailor20,T_INVHED.InvImg, T_INVDET.InvNo, T_INVDET.InvId, T_INVDET.InvSer, T_INVDET.ItmNo, T_INVDET.Cost, T_INVDET.Qty, T_INVDET.ItmUnt, T_INVDET.ItmDes,T_INVDET.ItmDesE , T_INVDET.ItmUntE, T_INVDET.ItmUntPak, T_INVDET.StoreNo, T_INVDET.Price, T_INVDET.Amount, T_INVDET.RealQty, T_INVDET.ItmTyp,T_INVDET.ItmDis, (Abs(T_INVDET.Qty) *  T_INVDET.Price) * (T_INVDET.ItmDis / 100) as ItmDisVal, T_INVDET.DatExper, T_INVDET.itmInvDsc,ItmIndex," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.LineGiftSts, vStr(VarGeneral.InvTyp)) ? " T_INVDET.ItmWight " : " 0 as ItmWight") + ", T_INVDET.ItmWight_T, T_INVDET.ItmAddCost, T_INVDET.RunCod, T_INVDET.LineDetails ,T_INVDET.Serial_Key, " + vInvH + ", T_Items.* , T_CstTbl.Arb_Des as CstTbl_Arb_Des , T_CstTbl.Eng_Des as CstTbl_Eng_Des , T_Mndob.Arb_Des as Mndob_Arb_Des , T_Mndob.Eng_Des as Mndob_Eng_Des,T_SYSSETTING.LogImg,(select max(T_AccDef.TaxNo) from T_AccDef where T_AccDef.AccDef_No = T_SYSSETTING.TaxAcc) as TaxAcc,T_SYSSETTING.TaxNoteInv,case when T_INVHED.IsTaxLines = 1 then (case when T_INVHED.IsTaxByTotal = 1 then (case when (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) > 0 then ((Abs(T_INVDET.Qty) *  T_INVDET.Price) - case when (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) > 0 then (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) else 0 end )* T_INVDET.ItmTax / 100   else 0 end) else (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) end) else 0 end as TaxValue ,(select InvNamA from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as InvNamA,(select InvNamE from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as InvNamE,(select T_Store.Arb_Des from T_Store where T_Store.Stor_ID = T_INVDET.StoreNo) as StoreNmA,(select T_Store.Eng_Des from T_Store where T_Store.Stor_ID = T_INVDET.StoreNo) as StoreNmE,(select defPrn from T_INVSETTING where CatID = (select ItmCat from T_Items where Itm_No = T_INVDET.ItmNo) ) as defPrn,case when T_INVHED.CusVenNo = '' THEN '0' ELSE (SELECT Sum(T_GDDET.gdValue) FROM T_GDHEAD INNER JOIN  T_GDDET ON T_GDHEAD.gdhead_ID = T_GDDET.gdID where T_GDDET.AccNo = T_INVHED.CusVenNo and T_GDHEAD.gdLok = 0 and (select T_AccDef.AccCat from T_AccDef where T_AccDef.AccDef_No = T_INVHED.CusVenNo) = '4') END as Balanc,T_INVDET.ItmTax,T_INVHED.InvAddTax,T_INVHED.InvAddTaxlLoc,T_INVHED.TaxGaidID,T_INVHED.IsTaxUse,T_INVHED.IsTaxLines,IsTaxByTotal,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.TaxNo from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as TaxCustNo,T_INVHED.OrderTyp," + ((data_this.IsTaxLines.Value && !VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65)) ? " T_INVHED.InvTotLocCur - T_INVHED.InvAddTax as TotWithTaxPoint " : " T_INVHED.InvTotLocCur as TotWithTaxPoint") + " ,T_INVHED.InvTotLocCur - T_INVHED.InvDisVal as TotBeforeDisVal,T_INVHED.IsTaxByNet,T_INVHED.TaxByNetValue," + (data_this.IsTaxUse.Value ? " T_INVHED.InvNetLocCur - T_INVHED.InvAddTax as NetWithoutTax " : " T_INVHED.InvNetLocCur as NetWithoutTax");
            VarGeneral.HeaderRep[0] = Text;
            VarGeneral.HeaderRep[1] = "";
            VarGeneral.HeaderRep[2] = "";
            _RepShow.Rule = " where T_INVHED.InvHed_ID = " + data_this.InvHed_ID;
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptMaintenanceCars.dll"))
            {
                Fields += ",case when (select SUM(Amount) from T_INVDET where T_INVDET.InvId = T_INVHED.InvHed_ID and T_INVDET.ItmNo = T_Items.Itm_No and ItmUnt = 'ميكانيكا / كهرباء') != '' then (select SUM(Amount) from T_INVDET where T_INVDET.InvId = T_INVHED.InvHed_ID and T_INVDET.ItmNo = T_Items.Itm_No and ItmUnt = 'ميكانيكا / كهرباء')  else 0 end as Unt1,case when (select SUM(Amount) from T_INVDET where T_INVDET.InvId = T_INVHED.InvHed_ID and T_INVDET.ItmNo = T_Items.Itm_No and ItmUnt = 'سمكرة') != '' then (select SUM(Amount) from T_INVDET where T_INVDET.InvId = T_INVHED.InvHed_ID and T_INVDET.ItmNo = T_Items.Itm_No and ItmUnt = 'سمكرة') else 0 end as Unt2,case when (select SUM(Amount) from T_INVDET where T_INVDET.InvId = T_INVHED.InvHed_ID and T_INVDET.ItmNo = T_Items.Itm_No and ItmUnt = 'دهان') != '' then (select SUM(Amount) from T_INVDET where T_INVDET.InvId = T_INVHED.InvHed_ID and T_INVDET.ItmNo = T_Items.Itm_No and ItmUnt = 'دهان') else 0 end as Unt3,case when (select SUM(Amount) from T_INVDET where T_INVDET.InvId = T_INVHED.InvHed_ID and T_INVDET.ItmNo = T_Items.Itm_No and ItmUnt = 'قطع غيار') != '' then (select SUM(Amount) from T_INVDET where T_INVDET.InvId = T_INVHED.InvHed_ID and T_INVDET.ItmNo = T_Items.Itm_No and ItmUnt = 'قطع غيار') else 0 end as Unt4,case when (select SUM(Amount) from T_INVDET where T_INVDET.InvId = T_INVHED.InvHed_ID and T_INVDET.ItmNo = T_Items.Itm_No and ItmUnt = 'أجور يد') != '' then (select SUM(Amount) from T_INVDET where T_INVDET.InvId = T_INVHED.InvHed_ID and T_INVDET.ItmNo = T_Items.Itm_No and ItmUnt = 'أجور يد') else 0 end as Unt5";
            }
            if (string.IsNullOrEmpty(Fields))
            {
                return;
            }
            _RepShow.Fields = Fields;
            try
            {
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                _RepShow = new RepShow();
                _RepShow.Rule = " WHERE T_Users.UsrNo = '" + data_this.SalsManNo + "'";
                _RepShow.Tables = " T_Branch INNER JOIN T_Users ON T_Branch.Branch_no = T_Users.Brn ";
                _RepShow.Fields = " T_Users.UsrNamA ,T_Branch.Branch_Name ,T_Users.UsrNamE ,T_Branch.Branch_NameE ,T_Users.UsrImg ";
                try
                {
                    VarGeneral.RepShowStock_Rat = "Rate";
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepShowStock_Rat = "";
                }
                catch (Exception ex2)
                {
                    VarGeneral.RepShowStock_Rat = "";
                    MessageBox.Show(ex2.Message);
                }
                _RepShow.RepData.Tables[0].Merge(VarGeneral.RepData.Tables[0]);
                VarGeneral.RepData = _RepShow.RepData;
                try
                {
                    for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
                    {
                        if (string.IsNullOrEmpty(VarGeneral.RepData.Tables[0].Rows[i]["LogImg"].ToString()))
                        {
                            VarGeneral.RepData.Tables[0].Rows[i]["LogImg"] = VarGeneral.RepData.Tables[0].Rows[VarGeneral.RepData.Tables[0].Rows.Count - 1]["LogImg"];
                            VarGeneral.RepData.Tables[0].Rows[i]["LTim"] = VarGeneral.RepData.Tables[0].Rows[VarGeneral.RepData.Tables[0].Rows.Count - 1]["LTim"];
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
                    {
                        if (string.IsNullOrEmpty(VarGeneral.RepData.Tables[0].Rows[i]["UsrImg"].ToString()))
                        {
                            try
                            {
                                VarGeneral.RepData.Tables[0].Rows[i]["UsrImg"] = VarGeneral.RepData.Tables[0].Rows[0]["UsrImg"];
                            }
                            catch
                            {
                            }
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    if (VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 15))
                    {
                        _RepShow = new RepShow();
                        _RepShow.Tables = "T_SINVDET LEFT OUTER JOIN T_INVHED ON T_SINVDET.SInvIdHEAD = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_SINVDET.SItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                        _RepShow.Fields = " Abs(T_SINVDET.SQty) as QtyAbs , SInvDet_ID as InvId , SInvNo as InvNo, SInvId as InvDet_ID, SInvSer as InvSer,SItmNo as ItmNo, SCost as Cost, SQty as Qty, SItmDes as ItmDes, SItmUnt as ItmUnt, SItmDesE as ItmDesE, SItmUntE as ItmUntE, SItmUntPak as ItmUntPak, SStoreNo as StoreNo, (SPrice * 0) as Price, (SAmount * 0) as Amount, SRealQty as RealQty, SitmInvDsc as itmInvDsc, SDatExper as DatExper, SItmDis as ItmDis, SItmTyp as ItmTyp,SItmIndex as ItmIndex, SItmWight_T as ItmWight_T, SItmWight as ItmWight , T_INVHED.* , T_Items.* , T_CstTbl.Arb_Des as CstTbl_Arb_Des , T_CstTbl.Eng_Des as CstTbl_Eng_Des , T_Mndob.Arb_Des as Mndob_Arb_Des , T_Mndob.Eng_Des as Mndob_Eng_Des,T_SYSSETTING.LogImg,(select max(T_AccDef.TaxNo) from T_AccDef where T_AccDef.AccDef_No = T_SYSSETTING.TaxAcc) as TaxAcc,T_SYSSETTING.TaxNoteInv";
                        _RepShow.Rule = " where T_INVHED.InvHed_ID = " + data_this.InvHed_ID;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData.Tables[0].Merge(_RepShow.RepData.Tables[0]);
                    }
                }
                catch
                {
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
            if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
            {
                return;
            }
            try
            {
                FrmReportsViewer frm = new FrmReportsViewer();
                frm.Repvalue = "InvSalTailor";
                frm.Tag = LangArEn;
                frm.BarcodSts = false;
                if (_InvSetting.InvpRINTERInfo.nTyp.Substring(1, 1) == "1")
                {
                    frm.Repvalue = "InvSalTailor";
                }
                else
                {
                    frm.Repvalue = "InvSalTailor";
                }
                VarGeneral.CostCenterlbl = label15.Text.Replace(" :", "");
                VarGeneral.Mndoblbl = label18.Text.Replace(" :", "");
                VarGeneral.vTitle = "فاتورة مبيعات";
                if (_InvSetting.InvpRINTERInfo.nTyp.Substring(2, 1) == "1")
                {
                    frm._Proceess();
                    return;
                }
                frm.TopMost = true;
                frm.ShowDialog();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("buttonItem_Print_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void Button_Save_EnabledChanged(object sender, EventArgs e)
        {
            buttonItem_Print.Enabled = !Button_Save.Enabled;
        }
    }
}
