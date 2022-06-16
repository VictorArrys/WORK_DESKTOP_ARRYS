using El_Camello.Modelo.dao;
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
        Modelo.clases.Aspirante aspirante = null;
        public consultarPerfil()
        {
            InitializeComponent();
            aspirante = new Modelo.clases.Aspirante();
            cargarDatosAspirante();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private async void cargarDatosAspirante()
        {
            /*string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZFVzdWFyaW8iOjkwLCJjbGF2ZSI6IjEyMzQ1NiIsInRpcG8iOiJBc3BpcmFudGUiLCJpYXQiOjE2NTUzMjkzMjEsImV4cCI6MTY1NTQxNTcyMX0.qQ-5BohPBoWPdRXZ_vjPdGj5G7pWj9n8PNjXK6_J2aY";
            aspirante = await AspiranteDAO.GetAspirante(90, token);

            String urlCarpetaTemporal = System.Environment.GetEnvironmentVariable("TEMP");

            MessageBox.Show(urlCarpetaTemporal);*/
        }
    }
}
