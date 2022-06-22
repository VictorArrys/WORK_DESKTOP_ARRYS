using El_Camello.Assets.utilerias;
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

namespace El_Camello.Aspirante
{
    /// <summary>
    /// Interaction logic for PerfilAspirante.xaml
    /// </summary>
    public partial class PerfilAspirante : Window
    {
        private int idAspirante;
        private string token;
        private Modelo.clases.Aspirante aspiranteConsultado;

        public PerfilAspirante(int idAspirante, string token)
        {
            this.idAspirante = idAspirante;
            this.token = token;

            InitializeComponent();

            cargarAspirante();
        }

        private void cargarAspirante()
        {
            obtenerAspirante();

            tbAspirante.Text = aspiranteConsultado.NombreAspirante;
            tbAspirante.IsEnabled = false;
            tbCorreo.Text = aspiranteConsultado.CorreoElectronico;
            tbCorreo.IsEnabled = false;
            tbDireccion.Text = aspiranteConsultado.Direccion;
            tbDireccion.IsEnabled = false;
            tbTelefono.Text = aspiranteConsultado.Telefono;
            tbTelefono.IsEnabled = false;


            aspiranteConsultado.RutaVideo = "";
            do
            {
                aspiranteConsultado.RutaVideo = System.IO.Path.GetTempFileName().Replace(".tmp", ".mp4");
            } while (System.IO.File.Exists(aspiranteConsultado.RutaVideo));

            MemoryStream_toFile.MemoryStreamToFile(aspiranteConsultado.Video, aspiranteConsultado.RutaVideo);
            meVideoAspirante.Source = new Uri(aspiranteConsultado.RutaVideo);


        }

        private async void obtenerAspirante()
        {
            aspiranteConsultado = await AspiranteDAO.GetAspirante(idAspirante, token);
            aspiranteConsultado.Video = await AspiranteDAO.GetVideo(aspiranteConsultado.IdPerfilusuario, token);


        }

        private void cerrarVentana_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
