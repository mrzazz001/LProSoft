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
using ProShared.GeneralM;using ProShared;
using System.Linq;
using System.Collections.Generic;
using System.Data.Linq;
using ProShared.Stock_Data;

namespace InvAcc.Controls
{
  
    public partial class Ubar : DevExpress.XtraEditors.XtraUserControl
    {
        public Ubar()
        {
            InitializeComponent();
   
        }

        FormState statex;
        bool canUpdate;
        public bool CanEdit;

        protected bool CanUpdate
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
        public delegate void customMessageHandler(System.Object sender,
                                        BarEvArg e);
        public event customMessageHandler Button_Next_Click;
        public event customMessageHandler Button_Previous_Click;
        public event customMessageHandler Button_First_Click;
        public event customMessageHandler Button_Last_Click;
        public event customMessageHandler Button_Add_Click;
        public event customMessageHandler Button_Save_Click;
        public event customMessageHandler Button_Delete_Click;
        public event customMessageHandler Button_Close_Click;

        public event customMessageHandler Button_Search_Click;
        public void Button_Prev_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           Binding.MovePrevious();
       
            if (Button_Previous_Click != null)
                Button_Previous_Click(null, null);
        }

        public void Button_First_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
               Binding.MoveFirst();
           
            }
            catch { }
            if (Button_First_Click != null)
                    Button_First_Click(null, null);

         }

        public void Button_Next_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           Binding.MoveNext();
            
            if (Button_Next_Click != null)
                Button_Next_Click(null, null);

        }

        public void Button_Last_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           Binding.MoveLast();
             
            if (Button_Last_Click != null)
                Button_Last_Click(null, null);
        }

        public void Button_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ItemEventArg ee = new ItemEventArg();
          
            if (Button_Add_Click != null)
                Button_Add_Click(null, null);
           Binding.AddNew();
        }
        public FormState State
        {
            get;set;
        }
      
        public bool IfAdd
        {
            set
            {
                Button_Add.Visibility = (value ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never);
            }
        }

        internal void setPostion(string v, string serachNo)
        { }

        public bool IfDelete
        {
            set
            {
               Button_Delete.Visibility = (value?DevExpress.XtraBars.BarItemVisibility.Always: DevExpress.XtraBars.BarItemVisibility.Never);
                
            }
        }
        public bool IfSave
        {
            set
            {
               Button_Save.Visibility = (value ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never);
            }
        }
        bool fcanUpdate;
     
      
        public int LangArEn { get; internal set; }
        public object Table { get; internal set; }
        public BindingSource BindingSource { 
            
            get
            {
                return Binding;
            }
            set 
            {
                Binding = value;
                Binding.PositionChanged += Binding_PositionChanged;
                Binding.ListChanged += Button_edit_Click;
            }
        
        }

        private void Button_edit_Click(object sender, ListChangedEventArgs e)
        {
            if (CanEdit && State != FormState.Edit && State != FormState.New )
            {
                if (State != FormState.New)
                {
                    State = FormState.Edit;
                }
              
            }
        }

        public void Button_Save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BarEvArg ee = new BarEvArg();
           
            if (Button_Save_Click != null)
                Button_Save_Click(null, ee);
            if(ee.ReturnedCommand==CommandTOexecute.Ok)
            {
               
                ee.db.SubmitChanges();
                State = FormState.Saved;
                MessageBox.Show("تم الحفظ بنجاح");
            }
        }

        public void Button_Search_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Button_Search_Click != null)
                Button_Search_Click(null, null);
        }

     
        public void Button_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BarEvArg ee = new BarEvArg();
            if (Button_Delete_Click != null)
                Button_Delete_Click(null, ee);
            if (ee.ReturnedCommand == CommandTOexecute.Ok)
            {
                if (MessageBox.Show("هل انت متاكم من حذف السجل الحالي", "تحذير", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Binding.RemoveCurrent();
               
                }
             
            }
        }
        public void UpdateVcr()
        {
            Label_Count.Caption =Binding.Count.ToString();
            TextBox_Index.EditValue =Binding.Position;
            int vCount = 0;
            int vPosition = 0;
            try
            {
                vCount = Binding.Count;
            }
            catch
            {
                vCount = 0;
            }
            try
            {
                vPosition = Binding.Position+1;
            }
            catch
            {
                vPosition = 0;
            }
            if (vCount <= 1)
            {
                Button_First.Enabled = false;
                Button_Prev.Enabled = false;
                Button_Next.Enabled = false;
                Button_Last.Enabled = false;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    lable_Records.Caption = ((vCount == 0) ? "لايوجد سجلات" : "سجل واحد فقط");
                }
                else
                {
                    lable_Records.Caption = ((vCount == 0) ? "No records" : "Only Record");
                }

                return;
            }
            if (vPosition == 1)
            {
                 
                bool enabled = (Button_Prev.Enabled = false);
                Button_First.Enabled = enabled;
               
                enabled = (Button_Next.Enabled = vCount > 1);
                Button_Last.Enabled = enabled;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    lable_Records.Caption = "الأول من " + vCount + " سجلات";
                }
                else
                {
                    lable_Records.Caption = "First of " + vCount + " records";
                }
                return;
            }
            if (vPosition == vCount)
            {
                Button_Last.Enabled = false;
                Button_Next.Enabled = false;
               
                bool enabled = (Button_Prev.Enabled = vCount > 1);
                Button_First.Enabled = enabled;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    lable_Records.Caption = "الأخير من " + vCount + " سجلات";
                }
                else
                {
                    lable_Records.Caption = "Last of " + vCount + " records";
                }
                return;
            }
            Button_First.Enabled = true;
            Button_Prev.Enabled = true;
            Button_Next.Enabled = true;
            Button_Last.Enabled = true;
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                lable_Records.Caption = "السجل " + vPosition + " من " + vCount;
            }
            else
            {
                lable_Records.Caption = "Record " + vPosition + " of " + vCount;
            }
        }

        public void TextBox_Index_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        public void Button_Close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(State==FormState.Edit)
            if (MessageBox.Show("هل تريد حفظ جميع التعديلات والخروج", "Close", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

            }

            if (Button_Close_Click!=null)
            {
                Button_Close_Click(null, null);
            }
           

        }

        public void ذ_LinkDeleted(object sender, DevExpress.XtraBars.LinkEventArgs e)
        {

        }

        public void Binding_PositionChanged(object sender, EventArgs e)
        {
            UpdateVcr();
        }
    }

   
    public enum CommandTOexecute
    {
        Ok, Cancel, NeedPermision
    }
    public class BarEvArg
    {
        public CommandTOexecute ReturnedCommand = CommandTOexecute.Ok;
        public Stock_DataDataContext db;
        public Rate_DataDataContext dbc;
        public BindingSource binding;


    }

}
