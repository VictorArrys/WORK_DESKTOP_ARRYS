using El_Camello.Assets.utilerias;
using El_Camello.Modelo.clases;
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
        Modelo.clases.Usuario usuario = null;
        string token = null;


        public ConsultarPerfilAspirante(Modelo.clases.Usuario usuarioSeleccionado, string token)
        {
            InitializeComponent();
            aspirante = new Modelo.clases.Aspirante();
            usuario = new Modelo.clases.Usuario();
            this.token = token;
            cargarInformacionAspirante(usuarioSeleccionado);

            
        }

        private async void cargarInformacionAspirante(Modelo.clases.Usuario usuarioSeleccionado) // cargar categorias y donde sea la categoria ponerle el nombre
        {
            List<Categoria> categorias = new List<Categoria>();
            usuario = await UsuarioDAO.getUsuario(usuarioSeleccionado.IdPerfilusuario, token);
            aspirante = await AspiranteDAO.GetAspirante(usuarioSeleccionado.IdPerfilusuario, token);
            aspirante.Video = await AspiranteDAO.GetVideo(aspirante.IdAspirante, token);
            cargarImagen(usuario.Fotografia);
            aspirante.IdPerfilusuario = usuario.IdPerfilusuario;
            lbNombreAspirante.Content = aspirante.NombreAspirante;
            tbDireccion.Text = aspirante.Direccion;
            dpFechaNacimiento.SelectedDate = aspirante.FechaNacimiento;
            tbCorreoElectronico.Text = usuario.CorreoElectronico;
            tbTelefono.Text = aspirante.Telefono;
            tbNombreUsuario.Text = usuario.NombreUsuario;
            tbConstraseña.Text = usuario.Clave;            
            categorias = await CategoriaDAO.GetCategorias();
            for (int x = 0; x < aspirante.Oficios.Count; x++)
            {
                for (int y = 0; y < categorias.Count; y++)
                {
                    if (categorias[y].IdCategoria == aspirante.Oficios[x].IdCategoria)
                    {
                        aspirante.Oficios[x].NombreCategoria = categorias[y].NombreCategoria;
                        break;
                    }
                }
            }

            dgOficios.ItemsSource = aspirante.Oficios;



            aspirante.RutaVideo = "";

            do
            {
                aspirante.RutaVideo = System.IO.Path.GetTempFileName().Replace(".tmp", ".mp4");
            } while (System.IO.File.Exists(aspirante.RutaVideo));

            MemoryStream_toFile.MemoryStreamToFile(aspirante.Video, aspirante.RutaVideo);
            meVideoAspirante.Source = new Uri(aspirante.RutaVideo);
            meVideoAspirante.Volume = 0.5;
            dgOficios.ItemsSource = aspirante.Oficios;
        }

        private void cargarImagen(byte[] fotografia)
        {
            try
            {
                byte[] fotoPerfil = fotografia;
                if (fotoPerfil == null)
                {
                    fotoPerfil = null;
                }
                else if (fotoPerfil.Length > 0)
                {
                    using (var memoryStream = new System.IO.MemoryStream(fotoPerfil))
                    {
                        var imagen = new BitmapImage();
                        imagen.BeginInit();
                        imagen.CacheOption = BitmapCacheOption.OnLoad;
                        imagen.StreamSource = memoryStream;
                        imagen.EndInit();
                        this.imgFoto.Source = imagen;
                    }
                }
            }
            catch (Exception)
            {
                imgFoto.Source = null;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
