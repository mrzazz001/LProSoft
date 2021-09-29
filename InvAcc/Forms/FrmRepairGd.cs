using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmRepairGd : Form
    { void avs(int arln)

{ 
 Text = "نوع السنــــد :";this.Text=   (arln == 0 ? "  نوع السنــــد :  " : "  Bond type:") ; Text = "خـــروج";this.Text=   (arln == 0 ? "  خـــروج  " : "  Close") ; Text = "صيانة";this.Text=   (arln == 0 ? "  صيانة  " : "  Maintenance") ;}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
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
        private Label label10;
        private ComboBoxEx CmbTyp;
        private ButtonX ButExit;
        private ButtonX ButOk;
        private Stock_DataDataContext dbInstance;
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
        public FrmRepairGd()
        {
            InitializeComponent();this.Load += langloads;
        }
        private void ButExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void FrmRepairGd_Load(object sender, EventArgs e)
        {
            CmbTyp.Items.Add("سندات القيد اليومية");
            CmbTyp.Items.Add("سندات القبض");
            CmbTyp.Items.Add("سندات الصرف");
            CmbTyp.SelectedIndex = 0;
        }
        private void FrmRepairGd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            List<T_GDHEAD> _Data = db.T_GDHEADs.Where((T_GDHEAD t) => t.gdTyp == (int?)((CmbTyp.SelectedIndex == 0) ? 11 : ((CmbTyp.SelectedIndex == 1) ? 12 : 13))).ToList();
            List<string> Query = (from c in _Data
                                  group c by new
                                  {
                                      c.gdNo
                                  } into g
                                  where g.Count() > 1
                                  select g.Key.gdNo).ToList();
            if (Query.Count > 0)
            {
                int c2 = 0;
                while (true)
                {
                    if (c2 >= Query.Count)
                    {
                        break;
                    }
                    List<T_GDHEAD> _list = (from t in db.T_GDHEADs
                                            where t.gdTyp == (int?)((CmbTyp.SelectedIndex == 0) ? 11 : ((CmbTyp.SelectedIndex == 1) ? 12 : 13))
                                            where t.gdNo == Query[c2]
                                            orderby t.gdhead_ID
                                            select t).ToList();
                    _list.RemoveAt(0);
                    for (int iicnt = 0; iicnt < _list.Count; iicnt++)
                    {
                        VarGeneral.InvTyp = ((CmbTyp.SelectedIndex == 0) ? 11 : ((CmbTyp.SelectedIndex == 1) ? 12 : 13));
                        string NewID = db.MaxGDHEADsNo.ToString();
                        List<T_GDDET> _Det = _list[iicnt].T_GDDETs.ToList();
                        for (int i = 0; i < _Det.Count; i++)
                        {
                            T_GDDET _DataDet = new T_GDDET();
                            _DataDet = _Det[i];
                            _DataDet.gdNo = NewID;
                            db.Log = VarGeneral.DebugLog;
                            db.SubmitChanges(ConflictMode.ContinueOnConflict);
                        }
                        T_GDHEAD _GdData = new T_GDHEAD();
                        this.netResize1 = new Softgroup.NetResize.NetResize(this.components);  this.netResize1.LabelsAutoEllipse = false;
                        this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
                        this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
                        this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
                        ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
                        _GdData = _list[iicnt];
                        _GdData.gdNo = NewID;
                        db.Log = VarGeneral.DebugLog;
                        db.SubmitChanges(ConflictMode.ContinueOnConflict);
                    }
                    c2++;
                }
            }
            Close();
        }
    }
}
