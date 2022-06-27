using El_Camello.Modelo.clases;
using El_Camello.Modelo.dao;
using El_Camello.Vistas.Aspirante.controles;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace El_Camello.Vistas.Aspirante
{
    /// <summary>
    /// Lógica de interacción para ConsultarContrataciones.xaml
    /// </summary>
    public partial class ConsultarContrataciones : Window
    {
        private Modelo.clases.Aspirante aspirante;

        public ConsultarContrataciones(Modelo.clases.Aspirante aspirante)
        {
            InitializeComponent();
            this.aspirante = aspirante;
            CargarContrataciones();
        }

        private async void CargarContrataciones()
        {
            //consulta contrataciones empleo y contrataciones servicio
            List<ContratacionServicio> contratacionesServicio = new List<ContratacionServicio>();
            contratacionesServicio = await ContratacionServicioDAO.GetContratacionesServicioAspirante(aspirante.IdAspirante, aspirante.Token);
            
            //Consulta contrataciones de ofertas de empleo
            List<ContratacionEmpleo> contratacionesEmpleo = new List<ContratacionEmpleo>();
            contratacionesEmpleo = await ContratacionEmpleoAspiranteDAO.GetContraracionesEmpleoAspirante(aspirante.IdAspirante, aspirante.Token);


            //Se muestran las contrataciones en panatalla
            Label lblContratacionesEmpleo = new Label();
            lblContratacionesEmpleo.Content = "Contrataciones de Empleo";
            lblContratacionesEmpleo.FontSize = 16;
            lblContratacionesEmpleo.FontWeight = FontWeights.Bold;
            lblContratacionesEmpleo.HorizontalContentAlignment = HorizontalAlignment.Center;
            pnlContrataciones.Children.Add(lblContratacionesEmpleo);
            foreach(ContratacionEmpleo contratacion in contratacionesEmpleo)
            {
                ContratacionControl contratacionControl = new ContratacionControl();
                contratacionControl.ContratacionEmpleo = contratacion;
                contratacionControl.MouseLeftButtonUp += CtrlContratacion_Click;
                pnlContrataciones.Children.Add(contratacionControl);
            }


            Label lblContratacionesServicio = new Label();
            lblContratacionesServicio.Content = "Contrataciones de servicio";
            lblContratacionesServicio.FontSize = 16;
            lblContratacionesServicio.FontWeight = FontWeights.Bold;
            lblContratacionesServicio.HorizontalContentAlignment = HorizontalAlignment.Center;
            pnlContrataciones.Children.Add(lblContratacionesServicio);
            foreach (ContratacionServicio contratacion in contratacionesServicio)
            {
                ContratacionControl contratacionControl = new ContratacionControl();
                contratacionControl.ContratacionServicio = contratacion;
                pnlContrataciones.Children.Add(contratacionControl);
            }
        }

        private void btnReportar_Click(object sender, RoutedEventArgs e)
        {
            ReportarEmpleo ventanaReporteEmpleo = new ReportarEmpleo();
            ventanaReporteEmpleo.ShowDialog();
        }

        private void btnEvaluar_Click(object sender, RoutedEventArgs e)
        {
            EvaluacionEmpleador ventanaEvaluacion = new EvaluacionEmpleador();
        }


        private async void CtrlContratacion_Click(object sender, MouseButtonEventArgs e)
        {
            //Cargar contratacion empleo en pantalla
            int idConversacion = ((ContratacionControl)e.Source).ContratacionEmpleo.IdContratacion;
            MessageBox.Show($"id contratacion {idConversacion}");
            
        }
    }
}
