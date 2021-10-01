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
        private bool CanEdit;

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
                                        ItemEventArg e);
        public event customMessageHandler Button_Next_Click;
        public event customMessageHandler Button_Previous_Click;
        public event customMessageHandler Button_First_Click;
        public event customMessageHandler Button_Last_Click;
        public event customMessageHandler Button_Add_Click;
        public event customMessageHandler Button_Save_Click;
        public event customMessageHandler Button_Delete_Click;
        public event customMessageHandler Button_Close_Click;

        public event customMessageHandler Button_Search_Click;
        public BindingSource Binding;
        private void Button_Prev_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Binding.MovePrevious();
            UpdateVcr();
            if (Button_Previous_Click != null)
                Button_Previous_Click(null, null);
        }

        private void Button_First_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Binding.MoveFirst();
                UpdateVcr();
            }
            catch { }
            if (Button_First_Click != null)
                    Button_First_Click(null, null);

         }

        private void Button_Next_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Binding.MoveNext();
            UpdateVcr();
            if (Button_Next_Click != null)
                Button_Next_Click(null, null);

        }

        private void Button_Last_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Binding.MoveLast();
            UpdateVcr();
            if (Button_Last_Click != null)
                Button_Last_Click(null, null);
        }

        private void Button_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Binding.AddNew();
            if (Button_Add_Click != null)
                Button_Add_Click(null, null);
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
     
      
        public int LangArEn { get; private set; }
        public object Table { get; internal set; }

        private void Button_Save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Button_Save.Enabled)
            {
                return;
            }
            if (State == FormState.Edit && !CanEdit)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (State == FormState.New && !Button_Add.Enabled)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
          
            if (Button_Save_Click != null)
                Button_Save_Click(null, null);

        }

        private void Button_Search_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Button_Search_Click != null)
                Button_Search_Click(null, null);
        }
     
     
        private void Button_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {   if (Button_Delete_Click != null)
                Button_Delete_Click(null, null);
        }
        private void UpdateVcr()
        {
            Label_Count.Caption = Binding.Count.ToString();
            TextBox_Index.EditValue = Binding.Position;
            int vCount = 0;
            int vPosition = 0;
            try
            {
                vCount = int.Parse(Label_Count.Caption);
            }
            catch
            {
                vCount = 0;
            }
            try
            {
                vPosition = int.Parse(TextBox_Index.EditValue.ToString());
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
                DevExpress.XtraBars.BarLargeButtonItem Button_Firsst = Button_First;
                bool enabled = (Button_Prev.Enabled = false);
                Button_Firsst.Enabled = enabled;
                DevExpress.XtraBars.BarLargeButtonItem Button_Lasst = Button_Last;
                enabled = (Button_Next.Enabled = vCount > 1);
                Button_Lasst.Enabled = enabled;
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
                DevExpress.XtraBars.BarLargeButtonItem Button_First2 = Button_First;
                bool enabled = (Button_Prev.Enabled = vCount > 1);
                Button_First2.Enabled = enabled;
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
            //Button_First.Enabled = true;
            //Button_Prev.Enabled = true;
            //Button_Next.Enabled = true;
            //Button_Last.Enabled = true;
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
             //   lable_Records.Caption = "السجل " + vPosition + " من " + vCount;
            }
            else
            {
               // lable_Records.Caption = "Record " + vPosition + " of " + vCount;
            }
        }

        private void TextBox_Index_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void Button_Close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Button_Close_Click!=null)
            {
                Button_Close_Click(null, null);
            }
        }

        private void ذ_LinkDeleted(object sender, DevExpress.XtraBars.LinkEventArgs e)
        {

        }
    }
}
