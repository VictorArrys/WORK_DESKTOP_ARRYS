using El_Camello.Modelo.dao;
using System.Windows;

namespace El_Camello.Vistas.Administrador
{
    /// <summary>
    /// Lógica de interacción para PerfilAdministrador.xaml
    /// </summary>
    public partial class PerfilAdministrador : Window
    {
        Modelo.clases.Administrador modificarAdministrador = null;
        string token;
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
            modificarAdministrador.Nombre = administrador.Nombre;
            modificarAdministrador.Telefono = administrador.Telefono;
            modificarAdministrador.NombreUsuario = administrador.NombreUsuario;
            modificarAdministrador.Clave = administrador.Clave;
            modificarAdministrador.CorreoElectronico = administrador.CorreoElectronico;
            token = modificarAdministrador.Token;

            tbNombre.Text = administrador.Nombre;
            tbTelefono.Text = administrador.Telefono;
            tbNombreUsuario.Text = administrador.NombreUsuario;
            pbContraseña.Password = administrador.Clave;
            pbConfirmarContraseña.Password = administrador.Clave;
            tbCorreoElectronico.Text = administrador.CorreoElectronico;

        }

        private async void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (validaCampos())
            {
                modificarAdministrador.Nombre = tbNombre.Text;
                modificarAdministrador.Telefono = tbTelefono.Text;
                modificarAdministrador.NombreUsuario = tbNombreUsuario.Text;
                modificarAdministrador.Clave = pbContraseña.Password;
                modificarAdministrador.CorreoElectronico = tbCorreoElectronico.Text;

                int resultado = await AdministradorDAO.putAdministrador(modificarAdministrador);
                if (resultado == 1)
                {
                    MessageBox.Show("Actualización de tus datos realizados con éxito", "¡Operación!");

                    this.Close();
                    

                }
                else
                {
                    MessageBox.Show("La actualizacion de tu perfil no se llevo a cabo, intenta mas tarde","¡Operacion!");
                }
            }
            else
            {
                MessageBox.Show("Al actualizar verifica que los campos no esten vacios o sin modificar", "¡Operación!");
            }
        }

        /*private async void cargarAdministradorActualizado(int idUsuario,string token)
        {
            modificarAdministrador = null;
            modificarAdministrador = await AdministradorDAO.getAdministrador(idUsuario, token);
        }*/

        private bool validaCampos()
        {
            bool validar = false;
            if (tbNombre.Text == "")
            {
                validar = false;
            }else if (tbTelefono.Text == "")
            {
                validar = false;
            }
            else if (tbNombreUsuario.Text == "")
            {
                validar = false;

            }else if (pbContraseña.Password != "" || pbConfirmarContraseña.Password != "")
            {
                if (pbContraseña.Password != pbConfirmarContraseña.Password)
                {
                    MessageBox.Show("Por favor introducir la misma contraseña en ambos campos para confirmar","¡Operacion!");
                    validar = false;
                }else if (tbCorreoElectronico.Text == "")
                {
                    validar = false;
                }
                else
                {
                    if (modificarAdministrador.Nombre == tbNombre.Text && modificarAdministrador.Telefono == tbTelefono.Text && modificarAdministrador.NombreUsuario == tbNombreUsuario.Text
                        && modificarAdministrador.Clave == pbContraseña.Password && modificarAdministrador.CorreoElectronico == tbCorreoElectronico.Text)
                    {
                        MessageBox.Show("Para poder modificar tu registro es necesario almenos modificar un campo.", "¡Operacion!");
                    }
                    else
                    {
                        validar = true;
                    }
                }
            }

            return validar;
        }
    }
}
