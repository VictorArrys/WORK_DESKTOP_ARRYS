using El_Camello.Assets.utilerias;
using El_Camello.Modelo.clases;
using El_Camello.Modelo.dao;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;

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

<<<<<<< HEAD


            aspirante.RutaVideo = "";

            
            do
            {
                aspirante.RutaVideo = System.IO.Path.GetTempFileName().Replace(".tmp", ".mp4");
            } while (System.IO.File.Exists(aspirante.RutaVideo));
            
            MemoryStream_toFile.MemoryStreamToFile(aspirante.Video, aspirante.RutaVideo);
            meVideoAspirante.Source = new Uri(aspirante.RutaVideo);
            meVideoAspirante.Volume = 0.5;
            dgOficios.ItemsSource = aspirante.Oficios;
=======
            if (aspirante.Video != null)
            {
                aspirante.RutaVideo = "";

                do
                {
                    aspirante.RutaVideo = System.IO.Path.GetTempFileName().Replace(".tmp", ".mp4");
                } while (System.IO.File.Exists(aspirante.RutaVideo));

                MemoryStream_toFile.MemoryStreamToFile(aspirante.Video, aspirante.RutaVideo);
                meVideoAspirante.Source = new Uri(aspirante.RutaVideo);
                meVideoAspirante.Volume = 0.5;
            }
            
>>>>>>> a78dc6bde69978fad47eacb3763dd6dce8e9e088
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
