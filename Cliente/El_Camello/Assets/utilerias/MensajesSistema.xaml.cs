using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace El_Camello.Assets.utilerias
{
    /// <summary>
    /// Interaction logic for MensajesSistema.xaml
    /// </summary>
    public partial class MensajesSistema : Window
    {
        private string tipoError;
        private string mensaje;
        private int confirmacionAccion = 0;
        private string ubicacion;
        private string excepcionCapturada;

        public MensajesSistema(string tipoError, string mensaje)
        {
            this.tipoError = tipoError;
            this.mensaje = mensaje;
            iniciarComponentes();
            tipoMensaje();

        }

        private void iniciarComponentes()
        {

            InitializeComponent();
            btnOk.IsEnabled = false;
            tbDetalles.IsEnabled = false;
            tbUbicacion.IsEnabled = false;


        }

        public MensajesSistema(string tipoError, string mensaje, string ubicacion, string excepcionCapturada)
        {
            this.tipoError = tipoError;
            this.mensaje = mensaje;
            this.ubicacion = ubicacion;
            this.excepcionCapturada = excepcionCapturada;
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

                    lbTipoMensaje.ContentStringFormat = "Acción no permitida";
                    winMensaje.Title = "Alerta de acción invalida";
                    btnOk.IsEnabled = true;
                    tbUbicacion.IsEnabled = true;
                    accionInvalida();


                    break;
                default:

                    break;

            }



        }

        public void accionInvalida()
        {
            lbTipoMensaje.Content = "Mensaje informativo";
            btnOk.IsEnabled = true;
            tbDetalles.IsEnabled = true;
            tbUbicacion.IsEnabled = true;

            tbMensaje.Text = "Mensaje: " + mensaje;
            tbUbicacion.Text = "Ubicación: " + ubicacion;
            tbDetalles.Text = "Detalles: " + excepcionCapturada;
        }

        public void mensajeError()
        {
            lbTipoMensaje.Content = "Se presento un error";
            winMensaje.Title = "Error";
            btnOk.IsEnabled = true;
            tbDetalles.IsEnabled = true;
            tbUbicacion.IsEnabled = true;

            tbMensaje.Text = "Mensaje: " + mensaje;
            tbUbicacion.Text = "Ubicación: " + ubicacion;
            tbDetalles.Text = "Detalles: " + excepcionCapturada;

        }


        private void enterado(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
