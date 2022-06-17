using El_Camello.Assets.utilerias;
using El_Camello.Empleador;
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
        private string token = "";
        List<Modelo.clases.Aspirante> empleados;

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

                if(ofertaEmpleoConsulta.FechaFinalizacion > DateTime.Now)
                {
                    btnEvaluar.IsEnabled = false;
                }

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

        private async void cargarEmpleados(List<ContratacionEmpleoAspirante> listaEmpleados)
        {
            empleados = new List<Modelo.clases.Aspirante>();
            foreach (var contratado in listaEmpleados)
            {
                Modelo.clases.Aspirante empleado = await AspiranteDAO.GetAspirante(contratado.IdAspirante, token);
                empleados.Add(empleado);

            }


            if (listaEmpleados.Count > 0)
            {

                dgEmpleados.ItemsSource = empleados;
            }

        }

        private void evaluarAspirante()
        {
            int indiceSeleccion = dgEmpleados.SelectedIndex;

            if (indiceSeleccion >= 0)
            {
                Modelo.clases.Aspirante aspiranteEvaluar = empleados[indiceSeleccion];

                EvaluarApirante ventanaEvaluar = new EvaluarApirante(aspiranteEvaluar, token);
                ventanaEvaluar.ShowDialog();
            }
            else
            {
                error = new MensajesSistema("AccionInvalida", "La acción que ha realizado es invalida", "Intento de evaluar un empleado", "Selecciona un empleado para evaluarlo posteriormente");
                error.ShowDialog();
            }

        }


        private void consultarAspirante()
        {
            int indiceSeleccion = dgEmpleados.SelectedIndex;

            if (indiceSeleccion >= 0)
            {
                Modelo.clases.Aspirante aspiranteEvaluar = empleados[indiceSeleccion];

                /*EvaluarApirante ventanaEvaluar = new EvaluarApirante(aspiranteEvaluar, token);
                ventanaEvaluar.ShowDialog();*/
            }
            else
            {
                error = new MensajesSistema("AccionInvalida", "La acción que ha realizado es invalida", "Intento de consultar oferta de empleo", "Selecciona una oferta de empleo para poder consultarla posteriormente");
                error.ShowDialog();
            }

        }


    }
}
