﻿using System;
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

namespace  InvAcc.Forms
{
    public partial class FrmPrinters : DevExpress.XtraEditors.XtraForm
    {
        public FrmPrinters()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            // This line of code is generated by Data Source Configuration Wizard
            WindowState = FormWindowState.Maximized;
        }
        void loadinv(int id)
        {
            xPrinterSetting1.init(id, 1);
        }
        private void accordionControlElement7_Click(object sender, EventArgs e)
        {

        }
        private class Item
        {
            public string Name;
            public int Value;
            public Item(string name, int value)
            {
                Name = name;
                Value = value;
            }
            public override string ToString()
            {
                return Name;
            }
        }
        private void accordionControlElement15_Click(object sender, EventArgs e)
        {
         
        }

        private void CmbInvType_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void XtraForm1_Load(object sender, EventArgs e)
        {

        }

        private void XtraForm1_FormClosing(object sender, FormClosingEventArgs e)
        {
        //    Close();
        }

        private void xPrinterSetting1_Load(object sender, EventArgs e)
        {
          
        }
    }
}