using El_Camello.Modelo.clases;
using El_Camello.Modelo.dao;
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

namespace El_Camello.Vistas.Demandante
{
    /// <summary>
    /// Lógica de interacción para SolicitarServicio.xaml
    /// </summary>
    public partial class SolicitarServicio : Window
    {
        Modelo.clases.Demandante demandante;
        Modelo.clases.Aspirante aspirante;

        public SolicitarServicio(Modelo.clases.Demandante demandante, Modelo.clases.Aspirante aspirante)
        {
            InitializeComponent();
            this.demandante = demandante;
            this.aspirante = aspirante;
        }

        private async void btnEnviarSolicitud_Click(object sender, RoutedEventArgs e)
        {
            if (txtTitulo.Text.Length > 0 && txtDescripcion.Text.Length > 0)
            {
                SolicitudServicio nuevaSolicitud = new SolicitudServicio();
                nuevaSolicitud.Titulo = txtTitulo.Text;
                nuevaSolicitud.Descripcion = txtDescripcion.Text;
                nuevaSolicitud.Aspirante = aspirante;

                int resultado = await SolicitudServicioDAO.PostSolicitudServicio(nuevaSolicitud, demandante.IdDemandante, demandante.Token);
                if (resultado == 1)
                {
                    MessageBox.Show("Solicitud registrada exitosamente", "Solicitud registrada");
                    this.Close();
                }
                return;
            }
            MessageBox.Show("Hay campos vacios.", "Campos vacios");
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
