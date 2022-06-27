using El_Camello.Modelo.dao;
using System;
using System.Windows;
using El_Camello.Vistas.Administrador;
using El_Camello.Vistas.Demandante;
using El_Camello.Vistas.Aspirante;
using El_Camello.Vistas.Empleador;
using El_Camello.Configuracion;

namespace El_Camello.Vistas.Usuario
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        Uri fileUri1;
        public Login()
        {

            InitializeComponent();
            Settings.CargarConfiguracion();
        }

        private async void btnIniciarSesion_Click(object sender, RoutedEventArgs e)  // listo en cliente
        {
            
            
            string nombreUsuario = tbNombreUsuario.Text;
            string clave = pbClave.Password;
            if (tbNombreUsuario.Text == "" || pbClave.Password == "")
            {
                MessageBox.Show("Por favor, llenar los campos mostrados", "¡Operacion!");
            }
            else
            {
                Modelo.clases.Usuario usuario = await UsuarioDAO.iniciarSesion(nombreUsuario, clave);
                if (usuario != null)
                {
                    switch (usuario.Tipo)
                    {
                        case "Administrador":
                            MenuAdministrador menuAdministrador = new MenuAdministrador(usuario);
                            menuAdministrador.Show();
                            this.Close();
                            break;
                        case "Aspirante":
                            MenuAspirante menuAspirante = new MenuAspirante(usuario);
                            menuAspirante.Show();
                            this.Close();
                            break;
                        case "Demandante":
                            MenuDemandante menuDemandante = new MenuDemandante(usuario);
                            menuDemandante.Show();
                            this.Close();
                            break;
                        case "Empleador":
                            OfertasEmpleo menuEmpleador = new OfertasEmpleo(usuario);
                            menuEmpleador.Show();
                            this.Close();
                            break;
                    }
                }

            }
        }

        private void btnResgistrarse_Click(object sender, RoutedEventArgs e)
        {
            RegistroPerfil menuRegistro = new RegistroPerfil();
            menuRegistro.Show();
            this.Close();
        }
    }
}
