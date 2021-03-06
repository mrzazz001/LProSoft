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
using ProShared.Stock_Data;
using ProShared.GeneralM;
using InvAcc.Controls;

namespace InvAcc.Forms.Eqr_Version.New
{
    public partial class XFrmTenant :BaseForm
    {
        private T_AccDef _AccDefBind=new T_AccDef();

        public XFrmTenant()
        {
            InitializeComponent();
            dbInstance = new Stock_DataDataContext();
            // This line of code is generated by Data Source Configuration Wizard
            t_TenantsBindingSource.DataSource =db.T_Tenants;
            // This line of code is generated by Data Source Configuration Wizard
            t_NationalitiesBindingSource.DataSource =db.T_Nationalities;
        }
        public T_User Permmission
        {
            get
            {
                return permission;
            }
            set
            {
                if (value != null && value.UsrNo != "")
                {
                    permission = value;
                    if (!VarGeneral.TString.ChkStatShow(value.Eqar_TenantStr, 1))
                    {
                        IfAdd = false;
                    }
                    else
                    {
                        IfAdd = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Eqar_TenantStr, 2))
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Eqar_TenantStr, 3))
                    {
                        IfDelete = false;
                    }
                    else
                    {
                        IfDelete = true;
                    }
                }
            }
        }

        private void XFrmTenant_Load(object sender, EventArgs e)
        {
            Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
            if (columns_Names_visible.Count == 0)
            {
                columns_Names_visible.Add("tenantNo", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
                columns_Names_visible.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
                columns_Names_visible.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            }
        }

        private void t_TenantsBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            T_Tenant et = new T_Tenant();
            et.tenantNo = db.MaxTenantDataNo;
            et.tenantID = et.tenantNo;
            e.NewObject = et;
            if (!string.IsNullOrEmpty(VarGeneral.Settings_Sys.tenantAcc))
            {
                int Value = 0;
                List<T_AccDef> q = (from t in db.T_AccDefs
                                    where t.ParAcc == VarGeneral.Settings_Sys.tenantAcc
                                    orderby t.AccDef_ID
                                    select t).ToList();
                if (q.Count == 0)
                {
                    AccNoTextEdit.EditValue = VarGeneral.Settings_Sys.tenantAcc + "001";
                }
                else
                {
                    _AccDefBind = q[q.Count - 1];
                    string _Zero = "";
                    for (int iiCnt = 0; iiCnt < _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Length && _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Substring(iiCnt, 1) == "0"; iiCnt++)
                    {
                        _Zero += _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Substring(iiCnt, 1);
                    }
                    Value = int.Parse(_AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length)) + 1;
                    if (!string.IsNullOrEmpty(_Zero))
                    {
                        AccNoTextEdit.Text = _AccDefBind.ParAcc + _Zero + Value;
                    }
                    else
                    {
                        AccNoTextEdit.Text = _AccDefBind.ParAcc + Value;
                    }
                }
            }

            NameATextEdit.Focus();
        }

        private void ubar1_Button_Search_Click(object sender, Controls.BarEvArg e)
        {
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_Tenant";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                var q = (from i in db.T_Tenants where i.tenantNo == int.Parse(frm.Serach_No) select i).FirstOrDefault();
                int index = db.T_Tenants.ToBindingList<T_Tenant>().IndexOf(q);
                if (index != -1)
                {

                    ubar1.Binding.Position = index;
                }
            }

        }
    }
}