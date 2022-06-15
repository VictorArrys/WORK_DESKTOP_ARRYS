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

namespace El_Camello.Vistas.Administrador
{
    /// <summary>
    /// Interaction logic for ReportesEstadisticos.xaml
    /// </summary>
    public partial class ReportesEstadisticos : Page
    {
        private string tokenAdministrador;
        private List<EstadisticasPlataforma> estadisticasPlataforma;
        private List<EstadisticasEmpleoDemanda> estadisticasEmpleoDemandas;
        private List<ValoracionEmpleador> valoracionesEmpleadores;
        private List<ValoracionAspirante> valoracionesAspirantes;

        public ReportesEstadisticos(string token)
        {
            this.tokenAdministrador = token;
            InitializeComponent();
            cargarTablas();

        }

        private void cargarTablas()
        {
            cargarEstadisticasPlataforma();
            cargarMayoresOfertas();
            cargarValoracionesAspirantes();
            cargarValoracionesEmpleadores();


        }

        private async void cargarEstadisticasPlataforma()
        {
            estadisticasPlataforma = await EstadisticasDAO.GetEstadisticasPlataforma(tokenAdministrador);
            dgPlataforma.ItemsSource = estadisticasPlataforma;

        }

        private async void cargarMayoresOfertas()
        {
            estadisticasEmpleoDemandas = await EstadisticasDAO.GetEstadisticasDemanda(tokenAdministrador);
            dgMayoresOfertas.ItemsSource = estadisticasEmpleoDemandas;
        }

        private async void cargarValoracionesEmpleadores()
        {
            valoracionesAspirantes = await EstadisticasDAO.GetValoracionesAspirantes(tokenAdministrador);
            dgValoracionesAspirantes.ItemsSource = valoracionesAspirantes;

        }
        private async void cargarValoracionesAspirantes()
        {
            valoracionesEmpleadores = await EstadisticasDAO.GetValoracionesEmpleadores(tokenAdministrador);
            dgValoracionesEmpleadores.ItemsSource = valoracionesEmpleadores;

        }



    }
}
