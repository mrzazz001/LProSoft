   

namespace InvAcc.Forms
{
partial class FrmNewDB
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
    
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmNewDB));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();

            components = new System.ComponentModel.Container();

            label3 = new DevComponents.DotNetBar.LabelX();
            buttonX_Close = new DevComponents.DotNetBar.ButtonX();
            ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            panel1 = new System.Windows.Forms.Panel();
            textBox_DataBaseNm = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            buttonX_OK = new DevComponents.DotNetBar.ButtonX();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();

            ribbonBar1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            label3.BackColor = System.Drawing.Color.SteelBlue;
            label3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            resources.ApplyResources(label3, "label3");
            label3.ForeColor = System.Drawing.Color.White;
            label3.Name = "label3";
            label3.TextAlignment = System.Drawing.StringAlignment.Center;
            buttonX_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            buttonX_Close.Checked = true;
            buttonX_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(buttonX_Close, "buttonX_Close");
            buttonX_Close.Name = "buttonX_Close";
            buttonX_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            buttonX_Close.Symbol = "\uf011";
            buttonX_Close.TextColor = System.Drawing.Color.SteelBlue;
            buttonX_Close.Click += new System.EventHandler(buttonX_Close_Click);
            ribbonBar1.AutoOverflowEnabled = true;
            ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.ContainerControlProcessDialogKey = true;
            ribbonBar1.Controls.Add(panel1);
            resources.ApplyResources(ribbonBar1, "ribbonBar1");
            ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            ribbonBar1.Name = "ribbonBar1";
            ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.FromArgb(227, 239, 255);
            ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(101, 147, 207);
            ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            panel1.BackColor = System.Drawing.Color.Transparent;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(textBox_DataBaseNm);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(buttonX_Close);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(buttonX_OK);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            textBox_DataBaseNm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(textBox_DataBaseNm, "textBox_DataBaseNm");
            textBox_DataBaseNm.ForeColor = System.Drawing.Color.Maroon;
            textBox_DataBaseNm.Name = "textBox_DataBaseNm";
            textBox_DataBaseNm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox_DataBaseNm_KeyPress);
            textBox_DataBaseNm.Enter += new System.EventHandler(textBox_DataBaseNm_Enter);
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.ForeColor = System.Drawing.Color.SteelBlue;
            label1.Name = "label1";
            buttonX_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            buttonX_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            resources.ApplyResources(buttonX_OK, "buttonX_OK");
            buttonX_OK.Name = "buttonX_OK";
            buttonX_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            buttonX_OK.Symbol = "\uf00c";
            buttonX_OK.TextColor = System.Drawing.Color.White;
            buttonX_OK.Click += new System.EventHandler(buttonX_OK_Click);
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            base.ControlBox = false;
            base.Controls.Add(ribbonBar1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.Name = "FrmNewDB";
            base.Load += new System.EventHandler(FrmNewDB_Load);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmNewDB_KeyDown);
            ribbonBar1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }//###########&&&&&&&&&&

}
}
