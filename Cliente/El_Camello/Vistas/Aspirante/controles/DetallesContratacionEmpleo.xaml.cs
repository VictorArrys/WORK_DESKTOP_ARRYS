using El_Camello.Modelo.clases;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace El_Camello.Vistas.Aspirante.controles
{
    /// <summary>
    /// Lógica de interacción para DetallesContratacionEmpleo.xaml
    /// </summary>
    public partial class DetallesContratacionEmpleo : UserControl
    {
        private Tuple<ContratacionEmpleo, OfertaEmpleo> contratacionDetallada;
        private Modelo.clases.Aspirante aspirante;

        public DetallesContratacionEmpleo()
        {
            InitializeComponent();
            CargarComponentes();
        }

        public Tuple<ContratacionEmpleo, OfertaEmpleo> ContratacionDetallada { 
            get => contratacionDetallada; 
            set 
            {
                if (!(value == null))
                {
                    contratacionDetallada = value;
                    MostrarDetallesContratacion();
                } 
                else
                {
                    CargarComponentes();   
                }
            }
        }

        public Modelo.clases.Aspirante Aspirante { get => aspirante; set => aspirante = value; }

        private void MostrarDetallesContratacion()
        {
            lblCantidadPago.Content = "Cantidad Pago: " + contratacionDetallada.Item2.CantidadPago;
            lblCategoria.Content = "Categoria: " + contratacionDetallada.Item2.CategoriaEmpleo;
            string diasLaborales = "Dias Laborales: ";
            foreach (char c in contratacionDetallada.Item2.DiasLaborales)
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
            lblDiasLaborales.Content = diasLaborales;
            lblDireccion.Content = "Dirección: " + contratacionDetallada.Item2.Direccion;
            switch(contratacionDetallada.Item1.Estatus)
            {
                case 1:
                    lblEstatus.Content = "Estatus: Em proceso";
                    btnEvaluar.IsEnabled = true;// false;
                    btnReportar.IsEnabled = true;//false;
                    break;
                case 0:
                    lblEstatus.Content = "Estatus: Finalizada";
                    btnEvaluar.IsEnabled = true;
                    btnReportar.IsEnabled = true;
                    break;
                default:
                    btnReportar.IsEnabled = false;
                    btnEvaluar.IsEnabled = false;
                    break;
            }
            lblFin.Content = "Fecha Fin: " + string.Format("{0:yyyy-MM-dd}", contratacionDetallada.Item2.FechaFinalizacion);
            lblInicio.Content = "Fecha Inicio: " + string.Format("{0:yyyy-MM-dd}", contratacionDetallada.Item2.FechaInicio);
            lblHorario.Content = "Horario: " + contratacionDetallada.Item2.HoraInicio + " - " + contratacionDetallada.Item2.HoraFin;
            lblNombre.Content = "Nombre empleo: " + contratacionDetallada.Item2.Nombre;
            lblTipoPago.Content = "Tipo pago: " + contratacionDetallada.Item2.TipoPago;
            
        }

        private void btnEvaluar_Click(object sender, RoutedEventArgs e)
        {
            EvaluacionEmpleador ventanaEvaluacion = new EvaluacionEmpleador();
            ventanaEvaluacion.ShowDialog();
        }

        private void btnReportar_Click(object sender, RoutedEventArgs e)
        {
            ReportarEmpleo ventanaReporteEmpleo = new ReportarEmpleo(aspirante, contratacionDetallada.Item1);
            ventanaReporteEmpleo.ShowDialog();
        }

        private void CargarComponentes()
        {

            btnEvaluar.IsEnabled = false;
            btnEvaluar.IsEnabled = false;

            lblCantidadPago.Content = "Cantidad Pago: ";
            lblCategoria.Content = "Categoria: ";
            lblDiasLaborales.Content = "Dias laborales";
            lblDireccion.Content = "Dirección: ";
            lblEstatus.Content = "Estatus: Em proceso";
            lblFin.Content = "Fecha fin: ";
            lblInicio.Content = "Fecha Inicio";
            lblHorario.Content = "Horario: ";
            lblNombre.Content = "Nombre empleo: ";
            lblTipoPago.Content = "Tipo pago: ";
        }
    }
}
