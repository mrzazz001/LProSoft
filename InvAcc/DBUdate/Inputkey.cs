
 
using InvAcc.Properties;
using InvAcc.GeneralM;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace InputKey
{
    internal class InputKey : Form
    {
        private IContainer components = (IContainer)null;
        private Button btnAceptar;
        internal Label lblMensaje;
        private Button button_Colse;
        internal PictureBox pbxIcono;
        private PictureBox pictureBox1;
        internal TextBox txtEntrada;


        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtEntrada = new System.Windows.Forms.TextBox();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.button_Colse = new System.Windows.Forms.Button();
            this.pbxIcono = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Location = new System.Drawing.Point(73, 103);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "مــوافق";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // txtEntrada
            // 
            this.txtEntrada.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtEntrada.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtEntrada.Location = new System.Drawing.Point(33, 68);
            this.txtEntrada.Name = "txtEntrada";
            this.txtEntrada.Size = new System.Drawing.Size(246, 20);
            this.txtEntrada.TabIndex = 0;
            this.txtEntrada.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEntrada.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEntrada_KeyPress);
            // 
            // lblMensaje
            // 
            this.lblMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.Location = new System.Drawing.Point(70, 31);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(10, 13);
            this.lblMensaje.TabIndex = 1173;
            this.lblMensaje.Text = ".";
            // 
            // button_Colse
            // 
            this.button_Colse.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_Colse.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_Colse.Location = new System.Drawing.Point(154, 103);
            this.button_Colse.Name = "button_Colse";
            this.button_Colse.Size = new System.Drawing.Size(75, 23);
            this.button_Colse.TabIndex = 2;
            this.button_Colse.Text = "خــروج";
            this.button_Colse.UseVisualStyleBackColor = true;
            this.button_Colse.Click += new System.EventHandler(this.button_Colse_Click);
            // 
            // pbxIcono
            // 
            this.pbxIcono.Location = new System.Drawing.Point(12, 12);
            this.pbxIcono.Name = "pbxIcono";
            this.pbxIcono.Size = new System.Drawing.Size(34, 31);
            this.pbxIcono.TabIndex = 1177;
            this.pbxIcono.TabStop = false;
            this.pbxIcono.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(201, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1178;
            this.pictureBox1.TabStop = false;
            // 
            // GetInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(313, 147);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pbxIcono);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtEntrada);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.button_Colse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GetInput";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Input_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Input_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public InputKey() => this.InitializeComponent(); 

        public void ajustarFormulario()
        {
            if (this.lblMensaje.Width > this.Width - 40)
                this.Width = this.lblMensaje.Width + 110;
            if (this.lblMensaje.Height > 65)
                this.Height = this.lblMensaje.Height + 110;
            this.lblMensaje.Location = new Point(65, 35);
        }

        public void botonCancelar()
        {
            Button button = new Button();
            button.Text = "Cancelar";
            button.Name = "btnCancelar";
            button.Anchor = AnchorStyles.Bottom;
            button.DialogResult = DialogResult.Cancel;
            this.btnAceptar.Location = new Point(65, 115);
            button.Size = new Size(75, 23);
            button.Location = new Point(161, 115);
            button.UseVisualStyleBackColor = true;
            this.Controls.Add((Control)button);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
        }

        private void button_Colse_Click(object sender, EventArgs e)
        {
            this.txtEntrada.Text = "";
           this.Dispose();
        }

        private void txtEntrada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(!char.IsNumber(e.KeyChar) & e.KeyChar != '\b'))
                return;
            e.Handled = true;
        }

        private void Input_Load(object sender, EventArgs e)
        {
            if (VarGeneral.InputChar != false)
                this.txtEntrada.PasswordChar = '*';
            if (this.lblMensaje.Text == "أدخل رقم الموظف الجديد : " || this.lblMensaje.Text == "Insert New Employee No : ")
                this.txtEntrada.KeyPress += new KeyPressEventHandler(this.txtEntrada_KeyPress);
            else
                this.txtEntrada.KeyPress -= new KeyPressEventHandler(this.txtEntrada_KeyPress);
        }

        private void Input_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
                return;
            SendKeys.Send("{Tab}");
        }

        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
        }
    }
}
