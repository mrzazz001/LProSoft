using DevComponents.DotNetBar.Controls;
using System;
using System.ComponentModel;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmImports : Form
    {
        private IContainer components = null;
        private ProgressBarX progressBarX_import;
        private Timer timer1;
        public FrmImports()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBarX_import.Increment(1);
            if (progressBarX_import.Value == 100)
            {
                timer1.Stop();
            }
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
            components = new System.ComponentModel.Container();
            progressBarX_import = new DevComponents.DotNetBar.Controls.ProgressBarX();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            progressBarX_import.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            progressBarX_import.Location = new System.Drawing.Point(14, 6);
            progressBarX_import.Name = "progressBarX_import";
            progressBarX_import.Size = new System.Drawing.Size(449, 23);
            progressBarX_import.TabIndex = 0;
            progressBarX_import.Text = "progressBarX1";
            timer1.Enabled = true;
            timer1.Interval = 1;
            timer1.Tick += new System.EventHandler(timer1_Tick);
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.MenuHighlight;
            base.ClientSize = new System.Drawing.Size(472, 36);
            base.ControlBox = false;
            base.Controls.Add(progressBarX_import);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.Name = "FrmImports";
            base.ShowIcon = false;
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ResumeLayout(false);
        }
    }
}
