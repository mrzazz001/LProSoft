using DevComponents.DotNetBar;
using ProShared.GeneralM;using ProShared;
using InvAcc.Properties;
using ProShared.Stock_Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace InvAcc.Controls
{
    public partial class POSItemControl : UserControl
    {
        public POSItemControl()
        {
            InitializeComponent();//
            TxtPrice.DisplayFormat = VarGeneral.DicemalMask;
            //CheckValue.CheckStateChanged += CheckValue_CheckStateChanged;
            this.TxtPrice.ValueChanged += new System.EventHandler(this.TxtPrice_ValueChanged);
            this.TxtPrice.Click += new System.EventHandler(this.TxtPrice_Click);
            this.Txt_Note.Click += new System.EventHandler(this.TxtPrice_Click);
            DeActivate();
            //            'this.Txt_Note.TextChanged += new System.EventHandler(this.Txt_Note_TextChanged);
            //        '  this.CheckValue.CheckedChanged += new System.EventHandler(this.CheckValue_CheckedChanged_1);
            this.CheckValue.CheckStateChanged += new System.EventHandler(this.CheckValue_CheckStateChanged);
            this.CheckValue.Click += new System.EventHandler(this.TxtPrice_Click);
            this.cmbUnit.Click += new System.EventHandler(this.TxtPrice_Click);

            this.TxtPriceInput.ValueChanged += changes;
            foreach (Control i in Controls)
            {
                i.MouseHover += POSItemControl_MouseHover;
                i.MouseLeave += TableDetails_MouseLeave;
            }
            foreach (Control i in TableDetails.Controls)
            {
                i.MouseHover += POSItemControl_MouseHover;
                i.MouseLeave += TableDetails_MouseLeave;
            }
            this.pictureBox1.MouseHover += POSItemControl_MouseHover;

            this.tableLayoutPanel1.MouseHover += POSItemControl_MouseHover;
            this.TableDetails.MouseHover += POSItemControl_MouseHover;
            this.pictureBox1.MouseLeave += TableDetails_MouseLeave;
            this.tableLayoutPanel1.MouseLeave += TableDetails_MouseLeave;
            this.TableDetails.MouseLeave += TableDetails_MouseLeave;

            //   this.cmbUnit.TextChanged += new System.EventHandler(this.textBox1_TextChanged);

            if (CheckValue.CheckState == CheckState.Checked)
            {
                pictureBox1.Enabled = true;
                cmbUnit.Enabled = true;
                TxtPriceInput.Enabled = true;
                Txt_Note.Enabled = true;              //  button_SrchItemGroup.Enabled = true;
            }
            else
            {

                pictureBox1.Enabled = false;
                cmbUnit.Enabled = false;
                TxtPriceInput.Enabled = false;
                Txt_Note.Enabled = false;
                //   button_SrchItemGroup.Enabled = false;
            }
            active = tableLayoutPanel1.BackColor;

            RightToLeft = RightToLeft.Yes;//controls
        }

        private void changes(object sender, EventArgs e)
        {
            TxtPrice.Value = TxtPriceInput.Value;
        }

        void setunit(T_Unit u)
        {

            if (u.Unit_ID == ItemData.Unit1)
            {
                Txt_Unit.Text = u.Arb_Des;
                TxtPrice.Value = (double)ItemData.UntPri1;
            }
            else if (u.Unit_ID == ItemData.Unit2)

            {
                Txt_Unit.Text = u.Arb_Des;
                TxtPrice.Value = (double)ItemData.UntPri1;
            }
            else if (u.Unit_ID == ItemData.T_Unit3.Unit_ID)

            {
                Txt_Unit.Text = u.Arb_Des;
                TxtPrice.Value = (double)ItemData.UntPri1;

            }
            else if (u.Unit_ID == ItemData.Unit4)


            {
                Txt_Unit.Text = u.Arb_Des;
                TxtPrice.Value = (double)ItemData.UntPri4;

            }
            else if (u.Unit_ID == ItemData.Unit5)

            {
                Txt_Unit.Text = u.Arb_Des;
                TxtPrice.Value = (double)ItemData.UntPri5;

            }
            price = TxtPrice.Value;
            type = u;
            cmbUnit.SelectedValueChanged -= cmbUnit_SelectedValueChanged;
            int i = 0;
            for (i = 0; i < ItemPriceUnits.Count; i++)
            {
                KeyValuePair<T_Unit, double> tmp = (KeyValuePair<T_Unit, double>)ItemPriceUnits[i];
                if (tmp.Key == u)
                    break;
            }
            cmbUnit.SelectedIndex = i;
            cmbUnit.SelectedValueChanged += cmbUnit_SelectedValueChanged;
        }
        public T_Unit type;
        public Hashtable ItemPriceUnits = new Hashtable();
        public Hashtable UnitMap = new Hashtable();
        public void SetitemControlData(string sname, double price)
        {


            CheckValue.Text = sname;
            TxtPrice.Value = price;
        }
        public T_Item ItemData;
        public CheckState State;
        Stock_DataDataContext db;

        public void SetitemControlData(T_Item t)
        {
            if (db == null)
            {
                db = new Stock_DataDataContext(VarGeneral.BranchCS);
            }

            CheckValue.CheckState = CheckState.Unchecked;
            State = CheckState.Unchecked;
            Row_ID = -10;
            ItemData = t;
            this.price = 0;

            CheckValue.Text = t.Arb_Des;
            //TxtPrice.Value = 0;
            T_Item i = t;
            listUnit = db.T_Units.ToList<T_Unit>();
            if (t.ItmImg != null)
                pictureBox1.Image = Utilites.getimage(t.ItmImg);
            else
                pictureBox1.Image = Resources.Customer;
            T_Unit _Unit;
            ItemPriceUnits.Clear();
            UnitMap.Clear();

            List<T_Unit> ITmunits = new List<T_Unit>();
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (i.Unit1 == _Unit.Unit_ID)
                {
                    ITmunits.Add(_Unit);
                    KeyValuePair<T_Unit, double> tmp = new KeyValuePair<T_Unit, double>(_Unit, (double)i.UntPri1);
                    ItemPriceUnits.Add(1, tmp);
                }
                if (i.Unit2 == _Unit.Unit_ID)
                {
                    ITmunits.Add(_Unit);//   cmbunit.Items.Add(_Unit.Arb_Des);

                    KeyValuePair<T_Unit, double> tmp = new KeyValuePair<T_Unit, double>(_Unit, (double)i.UntPri1);
                    ItemPriceUnits.Add(2, tmp);
                }
                if (i.T_Unit3.Unit_ID == _Unit.Unit_ID)
                {
                    ITmunits.Add(_Unit); //cmbunit.Items.Add(_Unit.Arb_Des);

                    KeyValuePair<T_Unit, double> tmp = new KeyValuePair<T_Unit, double>(_Unit, (double)i.UntPri1);
                    ItemPriceUnits.Add(3, tmp);
                }
                if (i.Unit4 == _Unit.Unit_ID)
                {
                    ItemPriceUnits.Add(_Unit, i.UntPri4);

                    KeyValuePair<T_Unit, double> tmp = new KeyValuePair<T_Unit, double>(_Unit, (double)i.UntPri4);
                    ItemPriceUnits.Add(4, tmp);
                }
                if (i.Unit5 == _Unit.Unit_ID)
                {
                    ItemPriceUnits.Add(_Unit, i.UntPri5);
                    KeyValuePair<T_Unit, double> tmp = new KeyValuePair<T_Unit, double>(_Unit, (double)i.UntPri4);
                    ItemPriceUnits.Add(5, tmp);
                }


            }
            if (ITmunits.Count > 0)
            {

                cmbUnit.DataSource = ITmunits;
                cmbUnit.DisplayMember = "Arb_Des";
                cmbUnit.ValueMember = "Unit_No";
                cmbUnit.Tag = i.Itm_ID.ToString();
                cmbUnit.SelectedIndex = 0;
                cmbUnit.SelectedIndexChanged += Unit_SelectedChanged;
            }
            if (ITmunits.Count == 1)
            {
                TableDetails.RowStyles[1].Height = 0;
                TableDetails.RowStyles[2].Height = 0;
            }


            Refresh();
            if (TOTCal_ReadY != null) TOTCal_ReadY(this, null);
        }
        public void SetitemControlDataClear(T_Item t)
        {
            CheckValue.CheckStateChanged -= CheckValue_CheckStateChanged;
            CheckValue.CheckState = CheckState.Unchecked;
            CheckValue.CheckStateChanged += CheckValue_CheckStateChanged;

            State = CheckState.Unchecked;
            Row_ID = -10;
            ItemData = t;

            CheckValue.Text = t.Arb_Des;
            TxtPrice.ValueChanged -= TxtPrice_ValueChanged;
            TxtPrice.Value = 0; setprice(0);
            TxtPrice.ValueChanged += TxtPrice_ValueChanged;

            cmbUnit.SelectedIndex = -1;
            if (TOTCal_ReadY != null) TOTCal_ReadY(this, null);
        }

        public int ControlID;
        public void setprice(double p)
        {
            TxtPriceInput.ValueChanged -= changes;
            TxtPriceInput.Value = p;
            TxtPriceInput.ValueChanged += changes;

        }
        public double getprice()
        {
            return double.Parse(TxtPrice.Text);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public double price
        {
            set
            {
                TxtPrice.Value = value;
            }
            get
            {
                return
             TxtPrice.Value;
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
#pragma warning disable CS0169 // The field 'POSItemControl.ITmunits' is never used
        List<T_Unit> ITmunits;
#pragma warning restore CS0169 // The field 'POSItemControl.ITmunits' is never used

        public void setcheck(CheckState e)
        {
            CheckValue.CheckState = e;
        }
        Color active, checkedcolor = Color.LimeGreen, howvercolor = Color.Orange;
        private void CheckValue_CheckStateChanged(object sender, EventArgs e)
        {


            State = CheckValue.CheckState;
            ItemEventArg ef = new ItemEventArg();
            if (CheckValue.CheckState == CheckState.Checked)
            {
                Activate();
                ef.Action = ActionInv.Add;
                TxtPrice.Enabled = true;
                tableLayoutPanel1.BackColor =
                    checkedcolor;
                TableDetails.BackColor = checkedcolor;
            }
            else
            {
                DeActivate();
                tableLayoutPanel1.BackColor = active;
                TableDetails.BackColor = active;
                ef.Action = ActionInv.Remove;
                TxtPrice.Enabled = false;
            }

            ef.ItemData = ItemData;
            ef.Price = TxtPrice.Value;
            ef.CPanel_ID = cPanel_ID;
            ef.state = CheckValue.CheckState;
            ef.Row_ID = Row_ID;
            if (ItemCheckedChanged != null)
            {
                ItemCheckedChanged(this, ef);
                Row_ID = ef.Row_ID;
                if (ef.Type != null)
                {



                    Txt_Unit.Text = ef.Type.Arb_Des;
                    cmbUnit.SelectedValueChanged -= cmbUnit_SelectedValueChanged;

                    cmbUnit.SelectedText = cmbUnit.GetItemText(ef.Type.Arb_Des);
                    cmbUnit.SelectedValueChanged += cmbUnit_SelectedValueChanged;
                }
                TxtPrice.ValueChanged -= TxtPrice_ValueChanged;

                TxtPrice.Value = ef.Price; setprice(ef.Price);
                TxtPrice.ValueChanged += TxtPrice_ValueChanged;
                TxtPriceInput.ValueChanged -= changes;
                TxtPriceInput.Value = ef.Price;
                TxtPriceInput.ValueChanged += changes;
                this.price = ef.Price;
                if (ef.Action == ActionInv.Remove)
                {


                }

                try
                {
                    price = TxtPrice.Value;

                }
                catch { }
                //                Column_ID = ef.Column_ID;

                if (TOTCal_ReadY != null)
                    TOTCal_ReadY(this, null);

            }


            if (CheckValue.CheckState == CheckState.Checked)
            {

                pictureBox1.Enabled = true;
                cmbUnit.Enabled = true;
                TxtPriceInput.Enabled = true;
                Txt_Note.Enabled = true;
                //   button_SrchItemGroup.Enabled = true;
            }
            else
            {

                pictureBox1.Enabled = false;
                cmbUnit.Enabled = false;
                TxtPriceInput.Enabled = false;
                Txt_Note.Enabled = false;
                //   button_SrchItemGroup.Enabled = false;
            }


            //ItemEventArg ef = new ItemEventArg();
            //State = CheckValue.CheckState;
            //if (CheckValue.CheckState == CheckState.Checked)
            //{
            //    ef.Action = ActionInv.Add;
            //    TxtPrice.Enabled = true;

            //}
            //else
            //{
            //    ef.Action = ActionInv.Remove;

            //    TxtPrice.Enabled = false;
            //}

            //ef.ItemData = ItemData;
            //ef.Price = TxtPrice.Value;
            //ef.CPanel_ID = cPanel_ID;
            //ef.state = State;
            //ef.Row_ID = Row_ID;

            //if (ItemCheckedChanged != null)
            //{

            //    ItemCheckedChanged(this, ef);
            //    Row_ID = ef.Row_ID;


            //    TxtPrice.ValueChanged -= TxtPrice_ValueChanged;
            //    TxtPrice.Value = ef.Price;
            //    TxtPrice.ValueChanged += TxtPrice_ValueChanged;



            //    if (TOTCal_ReadY != null)
            //    {
            //        TOTCal_ReadY(this, null);
            //    }



            //}
            //try
            //{
            //    price = Math.Round(double.Parse(TxtPrice.Text), GeneralM.VarGeneral.DecimalNo);
            //}
            //catch { }

        }
        public delegate void customMessageHandler(System.Object sender,
                                           ItemEventArg e);
        public event customMessageHandler PriceChanged;
#pragma warning disable CS0067 // The event 'POSItemControl.Unit_Changed' is never used
        public event customMessageHandler Unit_Changed;
#pragma warning restore CS0067 // The event 'POSItemControl.Unit_Changed' is never used
#pragma warning disable CS0067 // The event 'POSItemControl.FStatechanged' is never used
        public event customMessageHandler FStatechanged;
#pragma warning restore CS0067 // The event 'POSItemControl.FStatechanged' is never used
        public event customMessageHandler Edit;
        public event customMessageHandler ItemCheckedChanged, TOTCal_ReadY;
        public int Row_ID = -10;
        public int cPanel_ID;
        private void TxtPrice_ValueChanged(object sender, EventArgs e)
        {

            ItemEventArg ef = new ItemEventArg();
            ef.ItemData = ItemData;
            ef.Price = TxtPrice.Value;
            ef.CPanel_ID = cPanel_ID;
            ef.Row_ID = Row_ID;
            if (PriceChanged != null)
            {
                PriceChanged(this, ef);
                TxtPrice.TextChanged -= TxtPrice_ValueChanged;
                TxtPrice.Value = ef.Price;
                //   Row_ID = ef.Row_ID;
                try
                {
                    price = Math.Round(TxtPrice.Value, ProShared.GeneralM.VarGeneral.DecimalNo);
                }
                catch { }
                TxtPrice.TextChanged += TxtPrice_ValueChanged;
                if (TOTCal_ReadY != null)
                {
                    TOTCal_ReadY(this, null);
                }
            }

            TxtPriceInput.ValueChanged -= changes;
            TxtPriceInput.Value = ef.Price;
            TxtPriceInput.ValueChanged += changes;
        }

        internal void setprice(int r, double price)
        {
            if (r == Row_ID)
            {
                TxtPriceInput.ValueChanged -= changes;
                TxtPriceInput.Value = price;
                TxtPriceInput.ValueChanged += changes;
                TxtPrice.ValueChanged -= TxtPrice_ValueChanged;
                TxtPrice.Value = price;
                this.price = price;
                TxtPrice.ValueChanged += TxtPrice_ValueChanged;

            }
        }

        private void TxtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (Edit != null)
                Edit(null, null);
        }

        private void CheckValue_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckValue.CheckState == CheckState.Checked)
            {
                pictureBox1.Enabled = true;
                cmbUnit.Enabled = true;
                TxtPriceInput.Enabled = true;
                Txt_Note.Enabled = true;
            }
            else
            {
                pictureBox1.Enabled = true;
                cmbUnit.Enabled = true;
                TxtPriceInput.Enabled = true;
                Txt_Note.Enabled = true;
            }
        }
#pragma warning disable CS0414 // The field 'POSItemControl.old' is assigned but its value is never used
        CheckState old = CheckState.Indeterminate;
#pragma warning restore CS0414 // The field 'POSItemControl.old' is assigned but its value is never used

        private void CheckValue_Click(object sender, EventArgs e)
        {
            if (Edit != null)
                Edit(null, null);

        }

        private void TxtPrice_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        List<T_Unit> listUnit;
        internal void setData(double price, T_Unit u, int RowID, T_Item t)
        {
            this.price = price;
            CheckValue.CheckStateChanged -= CheckValue_CheckStateChanged;
            CheckValue.CheckState = CheckState.Checked;
            CheckValue.CheckStateChanged += CheckValue_CheckStateChanged;
            TxtPrice.ValueChanged -= TxtPrice_ValueChanged;
            TxtPrice.Value = price;
            ItemData = t;

            State = CheckState.Checked;
            type = u;
            Row_ID = RowID;
            TxtPrice.ValueChanged += TxtPrice_ValueChanged;
            TOTCal_ReadY(this, null);

            if (CheckValue.CheckState == CheckState.Checked)
            {

                //            Txt_Unit.Enabled = true;
                TxtPrice.Enabled = true;
                //          Txt_Note.Enabled = true;
                //              button_SrchItemGroup.Enabled = true;
            }
            else
            {

                //                Txt_Unit.Enabled = false;
                TxtPrice.Enabled = false;

            }
        }
        TextBox Txt_Unit = new TextBox();

        private void Unit_SelectedChanged(object sender, EventArgs e)
        {

        }

        private void superTabControl_Tables_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        {

        }

        private void metroTilePanel_Customer_ItemClick(object sender, EventArgs e)
        {

        }

        private void metroTileItem1_Click(object sender, EventArgs e)
        {

        }

        private void metroTilePanel_Customer_ItemClick_1(object sender, EventArgs e)
        {

        }

        private void metroTilePanel1_ItemClick(object sender, EventArgs e)
        {

        }

        private void POSItemControl_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            CheckValue.CheckState = CheckState.Checked;
        }

        private void TableDetails_RightToLeftChanged(object sender, EventArgs e)
        {
            TableDetails.RightToLeftChanged -= TableDetails_RightToLeftChanged;
            TableDetails.RightToLeft = RightToLeft.No;
            TableDetails.RightToLeftChanged += TableDetails_RightToLeftChanged;

        }

        private void POSItemControl_MouseHover(object sender, EventArgs e)
        {
            if (CheckValue.CheckState != CheckState.Checked)
            {
                tableLayoutPanel1.BackColor = howvercolor;
                TableDetails.BackColor = howvercolor;
            }
        }

        private void TableDetails_MouseLeave(object sender, EventArgs e)
        {
            if (CheckValue.CheckState != CheckState.Checked)
            {
                tableLayoutPanel1.BackColor = active;
                TableDetails.BackColor = active;
            }
        }

        private void cmbUnit_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CheckValue.CheckState == CheckState.Checked)
            {
                T_Unit u = (T_Unit)cmbUnit.SelectedItem;
                ItemEventArg ef = new ItemEventArg();
                ef.Action = ActionInv.setUnit;
                ef.Row_ID = Row_ID;
                ef.state = State;
                ef.ItemData = ItemData;
                ef.Type = u;

                ef.Price = Utilites.ItemPriceOfUnit(u, ItemData);

                if (ItemTypeChanged != null)
                {
                    ItemTypeChanged(this, ef);
                    TxtPrice.ValueChanged -= TxtPrice_ValueChanged;
                    TxtPrice.Value = ef.Price; setprice(ef.Price);
                    price = TxtPrice.Value;
                    TxtPrice.ValueChanged += TxtPrice_ValueChanged;
                    if (TOTCal_ReadY != null) TOTCal_ReadY(this, null);
                }
            }
        }

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TxtPriceInput_TextChanged(object sender, EventArgs e)
        {
            price = TxtPriceInput.Value;
            TxtPrice.Value = TxtPriceInput.Value;

        }
        public void Activate()
        {


        }
        public void DeActivate()
        {

        }
        private void CheckValue_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {


        }

        //   public event customMessageHandler ItemCheckedChanged;
        public event customMessageHandler ItemTypeChanged;

        private void TableDetails_Paint(object sender, PaintEventArgs e)
        {

        }

        // public event customMessageHandler TOTCal_ReadY;

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
    public class ItemUnitPrices
    {
        public double Price;
        public T_Unit Unit;
    }
}
