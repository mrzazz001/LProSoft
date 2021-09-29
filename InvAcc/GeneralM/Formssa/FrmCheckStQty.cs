using DevComponents.DotNetBar;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Library.RepShow;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmCheckStQty : Form
    {
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private bool tp = false;
        private int LangArEn = 0;
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
            InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCheckStQty));
            components = new System.ComponentModel.Container();
            this.ButExit = new DevComponents.DotNetBar.ButtonX();
            this.ButShow = new DevComponents.DotNetBar.ButtonX();
            this.ButDel = new DevComponents.DotNetBar.ButtonX();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.SuspendLayout();
            // 
            // ButExit
            // 
            this.ButExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButExit.Checked = true;
            this.ButExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ButExit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButExit.Location = new System.Drawing.Point(10, 151);
            this.ButExit.Name = "ButExit";
            this.ButExit.Size = new System.Drawing.Size(218, 60);
            this.ButExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButExit.Symbol = "";
            this.ButExit.SymbolSize = 16F;
            this.ButExit.TabIndex = 6785;
            this.ButExit.Text = "خـــروج";
            this.ButExit.TextColor = System.Drawing.Color.Black;
            this.ButExit.Click += new System.EventHandler(this.ButExit_Click);
            // 
            // ButShow
            // 
            this.ButShow.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButShow.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.ButShow.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButShow.Location = new System.Drawing.Point(10, 11);
            this.ButShow.Name = "ButShow";
            this.ButShow.Size = new System.Drawing.Size(218, 60);
            this.ButShow.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButShow.Symbol = "";
            this.ButShow.SymbolSize = 16F;
            this.ButShow.TabIndex = 6784;
            this.ButShow.Text = "عــــرض";
            this.ButShow.TextColor = System.Drawing.Color.White;
            this.ButShow.Click += new System.EventHandler(this.ButShow_Click);
            // 
            // ButDel
            // 
            this.ButDel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButDel.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.ButDel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButDel.Location = new System.Drawing.Point(10, 81);
            this.ButDel.Name = "ButDel";
            this.ButDel.Size = new System.Drawing.Size(218, 60);
            this.ButDel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButDel.Symbol = "";
            this.ButDel.SymbolSize = 16F;
            this.ButDel.TabIndex = 6786;
            this.ButDel.Text = "حـــذف الأصناف";
            this.ButDel.TextColor = System.Drawing.Color.White;
            this.ButDel.Click += new System.EventHandler(this.ButDel_Click);
            // 
            // FrmCheckStQty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(238, 219);
            this.ControlBox = false;
            this.Controls.Add(this.ButDel);
            this.Controls.Add(this.ButExit);
            this.Controls.Add(this.ButShow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.Name = "FrmCheckStQty";
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الأصناف المعلقة في المستودعات";
            this.Load += new System.EventHandler(this.FrmCheckStQty_Load);
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.ResumeLayout(false);
        }
    }
}
