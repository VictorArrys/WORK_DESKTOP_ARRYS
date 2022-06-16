using El_Camello.Modelo.dao;
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

namespace El_Camello.Vistas.Demandante
{
    /// <summary>
    /// Lógica de interacción para MenuDemandante.xaml
    /// </summary>
    public partial class MenuDemandante : Window, observadorRespuesta
    {
        Modelo.clases.Demandante demandante = null;
        List<Modelo.clases.Aspirante> aspirantes = new List<Modelo.clases.Aspirante>();
        List<Modelo.clases.Categoria> categorias = new List<Modelo.clases.Categoria>();
        public MenuDemandante(Modelo.clases.Usuario usuarioConectado)
        {
            InitializeComponent();
            demandante = new Modelo.clases.Demandante();
            cargarDemandante(usuarioConectado);
        }

        private void CargarImagen(Modelo.clases.Usuario usuarioConectado)
        {
            try
            {
                byte[] fotoPerfil = usuarioConectado.Fotografia;
                if (fotoPerfil == null)
                {
                    fotoPerfil = null;
                }
                else if (fotoPerfil.Length > 0)
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

        private async void cargarDemandante(Modelo.clases.Usuario usuarioConectado)
        {
            
            demandante = await DemandanteDAO.getDemandante(usuarioConectado.IdPerfilusuario, usuarioConectado.Token);
            
            //categorias = await CategoriaDAO.GetCategorias();
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
            aspirantes = await AspiranteDAO.GetAspirantes(demandante.Token);

            dgAspirantes.ItemsSource = aspirantes;

        }

        private void btnEditarPerfil_Click(object sender, RoutedEventArgs e)
        {
            RegistrarDemandante registrarDemandante = new RegistrarDemandante(demandante, this);
            registrarDemandante.ShowDialog();
        }

        public void actualizarInformacion(Modelo.clases.Usuario usuarioContectado)
        {
            cargarDemandante(usuarioContectado);
        }

        private void btnDesactivar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult opcionSeleccionada = MessageBox.Show("¿Estas seguro de desactivar tu perfil?", "Confirmacion", MessageBoxButton.OKCancel);
            if (opcionSeleccionada == MessageBoxResult.OK)
            {
                MessageBox.Show("Tu perfil se desactivará y no se podra mostrar tus peticiones de servicio, podrás volver actiuvar tu perfil activando el boton 'Activar perfil'", "Advertencia!");

            }
            else
            {
                Console.WriteLine("no pasa nada");
            }
        }

        private void btnConsultarSolicitudes_Click(object sender, RoutedEventArgs e)
        {
            //pasar usuario
            ConsultarSolicitudServicio consultarSolicitudServicio = new ConsultarSolicitudServicio();
            consultarSolicitudServicio.Show();
            this.Close();
        }

        private void btnConsultarValoraciones_Click(object sender, RoutedEventArgs e)
        {
            //Eduardo
        }

        private void btnMensajeria_Click(object sender, RoutedEventArgs e)
        {
            //eduardo
        }

        private void cambioCategoria(object sender, SelectionChangedEventArgs e)
        {
            int seleccion = cbCategorias.SelectedIndex;
            MessageBox.Show(categorias[seleccion].ToString());
           
        }
    }
}
