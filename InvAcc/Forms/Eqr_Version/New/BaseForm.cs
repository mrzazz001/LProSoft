using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SSSDateTime.Date;
using ProShared.GeneralM;
using ProShared.Stock_Data;
using InvAcc.Controls;
using DevExpress.XtraDataLayout;

namespace InvAcc.Forms.Eqr_Version.New
{
    public partial class BaseForm : DevExpress.XtraEditors.XtraForm
    {
        public class FindAbleBindingList<T> : BindingList<T>
        {

            public FindAbleBindingList()
                : base()
            {
            }

            public FindAbleBindingList(List<T> list)
                : base(list)
            {
            }

            protected override int FindCore(PropertyDescriptor property, object key)
            {
                for (int i = 0; i < Count; i++)
                {
                    T item = this[i];
                    //if (property.GetValue(item).Equals(key))
                    if (property.GetValue(item).ToString().StartsWith(key.ToString()))
                    {
                        return i;
                    }
                }
                return -1; // Not found
            }
        }
        public bool Dirty = false;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (ActiveControl.GetType() == typeof(DataLayoutControl) || ActiveControl.GetType() == typeof(LookUpEdit) || ActiveControl.GetType() == typeof(TextEdit) || ActiveControl.GetType() == typeof(ComboBoxEdit) || ActiveControl.GetType() == typeof(SpinEdit))
            { Dirty = true; 
                
                
                ubar1.State = FormState.Edit;

            State = FormState.Edit;


            }
            return base.ProcessCmdKey(ref msg, keyData);
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

        public HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        public int LangArEn = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
#pragma warning disable CS0414 // The field 'FrmAinTyp.FlagUpdate' is assigned but its value is never used
        public string FlagUpdate = "";
        public FormState statex;
        public bool canUpdate = true;
        public List<string> pkeys = new List<string>();
        public Stock_DataDataContext dbInstance;
        public T_AinTyp data_this;
        public Rate_DataDataContext dbInstanceRate;
        public T_User permission = new T_User();
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
       
        public FormState State
        {
            get
            {
                return statex;
            }
            set
            {
                statex = value;
            }
        }
        public bool IfAdd
        {
            set
            {
              //ubar1.IfAdd = value;
            }
        }
        public bool IfDelete
        {
            set
            {
                
           //    ubar1.IfDelete = value;
            
            }
        }
        public bool IfSave
        {
            set
            {
             //   ubar1.IfSave = value;
            }
        }
        public bool CanUpdate
        {
            get
            {
                return canUpdate;
            }
            set
            {
                canUpdate = value;
            }
        }
        public List<string> PKeys
        {
            get
            {
                return pkeys;
            }
            set
            {
                pkeys = value;
            }
        }
        public bool SetReadOnly
        {
            set
            {
                if (value)
                {
                    State = FormState.Saved;
                }

            }
        }
        public Stock_DataDataContext db
        {
            get
            {
                if (dbInstance == null)
                {
                    dbInstance = new Stock_DataDataContext(VarGeneral.BranchCS);
                    Arg.binding = ubar1.Binding;
                    try
                    {
                        Arg.db = dbInstance;
                    }
                    catch { }
                }
              
                return dbInstance;
            }
        }
        public Rate_DataDataContext dbc
        {
            get
            {
                if (dbInstanceRate == null)
                {
                    dbInstanceRate = new Rate_DataDataContext(VarGeneral.BranchRt);
                    Arg.binding = ubar1.Binding;
                    try
                    {
                        Arg.dbc = dbInstanceRate;
                    }
                    catch { }
                }
              
                return dbInstanceRate;
            }
        }
        public BaseForm()
        {
            InitializeComponent();
            Arg = new BarEvArg();
  
        }
        private void Frm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        //protected  void  Button_Add_Click(object sender, BarEvArg e)
        //{

        //}
        //protected void Button_Save_Click(object sender, BarEvArg e)
        //{

        //}
        //protected void Button_Search_Click(object sender, BarEvArg e)
        //{

        //}
        //protected void Button_Delete_Click(object sender, BarEvArg e)
        //{

        //}
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            BarEvArg es = new BarEvArg();
            es.db = db;
            es.dbc = dbc;
            es.binding = ubar1.Binding;
            if (e.KeyCode == Keys.F1 &&ubar1. Button_Add.Enabled && ubar1.Button_Add.Visibility==DevExpress.XtraBars.BarItemVisibility.Always)
            {
                ubar1. Button_Add_ItemClick(sender, null);
            }
            else if (e.KeyCode == Keys.F2 && ubar1.Button_Save.Enabled && ubar1.Button_Save.Visibility == DevExpress.XtraBars.BarItemVisibility.Always && State != 0)
            {
                ubar1.Button_Save_ItemClick(sender, null);
            }
            else if (e.KeyCode == Keys.F3 && ubar1.Button_Delete.Enabled && ubar1.Button_Delete.Visibility == DevExpress.XtraBars.BarItemVisibility.Always && State == FormState.Saved)
            {
                ubar1.Button_Delete_ItemClick(sender, null);
            }
            else if (e.KeyCode == Keys.F4 && ubar1.Button_Search.Enabled && ubar1.Button_Search.Visibility == DevExpress.XtraBars.BarItemVisibility.Always)
            {
                ubar1.Button_Search_ItemClick(sender, null);
            }
            //else if (e.KeyCode == Keys.F5 && ubar1.Button_PrintTable.Enabled && ubar1.Button_PrintTable.Visibility == DevExpress.XtraBars.BarItemVisibility.Always)
            //{
            //    ubar1.Button_Print_Click(sender, es);
            //}
            //else if (e.KeyCode == Keys.F10 && ubar1.Button_ExportTable2.Enabled && ubar1.Button_ExportTable2.Visibility == DevExpress.XtraBars.BarItemVisibility.Always)
            //{
            //    ubar1.Button_ExportTable2_Click(sender, es);
            //}
            else
            {
                if (e.KeyCode != Keys.Escape)
                {
                    return;
                }
                if (State == FormState.Saved)
                {
                    Close();
                    return;
                }
                if (State != FormState.New)
                {
                  
                    return;
                }
                try
                {
                    if (int.Parse(ubar1. Label_Count.Caption) > 0)
                    {
                     ubar1.   Button_Last_ItemClick(sender, null);
                    }
                    else
                    {
                        Close();
                    }
                }
                catch
                {
                    Close();
                }
            }
        }
        public void dateEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '/' || e.KeyChar == '.')
                e.KeyChar = ' ';
        }
        public void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            DateEdit ds = (sender as DateEdit);
            ds.EditValueChanged -= dateEdit1_EditValueChanged;
            DateTimeConverter cr = new DateTimeConverter();
            if (ds.EditValue != null)
            {
                if (ds.EditValue.ToString() == "")
                      ds.EditValue = DateTime.Today.ToShortDateString();

                ;
                if (ds.EditValue.ToString() != "")
                    ds.EditValue = ((DateTime)cr.ConvertFromString(ds.EditValue.ToString())).ToString("MM/dd/yyyy");
            }
            ds.EditValueChanged += dateEdit1_EditValueChanged;
        }

        public void BaseForm_Load(object sender, EventArgs e)
        {
             if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                   
                    LangArEn = 0;
                }
                else
                {
                   
                    LangArEn = 1;
                }
            this.KeyPress += Frm_KeyPress;
            this.KeyDown += Frm_KeyDown;
            dataLayoutControl1.OptionsView.HighlightFocusedItem = true;

        }
        public Controls.BarEvArg Arg=new
           BarEvArg() ;
        public void bindingSource1_DataSourceChanged(object sender, EventArgs e)
        {
            
        }

        private void ubar1_Button_Delete_Click(object sender, BarEvArg e)
        {
            e.db = db;
         //   e.dbc = dbc;

        }

        private void ubar1_Button_Save_Click(object sender, BarEvArg e)
        {
            if (ActiveControl.GetType() == typeof(DateEdit))
                this.Focus();
            e.db = db;
          //  e.dbc = dbc;

        }

        private void ubar1_Button_Close_Click(object sender, BarEvArg e)
        {
            e.db = db;

        }
    }
}