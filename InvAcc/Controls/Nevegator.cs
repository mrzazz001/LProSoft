using System;
using System.Windows.Forms;
namespace InvAcc.Controls
{
    public partial class Nevegator : UserControl
    {
        public Nevegator()
        {
            InitializeComponent();
        }

        private void Nevegator_Load(object sender, EventArgs e)
        {

        }
        void setbuttonPropritis()
        {

        }
        private void buttonX1_Click(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {

        }

        private void Button_Next_Click(object sender, EventArgs e)
        {
            if (Next_Click != null)
            {
                Next_Click(null, null);
            }

        }

        private void superTabControl_Main1_SelectedTabChanged(object sender, DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs e)
        {

        }
        public delegate void customMessageHandler(System.Object sender,
                                   ItemEventArg e);
        public event customMessageHandler Next_Click;
#pragma warning disable CS0067 // The event 'Nevegator.First_Click' is never used
        public event customMessageHandler First_Click;
#pragma warning restore CS0067 // The event 'Nevegator.First_Click' is never used
#pragma warning disable CS0067 // The event 'Nevegator.Previsous_Click' is never used
        public event customMessageHandler Previsous_Click;
#pragma warning restore CS0067 // The event 'Nevegator.Previsous_Click' is never used
#pragma warning disable CS0067 // The event 'Nevegator.Last_Click' is never used
        public event customMessageHandler Last_Click;
#pragma warning restore CS0067 // The event 'Nevegator.Last_Click' is never used
#pragma warning disable CS0067 // The event 'Nevegator.New_Click' is never used
        public event customMessageHandler New_Click;
#pragma warning restore CS0067 // The event 'Nevegator.New_Click' is never used
#pragma warning disable CS0067 // The event 'Nevegator.Save_Click' is never used
        public event customMessageHandler Save_Click;
#pragma warning restore CS0067 // The event 'Nevegator.Save_Click' is never used
#pragma warning disable CS0067 // The event 'toolbar.Delete_Data' is never used
        public event customMessageHandler Close_Click;
#pragma warning restore CS0067 // The event 'toolbar.Delete_Data' is never used
#pragma warning disable CS0067 // The event 'Nevegator.Select_Data' is never used
        public event customMessageHandler Select_Data;
#pragma warning restore CS0067 // The event 'Nevegator.Select_Data' is never used

    }
    public partial class ItemEventArgw : System.EventArgs
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
