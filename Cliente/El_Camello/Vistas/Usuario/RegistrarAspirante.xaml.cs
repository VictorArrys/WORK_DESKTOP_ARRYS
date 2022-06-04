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

namespace El_Camello.Vistas.Usuario
{
    /// <summary>
    /// Lógica de interacción para RegistrarAspirante.xaml
    /// </summary>
    public partial class RegistrarAspirante : Window
    {
        public RegistrarAspirante()
        {
            InitializeComponent();
            CargarVentana();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            RegistroPerfil menuRegistro = new RegistroPerfil();
            menuRegistro.Show();
            this.Close();
        }

        private async void CargarVentana()
        {
            cbCategorias.ItemsSource =  await CategoriaDAO.GetCategorias();
            cbExperienciaLaboral.Items.Clear();
            cbExperienciaLaboral.Items.Add("1 a 4 meses");
            cbExperienciaLaboral.Items.Add("4 a 6 meses");
            cbExperienciaLaboral.Items.Add("6 meses a 1 año");
            cbExperienciaLaboral.Items.Add("1 a 6 años");
            cbExperienciaLaboral.Items.Add("Mayor a 6 años");
        }

        private void btnSeleccionarVideo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog selectorVideo = new OpenFileDialog();
            selectorVideo.Filter = "Archivo mp4|*.mp4";
            if (selectorVideo.ShowDialog() == true)
            {
                tbRutaVideo.Text = selectorVideo.FileName;
            }
            
        }

        private void btnSeleccionarDocumento_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog selectorDocumento = new OpenFileDialog();
            selectorDocumento.Filter = "Archivo pdf|*.pdf";
            if (selectorDocumento.ShowDialog() == true)
            {
                tbRutaDocumento.Text = selectorDocumento.FileName;
            }
        }
    }
}
