using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Framework.UI;
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
    public partial  class FrmTransItmAcc : Form
    { void avs(int arln)

{ 
 groupBox_BranchFrom.Text=   (arln == 0 ? "  من فـــــــرع :  " : "  From branch:") ; groupBox_BranchTo.Text=   (arln == 0 ? "  نقل البيانات الى الفرع :  " : "  Transferring data to the branch:") ; groupBox_Choese.Text=   (arln == 0 ? "  خيارات النقل  " : "  Transportation options") ; chk1.Text=   (arln == 0 ? "  نقل الأصنـــــــاف  " : "  Transfer of items") ; chk2.Text=   (arln == 0 ? "  نقل كرت الحســــــابات  " : "  Account card transfer") ; ProgressBar1.Text=   (arln == 0 ? "  progressBarX1  " : "  progressBarX1") ; ButOk.Text=   (arln == 0 ? "  نقــــل  " : "  move") ; ButExit.Text=   (arln == 0 ? "  خـــروج  " : "  Close") ; Text = "نقل البيانات بين الفروع";this.Text=   (arln == 0 ? "  نقل البيانات بين الفروع  " : "  Transfer data between branches") ;}
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
        private Panel PanelSpecialContainer;
        public Softgroup.NetResize.NetResize netResize1;
        private RibbonBar ribbonBar1;
        private Panel panel1;
        private GroupBox groupBox_BranchFrom;
        private GroupBox groupBox_BranchTo;
        private GroupBox groupBox_Choese;
        private ComboBoxEx combobox_BranchFrom;
        private ComboBoxEx combobox_BranchTo;
        private CheckBoxX chk1;
        private CheckBoxX chk2;
        private ButtonX ButExit;
        private ButtonX ButOk;
        private TextBox textBox_Det;
        private ProgressBarX ProgressBar1;
        private int LangArEn = 0;
        private T_User _User = new T_User();
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
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
        public FrmTransItmAcc()
        {
            InitializeComponent();this.Load += langloads;
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmTransItmAcc));
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                Language.ChangeLanguage("ar-SA", this, resources);
                LangArEn = 0;
            }
            else if (VarGeneral.CurrentLang.ToString() == "1")
            {
                Language.ChangeLanguage("en", this, resources);
                LangArEn = 1;
            }
            FillCombo();
        }
        private void FrmTransItmAcc_Load(object sender, EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmTransItmAcc));
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
            if (VarGeneral.SSSTyp == 0)
            {
                chk1.Checked = true;
                chk2.Checked = false;
                groupBox_Choese.Visible = false;
                textBox_Det.Size = new Size(316, 184);
                textBox_Det.Location = new Point(10, 99);
            }
            else if (VarGeneral.SSSTyp == 1)
            {
                chk2.Checked = true;
                chk1.Checked = false;
                groupBox_Choese.Visible = false;
                textBox_Det.Size = new Size(316, 184);
                textBox_Det.Location = new Point(10, 99);
            }
            FillCombo();
        }
        private void FillCombo()
        {
            combobox_BranchFrom.DataSource = null;
            combobox_BranchTo.DataSource = null;
            List<T_Branch> qFrom = dbc.T_Branches.Where((T_Branch t) => t.Branch_no == VarGeneral.BranchNumber).ToList();
            combobox_BranchFrom.DataSource = qFrom;
            combobox_BranchFrom.DisplayMember = ((LangArEn == 0) ? "Branch_Name" : "Branch_NameE");
            combobox_BranchFrom.ValueMember = "Branch_no";
            List<T_Branch> qTo = dbc.T_Branches.Where((T_Branch t) => t.Branch_no != VarGeneral.BranchNumber).ToList();
            if (qTo.Count() > 0)
            {
                combobox_BranchTo.DataSource = qTo;
                combobox_BranchTo.DisplayMember = ((LangArEn == 0) ? "Branch_Name" : "Branch_NameE");
                combobox_BranchTo.ValueMember = "Branch_no";
            }
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                Text = "نقل البيانات بين الفروع";
            }
            else
            {
                Text = "Transfer Data Between Branches";
            }
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            try
            {
                int Cunit = 0;
                int CCat = 0;
                int CItm = 0;
                int CAccCat = 0;
                int CAccDef = 0;
                textBox_Det.Text = "";
                if (combobox_BranchTo.SelectedIndex == -1)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام العملية قبل تحديد الفرع المراد نقل البياناتا إليه" : "You can not complete the process before determining the branch to be data transfer him", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (!chk1.Checked && !chk2.Checked)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام العملية قبل تحديد خيار واحد على الأقل من خيارات النقل" : "You can not complete the process before determining the branch to be data transfer him", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                Stock_DataDataContext dbTran = new Stock_DataDataContext("Server=" + VarGeneral.gServerName + ";Database=" + VarGeneral.DBNo.Replace("DB", "") + "_" + combobox_BranchTo.SelectedValue.ToString() + ";UID=sa;PWD=" + VarGeneral.UsrPass);
                string xx = "Server=" + VarGeneral.gServerName + ";Database=" + VarGeneral.DBNo.Replace("DB", "") + "_" + combobox_BranchTo.SelectedValue.ToString() + ";UID=sa;PWD=" + VarGeneral.UsrPass;
                if (chk1.Checked)
                {
                    List<T_Unit> vUnit = db.FillUnit_2("").ToList();
                    if (vUnit.Count > 0)
                    {
                        ProgressBar1.Value = 0;
                        ProgressBar1.Maximum = vUnit.Count;
                        ProgressBar1.Minimum = 0;
                        ProgressBar1.Visible = true;
                        int m = 0;
                        while (true)
                        {
                            if (m >= vUnit.Count)
                            {
                                break;
                            }
                            List<T_Unit> q3 = dbTran.T_Units.Where((T_Unit t) => t.Unit_ID == vUnit[m].Unit_ID).ToList();
                            if (q3.Count == 0)
                            {
                                dbTran.ExecuteCommand("SET IDENTITY_INSERT [dbo].[T_Unit] ON\r\n                                                            INSERT [dbo].[T_Unit] ([Unit_ID], [Unit_No], [Arb_Des], [Eng_Des], [CompanyID]) VALUES (" + vUnit[m].Unit_ID + ", N'" + ((dbTran.StockUnit(vUnit[m].Unit_No) == null || dbTran.StockUnit(vUnit[m].Unit_No).Unit_ID == 0) ? vUnit[m].Unit_No : dbTran.MaxUnitNo.ToString()) + "', N'" + vUnit[m].Arb_Des + "', N'" + vUnit[m].Eng_Des + "', 1)\r\n                                                            SET IDENTITY_INSERT [dbo].[T_Unit] OFF");
                                Cunit++;
                                ProgressBar1.Value += 1;
                            }
                            m++;
                        }
                    }
                    ProgressBar1.Visible = false;
                    List<T_CATEGORY> vCat = db.FillCat_2("").ToList();
                    try
                    {
                        vCat = vCat.OrderBy((T_CATEGORY c) => int.Parse(c.CAT_No)).ToList();
                    }
                    catch
                    {
                    }
                    if (vCat.Count > 0)
                    {
                        ProgressBar1.Value = 0;
                        ProgressBar1.Maximum = vCat.Count;
                        ProgressBar1.Minimum = 0;
                        ProgressBar1.Visible = true;
                        int l = 0;
                        while (true)
                        {
                            if (l >= vCat.Count)
                            {
                                break;
                            }
                            List<T_CATEGORY> q4 = dbTran.T_CATEGORies.Where((T_CATEGORY t) => t.CAT_ID == vCat[l].CAT_ID).ToList();
                            if (q4.Count == 0)
                            {
                                dbTran.ExecuteCommand("SET IDENTITY_INSERT [dbo].[T_CATEGORY] ON\r\n                                                            INSERT [dbo].[T_CATEGORY] ([CAT_ID], [CAT_No], [Arb_Des], [Eng_Des], [CompanyID],[TotalPurchaes],[TotalPoint],[CAT_Symbol]) VALUES (" + vCat[l].CAT_ID + ", N'" + ((dbTran.StockCat(vCat[l].CAT_No) == null || dbTran.StockCat(vCat[l].CAT_No).CAT_ID == 0) ? vCat[l].CAT_No : dbTran.MaxCatNo.ToString()) + "', N'" + vCat[l].Arb_Des + "', N'" + vCat[l].Eng_Des + "', 1," + vCat[l].TotalPurchaes.Value + "," + vCat[l].TotalPoint.Value + ", N'" + vCat[l].CAT_Symbol + "')\r\n                                                            SET IDENTITY_INSERT [dbo].[T_CATEGORY] OFF");
                                int max = dbTran.MaxINVSETTING;
                                dbTran.ExecuteCommand("INSERT [dbo].[T_INVSETTING] ([InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines],[CatID],[PrintCat]) VALUES (" + max + ", N'" + vCat[l].Arb_Des + "', N'" + vCat[l].Eng_Des + "', N'212', N'1         ', N'نقدي                          ', N'آجل       ', NULL, NULL, NULL, N'Cash      ', N'Credit    ', NULL, NULL, NULL, -2147483633, 12640511, 0, N'العميل              ', NULL, NULL, NULL, NULL, N'Customer            ', NULL, NULL, NULL, NULL, N'3021001        ', N'1020001        ', NULL, NULL, NULL, NULL, NULL, N'3021005        ', N'***', N'3021005', N'1022001', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, N'Microsoft XPS Document Writer', N'110 ', N'1011 ', 1, 1,1," + vCat[l].CAT_ID + ",0)");
                                CCat++;
                                ProgressBar1.Value += 1;
                            }
                            l++;
                        }
                    }
                    ProgressBar1.Visible = false;
                    List<T_Item> vItems = db.FillItem_2("").ToList();
                    if (vItems.Count > 0)
                    {
                        ProgressBar1.Value = 0;
                        ProgressBar1.Maximum = vItems.Count;
                        ProgressBar1.Minimum = 0;
                        ProgressBar1.Visible = true;
                        int k;
                        for (k = 0; k < vItems.Count; k++)
                        {
                            try
                            {
                                List<T_Item> q5 = dbTran.T_Items.Where((T_Item t) => t.Itm_No == vItems[k].Itm_No).ToList();
                                if (q5.Count == 0)
                                {
                                    CItm++;
                                    T_Item vItm = new T_Item();
                                    vItm.Itm_No = vItems[k].Itm_No;
                                    if (vItems[k].ItmCat.HasValue)
                                    {
                                        vItm.ItmCat = vItems[k].ItmCat.Value;
                                    }
                                    vItm.Arb_Des = vItems[k].Arb_Des;
                                    vItm.Eng_Des = vItems[k].Eng_Des;
                                    if (vItems[k].DefultVendor.HasValue)
                                    {
                                        vItm.DefultVendor = vItems[k].DefultVendor.Value;
                                    }
                                    vItm.FirstCost = 0.0;
                                    vItm.StartCost = 0.0;
                                    vItm.AvrageCost = 0.0;
                                    vItm.LastCost = 0.0;
                                    vItm.OpenQty = 0.0;
                                    vItm.ItmLoc = vItems[k].ItmLoc;
                                    if (vItems[k].ItmTyp.HasValue)
                                    {
                                        vItm.ItmTyp = vItems[k].ItmTyp.Value;
                                    }
                                    if (vItems[k].QtyMax.HasValue)
                                    {
                                        vItm.QtyMax = vItems[k].QtyMax.Value;
                                    }
                                    if (vItems[k].QtyLvl.HasValue)
                                    {
                                        vItm.QtyLvl = vItems[k].QtyLvl.Value;
                                    }
                                    if (vItems[k].Lot.HasValue)
                                    {
                                        vItm.Lot = vItems[k].Lot.Value;
                                    }
                                    if (vItems[k].DMY.HasValue)
                                    {
                                        vItm.DMY = vItems[k].DMY.Value;
                                    }
                                    if (vItems[k].LrnExp.HasValue)
                                    {
                                        vItm.LrnExp = vItems[k].LrnExp.Value;
                                    }
                                    if (vItems[k].Unit1.HasValue)
                                    {
                                        vItm.Unit1 = vItems[k].Unit1.Value;
                                    }
                                    if (vItems[k].UntPri1.HasValue)
                                    {
                                        vItm.UntPri1 = vItems[k].UntPri1.Value;
                                    }
                                    if (vItems[k].Pack1.HasValue)
                                    {
                                        vItm.Pack1 = vItems[k].Pack1.Value;
                                    }
                                    if (vItems[k].Unit2.HasValue)
                                    {
                                        vItm.Unit2 = vItems[k].Unit2.Value;
                                    }
                                    if (vItems[k].UntPri2.HasValue)
                                    {
                                        vItm.UntPri2 = vItems[k].UntPri2.Value;
                                    }
                                    if (vItems[k].Pack2.HasValue)
                                    {
                                        vItm.Pack2 = vItems[k].Pack2.Value;
                                    }
                                    if (vItems[k].Unit3.HasValue)
                                    {
                                        vItm.Unit3 = vItems[k].Unit3.Value;
                                    }
                                    if (vItems[k].UntPri3.HasValue)
                                    {
                                        vItm.UntPri3 = vItems[k].UntPri3.Value;
                                    }
                                    if (vItems[k].Pack3.HasValue)
                                    {
                                        vItm.Pack3 = vItems[k].Pack3.Value;
                                    }
                                    if (vItems[k].Unit4.HasValue)
                                    {
                                        vItm.Unit4 = vItems[k].Unit4.Value;
                                    }
                                    if (vItems[k].UntPri4.HasValue)
                                    {
                                        vItm.UntPri4 = vItems[k].UntPri4.Value;
                                    }
                                    if (vItems[k].Pack4.HasValue)
                                    {
                                        vItm.Pack4 = vItems[k].Pack4.Value;
                                    }
                                    if (vItems[k].Unit5.HasValue)
                                    {
                                        vItm.Unit5 = vItems[k].Unit5.Value;
                                    }
                                    if (vItems[k].UntPri5.HasValue)
                                    {
                                        vItm.UntPri5 = vItems[k].UntPri5.Value;
                                    }
                                    if (vItems[k].Pack5.HasValue)
                                    {
                                        vItm.Pack5 = vItems[k].Pack5.Value;
                                    }
                                    if (vItems[k].DefPack.HasValue)
                                    {
                                        vItm.DefPack = vItems[k].DefPack.Value;
                                    }
                                    if (vItems[k].DefultUnit.HasValue)
                                    {
                                        vItm.DefultUnit = vItems[k].DefultUnit.Value;
                                    }
                                    if (vItems[k].Price1.HasValue)
                                    {
                                        vItm.Price1 = vItems[k].Price1;
                                    }
                                    if (vItems[k].Price2.HasValue)
                                    {
                                        vItm.Price2 = vItems[k].Price2;
                                    }
                                    if (vItems[k].Price3.HasValue)
                                    {
                                        vItm.Price3 = vItems[k].Price3;
                                    }
                                    if (vItems[k].Price4.HasValue)
                                    {
                                        vItm.Price4 = vItems[k].Price4;
                                    }
                                    if (vItems[k].Price5.HasValue)
                                    {
                                        vItm.Price5 = vItems[k].Price5;
                                    }
                                    vItm.BarCod1 = vItems[k].BarCod1 ?? "";
                                    vItm.BarCod2 = vItems[k].BarCod2 ?? "";
                                    vItm.BarCod3 = vItems[k].BarCod3 ?? "";
                                    vItm.BarCod4 = vItems[k].BarCod4 ?? "";
                                    vItm.BarCod5 = vItems[k].BarCod5 ?? "";
                                    vItm.ItemComm = vItems[k].ItemComm.Value;
                                    vItm.ItemDis = vItems[k].ItemDis.Value;
                                    vItm.TaxSales = vItems[k].TaxSales.Value;
                                    vItm.TaxPurchas = vItems[k].TaxPurchas.Value;
                                    if (vItems[k].InvSaleStoped.HasValue)
                                    {
                                        vItm.InvSaleStoped = vItems[k].InvSaleStoped.Value;
                                    }
                                    if (vItems[k].InvSaleReturnStoped.HasValue)
                                    {
                                        vItm.InvSaleReturnStoped = vItems[k].InvSaleReturnStoped.Value;
                                    }
                                    if (vItems[k].InvPaymentStoped.HasValue)
                                    {
                                        vItm.InvPaymentStoped = vItems[k].InvPaymentStoped.Value;
                                    }
                                    if (vItems[k].InvPaymentReturnStoped.HasValue)
                                    {
                                        vItm.InvPaymentReturnStoped = vItems[k].InvPaymentReturnStoped;
                                    }
                                    if (vItems[k].InvEnterStoped.HasValue)
                                    {
                                        vItm.InvEnterStoped = vItems[k].InvEnterStoped;
                                    }
                                    if (vItems[k].InvOutStoped.HasValue)
                                    {
                                        vItm.InvOutStoped = vItems[k].InvOutStoped;
                                    }
                                    if (vItems[k].IsBalance.HasValue)
                                    {
                                        vItm.IsBalance = vItems[k].IsBalance.Value;
                                    }
                                    if (vItems[k].IsPoints.HasValue)
                                    {
                                        vItm.IsPoints = vItems[k].IsPoints.Value;
                                    }
                                    if (vItems[k].ItmImg != null)
                                    {
                                        vItm.ItmImg = vItems[k].ItmImg;
                                    }
                                    try
                                    {
                                        vItm.SecriptCeramic = vItems[k].SecriptCeramic;
                                    }
                                    catch
                                    {
                                        vItm.SecriptCeramic = "";
                                    }
                                    try
                                    {
                                        vItm.SecriptCeramicCombo = vItems[k].SecriptCeramicCombo;
                                    }
                                    catch
                                    {
                                        vItm.SecriptCeramicCombo = "0";
                                    }
                                    try
                                    {
                                        vItm.vSize1 = vItems[k].vSize1;
                                        vItm.vSize2 = vItems[k].vSize2;
                                        vItm.vSize3 = vItems[k].vSize3;
                                        vItm.vSize4 = vItems[k].vSize4;
                                        vItm.vSize5 = vItems[k].vSize5;
                                        vItm.vSize6 = vItems[k].vSize6;
                                    }
                                    catch
                                    {
                                    }
                                    vItm.CompanyID = 1;
                                    dbTran.T_Items.InsertOnSubmit(vItm);
                                    dbTran.SubmitChanges();
                                    ProgressBar1.Value += 1;
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                    ProgressBar1.Visible = false;
                    try
                    {
                        textBox_Det.Text = textBox_Det.Text + Environment.NewLine + ((LangArEn == 0) ? (" تم عملية نقل " + Cunit + " وحدة الى كرت الوحدات ") : (" The transfer process " + Cunit + " Unit to the card units "));
                        textBox_Det.Text = textBox_Det.Text + Environment.NewLine + ((LangArEn == 0) ? (" تم عملية نقل " + CCat + " تصنيف الى كرت التصنيفات ") : (" The transfer process " + CCat + " Category to the card Categories "));
                        textBox_Det.Text = textBox_Det.Text + Environment.NewLine + ((LangArEn == 0) ? (" تم عملية نقل " + CItm + " صنف الى كرت الإصناف ") : (" The transfer process " + CItm + " Item to card items "));
                    }
                    catch
                    {
                        textBox_Det.Text = "";
                    }
                    textBox_Det.Text = textBox_Det.Text + Environment.NewLine + ((LangArEn == 0) ? " تمت عملية نقل بيانات الأ\u064bصناف بنجاح ... " : " Data items has successfully transfer process ... ") + Environment.NewLine;
                }
                if (!chk2.Checked)
                {
                    return;
                }
                List<T_AccCat> vAccCat = db.FillAccCat_2("").ToList();
                if (vAccCat.Count > 0)
                {
                    ProgressBar1.Value = 0;
                    ProgressBar1.Maximum = vAccCat.Count;
                    ProgressBar1.Minimum = 0;
                    ProgressBar1.Visible = true;
                    int j = 0;
                    while (true)
                    {
                        if (j >= vAccCat.Count)
                        {
                            break;
                        }
                        List<T_AccCat> q2 = dbTran.T_AccCats.Where((T_AccCat t) => t.AccCat_ID == vAccCat[j].AccCat_ID).ToList();
                        if (q2.Count == 0)
                        {
                            dbTran.ExecuteCommand("SET IDENTITY_INSERT [dbo].[T_AccCat] ON\r\n                                                            INSERT [dbo].[T_AccCat] ([AccCat_ID], [AccCat_No], [Arb_Des], [Eng_Des], [CompanyID]) VALUES (" + vAccCat[j].AccCat_ID + ", N'" + ((dbTran.StockAccCat(vAccCat[j].AccCat_No) == null || dbTran.StockAccCat(vAccCat[j].AccCat_No).AccCat_ID == 0) ? vAccCat[j].AccCat_No : dbTran.MaxAccCatNo.ToString()) + "', N'" + vAccCat[j].Arb_Des + "', N'" + vAccCat[j].Eng_Des + "', 1)\r\n                                                            SET IDENTITY_INSERT [dbo].[T_AccCat] OFF");
                            CAccCat++;
                            ProgressBar1.Value += 1;
                        }
                        j++;
                    }
                }
                ProgressBar1.Visible = false;
                List<T_AccDef> vAccDef = db.FillAccDef_2("").ToList();
                if (vAccDef.Count > 0)
                {
                    int i = 0;
                    while (true)
                    {
                        if (i >= vAccDef.Count)
                        {
                            break;
                        }
                        ProgressBar1.Value = 0;
                        ProgressBar1.Maximum = vAccDef.Count;
                        ProgressBar1.Minimum = 0;
                        ProgressBar1.Visible = true;
                        List<T_AccDef> q = dbTran.T_AccDefs.Where((T_AccDef t) => t.AccDef_No == vAccDef[i].AccDef_No).ToList();
                        if (q.Count == 0)
                        {
                            CAccDef++;
                            T_AccDef vAccDf = new T_AccDef();
                            vAccDf.AccDef_No = vAccDef[i].AccDef_No;
                            vAccDf.Arb_Des = vAccDef[i].Arb_Des;
                            vAccDf.Eng_Des = vAccDef[i].Eng_Des;
                            if (vAccDef[i].Lev.HasValue)
                            {
                                vAccDf.Lev = vAccDef[i].Lev.Value;
                            }
                            vAccDf.ParAcc = vAccDef[i].ParAcc;
                            if (vAccDef[i].AccCat.HasValue)
                            {
                                vAccDf.AccCat = vAccDef[i].AccCat.Value;
                            }
                            if (vAccDef[i].DC.HasValue)
                            {
                                vAccDf.DC = vAccDef[i].DC.Value;
                            }
                            if (vAccDef[i].Sts.HasValue)
                            {
                                vAccDf.Sts = vAccDef[i].Sts.Value;
                            }
                            if (vAccDef[i].MaxLemt.HasValue)
                            {
                                vAccDf.MaxLemt = vAccDef[i].MaxLemt.Value;
                            }
                            vAccDf.Credit = vAccDef[i].Credit;
                            vAccDf.Debit = vAccDef[i].Debit;
                            vAccDf.Balance = vAccDef[i].Balance;
                            vAccDf.Trn = vAccDef[i].Trn;
                            vAccDf.Typ = vAccDef[i].Typ;
                            vAccDf.City = vAccDef[i].City;
                            vAccDf.Email = vAccDef[i].Email;
                            vAccDf.Telphone1 = vAccDef[i].Telphone1;
                            vAccDf.Telphone2 = vAccDef[i].Telphone2;
                            vAccDf.Fax = vAccDef[i].Fax;
                            vAccDf.Mobile = vAccDef[i].Mobile;
                            vAccDf.DesPers = vAccDef[i].DesPers;
                            vAccDf.StrAm = vAccDef[i].StrAm;
                            vAccDf.Adders = vAccDef[i].Adders;
                            vAccDf.Mnd = vAccDef[i].Mnd;
                            vAccDf.Price = vAccDef[i].Price;
                            try
                            {
                                if (vAccDef[i].StopedState.HasValue)
                                {
                                    vAccDf.StopedState = vAccDef[i].StopedState.Value;
                                }
                                else
                                {
                                    vAccDf.StopedState = false;
                                }
                            }
                            catch
                            {
                                vAccDf.StopedState = false;
                            }
                            try
                            {
                                if (vAccDef[i].MainSal.HasValue)
                                {
                                    vAccDf.MainSal = vAccDef[i].MainSal.Value;
                                }
                                else
                                {
                                    vAccDf.MainSal = 0.0;
                                }
                            }
                            catch
                            {
                                vAccDf.MainSal = 0.0;
                            }
                            try
                            {
                                vAccDf.DepreciationPercent = vAccDef[i].DepreciationPercent;
                            }
                            catch
                            {
                                vAccDf.DepreciationPercent = 0.0;
                            }
                            try
                            {
                                vAccDf.MaxDisCust = vAccDef[i].MaxDisCust;
                            }
                            catch
                            {
                                vAccDf.MaxDisCust = 0.0;
                            }
                            try
                            {
                                vAccDf.vColStr1 = vAccDef[i].vColStr1;
                            }
                            catch
                            {
                                vAccDf.vColStr1 = "";
                            }
                            try
                            {
                                vAccDf.vColStr2 = vAccDef[i].vColStr2;
                            }
                            catch
                            {
                                vAccDf.vColStr2 = "";
                            }
                            try
                            {
                                vAccDf.vColStr3 = vAccDef[i].vColStr3;
                            }
                            catch
                            {
                                vAccDf.vColStr3 = "";
                            }
                            try
                            {
                                vAccDf.vColNum1 = vAccDef[i].vColNum1;
                            }
                            catch
                            {
                                vAccDf.vColNum1 = 0.0;
                            }
                            try
                            {
                                vAccDf.vColNum2 = vAccDef[i].vColNum2;
                            }
                            catch
                            {
                                vAccDf.vColNum2 = 0.0;
                            }
                            try
                            {
                                vAccDf.ProofAcc = vAccDef[i].ProofAcc;
                            }
                            catch
                            {
                                vAccDf.ProofAcc = "";
                            }
                            try
                            {
                                vAccDf.RelayAcc = vAccDef[i].RelayAcc;
                            }
                            catch
                            {
                                vAccDf.RelayAcc = "";
                            }
                            vAccDf.BankComm = vAccDef[i].BankComm;
                            vAccDf.TotPoints = vAccDef[i].TotPoints;
                            vAccDf.TaxNo = vAccDef[i].TaxNo;
                            vAccDf.CompanyID = 1;
                            dbTran.T_AccDefs.InsertOnSubmit(vAccDf);
                            dbTran.SubmitChanges();
                            ProgressBar1.Value += 1;
                        }
                        i++;
                    }
                }
                ProgressBar1.Visible = false;
                try
                {
                    textBox_Det.Text = textBox_Det.Text + Environment.NewLine + ((LangArEn == 0) ? (" تم عملية نقل " + CAccCat + " تصنيف حسابي الى كرت تصنيفات الحسابات ") : (" The transfer process " + CAccCat + " Record card to the classification of accounts "));
                    textBox_Det.Text = textBox_Det.Text + Environment.NewLine + ((LangArEn == 0) ? (" تم عملية نقل " + CAccDef + " حساب الى كرت الحسابات ") : (" The transfer process " + CAccDef + " Record to card accounts "));
                }
                catch
                {
                    textBox_Det.Text = "";
                }
                textBox_Det.Text = textBox_Det.Text + Environment.NewLine + ((LangArEn == 0) ? " تمت عملية نقل بيانات الحسابات بنجاح ... " : " It has accounts data transfer process successfully ... ") + Environment.NewLine;
            }
            catch (Exception error)
            {
                ProgressBar1.Visible = false;
                VarGeneral.DebLog.writeLog("ButOk_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void ButExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void FrmTransItmAcc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void FrmTransItmAcc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
    }
}
