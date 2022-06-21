using El_Camello.Modelo.clases;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace El_Camello.Vistas.Aspirante.controles
{
    public partial class OfertaEmpleoControl : UserControl
    {
        private Modelo.clases.OfertaEmpleo ofertaEmpleo;

        public OfertaEmpleoControl()
        {
            InitializeComponent();
            
        }

        public OfertaEmpleo OfertaEmpleo { get => ofertaEmpleo; 
            set 
            {
                ofertaEmpleo = value;
                this.lblCantidadPago.Content = "Cantidad Pago: " + ofertaEmpleo.CantidadPago;
                this.lblDireccion.Content = "Dirección: " + ofertaEmpleo.Direccion;
                this.lblFin.Content = "Fecha Fin: " + ofertaEmpleo.FechaFinalizacion;
                this.lblInicio.Content = "Fecha inicio: " + ofertaEmpleo.FechaInicio;
                this.lblNombre.Content = "Nombre empleo: " + ofertaEmpleo.Nombre;
                this.lblTipoPago.Content = "Tipo pago: " + ofertaEmpleo.TipoPago;
                this.lblVacantes.Content = "Vacantes: " + ofertaEmpleo.Vacantes;

                string diasLaborales = "Dias Laborales: ";
                foreach (char c in ofertaEmpleo.DiasLaborales)
                {
                    switch(c) {
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
                            diasLaborales += "Domingo ";
                            break;
                    }
                }

                this.lblDiasLaborales.Content = diasLaborales;

            } 
        }

        private void btnDetallesOferta_Click(object sender, RoutedEventArgs e)
        {
            ConsultarDetallesOfertaEmpleo ventanaOfertaEmpleo = new ConsultarDetallesOfertaEmpleo();
            ventanaOfertaEmpleo.ShowDialog();
        }
    }
}
