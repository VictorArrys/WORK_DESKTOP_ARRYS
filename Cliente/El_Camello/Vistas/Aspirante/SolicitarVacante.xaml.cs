using System;
using System.Windows;

namespace El_Camello.Vistas.Aspirante
{
    /// <summary>
    /// Lógica de interacción para SolicitarVacante.xaml
    /// </summary>
    public partial class SolicitarVacante : Window , Modelo.interfaz.observadorRespuesta
    {
        private string token;
        private int idOfertaEmpleo;
        private int idPerfilAspirante;

        public SolicitarVacante(string nombreOferta, int idOfertaEmpleo, int vacantes, int idPerfilAspriante, string token)
        {
            InitializeComponent();
            this.token = token;
            this.idOfertaEmpleo = idOfertaEmpleo;
            this.idPerfilAspirante = idPerfilAspriante;
            txtOferta.Text = nombreOferta;
            lblVacantes.Content = $"Quedan {vacantes} vancantes";
        }

        public void actualizarCambios(string aviso)
        {
            lblAviso.Content = $"Aviso: {aviso}";
        }

        public void actualizarInformacion(Modelo.clases.Usuario usuario)
        {
            throw new NotImplementedException();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSolicitarVacante_Click(object sender, RoutedEventArgs e)
        {
            RegistrarSolicitudVacante();
        }

        private async void RegistrarSolicitudVacante()
        {
            _ = await Modelo.dao.SolicitudEmpleoDAO.PostSolicitarVacante(idOfertaEmpleo, idPerfilAspirante, token, this);
        }
    }
}
