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

namespace El_Camello.Vistas.Empleador
{
    /// <summary>
    /// Interaction logic for RegistroOfertaEmpleo.xaml
    /// </summary>
    public partial class RegistroOfertaEmpleo : Window
    {
        private int idPerfilEmpleador;
        private List<Categoria> categorias;
        private string token ="";

        List<byte[]> imagenes = new List<byte[]>();

        Uri fileUri1;
        Uri fileUri2;
        Uri fileUri3;

        MensajesSistema error;

        public RegistroOfertaEmpleo(int idPerfilEmpleador, string token)
        {
            this.idPerfilEmpleador = idPerfilEmpleador;
            this.token = token;
            InitializeComponent();
            cargarDatosComponentes();

        }

        private async void cargarOfertaEmpleo()
        {

        }

        private void cargarDatosComponentes()
        {
            cargarCategoriasCombobox();
            cargarTipoEmpleos();
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
                error = new MensajesSistema("Error", "Hubo un error al cargar las categorias de empleo, favor de intentar más tarde", exception.StackTrace, exception.Message);
                error.ShowDialog();
            }
        }

        private void cargarTipoEmpleos()
        {
            cbTipoEmpleo.Items.Clear();
            cbTipoEmpleo.Items.Add("Medio tiempo");
            cbTipoEmpleo.Items.Add("Tiempo completo");

        }

        private void cargarTipoPago()
        {
            cbTipoPago.Items.Clear();
            cbTipoPago.Items.Add("Por día");
            cbTipoPago.Items.Add("Por hora");

        }

        private void guardarOfertaEmpleo(object sender, RoutedEventArgs e)
        {
            //Validar
            registrarOfertaEmpleo();

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
            
            }catch(Exception exception)
            {
                error = new MensajesSistema("Error", "Hubo un error al intentar registrar, favor de intentar más tarde", exception.StackTrace, exception.Message);
                error.ShowDialog();
            }

        }

        private string diasLaborales()
        {
            string diasLaborales = "";

            if (chkLunes.IsPressed)
            {
                diasLaborales += "1";
            }
            if (chkMartes.IsPressed)
            {
                diasLaborales += "2";
            }
            if (chkMiercoles.IsPressed)
            {
                diasLaborales += "3";
            }
            if (chkJueves.IsPressed)
            {
                diasLaborales += "4";
            }
            if (chkViernes.IsPressed)
            {
                diasLaborales += "5";
            }
            if (chkSabado.IsPressed)
            {
                diasLaborales += "6";
            }
            if (chkDomingo.IsPressed)
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
            openFileDialog.Filter = "Image files (*.jpg, *.png) | *.jpg; *.png";

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
    }
}