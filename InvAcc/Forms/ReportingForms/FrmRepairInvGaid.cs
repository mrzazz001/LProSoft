using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Framework.Data;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmRepairInvGaid : Form
    { void avs(int arln)

{ 
 Text = "خـــروج";this.Text=   (arln == 0 ? "  خـــروج  " : "  Close") ; Text = "مـــوافــــق";this.Text=   (arln == 0 ? "  مـــوافــــق  " : "  ok") ; Text = "نــــــوع الفـــاتــورة";this.Text=   (arln == 0 ? "  نــــــوع الفـــاتــورة  " : "  Invoice type") ;}
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
        private ComboBoxEx CmbInvType;
        private ButtonX ButExit;
        private ButtonX ButOk;
        private Label label1;
        private List<T_INVSETTING> listInvSetting = new List<T_INVSETTING>();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private int LangArEn = 0;
        private Stock_DataDataContext dbInstance;
        private bool tp = false;
        private ScriptNumber ScriptNumber1 = new ScriptNumber();
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
        public FrmRepairInvGaid(bool _typ)
        {
            InitializeComponent();this.Load += langloads;
            listInvSetting = db.T_INVSETTINGs.Where((T_INVSETTING t) => t.InvID == 1 || t.InvID == 2 || t.InvID == 3 || t.InvID == 4 || t.InvID == 5 || t.InvID == 6 || t.InvID == 7 || t.InvID == 8 || t.InvID == 9 || t.InvID == 10 || t.InvID == 14 || t.InvID == 17 || t.InvID == 20 || t.InvID == 21).ToList();
            CmbInvType.Items.Clear();
            CmbInvType.DataSource = listInvSetting;
            CmbInvType.DisplayMember = "InvNamA";
            CmbInvType.ValueMember = "InvID";
            CmbInvType.SelectedIndex = 0;
            tp = _typ;
            if (tp)
            {
                ButOk_Click(null, null);
            }
        }
        private void FrmRepairInvGaid_Load(object sender, EventArgs e)
        {
        }
        private void ButExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            try
            {
                VarGeneral.InvTyp = int.Parse(CmbInvType.SelectedValue.ToString());
                T_INVSETTING _InvSetting = db.StockInvSetting( VarGeneral.InvTyp);
                List<T_INVHED> _Data = (from t in db.T_INVHEDs
                                        where t.InvTyp == (int?)VarGeneral.InvTyp
                                        where t.IfDel.Value == 0
                                        where t.GadeId.HasValue
                                        select t).ToList();
                List<double?> Query = (from c in _Data
                                       group c by new
                                       {
                                           c.GadeId
                                       } into g
                                       where g.Count() > 1
                                       select g.Key.GadeId).ToList();
                if (Query.Count <= 0)
                {
                    return;
                }
                int i;
                List<T_INVHED> q;
                int c2;
                for (i = 0; i < Query.Count; i++)
                {
                    q = (from t in db.T_INVHEDs
                         where t.InvTyp == (int?)VarGeneral.InvTyp
                         where t.IfDel.Value == 0
                         where t.GadeId.HasValue
                         where t.GadeId.Value == Query[i].Value
                         select t).ToList();
                    for (c2 = 0; c2 < q.Count; c2++)
                    {
                        try
                        {
                            List<T_GDHEAD> j = (from item in db.T_GDHEADs
                                                where (double)item.gdhead_ID == Query[i].Value
                                                where item.gdLok == false
                                                where item.gdTyp == (int?)VarGeneral.InvTyp
                                                where item.gdNo == q[c2].InvNo
                                                select item).ToList();
                            if (j.Count > 0)
                            {
                                continue;
                            }
                            string AccCrdt = "";
                            string AccDbt = "";
                            string AccCrdt_Credit = "";
                            string AccDbt_Credit = "";
                            string AccCrdt_NewtWork = "";
                            string AccDbt_NetWork = "";
                            if (_InvSetting.InvSetting.Substring(1, 1) == "1" && VarGeneral.SSSTyp != 0)
                            {
                                AccCrdt_Credit = ((_InvSetting.AccCredit1.Trim() != "***") ? _InvSetting.AccCredit1.Trim() : q[c2].CusVenNo);
                                AccDbt_Credit = ((_InvSetting.AccDebit1.Trim() != "***") ? _InvSetting.AccDebit1.Trim() : q[c2].CusVenNo);
                                AccCrdt_NewtWork = ((_InvSetting.AccCredit2.Trim() != "***") ? _InvSetting.AccCredit2.Trim() : q[c2].CusVenNo);
                                AccDbt_NetWork = ((_InvSetting.AccDebit2.Trim() != "***") ? _InvSetting.AccDebit2.Trim() : q[c2].CusVenNo);
                                AccCrdt = ((_InvSetting.AccCredit0.Trim() != "***") ? _InvSetting.AccCredit0.Trim() : q[c2].CusVenNo);
                                AccDbt = ((_InvSetting.AccDebit0.Trim() != "***") ? _InvSetting.AccDebit0.Trim() : q[c2].CusVenNo);
                            }
                            else if (VarGeneral.SSSTyp == 0)
                            {
                                AccCrdt_Credit = ((_InvSetting.AccCredit4.Trim() != "***") ? _InvSetting.AccCredit4.Trim() : q[c2].CusVenNo);
                                AccDbt_Credit = ((_InvSetting.AccDebit4.Trim() != "***") ? _InvSetting.AccDebit4.Trim() : q[c2].CusVenNo);
                                AccCrdt_NewtWork = ((_InvSetting.AccCredit4.Trim() != "***") ? _InvSetting.AccCredit4.Trim() : q[c2].CusVenNo);
                                AccDbt_NetWork = ((_InvSetting.AccDebit4.Trim() != "***") ? _InvSetting.AccDebit4.Trim() : q[c2].CusVenNo);
                                AccCrdt = ((_InvSetting.AccCredit3.Trim() != "***") ? _InvSetting.AccCredit3.Trim() : q[c2].CusVenNo);
                                AccDbt = ((_InvSetting.AccDebit3.Trim() != "***") ? _InvSetting.AccDebit3.Trim() : q[c2].CusVenNo);
                            }
                            if (q[c2].CreditPay.Value <= 0.0)
                            {
                                AccCrdt_Credit = "";
                                AccDbt_Credit = "";
                            }
                            if (q[c2].NetworkPay.Value <= 0.0)
                            {
                                AccCrdt_NewtWork = "";
                                AccDbt_NetWork = "";
                            }
                            if (q[c2].CashPayLocCur.Value <= 0.0)
                            {
                                AccCrdt = "";
                                AccDbt = "";
                            }
                            if ((string.IsNullOrEmpty(AccCrdt) || string.IsNullOrEmpty(AccDbt)) && (string.IsNullOrEmpty(AccCrdt_NewtWork) || string.IsNullOrEmpty(AccDbt_NetWork)) && (string.IsNullOrEmpty(AccCrdt_Credit) || string.IsNullOrEmpty(AccDbt_Credit)))
                            {
                                continue;
                            }
                            Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
                            T_GDHEAD _GdHead = new T_GDHEAD();
                            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);  this.netResize1.LabelsAutoEllipse = false;
                            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
                            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
                            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
                            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
                            _GdHead.gdHDate = q[c2].HDat;
                            _GdHead.gdGDate = q[c2].GDat;
                            _GdHead.gdNo = q[c2].InvNo;
                            _GdHead.ArbTaf = ScriptNumber1.ScriptNum(decimal.Parse("0" + q[c2].InvNetLocCur.Value));
                            _GdHead.BName = _GdHead.BName;
                            _GdHead.ChekNo = _GdHead.ChekNo;
                            _GdHead.CurTyp = q[c2].CurTyp.Value;
                            _GdHead.EngTaf = ScriptNumber1.TafEng(decimal.Parse("0" + q[c2].InvNetLocCur.Value));
                            _GdHead.gdCstNo = q[c2].InvCstNo.Value;
                            _GdHead.gdID = 0;
                            _GdHead.gdLok = false;
                            _GdHead.gdMem = q[c2].Remark;
                            try
                            {
                                _GdHead.gdMnd = q[c2].MndNo.Value;
                            }
                            catch
                            {
                                _GdHead.gdMnd = null;
                            }
                            _GdHead.gdRcptID = (_GdHead.gdRcptID.HasValue ? _GdHead.gdRcptID.Value : 0.0);
                            _GdHead.gdTot = q[c2].InvNetLocCur.Value;
                            _GdHead.gdTp = (_GdHead.gdTp!=0? _GdHead.gdTp : 0);
                            _GdHead.gdTyp = VarGeneral.InvTyp;
                            _GdHead.RefNo = q[c2].RefNo;
                            _GdHead.AdminLock = q[c2].AdminLock.Value;
                            _GdHead.DATE_MODIFIED = q[c2].DATE_MODIFIED;
                            _GdHead.salMonth = "";
                            _GdHead.gdUser = q[c2].UserNew;
                            _GdHead.gdUserNam = "";
                            _GdHead.CompanyID = 1;
                            _GdHead.DATE_CREATED = DateTime.Now;
                            dbc.T_GDHEADs.InsertOnSubmit(_GdHead);
                            dbc.SubmitChanges();
                            IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
                            if (!string.IsNullOrEmpty(AccCrdt) && !string.IsNullOrEmpty(AccDbt))
                            {
                                db_.StartTransaction();
                                db_.ClearParameters();
                                db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                                db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                                db_.AddParameter("gdNo", DbType.String, q[c2].InvNo);
                                db_.AddParameter("gdDes", DbType.String, "قيد تلقائي لفاتورة " + CmbInvType.Text.Trim() + " رقم : " + q[c2].InvNo);
                                db_.AddParameter("gdDesE", DbType.String, "Auto Bound To Sales Invoice No : " + q[c2].InvNo);
                                db_.AddParameter("recptTyp", DbType.String, "1");
                                db_.AddParameter("AccNo", DbType.String, AccCrdt);
                                db_.AddParameter("AccName", DbType.String, "");
                                db_.AddParameter("gdValue", DbType.Double, 0.0 - q[c2].CashPay.Value);
                                db_.AddParameter("recptNo", DbType.String, q[c2].InvNo);
                                db_.AddParameter("Lin", DbType.Int32, 1);
                                db_.AddParameter("AccNoDestruction", DbType.String, null);
                                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                                db_.EndTransaction();
                                db_.StartTransaction();
                                db_.ClearParameters();
                                db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                                db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                                db_.AddParameter("gdNo", DbType.String, q[c2].InvNo);
                                db_.AddParameter("gdDes", DbType.String, "قيد تلقائي لفاتورة " + CmbInvType.Text.Trim() + " رقم : " + q[c2].InvNo);
                                db_.AddParameter("gdDesE", DbType.String, "Auto Bound To " + CmbInvType.Text.Trim() + " Invoice No : " + q[c2].InvNo);
                                db_.AddParameter("recptTyp", DbType.String, "1");
                                db_.AddParameter("AccNo", DbType.String, AccDbt);
                                db_.AddParameter("AccName", DbType.String, "");
                                db_.AddParameter("gdValue", DbType.Double, q[c2].CashPay.Value);
                                db_.AddParameter("recptNo", DbType.String, q[c2].InvNo);
                                db_.AddParameter("Lin", DbType.Int32, 1);
                                db_.AddParameter("AccNoDestruction", DbType.String, null);
                                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                                db_.EndTransaction();
                            }
                            if (!string.IsNullOrEmpty(AccCrdt_NewtWork) && !string.IsNullOrEmpty(AccDbt_NetWork))
                            {
                                db_.StartTransaction();
                                db_.ClearParameters();
                                db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                                db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                                db_.AddParameter("gdNo", DbType.String, q[c2].InvNo);
                                db_.AddParameter("gdDes", DbType.String, "قيد تلقائي لفاتورة " + CmbInvType.Text.Trim() + " رقم : " + q[c2].InvNo);
                                db_.AddParameter("gdDesE", DbType.String, "Auto Bound To " + CmbInvType.Text.Trim() + " Invoice No : " + q[c2].InvNo);
                                db_.AddParameter("recptTyp", DbType.String, "1");
                                db_.AddParameter("AccNo", DbType.String, AccCrdt_NewtWork);
                                db_.AddParameter("AccName", DbType.String, "");
                                db_.AddParameter("gdValue", DbType.Double, 0.0 - q[c2].NetworkPay);
                                db_.AddParameter("recptNo", DbType.String, q[c2].InvNo);
                                db_.AddParameter("Lin", DbType.Int32, 3);
                                db_.AddParameter("AccNoDestruction", DbType.String, null);
                                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                                db_.EndTransaction();
                                db_.StartTransaction();
                                db_.ClearParameters();
                                db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                                db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                                db_.AddParameter("gdNo", DbType.String, q[c2].InvNo);
                                db_.AddParameter("gdDes", DbType.String, "قيد تلقائي لفاتورة " + CmbInvType.Text.Trim() + " رقم : " + q[c2].InvNo);
                                db_.AddParameter("gdDesE", DbType.String, "Auto Bound To " + CmbInvType.Text.Trim() + " Invoice No : " + q[c2].InvNo);
                                db_.AddParameter("recptTyp", DbType.String, "1");
                                db_.AddParameter("AccNo", DbType.String, AccDbt_NetWork);
                                db_.AddParameter("AccName", DbType.String, "");
                                db_.AddParameter("gdValue", DbType.Double, q[c2].NetworkPay);
                                db_.AddParameter("recptNo", DbType.String, q[c2].InvNo);
                                db_.AddParameter("Lin", DbType.Int32, 3);
                                db_.AddParameter("AccNoDestruction", DbType.String, null);
                                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                                db_.EndTransaction();
                            }
                            if (!string.IsNullOrEmpty(AccCrdt_Credit) && !string.IsNullOrEmpty(AccDbt_Credit))
                            {
                                db_.StartTransaction();
                                db_.ClearParameters();
                                db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                                db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                                db_.AddParameter("gdNo", DbType.String, q[c2].InvNo);
                                db_.AddParameter("gdDes", DbType.String, "قيد تلقائي لفاتورة " + CmbInvType.Text.Trim() + " رقم : " + q[c2].InvNo);
                                db_.AddParameter("gdDesE", DbType.String, "Auto Bound To " + CmbInvType.Text.Trim() + " Invoice No : " + q[c2].InvNo);
                                db_.AddParameter("recptTyp", DbType.String, "1");
                                db_.AddParameter("AccNo", DbType.String, AccCrdt_Credit);
                                db_.AddParameter("AccName", DbType.String, "");
                                db_.AddParameter("gdValue", DbType.Double, 0.0 - q[c2].CreditPayLocCur.Value);
                                db_.AddParameter("recptNo", DbType.String, q[c2].InvNo);
                                db_.AddParameter("Lin", DbType.Int32, 2);
                                db_.AddParameter("AccNoDestruction", DbType.String, null);
                                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                                db_.EndTransaction();
                                db_.StartTransaction();
                                db_.ClearParameters();
                                db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                                db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                                db_.AddParameter("gdNo", DbType.String, q[c2].InvNo);
                                db_.AddParameter("gdDes", DbType.String, "قيد تلقائي لفاتورة " + CmbInvType.Text.Trim() + " رقم : " + q[c2].InvNo);
                                db_.AddParameter("gdDesE", DbType.String, "Auto Bound To " + CmbInvType.Text.Trim() + " Invoice No : " + q[c2].InvNo);
                                db_.AddParameter("recptTyp", DbType.String, "1");
                                db_.AddParameter("AccNo", DbType.String, AccDbt_Credit);
                                db_.AddParameter("AccName", DbType.String, "");
                                db_.AddParameter("gdValue", DbType.Double, q[c2].CreditPayLocCur.Value);
                                db_.AddParameter("recptNo", DbType.String, q[c2].InvNo);
                                db_.AddParameter("Lin", DbType.Int32, 2);
                                db_.AddParameter("AccNoDestruction", DbType.String, null);
                                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                                db_.EndTransaction();
                            }
                            dbc.ExecuteCommand("UPDATE T_INVHED SET GadeId = " + _GdHead.gdhead_ID + ",GadeNo = " + int.Parse(q[c2].InvNo) + " where InvHed_ID = " + q[c2].InvHed_ID);
                        }
                        catch
                        {
                        }
                    }
                    if (!tp)
                    {
                        MessageBox.Show((LangArEn == 0) ? "تمت العملية بنجاح .." : "Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Close();
                    }
                }
            }
            catch
            {
            }
        }
        private void FrmRepairInvGaid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ButExit_Click(sender, e);
            }
        }
    }
}
