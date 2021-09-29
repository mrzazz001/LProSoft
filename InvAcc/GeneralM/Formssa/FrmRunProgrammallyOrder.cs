using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmRunProgrammallyOrder : Form
    {
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private IContainer components = null;
        private void netResize1_AfterControlResize(object sender, Softgroup.NetResize.AfterControlResizeEventArgs e)
        {
            if (e.Control.GetType() == typeof(Label))
            {
                Label c = (e.Control as Label); if ((c.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))))) && (c.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))))) && (c.BackColor != System.Drawing.Color.SteelBlue))
                    c.BackColor = Color.Transparent; Size cc = c.PreferredSize;
                c.AutoSize = false;
                c.Size = cc;

                //  e.Control.Font= new System.Drawing.Font("Tahoma",(float) (c-0.5));

            }
        }


        private void FrmInvSale_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;
        }

        private void FrmInvSale_SizeChanged(object sender, EventArgs e)
        {
            netResize1.Refresh();
        }

        public Softgroup.NetResize.NetResize netResize1;

        private TextBoxX txtOrder;
        private ButtonX buttonX_Close;
        private ButtonX buttonX_Ok;
        private Stock_DataDataContext db
        {
            get
            {
                if (dbInstance == null)
                {
                    dbInstance = new Stock_DataDataContext(VarGeneral.BranchCS);
                }
                return dbInstance;
            }
        }
        private Rate_DataDataContext dbc
        {
            get
            {
                if (dbInstanceRate == null)
                {
                    dbInstanceRate = new Rate_DataDataContext(VarGeneral.BranchRt);
                }
                return dbInstanceRate;
            }
        }
        public FrmRunProgrammallyOrder()
        {
            InitializeComponent();
        }
        private void buttonX_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void buttonX_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("هل أنت متاكد من اتمام هذه العملية ?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && !string.IsNullOrEmpty(txtOrder.Text))
                {
                    if (MessageBox.Show("هل تريد تنفيذ الأمر على بيانات العمل ?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string[] lins = txtOrder.Text.Split(Environment.NewLine.ToCharArray());
                        try
                        {
                            if (lins[0] == "CommandTimeout")
                            {
                                db.CommandTimeout = int.Parse(lins[1]);
                                string sa = "";
                                for (int i = 2; i < lins.Length; i++)
                                    sa += lins[i] + Environment.NewLine;
                                txtOrder.Text = sa;
                            }
                        }
                        catch { }
                        db.ExecuteCommand(txtOrder.Text);
                    }
                    else
                    {
                        string[] lins = txtOrder.Text.Split(Environment.NewLine.ToCharArray());
                        try
                        {
                            if (lins[0] == "CommandTimeout")
                            {
                                dbc.CommandTimeout = int.Parse(lins[1]);
                                string sa = "";
                                for (int i = 2; i < lins.Length; i++)
                                    sa += lins[i] + Environment.NewLine;
                                txtOrder.Text = sa;
                            }
                        }
                        catch { }
                        dbc.ExecuteCommand(txtOrder.Text);
                    }
                    MessageBox.Show("تمت العملية بنجاح");
                    Close();
                }
            }
            catch
            {
                MessageBox.Show("لم يتم العملية بنجاح");
                Close();
            }
        }
        private void FrmRunProgrammallyOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void txtOrder_ButtonCustomClick(object sender, EventArgs e)
        {
            txtOrder.Text = "";
        }
        private void FrmRunProgrammallyOrder_Load(object sender, EventArgs e)
        {
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmRunProgrammallyOrder));
            components = new System.ComponentModel.Container();

            txtOrder = new DevComponents.DotNetBar.Controls.TextBoxX();
            buttonX_Close = new DevComponents.DotNetBar.ButtonX();
            buttonX_Ok = new DevComponents.DotNetBar.ButtonX();
            SuspendLayout();
            txtOrder.BackColor = System.Drawing.Color.White;
            txtOrder.Border.Class = "TextBoxBorder";
            txtOrder.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            txtOrder.ButtonCustom.Image = (System.Drawing.Image)resources.GetObject("txtRemark.ButtonCustom.Image");
            txtOrder.ButtonCustom.Visible = true;
            txtOrder.Dock = System.Windows.Forms.DockStyle.Top;
            txtOrder.ForeColor = System.Drawing.Color.Black;
            txtOrder.Location = new System.Drawing.Point(0, 0);
            txtOrder.Multiline = true;
            txtOrder.Name = "txtOrder";
            txtOrder.Size = new System.Drawing.Size(675, 251);
            txtOrder.TabIndex = 481;
            txtOrder.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            txtOrder.WatermarkText = "إدخل الأمر البرمجي";
            txtOrder.ButtonCustomClick += new System.EventHandler(txtOrder_ButtonCustomClick);
            buttonX_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            buttonX_Close.Checked = true;
            buttonX_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            buttonX_Close.Dock = System.Windows.Forms.DockStyle.Left;
            buttonX_Close.Font = new System.Drawing.Font("Tahoma", 8f, System.Drawing.FontStyle.Bold);
            buttonX_Close.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            buttonX_Close.Location = new System.Drawing.Point(0, 251);
            buttonX_Close.Name = "buttonX_Close";
            buttonX_Close.Size = new System.Drawing.Size(335, 63);
            buttonX_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            buttonX_Close.Symbol = "\uf011";
            buttonX_Close.TabIndex = 483;
            buttonX_Close.Text = "إغلاق";
            buttonX_Close.TextColor = System.Drawing.Color.Black;
            buttonX_Close.Click += new System.EventHandler(buttonX_Close_Click);
            buttonX_Ok.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            buttonX_Ok.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            buttonX_Ok.Dock = System.Windows.Forms.DockStyle.Right;
            buttonX_Ok.Font = new System.Drawing.Font("Tahoma", 8f, System.Drawing.FontStyle.Bold);
            buttonX_Ok.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            buttonX_Ok.Location = new System.Drawing.Point(340, 251);
            buttonX_Ok.Name = "buttonX_Ok";
            buttonX_Ok.Size = new System.Drawing.Size(335, 63);
            buttonX_Ok.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            buttonX_Ok.Symbol = "\uf00c";
            buttonX_Ok.TabIndex = 482;
            buttonX_Ok.Text = "موافــــق";
            buttonX_Ok.TextColor = System.Drawing.Color.White;
            buttonX_Ok.Click += new System.EventHandler(buttonX_Ok_Click);
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            base.ClientSize = new System.Drawing.Size(675, 314);
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();

            base.ControlBox = false;
            base.Controls.Add(buttonX_Close);
            base.Controls.Add(buttonX_Ok);
            base.Controls.Add(txtOrder);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FrmRunProgrammallyOrder";
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            base.ShowIcon = false;
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "تنفيذ كود برمجي خاص";
            base.Load += new System.EventHandler(FrmRunProgrammallyOrder_Load);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmRunProgrammallyOrder_KeyDown);
            ResumeLayout(false);
        }
    }
}
