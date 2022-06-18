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

namespace El_Camello.Empleador
{
    /// <summary>
    /// Interaction logic for EvaluarApirante.xaml
    /// </summary>
    public partial class EvaluarApirante : Window
    {
        private Modelo.clases.Aspirante aspiranteEvaluar;
        private string token;
        List<string> valoraciones;

        public EvaluarApirante()
        {
            InitializeComponent();
        }

        public EvaluarApirante(Modelo.clases.Aspirante aspiranteEvaluar, string token)
        {
            this.aspiranteEvaluar = aspiranteEvaluar;
            this.token = token;

            InitializeComponent();
            cargarValoraciones();
            cargarAspiranteEvaluar();
        }

        private void cargarValoraciones()
        {
            valoraciones = new List<string>();
            cbValoraciones.Items.Clear();
            valoraciones.Add("1");
            valoraciones.Add("2");
            valoraciones.Add("3");
            valoraciones.Add("4");
            valoraciones.Add("5");

            cbValoraciones.ItemsSource = valoraciones;

        }

        private async void cargarAspiranteEvaluar() {

            lbNombre.Content = aspiranteEvaluar.NombreAspirante;
            Modelo.clases.Usuario user = await UsuarioDAO.getUsuario(aspiranteEvaluar.IdPerfilusuario, token);
            CargarImagen(user);
        }

        private void CargarImagen(Modelo.clases.Usuario usuarioConectado)
        {

            try
            {
                byte[] fotoPerfil = usuarioConectado.Fotografia;
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
                        this.imgAspirante.Source = imagen;
                    }
                }

            }
            catch (Exception)
            {
                imgAspirante.Source = null;
            }
        }

    }
}
