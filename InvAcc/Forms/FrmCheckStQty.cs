using DevComponents.DotNetBar;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using Library.RepShow;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmCheckStQty : Form
    { void avs(int arln)

{ 
 ButExit.Text=   (arln == 0 ? "  خـــروج  " : "  Close") ; ButShow.Text=   (arln == 0 ? "  عــــرض  " : "  show") ; ButDel.Text=   (arln == 0 ? "  حـــذف الأصناف  " : "  Delete items") ; Text = "الأصناف المعلقة في المستودعات";this.Text=   (arln == 0 ? "  الأصناف المعلقة في المستودعات  " : "  Items suspended in warehouse") ;}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private bool tp = false;
        private int LangArEn = 0;
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
        private ButtonX ButExit;
        private ButtonX ButShow;
        private ButtonX ButDel;
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
        public FrmCheckStQty()
        {
            InitializeComponent();this.Load += langloads;
        }
        private void FrmCheckStQty_Load(object sender, EventArgs e)
        {
            tp = false;
        }
        private void ButExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ButShow_Click(object sender, EventArgs e)
        {
            try
            {
                tp = false;
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_STKSQTY ";
                string Fields = "";
                Fields = "T_STKSQTY.itmNo as No,T_STKSQTY.storeNo as NmE,(select Arb_Des from T_Items where T_Items.Itm_No = T_STKSQTY.itmNo ) as NmA";
                _RepShow.Rule = "where stkQty = 0 and stkInt = 0 and T_STKSQTY.itmNo not in (select T_INVDET.ItmNo from T_INVDET where T_INVDET.ItmNo = T_STKSQTY.itmNo and T_INVDET.StoreNo = T_STKSQTY.storeNo)";
                if (!string.IsNullOrEmpty(Fields))
                {
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
                        frm.Repvalue = "RepCheckStQty";
                        VarGeneral.vTitle = Text;
                        tp = true;
                        frm.TopMost = true;
                        frm.ShowDialog();
                    }
                    catch (Exception error)
                    {
                        VarGeneral.DebLog.writeLog("button_ShowRep_Click:", error, enable: true);
                        MessageBox.Show(error.Message);
                    }
                }
                else
                {
                    MessageBox.Show((LangArEn == 0) ? " يجب تحديد حقل واحد على الأقل للطباعة" : "You must select one field or more", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }
        private void ButDel_Click(object sender, EventArgs e)
        {
            if (!tp)
            {
                MessageBox.Show("يرجى عرض الأصناف والتاكد من صحتها قبل اتمام هذه العملية");
                return;
            }
            try
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_STKSQTY ";
                string Fields = "";
                Fields = "T_STKSQTY.itmNo as No,T_STKSQTY.storeNo as NmE,(select Arb_Des from T_Items where T_Items.Itm_No = T_STKSQTY.itmNo ) as NmA";
                _RepShow.Rule = "where stkQty = 0 and stkInt = 0 and T_STKSQTY.itmNo not in (select T_INVDET.ItmNo from T_INVDET where T_INVDET.ItmNo = T_STKSQTY.itmNo and T_INVDET.StoreNo = T_STKSQTY.storeNo)";
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
                if (VarGeneral.RepData.Tables[0].Rows.Count > 0)
                {
                    db.ExecuteCommand("DELETE FROM [dbo].[T_STKSQTY] where T_STKSQTY.stkQty = 0 and T_STKSQTY.stkInt = 0 and T_STKSQTY.itmNo not in (select T_INVDET.ItmNo from T_INVDET where T_INVDET.ItmNo = T_STKSQTY.itmNo and T_INVDET.StoreNo = T_STKSQTY.storeNo) ");
                    db.ExecuteCommand("DELETE FROM [dbo].[T_QTYEXP] where T_QTYEXP.stkQty = 0 and T_QTYEXP.itmNo not in (select T_INVDET.ItmNo from T_INVDET where T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.StoreNo = T_QTYEXP.storeNo) ");
                    Close();
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }
    }
}
