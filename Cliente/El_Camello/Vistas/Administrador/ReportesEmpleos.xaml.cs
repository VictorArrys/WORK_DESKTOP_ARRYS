using El_Camello.Assets.utilerias;
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

namespace El_Camello.Vistas.Administrador
{
    /// <summary>
    /// Interaction logic for ReportesEmpleos.xaml
    /// </summary>
    public partial class ReportesEmpleos : Page
    {
        private string token = "";
        private List<ReporteEmpleo> reportesEmpleos = new List<ReporteEmpleo>();
        MensajesSistema mensajes;

        public ReportesEmpleos(string token)
        {
            this.token = token;

            InitializeComponent();
            cargarReportes();
        }



        private void cargarReportes()
        {
            recuperarReportes();

        }

        private async void recuperarReportes()
        {
            try
            {
                reportesEmpleos = await ReporteEmpleoDAO.GetReportesEmpleo(token);
                dgReportes.ItemsSource = reportesEmpleos;
            }
            catch (Exception exceptionGetList)
            {
                mensajes = new MensajesSistema("Error", "Hubo un error al intentar cargar los reportes de empleo, favor de intentar más tarde", exceptionGetList.StackTrace, exceptionGetList.Message);
                mensajes.ShowDialog();
            }
           

        }

        private void aceptarEmpleado(object sender, RoutedEventArgs e)
        {

        }

        private void rechazarEmpleado(object sender, RoutedEventArgs e)
        {

        }

        private async void dgReportes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int indiceSeleccion = dgReportes.SelectedIndex;

            if (indiceSeleccion >= 0)
            {
                ReporteEmpleo reporteSeleccionado = reportesEmpleos[indiceSeleccion];

                lbNombreEmpleador.Content = reporteSeleccionado.NombreEmpleador;
                tbDescripcion.Text = reporteSeleccionado.DescripcionOfertaReportada;
                tbReporte.Text = reporteSeleccionado.Motivo;
                lbFecha.Content = reporteSeleccionado.FechaRegistro;

            }

        }
    }
}
