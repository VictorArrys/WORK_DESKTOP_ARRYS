using El_Camello.Modelo.dao;
using El_Camello.Modelo.interfaz;
using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

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
                if (validarCampos(isNuevo))
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
                        MessageBox.Show("Ocurrio un error al registrar tu perfil demanndante","¡Operación!");
                    }
                }
                else
                {
                    MessageBox.Show("Al registrar tu perfil verifica que los campos no esten vacios. ", "¡Operación!");
                }

            }
            else
            {
                if (validarCampos(isNuevo))
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
                        MessageBox.Show("Ocurrio un error al actualizar tu perfil", "¡Operación!");
                        this.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Al registrar tu perfil verifica que los campos no esten vacios. ", "¡Operación!");
                }
                
            }

        }

        private bool validarCampos(bool isNuevo)
        {
            bool validar = false;
            DateTime fechaActual = DateTime.Now;
            if (isNuevo)
            {
                if (tbNombreDemandante.Text == "")
                {
                    validar = false;
                }
                else if (tbDireccion.Text == "")
                {
                    validar = false;
                }
                else if (dpFechaNacimiento.SelectedDate == null)
                {
                    validar = false;
                }
                else if (dpFechaNacimiento.SelectedDate >= fechaActual)
                {
                    validar = false;
                    MessageBox.Show("Tu fecha de nacimiento no puede ser mayor a la fecha actual", "¡Operación!");
                }
                else if (dpFechaNacimiento.SelectedDate < fechaActual)
                {
                    DateTime nacimiento = (DateTime)dpFechaNacimiento.SelectedDate;
                    int edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;
                    if (edad < 18)
                    {
                        MessageBox.Show("Para poder completar tu registro se debera tener con un minimo de 18 años cumplidos", "¡Operación!");
                        validar = false;
                    }
                    else
                    {
                        if (tbCorreoElectronico.Text == "")
                        {
                            validar = false;
                        }
                        else if (tbTelefono.Text == "")
                        {
                            validar = false;
                        }
                        else if (tbTelefono.Text.Count() >= 11 || tbTelefono.Text.Count() < 10)
                        {
                            MessageBox.Show("Tu número telefonico debera ser exactamente de 10 digitos", "¡Operación!");
                            validar = false;
                        }
                        else if (tbNombreUsuario.Text == "")
                        {
                            validar = false;
                        }
                        else if (pbContraseña.Password != "" || pbConfirmarConstraseña.Password != "")
                        {
                            if (pbContraseña.Password != pbConfirmarConstraseña.Password)
                            {
                                MessageBox.Show("Por favor introducir la misma contraseña en ambos campos para confirmar", "¡Operacion!");
                                validar = false;
                            }
                            else if (imgFotografiaDemandante.Source == null)
                            {
                                MessageBox.Show("Por favor seleccionar una foto de perfil para tu cuenta, preferentemente una fotografia personal", "¡Operación!");
                                validar = false;
                            }
                            else
                            {
                                validar = true;
                            }
                        }
                    }
                }
            }
            else
            {
                if (tbNombreDemandante.Text == "")
                {
                    validar = false;
                }
                else if (tbDireccion.Text == "")
                {
                    validar = false;
                }
                else if (dpFechaNacimiento.SelectedDate == null)
                {
                    validar = false;
                }
                else if (dpFechaNacimiento.SelectedDate >= fechaActual)
                {
                    validar = false;
                    MessageBox.Show("Tu fecha de nacimiento no puede ser mayor a la fecha actual", "¡Operación!");
                }
                else if (dpFechaNacimiento.SelectedDate < fechaActual)
                {
                    DateTime nacimiento = (DateTime)dpFechaNacimiento.SelectedDate;
                    int edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;
                    if (edad < 18)
                    {
                        MessageBox.Show("Para poder completar tu registro se debera tener con un minimo de 18 años cumplidos", "¡Operación!");
                        validar = false;
                    }
                    else
                    {
                        if (tbCorreoElectronico.Text == "")
                        {
                            validar = false;
                        }
                        else if (tbTelefono.Text == "")
                        {
                            validar = false;
                        }
                        else if (tbTelefono.Text.Count() >= 11 || tbTelefono.Text.Count() < 10)
                        {
                            MessageBox.Show("Tu número telefonico debera ser exactamente de 10 digitos", "¡Operación!");
                            validar = false;
                        }
                        else if (tbNombreUsuario.Text == "")
                        {
                            validar = false;
                        }
                        else if (pbContraseña.Password != "" || pbConfirmarConstraseña.Password != "")
                        {
                            if (pbContraseña.Password != pbConfirmarConstraseña.Password)
                            {
                                MessageBox.Show("Por favor introducir la misma contraseña en ambos campos para confirmar", "¡Operacion!");
                                validar = false;
                            }
                            else if (imgFotografiaDemandante.Source == null)
                            {
                                MessageBox.Show("Por favor seleccionar una foto de perfil para tu cuenta, preferentemente una fotografia personal", "¡Operación!");
                                validar = false;
                            }
                            else if (tbNombreDemandante.Text == demandante.NombreDemandante && tbDireccion.Text == demandante.Direccion && tbCorreoElectronico.Text == demandante.CorreoElectronico &&
                                tbTelefono.Text == demandante.Telefono && tbNombreUsuario.Text == demandante.NombreUsuario && pbContraseña.Password == demandante.Clave &&
                                pbConfirmarConstraseña.Password == demandante.Clave)
                            {
                                MessageBox.Show("Antes de actualizar tu perfil es necesario modificar almenos un campo.", "¡Operación!");
                                validar = false;
                            }
                            else
                            {
                                validar = true;
                            }
                        }
                    }
                }
            }
            
            return validar;
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
