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

namespace El_Camello.Vistas.Aspirante
{
    /// <summary>
    /// Lógica de interacción para SolicitudesServicio.xaml
    /// </summary>
    public partial class SolicitudesServicio : Window
    {
        private Modelo.clases.Aspirante aspirante;
        private Modelo.clases.SolicitudServicio solicitudSeleccionada;

        public SolicitudesServicio(Modelo.clases.Aspirante aspirante)
        {
            InitializeComponent();
            this.aspirante = aspirante;
        }

        private void btnBuscarSolicitudes_Click(object sender, RoutedEventArgs e)
        {
            BucarSolicitudes();
        }

        private async void BucarSolicitudes()
        {
            if(cbxEstatus.SelectedIndex > -1)
            {
                List<SolicitudServicio> solicitudes = await SolicitudServicioDAO.GetSolicitudesAspirante(aspirante.IdAspirante, cbxEstatus.SelectedIndex , aspirante.Token);
                dgSolicitudes.ItemsSource = solicitudes;
            }
        }

        private void CargarDetallesSolicitud(object sender, SelectionChangedEventArgs e)
        {
            if(dgSolicitudes.SelectedIndex > -1)
            {
                MostrarSolicitudSeleccionada();
            }
        }

        private async void MostrarSolicitudSeleccionada()
        {
            int idSolicitud = ((SolicitudServicio)dgSolicitudes.SelectedItem).IdSolicitudServicio;
            solicitudSeleccionada = await SolicitudServicioDAO.GetSolicitudAspirante(aspirante.IdAspirante, idSolicitud, aspirante.Token);
            lblDemandante.Content = "Demandante: " + solicitudSeleccionada.NombreDemandante;
            lblDescripcion.Text = solicitudSeleccionada.Descripcion;
            lblEstatus.Content = "Estatus: " + solicitudSeleccionada.EstatusSolicitud;
            lblTitulo.Content = "Titulo: " + solicitudSeleccionada.Titulo;
            lblFechaRegistro.Content = "Fecha registro: " + string.Format("{0:yyyy-MM-dd}", solicitudSeleccionada.FechaRegistro);
            if (solicitudSeleccionada.Estatus == 0)
            {
                btnRechazar.IsEnabled = true;
                btnAceptar.IsEnabled = true;
            }
            else
            {
                btnRechazar.IsEnabled = false;
                btnAceptar.IsEnabled = false;
            }
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {

            AceptarSolicitud();
        }

        private async void AceptarSolicitud()
        {
            if (solicitudSeleccionada != null)
            {
                string mensaje = await SolicitudServicioDAO.PatchAceptarSolicitud(aspirante.IdAspirante, solicitudSeleccionada.IdSolicitudServicio, aspirante.Token);
                MessageBox.Show(mensaje);
            }
            ActualizarPantalla();
        }

        private void btnRechazar_Click(object sender, RoutedEventArgs e)
        {
            RechazarSolicitud();
        }

        private async void RechazarSolicitud()
        {
            if(solicitudSeleccionada != null)
            {
                string mensaje = await SolicitudServicioDAO.PatchRechazarSolicitud(aspirante.IdAspirante, solicitudSeleccionada.IdSolicitudServicio, aspirante.Token);
                MessageBox.Show(mensaje);
            }
            ActualizarPantalla();
        }

        private void ActualizarPantalla()
        {
            lblDemandante.Content = "Demandante: ";
            lblDescripcion.Text = "";
            lblEstatus.Content = "Estatus: ";
            lblTitulo.Content = "Titulo: ";
            lblFechaRegistro.Content = "Fecha registro: ";
            lblDescripcion.Text = "";
            btnRechazar.IsEnabled = false;
            btnAceptar.IsEnabled = false;
            solicitudSeleccionada = null;
            dgSolicitudes.Items.Clear();
        }
    }
}
