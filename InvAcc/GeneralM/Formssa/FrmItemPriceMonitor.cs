using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmItemPriceMonitor : Form
    {
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
        private int DefPack = 0;
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmItemPriceMonitor));
            labelX1 = new DevComponents.DotNetBar.LabelX();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1 = new System.Windows.Forms.Panel();
            labelX2 = new DevComponents.DotNetBar.LabelX();
            pictureBox_PicItem = new DevComponents.DotNetBar.Controls.ReflectionImage();
            textbox_Eng_Des = new System.Windows.Forms.Label();
            textbox_Arb_Des = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            labelPrice = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            textBox_Barcode = new DevComponents.DotNetBar.Controls.TextBoxX();
            PicItemImg = new System.Windows.Forms.PictureBox();
            txtTel1 = new System.Windows.Forms.TextBox();
            txtAddr = new System.Windows.Forms.TextBox();
            txtAct = new System.Windows.Forms.TextBox();
            txtCompany = new System.Windows.Forms.TextBox();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();

            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PicItemImg).BeginInit();
            SuspendLayout();
            labelX1.BackColor = System.Drawing.Color.SteelBlue;
            labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX1.Dock = System.Windows.Forms.DockStyle.Top;
            labelX1.Font = new System.Drawing.Font("Tahoma", 11f, System.Drawing.FontStyle.Bold);
            labelX1.ForeColor = System.Drawing.Color.White;
            labelX1.Location = new System.Drawing.Point(0, 0);
            labelX1.Name = "labelX1";
            labelX1.Size = new System.Drawing.Size(636, 41);
            labelX1.TabIndex = 1201;
            labelX1.Text = "أسعار الأصنـــاف  |  Prices of items\r\n";
            labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            timer1.Enabled = true;
            timer1.Interval = 10000;
            timer1.Tick += new System.EventHandler(timer1_Tick);
            panel1.BackColor = System.Drawing.Color.SteelBlue;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(labelX2);
            panel1.Controls.Add(pictureBox_PicItem);
            panel1.Controls.Add(textbox_Eng_Des);
            panel1.Controls.Add(textbox_Arb_Des);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(labelPrice);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(textBox_Barcode);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 41);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(636, 155);
            panel1.TabIndex = 1203;
            labelX2.BackColor = System.Drawing.Color.Gainsboro;
            labelX2.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Dash;
            labelX2.BackgroundStyle.BorderBottomColor = System.Drawing.Color.SteelBlue;
            labelX2.BackgroundStyle.BorderBottomWidth = 1;
            labelX2.BackgroundStyle.BorderColor = System.Drawing.Color.SteelBlue;
            labelX2.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Dash;
            labelX2.BackgroundStyle.BorderLeftColor = System.Drawing.Color.SteelBlue;
            labelX2.BackgroundStyle.BorderLeftWidth = 1;
            labelX2.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Dash;
            labelX2.BackgroundStyle.BorderRightColor = System.Drawing.Color.SteelBlue;
            labelX2.BackgroundStyle.BorderRightWidth = 1;
            labelX2.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Dash;
            labelX2.BackgroundStyle.BorderTopColor = System.Drawing.Color.SteelBlue;
            labelX2.BackgroundStyle.BorderTopWidth = 1;
            labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX2.Font = new System.Drawing.Font("Tahoma", 8f);
            labelX2.ForeColor = System.Drawing.Color.Red;
            labelX2.Location = new System.Drawing.Point(4, 123);
            labelX2.Name = "labelX2";
            labelX2.Size = new System.Drawing.Size(129, 19);
            labelX2.Symbol = "\uf03e";
            labelX2.SymbolColor = System.Drawing.Color.SteelBlue;
            labelX2.SymbolSize = 12f;
            labelX2.TabIndex = 1592;
            labelX2.Text = "صورة الصنف | Pic";
            labelX2.TextAlignment = System.Drawing.StringAlignment.Center;
            pictureBox_PicItem.BackColor = System.Drawing.Color.Gainsboro;
            pictureBox_PicItem.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Dash;
            pictureBox_PicItem.BackgroundStyle.BorderBottomColor = System.Drawing.Color.SteelBlue;
            pictureBox_PicItem.BackgroundStyle.BorderBottomWidth = 1;
            pictureBox_PicItem.BackgroundStyle.BorderColor = System.Drawing.Color.SteelBlue;
            pictureBox_PicItem.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Dash;
            pictureBox_PicItem.BackgroundStyle.BorderLeftColor = System.Drawing.Color.SteelBlue;
            pictureBox_PicItem.BackgroundStyle.BorderLeftWidth = 1;
            pictureBox_PicItem.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Dash;
            pictureBox_PicItem.BackgroundStyle.BorderRightWidth = 1;
            pictureBox_PicItem.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Dash;
            pictureBox_PicItem.BackgroundStyle.BorderTopColor = System.Drawing.Color.SteelBlue;
            pictureBox_PicItem.BackgroundStyle.BorderTopWidth = 1;
            pictureBox_PicItem.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            pictureBox_PicItem.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            pictureBox_PicItem.Location = new System.Drawing.Point(4, 3);
            pictureBox_PicItem.Name = "pictureBox_PicItem";
            pictureBox_PicItem.Size = new System.Drawing.Size(128, 119);
            pictureBox_PicItem.TabIndex = 1593;
            textbox_Eng_Des.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textbox_Eng_Des.BackColor = System.Drawing.Color.Yellow;
            textbox_Eng_Des.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textbox_Eng_Des.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
            textbox_Eng_Des.ForeColor = System.Drawing.Color.Navy;
            textbox_Eng_Des.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            textbox_Eng_Des.Location = new System.Drawing.Point(134, 77);
            textbox_Eng_Des.Name = "textbox_Eng_Des";
            textbox_Eng_Des.RightToLeft = System.Windows.Forms.RightToLeft.No;
            textbox_Eng_Des.Size = new System.Drawing.Size(315, 32);
            textbox_Eng_Des.TabIndex = 1206;
            textbox_Eng_Des.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textbox_Arb_Des.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textbox_Arb_Des.BackColor = System.Drawing.Color.Yellow;
            textbox_Arb_Des.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textbox_Arb_Des.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
            textbox_Arb_Des.ForeColor = System.Drawing.Color.Navy;
            textbox_Arb_Des.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            textbox_Arb_Des.Location = new System.Drawing.Point(134, 44);
            textbox_Arb_Des.Name = "textbox_Arb_Des";
            textbox_Arb_Des.RightToLeft = System.Windows.Forms.RightToLeft.No;
            textbox_Arb_Des.Size = new System.Drawing.Size(315, 32);
            textbox_Arb_Des.TabIndex = 1205;
            textbox_Arb_Des.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label2.BackColor = System.Drawing.Color.Gainsboro;
            label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label2.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Bold);
            label2.ForeColor = System.Drawing.Color.Navy;
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(450, 44);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(181, 65);
            label2.TabIndex = 1204;
            label2.Text = "إسم الصنف  |  Item Name";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            labelPrice.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            labelPrice.BackColor = System.Drawing.Color.Yellow;
            labelPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            labelPrice.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
            labelPrice.ForeColor = System.Drawing.Color.Navy;
            labelPrice.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            labelPrice.Location = new System.Drawing.Point(134, 110);
            labelPrice.Name = "labelPrice";
            labelPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            labelPrice.Size = new System.Drawing.Size(315, 32);
            labelPrice.TabIndex = 1203;
            labelPrice.Text = "0";
            labelPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label9.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label9.BackColor = System.Drawing.Color.Gainsboro;
            label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label9.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Bold);
            label9.ForeColor = System.Drawing.Color.Navy;
            label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label9.Location = new System.Drawing.Point(450, 110);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(181, 32);
            label9.TabIndex = 1202;
            label9.Text = "السعــــر  |  Price";
            label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBox_Barcode.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox_Barcode.BackColor = System.Drawing.Color.Red;
            textBox_Barcode.Border.Class = "TextBoxBorder";
            textBox_Barcode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_Barcode.ButtonCustom.Image = (System.Drawing.Image)resources.GetObject("textBox_Barcode.ButtonCustom.Image");
            textBox_Barcode.ButtonCustom.Visible = true;
            textBox_Barcode.ButtonCustom2.Image = (System.Drawing.Image)resources.GetObject("textBox_Barcode.ButtonCustom2.Image");
            textBox_Barcode.Font = new System.Drawing.Font("Tahoma", 11f, System.Drawing.FontStyle.Bold);
            textBox_Barcode.ForeColor = System.Drawing.Color.Black;
            textBox_Barcode.Location = new System.Drawing.Point(134, 5);
            textBox_Barcode.Name = "textBox_Barcode";
            textBox_Barcode.Size = new System.Drawing.Size(497, 38);
            textBox_Barcode.TabIndex = 1;
            textBox_Barcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox_Barcode.WatermarkColor = System.Drawing.Color.White;
            textBox_Barcode.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            textBox_Barcode.WatermarkText = "رقم الباركود  -  Barcode No";
            textBox_Barcode.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_Barcode_KeyDown);
            textBox_Barcode.ButtonCustom2Click += new System.EventHandler(textBox_Barcode_ButtonCustom2Click);
            textBox_Barcode.ButtonCustomClick += new System.EventHandler(textBox_Barcode_ButtonCustomClick);
            PicItemImg.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            PicItemImg.BackColor = System.Drawing.Color.Transparent;
            PicItemImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            PicItemImg.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            PicItemImg.Location = new System.Drawing.Point(503, 213);
            PicItemImg.Name = "PicItemImg";
            PicItemImg.Size = new System.Drawing.Size(134, 120);
            PicItemImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            PicItemImg.TabIndex = 1204;
            PicItemImg.TabStop = false;
            txtTel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtTel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtTel1.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold);
            txtTel1.Location = new System.Drawing.Point(4, 305);
            txtTel1.MaxLength = 20;
            txtTel1.Name = "txtTel1";
            txtTel1.ReadOnly = true;
            txtTel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            txtTel1.Size = new System.Drawing.Size(497, 27);
            txtTel1.TabIndex = 1208;
            txtTel1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            txtAddr.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtAddr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtAddr.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold);
            txtAddr.Location = new System.Drawing.Point(4, 275);
            txtAddr.MaxLength = 50;
            txtAddr.Name = "txtAddr";
            txtAddr.ReadOnly = true;
            txtAddr.Size = new System.Drawing.Size(497, 27);
            txtAddr.TabIndex = 1207;
            txtAddr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            txtAct.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtAct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtAct.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold);
            txtAct.Location = new System.Drawing.Point(4, 245);
            txtAct.MaxLength = 20;
            txtAct.Name = "txtAct";
            txtAct.ReadOnly = true;
            txtAct.Size = new System.Drawing.Size(497, 27);
            txtAct.TabIndex = 1206;
            txtAct.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            txtCompany.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtCompany.BackColor = System.Drawing.Color.White;
            txtCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtCompany.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold);
            txtCompany.Location = new System.Drawing.Point(4, 215);
            txtCompany.MaxLength = 50;
            txtCompany.Name = "txtCompany";
            txtCompany.ReadOnly = true;
            txtCompany.Size = new System.Drawing.Size(497, 27);
            txtCompany.TabIndex = 1205;
            txtCompany.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Silver;
            base.ClientSize = new System.Drawing.Size(636, 339);
            base.ControlBox = false;
            base.Controls.Add(txtTel1);
            base.Controls.Add(txtAddr);
            base.Controls.Add(txtAct);
            base.Controls.Add(txtCompany);
            base.Controls.Add(PicItemImg);
            base.Controls.Add(panel1);
            base.Controls.Add(labelX1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FrmItemPriceMonitor";
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            base.ShowIcon = false;
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            base.Load += new System.EventHandler(FrmItemPriceMonitor_Load);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PicItemImg).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        public FrmItemPriceMonitor()
        {
            InitializeComponent();
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
