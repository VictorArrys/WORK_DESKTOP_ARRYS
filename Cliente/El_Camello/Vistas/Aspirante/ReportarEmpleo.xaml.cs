using System.Windows;

namespace El_Camello.Vistas.Aspirante
{
    /// <summary>
    /// Lógica de interacción para ReportarEmpleo.xaml
    /// </summary>
    public partial class ReportarEmpleo : Window
    {
        private Modelo.clases.Aspirante aspirante;
        private Modelo.clases.ContratacionEmpleo contrtacion;
        public ReportarEmpleo(Modelo.clases.Aspirante aspirante, Modelo.clases.ContratacionEmpleo contratacion)
        {
            InitializeComponent();
            this.aspirante = aspirante;
            this.contrtacion = contratacion;
        }

        private async void btnEnviarReporte_Click(object sender, RoutedEventArgs e)
        {
            if (txtDescripcion.Text.Length > 0 )
            {
                Modelo.clases.ReporteEmpleo nuevoReporte = new Modelo.clases.ReporteEmpleo();
                nuevoReporte.Motivo = txtDescripcion.Text;
                nuevoReporte.IdAspirante = aspirante.IdAspirante;
                Modelo.clases.ReporteEmpleo reporteRegistrado = await Modelo.dao.ReporteEmpleoDAO.PostReporteEmpleo(nuevoReporte, contrtacion.IdContratacion, aspirante.Token);
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
