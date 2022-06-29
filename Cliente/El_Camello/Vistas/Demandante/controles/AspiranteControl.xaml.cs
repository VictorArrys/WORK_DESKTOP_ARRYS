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

namespace El_Camello.Vistas.Demandante.controles
{
    /// <summary>
    /// Lógica de interacción para AspiranteControl.xaml
    /// </summary>
    public partial class AspiranteControl : UserControl
    {
        Modelo.clases.Aspirante aspirante;
        Modelo.clases.Demandante demandante;

        public AspiranteControl(Modelo.clases.Demandante demandante, Modelo.clases.Aspirante aspirante)
        {
            InitializeComponent();
            this.aspirante = aspirante;
            this.demandante = demandante;
            lblCorreo.Content = aspirante.CorreoElectronico;
            lblNombre.Content = aspirante.NombreAspirante;
            lblTelefono.Content = aspirante.Telefono;
            if (aspirante.ValoracionPromedio == 0)
            {
                lblValoracion.Content = "Si valoraciones";
            }
            else
            {
                lblValoracion.Content = aspirante.ValoracionPromedio;
            }
            lblCorreo.Content = aspirante.CorreoElectronico;
        }

        public Modelo.clases.Aspirante Aspirante { get => aspirante; set => aspirante = value; }

        private void SolicitarServicio_Click(object sender, RoutedEventArgs e)
        {
            SolicitarServicio ventanaSolicitar = new SolicitarServicio(demandante, aspirante);
            ventanaSolicitar.ShowDialog();
        }

    }
}
