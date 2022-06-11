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

namespace El_Camello.Vistas.Usuario
{
    /// <summary> ¿Has oido hablar del manco de día y cojo de noche?
    /// Lógica de interacción para RegistroPerfil.xaml
    /// </summary>
    public partial class RegistroPerfil : Window
    {
        public RegistroPerfil()
        {
            InitializeComponent();
            CargarPantalla();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string tipoUsuario = cbxTipoUsuario.SelectedValue.ToString();
            switch (tipoUsuario)
            {
                case "Empleador":
                    RegistrarEmpleador ventanaRegistroEmp = new RegistrarEmpleador();
                    ventanaRegistroEmp.Show();
                    this.Close();
                    break;
                case "Aspirante":
                    RegistrarAspirante ventanaRegistroAsp = new RegistrarAspirante();
                    ventanaRegistroAsp.Show();
                    this.Close();
                    break;
                case "Demandante":
                    RegistrarDemandante ventanaRegistroDem = new RegistrarDemandante();
                    ventanaRegistroDem.Show();
                    this.Close();
                    break;
            }
            
        }

        private void CargarPantalla()
        {
            cbxTipoUsuario.Items.Clear();
            cbxTipoUsuario.Items.Add("Empleador");
            cbxTipoUsuario.Items.Add("Demandante");
            cbxTipoUsuario.Items.Add("Aspirante");
            cbxTipoUsuario.SelectedIndex = 0;
        }
    }
}
