
using El_Camello.Modelo.dao;
using System.Windows;


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
        private ReportesEmpleos ventanaReportesEmpleo;
        Modelo.clases.Administrador administrador = null;

        private string token;

        public MenuAdministrador(Modelo.clases.Usuario usuarioConectado)
        {
            InitializeComponent();
            administrador = new Modelo.clases.Administrador();
            cargarAdministrador(usuarioConectado);
        }

        public async void cargarAdministrador(Modelo.clases.Usuario usuarioConectado)
        {
            administrador = await AdministradorDAO.getAdministrador(usuarioConectado.IdPerfilusuario, usuarioConectado.Token);
            administrador.NombreUsuario = usuarioConectado.NombreUsuario;
            administrador.Clave = usuarioConectado.Clave;
            administrador.CorreoElectronico = usuarioConectado.CorreoElectronico;
            administrador.Estatus = usuarioConectado.Estatus;
            administrador.Token = usuarioConectado.Token;
            token = administrador.Token;
        }

        private void btnPantallaPerfil_Click(object sender, RoutedEventArgs e)
        {
            PerfilAdministrador ventanaPerfilAdministrador = new PerfilAdministrador(administrador);
            ventanaPerfilAdministrador.ShowDialog();
        }

        private void btnPantallaCategorias_Click(object sender, RoutedEventArgs e)
        {
            if (ventanaCategorias == null)
            {
                ventanaCategorias = new categoriasEmpleo(token);
            }
            panelPrincipal.Content = ventanaCategorias;
        }

        private void btnPantallaUsuarios_Click(object sender, RoutedEventArgs e)
        {
            if (ventanaConsultarPerfiles == null)
            {
                ventanaConsultarPerfiles = new consultarPerfiles(administrador);
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
            this.Close();
        }

        private void btnReportesEmpleos(object sender, RoutedEventArgs e)
        {
            if (ventanaReportesEmpleo == null)
            {
                ventanaReportesEmpleo = new ReportesEmpleos(token);
            }
            panelPrincipal.Content = ventanaReportesEmpleo;
        }
    }
}
