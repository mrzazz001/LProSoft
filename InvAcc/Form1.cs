using InvAcc.Forms;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace InvAcc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();//this.Load += langloads;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bubbleButton_BarcodSetting_Click(object sender, DevComponents.DotNetBar.ClickEventArgs e)
        {
            var q = (from k in this.MdiChildren
                     where k.Name == "FMBarCodePrintSetup"
                     select k).ToList();

            if (this.MdiChildren.Count() == 0)
            {
                FMBarCodePrintSetup fs = new FMBarCodePrintSetup();
                // fs.MdiParent = this;
                fs.TopLevel = false;
                fs.FormClosed += Form_Closed;
                fs.MdiParent = this;
                this.Width = fs.Size.Width + 20;
                fs.FormBorderStyle = FormBorderStyle.None;
                this.Height = fs.Size.Height + bubbleBar_Items.Size.Height + 50;

                fs.Show();
            }
            else
            {
                int ks = 0;
                foreach (Form form in this.MdiChildren)
                {
                    if (form.Name == "FMBarCodePrintSetup")
                    {
                        form.TopLevel = false;
                        ks = 1;
                        //       form.Parent = this;
                        this.Width = form.Size.Width + 20;
                        form.FormBorderStyle = FormBorderStyle.None;
                        this.Height = form.Size.Height + bubbleBar_Items.Size.Height + 50;
                        form.Show();
                    }
                    else
                    {
                        form.Hide();
                        // MessageBox.Show("To open ChildForm2, must close " + form.Name);
                    }
                }
                if (ks == 0)
                {
                    FMBarCodePrintSetup fs = new FMBarCodePrintSetup();
                    // fs.MdiParent = this;
                    fs.TopLevel = false;
                    fs.FormClosed += Form_Closed;
                    fs.MdiParent = this;
                    this.Width = fs.Size.Width + 20;
                    fs.FormBorderStyle = FormBorderStyle.None;
                    this.Height = fs.Size.Height + bubbleBar_Items.Size.Height + 50;

                    fs.Show();
                }
            }

        }
#pragma warning disable CS0414 // The field 'Form1.opp' is assigned but its value is never used
        int opp = 0;
#pragma warning restore CS0414 // The field 'Form1.opp' is assigned but its value is never used
        private void bubbleButton_GaidSetting_Click(object sender, DevComponents.DotNetBar.ClickEventArgs e)
        {

            if (this.MdiChildren.Count() == 0)
            {
                FMSndPrintSetup fs = new FMSndPrintSetup();
                //fs.MdiParent = this;
                fs.TopLevel = false;
                fs.FormClosed += Form_Closed;
                fs.MdiParent = this;
                // fs.Parent = this;
                this.Width = fs.Size.Width + 20;
                fs.FormBorderStyle = FormBorderStyle.None;
                this.Height = fs.Size.Height + bubbleBar_Items.Size.Height + 50;

                fs.Show();
            }
            else
            {
                int k = 0;
                foreach (Form form in this.MdiChildren)
                {
                    if (form.Name == "FMSndPrintSetup")
                    {
                        form.TopLevel = false;
                        k = 1;
                        //      form.Parent = this;
                        this.Width = form.Size.Width + 20;
                        form.FormBorderStyle = FormBorderStyle.None;
                        this.Height = form.Size.Height + bubbleBar_Items.Size.Height + 50;
                        form.Show();
                    }
                    else
                    {
                        form.Hide();
                        // MessageBox.Show("To open ChildForm2, must close " + form.Name);
                    }

                }
                if (k == 0)
                {
                    FMSndPrintSetup fs = new FMSndPrintSetup();
                    //fs.MdiParent = this;
                    fs.TopLevel = false;
                    fs.MdiParent = this;
                    // fs.Parent = this;
                    this.Width = fs.Size.Width + 20;
                    fs.FormClosed += Form_Closed;
                    fs.FormBorderStyle = FormBorderStyle.None;
                    this.Height = fs.Size.Height + bubbleBar_Items.Size.Height + 50;

                    fs.Show();

                }
            }
        }
        void Form_Closed(object sender, FormClosedEventArgs e)
        {
            var q = (from k in this.MdiChildren

                     select k).ToArray();
            if (q.Length != 0)
            {
                Form fs = q[0];

                // fs.Parent = this;
                this.Width = fs.Size.Width + 20;
                fs.FormClosed += Form_Closed;
                fs.FormBorderStyle = FormBorderStyle.None;
                this.Height = fs.Size.Height + bubbleBar_Items.Size.Height + 50;

                fs.Show();

            }
        }

        private void bubbleButton_InvSetting_Click(object sender, DevComponents.DotNetBar.ClickEventArgs e)
        {
            var q = (from k in this.MdiChildren
                     where k.Name == "FMInvPrintSetup"
                     select k).ToList();

            if (this.MdiChildren.Count() == 0)
            {
                FMInvPrintSetup fs = new FMInvPrintSetup(0);
                //fs.MdiParent = this;
                fs.TopLevel = false;
                fs.FormClosed += Form_Closed;
                fs.MdiParent = this;
                // fs.Parent = this;
                this.Width = fs.Size.Width + 20;
                fs.FormBorderStyle = FormBorderStyle.None;
                this.Height = fs.Size.Height + bubbleBar_Items.Size.Height + 50;

                fs.Show();
            }
            else
            {
                int k = 0;
                foreach (Form form in this.MdiChildren)
                {
                    if (form.Name == "FMInvPrintSetup")
                    {
                        form.TopLevel = false;
                        k = 1;
                        //      form.Parent = this;
                        this.Width = form.Size.Width + 20;
                        form.FormBorderStyle = FormBorderStyle.None;
                        this.Height = form.Size.Height + bubbleBar_Items.Size.Height + 50;
                        form.Show();
                    }
                    else
                    {
                        form.Hide();
                        // MessageBox.Show("To open ChildForm2, must close " + form.Name);
                    }

                }
                if (k == 0)
                {
                    FMInvPrintSetup fs = new FMInvPrintSetup(0);
                    //fs.MdiParent = this;
                    fs.TopLevel = false;
                    fs.MdiParent = this;
                    // fs.Parent = this;
                    this.Width = fs.Size.Width + 20;
                    fs.FormClosed += Form_Closed;
                    fs.FormBorderStyle = FormBorderStyle.None;
                    this.Height = fs.Size.Height + bubbleBar_Items.Size.Height + 50;

                    fs.Show();

                }
            }

        }
    }
}
