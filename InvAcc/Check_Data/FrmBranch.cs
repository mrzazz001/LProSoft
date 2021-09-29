// Decompiled with JetBrains decompiler
// Type: Check_Data.Forms.FrmBranch
// Assembly: Check_Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 36F786BA-8BF1-463D-BDEC-46FF9F01EBC1
// Assembly location: C:\Program Files (x86)\PROSOFT\InvAccc\Check_Data.dll
using DevComponents.DotNetBar;
using InvAcc.GeneralM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace Check_Data.Forms
{
    public partial class FrmBranch : Form
    {
        private List<string> AllDataBase = new List<string>();
        private IContainer components = (IContainer)null;
        private ListBox listBox_Branch;
        private ListBox listBox_Branch2;
        private Label label1;
        private Label label2;
        private ButtonX button_OK;
        public FrmBranch(List<string> value)
        {
            this.InitializeComponent();//this.Load += langloads;
            this.AllDataBase = value;
        }
        private void FrmBranch_Load(object sender, EventArgs e)
        {
            try
            {
                this.listBox_Branch.SelectedIndexChanged -= new EventHandler(this.listBox_Branch_SelectedIndexChanged);
                for (int index = 0; index < this.AllDataBase.Count; ++index)
                {
                    this.listBox_Branch.Items.Add((object)this.AllDataBase[index].ToString().Replace("DBPROSOFT_", ""));
                    this.listBox_Branch2.Items.Add((object)this.AllDataBase[index].ToString());
                }
                this.listBox_Branch.SelectedIndexChanged += new EventHandler(this.listBox_Branch_SelectedIndexChanged);
                this.listBox_Branch.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                VarGeneral.DebLog.writeLog("FrmBranch_Load:", ex, true);
                int num = (int)MessageBox.Show(ex.Message, Application.ProductName);
            }
        }
        private void listBox_Branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.listBox_Branch2.SelectedIndex = this.listBox_Branch.SelectedIndex;
                this.label1.Text = this.listBox_Branch.Text;
            }
            catch
            {
                this.listBox_Branch.SelectedIndex = -1;
                this.label1.Text = "-----";
            }
        }
        private void button_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.listBox_Branch.Text != "" && this.listBox_Branch2.Text.Length > 6)
                {
                    VarGeneral.brNm = this.listBox_Branch2.Text;
                    this.Close();
                }
            }
            catch
            {
                this.label1.Text = "-----";
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.listBox_Branch = new ListBox();
            this.listBox_Branch2 = new ListBox();
            this.label1 = new Label();
            this.label2 = new Label();
            this.button_OK = new ButtonX();
            this.SuspendLayout();
            this.listBox_Branch.BackColor = Color.SteelBlue;
            this.listBox_Branch.Dock = DockStyle.Top;
            this.listBox_Branch.Font = new Font("Tahoma", 11f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.listBox_Branch.ForeColor = Color.White;
            this.listBox_Branch.FormattingEnabled = true;
            this.listBox_Branch.ItemHeight = 18;
            this.listBox_Branch.Location = new Point(0, 0);
            this.listBox_Branch.Name = "listBox_Branch";
            this.listBox_Branch.ScrollAlwaysVisible = true;
            this.listBox_Branch.Size = new Size(469, 166);
            this.listBox_Branch.TabIndex = 0;
            this.listBox_Branch.SelectedIndexChanged += new EventHandler(this.listBox_Branch_SelectedIndexChanged);
            this.listBox_Branch2.BackColor = Color.White;
            this.listBox_Branch2.Font = new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.listBox_Branch2.FormattingEnabled = true;
            this.listBox_Branch2.ItemHeight = 14;
            this.listBox_Branch2.Location = new Point(155, 100);
            this.listBox_Branch2.Name = "listBox_Branch2";
            this.listBox_Branch2.ScrollAlwaysVisible = true;
            this.listBox_Branch2.Size = new Size(42, 18);
            this.listBox_Branch2.TabIndex = 11;
            this.label1.BackColor = Color.White;
            this.label1.BorderStyle = BorderStyle.FixedSingle;
            this.label1.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.label1.Location = new Point(3, 168);
            this.label1.Name = "label1";
            this.label1.Size = new Size(306, 37);
            this.label1.TabIndex = 12;
            this.label1.Text = "-----";
            this.label1.TextAlign = ContentAlignment.MiddleCenter;
            this.label2.BackColor = Color.WhiteSmoke;
            this.label2.BorderStyle = BorderStyle.FixedSingle;
            this.label2.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.label2.Location = new Point(311, 168);
            this.label2.Name = "label2";
            this.label2.Size = new Size(156, 37);
            this.label2.TabIndex = 13;
            this.label2.Text = "Enter To | الدخول إلى";
            this.label2.TextAlign = ContentAlignment.MiddleCenter;
            this.button_OK.AccessibleRole = AccessibleRole.PushButton;
            this.button_OK.ColorTable = eButtonColor.BlueOrb;
            this.button_OK.Dock = DockStyle.Bottom;
            this.button_OK.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.button_OK.ImagePosition = eImagePosition.Right;
            this.button_OK.Location = new Point(0, 207);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new Size(469, 40);
            this.button_OK.Style = eDotNetBarStyle.StyleManagerControlled;
            this.button_OK.Symbol = "\xF00C";
            this.button_OK.TabIndex = 1582;
            this.button_OK.Text = "Enter - دخــــول";
            this.button_OK.TextColor = Color.White;
            this.button_OK.Click += new EventHandler(this.button_OK_Click);
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.GradientInactiveCaption;
            this.ClientSize = new Size(469, 247);
            this.ControlBox = false;
            this.Controls.Add((Control)this.button_OK);
            this.Controls.Add((Control)this.label2);
            this.Controls.Add((Control)this.label1);
            this.Controls.Add((Control)this.listBox_Branch);
            this.Controls.Add((Control)this.listBox_Branch2);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Name = "FrmBranch";
            this.ShowIcon = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += new EventHandler(this.FrmBranch_Load);
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.ResumeLayout(false);
        }
    }
}
