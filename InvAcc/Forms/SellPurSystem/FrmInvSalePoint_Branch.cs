using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using ProShared.GeneralM;using ProShared;
using InvAcc.Properties;
using ProShared.Stock_Data;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmInvSalePoint_Branch : Form
    { void avs(int arln)

{ 
}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
        public class ColumnDictinary_POS
        {
            public string _Name = "";
            public string _Qty = "";
            public string _Unit = "";
            public string _Price = "";
            public ColumnDictinary_POS(string _name, string _qty, string _unit, string _price)
            {
                _Name = _name;
                _Qty = _qty;
                _Unit = _unit;
                _Price = _price;
            }
        }
        public Dictionary<int, ColumnDictinary_POS> columns_Names_visible_POS = new Dictionary<int, ColumnDictinary_POS>();
        private List<T_InfoTb> listInfotb = new List<T_InfoTb>();
        private T_InfoTb _Infotb = new T_InfoTb();
        private Stock_DataDataContext dbInstance;
        private int LangArEn = 0;
       // private IContainer components = null;
        private Panel panel1;
        private LabelX labelX1;
        public C1FlexGrid FlxInv;
        private Timer timer1;
        private Panel panel2;
        private PictureBox PicItemImg;
        private TextBoxX txtHeadingR2;
        private TextBoxX txtHeadingR1;
        private TextBoxX txtHeadingR4;
        private TextBoxX txtHeadingR3;
        private Panel panel3;
        private TextBoxX textBox_QtyTot;
        private TextBoxX textBox_TotPrice;
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
        public FrmInvSalePoint_Branch()
        {
            InitializeComponent();this.Load += langloads;
            try
            {
                listInfotb = db.StockInfoList();
                _Infotb = listInfotb[0];
            }
            catch
            {
            }
        }
        private void FrmInvSalePoint_Branch_Load(object sender, EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmInvSalePoint_Branch));
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
            BindData();
            base.WindowState = FormWindowState.Maximized;
        }
        public void _Process()
        {
            try
            {
                for (int i = 0; i < columns_Names_visible_POS.Count; i++)
                {
                    FlxInv.Rows.Add();
                    FlxInv.SetData(FlxInv.Rows.Count - 1, 1, columns_Names_visible_POS[columns_Names_visible_POS.Keys.ToList()[i]]._Name);
                    FlxInv.SetData(FlxInv.Rows.Count - 1, 2, columns_Names_visible_POS[columns_Names_visible_POS.Keys.ToList()[i]]._Qty);
                    FlxInv.SetData(FlxInv.Rows.Count - 1, 3, columns_Names_visible_POS[columns_Names_visible_POS.Keys.ToList()[i]]._Unit);
                    FlxInv.SetData(FlxInv.Rows.Count - 1, 4, columns_Names_visible_POS[columns_Names_visible_POS.Keys.ToList()[i]]._Price);
                }
            }
            catch
            {
            }
            GetInvTot();
        }
        private void BindData()
        {
            try
            {
                for (int iiCnt = 0; iiCnt < listInfotb.Count; iiCnt++)
                {
                    _Infotb = listInfotb[iiCnt];
                    if (LangArEn == 1)
                    {
                        if (txtHeadingR1.Tag.ToString() == _Infotb.fldFlag.ToString())
                        {
                            txtHeadingR1.Text = _Infotb.fldValue;
                        }
                        else if (txtHeadingR2.Tag.ToString() == _Infotb.fldFlag.ToString())
                        {
                            txtHeadingR2.Text = _Infotb.fldValue;
                        }
                        else if (txtHeadingR3.Tag.ToString() == _Infotb.fldFlag.ToString())
                        {
                            txtHeadingR3.Text = _Infotb.fldValue;
                        }
                        else if (txtHeadingR4.Tag.ToString() == _Infotb.fldFlag.ToString())
                        {
                            txtHeadingR4.Text = _Infotb.fldValue;
                        }
                    }
                    else if (txtHeadingR1.Tag.ToString() == _Infotb.fldFlag.ToString())
                    {
                        txtHeadingR1.Text = _Infotb.fldValue;
                    }
                    else if (txtHeadingR2.Tag.ToString() == _Infotb.fldFlag.ToString())
                    {
                        txtHeadingR2.Text = _Infotb.fldValue;
                    }
                    else if (txtHeadingR3.Tag.ToString() == _Infotb.fldFlag.ToString())
                    {
                        txtHeadingR3.Text = _Infotb.fldValue;
                    }
                    else if (txtHeadingR4.Tag.ToString() == _Infotb.fldFlag.ToString())
                    {
                        txtHeadingR4.Text = _Infotb.fldValue;
                    }
                }
                try
                {
                    Size newSize = new Size(245, 220);
                    if (db.SystemSettingStock().LogImg != null)
                    {
                        byte[] arr = db.SystemSettingStock().LogImg.ToArray();
                        MemoryStream stream = new MemoryStream(arr);
                        PicItemImg.Image = Image.FromStream(stream);
                    }
                    else
                    {
                        PicItemImg.Image = Resources.PROSOFTlogo_N;
                    }
                    Bitmap OriginalBM = new Bitmap(PicItemImg.Image, newSize);
                    PicItemImg.Image = OriginalBM;
                }
                catch
                {
                }
                Refresh();
            }
            catch
            {
            }
        }
        private void FlxInv_Resize(object sender, EventArgs e)
        {
            try
            {
                Screen screen = GetSecondaryScreen();
                FlxInv.Cols[1].Width = screen.Bounds.Width / 3 + 150;
                FlxInv.Cols[2].Width = screen.Bounds.Width / 9;
                FlxInv.Cols[3].Width = screen.Bounds.Width / 9;
            }
            catch
            {
            }
        }
        private void FlxInv_AfterRowColChange(object sender, RangeEventArgs e)
        {
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
            }
            catch
            {
            }
        }
        public Screen GetSecondaryScreen()
        {
            try
            {
                if (Screen.AllScreens.Length == 1)
                {
                    return null;
                }
                Screen[] allScreens = Screen.AllScreens;
                foreach (Screen screen in allScreens)
                {
                    if (!screen.Primary)
                    {
                        return screen;
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        private void FrmInvSalePoint_Branch_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
        private void GetInvTot()
        {
            try
            {
                double InvTot = 0.0;
                double InvQty = 0.0;
                for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
                {
                    try
                    {
                        InvTot += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 4)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 2))));
                        InvQty += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 2))));
                    }
                    catch
                    {
                    }
                }
                textBox_QtyTot.Text = VarGeneral.TString.TEmpty(Math.Round(InvQty, 2).ToString());
                textBox_TotPrice.Text = VarGeneral.TString.TEmpty(Math.Round(InvTot, 2).ToString());
            }
            catch
            {
                textBox_QtyTot.Text = "0";
                textBox_TotPrice.Text = "0";
            }
        }
    }
}
