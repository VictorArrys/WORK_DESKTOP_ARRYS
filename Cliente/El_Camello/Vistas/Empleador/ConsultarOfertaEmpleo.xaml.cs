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
    /// Interaction logic for ConsultarOfertaEmpleo.xaml
    /// </summary>
    public partial class ConsultarOfertaEmpleo : Window
    {
        int idOfertaEmpleo;
        string token;

        MensajesSistema error;

        public ConsultarOfertaEmpleo(int idOfertaEmpleo, string token)
        {
            this.token = token;
            this.idOfertaEmpleo = idOfertaEmpleo;
            InitializeComponent();

            cargarOfertaEmpleo();
        }

        private async void cargarOfertaEmpleo()
        {
            try
            {
                string tokenString = "" + token;

                OfertaEmpleo ofertaEmpleoConsulta = await OfertaEmpleoDAO.GetOfertaEmpleoCompleta(idOfertaEmpleo, tokenString);

                lbNombreEmpleo.Text = ofertaEmpleoConsulta.Nombre;
                lbTipoPago.Text = ofertaEmpleoConsulta.TipoPago;
                lbCategoria.Text = ofertaEmpleoConsulta.CategoriaEmpleo;
                lbPago.Text = "$" + ofertaEmpleoConsulta.CantidadPago;

                string fechaContratacion = string.Format("{0:yyyy-MM-dd}", ofertaEmpleoConsulta.ContratacionEmpleo.FechaContratacion);

                if (fechaContratacion == "0001-01-01")
                {
                    lbFechaContratacion.Text = "Sin contratación";
                }
                else
                {

                    lbFechaContratacion.Text = fechaContratacion;
                }

                cargarEmpleados(ofertaEmpleoConsulta.ContratacionEmpleo.ContratacionesAspirantes);

                string fechaFin = string.Format("{0:yyyy-MM-dd}", ofertaEmpleoConsulta.FechaFinalizacion);
                lbFechaFinalizacion.Text = fechaFin;

            }
            catch (Exception exception)
            {
                error = new MensajesSistema("Error", "Hubo un error al cargar la oferta de empleo, favor de intentar más tarde", exception.StackTrace, exception.Message);
                error.ShowDialog();
            }

        }

        private void cargarEmpleados(List<ContratacionEmpleoAspirante> listaEmpleados)
        {

            if (listaEmpleados.Count == 0)
            {

            }
            else
            {
                dgEmpleados.ItemsSource = listaEmpleados;
            }

        }


    }
}
