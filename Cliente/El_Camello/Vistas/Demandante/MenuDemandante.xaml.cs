using El_Camello.Modelo.dao;
using El_Camello.Modelo.interfaz;
using El_Camello.Vistas.Usuario;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace El_Camello.Vistas.Demandante
{
    
    public partial class MenuDemandante : Window, observadorRespuesta
    {
        Modelo.clases.Demandante demandante = null;
        Modelo.clases.Usuario usuario = null;
        List<Modelo.clases.Aspirante> aspirantes = new List<Modelo.clases.Aspirante>();
        List<Modelo.clases.Categoria> categorias = new List<Modelo.clases.Categoria>();
        


        public MenuDemandante(Modelo.clases.Usuario usuarioConectado)
        {
            InitializeComponent();
            if (usuarioConectado.Estatus == 1)
            {
                demandante = new Modelo.clases.Demandante();
                CargarPerfilDemandante(usuarioConectado);
                btnActivarPerfil.IsEnabled = false;
                usuario = usuarioConectado;
            }
            else
            {
                btnActivarPerfil.IsEnabled = true;
                btnConsultarSolicitudes.IsEnabled = false;
                btnConsultarValoraciones.IsEnabled = false;
                btnConsultarValoraciones.IsEnabled = false;
                btnMensajeria.IsEnabled = false;
                btnDesactivar.IsEnabled = false;
                btnEditarPerfil.IsEnabled = false;
                MessageBox.Show("En este momento esta desactivado tu perfil, para volver acivarlo presiona 'Activar perfil.'", "¡Advetencia!");
                usuario = usuarioConectado;
            }
            
        }

        private void CargarImagen(byte[] bytesFotografia)
        {
            try
            {
                if (bytesFotografia != null)
                {
                    using (var memoryStream = new System.IO.MemoryStream(bytesFotografia))
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

        /// <summary>
        /// Al iniciar sesión se consultan los datos faltantes de demandante.
        /// </summary>
        /// <param name="usuarioConectado"></param>
        private async void CargarPerfilDemandante(Modelo.clases.Usuario usuarioConectado)
        {
            demandante = await DemandanteDAO.getDemandante(usuarioConectado.IdPerfilusuario, usuarioConectado.Token);
            demandante.Clave = usuarioConectado.Clave;
            demandante.CorreoElectronico = usuarioConectado.CorreoElectronico;
            demandante.Estatus = usuarioConectado.Estatus;
            demandante.NombreUsuario = usuarioConectado.NombreUsuario;
            demandante.Fotografia = usuarioConectado.Fotografia;
            demandante.Tipo = usuarioConectado.Tipo;
            demandante.Token = usuarioConectado.Token;
            demandante.IdPerfilusuario = usuarioConectado.IdPerfilusuario;
            CargarImagen(demandante.Fotografia);

            categorias = await CategoriaDAO.GetCategorias();
            cbCategorias.ItemsSource = categorias;
            aspirantes = await AspiranteDAO.GetAspirantes(demandante.Token);
            lbNombreDemandante.Content = "Usuario:" + demandante.NombreDemandante;
            dgAspirantes.ItemsSource = aspirantes;

        }
       

        private void btnEditarPerfil_Click(object sender, RoutedEventArgs e)
        {
            RegistrarDemandante registrarDemandante = new RegistrarDemandante(demandante, this);
            registrarDemandante.ShowDialog();
        }

        public void actualizarInformacion(Modelo.clases.Usuario usuarioContectado)
        {
            CargarPerfilDemandante(usuarioContectado);
        }

        private async void btnDesactivar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult opcionSeleccionada = MessageBox.Show("¿Estas seguro de desactivar tu perfil?", "Confirmacion", MessageBoxButton.OKCancel);
            if (opcionSeleccionada == MessageBoxResult.OK)
            {
                MessageBox.Show("Tu perfil se desactivará y no se podra mostrar tus peticiones de servicio, podrás volver actiuvar tu perfil activando el boton 'Activar perfil'", "Advertencia!");
                Tuple<int, string> resultado = await UsuarioDAO.patchDeshabilitar(demandante.IdPerfilusuario, demandante.Token);
                if (resultado.Item1 == 1)
                {
                    Login login = new Login();
                    login.Show();
                    this.Close();
                }
            }
            else
            {
                Console.WriteLine("no pasa nada");
            }
        }

        private void btnConsultarSolicitudes_Click(object sender, RoutedEventArgs e)
        {
            ConsultarSolicitudServicio consultarSolicitudServicio = new ConsultarSolicitudServicio(demandante);
            this.Hide();
            consultarSolicitudServicio.ShowDialog();
            this.Show();
            
        }

        private void btnConsultarValoraciones_Click(object sender, RoutedEventArgs e)
        {
            //Eduardo
        }

        private void btnMensajeria_Click(object sender, RoutedEventArgs e)
        {
            Mensajeria ventanaMensajeria = new Mensajeria(demandante);
            Hide();
            ventanaMensajeria.ShowDialog();
            Show();
        }

        

        private void cambioCategoria(object sender, SelectionChangedEventArgs e)
        {
            int seleccion = cbCategorias.SelectedIndex;
            //MessageBox.Show(categorias[seleccion].ToString());
           
        }

        private void btnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            new Login().Show();
            this.Close();
        } 
           
        public void actualizarCambios(string operacion)
        {
            throw new NotImplementedException();
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
                    btnActivarPerfil.IsEnabled = false;
                    btnConsultarSolicitudes.IsEnabled = true;
                    btnConsultarValoraciones.IsEnabled = true;
                    btnConsultarValoraciones.IsEnabled = true;
                    btnMensajeria.IsEnabled = true;
                    btnDesactivar.IsEnabled = true;
                    btnEditarPerfil.IsEnabled = true;
                    usuario.Token = resultado.Item2;
                    CargarPerfilDemandante(usuario);
                }
            }

        }
    }
}
