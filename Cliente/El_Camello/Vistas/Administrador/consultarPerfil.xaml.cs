using Microsoft.Win32;
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
    /// Lógica de interacción para consultarPerfil.xaml
    /// </summary>
    public partial class consultarPerfil : Window
    {
        string rutaVideo = "";
        Uri video = null;
        public consultarPerfil()
        {
            InitializeComponent();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog selectorVideo = new OpenFileDialog();
            selectorVideo.Filter = "Archivo mp4|*.mp4";
            if (selectorVideo.ShowDialog() == true)
            {
                rutaVideo = selectorVideo.FileName;
            }

            video = new Uri(rutaVideo);
            meVideoAspirante.Source = video;

        }
    }
}
