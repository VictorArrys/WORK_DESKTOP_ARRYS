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

namespace El_Camello.Vistas.Empleador
{
    /// <summary>
    /// Interaction logic for OfertasEmpleo.xaml
    /// </summary>
    public partial class OfertasEmpleo : Window
    {
        public OfertasEmpleo(Modelo.clases.Usuario usuarioConectado)
        {
            InitializeComponent();
            byte[] fotoPerfil = usuarioConectado.Fotografia;
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
}
