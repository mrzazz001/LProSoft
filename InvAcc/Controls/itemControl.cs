using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using System;
using System.Windows.Forms;

namespace InvAcc.Controls
{
    public partial class itemControl : UserControl
    {

        public void SetitemControlData(string sname, double price)
        {


            CheckValue.Text = sname;
            TxtPrice.Value = price;
        }
        public T_Item ItemData;
        public CheckState State;
        public void SetitemControlData(T_Item t)
        {

            CheckValue.CheckState = CheckState.Unchecked;
            State = CheckState.Unchecked;
            Row_ID = -10;
            ItemData = t;

            CheckValue.Text = (VarGeneral.UserLang == 0 ? t.Arb_Des : t.Eng_Des);
            TxtPrice.Value = 0;
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

            CheckValue.Text = (VarGeneral.UserLang == 0 ? t.Arb_Des : t.Eng_Des);
            TxtPrice.ValueChanged -= TxtPrice_ValueChanged;
            TxtPrice.Value = 0;
            TxtPrice.ValueChanged += TxtPrice_ValueChanged;
            if (TOTCal_ReadY != null) TOTCal_ReadY(this, null);
        }

        public int ControlID;
        public itemControl()
        {
            InitializeComponent();//
            TxtPrice.DisplayFormat = VarGeneral.DicemalMask;
            RightToLeft = RightToLeft.Yes;//controls
        }
        public void setprice(double p)
        {
            TxtPrice.Value = p;


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
        public void setcheck(CheckState e)
        {
            CheckValue.CheckState = e;
        }
        private void CheckValue_CheckStateChanged(object sender, EventArgs e)
        {
            ItemEventArg ef = new ItemEventArg();
            State = CheckValue.CheckState;
            if (CheckValue.CheckState == CheckState.Checked)
            {
                ef.Action = ActionInv.Add;
                TxtPrice.Enabled = true;

            }
            else
            {
                ef.Action = ActionInv.Remove;

                TxtPrice.Enabled = false;
            }

            ef.ItemData = ItemData;
            ef.Price = TxtPrice.Value;
            ef.CPanel_ID = cPanel_ID;
            ef.state = State;
            ef.Row_ID = Row_ID;

            if (ItemCheckedChanged != null)
            {

                ItemCheckedChanged(this, ef);
                Row_ID = ef.Row_ID;


                TxtPrice.ValueChanged -= TxtPrice_ValueChanged;
                TxtPrice.Value = ef.Price;
                TxtPrice.ValueChanged += TxtPrice_ValueChanged;



                if (TOTCal_ReadY != null)
                {
                    TOTCal_ReadY(this, null);
                }



            }
            try
            {
                price = Math.Round(double.Parse(TxtPrice.Text), ProShared.GeneralM.VarGeneral.DecimalNo);
            }
            catch { }

        }
        public delegate void customMessageHandler(System.Object sender,
                                           ItemEventArg e);
        public event customMessageHandler PriceChanged;
#pragma warning disable CS0067 // The event 'itemControl.FStatechanged' is never used
        public event customMessageHandler FStatechanged;
#pragma warning restore CS0067 // The event 'itemControl.FStatechanged' is never used
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

                TxtPrice.TextChanged += TxtPrice_ValueChanged;
                if (TOTCal_ReadY != null)
                {
                    TOTCal_ReadY(this, null);
                }
            }
            try
            {
                price = Math.Round(double.Parse(TxtPrice.Text), ProShared.GeneralM.VarGeneral.DecimalNo);
            }
            catch { }

        }

        internal void setprice(int r, double price)
        {
            if (r == Row_ID)
            {
                TxtPrice.ValueChanged -= TxtPrice_ValueChanged;
                TxtPrice.Value = price;
                TxtPrice.ValueChanged += TxtPrice_ValueChanged;

            }
        }

        private void TxtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (Edit != null)
                Edit(null, null);
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            tableLayoutPanel1.RightToLeft = (VarGeneral.UserLang == 0 ? RightToLeft.Yes : RightToLeft.No);
        }
            private void CheckValue_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckValue.CheckState == CheckState.Checked)
            {
                TxtPrice.Enabled = true;
            }
            else
                TxtPrice.Enabled = false;
        }
#pragma warning disable CS0414 // The field 'itemControl.old' is assigned but its value is never used
        CheckState old = CheckState.Indeterminate;
#pragma warning restore CS0414 // The field 'itemControl.old' is assigned but its value is never used

        private void CheckValue_Click(object sender, EventArgs e)
        {
            if (Edit != null)
                Edit(null, null);

        }

        private void TxtPrice_Click(object sender, EventArgs e)
        {
            if (Edit != null)
                Edit(null, null);

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void itemControl_Load(object sender, EventArgs e)
        {

            tableLayoutPanel1.RightToLeft = (VarGeneral.UserLang == 0 ? RightToLeft.Yes : RightToLeft.No);
          this
                .RightToLeft = (VarGeneral.UserLang == 0 ? RightToLeft.Yes : RightToLeft.No);

        }

        internal void setData(double price, T_Unit u, int RowID, T_Item t)
        {
            CheckValue.CheckStateChanged -= CheckValue_CheckStateChanged;
            CheckValue.CheckState = CheckState.Checked;
            CheckValue.CheckStateChanged += CheckValue_CheckStateChanged;
            TxtPrice.ValueChanged -= TxtPrice_ValueChanged;
            TxtPrice.Value = price;
            ItemData = t;
            State = CheckState.Checked;
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
    }



}
