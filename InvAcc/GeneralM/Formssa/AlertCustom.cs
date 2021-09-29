using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using System;
using System.ComponentModel;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public class AlertCustom : Balloon
    {
        private ReflectionImage reflectionImage1;
        private Bar bar1;
        private ButtonItem buttonItem1;
        private ButtonItem buttonItem2;
        private ButtonItem buttonItem3;
        private LabelX labelX1;
        public LabelX labelX2;
        private Container components = null;
        public AlertCustom()
        {
            InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.AlertCustom));
            reflectionImage1 = new DevComponents.DotNetBar.Controls.ReflectionImage();
            bar1 = new DevComponents.DotNetBar.Bar();
            buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            labelX1 = new DevComponents.DotNetBar.LabelX();
            labelX2 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)bar1).BeginInit();
            SuspendLayout();
            reflectionImage1.BackColor = System.Drawing.Color.Transparent;
            reflectionImage1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            reflectionImage1.Image = (System.Drawing.Image)resources.GetObject("reflectionImage1.Image");
            reflectionImage1.Location = new System.Drawing.Point(8, 8);
            reflectionImage1.Name = "reflectionImage1";
            reflectionImage1.Size = new System.Drawing.Size(64, 100);
            reflectionImage1.TabIndex = 0;
            bar1.BackColor = System.Drawing.Color.Transparent;
            bar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            bar1.Font = new System.Drawing.Font("Segoe UI", 9f);
            bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[3]
            {
                buttonItem1,
                buttonItem2,
                buttonItem3
            });
            bar1.Location = new System.Drawing.Point(0, 109);
            bar1.Name = "bar1";
            bar1.Size = new System.Drawing.Size(280, 27);
            bar1.Stretch = true;
            bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            bar1.TabIndex = 1;
            bar1.TabStop = false;
            bar1.Text = "bar1";
            bar1.Click += new System.EventHandler(bar1_Click);
            buttonItem1.Image = (System.Drawing.Image)resources.GetObject("buttonItem1.Image");
            buttonItem1.Name = "buttonItem1";
            buttonItem1.Text = "buttonItem1";
            buttonItem1.Visible = false;
            buttonItem2.Image = (System.Drawing.Image)resources.GetObject("buttonItem2.Image");
            buttonItem2.Name = "buttonItem2";
            buttonItem2.Text = "buttonItem2";
            buttonItem2.Visible = false;
            buttonItem3.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            buttonItem3.Name = "buttonItem3";
            buttonItem3.Text = "عرض الطلبات ...";
            buttonItem3.Visible = false;
            buttonItem3.Click += new System.EventHandler(buttonItem3_Click);
            labelX1.BackColor = System.Drawing.Color.Transparent;
            labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX1.Location = new System.Drawing.Point(88, 38);
            labelX1.Name = "labelX1";
            labelX1.Size = new System.Drawing.Size(184, 16);
            labelX1.TabIndex = 2;
            labelX1.Text = "<b>تنبيـــــه</b>";
            labelX1.Click += new System.EventHandler(labelX1_Click);
            labelX2.BackColor = System.Drawing.Color.Transparent;
            labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX2.Location = new System.Drawing.Point(88, 74);
            labelX2.Name = "labelX2";
            labelX2.Size = new System.Drawing.Size(184, 27);
            labelX2.TabIndex = 3;
            labelX2.Text = "لديك طلبات محلية جديدة  ...";
            labelX2.TextLineAlignment = System.Drawing.StringAlignment.Near;
            labelX2.WordWrap = true;
            labelX2.Click += new System.EventHandler(labelX2_Click);
            AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            base.BackColor2 = System.Drawing.Color.FromArgb(201, 217, 239);
            base.BorderColor = System.Drawing.Color.FromArgb(101, 147, 207);
            base.ClientSize = new System.Drawing.Size(280, 136);
            base.Controls.Add(labelX2);
            base.Controls.Add(labelX1);
            base.Controls.Add(bar1);
            base.Controls.Add(reflectionImage1);
            ForeColor = System.Drawing.Color.FromArgb(76, 76, 76);
            base.Location = new System.Drawing.Point(0, 0);
            base.Name = "AlertCustom";
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            RightToLeftLayout = true;
            base.Style = DevComponents.DotNetBar.eBallonStyle.Office2007Alert;
            base.Click += new System.EventHandler(AlertCustom_Click);
            ((System.ComponentModel.ISupportInitialize)bar1).EndInit();
            ResumeLayout(false);
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }
        private void AlertCustom_Click(object sender, EventArgs e)
        {
            if (!base.ShowCloseButton)
            {
                Close();
            }
        }
        private void buttonItem3_Click(object sender, EventArgs e)
        {
            if (!base.ShowCloseButton)
            {
                Close();
            }
        }
        private void labelX2_Click(object sender, EventArgs e)
        {
            AlertCustom_Click(sender, e);
        }
        private void labelX1_Click(object sender, EventArgs e)
        {
            AlertCustom_Click(sender, e);
        }
        private void bar1_Click(object sender, EventArgs e)
        {
            AlertCustom_Click(sender, e);
        }
    }
}
