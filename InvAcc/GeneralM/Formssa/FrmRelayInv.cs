using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
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
    public partial class FrmRelayInv : Form
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
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private T_AccDef _AccDefBind = new T_AccDef();
        private int LangArEn = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
        private string FlagUpdate = "";
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        private T_SYSSETTING _SysSetting = new T_SYSSETTING();
        private List<T_SYSSETTING> listSysSetting = new List<T_SYSSETTING>();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private List<T_INVSETTING> listInvSetting = new List<T_INVSETTING>();
        private T_GDHEAD _GdHead = new T_GDHEAD();
        private List<T_GDHEAD> listGdHead = new List<T_GDHEAD>();
        private T_GDDET _GdDet = new T_GDDET();
        private List<T_GDDET> listGdDet = new List<T_GDDET>();
        private List<T_GdAuto> listGdAuto = new List<T_GdAuto>();
        private T_GdAuto _GdAuto = new T_GdAuto();
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private T_User Permmission = new T_User();
        private ScriptNumber ScriptNumber1 = new ScriptNumber();
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

        private GroupPanel groupPanel2;
        private ComboBoxEx CmbUser;
        private Label label3;
        private GroupPanel groupPanel1;
        private ButtonX ButOk;
        private Label label_Balance;
        private ButtonX buttonX_Close;
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
        public FrmRelayInv()
        {
            InitializeComponent();
        }
        private void FillCombo()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                List<T_User> LUsr = (from t in dbc.T_Users
                                     where t.Usr_ID != 1
                                     orderby t.UsrNo
                                     select t).ToList();
                LUsr.Insert(0, new T_User());
                CmbUser.DataSource = LUsr;
                CmbUser.DisplayMember = "UsrNamA";
                CmbUser.ValueMember = "UsrNo";
            }
            else
            {
                List<T_User> LUsr = (from t in dbc.T_Users
                                     where t.Usr_ID != 1
                                     orderby t.UsrNo
                                     select t).ToList();
                LUsr.Insert(0, new T_User());
                CmbUser.DataSource = LUsr;
                CmbUser.DisplayMember = "UsrNamE";
                CmbUser.ValueMember = "UsrNo";
            }
            CmbUser.SelectedIndex = 0;
        }
        private void FrmRelayInv_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmRelayInv));
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    Language.ChangeLanguage("ar-SA", this, resources);
                    LangArEn = 0;
                    ButOk.Text = "ترحيل F2";
                    buttonX_Close.Text = "إغلاق Esc";
                    Text = "فواتير نقاط البيع";
                }
                else
                {
                    Language.ChangeLanguage("en", this, resources);
                    LangArEn = 1;
                    ButOk.Text = "Relay F2";
                    buttonX_Close.Text = "Close Esc";
                    Text = "POS Invoices";
                }
                Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
                FillCombo();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void GetInvSetting()
        {
            _InvSetting = new T_INVSETTING();
            _SysSetting = new T_SYSSETTING();
            _InvSetting = db.StockInvSetting(VarGeneral.UserID, VarGeneral.InvTyp);
            _SysSetting = db.SystemSettingStock();
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbUser.SelectedIndex <= 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من اسم المستخدم ثم حاول مرة اخرى" : "Check User Name", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    CmbUser.Focus();
                }
                else if (double.Parse(label_Balance.Text) <= 0.0)
                {
                    MessageBox.Show((LangArEn == 0) ? "جميع فواتير نقطة البيع هذه مرحل\u0651ة.. " : "All point of sale bills migrated", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    db.ExecuteCommand("UPDATE T_INVHED SET T_INVHED.InvId = 0  WHERE SalsManNo = '" + CmbUser.SelectedValue.ToString() + "' and T_INVHED.InvId > 0");
                    MessageBox.Show((LangArEn == 0) ? "تمت عملية الترحيل بنجاح .." : "Relay Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    CmbUser.SelectedIndex = 0;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FrmRelayInv_Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void FrmRelayInv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && ButOk.Enabled && ButOk.Visible)
            {
                ButOk_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void buttonX_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void CmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CmbUser.SelectedIndex <= 0)
                {
                    label_Balance.Text = "0";
                    return;
                }
                List<T_INVHED> list = (from t in db.T_INVHEDs
                                       orderby t.InvHed_ID
                                       where t.InvTyp == (int?)1
                                       where t.IfDel == (int?)0
                                       where t.IfRet == (int?)0
                                       where t.InvId.HasValue && t.InvId > (double?)0.0
                                       where t.SalsManNo == CmbUser.SelectedValue.ToString()
                                       select t).ToList();
                if (list.Count > 0)
                {
                    label_Balance.Text = list.Count.ToString();
                }
                else
                {
                    label_Balance.Text = "0";
                }
            }
            catch
            {
                label_Balance.Text = "0";
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmRelayInv));
            components = new System.ComponentModel.Container();

            groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            buttonX_Close = new DevComponents.DotNetBar.ButtonX();
            ButOk = new DevComponents.DotNetBar.ButtonX();
            CmbUser = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            label3 = new System.Windows.Forms.Label();
            groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            label_Balance = new System.Windows.Forms.Label();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();

            groupPanel2.SuspendLayout();
            groupPanel1.SuspendLayout();
            SuspendLayout();
            groupPanel2.AccessibleDescription = null;
            groupPanel2.AccessibleName = null;
            resources.ApplyResources(groupPanel2, "groupPanel2");
            groupPanel2.BackColor = System.Drawing.Color.Transparent;
            groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            groupPanel2.Controls.Add(buttonX_Close);
            groupPanel2.Controls.Add(ButOk);
            groupPanel2.Controls.Add(CmbUser);
            groupPanel2.Controls.Add(label3);
            groupPanel2.Font = null;
            groupPanel2.Name = "groupPanel2";
            groupPanel2.Style.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            groupPanel2.Style.BackColorGradientAngle = 90;
            groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel2.Style.BorderBottomWidth = 1;
            groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel2.Style.BorderLeftWidth = 1;
            groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel2.Style.BorderRightWidth = 1;
            groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel2.Style.BorderTopWidth = 1;
            groupPanel2.Style.CornerDiameter = 4;
            groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            groupPanel2.TitleImagePosition = DevComponents.DotNetBar.eTitleImagePosition.Center;
            buttonX_Close.AccessibleDescription = null;
            buttonX_Close.AccessibleName = null;
            buttonX_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(buttonX_Close, "buttonX_Close");
            buttonX_Close.BackgroundImage = null;
            buttonX_Close.Checked = true;
            buttonX_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            buttonX_Close.CommandParameter = null;
            buttonX_Close.Name = "buttonX_Close";
            buttonX_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            buttonX_Close.Symbol = "\uf011";
            buttonX_Close.TextColor = System.Drawing.Color.SteelBlue;
            buttonX_Close.Click += new System.EventHandler(buttonX_Close_Click);
            ButOk.AccessibleDescription = null;
            ButOk.AccessibleName = null;
            ButOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(ButOk, "ButOk");
            ButOk.BackgroundImage = null;
            ButOk.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            ButOk.CommandParameter = null;
            ButOk.Name = "ButOk";
            ButOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButOk.Symbol = "\uf00c";
            ButOk.SymbolSize = 16f;
            ButOk.TextColor = System.Drawing.Color.White;
            ButOk.Click += new System.EventHandler(ButOk_Click);
            CmbUser.AccessibleDescription = null;
            CmbUser.AccessibleName = null;
            resources.ApplyResources(CmbUser, "CmbUser");
            CmbUser.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            CmbUser.BackgroundImage = null;
            CmbUser.CommandParameter = null;
            CmbUser.DisplayMember = "Text";
            CmbUser.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            CmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CmbUser.Font = null;
            CmbUser.FormattingEnabled = true;
            CmbUser.Name = "CmbUser";
            CmbUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            CmbUser.SelectedIndexChanged += new System.EventHandler(CmbUser_SelectedIndexChanged);
            label3.AccessibleDescription = null;
            label3.AccessibleName = null;
            resources.ApplyResources(label3, "label3");
            label3.Font = null;
            label3.Name = "label3";
            groupPanel1.AccessibleDescription = null;
            groupPanel1.AccessibleName = null;
            resources.ApplyResources(groupPanel1, "groupPanel1");
            groupPanel1.BackColor = System.Drawing.Color.Transparent;
            groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            groupPanel1.Controls.Add(label_Balance);
            groupPanel1.Font = null;
            groupPanel1.Name = "groupPanel1";
            groupPanel1.Style.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            groupPanel1.Style.BackColorGradientAngle = 90;
            groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel1.Style.BorderBottomWidth = 1;
            groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel1.Style.BorderLeftWidth = 1;
            groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel1.Style.BorderRightWidth = 1;
            groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel1.Style.BorderTopWidth = 1;
            groupPanel1.Style.CornerDiameter = 4;
            groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            groupPanel1.TitleImagePosition = DevComponents.DotNetBar.eTitleImagePosition.Right;
            label_Balance.AccessibleDescription = null;
            label_Balance.AccessibleName = null;
            resources.ApplyResources(label_Balance, "label_Balance");
            label_Balance.BackColor = System.Drawing.Color.WhiteSmoke;
            label_Balance.ForeColor = System.Drawing.Color.Red;
            label_Balance.Name = "label_Balance";
            base.AccessibleDescription = null;
            base.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.SteelBlue;
            BackgroundImage = null;
            base.Controls.Add(groupPanel1);
            base.Controls.Add(groupPanel2);
            Font = null;
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.Name = "FrmRelayInv";
            base.Load += new System.EventHandler(FrmRelayInv_Load);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmRelayInv_KeyDown);
            groupPanel2.ResumeLayout(false);
            groupPanel2.PerformLayout();
            groupPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
