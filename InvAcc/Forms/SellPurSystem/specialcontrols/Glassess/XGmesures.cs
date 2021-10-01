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

namespace InvAcc.Forms.SellPurSystem.specialcontrols
{
    public partial class XGmesures : DevExpress.XtraEditors.XtraUserControl
    {
        public XGmesures()
        {
            InitializeComponent();
        }
        public void setvalues(T_INVDET t)
        {
            RSpy.Value = t.RSph.GetValueOrDefault();
            RCyl.Value = t.RCyl.GetValueOrDefault();
            RAxis.Value = t.RAxis.GetValueOrDefault();
            RAdd.Value = t.RAdd_.GetValueOrDefault();
            RIPD.Value = t.RIPD.GetValueOrDefault();
            ITemName.Text = t.ItmDes;
            LSpy.Value = t.LSph.GetValueOrDefault();
            LCyl.Value = t.LCyl.GetValueOrDefault();
            LAxis.Value = t.LAxis.GetValueOrDefault();
            LAdd.Value = t.LAdd_.GetValueOrDefault();
            LPD.Value = t.LIPD.GetValueOrDefault();
        }
        public void clear()
        {
            RSpy.Value =0.0;//t.RSph.GetValueOrDefault();
            RCyl.Value =0.0;//t.RCyl.GetValueOrDefault();
            RAxis.Value =0.0;//t.RAxis.GetValueOrDefault();
            RAdd.Value =0.0;//t.RAdd_.GetValueOrDefault();
            RIPD.Value =0.0;//t.RIPD.GetValueOrDefault();
            ITemName.Text ="";//t.ItmDes;
            LSpy.Value =0.0;//t.LSph.GetValueOrDefault();
            LCyl.Value =0.0;//t.LCyl.GetValueOrDefault();
            LAxis.Value =0.0;//t.LAxis.GetValueOrDefault();
            LAdd.Value =0.0;//t.LAdd_.GetValueOrDefault();
            LPD.Value =0.0;//t.LIPD.GetValueOrDefault();
        }
        public void getValues(T_INVDET t)
        {
            t.RSph = RSpy.Value;
            t.RCyl = RCyl.Value;
            t.RAxis = RAxis.Value;
           
            t.RAdd_= RAdd.Value;
            t.RIPD= RIPD.Value;
         
            t.LSph = LSpy.Value;
            t.LCyl = LCyl.Value;
            t.LAxis = LAxis.Value;
           
            t.LAdd_ = LAdd.Value;
            t.LIPD = LPD.Value;

        }
        private void labelControl6_Click(object sender, EventArgs e)
        {

        }

        private void XGmesures_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar=='\r')
            {
                SendKeys.Send("{tab}");
            }
        }
    }
}
