using El_Camello.Modelo.dao;
using System;
using System.Windows;
using El_Camello.Vistas.Administrador;
using El_Camello.Vistas.Demandante;
using El_Camello.Vistas.Aspirante;
using El_Camello.Vistas.Empleador;
using El_Camello.Configuracion;
using El_Camello.Assets.utilerias;

namespace El_Camello.Vistas.Usuario
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            Settings.CargarConfiguracion();
        }

        private async void btnIniciarSesion_Click(object sender, RoutedEventArgs e)  // listo en cliente
        {
            MensajesSistema mensajes;
            string nombreUsuario = tbNombreUsuario.Text;
            string clave = pbClave.Password;
            if (tbNombreUsuario.Text == "" || pbClave.Password == "")
            {
                mensajes = new MensajesSistema("AccionInvalida", "Por favor, llena los campos mostrados", "Iniciar sesión", "Se requieren ambos campos");
                mensajes.ShowDialog();
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
