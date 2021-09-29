using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace InvAcc.Forms
{
    public partial class FrmCarChecking : Form
    {
        class pinlocation
        {
            public int picno = -100;
            public Point location;
            public int index;
            public PictureBox pin;

        }
        Stock_DataDataContext db;
        List<Image> image;
        List<T_Pine> InvPins;
        string invID = string.Empty;

        public FrmCarChecking(string invid)
        {
            InitializeComponent();
            invID = invid;


            db = new Stock_DataDataContext(VarGeneral.BranchCS);
            InvPins = db.StockGetInvPines(invid);
            foreach (T_Pine k in InvPins)
            {
                Bitmap c = InvAcc.Properties.Resources.red_thumbtack_round_metal_pushpin_attach_memo_pinned_documents_176411_1055;
                c.MakeTransparent(c.GetPixel(0, 0));

                var picture = new PictureBox
                {
                    Size = new Size(50, 50),
                    Location = new Point(k.X.GetValueOrDefault(), k.Y.GetValueOrDefault()),
                    Image = c,
                    SizeMode = PictureBoxSizeMode.StretchImage
                    ,
                    BackColor = Color.Transparent

                };
                pinlocation p = new pinlocation();
                p.picno = (int)k.Pic_no;
                p.location = new Point(k.X.GetValueOrDefault(), k.Y.GetValueOrDefault());
                p.index = list.Count;

                picture.ContextMenuStrip = contextMenuStrip1;
                picture.Tag = list.Count - 1;
                p.pin = picture;
                list.Add(p);
            }

            pictureBox1.BackColor = Color.Transparent;
            image = new List<Image>();
            image.Add(InvAcc.Properties.Resources._1);
            image.Add(InvAcc.Properties.Resources._2);
            image.Add(InvAcc.Properties.Resources._3);
            image.Add(InvAcc.Properties.Resources._4);
            image.Add(InvAcc.Properties.Resources._5);
        }
        List<pinlocation> list = new List<pinlocation>();
        public int currintimage = 0;
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        int X, Y;

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;
            var contextMenu = menuItem.GetCurrentParent() as ContextMenuStrip;
            var pictureBox = contextMenu.SourceControl;
            PicPanel.Controls.Remove(pictureBox);
            int i = int.Parse(pictureBox.Tag.ToString());
            list.RemoveAt(i);
            Refresh();
        }

        private void FrmCarChecking_Load(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = image[currintimage];
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            PicPanel = splitContainer1.Panel2;
            setpines();
            TopMost = true;
            Show();
        }

        Bitmap pb;
        void setpines()
        {
            pb = new Bitmap(image[currintimage], PicPanel.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(pb);

            var q = (from i in list
                     where i.picno == currintimage
                     select i);
            foreach (pinlocation r in q)
            {
                PicPanel.Controls.Add(r.pin);
                r.pin.BringToFront();
                g.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle rect = new Rectangle(r.location.X, r.location.Y, 50, 50);
                g.FillEllipse(Brushes.LightGreen, rect);
                using (Pen thick_pen = new Pen(Color.Blue, 5))
                {
                    g.DrawEllipse(thick_pen, rect);
                }

            }
            Refresh();

            Refresh();
        }
        Panel PicPanel;

        void removpin(int isa)
        {
            var q = (from i in list
                     where i.picno == isa
                     select i);
            foreach (pinlocation r in q)
            {

                PicPanel.Controls.Remove(r.pin);


            }
            Refresh();
        }

        private void Button_Privieos_Click(object sender, EventArgs e)
        {
            removpin(currintimage);
            if (currintimage == 0)
                currintimage = 4;
            else
                currintimage--;
            currintimage = (currintimage % 5);
            pictureBox1.BackgroundImage = image[currintimage];
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            Refresh();
            setpines();
            //pictureBox1.BackgroundImage = GetImag2e();
            Refresh();
        }

        private void Button_Next_Click(object sender, EventArgs e)
        {
            removpin(currintimage);
            currintimage++;
            currintimage = (currintimage % 5);
            pictureBox1.BackgroundImage = image[currintimage];
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            Refresh();
            setpines();


        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            int xCoordinate = X;
            int yCoordinate = Y;

            Bitmap c = InvAcc.Properties.Resources.red_thumbtack_round_metal_pushpin_attach_memo_pinned_documents_176411_1055;
            c.MakeTransparent(c.GetPixel(0, 0));

            var picture = new PictureBox
            {
                Size = new Size(50, 50),
                Location = new Point(X, Y),
                Image = c,
                SizeMode = PictureBoxSizeMode.StretchImage
                ,
                BackColor = Color.Transparent

            };
            pinlocation p = new pinlocation();
            p.picno = currintimage;
            p.location = new Point(X, Y);
            p.index = list.Count;

            picture.ContextMenuStrip = contextMenuStrip1;
            picture.Tag = list.Count - 1;
            p.pin = picture;
            list.Add(p);
            PicPanel.Controls.Add(picture);
            picture.BringToFront();
        }
        void ReverseControls()
        {
            var controls = PicPanel.Controls.Cast<Control>().Reverse().ToArray();
            PicPanel.Controls.Clear();
            PicPanel.Controls.AddRange(controls);
        }
        Image rev()
        {
            //ReverseControls();

            Bitmap bmp = new Bitmap(PicPanel.Width, PicPanel.Height);
            PicPanel.DrawToBitmap(bmp, PicPanel.ClientRectangle);
            Graphics graph = null;
            try
            {
                bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                graph = Graphics.FromImage(bmp);
                graph.CopyFromScreen(0, 0, 0, 0, bmp.Size);

            }
            finally
            {
                graph.Dispose();
            }


            //ReverseControls();
            return bmp;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<T_Pine> dd = db.StockGetInvPines(invID);
            foreach (T_Pine f in dd)
            {
                db.T_Pines.DeleteOnSubmit(f);

            }
            db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
            List<int> picne = new List<int>();
            foreach (pinlocation k in list)
            {
                if (!picne.Contains(k.picno))
                    picne.Add(k.picno);
                T_Pine ps = new T_Pine();
                ps.Inv_ID = invID;
                ps.Pic_no = k.picno;
                ps.X = k.location.X;
                ps.Y = k.location.Y;
                try
                {
                    db.T_Pines.InsertOnSubmit(ps);
                }
                catch (Exception ex)
                {


                }
            }


            db.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
            T_CarCheckPIC p = new T_CarCheckPIC();
            List<T_CarCheckPIC> fc = db.StockGetInvPIC(invID);
            if (fc.Count > 0)
            {
                p = fc[0];
                db.T_CarCheckPICs.DeleteOnSubmit(p);
                db.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict); ;
            }
            T_CarCheckPIC n = new T_CarCheckPIC();
            n.INVHED_ID = invID;

            foreach (int a in picne)
            {
                removpin(currintimage);
                currintimage = a;
                setpines();




                ;


                if (a == 0)
                {
                    n.Pic_1 = Utilites.ToBinary(pb);
                }

                else
                if (a == 1)
                {
                    n.Pic_2 = Utilites.ToBinary(pb);
                }
                else if (a == 2) n.Pic_3 = Utilites.ToBinary(pb);
                else if (a == 3) n.Pic_4 = Utilites.ToBinary(pb);
                else if (a == 4) n.Pic_5 = Utilites.ToBinary(pb);
                db.T_CarCheckPICs.InsertOnSubmit(n);

            }
            db.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);

            Close();


        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            X = e.X;
            Y = e.Y;

        }
    }
}
