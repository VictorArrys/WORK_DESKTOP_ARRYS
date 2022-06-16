using El_Camello.Modelo.interfaz;
using El_Camello.Assets.utilerias;
using El_Camello.Modelo.clases;
using El_Camello.Modelo.dao;
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

namespace El_Camello.Vistas.Empleador
{
    /// <summary>
    /// Interaction logic for OfertasEmpleo.xaml
    /// </summary>
    public partial class OfertasEmpleo : Window, observadorRespuesta
    {
        private int idPerfilEmpleador;
        private string token;
        List<OfertaEmpleo> ofertasTabla = new List<OfertaEmpleo>();
        Modelo.clases.Empleador empleador = null;
        MensajesSistema error;

        public OfertasEmpleo(Modelo.clases.Usuario usuarioConectado, int idPerfilEmpleador)
        {
            this.idPerfilEmpleador = idPerfilEmpleador;
            this.token = usuarioConectado.Token;

            InitializeComponent();
            cargarIinformacionUsuario(usuarioConectado);
            CargarOfertasTabla();
            
        }

        private async void CargarOfertasTabla()
        {
            //aqui pasar el token que viene desde el inicio de seción
            try
            {
                ofertasTabla = await OfertaEmpleoDAO.GetOfertasEmpleos(idPerfilEmpleador, token);

                dgOfertasEmpleo.ItemsSource = ofertasTabla;
            }
            catch (Exception exceptionGetList)
            {
                error = new MensajesSistema("Error", "Hubo un error al intentar cargar las ofertas de empleo, favor de intentar más tarde", exceptionGetList.StackTrace, exceptionGetList.Message);
                error.ShowDialog();
            }
        }

        private void cargarIinformacionUsuario(Modelo.clases.Usuario usuarioConectado)
        {
            CargarEmpleador(usuarioConectado);
        }


        private void CargarImagen(Modelo.clases.Usuario usuarioConectado)
        {

            try
            {
                byte[] fotoPerfil = usuarioConectado.Fotografia;
                if (fotoPerfil == null)
                {
                    fotoPerfil = null;
                }else if (fotoPerfil.Length > 0)
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

        private async void CargarEmpleador(Modelo.clases.Usuario usuarioConectado)
        {
            empleador = await EmpleadorDAO.getEmpleador(usuarioConectado.IdPerfilusuario, usuarioConectado.Token);
            CargarImagen(usuarioConectado);
            empleador.Clave = usuarioConectado.Clave;
            empleador.CorreoElectronico = usuarioConectado.CorreoElectronico;
            empleador.Estatus = usuarioConectado.Estatus;
            empleador.NombreUsuario = usuarioConectado.NombreUsuario;
            empleador.Fotografia = usuarioConectado.Fotografia;
            empleador.Tipo = usuarioConectado.Tipo;
            empleador.Token = usuarioConectado.Token;
            empleador.IdPerfilusuario = usuarioConectado.IdPerfilusuario;
           
        }

        private void btnEditarPerfil_Click(object sender, RoutedEventArgs e)
        {
            RegistrarEmpleador registrarEmpleador = new RegistrarEmpleador(empleador, this);
            registrarEmpleador.ShowDialog();
        }

        public void actualizarInformacion(Modelo.clases.Usuario usuarioContectado)
        {
            CargarEmpleador(usuarioContectado);
        }

        private void btnDesactivarPerfil_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnActivarPerfil_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMensajeria_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRegistrarOferta_Click(object sender, RoutedEventArgs e)
        {
            RegistroOfertaEmpleo ventanaRegistroOferta = new RegistroOfertaEmpleo(this,idPerfilEmpleador, token);
            ventanaRegistroOferta.ShowDialog();
            //actualizar tabla
        }

        private void btnConsultarEmpleo_Click(object sender, RoutedEventArgs e)
        {
            int indiceSeleccion = dgOfertasEmpleo.SelectedIndex;

            if (indiceSeleccion >= 0)
            {
                OfertaEmpleo ofertaEmpleoConsultar = ofertasTabla[indiceSeleccion];

                ConsultarOfertaEmpleo ventanaConsultarOferta = new ConsultarOfertaEmpleo(ofertaEmpleoConsultar.IdOfertaEmpleo, token);
                ventanaConsultarOferta.ShowDialog();
            }
            else
            {
                error = new MensajesSistema("AccionInvalida", "La acción que ha realizado es invalida", "Intento de consultar oferta de empleo", "Selecciona una oferta de empleo para poder consultarla posteriormente");
                error.ShowDialog();
            }
        }

        private void btnModificarOferta_Click(object sender, RoutedEventArgs e)
        {
            int indiceSeleccion = dgOfertasEmpleo.SelectedIndex;

            if (indiceSeleccion >= 0)
            {
                OfertaEmpleo ofertaEmpleoEditar = ofertasTabla[indiceSeleccion];


                RegistroOfertaEmpleo ventanaActualizarOferta = new RegistroOfertaEmpleo(this, idPerfilEmpleador, ofertaEmpleoEditar.IdOfertaEmpleo, token);
                ventanaActualizarOferta.ShowDialog();

            }
            else
            {
                error = new MensajesSistema("AccionInvalida", "La acción que ha realizado es invalida", "Intento de modificar oferta de empleo", "Selecciona una oferta de empleo para poder editarla posteriormente");
                error.ShowDialog();
            }

            
        }

        private void btnConsultarSolicitudes_Click(object sender, RoutedEventArgs e)
        {
            int indiceSeleccion = dgOfertasEmpleo.SelectedIndex;

            if (indiceSeleccion >= 0)
            {
                OfertaEmpleo ofertaEmpleoEditar = ofertasTabla[indiceSeleccion];

                SolcitudesEmpleos ventanaSolicitudes = new SolcitudesEmpleos(token, ofertaEmpleoEditar.IdOfertaEmpleo);
                ventanaSolicitudes.ShowDialog();
            }
            else
            {
                error = new MensajesSistema("AccionInvalida", "La acción que ha realizado es invalida", "Intento de consultar solicitudes", "Selecciona una oferta de empleo para poder consultarla posteriormente");
                error.ShowDialog();
            }

        }

        private void btnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {

        }

        public void actualizarInformacion(string operacion)
        {
            ofertasTabla.Clear();
            CargarOfertasTabla();
        }
    }
}
