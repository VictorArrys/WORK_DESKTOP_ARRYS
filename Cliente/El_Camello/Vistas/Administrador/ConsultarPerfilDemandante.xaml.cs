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

namespace El_Camello.Vistas.Administrador
{
    /// <summary>
    /// Lógica de interacción para ConsultarPerfilDemandante.xaml
    /// </summary>
    public partial class ConsultarPerfilDemandante : Window
    {
        Modelo.clases.Usuario usuario = null;
        Modelo.clases.Demandante demandante = null;
        string token = null;
        
        public ConsultarPerfilDemandante(Modelo.clases.Usuario usuarioSolicitado)
        {
            InitializeComponent();
            
            usuario = new Modelo.clases.Usuario();
            demandante = new Modelo.clases.Demandante();
            cargarInformacionDemandante(usuarioSolicitado);
            this.token = usuarioSolicitado.Token;
        }

        private async void cargarInformacionDemandante(Modelo.clases.Usuario usuario)
        {
            usuario = await UsuarioDAO.getUsuario(usuario.IdPerfilusuario, usuario.Token);
            demandante = await DemandanteDAO.getDemandante(usuario.IdPerfilusuario, token);
            cargarImagen(usuario.Fotografia);
            lbNombreDemandante.Content = demandante.NombreDemandante;
            tbDireccion.Text = demandante.Direccion;
            dpFechaNacimiento.SelectedDate = demandante.FechaNacimiento;
            tbTelefono.Text = demandante.Telefono;
            tbNombreUsuario.Text = usuario.NombreUsuario;
            tbCorreoElectronico.Text = usuario.CorreoElectronico;
            tbClave.Text = usuario.Clave;
            tbEstatus.Text = usuario.EstatusUsuario;
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

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
