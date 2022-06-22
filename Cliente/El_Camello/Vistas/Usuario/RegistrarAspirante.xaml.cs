using El_Camello.Modelo.clases;
using El_Camello.Modelo.dao;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        Modelo.clases.Aspirante aspirante = null;
        ObservableCollection<Oficio> oficios = null; 

        string rutaImagen = "";
        string rutaVideo = "";
        public RegistrarAspirante()
        {
            InitializeComponent();
            oficios = new ObservableCollection<Oficio>();
            aspirante = new Modelo.clases.Aspirante();
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
                Uri uriVideo;
                tbRutaVideo.Text = selectorVideo.FileName;

                rutaVideo = selectorVideo.FileName;

                //uriVideo = new Uri(rutaVideo);
            }
            
        }


        private async void btnGuardarAspirante_Click(object sender, RoutedEventArgs e)
        {
            Uri uriImagen;
            Uri uriVideo;
            Modelo.clases.Usuario user = new Modelo.clases.Usuario();
            //Modelo.clases.Aspirante aspiranteRegistro = new Modelo.clases.Aspirante();

            user.RutaFotografia = rutaImagen;
            uriImagen = new Uri(user.RutaFotografia);
            user.Fotografia = System.IO.File.ReadAllBytes(uriImagen.LocalPath);

            aspirante.RutaVideo = rutaVideo;
            uriVideo = new Uri(aspirante.RutaVideo);
            aspirante.RegistroVideo = System.IO.File.ReadAllBytes(uriVideo.LocalPath);

            aspirante.NombreAspirante = tbNombreAspirante.Text;
            aspirante.Direccion = tbDireccion.Text;
            aspirante.FechaNacimiento = (DateTime)dpFechaNacimiento.SelectedDate;
            user.CorreoElectronico = tbCorreoElectronico.Text;
            aspirante.Telefono = tbCorreoElectronico.Text;
            user.NombreUsuario = tbNombreUsuario.Text;
            user.Clave = pbClave.Password;
            aspirante.Oficios = oficios.ToList();

            int resultado = await AspiranteDAO.PostAspirante(user, aspirante);
            if (resultado == 1)
            {
                MessageBox.Show("Registro en el sistema exitoso, favor de inciar con las credenciales registradas", "Operación exitosa");
                MessageBox.Show("Nombre Usuario: " + user.NombreUsuario + "\n" + "Constraseña" + user.Clave, "Credenciales");
                Login login = new Login();
                login.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocurrio un error al registrar tu perfil Aspirante", "¡Operación!");
            }
        }

        private void btnSeleccionarImagen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog selectorDocumento = new OpenFileDialog();
            selectorDocumento.Filter = "Imagen jpg|*.jpg";
            if (selectorDocumento.ShowDialog() == true)
            {
                Uri uriImagen;
                rutaImagen = selectorDocumento.FileName;

                uriImagen = new Uri(rutaImagen);
                imgFotografiaAspirante.Source = new BitmapImage(uriImagen);
            }

        }

        private void btnAgregarCategoria_Click(object sender, RoutedEventArgs e)
        {
            if (cbCategorias.SelectedIndex > -1 && cbExperienciaLaboral.SelectedIndex > -1)
            {
                Categoria categoria = (Categoria)cbCategorias.SelectedItem;
                int estaLista = oficios.ToList().FindIndex(x => x.IdCategoria == categoria.IdCategoria);
                if(estaLista == -1){
                    Oficio oficio = new Oficio();
                    oficio.IdCategoria = categoria.IdCategoria;
                    oficio.NombreCategoria = categoria.NombreCategoria;
                    oficio.Experiencia = cbExperienciaLaboral.SelectedValue.ToString();
                    oficios.Add(oficio);
                    dgExperienciaCategoria.ItemsSource = oficios;
                }
                else
                {
                    MessageBox.Show("oficio agregado anteriormente");

                }
            }
            else
            {
                MessageBox.Show("algun combo box exta vacio, verificar");
            }
            dgExperienciaCategoria.ItemsSource = oficios;
        }

        private void btnQuitarCategoria_Click(object sender, RoutedEventArgs e)
        {
            if (dgExperienciaCategoria.SelectedIndex > -1)
            {
                Oficio oficioSeleccionado = (Oficio) dgExperienciaCategoria.SelectedItem;
                oficios.Remove(oficioSeleccionado);
                dgExperienciaCategoria.ItemsSource = oficios;
            }
            else
            {
                MessageBox.Show("seleccionar un oficio");
            }
        }
    }
}
