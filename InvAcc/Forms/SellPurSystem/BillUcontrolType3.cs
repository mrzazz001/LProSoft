using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProShared.Stock_Data;
using DevExpress.XtraTreeList.Nodes;
using System.Data.Linq;
using System.IO;
using InvAcc;
using Framework.Data;
using ProShared.GeneralM;
using ProShared;
using DevComponents.DotNetBar;
using Padding = System.Windows.Forms.Padding;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevComponents.DotNetBar.Controls;
using InvAcc.Forms;
using DevComponents.Editors;
using Library.RepShow;
using System.Drawing.Printing;

namespace InvAcc
{
    public partial class BillUcontrolType3 : UserControl
    {
        public BindingList<InvPfiled> DataList = new BindingList<InvPfiled>();
        public BindingSource t_GDDETsBindingSource34 = new BindingSource();
        public BillUcontrolType3()
        {
            try
            {
                InitializeComponent();

            }
            catch { }
            
        }
        Stock_DataDataContext _dsb;
        public BindingSource taxtypesbinding_source = new BindingSource();
        public BindingList<Suppliers> types = new BindingList<Suppliers>();
            public BindingList<TaxTypes> taxtypes = new BindingList<TaxTypes>();
        public BindingSource Suppliers_BindingSource = new BindingSource();
        private PopupHelper m_popup;
        private void ShowPopup()
        {
            _toolStripDropDown.AutoClose = true;
            _toolStripDropDown.ForeColor = Color.Black;

            treeList1.ForeColor = Color.Black;

            _toolStripDropDown.Show(100, 100);


        }
        private void dlsfjas(object sender, ToolStripDropDownClosingEventArgs e)
        {
            e.Cancel = false;
        }

        bool _IsOpen;
        public class PanelMenuItem : ToolStripControlHost
        {
            Panel panel;
            public PanelMenuItem(Panel d)
              : base(d)
            {
                panel = d;
                Visible = true;
                Enabled = true;
                panel.AutoSize = false;
                panel.Size = new Size(100, 50);

                panel.MinimumSize = panel.Size;
            }
            public void show()
            {
                panel.Show();

            }
        }
        public ComboBoxEx CmbLegate;
        public ComboBoxEx CmbCostC;
        public ComboBoxEx CmbCurr;
        public CheckBoxX checkBox_CostGaidTax;
        public CheckBoxX ChkA4Cahir;
        private ToolStripControlHost tsHost;
        private ToolStripDropDown tsDrop = new ToolStripDropDown();
        Stock_DataDataContext db
        {
            get {
                try
                {
                    if (_dsb == null)
                    {
                        _dsb = new Stock_DataDataContext(VarGeneral.BranchCS);

                    }
                }
                catch { }
                return _dsb;
            }
        }

        public string AccCrdt_Cost = "";

        public string AccDbbt_Cost = "";
        public bool deleteDatailsGaids(int lk)
        {
            List<T_GDHEAD> v = (from d in db.T_GDHEADs where d.gdTyp == VarGeneral.ServiceBillId && d.gdNo == lk.ToString() select d).ToList();
            db_ = Database.GetDatabase(VarGeneral.BranchCS);
            foreach (T_GDHEAD a in v)
            {
                List<T_GDDET> q = (from k in db.T_GDDETs
                                   where k.gdID== a.gdhead_ID select k).ToList();


                for (int i = 0; i < q.Count; i++)
                {
                    db_.StartTransaction();
                    db_.ClearParameters();
                    db_.AddParameter("GDDET_ID", DbType.Int32, q[i].GDDET_ID);
                    db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_DELETE");
                    db_.EndTransaction();
                }
            }
            v = (from d in db.T_GDHEADs where d.gdTyp == VarGeneral.InvTyp && d.gdNo == lk.ToString() select d).ToList();
            db_ = Database.GetDatabase(VarGeneral.BranchCS);
            foreach (T_GDHEAD a in v)
            {
                List<T_GDDET> q = (from k in db.T_GDDETs
                                   where k.gdID == a.gdhead_ID|| k.gdID==null
                                   select k).ToList();


                for (int i = 0; i < q.Count; i++)
                {
                    db_.StartTransaction();
                    db_.ClearParameters();
                    db_.AddParameter("GDDET_ID", DbType.Int32, q[i].GDDET_ID);
                    db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_DELETE");
                    db_.EndTransaction();
                }
            }
            return true;        
        
        
        }bool _isCashe = true;
        public bool isCashe
        {
            get
            {
                return _isCashe;
            }
            set
            {
                _isCashe = value;
                try
                {
                    if (value)
                    {
                        db_ = Database.GetDatabase(VarGeneral.BranchCS);
                        daf = db.FillAccDef_2("", 4, 2).ToList();
                        t_AccDefsBindingSource2.DataSource = daf;
                        lookUpEditWithDataSource1.Properties.DataSource = t_AccDefsBindingSource2;
                        layoutControlItem7.Text = "الصندوق";
                    }
                    else
                    {
                        db_ = Database.GetDatabase(VarGeneral.BranchCS);
                        daf = db.T_AccDefs.ToList();
                        t_AccDefsBindingSource2.DataSource = daf;
                        lookUpEditWithDataSource1.Properties.DataSource = t_AccDefsBindingSource2;
                        layoutControlItem7.Text = "الحساب الدائن";

                    }
                }
                catch { }
            }
        }
        public bool disTaxGaid = false;
        public void savedraft()
        {
            List<T_GDDET> d = getDetailsGaids();
            foreach(T_GDDET i in d)
            {
                T_TempGDDET k = new T_TempGDDET();
                k.gdNo = CurrentBill.InvHed_ID.ToString();
                k.AccName = i.AccName;
                k.AccNo = i.AccNo;
                k.AccNoDestruction = i.AccNoDestruction;
                k.gdDes = i.gdDes;
                k.gdDesE = i.gdDesE;
                k.gdValue = i.gdValue;
                k.Lin = i.Lin;
                k.recptNo = i.recptNo;
                k.recptNo = i.recptTyp;
                db.T_TempGDDET.InsertOnSubmit(k);

            }
            db.SubmitChanges();
        }
        public bool insertgaid(T_GDHEAD data_dthis, List<T_GDDET> DetaislsGaid, bool isupdate = false)
        {
           
            int ic = 1;
            currentGH = data_dthis;
            if (isupdate) deleteDatailsGaids(int.Parse(CurrentBill.InvNo));
            db_ = Database.GetDatabase(VarGeneral.BranchCS);
            db_.StartTransaction();
            db_.ClearParameters();
            db_.AddParameter("GDDET_ID", DbType.Int32, 0);
            db_.AddParameter("gdID", DbType.Int32, data_dthis.gdhead_ID);
            db_.AddParameter("gdNo", DbType.String, data_dthis.gdNo);
            db_.AddParameter("gdDes", DbType.String, "مصروفات مشتريات ");
            db_.AddParameter("gdDesE", DbType.String, textEdit1.Text);
            db_.AddParameter("recptTyp", DbType.String, recptTyp.ToString());
            db_.AddParameter("AccNo", DbType.String, lookUpEditWithDataSource1.EditValue.ToString());
            db_.AddParameter("AccName", DbType.String, lookUpEditWithDataSource1.Text);
            db_.AddParameter("gdValue", DbType.Double, 0.0 - txtDueAmountLoc.Value);
            db_.AddParameter("recptNo", DbType.String, data_dthis.gdNo);
            db_.AddParameter("Lin", DbType.Int32, 0);
            db_.AddParameter("AccNoDestruction", DbType.String, null);
            db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
            db_.EndTransaction();
            if (checkBox_CostGaidTax.Checked == true) CreateCostGaidTax(AccCrdt_Cost, AccDbbt_Cost);
            t_GDDETsBindingSource34.EndEdit();
            int ks = 0;
            int lin = 1;
            foreach (T_GDDET k in DetaislsGaid)
            {

                try
                {
                    if (k != null)
                    {
                        cash(data_dthis,DetaislsGaid,k,ref lin,ref ks,ref ic);
                       
                      
                    }
                }
                catch(Exception ex)
                {
                    return false;
                    //             goto Label1;
                }

            
            }
        
            try
            {
                Stock_DataDataContext stock_DataDataContext = new Stock_DataDataContext(VarGeneral.BranchCS);
                List<T_GDDET> q = (from t in stock_DataDataContext.T_GDDETs
                                   where t.gdNo == data_this.gdNo
                                   where t.T_GDHEAD.gdTyp == (int?)VarGeneral.ServiceBillId
                                   select t).ToList();
                if (q.Count <= 0)
                {
                    stock_DataDataContext.ExecuteCommand("DELETE FROM [T_GDHEAD] WHERE gdNo = '" + data_this.gdNo + "' and gdTyp =" + VarGeneral.ServiceBillId);

                }
            }
            catch
            {
            }
            _dsb = null; return true;
        }List<T_AccDef> daf = new List<T_AccDef>();
        public void init()
        {
            if (IsInitiated == false)
            {
                db_ = Database.GetDatabase(VarGeneral.BranchCS);
             daf=db.FillAccDef_2("", 4, 2).ToList();
                t_AccDefsBindingSource2.DataSource = daf;
            }
            repositoryItemDateEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
repositoryItemDateEdit1.Properties.Mask.EditMask = "dd/MM/yyyy";
            repositoryItemDateEdit1.Properties.Mask.UseMaskAsDisplayFormat = true;
            // This line of code is generated by Data Source Configuration Wizard
            t_GDDETsBindingSource34.DataSource = DataList;
            t_GDDETsBindingSource34.AddingNew += t_GDDETsBindingSource34new;
            // This line of code is generated by Data Source Configuration Wizard
            t_AccDefsBindingSource.DataSource = db.T_AccDefs;
            // This line of code is generated by Data Source Configuration Wizard
            t_AccDefsBindingSource1.DataSource = db.T_AccDefs;
            // This line of code is generated by Data Source Configuration Wizard
                // This line of code is generated by Data Source Configuration Wizard
            t_AccDefsBindingSource3.DataSource = db.T_AccDefs;
            // This line of code is generated by Data Source Configuration Wizard
            t_CstTblsBindingSource.DataSource = db.T_CstTbls;
            gridControl1.DataSource = t_GDDETsBindingSource34;
            panel3.SendToBack();
            panel3.Visible = true;
            treeList1.Visible = true;
            simpleButton1_Click(null, null);

            panel3.Visible = false;
            treeList1.Visible = false;
            panel3.BringToFront();

            //    this.Controls.Remove(panel3);
            //          panel3.Visible = false;
            gridColumn7.FieldName = "taxvalue";
            //    treeList1.Visible = false;
            if (!IsInitiated)
            {
                taxtypes = new BindingList<TaxTypes>();
                taxtypes.Add(new TaxTypes());
                taxtypes[0].Type_Description = "ضريبة النسبة الاساسية";
                taxtypes[0].Percent = 15;
                taxtypes.Add(new TaxTypes()); taxtypes[1].Type_Description = "ضريبة النسبة الصفريه";
                taxtypes[1].Percent = 0;

                taxtypes.Add(new TaxTypes()); taxtypes[2].Type_Description = " معفاه من الضريبة";
                taxtypes[2].Percent = 0;
                foreach (T_AccDef k in db.T_AccDefs)
                {
                    Suppliers tt = new Suppliers();
                    tt.AccDef_No = k.AccDef_No;
                    tt.Arb_Des = k.Arb_Des;
                    types.Add(tt);
                }

            }
            // db.T_AccDefs.ToList().Where(i => i.Lev == 4 && (VarGeneral.SSSTyp == 0 ? i.AccDef_No == "1020001" : i.AccCat == 2 || i.AccCat == 3) && i.Sts == 0).ToList();
            lookUpEditWithDataSource1.Properties.DataSource = t_AccDefsBindingSource2;
            Suppliers_BindingSource.DataSource = types;
            repositoryItemLookUpEdit2.DataSource = Suppliers_BindingSource;
            repositoryItemLookUpEdit2.DisplayMember = "Arb_Des";
            repositoryItemLookUpEdit2.ValueMember = "Arb_Des";
            taxtypesbinding_source.DataSource = taxtypes;
            repositoryItemLookUpEdit5.DataSource = taxtypesbinding_source;
            repositoryItemLookUpEdit5.DisplayMember = "Type_Description";
            repositoryItemLookUpEdit5.ValueMember = "Type_Description";

            IsInitiated = true;
            //        _toolStripDropDown.TopLevel = false;
            //    Controls.Add(_toolStripDropDown); 
        }
        private ToolStripDropDown _toolStripDropDown = new ToolStripDropDown
        {
            //TopLevel = false,
            CanOverflow = true,
            AutoClose = false,
            AutoSize = false, RightToLeft = RightToLeft.Yes
        };
        public delegate void customMessageHandler(System.Object sender,
                                        EventHandler e);
        public event customMessageHandler Item_PriceChanged;
        private void t_GDDETsBindingSource34new(object sender, AddingNewEventArgs e)
        {
            InvPfiled t = new InvPfiled();
            t.Quantity = 1;

            t.Taxtype = "ضريبة النسبة الاساسية";

            e.NewObject = t;
        }

        private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn== gridColumn1)
            {
                if (e.Value == "" || e.Value == null)
                {
                    e.Valid = false;
                    e.ErrorText = "لا يمكن ان يكون المورد فارغا";
                }
                else
                    e.Valid = true;
            }
            if (view.FocusedColumn == colgdValue)
            {
                if (e.Value == "" || e.Value == null)
                {
                    e.Valid = false;
                    e.ErrorText = "لا يمكن ان يكون الحساب فارغا";
                }
                else
                    e.Valid = true;
            }
            if (gridView1.FocusedColumn == colgdValue)
            {
                InvPfiled td = t_GDDETsBindingSource34.Current as InvPfiled;
                colgdValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                td.withouttax = double.Parse(e.Value.ToString());// ((gridView1.GetRowCellValue(gridView1.FocusedRowHandle, colgdValue).ToString())));
                TaxTypes fff = taxtypesbinding_source.Current as TaxTypes;
                double percent = fff.Percent;
                e.Value= caltax(td.withouttax, percent);
                td.taxvalue = (td.withouttax - (double)e.Value);


            }
            if (view.FocusedColumn == gridColumn3)
            {
                if (e.Value == "" || e.Value == null)
                {
                    e.Valid = false;
                    e.ErrorText = "لا يمكن ان يكون رقم الفاتورة فارغا";
                }
                else
                    e.Valid = true;
            }

        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
        InvPfiled current;
        private void t_GDDETsBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {

        }

        private void treeList1_NodesReloaded(object sender, EventArgs e)
        {
            try
            {
                treeList1.Refresh();
                treeList1.Update();
                treeList1.BeforeCheckNode -= treeList1_BeforeCheckNode;
                string sa = File.ReadAllText(Application.StartupPath + "\\nodes.dlf");
                string[] v = sa.Split('#');
                foreach (string s in v)
                {
                    try
                    {
                        int k = int.Parse(s);
                        TreeListNode n = treeList1.FindNodeByID(k);
                        n.CheckState = CheckState.Checked;
                        n.Checked = true;

                    }
                    catch (Exception ex)
                    {

                    }
                }
                treeList1.Invalidate();

            }
            catch { }

            treeList1.BeforeCheckNode += treeList1_BeforeCheckNode;


        }
        public Panel getPanel()
        {
            return panel3;
        }
        public  bool IsInitiated = false;
        public delegate void custemeventdelegate(System.Object sender,
                                         EventArgs e);
        public event customMessageHandler showpanel;
        public event customMessageHandler settotals;
        public event customMessageHandler getDetails;
        public event customMessageHandler SetAccountBoxNumber;
        public void FireGet()
        {
         if(   getDetails!=null)
            {
                getDetails(null, null);
            }
        }
        void treeList1_BeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e)
        {
            TreeListNode node = e.Node;
            if (node.Checked)
            {
                node.UncheckAll();
            }
            else
            {
                node.CheckAll();
            }
            while (node.ParentNode != null)
            {
                node = node.ParentNode;
                bool oneOfChildIsChecked = OneOfChildsIsChecked(node);
                if (oneOfChildIsChecked)
                {
                    node.CheckState = CheckState.Checked;
                }
                else
                {
                    node.CheckState = CheckState.Unchecked;
                }
            }
        }
        private bool OneOfChildsIsChecked(TreeListNode node)
        {
            bool result = false;
            foreach (TreeListNode item in node.Nodes)
            {
                if (item.CheckState == CheckState.Checked)
                {
                    result = true;
                }
            }
            return result;
        }
        private void t_GDDETsBindingSource_PositionChanged(object sender, EventArgs e)
        {
            current = (InvPfiled)t_GDDETsBindingSource34.Current;
        }

        private void repositoryItemLookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lookUpEdit = (LookUpEdit)sender;
            var val = lookUpEdit.EditValue;
            //   T_AccDef es = (T_AccDef)(repositoryItemLookUpEdit2).GetDataSourceRowByKeyValue(val);


            Suppliers_BindingSource.Position = repositoryItemLookUpEdit2.GetDataSourceRowIndex(repositoryItemLookUpEdit4.ValueMember, val);

        }

        private void t_AccDefsBindingSource1_PositionChanged(object sender, EventArgs e)
        {

        }

        private void repositoryItemLookUpEdit2_EditValueChangedn(object sender, EventArgs e)
        {
            LookUpEdit lookUpEdit = (LookUpEdit)sender;
            var val = lookUpEdit.EditValue;
            //   T_AccDef es = (T_AccDef)(repositoryItemLookUpEdit2).GetDataSourceRowByKeyValue(val);


            t_CstTblsBindingSource.Position = repositoryItemLookUpEdit4.GetDataSourceRowIndex(repositoryItemLookUpEdit4.ValueMember, val);


        }

        private void repositoryItemLookUpEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (e.Button.Tag.ToString() == "1")
                {

                    treeList1.Visible = true;
                    if (showpanel != null) showpanel(null, null);



                }
            }
            catch { }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            var nodes = treeList1.Selection;
            List<T_AccDef> values = new List<T_AccDef>();
            Table<T_AccDef> tf = t_AccDefsBindingSource3.DataSource as Table<T_AccDef>;
            string sa = "";
            List<TreeListNode> a = treeList1.GetAllCheckedNodes();
            foreach (TreeListNode node in a)
            {
                if (!values.Contains(tf.ToList()[node.Id])
                            )
                {
                    values.Add(tf.ToList()[node.Id]);
                    sa += node.Id.ToString() + "#";
                }
            }

            if (values.Count != 0)
            {
                File.WriteAllText(Application.StartupPath + "\\nodes.dlf", sa);
                t_AccDefsBindingSource.DataSource = null;
                t_AccDefsBindingSource.DataSource = values;
                repositoryItemLookUpEdit1.DataSource = t_AccDefsBindingSource;
            }
            panel3.Visible = false;

        }

        private void XtraUserControl1_Load(object sender, EventArgs e)
        {

        }

    public    List<T_GDDET> DetailsGaid = new List<T_GDDET>();
        public double InvQty = 0;

        public double InvTot = 0.0;
        public double InvCost = 0.0;

        public double InvDis = 0.0;
        public double InvAdd = 0.0;
        public double InvAddLocak = 0.0;
        public double InvTax = 0.0;
        public double ItmDisCount = 0.0;
        public List<T_GDDET> getDetailsGaids()
        {
            DetailsGaid = new List<T_GDDET>();
            int ic = 1;
            foreach (InvPfiled i in DataList)
            {
                T_GDDET k = new T_GDDET();
                //k.GDDET_ID = 0;
                //k.gdID = g.gdhead_ID;
                //k.gdNo = g.gdNo;
                //k.recptTyp = recptTyp;
                //k.recptNo = g.gdhead_ID.ToString();
                //k.Lin = ic;
                k.AccNo = i.AccountNumber;
                k.gdValue = i.Price;
                InvCost+= i.Price;
                InvTot += i.Price;
                InvAdd += i.taxvalue;
                string ss = "";
                string spli = "#";
                ss += " مصروفات مشتريات ";
                ss += spli + i.Description;
                ss += spli + i.Supplier;
                ss += spli + i.SupplierNumber;
                ss += spli + i.BillNumber;
                ss += spli + i.Taxtype;
                
                ss += spli + i.CostCenter;
                ss += spli + i.Quantity;

                k.gdDes = ss;
                k.AccName = i.date;
                DetailsGaid.Add(k);
                ic++;
                InvQty++;
            }

            return DetailsGaid;
        }
        T_INVHED curr;
        T_GDDET currentGdd;
        T_GDHEAD cGd=null;
        public T_GDHEAD currentGH
            {

            get{return cGd;
            }
            set
            {
                cGd = value;

            }
    }
        public T_INVHED CurrentBill
        {
            get
            {
             return   curr;
            }
            set
            {
                curr = value;
      
            }
        }

        public string GdValue { get; private set; }
        public object CmbCurrSelectedValue;// { get; private set; }
        public object CmbCostCSelectedValue;// { get; private set; }
        public FormState State { get; private set; }
        T_GDHEAD _GdHeadCostTax;
        private T_GDHEAD GetDataGdCostTax()
        {
            ScriptNumber ScriptNumber1 = new ScriptNumber();
            _GdHeadCostTax.gdHDate = txtHDate.Text;
            _GdHeadCostTax.gdGDate = txtGDate.Text;
            _GdHeadCostTax.gdNo = CurrentBill.InvNo;
            _GdHeadCostTax.ArbTaf = ScriptNumber1.ScriptNum(decimal.Parse("0" + InvTax.ToString()));
            _GdHeadCostTax.BName = _GdHeadCostTax.BName;
            _GdHeadCostTax.ChekNo = _GdHeadCostTax.ChekNo;
            _GdHeadCostTax.CurTyp = int.Parse(CmbCurr.SelectedValue.ToString());
            _GdHeadCostTax.EngTaf = ScriptNumber1.TafEng(decimal.Parse("0" + txtTotTax.Text));
            _GdHeadCostTax.gdCstNo = int.Parse(CmbCostC.SelectedValue.ToString());
            _GdHeadCostTax.gdID = 0;
            _GdHeadCostTax.gdLok = false;
            _GdHeadCostTax.AdminLock = switchButton_Lock.Value;
            _GdHeadCostTax.gdMem = "سند بقيمة الضريبة|Tax Value";
            if (CmbLegate.SelectedIndex > 0)
            {
                _GdHeadCostTax.gdMnd = int.Parse(CmbLegate.SelectedValue.ToString());
            }
            else
            {
                _GdHeadCostTax.gdMnd = null;
            }
            _GdHeadCostTax.gdRcptID = (_GdHeadCostTax.gdRcptID.HasValue ? _GdHeadCostTax.gdRcptID.Value : 0.0);
            _GdHeadCostTax.gdTot = txtTotTax.Value;
            _GdHeadCostTax.gdTp = (_GdHeadCostTax.gdTp.HasValue ? _GdHeadCostTax.gdTp.Value : 0);
            _GdHeadCostTax.gdTyp = VarGeneral.InvTyp;
            _GdHeadCostTax.RefNo = txtRefText;
            _GdHeadCostTax.DATE_MODIFIED = DateTime.Now;
            _GdHeadCostTax.salMonth = "";
            _GdHeadCostTax.gdUser = VarGeneral.UserNumber;
            _GdHeadCostTax.gdUserNam = VarGeneral.UserNameA;
            _GdHeadCostTax.CompanyID = 1;
            return _GdHeadCostTax;
        }

        private void CreateCostGaidTax(string AccCrdt_Cost, string AccDbt_Cost, string sss = "سند بقيمة الضريبة مصروفات مشتريات رقم : ")
        {
            _dsb = null;
           CurrentBill = db.StockInvHead(VarGeneral.ServiceBillId, currentGH.gdNo);
            IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
            using (Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS))
            {
                _GdHeadCostTax = new T_GDHEAD();
                if (!CurrentBill.TaxGaidID.HasValue)
                {
                    GetDataGdCostTax();
                    _GdHeadCostTax.DATE_CREATED = DateTime.Now;
                    dbc.T_GDHEADs.InsertOnSubmit(_GdHeadCostTax);
                    dbc.SubmitChanges();
                }
                else
                {
                    _GdHeadCostTax = dbc.StockGdHeadid((int)CurrentBill.TaxGaidID.Value).First();
                    GetDataGdCostTax();
                    dbc.Log = VarGeneral.DebugLog;
                    dbc.SubmitChanges(ConflictMode.ContinueOnConflict);
                    for (int i = 0; i < _GdHeadCostTax.T_GDDETs.Count; i++)
                    {
                        db_.StartTransaction();
                        db_.ClearParameters();
                        db_.AddParameter("GDDET_ID", DbType.Int32, _GdHeadCostTax.T_GDDETs[i].GDDET_ID);
                        db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_DELETE");
                        db_.EndTransaction();
                    }
                }

                if (!disTaxGaid&&checkBox_CostGaidTax.Checked == true)
                {
                    db_.StartTransaction();
                    db_.ClearParameters();
                    db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                    db_.AddParameter("gdID", DbType.Int32, _GdHeadCostTax.gdhead_ID);
                    db_.AddParameter("gdNo", DbType.String, CurrentBill.InvNo);
                    db_.AddParameter("gdDes", DbType.String,"سند بقيمة ضريبة مصروفات مشتريات رقم :"+CurrentBill.InvNo);
                    db_.AddParameter("recptTyp", DbType.String, "1");
                    db_.AddParameter("gdDesE", DbType.String, "Tax Value To Puchase Invoice No : " + CurrentBill.InvNo);
                    db_.AddParameter("AccNo", DbType.String, AccCrdt_Cost);
                    db_.AddParameter("AccName", DbType.String, "");
                    db_.AddParameter("gdValue", DbType.Double, 0.0 -(_GdHeadCostTax.gdTot));
                    db_.AddParameter("recptNo", DbType.String, CurrentBill.InvNo);
                    db_.AddParameter("Lin", DbType.Int32, 2);  
                    db_.AddParameter("AccNoDestruction", DbType.String, null);
                    db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                    db_.EndTransaction();
                    db_.StartTransaction();
                    db_.ClearParameters();
                    db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                    db_.AddParameter("gdID", DbType.Int32, _GdHeadCostTax.gdhead_ID);
                    db_.AddParameter("gdNo", DbType.String, CurrentBill.InvNo);
                    db_.AddParameter("gdDes", DbType.String, "سند بقيمة ضريبة مصروفات مشتريات رقم :" + CurrentBill.InvNo);
                    db_.AddParameter("recptTyp", DbType.String, "1");
                    db_.AddParameter("gdDesE", DbType.String, "Tax Value To Puchase Invoice No : " + CurrentBill.InvNo);
                    db_.AddParameter("AccNo", DbType.String, AccDbbt_Cost);
                    db_.AddParameter("AccName", DbType.String, "");
                    db_.AddParameter("gdValue", DbType.Double,(_GdHeadCostTax.gdTot));
                    db_.AddParameter("recptNo", DbType.String, CurrentBill.InvNo);
                    db_.AddParameter("Lin", DbType.Int32, 1);  
                    db_.AddParameter("AccNoDestruction", DbType.String, null);
                    db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                    db_.EndTransaction();
                 
                }

            }

            CurrentBill.TaxGaidID = _GdHeadCostTax.gdhead_ID;
            db.Log = VarGeneral.DebugLog;
            db.SubmitChanges(ConflictMode.ContinueOnConflict);
        }

        public void createCash()
        {
            db_.StartTransaction();
            db_.ClearParameters();
            db_.AddParameter("GDDET_ID", DbType.Int32, 0);
            db_.AddParameter("gdID", DbType.Int32, currentGH.gdhead_ID);
            db_.AddParameter("gdNo", DbType.String, CurrentBill.InvNo);
            db_.AddParameter("gdDes", DbType.String, "قيد تلقائي لفاتورة مشتريات رقم : " + CurrentBill.InvNo);
            db_.AddParameter("gdDesE", DbType.String, "Auto Bound To Puchase Invoice No : " + CurrentBill.InvNo);
            db_.AddParameter("recptTyp", DbType.String, "1");
            db_.AddParameter("AccNo", DbType.String, currentGdd.AccNo);
            db_.AddParameter("AccName", DbType.String, "");
            db_.AddParameter("gdValue", DbType.Double, 0.0 - double.Parse(currentGdd.gdValue.ToString()));
            db_.AddParameter("recptNo", DbType.String, CurrentBill.InvNo);
            db_.AddParameter("Lin", DbType.Int32, 1);
            db_.AddParameter("AccNoDestruction", DbType.String, null);
            db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
            db_.EndTransaction();
            db_.StartTransaction();
            db_.ClearParameters();
            db_.AddParameter("GDDET_ID", DbType.Int32, 0);
            db_.AddParameter("gdID", DbType.Int32, currentGH.gdhead_ID);
            db_.AddParameter("gdNo", DbType.String, CurrentBill.InvNo);
            db_.AddParameter("gdDes", DbType.String, "قيد تلقائي لفاتورة مشتريات رقم : " + CurrentBill.InvNo);
            db_.AddParameter("gdDesE", DbType.String, "Auto Bound To Puchase Invoice No : " + CurrentBill.InvNo);
            db_.AddParameter("recptTyp", DbType.String, "1");
            db_.AddParameter("AccNo", DbType.String, currentGdd.AccNo);
            db_.AddParameter("AccName", DbType.String, "");
            db_.AddParameter("gdValue", DbType.Double, double.Parse(current.Price.ToString()));
            db_.AddParameter("recptNo", DbType.String, CurrentBill.InvNo);
            db_.AddParameter("Lin", DbType.Int32, 1);
            db_.AddParameter("AccNoDestruction", DbType.String, null);
            db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
            db_.EndTransaction();

        }
        IDatabase db_ ;
        private string txtDueAmountLocText;
        private string txtRemarkText;
        private double txtDueAmountLocValue;
        private bool switchButton_LockValue;
       
        private string txtRefText;
        T_GDHEAD data_this;
        private string recptTyp = "1";

        private void savedatda()
        {if(State==FormState.New)
            {
                currentGH = new T_GDHEAD();
                GetDataGd();
            }

            //string update = @" UPDATE T_AccDef SET T_AccDef.Debit = T_AccDef.Debit + ROUND( T_GDDET.gdValue, case when Substring((select MAX(T_SYSSETTING.Seting) from T_SYSSETTING),49,1) = 0 then 2 else 3 end)


            //                            From T_AccDef Left Join T_GDDET ON(T_AccDef.AccDef_No = T_GDDET.AccNo)
            //                              where @GDDET_ID = GDDET_ID and T_GDDET.gdValue > 0;
            //UPDATE T_AccDef SET T_AccDef.Credit = T_AccDef.Credit + ABS(ROUND(T_GDDET.gdValue, case when Substring((select MAX(T_SYSSETTING.Seting) from T_SYSSETTING), 49, 1) = 0 then 2 else 3 end))
            //                              From T_AccDef Left Join T_GDDET ON(T_AccDef.AccDef_No = T_GDDET.AccNo)
            //                              where @GDDET_ID = GDDET_ID and T_GDDET.gdValue < 0;
            //UPDATE T_AccDef SET T_AccDef.Balance = T_AccDef.Debit - T_AccDef.Credit
            //                              From T_AccDef Left Join T_GDDET ON(T_AccDef.AccDef_No = T_GDDET.AccNo)
            //                              where @GDDET_ID = GDDET_ID; ";

            //db.ExecuteCommand(update.Replace("@GDDET_ID", data_this.gdhead_ID.ToString()), new object[0]);
            //return;
            data_this = currentGH;
        //    data_this.T_GDDETs.AddRange(getDetailsGaids());

            if (true)
            {
                try
                {
                    IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
                    if (this.State != FormState.New)
                    {
                      
                        this.data_this.MODIFIED_BY = VarGeneral.UserNumber;
                        this.db.Log = VarGeneral.DebugLog;
                        this.db.SubmitChanges(ConflictMode.ContinueOnConflict);
                        for (int i = 0; i < this.data_this.T_GDDETs.Count; i++)
                        {
                            db_.StartTransaction();
                            db_.ClearParameters();
                            db_.AddParameter("GDDET_ID", DbType.Int32, this.data_this.T_GDDETs[i].GDDET_ID);
                            db_.ExecuteNonQueryWithoutCommit(true, "S_T_GDDET_DELETE");
                            db_.EndTransaction();
                        }
                    }
                    else
                    {
                        Stock_DataDataContext dbGaid = new Stock_DataDataContext(VarGeneral.BranchCS);
                    }
                    T_GDHEAD cu = data_this;
                    db_ = Database.GetDatabase(VarGeneral.BranchCS);
                    db_.StartTransaction();
                    db_.ClearParameters();
                    db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                    db_.AddParameter("gdID", DbType.Int32, cu.gdID);
                    db_.AddParameter("gdNo", DbType.String, cu.gdNo);
                    db_.AddParameter("gdDes", DbType.String, cu.T_GDDETs[0].gdDes);
                    db_.AddParameter("gdDesE", DbType.String, cu.T_GDDETs[0].gdDesE);
                    db_.AddParameter("recptTyp", DbType.String, recptTyp.ToString());
                    db_.AddParameter("AccNo", DbType.String, this.lookUpEditWithDataSource1.EditValue.ToString());
                    db_.AddParameter("AccName", DbType.String, this.lookUpEditWithDataSource1.Text.ToString());
                    db_.AddParameter("gdValue", DbType.Double, cu.T_GDDETs[0].gdValue);
                    db_.AddParameter("recptNo", DbType.String, cu.gdNo);
                    db_.AddParameter("Lin", DbType.Int32, 0);
                    db_.AddParameter("AccNoDestruction", DbType.String, null);
                    db_.ExecuteNonQueryWithoutCommit(true, "S_T_GDDET_INSERT");
                    db_.EndTransaction();
                    int iiCnt = 0;
                   foreach(T_GDDET k in DetailsGaid)
                    {

                        try
                        {
                            if (k!=null)
                            {
                                db_.StartTransaction();
                                db_.ClearParameters();
                                db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                                db_.AddParameter("gdID", DbType.Int32, this.data_this.gdhead_ID);
                                db_.AddParameter("gdNo", DbType.String, this.data_this.gdNo.ToString());
                                db_.AddParameter("gdDes", DbType.String, k.gdDes);
                                try
                                {
                                    db_.AddParameter("gdDesE", DbType.String,k.gdDesE);
                                }
                                catch
                                {
                                    db_.AddParameter("gdDesE", DbType.String, " ");
                                }
                                db_.AddParameter("recptTyp", DbType.String, recptTyp.ToString());
                                db_.AddParameter("AccNo", DbType.String,k.AccNo);
                                db_.AddParameter("AccName", DbType.String, k.AccName);
                                if (double.Parse(k.gdValue.Value.ToString()) > 0)
                                {
                                    db_.AddParameter("gdValue", DbType.Double, double.Parse(k.gdValue.Value.ToString()));
                                }
                                else if (double.Parse(k.gdValue.Value.ToString()) > 0)
                                {
                                    db_.AddParameter("gdValue", DbType.Double, -double.Parse(k.gdValue.Value.ToString()));
                                }
                                db_.AddParameter("recptNo", DbType.String, this.data_this.gdhead_ID);
                                db_.AddParameter("Lin", DbType.Int32, iiCnt);
                                db_.AddParameter("AccNoDestruction", DbType.String, null);
                                db_.ExecuteNonQueryWithoutCommit(true, "S_T_GDDET_INSERT");
                                db_.EndTransaction();
                            }
                        }
                        catch
                        {
                            //             goto Label1;
                        }
                    }
                   

                    MessageBox.Show((VarGeneral.currentintlanguage == 0 ? "تمت عملية حفظ البيانات بنجاح .." : "Save Data Is Done"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    try
                    {
                        Stock_DataDataContext _DB = new Stock_DataDataContext(VarGeneral.BranchCS);
                        try
                        {
                            if ((
                                from t in _DB.T_GDDETs
                                where t.gdNo == this.data_this.gdNo
                                where t.T_GDHEAD.gdTyp == (int?)VarGeneral.ServiceBillId
                                select t).ToList<T_GDDET>().Count <= 0)
                            {
                                object[] dataThis = new object[] { "DELETE FROM [T_GDHEAD] WHERE gdNo = '", this.data_this.gdNo, "' and gdTyp =", VarGeneral.ServiceBillId };
                                _DB.ExecuteCommand(string.Concat(dataThis), new object[0]);

                            }
                        }
                        finally
                        {
                            if (_DB != null)
                            {
                                ((IDisposable)_DB).Dispose();
                            }
                        }
                    }
                    catch
                    {
                    }
                }
                catch (Exception exception1)
                {
                    Stock_DataDataContext _DB;
                    Exception ex = exception1;
                    try
                    {
                        _DB = new Stock_DataDataContext(VarGeneral.BranchCS);
                        try
                        {
                            if ((
                                from t in _DB.T_GDDETs
                                where t.gdNo == this.data_this.gdNo
                                where t.T_GDHEAD.gdTyp == (int?)VarGeneral.ServiceBillId
                                select t).ToList<T_GDDET>().Count <= 0)
                            {
                                object[] dataThis = new object[] { "DELETE FROM [T_GDHEAD] WHERE gdNo = '", this.data_this.gdNo, "' and gdTyp =", VarGeneral.ServiceBillId };
                                _DB.ExecuteCommand(string.Concat(dataThis), new object[0]);

                            }
                        }
                        finally
                        {
                            if (_DB != null)
                            {
                                ((IDisposable)_DB).Dispose();
                            }
                        }
                    }
                    catch
                    {
                    }
                    MessageBox.Show(ex.Message);

                }
            }

        }

        internal void setreadonly(bool f)
        {
 
          //  dataLayoutControl1.OptionsView.IsReadOnly = (f ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False);
            gridView1.OptionsBehavior.Editable = !f;
        }

        public bool validate()
        {
            if (lookUpEditWithDataSource1.Properties.GetDisplayText(lookUpEditWithDataSource1.EditValue) == ""|| (lookUpEditWithDataSource1.EditValue)==null)
            {
                MessageBox.Show("يجب عليك تحديد الصندوق");
                lookUpEditWithDataSource1.Focus();
                return false;
            }
          
            return true;
        }
        public T_GDHEAD GetDataGd()
        {
            ScriptNumber ScriptNumber1 = new ScriptNumber();
            currentGH.gdHDate = txtHDate.Text;
            currentGH.gdGDate = txtGDate.Text;
            currentGH.gdNo = CurrentBill.InvNo;
            currentGH.ArbTaf = ScriptNumber1.ScriptNum(decimal.Parse("0" + txtDueAmountLocText));
            currentGH.BName = currentGH.BName;
            currentGH.ChekNo = currentGH.ChekNo;
            currentGH.CurTyp = int.Parse(CmbCurrSelectedValue.ToString());
            currentGH.EngTaf = ScriptNumber1.TafEng(decimal.Parse("0" + txtDueAmountLocText));
            currentGH.gdCstNo = int.Parse(CmbCostCSelectedValue.ToString());
            currentGH.gdID = 0;
            currentGH.gdLok = false;
            currentGH.gdMem = txtRemarkText;
            //if (CmbLegate.SelectedIndex > 0)
            //{
            //    currentGH.gdMnd = int.Parse(CmbLegate.SelectedValue.ToString());
            //}
            //else
            {
                currentGH.gdMnd = null;
            }
            currentGH.gdRcptID = (currentGH.gdRcptID.HasValue ? currentGH.gdRcptID.Value : 0.0);
            currentGH.gdTot = txtDueAmountLocValue;
            currentGH.gdTp = (currentGH.gdTp.HasValue ? currentGH.gdTp.Value : 0);
            currentGH.gdTyp = VarGeneral.ServiceBillId;
            currentGH.RefNo = txtRefText;
            currentGH.AdminLock = switchButton_LockValue;
            currentGH.DATE_MODIFIED = DateTime.Now;
            currentGH.salMonth = "";
            currentGH.gdUser = VarGeneral.UserNumber;
            currentGH.gdUserNam = VarGeneral.UserNameA;
            currentGH.CompanyID = 1;
            currentGH.T_GDDETs.Clear();
        //    currentGH.T_GDDETs.AddRange(getDetailsGaids());
            return currentGH;
        }
        public T_INVSETTING _InvSetting;
        public string buttonItem_PrintText;
        private int vStr(int vTy)
        {
            if (VarGeneral.ServiceBillId == 1)
            {
                if (VarGeneral._IsPOS)
                {
                    return 27;
                }
                return 1;
            }
            if (VarGeneral.ServiceBillId == 1)
            {
                return 1;
            }
            if (VarGeneral.ServiceBillId == 2)
            {
                return 5;
            }
            if (VarGeneral.ServiceBillId == 3)
            {
                return 3;
            }
            if (VarGeneral.ServiceBillId == 4)
            {
                return 7;
            }
            if (VarGeneral.ServiceBillId == 7)
            {
                return 9;
            }
            if (VarGeneral.ServiceBillId == 8)
            {
                return 11;
            }
            if (VarGeneral.ServiceBillId == 9)
            {
                return 13;
            }
            if (VarGeneral.ServiceBillId == 14)
            {
                return 15;
            }
            if (VarGeneral.ServiceBillId == 5)
            {
                return 17;
            }
            if (VarGeneral.ServiceBillId == 6)
            {
                return 19;
            }
            if (VarGeneral.ServiceBillId == 17)
            {
                return 21;
            }
            if (VarGeneral.ServiceBillId == 20)
            {
                return 23;
            }
            return 25;
        }

        public void print()
        {
            try
            {
                if (CurrentBill.InvNo != "" && State == FormState.Saved)
                {
                    if ((_InvSetting.InvpRINTERInfo.ISPOINTERType!=true))
                    {
                        VarGeneral.Print_set_Gen_Stat = false;
                        RepShow _RepShow = new RepShow();
                        _RepShow.Tables = "T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                        string vInvH = " T_INVHED.InvHed_ID, T_INVHED.InvId as vID, T_INVHED.InvNo, T_INVHED.InvTyp, T_INVHED.InvCashPay, T_INVHED.CusVenNo,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Arb_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNm,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Eng_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNmE, T_INVHED.CusVenAdd, T_INVHED.CusVenTel, T_INVHED.Remark, T_INVHED.HDat, T_INVHED.GDat, T_INVHED.MndNo, T_INVHED.SalsManNo, T_INVHED.SalsManNam, T_INVHED.InvTot, T_INVHED.InvDisPrs, ((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints, T_INVHED.InvNet, T_INVHED.InvNetLocCur, T_INVHED.CashPayLocCur, T_INVHED.IfRet, T_INVHED.CashPay, T_INVHED.InvTotLocCur, T_INVHED.InvDisValLocCur, T_INVHED.GadeNo, T_INVHED.GadeId, T_INVHED.RetNo, T_INVHED.RetId, T_INVHED.InvCashPayNm, T_INVHED.InvCost, T_INVHED.CustPri, T_INVHED.ArbTaf, T_INVHED.ToStore, T_INVHED.InvCash, T_INVHED.CurTyp, T_INVHED.EstDat,case when DATEDIFF(day, GETDATE(), EstDat) > 0 Then DATEDIFF(day, GETDATE(), EstDat) WHEN DATEDIFF(day, GETDATE(), InvCashPayNm) > 0 THEN DATEDIFF(day, GETDATE(), InvCashPayNm) Else '0' END as EstDatNote, T_INVHED.InvCstNo, T_INVHED.IfDel, T_INVHED.RefNo, T_INVHED.ToStoreNm, T_INVHED.EngTaf, T_INVHED.IfTrans, T_INVHED.InvQty, T_INVHED.CustNet, T_INVHED.CustRep, T_INVHED.InvWight_T, T_INVHED.IfPrint, T_INVHED.LTim, T_INVHED.DATE_CREATED, T_INVHED.MODIFIED_BY, T_INVHED.CreditPay, T_INVHED.DATE_MODIFIED, T_INVHED.CREATED_BY, T_INVHED.CreditPayLocCur, T_INVHED.NetworkPay, T_INVHED.NetworkPayLocCur, T_INVHED.MndExtrnal, T_INVHED.CompanyID, T_INVHED.InvAddCost, T_INVHED.InvAddCostExtrnal, T_INVHED.InvAddCostExtrnalLoc, T_INVHED.IsExtrnalGaid, T_INVHED.ExtrnalCostGaidID, T_INVHED.InvAddCostLoc, T_INVHED.CommMnd_Inv, T_INVHED.Puyaid, T_INVHED.Remming,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.PersonalNm from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as PersonalNm,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.City from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as City,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Email from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Email,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Mobile from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Mobile,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Telphone1 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Telphone1,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select vColStr1 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CustAge,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Telphone2 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Telphone2,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Fax from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Fax,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.zipCod from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as zipCod,T_SYSSETTING.LineGiftlNameA,T_SYSSETTING.LineGiftlNameE,T_Curency.Arb_Des as CurrnceyNm,T_Curency.Eng_Des as CurrnceyNmE,(select max(gdDes)from T_GDDET where gdID = T_INVHED.GadeId )as gdDes, (T_INVDET.Amount - (case when T_INVHED.IsTaxLines = 1 then (case when T_INVHED.IsTaxByTotal = 1 then (case when (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) > 0 then ((Abs(T_INVDET.Qty) *  T_INVDET.Price) - case when (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) > 0 then (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) else 0 end )* T_INVDET.ItmTax / 100   else 0 end) else (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) end) else 0 end )) as TotBeforeTax,(select invGdADesc from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as invGdADesc,(select invGdEDesc from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as invGdEDesc,(select T_CATEGORY.CAT_No from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CAT_No,(select T_CATEGORY.Arb_Des from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CatNmA,(select T_CATEGORY.Eng_Des from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CatNmE,(case when (select t.BarCod1 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit1 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod1 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit1 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt ))  when (select t.BarCod2 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit2 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod2 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit2 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod3 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit3 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod3 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit3 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod4 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit4 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod4 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit4 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod5 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit5 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod5 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit5 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) else T_Items.Itm_No  end) as ItmBarcod";
                        string Fields = " Abs(T_INVDET.Qty) as QtyAbs , T_INVDET.InvDet_ID,T_INVHED.tailor1,T_INVHED.tailor2,T_INVHED.tailor3,T_INVHED.tailor4,T_INVHED.tailor5,T_INVHED.tailor6,T_INVHED.tailor7,T_INVHED.tailor8,T_INVHED.tailor9,T_INVHED.tailor10,T_INVHED.tailor11,T_INVHED.tailor12,T_INVHED.tailor13,T_INVHED.tailor14,T_INVHED.tailor15,T_INVHED.tailor16,T_INVHED.tailor17,T_INVHED.tailor18,T_INVHED.tailor19,T_INVHED.tailor20,T_INVHED.InvImg, T_INVDET.InvNo, T_INVDET.InvId, T_INVDET.InvSer, T_INVDET.ItmNo, T_INVDET.Cost, T_INVDET.Qty, T_INVDET.ItmUnt, T_INVDET.ItmDes,T_INVDET.ItmDesE , T_INVDET.ItmUntE, T_INVDET.ItmUntPak, T_INVDET.StoreNo, T_INVDET.Price, T_INVDET.Amount, T_INVDET.RealQty, T_INVDET.ItmTyp,T_INVDET.ItmDis, (Abs(T_INVDET.Qty) *  T_INVDET.Price) * (T_INVDET.ItmDis / 100) as ItmDisVal, T_INVDET.DatExper, T_INVDET.itmInvDsc,ItmIndex," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.LineGiftSts, vStr(VarGeneral.ServiceBillId)) ? " T_INVDET.ItmWight " : " 0 as ItmWight") + ", T_INVDET.ItmWight_T, T_INVDET.ItmAddCost, T_INVDET.RunCod, T_INVDET.LineDetails ,T_INVDET.Serial_Key, " + vInvH + ", T_Items.* , T_CstTbl.Arb_Des as CstTbl_Arb_Des , T_CstTbl.Eng_Des as CstTbl_Eng_Des , T_Mndob.Arb_Des as Mndob_Arb_Des , T_Mndob.Eng_Des as Mndob_Eng_Des,T_SYSSETTING.LogImg,(select max(T_AccDef.TaxNo) from T_AccDef where T_AccDef.AccDef_No = T_SYSSETTING.TaxAcc) as TaxAcc,T_SYSSETTING.TaxNoteInv,case when T_INVHED.IsTaxLines = 1 then (case when T_INVHED.IsTaxByTotal = 1 then (case when (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) > 0 then ((Abs(T_INVDET.Qty) *  T_INVDET.Price) - case when (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) > 0 then (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) else 0 end )* T_INVDET.ItmTax / 100   else 0 end) else (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) end) else 0 end as TaxValue ,(select InvNamA from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as InvNamA,(select InvNamE from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as InvNamE,(select T_Store.Arb_Des from T_Store where T_Store.Stor_ID = T_INVDET.StoreNo) as StoreNmA,(select T_Store.Eng_Des from T_Store where T_Store.Stor_ID = T_INVDET.StoreNo) as StoreNmE,(select defPrn from T_INVSETTING where CatID = (select ItmCat from T_Items where Itm_No = T_INVDET.ItmNo) ) as defPrn,case when T_INVHED.CusVenNo = '' THEN '0' ELSE (SELECT Sum(T_GDDET.gdValue) FROM T_GDHEAD INNER JOIN  T_GDDET ON T_GDHEAD.gdhead_ID = T_GDDET.gdID where T_GDDET.AccNo = T_INVHED.CusVenNo and T_GDHEAD.gdLok = 0 and (select T_AccDef.AccCat from T_AccDef where T_AccDef.AccDef_No = T_INVHED.CusVenNo) = '4') END as Balanc,T_INVDET.ItmTax,T_INVHED.InvAddTax,T_INVHED.InvAddTaxlLoc,T_INVHED.TaxGaidID,T_INVHED.IsTaxUse,T_INVHED.IsTaxLines,IsTaxByTotal,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.TaxNo from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as TaxCustNo,T_INVHED.OrderTyp," + ((CurrentBill.IsTaxLines.Value && !VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65)) ? " T_INVHED.InvTotLocCur - T_INVHED.InvAddTax as TotWithTaxPoint " : " T_INVHED.InvTotLocCur as TotWithTaxPoint") + " ,T_INVHED.InvTotLocCur - T_INVHED.InvDisVal as TotBeforeDisVal,T_INVHED.IsTaxByNet,T_INVHED.TaxByNetValue," + (CurrentBill.IsTaxUse.Value ? " T_INVHED.InvNetLocCur - T_INVHED.InvAddTax as NetWithoutTax " : " T_INVHED.InvNetLocCur as NetWithoutTax");
                        VarGeneral.HeaderRep[0] = Text;
                        VarGeneral.HeaderRep[1] = "";
                        VarGeneral.HeaderRep[2] = "";
                        _RepShow.Rule = " where T_INVHED.InvHed_ID = " + CurrentBill.InvHed_ID;

                        if (!string.IsNullOrEmpty(Fields))
                        {
                            _RepShow.Fields = Fields;
                            try
                            {
                                _RepShow = _RepShow.Save();
                                VarGeneral.RepData = _RepShow.RepData;
                                _RepShow = new RepShow();
                                _RepShow.Rule = " WHERE T_Users.UsrNo = '" + CurrentBill.SalsManNo + "'";
                                _RepShow.Tables = " T_Branch INNER JOIN T_Users ON T_Branch.Branch_no = T_Users.Brn ";
                                _RepShow.Fields = " T_Users.UsrNamA ,T_Branch.Branch_Name ,T_Users.UsrNamE ,T_Branch.Branch_NameE ,T_Users.UsrImg ";
                                try
                                {
                                    VarGeneral.RepShowStock_Rat = "Rate";
                                    _RepShow = _RepShow.Save();
                                    VarGeneral.RepShowStock_Rat = "";
                                }
                                catch (Exception ex2)
                                {
                                    VarGeneral.RepShowStock_Rat = "";
                                    MessageBox.Show(ex2.Message);
                                }
                                _RepShow.RepData.Tables[0].Merge(VarGeneral.RepData.Tables[0]);
                                VarGeneral.RepData = _RepShow.RepData;
                                try
                                {
                                    for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
                                    {
                                        if (string.IsNullOrEmpty(VarGeneral.RepData.Tables[0].Rows[i]["LogImg"].ToString()))
                                        {
                                            VarGeneral.RepData.Tables[0].Rows[i]["LogImg"] = VarGeneral.RepData.Tables[0].Rows[VarGeneral.RepData.Tables[0].Rows.Count - 1]["LogImg"];
                                            VarGeneral.RepData.Tables[0].Rows[i]["LTim"] = VarGeneral.RepData.Tables[0].Rows[VarGeneral.RepData.Tables[0].Rows.Count - 1]["LTim"];
                                        }
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
                                    {
                                        if (string.IsNullOrEmpty(VarGeneral.RepData.Tables[0].Rows[i]["UsrImg"].ToString()))
                                        {
                                            try
                                            {
                                                VarGeneral.RepData.Tables[0].Rows[i]["UsrImg"] = VarGeneral.RepData.Tables[0].Rows[0]["UsrImg"];
                                            }
                                            catch
                                            {
                                            }
                                        }
                                    }
                                }
                                catch
                                {
                                }
                            }
                            catch (Exception ex2)
                            {
                                MessageBox.Show(ex2.Message);
                            }
                            if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                            {
                                int id = 1;
                                foreach(InvPfiled k in DataList)
                                {
                                    DataRow r = VarGeneral.RepData.Tables[0].NewRow();
                                    r["InvDet_ID"] = id;
                                    r["InvNo"] = CurrentBill.InvNo;
                                  
                                    r["ItmNo"] = id;
                                    r["Qty"] = k.Quantity;
                                    r["ItmUnt"] = "-";
                                    r["ItmDes"] = k.Supplier + "-" + k.Description + k.BillNumber.ToString() + "-";
                                    r["ItmDesE"] = k.Supplier + "-" + k.BillNumber + k.Quantity.ToString() + "-";
                                    r["ItmUntPak"] = 1;
                                    r["StoreNo"] = 1;
                                    r["Price"] = k.Price;
                                    r["Amount"] = k.Price;
                                    r["CusVenNm"] = k.Supplier;
                                    r["HDat"] = CurrentBill.HDat.ToString();

                                    r["GDat"] = CurrentBill.GDat.ToString();
                                    r["InvTot"] = CurrentBill.InvTot;
                                    r["InvTotLocCur"] = CurrentBill.InvTotLocCur;
                                    r["InvNet"] = CurrentBill.InvNet;
                                    r["InvNetLocCur"] = CurrentBill.InvNetLocCur;
                                    r["InvAddTax"] = CurrentBill.InvAddTax;
                                    r["InvAddTaxlLoc"] = CurrentBill.InvAddTaxlLoc;
                                    r["EngTaf"] = CurrentBill.EngTaf;
                                    r["ArbTaf"] = CurrentBill.ArbTaf;
                            
                                    r["InvNet"] = CurrentBill.InvNet;
                                    r["InvNetLocCur"] = CurrentBill.InvNetLocCur;
                                    r["CashPay"] = CurrentBill.CashPay;
                                    r["CashPayLocCur"] = CurrentBill.CashPayLocCur;
                                    r["InvCash"] = CurrentBill.InvCash;
                                    r["InvCashPay"] = CurrentBill.InvCashPay;
                                    r["InvCashPayNm"] = CurrentBill.InvCashPayNm;


                                    r["InvQty"] = CurrentBill.InvQty;
                                    r["NetworkPay"] = CurrentBill.NetworkPay;
                                    r["NetworkPayLocCur"] = CurrentBill.NetworkPayLocCur;
                                    r["CreditPay"] = CurrentBill.CreditPay;
                                    r["CreditPayLocCur"] = CurrentBill.CreditPayLocCur;
                                    r["InvCashPayNm"] = CurrentBill.InvCashPayNm;
                                    r["Puyaid"] = CurrentBill.Puyaid;
                                    r["Remming"] = CurrentBill.Remming;

                                    r["SalsManNam"] = CurrentBill.SalsManNam;
                            //        r["UserNew"] = CurrentBill.UserNew;
                                    r["InvCost"] = CurrentBill.InvCost;
                                    r["InvDisVal"] = CurrentBill.InvDisVal ;
                                    r["InvDisPrs"] = CurrentBill.InvDisPrs;
                                    r["InvDisValLocCur"] = CurrentBill.InvDisValLocCur;
                                    r["InvTyp"] = CurrentBill.InvTyp;
                                    r["IsTaxLines"] = CurrentBill.IsTaxLines;
                            //        r["IsTotWithTax"] = CurrentBill.IsTaxByNet;

                                   

                               r["IsTaxUse"] = CurrentBill.IsTaxUse;

                                    r["QtyAbs"] =k.Quantity ;

                                    r["RealQty"] =k.Quantity;

                              

                                    VarGeneral.RepData.Tables[0].Rows.Add(r);


                                }
                                try
                                {
                                    FrmReportsViewer frm = new FrmReportsViewer();
                                    FrmReportsViewer.QRCodeData = Utilites.GetWQRCodeData(CurrentBill);

                                    frm.Repvalue = "Purchase";
                                    frm.RepCashier = "InvoiceCachier";
                                    frm.Tag = 0;
                                    if (false)
                                    {
                                        frm.BarcodSts = true;
                                    }
                                    else
                                    {
                                        frm.BarcodSts = false;
                                    }
                                    if (_InvSetting.InvpRINTERInfo.ISA4PaperType)
                                    {
                                        frm.Repvalue = "Purchase";
                                    }
                                    else
                                    {
                                        frm.RepCashier = "InvoiceCachier";
                                    }
                                    if (ChkA4Cahir == null) ChkA4Cahir = new CheckBoxX();

                                    if (ChkA4Cahir.Checked)
                                    {
                                        if (frm.Repvalue == "Purchase")
                                        {
                                            frm.RepCashier = "InvoiceCachier";
                                        }
                                        else
                                        {
                                            frm.Repvalue = "Purchase";
                                        }
                                        VarGeneral.PrintingSettingGen = new PrintDialog();
                                        VarGeneral.prnt_doc_Gen = new PrintDocument();
                                        VarGeneral.PrintingSettingGen.UseEXDialog = true;
                                        if (VarGeneral.PrintingSettingGen.ShowDialog() != DialogResult.OK)
                                        {
                                            return;
                                        }
                                        VarGeneral.prnt_doc_Gen.PrinterSettings = VarGeneral.PrintingSettingGen.PrinterSettings;
                                        VarGeneral.Print_set_Gen_Stat = true;
                                    }
                                    VarGeneral.CostCenterlbl = "مركز التكلفة";
                                    VarGeneral.Mndoblbl = "المندوب العميل /المورد";
                                    VarGeneral.vTitle = Text;
                                    if (_InvSetting.ISdirectPrinting || false)
                                    {
                                        frm._Proceess();
                                    }
                                    else
                                    {
                                        frm.TopMost = true;
                                        frm.ShowDialog();
                                    }
                                }
                                catch (Exception error)
                                {
                                    VarGeneral.DebLog.writeLog("buttonItem_Print_Click:", error, enable: true);
                                    MessageBox.Show(error.Message);
                                }
                            }
                        }
                    }
                    else
                    {
                        //PrintSet();
                        //prnt_doc.Print();
                    }
                }
            }
            catch
            {
                MessageBox.Show((0 == 0) ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            VarGeneral.Print_set_Gen_Stat = false;

        }
        public void clear()
        {
            DataList.Clear();
            gridControl1.Refresh();
            txtTotTax.Text = "";
            lookUpEditWithDataSource1.EditValueChanged -= lookUpEditWithDataSource1_EditValueChanged_1;
            lookUpEditWithDataSource1.EditValue = null;

            lookUpEditWithDataSource1.EditValueChanged += lookUpEditWithDataSource1_EditValueChanged_1;

            txtTotalAmLoc.Text = "";
        txtDueAmountLoc.Text = "";
        }
        public static bool UpdateInProgress = false;
        public void setBill(T_INVHED t)
        {if (UpdateInProgress)
            {
                BillUcontrolType3.UpdateInProgress = false;
                return;
            }
            if (!IsInitiated) init();
            CurrentBill = t;
            try
            {
                txtGDate.Text = t.GDat;
                txtHDate.Text = t.HDat;
                CurrentBill.InvNo = t.InvNo.ToString();
            }
            catch
            {
                return;
            }
            List<T_GDHEAD> f = new List<T_GDHEAD>();
            try
            {
                _dsb = null;
                f = db.StockGdHeadid((int)t.GadeId);
            }
            catch { }
            DataList = new BindingList<InvPfiled>();
            lookUpEditWithDataSource1.EditValueChanged -= lookUpEditWithDataSource1_EditValueChanged_1;
            lookUpEditWithDataSource1.EditValue = null;

            lookUpEditWithDataSource1.EditValueChanged += lookUpEditWithDataSource1_EditValueChanged_1;
            try
            {
                if (t.InvTyp != VarGeneral.DraftBillId)
                {
                    foreach (T_GDHEAD s in f)
                    {
                        currentGH = s;
                        List<T_GDDET> vv = s.T_GDDETs.ToList();
                        foreach (T_GDDET k in vv)
                        {
                            if (k.gdDes.Contains("تلقائي") || k.Lin == 0)
                            {
                                if (daf.Where(i => i.AccDef_No == k.AccNo).Count() == 1)

                                    lookUpEditWithDataSource1.EditValue = k.AccNo;
                                continue;
                            }
                            InvPfiled i = new InvPfiled();

                            i.date = k.AccName;

                            i.AccountNumber = k.AccNo;

                            string ss = k.gdDes;
                            try
                            {
                                i.Description = ss.Split('#')[1];
                            }
                            catch { i.Description = ss; }
                            try
                            {
                                i.Supplier = ss.Split('#')[2];
                            }
                            catch { i.Supplier = ss; }
                            try
                            {
                                i.SupplierNumber = ss.Split('#')[3];
                            }
                            catch { }
                            try
                            {
                                i.BillNumber = ss.Split('#')[4];
                            }
                            catch { }
                            int kk = 0;
                            try
                            {
                                i.Taxtype = ss.Split('#')[5];
                                kk = taxtypes.IndexOf(taxtypes.Where(ks => ks.Type_Description == i.Taxtype).FirstOrDefault());
                            }
                            catch { }
                            try
                            {
                                i.CostCenter = ss.Split('#')[6];
                            }
                            catch { }
                            try
                            {
                                i.Quantity = int.Parse(ss.Split('#')[7]);
                            }
                            catch { i.Quantity = 1; }
                            try
                            {
                                i.Price = (double)k.gdValue;
                                i.withouttax = i.Price * 1.15;
                                i.taxvalue = i.withouttax - i.Price;
                            }
                            catch { }

                            DataList.Add(i);


                        }
                    }
                }else

                {
                    var w = (from i in db.T_TempGDDET
                             where
   i.gdNo == t.InvHed_ID.ToString()
                             select i).ToList();

                    { 
                       
                        foreach (T_TempGDDET k in w)
                        {
                            if (k.gdDes.Contains("تلقائي") || k.Lin == 0)
                            {
                                if (daf.Where(i => i.AccDef_No == k.AccNo).Count() == 1)

                                    lookUpEditWithDataSource1.EditValue = k.AccNo;
                                continue;
                            }
                            InvPfiled i = new InvPfiled();

                            i.date = k.AccName;

                            i.AccountNumber = k.AccNo;

                            string ss = k.gdDes; try
                            {
                                i.Description = ss.Split('#')[1];
                            }
                            catch { i.Description = ss; }
                            try
                            {
                                i.Supplier = ss.Split('#')[2];
                            }
                            catch { i.Supplier = ss; }
                            try
                            {
                                i.SupplierNumber = ss.Split('#')[3];
                            }
                            catch { }
                            try
                            {
                                i.BillNumber = ss.Split('#')[4];
                            }
                            catch { }
                            int kk = 0;
                            try
                            {
                                i.Taxtype = ss.Split('#')[5];
                                kk = taxtypes.IndexOf(taxtypes.Where(ks => ks.Type_Description == i.Taxtype).FirstOrDefault());
                            }
                            catch { }
                            try
                            {
                                i.CostCenter = ss.Split('#')[6];
                            }
                            catch { }
                            try
                            {
                                i.Quantity = int.Parse(ss.Split('#')[7]);
                            }
                            catch { i.Quantity = 1; }
                            try
                            {
                                i.Price = (double)k.gdValue;
                                i.withouttax = i.Price * 1.15;
                                i.taxvalue = i.withouttax - i.Price;
                            }
                            catch { }

                            DataList.Add(i);


                        }
                    }

                }
                
            }
            catch { }
            t_GDDETsBindingSource34.DataSource = DataList;
            t_GDDETsBindingSource34.AddingNew += t_GDDETsBindingSource34new;
            gridControl1.DataSource = t_GDDETsBindingSource34;
            Refresh();
    
            gridView1.UpdateSummary();

            gridView1.UpdateTotalSummary();
            gridView1_FocusedColumnChanged(null, null);
        }
        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
        public void save(T_INVHED v)
        {

        }
        private void lookUpEditWithDataSource1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtGDate_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void gridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            kk = 0;
            try
            {
                {
                   

                 txtTotTax.Text = (gridColumn7.SummaryItem.SummaryValue.ToString());
                 
                }
            }
            catch { }
            try
            {
                {
                   txtTotalAmLoc.Text = (colgdValue.SummaryItem.SummaryValue.ToString()); ;// ( double.Parse(colgdValue.SummaryItem.SummaryValue.ToString())+double.Parse(gridColumn7.SummaryItem.SummaryValue.ToString())).ToString();
                }
            }
            catch { }

            try
            {
                txtDueAmountLoc.Text = (colgdValue.SummaryItem.SummaryValue.ToString());
            }
            catch { }
            InvTot = double.Parse(txtTotalAmLoc.Text);
            //   InvTot = double.Parse(txtDueAmountLoc.Text);
            InvCost = double.Parse(txtTotalAmLoc.Text);
            InvTax = double.Parse(txtTotTax.Text);
            InvTot = InvCost;

            if (settotals != null)
            {
               
                settotals(null, null);
            }
         
        }
        public SwitchButton switchButton_Lock;
        public SwitchButtonItem switchButton_TaxByNet, switchButton_TaxLines, switchButton_TaxByTotal;
        public TextBoxItem textBoxItem_TaxByNetValue;
        private double without;
        public void cash(T_GDHEAD data_dthis, List<T_GDDET> DetaislsGaid, T_GDDET k,ref int lin,ref int ks, ref int ic)

        {
            db_ = Database.GetDatabase(VarGeneral.BranchCS);
            db_.StartTransaction();
            db_.ClearParameters();

            db_.AddParameter("GDDET_ID", DbType.Int32, 0);
            db_.AddParameter("gdID", DbType.Int32, data_dthis.gdhead_ID);
            db_.AddParameter("gdNo", DbType.String, data_dthis.gdNo.ToString());
            db_.AddParameter("gdDes", DbType.String, k.gdDes);
            try
            {
                db_.AddParameter("gdDesE", DbType.String, k.gdDesE);
            }
            catch
            {
                db_.AddParameter("gdDesE", DbType.String, " ");
            }
            db_.AddParameter("recptTyp", DbType.String, recptTyp.ToString());
            db_.AddParameter("AccNo", DbType.String, k.AccNo);
            db_.AddParameter("AccName", DbType.String, k.AccName);
            if (double.Parse(k.gdValue.Value.ToString()) > 0)
            {
                db_.AddParameter("gdValue", DbType.Double, double.Parse(k.gdValue.Value.ToString()));
            }
            else if (double.Parse(k.gdValue.Value.ToString()) > 0)
            {
                db_.AddParameter("gdValue", DbType.Double, -double.Parse(k.gdValue.Value.ToString()));
            }
            db_.AddParameter("recptNo", DbType.String, data_dthis.gdNo);
            db_.AddParameter("Lin", DbType.Int32, ic);
            db_.AddParameter("AccNoDestruction", DbType.String, null);
            db_.ExecuteNonQueryWithoutCommit(true, "S_T_GDDET_INSERT");
            db_.EndTransaction();
            int ksv = int.Parse(db_.GetParameterValue("GDDET_ID").ToString());

            if (disTaxGaid&& checkBox_CostGaidTax.Checked == true)
            {
                db_.StartTransaction();
                db_.ClearParameters();
                db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                db_.AddParameter("gdID", DbType.Int32, _GdHeadCostTax.gdhead_ID);
                db_.AddParameter("gdNo", DbType.String, CurrentBill.InvNo);
                db_.AddParameter("gdDes", DbType.String, k.gdDes + "# " + "سند قيمة ضريبة لــ " + DataList[ks].BillNumber);
                db_.AddParameter("recptTyp", DbType.String, "1");
                db_.AddParameter("gdDesE", DbType.String, "Tax Value To Puchase Invoice No : " + DataList[ks].BillNumber);
                db_.AddParameter("AccNo", DbType.String, AccCrdt_Cost);
                db_.AddParameter("AccName", DbType.String, "");
                db_.AddParameter("gdValue", DbType.Double, 0.0 - DataList[ks].taxvalue);
                db_.AddParameter("recptNo", DbType.String, CurrentBill.InvNo);
                db_.AddParameter("Lin", DbType.Int32, lin); lin = lin + 1;
                db_.AddParameter("AccNoDestruction", DbType.String, null);
                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                db_.EndTransaction();
                db_.StartTransaction();
                db_.ClearParameters();
                db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                db_.AddParameter("gdID", DbType.Int32, _GdHeadCostTax.gdhead_ID);
                db_.AddParameter("gdNo", DbType.String, CurrentBill.InvNo);
                db_.AddParameter("gdDes", DbType.String, k.gdDes + "# " + "سند قيمة ضريبة لــ " + DataList[ks].BillNumber);
                db_.AddParameter("recptTyp", DbType.String, "1");
                db_.AddParameter("gdDesE", DbType.String, "Tax Value To Puchase Invoice No : " + DataList[ks].BillNumber);
                db_.AddParameter("AccNo", DbType.String, AccDbbt_Cost);
                db_.AddParameter("AccName", DbType.String, "");
                db_.AddParameter("gdValue", DbType.Double, DataList[ks].taxvalue);
                db_.AddParameter("recptNo", DbType.String, CurrentBill.InvNo);
                db_.AddParameter("Lin", DbType.Int32, lin); lin = lin + 1;
                db_.AddParameter("AccNoDestruction", DbType.String, null);
                db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                db_.EndTransaction();
                ks = ks + 1;
                ic = ic + 1;
            }

        }
        void createdetailstaxgaid()
        {
 
        }
        double caltax(double amount, double taxpercent)
        {
            without = amount;
  
            if (taxpercent != 0)
            {
                taxpercent = (double)taxpercent / 100;
                taxpercent++;
                return ((double)amount / taxpercent);
            }
            else return (amount);
        }
        int kk = 0;
        private int Level;

        public int CategoryID { get; }
        public int AccountType { get; }
        public int ParentLevel { get; private set; }

        private void gridControl1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
                {
            
        }
        public bool edited = false;
        private void gridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {
            edited = true;
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Delete row?", "Confirmation", MessageBoxButtons.YesNo) !=
                  DialogResult.Yes)
                    return;
                GridView view = gridView1;
                view.DeleteRow(view.FocusedRowHandle);
            }



        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            InvPfiled eff = t_GDDETsBindingSource34.Current as InvPfiled;
            if (eff.Supplier == ""||eff.Supplier == null)
            {
                e.Valid = false;
                gridView1.SetFocusedRowCellValue("Supplier", "");
                gridView1.SetColumnError(gridColumn1, "يجب ادخال  المورد");
                gridView1.FocusedColumn = gridColumn1;
                //  gridView2_InvalidValueException()
            }
            if (eff.Description == "" || eff.Description == null)
            {
                e.Valid = false;
                gridView1.SetFocusedRowCellValue("Description", "");
                gridView1.SetColumnError(gridColumn10, "يجب ادخال  البيان");
                gridView1.FocusedColumn = gridColumn10;
                //  gridView2_InvalidValueException()
            }
            if (eff.AccountNumber == "" || eff.AccountNumber == null)
            {
                e.Valid = false;
                gridView1.SetFocusedRowCellValue("AccountNumber", "");
                gridView1.SetColumnError(colAccNo, "يجب ادخال رقم  الحساب");
                gridView1.FocusedColumn = colAccNo;
                //  gridView2_InvalidValueException()
            }
            if (eff.BillNumber == "" || eff.BillNumber == null)
            {
                e.Valid = false;
                gridView1.SetFocusedRowCellValue("BillNumber", "");
                gridView1.SetColumnError(gridColumn3, "يجب ادخال رقم  الفاتورة");
                gridView1.FocusedColumn = gridColumn3;
                //  gridView2_InvalidValueException()
            }
          

        }

        private void gridView1_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;

        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.ThrowException;
        }

        private void repositoryItemLookUpEdit1_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
         

        }

        private void repositoryItemLookUpEdit2_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            Suppliers t = new Suppliers();
            t.AccDef_No = "0";
            t.Arb_Des = e.DisplayValue.ToString();

            Suppliers_BindingSource.Add(t);
            repositoryItemLookUpEdit2.DataSource = null;
            repositoryItemLookUpEdit2.DataSource = Suppliers_BindingSource;
            repositoryItemLookUpEdit2.DisplayMember = "Arb_Des";
            repositoryItemLookUpEdit2.ValueMember = "Arb_Des";
            InvPfiled fs = t_GDDETsBindingSource34.Current as InvPfiled;
            fs.Supplier = t.Arb_Des;
            gridView1.SetFocusedRowCellValue("Supplier", t.Arb_Des);
        }
        void netowrkrecording()
        {

            db_.StartTransaction();
            db_.ClearParameters();
            db_.AddParameter("GDDET_ID", DbType.Int32, 0);
            db_.AddParameter("gdID", DbType.Int32, currentGH.gdhead_ID);
            db_.AddParameter("gdNo", DbType.String, CurrentBill.InvNo);
            db_.AddParameter("gdDes", DbType.String, "قيد تلقائي لفاتورة مشتريات رقم : " + CurrentBill.InvNo);
            db_.AddParameter("gdDesE", DbType.String, "Auto Bound To Puchase Invoice No : " + CurrentBill.InvNo);
            db_.AddParameter("recptTyp", DbType.String, "1");
            db_.AddParameter("AccNo", DbType.String, AccCrdt_NewtWork);
            db_.AddParameter("AccName", DbType.String, "");
            db_.AddParameter("gdValue", DbType.Double, 0.0 - double.Parse(doubleInput_NetWorkLoc.Text));
            db_.AddParameter("recptNo", DbType.String, CurrentBill.InvNo);
            db_.AddParameter("Lin", DbType.Int32, 3);
            db_.AddParameter("AccNoDestruction", DbType.String, null);
            db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
            db_.EndTransaction();
            db_.StartTransaction();
            db_.ClearParameters();
            db_.AddParameter("GDDET_ID", DbType.Int32, 0);
            db_.AddParameter("gdID", DbType.Int32, currentGH.gdhead_ID);
            db_.AddParameter("gdNo", DbType.String, CurrentBill.InvNo);
            db_.AddParameter("gdDes", DbType.String, "قيد تلقائي لفاتورة مشتريات رقم : " + CurrentBill.InvNo);
            db_.AddParameter("gdDesE", DbType.String, "Auto Bound To Puchase Invoice No : " + CurrentBill.InvNo);
            db_.AddParameter("recptTyp", DbType.String, "1");
            db_.AddParameter("AccNo", DbType.String, AccDbt_NetWork);
            db_.AddParameter("AccName", DbType.String, "");
            db_.AddParameter("gdValue", DbType.Double, double.Parse(doubleInput_NetWorkLoc.Text));
            db_.AddParameter("recptNo", DbType.String, CurrentBill.InvNo);
            db_.AddParameter("Lin", DbType.Int32, 3);
            db_.AddParameter("AccNoDestruction", DbType.String, null);
            db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
            db_.EndTransaction();

        }
        public DoubleInput doubleInput_CreditLoc;
        public DoubleInput doubleInput_NetWorkLoc;
        public DoubleInput txtPaymentLoc;
        public string AccCrdt_Credit, AccDbt_Credit, AccDbt_NetWork, AccCrdt_NewtWork;
        void cridet()
        {
            db_.StartTransaction();
            db_.ClearParameters();
            db_.AddParameter("GDDET_ID", DbType.Int32, 0);
            db_.AddParameter("gdID", DbType.Int32, currentGH.gdhead_ID);
            db_.AddParameter("gdNo", DbType.String, CurrentBill.InvNo);
            db_.AddParameter("gdDes", DbType.String, "قيد تلقائي لفاتورة مشتريات رقم : " + CurrentBill.InvNo);
            db_.AddParameter("gdDesE", DbType.String, "Auto Bound To Puchase Invoice No : " + CurrentBill.InvNo);
            db_.AddParameter("recptTyp", DbType.String, "1");
            db_.AddParameter("AccNo", DbType.String, AccCrdt_Credit);
            db_.AddParameter("AccName", DbType.String, "");
            db_.AddParameter("gdValue", DbType.Double, 0.0 - double.Parse(doubleInput_CreditLoc.Text));
            db_.AddParameter("recptNo", DbType.String, CurrentBill.InvNo);
            db_.AddParameter("Lin", DbType.Int32, 2);
            db_.AddParameter("AccNoDestruction", DbType.String, null);
            db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
            db_.EndTransaction();
            db_.StartTransaction();
            db_.ClearParameters();
            db_.AddParameter("GDDET_ID", DbType.Int32, 0);
            db_.AddParameter("gdID", DbType.Int32, currentGH.gdhead_ID);
            db_.AddParameter("gdNo", DbType.String,CurrentBill.InvNo);
            db_.AddParameter("gdDes", DbType.String, "قيد تلقائي لفاتورة مشتريات رقم : " + CurrentBill.InvNo);
            db_.AddParameter("gdDesE", DbType.String, "Auto Bound To Puchase Invoice No : " + CurrentBill.InvNo);
            db_.AddParameter("recptTyp", DbType.String, "1");
            db_.AddParameter("AccNo", DbType.String, AccDbt_Credit);
            db_.AddParameter("AccName", DbType.String, "");
            db_.AddParameter("gdValue", DbType.Double, double.Parse(doubleInput_CreditLoc.Text));
            db_.AddParameter("recptNo", DbType.String, CurrentBill.InvNo);
            db_.AddParameter("Lin", DbType.Int32, 2);
            db_.AddParameter("AccNoDestruction", DbType.String, null);
            db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
            db_.EndTransaction();

        }
        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

        }

        private void repositoryItemLookUpEdit5_EditValueChanged(object sender, EventArgs e)
        {

            LookUpEdit lookUpEdit = (LookUpEdit)sender;
            var val = lookUpEdit.EditValue;
            //   T_AccDef es = (T_AccDef)(repositoryItemLookUpEdit2).GetDataSourceRowByKeyValue(val);


            taxtypesbinding_source.Position = repositoryItemLookUpEdit5.GetDataSourceRowIndex(repositoryItemLookUpEdit5.ValueMember, val);

            InvPfiled td = t_GDDETsBindingSource34.Current as InvPfiled;

            td.withouttax = td.withouttax;
            TaxTypes fff = taxtypesbinding_source.Current as TaxTypes;
            double percent = fff.Percent;
            td.Price = caltax(td.withouttax, percent);
            td.taxvalue = td.withouttax - (td.Price);

        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtDueAmountLoc_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lookUpEditWithDataSource1_EditValueChanged_1(object sender, EventArgs e)
        {
            int ks = this.lookUpEditWithDataSource1.Properties.GetDataSourceRowIndex(this.lookUpEditWithDataSource1.Properties.ValueMember, lookUpEditWithDataSource1.EditValue);
            if (ks != -1)
                this.BindingContext[this.lookUpEditWithDataSource1.Properties.DataSource].Position = ks;
            if (SetAccountBoxNumber != null)
                SetAccountBoxNumber(null, null);
        }

        private void txtHDate_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(e.Column.SummaryItem.SummaryType!=DevExpress.Data.SummaryItemType.None)
            {
                try
                {
                    gridView1.UpdateSummary();
                    gridView1.UpdateTotalSummary();
                    gridView1.UpdateGroupSummary();
                    gridView1.UpdateCurrentRow();
                }
                catch
                {

                }
            }
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
           
        }

        object getcell(GridColumn g)
        {
            return gridView1.GetRowCellValue(gridView1.FocusedRowHandle, g);
        }
        private void repositoryItemComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            InvPfiled td = t_GDDETsBindingSource34.Current as InvPfiled;
            colgdValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, colgdValue, caltax(td.withouttax, 15));
            td.taxvalue= (td.withouttax-double.Parse(getcell(colgdValue).ToString()));
        }
    }
    /// <summary>
    /// PopupHelper
    /// </summary>
    /// <summary>
    /// PopupHelper
    /// </summary>
    /// ]
    /// 

    public sealed class LookUpEditWithDataSource : LookUpEdit
    {
        private bool firstCall = true;

        /// <summary>
        /// Called when the edit value changes.
        /// </summary>
        protected override void OnEditValueChanged()
        {
            base.OnEditValueChanged();

            if (this.Properties.DataSource == null)
            {
                return;
            }

            if (this.BindingContext == null)
            {
                return;
            }

            if (this.firstCall)
            {
                this.firstCall = false;

                // HACK
                // starting and selecting the first item
                // doesn't work so we change the position to the first item
                this.BindingContext[this.Properties.DataSource].Position = 1;
            }
            int ks= this.Properties.GetDataSourceRowIndex(this.Properties.ValueMember, this.EditValue);
            if(ks!=-1)
            this.BindingContext[this.Properties.DataSource].Position = ks;

        }
        public void setpos(string sa)
        {
            

            if (this.Properties.DataSource == null)
            {
                return;
            }

            if (this.BindingContext == null)
            {
                return;
            }

            if (this.firstCall)
            {
                this.firstCall = false;

                // HACK
                // starting and selecting the first item
                // doesn't work so we change the position to the first item
                this.BindingContext[this.Properties.DataSource].Position = 1;
            }

            this.BindingContext[this.Properties.DataSource].Position = this.Properties.GetDataSourceRowIndex(this.Properties.ValueMember, sa);
            base.OnEditValueChanged();
        }
    }

    public sealed class PopupHelper : IDisposable
    {
        private readonly Control m_control;
        private readonly ToolStripDropDown m_tsdd;
        private readonly Panel m_hostPanel; // workarround - some controls don't display correctly if they are hosted directly in ToolStripControlHost

        public PopupHelper(Control pControl)
        {
            m_hostPanel = new Panel();
            m_hostPanel.Padding = System.Windows.Forms.Padding.Empty;
            m_hostPanel.Margin = Padding.Empty;
            m_hostPanel.TabStop = false;
            m_hostPanel.BorderStyle = BorderStyle.None;
            m_hostPanel.BackColor = Color.Transparent;

            m_tsdd = new ToolStripDropDown();
            m_tsdd.CausesValidation = false;

            m_tsdd.Padding = Padding.Empty;
            m_tsdd.Margin = Padding.Empty;
            m_tsdd.Opacity = 0.9;

            m_control = pControl;
          
            m_control.CausesValidation = false;
            m_control.Resize += MControlResize;

            m_hostPanel.Controls.Add(m_control);
            pControl.Dock = DockStyle.Fill;
            m_tsdd.Padding = Padding.Empty;
            m_tsdd.Margin = Padding.Empty;

            m_tsdd.MinimumSize = m_tsdd.MaximumSize = m_tsdd.Size = pControl.Size;

            m_tsdd.Items.Add(new ToolStripControlHost(m_hostPanel));
        }

        private void ResizeWindow()
        {
            m_tsdd.MinimumSize = m_tsdd.MaximumSize = m_tsdd.Size = m_control.Size;
            m_hostPanel.MinimumSize = m_hostPanel.MaximumSize = m_hostPanel.Size = m_control.Size;
        }

        private void MControlResize(object sender, EventArgs e)
        {
            ResizeWindow();
        }

        /// <summary>
        /// Display the popup and keep the focus
        /// </summary>
        /// <param name="pParentControl"></param>
        public void Show(Control pParentControl)
        {
            if (pParentControl == null) return;

            // position the popup window
            var loc = pParentControl.PointToScreen(new Point(0, pParentControl.Height));
            m_tsdd.Show(loc);
            m_control.Focus();
        }

        public void Close()
        {
            m_tsdd.Close();
        }

        public void Dispose()
        {
            m_control.Resize -= MControlResize;

            m_tsdd.Dispose();
            m_hostPanel.Dispose();
        }
    }
    public class Suppliers
    {
        public string Arb_Des { get; set; }
        public string AccDef_No { get; set; }
        //public Suppliers(string No ,string Name) { Arb_Des = Name; AccDef_No = No; }
    }
    public class TaxTypes
    {
        public string Type_Description { get; set; }
        public double Percent { get; set; }
        //public Suppliers(string No ,string Name) { Arb_Des = Name; AccDef_No = No; }
    }

    public class InvPfiled
    {
        public string AccountNumber { get; set; }
        public string Supplier { get; set; }
        public string SupplierNumber { get; set; }
        public string BillNumber { get; set; }
        public string Description { get; set; }
        public string date { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double withouttax { get; set; }
        public double taxvalue { get; set; }
        public string CostCenter { get; set; }
        public string Taxtype { get; set; }
    }

}
