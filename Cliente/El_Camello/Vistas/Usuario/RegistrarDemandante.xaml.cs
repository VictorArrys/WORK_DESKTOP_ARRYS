using El_Camello.Modelo.dao;
using El_Camello.Modelo.interfaz;
using El_Camello.Vistas.Demandante;
using Microsoft.Win32;
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

namespace El_Camello.Vistas.Usuario
{

    public partial class RegistrarDemandante : Window
    {

        observadorRespuesta notificacion; 
        Boolean isNuevo = true;
        Boolean nuevaFotografia = true;
        string rutaImagen = "";
        Modelo.clases.Demandante demandante = null;

        public RegistrarDemandante()
        {
            InitializeComponent();

        }

        public RegistrarDemandante(observadorRespuesta notificacion) :this()
        {
            this.notificacion = notificacion;
        }

        public RegistrarDemandante(Modelo.clases.Demandante demandante, observadorRespuesta notificacion) : this(notificacion)
        {
            this.demandante = demandante;
            isNuevo = false;
            cargarInformacionDemandante(demandante);
        }

        private void cargarInformacionDemandante(Modelo.clases.Demandante demandante)
        {
            tbNombreDemandante.Text = demandante.NombreDemandante;
            tbDireccion.Text = demandante.Direccion;
            dpFechaNacimiento.SelectedDate = demandante.FechaNacimiento;
            tbCorreoElectronico.Text = demandante.CorreoElectronico;
            cargarImagen(demandante.Fotografia);
            tbNombreUsuario.Text = demandante.NombreUsuario;
            pbContraseña.Password = demandante.Clave;
            pbConfirmarConstraseña.Password = demandante.Clave;
            tbTelefono.Text = demandante.Telefono;
            nuevaFotografia = false;
            btnCancelar.IsEnabled = false;

        }

        private void cargarImagen(Byte[] fotografia)
        {
            try
            {
                byte[] fotoPerfilEdicion = fotografia;
                if (fotoPerfilEdicion == null)
                {
                    fotoPerfilEdicion = null;
                }
                else if (fotoPerfilEdicion.Length > 0)
                {
                    using (var memoryStream = new System.IO.MemoryStream(fotoPerfilEdicion))
                    {
                        var imagen = new BitmapImage();
                        imagen.BeginInit();
                        imagen.CacheOption = BitmapCacheOption.OnLoad;
                        imagen.StreamSource = memoryStream;
                        imagen.EndInit();
                        this.imgFotografiaDemandante.Source = imagen;
                    }
                }

            }
            catch (Exception)
            {
                imgFotografiaDemandante.Source = null;
            }
        }


        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            RegistroPerfil menuRegistrarPerfil = new RegistroPerfil();
            menuRegistrarPerfil.Show();
            this.Close();
        }

        private async void btRegistrarDemandante_Click(object sender, RoutedEventArgs e)
        {
            if (isNuevo)
            {
                Uri uriImagen;
                Modelo.clases.Usuario user = new Modelo.clases.Usuario();
                Modelo.clases.Demandante demandante = new Modelo.clases.Demandante();

                user.RutaFotografia = rutaImagen;
                uriImagen = new Uri(user.RutaFotografia);
                user.Fotografia = System.IO.File.ReadAllBytes(uriImagen.LocalPath);

                demandante.NombreDemandante = tbNombreDemandante.Text;
                demandante.Direccion = tbDireccion.Text;
                demandante.FechaNacimiento = (DateTime)dpFechaNacimiento.SelectedDate;
                user.CorreoElectronico = tbCorreoElectronico.Text;
                user.Estatus = 1;
                demandante.Telefono = tbTelefono.Text;
                user.NombreUsuario = tbNombreUsuario.Text;
                user.Clave = pbContraseña.Password;
                int registro = await DemandanteDAO.PostDemandante(user, demandante);
                if (registro == 1)
                {
                    MessageBox.Show("Registro en el sistema exitoso, favor de inciar con las credenciales registradas", "Operación exitosa");
                    MessageBox.Show("Nombre Usuario: " + user.NombreUsuario + "\n" + "Constraseña" + user.Clave, "Credenciales");
                    Login login = new Login();
                    login.Show();
                    this.Close();

                }
                else
                {
                    //aqui poner si no se registrar
                }

            }
            else
            {
                Modelo.clases.Usuario modificarUsuario = new Modelo.clases.Usuario();
                Modelo.clases.Demandante modificarDemandante = new Modelo.clases.Demandante();
                if (nuevaFotografia)
                {
                    Uri uriImagen;
                    modificarUsuario.RutaFotografia = rutaImagen;
                    uriImagen = new Uri(modificarUsuario.RutaFotografia);
                    modificarUsuario.Fotografia = System.IO.File.ReadAllBytes(uriImagen.LocalPath);
                    MessageBox.Show(modificarUsuario.Fotografia.ToString());
                }
                else
                {
                    byte[] fotografia;
                    fotografia = demandante.Fotografia;
                    modificarUsuario.Fotografia = fotografia;
                }

                modificarDemandante.NombreDemandante = tbNombreDemandante.Text;
                modificarDemandante.Direccion = tbDireccion.Text;
                modificarDemandante.FechaNacimiento = (DateTime)dpFechaNacimiento.SelectedDate;
                modificarUsuario.CorreoElectronico = tbCorreoElectronico.Text;
                modificarUsuario.Estatus = 1;
                modificarDemandante.Telefono = tbTelefono.Text;
                modificarUsuario.NombreUsuario = tbNombreUsuario.Text;
                modificarUsuario.Clave = pbContraseña.Password;
                modificarUsuario.Token = demandante.Token;
                modificarUsuario.IdPerfilusuario = demandante.IdPerfilusuario;
                modificarDemandante.IdDemandante = demandante.IdDemandante;
                int resultado = await DemandanteDAO.putDemandante(modificarUsuario, modificarDemandante);
                if (resultado == 1)
                {
                    Modelo.clases.Usuario usuario = null;
                    usuario = await UsuarioDAO.getUsuario(modificarUsuario.IdPerfilusuario, modificarUsuario.Token);
                    usuario.Token = demandante.Token;
                    notificacion.actualizarInformacion(usuario);
                    MessageBox.Show("Actualización de tu perfil exitosa", "Operacion");
                    this.Close();
                }
                else
                {
                    //poner aqui cuando no entra
                }
            }
            

        }

        private void btnSeleccionarImagen_Click(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog selectorImagen = new OpenFileDialog();
            selectorImagen.Filter = "Imagen jpg|*.jpg";
            if (selectorImagen.ShowDialog() == true)
            {
                Uri uriImagen;
                rutaImagen = selectorImagen.FileName;

                uriImagen = new Uri(rutaImagen);
                imgFotografiaDemandante.Source = new BitmapImage(uriImagen);
                nuevaFotografia = true;

            }
        }
    }
}
