using El_Camello.Modelo.clases;
using El_Camello.Modelo.dao;
using System.Windows;

namespace El_Camello.Vistas.Demandante
{
    /// <summary>
    /// Lógica de interacción para EvaluarServicioAspirante.xaml
    /// </summary>
    public partial class EvaluarServicioAspirante : Window
    {
        Modelo.clases.Demandante demandante = null;
        ContratacionServicio contratacionServicio = null;
        public EvaluarServicioAspirante(ContratacionServicio contratacion, Modelo.clases.Demandante demandante)
        {
            InitializeComponent();
            cargarCombo();
            contratacionServicio = contratacion;
            this.demandante = demandante;

        }

        private void cargarCombo()
        {
            cbEvaluacion.Items.Add("1 Punto");
            cbEvaluacion.Items.Add("2 Puntos");
            cbEvaluacion.Items.Add("3 Puntos");
            cbEvaluacion.Items.Add("4 Puntos");
            cbEvaluacion.Items.Add("5 Puntos");
        }

        private async void btnEvaluar_Click(object sender, RoutedEventArgs e)
        {
            if (cbEvaluacion.SelectedIndex > -1)
            {
                int resultado = await ContratacionServicioDAO.evaluar(demandante.IdDemandante, contratacionServicio.IdContratacionServicio, demandante.Token, cbEvaluacion.SelectedIndex+1);
                if (resultado == 1)
                {
                    MessageBox.Show("personalizado","personalizado");
                    this.Close();
                }
            }
        }
    }
}
