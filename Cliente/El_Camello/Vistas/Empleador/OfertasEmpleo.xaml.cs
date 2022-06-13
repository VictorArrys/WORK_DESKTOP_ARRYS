using El_Camello.Modelo.clases;
using El_Camello.Modelo.dao;
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
        private int idPerfilEmpleador;
        private string token;
        public OfertasEmpleo(Modelo.clases.Usuario usuarioConectado, int idPerfilEmpleador)
        {
            this.idPerfilEmpleador = idPerfilEmpleador;
            this.token = usuarioConectado.Token;
            InitializeComponent();
            CargarOfertasTabla();
            
        }

        private async void CargarOfertasTabla()
        {
            List<OfertaEmpleo> ofertasTabla = new List<OfertaEmpleo>();
            //aqui pasar el token que viene desde el inicio de seción
            try
            {
                ofertasTabla = await OfertaEmpleoDAO.GetOfertasEmpleos(idPerfilEmpleador);

                dgOfertasEmpleo.ItemsSource = ofertasTabla;
            }
            catch (Exception exceptionGetList)
            {
                MessageBox.Show("Error debido a: " + exceptionGetList.Message);
            }
        }


        private void CargarImagen(Modelo.clases.Usuario usuarioConectado)
        {

            try
            {
                byte[] fotoPerfil = usuarioConectado.Fotografia;
                if (fotoPerfil == null)
                {
                    fotoPerfil = null;
                }else if (fotoPerfil.Length > 0)
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
            catch (Exception)
            {
                imgFoto.Source = null;
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
            RegistroOfertaEmpleo ventanaRegistroOferta = new RegistroOfertaEmpleo(idPerfilEmpleador, token);
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
            RegistroOfertaEmpleo ventanaActualizarOferta = new RegistroOfertaEmpleo(idPerfilEmpleador, token);
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
