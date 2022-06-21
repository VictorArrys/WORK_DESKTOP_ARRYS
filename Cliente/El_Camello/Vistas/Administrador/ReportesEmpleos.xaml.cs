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

        private async void aceptarReporte(object sender, RoutedEventArgs e)
        {
            int indiceSeleccion = dgReportes.SelectedIndex;

            if (indiceSeleccion >= 0)
            {
                ReporteEmpleo reporteSeleccionado = reportesEmpleos[indiceSeleccion];

                int reporteAceptado = await ReporteEmpleoDAO.PatchAceptarReporte(token, reporteSeleccionado.IdReporte);

               if (reporteAceptado == 1)
               {
                    mensajes = new MensajesSistema("AccionExitosa", "La acción que ha realizado se completo correctamente", "Aceptar reporte", "Se ha aceptado el reporte y aplicado amonestacion al empleador");
                    mensajes.ShowDialog();
                    cargarReportes();
               }else if(reporteAceptado == -1)
                {
                    mensajes = new MensajesSistema("AccionExitosa", "Se ha aprobado la solicitud del reporte", "Aceptar reporte", "El empleador ya tiene la cantidad maxima de amonestaciones, aún así agradecemos su reporte y le informamos que ya hemos tomado medidas");
                    mensajes.ShowDialog();
                    cargarReportes();
                }
               else
               {
                    mensajes = new MensajesSistema("Error", "La acción que ha realizado ha fallado", "Intento aceptar un reporte de empleo", "No se ha podido aceptar el reporte de empleo");
                    mensajes.ShowDialog();
               }


            }
            else
            {
                mensajes = new MensajesSistema("AccionInvalida", "La acción que ha realizado es invalida", "Intento aceptar un reporte de empleo", "Selecciona un reporte de empleo para aceptarlo posteriormente");
                mensajes.ShowDialog();
            }

        }

        private async void rechazarReporte(object sender, RoutedEventArgs e)
        {
            int indiceSeleccion = dgReportes.SelectedIndex;

            if (indiceSeleccion >= 0)
            {
                ReporteEmpleo reporteSeleccionado = reportesEmpleos[indiceSeleccion];

                int reporteRechazado = await ReporteEmpleoDAO.PatchRechazarReporte(token, reporteSeleccionado.IdReporte);

                if (reporteRechazado == 1)
                {
                    mensajes = new MensajesSistema("AccionExitosa", "La acción que ha realizado se completo correctamente", "Rechazar reporte", "Se ha rechazado el reporte de empleo");
                    mensajes.ShowDialog();
                    cargarReportes();
                }
                else
                {
                    mensajes = new MensajesSistema("Error", "La acción que ha realizado ha fallado", "Intento rechazar un reporte de empleo", "No se ha podido rechazar el reporte de empleo");
                    mensajes.ShowDialog();
                }


            }
            else
            {
                mensajes = new MensajesSistema("AccionInvalida", "La acción que ha realizado es invalida", "Intento rechazar un reporte de empleo", "Selecciona un reporte de empleo para rechazarlo posteriormente");
                mensajes.ShowDialog();
            }

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
