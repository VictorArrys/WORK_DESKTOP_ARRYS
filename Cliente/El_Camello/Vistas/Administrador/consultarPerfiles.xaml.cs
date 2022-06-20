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
    
    public partial class consultarPerfiles : Page
    {
        List<Modelo.clases.Usuario> usuarios = null;
        List<Modelo.clases.Usuario> usuariosAdministradores = null;
        List<Modelo.clases.Usuario> usuariosEmpleadores = null;
        List<Modelo.clases.Usuario> usuariosDemandantes = null;
        List<Modelo.clases.Usuario> usuariosAspirantes = null;
        Modelo.clases.Usuario usuarioSeleccionado = null;
        String token = null;
        public consultarPerfiles(Modelo.clases.Administrador administrador) // verificar que pase el token y crear pantallas para cada usuario
        {
            InitializeComponent();
            usuariosAdministradores = new List<Modelo.clases.Usuario>();
            usuariosEmpleadores = new List<Modelo.clases.Usuario>();
            usuariosDemandantes = new List<Modelo.clases.Usuario>();
            usuariosAspirantes = new List<Modelo.clases.Usuario>();
            usuarioSeleccionado = new Modelo.clases.Usuario();
            usuarios = new List<Modelo.clases.Usuario>();
            this.token = administrador.Token;
            cargarUsuarios(token);
            dgUsuarios.AutoGenerateColumns = false;
        }


        private async void cargarUsuarios(string token)
        {
            usuarios = await UsuarioDAO.getUsuarios(token);
            cargarListasUsuarios(usuarios);
        }

        private void cargarListasUsuarios(List<Modelo.clases.Usuario> usuarios)
        {
            
            for (int i = 0; i < usuarios.Count; i++)
            {

                string tipo = usuarios[i].Tipo;
                if (tipo != null)
                {
                    tipo.ToLower();
                    switch (tipo)
                    {
                        case "Administrador":
                            usuariosAdministradores.Add(usuarios[i]);
                            break;
                        case "Empleador":
                            usuariosEmpleadores.Add(usuarios[i]);
                            break;
                        case "Demandante":
                            usuariosDemandantes.Add(usuarios[i]);
                            break;
                        case "Aspirante":
                            usuariosAspirantes.Add(usuarios[i]);
                            break;
                    }
                } 
            }
            
        }

        private void btnAdministradores_Click(object sender, RoutedEventArgs e)
        {
            dgUsuarios.ItemsSource = null;
            dgUsuarios.ItemsSource = usuariosAdministradores;
        }

        private void btnAspirantes_Click(object sender, RoutedEventArgs e)
        {
            dgUsuarios.ItemsSource = null;
            dgUsuarios.ItemsSource = usuariosAspirantes;
        }

        private void btnDemandantes_Click(object sender, RoutedEventArgs e)
        {

            dgUsuarios.ItemsSource = null;
            dgUsuarios.ItemsSource = usuariosDemandantes;
        }

        private void btnEmpleadores_Click(object sender, RoutedEventArgs e)
        {
            dgUsuarios.ItemsSource = null;
            dgUsuarios.ItemsSource = usuariosEmpleadores;
        }

        private void dgSeleccionUsuario(object sender, SelectionChangedEventArgs e)
        {

            if (dgUsuarios.SelectedIndex > -1)
            {
                usuarioSeleccionado = (Modelo.clases.Usuario)dgUsuarios.SelectedItem;
                string tipo = usuarioSeleccionado.Tipo;
                usuarioSeleccionado.Token = token;

                switch (tipo)
                {
                    
                    case "Administrador":
                        ConsultarPerfilAdministrador consultarPerfilAdministrador = new ConsultarPerfilAdministrador(usuarioSeleccionado);
                        consultarPerfilAdministrador.ShowDialog();
                        break;
                    case "Empleador":
                        ConsultarPerfilEmpleador consultarPerfilEmpleador = new ConsultarPerfilEmpleador(usuarioSeleccionado);
                        consultarPerfilEmpleador.ShowDialog();
                        break;
                    case "Demandante":
                        ConsultarPerfilDemandante consultarPerfilDemandante = new ConsultarPerfilDemandante(usuarioSeleccionado);
                        consultarPerfilDemandante.ShowDialog();
                        break;
                    case "Aspirante":
                        break;
                }
            }
           

        }
    }
}
