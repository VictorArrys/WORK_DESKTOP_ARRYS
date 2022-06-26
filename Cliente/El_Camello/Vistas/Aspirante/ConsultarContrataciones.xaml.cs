using El_Camello.Modelo.clases;
using El_Camello.Modelo.dao;
using El_Camello.Vistas.Aspirante.controles;
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
            
            
            
            //Se muestran las contrataciones en panatalla
            foreach (ContratacionServicio contratacion in contratacionesServicio)
            {
                ContratacionControl contratacionControl = new ContratacionControl();
                contratacionControl.ContratacionServicio = contratacion;
                pnlContrataciones.Children.Add(contratacionControl);
            }
        }

        private void btnReportar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEvaluar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
