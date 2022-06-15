
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
    /// Lógica de interacción para MenuAdministrador.xaml
    /// </summary>
    public partial class MenuAdministrador : Window
    {
        private categoriasEmpleo ventanaCategorias;
        private consultarPerfiles ventanaConsultarPerfiles;
        private ReportesEstadisticos ventanaRepEst;
        private GraficasEstadisticas ventanaGrfEst;

        private string token;

        public MenuAdministrador(Modelo.clases.Usuario usuarioConectado)
        {
            this.token = usuarioConectado.Token;
            InitializeComponent();

        }

        private void btnPantallaPerfil_Click(object sender, RoutedEventArgs e)
        {
            PerfilAdministrador ventanaPerfilAdministrador = new PerfilAdministrador(/* Objeto Administrador */);
            ventanaPerfilAdministrador.ShowDialog();
        }

        private void btnPantallaCategorias_Click(object sender, RoutedEventArgs e)
        {
            if (ventanaCategorias == null)
            {
                ventanaCategorias = new categoriasEmpleo();
            }
            panelPrincipal.Content = ventanaCategorias;
        }

        private void btnPantallaUsuarios_Click(object sender, RoutedEventArgs e)
        {
            if (ventanaConsultarPerfiles == null)
            {
                ventanaConsultarPerfiles = new consultarPerfiles();
            }
            panelPrincipal.Content = ventanaConsultarPerfiles;
        }

        private void btnPantallaRptEst_Click(object sender, RoutedEventArgs e)
        {
            if (ventanaRepEst == null)
            {
                ventanaRepEst = new ReportesEstadisticos(token);
            }
            panelPrincipal.Content = ventanaRepEst;
        }

        private void btnPantallaGrfEst_Click(object sender, RoutedEventArgs e)
        {
            if (ventanaGrfEst == null)
            {
                //ventanaGrfEst = new GraficasEstadisticas();
            }
            panelPrincipal.Content = ventanaGrfEst;
        }

        private void btnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
