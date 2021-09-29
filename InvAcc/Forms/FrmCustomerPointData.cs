using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Library.RepShow;
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
    public partial  class FrmCustomerPointData : Form
    { void avs(int arln)

{ 
 buttonX_RepPointAll.Text=   (arln == 0 ? "  تقرير بإجمالي النقاط المستحقة والمرتجعة حسب كل فاتورة  " : "  Report of the total points due and returned according to each invoice") ; button_ItemMovementPoint.Text=   (arln == 0 ? "  تقرير تفصـــيلي بالنقاط المستحقة حسب حركة الأصناف  " : "  Detailed report of the points due according to the movement of items") ; buttonX_Close.Text=   (arln == 0 ? "  إغلاق  " : "  Close") ; buttonX_Ok.Text=   (arln == 0 ? "  موافــــق  " : "  ok") ; label11.Text=   (arln == 0 ? "  نقطــــة  " : "  point") ; label12.Text=   (arln == 0 ? "  إجمالي النقاط المرتجعــــة  " : "  Total points returned") ; lablCurr2.Text=   (arln == 0 ? "  ريــال  " : "  SAR") ; label8.Text=   (arln == 0 ? "  نقطــــة  " : "  point") ; label7.Text=   (arln == 0 ? "  نقطــــة  " : "  point") ; label6.Text=   (arln == 0 ? "  نقطــــة  " : "  point") ; lablCurr.Text=   (arln == 0 ? "  ريــال  " : "  SAR") ; label10.Text=   (arln == 0 ? "  " : "  ") ; lablPoint.Text=   (arln == 0 ? "  نقطــــة  " : "  point") ; label9.Text=   (arln == 0 ? "  " : "  ") ; label5.Text=   (arln == 0 ? "  قيمة خصم النقاط  " : "  Point discount value قيمة") ; Label26.Text=   (arln == 0 ? "  صافي الفاتورة  " : "  net invoice") ; label3.Text=   (arln == 0 ? "  إجمالي النقاط المتبقية  " : "  Total points remaining إجمالي") ; label2.Text=   (arln == 0 ? "  إجمالي النقاط المستخدمة  " : "  Total points used") ; label1.Text=   (arln == 0 ? "  إجمالي النقاط المستحقة  " : "  Total points earned") ; label4.Text=   (arln == 0 ? "  حساب العميــل  " : "  customer account") ; labelHeader.Text=   (arln == 0 ? "  بيانات نقاط عميل  " : "  Customer score data") ; line1.Text=   (arln == 0 ? "  line1  " : "  line1") ; label13.Text=   (arln == 0 ? "  نقطــــة  " : "  point") ; label14.Text=   (arln == 0 ? "  رصيد سابق للنقاط  " : "  Previous balance of points") ;}
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
            panel1.BringToFront();
        }
        private void FrmInvSale_SizeChanged(object sender, EventArgs e)
        {
            netResize1.Refresh();
        }
        public Softgroup.NetResize.NetResize netResize1;
        public TextBox txtCustNo;
        public TextBox txtCustName;
        public Panel panel1;
        public LabelX labelHeader;
        public ButtonX buttonX_Close;
        public ButtonX buttonX_Ok;
        public Label label4;
        public Label label1;
        public DoubleInput txtTotalPointAvalible;
        public Label label3;
        public DoubleInput txtTotalPointUsed;
        public Label label2;
        public DoubleInput txtTotalPointAll;
        public Label Label26;
        public DoubleInput txtDueAmountLoc;
        public Label label5;
        public DoubleInput txtDiscoundPointsValue;
        public Label lablPoint;
        public DoubleInput txtDiscoundPoints;
        public Label label9;
        public Line line1;
        public Label lablCurr;
        public DoubleInput txtTotalPointAvalibleValue;
        public Label label10;
        public Label label8;
        public Label label7;
        public Label label6;
        public Label lablCurr2;
        public Label label11;
        public DoubleInput txtTotalPointReturn;
        public Label label12;
        private ButtonX button_SrchCustNo;
        public ButtonX button_ItemMovementPoint;
        public Label label13;
        public DoubleInput txtTotalPointsOld;
        public Label label14;
        public ButtonX buttonX_RepPointAll;
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private int LangArEn = 0;
        public bool IsDone = false;
        private Stock_DataDataContext dbInstance;
        private bool Rep_ = false;
        private bool IsEdit_ = false;
        private int InvID_ = 0;
        private double DiscoundPointsVal_ = 0.0;
        public double totPointsIn = 0.0;
        public double totPointsOut = 0.0;
        public double totPoints = 0.0;
        public double _PointUseIn = 0.0;
        public double _PointUseOut = 0.0;
        public double totPointUse = 0.0;
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
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
        public FrmCustomerPointData(bool Rep, bool IsEdit, int InvID, double DiscoundPointsVal)
        {
            InitializeComponent();this.Load += langloads;
            IsEdit_ = IsEdit;
            InvID_ = InvID;
            DiscoundPointsVal_ = DiscoundPointsVal;
            Rep_ = Rep;
        }
        private void FrmCustomerPointData_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmCustomerPointData));
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
                RibunButtons();
                if (Rep_)
                {
                    button_SrchCustNo.Visible = true;
                    button_ItemMovementPoint.Visible = true;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        buttonX_Close.Size = new Size(203, 112);
                        buttonX_Close.Location = new Point(6, 203);
                    }
                    else
                    {
                        buttonX_Close.Size = new Size(203, 108);
                        buttonX_Close.Location = new Point(211, 204);
                        Label26.Visible = false;
                        txtDueAmountLoc.Visible = false;
                    }
                }
                MainProcess();
                button_ItemMovementPoint_VisibleChanged(sender, e);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void MainProcess()
        {
            if (!string.IsNullOrEmpty(txtCustNo.Text))
            {
                totPointsIn = 0.0;
                totPointsOut = 0.0;
                totPoints = 0.0;
                _PointUseIn = 0.0;
                _PointUseOut = 0.0;
                totPointUse = 0.0;
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                _RepShow.Rule = " Where T_Items.IsPoints = 1 and T_INVHED.InvTyp = 1  and  T_INVHED.IfDel != 1 and T_INVHED.IsPoints = 1 and CusVenNo = '" + txtCustNo.Text + "' and T_CATEGORY.TotalPurchaes > 0 and T_CATEGORY.TotalPoint > 0 " + (IsEdit_ ? (" and InvHed_ID != " + InvID_) : " ") + " group by T_items.ItmCat";
                _RepShow.Fields = " sum (Round(T_InvDet.Amount,2)) as Amount,T_items.ItmCat ,case when  CONVERT(INT,(sum(Round(T_InvDet.Amount,2)) / (select T_CATEGORY.TotalPurchaes from T_CATEGORY where T_CATEGORY.CAT_ID = T_items.ItmCat))) * (select T_CATEGORY.TotalPoint from T_CATEGORY where T_CATEGORY.CAT_ID = T_items.ItmCat) > 0 then  CONVERT(INT,(sum(Round(T_InvDet.Amount,2)) / (select T_CATEGORY.TotalPurchaes from T_CATEGORY where T_CATEGORY.CAT_ID = T_items.ItmCat))) * (select T_CATEGORY.TotalPoint from T_CATEGORY where T_CATEGORY.CAT_ID = T_items.ItmCat) else 0 end as PointsCount ";
                try
                {
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.Message);
                }
                try
                {
                    double t_ = (totPointsIn = db.StockAccDefWithOutBalance(txtCustNo.Text).TotPoints.Value);
                    txtTotalPointsOld.Value = t_;
                }
                catch
                {
                    totPointsIn = 0.0;
                    txtTotalPointsOld.Value = 0.0;
                }
                if (VarGeneral.RepData.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
                    {
                        try
                        {
                            if (double.Parse(VarGeneral.TString.TEmpty(VarGeneral.RepData.Tables[0].Rows[i][0].ToString())) > 0.0)
                            {
                                totPointsIn += double.Parse(VarGeneral.TString.TEmpty(VarGeneral.RepData.Tables[0].Rows[i][2].ToString()));
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                totPoints = totPointsIn - totPointsOut;
                if (totPoints > 0.0)
                {
                    txtTotalPointAll.Value = totPoints;
                    if (VarGeneral.InvTyp == 1 || Rep_)
                    {
                        txtTotalPointAvalibleValue.Value = totPoints * VarGeneral.Settings_Sys.PointOfRyal.Value;
                    }
                }
                List<T_INVHED> _in = db.T_INVHEDs.Where((T_INVHED t) => t.InvTyp == (int?)1 && t.IfDel != (int?)1 && t.IsPoints.Value && (IsEdit_ ? (t.InvHed_ID != InvID_) : true) && t.CusVenNo == txtCustNo.Text).ToList();
                _RepShow = new RepShow();
                _RepShow.Tables = " T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                _RepShow.Rule = " Where T_Items.IsPoints = 1 and T_INVHED.InvTyp = 3  and  T_INVHED.IfDel != 1 and T_INVHED.IsPoints = 1 and CusVenNo = '" + txtCustNo.Text + "' and T_CATEGORY.TotalPurchaes > 0 and T_CATEGORY.TotalPoint > 0 " + (IsEdit_ ? (" and InvHed_ID != " + InvID_) : " ") + " group by T_items.ItmCat";
                _RepShow.Fields = " sum (Round(T_InvDet.Amount,2)) as Amount,T_items.ItmCat ,case when  CONVERT(INT,(sum(Round(T_InvDet.Amount,2)) / (select T_CATEGORY.TotalPurchaes from T_CATEGORY where T_CATEGORY.CAT_ID = T_items.ItmCat))) * (select T_CATEGORY.TotalPoint from T_CATEGORY where T_CATEGORY.CAT_ID = T_items.ItmCat) > 0 then  CONVERT(INT,(sum(Round(T_InvDet.Amount,2)) / (select T_CATEGORY.TotalPurchaes from T_CATEGORY where T_CATEGORY.CAT_ID = T_items.ItmCat))) * (select T_CATEGORY.TotalPoint from T_CATEGORY where T_CATEGORY.CAT_ID = T_items.ItmCat) else 0 end as PointsCount ";
                try
                {
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.Message);
                }
                if (VarGeneral.RepData.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
                    {
                        try
                        {
                            if (double.Parse(VarGeneral.TString.TEmpty(VarGeneral.RepData.Tables[0].Rows[i][0].ToString())) > 0.0)
                            {
                                _PointUseOut += double.Parse(VarGeneral.TString.TEmpty(VarGeneral.RepData.Tables[0].Rows[i][2].ToString()));
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                if (_in.Count > 0)
                {
                    _PointUseIn = _in.Sum((T_INVHED g) => g.PointsCount.Value);
                }
                txtTotalPointUsed.Value = _PointUseIn;
                txtTotalPointReturn.Value = _PointUseOut;
                if (VarGeneral.InvTyp == 3 && !Rep_)
                {
                    txtTotalPointAvalible.Value -= txtTotalPointReturn.Value;
                    label3.Text = ((LangArEn == 0) ? "إجمالي النقاط المسموح ارجاعها" : "Total points allowed to be returned");
                }
                else
                {
                    try
                    {
                        if (txtTotalPointAll.Value - txtTotalPointReturn.Value - txtTotalPointUsed.Value >= 0.0)
                        {
                            txtTotalPointAvalible.Value = txtTotalPointAll.Value - txtTotalPointReturn.Value - txtTotalPointUsed.Value;
                        }
                        else
                        {
                            txtTotalPointAvalible.Value = 0.0;
                        }
                    }
                    catch
                    {
                        txtTotalPointAvalible.Value = 0.0;
                    }
                }
                if (!IsEdit_)
                {
                    txtDiscoundPointsValue.Value = txtTotalPointAvalibleValue.Value;
                }
                else
                {
                    txtDiscoundPointsValue.Value = DiscoundPointsVal_;
                }
            }
            else
            {
                txtTotalPointsOld.Value = 0.0;
                txtDiscoundPoints.Value = 0.0;
                txtDiscoundPointsValue.Value = 0.0;
                txtDueAmountLoc.Value = 0.0;
                txtTotalPointAll.Value = 0.0;
                txtTotalPointAvalible.Value = 0.0;
                txtTotalPointAvalibleValue.Value = 0.0;
                txtTotalPointReturn.Value = 0.0;
                txtTotalPointUsed.Value = 0.0;
            }
        }
        private void MainProcess_OLD()
        {
            if (!string.IsNullOrEmpty(txtCustNo.Text))
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                _RepShow.Rule = " Where T_Items.IsPoints = 1 and T_INVHED.InvTyp = 1  and  T_INVHED.IfDel != 1 and T_INVHED.IsPoints = 1 and CusVenNo = '" + txtCustNo.Text + "' and T_CATEGORY.TotalPurchaes > 0 and T_CATEGORY.TotalPoint > 0 " + (IsEdit_ ? (" and InvHed_ID != " + InvID_) : " ") + " group by T_items.ItmCat";
                _RepShow.Fields = " sum (Round(T_InvDet.Amount,2)) as Amount,T_items.ItmCat ,case when  CONVERT(INT,(sum(Round(T_InvDet.Amount,2)) / (select T_CATEGORY.TotalPurchaes from T_CATEGORY where T_CATEGORY.CAT_ID = T_items.ItmCat))) * (select T_CATEGORY.TotalPoint from T_CATEGORY where T_CATEGORY.CAT_ID = T_items.ItmCat) > 0 then  CONVERT(INT,(sum(Round(T_InvDet.Amount,2)) / (select T_CATEGORY.TotalPurchaes from T_CATEGORY where T_CATEGORY.CAT_ID = T_items.ItmCat))) * (select T_CATEGORY.TotalPoint from T_CATEGORY where T_CATEGORY.CAT_ID = T_items.ItmCat) else 0 end as PointsCount ";
                try
                {
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                try
                {
                    double t_ = (totPointsIn = db.StockAccDefWithOutBalance(txtCustNo.Text).TotPoints.Value);
                    txtTotalPointsOld.Value = t_;
                }
                catch
                {
                    totPointsIn = 0.0;
                    txtTotalPointsOld.Value = 0.0;
                }
                if (VarGeneral.RepData.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
                    {
                        try
                        {
                            if (double.Parse(VarGeneral.TString.TEmpty(VarGeneral.RepData.Tables[0].Rows[i][0].ToString())) > 0.0)
                            {
                                totPointsIn += double.Parse(VarGeneral.TString.TEmpty(VarGeneral.RepData.Tables[0].Rows[i][2].ToString()));
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                totPoints = totPointsIn - totPointsOut;
                if (totPoints > 0.0)
                {
                    txtTotalPointAll.Value = totPoints;
                    if (VarGeneral.InvTyp == 1 || Rep_)
                    {
                        txtTotalPointAvalibleValue.Value = totPoints * VarGeneral.Settings_Sys.PointOfRyal.Value;
                    }
                }
                List<T_INVHED> _in = db.T_INVHEDs.Where((T_INVHED t) => t.InvTyp == (int?)1 && t.IfDel != (int?)1 && t.IsPoints.Value && (IsEdit_ ? (t.InvHed_ID != InvID_) : true) && t.CusVenNo == txtCustNo.Text).ToList();
                List<T_INVHED> _Out = db.T_INVHEDs.Where((T_INVHED t) => t.InvTyp == (int?)3 && t.IfDel != (int?)1 && t.IsPoints.Value && (IsEdit_ ? (t.InvHed_ID != InvID_) : true) && t.CusVenNo == txtCustNo.Text).ToList();
                if (_in.Count > 0)
                {
                    _PointUseIn = _in.Sum((T_INVHED g) => g.PointsCount.Value);
                }
                if (_Out.Count > 0)
                {
                    _PointUseOut = _Out.Sum((T_INVHED g) => g.PointsCount.Value);
                }
                txtTotalPointUsed.Value = _PointUseIn;
                txtTotalPointReturn.Value = _PointUseOut;
                if (VarGeneral.InvTyp == 3 && !Rep_)
                {
                    txtTotalPointAvalible.Value = txtTotalPointUsed.Value - txtTotalPointReturn.Value;
                    label3.Text = ((LangArEn == 0) ? "إجمالي النقاط المسموح ارجاعها" : "Total points allowed to be returned");
                }
                else if (txtTotalPointAll.Value - txtTotalPointUsed.Value + txtTotalPointReturn.Value > txtTotalPointAll.Value)
                {
                    txtTotalPointAvalible.Value = txtTotalPointAll.Value;
                }
                else
                {
                    txtTotalPointAvalible.Value = txtTotalPointAll.Value - txtTotalPointUsed.Value + txtTotalPointReturn.Value;
                }
                if (!IsEdit_)
                {
                    txtDiscoundPointsValue.Value = txtTotalPointAvalibleValue.Value;
                }
                else
                {
                    txtDiscoundPointsValue.Value = DiscoundPointsVal_;
                }
            }
            else
            {
                txtTotalPointsOld.Value = 0.0;
                txtDiscoundPoints.Value = 0.0;
                txtDiscoundPointsValue.Value = 0.0;
                txtDueAmountLoc.Value = 0.0;
                txtTotalPointAll.Value = 0.0;
                txtTotalPointAvalible.Value = 0.0;
                txtTotalPointAvalibleValue.Value = 0.0;
                txtTotalPointReturn.Value = 0.0;
                txtTotalPointUsed.Value = 0.0;
            }
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                buttonX_Ok.Text = ((!Rep_) ? "موافـــق" : "تقرير بنقاط العميل المستخدمة في الفواتير");
                button_ItemMovementPoint.Text = "تقرير تفصـــيلي بالنقاط المستحقة حسب حركة كل صنف";
                buttonX_RepPointAll.Text = "تقرير بإجمالي النقاط المستحقة والمرتجعة حسب كل فاتورةة";
                buttonX_Close.Text = ((!Rep_) ? "تـراجـع" : "خــــــروج");
            }
            else
            {
                buttonX_Ok.Text = ((!Rep_) ? "Save" : "Report of client points used in invoices");
                button_ItemMovementPoint.Text = "Report of movement of points of items";
                buttonX_RepPointAll.Text = "Report the total points due and return to the customer per invoice";
                buttonX_Close.Text = ((!Rep_) ? "Back" : "Close");
            }
            try
            {
                lablCurr.Text = db.StockCurencyID(int.Parse(VarGeneral.Settings_Sys.ImportIp)).Symbol;
            }
            catch
            {
            }
            try
            {
                lablCurr2.Text = db.StockCurencyID(int.Parse(VarGeneral.Settings_Sys.ImportIp)).Symbol;
            }
            catch
            {
            }
        }
        private void buttonX_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void txtTotalPointAvalible_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtTotalPointAvalibleValue.Value = txtTotalPointAvalible.Value * VarGeneral.Settings_Sys.PointOfRyal.Value;
            }
            catch
            {
            }
        }
        private void txtTotalPointAvalibleValue_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtDiscoundPointsValue.MaxValue = txtTotalPointAvalibleValue.Value;
            }
            catch
            {
            }
        }
        private void buttonX_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Rep_)
                {
                    if (txtDiscoundPointsValue.Value > txtDueAmountLoc.Value)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن ان يكون قيمة خصم النقاط أكبر من صافي الفاتورة .. يرجى التأكد من المدخلات" : "Value of discount points can not be greater than net invoice .. Please make sure the input", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    IsDone = true;
                    Close();
                    return;
                }
                VarGeneral.itmDes = "";
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_INVHED Left Join  T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  Left Join T_Curency On T_INVHED.CurTyp = T_Curency.Curency_ID Left Join T_CstTbl On T_INVHED.InvCstNo = T_CstTbl.Cst_ID Left Join T_Mndob on T_INVHED.MndNo = T_Mndob.Mnd_Id Left Join T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                string Fields = "";
                Fields = ((LangArEn != 0) ? (" T_INVHED.InvTyp,T_INVHED.InvNo,T_INVSETTING.InvNamE as InvTypNm,T_INVHED.GDat,T_INVHED.HDat,T_INVHED.InvCash ,T_CstTbl.Eng_Des as CostCenteNm,T_Mndob.Eng_Des as MndNm,T_INVHED.CashPayLocCur,T_INVHED.NetworkPayLocCur,T_INVHED.CreditPayLocCur,T_INVHED.InvNetLocCur,(Round(T_INVHED.InvCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as  InvCost,(Round(T_INVHED.InvNetLocCur - T_INVHED.InvCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as InvProfit, T_INVHED.GadeNo ,T_INVHED.CusVenNo,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Arb_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNm,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Eng_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNmE,T_SYSSETTING.LogImg,T_SYSSETTING.Calendr ,T_INVHED.SalsManNo,((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.DesPointsValue,(case when T_INVHED.InvTyp = 3 then (select  CONVERT(INT,(Round(sum(T_InvDet.Amount),2) / max(T_CATEGORY.TotalPurchaes))) * max(TotalPoint) from T_INVDET LEFT  OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID where  T_INVDET.InvId = T_INVHED.InvHed_ID and T_INVHED.InvTyp = 3 and T_Items.IsPoints = 1 and T_CATEGORY.TotalPurchaes > 0 and T_CATEGORY.TotalPoint > 0 and  T_INVHED.IfDel != 1 and T_INVHED.IsPoints = 1) else T_INVHED.PointsCount end) as PointsCount,T_INVHED.IsPoints,'' as UsrNamA,''as UsrNamE,Round(case when IsTaxByNet = 1 and T_INVHED.TaxByNetValue > 0 then (T_INVHED.TaxByNetValue * T_INVHED.InvNetLocCur / 100) else (case when T_INVHED.IsTaxLines = 1 then((select sum(Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmTax) from T_INVDET where T_INVDET.InvId = T_INVHED.InvHed_ID) / 100) else 0 end ) end ," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as TaxValue,'" + txtTotalPointAll.Value + "' as DesPointsValueWithDisVal,'" + txtTotalPointUsed.Value + "' as InvDisValOnly,'" + txtTotalPointReturn.Value + "' as DesPointsValueLocCur,'" + txtTotalPointAvalible.Value + "' as InvAddTax,case when T_INVHED.CusVenNo = '' THEN 0 ELSE (select T_AccDef.TotPoints from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as InvTotLocCur,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Mobile from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Mobile") : (" T_INVHED.InvTyp,T_INVHED.InvNo,T_INVSETTING.InvNamA as InvTypNm,T_INVHED.GDat,T_INVHED.HDat,T_INVHED.InvCash ,T_CstTbl.Arb_Des as CostCenteNm,T_Mndob.Arb_Des as MndNm,T_INVHED.CashPayLocCur,T_INVHED.NetworkPayLocCur,T_INVHED.CreditPayLocCur,T_INVHED.InvNetLocCur,(Round(T_INVHED.InvCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as  InvCost,(Round(T_INVHED.InvNetLocCur - T_INVHED.InvCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as InvProfit, T_INVHED.GadeNo ,T_INVHED.CusVenNo,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Arb_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNm,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Eng_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNmE,T_SYSSETTING.LogImg,T_SYSSETTING.Calendr ,T_INVHED.SalsManNo,((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.DesPointsValue,(case when T_INVHED.InvTyp = 3 then (select  CONVERT(INT,(Round(sum(T_InvDet.Amount),2) / max(T_CATEGORY.TotalPurchaes))) * max(TotalPoint) from T_INVDET LEFT  OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID where  T_INVDET.InvId = T_INVHED.InvHed_ID and T_INVHED.InvTyp = 3 and T_Items.IsPoints = 1 and T_CATEGORY.TotalPurchaes > 0 and T_CATEGORY.TotalPoint > 0 and  T_INVHED.IfDel != 1 and T_INVHED.IsPoints = 1) else T_INVHED.PointsCount end) as PointsCount,T_INVHED.IsPoints,'' as UsrNamA,''as UsrNamE,Round(case when IsTaxByNet = 1 and T_INVHED.TaxByNetValue > 0 then (T_INVHED.TaxByNetValue * T_INVHED.InvNetLocCur / 100) else (case when T_INVHED.IsTaxLines = 1 then((select sum(Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmTax) from T_INVDET where T_INVDET.InvId = T_INVHED.InvHed_ID) / 100) else 0 end ) end ," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as TaxValue,'" + txtTotalPointAll.Value + "' as DesPointsValueWithDisVal,'" + txtTotalPointUsed.Value + "' as InvDisValOnly,'" + txtTotalPointReturn.Value + "' as DesPointsValueLocCur,'" + txtTotalPointAvalible.Value + "' as InvAddTax,case when T_INVHED.CusVenNo = '' THEN 0 ELSE (select T_AccDef.TotPoints from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as InvTotLocCur,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Mobile from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Mobile"));
                _RepShow.Rule = " Where ( T_INVHED.InvTyp = 1 or T_INVHED.InvTyp = 3 ) and  T_INVHED.IfDel != 1 and T_INVHED.IsPoints = 1 and ((( DesPointsValue > 0 and T_INVHED.InvTyp = 1) and (PointsCount > 0 and T_INVHED.InvTyp = 1)) or  T_INVHED.InvTyp = 3) and CusVenNo = '" + txtCustNo.Text + "' order by T_INVHED.InvTyp, T_INVHED.InvHed_ID";
                _RepShow.Fields = Fields;
                try
                {
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "عفوا .. لا يوجد بيانات لعرضها في التقرير " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                try
                {
                    FrmReportsViewer frm = new FrmReportsViewer();
                    frm.Tag = LangArEn;
                    frm.Repvalue = "InvoicesCustPoints";
                    VarGeneral.vTitle = labelHeader.Text;
                    frm.TopMost = true;
                    frm.ShowDialog();
                }
                catch (Exception error2)
                {
                    VarGeneral.DebLog.writeLog("button_ShowRep_Click:", error2, enable: true);
                    MessageBox.Show(error2.Message);
                }
            }
            catch (Exception error2)
            {
                VarGeneral.DebLog.writeLog("buttonX_Ok_Click:", error2, enable: true);
                MessageBox.Show(error2.Message);
                IsDone = false;
                Close();
            }
        }
        private void FrmCustomerPointData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void FrmCustomerPointData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void txtDiscoundPointsValue_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtDiscoundPoints.Value = txtDiscoundPointsValue.Value / VarGeneral.Settings_Sys.PointOfRyal.Value;
            }
            catch
            {
            }
        }
        private void button_SrchCustNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, ""));
            columns_Names_visible.Add("TaxNo", new ColumnDictinary("الرقم الضريبي", "Tax No", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_AccDef2";
            VarGeneral.AccTyp = 4;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtCustNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtCustName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
                else
                {
                    txtCustName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
            }
            else
            {
                txtCustNo.Text = "";
                txtCustName.Text = "";
            }
            MainProcess();
        }
        private string BuildFieldList()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                return " CONVERT(INT,(Round(T_InvDet.Amount,2) / T_CATEGORY.TotalPurchaes)) * TotalPoint as ItmUntPak,(CONVERT(INT,(Round(T_InvDet.Amount,2) / T_CATEGORY.TotalPurchaes)) * TotalPoint) * T_SYSSETTING.PointOfRyal as ItmDis,T_INVHED.CusVenNo,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Arb_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNm,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Eng_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNmE, InvDet_ID,T_Items.Itm_No,T_Items.Arb_Des as itemNm,T_Category.Arb_Des as CategoyNm,T_InvDet.StoreNo,T_InvDet.ItmUnt as UnitNm,(Round(T_InvDet.Price," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Price,T_InvDet.ItmDis,Abs(T_INVDET.Qty) as Qty,Abs(T_INVDET.RealQty) as RealQty,(Round(T_InvDet.Amount," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Amount,(Round(T_InvDet.Cost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Cost,T_INVHED.InvNo, T_INVSETTING.InvNamA as InvTypNm,T_INVHED.InvCash,T_Curency.Arb_Des as CurrnceyNm,T_INVHED.GadeNo, T_Mndob.Arb_Des as MndNm,T_INVHED.RetNo,T_SYSSETTING.LogImg,'" + txtTotalPointAll.Value + "' as Profit,'" + txtTotalPointUsed.Value + "' as CostCenteNm,'" + txtTotalPointReturn.Value + "' as HDat,'" + txtTotalPointAvalible.Value + "' as GDat,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Mobile from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Mobile";
            }
            return " CONVERT(INT,(Round(T_InvDet.Amount,2) / T_CATEGORY.TotalPurchaes)) * TotalPoint as ItmUntPak,(CONVERT(INT,(Round(T_InvDet.Amount,2) / T_CATEGORY.TotalPurchaes)) * TotalPoint) * T_SYSSETTING.PointOfRyal as ItmDis,T_INVHED.CusVenNo,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Arb_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNm,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Eng_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNmE,InvDet_ID,T_Items.Itm_No,T_Items.Eng_Des as itemNm,T_Category.Eng_Des as CategoyNm,T_InvDet.StoreNo,T_InvDet.ItmUntE as UnitNm,(Round(T_InvDet.Price," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Price,T_InvDet.ItmDis,Abs(T_INVDET.Qty) as Qty,Abs(T_INVDET.RealQty) as RealQty,(Round(T_InvDet.Amount," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Amount,(Round(T_InvDet.Cost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Cost,T_INVHED.InvNo, T_INVSETTING.InvNamE as InvTypNm,T_INVHED.InvCash,T_Curency.Eng_Des as CurrnceyNm,T_INVHED.GadeNo, T_Mndob.Eng_Des as MndNm,T_INVHED.RetNo,T_SYSSETTING.LogImg,'" + txtTotalPointAll.Value + "' as Profit,'" + txtTotalPointUsed.Value + "' as CostCenteNm,'" + txtTotalPointReturn.Value + "' as HDat,'" + txtTotalPointAvalible.Value + "' as GDat,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Mobile from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Mobile";
        }
        private void button_ItemMovementPoint_Click(object sender, EventArgs e)
        {
            try
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = "T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                string Fields = BuildFieldList();
                _RepShow.Rule = " Where T_Items.IsPoints = 1 and T_CATEGORY.TotalPurchaes > 0 and T_CATEGORY.TotalPoint > 0 and ( T_INVHED.InvTyp = 1 or T_INVHED.InvTyp = 3 ) and  T_INVHED.IfDel != 1 and T_INVHED.IsPoints = 1 and CusVenNo = '" + txtCustNo.Text + "' order by T_INVHED.InvTyp, T_INVHED.InvHed_ID";
                _RepShow.Fields = Fields;
                try
                {
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.Message);
                }
                if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "عفوا .. لا يوجد بيانات لعرضها في التقرير " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                try
                {
                    FrmReportsViewer frm = new FrmReportsViewer();
                    frm.Tag = LangArEn;
                    frm.Repvalue = "ItemMovementsCustPoints";
                    VarGeneral.vTitle = labelHeader.Text;
                    frm.TopMost = true;
                    frm.ShowDialog();
                }
                catch (Exception error)
                {
                    VarGeneral.DebLog.writeLog("button_ItemMovementPoint_Click:", error, enable: true);
                    MessageBox.Show(error.Message);
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }
        private void button_ItemMovementPoint_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                buttonX_RepPointAll.Visible = button_ItemMovementPoint.Visible;
                line1.Visible = !button_ItemMovementPoint.Visible;
            }
            catch
            {
                buttonX_RepPointAll.Visible = false;
                line1.Visible = true;
            }
        }
        private void buttonX_RepPointAll_Click(object sender, EventArgs e)
        {
            try
            {
                VarGeneral.itmDes = "";
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_INVHED Left Join  T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  Left Join T_Curency On T_INVHED.CurTyp = T_Curency.Curency_ID Left Join T_CstTbl On T_INVHED.InvCstNo = T_CstTbl.Cst_ID Left Join T_Mndob on T_INVHED.MndNo = T_Mndob.Mnd_Id Left Join T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                string Fields = "";
                Fields = ((LangArEn != 0) ? (" T_INVHED.InvTyp,T_INVHED.InvNo,T_INVSETTING.InvNamE as InvTypNm,T_INVHED.GDat,T_INVHED.HDat,T_INVHED.InvCash ,T_CstTbl.Eng_Des as CostCenteNm,T_Mndob.Eng_Des as MndNm,T_INVHED.CashPayLocCur,T_INVHED.NetworkPayLocCur,T_INVHED.CreditPayLocCur,T_INVHED.InvNetLocCur,(Round(T_INVHED.InvCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as  InvCost,(Round(T_INVHED.InvNetLocCur - T_INVHED.InvCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as InvProfit, T_INVHED.GadeNo ,T_INVHED.CusVenNo,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Arb_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNm,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Eng_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNmE,T_SYSSETTING.LogImg,T_SYSSETTING.Calendr ,T_INVHED.SalsManNo,((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.DesPointsValue,((select  CONVERT(INT,(Round(sum(T_InvDet.Amount),2) / max(T_CATEGORY.TotalPurchaes))) * max(TotalPoint) from T_INVDET LEFT  OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID where  T_INVDET.InvId = T_INVHED.InvHed_ID and T_Items.IsPoints = 1 and T_CATEGORY.TotalPurchaes > 0 and T_CATEGORY.TotalPoint > 0 and  T_INVHED.IfDel != 1 and T_INVHED.IsPoints = 1)) as PointsCount,T_INVHED.IsPoints,'' as UsrNamA,''as UsrNamE,Round(case when IsTaxByNet = 1 and T_INVHED.TaxByNetValue > 0 then (T_INVHED.TaxByNetValue * T_INVHED.InvNetLocCur / 100) else (case when T_INVHED.IsTaxLines = 1 then((select sum(Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmTax) from T_INVDET where T_INVDET.InvId = T_INVHED.InvHed_ID) / 100) else 0 end ) end ," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as TaxValue,'" + txtTotalPointAll.Value + "' as DesPointsValueWithDisVal,'" + txtTotalPointUsed.Value + "' as InvDisValOnly,'" + txtTotalPointReturn.Value + "' as DesPointsValueLocCur,'" + txtTotalPointAvalible.Value + "' as InvAddTax,case when T_INVHED.CusVenNo = '' THEN 0 ELSE (select T_AccDef.TotPoints from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as InvTotLocCur,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Mobile from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Mobile") : (" T_INVHED.InvTyp,T_INVHED.InvNo,T_INVSETTING.InvNamA as InvTypNm,T_INVHED.GDat,T_INVHED.HDat,T_INVHED.InvCash ,T_CstTbl.Arb_Des as CostCenteNm,T_Mndob.Arb_Des as MndNm,T_INVHED.CashPayLocCur,T_INVHED.NetworkPayLocCur,T_INVHED.CreditPayLocCur,T_INVHED.InvNetLocCur,(Round(T_INVHED.InvCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as  InvCost,(Round(T_INVHED.InvNetLocCur - T_INVHED.InvCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as InvProfit, T_INVHED.GadeNo ,T_INVHED.CusVenNo,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Arb_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNm,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Eng_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNmE,T_SYSSETTING.LogImg,T_SYSSETTING.Calendr ,T_INVHED.SalsManNo,((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.DesPointsValue,((select  CONVERT(INT,(Round(sum(T_InvDet.Amount),2) / max(T_CATEGORY.TotalPurchaes))) * max(TotalPoint) from T_INVDET LEFT  OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID where  T_INVDET.InvId = T_INVHED.InvHed_ID and T_Items.IsPoints = 1 and T_CATEGORY.TotalPurchaes > 0 and T_CATEGORY.TotalPoint > 0 and  T_INVHED.IfDel != 1 and T_INVHED.IsPoints = 1)) as PointsCount,T_INVHED.IsPoints,'' as UsrNamA,''as UsrNamE,Round(case when IsTaxByNet = 1 and T_INVHED.TaxByNetValue > 0 then (T_INVHED.TaxByNetValue * T_INVHED.InvNetLocCur / 100) else (case when T_INVHED.IsTaxLines = 1 then((select sum(Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmTax) from T_INVDET where T_INVDET.InvId = T_INVHED.InvHed_ID) / 100) else 0 end ) end ," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as TaxValue,'" + txtTotalPointAll.Value + "' as DesPointsValueWithDisVal,'" + txtTotalPointUsed.Value + "' as InvDisValOnly,'" + txtTotalPointReturn.Value + "' as DesPointsValueLocCur,'" + txtTotalPointAvalible.Value + "' as InvAddTax,case when T_INVHED.CusVenNo = '' THEN 0 ELSE (select T_AccDef.TotPoints from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as InvTotLocCur,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Mobile from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Mobile"));
                _RepShow.Rule = " Where ( T_INVHED.InvTyp = 1 or T_INVHED.InvTyp = 3 ) and  T_INVHED.IfDel != 1 and T_INVHED.IsPoints = 1 and CusVenNo = '" + txtCustNo.Text + "' order by T_INVHED.InvTyp, T_INVHED.InvHed_ID";
                _RepShow.Fields = Fields;
                try
                {
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "عفوا .. لا يوجد بيانات لعرضها في التقرير " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                try
                {
                    FrmReportsViewer frm = new FrmReportsViewer();
                    frm.Tag = LangArEn;
                    frm.Repvalue = "InvoicesCustPointsALL";
                    VarGeneral.vTitle = labelHeader.Text;
                    frm.TopMost = true;
                    frm.ShowDialog();
                }
                catch (Exception error2)
                {
                    VarGeneral.DebLog.writeLog("button_ShowRep_Click:", error2, enable: true);
                    MessageBox.Show(error2.Message);
                }
            }
            catch (Exception error2)
            {
                VarGeneral.DebLog.writeLog("buttonX_Ok_Click:", error2, enable: true);
                MessageBox.Show(error2.Message);
                IsDone = false;
                Close();
            }
        }
    }
}
