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
        OfertaEmpleo ofertaEmpleoEdicion = new OfertaEmpleo();

        private string token ="";
        private int idOfertaEmpleo = 0;

        observadorRespuesta notificacion; ///
        Boolean isNuevo = true; ///

        List<FotografiaOferta> imagenesEdicion = new List<FotografiaOferta>();
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

            lbAccion.Content = "Modificación de oferta de empleo";
            try
            {
                string tokenString = "" + token;

                ofertaEmpleoEdicion = await OfertaEmpleoDAO.GetOfertaEmpleo(idOfertaEmpleo, token);

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
                dpFechaInicio.IsEnabled = false;
                dpFechaFinalizacion.SelectedDate = ofertaEmpleoEdicion.FechaFinalizacion;
                dpFechaFinalizacion.IsEnabled = false;
                tbPago.Text = "" + ofertaEmpleoEdicion.CantidadPago;
                tbDireccion.Text = ofertaEmpleoEdicion.Direccion;
                tbDescripcion.Text = ofertaEmpleoEdicion.Descripcion;

                marcarChecksDias(ofertaEmpleoEdicion.DiasLaborales);

                ofertaEmpleoEdicion.FotografiasEdicion = await OfertaEmpleoDAO.GetFotografiasOfertaEmpleo(idOfertaEmpleo);
                //Guardamos las imagenes con id
                imagenesEdicion = ofertaEmpleoEdicion.FotografiasEdicion;
                CargarImagenesEdicion(ofertaEmpleoEdicion.FotografiasEdicion);

            }
            catch (Exception exception)
            {
                mensajes = new MensajesSistema("Error", "Hubo un error al cargar la oferta de empleo, favor de intentar más tarde", exception.StackTrace, exception.Message);
                mensajes.ShowDialog();
            }
            
            try
            {
                
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void CargarImagenesEdicion(List<FotografiaOferta> fotografias)
        {
            foreach (FotografiaOferta imagenAux in fotografias)
            {
                ofertaEmpleoEdicion.Fotografias.Add(imagenAux.Imagen);
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
            if (validarOfertaEmpleo(ofertaEmpleoNueva))
            {
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
                        notificacion.actualizarCambios("Registrar oferta empleo");
                        this.Close();
                    }


                }
                catch (Exception exception)
                {
                    mensajes = new MensajesSistema("Error", "Hubo un error al intentar registrar, favor de intentar más tarde", exception.StackTrace, exception.Message);
                    mensajes.ShowDialog();
                }
            }


        }

        private async void actualizarOfertaEmpleo()
        {
            OfertaEmpleo ofertaEmpleoModificada = new OfertaEmpleo();
            if (validarOfertaEmpleo(ofertaEmpleoModificada))
            {
                try
                {
                    ofertaEmpleoModificada.IdOfertaEmpleo = idOfertaEmpleo;
                    ofertaEmpleoModificada.IdPerfilEmpleador = idPerfilEmpleador;
                    Categoria categoria = (Categoria)cbCategorias.SelectedItem;
                    int idCategoria = categoria.IdCategoria;


                    ofertaEmpleoModificada.IdCategoriaEmpleo = idCategoria;
                    ofertaEmpleoModificada.Nombre = tbNombreEmpleo.Text;
                    ofertaEmpleoModificada.Descripcion = tbDescripcion.Text;
                    ofertaEmpleoModificada.Vacantes = int.Parse(tbVacantes.Text);
                    ofertaEmpleoModificada.DiasLaborales = diasLaborales();

                    string tipoPago = (string)cbTipoPago.SelectedItem;
                    ofertaEmpleoModificada.TipoPago = tipoPago;

                    ofertaEmpleoModificada.CantidadPago = int.Parse(tbPago.Text);
                    ofertaEmpleoModificada.Direccion = tbDireccion.Text;
                    string horaInicio = tbHoraInicio.Text;
                    string horaFin = tbHoraFin.Text;

                    ofertaEmpleoModificada.HoraInicio = TimeOnly.Parse(horaInicio);
                    ofertaEmpleoModificada.HoraFin = TimeOnly.Parse(horaFin);


                    ofertaEmpleoModificada.FechaInicio = dpFechaInicio.SelectedDate.Value;
                    ofertaEmpleoModificada.FechaFinalizacion = dpFechaFinalizacion.SelectedDate.Value;
                    ofertaEmpleoModificada.FotografiasEdicion = imagenesEdicion;
                    ofertaEmpleoModificada.Fotografias = imagenes;

                
                    int actualizado = await OfertaEmpleoDAO.PutOfertaEmpleo(ofertaEmpleoModificada, token);
                    if (actualizado >= 1)
                    {
                        mensajes = new MensajesSistema("AccionExitosa", "Se ha actualizado correctamente la oferta de empleo: " + ofertaEmpleoModificada.Nombre, "Actualizar oferta de empleo", "Oferta de empleo registrada");
                        mensajes.ShowDialog();

                        notificacion.actualizarCambios("Actualizar oferta empleo");
                        this.Close();
                    } else if (actualizado == 0)
                    {
                        mensajes = new MensajesSistema("AccionExitosa", "No se ha actualizado correctamente la oferta de empleo: " + ofertaEmpleoModificada.Nombre, "Actualizar oferta de empleo", "La oferta de empleo no tuvo cambios debido a que no ingreso ninguno");
                        mensajes.ShowDialog();
                    }




                }
                catch (Exception exception)
                {
                    mensajes = new MensajesSistema("Error", "Hubo un error al intentar actualizar, favor de intentar más tarde", exception.StackTrace, exception.Message);
                    mensajes.ShowDialog();
                }
            }

        }
        private bool validarOfertaEmpleo(OfertaEmpleo ofertaEmpleoNueva)
        {
            bool valido = true;
            ValidacionFormulario validarFormulario = new ValidacionFormulario();

            List<ComboBox> combobox = new List<ComboBox>();
            List<TextBox> textBox = new List<TextBox>();
            List<DatePicker> datePicker = new List<DatePicker>();
            List<CheckBox> checkBoxes = new List<CheckBox>();
            checkBoxes.Add(chkLunes);
            checkBoxes.Add(chkMartes);
            checkBoxes.Add(chkMiercoles);
            checkBoxes.Add(chkJueves);
            checkBoxes.Add(chkViernes);
            checkBoxes.Add(chkSabado);
            checkBoxes.Add(chkDomingo);

            combobox.Add(cbCategorias);
            combobox.Add(cbTipoPago);

            textBox.Add(tbNombreEmpleo);
            textBox.Add(tbDescripcion);
            textBox.Add(tbVacantes);
            textBox.Add(tbPago);
            textBox.Add(tbDireccion);
            textBox.Add(tbDescripcion);
            textBox.Add(tbHoraInicio);
            textBox.Add(tbHoraFin);

            datePicker.Add(dpFechaInicio);
            datePicker.Add(dpFechaFinalizacion);



            bool vacio = validarFormulario.comboboxVacios(combobox) && validarFormulario.textFieldsVacios(textBox) && validarFormulario.dataPickersVacios(datePicker) && validarFormulario.checkBoxsVacios(checkBoxes);
            
            if (vacio && imagenes.Count < 3)
            {
                valido = false;
                mensajes = new MensajesSistema("AccionInvalida", "No se puede registrar con campos vacios", "Guardar oferta de empleo", "Para guardar una oferta de empleo debe ingresar toda la información requerida");
                mensajes.ShowDialog();
            }            
            else
            {
                int comparacionFechas = 0;
                //Solo se compara la fecha si es registro nuevo
                if (isNuevo)
                {
                    comparacionFechas = validarFormulario.compararFecha(dpFechaInicio, dpFechaFinalizacion);
                }
                else
                {
                    comparacionFechas = 1;
                }
                
                if (comparacionFechas == 1)
                {
                    bool horasValidas;
                    horasValidas = validarFormulario.validarHora(tbHoraInicio);
                    if (horasValidas)
                    {
                        horasValidas = validarFormulario.validarHora(tbHoraFin);
                        if (horasValidas)
                        {
                            if (validarFormulario.textFieldEntero(tbVacantes) && validarFormulario.textFieldEntero(tbPago))
                            {

                                if (!ValidacionFormulario.validarEsNumero(tbDireccion) && !ValidacionFormulario.validarEsNumero(tbDescripcion) && !ValidacionFormulario.validarEsNumero(tbNombreEmpleo))
                                {
                                    if (imgFoto.Source != null && imgFoto2.Source != null && imgFoto3.Source != null)
                                    {
                                        valido = true;
                                    }
                                    else
                                    {
                                        valido = false;
                                        mensajes = new MensajesSistema("AccionInvalida", "No se puede agregar una oferta de empleo sin fotografias", "Guardar oferta de empleo", "Para guardar una oferta de empleo debe ingresar 3 fotografías obligatoriamente");
                                        mensajes.ShowDialog();
                                    }
                                }
                                else
                                {
                                    valido = false;
                                    mensajes = new MensajesSistema("AccionInvalida", "No se puede registrar puros numeros en estos campos", "Guardar oferta de empleo", "Para guardar una oferta de empleo debe ingresar toda la información correspondiente al campo");
                                    mensajes.ShowDialog();
                                }

                            }
                            else
                            {
                                valido = false;
                            }

                        }
                        else
                        {
                            valido = false;
                        }
                    }
                    else
                    {
                        valido = false;
                    }

                }
                else if (comparacionFechas == -1)
                {
                    valido = false;
                    mensajes = new MensajesSistema("AccionInvalida", "No se puede seleccionar que la fecha de inicio sea mayor que la de finalización", "Guardar oferta de empleo", "La fecha de inicio debe ser inferior a la de finalización");
                    mensajes.ShowDialog();
                }
                else if (comparacionFechas == -2)
                {
                    valido = false;
                    mensajes = new MensajesSistema("AccionInvalida", "No se puede seleccionar que la fecha de inicio sea menor a la fecha actual", "Guardar oferta de empleo", "La fecha de inicio debe ser superior a la fecha actual");
                    mensajes.ShowDialog();
                }
                else if (comparacionFechas == 0)
                {
                    valido = false;
                    mensajes = new MensajesSistema("AccionInvalida", "No se puede seleccionar que las fechas sean iguales", "Guardar oferta de empleo", "La fecha de inicio debe ser inferior y la fecha de finalización debe ser mayor a la de inicio");
                    mensajes.ShowDialog();
                }


            }                      

            return valido;
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

                chkLunes.IsEnabled = false;

                if (diasLaborales[i].Equals('2'))
                {
                    chkMartes.IsChecked = true;                    
                }

                chkMartes.IsEnabled = false;

                if (diasLaborales[i].Equals('3'))
                {
                    chkMiercoles.IsChecked = true;                    
                }

                chkMiercoles.IsEnabled = false;

                if (diasLaborales[i].Equals('4'))
                {
                    chkJueves.IsChecked = true;                    
                }

                chkJueves.IsEnabled = false;

                if (diasLaborales[i].Equals('5'))
                {
                    chkViernes.IsChecked = true;                   
                }

                chkViernes.IsEnabled = false;

                if (diasLaborales[i].Equals('6'))
                {
                    chkSabado.IsChecked = true;                    
                }

                chkSabado.IsEnabled = false;

                if (diasLaborales[i].Equals('7'))
                {
                    chkDomingo.IsChecked = true;                    
                }

                chkDomingo.IsEnabled = false;

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