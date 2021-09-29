   

namespace InvAcc.Forms
{
partial class FrmItemPriceMonitor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmItemPriceMonitor));
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.pictureBox_PicItem = new DevComponents.DotNetBar.Controls.ReflectionImage();
            this.textbox_Eng_Des = new System.Windows.Forms.Label();
            this.textbox_Arb_Des = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_Barcode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.PicItemImg = new System.Windows.Forms.PictureBox();
            this.txtTel1 = new System.Windows.Forms.TextBox();
            this.txtAddr = new System.Windows.Forms.TextBox();
            this.txtAct = new System.Windows.Forms.TextBox();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);  this.netResize1.LabelsAutoEllipse = false;
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicItemImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.SteelBlue;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.labelX1.ForeColor = System.Drawing.Color.White;
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(632, 41);
            this.labelX1.TabIndex = 1201;
            this.labelX1.Text = "أسعار الأصنـــاف  |  Prices of items\r\n";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelX2);
            this.panel1.Controls.Add(this.pictureBox_PicItem);
            this.panel1.Controls.Add(this.textbox_Eng_Des);
            this.panel1.Controls.Add(this.textbox_Arb_Des);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.labelPrice);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.textBox_Barcode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(632, 155);
            this.panel1.TabIndex = 1203;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Gainsboro;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.labelX2.BackgroundStyle.BorderBottomColor = System.Drawing.Color.SteelBlue;
            this.labelX2.BackgroundStyle.BorderBottomWidth = 1;
            this.labelX2.BackgroundStyle.BorderColor = System.Drawing.Color.SteelBlue;
            this.labelX2.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.labelX2.BackgroundStyle.BorderLeftColor = System.Drawing.Color.SteelBlue;
            this.labelX2.BackgroundStyle.BorderLeftWidth = 1;
            this.labelX2.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.labelX2.BackgroundStyle.BorderRightColor = System.Drawing.Color.SteelBlue;
            this.labelX2.BackgroundStyle.BorderRightWidth = 1;
            this.labelX2.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.labelX2.BackgroundStyle.BorderTopColor = System.Drawing.Color.SteelBlue;
            this.labelX2.BackgroundStyle.BorderTopWidth = 1;
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.labelX2.ForeColor = System.Drawing.Color.Red;
            this.labelX2.Location = new System.Drawing.Point(4, 123);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(129, 19);
            this.labelX2.Symbol = "";
            this.labelX2.SymbolColor = System.Drawing.Color.SteelBlue;
            this.labelX2.SymbolSize = 12F;
            this.labelX2.TabIndex = 1592;
            this.labelX2.Text = "صورة الصنف | Pic";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // pictureBox_PicItem
            // 
            this.pictureBox_PicItem.BackColor = System.Drawing.Color.Gainsboro;
            // 
            // 
            // 
            this.pictureBox_PicItem.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.pictureBox_PicItem.BackgroundStyle.BorderBottomColor = System.Drawing.Color.SteelBlue;
            this.pictureBox_PicItem.BackgroundStyle.BorderBottomWidth = 1;
            this.pictureBox_PicItem.BackgroundStyle.BorderColor = System.Drawing.Color.SteelBlue;
            this.pictureBox_PicItem.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.pictureBox_PicItem.BackgroundStyle.BorderLeftColor = System.Drawing.Color.SteelBlue;
            this.pictureBox_PicItem.BackgroundStyle.BorderLeftWidth = 1;
            this.pictureBox_PicItem.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.pictureBox_PicItem.BackgroundStyle.BorderRightWidth = 1;
            this.pictureBox_PicItem.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.pictureBox_PicItem.BackgroundStyle.BorderTopColor = System.Drawing.Color.SteelBlue;
            this.pictureBox_PicItem.BackgroundStyle.BorderTopWidth = 1;
            this.pictureBox_PicItem.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pictureBox_PicItem.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.pictureBox_PicItem.Location = new System.Drawing.Point(4, 3);
            this.pictureBox_PicItem.Name = "pictureBox_PicItem";
            this.pictureBox_PicItem.Size = new System.Drawing.Size(128, 119);
            this.pictureBox_PicItem.TabIndex = 1593;
            // 
            // textbox_Eng_Des
            // 
            this.textbox_Eng_Des.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textbox_Eng_Des.BackColor = System.Drawing.Color.Yellow;
            this.textbox_Eng_Des.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textbox_Eng_Des.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.textbox_Eng_Des.ForeColor = System.Drawing.Color.Navy;
            this.textbox_Eng_Des.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textbox_Eng_Des.Location = new System.Drawing.Point(134, 77);
            this.textbox_Eng_Des.Name = "textbox_Eng_Des";
            this.textbox_Eng_Des.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textbox_Eng_Des.Size = new System.Drawing.Size(311, 32);
            this.textbox_Eng_Des.TabIndex = 1206;
            this.textbox_Eng_Des.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textbox_Arb_Des
            // 
            this.textbox_Arb_Des.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textbox_Arb_Des.BackColor = System.Drawing.Color.Yellow;
            this.textbox_Arb_Des.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textbox_Arb_Des.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.textbox_Arb_Des.ForeColor = System.Drawing.Color.Navy;
            this.textbox_Arb_Des.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textbox_Arb_Des.Location = new System.Drawing.Point(134, 44);
            this.textbox_Arb_Des.Name = "textbox_Arb_Des";
            this.textbox_Arb_Des.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textbox_Arb_Des.Size = new System.Drawing.Size(311, 32);
            this.textbox_Arb_Des.TabIndex = 1205;
            this.textbox_Arb_Des.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.Gainsboro;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(446, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 65);
            this.label2.TabIndex = 1204;
            this.label2.Text = "إسم الصنف  |  Item Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPrice
            // 
            this.labelPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPrice.BackColor = System.Drawing.Color.Yellow;
            this.labelPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelPrice.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelPrice.ForeColor = System.Drawing.Color.Navy;
            this.labelPrice.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelPrice.Location = new System.Drawing.Point(134, 110);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelPrice.Size = new System.Drawing.Size(311, 32);
            this.labelPrice.TabIndex = 1203;
            this.labelPrice.Text = "0";
            this.labelPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.BackColor = System.Drawing.Color.Gainsboro;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Navy;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(446, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(181, 32);
            this.label9.TabIndex = 1202;
            this.label9.Text = "السعــــر  |  Price";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_Barcode
            // 
            this.textBox_Barcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Barcode.BackColor = System.Drawing.Color.Red;
            // 
            // 
            // 
            this.textBox_Barcode.Border.Class = "TextBoxBorder";
            this.textBox_Barcode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_Barcode.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("textBox_Barcode.ButtonCustom.Image")));
            this.textBox_Barcode.ButtonCustom.Visible = true;
            this.textBox_Barcode.ButtonCustom2.Image = ((System.Drawing.Image)(resources.GetObject("textBox_Barcode.ButtonCustom2.Image")));
            this.textBox_Barcode.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.textBox_Barcode.ForeColor = System.Drawing.Color.Black;
            this.textBox_Barcode.Location = new System.Drawing.Point(134, 5);
            this.textBox_Barcode.Name = "textBox_Barcode";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Barcode, false);
            this.textBox_Barcode.Size = new System.Drawing.Size(493, 38);
            this.textBox_Barcode.TabIndex = 1;
            this.textBox_Barcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Barcode.WatermarkColor = System.Drawing.Color.White;
            this.textBox_Barcode.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.textBox_Barcode.WatermarkText = "رقم الباركود  -  Barcode No";
            this.textBox_Barcode.ButtonCustomClick += new System.EventHandler(this.textBox_Barcode_ButtonCustomClick);
            this.textBox_Barcode.ButtonCustom2Click += new System.EventHandler(this.textBox_Barcode_ButtonCustom2Click);
            this.textBox_Barcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Barcode_KeyDown);
            // 
            // PicItemImg
            // 
            this.PicItemImg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PicItemImg.BackColor = System.Drawing.Color.Transparent;
            this.PicItemImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PicItemImg.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.PicItemImg.Location = new System.Drawing.Point(503, 213);
            this.PicItemImg.Name = "PicItemImg";
            this.PicItemImg.Size = new System.Drawing.Size(134, 120);
            this.PicItemImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicItemImg.TabIndex = 1204;
            this.PicItemImg.TabStop = false;
            // 
            // txtTel1
            // 
            this.txtTel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTel1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtTel1.Location = new System.Drawing.Point(4, 305);
            this.txtTel1.MaxLength = 20;
            this.txtTel1.Name = "txtTel1";
            this.txtTel1.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtTel1, false);
            this.txtTel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTel1.Size = new System.Drawing.Size(497, 27);
            this.txtTel1.TabIndex = 1208;
            this.txtTel1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAddr
            // 
            this.txtAddr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddr.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtAddr.Location = new System.Drawing.Point(4, 275);
            this.txtAddr.MaxLength = 50;
            this.txtAddr.Name = "txtAddr";
            this.txtAddr.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtAddr, false);
            this.txtAddr.Size = new System.Drawing.Size(497, 27);
            this.txtAddr.TabIndex = 1207;
            this.txtAddr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAct
            // 
            this.txtAct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAct.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtAct.Location = new System.Drawing.Point(4, 245);
            this.txtAct.MaxLength = 20;
            this.txtAct.Name = "txtAct";
            this.txtAct.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtAct, false);
            this.txtAct.Size = new System.Drawing.Size(497, 27);
            this.txtAct.TabIndex = 1206;
            this.txtAct.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCompany
            // 
            this.txtCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCompany.BackColor = System.Drawing.Color.White;
            this.txtCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompany.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtCompany.Location = new System.Drawing.Point(4, 215);
            this.txtCompany.MaxLength = 50;
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtCompany, false);
            this.txtCompany.Size = new System.Drawing.Size(497, 27);
            this.txtCompany.TabIndex = 1205;
            this.txtCompany.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // netResize1
            // 
            this.netResize1.ParentControl = this;
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            // 
            // FrmItemPriceMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(632, 335);
            this.ControlBox = false;
            this.Controls.Add(this.txtTel1);
            this.Controls.Add(this.txtAddr);
            this.Controls.Add(this.txtAct);
            this.Controls.Add(this.txtCompany);
            this.Controls.Add(this.PicItemImg);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelX1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmItemPriceMonitor";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fr";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmItemPriceMonitor_Load);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicItemImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }//###########&&&&&&&&&&

}
}
