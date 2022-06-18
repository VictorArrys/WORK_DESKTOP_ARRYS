using El_Camello.Modelo.dao;
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

namespace El_Camello.Vistas.Administrador
{
    /// <summary>
    /// Lógica de interacción para ConsultarPerfilEmpleador.xaml
    /// </summary>
    public partial class ConsultarPerfilEmpleador : Window
    {
        Modelo.clases.Empleador empleador = null;
        Modelo.clases.Usuario usuario = null;
        public ConsultarPerfilEmpleador(Modelo.clases.Usuario usuarioSolicitado)
        {
            InitializeComponent();
            empleador = new Modelo.clases.Empleador();
            usuario = new Modelo.clases.Usuario();
            cargarInformacionEmpleador(usuarioSolicitado);
            

        }

        public async void cargarInformacionEmpleador(Modelo.clases.Usuario usuarioSolicitado)
        {
            empleador = await EmpleadorDAO.getEmpleador(usuarioSolicitado.IdPerfilusuario, usuarioSolicitado.Token);
            usuario = await UsuarioDAO.getUsuario(usuarioSolicitado.IdPerfilusuario, usuarioSolicitado.Token);
            cargarImagen(usuario);
            lbNombreEmpleador.Content = empleador.NombreEmpleador;
            tbNombreEmpresa.Text = empleador.NombreOrganizacion;
            tbDireccion.Text = empleador.Direccion;
            dpFechaNacimiento.SelectedDate = empleador.FechaNacimiento;
            tbTelefono.Text = empleador.Telefono;
            tbNombreUsuario.Text = usuario.NombreUsuario;
            tbClave.Text = usuario.Clave;
            tbCorreoElectronico.Text = usuario.CorreoElectronico;
            tbEstatus.Text = usuario.EstatusUsuario;
            tbAmonestaciones.Text = empleador.Amonestaciones.ToString();
        }

        private void cargarImagen(Modelo.clases.Usuario usuario)
        {
            try
            {
                byte[] fotoPerfil = usuario.Fotografia;
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
            }catch (Exception)
            {
                imgFoto.Source = null;
            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
