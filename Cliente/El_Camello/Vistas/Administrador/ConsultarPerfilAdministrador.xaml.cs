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
    
    public partial class ConsultarPerfilAdministrador : Window
    {
        Modelo.clases.Administrador administrador = null;
        public ConsultarPerfilAdministrador(Modelo.clases.Usuario usuarioAdministrador)
        {
            InitializeComponent();
            administrador = new Modelo.clases.Administrador();
            cargarInformacionAdministrador(usuarioAdministrador);
        }

        private async void cargarInformacionAdministrador(Modelo.clases.Usuario usuario)
        {
            administrador = await AdministradorDAO.getAdministrador(usuario.IdPerfilusuario, usuario.Token);
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
