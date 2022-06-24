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
    /// Lógica de interacción para ConsultarDetallesOfertaEmpleo.xaml
    /// </summary>
    public partial class ConsultarDetallesOfertaEmpleo : Window
    {
        private int IdOfertaEmpleo;
        private Modelo.clases.Aspirante aspirante;
        private OfertaEmpleo ofertaEmpleo;

        public ConsultarDetallesOfertaEmpleo(int idOfertaEmpleo, Modelo.clases.Aspirante aspirante)
        {
            InitializeComponent();
            this.aspirante = aspirante;
            this.IdOfertaEmpleo = idOfertaEmpleo;
            CargarOfertaEmpleo();
        }

        private void CargarOfertaEmpleo()
        {
            if (IdOfertaEmpleo > 0 && aspirante.Token.Length > 0)
            {
                ConsultarOfertaEmpleo();
            }
        }

        private async void ConsultarOfertaEmpleo()
        {
            ofertaEmpleo = await OfertaEmpleoDAO.GetConsultarOfertaEmpleoAspirante(IdOfertaEmpleo, aspirante.Token);
            this.lblCantidadPago.Content = "Cantidad Pago: " + ofertaEmpleo.CantidadPago;
            this.lblDireccion.Content = "Dirección: " + ofertaEmpleo.Direccion;
            string fechaFin = string.Format("{0:yyyy-MM-dd}", ofertaEmpleo.FechaFinalizacion);
            this.lblFin.Content = "Fecha Fin: " + fechaFin;
            string fechaInicio = string.Format("{0:yyyy-MM-dd}", ofertaEmpleo.FechaInicio);
            this.lblInicio.Content = "Fecha inicio: " + fechaInicio;
            this.lblNombre.Content = "Nombre empleo: " + ofertaEmpleo.Nombre;
            this.lblTipoPago.Content = "Tipo pago: " + ofertaEmpleo.TipoPago;
            this.lblVacantes.Content = "Vacantes: " + ofertaEmpleo.Vacantes;
            lblHorario.Content = $"Horario: {ofertaEmpleo.HoraInicio} - {ofertaEmpleo.HoraFin}";
            txtDescripcion.Text = ofertaEmpleo.Descripcion;

            string diasLaborales = "Dias Laborales: ";
            foreach (char c in ofertaEmpleo.DiasLaborales)
            {
                switch (c)
                {
                    case '1':
                        diasLaborales += "Lunes ";
                        break;
                    case '2':
                        diasLaborales += "Martes ";
                        break;
                    case '3':
                        diasLaborales += "Miércoles ";
                        break;
                    case '4':
                        diasLaborales += "Jueves ";
                        break;
                    case '5':
                        diasLaborales += "Viernes ";
                        break;
                    case '6':
                        diasLaborales += "Sábado ";
                        break;
                    case '7':
                        diasLaborales += "Domingo";
                        break;
                }
            }

            this.lblDiasLaborales.Content = diasLaborales;
        }

        private void btnSolicitarVacante_Click(object sender, RoutedEventArgs e)
        {
            SolicitarVacante ventanaSolicitarVacante = new SolicitarVacante(ofertaEmpleo.Nombre, ofertaEmpleo.IdOfertaEmpleo, ofertaEmpleo.Vacantes, aspirante.IdAspirante, aspirante.Token);
            ventanaSolicitarVacante.ShowDialog();
        }
    }
}
