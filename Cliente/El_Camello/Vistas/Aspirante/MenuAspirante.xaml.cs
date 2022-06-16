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

namespace El_Camello.Vistas.Aspirante
{
    /// <summary>
    /// Lógica de interacción para MenuAspirante.xaml
    /// </summary>
    public partial class MenuAspirante : Window
    {
        Modelo.clases.Aspirante perfilAspirante = null;
        public MenuAspirante(Modelo.clases.Usuario usuarioConectado)
        {
            InitializeComponent();
            perfilAspirante = new Modelo.clases.Aspirante();
            CargarMenuAspirante(usuarioConectado);
            
        }

        private async void CargarMenuAspirante(Modelo.clases.Usuario usuarioConectado)
        {
            int idPerfil = usuarioConectado.IdPerfilusuario;
            string token = usuarioConectado.Token;
            perfilAspirante = await AspiranteDAO.GetAspirante(idPerfil, token);
            //perfilAspirante = await AspiranteDAO.GetAspirante(usuarioConectado.IdPerfilusuario, usuarioConectado.Token);
            /*perfilAspirante.Clave = usuarioConectado.Clave;
            perfilAspirante.Estatus = usuarioConectado.Estatus;
            perfilAspirante.IdPerfilusuario = usuarioConectado.IdPerfilusuario;
            perfilAspirante.CorreoElectronico = usuarioConectado.CorreoElectronico;
            perfilAspirante.Fotografia = usuarioConectado.Fotografia;
            perfilAspirante.Tipo = usuarioConectado.Tipo;
            perfilAspirante.Token = usuarioConectado.Token;*/

            MessageBox.Show(perfilAspirante.Token);
            

            
            byte[] fotoPerfil = perfilAspirante.Fotografia;
            if (fotoPerfil != null)
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

            //pendiente si esta deshabilidtado o no
        }

        
    }
}
