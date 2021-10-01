﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Data.Linq;
using ProShared.Stock_Data;

namespace InvAcc.Forms
{
    public partial class FormInvoicesDataViewre : Form
    {



        public FormInvoicesDataViewre()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            linqServerModeSource1.QueryableSource = new ProShared.Stock_Data.Stock_DataDataContext().T_INVHEDs;
            // This line of code is generated by Data Source Configuration Wizard
            gridControl1.DataSource = new ProShared.Stock_Data.Stock_DataDataContext().T_INVHEDs;
            // This line of code is generated by Data Source Configuration Wizard
            linqServerModeSource2.QueryableSource = new ProShared.Stock_Data.Stock_DataDataContext().T_GDHEADs;
            // This line of code is generated by Data Source Configuration Wizard


            repositoryItemLookUpEdit2.DataSource = new ProShared.Stock_Data.Rate_DataDataContext().T_Users;
            this.repositoryItemLookUpEdit2.DisplayMember = "UsrNamA";
            this.repositoryItemLookUpEdit2.ValueMember = "UsrNo";
            repositoryItemButtonEdit2.Click += Verication_Click;
           
        }

        private void Verication_Click(object sender, EventArgs e)
        {
            try
            {
                T_INVHED f = (T_INVHED)gridView1.GetFocusedRow();
 }
            catch
            {

            }

            }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void FormInvoicesDataViewre_Load(object sender, EventArgs e)
        {

        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                T_INVHED f = (T_INVHED)gridView1.GetRow(e.RowHandle);

                gridView3.ActiveFilter.Clear();
                string r = "";
                if (f.TaxGaidID != null)
                {
                    r += " OR " + "[gdhead_ID] = " + f.TaxGaidID;
                }
                if (f.GadeId != null)
                {
                    r += " OR " + "[gdhead_ID] = " + f.GadeId;
                }
                if (f.CommGaidID != null)
                {
                    r += " OR " + "[gdhead_ID] = " + f.CommGaidID;
                }
                if (f.DisGaidID1 != null)
                {
                    r += " OR " + "[gdhead_ID] = " + f.DisGaidID1
                        ;
                }
                gridView3.ActiveFilterString = r.TrimStart(" OR".ToCharArray());
            }
            catch
            {

            }

        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
          
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                T_INVHED f = (T_INVHED)gridView1.GetRow(e.FocusedRowHandle);

                gridView3.ActiveFilter.Clear();
                string r = "";
                if (f.TaxGaidID != null)
                {
                    r += " OR " + "[gdhead_ID] = " + f.TaxGaidID;
                }
                if (f.GadeId != null)
                {
                    r += " OR " + "[gdhead_ID] = " + f.GadeId;
                }
                if (f.CommGaidID != null)
                {
                    r += " OR " + "[gdhead_ID] = " + f.CommGaidID;
                }
                if (f.DisGaidID1 != null)
                {
                    r += " OR " + "[gdhead_ID] = " + f.DisGaidID1
                        ;
                }
                gridView3.ActiveFilterString = r.TrimStart(" OR".ToCharArray());
            }
            catch
            {

            }


        }
    }
}