using System.Windows;

namespace El_Camello.Vistas.Demandante
{
    /// <summary>
    /// Lógica de interacción para ConsultarSolicitudServicio.xaml
    /// </summary>
    public partial class ConsultarSolicitudServicio : Window
    {
        
        Modelo.clases.Demandante demandante;
        public ConsultarSolicitudServicio(Modelo.clases.Demandante demandante)
        {
            InitializeComponent();
            this.demandante = demandante; 
            cargarTablaServicios(demandante.IdPerfilusuario);
        }

        private async void cargarTablaServicios(int idUsuario)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
