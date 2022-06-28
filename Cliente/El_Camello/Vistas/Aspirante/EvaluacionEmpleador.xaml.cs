using System;
using System.Windows;

namespace El_Camello.Vistas.Aspirante
{

    public partial class EvaluacionEmpleador : Window
    {
        private Modelo.clases.Aspirante aspirante;
        private int idContratacionEmpleo;

        public EvaluacionEmpleador(Modelo.clases.Aspirante aspirante, int idContratacionEmpleo, string nombreOfertaEmpleo, string nombreEmpleador)
        {
            InitializeComponent();
            lblEmpleador.Content = nombreEmpleador;
            lblNombreEmpleo.Text = nombreOfertaEmpleo;
            this.Aspirante = aspirante;
            this.IdContratacionEmpleo = idContratacionEmpleo;
        }

        public Modelo.clases.Aspirante Aspirante { get => aspirante; set => aspirante = value; }
        public int IdContratacionEmpleo { get => idContratacionEmpleo; set => idContratacionEmpleo = value; }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEnviarValoracion_Click(object sender, RoutedEventArgs e)
        {
            if (cbxPuntuacion.SelectedIndex >= 0)
            {
                RegistrarEvaluacion();
                return;
            }
            MessageBox.Show("Elige la puntuación del empleador", "Puntuación no seleccionada");
        }

        private async void RegistrarEvaluacion()
        {
            int resultado = await Modelo.dao.ContratacionEmpleoAspiranteDAO.PatchEvaluarEmpleador(aspirante.IdAspirante, IdContratacionEmpleo, cbxPuntuacion.SelectedIndex + 1, aspirante.Token);
            if (resultado == 1)
            {
                MessageBox.Show("Evaluacion registrada", "Registro exitoso");
                return;
            }
        }
    }
}
