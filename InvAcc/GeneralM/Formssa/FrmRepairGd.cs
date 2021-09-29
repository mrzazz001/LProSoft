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
    public partial class FrmRepairGd : Form
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
            label10 = new System.Windows.Forms.Label();
            components = new System.ComponentModel.Container();

            CmbTyp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            ButExit = new DevComponents.DotNetBar.ButtonX();
            ButOk = new DevComponents.DotNetBar.ButtonX();
            SuspendLayout();
            label10.AutoSize = true;
            label10.BackColor = System.Drawing.Color.Transparent;
            label10.Font = new System.Drawing.Font("Tahoma", 8f, System.Drawing.FontStyle.Bold);
            label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label10.Location = new System.Drawing.Point(298, 25);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(77, 13);
            label10.TabIndex = 1152;
            label10.Text = "نوع السنــــد :";
            CmbTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            CmbTyp.DisplayMember = "Text";
            CmbTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            CmbTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CmbTyp.FormattingEnabled = true;
            CmbTyp.ItemHeight = 14;
            CmbTyp.Location = new System.Drawing.Point(65, 52);
            CmbTyp.Name = "CmbTyp";
            CmbTyp.Size = new System.Drawing.Size(307, 20);
            CmbTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            CmbTyp.TabIndex = 1151;
            ButExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            ButExit.Checked = true;
            ButExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            ButExit.Font = new System.Drawing.Font("Tahoma", 8f, System.Drawing.FontStyle.Bold);
            ButExit.Location = new System.Drawing.Point(12, 105);
            ButExit.Name = "ButExit";
            ButExit.Size = new System.Drawing.Size(193, 35);
            ButExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButExit.Symbol = "\uf011";
            ButExit.SymbolSize = 16f;
            ButExit.TabIndex = 1154;
            ButExit.Text = "خـــروج";
            ButExit.TextColor = System.Drawing.Color.Black;
            ButExit.Click += new System.EventHandler(ButExit_Click);
            ButOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            ButOk.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            ButOk.Font = new System.Drawing.Font("Tahoma", 8f, System.Drawing.FontStyle.Bold);
            ButOk.Location = new System.Drawing.Point(210, 105);
            ButOk.Name = "ButOk";
            ButOk.Size = new System.Drawing.Size(193, 35);
            ButOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButOk.Symbol = "\uf0c5";
            ButOk.SymbolSize = 16f;
            ButOk.TabIndex = 1153;
            ButOk.Text = "صيانة";
            ButOk.TextColor = System.Drawing.Color.White;
            ButOk.Click += new System.EventHandler(ButOk_Click);
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            base.ClientSize = new System.Drawing.Size(427, 161);
            base.ControlBox = false;
            base.Controls.Add(ButExit);
            base.Controls.Add(ButOk);
            base.Controls.Add(label10);
            base.Controls.Add(CmbTyp);
            base.KeyPreview = true;
            base.Name = "FrmRepairGd";
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            base.ShowIcon = false;
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "صيانة ارقام القيود";
            base.Load += new System.EventHandler(FrmRepairGd_Load);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmRepairGd_KeyDown);
            ResumeLayout(false);
            PerformLayout();
        }
        public FrmRepairGd()
        {
            InitializeComponent();
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
                        this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
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
