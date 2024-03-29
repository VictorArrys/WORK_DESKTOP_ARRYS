﻿using El_Camello.Modelo.clases;
using El_Camello.Modelo.dao;
using System.Collections.Generic;
using System.Windows;

namespace El_Camello.Vistas.Demandante
{
    /// <summary>
    /// Lógica de interacción para ConsultarSolicitudServicio.xaml
    /// </summary>
    public partial class ConsultarSolicitudServicio : Window
    {
        
        Modelo.clases.Demandante demandante;
        List<SolicitudServicio> solicitudesServicio = null;
        List<ContratacionServicio> contratacionesServicio = null;
        ContratacionServicio contratacionSeleccionada = null;
        public ConsultarSolicitudServicio(Modelo.clases.Demandante demandante)
        {
            InitializeComponent();
            this.demandante = demandante;
            solicitudesServicio = new List<SolicitudServicio>();
            contratacionesServicio = new List<ContratacionServicio>();
            btnFinalizar.IsEnabled = false;
            btnEvaluar.IsEnabled = false;
            cargarTablaServicios(demandante.IdDemandante, demandante.Token);

        }

        private async void cargarTablaServicios(int idUsuario, string token)
        {
            solicitudesServicio = await SolicitudServicioDAO.GetSolicitudesDemandante(demandante.IdDemandante, demandante.Token);
            contratacionesServicio = await ContratacionServicioDAO.GetContratacionesServicio(demandante.IdDemandante, demandante.Token);
            dgSolicitudes.ItemsSource = solicitudesServicio;
            dgContrataciones.ItemsSource = contratacionesServicio;
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEvaluar_Click(object sender, RoutedEventArgs e)
        {
            EvaluarServicioAspirante evaluarServicioAspirante = new EvaluarServicioAspirante(contratacionSeleccionada, demandante);
            evaluarServicioAspirante.ShowDialog();
            cargarTablaServicios(demandante.IdDemandante, demandante.Token);
        }

        private async void btnFinalizar_Click(object sender, RoutedEventArgs e)
        {

            int resultado = await ContratacionServicioDAO.finalizar(demandante.IdDemandante, this.contratacionSeleccionada.IdContratacionServicio, demandante.Token);
            
            if (resultado == 1)
            {
                MessageBox.Show("Contratación finalizada");
            }
            
            cargarTablaServicios(demandante.IdDemandante, demandante.Token);
        }

        private void dgContratacionesCambio(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dgContrataciones.SelectedIndex > -1)
            {
                contratacionSeleccionada = (ContratacionServicio)dgContrataciones.SelectedItem;
                if (contratacionSeleccionada.Estatus == 0)
                {
                    btnFinalizar.IsEnabled = true;
                    btnEvaluar.IsEnabled = false;
                }else if (contratacionSeleccionada.Estatus == 1 && contratacionSeleccionada.ValoracionAspirante == 0)
                {
                    btnFinalizar.IsEnabled = false;
                    btnEvaluar.IsEnabled = true;
                }
                else
                {
                    btnFinalizar.IsEnabled = false;
                    btnEvaluar.IsEnabled = false;
                }
            }
        }
    }
}
