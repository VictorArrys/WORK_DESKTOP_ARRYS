using El_Camello.Modelo.clases;
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
