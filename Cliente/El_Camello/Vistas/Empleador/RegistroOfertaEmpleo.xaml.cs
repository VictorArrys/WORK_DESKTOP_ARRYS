using El_Camello.Assets.utilerias;
using El_Camello.Modelo.clases;
using El_Camello.Modelo.dao;
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

using El_Camello.Modelo.interfaz;

namespace El_Camello.Vistas.Empleador
{
    /// <summary>
    /// Interaction logic for RegistroOfertaEmpleo.xaml
    /// </summary>
    public partial class RegistroOfertaEmpleo : Window
    {
        private int idPerfilEmpleador = 0;
        private List<Categoria> categorias;
        private List<string> tiposDePago;

        private string token ="";
        private int idOfertaEmpleo = 0;

        observadorRespuesta notificacion; ///
        Boolean isNuevo = true; ///


        List<byte[]> imagenes = new List<byte[]>();

        Uri fileUri1;
        Uri fileUri2;
        Uri fileUri3;

        MensajesSistema mensajes;

        public RegistroOfertaEmpleo(observadorRespuesta notificacion,int idPerfilEmpleador, string token)
        {
            this.idPerfilEmpleador = idPerfilEmpleador;
            this.token = token;
            this.notificacion = notificacion;
            InitializeComponent();
            cargarDatosComponentes();

        }

        public RegistroOfertaEmpleo(observadorRespuesta notificacion,int idPerfilEmpleador, int idOfertaEmpleo, string token)
        {
            this.idPerfilEmpleador = idPerfilEmpleador;
            this.token = token;
            this.notificacion = notificacion;
            this.idOfertaEmpleo = idOfertaEmpleo;
            isNuevo = false;
            InitializeComponent();
            cargarDatosComponentes();

            cargarOfertaEmpleo();

        }

        private async void cargarOfertaEmpleo()
        {
            try
            {
                string tokenString = "" + token;

                OfertaEmpleo ofertaEmpleoEdicion = await OfertaEmpleoDAO.GetOfertaEmpleo(idOfertaEmpleo, token);

                tbNombreEmpleo.Text = ofertaEmpleoEdicion.Nombre;

                foreach (string tipoPago in tiposDePago)
                {
                    if (tipoPago == ofertaEmpleoEdicion.TipoPago)
                    {
                        cbTipoPago.SelectedItem = tipoPago;
                    }
                }

                foreach (Categoria categoriaLista in categorias)
                {
                    if (categoriaLista.IdCategoria == ofertaEmpleoEdicion.IdCategoriaEmpleo)
                    {
                        cbCategorias.SelectedItem = categoriaLista;
                    }
                }

                tbHoraInicio.Text = "" + ofertaEmpleoEdicion.HoraInicio;
                tbHoraFin.Text = "" + ofertaEmpleoEdicion.HoraFin;
                tbVacantes.Text = "" + ofertaEmpleoEdicion.Vacantes;
                dpFechaInicio.SelectedDate = ofertaEmpleoEdicion.FechaInicio;
                dpFechaFinalizacion.SelectedDate = ofertaEmpleoEdicion.FechaFinalizacion;
                tbPago.Text = "" + ofertaEmpleoEdicion.CantidadPago;
                tbDireccion.Text = ofertaEmpleoEdicion.Direccion;
                tbDescripcion.Text = ofertaEmpleoEdicion.Descripcion;

                marcarChecksDias(ofertaEmpleoEdicion.DiasLaborales);



            }
            catch (Exception exception)
            {
                mensajes = new MensajesSistema("Error", "Hubo un error al cargar la oferta de empleo, favor de intentar más tarde", exception.StackTrace, exception.Message);
                mensajes.ShowDialog();
            }
            /*
            try
            {
                List<FotografiaOferta> fotografiasEdicion = await OfertaEmpleoDAO.GetFotografiasOfertaEmpleo(idOfertaEmpleo);
                CargarImagenes(fotografiasEdicion);
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }*/

        }

        private void CargarImagenes(List<FotografiaOferta> fotografias)
        {
            foreach (FotografiaOferta imagenAux in fotografias)
            {
                using (var ms1 = new System.IO.MemoryStream(imagenAux.Imagen))
                {
                    var imagen = new BitmapImage();
                    imagen.BeginInit();
                    imagen.CacheOption = BitmapCacheOption.OnLoad;
                    imagen.StreamSource = ms1;
                    imagen.EndInit();
                    if (imgFoto.Source == null)
                    {
                        imgFoto.Source = imagen;
                    }
                    else if (imgFoto2.Source == null)
                    {
                        imgFoto2.Source = imagen;
                    }
                    else if (imgFoto3.Source == null)
                    {
                        imgFoto3.Source = imagen;
                    }

                }

            }

        }

        private void cargarDatosComponentes()
        {
            cargarCategoriasCombobox();
            cargarTipoPago();

        }

        private async void cargarCategoriasCombobox()
        {
            try
            {
                categorias = await CategoriaDAO.GetCategorias();
                cbCategorias.ItemsSource = categorias;
            }
            catch(Exception exception) {
                mensajes = new MensajesSistema("Error", "Hubo un error al cargar las categorias de empleo, favor de intentar más tarde", exception.StackTrace, exception.Message);
                mensajes.ShowDialog();
            }
        }

        private void cargarTipoPago()
        {
            tiposDePago = new List<string>();
            cbTipoPago.Items.Clear();
            tiposDePago.Add("Por día");
            tiposDePago.Add("Por hora");

            cbTipoPago.ItemsSource = tiposDePago;

        }

        private void guardarOfertaEmpleo(object sender, RoutedEventArgs e)
        {

            //Validar
            if (isNuevo)
            {
                registrarOfertaEmpleo();
            }
            else
            {
                actualizarOfertaEmpleo();
            }

        }

        private async void registrarOfertaEmpleo()
        {
            OfertaEmpleo ofertaEmpleoNueva = new OfertaEmpleo();

            try
            {

            ofertaEmpleoNueva.IdPerfilEmpleador = idPerfilEmpleador;
            Categoria categoria = (Categoria)cbCategorias.SelectedItem;
            int idCategoria = categoria.IdCategoria;


            ofertaEmpleoNueva.IdCategoriaEmpleo = idCategoria;
            ofertaEmpleoNueva.Nombre = tbNombreEmpleo.Text;
            ofertaEmpleoNueva.Descripcion = tbDescripcion.Text;
            ofertaEmpleoNueva.Vacantes = int.Parse(tbVacantes.Text);
            ofertaEmpleoNueva.DiasLaborales = diasLaborales();

            string tipoPago = (string)cbTipoPago.SelectedItem;
            ofertaEmpleoNueva.TipoPago = tipoPago;


            ofertaEmpleoNueva.CantidadPago = int.Parse(tbPago.Text);
            ofertaEmpleoNueva.Direccion = tbDireccion.Text;
            string horaInicio = tbHoraInicio.Text;
            string horaFin = tbHoraFin.Text;

            ofertaEmpleoNueva.HoraInicio = TimeOnly.Parse(horaInicio);
            ofertaEmpleoNueva.HoraFin = TimeOnly.Parse(horaFin);


            ofertaEmpleoNueva.FechaInicio = dpFechaInicio.SelectedDate.Value;
            ofertaEmpleoNueva.FechaFinalizacion = dpFechaFinalizacion.SelectedDate.Value;

            ofertaEmpleoNueva.Fotografias = imagenes;

            
            int idOfertaEmpleo = await OfertaEmpleoDAO.PostOfertaEmpleo(ofertaEmpleoNueva, token);
            if (idOfertaEmpleo > 0)
                {
                    mensajes = new MensajesSistema("AccionExitosa", "Se ha registrado correctamente la oferta de empleo: " + ofertaEmpleoNueva.Nombre, "Registrar oferta de empleo", "Oferta de empleo registrada");
                    mensajes.ShowDialog();
                }

            }catch(Exception exception)
            {
                mensajes = new MensajesSistema("Error", "Hubo un error al intentar registrar, favor de intentar más tarde", exception.StackTrace, exception.Message);
                mensajes.ShowDialog();
            }

        }

        private async void actualizarOfertaEmpleo()
        {
            OfertaEmpleo ofertaEmpleoNueva = new OfertaEmpleo();

            try
            {
                ofertaEmpleoNueva.IdOfertaEmpleo = idOfertaEmpleo;
                ofertaEmpleoNueva.IdPerfilEmpleador = idPerfilEmpleador;
                Categoria categoria = (Categoria)cbCategorias.SelectedItem;
                int idCategoria = categoria.IdCategoria;


                ofertaEmpleoNueva.IdCategoriaEmpleo = idCategoria;
                ofertaEmpleoNueva.Nombre = tbNombreEmpleo.Text;
                ofertaEmpleoNueva.Descripcion = tbDescripcion.Text;
                ofertaEmpleoNueva.Vacantes = int.Parse(tbVacantes.Text);
                ofertaEmpleoNueva.DiasLaborales = diasLaborales();

                string tipoPago = (string)cbTipoPago.SelectedItem;
                ofertaEmpleoNueva.TipoPago = tipoPago;


                ofertaEmpleoNueva.CantidadPago = int.Parse(tbPago.Text);
                ofertaEmpleoNueva.Direccion = tbDireccion.Text;
                string horaInicio = tbHoraInicio.Text;
                string horaFin = tbHoraFin.Text;

                ofertaEmpleoNueva.HoraInicio = TimeOnly.Parse(horaInicio);
                ofertaEmpleoNueva.HoraFin = TimeOnly.Parse(horaFin);


                ofertaEmpleoNueva.FechaInicio = dpFechaInicio.SelectedDate.Value;
                ofertaEmpleoNueva.FechaFinalizacion = dpFechaFinalizacion.SelectedDate.Value;

                ofertaEmpleoNueva.Fotografias = imagenes;


                int actualizado = await OfertaEmpleoDAO.PutOfertaEmpleo(ofertaEmpleoNueva, token);
                if (actualizado > 0)
                {
                    mensajes = new MensajesSistema("AccionExitosa", "Se ha actualizado correctamente la oferta de empleo: " + ofertaEmpleoNueva.Nombre, "Registrar oferta de empleo", "Oferta de empleo registrada");
                    mensajes.ShowDialog();
                }

            }
            catch (Exception exception)
            {
                mensajes = new MensajesSistema("Error", "Hubo un error al intentar actualizar, favor de intentar más tarde", exception.StackTrace, exception.Message);
                mensajes.ShowDialog();
            }

        }

        private void marcarChecksDias(string diasLaborales)
        {
            int cantidad = diasLaborales.Length;

            for (int i= 0; i < cantidad; i++)
            {

                if (diasLaborales[i].Equals('1'))
                {
                    chkLunes.IsChecked = true;
                }
                if (diasLaborales[i].Equals('2'))
                {
                    chkMartes.IsChecked = true;
                }
                if (diasLaborales[i].Equals('3'))
                {
                    chkMartes.IsChecked = true;
                }
                if (diasLaborales[i].Equals('4'))
                {
                    chkJueves.IsChecked = true;
                }
                if (diasLaborales[i].Equals('5'))
                {
                    chkViernes.IsChecked = true;
                }
                if (diasLaborales[i].Equals('6'))
                {
                    chkSabado.IsChecked = true;
                }
                if (diasLaborales[i].Equals('7'))
                {
                    chkDomingo.IsChecked = true;
                }
            }


        }

        private string diasLaborales()
        {
            string diasLaborales = "";

            if (chkLunes.IsChecked == true)
            {
                diasLaborales += "1";
            }
            if (chkMartes.IsChecked == true)
            {
                diasLaborales += "2";
            }
            if (chkMiercoles.IsChecked == true)
            {
                diasLaborales += "3";
            }
            if (chkJueves.IsChecked == true)
            {
                diasLaborales += "4";
            }
            if (chkViernes.IsChecked == true)
            {
                diasLaborales += "5";
            }
            if (chkSabado.IsChecked == true)
            {
                diasLaborales += "6";
            }
            if (chkDomingo.IsChecked == true)
            {
                diasLaborales += "7";
            }


            MessageBox.Show("Días seleccionados: " + diasLaborales);
            return diasLaborales;
        }

        private void cancelarRegistro(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void agregarFoto(object sender, RoutedEventArgs e)
        {
            

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg) | *.jpg;";

            if (openFileDialog.ShowDialog() == true)
            {
                if (imgFoto.Source == null)
                {
                    fileUri1 = new Uri(openFileDialog.FileName);
                    imgFoto.Source = new BitmapImage(fileUri1);
                    byte[] imagen1;
                    imagen1 = System.IO.File.ReadAllBytes(fileUri1.LocalPath);
                    imagenes.Add(imagen1);

                }
                else if (imgFoto2.Source == null)
                {
                    fileUri2 = new Uri(openFileDialog.FileName);
                    imgFoto2.Source = new BitmapImage(fileUri2);
                    byte[] imagen2;
                    imagen2 = System.IO.File.ReadAllBytes(fileUri2.LocalPath);
                    imagenes.Add(imagen2);
                }
                else if (imgFoto3.Source == null)
                {
                    fileUri3 = new Uri(openFileDialog.FileName);
                    imgFoto3.Source = new BitmapImage(fileUri3);
                    byte[] imagen3;
                    imagen3 = System.IO.File.ReadAllBytes(fileUri3.LocalPath);
                    imagenes.Add(imagen3);
                }
                else if (imgFoto.Source != null && imgFoto2.Source != null && imgFoto3.Source != null)
                {
                    MessageBox.Show("Solo son máximo 3 fotografías", "Máximo de fotos");
                }
            }

        }

        private void removerFotos(object sender, RoutedEventArgs e)
        {
            imagenes.Clear();
            imgFoto.Source = null;
            imgFoto2.Source = null;
            imgFoto3.Source = null;

        }
    }
    
}