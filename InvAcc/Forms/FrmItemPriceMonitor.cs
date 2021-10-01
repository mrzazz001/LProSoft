using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmItemPriceMonitor : Form
    { void avs(int arln)

{ 
 Text = "أسعار الأصنـــاف  |  Prices of items\r\n";this.Text=   (arln == 0 ? "  أسعار الأصنـــاف  |  Prices of items\r\n  " : "  Items Prices | Prices of items\r\n") ; Text = "صورة الصنف | Pic";this.Text=   (arln == 0 ? "  صورة الصنف | Pic  " : "  Category Picture | Pic") ; Text = "إسم الصنف  |  Item Name";this.Text=   (arln == 0 ? "  إسم الصنف  |  Item Name  " : "  class name | Item Name") ; Text = "0";this.Text=   (arln == 0 ? "  0  " : "  0") ; Text = "السعــــر  |  Price";this.Text=   (arln == 0 ? "  السعــــر  |  Price  " : "  Price | Price") ;}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
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
        private LabelX labelX1;
        private Timer timer1;
        private Panel panel1;
        internal Label labelPrice;
        internal Label label9;
        private TextBoxX textBox_Barcode;
        private PictureBox PicItemImg;
        internal Label textbox_Arb_Des;
        internal Label label2;
        internal Label textbox_Eng_Des;
        private LabelX labelX2;
        private ReflectionImage pictureBox_PicItem;
        private TextBox txtTel1;
        private TextBox txtAddr;
        private TextBox txtAct;
        private TextBox txtCompany;
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private T_Company _Company = new T_Company();
        private T_Item _Items = new T_Item();
        private List<T_Item> listItems = new List<T_Item>();
#pragma warning disable CS0414 // The field 'FrmItemPriceMonitor.DefPack' is assigned but its value is never used
        private int DefPack = 0;
#pragma warning restore CS0414 // The field 'FrmItemPriceMonitor.DefPack' is assigned but its value is never used
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
        public FrmItemPriceMonitor()
        {
            InitializeComponent();this.Load += langloads;
        }
        private void FrmItemPriceMonitor_Load(object sender, EventArgs e)
        {
            if (VarGeneral.Settings_Sys.LogImg != null)
            {
                byte[] arr = VarGeneral.Settings_Sys.LogImg.ToArray();
                MemoryStream stream = new MemoryStream(arr);
                PicItemImg.Image = Image.FromStream(stream);
            }
            try
            {
                _Company = db.StockCompanyList().FirstOrDefault();
                txtAct.Text = _Company.Active;
                txtAddr.Text = _Company.Adder;
                txtCompany.Text = _Company.CopNam;
                txtTel1.Text = _Company.Tel1;
            }
            catch
            {
            }
            base.ActiveControl = textBox_Barcode;
            textBox_Barcode.Focus();
        }
        private void textBox_Barcode_ButtonCustom2Click(object sender, EventArgs e)
        {
            textBox_Barcode.Text = "";
            textBox_Barcode.Focus();
        }
        private void textBox_Barcode_ButtonCustomClick(object sender, EventArgs e)
        {
            textBox_Barcode_Leave(sender, e);
        }
        private bool ChkBarCod(string BarCod)
        {
            DefPack = 0;
            labelPrice.Text = "0";
            textbox_Arb_Des.Text = "";
            textbox_Eng_Des.Text = "";
            pictureBox_PicItem.Image = null;
            T_Item _ItmBarCod = new T_Item();
            listItems = db.FillItemBarCode_2(BarCod).ToList();
            for (int iiCnt = 0; iiCnt < listItems.Count; iiCnt++)
            {
                _ItmBarCod = listItems[iiCnt];
                if (BarCod == _ItmBarCod.BarCod1)
                {
                    _Items = _ItmBarCod;
                    DefPack = 1;
                    labelPrice.Text = _Items.UntPri1.Value.ToString();
                    textbox_Arb_Des.Text = _Items.Arb_Des;
                    textbox_Eng_Des.Text = _Items.Eng_Des;
                    if (_Items.ItmImg != null)
                    {
                        byte[] arr = _Items.ItmImg.ToArray();
                        MemoryStream stream = new MemoryStream(arr);
                        pictureBox_PicItem.Image = Image.FromStream(stream);
                    }
                    else
                    {
                        pictureBox_PicItem.Image = null;
                    }
                    timer1.Start();
                    return true;
                }
                if (BarCod == _ItmBarCod.BarCod2)
                {
                    _Items = _ItmBarCod;
                    DefPack = 2;
                    labelPrice.Text = _Items.UntPri2.Value.ToString();
                    textbox_Arb_Des.Text = _Items.Arb_Des;
                    textbox_Eng_Des.Text = _Items.Eng_Des;
                    if (_Items.ItmImg != null)
                    {
                        byte[] arr = _Items.ItmImg.ToArray();
                        MemoryStream stream = new MemoryStream(arr);
                        pictureBox_PicItem.Image = Image.FromStream(stream);
                    }
                    else
                    {
                        pictureBox_PicItem.Image = null;
                    }
                    timer1.Start();
                    return true;
                }
                if (BarCod == _ItmBarCod.BarCod3)
                {
                    _Items = _ItmBarCod;
                    DefPack = 3;
                    labelPrice.Text = _Items.UntPri3.Value.ToString();
                    textbox_Arb_Des.Text = _Items.Arb_Des;
                    textbox_Eng_Des.Text = _Items.Eng_Des;
                    if (_Items.ItmImg != null)
                    {
                        byte[] arr = _Items.ItmImg.ToArray();
                        MemoryStream stream = new MemoryStream(arr);
                        pictureBox_PicItem.Image = Image.FromStream(stream);
                    }
                    else
                    {
                        pictureBox_PicItem.Image = null;
                    }
                    timer1.Start();
                    return true;
                }
                if (BarCod == _ItmBarCod.BarCod4)
                {
                    _Items = _ItmBarCod;
                    DefPack = 4;
                    labelPrice.Text = _Items.UntPri4.Value.ToString();
                    textbox_Arb_Des.Text = _Items.Arb_Des;
                    textbox_Eng_Des.Text = _Items.Eng_Des;
                    if (_Items.ItmImg != null)
                    {
                        byte[] arr = _Items.ItmImg.ToArray();
                        MemoryStream stream = new MemoryStream(arr);
                        pictureBox_PicItem.Image = Image.FromStream(stream);
                    }
                    else
                    {
                        pictureBox_PicItem.Image = null;
                    }
                    timer1.Start();
                    return true;
                }
                if (BarCod == _ItmBarCod.BarCod5)
                {
                    _Items = _ItmBarCod;
                    DefPack = 5;
                    labelPrice.Text = _Items.UntPri5.Value.ToString();
                    textbox_Arb_Des.Text = _Items.Arb_Des;
                    textbox_Eng_Des.Text = _Items.Eng_Des;
                    if (_Items.ItmImg != null)
                    {
                        byte[] arr = _Items.ItmImg.ToArray();
                        MemoryStream stream = new MemoryStream(arr);
                        pictureBox_PicItem.Image = Image.FromStream(stream);
                    }
                    else
                    {
                        pictureBox_PicItem.Image = null;
                    }
                    timer1.Start();
                    return true;
                }
            }
            return false;
        }
        private void textBox_Barcode_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Barcod = false;
                if (textBox_Barcode.Text != "" && textBox_Barcode.Text != null)
                {
                    Barcod = ChkBarCod(textBox_Barcode.Text);
                    if (!Barcod)
                    {
                        textBox_Barcode.Text = "";
                        textBox_Barcode.Focus();
                    }
                    else if (!Barcod)
                    {
                        textBox_Barcode.Text = "";
                        textBox_Barcode.Focus();
                    }
                    else
                    {
                        textBox_Barcode.Text = "";
                        textBox_Barcode.Focus();
                    }
                }
                else
                {
                    textBox_Barcode.Text = "";
                    textBox_Barcode.Focus();
                }
            }
            catch
            {
                textBox_Barcode.Text = "";
                textBox_Barcode.Focus();
            }
        }
        private void textBox_Barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                textBox_Barcode_Leave(sender, e);
            }
        }
        private void textBox_Barcode_TextChanged(object sender, EventArgs e)
        {
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            labelPrice.Text = "0";
            textbox_Arb_Des.Text = "";
            textbox_Eng_Des.Text = "";
            pictureBox_PicItem.Image = null;
            textBox_Barcode.Text = "";
            textBox_Barcode.Focus();
            timer1.Stop();
        }
    }
}
