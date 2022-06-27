using System.Windows;

namespace El_Camello.Vistas.Aspirante
{
    /// <summary>
    /// Lógica de interacción para ReportarEmpleo.xaml
    /// </summary>
    public partial class ReportarEmpleo : Window
    {
        public ReportarEmpleo()
        {
            InitializeComponent();
        }

        private void btnEnviarReporte_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
