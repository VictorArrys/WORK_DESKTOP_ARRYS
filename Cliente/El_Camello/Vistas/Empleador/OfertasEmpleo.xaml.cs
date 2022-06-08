using El_Camello.Vistas.Usuario;
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

namespace El_Camello.Vistas.Empleador
{
    /// <summary>
    /// Interaction logic for OfertasEmpleo.xaml
    /// </summary>
    public partial class OfertasEmpleo : Window
    {
        public OfertasEmpleo(Modelo.clases.Usuario usuarioConectado)
        {
            InitializeComponent();
            byte[] fotoPerfil = usuarioConectado.Fotografia;
            if(fotoPerfil.Length > 0)
            {
                using (var memoryStream = new System.IO.MemoryStream(fotoPerfil))
                {
                    var imagen = new BitmapImage();
                    imagen.BeginInit();
                    imagen.CacheOption = BitmapCacheOption.OnLoad;
                    imagen.StreamSource = memoryStream;
                    imagen.EndInit();
                    this.imgFoto.Source = imagen;
                }
            }
        }

        private void btnEditarPerfil_Click(object sender, RoutedEventArgs e)
        {
            RegistrarEmpleador ventanaPerfil = new RegistrarEmpleador(new Modelo.clases.Empleador() /*Enviar datos de y empleador*/);
            ventanaPerfil.ShowDialog();
        }

        private void btnDesactivarPerfil_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnActivarPerfil_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMensajeria_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRegistrarOferta_Click(object sender, RoutedEventArgs e)
        {
            RegistroOfertaEmpleo ventanaRegistroOferta = new RegistroOfertaEmpleo();
            ventanaRegistroOferta.ShowDialog();
            //actualizar tabla
        }

        private void btnConsultarEmpleo_Click(object sender, RoutedEventArgs e)
        {
            ConsultarOfertaEmpleo ventanaConsultarOferta = new ConsultarOfertaEmpleo();
            ventanaConsultarOferta.ShowDialog();
            //actualizar tabla
        }

        private void btnModificarOferta_Click(object sender, RoutedEventArgs e)
        {
            RegistroOfertaEmpleo ventanaActualizarOferta = new RegistroOfertaEmpleo();
            ventanaActualizarOferta.ShowDialog();
            //actualizar tabla
        }

        private void btnConsultarSolicitudes_Click(object sender, RoutedEventArgs e)
        {
            SolcitudesEmpleos ventanaSolicitudes = new SolcitudesEmpleos();
            ventanaSolicitudes.ShowDialog();
          
        }

        private void btnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
