using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmInvCat : Form
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
        private IContainer components = null;
        private GroupPanel groupPanel_Cat;
        private ButtonX button_Close;
        private ButtonX button_Save;
        private SuperGridControl dataGridViewX_Cat;
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
        private bool canUpdate = true;
        private int ControlNo = 0;
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstance;
        private T_INVHED data_this;
        public string List_Cat = "";
        public bool vSts_Op = false;
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
        public T_INVHED DataThis
        {
            get
            {
                return data_this;
            }
            set
            {
                data_this = value;
            }
        }
        public string ListCat
        {
            get
            {
                return List_Cat;
            }
            set
            {
                List_Cat = value;
            }
        }
        public bool vStsOp
        {
            get
            {
                return vSts_Op;
            }
            set
            {
                vSts_Op = value;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmInvCat));
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background2 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            groupPanel_Cat = new DevComponents.DotNetBar.Controls.GroupPanel();
            button_Close = new DevComponents.DotNetBar.ButtonX();
            button_Save = new DevComponents.DotNetBar.ButtonX();
            dataGridViewX_Cat = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            groupPanel_Cat.SuspendLayout();
            SuspendLayout();
            groupPanel_Cat.BackColor = System.Drawing.Color.White;
            groupPanel_Cat.CanvasColor = System.Drawing.SystemColors.Control;
            groupPanel_Cat.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            groupPanel_Cat.Controls.Add(button_Close);
            groupPanel_Cat.Controls.Add(button_Save);
            groupPanel_Cat.Controls.Add(dataGridViewX_Cat);
            resources.ApplyResources(groupPanel_Cat, "groupPanel_Cat");
            groupPanel_Cat.Name = "groupPanel_Cat";
            groupPanel_Cat.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            groupPanel_Cat.Style.BackColorGradientAngle = 90;
            groupPanel_Cat.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            groupPanel_Cat.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel_Cat.Style.BorderBottomWidth = 1;
            groupPanel_Cat.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            groupPanel_Cat.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel_Cat.Style.BorderLeftWidth = 1;
            groupPanel_Cat.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel_Cat.Style.BorderRightWidth = 1;
            groupPanel_Cat.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel_Cat.Style.BorderTopWidth = 1;
            groupPanel_Cat.Style.CornerDiameter = 4;
            groupPanel_Cat.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            groupPanel_Cat.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            groupPanel_Cat.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            groupPanel_Cat.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            groupPanel_Cat.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            groupPanel_Cat.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            button_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            button_Close.Checked = true;
            button_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(button_Close, "button_Close");
            button_Close.Name = "button_Close";
            button_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_Close.Symbol = "\uf011";
            button_Close.SymbolSize = 16f;
            button_Close.TextColor = System.Drawing.Color.Black;
            button_Close.Click += new System.EventHandler(button_Close_Click);
            button_Save.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            button_Save.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            resources.ApplyResources(button_Save, "button_Save");
            button_Save.Name = "button_Save";
            button_Save.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_Save.Symbol = "\uf0c5";
            button_Save.SymbolSize = 16f;
            button_Save.TextColor = System.Drawing.Color.White;
            button_Save.Click += new System.EventHandler(button_Save_Click);
            dataGridViewX_Cat.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(dataGridViewX_Cat, "dataGridViewX_Cat");
            dataGridViewX_Cat.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            dataGridViewX_Cat.ForeColor = System.Drawing.Color.Black;
            dataGridViewX_Cat.HScrollBarVisible = false;
            dataGridViewX_Cat.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            dataGridViewX_Cat.Name = "dataGridViewX_Cat";
            dataGridViewX_Cat.PrimaryGrid.AllowRowHeaderResize = true;
            dataGridViewX_Cat.PrimaryGrid.AllowRowResize = true;
            dataGridViewX_Cat.PrimaryGrid.ColumnHeader.RowHeight = 30;
            dataGridViewX_Cat.PrimaryGrid.ColumnHeader.SortImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_Cat.PrimaryGrid.ColumnHeader.Visible = false;
            gridColumn1.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn1.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.None;
            gridColumn1.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn1.Name = "*";
            gridColumn1.Width = 50;
            gridColumn2.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn2.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn2.FilterAutoScan = true;
            gridColumn2.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn2.InfoImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn2.Name = "رقم / إسم الإدارة";
            gridColumn2.ReadOnly = true;
            gridColumn2.Width = 263;
            gridColumn3.ReadOnly = true;
            gridColumn3.Visible = false;
            dataGridViewX_Cat.PrimaryGrid.Columns.Add(gridColumn1);
            dataGridViewX_Cat.PrimaryGrid.Columns.Add(gridColumn2);
            dataGridViewX_Cat.PrimaryGrid.Columns.Add(gridColumn3);
            dataGridViewX_Cat.PrimaryGrid.DefaultRowHeight = 24;
            background1.Color1 = System.Drawing.Color.White;
            background1.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            dataGridViewX_Cat.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = background1;
            background2.Color1 = System.Drawing.Color.White;
            background2.Color2 = System.Drawing.Color.FromArgb(255, 255, 192);
            dataGridViewX_Cat.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background2;
            dataGridViewX_Cat.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_Cat.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridViewX_Cat.PrimaryGrid.EnableColumnFiltering = true;
            dataGridViewX_Cat.PrimaryGrid.EnableFiltering = true;
            dataGridViewX_Cat.PrimaryGrid.EnableRowFiltering = true;
            dataGridViewX_Cat.PrimaryGrid.FilterLevel = DevComponents.DotNetBar.SuperGrid.FilterLevel.All;
            dataGridViewX_Cat.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            dataGridViewX_Cat.PrimaryGrid.MultiSelect = false;
            dataGridViewX_Cat.PrimaryGrid.NullString = "-----";
            dataGridViewX_Cat.PrimaryGrid.RowHeaderWidth = 45;
            dataGridViewX_Cat.PrimaryGrid.ShowColumnHeader = false;
            dataGridViewX_Cat.PrimaryGrid.ShowRowGridIndex = true;
            dataGridViewX_Cat.PrimaryGrid.ShowRowHeaders = false;
            dataGridViewX_Cat.PrimaryGrid.UseAlternateRowStyle = true;
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ControlBox = false;
            base.Controls.Add(groupPanel_Cat);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FrmInvCat";
            base.Load += new System.EventHandler(FrmInvCat_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(FrmInvCat_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmInvCat_KeyDown);
            groupPanel_Cat.ResumeLayout(false);
            ResumeLayout(false);
        }
        public FrmInvCat()
        {
            InitializeComponent();
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                button_Save.Text = "مـــوافــق";
                button_Close.Text = "تـراجـع";
            }
            else
            {
                button_Save.Text = "OK";
                button_Close.Text = "Back";
            }
            dataGridViewX_Cat.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "التصنيف" : "Category");
            dataGridViewX_Cat.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Background.Color1 = SystemColors.ActiveCaption;
            dataGridViewX_Cat.PrimaryGrid.UseAlternateColumnStyle = false;
        }
        private void FrmInvCat_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmInvCat));
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    LangArEn = 0;
                }
                else
                {
                    LangArEn = 1;
                }
                RibunButtons();
                FillGrid();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void FillGrid()
        {
            dataGridViewX_Cat.PrimaryGrid.Rows.Clear();
            GridRow row = new GridRow();
            List<T_CATEGORY> listDept = db.FillCat_2("").ToList();
            try
            {
                listDept = listDept.OrderBy((T_CATEGORY c) => int.Parse(c.CAT_No)).ToList();
            }
            catch
            {
            }
            for (int i = 0; i < listDept.Count; i++)
            {
                row = new GridRow();
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                dataGridViewX_Cat.PrimaryGrid.Rows.Add(row);
                dataGridViewX_Cat.PrimaryGrid.GetCell(i, 1).Value = ((LangArEn == 0) ? listDept[i].Arb_Des.ToString() : listDept[i].Eng_Des.ToString());
                dataGridViewX_Cat.PrimaryGrid.GetCell(i, 2).Value = listDept[i].CAT_ID.ToString();
            }
        }
        private string[] getCatNo()
        {
            string[] listSalse = new string[dataGridViewX_Cat.PrimaryGrid.Rows.Count];
            for (int i = 0; i < dataGridViewX_Cat.PrimaryGrid.Rows.Count; i++)
            {
                if (dataGridViewX_Cat.PrimaryGrid.GetCell(i, 0).Value.ToString() == "True")
                {
                    listSalse[i] = dataGridViewX_Cat.PrimaryGrid.GetCell(i, 2).Value.ToString();
                }
            }
            return listSalse;
        }
        private void button_Close_Click(object sender, EventArgs e)
        {
            vStsOp = false;
            Close();
        }
        private void FrmInvCat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                button_Close_Click(sender, e);
            }
        }
        private void FrmInvCat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void button_Save_Click(object sender, EventArgs e)
        {
            List_Cat = GetSqlWhere();
            vStsOp = true;
            Close();
        }
        private string GetSqlWhere()
        {
            string QStr = "";
            string tmpStr = "";
            string[] GetSql = getCatNo();
            for (int num2 = 0; num2 < GetSql.Length; num2++)
            {
                if (!string.IsNullOrEmpty(GetSql[num2]))
                {
                    tmpStr = ((!string.IsNullOrEmpty(tmpStr)) ? (tmpStr + " OR ") : (tmpStr + " AND ( "));
                    tmpStr = tmpStr + " ( ItmCat = " + GetSql[num2].Trim() + " ) ";
                }
            }
            QStr += ((tmpStr != "") ? (tmpStr + " )") : "");
            tmpStr = "";
            return QStr;
        }
    }
}
