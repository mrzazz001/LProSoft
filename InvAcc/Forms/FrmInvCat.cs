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
    public partial  class FrmInvCat : Form
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
#pragma warning disable CS0414 // The field 'FrmInvCat.FlagUpdate' is assigned but its value is never used
        private string FlagUpdate = "";
#pragma warning restore CS0414 // The field 'FrmInvCat.FlagUpdate' is assigned but its value is never used
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
#pragma warning disable CS0414 // The field 'FrmInvCat.ControlNo' is assigned but its value is never used
        private int ControlNo = 0;
#pragma warning restore CS0414 // The field 'FrmInvCat.ControlNo' is assigned but its value is never used
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
        public FrmInvCat()
        {
            InitializeComponent();this.Load += langloads;
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
