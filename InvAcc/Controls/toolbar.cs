using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
namespace InvAcc
{
    public partial class toolbar : UserControl
    {
        public toolbar()
        {
            InitializeComponent();//

        }

        private void Change_Position(object sender, EventArgs e)
        {
            lbl_DisplayRecord.Text = "السجل " + (binding.Position + 1) + " من " + binding.Count;
        }


        private BindingSource binding;
        public BindingSource _binding
        {
            set
            {
                if (value != null)
                {
                    binding = value;
                    binding.PositionChanged += Change_Position;
                }
            }
            get { return binding; }
        }

        internal void showandselect()
        {
            BTN_NEW.Enabled = false;
            BTN_DELETE.Enabled = false;
            BTN_SAVE.Text = "اختيار";

            BTN_SAVE.Dock = DockStyle.Fill;
            flageselection = 1;
            panelControl2.Visible = false
                ;
            panelControl3.Visible = false;
            panelControl1.Visible = false;
            panelControl4.Visible = false;

            panel1.BringToFront();
            panel1.Dock = DockStyle.Fill;
            panel1.Controls.Add(BTN_SAVE);
            BTN_SAVE.ForeColor = Color.DarkGray;


        }
        public static int flageselection = 0;
        public BindingSource pro_classbin;

        public int cls = 0, faci = 0, mang = 0, own = 0, spe = 0, ed = 0, req = 0, min = 0;
        internal void disfollowing()
        {
            BTN_DELETE.Enabled = false;
            BTN_NEW.Enabled = false;

        }

        public BindingSource pro_requbin;
        //  public Plancreator1TableAdapters.tbl_pro_requirementTableAdapter pro_reqadapter=new Plancreator1TableAdapters.tbl_pro_requirementTableAdapter();
        List<int> mainList = new List<int>();
        List<int> detailedList = new List<int>();
        internal void Init(int f)
        {
            if (f == 0)
            {
                BTN_DELETE.Enabled = false;
                BTN_FIRST.Enabled = false;
                BTN_LAST.Enabled = false;
                BTN_PREV.Enabled = false;
                BTN_NEXT.Enabled = false;
            }
            else
            {
                BTN_DELETE.Enabled = true;
                BTN_FIRST.Enabled = true;
                BTN_LAST.Enabled = true;
                BTN_PREV.Enabled = true;
                BTN_NEXT.Enabled = true;
            }
        }

        public BindingSource pro_training;
        public BindingSource programbinding;
        private void panelControl3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void BTN_NEXT_Click(object sender, EventArgs e)
        {
            binding.MoveNext();
            //lbl_DisplayRecord.Text = "السجل " + ( binding.Position+ 1) + " من " + binding.Count;
        }

        private void BTN_LAST_Click(object sender, EventArgs e)
        {
            binding.MoveLast();

        }
        public void setpit()
        {
            lbl_DisplayRecord.Text = "السجل " + (binding.Position + 1) + " من " + binding.Count; ;
        }
        private void BTN_SAVE_Click(object sender, EventArgs e)
        {


        }

        private void BTN_PREV_Click(object sender, EventArgs e)
        {
            binding.MovePrevious();
            //  lbl_DisplayRecord.Text = "السجل " + (binding.Position + 1) + " من " + binding.Count;
        }

        private void BTN_FIRST_Click(object sender, EventArgs e)
        {
            binding.MoveFirst();
            //    lbl_DisplayRecord.Text = "السجل " + (binding.Position + 1) + " من " + binding.Count;
        }

        internal string getindex()
        {
            return binding.Position.ToString();
        }

        private void BTN_NEW_Click(object sender, EventArgs e)
        {

        }

        private void BTN_DELETE_Click(object sender, EventArgs e)
        {

        }

        private void BTN_NEW_Click_1(object sender, EventArgs e)
        {
            binding.AddNew();



        }
        public static byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new System.IO.MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
        List<int> tarjectdel = new List<int>();
        List<int> maintarjectlist = new List<int>();
        private void BTN_DELETE_Click_1(object sender, EventArgs e)
        {
            binding.RemoveCurrent();
            Change_Position(null, null);

        }

        private void BTN_SAVE_Click_1(object sender, EventArgs e)
        {
            if (flageselection == 1)
            {
                slectmessage();



            }
            else

            if (Save_Data != null)
            {
                Save_Data(null, null);
            }

        }

        private void slectmessage()
        {

            if (Select_Data != null)
            {
                Select_Data(null, null);
            }
        }




        private void panelControl3_Paint_1(object sender, PaintEventArgs e)
        {

        }

#pragma warning disable CS0649 // Field 'toolbar.detailedflag' is never assigned to, and will always have its default value 0
        internal int detailedflag;
#pragma warning restore CS0649 // Field 'toolbar.detailedflag' is never assigned to, and will always have its default value 0
        // internal tbl_plantarjectsTableAdapter detailedadapter;

        public BindingSource delbinding { get; internal set; }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //        public tbl_programsTableAdapter deladapter { get; internal set; }

        private void toolbar_Load(object sender, EventArgs e)
        {
            if (flageselection == 1)
            {

            }
        }

        private void lbl_DisplayRecord_Click(object sender, EventArgs e)
        {

        }

        private void panelControl4_Paint(object sender, PaintEventArgs e)
        {

        }
        public delegate void customMessageHandler(System.Object sender,
                                     ItemEventArg e);
        public event customMessageHandler Save_Data;
#pragma warning disable CS0067 // The event 'toolbar.Delete_Data' is never used
        public event customMessageHandler Delete_Data;
#pragma warning restore CS0067 // The event 'toolbar.Delete_Data' is never used
        public event customMessageHandler Select_Data;

    }
    public partial class ItemEventArg : System.EventArgs
    {


        private double price;

        public CheckState state;
        public int Row_ID;
        public int CPanel_ID;
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
