using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using InvAcc.GeneralM;
using InvAcc.Properties;
using InvAcc.Stock_Data;
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
    public partial class FrmInvSalePoint_Branch : Form
    {
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
        private IContainer components = null;
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
            InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmInvSalePoint_Branch));
            FlxInv = new C1.Win.C1FlexGrid.C1FlexGrid();
            panel1 = new System.Windows.Forms.Panel();
            labelX1 = new DevComponents.DotNetBar.LabelX();
            panel2 = new System.Windows.Forms.Panel();
            PicItemImg = new System.Windows.Forms.PictureBox();
            txtHeadingR2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            txtHeadingR1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            txtHeadingR4 = new DevComponents.DotNetBar.Controls.TextBoxX();
            txtHeadingR3 = new DevComponents.DotNetBar.Controls.TextBoxX();
            timer1 = new System.Windows.Forms.Timer(components);
            panel3 = new System.Windows.Forms.Panel();
            textBox_TotPrice = new DevComponents.DotNetBar.Controls.TextBoxX();
            textBox_QtyTot = new DevComponents.DotNetBar.Controls.TextBoxX();
            ((System.ComponentModel.ISupportInitialize)FlxInv).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PicItemImg).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            FlxInv.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            FlxInv.AllowEditing = false;
            FlxInv.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
            FlxInv.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            FlxInv.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(FlxInv, "FlxInv");
            FlxInv.ExtendLastCol = true;
            FlxInv.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            FlxInv.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            FlxInv.Name = "FlxInv";
            FlxInv.Rows.Count = 1;
            FlxInv.Rows.DefaultSize = 21;
            FlxInv.Rows.MinSize = 33;
            FlxInv.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
            FlxInv.StyleInfo = resources.GetString("FlxInv.StyleInfo");
            FlxInv.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue;
            FlxInv.Resize += new System.EventHandler(FlxInv_Resize);
            FlxInv.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(FlxInv_AfterRowColChange);
            panel1.Controls.Add(labelX1);
            panel1.Controls.Add(panel2);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            labelX1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            labelX1.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Dot;
            labelX1.BackgroundStyle.BorderBottomWidth = 2;
            labelX1.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(255, 255, 255);
            labelX1.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Dot;
            labelX1.BackgroundStyle.BorderLeftWidth = 2;
            labelX1.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Dot;
            labelX1.BackgroundStyle.BorderRightWidth = 2;
            labelX1.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Dot;
            labelX1.BackgroundStyle.BorderTopWidth = 2;
            labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            resources.ApplyResources(labelX1, "labelX1");
            labelX1.ForeColor = System.Drawing.Color.DarkGray;
            labelX1.Name = "labelX1";
            labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro;
            labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            labelX1.TextOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            labelX1.VerticalTextTopUp = false;
            panel2.Controls.Add(PicItemImg);
            panel2.Controls.Add(txtHeadingR2);
            panel2.Controls.Add(txtHeadingR1);
            panel2.Controls.Add(txtHeadingR4);
            panel2.Controls.Add(txtHeadingR3);
            resources.ApplyResources(panel2, "panel2");
            panel2.Name = "panel2";
            PicItemImg.BackColor = System.Drawing.Color.Transparent;
            PicItemImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(PicItemImg, "PicItemImg");
            PicItemImg.Name = "PicItemImg";
            PicItemImg.TabStop = false;
            txtHeadingR2.BackColor = System.Drawing.Color.White;
            txtHeadingR2.Border.Class = "TextBoxBorder";
            txtHeadingR2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            resources.ApplyResources(txtHeadingR2, "txtHeadingR2");
            txtHeadingR2.ForeColor = System.Drawing.SystemColors.ControlText;
            txtHeadingR2.Name = "txtHeadingR2";
            txtHeadingR2.Tag = "rTrwes2";
            txtHeadingR1.BackColor = System.Drawing.Color.White;
            txtHeadingR1.Border.Class = "TextBoxBorder";
            txtHeadingR1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            resources.ApplyResources(txtHeadingR1, "txtHeadingR1");
            txtHeadingR1.ForeColor = System.Drawing.SystemColors.ControlText;
            txtHeadingR1.Name = "txtHeadingR1";
            txtHeadingR1.Tag = "rTrwes1";
            txtHeadingR4.BackColor = System.Drawing.Color.White;
            txtHeadingR4.Border.Class = "TextBoxBorder";
            txtHeadingR4.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            resources.ApplyResources(txtHeadingR4, "txtHeadingR4");
            txtHeadingR4.ForeColor = System.Drawing.SystemColors.ControlText;
            txtHeadingR4.Name = "txtHeadingR4";
            txtHeadingR4.Tag = "rTrwes4";
            txtHeadingR3.BackColor = System.Drawing.Color.White;
            txtHeadingR3.Border.Class = "TextBoxBorder";
            txtHeadingR3.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            resources.ApplyResources(txtHeadingR3, "txtHeadingR3");
            txtHeadingR3.ForeColor = System.Drawing.SystemColors.ControlText;
            txtHeadingR3.Name = "txtHeadingR3";
            txtHeadingR3.Tag = "rTrwes3";
            timer1.Interval = 10000000;
            timer1.Tick += new System.EventHandler(timer1_Tick);
            panel3.Controls.Add(textBox_TotPrice);
            panel3.Controls.Add(textBox_QtyTot);
            resources.ApplyResources(panel3, "panel3");
            panel3.Name = "panel3";
            textBox_TotPrice.Border.Class = "TextBoxBorder";
            textBox_TotPrice.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_TotPrice.ButtonCustom.Text = resources.GetString("textBox_TotPrice.ButtonCustom.Text");
            textBox_TotPrice.ButtonCustom.Visible = true;
            resources.ApplyResources(textBox_TotPrice, "textBox_TotPrice");
            textBox_TotPrice.ForeColor = System.Drawing.Color.Maroon;
            textBox_TotPrice.Name = "textBox_TotPrice";
            textBox_QtyTot.Border.Class = "TextBoxBorder";
            textBox_QtyTot.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_QtyTot.ButtonCustom.Text = resources.GetString("textBox_QtyTot.ButtonCustom.Text");
            textBox_QtyTot.ButtonCustom.Visible = true;
            resources.ApplyResources(textBox_QtyTot, "textBox_QtyTot");
            textBox_QtyTot.ForeColor = System.Drawing.Color.Maroon;
            textBox_QtyTot.Name = "textBox_QtyTot";
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            base.ControlBox = false;
            base.Controls.Add(FlxInv);
            base.Controls.Add(panel3);
            base.Controls.Add(panel1);
            ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.Name = "FrmInvSalePoint_Branch";
            VarGeneral.CurrentLang = "";
            base.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            base.Load += new System.EventHandler(FrmInvSalePoint_Branch_Load);
            base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(FrmInvSalePoint_Branch_FormClosed);
            ((System.ComponentModel.ISupportInitialize)FlxInv).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PicItemImg).EndInit();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
