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
    /// <summary>
    /// Lógica de interacción para RegistrarEmpleador.xaml
    /// </summary>
    public partial class RegistrarEmpleador : Window
    {
        private bool nuevoRegistro;
        private Modelo.clases.Empleador perfilEmpleador;

        public RegistrarEmpleador()
        {
            InitializeComponent();
            nuevoRegistro = true;
            perfilEmpleador = new Modelo.clases.Empleador();
        }

        public RegistrarEmpleador(Modelo.clases.Empleador perfilEmpleador) : this()
        {
            nuevoRegistro = false;
            this.perfilEmpleador = perfilEmpleador;
            CargarFormulario();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            if (nuevoRegistro) {
                RegistroPerfil menuRegistrarPerfil = new RegistroPerfil();
                menuRegistrarPerfil.Show();
            }
            this.Close();
        }


        private void CargarFormulario()
        {
            //Preparar fomrulario


            if(!nuevoRegistro)
            {
                //Cargar datos de empleador en formulario
            }
        }
    }
}
