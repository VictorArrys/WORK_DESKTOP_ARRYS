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

namespace El_Camello.Vistas.Aspirante
{
    /// <summary>
    /// Lógica de interacción para MenuAspirante.xaml
    /// </summary>
    public partial class MenuAspirante : Window, observadorRespuesta
    {
        Modelo.clases.Aspirante perfilAspirante = null;
        Modelo.clases.Usuario usuario = null;
        string token = null;
        public MenuAspirante(Modelo.clases.Usuario usuarioConectado)
        {
            InitializeComponent();
            this.token = usuarioConectado.Token;
            perfilAspirante = new Modelo.clases.Aspirante();
            if (usuarioConectado.Estatus == 1)
            {
                CargarMenuAspirante(usuarioConectado);
            }
            else
            {
                btnEditarPerfil.IsEnabled = false;
                btnDesactivarPerfil.IsEnabled = false;
                btnMensajeria.IsEnabled = false;
                btnSolicitudesEmpleo.IsEnabled = false;
                btnContratacionesServicios.IsEnabled = false;
                btnValoraciones.IsEnabled = false;
                btnMensajeria.IsEnabled = false;
                btnSolicitudesServicio.IsEnabled = false;
                dgOfertasEmpleo.IsEnabled = false;
                

                MessageBox.Show("En este momento esta desactivado tu perfil, para volver acivarlo presiona 'Activar perfil.'", "¡Advetencia!");
                usuario = usuarioConectado;
            }
            
        }

        private async void CargarMenuAspirante(Modelo.clases.Usuario usuarioConectado)
        {
            int idPerfil = usuarioConectado.IdPerfilusuario;
            perfilAspirante = await AspiranteDAO.GetAspirante(idPerfil, token);
            perfilAspirante.Clave = usuarioConectado.Clave;
            perfilAspirante.Estatus = usuarioConectado.Estatus;
            perfilAspirante.IdPerfilusuario = usuarioConectado.IdPerfilusuario;
            perfilAspirante.CorreoElectronico = usuarioConectado.CorreoElectronico;
            perfilAspirante.Fotografia = usuarioConectado.Fotografia;
            perfilAspirante.Tipo = usuarioConectado.Tipo;
            perfilAspirante.Token = usuarioConectado.Token;
            perfilAspirante.NombreUsuario = usuarioConectado.NombreUsuario;
            lbNombreAspirante.Content = "Usuario: " + perfilAspirante.NombreAspirante;



            byte[] fotoPerfil = perfilAspirante.Fotografia;
            if (fotoPerfil != null)
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
            else
            {
                imgFoto.Source = null;
            }
        }



        public void actualizarInformacion(Modelo.clases.Usuario usuarioContectado)
        {
            CargarMenuAspirante(usuarioContectado);
        }

        private void btnMensajeria_Click(object sender, RoutedEventArgs e)
        {
            Mensajeria ventanaMensajeria = new Mensajeria(perfilAspirante);
            ventanaMensajeria.ShowDialog();
        }

        private void btnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            Usuario.Login ventanaLogin = new Usuario.Login();
            ventanaLogin.Show();
            this.Close();
        }

        private void btnEditarPerfil_Click(object sender, RoutedEventArgs e)
        {
            RegistrarAspirante registrarAspirante = new RegistrarAspirante(perfilAspirante, this);
            registrarAspirante.ShowDialog();
        }

        private async void btnDesactivarPerfil_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult opcionSeleccionada = MessageBox.Show("¿Estas seguro de desactivar tu perfil?", "Confirmacion", MessageBoxButton.OKCancel);
            if (opcionSeleccionada == MessageBoxResult.OK)
            {
                MessageBox.Show("Tu perfil se desactivará y no se podra mostrar tus peticiones de servicio, podrás volver actiuvar tu perfil activando el boton 'Activar perfil'", "Advertencia!");
                int resultado = await UsuarioDAO.patchDeshabilitar(perfilAspirante.IdPerfilusuario, token);// por checar
                if (resultado == 1)
                {
                    Login login = new Login();
                    login.Show();
                    this.Close();
                }
            }
        }

        private async void btnActivarPerfil_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult opcionSeleccionada = MessageBox.Show("¿Deseas activar tu perfil?", "Confirmacion", MessageBoxButton.OKCancel);
            if (opcionSeleccionada == MessageBoxResult.OK)
            {
                MessageBox.Show("Tu perfil esta por activarse. Por favor espera un momento'", "Advertencia!");
                int resultado = await UsuarioDAO.patchHabilitar(usuario.IdPerfilusuario, token); // verificar parametros
                if (resultado == 1)
                {
                    btnEditarPerfil.IsEnabled = true;
                    btnDesactivarPerfil.IsEnabled = true;
                    btnMensajeria.IsEnabled = true;
                    btnSolicitudesEmpleo.IsEnabled = true;
                    btnContratacionesServicios.IsEnabled = true;
                    btnValoraciones.IsEnabled = true;
                    btnMensajeria.IsEnabled = true;
                    btnSolicitudesServicio.IsEnabled = true;
                    dgOfertasEmpleo.IsEnabled = true;
                    CargarMenuAspirante(usuario);
                }
            }
        }

        public void actualizarCambios(string operacion)
        {
            throw new NotImplementedException();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BuscarOfertaEmpleo ventanaBuscarOfertaEmpleo = new BuscarOfertaEmpleo(perfilAspirante);
            ventanaBuscarOfertaEmpleo.ShowDialog();
        }


        private void btnSolicitudesServicio_Click(object sender, RoutedEventArgs e)
        {
            SolicitudesServicio ventanaSolicitudes = new SolicitudesServicio(perfilAspirante);
            ventanaSolicitudes.ShowDialog();

        }
    }
}
