using El_Camello.Modelo.dao;
using El_Camello.Modelo.interfaz;
using El_Camello.Vistas.Usuario;
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

namespace El_Camello.Vistas.Demandante
{
    /// <summary>
    /// Lógica de interacción para MenuDemandante.xaml
    /// </summary>
    public partial class MenuDemandante : Window, observadorRespuesta
    {
        Modelo.clases.Demandante demandante = null;
        public MenuDemandante(Modelo.clases.Usuario usuarioConectado)
        {
            InitializeComponent();
            CargarImagen(usuarioConectado);
            demandante = new Modelo.clases.Demandante();
            cargarDemandante(usuarioConectado);
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
                        this.imgFoto.Source = imagen;
                    }
                }

            }
            catch (Exception)
            {
                imgFoto.Source = null;
            }
        }

        private async void cargarDemandante(Modelo.clases.Usuario usuarioConectado)
        {
            demandante = await DemandanteDAO.getDemandante(usuarioConectado.IdPerfilusuario, usuarioConectado.Token);
            cbCategorias.ItemsSource = await CategoriaDAO.GetCategorias();
            demandante.Clave = usuarioConectado.Clave;
            demandante.CorreoElectronico = usuarioConectado.CorreoElectronico;
            demandante.Estatus = usuarioConectado.Estatus;
            demandante.NombreUsuario = usuarioConectado.NombreUsuario;
            demandante.Fotografia = usuarioConectado.Fotografia;
            demandante.Tipo = usuarioConectado.Tipo;
            demandante.Token = usuarioConectado.Token;
            MessageBox.Show(usuarioConectado.NombreUsuario);
        }

        private void btnEditarPerfil_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(demandante.Token);
            MessageBox.Show(demandante.NombreDemandante);
            MessageBox.Show(demandante.NombreUsuario);
            
            RegistrarDemandante registrarDemandante = new RegistrarDemandante(demandante, this);
            registrarDemandante.Show();
            this.Close();
        }

        public void actualizarInformacion(string operacion)
        {
            Console.WriteLine("Respuesta de formulario " + operacion);
        }
    }
}
