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

namespace El_Camello.Vistas.Empleador
{
    /// <summary>
    /// Interaction logic for SolcitudesEmpleos.xaml
    /// </summary>
    public partial class SolcitudesEmpleos : Window
    {
        private List<SolicitudEmpleo> solicitudes = new List<SolicitudEmpleo>();
        private List<SolicitudEmpleo> solicitudesAceptadas = new List<SolicitudEmpleo>();

        private List<SolicitudEmpleo> solicitudesPendientes = new List<SolicitudEmpleo>();

        private string token;
        private int idOfertaEmpleo;
        private int vacantes;

        MensajesSistema mensajes;        

        public SolcitudesEmpleos(string token, int idOfertaEmpleo, int vacantes)
        {
            this.token = token;
            this.idOfertaEmpleo = idOfertaEmpleo;
            this.vacantes = vacantes;
            InitializeComponent();
            cargarSolicitudes();

        }

        private void cargarSolicitudes()
        {
            recuperarSolicitudes();
            lbVacantesUso.Content = "Ocupadas: " + solicitudesAceptadas.Count;

            lbVacantesUso.Content = "Vacantes: " + vacantes;

        }

        private async void recuperarSolicitudes()
        {
            try
            {

                solicitudes = await SolicitudEmpleoDAO.GetSolicitudesEmpleo(token, idOfertaEmpleo);
                dgSolicitudes.ItemsSource = solicitudes;
            }
            catch (Exception exceptionGetList)
            {
                mensajes = new MensajesSistema("Error", "Hubo un error al intentar cargar las solicitudes de empleo, favor de intentar más tarde", exceptionGetList.StackTrace, exceptionGetList.Message);
                mensajes.ShowDialog();
            }
            solicitudesAceptadas = solicitudes.FindAll(

            delegate (SolicitudEmpleo solicitudAceptada)
            {
                return solicitudAceptada.Estatus == "Aprobada";
            });

            dgVacantesEnUso.ItemsSource = solicitudesAceptadas;
            
            solicitudesPendientes = solicitudes.FindAll(
            delegate (SolicitudEmpleo solicitudAceptada)
            {
                return solicitudAceptada.Estatus == "Pendiente";
            }
            );
            dgSolicitudes.ItemsSource = solicitudesPendientes;

        }

        private async void dgSolicitudes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int indiceSeleccion = dgSolicitudes.SelectedIndex;

            if (indiceSeleccion >= 0)
            {
                SolicitudEmpleo solicitudSeleccionada = solicitudes[indiceSeleccion];


                Modelo.clases.Aspirante informacionAspirante = await AspiranteDAO.GetAspirante(solicitudSeleccionada.IdUsuarioAspirante, token);
                lbNombreAspirante.Content = informacionAspirante.NombreAspirante;
                lbDireccion.Content = informacionAspirante.Direccion;
                lbTelefono.Content = informacionAspirante.Telefono;


            }

        }

        private async void aceptarEmpleado(object sender, RoutedEventArgs e)
        {
            int indiceSeleccion = dgSolicitudes.SelectedIndex;

            if (indiceSeleccion >= 0)
            {
                SolicitudEmpleo solicitudSeleccionada = solicitudes[indiceSeleccion];
                int solicitudAceptada = await SolicitudEmpleoDAO.PatchAceptarSolicitud(token, solicitudSeleccionada.IdSolicitud);
               
                if(solicitudAceptada == 1)
                {
                    mensajes = new MensajesSistema("AccionExitosa", "La acción que ha realizado se completo correctamente", "Aceptar solcitud", "Se ha aceptado la solicitud de empleo");
                    mensajes.ShowDialog();
                    vacantes --;
                    cargarSolicitudes();
                }
                else
                {
                    mensajes = new MensajesSistema("Error", "La acción que ha realizado ha fallado", "Intento aceptar una solicitud", "No se ha podido aceptar la solicitud de empleo");
                    mensajes.ShowDialog();
                }

            }
            else
            {
                mensajes = new MensajesSistema("AccionInvalida", "La acción que ha realizado es invalida", "Intento aceptar una solcitud", "Selecciona una solicitud para aceptarla posteriormente");
                mensajes.ShowDialog();
            }

        }

        private async void rechazarEmpleado(object sender, RoutedEventArgs e)
        {
            int indiceSeleccion = dgSolicitudes.SelectedIndex;

            if (indiceSeleccion >= 0)
            {
                SolicitudEmpleo solicitudSeleccionada = solicitudes[indiceSeleccion];
                int solicitudRechazada = await SolicitudEmpleoDAO.PatchRechazarSolicitud(token, solicitudSeleccionada.IdSolicitud);

                if (solicitudRechazada == 1)
                {
                    mensajes = new MensajesSistema("AccionExitosa", "La acción que ha realizado se completo correctamente", "Rechazar solcitud", "Se ha rechazado la solicitud de empleo");
                    mensajes.ShowDialog();
                    cargarSolicitudes();
                }
                else
                {
                    mensajes = new MensajesSistema("Error", "La acción que ha realizado ha fallado", "Intento rechazar una solicitud", "No se ha podido rechazar la solicitud de empleo");
                    mensajes.ShowDialog();
                }

            }
            else
            {
                mensajes = new MensajesSistema("AccionInvalida", "La acción que ha realizado es invalida", "Intento rechazar una solcitud", "Selecciona una solicitud para aceptarla posteriormente");
                mensajes.ShowDialog();
            }

        }


    }
}
