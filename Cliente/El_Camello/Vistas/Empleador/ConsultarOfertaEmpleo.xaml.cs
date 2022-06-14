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

                OfertaEmpleo ofertaEmpleoEdicion = await OfertaEmpleoDAO.GetOfertaEmpleoCompleta(idOfertaEmpleo, tokenString);

                lbNombreEmpleo.Text = ofertaEmpleoEdicion.Nombre;

                //tipoPago
                lbTipoPago.Text = ofertaEmpleoEdicion.TipoPago;
                //categoria
                lbCategoria.Text = ofertaEmpleoEdicion.CategoriaEmpleo;
                lbPago.Text = "$" + ofertaEmpleoEdicion.CantidadPago;

                string fechaContratacion = string.Format("{0:yyyy-MM-dd}", ofertaEmpleoEdicion.ContratacionEmpleo.FechaContratacion);

                if (fechaContratacion == "0001-01-01")
                {
                    lbFechaContratacion.Text = "Sin contratación";
                }
                else
                {

                    lbFechaContratacion.Text = fechaContratacion;
                }

                string fechaFin = string.Format("{0:yyyy-MM-dd}", ofertaEmpleoEdicion.FechaFinalizacion);
                lbFechaFinalizacion.Text = fechaFin;

            }
            catch (Exception exception)
            {
                error = new MensajesSistema("Error", "Hubo un error al cargar la oferta de empleo, favor de intentar más tarde", exception.StackTrace, exception.Message);
                error.ShowDialog();
            }

        }


    }
}
