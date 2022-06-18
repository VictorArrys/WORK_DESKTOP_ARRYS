using El_Camello.Modelo.dao;
using El_Camello.Modelo.interfaz;
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
    public partial class RegistrarEmpleador : Window
    {
        observadorRespuesta notificacion;
        Boolean isNuevo = true;
        Boolean nuevaFotografia = true;
        string rutaImagen = "";
        Modelo.clases.Empleador empleador = null;


        public RegistrarEmpleador()
        {
            InitializeComponent();

        }

        public RegistrarEmpleador(observadorRespuesta notificacion) : this()
        {
            this.notificacion = notificacion;
        }

        public RegistrarEmpleador(Modelo.clases.Empleador empleador, observadorRespuesta notificacion) : this(notificacion)
        {
            this.empleador = empleador;
            isNuevo = false;
            cargarInformacionEmpleador(empleador);
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            RegistroPerfil menuRegistrarPerfil = new RegistroPerfil();
            menuRegistrarPerfil.Show();
            this.Close();
        }


        private void cargarInformacionEmpleador(Modelo.clases.Empleador empleador)
        {
            tbNombreOrganizacion.Text = empleador.NombreOrganizacion;
            tbNombre.Text = empleador.NombreUsuario;
            tbDireccion.Text = empleador.Direccion;
            dpFechaNacimiento.SelectedDate = empleador.FechaNacimiento;
            cargarImagen(empleador.Fotografia);
            tbCorreoElectronico.Text = empleador.CorreoElectronico;
            tbTelefono.Text = empleador.Telefono;
            tbNombreUsuario.Text = empleador.NombreUsuario;
            pbConstraseña.Password = empleador.Clave;
            pbConfirmarContraseña.Password = empleador.Clave;
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
                        this.imgFotografiaEmpleador.Source = imagen;
                    }
                }

            }
            catch (Exception)
            {
                imgFotografiaEmpleador.Source = null;
            }
        }

        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (isNuevo)
            {
                if (validarCampos())
                {
                    Uri uriImagen;
                    Modelo.clases.Usuario usuario = new Modelo.clases.Usuario();
                    Modelo.clases.Empleador empleador = new Modelo.clases.Empleador();

                    usuario.RutaFotografia = rutaImagen;
                    uriImagen = new Uri(usuario.RutaFotografia);
                    usuario.Fotografia = System.IO.File.ReadAllBytes(uriImagen.LocalPath);

                    empleador.NombreOrganizacion = tbNombreOrganizacion.Text;
                    empleador.NombreEmpleador = tbNombre.Text;
                    empleador.Direccion = tbDireccion.Text;
                    empleador.FechaNacimiento = (DateTime)dpFechaNacimiento.SelectedDate;
                    usuario.CorreoElectronico = tbCorreoElectronico.Text;
                    empleador.Telefono = tbTelefono.Text;
                    usuario.NombreUsuario = tbNombreUsuario.Text;
                    usuario.Clave = pbConstraseña.Password;
                    usuario.Estatus = 1;

                    int resultado = await EmpleadorDAO.PostEmpleador(usuario, empleador);

                    if (resultado == 1)
                    {
                        MessageBox.Show("Registro en el sistema exitoso, favor de inciar con las credenciales registradas", "Operación exitosa");
                        MessageBox.Show("Nombre Usuario: " + usuario.NombreUsuario + "\n" + "Constraseña" + usuario.Clave, "Credenciales");
                        Login login = new Login();
                        login.Show();
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error al registrar tu perfil empleador", "¡Operación!");
                    }
                }
                else
                {
                    MessageBox.Show("Al registrar tu perfil verifica que los campos no esten vacios. ", "¡Operación!");
                }


                
            }
            else
            {
                Modelo.clases.Empleador modificarEmpleador = new Modelo.clases.Empleador();

                if (nuevaFotografia)
                {
                    Uri uriImagen;
                    modificarEmpleador.RutaFotografia = rutaImagen;
                    uriImagen = new Uri(modificarEmpleador.RutaFotografia);
                    modificarEmpleador.Fotografia = System.IO.File.ReadAllBytes(uriImagen.LocalPath);
                }
                else
                {
                    byte[] fotografia;
                    fotografia = empleador.Fotografia;
                    modificarEmpleador.Fotografia = fotografia;
                }

                modificarEmpleador.NombreOrganizacion = tbNombreOrganizacion.Text;
                modificarEmpleador.NombreEmpleador = tbNombre.Text;
                modificarEmpleador.Direccion = tbDireccion.Text;
                modificarEmpleador.FechaNacimiento = (DateTime)dpFechaNacimiento.SelectedDate;
                modificarEmpleador.CorreoElectronico = tbCorreoElectronico.Text;
                modificarEmpleador.Telefono = tbTelefono.Text;
                modificarEmpleador.NombreUsuario = tbNombreUsuario.Text;
                modificarEmpleador.Clave = pbConstraseña.Password;
                modificarEmpleador.Estatus = empleador.Estatus;
                modificarEmpleador.IdPerfilusuario = empleador.IdPerfilusuario;
                modificarEmpleador.IdPerfilEmpleador = empleador.IdPerfilEmpleador;
                modificarEmpleador.Token = empleador.Token;
                int resultado = await EmpleadorDAO.putEmpleador(modificarEmpleador);
                if (resultado == 1)
                {
                    Modelo.clases.Usuario usuario = null;
                    usuario = await UsuarioDAO.getUsuario(modificarEmpleador.IdPerfilusuario, modificarEmpleador.Token);
                    usuario.Token = modificarEmpleador.Token;
                    notificacion.actualizarInformacion(usuario);
                    MessageBox.Show("Actualización de tu perfil exitosa", "Operacion");
                    this.Close();
                }
                else
                {
                    ///
                }
            }
        }

        private bool validarCampos()
        {
            bool validar = false;
            if (tbNombreOrganizacion.Text == "")
            {
                validar = false;
            }else if (tbNombre.Text == "")
            {
                validar = false;
            }else if (tbDireccion.Text == "")
            {
                validar = false;
            }else if (dpFechaNacimiento.SelectedDate == null)
            {
                validar = false;
            }else if (tbCorreoElectronico.Text == "")
            {
                validar = false;
            }else if (tbTelefono.Text == "")
            {
                validar = false;
            }else if (tbNombreUsuario.Text == "")
            {
                validar = false;
            }else if (pbConstraseña.Password != "" || pbConfirmarContraseña.Password != "")
            {
                if (pbConstraseña.Password != pbConfirmarContraseña.Password)
                {
                    MessageBox.Show("Por favor introducir la misma contraseña en ambos campos para confirmar", "¡Operacion!");
                    validar = false;
                }else if (imgFotografiaEmpleador.Source == null)
                {
                    MessageBox.Show("Por favor seleccionar una foto de perfil para tu cuenta, preferentemente una fotografia personal","¡Operación!");
                    validar = false;
                }
                else
                {
                    validar = true;
                }
            }
            return validar;
        }

        private void btnSeleccionarFotografia_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog selectorImagen = new OpenFileDialog();
            selectorImagen.Filter = "Imagen jpg|*.jpg";
            if (selectorImagen.ShowDialog() == true)
            {
                Uri uriImagen;
                rutaImagen = selectorImagen.FileName;

                uriImagen = new Uri(rutaImagen);
                imgFotografiaEmpleador.Source = new BitmapImage(uriImagen);
                nuevaFotografia = true;
            }
        }
    }
}
