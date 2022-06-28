using El_Camello.Modelo.dao;
using El_Camello.Modelo.interfaz;
using El_Camello.Vistas.Usuario;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace El_Camello.Vistas.Aspirante
{
    /// <summary>
    /// Lógica de interacción para MenuAspirante.xaml
    /// </summary>
    public partial class MenuAspirante : Window, observadorRespuesta
    {
        Modelo.clases.Aspirante perfilAspirante = null;
        Modelo.clases.Usuario usuario = null;
        public MenuAspirante(Modelo.clases.Usuario usuarioConectado)
        {
            InitializeComponent();
            perfilAspirante = new Modelo.clases.Aspirante();
            if (usuarioConectado.Estatus == 1)
            {
                CargarMenuAspirante(usuarioConectado);
                btnActivarPerfil.IsEnabled = false;
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
            MessageBox.Show(usuarioConectado.Token);
            perfilAspirante = await AspiranteDAO.GetAspirante(idPerfil, usuarioConectado.Token);
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
            Hide();
            ventanaMensajeria.ShowDialog();
            Show();
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
                Tuple<int, string> resultado = await UsuarioDAO.patchDeshabilitar(perfilAspirante.IdPerfilusuario,perfilAspirante.Token);// por checar
                if (resultado.Item1 == 1)
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
                Tuple<int, string> resultado = await UsuarioDAO.patchHabilitar(usuario.IdPerfilusuario, usuario.Token); // verificar parametros
                if (resultado.Item1 == 1)
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
                    btnActivarPerfil.IsEnabled = false;
                    usuario.Token = resultado.Item2;
                    CargarMenuAspirante(usuario);
                }
            }
        }

        public void actualizarCambios(string operacion)
        {
            throw new NotImplementedException();
        }


        private void btnSolicitudesServicio_Click(object sender, RoutedEventArgs e)
        {
            SolicitudesServicio ventanaSolicitudes = new SolicitudesServicio(perfilAspirante);
            this.Hide();
            ventanaSolicitudes.ShowDialog();

            this.Show();
        }

        private void btnContrataciones_Click(object sender, RoutedEventArgs e)
        {
            ConsultarContrataciones ventanaContratacion = new ConsultarContrataciones(perfilAspirante);
            Hide();
            ventanaContratacion.ShowDialog();
            Show();
        }

        private void btnSolicitudesEmpleo_Click(object sender, RoutedEventArgs e)
        {
            BuscarOfertaEmpleo ventanaBuscarOfertaEmpleo = new BuscarOfertaEmpleo(perfilAspirante);
            Hide();
            ventanaBuscarOfertaEmpleo.ShowDialog();
            Show();
        }
    }
}
