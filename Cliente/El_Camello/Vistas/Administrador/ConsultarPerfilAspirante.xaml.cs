using El_Camello.Assets.utilerias;
using El_Camello.Modelo.dao;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Lógica de interacción para ConsultarPerfilAspirante.xaml
    /// </summary>
    public partial class ConsultarPerfilAspirante : Window
    {
        Modelo.clases.Aspirante aspirante = null;
        string token = null;


        public ConsultarPerfilAspirante(Modelo.clases.Usuario usuarioSeleccionado, string token)
        {
            InitializeComponent();
            aspirante = new Modelo.clases.Aspirante();
            this.token = token;
            cargarInformacionAspirante(usuarioSeleccionado);

            
        }

        private async void cargarInformacionAspirante(Modelo.clases.Usuario usuarioSeleccionado)
        {
            aspirante = await AspiranteDAO.GetAspirante(usuarioSeleccionado.IdPerfilusuario, token);
            aspirante.Video = await AspiranteDAO.GetVideo(usuarioSeleccionado.IdPerfilusuario, token);


            aspirante.RutaVideo = "";

            do
            {
                aspirante.RutaVideo = System.IO.Path.GetTempFileName().Replace(".tmp", ".mp4");
            } while (System.IO.File.Exists(aspirante.RutaVideo));

            MemoryStream_toFile.MemoryStreamToFile(aspirante.Video, aspirante.RutaVideo);
            meVideoAspirante.Source = new Uri(aspirante.RutaVideo);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
