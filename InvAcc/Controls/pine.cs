using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace InvAcc.Controls
{
    public partial class pine : UserControl
    {
        public pine()
        {
            InitializeComponent();//
        }

        private void pine_Load(object sender, EventArgs e)
        {
            GraphicsPath myPath = new GraphicsPath();

            myPath.AddEllipse(new Rectangle(1, 1, 20, 20));

            Region myRegion = new Region(myPath);

            this.Region = myRegion;
        }

        private void pine_Paint(object sender, PaintEventArgs e)
        {


        }
    }
}
