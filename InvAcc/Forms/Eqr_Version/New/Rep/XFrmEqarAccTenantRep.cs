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

namespace InvAcc.Forms.Eqr_Version.New.Rep
{
    public partial class XFrmEqarAccTenantRep : BaseRepForm
    {
        public XFrmEqarAccTenantRep()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            t_TenantsBindingSource.DataSource = new ProShared.Stock_Data.Stock_DataDataContext().T_Tenants;
        }

        private void XFrmEqarAccTenantRep_Load(object sender, EventArgs e)
        {

        }
    }
}