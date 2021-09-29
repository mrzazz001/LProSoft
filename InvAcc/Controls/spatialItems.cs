using InvAcc.Forms;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace InvAcc.Controls
{

    public partial class spatialItems : UserControl
    {
        public spatialItems()
        {
            InitializeComponent();//
            TxtPrice.DisplayFormat = VarGeneral.DicemalMask;

            if (CheckValue.CheckState == CheckState.Checked)
            {

                Txt_Unit.Enabled = true;
                TxtPrice.Enabled = true;
                Txt_Note.Enabled = true;
                button_SrchItemGroup.Enabled = true;
            }
            else
            {

                Txt_Unit.Enabled = false;
                TxtPrice.Enabled = false;
                Txt_Note.Enabled = false;
                button_SrchItemGroup.Enabled = false;
            }
            //  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));

            button_SrchItemGroup.Click += button_SrchItemGroup_CheckedChanged;
        }
        public T_Item ItemData;
        public int ControlID;

        public void SetitemControlDataClear(T_Item t)
        {
            CheckValue.CheckStateChanged -= CheckValue_CheckStateChanged;
            CheckValue.CheckState = CheckState.Unchecked;
            CheckValue.CheckStateChanged += CheckValue_CheckStateChanged;

            State = CheckState.Unchecked;
            Row_ID = -10;
            ItemData = t;

            CheckValue.Text = (VarGeneral.UserLang == 0 ? t.Arb_Des : t.Eng_Des);
            text = (VarGeneral.UserLang == 0 ? t.Arb_Des : t.Eng_Des);
            TxtPrice.ValueChanged -= TxtPrice_ValueChanged;
            TxtPrice.Value = 0;
            TxtPrice.ValueChanged += TxtPrice_ValueChanged;
            if (TOTCal_ReadY != null) TOTCal_ReadY(this, null);
        }
        public void setItemData(T_Item t)
        {
            CheckValue.CheckState = CheckState.Unchecked;
            State = CheckState.Unchecked;
            Row_ID = -10;
            ItemData = t;
            Header = false;
            text = (VarGeneral.UserLang == 0 ? t.Arb_Des : t.Eng_Des);
            CheckValue.Text = text;
            TxtPrice.Value = 0;
            if (TOTCal_ReadY != null) TOTCal_ReadY(this, null);


        }
        public bool Header;
        public void setHeader(string n, string t, string m, string p)
        {
            Column1.Text = n;
            Column2.Text = t;
            column3.Text = m;
            Header = true;
            Column4.Text = p;
            PHeader.BringToFront();


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
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private Dictionary<string, ColumnDictinary> Dir_ButSearch = new Dictionary<string, ColumnDictinary>();

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public class ColumnDictinary
        {
            public string AText = string.Empty;
            public string EText = string.Empty;
            public bool IfDefault = false;
            public string Format = string.Empty;
            public ColumnDictinary(string aText, string eText, bool ifDefault, string format)
            {
                AText = aText;
                EText = eText;
                IfDefault = ifDefault;
                Format = format;
            }
        }
        private void button_SrchItemGroup_Click(object sender, EventArgs e)
        {

        }
        void setunit(T_Unit u)
        {

            if (u.Unit_ID == ItemData.Unit1)
            {
                Txt_Unit.Text = (VarGeneral.UserLang == 0 ? u.Arb_Des : u.Eng_Des); ;
                TxtPrice.Value = (double)ItemData.UntPri1;
            }
            else if (u.Unit_ID == ItemData.Unit2)

            {
                Txt_Unit.Text = (VarGeneral.UserLang == 0 ? u.Arb_Des : u.Eng_Des); ;
                TxtPrice.Value = (double)ItemData.UntPri2;
            }
            else if (u.Unit_ID == ItemData.Unit3)

            {
                Txt_Unit.Text = (VarGeneral.UserLang == 0 ? u.Arb_Des : u.Eng_Des); ;
                TxtPrice.Value = (double)ItemData.UntPri3;

            }
            else if (u.Unit_ID == ItemData.Unit4)


            {
                Txt_Unit.Text = (VarGeneral.UserLang == 0 ? u.Arb_Des : u.Eng_Des); ;
                TxtPrice.Value = (double)ItemData.UntPri4;

            }
            else if (u.Unit_ID == ItemData.Unit5)

            {
                Txt_Unit.Text = (VarGeneral.UserLang == 0 ? u.Arb_Des : u.Eng_Des); ;
                TxtPrice.Value = (double)ItemData.UntPri5;

            }
            price = TxtPrice.Value;
            type = u;
        }
        T_Unit type;
        internal void setData(double price, T_Unit u, int RowID, T_Item t)
        {
            CheckValue.CheckStateChanged -= CheckValue_CheckStateChanged;
            CheckValue.CheckState = CheckState.Checked;
            CheckValue.CheckStateChanged += CheckValue_CheckStateChanged;

            TxtPrice.ValueChanged -= TxtPrice_ValueChanged;
            setunit(u);
            type = u;
            TxtPrice.Value = price;
            ItemData = t;
            State = CheckState.Checked;
            Row_ID = RowID;
            TxtPrice.ValueChanged += TxtPrice_ValueChanged;

            if (CheckValue.CheckState == CheckState.Checked)
            {

                Txt_Unit.Enabled = true;
                TxtPrice.Enabled = true;
                Txt_Note.Enabled = true;
                button_SrchItemGroup.Enabled = true;
            }
            else
            {

                Txt_Unit.Enabled = false;
                TxtPrice.Enabled = false;
                Txt_Note.Enabled = false;
                button_SrchItemGroup.Enabled = false;
            }
            TOTCal_ReadY(this, null);
        }

        private void CheckValue_CheckStateChanged(object sender, EventArgs e)
        {
            State = CheckValue.CheckState;
            ItemEventArg ef = new ItemEventArg();
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
            ef.state = CheckValue.CheckState;
            ef.Row_ID = Row_ID;
            if (ItemCheckedChanged != null)
            {
                ItemCheckedChanged(this, ef);
                Row_ID = ef.Row_ID;
                if (ef.Type != null)
                    setunit(ef.Type);
                TxtPrice.ValueChanged -= TxtPrice_ValueChanged;

                TxtPrice.Value = ef.Price;
                TxtPrice.ValueChanged += TxtPrice_ValueChanged;

                if (ef.Action == ActionInv.Remove)
                {

                    if (TOTCal_ReadY != null)
                        TOTCal_ReadY(this, null);
                }


                //                Column_ID = ef.Column_ID;



            }
            try
            {
                price = TxtPrice.Value;

            }
            catch { }

            if (CheckValue.CheckState == CheckState.Checked)
            {

                Txt_Unit.Enabled = true;
                TxtPrice.Enabled = true;
                Txt_Note.Enabled = true;
                button_SrchItemGroup.Enabled = true;
            }
            else
            {

                Txt_Unit.Enabled = false;
                TxtPrice.Enabled = false;
                Txt_Note.Enabled = false;
                button_SrchItemGroup.Enabled = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            Txt_Note.Text = this.Location.ToString();

        }
        //public event EventHandler PriceChanged
        //{
        //    add { TxtPrice.ValueChanged += value; }
        //    remove { TxtPrice.ValueChanged -= value; }
        //}
        public int Flxinv_RowID
        {
            set
            {
                Flxinv_RowID = value;

            }
            get
            {
                return Flxinv_RowID;
            }
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
        public CheckState State;
        public void setcheck(CheckState e)
        {
            CheckValue.CheckState = e;

        }

        public delegate void customMessageHandler(System.Object sender,
                                         ItemEventArg e);
        public event customMessageHandler PriceChanged;


        public event customMessageHandler ItemCheckedChanged;
        public event customMessageHandler ItemTypeChanged;
        public event customMessageHandler TOTCal_ReadY;

        public int Row_ID = -10;
        public int Column_ID = -10;
        private void TxtPrice_ValueChanged(object sender, EventArgs e)
        {

            ItemEventArg ef = new ItemEventArg();
            ef.ItemData = ItemData;
            ef.CPanel_ID = cPanel_ID;
            ef.Price = TxtPrice.Value;
            ef.Row_ID = Row_ID;
            if (PriceChanged != null)
            {
                PriceChanged(this, ef);
                TxtPrice.ValueChanged -= TxtPrice_ValueChanged;
                TxtPrice.Value = ef.Price;
                price = ef.Price;

                TxtPrice.ValueChanged += TxtPrice_ValueChanged;
                if (TOTCal_ReadY != null)
                {
                    TOTCal_ReadY(this, null);
                }

            }
            try
            {
                price = TxtPrice.Value;

            }
            catch { }
        }
        public int cPanel_ID;
        private void Txt_Note_TextChanged(object sender, EventArgs e)
        {

        }

        private void CheckValue_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckValue_CheckedChanged_1(object sender, EventArgs e)
        {

            if (CheckValue.CheckState == CheckState.Checked)
            {

                Txt_Unit.Enabled = true;
                TxtPrice.Enabled = true;
                Txt_Note.Enabled = true;
                button_SrchItemGroup.Enabled = true;
            }
            else
            {

                Txt_Unit.Enabled = false;
                TxtPrice.Enabled = false;
                Txt_Note.Enabled = false;
                button_SrchItemGroup.Enabled = false;
            }
        }
        public event customMessageHandler Edit;

        private void TxtPrice_Click(object sender, EventArgs e)
        {
            if (Edit != null)
                Edit(null, null);
        }
        Stock_DataDataContext db;
        private void button_SrchItemGroup_CheckedChanged(object sender, EventArgs e)
        {
            if (db == null) db = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_Unit> listUnit = db.T_Units.ToList<T_Unit>();
            T_Unit _Unit = null;
            FrmItemSize frm = new FrmItemSize(ItemData.Itm_No);
            frm.Tag = VarGeneral.CurrentLang;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.vSts_Op)
            {
                if (frm.vSize_ == 0)
                {
                    for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                    {
                        _Unit = listUnit[iiCnt];
                        if (ItemData.Unit1 == _Unit.Unit_ID)
                        {
                            //  ItemData.Pack1.Value;
                            Txt_Unit.Text = (VarGeneral.UserLang == 0 ? _Unit.Arb_Des : _Unit.Eng_Des);

                            //  DefUnitE = _Unit.Eng_Des;
                            //   FlxInv.SetData(FlxInv.Row, 8, ItemData.UntPri1.Value);
                            //   FlxInv.SetData(FlxInv.Row, 11, ItemData.Pack1.Value);
                            break;
                        }
                    }
                }
                else if (frm.vSize_ == 1)
                {
                    for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                    {
                        _Unit = listUnit[iiCnt];
                        if (ItemData.Unit2 == _Unit.Unit_ID)
                        {
                            //  ItemData.Pack2.Value;
                            Txt_Unit.Text = (VarGeneral.UserLang == 0 ? _Unit.Arb_Des : _Unit.Eng_Des);
                            //  DefUnitE = _Unit.Eng_Des;
                            //   FlxInv.SetData(FlxInv.Row, 8, ItemData.UntPri2.Value);
                            //   FlxInv.SetData(FlxInv.Row, 11, ItemData.Pack2.Value);
                            break;
                        }
                    }
                }
                else if (frm.vSize_ == 2)
                {
                    for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                    {
                        _Unit = listUnit[iiCnt];
                        if (ItemData.Unit3 == _Unit.Unit_ID)
                        {
                            //  ItemData.Pack3.Value;
                            Txt_Unit.Text = (VarGeneral.UserLang == 0 ? _Unit.Arb_Des : _Unit.Eng_Des);
                            //  DefUnitE = _Unit.Eng_Des;
                            //   FlxInv.SetData(FlxInv.Row, 8, ItemData.UntPri3.Value);
                            //   FlxInv.SetData(FlxInv.Row, 11, ItemData.Pack3.Value);
                            break;
                        }
                    }
                }
                else if (frm.vSize_ == 3)
                {
                    for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                    {
                        _Unit = listUnit[iiCnt];
                        if (ItemData.Unit4 == _Unit.Unit_ID)
                        {
                            //  ItemData.Pack4.Value;
                            Txt_Unit.Text = (VarGeneral.UserLang == 0 ? _Unit.Arb_Des : _Unit.Eng_Des);
                            //  DefUnitE = _Unit.Eng_Des;
                            //   FlxInv.SetData(FlxInv.Row, 8, ItemData.UntPri4.Value);
                            //   FlxInv.SetData(FlxInv.Row, 11, ItemData.Pack4.Value);
                            break;
                        }
                    }
                }
                else
                {
                    for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                    {
                        _Unit = listUnit[iiCnt];
                        if (ItemData.Unit5 == _Unit.Unit_ID)
                        {

                            Txt_Unit.Text = (VarGeneral.UserLang == 0 ? _Unit.Arb_Des : _Unit.Eng_Des);
                            //  DefUnitE = _Unit.Eng_Des;
                            //   FlxInv.SetData(FlxInv.Row, 8, ItemData.UntPri5.Value);
                            //   FlxInv.SetData(FlxInv.Row, 11, ItemData.Pack5.Value);
                            break;
                        }
                    }
                }
                if (_Unit != null)
                {
                    T_Unit u = _Unit;
                    ItemEventArg ef = new ItemEventArg();
                    ef.Action = ActionInv.setUnit;
                    ef.Row_ID = Row_ID;
                    ef.state = State;
                    ef.ItemData = ItemData;
                    ef.Type = u;
                    switch (frm.vSize_)
                    {
                        case 0:
                            ef.Price = (double)ItemData.UntPri1;
                            break;
                        case 1:
                            ef.Price = (double)ItemData.UntPri2;
                            break;
                        case 2:
                            ef.Price = (double)ItemData.UntPri3;
                            break;
                        case 3:
                            ef.Price = (double)ItemData.UntPri4;
                            break;
                        case 4:
                            ef.Price = (double)ItemData.UntPri5;
                            break;
                    }
                    //   ef.Price = (double)((KeyValuePair<T_Unit, double>)ItemPriceUnits[cmbUnit.SelectedIndex]).Value;

                    ItemTypeChanged?.Invoke(this, ef);

                    TxtPrice.ValueChanged -= TxtPrice_ValueChanged;
                    TxtPrice.Value = ef.Price;
                    TxtPrice.ValueChanged += TxtPrice_ValueChanged;
                    if (TOTCal_ReadY != null) TOTCal_ReadY(this, null);
                }
            }


        }
        string text;
        private void CheckValue_Paint(object sender, PaintEventArgs e)
        {
            //   string measureString = text ;
            //   Font stringFont = CheckValue.Font;
            //   SizeF stringSize = new SizeF();
            //   float w = tableLayoutPanel1.ColumnStyles[0].Width;
            //  stringSize = e.Graphics.MeasureString(measureString, stringFont);


            //   e.Graphics.DrawRectangle(new Pen(Color.Red, 1), 0.0F, 0.0F, stringSize.Width, stringSize.Height);

            ////   StringFormat f = new StringFormat(StringFormatFlags.DirectionRightToLeft);
            //   e.Graphics.DrawString(measureString, stringFont, Brushes.Black, new PointF(0, 0) );


        }
#pragma warning disable CS0414 // The field 'spatialItems.fg' is assigned but its value is never used
        int fg = 0;
#pragma warning restore CS0414 // The field 'spatialItems.fg' is assigned but its value is never used
        private void TxtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            fg = 1;
        }

        private void TxtPrice_Validated(object sender, EventArgs e)
        {
            fg = 0;
            TxtPrice_ValueChanged(null, null);
        }

        private void spatialItems_Load(object sender, EventArgs e)
        {

        }
    }
    public partial class ItemEventArg : System.EventArgs
    {


        private double price;
        public T_Unit Type;
        public T_Item ItemData;
        public CheckState state;
        public ActionInv Action;
        public int Row_ID;
        public int CPanel_ID;
        internal string item_No;

        public double Price
        {
            get
            {

                return price;
            }
            set
            {
                price = value;
            }
        }
    }
}

