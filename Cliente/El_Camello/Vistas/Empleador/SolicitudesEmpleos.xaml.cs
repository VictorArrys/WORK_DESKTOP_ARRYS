using El_Camello.Aspirante;
using El_Camello.Assets.utilerias;
using El_Camello.Modelo.clases;
using El_Camello.Modelo.dao;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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
            btnAprobar.IsEnabled = false;
            btnRechazar.IsEnabled = false;
            btnVerMas.IsEnabled = false;
            recuperarSolicitudes();

        }

        private async void recuperarSolicitudes()
        {
            try
            {

                solicitudes = await SolicitudEmpleoDAO.GetSolicitudesEmpleo(token, idOfertaEmpleo);

                if(solicitudes.Count == 0)
                {
                    lbMensaje.Content = "Aun no cuentas con ninguna solicitud, vuelve pronto a revisar nuevamente";

                }
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


            lbVacantesUso.Content = "Ocupadas: " + solicitudesAceptadas.Count;

            lbVacantesLibres.Content = "Vacantes: " + vacantes;

        }

        private async void dgSolicitudes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnAprobar.IsEnabled = true;
            btnRechazar.IsEnabled = true;
            btnVerMas.IsEnabled = true;

            int indiceSeleccion = dgSolicitudes.SelectedIndex;

            if (indiceSeleccion >= 0)
            {
                SolicitudEmpleo solicitudSeleccionada = solicitudesPendientes[indiceSeleccion];


                Modelo.clases.Aspirante informacionAspirante = await AspiranteDAO.GetAspirante(solicitudSeleccionada.IdUsuarioAspirante, token);
                lbNombreAspirante.Content = informacionAspirante.NombreAspirante;
                lbDireccion.Content = informacionAspirante.Direccion;
                lbTelefono.Content = informacionAspirante.Telefono;

                List<Categoria> categorias = new List<Categoria>();
                categorias = await CategoriaDAO.GetCategorias();
                for (int x = 0; x < informacionAspirante.Oficios.Count; x++)
                {
                    for (int y = 0; y < categorias.Count; y++)
                    {
                        if (categorias[y].IdCategoria == informacionAspirante.Oficios[x].IdCategoria)
                        {
                            informacionAspirante.Oficios[x].NombreCategoria = categorias[y].NombreCategoria;
                            break;
                        }
                    }
                }

                dgOficios.ItemsSource = informacionAspirante.Oficios;

            }

        }

        private async void aceptarEmpleado(object sender, RoutedEventArgs e)
        {

            int indiceSeleccion = dgSolicitudes.SelectedIndex;

            if (indiceSeleccion >= 0)
            {
                if (vacantes >= 1)
                {
                    SolicitudEmpleo solicitudSeleccionada = solicitudesPendientes[indiceSeleccion];

                    int solicitudAceptada = await SolicitudEmpleoDAO.PatchAceptarSolicitud(token, solicitudSeleccionada.IdSolicitud);

                    if (solicitudAceptada == 1)
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
                    mensajes = new MensajesSistema("AccionInvalida", "La acción que ha realizado es invalida", "Intento aceptar una solcitud", "Ya no existen más vacantes, no puedes aceptar más solicitudes");
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
                SolicitudEmpleo solicitudSeleccionada = solicitudesPendientes[indiceSeleccion];
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



        private async void consultarAspirante(object sender, RoutedEventArgs e)
        {
            int indiceSeleccion = dgSolicitudes.SelectedIndex;

            if (indiceSeleccion >= 0)
            {
                SolicitudEmpleo aspiranteConsultar = solicitudesPendientes[indiceSeleccion];

                PerfilAspirante perfilAspirante = new PerfilAspirante(aspiranteConsultar.IdUsuarioAspirante, token);
                perfilAspirante.ShowDialog();
            }
            else
            {
                int indiceSeleccionVacantesUso = dgVacantesEnUso.SelectedIndex;
                if (indiceSeleccionVacantesUso >= 0)
                {
                    SolicitudEmpleo aspiranteConsultar = solicitudesAceptadas[indiceSeleccionVacantesUso];

                    PerfilAspirante perfilAspirante = new PerfilAspirante(aspiranteConsultar.IdUsuarioAspirante, token);
                    perfilAspirante.ShowDialog();
                }
                else
                {
                    mensajes = new MensajesSistema("AccionInvalida", "La acción que ha realizado es invalida", "Intento de consultar oferta de empleo", "Selecciona una oferta de empleo para poder consultarla posteriormente");
                    mensajes.ShowDialog();
                }

            }
           

        }

        private async void dgVacantesEnUso_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnAprobar.IsEnabled = true;
            btnRechazar.IsEnabled = true;
            btnVerMas.IsEnabled = true;
            int indiceSeleccion = dgVacantesEnUso.SelectedIndex;

            if (indiceSeleccion >= 0)
            {
                SolicitudEmpleo solicitudSeleccionada = solicitudesAceptadas[indiceSeleccion];


                Modelo.clases.Aspirante informacionAspirante = await AspiranteDAO.GetAspirante(solicitudSeleccionada.IdUsuarioAspirante, token);
                lbNombreAspirante.Content = informacionAspirante.NombreAspirante;
                lbDireccion.Content = informacionAspirante.Direccion;
                lbTelefono.Content = informacionAspirante.Telefono;

                List<Categoria> categorias = new List<Categoria>();
                categorias = await CategoriaDAO.GetCategorias();
                for (int x = 0; x < informacionAspirante.Oficios.Count; x++)
                {
                    for (int y = 0; y < categorias.Count; y++)
                    {
                        if (categorias[y].IdCategoria == informacionAspirante.Oficios[x].IdCategoria)
                        {
                            informacionAspirante.Oficios[x].NombreCategoria = categorias[y].NombreCategoria;
                            break;
                        }
                    }
                }

                dgOficios.ItemsSource = informacionAspirante.Oficios;

            }

        }

        private void cerrarVentana_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
