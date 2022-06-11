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
    /// <summary> THE THUNDER PANDAS FOREVER
    /// Lógica de interacción para restablecerContraseña.xaml
    /// </summary>
    public partial class RestablecerContraseña : Window
    {
        public RestablecerContraseña()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Login ventanaLogin = new Login();
            ventanaLogin.Show();
            this.Close();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
