using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmInvDetNoteSrch : Form
    { void avs(int arln)

{ 
}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
        }
   
       // private IContainer components = null;
        private GroupPanel groupPanel_BoardNo;
        private ButtonX button_0;
        private ButtonX button_2;
        private ButtonX button_1;
        private ButtonX button_6;
        private ButtonX button_5;
        private ButtonX button_8;
        private ButtonX button_7;
        private ButtonX button_Bac;
        private ButtonX button_3;
        private ButtonX button_4;
        private ButtonX button_9;
        private Panel panel1;
        private SuperTabControl superTabControl_ItemsGrids;
        protected LabelItem labelItem2;
        protected ButtonItem btnPrevPage_Det;
        protected ButtonItem btnNxtPage_Det;
        private SuperGridControl dataGridView_ItemDet;
        private ButtonX button_Exit;
        private ButtonX button_Save;
        protected ButtonItem buttonItem_FrmNotes;
        public TextBoxX textbox_Detailes;
        private string vTot = "";
        private int PageSizeDet = 10;
        private int CurrentPageIndexItmDet = 1;
        private int TotalPageDet = 0;
        private int col_Det = 0;
        private int colW_Det = 0;
        private int row_Det = 0;
        private int rowH_Det = 0;
        public static int LangArEn = 0;
        public string Serach_No = "";
        private Stock_DataDataContext dbInstance;
        public string SerachNo
        {
            get
            {
                return Serach_No;
            }
            set
            {
                Serach_No = value;
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
        public FrmInvDetNoteSrch()
        {
            InitializeComponent();this.Load += langloads;
        }
        private void Frm_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                SerachNo = "";
                Close();
            }
        }
        private void FrmInvDetNoteSrch_Load(object sender, EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmInvDetNoteSrch));
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                Language.ChangeLanguage("ar-SA", this, resources);
                LangArEn = 0;
            }
            else
            {
                Language.ChangeLanguage("en", this, resources);
                LangArEn = 1;
                button_Save.Text = "OK";
                button_Exit.Text = "Close";
                button_Bac.Text = "Clear";
                btnPrevPage_Det.Text = "Previous";
                btnNxtPage_Det.Text = "Next";
            }
            ItemsDetSetting();
            base.ActiveControl = textbox_Detailes;
        }
        private void ItemsDetSetting()
        {
            dataGridView_ItemDet.PrimaryGrid.Rows.Clear();
            dataGridView_ItemDet.PrimaryGrid.Columns.Clear();
            col_Det = dataGridView_ItemDet.Width / 100;
            colW_Det = dataGridView_ItemDet.Width / col_Det;
            row_Det = dataGridView_ItemDet.Height / 43;
            rowH_Det = dataGridView_ItemDet.Height / row_Det;
            PageSizeDet = Math.Abs(col_Det * row_Det);
            try
            {
                for (int i = 0; i < col_Det; i++)
                {
                    GridColumn q = new GridColumn();
                    q.Width = colW_Det;
                    dataGridView_ItemDet.PrimaryGrid.Columns.Add(q);
                }
                for (int i = 0; i < row_Det; i++)
                {
                    GridRow c = new GridRow();
                    c.RowHeight = rowH_Det;
                    c.RowStyles.Default.Background.Color1 = Color.AliceBlue;
                    for (int j = 0; j < col_Det; j++)
                    {
                        c.Cells.Add(new GridCell(""));
                    }
                    dataGridView_ItemDet.PrimaryGrid.Rows.Add(c);
                }
            }
            catch
            {
            }
            FillItmesDet();
        }
        private void FillItmesDet()
        {
            List<T_InvDetNote> vItems = new List<T_InvDetNote>();
            Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
            vItems = dbc.T_InvDetNotes.OrderBy((T_InvDetNote t) => t.InvDetNote_No).ToList();
            if (vItems.Count <= 0)
            {
                ClearItemsDet();
                return;
            }
            CalculateTotalPagesItemDet(vItems);
            GetCurrentRecordsItemDet(1);
        }
        private void CalculateTotalPagesItemDet(List<T_InvDetNote> vItems)
        {
            try
            {
                int rowCount = vItems.ToList().Count;
                TotalPageDet = rowCount / PageSizeDet;
                if (rowCount % PageSizeDet > 0)
                {
                    TotalPageDet++;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("CalculateTotalPagesItemDet:", error, enable: true);
                if (TotalPageDet <= 0)
                {
                    TotalPageDet = 1;
                }
            }
        }
        private void GetCurrentRecordsItemDet(int page)
        {
            try
            {
                List<T_InvDetNote> dt = new List<T_InvDetNote>();
                if (page == 1)
                {
                    dt = db.ExecuteQuery<T_InvDetNote>("Select TOP " + PageSizeDet + " * from T_InvDetNote ORDER BY InvDetNote_No", new object[0]).ToList();
                }
                else
                {
                    int PreviouspageLimit = (page - 1) * PageSizeDet;
                    dt = db.ExecuteQuery<T_InvDetNote>("Select TOP " + PageSizeDet + " * from T_InvDetNote WHERE InvDetNote_No NOT IN (Select TOP " + PreviouspageLimit + " InvDetNote_No from T_InvDetNote ORDER BY InvDetNote_No)) ", new object[0]).ToList();
                }
                int iicnt = 0;
                foreach (GridRow rowCell in dataGridView_ItemDet.PrimaryGrid.Rows)
                {
                    foreach (GridCell cell in rowCell.Cells)
                    {
                        if (iicnt < dt.Count)
                        {
                            try
                            {
                                cell.Value = ((LangArEn == 0) ? dt[iicnt].Arb_Des : dt[iicnt].Eng_Des);
                                cell.Tag = dt[iicnt].InvDetNote_No;
                                cell.CellStyles.Default.AllowWrap = Tbool.True;
                                iicnt++;
                            }
                            catch
                            {
                                iicnt++;
                            }
                        }
                        else
                        {
                            cell.Value = "";
                        }
                    }
                }
            }
            catch
            {
            }
        }
        private void btnFirstPAge_Det_Click(object sender, EventArgs e)
        {
            CurrentPageIndexItmDet = 1;
            GetCurrentRecordsItemDet(CurrentPageIndexItmDet);
        }
        private void btnPrevPage_Det_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndexItmDet > 1)
            {
                CurrentPageIndexItmDet--;
                GetCurrentRecordsItemDet(CurrentPageIndexItmDet);
            }
        }
        private void btnNxtPage_Det_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndexItmDet < TotalPageDet)
            {
                CurrentPageIndexItmDet++;
                GetCurrentRecordsItemDet(CurrentPageIndexItmDet);
            }
        }
        private void btnLastPage_Det_Click(object sender, EventArgs e)
        {
            CurrentPageIndexItmDet = TotalPageDet;
            GetCurrentRecordsItemDet(CurrentPageIndexItmDet);
        }
        private void ClearItemsDet()
        {
            foreach (GridRow rowCell in dataGridView_ItemDet.PrimaryGrid.Rows)
            {
                foreach (GridCell cell in rowCell.Cells)
                {
                    cell.Value = "";
                    cell.Tag = "";
                }
            }
        }
        private void FrmInvDetNoteSrch_SizeChanged(object sender, EventArgs e)
        {
            ItemsDetSetting();
        }
        private void button_1_Click(object sender, EventArgs e)
        {
            vTot += 1;
            textbox_Detailes.Focus();
            try
            {
                textbox_Detailes.SelectionStart = textbox_Detailes.Text.Length;
                textbox_Detailes.SelectionLength = 0;
            }
            catch
            {
                textbox_Detailes.SelectionLength = 0;
            }
        }
        private void button_2_Click(object sender, EventArgs e)
        {
            vTot += 2;
            textbox_Detailes.Focus();
            try
            {
                textbox_Detailes.SelectionStart = textbox_Detailes.Text.Length;
                textbox_Detailes.SelectionLength = 0;
            }
            catch
            {
                textbox_Detailes.SelectionLength = 0;
            }
        }
        private void button_3_Click(object sender, EventArgs e)
        {
            vTot += 3;
            textbox_Detailes.Focus();
            try
            {
                textbox_Detailes.SelectionStart = textbox_Detailes.Text.Length;
                textbox_Detailes.SelectionLength = 0;
            }
            catch
            {
                textbox_Detailes.SelectionLength = 0;
            }
        }
        private void button_4_Click(object sender, EventArgs e)
        {
            vTot += 4;
            textbox_Detailes.Focus();
            try
            {
                textbox_Detailes.SelectionStart = textbox_Detailes.Text.Length;
                textbox_Detailes.SelectionLength = 0;
            }
            catch
            {
                textbox_Detailes.SelectionLength = 0;
            }
        }
        private void button_5_Click(object sender, EventArgs e)
        {
            vTot += 5;
            textbox_Detailes.Focus();
            try
            {
                textbox_Detailes.SelectionStart = textbox_Detailes.Text.Length;
                textbox_Detailes.SelectionLength = 0;
            }
            catch
            {
                textbox_Detailes.SelectionLength = 0;
            }
        }
        private void button_6_Click(object sender, EventArgs e)
        {
            vTot += 6;
            textbox_Detailes.Focus();
            try
            {
                textbox_Detailes.SelectionStart = textbox_Detailes.Text.Length;
                textbox_Detailes.SelectionLength = 0;
            }
            catch
            {
                textbox_Detailes.SelectionLength = 0;
            }
        }
        private void button_7_Click(object sender, EventArgs e)
        {
            vTot += 7;
            textbox_Detailes.Focus();
            try
            {
                textbox_Detailes.SelectionStart = textbox_Detailes.Text.Length;
                textbox_Detailes.SelectionLength = 0;
            }
            catch
            {
                textbox_Detailes.SelectionLength = 0;
            }
        }
        private void button_8_Click(object sender, EventArgs e)
        {
            vTot += 8;
            textbox_Detailes.Focus();
            try
            {
                textbox_Detailes.SelectionStart = textbox_Detailes.Text.Length;
                textbox_Detailes.SelectionLength = 0;
            }
            catch
            {
                textbox_Detailes.SelectionLength = 0;
            }
        }
        private void button_9_Click(object sender, EventArgs e)
        {
            vTot += 9;
            textbox_Detailes.Focus();
            try
            {
                textbox_Detailes.SelectionStart = textbox_Detailes.Text.Length;
                textbox_Detailes.SelectionLength = 0;
            }
            catch
            {
                textbox_Detailes.SelectionLength = 0;
            }
        }
        private void button_0_Click(object sender, EventArgs e)
        {
            vTot += 0;
            textbox_Detailes.Focus();
            try
            {
                textbox_Detailes.SelectionStart = textbox_Detailes.Text.Length;
                textbox_Detailes.SelectionLength = 0;
            }
            catch
            {
                textbox_Detailes.SelectionLength = 0;
            }
        }
        private void button_Bac_Click(object sender, EventArgs e)
        {
            textbox_Detailes.Text = "";
            vTot = "";
            textbox_Detailes.Focus();
            try
            {
                textbox_Detailes.SelectionStart = textbox_Detailes.Text.Length;
                textbox_Detailes.SelectionLength = 0;
            }
            catch
            {
                textbox_Detailes.SelectionLength = 0;
            }
        }
        private void button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                SerachNo = textbox_Detailes.Text;
                Close();
            }
            catch
            {
                SerachNo = "";
                Close();
            }
        }
        private void button_Exit_Click(object sender, EventArgs e)
        {
            SerachNo = "";
            Close();
        }
        private void textbox_Detailes_ButtonCustomClick(object sender, EventArgs e)
        {
            textbox_Detailes.Text = "";
        }
        private void dataGridView_ItemDet_CellClick(object sender, GridCellClickEventArgs e)
        {
            try
            {
                int eRow = e.GridCell.RowIndex;
                int eCol = e.GridCell.ColumnIndex;
                object q = dataGridView_ItemDet.PrimaryGrid.GetCell(eRow, eCol).Tag;
                if (string.IsNullOrEmpty(q.ToString()) || string.IsNullOrEmpty(dataGridView_ItemDet.PrimaryGrid.GetCell(eRow, eCol).Value.ToString()))
                {
                    return;
                }
                SerachNo = q.ToString();
                textbox_Detailes.Text += ((LangArEn != 0) ? (string.IsNullOrEmpty(textbox_Detailes.Text) ? (vTot + " " + db.StockInvDetNote(SerachNo).Eng_Des + " ") : (" + " + vTot + " " + db.StockInvDetNote(SerachNo).Eng_Des + " ")) : (string.IsNullOrEmpty(textbox_Detailes.Text) ? (vTot + " " + db.StockInvDetNote(SerachNo).Arb_Des + " ") : (" + " + vTot + " " + db.StockInvDetNote(SerachNo).Arb_Des + " ")));
            }
            catch
            {
                SerachNo = "";
            }
            vTot = "";
        }
        private void buttonItem_FrmNotes_Click(object sender, EventArgs e)
        {
            FrmInvDetNote frm = new FrmInvDetNote();
            frm.Tag = LangArEn;
            frm.TopMost = true;
            frm.ShowDialog();
            ItemsDetSetting();
        }
    }
}
