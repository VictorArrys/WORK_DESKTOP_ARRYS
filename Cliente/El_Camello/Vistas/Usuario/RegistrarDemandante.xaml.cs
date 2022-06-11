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

    public partial class RegistrarDemandante : Window
    {

        string rutaImagen = "";
        public RegistrarDemandante()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            RegistroPerfil menuRegistrarPerfil = new RegistroPerfil();
            menuRegistrarPerfil.Show();
            this.Close();
        }

        private async void btRegistrarDemandante_Click(object sender, RoutedEventArgs e)
        {
            Uri uriImagen;
            Modelo.clases.Usuario user = new Modelo.clases.Usuario();
            Modelo.clases.Demandante demandante = new Modelo.clases.Demandante();

            demandante.Nombre = tbNombreDemandante.Text;
            demandante.Direccion = tbDireccion.Text;
            demandante.FechaNacimiento = (DateTime)dpFechaNacimiento.SelectedDate;
            demandante.CorreoElectronico = tbCorreoElectronico.Text;
            demandante.Telefono = tbTelefono.Text;
            user.NombreUsuario = tbNombreUsuario.Text;
            user.Clave = pbContraseña.Password;
            user.RutaFotografia = rutaImagen;
            uriImagen = new Uri(user.RutaFotografia);
            user.Fotografia = System.IO.File.ReadAllBytes(uriImagen.LocalPath);

            int registro = await DemandanteDAO.PostDemandante(user, demandante);
            MessageBox.Show(registro.ToString());
        }

        private void btnSeleccionarImagen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog selectorImagen = new OpenFileDialog();
            selectorImagen.Filter = "Imagen jpg|*.jpg";
            if (selectorImagen.ShowDialog() == true)
            {
                Uri uriImagen;
                rutaImagen = selectorImagen.FileName;

                uriImagen = new Uri(rutaImagen);
                imgFotografiaDemandante.Source = new BitmapImage(uriImagen);

            }
        }
    }
}
