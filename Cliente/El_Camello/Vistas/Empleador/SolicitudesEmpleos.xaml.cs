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

        private string token;
        private int idOfertaEmpleo;

        MensajesSistema error;        

        public SolcitudesEmpleos(string token, int idOfertaEmpleo)
        {
            this.token = token;
            this.idOfertaEmpleo = idOfertaEmpleo;
            InitializeComponent();
            cargarSolicitudes();

        }

        private void cargarSolicitudes()
        {
            recuperarSolicitudes();


            
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
                error = new MensajesSistema("Error", "Hubo un error al intentar cargar las solicitudes de empleo, favor de intentar más tarde", exceptionGetList.StackTrace, exceptionGetList.Message);
                error.ShowDialog();
            }

            dgVacantesEnUso.ItemsSource = solicitudes.FindAll(

            delegate (SolicitudEmpleo solicitudAceptada)
            {
                return solicitudAceptada.Estatus == "Aprobada";
            }
            );

            dgSolicitudes.ItemsSource = solicitudes.FindAll(
            delegate (SolicitudEmpleo solicitudAceptada)
            {
                return solicitudAceptada.Estatus == "Pendiente";
            }
            );

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
    }
}
