using ProShared.GeneralM;using ProShared;
using System.Data.SqlClient;

namespace InvAcc.Controls
{
    partial class EXPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            SqlDependency.Stop(VarGeneral.BranchCS);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.UnExStatus = new System.Windows.Forms.DataGridView();
            this.ExStatus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UndeExeCView = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.DonExstatus = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DonView = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UnExStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UndeExeCView)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DonExstatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DonView)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(828, 517);
            this.splitContainer1.SplitterDistance = 232;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.UnExStatus);
            this.splitContainer2.Panel2.Controls.Add(this.UndeExeCView);
            this.splitContainer2.Size = new System.Drawing.Size(828, 232);
            this.splitContainer2.SplitterDistance = 25;
            this.splitContainer2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.MinimumSize = new System.Drawing.Size(598, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(598, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "اوامر الطلب التي تحت التنفيذ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // UnExStatus
            // 
            this.UnExStatus.AllowUserToAddRows = false;
            this.UnExStatus.AllowUserToDeleteRows = false;
            this.UnExStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UnExStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ExStatus});
            this.UnExStatus.Location = new System.Drawing.Point(203, 26);
            this.UnExStatus.Name = "UnExStatus";
            this.UnExStatus.Size = new System.Drawing.Size(238, 140);
            this.UnExStatus.TabIndex = 2;
            this.UnExStatus.Visible = false;
            this.UnExStatus.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.UnExStatus_CellEndEdit);
            this.UnExStatus.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.UnExStatus_RowsAdded);
            this.UnExStatus.Leave += new System.EventHandler(this.UnExStatus_Leave);
            // 
            // ExStatus
            // 
            this.ExStatus.HeaderText = "حالة تنفيذ";
            this.ExStatus.Name = "ExStatus";
            // 
            // UndeExeCView
            // 
            this.UndeExeCView.AllowUserToAddRows = false;
            this.UndeExeCView.AllowUserToDeleteRows = false;
            this.UndeExeCView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.UndeExeCView.BackgroundColor = System.Drawing.Color.Firebrick;
            this.UndeExeCView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.UndeExeCView.DefaultCellStyle = dataGridViewCellStyle1;
            this.UndeExeCView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UndeExeCView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.UndeExeCView.Location = new System.Drawing.Point(0, 0);
            this.UndeExeCView.Name = "UndeExeCView";
            this.UndeExeCView.Size = new System.Drawing.Size(828, 203);
            this.UndeExeCView.TabIndex = 1;
            this.UndeExeCView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UndeExeCView_CellClick);
            this.UndeExeCView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UndeExeCView_CellContentClick_1);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.DonExstatus);
            this.splitContainer3.Panel2.Controls.Add(this.DonView);
            this.splitContainer3.Size = new System.Drawing.Size(828, 281);
            this.splitContainer3.SplitterDistance = 42;
            this.splitContainer3.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.MinimumSize = new System.Drawing.Size(598, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(598, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "اوامر الطلب التي تم تنفيذها";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DonExstatus
            // 
            this.DonExstatus.AllowUserToAddRows = false;
            this.DonExstatus.AllowUserToDeleteRows = false;
            this.DonExstatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DonExstatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1});
            this.DonExstatus.Location = new System.Drawing.Point(168, 46);
            this.DonExstatus.Name = "DonExstatus";
            this.DonExstatus.Size = new System.Drawing.Size(253, 140);
            this.DonExstatus.TabIndex = 3;
            this.DonExstatus.Visible = false;
            this.DonExstatus.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DonExstatus_CellBeginEdit);
            this.DonExstatus.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DonExstatus_CellEndEdit);
            this.DonExstatus.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DonExstatus_RowsAdded);
            this.DonExstatus.Leave += new System.EventHandler(this.DonExstatus_Leave);
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "حالة تنفيذ";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // DonView
            // 
            this.DonView.AllowUserToAddRows = false;
            this.DonView.AllowUserToDeleteRows = false;
            this.DonView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DonView.BackgroundColor = System.Drawing.Color.LawnGreen;
            this.DonView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DonView.DefaultCellStyle = dataGridViewCellStyle2;
            this.DonView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DonView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DonView.Location = new System.Drawing.Point(0, 0);
            this.DonView.Name = "DonView";
            this.DonView.Size = new System.Drawing.Size(828, 235);
            this.DonView.TabIndex = 0;
            this.DonView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DonView_CellClick);
            this.DonView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DonView_CellContentClick_1);
            this.DonView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DonView_CellEnter);
            this.DonView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DonView_RowEnter);
            // 
            // EXPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Name = "EXPanel";
            this.Size = new System.Drawing.Size(828, 517);
            this.Load += new System.EventHandler(this.EXPanel_Load);
            this.SizeChanged += new System.EventHandler(this.EXPanel_SizeChanged);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UnExStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UndeExeCView)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DonExstatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DonView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.DataGridViewX UndeExeCView;
        private DevComponents.DotNetBar.Controls.DataGridViewX DonView;
        private System.Windows.Forms.DataGridView UnExStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ExStatus;
        private System.Windows.Forms.DataGridView DonExstatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
    }
}
