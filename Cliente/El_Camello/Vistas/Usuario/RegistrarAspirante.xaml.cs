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
    /// Lógica de interacción para RegistrarAspirante.xaml
    /// </summary>
    public partial class RegistrarAspirante : Window
    {
        public RegistrarAspirante()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            RegistroPerfil menuRegistro = new RegistroPerfil();
            menuRegistro.Show();
            this.Close();
        }
    }
}
