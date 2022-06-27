using El_Camello.Modelo.dao;
using System.Windows;

namespace El_Camello.Vistas.Administrador
{
    
    public partial class ConsultarPerfilAdministrador : Window
    {
        Modelo.clases.Administrador administrador = null;
        string token = null;
        public ConsultarPerfilAdministrador(Modelo.clases.Usuario usuarioAdministrador, string token)
        {
            InitializeComponent();
            administrador = new Modelo.clases.Administrador();
            this.token = token;
            cargarInformacionAdministrador(usuarioAdministrador);
        }

        private async void cargarInformacionAdministrador(Modelo.clases.Usuario usuario)
        {
            administrador = await AdministradorDAO.getAdministrador(usuario.IdPerfilusuario, token);
            administrador.NombreUsuario = usuario.NombreUsuario;
            administrador.Clave = usuario.Clave;
            administrador.CorreoElectronico = usuario.CorreoElectronico;
            administrador.Estatus = usuario.Estatus;

            lbNombreAdministrador.Content = administrador.Nombre;
            tbNombreUsuario.Text = administrador.NombreUsuario;
            tbClave.Text = administrador.Clave;
            tbCorreoElectronico.Text = administrador.CorreoElectronico;
            tbTelefono.Text = administrador.Telefono;
            tbEstatus.Text = administrador.EstatusUsuario;
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
