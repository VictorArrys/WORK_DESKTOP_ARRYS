using System.Windows;

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
