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

        Modelo.clases.Usuario user = null;
        Modelo.clases.Aspirante aspirante = null;
        ObservableCollection<Oficio> oficios = null; 

        string rutaImagen = "";
        public RegistrarAspirante()
        {
            InitializeComponent();
            oficios = new ObservableCollection<Oficio>();
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

        private void btnGuardarAspirante_Click(object sender, RoutedEventArgs e)
        {
            
            user = new Modelo.clases.Usuario();
            aspirante = new Modelo.clases.Aspirante();
            //oficios = new Modelo.clases.Oficios();

            user.Clave = pwdClave.Password;
            user.NombreUsuario = tbNombreUsuario.Text;
            user.CorreoElectronico = tbCorreoElectronico.Text;
            aspirante.Oficios = oficios.ToList();
            //isertar a ruta imagen
            user.RutaFotografia = rutaImagen;
            aspirante.NombreAspirante = tbNombreAspirante.Text;
            aspirante.Direccion = tbDireccion.Text;
            aspirante.FechaNacimiento = (DateTime)dpFechaNacimiento.SelectedDate;
            aspirante.Telefono = tbtelefono.Text;
            //aspirante.RutaVideo = tbRutaVideo.Text;
            //aspirante.RutaCurriculum = tbRutaDocumento.Text;

            AspiranteDAO.PostAspirante(user, aspirante);
        }

        private void btnSeleccionarImagen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog selectorDocumento = new OpenFileDialog();
            selectorDocumento.Filter = "Imagen jpg|*.jpg";
            if (selectorDocumento.ShowDialog() == true)
            {
                rutaImagen = selectorDocumento.FileName;
            }
        }

        private void btnAgregarCategoria_Click(object sender, RoutedEventArgs e)
        {
            if (cbCategorias.SelectedIndex > -1 && cbExperienciaLaboral.SelectedIndex > -1)
            {
                Categoria categoria = (Categoria)cbCategorias.SelectedItem;
                int estaLista = oficios.ToList().FindIndex(x => x.IdCategoria == categoria.IdCategoria);
                MessageBox.Show(categoria.IdCategoria.ToString());
                if(estaLista == -1){
                    Oficio oficio = new Oficio();
                    oficio.IdCategoria = categoria.IdCategoria;
                    oficio.NombreCategoria = categoria.NombreCategoria;
                    oficio.Experiencia = cbExperienciaLaboral.SelectedValue.ToString();
                    MessageBox.Show(oficio.IdCategoria.ToString());
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
            MessageBox.Show(oficios.Count().ToString());
        }

        private void btnQuitarCategoria_Click(object sender, RoutedEventArgs e)
        {
            if (dgExperienciaCategoria.SelectedIndex > -1)
            {
                Oficio oficioSeleccionado = (Oficio) dgExperienciaCategoria.SelectedItem;
                oficios.Remove(oficioSeleccionado);
                //oficios.RemoveAt(oficioSeleccionado.IdCategoria);
                dgExperienciaCategoria.ItemsSource = oficios;
            }
            else
            {
                MessageBox.Show("seleccionar un oficio");
            }
        }
    }
}
