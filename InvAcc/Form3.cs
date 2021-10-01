using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using Check_Data.Forms;
using InvAcc.Controls.POS;
using InvAcc.Forms;
using ProShared.GeneralM;using ProShared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InvAcc
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            new FrmMain(null, null,"1", 0);
            VarGeneral.UserLang = 0;
            poS_ItemsPanel1.Product_Click += fsa;
            C1.Win.C1Input.C1Button b1 = new C1.Win.C1Input.C1Button();
            // Set up color column.
            Column c = FlxInv.Cols[39];
            c.DataType = typeof(C1Button);
            c.Editor = b1;

          

            c.ComboList = "...";

        }

        private void fasdfa(object sender, EventArgs e)
        {
//throw new NotImplementedException();
        }

        private void _flex_CellButtonClick(object sender, RowColEventArgs e)
        {
            // Create color picker dialog.
            ColorDialog clrDlg = new ColorDialog();

            // Initialize the dialog.
#pragma warning disable CS0252 // Possible unintended reference comparison; to get a value comparison, cast the left hand side to type 'Type'
            if (FlxInv[e.Row, e.Col] == typeof(Button))
#pragma warning restore CS0252 // Possible unintended reference comparison; to get a value comparison, cast the left hand side to type 'Type'
            {
               }

            // Get new color from dialog and assign it to the cell.
            if (clrDlg.ShowDialog() == DialogResult.OK)
            {
                FlxInv[e.Row, e.Col] = clrDlg.Color;
            }
        }

        private void fsa(object sender, Controls.ItemEventArg e)
        {
            this.Text = e.item_No;
        }

        private void Form3_Click(object sender, EventArgs e)
        {
         
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                poS_ItemsPanel1.Dock = DockStyle.Fill;
                poS_ItemsPanel1.Invalidate();
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            }catch(Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            { }
        }

        private void FlxInv_CellButtonClick(object sender, RowColEventArgs e)
        {
            ColorDialog clrDlg = new ColorDialog();

            // Initialize the dialog.
#pragma warning disable CS0252 // Possible unintended reference comparison; to get a value comparison, cast the left hand side to type 'Type'
            if (FlxInv[e.Row, e.Col] == typeof(Button))
#pragma warning restore CS0252 // Possible unintended reference comparison; to get a value comparison, cast the left hand side to type 'Type'
            {
            }

            // Get new color from dialog and assign it to the cell.
            if (clrDlg.ShowDialog() == DialogResult.OK)
            {
                FlxInv[e.Row, e.Col] = clrDlg.Color;
            }
        }

        private void FlxInv_Click(object sender, EventArgs e)
        {

        }

        private void button_opendraft_Click(object sender, EventArgs e)
        {
            Frm_Main frm = new Frm_Main();
            frm.Show();
        }
    }
}
