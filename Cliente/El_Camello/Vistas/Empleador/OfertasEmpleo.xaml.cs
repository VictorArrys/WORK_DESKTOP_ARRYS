using El_Camello.Modelo.interfaz;
using El_Camello.Assets.utilerias;
using El_Camello.Modelo.clases;
using El_Camello.Modelo.dao;
using El_Camello.Vistas.Usuario;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;

namespace El_Camello.Vistas.Empleador 
{
    /// <summary>
    /// Interaction logic for OfertasEmpleo.xaml
    /// </summary>
    public partial class OfertasEmpleo : Window, observadorRespuesta
    {
        private int idPerfilEmpleador;
        List<OfertaEmpleo> ofertasTabla = new List<OfertaEmpleo>();
        Modelo.clases.Empleador empleador = null;
        Modelo.clases.Usuario usuario = null;
        MensajesSistema error;

        public OfertasEmpleo(Modelo.clases.Usuario usuarioConectado)
        {

            InitializeComponent();
            if (usuarioConectado.Estatus == 1)
            {
                cargarInformacionUsuario(usuarioConectado);
                usuario = usuarioConectado;
                
            }
            else
            {
                btnEditarPerfil.IsEnabled = false;
                btnDesactivarPerfil.IsEnabled = false;
                btnMensajeria.IsEnabled = false;
                btnRegistrarOferta.IsEnabled = false;
                btnConsultarEmpleo.IsEnabled = false;
                btnConsultarEmpleo.IsEnabled = false;
                btnConsultarSolicitudes.IsEnabled = false;
                btnRegistrarOferta.IsEnabled = false;
                btnModificarOferta.IsEnabled = false;

                MessageBox.Show("En este momento esta desactivado tu perfil, para volver acivarlo presiona 'Activar perfil.'", "¡Advetencia!");
                usuario = usuarioConectado;

            }
            
            
        }

        private async void CargarOfertasTabla(String token)
        {
            //aqui pasar el token que viene desde el inicio de seción
            try
            {
                ofertasTabla = await OfertaEmpleoDAO.GetOfertasEmpleos(idPerfilEmpleador, token);
                if (ofertasTabla.Count == 0)
                {

                }
                else
                {
                    dgOfertasEmpleo.ItemsSource = ofertasTabla;
                }
            }
            catch (Exception exceptionGetList)
            {
                error = new MensajesSistema("Error", "Hubo un error al intentar cargar las ofertas de empleo, favor de intentar más tarde", exceptionGetList.StackTrace, exceptionGetList.Message);
                error.ShowDialog();
            }
        }

        private void cargarInformacionUsuario(Modelo.clases.Usuario usuarioConectado)
        {
            lbUsuario.Content = "Usuario: " + usuarioConectado.NombreUsuario;
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
            empleador = await EmpleadorDAO.getEmpleador(usuarioConectado.IdPerfilusuario, usuarioConectado.Token);
            CargarImagen(usuarioConectado);

           
            empleador.Clave = usuarioConectado.Clave;
            empleador.CorreoElectronico = usuarioConectado.CorreoElectronico;
            empleador.Estatus = usuarioConectado.Estatus;
            empleador.NombreUsuario = usuarioConectado.NombreUsuario;
            empleador.Fotografia = usuarioConectado.Fotografia;
            empleador.Tipo = usuarioConectado.Tipo;
            empleador.Token = usuarioConectado.Token;
            empleador.IdPerfilusuario = usuarioConectado.IdPerfilusuario;
            lbNombre.Content = "Nombre: " + empleador.NombreEmpleador;
            
            idPerfilEmpleador = empleador.IdPerfilEmpleador;

            CargarOfertasTabla(usuarioConectado.Token);
            btnActivarPerfil.IsEnabled = false;
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

        private async void btnDesactivarPerfil_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult opcionSeleccionada = MessageBox.Show("¿Estas seguro de desactivar tu perfil?", "Confirmacion", MessageBoxButton.OKCancel);
            if (opcionSeleccionada == MessageBoxResult.OK)
            {
                MessageBox.Show("Tu perfil se desactivará y no se podra mostrar tus peticiones de servicio, podrás volver actiuvar tu perfil activando el boton 'Activar perfil'", "Advertencia!");
                Tuple<int, string> resultado = await UsuarioDAO.patchDeshabilitar(empleador.IdPerfilusuario, empleador.Token);
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
                Tuple<int, string> resultado = await UsuarioDAO.patchHabilitar(usuario.IdPerfilusuario, usuario.Token);
                if (resultado.Item1 == 1)
                {

                    btnEditarPerfil.IsEnabled = true;
                    btnDesactivarPerfil.IsEnabled = true;
                    btnMensajeria.IsEnabled = true;
                    btnRegistrarOferta.IsEnabled = true;
                    btnConsultarEmpleo.IsEnabled = true;
                    btnConsultarEmpleo.IsEnabled = true;
                    btnConsultarSolicitudes.IsEnabled = true;
                    btnRegistrarOferta.IsEnabled = true;
                    btnModificarOferta.IsEnabled = true;
                    usuario.Token = resultado.Item2;
                    cargarInformacionUsuario(usuario);
                    CargarOfertasTabla(usuario.Token);
                }
            }
        }

        private void btnMensajeria_Click(object sender, RoutedEventArgs e)
        {
            Mensajeria ventanaMensajeria = new Mensajeria(empleador);
            ventanaMensajeria.ShowDialog();
        }

        private void btnRegistrarOferta_Click(object sender, RoutedEventArgs e)
        {
            RegistroOfertaEmpleo ventanaRegistroOferta = new RegistroOfertaEmpleo(this,idPerfilEmpleador, usuario.Token);
            ventanaRegistroOferta.ShowDialog();
            //actualizar tabla
        }

        private void btnConsultarEmpleo_Click(object sender, RoutedEventArgs e)
        {
            int indiceSeleccion = dgOfertasEmpleo.SelectedIndex;

            if (indiceSeleccion >= 0)
            {
                OfertaEmpleo ofertaEmpleoConsultar = ofertasTabla[indiceSeleccion];

                ConsultarOfertaEmpleo ventanaConsultarOferta = new ConsultarOfertaEmpleo(ofertaEmpleoConsultar.IdOfertaEmpleo, usuario.Token);
                ventanaConsultarOferta.ShowDialog();
            }
            else
            {
                error = new MensajesSistema("AccionInvalida", "La acción que ha realizado es invalida", "Intento de consultar oferta de empleo", "Selecciona una oferta de empleo para poder consultarla posteriormente");
                error.ShowDialog();
            }
        }

        private void btnModificarOferta_Click(object sender, RoutedEventArgs e)
        {
            int indiceSeleccion = dgOfertasEmpleo.SelectedIndex;

            if (indiceSeleccion >= 0)
            {
                OfertaEmpleo ofertaEmpleoEditar = ofertasTabla[indiceSeleccion];


                RegistroOfertaEmpleo ventanaActualizarOferta = new RegistroOfertaEmpleo(this, idPerfilEmpleador, ofertaEmpleoEditar.IdOfertaEmpleo, usuario.Token);
                ventanaActualizarOferta.ShowDialog();

            }
            else
            {
                error = new MensajesSistema("AccionInvalida", "La acción que ha realizado es invalida", "Intento de modificar oferta de empleo", "Selecciona una oferta de empleo para poder editarla posteriormente");
                error.ShowDialog();
            }

            
        }

        private void btnConsultarSolicitudes_Click(object sender, RoutedEventArgs e)
        {
            int indiceSeleccion = dgOfertasEmpleo.SelectedIndex;

            if (indiceSeleccion >= 0)
            {
                OfertaEmpleo ofertaEmpleoEditar = ofertasTabla[indiceSeleccion];

                SolcitudesEmpleos ventanaSolicitudes = new SolcitudesEmpleos(usuario.Token, ofertaEmpleoEditar.IdOfertaEmpleo, ofertaEmpleoEditar.Vacantes);
                ventanaSolicitudes.ShowDialog();
            }
            else
            {
                error = new MensajesSistema("AccionInvalida", "La acción que ha realizado es invalida", "Intento de consultar solicitudes", "Selecciona una oferta de empleo para poder consultarla posteriormente");
                error.ShowDialog();
            }

        }

        private void btnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            Usuario.Login ventanaLogin = new Usuario.Login();
            ventanaLogin.Show();
            this.Close();
        }

        public void actualizarCambios(string operacion)
        {
            switch (operacion)
            {
                case "Registrar oferta empleo":
                    ofertasTabla.Clear();
                    CargarOfertasTabla(usuario.Token);
                    break;
                case "Actualizar oferta empleo":
                    ofertasTabla.Clear();
                    CargarOfertasTabla(usuario.Token);
                    break;
            };
        }
    }
}
