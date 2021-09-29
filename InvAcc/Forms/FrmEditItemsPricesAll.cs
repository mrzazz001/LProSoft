using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSLanguage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
//using Stock_Data;
namespace InvAcc.Forms
{
    public partial  class FrmEditItemsPricesAll : Form
    { void avs(int arln)

{ 
}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
        }
   
       // private IContainer components = null;
        private C1FlexGrid FlxItems;
        private ButtonX ButExit;
        private ButtonX ButOk;
        private Panel panel1;
        private TextBoxX txtSearch;
        private ButtonX button_Search;
        private GroupBox groupBox1;
        private RadioButton radBarcode5;
        private RadioButton radBarcode4;
        private RadioButton radBarcode3;
        private RadioButton radBarcode2;
        private RadioButton radBarcode1;
        private RadioButton radItmNo;
        private Rate_DataDataContext dbInstanceRate;
        private Stock_DataDataContext dbInstance;
        private int LangArEn = 0;
        private double c = 0.0;
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
        public FrmEditItemsPricesAll()
        {
            InitializeComponent();this.Load += langloads;
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
            {
                try
                {
                    FlxItems.Cols[6].Format = VarGeneral.DicimalNN;
                    FlxItems.Cols[8].Format = VarGeneral.DicimalNN;
                    FlxItems.Cols[10].Format = VarGeneral.DicimalNN;
                    FlxItems.Cols[12].Format = VarGeneral.DicimalNN;
                    FlxItems.Cols[14].Format = VarGeneral.DicimalNN;
                }
                catch
                {
                }
            }
        }
        private void ArbEng()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ButOk.Text = "تحــــديــث";
                ButExit.Text = "خـــروج";
                button_Search.Text = "بحـــث";
                FlxItems.Cols[2].Caption = "رقم الصنف";
                FlxItems.Cols[3].Caption = "إسم الصنــف";
                FlxItems.Cols[4].Caption = "تكلفة الصنف";
                FlxItems.Cols[5].Caption = "الوحدة 1";
                FlxItems.Cols[6].Caption = "سعر البيع";
                FlxItems.Cols[7].Caption = "الوحدة 2";
                FlxItems.Cols[8].Caption = "سعر البيع";
                FlxItems.Cols[9].Caption = "الوحدة 3";
                FlxItems.Cols[10].Caption = "سعر البيع";
                FlxItems.Cols[11].Caption = "الوحدة 4";
                FlxItems.Cols[12].Caption = "سعر البيع";
                FlxItems.Cols[13].Caption = "الوحدة 5";
                FlxItems.Cols[14].Caption = "سعر البيع";
                Text = "معالج تحديث اسعار البيع للأصناف";
            }
            else
            {
                ButOk.Text = "OK";
                ButExit.Text = "Exit";
                button_Search.Text = "Search";
                FlxItems.Cols[2].Caption = "Item No";
                FlxItems.Cols[3].Caption = "Item Name";
                FlxItems.Cols[4].Caption = "Item Cost";
                FlxItems.Cols[5].Caption = "Unit 1";
                FlxItems.Cols[6].Caption = "Sale Price";
                FlxItems.Cols[7].Caption = "Unit 2";
                FlxItems.Cols[8].Caption = "Sale Price";
                FlxItems.Cols[9].Caption = "Unit 3";
                FlxItems.Cols[10].Caption = "Sale Price";
                FlxItems.Cols[11].Caption = "Unit 4";
                FlxItems.Cols[12].Caption = "Sale Price";
                FlxItems.Cols[13].Caption = "Unit 5";
                FlxItems.Cols[14].Caption = "Sale Price";
                Text = "Edite Sale Prices Process";
            }
        }
        private void FrmEditItemsPricesAll_Load(object sender, EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmEditItemsPricesAll));
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
            ArbEng();
            List<T_Item> qkeys = db.FillItem_2("").ToList();
            try
            {
                qkeys = qkeys.OrderBy((T_Item c) => int.Parse(c.Itm_No)).ToList();
            }
            catch
            {
            }
            FlxItems.Rows.Count = qkeys.Count + 1;
            for (int i = 0; i < qkeys.Count; i++)
            {
                FlxItems.SetData(i + 1, 1, false);
                FlxItems.SetData(i + 1, 2, qkeys[i].Itm_No);
                FlxItems.SetData(i + 1, 3, (LangArEn == 0) ? qkeys[i].Arb_Des : qkeys[i].Eng_Des);
                FlxItems.SetData(i + 1, 4, qkeys[i].AvrageCost.Value);
                if (qkeys[i].Unit1.HasValue)
                {
                    FlxItems.SetData(i + 1, 5, (LangArEn == 0) ? qkeys[i].T_Unit.Arb_Des : qkeys[i].T_Unit.Eng_Des);
                    FlxItems.SetData(i + 1, 6, qkeys[i].UntPri1.Value);
                }
                else
                {
                    FlxItems.SetData(i + 1, 6, 0);
                }
                if (qkeys[i].Unit2.HasValue)
                {
                    FlxItems.SetData(i + 1, 7, (LangArEn == 0) ? qkeys[i].T_Unit1.Arb_Des : qkeys[i].T_Unit1.Eng_Des);
                    FlxItems.SetData(i + 1, 8, qkeys[i].UntPri2.Value);
                }
                else
                {
                    FlxItems.SetData(i + 1, 8, 0);
                }
                if (qkeys[i].Unit3.HasValue)
                {
                    FlxItems.SetData(i + 1, 9, (LangArEn == 0) ? qkeys[i].T_Unit2.Arb_Des : qkeys[i].T_Unit2.Eng_Des);
                    FlxItems.SetData(i + 1, 10, qkeys[i].UntPri3.Value);
                }
                else
                {
                    FlxItems.SetData(i + 1, 10, 0);
                }
                if (qkeys[i].Unit4.HasValue)
                {
                    FlxItems.SetData(i + 1, 11, (LangArEn == 0) ? qkeys[i].T_Unit3.Arb_Des : qkeys[i].T_Unit3.Eng_Des);
                    FlxItems.SetData(i + 1, 12, qkeys[i].UntPri4.Value);
                }
                else
                {
                    FlxItems.SetData(i + 1, 12, 0);
                }
                if (qkeys[i].Unit5.HasValue)
                {
                    FlxItems.SetData(i + 1, 13, (LangArEn == 0) ? qkeys[i].T_Unit4.Arb_Des : qkeys[i].T_Unit4.Eng_Des);
                    FlxItems.SetData(i + 1, 14, qkeys[i].UntPri5.Value);
                }
                else
                {
                    FlxItems.SetData(i + 1, 14, 0);
                }
            }
        }
        private void ButExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل أنت متاكد من تحديث اسعار الأصناف ؟ \n Are you sure to update the item prices ?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            for (int iiCnt = 1; iiCnt < FlxItems.Rows.Count; iiCnt++)
            {
                try
                {
                    if (Convert.ToBoolean(FlxItems.Rows[iiCnt][1].ToString()))
                    {
                        if (!string.IsNullOrEmpty(FlxItems.Rows[iiCnt][5].ToString()) && double.Parse(FlxItems.Rows[iiCnt][6].ToString()) > 0.0)
                        {
                            db.ExecuteCommand("UPDATE [dbo].[T_Items] SET [UntPri1] = " + double.Parse(FlxItems.Rows[iiCnt][6].ToString()) + " WHERE Itm_No = '" + FlxItems.Rows[iiCnt][2].ToString() + "'");
                        }
                        if (!string.IsNullOrEmpty(FlxItems.Rows[iiCnt][7].ToString()) && double.Parse(FlxItems.Rows[iiCnt][8].ToString()) > 0.0)
                        {
                            db.ExecuteCommand("UPDATE [dbo].[T_Items] SET [UntPri2] = " + double.Parse(FlxItems.Rows[iiCnt][8].ToString()) + " WHERE Itm_No = '" + FlxItems.Rows[iiCnt][2].ToString() + "'");
                        }
                        if (!string.IsNullOrEmpty(FlxItems.Rows[iiCnt][9].ToString()) && double.Parse(FlxItems.Rows[iiCnt][10].ToString()) > 0.0)
                        {
                            db.ExecuteCommand("UPDATE [dbo].[T_Items] SET [UntPri3] = " + double.Parse(FlxItems.Rows[iiCnt][10].ToString()) + " WHERE Itm_No = '" + FlxItems.Rows[iiCnt][2].ToString() + "'");
                        }
                        if (!string.IsNullOrEmpty(FlxItems.Rows[iiCnt][11].ToString()) && double.Parse(FlxItems.Rows[iiCnt][12].ToString()) > 0.0)
                        {
                            db.ExecuteCommand("UPDATE [dbo].[T_Items] SET [UntPri4] = " + double.Parse(FlxItems.Rows[iiCnt][12].ToString()) + " WHERE Itm_No = '" + FlxItems.Rows[iiCnt][2].ToString() + "'");
                        }
                        if (!string.IsNullOrEmpty(FlxItems.Rows[iiCnt][13].ToString()) && double.Parse(FlxItems.Rows[iiCnt][14].ToString()) > 0.0)
                        {
                            db.ExecuteCommand("UPDATE [dbo].[T_Items] SET [UntPri5] = " + double.Parse(FlxItems.Rows[iiCnt][14].ToString()) + " WHERE Itm_No = '" + FlxItems.Rows[iiCnt][2].ToString() + "'");
                        }
                    }
                }
                catch
                {
                }
            }
            Close();
        }
        private void FlxItems_BeforeEdit(object sender, RowColEventArgs e)
        {
            try
            {
                if (e.Col == 6 || e.Col == 8 || e.Col == 10 || e.Col == 12 || e.Col == 14)
                {
                    try
                    {
                        c = double.Parse(FlxItems.Rows[e.Row][e.Col].ToString());
                    }
                    catch
                    {
                        c = 0.0;
                    }
                }
            }
            catch
            {
            }
        }
        private void FlxItems_AfterEdit(object sender, RowColEventArgs e)
        {
            try
            {
                if ((e.Col == 6 || e.Col == 8 || e.Col == 10 || e.Col == 12 || e.Col == 14) && !Convert.ToBoolean(FlxItems.Rows[e.Row][1].ToString()))
                {
                    try
                    {
                        FlxItems.SetData(e.Row, e.Col, c);
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
        }
        private void FrmEditItemsPricesAll_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                ButOk_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void FrmEditItemsPricesAll_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void button_Search_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text;
            try
            {
                if (radItmNo.Checked)
                {
                    foreach (Row row in (IEnumerable)FlxItems.Rows)
                    {
                        if (FlxItems.GetData(row.Index, 2).ToString().StartsWith(searchValue))
                        {
                            try
                            {
                                FlxItems.Row = 0;
                                FlxItems.RowSel = 0;
                            }
                            catch
                            {
                            }
                            FlxItems.Row = row.Index;
                            FlxItems.RowSel = row.Index;
                            FlxItems.Col = 2;
                            FlxItems.ColSel = 2;
                            txtSearch.Text = "";
                            break;
                        }
                    }
                }
                else
                {
                    List<T_Item> q;
                    if (radBarcode1.Checked)
                    {
                        q = db.T_Items.Where((T_Item t) => t.BarCod1 == searchValue).ToList();
                        if (q.Count <= 0)
                        {
                            return;
                        }
                        searchValue = q.FirstOrDefault().Itm_No;
                        foreach (Row row in (IEnumerable)FlxItems.Rows)
                        {
                            if (FlxItems.GetData(row.Index, 2).ToString().StartsWith(searchValue))
                            {
                                try
                                {
                                    FlxItems.Row = 0;
                                    FlxItems.RowSel = 0;
                                }
                                catch
                                {
                                }
                                FlxItems.Row = row.Index;
                                FlxItems.RowSel = row.Index;
                                FlxItems.Col = 2;
                                FlxItems.ColSel = 2;
                                txtSearch.Text = "";
                                break;
                            }
                        }
                        return;
                    }
                    if (radBarcode2.Checked)
                    {
                        q = db.T_Items.Where((T_Item t) => t.BarCod2 == searchValue).ToList();
                        if (q.Count <= 0)
                        {
                            return;
                        }
                        searchValue = q.FirstOrDefault().Itm_No;
                        foreach (Row row in (IEnumerable)FlxItems.Rows)
                        {
                            if (FlxItems.GetData(row.Index, 2).ToString().StartsWith(searchValue))
                            {
                                try
                                {
                                    FlxItems.Row = 0;
                                    FlxItems.RowSel = 0;
                                }
                                catch
                                {
                                }
                                FlxItems.Row = row.Index;
                                FlxItems.RowSel = row.Index;
                                FlxItems.Col = 2;
                                FlxItems.ColSel = 2;
                                txtSearch.Text = "";
                                break;
                            }
                        }
                        return;
                    }
                    if (radBarcode3.Checked)
                    {
                        q = db.T_Items.Where((T_Item t) => t.BarCod3 == searchValue).ToList();
                        if (q.Count <= 0)
                        {
                            return;
                        }
                        searchValue = q.FirstOrDefault().Itm_No;
                        foreach (Row row in (IEnumerable)FlxItems.Rows)
                        {
                            if (FlxItems.GetData(row.Index, 2).ToString().StartsWith(searchValue))
                            {
                                try
                                {
                                    FlxItems.Row = 0;
                                    FlxItems.RowSel = 0;
                                }
                                catch
                                {
                                }
                                FlxItems.Row = row.Index;
                                FlxItems.RowSel = row.Index;
                                FlxItems.Col = 2;
                                FlxItems.ColSel = 2;
                                txtSearch.Text = "";
                                break;
                            }
                        }
                        return;
                    }
                    if (radBarcode4.Checked)
                    {
                        q = db.T_Items.Where((T_Item t) => t.BarCod4 == searchValue).ToList();
                        if (q.Count <= 0)
                        {
                            return;
                        }
                        searchValue = q.FirstOrDefault().Itm_No;
                        foreach (Row row in (IEnumerable)FlxItems.Rows)
                        {
                            if (FlxItems.GetData(row.Index, 2).ToString().StartsWith(searchValue))
                            {
                                try
                                {
                                    FlxItems.Row = 0;
                                    FlxItems.RowSel = 0;
                                }
                                catch
                                {
                                }
                                FlxItems.Row = row.Index;
                                FlxItems.RowSel = row.Index;
                                FlxItems.Col = 2;
                                FlxItems.ColSel = 2;
                                txtSearch.Text = "";
                                break;
                            }
                        }
                        return;
                    }
                    if (!radBarcode5.Checked)
                    {
                        return;
                    }
                    q = db.T_Items.Where((T_Item t) => t.BarCod5 == searchValue).ToList();
                    if (q.Count <= 0)
                    {
                        return;
                    }
                    searchValue = q.FirstOrDefault().Itm_No;
                    foreach (Row row in (IEnumerable)FlxItems.Rows)
                    {
                        if (FlxItems.GetData(row.Index, 2).ToString().StartsWith(searchValue))
                        {
                            try
                            {
                                FlxItems.Row = 0;
                                FlxItems.RowSel = 0;
                            }
                            catch
                            {
                            }
                            FlxItems.Row = row.Index;
                            FlxItems.RowSel = row.Index;
                            FlxItems.Col = 2;
                            FlxItems.ColSel = 2;
                            txtSearch.Text = "";
                            break;
                        }
                    }
                    return;
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
