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

        observadorRespuesta notificacion; ///
        Boolean isNuevo = true; ///
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
            Uri uriImagen;
            Modelo.clases.Usuario user = new Modelo.clases.Usuario();
            Modelo.clases.Demandante demandante = new Modelo.clases.Demandante();

            user.RutaFotografia = rutaImagen;
            uriImagen = new Uri(user.RutaFotografia);
            user.Fotografia = System.IO.File.ReadAllBytes(uriImagen.LocalPath);
            MessageBox.Show(user.Fotografia.ToString());

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
                MessageBox.Show("Nombre Usuario: "+user.NombreUsuario+"\n"+"Constraseña"+user.Clave, "Credenciales");
                Login login = new Login();
                login.Show();
                this.Close();

            }
            else
            {
                //aqui poner si no se registrar
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

            }
        }
    }
}
