using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
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
    public partial class FrmTailor : Form
    {
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
        private IContainer components = null;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!keyData.ToString().Contains("Control") && !keyData.ToString().ToLower().Contains("delete") && keyData.ToString().Contains("Alt"))
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
            InitializeComponent();
            _InvSetting = new T_INVSETTING();
            _SysSetting = new T_SYSSETTING();
            _InvSetting = db.StockInvSetting(VarGeneral.UserID, VarGeneral.InvTyp);
            _SysSetting = db.SystemSettingStock();
            buttonItem_Print.Text = ((_InvSetting.InvpRINTERInfo.nTyp.Substring(2, 1) == "0") ? "طباعة" : "عــرض");
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
                if (_InvSetting.InvpRINTERInfo.nTyp.Substring(2, 1) == "0")
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmTailor));
            labelX1 = new DevComponents.DotNetBar.LabelX();
            panel1 = new System.Windows.Forms.Panel();
            panel21 = new System.Windows.Forms.Panel();
            panel18 = new System.Windows.Forms.Panel();
            panel22 = new System.Windows.Forms.Panel();
            panel23 = new System.Windows.Forms.Panel();
            panel24 = new System.Windows.Forms.Panel();
            panel25 = new System.Windows.Forms.Panel();
            panel16 = new System.Windows.Forms.Panel();
            panel17 = new System.Windows.Forms.Panel();
            line7 = new DevComponents.DotNetBar.Controls.Line();
            line6 = new DevComponents.DotNetBar.Controls.Line();
            line5 = new DevComponents.DotNetBar.Controls.Line();
            panel15 = new System.Windows.Forms.Panel();
            panel14 = new System.Windows.Forms.Panel();
            label34 = new System.Windows.Forms.Label();
            label33 = new System.Windows.Forms.Label();
            panel13 = new System.Windows.Forms.Panel();
            panel10 = new System.Windows.Forms.Panel();
            panel12 = new System.Windows.Forms.Panel();
            panel11 = new System.Windows.Forms.Panel();
            panel7 = new System.Windows.Forms.Panel();
            label30 = new System.Windows.Forms.Label();
            label31 = new System.Windows.Forms.Label();
            label32 = new System.Windows.Forms.Label();
            panel9 = new System.Windows.Forms.Panel();
            panel8 = new System.Windows.Forms.Panel();
            panel6 = new System.Windows.Forms.Panel();
            label28 = new System.Windows.Forms.Label();
            label29 = new System.Windows.Forms.Label();
            panel5 = new System.Windows.Forms.Panel();
            line3 = new DevComponents.DotNetBar.Controls.Line();
            label27 = new System.Windows.Forms.Label();
            panel4 = new System.Windows.Forms.Panel();
            label25 = new System.Windows.Forms.Label();
            label24 = new System.Windows.Forms.Label();
            label23 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            label22 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            label20 = new System.Windows.Forms.Label();
            label21 = new System.Windows.Forms.Label();
            panel3 = new System.Windows.Forms.Panel();
            line2 = new DevComponents.DotNetBar.Controls.Line();
            panel2 = new System.Windows.Forms.Panel();
            line1 = new DevComponents.DotNetBar.Controls.Line();
            label12 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            line4 = new DevComponents.DotNetBar.Controls.Line();
            panel_Main = new System.Windows.Forms.Panel();
            text_tailor6 = new DevComponents.DotNetBar.Controls.TextBoxX();
            label8 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            text_tailor5 = new DevComponents.DotNetBar.Controls.TextBoxX();
            text_tailor7 = new DevComponents.DotNetBar.Controls.TextBoxX();
            text_tailor4 = new DevComponents.DotNetBar.Controls.TextBoxX();
            text_tailor2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            label7 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            text_tailor3 = new DevComponents.DotNetBar.Controls.TextBoxX();
            label1 = new System.Windows.Forms.Label();
            Label26 = new System.Windows.Forms.Label();
            buttonX_Close = new DevComponents.DotNetBar.ButtonX();
            buttonItem_Print = new DevComponents.DotNetBar.ButtonX();
            Button_Save = new DevComponents.DotNetBar.ButtonX();
            panel20 = new System.Windows.Forms.Panel();
            x = new System.Windows.Forms.Panel();
            text_tailor1_24 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            Image8 = new System.Windows.Forms.PictureBox();
            panel27 = new System.Windows.Forms.Panel();
            text_tailor1_28 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            Image12 = new System.Windows.Forms.PictureBox();
            panel28 = new System.Windows.Forms.Panel();
            text_tailor1_25 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            panel29 = new System.Windows.Forms.Panel();
            text_tailor1_26 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            panel30 = new System.Windows.Forms.Panel();
            text_tailor1_27 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            Image11 = new System.Windows.Forms.PictureBox();
            Image10 = new System.Windows.Forms.PictureBox();
            Image9 = new System.Windows.Forms.PictureBox();
            panel31 = new System.Windows.Forms.Panel();
            panel32 = new System.Windows.Forms.Panel();
            text_tailor1_23 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            text_tailor1_22 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            text_tailor1_21 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            text_tailor1_20 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            line8 = new DevComponents.DotNetBar.Controls.Line();
            line9 = new DevComponents.DotNetBar.Controls.Line();
            line10 = new DevComponents.DotNetBar.Controls.Line();
            Image7 = new System.Windows.Forms.PictureBox();
            Image6 = new System.Windows.Forms.PictureBox();
            Image5 = new System.Windows.Forms.PictureBox();
            Image4 = new System.Windows.Forms.PictureBox();
            panel33 = new System.Windows.Forms.Panel();
            text_tailor1_19 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            panel34 = new System.Windows.Forms.Panel();
            text_tailor1_18 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            label35 = new System.Windows.Forms.Label();
            label36 = new System.Windows.Forms.Label();
            panel35 = new System.Windows.Forms.Panel();
            Image3 = new System.Windows.Forms.PictureBox();
            Image2 = new System.Windows.Forms.PictureBox();
            panel36 = new System.Windows.Forms.Panel();
            text_tailor1_15 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            Image1 = new System.Windows.Forms.PictureBox();
            panel37 = new System.Windows.Forms.Panel();
            text_tailor1_17 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            panel38 = new System.Windows.Forms.Panel();
            text_tailor1_16 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            panel39 = new System.Windows.Forms.Panel();
            text_tailor1_12 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            label37 = new System.Windows.Forms.Label();
            label38 = new System.Windows.Forms.Label();
            label39 = new System.Windows.Forms.Label();
            panel40 = new System.Windows.Forms.Panel();
            text_tailor1_14 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            panel41 = new System.Windows.Forms.Panel();
            text_tailor1_13 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            panel42 = new System.Windows.Forms.Panel();
            text_tailor1_7 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            text_tailor1_6 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            label40 = new System.Windows.Forms.Label();
            label41 = new System.Windows.Forms.Label();
            panel43 = new System.Windows.Forms.Panel();
            text_tailor1_5 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            text_tailor1_4 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            line11 = new DevComponents.DotNetBar.Controls.Line();
            text_tailor10 = new DevComponents.DotNetBar.Controls.TextBoxX();
            text_tailor14 = new DevComponents.DotNetBar.Controls.TextBoxX();
            label42 = new System.Windows.Forms.Label();
            panel44 = new System.Windows.Forms.Panel();
            text_tailor1_11 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            text_tailor1_10 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            text_tailor1_9 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            text_tailor1_8 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            label43 = new System.Windows.Forms.Label();
            label44 = new System.Windows.Forms.Label();
            label45 = new System.Windows.Forms.Label();
            label46 = new System.Windows.Forms.Label();
            text_tailor13 = new DevComponents.DotNetBar.Controls.TextBoxX();
            text_tailor12 = new DevComponents.DotNetBar.Controls.TextBoxX();
            label47 = new System.Windows.Forms.Label();
            label48 = new System.Windows.Forms.Label();
            label49 = new System.Windows.Forms.Label();
            label50 = new System.Windows.Forms.Label();
            label51 = new System.Windows.Forms.Label();
            label52 = new System.Windows.Forms.Label();
            label53 = new System.Windows.Forms.Label();
            label54 = new System.Windows.Forms.Label();
            panel45 = new System.Windows.Forms.Panel();
            text_tailor1_3 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            text_tailor1_2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            line12 = new DevComponents.DotNetBar.Controls.Line();
            panel46 = new System.Windows.Forms.Panel();
            text_tailor1_1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            text_tailor1_0 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            line13 = new DevComponents.DotNetBar.Controls.Line();
            text_tailor8 = new DevComponents.DotNetBar.Controls.TextBoxX();
            text_tailor9 = new DevComponents.DotNetBar.Controls.TextBoxX();
            text_tailor11 = new DevComponents.DotNetBar.Controls.TextBoxX();
            label55 = new System.Windows.Forms.Label();
            label56 = new System.Windows.Forms.Label();
            label57 = new System.Windows.Forms.Label();
            label58 = new System.Windows.Forms.Label();
            label59 = new System.Windows.Forms.Label();
            label60 = new System.Windows.Forms.Label();
            label61 = new System.Windows.Forms.Label();
            label62 = new System.Windows.Forms.Label();
            label63 = new System.Windows.Forms.Label();
            label64 = new System.Windows.Forms.Label();
            label65 = new System.Windows.Forms.Label();
            label66 = new System.Windows.Forms.Label();
            label67 = new System.Windows.Forms.Label();
            label68 = new System.Windows.Forms.Label();
            labelX2 = new DevComponents.DotNetBar.LabelX();
            line14 = new DevComponents.DotNetBar.Controls.Line();
            panel1.SuspendLayout();
            panel21.SuspendLayout();
            panel16.SuspendLayout();
            panel17.SuspendLayout();
            panel13.SuspendLayout();
            panel5.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel_Main.SuspendLayout();
            panel20.SuspendLayout();
            x.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Image8).BeginInit();
            panel27.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Image12).BeginInit();
            panel28.SuspendLayout();
            panel29.SuspendLayout();
            panel30.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Image11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Image10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Image9).BeginInit();
            panel31.SuspendLayout();
            panel32.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Image7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Image6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Image5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Image4).BeginInit();
            panel33.SuspendLayout();
            panel34.SuspendLayout();
            panel35.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Image3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Image2).BeginInit();
            panel36.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Image1).BeginInit();
            panel37.SuspendLayout();
            panel38.SuspendLayout();
            panel39.SuspendLayout();
            panel40.SuspendLayout();
            panel41.SuspendLayout();
            panel42.SuspendLayout();
            panel43.SuspendLayout();
            panel44.SuspendLayout();
            panel45.SuspendLayout();
            panel46.SuspendLayout();
            SuspendLayout();
            labelX1.AccessibleDescription = null;
            labelX1.AccessibleName = null;
            resources.ApplyResources(labelX1, "labelX1");
            labelX1.BackColor = System.Drawing.Color.SteelBlue;
            labelX1.BackgroundImage = null;
            labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX1.CommandParameter = null;
            labelX1.ForeColor = System.Drawing.Color.White;
            labelX1.Name = "labelX1";
            labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            panel1.AccessibleDescription = null;
            panel1.AccessibleName = null;
            resources.ApplyResources(panel1, "panel1");
            panel1.BackColor = System.Drawing.Color.Transparent;
            panel1.BackgroundImage = null;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(panel21);
            panel1.Controls.Add(panel16);
            panel1.Controls.Add(panel15);
            panel1.Controls.Add(panel14);
            panel1.Controls.Add(label34);
            panel1.Controls.Add(label33);
            panel1.Controls.Add(panel13);
            panel1.Controls.Add(panel7);
            panel1.Controls.Add(label30);
            panel1.Controls.Add(label31);
            panel1.Controls.Add(label32);
            panel1.Controls.Add(panel9);
            panel1.Controls.Add(panel8);
            panel1.Controls.Add(panel6);
            panel1.Controls.Add(label28);
            panel1.Controls.Add(label29);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(label27);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(label25);
            panel1.Controls.Add(label24);
            panel1.Controls.Add(label23);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(label16);
            panel1.Controls.Add(label17);
            panel1.Controls.Add(label22);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(label18);
            panel1.Controls.Add(label19);
            panel1.Controls.Add(label20);
            panel1.Controls.Add(label21);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(labelX1);
            panel1.Controls.Add(line4);
            panel1.Font = null;
            panel1.Name = "panel1";
            panel21.AccessibleDescription = null;
            panel21.AccessibleName = null;
            resources.ApplyResources(panel21, "panel21");
            panel21.BackColor = System.Drawing.Color.White;
            panel21.BackgroundImage = null;
            panel21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel21.Controls.Add(panel18);
            panel21.Controls.Add(panel22);
            panel21.Controls.Add(panel23);
            panel21.Controls.Add(panel24);
            panel21.Controls.Add(panel25);
            panel21.Font = null;
            panel21.Name = "panel21";
            panel18.AccessibleDescription = null;
            panel18.AccessibleName = null;
            resources.ApplyResources(panel18, "panel18");
            panel18.BackColor = System.Drawing.Color.White;
            panel18.BackgroundImage = null;
            panel18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel18.Font = null;
            panel18.Name = "panel18";
            panel22.AccessibleDescription = null;
            panel22.AccessibleName = null;
            resources.ApplyResources(panel22, "panel22");
            panel22.BackColor = System.Drawing.Color.White;
            panel22.BackgroundImage = null;
            panel22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel22.Font = null;
            panel22.Name = "panel22";
            panel23.AccessibleDescription = null;
            panel23.AccessibleName = null;
            resources.ApplyResources(panel23, "panel23");
            panel23.BackColor = System.Drawing.Color.White;
            panel23.BackgroundImage = null;
            panel23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel23.Font = null;
            panel23.Name = "panel23";
            panel24.AccessibleDescription = null;
            panel24.AccessibleName = null;
            resources.ApplyResources(panel24, "panel24");
            panel24.BackColor = System.Drawing.Color.White;
            panel24.BackgroundImage = null;
            panel24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel24.Font = null;
            panel24.Name = "panel24";
            panel25.AccessibleDescription = null;
            panel25.AccessibleName = null;
            resources.ApplyResources(panel25, "panel25");
            panel25.BackColor = System.Drawing.Color.White;
            panel25.BackgroundImage = null;
            panel25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel25.Font = null;
            panel25.Name = "panel25";
            panel16.AccessibleDescription = null;
            panel16.AccessibleName = null;
            resources.ApplyResources(panel16, "panel16");
            panel16.BackColor = System.Drawing.Color.White;
            panel16.BackgroundImage = null;
            panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel16.Controls.Add(panel17);
            panel16.Font = null;
            panel16.Name = "panel16";
            panel17.AccessibleDescription = null;
            panel17.AccessibleName = null;
            resources.ApplyResources(panel17, "panel17");
            panel17.BackgroundImage = null;
            panel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel17.Controls.Add(line7);
            panel17.Controls.Add(line6);
            panel17.Controls.Add(line5);
            panel17.Font = null;
            panel17.Name = "panel17";
            line7.AccessibleDescription = null;
            line7.AccessibleName = null;
            resources.ApplyResources(line7, "line7");
            line7.BackgroundImage = null;
            line7.Font = null;
            line7.Name = "line7";
            line7.VerticalLine = true;
            line6.AccessibleDescription = null;
            line6.AccessibleName = null;
            resources.ApplyResources(line6, "line6");
            line6.BackgroundImage = null;
            line6.Font = null;
            line6.Name = "line6";
            line6.VerticalLine = true;
            line5.AccessibleDescription = null;
            line5.AccessibleName = null;
            resources.ApplyResources(line5, "line5");
            line5.BackgroundImage = null;
            line5.Font = null;
            line5.Name = "line5";
            line5.VerticalLine = true;
            panel15.AccessibleDescription = null;
            panel15.AccessibleName = null;
            resources.ApplyResources(panel15, "panel15");
            panel15.BackgroundImage = null;
            panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel15.Font = null;
            panel15.Name = "panel15";
            panel14.AccessibleDescription = null;
            panel14.AccessibleName = null;
            resources.ApplyResources(panel14, "panel14");
            panel14.BackgroundImage = null;
            panel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel14.Font = null;
            panel14.Name = "panel14";
            label34.AccessibleDescription = null;
            label34.AccessibleName = null;
            resources.ApplyResources(label34, "label34");
            label34.BackColor = System.Drawing.Color.Transparent;
            label34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label34.ForeColor = System.Drawing.Color.SteelBlue;
            label34.Name = "label34";
            label33.AccessibleDescription = null;
            label33.AccessibleName = null;
            resources.ApplyResources(label33, "label33");
            label33.BackColor = System.Drawing.Color.Transparent;
            label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label33.ForeColor = System.Drawing.Color.SteelBlue;
            label33.Name = "label33";
            panel13.AccessibleDescription = null;
            panel13.AccessibleName = null;
            resources.ApplyResources(panel13, "panel13");
            panel13.BackColor = System.Drawing.Color.White;
            panel13.BackgroundImage = null;
            panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel13.Controls.Add(panel10);
            panel13.Controls.Add(panel12);
            panel13.Controls.Add(panel11);
            panel13.Font = null;
            panel13.Name = "panel13";
            panel10.AccessibleDescription = null;
            panel10.AccessibleName = null;
            resources.ApplyResources(panel10, "panel10");
            panel10.BackColor = System.Drawing.Color.White;
            panel10.BackgroundImage = null;
            panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel10.Font = null;
            panel10.Name = "panel10";
            panel12.AccessibleDescription = null;
            panel12.AccessibleName = null;
            resources.ApplyResources(panel12, "panel12");
            panel12.BackColor = System.Drawing.Color.White;
            panel12.BackgroundImage = null;
            panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel12.Font = null;
            panel12.Name = "panel12";
            panel11.AccessibleDescription = null;
            panel11.AccessibleName = null;
            resources.ApplyResources(panel11, "panel11");
            panel11.BackColor = System.Drawing.Color.White;
            panel11.BackgroundImage = null;
            panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel11.Font = null;
            panel11.Name = "panel11";
            panel7.AccessibleDescription = null;
            panel7.AccessibleName = null;
            resources.ApplyResources(panel7, "panel7");
            panel7.BackgroundImage = null;
            panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel7.Font = null;
            panel7.Name = "panel7";
            label30.AccessibleDescription = null;
            label30.AccessibleName = null;
            resources.ApplyResources(label30, "label30");
            label30.BackColor = System.Drawing.Color.Transparent;
            label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label30.ForeColor = System.Drawing.Color.SteelBlue;
            label30.Name = "label30";
            label31.AccessibleDescription = null;
            label31.AccessibleName = null;
            resources.ApplyResources(label31, "label31");
            label31.BackColor = System.Drawing.Color.Transparent;
            label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label31.ForeColor = System.Drawing.Color.SteelBlue;
            label31.Name = "label31";
            label32.AccessibleDescription = null;
            label32.AccessibleName = null;
            resources.ApplyResources(label32, "label32");
            label32.BackColor = System.Drawing.Color.Transparent;
            label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label32.ForeColor = System.Drawing.Color.SteelBlue;
            label32.Name = "label32";
            panel9.AccessibleDescription = null;
            panel9.AccessibleName = null;
            resources.ApplyResources(panel9, "panel9");
            panel9.BackgroundImage = null;
            panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel9.Font = null;
            panel9.Name = "panel9";
            panel8.AccessibleDescription = null;
            panel8.AccessibleName = null;
            resources.ApplyResources(panel8, "panel8");
            panel8.BackgroundImage = null;
            panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel8.Font = null;
            panel8.Name = "panel8";
            panel6.AccessibleDescription = null;
            panel6.AccessibleName = null;
            resources.ApplyResources(panel6, "panel6");
            panel6.BackgroundImage = null;
            panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel6.Font = null;
            panel6.Name = "panel6";
            label28.AccessibleDescription = null;
            label28.AccessibleName = null;
            resources.ApplyResources(label28, "label28");
            label28.BackColor = System.Drawing.Color.Transparent;
            label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label28.ForeColor = System.Drawing.Color.SteelBlue;
            label28.Name = "label28";
            label29.AccessibleDescription = null;
            label29.AccessibleName = null;
            resources.ApplyResources(label29, "label29");
            label29.BackColor = System.Drawing.Color.Transparent;
            label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label29.ForeColor = System.Drawing.Color.SteelBlue;
            label29.Name = "label29";
            panel5.AccessibleDescription = null;
            panel5.AccessibleName = null;
            resources.ApplyResources(panel5, "panel5");
            panel5.BackgroundImage = null;
            panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel5.Controls.Add(line3);
            panel5.Font = null;
            panel5.Name = "panel5";
            line3.AccessibleDescription = null;
            line3.AccessibleName = null;
            resources.ApplyResources(line3, "line3");
            line3.BackgroundImage = null;
            line3.Font = null;
            line3.Name = "line3";
            line3.VerticalLine = true;
            label27.AccessibleDescription = null;
            label27.AccessibleName = null;
            resources.ApplyResources(label27, "label27");
            label27.BackColor = System.Drawing.Color.Transparent;
            label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label27.ForeColor = System.Drawing.Color.SteelBlue;
            label27.Name = "label27";
            panel4.AccessibleDescription = null;
            panel4.AccessibleName = null;
            resources.ApplyResources(panel4, "panel4");
            panel4.BackgroundImage = null;
            panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel4.Font = null;
            panel4.Name = "panel4";
            label25.AccessibleDescription = null;
            label25.AccessibleName = null;
            resources.ApplyResources(label25, "label25");
            label25.BackColor = System.Drawing.Color.Transparent;
            label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label25.ForeColor = System.Drawing.Color.SteelBlue;
            label25.Name = "label25";
            label24.AccessibleDescription = null;
            label24.AccessibleName = null;
            resources.ApplyResources(label24, "label24");
            label24.BackColor = System.Drawing.Color.Transparent;
            label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label24.ForeColor = System.Drawing.Color.SteelBlue;
            label24.Name = "label24";
            label23.AccessibleDescription = null;
            label23.AccessibleName = null;
            resources.ApplyResources(label23, "label23");
            label23.BackColor = System.Drawing.Color.Transparent;
            label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label23.ForeColor = System.Drawing.Color.SteelBlue;
            label23.Name = "label23";
            label14.AccessibleDescription = null;
            label14.AccessibleName = null;
            resources.ApplyResources(label14, "label14");
            label14.BackColor = System.Drawing.Color.Transparent;
            label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label14.ForeColor = System.Drawing.Color.SteelBlue;
            label14.Name = "label14";
            label16.AccessibleDescription = null;
            label16.AccessibleName = null;
            resources.ApplyResources(label16, "label16");
            label16.BackColor = System.Drawing.Color.Transparent;
            label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label16.ForeColor = System.Drawing.Color.SteelBlue;
            label16.Name = "label16";
            label17.AccessibleDescription = null;
            label17.AccessibleName = null;
            resources.ApplyResources(label17, "label17");
            label17.BackColor = System.Drawing.Color.Transparent;
            label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label17.ForeColor = System.Drawing.Color.SteelBlue;
            label17.Name = "label17";
            label22.AccessibleDescription = null;
            label22.AccessibleName = null;
            resources.ApplyResources(label22, "label22");
            label22.BackColor = System.Drawing.Color.Transparent;
            label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label22.ForeColor = System.Drawing.Color.SteelBlue;
            label22.Name = "label22";
            label15.AccessibleDescription = null;
            label15.AccessibleName = null;
            resources.ApplyResources(label15, "label15");
            label15.BackColor = System.Drawing.Color.Transparent;
            label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label15.ForeColor = System.Drawing.Color.SteelBlue;
            label15.Name = "label15";
            label18.AccessibleDescription = null;
            label18.AccessibleName = null;
            resources.ApplyResources(label18, "label18");
            label18.BackColor = System.Drawing.Color.Transparent;
            label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label18.ForeColor = System.Drawing.Color.SteelBlue;
            label18.Name = "label18";
            label19.AccessibleDescription = null;
            label19.AccessibleName = null;
            resources.ApplyResources(label19, "label19");
            label19.BackColor = System.Drawing.Color.Transparent;
            label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label19.ForeColor = System.Drawing.Color.SteelBlue;
            label19.Name = "label19";
            label20.AccessibleDescription = null;
            label20.AccessibleName = null;
            resources.ApplyResources(label20, "label20");
            label20.BackColor = System.Drawing.Color.Transparent;
            label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label20.ForeColor = System.Drawing.Color.SteelBlue;
            label20.Name = "label20";
            label21.AccessibleDescription = null;
            label21.AccessibleName = null;
            resources.ApplyResources(label21, "label21");
            label21.BackColor = System.Drawing.Color.Transparent;
            label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label21.ForeColor = System.Drawing.Color.SteelBlue;
            label21.Name = "label21";
            panel3.AccessibleDescription = null;
            panel3.AccessibleName = null;
            resources.ApplyResources(panel3, "panel3");
            panel3.BackgroundImage = null;
            panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel3.Controls.Add(line2);
            panel3.Font = null;
            panel3.Name = "panel3";
            line2.AccessibleDescription = null;
            line2.AccessibleName = null;
            resources.ApplyResources(line2, "line2");
            line2.BackgroundImage = null;
            line2.Font = null;
            line2.Name = "line2";
            line2.VerticalLine = true;
            panel2.AccessibleDescription = null;
            panel2.AccessibleName = null;
            resources.ApplyResources(panel2, "panel2");
            panel2.BackgroundImage = null;
            panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel2.Controls.Add(line1);
            panel2.Font = null;
            panel2.Name = "panel2";
            line1.AccessibleDescription = null;
            line1.AccessibleName = null;
            resources.ApplyResources(line1, "line1");
            line1.BackgroundImage = null;
            line1.Font = null;
            line1.Name = "line1";
            line1.VerticalLine = true;
            label12.AccessibleDescription = null;
            label12.AccessibleName = null;
            resources.ApplyResources(label12, "label12");
            label12.BackColor = System.Drawing.Color.Transparent;
            label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label12.ForeColor = System.Drawing.Color.SteelBlue;
            label12.Name = "label12";
            label13.AccessibleDescription = null;
            label13.AccessibleName = null;
            resources.ApplyResources(label13, "label13");
            label13.BackColor = System.Drawing.Color.Transparent;
            label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label13.ForeColor = System.Drawing.Color.SteelBlue;
            label13.Name = "label13";
            label11.AccessibleDescription = null;
            label11.AccessibleName = null;
            resources.ApplyResources(label11, "label11");
            label11.BackColor = System.Drawing.Color.Transparent;
            label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label11.ForeColor = System.Drawing.Color.SteelBlue;
            label11.Name = "label11";
            label10.AccessibleDescription = null;
            label10.AccessibleName = null;
            resources.ApplyResources(label10, "label10");
            label10.BackColor = System.Drawing.Color.Transparent;
            label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label10.ForeColor = System.Drawing.Color.SteelBlue;
            label10.Name = "label10";
            label9.AccessibleDescription = null;
            label9.AccessibleName = null;
            resources.ApplyResources(label9, "label9");
            label9.BackColor = System.Drawing.Color.Transparent;
            label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label9.ForeColor = System.Drawing.Color.SteelBlue;
            label9.Name = "label9";
            label6.AccessibleDescription = null;
            label6.AccessibleName = null;
            resources.ApplyResources(label6, "label6");
            label6.BackColor = System.Drawing.Color.Transparent;
            label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label6.ForeColor = System.Drawing.Color.SteelBlue;
            label6.Name = "label6";
            line4.AccessibleDescription = null;
            line4.AccessibleName = null;
            resources.ApplyResources(line4, "line4");
            line4.BackgroundImage = null;
            line4.Font = null;
            line4.Name = "line4";
            line4.Thickness = 2;
            panel_Main.AccessibleDescription = null;
            panel_Main.AccessibleName = null;
            resources.ApplyResources(panel_Main, "panel_Main");
            panel_Main.BackColor = System.Drawing.Color.Transparent;
            panel_Main.BackgroundImage = null;
            panel_Main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel_Main.Controls.Add(text_tailor6);
            panel_Main.Controls.Add(label8);
            panel_Main.Controls.Add(label3);
            panel_Main.Controls.Add(label4);
            panel_Main.Controls.Add(label5);
            panel_Main.Controls.Add(text_tailor5);
            panel_Main.Controls.Add(text_tailor7);
            panel_Main.Controls.Add(text_tailor4);
            panel_Main.Controls.Add(text_tailor2);
            panel_Main.Controls.Add(label7);
            panel_Main.Controls.Add(label2);
            panel_Main.Controls.Add(text_tailor3);
            panel_Main.Controls.Add(label1);
            panel_Main.Controls.Add(Label26);
            panel_Main.Controls.Add(buttonX_Close);
            panel_Main.Controls.Add(buttonItem_Print);
            panel_Main.Controls.Add(Button_Save);
            panel_Main.Controls.Add(panel20);
            panel_Main.Controls.Add(panel31);
            panel_Main.Controls.Add(panel33);
            panel_Main.Controls.Add(panel34);
            panel_Main.Controls.Add(label35);
            panel_Main.Controls.Add(label36);
            panel_Main.Controls.Add(panel35);
            panel_Main.Controls.Add(panel39);
            panel_Main.Controls.Add(label37);
            panel_Main.Controls.Add(label38);
            panel_Main.Controls.Add(label39);
            panel_Main.Controls.Add(panel40);
            panel_Main.Controls.Add(panel41);
            panel_Main.Controls.Add(panel42);
            panel_Main.Controls.Add(label40);
            panel_Main.Controls.Add(label41);
            panel_Main.Controls.Add(panel43);
            panel_Main.Controls.Add(text_tailor10);
            panel_Main.Controls.Add(text_tailor14);
            panel_Main.Controls.Add(label42);
            panel_Main.Controls.Add(panel44);
            panel_Main.Controls.Add(label43);
            panel_Main.Controls.Add(label44);
            panel_Main.Controls.Add(label45);
            panel_Main.Controls.Add(label46);
            panel_Main.Controls.Add(text_tailor13);
            panel_Main.Controls.Add(text_tailor12);
            panel_Main.Controls.Add(label47);
            panel_Main.Controls.Add(label48);
            panel_Main.Controls.Add(label49);
            panel_Main.Controls.Add(label50);
            panel_Main.Controls.Add(label51);
            panel_Main.Controls.Add(label52);
            panel_Main.Controls.Add(label53);
            panel_Main.Controls.Add(label54);
            panel_Main.Controls.Add(panel45);
            panel_Main.Controls.Add(panel46);
            panel_Main.Controls.Add(text_tailor8);
            panel_Main.Controls.Add(text_tailor9);
            panel_Main.Controls.Add(text_tailor11);
            panel_Main.Controls.Add(label55);
            panel_Main.Controls.Add(label56);
            panel_Main.Controls.Add(label57);
            panel_Main.Controls.Add(label58);
            panel_Main.Controls.Add(label59);
            panel_Main.Controls.Add(label60);
            panel_Main.Controls.Add(label61);
            panel_Main.Controls.Add(label62);
            panel_Main.Controls.Add(label63);
            panel_Main.Controls.Add(label64);
            panel_Main.Controls.Add(label65);
            panel_Main.Controls.Add(label66);
            panel_Main.Controls.Add(label67);
            panel_Main.Controls.Add(label68);
            panel_Main.Controls.Add(labelX2);
            panel_Main.Controls.Add(line14);
            panel_Main.Font = null;
            panel_Main.Name = "panel_Main";
            text_tailor6.AccessibleDescription = null;
            text_tailor6.AccessibleName = null;
            resources.ApplyResources(text_tailor6, "text_tailor6");
            text_tailor6.BackColor = System.Drawing.Color.White;
            text_tailor6.BackgroundImage = null;
            text_tailor6.Border.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            text_tailor6.Border.Class = "TextBoxBorder";
            text_tailor6.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor6.ButtonCustom.DisplayPosition = (int)resources.GetObject("text_tailor6.ButtonCustom.DisplayPosition");
            text_tailor6.ButtonCustom.Image = (System.Drawing.Image)resources.GetObject("text_tailor6.ButtonCustom.Image");
            text_tailor6.ButtonCustom.Text = resources.GetString("text_tailor6.ButtonCustom.Text");
            text_tailor6.ButtonCustom2.DisplayPosition = (int)resources.GetObject("text_tailor6.ButtonCustom2.DisplayPosition");
            text_tailor6.ButtonCustom2.Image = (System.Drawing.Image)resources.GetObject("text_tailor6.ButtonCustom2.Image");
            text_tailor6.ButtonCustom2.Text = resources.GetString("text_tailor6.ButtonCustom2.Text");
            text_tailor6.Font = null;
            text_tailor6.ForeColor = System.Drawing.Color.Black;
            text_tailor6.Name = "text_tailor6";
            label8.AccessibleDescription = null;
            label8.AccessibleName = null;
            resources.ApplyResources(label8, "label8");
            label8.BackColor = System.Drawing.Color.Transparent;
            label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label8.ForeColor = System.Drawing.Color.SteelBlue;
            label8.Name = "label8";
            label3.AccessibleDescription = null;
            label3.AccessibleName = null;
            resources.ApplyResources(label3, "label3");
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label3.ForeColor = System.Drawing.Color.SteelBlue;
            label3.Name = "label3";
            label4.AccessibleDescription = null;
            label4.AccessibleName = null;
            resources.ApplyResources(label4, "label4");
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label4.ForeColor = System.Drawing.Color.SteelBlue;
            label4.Name = "label4";
            label5.AccessibleDescription = null;
            label5.AccessibleName = null;
            resources.ApplyResources(label5, "label5");
            label5.BackColor = System.Drawing.Color.Transparent;
            label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label5.ForeColor = System.Drawing.Color.SteelBlue;
            label5.Name = "label5";
            text_tailor5.AccessibleDescription = null;
            text_tailor5.AccessibleName = null;
            resources.ApplyResources(text_tailor5, "text_tailor5");
            text_tailor5.BackColor = System.Drawing.Color.White;
            text_tailor5.BackgroundImage = null;
            text_tailor5.Border.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            text_tailor5.Border.Class = "TextBoxBorder";
            text_tailor5.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor5.ButtonCustom.DisplayPosition = (int)resources.GetObject("text_tailor5.ButtonCustom.DisplayPosition");
            text_tailor5.ButtonCustom.Image = (System.Drawing.Image)resources.GetObject("text_tailor5.ButtonCustom.Image");
            text_tailor5.ButtonCustom.Text = resources.GetString("text_tailor5.ButtonCustom.Text");
            text_tailor5.ButtonCustom2.DisplayPosition = (int)resources.GetObject("text_tailor5.ButtonCustom2.DisplayPosition");
            text_tailor5.ButtonCustom2.Image = (System.Drawing.Image)resources.GetObject("text_tailor5.ButtonCustom2.Image");
            text_tailor5.ButtonCustom2.Text = resources.GetString("text_tailor5.ButtonCustom2.Text");
            text_tailor5.Font = null;
            text_tailor5.ForeColor = System.Drawing.Color.Black;
            text_tailor5.Name = "text_tailor5";
            text_tailor7.AccessibleDescription = null;
            text_tailor7.AccessibleName = null;
            resources.ApplyResources(text_tailor7, "text_tailor7");
            text_tailor7.BackColor = System.Drawing.Color.White;
            text_tailor7.BackgroundImage = null;
            text_tailor7.Border.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            text_tailor7.Border.Class = "TextBoxBorder";
            text_tailor7.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor7.ButtonCustom.DisplayPosition = (int)resources.GetObject("text_tailor7.ButtonCustom.DisplayPosition");
            text_tailor7.ButtonCustom.Image = (System.Drawing.Image)resources.GetObject("text_tailor7.ButtonCustom.Image");
            text_tailor7.ButtonCustom.Text = resources.GetString("text_tailor7.ButtonCustom.Text");
            text_tailor7.ButtonCustom2.DisplayPosition = (int)resources.GetObject("text_tailor7.ButtonCustom2.DisplayPosition");
            text_tailor7.ButtonCustom2.Image = (System.Drawing.Image)resources.GetObject("text_tailor7.ButtonCustom2.Image");
            text_tailor7.ButtonCustom2.Text = resources.GetString("text_tailor7.ButtonCustom2.Text");
            text_tailor7.Font = null;
            text_tailor7.ForeColor = System.Drawing.Color.Black;
            text_tailor7.Name = "text_tailor7";
            text_tailor4.AccessibleDescription = null;
            text_tailor4.AccessibleName = null;
            resources.ApplyResources(text_tailor4, "text_tailor4");
            text_tailor4.BackColor = System.Drawing.Color.White;
            text_tailor4.BackgroundImage = null;
            text_tailor4.Border.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            text_tailor4.Border.Class = "TextBoxBorder";
            text_tailor4.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor4.ButtonCustom.DisplayPosition = (int)resources.GetObject("text_tailor4.ButtonCustom.DisplayPosition");
            text_tailor4.ButtonCustom.Image = (System.Drawing.Image)resources.GetObject("text_tailor4.ButtonCustom.Image");
            text_tailor4.ButtonCustom.Text = resources.GetString("text_tailor4.ButtonCustom.Text");
            text_tailor4.ButtonCustom2.DisplayPosition = (int)resources.GetObject("text_tailor4.ButtonCustom2.DisplayPosition");
            text_tailor4.ButtonCustom2.Image = (System.Drawing.Image)resources.GetObject("text_tailor4.ButtonCustom2.Image");
            text_tailor4.ButtonCustom2.Text = resources.GetString("text_tailor4.ButtonCustom2.Text");
            text_tailor4.Font = null;
            text_tailor4.ForeColor = System.Drawing.Color.Black;
            text_tailor4.Name = "text_tailor4";
            text_tailor2.AccessibleDescription = null;
            text_tailor2.AccessibleName = null;
            resources.ApplyResources(text_tailor2, "text_tailor2");
            text_tailor2.BackColor = System.Drawing.Color.White;
            text_tailor2.BackgroundImage = null;
            text_tailor2.Border.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            text_tailor2.Border.Class = "TextBoxBorder";
            text_tailor2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor2.ButtonCustom.DisplayPosition = (int)resources.GetObject("text_tailor2.ButtonCustom.DisplayPosition");
            text_tailor2.ButtonCustom.Image = (System.Drawing.Image)resources.GetObject("text_tailor2.ButtonCustom.Image");
            text_tailor2.ButtonCustom.Text = resources.GetString("text_tailor2.ButtonCustom.Text");
            text_tailor2.ButtonCustom2.DisplayPosition = (int)resources.GetObject("text_tailor2.ButtonCustom2.DisplayPosition");
            text_tailor2.ButtonCustom2.Image = (System.Drawing.Image)resources.GetObject("text_tailor2.ButtonCustom2.Image");
            text_tailor2.ButtonCustom2.Text = resources.GetString("text_tailor2.ButtonCustom2.Text");
            text_tailor2.Font = null;
            text_tailor2.ForeColor = System.Drawing.Color.Black;
            text_tailor2.Name = "text_tailor2";
            label7.AccessibleDescription = null;
            label7.AccessibleName = null;
            resources.ApplyResources(label7, "label7");
            label7.BackColor = System.Drawing.Color.Transparent;
            label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label7.ForeColor = System.Drawing.Color.SteelBlue;
            label7.Name = "label7";
            label2.AccessibleDescription = null;
            label2.AccessibleName = null;
            resources.ApplyResources(label2, "label2");
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label2.ForeColor = System.Drawing.Color.SteelBlue;
            label2.Name = "label2";
            text_tailor3.AccessibleDescription = null;
            text_tailor3.AccessibleName = null;
            resources.ApplyResources(text_tailor3, "text_tailor3");
            text_tailor3.BackColor = System.Drawing.Color.White;
            text_tailor3.BackgroundImage = null;
            text_tailor3.Border.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            text_tailor3.Border.Class = "TextBoxBorder";
            text_tailor3.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor3.ButtonCustom.DisplayPosition = (int)resources.GetObject("text_tailor3.ButtonCustom.DisplayPosition");
            text_tailor3.ButtonCustom.Image = (System.Drawing.Image)resources.GetObject("text_tailor3.ButtonCustom.Image");
            text_tailor3.ButtonCustom.Text = resources.GetString("text_tailor3.ButtonCustom.Text");
            text_tailor3.ButtonCustom2.DisplayPosition = (int)resources.GetObject("text_tailor3.ButtonCustom2.DisplayPosition");
            text_tailor3.ButtonCustom2.Image = (System.Drawing.Image)resources.GetObject("text_tailor3.ButtonCustom2.Image");
            text_tailor3.ButtonCustom2.Text = resources.GetString("text_tailor3.ButtonCustom2.Text");
            text_tailor3.Font = null;
            text_tailor3.ForeColor = System.Drawing.Color.Black;
            text_tailor3.Name = "text_tailor3";
            label1.AccessibleDescription = null;
            label1.AccessibleName = null;
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label1.ForeColor = System.Drawing.Color.SteelBlue;
            label1.Name = "label1";
            Label26.AccessibleDescription = null;
            Label26.AccessibleName = null;
            resources.ApplyResources(Label26, "Label26");
            Label26.BackColor = System.Drawing.Color.Transparent;
            Label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Label26.ForeColor = System.Drawing.Color.SteelBlue;
            Label26.Name = "Label26";
            buttonX_Close.AccessibleDescription = null;
            buttonX_Close.AccessibleName = null;
            buttonX_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(buttonX_Close, "buttonX_Close");
            buttonX_Close.BackgroundImage = null;
            buttonX_Close.Checked = true;
            buttonX_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            buttonX_Close.CommandParameter = null;
            buttonX_Close.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            buttonX_Close.Name = "buttonX_Close";
            buttonX_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            buttonX_Close.Symbol = "\uf011";
            buttonX_Close.SymbolSize = 11f;
            buttonX_Close.TextColor = System.Drawing.Color.Black;
            buttonX_Close.Click += new System.EventHandler(buttonX_Close_Click);
            buttonItem_Print.AccessibleDescription = null;
            buttonItem_Print.AccessibleName = null;
            buttonItem_Print.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(buttonItem_Print, "buttonItem_Print");
            buttonItem_Print.BackgroundImage = null;
            buttonItem_Print.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            buttonItem_Print.CommandParameter = null;
            buttonItem_Print.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            buttonItem_Print.Name = "buttonItem_Print";
            buttonItem_Print.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            buttonItem_Print.SubItemsExpandWidth = 13;
            buttonItem_Print.Symbol = "\uf016";
            buttonItem_Print.SymbolSize = 22f;
            buttonItem_Print.TextColor = System.Drawing.Color.White;
            buttonItem_Print.Click += new System.EventHandler(buttonItem_Print_Click);
            Button_Save.AccessibleDescription = null;
            Button_Save.AccessibleName = null;
            Button_Save.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(Button_Save, "Button_Save");
            Button_Save.BackgroundImage = null;
            Button_Save.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            Button_Save.CommandParameter = null;
            Button_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_Save.Name = "Button_Save";
            Button_Save.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            Button_Save.SubItemsExpandWidth = 13;
            Button_Save.Symbol = "\uf00c";
            Button_Save.SymbolSize = 11f;
            Button_Save.TextColor = System.Drawing.Color.White;
            Button_Save.Click += new System.EventHandler(buttonX_Ok_Click);
            Button_Save.EnabledChanged += new System.EventHandler(Button_Save_EnabledChanged);
            panel20.AccessibleDescription = null;
            panel20.AccessibleName = null;
            resources.ApplyResources(panel20, "panel20");
            panel20.BackColor = System.Drawing.Color.White;
            panel20.BackgroundImage = null;
            panel20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel20.Controls.Add(x);
            panel20.Controls.Add(Image8);
            panel20.Controls.Add(panel27);
            panel20.Controls.Add(Image12);
            panel20.Controls.Add(panel28);
            panel20.Controls.Add(panel29);
            panel20.Controls.Add(panel30);
            panel20.Controls.Add(Image11);
            panel20.Controls.Add(Image10);
            panel20.Controls.Add(Image9);
            panel20.Font = null;
            panel20.Name = "panel20";
            x.AccessibleDescription = null;
            x.AccessibleName = null;
            resources.ApplyResources(x, "x");
            x.BackColor = System.Drawing.Color.White;
            x.BackgroundImage = null;
            x.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            x.Controls.Add(text_tailor1_24);
            x.Font = null;
            x.Name = "x";
            text_tailor1_24.AccessibleDescription = null;
            text_tailor1_24.AccessibleName = null;
            resources.ApplyResources(text_tailor1_24, "text_tailor1_24");
            text_tailor1_24.BackColor = System.Drawing.Color.Transparent;
            text_tailor1_24.BackgroundImage = null;
            text_tailor1_24.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor1_24.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            text_tailor1_24.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            text_tailor1_24.CheckSignSize = new System.Drawing.Size(14, 14);
            text_tailor1_24.CommandParameter = null;
            text_tailor1_24.Name = "text_tailor1_24";
            text_tailor1_24.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            Image8.AccessibleDescription = null;
            Image8.AccessibleName = null;
            resources.ApplyResources(Image8, "Image8");
            Image8.BackgroundImage = null;
            Image8.Font = null;
            Image8.ImageLocation = null;
            Image8.Name = "Image8";
            Image8.TabStop = false;
            panel27.AccessibleDescription = null;
            panel27.AccessibleName = null;
            resources.ApplyResources(panel27, "panel27");
            panel27.BackColor = System.Drawing.Color.White;
            panel27.BackgroundImage = null;
            panel27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel27.Controls.Add(text_tailor1_28);
            panel27.Font = null;
            panel27.Name = "panel27";
            text_tailor1_28.AccessibleDescription = null;
            text_tailor1_28.AccessibleName = null;
            resources.ApplyResources(text_tailor1_28, "text_tailor1_28");
            text_tailor1_28.BackColor = System.Drawing.Color.Transparent;
            text_tailor1_28.BackgroundImage = null;
            text_tailor1_28.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor1_28.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            text_tailor1_28.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            text_tailor1_28.CheckSignSize = new System.Drawing.Size(14, 14);
            text_tailor1_28.CommandParameter = null;
            text_tailor1_28.Name = "text_tailor1_28";
            text_tailor1_28.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            Image12.AccessibleDescription = null;
            Image12.AccessibleName = null;
            resources.ApplyResources(Image12, "Image12");
            Image12.BackgroundImage = null;
            Image12.Font = null;
            Image12.ImageLocation = null;
            Image12.Name = "Image12";
            Image12.TabStop = false;
            panel28.AccessibleDescription = null;
            panel28.AccessibleName = null;
            resources.ApplyResources(panel28, "panel28");
            panel28.BackColor = System.Drawing.Color.White;
            panel28.BackgroundImage = null;
            panel28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel28.Controls.Add(text_tailor1_25);
            panel28.Font = null;
            panel28.Name = "panel28";
            text_tailor1_25.AccessibleDescription = null;
            text_tailor1_25.AccessibleName = null;
            resources.ApplyResources(text_tailor1_25, "text_tailor1_25");
            text_tailor1_25.BackColor = System.Drawing.Color.Transparent;
            text_tailor1_25.BackgroundImage = null;
            text_tailor1_25.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor1_25.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            text_tailor1_25.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            text_tailor1_25.CheckSignSize = new System.Drawing.Size(14, 14);
            text_tailor1_25.CommandParameter = null;
            text_tailor1_25.Name = "text_tailor1_25";
            text_tailor1_25.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            panel29.AccessibleDescription = null;
            panel29.AccessibleName = null;
            resources.ApplyResources(panel29, "panel29");
            panel29.BackColor = System.Drawing.Color.White;
            panel29.BackgroundImage = null;
            panel29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel29.Controls.Add(text_tailor1_26);
            panel29.Font = null;
            panel29.Name = "panel29";
            text_tailor1_26.AccessibleDescription = null;
            text_tailor1_26.AccessibleName = null;
            resources.ApplyResources(text_tailor1_26, "text_tailor1_26");
            text_tailor1_26.BackColor = System.Drawing.Color.Transparent;
            text_tailor1_26.BackgroundImage = null;
            text_tailor1_26.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor1_26.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            text_tailor1_26.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            text_tailor1_26.CheckSignSize = new System.Drawing.Size(14, 14);
            text_tailor1_26.CommandParameter = null;
            text_tailor1_26.Name = "text_tailor1_26";
            text_tailor1_26.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            panel30.AccessibleDescription = null;
            panel30.AccessibleName = null;
            resources.ApplyResources(panel30, "panel30");
            panel30.BackColor = System.Drawing.Color.White;
            panel30.BackgroundImage = null;
            panel30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel30.Controls.Add(text_tailor1_27);
            panel30.Font = null;
            panel30.Name = "panel30";
            text_tailor1_27.AccessibleDescription = null;
            text_tailor1_27.AccessibleName = null;
            resources.ApplyResources(text_tailor1_27, "text_tailor1_27");
            text_tailor1_27.BackColor = System.Drawing.Color.Transparent;
            text_tailor1_27.BackgroundImage = null;
            text_tailor1_27.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor1_27.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            text_tailor1_27.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            text_tailor1_27.CheckSignSize = new System.Drawing.Size(14, 14);
            text_tailor1_27.CommandParameter = null;
            text_tailor1_27.Name = "text_tailor1_27";
            text_tailor1_27.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            Image11.AccessibleDescription = null;
            Image11.AccessibleName = null;
            resources.ApplyResources(Image11, "Image11");
            Image11.BackgroundImage = null;
            Image11.Font = null;
            Image11.ImageLocation = null;
            Image11.Name = "Image11";
            Image11.TabStop = false;
            Image10.AccessibleDescription = null;
            Image10.AccessibleName = null;
            resources.ApplyResources(Image10, "Image10");
            Image10.BackgroundImage = null;
            Image10.Font = null;
            Image10.ImageLocation = null;
            Image10.Name = "Image10";
            Image10.TabStop = false;
            Image9.AccessibleDescription = null;
            Image9.AccessibleName = null;
            resources.ApplyResources(Image9, "Image9");
            Image9.BackgroundImage = null;
            Image9.Font = null;
            Image9.ImageLocation = null;
            Image9.Name = "Image9";
            Image9.TabStop = false;
            panel31.AccessibleDescription = null;
            panel31.AccessibleName = null;
            resources.ApplyResources(panel31, "panel31");
            panel31.BackColor = System.Drawing.Color.White;
            panel31.BackgroundImage = null;
            panel31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel31.Controls.Add(panel32);
            panel31.Controls.Add(Image7);
            panel31.Controls.Add(Image6);
            panel31.Controls.Add(Image5);
            panel31.Controls.Add(Image4);
            panel31.Font = null;
            panel31.Name = "panel31";
            panel32.AccessibleDescription = null;
            panel32.AccessibleName = null;
            resources.ApplyResources(panel32, "panel32");
            panel32.BackgroundImage = null;
            panel32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel32.Controls.Add(text_tailor1_23);
            panel32.Controls.Add(text_tailor1_22);
            panel32.Controls.Add(text_tailor1_21);
            panel32.Controls.Add(text_tailor1_20);
            panel32.Controls.Add(line8);
            panel32.Controls.Add(line9);
            panel32.Controls.Add(line10);
            panel32.Font = null;
            panel32.Name = "panel32";
            text_tailor1_23.AccessibleDescription = null;
            text_tailor1_23.AccessibleName = null;
            resources.ApplyResources(text_tailor1_23, "text_tailor1_23");
            text_tailor1_23.BackColor = System.Drawing.Color.Transparent;
            text_tailor1_23.BackgroundImage = null;
            text_tailor1_23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor1_23.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            text_tailor1_23.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            text_tailor1_23.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
            text_tailor1_23.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            text_tailor1_23.CheckSignSize = new System.Drawing.Size(14, 14);
            text_tailor1_23.CommandParameter = null;
            text_tailor1_23.Name = "text_tailor1_23";
            text_tailor1_23.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            text_tailor1_22.AccessibleDescription = null;
            text_tailor1_22.AccessibleName = null;
            resources.ApplyResources(text_tailor1_22, "text_tailor1_22");
            text_tailor1_22.BackColor = System.Drawing.Color.Transparent;
            text_tailor1_22.BackgroundImage = null;
            text_tailor1_22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor1_22.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            text_tailor1_22.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            text_tailor1_22.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
            text_tailor1_22.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            text_tailor1_22.CheckSignSize = new System.Drawing.Size(14, 14);
            text_tailor1_22.CommandParameter = null;
            text_tailor1_22.Name = "text_tailor1_22";
            text_tailor1_22.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            text_tailor1_21.AccessibleDescription = null;
            text_tailor1_21.AccessibleName = null;
            resources.ApplyResources(text_tailor1_21, "text_tailor1_21");
            text_tailor1_21.BackColor = System.Drawing.Color.Transparent;
            text_tailor1_21.BackgroundImage = null;
            text_tailor1_21.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor1_21.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            text_tailor1_21.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            text_tailor1_21.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
            text_tailor1_21.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            text_tailor1_21.CheckSignSize = new System.Drawing.Size(14, 14);
            text_tailor1_21.CommandParameter = null;
            text_tailor1_21.Name = "text_tailor1_21";
            text_tailor1_21.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            text_tailor1_20.AccessibleDescription = null;
            text_tailor1_20.AccessibleName = null;
            resources.ApplyResources(text_tailor1_20, "text_tailor1_20");
            text_tailor1_20.BackColor = System.Drawing.Color.Transparent;
            text_tailor1_20.BackgroundImage = null;
            text_tailor1_20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor1_20.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            text_tailor1_20.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            text_tailor1_20.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
            text_tailor1_20.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            text_tailor1_20.Checked = true;
            text_tailor1_20.CheckSignSize = new System.Drawing.Size(14, 14);
            text_tailor1_20.CheckState = System.Windows.Forms.CheckState.Checked;
            text_tailor1_20.CheckValue = "Y";
            text_tailor1_20.CommandParameter = null;
            text_tailor1_20.Name = "text_tailor1_20";
            text_tailor1_20.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            line8.AccessibleDescription = null;
            line8.AccessibleName = null;
            resources.ApplyResources(line8, "line8");
            line8.BackgroundImage = null;
            line8.Font = null;
            line8.Name = "line8";
            line8.VerticalLine = true;
            line9.AccessibleDescription = null;
            line9.AccessibleName = null;
            resources.ApplyResources(line9, "line9");
            line9.BackgroundImage = null;
            line9.Font = null;
            line9.Name = "line9";
            line9.VerticalLine = true;
            line10.AccessibleDescription = null;
            line10.AccessibleName = null;
            resources.ApplyResources(line10, "line10");
            line10.BackgroundImage = null;
            line10.Font = null;
            line10.Name = "line10";
            line10.VerticalLine = true;
            Image7.AccessibleDescription = null;
            Image7.AccessibleName = null;
            resources.ApplyResources(Image7, "Image7");
            Image7.BackgroundImage = null;
            Image7.Font = null;
            Image7.ImageLocation = null;
            Image7.Name = "Image7";
            Image7.TabStop = false;
            Image6.AccessibleDescription = null;
            Image6.AccessibleName = null;
            resources.ApplyResources(Image6, "Image6");
            Image6.BackgroundImage = null;
            Image6.Font = null;
            Image6.ImageLocation = null;
            Image6.Name = "Image6";
            Image6.TabStop = false;
            Image5.AccessibleDescription = null;
            Image5.AccessibleName = null;
            resources.ApplyResources(Image5, "Image5");
            Image5.BackgroundImage = null;
            Image5.Font = null;
            Image5.ImageLocation = null;
            Image5.Name = "Image5";
            Image5.TabStop = false;
            Image4.AccessibleDescription = null;
            Image4.AccessibleName = null;
            resources.ApplyResources(Image4, "Image4");
            Image4.BackgroundImage = null;
            Image4.Font = null;
            Image4.ImageLocation = null;
            Image4.Name = "Image4";
            Image4.TabStop = false;
            panel33.AccessibleDescription = null;
            panel33.AccessibleName = null;
            resources.ApplyResources(panel33, "panel33");
            panel33.BackgroundImage = null;
            panel33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel33.Controls.Add(text_tailor1_19);
            panel33.Font = null;
            panel33.Name = "panel33";
            text_tailor1_19.AccessibleDescription = null;
            text_tailor1_19.AccessibleName = null;
            resources.ApplyResources(text_tailor1_19, "text_tailor1_19");
            text_tailor1_19.BackColor = System.Drawing.Color.Transparent;
            text_tailor1_19.BackgroundImage = null;
            text_tailor1_19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor1_19.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            text_tailor1_19.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            text_tailor1_19.CheckSignSize = new System.Drawing.Size(14, 14);
            text_tailor1_19.CommandParameter = null;
            text_tailor1_19.Name = "text_tailor1_19";
            text_tailor1_19.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            panel34.AccessibleDescription = null;
            panel34.AccessibleName = null;
            resources.ApplyResources(panel34, "panel34");
            panel34.BackgroundImage = null;
            panel34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel34.Controls.Add(text_tailor1_18);
            panel34.Font = null;
            panel34.Name = "panel34";
            text_tailor1_18.AccessibleDescription = null;
            text_tailor1_18.AccessibleName = null;
            resources.ApplyResources(text_tailor1_18, "text_tailor1_18");
            text_tailor1_18.BackColor = System.Drawing.Color.Transparent;
            text_tailor1_18.BackgroundImage = null;
            text_tailor1_18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor1_18.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            text_tailor1_18.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            text_tailor1_18.CheckSignSize = new System.Drawing.Size(14, 14);
            text_tailor1_18.CommandParameter = null;
            text_tailor1_18.Name = "text_tailor1_18";
            text_tailor1_18.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            label35.AccessibleDescription = null;
            label35.AccessibleName = null;
            resources.ApplyResources(label35, "label35");
            label35.BackColor = System.Drawing.Color.Transparent;
            label35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label35.ForeColor = System.Drawing.Color.SteelBlue;
            label35.Name = "label35";
            label36.AccessibleDescription = null;
            label36.AccessibleName = null;
            resources.ApplyResources(label36, "label36");
            label36.BackColor = System.Drawing.Color.Transparent;
            label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label36.ForeColor = System.Drawing.Color.SteelBlue;
            label36.Name = "label36";
            panel35.AccessibleDescription = null;
            panel35.AccessibleName = null;
            resources.ApplyResources(panel35, "panel35");
            panel35.BackColor = System.Drawing.Color.White;
            panel35.BackgroundImage = null;
            panel35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel35.Controls.Add(Image3);
            panel35.Controls.Add(Image2);
            panel35.Controls.Add(panel36);
            panel35.Controls.Add(Image1);
            panel35.Controls.Add(panel37);
            panel35.Controls.Add(panel38);
            panel35.Font = null;
            panel35.Name = "panel35";
            Image3.AccessibleDescription = null;
            Image3.AccessibleName = null;
            resources.ApplyResources(Image3, "Image3");
            Image3.BackgroundImage = null;
            Image3.Font = null;
            Image3.ImageLocation = null;
            Image3.Name = "Image3";
            Image3.TabStop = false;
            Image2.AccessibleDescription = null;
            Image2.AccessibleName = null;
            resources.ApplyResources(Image2, "Image2");
            Image2.BackgroundImage = null;
            Image2.Font = null;
            Image2.ImageLocation = null;
            Image2.Name = "Image2";
            Image2.TabStop = false;
            panel36.AccessibleDescription = null;
            panel36.AccessibleName = null;
            resources.ApplyResources(panel36, "panel36");
            panel36.BackColor = System.Drawing.Color.White;
            panel36.BackgroundImage = null;
            panel36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel36.Controls.Add(text_tailor1_15);
            panel36.Font = null;
            panel36.Name = "panel36";
            text_tailor1_15.AccessibleDescription = null;
            text_tailor1_15.AccessibleName = null;
            resources.ApplyResources(text_tailor1_15, "text_tailor1_15");
            text_tailor1_15.BackColor = System.Drawing.Color.Transparent;
            text_tailor1_15.BackgroundImage = null;
            text_tailor1_15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor1_15.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            text_tailor1_15.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            text_tailor1_15.CheckSignSize = new System.Drawing.Size(14, 14);
            text_tailor1_15.CommandParameter = null;
            text_tailor1_15.Name = "text_tailor1_15";
            text_tailor1_15.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            Image1.AccessibleDescription = null;
            Image1.AccessibleName = null;
            resources.ApplyResources(Image1, "Image1");
            Image1.BackgroundImage = null;
            Image1.Font = null;
            Image1.ImageLocation = null;
            Image1.Name = "Image1";
            Image1.TabStop = false;
            panel37.AccessibleDescription = null;
            panel37.AccessibleName = null;
            resources.ApplyResources(panel37, "panel37");
            panel37.BackColor = System.Drawing.Color.White;
            panel37.BackgroundImage = null;
            panel37.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel37.Controls.Add(text_tailor1_17);
            panel37.Font = null;
            panel37.Name = "panel37";
            text_tailor1_17.AccessibleDescription = null;
            text_tailor1_17.AccessibleName = null;
            resources.ApplyResources(text_tailor1_17, "text_tailor1_17");
            text_tailor1_17.BackColor = System.Drawing.Color.Transparent;
            text_tailor1_17.BackgroundImage = null;
            text_tailor1_17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor1_17.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            text_tailor1_17.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            text_tailor1_17.CheckSignSize = new System.Drawing.Size(14, 14);
            text_tailor1_17.CommandParameter = null;
            text_tailor1_17.Name = "text_tailor1_17";
            text_tailor1_17.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            panel38.AccessibleDescription = null;
            panel38.AccessibleName = null;
            resources.ApplyResources(panel38, "panel38");
            panel38.BackColor = System.Drawing.Color.White;
            panel38.BackgroundImage = null;
            panel38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel38.Controls.Add(text_tailor1_16);
            panel38.Font = null;
            panel38.Name = "panel38";
            text_tailor1_16.AccessibleDescription = null;
            text_tailor1_16.AccessibleName = null;
            resources.ApplyResources(text_tailor1_16, "text_tailor1_16");
            text_tailor1_16.BackColor = System.Drawing.Color.Transparent;
            text_tailor1_16.BackgroundImage = null;
            text_tailor1_16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor1_16.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            text_tailor1_16.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            text_tailor1_16.CheckSignSize = new System.Drawing.Size(14, 14);
            text_tailor1_16.CommandParameter = null;
            text_tailor1_16.Name = "text_tailor1_16";
            text_tailor1_16.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            panel39.AccessibleDescription = null;
            panel39.AccessibleName = null;
            resources.ApplyResources(panel39, "panel39");
            panel39.BackgroundImage = null;
            panel39.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel39.Controls.Add(text_tailor1_12);
            panel39.Font = null;
            panel39.Name = "panel39";
            text_tailor1_12.AccessibleDescription = null;
            text_tailor1_12.AccessibleName = null;
            resources.ApplyResources(text_tailor1_12, "text_tailor1_12");
            text_tailor1_12.BackColor = System.Drawing.Color.Transparent;
            text_tailor1_12.BackgroundImage = null;
            text_tailor1_12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor1_12.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            text_tailor1_12.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            text_tailor1_12.CheckSignSize = new System.Drawing.Size(14, 14);
            text_tailor1_12.CommandParameter = null;
            text_tailor1_12.Name = "text_tailor1_12";
            text_tailor1_12.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            label37.AccessibleDescription = null;
            label37.AccessibleName = null;
            resources.ApplyResources(label37, "label37");
            label37.BackColor = System.Drawing.Color.Transparent;
            label37.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label37.ForeColor = System.Drawing.Color.SteelBlue;
            label37.Name = "label37";
            label38.AccessibleDescription = null;
            label38.AccessibleName = null;
            resources.ApplyResources(label38, "label38");
            label38.BackColor = System.Drawing.Color.Transparent;
            label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label38.ForeColor = System.Drawing.Color.SteelBlue;
            label38.Name = "label38";
            label39.AccessibleDescription = null;
            label39.AccessibleName = null;
            resources.ApplyResources(label39, "label39");
            label39.BackColor = System.Drawing.Color.Transparent;
            label39.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label39.ForeColor = System.Drawing.Color.SteelBlue;
            label39.Name = "label39";
            panel40.AccessibleDescription = null;
            panel40.AccessibleName = null;
            resources.ApplyResources(panel40, "panel40");
            panel40.BackgroundImage = null;
            panel40.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel40.Controls.Add(text_tailor1_14);
            panel40.Font = null;
            panel40.Name = "panel40";
            text_tailor1_14.AccessibleDescription = null;
            text_tailor1_14.AccessibleName = null;
            resources.ApplyResources(text_tailor1_14, "text_tailor1_14");
            text_tailor1_14.BackColor = System.Drawing.Color.Transparent;
            text_tailor1_14.BackgroundImage = null;
            text_tailor1_14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor1_14.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            text_tailor1_14.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            text_tailor1_14.CheckSignSize = new System.Drawing.Size(14, 14);
            text_tailor1_14.CommandParameter = null;
            text_tailor1_14.Name = "text_tailor1_14";
            text_tailor1_14.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            panel41.AccessibleDescription = null;
            panel41.AccessibleName = null;
            resources.ApplyResources(panel41, "panel41");
            panel41.BackgroundImage = null;
            panel41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel41.Controls.Add(text_tailor1_13);
            panel41.Font = null;
            panel41.Name = "panel41";
            text_tailor1_13.AccessibleDescription = null;
            text_tailor1_13.AccessibleName = null;
            resources.ApplyResources(text_tailor1_13, "text_tailor1_13");
            text_tailor1_13.BackColor = System.Drawing.Color.Transparent;
            text_tailor1_13.BackgroundImage = null;
            text_tailor1_13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor1_13.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            text_tailor1_13.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            text_tailor1_13.CheckSignSize = new System.Drawing.Size(14, 14);
            text_tailor1_13.CommandParameter = null;
            text_tailor1_13.Name = "text_tailor1_13";
            text_tailor1_13.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            panel42.AccessibleDescription = null;
            panel42.AccessibleName = null;
            resources.ApplyResources(panel42, "panel42");
            panel42.BackgroundImage = null;
            panel42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel42.Controls.Add(text_tailor1_7);
            panel42.Controls.Add(text_tailor1_6);
            panel42.Font = null;
            panel42.Name = "panel42";
            text_tailor1_7.AccessibleDescription = null;
            text_tailor1_7.AccessibleName = null;
            resources.ApplyResources(text_tailor1_7, "text_tailor1_7");
            text_tailor1_7.BackColor = System.Drawing.Color.Transparent;
            text_tailor1_7.BackgroundImage = null;
            text_tailor1_7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor1_7.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            text_tailor1_7.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            text_tailor1_7.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
            text_tailor1_7.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            text_tailor1_7.CheckSignSize = new System.Drawing.Size(14, 14);
            text_tailor1_7.CommandParameter = null;
            text_tailor1_7.Name = "text_tailor1_7";
            text_tailor1_7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            text_tailor1_6.AccessibleDescription = null;
            text_tailor1_6.AccessibleName = null;
            resources.ApplyResources(text_tailor1_6, "text_tailor1_6");
            text_tailor1_6.BackColor = System.Drawing.Color.Transparent;
            text_tailor1_6.BackgroundImage = null;
            text_tailor1_6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor1_6.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            text_tailor1_6.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            text_tailor1_6.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
            text_tailor1_6.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            text_tailor1_6.Checked = true;
            text_tailor1_6.CheckSignSize = new System.Drawing.Size(14, 14);
            text_tailor1_6.CheckState = System.Windows.Forms.CheckState.Checked;
            text_tailor1_6.CheckValue = "Y";
            text_tailor1_6.CommandParameter = null;
            text_tailor1_6.Name = "text_tailor1_6";
            text_tailor1_6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            label40.AccessibleDescription = null;
            label40.AccessibleName = null;
            resources.ApplyResources(label40, "label40");
            label40.BackColor = System.Drawing.Color.Transparent;
            label40.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label40.ForeColor = System.Drawing.Color.SteelBlue;
            label40.Name = "label40";
            label41.AccessibleDescription = null;
            label41.AccessibleName = null;
            resources.ApplyResources(label41, "label41");
            label41.BackColor = System.Drawing.Color.Transparent;
            label41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label41.ForeColor = System.Drawing.Color.SteelBlue;
            label41.Name = "label41";
            panel43.AccessibleDescription = null;
            panel43.AccessibleName = null;
            resources.ApplyResources(panel43, "panel43");
            panel43.BackgroundImage = null;
            panel43.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel43.Controls.Add(text_tailor1_5);
            panel43.Controls.Add(text_tailor1_4);
            panel43.Controls.Add(line11);
            panel43.Font = null;
            panel43.Name = "panel43";
            text_tailor1_5.AccessibleDescription = null;
            text_tailor1_5.AccessibleName = null;
            resources.ApplyResources(text_tailor1_5, "text_tailor1_5");
            text_tailor1_5.BackColor = System.Drawing.Color.Transparent;
            text_tailor1_5.BackgroundImage = null;
            text_tailor1_5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor1_5.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            text_tailor1_5.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            text_tailor1_5.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
            text_tailor1_5.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            text_tailor1_5.CheckSignSize = new System.Drawing.Size(14, 14);
            text_tailor1_5.CommandParameter = null;
            text_tailor1_5.Name = "text_tailor1_5";
            text_tailor1_5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            text_tailor1_4.AccessibleDescription = null;
            text_tailor1_4.AccessibleName = null;
            resources.ApplyResources(text_tailor1_4, "text_tailor1_4");
            text_tailor1_4.BackColor = System.Drawing.Color.Transparent;
            text_tailor1_4.BackgroundImage = null;
            text_tailor1_4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor1_4.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            text_tailor1_4.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            text_tailor1_4.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
            text_tailor1_4.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            text_tailor1_4.Checked = true;
            text_tailor1_4.CheckSignSize = new System.Drawing.Size(14, 14);
            text_tailor1_4.CheckState = System.Windows.Forms.CheckState.Checked;
            text_tailor1_4.CheckValue = "Y";
            text_tailor1_4.CommandParameter = null;
            text_tailor1_4.Name = "text_tailor1_4";
            text_tailor1_4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            line11.AccessibleDescription = null;
            line11.AccessibleName = null;
            resources.ApplyResources(line11, "line11");
            line11.BackgroundImage = null;
            line11.Font = null;
            line11.Name = "line11";
            line11.VerticalLine = true;
            text_tailor10.AccessibleDescription = null;
            text_tailor10.AccessibleName = null;
            resources.ApplyResources(text_tailor10, "text_tailor10");
            text_tailor10.BackColor = System.Drawing.Color.White;
            text_tailor10.BackgroundImage = null;
            text_tailor10.Border.Class = "TextBoxBorder";
            text_tailor10.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor10.ButtonCustom.DisplayPosition = (int)resources.GetObject("text_tailor10.ButtonCustom.DisplayPosition");
            text_tailor10.ButtonCustom.Image = (System.Drawing.Image)resources.GetObject("text_tailor10.ButtonCustom.Image");
            text_tailor10.ButtonCustom.Text = resources.GetString("text_tailor10.ButtonCustom.Text");
            text_tailor10.ButtonCustom2.DisplayPosition = (int)resources.GetObject("text_tailor10.ButtonCustom2.DisplayPosition");
            text_tailor10.ButtonCustom2.Image = (System.Drawing.Image)resources.GetObject("text_tailor10.ButtonCustom2.Image");
            text_tailor10.ButtonCustom2.Text = resources.GetString("text_tailor10.ButtonCustom2.Text");
            text_tailor10.Font = null;
            text_tailor10.ForeColor = System.Drawing.Color.Black;
            text_tailor10.Name = "text_tailor10";
            text_tailor14.AccessibleDescription = null;
            text_tailor14.AccessibleName = null;
            resources.ApplyResources(text_tailor14, "text_tailor14");
            text_tailor14.BackColor = System.Drawing.Color.White;
            text_tailor14.BackgroundImage = null;
            text_tailor14.Border.Class = "TextBoxBorder";
            text_tailor14.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor14.ButtonCustom.DisplayPosition = (int)resources.GetObject("text_tailor14.ButtonCustom.DisplayPosition");
            text_tailor14.ButtonCustom.Image = (System.Drawing.Image)resources.GetObject("text_tailor14.ButtonCustom.Image");
            text_tailor14.ButtonCustom.Text = resources.GetString("text_tailor14.ButtonCustom.Text");
            text_tailor14.ButtonCustom2.DisplayPosition = (int)resources.GetObject("text_tailor14.ButtonCustom2.DisplayPosition");
            text_tailor14.ButtonCustom2.Image = (System.Drawing.Image)resources.GetObject("text_tailor14.ButtonCustom2.Image");
            text_tailor14.ButtonCustom2.Text = resources.GetString("text_tailor14.ButtonCustom2.Text");
            text_tailor14.Font = null;
            text_tailor14.ForeColor = System.Drawing.Color.Black;
            text_tailor14.Name = "text_tailor14";
            label42.AccessibleDescription = null;
            label42.AccessibleName = null;
            resources.ApplyResources(label42, "label42");
            label42.BackColor = System.Drawing.Color.Transparent;
            label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label42.ForeColor = System.Drawing.Color.SteelBlue;
            label42.Name = "label42";
            panel44.AccessibleDescription = null;
            panel44.AccessibleName = null;
            resources.ApplyResources(panel44, "panel44");
            panel44.BackgroundImage = null;
            panel44.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel44.Controls.Add(text_tailor1_11);
            panel44.Controls.Add(text_tailor1_10);
            panel44.Controls.Add(text_tailor1_9);
            panel44.Controls.Add(text_tailor1_8);
            panel44.Font = null;
            panel44.Name = "panel44";
            text_tailor1_11.AccessibleDescription = null;
            text_tailor1_11.AccessibleName = null;
            resources.ApplyResources(text_tailor1_11, "text_tailor1_11");
            text_tailor1_11.BackColor = System.Drawing.Color.Transparent;
            text_tailor1_11.BackgroundImage = null;
            text_tailor1_11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor1_11.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            text_tailor1_11.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            text_tailor1_11.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
            text_tailor1_11.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            text_tailor1_11.CheckSignSize = new System.Drawing.Size(14, 14);
            text_tailor1_11.CommandParameter = null;
            text_tailor1_11.Name = "text_tailor1_11";
            text_tailor1_11.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            text_tailor1_10.AccessibleDescription = null;
            text_tailor1_10.AccessibleName = null;
            resources.ApplyResources(text_tailor1_10, "text_tailor1_10");
            text_tailor1_10.BackColor = System.Drawing.Color.Transparent;
            text_tailor1_10.BackgroundImage = null;
            text_tailor1_10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor1_10.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            text_tailor1_10.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            text_tailor1_10.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
            text_tailor1_10.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            text_tailor1_10.CheckSignSize = new System.Drawing.Size(14, 14);
            text_tailor1_10.CommandParameter = null;
            text_tailor1_10.Name = "text_tailor1_10";
            text_tailor1_10.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            text_tailor1_9.AccessibleDescription = null;
            text_tailor1_9.AccessibleName = null;
            resources.ApplyResources(text_tailor1_9, "text_tailor1_9");
            text_tailor1_9.BackColor = System.Drawing.Color.Transparent;
            text_tailor1_9.BackgroundImage = null;
            text_tailor1_9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor1_9.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            text_tailor1_9.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            text_tailor1_9.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
            text_tailor1_9.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            text_tailor1_9.CheckSignSize = new System.Drawing.Size(14, 14);
            text_tailor1_9.CommandParameter = null;
            text_tailor1_9.Name = "text_tailor1_9";
            text_tailor1_9.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            text_tailor1_8.AccessibleDescription = null;
            text_tailor1_8.AccessibleName = null;
            resources.ApplyResources(text_tailor1_8, "text_tailor1_8");
            text_tailor1_8.BackColor = System.Drawing.Color.Transparent;
            text_tailor1_8.BackgroundImage = null;
            text_tailor1_8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor1_8.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            text_tailor1_8.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            text_tailor1_8.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
            text_tailor1_8.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            text_tailor1_8.Checked = true;
            text_tailor1_8.CheckSignSize = new System.Drawing.Size(14, 14);
            text_tailor1_8.CheckState = System.Windows.Forms.CheckState.Checked;
            text_tailor1_8.CheckValue = "Y";
            text_tailor1_8.CommandParameter = null;
            text_tailor1_8.Name = "text_tailor1_8";
            text_tailor1_8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            label43.AccessibleDescription = null;
            label43.AccessibleName = null;
            resources.ApplyResources(label43, "label43");
            label43.BackColor = System.Drawing.Color.Transparent;
            label43.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label43.ForeColor = System.Drawing.Color.SteelBlue;
            label43.Name = "label43";
            label44.AccessibleDescription = null;
            label44.AccessibleName = null;
            resources.ApplyResources(label44, "label44");
            label44.BackColor = System.Drawing.Color.Transparent;
            label44.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label44.ForeColor = System.Drawing.Color.SteelBlue;
            label44.Name = "label44";
            label45.AccessibleDescription = null;
            label45.AccessibleName = null;
            resources.ApplyResources(label45, "label45");
            label45.BackColor = System.Drawing.Color.Transparent;
            label45.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label45.ForeColor = System.Drawing.Color.SteelBlue;
            label45.Name = "label45";
            label46.AccessibleDescription = null;
            label46.AccessibleName = null;
            resources.ApplyResources(label46, "label46");
            label46.BackColor = System.Drawing.Color.Transparent;
            label46.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label46.ForeColor = System.Drawing.Color.SteelBlue;
            label46.Name = "label46";
            text_tailor13.AccessibleDescription = null;
            text_tailor13.AccessibleName = null;
            resources.ApplyResources(text_tailor13, "text_tailor13");
            text_tailor13.BackColor = System.Drawing.Color.White;
            text_tailor13.BackgroundImage = null;
            text_tailor13.Border.Class = "TextBoxBorder";
            text_tailor13.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor13.ButtonCustom.DisplayPosition = (int)resources.GetObject("text_tailor13.ButtonCustom.DisplayPosition");
            text_tailor13.ButtonCustom.Image = (System.Drawing.Image)resources.GetObject("text_tailor13.ButtonCustom.Image");
            text_tailor13.ButtonCustom.Text = resources.GetString("text_tailor13.ButtonCustom.Text");
            text_tailor13.ButtonCustom2.DisplayPosition = (int)resources.GetObject("text_tailor13.ButtonCustom2.DisplayPosition");
            text_tailor13.ButtonCustom2.Image = (System.Drawing.Image)resources.GetObject("text_tailor13.ButtonCustom2.Image");
            text_tailor13.ButtonCustom2.Text = resources.GetString("text_tailor13.ButtonCustom2.Text");
            text_tailor13.Font = null;
            text_tailor13.ForeColor = System.Drawing.Color.Black;
            text_tailor13.Name = "text_tailor13";
            text_tailor12.AccessibleDescription = null;
            text_tailor12.AccessibleName = null;
            resources.ApplyResources(text_tailor12, "text_tailor12");
            text_tailor12.BackColor = System.Drawing.Color.White;
            text_tailor12.BackgroundImage = null;
            text_tailor12.Border.Class = "TextBoxBorder";
            text_tailor12.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor12.ButtonCustom.DisplayPosition = (int)resources.GetObject("text_tailor12.ButtonCustom.DisplayPosition");
            text_tailor12.ButtonCustom.Image = (System.Drawing.Image)resources.GetObject("text_tailor12.ButtonCustom.Image");
            text_tailor12.ButtonCustom.Text = resources.GetString("text_tailor12.ButtonCustom.Text");
            text_tailor12.ButtonCustom2.DisplayPosition = (int)resources.GetObject("text_tailor12.ButtonCustom2.DisplayPosition");
            text_tailor12.ButtonCustom2.Image = (System.Drawing.Image)resources.GetObject("text_tailor12.ButtonCustom2.Image");
            text_tailor12.ButtonCustom2.Text = resources.GetString("text_tailor12.ButtonCustom2.Text");
            text_tailor12.Font = null;
            text_tailor12.ForeColor = System.Drawing.Color.Black;
            text_tailor12.Name = "text_tailor12";
            label47.AccessibleDescription = null;
            label47.AccessibleName = null;
            resources.ApplyResources(label47, "label47");
            label47.BackColor = System.Drawing.Color.Transparent;
            label47.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label47.ForeColor = System.Drawing.Color.SteelBlue;
            label47.Name = "label47";
            label48.AccessibleDescription = null;
            label48.AccessibleName = null;
            resources.ApplyResources(label48, "label48");
            label48.BackColor = System.Drawing.Color.Transparent;
            label48.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label48.ForeColor = System.Drawing.Color.SteelBlue;
            label48.Name = "label48";
            label49.AccessibleDescription = null;
            label49.AccessibleName = null;
            resources.ApplyResources(label49, "label49");
            label49.BackColor = System.Drawing.Color.Transparent;
            label49.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label49.ForeColor = System.Drawing.Color.SteelBlue;
            label49.Name = "label49";
            label50.AccessibleDescription = null;
            label50.AccessibleName = null;
            resources.ApplyResources(label50, "label50");
            label50.BackColor = System.Drawing.Color.Transparent;
            label50.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label50.ForeColor = System.Drawing.Color.SteelBlue;
            label50.Name = "label50";
            label51.AccessibleDescription = null;
            label51.AccessibleName = null;
            resources.ApplyResources(label51, "label51");
            label51.BackColor = System.Drawing.Color.Transparent;
            label51.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label51.ForeColor = System.Drawing.Color.SteelBlue;
            label51.Name = "label51";
            label52.AccessibleDescription = null;
            label52.AccessibleName = null;
            resources.ApplyResources(label52, "label52");
            label52.BackColor = System.Drawing.Color.Transparent;
            label52.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label52.ForeColor = System.Drawing.Color.SteelBlue;
            label52.Name = "label52";
            label53.AccessibleDescription = null;
            label53.AccessibleName = null;
            resources.ApplyResources(label53, "label53");
            label53.BackColor = System.Drawing.Color.Transparent;
            label53.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label53.ForeColor = System.Drawing.Color.SteelBlue;
            label53.Name = "label53";
            label54.AccessibleDescription = null;
            label54.AccessibleName = null;
            resources.ApplyResources(label54, "label54");
            label54.BackColor = System.Drawing.Color.Transparent;
            label54.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label54.ForeColor = System.Drawing.Color.SteelBlue;
            label54.Name = "label54";
            panel45.AccessibleDescription = null;
            panel45.AccessibleName = null;
            resources.ApplyResources(panel45, "panel45");
            panel45.BackgroundImage = null;
            panel45.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel45.Controls.Add(text_tailor1_3);
            panel45.Controls.Add(text_tailor1_2);
            panel45.Controls.Add(line12);
            panel45.Font = null;
            panel45.Name = "panel45";
            text_tailor1_3.AccessibleDescription = null;
            text_tailor1_3.AccessibleName = null;
            resources.ApplyResources(text_tailor1_3, "text_tailor1_3");
            text_tailor1_3.BackColor = System.Drawing.Color.Transparent;
            text_tailor1_3.BackgroundImage = null;
            text_tailor1_3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor1_3.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            text_tailor1_3.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            text_tailor1_3.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
            text_tailor1_3.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            text_tailor1_3.Checked = true;
            text_tailor1_3.CheckSignSize = new System.Drawing.Size(14, 14);
            text_tailor1_3.CheckState = System.Windows.Forms.CheckState.Checked;
            text_tailor1_3.CheckValue = "Y";
            text_tailor1_3.CommandParameter = null;
            text_tailor1_3.Name = "text_tailor1_3";
            text_tailor1_3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            text_tailor1_2.AccessibleDescription = null;
            text_tailor1_2.AccessibleName = null;
            resources.ApplyResources(text_tailor1_2, "text_tailor1_2");
            text_tailor1_2.BackColor = System.Drawing.Color.Transparent;
            text_tailor1_2.BackgroundImage = null;
            text_tailor1_2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor1_2.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            text_tailor1_2.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            text_tailor1_2.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
            text_tailor1_2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            text_tailor1_2.CheckSignSize = new System.Drawing.Size(14, 14);
            text_tailor1_2.CommandParameter = null;
            text_tailor1_2.Name = "text_tailor1_2";
            text_tailor1_2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            line12.AccessibleDescription = null;
            line12.AccessibleName = null;
            resources.ApplyResources(line12, "line12");
            line12.BackgroundImage = null;
            line12.Font = null;
            line12.Name = "line12";
            line12.VerticalLine = true;
            panel46.AccessibleDescription = null;
            panel46.AccessibleName = null;
            resources.ApplyResources(panel46, "panel46");
            panel46.BackgroundImage = null;
            panel46.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel46.Controls.Add(text_tailor1_1);
            panel46.Controls.Add(text_tailor1_0);
            panel46.Controls.Add(line13);
            panel46.Font = null;
            panel46.Name = "panel46";
            text_tailor1_1.AccessibleDescription = null;
            text_tailor1_1.AccessibleName = null;
            resources.ApplyResources(text_tailor1_1, "text_tailor1_1");
            text_tailor1_1.BackColor = System.Drawing.Color.Transparent;
            text_tailor1_1.BackgroundImage = null;
            text_tailor1_1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor1_1.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            text_tailor1_1.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            text_tailor1_1.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
            text_tailor1_1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            text_tailor1_1.Checked = true;
            text_tailor1_1.CheckSignSize = new System.Drawing.Size(14, 14);
            text_tailor1_1.CheckState = System.Windows.Forms.CheckState.Checked;
            text_tailor1_1.CheckValue = "Y";
            text_tailor1_1.CommandParameter = null;
            text_tailor1_1.Name = "text_tailor1_1";
            text_tailor1_1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            text_tailor1_0.AccessibleDescription = null;
            text_tailor1_0.AccessibleName = null;
            resources.ApplyResources(text_tailor1_0, "text_tailor1_0");
            text_tailor1_0.BackColor = System.Drawing.Color.Transparent;
            text_tailor1_0.BackgroundImage = null;
            text_tailor1_0.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor1_0.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            text_tailor1_0.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            text_tailor1_0.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
            text_tailor1_0.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            text_tailor1_0.CheckSignSize = new System.Drawing.Size(14, 14);
            text_tailor1_0.CommandParameter = null;
            text_tailor1_0.Name = "text_tailor1_0";
            text_tailor1_0.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            line13.AccessibleDescription = null;
            line13.AccessibleName = null;
            resources.ApplyResources(line13, "line13");
            line13.BackgroundImage = null;
            line13.Font = null;
            line13.Name = "line13";
            line13.VerticalLine = true;
            text_tailor8.AccessibleDescription = null;
            text_tailor8.AccessibleName = null;
            resources.ApplyResources(text_tailor8, "text_tailor8");
            text_tailor8.BackColor = System.Drawing.Color.White;
            text_tailor8.BackgroundImage = null;
            text_tailor8.Border.Class = "TextBoxBorder";
            text_tailor8.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor8.ButtonCustom.DisplayPosition = (int)resources.GetObject("text_tailor8.ButtonCustom.DisplayPosition");
            text_tailor8.ButtonCustom.Image = (System.Drawing.Image)resources.GetObject("text_tailor8.ButtonCustom.Image");
            text_tailor8.ButtonCustom.Text = resources.GetString("text_tailor8.ButtonCustom.Text");
            text_tailor8.ButtonCustom2.DisplayPosition = (int)resources.GetObject("text_tailor8.ButtonCustom2.DisplayPosition");
            text_tailor8.ButtonCustom2.Image = (System.Drawing.Image)resources.GetObject("text_tailor8.ButtonCustom2.Image");
            text_tailor8.ButtonCustom2.Text = resources.GetString("text_tailor8.ButtonCustom2.Text");
            text_tailor8.Font = null;
            text_tailor8.ForeColor = System.Drawing.Color.Black;
            text_tailor8.Name = "text_tailor8";
            text_tailor9.AccessibleDescription = null;
            text_tailor9.AccessibleName = null;
            resources.ApplyResources(text_tailor9, "text_tailor9");
            text_tailor9.BackColor = System.Drawing.Color.White;
            text_tailor9.BackgroundImage = null;
            text_tailor9.Border.Class = "TextBoxBorder";
            text_tailor9.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor9.ButtonCustom.DisplayPosition = (int)resources.GetObject("text_tailor9.ButtonCustom.DisplayPosition");
            text_tailor9.ButtonCustom.Image = (System.Drawing.Image)resources.GetObject("text_tailor9.ButtonCustom.Image");
            text_tailor9.ButtonCustom.Text = resources.GetString("text_tailor9.ButtonCustom.Text");
            text_tailor9.ButtonCustom2.DisplayPosition = (int)resources.GetObject("text_tailor9.ButtonCustom2.DisplayPosition");
            text_tailor9.ButtonCustom2.Image = (System.Drawing.Image)resources.GetObject("text_tailor9.ButtonCustom2.Image");
            text_tailor9.ButtonCustom2.Text = resources.GetString("text_tailor9.ButtonCustom2.Text");
            text_tailor9.Font = null;
            text_tailor9.ForeColor = System.Drawing.Color.Black;
            text_tailor9.Name = "text_tailor9";
            text_tailor11.AccessibleDescription = null;
            text_tailor11.AccessibleName = null;
            resources.ApplyResources(text_tailor11, "text_tailor11");
            text_tailor11.BackColor = System.Drawing.Color.White;
            text_tailor11.BackgroundImage = null;
            text_tailor11.Border.Class = "TextBoxBorder";
            text_tailor11.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            text_tailor11.ButtonCustom.DisplayPosition = (int)resources.GetObject("text_tailor11.ButtonCustom.DisplayPosition");
            text_tailor11.ButtonCustom.Image = (System.Drawing.Image)resources.GetObject("text_tailor11.ButtonCustom.Image");
            text_tailor11.ButtonCustom.Text = resources.GetString("text_tailor11.ButtonCustom.Text");
            text_tailor11.ButtonCustom2.DisplayPosition = (int)resources.GetObject("text_tailor11.ButtonCustom2.DisplayPosition");
            text_tailor11.ButtonCustom2.Image = (System.Drawing.Image)resources.GetObject("text_tailor11.ButtonCustom2.Image");
            text_tailor11.ButtonCustom2.Text = resources.GetString("text_tailor11.ButtonCustom2.Text");
            text_tailor11.Font = null;
            text_tailor11.ForeColor = System.Drawing.Color.Black;
            text_tailor11.Name = "text_tailor11";
            label55.AccessibleDescription = null;
            label55.AccessibleName = null;
            resources.ApplyResources(label55, "label55");
            label55.BackColor = System.Drawing.Color.Transparent;
            label55.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label55.ForeColor = System.Drawing.Color.SteelBlue;
            label55.Name = "label55";
            label56.AccessibleDescription = null;
            label56.AccessibleName = null;
            resources.ApplyResources(label56, "label56");
            label56.BackColor = System.Drawing.Color.Transparent;
            label56.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label56.ForeColor = System.Drawing.Color.SteelBlue;
            label56.Name = "label56";
            label57.AccessibleDescription = null;
            label57.AccessibleName = null;
            resources.ApplyResources(label57, "label57");
            label57.BackColor = System.Drawing.Color.Transparent;
            label57.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label57.ForeColor = System.Drawing.Color.SteelBlue;
            label57.Name = "label57";
            label58.AccessibleDescription = null;
            label58.AccessibleName = null;
            resources.ApplyResources(label58, "label58");
            label58.BackColor = System.Drawing.Color.Transparent;
            label58.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label58.ForeColor = System.Drawing.Color.SteelBlue;
            label58.Name = "label58";
            label59.AccessibleDescription = null;
            label59.AccessibleName = null;
            resources.ApplyResources(label59, "label59");
            label59.BackColor = System.Drawing.Color.Transparent;
            label59.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label59.ForeColor = System.Drawing.Color.SteelBlue;
            label59.Name = "label59";
            label60.AccessibleDescription = null;
            label60.AccessibleName = null;
            resources.ApplyResources(label60, "label60");
            label60.BackColor = System.Drawing.Color.Transparent;
            label60.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label60.ForeColor = System.Drawing.Color.SteelBlue;
            label60.Name = "label60";
            label61.AccessibleDescription = null;
            label61.AccessibleName = null;
            resources.ApplyResources(label61, "label61");
            label61.BackColor = System.Drawing.Color.Transparent;
            label61.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label61.ForeColor = System.Drawing.Color.SteelBlue;
            label61.Name = "label61";
            label62.AccessibleDescription = null;
            label62.AccessibleName = null;
            resources.ApplyResources(label62, "label62");
            label62.BackColor = System.Drawing.Color.Transparent;
            label62.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label62.ForeColor = System.Drawing.Color.SteelBlue;
            label62.Name = "label62";
            label63.AccessibleDescription = null;
            label63.AccessibleName = null;
            resources.ApplyResources(label63, "label63");
            label63.BackColor = System.Drawing.Color.Transparent;
            label63.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label63.ForeColor = System.Drawing.Color.SteelBlue;
            label63.Name = "label63";
            label64.AccessibleDescription = null;
            label64.AccessibleName = null;
            resources.ApplyResources(label64, "label64");
            label64.BackColor = System.Drawing.Color.Transparent;
            label64.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label64.ForeColor = System.Drawing.Color.SteelBlue;
            label64.Name = "label64";
            label65.AccessibleDescription = null;
            label65.AccessibleName = null;
            resources.ApplyResources(label65, "label65");
            label65.BackColor = System.Drawing.Color.Transparent;
            label65.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label65.ForeColor = System.Drawing.Color.SteelBlue;
            label65.Name = "label65";
            label66.AccessibleDescription = null;
            label66.AccessibleName = null;
            resources.ApplyResources(label66, "label66");
            label66.BackColor = System.Drawing.Color.Transparent;
            label66.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label66.ForeColor = System.Drawing.Color.SteelBlue;
            label66.Name = "label66";
            label67.AccessibleDescription = null;
            label67.AccessibleName = null;
            resources.ApplyResources(label67, "label67");
            label67.BackColor = System.Drawing.Color.Transparent;
            label67.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label67.ForeColor = System.Drawing.Color.SteelBlue;
            label67.Name = "label67";
            label68.AccessibleDescription = null;
            label68.AccessibleName = null;
            resources.ApplyResources(label68, "label68");
            label68.BackColor = System.Drawing.Color.Transparent;
            label68.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label68.ForeColor = System.Drawing.Color.SteelBlue;
            label68.Name = "label68";
            labelX2.AccessibleDescription = null;
            labelX2.AccessibleName = null;
            resources.ApplyResources(labelX2, "labelX2");
            labelX2.BackColor = System.Drawing.Color.SteelBlue;
            labelX2.BackgroundImage = null;
            labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX2.CommandParameter = null;
            labelX2.ForeColor = System.Drawing.Color.White;
            labelX2.Name = "labelX2";
            labelX2.TextAlignment = System.Drawing.StringAlignment.Center;
            line14.AccessibleDescription = null;
            line14.AccessibleName = null;
            resources.ApplyResources(line14, "line14");
            line14.BackgroundImage = null;
            line14.Font = null;
            line14.Name = "line14";
            line14.Thickness = 2;
            base.AccessibleDescription = null;
            base.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            BackgroundImage = null;
            base.ControlBox = false;
            base.Controls.Add(panel_Main);
            base.Controls.Add(panel1);
            Font = null;
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.Name = "FrmTailor";
            base.Load += new System.EventHandler(FrmTailor_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(FrmTailor_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmTailor_KeyDown);
            panel1.ResumeLayout(false);
            panel21.ResumeLayout(false);
            panel16.ResumeLayout(false);
            panel17.ResumeLayout(false);
            panel13.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel_Main.ResumeLayout(false);
            panel20.ResumeLayout(false);
            x.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Image8).EndInit();
            panel27.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Image12).EndInit();
            panel28.ResumeLayout(false);
            panel29.ResumeLayout(false);
            panel30.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Image11).EndInit();
            ((System.ComponentModel.ISupportInitialize)Image10).EndInit();
            ((System.ComponentModel.ISupportInitialize)Image9).EndInit();
            panel31.ResumeLayout(false);
            panel32.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Image7).EndInit();
            ((System.ComponentModel.ISupportInitialize)Image6).EndInit();
            ((System.ComponentModel.ISupportInitialize)Image5).EndInit();
            ((System.ComponentModel.ISupportInitialize)Image4).EndInit();
            panel33.ResumeLayout(false);
            panel34.ResumeLayout(false);
            panel35.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Image3).EndInit();
            ((System.ComponentModel.ISupportInitialize)Image2).EndInit();
            panel36.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Image1).EndInit();
            panel37.ResumeLayout(false);
            panel38.ResumeLayout(false);
            panel39.ResumeLayout(false);
            panel40.ResumeLayout(false);
            panel41.ResumeLayout(false);
            panel42.ResumeLayout(false);
            panel43.ResumeLayout(false);
            panel44.ResumeLayout(false);
            panel45.ResumeLayout(false);
            panel46.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
