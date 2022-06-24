using El_Camello.Modelo.clases;
using El_Camello.Modelo.dao;
using El_Camello.Modelo.interfaz;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    /// <summary>
    /// Lógica de interacción para RegistrarAspirante.xaml
    /// </summary>
    public partial class RegistrarAspirante : Window
    {

        observadorRespuesta notificacion;
        bool isNuevo = true;
        bool nuevaFotografia = true;
        bool nuevoVideo = true;
        int idAspiranteEdicion = 0;
        Modelo.clases.Aspirante aspirante = null;
        List<Categoria> categorias = null;
        ObservableCollection<Oficio> oficios = null;

        string rutaImagen = "";
        string rutaVideo = "";
        public RegistrarAspirante()
        {
            InitializeComponent();
            oficios = new ObservableCollection<Oficio>();
            aspirante = new Modelo.clases.Aspirante();
            CargarVentana();
        }

        public RegistrarAspirante(observadorRespuesta notificacion) :this()
        {
            this.notificacion = notificacion;
        }

        public RegistrarAspirante(Modelo.clases.Aspirante aspirante, observadorRespuesta notificacion) :this(notificacion)
        {
            this.aspirante = aspirante;
            isNuevo = false;
            cargarInformacionAspirante(aspirante);
        }

        public void cargarInformacionAspirante(Modelo.clases.Aspirante aspirante)
        {
            tbNombreAspirante.Text = aspirante.NombreAspirante;
            tbDireccion.Text = aspirante.Direccion;
            dpFechaNacimiento.SelectedDate = aspirante.FechaNacimiento;
            tbCorreoElectronico.Text = aspirante.CorreoElectronico;
            tbtelefono.Text = aspirante.Telefono;
            tbRutaVideo.Text = "Video";
            lbVideoEdicion.Content = "Video ya existente. en caso de actualizar da clic en añadir";
            tbNombreUsuario.Text = aspirante.NombreUsuario;
            pbClave.Password = aspirante.Clave;
            pbClaveConfirmacion.Password = aspirante.Clave;
            cargarImagen(aspirante.Fotografia);
            cargarOficios(aspirante.Oficios);
            nuevaFotografia = false;
            nuevoVideo = false;
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
                        this.imgFotografiaAspirante.Source = imagen;
                    }
                }

            }
            catch (Exception)
            {
                imgFotografiaAspirante.Source = null;
            }
        }

        private async void cargarOficios(List<Oficio> oficios)
        {
            categorias = await CategoriaDAO.GetCategorias();
            for (int x = 0; x < oficios.Count; x++)
            {
                for (int y = 0; y < categorias.Count; y++)
                {
                    if (categorias[y].IdCategoria == oficios[x].IdCategoria)
                    {
                        oficios[x].NombreCategoria = categorias[y].NombreCategoria;
                        break;
                    }
                }
            }

            foreach (var item  in oficios)
            {
                this.oficios.Add(item);
            }

            dgExperienciaCategoria.ItemsSource = this.oficios;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            RegistroPerfil menuRegistro = new RegistroPerfil();
            menuRegistro.Show();
            this.Close();
        }

        private async void CargarVentana()
        {
            cbCategorias.ItemsSource =  await CategoriaDAO.GetCategorias();
            cbExperienciaLaboral.Items.Clear();
            cbExperienciaLaboral.Items.Add("1 a 4 meses");
            cbExperienciaLaboral.Items.Add("4 a 6 meses");
            cbExperienciaLaboral.Items.Add("6 meses a 1 año");
            cbExperienciaLaboral.Items.Add("1 a 6 años");
            cbExperienciaLaboral.Items.Add("Mayor a 6 años");
        }

        private void btnSeleccionarVideo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog selectorVideo = new OpenFileDialog();
            selectorVideo.Filter = "Archivo mp4|*.mp4";
            if (selectorVideo.ShowDialog() == true)
            {
                Uri uriVideo;
                tbRutaVideo.Text = selectorVideo.FileName;
                FileInfo informacionVideo = new FileInfo(selectorVideo.FileName);
                if (informacionVideo.Length > (1024 * 1024 * 3))
                {
                    MessageBox.Show("No se permite la carga de mayores a lo especificado, intentar de nuevo","¡Operación!");
                    nuevoVideo = false;
                    tbRutaVideo.Text = "video";
                }
                else
                {
                    rutaVideo = selectorVideo.FileName;
                    lbVideoEdicion.Content = "";
                    nuevoVideo = true;
                }

            }
            
        }


        private async void btnGuardarAspirante_Click(object sender, RoutedEventArgs e)
        {
            if (isNuevo)
            {
                if (validarCampos(isNuevo))
                {
                    Uri uriImagen;
                    Uri uriVideo;

                    Modelo.clases.Usuario user = new Modelo.clases.Usuario();

                    user.RutaFotografia = rutaImagen;
                    uriImagen = new Uri(user.RutaFotografia);
                    user.Fotografia = System.IO.File.ReadAllBytes(uriImagen.LocalPath);

                    aspirante.RutaVideo = rutaVideo;
                    uriVideo = new Uri(aspirante.RutaVideo);
                    aspirante.RegistroVideo = System.IO.File.ReadAllBytes(uriVideo.LocalPath);

                    aspirante.NombreAspirante = tbNombreAspirante.Text;
                    aspirante.Direccion = tbDireccion.Text;
                    aspirante.FechaNacimiento = (DateTime)dpFechaNacimiento.SelectedDate;
                    user.CorreoElectronico = tbCorreoElectronico.Text;
                    aspirante.Telefono = tbtelefono.Text;
                    user.NombreUsuario = tbNombreUsuario.Text;
                    user.Clave = pbClave.Password;
                    aspirante.Oficios = oficios.ToList();

                    int resultado = await AspiranteDAO.PostAspirante(user, aspirante);
                    if (resultado == 1)
                    {
                        MessageBox.Show("Registro en el sistema exitoso, favor de inciar con las credenciales registradas", "Operación exitosa");
                        MessageBox.Show("Nombre Usuario: " + user.NombreUsuario + "\n" + "Constraseña" + user.Clave, "Credenciales");
                        Login login = new Login();
                        login.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error al registrar tu perfil Aspirante", "¡Operación!");
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
                    Modelo.clases.Aspirante modificarAspirante = new Modelo.clases.Aspirante();

                    if (tbNombreAspirante.Text == aspirante.NombreAspirante && tbDireccion.Text == aspirante.Direccion && tbCorreoElectronico.Text == aspirante.CorreoElectronico
                        && tbtelefono.Text == aspirante.Telefono && tbNombreUsuario.Text == aspirante.NombreUsuario &&
                        pbClave.Password == aspirante.Clave)
                    {
                        MessageBox.Show("Para poder modificar tu registro es necesario almenos modificar un campo.", "¡Operacion!");
                    }
                    else
                    {
                        if (nuevaFotografia)
                        {
                            Uri uriImagen;
                            modificarAspirante.RutaFotografia = rutaImagen;
                            uriImagen = new Uri(modificarAspirante.RutaFotografia);
                            modificarAspirante.Fotografia = System.IO.File.ReadAllBytes(uriImagen.LocalPath);
                        }
                        else
                        {
                            byte[] fotografia;
                            fotografia = aspirante.Fotografia;
                            modificarAspirante.Fotografia = fotografia;

                        }

                        if (nuevoVideo)
                        {
                            Uri uriVideo;
                            modificarAspirante.RutaVideo = rutaVideo;
                            uriVideo = new Uri(modificarAspirante.RutaVideo);
                            modificarAspirante.RegistroVideo = System.IO.File.ReadAllBytes(uriVideo.LocalPath);
                        }

                        modificarAspirante.IdPerfilusuario = aspirante.IdPerfilusuario;
                        modificarAspirante.NombreAspirante = tbNombreAspirante.Text;
                        modificarAspirante.Direccion = tbDireccion.Text;
                        modificarAspirante.FechaNacimiento = (DateTime)dpFechaNacimiento.SelectedDate;
                        modificarAspirante.CorreoElectronico = tbCorreoElectronico.Text;
                        modificarAspirante.Estatus = 1;
                        modificarAspirante.IdAspirante = aspirante.IdAspirante;
                        modificarAspirante.Telefono = tbtelefono.Text;
                        modificarAspirante.NombreUsuario = tbNombreUsuario.Text;
                        modificarAspirante.Clave = pbClave.Password;
                        modificarAspirante.Token = aspirante.Token;
                        modificarAspirante.Oficios = oficios.ToList();

                        int resultado = await AspiranteDAO.putAspirante(modificarAspirante, nuevoVideo);
                        if (resultado == 1)
                        {
                            Modelo.clases.Usuario usuario = null;
                            usuario = await UsuarioDAO.getUsuario(modificarAspirante.IdPerfilusuario, modificarAspirante.Token);
                            usuario.Token = aspirante.Token;
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
                }
                else
                {
                    MessageBox.Show("Al registrar tu perfil verifica que los campos no esten vacios. ", "¡Operación!");
                }
            }
        }

        private void btnSeleccionarImagen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog selectorDocumento = new OpenFileDialog();
            selectorDocumento.Filter = "Imagen jpg|*.jpg";
            if (selectorDocumento.ShowDialog() == true)
            {
                Uri uriImagen;
                rutaImagen = selectorDocumento.FileName;

                uriImagen = new Uri(rutaImagen);
                imgFotografiaAspirante.Source = new BitmapImage(uriImagen);
                nuevaFotografia = true;
            }

        }

        private void btnAgregarCategoria_Click(object sender, RoutedEventArgs e)
        {
            if (cbCategorias.SelectedIndex > -1 && cbExperienciaLaboral.SelectedIndex > -1)
            {
                Categoria categoria = (Categoria)cbCategorias.SelectedItem;
                int estaLista = oficios.ToList().FindIndex(x => x.IdCategoria == categoria.IdCategoria);
                if(estaLista == -1){
                    Oficio oficio = new Oficio();
                    oficio.IdCategoria = categoria.IdCategoria;
                    oficio.NombreCategoria = categoria.NombreCategoria;
                    oficio.Experiencia = cbExperienciaLaboral.SelectedValue.ToString();
                    oficios.Add(oficio);
                    dgExperienciaCategoria.ItemsSource = oficios;
                }
                else
                {
                    MessageBox.Show("oficio agregado anteriormente");

                }
            }
            else
            {
                MessageBox.Show("algun combo box exta vacio, verificar");
            }
            dgExperienciaCategoria.ItemsSource = oficios;
        }

        private void btnQuitarCategoria_Click(object sender, RoutedEventArgs e)
        {
            if (dgExperienciaCategoria.SelectedIndex > -1)
            {
                Oficio oficioSeleccionado = (Oficio) dgExperienciaCategoria.SelectedItem;
                oficios.Remove(oficioSeleccionado);
                dgExperienciaCategoria.ItemsSource = oficios;
            }
            else
            {
                MessageBox.Show("seleccionar un oficio");
            }
        }

        private bool validarCampos(bool isNuevo)
        {
            bool validar = false;
            if (isNuevo)
            {
                if (tbNombreAspirante.Text == "")
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
                else if (tbCorreoElectronico.Text == "")
                {
                    validar = false;
                }
                else if (tbtelefono.Text == "")
                {
                    validar = false;
                }
                else if (tbNombreUsuario.Text == "")
                {
                    validar = false;
                }
                else if (pbClave.Password != "" || pbClaveConfirmacion.Password != "")
                {
                    if (pbClave.Password != pbClaveConfirmacion.Password)
                    {
                        MessageBox.Show("Por favor introducir la misma contraseña en ambos campos para confirmar", "¡Operacion!");
                        validar = false;
                    }
                    else if (imgFotografiaAspirante.Source == null) 
                    {
                        MessageBox.Show("Por favor seleccionar una foto de perfil para tu cuenta, preferentemente una fotografia personal", "¡Operación!");
                        validar = false;
                    }
                    else if (rutaVideo == null)
                    {
                        MessageBox.Show("Por favor seleccionar una vides de presentación para tu cuenta", "¡Operación!");
                        validar = false;
                    }
                    else
                    {
                        validar = true;
                    }
                }
            }
            else
            {
                validar = true;
                if (tbNombreAspirante.Text == "")
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
                else if (tbCorreoElectronico.Text == "")
                {
                    validar = false;
                }
                else if (tbtelefono.Text == "")
                {
                    validar = false;
                }
                else if (tbNombreUsuario.Text == "")
                {
                    validar = false;
                }
                else if (pbClave.Password != "" || pbClaveConfirmacion.Password != "")
                {
                    if (pbClave.Password != pbClaveConfirmacion.Password)
                    {
                        MessageBox.Show("Por favor introducir la misma contraseña en ambos campos para confirmar", "¡Operacion!");
                        validar = false;
                    }
                    else if (imgFotografiaAspirante.Source == null)
                    {
                        MessageBox.Show("Por favor seleccionar una foto de perfil para tu cuenta, preferentemente una fotografia personal", "¡Operación!");
                        validar = false;
                    }
                    else if (rutaVideo == null)
                    {
                        MessageBox.Show("Por favor seleccionar una vides de presentación para tu cuenta", "¡Operación!");
                        validar = false;
                    }
                    else
                    {
                        validar = true;
                    }
                }
            }

            return validar;
        }
    }
}
