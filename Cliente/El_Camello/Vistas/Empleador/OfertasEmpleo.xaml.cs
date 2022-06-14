using El_Camello.Modelo.interfaz;
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
    public partial class OfertasEmpleo : Window, observadorRespuesta
    {
        Modelo.clases.Empleador empleador = null;

        
        public OfertasEmpleo(Modelo.clases.Usuario usuarioConectado)
        {

            InitializeComponent();
            CargarEmpleador(usuarioConectado);
            
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

        private async void CargarEmpleador(Modelo.clases.Usuario usuarioConectado)
        {
            //demandante = await DemandanteDAO.getDemandante(usuarioConectado.IdPerfilusuario, usuarioConectado.Token);

            /*categorias = await CategoriaDAO.GetCategorias(usuarioConectado.Token);
            cbCategorias.ItemsSource = categorias;
            CargarImagen(usuarioConectado);
            demandante.Clave = usuarioConectado.Clave;
            demandante.CorreoElectronico = usuarioConectado.CorreoElectronico;
            demandante.Estatus = usuarioConectado.Estatus;
            demandante.NombreUsuario = usuarioConectado.NombreUsuario;
            demandante.Fotografia = usuarioConectado.Fotografia;
            demandante.Tipo = usuarioConectado.Tipo;
            demandante.Token = usuarioConectado.Token;
            demandante.IdPerfilusuario = usuarioConectado.IdPerfilusuario;
            aspirantes = await AspiranteDAO.GetAspirantes(demandante.Token);*/
        }

        private void btnEditarPerfil_Click(object sender, RoutedEventArgs e)
        {
            RegistrarEmpleador registrarEmpleador = new RegistrarEmpleador(empleador, this);
            registrarEmpleador.ShowDialog();
        }

        public void actualizarInformacion(Modelo.clases.Usuario usuarioContectado)
        {
            CargarEmpleador(usuarioContectado);
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
