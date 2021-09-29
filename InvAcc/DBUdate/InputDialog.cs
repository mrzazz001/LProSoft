

using InvAcc.Properties;
using System.Drawing;
using System.Windows.Forms;
using InputKey;
namespace InputKey
{
    public class InputDialog
    {
        public static readonly int ACEPTAR_BOTON = 0;
        public static readonly int ACEPTAR_CANCELAR_BOTON = 1;
        public static readonly int MENSAJE_VACIO = 0;
        public static readonly int MENSAJE_ERROR = 1;
        public static readonly int MENSAJE_PREGUNTA = 2;
        public static readonly int MENSAJE_ADVERTENCIA = 3;
        public static readonly int MENSAJE_INFORMACION = 4;
        public static readonly string VERSION = "v1.0.0.0";

        public static string mostrar(string mensaje) => InputDialog.InstanciarInput(mensaje, nameof(mensaje), InputDialog.ACEPTAR_BOTON, InputDialog.MENSAJE_INFORMACION);

        public static string mostrar(string mensaje, string titulo) => InputDialog.InstanciarInput(mensaje, titulo, InputDialog.ACEPTAR_BOTON, InputDialog.MENSAJE_INFORMACION);

        public static string mostrar(string mensaje, string titulo, int tipoBoton) => InputDialog.InstanciarInput(mensaje, titulo, tipoBoton, InputDialog.MENSAJE_INFORMACION);

        public static string mostrar(string mensaje, string titulo, int tipoBoton, int tipoMensaje, int ispasswordmasked = 0) => InputDialog.InstanciarInput(mensaje, titulo, tipoBoton, tipoMensaje);
        public static string mostrar(string mensaje, string titulo, bool ispasswordmasked) => InputDialog.InstanciarInput(mensaje, titulo, InputDialog.ACEPTAR_BOTON, InputDialog.MENSAJE_INFORMACION, ispasswordmasked);

        public static string toString() => InputDialog.toString();

        private static string InstanciarInput(
          string mensaje,
          string titulo,
          int tipoBoton,
          int tipoMensaje, bool ispasswordmasked = false)
        {
            InputKey input = new InputKey();
            input.lblMensaje.Text = mensaje;
            input.Text = titulo;
            if (tipoBoton == InputDialog.ACEPTAR_CANCELAR_BOTON)
                input.botonCancelar();
            input.ajustarFormulario();
            switch (tipoMensaje)
            {
                case 0:
                    input.pbxIcono.Image = (Image)null;
                    break;
                case 1:
                    input.pbxIcono.Image = (Image)Resources.cross;
                    break;
                case 2:
                    input.pbxIcono.Image = (Image)Resources.question;
                    break;
                case 3:
                    input.pbxIcono.Image = (Image)Resources.error;
                    break;
                case 4:
                    input.pbxIcono.Image = (Image)Resources.information;
                    break;
            }
            if (ispasswordmasked == true) input.txtEntrada.UseSystemPasswordChar = true;
            if (input.ShowDialog() == DialogResult.OK)
                return input.txtEntrada.Text;
            return input.ShowDialog() == DialogResult.Cancel ? "" : "";
        }
    }
}
