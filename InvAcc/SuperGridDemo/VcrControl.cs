using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace SuperGridDemo
{
	public class VcrControl : UserControl
	{
		private IContainer components = null;
		private Button btnFirst;
		private Button btnLast;
		private Button btnPrevious;
		private Button btnNext;
		private ImageList imageList1;
		private Label label;
		private Panel leftPanel;
		private Panel rightPanel;
		public Label Label => label;
		public Button FirstButton => btnFirst;
		public Button PreviousButton => btnPrevious;
		public Button NextButton => btnNext;
		public Button LastButton => btnLast;
		[Description("Occurs when a cell has been clicked.")]
		public event EventHandler<EventArgs> FirstClick;
		[Description("Occurs when the 'Previous' button has been clicked.")]
		public event EventHandler<EventArgs> PreviousClick;
		[Description("Occurs when the 'Next' button has been clicked.")]
		public event EventHandler<EventArgs> NextClick;
		[Description("Occurs when the 'Last' button has been clicked.")]
		public event EventHandler<EventArgs> LastClick;
		public VcrControl()
		{
			InitializeComponent();
		}
		private void BtnFirstClick(object sender, EventArgs e)
		{
			if (this.FirstClick != null)
			{
				this.FirstClick(this, EventArgs.Empty);
			}
		}
		private void BtnPreviousClick(object sender, EventArgs e)
		{
			if (this.PreviousClick != null)
			{
				this.PreviousClick(this, EventArgs.Empty);
			}
		}
		private void BtnNextClick(object sender, EventArgs e)
		{
			if (this.NextClick != null)
			{
				this.NextClick(this, EventArgs.Empty);
			}
		}
		private void BtnLastClick(object sender, EventArgs e)
		{
			if (this.LastClick != null)
			{
				this.LastClick(this, EventArgs.Empty);
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuperGridDemo.VcrControl));
			btnFirst = new System.Windows.Forms.Button();
			imageList1 = new System.Windows.Forms.ImageList(components);
			btnLast = new System.Windows.Forms.Button();
			btnPrevious = new System.Windows.Forms.Button();
			btnNext = new System.Windows.Forms.Button();
			label = new System.Windows.Forms.Label();
			leftPanel = new System.Windows.Forms.Panel();
			rightPanel = new System.Windows.Forms.Panel();
			leftPanel.SuspendLayout();
			rightPanel.SuspendLayout();
			SuspendLayout();
			btnFirst.AutoSize = true;
			btnFirst.Dock = System.Windows.Forms.DockStyle.Right;
			btnFirst.ImageKey = "Last";
			btnFirst.ImageList = imageList1;
			btnFirst.Location = new System.Drawing.Point(35, 0);
			btnFirst.Name = "btnFirst";
			btnFirst.Size = new System.Drawing.Size(33, 36);
			btnFirst.TabIndex = 0;
			btnFirst.UseVisualStyleBackColor = true;
			btnFirst.Click += new System.EventHandler(BtnFirstClick);
			imageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList1.ImageStream");
			imageList1.TransparentColor = System.Drawing.Color.Transparent;
			imageList1.Images.SetKeyName(0, "First");
			imageList1.Images.SetKeyName(1, "Last");
			imageList1.Images.SetKeyName(2, "Next");
			imageList1.Images.SetKeyName(3, "Previous");
			btnLast.AutoSize = true;
			btnLast.Dock = System.Windows.Forms.DockStyle.Left;
			btnLast.ImageKey = "First";
			btnLast.ImageList = imageList1;
			btnLast.Location = new System.Drawing.Point(0, 0);
			btnLast.Name = "btnLast";
			btnLast.Size = new System.Drawing.Size(33, 36);
			btnLast.TabIndex = 1;
			btnLast.UseVisualStyleBackColor = true;
			btnLast.Click += new System.EventHandler(BtnLastClick);
			btnPrevious.AutoSize = true;
			btnPrevious.Dock = System.Windows.Forms.DockStyle.Left;
			btnPrevious.ImageKey = "Next";
			btnPrevious.ImageList = imageList1;
			btnPrevious.Location = new System.Drawing.Point(0, 0);
			btnPrevious.Name = "btnPrevious";
			btnPrevious.Size = new System.Drawing.Size(33, 36);
			btnPrevious.TabIndex = 2;
			btnPrevious.UseVisualStyleBackColor = true;
			btnPrevious.Click += new System.EventHandler(BtnPreviousClick);
			btnNext.AutoSize = true;
			btnNext.Dock = System.Windows.Forms.DockStyle.Right;
			btnNext.ImageKey = "Previous";
			btnNext.ImageList = imageList1;
			btnNext.Location = new System.Drawing.Point(35, 0);
			btnNext.Name = "btnNext";
			btnNext.Size = new System.Drawing.Size(33, 36);
			btnNext.TabIndex = 3;
			btnNext.UseVisualStyleBackColor = true;
			btnNext.Click += new System.EventHandler(BtnNextClick);
			label.Dock = System.Windows.Forms.DockStyle.Fill;
			label.Location = new System.Drawing.Point(68, 0);
			label.Name = "label";
			label.Size = new System.Drawing.Size(174, 36);
			label.TabIndex = 4;
			label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			leftPanel.Controls.Add(btnFirst);
			leftPanel.Controls.Add(btnPrevious);
			leftPanel.Dock = System.Windows.Forms.DockStyle.Right;
			leftPanel.Location = new System.Drawing.Point(242, 0);
			leftPanel.Name = "leftPanel";
			leftPanel.Size = new System.Drawing.Size(68, 36);
			leftPanel.TabIndex = 5;
			rightPanel.Controls.Add(btnNext);
			rightPanel.Controls.Add(btnLast);
			rightPanel.Dock = System.Windows.Forms.DockStyle.Left;
			rightPanel.Location = new System.Drawing.Point(0, 0);
			rightPanel.Name = "rightPanel";
			rightPanel.Size = new System.Drawing.Size(68, 36);
			rightPanel.TabIndex = 6;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.Transparent;
			base.Controls.Add(label);
			base.Controls.Add(rightPanel);
			base.Controls.Add(leftPanel);
			base.Name = "VcrControl";
			base.Size = new System.Drawing.Size(310, 36);
			leftPanel.ResumeLayout(false);
			leftPanel.PerformLayout();
			rightPanel.ResumeLayout(false);
			rightPanel.PerformLayout();
			ResumeLayout(false);
		}
	}
}
