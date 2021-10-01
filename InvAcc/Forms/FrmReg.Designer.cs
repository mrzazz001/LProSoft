using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using ProShared.GeneralM;using ProShared;
using Microsoft.Win32;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Management;
using System.Windows.Forms;


namespace InvAcc.Forms
{
    partial class FrmReg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReg));
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.txtDiskInfo = new System.Windows.Forms.TextBox();
            this.txtWindowsName = new System.Windows.Forms.TextBox();
            this.txtBIOSId = new System.Windows.Forms.TextBox();
            this.txtProcessorId = new System.Windows.Forms.TextBox();
            this.txtDiskSerNo = new System.Windows.Forms.TextBox();
            this.txtRunNo = new System.Windows.Forms.TextBox();
            this.txtSerNo = new System.Windows.Forms.TextBox();
            this.txtProName = new System.Windows.Forms.TextBox();
            this.textBox_Email = new System.Windows.Forms.TextBox();
            this.textBox_ActivatedCompany = new System.Windows.Forms.TextBox();
            this.textBox_City = new System.Windows.Forms.TextBox();
            this.txtPost = new System.Windows.Forms.TextBox();
            this.txtPOBOX = new System.Windows.Forms.TextBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtPrsName = new System.Windows.Forms.TextBox();
            this.txtCsutName = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_Close = new DevComponents.DotNetBar.ButtonX();
            this.bubbleButton_Cancel = new DevComponents.DotNetBar.ButtonX();
            this.bubbleButton_Print = new DevComponents.DotNetBar.ButtonX();
            this.bubbleBar_Ok = new DevComponents.DotNetBar.ButtonX();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(323, 214);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(141, 18);
            this.label9.TabIndex = 15;
            this.label9.Text = "مفتاح التشغيل";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(323, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(141, 18);
            this.label8.TabIndex = 13;
            this.label8.Text = "الرقم التسلسلي";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(323, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 18);
            this.label7.TabIndex = 11;
            this.label7.Text = "رقم المنتج";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(323, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "رقم القرص الصلب";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(323, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "رقم المعالج";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(323, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "رقم اللوحة الأم";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(323, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "نظام التشغيل";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(323, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "أسم المنتج";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // netResize1
            // 
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            // 
            // txtDiskInfo
            // 
            this.txtDiskInfo.BackColor = System.Drawing.Color.White;
            this.txtDiskInfo.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtDiskInfo.Location = new System.Drawing.Point(308, 20);
            this.txtDiskInfo.Name = "txtDiskInfo";
            this.txtDiskInfo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtDiskInfo, false);
            this.txtDiskInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDiskInfo.Size = new System.Drawing.Size(183, 21);
            this.txtDiskInfo.TabIndex = 4;
            this.txtDiskInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtWindowsName
            // 
            this.txtWindowsName.BackColor = System.Drawing.Color.White;
            this.txtWindowsName.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtWindowsName.Location = new System.Drawing.Point(74, 47);
            this.txtWindowsName.Name = "txtWindowsName";
            this.txtWindowsName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtWindowsName, false);
            this.txtWindowsName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtWindowsName.Size = new System.Drawing.Size(159, 21);
            this.txtWindowsName.TabIndex = 1;
            this.txtWindowsName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBIOSId
            // 
            this.txtBIOSId.BackColor = System.Drawing.Color.White;
            this.txtBIOSId.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtBIOSId.Location = new System.Drawing.Point(74, 17);
            this.txtBIOSId.Name = "txtBIOSId";
            this.txtBIOSId.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtBIOSId, false);
            this.txtBIOSId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBIOSId.Size = new System.Drawing.Size(159, 21);
            this.txtBIOSId.TabIndex = 3;
            this.txtBIOSId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtProcessorId
            // 
            this.txtProcessorId.BackColor = System.Drawing.Color.White;
            this.txtProcessorId.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtProcessorId.Location = new System.Drawing.Point(308, 50);
            this.txtProcessorId.Name = "txtProcessorId";
            this.txtProcessorId.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtProcessorId, false);
            this.txtProcessorId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtProcessorId.Size = new System.Drawing.Size(183, 21);
            this.txtProcessorId.TabIndex = 2;
            this.txtProcessorId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDiskSerNo
            // 
            this.txtDiskSerNo.BackColor = System.Drawing.Color.White;
            this.txtDiskSerNo.Location = new System.Drawing.Point(8, 25);
            this.txtDiskSerNo.MaxLength = 10;
            this.txtDiskSerNo.Name = "txtDiskSerNo";
            this.txtDiskSerNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtDiskSerNo, false);
            this.txtDiskSerNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDiskSerNo.Size = new System.Drawing.Size(515, 21);
            this.txtDiskSerNo.TabIndex = 5;
            this.txtDiskSerNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtRunNo
            // 
            this.txtRunNo.BackColor = System.Drawing.Color.White;
            this.txtRunNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtRunNo.Location = new System.Drawing.Point(294, 71);
            this.txtRunNo.Name = "txtRunNo";
            this.netResize1.SetResizeTextBoxMultiline(this.txtRunNo, false);
            this.txtRunNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRunNo.Size = new System.Drawing.Size(229, 21);
            this.txtRunNo.TabIndex = 7;
            this.txtRunNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSerNo
            // 
            this.txtSerNo.BackColor = System.Drawing.Color.White;
            this.txtSerNo.Location = new System.Drawing.Point(16, 71);
            this.txtSerNo.Name = "txtSerNo";
            this.netResize1.SetResizeTextBoxMultiline(this.txtSerNo, false);
            this.txtSerNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSerNo.Size = new System.Drawing.Size(195, 21);
            this.txtSerNo.TabIndex = 6;
            this.txtSerNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSerNo.TextChanged += new System.EventHandler(this.txtSerNo_TextChanged_1);
            // 
            // txtProName
            // 
            this.txtProName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtProName.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtProName.Location = new System.Drawing.Point(14, -96);
            this.txtProName.Name = "txtProName";
            this.txtProName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtProName, false);
            this.txtProName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtProName.Size = new System.Drawing.Size(417, 21);
            this.txtProName.TabIndex = 0;
            this.txtProName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtProName.Visible = false;
            // 
            // textBox_Email
            // 
            this.textBox_Email.BackColor = System.Drawing.Color.White;
            this.textBox_Email.Location = new System.Drawing.Point(11, 144);
            this.textBox_Email.Name = "textBox_Email";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Email, false);
            this.textBox_Email.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_Email.Size = new System.Drawing.Size(436, 20);
            this.textBox_Email.TabIndex = 10;
            this.textBox_Email.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_ActivatedCompany
            // 
            this.textBox_ActivatedCompany.BackColor = System.Drawing.Color.White;
            this.textBox_ActivatedCompany.Location = new System.Drawing.Point(293, 37);
            this.textBox_ActivatedCompany.Name = "textBox_ActivatedCompany";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_ActivatedCompany, false);
            this.textBox_ActivatedCompany.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_ActivatedCompany.Size = new System.Drawing.Size(152, 20);
            this.textBox_ActivatedCompany.TabIndex = 2;
            // 
            // textBox_City
            // 
            this.textBox_City.BackColor = System.Drawing.Color.White;
            this.textBox_City.Location = new System.Drawing.Point(11, 90);
            this.textBox_City.Name = "textBox_City";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_City, false);
            this.textBox_City.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_City.Size = new System.Drawing.Size(174, 20);
            this.textBox_City.TabIndex = 7;
            this.textBox_City.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPost
            // 
            this.txtPost.BackColor = System.Drawing.Color.White;
            this.txtPost.Location = new System.Drawing.Point(11, 117);
            this.txtPost.Name = "txtPost";
            this.netResize1.SetResizeTextBoxMultiline(this.txtPost, false);
            this.txtPost.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPost.Size = new System.Drawing.Size(175, 20);
            this.txtPost.TabIndex = 9;
            this.txtPost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPOBOX
            // 
            this.txtPOBOX.BackColor = System.Drawing.Color.White;
            this.txtPOBOX.Location = new System.Drawing.Point(320, 117);
            this.txtPOBOX.Name = "txtPOBOX";
            this.netResize1.SetResizeTextBoxMultiline(this.txtPOBOX, false);
            this.txtPOBOX.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPOBOX.Size = new System.Drawing.Size(124, 20);
            this.txtPOBOX.TabIndex = 8;
            this.txtPOBOX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMobile
            // 
            this.txtMobile.BackColor = System.Drawing.Color.White;
            this.txtMobile.Location = new System.Drawing.Point(320, 90);
            this.txtMobile.Name = "txtMobile";
            this.netResize1.SetResizeTextBoxMultiline(this.txtMobile, false);
            this.txtMobile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMobile.Size = new System.Drawing.Size(124, 20);
            this.txtMobile.TabIndex = 6;
            this.txtMobile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFax
            // 
            this.txtFax.BackColor = System.Drawing.Color.White;
            this.txtFax.Location = new System.Drawing.Point(11, 63);
            this.txtFax.Name = "txtFax";
            this.netResize1.SetResizeTextBoxMultiline(this.txtFax, false);
            this.txtFax.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFax.Size = new System.Drawing.Size(175, 20);
            this.txtFax.TabIndex = 5;
            this.txtFax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTel
            // 
            this.txtTel.BackColor = System.Drawing.Color.White;
            this.txtTel.Location = new System.Drawing.Point(320, 63);
            this.txtTel.Name = "txtTel";
            this.netResize1.SetResizeTextBoxMultiline(this.txtTel, false);
            this.txtTel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTel.Size = new System.Drawing.Size(124, 20);
            this.txtTel.TabIndex = 4;
            this.txtTel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPrsName
            // 
            this.txtPrsName.BackColor = System.Drawing.Color.White;
            this.txtPrsName.Location = new System.Drawing.Point(11, 36);
            this.txtPrsName.Name = "txtPrsName";
            this.netResize1.SetResizeTextBoxMultiline(this.txtPrsName, false);
            this.txtPrsName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrsName.Size = new System.Drawing.Size(175, 20);
            this.txtPrsName.TabIndex = 3;
            // 
            // txtCsutName
            // 
            this.txtCsutName.BackColor = System.Drawing.Color.White;
            this.txtCsutName.Location = new System.Drawing.Point(11, 9);
            this.txtCsutName.Name = "txtCsutName";
            this.netResize1.SetResizeTextBoxMultiline(this.txtCsutName, false);
            this.txtCsutName.Size = new System.Drawing.Size(436, 20);
            this.txtCsutName.TabIndex = 0;
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.Color.SteelBlue;
            this.textBox9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBox9.ForeColor = System.Drawing.Color.White;
            this.textBox9.Location = new System.Drawing.Point(6, 200);
            this.textBox9.Multiline = true;
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.textBox9, false);
            this.textBox9.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox9.Size = new System.Drawing.Size(317, 67);
            this.textBox9.TabIndex = 103;
            this.textBox9.Text = resources.GetString("textBox9.Text");
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.ForestGreen;
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label21.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(0, 196);
            this.label21.Name = "label21";
            this.netResize1.SetResizeChildren(this.label21, false);
            this.netResize1.SetResizeControl(this.label21, false);
            this.netResize1.SetResizeFont(this.label21, false);
            this.label21.Size = new System.Drawing.Size(562, 27);
            this.label21.TabIndex = 13;
            this.label21.Text = "تفعيل النسخة";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.Gainsboro;
            this.label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label29.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label29.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label29.ForeColor = System.Drawing.Color.Black;
            this.label29.Location = new System.Drawing.Point(0, -4);
            this.label29.Name = "label29";
            this.netResize1.SetResizeChildren(this.label29, false);
            this.netResize1.SetResizeControl(this.label29, false);
            this.netResize1.SetResizeFont(this.label29, false);
            this.label29.Size = new System.Drawing.Size(562, 28);
            this.label29.TabIndex = 1172;
            this.label29.Text = "بيانات العميل";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label29.Click += new System.EventHandler(this.label29_Click);
            // 
            // panel2
            // 
            this.panel2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.panel2.Controls.Add(this.button_Close);
            this.panel2.Controls.Add(this.bubbleButton_Cancel);
            this.panel2.Controls.Add(this.bubbleButton_Print);
            this.panel2.Controls.Add(this.bubbleBar_Ok);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 497);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(562, 53);
            this.panel2.TabIndex = 1171;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // button_Close
            // 
            this.button_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_Close.Location = new System.Drawing.Point(0, 0);
            this.button_Close.Margin = new System.Windows.Forms.Padding(2);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(102, 54);
            this.button_Close.TabIndex = 1172;
            this.button_Close.Text = "اغلاق";
            this.button_Close.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // bubbleButton_Cancel
            // 
            this.bubbleButton_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bubbleButton_Cancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.bubbleButton_Cancel.Location = new System.Drawing.Point(102, 0);
            this.bubbleButton_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.bubbleButton_Cancel.Name = "bubbleButton_Cancel";
            this.bubbleButton_Cancel.Size = new System.Drawing.Size(179, 54);
            this.bubbleButton_Cancel.TabIndex = 1171;
            this.bubbleButton_Cancel.Text = "تجريب النسخة";
            this.bubbleButton_Cancel.Click += new System.EventHandler(this.bubbleButton_Cancel_Click);
            // 
            // bubbleButton_Print
            // 
            this.bubbleButton_Print.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bubbleButton_Print.Dock = System.Windows.Forms.DockStyle.Right;
            this.bubbleButton_Print.Location = new System.Drawing.Point(281, 0);
            this.bubbleButton_Print.Margin = new System.Windows.Forms.Padding(2);
            this.bubbleButton_Print.Name = "bubbleButton_Print";
            this.bubbleButton_Print.Size = new System.Drawing.Size(160, 54);
            this.bubbleButton_Print.TabIndex = 1170;
            this.bubbleButton_Print.Text = "طباعة الاستمارة";
            this.bubbleButton_Print.Click += new System.EventHandler(this.bubbleButton_Print_Click);
            // 
            // bubbleBar_Ok
            // 
            this.bubbleBar_Ok.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bubbleBar_Ok.Dock = System.Windows.Forms.DockStyle.Right;
            this.bubbleBar_Ok.Location = new System.Drawing.Point(441, 0);
            this.bubbleBar_Ok.Margin = new System.Windows.Forms.Padding(2);
            this.bubbleBar_Ok.Name = "bubbleBar_Ok";
            this.bubbleBar_Ok.Size = new System.Drawing.Size(121, 54);
            this.bubbleBar_Ok.TabIndex = 1169;
            this.bubbleBar_Ok.Text = "تفعيل";
            this.bubbleBar_Ok.Click += new System.EventHandler(this.bubbleButton_Ok_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gold;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label40);
            this.panel4.Controls.Add(this.textBox_Email);
            this.panel4.Controls.Add(this.label41);
            this.panel4.Controls.Add(this.textBox_ActivatedCompany);
            this.panel4.Controls.Add(this.label43);
            this.panel4.Controls.Add(this.textBox_City);
            this.panel4.Controls.Add(this.label44);
            this.panel4.Controls.Add(this.txtPost);
            this.panel4.Controls.Add(this.label45);
            this.panel4.Controls.Add(this.txtPOBOX);
            this.panel4.Controls.Add(this.label46);
            this.panel4.Controls.Add(this.txtMobile);
            this.panel4.Controls.Add(this.label47);
            this.panel4.Controls.Add(this.txtFax);
            this.panel4.Controls.Add(this.label48);
            this.panel4.Controls.Add(this.txtTel);
            this.panel4.Controls.Add(this.label49);
            this.panel4.Controls.Add(this.txtPrsName);
            this.panel4.Controls.Add(this.label50);
            this.panel4.Controls.Add(this.txtCsutName);
            this.panel4.Location = new System.Drawing.Point(3, 24);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(559, 170);
            this.panel4.TabIndex = 98;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(449, 146);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(87, 16);
            this.label40.TabIndex = 51;
            this.label40.Text = "بريد إلكتروني :";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(186, 38);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(94, 16);
            this.label41.TabIndex = 49;
            this.label41.Text = "اسم المسؤول :";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(186, 92);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(41, 16);
            this.label43.TabIndex = 45;
            this.label43.Text = "البلد :";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(186, 119);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(84, 16);
            this.label44.TabIndex = 43;
            this.label44.Text = "الرمز البريدي :";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(449, 119);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(98, 16);
            this.label45.TabIndex = 42;
            this.label45.Text = "صندوق البريدي :";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(449, 92);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(63, 16);
            this.label46.TabIndex = 39;
            this.label46.Text = "موبايــــل :";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.Location = new System.Drawing.Point(186, 65);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(49, 16);
            this.label47.TabIndex = 38;
            this.label47.Text = "فاكس :";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.Location = new System.Drawing.Point(449, 65);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(57, 16);
            this.label48.TabIndex = 37;
            this.label48.Text = "تلفـــون :";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.Location = new System.Drawing.Point(449, 38);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(96, 16);
            this.label49.TabIndex = 19;
            this.label49.Text = "نشاط المنشأة :";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.Location = new System.Drawing.Point(449, 11);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(90, 16);
            this.label50.TabIndex = 17;
            this.label50.Text = "إسم المنشأة :";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.GreenYellow;
            this.groupBox1.Controls.Add(this.textBox9);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupPanel1);
            this.groupBox1.Controls.Add(this.txtDiskSerNo);
            this.groupBox1.Controls.Add(this.txtRunNo);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtSerNo);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtProName);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 224);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(562, 273);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.Black;
            this.checkBox1.Location = new System.Drawing.Point(332, 200);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(211, 17);
            this.checkBox1.TabIndex = 102;
            this.checkBox1.Text = "نعم , أوافق على جميع شروط المنتج";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(363, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 31;
            this.label1.Text = "Activation No";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.OrangeRed;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.ColorTable = DevComponents.DotNetBar.Controls.ePanelColorTable.Orange;
            this.groupPanel1.Controls.Add(this.label12);
            this.groupPanel1.Controls.Add(this.label13);
            this.groupPanel1.Controls.Add(this.label14);
            this.groupPanel1.Controls.Add(this.label15);
            this.groupPanel1.Controls.Add(this.txtDiskInfo);
            this.groupPanel1.Controls.Add(this.txtWindowsName);
            this.groupPanel1.Controls.Add(this.txtBIOSId);
            this.groupPanel1.Controls.Add(this.txtProcessorId);
            this.groupPanel1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(10, 99);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(515, 95);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(192)))), ((int)(((byte)(143)))));
            this.groupPanel1.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(150)))), ((int)(((byte)(70)))));
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(72)))), ((int)(((byte)(6)))));
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(61)))), ((int)(((byte)(6)))));
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 30;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(239, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 16);
            this.label12.TabIndex = 26;
            this.label12.Text = "Hard Desc";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(253, 49);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 16);
            this.label13.TabIndex = 25;
            this.label13.Text = "Process";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(37, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 16);
            this.label14.TabIndex = 24;
            this.label14.Text = "Bord";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(41, 49);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 16);
            this.label15.TabIndex = 23;
            this.label15.Text = "Win";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(102, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 17);
            this.label10.TabIndex = 29;
            this.label10.Text = "Serial";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(218, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 17);
            this.label11.TabIndex = 27;
            this.label11.Text = "Prouduct Code ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(434, -96);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 16);
            this.label16.TabIndex = 22;
            this.label16.Text = "إسم المنتج :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label16.Visible = false;
            // 
            // FrmReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(562, 550);
            this.ControlBox = false;
            this.Controls.Add(this.label29);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = global::InvAcc.Properties.Resources.favicon;
            this.KeyPreview = true;
            this.Name = "FrmReg";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تفعيل النسخة";
            this.Load += new System.EventHandler(this.FrmReg_Load);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);

        }//###########&&&&&&&&&&
        private Panel panel2;
        private DevComponents.DotNetBar.ButtonX button_Close;
        private DevComponents.DotNetBar.ButtonX bubbleButton_Cancel;
        private DevComponents.DotNetBar.ButtonX bubbleButton_Print;
        private DevComponents.DotNetBar.ButtonX bubbleBar_Ok;
        private Panel panel4;
        private Label label40;
        private TextBox textBox_Email;
        private Label label41;
        private TextBox textBox_ActivatedCompany;
        private Label label43;
        private TextBox textBox_City;
        private Label label44;
        private TextBox txtPost;
        private Label label45;
        private TextBox txtPOBOX;
        private Label label46;
        private TextBox txtMobile;
        private Label label47;
        private TextBox txtFax;
        private Label label48;
        private TextBox txtTel;
        private Label label49;
        private TextBox txtPrsName;
        private Label label50;
        private TextBox txtCsutName;
        private GroupBox groupBox1;
        private CheckBox checkBox1;
        private Label label1;
        private GroupPanel groupPanel1;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private TextBox txtDiskInfo;
        private TextBox txtWindowsName;
        private TextBox txtBIOSId;
        private TextBox txtProcessorId;
        private TextBox txtDiskSerNo;
        private TextBox txtRunNo;
        private Label label10;
        private TextBox txtSerNo;
        private Label label11;
        private Label label16;
        private TextBox txtProName;
        private Label label21;
        private TextBox textBox9;
        private Label label29;
    }
}
