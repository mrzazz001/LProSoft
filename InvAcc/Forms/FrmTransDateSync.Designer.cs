   

namespace InvAcc.Forms
{
partial class FrmTransDateSync
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmTransDateSync));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();

            components = new System.ComponentModel.Container();

            ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            panel1 = new System.Windows.Forms.Panel();
            ButOk = new DevComponents.DotNetBar.ButtonX();
            label3 = new DevComponents.DotNetBar.LabelX();
            buttonX_Close = new DevComponents.DotNetBar.ButtonX();
            dateTimeInput_DateG = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_DateH = new System.Windows.Forms.MaskedTextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);  this.netResize1.LabelsAutoEllipse = false;
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();

            ribbonBar1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            ribbonBar1.AccessibleDescription = null;
            ribbonBar1.AccessibleName = null;
            resources.ApplyResources(ribbonBar1, "ribbonBar1");
            ribbonBar1.AutoOverflowEnabled = true;
            ribbonBar1.BackgroundImage = null;
            ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.ContainerControlProcessDialogKey = true;
            ribbonBar1.Controls.Add(panel1);
            ribbonBar1.Font = null;
          // ribbonBar1.Tag= "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            ribbonBar1.Name = "ribbonBar1";
            ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.FromArgb(227, 239, 255);
            ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(101, 147, 207);
            ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.ItemClick += new System.EventHandler(ribbonBar1_ItemClick);
            panel1.AccessibleDescription = null;
            panel1.AccessibleName = null;
            resources.ApplyResources(panel1, "panel1");
            panel1.BackColor = System.Drawing.Color.Transparent;
            panel1.BackgroundImage = null;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(ButOk);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(buttonX_Close);
            panel1.Controls.Add(dateTimeInput_DateG);
            panel1.Controls.Add(dateTimeInput_DateH);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Font = null;
            panel1.Name = "panel1";
            ButOk.AccessibleDescription = null;
            ButOk.AccessibleName = null;
            ButOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(ButOk, "ButOk");
            ButOk.BackgroundImage = null;
            ButOk.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            ButOk.CommandParameter = null;
            ButOk.Name = "ButOk";
            ButOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButOk.Symbol = "\uf00c";
            ButOk.SymbolSize = 16f;
            ButOk.TextColor = System.Drawing.Color.White;
            ButOk.Click += new System.EventHandler(ButOk_Click);
            label3.AccessibleDescription = null;
            label3.AccessibleName = null;
            resources.ApplyResources(label3, "label3");
            label3.BackColor = System.Drawing.Color.SteelBlue;
            label3.BackgroundImage = null;
            label3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            label3.CommandParameter = null;
            label3.ForeColor = System.Drawing.Color.White;
            label3.Name = "label3";
            label3.TextAlignment = System.Drawing.StringAlignment.Center;
            buttonX_Close.AccessibleDescription = null;
            buttonX_Close.AccessibleName = null;
            buttonX_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(buttonX_Close, "buttonX_Close");
            buttonX_Close.BackgroundImage = null;
            buttonX_Close.Checked = true;
            buttonX_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            buttonX_Close.CommandParameter = null;
            buttonX_Close.Name = "buttonX_Close";
            buttonX_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            buttonX_Close.Symbol = "\uf011";
            buttonX_Close.TextColor = System.Drawing.Color.Black;
            buttonX_Close.Click += new System.EventHandler(buttonX_Close_Click);
            dateTimeInput_DateG.AccessibleDescription = null;
            dateTimeInput_DateG.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_DateG, "dateTimeInput_DateG");
            dateTimeInput_DateG.BackColor = System.Drawing.Color.SteelBlue;
            dateTimeInput_DateG.BackgroundImage = null;
            dateTimeInput_DateG.ForeColor = System.Drawing.Color.White;
            dateTimeInput_DateG.Name = "dateTimeInput_DateG";
            dateTimeInput_DateG.Leave += new System.EventHandler(dateTimeInput_DateG_Leave);
            dateTimeInput_DateG.Click += new System.EventHandler(dateTimeInput_DateG_Click);
            dateTimeInput_DateH.AccessibleDescription = null;
            dateTimeInput_DateH.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_DateH, "dateTimeInput_DateH");
            dateTimeInput_DateH.BackColor = System.Drawing.Color.SteelBlue;
            dateTimeInput_DateH.BackgroundImage = null;
            dateTimeInput_DateH.ForeColor = System.Drawing.Color.White;
            dateTimeInput_DateH.Name = "dateTimeInput_DateH";
            dateTimeInput_DateH.Leave += new System.EventHandler(dateTimeInput_DateH_Leave);
            dateTimeInput_DateH.Click += new System.EventHandler(dateTimeInput_DateH_Click);
            label1.AccessibleDescription = null;
            label1.AccessibleName = null;
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.ForeColor = System.Drawing.Color.SteelBlue;
            label1.Name = "label1";
            label2.AccessibleDescription = null;
            label2.AccessibleName = null;
            resources.ApplyResources(label2, "label2");
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.ForeColor = System.Drawing.Color.SteelBlue;
            label2.Name = "label2";
            base.AccessibleDescription = null;
            base.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImage = null;
            base.ControlBox = false;
            base.Controls.Add(ribbonBar1);
            Font = null;
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.Icon = null;
            base.KeyPreview = true;
            base.Name = "FrmTransDateSync";
            base.ShowIcon = false;
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Frm_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(Frm_KeyDown);
            ribbonBar1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }//###########&&&&&&&&&&

}
}
