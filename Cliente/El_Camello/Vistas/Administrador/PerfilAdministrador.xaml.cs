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
    /// Lógica de interacción para PerfilAdministrador.xaml
    /// </summary>
    public partial class PerfilAdministrador : Window
    {
        Modelo.clases.Administrador modificarAdministrador = null;
        public PerfilAdministrador(Modelo.clases.Administrador administrador)
        {
            InitializeComponent();
            modificarAdministrador = new Modelo.clases.Administrador();
            cargarInformacionAdministrador(administrador);
        }

        private void cargarInformacionAdministrador(Modelo.clases.Administrador administrador)
        {
            modificarAdministrador.IdPerfilAdministrador = administrador.IdPerfilAdministrador;
            modificarAdministrador.IdPerfilusuario = administrador.IdPerfilusuario;
            modificarAdministrador.Estatus = administrador.Estatus;
            modificarAdministrador.Token = administrador.Token;
            tbNombre.Text = administrador.Nombre;
            tbTelefono.Text = administrador.Telefono;
            tbNombreUsuario.Text = administrador.NombreUsuario;
            pbContraseña.Password = administrador.Clave;
            pbConfirmarContraseña.Password = administrador.Clave;
            tbCorreoElectronico.Text = administrador.CorreoElectronico;

        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            // mandar a llamar el dao
        }
    }
}
