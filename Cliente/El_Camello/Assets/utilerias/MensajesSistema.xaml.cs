using System.Windows;

namespace El_Camello.Assets.utilerias
{
    /// <summary>
    /// Interaction logic for MensajesSistema.xaml
    /// </summary>
    public partial class MensajesSistema : Window
    {
        private string tipoError;
        private string mensaje;
        private string ubicacion;
        private string detalles;

        public MensajesSistema(string tipoError, string mensaje)
        {
            this.tipoError = tipoError;
            this.mensaje = mensaje;
            ubicacion = "";
            detalles = "";
            iniciarComponentes();
            tipoMensaje();

        }

        private void iniciarComponentes()
        {

            InitializeComponent();
            btnOk.IsEnabled = false;
            tbDetalles.IsEnabled = false;
            tbUbicacion.IsEnabled = false;
            tbMensaje.IsEnabled = false;


        }

        public MensajesSistema(string tipoError, string mensaje, string ubicacion, string excepcionCapturada)
        {
            this.tipoError = tipoError;
            this.mensaje = mensaje;
            this.ubicacion = ubicacion;
            this.detalles = excepcionCapturada;
            iniciarComponentes();


            tipoMensaje();

        }

        private void tipoMensaje()
        {
            switch (tipoError)
            {
                case "Error":

                    mensajeError();

                    break;

                case "AccionInvalida":

                    accionInvalida();


                    break;
                case "AccionExitosa":

                    mensajeExito();

                    break;
                case "Prohibido":

                    mensajeProhibido();

                    break;
                case "Duplicado":

                    mensajeDuplicado();

                    break;
                default:

                    break;

            }



        }

        public void accionInvalida()
        {

            imgDuplicado.Source = null;
            imgProhibido.Source = null;
            imgAccion.Source = null;
            imgError.Source = null;
            lbTipoMensaje.Content = "Mensaje informativo";

            winMensaje.Title = "Alerta de acción invalida";
            btnOk.IsEnabled = true;
            btnOk.IsEnabled = true;

            tbMensaje.Text = "Mensaje: " + mensaje;
            tbUbicacion.Text = "Ubicación: " + ubicacion;
            tbDetalles.Text = "Detalles: " + detalles;
        }

        public void mensajeError()
        {
            imgDuplicado.Source = null;
            imgProhibido.Source = null;
            imgAccion.Source = null;
            imgAlerta.Source = null;
            lbTipoMensaje.Content = "Se presento un error";
            winMensaje.Title = "Error";
            btnOk.IsEnabled = true;

            tbMensaje.Text = "Mensaje: " + mensaje;
            tbUbicacion.Text = "Ubicación: " + ubicacion;
            tbDetalles.Text = "Detalles: " + detalles;

        }

        public void mensajeExito()
        {
            imgDuplicado.Source = null;
            imgProhibido.Source = null;
            imgAlerta.Source = null;
            imgError.Source = null;
            winMensaje.Title = "Acción existosa";
            btnOk.IsEnabled = true;

            lbTipoMensaje.Content = "Se ha completado la acción";
            btnOk.IsEnabled = true;

            tbMensaje.Text = "Mensaje: " + mensaje;
            tbUbicacion.Text = "Acción: " + ubicacion;
            tbDetalles.Text = "Resultado: " + detalles;

        }

        public void mensajeProhibido()
        {
            imgDuplicado.Source = null;
            imgAccion.Source = null;
            imgAlerta.Source = null;
            imgError.Source = null;
            winMensaje.Title = "Prohibido";
            btnOk.IsEnabled = true;

            lbTipoMensaje.Content = "Contenido bloqueado";
            btnOk.IsEnabled = true;

            tbMensaje.Text = "Mensaje: " + mensaje;
            tbUbicacion.Text = "Acción: " + ubicacion;
            tbDetalles.Text = "Resultado: " + detalles;

        }

        public void mensajeDuplicado()
        {
            imgAccion.Source = null;
            imgProhibido.Source = null;
            imgAlerta.Source = null;
            imgError.Source = null;
            winMensaje.Title = "Petición no aceptada";
            btnOk.IsEnabled = true;

            lbTipoMensaje.Content = "No se ha aceptado la petición";
            btnOk.IsEnabled = true;

            tbMensaje.Text = "Mensaje: " + mensaje;
            tbUbicacion.Text = "Acción: " + ubicacion;
            tbDetalles.Text = "Resultado: " + detalles;

        }


        private void enterado(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
