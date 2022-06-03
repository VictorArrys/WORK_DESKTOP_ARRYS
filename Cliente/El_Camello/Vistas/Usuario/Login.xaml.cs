using El_Camello.Modelo.dao;
using El_Camello.Modelo.clases;
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
using El_Camello.Vistas.Administrador;
using El_Camello.Vistas.Demandante;
using El_Camello.Vistas.Aspirante;
using El_Camello.Empleador;
using El_Camello.Vistas.Empleador;

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
        }

        private async void btnIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            string nombreUsuario = txtNombreUsuario.Text;
            string clave = pwdClave.Password;
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
                        break;
                }
            }
        }

        private void btnRestablcerClave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
